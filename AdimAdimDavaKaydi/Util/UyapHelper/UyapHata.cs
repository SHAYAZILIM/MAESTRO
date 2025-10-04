using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdimAdimDavaKaydi.AnaForm;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.Uyap
{
    public class UyapHata
    {
        public TList<AV001_TDI_BIL_SOZLESME> HataliSozlesme;
        public AV001_TI_BIL_FOY HataliFoyEski;
        public AV001_TI_BIL_ALACAK_NEDEN HataliAlacakNedeni;
        public AV001_TI_BIL_FOY_TARAF HataliTaraf;
        public AV001_TI_BIL_ALACAK_NEDEN_TARAF HataliAlacakNedenTarafi;
        public AV001_TDI_BIL_KIYMETLI_EVRAK HataliKiymetliEvrak;
        public AV001_TI_BIL_ILAM_MAHKEMESI HataliIlamMahkemesi;
        public TList<AV001_TDI_BIL_CARI> HataliCari;
        public per_AV001_TI_BIL_ICRA_Arama HataliFoy;
        public string HataBilgisi;
        public string HataNedeni;
        public AvukatProLib.Extras.FormType AcilacakFormTipi;

        public UyapHata()
        {

        }

        public UyapHata(string HataliFoyId, string HataNedeni, AvukatProLib.Extras.FormType AcilacakFormTipi)
        {
            this.HataliFoy = new per_AV001_TI_BIL_ICRA_Arama();
            this.HataliFoy.ID = Convert.ToInt32(HataliFoyId);
            this.HataNedeni = HataNedeni;
            this.AcilacakFormTipi = AcilacakFormTipi;

        }
    }
}
