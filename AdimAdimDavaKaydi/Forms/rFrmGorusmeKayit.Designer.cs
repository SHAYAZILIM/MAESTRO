namespace  AdimAdimDavaKaydi.Forms
{
    partial class rFrmGorusmeKayit
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            this.ucGorusmeKayit1 = new AdimAdimDavaKaydi.UserControls.ucGorusmeKayit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.c_lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.c_lueDosya = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAKIP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(615, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 479);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 479);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 454);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(632, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(482, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(557, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucGorusmeKayit1);
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(632, 479);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucGorusmeKayit1, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 12);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 13);
            label5.TabIndex = 176;
            label5.Text = "Modül :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 13);
            label2.TabIndex = 177;
            label2.Text = "Dosya :";
            // 
            // ucGorusmeKayit1
            // 
            this.ucGorusmeKayit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorusmeKayit1.Location = new System.Drawing.Point(0, 52);
            this.ucGorusmeKayit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucGorusmeKayit1.MyDataSource = null;
            this.ucGorusmeKayit1.Name = "ucGorusmeKayit1";
            this.ucGorusmeKayit1.Size = new System.Drawing.Size(632, 402);
            this.ucGorusmeKayit1.TabIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.c_lueModul);
            this.panelControl1.Controls.Add(label5);
            this.panelControl1.Controls.Add(label2);
            this.panelControl1.Controls.Add(this.c_lueDosya);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 52);
            this.panelControl1.TabIndex = 10;
            this.panelControl1.Visible = false;
            // 
            // c_lueModul
            // 
            this.c_lueModul.Location = new System.Drawing.Point(142, 5);
            this.c_lueModul.Name = "c_lueModul";
            this.c_lueModul.Size = new System.Drawing.Size(154, 20);
            this.c_lueModul.TabIndex = 178;
            // 
            // c_lueDosya
            // 
            this.c_lueDosya.Enabled = false;
            this.c_lueDosya.Location = new System.Drawing.Point(142, 26);
            this.c_lueDosya.Name = "c_lueDosya";
            this.c_lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_lueDosya.Properties.DisplayMember = "FOY_NO";
            this.c_lueDosya.Properties.ValueMember = "ID";
            this.c_lueDosya.Properties.View = this.searchLookUpEdit1View;
            this.c_lueDosya.Size = new System.Drawing.Size(487, 20);
            this.c_lueDosya.TabIndex = 179;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFOY_NO,
            this.colADLIYE,
            this.colNO,
            this.colGOREV,
            this.colESAS_NO,
            this.colTAKIP_TARIHI});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.searchLookUpEdit1View.GroupPanelText = "Gruplamak için bir alan sürükleyiniz...";
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.Editable = false;
            this.searchLookUpEdit1View.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.searchLookUpEdit1View.OptionsFilter.UseNewCustomFilterDialog = true;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupedColumns = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.FixedWidth = true;
            // 
            // colFOY_NO
            // 
            this.colFOY_NO.Caption = "Dosya No";
            this.colFOY_NO.FieldName = "FOY_NO";
            this.colFOY_NO.Name = "colFOY_NO";
            this.colFOY_NO.Visible = true;
            this.colFOY_NO.VisibleIndex = 0;
            // 
            // colADLIYE
            // 
            this.colADLIYE.Caption = "Adliye";
            this.colADLIYE.FieldName = "ADLIYE";
            this.colADLIYE.Name = "colADLIYE";
            this.colADLIYE.Visible = true;
            this.colADLIYE.VisibleIndex = 1;
            // 
            // colNO
            // 
            this.colNO.Caption = "No";
            this.colNO.FieldName = "NO";
            this.colNO.Name = "colNO";
            this.colNO.Visible = true;
            this.colNO.VisibleIndex = 3;
            // 
            // colGOREV
            // 
            this.colGOREV.Caption = "Görev No";
            this.colGOREV.FieldName = "GOREV";
            this.colGOREV.Name = "colGOREV";
            this.colGOREV.Visible = true;
            this.colGOREV.VisibleIndex = 2;
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 4;
            // 
            // colTAKIP_TARIHI
            // 
            this.colTAKIP_TARIHI.Caption = "Takip Tarihi";
            this.colTAKIP_TARIHI.FieldName = "TAKIP_TARIHI";
            this.colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            this.colTAKIP_TARIHI.Visible = true;
            this.colTAKIP_TARIHI.VisibleIndex = 5;
            // 
            // rFrmGorusmeKayit
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 479);
            this.Name = "rFrmGorusmeKayit";
            this.Text = "Görüþme Kayýt formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmGorusmeKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colNO;
        private DevExpress.XtraGrid.Columns.GridColumn colGOREV;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTAKIP_TARIHI;
        public UserControls.ucGorusmeKayit ucGorusmeKayit1;
        public DevExpress.XtraEditors.LookUpEdit c_lueModul;
        public DevExpress.XtraEditors.SearchLookUpEdit c_lueDosya;
        
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
    }
}