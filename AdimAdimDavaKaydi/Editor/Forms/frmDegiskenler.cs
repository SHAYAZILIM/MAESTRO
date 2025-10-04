using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;

namespace AvukatProEditorDegisken
{
    public partial class frmDegiskenler : DevExpress.XtraEditors.XtraForm
    {
        public frmDegiskenler()
        {
            InitializeComponent();
        }

        private AV001_TI_BIL_FOY _foy;

        private TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> _myDataSource;

        private VList<per_TI_KOD_ALACAK_NEDEN> AlacakNedenleri;

        private TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN Current;

        public enum IcraDovizIslemTipi
        {
            /// <summary>
            /// Default alan
            /// </summary>
            Vade_Tarihinde_TL = 1,

            Takip_Tarihinde_TL = 2,
            Ödeme_Tarihinde_TL = 3
        }

        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null && !DesignMode)
                {
                    bool YtlLi = false;
                    bool Dovizli = false;
                    bool Faiz = true;
                    int dovIslTip = 1;
                    bool veya = false;
                    bool ilamaFaiz = IlamiFaizliMi(value);
                    bool herAyaNafaka = value.HER_AY_NAFAKA_EKLE;
                    string AlacakKalemleri = "";
                    for (int y = 0; y < value.AV001_TI_BIL_ALACAK_NEDENCollection.Count; y++)
                    {
                        YtlLi = (value.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value == 1);
                        Dovizli = (value.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value != 1);
                        if (Faiz)
                        {
                            Faiz = value.AV001_TI_BIL_ALACAK_NEDENCollection[y].FAIZ_YOK;
                        }

                        dovIslTip = value.AV001_TI_BIL_ALACAK_NEDENCollection[y].HESAPLAMA_MODU;

                        AlacakKalemleri +=
                            value.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI + ",";

                        if (value.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 1)
                        {
                            veya = true;
                        }
                    }
                    this.gridView1.ActiveFilterString =
                        string.Format(
                            "[FORM_TIPI_ID] = {0} And [DOVIZ_ISLEM_TIPI] = '{1}' And [DOVIZLI_MI] = {2} And [YTL_MI] = {3} And [FAIZ_YOK_MU] = {4} And [ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI] = {5} And [ILAMA_FAIZ_ISLEMIS_MI] = {6} And [HER_AYA_NAFAKA_ISLEMIS_MI] = {7}",
                            value.FORM_TIP_ID, dovIslTip, Dovizli, YtlLi, Faiz, veya, ilamaFaiz, herAyaNafaka);
                    if (gridView1.RowCount <= 0)
                    {
                        TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN degisken = new TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN();
                        degisken.YTL_MI = YtlLi;
                        degisken.DOVIZLI_MI = Dovizli;
                        degisken.ILAMA_FAIZ_ISLEMIS_MI = ilamaFaiz;
                        degisken.HER_AYA_NAFAKA_ISLEMIS_MI = herAyaNafaka;
                        degisken.ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI = veya;
                        degisken.FAIZ_YOK_MU = Faiz;
                        degisken.DOVIZ_ISLEM_TIPI = dovIslTip;
                        string talepAciklama = " Döviz iþlem tipi " +
                                               (dovIslTip == 1 ? "Vade tarihinde Ytl " : "Belirtilmemiþ") +
                                               (dovIslTip == 2 ? "Takip tarihinde Ytl " : "Belirtilmemiþ") +
                                               (dovIslTip == 3 ? "Ödeme tarihinde Ytl " : "Belirtilmemiþ") + " Olup " +
                                               (YtlLi ? " Ytl li " : " Dövizli ") + " Alacak kalemleri " +
                                               AlacakKalemleri + " olan takiplerde .";
                        degisken.TALEP_ACIKLAMA = talepAciklama;
                        degisken.ACIKLAMA = " alacaðýmýzýn ";
                        this.MyDataSource = new TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN>();
                        this.MyDataSource.Add(degisken);

                        XtraMessageBox.Show(talepAciklama);
                    }
                }
            }
        }

        public TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                if (value != null)
                {
                    value.AddingNew += value_AddingNew;
                    bindingSource1.DataSource = value;
                    AvukatProLib2.Data.DataRepository.TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.DeepLoad(value, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD>));
                }
            }
        }

        public void Save()
        {
            AvukatProLib2.Data.DataRepository.TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.DeepSave(this.MyDataSource, AvukatProLib2.Data.DeepSaveType.IncludeChildren, typeof(TList<NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD>));
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            AlacakNedenleri = BelgeUtil.Inits.AlacakNedenKodGetirByFormTipId((bindingSource1.Current as TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN).FORM_TIPI_ID);
            Current = (bindingSource1.Current as TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN);

            if (AlacakNedenleri.Count == 0)
            {
                return;
            }
            rlueAlacak.DataSource = AlacakNedenleri;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            this.MyDataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.GetAll();
        }

        private void frmDegiskenler_Load(object sender, EventArgs e)
        {
            if (this.MyDataSource == null)
            {
                this.MyDataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.GetAll();
            }
            BelgeUtil.Inits.AlacakNedenKodGetir1(this.rlueAlacak);
            this.rlueFormTipi.EditValueChanged += rlueFormTipi_EditValueChanged;
            BelgeUtil.Inits.FormTipiGetir(this.rlueFormTipi);
            BelgeUtil.Inits.DovizIslemTipiGetir(rlueDislemTipi);
        }

        private bool IlamiFaizliMi(AV001_TI_BIL_FOY Foy)
        {
            for (int i = 0; i < Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++)
            {
                if (Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].BAKIYE_KARAR_HARCI_FAIZ_ISLESIN_MI ||
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_TEBLIG_GIDER_FAIZ_ISLESIN_MI ||
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_VEKALET_UCRET_FAIZ_ISLESIN_MI ||
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].INKAR_TAZMINAT_FAIZ_ISLESIN_MI ||
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].YARGILAMA_GIDERI_FAIZ_ISLESIN_MI ||
                    Foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].YARGITAY_ONAMA_HARCI_FAIZ_ISLESIN_MI)
                {
                    return true;
                }
            }
            return false;
        }

        private void rlueFormTipi_EditValueChanged(object sender, EventArgs e)
        {
            AlacakNedenleri = BelgeUtil.Inits.AlacakNedenKodGetirByFormTipId(Convert.ToInt32(((LookUpEdit)sender).EditValue));
            Current = (bindingSource1.Current as TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN);

            if (AlacakNedenleri.Count == 0)
            {
                return;
            }
            rlueAlacak.DataSource = AlacakNedenleri;
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (e.NewObject is TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN)
            {
                AlacakNedenleri = BelgeUtil.Inits.AlacakNedenKodGetirByFormTipId(((TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN)e.NewObject).FORM_TIPI_ID);
                rlueAlacak.DataSource = AlacakNedenleri;
            }
        }
    }
}