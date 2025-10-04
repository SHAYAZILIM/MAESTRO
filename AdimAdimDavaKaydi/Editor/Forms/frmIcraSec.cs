using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmIcraSec : AvpXtraForm
    {
        public frmIcraSec()
        {
            InitializeComponent();
            this.EventlerKullanilacakMi = true;
            this.Button_Tamam_Click += frmIcraSec_Button_Tamam_Click;
            this.Button_Iptal_Click += frmIcraSec_Button_Iptal_Click;
        }

        public AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.Criteria kriter =
            new AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.Criteria();

        //aykut hýzlandýrma 11.02.2013
        //private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> Foyler;
        private DataTable Foyler;

        private void frmIcraSec_Button_Iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIcraSec_Button_Tamam_Click(object sender, EventArgs e)
        {
            AV001_TI_BIL_FOY myFoy =
                ((AV001_TI_BIL_FOY)((GridView)this.ucIcraFoy1.gcIcraFoy.MainView).GetFocusedRow());
            if (myFoy == null)
            {
                ucIcraFoy1.gcIcraFoy.MainView.CloseEditor();
                return;
            }

            kriter.Kriter = myFoy.ID.ToString();
            kriter.Record = myFoy;
            this.Close();
        }

        private void frmIcraSec_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            #region SUBEKONTROLLU VERI CEKME

            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                    this.ucIcraFoy1.MyDataSource = BelgeUtil.Inits.IcraDosyalariGetir();
                else
                    this.ucIcraFoy1.MyDataSource = BelgeUtil.Inits.IcraDosyalariGetirBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);

            #endregion SUBEKONTROLLU VERI CEKME

            if (Foyler == null)
            {
                Foyler = BelgeUtil.Inits.IcraDosyalariGetir();
            }

            this.ucIcraFoy1.MyDataSource = Foyler;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AV001_TI_BIL_FOY myFoy =
                ((AV001_TI_BIL_FOY)((GridView)this.ucIcraFoy1.gcIcraFoy.MainView).GetFocusedRow());
            kriter.Kriter = myFoy.ID.ToString();
            kriter.Record = myFoy;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Foyler = BelgeUtil.Inits.IcraDosyalariGetir();
        }
    }
}