namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucKayitYardim
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtYardim = new DevExpress.XtraEditors.MemoEdit();
            this.image = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYardim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtYardim);
            this.groupControl1.Controls.Add(this.image);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(649, 109);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "[Yardim Konusu]";
            // 
            // txtYardim
            // 
            this.txtYardim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYardim.Location = new System.Drawing.Point(89, 20);
            this.txtYardim.Name = "txtYardim";
            this.txtYardim.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYardim.Properties.Appearance.Options.UseFont = true;
            this.txtYardim.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtYardim.Size = new System.Drawing.Size(558, 87);
            this.txtYardim.TabIndex = 2;
            // 
            // image
            // 
            this.image.Dock = System.Windows.Forms.DockStyle.Left;
            this.image.Location = new System.Drawing.Point(2, 20);
            this.image.Name = "image";
            this.image.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.image.Size = new System.Drawing.Size(87, 87);
            this.image.TabIndex = 1;
            // 
            // ucKayitYardim
            // 
            this.Controls.Add(this.groupControl1);
            this.Name = "ucKayitYardim";
            this.Size = new System.Drawing.Size(649, 109);
            this.Load += new System.EventHandler(this.ucKayitYardim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtYardim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit txtYardim;
        private DevExpress.XtraEditors.PictureEdit image;
    }
}
