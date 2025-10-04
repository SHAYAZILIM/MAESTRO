namespace  AdimAdimDavaKaydi.Util
{
    partial class frmInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputBox));
            this.txtDosyaYolu = new DevExpress.XtraEditors.TextEdit();
            this.btnSec = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaYolu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDosyaYolu
            // 
            this.txtDosyaYolu.Location = new System.Drawing.Point(6, 35);
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.Size = new System.Drawing.Size(290, 20);
            this.txtDosyaYolu.TabIndex = 0;
            this.txtDosyaYolu.ToolTipTitle = "Dosya Yolu";
            // 
            // btnSec
            // 
            this.btnSec.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSec.Location = new System.Drawing.Point(297, 35);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(28, 20);
            this.btnSec.TabIndex = 1;
            this.btnSec.Text = "...";
            this.btnSec.ToolTipTitle = "Dosya Yolu Seç";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Lütfen Dosya Yolu Belirtiniz.";
            // 
            // btnTamam
            // 
            this.btnTamam.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnTamam.Location = new System.Drawing.Point(91, 63);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(60, 18);
            this.btnTamam.TabIndex = 3;
            this.btnTamam.Text = "&Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnIptal.Location = new System.Drawing.Point(155, 63);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(60, 18);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "&Ýptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::AdimAdimDavaKaydi.Properties.Resources.folder_previous_22x22;
            this.pictureEdit1.Location = new System.Drawing.Point(0, -5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(39, 39);
            this.pictureEdit1.TabIndex = 4;
            // 
            // frmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 84);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.txtDosyaYolu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInputBox";
            this.Text = "Excel \'e Gönder.";
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaYolu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDosyaYolu;
        private DevExpress.XtraEditors.SimpleButton btnSec;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}