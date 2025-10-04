namespace AdimAdimDavaKaydi.Editor
{
    partial class frmDosyaModulSec
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPopupBelgeleriKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.lueDosya = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAKIP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTag = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Modül Seçiniz:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Dosya Seçiniz:";
            // 
            // btnPopupBelgeleriKaydet
            // 
            this.btnPopupBelgeleriKaydet.Location = new System.Drawing.Point(211, 91);
            this.btnPopupBelgeleriKaydet.Name = "btnPopupBelgeleriKaydet";
            this.btnPopupBelgeleriKaydet.Size = new System.Drawing.Size(70, 23);
            this.btnPopupBelgeleriKaydet.TabIndex = 7;
            this.btnPopupBelgeleriKaydet.Text = "Tamam";
            this.btnPopupBelgeleriKaydet.Click += new System.EventHandler(this.btnPopupBelgeleriKaydet_Click);
            // 
            // lueModul
            // 
            this.lueModul.Location = new System.Drawing.Point(120, 12);
            this.lueModul.Name = "lueModul";
            this.lueModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModul.Size = new System.Drawing.Size(173, 20);
            this.lueModul.TabIndex = 161;
            this.lueModul.EditValueChanged += new System.EventHandler(this.lueModul_EditValueChanged);
            // 
            // lueDosya
            // 
            this.lueDosya.Location = new System.Drawing.Point(120, 52);
            this.lueDosya.Name = "lueDosya";
            this.lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDosya.Properties.DisplayMember = "FOY_NO";
            this.lueDosya.Properties.ValueMember = "ID";
            this.lueDosya.Properties.View = this.gridLookUpEdit1View;
            this.lueDosya.Size = new System.Drawing.Size(173, 20);
            this.lueDosya.TabIndex = 164;
            this.lueDosya.EditValueChanged += new System.EventHandler(this.lueDosya_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFOY_NO,
            this.colADLIYE,
            this.colGOREV,
            this.colNO,
            this.colESAS_NO,
            this.colTAKIP_TARIHI,
            this.colTag});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
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
            // colGOREV
            // 
            this.colGOREV.Caption = "Görev No";
            this.colGOREV.FieldName = "GOREV";
            this.colGOREV.Name = "colGOREV";
            this.colGOREV.Visible = true;
            this.colGOREV.VisibleIndex = 2;
            // 
            // colNO
            // 
            this.colNO.Caption = "Birim No";
            this.colNO.FieldName = "NO";
            this.colNO.Name = "colNO";
            this.colNO.Visible = true;
            this.colNO.VisibleIndex = 3;
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
            // colTag
            // 
            this.colTag.FieldName = "Tag";
            this.colTag.Name = "colTag";
            // 
            // frmDosyaModulSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 137);
            this.Controls.Add(this.lueDosya);
            this.Controls.Add(this.lueModul);
            this.Controls.Add(this.btnPopupBelgeleriKaydet);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmDosyaModulSec";
            this.Text = "frmDosyaModulSec";
            this.Load += new System.EventHandler(this.frmDosyaModulSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPopupBelgeleriKaydet;
        private DevExpress.XtraEditors.LookUpEdit lueModul;
        private DevExpress.XtraEditors.GridLookUpEdit lueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colGOREV;
        private DevExpress.XtraGrid.Columns.GridColumn colNO;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTAKIP_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTag;
    }
}