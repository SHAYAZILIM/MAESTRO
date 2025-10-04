namespace AvukatProRaporlar.Raport.Util
{
    partial class frmXGridStyleChooser
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
            this.lsStyles = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.lsStyles)).BeginInit();
            this.SuspendLayout();
            // 
            // lsStyles
            // 
            this.lsStyles.Location = new System.Drawing.Point(2, 3);
            this.lsStyles.Name = "lsStyles";
            this.lsStyles.Size = new System.Drawing.Size(144, 363);
            this.lsStyles.TabIndex = 0;
            // 
            // frmXGridStyleChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 369);
            this.Controls.Add(this.lsStyles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmXGridStyleChooser";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmXGridStyleChooser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lsStyles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lsStyles;
    }
}