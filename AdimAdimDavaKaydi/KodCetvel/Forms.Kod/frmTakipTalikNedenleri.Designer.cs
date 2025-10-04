namespace  AnaForm
{
    partial class frmTakipTalikNedenleri
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
            this.panelTakipTalikErteleme = new DevExpress.XtraEditors.PanelControl();
            this.gridTakipTalikErteleme = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GRUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rCb_TakipTalikGrup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.NEDEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipTalikErteleme)).BeginInit();
            this.panelTakipTalikErteleme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipTalikErteleme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TakipTalikGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTakipTalikErteleme
            // 
            this.panelTakipTalikErteleme.Controls.Add(this.gridTakipTalikErteleme);
            this.panelTakipTalikErteleme.Controls.Add(this.panelControl1);
            this.panelTakipTalikErteleme.Controls.Add(this.panelControl2);
            this.panelTakipTalikErteleme.Location = new System.Drawing.Point(12, 12);
            this.panelTakipTalikErteleme.Name = "panelTakipTalikErteleme";
            this.panelTakipTalikErteleme.Size = new System.Drawing.Size(750, 360);
            this.panelTakipTalikErteleme.TabIndex = 13;
            // 
            // gridTakipTalikErteleme
            // 
            this.gridTakipTalikErteleme.CustomButtonlarGorunmesin = false;
            this.gridTakipTalikErteleme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTakipTalikErteleme.DoNotExtendEmbedNavigator = false;
            this.gridTakipTalikErteleme.FilterText = null;
            this.gridTakipTalikErteleme.FilterValue = null;
            this.gridTakipTalikErteleme.GridlerDuzenlenebilir = true;
            this.gridTakipTalikErteleme.GridsFilterControl = null;
            this.gridTakipTalikErteleme.Location = new System.Drawing.Point(2, 72);
            this.gridTakipTalikErteleme.MainView = this.gridView1;
            this.gridTakipTalikErteleme.MyGridStyle = null;
            this.gridTakipTalikErteleme.Name = "gridTakipTalikErteleme";
            this.gridTakipTalikErteleme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit16,
            this.rCb_TakipTalikGrup});
            this.gridTakipTalikErteleme.ShowRowNumbers = false;
            this.gridTakipTalikErteleme.Size = new System.Drawing.Size(746, 286);
            this.gridTakipTalikErteleme.TabIndex = 5;
            this.gridTakipTalikErteleme.TemizleKaldirGorunsunmu = false;
            this.gridTakipTalikErteleme.UniqueId = "aec3cfb6-71bb-4cb8-bb83-c14d6f3421c7";
            this.gridTakipTalikErteleme.UseEmbeddedNavigator = true;
            this.gridTakipTalikErteleme.UseHyperDragDrop = false;
            this.gridTakipTalikErteleme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GRUP,
            this.NEDEN});
            this.gridView1.GridControl = this.gridTakipTalikErteleme;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Takip Talik Nedenleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // GRUP
            // 
            this.GRUP.Caption = "Grup";
            this.GRUP.ColumnEdit = this.rCb_TakipTalikGrup;
            this.GRUP.FieldName = "GRUP";
            this.GRUP.Name = "GRUP";
            this.GRUP.Visible = true;
            this.GRUP.VisibleIndex = 0;
            // 
            // rCb_TakipTalikGrup
            // 
            this.rCb_TakipTalikGrup.AutoHeight = false;
            this.rCb_TakipTalikGrup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rCb_TakipTalikGrup.Name = "rCb_TakipTalikGrup";
            // 
            // NEDEN
            // 
            this.NEDEN.Caption = "Neden";
            this.NEDEN.ColumnEdit = this.repositoryItemTextEdit16;
            this.NEDEN.FieldName = "NEDEN";
            this.NEDEN.Name = "NEDEN";
            this.NEDEN.Visible = true;
            this.NEDEN.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit16
            // 
            this.repositoryItemTextEdit16.AutoHeight = false;
            this.repositoryItemTextEdit16.Name = "repositoryItemTextEdit16";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Takip Talik ( Erteleme ) Nedenleri";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.navigator);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // navigator
            // 
            this.navigator.Location = new System.Drawing.Point(5, 5);
            this.navigator.Name = "navigator";
            this.navigator.NavigatableControl = this.gridTakipTalikErteleme;
            this.navigator.Size = new System.Drawing.Size(364, 33);
            this.navigator.TabIndex = 8;
            this.navigator.Text = "controlNavigator1";
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTakipTalikErteleme;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(426, 392);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 14;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmTakipTalikNedenleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTakipTalikErteleme);
            this.Name = "frmTakipTalikNedenleri";
            this.Text = "Takip Erteleme Nedenleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTakipTalikErteleme)).EndInit();
            this.panelTakipTalikErteleme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTakipTalikErteleme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rCb_TakipTalikGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTakipTalikErteleme;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTakipTalikErteleme;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ControlNavigator navigator;
        private DevExpress.XtraGrid.Columns.GridColumn GRUP;
        private DevExpress.XtraGrid.Columns.GridColumn NEDEN;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit16;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rCb_TakipTalikGrup;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
    }
}