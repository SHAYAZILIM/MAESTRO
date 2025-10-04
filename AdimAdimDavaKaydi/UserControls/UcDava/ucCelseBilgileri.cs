using System;
using System.Collections.Generic;
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
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucCelseBilgileri : AvpXUserControl
    {
        public static bool Duzenlememi;

        public ucCelseBilgileri()
        {
            this.Load += ucCelseBilgileri_Load;
        }

        private void gridCelseBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "rFrmCelseKayit")
            {
                rFrmCelseKayit frm = new rFrmCelseKayit();
                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(MyFoy);
                frm.FormClosed += frm_FormClosed;
            }
            if (e.Button.Tag.ToString() == "KayýtDuýzenle")
            {
                rFrmCelseKayit frmd = new rFrmCelseKayit();
                DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyDataSource[vgRecordIndex], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>));
                frmd.MyCelse = MyDataSource[vgRecordIndex];
                frmd.Show(MyFoy);
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }

        private AV001_TD_BIL_FOY myFoy;

        private TList<AV001_TD_BIL_CELSE> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_CELSE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                if (gridCelseBilgileri != null)
                    gridCelseBilgileri.DataSource = value;

                if (vgCelse != null)
                    vgCelse.DataSource = value;//Hýzlý eriþimden Vertical Gride Datasource verilmesini saðlamak için eklendi. MB

                if (value != null)
                {
                    _MyDataSource = value;
                    foreach (var item in value)
                    {
                        item.ColumnChanged += item_ColumnChanged;
                    }
                }
            }
        }

        private void item_ColumnChanged(object sender, AV001_TD_BIL_CELSEEventArgs e)
        {
            if (e.Column == AV001_TD_BIL_CELSEColumn.CELSE_MI)
            {
                bool b = (bool)e.Value;
                if (b)
                {
                    mRowINCELEME_TUR_ID.Visible = false;
                    rowCELSEYE_GIRILDI_MI.Properties.Caption = "Duruþmaya Girildi mi ?";
                }
                else
                {
                    mRowINCELEME_TUR_ID.Visible = true;
                    rowCELSEYE_GIRILDI_MI.Properties.Caption = "Ýncelemeye Girildi mi ?";
                }
            }
            else if (e.Column == AV001_TD_BIL_CELSEColumn.TARIH)
            {
                if ((DateTime)e.Value <= DateTime.Today.Date)
                    rowCELSEYE_GIRILDI_MI.Enabled = true;
                else
                    rowCELSEYE_GIRILDI_MI.Enabled = false;
            }
        }

        public void BindData()
        {
            if (MyDataSource == null)
                return;

            #region <MB-20100623>

            //Celse tabý açýldýðýnda sorun yaþandýðý için kapatýldý. Aþaðýdaki eventlarda yapýlan iþlemler bu metod içerisine alýndý.
            //if (!bckWorker.IsBusy)
            //{
            //    bckWorker.DoWork += new DoWorkEventHandler(bckWorker_DoWork);
            //    bckWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckWorker_RunWorkerCompleted);
            //    bckWorker.RunWorkerAsync();
            //}

            #endregion

            if (MyDataSource.Count == 0 && MyFoy != null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
                MyDataSource = MyFoy.AV001_TD_BIL_CELSECollection;
                if (Duzenlememi && MyDataSource != null)
                    DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyDataSource[0], true, DeepLoadType.IncludeChildren, typeof(TList<NN_BELGE_CELSE>));
                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    foreach (var belge in MyDataSource[0].NN_BELGE_CELSECollection)
                    {
                        for (int rowHandle = 0; rowHandle < lueBelge.Properties.View.RowCount; rowHandle++)
                        {
                            if ((int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id") == belge.BELGE_ID)
                                lueBelge.Properties.View.SetRowCellValue(rowHandle, "IsSelected", true);
                        }
                    } 
                }
            }
            if (!this.DesignMode && IsLoaded)
            {
                dnCelseBilgileri.DataSource = MyDataSource;
                gridCelseBilgileri.DataSource = MyDataSource;
                vgCelse.DataSource = dnCelseBilgileri.DataSource;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (value.AV001_TD_BIL_CELSECollection != null && value.AV001_TD_BIL_CELSECollection.Count == 0)
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
                    MyDataSource = value.AV001_TD_BIL_CELSECollection;
                }
            }
        }

        [Browsable(true)]
        [Description("Görünümü Deðiþtirir.")]
        public ViewType MyType { get; set; }

        public static string ReferansNo()
        {
            return "CR" + "-" + DateTime.Today.Year + "~" +
                   System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
        }

        //private int vgRIndex;
        [Browsable(false)]
        public int vgRecordIndex
        {
            get
            {
                if (vgCelse != null)
                {
                    if (vgCelse.FocusedRecord < 0)
                        return 0;

                    return vgCelse.FocusedRecord;
                }
                else
                    return 0;
            }
            //set { vgRIndex = value; }
        }

        private void ucCelseBilgileri_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            gridCelseBilgileri.ButtonClick += gridCelseBilgileri_ButtonClick;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridCelseBilgileri.Visible = true;
                //extendedGridControl1.Visible = false;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridCelseBilgileri.Visible = false;
                //extendedGridControl1.Visible = true;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridCelseBilgileri.Visible = false;
            }
            if (!this.DesignMode)
            {
                gridCelseBilgileri.ShowOnlyPredefinedDetails = true;

                BelgeUtil.Inits.CariAvukatGetir(CariAvukat);
                BelgeUtil.Inits.IncelemeTurGetir(rlueIncelemeTuru);
                BelgeUtil.Inits.AraKararGetir(rlueAraKararBilgileri);
                BelgeUtil.Inits.CariAdliPersonelGetir(CariSavci);
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);

                if (!Duzenlememi)
                    mRowINCELEME_TUR_ID.Visible = false;
                BindData();
            }
        }

        public event IndexChangedEventHandler FocusedRecordChanged;

        private void vgCelse_FocusedRecordChanged(object sender,
                                                  DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedRecordChanged != null)
            {
                FocusedRecordChanged(sender, e);
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            AV001_TD_BIL_CELSE celse = MyDataSource[vgRecordIndex];
            if (celse.ID == 0)
            {
                MessageBox.Show("Öncelikle Celseyi Kaydediniz.");
                return;
            }
            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
            frmisKayit.ucIsKayitUfak1.OpenedRecord = celse;
            //frmisKayit.MdiParent = null;
            frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmisKayit.Show();
        }

        private void gwCelseBilgileri_DoubleClick(object sender, EventArgs e)
        {
            TList<AV001_TD_BIL_CELSE> master = gwCelseBilgileri.DataSource as TList<AV001_TD_BIL_CELSE>;
            AV001_TD_BIL_CELSE CelseSelectedRow = master[gwCelseBilgileri.FocusedRowHandle];

            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(CelseSelectedRow, false, DeepLoadType.IncludeChildren, typeof(TList<NN_BELGE_CELSE>));
            TList<NN_BELGE_CELSE> NNbelge = DataRepository.NN_BELGE_CELSEProvider.Find("CELSE_ID =" + CelseSelectedRow.ID);
            List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> belgelerim = new List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>();
            foreach (NN_BELGE_CELSE item in NNbelge)
            {
                belgelerim.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(vi => vi.ID == item.BELGE_ID));
            }
        }
    }
}