using System;
using System.Collections.Generic;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.PivotOfisAcma;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using AvukatPro.Model.EntityClasses;
using System.IO;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Data;
using AdimAdimDavaKaydi.UserControls.Util;

namespace AdimAdimDavaKaydi.UserControls.ucRapor
{
    public partial class ucPivotChart : DevExpress.XtraEditors.XtraUserControl
    {
        public ucPivotChart()
        {
            InitializeComponent();
            ucChartDesignerControlPanel1.MyChartControl = chartControl1;

            Load += ucPivotChart_Load;
        }

        private void ucPivotChart_Load(object sender, EventArgs e)
        {
            #region Chart DataSource

            ChartDataSource();

            #endregion
        }

        //aykut hýzlandýrma 25.01.2013
        //[Browsable(false)]
        //public List<RMasrafAvansDetayli2Entity> MyMasrafAvansDetayliSonuc
        //{
        //    get
        //    {
        //        if (pivotGridControl1.DataSource == null) return null;
        //        else if (
        //            pivotGridControl1.DataSource.GetType().FullName.Contains(
        //                typeof(RMasrafAvansDetayli2Entity).FullName))
        //        {
        //            return pivotGridControl1.DataSource as List<RMasrafAvansDetayli2Entity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        pivotGridControl1.DataSource = null;
        //        MuhasebePivot.MasrafAvansMuhasebe mdP =
        //            new MuhasebePivot.MasrafAvansMuhasebe();
        //        pivotGridControl1.Tag = "R_MASRAF_AVANS_DETAYLI2";
        //        pivotGridControl1.Fields.Clear();
        //        pivotGridControl1.Fields.AddRange(mdP.GetFields());
        //        ChartDataSource();
        //        pivotGridControl1.DataSource = value;
        //    }
        //}

        [Browsable(false)]
        public DataTable MyMasrafAvansDetayliSonuc
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.MasrafAvansMuhasebe mdP =
                    new MuhasebePivot.MasrafAvansMuhasebe();
                pivotGridControl1.Tag = "R_MASRAF_AVANS_DETAYLI2";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(mdP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }
        //aykut hýzlandýrma 25.01.2013
        //[Browsable(false)]
        //public List<RCariHesapDetayliEntity> MyCarHesapDetayliArama
        //{
        //    get
        //    {
        //        if (pivotGridControl1.DataSource is List<RCariHesapDetayliEntity>)
        //        {
        //            return pivotGridControl1.DataSource as List<RCariHesapDetayliEntity>;
        //        }

        //        return null;
        //    }
        //    set
        //    {
        //        pivotGridControl1.DataSource = null;

        //        pivotGridControl1.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
        //        MuhasebePivot.CariHesapMuhasebe mdP =
        //            new MuhasebePivot.CariHesapMuhasebe();
        //        pivotGridControl1.Fields.Clear();
        //        pivotGridControl1.Fields.AddRange(mdP.GetFields());
        //        ChartDataSource();
        //        pivotGridControl1.DataSource = value;
        //    }
        //}

        [Browsable(false)]
        public DataTable MyCarHesapDetayliArama
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;

                pivotGridControl1.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
                MuhasebePivot.CariHesapMuhasebe mdP =
                    new MuhasebePivot.CariHesapMuhasebe();
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(mdP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        //aykut hýzlandýrma 28.01.2013
        //[Browsable(false)]
        //public List<Av001TdiBilKasaEntity> MyKasaView
        //{
        //    get
        //    {
        //        if (pivotGridControl1.DataSource == null) return null;
        //        else if (
        //            pivotGridControl1.DataSource.GetType().FullName.Contains(
        //                typeof(Av001TdiBilKasaEntity).FullName))
        //        {
        //            return pivotGridControl1.DataSource as List<Av001TdiBilKasaEntity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        pivotGridControl1.DataSource = null;
        //        Muhasebe.Kasa ks = new Muhasebe.Kasa();
        //        pivotGridControl1.Tag = "AV001_TDI_BIL_KASA";
        //        MuhasebePivot.KasaHesapMuhasebe mdP =
        //            new MuhasebePivot.KasaHesapMuhasebe();
        //        pivotGridControl1.Fields.Clear();
        //        pivotGridControl1.Fields.AddRange(mdP.GetFields());
        //        pivotGridControl1.DataSource = value;
        //    }
        //}

        [Browsable(false)]
        public DataTable MyKasaView
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Kasa ks = new Util.Muhasebe.Kasa();
                pivotGridControl1.Tag = "AV001_TDI_BIL_KASA";
                MuhasebePivot.KasaHesapMuhasebe mdP =
                    new MuhasebePivot.KasaHesapMuhasebe();
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(mdP.GetFields());
                pivotGridControl1.DataSource = value;
            }
        }

        [Browsable(false)]
        public DataTable MyDavaFoy
        {
            get
            {
                //if (pivotGridControl1.DataSource == null) return null;
                //else if (
                //    pivotGridControl1.DataSource.GetType().FullName.Contains(
                //        typeof(AvukatProLib.Arama.AV001_TD_BIL_FOY).FullName))
                //{
                //    return pivotGridControl1.DataSource as List<AvukatProLib.Arama.AV001_TD_BIL_FOY>;
                //}
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.DavaFoy dfP =
                    new MuhasebePivot.DavaFoy();
                pivotGridControl1.Tag = "DAVA_FOY";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(dfP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        //aykut hýzlandýrma 29.01.2013 Ýcra
        //[Browsable(false)]
        //public List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> MyIcraFoy
        //{
        //    get
        //    {
        //        if (pivotGridControl1.DataSource == null) return null;
        //        else if (
        //            pivotGridControl1.DataSource.GetType().FullName.Contains(
        //                typeof(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama).FullName))
        //        {
        //            return pivotGridControl1.DataSource as List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        pivotGridControl1.DataSource = null;
        //        MuhasebePivot.IcraFoy ifP =
        //            new MuhasebePivot.IcraFoy();
        //        pivotGridControl1.Tag = "ICRA_FOY";
        //        pivotGridControl1.Fields.Clear();
        //        pivotGridControl1.Fields.AddRange(ifP.GetFields());
        //        ChartDataSource();
        //        pivotGridControl1.DataSource = value;
        //    }
        //}

        [Browsable(false)]
        public DataTable MyIcraFoy
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.IcraFoy ifP =
                    new MuhasebePivot.IcraFoy();
                pivotGridControl1.Tag = "ICRA_FOY";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(ifP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        [Browsable(false)]
        public DataTable MyDurusma
        {
            get
            {
                if (pivotGridControl1.DataSource == null) return null;
                else if (
                    pivotGridControl1.DataSource.GetType().FullName.Contains(
                        typeof(AV001_TD_BIL_CELSE).FullName))
                {
                    return pivotGridControl1.DataSource as DataTable;
                }
                return null;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.Durusma dP =
                    new MuhasebePivot.Durusma();
                pivotGridControl1.Tag = "DURUSMA";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(dP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        [Browsable(false)]
        public DataTable MyOdemeExpress
        {
            get
            {
                if (pivotGridControl1.DataSource == null) return null;
                else if (
                    pivotGridControl1.DataSource.GetType().FullName.Contains(
                        typeof(RExpressBorcluOdemeProjeEntity).FullName))
                {
                    return pivotGridControl1.DataSource as DataTable;
                }
                return null;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.OdemeExpress oe =
                    new MuhasebePivot.OdemeExpress();
                pivotGridControl1.Tag = "RExpressBorcluOdemeProjeEntity";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(oe.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        public void ChartDataSource()
        {
            chartControl1.DataSource = pivotGridControl1;
            chartControl1.SeriesDataMember = "Series";
            chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new[] { "Values" });
        }

        public object MyDataSource
        {
            get { return pivotGridControl1.DataSource; }
            set { pivotGridControl1.DataSource = value; }
        }


        [Browsable(false)]
        public DataTable MySorusturma
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.R_SORUSTURMA_PIVOT ifP =
                    new MuhasebePivot.R_SORUSTURMA_PIVOT();
                pivotGridControl1.Tag = "R_SORUSTURMA_PIVOT";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(ifP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

        [Browsable(false)]
        public DataTable MyProje
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.Proje ifP = new MuhasebePivot.Proje();
                pivotGridControl1.Tag = "Proje";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(ifP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }

            [Browsable(false)]
            public DataTable MyTicariRiskRaporu
        {
            get
            {
                return pivotGridControl1.DataSource as DataTable;
            }
            set
            {
                pivotGridControl1.DataSource = null;
                MuhasebePivot.TicariRiskRaporu ifP = new MuhasebePivot.TicariRiskRaporu();
                pivotGridControl1.Tag = "TicariRiskRaporu";
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.Fields.AddRange(ifP.GetFields());
                ChartDataSource();
                pivotGridControl1.DataSource = value;
            }
        }


            [Browsable(false)]
            public DataTable MyTicariRiskRaporuDosya
            {
                get
                {
                    return pivotGridControl1.DataSource as DataTable;
                }
                set
                {
                    pivotGridControl1.DataSource = null;
                    MuhasebePivot.TicariRiskRaporuDosya ifP = new MuhasebePivot.TicariRiskRaporuDosya();
                    pivotGridControl1.Tag = "AV001_TDIE_BIL_DOSYA_RISK_RAPORU";
                    pivotGridControl1.Fields.Clear();
                    pivotGridControl1.Fields.AddRange(ifP.GetFields());
                    ChartDataSource();
                    pivotGridControl1.DataSource = value;
                }
            }

        private KayitTipiOfis SecilenKayitTipi;

        private void btnListeSecti_Click(object sender, EventArgs e)
        {
            if (SecilenKayitTipi != null)
                SaveFileTools.Exporter(pivotGridControl1, SecilenKayitTipi);

            popupContainerControl1.Hide();
        }

        private void btnGrafikSecti_Click(object sender, EventArgs e)
        {
            if (SecilenKayitTipi != null)
                SaveFileTools.Exporter(chartControl1, SecilenKayitTipi);

            popupContainerControl1.Hide();
        }

        private void btnPopupKapat_Click(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SecilenKayitTipi = KayitTipiOfis.Excel;
            popupContainerControl1.Show();
            popupContainerControl1.SuspendLayout();
        }

        private void btnGorunumuKaydet_Click(object sender, EventArgs e)
        {
            //pivotGridControl1
        }

        private void spinSonucSayisi_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(spinSonucSayisi.Value)<((System.Data.DataTable)(((DevExpress.XtraPivotGrid.PivotGridControl)(chartControl1.DataSource)).DataSource)).Rows.Count)
            //{
            //    decimal[] mylist = new decimal[((System.Data.DataTable)(((DevExpress.XtraPivotGrid.PivotGridControl)(chartControl1.DataSource)).DataSource)).Rows.Count];
            //    DataSet DS = ((AdimAdimDavaKaydi.Util.ExtendedPivotControl)(chartControl1.DataSource)).DataSource as DataSet;
            //    //string s=    ((DevExpress.XtraPivotGrid.PivotChartDataSourceRowItem)((new System.Linq.SystemCore_EnumerableDebugView(((AdimAdimDavaKaydi.Util.ExtendedPivotControl)(chartControl1.DataSource)))).Items[1])).Value.ToString();
            //        for (int i = 0; i < ((System.Data.DataTable)(((DevExpress.XtraPivotGrid.PivotGridControl)(chartControl1.DataSource)).DataSource)).Rows.Count; i++)
            //        {
            //            decimal s = Convert.ToDecimal(((System.Data.DataTable)(((DevExpress.XtraPivotGrid.PivotGridControl)(chartControl1.DataSource)).DataSource)).Rows[i][38].ToString());
            //            mylist[i] = s;
            //            //sorting yapcaz büyükten küçüðe
            //            Array.Sort(mylist);
            //        }                  
            //}
        }
    }
}