namespace AdimAdimDavaKaydi.Forms
{
    partial class frmDosyaKimlikBilgileri
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
            this.lcBilgiler = new DevExpress.XtraLayout.LayoutControl();
            this.lueDegisimNedeni = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEsasNo = new DevExpress.XtraEditors.TextEdit();
            this.gcEskiBilgiler = new DevExpress.XtraGrid.GridControl();
            this.bndEskiBilgiler = new System.Windows.Forms.BindingSource(this.components);
            this.gvEskiBilgiler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLI_BIRIM_ADLIYE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_NO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colADLI_BIRIM_GOREV_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUSME_DEGISME_KODU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDegisimNedeni = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueGorev = new DevExpress.XtraEditors.LookUpEdit();
            this.lueNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lueAdliye = new DevExpress.XtraEditors.LookUpEdit();
            this.lcGroupBilgiler = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemAdliye = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemGorev = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemEskiBilgiler = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemEsasNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemDegisimNedeni = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcBilgiler)).BeginInit();
            this.lcBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDegisimNedeni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEskiBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEskiBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEskiBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDegisimNedeni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGorev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAdliye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemEskiBilgiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemEsasNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDegisimNedeni)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 319);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(499, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(349, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(424, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.lcBilgiler);
            this.c_pnlContainer.Size = new System.Drawing.Size(499, 344);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.lcBilgiler, 0);
            // 
            // lcBilgiler
            // 
            this.lcBilgiler.Controls.Add(this.lueDegisimNedeni);
            this.lcBilgiler.Controls.Add(this.txtEsasNo);
            this.lcBilgiler.Controls.Add(this.gcEskiBilgiler);
            this.lcBilgiler.Controls.Add(this.lueGorev);
            this.lcBilgiler.Controls.Add(this.lueNo);
            this.lcBilgiler.Controls.Add(this.lueAdliye);
            this.lcBilgiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcBilgiler.Location = new System.Drawing.Point(0, 0);
            this.lcBilgiler.Name = "lcBilgiler";
            this.lcBilgiler.Root = this.lcGroupBilgiler;
            this.lcBilgiler.Size = new System.Drawing.Size(499, 319);
            this.lcBilgiler.TabIndex = 10;
            this.lcBilgiler.Text = "layoutControl1";
            // 
            // lueDegisimNedeni
            // 
            this.lueDegisimNedeni.Location = new System.Drawing.Point(88, 60);
            this.lueDegisimNedeni.Name = "lueDegisimNedeni";
            this.lueDegisimNedeni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDegisimNedeni.Size = new System.Drawing.Size(399, 20);
            this.lueDegisimNedeni.StyleController = this.lcBilgiler;
            this.lueDegisimNedeni.TabIndex = 10;
            // 
            // txtEsasNo
            // 
            this.txtEsasNo.Location = new System.Drawing.Point(88, 36);
            this.txtEsasNo.Name = "txtEsasNo";
            this.txtEsasNo.Properties.Mask.EditMask = "..../.+";
            this.txtEsasNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtEsasNo.Size = new System.Drawing.Size(399, 20);
            this.txtEsasNo.StyleController = this.lcBilgiler;
            this.txtEsasNo.TabIndex = 9;
            // 
            // gcEskiBilgiler
            // 
            this.gcEskiBilgiler.DataSource = this.bndEskiBilgiler;
            this.gcEskiBilgiler.Location = new System.Drawing.Point(12, 100);
            this.gcEskiBilgiler.MainView = this.gvEskiBilgiler;
            this.gcEskiBilgiler.Name = "gcEskiBilgiler";
            this.gcEskiBilgiler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueAdliye,
            this.rlueNo,
            this.rlueGorev,
            this.rlueDegisimNedeni});
            this.gcEskiBilgiler.Size = new System.Drawing.Size(475, 207);
            this.gcEskiBilgiler.TabIndex = 8;
            this.gcEskiBilgiler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEskiBilgiler});
            // 
            // gvEskiBilgiler
            // 
            this.gvEskiBilgiler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colADLI_BIRIM_ADLIYE_ID,
            this.colADLI_BIRIM_NO_ID,
            this.colADLI_BIRIM_GOREV_ID,
            this.colESAS_NO,
            this.colDUSME_DEGISME_KODU_ID});
            this.gvEskiBilgiler.GridControl = this.gcEskiBilgiler;
            this.gvEskiBilgiler.Name = "gvEskiBilgiler";
            this.gvEskiBilgiler.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colADLI_BIRIM_ADLIYE_ID
            // 
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adli Birim";
            this.colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rlueAdliye;
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 0;
            // 
            // rlueAdliye
            // 
            this.rlueAdliye.AutoHeight = false;
            this.rlueAdliye.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueAdliye.Name = "rlueAdliye";
            // 
            // colADLI_BIRIM_NO_ID
            // 
            this.colADLI_BIRIM_NO_ID.Caption = "İcra Dairesi Şubesi";
            this.colADLI_BIRIM_NO_ID.ColumnEdit = this.rlueNo;
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 1;
            // 
            // rlueNo
            // 
            this.rlueNo.AutoHeight = false;
            this.rlueNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueNo.Name = "rlueNo";
            // 
            // colADLI_BIRIM_GOREV_ID
            // 
            this.colADLI_BIRIM_GOREV_ID.Caption = "İcra Dairesi Adı";
            this.colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rlueGorev;
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 2;
            // 
            // rlueGorev
            // 
            this.rlueGorev.AutoHeight = false;
            this.rlueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueGorev.Name = "rlueGorev";
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.OptionsColumn.AllowEdit = false;
            this.colESAS_NO.OptionsColumn.ReadOnly = true;
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 3;
            // 
            // colDUSME_DEGISME_KODU_ID
            // 
            this.colDUSME_DEGISME_KODU_ID.Caption = "Neden";
            this.colDUSME_DEGISME_KODU_ID.ColumnEdit = this.rlueDegisimNedeni;
            this.colDUSME_DEGISME_KODU_ID.FieldName = "DUSME_DEGISME_KODU_ID";
            this.colDUSME_DEGISME_KODU_ID.Name = "colDUSME_DEGISME_KODU_ID";
            this.colDUSME_DEGISME_KODU_ID.OptionsColumn.AllowEdit = false;
            this.colDUSME_DEGISME_KODU_ID.OptionsColumn.ReadOnly = true;
            this.colDUSME_DEGISME_KODU_ID.Visible = true;
            this.colDUSME_DEGISME_KODU_ID.VisibleIndex = 4;
            // 
            // rlueDegisimNedeni
            // 
            this.rlueDegisimNedeni.AutoHeight = false;
            this.rlueDegisimNedeni.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDegisimNedeni.Name = "rlueDegisimNedeni";
            // 
            // lueGorev
            // 
            this.lueGorev.Location = new System.Drawing.Point(402, 12);
            this.lueGorev.Name = "lueGorev";
            this.lueGorev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGorev.Size = new System.Drawing.Size(85, 20);
            this.lueGorev.StyleController = this.lcBilgiler;
            this.lueGorev.TabIndex = 6;
            // 
            // lueNo
            // 
            this.lueNo.Location = new System.Drawing.Point(319, 12);
            this.lueNo.Name = "lueNo";
            this.lueNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNo.Size = new System.Drawing.Size(79, 20);
            this.lueNo.StyleController = this.lcBilgiler;
            this.lueNo.TabIndex = 5;
            // 
            // lueAdliye
            // 
            this.lueAdliye.Location = new System.Drawing.Point(88, 12);
            this.lueAdliye.Name = "lueAdliye";
            this.lueAdliye.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAdliye.Size = new System.Drawing.Size(227, 20);
            this.lueAdliye.StyleController = this.lcBilgiler;
            this.lueAdliye.TabIndex = 4;
            // 
            // lcGroupBilgiler
            // 
            this.lcGroupBilgiler.CustomizationFormText = "lcGroupBilgiler";
            this.lcGroupBilgiler.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcGroupBilgiler.GroupBordersVisible = false;
            this.lcGroupBilgiler.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemAdliye,
            this.lcItemNo,
            this.lcItemGorev,
            this.lcItemEskiBilgiler,
            this.lcItemEsasNo,
            this.lcItemDegisimNedeni});
            this.lcGroupBilgiler.Location = new System.Drawing.Point(0, 0);
            this.lcGroupBilgiler.Name = "lcGroupBilgiler";
            this.lcGroupBilgiler.Size = new System.Drawing.Size(499, 319);
            this.lcGroupBilgiler.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcGroupBilgiler.Text = "lcGroupBilgiler";
            this.lcGroupBilgiler.TextVisible = false;
            // 
            // lcItemAdliye
            // 
            this.lcItemAdliye.Control = this.lueAdliye;
            this.lcItemAdliye.CustomizationFormText = "lcItemAdliye";
            this.lcItemAdliye.Location = new System.Drawing.Point(0, 0);
            this.lcItemAdliye.Name = "lcItemAdliye";
            this.lcItemAdliye.Size = new System.Drawing.Size(307, 24);
            this.lcItemAdliye.Text = "Adli Birim";
            this.lcItemAdliye.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lcItemNo
            // 
            this.lcItemNo.Control = this.lueNo;
            this.lcItemNo.CustomizationFormText = "No";
            this.lcItemNo.Location = new System.Drawing.Point(307, 0);
            this.lcItemNo.Name = "lcItemNo";
            this.lcItemNo.Size = new System.Drawing.Size(83, 24);
            this.lcItemNo.Text = "No";
            this.lcItemNo.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemNo.TextToControlDistance = 0;
            this.lcItemNo.TextVisible = false;
            // 
            // lcItemGorev
            // 
            this.lcItemGorev.Control = this.lueGorev;
            this.lcItemGorev.CustomizationFormText = "Görev";
            this.lcItemGorev.Location = new System.Drawing.Point(390, 0);
            this.lcItemGorev.Name = "lcItemGorev";
            this.lcItemGorev.Size = new System.Drawing.Size(89, 24);
            this.lcItemGorev.Text = "Görev";
            this.lcItemGorev.TextSize = new System.Drawing.Size(0, 0);
            this.lcItemGorev.TextToControlDistance = 0;
            this.lcItemGorev.TextVisible = false;
            // 
            // lcItemEskiBilgiler
            // 
            this.lcItemEskiBilgiler.Control = this.gcEskiBilgiler;
            this.lcItemEskiBilgiler.CustomizationFormText = "Eski Bilgiler";
            this.lcItemEskiBilgiler.Location = new System.Drawing.Point(0, 72);
            this.lcItemEskiBilgiler.Name = "lcItemEskiBilgiler";
            this.lcItemEskiBilgiler.Size = new System.Drawing.Size(479, 227);
            this.lcItemEskiBilgiler.Text = "Eski Bilgiler";
            this.lcItemEskiBilgiler.TextLocation = DevExpress.Utils.Locations.Top;
            this.lcItemEskiBilgiler.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lcItemEsasNo
            // 
            this.lcItemEsasNo.Control = this.txtEsasNo;
            this.lcItemEsasNo.CustomizationFormText = "Esas No";
            this.lcItemEsasNo.Location = new System.Drawing.Point(0, 24);
            this.lcItemEsasNo.Name = "lcItemEsasNo";
            this.lcItemEsasNo.Size = new System.Drawing.Size(479, 24);
            this.lcItemEsasNo.Text = "Esas No";
            this.lcItemEsasNo.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lcItemDegisimNedeni
            // 
            this.lcItemDegisimNedeni.Control = this.lueDegisimNedeni;
            this.lcItemDegisimNedeni.CustomizationFormText = "Değişim Nedeni";
            this.lcItemDegisimNedeni.Location = new System.Drawing.Point(0, 48);
            this.lcItemDegisimNedeni.Name = "lcItemDegisimNedeni";
            this.lcItemDegisimNedeni.Size = new System.Drawing.Size(479, 24);
            this.lcItemDegisimNedeni.Text = "Değişim Nedeni";
            this.lcItemDegisimNedeni.TextSize = new System.Drawing.Size(72, 13);
            // 
            // frmDosyaKimlikBilgileri
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 344);
            this.Name = "frmDosyaKimlikBilgileri";
            this.Text = "Dosya Kimlik Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcBilgiler)).EndInit();
            this.lcBilgiler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueDegisimNedeni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEsasNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEskiBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndEskiBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEskiBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDegisimNedeni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGorev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemAdliye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemEskiBilgiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemEsasNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemDegisimNedeni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcBilgiler;
        private DevExpress.XtraEditors.LookUpEdit lueDegisimNedeni;
        private DevExpress.XtraEditors.TextEdit txtEsasNo;
        private DevExpress.XtraGrid.GridControl gcEskiBilgiler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEskiBilgiler;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_ADLIYE_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_NO_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo;
        private DevExpress.XtraGrid.Columns.GridColumn colADLI_BIRIM_GOREV_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraEditors.LookUpEdit lueGorev;
        private DevExpress.XtraEditors.LookUpEdit lueNo;
        private DevExpress.XtraEditors.LookUpEdit lueAdliye;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupBilgiler;
        private DevExpress.XtraLayout.LayoutControlItem lcItemAdliye;
        private DevExpress.XtraLayout.LayoutControlItem lcItemNo;
        private DevExpress.XtraLayout.LayoutControlItem lcItemGorev;
        private DevExpress.XtraLayout.LayoutControlItem lcItemEskiBilgiler;
        private DevExpress.XtraLayout.LayoutControlItem lcItemEsasNo;
        private DevExpress.XtraLayout.LayoutControlItem lcItemDegisimNedeni;
        private System.Windows.Forms.BindingSource bndEskiBilgiler;
        private DevExpress.XtraGrid.Columns.GridColumn colDUSME_DEGISME_KODU_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDegisimNedeni;
    }
}