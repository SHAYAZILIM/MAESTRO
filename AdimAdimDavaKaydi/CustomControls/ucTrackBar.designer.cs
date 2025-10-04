namespace  AdimAdimDavaKaydi
{
    partial class ucTrackBar
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
            this.tkBar = new DevExpress.XtraEditors.TrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.tkBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tkBar
            // 
            this.tkBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tkBar.EditValue = null;
            this.tkBar.Location = new System.Drawing.Point(0, 0);
            this.tkBar.Name = "tkBar";
            this.tkBar.Properties.Maximum = 3;
            this.tkBar.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkBar.Properties.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tkBar.Size = new System.Drawing.Size(41, 143);
            this.tkBar.TabIndex = 0;
            // 
            // ucTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tkBar);
            this.Name = "ucTrackBar";
            this.Size = new System.Drawing.Size(41, 143);
            this.Load += new System.EventHandler(this.ucTrackBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tkBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TrackBarControl tkBar;
    }
}
