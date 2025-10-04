using AvukatProLib.Util.Etiket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AvukatProLib
{
    [Serializable]
    public class KurumsalMod
    {
        /// <summary>
        /// Kurumsal Mod bilgilerinin tutulduğu dosyanın yolu
        /// </summary>
        public static readonly string FilePath = Application.StartupPath + "\\modref.gio";

        private ReferansAlanlari _DavaDnReferans = new ReferansAlanlari();

        private OzelKodAlanlari _DavaOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _DavaReferans = new ReferansAlanlari();

        private ReferansAlanlari _IcraAnReferans = new ReferansAlanlari();

        private OzelDurumlar _IcraOzelDurum = new OzelDurumlar();

        private OzelKodAlanlari _IcraOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _IcraReferans = new ReferansAlanlari();

        private string _ModIsmi = "<Modül İsmi>";

        private int _ModNo = 0;

        private OzelDurumlar _OrtakOzelDurum = new OzelDurumlar();

        private OzelKodAlanlari _SorusturmaOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _SorusturmaReferans = new ReferansAlanlari();

        private OzelKodAlanlari _SozlesmeOzelKod = new OzelKodAlanlari();

        private ReferansAlanlari _SozlesmeReferans = new ReferansAlanlari();

        public string ModIsmi
        {
            get { return _ModIsmi; }
            set { _ModIsmi = value; }
        }

        public int ModNo
        {
            get { return _ModNo; }
            set { _ModNo = value; }
        }

        /// <summary>
        /// Kurumsal modları dosyadan okuyup getiren method.
        /// </summary>
        /// <returns>Eğer dosya var ise okuyup liste halinde getirir, dosya yok ise hata vermez null geri döner.</returns>
        public static List<KurumsalMod> KurumsalModGetir()
        {
            List<KurumsalMod> modlar = null;
            if (File.Exists(KurumsalMod.FilePath))
            {
                FileStream fs = File.OpenRead(KurumsalMod.FilePath);

                BinaryFormatter bf = new BinaryFormatter();
                modlar = (List<KurumsalMod>)bf.Deserialize(fs);
                fs.Close();
            }
            return modlar;
        }

        #region _OrtakOzelDurum

        public OzelDurumlar OrtakOzelDurum
        {
            get { return _OrtakOzelDurum; }
            set { _OrtakOzelDurum = value; }
        }

        public string OrtakOzelDurum_Banka
        {
            get
            {
                return OrtakOzelDurum.Banka;
            }
            set
            {
                OrtakOzelDurum.Banka = value;
            }
        }

        public string OrtakOzelDurum_FoyBirim
        {
            get
            {
                return OrtakOzelDurum.FoyBirim;
            }
            set
            {
                OrtakOzelDurum.FoyBirim = value;
            }
        }

        public string OrtakOzelDurum_FoyYeri
        {
            get
            {
                return OrtakOzelDurum.FoyYeri;
            }
            set
            {
                OrtakOzelDurum.FoyYeri = value;
            }
        }

        public string OrtakOzelDurum_Klasor1
        {
            get
            {
                return OrtakOzelDurum.Klasor1;
            }
            set
            {
                OrtakOzelDurum.Klasor1 = value;
            }
        }

        public string OrtakOzelDurum_Klasor2
        {
            get
            {
                return OrtakOzelDurum.Klasor2;
            }
            set
            {
                OrtakOzelDurum.Klasor2 = value;
            }
        }

        public string OrtakOzelDurum_KrediGrup
        {
            get
            {
                return OrtakOzelDurum.KrediGrup;
            }
            set
            {
                OrtakOzelDurum.KrediGrup = value;
            }
        }

        public string OrtakOzelDurum_KrediTip
        {
            get
            {
                return OrtakOzelDurum.KrediTip;
            }
            set
            {
                OrtakOzelDurum.KrediTip = value;
            }
        }

        public string OrtakOzelDurum_Ozel
        {
            get
            {
                return OrtakOzelDurum.Ozel;
            }
            set
            {
                OrtakOzelDurum.Ozel = value;
            }
        }

        public string OrtakOzelDurum_Sube
        {
            get
            {
                return OrtakOzelDurum.Sube;
            }
            set
            {
                OrtakOzelDurum.Sube = value;
            }
        }

        public string OrtakOzelDurum_Tahsilat
        {
            get
            {
                return OrtakOzelDurum.Tahsilat;
            }
            set
            {
                OrtakOzelDurum.Tahsilat = value;
            }
        }

        #endregion _OrtakOzelDurum

        #region _IcraOzelDurum

        public OzelDurumlar IcraOzelDurum
        {
            get { return _IcraOzelDurum; }
            set { _IcraOzelDurum = value; }
        }

        public string IcraOzelDurum_Banka
        {
            get
            {
                return IcraOzelDurum.Banka;
            }
            set
            {
                IcraOzelDurum.Banka = value;
            }
        }

        public string IcraOzelDurum_FoyBirim
        {
            get
            {
                return IcraOzelDurum.FoyBirim;
            }
            set
            {
                IcraOzelDurum.FoyBirim = value;
            }
        }

        public string IcraOzelDurum_FoyYeri
        {
            get
            {
                return IcraOzelDurum.FoyYeri;
            }
            set
            {
                IcraOzelDurum.FoyYeri = value;
            }
        }

        public string IcraOzelDurum_Klasor1
        {
            get
            {
                return IcraOzelDurum.Klasor1;
            }
            set
            {
                IcraOzelDurum.Klasor1 = value;
            }
        }

        public string IcraOzelDurum_Klasor2
        {
            get
            {
                return IcraOzelDurum.Klasor2;
            }
            set
            {
                IcraOzelDurum.Klasor2 = value;
            }
        }

        public string IcraOzelDurum_KrediGrup
        {
            get
            {
                return IcraOzelDurum.KrediGrup;
            }
            set
            {
                IcraOzelDurum.KrediGrup = value;
            }
        }

        public string IcraOzelDurum_KrediTip
        {
            get
            {
                return IcraOzelDurum.KrediTip;
            }
            set
            {
                IcraOzelDurum.KrediTip = value;
            }
        }

        public string IcraOzelDurum_Ozel
        {
            get
            {
                return IcraOzelDurum.Ozel;
            }
            set
            {
                IcraOzelDurum.Ozel = value;
            }
        }

        public string IcraOzelDurum_Sube
        {
            get
            {
                return IcraOzelDurum.Sube;
            }
            set
            {
                IcraOzelDurum.Sube = value;
            }
        }

        public string IcraOzelDurum_Tahsilat
        {
            get
            {
                return IcraOzelDurum.Tahsilat;
            }
            set
            {
                IcraOzelDurum.Tahsilat = value;
            }
        }

        #endregion _IcraOzelDurum

        #region _DavaReferans

        public ReferansAlanlari DavaReferans
        {
            get { return _DavaReferans; }
            set { _DavaReferans = value; }
        }

        public string DavaReferans_Referans1
        {
            get
            {
                return DavaReferans.Referans1;
            }
            set
            {
                DavaReferans.Referans1 = value;
            }
        }

        public string DavaReferans_Referans2
        {
            get
            {
                return DavaReferans.Referans2;
            }
            set
            {
                DavaReferans.Referans2 = value;
            }
        }

        public string DavaReferans_Referans3
        {
            get
            {
                return DavaReferans.Referans3;
            }
            set
            {
                DavaReferans.Referans3 = value;
            }
        }

        #endregion _DavaReferans

        #region _SorusturmaReferans

        public ReferansAlanlari SorusturmaReferans
        {
            get { return _SorusturmaReferans; }
            set { _SorusturmaReferans = value; }
        }

        public string SorusturmaReferans_Referans1
        {
            get
            {
                return SorusturmaReferans.Referans1;
            }
            set
            {
                SorusturmaReferans.Referans1 = value;
            }
        }

        public string SorusturmaReferans_Referans2
        {
            get
            {
                return SorusturmaReferans.Referans2;
            }
            set
            {
                SorusturmaReferans.Referans2 = value;
            }
        }

        public string SorusturmaReferans_Referans3
        {
            get
            {
                return SorusturmaReferans.Referans3;
            }
            set
            {
                SorusturmaReferans.Referans3 = value;
            }
        }

        #endregion _SorusturmaReferans

        #region _SozlesmeReferans

        public ReferansAlanlari SozlesmeReferans
        {
            get { return _SozlesmeReferans; }
            set { _SozlesmeReferans = value; }
        }

        public string SozlesmeReferans_Referans1
        {
            get
            {
                return SozlesmeReferans.Referans1;
            }
            set
            {
                SozlesmeReferans.Referans1 = value;
            }
        }

        public string SozlesmeReferans_Referans2
        {
            get
            {
                return SozlesmeReferans.Referans2;
            }
            set
            {
                SozlesmeReferans.Referans2 = value;
            }
        }

        public string SozlesmeReferans_Referans3
        {
            get
            {
                return SozlesmeReferans.Referans3;
            }
            set
            {
                SozlesmeReferans.Referans3 = value;
            }
        }

        #endregion _SozlesmeReferans

        #region _SorusturmaOzelKod

        public OzelKodAlanlari SorusturmaOzelKod
        {
            get { return _SorusturmaOzelKod; }
            set { _SorusturmaOzelKod = value; }
        }

        public string SorusturmaOzelKod_OzelKod1
        {
            get
            {
                return SorusturmaOzelKod.OzelKod1;
            }
            set
            {
                SorusturmaOzelKod.OzelKod1 = value;
            }
        }

        public string SorusturmaOzelKod_OzelKod2
        {
            get
            {
                return SorusturmaOzelKod.OzelKod2;
            }
            set
            {
                SorusturmaOzelKod.OzelKod2 = value;
            }
        }

        public string SorusturmaOzelKod_OzelKod3
        {
            get
            {
                return SorusturmaOzelKod.OzelKod3;
            }
            set
            {
                SorusturmaOzelKod.OzelKod3 = value;
            }
        }

        public string SorusturmaOzelKod_OzelKod4
        {
            get
            {
                return SorusturmaOzelKod.OzelKod4;
            }
            set
            {
                SorusturmaOzelKod.OzelKod4 = value;
            }
        }

        #endregion _SorusturmaOzelKod

        #region _SozlesmeOzelKod

        public OzelKodAlanlari SozlesmeOzelKod
        {
            get { return _SozlesmeOzelKod; }
            set { _SozlesmeOzelKod = value; }
        }

        public string SozlesmeOzelKod_OzelKod1
        {
            get
            {
                return SozlesmeOzelKod.OzelKod1;
            }
            set
            {
                SozlesmeOzelKod.OzelKod1 = value;
            }
        }

        public string SozlesmeOzelKod_OzelKod2
        {
            get
            {
                return SozlesmeOzelKod.OzelKod2;
            }
            set
            {
                SozlesmeOzelKod.OzelKod2 = value;
            }
        }

        public string SozlesmeOzelKod_OzelKod3
        {
            get
            {
                return SozlesmeOzelKod.OzelKod3;
            }
            set
            {
                SozlesmeOzelKod.OzelKod3 = value;
            }
        }

        public string SozlesmeOzelKod_OzelKod4
        {
            get
            {
                return SozlesmeOzelKod.OzelKod4;
            }
            set
            {
                SozlesmeOzelKod.OzelKod4 = value;
            }
        }

        #endregion _SozlesmeOzelKod

        #region _DavaDnReferans

        public ReferansAlanlari DavaDnReferans
        {
            get { return _DavaDnReferans; }
            set { _DavaDnReferans = value; }
        }

        public string DavaDnReferans_Referans1
        {
            get
            {
                return DavaDnReferans.Referans1;
            }
            set
            {
                DavaDnReferans.Referans1 = value;
            }
        }

        public string DavaDnReferans_Referans2
        {
            get
            {
                return DavaDnReferans.Referans2;
            }
            set
            {
                DavaDnReferans.Referans2 = value;
            }
        }

        public string DavaDnReferans_Referans3
        {
            get
            {
                return DavaDnReferans.Referans3;
            }
            set
            {
                DavaDnReferans.Referans3 = value;
            }
        }

        #endregion _DavaDnReferans

        #region _IcraAnReferans

        public ReferansAlanlari IcraAnReferans
        {
            get { return _IcraAnReferans; }
            set { _IcraAnReferans = value; }
        }

        public string IcraAnReferans_Referans1
        {
            get
            {
                return IcraAnReferans.Referans1;
            }
            set
            {
                IcraAnReferans.Referans1 = value;
            }
        }

        public string IcraAnReferans_Referans2
        {
            get
            {
                return IcraAnReferans.Referans2;
            }
            set
            {
                IcraAnReferans.Referans2 = value;
            }
        }

        public string IcraAnReferans_Referans3
        {
            get
            {
                return IcraAnReferans.Referans3;
            }
            set
            {
                IcraAnReferans.Referans3 = value;
            }
        }

        #endregion _IcraAnReferans

        #region _IcraReferans

        public ReferansAlanlari IcraReferans
        {
            get { return _IcraReferans; }
            set { _IcraReferans = value; }
        }

        public string IcraReferans_Referans1
        {
            get
            {
                return IcraReferans.Referans1;
            }
            set
            {
                IcraReferans.Referans1 = value;
            }
        }

        public string IcraReferans_Referans2
        {
            get
            {
                return IcraReferans.Referans2;
            }
            set
            {
                IcraReferans.Referans2 = value;
            }
        }

        public string IcraReferans_Referans3
        {
            get
            {
                return IcraReferans.Referans3;
            }
            set
            {
                IcraReferans.Referans3 = value;
            }
        }

        #endregion _IcraReferans

        #region _DavaOzelKod

        public OzelKodAlanlari DavaOzelKod
        {
            get { return _DavaOzelKod; }
            set { _DavaOzelKod = value; }
        }

        public string DavaOzelKod_OzelKod1
        {
            get
            {
                return DavaOzelKod.OzelKod1;
            }
            set
            {
                DavaOzelKod.OzelKod1 = value;
            }
        }

        public string DavaOzelKod_OzelKod2
        {
            get
            {
                return DavaOzelKod.OzelKod2;
            }
            set
            {
                DavaOzelKod.OzelKod2 = value;
            }
        }

        public string DavaOzelKod_OzelKod3
        {
            get
            {
                return DavaOzelKod.OzelKod3;
            }
            set
            {
                DavaOzelKod.OzelKod3 = value;
            }
        }

        public string DavaOzelKod_OzelKod4
        {
            get
            {
                return DavaOzelKod.OzelKod4;
            }
            set
            {
                DavaOzelKod.OzelKod4 = value;
            }
        }

        #endregion _DavaOzelKod

        #region _IcraOzelKod

        public OzelKodAlanlari IcraOzelKod
        {
            get { return _IcraOzelKod; }
            set { _IcraOzelKod = value; }
        }

        public string IcraOzelKod_OzelKod1
        {
            get
            {
                return IcraOzelKod.OzelKod1;
            }
            set
            {
                IcraOzelKod.OzelKod1 = value;
            }
        }

        public string IcraOzelKod_OzelKod2
        {
            get
            {
                return IcraOzelKod.OzelKod2;
            }
            set
            {
                IcraOzelKod.OzelKod2 = value;
            }
        }

        public string IcraOzelKod_OzelKod3
        {
            get
            {
                return IcraOzelKod.OzelKod3;
            }
            set
            {
                IcraOzelKod.OzelKod3 = value;
            }
        }

        public string IcraOzelKod_OzelKod4
        {
            get
            {
                return IcraOzelKod.OzelKod4;
            }
            set
            {
                IcraOzelKod.OzelKod4 = value;
            }
        }

        #endregion _IcraOzelKod
    }
}