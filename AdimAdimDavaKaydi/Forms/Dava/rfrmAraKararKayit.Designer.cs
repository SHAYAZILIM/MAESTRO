namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rfrmAraKararKayit
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
            System.Windows.Forms.Label label2;
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.ucAraKarar1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucAraKarar();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.c_lueDosya = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
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
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(632, 479);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 13);
            label2.TabIndex = 169;
            label2.Text = "Dosya :";
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.ucAraKarar1);
            this.clientPanel.Controls.Add(this.panelControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(632, 479);
            this.clientPanel.TabIndex = 2;
            // 
            // ucAraKarar1
            // 
            this.ucAraKarar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAraKarar1.Location = new System.Drawing.Point(0, 47);
            this.ucAraKarar1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ucAraKarar1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucAraKarar1.Name = "ucAraKarar1";
            this.ucAraKarar1.Size = new System.Drawing.Size(632, 432);
            this.ucAraKarar1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(label2);
            this.panelControl1.Controls.Add(this.c_lueDosya);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 47);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Visible = false;
            // 
            // c_lueDosya
            // 
            this.c_lueDosya.Location = new System.Drawing.Point(146, 12);
            this.c_lueDosya.Name = "c_lueDosya";
            this.c_lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_lueDosya.Properties.DisplayMember = "FOY_NO";
            this.c_lueDosya.Properties.ValueMember = "ID";
            this.c_lueDosya.Properties.View = this.searchLookUpEdit1View;
            this.c_lueDosya.Size = new System.Drawing.Size(474, 20);
            this.c_lueDosya.TabIndex = 171;
            this.c_lueDosya.EditValueChanged += new System.EventHandler(this.c_lueDosya_EditValueChanged);
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
            this.colTARIH});
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
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
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
            // colTARIH
            // 
            this.colTARIH.Caption = "Dava Tarihi";
            this.colTARIH.FieldName = "DAVA_TARIHI";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 5;
            // 
            // rfrmAraKararKayit
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 479);
            this.Name = "rfrmAraKararKayit";
            this.Text = "Yeni Ara Karar Kayýt Formu";
            this.Load += new System.EventHandler(this.rfrmAraKararKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucAraKarar ucAraKarar1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit c_lueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colNO;
        private DevExpress.XtraGrid.Columns.GridColumn colGOREV;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
    }
}