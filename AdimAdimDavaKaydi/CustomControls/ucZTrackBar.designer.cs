namespace  AdimAdimDavaKaydi
{
    partial class ucZTrackBar
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
            this.zoomTrackBarControl1 = new DevExpress.XtraEditors.ZoomTrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomTrackBarControl1
            // 
            this.zoomTrackBarControl1.EditValue = null;
            this.zoomTrackBarControl1.Location = new System.Drawing.Point(0, 0);
            this.zoomTrackBarControl1.Name = "zoomTrackBarControl1";
            this.zoomTrackBarControl1.Properties.Maximum = 1;
            this.zoomTrackBarControl1.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBarControl1.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.zoomTrackBarControl1.Size = new System.Drawing.Size(18, 87);
            this.zoomTrackBarControl1.TabIndex = 4;
            // 
            // ucZTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zoomTrackBarControl1);
            this.Name = "ucZTrackBar";
            this.Size = new System.Drawing.Size(17, 87);
            this.Load += new System.EventHandler(this.ucZTrackBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl1;
    }
}
