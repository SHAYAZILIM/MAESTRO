using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace AVPLisans
{
    /// <summary>
    /// Summary description for LisansControl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class LisansControl : System.Web.Services.WebService
    {
        public DbLisansDataContext ctx = new DbLisansDataContext();

        [WebMethod]
        public LisansBilgisi CheckProductKey(string productKey)
        {
            TMYS_URUN_ANAHTARI anahtar = ctx.TMYS_URUN_ANAHTARIs.Single(vi => vi.URUN_ANAHTARI == productKey);

            if (anahtar != null)
            {
                TMYS_MUSTERI musteri = anahtar.TMYS_MUSTERI;
                LisansBilgisi lisans = new LisansBilgisi();
                lisans.AdSoyad = musteri.AD_SOYAD;
                lisans.DavaKayitSayisi = musteri.DAVA_KAYIT_SAYISI;
                lisans.DavaKullaniciSayisi = musteri.DAVA_KULLANICI;
                lisans.IcraKayitSayisi = musteri.ICRA_KAYIT_SAYISI;
                lisans.IcraKullaniciSayisi = musteri.ICRA_KULLANICI;
                lisans.LisansBitisTarihi = musteri.LISANS_BITIS_TARIHI;
                lisans.PaketAdi = anahtar.CS_KOD_PAKET.PAKET_ADI;
                lisans.ProductKey = anahtar.URUN_ANAHTARI;
                lisans.SorusturmaKayitSayisi = musteri.SORUSTURMA_KAYIT_SAYISI;
                lisans.SorusturmaKullaniciSayisi = musteri.SORUSTURMA_KULLANICI;
                lisans.PaketElemanlari = new List<PaketElemanlari>();

                foreach (var item in anahtar.CS_KOD_PAKET.CS_KOD_PAKET_NN_FORMs)
                {
                    PaketElemanlari pkt = new PaketElemanlari();
                    pkt.Aciklama = item.CS_KOD_FORM_LISTESI.FORM_ACIKLAMA;
                    pkt.FormAdi = item.CS_KOD_FORM_LISTESI.FULL_ADI;
                    pkt.Visible = true;
                    lisans.PaketElemanlari.Add(pkt);
                }
                List<CS_KOD_FORM_LISTESI> formListe = ctx.CS_KOD_FORM_LISTESIs.ToList();

                foreach (var item in formListe)
                {
                    if (!lisans.PaketElemanlari.Exists(delegate(PaketElemanlari p)
                    {
                        return p.FormAdi == item.FULL_ADI;
                    }))
                    {
                        PaketElemanlari pkt = new PaketElemanlari();
                        pkt.Aciklama = item.FORM_ACIKLAMA;
                        pkt.FormAdi = item.FULL_ADI;
                        pkt.Visible = false;
                        lisans.PaketElemanlari.Add(pkt);
                    }
                }

                return lisans;
            }
            else
            {
                return null;
            }
        }
    }
}