using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AvukatPro.Model.EntityClasses;
using AvukatProLib2.Entities;
using System.Data;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucOdemeGirisView : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucOdemeGirisView()
        {
            InitializeComponent();
        }

        public DataTable MyDataSource
        {
            get
            {
                return exOdemeBilgileri.DataSource as DataTable;
            }
            set { exOdemeBilgileri.DataSource = value; }
        }

        private void exOdemeBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueKalanDovizID);
                AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueOdemeMiktarDovizID);
                AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueRiskMiktariDovizID);
                BelgeUtil.Inits.AlacakNedenByFoy(lueAlacakNedeni);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
                AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);
                BelgeUtil.Inits.SubeKodGetir(rlueSubeKodID);
                AvukatPro.Services.Implementations.DevExpressService.FormTipiDoldur(lueFormTipiID);
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
                BelgeUtil.Inits.ParaBicimiAyarla(rluePara);

                BelgeUtil.Inits.KiymetliEvrakTipiGetir(lueKiymetliEvrakBilgileri);
                compGridDovizSummary1.MyGridView = gvOdemeler;


                try
                {
                    gvOdemeler.Columns["OdemeMiktarDovizId"].SummaryItem.DisplayFormat = "";
                    gvOdemeler.Columns["OdemeMiktarDovizId"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;

                    gvOdemeler.Columns["KalanDovizId"].SummaryItem.DisplayFormat = "";
                    gvOdemeler.Columns["KalanDovizId"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;

                    gvOdemeler.Columns["RiskMiktariDovizId"].SummaryItem.DisplayFormat = "";
                    gvOdemeler.Columns["RiskMiktariDovizId"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                }
                catch { ;}

                gvOdemeler.GroupSummary.Clear();
                foreach (GridColumn item in gvOdemeler.Columns)
                {
                    try
                    {
                        if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                            gvOdemeler.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                    }
                    catch { ;}
                }
            }
        }

        private void exOdemeBilgileri_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                IcraTakipForms.rFrmTarafOdeme IcraOdemeKayit = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();
                //IcraOdemeKayit.MdiParent = null;
                IcraOdemeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                IcraOdemeKayit.IsModul = true;
                IcraOdemeKayit.MyGelisme = new AV001_TI_BIL_FOY_TARAF_GELISME();
                IcraOdemeKayit.Show();
            }
        }
    }
}