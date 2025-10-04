using System;
using System.Collections.Generic;
using System.ComponentModel;

//using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIcraVekaletSozlesmesi : AvpXUserControl
    {
        private AV001_TI_BIL_VEKALET_SOZLESME _MyDataSource;

        private AV001_TI_BIL_FOY myIcraFoy;

        public ucIcraVekaletSozlesmesi()
        {
            //if (DesignMode)
            InitializeComponent();
            IsLoaded = true;
            this.Load += ucIcraVekaletSozlesmesi_Load;
        }

        [Browsable(false)]
        public AV001_TI_BIL_VEKALET_SOZLESME MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                {
                    //BindData();
                    BindVekaletSozlesmeDetayGrid(_MyDataSource);
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (value != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myIcraFoy, true, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_VEKALET_SOZLESME));
                    MyDataSource = myIcraFoy.VEKALET_SOZLESME_IDSource;
                    if (lueSozlesmeKategori != null)
                        lueSozlesmeKategori.EditValue = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetByID((int)myIcraFoy.VEKALET_SOZLESME_ID).SOZLESME_KATEGORI_ID;

                    //BindData();
                }
            }
        }

        //public void BindData()
        //{
        //if (!bckWorker.IsBusy)
        //{
        //    bckWorker.DoWork += bckWorker_DoWork;
        //    bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
        //    bckWorker.RunWorkerAsync();
        //}

        //if (IsLoaded)
        //{
        //}
        //}

        //private BackgroundWorker bckWorker = new BackgroundWorker();

        //private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_VEKALET_SOZLESME));
        //    MyDataSource = MyIcraFoy.VEKALET_SOZLESME_IDSource;
        //}

        //private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (IsLoaded)
        //    {
        //        if (MyIcraFoy.VEKALET_SOZLESME_IDSource == null)
        //            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, true, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_VEKALET_SOZLESME));
        //        MyDataSource = MyIcraFoy.VEKALET_SOZLESME_IDSource;
        //    }
        //}

        #region <TS-20111117> Load

        private bool initsFilled;

        private void BindVekaletSozlesmeDetayGrid(AV001_TI_BIL_VEKALET_SOZLESME sozlesme)
        {
            if (sozlesme != null)
            {
                DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
                if (!sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Exists(vi => vi.VEKALET_SOZLESME_ID == sozlesme.ID))
                {
                    var detay = sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Where(vi => vi.VEKALET_SOZLESME_ID == sozlesme.ID);
                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> altKategoriler =
                        DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(17);

                    #region <MB-20100803> Alt Kategorilerin Sıralanması

                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> sortedAltKategoriler =
                        new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
                    myList.ForEach(item =>
                    {
                        TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI tmpItem =
                            altKategoriler.Find(kat => kat.ALT_KATEGORI == item);
                        if (tmpItem != null) sortedAltKategoriler.Add(tmpItem);
                    }
                        );

                    #endregion <MB-20100803> Alt Kategorilerin Sıralanması

                    var kayitlar = sortedAltKategoriler.Select(vi => new AV001_TI_BIL_VEKALET_SOZLESME_DETAY
                    {
                        VEKALET_SOZLESME_ID = sozlesme.ID,
                        MUHASEBE_ALT_TUR_ID = vi.ID,
                        KAYIT_TARIHI = DateTime.Now,
                        KONTROL_NE_ZAMAN = DateTime.Now,
                        KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID,
                        KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon,
                        STAMP = AvukatProLib.Kimlik.DefaultStamp,
                    }).ToList();

                    sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.Clear();
                    sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection.AddRange(kayitlar);
                    gcSozlesmeDetay.DataSource = sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection;

                    DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.Save(sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection);
                }
                else
                    gcSozlesmeDetay.DataSource = sozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection;
            }
        }

        private void InitsDoldur()
        {
            if (!initsFilled)
            {
                BelgeUtil.Inits.DovizTipGetir(lueSabitTutarDoviz);
                BelgeUtil.Inits.SozlesmeKategorisiGetir(lueSozlesmeKategori.Properties);
                BelgeUtil.Inits.MuhasebeHareketAltKategori(rlueKategoriID);

                initsFilled = true;
            }
        }

        private void ucIcraVekaletSozlesmesi_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            //if (!IsLoaded)
            //    InitializeComponent();

            InitsDoldur();

            //BindData();

            SetParameters(true, 85);

            //if (MyIcraFoy != null)
            //{
            //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_VEKALET_SOZLESME));
            //    if (MyIcraFoy.VEKALET_SOZLESME_IDSource == null)
            //        MyIcraFoy.VEKALET_SOZLESME_IDSource = new AV001_TI_BIL_VEKALET_SOZLESME();
            //    bndVekaletSozlesme.DataSource = MyIcraFoy.VEKALET_SOZLESME_IDSource;
            //}

            //BindVekaletSozlesmeDetayGrid(bndVekaletSozlesme.Current as AV001_TI_BIL_VEKALET_SOZLESME);
        }

        #region <TS-20111117> Detay Gridi

        //Detay gridinin headerlarının Vertical görünmesini sağlıyor.
        private bool vertical;


        private void SetParameters(bool vertical, int h)
        {
            this.vertical = vertical;
            gvSozlesmeDetay.ColumnPanelRowHeight = h;
        }

        #endregion <TS-20111117> Detay Gridi

        #region <TS-20111117> Alt Kategorilerin Sırası

        private List<string> myList = new[]
                                          {
                                              "ASIL ALACAK",
                                              "İŞLEMİŞ FAİZ",
                                              "BSMV TAKİP ÖNCESİ",
                                              "KKDF TAKİP ÖNCESİ",
                                              "ÖİV TAKİP ÖNCESİ",
                                              "KDV TAKİP ÖNCESİ",
                                              "İHTİYATİ HACİZ VEKALET ÜCRETİ",
                                              "İHTİYATİ HACİZ GİDERİ",
                                              "İHTİYATİ TEDBİR VEKALET ÜCRETİ",
                                              "İHTİYATİ TEDBİR GİDERİ",
                                              "İLAM VEKALET ÜCRETİ",
                                              "İLAM TEBLİĞ GİDERİ",
                                              "İLAM İNKAR TAZMİNATI",
                                              "İLAM GİDER",
                                              "İLAM YARGILAMA GİDERİ",
                                              "İLAM BAKİYE KARAR HARCI",
                                              "ÇEK TAZMİNATI",
                                              "YARGITAY ONAMA HARCI",
                                              "KOMİSYON",
                                              "ÖZEL TUTAR 1",
                                              "ÖZEL TUTAR 2",
                                              "ÖZEL TUTAR 3",
                                              "ÖZEL TAZMİNAT",
                                              "PROTESTO GİDERİ",
                                              "İHTAR GİDERİ",
                                              "DAMGA PULU",
                                              "SONRAKİ FAİZ",
                                              "BSMV TAKİP SONRASI",
                                              "KDV TAKİP SONRASI",
                                              "ÖİV TAKİP SONRASI",
                                              "SONRAKİ TAZMİNATLAR",
                                              "BİRİKMİŞ NAFAKALAR",
                                              "TAKİP VEKALET ÜCRETİ",
                                              "TAHLİYE VEKALET ÜCRETİ",
                                              "DAVA VEKALET ÜCRETİ",
                                              "TAHLİYE DAVASI VEKALET ÜCRETİ",
                                              "İCRA İNKAR TAZMİNATI",
                                              "DAVA İNKAR TAZMİNATI",
                                              "TEBLİGAT GİDERİ",
                                              "DİĞER GİDER",
                                              "DAVA GİDERİ",
                                              "TAHSİL HARCI",
                                              "TAHLİYE DAVASI GİDERİ",
                                              "KALAN TAHSİL HARCI",
                                              "MENKUL TESLİM HARCI",
                                              "CEZAEVİ HARCI",
                                              "TAHLİYE HARCI"
                                          }.ToList();

        #endregion <TS-20111117> Alt Kategorilerin Sırası

        #endregion <TS-20111117> Load

        #region <TS-20111117> Kayıt İşlemi

        private void Kaydet()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = bndVekaletSozlesme.Current as AV001_TI_BIL_VEKALET_SOZLESME;

                if (sbtnKaydet.Tag == "yeni")
                {
                    TDI_KOD_SOZLESME_KATEGORILERI kategori = SozlesmeKategorisiOlustur();
                    vekaletSozlesme.SOZLESME_KATEGORI_ID = kategori.ID;
                    vekaletSozlesme.SOZLESME_KATEGORI = kategori.AD;
                }

                vekaletSozlesme.FAIZ_BASLANGIC_TARIHI = DateTime.Now;
                vekaletSozlesme.SOZLESME_TARIHI = DateTime.Now;
                vekaletSozlesme.KAYIT_TARIHI = DateTime.Now;
                vekaletSozlesme.KONTROL_NE_ZAMAN = DateTime.Now;
                vekaletSozlesme.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
                vekaletSozlesme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                vekaletSozlesme.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                if (vekaletSozlesme.DEFAULT_SOZLESME_MI == true)
                {
                    if (XtraMessageBox.Show("Varsayılan sözleşmemi alanını işaretlediniz.\nÜzerinde bulunduğunuz bu sözleşme bundan sonra kaydedilecek tüm icra dosyalarında seçili olarak gelecektir.\nEminmisiniz ?", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Information).Equals(DialogResult.OK))
                    {
                        tran.BeginTransaction();
                        TList<AV001_TI_BIL_VEKALET_SOZLESME> sozlesmeler = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetAll();
                        foreach (var sozlesme in sozlesmeler)
                        {
                            sozlesme.DEFAULT_SOZLESME_MI = false;
                        }
                        DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.Update(tran, sozlesmeler);
                        vekaletSozlesme.DEFAULT_SOZLESME_MI = true;

                        if (sbtnKaydet.Tag == "yeni")
                        {
                            DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.Save(tran, sozlesmeler);
                            DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepSave(tran, vekaletSozlesme, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
                        }
                        else
                        {
                            DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.Update(tran, vekaletSozlesme);
                            DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.Update(tran, vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection);
                        }
                        tran.Commit();
                    }
                }
                else
                {
                    tran.BeginTransaction();

                    if (vekaletSozlesme.IsNew)
                    {
                        DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepSave(tran, vekaletSozlesme, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
                    }
                    else
                    {
                        DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.Update(tran, vekaletSozlesme);
                        DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.Update(tran, vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection);
                    }
                    tran.Commit();
                }
                BelgeUtil.Inits.SozlesmeKategorisiGetir(lueSozlesmeKategori.Properties);
                lueSozlesmeKategori.EditValue = vekaletSozlesme.SOZLESME_KATEGORI_ID;
                MyIcraFoy.VEKALET_SOZLESME_ID = vekaletSozlesme.ID;
                DataRepository.AV001_TI_BIL_FOYProvider.Save(MyIcraFoy);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                lueSozlesmeKategori.EditValueChanged += null;
                if (sbtnKaydet.Tag == "yeni")
                {
                    try
                    {
                        Kaydet();
                        lcYeniSozlesme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lcItemSozlesmeKategori.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lueSozlesmeKategori.Enabled = true;
                        lcSozlesmeAdi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        sbtnKaydet.Tag = "guncelle";
                        XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Kayıt işlemi sırasında bir hata oluştu.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (sbtnKaydet.Tag == "guncelle")
                {
                    if (XtraMessageBox.Show("Dikkat bu vekalet ücret sözleşmesi başka icra dosyalarındada kullanılıyor olabilir,\nyapacağınız değişiklikler bu sözleşmenin kullanıldığı diğer icra dosyalarının müvekkil hesaplarınıda etkileyecektir.\nIşleme devam etmek istediğinizde eminmisiniz?", "UYARI", MessageBoxButtons.OKCancel,
                                       MessageBoxIcon.Information).Equals(DialogResult.OK))
                    {
                        try
                        {
                            Kaydet();
                            XtraMessageBox.Show("Güncelleme işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Güncelleme işlemi sırasında bir hata oluştu..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                lueSozlesmeKategori.EditValueChanged += new EventHandler(lueSozlesmeKategori_EditValueChanged);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Güncelleme işlemi gerçekleştirilemedi!", "HATA", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Error);
            }
        }

        #endregion <TS-20111117> Kayıt İşlemi

        private void btnSozlesmeEkle_Click(object sender, EventArgs e)
        {
            var mbox = XtraMessageBox.Show("Açık olan sözleşmedeki değerler yeni sözleşmeye aktarılsın mı?", "Değerler taşınsın mı?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (mbox.Equals(DialogResult.Yes) || mbox.Equals(DialogResult.No))
            {
                sbtnKaydet.Tag = "yeni";
                btnSozlesmeEkle.Visible = false;
                lcYeniSozlesme.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lcSozlesmeAdi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcItemSozlesmeKategori.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lueSozlesmeKategori.Enabled = false;

                if (mbox.Equals(DialogResult.No))
                    formuTemizle();
            }

            else
            {
            }
        }

        private void dtSozlesmeTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtSozlesmeTarih.EditValue.ToString()))
                return;

            (bndVekaletSozlesme.Current as AV001_TD_BIL_VEKALET_SOZLESME).SOZLESME_TARIHI = (DateTime)dtSozlesmeTarih.EditValue;
        }

        private void formuTemizle()
        {
            AV001_TI_BIL_VEKALET_SOZLESME sozlesme = new AV001_TI_BIL_VEKALET_SOZLESME();
            sozlesme.ODEMELERDEN_ORANSAL_KESILSIN = false;
            sozlesme.SOZLESME_TARIHI = DateTime.Now.Date;
            sozlesme.SABIT_TUTAR_DOVIZ_ID = null;
            bndVekaletSozlesme.Clear();
            bndVekaletSozlesme.Add(sozlesme);

            for (int rowHandle = 0; rowHandle < gvSozlesmeDetay.RowCount; rowHandle++)
            {
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colHACIZ_ONCESI_INFAZ, 0);
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colSATIS_ONCESI_INFAZ, 0);
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colSATIS_SONRASI_INFAZ, 0);
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colFERAGAT, 0);
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colDUSME, 0);
                gvSozlesmeDetay.SetRowCellValue(rowHandle, colACIZ, 0);
            }
        }

        private void lueSozlesmeKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueSozlesmeKategori.EditValue.ToString()))
                return;
            AV001_TI_BIL_VEKALET_SOZLESME seciliSozlesme = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetBySOZLESME_KATEGORI_ID((int?)lueSozlesmeKategori.EditValue).FirstOrDefault();

            if (seciliSozlesme != null)
            {
                BindVekaletSozlesmeDetayGrid(seciliSozlesme);
                bndVekaletSozlesme.Clear();
                bndVekaletSozlesme.Add(seciliSozlesme);
            }
        }

        private TDI_KOD_SOZLESME_KATEGORILERI SozlesmeKategorisiOlustur()
        {
            TDI_KOD_SOZLESME_KATEGORILERI kategori = new TDI_KOD_SOZLESME_KATEGORILERI();
            kategori.AD = txtSozlesmeAdi.Text;
            kategori.ADMIN_KAYIT_MI = false;
            kategori.KONTROL_NE_ZAMAN = DateTime.Now;
            kategori.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            kategori.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            kategori.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            kategori.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;
            try
            { DataRepository.TDI_KOD_SOZLESME_KATEGORILERIProvider.Save(kategori); }
            catch 
            { XtraMessageBox.Show("Bu isimde bir sözleşme mevcut. Lüften başka bir sözleşme ismi giriniz!"); }
            return kategori;
        }
    }
}