using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraBars;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.DavaTakip;
using AvukatProLib2.Data;
using AdimAdimDavaKaydi.GirisEkran;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTaahhutBilgileriGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTaahhutBilgileriGiris()
        {
            InitializeComponent();
            exGridTaahhut.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        public DataTable MyDataSource
        {
            get
            {
                return (DataTable)exGridTaahhut.DataSource;
            }
            set
            {
                if (value == null)
                    exGridTaahhut.DataSource = value;

                exGridTaahhut.Tag = "AV001_TI_BIL_BORCLU_TAAHHUT_MASTER";
                exGridTaahhut.DataSource = value;
                extendedGridControl1.DataSource = exGridTaahhut.DataSource;
            }
        }

        private void ucTaahhutBilgileriGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.TaahhutDurumGetir(rLueTahDurum);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.GorevTipGetir(rLueGorevTip);

            BelgeUtil.Inits.FoyOzelKodGetir(rlueOzelKod1, 3, AvukatProLib.Extras.Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(rlueOzelKod2, 3, AvukatProLib.Extras.Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(rlueOzelKod4, 3, AvukatProLib.Extras.Modul.Icra);

            exGridTaahhut.ButtonCevirClick += exGridTaahhut_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridTaahhut_ButtonCevirClick;
        }

        private void exGridTaahhut_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridTaahhut.Visible)
            {
                exGridTaahhut.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridTaahhut.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridTaahhut_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;
            else if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmTaahhut TaahhutKaydi = new rFrmTaahhut();
                //TaahhutKaydi.MdiParent = null;
                TaahhutKaydi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                TaahhutKaydi.TaahhutList = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
                TaahhutKaydi.IsModul = true;
                TaahhutKaydi.Show();
            }
        }


        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            
            BarButtonItem barduz = new BarButtonItem(e.Manager, "Düzenle");
            barduz.ItemClick+=new ItemClickEventHandler(barduz_ItemClick);
            e.MyPopupMenu.ItemLinks.Add(barduz);

            BarButtonItem barsil = new BarButtonItem(e.Manager, "Sil");
            barsil.ItemClick+=new ItemClickEventHandler(barsil_ItemClick);
            e.MyPopupMenu.ItemLinks.Add(barsil);
            
            BarButtonItem baricr = new BarButtonItem(e.Manager, "İcra Dosyasını Aç");
            baricr.ItemClick += new ItemClickEventHandler(baricr_ItemClick);
            e.MyPopupMenu.ItemLinks.Add(baricr);
            

            if (gridView1.GetFocusedRowCellValue("DAVA_FOY_ID") != null)
            {
                if (gridView1.GetFocusedRowCellValue("DAVA_FOY_ID") != DBNull.Value)
                {
                    BarButtonItem bardav = new BarButtonItem(e.Manager, "Dava Dosyasını Aç");
                    bardav.ItemClick += new ItemClickEventHandler(bardav_ItemClick);
                    e.MyPopupMenu.ItemLinks.Add(bardav);
                }
            }
        }

        void bardav_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            frmDavaTakip frm = new frmDavaTakip();
            frm.Show((int)gridView1.GetFocusedRowCellValue("DAVA_FOY_ID"));
        }

        void baricr_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            _frmIcraTakip frm = new _frmIcraTakip();
            frm.Show((int)gridView1.GetFocusedRowCellValue("ICRA_FOY_ID"));
        }

        void barsil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            int ID = (int)gridView1.GetFocusedRowCellValue("ID");
            frmKayitSil kayitSil = new frmKayitSil("AV001_TI_BIL_BORCLU_TAAHHUT_MASTER", "ID=" + ID);
            if (kayitSil.ShowDialog() == DialogResult.OK && kayitSil.SilmeOnayi != DialogResult.Cancel)
            {
                ((rFrmTaahhutBilgileriGirisEkran)this.FindForm()).sbtnSorgula_Click(sender, e);
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    if ((int)gridView1.GetRowCellValue(i, "ID") == ID)
                //    {
                //        gridView1.DeleteRow(i);
                //        i = 0;
                //    }
                //}
            }
        }

        void barduz_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            rFrmTaahhut frm = new rFrmTaahhut();

            TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> list = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> ();
            list.Add(DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID")));

            frm.IsModul = true;
            frm.MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ICRA_FOY_ID"));
            frm.TaahhutList = list;
            frm.TaahhutChild = DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProvider.GetByMASTER_TAAHHUT_ID((int)gridView1.GetFocusedRowCellValue("ID"));
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);            
            frm.Show();


        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((rFrmTaahhutBilgileriGirisEkran)this.FindForm()).sbtnSorgula_Click(sender, e);
        }
    }
}