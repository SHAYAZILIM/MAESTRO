namespace AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmCariTebligTarihiEkleme
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
            this.gcTarihler = new DevExpress.XtraGrid.GridControl();
            this.gvTarihler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTarihler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarihler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTarihler
            // 
            this.gcTarihler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTarihler.Location = new System.Drawing.Point(0, 0);
            this.gcTarihler.MainView = this.gvTarihler;
            this.gcTarihler.Name = "gcTarihler";
            this.gcTarihler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCari});
            this.gcTarihler.Size = new System.Drawing.Size(527, 248);
            this.gcTarihler.TabIndex = 0;
            this.gcTarihler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTarihler});
            // 
            // gvTarihler
            // 
            this.gvTarihler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvTarihler.GridControl = this.gcTarihler;
            this.gvTarihler.Name = "gvTarihler";
            this.gvTarihler.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "İlgili";
            this.gridColumn1.ColumnEdit = this.rlueCari;
            this.gridColumn1.FieldName = "CARI_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 236;
            // 
            // rlueCari
            // 
            this.rlueCari.AutoHeight = false;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Açıklama";
            this.gridColumn3.FieldName = "ACIKLAMA";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 161;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tebliğ Tarihi";
            this.gridColumn2.FieldName = "TEBLIG_TARIHI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 109;
            // 
            // sbtnKaydet
            // 
            this.sbtnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sbtnKaydet.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnKaydet.Appearance.Options.UseFont = true;
            this.sbtnKaydet.Appearance.Options.UseForeColor = true;
            this.sbtnKaydet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbtnKaydet.Location = new System.Drawing.Point(0, 248);
            this.sbtnKaydet.Name = "sbtnKaydet";
            this.sbtnKaydet.Size = new System.Drawing.Size(527, 23);
            this.sbtnKaydet.TabIndex = 1;
            this.sbtnKaydet.Text = "KAYDET";
            this.sbtnKaydet.Click += new System.EventHandler(this.sbtnKaydet_Click);
            // 
            // frmCariTebligTarihiEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 271);
            this.Controls.Add(this.gcTarihler);
            this.Controls.Add(this.sbtnKaydet);
            this.Name = "frmCariTebligTarihiEkleme";
            this.Text = "Tebliğ Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.gcTarihler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarihler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTarihler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTarihler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton sbtnKaydet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
    }
}