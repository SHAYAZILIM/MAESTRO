using AvukatProLib.AVPLicence;
using AvukatProLib.PaketYonetimi;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProLib.Util
{
    /// <summary>
    /// Yetkilendirme iþlemlerinde kullanýlan sýnýf.
    /// </summary>
    public class AuthHelperBase
    {
        /// <summary>
        /// Yeni bir AuthHelper örneði oluþturur.
        /// </summary>
        public AuthHelperBase()
        { }

        /// <summary>
        /// Yeni bir AuthHelper örneði oluþturur.
        /// </summary>
        /// <param name="yetkiCumlesi">Örneði yapýlandýracak yetki cümlesi</param>
        public AuthHelperBase(string yetkiCumlesi)
        {
            YetkiCumlesi = yetkiCumlesi;
        }

        public AuthHelperBase(AvukatProLib2.Entities.CS_KOD_FORM_LISTESI formList)
        {
            YetkiCumlesi = "0000000000000000";
            KullaniciYetki = new CS_KOD_FORM_KULLANICI_YETKI();
            KullaniciYetki.FORM_ID = formList.ID;
            Form_Aciklama = formList.FORM_ACIKLAMA;
        }

        public AuthHelperBase(CS_KOD_KULLANICI_GRUP_YETKI formList)
        {
            YetkiCumlesi = formList.YETKI_CUMLESI;

            GrupYetki = formList;
            if (formList.FORM_ID > 0)
            {
                AvukatProLib2.Entities.CS_KOD_FORM_LISTESI list = DataRepository.CS_KOD_FORM_LISTESIProvider.GetByID(formList.FORM_ID);

                Form_Aciklama = list.FORM_ACIKLAMA;
            }
            else if (formList.GRUP_ID > 0)
            {
                CS_KOD_FORM_GRUP list = DataRepository.CS_KOD_FORM_GRUPProvider.GetByID(formList.GRUP_ID);
                Form_Aciklama = list.GRUP_ADI;
            }
        }

        /// <summary>
        /// Yeni bir AuthHelper örneði oluþturur.
        /// </summary>
        /// <param name="yetki">Db yetki nesne örneði</param>
        public AuthHelperBase(CS_KOD_FORM_KULLANICI_YETKI yetki)
        {
            KullaniciYetki = yetki;
            YetkiCumlesi = yetki.YETKI_CUMLESI;
        }

        private static AvukatProLib.PaketYonetimi.FormReaderOffline reader = null;

        private string _Form_Aciklama;
        private bool _FormAcabilir;
        private CS_KOD_KULLANICI_GRUP_YETKI _GrupYetki;
        private bool _Kaydedebilir;
        private CS_KOD_FORM_KULLANICI_YETKI _KullaniciYetki;
        private bool _MenuGorebilir;
        private bool _MenuTiklayabilir;
        private string _YetkiCumlesi;

        public string Form_Aciklama
        {
            get { return _Form_Aciklama; }
            set { _Form_Aciklama = value; }
        }

        public bool FormAcabilir
        {
            get { return _FormAcabilir; }
            set { _FormAcabilir = value; cumleYapilandir(); }
        }

        // private int _FormId;
        [DataObjectField(false, false, false)]
        [Description("")]
        [Bindable(true)]
        public int? FormId
        {
            get
            {
                if (KullaniciYetki != null)
                {
                    return KullaniciYetki.FORM_ID;
                }
                else
                    return null;
            }
            set
            {
                if (KullaniciYetki != null)
                {
                    KullaniciYetki.FORM_ID = value ?? 0;
                }
            }
        }

        public int? GrupId
        {
            get
            {
                if (GrupYetki != null)
                {
                    return GrupYetki.GRUP_ID;
                }
                else
                    return null;
            }
            set
            {
                if (KullaniciYetki != null)
                {
                    GrupYetki.GRUP_ID = value ?? 0;
                }
            }
        }

        public CS_KOD_KULLANICI_GRUP_YETKI GrupYetki
        {
            get { return _GrupYetki; }
            set { _GrupYetki = value; }
        }

        public bool Kaydedebilir
        {
            get { return _Kaydedebilir; }
            set { _Kaydedebilir = value; cumleYapilandir(); }
        }

        public int? KullaniciId
        {
            get
            {
                if (KullaniciYetki != null)
                {
                    return KullaniciYetki.KULLANICI_ID;
                }
                else
                    return null;
            }
            set
            {
                if (KullaniciYetki != null)
                {
                    KullaniciYetki.KULLANICI_ID = value ?? 0;
                }
            }
        }

        public CS_KOD_FORM_KULLANICI_YETKI KullaniciYetki
        {
            get { return _KullaniciYetki; }
            set { _KullaniciYetki = value; }
        }

        public bool MenuGorebilir
        {
            get { return _MenuGorebilir; }
            set { _MenuGorebilir = value; cumleYapilandir(); }
        }

        public bool MenuTiklayabilir
        {
            get { return _MenuTiklayabilir; }
            set { _MenuTiklayabilir = value; cumleYapilandir(); }
        }

        public string YetkiCumlesi
        {
            get { return _YetkiCumlesi; }
            set
            {
                _YetkiCumlesi = value;
                yetkiYapilandir(value);
            }
        }

        private void cumleYapilandir()
        {
            _YetkiCumlesi = String.Format("{0}{1}{2}{3}", Convert.ToSByte(_FormAcabilir), Convert.ToSByte(_Kaydedebilir), Convert.ToSByte(_MenuGorebilir), Convert.ToSByte(_MenuTiklayabilir));
            if (this._KullaniciYetki != null)
            {
                this._KullaniciYetki.YETKI_CUMLESI = _YetkiCumlesi;
            }
            else if (this._GrupYetki != null)
            {
                this._GrupYetki.YETKI_CUMLESI = _YetkiCumlesi;
            }
        }

        /// <summary>
        /// Verilen yetki cümlesine göre bulunduðu nesne örneðini yapýlandýrýr
        /// </summary>
        /// <param name="yetkiCumlesi">1 ve 0 lardan oluþan sayý dizisi</param>
        private void yetkiYapilandir(string yetkiCumlesi)
        {
            if (yetkiCumlesi.Length > 0)
                _FormAcabilir = yetkiCumlesi[0] == '1' ? true : false;
            if (yetkiCumlesi.Length > 1)
                _Kaydedebilir = yetkiCumlesi[1] == '1' ? true : false;
            if (yetkiCumlesi.Length > 2)
                _MenuGorebilir = yetkiCumlesi[2] == '1' ? true : false;
            if (yetkiCumlesi.Length > 3)
                _MenuTiklayabilir = yetkiCumlesi[3] == '1' ? true : false;
        }

        #region Static Elemanlar

        /// <summary>
        /// Verilen kullanýcý Id ve form adýna göre AuthHelper tipinde yetkilendirme getirir. Ýlgili yetki tabloda bulunmadýðýnda null geri döner.
        /// </summary>
        /// <param name="kullaniciId">Yetkisini öðrenmek istediðimiz kullanýcýnýn ID si</param>
        /// <param name="formFullName">Yetkisini öðrenmek istediðimiz form adý.</param>
        /// <returns>Yetki bulunduðunda yetkilerin yapýlandýrýlmýþ halini döndürür. Yetki bulunmadýðýnda null döndürür.</returns>
        public static AuthHelperBase GetAuthHelper(int kullaniciId, string formFullName)
        {
            // Okan 04.01.2010 Performans Çalýþmasý
            TList<CS_KOD_FORM_KULLANICI_YETKI> yetkiler = DataRepository.CS_KOD_FORM_KULLANICI_YETKIProvider.GetByKullaniciIdFormFullAdi(kullaniciId, formFullName);
            if (yetkiler.Count > 0)
            {
                AuthHelperBase hlp = new AuthHelperBase(yetkiler[0]);
                return hlp;
            }

            return null;
        }

        /// <summary>
        /// Verilen kullanýcý Id ve form adýna göre AuthHelper tipinde yetkilendirme getirir. Ýlgili yetki tabloda bulunmadýðýnda null geri döner.
        /// </summary>
        /// <param name="kullaniciId">Yetkisini öðrenmek istediðimiz kullanýcýnýn ID si</param>
        /// <param name="formName">Yetkisini öðrenmek istediðimiz form adý.</param>
        /// <param name="controlName">Yetkisini öðrenmek istediðimiz form üzerindeki kontrol adý</param>
        /// <returns>Yetki bulunduðunda yetkilerin yapýlandýrýlmýþ halini döndürür. Yetki bulunmadýðýnda null döndürür.</returns>
        public static AuthHelperBase GetAuthHelper(int kullaniciId, string formName, string controlName)
        {
            return GetAuthHelper(kullaniciId, String.Format("{0}#{1}", formName, controlName));
        }

        #endregion Static Elemanlar

        #region Paket

        public static List<AvukatProLib.PaketYonetimi.ControlItem> CachedControlItems = new List<AvukatProLib.PaketYonetimi.ControlItem>();

        public static List<string> loadedControlList = new List<string>();

        private static PaketBilgisi _AktifPaketBilgisi;

        private static List<PaketBilgisi> _PaketKontrolList;

        private static PaketForm aktifForm = null;

        internal static PaketBilgisi AktifPaketBilgisi
        {
            get
            {
                if (/*_AktifPaketBilgisi == null &&*/ PaketKontrolList != null)
                    _AktifPaketBilgisi = PaketKontrolList.Find(item => item.PaketAdi == Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.PaketAdi);
                return _AktifPaketBilgisi;
            }
        }

        //static List<PaketElemanlari> _PaketKontrolList;
        //internal static List<PaketElemanlari> PaketKontrolList
        //{
        //    get
        //    {
        //        if (_PaketKontrolList == null && Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.PaketElemanlari != null)
        //            _PaketKontrolList = new List<PaketElemanlari>(Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.PaketElemanlari);
        //        return _PaketKontrolList;
        //    }
        //}
        internal static List<PaketBilgisi> PaketKontrolList
        {
            get
            {
                _PaketKontrolList = FormReaderHelper.Packets;
                return _PaketKontrolList;
            }
        }

        /// <summary>
        /// Tree yapýsýnda gonderilen menu itemlari CS_KOD_FORM_LISTESI tablosuna aktarýr.
        /// </summary>
        /// <param name="menuItem"></param>
        public static void ApplyAuthorization(MenuItem menuItem)
        {
            /* Okan 04.01.2010 Performans Çalýþmasý
            if (menuItem != null)
            {
                //ilk itemin root olma sartýna bakar.
                if (menuItem.Name.ToUpper() == "ROOT")
                    foreach (MenuItem item in menuItem.ListMenu)
                    {
                        item.RootID = 0;
                        ApplyAuthorizationChild(item);
                    }
            }
             */
        }

        /// <summary>
        /// Verilen form adý, form üzerinde yer alan kontrollere ve kontrolün metinine göre CS_KOD_FORM_LISTESI tablosuna form üzerinde týklanabilir deðerler eklenir.
        /// </summary>
        /// <param name="formFullName">Yetkilendirmek istediðimiz formun tam adý.</param>
        /// <param name="controlName">Yetkilendirmek istediðimiz form üzerindeki kontrol adý</param>
        /// <param name="controlText">Yetkilendirmek istediðimiz formun görünen ad bilgisi</param>
        public static AvukatProLib2.Entities.CS_KOD_FORM_LISTESI ApplyAuthorization(string formFullName, string controlName, int modulNo, string controlText)
        {
            string FullAdi = formFullName + '#' + controlName;
            AvukatProLib2.Entities.CS_KOD_FORM_LISTESI tmp = new AvukatProLib2.Entities.CS_KOD_FORM_LISTESI();
            /* Okan 04.01.2010 Performans Çalýþmasý
            TList<CS_KOD_FORM_LISTESI> list = DataRepository.CS_KOD_FORM_LISTESIProvider.Find("FULL_ADI = '" + FullAdi + "'");

            if (list.Count <= 0)
                tmp = DataRepository.CS_KOD_FORM_LISTESIProvider.Save(CS_KOD_FORM_LISTESIBase.CreateCS_KOD_FORM_LISTESI(formFullName + "#" + controlName, controlText, "1", "1", 2, "1", "1", modulNo, 1, 2, true, DateTime.Now, 10002, 1, 1));
            else
                tmp = list[0];
             * */
            return tmp;
        }

        /// <summary>
        /// Verilen form adý, form üzerinde yer alan kontrollere ve kontrolün metinine göre CS_KOD_FORM_LISTESI tablosuna form üzerinde týklanabilir deðerler eklenir.
        /// </summary>
        /// <param name="formFullName">Yetkilendirmek istediðimiz formun tam adý.</param>
        /// <param name="controlName">Yetkilendirmek istediðimiz form üzerindeki kontrol adý</param>
        /// <param name="controlText">Yetkilendirmek istediðimiz formun görünen ad bilgisi</param>
        public static void ApplyAuthorization(string formFullName, string controlName, string controlText)
        {
            /* Okan 04.01.2010 Performans Çalýþmasý
            string FullAdi = formFullName + '#' + controlName;

            TList<CS_KOD_FORM_LISTESI> list = DataRepository.CS_KOD_FORM_LISTESIProvider.Find("FULL_ADI = '" + FullAdi + "'");

            if (list.Count <= 0)
                DataRepository.CS_KOD_FORM_LISTESIProvider.Save(CS_KOD_FORM_LISTESIBase.CreateCS_KOD_FORM_LISTESI(formFullName + "#" + controlName, controlText, "1", "1", 2, "1", "1", 0, 1, 2, true, DateTime.Now, Kimlikci.Kimlik.Bilgi.ID, 1, 1));
            */
        }

        public static TList<AvukatProLib2.Entities.CS_KOD_FORM_LISTESI> PaketeGoreFormListesiGetir(int modulNo)
        {
            if (!EntityBase.BagliSubeId.HasValue)
                return new TList<AvukatProLib2.Entities.CS_KOD_FORM_LISTESI>();
            TList<AvukatProLib2.Entities.CS_KOD_PAKET> paketler = DataRepository.CS_KOD_PAKETProvider.Find(String.Format("MODUL_NO = '{0}'", modulNo));
            if (paketler != null && paketler.Count > 0)
            {
                //Kayit tek gelebileceði için
                AvukatProLib2.Entities.CS_KOD_PAKET paketim = paketler[0];
                DataRepository.CS_KOD_PAKETProvider.DeepLoad(paketim, false, DeepLoadType.IncludeChildren, typeof(TList<AvukatProLib2.Entities.CS_KOD_FORM_LISTESI>));
                return paketler[0].CS_KOD_FORM_LISTESICollection_From_CS_KOD_PAKET_NN_FORM;
            }
            else
                return null;
        }

        public static void PaketKontrol(Form form)
        {
            if (form == null)
                return;
            if (reader == null)
                reader = new PaketYonetimi.FormReaderOffline();

            DateTime dt = DateTime.Now;
            Console.WriteLine("Paket Start: " + DateTime.Now);
            if (AktifPaketBilgisi == null || AktifPaketBilgisi.PaketAdi == "*")
                return;

            aktifForm = new List<PaketForm>(AktifPaketBilgisi.FormListesi).Find(item => item.FormAdi == form.GetType().FullName);
            if (aktifForm == null) return;

            //if (!loadedControlList.Contains(form.Name))
            //{
            reader.AnalyzeSelectedForm(form);
            //loadedControlList.Add(form.Name);
            //}
            var paket = FormReaderHelper.Packets.Where(w => w.PaketAdi == AktifPaketBilgisi.PaketAdi).FirstOrDefault();

            var paketforms = paket.FormListesi.Where(q => q.FormAdi == form.Name);

            if (paketforms.Count() > 1)
                throw new Exception("Hatalý Paket Konfigurasyonu. Lütfen Avukatpro ile iþetiþime geçiniz.");

            var paketform = paket.FormListesi.Where(q => q.FormAdi == form.GetType().FullName).FirstOrDefault();

            var ctrl = reader.packItems[paketform.FormAdi][paket.PaketAdi].ToList();

            if (ctrl.Count > 0)
            {
                foreach (var item in ctrl)
                {
                    var dlk2 = paketform.KontrolListesi.Where(q => q.RelativePath == item.RelativePath && q.KontrolAdi == item.Name);
                    if (dlk2.Count() > 1)
                    {
                    }
                    var dlk = dlk2.FirstOrDefault();
                    if (dlk != null)
                    {
                        item.Visible = dlk.Gorunur;
                        item.Enabled = dlk.Aktif;
                        item.ShowInCustomizationForm = dlk.Sepette_Goster;
                        item.ShowInAccessList = dlk.Yetkilendirmede_Kullan;
                    }

                    //else
                    //{
                    //    item.Visible = true;
                    //    item.Enabled = true;
                    //}
                    //if (item.csControlProperties != null && item.csControlProperties.GORUNUR_MU.HasValue/* && item.Visible != Convert.ToBoolean(item.csControlProperties.GORUNUR_MU)*/)
                    //    item.Visible = Convert.ToBoolean(item.csControlProperties.GORUNUR_MU);
                    //if (item.csControlProperties != null && item.csControlProperties.AKTIF_MI.HasValue/* && item.Enabled != Convert.ToBoolean(item.csControlProperties.AKTIF_MI)*/) item.Enabled = Convert.ToBoolean(item.csControlProperties.AKTIF_MI);
                    //if (item.csControlProperties != null && item.csControlProperties.SEPETTE_GOSTERILSIN_MI.HasValue/* && item.ShowInCustomizationForm != Convert.ToBoolean(item.csControlProperties.SEPETTE_GOSTERILSIN_MI)*/) item.ShowInCustomizationForm = Convert.ToBoolean(item.csControlProperties.SEPETTE_GOSTERILSIN_MI);
                    //if (item.csControlProperties != null && item.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI.HasValue/* && item.ShowInAccessList != Convert.ToBoolean(item.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI)*/) item.ShowInAccessList = Convert.ToBoolean(item.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI);
                }
            }
        }

        public static void PaketKontrol(Form form, Component control)
        {
            PaketKontrol(form);

            //if (aktifForm != null && aktifForm.FormAdi == form.GetType().FullName)
            //{
            //  if (loadedControlList.Contains(control.Name)) return;

            #region burda takýlýyor

            ////if (AktifPaketBilgisi == null) return;
            ////List<PaketForm> frmList = AktifPaketBilgisi.FormListesi.Where(item => item.FormAdi == form.GetType().FullName).ToList();
            ////aktifForm = frmList.Count > 0 ? frmList[0] : null;
            ////if (aktifForm == null) return;
            ////loadedControlList.Add(GetPropertyValue(control, "Name").ToString());

            ////aktifForm.KontrolListesi.Where(item => !item.Gorunur).ToList().ForEach(item =>
            ////{
            ////    var ctrl = AvukatProLib.PaketYonetimi.FormReader.GetControlByPath(String.Format("{0}.{1}", item.RelativePath, item.KontrolAdi), form);
            ////    if (ctrl != null)
            ////    {
            ////        AvukatProLib.PaketYonetimi.ControlItem ctrlItem = new AvukatProLib.PaketYonetimi.ControlItem();
            ////        ctrlItem.Control = ctrl;
            ////        ctrlItem.Visible = item.Gorunur;
            ////        ctrlItem.ShowInCustomizationForm = item.Sepette_Goster;
            ////        ctrlItem.ShowInAccessList = item.Yetkilendirmede_Kullan;
            ////        ctrlItem.Enabled = item.Aktif;
            ////    }
            ////});

            #endregion burda takýlýyor

            //    List<AvukatProLib.PaketYonetimi.ControlItem> subControls = GetControlsList(control);
            //    //var identicalQuery = from item in aktifForm.KontrolListesi
            //    //                     join ctrlItem in subControls on item.UniqueId equals ctrlItem.FullPath.GetHashCode()
            //    //                     select new { Item1 = item, Item2 = ctrlItem };
            //    string ctrlName = subControls[0].Name;
            //    int index = 0;
            //    int i = 1;
            //    bool found = false;
            //begin:
            //    for (index = 0; index < aktifForm.KontrolListesi.Length; index++)
            //    {
            //        if (aktifForm.KontrolListesi[index].KontrolAdi == ctrlName)
            //        {
            //            found = true;
            //            break;
            //        }
            //    }

            //    if (!found && i < subControls.Count)
            //    {
            //        ctrlName = subControls[i].Name;
            //        i++;
            //        goto begin;
            //    }
            //    //           List<PaketControl> aktifKontrolList = aktifForm.KontrolListesi.ToList().GetRange(index, aktifForm.KontrolListesi.Length - index);
            //    //var identicalQuery = from ctrlItem in aktifForm.KontrolListesi
            //    //                     join csControl in subControls on
            //    //                         ctrlItem.UniqueId
            //    //                         equals
            //    //                         csControl.FullPath.GetHashCode()
            //    //                     select new { Item1 = ctrlItem, Item2 = csControl };

            //    var identicalQuery = from ctrlItem in aktifForm.KontrolListesi
            //                         join csControl in subControls on
            //                                 new { name = ctrlItem.KontrolAdi, parName = ctrlItem.Parent != null ? ctrlItem.Parent.KontrolAdi : "" }
            //                                 equals
            //                                 new { name = csControl.Name, parName = csControl.Parent != null ? csControl.Parent.Name : "" }
            //                         select new { Item1 = ctrlItem, Item2 = csControl };

            //    int k = 0;
            //    foreach (var item in identicalQuery)
            //    {
            //        if (item.Item1.Parent == null || item.Item2.Parent == null || item.Item1.Parent.KontrolAdi == item.Item2.Parent.Name)
            //        {
            //            if (item.Item2.Visible != item.Item1.Gorunur) item.Item2.Visible = item.Item1.Gorunur;
            //            if (item.Item1.Gorunur) item.Item2.Enabled = item.Item1.Aktif;
            //            item.Item2.ShowInCustomizationForm = item.Item1.Sepette_Goster;
            //            k++;
            //        }
            //    }
            //    //}
        }

        public static int PaketKontrol(string formFullName, string controlName)
        {
            string fullAdi = formFullName + '#' + controlName;

            if (Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.PaketAdi == "*")
                return 2;

            //PaketElemanlari sonuc = PaketKontrolList.Find(delegate(PaketElemanlari v)
            //{
            //    return v.FormAdi == fullAdi;
            //});
            //if (sonuc == null)
            //    return 2;
            //else if (!sonuc.Visible)
            //    return 0;
            //else
            return 1;
        }

        public static void ResetControls()
        {
            if (CachedControlItems != null)
            {
                CachedControlItems.ForEach(item => { if (item.Control != null) item.Visible = true; });
                CachedControlItems.Clear();
            }
        }

        #endregion Paket
    }

    /// <summary>
    /// Menu itemlarýný childlari ile birlikte tutmak için olusturuldu
    /// </summary>
    public class MenuItem
    {
        public MenuItem()
        {
        }

        /// <summary>
        /// MenuItem Constactor
        /// </summary>
        /// <param name="FormName">controlun bulundugu contanier ile birlikteki adý</param>
        /// <param name="Name">control adi</param>
        /// <param name="Aciklama"></param>
        public MenuItem(string FormName, string Name, string Aciklama)
        {
            this.Aciklama = Aciklama;
            this.FormName = FormName;
            this.Name = Name;
        }

        private string aciklama;
        private string formName;
        private bool hasChild;
        private List<MenuItem> lstMenu = new List<MenuItem>();
        private string name;
        private int rootID;

        /// <summary>
        /// Control ile ilgi acýklama
        /// </summary>
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }

        /// <summary>
        /// Full Form adý.
        /// </summary>
        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }

        /// <summary>
        /// Childi bulunuyor mu?
        /// </summary>
        public bool HasChild
        {
            get { return hasChild; }
        }

        /// <summary>
        /// Child MenuItem listler
        /// </summary>
        public List<MenuItem> ListMenu
        {
            get { return lstMenu; }
        }

        /// <summary>
        /// control name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ParentIdyi tutar.
        /// </summary>
        public int RootID
        {
            get { return rootID; }
            set { rootID = value; }
        }

        /// <summary>
        /// Listeye MenuItem ekler.
        /// </summary>
        /// <param name="item">MenuItem</param>
        public void AddList(MenuItem item)
        {
            if (item != null)
            {
                lstMenu.Add(item);
                hasChild = true;
            }
        }
    }
}