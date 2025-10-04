namespace AvukatProRaporlar.Forms
{
    partial class frmKullaniciTanimliKaydet
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tBoxRaporAdi = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.rGKayitTipi = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cBoxGrup = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBoxRaporAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGKayitTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBoxGrup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tBoxRaporAdi);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(192, 40);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Rapor Adı";
            // 
            // tBoxRaporAdi
            // 
            this.tBoxRaporAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxRaporAdi.Location = new System.Drawing.Point(2, 20);
            this.tBoxRaporAdi.Name = "tBoxRaporAdi";
            this.tBoxRaporAdi.Size = new System.Drawing.Size(188, 20);
            this.tBoxRaporAdi.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(48, 162);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(129, 162);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 4;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // rGKayitTipi
            // 
            this.rGKayitTipi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGKayitTipi.EditValue = true;
            this.rGKayitTipi.Location = new System.Drawing.Point(2, 20);
            this.rGKayitTipi.Name = "rGKayitTipi";
            this.rGKayitTipi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Genel"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Özel")});
            this.rGKayitTipi.Size = new System.Drawing.Size(188, 28);
            this.rGKayitTipi.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rGKayitTipi);
            this.groupControl2.Location = new System.Drawing.Point(12, 58);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(192, 50);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Kullanım";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cBoxGrup);
            this.groupControl3.Location = new System.Drawing.Point(12, 114);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(192, 42);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Grubu";
            // 
            // cBoxGrup
            // 
            this.cBoxGrup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxGrup.Location = new System.Drawing.Point(2, 20);
            this.cBoxGrup.Name = "cBoxGrup";
            this.cBoxGrup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cBoxGrup.Size = new System.Drawing.Size(188, 20);
            this.cBoxGrup.TabIndex = 0;
            // 
            // frmKullaniciTanimliKaydet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 201);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullaniciTanimliKaydet";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmKullaniciTanimliKaydet";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBoxRaporAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGKayitTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cBoxGrup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.RadioGroup rGKayitTipi;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cBoxGrup;
        private DevExpress.XtraEditors.TextEdit tBoxRaporAdi;
    }
}