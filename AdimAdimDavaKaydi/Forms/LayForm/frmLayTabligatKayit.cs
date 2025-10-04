using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Belge.Util;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.UserControls;
using System.IO;

namespace AdimAdimDavaKaydi.Forms.LayForm
{
    public partial class frmLayTabligatKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Global Properties

        #endregion Global Properties

        #region Fields

        public bool Duzenlememi = false;
        public bool ihbarname;
        public bool muzekkre;

        private int _ModulID = 10;

        //Düzenleme işlemi için eklenmiştir.
        private AV001_TDI_BIL_TEBLIGAT _MyDataSource;

        private int _MyDavaFoyID;
        private int _MyHazirlikFoyID;
        private int _MyIcraFoyID;
        private int _MySozlesmeFoyID;
        private IEntity _OpenedRecord;
        private CariStatu csDavaEden;
        private CariStatu csDavaEdilen;

        //İş Kaydedilsin Checked ise O tebligata iş kaydı üretilmesi sağlanıyor.
        private bool isLookUpTaraflarFill;

        #endregion Fields

        #region Constructors

        public frmLayTabligatKayit()
        {
            InitializeComponent();

            this.bndTebligat.AddingNew += bndTebligat_AddingNew;
            bndTebligat.CurrentChanged += bndTebligat_CurrentChanged;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EvrakKayitEventArgs> YenileKayit;

        #endregion Events

        #region Properties

        public int ModulID
        {
            get { return _ModulID; }
            set { _ModulID = value; }
        }

        public AV001_TDI_BIL_TEBLIGAT MyDataSource
        {
            get
            {
                return _MyDataSource;
            }
            set
            {
                _MyDataSource = value;
                if (value.ID != 0)
                {
                    value.STAMP = 1;
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Save(value);
                }
                bndTebligat.DataSource = value;
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                for (int x = 0; x < value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; x++)
                {
                    try
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.Clear();
                        cn.AddParams("@TEBLIGAT_ID", value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].TEBLIGAT_ID);
                        cn.AddParams("@MUHATAP_CARI_ID", value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].MUHATAP_CARI_ID);

                        value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].PTT_BARKOD_NO = cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();

                        value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].TEBLIGAT_ADRESI = cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();
                    }
                    catch { ;}
                }

                gcMuhatap.DataSource = value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;

                gcGonderen.DataSource = value.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;

                (gcMuhatap.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>).AddingNew += AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                (gcGonderen.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>).AddingNew += AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get;
            set;
        }

        public int MyDavaFoyID
        {
            get { return _MyDavaFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                    lueModul.EditValue = (int)Modul.Dava;
                    lueDosya.EditValue = value;
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get;
            set;
        }

        public int MyHazirlikFoyID
        {
            get { return _MyHazirlikFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                    lueModul.EditValue = (int)Modul.Sorusturma;
                    lueDosya.EditValue = value;
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get;
            set;
        }

        public int MyIcraFoyID
        {
            get { return _MyIcraFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                    lueModul.EditValue = (int)Modul.Icra;
                    lueDosya.EditValue = value;
                }
            }
        }

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get;
            set;
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get;
            set;
        }

        public int MySozlesmeFoyID
        {
            get { return _MySozlesmeFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                    lueModul.EditValue = (int)Modul.Sozlesme;
                    lueDosya.EditValue = value;
                }
            }
        }

        [Browsable(false)]
        public IEntity OpenedRecord
        {
            get { return _OpenedRecord; }
            set { _OpenedRecord = value; }
        }

        #endregion Properties

        #region Methods

        public static string TebligatReferansNoOlustur()
        {
            var refNo = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "SELECT TOP(1)TEBLIGAT_REFERANS_NO FROM AV001_TDI_BIL_TEBLIGAT ORDER BY ID DESC");
            if (refNo != null)
            {
                if (refNo.ToString().Contains("~"))
                {
                    string[] dizi = refNo.ToString().Split('~');
                    refNo = dizi[1];
                    int refNoSayi = Convert.ToInt32(refNo);
                    return "E" + "-" + DateTime.Today.Year + "~" + (++refNoSayi).ToString();
                }
                else
                {
                    string strRefNo = "E-" + DateTime.Today.Year.ToString() + "~10000";
                    return strRefNo;
                }
            }
            else
            {
                string strRefNo = "E-" + DateTime.Today.Year.ToString() + "~10000";
                return strRefNo;
            }
        }

        public void DefaultAlanlarMuhatap(AV001_TDI_BIL_TEBLIGAT_MUHATAP trf)
        {
            trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            trf.KONTROL_NE_ZAMAN = DateTime.Today;
            trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            trf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
        }

        public void DefaultAlanlarYapan(AV001_TDI_BIL_TEBLIGAT_YAPAN trf)
        {
            trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            trf.KONTROL_NE_ZAMAN = DateTime.Today;
            trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            trf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
        }

        public void IsKaydet()
        {
            if (bndTebligat.Current == null)
                return;
            AV001_TDI_BIL_TEBLIGAT tebligat = bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT;

            AV001_TDI_BIL_IS ds = new AV001_TDI_BIL_IS();
            TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();
            ds.ACIKLAMA = tebligat.ACIKLAMA;
            ds.ADLI_BIRIM_ADLIYE_ID = tebligat.ADLI_BIRIM_ADLIYE_ID;
            ds.ADLI_BIRIM_GOREV_ID = tebligat.ADLI_BIRIM_GOREV_ID;
            ds.ADLI_BIRIM_NO_ID = tebligat.ADLI_BIRIM_NO_ID;
            ds.AJANDADA_GORUNSUN_MU = true;
            ds.BASLANGIC_TARIHI = bASLANGIC_TARIHIDateEdit.DateTime;
            ds.ESAS_NO = tebligat.TEBLIGAT_ESAS_NO;
            ds.KONU = string.Format("{0} nolu Tebligat kaydı", tebligat.TEBLIGAT_REFERANS_NO);
            ds.ONGORULEN_BITIS_TARIHI = oNGORULEN_BITIS_TARIHIDateEdit.DateTime;

            //bASLANGIC_TARIHIDateEdit.EditValue = tebligat.KAYIT_TARIHI;
            //oNGORULEN_BITIS_TARIHIDateEdit.EditValue = tebligat.KAYIT_TARIHI.AddDays(1);
            //ds.REFERANS_NO = tebligat.TEBLIGAT_REFERANS_NO;
            ds.REFERANS_NO = "Y-" + DateTime.Now.Year + "~" + DateTime.Now.Ticks;
            ds.DURUM = false;
            ds.BITIS_TARIHI = null;
            ds.ONCELIK_ID = 2; //Acil
            ds.KATEGORI_ID = 612;//TEBLİGAT İŞLERİ
            ds.STAMP = 0;
            if (gcIsTaraflari.DataSource != null)
                ds.AV001_TDI_BIL_IS_TARAFCollection = gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>;
            
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            if (isler != null && isler.Count > 0)
            {
                ds.TEKRARLAMA_BILGISI = isler[0].TEKRARLAMA_BILGISI;
                ds.HATIRLATMA_BILGISI = isler[0].HATIRLATMA_BILGISI;
            }

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            if (OpenedRecord != null)
            {
                switch (OpenedRecord.TableName)
                {
                    case "AV001_TI_BIL_FOY":
                        NN_IS_ICRA_FOY isIcra = new NN_IS_ICRA_FOY();
                        isIcra.ICRA_FOY_ID = (OpenedRecord as AV001_TI_BIL_FOY).ID;
                        isIcra.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(isIcra);
                        break;

                    case "AV001_TD_BIL_FOY":
                        NN_IS_DAVA_FOY isDava = new NN_IS_DAVA_FOY();
                        isDava.DAVA_FOY_ID = (OpenedRecord as AV001_TD_BIL_FOY).ID;
                        isDava.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(isDava);
                        break;
                    case "AV001_TD_BIL_HAZIRLIK":
                        NN_IS_HAZIRLIK isHazirlik = new NN_IS_HAZIRLIK();
                        isHazirlik.HAZIRLIK_ID = (OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                        isHazirlik.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(isHazirlik);
                        break;

                    case "AV001_TDI_BIL_SOZLESME":
                        NN_IS_SOZLESME isSozlesme = new NN_IS_SOZLESME();
                        isSozlesme.SOZLESME_ID = (OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                        isSozlesme.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(isSozlesme);
                        break;

                    default:
                        break;
                }
            }

            //IEntity MyRecord;
            NNProcess.SaveIs(ds, (IEntity)bndTebligat.Current);

            foreach (var item in ds.AV001_TDI_BIL_IS_TARAFCollection)
            {
                item.IS_ID = ds.ID;
            }
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(ds.AV001_TDI_BIL_IS_TARAFCollection);

            if (ds.AV001_TDI_BIL_IS_TARAFCollection != null && ds.AV001_TDI_BIL_IS_TARAFCollection.Count >= 0)
            {
                for (int i = 0; i < ds.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
                {
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(ds, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<NN_IS_CARI>));
                    NN_IS_CARI isCari = new NN_IS_CARI();
                    isCari.IS_ID = ds.ID;
                    if (ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID > 0)
                    {
                        isCari.CARI_ID = ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID.Value;

                        if (
                            ds.NN_IS_CARICollection.Exists(
                                delegate(NN_IS_CARI tarf)
                                {
                                    return tarf.CARI_ID == isCari.CARI_ID; // && tarf.IS_ID==isCari.IS_ID;
                                })) continue;
                        AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(isCari);
                    }
                }
            }
            DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(ds, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_HATIRLAT>), typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));

            #region Ekran Hatırlatması

            if (chkEkran.Checked)
            {
                AV001_TDI_BIL_HATIRLAT ekranHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                ekranHatirlatma.IS_ID = ds.ID;
                ekranHatirlatma.HATIRLATSIN_MI = true;
                ekranHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                ekranHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                ekranHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                ekranHatirlatma.ACIKLAMA = ds.TEKRARLAMA_BILGISI ?? string.Empty;
                ekranHatirlatma.HATIRLATMA_TIPI = "0";
                ekranHatirlatma.BASLANGIC_ID = 1;
                ekranHatirlatma.PERIYOD_ID = 1;
                ekranHatirlatma.TEKRAR = 1;
                ekranHatirlatma.GUNLUK_UYARI_SAAT = (timeBaslangic.Time - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    switch (ucHatirlatmaPeriyot1.cbxHatirlatmaEkran.SelectedIndex)
                    {
                        case 0:
                            if (taraf.IS_TARAF_ID == 1)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 1:
                            if (taraf.IS_TARAF_ID == 2)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 2:
                            if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                                ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        case 3:
                            ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                            break;

                        default:
                            break;
                    }
                }

                ekranHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(ekranHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Ekran Hatırlatması

            #region Mail Hatırlatması

            if (chkMail.Checked)
            {
                AV001_TDI_BIL_HATIRLAT mailHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                mailHatirlatma.IS_ID = ds.ID;
                mailHatirlatma.HATIRLATSIN_MI = true;
                mailHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                mailHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                mailHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                mailHatirlatma.ACIKLAMA = "mail hatırlatma";
                mailHatirlatma.HATIRLATMA_TIPI = "1";
                mailHatirlatma.BASLANGIC_ID = 1;
                mailHatirlatma.PERIYOD_ID = 1;

                mailHatirlatma.TEKRAR = 1;
                mailHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                //if (chkIsBildir.Checked)
                //{
                mailHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = true;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxIsiBildirMail.SelectedIndex)
                    //{
                    //case 0:
                    //    if (taraf.IS_TARAF_ID == 1)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 1:
                    //    if (taraf.IS_TARAF_ID == 2)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 2:
                    //    if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //        mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;

                    //case 3:
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //    break;
                    //default:
                    //    break;
                    //}
                }
                //}

                //if (chkTamamlandiMail.Checked)
                //{
                //    mailHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxTamamlandiMail.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkYapilmamissaMail.Checked)
                //{
                //mailHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = true;

                //foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //{
                //    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //        break;
                //    switch (cbxYapilmamissaMail.SelectedIndex)
                //    {
                //        case 0:
                //            if (taraf.IS_TARAF_ID == 1)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 1:
                //            if (taraf.IS_TARAF_ID == 2)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 2:
                //            if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;

                //        case 3:
                //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //            break;
                //        default:
                //            break;
                //    }
                //}
                //}

                //if (chkHatirlatmaMail.Checked)
                //{
                //mailHatirlatma.GUNLUK_UYARI_SAAT = durationEdit1.Text.Substring(0, 5);
                mailHatirlatma.TEKRAR = 1;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxHatirlatmaMail.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                mailHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(mailHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Mail Hatırlatması

            #region SMS Hatırlatması

            if (chkSms.Checked)
            {
                AV001_TDI_BIL_HATIRLAT smsHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                smsHatirlatma.IS_ID = ds.ID;
                smsHatirlatma.HATIRLATSIN_MI = true;
                smsHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                smsHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                smsHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                smsHatirlatma.ACIKLAMA = "sms hatırlatma";
                smsHatirlatma.HATIRLATMA_TIPI = "2";
                smsHatirlatma.BASLANGIC_ID = 1;
                smsHatirlatma.PERIYOD_ID = 1;

                smsHatirlatma.TEKRAR = 1;
                smsHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                //if (chkIsiBildirSMS.Checked)
                //{
                smsHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = true;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxIsiBildirSMS.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                //if (chkTamamlandigindaSMS.Checked)
                //{
                //    smsHatirlatma.GOSTERSIN_MI_1_GUN_ONCE = chkTamamlandiMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxTamamlandiğindaSMS.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkYapilmamissaSMS.Checked)
                //{
                //    smsHatirlatma.PERIYODUN_SON_PATLAMASI_OLDU_MU = chkYapilmamissaMail.Checked;

                //    foreach (var taraf in myIs.AV001_TDI_BIL_IS_TARAFCollection)
                //    {
                //        if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                //            break;
                //        switch (cbxYapilmamissaSMS.SelectedIndex)
                //        {
                //            case 0:
                //                if (taraf.IS_TARAF_ID == 1)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 1:
                //                if (taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 2:
                //                if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                //                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;

                //            case 3:
                //                smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                //                break;
                //            default:
                //                break;
                //        }
                //    }
                //}

                //if (chkHatirlatSMS.Checked)
                //{
                //smsHatirlatma.GUNLUK_UYARI_SAAT = durationEdit1.Text.Substring(0, 5);
                smsHatirlatma.TEKRAR = 1;

                foreach (var taraf in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf.IS_TARAF_ID == null || smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf.ID))
                        break;
                    //switch (cbxHatirlatSMS.SelectedIndex)
                    //{
                    //    case 0:
                    //        if (taraf.IS_TARAF_ID == 1)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 1:
                    //        if (taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 2:
                    //        if (taraf.IS_TARAF_ID == 1 || taraf.IS_TARAF_ID == 2)
                    //            smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;

                    //    case 3:
                    smsHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf.ID });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                //}

                smsHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(smsHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion SMS Hatırlatması


        }

        // İşin ilgili NN tablolarına da kayıt yapması sağlanıyor.
        //public void IsKaydet()
        //{
        //    if (bndTebligat.Current == null)
        //        return;
        //    AV001_TDI_BIL_TEBLIGAT tebligat = bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT;

        //    AV001_TDI_BIL_IS ds = new AV001_TDI_BIL_IS();
        //    TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();
        //    ds.ACIKLAMA = tebligat.ACIKLAMA;
        //    ds.ADLI_BIRIM_ADLIYE_ID = tebligat.ADLI_BIRIM_ADLIYE_ID;
        //    ds.ADLI_BIRIM_GOREV_ID = tebligat.ADLI_BIRIM_GOREV_ID;
        //    ds.ADLI_BIRIM_NO_ID = tebligat.ADLI_BIRIM_NO_ID;
        //    ds.AJANDADA_GORUNSUN_MU = true;
        //    ds.BASLANGIC_TARIHI = tebligat.KAYIT_TARIHI;
        //    ds.ESAS_NO = tebligat.TEBLIGAT_ESAS_NO;
        //    ds.KONU = string.Format("{0} nolu Tebligat kaydı", tebligat.TEBLIGAT_REFERANS_NO);
        //    ds.ONGORULEN_BITIS_TARIHI = tebligat.KAYIT_TARIHI.AddHours(1);
        //    //ds.REFERANS_NO = tebligat.TEBLIGAT_REFERANS_NO;
        //    ds.REFERANS_NO = "Y-" + DateTime.Now.Year + "~" + DateTime.Now.Ticks;
        //    ds.DURUM = false;
        //    ds.BITIS_TARIHI = null;
        //    ds.ONCELIK_ID = 2; //Acil
        //    ds.KATEGORI_ID = 612;//TEBLİGAT İŞLERİ
        //    ds.STAMP = 0;

        //    if (gcIsTaraflari.DataSource != null)
        //        ds.AV001_TDI_BIL_IS_TARAFCollection = gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>;
        //    ds.MODUL_ID = 9; //Tebligat
        //    ds.STAMP = 0;
        //    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

        //    if (MyIcraFoy != null)
        //        _OpenedRecord = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(MyIcraFoy.ID);
        //    if (_OpenedRecord != null)
        //    {
        //        switch (_OpenedRecord.TableName)
        //        {
        //            case "AV001_TI_BIL_FOY":
        //                NN_IS_ICRA_FOY isIcra = new NN_IS_ICRA_FOY();
        //                isIcra.ICRA_FOY_ID = (OpenedRecord as AV001_TI_BIL_FOY).ID;
        //                isIcra.IS_ID = ds.ID;

        //                AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(isIcra);
        //                break;

        //            case "AV001_TD_BIL_FOY":
        //                NN_IS_DAVA_FOY isDava = new NN_IS_DAVA_FOY();
        //                isDava.DAVA_FOY_ID = (OpenedRecord as AV001_TD_BIL_FOY).ID;
        //                isDava.IS_ID = ds.ID;

        //                AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(isDava);
        //                break;

        //            case "AV001_TD_BIL_HAZIRLIK":
        //                NN_IS_HAZIRLIK isHazirlik = new NN_IS_HAZIRLIK();
        //                isHazirlik.HAZIRLIK_ID = (OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
        //                isHazirlik.IS_ID = ds.ID;

        //                AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(isHazirlik);
        //                break;

        //            case "AV001_TDI_BIL_SOZLESME":
        //                NN_IS_SOZLESME isSozlesme = new NN_IS_SOZLESME();
        //                isSozlesme.SOZLESME_ID = (OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
        //                isSozlesme.IS_ID = ds.ID;

        //                AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(isSozlesme);
        //                break;

        //            default:
        //                break;
        //        }
        //    }

        //    AdimAdimDavaKaydi.Util.NNProcess.SaveIs(ds, (IEntity)bndTebligat.Current);

        //    foreach (var item in ds.AV001_TDI_BIL_IS_TARAFCollection)
        //    {
        //        item.IS_ID = ds.ID;
        //    }
        //    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(ds.AV001_TDI_BIL_IS_TARAFCollection);

        //    if (ds.AV001_TDI_BIL_IS_TARAFCollection != null && ds.AV001_TDI_BIL_IS_TARAFCollection.Count >= 0)
        //    {
        //        for (int i = 0; i < ds.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
        //        {
        //            DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(ds, false, DeepLoadType.IncludeChildren,
        //                                                             typeof(TList<NN_IS_CARI>));
        //            NN_IS_CARI isCari = new NN_IS_CARI();
        //            isCari.IS_ID = ds.ID;
        //            if (ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID > 0)
        //            {
        //                isCari.CARI_ID = ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID.Value;

        //                if (
        //                    ds.NN_IS_CARICollection.Exists(
        //                        delegate(NN_IS_CARI tarf)
        //                        {
        //                            return tarf.CARI_ID == isCari.CARI_ID; // && tarf.IS_ID==isCari.IS_ID;
        //                        })) continue;
        //                AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(isCari);
        //            }
        //        }
        //    }
        //}

        public void Show(AV001_TI_BIL_FOY foy)
        {
            MyIcraFoy = foy;

            lueModul.EditValue = 1;

            lueModul_EditValueChanged(lueModul, new EventArgs());

            lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Icra");
            lueDosya.Properties.DisplayMember = "FOY_NO";
            lueDosya.Properties.ValueMember = "ID";
            //DosyaDoldur("Icra");

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            lueDosya.EditValue = foy.ID;

            layoutControlItem1.Control.Enabled = false;
            layoutControlItem2.Control.Enabled = false;
            this.Show();

            for (int x = 0; x < gridView1.RowCount; x++)
            {
                try
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    cn.Clear();
                    cn.AddParams("@TEBLIGAT_ID", MyDataSource.ID);
                    cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                    gridView1.SetRowCellValue(x, "PTT_BARKOD_NO", cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString());
                    gridView1.SetRowCellValue(x, "TEBLIGAT_ADRESI", cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString());
                }
                catch { ;}
            }

            chYapilacakIs.Checked = false;
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyDavaFoy = foy;

            lueModul.EditValue = 2;

            //lueModul_EditValueChanged(lueModul, new EventArgs());

            //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Dava");
            //lueDosyaNo.Properties.DisplayMember = "FOY_NO";
            //lueDosyaNo.Properties.ValueMember = "ID";
            //DosyaDoldur("Dava");

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            lueDosya.EditValue = foy.ID;

            layoutControlItem1.Control.Enabled = false;
            layoutControlItem2.Control.Enabled = false;

            this.Show();
            chYapilacakIs.Checked = false;
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foy)
        {
            MyHazirlik = foy;

            lueModul.EditValue = 3;

            //lueModul_EditValueChanged(lueModul, new EventArgs());

            //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur();
            //lueDosyaNo.Properties.DisplayMember = "HAZIRLIK_NO";
            //lueDosyaNo.Properties.ValueMember = "ID";
            //DosyaDoldur("Soruşturma");

            layoutControlItem1.Control.Enabled = false;
            layoutControlItem2.Control.Enabled = false;

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            lueDosya.EditValue = foy.ID;

            this.Show();
            chYapilacakIs.Checked = false;
        }

        public void Show(AV001_TDI_BIL_SOZLESME foy)
        {
            MySozlesme = foy;

            lueModul.EditValue = 5;

            //lueModul_EditValueChanged(lueModul, new EventArgs());

            //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur();
            //lueDosyaNo.Properties.DisplayMember = "HAZIRLIK_NO";
            //lueDosyaNo.Properties.ValueMember = "ID";
            //DosyaDoldur("Sozlesme");

            layoutControlItem1.Control.Enabled = false;
            layoutControlItem2.Control.Enabled = false;

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            lueDosya.EditValue = foy.ID;

            this.Show();
            chYapilacakIs.Checked = false;
        }

        public void Show(AV001_TDIE_BIL_PROJE proje)
        {
            this.MyProje = proje;
            this.Show();
            chYapilacakIs.Checked = false;
        }

        //public DialogResult ShowDialog(AV001_TI_BIL_FOY foy)
        //{
        //    MyIcraFoy = foy;

        //    lueModul.EditValue = 1;
        //    lueModul_EditValueChanged(lueModul, new EventArgs());

        //    //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Icra");
        //    //lueDosyaNo.Properties.DisplayMember = "FOY_NO";
        //    //lueDosyaNo.Properties.ValueMember = "ID";
        //    //DosyaDoldur("Icra");
        //    if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
        //        bndTebligat.AddNew();

        //    lueDosya.EditValue = foy.ID;

        //    layoutControlItem1.Control.Enabled = false;
        //    layoutControlItem2.Control.Enabled = false;

        //    return this.ShowDialog();
        //}

        //public DialogResult ShowDialog(AV001_TD_BIL_FOY foy)
        //{
        //    MyDavaFoy = foy;

        //    lueModul.EditValue = 2;
        //    lueModul_EditValueChanged(lueModul, new EventArgs());

        //    //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Dava");
        //    //lueDosyaNo.Properties.DisplayMember = "FOY_NO";
        //    //lueDosyaNo.Properties.ValueMember = "ID";
        //    //DosyaDoldur("Dava");

        //    if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
        //        bndTebligat.AddNew();

        //    lueDosya.EditValue = foy.ID;

        //    layoutControlItem1.Control.Enabled = false;
        //    layoutControlItem2.Control.Enabled = false;

        //    return this.ShowDialog();
        //}

        //public DialogResult ShowDialog(AV001_TD_BIL_HAZIRLIK foy)
        //{
        //    MyHazirlik = foy;

        //    lueModul.EditValue = 3;
        //    lueModul_EditValueChanged(lueModul, new EventArgs());

        //    //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur();
        //    //lueDosyaNo.Properties.DisplayMember = "HAZIRLIK_NO";
        //    //lueDosyaNo.Properties.ValueMember = "ID";
        //    //DosyaDoldur("Soruşturma");

        //    layoutControlItem1.Control.Enabled = false;
        //    layoutControlItem2.Control.Enabled = false;

        //    if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
        //        bndTebligat.AddNew();

        //    lueDosya.EditValue = foy.ID;

        //    return this.ShowDialog();
        //}

        //public DialogResult ShowDialog(AV001_TDI_BIL_SOZLESME foy)
        //{
        //    MySozlesme = foy;

        //    lueModul.EditValue = 5;
        //    lueModul_EditValueChanged(lueModul, new EventArgs());

        //    //lueDosyaNo.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur();
        //    //lueDosyaNo.Properties.DisplayMember = "HAZIRLIK_NO";
        //    //lueDosyaNo.Properties.ValueMember = "ID";
        //    //DosyaDoldur("Sozlesme");

        //    layoutControlItem1.Control.Enabled = false;
        //    layoutControlItem2.Control.Enabled = false;

        //    if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
        //        bndTebligat.AddNew();

        //    lueDosya.EditValue = foy.ID;

        //    return this.ShowDialog();
        //}

        //public DialogResult ShowDialog(AV001_TDIE_BIL_PROJE proje)
        //{
        //    this.MyProje = proje;
        //    return this.ShowDialog();
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            muhatab.OKUNDU_MU = false;
            muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
            muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = muhatab;
        }

        private void AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            yapan.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            yapan.KONTROL_NE_ZAMAN = DateTime.Today;
            yapan.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            yapan.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            yapan.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            yapan.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = yapan;
        }

        private void belgeKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            TList<NN_BELGE_TEBLIGAT> belgeList =
                DataRepository.NN_BELGE_TEBLIGATProvider.GetByTEBLIGAT_ID(
                    (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).ID);

            TList<AV001_TDIE_BIL_BELGE> belgeler = new TList<AV001_TDIE_BIL_BELGE>();

            foreach (var item in belgeList)
            {
                AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(item.BELGE_ID);

                belgeler.Add(belge);
            }
            exGridBelge.DataSource = belgeler;
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, Modul.Tebligat);
        }

        private void bndTebligat_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyIcraFoy != null)
            {
                #region İcra

                var yeniTebligat = MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyIcraFoy.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyIcraFoy.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyIcraFoy.ADLI_BIRIM_NO_ID;
                yeniTebligat.ICRA_FOY_ID = MyIcraFoy.ID;

                //yeniTebligat.ICRA_FOY_NO = MyIcraFoy.FOY_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                IcraTaraflarindanAl(MyIcraFoy, yeniTebligat);
                this.exGridBelge.DataSource = yeniTebligat.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;

                e.NewObject = yeniTebligat;

                #endregion İcra
            }
            else if (MyDavaFoy != null)
            {
                #region Dava

                var yeniTebligat = MyDavaFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyDavaFoy.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyDavaFoy.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyDavaFoy.ADLI_BIRIM_NO_ID;
                yeniTebligat.DAVA_FOY_ID = MyDavaFoy.ID;

                //yeniTebligat.DAVA_FOY_NO = MyDavaFoy.FOY_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                DavaTaraflarindanAl(MyDavaFoy, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Dava
            }
            else if (MyHazirlik != null)
            {
                #region Hazırlık

                var yeniTebligat = MyHazirlik.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyHazirlik.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyHazirlik.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyHazirlik.ADLI_BIRIM_NO_ID;
                yeniTebligat.HAZIRLIK_ID = MyHazirlik.ID;

                //yeniTebligat.HAZIRLIK_NO = MyHazirlik.HAZIRLIK_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                HazırlıkTaraflarindanAl(MyHazirlik, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Hazırlık
            }
            else if (MySozlesme != null)
            {
                #region Sozlesme

                var yeniTebligat = MySozlesme.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MySozlesme.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MySozlesme.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MySozlesme.ADLI_BIRIM_NO_ID;
                yeniTebligat.SOZLESME_ID = MySozlesme.ID;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                SozlesmeTaraflarindanAl(MySozlesme, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Sozlesme
            }
            else
            {
                AV001_TDI_BIL_TEBLIGAT yeniTebligat = new AV001_TDI_BIL_TEBLIGAT();
                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                e.NewObject = yeniTebligat;
            }
        }

        private void bndTebligat_CurrentChanged(object sender, EventArgs e)
        {
            if (bndTebligat.Current is AV001_TDI_BIL_TEBLIGAT)
            {
                AV001_TDI_BIL_TEBLIGAT tep = (AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current;
                this.exGridBelge.DataSource = tep.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;
                tep.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew += AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                this.exGridBelge.DataSource = tep.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;
                tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;

                for (int x = 0; x < tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; x++)
                {
                    try
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.Clear();
                        cn.AddParams("@TEBLIGAT_ID", tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].TEBLIGAT_ID);
                        cn.AddParams("@MUHATAP_CARI_ID", tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].MUHATAP_CARI_ID);

                        tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].PTT_BARKOD_NO = cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();

                        tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].TEBLIGAT_ADRESI = cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();
                    }
                    catch { ;}
                }
                this.gcMuhatap.DataSource = tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
            }
        }

        private void Child_OnNew(AV001_TDIE_BIL_BELGE belge, object sender)
        {
        }

        private void chYapilacakIs_CheckedChanged(object sender, EventArgs e)
        {
            if (chYapilacakIs.Checked)
            {
                tabIsTaraflari.PageVisible = true;
                chkMail.Checked = true;
                checkEdit3.Checked = true;
                hATIRLATILSIN_MICheckEdit.Checked = true;
                if (!isLookUpTaraflarFill)
                {
                    AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCariID);
                    BelgeUtil.Inits.IsTarafGetir(this.rlueIsTarafID);

                    #region<MB-20100322> İş Taraflarının Gelmesi

                    AV001_TDI_BIL_TEBLIGAT tebligat = ((AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current);
                    bASLANGIC_TARIHIDateEdit.EditValue = tebligat.KAYIT_TARIHI;
                    oNGORULEN_BITIS_TARIHIDateEdit.EditValue = tebligat.KAYIT_TARIHI.AddDays(1);

                    if (tebligat != null)
                    {
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <AV001_TDI_BIL_TEBLIGAT_MUHATAP>));
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                        TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> tebligatMuhataplar =
                            tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
                        TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebligatYapanlar =
                            tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;

                        TList<AV001_TDI_BIL_IS_TARAF> isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();

                        foreach (var item in tebligatMuhataplar)
                        {
                            AV001_TDI_BIL_CARI cari =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.MUHATAP_CARI_ID);

                            if (cari != null)
                            {
                                if (cari.MUVEKKIL_MI)
                                {
                                    AV001_TDI_BIL_IS_TARAF tarafMuvekkil = new AV001_TDI_BIL_IS_TARAF();
                                    tarafMuvekkil.IS_TARAF_ID = 3;
                                    tarafMuvekkil.CARI_ID = item.MUHATAP_CARI_ID;
                                    isTaraflari.Add(tarafMuvekkil);
                                }
                            }
                        }
                        foreach (var item in tebligatYapanlar)
                        {
                            AV001_TDI_BIL_CARI cari =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.YAPAN_CARI_ID);

                            if (cari != null)
                            {
                                if (cari.MUVEKKIL_MI)
                                {
                                    AV001_TDI_BIL_IS_TARAF tarafMuvekkil = new AV001_TDI_BIL_IS_TARAF();
                                    tarafMuvekkil.IS_TARAF_ID = 3;
                                    tarafMuvekkil.CARI_ID = item.YAPAN_CARI_ID;
                                    isTaraflari.Add(tarafMuvekkil);
                                }
                            }
                        }

                        if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                        {
                            AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                            taraf.IS_TARAF_ID = 2;
                            taraf.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                            isTaraflari.Add(taraf);
                        }

                        gcIsTaraflari.DataSource = isTaraflari;
                    }

                    #endregion Methods

                    isLookUpTaraflarFill = true;
                }
            }
            else
                tabIsTaraflari.PageVisible = false;
        }

        private void DavaTaraflarindanAl(AV001_TD_BIL_FOY icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
            for (int i = 0; i < icram.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(
                    icram.AV001_TD_BIL_FOY_TARAFCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = (short)icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

            //for (int y = 0; y < icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafs = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            //    tarafs.IS_TARAF_ID = 2;
            //    tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafs);
            //}
        }

        private void exGridBelge_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var tebligat = (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);

            if (tebligat != null)
            {
                AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belgeKayit = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();

                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = tebligat;
                belgeKayit.MyDataSource = tebligat.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;

                //belgeKayit.MdiParent = null;
                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeKayit.Child.OnNew += Child_OnNew;
                belgeKayit.FormClosed += belgeKayit_FormClosed;
                belgeKayit.Show();
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void frmlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.EvrakDoldur(lueEvrak);
        }

        private void frmLayTabligatKayit_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            InitsData();

            if (bndTebligat.Count == 0)
            {
                bndTebligat.AddingNew += bndTebligat_AddingNew;
                bndTebligat.AddNew();
            }
            else
            {
                //layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //Düzenleme modunda dosya değişikliği yapılması istediğinden item'lar görünür yapıldı ve aşağıdaki hale getirildi.
                //AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);

                //BelgeUtil.Inits.ModulKodGetir();
                //lueModul.EditValue = (int)Modul.Icra;
                //lueModul_EditValueChanged(lueModul, new EventArgs());
                //lueDosya.EditValue = (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).ICRA_FOY_ID;
            }

            if (MyProje != null)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            lueDosya.Properties.NullText = "Dosya Seçiniz";
            lciOzelKod1.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
            lciOzelKod2.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
            lciOzelKod3.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
            lciOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

            layoutControlItem11.Text = Kimlikci.Kimlik.DavaReferans.Referans1;
            layoutControlItem22.Text = Kimlikci.Kimlik.DavaReferans.Referans2;
            layoutControlItem20.Text = Kimlikci.Kimlik.DavaReferans.Referans3;
        }

        private void HazırlıkTaraflarindanAl(AV001_TD_BIL_HAZIRLIK icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
            for (int i = 0; i < icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(
                    icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i], false,
                    AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

            //for (int y = 0; y < icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafs = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            //    tarafs.IS_TARAF_ID = 2;
            //    tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafs);
            //}
        }

        private void IcraTaraflarindanAl(AV001_TI_BIL_FOY icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            for (int i = 0; i < icram.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(
                    icram.AV001_TI_BIL_FOY_TARAFCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            //for (int y = 0; y < icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafs = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            //    tarafs.IS_TARAF_ID = 2;
            //    tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafs);
            //}
        }

        private void InitsData()
        {
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lueAdliGorev);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lueAdliNo);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lueAdliye);
            BelgeUtil.Inits.TebligatKonuGetir(lueKonu);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCariID);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueTarafKod);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueTarafKodMuh);
            BelgeUtil.Inits.TebligatTipGetir(lueEvrakTip);
            BelgeUtil.Inits.TebligatKonuGetir(lueKonu);
            BelgeUtil.Inits.KullaniciListesiGetir(rlueBelgeKullaniciID);
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);
            lueModul.Enter += BelgeUtil.Inits.ModulKodGetir_Enter;
            lueModul.EditValueChanged += lueModul_EditValueChanged;

            BindOzelKod();

            lueOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
            //AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            //AvukatPro.Services.Implementations.DevExpressService.EvrakDoldur(lueEvrak);
            //AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValTebligat.Validate()) return;

                for (int i = 0; i < bndTebligat.List.Count; i++)
                {
                    var tebligat = bndTebligat[i] as AV001_TDI_BIL_TEBLIGAT;

                    TDI_KOD_TEBLIGAT_KONU Tk =
                        AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(tebligat.KONU_ID);

                    tebligat.ANA_TUR_ID = Tk.ANA_TUR_ID;
                    tebligat.ALT_TUR_ID = Tk.ALT_TUR_ID;
                    tebligat.TEBLIGAT_HEDEF_TIP = Convert.ToInt16(lueDosya.EditValue);

                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> Hak =
                        AvukatProLib2.Data.DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.
                            GetByANA_KATEGORI_ID(Tk.ANA_TUR_ID);
                    foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak in Hak)
                    {
                        tebligat.MUHASEBE_ALT_KATEGORI_IDSource = mhak;
                        break;
                    }

                    tebligat.NN_BELGE_TEBLIGATCollection.Clear();
                    for (int rowHandle = 0; rowHandle < lueBelge.Properties.View.RowCount; rowHandle++)
                    {
                        if ((bool)lueBelge.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        {
                            var belgeid = (int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id");
                            if (!tebligat.NN_BELGE_TEBLIGATCollection.Any(q => q.BELGE_ID == belgeid))
                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT() { BELGE_ID = belgeid });
                        }
                    }

                    tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Clear();
                    for (int rowHandle = 0; rowHandle < lueEvrak.Properties.View.RowCount; rowHandle++)
                    {
                        if ((bool)lueEvrak.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                            tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Add(new NN_TEBLIGAT_TEBLIGAT() { ILISKILI_TEBLIGAT_ID = (int)lueEvrak.Properties.View.GetRowCellValue(rowHandle, "Id") });
                    }

                    AvukatProLib2.Data.TransactionManager tm =
                        new AvukatProLib2.Data.TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                    try
                    {
                        tm.BeginTransaction();

                        if (tebligat.ICRA_FOY_ID.HasValue)
                            tebligat.NN_TEBLIGAT_ICRACollection.Add(new NN_TEBLIGAT_ICRA() { ICRA_FOY_ID = tebligat.ICRA_FOY_ID.Value });
                        if (tebligat.DAVA_FOY_ID.HasValue)
                            tebligat.NN_TEBLIGAT_DAVACollection.Add(new NN_TEBLIGAT_DAVA() { DAVA_FOY_ID = tebligat.DAVA_FOY_ID.Value });
                        if (tebligat.HAZIRLIK_ID.HasValue)
                            tebligat.NN_TEBLIGAT_HAZIRLIKCollection.Add(new NN_TEBLIGAT_HAZIRLIK() { HAZIRLIK_FOY_ID = tebligat.HAZIRLIK_ID.Value });
                        if (tebligat.SOZLESME_ID.HasValue)
                            tebligat.NN_TEBLIGAT_SOZLESMECollection.Add(new NN_TEBLIGAT_SOZLESME() { SOZLESME_ID = tebligat.SOZLESME_ID.Value });

                        if (tebligat.ID == 0)
                            tebligat.STAMP = 0;
                        else
                            tebligat.STAMP = 1;

                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Save(tm, tebligat);

                        foreach (var item in tebligat.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT)
                        {
                            if (!tebligat.NN_BELGE_TEBLIGATCollection.Exists(vi => vi.BELGE_ID == item.ID))
                            {
                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT
                                                                             {
                                                                                 TEBLIGAT_ID = tebligat.ID,
                                                                                 BELGE_ID = item.ID
                                                                             });
                            }
                        }

                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tm, tebligat, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_TEBLIGAT>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                        if (MyProje != null && !Duzenlememi)
                        {
                            if (DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.GetByPROJE_IDTEBLIGAT_ID(MyProje.ID, tebligat.ID) == null)
                            {
                                AV001_TDIE_BIL_PROJE_IHTARNAME ihtar = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                                ihtar.TEBLIGAT_ID = tebligat.ID;
                                ihtar.PROJE_ID = MyProje.ID;
                                DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.Save(tm, ihtar);
                            }
                        }

                        int belgei = 1;
                        foreach (var item in opfBelge.FileNames)
                        {
                            try
                            {
                                AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                                blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                                blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                                blg.BELGE_TUR_ID = 7;
                                blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                                blg.YAZILMA_TARIHI = DateTime.Now;
                                blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                                blg.STAMP = 0;
                                blg.DOSYA_ADI = item;
                                blg.DOKUMAN_UZANTI = Path.GetExtension(item);
                                blg.YIL = DateTime.Now.Year.ToString();
                                if (System.IO.File.Exists(item) && blg != null)
                                {
                                    System.IO.FileStream fss = new System.IO.FileStream(item, System.IO.FileMode.Open);
                                    byte[] veri = new byte[fss.Length];
                                    fss.Read(veri, 0, veri.Length);
                                    blg.ICERIK = veri;
                                    fss.Close();
                                }

                                foreach (var muhattap in tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                                {
                                    var trf = blg.AV001_TDIE_BIL_BELGE_TARAFCollection.AddNew();
                                    trf.CARI_ID = muhattap.MUHATAP_CARI_ID;
                                    trf.SIFAT_ID = 65;
                                    trf.KODU = 1;
                                }


                                foreach (var yapan in tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection)
                                {
                                    var trf = blg.AV001_TDIE_BIL_BELGE_TARAFCollection.AddNew();
                                    trf.CARI_ID = yapan.YAPAN_CARI_ID;
                                    trf.KODU = 3;
                                    trf.SIFAT_ID = 38;
                                }

                                blg.BELGE_ADI = Path.GetFileName(item);

                                blg.OZEL_KOD_1_ID = tebligat.TEBLIGAT_OZEL_KOD_ID;
                                blg.OZEL_KOD_2_ID = tebligat.TEBLIGAT_OZEL_KOD2_ID;
                                blg.OZEL_KOD_3_ID = tebligat.TEBLIGAT_OZEL_KOD3_ID;
                                blg.OZEL_KOD_4_ID = tebligat.TEBLIGAT_OZEL_KOD4_ID;

                                if (tebligat.ICRA_FOY_ID.HasValue)
                                    blg.NN_BELGE_ICRACollection.Add(new NN_BELGE_ICRA() { ICRA_FOY_ID = tebligat.ICRA_FOY_ID.Value });
                                if (tebligat.DAVA_FOY_ID.HasValue)
                                    blg.NN_BELGE_DAVACollection.Add(new NN_BELGE_DAVA() { DAVA_FOY_ID = tebligat.DAVA_FOY_ID.Value });
                                if (tebligat.HAZIRLIK_ID.HasValue)
                                    blg.NN_BELGE_HAZIRLIKCollection.Add(new NN_BELGE_HAZIRLIK() { HAZIRLIK_ID = tebligat.HAZIRLIK_ID.Value });
                                if (tebligat.SOZLESME_ID.HasValue)
                                    blg.NN_BELGE_SOZLESMECollection.Add(new NN_BELGE_SOZLESME() { SOZLESME_ID = tebligat.SOZLESME_ID.Value });

                                blg.ESAS_NO = tebligat.TEBLIGAT_ESAS_NO;

                                if (tebligat.ADLI_BIRIM_ADLIYE_ID.HasValue)
                                    blg.ADLI_BIRIM_ADLIYE_ID = tebligat.ADLI_BIRIM_ADLIYE_ID;

                                if (tebligat.ADLI_BIRIM_NO_ID.HasValue)
                                    blg.ADLI_BIRIM_NO_ID = tebligat.ADLI_BIRIM_NO_ID;

                                if (tebligat.ADLI_BIRIM_GOREV_ID.HasValue)
                                    blg.ADLI_BIRIM_GOREV_ID = tebligat.ADLI_BIRIM_GOREV_ID;

                                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(blg, AvukatProLib2.Data.DeepSaveType.IncludeChildren,
                                    typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>),
                                    typeof(TList<NN_BELGE_ICRA>),
                                    typeof(TList<NN_BELGE_DAVA>),
                                    typeof(TList<NN_BELGE_HAZIRLIK>),
                                    typeof(TList<NN_BELGE_SOZLESME>)
                                    );

                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT() { BELGE_ID = blg.ID });
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Tebligat Belge Kayıt", ex);
                            }
                            belgei++;
                        }
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tm, tebligat, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_TEBLIGAT>));
                        tm.Commit();

                        for (int x = 0; x < gridView1.RowCount; x++)
                        {
                            try
                            {
                                if (gridView1.GetRowCellValue(x, "PTT_BARKOD_NO") != null)
                                {
                                    if (gridView1.GetRowCellValue(x, "PTT_BARKOD_NO") != DBNull.Value)
                                    {
                                        if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(x, "PTT_BARKOD_NO").ToString()))
                                        {
                                            ABSqlConnection cn = new ABSqlConnection();
                                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                                            cn.Clear();
                                            cn.AddParams("@PTT_BARKOD_NO", gridView1.GetRowCellValue(x, "PTT_BARKOD_NO"));
                                            cn.AddParams("@TEBLIGAT_ID", tebligat.ID);
                                            cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                                            cn.ExcuteQuery("UPDATE dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP SET PTT_BARKOD_NO=@PTT_BARKOD_NO WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID");
                                        }
                                    }
                                }
                                if (gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI") != null)
                                {
                                    if (gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI") != DBNull.Value)
                                    {
                                        if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI").ToString()))
                                        {
                                            ABSqlConnection cn = new ABSqlConnection();
                                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                                            cn.Clear();
                                            cn.AddParams("@TEBLIGAT_ADRESI", gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI"));
                                            cn.AddParams("@TEBLIGAT_ID", tebligat.ID);
                                            cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                                            cn.ExcuteQuery("UPDATE dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP SET TEBLIGAT_ADRESI=@TEBLIGAT_ADRESI WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID");
                                        }
                                    }
                                }
                            }
                            catch { ;}
                        }

                        if (chYapilacakIs.Checked)
                            IsKaydet();

                        XtraMessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleşmiştir");
                        if (YenileKayit != null)
                            YenileKayit(this, new EvrakKayitEventArgs(tebligat));

                        tabBelgeler.PageVisible = true;
                        lcItemIliskiliEvrakEkle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                    catch (Exception ex)
                    {
                        if (tm.IsOpen)
                            tm.Rollback();

                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            }
        }

        private void lueBelge_Enter(object sender, System.EventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
        }

        private void lueDosyaNo_EditValueChanged(object sender, EventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = ((AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current);
            if (lueModul.EditValue != null && lueModul.EditValue != DBNull.Value)
                ModulID = Convert.ToInt32(lueModul.EditValue);
            if (lueDosya.EditValue == null) return;
            if (gcIsTaraflari.DataSource != null)
            {
                (gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>).Clear();
            }
            switch (ModulID)
            {
                case 2:
                    _OpenedRecord = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    if (tebligat != null)
                    {
                        lueAdliGorev.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        lueAdliye.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        lueAdliNo.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        tebligat.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        txtEsasNo.EditValue = ((AV001_TD_BIL_FOY)_OpenedRecord).ESAS_NO;
                        tebligat.TEBLIGAT_ESAS_NO = ((AV001_TD_BIL_FOY)_OpenedRecord).ESAS_NO;
                        tebligat.DAVA_FOY_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).ID;
                        tebligat.SEGMENT_ID = ((AV001_TD_BIL_FOY)_OpenedRecord).SEGMENT_ID;

                        #region<MB-20100322> Dosya Taraflarının Gelmesi

                        if ((_OpenedRecord as AV001_TD_BIL_FOY).AV001_TD_BIL_FOY_TARAFCollection.Count == 0)
                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad((AV001_TD_BIL_FOY)_OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

                        TList<AV001_TD_BIL_FOY_TARAF> foyTaraflari =
                            (_OpenedRecord as AV001_TD_BIL_FOY).AV001_TD_BIL_FOY_TARAFCollection;

                        tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                        tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();

                        if (foyTaraflari == null) return;

                        foreach (var item in foyTaraflari)
                        {
                            if (!item.DAVA_EDEN_MI)
                            {
                                AV001_TDI_BIL_TEBLIGAT_MUHATAP trf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                                DefaultAlanlarMuhatap(trf);

                                if (item.CARI_ID.HasValue)
                                    trf.MUHATAP_CARI_ID = item.CARI_ID.Value;
                                trf.MUHATAP_TARAF_KOD = Convert.ToInt16(item.TARAF_KODU);
                                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(trf);
                            }

                            else
                            {
                                AV001_TDI_BIL_TEBLIGAT_YAPAN trf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                                DefaultAlanlarYapan(trf);

                                trf.YAPAN_CARI_ID = item.CARI_ID.Value;
                                trf.TARAF_KOD = item.TARAF_KODU.ToString();
                                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(trf);
                            }
                        }
                        foreach (var item in ((AV001_TD_BIL_FOY)OpenedRecord).AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                            trf.CARI_ID = item.SORUMLU_AVUKAT_CARI_ID;
                            trf.IS_TARAF_ID = 2;
                            if (gcIsTaraflari.DataSource == null)
                                gcIsTaraflari.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
                            (gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>).Add(trf);
                        }
                        #endregion
                    }
                    break;

                case 3:
                    _OpenedRecord = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)lueDosya.EditValue);
                    if (tebligat != null)
                    {
                        lueAdliGorev.EditValue = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        lueAdliye.EditValue = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        lueAdliNo.EditValue = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        tebligat.ADLI_BIRIM_NO_ID = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        txtEsasNo.EditValue = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).HAZIRLIK_ESAS_NO;
                        tebligat.TEBLIGAT_ESAS_NO = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).HAZIRLIK_ESAS_NO;
                        tebligat.HAZIRLIK_ID = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).ID;
                        tebligat.SEGMENT_ID = ((AV001_TD_BIL_HAZIRLIK)_OpenedRecord).SEGMENT_ID;

                        #region<MB-20100322> Dosya Taraflarının Gelmesi

                        if ((_OpenedRecord as AV001_TD_BIL_HAZIRLIK).AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count == 0)
                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(
                                (AV001_TD_BIL_HAZIRLIK)_OpenedRecord, false, DeepLoadType.IncludeChildren,
                                typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));

                        TList<AV001_TD_BIL_HAZIRLIK_TARAF> foyTaraflari =
                            (_OpenedRecord as AV001_TD_BIL_HAZIRLIK).AV001_TD_BIL_HAZIRLIK_TARAFCollection;

                        tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                        tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();

                        if (foyTaraflari == null) return;

                        foreach (var item in foyTaraflari)
                        {
                            if (!item.SIKAYET_EDEN_MI)
                            {
                                AV001_TDI_BIL_TEBLIGAT_MUHATAP trf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                                DefaultAlanlarMuhatap(trf);

                                if (item.CARI_ID.HasValue)
                                    trf.MUHATAP_CARI_ID = item.CARI_ID.Value;
                                trf.MUHATAP_TARAF_KOD = item.TARAF_KODU;
                                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(trf);
                            }

                            else
                            {
                                AV001_TDI_BIL_TEBLIGAT_YAPAN trf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                                DefaultAlanlarYapan(trf);

                                trf.YAPAN_CARI_ID = item.CARI_ID.Value;
                                trf.TARAF_KOD = item.TARAF_KODU.ToString();
                                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(trf);
                            }
                        }
                        foreach (var item in ((AV001_TD_BIL_HAZIRLIK)OpenedRecord).AV001_TD_BIL_HAZIRLIK_SORUMLUCollection)
                        {
                            AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                            trf.CARI_ID = item.CARI_ID;
                            trf.IS_TARAF_ID = 2;
                            if (gcIsTaraflari.DataSource == null)
                                gcIsTaraflari.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
                            (gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>).Add(trf);
                        }
                        #endregion
                    }
                    break;

                case 5:
                    _OpenedRecord = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)lueDosya.EditValue);
                    if (tebligat != null)
                    {
                        lueAdliGorev.EditValue = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        lueAdliye.EditValue = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        lueAdliNo.EditValue = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        tebligat.ADLI_BIRIM_NO_ID = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        tebligat.SOZLESME_ID = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).ID;
                        tebligat.SEGMENT_ID = ((AV001_TDI_BIL_SOZLESME)_OpenedRecord).SEGMENT_ID;

                        #region<MB-20100322> Dosya Taraflarının Gelmesi

                        if ((_OpenedRecord as AV001_TDI_BIL_SOZLESME).AV001_TDI_BIL_SOZLESME_TARAFCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(
                                (AV001_TDI_BIL_SOZLESME)_OpenedRecord, false, DeepLoadType.IncludeChildren,
                                typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));

                        TList<AV001_TDI_BIL_SOZLESME_TARAF> foyTaraflari =
                            (_OpenedRecord as AV001_TDI_BIL_SOZLESME).AV001_TDI_BIL_SOZLESME_TARAFCollection;

                        tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                        tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();

                        if (foyTaraflari == null) return;

                        foreach (var item in foyTaraflari)
                        {
                            if (item.TARAF_KODU == Convert.ToInt16(TarafKodlari.K))
                            {
                                AV001_TDI_BIL_TEBLIGAT_MUHATAP trf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                                DefaultAlanlarMuhatap(trf);

                                if (item.CARI_ID.HasValue)
                                    trf.MUHATAP_CARI_ID = item.CARI_ID.Value;
                                trf.MUHATAP_TARAF_KOD = item.TARAF_KODU;
                                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(trf);
                            }

                            if (item.TARAF_KODU == Convert.ToInt16(TarafKodlari.M))
                            {
                                AV001_TDI_BIL_TEBLIGAT_YAPAN trf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                                DefaultAlanlarYapan(trf);

                                trf.YAPAN_CARI_ID = item.CARI_ID.Value;
                                trf.TARAF_KOD = item.TARAF_KODU.ToString();
                                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(trf);
                            }
                        }
                        foreach (var item in ((AV001_TDI_BIL_SOZLESME)OpenedRecord).AV001_TDI_BIL_SOZLESME_SORUMLUCollection)
                        {
                            AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                            trf.CARI_ID = item.SORUMLU_CARI_ID;
                            trf.IS_TARAF_ID = 2;
                            if (gcIsTaraflari.DataSource == null)
                                gcIsTaraflari.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
                            (gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>).Add(trf);
                        }
                        #endregion
                    }
                    break;

                case 1:
                    _OpenedRecord = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    if (tebligat != null)
                    {
                        lueAdliGorev.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        tebligat.ADLI_BIRIM_GOREV_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_GOREV_ID;
                        lueAdliye.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        tebligat.ADLI_BIRIM_ADLIYE_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_ADLIYE_ID;
                        lueAdliNo.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        tebligat.ADLI_BIRIM_NO_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ADLI_BIRIM_NO_ID;
                        txtEsasNo.EditValue = ((AV001_TI_BIL_FOY)_OpenedRecord).ESAS_NO;
                        tebligat.TEBLIGAT_ESAS_NO = ((AV001_TI_BIL_FOY)_OpenedRecord).ESAS_NO;
                        tebligat.FORM_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).FORM_TIP_ID;
                        tebligat.ICRA_FOY_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).ID;
                        tebligat.SEGMENT_ID = ((AV001_TI_BIL_FOY)_OpenedRecord).SEGMENT_ID;

                        #region<MB-20100322> Dosya Taraflarının Gelmesi

                        if ((_OpenedRecord as AV001_TI_BIL_FOY).AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad((AV001_TI_BIL_FOY)_OpenedRecord, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

                        TList<AV001_TI_BIL_FOY_TARAF> foyTaraflari =
                            (_OpenedRecord as AV001_TI_BIL_FOY).AV001_TI_BIL_FOY_TARAFCollection;

                        tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                        tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();

                        if (foyTaraflari == null) return;

                        foreach (var item in foyTaraflari)
                        {
                            if (!item.TAKIP_EDEN_MI)
                            {
                                AV001_TDI_BIL_TEBLIGAT_MUHATAP trf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

                                DefaultAlanlarMuhatap(trf);

                                if (item.CARI_ID.HasValue)
                                    trf.MUHATAP_CARI_ID = item.CARI_ID.Value;
                                trf.MUHATAP_TARAF_KOD = item.TARAF_KODU;
                                tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(trf);
                            }

                            else
                            {
                                AV001_TDI_BIL_TEBLIGAT_YAPAN trf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                                DefaultAlanlarYapan(trf);

                                trf.YAPAN_CARI_ID = item.CARI_ID.Value;
                                trf.TARAF_KOD = item.TARAF_KODU.ToString();
                                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(trf);
                            }
                        }

                        foreach (var item in ((AV001_TI_BIL_FOY)OpenedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                        {
                            AV001_TDI_BIL_IS_TARAF trf = new AV001_TDI_BIL_IS_TARAF();
                            trf.CARI_ID = item.SORUMLU_AVUKAT_CARI_ID;
                            trf.IS_TARAF_ID = 2;
                            if (gcIsTaraflari.DataSource == null)
                                gcIsTaraflari.DataSource = new TList<AV001_TDI_BIL_IS_TARAF>();
                            (gcIsTaraflari.DataSource as TList<AV001_TDI_BIL_IS_TARAF>).Add(trf);
                        }
                        #endregion
                    }
                    break;

                default:
                    break;
            }
        }

        private void lueEvrak_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmLayTabligatKayit frmlay = new frmLayTabligatKayit();
                frmlay.FormClosed += new FormClosedEventHandler(frmlay_FormClosed);
                frmlay.Show();
            }
        }

        private void lueEvrak_Enter(object sender, System.EventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.EvrakDoldur(lueEvrak);
        }

        private void lueKonu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "Yeni")
            {
                AdimAdimDavaKaydi.Forms.frmTebligatKonu frm = new frmTebligatKonu();
                frm.Show(lueKonu.Text);
            }
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueModul.Text == "Soruşturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueModul.Text == "Sözleşme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            lueDosya.Enabled = true;
        }

        private void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        private void lueSegment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag == "ekle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.Segment, -1);
                frmalt.ShowDialog();

                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            }
        }

        private void lueSegment_Enter(object sender, System.EventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
        }

        private void rLueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SearchLookUpEdit sLue = new SearchLookUpEdit();
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "mEkleCariD")
            {
                frm.tmpCariAd = lue.Text;

                if (csDavaEden != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEden);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
                                          }
                                      };
            }
        }

        private void rLueCari_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();

            frm.tmpCariAd = lue.Text;

            if (csDavaEden != null)
            {
                if (csDavaEden != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEden);
            }

            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      DialogResult dr = frm.KayitBasarili;
                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                      {
                                          //Inits.perCariGetirRefresh();
                                          AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
                                      }
                                  };
        }

        private void rLueCariMuhatab_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "mEkleCariD")
            {
                frm.tmpCariAd = lue.Text;

                if (csDavaEdilen != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEdilen);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
                                          }
                                      };
            }
        }

        private void rLueCariMuhatab_ProcessNewValue(object sender,
            DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();

            frm.tmpCariAd = lue.Text;

            if (csDavaEdilen != CariStatu.Personel)
                frm.Statuler.Add(csDavaEdilen);

            frm.MdiParent = null;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      DialogResult dr = frm.KayitBasarili;
                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                      {
                                          //Inits.perCariGetirRefresh();
                                          AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
                                      }
                                  };
        }

        private void rLueTarafKod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            csDavaEden = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void rLueTarafKodMuh_EditValueChanging(object sender,
            DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            csDavaEdilen = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void sbtnIliskiliEvrakEkle_Click(object sender, EventArgs e)
        {
            var selectedTebligat = bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT;
            Forms.frmTebligatIliskiEkle frm = new frmTebligatIliskiEkle();
            frm.Show(selectedTebligat);
        }

        private void SozlesmeTaraflarindanAl(AV001_TDI_BIL_SOZLESME icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));

            for (int i = 0; i < icram.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(
                    icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i], false,
                    AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
        }

        private void Vazgec_Click(object sender, EventArgs e)
        {
            if (MyIcraFoy != null)
            {
                MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MyDavaFoy != null)
            {
                MyDavaFoy.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MyHazirlik != null)
            {
                MyHazirlik.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MySozlesme != null)
            {
                MySozlesme.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            this.Close();
        }

        #endregion Methods

        private void hATIRLATILSIN_MICheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = hATIRLATILSIN_MICheckEdit.Checked;
            durationEdit1.SelectedIndex = 0;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            tabTekrarlama.PageVisible = checkEdit3.Checked;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            opfBelge.ShowDialog();

        }
    }

    public class EvrakKayitEventArgs : EventArgs
    {
        #region Constructors

        public EvrakKayitEventArgs(AV001_TDI_BIL_TEBLIGAT myEvrak)
        {
            MyEvrak = myEvrak;
        }

        #endregion Constructors

        #region Properties

        public AV001_TDI_BIL_TEBLIGAT MyEvrak
        {
            get;
            set;
        }

        #endregion Properties
    }
}