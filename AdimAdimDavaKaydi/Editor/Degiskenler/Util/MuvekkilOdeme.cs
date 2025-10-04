using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Linq;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    public static class MuvekkilOdeme
    {
        public static void OdemeMakbuzuGetir(AV001_TI_BIL_MUVEKKILE_ODEME odeme)
        {
            //Sablon ID = 1230
            if (odeme.ICRA_FOY_IDSource == null)
                DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.DeepLoad(odeme, false, DeepLoadType.IncludeChildren,
                                                                             typeof(AV001_TI_BIL_FOY),
                                                                             typeof(TDI_KOD_ODEME_TIP));

            frmEditor editor = new frmEditor();
            editor.MdiParent = mdiAvukatPro.MainForm;
            editor.Show();
            Print(editor.CurrentEditor.textControl1, DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1230),
                  odeme);
        }

        private static void Print(TextControl txControl, AV001_TDIE_BIL_SABLON_RAPOR rapor,
                                  AV001_TI_BIL_MUVEKKILE_ODEME odeme)
        {
            EditorAraclari arac = new EditorAraclari();
            EditorDokuman dokuman = new EditorDokuman(odeme);

            //dokuman.Sablon = rapor;
            dokuman.Dokuman = rapor.DOSYA;

            var fieldlar = arac.GetFieldListByEditorDokumanAndTextControl(dokuman, txControl);

            foreach (var item in fieldlar)
            {
                switch (item.Text)
                {
                    case "[MUVEKKIL-ODEME] ODEYEN ADI":
                        item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(odeme.ODENEN_CARI_ID);
                        break;

                    case "[MUVEKKIL-ODEME] MUVEKKIL ADI":
                        item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(odeme.ODEYEN_CARI_ID);
                        break;

                    case "[MUVEKKIL-ODEME] ODEME MIKTARI":
                        item.Text = (new ParaVeDovizId(odeme.MIKTAR, odeme.MIKTAR_DOVIZ_ID)).GetStringValue();
                        break;

                    case "[MUVEKKIL-ODEME] ODEME TARIHI":
                        item.Text = EditorDataAraclari.Tools.TarihBicimlendirme(odeme.ODEME_TARIHI);
                        break;

                    case "[MUVEKKIL-ODEME] ESAS NO":
                        if (odeme.ICRA_FOY_IDSource != null)
                            item.Text = odeme.ICRA_FOY_IDSource.ESAS_NO;
                        break;

                    case "[MUVEKKIL-ODEME] DOSYA NO":
                        if (odeme.ICRA_FOY_IDSource != null)
                            item.Text = odeme.ICRA_FOY_IDSource.FOY_NO;
                        break;

                    case "[MUVEKKIL-ODEME] ODEME TIPI":
                        if (odeme.ODEME_TIP_IDSource != null)
                            item.Text = odeme.ODEME_TIP_IDSource.ODEME_TIP;
                        break;

                    case "[MUVEKKIL-ODEME] MUDURLUK":
                        if (odeme.ICRA_FOY_IDSource != null)
                        {
                            string result = string.Format("{0} {1} {2}",
                                                          EditorDataAraclari.Icra.GetAdliyeAdi(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_ADLIYE_ID),
                                                          EditorDataAraclari.Icra.GetAdliBirimNo(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_NO_ID),
                                                          EditorDataAraclari.Icra.GetAdliBirimGorev(
                                                              odeme.ICRA_FOY_IDSource.ADLI_BIRIM_GOREV_ID));

                            item.Text = result;
                        }
                        break;

                    case "[ODEME] SORUMLU AVUKAT":
                        if (odeme.ICRA_FOY_IDSource != null)
                        {
                            if (odeme.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(odeme.ICRA_FOY_IDSource, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                            var sorumlu =
                                odeme.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(
                                    vi => !vi.YETKILI_MI).First();
                            if (sorumlu != null)
                                item.Text = HesapAraclari.Icra.CariAdiGetirByCariId(sorumlu.SORUMLU_AVUKAT_CARI_ID);
                        }
                        break;

                    default:
                        break;
                }
            }

            txControl.Select(txControl.Text.Length, 0);
        }
    }
}