namespace  AdimAdimDavaKaydi.Util
{
    partial class frmRaporAdi
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
            this.tBoxRaporBasligi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxRaporBasligi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tBoxRaporBasligi
            // 
            this.tBoxRaporBasligi.Location = new System.Drawing.Point(12, 32);
            this.tBoxRaporBasligi.Name = "tBoxRaporBasligi";
            this.tBoxRaporBasligi.Size = new System.Drawing.Size(306, 20);
            this.tBoxRaporBasligi.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Lütfen Rapor Baþlýðý Giriniz";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(162, 58);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Tamam";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(243, 58);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Vazgeç";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(13, 58);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Kaydet";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 4;
            // 
            // frmRaporAdi
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 99);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tBoxRaporBasligi);
            this.MaximumSize = new System.Drawing.Size(338, 126);
            this.MinimumSize = new System.Drawing.Size(338, 126);
            this.Name = "frmRaporAdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rapor Ekraný";
            ((System.ComponentModel.ISupportInitialize)(this.tBoxRaporBasligi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tBoxRaporBasligi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;

    }
}