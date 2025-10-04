namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucBelgeAramaGirisEkran
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
            this.sBtnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.rgFiltre = new DevExpress.XtraEditors.RadioGroup();
            this.lueDurum = new DevExpress.XtraEditors.LookUpEdit();
            this.txtBarkodNo = new DevExpress.XtraEditors.TextEdit();
            this.lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.txtReferansNo = new DevExpress.XtraEditors.TextEdit();
            this.txtBelgeNo = new DevExpress.XtraEditors.TextEdit();
            this.lueBelgeTuru = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.txtBelgeAdi = new DevExpress.XtraEditors.TextEdit();
            this.lueDosya = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFoyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdliye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEsasNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTakipTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.rgZamanDilimi = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.rgFiltre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferansNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBelgeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBelgeTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBelgeAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgZamanDilimi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sBtnSorgula
            // 
            this.sBtnSorgula.Location = new System.Drawing.Point(639, 31);
            this.sBtnSorgula.Name = "sBtnSorgula";
            this.sBtnSorgula.Size = new System.Drawing.Size(89, 23);
            this.sBtnSorgula.TabIndex = 7;
            this.sBtnSorgula.Text = "Sorgula";
            this.sBtnSorgula.Click += new System.EventHandler(this.sBtnSorgula_Click);
            // 
            // sBtnTemizle
            // 
            this.sBtnTemizle.Location = new System.Drawing.Point(639, 7);
            this.sBtnTemizle.Name = "sBtnTemizle";
            this.sBtnTemizle.Size = new System.Drawing.Size(89, 23);
            this.sBtnTemizle.TabIndex = 6;
            this.sBtnTemizle.Text = "Temizle";
            this.sBtnTemizle.Click += new System.EventHandler(this.sBtnTemizle_Click);
            // 
            // rgFiltre
            // 
            this.rgFiltre.EditValue = true;
            this.rgFiltre.Location = new System.Drawing.Point(5, 96);
            this.rgFiltre.Name = "rgFiltre";
            this.rgFiltre.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Benim Belgelerim"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Tüm Belgeler")});
            this.rgFiltre.Size = new System.Drawing.Size(527, 39);
            this.rgFiltre.TabIndex = 8;
            // 
            // lueDurum
            // 
            this.lueDurum.Location = new System.Drawing.Point(367, 69);
            this.lueDurum.Name = "lueDurum";
            this.lueDurum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDurum.Size = new System.Drawing.Size(165, 20);
            this.lueDurum.TabIndex = 7;
            this.lueDurum.EditValueChanged += new System.EventHandler(this.lueDurum_EditValueChanged);
            // 
            // txtBarkodNo
            // 
            this.txtBarkodNo.Location = new System.Drawing.Point(367, 48);
            this.txtBarkodNo.Name = "txtBarkodNo";
            this.txtBarkodNo.Size = new System.Drawing.Size(165, 20);
            this.txtBarkodNo.TabIndex = 6;
            this.txtBarkodNo.TextChanged += new System.EventHandler(this.txtBarkodNo_TextChanged);
            // 
            // lueModul
            // 
            this.lueModul.Location = new System.Drawing.Point(75, 7);
            this.lueModul.Name = "lueModul";
            this.lueModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModul.Size = new System.Drawing.Size(192, 20);
            this.lueModul.TabIndex = 4;
            this.lueModul.EditValueChanged += new System.EventHandler(this.lueModul_EditValueChanged);
            // 
            // txtReferansNo
            // 
            this.txtReferansNo.Location = new System.Drawing.Point(367, 27);
            this.txtReferansNo.Name = "txtReferansNo";
            this.txtReferansNo.Size = new System.Drawing.Size(165, 20);
            this.txtReferansNo.TabIndex = 2;
            this.txtReferansNo.TextChanged += new System.EventHandler(this.txtBelgeReferansNo_TextChanged);
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.Location = new System.Drawing.Point(367, 6);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(165, 20);
            this.txtBelgeNo.TabIndex = 2;
            this.txtBelgeNo.TextChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // lueBelgeTuru
            // 
            this.lueBelgeTuru.Location = new System.Drawing.Point(75, 70);
            this.lueBelgeTuru.Name = "lueBelgeTuru";
            this.lueBelgeTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBelgeTuru.Size = new System.Drawing.Size(192, 20);
            this.lueBelgeTuru.TabIndex = 1;
            this.lueBelgeTuru.EditValueChanged += new System.EventHandler(this.lueBelgeTuru_EditValueChanged);
            // 
            // txtBelgeAdi
            // 
            this.txtBelgeAdi.Location = new System.Drawing.Point(75, 49);
            this.txtBelgeAdi.Name = "txtBelgeAdi";
            this.txtBelgeAdi.Size = new System.Drawing.Size(192, 20);
            this.txtBelgeAdi.TabIndex = 2;
            this.txtBelgeAdi.TextChanged += new System.EventHandler(this.txtBelgeAdi_TextChanged);
            // 
            // lueDosya
            // 
            this.lueDosya.Location = new System.Drawing.Point(75, 28);
            this.lueDosya.Name = "lueDosya";
            this.lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDosya.Properties.DisplayMember = "FoyNo";
            this.lueDosya.Properties.ValueMember = "Id";
            this.lueDosya.Properties.View = this.searchLookUpEdit1View;
            this.lueDosya.Size = new System.Drawing.Size(192, 20);
            this.lueDosya.TabIndex = 5;
            this.lueDosya.EditValueChanged += new System.EventHandler(this.lueDosya_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFoyNo,
            this.colAdliye,
            this.colNo,
            this.colGorev,
            this.colEsasNo,
            this.colTakipTarihi});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFoyNo
            // 
            this.colFoyNo.Caption = "Dosya No";
            this.colFoyNo.FieldName = "FoyNo";
            this.colFoyNo.Name = "colFoyNo";
            this.colFoyNo.Visible = true;
            this.colFoyNo.VisibleIndex = 0;
            // 
            // colAdliye
            // 
            this.colAdliye.Caption = "Adliye";
            this.colAdliye.FieldName = "Adliye";
            this.colAdliye.Name = "colAdliye";
            this.colAdliye.Visible = true;
            this.colAdliye.VisibleIndex = 1;
            // 
            // colNo
            // 
            this.colNo.Caption = "No";
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 2;
            // 
            // colGorev
            // 
            this.colGorev.Caption = "Görev";
            this.colGorev.FieldName = "Gorev";
            this.colGorev.Name = "colGorev";
            this.colGorev.Visible = true;
            this.colGorev.VisibleIndex = 3;
            // 
            // colEsasNo
            // 
            this.colEsasNo.Caption = "Esas No";
            this.colEsasNo.FieldName = "EsasNo";
            this.colEsasNo.Name = "colEsasNo";
            this.colEsasNo.Visible = true;
            this.colEsasNo.VisibleIndex = 4;
            // 
            // colTakipTarihi
            // 
            this.colTakipTarihi.Caption = "Takip T.";
            this.colTakipTarihi.FieldName = "TakipTarihi";
            this.colTakipTarihi.Name = "colTakipTarihi";
            this.colTakipTarihi.Visible = true;
            this.colTakipTarihi.VisibleIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Modül :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Dosya :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Belge Adı :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 73);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Belge Türü :";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(314, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Belge No :";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(296, 31);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Referans No :";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(307, 52);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 13);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "Barkod No :";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(325, 74);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "Durum :";
            // 
            // rgZamanDilimi
            // 
            this.rgZamanDilimi.EditValue = "Bugun";
            this.rgZamanDilimi.Location = new System.Drawing.Point(536, 6);
            this.rgZamanDilimi.Name = "rgZamanDilimi";
            this.rgZamanDilimi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Dun", "Dün"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Bugun", "Bugün"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Yarin", "Yarın"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("BuHafta", "Bu Hafta"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("BuAy", "Bu Ay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("BuYil", "Bu Yıl"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Tumu", "Tümü")});
            this.rgZamanDilimi.Size = new System.Drawing.Size(97, 129);
            this.rgZamanDilimi.TabIndex = 249;
            // 
            // ucBelgeAramaGirisEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rgZamanDilimi);
            this.Controls.Add(this.sBtnSorgula);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.sBtnTemizle);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.rgFiltre);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lueBelgeTuru);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtBelgeAdi);
            this.Controls.Add(this.lueDurum);
            this.Controls.Add(this.txtBarkodNo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lueDosya);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtReferansNo);
            this.Controls.Add(this.lueModul);
            this.Controls.Add(this.txtBelgeNo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Name = "ucBelgeAramaGirisEkran";
            this.Size = new System.Drawing.Size(740, 140);
            this.Load += new System.EventHandler(this.ucBelgeAramaGirisEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgFiltre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferansNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBelgeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBelgeTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBelgeAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgZamanDilimi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton sBtnSorgula;
        public DevExpress.XtraEditors.SimpleButton sBtnTemizle;
        private DevExpress.XtraEditors.RadioGroup rgFiltre;
        private DevExpress.XtraEditors.LookUpEdit lueDurum;
        private DevExpress.XtraEditors.TextEdit txtBarkodNo;
        private DevExpress.XtraEditors.LookUpEdit lueModul;
        public DevExpress.XtraEditors.TextEdit txtReferansNo;
        public DevExpress.XtraEditors.TextEdit txtBelgeNo;
        public AdimAdimDavaKaydi.Util.ExtendedLookUpEdit lueBelgeTuru;
        public DevExpress.XtraEditors.TextEdit txtBelgeAdi;
        private DevExpress.XtraEditors.SearchLookUpEdit lueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFoyNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAdliye;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGorev;
        private DevExpress.XtraGrid.Columns.GridColumn colEsasNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTakipTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.RadioGroup rgZamanDilimi;


    }
}
