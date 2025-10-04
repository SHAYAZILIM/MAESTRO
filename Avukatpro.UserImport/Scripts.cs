using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avukatpro.UserImport
{
    public class Scripts
    {
        public static string IlSelect = @"
SELECT [ID]
  FROM [TDI_KOD_IL]
WHERE [IL] = @IL
";

        public static string IlceSelect = @"
SELECT [ID]
  FROM [TDI_KOD_ILCE]
WHERE [ILCE] = @ILCE
";

        public static string SubeSelect = @"
SELECT [ID]
  FROM [TDIE_BIL_KULLANICI_SUBELERI]
WHERE [SUBE_ADI] = @SUBE_ADI
";

        public static string SubeInsert = @"
INSERT INTO [TDIE_BIL_KULLANICI_SUBELERI]
           (
           [SUBE_ADI]
           ,[KAYIT_TARIHI]
           )
     VALUES
           (@SUBE_ADI,GETDATE());SELECT SCOPE_IDENTITY();
";
        public static string KullaniciSelect = @"
SELECT [ID]
  FROM [TDI_BIL_KULLANICI_LISTESI]
WHERE [KULLANICI_ADI] = @KULLANICI_ADI
";
        public static string KullaniciInsert = @"
INSERT INTO [TDI_BIL_KULLANICI_LISTESI]
           ([KULLANICI_ADI]
           ,[KULLANICI_SIFRESI]
           ,[KULLANICI_GRUP_ID]
           ,[PROGRAM_MODUL]
           ,[KULLANICI_YETKI_SEVIYESI]
           ,[KULLANICI_AKTIF]
           ,[SUBE_ID]          
           ,[KULLANICI_SUBE_ID]
           ,[CARI_ID]
          )
     VALUES
           (@KULLANICI_ADI
           ,@KULLANICI_SIFRESI
           ,3
           ,127
           ,999
           ,1
           ,@SUBE_ID
           ,@KULLANICI_SUBE_ID
           ,@CARI_ID
           )
";
        public static string CariSelect = @"
SELECT [ID]
  FROM [AV001_TDI_BIL_CARI]
WHERE [AD] = @AD
";
        public static string CariInsert = @"
INSERT INTO [AV001_TDI_BIL_CARI]
           (
           [AD]          
           ,[ILCE_ID]
           ,[IL_ID]           
           ,[TEL_1]
           ,[CEP_TEL]
           ,[EMAIL_1]
           ,[MESLEK_ID]          
           ,[MUVEKKIL_MI]
           ,[KARSI_TARAF_MI]
           ,[FIRMA_MI]
           ,[PERSONEL_MI]
           ,[AVUKAT_MI]
           ,[BILIRKISI_MI]
           ,[AVUKAT_ORTAKLIGI_MI]
           ,[ADLI_BIRIM_MI]
           ,[ADLI_PERSONEL_MI]           
           ,[SUBE_KOD_ID]
          )
     VALUES
           (
           @AD
           ,@ILCE_ID
           ,@IL_ID
           ,@TEL_1
           ,@CEP_TEL
           ,@EMAIL_1
           ,3
           ,0
           ,0
           ,0
           ,1
           ,1
           ,0
           ,0
           ,0
           ,0         
           ,@SUBE_KOD_ID
          );SELECT SCOPE_IDENTITY();
";
    }
}
