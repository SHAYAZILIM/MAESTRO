using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmBankaSubeSecForAltCari : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmBankaSubeSecForAltCari()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private AV001_TI_BIL_FOY gelenFoy = new AV001_TI_BIL_FOY();

        private TList<AV001_TDI_BIL_TEBLIGAT> gelenTebligat = new TList<AV001_TDI_BIL_TEBLIGAT>();

        private List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> MyDataBankaSube = new List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay>();

        private List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay> SecilenBankaSubeleri = new List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay>();
        
        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Tamam_Click += frmBankaSubeSecForAltCari_Button_Tamam_Click;
        }

        public void Show(TList<AV001_TDI_BIL_TEBLIGAT> tebligatHacizIhbarname, int mFoyId)
        {
            var mFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(mFoyId);

            //Hesap.Icra hy = new Hesap.Icra(mFoy);
            gelenTebligat = tebligatHacizIhbarname;
            gelenFoy = mFoy;
            this.Show();
        }

        private void BankaSubeDoldur()
        {
            if (BelgeUtil.Inits._BankaSubeGetirDetay == null)
                BelgeUtil.Inits._BankaSubeGetirDetay = BelgeUtil.Inits.context.VDI_KOD_BANKA_SUBE_Detays.ToList();
            MyDataBankaSube = BelgeUtil.Inits._BankaSubeGetirDetay;
            ucBankaSubeSec1.MyDataSource = MyDataBankaSube;
        }

        private void frmBankaSubeSecForAltCari_Button_Tamam_Click(object sender, EventArgs e)
        {
            //TAMAM da SEÇİLDİ
            SecilenBankaSubeleri = ucBankaSubeSec1.GetSelectedBankaSube(ucBankaSubeSec1.MyDataSource);

            if (SecilenBankaSubeleri.Count > 0)
            {
                CariAltaveTebMuhatapaKaydet();
            }
            else
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Seçilen Banka Şubesi Yok , Bütün Banka Şubelerini Getirmek istermisiniz(Bütün Bankalar ve Şubeleri) ?",
                        "Banka Şube ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (BelgeUtil.Inits._BankaSubeGetirDetay == null) BelgeUtil.Inits._BankaSubeGetirDetay = BelgeUtil.Inits.context.VDI_KOD_BANKA_SUBE_Detays.ToList();
                    SecilenBankaSubeleri = BelgeUtil.Inits._BankaSubeGetirDetay;
                    CariAltaveTebMuhatapaKaydet();
                }
                else
                {
                    SecilenBankaSubeleri = null;
                    this.Close();
                }
            }
            SecilenBankaSubeleri = null;
        }

        #region <TIO - 20090606>

        /*
         *
         * Seçilen banka şubelerinden CAri Alt  şubelerin bankalarından Cari kaydı oluşturuyoruz
         * seçilen verilerden 89/1 haciz ihbarnameli tebligat kaydı oluşturuyoruz
         * ve kayıt işlemini yapıyoruz.
         */

        /// <summary>
        /// Seçilen banka şubelerinden CAri Alt  şubelerin bankalarından Cari kaydı oluşturuyoruz
        /// seçilen verilerden 89/1 haciz ihbarnameli tebligat kaydı oluşturuyoruz
        /// ve kayıt işlemini yapıyoruz.
        /// </summary>

        private string CariAd;
        private bool cariVar;
        private int varOlanCari;

        private void CariAltaveTebMuhatapaKaydet()
        {
            frmTebligatKaydetVgrid frm = new frmTebligatKaydetVgrid();
            frm.MyDataSource = gelenTebligat;

            if (SecilenBankaSubeleri.Count < 0 || SecilenBankaSubeleri == null)
                return;

            int refSayim = 1;

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(gelenFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            TList<AV001_TDI_BIL_TEBLIGAT> tebligatList = new TList<AV001_TDI_BIL_TEBLIGAT>();

            foreach (AvukatProLib.Arama.VDI_KOD_BANKA_SUBE_Detay bankaSube in SecilenBankaSubeleri)
            {
                AV001_TDI_BIL_TEBLIGAT tebligat = gelenTebligat.AddNew();
                tebligat.ALT_TUR_ID = 94;
                tebligat.ADLI_BIRIM_ADLIYE_ID = gelenFoy.ADLI_BIRIM_ADLIYE_ID;
                tebligat.ADLI_BIRIM_GOREV_ID = gelenFoy.ADLI_BIRIM_GOREV_ID;
                tebligat.ADLI_BIRIM_NO_ID = gelenFoy.ADLI_BIRIM_NO_ID;
                tebligat.ANA_TUR_ID = 64;
                tebligat.GELEN_BELGE_MI = false;
                tebligat.ICRA_FOY_ID = gelenFoy.ID;
                tebligat.ICRA_FOY_NO = gelenFoy.FOY_NO_Sayi;
                tebligat.ICRA_ILK_TEBLIGAT_MI = false;
                tebligat.KONU_ID = 162;
                tebligat.TEBLIGAT_ESAS_NO = gelenFoy.ESAS_NO;

                //tebligat.TEBLIGAT_REFERANS_NO = AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit.TebligatReferansNoOlustur();//Haciz ihbarnameleri formunda verileceğinden kapatıldı. MB
                tebligat.HAZIRLAYAN_ID =
                    gelenFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].SORUMLU_AVUKAT_CARI_ID.Value;

                //Tebligat gideri ID 546
                tebligat.MUHASEBE_ALT_KATEGORI_ID = 546;
                tebligat.KLASOR_KODU = gelenFoy.KLASOR_KODU;
                refSayim++;

                if (BelgeUtil.Inits._per_CariGetir == null) BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                var item = BelgeUtil.Inits._per_CariGetir.FindAll(vi => vi.AD == bankaSube.BANKA).FirstOrDefault();
                if (item != null)
                {
                    cariVar = true;
                    varOlanCari = item.ID;
                    CariAd = item.AD;
                }
                else
                    cariVar = false;

                //Yukarıdaki şekilde yapıldı. MB
                //foreach (var item in BelgeUtil.Inits._per_CariGetir)
                //{
                //    if (item.AD == bankaSube.BANKA)
                //    {
                //        cariVar = true;
                //        varOlanCari = item.ID;
                //        CariAd = item.AD;
                //        break;
                //    }
                //    else
                //    {
                //        cariVar = false;
                //    }
                //}

                if (!cariVar)
                {
                    AV001_TDI_BIL_CARI cari = new AV001_TDI_BIL_CARI();
                    cari.AD = bankaSube.BANKA ?? "-";
                    cari.BANKA_ID = bankaSube.BANKA_ID;
                    cari.BANKA_SUBE_ID = bankaSube.ID;
                    cari.TEL_1 = bankaSube.TELEFON ?? "-";
                    cari.FAX = bankaSube.FAX ?? "-";
                    cari.FIRMA_MI = true;

                    //finans firma tür
                    cari.FIRMA_TUR_ID = 9;

                    //cari.KOD = DateTime.Now.Ticks.ToString() + DateTime.Now.Year.ToString() ?? "-";//Yanlış atama olduğundan kaldırıldı.

                    if (BelgeUtil.Inits._per_CariGetir == null)
                        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                    var kod = BelgeUtil.Inits._per_CariGetir.OrderByDescending(vi => vi.ID).FirstOrDefault().KOD;
                    cari.KOD = (Convert.ToInt32(kod) + 2).ToString();

                    //"BANKA "+bankaSube.KODU + TebRefNo ?? "-";
                    if (!string.IsNullOrEmpty(bankaSube.IL))
                    {
                        if (BelgeUtil.Inits.ILlistem == null)
                            BelgeUtil.Inits.ILlistem = DataRepository.per_TDI_KOD_ILProvider.GetAll();
                        var ilItem = BelgeUtil.Inits.ILlistem.SingleOrDefault(vi => vi.IL == bankaSube.IL.ToUpper());
                        if (item != null)
                            cari.IL_ID = item.ID;
                    }

                    if (!string.IsNullOrEmpty(bankaSube.ILCE))
                    {
                        var ilceItem = DataRepository.per_TDI_KOD_ILCEProvider.GetByIL_ID((int)cari.IL_ID).Find(vi => vi.ILCE == bankaSube.ILCE.ToUpper());
                        if (ilceItem != null) cari.ILCE_ID = ilceItem.ID;
                    }
                    cari.ADRES_1 = bankaSube.ADRES ?? "-";

                    //KOD da unquie index hatası
                    DataRepository.AV001_TDI_BIL_CARIProvider.Save(cari);

                    //DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari);//Gereksiz bulunduğundan kaldırıldı. MB
                    BelgeUtil.Inits._per_CariGetir.Add(BelgeUtil.Inits.GetCariViewItem(cari));
                    varOlanCari = cari.ID;
                    CariAd = cari.AD;
                }
                AV001_TDI_BIL_CARI_ALT alt_cari = new AV001_TDI_BIL_CARI_ALT();
                alt_cari.AD = CariAd + " Bankası " + bankaSube.SUBE + " Şubesi";
                alt_cari.ADRES_1 = bankaSube.ADRES ?? "-";
                alt_cari.TEL_1 = bankaSube.TELEFON ?? "-";
                alt_cari.FAX = bankaSube.FAX ?? "-";
                alt_cari.BANKA_ID = bankaSube.BANKA_ID;
                alt_cari.BANKA_SUBE_ID = bankaSube.ID;
                alt_cari.UST_CARI_ID = varOlanCari;

                if (!string.IsNullOrEmpty(bankaSube.IL))
                {
                    if (BelgeUtil.Inits.ILlistem == null)
                        BelgeUtil.Inits.ILlistem = DataRepository.per_TDI_KOD_ILProvider.GetAll();
                    var ilItem = BelgeUtil.Inits.ILlistem.Single(vi => vi.IL == bankaSube.IL.ToUpper());
                    if (ilItem != null)
                        alt_cari.IL_ID = BelgeUtil.Inits.ILlistem.Single(vi => vi.IL == bankaSube.IL.ToUpper()).ID;
                }

                if (!string.IsNullOrEmpty(bankaSube.ILCE))
                {
                    var ilceItem = DataRepository.per_TDI_KOD_ILCEProvider.GetByIL_ID((int)alt_cari.IL_ID).Find(vi => vi.ILCE == bankaSube.ILCE.ToUpper());
                    if (ilceItem != null) alt_cari.ILCE_ID = ilceItem.ID;
                }

                DataRepository.AV001_TDI_BIL_CARI_ALTProvider.Save(alt_cari);

                //Kullanılmadığı tespit edildi, o nedenle de kaldırıldı. Sorun çıkarsa açılacak. MB
                //if (BelgeUtil.Inits._CariAltGetir == null)
                //    BelgeUtil.Inits.CariAltRefersh();
                //else
                //    BelgeUtil.Inits._CariAltGetir.Add(alt_cari);

                AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();

                //mhtp.CARI_ALT_IDSource = alt_cari;
                mhtp.CARI_ALT_ID = alt_cari.ID;
                mhtp.MUHATAP_CARI_ID = varOlanCari;
                mhtp.ICRA_FOY_ID = gelenFoy.ID;
                mhtp.KLASOR_KODU = tebligat.KLASOR_KODU;
                mhtp.ODEME_TUTARI = gelenFoy.KALAN;
                mhtp.ODEME_TUTAR_DOVIZ_ID = gelenFoy.KALAN_DOVIZ_ID;

                //tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(mhtp);//yukarıda verildiğinden kapatıldı. MB

                //if (gelenFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                //    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(gelenFoy, false, DeepLoadType.IncludeChildren,
                //                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                for (int i = 0; i < gelenFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(vi => vi.TAKIP_EDEN_MI).Count; i++)
                {
                    //if (gelenFoy.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                    //{
                    AV001_TDI_BIL_TEBLIGAT_YAPAN ypn = tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();

                    //... FOY TARAFINDAN
                    ypn.ICRA_FOY_ID = gelenFoy.ID;
                    ypn.TEBLIGAT_ID = tebligat.ID;
                    ypn.YAPAN_CARI_ID = gelenFoy.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    ypn.KLASOR_KODU = tebligat.KLASOR_KODU;

                    //tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(ypn);//yukarıda verildiğinden kapatıldı. MB
                    //}
                }

                tebligatList.Add(tebligat);//frmHacizIhbarnameleri Show metoduna parametre olarak gönderilecek. MB

                //Kayıt işlemi frmhacizIhbarnameleri formunda yapılacağından bu blok kaldırıldı. MB
                //TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                //try
                //{
                //    tran.BeginTransaction();

                //    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, tebligat, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>)/*, typeof(TList<AV001_TDI_BIL_CARI>)Gerek görülmedi.MB*/);

                //    //DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepSave(tran, tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_ALT>));//Gerek görülmedi. MB

                //    tran.Commit();
                //    kayitBasarili = true;
                //}
                //catch (Exception ex)
                //{
                //    if (tran.IsOpen)
                //        tran.Rollback();

                //    kayitBasarili = false;
                //    BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Kayit, BelgeUtil.Bilesen.Tebligat);
                //}
            }

            IcraTakipForms.frmHacizIhbarnameleri frmIhbarname = new AdimAdimDavaKaydi.IcraTakipForms.frmHacizIhbarnameleri();
            frmIhbarname.Show(gelenFoy, tebligatList, AvukatProLib.Extras.IhbarnameTip.BirinciHacizIhbarnamesi);
            ucBankaSubeSec1.MyDataSource.FindAll(vi => vi.IsSelected).ForEach(item => item.IsSelected = false);

            //Kayıt işlemi frmhacizIhbarnameleri formunda yapılacağından bu blok kaldırıldı. MB
            //if (kayitBasarili)
            //{
            //    ucBankaSubeSec1.MyDataSource.FindAll(vi => vi.IsSelected).ForEach(item => item.IsSelected = false);

            //    DialogResult dr = XtraMessageBox.Show("Seçilenlerin herbiri için 89/1 Haciz İhbarnamesi Kayıtları Oluşturulmuştur.", "İhbarname", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    this.Close();
            //}
            //else
            //{
            //    XtraMessageBox.Show("89/1 Haciz İhbarnamesi Oluşturulurken Hata ile karşılaşıldı.");
            //}
        }

        #endregion <TIO - 20090606>

        private void frmBankaSubeSecForAltCari_Load(object sender, EventArgs e)
        {
            //LOAD
            BankaSubeDoldur();
        }
    }
}