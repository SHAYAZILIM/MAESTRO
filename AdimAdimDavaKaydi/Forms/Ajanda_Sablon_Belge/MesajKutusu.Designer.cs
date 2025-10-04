namespace  AdimAdimDavaKaydi
{
    partial class MesajKutusu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesajKutusu));
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkTumu = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTumu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(241, 144);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(86, 24);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "simpleButton1";
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(436, 144);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(86, 24);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "simpleButton2";
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(29, 144);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(86, 24);
            this.btn3.TabIndex = 0;
            this.btn3.Text = "simpleButton1";
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(127, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(424, 52);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(114, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(437, 27);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = resources.GetString("labelControl2.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 77);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chkTumu
            // 
            this.chkTumu.Location = new System.Drawing.Point(27, 119);
            this.chkTumu.Name = "chkTumu";
            this.chkTumu.Properties.Caption = "Tümü için Bu seçeneði Uygula";
            this.chkTumu.Size = new System.Drawing.Size(290, 19);
            this.chkTumu.TabIndex = 7;
            // 
            // MesajKutusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 180);
            this.Controls.Add(this.chkTumu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "MesajKutusu";
            this.Opacity = 0.95;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTumu.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private  DevExpress.XtraEditors.SimpleButton btn1;
        private  DevExpress.XtraEditors.SimpleButton btn2;
        private DevExpress.XtraEditors.SimpleButton btn3;
        private  DevExpress.XtraEditors.LabelControl labelControl1;
        private  DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.CheckEdit chkTumu;
    }
}