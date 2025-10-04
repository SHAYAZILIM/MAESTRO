namespace AvukatPro.Outlook
{
    partial class frmMailSettings
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdAttachs = new System.Windows.Forms.RadioButton();
            this.chkAttachs = new System.Windows.Forms.CheckedListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(154, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Mail Dosyası Olarak Kaydet";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdAttachs
            // 
            this.rdAttachs.AutoSize = true;
            this.rdAttachs.Location = new System.Drawing.Point(13, 37);
            this.rdAttachs.Name = "rdAttachs";
            this.rdAttachs.Size = new System.Drawing.Size(124, 17);
            this.rdAttachs.TabIndex = 1;
            this.rdAttachs.Text = "Ekli Dosyaları Kaydet";
            this.rdAttachs.UseVisualStyleBackColor = true;
            this.rdAttachs.CheckedChanged += new System.EventHandler(this.rdAttachs_CheckedChanged);
            // 
            // chkAttachs
            // 
            this.chkAttachs.Enabled = false;
            this.chkAttachs.FormattingEnabled = true;
            this.chkAttachs.Location = new System.Drawing.Point(13, 61);
            this.chkAttachs.Name = "chkAttachs";
            this.chkAttachs.Size = new System.Drawing.Size(493, 109);
            this.chkAttachs.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(431, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Tamam";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmMailSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 203);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkAttachs);
            this.Controls.Add(this.rdAttachs);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMailSettings";
            this.ShowIcon = false;
            this.Text = "Kayıt Seçenekleri";
            this.Load += new System.EventHandler(this.frmMailSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdAttachs;
        private System.Windows.Forms.CheckedListBox chkAttachs;
        private System.Windows.Forms.Button btnOk;
    }
}