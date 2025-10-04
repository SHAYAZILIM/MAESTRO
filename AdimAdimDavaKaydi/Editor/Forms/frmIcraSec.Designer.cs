namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmIcraSec
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
            this.ucIcraFoy1 = new AdimAdimDavaKaydi.UserControls.ucIcraFoy();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            this.SuspendLayout();
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.simpleButton2);
            this.c_pnlContainer.Controls.Add(this.simpleButton1);
            this.c_pnlContainer.Controls.Add(this.ucIcraFoy1);
            this.c_pnlContainer.Size = new System.Drawing.Size(942, 580);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucIcraFoy1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.simpleButton1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.simpleButton2, 0);
 
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(959, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(16, 634);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 634);
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
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(900, 532);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 48);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(825, 532);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 48);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Vazgeç";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucIcraFoy1
            // 
            this.ucIcraFoy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraFoy1.Location = new System.Drawing.Point(0, 0);

            this.ucIcraFoy1.Name = "ucIcraFoy1";
            this.ucIcraFoy1.Size = new System.Drawing.Size(942, 580);
            this.ucIcraFoy1.TabIndex = 0;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(711, 2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 5;
            this.simpleButton3.Text = "Yenile";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // frmIcraSec
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 634);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Editor;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.KodFormu;
            this.Name = "frmIcraSec";
            this.Text = "frmIcraSec";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmIcraSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucIcraFoy ucIcraFoy1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}