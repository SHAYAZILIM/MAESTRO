namespace  AvukatProLib.Bakim.Firma
{
    partial class frmGrupTanimlama
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
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.vgKullaniciGruplari = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKISA_ADI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMAX_MIN = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.dnKullaniciGruplari = new DevExpress.XtraEditors.DataNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgKullaniciGruplari)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.vgKullaniciGruplari);
            this.groupControl1.Controls.Add(this.dnKullaniciGruplari);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(326, 351);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Kullanıcı Grupları";
            // 
            // vgKullaniciGruplari
            // 
            this.vgKullaniciGruplari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgKullaniciGruplari.Location = new System.Drawing.Point(2, 20);
            this.vgKullaniciGruplari.Name = "vgKullaniciGruplari";
            this.vgKullaniciGruplari.RecordWidth = 153;
            this.vgKullaniciGruplari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.vgKullaniciGruplari.RowHeaderWidth = 162;
            this.vgKullaniciGruplari.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowADI,
            this.rowKISA_ADI,
            this.rowMAX_MIN});
            this.vgKullaniciGruplari.Size = new System.Drawing.Size(322, 305);
            this.vgKullaniciGruplari.TabIndex = 1;
            // 
            // rowADI
            // 
            this.rowADI.Name = "rowADI";
            this.rowADI.Properties.Caption = "ADI";
            this.rowADI.Properties.FieldName = "ADI";
            // 
            // rowKISA_ADI
            // 
            this.rowKISA_ADI.Name = "rowKISA_ADI";
            this.rowKISA_ADI.Properties.Caption = "KISA_ADI";
            this.rowKISA_ADI.Properties.FieldName = "KISA_ADI";
            // 
            // rowMAX_MIN
            // 
            this.rowMAX_MIN.Name = "rowMAX_MIN";
            multiEditorRowProperties3.Caption = "Max";
            multiEditorRowProperties3.FieldName = "MAX_LEVEL";
            multiEditorRowProperties3.RowEdit = this.repositoryItemSpinEdit1;
            multiEditorRowProperties4.Caption = "Min";
            multiEditorRowProperties4.FieldName = "MIN_LEVEL";
            multiEditorRowProperties4.RowEdit = this.repositoryItemSpinEdit1;
            this.rowMAX_MIN.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties3,
            multiEditorRowProperties4});
            // 
            // dnKullaniciGruplari
            // 
            this.dnKullaniciGruplari.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnKullaniciGruplari.Location = new System.Drawing.Point(2, 325);
            this.dnKullaniciGruplari.Name = "dnKullaniciGruplari";
            this.dnKullaniciGruplari.Size = new System.Drawing.Size(322, 24);
            this.dnKullaniciGruplari.TabIndex = 2;
            this.dnKullaniciGruplari.Text = "dataNavigator1";
            // 
            // frmGrupTanimlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 351);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmGrupTanimlama";
            this.Text = "Kullanıcı Grupları";
            this.Load += new System.EventHandler(this.frmGrupTanimlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgKullaniciGruplari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraVerticalGrid.VGridControl vgKullaniciGruplari;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowADI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKISA_ADI;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowMAX_MIN;
        private DevExpress.XtraEditors.DataNavigator dnKullaniciGruplari;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;

    }
}