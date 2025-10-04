using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.Uyap
{
    public class UyapGeriBildirim
    {
        private List<per_AV001_TI_BIL_ICRA_Arama> _icraDosyalari;
        private string _xmlDosyaYolu;
        public bool geriBildirimYapilsin;
        private UyapGenerator _cagiranUyap;

        public UyapGenerator CagiranUyap
        {
            get { return _cagiranUyap; }
            set { _cagiranUyap = value; }
        }

        public string XmlDosyaYolu
        {
            get { return _xmlDosyaYolu; }
            set { _xmlDosyaYolu = value; }
        }
        public List<per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari
        {
            get { return _icraDosyalari; }
            set { _icraDosyalari = value; }
        }

        public UyapGeriBildirim()
        {

        }
        public UyapGeriBildirim(List<per_AV001_TI_BIL_ICRA_Arama> _icraDosyalari, UyapGenerator _cagiranUyap)
        {
            this._icraDosyalari = _icraDosyalari;
            
            this._cagiranUyap = _cagiranUyap;

        }
       

    }
}
