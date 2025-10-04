using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Entities;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TXTextControl;

namespace AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    public partial class ucSeciliBelgeler : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSeciliBelgeler()
        {
            InitializeComponent();
        }

        private frmEditor _parentForm;

        public frmEditor ParentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }

        public uctxEditor Document { get; set; }

        private AV001_TDIE_BIL_SABLON_RAPOR _seciliSablon;

        [Browsable(false)]
        public AV001_TDIE_BIL_SABLON_RAPOR SeciliSablon
        {
            get { return _seciliSablon; }
            set
            {
                if (value != null && !DesignMode)
                {
                    _seciliSablon = value;
                    TList<TI_KOD_FORM_TIP> lstFormlar = new AvukatProLib2.Entities.TList<TI_KOD_FORM_TIP>();

                    for (int i = 0; i < value.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection.Count; i++)
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_SECILI_BELGEProvider.DeepLoad(
                            value.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i], false,
                            AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_FORM_TIP));
                        lstFormlar.Add(value.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i].FORM_ORNEK_IDSource);
                    }

                    this.SeciliFormTipleri = lstFormlar;
                }
            }
        }

        private TList<TI_KOD_FORM_TIP> _formTipleri;

        [Browsable(false)]
        public TList<TI_KOD_FORM_TIP> SeciliFormTipleri
        {
            get { return _formTipleri; }
            set
            {
                _formTipleri = value;
                if (value != null && !DesignMode)
                {
                    this.grdBuSablonuKullananFormlar.DataSource = value;
                }
            }
        }

        private TI_KOD_FORM_TIP _seciliForm;

        [Browsable(false)]
        public TI_KOD_FORM_TIP SeciliForm
        {
            get { return _seciliForm; }
            set
            {
                _seciliForm = value;

                if (value != null && !DesignMode)
                {
                    AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.DeepLoad(value, false,
                                                                                       AvukatProLib2.Data.DeepLoadType.
                                                                                           IncludeChildren,
                                                                                       typeof(
                                                                                           TList
                                                                                           <
                                                                                           AV001_TDIE_BIL_SABLON_SECILI_BELGE
                                                                                           >));
                    TList<AV001_TDIE_BIL_SABLON_RAPOR> lstSablonlar = new TList<AV001_TDIE_BIL_SABLON_RAPOR>();
                    for (int i = 0; i < _seciliForm.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection.Count; i++)
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_SECILI_BELGEProvider.DeepLoad(
                            _seciliForm.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i], false,
                            AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDIE_BIL_SABLON_RAPOR));
                        if (_seciliForm.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i].SABLON_RAPOR_IDSource != null)
                        {
                            lstSablonlar.Add(
                                _seciliForm.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection[i].SABLON_RAPOR_IDSource);
                        }
                    }
                    FormTipiniKullananSablonlar = lstSablonlar;
                }
            }
        }

        private TList<AV001_TDIE_BIL_SABLON_RAPOR> _formTipiniKullananSablonlar;

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_SABLON_RAPOR> FormTipiniKullananSablonlar
        {
            get { return _formTipiniKullananSablonlar; }
            set
            {
                _formTipiniKullananSablonlar = value;
                if (value != null && !DesignMode)
                {
                    this.grdFormIcinSeciliSablonlar.DataSource = value;
                }
            }
        }

        private TList<AV001_TDIE_BIL_SABLON_RAPOR> _tumSablonlar;

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_SABLON_RAPOR> TumSablonlar
        {
            get { return _tumSablonlar; }
            set
            {
                _tumSablonlar = value;
                if (value != null && !DesignMode)
                {
                    this.grdTumSablonlar.DataSource = value;
                }
            }
        }

        private int _modul;

        public int Modul
        {
            get { return _modul; }
            set
            {
                _modul = value;

                if (value != null && !DesignMode)
                {
                    SetGridsFilter("MODUL_ID=" + value, grdBuSablonuKullananFormlar);
                    SetGridsFilter("MODUL_ID=" + value, grdFormIcinSeciliSablonlar);
                    SetGridsFilter("MODUL_ID=" + value, grdOtomatikSablonlar);
                    SetGridsFilter("MODUL_ID=" + value, grdTumSablonlar);
                }
            }
        }

        private void SetGridsFilter(string Filter, GridControl grd)
        {
            if (grd.MainView is GridView)
            {
                ((GridView)grd.MainView).ActiveFilterString = Filter;
            }

            if (grd.MainView is CardView)
            {
                ((CardView)grd.MainView).ActiveFilterString = Filter;
            }
        }

        private void ucSeciliBelgeler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            try
            {
                BelgeUtil.Inits.SektorKodGetir(rLueSektor);
                BelgeUtil.Inits.DilKodGetir(rLueDil);
                BelgeUtil.Inits.DavaNedenGetir(rLueDavaNeden);
                BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
                BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);
                BelgeUtil.Inits.ModulKodGetir(rLueModul);
                BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdliBirimBolum);
                BelgeUtil.Inits.SablonRaporTipGetir(rLueRaporTip);
                BelgeUtil.Inits.SablonRaporTipGetir(rLueSablonRapor);
                BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);
                BelgeUtil.Inits.FormTipiGetir(rLueFormOrnekNo);

                Surukle<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> srk =
                    new Surukle<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();

                srk.GridMyDraggerGrid = grdOtomatikSablonlar;

                Surukle<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> srk2 =
                    new Surukle<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();

                srk2.GridMyDraggerGrid = grdTumSablonlar;

                Birak
                    <AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE,
                        AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> birakilacak =
                            new Birak
                                <AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE,
                                    AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>();
                birakilacak.DragDropGrid = grdFormIcinSeciliSablonlar;

                birakilacak.DragDropConvert += birakilacak_DragDropConvert;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }


        private void birakilacak_DragDropConvert(AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR value,
                                                 ExtendedGridControl sender,
                                                 AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE valueToAdd,
                                                 out bool addToGrid, GridHitInfo ghinf)
        {
            addToGrid = false;
            AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE seciliBelge =
                new AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE();
            seciliBelge.SABLON_RAPOR_ID = value.ID;
            seciliBelge.FORM_ORNEK_ID = value.FORM_ORNEK_ID;
            value.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection.Add(seciliBelge);
            if (grdFormIcinSeciliSablonlar.DataSource == null)
            {
                grdFormIcinSeciliSablonlar.DataSource =
                    new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_SECILI_BELGE>();
            }
            ((AvukatProLib2.Entities.VList<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>)
             grdFormIcinSeciliSablonlar.DataSource).Add(
                 AdimAdimDavaKaydi.Editor.Util.EditorHelper.GetSablonRaporView(value));
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;

            object fr = null;

            if (gridView1.GetFocusedRow() != null)
            {
                fr = gridView1.GetFocusedRow();
            }

            OpenSelectedRapor((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)fr, false, false);
        }

        private void OpenSelectedRapor(AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr, bool fill, bool print)
        {
            if (DesignMode)
            {
                return;
            }

            RecordInfos ri = new RecordInfos();
            ri.Data = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(rpr.ID);
            ri.SelectedFrom = LoadFromType.FromTable;
            this.Document.SelectedStreamType = StreamType.InternalFormat;
            List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR> lstRpr = new List<AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR>();
            lstRpr.Add(rpr);
            if (ParentForm != null)
            {
                if (fill)
                {
                    for (int i = 0; i < this.ParentForm.SelectedFoys.Count; i++)
                    {
                        if (this.ParentForm.SelectedFoys[i] is AvukatProLib2.Entities.IEntity)
                        {
                            this.ParentForm.OpenAllSablon(lstRpr, this.ParentForm.SelectedFoys[i], true, print);
                        }
                    }
                }
                else
                {
                    this.ParentForm.OpenAllSablon(lstRpr, ParentForm.SelectedFoys,"");
                }
            }
            else
            {
                this.Document.OpenRecord(ri);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            object fr = null;

            if (gridView9.GetFocusedRow() != null)
            {
                fr = gridView9.GetFocusedRow();
            }

            OpenSelectedRapor((AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)fr, false, false);
        }

        private void tümSeçiliÞablonlarýAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object record = gridView1.GetRow(i);
                if (record != null)
                {
                    bool isSelected = (bool)gridView1.GetFocusedRowCellValue("IsSelected");
                    AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr =
                        (AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)record;
                    if (isSelected)
                    {
                        OpenSelectedRapor(rpr, false, false);
                    }
                }
            }
        }

        private void tümSeçiliÞablonlarýAçToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView9.RowCount; i++)
            {
                object record = gridView9.GetRow(i);
                if (record != null)
                {
                    bool isSelected = (bool)gridView1.GetFocusedRowCellValue("IsSelected");
                    AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr =
                        (AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)record;
                    if (isSelected)
                    {
                        OpenSelectedRapor(rpr, false, false);
                    }
                }
            }
        }

        private void tumunuAcVeDoldurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object record = gridView1.GetRow(i);

                if (record != null)
                {
                    bool isSelected = (bool)gridView1.GetFocusedRowCellValue("IsSelected");
                    AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr =
                        (AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)record;
                    if (isSelected)
                    {
                        OpenSelectedRapor(rpr, true, false);
                    }
                }
            }
        }

        private void tümünüAçVeYazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object record = gridView1.GetRow(i);
                if (record != null)
                {
                    bool isSelected = (bool)gridView1.GetFocusedRowCellValue("IsSelected");
                    AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR rpr =
                        (AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR)record;
                    if (isSelected)
                    {
                        OpenSelectedRapor(rpr, true, true);
                    }
                }
            }
        }
    }

    public class Surukle<T> where T : AvukatProLib2.Entities.IEntity, new()
    {
        #region  gridSurukle

        private ExtendedGridControl gridMyDraggerGrid;

        public ExtendedGridControl GridMyDraggerGrid
        {
            get { return gridMyDraggerGrid; }
            set
            {
                gridMyDraggerGrid = value;
                if (value == null)
                {
                    return;
                }
                gridMyDraggerGrid.DataSourceChanged += gridMyDraggerGrid_DataSourceChanged;
            }
        }

        private void ucAjanda_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                downHitInfo = hitInfo;
        }

        private void gridMyDraggerGrid_DataSourceChanged(object sender, EventArgs e)
        {
            (gridMyDraggerGrid.MainView).MouseDown += ucAjanda_MouseDown;
            (gridMyDraggerGrid.MainView).MouseMove += ucAjanda_MouseMove;
            ((GridView)gridMyDraggerGrid.MainView).OptionsBehavior.EditorShowMode =
                DevExpress.Utils.EditorShowMode.MouseUp;
        }

        private GridHitInfo downHitInfo;

        private void ucAjanda_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                                                             downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    T deger = Activator.CreateInstance<T>();
                    deger = (T)((GridView)GridMyDraggerGrid.MainView).GetFocusedRow();
                    view.GridControl.DoDragDrop(deger, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }

        
        #endregion
    }

    public class Birak<T, Z>
        where T : AvukatProLib2.Entities.IEntity, new()
        where Z : AvukatProLib2.Entities.IEntity, new()
    {
        #region drop

        private ExtendedGridControl dragdropGrid;

        public ExtendedGridControl DragDropGrid
        {
            get { return dragdropGrid; }
            set
            {
                dragdropGrid = value;
                if (value != null)
                {
                    value.DragEnter += value_DragEnter;
                    value.DragDrop += value_DragDrop;
                }
            }
        }

        private void value_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

            ghinf = new GridHitInfo();

            ghinf = ((GridView)((GridControl)sender).MainView).CalcHitInfo(e.X, e.Y);
            ((GridView)((GridControl)sender).MainView).FocusedRowHandle = ghinf.RowHandle;
        }

        public delegate void OnDragDropConvert(
            Z value, ExtendedGridControl sender, T valueToAdd, out bool addToGrid, GridHitInfo ghinf);

        public event OnDragDropConvert DragDropConvert;
        private GridHitInfo ghinf = new GridHitInfo();

        private void value_DragDrop(object sender, DragEventArgs e)
        {
            Z dropped = (Z)e.Data.GetData(typeof(Z));
            T val = Activator.CreateInstance<T>();
            bool canAdd = false;

            DragDropConvert(dropped, dragdropGrid, val, out canAdd, ghinf);
            if (canAdd)
            {
                ((AvukatProLib2.Entities.TList<T>)((GridControl)sender).DataSource).Add(val);
            }
        }

        #endregion
    }
}