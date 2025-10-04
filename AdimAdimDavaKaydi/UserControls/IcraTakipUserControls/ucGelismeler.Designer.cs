namespace  AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    partial class ucGelismeler
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGelismeler));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdGelismeler = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rLueGelismeAdimID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueCariID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gwGelismeler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKAYNAK_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueKaynakTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGELISME_ADIM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARAF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView7 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdGelismeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdimID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwGelismeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKaynakTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGelismeler
            // 
            this.grdGelismeler.CustomButtonlarGorunmesin = false;
            resources.ApplyResources(this.grdGelismeler, "grdGelismeler");
            this.grdGelismeler.DoNotExtendEmbedNavigator = false;
            this.grdGelismeler.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grdGelismeler.ExternalRepository = this.MyRepository;
            this.grdGelismeler.FilterText = null;
            this.grdGelismeler.FilterValue = null;
            this.grdGelismeler.GridlerDuzenlenebilir = true;
            this.grdGelismeler.GridsFilterControl = null;
            this.grdGelismeler.MainView = this.gwGelismeler;
            this.grdGelismeler.MyGridStyle = null;
            this.grdGelismeler.Name = "grdGelismeler";
            this.grdGelismeler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueKaynakTip});
            this.grdGelismeler.ShowRowNumbers = false;
            this.grdGelismeler.SilmeKaldirilsin = false;
            this.grdGelismeler.TemizleKaldirGorunsunmu = false;
            this.grdGelismeler.UniqueId = "2d2fab86-53d8-4970-af6c-cb437e95769e";
            this.grdGelismeler.UseEmbeddedNavigator = true;
            this.grdGelismeler.UseHyperDragDrop = false;
            this.grdGelismeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwGelismeler,
            this.cardView7});
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueGelismeAdimID,
            this.rLueCariID,
            this.txtAciklama});
            // 
            // rLueGelismeAdimID
            // 
            resources.ApplyResources(this.rLueGelismeAdimID, "rLueGelismeAdimID");
            this.rLueGelismeAdimID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueGelismeAdimID.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueGelismeAdimID.Buttons1"))), resources.GetString("rLueGelismeAdimID.Buttons2"), ((int)(resources.GetObject("rLueGelismeAdimID.Buttons3"))), ((bool)(resources.GetObject("rLueGelismeAdimID.Buttons4"))), ((bool)(resources.GetObject("rLueGelismeAdimID.Buttons5"))), ((bool)(resources.GetObject("rLueGelismeAdimID.Buttons6"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("rLueGelismeAdimID.Buttons7"))), ((System.Drawing.Image)(resources.GetObject("rLueGelismeAdimID.Buttons8"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("rLueGelismeAdimID.Buttons9"), resources.GetString("rLueGelismeAdimID.Buttons10"), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("rLueGelismeAdimID.Buttons11"))), ((bool)(resources.GetObject("rLueGelismeAdimID.Buttons12"))))});
            this.rLueGelismeAdimID.Name = "rLueGelismeAdimID";
            this.rLueGelismeAdimID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rLueGelismeAdimID.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rLueGelismeAdimID_ProcessNewValue);
            this.rLueGelismeAdimID.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rLueGelismeAdimID_ButtonClick);
            // 
            // rLueCariID
            // 
            resources.ApplyResources(this.rLueCariID, "rLueCariID");
            this.rLueCariID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueCariID.Buttons"))))});
            this.rLueCariID.Name = "rLueCariID";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Name = "txtAciklama";
            // 
            // gwGelismeler
            // 
            this.gwGelismeler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKAYNAK_TIP,
            this.colGELISME_ADIM,
            this.colTARAF,
            this.colTARIH1,
            this.colACIKLAMA1});
            this.gwGelismeler.GridControl = this.grdGelismeler;
            resources.ApplyResources(this.gwGelismeler, "gwGelismeler");
            this.gwGelismeler.IndicatorWidth = 20;
            this.gwGelismeler.Name = "gwGelismeler";
            this.gwGelismeler.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwGelismeler.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gwGelismeler.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gwGelismeler.OptionsNavigation.AutoFocusNewRow = true;
            this.gwGelismeler.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwGelismeler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwGelismeler.OptionsView.ColumnAutoWidth = false;
            this.gwGelismeler.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gwGelismeler.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwGelismeler.OptionsView.ShowAutoFilterRow = true;
            this.gwGelismeler.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwGelismeler.OptionsView.ShowPreview = true;
            this.gwGelismeler.PaintStyleName = "Skin";
            this.gwGelismeler.PreviewFieldName = "ACIKLAMA";
            // 
            // colKAYNAK_TIP
            // 
            resources.ApplyResources(this.colKAYNAK_TIP, "colKAYNAK_TIP");
            this.colKAYNAK_TIP.ColumnEdit = this.rLueKaynakTip;
            this.colKAYNAK_TIP.FieldName = "KAYNAK_TIP";
            this.colKAYNAK_TIP.Name = "colKAYNAK_TIP";
            // 
            // rLueKaynakTip
            // 
            resources.ApplyResources(this.rLueKaynakTip, "rLueKaynakTip");
            this.rLueKaynakTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("rLueKaynakTip.Buttons"))))});
            this.rLueKaynakTip.Name = "rLueKaynakTip";
            // 
            // colGELISME_ADIM
            // 
            resources.ApplyResources(this.colGELISME_ADIM, "colGELISME_ADIM");
            this.colGELISME_ADIM.ColumnEdit = this.rLueGelismeAdimID;
            this.colGELISME_ADIM.FieldName = "GELISME_ADIM_ID";
            this.colGELISME_ADIM.Name = "colGELISME_ADIM";
            // 
            // colTARAF
            // 
            resources.ApplyResources(this.colTARAF, "colTARAF");
            this.colTARAF.ColumnEdit = this.rLueCariID;
            this.colTARAF.FieldName = "TARAF_ID";
            this.colTARAF.Name = "colTARAF";
            // 
            // colTARIH1
            // 
            resources.ApplyResources(this.colTARIH1, "colTARIH1");
            this.colTARIH1.FieldName = "TARIH";
            this.colTARIH1.Name = "colTARIH1";
            // 
            // colACIKLAMA1
            // 
            resources.ApplyResources(this.colACIKLAMA1, "colACIKLAMA1");
            this.colACIKLAMA1.ColumnEdit = this.txtAciklama;
            this.colACIKLAMA1.FieldName = "ACIKLAMA";
            this.colACIKLAMA1.Name = "colACIKLAMA1";
            // 
            // cardView7
            // 
            this.cardView7.FocusedCardTopFieldIndex = 0;
            this.cardView7.GridControl = this.grdGelismeler;
            this.cardView7.Name = "cardView7";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnKaydet);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdGelismeler);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Image = global::AdimAdimDavaKaydi.PrintRibbonControllerResources.RibbonPrintPreview_SaveLarge;
            resources.ApplyResources(this.btnKaydet, "btnKaydet");
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // ucGelismeler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucGelismeler";
            this.Load += new System.EventHandler(this.ucGelismeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGelismeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueGelismeAdimID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueCariID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwGelismeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueKaynakTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl grdGelismeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gwGelismeler;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYNAK_TIP;
        private DevExpress.XtraGrid.Columns.GridColumn colGELISME_ADIM;
        private DevExpress.XtraGrid.Columns.GridColumn colTARAF;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH1;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView7;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueGelismeAdimID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueCariID;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit txtAciklama;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueKaynakTip;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}
