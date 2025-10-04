using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using AvukatProLib;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaliOdemeleri : AvpXUserControl
    {
        #region Fields


        private BackgroundWorker bckWorker = new BackgroundWorker();
        private AV001_TD_BIL_FOY myFoy;
        private TList<AV001_TD_BIL_BORCLU_ODEME> _MyDataSource;

        #endregion Fields

        #region Constructors

        public ucDavaliOdemeleri()
        {
            this.Load += ucDavaliOdemeleri_Load;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public TList<AV001_TD_BIL_BORCLU_ODEME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                //if (value != null)
                //    MyDataSource = value.AV001_TD_BIL_BORCLU_ODEMECollection;
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void BindData()
        {
            if (MyDataSource == null) 
                return;
            if (!bckWorker.IsBusy)
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
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_BORCLU_ODEME>));
                MyDataSource = MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dnDavaliOdemeleri.DataSource = MyDataSource;
                gridDavaliOdeme.DataSource = MyDataSource;
                vGDavaliOdeme.DataSource = MyDataSource;
            }
        }

        private void gridDavaliOdeme_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "rFrmDavaliOdemeleri")
            {
                rFrmDavaliOdemeleri frm = new rFrmDavaliOdemeleri();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(MyFoy);
            }
            if (e.Button.Tag.ToString() == "KayitDuzenle")
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

                rFrmDavaliOdemeleri frm = new rFrmDavaliOdemeleri();
                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.AddNewList = new TList<AV001_TD_BIL_BORCLU_ODEME>();
                frm.AddNewList.Add(gwDavaliOdeme.GetFocusedRow() as AV001_TD_BIL_BORCLU_ODEME);
                frm.Show(MyFoy);
            }
        }

        private void ucDavaliOdemeleri_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDavaliOdeme.Visible = true;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridDavaliOdeme.Visible = false;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDavaliOdeme.Visible = false;


                AvukatPro.Services.Implementations.DevExpressService.KasaHesapBilgileriDoldur(rlueKasaHesabi);
                AvukatPro.Services.Implementations.DevExpressService.MuhatapHesapBilgilerirDoldur(rlueMuhatapHesabi);
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(rlueKiymetliEvrak);
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
            }
            if (!this.DesignMode)
            {
                try
                {
                    BelgeUtil.Inits.ParaBicimiAyarla(Tutar);
                    BelgeUtil.Inits.FeragatKapsamiGetir(rlueFeragati);
                    BelgeUtil.Inits.FoyTarafGetir(rlueFoyTarafi);
                    BelgeUtil.Inits.MahsupKategoriGetir(rlueMahsupKat);
                    BelgeUtil.Inits.MahsupAltKategoriGetir(rlueAltKategori);
                    BelgeUtil.Inits.DovizTipGetir(rlueDovizTip);
                    BelgeUtil.Inits.OdemeYeriGetir(rlueOdemeYer);
                    BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTipi);
                    BelgeUtil.Inits.perCariGetir(rlueCari);

                    if (MyFoy != null)
                    {
                        try
                        {
                            BelgeUtil.Inits.DavaEdenTarafGetir(MyFoy, new[] { relueOdenenCari });
                            BelgeUtil.Inits.DavaEdilenTarafGetir(MyFoy, new[] { rlueOdeyenCari });
                            BelgeUtil.Inits.DavaNedenBilGetir(rlueDavaNeden, MyFoy.ID);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        #endregion Methods
    }
}