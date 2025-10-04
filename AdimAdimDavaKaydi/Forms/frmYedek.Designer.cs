namespace AdimAdimDavaKaydi.Forms
{
    partial class frmYedek
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.beDosya = new DevExpress.XtraEditors.ButtonEdit();
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.beDosyaYolu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDosyaAdı = new DevExpress.XtraEditors.TextEdit();
            this.btnBackUp = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.xtabYedek = new DevExpress.XtraTab.XtraTabControl();
            this.tabRestore = new DevExpress.XtraTab.XtraTabPage();
            this.tabBackUp = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.beDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDosyaYolu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaAdı.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabYedek)).BeginInit();
            this.xtabYedek.SuspendLayout();
            this.tabRestore.SuspendLayout();
            this.tabBackUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Dosya:";
            // 
            // beDosya
            // 
            this.beDosya.Location = new System.Drawing.Point(74, 7);
            this.beDosya.Name = "beDosya";
            this.beDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "new", null, true)});
            this.beDosya.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.beDosya.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beDosya.Size = new System.Drawing.Size(355, 20);
            this.beDosya.TabIndex = 1;
            this.beDosya.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDosya_ButtonClick);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(354, 33);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 20);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // beDosyaYolu
            // 
            this.beDosyaYolu.Location = new System.Drawing.Point(74, 7);
            this.beDosyaYolu.Name = "beDosyaYolu";
            this.beDosyaYolu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "new", null, true)});
            this.beDosyaYolu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.beDosyaYolu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beDosyaYolu.Size = new System.Drawing.Size(355, 20);
            this.beDosyaYolu.TabIndex = 3;
            this.beDosyaYolu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDosyaYolu_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Dosya Yolu:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Dosya Adı:";
            // 
            // txtDosyaAdı
            // 
            this.txtDosyaAdı.Location = new System.Drawing.Point(74, 33);
            this.txtDosyaAdı.Name = "txtDosyaAdı";
            this.txtDosyaAdı.Size = new System.Drawing.Size(100, 20);
            this.txtDosyaAdı.TabIndex = 6;
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(354, 60);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 20);
            this.btnBackUp.TabIndex = 7;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // xtabYedek
            // 
            this.xtabYedek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabYedek.Location = new System.Drawing.Point(0, 0);
            this.xtabYedek.Name = "xtabYedek";
            this.xtabYedek.SelectedTabPage = this.tabRestore;
            this.xtabYedek.Size = new System.Drawing.Size(442, 113);
            this.xtabYedek.TabIndex = 8;
            this.xtabYedek.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabRestore,
            this.tabBackUp});
            // 
            // tabRestore
            // 
            this.tabRestore.Controls.Add(this.beDosya);
            this.tabRestore.Controls.Add(this.labelControl1);
            this.tabRestore.Controls.Add(this.btnRestore);
            this.tabRestore.Name = "tabRestore";
            this.tabRestore.Size = new System.Drawing.Size(436, 204);
            this.tabRestore.Text = "Restore";
            // 
            // tabBackUp
            // 
            this.tabBackUp.Controls.Add(this.beDosyaYolu);
            this.tabBackUp.Controls.Add(this.btnBackUp);
            this.tabBackUp.Controls.Add(this.labelControl2);
            this.tabBackUp.Controls.Add(this.txtDosyaAdı);
            this.tabBackUp.Controls.Add(this.labelControl3);
            this.tabBackUp.Name = "tabBackUp";
            this.tabBackUp.Size = new System.Drawing.Size(436, 87);
            this.tabBackUp.Text = "BackUp";
            // 
            // frmYedek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 113);
            this.Controls.Add(this.xtabYedek);
            this.Name = "frmYedek";
            this.Text = "SQL Database İşlemleri";
            this.Load += new System.EventHandler(this.frmYedek_Load);
            ((System.ComponentModel.ISupportInitialize)(this.beDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDosyaYolu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaAdı.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabYedek)).EndInit();
            this.xtabYedek.ResumeLayout(false);
            this.tabRestore.ResumeLayout(false);
            this.tabRestore.PerformLayout();
            this.tabBackUp.ResumeLayout(false);
            this.tabBackUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit beDosya;
        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.ButtonEdit beDosyaYolu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDosyaAdı;
        private DevExpress.XtraEditors.SimpleButton btnBackUp;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraTab.XtraTabControl xtabYedek;
        private DevExpress.XtraTab.XtraTabPage tabRestore;
        private DevExpress.XtraTab.XtraTabPage tabBackUp;
    }
}