namespace  AvukatProEditorDegisken
{
    partial class frmDegiskenler
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
            this.gcDegiskenler = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFORM_TIPI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueFormTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDOVIZ_ISLEM_TIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDislemTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDOVIZLI_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYTL_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAIZ_YOK_MU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTALEP_ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mmAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGeri = new DevExpress.XtraEditors.SimpleButton();
            this.btnIleri = new DevExpress.XtraEditors.SimpleButton();
            this.gcAlacakKalemleri = new DevExpress.XtraGrid.GridControl();
            this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colALACAK_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAlacak = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataNavigator2 = new DevExpress.XtraEditors.DataNavigator();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDegiskenler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueFormTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDislemTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakKalemleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDegiskenler
            // 
            this.gcDegiskenler.DataSource = this.bindingSource1;
            this.gcDegiskenler.Location = new System.Drawing.Point(12, 30);
            this.gcDegiskenler.MainView = this.gridView1;
            this.gcDegiskenler.Name = "gcDegiskenler";
            this.gcDegiskenler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueDislemTipi,
            this.rlueFormTipi});
            this.gcDegiskenler.Size = new System.Drawing.Size(733, 307);
            this.gcDegiskenler.TabIndex = 0;
            this.gcDegiskenler.UseEmbeddedNavigator = true;
            this.gcDegiskenler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AvukatProLib2.Entities.TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN);
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFORM_TIPI_ID,
            this.colDOVIZ_ISLEM_TIPI,
            this.colDOVIZLI_MI,
            this.colYTL_MI,
            this.colFAIZ_YOK_MU,
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI,
            this.colTALEP_ACIKLAMA,
            this.colACIKLAMA,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gcDegiskenler;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PreviewFieldName = "ACIKLAMA";
            // 
            // colFORM_TIPI_ID
            // 
            this.colFORM_TIPI_ID.Caption = "Form Tipi";
            this.colFORM_TIPI_ID.ColumnEdit = this.rlueFormTipi;
            this.colFORM_TIPI_ID.FieldName = "FORM_TIPI_ID";
            this.colFORM_TIPI_ID.Name = "colFORM_TIPI_ID";
            this.colFORM_TIPI_ID.Visible = true;
            this.colFORM_TIPI_ID.VisibleIndex = 0;
            this.colFORM_TIPI_ID.Width = 89;
            // 
            // rlueFormTipi
            // 
            this.rlueFormTipi.AutoHeight = false;
            this.rlueFormTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueFormTipi.Name = "rlueFormTipi";
            // 
            // colDOVIZ_ISLEM_TIPI
            // 
            this.colDOVIZ_ISLEM_TIPI.Caption = "Döviz Ýþlem Tipi";
            this.colDOVIZ_ISLEM_TIPI.ColumnEdit = this.rlueDislemTipi;
            this.colDOVIZ_ISLEM_TIPI.FieldName = "DOVIZ_ISLEM_TIPI";
            this.colDOVIZ_ISLEM_TIPI.Name = "colDOVIZ_ISLEM_TIPI";
            this.colDOVIZ_ISLEM_TIPI.Visible = true;
            this.colDOVIZ_ISLEM_TIPI.VisibleIndex = 1;
            this.colDOVIZ_ISLEM_TIPI.Width = 101;
            // 
            // rlueDislemTipi
            // 
            this.rlueDislemTipi.AutoHeight = false;
            this.rlueDislemTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDislemTipi.Name = "rlueDislemTipi";
            // 
            // colDOVIZLI_MI
            // 
            this.colDOVIZLI_MI.Caption = "Dövizli mi";
            this.colDOVIZLI_MI.FieldName = "DOVIZLI_MI";
            this.colDOVIZLI_MI.Name = "colDOVIZLI_MI";
            this.colDOVIZLI_MI.Visible = true;
            this.colDOVIZLI_MI.VisibleIndex = 2;
            this.colDOVIZLI_MI.Width = 67;
            // 
            // colYTL_MI
            // 
            this.colYTL_MI.Caption = "TL mi";
            this.colYTL_MI.FieldName = "YTL_MI";
            this.colYTL_MI.Name = "colYTL_MI";
            this.colYTL_MI.Visible = true;
            this.colYTL_MI.VisibleIndex = 3;
            this.colYTL_MI.Width = 47;
            // 
            // colFAIZ_YOK_MU
            // 
            this.colFAIZ_YOK_MU.Caption = "Faiz Yok";
            this.colFAIZ_YOK_MU.FieldName = "FAIZ_YOK_MU";
            this.colFAIZ_YOK_MU.Name = "colFAIZ_YOK_MU";
            this.colFAIZ_YOK_MU.Visible = true;
            this.colFAIZ_YOK_MU.VisibleIndex = 4;
            this.colFAIZ_YOK_MU.Width = 68;
            // 
            // colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI
            // 
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.Caption = "Veya";
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.FieldName = "ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI";
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.Name = "colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI";
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.Visible = true;
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.VisibleIndex = 5;
            this.colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI.Width = 49;
            // 
            // colTALEP_ACIKLAMA
            // 
            this.colTALEP_ACIKLAMA.Caption = "Talep Açýklamasý";
            this.colTALEP_ACIKLAMA.FieldName = "TALEP_ACIKLAMA";
            this.colTALEP_ACIKLAMA.Name = "colTALEP_ACIKLAMA";
            this.colTALEP_ACIKLAMA.Width = 111;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Açýklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Width = 180;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ýlama Faiz Ýþlemiþmi";
            this.gridColumn1.FieldName = "ILAMA_FAIZ_ISLEMIS_MI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 127;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Her Aya Nafaka Ýþlemiþmi";
            this.gridColumn2.FieldName = "HER_AYA_NAFAKA_ISLEMIS_MI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 122;
            // 
            // mmAciklama
            // 
            this.mmAciklama.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "ACIKLAMA", true));
            this.mmAciklama.Location = new System.Drawing.Point(12, 393);
            this.mmAciklama.Name = "mmAciklama";
            this.mmAciklama.Size = new System.Drawing.Size(936, 107);
            this.mmAciklama.TabIndex = 1;
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(12, 1);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(75, 23);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(670, 1);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(174, 1);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(75, 23);
            this.btnGeri.TabIndex = 2;
            this.btnGeri.Text = "Geri Al";
            // 
            // btnIleri
            // 
            this.btnIleri.Location = new System.Drawing.Point(255, 1);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(75, 23);
            this.btnIleri.TabIndex = 2;
            this.btnIleri.Text = "Ýleri Al";
            // 
            // gcAlacakKalemleri
            // 
            this.gcAlacakKalemleri.DataSource = this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource;
            this.gcAlacakKalemleri.Location = new System.Drawing.Point(751, 30);
            this.gcAlacakKalemleri.MainView = this.gridView2;
            this.gcAlacakKalemleri.Name = "gcAlacakKalemleri";
            this.gcAlacakKalemleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAlacak});
            this.gcAlacakKalemleri.Size = new System.Drawing.Size(197, 287);
            this.gcAlacakKalemleri.TabIndex = 3;
            this.gcAlacakKalemleri.UseEmbeddedNavigator = true;
            this.gcAlacakKalemleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource
            // 
            this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource.DataMember = "NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KODCollection";
            this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource.DataSource = this.bindingSource1;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colALACAK_NEDEN_ID});
            this.gridView2.GridControl = this.gcAlacakKalemleri;
            this.gridView2.Name = "gridView2";
            // 
            // colALACAK_NEDEN_ID
            // 
            this.colALACAK_NEDEN_ID.Caption = "Alacak Nedeni";
            this.colALACAK_NEDEN_ID.ColumnEdit = this.rlueAlacak;
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.Visible = true;
            this.colALACAK_NEDEN_ID.VisibleIndex = 0;
            // 
            // rlueAlacak
            // 
            this.rlueAlacak.AutoHeight = false;
            this.rlueAlacak.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAlacak.Name = "rlueAlacak";
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.DataSource = this.bindingSource1;
            this.dataNavigator1.Location = new System.Drawing.Point(12, 506);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(936, 24);
            this.dataNavigator1.TabIndex = 4;
            this.dataNavigator1.Text = "dataNavigator1";
            // 
            // tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource
            // 
            this.tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource.DataMember = "TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD";
            this.tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource.DataSource = this.bindingSource1;
            // 
            // dataNavigator2
            // 
            this.dataNavigator2.DataSource = this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource;
            this.dataNavigator2.Location = new System.Drawing.Point(749, 323);
            this.dataNavigator2.Name = "dataNavigator2";
            this.dataNavigator2.Size = new System.Drawing.Size(199, 19);
            this.dataNavigator2.TabIndex = 5;
            this.dataNavigator2.Text = "dataNavigator2";
            // 
            // memoEdit1
            // 
            this.memoEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "TALEP_ACIKLAMA", true));
            this.memoEdit1.Location = new System.Drawing.Point(12, 343);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(936, 44);
            this.memoEdit1.TabIndex = 1;
            // 
            // frmDegiskenler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 532);
            this.Controls.Add(this.dataNavigator2);
            this.Controls.Add(this.dataNavigator1);
            this.Controls.Add(this.gcAlacakKalemleri);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.mmAciklama);
            this.Controls.Add(this.gcDegiskenler);
            this.Name = "frmDegiskenler";
            this.Text = "frmDegiskenler";
            this.Load += new System.EventHandler(this.frmDegiskenler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDegiskenler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueFormTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDislemTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlacakKalemleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAlacak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDegiskenler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit mmAciklama;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGeri;
        private DevExpress.XtraEditors.SimpleButton btnIleri;
        private DevExpress.XtraGrid.GridControl gcAlacakKalemleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colFORM_TIPI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDOVIZ_ISLEM_TIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colDOVIZLI_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colYTL_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colFAIZ_YOK_MU;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI;
        private DevExpress.XtraGrid.Columns.GridColumn colTALEP_ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private System.Windows.Forms.BindingSource nNTALEPACIKLAMADEGISKENALACAKNEDENKODCollectionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDEN_ID;
        private System.Windows.Forms.BindingSource tIKODALACAKNEDENCollectionFromNNTALEPACIKLAMADEGISKENALACAKNEDENKODBindingSource;
        private DevExpress.XtraEditors.DataNavigator dataNavigator2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDislemTipi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAlacak;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueFormTipi;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}