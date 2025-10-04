using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace AdimAdimDavaKaydi.Is
{
    public partial class frmIsSureOlcer : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public string projeadi;
        public int projeID;
        public int SorumluCariId;
        private int dak, saat, saniye;
        private int dak1, saat1, saniye1;
        private int dak2, saat2, saniye2;
        private int dak3, saat3, saniye3;
        private int dak4, saat4, saniye4;
        private int HareketAltKategoriID;
        private int j;
        private int lockTimerCounter, lockTimerCounter2;
        private double miktar;
        private TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE> myDataSource;
        private TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE> MyDataSourceGrid = new TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>();
        private AV001_TDI_BIL_IS myIs;
        private Dictionary<int, int> paralar = new Dictionary<int, int>();
        private int sayi;
        private ArcScaleComponent scaleMinutes, scaleSeconds;
        private string str = "";

        private AV001_TDI_BIL_IS_TAMAMLANMA_SURE sur;

        private AV001_TDI_BIL_IS_TAMAMLANMA_SURE surem;

        public frmIsSureOlcer()
        {
            InitializeComponent();
            InitializeEvents();

            scaleMinutes = circularGauge2.AddScale();
            scaleSeconds = circularGauge2.AddScale();
            this.FormClosing += frmIsSureOlcer_FormClosing;
            scaleMinutes.Assign(scaleHours);
            scaleSeconds.Assign(scaleHours);

            arcScaleNeedleComponent5.ArcScale = scaleMinutes;
            arcScaleNeedleComponent6.ArcScale = scaleSeconds;
            Analog.Start();
            OnTimerTick(null, null);
            Digital.Start();
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDataSource = value;
                    bndIsSurec.DataSource = value;
                    bndIsSurec.AddingNew += MyDataSource_AddingNew;
                    bndIsSurec.AddNew();

                    panelcontrolDoldur();
                    lueSorumlu.EditValue = SorumluCariId;
                    lblIs.Text = projeadi + " Ait " + "İşin Çalışma Süreci";
                }
            }
        }

        public AV001_TDI_BIL_IS MyIs
        {
            get { return myIs; }
            set
            {
                if (value != null)
                {
                    myIs = value;
                    HareketAltKategoriID = myIs.KATEGORI_ID.Value;
                    if (MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(MyIs, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>
                                                                             ));

                    // MyDataSource = MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection;
                }
            }
        }

        public void DurumAciklamaGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("HacizChildTip");
            dt.Columns.Add("DEGER");
            dt.Columns.Add("ACIKLAMA");
            foreach (DurumAciklama tipi in Enum.GetValues(typeof(DurumAciklama)))
            {
                dt.Rows.Add(tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "DEGER";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Durum Açıklama"));
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (btnBaslat.Text == "Çalışmaya Başla")
            {
                btnBaslat.Text = "Çalışmaya Bitir";
                timer1.Start();
            }
            else if (btnBaslat.Text == "Çalışmaya Bitir")
            {
                surem.BITIS_ZAMANI = DateTime.Now;
                btnBaslat.Text = "Çalışmaya Başla";
                timer1.Stop();
            }

            yazdir();
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            surem.BITIS_ZAMANI = DateTime.Now;
            frmIsKayitDetay detay = new frmIsKayitDetay();
            AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAY dty = new AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAY();
            detay.MyDataSource = dty;
            surem.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection.Add(dty);

            detay.Show();
            timer1.Stop();

            int tmilk = 0;
            if (sur != null && sur.SURE.HasValue)
                tmilk = sur.SURE.Value;

            sur = new AV001_TDI_BIL_IS_TAMAMLANMA_SURE();
            
            sur.BASLANGIC_ZAMANI = surem.BASLANGIC_ZAMANI;
            sur.BIRIM_FIYAT = surem.BIRIM_FIYAT;
            sur.BIRIM_FIYAT_DOVIZ_ID = surem.BIRIM_FIYAT_DOVIZ_ID;
            sur.BITIS_ZAMANI = surem.BITIS_ZAMANI;
            sur.IS_SOZLESME_ID = surem.IS_SOZLESME_ID;
            sur.IS_SUREC_ID = surem.IS_SUREC_ID;
            sur.MADDE_KALEM_ID = surem.MADDE_KALEM_ID;
            sur.TOPLAM_FIYAT = surem.TOPLAM_FIYAT;
            sur.TOPLAM_FIYAT_DOVIZ_ID = surem.TOPLAM_FIYAT_DOVIZ_ID;
            sur.SUREC_ACIKLAMA = surem.SUREC_ACIKLAMA;
            sur.SORUMLU_CARI_ID = surem.SORUMLU_CARI_ID;
            DateTime tm = new DateTime(2000, 01, 01, saat, dak, saniye);
            sur.SURE = 0;
            int i = Convert.ToInt32(tm.TimeOfDay.TotalMilliseconds);
            sur.SURE = i;
            var fark = i - tmilk;
            var c = TimeSpan.FromMilliseconds(fark);
            sur.SUREC_ACIKLAMA = string.Format("{0:00}:{1:00}:{2:00}", c.Hours, c.Minutes, c.Seconds);
            spToplamUcretBirim.EditValue = Convert.ToDecimal(surem.TOPLAM_FIYAT);
            sur.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection.AddRange(
                surem.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection);
            detay.FormClosing += detay_FormClosing;
            yazdir();
            bndIsSurec.AddNew();

            sayi++;
        }

        private void detay_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyDataSourceGrid.Add(sur);
            gcIsSurec.DataSource = MyDataSourceGrid;
            timer1.Start();
            foreach (var item in MyDataSource[0].AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection)
            {
                var dizi = item.OZEL_ALAN.Split(':');
            }
        }

        private void Digital_Tick(object sender, EventArgs e)
        {
            if (lockTimerCounter2 == 0)
            {
                lockTimerCounter2++;
                UpdateTime();
                lockTimerCounter2--;
            }
        }

        private void frmIsSureOlcer_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (MyDataSource.Any(q => q.IS_SUREC_ID == 0))
            {
                XtraMessageBox.Show("Lütfen Süreç Seçiniz");
                return;
            }
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                //DateTime tm = new DateTime(2000, 01, 01, saat, dak, saniye);
                foreach (var item in MyDataSource)
                {
                    item.IS_ID = MyIs.ID;
                    item.BIRIM_FIYAT_DOVIZ_ID = 1;
                    item.TOPLAM_FIYAT_DOVIZ_ID = 1;
                    if (item.BITIS_ZAMANI == DateTime.MinValue)
                        item.BITIS_ZAMANI = surem.BITIS_ZAMANI;
                }
                trans.BeginTransaction();

                DataRepository.AV001_TDI_BIL_IS_TAMAMLANMA_SUREProvider.DeepSave(trans, MyDataSource,
                                                                                 DeepSaveType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <
                                                                                     AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAY
                                                                                     >));
                foreach (var item in MyDataSource)
                {
                    if (
                        MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection.Exists(
                            delegate(AV001_TDI_BIL_IS_TAMAMLANMA_SURE surec) { return surec.ID == item.ID; })) continue;
                    MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection.Add(item);
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(trans, MyIs, DeepSaveType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>));
                }

                trans.Commit();
                XtraMessageBox.Show("Kayıt Tamamlandı");
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.Error("Hata", ex);
                BelgeUtil.ErrorHandler.Catch(this, ex);
                trans.Rollback();
            }
        }

        private void frmIsSureOlcer_FormClosing(object sender, FormClosingEventArgs e)
        {
            lockTimerCounter++;
            lockTimerCounter2++;
            if (Analog != null)
            {
                Analog.Stop();
                Analog.Dispose();
                Analog = null;
            }
            if (Digital != null)
            {
                Digital.Stop();
                Digital.Dispose();
                Digital = null;
            }
        }

        private void frmIsSureOlcer_Load(object sender, EventArgs e)
        {
            InitsData();
            if (MyDataSource == null)
                MyDataSource = new TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>();
            SummaryItemEkle(gridView1);
        }

        private int GetStringLength(string str)
        {
            int counter = 0;
            int pos = 0;
            while (pos < str.Length)
            {
                if (str[pos] != ':') counter++;
                pos++;
            }
            return counter;
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.GridSummaryItem summaryItem = e.Item as DevExpress.XtraGrid.GridSummaryItem;

            #region Para

            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                paralar.Clear();
            }
            else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                if (e.FieldValue != null)
                {
                    var sure = view.GetRowCellValue(e.RowHandle, "OZEL_ALAN").ToString();
                    var sr = e.FieldValue.ToString().Split(':');
                    int? hour = Convert.ToInt32(sr[0]);
                    int? minute = Convert.ToInt32(sr[1]);
                    int? second = Convert.ToInt32(sr[2]);

                    second += (hour * 3600) + (minute * 60);
                    if (sure != null)
                    {
                        if (paralar.ContainsKey(j))
                        {
                            paralar[j] += second.Value;
                            j++;
                        }
                        else
                            paralar.Add(j, second.Value);
                    }
                    else if (sure == null)
                    {
                        if (paralar.ContainsKey(1))
                            paralar[1] += second.Value;
                        else
                            paralar.Add(1, second.Value);
                    }
                }
            }
            else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                int toplam = 0;

                string fieldName = string.Empty;
                if (paralar.Count > 1)
                {
                    foreach (KeyValuePair<int, int> para in paralar)
                    {
                        toplam += para.Value;
                    }
                }
                else if (paralar.Count == 1)
                {
                    foreach (KeyValuePair<int, int> item in paralar)
                    {
                        toplam = item.Value;
                    }
                }
                int s = toplam % 60;
                int d = toplam / 60;
                int h = 0;
                if (d > 60)
                {
                    h = d / 60;
                    d = d % 60;
                }
                string yazdirilacakAlan = h + ":" + d + ":" + s;
                e.TotalValue = yazdirilacakAlan;
            }

            #endregion Para
        }

        private void gridView3_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView3.FocusedRowHandle >= 0)
                exgrdIsdetay.DataSource =
                    MyDataSourceGrid[gridView3.FocusedRowHandle].AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIsSureOlcer_Button_Kaydet_Click;
        }

        private void InitsData()
        {
            BelgeUtil.Inits.DovizTipGetir(lueSaatUcretBirim);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueToplamUcretBirim);
            BelgeUtil.Inits.IsSozlesmeGetir(lueSozlesme);
            BelgeUtil.Inits.IsSozlesmeGetir(rlueSozlesme);
            BelgeUtil.Inits.IsSurecGetir(lueSurec);
            BelgeUtil.Inits.IsSurecGetir(rLueIsSurec);
            BelgeUtil.Inits.perCariGetir(lueSorumlu.Properties);
            BelgeUtil.Inits.perCariGetir(rLueSorumlu);
            BelgeUtil.Inits.ParaBicimiAyarla(spSaatUcret);
            BelgeUtil.Inits.ParaBicimiAyarla(spToplamUcretBirim);
            BelgeUtil.Inits.ParaBicimiAyarla(spPara);
            DurumAciklamaGetir(rLueDurmaNeden);
        }

        private void ISMIKTAR()
        {
            //if (string.IsNullOrEmpty(lueSozlesme.EditValue.ToString()))
            //    return;

            int sozlesme_id = Convert.ToInt32(lueSozlesme.EditValue);
            TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> DetaySrm =
                DataRepository.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUProvider.GetByIS_MUHASEBE_ALT_KATEGORI_ID(
                    HareketAltKategoriID);
            TList<AV001_TDI_BIL_IS_SOZLESME_DETAY> Detay =
                DataRepository.AV001_TDI_BIL_IS_SOZLESME_DETAYProvider.GetByIS_MUHASEBE_ALT_KATEGORI_ID(
                    HareketAltKategoriID);
            DetaySrm.Filter = "IS_SOZLESME_ID = " + sozlesme_id;
            Detay.Filter = "IS_SOZLESME_ID = " + sozlesme_id;
            foreach (var item in DetaySrm)
            {
                if (item.IS_MIKTAR != 0)
                {
                    //foreach (var Sure in MyDataSource)
                    //{
                    if (surem.ID == 0)
                    {
                        miktar = Convert.ToDouble(item.IS_MIKTAR);
                        surem.BIRIM_FIYAT = item.IS_MIKTAR;
                        surem.BIRIM_FIYAT_DOVIZ_ID = item.DOVIZ_ID.Value;
                        surem.TOPLAM_FIYAT = Convert.ToDecimal(miktar / 3600);
                        surem.TOPLAM_FIYAT_DOVIZ_ID = item.DOVIZ_ID.Value;
                    }

                    // }
                }
            }
            foreach (var item in Detay)
            {
                if (item.IS_MIKTAR != 0)
                {
                    //foreach (var Sure in MyDataSource)
                    //{
                    if (surem.ID == 0)
                    {
                        miktar = Convert.ToDouble(item.IS_MIKTAR);
                        surem.BIRIM_FIYAT = item.IS_MIKTAR;
                        surem.BIRIM_FIYAT_DOVIZ_ID = item.DOVIZ_ID.Value;
                        surem.TOPLAM_FIYAT = Convert.ToDecimal(miktar / 3600);
                        surem.TOPLAM_FIYAT_DOVIZ_ID = item.DOVIZ_ID.Value;
                    }

                    // }
                }
            }
            surem.IS_SOZLESME_ID = sozlesme_id;
            lueSozlesme.EditValue = sozlesme_id;
        }

        private void lueSozlesme_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSozlesme.EditValue != null)
            {
                ISMIKTAR();
            }
        }

        private void lueSurec_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSurec.EditValue != null)
                (bndIsSurec.Current as AV001_TDI_BIL_IS_TAMAMLANMA_SURE).IS_SUREC_ID = (int)lueSurec.EditValue;
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            surem = new AV001_TDI_BIL_IS_TAMAMLANMA_SURE();
            surem.BASLANGIC_ZAMANI = DateTime.Now;
            surem.SORUMLU_CARI_ID = SorumluCariId;
            
            if (sur != null)
            {
                surem.BASLANGIC_ZAMANI = sur.BASLANGIC_ZAMANI;
                surem.BIRIM_FIYAT = sur.BIRIM_FIYAT;
                surem.BIRIM_FIYAT_DOVIZ_ID = sur.BIRIM_FIYAT_DOVIZ_ID;
                surem.BITIS_ZAMANI = sur.BITIS_ZAMANI;
                surem.IS_SUREC_ID = sur.IS_SUREC_ID;
                surem.IS_SOZLESME_ID = sur.IS_SOZLESME_ID;
                surem.SURE = sur.SURE;
                ISMIKTAR();
            }
            e.NewObject = surem;
            exgrdIsdetay.DataSource = surem.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection;
        }

        private void OnTimerTick(object sender, System.EventArgs e)
        {
            if (lockTimerCounter == 0)
            {
                lockTimerCounter++;
                UpdateClock(DateTime.Now, scaleHours, scaleMinutes, scaleSeconds);
                lockTimerCounter--;
            }
        }

        private void panelcontrolDoldur()
        {
            #region bu sorumlunun bu işteki harcadığı zaman

            foreach (var item in MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection)
            {
                if (item.SURE == null)
                    item.SURE = 0;
                int i = item.SURE.Value;
                DateTime tm = new DateTime(i * 10000);

                //   tm.AddMilliseconds(Convert.ToDouble(i));// = i;
                if (item.SORUMLU_CARI_ID == SorumluCariId)
                {
                    dak1 += tm.Minute;
                    saat1 += tm.Hour;
                    saniye1 += tm.Second;
                    foreach (var sure in item.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection)
                    {
                        dak1 += sure.DURMA_TARIH_ZAMAN.Value.Minute - sure.BASLAMA_TARIH_ZAMAN.Value.Minute;
                        saat1 += sure.DURMA_TARIH_ZAMAN.Value.Hour - sure.BASLAMA_TARIH_ZAMAN.Value.Hour;
                        saniye1 += sure.DURMA_TARIH_ZAMAN.Value.Second - sure.BASLAMA_TARIH_ZAMAN.Value.Second;
                    }
                }
            }
            if (saniye1 >= 60)
            {
                dak1++;
                saniye1 = saniye1 - 60;
                if (saniye1 < 0)
                    saniye1 = 0;
            }
            if (dak1 >= 60)
            {
                dak1 = dak1 - 60;
                if (dak1 < 0)
                    dak1 = 0;
                saat1++;
            }

            txtBuIstekiZaman.Text = yazdirZaman(dak1, saat1, saniye1);

            #endregion bu sorumlunun bu işteki harcadığı zaman

            #region bu sorumlunun Bu projedeki Harcadığı Zaman

            if (projeID > 0)
            {
                TList<AV001_TDIE_BIL_PROJE_IS> proj =
                    DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByPROJE_ID(projeID);
                foreach (AV001_TDIE_BIL_PROJE_IS projIs in proj)
                {
                    if (projIs.IS_IDSource == null)
                        projIs.IS_IDSource = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(projIs.IS_ID);

                    AV001_TDI_BIL_IS isim = projIs.IS_IDSource;
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(isim, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>));
                    foreach (var Is in isim.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection)
                    {
                        if (Is.SURE == null)
                            Is.SURE = 0;
                        int i = Is.SURE.Value;
                        DateTime tm = new DateTime(i * 10000);

                        //   tm.AddMilliseconds(Convert.ToDouble(i));// = i;
                        if (Is.SORUMLU_CARI_ID == SorumluCariId)
                        {
                            dak2 += tm.Minute;
                            saat2 += tm.Hour;
                            saniye2 += tm.Second;
                            foreach (var sure in Is.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection)
                            {
                                dak2 += sure.DURMA_TARIH_ZAMAN.Value.Minute - sure.BASLAMA_TARIH_ZAMAN.Value.Minute;
                                saat2 += sure.DURMA_TARIH_ZAMAN.Value.Hour - sure.BASLAMA_TARIH_ZAMAN.Value.Hour;
                                saniye2 += sure.DURMA_TARIH_ZAMAN.Value.Second - sure.BASLAMA_TARIH_ZAMAN.Value.Second;
                            }
                        }
                    }
                }
                if (saniye2 >= 60)
                {
                    dak2++;
                    saniye2 = saniye2 - 60;
                    if (saniye2 < 0)
                        saniye2 = 0;
                }
                if (dak2 >= 60)
                {
                    dak2 = dak2 - 60;
                    if (dak2 < 0)
                        dak2 = 0;
                    saat2++;
                }
            }

            txtProjedeHarcanan.Text = yazdirZaman(dak2, saat2, saniye2);

            #endregion bu sorumlunun Bu projedeki Harcadığı Zaman

            #region Bu İşteki Toplam Zaman

            foreach (var item in MyIs.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection)
            {
                if (item.SURE == null)
                    item.SURE = 0;
                int i = item.SURE.Value;
                DateTime tm = new DateTime(i * 10000);

                //   tm.AddMilliseconds(Convert.ToDouble(i));// = i;

                dak3 += tm.Minute;
                saat3 += tm.Hour;
                saniye3 += tm.Second;
                foreach (var sure in item.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection)
                {
                    dak3 += sure.DURMA_TARIH_ZAMAN.Value.Minute - sure.BASLAMA_TARIH_ZAMAN.Value.Minute;
                    saat3 += sure.DURMA_TARIH_ZAMAN.Value.Hour - sure.BASLAMA_TARIH_ZAMAN.Value.Hour;
                    saniye3 += sure.DURMA_TARIH_ZAMAN.Value.Second - sure.BASLAMA_TARIH_ZAMAN.Value.Second;
                }
            }
            if (saniye3 >= 60)
            {
                dak3++;
                saniye3 = saniye3 - 60;
                if (saniye3 < 0)
                    saniye3 = 0;
            }
            if (dak3 >= 60)
            {
                dak3 = dak3 - 60;
                if (dak3 < 0)
                    dak3 = 0;
                saat3++;
            }

            txtBuIsteHarcanantoplam.Text = yazdirZaman(dak3, saat3, saniye3);

            #endregion Bu İşteki Toplam Zaman

            #region Bu Projedeki Toplam

            if (projeID > 0)
            {
                TList<AV001_TDIE_BIL_PROJE_IS> proj =
                    DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByPROJE_ID(projeID);
                foreach (AV001_TDIE_BIL_PROJE_IS projIs in proj)
                {
                    if (projIs.IS_IDSource == null)
                        projIs.IS_IDSource = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(projIs.IS_ID);

                    AV001_TDI_BIL_IS isim = projIs.IS_IDSource;
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(isim, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>));
                    foreach (var Is in isim.AV001_TDI_BIL_IS_TAMAMLANMA_SURECollection)
                    {
                        if (Is.SURE == null)
                            Is.SURE = 0;
                        int i = Is.SURE.Value;
                        DateTime tm = new DateTime(i * 10000);

                        //   tm.AddMilliseconds(Convert.ToDouble(i));// = i;

                        dak4 += tm.Minute;
                        saat4 += tm.Hour;
                        saniye4 += tm.Second;
                        foreach (var sure in Is.AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAYCollection)
                        {
                            dak4 += sure.DURMA_TARIH_ZAMAN.Value.Minute - sure.BASLAMA_TARIH_ZAMAN.Value.Minute;
                            saat4 += sure.DURMA_TARIH_ZAMAN.Value.Hour - sure.BASLAMA_TARIH_ZAMAN.Value.Hour;
                            saniye4 += sure.DURMA_TARIH_ZAMAN.Value.Second - sure.BASLAMA_TARIH_ZAMAN.Value.Second;
                        }
                    }
                }
                if (saniye4 >= 60)
                {
                    dak4++;
                    saniye4 = saniye4 - 60;
                    if (saniye4 < 0)
                        saniye4 = 0;
                }
                if (dak4 >= 60)
                {
                    dak4 = dak4 - 60;
                    if (dak4 < 0)
                        dak4 = 0;
                    saat4++;
                }
            }

            txtBuProjedeToplamSure.Text = yazdirZaman(dak4, saat4, saniye4);

            #endregion Bu Projedeki Toplam
        }

        private void SummaryItemEkle(GridView grid)
        {
            if (grid == null)
                return;
            string tutarAlani = "OZEL_ALAN";
            Dictionary<string, GridColumn> columnListesi = new Dictionary<string, GridColumn>();
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(grid.Columns[i].FieldName))
                {
                    if (!columnListesi.ContainsKey((grid.Columns[i].FieldName)))
                        columnListesi.Add(grid.Columns[i].FieldName, grid.Columns[i]);
                }
            }
            grid.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]
                                           {
                                               new DevExpress.XtraGrid.GridGroupSummaryItem(
                                                   DevExpress.Data.SummaryItemType.Custom,
                                                   columnListesi[tutarAlani].FieldName, columnListesi[tutarAlani],
                                                   "{0:###,###,###,###,##0.00}")
                                           });
            grid.Columns[tutarAlani].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            grid.Columns[tutarAlani].SummaryItem.DisplayFormat = "{0:##:##:##}";
            grid.Columns[tutarAlani].ToolTip = "Toplam";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            saniye1++;
            saniye2++;
            saniye3++;
            saniye4++;
            foreach (var item in MyDataSource)
            {
                if (item.ID == 0)
                    item.TOPLAM_FIYAT += Convert.ToDecimal(miktar / 3600);
            }
            if (saniye == 60)
            {
                dak++;

                saniye = 0;
            }
            if (dak == 60)
            {
                dak = 0;
                dak1 = 0;
                saat1++;
                saat++;
            }
            if (saniye1 >= 60)
            {
                dak1++;
                saniye1 = saniye1 - 60;
                if (saniye1 < 0)
                    saniye1 = 0;
            }
            if (dak1 >= 60)
            {
                dak1 = dak1 - 60;
                if (dak1 < 0)
                    dak1 = 0;
                saat1++;
            }
            if (saniye2 >= 60)
            {
                dak2++;
                saniye2 = saniye2 - 60;
                if (saniye2 < 0)
                    saniye2 = 0;
            }
            if (dak2 >= 60)
            {
                dak2 = dak2 - 60;
                if (dak2 < 0)
                    dak2 = 0;
                saat2++;
            }
            if (saniye3 >= 60)
            {
                dak3++;
                saniye3 = saniye3 - 60;
                if (saniye3 < 0)
                    saniye3 = 0;
            }
            if (dak3 >= 60)
            {
                dak3 = dak1 - 60;
                if (dak3 < 0)
                    dak3 = 0;
                saat3++;
            }
            if (saniye4 >= 60)
            {
                dak4++;
                saniye4 = saniye4 - 60;
                if (saniye4 < 0)
                    saniye4 = 0;
            }
            if (dak4 >= 60)
            {
                dak4 = dak4 - 60;
                if (dak4 < 0)
                    dak4 = 0;
                saat4++;
            }

            yazdir();
            txtBuIstekiZaman.Text = yazdirZaman(dak1, saat1, saniye1);
            txtProjedeHarcanan.Text = yazdirZaman(dak2, saat2, saniye2);
            txtBuIsteHarcanantoplam.Text = yazdirZaman(dak3, saat3, saniye3);
            txtBuProjedeToplamSure.Text = yazdirZaman(dak4, saat4, saniye4);
        }

        private void UpdateClock(DateTime dt, IArcScale h, IArcScale m, IArcScale s)
        {
            int hour = dt.Hour <= 12 ? dt.Hour : dt.Hour - 12;
            int min = dt.Minute;
            int sec = dt.Second;
            h.Value = hour + (min) / 60.0f;
            m.Value = (min + (sec) / 60.0f) / 5f;
            s.Value = sec / 5.0f;
        }

        private void UpdateTime()
        {
            string time = DateTime.Now.ToLongTimeString();
            if (GetStringLength(time) > digitalGauge2.DigitCount) digitalGauge2.DigitCount = GetStringLength(time);
            digitalGauge2.Text = time;
        }

        private void yazdir()
        {
            if (saat < 10)
            {
                if (dak < 10)
                {
                    if (saniye < 10)
                        str = "0" + saat + ":0" + dak + ":0" + saniye;
                    else
                        str = "0" + saat + ":0" + dak + ":" + saniye;
                }
                else
                {
                    if (saniye < 10)
                        str = "0" + saat + ":" + dak + ":0" + saniye;
                    else str = "0" + saat + ":" + dak + ":" + saniye;
                }
            }
            else
            {
                if (saniye < 10)
                {
                    if (saniye < 10)
                        str = saat + ":0" + dak + ":0" + saniye;
                    else
                        str = saat + ":0" + dak + ":" + saniye;
                }
                else
                {
                    if (saniye < 10)
                        str = saat + ":" + dak + ":0" + saniye;
                    else str = saat + ":" + dak + ":" + saniye;
                }
            }

            digitalGauge1.Text = str;
            txtCalismaToplamZaman.Text = str;
        }

        private string yazdirZaman(int dk, int st, int sn)
        {
            string deger = "Zaman Bilgisi Bulunamadı";

            if (st < 10)
            {
                if (dk < 10)
                {
                    if (sn < 10)
                        deger = "0" + st + ":0" + dk + ":0" + sn;
                    else
                        deger = "0" + st + ":0" + dk + ":" + sn;
                }
                else
                {
                    if (sn < 10)
                        deger = "0" + st + ":" + dk + ":0" + sn;
                    else deger = "0" + st + ":" + dk + ":" + sn;
                }
            }
            else
            {
                if (sn < 10)
                {
                    if (sn < 10)
                        deger = st + ":0" + dk + ":0" + sn;
                    else
                        deger = st + ":0" + dk + ":" + sn;
                }
                else
                {
                    if (sn < 10)
                        deger = st + ":" + dk + ":0" + sn;
                    else deger = st + ":" + dk + ":" + sn;
                }
            }
            return deger;
        }

        private void gridView3_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
            GridView view = sender as GridView;
            if (Equals("SUREC_ACIKLAMA", item.FieldName))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    TimeSpan c = new TimeSpan();
                    if (sur != null && sur.SURE.HasValue)
                        c = TimeSpan.FromMilliseconds(sur.SURE.Value);
                    e.TotalValue = string.Format("{0:00}:{1:00}:{2:00}", c.Hours, c.Minutes, c.Seconds);
                }
            }
        }
    }
}