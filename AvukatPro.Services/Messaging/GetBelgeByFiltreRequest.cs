namespace AvukatPro.Services.Messaging
{
    public class GetBelgeByFiltreRequest
    {
        public string BarkodNo { get; set; }

        public string BelgeAdi { get; set; }

        public string BelgeNo { get; set; }

        public int? DosyaID { get; set; }

        public int? DurumID { get; set; }

        public int? KullaniciSubeID { get; set; }

        public AvukatProLib.Extras.Modul? Modul { get; set; }

        public string RefNo { get; set; }

        public int? TurID { get; set; }
    }
}