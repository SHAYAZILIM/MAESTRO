namespace AdimAdimDavaKaydi
{
    partial class frmOnaySifreKontrolu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOnaySifreKontrolu));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnDevam = new DevExpress.XtraEditors.SimpleButton();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnVazgec);
            this.groupControl1.Controls.Add(this.btnDevam);
            this.groupControl1.Controls.Add(this.txtSifre);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.pictureBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(350, 135);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            this.groupControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Down);
            this.groupControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move);
            this.groupControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(182, 100);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 4;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnDevam
            // 
            this.btnDevam.Location = new System.Drawing.Point(263, 100);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(75, 23);
            this.btnDevam.TabIndex = 3;
            this.btnDevam.Text = "Devam";
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(182, 52);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(156, 20);
            this.txtSifre.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(89, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Değiştirme Şifresi :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 72);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmOnaySifreKontrolu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 135);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOnaySifreKontrolu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmOnaySifreKontrolu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOnaySifreKontrolu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnDevam;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}