namespace  AnaForm
{
    partial class frmTebligatAnaTur
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
            this.panelTebligatAnaTur = new DevExpress.XtraEditors.PanelControl();
            this.gridTebligatAnaTur = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ANA_TUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit20 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAnaTur)).BeginInit();
            this.panelTebligatAnaTur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAnaTur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTebligatAnaTur
            // 
            this.panelTebligatAnaTur.Controls.Add(this.gridTebligatAnaTur);
            this.panelTebligatAnaTur.Controls.Add(this.panelControl1);
            this.panelTebligatAnaTur.Controls.Add(this.panelControl2);
            this.panelTebligatAnaTur.Location = new System.Drawing.Point(10, 46);
            this.panelTebligatAnaTur.Name = "panelTebligatAnaTur";
            this.panelTebligatAnaTur.Size = new System.Drawing.Size(750, 360);
            this.panelTebligatAnaTur.TabIndex = 16;
            // 
            // gridTebligatAnaTur
            // 
            this.gridTebligatAnaTur.CustomButtonlarGorunmesin = false;
            this.gridTebligatAnaTur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTebligatAnaTur.DoNotExtendEmbedNavigator = false;
            this.gridTebligatAnaTur.FilterText = null;
            this.gridTebligatAnaTur.FilterValue = null;
            this.gridTebligatAnaTur.GridlerDuzenlenebilir = true;
            this.gridTebligatAnaTur.GridsFilterControl = null;
            this.gridTebligatAnaTur.Location = new System.Drawing.Point(2, 72);
            this.gridTebligatAnaTur.MainView = this.gridView1;
            this.gridTebligatAnaTur.MyGridStyle = null;
            this.gridTebligatAnaTur.Name = "gridTebligatAnaTur";
            this.gridTebligatAnaTur.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit20});
            this.gridTebligatAnaTur.ShowRowNumbers = false;
            this.gridTebligatAnaTur.Size = new System.Drawing.Size(746, 286);
            this.gridTebligatAnaTur.TabIndex = 5;
            this.gridTebligatAnaTur.TemizleKaldirGorunsunmu = false;
            this.gridTebligatAnaTur.UniqueId = "4f023c29-e270-4d08-a11c-67b285bd2d3a";
            this.gridTebligatAnaTur.UseEmbeddedNavigator = true;
            this.gridTebligatAnaTur.UseHyperDragDrop = false;
            this.gridTebligatAnaTur.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ANA_TUR});
            this.gridView1.GridControl = this.gridTebligatAnaTur;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Tebligat Ana Tür Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // ANA_TUR
            // 
            this.ANA_TUR.Caption = "Tebligat Ana Tür";
            this.ANA_TUR.ColumnEdit = this.repositoryItemTextEdit20;
            this.ANA_TUR.FieldName = "ANA_TUR";
            this.ANA_TUR.Name = "ANA_TUR";
            this.ANA_TUR.Visible = true;
            this.ANA_TUR.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit20
            // 
            this.repositoryItemTextEdit20.AutoHeight = false;
            this.repositoryItemTextEdit20.Name = "repositoryItemTextEdit20";
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
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tebligat Ana Tür Kodlarý";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.sBtnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridTebligatAnaTur;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(434, 411);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 17;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(69, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // frmTebligatAnaTur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 453);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelTebligatAnaTur);
            this.Name = "frmTebligatAnaTur";
            this.Text = "Tebligat Ana Türü";
            ((System.ComponentModel.ISupportInitialize)(this.panelTebligatAnaTur)).EndInit();
            this.panelTebligatAnaTur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTebligatAnaTur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTebligatAnaTur;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTebligatAnaTur;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn ANA_TUR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit20;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}