namespace  AdimAdimDavaKaydi.Forms.Icra
{
    partial class rFrmIcraIhtiyatiHaciz
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
            this.ckButunKayitlar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucTazminat_Ihtiyat1 = new AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ucTazminat_Ihtiyat_Taraf1 = new AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat_Taraf();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            
            
            
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(748, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 625);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 625);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(765, 571);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
 
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ckButunKayitlar
            // 
            this.ckButunKayitlar.Caption = "Bütün Kayýtlarý Göster";
            this.ckButunKayitlar.Edit = this.repositoryItemCheckEdit1;
            this.ckButunKayitlar.Id = 4;
            this.ckButunKayitlar.Name = "ckButunKayitlar";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.splitContainerControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(765, 571);
            this.clientPanel.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucTazminat_Ihtiyat1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(765, 571);
            this.splitContainerControl1.SplitterPosition = 312;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucTazminat_Ihtiyat1
            // 
            this.ucTazminat_Ihtiyat1.CurrentHaciz = null;
            this.ucTazminat_Ihtiyat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTazminat_Ihtiyat1.KlasorIcin = false;
            this.ucTazminat_Ihtiyat1.Location = new System.Drawing.Point(0, 0);

            this.ucTazminat_Ihtiyat1.MyDataSourceTeminat = null;
            this.ucTazminat_Ihtiyat1.Name = "ucTazminat_Ihtiyat1";
            this.ucTazminat_Ihtiyat1.Size = new System.Drawing.Size(765, 312);
            this.ucTazminat_Ihtiyat1.TabIndex = 1;
            this.ucTazminat_Ihtiyat1.FocusedHacizChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucTazminat_Ihtiyat1_FocusedHacizChanged);
            this.ucTazminat_Ihtiyat1.MyDataSourceChanged += new System.EventHandler(this.ucTazminat_Ihtiyat1_MyDataSourceChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.ucTazminat_Ihtiyat_Taraf1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(765, 253);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Ýhtiyati Haciz Taraf Bilgileri";
            // 
            // ucTazminat_Ihtiyat_Taraf1
            // 
            this.ucTazminat_Ihtiyat_Taraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTazminat_Ihtiyat_Taraf1.KlasorIcin = false;
            this.ucTazminat_Ihtiyat_Taraf1.Location = new System.Drawing.Point(2, 20);


            this.ucTazminat_Ihtiyat_Taraf1.Name = "ucTazminat_Ihtiyat_Taraf1";
            this.ucTazminat_Ihtiyat_Taraf1.Size = new System.Drawing.Size(761, 231);
            this.ucTazminat_Ihtiyat_Taraf1.TabIndex = 3;
            // 
            // rFrmIcraIhtiyatiHaciz
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 625);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Icra;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.KayitFormu;
            this.Name = "rFrmIcraIhtiyatiHaciz";
            this.Text = "Ýhtiyati Haciz Kayýt Formu";
            this.UstMenu = true;
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
 
 
 
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat ucTazminat_Ihtiyat1;
        private AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat_Taraf ucTazminat_Ihtiyat_Taraf1;
//        private DevExpress.XtraBars.BarButtonItem btnKaydet;
        private DevExpress.XtraBars.BarEditItem ckButunKayitlar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}