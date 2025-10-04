namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class frmTemyizEkle
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
            this.tarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.MyRepository = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.aciklama = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowTEFHIM_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSURE_TUTUM_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMYIZ_TEBLIG_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEMYIZ_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUSUL_NEDENLER = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowYASAL_NEDENLER = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEDBIR_ISTEM_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEDBIR_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTEDBIR_ACIKLAMASI = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucTemyizBilgileri1 = new AdimAdimDavaKaydi.UserControls.UcDava.ucTemyizBilgileri();
            this.bndTemyiz = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndTemyiz)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(784, 0);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 633);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(801, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(651, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(726, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.clientPanel);
            this.c_pnlContainer.Size = new System.Drawing.Size(801, 658);
            this.c_pnlContainer.Controls.SetChildIndex(this.clientPanel, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // tarih
            // 
            this.tarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tarih.Name = "tarih";
            this.tarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.splitContainerControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 0);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(801, 658);
            this.clientPanel.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(801, 658);
            this.splitContainerControl1.SplitterPosition = 298;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(801, 298);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "Kanun Yoluna Müracaat Edenler";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.vGridControl2);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.dataNavigatorExtended1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(797, 275);
            this.panelControl1.TabIndex = 3;
            // 
            // vGridControl2
            // 
            this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl2.ExternalRepository = this.MyRepository;
            this.vGridControl2.Location = new System.Drawing.Point(2, 56);
            this.vGridControl2.Name = "vGridControl2";
            this.vGridControl2.RecordWidth = 151;
            this.vGridControl2.RowHeaderWidth = 294;
            this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTEFHIM_TARIHI,
            this.rowSURE_TUTUM_TARIHI,
            this.rowTEMYIZ_TEBLIG_TARIHI,
            this.rowTEMYIZ_TARIHI,
            this.rowCARI_ID,
            this.rowUSUL_NEDENLER,
            this.rowYASAL_NEDENLER,
            this.rowTEDBIR_ISTEM_TARIHI,
            this.rowTEDBIR_TARIHI,
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI,
            this.rowTEDBIR_ACIKLAMASI});
            this.vGridControl2.Size = new System.Drawing.Size(793, 193);
            this.vGridControl2.TabIndex = 4;
            // 
            // MyRepository
            // 
            this.MyRepository.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tarih,
            this.aciklama,
            this.rlueCari});
            // 
            // aciklama
            // 
            this.aciklama.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.aciklama.Name = "aciklama";
            // 
            // rlueCari
            // 
            this.rlueCari.AutoHeight = false;
            this.rlueCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueCari.Name = "rlueCari";
            // 
            // rowTEFHIM_TARIHI
            // 
            this.rowTEFHIM_TARIHI.Name = "rowTEFHIM_TARIHI";
            this.rowTEFHIM_TARIHI.Properties.Caption = "Tefhim T.";
            this.rowTEFHIM_TARIHI.Properties.FieldName = "TEFHIM_TARIHI";
            this.rowTEFHIM_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowSURE_TUTUM_TARIHI
            // 
            this.rowSURE_TUTUM_TARIHI.Name = "rowSURE_TUTUM_TARIHI";
            this.rowSURE_TUTUM_TARIHI.Properties.Caption = "Müracaat Tarihi / Süre Tutum Tarihi";
            this.rowSURE_TUTUM_TARIHI.Properties.FieldName = "SURE_TUTUM_TARIHI";
            this.rowSURE_TUTUM_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEMYIZ_TEBLIG_TARIHI
            // 
            this.rowTEMYIZ_TEBLIG_TARIHI.Name = "rowTEMYIZ_TEBLIG_TARIHI";
            this.rowTEMYIZ_TEBLIG_TARIHI.Properties.Caption = "Karþý Tarafýn Kanun Yoluna Müracaatýnýn Teblið T.";
            this.rowTEMYIZ_TEBLIG_TARIHI.Properties.FieldName = "TEMYIZ_TEBLIG_TARIHI";
            this.rowTEMYIZ_TEBLIG_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEMYIZ_TARIHI
            // 
            this.rowTEMYIZ_TARIHI.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rowTEMYIZ_TARIHI.Appearance.Options.UseBackColor = true;
            this.rowTEMYIZ_TARIHI.Name = "rowTEMYIZ_TARIHI";
            this.rowTEMYIZ_TARIHI.Properties.Caption = "Kanun Yoluna Müracaat (Gerekçeli) T.";
            this.rowTEMYIZ_TARIHI.Properties.FieldName = "TEMYIZ_TARIHI";
            this.rowTEMYIZ_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowCARI_ID
            // 
            this.rowCARI_ID.Name = "rowCARI_ID";
            this.rowCARI_ID.Properties.Caption = "Müracaat Eden";
            this.rowCARI_ID.Properties.FieldName = "CARI_ID";
            this.rowCARI_ID.Properties.RowEdit = this.rlueCari;
            // 
            // rowUSUL_NEDENLER
            // 
            this.rowUSUL_NEDENLER.Name = "rowUSUL_NEDENLER";
            this.rowUSUL_NEDENLER.Properties.Caption = "Usül Nedenler";
            this.rowUSUL_NEDENLER.Properties.FieldName = "USUL_NEDENLER";
            this.rowUSUL_NEDENLER.Visible = false;
            // 
            // rowYASAL_NEDENLER
            // 
            this.rowYASAL_NEDENLER.Name = "rowYASAL_NEDENLER";
            this.rowYASAL_NEDENLER.Properties.Caption = "Yasal Nedenler";
            this.rowYASAL_NEDENLER.Properties.FieldName = "YASAL_NEDENLER";
            this.rowYASAL_NEDENLER.Visible = false;
            // 
            // rowTEDBIR_ISTEM_TARIHI
            // 
            this.rowTEDBIR_ISTEM_TARIHI.Height = 19;
            this.rowTEDBIR_ISTEM_TARIHI.Name = "rowTEDBIR_ISTEM_TARIHI";
            this.rowTEDBIR_ISTEM_TARIHI.Properties.Caption = "Ýcranýn Geri Býrakýlmasýný Ýstem T.";
            this.rowTEDBIR_ISTEM_TARIHI.Properties.FieldName = "TEDBIR_ISTEM_TARIHI";
            this.rowTEDBIR_ISTEM_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEDBIR_TARIHI
            // 
            this.rowTEDBIR_TARIHI.Name = "rowTEDBIR_TARIHI";
            this.rowTEDBIR_TARIHI.Properties.Caption = "Ýcranýn Geri Býrakýldýðý T.";
            this.rowTEDBIR_TARIHI.Properties.FieldName = "TEDBIR_TARIHI";
            this.rowTEDBIR_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEDBIRIN_KALDIRILMASI_TARIHI
            // 
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI.Name = "rowTEDBIRIN_KALDIRILMASI_TARIHI";
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI.Properties.Caption = "Ýcraya Devam T.";
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI.Properties.FieldName = "TEDBIRIN_KALDIRILMASI_TARIHI";
            this.rowTEDBIRIN_KALDIRILMASI_TARIHI.Properties.RowEdit = this.tarih;
            // 
            // rowTEDBIR_ACIKLAMASI
            // 
            this.rowTEDBIR_ACIKLAMASI.Name = "rowTEDBIR_ACIKLAMASI";
            this.rowTEDBIR_ACIKLAMASI.Properties.Caption = "Açýklama";
            this.rowTEDBIR_ACIKLAMASI.Properties.FieldName = "TEDBIR_ACIKLAMASI";
            this.rowTEDBIR_ACIKLAMASI.Properties.RowEdit = this.aciklama;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lookUpEdit1);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(793, 54);
            this.panelControl2.TabIndex = 7;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(260, 15);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(263, 20);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Müracaat Edilen Kanun Yolu ?";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 249);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(793, 24);
            this.dataNavigatorExtended1.TabIndex = 3;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.ucTemyizBilgileri1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(801, 355);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Yüksek Mahkeme (Ýstinaf, Bölge Ýdare Mahkemesi, Yargýtay, Danýþtay vs.) Bilgileri" +
    "";
            // 
            // ucTemyizBilgileri1
            // 
            this.ucTemyizBilgileri1.DavaFoyID = 0;
            this.ucTemyizBilgileri1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemyizBilgileri1.Location = new System.Drawing.Point(2, 21);
            this.ucTemyizBilgileri1.MyType = AvukatProLib.Extras.ViewType.VGrid;
            this.ucTemyizBilgileri1.Name = "ucTemyizBilgileri1";
            this.ucTemyizBilgileri1.Size = new System.Drawing.Size(797, 332);
            this.ucTemyizBilgileri1.TabIndex = 0;
            // 
            // bndTemyiz
            // 
            this.bndTemyiz.DataSource = typeof(AvukatProLib2.Entities.AV001_TD_BIL_TEMYIZ);
            // 
            // frmTemyizEkle
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 658);
            this.Name = "frmTemyizEkle";
            this.Text = "Kanun Yolu";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmTemyizEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bndTemyiz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.PanelControl clientPanel;
        private System.Windows.Forms.BindingSource bndTemyiz;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        //private DevExpress.XtraBars.BarButtonItem btnKaydet;
        //private DevExpress.XtraBars.BarButtonItem btnVazgec;
        private DevExpress.XtraEditors.Repository.PersistentRepository MyRepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit tarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit aciklama;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private AdimAdimDavaKaydi.UserControls.UcDava.ucTemyizBilgileri ucTemyizBilgileri1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMYIZ_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUSUL_NEDENLER;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowYASAL_NEDENLER;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEDBIR_ISTEM_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEDBIR_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEDBIRIN_KALDIRILMASI_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEDBIR_ACIKLAMASI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEMYIZ_TEBLIG_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTEFHIM_TARIHI;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSURE_TUTUM_TARIHI;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
    }
}