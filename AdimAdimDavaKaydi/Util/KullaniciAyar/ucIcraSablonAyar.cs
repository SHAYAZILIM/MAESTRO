using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class ucIcraSablonAyar : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIcraSablonAyar()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public AV001_TDIE_BIL_SABLON_RAPOR SeciliRapor
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return (AV001_TDIE_BIL_SABLON_RAPOR)this.bndRaporlar.Current;
            }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> DataSource
        {
            get { return (List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)this.bndRaporlar.DataSource; }
            set { this.bndRaporlar.DataSource = value; }
        }

        private void ucIcraSablonAyar_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNEdenID);
            BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rLueSozlesmeAltTipID);
            BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekID);
            BelgeUtil.Inits.YaziTipiDoldur(rLueYaziTipiEnum);
            BelgeUtil.Inits.SablonRaporGetir(rlueYazdirilacakSablon);
            this.bndRaporlar.DataSource = BelgeUtil.Inits._SablonRaporGetir;
            this.ucSablonRapor1.MyDataSource = (List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)this.bndRaporlar.DataSource;
            this.ucSablonRapor1.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            this.gridView1.FocusedRowChanged += AyargridView1_FocusedRowChanged;
        }

        private void AyargridView1_FocusedRowChanged(object sender,
                                                     DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.gridView1.GetFocusedRow() != null)
            {
                this.tDIEKODSABLONRAPORYAZDIRMAAYARKOSULCollectionBindingSource1.DataSource =
                    ((AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI)this.gridView1.GetFocusedRow()).
                        TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSULCollection;
                this.vGridSablonRaporAyar.DataSource =
                    this.tDIEKODSABLONRAPORYAZDIRMAAYARKOSULCollectionBindingSource1.DataSource;
            }
        }

        private void gridView1_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.aV001TDIEBILSABLONRAPORYAZDIRMAAYARLARICollectionGetBySABLONIDBindingSource.DataSource =
                ((AV001_TDIE_BIL_SABLON_RAPOR)ucSablonRapor1.gridView1.GetFocusedRow()).
                    AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARICollectionGetBySABLON_ID;
            this.gridControl1.DataSource =
                this.aV001TDIEBILSABLONRAPORYAZDIRMAAYARLARICollectionGetBySABLONIDBindingSource.DataSource;
        }

        public void Kaydet()
        {
            AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.DeepSave(
                (TList<AV001_TDIE_BIL_SABLON_RAPOR>)this.bndRaporlar.DataSource);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
    }
}