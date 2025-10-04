namespace  AvukatProLib.Bakim
{
    partial class frmYedekAl
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
            this.beDosyaYolu = new DevExpress.XtraEditors.ButtonEdit();
            this.btnBackUp = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDosyaAdý = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grpYedekAl)).BeginInit();
            this.grpYedekAl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDosyaYolu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaAdý.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpYedekAl
            // 
            this.grpYedekAl.Controls.Add(this.beDosyaYolu);
            this.grpYedekAl.Controls.Add(this.btnBackUp);
            this.grpYedekAl.Controls.Add(this.labelControl2);
            this.grpYedekAl.Controls.Add(this.txtDosyaAdý);
            this.grpYedekAl.Controls.Add(this.labelControl1);
            this.grpYedekAl.Controls.Add(this.labelControl3);
            this.grpYedekAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpYedekAl.Location = new System.Drawing.Point(0, 0);
            this.grpYedekAl.Name = "grpYedekAl";
            this.grpYedekAl.Size = new System.Drawing.Size(580, 131);
            this.grpYedekAl.TabIndex = 3;
            // 
            // beDosyaYolu
            // 
            this.beDosyaYolu.Location = new System.Drawing.Point(70, 24);
            this.beDosyaYolu.Name = "beDosyaYolu";
            this.beDosyaYolu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "new", null, true)});
            this.beDosyaYolu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.beDosyaYolu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beDosyaYolu.Size = new System.Drawing.Size(355, 20);
            this.beDosyaYolu.TabIndex = 8;
            this.beDosyaYolu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDosyaYolu_ButtonClick);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(350, 77);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 20);
            this.btnBackUp.TabIndex = 12;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Dosya Yolu:";
            // 
            // txtDosyaAdý
            // 
            this.txtDosyaAdý.Location = new System.Drawing.Point(70, 50);
            this.txtDosyaAdý.Name = "txtDosyaAdý";
            this.txtDosyaAdý.Size = new System.Drawing.Size(100, 20);
            this.txtDosyaAdý.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Dosya Adý:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(176, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = ".bak";
            // 
            // frmYedekAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 131);
            this.Controls.Add(this.grpYedekAl);
            this.Name = "frmYedekAl";
            this.Text = "Yedek Al";
            this.Load += new System.EventHandler(this.frmYedekAl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpYedekAl)).EndInit();
            this.grpYedekAl.ResumeLayout(false);
            this.grpYedekAl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDosyaYolu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaAdý.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpYedekAl;
        private DevExpress.XtraEditors.ButtonEdit beDosyaYolu;
        private DevExpress.XtraEditors.SimpleButton btnBackUp;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDosyaAdý;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}