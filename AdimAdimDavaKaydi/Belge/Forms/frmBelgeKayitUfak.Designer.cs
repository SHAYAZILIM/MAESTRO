namespace  AdimAdimDavaKaydi.Belge.Forms
{
    partial class frmBelgeKayitUfak
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
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBelgeKayitUfak));
            this.ucBelgeKayitUfak1 = new AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak();
            this.SuspendLayout();
            // 
            // ucBelgeKayitUfak1
            // 
            this.ucBelgeKayitUfak1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBelgeKayitUfak1.Duzenle = false;
            this.ucBelgeKayitUfak1.FileName = ((System.Collections.Generic.List<string>)(resources.GetObject("ucBelgeKayitUfak1.FileName")));
            this.ucBelgeKayitUfak1.HatirlatilcakIs = null;
            this.ucBelgeKayitUfak1.InForm = false;
            this.ucBelgeKayitUfak1.Location = new System.Drawing.Point(0, 0);
            this.ucBelgeKayitUfak1.MyDataSource = null;
            this.ucBelgeKayitUfak1.Name = "ucBelgeKayitUfak1";
            this.ucBelgeKayitUfak1.OpenedRecord = null;
            this.ucBelgeKayitUfak1.Position = -1;
            this.ucBelgeKayitUfak1.Record = null;
            this.ucBelgeKayitUfak1.Size = new System.Drawing.Size(784, 619);
            this.ucBelgeKayitUfak1.TabIndex = 0;
            // 
            // frmBelgeKayitUfak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.ucBelgeKayitUfak1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBelgeKayitUfak";
            this.Text = "Belge Kaydý";
            this.ResumeLayout(false);

        }

        #endregion

        public AdimAdimDavaKaydi.Belge.UserControls.ucBelgeKayitUfak ucBelgeKayitUfak1;
    }
}