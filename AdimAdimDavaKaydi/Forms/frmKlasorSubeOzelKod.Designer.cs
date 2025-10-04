namespace AdimAdimDavaKaydi.Forms
{
    partial class frmKlasorSubeOzelKod
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
            this.txtOzelKod = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtOzelKod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOzelKod
            // 
            this.txtOzelKod.Location = new System.Drawing.Point(12, 12);
            this.txtOzelKod.Name = "txtOzelKod";
            this.txtOzelKod.Size = new System.Drawing.Size(206, 20);
            this.txtOzelKod.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(183, 51);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmKlasorSubeOzelKod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 86);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtOzelKod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKlasorSubeOzelKod";
            this.Text = "Şube Ekleme";
            ((System.ComponentModel.ISupportInitialize)(this.txtOzelKod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOzelKod;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}