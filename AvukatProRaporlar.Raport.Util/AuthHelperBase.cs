using AvukatProLib;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AvukatProRaporlar.Raport.Util
{
    /// <summary>
    /// Yetkilendirme işlemlerinde kullanılan sınıf.
    /// </summary>
    public class AuthHelperBase
    {
        /// <summary>
        /// Yeni bir AuthHelper örneği oluşturur.
        /// </summary>
        public AuthHelperBase()
        { }

        /// <summary>
        /// Yeni bir AuthHelper örneği oluşturur.
        /// </summary>
        /// <param name="yetkiCumlesi">Örneği yapılandıracak yetki cümlesi</param>
        public AuthHelperBase(string yetkiCumlesi)
        {
            YetkiCumlesi = yetkiCumlesi;
        }

        public AuthHelperBase(CS_KOD_FORM_LISTESI formList)
        {
            YetkiCumlesi = "0000000000000000";
            KullaniciYetki = new CS_KOD_FORM_KULLANICI_YETKI();
            KullaniciYetki.FORM_ID = formList.ID;
            Form_Aciklama = formList.FORM_ACIKLAMA;
        }

        public AuthHelperBase(CS_KOD_KULLANICI_GRUP_YETKI formList)
        {
            Connection con = new Connection();
            AvukatProViewDataContext dbV = new AvukatProViewDataContext(con.MyConnection);
            YetkiCumlesi = formList.YETKI_CUMLESI;

            GrupYetki = formList;
            if (formList.FORM_ID > 0)
            {
                CS_KOD_FORM_LISTESI list = (CS_KOD_FORM_LISTESI)dbV.CS_KOD_FORM_LISTESI_GetByID(formList.FORM_ID);

                Form_Aciklama = list.FORM_ACIKLAMA;
            }
            else if (formList.GRUP_ID > 0)
            {
                CS_KOD_FORM_GRUP list = (CS_KOD_FORM_GRUP)dbV.CS_KOD_FORM_GRUP_GetByID(formList.GRUP_ID);
                Form_Aciklama = list.GRUP_ADI;
            }
        }

        /// <summary>
        /// Yeni bir AuthHelper örneği oluşturur.
        /// </summary>
        /// <param name="yetki">Db yetki nesne örneği</param>
        public AuthHelperBase(CS_KOD_FORM_KULLANICI_YETKI yetki)
        {
            KullaniciYetki = yetki;
            YetkiCumlesi = yetki.YETKI_CUMLESI;
        }

        public static string StartupPath = string.Empty;

        private string _Form_Aciklama;

        private bool _FormAcabilir;

        private CS_KOD_KULLANICI_GRUP_YETKI _GrupYetki;

        private bool _Kaydedebilir;

        private CS_KOD_FORM_KULLANICI_YETKI _KullaniciYetki;

        private bool _MenuGorebilir;

        private bool _MenuTiklayabilir;

        //DBDataContext db = new DBDataContext(connec.MyConnection);
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
        /// Verilen yetki cümlesine göre bulunduğu nesne örneğini yapılandırır
        /// </summary>
        /// <param name="yetkiCumlesi">1 ve 0 lardan oluşan sayı dizisi</param>
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

        // public static string StartupPath = string.Empty;

        #region Static Elemanlar

        /// <summary>
        /// Verilen kullanıcı Id ve form adına göre AuthHelper tipinde yetkilendirme getirir. İlgili
        /// yetki tabloda bulunmadığında null geri döner.
        /// </summary>
        /// <param name="kullaniciId">Yetkisini öğrenmek istediğimiz kullanıcının ID si</param>
        /// <param name="formFullName">Yetkisini öğrenmek istediğimiz form adı.</param>
        /// <returns>Yetki bulunduğunda yetkilerin yapılandırılmış halini döndürür. Yetki
        /// bulunmadığında null döndürür.</returns>
        public static AuthHelperBase GetAuthHelper(int kullaniciId, string formFullName)
        {
            Connection con = new Connection();
            AvukatProViewDataContext db = null;
            if (con.MyConnection == null)
            {
                List<CompInfo> sList = CompInfo.CmpNfoList;
                foreach (CompInfo info in sList)
                {
                    con.MyConnection = info.ConStr;
                }
                db = new AvukatProViewDataContext(con.MyConnection);
            }
            else
            {
                db = new AvukatProViewDataContext(con.MyConnection);
            }
            var yetkiler = db._CS_KOD_FORM_KULLANICI_YETKI_GetByKullaniciIdFormFullAdi(kullaniciId, formFullName);
            if (yetkiler.Count() > 0)
            {
                var yetki = db.CS_KOD_FORM_KULLANICI_YETKIs.Where(vii => vii.ID == yetkiler.First().ID);
                AuthHelperBase hlp = new AuthHelperBase(yetki as CS_KOD_FORM_KULLANICI_YETKI);
                return hlp;
            }
            return null;
        }

        /// <summary>
        /// Verilen kullanıcı Id ve form adına göre AuthHelper tipinde yetkilendirme getirir. İlgili
        /// yetki tabloda bulunmadığında null geri döner.
        /// </summary>
        /// <param name="kullaniciId">Yetkisini öğrenmek istediğimiz kullanıcının ID si</param>
        /// <param name="formName">Yetkisini öğrenmek istediğimiz form adı.</param>
        /// <param name="controlName">Yetkisini öğrenmek istediğimiz form üzerindeki kontrol
        /// adı</param>
        /// <returns>Yetki bulunduğunda yetkilerin yapılandırılmış halini döndürür. Yetki
        /// bulunmadığında null döndürür.</returns>
        public static AuthHelperBase GetAuthHelper(int kullaniciId, string formName, string controlName)
        {
            return GetAuthHelper(kullaniciId, String.Format("{0}#{1}", formName, controlName));
        }

        #endregion Static Elemanlar
    }
}