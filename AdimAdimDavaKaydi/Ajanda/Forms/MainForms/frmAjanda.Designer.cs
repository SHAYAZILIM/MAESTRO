namespace  AdimAdimDavaKaydi.Ajanda.Forms.MainForms
{
    partial class frmAjanda
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
            this.ucIsAjanda1 = new AdimAdimDavaKaydi.Ajanda.UserControls.ucIsAjanda();
            this.SuspendLayout();
            // 
            // ucIsAjanda1
            // 
            this.ucIsAjanda1.Data = null;
            this.ucIsAjanda1.DataSource = null;
            this.ucIsAjanda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIsAjanda1.Location = new System.Drawing.Point(0, 55);
            this.ucIsAjanda1.Name = "ucIsAjanda1";
            this.ucIsAjanda1.OpenedRecord = null;
            this.ucIsAjanda1.Size = new System.Drawing.Size(676, 445);
            this.ucIsAjanda1.TabIndex = 0;
            // 
            // frmAjanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 500);
            this.Controls.Add(this.ucIsAjanda1);
            this.Name = "frmAjanda";
            this.Text = "Ajanda";
            this.Load += new System.EventHandler(this.frmAjanda_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Ajanda.UserControls.ucIsAjanda ucIsAjanda1;

    }
}