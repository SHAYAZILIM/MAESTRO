namespace  AdimAdimDavaKaydi.GirisEkran
{
    partial class rFrmBelgeAramaEkran
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
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
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
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 648);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(922, 10);
            // 
            // c_pnlFormSakla
            // 
            this.c_pnlFormSakla.Size = new System.Drawing.Size(343, 10);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Size = new System.Drawing.Size(75, 10);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Size = new System.Drawing.Size(75, 10);
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
            this.navBarControl1.Size = new System.Drawing.Size(922, 648);
            this.navBarControl1.TabIndex = 11;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Arama Kriterleri";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 162;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(914, 155);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(914, 467);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Arama Sonuçları";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupClientHeight = 474;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnGonder
            // 
            this.btnGonder.Location = new System.Drawing.Point(0, 0);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(75, 23);
            this.btnGonder.TabIndex = 0;
            // 
            // compNavBarAutoHeight1
            // 
            this.compNavBarAutoHeight1.DockingGroup = this.navBarGroup2;
            this.compNavBarAutoHeight1.MyNavBarControl = this.navBarControl1;
            // 
            // rFrmBelgeAramaEkran
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(922, 658);
            this.Name = "rFrmBelgeAramaEkran";
            this.Text = "Avukatpro Hukuk Ailesi Belge Arama Ekranı";
            this.UstMenu = true;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private AdimAdimDavaKaydi.UserControls.ucBelgeAramaGirisEkran ucBelgeAramaGirisEkran1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private AdimAdimDavaKaydi.Util.compNavBarAutoHeight compNavBarAutoHeight1;
        private AdimAdimDavaKaydi.Belge.UserControls.ucBelgeAramaView ucBelgeAramaView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGonder;
    }
}
