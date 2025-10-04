using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AvukatPro.WinUI
{
    public partial class frmIcraHacizIstirak : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraHacizIstirak()
        {
            InitializeComponent();

            InitializeEvents();
            this.FormClosing += frmIcraHacizIstirak_FormClosing;
        }

        private TList<AV001_TI_BIL_HACIZ_ISTIRAK> addNewList;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_ISTIRAK> AddNewList
        {
            get { return addNewList; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    addNewList = value;
                    gridIcraHacizIstirak.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TI_BIL_HACIZ_ISTIRAK>();
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueIstirakIstenen });
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;
            InitData();
            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_HACIZ_ISTIRAK n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (panelControl1.Visible)
            {
                gridIcraHacizIstirak.Visible = true;
                panelControl1.Visible = false;
                gridIcraHacizIstirak.BringToFront();
            }
            else if (gridIcraHacizIstirak.Visible)
            {
                panelControl1.Visible = true;
                gridIcraHacizIstirak.Visible = false;
                panelControl1.BringToFront();
            }
        }

        private void frmIcraHacizIstirak_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            // Validate

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Değişiklikler kaydedildi.", "Kaydet ve Çık",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme işlemi yapılamıyor.",
                                        "Kaydet ve Çık", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmIcraHacizIstirak_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapılan değişiklikleri kaydetmediniz.Şimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmIcraHacizIstirak_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmIcraHacizIstirak_Load(object sender, EventArgs e)
        {
            ////LOAD
        }

        private void InitData()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.perCariGetir(rlueIstirakIsteyen);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.ImtiyazliAlacakGetir(rlueImtiyazli);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.HacizChildGetir(myFoy, rLueMallar);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraHacizIstirak_Button_Kaydet_Click;
        }

        private void rLueMallar_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.EditValue != null && gwIcraHacizIstirak.FocusedRowHandle >= 0)
            {
                int ID = Convert.ToInt32(lue.EditValue);
                AV001_TI_BIL_HACIZ_CHILD child = DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(ID);
                addNewList[gwIcraHacizIstirak.FocusedRowHandle].HACIZLI_MAL_CINS_ID = child.HACIZLI_MAL_CINS_ID;
                addNewList[gwIcraHacizIstirak.FocusedRowHandle].HACIZLI_MAL_KATEGORI_ID = child.HACIZLI_MAL_KATEGORI_ID;
                addNewList[gwIcraHacizIstirak.FocusedRowHandle].HACIZLI_MAL_TUR_ID = child.HACIZLI_MAL_TUR_ID;
            }
        }

        private bool Save()
        {
            bool sonuc = false;
            MyFoy.AV001_TI_BIL_HACIZ_ISTIRAKCollection.AddRange(AddNewList);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_HACIZ_ISTIRAKProvider.DeepSave(tran,
                                                                           MyFoy.AV001_TI_BIL_HACIZ_ISTIRAKCollection);

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
                    MyFoy.AV001_TI_BIL_HACIZ_ISTIRAKCollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }
    }
}