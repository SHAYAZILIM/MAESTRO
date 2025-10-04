using AvukatProLib.Extras;

namespace AvukatPro.Services.Messaging
{
    public class GetDosyaTaraflariRequest
    {
        public int FoyId { get; set; }

        public int ModulId { get; set; }

        public TarafKodu TarafKodu { get; set; }
    }
}