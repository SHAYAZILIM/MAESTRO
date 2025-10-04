namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmDosyaAc
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ucDosyaAc1 = new AdimAdimDavaKaydi.Editor.UserControls.ucDosyaAc();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucDosyaAc1);
            this.c_pnlContainer.Controls.Add(this.simpleButton2);
            this.c_pnlContainer.Controls.Add(this.simpleButton1);
            this.c_pnlContainer.Size = new System.Drawing.Size(550, 357);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(567, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 411);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 411);
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton1.Location = new System.Drawing.Point(0, 334);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(550, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Dosyadan Aç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(0, 311);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(550, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Tamam";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ucDosyaAc1
            // 
            this.ucDosyaAc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDosyaAc1.Filter = new DevExpress.XtraGrid.Views.Base.ViewColumnFilterInfo[0];
            this.ucDosyaAc1.Location = new System.Drawing.Point(0, 0);
            this.ucDosyaAc1.MyParent = null;
            this.ucDosyaAc1.Name = "ucDosyaAc1";
            this.ucDosyaAc1.SelectedRecord = null;
            this.ucDosyaAc1.SelectedrecordInfo = null;
            this.ucDosyaAc1.Size = new System.Drawing.Size(550, 311);
            this.ucDosyaAc1.TabIndex = 0;
            // 
            // frmDosyaAc
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Name = "frmDosyaAc";
            this.Text = "frmDosyaAc";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmDosyaAc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.Editor.UserControls.ucDosyaAc ucDosyaAc1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}