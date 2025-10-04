namespace  AdimAdimDavaKaydi.Sorusturma.UserControls
{
    partial class ucMeslekMakbuzu
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
            this.gridMeslekMakbuzu = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwMeslekMakbuzu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucBelgeIzlemeDolasimDock1 = new AdimAdimDavaKaydi.UserControls.ucBelgeIzlemeDolasimDock();
            ((System.ComponentModel.ISupportInitialize)(this.gridMeslekMakbuzu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMeslekMakbuzu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMeslekMakbuzu
            // 
            this.gridMeslekMakbuzu.CustomButtonlarGorunmesin = false;
            this.gridMeslekMakbuzu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMeslekMakbuzu.DoNotExtendEmbedNavigator = false;
            this.gridMeslekMakbuzu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridMeslekMakbuzu.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gridMeslekMakbuzu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridMeslekMakbuzu.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt", "FormAc"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Düzenle", "KaydýDuzenle")});
            this.gridMeslekMakbuzu.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridMeslekMakbuzu_EmbeddedNavigator_ButtonClick);
            this.gridMeslekMakbuzu.FilterText = null;
            this.gridMeslekMakbuzu.FilterValue = null;
            this.gridMeslekMakbuzu.GridlerDuzenlenebilir = true;
            this.gridMeslekMakbuzu.GridsFilterControl = null;
            this.gridMeslekMakbuzu.Location = new System.Drawing.Point(0, 0);
            this.gridMeslekMakbuzu.MainView = this.gwMeslekMakbuzu;
            this.gridMeslekMakbuzu.MyGridStyle = null;
            this.gridMeslekMakbuzu.Name = "gridMeslekMakbuzu";
            this.gridMeslekMakbuzu.ShowRowNumbers = false;
            this.gridMeslekMakbuzu.SilmeKaldirilsin = false;
            this.gridMeslekMakbuzu.Size = new System.Drawing.Size(521, 501);
            this.gridMeslekMakbuzu.TabIndex = 0;
            this.gridMeslekMakbuzu.TemizleKaldirGorunsunmu = false;
            this.gridMeslekMakbuzu.UniqueId = "250d0268-2c61-4217-b70b-b73d47e3123b";
            this.gridMeslekMakbuzu.UseEmbeddedNavigator = true;
            this.gridMeslekMakbuzu.UseHyperDragDrop = false;
            this.gridMeslekMakbuzu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwMeslekMakbuzu});
            // 
            // gwMeslekMakbuzu
            // 
            this.gwMeslekMakbuzu.GridControl = this.gridMeslekMakbuzu;
            this.gwMeslekMakbuzu.IndicatorWidth = 20;
            this.gwMeslekMakbuzu.Name = "gwMeslekMakbuzu";
            this.gwMeslekMakbuzu.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwMeslekMakbuzu.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwMeslekMakbuzu.OptionsNavigation.AutoFocusNewRow = true;
            this.gwMeslekMakbuzu.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwMeslekMakbuzu.OptionsView.AutoCalcPreviewLineCount = true;
            this.gwMeslekMakbuzu.OptionsView.ColumnAutoWidth = false;
            this.gwMeslekMakbuzu.OptionsView.ShowAutoFilterRow = true;
            this.gwMeslekMakbuzu.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwMeslekMakbuzu.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwMeslekMakbuzu.OptionsView.ShowPreview = true;
            this.gwMeslekMakbuzu.PreviewFieldName = "ACIKLAMA";
            this.gwMeslekMakbuzu.DoubleClick += new System.EventHandler(this.gwMeslekMakbuzu_DoubleClick);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Location = new System.Drawing.Point(521, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 221;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(221, 501);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.Visible = false;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Belge Önizleme";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 476;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.ucBelgeIzlemeDolasimDock1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(221, 426);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // ucBelgeIzlemeDolasimDock1
            // 
            this.ucBelgeIzlemeDolasimDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBelgeIzlemeDolasimDock1.Location = new System.Drawing.Point(0, 0);
            this.ucBelgeIzlemeDolasimDock1.MyDataSource = null;
            this.ucBelgeIzlemeDolasimDock1.Name = "ucBelgeIzlemeDolasimDock1";
            this.ucBelgeIzlemeDolasimDock1.Size = new System.Drawing.Size(221, 426);
            this.ucBelgeIzlemeDolasimDock1.TabIndex = 4;
            // 
            // ucMeslekMakbuzu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridMeslekMakbuzu);
            this.Controls.Add(this.navBarControl1);
            this.Name = "ucMeslekMakbuzu";
            this.Size = new System.Drawing.Size(742, 501);
            this.Load += new System.EventHandler(this.ucMeslekMakbuzu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMeslekMakbuzu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwMeslekMakbuzu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridMeslekMakbuzu;
        private DevExpress.XtraGrid.Views.Grid.GridView gwMeslekMakbuzu;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private AdimAdimDavaKaydi.UserControls.ucBelgeIzlemeDolasimDock ucBelgeIzlemeDolasimDock1;
    }
}
