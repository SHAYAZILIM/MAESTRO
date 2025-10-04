using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AvukatProLib.DbUpdate
{
    public static class DbUpdater
    {
        //TODO: 11072009 hatalý chekin yapýldýðýndan alt satýr tarafýmdan comment edilmiþtir. -THSN -
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Veritabaný yükseltmesi için kullanýlan method.
        /// </summary>
        /// <param name="fromVersion">Þuanki Sürüm</param>
        /// <param name="toVersion">Yükseltilecek sürüm</param>
        /// <returns>Yükseltme baþarýlý olduðu takdirde true, baþarýsýz olduðu takdirde false döner.</returns>
        public static bool UpdateDb(DbVersion fromVersion, DbVersion toVersion, string conStr, string startupPath)
        {
            List<String> bulunanlar = new List<string>(Directory.GetDirectories(startupPath + "\\DB_SCRIPTS\\", fromVersion + "*", SearchOption.TopDirectoryOnly));

            //SATIR 13 AÇIKLAMA
            if (bulunanlar.Count == 0)
                logger.Debug(string.Format(@"Veritabanýna uygun script dosyalarý bulanadý.DB_SCRIPTS\{0}*", fromVersion));
            else
                logger.Debug(string.Format("bulunan script dosyalarý : {0}", string.Join(",", bulunanlar.ToArray())));

            bool donecekDeger = false;
            while (bulunanlar.Count > 0)
            {
                donecekDeger = true;
                bulunanlar.Sort();
                bulunanlar.Reverse();
                string enSonGuncelleme = bulunanlar[0];
                string[] versionlar = enSonGuncelleme.Split('-');
                DbVersion v1 = new DbVersion(versionlar[0]);
                DbVersion v2 = new DbVersion(versionlar[1]);

                frmDbBulkScriptExecuter frm = new frmDbBulkScriptExecuter(conStr, enSonGuncelleme);
                frm.Text += string.Format(" ({0})", v2);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Veritabaný Güncellemeleri Tamamlanamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                bulunanlar = new List<string>(Directory.GetDirectories(startupPath + "\\DB_SCRIPTS\\", v2.VersionString + "*", SearchOption.TopDirectoryOnly));
            }
            return donecekDeger;
        }
    }

    public class DbVersion : IComparable<DbVersion>, IComparer<DbVersion>, IEqualityComparer<DbVersion>
    {
        public DbVersion(string versionString)
        {
            VersionString = versionString;
        }

        public DbVersion(int major, int minor, int tiny)
        {
            Major = major;
            Minor = minor;
            Tiny = tiny;
        }

        private int _Major;
        private int _Minor;
        private int _Tiny;
        private string _VersionString;

        public int Major
        {
            get { return _Major; }
            set { _Major = value; }
        }

        public int Minor
        {
            get { return _Minor; }
            set { _Minor = value; }
        }

        public int Tiny
        {
            get { return _Tiny; }
            set { _Tiny = value; }
        }

        public string VersionString
        {
            get { return _VersionString; }
            set
            {
                _VersionString = value;
                ParseVersion();
            }
        }

        public static bool operator <(DbVersion bir, DbVersion iki)
        {
            if (bir.CompareTo(iki) < 0)
                return true;
            return false;
        }

        public static bool operator <=(DbVersion bir, DbVersion iki)
        {
            if (bir.CompareTo(iki) <= 0)
                return true;
            return false;
        }

        public static bool operator >(DbVersion bir, DbVersion iki)
        {
            if (bir.CompareTo(iki) > 0)
                return true;
            return false;
        }

        public static bool operator >=(DbVersion bir, DbVersion iki)
        {
            if (bir.CompareTo(iki) >= 0)
                return true;
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Major.ToString());
            sb.Append('.');
            sb.Append(Minor.ToString());
            sb.Append('.');
            sb.Append(Tiny.ToString());

            return sb.ToString();
        }

        private void ParseVersion()
        {
            string[] parts = _VersionString.Split('.');
            for (int i = 0; i < parts.Length; i++)
            {
                string version = parts[i];
                switch (i)
                {
                    case 0:
                        Int32.TryParse(version, out _Major);
                        break;

                    case 1:
                        Int32.TryParse(version, out _Minor);
                        break;

                    case 2:
                        Int32.TryParse(version, out _Tiny);
                        break;

                    default:
                        break;
                }
            }
        }

        #region IComparable<DbVersion> Members

        public int CompareTo(DbVersion other)
        {
            int result = new int();
            result += (this.Major - other.Major) * 100;
            result += (this.Minor - other.Minor) * 10;
            result += (this.Tiny - other.Tiny) * 1;
            return result;
        }

        #endregion IComparable<DbVersion> Members

        #region IComparer<DbVersion> Members

        public int Compare(DbVersion x, DbVersion y)
        {
            int result = new int();
            result += (x.Major - y.Major) * 100;
            result += (x.Minor - y.Minor) * 10;
            result += (x.Tiny - y.Tiny) * 1;
            return result;
        }

        #endregion IComparer<DbVersion> Members

        //public static bool operator !=(DbVersion bir, DbVersion iki)
        //{
        //    if (bir.CompareTo(iki) != 0)
        //        return true;
        //    return false;
        //}
        //public static bool operator ==(DbVersion bir, DbVersion iki)
        //{
        //    if (bir.CompareTo(iki) == 0)
        //        return true;
        //    return false;
        //}

        #region IEqualityComparer<DbVersion> Members

        public bool Equals(DbVersion x, DbVersion y)
        {
            if (x != null && y != null)
            {
                return x.VersionString == y.VersionString;
            }
            else if (x == null && y == null)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(DbVersion obj)
        {
            return base.GetHashCode();
        }

        #endregion IEqualityComparer<DbVersion> Members
    }
}