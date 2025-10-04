namespace  ImportExportWithSelection.Import
{
    partial class frmUcuncuSahisBilgileri
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
            this.bbtnCarilerden = new DevExpress.XtraEditors.SimpleButton();
            this.bbtnBankaSubelerinden = new DevExpress.XtraEditors.SimpleButton();
            this.bbtnIletisinBilgilerinden = new DevExpress.XtraEditors.SimpleButton();
            this.bbtnExcelDen = new DevExpress.XtraEditors.SimpleButton();
            this.bbtnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ucCariArama1 = new AdimAdimDavaKaydi.UserControls.ucCariAlt();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bbtnCarilerden
            // 
            this.bbtnCarilerden.Location = new System.Drawing.Point(12, 14);
            this.bbtnCarilerden.Name = "bbtnCarilerden";
            this.bbtnCarilerden.Size = new System.Drawing.Size(134, 23);
            this.bbtnCarilerden.TabIndex = 2;
            this.bbtnCarilerden.Text = "Þahýstan Seç";
            this.bbtnCarilerden.Click += new System.EventHandler(this.bbtnCarilerden_Click);
            // 
            // bbtnBankaSubelerinden
            // 
            this.bbtnBankaSubelerinden.Location = new System.Drawing.Point(12, 43);
            this.bbtnBankaSubelerinden.Name = "bbtnBankaSubelerinden";
            this.bbtnBankaSubelerinden.Size = new System.Drawing.Size(134, 23);
            this.bbtnBankaSubelerinden.TabIndex = 2;
            this.bbtnBankaSubelerinden.Text = "Banka Þubelerinden Getir";
            this.bbtnBankaSubelerinden.Click += new System.EventHandler(this.bbtnBankaSubelerinden_Click);
            // 
            // bbtnIletisinBilgilerinden
            // 
            this.bbtnIletisinBilgilerinden.Location = new System.Drawing.Point(177, 14);
            this.bbtnIletisinBilgilerinden.Name = "bbtnIletisinBilgilerinden";
            this.bbtnIletisinBilgilerinden.Size = new System.Drawing.Size(132, 23);
            this.bbtnIletisinBilgilerinden.TabIndex = 2;
            this.bbtnIletisinBilgilerinden.Text = "Ýletiþim Bilgilerinden Getir";
            this.bbtnIletisinBilgilerinden.Click += new System.EventHandler(this.button4_Click);
            // 
            // bbtnExcelDen
            // 
            this.bbtnExcelDen.Location = new System.Drawing.Point(177, 43);
            this.bbtnExcelDen.Name = "bbtnExcelDen";
            this.bbtnExcelDen.Size = new System.Drawing.Size(132, 23);
            this.bbtnExcelDen.TabIndex = 2;
            this.bbtnExcelDen.Text = "Excel Dosyasýndan Getir";
            this.bbtnExcelDen.Click += new System.EventHandler(this.button1_Click);
            // 
            // bbtnTamam
            // 
            this.bbtnTamam.Location = new System.Drawing.Point(177, 72);
            this.bbtnTamam.Name = "bbtnTamam";
            this.bbtnTamam.Size = new System.Drawing.Size(132, 23);
            this.bbtnTamam.TabIndex = 2;
            this.bbtnTamam.Text = "Tamam";
            this.bbtnTamam.Click += new System.EventHandler(this.bbtnTamam_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bbtnIletisinBilgilerinden);
            this.panelControl1.Controls.Add(this.bbtnTamam);
            this.panelControl1.Controls.Add(this.bbtnCarilerden);
            this.panelControl1.Controls.Add(this.bbtnExcelDen);
            this.panelControl1.Controls.Add(this.bbtnBankaSubelerinden);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(337, 143);
            this.panelControl1.TabIndex = 3;
            // 
            // ucCariArama1
            // 
            this.ucCariArama1.Location = new System.Drawing.Point(0, 271);
            this.ucCariArama1.MyDataSource = null;
            this.ucCariArama1.Name = "ucCariArama1";
            this.ucCariArama1.Size = new System.Drawing.Size(712, 25);
            this.ucCariArama1.TabIndex = 0;
            this.ucCariArama1.Visible = false;
            // 
            // frmUcuncuSahisBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 144);
            this.Controls.Add(this.ucCariArama1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmUcuncuSahisBilgileri";
            this.Text = "Üçüncü Þahýs Bilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucCariAlt ucCariArama1;
        private DevExpress.XtraEditors.SimpleButton bbtnCarilerden;
        private DevExpress.XtraEditors.SimpleButton bbtnBankaSubelerinden;
        private DevExpress.XtraEditors.SimpleButton bbtnIletisinBilgilerinden;
        private DevExpress.XtraEditors.SimpleButton bbtnExcelDen;
        private DevExpress.XtraEditors.SimpleButton bbtnTamam;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}