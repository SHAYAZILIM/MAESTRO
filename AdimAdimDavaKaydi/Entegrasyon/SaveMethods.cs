using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class SaveMethods
    {
        public static void DeepSaveMethod(object savedObject)
        {
            if (savedObject == null) return;

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                if (savedObject is TList<AV001_TI_BIL_ALACAK_NEDEN>)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, savedObject as TList<AV001_TI_BIL_ALACAK_NEDEN>, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>), typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY>));
                    foreach (var alacak in savedObject as TList<AV001_TI_BIL_ALACAK_NEDEN>)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, alacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>));
                    }
                }
                else if (savedObject is TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)
                {
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, savedObject as TList<AV001_TDI_BIL_KIYMETLI_EVRAK>, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                }
                else if (savedObject is AV001_TDI_BIL_KIYMETLI_EVRAK)
                {
                    //Update
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.Save(tran, savedObject as AV001_TDI_BIL_KIYMETLI_EVRAK);
                }
                else if (savedObject is TList<AV001_TI_BIL_GAYRIMENKUL>)
                {
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(tran, savedObject as TList<AV001_TI_BIL_GAYRIMENKUL>, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<NN_ICRA_GAYRIMENKUL>));
                }
                else if (savedObject is TList<AV001_TDI_BIL_SOZLESME>)
                {
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(tran, savedObject as TList<AV001_TDI_BIL_SOZLESME>, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>), typeof(TList<NN_SOZLESME_GAYRIMENKUL>), typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));
                }
                else if (savedObject is AV001_TDI_BIL_SOZLESME)
                {
                    //Update
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(tran, savedObject as AV001_TDI_BIL_SOZLESME);
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                System.Windows.Forms.MessageBox.Show(ex.Message, "HATA", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }
        }
    }
}