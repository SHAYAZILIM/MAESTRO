namespace  AvukatProLib.Controls
{
    partial class Form1
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
            Bilgi bilgi2 = new Bilgi();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chSutun = new System.Windows.Forms.ColumnHeader();
            this.chKosul = new System.Windows.Forms.ColumnHeader();
            this.chDeger1 = new System.Windows.Forms.ColumnHeader();
            this.chDeger2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buKural�De�i�tirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buKural�SilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkSutun = new DevExpress.XtraEditors.LookUpEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.rclrColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.rlkBicimKosulu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkRenkGecisYonu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkRenkUygulamaTipi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rdtTarih = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rchkKutucuk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rtxtYazi = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.rlkSutunlar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.categoryMisc = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowTip = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDegerlerinTipi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKosul = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDeger1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDeger2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSutun1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSutun2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowArkaPlanRengi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowArkaPlanRengi2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowYaziRengi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSatiraUygula = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowRenkGecisYonu = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKenarlikRengi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.propertyDescriptionControl1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.button3 = new DevExpress.XtraEditors.SimpleButton();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkSutun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rclrColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBicimKosulu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkRenkGecisYonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkRenkUygulamaTipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTarih.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkKutucuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtYazi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkSutunlar)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSutun,
            this.chKosul,
            this.chDeger1,
            this.chDeger2});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(303, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(409, 432);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chSutun
            // 
            this.chSutun.Text = "S�tun Ad�";
            this.chSutun.Width = 101;
            // 
            // chKosul
            // 
            this.chKosul.Text = "Ko�ul";
            this.chKosul.Width = 100;
            // 
            // chDeger1
            // 
            this.chDeger1.Text = "De�er 1";
            this.chDeger1.Width = 100;
            // 
            // chDeger2
            // 
            this.chDeger2.Text = "De�er 2";
            this.chDeger2.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buKural�De�i�tirToolStripMenuItem,
            this.buKural�SilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            // 
            // buKural�De�i�tirToolStripMenuItem
            // 
            this.buKural�De�i�tirToolStripMenuItem.Name = "buKural�De�i�tirToolStripMenuItem";
            this.buKural�De�i�tirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.buKural�De�i�tirToolStripMenuItem.Text = "Bu Kural� De�i�tir";
            this.buKural�De�i�tirToolStripMenuItem.Click += new System.EventHandler(this.buKural�De�i�tirToolStripMenuItem_Click);
            // 
            // buKural�SilToolStripMenuItem
            // 
            this.buKural�SilToolStripMenuItem.Name = "buKural�SilToolStripMenuItem";
            this.buKural�SilToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.buKural�SilToolStripMenuItem.Text = "Bu Kural� Sil";
            this.buKural�SilToolStripMenuItem.Click += new System.EventHandler(this.buKural�SilToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kar��la�t�r�lacak S�tun :";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.propertyGrid1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.propertyGrid1.Location = new System.Drawing.Point(627, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(209, 311);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button3);
            this.panelControl1.Controls.Add(this.lkSutun);
            this.panelControl1.Controls.Add(this.listView1);
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.propertyGrid1);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(714, 436);
            this.panelControl1.TabIndex = 2;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // lkSutun
            // 
            this.lkSutun.Location = new System.Drawing.Point(156, 4);
            this.lkSutun.Name = "lkSutun";
            this.lkSutun.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lkSutun.Properties.Appearance.Options.UseFont = true;
            this.lkSutun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSutun.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption", "S�tun Ad�", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lkSutun.Properties.NullText = "<S�tun Se�iniz>";
            this.lkSutun.Size = new System.Drawing.Size(143, 20);
            this.lkSutun.TabIndex = 9;
            this.lkSutun.EditValueChanged += new System.EventHandler(this.rlkSutunlar_EditValueChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 30);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.propertyGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.propertyDescriptionControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(294, 372);
            this.splitContainerControl1.SplitterPosition = 269;
            this.splitContainerControl1.TabIndex = 11;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.splitContainerControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerControl1_Paint);
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.DefaultEditors.AddRange(new DevExpress.XtraVerticalGrid.Rows.DefaultEditor[] {
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(typeof(System.Drawing.Color), this.rclrColor)});
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.RecordWidth = 97;
            this.propertyGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rclrColor,
            this.rlkBicimKosulu,
            this.rlkRenkGecisYonu,
            this.rlkRenkUygulamaTipi,
            this.rdtTarih,
            this.rchkKutucuk,
            this.rtxtYazi,
            this.rlkSutunlar});
            this.propertyGridControl1.RowHeaderWidth = 103;
            this.propertyGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.categoryMisc});
            bilgi2.ArkaPlanRengi = System.Drawing.Color.Empty;
            bilgi2.ArkaPlanRengi2 = System.Drawing.Color.Empty;
            bilgi2.Deger1 = null;
            bilgi2.Deger2 = null;
            bilgi2.DegerlerinTipi = DegerTipi.Say�sal;
            bilgi2.KenarlikRengi = System.Drawing.Color.Empty;
            bilgi2.Kosul = DevExpress.XtraGrid.FormatConditionEnum.None;
            bilgi2.RenkGecisYonu = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            bilgi2.SatiraUygula = false;
            bilgi2.Sutun = null;
            bilgi2.Sutun1 = null;
            bilgi2.Sutun2 = null;
            bilgi2.Tip = KarsilastirmaTipi.Sutun;
            bilgi2.YaziRengi = System.Drawing.Color.Empty;
            this.propertyGridControl1.SelectedObject = bilgi2;
            this.propertyGridControl1.ServiceProvider = null;
            this.propertyGridControl1.Size = new System.Drawing.Size(290, 265);
            this.propertyGridControl1.TabIndex = 8;
            // 
            // rclrColor
            // 
            this.rclrColor.AutoHeight = false;
            this.rclrColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rclrColor.Name = "rclrColor";
            // 
            // rlkBicimKosulu
            // 
            this.rlkBicimKosulu.AutoHeight = false;
            this.rlkBicimKosulu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkBicimKosulu.Name = "rlkBicimKosulu";
            // 
            // rlkRenkGecisYonu
            // 
            this.rlkRenkGecisYonu.AutoHeight = false;
            this.rlkRenkGecisYonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkRenkGecisYonu.Name = "rlkRenkGecisYonu";
            // 
            // rlkRenkUygulamaTipi
            // 
            this.rlkRenkUygulamaTipi.AutoHeight = false;
            this.rlkRenkUygulamaTipi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkRenkUygulamaTipi.Name = "rlkRenkUygulamaTipi";
            // 
            // rdtTarih
            // 
            this.rdtTarih.AutoHeight = false;
            this.rdtTarih.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdtTarih.Name = "rdtTarih";
            this.rdtTarih.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rchkKutucuk
            // 
            this.rchkKutucuk.AutoHeight = false;
            this.rchkKutucuk.Name = "rchkKutucuk";
            // 
            // rtxtYazi
            // 
            this.rtxtYazi.AutoHeight = false;
            this.rtxtYazi.Name = "rtxtYazi";
            // 
            // rlkSutunlar
            // 
            this.rlkSutunlar.AutoHeight = false;
            this.rlkSutunlar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkSutunlar.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption", "S�tun", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.rlkSutunlar.Name = "rlkSutunlar";
            this.rlkSutunlar.NullText = "<S�tun Se�iniz>";
            this.rlkSutunlar.ValueMember = "FieldName";
            // 
            // categoryMisc
            // 
            this.categoryMisc.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTip,
            this.rowDegerlerinTipi,
            this.rowKosul,
            this.rowDeger1,
            this.rowDeger2,
            this.rowSutun1,
            this.rowSutun2,
            this.rowArkaPlanRengi,
            this.rowArkaPlanRengi2,
            this.rowYaziRengi,
            this.rowSatiraUygula,
            this.rowRenkGecisYonu,
            this.rowKenarlikRengi});
            this.categoryMisc.Height = 19;
            this.categoryMisc.Name = "categoryMisc";
            this.categoryMisc.Properties.Caption = "Ko�ul";
            // 
            // rowTip
            // 
            this.rowTip.Name = "rowTip";
            this.rowTip.Properties.Caption = "Kar��la�t�rma Tipi";
            this.rowTip.Properties.FieldName = "Tip";
            // 
            // rowDegerlerinTipi
            // 
            this.rowDegerlerinTipi.Name = "rowDegerlerinTipi";
            this.rowDegerlerinTipi.Properties.Caption = "De�erlerin Tipi";
            this.rowDegerlerinTipi.Properties.FieldName = "DegerlerinTipi";
            // 
            // rowKosul
            // 
            this.rowKosul.Height = 19;
            this.rowKosul.Name = "rowKosul";
            this.rowKosul.Properties.Caption = "Ko�ul";
            this.rowKosul.Properties.FieldName = "Kosul";
            this.rowKosul.Properties.RowEdit = this.rlkBicimKosulu;
            // 
            // rowDeger1
            // 
            this.rowDeger1.Height = 17;
            this.rowDeger1.Name = "rowDeger1";
            this.rowDeger1.Properties.Caption = "De�er 1";
            this.rowDeger1.Properties.FieldName = "Deger1";
            this.rowDeger1.Visible = false;
            // 
            // rowDeger2
            // 
            this.rowDeger2.Height = 17;
            this.rowDeger2.Name = "rowDeger2";
            this.rowDeger2.Properties.Caption = "De�er 2";
            this.rowDeger2.Properties.FieldName = "Deger2";
            this.rowDeger2.Visible = false;
            // 
            // rowSutun1
            // 
            this.rowSutun1.Name = "rowSutun1";
            this.rowSutun1.Properties.Caption = "S�tun 1";
            this.rowSutun1.Properties.FieldName = "Sutun1";
            this.rowSutun1.Properties.RowEdit = this.rlkSutunlar;
            // 
            // rowSutun2
            // 
            this.rowSutun2.Name = "rowSutun2";
            this.rowSutun2.Properties.Caption = "S�tun 2";
            this.rowSutun2.Properties.FieldName = "Sutun2";
            this.rowSutun2.Properties.RowEdit = this.rlkSutunlar;
            // 
            // rowArkaPlanRengi
            // 
            this.rowArkaPlanRengi.Name = "rowArkaPlanRengi";
            this.rowArkaPlanRengi.Properties.Caption = "Arka Plan Rengi";
            this.rowArkaPlanRengi.Properties.FieldName = "ArkaPlanRengi";
            // 
            // rowArkaPlanRengi2
            // 
            this.rowArkaPlanRengi2.Name = "rowArkaPlanRengi2";
            this.rowArkaPlanRengi2.Properties.Caption = "Arka Plan Rengi 2";
            this.rowArkaPlanRengi2.Properties.FieldName = "ArkaPlanRengi2";
            // 
            // rowYaziRengi
            // 
            this.rowYaziRengi.Name = "rowYaziRengi";
            this.rowYaziRengi.Properties.Caption = "Yaz� Rengi";
            this.rowYaziRengi.Properties.FieldName = "YaziRengi";
            // 
            // rowSatiraUygula
            // 
            this.rowSatiraUygula.Name = "rowSatiraUygula";
            this.rowSatiraUygula.Properties.Caption = "Renk Uygulama Tipi";
            this.rowSatiraUygula.Properties.FieldName = "SatiraUygula";
            this.rowSatiraUygula.Properties.RowEdit = this.rlkRenkUygulamaTipi;
            // 
            // rowRenkGecisYonu
            // 
            this.rowRenkGecisYonu.Name = "rowRenkGecisYonu";
            this.rowRenkGecisYonu.Properties.Caption = "Renk Ge�i� Y�n�";
            this.rowRenkGecisYonu.Properties.FieldName = "RenkGecisYonu";
            this.rowRenkGecisYonu.Properties.RowEdit = this.rlkRenkGecisYonu;
            // 
            // rowKenarlikRengi
            // 
            this.rowKenarlikRengi.Name = "rowKenarlikRengi";
            this.rowKenarlikRengi.Properties.Caption = "Kenarl�k Rengi";
            this.rowKenarlikRengi.Properties.FieldName = "KenarlikRengi";
            // 
            // propertyDescriptionControl1
            // 
            this.propertyDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyDescriptionControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyDescriptionControl1.Name = "propertyDescriptionControl1";
            this.propertyDescriptionControl1.PropertyGrid = this.propertyGridControl1;
            this.propertyDescriptionControl1.Size = new System.Drawing.Size(290, 93);
            this.propertyDescriptionControl1.TabIndex = 9;
            this.propertyDescriptionControl1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(193, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Ko�ullar� uygula";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Se�ili olan� sil";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ekle";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 436);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Ko�ullu Bi�imlendirme";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkSutun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rclrColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkBicimKosulu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkRenkGecisYonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkRenkUygulamaTipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTarih.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdtTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkKutucuk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtYazi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkSutunlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chSutun;
        private System.Windows.Forms.ColumnHeader chKosul;
        private System.Windows.Forms.ColumnHeader chDeger1;
        private System.Windows.Forms.ColumnHeader chDeger2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buKural�De�i�tirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buKural�SilToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button3;
        private DevExpress.XtraEditors.SimpleButton button2;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow categoryMisc;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowArkaPlanRengi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowArkaPlanRengi2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDeger1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDeger2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDegerlerinTipi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTip;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKenarlikRengi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKosul;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowRenkGecisYonu;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSatiraUygula;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowYaziRengi;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit rclrColor;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkBicimKosulu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkRenkGecisYonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkRenkUygulamaTipi;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdtTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkKutucuk;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rtxtYazi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSutun1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSutun2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkSutunlar;
        private DevExpress.XtraEditors.LookUpEdit lkSutun;
    }
}

