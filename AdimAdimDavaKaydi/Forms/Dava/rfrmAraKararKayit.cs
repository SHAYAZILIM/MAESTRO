using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rfrmAraKararKayit : Util.BaseClasses.AvpXtraForm
    {
        public rfrmAraKararKayit()
        {
            InitializeComponent();
            this.FormClosing += rfrmAraKararKayit_FormClosing;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
            this.EventlerKullanilacakMi = true;
        }

        private int gun;

        private bool kaydedildi;

        private DateTime tarh;

        #region Properties

        private TList<AV001_TD_BIL_ARA_KARAR> addNewList;
        private bool isModul;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_ARA_KARAR> AddNewList { get; set; }

        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);
                    c_lueDosya.EditValue = value.ID;

                    if (AddNewList == null)
                        AddNewList = new TList<AV001_TD_BIL_ARA_KARAR>();

                    AddNewList.AddingNew += Arakarar_AddingNew;

                    //AddNewList.AddNew();//Kayýt formlarý default 0 kayýtla getirilecek.
                    ucAraKarar1.MyDataSource = AddNewList;
                }
            }
        }

        #endregion Properties

        #region Events

        private void addNewKarar_ColumnChanged(object sender, AV001_TD_BIL_ARA_KARAREventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR karar = sender as AV001_TD_BIL_ARA_KARAR;
            if (e.Column == AV001_TD_BIL_ARA_KARARColumn.YERINE_GETIRME_GUN)
            {
                gun = Convert.ToInt32(e.Value);
                tarh = karar.TARIH;
                karar.YERINE_GETIRME_TARIH = tarh.AddDays(Convert.ToDouble(gun));
            }
        }

        private void Arakarar_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR addNewKarar = new AV001_TD_BIL_ARA_KARAR();
            addNewKarar.KAYIT_TARIHI = DateTime.Now;
            addNewKarar.KLASOR_KODU = "GENEL";
            addNewKarar.KONTROL_KIM = "AVUKATPRO";
            addNewKarar.KONTROL_NE_ZAMAN = DateTime.Now;
            addNewKarar.KONTROL_VERSIYON = 1;
            addNewKarar.STAMP = 1;
            addNewKarar.SUBE_KODU = 1;
            addNewKarar.KIM_YERINE_GETIRECEK = 0;
            addNewKarar.ColumnChanged += addNewKarar_ColumnChanged;
            e.NewObject = addNewKarar;
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            if (MyFoy == null && (int)c_lueDosya.EditValue < 1)
            {
                MessageBox.Show("Lütfen föy seçiniz");
                return;
            }

            foreach (AV001_TD_BIL_ARA_KARAR k in AddNewList)
            {
                string sStr = ucAraKarar.Validate(k);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show(sStr, "Uyarý");

                    result = false;
                    break;
                }
            }

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            ucAraKarar1.Enabled = true;
            if (c_lueDosya.EditValue != null)
                MyFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
        }

        private void rfrmAraKararKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void rfrmAraKararKayit_Load(object sender, EventArgs e)
        {
            if (IsModul)
            {
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);

                //c_lueDosya.Enter += delegate { c_lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(AvukatProLib.Extras.ModulTip.Dava.ToString()); };
                //c_lueDosya.Properties.ValueMember = "ID";
                //c_lueDosya.Properties.DisplayMember = "FOY_NO";
                //c_lueDosya.Properties.NullText = "Dava Dosyasý Seçiniz...";
                ucAraKarar1.Enabled = false;
            }
        }

        #endregion Events

        #region Methods

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;
            this.Show();
        }

        private bool CikabilirMi()
        {
            if (addNewList == null)
                return true;
            foreach (AV001_TD_BIL_ARA_KARAR k in AddNewList)
            {
                if (k.IsNew || k.HasDataChanged())
                    return false;
            }
            return true;
        }

        private bool Save()
        {
            if (MyFoy == null && (int)c_lueDosya.EditValue > 0)
                MyFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);

            AddNewList.ForEach(item =>
                {
                    item.DAVA_FOY_ID = MyFoy.ID;
                    if (item.TIP == (int)AvukatProLib.Extras.AraKararTip.Mehilsiz)
                        item.YERINE_GETIRME_TARIH = item.TARIH;
                });

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();
                DataRepository.AV001_TD_BIL_ARA_KARARProvider.DeepSave(trans, AddNewList);
                if (trans.IsOpen)
                    trans.Commit();
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>), typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                if (AddNewList[0].YERINE_GETIRILDI_MI == false && AddNewList[0].KIM_YERINE_GETIRECEK == 0)
                    Is.Util.IsHelper.IsleriKaydet(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
            finally
            {
                trans.Dispose();
            }
            return true;
        }

        #endregion Methods
    }
}