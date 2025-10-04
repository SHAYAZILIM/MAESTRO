namespace AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmYapilcakIsAramaEkran
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
            this.components = new System.ComponentModel.Container();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucYapilcakIsArama1 = new AdimAdimDavaKaydi.UserControls.ucYapilcakIsArama();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucGorevGrid1 = new AdimAdimDavaKaydi.UserControls.ucYapılacakIsAramaGrid();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.compNavBarAutoHeight1 = new AdimAdimDavaKaydi.Util.compNavBarAutoHeight(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 633);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.navBarControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(922, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.navBarControl1, 0);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 922;
            this.navBarControl1.Size = new System.Drawing.Size(922, 633);
            this.navBarControl1.TabIndex = 9;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Arama Kriterleri";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 192;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.ucYapilcakIsArama1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(918, 286);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // ucYapilcakIsArama1
            // 
            this.ucYapilcakIsArama1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucYapilcakIsArama1.Location = new System.Drawing.Point(0, 0);
            this.ucYapilcakIsArama1.Name = "ucYapilcakIsArama1";
            this.ucYapilcakIsArama1.Size = new System.Drawing.Size(918, 286);
            this.ucYapilcakIsArama1.TabIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.ucGorevGrid1);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(918, 318);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // ucGorevGrid1
            // 
            this.ucGorevGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGorevGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucGorevGrid1.MyDataSource = null;
            this.ucGorevGrid1.Name = "ucGorevGrid1";
            this.ucGorevGrid1.SelectedRecord = null;
            this.ucGorevGrid1.SelectedRecordId = 0;
            this.ucGorevGrid1.Size = new System.Drawing.Size(918, 318);
            this.ucGorevGrid1.TabIndex = 0;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Arama Sonuçları";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 368;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // compNavBarAutoHeight1
            // 
            this.compNavBarAutoHeight1.DockingGroup = this.navBarGroup2;
            this.compNavBarAutoHeight1.MyNavBarControl = this.navBarControl1;
            // 
            // rFrmYapilcakIsAramaEkran
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "rFrmYapilcakIsAramaEkran";
            this.Text = "Avukatpro Hukuk Ailesi Yapılcak İş Arama Ekranı";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmYapilcakIsAramaEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private AdimAdimDavaKaydi.UserControls.ucYapılacakIsAramaGrid ucGorevGrid1;
        private AdimAdimDavaKaydi.UserControls.ucYapilcakIsArama ucYapilcakIsArama1;
        private AdimAdimDavaKaydi.Util.compNavBarAutoHeight compNavBarAutoHeight1;
    }
}