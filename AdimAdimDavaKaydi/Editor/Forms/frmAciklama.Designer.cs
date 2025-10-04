namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmAciklama
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
            this.ucGrupDegiskenAciklama1 = new AdimAdimDavaKaydi.Editor.UserControls.ucGrupDegiskenAciklama();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucGrupDegiskenAciklama1);
            this.c_pnlContainer.Size = new System.Drawing.Size(588, 353);
 
            this.c_pnlContainer.Controls.SetChildIndex(this.ucGrupDegiskenAciklama1, 0);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(598, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(10, 407);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(10, 407);
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
            // ucGrupDegiskenAciklama1
            // 
            this.ucGrupDegiskenAciklama1.Location = new System.Drawing.Point(7, 6);
            this.ucGrupDegiskenAciklama1.Name = "ucGrupDegiskenAciklama1";
            this.ucGrupDegiskenAciklama1.Size = new System.Drawing.Size(575, 317);
            this.ucGrupDegiskenAciklama1.TabIndex = 0;
            // 
            // frmAciklama
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 407);
            this.Name = "frmAciklama";
            this.Text = "Açýklama";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmAciklama_Load);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.Editor.UserControls.ucGrupDegiskenAciklama ucGrupDegiskenAciklama1;
    }
}