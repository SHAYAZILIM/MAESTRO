using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using AvukatProLib;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    //Klasör hesabýnda Gayrinakit ve Çek yapraðýna göre bilgilerin gelmesini saðlamak için eklendi. MB
    public enum GayrinakitTip
    {
        CekYapragi,
        DigerGayrinakit
    }

    public partial class ucAlacaklar : AvpXUserControl
    {
        public GayrinakitTip GNakitTip = GayrinakitTip.DigerGayrinakit;

        //Klasör hesabýnda Gayrinakit ve çek yapraðýnda gride bilgilerin gelmesini saðlamak için eklendi.
        public bool KlasorHesabindan = false;

        private DataTable _MyDataSource;

        private AV001_TI_BIL_FOY _myFoy;

        //Klasör hesabýnda Gayrinakit ve çek yapraðýnda gride bilgilerin gelmesini saðlamak için eklendi. Sadece klasör hesabýnda AlacakNedenList.Count > 0. MB
        private TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

        private List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ> itirazListe;

        public ucAlacaklar()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucAlacaklar_Load;
        }

        //aykut hýzlandýrma 01.03.2013
        //[Browsable(false)]
        //public List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> MyDataSource
        //{
        //    get { return _MyDataSource; }
        //    set
        //    {
        //        _MyDataSource = value;
        //        if (gcAlacak != null)
        //            gcAlacak.DataSource = _MyDataSource;
        //    }
        //}
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (gcAlacak != null)
                    gcAlacak.DataSource = _MyDataSource;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;

                #region <MB-20101207>

                //Klasör hesabýnda Gayrinakit ve çek yapraðýnda gride bilgilerin gelmesini saðlamak için eklendi.
                if (value != null && KlasorHesabindan)
                {
                    AlacakNedenList.Clear();
                    var klasorAlacakListTakipli = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI(MyProje.ID);
                    switch (GNakitTip)
                    {
                        case GayrinakitTip.CekYapragi:
                            if (gwAlacak != null)
                            {
                                gwAlacak.Columns.Clear();
                                gwAlacak.Columns.AddRange(GetTabCekYapragi());
                            }

                            if (klasorAlacakListTakipli.Count > 0)
                                klasorAlacakListTakipli.ForEach(item =>
                                {
                                    if (AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) && AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenCekYapragimi(item))
                                    {
                                        if (item.REFERANS_ALACAK_NEDEN_ID.HasValue)
                                        {
                                            if (AlacakNedenList.Find(vi => vi.REFERANS_ALACAK_NEDEN_ID == item.REFERANS_ALACAK_NEDEN_ID) == null)
                                                AlacakNedenList.Add(item);
                                        }
                                        else
                                        {
                                            GayrinakitDegerleriAyarla(AlacakNedenList, item);
                                        }
                                    }
                                });
                            else
                            {
                                var klasorAlacakList = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN(MyProje.ID);

                                klasorAlacakList.ForEach(item =>
                                {
                                    if (AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) && AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenCekYapragimi(item))
                                        AlacakNedenList.Add(item);
                                });
                            }
                            break;

                        case GayrinakitTip.DigerGayrinakit:
                            if (gwAlacak != null)
                            {
                                gwAlacak.Columns.Clear();
                                gwAlacak.Columns.AddRange(GetTabGayriNakit());
                            }
                            if (klasorAlacakListTakipli.Count > 0)
                                klasorAlacakListTakipli.ForEach(item =>
                                {
                                    if (AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) && !AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenCekYapragimi(item))
                                    {
                                        if (item.REFERANS_ALACAK_NEDEN_ID.HasValue)
                                        {
                                            if (AlacakNedenList.Find(vi => vi.REFERANS_ALACAK_NEDEN_ID == item.REFERANS_ALACAK_NEDEN_ID) == null)
                                                AlacakNedenList.Add(item);
                                        }
                                        else
                                        {
                                            GayrinakitDegerleriAyarla(AlacakNedenList, item);
                                        }
                                    }
                                });
                            else
                            {
                                var klasorAlacakList = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN(MyProje.ID);
                                klasorAlacakList.ForEach(item =>
                                {
                                    if (AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) && !AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenCekYapragimi(item))
                                        AlacakNedenList.Add(item);
                                });
                            }
                            break;
                        default:
                            break;
                    }
                    if (gcAlacak != null)
                    {
                        aV001TIBILALACAKNEDENBindingSource.DataSource = AlacakNedenList;
                        aV001TIBILALACAKNEDENBindingSource.CurrencyManager.Refresh();
                        gcAlacak.DataSource = aV001TIBILALACAKNEDENBindingSource.List as TList<AV001_TI_BIL_ALACAK_NEDEN>;
                        gcAlacak.Refresh();
                    }
                }

                #endregion <MB-20101207>
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        public void DatayiDoldur()
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@ICRA_FOY_ID", MyFoy.ID);
            gcAlacak.Tag = "AV001_TI_BIL_ALACAK_NEDEN";
            MyDataSource = cn.GetDataTable("SELECT * FROM dbo.per_TAKIP_ALACAK_NEDEN(nolock) where ICRA_FOY_ID=@ICRA_FOY_ID");
        }

        public void BindData()
        {
            //MyDataSource = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList();
            DatayiDoldur();

            BelgeUtil.Inits.DovizTipGetir(rLueAlacakNedenDovizID);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizCek);
            BelgeUtil.Inits.DovizTipGetir(rlueDovizGayri);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutarGayri);
            BelgeUtil.Inits.perCariGetir(rlueDepoEden);
            BelgeUtil.Inits.perCariGetir(rlueDepoEdenGayri);
        }

        private void DataChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = (AV001_TI_BIL_ALACAK_NEDEN)sender;

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.TO_UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID, MyFoy.TAKIP_TARIHI);

                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID, MyFoy.TAKIP_TARIHI);

                gonderen.ALACAK_FAIZ_TIP_ID = (int)e.Value;
            }

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_FAIZ_TIP_ID)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID, MyFoy.TAKIP_TARIHI);
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI)
            {
                if (gonderen.TUTAR_DOVIZ_ID == 1)
                {
                    gonderen.ISLEME_KONAN_TUTAR = (decimal)e.Value;
                }
                else
                {
                    DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                    gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID, gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                }
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
            {
                gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = (int)e.Value;
                if (gonderen.TUTAR_DOVIZ_ID != 1)
                {
                    DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                    gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID, gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                    gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;
                }
                else
                {
                    gonderen.ISLEME_KONAN_TUTAR = gonderen.TUTARI;
                }
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.CEK_TAZMINATI_ORANI)
            {
                gonderen.CEK_TAZMINATI_ORANI = (double)e.Value;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.KOMISYONU_ORANI)
            {
                gonderen.KOMISYONU_ORANI = (double)e.Value;
            }
        }

        private void frmAlacak_FormClosed(object sender, FormClosedEventArgs e)
        {
            DatayiDoldur();
            //MyDataSource = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList();
        }

        private void GayrinakitDegerleriAyarla(TList<AV001_TI_BIL_ALACAK_NEDEN> list, AV001_TI_BIL_ALACAK_NEDEN item)
        {
            //Eski kayýtlarda REFERANS_ALACAK_NEDEN_ID alaný deðer almýyordu.
            TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> projeTakipsizList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(MyProje.ID);

            foreach (var takipsizAlacak in projeTakipsizList)
            {
                var aNedenTakipsiz = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(takipsizAlacak.ALACAK_NEDEN_ID);
                if (aNedenTakipsiz.DIGER_ALACAK_NEDENI == item.DIGER_ALACAK_NEDENI && aNedenTakipsiz.TUTARI == item.TUTARI)
                {
                    if (list.Find(vi => vi.DIGER_ALACAK_NEDENI == item.DIGER_ALACAK_NEDENI && vi.TUTARI == item.TUTARI) == null)
                        list.Add(aNedenTakipsiz);
                }
            }
        }

        private void gcAlacak_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button != null && e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "Form")
                {
                    frmAlacakNedenEkle frm = new frmAlacakNedenEkle();
                    frm.FormClosed += new FormClosedEventHandler(frmAlacak_FormClosed);
                    frm.Show(MyFoy, BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList());
                }
                else if (e.Button.Tag.ToString() == "Duzenle" && gwAlacak.FocusedRowHandle > -1)
                {
                    frmAlacakNedenEkle frm = new frmAlacakNedenEkle();
                    frm.FormClosed += new FormClosedEventHandler(frmAlacak_FormClosed);
                    frm.DuzenlemeMi = true;
                    frm.Show(BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList()[gwAlacak.FocusedRowHandle], MyFoy, BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList(), this);
                    //frm.Show(MyDataSource[gwAlacak.FocusedRowHandle], MyFoy, MyDataSource, this);
                }
            }
        }

        private GridColumn[] GetOrjinalAlacakNeden()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colALACAK_NEDEN_KOD_ID,
                                        this.colDIGER_ALACAK_NEDENI,
                                        this.colDUZENLENME_TARIHI,
                                        this.colVADE_TARIHI,
                                        this.colFAIZ_BASLANGIC_TARIHI,
                                        this.colTUTARI,
                                        this.colTUTAR_DOVIZ_ID,
                                        this.colISLEME_KONAN_TUTAR,
                                        this.colISLEME_KONAN_TUTAR_DOVIZ_ID,
                                        this.colHARCA_ESAS_DEGER,
                                        this.colHARCA_ESAS_DEGER_DOVIZ_ID,
                                        this.colALACAK_FAIZ_TIP_ID,
                                        this.colUYGULANACAK_FAIZ_ORANI,
                                        this.colSURE_GUN,
                                        this.colSURE_AY,
                                        this.colSURE_YIL,
                                        this.colACIKLAMA,
                                        this.colADET,
                                        this.colTEMINAT_MEKTUP_MUHATAP_CARI_ID,
                                        this.colTAZMIN_MIKTARI,
                                        this.colTAZMIN_MIKTAR_DOVIZ_ID,
                                        this.colIADE_TARIHI,
                                        this.colDEPO_TARIHI,
                                        this.colIADE_MIKTARI,
                                        this.colIADE_MIKTARI_DOVIZ_ID,
                                        this.colDEPO_MIKTARI,
                                        this.colDEPO_MIKTARI_DOVIZ_ID,
                                        this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI,
                                        this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID
                                    };
            this.colALACAK_NEDEN_KOD_ID.Caption = "Alacak Neden";
            this.colDIGER_ALACAK_NEDENI.Caption = "Diðer Alacak Nedeni";
            this.colDUZENLENME_TARIHI.Caption = "Düz. T";
            this.colVADE_TARIHI.Caption = "Vade T";
            this.colFAIZ_BASLANGIC_TARIHI.Caption = "Faiz. Baþ. T";
            this.colTUTARI.Caption = "Tutarý";
            this.colTUTAR_DOVIZ_ID.Caption = " ";
            this.colISLEME_KONAN_TUTAR.Caption = "Ýþleme Konan Tu.";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Caption = " ";
            this.colHARCA_ESAS_DEGER.Caption = "Esas Deðer";
            this.colHARCA_ESAS_DEGER_DOVIZ_ID.Caption = " ";
            this.colALACAK_FAIZ_TIP_ID.Caption = "TS Faiz Tip";
            this.colUYGULANACAK_FAIZ_ORANI.Caption = "TS Faiz Oraný";
            this.colACIKLAMA.Caption = "Açýklama";

            return dizi;
        }

        private GridColumn[] GetTabCekYapragi()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colALACAK_NEDEN_KOD_ID,
                                        this.colDUZENLENME_TARIHI,
                                        this.colADET,
                                        this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI,
                                        this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID,
                                        this.colTUTARI,
                                        this.colTUTAR_DOVIZ_ID,

                                        //this.colVADE_TARIHI,
                                        //this.colTAZMIN_MIKTARI,
                                        //this.colTAZMIN_MIKTAR_DOVIZ_ID,
                                        //this.colIADE_TARIHI,
                                        //this.colIADE_MIKTARI,
                                        //this.colIADE_MIKTARI_DOVIZ_ID,
                                        //this.colDEPO_MIKTARI,
                                        //this.colDEPO_MIKTARI_DOVIZ_ID,
                                        this.colISLEME_KONAN_TUTAR,
                                        this.colISLEME_KONAN_TUTAR_DOVIZ_ID
                                    };

            this.colALACAK_NEDEN_KOD_ID.Caption = "Gayri Nakit Tür1";
            this.colDUZENLENME_TARIHI.Caption = "Verildiði T";
            this.colADET.Caption = "Sayý";
            this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI.Caption = "Yaprak Sorumluluk";
            this.colCEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID.Caption = " ";
            this.colTUTARI.Caption = "Miktarý";
            this.colTUTAR_DOVIZ_ID.Caption = " ";

            //this.colVADE_TARIHI.Caption = "Tazmin T ";
            //this.colTAZMIN_MIKTARI.Caption = "Tazmin Mik.";
            //this.colTAZMIN_MIKTAR_DOVIZ_ID.Caption = "";
            //this.colIADE_TARIHI.Caption = "Ýade T";
            //this.colIADE_MIKTARI.Caption = "Ýade Mik.";
            //this.colIADE_MIKTARI_DOVIZ_ID.Caption = "";
            //this.colDEPO_TARIHI.Caption = "Depo T";
            //this.colDEPO_MIKTARI.Caption = "Depo Mik.";
            this.colISLEME_KONAN_TUTAR.Caption = "Bakiye";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Caption = " ";

            int i = 0;
            foreach (var item in dizi)
            {
                item.VisibleIndex = i;
                i++;
            }
            return dizi;
        }

        private GridColumn[] GetTabGayriNakit()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colALACAK_NEDEN_KOD_ID,
                                        this.colDUZENLENME_TARIHI,
                                        this.colADET,
                                        this.colTEMINAT_MEKTUP_MUHATAP_CARI_ID,
                                        this.colTUTARI,
                                        this.colTUTAR_DOVIZ_ID,

                                        //this.colVADE_TARIHI,
                                        //this.colTAZMIN_MIKTARI,
                                        //this.colTAZMIN_MIKTAR_DOVIZ_ID,
                                        //this.colIADE_TARIHI,
                                        //this.colIADE_MIKTARI,
                                        //this.colIADE_MIKTARI_DOVIZ_ID,
                                        //this.colDEPO_TARIHI,
                                        //this.colDEPO_MIKTARI,
                                        //this.colDEPO_MIKTARI_DOVIZ_ID,
                                        this.colISLEME_KONAN_TUTAR,
                                        this.colISLEME_KONAN_TUTAR_DOVIZ_ID
                                    };
            this.colALACAK_NEDEN_KOD_ID.Caption = "Gayri Nakit Türü";
            this.colDUZENLENME_TARIHI.Caption = "Verildiði T";
            this.colADET.Caption = "Sayý";
            this.colTEMINAT_MEKTUP_MUHATAP_CARI_ID.Caption = "Muhatabý";
            this.colTUTARI.Caption = "Miktarý";
            this.colTUTAR_DOVIZ_ID.Caption = " ";

            //this.colVADE_TARIHI.Caption = "Tazmin T ";
            //this.colTAZMIN_MIKTARI.Caption = "Tazmin Mik.";
            //this.colTAZMIN_MIKTAR_DOVIZ_ID.Caption = "";
            //this.colIADE_TARIHI.Caption = "Ýade T";
            //this.colIADE_MIKTARI.Caption = "Ýade Mik.";
            //this.colIADE_MIKTARI_DOVIZ_ID.Caption = "";
            //this.colDEPO_TARIHI.Caption = "Depo T";
            //this.colDEPO_MIKTARI.Caption = "Depo Mik.";
            this.colISLEME_KONAN_TUTAR.Caption = "Bakiye";
            this.colISLEME_KONAN_TUTAR_DOVIZ_ID.Caption = " ";

            return dizi;
        }

        private void GridColumnVisible(GridView gw, FormTipleri formTipi, AvukatProLib.Extras.FormKonusu? formKonusu)
        {
            try
            {
                switch (formTipi)
                {
                    case FormTipleri.Form49:
                        SetDefaultColumns(gw);
                        if (gw.Columns["HARCA_ESAS_DEGER"] != null)
                        {
                            gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                            gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        }

                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form153:
                        SetDefaultColumns(gw);
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form56:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["DUZENLENME_TARIHI"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form50:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        gw.Columns["HER_AY_TAZMINAT_EKLE"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                        break;

                    case FormTipleri.Form53:
                        if (formKonusu.HasValue)
                        {
                            SetDefaultColumns(gw);

                            if (formKonusu == FormKonusu.Form53_ISIN_YAPILMASI)
                            {
                                for (int i = 0; i < gw.Columns.Count; i++)
                                {
                                    if (gw.Columns[i].FieldName == "SURE_GUN" || gw.Columns[i].FieldName == "SURE_YIL" ||
                                        gw.Columns[i].FieldName == "SURE_AY" || gw.Columns[i].FieldName == "ACIKLAMA" ||
                                        gw.Columns[i].FieldName == "ALACAK_NEDEN_KOD_ID")
                                    {
                                        gw.Columns[i].Visible = true;
                                    }
                                    else
                                        gw.Columns[i].Visible = false;
                                }
                            }

                            else if (formKonusu == FormKonusu.Form53_IRTIFAK_HAKKI)
                            {
                                for (int i = 0; i < gw.Columns.Count; i++)
                                {
                                    if (gw.Columns[i].FieldName == "ACIKLAMA" ||
                                        gw.Columns[i].FieldName == "ALACAK_NEDEN_KOD_ID")
                                    {
                                        gw.Columns[i].Visible = true;
                                    }
                                    else
                                        gw.Columns[i].Visible = false;
                                }
                            }
                            else
                            {
                                gw.Columns["DUZENLENME_TARIHI"].Visible = false;
                                gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                                gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                                gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                                gw.Columns["TAZMINATI_ORANI"].Visible = false;
                                gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                                gw.Columns["KOMISYONU_ORANI"].Visible = false;
                                gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                                gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                                gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                                gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                                gw.Columns["KDV_TIP_ID"].Visible = false;
                                gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                            }
                        }
                        break;

                    case FormTipleri.Form54:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["DUZENLENME_TARIHI"].Visible = false;
                        gw.Columns["FAIZ_BASLANGIC_TARIHI"].Visible = false;
                        gw.Columns["HESAPLAMA_MODU"].Visible = false;
                        gw.Columns["FAIZ_YOK"].Visible = false;
                        gw.Columns["ALACAK_FAIZ_TIP_ID"].Visible = false;
                        gw.Columns["UYGULANACAK_FAIZ_ORANI"].Visible = false;
                        gw.Columns["TO_ALACAK_FAIZ_TIP_ID"].Visible = false;
                        gw.Columns["TO_UYGULANACAK_FAIZ_ORANI"].Visible = false;
                        gw.Columns["SABIT_FAIZ_UYGULA"].Visible = false;
                        gw.Columns["BIR_GUNE_AYLIK_FAIZ"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        gw.Columns["HER_AY_TAZMINAT_EKLE"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        break;

                    case FormTipleri.Form55:
                        for (int i = 0; i < gw.Columns.Count; i++)
                        {
                            if (gw.Columns[i].FieldName == "ALACAK_NEDEN_KOD_ID" ||
                                gw.Columns[i].FieldName == "VADE_TARIHI" || gw.Columns[i].FieldName == "IHTAR_TARIHI" ||
                                gw.Columns[i].FieldName == "ACIKLAMA")
                            {
                                gw.Columns[i].Visible = false;
                            }
                            else
                                gw.Columns[i].Visible = true;
                        }
                        break;

                    case FormTipleri.Form52:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["BIR_GUNE_AYLIK_FAIZ"].Visible = false;
                        gw.Columns["HER_AY_TAZMINAT_EKLE"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form163:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["BIR_GUNE_AYLIK_FAIZ"].Visible = false;
                        gw.Columns["HER_AY_TAZMINAT_EKLE"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form51:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["DUZENLENME_TARIHI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        gw.Columns["BSMV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KKDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        break;

                    case FormTipleri.Form151:
                    case FormTipleri.Form152:
                        SetDefaultColumns(gw);
                        if (gw.Columns.Contains(gw.Columns["DIGER_ALACAK_NEDENI"]))
                            gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["BIR_GUNE_AYLIK_FAIZ"].Visible = false;
                        gw.Columns["HER_AY_TAZMINAT_EKLE"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["TAZMINATI_ORANI"]))
                            gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                        break;

                    case FormTipleri.Form201:
                        SetDefaultColumns(gw);
                        gw.Columns["DIGER_ALACAK_NEDENI"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER"].Visible = false;
                        gw.Columns["HARCA_ESAS_DEGER_DOVIZ_ID"].Visible = false;
                        gw.Columns["BIR_GUNE_AYLIK_FAIZ"].Visible = false;
                        gw.Columns["TAZMINAT_TIP_ID"].Visible = false;
                        gw.Columns["TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["CEK_TAZMINATI_ORANI"].Visible = false;
                        gw.Columns["KOMISYONU_ORANI"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_GUN"]))
                            gw.Columns["SURE_GUN"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_YIL"]))
                            gw.Columns["SURE_YIL"].Visible = false;
                        if (gw.Columns.Contains(gw.Columns["SURE_AY"]))
                            gw.Columns["SURE_AY"].Visible = false;
                        gw.Columns["OIV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_HESAPLANSIN"].Visible = false;
                        gw.Columns["KDV_TIP_ID"].Visible = false;
                        gw.Columns["DAMGA_PULU_HESAPLANSIN"].Visible = false;
                        break;
                }
            }
            catch
            {
            }
        }

        private void gwAlacak_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gwAlacak.GetFocusedRow() == null)
                return;

            if (gwAlacak.GetFocusedRow() is AV001_TI_BIL_ALACAK_NEDEN)
            {
                AV001_TI_BIL_ALACAK_NEDEN alacak = gwAlacak.GetFocusedRow() as AV001_TI_BIL_ALACAK_NEDEN;
                var kirilimList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == alacak.ID).ToList();
                if (kirilimList.Count == 0)
                    kirilimList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == alacak.REFERANS_ALACAK_NEDEN_ID).ToList();

                if (GNakitTip == GayrinakitTip.CekYapragi)
                    gcCekYapragiKirilim.DataSource = kirilimList;
                else
                    gcGayrinakitKirilim.DataSource = kirilimList;
            }
            else if ((gwAlacak.GetFocusedRow() is AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN) && e.FocusedRowHandle >= 0)
            {
                AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN tkp;
                tkp = (AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN)gwAlacak.GetFocusedRow();

                itirazListe = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDEN_ITIRAZs.Where(vi => vi.ALACAK_NEDEN_ID == tkp.ID).ToList();
                if (itirazListe != null)
                    grdItirazlar.DataSource = itirazListe;
                else
                    grdItirazlar.DataSource = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ>();
            }
        }

        private void gwAlacak_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            try
            {
                AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN gelen = (AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN)gwAlacak.GetRow(e.RowHandle);
                if (gelen.AlacakNedenTaraflar == null)
                    gelen.AlacakNedenTaraflar = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDEN_TARAFs.Where(vi => vi.ICRA_ALACAK_NEDEN_ID.HasValue && vi.ICRA_ALACAK_NEDEN_ID == gelen.ID).ToList();
            }
            catch { }
        }

        private void neden_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            DataChanged(sender, e);
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcAlacak_EmbeddedNavigator_ButtonClick(sender, new NavigatorButtonClickEventArgs(e.Item.Tag as NavigatorCustomButton));
        }

        private void SetDefaultColumns(GridView gw)
        {
            //for (int i = 0; i < gw.Columns.Count; i++)
            //{
            //    gw.Columns[i].Visible = true;
            //}
        }

        private void ucAlacaklar_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            gcAlacak.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gcAlacak.ShowOnlyPredefinedDetails = true;
            tabAlacakToplamiOrjin.Controls.Add(gcAlacak);
            try
            {
                gwAlacak.FocusedRowChanged += gwAlacak_FocusedRowChanged;

                //InitsDoldur(); // Okan ARDIÇ // Buradan kaldýrýldý

                BindData();
                if (MyFoy != null)
                {
                    if (!MyFoy.FORM_TIP_ID.HasValue)
                        MyFoy.FORM_TIP_ID = (int)FormTipleri.Form49;

                    GridColumnVisible(gwAlacak, (FormTipleri)(MyFoy.FORM_TIP_ID ?? (int)FormTipleri.Form49), (FormKonusu)MyFoy.TAKIP_TALEP_ID.Value);

                    BelgeUtil.Inits.AlacakNedenKodGetir((FormTipleri)MyFoy.FORM_TIP_ID.Value, rLueAlacakNedeniID, MyFoy);
                    BelgeUtil.Inits.perCariGetir(rLueCariID);

                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ColumnChanged += neden_ColumnChanged;
                    }

                    if (KlasorHesabindan) gcAlacak.DataSource = AlacakNedenList;
                }
                IsLoaded = true;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //  TAB DEÐÝÞTÝ !
            if (e.Page != null)
            {
                if (e.Page.Name == tabNakitAlacak.Name)
                {
                    #region Nakit Alacaklar

                    List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> alNdn = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();

                    foreach (DataRow item in MyDataSource.Rows)
                    {
                        AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN xx = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID & vi.ID == (int)item["ID"]).ToList()[0];
                        if (!AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(xx))
                            alNdn.Add(xx);
                    }
                    tabNakitAlacak.Controls.Add(gcAlacak);
                    gwAlacak.Columns.Clear();
                    gwAlacak.Columns.AddRange(GetOrjinalAlacakNeden());
                    gwAlacak.RefreshEditor(true);
                    aV001TIBILALACAKNEDENBindingSource.DataSource = alNdn;
                    gcAlacak.DataSource = aV001TIBILALACAKNEDENBindingSource.List as List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>;
                    gcAlacak.Refresh();

                    #endregion Nakit Alacaklar
                }
                else if (e.Page.Name == tabGayriNakitAlacak.Name)
                {
                    #region Gayrinakit alacaklar

                    List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> alNdn = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();

                    foreach (DataRow item in MyDataSource.Rows)
                    {
                        AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN xx = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID & vi.ID == (int)item["ID"]).ToList()[0];
                        if (AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(xx)
                            && !AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenCekYapragimi(xx))
                            alNdn.Add(xx);
                    }

                    //tabGayriNakitAlacak.Controls.Add(gcAlacak);
                    splitGayrinakit.Panel1.Controls.Add(gcAlacak);
                    gcAlacak.Dock = DockStyle.Fill;

                    //Klasör hesabýnda Gayrinakit ve çek yapraðýnda gride bilgilerin gelmesini saðlamak için AlacakNedenList.Count == 0 kontrolü eklendi. Sadece klasör hesabýnda AlacakNedenList.Count > 0. MB
                    if (AlacakNedenList.Count == 0)
                    {
                        gwAlacak.Columns.Clear();
                        gwAlacak.Columns.AddRange(GetTabGayriNakit());
                        gwAlacak.RefreshEditor(true);

                        aV001TIBILALACAKNEDENBindingSource.DataSource = null;
                        aV001TIBILALACAKNEDENBindingSource.DataSource = alNdn;
                        gcAlacak.DataSource = aV001TIBILALACAKNEDENBindingSource.List as List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>;
                        gcAlacak.Refresh();
                    }

                    #endregion Gayrinakit alacaklar
                }
                else if (e.Page.Name == tabAlacakToplamiOrjin.Name)
                {
                    tabAlacakToplamiOrjin.Controls.Add(gcAlacak);
                    gwAlacak.Columns.Clear();
                    gwAlacak.Columns.AddRange(GetOrjinalAlacakNeden());
                    aV001TIBILALACAKNEDENBindingSource.DataSource = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID).ToList();
                    aV001TIBILALACAKNEDENBindingSource.CurrencyManager.Refresh();
                    gcAlacak.DataSource = aV001TIBILALACAKNEDENBindingSource.List as List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>;
                    gcAlacak.Refresh();
                }
                else if (e.Page.Name == tabCekYapragi.Name)
                {
                    List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> alNdn = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();

                    if (MyDataSource != null)
                    {
                        foreach (DataRow item in MyDataSource.Rows)
                        {
                            AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN xx = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == MyFoy.ID & vi.ID == (int)item["ID"]).ToList()[0];
                            if (HesapAraclari.Icra.AlacakNedenCekYapragimi(xx))
                                alNdn.Add(xx);
                        }

                        //tabCekYapragi.Controls.Add(gcAlacak);
                        splitCekYapragi.Panel1.Controls.Add(gcAlacak);
                        gcAlacak.Dock = DockStyle.Fill;

                        //Klasör hesabýnda Gayrinakit ve çek yapraðýnda gride bilgilerin gelmesini saðlamak için AlacakNedenList.Count == 0 kontrolü eklendi. Sadece klasör hesabýnda AlacakNedenList.Count > 0. MB
                        if (AlacakNedenList.Count == 0)
                        {
                            gwAlacak.Columns.Clear();
                            gwAlacak.Columns.AddRange(GetTabCekYapragi());
                            aV001TIBILALACAKNEDENBindingSource.DataSource = alNdn;
                            aV001TIBILALACAKNEDENBindingSource.CurrencyManager.Refresh();
                            gcAlacak.DataSource = aV001TIBILALACAKNEDENBindingSource.List as List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>;
                            gcAlacak.Refresh();
                        }
                    }
                }

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcAlacak);

                #endregion Paket Kontrolü
            }
        }

        #region <MB-20100602>

        //Ýtiraz Kaydý, düzenlemesi ve bu iþlemlerden sonra itiraz gridininyenilenmesi için eklendi.

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN tkp;
            if (gwAlacak.GetFocusedRow() == null)
                return;
            tkp = (AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN)gwAlacak.GetFocusedRow();
            itirazListe = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDEN_ITIRAZs.Where(vi => vi.ALACAK_NEDEN_ID == tkp.ID).ToList();
            if (itirazListe != null)
                grdItirazlar.DataSource = itirazListe;
            else
                grdItirazlar.DataSource = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ>();
        }

        private void grdItirazlar_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz = new AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN();
                TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazList = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                itirazList.Add(itiraz);

                rFrmItiraz frm = new rFrmItiraz();
                frm.AddNewList = itirazList;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.FormClosed += frm_FormClosed;
                frm.Show(MyFoy);
            }
            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                rFrmItiraz frm = new rFrmItiraz();
                TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazList = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz = DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.GetByID((gwItiraz.GetFocusedRow() as AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ).ID);
                itirazList.Add(itiraz);
                frm.AddNewList = itirazList;
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.FormClosed += frm_FormClosed;
                frm.Show(MyFoy);
            }
        }

        #endregion <MB-20100602>
    }
}