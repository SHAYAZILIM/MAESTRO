using AvukatProLib.Util.Is;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;

namespace AvukatProLib.Util
{
    public static class SchedulerResourceHelper
    {
        public static string ConvertToResource(int id)
        {
            return "<ResourceId Type=\"System.Int32\" Value=\"" + id.ToString() + "\" />";
        }

        public static TList<AV001_TDI_BIL_IS_TARAF> GetResourcesAsTaraf(string Resources)
        {
            TList<AV001_TDI_BIL_IS_TARAF> taraflar = new TList<AV001_TDI_BIL_IS_TARAF>();

            string[] resources = Resources.Split(new string[] { "<ResourceId Type=\"System.Int32\" Value=\"" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < resources.Length; i++)
            {
                string[] kisiId = resources[i].Split(new string[] { "\" />" }, StringSplitOptions.RemoveEmptyEntries);
                if (kisiId.Length > 0)
                {
                    int kisi = 0;
                    if (int.TryParse(kisiId[0], out kisi))
                    {
                        AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                        taraf.CARI_ID = kisi;
                        taraf.IS_TARAF_ID = 1;
                        taraflar.Add(taraf);
                    }
                }
            }

            return taraflar;
        }

        public static TList<AV001_TDI_BIL_IS_TARAF> GetTaraf(List<IsTarafi> isTaraflari)
        {
            TList<AV001_TDI_BIL_IS_TARAF> taraflar = new TList<AV001_TDI_BIL_IS_TARAF>();

            //string[] res= Xml.Split("<ResourceId Type=\"System.Int32\" Value=", StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < res.Length; i++)
            //{
            //    int ResourceId = 0;

            // if (!int.TryParse(res[i].Replace("\"/>", ""), out ResourceId )) { throw new
            // NotImplementedException("Resource yüklenemedi."); } isTaraflari[i].
            // AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF(); taraf.CARI_ID =
            // ResourceId; taraf.IS_TARAF_ID= taraflar.Add();
            //}
            for (int i = 0; i < isTaraflari.Count; i++)
            {
                if (isTaraflari[i].Dagitici)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 1;
                    taraflar.Add(taraf);
                }

                if (isTaraflari[i].Muhatap)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 2;
                    taraflar.Add(taraf);
                }

                if (isTaraflari[i].Planlayan)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 3;
                    taraflar.Add(taraf);
                }

                if (isTaraflari[i].Sahibi)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 4;
                    taraflar.Add(taraf);
                }

                if (isTaraflari[i].Sorumlu)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 5;
                    taraflar.Add(taraf);
                }

                if (isTaraflari[i].Yetkili)
                {
                    AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                    taraf.CARI_ID = isTaraflari[i].Cari;
                    taraf.IS_TARAF_ID = 6;
                    taraflar.Add(taraf);
                }
            }

            return taraflar;
        }

        public static void SetRecordResource(VDI_BIL_IS isim, int id)
        {
            if (isim.TARAFLAR == null)
            {
                System.Windows.Forms.MessageBox.Show("Bu kaydýn taraflarý düzgün bir þekilde ayarlanmamýþ ! ");
                return;
            }
            string[] taraflar = isim.TARAFLAR.Split(new string[] { "<ResourceId Type=\"System.Int32\" Value=\"" }, StringSplitOptions.RemoveEmptyEntries);
            bool varmiTaraf = false;
            for (int i = 0; i < taraflar.Length; i++)
            {
                string[] taraf = taraflar[i].Split(new string[] { "\" />" }, StringSplitOptions.RemoveEmptyEntries);
                if (taraf.Length > 0)
                {
                    int Rid = 0;
                    if (int.TryParse(taraf[0], out Rid))
                    {
                        if (Rid == id)
                        {
                            varmiTaraf = true;
                        }
                    }
                }
            }
            if (taraflar.Length <= 1)
            {
                isim.TARAFLAR = "<ResourceIds>  " + ConvertToResource(id) + "</ResourceIds>";
            }
            else
            {
                if (!varmiTaraf)
                {
                    isim.TARAFLAR = isim.TARAFLAR.Replace("</ResourceIds>", "");
                    isim.TARAFLAR += ConvertToResource(id) + "</ResourceIds>";
                }
            }
        }
    }
}