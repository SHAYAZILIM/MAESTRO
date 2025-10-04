using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmTemsilBilgisiEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmTemsilBilgisiEkle()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TDI_BIL_TEMSIL> MySelectedList = new TList<AV001_TDI_BIL_TEMSIL>();

        public TList<AV001_TDI_BIL_TEMSIL> MyDataSource
        {
            get { return gridControl1.DataSource as TList<AV001_TDI_BIL_TEMSIL>; }
            set { gridControl1.DataSource = value; }
        }

        public DialogResult ShowDialog(TList<AV001_TDI_BIL_TEMSIL> myDataSource)
        {
            MyDataSource = myDataSource;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        public void TemsilLoad()
        {
            try
            {
                BelgeUtil.Inits.TemsilYetkiKullanmaTipiGetir(rlkYETKI_KULLANMA_SEKLI);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rlkADLI_BIRIM_ADLIYE_ID);
                BelgeUtil.Inits.AdliBirimGorevGetirSadeceN(rlkADLI_BIRIM_GOREV_ID);
                BelgeUtil.Inits.perCariGetir(rlkEVRAK_SORUMLU_ID);
                BelgeUtil.Inits.TemsilSekliGetir(rlkTEMSIL_SEKIL_ID);
                BelgeUtil.Inits.TemsilTuruGetir(rlkTEMSIL_TUR_ID);
                BelgeUtil.Inits.perCariGetir(rlkCarii);
                BelgeUtil.Inits.TemsilTipiGetir(rlkTemsilTip);
                BelgeUtil.Inits.TemsilSonaErmeSebepGetir(rlkVSES);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
        
        private void frmTemsilBilgisiEkle_FormClosing(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Yaptýðýnýz deðiþiklikleri kaydetmek istiyormusunuz ?", "Çýkýþ",
                                                  MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.Save(MyDataSource);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void frmTemsilBilgisiEkle_Load(object sender, EventArgs e)
        {
            TemsilLoad();
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += frmTemsilBilgisiEkle_FormClosing;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MySelectedList = MyDataSource.FindAll("IsSelected", true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}