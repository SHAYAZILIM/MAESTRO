namespace  AvukatProLib.Bakim
{
    partial class frmVeriTabaniKontrol
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
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.IcbVeriTabani = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.rlkDbler = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rwVeriTabani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.crDurumMesaj = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IcbVeriTabani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDbler)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl1
            // 
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.IcbVeriTabani,
            this.rlkDbler});
            this.vGridControl1.RowHeaderWidth = 284;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rwVeriTabani,
            this.crDurumMesaj});
            this.vGridControl1.Size = new System.Drawing.Size(523, 217);
            this.vGridControl1.TabIndex = 0;
            // 
            // IcbVeriTabani
            // 
            this.IcbVeriTabani.AutoHeight = false;
            this.IcbVeriTabani.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IcbVeriTabani.Name = "IcbVeriTabani";
            // 
            // rlkDbler
            // 
            this.rlkDbler.AutoHeight = false;
            this.rlkDbler.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkDbler.Name = "rlkDbler";
            // 
            // rwVeriTabani
            // 
            this.rwVeriTabani.Height = 19;
            this.rwVeriTabani.Name = "rwVeriTabani";
            this.rwVeriTabani.Properties.Caption = "Ýncelenecek Veri Tabaný Seçiniz ";
            this.rwVeriTabani.Properties.FieldName = "IncelenecekVeriTabani";
            this.rwVeriTabani.Properties.RowEdit = this.rlkDbler;
            // 
            // crDurumMesaj
            // 
            this.crDurumMesaj.Name = "crDurumMesaj";
            this.crDurumMesaj.Properties.Caption = "Veri Tabani Durumu Henüz Ýncelenmedi ...";
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator1.Location = new System.Drawing.Point(0, 217);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(523, 24);
            this.dataNavigator1.TabIndex = 1;
            this.dataNavigator1.Text = "dataNavigator1";
            // 
            // frmVeriTabaniKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 241);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.dataNavigator1);
            this.Name = "frmVeriTabaniKontrol";
            this.Text = "Veri Tabani Hata Kontrol";
            this.Load += new System.EventHandler(this.frmVeriTabaniKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IcbVeriTabani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkDbler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit IcbVeriTabani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwVeriTabani;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkDbler;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crDurumMesaj;
    }
}