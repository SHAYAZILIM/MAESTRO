namespace  AvukatProImageEditor
{
    partial class AvproImageEditor
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.c_peResim = new DevExpress.XtraEditors.PictureEdit();
            this.c_txtDosya = new DevExpress.XtraEditors.TextEdit();
            this.c_btnDosyaAc = new DevExpress.XtraEditors.SimpleButton();
            this.c_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.c_btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.c_pnlKagit = new DevExpress.XtraEditors.PanelControl();
            this.c_pePosition = new System.Windows.Forms.PictureBox();
            this.c_btnSifirla = new DevExpress.XtraEditors.SimpleButton();
            this.mover1 = new AvukatProImageEditor.Mover();
            this.c_mmYazi = new DevExpress.XtraEditors.MemoEdit();
            this.c_txtFont = new DevExpress.XtraEditors.TextEdit();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.mover2 = new AvukatProImageEditor.Mover();
            this.c_pnlResim = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_peResim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlKagit)).BeginInit();
            this.c_pnlKagit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_mmYazi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonKeyTip = "";
            this.ribbon.ApplicationIcon = null;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem2,
            this.barEditItem3});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemMemoEdit1});
            this.ribbon.SelectedPage = this.ribbonPage1;
            this.ribbon.Size = new System.Drawing.Size(841, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 617);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(841, 25);
            // 
            // c_peResim
            // 
            this.c_peResim.Location = new System.Drawing.Point(754, 485);
            this.c_peResim.Name = "c_peResim";
            this.c_peResim.Size = new System.Drawing.Size(75, 23);
            this.c_peResim.TabIndex = 8;
            // 
            // c_txtDosya
            // 
            this.c_txtDosya.Location = new System.Drawing.Point(12, 57);
            this.c_txtDosya.Name = "c_txtDosya";
            this.c_txtDosya.Size = new System.Drawing.Size(369, 20);
            this.c_txtDosya.TabIndex = 9;
            // 
            // c_btnDosyaAc
            // 
            this.c_btnDosyaAc.Location = new System.Drawing.Point(387, 56);
            this.c_btnDosyaAc.Name = "c_btnDosyaAc";
            this.c_btnDosyaAc.Size = new System.Drawing.Size(105, 23);
            this.c_btnDosyaAc.TabIndex = 10;
            this.c_btnDosyaAc.Text = "Aç";
            this.c_btnDosyaAc.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // c_openFileDialog
            // 
            this.c_openFileDialog.FileName = "openFileDialog1";
            this.c_openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // c_btnOk
            // 
            this.c_btnOk.Location = new System.Drawing.Point(662, 587);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(167, 23);
            this.c_btnOk.TabIndex = 13;
            this.c_btnOk.Text = "Ok";
            this.c_btnOk.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // c_pnlKagit
            // 
            this.c_pnlKagit.Controls.Add(this.c_pePosition);
            this.c_pnlKagit.Location = new System.Drawing.Point(662, 84);
            this.c_pnlKagit.Name = "c_pnlKagit";
            this.c_pnlKagit.Size = new System.Drawing.Size(170, 235);
            this.c_pnlKagit.TabIndex = 16;
            // 
            // c_pePosition
            // 
            this.c_pePosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c_pePosition.Location = new System.Drawing.Point(27, 27);
            this.c_pePosition.Name = "c_pePosition";
            this.c_pePosition.Size = new System.Drawing.Size(33, 30);
            this.c_pePosition.TabIndex = 1;
            this.c_pePosition.TabStop = false;
            // 
            // c_btnSifirla
            // 
            this.c_btnSifirla.Location = new System.Drawing.Point(662, 325);
            this.c_btnSifirla.Name = "c_btnSifirla";
            this.c_btnSifirla.Size = new System.Drawing.Size(170, 23);
            this.c_btnSifirla.TabIndex = 17;
            this.c_btnSifirla.Text = "Sifirla";
            this.c_btnSifirla.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // mover1
            // 
            this.mover1.MoveAll = true;
            this.mover1.MyControl = this.c_pePosition;
            this.mover1.Parent = this.c_pnlKagit;
            // 
            // c_mmYazi
            // 
            this.c_mmYazi.Location = new System.Drawing.Point(13, 528);
            this.c_mmYazi.Name = "c_mmYazi";
            this.c_mmYazi.Size = new System.Drawing.Size(577, 82);
            this.c_mmYazi.TabIndex = 21;
            // 
            // c_txtFont
            // 
            this.c_txtFont.Location = new System.Drawing.Point(662, 525);
            this.c_txtFont.Name = "c_txtFont";
            this.c_txtFont.Size = new System.Drawing.Size(170, 20);
            this.c_txtFont.TabIndex = 25;
            this.c_txtFont.Click += new System.EventHandler(this.c_txtFont_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(596, 527);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(60, 83);
            this.simpleButton1.TabIndex = 29;
            this.simpleButton1.Text = "Yazi Ekle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // mover2
            // 
            this.mover2.MoveAll = false;
            this.mover2.MyControl = null;
            this.mover2.Parent = this;
            // 
            // c_pnlResim
            // 
            this.c_pnlResim.Location = new System.Drawing.Point(13, 84);
            this.c_pnlResim.Name = "c_pnlResim";
            this.c_pnlResim.Size = new System.Drawing.Size(643, 409);
            this.c_pnlResim.TabIndex = 32;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(13, 502);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(257, 20);
            this.lookUpEdit1.TabIndex = 35;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(276, 502);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Size = new System.Drawing.Size(248, 20);
            this.lookUpEdit2.TabIndex = 36;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(530, 503);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(60, 19);
            this.simpleButton2.TabIndex = 29;
            this.simpleButton2.Text = "Ekle";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(662, 403);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(170, 23);
            this.simpleButton3.TabIndex = 17;
            this.simpleButton3.Text = "Resim";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.KeyTip = "";
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Özellikler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem3);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Yazi";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Font";
            this.barEditItem2.Edit = this.repositoryItemTextEdit2;
            this.barEditItem2.Id = 1;
            this.barEditItem2.Name = "barEditItem2";
            this.barEditItem2.Width = 200;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Yazi";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 0;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Width = 200;
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "Yazi";
            this.barEditItem3.Edit = this.repositoryItemMemoEdit1;
            this.barEditItem3.Id = 3;
            this.barEditItem3.Name = "barEditItem3";
            this.barEditItem3.Width = 200;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // AvproImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 642);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.lookUpEdit2);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.c_pnlResim);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.c_peResim);
            this.Controls.Add(this.c_txtFont);
            this.Controls.Add(this.c_mmYazi);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.c_btnSifirla);
            this.Controls.Add(this.c_pnlKagit);
            this.Controls.Add(this.c_btnOk);
            this.Controls.Add(this.c_btnDosyaAc);
            this.Controls.Add(this.c_txtDosya);
            this.Controls.Add(this.ribbonStatusBar);
            this.Name = "AvproImageEditor";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "AvproImageEditor";
            this.Load += new System.EventHandler(this.AvproImageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_peResim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlKagit)).EndInit();
            this.c_pnlKagit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_mmYazi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_txtFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PictureEdit c_peResim;
        private DevExpress.XtraEditors.TextEdit c_txtDosya;
        private DevExpress.XtraEditors.SimpleButton c_btnDosyaAc;
        private System.Windows.Forms.OpenFileDialog c_openFileDialog;
        private DevExpress.XtraEditors.SimpleButton c_btnOk;
        private DevExpress.XtraEditors.PanelControl c_pnlKagit;
        private DevExpress.XtraEditors.SimpleButton c_btnSifirla;
        private Mover mover1;
        private System.Windows.Forms.PictureBox c_pePosition;
        private DevExpress.XtraEditors.MemoEdit c_mmYazi;
        private DevExpress.XtraEditors.TextEdit c_txtFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Mover mover2;
        private DevExpress.XtraEditors.PanelControl c_pnlResim;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
    }
}