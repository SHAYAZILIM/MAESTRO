namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmTumsablonlar
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
            this.ucSablonRapor1 = new AdimAdimDavaKaydi.UserControls.ucSablonRapor();
            this.SuspendLayout();
            // 
            // ucSablonRapor1
            // 
            this.ucSablonRapor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSablonRapor1.Location = new System.Drawing.Point(0, 0);

            this.ucSablonRapor1.Name = "ucSablonRapor1";
            this.ucSablonRapor1.Size = new System.Drawing.Size(737, 547);
            this.ucSablonRapor1.TabIndex = 0;
            // 
            // frmTumsablonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 547);
            this.Controls.Add(this.ucSablonRapor1);
            this.Name = "frmTumsablonlar";
            this.Text = "Sistemde Kayýtlý Þablonlar";
            this.Load += new System.EventHandler(this.frmTumsablonlar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public AdimAdimDavaKaydi.UserControls.ucSablonRapor ucSablonRapor1;

    }
}