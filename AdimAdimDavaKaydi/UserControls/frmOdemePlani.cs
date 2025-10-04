using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Microsoft.VisualBasic;
using HesapKosulu = AvukatProLib.Hesap.HesapKosulu;

namespace AdimAdimDavaKaydi.UserControls
{
    internal struct KonuAciklama
    {
        public string _aciklama;
        public string _konu;

        public KonuAciklama(string konu, string aciklama)
        {
            _konu = konu;
            _aciklama = aciklama;
        }
    }

    public struct Tercih
    {
        public string TercihAdi
        {
            set;
            get;
        }
    }

    public partial class frmOdemePlani : AvpXtraForm
    {
        private decimal CustomAsilAlacak = 0;
        private bool hariciSimulasyon = false;
        private int kagitGenisligi = 720;

        #region Constructor

        private List<HesapKosulu> Kosul5Listesi = new List<HesapKosulu>();

        private ManuelTaahhut mt = null;

        private Dictionary<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI, List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>> odemePlanList;

        private TaahhutHelper taahhutHelper = null;

        public frmOdemePlani()
            : this(false)
        {
        }

        public frmOdemePlani(bool hariciSimulasyon)
        {
            InitializeComponent();
            this.hariciSimulasyon = hariciSimulasyon;
            bndHariciAlacakNeden.DataSource = new List<HariciAlacakNeden>();
            this.Load += frmOdemePlani_Load;
            this.FormClosing += new FormClosingEventHandler(frmOdemePlani_FormClosing);
            lueFaizSecenekleri.EditValueChanged += lueFaizSecenekleri_EditValueChanged;
            listBoxControl1.MouseClick += listBoxControl1_MouseClick;
            //gLueDosyaNo.EditValueChanged += gLueDosyaNo_EditValueChanged;

            //btnHesapla.Click += btnHesapla_Click;

            bwHesapla.WorkerSupportsCancellation = true;
            bwHesapla.DoWork += bw_DoWork;
            bwHesapla.RunWorkerCompleted += bw_RunWorkerCompleted;

            bwTahhutHesabi.WorkerSupportsCancellation = true;
            bwTahhutHesabi.DoWork += bwTahhutHesabi_DoWork;
            bwTahhutHesabi.RunWorkerCompleted += bwTahhutHesabi_RunWorkerCompleted;

            cbBakiyeHarcHesabaDahil.CheckedChanged += cbBakiyeHarcHesabaDahil_CheckStateChanged;
            gwOdemePlani.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gwOdemePlani_RowStyle);
        }

        private void bwTahhutHesabi_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is List<HesapKosulu>)
            {
                taahhutHelper = new TaahhutHelper();

                taahhutHelper.TarihDegistirildi += th_TarihDegistirildi;

                List<HesapKosulu> gelenKosulListesi = e.Argument as List<HesapKosulu>;

                AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI foy = new AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI();

                DateTime sayac = dateTaksitlerBaslasin.DateTime;//DateTime.Today;
                if (sayac == new DateTime())
                    sayac = DateTime.Today;

                Kosul5Listesi.Clear();
                Kosul5Listesi = gelenKosulListesi.Where(item => item.Sekil == HesapKosulu.KosulSekli.Sekil5).OrderBy(vi => vi.Tarih).ToList();
                Kosul5Listesi.ForEach(kosul => kosul.IslemGordu = false);
                try
                {
                    if (gelenKosulListesi.Count > 0)
                    {
                        bool kosul5Calistir = false;
                        foy = gelenKosulListesi[0].SimulasyonCetveli;
                        List<AV001_TI_BIL_ALACAK_NEDEN> alacakList = (bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>).Where(item => item.IsSelected).ToList();
                        if (ceGayriNakit.Checked && !hariciSimulasyon)
                        {
                            alacakList = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(item => item.TUTAR_DOVIZ_ID == alacakList[0].TUTAR_DOVIZ_ID).ToList();
                        }
                        
                        mt = new ManuelTaahhut(alacakList, MyFoy, foy, SecilenSimulasyonBirimi, (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString())), sayac, ManuelTaahhut.OrtalamaFaizOraniHesapla(alacakList), HesapSiraListesi, cbBakiyeHarcHesabaDahil.Checked); // Okan -- MyFoy eklendi
                        mt.KesitTarihi = SonHesapTarihi;

                        if (gelenKosulListesi[0].Sekil == HesapKosulu.KosulSekli.Sekil5)
                            mt.CurrentDay = dateTaksitlerBaslasin.DateTime;
                        if (Kosul5Listesi.Count > 0)
                        {
                            mt.AraOdemeler = Kosul5Listesi;
                        }
                        if (Kosul5Listesi.Count == gelenKosulListesi.Count || gelenKosulListesi[0].Sekil == HesapKosulu.KosulSekli.Sekil5)
                        {
                            kosul5Calistir = true;
                        }
                        foreach (HesapKosulu gelenKosul in gelenKosulListesi)
                        {
                            if (gelenKosul.Sekil == HesapKosulu.KosulSekli.Sekil1)
                            {
                                gelenKosul.FaizOrani = 0;//(double)spinFaizOrani.Value;
                                gelenKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));

                                var plan = mt.ManuelTaahutHesabiModel1(gelenKosul, MyFoy); //(gelenKosul.Foy, gelenKosul.Gun, gelenKosul.Odeme.YtlCevir(sayac), sayac, gelenKosul, gelenKosul.FaizOrani, 1);

                                MySimilasyon.BSMV_TS = gelenKosul.SimulasyonCetveli.BSMV_TS;
                                MySimilasyon.KDV_TS = gelenKosul.SimulasyonCetveli.KDV_TS;
                                MySimilasyon.OIV_TS = gelenKosul.SimulasyonCetveli.OIV_TS;
                                MySimilasyon.DIGER_GIDERLER = gelenKosul.SimulasyonCetveli.DIGER_GIDERLER;
                                //MySimilasyon.KARSILIKSIZ_CEK_TAZMINATI = gelenKosul.SimulasyonCetveli.KARSILIKSIZ_CEK_TAZMINATI;
                            }
                            else if (gelenKosul.Sekil == HesapKosulu.KosulSekli.Sekil2)
                            {
                                gelenKosul.FaizOrani = 0;// (double)spinFaizOrani.Value;
                                gelenKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));
                                var plan = mt.ManuelTaahutHesabiModel2(gelenKosul, false, MyFoy);
                            }
                            else if (gelenKosul.Sekil == HesapKosulu.KosulSekli.Sekil3)
                            {
                                gelenKosul.FaizOrani = 0;// (double)spinFaizOrani.Value;
                                gelenKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));
                                var plan = mt.ManuelTaahutHesabiModel3(gelenKosul, MyFoy);
                            }
                            else if (gelenKosul.Sekil == HesapKosulu.KosulSekli.Sekil4)
                            {
                                gelenKosul.FaizOrani = 0;// (double)spinFaizOrani.Value;
                                gelenKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));
                                var plan = mt.ManuelTaahutHesabiModel1(gelenKosul, MyFoy);
                            }
                            else if (gelenKosul.Sekil == HesapKosulu.KosulSekli.Sekil5 && kosul5Calistir)
                            {
                                gelenKosul.FaizOrani = 0;// (double)spinFaizOrani.Value;
                                gelenKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));
                                var plan = mt.ManuelTaahutHesabiModel2(gelenKosul, true, MyFoy);
                            }
                        }
                        if (mt.KesitTarihi.HasValue && !mt.SonOdemeYapildi) // Belirtilen tarihe göre bakiye henüz hesaplanmamış
                        {
                            HesapKosulu tmpKosul = new HesapKosulu();
                            tmpKosul.Sekil = HesapKosulu.KosulSekli.Sekil5;
                            tmpKosul.Odeme = new ParaVeDovizId(0, 1);
                            tmpKosul.Tarih = mt.KesitTarihi.Value;
                            tmpKosul.HesapTip = (HesapKosulu.HesapTipleri)(int.Parse(lueHesapTipi.EditValue.ToString()));
                            tmpKosul.IslemGordu = false;
                            tmpKosul.SimulasyonCetveli = MySimilasyon;
                            tmpKosul.FaizIsltimTipi = (HesapYapar.FaizIsletimTipi)Convert.ToInt32(lueFaizSecenekleri.EditValue);
                            mt.ManuelTaahutHesabiModel2(tmpKosul, true, MyFoy);
                            mt.masterChildOdemePlani.Keys.Last().ODEME = 0;
                        }
                        e.Result = mt.masterChildOdemePlani;
                    }

                    if (e.Result != null)
                        return;

                    e.Result = foy;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void bwTahhutHesabi_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foy = e.Result as AV001_TI_BIL_FOY;
                AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI plan = new AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI();
            }
            else if ((e.Result is Dictionary<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI, List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>>))
            {
                odemePlanList = (e.Result as Dictionary<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI, List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>>);
                gcOdemePlani.DataSource = (e.Result as Dictionary<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI, List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>>).Keys.ToList();

                HesapDetaylariniGuncelle(odemePlanList.Keys.ToList());

                lblSonOdemeBakiye.Visible = lblSonOdemeText.Visible = SonHesapTarihi.HasValue;
                if (SonHesapTarihi.HasValue)
                {
                    var sonOdemePlani = ((List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>)gcOdemePlani.DataSource).Last();
                    lblSonOdemeText.Text = String.Format("{0} Tarihine Göre Bakiye:", sonOdemePlani.TARIH.ToShortDateString());
                    lblSonOdemeBakiye.Text = sonOdemePlani.BAKIYE.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == sonOdemePlani.BAKIYE_DOVIZ_ID).DOVIZ_KODU));
                }

                gcOdemePlaniDetay.DataSource = mt.OdemeGrubuListesi;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView6.Columns)
                {
                    if (col.ColumnEdit == null)
                        col.ColumnEdit = this.rSpinTutar;
                    col.OptionsColumn.ReadOnly = true;
                }
            }
        }

        private void frmOdemePlani_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hariciSimulasyon || MyFoy == null) return;
            if (MyFoy.ID > 0)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            }

            #region <MB-20100609>

            //Simülasyonda faiz değiştirildiği zaman özet hesap tabında faiz değerlerinin eski haline gelmesi içine eklendi.

            foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                item.CancelChanges();
            }

            #endregion <MB-20100609>
        }

        private void gwOdemePlani_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0 || MyFoy == null) return;
            if (e.RowHandle < MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count)
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        // Okan 17.09.2010

        private void HesapDetaylariniGuncelle(List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI> planList)
        {
            if (SecilenSimulasyonBirimi == null) return;

            decimal bsmvts = MySimilasyon.BSMV_TS;
            decimal kdvts = MySimilasyon.KDV_TS;
            decimal oivts = MySimilasyon.OIV_TS;
            decimal digergdr = MySimilasyon.DIGER_GIDERLER;
            //decimal karsiliksizcektaz = MySimilasyon.KARSILIKSIZ_CEK_TAZMINATI;

            double ortFaizOrani = 0;
            if (MyFoy != null && (!hariciSimulasyon || !ceToplamlarAsilAlacak.Checked))
                MySimilasyon = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(MyFoy);

            MySimilasyon.BSMV_TS = bsmvts;
            MySimilasyon.KDV_TS = kdvts;
            MySimilasyon.OIV_TS = oivts;
            MySimilasyon.DIGER_GIDERLER = digergdr;
            //MySimilasyon.KARSILIKSIZ_CEK_TAZMINATI = karsiliksizcektaz;

            if (mt != null)
            {
                MySimilasyon.KO_ILAM_YARGILAMA_GIDERI = mt.OdemeGruplari[MahsupKategori.Vergiler].TOPLAM;
                MySimilasyon.TUM_MASRAF_TOPLAMI = mt.OdemeGruplari[MahsupKategori.Masraflar].TOPLAM;
            }
            ortFaizOrani = ManuelTaahhut.OrtalamaFaizOraniHesapla(bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>);

            //MySimilasyon.BSMV_TS = 


            if (mt != null && listBoxControl1.ItemCount > 0)
            {
                lblAsilAlacak.Text = mt.OdemeGruplari[MahsupKategori.Asil_Alacak].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblHarclar.Text = (mt.OdemeGruplari[MahsupKategori.Harclar].TOPLAM).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.MASRAFLAR_DOVIZ_ID).DOVIZ_KODU));
                lblMasraf.Text = (mt.OdemeGruplari[MahsupKategori.Masraflar].TOPLAM).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.MASRAFLAR_DOVIZ_ID).DOVIZ_KODU));
                lblFaizTutari.Text = mt.OdemeGruplari[MahsupKategori.Faizler].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.FAIZLER_DOVIZ_ID).DOVIZ_KODU));
                lblGiderVergisi.Text = mt.OdemeGruplari[MahsupKategori.Vergiler].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VERGILER_DOVIZ_ID).DOVIZ_KODU));
                lblVekaletUcreti.Text = mt.OdemeGruplari[MahsupKategori.Vekalet_Ucreti].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VEKALET_DOVIZ_ID).DOVIZ_KODU));
                lblTazminat.Text = mt.OdemeGruplari[MahsupKategori.Tazminatlar].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VEKALET_DOVIZ_ID).DOVIZ_KODU));
                //lblDigerGiderler.Text = mt.OdemeGruplari[MahsupKategori.Diger].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VEKALET_DOVIZ_ID).DOVIZ_KODU));
                lblDigerAlacaklar.Text = mt.OdemeGruplari[MahsupKategori.Diger_Asil_Alacak].TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VEKALET_DOVIZ_ID).DOVIZ_KODU));

                lblToplamTutar.Text = mt.OdemeGruplari.Sum(vi => vi.Value.TOPLAM).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));



                ortFaizOrani = mt.OdemeGruplari[MahsupKategori.Faizler].ODEME_TOPLAMI == 0 ? ortFaizOrani : Convert.ToDouble(Math.Abs(mt.OdemeGruplari.Sum(vi => vi.Value.ODEME_TOPLAMI) - mt.OdemeGruplari.Sum(vi => vi.Value.TOPLAM)) * (decimal)(ortFaizOrani) / mt.OdemeGruplari[MahsupKategori.Faizler].TOPLAM);
                lblAnaparayaOdenen.Text = mt.OdemeGruplari[MahsupKategori.Asil_Alacak].ODEME_TOPLAMI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblFaizeOdenen.Text = mt.OdemeGruplari[MahsupKategori.Faizler].ODEME_TOPLAMI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.FAIZLER_DOVIZ_ID).DOVIZ_KODU));
                lblToplamOdeme.Text = mt.OdemeGruplari.Sum(vi => vi.Value.ODEME_TOPLAMI).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.DIGER_DOVIZ_ID).DOVIZ_KODU));
                lblGiderVergisineOdenen.Text = mt.OdemeGruplari[MahsupKategori.Vergiler].ODEME_TOPLAMI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.DIGER_DOVIZ_ID).DOVIZ_KODU));
                lblHarcVeMasraflaraOdenen.Text = (mt.OdemeGruplari[MahsupKategori.Masraflar].ODEME_TOPLAMI + mt.OdemeGruplari[MahsupKategori.Harclar].ODEME_TOPLAMI).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.DIGER_DOVIZ_ID).DOVIZ_KODU));
                lblVekaletUcretineOdenen.Text = mt.OdemeGruplari[MahsupKategori.Vekalet_Ucreti].ODEME_TOPLAMI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.DIGER_DOVIZ_ID).DOVIZ_KODU));
                lblBakiye.Text = mt.OdemeGruplari.Sum(vi => vi.Value.TUTARI).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.DIGER_DOVIZ_ID).DOVIZ_KODU));
                lblOrtFaizOrani.Text = String.Format("% {0:0.00}", ortFaizOrani);
            }
            else
            {
                lblAsilAlacak.Text = SecilenSimulasyonBirimi.ASIL_ALACAK.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblHarclar.Text = (SecilenSimulasyonBirimi.HARCLAR + SecilenSimulasyonBirimi.MASRAFLAR).ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.MASRAFLAR_DOVIZ_ID).DOVIZ_KODU));
                lblFaizTutari.Text = SecilenSimulasyonBirimi.FAIZLER.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.FAIZLER_DOVIZ_ID).DOVIZ_KODU));
                lblGiderVergisi.Text = SecilenSimulasyonBirimi.VERGILER.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VERGILER_DOVIZ_ID).DOVIZ_KODU));
                lblVekaletUcreti.Text = SecilenSimulasyonBirimi.VEKALET_UCRETI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.VEKALET_DOVIZ_ID).DOVIZ_KODU));
                lblToplamTutar.Text = SecilenSimulasyonBirimi.TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));

                lblAnaparayaOdenen.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblFaizeOdenen.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblToplamOdeme.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblGiderVergisineOdenen.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblHarcVeMasraflaraOdenen.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblVekaletUcretineOdenen.Text = 0.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblBakiye.Text = SecilenSimulasyonBirimi.TOPLAM.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == SecilenSimulasyonBirimi.ASIL_ALACAK_DOVIZ_ID).DOVIZ_KODU));
                lblOrtFaizOrani.Text = String.Format("% {0:0.00}", ortFaizOrani);
            }
        }

        private void th_TarihDegistirildi(AV001_TI_BIL_FOY foy, DateTime sonTarih)
        {
            if (Kosul5Listesi.Count > 0)
            {
                foreach (HesapKosulu kosul in Kosul5Listesi)
                {
                    if (!kosul.IslemGordu)
                        if (kosul.Tarih.Year <= sonTarih.Year)
                        {
                            if (kosul.Tarih.Month <= sonTarih.Month)
                            {
                                TaahhutHelper.OdemeEkle(kosul.Odeme, foy, kosul.Tarih, kosul);
                                kosul.IslemGordu = true;
                                foy.SON_HESAP_TARIHI = sonTarih;
                            }
                        }
                }
            }
        }

        #endregion Constructor

        #region bwHesapla

        public BackgroundWorker bwHesapla = new BackgroundWorker();

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int foyID = (int)e.Argument;

            var mFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foyID);
            Hesap.Icra hy = new Hesap.Icra(mFoy);
            e.Result = mFoy;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Result is AV001_TI_BIL_FOY)
                {
                    AV001_TI_BIL_FOY foy = e.Result as AV001_TI_BIL_FOY;
                    SetMyFoy(foy, MyProje);
                }
            }
        }

        #endregion bwHesapla

        #region Properties

        private AV001_TI_BIL_FOY _myFoy;

        private AV001_TDIE_BIL_PROJE _MyProje;

        private AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI _mySimilasyon;

        private bool _resmiMi;

        private object _TaahhutEden;

        private object _TaahhutKabulEden;

        private AV001_TI_BIL_BORCLU_TAAHHUT_MASTER _taahhutMaster;

        private decimal gayriNakit = 0;

        private bool vekaletUcretiDegistir = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (!ceToplamlarAsilAlacak.Checked || !hariciSimulasyon) MySimilasyon = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(value);

                //Vekalet Ücreti Kontrol
                if (vekaletUcretiDegistir)
                    value.TAKIP_VEKALET_UCRETI = prVekaletUcreti.Tutar.Para;

                MySimilasyon.BAKIYE_HARC_HESABA_DAHIL = cbBakiyeHarcHesabaDahil.Checked;
                _myFoy.BAKIYE_HARC_TOPLAMA_EKLE = cbBakiyeHarcHesabaDahil.Checked;
                var AsilNesne = MySimilasyon.Clone() as AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI;
                AsilNesne.Tag = "Asil";
                TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI> liste = new TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI>();
                liste.Add(AsilNesne);
                liste.Add(MySimilasyon);

                if (MyProje == null)
                {
                    Inits.AlacakliTarafByFoy(MyFoy, new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] { lueTaahhutKabulEden.Properties });

                    //gcBorclular.DataSource = Inits.FoyTarafGetir(MyFoy).FindAll(vi => !vi.TAKIP_EDEN_MI); katmandan sonra

                    Inits.BorcluTarafByFoy(MyFoy, new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] { lueTaahhutEden.Properties });
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get
            {
                return _MyProje;
            }
            set
            {
                _MyProje = value;

                if (value != null)
                {
                    Inits.ProjeTarafGetir(value, new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] { lueTaahhutKabulEden.Properties, lueTaahhutEden.Properties });

                    //katmandan sonra
                    //var projeTaraflari = DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.GetByPROJE_ID(value.ID);
                    //DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(projeTaraflari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI>));
                    //gcBorclular.DataSource = projeTaraflari.FindAll(vi => !vi.CARI_IDSource.MUVEKKIL_MI);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI MySimilasyon
        {
            get
            {
                return _mySimilasyon;
            }
            set
            {
                if (value != null)
                {
                    HesapAraclari.SimilasyonHesapCetveli.SetFoyAlanlariHesapla(value);

                    //if (ceGayriNakit.Checked)
                    //{
                    if (MyFoy != null)
                    {
                        value.TUM_MASRAF_TOPLAMI += MyFoy.BASVURMA_HARCI;
                        gayriNakit = decimal.Zero;

                        //Vekalet Ücreti Kontrol
                        value.TAKIP_VEKALET_UCRETI = MyFoy.TAKIP_VEKALET_UCRETI + (MyFoy.DEPO_VEKALET_UCRETI.HasValue ? MyFoy.DEPO_VEKALET_UCRETI.Value : 0);
                        if (vekaletUcretiDegistir)
                        {
                            MyFoy.TAKIP_VEKALET_UCRETI = prVekaletUcreti.Tutar.Para;
                            value.TAKIP_VEKALET_UCRETI = MyFoy.TAKIP_VEKALET_UCRETI;
                        }

                        value.KALAN = MyFoy.KALAN + (MyFoy.BAKIYE_HARC_TOPLAMA_EKLE ? MyFoy.KALAN_TAHSIL_HARCI : decimal.Zero);

                        if (ceGayriNakit.Checked && !hariciSimulasyon)
                        {
                            foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                if ((item.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.HasValue && item.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value && !item.VADE_TARIHI.HasValue))
                                {
                                    gayriNakit += new ParaVeDovizId(item.TUTARI, item.TUTAR_DOVIZ_ID).YtlHali;
                                }
                            }
                        }
                    }

                    //vekaletUcretiDegistir = false;//Vekalet Ücreti Kontrol

                    //}

                    var masraflar = new List<ParaVeDovizId>(
                new[]
                {
                    new ParaVeDovizId(value.TS_MASRAF_TOPLAMI,value.TS_MASRAF_TOPLAMI_DOVIZ_ID),
                    new ParaVeDovizId(value.KKDV_TO,value.KKDV_TO_DOVIZ_ID),
                    new ParaVeDovizId(value.TO_MASRAF_TOPLAMI,value.TO_MASRAF_TOPLAMI_DOVIZ_ID),
                    new ParaVeDovizId(value.ODENEN_TAHSIL_HARCI,value.ODENEN_TAHSIL_HARCI_DOVIZ_ID),
                    new ParaVeDovizId(value.IH_GIDERI,value.IH_GIDERI_DOVIZ_ID),
                    new ParaVeDovizId(value.IH_VEKALET_UCRETI,value.IH_VEKALET_UCRETI_DOVIZ_ID),
                    new ParaVeDovizId(value.DEPO_HARCI, value.DEPO_HARCI_DOVIZ_ID),

                    //new ParaVeDovizId(value.BSMV_TO,value.BSMV_TO_DOVIZ_ID),
                    //new ParaVeDovizId(value.BSMV_TS,value.BSMV_TS_DOVIZ_ID)
                });
                    var masrafParaVeDoviz = ParaVeDovizId.Topla(masraflar);

                    _mySimilasyon = value;
                    prBakiyeHarc.Tutar = new ParaVeDovizId(value.KALAN_TAHSIL_HARCI, value.KALAN_TAHSIL_HARCI_DOVIZ_ID);
                    prVekaletUcreti.Tutar = new ParaVeDovizId(value.TAKIP_VEKALET_UCRETI, value.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
                    prToplamMasraf.Tutar = SecilenSimulasyonBirimi != null ? new ParaVeDovizId((SecilenSimulasyonBirimi.HARCLAR + SecilenSimulasyonBirimi.MASRAFLAR), masrafParaVeDoviz.DovizId) : masrafParaVeDoviz;
                    prToplam.Tutar = new ParaVeDovizId(value.KALAN + gayriNakit, value.KALAN_DOVIZ_ID);
                }
                _mySimilasyon = value;

                CustomAsilAlacak = value.ASIL_ALACAK; //Okan 06.10.2010
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ResmiMi
        {
            get { return _resmiMi; }
            set { _resmiMi = value; }
        }

        public SimulasyonBirimi SecilenSimulasyonBirimi
        {
            get
            {
                if (gcSimulasyonGruplari.DataSource == null) return null;
                return ((List<SimulasyonBirimi>)gcSimulasyonGruplari.DataSource).FirstOrDefault(vi => vi.Secim);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object TaahhutEden
        {
            get
            {
                return _TaahhutEden;
            }
            set
            {
                _TaahhutEden = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object TaahhutKabulEden
        {
            get
            {
                return _TaahhutKabulEden;
            }
            set
            {
                _TaahhutKabulEden = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_BORCLU_TAAHHUT_MASTER TaahhutMaster
        {
            get { return _taahhutMaster; }
            set { _taahhutMaster = value; }
        }

        #endregion Properties

        #region Events

        private void cbBakiyeHarcHesabaDahil_CheckStateChanged(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.frmSimilasyonHesapCetveli frm = new AdimAdimDavaKaydi.Forms.frmSimilasyonHesapCetveli();

            TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI> liste = new TList<AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELI>();

            var asilFoy = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(MyFoy);
            asilFoy.Tag = "Asil";
            liste.Add(asilFoy);
            liste.Add(MySimilasyon);

            frm.MyDataSource = liste;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            var dialogResult = frm.ShowDialog();

            MySimilasyon = MySimilasyon;
        }

        #endregion Events

        #region bwTahhutHesabi

        private BackgroundWorker bwTahhutHesabi = new BackgroundWorker();

        private bool hesapTiklandi = true;

        private List<HesapKosulu> kosulListesi;

        //Kaydet
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kaydet();
            XtraMessageBox.Show("Kayıt İşlemi Tamamlandı");
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.Items.Count > 0)
            {
                hesapTiklandi = true;
                wizardControl1.SelectedPage = wpOdemePlani; // Okan 16.09.2010
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listBoxControl1.SelectedItem == null)
                return;

            listBoxControl1.Items.Remove(listBoxControl1.SelectedItem);
            odemePlanList = null;
            Hesapla();
        }

        private void frmOdemePlani_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            if (this.hariciSimulasyon)
            {
                radioGroup1.Visible = false;
                panelControl4.ContentImageAlignment = ContentAlignment.MiddleCenter;
            }

            Inits.DovizTipGetir(m1_lueOdemeDovizId);
            Inits.DovizTipGetir(m2_lueOdemeDovizId);
            Inits.DovizTipGetir(m4_lueOdemeDovizId);
            Inits.DovizTipGetir(m5_lueOdemeDoviz);
            Inits.DovizTipGetir(rlueSimuDoviz);
            Inits.ParaBicimiAyarla(rSpinSimuPara);
            Inits.ParaBicimiAyarla(rSpinTutar);
            Inits.BirYilKacGGetir(lueBirYilKacGun);

            //Inits.HesapTipiGetir(lueHesapTipi);
            //Inits.HesapTipiGetir(lueTakipSonrasiHesapTipi);
            Inits.FaizIsletimSecenekleriGetir(lueFaizSecenekleri);

            //      Inits.IcraPratikAramaGetir(rlueIcraPratikArama); Okan

            HesapTipiGetir(lueHesapTipi);
            lueHesapTipi.ItemIndex = 1;

            //lueHesapTipi.EditValue = 1;

            //     Inits.CariGetir(rlueBorcluCari); Okan
            Inits.AdliBirimAdliyeGetir(rlueMudurluk);
            Inits.AdliBirimNoGetir(rlueMudurlukNo);

            //Inits.BankaGetir(rlueBankasi);
            //Inits.BankaSubeGetir(rlueSubesi);
            //Inits.KrediTipiGetir(rlueKrediTipi);
            Inits.DovizTipGetir(rLueDovizId);
            Inits.CariGetir(rLueTaraf);
            Inits.DovizTipGetir(rLueDoviz);
            Inits.ParaBicimiAyarla(rSpinPara);
            Inits.YuzdeBicimiAyarla(rSpinOran);
            Inits.AlacakNedenKodGetir(rLueAlacakNeden);
            Inits.ParaBicimiAyarla(seVekaletUcreti);
            Inits.ParaBicimiAyarla(seHarcVeMasraflar);

            Inits.perCariGetir(rlueBorclu);

            //if (MyProje != null)
            //    Inits.ProjeTarafGetir(MyProje, new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit[] { lueTaahhutKabulEden.Properties, lueTaahhutEden.Properties });


            //gLueDosyaNo.DataSource = DataRepository.ICRA_PRATIK_ARAMAProvider.GetAll().FindAll(ICRA_PRATIK_ARAMAColumn.KOD, "K");
            //gLueDosyaNo_EditValueChanged(gLueDosyaNo, new EventArgs());

            lueFaizSecenekleri.EditValue = 0;
            dateTaksitlerBaslasin.DateTime = DateTime.Today;
            AlanlariKapat();

            if (MyFoy != null)
                bndAlacakNeden.DataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(vi => !HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(vi)).ToList();

            if (MySimilasyon != null)
                HesapDetaylariniGuncelle(null);
            wpTaahhütTaraflari.AllowNext = false;

            simpleButton2.Visible = !hariciSimulasyon;
            popupContainerEdit1.Visible = !hariciSimulasyon;
            wizardControl1.SelectedPage = hariciSimulasyon ? wpAlacakNedenleri : wpTaahhütTaraflari;
        }

        private void Hesapla()
        {
            if (!bwTahhutHesabi.IsBusy)
            {
                if (listBoxControl1.Items.Count > 0)
                {
                    kosulListesi = new List<HesapKosulu>();

                    SimulasyonBirimi secilen = null;
                    for (int i = 0; i < listBoxControl1.Items.Count; i++)
                    {
                        HesapKosulu gelenKosul = listBoxControl1.Items[i] as HesapKosulu;
                        gelenKosul.FaizIsltimTipi = (HesapYapar.FaizIsletimTipi)Convert.ToInt32(lueFaizSecenekleri.EditValue);
                        try
                        {
                            MySimilasyon.BIR_YIL_KAC_GUN = short.Parse(lueBirYilKacGun.Text);
                        }
                        catch
                        {
                            if (MySimilasyon.BIR_YIL_KAC_GUN == 0)
                            {
                                MySimilasyon.BIR_YIL_KAC_GUN = 360;
                            }
                        }

                        if (gelenKosul != null)
                        {
                            secilen = (gcSimulasyonGruplari.DataSource as List<SimulasyonBirimi>).Where(vi => vi.Secim).SingleOrDefault();
                            if (secilen != null)
                            {
                                var convertSimulasyon = secilen.GetSimulasyonCetveli();
                                convertSimulasyon.BIR_YIL_KAC_GUN = MySimilasyon.BIR_YIL_KAC_GUN;
                                gelenKosul.SimulasyonCetveli = convertSimulasyon; //ucIcraHesapCetveli1.MyFoyDataSource;
                                gelenKosul.Foy = MyFoy;

                                gcOdemePlani.DataSource = gelenKosul.Foy.AV001_TI_BIL_ODEME_PLANICollection;
                            }
                            else
                            {
                                MessageBox.Show("Lütfen Para Birimine Göre Alacak Kalemi Seçiniz");
                                return;
                            }
                        }

                        kosulListesi.Add(gelenKosul);
                    }

                    if (!hariciSimulasyon && secilen != null) // Çıktı alınabilmesi için harici alacak neden gridine datasource veriliyor. Okan
                    {
                        var list = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(item => item.TUTAR_DOVIZ_ID == secilen.ASIL_ALACAK_DOVIZ_ID).ToList();
                        List<HariciAlacakNeden> hNedenList = new List<HariciAlacakNeden>();
                        foreach (var item in list)
                        {
                            hNedenList.Add(new HariciAlacakNeden(item.TUTARI, item.TUTAR_DOVIZ_ID ?? 1, item.VADE_TARIHI, item.TO_UYGULANACAK_FAIZ_ORANI));
                        }
                        gcHariciAlacaklar.DataSource = hNedenList;
                    }

                    bwTahhutHesabi.RunWorkerAsync(kosulListesi);
                }
                else HesapDetaylariniGuncelle(null);
            }
            else
                XtraMessageBox.Show("Hesaplama İşlemi Devam Ediyor");
        }

        private void listBoxControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            contextMenuStrip1.Show(listBoxControl1.PointToScreen(e.Location));
            listBoxControl1.SelectedIndex = listBoxControl1.IndexFromPoint(e.Location);
        }

        private void lueFaizSecenekleri_EditValueChanged(object sender, EventArgs e)
        {
            //string secilen = lueFaizSecenekleri.EditValue.ToString();

            //switch (secilen)
            //{
            //    case "0":
            //        ParametrelerVisible(true);
            //        break;
            //    default:
            //        ParametrelerVisible(false);
            //        break;
            //}
        }

        private void mbtnTumKosullariKaldir_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
            listBoxControl1.Refresh();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup grup = sender as RadioGroup;

            if (grup != null)
                switch (grup.Text)
                {
                    case "1":
                        PlanlamaModeli1();
                        break;

                    case "2":
                        PlanlamaModeli2();
                        break;

                    case "3":
                        PlanlamaModeli3();
                        break;

                    case "4":
                        PlanlamaModeli4();
                        break;

                    case "5":
                        PlanlamaModeli5();
                        break;
                    default:
                        break;
                }
        }

        //Koşul ekle
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.Items.Count > 0)
            {
                bool kosulEklenebilir = true;
                foreach (HesapKosulu item in listBoxControl1.Items)
                {
                    if (item.Sekil == HesapKosulu.KosulSekli.Sekil1
                        || item.Sekil == HesapKosulu.KosulSekli.Sekil3
                        || item.Sekil == HesapKosulu.KosulSekli.Sekil4)
                    {
                        kosulEklenebilir = false;
                        break;
                    }
                }
                if (rgKosullar.Text == "5" || kosulEklenebilir)
                {
                    KosuluEkle();
                }
                else
                {
                    XtraMessageBox.Show("Ara Ödeme Yapabilirsiniz 5. Tercih");
                }

                /*        if (listBoxControl1.Items[listBoxControl1.Items.Count - 1] is HesapKosulu)
                        {
                            HesapKosulu oncekiKosul = (listBoxControl1.Items[listBoxControl1.Items.Count - 1] as HesapKosulu);
                            if (oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil1
                                || oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil3
                                || oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil4)
                            {
                                if (rgKosullar.Text == "5")
                                {
                                    KosuluEkle();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Ara Ödeme Yapabilirsiniz 5. Tercih");
                                }
                            }
                            else if (oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil2
                                     || oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil5)
                            {
                                KosuluEkle();
                            }
                            else if (oncekiKosul.Sekil == HesapKosulu.KosulSekli.Sekil5)
                            {
                                if (rgKosullar.Text == "5")
                                    KosuluEkle();
                                else
                                    XtraMessageBox.Show("Ara Ödeme Yapabilirsiniz 5. Tercih");
                            }
                        }*/
            }
            else
                KosuluEkle();

            Hesapla(); // Okan 16.09.2010
        }

        //Kaydet
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        #endregion bwTahhutHesabi

        #region Methots

        public static void HesapTipiGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("MAvans");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            dt.Rows.Add(1, "Azalan (Öncelikle Ana Paradan Mahsup)");
            dt.Rows.Add(2, "BK84 (Öncelikle Faiz ve Masraflardan Mahsup)");

            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Tipi"));
        }

        private void AlanlariKapat()
        {
            /* Okan
            foreach (Control con in navBarGroupControlContainer2.Controls)
            {
                if (con is SpinEdit)
                {
                    (con as SpinEdit).Value = decimal.Zero;
                    con.Enabled = false;
                }

                if (con is LookUpEdit)
                {
                    (con as LookUpEdit).EditValue = null;
                    con.Enabled = false;
                }
                if (con is DateEdit)
                {
                    (con as DateEdit).EditValue = null;
                    con.Enabled = false;
                }
            }
             * */
        }

        private DateTime IlkOdemeTarihiHesapla(int day) // Okan
        {
            DateTime tarih = dateTaksitlerBaslasin.DateTime;
            if (day < tarih.Day)
            {
                tarih = tarih.AddMonths(1);
            }
            return tarih;
        }

        //[Obsolete("Bu Kullanılamayacak",true)]
        private void Kaydet()
        {
            AV001_TI_BIL_FOY foy = MyFoy; // ucIcraHesapCetveli1.MyFoyDataSource;
            int siraNo = DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.GetByICRA_FOY_ID(foy.ID).Count;

            if (TaahhutEden != null && TaahhutKabulEden != null)
            {
                TaahhutTaraf tTarafTaahhutEden = TaahhutEden as TaahhutTaraf;

                TaahhutTaraf tTarafTaahhutKabulEden = TaahhutKabulEden as TaahhutTaraf;

                AV001_TI_BIL_BORCLU_TAAHHUT_MASTER master = new AV001_TI_BIL_BORCLU_TAAHHUT_MASTER();

                if (foy.ID > 0)//ToDo : proje içerisinden gelinmiş ise proje id sinin yazılacağı bir alan belirlenmeli ve kayıt projeye ilişkilendirilmeli
                    master.ICRA_FOY_ID = foy.ID;
                master.TAAHHUT_SIRA_NO = siraNo + 1;
                master.TAAHHUT_EDEN_ID = tTarafTaahhutEden.CariId;
                master.TAAHHUDU_KABUL_EDEN_ID = tTarafTaahhutKabulEden.CariId;
                master.TAAHHUDU_KABUL_TARIHI = deKabulTarihi.DateTime;
                master.TAAHHUT_TARIHI = deTaahhutTarihi.DateTime;
                master.TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = deTebligTarihi.DateTime;
                master.DAVASI_VAR_MI = false;
                master.RESMI_MI = ResmiMi;
                master.GECERLI_MI = ceGecerliTaahhut.Checked;

                if (MyProje != null)
                    master.PROJE_ID = MyProje.ID;

                MySimilasyon.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection.Add(master);
                MySimilasyon.KAYIT_TARIHI = DateTime.Now;
                MySimilasyon.KONTROL_NE_ZAMAN = DateTime.Now;
                if (ceGecerliTaahhut.Checked)
                {
                    TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> eskiTaahhutler =
                        DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.GetByICRA_FOY_ID(foy.ID);

                    foreach (AV001_TI_BIL_BORCLU_TAAHHUT_MASTER tMast in eskiTaahhutler)
                    {
                        tMast.GECERLI_MI = false;
                    }

                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.Save(eskiTaahhutler);
                }

                #region Child Değerleri

                if (gcOdemePlani.DataSource is IList<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>)
                {
                    var odemeler = gcOdemePlani.DataSource as IList<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>;

                    short sira = 1;
                    foreach (var odeme in odemeler)
                    {
                        AV001_TI_BIL_BORCLU_TAAHHUT_CHILD child = new AV001_TI_BIL_BORCLU_TAAHHUT_CHILD();

                        child.SIRA_NO = sira;
                        if (foy.ID > 0) //ToDo : proje içerisinden gelinmiş ise proje id sinin yazılacağı bir alan belirlenmeli ve kayıt projeye ilişkilendirilmeli GKN
                            child.ICRA_FOY_ID = foy.ID;
                        child.DURUM_ID = 1; // ihlal yok

                        child.TAAHHUT_MIKTARI = odeme.ODEME;
                        child.TAAHHUT_MIKTARI_DOVIZ_ID = odeme.ODEME_DOVIZ_ID;

                        //child.TAAHHUTTEN_KALAN_MIKTAR = odeme.ODEME;
                        child.TAAHHUTTEN_KALAN_MIKTAR_DOVIZ_ID = odeme.ODEME_DOVIZ_ID;

                        child.ODEME_MIKTARI = 0;
                        child.ODEME_MIKTARI_DOVIZ_ID = 1;

                        child.MASTER_TAAHHUT_ID = master.ID;

                        if (odeme.TARIH.Year != 1)
                            child.TAAHHUTU_YERINE_GETIRME_TARIHI = odeme.TARIH;
                        child.ANA_PARAYA_ODENEN = odeme.ANA_PARAYA_ODENEN;
                        child.ANA_PARAYA_ODENEN_DOVIZ_ID = odeme.ANA_PARAYA_ODENEN_DOVIZ_ID;
                        child.DEVRE_FAIZI = odeme.DEVRE_FAIZI;
                        child.DEVRE_FAIZI_DOVIZ_ID = odeme.DEVRE_FAIZI_DOVIZ_ID;
                        child.DIGERLERINE_ODENEN = odeme.DIGERLERINE_ODENEN;
                        child.DIGERLERINE_ODENEN_DOVIZ_ID = odeme.DIGERLERINE_ODENEN_DOVIZ_ID;
                        child.FAIZE_ODENEN = odeme.FAIZE_ODENEN;
                        child.FAIZE_ODENEN_DOVIZ_ID = odeme.FAIZE_ODENEN_DOVIZ_ID;

                        master.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection.Add(child);

                        sira++;
                    }
                }

                #endregion Child Değerleri

                if (MyFoy.Tag != null && MyFoy.Tag is AV001_TDIE_BIL_PROJE)
                {
                    var proje = MyFoy.Tag as AV001_TDIE_BIL_PROJE;
                    master.PROJE_ID = proje.ID;
                    MySimilasyon.PROJE_ID = proje.ID;
                }

                TransactionManager trans = new TransactionManager(Kimlik.SirketBilgisi.ConStr);
                try
                {
                    //ToDo : Geçerlilik Durumu İçin Diğer kayıtlardaki geçerlilik durumunu false yapmamız gerekmektedir  GKN
                    //gkn

                    trans.BeginTransaction();
                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepSave(trans, master, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                    DataRepository.AV001_TI_BIL_FOY_SIMILASYON_HESAP_CETVELIProvider.DeepSave(trans, MySimilasyon);

                    #region Borçlu - Taahhüt Kayıt

                    //if (MyProje == null)
                    //{
                    //    var borcluList = (gcBorclular.DataSource as TList<AV001_TI_BIL_FOY_TARAF>).FindAll(vi => vi.IsSelected);
                    //    borcluList.ForEach(item =>
                    //        {
                    //            //nn kayıt üretme
                    //        });
                    //}
                    //else
                    //Proje taraflarından datasource cast edilecek.

                    #endregion Borçlu - Taahhüt Kayıt

                    trans.Commit();
                    MessageBox.Show("Kayıt Tamamlandı", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KayitYapildi = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Catch(this, ex);
                    if (trans.IsOpen)
                        trans.Rollback();
                }

                //AdimAdimDavaKaydi.IcraTakipForms.rFrmTaahhut taahhutFormu = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTaahhut();
                ////taahhutFormu.Show(master);
                ////Todo : Programın çalışması için Düzeltildi Canan ...
                //TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> masterList = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
                //masterList.Add(master);
                //taahhutFormu.MyFoy = MyFoy;
                //taahhutFormu.TaahhutChild = master.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;
                //taahhutFormu.Show(masterList);

                //
            }
            else
            {
                DialogResult dr = MessageBox.Show("Taraf bilgileri seçilmemiş.\r\nTarafların seçildiği ekrana gitmek ister misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    wizardControl1.SelectedPage = wpTaahhütTaraflari;
            }
        }

        private void KosuluEkle()
        {
            bool ilkOdeme = listBoxControl1.ItemCount == 0;
            int faizIsletimTipi = Convert.ToInt32(lueFaizSecenekleri.EditValue);

            switch (rgKosullar.Text)
            {
                case "1":
                    HesapKosulu kosul1 = new HesapKosulu();
                    kosul1.Gun = (int)m1_spinGun.Value;
                    kosul1.Odeme = new ParaVeDovizId(m1_spinOdeme.Value, (int)m1_lueOdemeDovizId.EditValue);
                    kosul1.Aciklama = string.Format("Her ayın {0}. günü {1:###,###,###,###,##0.00} {2} ödenerek bitsin", m1_spinGun.Text, m1_spinOdeme.Value, m1_lueOdemeDovizId.Text);
                    kosul1.Sekil = HesapKosulu.KosulSekli.Sekil1;
                    kosul1.AydaBir = 1;
                    listBoxControl1.Items.Add(kosul1);
                    if (ilkOdeme && hariciSimulasyon) HariciAlacakNeden.ILK_ODEME_TARIHI = IlkOdemeTarihiHesapla((int)m1_spinGun.Value);
                    m1_spinOdeme.Value = m2_spinGun.Value = 0;
                    break;

                case "2":
                    HesapKosulu kosul2 = new HesapKosulu();
                    kosul2.Aciklama = string.Format("Her ayın {0}. günü, {1} ay süreyle {2:###,###,###,###,##0.00} {3} ödesin.", m2_spinGun.Text, m2_spinAy.Text, m2_spinOdeme.Value, m2_lueOdemeDovizId.Text);
                    kosul2.Ay = (int)m2_spinAy.Value;
                    kosul2.Gun = (int)m2_spinGun.Value;
                    kosul2.Odeme = new ParaVeDovizId(m2_spinOdeme.Value, (int)m2_lueOdemeDovizId.EditValue);
                    kosul2.Sekil = HesapKosulu.KosulSekli.Sekil2;
                    listBoxControl1.Items.Add(kosul2);
                    kosul2.AydaBir = 1;
                    if (ilkOdeme && hariciSimulasyon) HariciAlacakNeden.ILK_ODEME_TARIHI = IlkOdemeTarihiHesapla((int)m2_spinGun.Value);
                    m2_spinGun.Value = m2_spinAy.Value = m2_spinOdeme.Value = 0;
                    break;

                case "3":
                    HesapKosulu kosul3 = new HesapKosulu();
                    kosul3.Aciklama = string.Format("Her ayın {0}. günü ödensin, {1} ayda bitsin.", m3_spinGun.Text, m3_spinAy.Text);
                    kosul3.Sekil = HesapKosulu.KosulSekli.Sekil3;
                    kosul3.Gun = (int)m3_spinGun.Value;
                    kosul3.Ay = (int)m3_spinAy.Value;
                    listBoxControl1.Items.Add(kosul3);
                    kosul3.AydaBir = 1;
                    if (ilkOdeme && hariciSimulasyon) HariciAlacakNeden.ILK_ODEME_TARIHI = IlkOdemeTarihiHesapla((int)m3_spinGun.Value);
                    m3_spinGun.Value = m3_spinAy.Value = 0;
                    break;

                case "4":
                    HesapKosulu kosul4 = new HesapKosulu();
                    kosul4.Aciklama = string.Format("{0} ayda bir, ayın {1}. günü {2:###,###,###,###,##0.00} {3} ödenerek bitsin.", m4_spinAy.Text, m4_spinGun.Text, m4_spinOdeme.Value, m4_lueOdemeDovizId.Text);
                    kosul4.Sekil = HesapKosulu.KosulSekli.Sekil4;
                    kosul4.AydaBir = (int)m4_spinAy.Value;
                    kosul4.Gun = (int)m4_spinGun.Value;
                    kosul4.Odeme = new ParaVeDovizId(m4_spinOdeme.Value, (int)m4_lueOdemeDovizId.EditValue);
                    listBoxControl1.Items.Add(kosul4);
                    if (ilkOdeme && hariciSimulasyon) HariciAlacakNeden.ILK_ODEME_TARIHI = IlkOdemeTarihiHesapla((int)m1_spinGun.Value);
                    m4_spinGun.Value = m4_spinAy.Value = m4_spinOdeme.Value = 0;
                    break;

                case "5":
                    HesapKosulu kosul5 = new HesapKosulu();
                    kosul5.Aciklama = string.Format("{0} tarihinde, {1:###,###,###,###,##0.00} {2} ödensin.", m5_deTarih.Text, m5_spinOdeme.Value, m5_lueOdemeDoviz.Text);
                    kosul5.Sekil = HesapKosulu.KosulSekli.Sekil5;
                    kosul5.Tarih = m5_deTarih.DateTime.Date;
                    kosul5.Odeme = new ParaVeDovizId(m5_spinOdeme.Value, (int)m5_lueOdemeDoviz.EditValue);
                    kosul5.IslemGordu = false;
                    listBoxControl1.Items.Add(kosul5);
                    if (ilkOdeme) HariciAlacakNeden.ILK_ODEME_TARIHI = dateTaksitlerBaslasin.DateTime = m5_deTarih.DateTime;
                    if (hariciSimulasyon)
                    {
                        var neden = (bndHariciAlacakNeden.DataSource as List<HariciAlacakNeden>).Min(vi => vi.TEMERRUT_TARIHI);
                        if (neden.HasValue && HariciAlacakNeden.ILK_ODEME_TARIHI.HasValue && HariciAlacakNeden.ILK_ODEME_TARIHI > neden.Value)
                            HariciAlacakNeden.ILK_ODEME_TARIHI = dateTaksitlerBaslasin.DateTime = (neden.Value);
                    }
                    m5_spinOdeme.Value = 0;
                    m5_deTarih.EditValue = null;
                    break;
                default:
                    break;
            }
            if ((HesapYapar.FaizIsletimTipi)faizIsletimTipi != HesapYapar.FaizIsletimTipi.Faiz_basit_usulde_hesaplansin)
            {
                var aNedenTemerrutTarihi = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Min(vi => vi.VADE_TARIHI).Value;
                List<DateTime> bankaDonemleri = null;
                bankaDonemleri = ManuelTaahhut.BankaDonemleri(aNedenTemerrutTarihi.AddMonths(13), aNedenTemerrutTarihi, (HesapYapar.FaizIsletimTipi)faizIsletimTipi);

                if (HariciAlacakNeden.ILK_ODEME_TARIHI.HasValue && bankaDonemleri != null && bankaDonemleri.Count > 0 && bankaDonemleri[0] < HariciAlacakNeden.ILK_ODEME_TARIHI)
                    HariciAlacakNeden.ILK_ODEME_TARIHI = bankaDonemleri[0];
            }
            RefreshKosulListesi();
            if (ilkOdeme) HariciAlacakNedenleriniGrupla();
            rgKosullar.SelectedIndex = -1;
            AlanlariKapat();
        }

        private void PlanlamaModeli1()
        {
            AlanlariKapat();

            m1_lueOdemeDovizId.Enabled = true;
            m1_spinGun.Enabled = true;
            m1_spinOdeme.Enabled = true;

            m1_lueOdemeDovizId.EditValue = 1;
            m1_spinGun.EditValue = 1;
        }

        private void PlanlamaModeli2()
        {
            AlanlariKapat();

            m2_lueOdemeDovizId.Enabled = true;
            m2_spinAy.Enabled = true;
            m2_spinGun.Enabled = true;
            m2_spinOdeme.Enabled = true;

            m2_lueOdemeDovizId.EditValue = 1;
            m2_spinAy.EditValue = 1;
            m2_spinGun.EditValue = 1;
        }

        private void PlanlamaModeli3()
        {
            AlanlariKapat();

            m3_spinAy.Enabled = true;
            m3_spinGun.Enabled = true;

            m3_spinAy.EditValue = 1;
            m3_spinGun.EditValue = 1;
        }

        private void PlanlamaModeli4()
        {
            AlanlariKapat();

            m4_lueOdemeDovizId.Enabled = true;
            m4_spinAy.Enabled = true;
            m4_spinGun.Enabled = true;
            m4_spinOdeme.Enabled = true;

            m4_lueOdemeDovizId.EditValue = 1;
            m4_spinGun.EditValue = 1;
            m4_spinAy.EditValue = 1;
        }

        private void PlanlamaModeli5()
        {
            AlanlariKapat();

            m5_deTarih.Enabled = true;
            m5_lueOdemeDoviz.Enabled = true;
            m5_spinOdeme.Enabled = true;

            m5_lueOdemeDoviz.EditValue = 1;
            m5_deTarih.DateTime = DateTime.Now;
        }

        private void RefreshKosulListesi()
        {
            List<HesapKosulu> kosulList = new List<HesapKosulu>();
            List<int> indexList = new List<int>();
            for (int i = listBoxControl1.Items.Count - 1; i >= 0; i--)
            {
                HesapKosulu tmpKosul = (HesapKosulu)listBoxControl1.Items[i];
                if (tmpKosul.Sekil == HesapKosulu.KosulSekli.Sekil5)
                {
                    kosulList.Add(tmpKosul);
                    indexList.Add(i);
                    listBoxControl1.Items.RemoveAt(i);
                }
            }
            indexList.Sort();
            kosulList = kosulList.OrderBy(vi => vi.Tarih).ToList();
            indexList.ForEach(index =>
                {
                    listBoxControl1.Items.Insert(index, kosulList.First());
                    kosulList.RemoveAt(0);
                });
        }

        private void SetMyFoy(AV001_TI_BIL_FOY foy)
        {
            if (foy == null)
                return;

            lueBirYilKacGun.Text = foy.BIR_YIL_KAC_GUN.ToString();
            lueBirYilKacGun.SelectedText = foy.BIR_YIL_KAC_GUN.ToString();
            lueBirYilKacGun.EditValue = foy.BIR_YIL_KAC_GUN;
            lueBirYilKacGun.ClosePopup();
            lueHesapTipi.EditValue = foy.TO_HESAP_TIP_ID;

            dateSonHesapTarihi.EditValue = foy.SON_HESAP_TARIHI.HasValue ? foy.SON_HESAP_TARIHI.Value : DateTime.Now;

            deTaahhutTarihi.DateTime = DateTime.Now;
            deTebligTarihi.DateTime = DateTime.Now;
            deKabulTarihi.DateTime = DateTime.Now;

            MyFoy = foy;

            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            bndAlacakNeden.DataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Where(vi => !HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(vi)).ToList();
            if (!hariciSimulasyon) SeciliAlacakNedenleriGrupla();
        }

        private void SetMyFoy(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE proje)
        {
            MyProje = proje;

            SetMyFoy(foy);
        }

        #region <MB-20100611>

        //Yeni Taahhüt Kaydından sonra gridin yenilenmesi için eklendi.

        public bool KayitYapildi = false;

        #endregion <MB-20100611>

        #endregion Methots

        #region Show & ShowDialog

        public void Show(List<AvukatProLib.Arama.per_ICRA_HIZLI_ARAMA> foyListesi)
        {
            Show(KlasoreTaahhut.IcraFoyleriniTopla(foyListesi));
        }

        public void Show(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyListesi)
        {
            Show(KlasoreTaahhut.IcraFoyleriniTopla(foyListesi));
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            // this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            SetMyFoy(foy);

            //MyFoy = foy;
            gcAlacakNedenleri.RefreshDataSource();

            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foy, AV001_TDIE_BIL_PROJE proje)
        {
            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            SetMyFoy(foy, proje);

            //MyFoy = foy;
            gcAlacakNedenleri.RefreshDataSource();

            this.Show();
        }

        public void Show(int foyId, string foy_No)
        {
            bwHesapla.RunWorkerAsync(foyId);

            //List<ICRA_PRATIK_ARAMA> tumu = new List<ICRA_PRATIK_ARAMA>();
            ICRA_PRATIK_ARAMAQuery icp = new ICRA_PRATIK_ARAMAQuery();
            icp.Append(ICRA_PRATIK_ARAMAColumn.FOY_NO, foy_No);
            var arama = DataRepository.ICRA_PRATIK_ARAMAProvider.Find(icp);

            //tumu.Add(arama);
            //    vGridControl1.DataSource = arama; //Okan
            //gLueDosyaNo_EditValueChanged(this, new EventArgs());

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(int foyId, R_BIRLESIK_TAKIPLER_TUMU_TEXT takip)
        {
            this.Show();
            bwHesapla.RunWorkerAsync(foyId);

            List<ICRA_PRATIK_ARAMA> tumu = new List<ICRA_PRATIK_ARAMA>();
            ICRA_PRATIK_ARAMA arama = DataRepository.ICRA_PRATIK_ARAMAProvider.GetAll().Find(ICRA_PRATIK_ARAMAColumn.FOY_NO, takip.Dosya_No);

            tumu.Add(arama);

            //    vGridControl1.DataSource = tumu; // Okan
            //gLueDosyaNo_EditValueChanged(this, new EventArgs());
        }

        #endregion Show & ShowDialog

        public System.Collections.Generic.List<AV001_TI_KOD_HESAP_TIP_SIRA> HesapSiraListesi { get; set; }

        private DateTime? SonHesapTarihi { get; set; }

        private void AsilAlacakAyarla()
        {
            if (ceToplamlarAsilAlacak.Checked)
            {
                MySimilasyon.ALACAK_TOPLAMI = MySimilasyon.ASIL_ALACAK = MySimilasyon.KALAN + gayriNakit;
                MySimilasyon.TUM_MASRAF_TOPLAMI = decimal.Zero;
                MySimilasyon.FAIZ_TOPLAMI = MySimilasyon.ISLEMIS_FAIZ = decimal.Zero;
            }
            else
            {
                MySimilasyon = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(MyFoy);
            }
            if (hariciSimulasyon) HariciAlacakNedenleriniGrupla();
            else SeciliAlacakNedenleriGrupla();
            HesapDetaylariniGuncelle(odemePlanList != null ? odemePlanList.Keys.ToList() : null);
        }

        private void bEditTOFaizOrani_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (bndAlacakNeden.DataSource != null
                && bEditTOFaizOrani.EditValue != null)
            {
                List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>;
                for (int i = 0; i < alacaklar.Count; i++)
                {
                    if (alacaklar[i].IsSelected)
                        alacaklar[i].TO_UYGULANACAK_FAIZ_ORANI = Convert.ToDouble(bEditTOFaizOrani.EditValue);
                }
            }
        }

        private void bndAlacakNeden_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bndAlacakNeden.Current != null)
            {
                (bndAlacakNeden.Current as AV001_TI_BIL_ALACAK_NEDEN).UYGULANACAK_FAIZ_ORANI = (bndAlacakNeden.Current as AV001_TI_BIL_ALACAK_NEDEN).TO_UYGULANACAK_FAIZ_ORANI;
            }
        }

        private void bndHariciAlacakNeden_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new HariciAlacakNeden(decimal.Zero, 1, DateTime.Today, 0);
        }

        private void btnHesapSira_Click(object sender, EventArgs e)
        {
            if (mt != null) HesapSiraListesi = mt.HesapSiralamaTumu;
            else if (HesapSiraListesi == null) HesapSiraListesi = DataRepository.AV001_TI_KOD_HESAP_TIP_SIRAProvider.GetAll().ToList();
            AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira frm =
                    new AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira(Convert.ToInt32(lueHesapTipi.EditValue), true, HesapSiraListesi);
            frm.StartPosition = FormStartPosition.CenterScreen;

            //  frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            if (frm.KayitBasarili == DialogResult.OK)
                HesapSiraListesi = frm.HesapSiraListesi;
        }

        private void cbVekaletOtomatikHesapla_CheckedChanged(object sender, EventArgs e)
        {
            if (vekaletUcretiDegistir)
                prVekaletUcreti.ReadOnlyTutar = cbVekaletOtomatikHesapla.Checked;
            vekaletUcretiDegistir = true;
        }

        private void cEditTumAlacaklariSec_CheckedChanged(object sender, EventArgs e)
        {
            if (bndAlacakNeden.DataSource != null)
            {
                List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>;

                for (int i = 0; i < alacaklar.Count; i++)
                {
                    alacaklar[i].IsSelected = cEditTumAlacaklariSec.Checked;
                }
            }
            if (cEditTumAlacaklariSec.Checked)
                cEditTumAlacaklariSec.Text = "Tüm Seçimleri Kaldır";
            else
                cEditTumAlacaklariSec.Text = "Tüm Alacak Nedenlerini Seç";

            bndAlacakNeden.CurrencyManager.Refresh();
            bndAlacakNeden.ResetBindings(false); // Okan - BindingSource refresh
            gcAlacakNedenleri.Refresh();
        }

        private void ceToplamlarAsilAlacak_CheckedChanged(object sender, EventArgs e)
        {
            AsilAlacakAyarla();
        }

        private void chKesitTarihiKullan_CheckedChanged(object sender, EventArgs e)
        {
            dateSimulasyonHesapTarihi.Enabled = chKesitTarihiKullan.Checked;
            if (!chKesitTarihiKullan.Checked) SonHesapTarihi = null;
        }

        private void dateSonHesapTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dateSimulasyonHesapTarihi.Enabled) SonHesapTarihi = dateSimulasyonHesapTarihi.DateTime;
            else SonHesapTarihi = null;
        }

        private void dateTaksitlerBaslasin_EditValueChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.Items.Count == 0 || ((HesapKosulu)listBoxControl1.Items[0]).Sekil == HesapKosulu.KosulSekli.Sekil5) HariciAlacakNeden.ILK_ODEME_TARIHI = dateTaksitlerBaslasin.DateTime;
            else

                //HariciAlacakNeden.ILK_ODEME_TARIHI = IlkOdemeTarihiHesapla(((HesapKosulu)listBoxControl1.Items[0]).Gun);
                HariciAlacakNeden.ILK_ODEME_TARIHI = dateTaksitlerBaslasin.DateTime;

            HariciAlacakNedenleriniGrupla();
        }

        private void ExportIt(int ciktiTipi)
        {
            PrintingSystem prts = new PrintingSystem();
            prts.ContinuousPageNumbering = true;

            Font kalinKonuFontu = new Font("Tahoma", 8.25f, FontStyle.Bold);

            #region Tercihler

            List<Tercih> tercihler = new List<Tercih>();
            Tercih tmpTercih;
            foreach (HesapKosulu tmp in listBoxControl1.Items)
            {
                tmpTercih = new Tercih();
                tmpTercih.TercihAdi = tmp.Aciklama;
                tercihler.Add(tmpTercih);
            }

            GridControl yapilanTercihler = new GridControl();
            BandedGridView anaview = new BandedGridView(yapilanTercihler);
            yapilanTercihler.MainView = anaview;
            GridBand baslik = new GridBand();
            baslik.Caption = "Yapılan Tercihler";
            BandedGridColumn kolon1 = new BandedGridColumn();
            kolon1.FieldName = "TercihAdi";
            kolon1.Caption = "Tercih Adı";
            kolon1.Name = "kolon1";
            kolon1.OptionsColumn.ShowCaption = true;

            baslik.OptionsBand.ShowCaption = true;
            baslik.Columns.Add(kolon1);
            baslik.AppearanceHeader.Options.UseTextOptions = true;
            baslik.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            baslik.Name = "baslik";
            anaview.Bands.Add(baslik);

            anaview.OptionsView.ShowBands = true;
            anaview.OptionsView.ShowColumnHeaders = true;
            anaview.OptionsPrint.PrintBandHeader = true;

            yapilanTercihler.MainView = anaview;
            yapilanTercihler.DataSource = tercihler;

            this.Controls.Add(yapilanTercihler);

            #endregion Tercihler

            #region GenelAciklamaKonu

            List<KonuAciklama> aciklamalar = new List<KonuAciklama>();
            if (!this.hariciSimulasyon)
            {
                if (MyFoy != null)
                {
                    var adliyeBilgileri = BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.SingleOrDefault(vi => vi.ID == MyFoy.ID);
                    if (adliyeBilgileri != null)
                    {
                        aciklamalar.Add(new KonuAciklama("İcra Müdürlüğü", adliyeBilgileri.ADLI_BIRIM_ADLIYE + " / " + adliyeBilgileri.ADLI_BIRIM_NO + " / " + adliyeBilgileri.BOLUM));
                        aciklamalar.Add(new KonuAciklama("Esas No", MyFoy.ESAS_NO));
                        aciklamalar.Add(new KonuAciklama("Takip Tarihi", MyFoy.TAKIP_TARIHI.Value.ToShortDateString()));
                    }
                }
                aciklamalar.Add(new KonuAciklama("Taahhüdü Kabul Eden Alacaklı", lueTaahhutKabulEden.Text));
                aciklamalar.Add(new KonuAciklama("Taahhüt Eden Borçlu", lueTaahhutEden.Text));
                aciklamalar.Add(new KonuAciklama("Taahhüt Tarihi", deTaahhutTarihi.DateTime.ToShortDateString()));
                aciklamalar.Add(new KonuAciklama("Tebliğ Tarihi", deTebligTarihi.DateTime.ToShortDateString()));
                aciklamalar.Add(new KonuAciklama("Kabul Tarihi", deKabulTarihi.DateTime.ToShortDateString()));
            }
            aciklamalar.Add(new KonuAciklama("Faiz İşletim Seçeneği", lueFaizSecenekleri.Text));
            aciklamalar.Add(new KonuAciklama("Kesit Tarihi", dateSimulasyonHesapTarihi.DateTime.ToShortDateString()));
            GridControl aciklamaGrid = new GridControl();
            BandedGridView anaviewAciklama = new BandedGridView(aciklamaGrid);
            aciklamaGrid.MainView = anaviewAciklama;
            GridBand baslik2 = new GridBand();
            baslik2.Caption = "Genel Bilgiler";
            BandedGridColumn kolon3 = new BandedGridColumn();
            kolon3.AppearanceCell.Font = kalinKonuFontu;
            kolon3.FieldName = "Konu";
            kolon3.Caption = "Konu";

            BandedGridColumn kolon4 = new BandedGridColumn();
            kolon4.FieldName = "Aciklama";
            kolon4.Caption = "Açıklama";

            baslik2.Columns.Add(kolon3);
            baslik2.Columns.Add(kolon4);
            baslik2.AppearanceHeader.Options.UseTextOptions = true;
            baslik2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            baslik2.Name = "baslik2";
            anaviewAciklama.Bands.Add(baslik2);
            anaviewAciklama.OptionsView.ShowColumnHeaders = true;
            anaviewAciklama.OptionsView.ShowBands = true;
            anaviewAciklama.OptionsPrint.PrintBandHeader = true;
            aciklamaGrid.MainView = anaviewAciklama;
            aciklamaGrid.DataSource = aciklamalar;

            this.Controls.Add(aciklamaGrid);

            #endregion GenelAciklamaKonu

            #region Temerrütler

            //List<KonuAciklama> temerrutler = new List<KonuAciklama>();

            //temerrutler.Add(new KonuAciklama("Faiz İşletim Seçeneği", lueFaizSecenekleri.Text));
            //temerrutler.Add(new KonuAciklama("Kesit Tarihi", dateSonHesapTarihi.DateTime.ToShortDateString()));
            //GridControl temerrutGrid = new GridControl();
            //BandedGridView anaviewTemerrut = new BandedGridView(temerrutGrid);

            //GridBand baslikT1 = new GridBand();
            //baslikT1.Caption = "Alacak Nedenlerine Göre Temerrüt Tarihleri";
            //BandedGridColumn kolonT1 = new BandedGridColumn();
            //kolonT1.FieldName = "TEMERRUT_TARIHI";
            //kolonT1.Caption = "Temerrüt Tarihi";
            //BandedGridColumn kolonT2 = new BandedGridColumn();
            //kolonT2.FieldName = "BSMV";
            //kolonT2.Caption = "BSMV";
            //BandedGridColumn kolonT3 = new BandedGridColumn();
            //kolonT3.FieldName = "TUTARI";
            //kolonT3.Caption = "Tutarı";

            //baslikT1.Columns.Add(kolonT1);
            //baslikT1.Columns.Add(kolonT2);
            //baslikT1.Columns.Add(kolonT2);
            //baslikT1.AppearanceHeader.Options.UseTextOptions = true;
            //baslikT1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //baslikT1.Name = "baslikT1";
            //anaviewTemerrut.Bands.Add(baslik2);
            //anaviewTemerrut.OptionsView.ShowColumnHeaders = true;
            //anaviewTemerrut.OptionsView.ShowBands = true;
            //anaviewTemerrut.OptionsPrint.PrintBandHeader = true;
            //temerrutGrid.MainView = anaviewTemerrut;
            //temerrutGrid.DataSource = temerrutler;

            //this.Controls.Add(g);

            #endregion Temerrütler

            #region Hesap Detayları 1

            List<KonuAciklama> hesaplar = new List<KonuAciklama>();
            hesaplar.Add(new KonuAciklama("Asıl Alacak", lblAsilAlacak.Text));
            hesaplar.Add(new KonuAciklama("Yapılacak Son Ödeme Tarihine Göre Hesaplama", lblFaizTutari.Text));
            hesaplar.Add(new KonuAciklama("Gider Vergisi", lblGiderVergisi.Text));
            hesaplar.Add(new KonuAciklama("Harç ve Masraflar", lblHarclar.Text));
            hesaplar.Add(new KonuAciklama("Vekalet Ücreti", lblVekaletUcreti.Text));
            hesaplar.Add(new KonuAciklama(String.Empty, String.Empty));
            hesaplar.Add(new KonuAciklama("Toplam Tutar", lblToplamTutar.Text));

            GridControl hesaplar1Grid = new GridControl();
            BandedGridView hesaplarView = new BandedGridView(hesaplar1Grid);
            hesaplar1Grid.MainView = hesaplarView;
            GridBand baslik3 = new GridBand();
            baslik3.Caption = "Hesap Detayları";
            BandedGridColumn kolon5 = new BandedGridColumn();
            kolon5.AppearanceCell.Options.UseTextOptions = true;
            kolon5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            kolon5.FieldName = "Konu";
            kolon5.AppearanceCell.Font = kalinKonuFontu;
            kolon5.Caption = "Hesap Detayları";
            kolon5.Name = "kolon5";

            BandedGridColumn kolon6 = new BandedGridColumn();
            kolon6.AppearanceCell.Options.UseTextOptions = true;
            kolon6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            kolon6.FieldName = "Aciklama";
            kolon6.Caption = "Miktar";
            kolon6.Name = "kolon6";

            baslik3.Columns.Add(kolon5);
            baslik3.Columns.Add(kolon6);
            baslik3.AppearanceHeader.Options.UseTextOptions = true;
            baslik3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            baslik3.Name = "baslik3";
            hesaplarView.Bands.Add(baslik3);
            hesaplarView.OptionsView.ShowBands = true;
            hesaplarView.OptionsView.ShowColumnHeaders = true;
            hesaplarView.OptionsPrint.PrintBandHeader = true;
            hesaplar1Grid.MainView = hesaplarView;
            hesaplar1Grid.DataSource = hesaplar;

            this.Controls.Add(hesaplar1Grid);

            #endregion Hesap Detayları 1

            #region Hesap Detayları 2

            List<KonuAciklama> hesaplar2 = new List<KonuAciklama>();
            hesaplar2.Add(new KonuAciklama("Anaparaya Ödenen", lblAnaparayaOdenen.Text));
            hesaplar2.Add(new KonuAciklama("Faize Ödenen", lblFaizeOdenen.Text));
            hesaplar2.Add(new KonuAciklama("Gider Vergisine Ödenen", lblGiderVergisineOdenen.Text));
            hesaplar2.Add(new KonuAciklama("Harç ve Masraflara Ödenen", lblHarcVeMasraflaraOdenen.Text));
            hesaplar2.Add(new KonuAciklama("Vekalet Ücretine Ödenen", lblVekaletUcretineOdenen.Text));
            hesaplar2.Add(new KonuAciklama(String.Empty, String.Empty));
            hesaplar2.Add(new KonuAciklama("Toplam Ödeme", lblToplamOdeme.Text));
            hesaplar2.Add(new KonuAciklama("Bakiye", lblBakiye.Text));
            hesaplar2.Add(new KonuAciklama(lblSonOdemeText.Text, lblSonOdemeBakiye.Text));
            hesaplar2.Add(new KonuAciklama("Ortalama Faiz Oranı", lblOrtFaizOrani.Text));

            GridControl hesaplar2Grid = new GridControl();
            BandedGridView hesaplarView2 = new BandedGridView(hesaplar2Grid);
            hesaplar2Grid.MainView = hesaplarView2;
            GridBand baslik4 = new GridBand();
            baslik4.Caption = "Ödemelerin Dağılımı";
            BandedGridColumn kolon7 = new BandedGridColumn();
            kolon7.AppearanceCell.Options.UseTextOptions = true;
            kolon7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            kolon7.FieldName = "Konu";
            kolon7.AppearanceCell.Font = kalinKonuFontu;
            kolon7.Name = "kolon7";
            kolon7.Caption = "Ödemelerin Dağılımı";

            BandedGridColumn kolon8 = new BandedGridColumn();
            kolon8.AppearanceCell.Options.UseTextOptions = true;
            kolon8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            kolon8.FieldName = "Aciklama";
            kolon8.Caption = "Miktar";
            kolon8.Name = "kolon8";

            baslik4.Columns.Add(kolon7);
            baslik4.Columns.Add(kolon8);
            baslik4.AppearanceHeader.Options.UseTextOptions = true;
            baslik4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            baslik4.Name = "baslik4";
            baslik4.Width = 926;
            baslik4.Visible = true;
            hesaplarView2.Bands.Add(baslik4);
            hesaplarView2.OptionsView.ColumnAutoWidth = false;
            hesaplarView2.OptionsView.ShowBands = true;
            hesaplarView2.OptionsView.ShowColumnHeaders = true;
            hesaplarView2.OptionsPrint.PrintBandHeader = true;
            hesaplar2Grid.MainView = hesaplarView2;
            hesaplar2Grid.DataSource = hesaplar2;

            this.Controls.Add(hesaplar2Grid);

            #endregion Hesap Detayları 2

            CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink(prts);
            compositeLink.PrintingSystem = new PrintingSystem();
            compositeLink.PageHeaderFooter = "Ödeme Planı";
            compositeLink.BreakSpace = 25;
            System.Drawing.Printing.Margins mrg = new System.Drawing.Printing.Margins(1, 1, 30, 1);
            compositeLink.Margins = mrg;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
            try
            {
                compositeLink.PrintingSystem.Document.ScaleFactor = 1;
            }
            catch { }
            PrintableComponentLink link = new PrintableComponentLink();
            link.Component = aciklamaGrid;

            PrintableComponentLink link2 = new PrintableComponentLink();
            link2.Component = gcSimulasyonGruplari;

            PrintableComponentLink link3 = new PrintableComponentLink();
            link3.Component = yapilanTercihler;

            PrintableComponentLink link4 = new PrintableComponentLink();
            link4.Component = hesaplar1Grid;

            PrintableComponentLink link5 = new PrintableComponentLink();
            link5.Component = hesaplar2Grid;

            PrintableComponentLink link6 = new PrintableComponentLink();
            link6.Component = gcOdemePlani;

            PrintableComponentLink link7 = new PrintableComponentLink();
            link7.Component = gcHariciAlacaklar;

            Link yazi = new Link();
            Link yazi2 = new Link();
            Link baslikYazisi = new Link();
            if (radioGroup1.SelectedIndex == 0)
            {
                yazi.CreateDetailArea += new CreateAreaEventHandler(linkGridReport_CreateDetailArea);
                yazi2.CreateDetailArea += new CreateAreaEventHandler(linkGridReport2_CreateDetailArea);
                baslikYazisi.CreateDetailArea += new CreateAreaEventHandler(linkGridReport5_CreateDetailArea);
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                yazi.CreateDetailArea += new CreateAreaEventHandler(linkGridReport3_CreateDetailArea);
                yazi2.CreateDetailArea += new CreateAreaEventHandler(linkGridReport4_CreateDetailArea);
                baslikYazisi.CreateDetailArea += new CreateAreaEventHandler(linkGridReport6_CreateDetailArea);
            }

            if (!this.hariciSimulasyon)
                compositeLink.Links.Add(baslikYazisi);

            compositeLink.Links.Add(link);

            if (!this.hariciSimulasyon)
                compositeLink.Links.Add(yazi);
            compositeLink.Links.Add(link7);
            compositeLink.Links.Add(link2);
            compositeLink.Links.Add(link3);
            compositeLink.Links.Add(link4);
            compositeLink.Links.Add(link5);
            compositeLink.Links.Add(link6);
            if (!this.hariciSimulasyon)
                compositeLink.Links.Add(yazi2);

            SaveFileDialog sv = new SaveFileDialog();
            if (ciktiTipi == 0)
                compositeLink.ShowPreviewDialog();

            else if (ciktiTipi == 1) //Excel
            {
                sv.DefaultExt = "xls";
                sv.Filter = "Excel Dosya Türü|*.xls";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToXls(sv.FileName);
                }
            }
            else if (ciktiTipi == 2) //Word
            {
                sv.DefaultExt = "doc";
                sv.Filter = "Word Dosya Türü|*.doc";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToRtf(sv.FileName);
                }
            }
            else if (ciktiTipi == 3) //Pdf
            {
                sv.DefaultExt = "xls";
                sv.Filter = "PDF (E-Book) Dosya Türü|*.pdf";
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    compositeLink.CreateDocument();
                    compositeLink.PrintingSystem.ExportToPdf(sv.FileName);
                }
            }
            else if (ciktiTipi == 4) //E-mail
            {
                ///not implemented
            }
            this.Controls.Remove(yapilanTercihler);

            //this.Controls.Remove(temerrutGrid);
            this.Controls.Remove(aciklamaGrid);
            this.Controls.Remove(hesaplar1Grid);
            this.Controls.Remove(hesaplar2Grid);
        }

        private void gcSimulasyonGruplari_MouseMove(object sender, MouseEventArgs e)
        {
            if (gwSimulasyonGruplari.IsEditing)
            {
                gwSimulasyonGruplari.CloseEditor();
                gcSimulasyonGruplari.RefreshDataSource();
            }
        }

        private void gvSimulasyonGruplari_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colSecim)
            {
                var secilen = (gcSimulasyonGruplari.DataSource as List<SimulasyonBirimi>).Where(vi => vi.Secim).SingleOrDefault();
                if (secilen == null) return;
                (bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>).ForEach(item => item.IsSelected = (secilen.ASIL_ALACAK_DOVIZ_ID == item.TUTAR_DOVIZ_ID));
            }
        }

        private void gwChildOdemePlan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var odemePlan = (gwChildOdemePlan.GetRow(e.RowHandle) as AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI);
            if (e.Column == colBSMV_2)
            {
                e.DisplayText = (odemePlan.DEVRE_FAIZI * ((decimal)FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, odemePlan.TARIH) / 100)).ToString("###,###,###,###,##0.00");
            }
            else if (e.Column == colTOPLAM_FAIZ_2)
            {
                e.DisplayText = (odemePlan.DEVRE_FAIZI * (1 + (decimal)FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, odemePlan.TARIH) / 100)).ToString("###,###,###,###,##0.00");
            }
        }

        private void gwOdemePlani_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var odemePlan = (gwOdemePlani.GetRow(e.RowHandle) as AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI);
            if (e.Column == colANAPARA)
            {
                if (mt == null || mt.AsilAlacakList.Count <= e.RowHandle) return;
                e.DisplayText = mt.AsilAlacakList[e.RowHandle].ToString("###,###,###,###,##0.00");

                //e.DisplayText = (odemePlanList.Values.ElementAt(e.RowHandle) as List<AvukatProLib2.Entities.AV001_TI_BIL_ODEME_PLANI>).Sum(item => item.BORC_TUTARI).ToString("###,###,###,###,##0.00");
            }
            else if (e.Column == colDEVRE_FAIZI)
            {
                //   e.DisplayText = (odemePlan.DEVRE_FAIZI / (1 + ((decimal)FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, odemePlan.TARIH) / 100))).ToString("###,###,###,###,##0.00");
            }
            else if (e.Column == colBSMV_3)
            {
                decimal bsmvOran = ((decimal)FaizHelper.DigerVergiOraniGetir(DigerVergiTuru.BSMV, odemePlan.TARIH));
                e.DisplayText = (odemePlan.DEVRE_FAIZI * bsmvOran / 100).ToString("###,###,###,###,##0.00");
            }
        }

        private void gwOdemePlani_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            gcChildOdemePlan.DataSource = odemePlanList.Values.ElementAt(e.FocusedRowHandle);
        }

        private void HariciAlacakNedenleriniGrupla() //Okan 20.09.2010 Harici simülasyonda Alacak Nedenlerini gruplamak için yazıldı.
        {
            if (bndHariciAlacakNeden.DataSource == null || (bndHariciAlacakNeden.DataSource as List<HariciAlacakNeden>).Count == 0) return;
            AV001_TI_BIL_FOY foy = new AV001_TI_BIL_FOY();
            foy.FAIZ_TOPLAMI = decimal.Zero;
            foy.TAKIP_VEKALET_UCRETI = seVekaletUcreti.Value;
            var tutar = new List<ParaVeDovizId>();
            var faizToplami = new List<ParaVeDovizId>();
            var vergiler = new List<ParaVeDovizId>();
            foreach (var item in bndHariciAlacakNeden.DataSource as List<HariciAlacakNeden>)
            {
                AV001_TI_BIL_ALACAK_NEDEN aNeden = new AV001_TI_BIL_ALACAK_NEDEN();
                aNeden.TUTARI = item.TUTARI;
                aNeden.VADE_TARIHI = item.TEMERRUT_TARIHI;
                tutar.Add(new ParaVeDovizId(item.TUTARI, item.TUTAR_DOVIZ_ID));
                faizToplami.Add(new ParaVeDovizId(item.ISLEMIS_FAIZ, item.TUTAR_DOVIZ_ID));
                vergiler.Add(new ParaVeDovizId(item.BSMV, item.TUTAR_DOVIZ_ID));
                aNeden.TO_UYGULANACAK_FAIZ_ORANI = aNeden.UYGULANACAK_FAIZ_ORANI = item.TO_UYGULANACAK_FAIZ_ORANI;
                aNeden.TUTAR_DOVIZ_ID = aNeden.ISLEME_KONAN_TUTAR_DOVIZ_ID = item.TUTAR_DOVIZ_ID;
                aNeden.IsSelected = true;
                foy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(aNeden);
            }
            var masraflar = new List<ParaVeDovizId>(
            new[]
                {
                    new ParaVeDovizId(seHarcVeMasraflar.Value, foy.AV001_TI_BIL_ALACAK_NEDENCollection[0].TUTAR_DOVIZ_ID),
                });

            var vekalet = new List<ParaVeDovizId>(
            new[]
                {
                    new ParaVeDovizId(seVekaletUcreti.Value, foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID)
                });

            SimulasyonBirimi foyBirimi = new SimulasyonBirimi(1)
            {
                ParaMasraflar = ParaVeDovizId.Topla(masraflar),
                ParaAsilAlacak = ParaVeDovizId.Topla(tutar),

                //       ParaFaizler = ParaVeDovizId.Topla(faizToplami),
                ParaVekaletUcreti = ParaVeDovizId.Topla(vekalet),

                //       ParaVergiler = ParaVeDovizId.Topla(vergiler)
            };

            //    foy.SON_HESAP_TARIHI = dateSonHesapTarihi.DateTime == new DateTime() ? DateTime.Today : dateSonHesapTarihi.DateTime;
            foy.BSMV_TO = foyBirimi.ParaVergiler.Para;
            foy.ASIL_ALACAK = foyBirimi.ASIL_ALACAK;
            foy.ASIL_ALACAK_DOVIZ_ID = foyBirimi.ASIL_ALACAK_DOVIZ_ID;
            foy.ISLEMIS_FAIZ = foyBirimi.FAIZLER;
            foy.ISLEMIS_FAIZ_DOVIZ_ID = foyBirimi.FAIZLER_DOVIZ_ID;
            foy.TO_MASRAF_TOPLAMI = foyBirimi.MASRAFLAR;
            foy.TO_MASRAF_TOPLAMI_DOVIZ_ID = foyBirimi.MASRAFLAR_DOVIZ_ID;
            foy.DIGER_GIDERLER = foyBirimi.DIGER;
            foy.DIGER_GIDERLER_DOVIZ_ID = foyBirimi.DIGER_DOVIZ_ID;
            foy.KALAN = foy.ASIL_ALACAK + foy.ISLEMIS_FAIZ + foy.DIGER_GIDERLER + (foy.TO_MASRAF_TOPLAMI ?? 0) + foy.TAKIP_VEKALET_UCRETI;
            foy.KALAN_DOVIZ_ID = foyBirimi.ASIL_ALACAK_DOVIZ_ID;
            foy.BIR_YIL_KAC_GUN = 360;
            foy.TO_HESAP_TIP_ID = 1;
            bndAlacakNeden.DataSource = foy.AV001_TI_BIL_ALACAK_NEDENCollection;
            foy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(item => item.ICRA_FOY_IDSource = foy);
            foyBirimi.ParaBirimi = foyBirimi.ParaDiger.DovizId;
            foyBirimi.Secim = true;
            gcSimulasyonGruplari.DataSource = new List<SimulasyonBirimi>(new[] { foyBirimi });
            SetMyFoy(foy);
        }

        private void lBtnFaizOraniUygula_Click(object sender, EventArgs e)
        {
            if (bndAlacakNeden.DataSource != null
  && bEditTOFaizOrani.EditValue != null)
            {
                List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>;
                for (int i = 0; i < alacaklar.Count; i++)
                {
                    //  if (alacaklar[i].IsSelected)
                    alacaklar[i].TO_UYGULANACAK_FAIZ_ORANI = alacaklar[i].UYGULANACAK_FAIZ_ORANI = Convert.ToDouble(bEditTOFaizOrani.EditValue);
                }

                //   spinFaizOrani.EditValue = bEditTOFaizOrani.EditValue;
                bndAlacakNeden.ResetBindings(false); // Okan - BindingSource refresh
            }
        }

        private void linkGridReport_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            StringBuilder myStringBuilder = new StringBuilder(1000);
            myStringBuilder.AppendFormat(@" Yukarıda isimleri belirtilen dosya borçlusu/ları ile alacaklı temsilcileri, birlikte daireye geldi. ");
            myStringBuilder.AppendFormat(@"Borçlu taraf ödeme emrinin{0} dairede tebliğini talep etti. Tebliğ edildi. Borçlu taraf söz alarak ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"ödeme emrinde lehime/ize işleyen sürelerden feragat{0} ediyorum/uz. Borca ve ferilerine bir ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"itirazım/ız yoktur. Borca, ferilerine ve takibe ilişkin her türlü itirazdan vazgeçiyor ve{0} takibin ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"kesinleşmesini kabul ediyorum/uz dedi/ler.  borcu kabul ediyorum, takibi kesinleşmesini kabul ");
            myStringBuilder.AppendFormat(@"ediyorum dedi.{0} Takibin kesinleştiği bildirildi. Her hangi bir itirazım yoktur dedi. Borçlu söze ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"devamla, takibe konu işbu borcumu yıllık{0} aşağıda detaylı dökümü belirtilen faiz ve faizin gider ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"vergisi ile birlikte yine aşağıdaki ödeme planı çerçevesinde;");

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 10);
            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 110);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        private void linkGridReport2_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            StringBuilder myStringBuilder = new StringBuilder(1140);
            myStringBuilder.AppendFormat(@" olmak üzere toplam [" + lblToplamTutar.Text + "] ödemeyi, işbu ödeme taahhüdünün borcun tecditi veya temdidi anlamına{0} ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"gelmediğini ve bu şekilde yorumlanamayacağını, taahhüdüme konu ödemelerimi aksattığım takdirde, ");
            myStringBuilder.AppendFormat(@"alacaklının takibe{0} takip talebindeki tutar ve şartlarla devam edeceğini, o tarihe kadar yaptığım ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"ödemelerin de öncelikle faizden mahsup{0} edileceğini kabul, beyan  ve taahhüt ediyorum/uz dedi. ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"Borçlu taraf söze devamla, yukarıdaki ödeme taahhüdüme/üze{0} harçlar ile dosyaya yapılacak usulü ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"işlemlere ilişkin masraflar dahil olmayıp harçlar ile daha sonra oluşacak masrafları{0} son taksitle ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"birlikte ödeyeceğim/iz dedi.  {0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" Alacaklı vekilinden soruldu. Ödeme taahhüdünü aynen kabul ediyorum. Ödeme taahhüdünün ihlali ");
            myStringBuilder.AppendFormat(@"halinde ise indirimsiz{0} olarak takip talebinde yazılı şartlarla tahsil edilecektir dedi. {0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" Taahhüdün kabul edildiği borçluya/lara tefhim edildi. Borçlu/lar ödeme taahhüdüme/üze aynen ");
            myStringBuilder.AppendFormat(@"uyacağım/ız dedi. {0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" İşbu ödeme taahhüdü taraflara ayrıca okundu. Gerçek irademize uygundur dediler ve hep birlikte imza ");
            myStringBuilder.AppendFormat(@"altına alındı.{0} [" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + ".]{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" İcra Müd.{0}{0}ALACAKLI (" + lueTaahhutKabulEden.Text + "){0}{0}BORÇLU (" + lueTaahhutEden.Text + ") {1}", ControlChars.Tab, Environment.NewLine);

            TextBrick tb = new TextBrick();

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 10);
            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 300);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        private void linkGridReport3_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            StringBuilder myStringBuilder = new StringBuilder();
            myStringBuilder.AppendFormat(@" Yukarıda müdürlüğü ve esas numarası belirtilmiş dosya ile takibe konmuş borcu, borçların ");
            myStringBuilder.AppendFormat(@"ertelendiği veya yenilendiği{0} anlamına gelmemesi kaydıyla, indirim uygulanarak aşağıdaki şartlarla ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"ödenmesi hususunda taraflar mutabık kalmışlardır.");
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" Borçlunun ödemelerini gününde ve eksiksiz ödemesi halinde dosya borcu indirimli olarak ve harçlar ");
            myStringBuilder.AppendFormat(@"borçluya ait olmak{0} üzere kapatılacaktır. Aşağıdaki hesaba harçlar dahil değildir. {0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" Borçlu/lar, takibe konu borçlarını gayrikabili rücu kabul etmişlerdir ve var ise anılan takip ");
            myStringBuilder.AppendFormat(@"dosyası ve bu dosya ile bu{0} dosyaya konu alacağın tahsili için başlatılan bağlantılı diğer icra ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"takip dosyalarına yapmış oldukları itirazlarından feragat{0} edecekler, takipleri ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"kesinleştireceklerdir. {0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" Ödemelerin gününde ve tam olarak yapılmaması halinde ise indirimsiz olarak yukarıda anılan icra ");
            myStringBuilder.AppendFormat(@"dosyasına ait şartlarla{0} ve yapılmış ödemeler de faizden mahsup edilerek icra takibiyle tahsili ", Environment.NewLine);
            myStringBuilder.AppendFormat(@"cihetine gidilecektir. {0}", Environment.NewLine);

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 10);
            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 220);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        private void linkGridReport4_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" olmak üzere toplam " + lblToplamTutar.Text + " olup, birlikte okunup imzalanmıştır. " + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + ".");
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@" İcra Müd.{0}{0}ALACAKLI (" + lueTaahhutKabulEden.Text + "){0}{0}BORÇLU (" + lueTaahhutEden.Text + ") {1}", ControlChars.Tab, Environment.NewLine);

            TextBrick tb = new TextBrick();

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 10);
            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 100);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        private void linkGridReport5_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"TAAHHÜT");
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);

            TextBrick tb = new TextBrick();

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 14, FontStyle.Bold);

            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 50);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            e.Graph.DrawBrick(tb);
        }

        private void linkGridReport6_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            StringBuilder myStringBuilder = new StringBuilder();

            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"PROTOKOL");
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);
            myStringBuilder.AppendFormat(@"{0}", Environment.NewLine);

            TextBrick tb = new TextBrick();

            tb.Text = myStringBuilder.ToString();
            tb.Font = new Font("Arial", 14, FontStyle.Bold);

            tb.Rect = new RectangleF(15, 0, kagitGenisligi, 50);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            e.Graph.DrawBrick(tb);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            double oran = 0;
            if (String.IsNullOrEmpty(txtFaizOrani.Text) || !double.TryParse(txtFaizOrani.Text, out oran)) return;
            if (bndAlacakNeden.DataSource != null)
            {
                List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>;
                for (int i = 0; i < alacaklar.Count; i++)
                {
                    if (alacaklar[i].IsSelected)
                        alacaklar[i].TO_UYGULANACAK_FAIZ_ORANI = oran;
                }
            }
            if (bndHariciAlacakNeden.DataSource != null)
            {
                List<HariciAlacakNeden> alacaklar = bndHariciAlacakNeden.DataSource as List<HariciAlacakNeden>;
                for (int i = 0; i < alacaklar.Count; i++)
                {
                    alacaklar[i].TO_UYGULANACAK_FAIZ_ORANI = oran;
                }
            }
        }

        private void lueTaahhutEden_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTaahhutEden.EditValue != null)
            {
                TaahhutTaraf taahhutEden = new TaahhutTaraf();
                if (lueTaahhutEden.EditValue != null)
                    taahhutEden.CariId = (int)lueTaahhutEden.EditValue;
                taahhutEden.Adi = lueTaahhutEden.Text;
                taahhutEden.TakipEdenmi = false;
                TaahhutEden = taahhutEden;
                wpTaahhütTaraflari.AllowNext = (lueTaahhutKabulEden.EditValue != null);
            }
        }

        private void lueTaahhutKabulEden_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTaahhutKabulEden.EditValue != null)
            {
                TaahhutTaraf taahutKabulEden = new TaahhutTaraf();
                if (lueTaahhutKabulEden.EditValue != null)
                    taahutKabulEden.CariId = (int)lueTaahhutKabulEden.EditValue;
                taahutKabulEden.Adi = lueTaahhutKabulEden.Text;
                taahutKabulEden.TakipEdenmi = true;
                TaahhutKabulEden = taahutKabulEden;
                wpTaahhütTaraflari.AllowNext = (lueTaahhutEden.EditValue != null);
            }
        }

        private void prVekaletUcreti_TutarDegisti(object sender, EventArgs e)
        {
            if (MyFoy != null && vekaletUcretiDegistir) MyFoy.TAKIP_VEKALET_UCRETI = prVekaletUcreti.Tutar.Para;
            lblVekaletUcreti.Text = MyFoy.TAKIP_VEKALET_UCRETI.ToString(String.Format("###,###,###,###,##0.00 {0}", BelgeUtil.Inits._DovizTipGetir.Single(item => item.ID == (MyFoy.TAKIP_VEKALET_UCRETI_DOVIZ_ID ?? 1)).DOVIZ_KODU));
            vekaletUcretiDegistir = true;
        }

        private void SeciliAlacakNedenleriGrupla() // Okan 26.05.2010
        {
            if (bndAlacakNeden.DataSource == null) return;
            List<int> dovizIdList = null;
            if (gcSimulasyonGruplari.DataSource != null)
            {
                var simBirim = (gcSimulasyonGruplari.DataSource as List<SimulasyonBirimi>).Where(item => item.Secim);
                if (simBirim != null) dovizIdList = simBirim.Select(vi => vi.ASIL_ALACAK_DOVIZ_ID).ToList();
            }

            //List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = (bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>).Where(item => item.IsSelected).ToList();
            List<AV001_TI_BIL_ALACAK_NEDEN> alacaklar = (bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>);
            AlacaklariGrupla yeniGrup = new AlacaklariGrupla(MyFoy, MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ToList(), ceGayriNakit.Checked);
            if (dovizIdList != null && dovizIdList.Count > 0) yeniGrup.BirimListesi.ForEach(itm => { if (dovizIdList.Contains(itm.ASIL_ALACAK_DOVIZ_ID)) itm.Secim = true; });
            
            gcSimulasyonGruplari.DataSource = yeniGrup.BirimListesi;

            for (int i = 0; i < gwSimulasyonGruplari.RowCount; i++)
            {
                gwSimulasyonGruplari.SetRowCellValue(i, "Secim", true);
            }
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            ExportIt(0);
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            foreach (var item in bndAlacakNeden.DataSource as List<AV001_TI_BIL_ALACAK_NEDEN>)
            {
                item.UYGULANACAK_FAIZ_ORANI = item.TO_UYGULANACAK_FAIZ_ORANI;
            }
            MyFoy.BAKIYE_HARC_TOPLAMA_EKLE = cbBakiyeHarcHesabaDahil.Checked;
            MyFoy.SON_HESAP_TARIHI = dateSonHesapTarihi.DateTime;
            foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                item.SABIT_FAIZ_UYGULA = true;
            }
            if (!ceGayriNakit.Checked)
            {
                foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item))
                        item.Tag = 1;
                    else
                        item.Tag = null;
                }

                MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Filter = "Tag = null";
            }
            else
            {
                MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Filter = string.Empty;
            }

            MyFoy.Tag = "Cekme"; //hesaplama esnasında Deepload çekilmemesi için

            //      Hesap.Icra hy = new Hesap.Icra(MyFoy, false);

            #region Hesap Güncelleme - 07.06.2010

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(delegate(object s1, DoWorkEventArgs e1)
            {
                if (!hariciSimulasyon)
                {
                    if (e1.Argument is AV001_TI_BIL_FOY)
                    {
                        var icraFoy = e1.Argument as AV001_TI_BIL_FOY;
                        Hesap.Icra hesap = new Hesap.Icra(icraFoy, false);
                        e1.Result = hesap;
                    }
                    else if (e1.Argument is AV001_TDIE_BIL_PROJE)
                    {
                        var proje = e1.Argument as AV001_TDIE_BIL_PROJE;

                        KlasorHesapAraclari kHesap = new KlasorHesapAraclari();
                        var ozet = kHesap.GetKonsolideAlacaklarHesabi2G(proje, false);
                        e1.Result = kHesap.HesapAraci;
                    }
                }
            });
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate(object s1, RunWorkerCompletedEventArgs e1)
            {
                gcHariciAlacaklar.Enabled = true;
                if (e1.Result != null)
                {
                    var hesap = e1.Result as Hesap.Icra;
                    this.MyFoy = hesap.Foy;

                    SetMyFoy(MyFoy);

                    //    MySimilasyon = HesapAraclari.SimilasyonHesapCetveli.GetSimilasyonCetveliByFoy(MyFoy);
                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Filter = string.Empty;

                    HesapDetaylariniGuncelle(null);
                    return;
                }
            });

            gcHariciAlacaklar.Enabled = false;
            if (MyProje != null)
            {
                bw.RunWorkerAsync(MyProje);
            }
            else if (MyFoy != null)
            {
                bw.RunWorkerAsync(MyFoy);
            }

            #endregion Hesap Güncelleme - 07.06.2010
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            ExportIt(1);
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            ExportIt(3);
        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            ExportIt(2);
        }

        private void wizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == wpOdemePlani && !hesapTiklandi)
                e.Page.AllowNext = false;
            else if (e.Page != wpTaahhütTaraflari) e.Page.AllowNext = true;

            if (e.Page == wpHesapKosullari)
            {
                if (!(gcSimulasyonGruplari.DataSource as List<SimulasyonBirimi>).Exists(vi => vi.Secim))
                {
                    MessageBox.Show("Lütfen Para Birimine Göre Alacak Kalemi Seçiniz");
                    e.Cancel = true;
                }

                rgKosullar.SelectedIndex = 0;
            }
            else if (e.PrevPage == wpAlacakNedenleri && hariciSimulasyon && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                HariciAlacakNedenleriniGrupla();
                if (MySimilasyon != null)
                    HesapDetaylariniGuncelle(null);
                e.Page = wpHesapParametreleri;
            }
            else if (e.PrevPage == wpHesapParametreleri)
            {
                e.Page = hariciSimulasyon ? wpAlacakNedenleri : wpTaahhütTaraflari;
            }
            else if (e.Page == wpTaahhütTaraflari && hariciSimulasyon && e.Direction == DevExpress.XtraWizard.Direction.Backward)
            {
                e.Page = wpAlacakNedenleri;
            }
            else if (e.Page == wpTaahhütTaraflari && !hariciSimulasyon)
            {
                e.Page.AllowBack = false;
            }
        }
    }

    public class HariciAlacakNeden
    {
        public decimal OncekiFaiz = 0;

        public HariciAlacakNeden()
        {
        }

        public HariciAlacakNeden(decimal tutari, int tutariDovizId, DateTime? temerrutTarihi, double faizOrani)
        {
            TUTARI = tutari;
            TUTAR_DOVIZ_ID = tutariDovizId;
            TEMERRUT_TARIHI = temerrutTarihi;
            TO_UYGULANACAK_FAIZ_ORANI = faizOrani;
        }

        public static DateTime? ILK_ODEME_TARIHI { get; set; }

        public decimal BSMV
        {
            get
            {
                if (!TEMERRUT_TARIHI.HasValue) return 0;
                double bsmv = ManuelTaahhut.BSMV_ORANI == 0 ? 5 : ManuelTaahhut.BSMV_ORANI;
                decimal tutar = TUTARI * (((ILK_ODEME_TARIHI ?? DateTime.Today) - TEMERRUT_TARIHI.Value.Date).Days * (decimal)(TO_UYGULANACAK_FAIZ_ORANI / (360 * 100))) * ((decimal)(bsmv / 100));
                return tutar < 0 ? 0 : tutar + (OncekiFaiz * ((decimal)(bsmv / 100)));
            }
        }

        public decimal ISLEMIS_FAIZ
        {
            get
            {
                if (!TEMERRUT_TARIHI.HasValue) return 0;
                decimal tutar = TUTARI * (((ILK_ODEME_TARIHI ?? DateTime.Today) - TEMERRUT_TARIHI.Value.Date).Days * (decimal)(TO_UYGULANACAK_FAIZ_ORANI / (360 * 100)));
                return tutar < 0 ? 0 : tutar + OncekiFaiz;
            }
        }

        public DateTime? TEMERRUT_TARIHI { get; set; }

        public double TO_UYGULANACAK_FAIZ_ORANI { get; set; }

        public int TUTAR_DOVIZ_ID { get; set; }

        public decimal TUTARI { get; set; }
    }

    internal class TaahhutTaraf
    {
        private string _adi;
        private int _cariId;

        private bool _takipEdenmi;

        public string Adi
        {
            get { return _adi; }
            set { _adi = value; }
        }

        public int CariId
        {
            get { return _cariId; }
            set { _cariId = value; }
        }

        public bool TakipEdenmi
        {
            set { _takipEdenmi = value; }
        }

        public override string ToString()
        {
            return Adi;
        }
    }
}