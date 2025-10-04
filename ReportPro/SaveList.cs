using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ReportPro
{
    [Serializable]
    public class SaveList : List<SaveListItem>
    {
        public SaveList()
        {
            string path = ReportPro.Utils.Tools.Temp + "Saverp.srp";
            if (Utils.Tools.DosyaKontrol(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    object serialized = bf.Deserialize(fs);
                    SaveListItem[] slist = (serialized as SaveListItem[]);
                    if (slist != null)
                    {
                        this.AddRange(slist.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message); Enver Burasý Bakýlacak
                    Utils.Tools.Logla(ex, this);
                }
                finally { fs.Close(); }
            }
        }

        public delegate void OnBeforeSave(SaveList sender, string path);

        public event OnBeforeSave BeforeSave;

        /// <summary>
        /// saves the datas as a binnary file with binnary serialization and returns the serialized
        /// saved data files path
        /// </summary>
        /// <returns>saved file path</returns>
        public string Save()
        {
            string path = Utils.Tools.Temp + "Saverp.srp";
            if (BeforeSave != null)
            {
                BeforeSave(this, path);
            }

            FileStream fs = null;
            if (File.Exists(path))
            {
                fs = new FileStream(path, FileMode.Open);
            }
            else
            {
                fs = new FileStream(path, FileMode.CreateNew);
            }
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, this.ToArray());
            }
            catch (Exception ex)
            {
                Utils.Tools.Logla(ex, this);
            }
            finally
            {
                fs.Close();
            }

            return path;
        }
    }
}