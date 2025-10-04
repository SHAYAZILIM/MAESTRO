using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvukatProLib.Hesap;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSimulasyonHesapCetveli : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSimulasyonHesapCetveli()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += ucSimulasyonHesapCetveli_Load;
        }

        private void ucSimulasyonHesapCetveli_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            InitsRepositoryItem();
            Renklendir();
        }

        private void InitsRepositoryItem()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit rSpinPara = new RepositoryItemSpinEdit();

            BelgeUtil.Inits.ParaBicimiAyarla(rSpinPara);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);

            var dovizDizisi = DovizAlanlari();
            foreach (var item in dovizDizisi)
            {
                var row = vgHesapCetveli.GetRowByFieldName(item);
                if (row != null && row is MultiEditorRow)
                {
                    var mRow = row as MultiEditorRow;
                    mRow.PropertiesCollection[item].RowEdit = rlueDoviz;
                }
            }
            var tutarDizisi = TutarAlanlari();

            foreach (var item in tutarDizisi)
            {
                var row = vgHesapCetveli.GetRowByFieldName(item);
                if (row != null && row is MultiEditorRow)
                {
                    var mRow = row as MultiEditorRow;
                    mRow.PropertiesCollection[item].RowEdit = rSpinPara;
                }
            }
        }

        private string[] DovizAlanlari()
        {
            var dizi = new[]
                           {
                               "ASIL_ALACAK_DOVIZ_ID",
                               "ISLEMIS_FAIZ_DOVIZ_ID",
                               "BSMV_TO_DOVIZ_ID",
                               "KKDV_TO_DOVIZ_ID",
                               "OIV_TO_DOVIZ_ID",
                               "KDV_TO_DOVIZ_ID",
                               "IH_VEKALET_UCRETI_DOVIZ_ID",
                               "IH_GIDERI_DOVIZ_ID",
                               "IT_HACIZDE_ODENEN_DOVIZ_ID",
                               "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID",
                               "CEK_KOMISYONU_DOVIZ_ID",
                               "ILAM_YARGILAMA_GIDERI_DOVIZ_ID",
                               "ILAM_BK_YARG_ONAMA_DOVIZ_ID",
                               "ILAM_TEBLIG_GIDERI_DOVIZ_ID",
                               "ILAM_INKAR_TAZMINATI_DOVIZ_ID",
                               "ILAM_VEK_UCR_DOVIZ_ID",
                               "KO_ILAM_TOPLAM_DOVIZ_ID",
                               "PROTESTO_GIDERI_DOVIZ_ID",
                               "IHTAR_GIDERI_DOVIZ_ID",
                               "OZEL_TAZMINAT_DOVIZ_ID",
                               "OZEL_TUTAR1_DOVIZ_ID",
                               "OZEL_TUTAR2_DOVIZ_ID",
                               "OZEL_TUTAR3_DOVIZ_ID",
                               "TAKIP_CIKISI_DOVIZ_ID",
                               "SONRAKI_FAIZ_DOVIZ_ID",
                               "SONRAKI_TAZMINAT_DOVIZ_ID",
                               "BSMV_TS_DOVIZ_ID",
                               "OIV_TS_DOVIZ_ID",
                               "KDV_TS_DOVIZ_ID",
                               "ILK_GIDERLER_DOVIZ_ID",
                               "PESIN_HARC_DOVIZ_ID",
                               "ODENEN_TAHSIL_HARCI_DOVIZ_ID",
                               "KALAN_TAHSIL_HARCI_DOVIZ_ID",
                               "MASAYA_KATILMA_HARCI_DOVIZ_ID",
                               "PAYLASMA_HARCI_DOVIZ_ID",
                               "DAVA_GIDERLERI_DOVIZ_ID",
                               "DIGER_GIDERLER_DOVIZ_ID",
                               "TAKIP_VEKALET_UCRETI_DOVIZ_ID",
                               "DAVA_INKAR_TAZMINATI_DOVIZ_ID",
                               "DAVA_VEKALET_UCRETI_DOVIZ_ID",
                               "ODEME_TOPLAMI_DOVIZ_ID",
                               "TO_ODEME_TOPLAMI_DOVIZ_ID",
                               "MAHSUP_TOPLAMI_DOVIZ_ID",
                               "FERAGAT_TOPLAMI_DOVIZ_ID",
                               "ALACAK_TOPLAMI_DOVIZ_ID",
                               "KALAN_DOVIZ_ID",
                               "TAHLIYE_VEK_UCR_DOVIZ_ID",
                               "DIGER_HARC_DOVIZ_ID",
                               "TD_GIDERI_DOVIZ_ID",
                               "TD_BAKIYE_HARC_DOVIZ_ID",
                               "TD_VEK_UCR_DOVIZ_ID",
                               "TD_TEBLIG_GIDERI_DOVIZ_ID",
                               "BIRIKMIS_NAFAKA_DOVIZ_ID",
                               "ICRA_INKAR_TAZMINATI_DOVIZ_ID",
                               "DAMGA_PULU_DOVIZ_ID",
                               "PROTOKOL_MIKTARI_DOVIZ_ID",
                               "KARSILIK_TUTARI_DOVIZ_ID",
                               "HESAPLANMIS_FAIZ_DOVIZ_ID",
                               "HESAPLANMIS_KKDF_DOVIZ_ID",
                               "HESAPLANMIS_BSMV_DOVIZ_ID",
                               "HESAPLANMIS_KDV_DOVIZ_ID",
                               "HESAPLANMIS_OIV_DOVIZ_ID",
                               "TO_MASRAF_TOPLAMI_DOVIZ_ID",
                               "TS_MASRAF_TOPLAMI_DOVIZ_ID",
                               "TUM_MASRAF_TOPLAMI_DOVIZ_ID",
                               "HARC_TOPLAMI_DOVIZ_ID",
                               "TO_VEKALET_TOPLAMI_DOVIZ_ID",
                               "TS_VEKALET_TOPLAMI_DOVIZ_ID",
                               "TUM_VEKALET_TOPLAMI_DOVIZ_ID",
                               "KARSI_VEKALET_TOPLAMI_DOVIZ_ID",
                               "FAIZ_TOPLAMI_DOVIZ_ID",
                               "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID",
                               "IT_VEKALET_UCRETI_DOVIZ_ID",
                               "IT_GIDERI_DOVIZ_ID",
                               "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID",
                               "BASVURMA_HARCI_DOVIZ_ID",
                               "VEKALET_HARCI_DOVIZ_ID",
                               "VEKALET_PULU_DOVIZ_ID",
                               "IFLAS_BASVURMA_HARCI_DOVIZ_ID",
                               "IFLASIN_ACILMASI_HARCI_DOVIZ_ID",
                               "ILK_TEBLIGAT_GIDERI_DOVIZ_ID",
                               "TAHLIYE_HARCI_DOVIZ_ID",
                               "TESLIM_HARCI_DOVIZ_ID",
                               "FERAGAT_HARCI_DOVIZ_ID",
                               "TO_YONETIMG_TAZMINATI_DOVIZ_ID",
                               "GAYRI_NAKTI_ALACAK_DOVIZ_ID",
                               "GAYRI_NAKTI_ALACAK_FAIZ_DOVIZ_ID",
                               "GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_DOVIZ_ID",
                               "GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI_DOVIZ_ID",
                               "TAKIP_CIKIS_GAYRI_NAKIT_DOVIZ_ID",
                               "GAYRI_NAKIT_KALAN_DOVIZ_ID",
                               "DEPO_VEKALET_UCRET_DOVIZ_ID",
                               "DEPO_HARCI_DOVIZ_ID",
                               "TS_MASRAF_HARC_TOPLAMI_DOVIZ_ID"
                           };

            return dizi;
        }

        private string[] TutarAlanlari()
        {
            var dizi = new[]
                           {
                               "ASIL_ALACAK",
                               "ISLEMIS_FAIZ",
                               "BSMV_TO",
                               "KKDV_TO",
                               "OIV_TO",
                               "KDV_TO",
                               "IH_VEKALET_UCRETI",
                               "IH_GIDERI",
                               "IT_HACIZDE_ODENEN",
                               "KARSILIKSIZ_CEK_TAZMINATI",
                               "CEK_KOMISYONU",
                               "ILAM_YARGILAMA_GIDERI",
                               "ILAM_BK_YARG_ONAMA",
                               "ILAM_TEBLIG_GIDERI",
                               "ILAM_INKAR_TAZMINATI",
                               "ILAM_VEK_UCR",
                               "KO_ILAM_TOPLAM",
                               "PROTESTO_GIDERI",
                               "IHTAR_GIDERI",
                               "OZEL_TAZMINAT",
                               "OZEL_TUTAR1",
                               "OZEL_TUTAR2",
                               "OZEL_TUTAR3",
                               "TAKIP_CIKISI",
                               "SONRAKI_FAIZ",
                               "SONRAKI_TAZMINAT",
                               "BSMV_TS",
                               "OIV_TS",
                               "KDV_TS",
                               "ILK_GIDERLER",
                               "PESIN_HARC",
                               "ODENEN_TAHSIL_HARCI",
                               "KALAN_TAHSIL_HARCI",
                               "MASAYA_KATILMA_HARCI",
                               "PAYLASMA_HARCI",
                               "DAVA_GIDERLERI",
                               "DIGER_GIDERLER",
                               "TAKIP_VEKALET_UCRETI",
                               "DAVA_INKAR_TAZMINATI",
                               "DAVA_VEKALET_UCRETI",
                               "ODEME_TOPLAMI",
                               "TO_ODEME_TOPLAMI",
                               "MAHSUP_TOPLAMI",
                               "FERAGAT_TOPLAMI",
                               "ALACAK_TOPLAMI",
                               "KALAN",
                               "TAHLIYE_VEK_UCR",
                               "DIGER_HARC",
                               "TD_GIDERI",
                               "TD_BAKIYE_HARC",
                               "TD_VEK_UCR",
                               "TD_TEBLIG_GIDERI",
                               "BIRIKMIS_NAFAKA",
                               "ICRA_INKAR_TAZMINATI",
                               "DAMGA_PULU",
                               "PROTOKOL_MIKTARI",
                               "KARSILIK_TUTARI",
                               "HESAPLANMIS_FAIZ",
                               "HESAPLANMIS_KKDF",
                               "HESAPLANMIS_BSMV",
                               "HESAPLANMIS_KDV",
                               "HESAPLANMIS_OIV",
                               "TO_MASRAF_TOPLAMI",
                               "TS_MASRAF_TOPLAMI",
                               "TUM_MASRAF_TOPLAMI",
                               "HARC_TOPLAMI",
                               "TO_VEKALET_TOPLAMI",
                               "TS_VEKALET_TOPLAMI",
                               "TUM_VEKALET_TOPLAMI",
                               "KARSI_VEKALET_TOPLAMI",
                               "FAIZ_TOPLAMI",
                               "ILAM_UCRETLER_TOPLAMI",
                               "IT_VEKALET_UCRETI",
                               "IT_GIDERI",
                               "TO_ODEME_MAHSUP_TOPLAMI",
                               "BASVURMA_HARCI",
                               "VEKALET_HARCI",
                               "VEKALET_PULU",
                               "IFLAS_BASVURMA_HARCI",
                               "IFLASIN_ACILMASI_HARCI",
                               "ILK_TEBLIGAT_GIDERI",
                               "TAHLIYE_HARCI",
                               "TESLIM_HARCI",
                               "FERAGAT_HARCI",
                               "TO_YONETIMG_TAZMINATI",
                               "GAYRI_NAKTI_ALACAK",
                               "GAYRI_NAKTI_ALACAK_FAIZ",
                               "GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK",
                               "GAYRI_NAKITIN_TAZMININDEN_GELEN_ASIL_ALACAK_FAIZI",
                               "TAKIP_CIKIS_GAYRI_NAKIT",
                               "GAYRI_NAKIT_KALAN",
                               "DEPO_VEKALET_UCRET",
                               "DEPO_HARCI",
                               "TS_MASRAF_HARC_TOPLAMI"
                           };
            return dizi;
        }

        [DefaultValue(null)]
        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI> MyDataSource
        {
            get
            {
                if (vgHesapCetveli.DataSource != null
                    && vgHesapCetveli.DataSource is TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI>)
                {
                    return vgHesapCetveli.DataSource as TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI>;
                }

                return null;
            }
            set
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item.Tag == null)
                        {
                            item.ColumnChanged += HesapAraclari.SimilasyonHesapCetveli.EventMethod_ColumnChanged;
                            item.ColumnChanged += item_ColumnChanged;
                        }
                        else if (item.Tag.ToString() == "Asil")
                        {
                        }
                    }
                }
                vgHesapCetveli.DataSource = value;
            }
        }

        private void item_ColumnChanged(object sender, AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIEventArgs e)
        {
            Renklendir();
        }

        private void Renklendir()
        {
            if (MyDataSource.Count > 1)
            {
                var obj1 = MyDataSource[0];
                var obj2 = MyDataSource[1];

                var fields = obj1.TableColumns;

                foreach (var field in fields)
                {
                    object deger1 = obj1[field];
                    object deger2 = obj2[field];
                    var row = vgHesapCetveli.GetRowByFieldName(field);
                    if (row != null)
                    {
                        if (deger1 != null && deger2 != null
                            && deger1.ToString() != deger2.ToString())
                        {
                            row.Appearance.BackColor = Color.Orange;
                            row.Appearance.BackColor2 = Color.White;
                        }
                        else
                        {
                            row.Appearance.BackColor = Color.White;
                        }
                    }
                }
            }
        }
    }
}