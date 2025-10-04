namespace AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmEditoreGonder
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
            this.ucSablonEditoreGonder1 = new AdimAdimDavaKaydi.Editor.UserControls.ucSablonEditoreGonder();
            this.SuspendLayout();
            // 
            // ucSablonEditoreGonder1
            // 
            this.ucSablonEditoreGonder1.AutoSize = true;
            this.ucSablonEditoreGonder1.Foys = null;
            this.ucSablonEditoreGonder1.Location = new System.Drawing.Point(12, 12);
            this.ucSablonEditoreGonder1.MyDataSource = null;
            this.ucSablonEditoreGonder1.Name = "ucSablonEditoreGonder1";
            this.ucSablonEditoreGonder1.SelectedEditor = null;
            this.ucSablonEditoreGonder1.Size = new System.Drawing.Size(310, 106);
            this.ucSablonEditoreGonder1.TabIndex = 0;
            // 
            // frmEditoreGonder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 45);
            this.Controls.Add(this.ucSablonEditoreGonder1);
            this.Name = "frmEditoreGonder";
            this.Text = "Editöre Gönder";
            this.Load += new System.EventHandler(this.frmEditoreGonder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.Editor.UserControls.ucSablonEditoreGonder ucSablonEditoreGonder1;
    }
}