namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmDegiskenAyar
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
            this.lueDegisken = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueSablon = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ucAvukatBilgisi1 = new AdimAdimDavaKaydi.Editor.UserControls.DegiskenAyar.ucAvukatBilgisi();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.lueDegisken.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSablon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(610, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 526);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 526);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Controls.Add(this.lueSablon);
            this.c_pnlContainer.Controls.Add(this.labelControl1);
            this.c_pnlContainer.Controls.Add(this.labelControl2);
            this.c_pnlContainer.Controls.Add(this.lueDegisken);
            this.c_pnlContainer.Size = new System.Drawing.Size(627, 472);
            this.c_pnlContainer.Controls.SetChildIndex(this.lueDegisken, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.labelControl2, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.labelControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.lueSablon, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
 
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // lueDegisken
            // 
            this.lueDegisken.Location = new System.Drawing.Point(159, 54);
            this.lueDegisken.Name = "lueDegisken";
            this.lueDegisken.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDegisken.Size = new System.Drawing.Size(344, 20);
            this.lueDegisken.TabIndex = 0;
            this.lueDegisken.EditValueChanged += new System.EventHandler(this.lueDegisken_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Degisken";
            // 
            // lueSablon
            // 
            this.lueSablon.Location = new System.Drawing.Point(159, 25);
            this.lueSablon.Name = "lueSablon";
            this.lueSablon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSablon.Size = new System.Drawing.Size(344, 20);
            this.lueSablon.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(64, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Þablon";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ucAvukatBilgisi1);
            this.panelControl1.Location = new System.Drawing.Point(12, 99);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(560, 342);
            this.panelControl1.TabIndex = 2;
            // 
            // ucAvukatBilgisi1
            // 
            this.ucAvukatBilgisi1.Location = new System.Drawing.Point(99, 11);
            this.ucAvukatBilgisi1.Name = "ucAvukatBilgisi1";
            this.ucAvukatBilgisi1.Size = new System.Drawing.Size(392, 326);
            this.ucAvukatBilgisi1.TabIndex = 0;
            // 
            // frmDegiskenAyar
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(627, 526);
            this.Name = "frmDegiskenAyar";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmDegiskenAyar_Load);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            this.c_pnlContainer.PerformLayout();
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.lueDegisken.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSablon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueDegisken;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueSablon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private AdimAdimDavaKaydi.Editor.UserControls.DegiskenAyar.ucAvukatBilgisi ucAvukatBilgisi1;
    }
}