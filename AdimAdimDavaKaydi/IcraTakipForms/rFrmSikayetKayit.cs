using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmSikayetKayit : Util.BaseClasses.AvpXtraForm
    {
        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        public rFrmSikayetKayit()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rFrmSikayetKayit_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_SIKAYET> AddNewList { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_SIKAYET>();
                        AddNewList.AddingNew += Sikayet_AddingNew;
                        vGridSikayet.DataSource = value.AV001_TI_BIL_SIKAYETCollection;
                        dataNavigatorExtended1.DataSource = value.AV001_TI_BIL_SIKAYETCollection;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;

            AddNewList = MyFoy.AV001_TI_BIL_SIKAYETCollection;
            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool result = true;
            foreach (AV001_TI_BIL_SIKAYET n in AddNewList)
            {
                string sStr = ucSikayetBilgileri.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

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

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_SIKAYET s in AddNewList)
            {
                if (s.IsNew || s.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmSikayetKayit_Button_Kaydet_Click;
        }

        private void rFrmSikayetKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TI_BIL_SIKAYET n in AddNewList)
            {
                string sStr = ucSikayetBilgileri.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

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

        private void rFrmSikayetKayit_FormClosing(object sender, FormClosingEventArgs e)
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

        private void rFrmSikayetKayit_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.SikayetKategoriGetir(rlueKategori);
            BelgeUtil.Inits.SikayetNEdenGetir(rlueSNeden);
            BelgeUtil.Inits.CariAdliPersonelGetir(rlueAdliPer);
            BelgeUtil.Inits.perCariGetir(rlueTarafCAri);
        }

        private bool Save()
        {
            bool sonuc = false;

            MyFoy.AV001_TI_BIL_SIKAYETCollection.ForEach(delegate(AV001_TI_BIL_SIKAYET s) { s.ICRA_FOY_ID = MyFoy.ID; });

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_SIKAYETProvider.DeepSave(tran, MyFoy.AV001_TI_BIL_SIKAYETCollection);
                tran.Commit();
                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_SIKAYETCollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void Sikayet_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_SIKAYET addNew = e.NewObject as AV001_TI_BIL_SIKAYET;

            if (addNew == null)
                addNew = new AV001_TI_BIL_SIKAYET();

            e.NewObject = addNew;
        }
    }
}