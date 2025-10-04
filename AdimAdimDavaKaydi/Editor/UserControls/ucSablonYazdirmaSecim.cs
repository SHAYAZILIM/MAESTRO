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
            Takip_Eden_Say�s�,
            Takip_Edilen_Say�s�,
            Sorumlu_Avukat_Say�s�,
            Tak�p_Eden_Say�s�_ve_Sorumlu_Avukat_Say�s�,
            Tak�p_Ed�len_Say�s�_ve_Sorumlu_Avukat_Say�s�,
            Tak�p_Eden_Say�s�_ve_Tak�p_Ed�len_Say�s�,
            Tak�p_Eden_Say�s�_ve_Tak�p_Ed�len_Say�s�_ve_Sorumlu_Avukat_Say�s�,
            Her_Taraf_i�in_ve_Bu_Taraflar�n_her_Bir_Adresi_��inde_Birer_Tane,
            Sadece_Bir_Kopyas�n�_Olu�tur,
            Hi�biri
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