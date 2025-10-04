using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmTakipAc : Form
    {
        public frmTakipAc()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmTakipAc_Load);
        }

        public List<int> TakibeAlinanBilesenler = new List<int>();

        private int _FormTipi;

        public CustomerData Customer { get; set; }

        public Classes.DosyaBilgileri Dosya { get; set; }

        public int FormTipi
        {
            get
            {
                return _FormTipi;
            }
            set
            {
                if (value != null)
                {
                    _FormTipi = value;
                    TakibeAlinanBilesenler.Clear();

                    switch (_FormTipi)
                    {
                        case (int)Enums.FormTipleri.Form49_7:
                        case (int)Enums.FormTipleri.Form153_11:
                            BindGridControlsAsFormTip(nbgCek, gcCekler, false, Enums.DosyaBilesenleri.Cek, Dosya.Cekler);
                            BindGridControlsAsFormTip(nbgBono, gcBonolar, false, Enums.DosyaBilesenleri.Bono, Dosya.Bonolar);
                            BindGridControlsAsFormTip(nbgMunzamSenet, gcMunzamSenetler, false, Enums.DosyaBilesenleri.MunzamSenet, Dosya.MunzamSenetler);
                            BindGridControlsAsFormTip(nbgIpotek, gcIpotekler, false, Enums.DosyaBilesenleri.Ipotek, Dosya.Ipotekler);
                            BindGridControlsAsFormTip(nbgRehin, gcRehinler, false, Enums.DosyaBilesenleri.Rehin, Dosya.Rehinler);
                            break;

                        case (int)Enums.FormTipleri.Form52_12:
                        case (int)Enums.FormTipleri.Form163_10:
                            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.Cek);
                            BindGridControlsAsFormTip(nbgCek, gcCekler, true, Enums.DosyaBilesenleri.Cek, Dosya.Cekler);
                            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.Bono);
                            BindGridControlsAsFormTip(nbgBono, gcBonolar, true, Enums.DosyaBilesenleri.Bono, Dosya.Bonolar);
                            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.MunzamSenet);
                            BindGridControlsAsFormTip(nbgMunzamSenet, gcMunzamSenetler, true, Enums.DosyaBilesenleri.MunzamSenet, Dosya.MunzamSenetler);
                            BindGridControlsAsFormTip(nbgIpotek, gcIpotekler, false, Enums.DosyaBilesenleri.Ipotek, Dosya.Ipotekler);
                            BindGridControlsAsFormTip(nbgRehin, gcRehinler, false, Enums.DosyaBilesenleri.Rehin, Dosya.Rehinler);
                            break;

                        case (int)Enums.FormTipleri.Form151_6:
                        case (int)Enums.FormTipleri.Form152_9:
                            BindGridControlsAsFormTip(nbgCek, gcCekler, false, Enums.DosyaBilesenleri.Cek, Dosya.Cekler);
                            BindGridControlsAsFormTip(nbgBono, gcBonolar, false, Enums.DosyaBilesenleri.Bono, Dosya.Bonolar);
                            BindGridControlsAsFormTip(nbgMunzamSenet, gcMunzamSenetler, false, Enums.DosyaBilesenleri.MunzamSenet, Dosya.MunzamSenetler);
                            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.Ipotek);
                            BindGridControlsAsFormTip(nbgIpotek, gcIpotekler, true, Enums.DosyaBilesenleri.Ipotek, Dosya.Ipotekler);
                            BindGridControlsAsFormTip(nbgRehin, gcRehinler, false, Enums.DosyaBilesenleri.Rehin, Dosya.Rehinler);
                            break;

                        case (int)Enums.FormTipleri.Form54_2:
                        case (int)Enums.FormTipleri.Form201_44:
                            BindGridControlsAsFormTip(nbgCek, gcCekler, false, Enums.DosyaBilesenleri.Cek, Dosya.Cekler);
                            BindGridControlsAsFormTip(nbgBono, gcBonolar, false, Enums.DosyaBilesenleri.Bono, Dosya.Bonolar);
                            BindGridControlsAsFormTip(nbgMunzamSenet, gcMunzamSenetler, false, Enums.DosyaBilesenleri.MunzamSenet, Dosya.MunzamSenetler);
                            BindGridControlsAsFormTip(nbgIpotek, gcIpotekler, false, Enums.DosyaBilesenleri.Ipotek, Dosya.Ipotekler);
                            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.Rehin);
                            BindGridControlsAsFormTip(nbgRehin, gcRehinler, true, Enums.DosyaBilesenleri.Rehin, Dosya.Rehinler);
                            break;

                        case (int)Enums.FormTipleri.Form49_7_Kambiyo:
                            break;

                        case (int)Enums.FormTipleri.FormKarisik:
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        //Seçilen form tipine göre açıkta kalan nesneler varsa bunun bilgisi verilecek. Örneğin dosyada çek var, 49 seçildi. Çekler takibe dahil edilmeyecek ama dosyada çek olduğu bilgisi kullanıcıya gösterilecek. Bu nedenle Visible false olan bileşenlerde bu proerty'e Add yapılacak.
        public Dictionary<object, int> TakipControls { get; set; }

        public void BindGridContols()
        {
            #region Binding Kontrolleri

            //Aktarımda değer gelmişşe ilgili navbargroup gösteriliyor. Değer yoksa navbargroup invisible yapılıyor.
            //navbargroup visible olma durumuna göre seçilen form tiplerinde collection'lar kurallara göre şekillendiriliyor.

            if (Dosya.NakitAlacaklar != null) gcNakitAlacaklar.DataSource = Dosya.NakitAlacaklar;
            else nbgNakitAlacak.Visible = false;

            if (Dosya.GayriNakitAlacaklar != null) gcGayrinakitAlacaklar.DataSource = Dosya.GayriNakitAlacaklar;
            else nbgGayrinakitAlacak.Visible = false;

            if (Dosya.Cekler != null) gcCekler.DataSource = Dosya.Cekler;
            else nbgCek.Visible = false;

            if (Dosya.Bonolar != null) gcBonolar.DataSource = Dosya.Bonolar;
            else nbgBono.Visible = false;

            if (Dosya.MunzamSenetler != null) gcMunzamSenetler.DataSource = Dosya.MunzamSenetler;
            else nbgMunzamSenet.Visible = false;

            if (Dosya.Sozlesmeler != null) gcSozlesmeler.DataSource = Dosya.Sozlesmeler;
            else nbgSozlesme.Visible = false;

            if (Dosya.Ipotekler != null) gcIpotekler.DataSource = Dosya.Ipotekler;
            else nbgIpotek.Visible = false;

            if (Dosya.Rehinler != null && Dosya.Rehinler.Count > 0) gcRehinler.DataSource = Dosya.Rehinler;
            else nbgRehin.Visible = false;

            List<Classes.AlacakTaraf> alacakTarafList = new List<Classes.AlacakTaraf>();

            if (Dosya.NakitAlacaklar != null) Dosya.NakitAlacaklar.ForEach(item =>
                {
                    item.Taraflari.ForEach(taraf =>
                        {
                            if (alacakTarafList.Find(vi => vi.Musteri == taraf.Musteri) == null)
                                alacakTarafList.Add(taraf);
                        });
                });
            if (Dosya.GayriNakitAlacaklar != null) Dosya.GayriNakitAlacaklar.ForEach(item =>
                {
                    item.Taraflari.ForEach(taraf =>
                        {
                            if (alacakTarafList.Find(vi => vi.Musteri == taraf.Musteri) == null)
                                alacakTarafList.Add(taraf);
                        });
                });

            if (alacakTarafList.Count > 0) gcKrediTaraflari.DataSource = alacakTarafList;
            else nbgKrediTaraf.Visible = false;

            #endregion Binding Kontrolleri

            #region Bind Taraf, Nakit, Gayrinakit Alacak, Sözleşme

            //Taraf, nakit ve gayrinakit alacaklar, sözleşmeler her durumda visible true parametresi ile getirileceğinden form tipi kontrolü içerisinde yapılmadı.

            //Tarafları Dosya propert'sinden almadık çünkü dosyada taraflar nakit ve gayrinakit diye ayrılmış, onların toplanmış hali de gcKrediTaraflari üzerinde.
            if (nbgKrediTaraf.Visible)
            {
                nbgKrediTaraf.Expanded = true;
                Methods.BindGrid(gcKrediTaraflari, gvKrediTaraflari.DataSource as List<Classes.AlacakTaraf>, true);
                gcKrediTaraflari.RefreshDataSource();
                TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.KrediTaraf);
            }

            //Diğer property'ler gridin datasource'u ile aynı olduğundan casting işlemi yapmadan Dosya üzerindeki ilgili property kullanılabilir.
            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.NakitAlacak);
            BindGridControlsAsFormTip(nbgNakitAlacak, gcNakitAlacaklar, true, Enums.DosyaBilesenleri.NakitAlacak, Dosya.NakitAlacaklar);
            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.GayrinakitAlacak);
            BindGridControlsAsFormTip(nbgGayrinakitAlacak, gcGayrinakitAlacaklar, true, Enums.DosyaBilesenleri.GayrinakitAlacak, Dosya.GayriNakitAlacaklar);
            TakibeAlinanBilesenler.Add((int)Enums.DosyaBilesenleri.Sozlesme);
            BindGridControlsAsFormTip(nbgSozlesme, gcSozlesmeler, true, Enums.DosyaBilesenleri.Sozlesme, Dosya.Sozlesmeler);

            #endregion Bind Taraf, Nakit, Gayrinakit Alacak, Sözleşme
        }

        public void BindGridControlsAsFormTip(DevExpress.XtraNavBar.NavBarGroup group, DevExpress.XtraGrid.GridControl grid, bool isSelected, Enums.DosyaBilesenleri bilesen, object deger)
        {
            if (group.Visible)//ise Collectionda değer vardır.
            {
                if (isSelected)
                {
                    group.Expanded = isSelected;
                    Methods.BindGrid(grid, deger, isSelected);
                    grid.RefreshDataSource();
                }
                else
                {
                    Methods.BindGrid(grid, deger, isSelected);
                    grid.RefreshDataSource();
                    if (TakipControls == null) TakipControls = new Dictionary<object, int>();
                    if (TakipControls.Where(vi => vi.Key == deger && vi.Value == (int)bilesen) == null)
                        TakipControls.Add(deger, (int)bilesen);
                }
            }
            else
            {
                if (isSelected)
                {
                    DialogResult drOnay = MessageBox.Show(bilesen.ToString() + " Dosyada mevcut değil.\r\nDevam etmek istiyor musunuz?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drOnay == DialogResult.No)
                    {
                        //Form ilk haline getirilir.
                        rgFormTipleri.EditValue = null;
                        BindGridContols();
                    }
                }
            }
        }

        public void Show(Classes.DosyaBilgileri dosya, CustomerData customer)
        {
            this.Dosya = dosya;
            this.Customer = customer;

            this.Show();
        }

        private void frmTakipAc_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(lueNo);

            BindGridContols();
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            AV001_TI_BIL_FOY yeniTakip = new AV001_TI_BIL_FOY();
            yeniTakip.FORM_TIP_ID = (int)rgFormTipleri.EditValue;
            yeniTakip.FOY_NO = Forms.Icra.frmIcraDosyaKayit.FoyNoGetir();

            //Atayan avukata aşağıdaki ekranın gösterilmesi istenmediğinden kaldırıldı. (Bahattin Çelik talebi)
            //if (dtTakipTarihi.EditValue != null) yeniTakip.TAKIP_TARIHI = (DateTime)dtTakipTarihi.EditValue;
            //else yeniTakip.TAKIP_TARIHI = DateTime.Now;

            //if (lueAdliye.EditValue != null) yeniTakip.ADLI_BIRIM_ADLIYE_ID = (int)lueAdliye.EditValue;

            //if (lueNo.EditValue != null) yeniTakip.ADLI_BIRIM_NO_ID = (int)lueNo.EditValue;

            //yeniTakip.ESAS_NO = string.Format("{0}/{1}", txtDosyaNoYil.Text, txtDosyaNumarasi.Text);
            yeniTakip.ADLI_BIRIM_GOREV_ID = (int)AdliBirimBolumGorev.ICRM;
            yeniTakip.FOY_DURUM_ID = 2;//DERDEST

            yeniTakip = Methods.SetTakipCollection(yeniTakip, Dosya, Customer, TakibeAlinanBilesenler);

            #region Dosya Atama Bilgileri

            AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA dosyaAtama = yeniTakip.AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMACollection.AddNew();
            dosyaAtama.SORUMLU_AVUKAT_CARI_ID = Customer.SorumluAvukatID;
            dosyaAtama.IZLEYEN_AVUKAT_CARI_ID = Customer.IzleyenAvukatID;
            dosyaAtama.KABUL_DURUM_ID = (int)Enums.DosyaAtamaKabulDurumlari.IslemBekliyor;
            dosyaAtama.DOSYAYI_ATAYAN_CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            dosyaAtama.ATAMA_TARIHI = DateTime.Now;

            #endregion Dosya Atama Bilgileri

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, yeniTakip, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<NN_ICRA_GAYRIMENKUL>), typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>), typeof(TList<AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA>));
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                foreach (var alacakNeden in yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, alacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                }
                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, yeniTakip.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(tran, yeniTakip.AV001_TDI_BIL_SOZLESMECollection_From_NN_ICRA_SOZLESME, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>), typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<NN_SOZLESME_GAYRIMENKUL>));

                tran.Commit();

                DataRepository.Provider.ExecuteNonQuery("dbo._NN_ICRA_GEMI_UCAK_ARAC_HacizKaydiOlustur", yeniTakip.ID);
                DataRepository.Provider.ExecuteNonQuery("dbo._NN_ICRA_GAYRIMENKUL_HacizKaydiOlustur", yeniTakip.ID);

                if (BelgeUtil.Inits._AlacakNEdenGetir != null)
                    BelgeUtil.Inits._AlacakNEdenGetir.AddRange(BelgeUtil.Inits.GetAlacakNedenViewItem(yeniTakip.AV001_TI_BIL_ALACAK_NEDENCollection));

                if (BelgeUtil.Inits._FoyTarafGetir != null)
                    BelgeUtil.Inits._FoyTarafGetir.AddRange(BelgeUtil.Inits.GetIcraFoyTarafViewItem(yeniTakip.AV001_TI_BIL_FOY_TARAFCollection));

                //Atamayı yapan kişiye aşağıdaki ekranın gelmesi istenmediğinden kapatıldı ve başka bir message box eklendi. (Bahattin Çelik talebi)
                //DialogResult dr = MessageBox.Show(string.Format("Aktarımdan gelen dosyadan, {0} raf numarası ile \r\nBAĞIMSIZ TAKİP oluşturuldu.\r\nTakip ekranına gitmek ister misiniz ?", yeniTakip.FOY_NO), "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dr == DialogResult.Yes)
                //{
                //    IcraTakipForms._frmIcraTakip frm = new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                //    frm.Show(yeniTakip.ID);
                //}

                string mailTo = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(Customer.SorumluAvukatID).EMAIL_1;
                AdimAdimDavaKaydi.Util.DosyaAvukatIliski.SendMail(mailTo, Methods.ReturnMailBody());

                MessageBox.Show("Atama işlemi tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Methods.RemoveXMLNode(Dosya.Musteri);

                #region Masraf ve Tahsilat İşlemleri

                Methods.DosyaMasrafIliskilendir(yeniTakip, Customer.CustomerID, Dosya.MusteriNo, tran);
                Methods.DosyaTahsilatIliskilendir(yeniTakip, Customer.CustomerID, Dosya.MusteriNo, tran);

                #endregion Masraf ve Tahsilat İşlemleri

                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                if (ex is System.Data.SqlClient.SqlException && ex.Message.Contains("uFOY_NO"))
                {
                    sbtnKaydet.PerformClick();
                }
            }
        }

        private void sbtnTakipAc_Click(object sender, EventArgs e)
        {
            if (rgFormTipleri.EditValue == null) return;

            FormTipi = (int)rgFormTipleri.EditValue;
        }
    }
}