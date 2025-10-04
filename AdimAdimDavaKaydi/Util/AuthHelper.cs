using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util
{
    /// <summary>
    /// Yetkilendirme i�lemlerinde kullan�lan base s�n�f.
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
        /// Verilen yetki c�mlesine g�re bulundu�u nesne �rne�ini yap�land�r�r
        /// </summary>
        /// <param name="yetkiCumlesi">1 ve 0 lardan olu�an say� dizisi</param>
        private void yetkiYapilandir(string yetkiCumlesi)
        {
            /* Okan 04.01.2010 Performans �al��mas�
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
        /// Verilen form ad� ve kontrol ad�na g�re AuthHelper tipinde aktif kullan�c�ya ait yetkilendirme getirir. �lgili yetki tabloda bulunmad���nda null geri d�ner.
        /// </summary>
        /// <param name="formName">Yetkisini ��renmek istedi�imiz form ad�.</param>
        /// <param name="controlName">Yetkisini ��renmek istedi�imiz form �zerindeki kontrol ad�</param>
        /// <returns>Yetki bulundu�unda yetkilerin yap�land�r�lm�� halini d�nd�r�r. Yetki bulunmad���nda veya AvukatProLib.Kimlik.Bilgi null ise null d�nd�r�r.</returns>
        public static AuthHelper GetAuthHelper(string formName, string controlName)
        {
            /* Okan 04.01.2010 Performans �al��mas�
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
                    MessageBox.Show("�ifre en az 8 karakter olmal�");
                return false;
            }
            if (!AlphaRegex.IsMatch(p))
            {
                if (msg)
                    MessageBox.Show("�ifre i�erisinde en az 1 Harf ve 1 Rakamdan olu�mal�.");
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