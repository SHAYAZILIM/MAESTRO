using AvukatProLib2.Entities;
using BelgeUtil;

namespace AvukatProLib.Util.Is
{
    public class IsTarafi
    {
        private int _cari;

        private bool _dagitici;

        private bool _muhatap;

        private bool _planlayan;

        private bool _sahibi;

        private bool _sorumlu;

        private bool _yetkili;

        public int Cari
        {
            get { return _cari; }
            set { _cari = value; }
        }

        public bool Dagitici
        {
            get { return _dagitici; }
            set { _dagitici = value; }
        }

        public bool Muhatap
        {
            get { return _muhatap; }
            set { _muhatap = value; }
        }

        public bool Planlayan
        {
            get { return _planlayan; }
            set { _planlayan = value; }
        }

        public bool Sahibi
        {
            get { return _sahibi; }
            set { _sahibi = value; }
        }

        public bool Sorumlu
        {
            get { return _sorumlu; }
            set { _sorumlu = value; }
        }

        public bool Yetkili
        {
            get { return _yetkili; }
            set { _yetkili = value; }
        }

        public override string ToString()
        {
            string araLaf = "";
            if (this.Muhatap == true) araLaf += " muhatap ";
            if (this.Sorumlu == true) araLaf += " sorumlu ";
            if (this.Sahibi == true) araLaf += " sahibi ";
            if (this.Planlayan == true) araLaf += " planlayan ";
            if (this.Dagitici == true) araLaf += " daðýtýcý ";
            if (this.Yetkili == true) araLaf += " yetkilisi ";
            CacheData data = CacheHelper.GetCachedDataByKeyValue("VDI_BIL_CARI");
            VList<VDI_BIL_CARI> cariler = null;
            string cariAdi = "";
            if (data != null)
            {
                cariler = (VList<VDI_BIL_CARI>)data.Data;
                for (int i = 0; i < cariler.Count; i++)
                {
                    if (cariler[i].ID == this.Cari)
                    {
                        cariAdi = cariler[i].AD;
                    }
                }
            }
            return cariAdi + " adlý carinin " + araLaf + " olduðu ";
        }
    }
}