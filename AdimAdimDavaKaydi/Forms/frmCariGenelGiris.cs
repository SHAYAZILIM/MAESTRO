using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmCariGenelGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmCariGenelGiris()
        {
            InitializeComponent();
            InitializeEvents();
            ucCari1.Load += ucCari1_Load;
            ucCari1.FocusedCariChanged += ucCari1_FocusedCariChanged;
        }

        public bool Firma;
        public DialogResult KayitBasarili = DialogResult.No;
        public bool KontrolEdildi = false;
        public AV001_TDI_BIL_CARI MyCari;
        public int SeciliPage = 0;//Genel Bilgiler
        public List<CariStatu> Statuler = new List<CariStatu>();
        private string _tmpCariAd = "";
        private bool _yeniKayitMi = true;
        private AV001_TDI_BIL_CARI cari;
        private string yeniKod = "";

        public string MusteriNo { get; set; }

        [Browsable(false)]
        public int MyCariId { get; set; }

        #region Uyap GeriBildirim

        private UyapGeriBildirim _uyapBildirim;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        public void UyapKimlikDuzenle()
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
        }

        #endregion Uyap GeriBildirim

        public string tmpCariAd
        {
            get { return _tmpCariAd; }
            set { _tmpCariAd = value.ToUpper(); }
        }

        [Browsable(false)]
        public bool YeniKayitMi
        {
            get { return _yeniKayitMi; }
            set
            {
                _yeniKayitMi = value;

                //if (value != null)
                //{
                //    if (value)
                //        ucCari1.crowFirma.Visible = false;
                //    else
                //        ucCari1.crowFirma.Visible = true;
                //}
            }
        }

        //private TList<AV001_TDI_BIL_CARI> personList = null;
        [Browsable(false)]
        public void Show(TList<AV001_TDI_BIL_CARI> persons)
        {
            ucCari1.aramadanMiGeliyor = true;
            ucCari1.MyDataSource = persons;
            ucSahisKimlikBilgileri1.MyDataSource = ucCari1.CurrentCari != null ? ucCari1.CurrentCari.AV001_TDI_BIL_CARI_KIMLIKCollection : null;

            ucSahisBankaBilgileri1.MyDataBankaSource = ucCari1.CurrentCari != null ? ucCari1.CurrentCari.AV001_TDI_BIL_CARI_BANKACollection : null;
            this.Show();
        }

        private void AV001_TDI_BIL_CARI_BANKACollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI_BANKA banka = new AV001_TDI_BIL_CARI_BANKA();

            //banka.ColumnChanged += banka_ColumnChanged;
            e.NewObject = banka;
        }

        private void AV001_TDI_BIL_CARI_KIMLIKCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI_KIMLIK kimlik = new AV001_TDI_BIL_CARI_KIMLIK();
            kimlik.ColumnChanged += kimlik_ColumnChanged;
            e.NewObject = kimlik;
        }

        private void frmCariGenelGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
        }

        private void frmCariGenelGiris_Load(object sender, EventArgs e)
        {
            //GridLookUpEdit ge = new GridLookUpEdit();
            //BelgeUtil.Inits.perCariGetirKimlikIletisim(ge);
            //RepositoryItemLookUpEdit rep = new RepositoryItemLookUpEdit ();
            //BelgeUtil.Inits.KurumsalGirisFormTipi(rep.Properties);

            if (YeniKayitMi)
            {
                if (Firma)
                {
                    cari.FIRMA_MI = true;
                    ucCari1.crowFirma.Visible = true;
                }
                else
                {
                    cari.FIRMA_MI = false;
                    ucCari1.crowFirma.Visible = false;
                }
            }
            else if (!YeniKayitMi)
            {
                if (MyCariId != 0)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(MyCariId);
                    if (cari.FIRMA_MI)
                        ucCari1.crowFirma.Visible = true;
                    else
                        ucCari1.crowFirma.Visible = false;
                }
                else if (MyCari != null)
                {
                    AV001_TDI_BIL_CARI cari = MyCari;
                    if (cari.FIRMA_MI)
                        ucCari1.crowFirma.Visible = true;
                    else
                        ucCari1.crowFirma.Visible = false;
                }
            }

            if (SeciliPage == 1)//Kimlik Bilgileri
                xtraTabControl1.SelectedTabPage = tabKimlikBilgileri;
            else
                xtraTabControl1.SelectedTabPage = tabSahisBilgileri;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += Kaydet_ItemClick;
        }

        private void Kaydet_ItemClick(object sender, EventArgs e)
        {
            if (!KontrolEdildi)
            {
                List<String> hatalar = new List<string>();
                for (int i = 0; i < ucCari1.MyDataSource.Count; i++)
                {
                    if (!ucCari1.MyDataSource[i].FIRMA_MI)
                    {
                        if (ucCari1.MyDataSource[i].AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
                            ucCari1.MyDataSource[i].VERGI_NO = ucCari1.MyDataSource[i].AV001_TDI_BIL_CARI_KIMLIKCollection[0].TC_KIMLIK_NO;
                    }
                    AV001_TDI_BIL_CARI carim = ucCari1.MyDataSource[i];

                    if (String.IsNullOrEmpty(carim.AD.Trim()))
                    {
                        hatalar.Add(String.Format("{0} numaralı kayıtta AD bölümü boş geçilmiş", i + 1));
                    }
                    if (!carim.FIRMA_MI && carim.AD.Trim().Split(' ').Length == 1)
                    {
                        hatalar.Add(String.Format("{0} numaralı kayıtta AD bölümü şahıs olduğu halde soyad girilmemiş", i + 1));
                    }
                }
                if (hatalar.Count > 0)
                {
                    string birlestirilmisHata = string.Empty;
                    foreach (string str in hatalar)
                    {
                        birlestirilmisHata += Environment.NewLine + str;
                    }
                    XtraMessageBox.Show("Aşağıda bulunana hata(lar) dan dolayı kayıt işlemine devam edilemiyor. Lütfen düzelterek tekrar kaydediniz" + birlestirilmisHata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<String> uyapHatalar = new List<string>();

                for (int i = 0; i < ucCari1.MyDataSource.Count; i++)
                {
                    AV001_TDI_BIL_CARI carim = ucCari1.MyDataSource[i];
                    if (String.IsNullOrEmpty(carim.ADRES_1.Trim()))
                    {
                        uyapHatalar.Add(
                            String.Format("{0} numaralı kayıtta ADRES_1 bölümü Uyap için zorunlu alandır. Boş geçilmiş",
                                          i + 1));
                    }
                    if (!carim.IL_ID.HasValue)
                    {
                        uyapHatalar.Add(
                            String.Format("{0} numaralı kayıtta İl bölümü Uyap için zorunlu alandır. Boş geçilmiş", i + 1));
                    }
                    if (!carim.ILCE_ID.HasValue)
                    {
                        uyapHatalar.Add(
                            String.Format("{0} numaralı kayıtta İlçe bölümü Uyap için zorunlu alandır. Boş geçilmiş", i + 1));
                    }

                    if (carim.PERSONEL_MI && carim.AVUKAT_MI)
                    {
                        if (String.IsNullOrEmpty(carim.VERGI_NO.Trim()))
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralı kayıtta Vergi No bölümü Uyap için zorunlu alandır. Boş geçilmiş", i + 1));
                        }
                        if (String.IsNullOrEmpty(carim.VERGI_DAIRESI.Trim()))
                        {
                            uyapHatalar.Add(
                                String.Format(
                                    "{0} numaralı kayıtta Vergi Dairesi bölümü Uyap için zorunlu alandır. Boş geçilmiş",
                                    i + 1));
                        }
                    }
                }

                if (uyapHatalar.Count > 0)
                {
                    string birlestirilmisHata = string.Empty;
                    foreach (string str in uyapHatalar)
                    {
                        birlestirilmisHata += Environment.NewLine + str;
                    }
                    DialogResult dr = XtraMessageBox.Show("Aşağıda bulunan alan(lar) Uyap için zorunludur. Boş geçmek istediğinize emin misiniz?" + birlestirilmisHata, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    KontrolEdildi = true;
                    if (dr == DialogResult.No)
                        return;
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                if (YeniKayitMi)
                {
                    //var kod = BelgeUtil.Inits._per_CariGetir.OrderByDescending(vi => vi.ID).FirstOrDefault().KOD;
                    //cari.KOD = (Convert.ToInt32(kod) + 2).ToString();
                    //string kod = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_CARIs where item.KOD != null &&  != string.Empty orderby item.ID descending select item.KOD).FirstOrDefault();

                    YeniKodGetir();
                    string kod = yeniKod;

                    foreach (var item in ucCari1.MyDataSource)
                    {
                        try
                        {
                            kod = (Convert.ToInt32(kod) + 1).ToString();
                            item.KOD = kod;
                        }
                        catch
                        { ; }
                    }
                }

                foreach (var cari in ucCari1.MyDataSource)
                {
                    //Aynı tck'lı şahsın kaydının engellenmesini sağlayan blok
                    foreach (var kimlik in cari.AV001_TDI_BIL_CARI_KIMLIKCollection)
                    {
                        if (YeniKayitMi)
                        {
                            if (!string.IsNullOrEmpty(kimlik.TC_KIMLIK_NO.Trim()) && AvukatPro.Services.Implementations.CariService.GetCariByTcKimlikNo(kimlik.TC_KIMLIK_NO.Trim()) != null)
                            {
                                if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı Tc Kimlik numarasını taşıyan şahıs bulunmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error).Equals(DialogResult.OK))
                                    return;
                            }
                        }
                        else
                        {
                            if (AvukatPro.Services.Implementations.CariService.GetCariByTcKimlikNo(kimlik.TC_KIMLIK_NO.Trim()) != null && AvukatPro.Services.Implementations.CariService.GetCariByTcKimlikNo(kimlik.TC_KIMLIK_NO.Trim()).Ad != cari.AD)
                            {
                                if (!string.IsNullOrEmpty(kimlik.TC_KIMLIK_NO.Trim()))
                                {
                                    if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı Tc Kimlik numarasını taşıyan şahıs bulunmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error).Equals(DialogResult.OK))
                                        return;
                                }
                            }
                        }
                    }

                    //if (YeniKayitMi)
                    //{
                    //    if ((!string.IsNullOrEmpty(cari.VERGI_NO) && AvukatPro.Services.Implementations.CariService.GetCariByVergiNo(cari.VERGI_NO) != null))
                    //    {
                    //        if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı Vergi numarasını taşıyan şahıs bulunmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error).Equals(DialogResult.OK))
                    //            return;
                    //    }
                    //}
                    //else
                    //{
                    //    if (AvukatPro.Services.Implementations.CariService.GetCariById(cari.ID).VergiNo != cari.VERGI_NO && AvukatPro.Services.Implementations.CariService.GetCariByAd(cari.VERGI_NO) != null)
                    //    {
                    //        if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı Vergi numarasını taşıyan şahıs bulunmaktadır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error).Equals(DialogResult.OK))
                    //            return;
                    //    }
                    //}

                    if (YeniKayitMi)
                    {
                        if (AvukatPro.Services.Implementations.CariService.GetCariByAd(cari.AD) != null)
                        {
                            if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı isimde başka bir şahıs bulunmaktadır. Kaydetmek istiyormusunuz ?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                                return;
                        }
                    }
                    else
                    {
                        if (AvukatPro.Services.Implementations.CariService.GetCariById(cari.ID).Ad != cari.AD && AvukatPro.Services.Implementations.CariService.GetCariByAd(cari.AD) != null)
                        {
                            if (XtraMessageBox.Show("Kaydetmeye çalıştığınız şahıs ile aynı isimde başka bir şahıs bulunmaktadır. Kaydetmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                                return;
                        }
                    }
                }

                tran.BeginTransaction();
                BelgeUtil.Inits.context.CommandTimeout = 99999999;
                DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(tran, ucCari1.MyDataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TList<AV001_TDI_BIL_CARI_BANKA>), typeof(TList<AV001_TDI_BIL_CARI_UNVAN_DEGISIKLIK>));
                KontrolEdildi = false;
                MyCariId = ucCari1.MyDataSource[0].ID;

                //if (YeniKayitMi)
                //{
                //    if (BelgeUtil.Inits._per_CariGetir == null)
                //        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                //    ucCari1.MyDataSource.ForEach(item => BelgeUtil.Inits._per_CariGetir.Add(BelgeUtil.Inits.GetCariViewItem(item)));
                //}
                //else
                //{
                //    if (BelgeUtil.Inits._per_CariGetir == null)
                //        BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();
                //    var currentCari = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == MyCari.ID);
                //    BelgeUtil.Inits._per_CariGetir.Remove(currentCari);
                //    currentCari = BelgeUtil.Inits.GetCariViewItem(MyCari);
                //    BelgeUtil.Inits._per_CariGetir.Add(currentCari);
                //}
                //if (ucCari1.MyDataSource.Count > 0)
                //    MyCari = ucCari1.MyDataSource[0];
                //if (CariKaydedildi != null)
                //    CariKaydedildi(this, new CariKaydedildiEventArgs(MyCari));

                tran.Commit();

                //Inits.CariGetirRefersh();
                KayitBasarili = DialogResult.OK;

                if (ucCari1.IsimBilgisiGuncellendi)
                    MessageBox.Show(string.Format("Şahıs başarıyla kaydedildi.\r\n Şahsın isim bilgisi {0} olarak güncellendi.", MyCari.AD), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Şahıs başarıyla kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

                if (DialogResult == DialogResult.OK)
                    Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();

                if (ex is SqlException && ex.Message.ToLower().Contains("duplicate key") || ex.Message.ToLower().Contains("uKOD"))
                {
                    Kaydet_ItemClick(this, new EventArgs());
                }
            }
            //BelgeUtil.Inits.SorumluAvukatGetirRefresr();
        }

        private void kimlik_ColumnChanged(object sender, AV001_TDI_BIL_CARI_KIMLIKEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_CARI_KIMLIKColumn.TC_KIMLIK_NO)
            {
                if (cari != null)
                {
                    cari.VERGI_NO = e.Value.ToString();
                }
            }
        }

        private void ucCari1_FocusedCariChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            ucSahisKimlikBilgileri1.MyDataSource = ucCari1.CurrentCari != null ? ucCari1.CurrentCari.AV001_TDI_BIL_CARI_KIMLIKCollection : null;
            ucSahisBankaBilgileri1.MyDataBankaSource = ucCari1.CurrentCari != null ? ucCari1.CurrentCari.AV001_TDI_BIL_CARI_BANKACollection : null;
        }

        private void ucCari1_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (YeniKayitMi)
            {
                cari = ucCari1.MyDataSource.AddNew();
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlik.SirketBilgisi.ConStr;

                //string kod = cn.ExecuteScalar("SELECT MAX(KOD) FROM dbo.AV001_TDI_BIL_CARI(nolock)").ToString();
                //try
                //{
                //    cari.KOD = (Convert.ToInt32(kod) + 1).ToString();
                //}
                //catch { ;}

                YeniKodGetir();
                string kod = yeniKod;

                foreach (var item in ucCari1.MyDataSource)
                {
                    try
                    {
                        kod = (Convert.ToInt32(kod) + 1).ToString();
                        cari.KOD = kod;
                    }
                    catch
                    { ; }
                }

                //Müşteri no bilgisi entegrasyon sırasında gelmeişse addingnew'de verilmesi sağlandı.
                if (!string.IsNullOrEmpty(MusteriNo)) cari.MUSTERI_NO = MusteriNo;
                if (Firma)
                    cari.FIRMA_MI = true;
                else
                    cari.FIRMA_MI = false;
                cari.AKTIF_ADRES = true;
                cari.RESIM = null;
                cari.ADRES_TUR_ID = 1;
                cari.ADRES2_TUR_ID = 1;
                cari.ULKE_ID = 1;
                cari.ULKE2_ID = 1;

                //cari.FIRMA_MI = false;
                string tmpStatu = "";
                foreach (AvukatProLib.Extras.CariStatu statu in Statuler)
                {
                    tmpStatu += statu.ToString().Replace("_", " ") + ",";
                }
                if (tmpStatu.Length > 0)
                    tmpStatu = tmpStatu.Remove(tmpStatu.Length - 1, 1);

                cari.KARSI_TARAF_MI = true;
                cari.AV001_TDI_BIL_CARI_KIMLIKCollection.AddingNew += AV001_TDI_BIL_CARI_KIMLIKCollection_AddingNew;
                cari.AV001_TDI_BIL_CARI_KIMLIKCollection.AddNew();
                cari.AV001_TDI_BIL_CARI_BANKACollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_CARI_BANKACollection_AddingNew);
                ucSahisKimlikBilgileri1.MyDataSource = cari.AV001_TDI_BIL_CARI_KIMLIKCollection;
                ucSahisBankaBilgileri1.MyDataBankaSource = cari.AV001_TDI_BIL_CARI_BANKACollection;
                ucCari1.crowFirma.Visible = false;
            }
            else if (!YeniKayitMi)
            {
                if (MyCariId != 0)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(MyCariId);
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    ucCari1.MyDataSource.Add(cari);
                    ucSahisKimlikBilgileri1.MyDataSource = cari.AV001_TDI_BIL_CARI_KIMLIKCollection;
                    ucSahisBankaBilgileri1.MyDataBankaSource = cari.AV001_TDI_BIL_CARI_BANKACollection;

                    if (cari.FIRMA_MI)
                        ucCari1.crowFirma.Visible = true;
                    else
                        ucCari1.crowFirma.Visible = false;
                }
                else if (MyCari != null)
                {
                    AV001_TDI_BIL_CARI cari = MyCari;
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    ucCari1.MyCari = cari;
                    ucCari1.MyDataSource.Add(cari);
                    ucSahisKimlikBilgileri1.MyDataSource = cari.AV001_TDI_BIL_CARI_KIMLIKCollection;
                    ucSahisBankaBilgileri1.MyDataBankaSource = cari.AV001_TDI_BIL_CARI_BANKACollection;

                    if (cari.FIRMA_MI)
                        ucCari1.crowFirma.Visible = true;
                    else
                        ucCari1.crowFirma.Visible = false;
                }
            }

            //this.compRibbonExtender1.LoadMainMenu = true;
            //this.compRibbonExtender1.RibbonForExtend = null;
            //this.compRibbonExtender1.RibbonFormForExtend = this;
        }

        private void YeniKodGetir()
        {
            string NotIn = "";
            string kod = "";

            for (int i = 0; i < 2; i++)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlik.SirketBilgisi.ConStr;

                kod = cn.ExecuteScalar("SELECT MAX(CONVERT(INT,KOD)) FROM dbo.AV001_TDI_BIL_CARI(nolock) WHERE KOD NOT IN('CARI', 'HASIMSIZ', 'KAMU')" + (string.IsNullOrEmpty(NotIn) ? "" : (NotIn + ")"))).ToString();

                try
                {
                    Convert.ToInt32(kod);
                }
                catch
                {
                    if (string.IsNullOrEmpty(NotIn))
                        NotIn = " and KOD NOT IN('-1'" + ",'" + kod + "'";
                    else
                        NotIn += ",'" + kod + "'";

                    i = 0;
                }
            }

            yeniKod = kod;
        }
    }
}