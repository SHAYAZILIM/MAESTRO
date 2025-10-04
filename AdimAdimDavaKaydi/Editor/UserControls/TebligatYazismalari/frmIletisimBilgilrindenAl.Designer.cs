namespace  ImportExportWithSelection.Import
{
    partial class frmIletisimBilgilrindenAl
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.ucIletisimBilgileri1 = new ImportExportWithSelection.ucIletisimBilgileri();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(734, 345);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1, 360);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(821, 12);
            this.simpleButton2.TabIndex = 2;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(0, 0);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(821, 12);
            this.simpleButton3.TabIndex = 2;
            // 
            // ucIletisimBilgileri1
            // 
            this.ucIletisimBilgileri1.Location = new System.Drawing.Point(3, 21);

            this.ucIletisimBilgileri1.Name = "ucIletisimBilgileri1";
            this.ucIletisimBilgileri1.Size = new System.Drawing.Size(816, 318);
            this.ucIletisimBilgileri1.TabIndex = 0;
            // 
            // frmIletisimBilgilrindenAl
            // 
            this.ClientSize = new System.Drawing.Size(823, 371);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.ucIletisimBilgileri1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmIletisimBilgilrindenAl";
            this.Load += new System.EventHandler(this.frmIletisimBilgilrindenAl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucIletisimBilgileri ucIletisimBilgileri1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}