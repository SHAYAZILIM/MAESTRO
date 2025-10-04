namespace AVPTransfer
{
    partial class frmCheck
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbExistTables = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbNotExistTables = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExistTables.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotExistTables.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cmbExistTables);
            this.panelControl1.Controls.Add(this.cmbNotExistTables);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(685, 45);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlString = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(5, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 30);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Kaynakta olup boş geçilemeyenler";
            // 
            // labelControl1
            // 
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(341, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 30);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Kaynakta olmayıp boş geçilemeyenler";
            // 
            // cmbExistTables
            // 
            this.cmbExistTables.AllowDrop = true;
            this.cmbExistTables.Location = new System.Drawing.Point(105, 17);
            this.cmbExistTables.Name = "cmbExistTables";
            this.cmbExistTables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExistTables.Size = new System.Drawing.Size(230, 20);
            this.cmbExistTables.TabIndex = 8;
            this.cmbExistTables.SelectedIndexChanged += new System.EventHandler(this.cmbExistTables_SelectedIndexChanged);
            // 
            // cmbNotExistTables
            // 
            this.cmbNotExistTables.AllowDrop = true;
            this.cmbNotExistTables.Location = new System.Drawing.Point(441, 17);
            this.cmbNotExistTables.Name = "cmbNotExistTables";
            this.cmbNotExistTables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNotExistTables.Size = new System.Drawing.Size(230, 20);
            this.cmbNotExistTables.TabIndex = 8;
            this.cmbNotExistTables.SelectedIndexChanged += new System.EventHandler(this.cmbNotExistTables_SelectedIndexChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(685, 324);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 369);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCheck";
            this.Text = "frmCheck";
            this.Load += new System.EventHandler(this.frmCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbExistTables.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotExistTables.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbNotExistTables;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbExistTables;
    }
}