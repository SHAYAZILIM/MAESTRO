using AvukatProLib.Util.Is;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AvukatProLib.Util
{
    public static class SaveRecord
    {
        public static void Save(object Data)
        {
            if (Data is IBindingList)
            {
                IBindingList listData = (Data as IBindingList);
                SaveTList(listData);
            }
            else if (Data is IEntity)
            {
                SaveIEntity(Data);
            }
        }

        public static void SaveFromView(IBindingList Data)
        {
            if (Data.Count > 0)
            {
                if (Data[0] is VDI_BIL_IS)
                {
                    VList<VDI_BIL_IS> LstData = new VList<VDI_BIL_IS>();
                    LstData = (VList<VDI_BIL_IS>)Data;
                    for (int i = 0; i < LstData.Count; i++)
                    {
                        if (LstData[i].IsNew || LstData[i].IsDirty || LstData[i].IsDeleted)
                        {
                            try
                            {
                                AvukatProLib2.Entities.AV001_TDI_BIL_IS isim = new AV001_TDI_BIL_IS();
                                if (LstData[i].IsDirty && !LstData[i].IsNew)
                                {
                                    isim = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.GetByID(LstData[i].ID);
                                }

                                isim.ID = LstData[i].ID;
                                isim.ACIKLAMA = LstData[i].ACIKLAMA;
                                isim.ADLI_BIRIM_ADLIYE_ID = LstData[i].ADLI_BIRIM_ADLIYE_ID;
                                if (LstData[i].ADLI_BIRIM_GOREV_ID == 0)
                                {
                                    LstData[i].ADLI_BIRIM_GOREV_ID = 1;
                                }
                                isim.ADLI_BIRIM_GOREV_ID = LstData[i].ADLI_BIRIM_GOREV_ID;
                                if (LstData[i].ADLI_BIRIM_NO_ID == 0)
                                {
                                    LstData[i].ADLI_BIRIM_NO_ID = 1;
                                }
                                isim.ADLI_BIRIM_NO_ID = LstData[i].ADLI_BIRIM_NO_ID;
                                isim.AJANDADA_GORUNSUN_MU = LstData[i].AJANDADA_GORUNSUN_MU;
                                if (LstData[i].BASLANGIC_TARIHI.HasValue && LstData[i].BASLANGIC_TARIHI.Value < DateTime.Parse("01.01.1900"))
                                {
                                    LstData[i].BASLANGIC_TARIHI = DateTime.Now;
                                }
                                isim.BASLANGIC_TARIHI = LstData[i].BASLANGIC_TARIHI;
                                isim.BITIS_TARIHI = LstData[i].BITIS_TARIHI;
                                isim.DURUM = LstData[i].DURUM;
                                isim.ESAS_NO = LstData[i].ESAS_NO;
                                isim.ETIKET_ID = LstData[i].ETIKET_ID;
                                if (LstData[i].FORM_ID == 0)
                                {
                                    LstData[i].FORM_ID = 1;
                                }
                                isim.FORM_ID = LstData[i].FORM_ID;
                                isim.HATIRLATILSIN_MI = LstData[i].HATIRLATILSIN_MI;
                                isim.HATIRLATMA_BILGISI = LstData[i].HATIRLATMA_BILGISI;
                                isim.HATIRLATMA_ID = LstData[i].HATIRLATMA_ID;
                                isim.HER_GUN_MU = LstData[i].HER_GUN_MU;
                                isim.IS_NO = LstData[i].IS_NO;

                                // isim.IsDeleted = LstData[i].IsDeleted; isim.IsDirty =
                                // LstData[i].IsDirty;
                                isim.IsNew = LstData[i].IsNew;
                                isim.KATEGORI_ID = LstData[i].KATEGORI_ID;

                                // isim.KAYIT_TARIHI = LstData[i].KAYIT_TARIHI;
                                isim.KONU = LstData[i].KONU;
                                isim.MUHASEBELESTIRILSIN_MI = LstData[i].MUHASEBELESTIRILSIN_MI;
                                if (LstData[i].ONCELIK_ID == 0)
                                {
                                    LstData[i].ONCELIK_ID = 1;
                                }
                                isim.ONCELIK_ID = LstData[i].ONCELIK_ID;
                                isim.ONGORULEN_BITIS_TARIHI = LstData[i].ONGORULEN_BITIS_TARIHI;
                                isim.STATU_ID = LstData[i].STATU_ID;

                                // isim.SUBE_KOD_ID = LstData[i].SUBE_KOD_ID;
                                isim.Tag = LstData[i].Tag;
                                isim.TARAFLAR = LstData[i].TARAFLAR;
                                isim.TEKRARLAMA_BILGISI = LstData[i].TEKRARLAMA_BILGISI;
                                isim.TIP = LstData[i].TIP;
                                isim.YAPILACAK_IS = LstData[i].YAPILACAK_IS;
                                isim.YER = LstData[i].YER;
                                isim.REFERANS_NO = DateTime.Now.Ticks.ToString();
                                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(isim);
                                TList<AvukatProLib2.Entities.AV001_TDI_BIL_IS_TARAF> TARAFLAR = new TList<AV001_TDI_BIL_IS_TARAF>();
                                if (LstData[i].Tag == null)
                                {
                                    TARAFLAR = SchedulerResourceHelper.GetResourcesAsTaraf(LstData[i].TARAFLAR);
                                }
                                else
                                {
                                    TARAFLAR = SchedulerResourceHelper.GetTaraf((List<IsTarafi>)LstData[i].Tag);
                                }
                                LstData[i].AcceptChanges();
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.Error("Hata", ex);
                                System.Windows.Forms.MessageBox.Show(LstData[i].IS_NO + " numaralý iþ kaydý sýrasýnda bazý sorunlarla karþýlaþýldý !");
                            }
                        }
                    }

                    System.Windows.Forms.MessageBox.Show("Kayýt Ýþlemi Baþarýyla gerçekleþti...");
                }
            }
        }

        public static void SaveIEntity(object Data)
        {
            string TableName = "";
            if (Data is IEntity)
            {
                TableName = (Data as IEntity).TableName;
            }
            switch (TableName)
            {
                case "AV001_TDI_BIL_IS":
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save((AV001_TDI_BIL_IS)Data);
                    break;

                case "AV001_TDI_BIL_CARI":
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Save((AV001_TDI_BIL_CARI)Data);
                    break;

                default:

                    break;
            }
        }

        public static void SaveTList(IBindingList Data)
        {
            string TableName = "";
            if (Data.Count > 0 && Data[0] is IEntity)
            {
                TableName = (Data[0] as IEntity).TableName;
            }
            else if (Data.Count > 0)
            {
                SaveFromView(Data);
            }
            else
            {
                return;
            }

            switch (TableName)
            {
                case "AV001_TDI_BIL_IS":
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save((TList<AV001_TDI_BIL_IS>)Data);
                    break;

                case "AV001_TDI_BIL_CARI":
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Save((TList<AV001_TDI_BIL_CARI>)Data);
                    break;

                default:

                    break;
            }
        }

        //
    }
}