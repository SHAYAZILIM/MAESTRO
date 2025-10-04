namespace  AdimAdimDavaKaydi
{
    partial class frmIcraIlamMahkemesiGiris
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
            this.ucIlamMahkemesi1 = new AdimAdimDavaKaydi.ucIlamMahkemesi();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.glueDosya = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.glueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(1060, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 434);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 434);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 409);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1028, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(878, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(953, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucIlamMahkemesi1);
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(1028, 434);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucIlamMahkemesi1, 0);
            // 
            // ucIlamMahkemesi1
            // 
            this.ucIlamMahkemesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIlamMahkemesi1.Location = new System.Drawing.Point(0, 31);
            this.ucIlamMahkemesi1.MyDataSource = null;
            this.ucIlamMahkemesi1.Name = "ucIlamMahkemesi1";
            this.ucIlamMahkemesi1.Size = new System.Drawing.Size(1028, 378);
            this.ucIlamMahkemesi1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.glueDosya);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1028, 31);
            this.panelControl1.TabIndex = 10;
            this.panelControl1.Visible = false;
            // 
            // glueDosya
            // 
            this.glueDosya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glueDosya.Location = new System.Drawing.Point(2, 2);
            this.glueDosya.Name = "glueDosya";
            this.glueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueDosya.Properties.View = this.gridLookUpEdit1View;
            this.glueDosya.Size = new System.Drawing.Size(1024, 20);
            this.glueDosya.TabIndex = 0;
            this.glueDosya.EditValueChanged += new System.EventHandler(this.glueDosya_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmIcraIlamMahkemesiGiris
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 434);
            this.Name = "frmIcraIlamMahkemesiGiris";
            this.Text = "Ilam Giriþi";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmIcraIlamMahkemesiGiris_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIcraIlamMahkemesiGiris_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.glueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucIlamMahkemesi ucIlamMahkemesi1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit glueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}