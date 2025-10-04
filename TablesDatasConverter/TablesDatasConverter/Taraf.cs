using AvukatProLib2.Entities;

namespace TablesDatasConverter
{
    public class Taraf
    {
        private string _Ad;
        private AV001_TDI_BIL_CARI _CARI;

        private int _CariId;

        private TDI_KOD_IS_TARAF _IS_TARAF;

        private bool _IsSorumlu;

        private int _id;

        private byte _Kodu;

        private string _MainTable;

        private TDIE_KOD_TARAF_SIFAT _SIFAT;

        private string _Sifat;

        private int _SifatId;

        private TDI_KOD_SOZLESME_TARAF_SIFAT _SozlesmeSifat;

        private string _sozlesmeSifati;

        private bool _sozlesmeTarafimi;

        private string _Table;

        private IEntity _TARAF;

        public string Ad
        {
            get { return _Ad; }
            set { _Ad = value; }
        }

        public AV001_TDI_BIL_CARI CARI
        {
            get { return _CARI; }
            set { _CARI = value; }
        }

        public int CariId
        {
            get { return _CariId; }
            set { _CariId = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public TDI_KOD_IS_TARAF IS_TARAF
        {
            get { return _IS_TARAF; }
            set { _IS_TARAF = value; }
        }

        public bool IsSorumlu
        {
            get { return _IsSorumlu; }
            set { _IsSorumlu = value; }
        }

        public byte Kodu
        {
            get { return _Kodu; }
            set { _Kodu = value; }
        }

        public string MainTable
        {
            get { return _MainTable; }
            set { _MainTable = value; }
        }

        public TDIE_KOD_TARAF_SIFAT SIFAT
        {
            get { return _SIFAT; }
            set { _SIFAT = value; }
        }

        public string Sifat
        {
            get { return _Sifat; }
            set { _Sifat = value; }
        }

        public int SifatId
        {
            get { return _SifatId; }
            set { _SifatId = value; }
        }

        public TDI_KOD_SOZLESME_TARAF_SIFAT SozlesmeSifat
        {
            get { return _SozlesmeSifat; }
            set { _SozlesmeSifat = value; }
        }

        public string SozlesmeSifati
        {
            get { return _sozlesmeSifati; }
            set { _sozlesmeSifati = value; }
        }

        public bool SozlesmeTarafimi
        {
            get { return _sozlesmeTarafimi; }
            set { _sozlesmeTarafimi = value; }
        }

        public string Table
        {
            get { return _Table; }
            set { _Table = value; }
        }

        public IEntity TARAF
        {
            get { return _TARAF; }
            set { _TARAF = value; }
        }
    }
}