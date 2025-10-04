using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmDavaliOdemeleri : Util.BaseClasses.AvpXtraForm
    {
        public rFrmDavaliOdemeleri()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private TList<AV001_TD_BIL_BORCLU_ODEME> addNewList;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_BORCLU_ODEME> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (AddNewList == null)
                            AddNewList = new TList<AV001_TD_BIL_BORCLU_ODEME>();

                        //ucDavaliOdemeleri1.MyDataSource = AddNewList;
                        if (AddNewList.Count < 1)
                        {
                            AddNewList.AddingNew += Odeme_AddingNew;
                            AddNewList.AddNew();
                        }
                        ucDavaliOdemeleri1.MyDataSource = AddNewList;
                        ucDavaliOdemeleri1.MyFoy = value;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;

            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                    "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEvents()
        {
            EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void Odeme_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Count < 1)
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));

            AV001_TD_BIL_BORCLU_ODEME DOdeme = new AV001_TD_BIL_BORCLU_ODEME();
            DOdeme.ODEME_TARIHI = DateTime.Now.Date;
            DOdeme.ODEYEN_CARI_ID = MyFoy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(t => t.TARAF_KODU == 3)[0].CARI_ID;
            DOdeme.BORCLU_ADINA_ODEYEN_CARI_ID = MyFoy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(t => t.TARAF_KODU == 1)[0].CARI_ID;
            DOdeme.ODENEN_CARI_ID = MyFoy.AV001_TD_BIL_FOY_TARAFCollection.FindAll(t => t.TARAF_KODU == 1)[0].CARI_ID;
            DOdeme.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            DOdeme.KAYIT_TARIHI = DateTime.Now;
            DOdeme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            DOdeme.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            DOdeme.KONTROL_NE_ZAMAN = DateTime.Now;
            DOdeme.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            DOdeme.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            DOdeme.ODEME_TIP_ID = 1;
            DOdeme.ODEME_YER_ID = 3;
            e.NewObject = DOdeme;
        }

        private bool Save()
        {
            bool sonuc = false;
            addNewList.ForEach(delegate(AV001_TD_BIL_BORCLU_ODEME o) { o.DAVA_FOY_ID = MyFoy.ID; });
            MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection.AddRange(AddNewList);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            if (MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection.Count > 0)
            {
                foreach (var odeme in MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection)
                    odeme.DAVA_FOY_ID = MyFoy.ID;
            }

            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TD_BIL_BORCLU_ODEMEProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection.Remove(AddNewList[i]);
                }
            }

            #region Foy muhasebe üretimi kapatýldý!

            //if (MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection.Count > 0)
            //{
            //    foreach (var borcluOdeme in MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection)
            //    {
            //MuhasebeAraclari.SetMuhasebeVeDetayByDavaBorcluOdeme(borcluOdeme.ID);
            //    }
            //}

            #endregion Foy muhasebe üretimi kapatýldý!

            #region Masraf Avans üretimi kapatýldý!

            //TList<AV001_TDI_BIL_MASRAF_AVANS> masrafAvansListesi = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
            //foreach (var odeme in MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection)
            //{
            //    AV001_TDI_BIL_MASRAF_AVANS ma = new AV001_TDI_BIL_MASRAF_AVANS();
            //    // Masraf Avansýn alanlarý mevcut bilgilerden doldurulacak
            //    ma.CARI_ID = (int)odeme.ODEYEN_CARI_ID;
            //    ma.DAVA_FOY_ID = MyFoy.ID;
            //    //ma.ICRA_FOY_NO = MyFoy.FOY_NO; //Alanýn Tipi Deðiþtirilecek
            //    ma.MANUEL_KAYIT_MI = false;
            //    ma.MASRAF_AVANS_TIP = (int)MasrafAvansTip.Masraf;

            //    ma.ACIKLAMA = String.Format("{0} Tarihinde {1} tarafýndan ödenen paranýn karþýlýðý üretilmiþtir", odeme.ODEME_TARIHI, Inits.CariIsmiGetir((int)odeme.ODEYEN_CARI_ID)); //Açýklama Üretilecek, þu tarihte borçlu tarafýndan ödenen paranýn karþýlýðý üretilmiþtir
            //    ma.BORCLU_CARI_ID = odeme.ODEYEN_CARI_ID;
            //    ma.CARI_HESAP_HEDEF_TIP = (int)Modul.Icra; // icra

            //    var maDetay = ma.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.AddNew();
            //    //detay ýn bilgileri mevcut ödemeden doldurulacak
            //    //odeme yi borçlu yapýyorsa bu durumdan avukat (borçlu) Müvekkil (Alacaklý)

            //    maDetay.ACIKLAMA = ma.ACIKLAMA;  // Açýklama Üretilecek,
            //    maDetay.ADET = 1;
            //    maDetay.BIRIM_FIYAT = odeme.ODEME_MIKTAR;
            //    maDetay.BIRIM_FIYAT_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID;
            //    maDetay.TOPLAM_TUTAR = odeme.ODEME_MIKTAR;
            //    maDetay.TOPLAM_TUTAR_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1;
            //    maDetay.GENEL_TOPLAM = odeme.ODEME_MIKTAR;
            //    maDetay.GENEL_TOPLAM_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID ?? 1;

            //    maDetay.BORC_ALACAK_ID = (int)BorcAlacak.Borc;  //Testpit Edilecek, -- Alacak

            //    maDetay.HAREKET_ANA_KATEGORI_ID = (int)HareketAnaKategori.Odeme;
            //    maDetay.HAREKET_ALT_KATEGORI_ID = (int)HareketAltKategori.BorcluOdemesi;

            //    ///Katman Üzerinden verildiði Düþünülüyor
            //    //maDetay.MA_ICRA_FOY_ID = MyFoy.ID;
            //    //maDetay.MA_REFERANS_NO = ma.REFERANS_NO;

            //    //maDetay.MUVEKKIL_CARI_ID =  ma.CARI_ID; //Dosyanýn Müvekkillerine
            //    maDetay.ODEME_TIP_ID = odeme.ODEME_TIP_ID;
            //    maDetay.ONAY_DURUM = 1;
            //    maDetay.ONAY_NO = "1";
            //    maDetay.ONAY_TARIHI = odeme.ODEME_TARIHI;
            //    maDetay.Onaylandi = true;
            //    maDetay.MuhasebelestirilecekMi = true;
            //    maDetay.TARIH = DateTime.Now;
            //    maDetay.TUM_MUVEKKILLERE_PAYLASTIR = true;
            //    maDetay.INCELENDI = true;

            //    masrafAvansListesi.Add(ma);
            //}
            //if (masrafAvansListesi.Count > 0)
            //{
            //    tran.BeginTransaction();
            //    try
            //    {
            //        //AV001_TDI_BIL_MASRAF_AVANS_DETAY ma;
            //        //DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, MyFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
            //        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, masrafAvansListesi);
            //        tran.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        if (tran.IsOpen)
            //            tran.Rollback();

            //        BelgeUtil.ErrorHandler.Catch(this, ex);
            //    }
            //    //foreach (var ma in masrafAvansListesi)
            //    //{
            //    //    MuhasebeHelper.MasrafAvansToKasa(ma);
            //    //}
            //}

            #endregion Masraf Avans üretimi kapatýldý!

            #region Cari hesap üretimi açýldý

            if (addNewList.Count > 0)
            {
                foreach (var davaliOdeme in addNewList)
                {
                    MuhasebeAraclari.SetCariHesapByDavaliBorcluOdeme(davaliOdeme.ID);
                }
            }

            #endregion Cari hesap üretimi açýldý

            return sonuc;
        }
    }
}