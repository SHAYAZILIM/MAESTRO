using System.Collections.Generic;
using System.Linq;
using AvukatProRaporlar.Util;
using RaporDataSource.ViewDB;

namespace AvukatProRaporlar.RaporSource
{
    public class PvDDeneme
    {
        private ParaVeDovizId p1;

        private ParaVeDovizId p2;

        private ParaVeDovizId p3;

        private ParaVeDovizId p4;

        private ParaVeDovizId p5;

        public PvDDeneme()
        {
        }

        public ParaVeDovizId P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public ParaVeDovizId P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public ParaVeDovizId P3
        {
            get { return p3; }
            set { p3 = value; }
        }

        public ParaVeDovizId P4
        {
            get { return p4; }
            set { p4 = value; }
        }

        public ParaVeDovizId P5
        {
            get { return p5; }
            set { p5 = value; }
        }

        public static List<PvDDeneme> GetList()
        {
            AvukatProViewDataContext dbV = Program.dbV;

            var liste = dbV.R_RAPOR_PROJE_ICRAs.Select(vi => new PvDDeneme
            {
                P1 = new ParaVeDovizId(vi.ASIL_ALACAK, vi.ASIL_ALACAK_DOVIZ_ID),
                P2 = new ParaVeDovizId(vi.INDIRIM_ANAPARA, vi.INDIRIM_ANAPARA_DOVIZ_ID),
                P3 = new ParaVeDovizId(vi.INDIRIM_BANKA_BAKIYESI, vi.INDIRIM_BANKA_BAKIYESI_DOVIZ_ID),
                P4 = new ParaVeDovizId(vi.INDIRIM_KALAN, vi.INDIRIM_KALAN_DOVIZ_ID),
                P5 = new ParaVeDovizId(vi.INDIRIM_MASRAF, vi.INDIRIM_MASRAF_DOVIZ_ID)
            }).ToList();

            return liste;
        }
    }
}