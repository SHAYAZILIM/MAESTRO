using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BelgeUtil
{
    public static class CodeInfo<T>
    {
        public static IList<T> ListeGetir(Type T)
        {
            string file = Application.StartupPath + "//CodeData//" + T.FullName + ".code";
            IList<T> liste = null;
            FileStream fss = null;
            try
            {
                if (File.Exists(file))
                {
                    fss = File.OpenRead(file);
                    BinaryFormatter bff = new BinaryFormatter();
                    liste = (IList<T>)bff.Deserialize(fss);
                    fss.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return liste;
        }

        public static bool ListeKaydet(IList<T> liste, Type T)
        {
            try
            {
                string directory = Application.StartupPath + "\\CodeData";
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string file = Application.StartupPath + "//CodeData//" + T.FullName + ".code";

                FileStream fs = null;

                if (!File.Exists(file))
                {
                    fs = new FileStream(file, FileMode.CreateNew);
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(fs, liste);
                    fs.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(null, ex);
                return false;
            }
        }

        public static bool ListeVarmi(Type T)
        {
            string file = Application.StartupPath + "//CodeData//" + T.FullName + ".code";
            return File.Exists(file);
        }
    }
}