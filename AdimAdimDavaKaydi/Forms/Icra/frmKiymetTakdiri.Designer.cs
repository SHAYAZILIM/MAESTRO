namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class frmKiymetTakdiri
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
            this.ucKiymetTakdiri1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKiymetTakdiri();
            
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
            this.c_pnlContainer.Controls.Add(this.ucKiymetTakdiri1);
            this.c_pnlContainer.Size = new System.Drawing.Size(767, 455);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucKiymetTakdiri1, 0);
 
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(784, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 509);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 509);
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
            // ucKiymetTakdiri1
            // 
            this.ucKiymetTakdiri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiymetTakdiri1.Location = new System.Drawing.Point(0, 0);


            this.ucKiymetTakdiri1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucKiymetTakdiri1.Name = "ucKiymetTakdiri1";
            this.ucKiymetTakdiri1.Size = new System.Drawing.Size(767, 455);
            this.ucKiymetTakdiri1.TabIndex = 0;
            // 
            // frmKiymetTakdiri
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 509);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Icra;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.KayitFormu;
            this.Name = "frmKiymetTakdiri";
            this.Text = "Kýymet Takdiri Kayýt Formu";
            this.UstMenu = true;
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucKiymetTakdiri ucKiymetTakdiri1;
    }
}