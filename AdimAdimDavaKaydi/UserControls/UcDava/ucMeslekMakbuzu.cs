using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using AvukatProLib;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucMeslekMakbuzu : AvpXUserControl
    {

        public ucMeslekMakbuzu()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMeslekMakbuzu_Load;
        }

        private AV001_TD_BIL_FOY myDavaFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if (MyDataSource == null)
                    MyDataSource = new List<RBilFaturaModulEntity>();
                BindData();
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        private AV001_TI_BIL_FOY myIcraFoy;

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                myIcraFoy = value;
                if (MyDataSource == null)
                    MyDataSource = new List<RBilFaturaModulEntity>();
                BindData();
            }
        }

        private AV001_TD_BIL_HAZIRLIK myHazirlik;

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                myHazirlik = value;
                if (value != null)
                    MyDataSource = new List<RBilFaturaModulEntity>();
            }
        }

        [Browsable(false)]
        public List<RBilFaturaModulEntity> MyDataSource { get; set; }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyIcraFoy != null)
            {
                MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MyIcraFoy.ID, Modul.Icra);
            }
            else if (MyDavaFoy != null)
            {
                MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MyDavaFoy.ID, Modul.Dava);
            }

            else if (MyHazirlik != null)
            {
                MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MyHazirlik.ID, Modul.Sorusturma);
            }

            else if (MySozlesme != null)
            {
                MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFoy(MySozlesme.ID, Modul.Sozlesme);
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                gridMeslekMakbuzu.DataSource = MyDataSource;
            }
        }

        private void ucMeslekMakbuzu_Load(object sender, EventArgs e)
        {

            if (DesignMode)
                return;
            if (!IsLoaded)
                InitializeComponent();

            IsLoaded = true;
            NavBarGroup currentGroup = navBarControl1.Groups[0];
            currentGroup.Expanded = false;
            navBarGroup1.NavigationPaneVisible = false;
            AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura md = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.Fatura();
            gwMeslekMakbuzu.Columns.AddRange(md.GetFaturaIcColumns());
            BindData();
        }

        private void gridMeslekMakbuzu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;
            else if (e.Button.Tag.ToString() == "KaydýDuzenle")
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

                TList<AV001_TDI_BIL_FATURA> DvList = new TList<AV001_TDI_BIL_FATURA>();

                AV001_TDI_BIL_FATURA fatura = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)gwMeslekMakbuzu.GetRowCellValue(gwMeslekMakbuzu.GetSelectedRows()[0], "ID"));
                DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(fatura, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA_DETAY>));
                DvList.Add(fatura);

                rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
                frmMeslekMakbuzu.AddNewList = DvList;
                if (MyDavaFoy != null)
                {
                    frmMeslekMakbuzu.Show(MyDavaFoy);
                }
                else if (MySozlesme != null)
                {
                    frmMeslekMakbuzu.Show(MySozlesme);
                }
                else if (MyIcraFoy != null)
                {
                    frmMeslekMakbuzu.Show(myIcraFoy);
                }
                else if (MyHazirlik != null)
                {
                    frmMeslekMakbuzu.Show(MyHazirlik);
                }
            }
            else if (e.Button.Tag.ToString() == "FormAc")
            {
                if (MyIcraFoy != null)
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava(MyIcraFoy.ID, Modul.Icra);
                    try
                    {
                        frmMeslekMakbuzu.Show();
                    }
                    catch (OutOfMemoryException)
                    {
                        foreach (var item in System.Windows.Forms.Application.OpenForms)
                        {
                            if (item.GetType() == typeof(AdimAdimDavaKaydi.Raporlama.frmMuvekkilRapor))
                            {
                                (item as AdimAdimDavaKaydi.Raporlama.frmMuvekkilRapor).Close();
                                gridMeslekMakbuzu_EmbeddedNavigator_ButtonClick(sender, e);
                                break;
                            }
                        }
                    }
                }
                else if (MyDavaFoy != null)
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava(MyDavaFoy.ID, Modul.Dava);
                    frmMeslekMakbuzu.Show();
                }
                else if (MyHazirlik != null)
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava(MyHazirlik.ID, Modul.Sorusturma);
                    frmMeslekMakbuzu.Show();
                }
                else if (MySozlesme != null)
                {
                    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava(MySozlesme.ID, Modul.Sozlesme);
                    frmMeslekMakbuzu.Show();
                }
            }

            //else if (e.Button.Tag.ToString() == "KaydýDuzenle")
            //{
            //    TList<AV001_TDI_BIL_FATURA> DvList = new TList<AV001_TDI_BIL_FATURA>();

            //    AV001_TDI_BIL_FATURA fatura = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)gwMeslekMakbuzu.GetRowCellValue(gwMeslekMakbuzu.GetSelectedRows()[0], "ID"));
            //    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(fatura, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA_DETAY>));
            //    DvList.Add(fatura);

            //    rFrmMeslekMakbuzuKaydetForDava frmMeslekMakbuzu = new rFrmMeslekMakbuzuKaydetForDava();
            //    frmMeslekMakbuzu.AddNewList = DvList;
            //    if (MyDavaFoy != null)
            //    {
            //        frmMeslekMakbuzu.Show(MyDavaFoy);
            //    }
            //    else if (MySozlesme != null)
            //    {
            //        frmMeslekMakbuzu.Show(MySozlesme);
            //    }
            //    else if (MyIcraFoy != null)
            //    {
            //        frmMeslekMakbuzu.Show(myIcraFoy);
            //    }
            //    else if (MyHazirlik != null)
            //    {
            //        frmMeslekMakbuzu.Show(MyHazirlik);
            //    }
            //}
        }

        private void gwMeslekMakbuzu_DoubleClick(object sender, EventArgs e)
        {
            navBarGroup1.NavigationPaneVisible = true;
            TList<AV001_TDI_BIL_FATURA> master = gwMeslekMakbuzu.DataSource as TList<AV001_TDI_BIL_FATURA>;
            AV001_TDI_BIL_FATURA faturaSelectedRow = master[gwMeslekMakbuzu.FocusedRowHandle];

            TList<NN_FATURA_BELGE> NNbelge = DataRepository.NN_FATURA_BELGEProvider.Find("FATURA_ID =" + faturaSelectedRow.ID);
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> belgelerim = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            foreach (NN_FATURA_BELGE item in NNbelge)
            {
                belgelerim.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(b => b.ID == item.BELGE_ID));
            }
            if (belgelerim.Count != 0)
                this.ucBelgeIzlemeDolasimDock1.MyDataSource = belgelerim;
        }
    }
}