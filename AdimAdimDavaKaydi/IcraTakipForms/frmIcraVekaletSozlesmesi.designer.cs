namespace AdimAdimDavaKaydi.GirisEkran
{
    partial class frmIcraVekaletSozlesmesi
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
            this.ucIcraVekaletSozlesmesi1 = new AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraVekaletSozlesmesi();
            this.SuspendLayout();
            // 
            // ucIcraVekaletSozlesmesi1
            // 
            this.ucIcraVekaletSozlesmesi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraVekaletSozlesmesi1.Location = new System.Drawing.Point(0, 0);
            this.ucIcraVekaletSozlesmesi1.MyDataSource = null;
            this.ucIcraVekaletSozlesmesi1.MyIcraFoy = null;
            this.ucIcraVekaletSozlesmesi1.Name = "ucIcraVekaletSozlesmesi1";
            this.ucIcraVekaletSozlesmesi1.Size = new System.Drawing.Size(844, 455);
            this.ucIcraVekaletSozlesmesi1.TabIndex = 0;
            // 
            // frmIcraVekaletSozlesmesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 455);
            this.Controls.Add(this.ucIcraVekaletSozlesmesi1);
            this.Name = "frmIcraVekaletSozlesmesi";
            this.Text = "İcra Vekalet Sözleşmesi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.IcraTakipUserControls.ucIcraVekaletSozlesmesi ucIcraVekaletSozlesmesi1;
    }
}