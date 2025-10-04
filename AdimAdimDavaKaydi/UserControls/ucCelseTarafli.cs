using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraBars;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucCelseTarafli : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCelseTarafli()
        {
            InitializeComponent();
        }

        //AV001_TD_BIL_CELSE
        public DataTable MyDataSource
        {
            get
            {
                return (DataTable)exGridCelseTarafli.DataSource;
            }
            set
            {
                if (value != null)
                {
                    if (exGridCelseTarafli != null)
                    {
                        //if (value.Count > 0)
                        //    davaKayitGetir(value);

                        exGridCelseTarafli.Tag = "AV001_TD_BIL_CELSE";
                        exGridCelseTarafli.DataSource = value;
                        extendedGridControl1.DataSource = exGridCelseTarafli.DataSource;
                    }
                }
                exGridCelseTarafli.DataSource = value;
                extendedGridControl1.DataSource = exGridCelseTarafli.DataSource;
            }
        }

        private void ucCelseTarafli_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            //ada.DavaEdenler
            //ada.DavaEdilenler
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.IncelemeTurGetir(rLueIncelemeTur);
            //
            BelgeUtil.Inits.AdliBirimNoGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.AdliBirimGorevGetir(repositoryItemLookUpEdit3);
            BelgeUtil.Inits.perCariGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.IncelemeTurGetir(repositoryItemLookUpEdit5);

            exGridCelseTarafli.ButtonCevirClick += exGridCelseTarafli_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridCelseTarafli_ButtonCevirClick;

            exGridCelseTarafli.RightClickPopup.PopupOpening += new EventHandler<PopupOpeningEventArgs>(RightClickPopup_PopupOpening);
        }

        void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            BarButtonItem duzenle = new BarButtonItem(e.Manager, "Düzenle");
            duzenle.Tag = e.Rows;
            duzenle.Name = "Duzenle";
            duzenle.Glyph = AdimAdimDavaKaydi.Properties.Resources.dilekce;
            duzenle.ItemClick += new ItemClickEventHandler(duzenle_ItemClick);
            e.MyPopupMenu.ItemLinks.Insert(0, duzenle);

            BarButtonItem sil = new BarButtonItem(e.Manager, "Sil");
            sil.Tag = e.Rows;
            sil.Name = "KaydiSil";
            sil.Glyph = AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_delete;
            sil.ItemClick += new ItemClickEventHandler(sil_ItemClick);
            e.MyPopupMenu.ItemLinks.Insert(0, sil);
        }

        void sil_ItemClick(object sender, ItemClickEventArgs e)
        {
            AdimAdimDavaKaydi.Util.frmKayitSil kayitSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TD_BIL_CELSE", "ID = " + gridView1.GetFocusedRowCellValue("ID"), true);

            if (kayitSil.ShowDialog() == DialogResult.OK)
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        void duzenle_ItemClick(object sender, ItemClickEventArgs e)
        {
            AV001_TD_BIL_CELSE celse = DataRepository.AV001_TD_BIL_CELSEProvider.GetByID((int)gridView1.GetFocusedRowCellValue("ID"));
            AV001_TD_BIL_FOY foy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gridView1.GetFocusedRowCellValue("FOY_ID"));
            rFrmCelseKayit durusma = new rFrmCelseKayit();
            durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
            durusma.IsModul = true;            
            durusma.Show();
            durusma.c_lueDosya.EditValue = foy.ID;
            durusma.MyFoy = foy;
            durusma.MyCelse = celse;
        }

        private void exGridCelseTarafli_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridCelseTarafli.Visible)
            {
                exGridCelseTarafli.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = false;
                exGridCelseTarafli.Visible = true;
            }
        }

        private void exGridCelseTarafli_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            if (e.Button.Tag.ToString() == "FormAc")
            {
                rFrmCelseKayit durusma = new rFrmCelseKayit();
                // durusma.MdiParent = null;
                durusma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                durusma.IsModul = true;
                durusma.Show();
            }
        }
    }
}