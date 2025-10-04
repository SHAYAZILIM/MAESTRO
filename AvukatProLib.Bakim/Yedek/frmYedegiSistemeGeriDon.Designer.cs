namespace  AvukatProLib.Bakim
{
    partial class frmYedegiSistemeGeriDon
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grpYedekAl = new DevExpress.XtraEditors.GroupControl();
            this.beDosya = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grpYedekAl)).BeginInit();
            this.grpYedekAl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDosya.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpYedekAl
            // 
            this.grpYedekAl.Controls.Add(this.beDosya);
            this.grpYedekAl.Controls.Add(this.labelControl1);
            this.grpYedekAl.Controls.Add(this.btnRestore);
            this.grpYedekAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpYedekAl.Location = new System.Drawing.Point(0, 0);
            this.grpYedekAl.Name = "grpYedekAl";
            this.grpYedekAl.Size = new System.Drawing.Size(426, 110);
            this.grpYedekAl.TabIndex = 4;
            // 
            // beDosya
            // 
            this.beDosya.Location = new System.Drawing.Point(64, 24);
            this.beDosya.Name = "beDosya";
            this.beDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "new", null, true)});
            this.beDosya.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.beDosya.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beDosya.Size = new System.Drawing.Size(355, 20);
            this.beDosya.TabIndex = 5;
            this.beDosya.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDosya_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Dosya:";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(344, 50);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 20);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmYedegiSistemeGeriDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 110);
            this.Controls.Add(this.grpYedekAl);
            this.Name = "frmYedegiSistemeGeriDon";
            this.Text = "Yedeði Sisteme Geri Don";
            this.Load += new System.EventHandler(this.frmYedegiSistemeGeriDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpYedekAl)).EndInit();
            this.grpYedekAl.ResumeLayout(false);
            this.grpYedekAl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDosya.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpYedekAl;
        private DevExpress.XtraEditors.ButtonEdit beDosya;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}