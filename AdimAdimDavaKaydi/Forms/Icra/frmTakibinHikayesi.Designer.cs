namespace AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmTakibinHikayesi
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
            this.vgTakibinHikayesi = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rLueHikayeSurec = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowHIKAYE_SUREC_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowISTEKLER = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowACIKLAMA = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgTakibinHikayesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHikayeSurec)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 237);
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
            this.c_pnlContainer.Controls.Add(this.dataNavigatorExtended1);
            this.c_pnlContainer.Controls.Add(this.vgTakibinHikayesi);
            this.c_pnlContainer.Size = new System.Drawing.Size(499, 262);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.vgTakibinHikayesi, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.dataNavigatorExtended1, 0);
            // 
            // vgTakibinHikayesi
            // 
            this.vgTakibinHikayesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgTakibinHikayesi.Location = new System.Drawing.Point(0, 0);
            this.vgTakibinHikayesi.Name = "vgTakibinHikayesi";
            this.vgTakibinHikayesi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueHikayeSurec});
            this.vgTakibinHikayesi.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHIKAYE_SUREC_ID,
            this.rowISTEKLER,
            this.rowACIKLAMA});
            this.vgTakibinHikayesi.Size = new System.Drawing.Size(499, 237);
            this.vgTakibinHikayesi.TabIndex = 10;
            // 
            // rLueHikayeSurec
            // 
            this.rLueHikayeSurec.AutoHeight = false;
            this.rLueHikayeSurec.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueHikayeSurec.Name = "rLueHikayeSurec";
            // 
            // rowHIKAYE_SUREC_ID
            // 
            this.rowHIKAYE_SUREC_ID.Name = "rowHIKAYE_SUREC_ID";
            this.rowHIKAYE_SUREC_ID.Properties.Caption = "Süreç";
            this.rowHIKAYE_SUREC_ID.Properties.FieldName = "HIKAYE_SUREC_ID";
            this.rowHIKAYE_SUREC_ID.Properties.RowEdit = this.rLueHikayeSurec;
            // 
            // rowISTEKLER
            // 
            this.rowISTEKLER.Name = "rowISTEKLER";
            this.rowISTEKLER.Properties.Caption = "İstekler";
            this.rowISTEKLER.Properties.FieldName = "ISTEKLER";
            // 
            // rowACIKLAMA
            // 
            this.rowACIKLAMA.Name = "rowACIKLAMA";
            this.rowACIKLAMA.Properties.Caption = "Açıklama";
            this.rowACIKLAMA.Properties.FieldName = "ACIKLAMA";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 213);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(499, 24);
            this.dataNavigatorExtended1.TabIndex = 11;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // frmTakibinHikayesi
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 262);
            this.Name = "frmTakibinHikayesi";
            this.Text = "Takibin Hikayesi";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgTakibinHikayesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueHikayeSurec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.VGridControl vgTakibinHikayesi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHIKAYE_SUREC_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowISTEKLER;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueHikayeSurec;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowACIKLAMA;
    }
}