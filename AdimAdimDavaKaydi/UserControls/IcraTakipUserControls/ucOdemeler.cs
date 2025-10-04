using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using AvukatProLib;
using AdimAdimDavaKaydi.Util;
using DevExpress.XtraBars;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucOdemeler : AvpXUserControl
    {
        private TList<AV001_TI_BIL_BORCLU_ODEME> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private List<int> dovizler = new List<int>();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        private List<ParaVeDovizId> odemeToplamlar = new List<ParaVeDovizId>();

        public ucOdemeler()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucOdemeler_Load;
        }

        public event DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler ucOdemelerValidataRow;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_ODEME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                try
                {
                    grdOdemeler.Tag = "AV001_TI_BIL_BORCLU_ODEME";
                }
                catch { ;}
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    MyDataSource = value.AV001_TI_BIL_BORCLU_ODEMECollection;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy && MyFoy != null)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;

                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
                foreach (var item in MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection)
                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                              typeof(TList<AV001_TI_BIL_ODEME_DAGILIM>));
                MyDataSource = MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                try
                {
                    InitsDoldur(false);
                    grdOdemeler.DataSource = MyDataSource;
                }
                catch
                {
                }
            }
        }

        private void customMenuItem_Click(object sender, EventArgs e)
        {
            ODEME_MIKTAR.SummaryItem.Assign(
                new DevExpress.XtraGrid.GridSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR",
                                                        "Toplam : {0:###,###,###,##0.00}", 1));
            gwOdemeler.GroupSummary.Add(
                new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_MIKTAR",
                                                             ODEME_MIKTAR, "Grup Toplamý : {0:###,###,###,##0.00}", 1));
            gwOdemeler.UpdateGroupSummary();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByICRA_FOY_ID(MyFoy.ID);
            this.MyFoy = MyFoy;
        }

        private void grdOdemeler_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (grdOdemeler.Visible)
            {
                //extendedGridControl1.Visible = true;
                grdOdemeler.Visible = false;
            }
            else
            {
                //extendedGridControl1.Visible = false;
                grdOdemeler.Visible = true;
            }
        }

        private void grdOdemeler_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "rFrmTarafOdeme")
            {
                rFrmTarafOdeme frm = new rFrmTarafOdeme();
                //InitsDoldur(true);
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

                //MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddNew();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
                frm.MyFoy = this.MyFoy;
            }
            if (e.Button.Tag.ToString() == "Sil")
            {
                DialogResult dr = XtraMessageBox.Show("Geçerli kaydý silmek istediðinizden emin misiniz?", "Sil",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                    MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Remove(
                        (AV001_TI_BIL_BORCLU_ODEME)gwOdemeler.GetFocusedRow());
            }
            if (e.Button.Tag.ToString() == "Duzenle")
            {
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                CompInfo cmpNfo = cmpNfoList[0];
                if (cmpNfo.DegistirmeSilmeSifresiAktif)
                {
                    frmOnaySifreKontrolu frmx = new frmOnaySifreKontrolu(4);
                    frmx.ShowDialog();
                    if (!frmx.Onaylandi)
                        return;
                }

                rFrmTarafOdeme frm = new rFrmTarafOdeme();
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.AddNewList = new TList<AV001_TI_BIL_BORCLU_ODEME>();
                frm.AddNewList.Add(MyDataSource[gwOdemeler.FocusedRowHandle]);
                frm.MyFoy = MyFoy;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
            }
        }

        private void grdOdemeler_ButtonEditorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME odeme = gwOdemeler.GetFocusedRow() as AV001_TI_BIL_BORCLU_ODEME;

            Editor.Degiskenler.Util.OdemeMakbuzu.OdemeMakbuzuGetir(odeme);
        }

        private void gwOdemeler_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item != null && e.Item is DevExpress.XtraGrid.GridSummaryItem &&
                (e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag is int)
            {
                //SummaryID yi alýyoruz
                int summaryID = Convert.ToInt32((e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag);
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view == null)
                    return;

                // Baþlangýç
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    switch (summaryID)
                    {
                        case 1:
                            odemeToplamlar.Clear();
                            break;

                        case 2:
                            dovizler.Clear();
                            break;
                    }
                }

                // Hesaplama
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    AV001_TI_BIL_BORCLU_ODEME odeme = view.GetRow(e.RowHandle) as AV001_TI_BIL_BORCLU_ODEME;
                    if (odeme != null)
                        switch (summaryID)
                        {
                            case 1: // YTL Cinsinden Cevirip toplanýlan yer

                                odemeToplamlar.Add(new ParaVeDovizId(odeme.ODEME_MIKTAR.Value,
                                                                     odeme.ODEME_MIKTAR_DOVIZ_ID.Value,
                                                                     odeme.ODEME_TARIHI));
                                break;

                            case 2:
                                if (
                                    !dovizler.Contains(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue
                                                           ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value
                                                           : 1))
                                    dovizler.Add(odeme.ODEME_MIKTAR_DOVIZ_ID.HasValue
                                                     ? odeme.ODEME_MIKTAR_DOVIZ_ID.Value
                                                     : 1);
                                break;
                        }
                }

                // Sonuç yazdýrma
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    switch (summaryID)
                    {
                        case 1:
                            ParaVeDovizId pDId = ParaVeDovizId.Topla(odemeToplamlar);
                            e.TotalValue = pDId.Para;
                            break;

                        case 2:
                            if (dovizler.Count > 1)
                            {
                                e.TotalValue = DovizHelper.CevirString(1); //YTL
                            }
                            else if (dovizler.Count == 1)
                            {
                                e.TotalValue = DovizHelper.CevirString(dovizler[0]);
                            }

                            break;
                    }
                }
            }
        }

        private void gwOdemeler_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary && e.HitInfo.Column != null)
            {
                if (e.HitInfo.Column.FieldName == "ODEME_MIKTAR")
                {
                    //DevExpress.Utils.Menu.DXMenuItem mi = e.Menu.Items[0];
                    foreach (DevExpress.Utils.Menu.DXMenuItem menuItem in e.Menu.Items)
                    {
                        menuItem.Enabled = true;
                    }
                    GridViewFooterMenu footerMenu = (GridViewFooterMenu)e.Menu;
                    DevExpress.Utils.Menu.DXMenuItem menuCustom = new DXMenuItem("Para Birimine Göre Toplam",
                                                                                 customMenuItem_Click,
                                                                                 Properties.Resources.money);
                    menuCustom.Enabled = true;

                    //footerMenu.
                    e.Menu.Items.RemoveAt(0);
                    e.Menu.Items.Insert(0, menuCustom);
                }
            }
        }

        private void gwOdemeler_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ucOdemelerValidataRow != null)
                ucOdemelerValidataRow(sender, e);
        }

        private void InitsDoldur(bool newItem)
        {
            if ((!initsFilled && MyDataSource.Count > 0) || newItem)
            {
                if (MyFoy != null)
                {
                    BelgeUtil.Inits.OdemeBorcluTarafByFoy(MyFoy, new[] { rLueCariIDBorclu });
                    BelgeUtil.Inits.OdemeAlacakliTarafByFoy(MyFoy, new[] { rlueCariAlacakli });
                }
                else if (MyProje != null)
                    BelgeUtil.Inits.ProjeTarafGetir(MyProje, rLueCariIDBorclu, rLueAlacakNedenTarafID);

                BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNedenID);
                BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTipID);
                BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYeriID);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTiplID);
                BelgeUtil.Inits.MahsupAltKategoriGetir(rLueAltKategoriID);
                BelgeUtil.Inits.MahsupKategoriGetir(rLueKategoriID);
                BelgeUtil.Inits.OdemeDagilimGetir(rlueDagilimTipi);
                if (MyFoy != null)
                    BelgeUtil.Inits.AlacakNedenByFoy(MyFoy, glueAlacakNeden);
                BelgeUtil.Inits.AlacakNedenKodGetir1(rLueAlacakNedenKod);

                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur(false);
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur(false);
        }

        private void ucOdemeler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            //IsLoaded = true;
            IsLoaded = true;
            try
            {
                grdOdemeler.ShowOnlyPredefinedDetails = true;
                grdOdemeler.RightClickPopup.PopupOpening += new EventHandler<AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs>(RightClickPopup_PopupOpening);
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            BarButtonItem bus2 = new BarButtonItem(e.Manager, "Ödeme Makbuzu");
            bus2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.yazdir_22x221;
            bus2.ItemClick += bus2_ItemClick;
            e.MyPopupMenu.ItemLinks.Insert(1, bus2);
        }

        void bus2_ItemClick(object sender, ItemClickEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME odeme = gwOdemeler.GetFocusedRow() as AV001_TI_BIL_BORCLU_ODEME;
            Editor.Degiskenler.Util.OdemeMakbuzu.OdemeMakbuzuGetir(odeme);
        }

    }
}