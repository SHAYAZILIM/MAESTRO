namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmBorcluMalKaydetVGrid
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
            this.ucBorcluMalBilgileri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucBorcluMalBilgileri();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucBorcluMalBilgileri1);
            this.c_pnlContainer.Size = new System.Drawing.Size(888, 604);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucBorcluMalBilgileri1, 0);
 
            // 
            // c_pnlAltButtons
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
            // ucBorcluMalBilgileri1
            // 
            this.ucBorcluMalBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBorcluMalBilgileri1.FocusedIndex = 0;
            this.ucBorcluMalBilgileri1.Location = new System.Drawing.Point(0, 0);


            this.ucBorcluMalBilgileri1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucBorcluMalBilgileri1.Name = "ucBorcluMalBilgileri1";
            this.ucBorcluMalBilgileri1.ShowOnlyGridControl = false;
            this.ucBorcluMalBilgileri1.Size = new System.Drawing.Size(888, 604);
            this.ucBorcluMalBilgileri1.TabIndex = 0;
            // 
            // frmBorcluMalKaydetVGrid
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "frmBorcluMalKaydetVGrid";
            this.Text = "Borçlunun Mal Bilgileri Kayýt Formu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmBorcluMalKaydetVGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucBorcluMalBilgileri ucBorcluMalBilgileri1;
    }
}