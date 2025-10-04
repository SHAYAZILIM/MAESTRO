namespace  AvukatProImageEditor
{
    partial class XtraForm1
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
            this.textControl1 = new TXTextControl.TextControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(12, 12);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(758, 556);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(526, 595);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(244, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(254, 595);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(244, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "simpleButton1";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(254, 566);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(112, 23);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "simpleButton1";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(24, 595);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(112, 23);
            this.simpleButton4.TabIndex = 1;
            this.simpleButton4.Text = "simpleButton1";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 630);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textControl1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}