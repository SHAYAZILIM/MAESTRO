using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Entegrasyon.Classes
{
    public class DosyaBilgileri
    {
        public List<AlacaginTemliki> AlacaginTemlikleri { get; set; }

        public List<AltinRehni> AltinRehinleri { get; set; }

        public List<AracRehin> AracRehinleri { get; set; }

        public string Banka { get; set; }

        public string Birimi { get; set; }

        public List<Bono> Bonolar { get; set; }

        public List<CariBilgileri> Cariler { get; set; }

        public List<Cek> Cekler { get; set; }

        public List<DigerRehin> DigerRehinler { get; set; }

        public string DosyaYeri { get; set; }

        public List<EmtiaRehni> EmtiaRehinleri { get; set; }

        public List<FirmaGaranti> FirmaGarantileri { get; set; }

        public string FoyNo { get; set; }

        public List<GayriNakitAlacak> GayriNakitAlacaklar { get; set; }

        public List<GemiRehin> GemiRehinleri { get; set; }

        public List<HatRehni> HatRehinleri { get; set; }

        public List<HisseSenediTeminati> HisseSenediTeminatlari { get; set; }

        public List<IhracatIthalatVesaiki> IhracatVesaikileri { get; set; }

        public List<Ipotek> Ipotekler { get; set; }

        public bool IsSelected { get; set; }

        public List<IhracatIthalatVesaiki> IthalatVesaikileri { get; set; }

        public string IzleyenAvukat { get; set; }

        public string KrediGrubu { get; set; }

        public string KrediTipi { get; set; }

        public List<MakbuzSenediRehni> MakbuzSenediRehinleri { get; set; }

        public List<MenkulRehni> MenkulRehinleri { get; set; }

        public List<Bono> MunzamSenetler { get; set; }

        public string Musteri { get; set; }

        public string MusteriNo { get; set; }

        public List<NakitAlacak> NakitAlacaklar { get; set; }

        public List<Rehin> Rehinler { get; set; }

        public string SorumluAvukat { get; set; }

        public List<Sozlesmeler> Sozlesmeler { get; set; }

        public string Sube { get; set; }

        public List<TicariIsletmeRehni> TicariIsletmeRehinleri { get; set; }

        public List<UcakRehin> UcakRehinleri { get; set; }

        public List<VarantRehni> VarantRehinleri { get; set; }
    }
}