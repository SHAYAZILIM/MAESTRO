namespace  AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    partial class ucDegiskenBicimlendirme
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = global::AdimAdimDavaKaydi.Properties.Resources.kapat_16x162;
            this.simpleButton3.Location = new System.Drawing.Point(95, 26);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(27, 26);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Kiþi Renklerini Ayarla";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.degistir_22x221;
            this.simpleButton1.Location = new System.Drawing.Point(69, 26);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(27, 26);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Kiþi Renklerini Ayarla";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::AdimAdimDavaKaydi.Properties.Resources.kapat_16x162;
            this.simpleButton2.Location = new System.Drawing.Point(95, 1);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(27, 26);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Kiþi Renklerini Ayarla";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucDegiskenBicimlendirme
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton3);
            this.Name = "ucDegiskenBicimlendirme";
            this.Size = new System.Drawing.Size(124, 54);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
