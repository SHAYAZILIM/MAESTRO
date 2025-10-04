using System;
using System.Data.SqlClient;

namespace AvukatProLib.OzelKodReferans
{
    public class DavaOzelKodReferans
    {
        private string _DavaNedenReferans1;
        private string _DavaNedenReferans2;
        private string _DavaNedenReferans3;
        private string _DavaOzelKod1;
        private string _DavaOzelKod2;
        private string _DavaOzelKod3;
        private string _DavaOzelKod4;
        private string _DavaReferans1;
        private string _DavaReferans2;
        private string _DavaReferans3;
        private int _Id;

        public string DavaNedenReferans1
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaNedenReferans1))
                {
                    _DavaNedenReferans1 = "Referans1";
                }
                return _DavaNedenReferans1;
            }
            set
            {
                _DavaNedenReferans1 = value;
            }
        }

        public string DavaNedenReferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaNedenReferans2))
                {
                    _DavaNedenReferans2 = "Referans2";
                }
                return _DavaNedenReferans2;
            }
            set
            {
                _DavaNedenReferans2 = value;
            }
        }

        public string DavaNedenReferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaNedenReferans3))
                {
                    _DavaNedenReferans3 = "Referans3";
                }
                return _DavaNedenReferans3;
            }
            set
            {
                _DavaNedenReferans3 = value;
            }
        }

        public string DavaOzelKod1
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaOzelKod1))
                {
                    _DavaOzelKod1 = "OzelKod1";
                }
                return _DavaOzelKod1;
            }
            set
            {
                _DavaOzelKod1 = value;
            }
        }

        public string DavaOzelKod2
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaOzelKod2))
                {
                    _DavaOzelKod2 = "OzelKod2";
                }
                return _DavaOzelKod2;
            }
            set
            {
                _DavaOzelKod2 = value;
            }
        }

        public string DavaOzelKod3
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaOzelKod3))
                {
                    _DavaOzelKod3 = "OzelKod3";
                }
                return _DavaOzelKod3;
            }
            set
            {
                _DavaOzelKod3 = value;
            }
        }

        public string DavaOzelKod4
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaOzelKod4))
                {
                    _DavaOzelKod4 = "OzelKod4";
                }
                return _DavaOzelKod4;
            }
            set
            {
                _DavaOzelKod4 = value;
            }
        }

        public string DavaReferans1
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaReferans1))
                {
                    _DavaReferans1 = "Referans1";
                }
                return _DavaReferans1;
            }
            set
            {
                _DavaReferans1 = value;
            }
        }

        public string DavaReferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaReferans2))
                {
                    _DavaReferans2 = "Referans2";
                }
                return _DavaReferans2;
            }
            set
            {
                _DavaReferans2 = value;
            }
        }

        public string DavaReferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_DavaReferans3))
                {
                    _DavaReferans3 = "Referans3";
                }
                return _DavaReferans3;
            }
            set
            {
                _DavaReferans3 = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }

    public class IcraOzelKodReferans
    {
        private string _IcraANrefarans1;
        private string _IcraANreferans2;
        private string _IcraANreferans3;
        private string _IcraOzelDurumBanka;
        private string _IcraOzelDurumFoyBirim;
        private string _IcraOzelDurumFoyYeri;
        private string _IcraOzelDurumKlasor1;
        private string _IcraOzelDurumKlasor2;
        private string _IcraOzelDurumKrediGrup;
        private string _IcraOzelDurumKrediTip;
        private string _IcraOzelDurumOzel;
        private string _IcraOzelDurumSube;
        private string _IcraOzelDurumTahsilat;
        private string _IcraOzelKod1;
        private string _IcraOzelKod2;
        private string _IcraOzelKod3;
        private string _IcraOzelKod4;
        private string _IcraReferans1;
        private string _IcraReferans2;
        private string _IcraReferans3;
        private int _Id;
        private string _KurumsalMod;

        public string IcraANrefarans1
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraANrefarans1))
                {
                    _IcraANrefarans1 = "Referans1";
                }
                return _IcraANrefarans1;
            }
            set
            {
                _IcraANrefarans1 = value;
            }
        }

        public string IcraANreferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraANreferans2))
                {
                    _IcraANreferans2 = "Referans2";
                }
                return _IcraANreferans2;
            }
            set
            {
                _IcraANreferans2 = value;
            }
        }

        public string IcraANreferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraANreferans3))
                {
                    _IcraANreferans3 = "Referans3";
                }
                return _IcraANreferans3;
            }
            set
            {
                _IcraANreferans3 = value;
            }
        }

        public string IcraOzelDurumBanka
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumBanka))
                {
                    _IcraOzelDurumBanka = "Banka";
                }
                return _IcraOzelDurumBanka;
            }
            set
            {
                _IcraOzelDurumBanka = value;
            }
        }

        public string IcraOzelDurumFoyBirim
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumFoyBirim))
                {
                    _IcraOzelDurumFoyBirim = "FoyBirim";
                }
                return _IcraOzelDurumFoyBirim;
            }
            set
            {
                _IcraOzelDurumFoyBirim = value;
            }
        }

        public string IcraOzelDurumFoyYeri
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumFoyYeri))
                {
                    _IcraOzelDurumFoyYeri = "FoyYeri";
                }
                return _IcraOzelDurumFoyYeri;
            }
            set
            {
                _IcraOzelDurumFoyYeri = value;
            }
        }

        public string IcraOzelDurumKlasor1
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumKlasor1))
                {
                    _IcraOzelDurumKlasor1 = "Klasor1";
                }
                return _IcraOzelDurumKlasor1;
            }
            set
            {
                _IcraOzelDurumKlasor1 = value;
            }
        }

        public string IcraOzelDurumKlasor2
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumKlasor2))
                {
                    _IcraOzelDurumKlasor2 = "Klasor2";
                }
                return _IcraOzelDurumKlasor2;
            }
            set
            {
                _IcraOzelDurumKlasor2 = value;
            }
        }

        public string IcraOzelDurumKrediGrup
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumKrediGrup))
                {
                    _IcraOzelDurumKrediGrup = "KrediGrup";
                }
                return _IcraOzelDurumKrediGrup;
            }
            set
            {
                _IcraOzelDurumKrediGrup = value;
            }
        }

        public string IcraOzelDurumKrediTip
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumKrediTip))
                {
                    _IcraOzelDurumKrediTip = "KrediTip";
                }
                return _IcraOzelDurumKrediTip;
            }
            set
            {
                _IcraOzelDurumKrediTip = value;
            }
        }

        public string IcraOzelDurumOzel
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumOzel))
                {
                    _IcraOzelDurumOzel = "Ozel";
                }
                return _IcraOzelDurumOzel;
            }
            set
            {
                _IcraOzelDurumOzel = value;
            }
        }

        public string IcraOzelDurumSube
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumSube))
                {
                    _IcraOzelDurumSube = "Sube";
                }
                return _IcraOzelDurumSube;
            }
            set
            {
                _IcraOzelDurumSube = value;
            }
        }

        public string IcraOzelDurumTahsilat
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelDurumTahsilat))
                {
                    _IcraOzelDurumTahsilat = "Tahsilat";
                }
                return _IcraOzelDurumTahsilat;
            }
            set
            {
                _IcraOzelDurumTahsilat = value;
            }
        }

        public string IcraOzelKod1
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelKod1))
                {
                    _IcraOzelKod1 = "OzelKod1";
                }
                return _IcraOzelKod1;
            }
            set
            {
                _IcraOzelKod1 = value;
            }
        }

        public string IcraOzelKod2
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelKod2))
                {
                    _IcraOzelKod2 = "OzelKod2";
                }
                return _IcraOzelKod2;
            }
            set
            {
                _IcraOzelKod2 = value;
            }
        }

        public string IcraOzelKod3
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelKod3))
                {
                    _IcraOzelKod3 = "OzelKod3";
                }
                return _IcraOzelKod3;
            }
            set
            {
                _IcraOzelKod3 = value;
            }
        }

        public string IcraOzelKod4
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraOzelKod4))
                {
                    _IcraOzelKod4 = "OzelKod4";
                }
                return _IcraOzelKod4;
            }
            set
            {
                _IcraOzelKod4 = value;
            }
        }

        public string IcraReferans1
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraReferans1))
                {
                    _IcraReferans1 = "Referans1";
                }
                return _IcraReferans1;
            }
            set
            {
                _IcraReferans1 = value;
            }
        }

        public string IcraReferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraReferans2))
                {
                    _IcraReferans2 = "Referans2";
                }
                return _IcraReferans2;
            }
            set
            {
                _IcraReferans2 = value;
            }
        }

        public string IcraReferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_IcraReferans3))
                {
                    _IcraReferans3 = "Referans3";
                }
                return _IcraReferans3;
            }
            set
            {
                _IcraReferans3 = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string KurumsalMod
        {
            get
            {
                if (string.IsNullOrEmpty(_KurumsalMod))
                {
                    _KurumsalMod = "KurumsalMod";
                }
                return _KurumsalMod;
            }
            set
            {
                _KurumsalMod = value;
            }
        }
    }

    public class OrtakOzelKodReferans
    {
        private int _Id;
        private string _OrtakOzelDurumBanka;

        private string _OrtakOzelDurumFoyBirim;

        private string _OrtakOzelDurumFoyYeri;

        private string _OrtakOzelDurumKlasor1;

        private string _OrtakOzelDurumKlasor2;

        private string _OrtakOzelDurumKrediGrup;

        private string _OrtakOzelDurumKrediTip;

        private string _OrtakOzelDurumOzel;

        private string _OrtakOzelDurumSube;

        private string _OrtakOzelDurumTahsilat;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string OrtakOzelDurumBanka
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumBanka))
                {
                    _OrtakOzelDurumBanka = "Banka";
                }
                return _OrtakOzelDurumBanka;
            }
            set
            {
                _OrtakOzelDurumBanka = value;
            }
        }

        public string OrtakOzelDurumFoyBirim
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumFoyBirim))
                {
                    _OrtakOzelDurumFoyBirim = "FoyBirim";
                }
                return _OrtakOzelDurumFoyBirim;
            }
            set
            {
                _OrtakOzelDurumFoyBirim = value;
            }
        }

        public string OrtakOzelDurumFoyYeri
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumFoyYeri))
                {
                    _OrtakOzelDurumFoyYeri = "FoyYeri";
                }
                return _OrtakOzelDurumFoyYeri;
            }
            set
            {
                _OrtakOzelDurumFoyYeri = value;
            }
        }

        public string OrtakOzelDurumKlasor1
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumKlasor1))
                {
                    _OrtakOzelDurumKlasor1 = "Klasor1";
                }
                return _OrtakOzelDurumKlasor1;
            }
            set
            {
                _OrtakOzelDurumKlasor1 = value;
            }
        }

        public string OrtakOzelDurumKlasor2
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumKlasor2))
                {
                    _OrtakOzelDurumKlasor2 = "Klasor2";
                }
                return _OrtakOzelDurumKlasor2;
            }
            set
            {
                _OrtakOzelDurumKlasor2 = value;
            }
        }

        public string OrtakOzelDurumKrediGrup
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumKrediGrup))
                {
                    _OrtakOzelDurumKrediGrup = "KrediGrup";
                }
                return _OrtakOzelDurumKrediGrup;
            }
            set
            {
                _OrtakOzelDurumKrediGrup = value;
            }
        }

        public string OrtakOzelDurumKrediTip
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumKrediTip))
                {
                    _OrtakOzelDurumKrediTip = "KrediTip";
                }
                return _OrtakOzelDurumKrediTip;
            }
            set
            {
                _OrtakOzelDurumKrediTip = value;
            }
        }

        public string OrtakOzelDurumOzel
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumOzel))
                {
                    _OrtakOzelDurumOzel = "Ozel";
                }
                return _OrtakOzelDurumOzel;
            }
            set
            {
                _OrtakOzelDurumOzel = value;
            }
        }

        public string OrtakOzelDurumSube
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumSube))
                {
                    _OrtakOzelDurumSube = "Sube";
                }
                return _OrtakOzelDurumSube;
            }
            set
            {
                _OrtakOzelDurumSube = value;
            }
        }

        public string OrtakOzelDurumTahsilat
        {
            get
            {
                if (string.IsNullOrEmpty(_OrtakOzelDurumTahsilat))
                {
                    _OrtakOzelDurumTahsilat = "Tahsilat";
                }
                return _OrtakOzelDurumTahsilat;
            }
            set
            {
                _OrtakOzelDurumTahsilat = value;
            }
        }
    }
    
    public class OzelKodReferans
    {
        private static DavaOzelKodReferans _DavaOzelKodReferans;

        private static IcraOzelKodReferans _IcraOzelKodReferans;

        private static OrtakOzelKodReferans _OrtakOzelKodReferans;

        private static SorusturmaOzelKodReferans _SorusturmaOzelKodReferans;

        private static SozlesmeOzelKodReferans _SozlesmeOzelKodReferans;

        public static DavaOzelKodReferans DavaOzelKodReferans
        {
            get { return OzelKodReferans._DavaOzelKodReferans; }
            set { OzelKodReferans._DavaOzelKodReferans = value; }
        }

        public static IcraOzelKodReferans IcraOzelKodReferans
        {
            get { return OzelKodReferans._IcraOzelKodReferans; }
            set { OzelKodReferans._IcraOzelKodReferans = value; }
        }

        public static OrtakOzelKodReferans OrtakOzelKodReferans
        {
            get { return OzelKodReferans._OrtakOzelKodReferans; }
            set { OzelKodReferans._OrtakOzelKodReferans = value; }
        }

        public static SorusturmaOzelKodReferans SorusturmaOzelKodReferans
        {
            get { return OzelKodReferans._SorusturmaOzelKodReferans; }
            set { OzelKodReferans._SorusturmaOzelKodReferans = value; }
        }

        public static SozlesmeOzelKodReferans SozlesmeOzelKodReferans
        {
            get { return OzelKodReferans._SozlesmeOzelKodReferans; }
            set { OzelKodReferans._SozlesmeOzelKodReferans = value; }
        }

        public static DavaOzelKodReferans GetDavaOzelKodReferans(string connectionstring)
        {
            if (_DavaOzelKodReferans == null)
            {
                _DavaOzelKodReferans = new AvukatProLib.OzelKodReferans.DavaOzelKodReferans();
                var _Connection = new SqlConnection(connectionstring);
                try
                {
                    _Connection.Open();
                    SqlCommand cn = new SqlCommand(@"
SELECT TOP 1 Id
      ,DavaNedenReferans1
      ,DavaNedenReferans2
      ,DavaNedenReferans3
      ,DavaOzelKod1
      ,DavaOzelKod2
      ,DavaOzelKod3
      ,DavaOzelKod4
      ,DavaReferans1
      ,DavaReferans2
      ,DavaReferans3
  FROM OZEL_KOD_VE_REFERANSLAR_DAVA(nolock)", _Connection);
                    var dr = cn.ExecuteReader();
                    var cnt = false;
                    while (dr.Read())
                    {
                        _DavaOzelKodReferans.Id = dr.GetInt32(0);
                        _DavaOzelKodReferans.DavaNedenReferans1 = dr.GetString(1);
                        _DavaOzelKodReferans.DavaNedenReferans2 = dr.GetString(2);
                        _DavaOzelKodReferans.DavaNedenReferans3 = dr.GetString(3);
                        _DavaOzelKodReferans.DavaOzelKod1 = dr.GetString(4);
                        _DavaOzelKodReferans.DavaOzelKod2 = dr.GetString(5);
                        _DavaOzelKodReferans.DavaOzelKod3 = dr.GetString(6);
                        _DavaOzelKodReferans.DavaOzelKod4 = dr.GetString(7);
                        _DavaOzelKodReferans.DavaReferans1 = dr.GetString(8);
                        _DavaOzelKodReferans.DavaReferans2 = dr.GetString(9);
                        _DavaOzelKodReferans.DavaReferans3 = dr.GetString(10);
                        cnt = true;
                    }
                    dr.Close();

                    if (!cnt)
                    {
                        SqlCommand cninsert = new SqlCommand(@"INSERT INTO OZEL_KOD_VE_REFERANSLAR_DAVA
           (DavaNedenReferans1
           ,DavaNedenReferans2
           ,DavaNedenReferans3
           ,DavaOzelKod1
           ,DavaOzelKod2
           ,DavaOzelKod3
           ,DavaOzelKod4
           ,DavaReferans1
           ,DavaReferans2
           ,DavaReferans3)
     VALUES
           (@DavaNedenReferans1
           ,@DavaNedenReferans2
           ,@DavaNedenReferans3
           ,@DavaOzelKod1
           ,@DavaOzelKod2
           ,@DavaOzelKod3
           ,@DavaOzelKod4
           ,@DavaReferans1
           ,@DavaReferans2
           ,@DavaReferans3)", _Connection);

                        cninsert.Parameters.AddWithValue("@DavaNedenReferans1", _DavaOzelKodReferans.DavaNedenReferans1);
                        cninsert.Parameters.AddWithValue("@DavaNedenReferans2", _DavaOzelKodReferans.DavaNedenReferans2);
                        cninsert.Parameters.AddWithValue("@DavaNedenReferans3", _DavaOzelKodReferans.DavaNedenReferans3);
                        cninsert.Parameters.AddWithValue("@DavaOzelKod1", _DavaOzelKodReferans.DavaOzelKod1);
                        cninsert.Parameters.AddWithValue("@DavaOzelKod2", _DavaOzelKodReferans.DavaOzelKod2);
                        cninsert.Parameters.AddWithValue("@DavaOzelKod3", _DavaOzelKodReferans.DavaOzelKod3);
                        cninsert.Parameters.AddWithValue("@DavaOzelKod4", _DavaOzelKodReferans.DavaOzelKod4);
                        cninsert.Parameters.AddWithValue("@DavaReferans1", _DavaOzelKodReferans.DavaReferans1);
                        cninsert.Parameters.AddWithValue("@DavaReferans2", _DavaOzelKodReferans.DavaReferans2);
                        cninsert.Parameters.AddWithValue("@DavaReferans3", _DavaOzelKodReferans.DavaReferans3);
                        cninsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
                }
                finally
                {
                    _Connection.Close();
                }
            }

            return _DavaOzelKodReferans;
        }

        public static IcraOzelKodReferans GetIcraOzelKodReferans(string connectionstring)
        {
            if (_IcraOzelKodReferans == null)
            {
                _IcraOzelKodReferans = new AvukatProLib.OzelKodReferans.IcraOzelKodReferans();
                var _Connection = new SqlConnection(connectionstring);
                try
                {
                    _Connection.Open();
                    SqlCommand cn = new SqlCommand(@"
SELECT TOP 1 Id
      ,KurumsalMod
      ,IcraANrefarans1
      ,IcraANreferans2
      ,IcraANreferans3
      ,IcraReferans1
      ,IcraReferans2
      ,IcraReferans3
      ,IcraOzelKod1
      ,IcraOzelKod2
      ,IcraOzelKod3
      ,IcraOzelKod4
      ,IcraOzelDurumBanka
      ,IcraOzelDurumSube
      ,IcraOzelDurumFoyBirim
      ,IcraOzelDurumFoyYeri
      ,IcraOzelDurumKlasor1
      ,IcraOzelDurumKlasor2
      ,IcraOzelDurumOzel
      ,IcraOzelDurumKrediGrup
      ,IcraOzelDurumKrediTip
      ,IcraOzelDurumTahsilat
  FROM OZEL_KOD_VE_REFERANSLAR_ICRA(nolock)", _Connection);
                    var dr = cn.ExecuteReader();
                    var cnt = false;
                    while (dr.Read())
                    {
                        _IcraOzelKodReferans.Id = dr.GetInt32(0);
                        _IcraOzelKodReferans.KurumsalMod = dr.GetString(1);
                        _IcraOzelKodReferans.IcraANrefarans1 = dr.GetString(2);
                        _IcraOzelKodReferans.IcraANreferans2 = dr.GetString(3);
                        _IcraOzelKodReferans.IcraANreferans3 = dr.GetString(4);
                        _IcraOzelKodReferans.IcraReferans1 = dr.GetString(5);
                        _IcraOzelKodReferans.IcraReferans2 = dr.GetString(6);
                        _IcraOzelKodReferans.IcraReferans3 = dr.GetString(7);
                        _IcraOzelKodReferans.IcraOzelKod1 = dr.GetString(8);
                        _IcraOzelKodReferans.IcraOzelKod2 = dr.GetString(9);
                        _IcraOzelKodReferans.IcraOzelKod3 = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelKod4 = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumBanka = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumSube = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumFoyBirim = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumFoyYeri = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumKlasor1 = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumKlasor2 = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumOzel = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumKrediGrup = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumKrediTip = dr.GetString(10);
                        _IcraOzelKodReferans.IcraOzelDurumTahsilat = dr.GetString(10);
                        cnt = true;
                    }
                    dr.Close();
                    if (!cnt)
                    {
                        SqlCommand cninsert = new SqlCommand(@"
INSERT INTO OZEL_KOD_VE_REFERANSLAR_ICRA
           (KurumsalMod
           ,IcraANrefarans1
           ,IcraANreferans2
           ,IcraANreferans3
           ,IcraReferans1
           ,IcraReferans2
           ,IcraReferans3
           ,IcraOzelKod1
           ,IcraOzelKod2
           ,IcraOzelKod3
           ,IcraOzelKod4
           ,IcraOzelDurumBanka
           ,IcraOzelDurumSube
           ,IcraOzelDurumFoyBirim
           ,IcraOzelDurumFoyYeri
           ,IcraOzelDurumKlasor1
           ,IcraOzelDurumKlasor2
           ,IcraOzelDurumOzel
           ,IcraOzelDurumKrediGrup
           ,IcraOzelDurumKrediTip
           ,IcraOzelDurumTahsilat)
     VALUES
           (@KurumsalMod
           ,@IcraANrefarans1
           ,@IcraANreferans2
           ,@IcraANreferans3
           ,@IcraReferans1
           ,@IcraReferans2
           ,@IcraReferans3
           ,@IcraOzelKod1
           ,@IcraOzelKod2
           ,@IcraOzelKod3
           ,@IcraOzelKod4
           ,@IcraOzelDurumBanka
           ,@IcraOzelDurumSube
           ,@IcraOzelDurumFoyBirim
           ,@IcraOzelDurumFoyYeri
           ,@IcraOzelDurumKlasor1
           ,@IcraOzelDurumKlasor2
           ,@IcraOzelDurumOzel
           ,@IcraOzelDurumKrediGrup
           ,@IcraOzelDurumKrediTip
           ,@IcraOzelDurumTahsilat)", _Connection);
                        cninsert.Parameters.AddWithValue("@KurumsalMod", _IcraOzelKodReferans.KurumsalMod);
                        cninsert.Parameters.AddWithValue("@IcraANrefarans1", _IcraOzelKodReferans.IcraANrefarans1);
                        cninsert.Parameters.AddWithValue("@IcraANreferans2", _IcraOzelKodReferans.IcraANreferans2);
                        cninsert.Parameters.AddWithValue("@IcraANreferans3", _IcraOzelKodReferans.IcraANreferans3);
                        cninsert.Parameters.AddWithValue("@IcraReferans1", _IcraOzelKodReferans.IcraReferans1);
                        cninsert.Parameters.AddWithValue("@IcraReferans2", _IcraOzelKodReferans.IcraReferans2);
                        cninsert.Parameters.AddWithValue("@IcraReferans3", _IcraOzelKodReferans.IcraReferans3);
                        cninsert.Parameters.AddWithValue("@IcraOzelKod1", _IcraOzelKodReferans.IcraOzelKod1);
                        cninsert.Parameters.AddWithValue("@IcraOzelKod2", _IcraOzelKodReferans.IcraOzelKod2);
                        cninsert.Parameters.AddWithValue("@IcraOzelKod3", _IcraOzelKodReferans.IcraOzelKod3);
                        cninsert.Parameters.AddWithValue("@IcraOzelKod4", _IcraOzelKodReferans.IcraOzelKod4);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumBanka", _IcraOzelKodReferans.IcraOzelDurumBanka);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumSube", _IcraOzelKodReferans.IcraOzelDurumSube);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumFoyBirim", _IcraOzelKodReferans.IcraOzelDurumFoyBirim);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumFoyYeri", _IcraOzelKodReferans.IcraOzelDurumFoyYeri);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumKlasor1", _IcraOzelKodReferans.IcraOzelDurumKlasor1);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumKlasor2", _IcraOzelKodReferans.IcraOzelDurumKlasor2);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumOzel", _IcraOzelKodReferans.IcraOzelDurumOzel);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumKrediGrup", _IcraOzelKodReferans.IcraOzelDurumKrediGrup);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumKrediTip", _IcraOzelKodReferans.IcraOzelDurumKrediTip);
                        cninsert.Parameters.AddWithValue("@IcraOzelDurumTahsilat", _IcraOzelKodReferans.IcraOzelDurumTahsilat);
                        cninsert.ExecuteNonQuery();
                    }
                }

                catch (Exception ex)
                {
                    DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
                }
                finally
                {
                    _Connection.Close();
                }
            }

            return _IcraOzelKodReferans;
        }

        public static SorusturmaOzelKodReferans GetSorusturmaOzelKodReferans(string connectionstring)
        {
            if (_SorusturmaOzelKodReferans == null)
            {
                _SorusturmaOzelKodReferans = new AvukatProLib.OzelKodReferans.SorusturmaOzelKodReferans();
                var _Connection = new SqlConnection(connectionstring);
                try
                {
                    _Connection.Open();
                    SqlCommand cn = new SqlCommand(@"
SELECT TOP 1 Id
      ,SorusturmaReferans1
      ,SorusturmaReferans2
      ,SorusturmaReferans3
      ,SorusturmaOzelKod1
      ,SorusturmaOzelKod2
      ,SorusturmaOzelKod3
      ,SorusturmaOzelKod4
  FROM OZEL_KOD_VE_REFERANSLAR_SORUSTURMA(nolock)", _Connection);
                    var dr = cn.ExecuteReader();
                    var cnt = false;
                    while (dr.Read())
                    {
                        _SorusturmaOzelKodReferans.Id = dr.GetInt32(0);
                        _SorusturmaOzelKodReferans.SorusturmaReferans1 = dr.GetString(1);
                        _SorusturmaOzelKodReferans.SorusturmaReferans2 = dr.GetString(2);
                        _SorusturmaOzelKodReferans.SorusturmaReferans3 = dr.GetString(3);
                        _SorusturmaOzelKodReferans.SorusturmaOzelKod1 = dr.GetString(4);
                        _SorusturmaOzelKodReferans.SorusturmaOzelKod2 = dr.GetString(5);
                        _SorusturmaOzelKodReferans.SorusturmaOzelKod3 = dr.GetString(6);
                        _SorusturmaOzelKodReferans.SorusturmaOzelKod4 = dr.GetString(7);
                        cnt = true;
                    }
                    dr.Close();
                    if (!cnt)
                    {
                        SqlCommand cninsert = new SqlCommand(@"
INSERT INTO OZEL_KOD_VE_REFERANSLAR_SORUSTURMA
           (SorusturmaReferans1
           ,SorusturmaReferans2
           ,SorusturmaReferans3
           ,SorusturmaOzelKod1
           ,SorusturmaOzelKod2
           ,SorusturmaOzelKod3
           ,SorusturmaOzelKod4)
     VALUES
           (@SorusturmaReferans1
           ,@SorusturmaReferans2
           ,@SorusturmaReferans3
           ,@SorusturmaOzelKod1
           ,@SorusturmaOzelKod2
           ,@SorusturmaOzelKod3
           ,@SorusturmaOzelKod4)", _Connection);
                        cninsert.Parameters.AddWithValue("@SorusturmaReferans1", _SorusturmaOzelKodReferans.SorusturmaReferans1);
                        cninsert.Parameters.AddWithValue("@SorusturmaReferans2", _SorusturmaOzelKodReferans.SorusturmaReferans2);
                        cninsert.Parameters.AddWithValue("@SorusturmaReferans3", _SorusturmaOzelKodReferans.SorusturmaReferans3);
                        cninsert.Parameters.AddWithValue("@SorusturmaOzelKod1", _SorusturmaOzelKodReferans.SorusturmaOzelKod1);
                        cninsert.Parameters.AddWithValue("@SorusturmaOzelKod2", _SorusturmaOzelKodReferans.SorusturmaOzelKod2);
                        cninsert.Parameters.AddWithValue("@SorusturmaOzelKod3", _SorusturmaOzelKodReferans.SorusturmaOzelKod3);
                        cninsert.Parameters.AddWithValue("@SorusturmaOzelKod4", _SorusturmaOzelKodReferans.SorusturmaOzelKod4);
                        cninsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
                }
                finally
                {
                    _Connection.Close();
                }
            }

            return _SorusturmaOzelKodReferans;
        }

        public static SozlesmeOzelKodReferans GetSozlesmeOzelKodReferans(string connectionstring)
        {
            if (_SozlesmeOzelKodReferans == null)
            {
                _SozlesmeOzelKodReferans = new AvukatProLib.OzelKodReferans.SozlesmeOzelKodReferans();
                var _Connection = new SqlConnection(connectionstring);
                try
                {
                    _Connection.Open();
                    SqlCommand cn = new SqlCommand(@"
SELECT TOP 1 Id
      ,SozlesmeReferans1
      ,SozlesmeReferans2
      ,SozlesmeReferans3
      ,SozlesmeOzelKod1
      ,SozlesmeOzelKod2
      ,SozlesmeOzelKod3
      ,SozlesmeOzelKod4
  FROM OZEL_KOD_VE_REFERANSLAR_SOZLESME(nolock)", _Connection);
                    var dr = cn.ExecuteReader();
                    var cnt = false;
                    while (dr.Read())
                    {
                        _SozlesmeOzelKodReferans.Id = dr.GetInt32(0);
                        _SozlesmeOzelKodReferans.SozlesmeReferans1 = dr.GetString(1);
                        _SozlesmeOzelKodReferans.SozlesmeReferans2 = dr.GetString(2);
                        _SozlesmeOzelKodReferans.SozlesmeReferans3 = dr.GetString(3);
                        _SozlesmeOzelKodReferans.SozlesmeOzelKod1 = dr.GetString(4);
                        _SozlesmeOzelKodReferans.SozlesmeOzelKod2 = dr.GetString(5);
                        _SozlesmeOzelKodReferans.SozlesmeOzelKod3 = dr.GetString(6);
                        _SozlesmeOzelKodReferans.SozlesmeOzelKod4 = dr.GetString(7);
                        cnt = true;
                    }
                    dr.Close();
                    if (!cnt)
                    {
                        SqlCommand cninsert = new SqlCommand(@"
INSERT INTO OZEL_KOD_VE_REFERANSLAR_SOZLESME
           (SozlesmeReferans1
           ,SozlesmeReferans2
           ,SozlesmeReferans3
           ,SozlesmeOzelKod1
           ,SozlesmeOzelKod2
           ,SozlesmeOzelKod3
           ,SozlesmeOzelKod4)
     VALUES
           (@SozlesmeReferans1
           ,@SozlesmeReferans2
           ,@SozlesmeReferans3
           ,@SozlesmeOzelKod1
           ,@SozlesmeOzelKod2
           ,@SozlesmeOzelKod3
           ,@SozlesmeOzelKod4)", _Connection);
                        cninsert.Parameters.AddWithValue("@SozlesmeReferans1", _SozlesmeOzelKodReferans.SozlesmeReferans1);
                        cninsert.Parameters.AddWithValue("@SozlesmeReferans2", _SozlesmeOzelKodReferans.SozlesmeReferans2);
                        cninsert.Parameters.AddWithValue("@SozlesmeReferans3", _SozlesmeOzelKodReferans.SozlesmeReferans3);
                        cninsert.Parameters.AddWithValue("@SozlesmeOzelKod1", _SozlesmeOzelKodReferans.SozlesmeOzelKod1);
                        cninsert.Parameters.AddWithValue("@SozlesmeOzelKod2", _SozlesmeOzelKodReferans.SozlesmeOzelKod2);
                        cninsert.Parameters.AddWithValue("@SozlesmeOzelKod3", _SozlesmeOzelKodReferans.SozlesmeOzelKod3);
                        cninsert.Parameters.AddWithValue("@SozlesmeOzelKod4", _SozlesmeOzelKodReferans.SozlesmeOzelKod4);
                        cninsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
                }
                finally
                {
                    _Connection.Close();
                }
            }

            return _SozlesmeOzelKodReferans;
        }

        public static void Kaydet(string connectionstring)
        {
            var _Connection = new SqlConnection(connectionstring);
            try
            {
                _Connection.Open();
                if (_DavaOzelKodReferans != null)
                {
                    SqlCommand cn = new SqlCommand(@"
UPDATE OZEL_KOD_VE_REFERANSLAR_DAVA
   SET DavaNedenReferans1 = @DavaNedenReferans1
      ,DavaNedenReferans2 = @DavaNedenReferans2
      ,DavaNedenReferans3 = @DavaNedenReferans3
      ,DavaOzelKod1 = @DavaOzelKod1
      ,DavaOzelKod2 = @DavaOzelKod2
      ,DavaOzelKod3 = @DavaOzelKod3
      ,DavaOzelKod4 = @DavaOzelKod4
      ,DavaReferans1 = @DavaReferans1
      ,DavaReferans2 = @DavaReferans2
      ,DavaReferans3 = @DavaReferans3", _Connection);
                    cn.Parameters.AddWithValue("@DavaNedenReferans1", _DavaOzelKodReferans.DavaNedenReferans1);
                    cn.Parameters.AddWithValue("@DavaNedenReferans2", _DavaOzelKodReferans.DavaNedenReferans2);
                    cn.Parameters.AddWithValue("@DavaNedenReferans3", _DavaOzelKodReferans.DavaNedenReferans3);
                    cn.Parameters.AddWithValue("@DavaOzelKod1", _DavaOzelKodReferans.DavaOzelKod1);
                    cn.Parameters.AddWithValue("@DavaOzelKod2", _DavaOzelKodReferans.DavaOzelKod2);
                    cn.Parameters.AddWithValue("@DavaOzelKod3", _DavaOzelKodReferans.DavaOzelKod3);
                    cn.Parameters.AddWithValue("@DavaOzelKod4", _DavaOzelKodReferans.DavaOzelKod4);
                    cn.Parameters.AddWithValue("@DavaReferans1", _DavaOzelKodReferans.DavaReferans1);
                    cn.Parameters.AddWithValue("@DavaReferans2", _DavaOzelKodReferans.DavaReferans2);
                    cn.Parameters.AddWithValue("@DavaReferans3", _DavaOzelKodReferans.DavaReferans3);
                    cn.ExecuteNonQuery();
                }

                if (_IcraOzelKodReferans != null)
                {
                    SqlCommand cn = new SqlCommand(@"
UPDATE OZEL_KOD_VE_REFERANSLAR_ICRA
   SET KurumsalMod = @KurumsalMod
      ,IcraANrefarans1 = @IcraANrefarans1
      ,IcraANreferans2 = @IcraANreferans2
      ,IcraANreferans3 = @IcraANreferans3
      ,IcraReferans1 = @IcraReferans1
      ,IcraReferans2 = @IcraReferans2
      ,IcraReferans3 = @IcraReferans3
      ,IcraOzelKod1 = @IcraOzelKod1
      ,IcraOzelKod2 = @IcraOzelKod2
      ,IcraOzelKod3 = @IcraOzelKod3
      ,IcraOzelKod4 = @IcraOzelKod4
      ,IcraOzelDurumBanka = @IcraOzelDurumBanka
      ,IcraOzelDurumSube = @IcraOzelDurumSube
      ,IcraOzelDurumFoyBirim = @IcraOzelDurumFoyBirim
      ,IcraOzelDurumFoyYeri = @IcraOzelDurumFoyYeri
      ,IcraOzelDurumKlasor1 = @IcraOzelDurumKlasor1
      ,IcraOzelDurumKlasor2 = @IcraOzelDurumKlasor2
      ,IcraOzelDurumOzel = @IcraOzelDurumOzel
      ,IcraOzelDurumKrediGrup = @IcraOzelDurumKrediGrup
      ,IcraOzelDurumKrediTip = @IcraOzelDurumKrediTip
      ,IcraOzelDurumTahsilat = @IcraOzelDurumTahsilat", _Connection);
                    cn.Parameters.AddWithValue("@KurumsalMod", _IcraOzelKodReferans.KurumsalMod);
                    cn.Parameters.AddWithValue("@IcraANrefarans1", _IcraOzelKodReferans.IcraANrefarans1);
                    cn.Parameters.AddWithValue("@IcraANreferans2", _IcraOzelKodReferans.IcraANreferans2);
                    cn.Parameters.AddWithValue("@IcraANreferans3", _IcraOzelKodReferans.IcraANreferans3);
                    cn.Parameters.AddWithValue("@IcraReferans1", _IcraOzelKodReferans.IcraReferans1);
                    cn.Parameters.AddWithValue("@IcraReferans2", _IcraOzelKodReferans.IcraReferans2);
                    cn.Parameters.AddWithValue("@IcraReferans3", _IcraOzelKodReferans.IcraReferans3);
                    cn.Parameters.AddWithValue("@IcraOzelKod1", _IcraOzelKodReferans.IcraOzelKod1);
                    cn.Parameters.AddWithValue("@IcraOzelKod2", _IcraOzelKodReferans.IcraOzelKod2);
                    cn.Parameters.AddWithValue("@IcraOzelKod3", _IcraOzelKodReferans.IcraOzelKod3);
                    cn.Parameters.AddWithValue("@IcraOzelKod4", _IcraOzelKodReferans.IcraOzelKod4);
                    cn.Parameters.AddWithValue("@IcraOzelDurumBanka", _IcraOzelKodReferans.IcraOzelDurumBanka);
                    cn.Parameters.AddWithValue("@IcraOzelDurumSube", _IcraOzelKodReferans.IcraOzelDurumSube);
                    cn.Parameters.AddWithValue("@IcraOzelDurumFoyBirim", _IcraOzelKodReferans.IcraOzelDurumFoyBirim);
                    cn.Parameters.AddWithValue("@IcraOzelDurumFoyYeri", _IcraOzelKodReferans.IcraOzelDurumFoyYeri);
                    cn.Parameters.AddWithValue("@IcraOzelDurumKlasor1", _IcraOzelKodReferans.IcraOzelDurumKlasor1);
                    cn.Parameters.AddWithValue("@IcraOzelDurumKlasor2", _IcraOzelKodReferans.IcraOzelDurumKlasor2);
                    cn.Parameters.AddWithValue("@IcraOzelDurumOzel", _IcraOzelKodReferans.IcraOzelDurumOzel);
                    cn.Parameters.AddWithValue("@IcraOzelDurumKrediGrup", _IcraOzelKodReferans.IcraOzelDurumKrediGrup);
                    cn.Parameters.AddWithValue("@IcraOzelDurumKrediTip", _IcraOzelKodReferans.IcraOzelDurumKrediTip);
                    cn.Parameters.AddWithValue("@IcraOzelDurumTahsilat", _IcraOzelKodReferans.IcraOzelDurumTahsilat);
                    cn.ExecuteNonQuery();
                }

                if (_OrtakOzelKodReferans != null)
                {
                    SqlCommand cninsert = new SqlCommand(@"
UPDATE OZEL_KOD_VE_REFERANSLAR_ORTAK_OZEL_DURUM
   SET OrtakOzelDurumBanka = @OrtakOzelDurumBanka
      ,OrtakOzelDurumSube = @OrtakOzelDurumSube
      ,OrtakOzelDurumFoyBirim = @OrtakOzelDurumFoyBirim
      ,OrtakOzelDurumFoyYeri = @OrtakOzelDurumFoyYeri
      ,OrtakOzelDurumKlasor1 = @OrtakOzelDurumKlasor1
      ,OrtakOzelDurumKlasor2 = @OrtakOzelDurumKlasor2
      ,OrtakOzelDurumOzel = @OrtakOzelDurumOzel
      ,OrtakOzelDurumKrediGrup = @OrtakOzelDurumKrediGrup
      ,OrtakOzelDurumKrediTip = @OrtakOzelDurumKrediTip
      ,OrtakOzelDurumTahsilat = @OrtakOzelDurumTahsilat", _Connection);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumBanka", _OrtakOzelKodReferans.OrtakOzelDurumBanka);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumSube", _OrtakOzelKodReferans.OrtakOzelDurumSube);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumFoyBirim", _OrtakOzelKodReferans.OrtakOzelDurumFoyBirim);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumFoyYeri", _OrtakOzelKodReferans.OrtakOzelDurumFoyYeri);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumKlasor1", _OrtakOzelKodReferans.OrtakOzelDurumKlasor1);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumKlasor2", _OrtakOzelKodReferans.OrtakOzelDurumKlasor2);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumOzel", _OrtakOzelKodReferans.OrtakOzelDurumOzel);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumKrediGrup", _OrtakOzelKodReferans.OrtakOzelDurumKrediGrup);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumKrediTip", _OrtakOzelKodReferans.OrtakOzelDurumKrediTip);
                    cninsert.Parameters.AddWithValue("@OrtakOzelDurumTahsilat", _OrtakOzelKodReferans.OrtakOzelDurumTahsilat);
                    cninsert.ExecuteNonQuery();
                }

                if (_SorusturmaOzelKodReferans != null)
                {
                    SqlCommand cninsert = new SqlCommand(@"
UPDATE OZEL_KOD_VE_REFERANSLAR_SORUSTURMA
   SET SorusturmaReferans1 = @SorusturmaReferans1
      ,SorusturmaReferans2 = @SorusturmaReferans2
      ,SorusturmaReferans3 = @SorusturmaReferans3
      ,SorusturmaOzelKod1 = @SorusturmaOzelKod1
      ,SorusturmaOzelKod2 = @SorusturmaOzelKod2
      ,SorusturmaOzelKod3 = @SorusturmaOzelKod3
      ,SorusturmaOzelKod4 = @SorusturmaOzelKod4", _Connection);
                    cninsert.Parameters.AddWithValue("@SorusturmaReferans1", _SorusturmaOzelKodReferans.SorusturmaReferans1);
                    cninsert.Parameters.AddWithValue("@SorusturmaReferans2", _SorusturmaOzelKodReferans.SorusturmaReferans2);
                    cninsert.Parameters.AddWithValue("@SorusturmaReferans3", _SorusturmaOzelKodReferans.SorusturmaReferans3);
                    cninsert.Parameters.AddWithValue("@SorusturmaOzelKod1", _SorusturmaOzelKodReferans.SorusturmaOzelKod1);
                    cninsert.Parameters.AddWithValue("@SorusturmaOzelKod2", _SorusturmaOzelKodReferans.SorusturmaOzelKod2);
                    cninsert.Parameters.AddWithValue("@SorusturmaOzelKod3", _SorusturmaOzelKodReferans.SorusturmaOzelKod3);
                    cninsert.Parameters.AddWithValue("@SorusturmaOzelKod4", _SorusturmaOzelKodReferans.SorusturmaOzelKod4);
                    cninsert.ExecuteNonQuery();
                }

                if (_SozlesmeOzelKodReferans != null)
                {
                    SqlCommand cninsert = new SqlCommand(@"
UPDATE OZEL_KOD_VE_REFERANSLAR_SOZLESME
   SET SozlesmeReferans1 = @SozlesmeReferans1
      ,SozlesmeReferans2 = @SozlesmeReferans2
      ,SozlesmeReferans3 = @SozlesmeReferans3
      ,SozlesmeOzelKod1 = @SozlesmeOzelKod1
      ,SozlesmeOzelKod2 = @SozlesmeOzelKod2
      ,SozlesmeOzelKod3 = @SozlesmeOzelKod3
      ,SozlesmeOzelKod4 = @SozlesmeOzelKod4");
                    cninsert.Parameters.AddWithValue("@SozlesmeReferans1", _SozlesmeOzelKodReferans.SozlesmeReferans1);
                    cninsert.Parameters.AddWithValue("@SozlesmeReferans2", _SozlesmeOzelKodReferans.SozlesmeReferans2);
                    cninsert.Parameters.AddWithValue("@SozlesmeReferans3", _SozlesmeOzelKodReferans.SozlesmeReferans3);
                    cninsert.Parameters.AddWithValue("@SozlesmeOzelKod1", _SozlesmeOzelKodReferans.SozlesmeOzelKod1);
                    cninsert.Parameters.AddWithValue("@SozlesmeOzelKod2", _SozlesmeOzelKodReferans.SozlesmeOzelKod2);
                    cninsert.Parameters.AddWithValue("@SozlesmeOzelKod3", _SozlesmeOzelKodReferans.SozlesmeOzelKod3);
                    cninsert.Parameters.AddWithValue("@SozlesmeOzelKod4", _SozlesmeOzelKodReferans.SozlesmeOzelKod4); ;
                    cninsert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public static OrtakOzelKodReferans GetOrtakOzelKodReferans(string connectionstring)
        {
            if (_OrtakOzelKodReferans == null)
            {
                _OrtakOzelKodReferans = new AvukatProLib.OzelKodReferans.OrtakOzelKodReferans();
                var _Connection = new SqlConnection(connectionstring);
                try
                {
                    _Connection.Open();
                    SqlCommand cn = new SqlCommand(@"
SELECT TOP 1
	   Id
      ,OrtakOzelDurumBanka
      ,OrtakOzelDurumSube
      ,OrtakOzelDurumFoyBirim
      ,OrtakOzelDurumFoyYeri
      ,OrtakOzelDurumKlasor1
      ,OrtakOzelDurumKlasor2
      ,OrtakOzelDurumOzel
      ,OrtakOzelDurumKrediGrup
      ,OrtakOzelDurumKrediTip
      ,OrtakOzelDurumTahsilat
  FROM OZEL_KOD_VE_REFERANSLAR_ORTAK_OZEL_DURUM(nolock)", _Connection);
                    var dr = cn.ExecuteReader();
                    var cnt = false;
                    while (dr.Read())
                    {
                        _OrtakOzelKodReferans.Id = dr.GetInt32(0);
                        _OrtakOzelKodReferans.OrtakOzelDurumBanka = dr.GetString(1);
                        _OrtakOzelKodReferans.OrtakOzelDurumSube = dr.GetString(2);
                        _OrtakOzelKodReferans.OrtakOzelDurumFoyBirim = dr.GetString(3);
                        _OrtakOzelKodReferans.OrtakOzelDurumFoyYeri = dr.GetString(4);
                        _OrtakOzelKodReferans.OrtakOzelDurumKlasor1 = dr.GetString(5);
                        _OrtakOzelKodReferans.OrtakOzelDurumKlasor2 = dr.GetString(6);
                        _OrtakOzelKodReferans.OrtakOzelDurumOzel = dr.GetString(7);
                        _OrtakOzelKodReferans.OrtakOzelDurumKrediGrup = dr.GetString(8);
                        _OrtakOzelKodReferans.OrtakOzelDurumKrediTip = dr.GetString(9);
                        _OrtakOzelKodReferans.OrtakOzelDurumTahsilat = dr.GetString(10);
                        cnt = true;
                    }
                    dr.Close();
                    if (!cnt)
                    {
                        SqlCommand cninsert = new SqlCommand(@"
INSERT INTO OZEL_KOD_VE_REFERANSLAR_ORTAK_OZEL_DURUM
           (OrtakOzelDurumBanka
           ,OrtakOzelDurumSube
           ,OrtakOzelDurumFoyBirim
           ,OrtakOzelDurumFoyYeri
           ,OrtakOzelDurumKlasor1
           ,OrtakOzelDurumKlasor2
           ,OrtakOzelDurumOzel
           ,OrtakOzelDurumKrediGrup
           ,OrtakOzelDurumKrediTip
           ,OrtakOzelDurumTahsilat)
     VALUES
           (@OrtakOzelDurumBanka
           ,@OrtakOzelDurumSube
           ,@OrtakOzelDurumFoyBirim
           ,@OrtakOzelDurumFoyYeri
           ,@OrtakOzelDurumKlasor1
           ,@OrtakOzelDurumKlasor2
           ,@OrtakOzelDurumOzel
           ,@OrtakOzelDurumKrediGrup
           ,@OrtakOzelDurumKrediTip
           ,@OrtakOzelDurumTahsilat)", _Connection);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumBanka", _OrtakOzelKodReferans.OrtakOzelDurumBanka);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumSube", _OrtakOzelKodReferans.OrtakOzelDurumSube);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumFoyBirim", _OrtakOzelKodReferans.OrtakOzelDurumFoyBirim);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumFoyYeri", _OrtakOzelKodReferans.OrtakOzelDurumFoyYeri);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumKlasor1", _OrtakOzelKodReferans.OrtakOzelDurumKlasor1);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumKlasor2", _OrtakOzelKodReferans.OrtakOzelDurumKlasor2);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumOzel", _OrtakOzelKodReferans.OrtakOzelDurumOzel);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumKrediGrup", _OrtakOzelKodReferans.OrtakOzelDurumKrediGrup);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumKrediTip", _OrtakOzelKodReferans.OrtakOzelDurumKrediTip);
                        cninsert.Parameters.AddWithValue("@OrtakOzelDurumTahsilat", _OrtakOzelKodReferans.OrtakOzelDurumTahsilat);
                        cninsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    DbUpdate.DbUpdater.logger.ErrorException("hata", ex);
                }
                finally
                {
                    _Connection.Close();
                }
            }

            return _OrtakOzelKodReferans;
        }
    }

    public class SorusturmaOzelKodReferans
    {
        private int _Id;
        private string _SorusturmaOzelKod1;

        private string _SorusturmaOzelKod2;

        private string _SorusturmaOzelKod3;

        private string _SorusturmaOzelKod4;

        private string _SorusturmaReferans1;

        private string _SorusturmaReferans2;

        private string _SorusturmaReferans3;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string SorusturmaOzelKod1
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaOzelKod1))
                {
                    _SorusturmaOzelKod1 = "OzelKod1";
                }
                return _SorusturmaOzelKod1;
            }
            set
            {
                _SorusturmaOzelKod1 = value;
            }
        }

        public string SorusturmaOzelKod2
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaOzelKod2))
                {
                    _SorusturmaOzelKod2 = "OzelKod2";
                }
                return _SorusturmaOzelKod2;
            }
            set
            {
                _SorusturmaOzelKod2 = value;
            }
        }

        public string SorusturmaOzelKod3
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaOzelKod3))
                {
                    _SorusturmaOzelKod3 = "OzelKod3";
                }
                return _SorusturmaOzelKod3;
            }
            set
            {
                _SorusturmaOzelKod3 = value;
            }
        }

        public string SorusturmaOzelKod4
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaOzelKod4))
                {
                    _SorusturmaOzelKod4 = "OzelKod4";
                }
                return _SorusturmaOzelKod4;
            }
            set
            {
                _SorusturmaOzelKod4 = value;
            }
        }

        public string SorusturmaReferans1
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaReferans1))
                {
                    _SorusturmaReferans1 = "Referans1";
                }
                return _SorusturmaReferans1;
            }
            set
            {
                _SorusturmaReferans1 = value;
            }
        }

        public string SorusturmaReferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaReferans2))
                {
                    _SorusturmaReferans2 = "Referans2";
                }
                return _SorusturmaReferans2;
            }
            set
            {
                _SorusturmaReferans2 = value;
            }
        }

        public string SorusturmaReferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_SorusturmaReferans3))
                {
                    _SorusturmaReferans3 = "Referans3";
                }
                return _SorusturmaReferans3;
            }
            set
            {
                _SorusturmaReferans3 = value;
            }
        }
    }

    public class SozlesmeOzelKodReferans
    {
        private int _Id;
        private string _SozlesmeOzelKod1;

        private string _SozlesmeOzelKod2;

        private string _SozlesmeOzelKod3;

        private string _SozlesmeOzelKod4;

        private string _SozlesmeReferans1;

        private string _SozlesmeReferans2;

        private string _SozlesmeReferans3;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string SozlesmeOzelKod1
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeOzelKod1))
                {
                    _SozlesmeOzelKod1 = "OzelKod1";
                }
                return _SozlesmeOzelKod1;
            }
            set
            {
                _SozlesmeOzelKod1 = value;
            }
        }

        public string SozlesmeOzelKod2
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeOzelKod2))
                {
                    _SozlesmeOzelKod2 = "OzelKod2";
                }
                return _SozlesmeOzelKod2;
            }
            set
            {
                _SozlesmeOzelKod2 = value;
            }
        }

        public string SozlesmeOzelKod3
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeOzelKod3))
                {
                    _SozlesmeOzelKod3 = "OzelKod3";
                }
                return _SozlesmeOzelKod3;
            }
            set
            {
                _SozlesmeOzelKod3 = value;
            }
        }

        public string SozlesmeOzelKod4
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeOzelKod4))
                {
                    _SozlesmeOzelKod4 = "OzelKod4";
                }
                return _SozlesmeOzelKod4;
            }
            set
            {
                _SozlesmeOzelKod4 = value;
            }
        }

        public string SozlesmeReferans1
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeReferans1))
                {
                    _SozlesmeReferans1 = "Referans1";
                }
                return _SozlesmeReferans1;
            }
            set
            {
                _SozlesmeReferans1 = value;
            }
        }

        public string SozlesmeReferans2
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeReferans2))
                {
                    _SozlesmeReferans2 = "Referans2";
                }
                return _SozlesmeReferans2;
            }
            set
            {
                _SozlesmeReferans2 = value;
            }
        }

        public string SozlesmeReferans3
        {
            get
            {
                if (string.IsNullOrEmpty(_SozlesmeReferans3))
                {
                    _SozlesmeReferans3 = "Referans3";
                }
                return _SozlesmeReferans3;
            }
            set
            {
                _SozlesmeReferans3 = value;
            }
        }
    }
}