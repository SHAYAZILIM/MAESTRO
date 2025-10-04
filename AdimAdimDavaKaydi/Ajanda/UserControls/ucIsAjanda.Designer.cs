namespace  AdimAdimDavaKaydi.Ajanda.UserControls
{
    partial class ucIsAjanda
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucAjanda1 = new AdimAdimDavaKaydi.Ajanda.UserControls.ucAjanda();
            this.SuspendLayout();
            // 
            // ucAjanda1
            // 
            this.ucAjanda1.Data = null;
            this.ucAjanda1.DataSource = null;
            this.ucAjanda1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAjanda1.Location = new System.Drawing.Point(0, 0);
            this.ucAjanda1.Name = "ucAjanda1";
            this.ucAjanda1.OpenedRecord = null;
            this.ucAjanda1.Size = new System.Drawing.Size(1035, 594);
            this.ucAjanda1.TabIndex = 0;
            // 
            // ucIsAjanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucAjanda1);
            this.Name = "ucIsAjanda";
            this.Size = new System.Drawing.Size(1035, 594);
            this.Click += new System.EventHandler(this.ucIsAjanda_Click);
            this.ResumeLayout(false);

        }

        #endregion

        public ucAjanda ucAjanda1;

    }
}
