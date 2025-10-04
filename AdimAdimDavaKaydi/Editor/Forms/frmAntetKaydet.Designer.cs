namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmAntetKaydet
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
            this.ucAntetKaydet1 = new AdimAdimDavaKaydi.Editor.UserControls.ucAntetKaydet();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucAntetKaydet1);
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 658);
            this.c_pnlContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.c_pnlContainer_Paint);
            // 
            // ucAntetKaydet1
            // 
            this.ucAntetKaydet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAntetKaydet1.Location = new System.Drawing.Point(0, 0);

            this.ucAntetKaydet1.Name = "ucAntetKaydet1";
            this.ucAntetKaydet1.Size = new System.Drawing.Size(922, 658);
            this.ucAntetKaydet1.TabIndex = 0;
            // 
            // frmAntetKaydet
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "frmAntetKaydet";
            this.Load += new System.EventHandler(this.frmAntetKaydet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.Editor.UserControls.ucAntetKaydet ucAntetKaydet1;
    }
}
