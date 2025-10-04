namespace AdimAdimDavaKaydi.Entegrasyon
{
    public static class Enums
    {
        public enum DosyaAtamaKabulDurumlari
        {
            Kabul,
            Red,
            IslemBekliyor
        }

        public enum DosyaBilesenleri
        {
            KrediTaraf,
            NakitAlacak,
            GayrinakitAlacak,
            Cek,
            Bono,
            MunzamSenet,
            Sozlesme,
            Ipotek,
            Rehin
        }

        public enum Durumlar
        {
            BagliDegil = 0,
            KlasoreBagli = 1,
            MusteriBilgisiYok = 2,//XML'de ilgili node doldurulmamis.
            MusteriSistemdeYok = 3,//Gönderilen müşteri, veritabanında kayıtlı bir cari değil.
            AyniMusteridenVar = 4
        }

        public enum FormTipleri
        {
            Form49_7 = 1,
            Form153_11 = 12,
            Form52_12 = 11,
            Form163_10 = 3,
            Form151_6 = 7,
            Form152_9 = 8,
            Form54_2 = 6,
            Form201_44 = 13,
            Form49_7_Kambiyo,
            FormKarisik
        }

        public enum Islemler
        {
            YeniKlasorAta = 0,
            YeniBagimsizTakipAta = 1,
            MevcutKlasoruKullan = 2
        }

        public enum MasrafinGonderildigiDosya
        {
            Klasor,
            Icra,
            Dava,
            Sorusturma
        }
    }
}