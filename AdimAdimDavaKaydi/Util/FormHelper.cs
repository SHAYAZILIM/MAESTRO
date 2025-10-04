using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.GirisEkran;

namespace AdimAdimDavaKaydi.Util
{
    public static class FormHelperII
    {
        private const byte _MaximumAcilabilirFormSayisi = 2;
        private static Dictionary<AramaFormlari, Form> _AcikFormlar = new Dictionary<AramaFormlari, Form>();

        public static Dictionary<AramaFormlari, Form> AcikFormlar
        {
            get { return _AcikFormlar; }
            set { _AcikFormlar = value; }
        }

        public static bool FormAc(AramaFormlari form, bool showDialog)
        {
            if (AcikFormlar.ContainsKey(form))
            {
                AcikFormlar[form].Focus();
            }
            else
            {
                if (AcikFormlar.Count > _MaximumAcilabilirFormSayisi)
                {
                    return false;
                }
                else
                {
                    Form frm = null;
                    switch (form)
                    {
                        case AramaFormlari.ICRA_GIRIS:
                            frm = new rFrmIcraGirisEkran();
                            break;
                        case AramaFormlari.DAVA_GIRIS:
                            frm = new rFrmDavaGirisEkran();
                            break;
                        case AramaFormlari.SOZLESME_GIRIS:
                            frm = new rFrmSozlesmeGirisEkran();
                            break;
                        case AramaFormlari.SORUSTURMA_GIRIS:
                            frm = new rFrmSorusturmaGirisEkran();
                            break;
                        case AramaFormlari.EDITOR_GIRIS:
                            frm = new frmEditor();
                            break;
                        case AramaFormlari.BELGE_GIRIS:
                            frm = new rFrmBelgeAramaEkran();
                            break;
                        case AramaFormlari.GELEN_GIDEN_EVRAK:
                            frm = new rFrmTebligatGirisEkran();
                            break;
                        case AramaFormlari.HUKUK_MUHASEBESI:
                            frm = new rFrmMuhasebeGirisEkran();
                            break;
                        case AramaFormlari.PROJE_YONETIMI:
                            frm = new rFrmKlasorAramaEkran();
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            //frm.MdiParent = null;
                            break;
                        case AramaFormlari.BURO_YONETIMI:
                            break;
                        case AramaFormlari.GOREV_GIRIS:
                            frm = new rFrmYapilcakIsAramaEkran();
                            break;
                        case AramaFormlari.TEMSIL_GIRIS:
                            frm = new rFrmTemsilBilgileriGirisEkran();
                            break;
                        case AramaFormlari.CARI_BUL:
                            frm = new rFrmCariAramaForm();
                            break;
                        case AramaFormlari.GORUSME_GIRIS:
                            frm = new rFrmGorusmeGirisEkran();
                            break;
                        default:
                            MessageBox.Show(form + " Henüz bu fonksiyon yazýlmadý", "Uyarý", MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            break;
                    }
                    if (frm != null)
                    {
                        if (showDialog)
                        {
                            // frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                        }
                        else
                        {
                            frm.Show();
                        }
                    }
                    AcikFormlar.Add(form, frm);
                    frm.FormClosed += frm_FormClosed;
                    return true;
                }
            }

            return false;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form)
            {
                if (AcikFormlar.ContainsValue((Form)sender))
                {
                    AramaFormlari bulunan = AramaFormlari.NULL;
                    foreach (KeyValuePair<AramaFormlari, Form> kvp in AcikFormlar)
                    {
                        if (kvp.Value == sender)
                        {
                            bulunan = kvp.Key;
                        }
                    }
                    ((Form)sender).FormClosed -= frm_FormClosed;
                    AcikFormlar.Remove(bulunan);
                }
            }
        }
    }

    public enum AramaFormlari
    {
        NULL,
        ICRA_GIRIS,
        DAVA_GIRIS,
        SOZLESME_GIRIS,
        SORUSTURMA_GIRIS,
        EDITOR_GIRIS,
        BELGE_GIRIS,
        GELEN_GIDEN_EVRAK,
        HUKUK_MUHASEBESI,
        PROJE_YONETIMI,
        /// <summary>
        /// Þuanda bununla ilgili bir form yoktur lütfen kullanmayýnýz
        /// </summary>
        ICTIHAT_MEVZUAT_YONETIMI,
        TUM_DOSYALAR,
        BURO_YONETIMI,
        GOREV_GIRIS,
        GORUSME_GIRIS,
        TEMSIL_GIRIS,
        CARI_BUL
    }
}