using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi
{
    public partial class ucUcakGemiArac : AvpXUserControl
    {
        public bool KayitEkranindanMi;

        public ucUcakGemiArac()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucUcakGemiArac_Load;
        }

        #region Properties
        //aykut
        public AV001_TD_BIL_FOY MyDavaFoy = new AV001_TD_BIL_FOY();

        private TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> _MyDataSource;

        private List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> _PerMyDataSource;

        private AracTipi aracTipi;

        [Category("UcakGemiArac")]
        public event IndexChangedEventHandler FocusedUcakGemiAracChanged;

        [Browsable(true), Category("yyExpress")]
        public AracTipi AracTipi { get; set; }

        public bool HacizKayitEkranimi { get; set; }

        [Browsable(true), Category("yyExpress")]
        public GemiUcakAracTipi KontrolTipi { get; set; }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> PerMyDataSource
        {
            get { return _PerMyDataSource; }
            set
            {
                _PerMyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        //[DefaultValue(false)]
        //public bool AracTipiReadOnly
        //{
        //    get
        //    {
        //        if (rowARAC_TIP == null) return false;
        //        return rowARAC_TIP.Properties.ReadOnly;
        //    }
        //    set
        //    {
        //        if (IsLoaded)
        //            rowARAC_TIP.Properties.ReadOnly = value;
        //    }
        //}

        #endregion Properties

        #region Events

        private void AracBilgileri_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_GEMI_UCAK_ARAC addNew = e.NewObject as AV001_TDI_BIL_GEMI_UCAK_ARAC;
            if (addNew == null)
                addNew = new AV001_TDI_BIL_GEMI_UCAK_ARAC();

            addNew.GEMI_UCAK_ARAC_TIP = (byte)KontrolTipi;
            addNew.KAYIT_TARIHI = DateTime.Now;
            addNew.KLASOR_KODU = "GENEL";
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Now;
            addNew.KONTROL_VERSIYON = 1;
            if (KontrolTipi == GemiUcakAracTipi.Gemi) addNew.TIPI = (int)AracTipi.GEMI;
            else if (KontrolTipi == GemiUcakAracTipi.Ucak) addNew.TIPI = (int)AracTipi.UCAK;
            else addNew.TIPI = (int)GemiUcakAracTipi.Arac;

            ucKiymetTakdiri1.MyDataSource = addNew.AV001_TI_BIL_KIYMET_TAKDIRICollection;
            ucTakyidat.MyDataSource = addNew.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
            e.NewObject = addNew;
            //aykut
            if (MyDavaFoy != null)
                MyDavaFoy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection.Add(addNew);
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgUGA.Visible)
            {
                vgUGA.Visible = false;
                gcUGA.Visible = true;
            }
            else
            {
                vgUGA.Visible = true;
                gcUGA.Visible = false;
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender, AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
            frmEkleUcakGemiArac frm = new frmEkleUcakGemiArac();

            //frm.alreadyaddedList = PerMyDataSource;
            frm.alreadyaddedList = BelgeUtil.Inits.context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs.ToList();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

            //DialogResult dr = frm.Show(this.KontrolTipi);
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show(this.KontrolTipi);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as frmEkleUcakGemiArac).selectedList != null)
            {
                foreach (AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC gua in (sender as frmEkleUcakGemiArac).selectedList)
                {
                    if (MyDataSource.Find(vi => vi.ID == gua.ID) == null)
                    {
                        MyDataSource.Add(AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(gua.ID));

                        //aykut
                        if (MyDavaFoy != null)
                            MyDavaFoy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection.Add(AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetByID(gua.ID));
                    }
                }
            }
        }

        private void ucUcakGemiArac_Load(object sender, EventArgs e)
        {
            if (this.DesignMode && AvukatProLib.Kimlik.DesignMode) return;

            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            initMe();
            compGridRowCopy1.MyGridControl = gcUGA;
            compVGridRecordCopy1.MyVGridControl = vgUGA; //vgUGA.DataSource = initGUADataTableGetir();
            BindData();
            aracTipi = AracTipi.DIGER;
            if (MyDataSource != null && MyDataSource.Count > 0)
                aracTipi = (AracTipi)this.MyDataSource[0].TIPI;

            if (!KayitEkranindanMi)
                KontrolYapilandir(aracTipi);
            else
                KontroluYapilandir(KontrolTipi);
            ucKiymetTakdiri1.EkspertizKaydiMi = true;
            ucKiymetTakdiri1.HacizKayitEkraniMi = HacizKayitEkranimi;
        }

        private void vgUGA_FocusedRecordChanged(object sender, DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex >= 0 && MyDataSource != null && MyDataSource.Count > 0)
            {
                ucKiymetTakdiri1.MyDataSource = MyDataSource[e.NewIndex].AV001_TI_BIL_KIYMET_TAKDIRICollection;
                ucTakyidat.MyDataSource = MyDataSource[e.NewIndex].AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;
                aracTipi = (AracTipi)MyDataSource[e.NewIndex].TIPI;
                KontrolYapilandir(aracTipi);
            }
            if (FocusedUcakGemiAracChanged != null)
            {
                FocusedUcakGemiAracChanged(sender, e);
            }
        }

        #endregion Events

        #region Methods

        public void BindData()
        {
            if (vgUGA == null)
                InitializeComponent();

            vgUGA.DataSource = MyDataSource;
            if (MyDataSource != null)
            {
                MyDataSource.AddingNew += AracBilgileri_AddingNew;

                //if (MyDataSource != null && MyDataSource.Count > 0)
                //    ucKiymetTakdiri1.MyDataSource = MyDataSource[vgUGA.FocusedRecord].AV001_TI_BIL_KIYMET_TAKDIRICollection;
            }

            KontroluYapilandir(KontrolTipi);
        }

        private void GetirGoturBulYokEt(GemiUcakAracTipi tip)
        {
            //Enum elemanın ilk harfini alıyoruz
            string kd = tip.ToString()[0].ToString();
            foreach (DevExpress.XtraGrid.Columns.GridColumn c in gridView1.Columns)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                if (tag.Contains("+") && tag.Length == 1)
                {
                    c.Visible = true;
                }
                else if (tag.Contains("+") && !tag.Contains(kd.ToLower()))
                {
                    c.Visible = true;
                }
                else if (tag.Contains(kd))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
        }

        private void GetirGoturBulYokEt(string kd)
        {
            foreach (DevExpress.XtraVerticalGrid.Rows.BaseRow c in vgUGA.Rows)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                if (tag.Contains("+") && tag.Length == 1)
                {
                    c.Visible = true;
                }
                else if (tag.Contains("+") && !tag.Contains(kd.ToLower()))
                {
                    c.Visible = true;
                }
                else if (tag.Contains(kd))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }

                foreach (BaseRow rw in c.ChildRows)
                {
                    string tg = rw.Tag == null ? "" : rw.Tag.ToString();
                    if (tg.Contains("+") && tg.Length == 1)
                    {
                        rw.Visible = true;
                    }
                    else if (tg.Contains("+") && !tg.Contains(kd.ToLower()))
                    {
                        rw.Visible = true;
                    }
                    else if (tg.Contains(kd))
                    {
                        //if (!nispiMi && tag.Contains("[N]"))
                        //    c.Visible = false;
                        //else
                        rw.Visible = true;
                    }
                    else
                    {
                        rw.Visible = false;
                    }
                }
            }
        }

        private void GetirGoturBulYokEt(AracTipi tip)
        {
            //Enum elemanın ilk harfini alıyoruz
            string kd = tip.ToString()[0].ToString();
            foreach (DevExpress.XtraGrid.Columns.GridColumn c in gridView1.Columns)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                if (tag.Contains("+") && tag.Length == 1)
                {
                    c.Visible = true;
                }
                else if (tag.Contains("+") && !tag.Contains(kd.ToLower()))
                {
                    c.Visible = true;
                }
                else if (tag.Contains(kd))
                {
                    //if (!nispiMi && tag.Contains("[N]"))
                    //    c.Visible = false;
                    //else
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
        }

        private void HepsiniGoster()
        {
            foreach (BaseRow row in vgUGA.Rows)
            {
                if (row is CategoryRow)
                {
                    row.Visible = true;
                }
            }
        }

        private void initMe()
        {
            //AdimAdimDavaKaydi.Util.Inits.GUATipGetirByGUATipId(rlkTipi,(int)this.kontrolTipi);
            BelgeUtil.Inits.AracTipGetir(rlkTipi);
            BelgeUtil.Inits.AracTipGetir(rlkGemiUcakAracTip);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueAracSahibiCari, null);
            AvukatPro.Services.Implementations.DevExpressService.AracTipiDoldur(rlueAracTip);
        }

        private void KontroluYapilandir(GemiUcakAracTipi s)
        {
            #region

            GetirGoturBulYokEt(s.ToString()[0].ToString());
            GetirGoturBulYokEt(s);
            if (s == GemiUcakAracTipi.Ucak)
            {
                crowGemiUcakBilgileri.Properties.Caption = "Uçak Bilgileri";
            }
            else if (s == GemiUcakAracTipi.Gemi)
            {
                crowGemiUcakBilgileri.Properties.Caption = "Gemi Bilgileri";
            }

            #endregion Methods
        }

        private void KontrolYapilandir(AracTipi s)
        {
            switch (s)
            {
                case AracTipi.UCAK:
                    HepsiniGoster();
                    foreach (BaseRow row in vgUGA.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            crowGemiUcakBilgileri.Properties.Caption = "Uçak Bilgileri";
                            GetirGoturBulYokEt(s.ToString()[0].ToString());
                            GetirGoturBulYokEt(s);
                        }
                    }
                    break;

                case AracTipi.GEMI:
                    HepsiniGoster();
                    foreach (BaseRow row in vgUGA.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            crowGemiUcakBilgileri.Properties.Caption = "Gemi Bilgileri";
                            GetirGoturBulYokEt(s.ToString()[0].ToString());
                            GetirGoturBulYokEt(s);
                        }
                    }

                    break;

                case AracTipi.DIGER:
                case AracTipi.ARAC:
                case AracTipi.KAMYON:
                case AracTipi.KAMYONET:
                case AracTipi.MIDIBUS:
                case AracTipi.MINIBUS:
                case AracTipi.OTOBUS:
                    HepsiniGoster();
                    foreach (BaseRow row in vgUGA.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            crowGemiUcakBilgileri.Properties.Caption = "Araç Bilgileri";
                            GetirGoturBulYokEt("A");
                            GetirGoturBulYokEt(AracTipi.ARAC);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void vgUGA_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.RecordIndex < 0)
                return;

            if (e.Row == rowAracTipi)
            {
                if ((int)e.Value == 3)
                    rowTIPI.Visible = true;
                else
                    rowTIPI.Visible = false;
            }
        }
    }
}