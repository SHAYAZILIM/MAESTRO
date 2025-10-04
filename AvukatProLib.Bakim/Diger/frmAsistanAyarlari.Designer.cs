namespace  AvukatProLib.Bakim
{
    partial class frmAsistanAyarlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistanAyarlari));
            this.cbKontrol = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsistanAyari = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbKontrol.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbKontrol
            // 
            this.cbKontrol.Enabled = false;
            this.cbKontrol.Location = new System.Drawing.Point(363, 42);
            this.cbKontrol.Name = "cbKontrol";
            this.cbKontrol.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbKontrol.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbKontrol.Properties.Appearance.Options.UseBackColor = true;
            this.cbKontrol.Properties.Appearance.Options.UseFont = true;
            this.cbKontrol.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cbKontrol.Properties.Caption = "Evet ";
            this.cbKontrol.Size = new System.Drawing.Size(62, 23);
            this.cbKontrol.TabIndex = 1;
            this.cbKontrol.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Program Windows Açýlýþýnda Otomatik Olarak Baþlatýlsýn Mý?";
            // 
            // btnAsistanAyari
            // 
            this.btnAsistanAyari.Image = ((System.Drawing.Image)(resources.GetObject("btnAsistanAyari.Image")));
            this.btnAsistanAyari.Location = new System.Drawing.Point(12, 0);
            this.btnAsistanAyari.Name = "btnAsistanAyari";
            this.btnAsistanAyari.Size = new System.Drawing.Size(51, 43);
            this.btnAsistanAyari.TabIndex = 3;
            this.btnAsistanAyari.Tag = "Deðiþtir";
            this.btnAsistanAyari.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmAsistanAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 78);
            this.Controls.Add(this.btnAsistanAyari);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKontrol);
            this.Name = "frmAsistanAyarlari";
            this.Text = "Asistan Ayarlari";
            this.Load += new System.EventHandler(this.frmAsistanAyarlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbKontrol.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit cbKontrol;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAsistanAyari;
    }
}