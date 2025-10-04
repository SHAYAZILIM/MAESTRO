using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    /// <summary>
    /// Yetkilendirme iþlemlerinde kullanýlan base sýnýf.
    /// </summary>
    public class AuthHelper : AvukatProLib.Util.AuthHelperBase
    {
        private string _YetkiCumlesi;
        private bool _FormAcabilir;
        private bool _Kaydedebilir;
        private bool _MenuGorebilir;
        private bool _MenuTiklayabilir;
        private CS_KOD_FORM_KULLANICI_YETKI _KullaniciYetki;

        public CS_KOD_FORM_KULLANICI_YETKI KullaniciYetki
        {
            get { return _KullaniciYetki; }
            set { _KullaniciYetki = value; }
        }

        public CS_KOD_KULLANICI_GRUP_YETKI KullaniciGrupYetki { get; set; }

        public bool MenuTiklayabilir
        {
            get { return _MenuTiklayabilir; }
            set { _MenuTiklayabilir = value; }
        }

        public bool MenuGorebilir
        {
            get { return _MenuGorebilir; }
            set { _MenuGorebilir = value; }
        }

        public bool Kaydedebilir
        {
            get { return _Kaydedebilir; }
            set { _Kaydedebilir = value; }
        }

        public bool FormAcabilir
        {
            get { return _FormAcabilir; }
            set { _FormAcabilir = value; }
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
     
        /// <summary>
        /// Verilen yetki cümlesine göre bulunduðu nesne örneðini yapýlandýrýr
        /// </summary>
        /// <param name="yetkiCumlesi">1 ve 0 lardan oluþan sayý dizisi</param>
        private void yetkiYapilandir(string yetkiCumlesi)
        {
            /* Okan 04.01.2010 Performans Çalýþmasý
            if (yetkiCumlesi.Length > 0)
                _FormAcabilir = yetkiCumlesi[0] == '1' ? true : false;
            if (yetkiCumlesi.Length > 1)
                _Kaydedebilir = yetkiCumlesi[1] == '1' ? true : false;
            if (yetkiCumlesi.Length > 2)
                _MenuGorebilir = yetkiCumlesi[2] == '1' ? true : false;
            if (yetkiCumlesi.Length > 3)
                _MenuTiklayabilir = yetkiCumlesi[3] == '1' ? true : false;
            //...
             */
        }

        #region Static Elemanlar

        /// <summary>
        /// Verilen form adý ve kontrol adýna göre AuthHelper tipinde aktif kullanýcýya ait yetkilendirme getirir. Ýlgili yetki tabloda bulunmadýðýnda null geri döner.
        /// </summary>
        /// <param name="formName">Yetkisini öðrenmek istediðimiz form adý.</param>
        /// <param name="controlName">Yetkisini öðrenmek istediðimiz form üzerindeki kontrol adý</param>
        /// <returns>Yetki bulunduðunda yetkilerin yapýlandýrýlmýþ halini döndürür. Yetki bulunmadýðýnda veya AvukatProLib.Kimlik.Bilgi null ise null döndürür.</returns>
        public static AuthHelper GetAuthHelper(string formName, string controlName)
        {
            /* Okan 04.01.2010 Performans Çalýþmasý
            if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.ID > 0)
                return GetAuthHelper(AvukatProLib.Kimlik.Bilgi.ID, formName, controlName);
            else
             */
            return null;
        }

        #endregion Static Elemanlar
        
        public static bool PasswordControl(string p, bool msg)
        {
            Regex AlphaRegex = new Regex("([a-zA-Z0-9])$");
            if (p.Length < 8)
            {
                if (msg)
                    MessageBox.Show("Þifre en az 8 karakter olmalý");
                return false;
            }
            if (!AlphaRegex.IsMatch(p))
            {
                if (msg)
                    MessageBox.Show("Þifre içerisinde en az 1 Harf ve 1 Rakamdan oluþmalý.");
                return false;
            }

            return true;
        }
    }

    public interface IYetkilendirilebilir
    {
        AuthHelper MyAuthHelper { get; set; }
    }
}