namespace  AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    partial class ucDavaTalep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridDavaTalep = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.tDKODDAVATALEPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gwDavaTalep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colADLI_BIRIM_BOLUM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueAdliBirimBolumKod = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDAVA_TALEP = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaTalep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDKODDAVATALEPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaTalep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolumKod)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(298, 455);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Sil";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(400, 455);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridDavaTalep
            // 
            this.gridDavaTalep.DataSource = this.tDKODDAVATALEPBindingSource;
            this.gridDavaTalep.EmbeddedNavigator.Name = "";
            this.gridDavaTalep.Location = new System.Drawing.Point(0, 3);
            this.gridDavaTalep.MainView = this.gwDavaTalep;
            this.gridDavaTalep.Name = "gridDavaTalep";
            this.gridDavaTalep.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAdliBirimBolumKod});
            this.gridDavaTalep.Size = new System.Drawing.Size(743, 446);
            this.gridDavaTalep.TabIndex = 2;
            this.gridDavaTalep.UseEmbeddedNavigator = true;
            this.gridDavaTalep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDavaTalep});
            // 
            // tDKODDAVATALEPBindingSource
            // 
            this.tDKODDAVATALEPBindingSource.DataSource = typeof(AvukatProLib2.Entities.TD_KOD_DAVA_TALEP);
            // 
            // gwDavaTalep
            // 
            this.gwDavaTalep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colADLI_BIRIM_BOLUM_ID,
            this.colDAVA_TALEP});
            this.gwDavaTalep.GridControl = this.gridDavaTalep;
            this.gwDavaTalep.Name = "gwDavaTalep";
            this.gwDavaTalep.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwDavaTalep.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDavaTalep.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDavaTalep.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDavaTalep.OptionsView.ColumnAutoWidth = false;
            this.gwDavaTalep.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwDavaTalep.OptionsView.ShowAutoFilterRow = true;
            this.gwDavaTalep.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDavaTalep.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // colADLI_BIRIM_BOLUM_ID
            // 
            this.colADLI_BIRIM_BOLUM_ID.Caption = "Adli Birim Bölüm Kod";
            this.colADLI_BIRIM_BOLUM_ID.ColumnEdit = this.rLueAdliBirimBolumKod;
            this.colADLI_BIRIM_BOLUM_ID.FieldName = "ADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Name = "colADLI_BIRIM_BOLUM_ID";
            this.colADLI_BIRIM_BOLUM_ID.Visible = true;
            this.colADLI_BIRIM_BOLUM_ID.VisibleIndex = 0;
            // 
            // rLueAdliBirimBolumKod
            // 
            this.rLueAdliBirimBolumKod.AutoHeight = false;
            this.rLueAdliBirimBolumKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAdliBirimBolumKod.Name = "rLueAdliBirimBolumKod";
            // 
            // colDAVA_TALEP
            // 
            this.colDAVA_TALEP.Caption = "Dava Talep";
            this.colDAVA_TALEP.FieldName = "DAVA_TALEP";
            this.colDAVA_TALEP.Name = "colDAVA_TALEP";
            this.colDAVA_TALEP.Visible = true;
            this.colDAVA_TALEP.VisibleIndex = 1;
            // 
            // ucDavaTalep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaTalep);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "ucDavaTalep";
            this.Size = new System.Drawing.Size(749, 481);
            this.Load += new System.EventHandler(this.ucDavaTalep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaTalep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDKODDAVATALEPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaTalep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAdliBirimBolumKod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaTalep;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDavaTalep;
        private System.Windows.Forms.BindingSource tDKODDAVATALEPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_BOLUM_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDAVA_TALEP;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAdliBirimBolumKod;
    }
}
