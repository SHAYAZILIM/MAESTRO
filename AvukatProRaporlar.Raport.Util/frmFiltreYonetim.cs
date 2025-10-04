using AvukatProLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using RaporDataSource.TableDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util
{
    public partial class frmFiltreYonetim : DevExpress.XtraEditors.XtraForm
    {
        public frmFiltreYonetim()
        {
            InitializeComponent();
            this.simpleButton1.Click += simpleButton1_Click;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private object myFilter;

        //TODO : sonra yapýlacak unutulmasýn
        private List<AV001_CS_BIL_GRID_FILTRE> myFilters;

        private ExtendedGridControl myGridControl = null;

        public void Show(ExtendedGridControl grid, string UniqueId)
        {
            this.myGridControl = grid;
            Connection conn = new Connection();
            conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
            DBDataContext db = new DBDataContext(conn.MyConnection);

            // myFilter = db.AV001_CS_BIL_GRID_FILTREs;
            myFilter = db.AV001_CS_BIL_GRID_FILTREs.Where(vii => vii.GRID_EU_ID == UniqueId);
            extendedGridControl1.DataSource = myFilter;
            this.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                AV001_CS_BIL_GRID_FILTRE filtre = gridView1.GetRow(e.FocusedRowHandle) as AV001_CS_BIL_GRID_FILTRE;
                if (filtre != null)
                {
                    string[] filx = filtre.FILTRE_ICERIGI.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in filx)
                    {
                        string[] mHilk = s.Split('`');
                        if (mHilk.Length == 2)
                        {
                            foreach (BaseView view in myGridControl.Views)
                            {
                                if (view is GridView && view.Name == mHilk[0])
                                {
                                    GridView vg = (GridView)view;
                                    vg.ActiveFilterString = mHilk[1];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        //s;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AV001_CS_BIL_GRID_FILTRE filtre = new AV001_CS_BIL_GRID_FILTRE();
            filtre.FILTRE_ADI = txtFiltreAdi.Text;
            filtre.FILTRE_KATEGORI = cmbFiltreKategori.EditValue.ToString();
            filtre.GRID_EU_ID = myGridControl.UniqueId;
            filtre.KULLANICI_ID = Kimlikci.Kimlik.Bilgi.ID;
            filtre.KAYIT_TARIHI = DateTime.Now;

            foreach (BaseView view in myGridControl.Views)
            {
                if (view is GridView)
                {
                    GridView gv = (GridView)view;
                    filtre.FILTRE_ICERIGI += gv.Name + "`" + gv.ActiveFilterString + "|||";
                }
            }
            try
            {
                Connection conn = new Connection();
                conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                DBDataContext db = new DBDataContext(conn.MyConnection);

                db.AV001_CS_BIL_GRID_FILTREs.InsertOnSubmit(filtre);
                db.SubmitChanges();
                this.Close();

                myFilters = db.AV001_CS_BIL_GRID_FILTREs.ToList();

                // myFilters = myFilter as List<AV001_CS_BIL_GRID_FILTRE>;
                myFilters.Add(filtre);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
    }
}