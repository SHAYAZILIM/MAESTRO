using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatPro.Model.EntityClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using AvukatProLib;
using System.Drawing;
using System.Data;
using DevExpress.XtraGrid.Columns;
using AdimAdimDavaKaydi.UserControls.ucRapor;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.IcraTakipForms;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucMuhasebeGenel : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucPivotChart ucPivotChart1 = new ucPivotChart();

        public int? KasaHesapId { get; set; }
        public int? MuhatapHesapId { get; set; }
        public int? KiymetliEvrakId { get; set; }
        public List<int> BelgeIds { get; set; }
        public int BelgeIndex { get; set; }
        public AV001_TD_BIL_FOY MyDavaFoy { get; set; }
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy { get; set; }
        public TList<AV001_TDI_BIL_MASRAF_AVANS> MyMasrafDataSource { get; set; }
        public AV001_TDI_BIL_SOZLESME MySozlesmeFoy { get; set; }
        public AV001_TI_BIL_FOY MyIcraFoy { get; set; }
        public bool personel;

        #region Properties

        private DataTable myCariHesapDetayliArama;
        public object CurrentMasraf { get; set; }
        public bool SaveStatus { get; set; }
        public string ModuleName { get; set; }
        public string ColumnsMode { get; set; }
        public object MyDataSource { get; set; }

        //[Browsable(false)]
        //public VList<AvukatProLib2.Entities.R_MUHASEBE_KAPSAMLI> MyMuhasebeDetay
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null)
        //            return null;
        //        if (
        //            gcGenel.DataSource.GetType().FullName.Contains(
        //                typeof(AvukatProLib2.Entities.R_MUHASEBE_KAPSAMLI).FullName))
        //        {
        //            return gcGenel.DataSource as VList<AvukatProLib2.Entities.R_MUHASEBE_KAPSAMLI>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        if (value != null)
        //            if (SaveControler())
        //            {
        //                if (gcGenel == null) return;

        //                mainView.Columns.Clear();

        //                Muhasebe.MuhasebeDetayli md = new Muhasebe.MuhasebeDetayli();

        //                mainView.Columns.AddRange(md.GetMuhasebeDetayli());

        //                #region Paket Kontrolü

        //                AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion

        //                gcGenel.DataSource = value;
        //            }
        //    }
        //}

        //[Browsable(false)]
        //public TList<AvukatProLib2.Entities.AV001_TDI_BIL_KASA> MyKasa
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null) return null;
        //        else if (
        //            gcGenel.DataSource.GetType().FullName.Contains(
        //                typeof(AvukatProLib2.Entities.AV001_TDI_BIL_KASA).FullName))
        //        {
        //            return gcGenel.DataSource as TList<AvukatProLib2.Entities.AV001_TDI_BIL_KASA>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        if (value != null)
        //            if (SaveControler())
        //            {
        //                if (gcGenel == null) return;

        //                mainView.Columns.Clear();

        //                Muhasebe.Kasa ks = new Muhasebe.Kasa();

        //                mainView.Columns.AddRange(ks.GetKasa());

        //                #region Paket Kontrolü

        //                AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion

        //                gcGenel.DataSource = value;
        //            }
        //    }
        //}

        //aykut hýzlandýrma 28.01.2013       
        //[Browsable(false)]
        //public List<Av001TdiBilKasaEntity> MyKasaView
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null)
        //            return null;
        //        else if (
        //            gcGenel.DataSource.GetType().FullName.Contains(
        //                typeof(Av001TdiBilKasaEntity).FullName))
        //        {
        //            return gcGenel.DataSource as List<Av001TdiBilKasaEntity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        //if (value != null)
        //        if (SaveControler())
        //        {
        //            compGridDovizSummary1.YasakliAlanlar.Remove("BirimFiyatDovizId");
        //            if (gcGenel == null) return;
        //            if (value != null)
        //            {
        //                mainView.Columns.Clear();
        //                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Kasa ks = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Kasa();
        //                gcGenel.Tag = "AV001_TDI_BIL_KASA";
        //                mainView.Columns.AddRange(ks.GetKasaColumns());

        //                #region SET COLUMNS VISIBILITY (ARCH)

        //                SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //                #endregion

        //                #region Paket Kontrolü

        //                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion
        //            }
        //            gcGenel.DataSource = value;
        //            //aykut hýzlandýrma 28.01.2013 pivot aç kapat
        //            tabPPivot.PageVisible = false;
        //            mainView.ClearGrouping();
        //        }
        //    }
        //}

        [Browsable(false)]
        public DataTable MyKasaView
        {
            get
            {
                return gcGenel.DataSource as DataTable;
            }
            set
            {
                //if (value != null)
                if (SaveControler())
                {
                    compGridDovizSummary1.YasakliAlanlar.Remove("BirimFiyatDovizId");
                    if (gcGenel == null) return;
                    if (value != null)
                    {
                        mainView.Columns.Clear();
                        AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Kasa ks = new Util.Muhasebe.Kasa();
                        gcGenel.Tag = "AV001_TDI_BIL_KASA";
                        mainView.Columns.AddRange(ks.GetKasaColumns());

                        #region SET COLUMNS VISIBILITY (ARCH)

                        SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

                        #endregion

                        #region Paket Kontrolü

                        //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                        #endregion
                    }
                    gcGenel.DataSource = value;
                    //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                    tabPPivot.PageVisible = false;
                    mainView.PreviewFieldName = "Aciklama";
                    try
                    {
                        mainView.Columns["BirimFiyatDovizId"].SummaryItem.DisplayFormat = "";
                        mainView.Columns["BirimFiyatDovizId"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                    }
                    catch { ;}

                    mainView.ClearGrouping();

                    mainView.GroupSummary.Clear();
                    foreach (GridColumn item in mainView.Columns)
                    {
                        try
                        {
                            if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                        }
                        catch { ;}
                    }
                }
            }
        }

        //[Browsable(false)]
        //public List<RMasrafAvansDetayli2Entity> MyMasrafAvansDetayli
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null) return null;
        //        else if (gcGenel.DataSource.GetType().FullName.Contains(typeof(RMasrafAvansDetayli2Entity).FullName))
        //        {
        //            return gcGenel.DataSource as List<RMasrafAvansDetayli2Entity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        if (SaveControler())
        //        {
        //            if (gcGenel == null) return;
        //            if (value != null)
        //            {
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
        //                mainView.Columns.Clear();

        //                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MasrafAvans md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MasrafAvans();
        //                gcGenel.Tag = "R_MASRAF_AVANS_DETAYLI2";
        //                tabPPivot.PageVisible = true;
        //                mainView.Columns.AddRange(md.GetMasrafAvansDetayliColumns());

        //                #region SET COLUMNS VISIBILITY (ARCH)
        //                SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //                #endregion

        //                #region Paket Kontrolü

        //                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion
        //            }
        //            gcGenel.DataSource = value;
        //            mainView.ClearGrouping();
        //        }
        //    }           
        //}
        //aykut hýzlandýrma 25.01.2013 yukarý yerine aþaðýsý eklendi

        [Browsable(false)]
        public DataTable MyMasrafAvansDetayli
        {
            get
            {
                return gcGenel.DataSource as DataTable;
            }
            set
            {
                if (SaveControler())
                {
                    if (gcGenel == null) return;
                    if (value != null)
                    {
                        if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
                            compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                        if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
                            compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                        mainView.Columns.Clear();

                        AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MasrafAvans md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MasrafAvans();
                        gcGenel.Tag = "R_MASRAF_AVANS_DETAYLI2";
                        //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                        tabPPivot.PageVisible = false;

                        mainView.Columns.AddRange(md.GetMasrafAvansDetayliColumns());
                        mainView.PreviewFieldName = "DetayAciklama";
                        #region SET COLUMNS VISIBILITY (ARCH)
                        SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

                        #endregion

                        #region Paket Kontrolü

                        //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                        #endregion
                    }
                    gcGenel.DataSource = value;
                    mainView.ClearGrouping();
                    mainView.GroupSummary.Clear();
                    foreach (GridColumn item in mainView.Columns)
                    {
                        try
                        {
                            if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                        }
                        catch { ;}
                    }
                }
            }
        }

        //aykut hýzlandýrma 29.01.2013
        //[Browsable(false)]
        //public List<RBilFaturaModulEntity> MyFaturaView
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null) return null;
        //        else if (
        //            gcGenel.DataSource.GetType().FullName.Contains(
        //                typeof(RBilFaturaModulEntity).FullName))
        //        {
        //            return gcGenel.DataSource as List<RBilFaturaModulEntity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        //if (value != null)
        //        if (SaveControler())
        //        {
        //            if (gcGenel == null) return;
        //            if (value != null)
        //            {
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("KALAN_DOVIZ_ID"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("KALAN_DOVIZ_ID");
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("BIRIM_FIYAT_DOVIZ_ID"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("BIRIM_FIYAT_DOVIZ_ID");
        //                mainView.Columns.Clear();
        //                tabPPivot.PageVisible = false;
        //                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura();
        //                gcGenel.Tag = "AV001_TDI_BIL_FATURA";
        //                mainView.Columns.AddRange(md.GetFaturaColumns());

        //                #region SET COLUMNS VISIBILITY (ARCH)

        //                SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //                #endregion

        //                #region Paket Kontrolü

        //                AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion
        //            }
        //            gcGenel.DataSource = value;
        //            compGridDovizSummary1.Refresh();
        //        }
        //    }
        //}

        [Browsable(false)]
        public DataTable MyFaturaView
        {
            get
            {
                return gcGenel.DataSource as DataTable;
            }
            set
            {
                //if (value != null)
                if (SaveControler())
                {
                    if (gcGenel == null) return;
                    if (value != null)
                    {
                        if (!compGridDovizSummary1.YasakliAlanlar.Contains("KALAN_DOVIZ_ID"))
                            compGridDovizSummary1.YasakliAlanlar.Add("KALAN_DOVIZ_ID");
                        if (!compGridDovizSummary1.YasakliAlanlar.Contains("BIRIM_FIYAT_DOVIZ_ID"))
                            compGridDovizSummary1.YasakliAlanlar.Add("BIRIM_FIYAT_DOVIZ_ID");
                        mainView.Columns.Clear();
                        tabPPivot.PageVisible = false;
                        AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura();
                        gcGenel.Tag = "AV001_TDI_BIL_FATURA";
                        mainView.Columns.AddRange(md.GetFaturaColumns());

                        #region SET COLUMNS VISIBILITY (ARCH)

                        SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

                        #endregion

                        #region Paket Kontrolü

                        AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                        #endregion
                    }
                    gcGenel.DataSource = value;
                    compGridDovizSummary1.Refresh();

                    mainView.GroupSummary.Clear();
                    foreach (GridColumn item in mainView.Columns)
                    {
                        try
                        {
                            if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                        }
                        catch { ;}
                    }
                }
            }
        }

        //[Browsable(false)]
        //public List<RMasrafAvansDetayli2Entity> MyMasrafAvansDetayliSonuc
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource == null) return null;
        //        else if (gcGenel.DataSource.GetType().FullName.Contains(typeof(RMasrafAvansDetayli2Entity).FullName))
        //        {
        //            return gcGenel.DataSource as List<RMasrafAvansDetayli2Entity>;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        if (SaveControler())
        //        {
        //            if (gcGenel == null) return;
        //            if (value != null)
        //            {
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
        //                if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
        //                    compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
        //                mainView.Columns.Clear();

        //                Muhasebe.MasrafAvans md = new Muhasebe.MasrafAvans();
        //                gcGenel.Tag = "R_MASRAF_AVANS_DETAYLI2";
        //                tabPPivot.PageVisible = true;
        //                mainView.Columns.AddRange(md.GetMasrafAvansDetaylý());

        //                #region SET COLUMNS VISIBILITY (ARCH)
        //                SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //                #endregion

        //                #region Paket Kontrolü

        //                AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //                #endregion
        //            }
        //            if (value != null)
        //            {
        //                foreach (var item in value)
        //                {
        //                    if (item.MasrafAvansTip == 2)
        //                    {
        //                        item.ToplamTutar = -item.ToplamTutar;
        //                        item.GenelToplam = -item.GenelToplam;
        //                        item.BirimFiyat = -item.BirimFiyat;
        //                    }
        //                }
        //            }
        //            gcGenel.DataSource = value;
        //        }
        //    }
        //}

        [Browsable(false)]
        public VList<CARI_HESAP> MyCariHesap
        {
            get
            {
                gcGenel.Tag = "CARI_HESAP";
                if (gcGenel.DataSource == null) return null;

                else if (gcGenel.DataSource.GetType().FullName.Contains(typeof(CARI_HESAP).FullName))
                {
                    return gcGenel.DataSource as VList<CARI_HESAP>;
                }
                return null;
            }
            set
            {
                if (value != null)
                    if (SaveControler())
                    {
                        if (gcGenel == null) return;

                        mainView.Columns.Clear();

                        AdimAdimDavaKaydi.UserControls.Util.Muhasebe.CariHesap md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.CariHesap();
                        gcGenel.Tag = "CARI_HESAP";
                        mainView.Columns.AddRange(md.GetCariHesapColumn());

                        #region Paket Kontrolü

                        //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                        #endregion

                        gcGenel.DataSource = value;

                        mainView.GroupSummary.Clear();
                        foreach (GridColumn item in mainView.Columns)
                        {
                            try
                            {
                                if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                                    mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                            }
                            catch { ;}
                        }
                    }
            }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.R_CARI_HESAP_DETAYLI> MyCariHesapDetayli
        {
            get
            {
                if (gcGenel.DataSource is List<AvukatProLib.Arama.R_CARI_HESAP_DETAYLI>)
                {
                    return gcGenel.DataSource as List<AvukatProLib.Arama.R_CARI_HESAP_DETAYLI>;
                }

                return null;
            }
            set
            {
                if (gcGenel == null) return;

                mainView.Columns.Clear();
                gcGenel.Tag = "R_CARI_HESAP_DETAYLI";
                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap cm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap();
                mainView.Columns.AddRange(cm.GetCariColumns());
                mainView.PreviewFieldName = "Aciklama";

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;

                mainView.GroupSummary.Clear();
                foreach (GridColumn item in mainView.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        //aykut hýzlandýrma 25.01.2013
        //[Browsable(false)]
        //public List<RCariHesapDetayliEntity> MyMuvekkilCariHesapDetayli
        //{
        //    get
        //    {
        //        if ( /*gcGenel.DataSource*/
        //            myCariHesapDetayliArama is List<RCariHesapDetayliEntity>)
        //        {
        //            return myCariHesapDetayliArama;
        //            //return gcGenel.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY>;
        //        }

        //        return null;
        //    }
        //    set
        //    {
        //        myCariHesapDetayliArama = value;
        //        if (gcGenel == null) return;
        //        if (value != null)
        //        {
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
        //            mainView.Columns.Clear();
        //            gcGenel.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
        //            AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilCariHesap cm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilCariHesap();
        //            mainView.Columns.AddRange(cm.GetCariColumns());

        //            #region SET COLUMNS VISIBILITY (ARCH)

        //            SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //            #endregion

        //            value = value.OrderBy(vi => vi.Tarih).ToList();

        //            #region Paket Kontrolü

        //            //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //            #endregion

        //            //KalanHesapla(value);
        //        }
        //        gcGenel.DataSource = value;
        //        tabPPivot.PageVisible = true;
        //    }
        //}

        //[Browsable(false)]
        //public List<RCariHesapDetayliEntity> MyPersonelCariHesapDetayli
        //{
        //    get
        //    {
        //        if ( /*gcGenel.DataSource*/
        //            myCariHesapDetayliArama is List<RCariHesapDetayliEntity>)
        //        {
        //            return myCariHesapDetayliArama;
        //            //return gcGenel.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY>;
        //        }

        //        return null;
        //    }
        //    set
        //    {
        //        myCariHesapDetayliArama = value;
        //        if (gcGenel == null) return;
        //        if (value != null)
        //        {
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
        //            mainView.Columns.Clear();
        //            gcGenel.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
        //            AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap cm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap();
        //            mainView.Columns.AddRange(cm.GetCariColumns());
        //            #region SET COLUMNS VISIBILITY (ARCH)

        //            SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

        //            #endregion

        //            value = value.OrderBy(vi => vi.Tarih).ToList();

        //            #region Paket Kontrolü

        //            //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //            #endregion

        //            //KalanHesapla(value);
        //        }
        //        gcGenel.DataSource = value;
        //        tabPPivot.PageVisible = true;
        //    }
        //}

        //private void KalanHesapla(List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY> value)
        //{
        //    if (value != null)
        //    {
        //        AvukatProLib.Hesap.ParaVeDovizId odenen = new AvukatProLib.Hesap.ParaVeDovizId(0, 1);
        //        AvukatProLib.Hesap.ParaVeDovizId alinan = new AvukatProLib.Hesap.ParaVeDovizId(0, 1);

        //        foreach (var item in value)
        //        {
        //            odenen = AvukatProLib.Hesap.ParaVeDovizId.Topla(odenen,
        //                                                            new AvukatProLib.Hesap.ParaVeDovizId(item.ODENEN,
        //                                                                                                 item.
        //                                                                                                     ODENEN_DOVIZ_ID));
        //            alinan = AvukatProLib.Hesap.ParaVeDovizId.Topla(alinan,
        //                                                            new AvukatProLib.Hesap.ParaVeDovizId(item.ALINAN,
        //                                                                                                 item.
        //                                                                                                     ALINAN_DOVIZ_ID));

        //            var kalan = AvukatProLib.Hesap.ParaVeDovizId.Topla(alinan, odenen);
        //            item.KALAN = kalan.Para;
        //            item.KALAN_DOVIZ_ID = kalan.DovizId;
        //        }
        //    }
        //}

        [Browsable(false)]
        public DataTable MyMuvekkilCariHesapDetayli
        {
            get
            {
                return myCariHesapDetayliArama;
            }
            set
            {
                myCariHesapDetayliArama = value;
                if (gcGenel == null) return;
                if (value != null)
                {
                    if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
                        compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                    if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
                        compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                    mainView.Columns.Clear();
                    gcGenel.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
                    AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilCariHesap cm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilCariHesap();
                    mainView.Columns.AddRange(cm.GetCariColumns());

                    mainView.PreviewFieldName = "Aciklama";

                    #region SET COLUMNS VISIBILITY (ARCH)

                    SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

                    #endregion

                    //value = value.OrderBy(vi => vi.Tarih).ToList();

                    #region Paket Kontrolü

                    //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                    #endregion

                    //KalanHesapla(value);
                }
                gcGenel.DataSource = value;
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;

                mainView.GroupSummary.Clear();
                foreach (GridColumn item in mainView.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        [Browsable(false)]
        public DataTable MyPersonelCariHesapDetayli
        {
            get
            {
                return myCariHesapDetayliArama;
            }
            set
            {
                myCariHesapDetayliArama = value;
                if (gcGenel == null) return;
                if (value != null)
                {
                    if (!compGridDovizSummary1.YasakliAlanlar.Contains("KalanDovizId"))
                        compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                    if (!compGridDovizSummary1.YasakliAlanlar.Contains("BirimFiyatDovizId"))
                        compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                    mainView.Columns.Clear();
                    gcGenel.Tag = "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY";
                    AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap cm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.PersonelCariHesap();
                    mainView.Columns.AddRange(cm.GetCariColumns());
                    mainView.PreviewFieldName = "Aciklama";
                    #region SET COLUMNS VISIBILITY (ARCH)

                    SetColumnsView(mainView.Columns, ColumnsMode, ModuleName);

                    #endregion

                    //value = value.OrderBy(vi => vi.Tarih).ToList();

                    #region Paket Kontrolü

                    //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                    #endregion

                    //KalanHesapla(value);
                }
                gcGenel.DataSource = value;
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;

                mainView.GroupSummary.Clear();
                foreach (GridColumn item in mainView.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        //aykut hýzlandýrma 28.01.2013
        //[Browsable(false)]
        //public List<RFoyMuhasebesiBirlesikDetayliEntity> MyFoyMuhasebeBirlesikDetayli
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource is List<RFoyMuhasebesiBirlesikDetayliEntity>)
        //            return gcGenel.DataSource as List<RFoyMuhasebesiBirlesikDetayliEntity>;

        //        return null;
        //    }
        //    set
        //    {
        //        if (gcGenel == null) return;
        //        compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
        //        compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
        //        mainView.Columns.Clear();
        //        //aykut hýzlandýrma 28.01.2013 pivot aç kapat
        //        tabPPivot.PageVisible = false;

        //        AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
        //        mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

        //        #region Paket Kontrolü

        //        //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //        #endregion

        //        gcGenel.DataSource = value;
        //    }
        //}

        [Browsable(false)]
        public DataTable MyFoyMuhasebeBirlesikDetayli
        {
            get
            {
                return gcGenel.DataSource as DataTable;
            }
            set
            {
                if (gcGenel == null) return;
                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                mainView.Columns.Clear();
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;
                gcGenel.Tag = "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI";

                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
                mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;

                mainView.GroupSummary.Clear();
                foreach (GridColumn item in mainView.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            mainView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        [Browsable(false)]
        public List<RFoyMuhasebesiIcraEntity> MyIcraFoyMuhasebeDetay
        {
            get
            {
                if (gcGenel.DataSource is List<RFoyMuhasebesiIcraEntity>)
                    return gcGenel.DataSource as List<RFoyMuhasebesiIcraEntity>;

                return null;
            }
            set
            {
                if (gcGenel == null) return;
                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                mainView.Columns.Clear();
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;
                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
                mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;
            }
        }

        [Browsable(false)]
        public List<RFoyMuhasebesiDavaEntity> MyDavaFoyMuhasebeDetay
        {
            get
            {
                if (gcGenel.DataSource is List<RFoyMuhasebesiDavaEntity>)
                    return gcGenel.DataSource as List<RFoyMuhasebesiDavaEntity>;

                return null;
            }
            set
            {
                if (gcGenel == null) return;
                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                mainView.Columns.Clear();
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;

                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
                mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;
            }
        }

        [Browsable(false)]
        public List<RFoyMuhasebesiSorusturmaEntity> MySorusturmaFoyMuhasebe
        {
            get
            {
                if (gcGenel.DataSource is List<RFoyMuhasebesiSorusturmaEntity>)
                    return gcGenel.DataSource as List<RFoyMuhasebesiSorusturmaEntity>;

                return null;
            }
            set
            {
                if (gcGenel == null)
                    return;
                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                mainView.Columns.Clear();
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;

                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
                mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;
            }
        }

        [Browsable(false)]
        public List<RFoyMuhasebesiSozlesmeEntity> MySozlesmeFoyMuhasebe
        {
            get
            {
                if (gcGenel.DataSource is List<RFoyMuhasebesiSozlesmeEntity>)
                    return gcGenel.DataSource as List<RFoyMuhasebesiSozlesmeEntity>;

                return null;
            }
            set
            {
                if (gcGenel == null) return;
                compGridDovizSummary1.YasakliAlanlar.Add("KalanDovizId");
                compGridDovizSummary1.YasakliAlanlar.Add("BirimFiyatDovizId");
                mainView.Columns.Clear();
                //aykut hýzlandýrma 28.01.2013 pivot aç kapat
                tabPPivot.PageVisible = false;

                AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli fm = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuhasebeDetayli();
                mainView.Columns.AddRange(fm.GetMuhasebeDetayliColumns());

                #region Paket Kontrolü

                //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

                #endregion

                gcGenel.DataSource = value;
            }
        }

        //[Browsable(false)]
        //public List<AvukatProLib.Arama.R_FOY_MUHASEBESI_BIRLESIK_DETAYLI> MyFoyMuhasebeDetayliView
        //{
        //    get
        //    {
        //        if (gcGenel.DataSource is List<AvukatProLib.Arama.R_FOY_MUHASEBESI_BIRLESIK_DETAYLI>)
        //            return gcGenel.DataSource as List<AvukatProLib.Arama.R_FOY_MUHASEBESI_BIRLESIK_DETAYLI>;

        //        return null;
        //    }
        //    set
        //    {
        //        if (gcGenel == null) return;
        //        if (value != null)
        //        {
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("KALAN_DOVIZ_ID"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("KALAN_DOVIZ_ID");
        //            if (!compGridDovizSummary1.YasakliAlanlar.Contains("BIRIM_FIYAT_DOVIZ_ID"))
        //                compGridDovizSummary1.YasakliAlanlar.Add("BIRIM_FIYAT_DOVIZ_ID");
        //            mainView.Columns.Clear();
        //            Muhasebe.FoyMuhasebeDetay fm = new Muhasebe.FoyMuhasebeDetay();
        //            gcGenel.Tag = "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI";
        //            mainView.Columns.AddRange(fm.GetMuhasebeDetay());

        //            #region Paket Kontrolü

        //            AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, gcGenel);

        //            #endregion
        //        }
        //        gcGenel.DataSource = value;
        //        tabPPivot.PageVisible = true;
        //    }
        //}

        #endregion

        public ucMuhasebeGenel()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMuhasebeGenel_Load;
        }

        public ucMuhasebeGenel(string moduleName, string columnsMode, object TheObject)
        {
            ModuleName = moduleName;
            ColumnsMode = columnsMode;
            if (TheObject is AV001_TD_BIL_FOY) MyDavaFoy = (AV001_TD_BIL_FOY)TheObject;
            if (TheObject is AV001_TI_BIL_FOY) MyIcraFoy = (AV001_TI_BIL_FOY)TheObject;
            if (TheObject is AV001_TD_BIL_HAZIRLIK) MyHazirlikFoy = (AV001_TD_BIL_HAZIRLIK)TheObject;
            if (TheObject is AV001_TDI_BIL_SOZLESME) MySozlesmeFoy = (AV001_TDI_BIL_SOZLESME)TheObject;
            InitializeComponent();
            this.Load += ucMuhasebeGenel_Load;
        }

        private void ucMuhasebeGenel_Load(object sender, EventArgs e)
        {
            //gcGenel.ButtonEditorClick += gridMasrafAvans_ButtonEditorClick;
            //gcGenel.ButtonClick += new EventHandler<NavigatorButtonClickEventArgs>(gcGenel_ButtonClick);

            if (DesignMode) return;

            //if (MyDavaFoy == null && MyIcraFoy == null && MyHazirlikFoy == null && MySozlesmeFoy == null)
            //    if (!this.IsLoaded) InitializeComponent();
            if (gcGenel == null)
            {
                InitializeComponent();
            }

            mainView.CellValueChanged += gridView2_CellValueChanged;
            mainView.FocusedRowChanged += new FocusedRowChangedEventHandler(gridView2_FocusedRowChanged);
            SaveButtonEnable += ucMuhasebeGenel_SaveButtonEnable;
            SaveButtonDisable += ucMuhasebeGenel_SaveButtonDisable;
            mainView.CustomSummaryExists += gridView2_CustomSummaryExists;
            gcGenel.DataSourceChanged += gcGenel_DataSourceChanged;
            gcGenel.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gcGenel.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            compGridDovizSummary1.YasakliAlanlar.Add("KALAN_DOVIZ_ID");
            compGridDovizSummary1.YasakliAlanlar.Add("BIRIM_FIYAT_DOVIZ_ID");

            if (myCariHesapDetayliArama != null)
            {
                MyMuvekkilCariHesapDetayli = myCariHesapDetayliArama;
                ucPivotChart1.MyCarHesapDetayliArama = myCariHesapDetayliArama;
            }

            

            IsLoaded = true;
            hidePanelTemizle();
        }

        public void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CurrentMasraf = gcGenel.MainView.GetRow(e.FocusedRowHandle);

            hidePanelTemizle();


            KasaHesapId = (int?)mainView.GetRowCellValue(e.FocusedRowHandle, "BuroHesapSahibiCariBankaId");
            if (mainView.GetRowCellValue(e.FocusedRowHandle, "MuhatapHesapSahibiCariBankaId") != DBNull.Value)
                MuhatapHesapId = (int?)mainView.GetRowCellValue(e.FocusedRowHandle, "MuhatapHesapSahibiCariBankaId");

            if (mainView.GetRowCellValue(e.FocusedRowHandle, "KiymetliEvrakId") != DBNull.Value)
                KiymetliEvrakId = (int?)mainView.GetRowCellValue(e.FocusedRowHandle, "KiymetliEvrakId");

            if (mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId") == DBNull.Value)
                return;
            else if (((int?)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId")).HasValue)
            {
                if (ColumnsMode == "Masraf")
                {
                    BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByMayrafAvansDetayId((int)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId"));
                }

                if (ColumnsMode == "Dosya")
                {
                    BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByMuhasebeDetayId((int)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId"));
                }

                if (ColumnsMode == "Personel" || ColumnsMode == "Müvekkil")
                {
                    BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByCariHesapDetayId((int)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId"));
                }

                if (ColumnsMode == "Serbest")
                {
                    BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByFaturaId((int)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId"));
                }

                if (ColumnsMode == "Kasa")
                {
                    BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByKasaDetayDetayId((int)mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId"));
                }

                if (KasaHesapId.HasValue)
                {
                    BelgeUtil.Inits.CariIsmiGetir(rlueKasaCariAd);
                    BelgeUtil.Inits.BankaGetir(rlueKasaBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueKasaSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueKasaHesapTuru);
                    BelgeUtil.Inits.BankaKartTipiGetir(rlueKasaKartTipi);

                    gcKasaHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetCariBankaById((int)KasaHesapId);
                    gcKasaHesap.Visible = true;
                }

                if (MuhatapHesapId.HasValue)
                {
                    BelgeUtil.Inits.CariIsmiGetir(rlueMuhatapCari);
                    BelgeUtil.Inits.BankaGetir(rlueMuhatapBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueMuhatapSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueMuhatapHesapTur);
                    BelgeUtil.Inits.BankaKartTipiGetir(rlueMuhatapKartTipi);
                    gcMuhatapHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetCariBankaById((int)MuhatapHesapId);

                    gcMuhatapHesap.Visible = true;
                }

                if (KiymetliEvrakId.HasValue)
                {

                    BelgeUtil.Inits.BankaGetir(rlueKiymetliEvrakBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueKiymetliEvrakSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueKiymetliEvrakDoviz);
                    BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlueKiymetliEvrakTur);


                    List<Av001TdiBilKiymetliEvrakEntity> gelenKiymetliEvrak = AvukatPro.Services.Implementations.DosyaService.GetKiymetliEvrakById((int)KiymetliEvrakId);
                    gcKiymetliEvrak.DataSource = gelenKiymetliEvrak;
                    List<Av001TdiBilKiymetliEvrakTarafEntity> gelenTaraflar = AvukatPro.Services.Implementations.DosyaService.GetKiymetliEvrakTarafByKiymetliEvrakId(gelenKiymetliEvrak.FirstOrDefault().Id);

                    if (gelenTaraflar.Count > 0)
                    {
                        gcKiymetliEvrakTaraf.DataSource = gelenTaraflar;
                        gcKiymetliEvrakTaraf.Visible = true;
                        BelgeUtil.Inits.perCariGetir(rlueTarafCari);
                        BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rlueTarafTipi);
                        gcKiymetliEvrakTaraf.BringToFront();
                    }

                    gcKiymetliEvrak.Visible = true;

                }

                if (BelgeIds != null && BelgeIds.Count > 0)
                {
                    dnBelge.DataSource = BelgeIds;
                    Av001TdieBilBelgeEntity belge = AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[0]);
                    belgeyiOnlizle(belge, 0);
                    btnProgram.Enabled = true;
                    ucBelgeOnizleme1.Visible = true;
                }
            }
        }
                
        public static void SetColumnsView(DevExpress.XtraGrid.Columns.GridColumnCollection gcc, string ColumnsMode, string Module)
        {
            if (!string.IsNullOrEmpty(ColumnsMode))
            {
                int index = 0;
                int visibleColmunsEndIndex = 0;
                if (ColumnsMode.Equals("Müvekkil") || ColumnsMode.Equals("Personel"))
                {
                    //index = 0;
                    //gcc["Tarih"].VisibleIndex = index++;
                    //gcc["BorcAlacakId"].VisibleIndex = index++;
                    //gcc["Alinan"].VisibleIndex = index++;
                    //gcc["AlinanDovizId"].VisibleIndex = index++;
                    //gcc["Odenen"].VisibleIndex = index++;
                    //gcc["OdenenDovizId"].VisibleIndex = index++;
                    //gcc["Kalan"].VisibleIndex = index++;
                    //gcc["KalanDovizId"].VisibleIndex = index++;
                    //gcc["HareketAnaKategoriId"].VisibleIndex = index++;
                    //gcc["HareketAltKaregoriId"].VisibleIndex = index++;
                    //gcc["HESAP_ACIKLAMA"].VisibleIndex = index++;
                    //gcc["Dosya_No"].VisibleIndex = index++;
                    //gcc["FOY_ADLIYE"].VisibleIndex = index++;
                    //gcc["FOY_ADLI_BIRIM_NO"].VisibleIndex = index++;
                    //gcc["FOY_GOREV"].VisibleIndex = index++;
                    //gcc["Esas_No"].VisibleIndex = visibleColmunsEndIndex = index++;
                    //gcc["CARI_AD"].Caption = ColumnsMode;
                    //gcc["BORC_ALACAK_ADI"].Caption = "B/A";
                    if (ColumnsMode.Equals("Müvekkil"))
                        gcc["CariId"].Caption = "Müvekkil";
                    else if (ColumnsMode.Equals("Personel"))
                        gcc["CariId"].Caption = "Personel";

                }
                else if (ColumnsMode.Equals("Dosya"))
                {
                    //gcc["FoyNo"].VisibleIndex = 0;
                    //gcc["AdliBirimAdliyeId"].VisibleIndex = 1;
                    //gcc["AdliBirimNoId"].VisibleIndex = 2;
                    //gcc["AdliBirimGorevId"].VisibleIndex = 3;
                    //gcc["EsasNo"].VisibleIndex = 4;
                    //gcc["HareketAltKategoriId"].VisibleIndex = 5;
                    //gcc["Tarih"].VisibleIndex = 6;
                    //gcc["BirimFiyat"].VisibleIndex = 7;
                    //gcc["BirimFiyatDovizId"].VisibleIndex = 8;
                    //gcc["Adet"].VisibleIndex = 9;
                    //gcc["ToplamTutar"].VisibleIndex = 10;
                    //gcc["ToplamTutarDovizId"].VisibleIndex = 11;
                    //gcc["Aciklama"].VisibleIndex = 12;
                    //gcc["MuvekkilCariId"].VisibleIndex = 13;
                    //gcc["CariId"].VisibleIndex = 14;
                    //gcc["BorcluCariId"].VisibleIndex = visibleColmunsEndIndex = 15;
                    //gcc["CariId"].Caption = "Sorumlu";
                }
                else if (ColumnsMode.Equals("Masraf"))
                {
                    index = -1;
                    if (Module == "Dava" || Module == "Ýcra" || Module == "Soruþturma" || Module == "Sözleþme" || Module == "Genel")
                    {
                        DevExpress.XtraGrid.Columns.GridColumn colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
                        colIsSelected.Caption = "Seç";
                        colIsSelected.FieldName = "IsSelected";
                        colIsSelected.Name = "colIsSelected";
                        colIsSelected.Visible = true;
                        colIsSelected.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        colIsSelected.ColumnEdit.ReadOnly = false;
                        colIsSelected.ColumnEdit.AllowFocused = true;
                        colIsSelected.OptionsColumn.AllowEdit = true;
                        colIsSelected.OptionsColumn.ReadOnly = false;
                        colIsSelected.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        gcc.Add(colIsSelected);
                        colIsSelected.VisibleIndex = visibleColmunsEndIndex = ++index;
                    }
                    gcc["SegmentId"].VisibleIndex = ++index;
                    gcc["ModulId"].VisibleIndex = ++index;
                    gcc["MasrafAvansTip"].VisibleIndex = ++index;
                    gcc["MuvekkilCariId"].VisibleIndex = ++index;
                    gcc["CariId"].VisibleIndex = ++index;
                    //gcc["BorcluCariId"].VisibleIndex = ++index;
                    gcc["Tarih"].VisibleIndex = ++index;
                    gcc["HareketAltKategoriId"].VisibleIndex = ++index;
                    gcc["BorcAlacakId"].VisibleIndex = ++index;
                    gcc["Adet"].VisibleIndex = ++index;
                    gcc["BirimFiyat"].VisibleIndex = ++index;
                    gcc["BirimFiyatDovizId"].VisibleIndex = ++index;
                    gcc["ToplamTutar"].VisibleIndex = ++index;
                    //gcc["ToplamTutarDovizId"].VisibleIndex = ++index;
                    gcc["KdvTutar"].VisibleIndex = ++index;
                    gcc["StopajSsdfTutar"].VisibleIndex = ++index;
                    gcc["GenelToplam"].VisibleIndex = ++index;
                    //gcc["GenelToplamDovizId"].VisibleIndex = ++index;
                    //gcc["Aciklama"].VisibleIndex = ++index;
                    gcc["ReferansNo"].VisibleIndex = ++index;
                    gcc["HareketAnaKategoriId"].Visible = false;

                    if (!(Module == "Dava" || Module == "Ýcra" || Module == "Soruþturma" || Module == "Sözleþme"))
                    {
                        gcc["FoyNo"].VisibleIndex = ++index;
                        gcc["AdliBirimAdliyeId"].VisibleIndex = ++index;
                        gcc["AdliBirimNoId"].VisibleIndex = ++index;
                        gcc["AdliBirimGorevId"].VisibleIndex = ++index;
                        gcc["EsasNo"].VisibleIndex = ++index;
                    }
                    gcc["CariId"].Caption = "Sorumlu";
                    gcc["BorcAlacakId"].Caption = "B/A";

                }
                else if (ColumnsMode.Equals("Serbest"))
                {
                    //index = 0;
                    //gcc["SegmentId"].VisibleIndex = index++;
                    //gcc["FaturaTarihi"].VisibleIndex = index++;
                    //gcc["SeriNo"].VisibleIndex = index++;
                    //gcc["CariId"].VisibleIndex = index++;
                    //gcc["FaturaKapsamTip"].VisibleIndex = index++;
                    //gcc["Miktar"].VisibleIndex = index++;
                    //gcc["MiktarDovizId"].VisibleIndex = index++;
                    //gcc["Kdv"].VisibleIndex = index++;
                    //gcc["KdvDovizId"].VisibleIndex = index++;
                    //gcc["Toplam"].VisibleIndex = index++;
                    //gcc["ToplamDovizId"].VisibleIndex = index++;
                    //gcc["Aciklama"].VisibleIndex = index++; ;
                    //gcc["FaturaHedefTip"].VisibleIndex = index++;
                    //gcc["ICRA_FOY_NO"].VisibleIndex = 12;
                    //gcc["DAVA_FOY_NO"].VisibleIndex = 13;
                    //gcc["HAZIRLIK_NO"].VisibleIndex = visibleColmunsEndIndex = 14;
                    //gcc["ToplamDovizId"].Caption = " ";
                    //gcc["DAVA_FOY_NO"].Caption = "Dava Dosya No";
                    //gcc["HAZIRLIK_NO"].Caption = "Soruþturma Dosya No";
                }
                else if (ColumnsMode.Equals("Kasa"))
                {
                    //index = 0;
                    //gcc["SegmentId"].VisibleIndex = index++;
                    //gcc["HareketCariId"].VisibleIndex = index++;
                    //gcc["BorcAlacakId"].VisibleIndex = index++;
                    //gcc["BelgeNo"].VisibleIndex = index++;
                    //gcc["OdemeTipId"].VisibleIndex = index++;
                    //gcc["Tarih"].VisibleIndex = index++;
                    //gcc["HareketAnaKategoriId"].VisibleIndex = index++;
                    //gcc["HareketAltKategoriId"].VisibleIndex = index++;
                    //gcc["BirimFiyat"].VisibleIndex = index++;
                    //gcc["BirimFiyatDovizId"].VisibleIndex = index++;
                    //gcc["Adet"].VisibleIndex = index++;
                    //gcc["GenelToplam"].VisibleIndex = index++;
                    //gcc["Aciklama"].VisibleIndex = index++;
                    //gcc["ReferansNo"].VisibleIndex = index++;
                    //gcc["BirimFiyatDovizId"].Caption = " ";
                    //gcc["BirimFiyatDovizId"].ToolTip = "Birim Fiyat Döviz";
                }
                else return;

                //foreach (DevExpress.XtraGrid.Columns.GridColumn item in gcc)
                //    if (item.VisibleIndex > visibleColmunsEndIndex || item.VisibleIndex < 0)
                //        item.Visible = false;
                //    else item.Visible = true;
            }

        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            #region Masraf-Avans

            if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
            {
                DevExpress.XtraBars.BarSubItem bus = new DevExpress.XtraBars.BarSubItem(e.Manager, "Ýþlemler");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.money;
                DevExpress.XtraBars.BarButtonItem bus1 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Hýzlý Masraf Kaydet");
                bus1.Name = "bButtonHizliMasrafKaydet";
                DevExpress.XtraBars.BarButtonItem bus2 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Hýzlý Avans Kaydet");
                bus2.Name = "bButtonHizliAvansKaydet";
                DevExpress.XtraBars.BarButtonItem bus3 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seri Masraf Kaydet");
                bus3.Name = "bButtonSeriMasrafKaydet";
                DevExpress.XtraBars.BarButtonItem bus4 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Seri Avans Kaydet");
                bus4.Name = "bButtonSeriAvansKaydet";
                DevExpress.XtraBars.BarButtonItem bus5 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Masraf Avans Kaydýný Sil");
                bus5.Name = "bButtonMasrafAvansSil";
                bus5.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus6 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Dosyasýný Aç");
                bus6.Name = "bButtonDosyaAc";
                bus6.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus7 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Klasörünü Aç");
                bus7.Name = "bButtonKlasorAc";
                bus7.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus8 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Belgesini Yazdýr");
                bus8.Name = "bButtonBelgeYazdýr";
                bus8.Enabled = false;
                foreach (DevExpress.XtraBars.BarItemLink item in e.MyPopupMenu.ItemLinks)
                {
                    if (item.Caption == "Yeni Kayýt")
                        item.Visible = false;
                    if (item.Caption == "Kolay Kayýt")
                        item.Visible = false;
                }
                bus.ItemLinks.AddRange(new DevExpress.XtraBars.BarItem[]
                                           {
                                               bus1,
                                               bus2,
                                               bus3,
                                               bus4,
                                               bus5,
                                               bus6,
                                               bus7,
                                               bus8,
                                           });
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }

            #endregion Masraf-Avans

            #region Personel

            if (gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
            {
                if (personel)
                {
                    DevExpress.XtraBars.BarSubItem bus = new DevExpress.XtraBars.BarSubItem(e.Manager, "Ýþlemler");
                    bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Personel_12x12;

                    DevExpress.XtraBars.BarButtonItem bus1 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Personele Avans Kaydet");
                    bus1.Tag = e.Rows;
                    bus1.Name = "bButtonPersonelAvansKaydet";
                    DevExpress.XtraBars.BarButtonItem bus2 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Personele Maaþ Kaydet");
                    bus2.Tag = e.Rows;
                    bus2.Name = "bButtonPersonelAvansKaydet";
                    DevExpress.XtraBars.BarButtonItem bus3 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Personel Kaydýný Sil");
                    bus3.Tag = e.Rows;
                    bus3.Name = "bButtonPersonelAvansKaydet";
                    DevExpress.XtraBars.BarButtonItem bus4 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Dosyasýný Aç");
                    bus4.Name = "bButtonDosyaAc";
                    bus4.Tag = e.Rows;
                    DevExpress.XtraBars.BarButtonItem bus5 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Belgesini Yazdýr");
                    bus5.Name = "bButtonBelgeYazdýr";
                    bus5.Enabled = false;
                    bus.ItemLinks.AddRange(new DevExpress.XtraBars.BarItem[]
                                               {
                                                   bus1,
                                                   bus2,
                                                   bus3,
                                                   bus4,
                                                   bus5,
                                               });
                    e.MyPopupMenu.ItemLinks.Insert(0, bus);
                }
            }

            #endregion Personel

            #region Müvekkil

            if (!personel)
            {
                if (gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
                {
                    DevExpress.XtraBars.BarSubItem bus = new DevExpress.XtraBars.BarSubItem(e.Manager, "Ýþlemler");
                    bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Personel_12x12;

                    DevExpress.XtraBars.BarButtonItem bus1 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Müvekkile Ödeme Kaydet");
                    bus1.Name = "bButtonPersonelAvansKaydet";
                    bus1.Tag = e.Rows;
                    DevExpress.XtraBars.BarButtonItem bus2 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Müvekkile Avans Kaydet");
                    bus2.Name = "bButtonPersonelAvansKaydet";
                    bus2.Tag = e.Rows;
                    DevExpress.XtraBars.BarButtonItem bus3 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Müvekkile Ýade Avans Kaydet");
                    bus3.Name = "bButtonPersonelAvansKaydet";
                    bus3.Tag = e.Rows;
                    DevExpress.XtraBars.BarButtonItem bus4 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Müvekkil Kaydýný Sil");
                    bus4.Tag = e.Rows;
                    bus4.Name = "bButtonPersonelAvansKaydet";
                    DevExpress.XtraBars.BarButtonItem bus5 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Dosyasýný Aç");
                    bus5.Name = "bButtonDosyaAc";
                    bus5.Tag = e.Rows;
                    DevExpress.XtraBars.BarButtonItem bus6 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Belgesini Yazdýr");
                    bus6.Name = "bButtonBelgeYazdýr";
                    bus6.Enabled = false;
                    bus.ItemLinks.AddRange(new DevExpress.XtraBars.BarItem[]
                                               {
                                                   bus1,
                                                   bus2,
                                                   bus3,
                                                   bus4,
                                                   bus5,
                                                   bus6,
                                               });
                    e.MyPopupMenu.ItemLinks.Insert(0, bus);
                }
            }

            #endregion Müvekkil

            #region Kasa

            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
            {
                DevExpress.XtraBars.BarSubItem bus = new DevExpress.XtraBars.BarSubItem(e.Manager, "Ýþlemler");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.kasa1_12x12;

                DevExpress.XtraBars.BarButtonItem bus1 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Yeni Kasa Giriþi Kaydet");
                bus1.Name = "bButtonPersonelAvansKaydet";

                DevExpress.XtraBars.BarButtonItem bus4 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Kasa Giriþ Kaydýný Sil");
                bus4.Tag = e.Rows;
                bus4.Name = "bButtonPersonelAvansKaydet";
                DevExpress.XtraBars.BarButtonItem bus5 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Dosyasýný Aç");
                bus5.Name = "bButtonDosyaAc";
                bus5.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus6 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Belgesini Yazdýr");
                bus6.Name = "bButtonBelgeYazdýr";
                bus6.Enabled = false;
                bus.ItemLinks.AddRange(new DevExpress.XtraBars.BarItem[]
                                           {
                                               bus1,
                                               bus4,
                                               bus5,
                                               bus6,
                                           });
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }

            #endregion Kasa

            #region Serbest Meslek Makbuzu

            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
            {
                DevExpress.XtraBars.BarSubItem bus = new DevExpress.XtraBars.BarSubItem(e.Manager, "Ýþlemler");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.belgeler12x12;

                DevExpress.XtraBars.BarButtonItem bus1 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "SMM Giriþi Kaydet");
                bus1.Name = "bButtonPersonelAvansKaydet";

                DevExpress.XtraBars.BarButtonItem bus4 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "SMM Kaydýný Sil");
                bus4.Tag = e.Rows;
                bus4.Name = "bButtonPersonelAvansKaydet";
                DevExpress.XtraBars.BarButtonItem bus5 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Dosyasýný Aç");
                bus5.Name = "bButtonDosyaAc";
                bus5.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus2 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Klasörünü Aç");
                bus2.Name = "bButtonDosyaAc";
                bus2.Tag = e.Rows;
                DevExpress.XtraBars.BarButtonItem bus6 = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Bu Kaydýn Belgesini Yazdýr");
                bus6.Name = "bButtonBelgeYazdýr";
                bus6.Enabled = false;
                bus.ItemLinks.AddRange(new DevExpress.XtraBars.BarItem[]
                                           {
                                               bus1,
                                               bus2,
                                               bus4,
                                               bus5,
                                               bus6,
                                           });
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }

            #endregion Serbest Meslek Makbuzu
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Eski

            //if (e.Item.Caption != null)
            //{
            //    if (e.Item.Caption.ToString() == "Yeni Kayýt")
            //    {
            //        object dataSource = gcGenel.DataSource;
            //        if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
            //        {
            //            Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
            //            masraf.MdiParent = null;
            //            masraf.IsModul = true;
            //            masraf.Show();
            //            masraf.FormClosed += new FormClosedEventHandler(masraf_FormClosed);
            //        }
            //        if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
            //        {
            //            AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
            //            frmMuhasebeGir.MdiParent = null;
            //            frmMuhasebeGir.Show();
            //            frmMuhasebeGir.FormClosed += muhasebe_FormClosed;

            //        }
            //        if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
            //        {
            //            rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
            //            frmMeslekMakbuzu.MdiParent = null;
            //            frmMeslekMakbuzu.IsModul = true;
            //            frmMeslekMakbuzu.Show();
            //            frmMeslekMakbuzu.FormClosed += new FormClosedEventHandler(frmMeslekMakbuzu_FormClosed);
            //        }
            //        if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
            //        {
            //            Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
            //            kg.MdiParent = null;
            //            kg.ShowDialog();
            //            kg.FormClosed += new FormClosedEventHandler(kg_FormClosed);
            //        }
            //    }
            //    if (e.Item.Caption == "Düzenle")
            //    {
            //        object dataSource = gcGenel.DataSource;
            //        if (gridView2.FocusedRowHandle > 0)
            //        {
            //            if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
            //            {
            //                AV001_TDI_BIL_MASRAF_AVANS data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((gcGenel.DataSource as List<R_MASRAF_AVANS_DETAYLI2>)[gridView2.FocusedRowHandle].ID);
            //                Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
            //                masraf.MdiParent = null;
            //                masraf.MyDataSource = data;
            //                masraf.IsModul = false;
            //                masraf.Show();
            //                masraf.FormClosed += new FormClosedEventHandler(masraf_FormClosed);
            //            }
            //            if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
            //            {
            //                AV001_TDI_BIL_MASRAF_AVANS data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((gcGenel.DataSource as List<R_MASRAF_AVANS_DETAYLI2>)[gridView2.FocusedRowHandle].ID);
            //                AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
            //                frmMuhasebeGir.MdiParent = null;
            //                frmMuhasebeGir.MyMasrafAvans = data;
            //                frmMuhasebeGir.Show();
            //                frmMuhasebeGir.FormClosed += muhasebe_FormClosed;

            //            }
            //            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
            //            {
            //                AvukatProLib2.Entities.AV001_TDI_BIL_FATURA data = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((gcGenel.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_FATURA>)[gridView2.FocusedRowHandle].ID);
            //                rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
            //                frmMeslekMakbuzu.MdiParent = null;
            //                frmMeslekMakbuzu.AddNewList.Add(data);
            //                frmMeslekMakbuzu.IsModul = false;
            //                frmMeslekMakbuzu.Show();
            //                frmMeslekMakbuzu.FormClosed += new FormClosedEventHandler(frmMeslekMakbuzu_FormClosed);
            //            }
            //            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
            //            {
            //                AvukatProLib2.Entities.AV001_TDI_BIL_KASA data = DataRepository.AV001_TDI_BIL_KASAProvider.GetByID((gcGenel.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_KASA>)[gridView2.FocusedRowHandle].ID);
            //                Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
            //                kg.EklenenlerListesi.Add(data);
            //                kg.MdiParent = null;
            //                kg.ShowDialog();
            //                kg.FormClosed += new FormClosedEventHandler(kg_FormClosed);
            //            }
            //        }
            //    }
            //}

            #endregion Eski

            #region Masraf-Avans

            if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
            {
                switch (e.Item.Caption)
                {
                    case "Düzenle":
                        object dataSource = gcGenel.DataSource;
                        if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                        {
                            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                            CompInfo cmpNfo = cmpNfoList[0];
                            if (cmpNfo.DegistirmeSilmeSifresiAktif)
                            {
                                frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(4);
                                frm.ShowDialog();
                                if (!frm.Onaylandi)
                                    return;
                            }

                            AV001_TDI_BIL_MASRAF_AVANS data = null;
                            if (MyDavaFoy == null && MyIcraFoy == null && MyHazirlikFoy == null && MySozlesmeFoy == null)
                                data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            else
                            {
                                data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            }
                            //Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
                            IcraTakipForms.frmMasrafAvansKayitHizli masraf = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                            masraf.Duzenleme = true;

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(data, false, DeepLoadType.IncludeChildren, typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY), typeof(AvukatProLib2.Entities.AV001_TD_BIL_FOY), typeof(AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK), typeof(TList<AvukatProLib2.Entities.AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                            if (data.ICRA_FOY_ID != null)
                                masraf.MyIcraFoy = data.ICRA_FOY_IDSource;
                            else if (data.DAVA_FOY_ID != null)
                                masraf.MyDavaFoy = data.DAVA_FOY_IDSource;
                            else if (data.HAZIRLIK_ID != null)
                                masraf.MyHazirlikFoy = data.HAZIRLIK_IDSource;

                            //masraf.MdiParent = null;
                            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;

                            masraf.MyDataSource = data;
                            //aykut hýzlandýrma 25.01.2013
                            //masraf.DefaultDetail = GetSelectedDetail((RMasrafAvansDetayli2Entity)mainView.GetFocusedRow(), data);
                            masraf.DefaultDetail = GetSelectedDetail(data);
                            masraf.FormClosed += masraf_FormClosed;
                            if (data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID != null)
                                masraf.DefaultMuvekkil = data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID.Value;

                            masraf.Show();
                        }
                        break;
                    case "Hýzlý Masraf Kaydet":
                        if (e.Item.Name == "bButtonHizliMasrafKaydet")
                        {
                            //Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
                            IcraTakipForms.frmMasrafAvansKayitHizli masraf =
                                new IcraTakipForms.frmMasrafAvansKayitHizli();
                            // masraf.MdiParent = null;
                            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            masraf.AcilisYeri =
                                AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.PersonelMuhasebeMasraf;
                            masraf.FormClosed += masraf_FormClosed;
                            masraf.Show();

                            //masraf.MyDataSource.MASRAF_AVANS_TIP = (int)MasrafAvansTip.Masraf;
                            //masraf.ShowDialog(AvukatProLib.Extras.MasrafAvansTip.Masraf);
                        }
                        break;
                    case "Hýzlý Avans Kaydet":
                        if (e.Item.Name == "bButtonHizliAvansKaydet")
                        {
                            //Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
                            IcraTakipForms.frmMasrafAvansKayitHizli masraf =
                                new IcraTakipForms.frmMasrafAvansKayitHizli();
                            // masraf.MdiParent = null;
                            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.PersonelMuhasebeAvans;
                            masraf.FormClosed += masraf_FormClosed;
                            masraf.Show();
                        }
                        break;
                    case "Seri Masraf Kaydet":
                        if (e.Item.Name == "bButtonSeriMasrafKaydet")
                        {
                            AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMasrafKaydet = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                            frmMasrafKaydet.Show(AvukatProLib.Extras.MasrafAvansTip.Masraf);
                        }
                        break;
                    case "Seri Avans Kaydet":
                        if (e.Item.Name == "bButtonSeriAvansKaydet")
                        {
                            AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMasrafKaydet = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                            frmMasrafKaydet.Show(AvukatProLib.Extras.MasrafAvansTip.Avans);
                        }
                        break;
                    case "Masraf Avans Kaydýný Sil":
                        if (e.Item.Name == "bButtonMasrafAvansSil")
                        {
                            if (e.Item.Tag != null)
                            {
                                //aykut hýzlandýrma 25.01.2013
                                //RMasrafAvansDetayli2Entity masraf =
                                //    e.Item.Tag as RMasrafAvansDetayli2Entity;

                                //frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_MASRAF_AVANS_DETAY",
                                //                                       "ID = " + masraf.Id);

                                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_MASRAF_AVANS_DETAY",
                                                                       "ID = " + (int?)mainView.GetFocusedRowCellValue("KayitId"));
                                if (kayitSil.ShowDialog() == DialogResult.OK)
                                    MyMasrafAvansDetayli = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasraf();
                            }
                        }
                        break;
                    case "Bu Kaydýn Dosyasýný Aç":
                        if (e.Item.Name == "bButtonDosyaAc")
                        {
                            if (e.Item.Tag != null)
                            {
                                //aykut hýzlandýrma 25.01.2013
                                //RMasrafAvansDetayli2Entity masraf =
                                //    e.Item.Tag as RMasrafAvansDetayli2Entity;
                                //if (masraf.KayitId > 0)
                                //    TakibeGonder(masraf.KayitId.Value, (AvukatProLib.Extras.Modul)masraf.ModulId.Value);
                                //else
                                //    XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..",
                                //                        "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if ((int?)mainView.GetFocusedRowCellValue("KayitId") > 0)
                                    TakibeGonder((int)mainView.GetFocusedRowCellValue("KayitId"), (AvukatProLib.Extras.Modul)(int?)mainView.GetFocusedRowCellValue("ModulId"));
                                else
                                    XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..",
                                                        "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    case "Bu Kaydýn Klasörünü Aç":
                        if (e.Item.Name == "bButtonKlasorAc")
                        {
                            if (e.Item.Tag != null)
                            {
                                //aykut hýzlandýrma 25.01.2013
                                //RMasrafAvansDetayli2Entity masraf =
                                //    e.Item.Tag as RMasrafAvansDetayli2Entity;
                                //KlasorAc(masraf.KayitId, (AvukatProLib.Extras.Modul?)masraf.ModulId, (int)masraf.Id);

                                KlasorAc((int?)mainView.GetFocusedRowCellValue("KayitId"), (AvukatProLib.Extras.Modul?)(int?)mainView.GetFocusedRowCellValue("ModulId"), (int)(int?)mainView.GetFocusedRowCellValue("ID"));
                            }
                        }
                        break;
                    case "Bu Kaydýn Belgesini Yazdýr":
                        if (e.Item.Name == "bButtonBelgeYazdýr")
                        {
                            if (e.Item.Tag != null)
                            {
                                RMasrafAvansDetayli2Entity masraf =
                                    e.Item.Tag as RMasrafAvansDetayli2Entity;
                                //yazdýrma yap
                            }
                        }
                        break;
                }
            }

            #endregion Masraf-Avans

            #region Personel

            if (gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
            {
                RCariHesapDetayliEntity carihesa = e.Item.Tag as RCariHesapDetayliEntity;
                AvukatProLib2.Entities.AV001_TDI_BIL_CARI_HESAP Chesap = null;
                Forms.HesapMuhasebe.frmSahisHesapHareket hesapHareket =
                    new AdimAdimDavaKaydi.Forms.HesapMuhasebe.frmSahisHesapHareket();
                if (personel)
                {
                    switch (e.Item.Caption)
                    {
                        case "Personele Avans Kaydet":

                            if (carihesa != null)
                            {
                                Chesap = DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetByID(carihesa.Id);
                            }

                            hesapHareket.MyDataSource = Chesap;
                            // hesapHareket.MdiParent = null;
                            hesapHareket.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            hesapHareket.IsModul = true;
                            hesapHareket.Show((int)AvukatProLib.Extras.MuhasebeAltKategoriId.AVANS_ODEMELERI, 54);
                            break;
                        case "Personele Maaþ Kaydet":

                            #region

                            if (carihesa != null)
                                Chesap = DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetByID(carihesa.Id);

                            #endregion Personel

                            hesapHareket.MyDataSource = Chesap;
                            // hesapHareket.MdiParent = null;
                            hesapHareket.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            hesapHareket.IsModul = true;
                            hesapHareket.Show((int)AvukatProLib.Extras.MuhasebeAltKategoriId.MAAS_ÖDEMELERI, 54);
                            //Cariden formYapilacak
                            break;
                        case "Personel Kaydýný Sil":
                            if (e.Item.Tag != null)
                            {
                                //RCariHesapDetayliEntity hesap =
                                //    e.Item.Tag as RCariHesapDetayliEntity;
                                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_CARI_HESAP_DETAY", "ID = " + (int)mainView.GetFocusedRowCellValue("HesapDetayId"));
                                if (kayitSil.ShowDialog() == DialogResult.OK)
                                    mainView.DeleteRow(mainView.FocusedRowHandle);
                            }
                            break;
                        case "Bu Kaydýn Dosyasýný Aç":
                            if (e.Item.Tag != null)
                            {
                                int KayitId = (int)mainView.GetFocusedRowCellValue("FoyId");
                                AvukatProLib.Extras.Modul modu = new AvukatProLib.Extras.Modul();

                                //RCariHesapDetayliEntity carihe = e.Item.Tag as RCariHesapDetayliEntity;
                                //int KayitId = 0;
                                //AvukatProLib.Extras.Modul modu = new AvukatProLib.Extras.Modul();
                                //if (carihe.FoyId.HasValue)
                                //    KayitId = carihe.FoyId.Value;

                                if (mainView.GetFocusedRowCellValue("CariHesapHedefTip") != null)
                                {
                                    switch ((int)mainView.GetFocusedRowCellValue("CariHesapHedefTip"))
                                    {
                                        case 1:
                                            modu = AvukatProLib.Extras.Modul.Icra;
                                            break;
                                        case 2:
                                            modu = AvukatProLib.Extras.Modul.Dava;
                                            break;
                                        case 3:
                                            modu = AvukatProLib.Extras.Modul.Sorusturma;
                                            break;
                                        case 4:
                                            modu = AvukatProLib.Extras.Modul.Sozlesme;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (KayitId > 0)
                                    TakibeGonder(KayitId, modu);
                                else
                                    XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..",
                                                        "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Bu Kaydýn Belgesini Yazdýr":
                            break;
                    }
                }
            }

            #endregion

            #region Muvekkil

            if (gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
            {
                RCariHesapDetayliEntity carihesa = e.Item.Tag as RCariHesapDetayliEntity;
                AvukatProLib2.Entities.AV001_TI_BIL_FOY foy = null;
                AvukatProLib2.Entities.AV001_TDI_BIL_CARI_HESAP Chesap = null;
                Forms.HesapMuhasebe.frmSahisHesapHareket hesapHareket =
                    new AdimAdimDavaKaydi.Forms.HesapMuhasebe.frmSahisHesapHareket();
                if (!personel)
                {
                    switch (e.Item.Caption)
                    {
                        case "Müvekkile Ödeme Kaydet":

                            if (carihesa != null)
                            {
                                if (carihesa.FoyId.HasValue && carihesa.CariHesapHedefTip == 1)
                                    foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(carihesa.FoyId.Value);
                            }
                            AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout odeme = new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout();
                            //if (foy != null) odeme.MyIcraFoy = foy;
                            odeme.Show();
                            break;
                        case "Müvekkile Avans Kaydet":

                            #region

                            if (carihesa != null)
                                Chesap = DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetByID(carihesa.Id);

                            #endregion

                            hesapHareket.MyDataSource = Chesap;
                            //hesapHareket.MdiParent = null;
                            hesapHareket.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            hesapHareket.IsModul = true;
                            hesapHareket.Show((int)AvukatProLib.Extras.MuhasebeAltKategoriId.AVANS_ODEMELERI, 54);
                            break;
                        case "Müvekkile Ýade Avans Kaydet":

                            #region

                            if (carihesa != null)
                                Chesap = DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetByID(carihesa.Id);

                            #endregion

                            hesapHareket.MyDataSource = Chesap;
                            // hesapHareket.MdiParent = null;
                            hesapHareket.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            hesapHareket.IsModul = true;
                            hesapHareket.Show((int)AvukatProLib.Extras.MuhasebeAltKategoriId.IADE_AVANS_ODEMELERI, 54);
                            break;
                        case "Müvekkil Kaydýný Sil":
                            if (e.Item.Tag != null)
                            {
                                //RCariHesapDetayliEntity masraf =
                                //    e.Item.Tag as RCariHesapDetayliEntity;

                                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_CARI_HESAP_DETAY",
                                                                       "ID = " + (int)mainView.GetFocusedRowCellValue("HesapDetayId"));
                                if (kayitSil.ShowDialog() == DialogResult.OK)
                                    mainView.DeleteRow(mainView.FocusedRowHandle);
                            }
                            break;
                        case "Bu Kaydýn Dosyasýný Aç":
                            if (e.Item.Tag != null)
                            {
                                //RCariHesapDetayliEntity cariHesap = e.Item.Tag as RCariHesapDetayliEntity;
                                int KayitId = (int)mainView.GetFocusedRowCellValue("FoyId");
                                AvukatProLib.Extras.Modul modu = new AvukatProLib.Extras.Modul();
                                if (mainView.GetFocusedRowCellValue("CariHesapHedefTip") != null)
                                {
                                    switch ((int)mainView.GetFocusedRowCellValue("CariHesapHedefTip"))
                                    {
                                        case 1:
                                            modu = AvukatProLib.Extras.Modul.Icra;
                                            break;
                                        case 2:
                                            modu = AvukatProLib.Extras.Modul.Dava;
                                            break;
                                        case 3:
                                            modu = AvukatProLib.Extras.Modul.Sorusturma;
                                            break;
                                        case 4:
                                            modu = AvukatProLib.Extras.Modul.Sozlesme;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (KayitId > 0)
                                    TakibeGonder(KayitId, modu);
                                else
                                    XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..",
                                                        "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Bu Kaydýn Belgesini Yazdýr":
                            break;
                    }
                }
            }

            #endregion

            #region Kasa

            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
            {
                switch (e.Item.Caption)
                {
                    case "Düzenle":
                        List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                        CompInfo cmpNfo = cmpNfoList[0];
                        if (cmpNfo.DegistirmeSilmeSifresiAktif)
                        {
                            frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(4);
                            frm.ShowDialog();
                            if (!frm.Onaylandi)
                                return;
                        }

                        AvukatProLib2.Entities.AV001_TDI_BIL_KASA data =
                            DataRepository.AV001_TDI_BIL_KASAProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                        Forms.frmKasaGiris kg1 = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
                        kg1.YeniKayit = false;
                        kg1.EklenenlerListesi.Add(data);
                        //kg.MdiParent = null;
                        kg1.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        kg1.FormClosed += kg_FormClosed;
                        kg1.Show();
                        break;
                    case "Yeni Kasa Giriþi Kaydet":
                        Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
                        //kg.MdiParent = null;
                        kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        kg.FormClosed += kg_FormClosed;
                        kg.Show();
                        break;
                    case "Kasa Giriþ Kaydýný Sil":
                        if (e.Item.Tag != null)
                        {
                            //Av001TdiBilKasaEntity masraf =
                            //    e.Item.Tag as Av001TdiBilKasaEntity;
                            frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_KASA", "ID = " + mainView.GetFocusedRowCellValue("Id"));
                            if (kayitSil.ShowDialog() == DialogResult.OK)
                                MyKasaView = AvukatPro.Services.Implementations.DosyaService.GetAllKasa();
                        }
                        break;
                    case "Bu Kaydýn Dosyasýný Aç":
                        if (e.Item.Tag != null)
                        {
                            //Av001TdiBilKasaEntity kasa =
                            //    e.Item.Tag as Av001TdiBilKasaEntity;
                            if (mainView.GetFocusedRowCellValue("Id") != null)
                            {
                                List<RMasrafAvansDetayli2Entity> masrafDetay = AvukatPro.Services.Implementations.MasrafAvansService.GetMasrafAvansViewByDetayId((int)mainView.GetFocusedRowCellValue("Id"));
                                if (masrafDetay.Count > 0)
                                    TakibeGonder(masrafDetay[0].KayitId.Value, (AvukatProLib.Extras.Modul)masrafDetay[0].ModulId.Value);
                            }
                            else
                                XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Bu Kaydýn Belgesini Yazdýr":
                        break;
                }
            }

            #endregion

            #region Serbest Meslek Makbuzu

            if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
            {
                switch (e.Item.Caption)
                {
                    case "Düzenle":
                        List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                        CompInfo cmpNfo = cmpNfoList[0];
                        if (cmpNfo.DegistirmeSilmeSifresiAktif)
                        {
                            frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(4);
                            frm.ShowDialog();
                            if (!frm.Onaylandi)
                                return;
                        }

                        AvukatProLib2.Entities.AV001_TDI_BIL_FATURA data = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                        TList<AvukatProLib2.Entities.AV001_TDI_BIL_FATURA_DETAY> data2 = DataRepository.AV001_TDI_BIL_FATURA_DETAYProvider.GetByFATURA_ID((int)mainView.GetFocusedRowCellValue("Id"));
                        TList<AvukatProLib2.Entities.AV001_TDI_BIL_GORUSME> data3 = DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByFATURA_IDFromNN_FATURA_GORUSME((int)mainView.GetFocusedRowCellValue("Id"));

                        TList<AvukatProLib2.Entities.AV001_TDI_BIL_IS> data4 = DataRepository.AV001_TDI_BIL_ISProvider.GetByFATURA_IDFromNN_FATURA_IS((int)mainView.GetFocusedRowCellValue("Id"));

                        TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE> data5 = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByFATURA_IDFromNN_FATURA_BELGE((int)mainView.GetFocusedRowCellValue("Id"));

                        data.AV001_TDI_BIL_FATURA_DETAYCollection = data2;
                        data.AV001_TDI_BIL_GORUSMECollection_From_NN_FATURA_GORUSME = data3;
                        data.AV001_TDI_BIL_ISCollection_From_NN_FATURA_IS = data4;
                        data.AV001_TDIE_BIL_BELGECollection_From_NN_FATURA_BELGE = data5;

                        AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava();
                        //frmMeslekMakbuzu.MdiParent = null;
                        frmMeslekMakbuzu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmMeslekMakbuzu.AddNewList = new TList<AvukatProLib2.Entities.AV001_TDI_BIL_FATURA>();
                        frmMeslekMakbuzu.AddNewList.Add(data);
                        frmMeslekMakbuzu.IsModul = false;
                        frmMeslekMakbuzu.FormClosed += frmMeslekMakbuzu_FormClosed;
                        frmMeslekMakbuzu.Show();
                        break;
                    case "SMM Giriþi Kaydet":
                        AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu1 = new AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava();
                        //frmMeslekMakbuzu.MdiParent = null;
                        frmMeslekMakbuzu1.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmMeslekMakbuzu1.IsModul = true;
                        frmMeslekMakbuzu1.FormClosed += frmMeslekMakbuzu_FormClosed;
                        frmMeslekMakbuzu1.Show();
                        break;
                    case "SMM Kaydýný Sil":
                        if (e.Item.Tag != null)
                        {
                            //RBilFaturaModulEntity masraf = e.Item.Tag as RBilFaturaModulEntity;
                            frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_FATURA", "ID = " + (int)mainView.GetFocusedRowCellValue("Id"));
                            if (kayitSil.ShowDialog() == DialogResult.OK)
                            {
                                mainView.DeleteRow(mainView.FocusedRowHandle);
                                //MyFaturaView = AvukatPro.Services.Implementations.DosyaService.GetAllFatura();
                            }
                        }
                        break;
                    case "Bu Kaydýn Dosyasýný Aç":
                        if (e.Item.Tag != null)
                        {
                            //RBilFaturaModulEntity personel = e.Item.Tag as RBilFaturaModulEntity;
                            int KayitId = (int)mainView.GetFocusedRowCellValue("FoyId");
                            AvukatProLib.Extras.Modul modu = new AvukatProLib.Extras.Modul();
                            if (Convert.ToInt32(mainView.GetFocusedRowCellValue("FaturaHedefTip")) > 0)
                            {
                                switch (Convert.ToInt32(mainView.GetFocusedRowCellValue("FaturaHedefTip")))
                                {
                                    case 1:
                                        modu = AvukatProLib.Extras.Modul.Icra;
                                        break;
                                    case 2:
                                        modu = AvukatProLib.Extras.Modul.Dava;
                                        break;
                                    case 3:
                                        modu = AvukatProLib.Extras.Modul.Sorusturma;
                                        break;
                                    case 4:
                                        modu = AvukatProLib.Extras.Modul.Sozlesme;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (KayitId > 0)
                                TakibeGonder(KayitId, modu);
                            else
                                XtraMessageBox.Show("Bu Kayda Ýliþkin Bir Takip(Dosya) Kaydý Bulunamamýþtýr..", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Bu Kaydýn Klasörünü Aç":
                        if (e.Item.Tag != null)
                        {
                            RBilFaturaModulEntity personel = e.Item.Tag as RBilFaturaModulEntity;
                            int KayitId = 0;
                            AvukatProLib.Extras.Modul modu = new AvukatProLib.Extras.Modul();
                            if (personel.FaturaHedefTip > 0)
                            {
                                switch (personel.FaturaHedefTip)
                                {
                                    case 1:
                                        modu = AvukatProLib.Extras.Modul.Icra;
                                        break;
                                    case 2:
                                        modu = AvukatProLib.Extras.Modul.Dava;
                                        break;
                                    case 3:
                                        modu = AvukatProLib.Extras.Modul.Sorusturma;
                                        break;
                                    case 4:
                                        modu = AvukatProLib.Extras.Modul.Sozlesme;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            KlasorAc(KayitId, modu, 0);
                        }
                        break;
                    case "Bu Kaydýn Belgesini Yazdýr":
                        break;
                }
            }

            #endregion

            if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI" || gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
            {
                if (e.Item.Caption == "Düzenle")
                    MessageBox.Show("Bu kaydýn düzenlemesini bu ekrandan yapamazsýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KlasorAc(int? KayitId, AvukatProLib.Extras.Modul? tip, int ID)
        {
            if (KayitId.HasValue && KayitId.Value > 0)
            {
                AvukatProLib.Arama.AvpDataContext dt =
                    new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                switch (tip)
                {
                    case AvukatProLib.Extras.Modul.Icra:
                        var kayit = dt.AV001_TI_BIL_FOYs.Where(vi => vi.ID == KayitId.Value).ToList();
                        if (kayit.Count > 0)
                        {
                            TList<AV001_TDIE_BIL_PROJE_ICRA_FOY> icra =
                                DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(kayit[0].ID);
                            if (icra.Count > 0)
                            {
                                AV001_TDIE_BIL_PROJE proj =
                                    DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(icra[0].PROJE_ID);
                                TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                seciliKayitler.Add(proj);
                                AdimAdimDavaKaydi.Forms.frmKlasorYeni kg = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
                                //kg.MdiParent = null;
                                kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                kg.Show(seciliKayitler);
                            }
                            else
                            {
                                XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                                return;
                            }
                        }
                        break;
                    case AvukatProLib.Extras.Modul.Dava:
                        var kayit2 = dt.AV001_TD_BIL_FOYs.Where(vi => vi.ID == KayitId.Value).ToList();
                        if (kayit2.Count > 0)
                        {
                            TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> dava =
                                DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(kayit2[0].ID);
                            if (dava.Count > 0)
                            {
                                AV001_TDIE_BIL_PROJE proj =
                                    DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(dava[0].PROJE_ID);
                                TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                seciliKayitler.Add(proj);
                                AdimAdimDavaKaydi.Forms.frmKlasorYeni kg = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
                                //kg.MdiParent = null;
                                kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                kg.Show(seciliKayitler);
                            }
                            else
                            {
                                XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                                return;
                            }
                        }
                        break;
                    case AvukatProLib.Extras.Modul.Sorusturma:
                        var kayit3 = dt.AV001_TD_BIL_HAZIRLIKs.Where(vi => vi.ID == KayitId.Value).ToList();
                        if (kayit3.Count > 0)
                        {
                            TList<AV001_TDIE_BIL_PROJE_HAZIRLIK> sorusturma =
                                DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(kayit3[0].ID);
                            if (sorusturma.Count > 0)
                            {
                                AV001_TDIE_BIL_PROJE proj =
                                    DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(sorusturma[0].PROJE_ID);
                                TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                seciliKayitler.Add(proj);
                                AdimAdimDavaKaydi.Forms.frmKlasorYeni kg = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
                                //kg.MdiParent = null;
                                kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                kg.Show(seciliKayitler);
                            }
                            else
                            {
                                XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                                return;
                            }
                        }
                        break;
                    case AvukatProLib.Extras.Modul.Sozlesme:
                        var kayit4 = dt.AV001_TDI_BIL_SOZLESMEs.Where(vi => vi.ID == KayitId.Value).ToList();
                        if (kayit4.Count > 0)
                        {
                            TList<AV001_TDIE_BIL_PROJE_SOZLESME> sozlesme =
                                DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetBySOZLESME_ID(kayit4[0].ID);
                            if (sozlesme.Count > 0)
                            {
                                AV001_TDIE_BIL_PROJE proj =
                                    DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(sozlesme[0].PROJE_ID);
                                TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                seciliKayitler.Add(proj);
                                AdimAdimDavaKaydi.Forms.frmKlasorYeni kg = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
                                // kg.MdiParent = null;
                                kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                kg.Show(seciliKayitler);
                            }
                            else
                            {
                                XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                                return;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (ID > 0)
                {
                    if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                    {
                        TList<AV001_TDIE_BIL_PROJE_MASRAF_AVANS> masraf =
                            DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.GetByMASRAF_AVANS_ID(ID);
                        if (masraf.Count > 0)
                        {
                            AV001_TDIE_BIL_PROJE proj = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(ID);
                            TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                            seciliKayitler.Add(proj);
                            AdimAdimDavaKaydi.Forms.frmKlasorYeni kg = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();
                            //kg.MdiParent = null;
                            kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            kg.Show(seciliKayitler);
                        }
                        else
                        {
                            XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                            return;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydý Bulunmamaktadýr", "Uyarý");
                    return;
                }
            }
        }

        public void TakibeGonder(int KayitId, AvukatProLib.Extras.Modul tip)
        {
            switch (tip)
            {
                case AvukatProLib.Extras.Modul.Icra:
                    AvukatProLib2.Entities.AV001_TI_BIL_FOY foy =
                        DataRepository.AV001_TI_BIL_FOYProvider.GetByID(KayitId);
                    TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY> seciliIKayitler =
                        new TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY>();
                    seciliIKayitler.Add(foy);
                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmicraTakip = new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                    frmicraTakip.Show(seciliIKayitler);
                    break;
                case AvukatProLib.Extras.Modul.Dava:
                    AvukatProLib2.Entities.AV001_TD_BIL_FOY foyd =
                        DataRepository.AV001_TD_BIL_FOYProvider.GetByID(KayitId);
                    TList<AvukatProLib2.Entities.AV001_TD_BIL_FOY> seciliDKayitler =
                        new TList<AvukatProLib2.Entities.AV001_TD_BIL_FOY>();
                    seciliDKayitler.Add(foyd);
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmdavaTakip = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                    frmdavaTakip.Show(seciliDKayitler);
                    break;
                case AvukatProLib.Extras.Modul.Sorusturma:
                    AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK foyh =
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(KayitId);
                    TList<AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK> seciliHKayitler =
                        new TList<AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK>();
                    seciliHKayitler.Add(foyh);
                    AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmhazirlikTakip = new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                    frmhazirlikTakip.Show(seciliHKayitler);
                    break;
                case AvukatProLib.Extras.Modul.Sozlesme:
                    AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME foyS =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(KayitId);
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip frmhsozlesmeTakip = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip();
                    frmhsozlesmeTakip.Show(foyS.ID);
                    break;
                default:
                    break;
            }
        }

        private void gcGenel_DataSourceChanged(object sender, EventArgs e)
        {
            if (gcGenel != null) MyDataSource = gcGenel.DataSource;
            compGridDovizSummary1.Refresh();

            mainView.FormatConditions.Clear();

            string _path = String.Format("{0}\\layouts\\{1}\\", Application.StartupPath, gcGenel.UniqueId);
            string filePath = String.Format("{0}{1}.yyl", _path, mainView.Name);
            string stylePath = String.Format("{0}{1}.yys", _path, mainView.Name);
            if (System.IO.File.Exists(filePath))
                mainView.RestoreLayoutFromXml(filePath);
            if (System.IO.File.Exists(stylePath))
            {
                System.Xml.Serialization.XmlSerializer xm = new System.Xml.Serialization.XmlSerializer(typeof(GridAyar));
                System.IO.FileStream fs = System.IO.File.OpenRead(stylePath);
                GridAyar ayar = (GridAyar)xm.Deserialize(fs);

                if (ayar != null)
                    if (mainView is DevExpress.XtraGrid.Views.Grid.GridView)
                        initGridStyleCon((DevExpress.XtraGrid.Views.Grid.GridView)mainView, ayar);
                    else
                        initGridStyleCon(mainView, ayar);
            }


        }

        private void initGridStyleCon(GridView gv, GridAyar ayarVer)
        {
            foreach (Bilgi bilgi in ayarVer.StyleConditions)
            {
                mainView.FormatConditions.Add(frmBicimlendirme.ConvertBilgiToSFC(bilgi, gv, false));
            }
            if (!String.IsNullOrEmpty(ayarVer.MyCustomStyle))
                frmXGridStyleChooser.xs.LoadScheme(ayarVer.MyCustomStyle, gv);
        }

        public static TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> GetSelectedFoy(List<RMasrafAvansDetayli2Entity> masraflar)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> seciliMasrafDetaylari = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
            foreach (RMasrafAvansDetayli2Entity masraf in masraflar)
            {
                //var obj22 = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)masraf.Id);
                if (masraf.IsSelected)
                {
                    //DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(obj22, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                    seciliMasrafDetaylari.Add(DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByID(masraf.MasrafAvansDetayId));
                }
            }
            return seciliMasrafDetaylari;
        }

        private void gridMasrafAvans_ButtonEditorClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            gcGenel.MainView.CloseEditor();
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detaylar = GetSelectedFoy((gcGenel.DataSource as List<RMasrafAvansDetayli2Entity>));
            foreach (var item in detaylar)
            {
                if (item.BIRIM_FIYAT < 0)
                    item.BIRIM_FIYAT *= -1;
                if (item.TOPLAM_TUTAR < 0)
                    item.TOPLAM_TUTAR *= -1;
            }
            Editor.Degiskenler.Util.MasrafMakbuzu.MasrafMakbuzuGetir(detaylar);
            foreach (var item in detaylar)
            {
                if (item.BIRIM_FIYAT > 0 && item.BORC_ALACAK_ID == 2)
                    item.BIRIM_FIYAT *= -1;
                if (item.TOPLAM_TUTAR > 0 && item.BORC_ALACAK_ID == 2)
                    item.TOPLAM_TUTAR *= -1;
            }
        }

        private void gridView2_CustomSummaryExists(object sender, DevExpress.Data.CustomSummaryExistEventArgs e)
        {
            //aykut hýzlandýrma 25.01.2013
            //if (e.Item is DevExpress.XtraGrid.GridSummaryItem)
            //{
            //    DevExpress.XtraGrid.GridSummaryItem item = e.Item as DevExpress.XtraGrid.GridSummaryItem;

            //    if (gcGenel.DataSource != null && item != null
            //        && gcGenel.DataSource.GetType().GetGenericArguments()[0].GetProperty(item.FieldName) != null
            //        && gcGenel.DataSource.GetType().GetGenericArguments()[0].GetProperty(item.FieldName).PropertyType.FullName.Contains("Decimal"))
            //    {
            //        item.DisplayFormat = "{0:C2}";
            //    }
            //}
        }

        #region Events

        public event EventHandler<EventArgs> SaveButtonEnable;
        public event EventHandler<EventArgs> SaveButtonDisable;

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            SaveButtonEnable(this, new EventArgs());
        }

        private void ucMuhasebeGenel_SaveButtonDisable(object sender, EventArgs e)
        {
            SaveStatus = false;
        }

        private void ucMuhasebeGenel_SaveButtonEnable(object sender, EventArgs e)
        {
            SaveStatus = true;
        }

        #endregion

        #region Methots

        public void Save()
        {
            Type type = gcGenel.DataSource.GetType();

            if (type.FullName.Contains(typeof(AV001_TDI_BIL_MASRAF_AVANS).FullName))
            {
                MessageBox.Show("Masraf Avanslar Kaydedilecek");
            }
            else if (type.FullName.Contains(typeof(AvukatProLib2.Entities.AV001_TDI_BIL_KASA).FullName))
            {
                MessageBox.Show("Kasa Kaydedilecek");
            }
            else if (type.FullName.Contains(typeof(AvukatProLib2.Entities.AV001_TDI_BIL_FOY_MUHASEBE_DETAY).FullName))
            {
                MessageBox.Show("Muhasebe Detay Kaydedilecek");
            }

            SaveButtonDisable(this, new EventArgs());
        }

        private bool SaveControler()
        {
            bool kontrol = true;
            if (SaveStatus)
            {
                kontrol = false;
                DialogResult dr = MessageBox.Show("Deðiþiklikler Var Kaydetmek Ýstermisiniz", "Dikkat", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                {
                    Save();
                    kontrol = true;
                }
                else if (dr == DialogResult.No)
                {
                    kontrol = true;
                }
                else if (dr == DialogResult.Cancel)
                {
                    kontrol = false;
                }
            }
            return kontrol;
        }

        private void gcGenel_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "Editor")
                gridMasrafAvans_ButtonEditorClick(sender, e);

            if (e.Button.Tag.ToString() == "yeniKayit")
            {
                object dataSource = gcGenel.DataSource;
                if (dataSource != null && !(MyDavaFoy != null || MyIcraFoy != null || MyHazirlikFoy != null || MySozlesmeFoy != null))
                {
                    if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                    {
                        IcraTakipForms.frmMasrafAvansKayitHizli masraf = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                        masraf.StartPosition = FormStartPosition.CenterParent;

                        if (string.IsNullOrEmpty(ModuleName))
                            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
                        else
                            masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
                        masraf.FormClosed += masraf_FormClosed;
                        if (MyIcraFoy != null)
                        { masraf.Show(MyIcraFoy); }
                        else if (MyDavaFoy != null)
                        { masraf.Show(MyDavaFoy); }
                        else if (MyHazirlikFoy != null)
                        { masraf.Show(MyHazirlikFoy); }
                        else if (MySozlesmeFoy != null)
                        { masraf.Show(MySozlesmeFoy); }
                        else
                            masraf.Show();
                    }

                    if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
                    {
                        AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir =
                            new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                        frmMuhasebeGir.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmMuhasebeGir.FormClosed += muhasebe_FormClosed;
                        frmMuhasebeGir.Show();
                    }
                    if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
                    {
                        AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava();
                        frmMeslekMakbuzu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmMeslekMakbuzu.IsModul = true;
                        frmMeslekMakbuzu.FormClosed += frmMeslekMakbuzu_FormClosed;
                        frmMeslekMakbuzu.Show();
                    }
                    if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
                    {
                        Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
                        kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        kg.FormClosed += kg_FormClosed;
                        kg.Show();
                    }
                    if (gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY")
                    {
                        IcraTakipForms.frmMasrafAvansKayitHizli masraf = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                        masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
                        masraf.FormClosed += masraf_FormClosed;
                        masraf.Show();
                    }
                }
                else if (MyDavaFoy != null || MyIcraFoy != null || MyHazirlikFoy != null || MySozlesmeFoy != null)
                {
                    IcraTakipForms.frmMasrafAvansKayitHizli masraf = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                    masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    if (string.IsNullOrEmpty(ModuleName))
                        masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkraniDisinda;
                    else
                        masraf.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;
                    masraf.FormClosed += masraf_FormClosed;
                    //masraf.Duzenleme = true;
                    //masraf.ModuleGoreLookUpDoldur(true);
                    //masraf.DefaultAlanlariDoldur(new AV001_TDI_BIL_MASRAF_AVANS());
                    masraf.txtReferansNo.Text = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
                    //masraf.lueDosya.Enabled = false;
                    //masraf.lueModul.Enabled = false;
                    if (MyIcraFoy != null)
                    {
                        masraf.SelectedDosya = MyIcraFoy.ID;
                        masraf.Module = 1;
                        masraf.MyIcraFoy = MyIcraFoy;
                        masraf.lueModul.EditValue = 1;
                        masraf.lueModul_EditValueChanged(sender, e);
                        masraf.lueDosya.EditValue = MyIcraFoy.ID;
                        masraf.lueDosya_EditValueChanged(sender, e);
                        masraf.Show(MyIcraFoy);
                    }
                    else if (MyDavaFoy != null)
                    {
                        masraf.SelectedDosya = MyDavaFoy.ID;
                        masraf.Module = 2;
                        masraf.MyDavaFoy = MyDavaFoy;
                        masraf.lueModul.EditValue = 2;
                        masraf.lueModul_EditValueChanged(sender, e);
                        masraf.lueDosya.EditValue = MyDavaFoy.ID;
                        masraf.lueDosya_EditValueChanged(sender, e);
                        masraf.Show(MyDavaFoy);
                    }
                    else if (MyHazirlikFoy != null)
                    {
                        masraf.SelectedDosya = MyHazirlikFoy.ID;
                        masraf.Module = 3;
                        masraf.MyHazirlikFoy = MyHazirlikFoy;
                        masraf.lueModul.EditValue = 3;
                        masraf.lueModul_EditValueChanged(sender, e);
                        masraf.lueDosya.EditValue = MyHazirlikFoy.ID;
                        masraf.lueDosya_EditValueChanged(sender, e);
                        masraf.Show(MyHazirlikFoy);
                    }
                    else if (MySozlesmeFoy != null)
                    {
                        masraf.SelectedDosya = MySozlesmeFoy.ID;
                        masraf.Module = 5;
                        masraf.MySozlesmeFoy = MySozlesmeFoy;
                        masraf.lueModul.EditValue = 5;
                        masraf.lueModul_EditValueChanged(sender, e);
                        masraf.lueDosya.EditValue = MySozlesmeFoy.ID;
                        masraf.lueDosya_EditValueChanged(sender, e);
                        masraf.Show(MySozlesmeFoy);
                    }
                }
                else
                    XtraMessageBox.Show("Kayýt Ekleyebilmek Ýçin Lütfen Önce Sorgulama Butonuna Basýnýz");
            }
            if (e.Button.Tag.ToString() == "kolayKayit")
            {
                if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                {
                    AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMasrafKaydet = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                    //frmMasrafKaydet.KayitTamamlandi += new EventHandler<EventArgs>(frmMasrafKaydet_KayitTamamlandi);
                    frmMasrafKaydet.Show();
                    // frmMasrafKaydet.FormClosed += new FormClosedEventHandler(frmMasrafKaydet_FormClosed);
                }
            }

            if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI" || gcGenel.Tag.ToString() == "AvukatProLib.Arama.AV001_TDI_BIL_CARI_HESAP_DETAY" || gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
                {
                    MessageBox.Show("Bu kaydýn düzenlemesini bu ekrandan yapamazsýnýz.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                CompInfo cmpNfo = cmpNfoList[0];
                if (cmpNfo.DegistirmeSilmeSifresiAktif)
                {
                    frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(4);
                    frm.ShowDialog();
                    if (!frm.Onaylandi)
                        return;
                }
                //if (MyDavaFoy != null && MyIcraFoy = null && MyHazirlikFoy != null && MySozlesmeFoy != null)
                //{
                //}
                //else
                {
                    object dataSource = gcGenel.DataSource;
                    if (mainView.FocusedRowHandle > -1)
                    {
                        if (gcGenel.Tag.ToString() == "R_MASRAF_AVANS_DETAYLI2")
                        {
                            AV001_TDI_BIL_MASRAF_AVANS data = null;
                            if (MyDavaFoy == null && MyIcraFoy == null && MyHazirlikFoy == null && MySozlesmeFoy == null)
                                data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            else
                            {
                                data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            }
                            //Forms.frmMasrafAvansMini masraf = new AdimAdimDavaKaydi.Forms.frmMasrafAvansMini();
                            IcraTakipForms.frmMasrafAvansKayitHizli masraf = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                            masraf.Duzenleme = true;

                            DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(data, false, DeepLoadType.IncludeChildren, typeof(AvukatProLib2.Entities.AV001_TI_BIL_FOY), typeof(AvukatProLib2.Entities.AV001_TD_BIL_FOY), typeof(AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK), typeof(TList<AvukatProLib2.Entities.AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                            if (data.ICRA_FOY_ID != null)
                                masraf.MyIcraFoy = data.ICRA_FOY_IDSource;
                            else if (data.DAVA_FOY_ID != null)
                                masraf.MyDavaFoy = data.DAVA_FOY_IDSource;
                            else if (data.HAZIRLIK_ID != null)
                                masraf.MyHazirlikFoy = data.HAZIRLIK_IDSource;

                            //masraf.MdiParent = null;
                            masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            
                            

                            masraf.MyDataSource = data;
                            //aykut hýzlandýrma 25.01.2013
                            //masraf.DefaultDetail = GetSelectedDetail((RMasrafAvansDetayli2Entity)mainView.GetFocusedRow(), data);
                            masraf.DefaultDetail = GetSelectedDetail(data);
                            masraf.FormClosed += masraf_FormClosed;
                            if (data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID != null)
                                masraf.DefaultMuvekkil = data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection[0].MUVEKKIL_CARI_ID.Value;

                            masraf.Show();
                            masraf.lueModul.EditValue = 1;
                            masraf.lueDosya.EditValue = data.ICRA_FOY_IDSource.ID;
                        }
                        if (gcGenel.Tag.ToString() == "R_FOY_MUHASEBESI_BIRLESIK_DETAYLI")
                        {
                            AV001_TDI_BIL_MASRAF_AVANS data = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris frmMuhasebeGir = new AdimAdimDavaKaydi.Muhasebe.rfrmMuhasebeGiris();
                            //frmMuhasebeGir.MdiParent = null;
                            frmMuhasebeGir.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frmMuhasebeGir.MyMasrafAvans = data;
                            frmMuhasebeGir.FormClosed += muhasebe_FormClosed;
                            frmMuhasebeGir.Show();
                        }
                        if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_FATURA")
                        {
                            AvukatProLib2.Entities.AV001_TDI_BIL_FATURA data = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            TList<AvukatProLib2.Entities.AV001_TDI_BIL_FATURA_DETAY> data2 = DataRepository.AV001_TDI_BIL_FATURA_DETAYProvider.GetByFATURA_ID((int)mainView.GetFocusedRowCellValue("Id"));
                            TList<AvukatProLib2.Entities.AV001_TDI_BIL_GORUSME> data3 = DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByFATURA_IDFromNN_FATURA_GORUSME((int)mainView.GetFocusedRowCellValue("Id"));

                            TList<AvukatProLib2.Entities.AV001_TDI_BIL_IS> data4 = DataRepository.AV001_TDI_BIL_ISProvider.GetByFATURA_IDFromNN_FATURA_IS((int)mainView.GetFocusedRowCellValue("Id"));

                            TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE> data5 = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByFATURA_IDFromNN_FATURA_BELGE((int)mainView.GetFocusedRowCellValue("Id"));

                            data.AV001_TDI_BIL_FATURA_DETAYCollection = data2;
                            data.AV001_TDI_BIL_GORUSMECollection_From_NN_FATURA_GORUSME = data3;
                            data.AV001_TDI_BIL_ISCollection_From_NN_FATURA_IS = data4;
                            data.AV001_TDIE_BIL_BELGECollection_From_NN_FATURA_BELGE = data5;

                            AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new AdimAdimDavaKaydi.Forms.Dava.rFrmMeslekMakbuzuKaydetForDava();
                            //frmMeslekMakbuzu.MdiParent = null;
                            frmMeslekMakbuzu.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frmMeslekMakbuzu.AddNewList = new TList<AvukatProLib2.Entities.AV001_TDI_BIL_FATURA>();
                            frmMeslekMakbuzu.AddNewList.Add(data);
                            frmMeslekMakbuzu.IsModul = false;
                            frmMeslekMakbuzu.FormClosed += frmMeslekMakbuzu_FormClosed;
                            frmMeslekMakbuzu.Show();
                        }
                        if (gcGenel.Tag.ToString() == "AV001_TDI_BIL_KASA")
                        {
                            AvukatProLib2.Entities.AV001_TDI_BIL_KASA data =
                                DataRepository.AV001_TDI_BIL_KASAProvider.GetByID((int)mainView.GetFocusedRowCellValue("Id"));
                            Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
                            kg.YeniKayit = false;
                            kg.EklenenlerListesi.Add(data);
                            //kg.MdiParent = null;
                            kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            kg.FormClosed += kg_FormClosed;
                            kg.Show();
                        }
                    }
                }
            }
            if (e.Button.Tag.ToString().Equals("AdimAdimDavaKaydi.UserControls.AddSelection"))
            {
            }
        }

        private AV001_TDI_BIL_MASRAF_AVANS_DETAY GetSelectedDetail(AV001_TDI_BIL_MASRAF_AVANS data)
        {
            if (data != null)
            {
                if (data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection != null)
                {
                    foreach (var item in data.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                    {
                        if ((decimal)mainView.GetFocusedRowCellValue("BirimFiyat") == item.BIRIM_FIYAT)
                        {
                            if ((int)mainView.GetFocusedRowCellValue("BirimFiyatDovizId") == item.BIRIM_FIYAT_DOVIZ_ID)
                            {
                                if ((int)mainView.GetFocusedRowCellValue("HareketAltKategoriId") == item.HAREKET_ALT_KATEGORI_ID)
                                {
                                    if ((int)mainView.GetFocusedRowCellValue("HareketAnaKategoriId") == item.HAREKET_ANA_KATEGORI_ID)
                                    {
                                        if ((int)mainView.GetFocusedRowCellValue("Adet") == item.ADET)
                                        {
                                            if ((bool)mainView.GetFocusedRowCellValue("Incelendi") == item.INCELENDI)
                                            {
                                                if ((DateTime)mainView.GetFocusedRowCellValue("Tarih") == item.TARIH)
                                                    return item;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void muhasebe_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyFoyMuhasebeBirlesikDetayli = AvukatPro.Services.Implementations.MuhasebeService.GetAllMuhasebeBirlesikDetayli();
        }

        private void frmMeslekMakbuzu_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyFaturaView = AvukatPro.Services.Implementations.DosyaService.GetAllFatura();
        }

        private void kg_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyKasaView = AvukatPro.Services.Implementations.DosyaService.GetAllKasa();
        }

        private void masraf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyDavaFoy != null || MyIcraFoy != null || MyHazirlikFoy != null || MySozlesmeFoy != null)
            {
                //aykut hýzlandýrma 25.01.2013
                //List<RMasrafAvansDetayli2Entity> sorgu = new List<RMasrafAvansDetayli2Entity>();
                DataTable sorgu = new DataTable();
                if (MyIcraFoy != null)
                    sorgu = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByIcraFoyId(MyIcraFoy.ID);
                else if (MyDavaFoy != null)
                    sorgu = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByDavaFoyId(MyDavaFoy.ID);
                else if (MyHazirlikFoy != null)
                    sorgu = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafBySorusturmaFoyId(MyHazirlikFoy.ID);
                else if (MySozlesmeFoy != null)
                    sorgu = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafBySozlesmeFoyId(MySozlesmeFoy.ID);

                MyMasrafAvansDetayli = sorgu;
            }

            else
                MyMasrafAvansDetayli = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasraf();
        }

        #endregion

        private void hidePanelTemizle()
        {
            BelgeIds = null;
            btnProgram.Enabled = false;
            gcKasaHesap.Visible = false;
            gcMuhatapHesap.Visible = false;
            gcKiymetliEvrak.Visible = false;
            gcKiymetliEvrakTaraf.Visible = false;
            ucBelgeOnizleme1.Visible = false;
        }

        private void belgeyiOnlizle(Av001TdieBilBelgeEntity belge, int index)
        {
            if (belge != null && belge.Id != 0)
            {
                string file = belge.DosyaAdi;
                string[] exts = file.Split('.');

                if (exts.Length <= 0)
                {
                    return;
                }

                string ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
                byte[] data = belge.Icerik;

                if (file == string.Empty && data == null)
                {
                    return;
                }

                if (data == null)
                {
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.FileStream fss = new System.IO.FileStream(file, System.IO.FileMode.Open);

                        byte[] veri = new byte[fss.Length];
                        fss.Read(veri, 0, veri.Length);
                        belge.Icerik = veri;
                        data = belge.Icerik;
                        fss.Close();
                    }
                }
                ucBelgeOnizleme1.ViewFile(data, belge.Id, belge.KontrolVersiyon, ext);
                dnBelge.Tag = belge.Id;
                BelgeIndex = index;

            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            Av001TdieBilBelgeEntity belge = AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]);
            if (belge != null && belge.Icerik != null)
            {
                string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DokumanUzanti;
                System.IO.FileStream fs = new System.IO.FileStream(bad, System.IO.FileMode.Create);
                fs.Write(belge.Icerik.ToArray(), 0, belge.Icerik.Length);
                fs.Close();
                fs.Dispose();
                Tools.OpenProgram(bad);
            }
            else
                MessageBox.Show("Belge Ýçeriði Bulunamadý", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "first")
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.First()), 0);

            else if (e.Button.Tag == "last")
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.Last()), BelgeIds.Count - 1);

            else if (e.Button.Tag == "next")
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex + 1]), BelgeIndex + 1);

            else if (e.Button.Tag == "prev")
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex - 1]), BelgeIndex - 1);
        }

        private void mainView_CustomDrawRowPreview(object sender, RowObjectCustomDrawEventArgs e)
        {

        }

        private void mainView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            //if (mainView.GetRowCellValue(e.RowHandle, "Borc_Alacak").ToString() == "B")
            //    e.Appearance.ForeColor = Color.Red;
        }

        private void mainView_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                if (mainView.GetRowCellValue(e.RowHandle, "BorcAlacakId").ToString() == "1")
                    e.Appearance.ForeColor = Color.Green;
                else
                    e.Appearance.ForeColor = Color.Red;
            }
            catch { ;}
        }

        private void tabPPivot_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabCMuhasebe_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabCMuhasebe_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //aykut hýzlandýrma 28.01.2013 pivot aç kapat
            //if (tabCMuhasebe.SelectedTabPageIndex == 1)
            //{
            //    if (tabPPivot.Controls.Count == 0)
            //    {
            //        ucPivotChart1.Dock = DockStyle.Fill;
            //        tabPPivot.Controls.Add(ucPivotChart1);
            //    }
            //}
        }
    }
}