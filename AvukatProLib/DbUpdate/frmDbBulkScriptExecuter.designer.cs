namespace  AvukatProLib.DbUpdate
{
    partial class frmDbBulkScriptExecuter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbBulkScriptExecuter));
            this.lblBasarili = new System.Windows.Forms.Label();
            this.lblBitenleToplam = new System.Windows.Forms.Label();
            this.lblYuzde = new System.Windows.Forms.Label();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnBasla = new System.Windows.Forms.Button();
            this.prgProgres = new System.Windows.Forms.ProgressBar();
            this.bgwSatirSay = new System.ComponentModel.BackgroundWorker();
            this.bgwTextOku = new System.ComponentModel.BackgroundWorker();
            this.txtIslem = new System.Windows.Forms.TextBox();
            this.lblDosyaAciklamasi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBasarili
            // 
            this.lblBasarili.AutoSize = true;
            this.lblBasarili.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBasarili.Location = new System.Drawing.Point(150, 89);
            this.lblBasarili.Name = "lblBasarili";
            this.lblBasarili.Size = new System.Drawing.Size(182, 16);
            this.lblBasarili.TabIndex = 16;
            this.lblBasarili.Text = "Yükseltme Ýþlemi Baþarýlý";
            this.lblBasarili.Visible = false;
            // 
            // lblBitenleToplam
            // 
            this.lblBitenleToplam.Location = new System.Drawing.Point(345, 52);
            this.lblBitenleToplam.Name = "lblBitenleToplam";
            this.lblBitenleToplam.Size = new System.Drawing.Size(125, 13);
            this.lblBitenleToplam.TabIndex = 14;
            this.lblBitenleToplam.Text = "lblToplam";
            this.lblBitenleToplam.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblYuzde
            // 
            this.lblYuzde.AutoSize = true;
            this.lblYuzde.Location = new System.Drawing.Point(218, 52);
            this.lblYuzde.Name = "lblYuzde";
            this.lblYuzde.Size = new System.Drawing.Size(47, 13);
            this.lblYuzde.TabIndex = 15;
            this.lblYuzde.Text = "lblYuzde";
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(345, 89);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(125, 23);
            this.btnIptal.TabIndex = 13;
            this.btnIptal.Text = "Ýptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnBasla
            // 
            this.btnBasla.Location = new System.Drawing.Point(14, 86);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(125, 23);
            this.btnBasla.TabIndex = 12;
            this.btnBasla.Text = "Baþla";
            this.btnBasla.UseVisualStyleBackColor = true;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // prgProgres
            // 
            this.prgProgres.Location = new System.Drawing.Point(12, 26);
            this.prgProgres.Name = "prgProgres";
            this.prgProgres.Size = new System.Drawing.Size(458, 23);
            this.prgProgres.TabIndex = 11;
            // 
            // bgwSatirSay
            // 
            this.bgwSatirSay.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSatirSay_DoWork);
            this.bgwSatirSay.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSatirSay_RunWorkerCompleted);
            // 
            // bgwTextOku
            // 
            this.bgwTextOku.WorkerSupportsCancellation = true;
            this.bgwTextOku.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTextOku_DoWork);
            this.bgwTextOku.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTextOku_RunWorkerCompleted);
            // 
            // txtIslem
            // 
            this.txtIslem.Location = new System.Drawing.Point(5, 115);
            this.txtIslem.Multiline = true;
            this.txtIslem.Name = "txtIslem";
            this.txtIslem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIslem.Size = new System.Drawing.Size(465, 269);
            this.txtIslem.TabIndex = 11;
            // 
            // lblDosyaAciklamasi
            // 
            this.lblDosyaAciklamasi.AutoSize = true;
            this.lblDosyaAciklamasi.Location = new System.Drawing.Point(15, 7);
            this.lblDosyaAciklamasi.Name = "lblDosyaAciklamasi";
            this.lblDosyaAciklamasi.Size = new System.Drawing.Size(0, 13);
            this.lblDosyaAciklamasi.TabIndex = 17;
            // 
            // frmDbBulkScriptExecuter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 394);
            this.Controls.Add(this.lblDosyaAciklamasi);
            this.Controls.Add(this.lblBasarili);
            this.Controls.Add(this.lblBitenleToplam);
            this.Controls.Add(this.prgProgres);
            this.Controls.Add(this.lblYuzde);
            this.Controls.Add(this.btnBasla);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.txtIslem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDbBulkScriptExecuter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avukatpro Veritabaný Yükseltme Aracý";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmDbBulkScriptExecuter_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBitenleToplam;
        private System.Windows.Forms.Label lblYuzde;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.ProgressBar prgProgres;
        private System.ComponentModel.BackgroundWorker bgwSatirSay;
        private System.ComponentModel.BackgroundWorker bgwTextOku;
        private System.Windows.Forms.TextBox txtIslem;
        private System.Windows.Forms.Label lblBasarili;
        private System.Windows.Forms.Label lblDosyaAciklamasi;



    }
}

