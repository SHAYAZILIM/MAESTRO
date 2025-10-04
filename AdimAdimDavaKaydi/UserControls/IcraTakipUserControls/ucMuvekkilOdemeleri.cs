using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System.Collections.Generic;
using AvukatProLib;
using AvukatPro.Services.Implementations;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucMuvekkilOdemeleri : AvpXUserControl
    {
        private AV001_TI_BIL_FOY _MyIcraFoy;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TD_BIL_FOY myDavaFoy;

        private bool verticalGorunsun = true;

        public ucMuvekkilOdemeleri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMuvekkilOdemeleri_Load;

            //TODO: BURDAKÝ COLOMLAR DAHA SONRA DÜZENLENECEK ...
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_MUVEKKILE_ODEME> MyDataSource { get; set; }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                myDavaFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByDAVA_FOY_ID;
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return _MyIcraFoy; }
            set
            {
                _MyIcraFoy = value;
                if (value != null)
                {
                    MyDataSource = value.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID;
                    BindData();
                }
            }
        }

        [DefaultValue(true)]
        public bool VerticalGorunsun
        {
            get { return verticalGorunsun; }

            set
            {
                verticalGorunsun = value;
                if (IsLoaded)
                    if (value)
                        vGMuvekkilOdemeleri.BringToFront();
                    else
                        vGMuvekkilOdemeleri.SendToBack();
            }
        }

        public static string Validate(AV001_TI_BIL_MUVEKKILE_ODEME row)
        {
            StringBuilder sb = new StringBuilder();

            if (row.ODENEN_CARI_ID == 0)
                sb.AppendLine("* Ödenen Þahýs boþ olamaz.");
            if (row.ODEYEN_CARI_ID == 0)
                sb.AppendLine("* Ödeyen Þahýs boþ olamaz");

            return sb.ToString();
        }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
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
                if (MyDavaFoy != null)
                {
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));
                    MyDataSource = MyDavaFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByDAVA_FOY_ID;
                }
                else if (MyIcraFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));
                    MyDataSource = MyIcraFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                InitsDoldur(false);
                dnMuvekkilOdemeleri.DataSource = MyDataSource;
                vGMuvekkilOdemeleri.DataSource = MyDataSource;
                gridMuvekkilOdemeleri.DataSource = MyDataSource;
            }
        }

        private void frmMuvekkilOdeme_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyIcraFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));

            gridMuvekkilOdemeleri.DataSource = MyIcraFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID;
            MyDataSource = MyIcraFoy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID;
        }

        private void gridMuvekkilOdemeleri_ButtonClick(object sender,
                                                       DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                IcraTakipForms.frmMuvekkilOdemeleriLayout frmMuvekkilOdeme =
                    new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout(Modul.Icra, MyIcraFoy.ID);

                if (MyIcraFoy != null)
                {
                    InitsDoldur(true);

                    //frmMuvekkilOdeme.MyIcraFoy = MyIcraFoy;
                    //.MdiParent = null;
                    frmMuvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmMuvekkilOdeme.Show();
                    frmMuvekkilOdeme.FormClosed += frmMuvekkilOdeme_FormClosed;
                }
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
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

                DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.DeepLoad(
                    MyDataSource[gwMukekkilOdeme.FocusedRowHandle], false, DeepLoadType.IncludeChildren,
                    typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));
                TList<AV001_TI_BIL_MUVEKKILE_ODEME> DvList = new TList<AV001_TI_BIL_MUVEKKILE_ODEME>();
                DvList.Add(MyDataSource[gwMukekkilOdeme.FocusedRowHandle]);

                IcraTakipForms.frmMuvekkilOdemeleriLayout frmMuvekkilOdeme =
                    new AdimAdimDavaKaydi.IcraTakipForms.frmMuvekkilOdemeleriLayout(Modul.Icra, MyIcraFoy.ID);

                //frmMuvekkilOdeme.MyIcraFoy = MyIcraFoy;
                //frmMuvekkilOdeme.MdiParent = null;
                frmMuvekkilOdeme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmMuvekkilOdeme.MyDataSource = DvList;
                frmMuvekkilOdeme.Text = "Müvekkil Ödeme Kayýt Düzenleme";
                frmMuvekkilOdeme.Show();
                frmMuvekkilOdeme.FormClosed += frmMuvekkilOdeme_FormClosed;
            }
        }

        private void gridMuvekkilOdemeleri_ButtonEditorClick(object sender,
                                                             DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            AV001_TI_BIL_MUVEKKILE_ODEME muvekkileOdeme =
                gwMukekkilOdeme.GetFocusedRow() as AV001_TI_BIL_MUVEKKILE_ODEME;

            Editor.Degiskenler.Util.MuvekkilOdeme.OdemeMakbuzuGetir(muvekkileOdeme);
        }

        private void InitsDoldur(bool newItem)
        {
            if ((!initsFilled && MyDataSource.Count > 0) || newItem)
            {
                BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTipID);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);

                if (MyDavaFoy != null)
                {
                    BelgeUtil.Inits.DavaEdenTarafGetir(MyDavaFoy, new[] { rlueAlacakli });
                    BelgeUtil.Inits.DavaEdilenTarafGetir(MyDavaFoy, new[] { rlueBorclu });
                }
                if (MyIcraFoy != null)
                {
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyIcraFoy, new[] { rlueAlacakli });
                    //BelgeUtil.Inits.DosyaSorumluAvukatGetir(MyIcraFoy, new[] { rlueBorclu });
                    DevExpressService.CariDoldur(rlueBorclu);
                }

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

        private void ucMuvekkilOdemeleri_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            if (verticalGorunsun)
            {
                vGMuvekkilOdemeleri.BringToFront();
                gridMuvekkilOdemeleri.SendToBack();
            }
            else
            {
                vGMuvekkilOdemeleri.SendToBack();
                gridMuvekkilOdemeleri.BringToFront();
            }
            try
            {
                gridMuvekkilOdemeleri.ShowOnlyPredefinedDetails = true;
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}