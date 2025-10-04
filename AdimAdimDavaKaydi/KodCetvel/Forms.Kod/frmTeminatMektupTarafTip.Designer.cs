namespace  AnaForm
{
    partial class frmTeminatMektupTarafTip
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
            this.panelTeminatMektupTarafTipleri = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARAF_TIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox20 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupTarafTipleri)).BeginInit();
            this.panelTeminatMektupTarafTipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox20)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTeminatMektupTarafTipleri
            // 
            this.panelTeminatMektupTarafTipleri.Controls.Add(this.panelControl1);
            this.panelTeminatMektupTarafTipleri.Controls.Add(this.panelControl2);
            this.panelTeminatMektupTarafTipleri.Location = new System.Drawing.Point(19, 52);
            this.panelTeminatMektupTarafTipleri.Name = "panelTeminatMektupTarafTipleri";
            this.panelTeminatMektupTarafTipleri.Size = new System.Drawing.Size(750, 360);
            this.panelTeminatMektupTarafTipleri.TabIndex = 47;
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
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Teminat Mektup Taraf Tipleri";
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
            // sBtnKaydet
            // 
            this.sBtnKaydet.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.sBtnKaydet.Location = new System.Drawing.Point(98, 10);
            this.sBtnKaydet.Name = "sBtnKaydet";
            this.sBtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sBtnKaydet.TabIndex = 7;
            this.sBtnKaydet.Text = "Kaydet";
            this.sBtnKaydet.Click += new System.EventHandler(this.sBtnKaydet_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARAF_TIP});
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Taraf Tipleri Ekleyin";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // TARAF_TIP
            // 
            this.TARAF_TIP.Caption = "Teminat Mektup Taraf Tipi";
            this.TARAF_TIP.ColumnEdit = this.repositoryItemComboBox20;
            this.TARAF_TIP.FieldName = "TARAF_TIP";
            this.TARAF_TIP.Name = "TARAF_TIP";
            this.TARAF_TIP.Visible = true;
            this.TARAF_TIP.VisibleIndex = 0;
            // 
            // repositoryItemComboBox20
            // 
            this.repositoryItemComboBox20.AutoHeight = false;
            this.repositoryItemComboBox20.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox20.Name = "repositoryItemComboBox20";
            // 
            // frmTeminatMektupTarafTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 464);
            this.Controls.Add(this.panelTeminatMektupTarafTipleri);
            this.Name = "frmTeminatMektupTarafTip";
            this.Text = "Teminat Mektup Taraf Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelTeminatMektupTarafTipleri)).EndInit();
            this.panelTeminatMektupTarafTipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox20)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTeminatMektupTarafTipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridTeminatMektupTarafTipler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn TARAF_TIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox20;
        private DevExpress.XtraEditors.SimpleButton sBtnKaydet;
    }
}