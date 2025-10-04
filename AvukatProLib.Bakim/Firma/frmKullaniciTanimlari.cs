using AvukatProLib.Bakim.CariKayit;
using AvukatProLib.Bakim.Firma;
using AvukatProLib.Bakim.Resources;
using AvukatProLib.Bakim.UserKontrol;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmKullaniciTanimlari : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciTanimlari()
        {
            InitializeComponent();
        }

        private TList<TDI_BIL_KULLANICI_LISTESI> _MyDataSource;

        private TDI_BIL_KULLANICI_LISTESI _MyKullanici;

        private ucKullaniciYetki kul = new ucKullaniciYetki();

        private string KullaniciAdi = string.Empty;

        private string Sifre = string.Empty;

        private bool sifreAcik = false;

        public TList<TDI_BIL_KULLANICI_LISTESI> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                vgKullaniciListesi.DataSource = value;
                dnKullaniciListesi.DataSource = value;
            }
        }

        public TDI_BIL_KULLANICI_LISTESI MyKullanici
        {
            get
            {
                return _MyKullanici;
            }
            set
            {
                _MyKullanici = value;
            }
        }

        public void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            //KýsaAdGetir((int)MyKullanici.KULLANICI_GRUP_ID);
            //HashTool ht = new HashTool();
            //KullaniciAdi = MyKullanici.KULLANICI_ADI;
            //Sube_ID = MyKullanici.SUBE_ID;
            //string ilkdeger = KullaniciAdi.ToUpper() + Sube_ID.ToString().ToUpper();
            //string a = ht.CalculateMD5Hashing(ilkdeger);
            //Sifre = MyKullanici.KULLANICI_SIFRESI;
            //string ikincideger = Sifre.ToUpper() + Sube_ID.ToString().ToUpper();
            //string b = ht.CalculateMD5Hashing(ikincideger);
            if (Kaydet(MyDataSource))
            {
                dnKullaniciListesi.DataSource = MyDataSource;
                vgKullaniciListesi.DataSource = MyDataSource;
                dnKullaniciListesi.Refresh();
                vgKullaniciListesi.Refresh();

                XtraMessageBox.Show("Kullanýcý kaydý baþarýyla gerçekleþti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Kayýt iþlemi yapýlamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void KapanisDegerGetir()
        {
            if (kul.MyProperty != null)
            {
                CS_KOD_FORM_LISTESI liste = kul.MyProperty;
                popupContainerEdit1.Text = liste.FORM_ACIKLAMA;
                popupContainerEdit1.EditValue = liste.FORM_ACIKLAMA;
            }
        }

        public bool Kaydet(TDI_BIL_KULLANICI_LISTESI klist)
        {
            if (klist.HATALI_GIRIS == 3)
                klist.HATALI_GIRIS = 0;
            if (!klist.CARI_ID.HasValue)
            {
                MessageBox.Show(String.Format("{0} isimli kullanýcý için bir Þahýs baðlanmamýþ kayýt yapýlamaz", klist.KULLANICI_ADI), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                //trans.BeginTransaction();
                DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.DeepSave(klist);
                //trans.Commit();
                return true;
            }
            catch 
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);
                //if (trans.IsOpen)
                //    trans.Rollback();
                return false;
            }
        }

        public bool Kaydet(TList<TDI_BIL_KULLANICI_LISTESI> klist)
        {
            string isimler = string.Empty;
            foreach (TDI_BIL_KULLANICI_LISTESI usr in klist)
            {
                if (!usr.CARI_ID.HasValue)
                {
                    isimler += usr.KULLANICI_ADI + ",";
                }
            }
            if (isimler.Length > 0)
            {
                isimler = isimler.Remove(isimler.Length - 1);
            }

            //Eðer doluysa hata vardýr.
            if (!String.IsNullOrEmpty(isimler))
            {
                MessageBox.Show(String.Format("{0} isimli kullanýcý(lar) için bir Þahýs baðlanmamýþ kayýt yapýlamaz", isimler), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                foreach (var k in klist)
                {
                    if (k.HATALI_GIRIS == 3)
                        k.HATALI_GIRIS = 0;
                }
                //trans.BeginTransaction();
                DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.DeepSave(klist);
                //trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);
                //if (trans.IsOpen)
                //    trans.Rollback();
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void dnKullaniciListesi_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            //if (e.Button.Tag.ToString() == "Sil")
            //{
            //}
            //else
            //{
            if (!sifreAcik)
            {
                rtxtSifre.PasswordChar = new char();
                sifreAcik = true;
            }
            else
            {
                rtxtSifre.PasswordChar = '*';
                sifreAcik = false;
            }
            //}
        }

        private void frmKullaniciTanimlari_Load(object sender, EventArgs e)
        {
            kul.Dock = DockStyle.Fill;
            kul.Name = "KullaniciYetki";
            popupContainerControl1.Controls.Add(kul);

            MyDataSource = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
            MyDataSource.Filter = "GRUP_KISA_ADI != 'N'";
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            Inits.SubeGetir(rLueKullaniciSube);
            Inits.SubeGetir(rLueSube);
            Inits.CariGetir(rLueCari);
            Inits.KullaniciGrupGetir(rLueKullaniciGrup);
        }

        private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            KapanisDegerGetir();
            popupContainerEdit1.ClosePopup();
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDI_BIL_KULLANICI_LISTESI tlist = new TDI_BIL_KULLANICI_LISTESI();
            tlist.KULLANICI_GRUP_ID = 1;
            tlist.SUBE_ID = 2;
            tlist.HASHED_CODE = "HAYIR";
            tlist.STAMP = 1;
            tlist.KONTROL_VERSIYON = 1;
            tlist.KONTROL_KIM = "AVUKATPRO";
            tlist.KONTROL_NE_ZAMAN = DateTime.Now;
            tlist.KAYIT_TARIHI = DateTime.Now;
            tlist.STYLE = "Caramel";
            MyKullanici = tlist;
            MyKullanici.KULLANICI_SUBE_ID = MyKullanici.SUBE_ID;
            e.NewObject = tlist;
        }

        #region LookupDoldurma

        public void KýsaAdGetir(int grupid)
        {
            if (grupid > 0)
            {
                TDI_KOD_KULLANICI_GRUP grup = DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetByID(grupid);
                MyKullanici.GRUP_KISA_ADI = grup.KISA_ADI;
            }
        }

        #endregion LookupDoldurma

        #region Extender

        private void rLueCari_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button != null && e.Button.Tag is string && e.Button.Tag.ToString() == "mEkle")
            {
                Degisken.SubeKodu = MyKullanici.SUBE_ID;
                rfrmCariEkle cari = new rfrmCariEkle();
                if (cari.ShowDialog() == DialogResult.OK)
                {
                    TList<AV001_TDI_BIL_CARI> cariler = (rLueCari.DataSource as TList<AV001_TDI_BIL_CARI>);
                    if (cariler != null)
                    {
                        cariler.Add(cari.myCari);
                    }
                }
            }
        }

        private void rLueCari_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            rfrmCariEkle cari = new rfrmCariEkle();
            cari.CariAdi = e.DisplayValue.ToString();
            if (cari.ShowDialog() == DialogResult.OK)
            {
                TList<AV001_TDI_BIL_CARI> cariler = (rLueCari.DataSource as TList<AV001_TDI_BIL_CARI>);
                if (cariler != null)
                {
                    cariler.Add(cari.myCari);
                }
            }
        }

        #endregion Extender

        private void popupContainerEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            foreach (Control var in kul.Controls[0].Controls)
            {
                if (var.Name == "lslForumListesi")
                {
                    (var as ListBox).MouseDoubleClick += new MouseEventHandler(lst_MouseDoubleClick);
                }
            }
        }

        private void popupContainerEdit1_Closed(object sender, ClosedEventArgs e)
        {
            KapanisDegerGetir();
        }

        private void popupContainerEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            KapanisDegerGetir();
        }

        private void rLueKullaniciSube_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            if (e.Button.Tag != null && e.Button.Tag == "SubeEkle")
            {
                frmSubeEkle Sube = new frmSubeEkle();

                DialogResult dr = Sube.ShowDialog(lue.Text);
                if (dr == DialogResult.OK)
                {
                    TList<TDIE_BIL_KULLANICI_SUBELERI> dtSube = rLueKullaniciSube.DataSource as TList<TDIE_BIL_KULLANICI_SUBELERI>;
                    if (dtSube != null)
                    {
                        //dtSube.Add();
                    }
                    Inits.SubeGetir(rLueKullaniciSube);
                }
            }
        }

        private void rLueKullaniciSube_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;

            frmSubeEkle Sube = new frmSubeEkle();

            DialogResult dr = Sube.ShowDialog(lue.Text);
            if (dr == DialogResult.OK)
            {
                TList<TDIE_BIL_KULLANICI_SUBELERI> dtSube = rLueKullaniciSube.DataSource as TList<TDIE_BIL_KULLANICI_SUBELERI>;
                if (dtSube != null)
                {
                    //dtSube.Add();
                }
            }
        }
    }
}