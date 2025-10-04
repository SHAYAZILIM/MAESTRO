namespace AdimAdimDavaKaydi.Forms
{
    partial class frmKrediBorclusuSec
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
            this.gcKrediBrclulari = new DevExpress.XtraGrid.GridControl();
            this.gvKrediBorclulari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bndSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcKrediBrclulari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKrediBorclulari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gcKrediBrclulari
            // 
            this.gcKrediBrclulari.DataSource = this.bndSource;
            this.gcKrediBrclulari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcKrediBrclulari.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcKrediBrclulari.Location = new System.Drawing.Point(0, 0);
            this.gcKrediBrclulari.MainView = this.gvKrediBorclulari;
            this.gcKrediBrclulari.Name = "gcKrediBrclulari";
            this.gcKrediBrclulari.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueCari});
            this.gcKrediBrclulari.Size = new System.Drawing.Size(306, 262);
            this.gcKrediBrclulari.TabIndex = 0;
            this.gcKrediBrclulari.UseEmbeddedNavigator = true;
            this.gcKrediBrclulari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKrediBorclulari});
            // 
            // gvKrediBorclulari
            // 
            this.gvKrediBorclulari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvKrediBorclulari.GridControl = this.gcKrediBrclulari;
            this.gvKrediBorclulari.Name = "gvKrediBorclulari";
            this.gvKrediBorclulari.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kredi Borçlusu";
            this.gridColumn1.ColumnEdit = this.rlueCari;
            this.gridColumn1.FieldName = "KREDI_BORCLUSU_CARI_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // rlueCari
            // 
            this.rlueCari.AutoHeight = false;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // frmKrediBorclusuSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 262);
            this.Controls.Add(this.gcKrediBrclulari);
            this.Name = "frmKrediBorclusuSec";
            this.Text = "KREDİ BOÇLUSU SEÇME EKRANI";
            ((System.ComponentModel.ISupportInitialize)(this.gcKrediBrclulari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKrediBorclulari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcKrediBrclulari;
        private DevExpress.XtraGrid.Views.Grid.GridView gvKrediBorclulari;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private System.Windows.Forms.BindingSource bndSource;
    }
}