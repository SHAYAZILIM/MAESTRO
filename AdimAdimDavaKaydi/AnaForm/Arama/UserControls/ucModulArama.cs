using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace AdimAdimDavaKaydi.Arama.UserControls
{
    public enum AranacakKayitTipi
    {
        Is,
        Belge,
    }

    public class AramaProperties
    {
        public string Aciklama { get; set; }

        [Browsable(false)]
        public int? AdliBirimGorev { get; set; }

        [Browsable(false)]
        public int? Adlibirimno { get; set; }

        [Browsable(false)]
        public int? Adliye { get; set; }

        [Browsable(false)]
        public DateTime? AvukataIntikalTarihi { get; set; }

        [Browsable(false)]
        public int? Cari { get; set; }

        [Browsable(false)]
        public string EsasNo { get; set; }

        [Browsable(false)]
        public int? Formtipi { get; set; }

        [Browsable(false)]
        public string FoyNo { get; set; }

        [Browsable(false)]
        public DateTime? Kayittarihi { get; set; }

        public int? Konu { get; set; }

        [Browsable(false)]
        public AdimAdimDavaKaydi.Arama.UserControls.ucModulArama.Kriter Kriter { get; set; }

        [Browsable(false)]
        public decimal? Miktar { get; set; }

        [Browsable(false)]
        public int? TakipKonusu { get; set; }

        [Browsable(false)]
        public DateTime? TakipSikayetTarihi { get; set; }

        public string Taraf { get; set; }

        public string Yer { get; set; }
    }

    public partial class ucModulArama : DevExpress.XtraEditors.XtraUserControl //,IModuler//,IModulerParent
    {
        public ucModulArama()
        {
            InitializeComponent();
        }

        private AramaProperties aramaList = new AramaProperties();

        public enum Kriter
        {
            Büyük,
            Eþit,
            Küçük,
            Büyük_veya_Eþit,
            Küçük_veya_Eþit
        }

        [Browsable(false)]
        public AramaProperties Aramalist
        {
            get { return aramaList; }
            set
            {
                if (value != null && !DesignMode)
                {
                    aramaList = value;
                    bndModul.DataSource = Aramalist;
                }
            }
        }

        public object Ara()
        {
            aramaList.Adliye = (int?)lueAdliye.EditValue;
            aramaList.AdliBirimGorev = (int?)lueGorev.EditValue;
            aramaList.Adlibirimno = (int?)lueNo.EditValue;
            aramaList.EsasNo = txtEsasNo.Text;
            aramaList.Formtipi = (int?)lueFormTipi.EditValue;
            aramaList.FoyNo = txtFoyNo.Text;
            aramaList.TakipSikayetTarihi = (DateTime?)dteTakipTarihi.EditValue;
            aramaList.Kayittarihi = (DateTime?)dteKayitTarihi.EditValue;
            aramaList.Konu = (int?)lueTakipKonusu.EditValue;

            ////aykut hýzlandýrma 29.01.2013 Ýcra
            //List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraReturnValues = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
            DataTable IcraReturnValues = new DataTable();

            DataTable DavaReturnValues = new DataTable();
            List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW> SorusturmaReturnValues = new List<AvukatProLib.Arama.per_AV001_TD_BIL_HAZIRLIK_NEW>();

            switch (Modul)
            {
                case AvukatProLib.Extras.ModulTip.Sorusturma:
                    return SorusturmaReturnValues;

                case AvukatProLib.Extras.ModulTip.Dava:
                    //DavaReturnValues = AdimAdimDavaKaydi.Util.ModulArama.DavaFiltrele(aramaList);
                    DavaReturnValues = AvukatProLib.Arama.R_DAVA_GENEL_ARAMASorgu.GetByFiltreView(null,
                                                                                         null, null, null,
                                                                                         null, null, null,
                                                                                         null, null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null, null, aramaList.FoyNo,
                                                                                         null, null, null, null, aramaList.TakipSikayetTarihi, aramaList.Adliye,
                                                                                         aramaList.Adlibirimno, aramaList.AdliBirimGorev, aramaList.EsasNo, null,
                                                                                         null, null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         0, null, null, null);
                    return DavaReturnValues;

                case AvukatProLib.Extras.ModulTip.Icra:
                    IcraReturnValues = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null,
                                                                                         null, null, null,
                                                                                         null, null, null,
                                                                                         null, null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null, null, aramaList.FoyNo,
                                                                                         null, null, null, null, aramaList.Adliye,
                                                                                         aramaList.Adlibirimno, aramaList.EsasNo, null,
                                                                                         null, null, null,
                                                                                         null, aramaList.TakipSikayetTarihi,
                                                                                         null, null,
                                                                                         null, null,
                                                                                         null, null, aramaList.Kayittarihi, aramaList.Formtipi, aramaList.Konu,
                                                                                         AvukatProLib.Kimlik.
                                                                                             SirketBilgisi.ConStr, 2, "Tumu", -1, -1, "");
                    return IcraReturnValues;

                case AvukatProLib.Extras.ModulTip.Sozlesme:
                    break;

                case AvukatProLib.Extras.ModulTip.Tebligat:
                    break;

                case AvukatProLib.Extras.ModulTip.YapilacakIsler:
                    break;

                case AvukatProLib.Extras.ModulTip.CariArama:
                    break;

                case AvukatProLib.Extras.ModulTip.Gorusme:
                    break;

                default:
                    break;
            }
            return null;
        }

        private void ucModulArama_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            lueAdliye.Properties.NullText = "Seç";
            lueNo.Properties.NullText = "Seç";
            lueGorev.Properties.NullText = "Seç";
            lueFormTipi.Properties.NullText = "Seç";
            lueTakipKonusu.Properties.NullText = "Seç";
            lueAdliye.Enter += BelgeUtil.Inits.AdliBirimAdliyeGetir_Enter;
            lueNo.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;
            lueGorev.Enter += BelgeUtil.Inits.AdliBirimGorevGetir_Enter;
            lueFormTipi.Enter += delegate { BelgeUtil.Inits.FormTipiGetir(lueFormTipi); };
            lueTakipKonusu.Enter += BelgeUtil.Inits.TakipKonusuGetir_Enter;
        }

        #region IModuler Members

        private AvukatProLib.Extras.ModulTip _modul;

        public AranacakKayitTipi KayitTipi { get; set; }

        [Browsable(false)]
        public AvukatProLib.Extras.ModulTip Modul
        {
            get { return _modul; }
            set
            {
                _modul = value;
                this.ModuleGoreDegerVer(value);
            }
        }

        public void ModuleGoreDegerVer(AvukatProLib.Extras.ModulTip modul)
        {
            //for (int i = 0; i < this.Childs.Count; i++)
            //{
            //    this.Childs[i].Modul = this.Modul;
            //}
        }

        #endregion IModuler Members

        #region IModulerParent Members

        //List<IModuler> _Childs = null;
        //public List<IModuler> Childs
        //{
        //    get
        //    {
        //        return _Childs;
        //    }
        //    set
        //    {
        //        _Childs = value;

        //    }
        //}

        //public void AddChild(IModuler child)
        //{
        //    this._Childs.Add(child);
        //}

        #endregion IModulerParent Members
    }
}