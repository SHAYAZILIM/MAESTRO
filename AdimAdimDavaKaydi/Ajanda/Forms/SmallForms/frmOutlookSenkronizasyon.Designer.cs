namespace  AdimAdimDavaKaydi.Ajanda.Forms.SmallForms
{
    partial class frmOutlookSenkronizasyon
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ucAjandaOutlookExport1 = new AdimAdimDavaKaydi.Ajanda.UserControls.ucAjandaOutlookExport();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(335, 121);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ucAjandaOutlookExport1
            // 
            this.ucAjandaOutlookExport1.Location = new System.Drawing.Point(12, 12);
            this.ucAjandaOutlookExport1.Name = "ucAjandaOutlookExport1";
            this.ucAjandaOutlookExport1.Size = new System.Drawing.Size(407, 103);
            this.ucAjandaOutlookExport1.Storage = null;
            this.ucAjandaOutlookExport1.TabIndex = 1;
            // 
            // frmOutlookSenkronizasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 148);
            this.Controls.Add(this.ucAjandaOutlookExport1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmOutlookSenkronizasyon";
            this.Text = "Outlook Senkronizasyonu";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private AdimAdimDavaKaydi.Ajanda.UserControls.ucAjandaOutlookExport ucAjandaOutlookExport1;
    }
}