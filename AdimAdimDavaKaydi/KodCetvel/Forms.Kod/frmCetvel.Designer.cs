namespace  AdimAdimDavaKaydi.KodCetvel.Forms.Kod
{
    partial class frmCetvel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCetvel));
            this.barMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.Cetveller = new DevExpress.XtraNavBar.NavBarGroup();
            this.antet = new DevExpress.XtraNavBar.NavBarItem();
            this.sabitler = new DevExpress.XtraNavBar.NavBarItem();
            this.cetvel = new DevExpress.XtraNavBar.NavBarItem();
            this.servisler = new DevExpress.XtraNavBar.NavBarItem();
            this.bakim = new DevExpress.XtraNavBar.NavBarItem();
            this.sistem = new DevExpress.XtraNavBar.NavBarItem();
            this.treePanel = new DevExpress.XtraEditors.GroupControl();
            this.treeListMenu = new DevExpress.XtraTreeList.TreeList();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList = new DevExpress.Utils.ImageCollection(this.components);
            this.anaPanel = new DevExpress.XtraEditors.PanelControl();
            this.ContainerPanel = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridMenu = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treePanel)).BeginInit();
            this.treePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anaPanel)).BeginInit();
            this.anaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerPanel)).BeginInit();
            this.ContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(1011, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 505);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 505);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 480);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1028, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(878, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(953, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.anaPanel);
            this.c_pnlContainer.Controls.Add(this.barMenu);
            this.c_pnlContainer.Size = new System.Drawing.Size(1028, 505);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.barMenu, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.anaPanel, 0);
            // 
            // barMenu
            // 
            this.barMenu.ActiveGroup = this.Cetveller;
            this.barMenu.ContentButtonHint = null;
            this.barMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.barMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.Cetveller});
            this.barMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.antet,
            this.bakim,
            this.servisler,
            this.cetvel,
            this.sabitler,
            this.sistem});
            this.barMenu.Location = new System.Drawing.Point(0, 0);
            this.barMenu.Name = "barMenu";
            this.barMenu.OptionsNavPane.ExpandedWidth = 184;
            this.barMenu.Size = new System.Drawing.Size(184, 480);
            this.barMenu.TabIndex = 0;
            this.barMenu.Text = "navBarControl1";
            this.barMenu.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Caramel");
            // 
            // Cetveller
            // 
            this.Cetveller.Caption = "Cetvel Menüsü";
            this.Cetveller.Expanded = true;
            this.Cetveller.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.Cetveller.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.antet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.sabitler),
            new DevExpress.XtraNavBar.NavBarItemLink(this.cetvel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.servisler),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bakim),
            new DevExpress.XtraNavBar.NavBarItemLink(this.sistem)});
            this.Cetveller.Name = "Cetveller";
            // 
            // antet
            // 
            this.antet.Caption = "Antet Bilgileri";
            this.antet.Name = "antet";
            this.antet.Visible = false;
            // 
            // sabitler
            // 
            this.sabitler.Caption = "Sabit Giriþleri";
            this.sabitler.Name = "sabitler";
            this.sabitler.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.sabitler_LinkClicked);
            // 
            // cetvel
            // 
            this.cetvel.Caption = "Cetveller";
            this.cetvel.Name = "cetvel";
            this.cetvel.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.cetvel_LinkClicked);
            // 
            // servisler
            // 
            this.servisler.Caption = "Servisler";
            this.servisler.Name = "servisler";
            this.servisler.Visible = false;
            // 
            // bakim
            // 
            this.bakim.Caption = "Bakým Ayarlarý";
            this.bakim.Name = "bakim";
            this.bakim.Visible = false;
            // 
            // sistem
            // 
            this.sistem.Caption = "Sistem Ayarlarý";
            this.sistem.Name = "sistem";
            this.sistem.Visible = false;
            // 
            // treePanel
            // 
            this.treePanel.Controls.Add(this.treeListMenu);
            this.treePanel.Controls.Add(this.panelControl1);
            this.treePanel.Location = new System.Drawing.Point(0, 0);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(185, 476);
            this.treePanel.TabIndex = 1;
            // 
            // treeListMenu
            // 
            this.treeListMenu.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(219)))));
            this.treeListMenu.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.treeListMenu.Appearance.Empty.Options.UseBackColor = true;
            this.treeListMenu.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(219)))));
            this.treeListMenu.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeListMenu.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeListMenu.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeListMenu.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.treeListMenu.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeListMenu.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListMenu.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeListMenu.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(136)))), ((int)(((byte)(91)))));
            this.treeListMenu.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeListMenu.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListMenu.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeListMenu.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(62)))));
            this.treeListMenu.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(62)))));
            this.treeListMenu.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.treeListMenu.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeListMenu.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeListMenu.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeListMenu.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(62)))));
            this.treeListMenu.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(143)))), ((int)(((byte)(62)))));
            this.treeListMenu.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeListMenu.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeListMenu.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(189)))), ((int)(((byte)(125)))));
            this.treeListMenu.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(189)))), ((int)(((byte)(125)))));
            this.treeListMenu.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeListMenu.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeListMenu.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeListMenu.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeListMenu.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(166)))), ((int)(((byte)(93)))));
            this.treeListMenu.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(166)))), ((int)(((byte)(93)))));
            this.treeListMenu.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.treeListMenu.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeListMenu.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeListMenu.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeListMenu.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(172)))), ((int)(((byte)(134)))));
            this.treeListMenu.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(234)))), ((int)(((byte)(216)))));
            this.treeListMenu.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeListMenu.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeListMenu.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(169)))), ((int)(((byte)(107)))));
            this.treeListMenu.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeListMenu.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(224)))), ((int)(((byte)(190)))));
            this.treeListMenu.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeListMenu.Appearance.OddRow.Options.UseBackColor = true;
            this.treeListMenu.Appearance.OddRow.Options.UseForeColor = true;
            this.treeListMenu.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(237)))));
            this.treeListMenu.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.treeListMenu.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(120)))), ((int)(((byte)(88)))));
            this.treeListMenu.Appearance.Preview.Options.UseBackColor = true;
            this.treeListMenu.Appearance.Preview.Options.UseFont = true;
            this.treeListMenu.Appearance.Preview.Options.UseForeColor = true;
            this.treeListMenu.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(219)))));
            this.treeListMenu.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeListMenu.Appearance.Row.Options.UseBackColor = true;
            this.treeListMenu.Appearance.Row.Options.UseForeColor = true;
            this.treeListMenu.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(159)))), ((int)(((byte)(114)))));
            this.treeListMenu.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treeListMenu.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeListMenu.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeListMenu.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(120)))), ((int)(((byte)(88)))));
            this.treeListMenu.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeListMenu.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(169)))), ((int)(((byte)(107)))));
            this.treeListMenu.Appearance.VertLine.Options.UseBackColor = true;
            this.treeListMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListMenu.Location = new System.Drawing.Point(2, 62);
            this.treeListMenu.Name = "treeListMenu";
            this.treeListMenu.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListMenu.OptionsView.EnableAppearanceOddRow = true;
            this.treeListMenu.Size = new System.Drawing.Size(181, 412);
            this.treeListMenu.TabIndex = 0;
            this.treeListMenu.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListMenu_FocusedNodeChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textBox1);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(181, 41);
            this.panelControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(46, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama:";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageList.ImageStream")));
            // 
            // anaPanel
            // 
            this.anaPanel.Controls.Add(this.ContainerPanel);
            this.anaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anaPanel.Location = new System.Drawing.Point(184, 0);
            this.anaPanel.Name = "anaPanel";
            this.anaPanel.Size = new System.Drawing.Size(844, 480);
            this.anaPanel.TabIndex = 2;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(2, 2);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Panel1.Controls.Add(this.gridMenu);
            this.ContainerPanel.Panel1.Controls.Add(this.treePanel);
            this.ContainerPanel.Panel1.Text = "Panel1";
            this.ContainerPanel.Panel2.Controls.Add(this.dockPanel1);
            this.ContainerPanel.Panel2.Text = "Panel2";
            this.ContainerPanel.Size = new System.Drawing.Size(840, 476);
            this.ContainerPanel.SplitterPosition = 343;
            this.ContainerPanel.TabIndex = 2;
            this.ContainerPanel.Text = "splitContainerControl1";
            this.ContainerPanel.Visible = false;
            // 
            // gridMenu
            // 
            this.gridMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMenu.Location = new System.Drawing.Point(0, 0);
            this.gridMenu.MainView = this.gridView1;
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridMenu.Size = new System.Drawing.Size(343, 476);
            this.gridMenu.TabIndex = 3;
            this.gridMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.GridControl = this.gridMenu;
            this.gridView1.GroupPanelText = "Guruplamak Ýçin Baþlýklarý Sürükleyin";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Adi", null, "- {0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Adý";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.FieldName = "Adi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 77;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ReadOnly = true;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("0c1fad49-20e1-4810-99ec-164df1b507e1");
            this.dockPanel1.Location = new System.Drawing.Point(156, 45);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(287, 200);
            this.dockPanel1.Size = new System.Drawing.Size(287, 387);
            this.dockPanel1.Text = "Rapor Listeleri";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(281, 359);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // frmCetvel
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 505);
            this.Name = "frmCetvel";
            this.Text = "Cetvel";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmCetvel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treePanel)).EndInit();
            this.treePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anaPanel)).EndInit();
            this.anaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerPanel)).EndInit();
            this.ContainerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl barMenu;
        private DevExpress.XtraNavBar.NavBarGroup Cetveller;
        private DevExpress.XtraNavBar.NavBarItem antet;
        private DevExpress.XtraEditors.GroupControl treePanel;
        private DevExpress.XtraNavBar.NavBarItem bakim;
        private DevExpress.XtraNavBar.NavBarItem servisler;
        private DevExpress.XtraNavBar.NavBarItem cetvel;
        private DevExpress.Utils.ImageCollection imageList;
        private DevExpress.XtraNavBar.NavBarItem sabitler;
        private DevExpress.XtraNavBar.NavBarItem sistem;
        private DevExpress.XtraTreeList.TreeList treeListMenu;
        private DevExpress.XtraEditors.PanelControl anaPanel;
        private DevExpress.XtraEditors.SplitContainerControl ContainerPanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        public DevExpress.XtraGrid.GridControl gridMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}