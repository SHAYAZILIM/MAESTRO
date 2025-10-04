namespace AvukatPro.Services.Messaging
{
    public class CreateFoyMuhasebeDetayByMasrafAvansDetayRequest
    {
        public int MasrafAvansDetayId { get; set; }

        public int MuhasebeId { get; set; }

        public bool YenidenHesaplanabilir { get; set; }
    }
}