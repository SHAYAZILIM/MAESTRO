using AvukatProLib2.Entities;
using System;

namespace AvpNg.Editor.UserControls
{
    public partial class ucSablonYazdirmaSecim : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSablonYazdirmaSecim()
        {
            InitializeComponent();
        }

        public enum YazdirmaSayilari
        {
            Takip_Eden_Sayýsý,
            Takip_Edilen_Sayýsý,
            Sorumlu_Avukat_Sayýsý,
            Takýp_Eden_Sayýsý_ve_Sorumlu_Avukat_Sayýsý,
            Takýp_Edýlen_Sayýsý_ve_Sorumlu_Avukat_Sayýsý,
            Takýp_Eden_Sayýsý_ve_Takýp_Edýlen_Sayýsý,
            Takýp_Eden_Sayýsý_ve_Takýp_Edýlen_Sayýsý_ve_Sorumlu_Avukat_Sayýsý,
            Her_Taraf_için_ve_Bu_Taraflarýn_her_Bir_Adresi_Ýçinde_Birer_Tane,
            Sadece_Bir_Kopyasýný_Oluþtur,
            Hiçbiri
        }

        public TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> MyDataSource
        {
            get
            {
                if (gridControl1.DataSource is TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI>)
                {
                    return (TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI>)gridControl1.DataSource;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                {
                    gridControl1.DataSource = value;
                }
            }
        }

        public bool Save()
        {
            try
            {
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARIProvider.Save(
                    (TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI>)this.gridControl1.DataSource);
            }
            catch 
            {
                return false;
            }

            return true;
        }

        private void ucSablonYazdirmaSecim_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (MyDataSource == null)
            {
                this.MyDataSource = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARIProvider.GetAll();
            }

            BelgeUtil.Inits.SetLookupByEnum(rlueYazdirmaSayislari, typeof(YazdirmaSayilari));
            BelgeUtil.Inits.YaziTipiDoldur(rlueYaziTipleri);
            BelgeUtil.Inits.SablonRaporGetir(rlueSablonlar);
        }
    }
}