using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmHacizIhbarnameleri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmHacizIhbarnameleri()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += new EventHandler(frmHacizIhbarnameleri_Load);
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmHacizIhbarnameleri_Button_Kaydet_Click);
        }

        #region Properties

        //89/1
        private List<int> _SecilenCarilerIDList;

        //89/2, 89/3, Borçlu Oluştur
        private TList<AV001_TDI_BIL_TEBLIGAT> _TebligatList;

        private TList<AV001_TDI_BIL_CARI_ALT> cariAltList = new TList<AV001_TDI_BIL_CARI_ALT>();
        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> MuhatapList = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
        private Dictionary<int, IhbarnameTip> NewIhbarnameList = new Dictionary<int, IhbarnameTip>();
        private Dictionary<int, string> RefNoList = new Dictionary<int, string>();
        private TList<AV001_TDI_BIL_TEBLIGAT> tebligatList = new TList<AV001_TDI_BIL_TEBLIGAT>();

        public AV001_TI_BIL_FOY IcraFoy { get; set; }

        public List<int> SecilenCarilerIDList
        {
            get { return _SecilenCarilerIDList; }
            set
            {
                if (value != null)
                {
                    _SecilenCarilerIDList = value;
                    Tip = IhbarnameTip.BirinciHacizIhbarnamesi;
                    TebligatReferansNoOlustur(_SecilenCarilerIDList);
                    gcHacizIhbarnameleri.DataSource = NewBirinciHacizIhbarnamesi(_SecilenCarilerIDList);
                }
            }
        }

        public TList<AV001_TDI_BIL_TEBLIGAT> TebligatList
        {
            get
            {
                return _TebligatList;
            }
            set
            {
                if (value != null)
                {
                    _TebligatList = value;

                    if (Tip == IhbarnameTip.BorcluYap)
                    {
                        #region Borçlu Yap

                        foreach (var item in _TebligatList)
                        {
                            var muhatapList = DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID(item.ID).FindAll(vi => vi.TEBLIGAT_SONUC_ID != 1 && vi.TEBLIG_TARIH.HasValue);//Kapatılmamış, 3.Haciz İhbarnameleri

                            foreach (var muhatap in muhatapList)
                            {
                                var sonTebligT = muhatap.TEBLIG_TARIH.Value.AddDays(15);
                                if (sonTebligT.DayOfWeek == DayOfWeek.Saturday) sonTebligT.AddDays(2);
                                else if (sonTebligT.DayOfWeek == DayOfWeek.Sunday) sonTebligT.AddDays(1);

                                if (DateTime.Now.Date < sonTebligT) continue;

                                if (!muhatap.MENFI_TESPIT_DAVA_TARIHI.HasValue && !muhatap.BORCUN_ODENDIGI_TARIH.HasValue)
                                {
                                    //Borçlu yap
                                    MuhatapList.Add(muhatap);
                                }
                                else
                                    IhbarnameTarihleriKontrol(muhatap, sonTebligT);
                            }
                        }
                        gcHacizIhbarnameleri.DataSource = MuhatapList;

                        #endregion Borçlu Yap
                    }
                    else
                    {
                        #region 89/2, 89/3 Oluştur

                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(_TebligatList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));

                        foreach (var item in _TebligatList)
                        {
                            var muhatapList = item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.FindAll(vi => vi.TEBLIGAT_SONUC_ID != 1 && vi.TEBLIG_TARIH.HasValue);

                            foreach (var muhatap in muhatapList)
                            {
                                if (muhatap.BILA_TARIHI.HasValue)
                                {
                                    //Kapanır.
                                    muhatap.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
                                    continue;
                                }
                                var sonTebligT = muhatap.TEBLIG_TARIH.Value.AddDays(7);
                                if (sonTebligT.DayOfWeek == DayOfWeek.Saturday) sonTebligT.AddDays(2);
                                else if (sonTebligT.DayOfWeek == DayOfWeek.Sunday) sonTebligT.AddDays(1);

                                if (DateTime.Now.Date < sonTebligT) continue;

                                if (!muhatap.BORCUN_ODENDIGI_TARIH.HasValue && !muhatap.TEBLIGATA_ITIRAZ_TARIHI.HasValue)
                                {
                                    //89/2 oluşturulabilir.
                                    NewIhbarnameList.Add(muhatap.MUHATAP_CARI_ID, Tip);
                                    muhatap.TEBLIGAT_SONUC_ID = 1;
                                }
                                else
                                {
                                    if (muhatap.BORCUN_ODENDIGI_TARIH.HasValue)
                                    {
                                        if (muhatap.BORCUN_ODENDIGI_TARIH.Value <= sonTebligT)
                                        {
                                            //kapanır.
                                            muhatap.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
                                        }
                                        else
                                        {
                                            //89/2 oluşturulabilir.
                                            NewIhbarnameList.Add(muhatap.MUHATAP_CARI_ID, Tip);
                                            muhatap.TEBLIGAT_SONUC_ID = 1;
                                        }
                                    }

                                    else if (muhatap.TEBLIGATA_ITIRAZ_TARIHI.HasValue)
                                    {
                                        if (muhatap.TEBLIGATA_ITIRAZ_TARIHI.Value <= sonTebligT)
                                        {
                                            //kapanır.
                                            muhatap.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
                                        }
                                        else
                                        {
                                            //89/2 oluşturulabilir.
                                            NewIhbarnameList.Add(muhatap.MUHATAP_CARI_ID, Tip);

                                            //89/2'den 89/3, 89/1'den 89/2 oluşturulurken, mevcut 89/2 ve 89/1 kayıtları kapanır. O kayıttan oluşturulan ihbarname aktif olur. Aşağıdaki kod bu nedenle eklendi.
                                            muhatap.TEBLIGAT_SONUC_ID = 1;
                                        }
                                    }
                                }
                            }
                        }
                        gcHacizIhbarnameleri.DataSource = NewIhbarname(NewIhbarnameList);

                        #endregion 89/2, 89/3 Oluştur
                    }
                }
            }
        }

        public IhbarnameTip Tip { get; set; }

        #endregion Properties

        #region Events

        private void btnBorcluYap_Click(object sender, EventArgs e)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(IcraFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            var selectedIhbarname = gvHacizIhbarnameleri.GetFocusedRow() as AV001_TDI_BIL_TEBLIGAT_MUHATAP;
            selectedIhbarname.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
            IcraFoy.AV001_TI_BIL_FOY_TARAFCollection.Add(NewFoyTaraf(selectedIhbarname.MUHATAP_CARI_ID, IcraFoy.ID));

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, IcraFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Save(tran, selectedIhbarname);
                tran.Commit();
                MessageBox.Show("İhbarname muhatapları dosyanın \r\nBORÇLULARINA eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("İşlem gerçekleştirilemedi.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmHacizIhbarnameleri_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_CARI_ALTProvider.Save(tran, cariAltList);

                if (Tip == IhbarnameTip.IkinciHacizIhbarnamesi || Tip == IhbarnameTip.UcuncuHacizIhbarnamesi)
                {
                    TList<AV001_TDI_BIL_TEBLIGAT> selectedTebligatList = new TList<AV001_TDI_BIL_TEBLIGAT>();

                    foreach (var item in tebligatList)
                    {
                        foreach (var muh in item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                        {
                            if (muh.IsSelected && !selectedTebligatList.Contains(item))
                                selectedTebligatList.Add(item);
                        }
                    }

                    //89/2, 89/3
                    if (selectedTebligatList.Count > 0)
                    {
                        foreach (var item in selectedTebligatList)
                        {
                            foreach (var muh in item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                            {
                                if (muh.BORCUN_ODENDIGI_TARIH.HasValue || muh.POSTA_SON_ISLEM_TARIHI.HasValue || muh.TEBLIGATA_ITIRAZ_TARIHI.HasValue)
                                    muh.TEBLIGAT_SONUC_ID = 1;//KAPATILDI

                                //89/2'den 89/3, 89/1'den 89/2 oluşturduktan sonra 89/2,89/1 kayıtlarının durumlarını KAPATILDI yapabilmek için eklendi.
                                var ustTebligat = TebligatList.Find(vi => vi.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].MUHATAP_CARI_ID == muh.MUHATAP_CARI_ID);
                                if (ustTebligat != null)
                                {
                                    ustTebligat.IsSelected = true;
                                }
                            }
                        }
                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, selectedTebligatList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                        DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, TebligatList.FindAll(vi => vi.IsSelected), DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>));
                    }
                }
                else //89/1
                {
                    foreach (var item in tebligatList)
                    {
                        foreach (var muh in item.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                        {
                            if (muh.BORCUN_ODENDIGI_TARIH.HasValue || muh.BILA_TARIHI.HasValue || muh.TEBLIGATA_ITIRAZ_TARIHI.HasValue)
                                muh.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
                        }
                    }
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tran, tebligatList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                }

                tran.Commit();
                MessageBox.Show("Kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kaydedilemedi.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmHacizIhbarnameleri_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.perCariGetir(rlueMuhatapCari);

            #region Column Control

            switch (Tip)
            {
                case IhbarnameTip.BirinciHacizIhbarnamesi:
                    colBorcluYap.Visible = false;
                    colIsSelected.Visible = false;
                    colMUHATAP_CARI_ID.Caption = "1.Haciz İhbarnamesi Gönderilen ÜÇÜNCÜ kişi";
                    break;

                case IhbarnameTip.IkinciHacizIhbarnamesi:
                    colBorcluYap.Visible = false;
                    colIsSelected.Visible = true;
                    colMUHATAP_CARI_ID.Caption = "2.Haciz İhbarnamesi Gönderilen ÜÇÜNCÜ kişi";
                    break;

                case IhbarnameTip.UcuncuHacizIhbarnamesi:
                    colBorcluYap.Visible = false;
                    colIsSelected.Visible = true;
                    colMUHATAP_CARI_ID.Caption = "3.Haciz İhbarnamesi Gönderilen ÜÇÜNCÜ kişi";
                    break;

                case IhbarnameTip.BorcluYap:
                    colBorcluYap.Visible = true;
                    colIsSelected.Visible = false;
                    colMUHATAP_CARI_ID.Caption = "3.Haciz İhbarnamesi Gönderilen ÜÇÜNCÜ kişi";
                    this.Button_Kaydet_Click -= frmHacizIhbarnameleri_Button_Kaydet_Click;
                    break;
                default:
                    break;
            }

            #endregion Column Control
        }

        #endregion Events

        #region Methods

        public void Show(AV001_TI_BIL_FOY foy, List<int> idList)
        {
            this.IcraFoy = foy;
            this.SecilenCarilerIDList = idList;

            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foy, TList<AV001_TDI_BIL_TEBLIGAT> tebligatList, IhbarnameTip tip)
        {
            this.Tip = tip;
            this.IcraFoy = foy;
            this.TebligatList = tebligatList;

            this.Show();
        }

        public void TebligatReferansNoOlustur(List<int> idList)
        {
            var refNo = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "SELECT TOP(1)TEBLIGAT_REFERANS_NO FROM AV001_TDI_BIL_TEBLIGAT ORDER BY ID DESC");
            int refNoSayi = 10000;
            string yeniRefNo = string.Empty;

            if (refNo != null)
            {
                refNo = refNo.ToString().Substring(7, 5);
                refNoSayi = Convert.ToInt32(refNo);
                yeniRefNo = "E" + "-" + DateTime.Today.Year + "~" + (++refNoSayi).ToString();
            }
            else
                yeniRefNo = "E-" + DateTime.Today.Year.ToString() + "~" + refNoSayi.ToString();

            idList.ForEach(item =>
            {
                RefNoList.Add(item, yeniRefNo);
                yeniRefNo = "E" + "-" + DateTime.Today.Year + "~" + (++refNoSayi).ToString();
            });
        }

        public void TebligatReferansNoOlustur(Dictionary<int, IhbarnameTip> idList)
        {
            var id = idList.Select(vi => vi.Key).ToList();
            TebligatReferansNoOlustur(idList.Select(vi => vi.Key).ToList());
        }

        private void BorcluOlustur(AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap, DateTime date, DateTime sonTebligT, TarihTip tarihTip)
        {
            if (date <= sonTebligT || tarihTip == TarihTip.BorcOdemeTarihi)
            {
                //Kapanır
                muhatap.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
            }
            else if (muhatap.ICRAYA_BELGE_IBRAZ_TARIHI.HasValue)
            {
                sonTebligT = muhatap.TEBLIG_TARIH.Value.AddDays(20);
                if (sonTebligT.DayOfWeek == DayOfWeek.Saturday) sonTebligT.AddDays(2);
                else if (sonTebligT.DayOfWeek == DayOfWeek.Sunday) sonTebligT.AddDays(1);

                if (muhatap.ICRAYA_BELGE_IBRAZ_TARIHI.Value <= sonTebligT)
                {
                    //Sonuca Bakılır.
                    // Sonuc Bankanın lehine ise borçlu oluşturulur. Sonuc bankanın aleyhine ise kapanır.

                    //POSTA_SON_ISLEM_TARIHI alanı katman basılım dava kabul tarihi eklenene kadar dava kabul tarihi olarak kullanılacak. Bu alanın değeri olması demek muhatabın açtığı davayı kazanması ve ihbarnamenin kapanması demektir. Değeri yoksa Muhataptan Borclu oluşturulur.
                    if (muhatap.POSTA_SON_ISLEM_TARIHI.HasValue)//Bankanın Aleyhine
                    {
                        //Kapanır
                        muhatap.TEBLIGAT_SONUC_ID = 1;//KAPATILDI
                    }
                    else if (muhatap.TEBLIGATA_ITIRAZ_TARIHI.HasValue)//Bankanın Lehine
                    {
                        //Borclu Yap.
                        MuhatapList.Add(muhatap);
                    }
                }
            }
            else if (DateTime.Now.Date < sonTebligT)
            {
                sonTebligT = sonTebligT.AddDays(5);
                if (sonTebligT.DayOfWeek == DayOfWeek.Saturday) sonTebligT.AddDays(2);
                else if (sonTebligT.DayOfWeek == DayOfWeek.Sunday) sonTebligT.AddDays(1);

                if (DateTime.Now.Date < sonTebligT)
                {
                    //borçlu yap
                    MuhatapList.Add(muhatap);
                }
            }
        }

        private AV001_TDI_BIL_TEBLIGAT_MUHATAP CreateNewTebligatItemsForIhbarname(KeyValuePair<int, IhbarnameTip> item)
        {
            return CreateNewTebligatItemsForIhbarname(item.Key, item.Value);
        }

        private AV001_TDI_BIL_TEBLIGAT_MUHATAP CreateNewTebligatItemsForIhbarname(int item, IhbarnameTip tip)
        {
            AV001_TDI_BIL_TEBLIGAT tebligat = new AV001_TDI_BIL_TEBLIGAT();
            tebligat.ALT_TUR_ID = 94;
            tebligat.ANA_TUR_ID = 64;
            tebligat.GELEN_BELGE_MI = false;
            tebligat.ICRA_FOY_ID = IcraFoy.ID;
            tebligat.ICRA_ILK_TEBLIGAT_MI = false;
            if (tip == IhbarnameTip.BirinciHacizIhbarnamesi)
                tebligat.KONU_ID = 162;
            else if (tip == IhbarnameTip.IkinciHacizIhbarnamesi)
                tebligat.KONU_ID = 163;
            else if (tip == IhbarnameTip.UcuncuHacizIhbarnamesi)
                tebligat.KONU_ID = 450;
            tebligat.TEBLIGAT_REFERANS_NO = RefNoList.FirstOrDefault(vi => vi.Key == item).Value;

            var sorumluList = DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(IcraFoy.ID);

            tebligat.HAZIRLAYAN_ID = sorumluList.FirstOrDefault(vi => !vi.YETKILI_MI).SORUMLU_AVUKAT_CARI_ID.Value;
            tebligat.MUHASEBE_ALT_KATEGORI_ID = 546;

            AV001_TDI_BIL_CARI_ALT alt_cari = cariAltList.AddNew();
            alt_cari.UST_CARI_ID = item;

            AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
            mhtp.CARI_ALT_IDSource = alt_cari;
            mhtp.MUHATAP_CARI_ID = item;
            mhtp.ICRA_FOY_ID = IcraFoy.ID;
            mhtp.KLASOR_KODU = tebligat.KLASOR_KODU;
            mhtp.ODEME_TUTARI = IcraFoy.KALAN;
            mhtp.ODEME_TUTAR_DOVIZ_ID = IcraFoy.KALAN_DOVIZ_ID;

            tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(mhtp);

            if (BelgeUtil.Inits._FoyTarafGetir == null)
                BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            var tarafList = BelgeUtil.Inits._FoyTarafGetir.FindAll(vi => vi.ICRA_FOY_ID == IcraFoy.ID);
            for (int i = 0; i < tarafList.Count; i++)
            {
                if (tarafList[i].TAKIP_EDEN_MI)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN ypn = tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                    ypn.ICRA_FOY_ID = IcraFoy.ID;
                    ypn.YAPAN_CARI_ID = tarafList[i].CARI_ID.Value;
                    ypn.KLASOR_KODU = tebligat.KLASOR_KODU;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(ypn);
                }
            }

            if (!tebligatList.Contains(tebligat))
                tebligatList.Add(tebligat);

            return mhtp;
        }

        private void IhbarnameTarihleriKontrol(AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatap, DateTime sonTebligT)
        {
            if (muhatap.MENFI_TESPIT_DAVA_TARIHI.HasValue)
            {
                BorcluOlustur(muhatap, muhatap.MENFI_TESPIT_DAVA_TARIHI.Value, sonTebligT, TarihTip.MenfiTespitDavasiTarihi);
            }
            else if (muhatap.BORCUN_ODENDIGI_TARIH.HasValue)
            {
                BorcluOlustur(muhatap, muhatap.BORCUN_ODENDIGI_TARIH.Value, sonTebligT, TarihTip.BorcOdemeTarihi);
            }
        }

        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> NewBirinciHacizIhbarnamesi(List<int> idList)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> list = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();

            foreach (int item in idList)
                list.Add(CreateNewTebligatItemsForIhbarname(item, Tip));

            return list;
        }

        private AV001_TI_BIL_FOY_TARAF NewFoyTaraf(int muhatapCariID, int foyID)
        {
            AV001_TI_BIL_FOY_TARAF trf = new AV001_TI_BIL_FOY_TARAF();
            trf.ICRA_FOY_ID = foyID;
            trf.CARI_ID = muhatapCariID;
            trf.TARAF_KODU = (int)AvukatProLib.Extras.TarafKodu.KarsiTaraf;
            trf.TARAF_SIFAT_ID = 2;
            trf.KAYIT_TARIHI = DateTime.Now;
            trf.KONTROL_NE_ZAMAN = DateTime.Now;
            trf.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            trf.TAKIP_EDEN_MI = false;
            trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            return trf;
        }

        private TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> NewIhbarname(Dictionary<int, IhbarnameTip> newItemList)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> list = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
            TebligatReferansNoOlustur(newItemList);

            foreach (var item in newItemList)
                list.Add(CreateNewTebligatItemsForIhbarname(item));

            return list;
        }

        #endregion Methods
    }
}