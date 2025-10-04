namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmRaporKAydet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaporKAydet));
            this.ucRaporBilgi1 = new AdimAdimDavaKaydi.Editor.UserControls.ucRaporBilgi();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(811, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 602);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 602);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 577);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(828, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(678, 0);
            this.c_btnIptal.Visible = false;
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(753, 0);
            this.c_btnTamam.Visible = false;
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucRaporBilgi1);
            this.c_pnlContainer.Size = new System.Drawing.Size(828, 602);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucRaporBilgi1, 0);
            // 
            // ucRaporBilgi1
            // 
            this.ucRaporBilgi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRaporBilgi1.Location = new System.Drawing.Point(0, 0);
            this.ucRaporBilgi1.MyBelgeDataSource = null;
            this.ucRaporBilgi1.MyDataSource = null;
            this.ucRaporBilgi1.MyDegiskenDataSource = null;
            this.ucRaporBilgi1.MySeciliBelgeDataSource = null;
            this.ucRaporBilgi1.Name = "ucRaporBilgi1";
            this.ucRaporBilgi1.Sender = null;
            this.ucRaporBilgi1.Size = new System.Drawing.Size(828, 577);
            this.ucRaporBilgi1.TabIndex = 0;
            // 
            // frmRaporKAydet
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 602);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRaporKAydet";
            this.Text = "Kaydet";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.Editor.UserControls.ucRaporBilgi ucRaporBilgi1;
    }
}