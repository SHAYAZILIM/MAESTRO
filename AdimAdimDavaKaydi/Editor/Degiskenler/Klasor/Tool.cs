using AdimAdimDavaKaydi.Editor.Degiskenler.Util;
using AvukatProLib2.Entities;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Klasor
{
    public static  class Tool
    {
        public static void IhtiyatiHacizDilekcesi(AV001_TI_BIL_IHTIYATI_HACIZ iHaciz, AV001_TDIE_BIL_SABLON_RAPOR rapor,
                                                          AV001_TDIE_BIL_PROJE proje, TextControl txControl)
        {
            if (proje == null)
                return;
            EditorAraclari arac = new EditorAraclari();
            EditorDokuman dokuman = new EditorDokuman(proje);

            //dokuman.Sablon = rapor;
            dokuman.Dokuman = rapor.DOSYA;

            var fieldListesi = arac.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

            foreach (var field in fieldListesi)
            {
                switch (field.Text)
                {
                    case "[PROJE] IHTIYATI_HACIZ_TARAFLARI ALACAKLI":
                        Editor.Degiskenler.Klasor.Degiskenler.GetIhtiyatiHacizTaraflari(iHaciz, txControl, field, false);
                        break;

                    case "[PROJE] IHTIYATI_HACIZ_TARAFLARI BORCLU":
                        Editor.Degiskenler.Klasor.Degiskenler.GetIhtiyatiHacizTaraflari(iHaciz, txControl, field, true);
                        break;

                    case "[PROJE] SORUMLU AVUKAT AD ADRES":
                        Editor.Degiskenler.Klasor.Degiskenler.GetProjeSorumlulariAdAdres(proje, txControl, field);
                        break;

                    case "[PROJE] IHTIYATI HACIZ MAHKEME GOREV":
                        Editor.Degiskenler.Klasor.Degiskenler.GetIhtiyatiHacizMahkemeGorev(iHaciz, txControl, field);
                        break;

                    case "[PROJE] IHTIYATI HACIZ TALEP TARIHI":
                        Editor.Degiskenler.Klasor.Degiskenler.GetIhtiyatiHacizTalepTarihi(iHaciz, txControl, field);
                        break;

                    case "[PROJE] SORUMLU AVUKAT AD":
                        Editor.Degiskenler.Klasor.Degiskenler.GetProjeSorumluAvukatAdi(proje, txControl, field);
                        break;

                    case "[PROJE] ALACAK NEDEN BILGILERI KISITLI":
                        Editor.Degiskenler.Klasor.Degiskenler.GetAlacakNedenleriKisitli(proje, txControl, field);
                        break;

                    case "[PROJE] ALACAK KALEMLERI TOPLAM TUTAR":
                        Editor.Degiskenler.Klasor.Degiskenler.GetAlacakToplamlari(proje, txControl, field);
                        break;

                    default:
                        break;
                }
            }

            txControl.Select(txControl.Text.Length, 0);
        }

        public static void KlasorRapor(AV001_TDIE_BIL_SABLON_RAPOR rapor, AV001_TDIE_BIL_PROJE proje,
                                               TextControl txControl)
        {
            if (proje == null)
                return;
            EditorAraclari arac = new EditorAraclari();
            EditorDokuman dokuman = new EditorDokuman(proje);

            //dokuman.Sablon = rapor;
            dokuman.Dokuman = rapor.DOSYA;

            var fieldListesi = arac.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

            foreach (var field in fieldListesi)
            {
                switch (field.Text)
                {
                    #region Klasör Rapor Değişkenleri

                    case "[PROJE] GENEL KLASOR BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetGenelKlasorBilgileri(proje, txControl,
                                                                                                        field);
                        break;

                    case "[PROJE] BORCLU BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetBorcluBilgileri(proje, txControl,
                                                                                                   field);

                        //field.Text = AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetBorcluBilgileri(proje);
                        break;

                    case "[PROJE] SORUMLU BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetSorumluBilgileri(proje, txControl,
                                                                                                    field);
                        break;

                    case "[PROJE] HESAP DATAYLARI1":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetHesapDetaylari1(proje, txControl,
                                                                                                   field);
                        break;

                    case "[PROJE] HESAP DATAYLARI2":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetHesapDetaylari2(proje, txControl,
                                                                                                   field);
                        break;

                    case "[PROJE] HESAP DATAYLARI3":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetHesapDetaylari3(proje, txControl,
                                                                                                   field);
                        break;

                    case "[PROJE] ICRA BILGILERI":
                        string st = AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetIcraBilgileri(txControl,
                                                                                                             field,
                                                                                                             proje);
                        break;

                    case "[PROJE] DAVA BILGILERI":
                        string stt = AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetDavaBilgileri(proje,
                                                                                                              txControl,
                                                                                                              field);
                        break;

                    case "[PROJE] TEMINAT BILGILERI": //view bozuk düzelince açacağız
                        string sttt = AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetTeminatBilgileri(
                            proje, false, txControl, field);
                        break;

                    case "[PROJE] MUNZAM SENET BILGILERI":
                        string sttt1 = AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetTeminatBilgileri(
                            proje, true, txControl, field);
                        break;

                    case "[PROJE] BORCLU MAL BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetMalTakipSureci(proje, true, txControl,
                                                                                                  field);
                        break;

                    case "[PROJE] BORCLU MAL BILGILERI (REHIN)":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetMalTakipSureci(proje, false, txControl,
                                                                                                  field);
                        break;

                    case "[PROJE] SORUSTURMA BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetSorusturmaBilgileri(proje, txControl,
                                                                                                       field);
                        break;

                    case "[PROJE] TAAHHUT BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetTaahhutBilgileri(proje, txControl,
                                                                                                    field);
                        break;

                    case "[PROJE] ALACAK NEDEN BILGILERI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetAlacakNedenleri(proje, txControl,
                                                                                                   field);
                        break;

                    case "[PROJE] ACIKLAMALARI":
                        AdimAdimDavaKaydi.Editor.Degiskenler.Klasor.Degiskenler.GetProjeAciklamalari(proje, txControl,
                                                                                                     field);
                        break;

                    case "[PROJE] TARAF GELISME BILGILERI":
                        Editor.Degiskenler.Klasor.Degiskenler.GetTarafGelismeleri(proje, txControl, field);
                        break;

                    case "[PROJE] TAKIPSIZ TEMINATLAR"://Takibi açılmamış, direkt klasöre bağlı teminatların raporda görünmesini sağlıyor. MB
                        Editor.Degiskenler.Klasor.Degiskenler.GetTakipsizMalTakipSureci(proje, txControl, field);
                        break;

                    case "[PROJE] IADE ALINMAMIS TEMINATLAR":
                        Editor.Degiskenler.Klasor.Degiskenler.GetIadeAlinmamisTeminatlar(proje, txControl, field);
                        break;

                    #endregion Klasör Rapor Değişkenleri

                    default:
                        break;
                }
            }

            txControl.Select(txControl.Text.Length, 0);
        }

        /// <summary>
        /// filePath olarak verilen word dökümanını field ın bulunduğu noktaya improt eder
        /// </summary>
        /// <param name="txControl"></param>
        /// <param name="field"></param>
        /// <param name="filePath"></param>
        public static void WordImport(TextControl txControl, TextField field, string filePath)
        {
            field.Text = " ";

            txControl.Select(field.Start, 0);

            try
            {
                txControl.Selection.Load(filePath, StreamType.MSWord);
            }
            catch
            {
                try
                {
                    txControl.Selection.Load(filePath, StreamType.WordprocessingML);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Microsoft Office Referanslarınızla ilgili Sorun Yaşanıyor");
                }
            }
        }
    }
}