using System;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmFiltreYonetim : XtraForm
    {
        public frmFiltreYonetim()
        {
            InitializeComponent();
            simpleButton1.Click += simpleButton1_Click;
            gridView1.DoubleClick += gridView1_DoubleClick;
        }

        private ExtendedGridControl myGridControl;
        private TList<AV001_CS_BIL_GRID_FILTRE> myFilters;

        public void Show(ExtendedGridControl grid)
        {
            this.myGridControl = grid;
            myFilters = AvukatProLib2.Data.DataRepository.AV001_CS_BIL_GRID_FILTREProvider.GetByGRID_EU_ID(grid.UniqueId);
            extendedGridControl1.DataSource = myFilters;
            this.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AV001_CS_BIL_GRID_FILTRE filtre = gridView1.GetRow(gridView1.FocusedRowHandle) as AV001_CS_BIL_GRID_FILTRE;
                if (filtre != null)
                {
                    string[] filx = filtre.FILTRE_ICERIGI.Split(new[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                    //foreach (string s in filx)
                    //{
                    if (filx[0].Length > 0)
                    {
                        string[] mHilk = filx[0].Split('`');
                        if (mHilk.Length == 2)
                        {
                            foreach (BaseView view in myGridControl.Views)
                            {
                                if (view is GridView && view.Name == mHilk[0])
                                {
                                    GridView vg = (GridView)view;
                                    vg.ActiveFilterString = mHilk[1];
                                    if (filx[1].Length > 0)
                                    {
                                        foreach (DevExpress.XtraGrid.Columns.GridColumn column in vg.Columns)
                                        {
                                            column.Visible = false;
                                        }
                                        foreach (var cn in filx[1].Split('+'))
                                        {
                                            if (cn.Length > 0)
                                            {
                                                DevExpress.XtraGrid.Columns.GridColumn col = vg.Columns.ColumnByName(cn);
                                                if (col != null)
                                                    col.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AV001_CS_BIL_GRID_FILTRE filtre = new AV001_CS_BIL_GRID_FILTRE();
            filtre.FILTRE_ADI = txtFiltreAdi.Text;
            filtre.FILTRE_KATEGORI = cmbFiltreKategori.EditValue.ToString();
            filtre.GRID_EU_ID = myGridControl.UniqueId;
            filtre.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
            filtre.KAYIT_TARIHI = DateTime.Now;
            GridView gv = null;
            foreach (BaseView view in myGridControl.Views)
            {
                if (view is GridView)
                {
                    gv = (GridView)view;
                    filtre.FILTRE_ICERIGI += gv.Name + "`" + gv.ActiveFilterString + "|||";
                }
            }
            if (gv != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gv.Columns)
                {
                    if (column.Visible == true)
                        filtre.FILTRE_ICERIGI += column.Name + "+";
                }
            }
            try
            {
                TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                trans.BeginTransaction();
                AvukatProLib2.Data.DataRepository.AV001_CS_BIL_GRID_FILTREProvider.DeepSave(trans, filtre);
                trans.Commit();
                myFilters.Add(filtre);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}