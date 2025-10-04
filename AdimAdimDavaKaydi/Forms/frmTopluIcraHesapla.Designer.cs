namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmTopluIcraHesapla
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rMemoAciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnHesapla = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.ceKaydet = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceKaydet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rMemoAciklama});
            this.gridControl1.Size = new System.Drawing.Size(400, 229);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Dosya No";
            this.gridColumn1.FieldName = "FoyNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 105;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Durum";
            this.gridColumn2.FieldName = "Durum";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 33;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Açýklama";
            this.gridColumn3.ColumnEdit = this.rMemoAciklama;
            this.gridColumn3.FieldName = "Aciklama";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 158;
            // 
            // rMemoAciklama
            // 
            this.rMemoAciklama.AutoHeight = false;
            this.rMemoAciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rMemoAciklama.Name = "rMemoAciklama";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // btnHesapla
            // 
            this.btnHesapla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHesapla.Location = new System.Drawing.Point(314, 248);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(98, 23);
            this.btnHesapla.TabIndex = 1;
            this.btnHesapla.Text = "Hesapla";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(13, 248);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(295, 49);
            this.progressBarControl1.TabIndex = 2;
            // 
            // ceKaydet
            // 
            this.ceKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ceKaydet.Location = new System.Drawing.Point(328, 277);
            this.ceKaydet.Name = "ceKaydet";
            this.ceKaydet.Properties.Caption = "Kaydet";
            this.ceKaydet.Size = new System.Drawing.Size(75, 19);
            this.ceKaydet.TabIndex = 3;
            this.ceKaydet.CheckedChanged += new System.EventHandler(this.ceKaydet_CheckedChanged);
            // 
            // frmTopluIcraHesapla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 302);
            this.Controls.Add(this.ceKaydet);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.btnHesapla);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmTopluIcraHesapla";
            this.Text = "frmTopluIcraHesapla";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rMemoAciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceKaydet.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit rMemoAciklama;
        private DevExpress.XtraEditors.SimpleButton btnHesapla;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.CheckEdit ceKaydet;
    }
}