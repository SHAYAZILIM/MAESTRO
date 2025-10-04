namespace  AdimAdimDavaKaydi.Forms.Dava
{
    partial class rFrmMeslekMakbuzuKaydetForDava
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
            this.pnlUst = new DevExpress.XtraEditors.PanelControl();
            this.lcFatura = new DevExpress.XtraLayout.LayoutControl();
            this.txtRefNo = new DevExpress.XtraEditors.TextEdit();
            this.bndFatura = new System.Windows.Forms.BindingSource(this.components);
            this.deTarih = new DevExpress.XtraEditors.DateEdit();
            this.txtSeriNo = new DevExpress.XtraEditors.TextEdit();
            this.lueSegment = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMuvekkil = new DevExpress.XtraEditors.LookUpEdit();
            this.lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.lueDosya = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFOY_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADLIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAKIP_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueBelge = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcGroupFatura = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciModul = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDosya = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMuvekkil = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSegment = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSeriNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTarih = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciReferansNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBelge = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcFaturaDetay = new DevExpress.XtraLayout.LayoutControl();
            this.lueGenelToplamDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.bndFaturaDetay = new System.Windows.Forms.BindingSource(this.components);
            this.lueSSDFDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.lueStopajDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.lueKdvDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.seBirimFiyat = new DevExpress.XtraEditors.SpinEdit();
            this.lueToplamDoviz = new DevExpress.XtraEditors.LookUpEdit();
            this.chkKDV = new DevExpress.XtraEditors.CheckEdit();
            this.chkStopajDahil = new DevExpress.XtraEditors.CheckEdit();
            this.seAdet = new DevExpress.XtraEditors.SpinEdit();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            this.txtKDVTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtStopajTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtSSDF = new DevExpress.XtraEditors.TextEdit();
            this.txtGenelToplam = new DevExpress.XtraEditors.TextEdit();
            this.memoKonu = new DevExpress.XtraEditors.MemoEdit();
            this.lcGroupFaturaDetay = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAdet = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKonu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBirimFiyat = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciToplam = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBirimFiyatDovizId = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKdv = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKDVTutar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStopajDahil = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStopaj = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciKdvDovizId = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStopajDovizId = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSSDFTutar = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSSDFDovizId = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGenelToplam = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGenelToplamDoviz = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcFaturaDetay = new DevExpress.XtraGrid.GridControl();
            this.gvFaturaDetay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFaturaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaAdet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaToplam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaKDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaStopaj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaSSDF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaGenelToplam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaDoviz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dnFaturaDetay = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUst)).BeginInit();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcFatura)).BeginInit();
            this.lcFatura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndFatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSegment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMuvekkil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBelge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupFatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDosya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMuvekkil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSeriNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReferansNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBelge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcFaturaDetay)).BeginInit();
            this.lcFaturaDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGenelToplamDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndFaturaDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSSDFDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStopajDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKdvDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seBirimFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueToplamDoviz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStopajDahil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAdet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDVTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopajTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSSDF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenelToplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKonu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupFaturaDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBirimFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciToplam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBirimFiyatDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKdv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKDVTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopajDahil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKdvDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopajDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSSDFTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSSDFDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenelToplam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenelToplamDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFaturaDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFaturaDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(722, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 493);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 493);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 489);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(514, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(364, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(439, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.pnlUst);
            this.c_pnlContainer.Controls.Add(this.gcFaturaDetay);
            this.c_pnlContainer.Controls.Add(this.dnFaturaDetay);
            this.c_pnlContainer.Size = new System.Drawing.Size(514, 538);
            this.c_pnlContainer.Controls.SetChildIndex(this.dnFaturaDetay, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.gcFaturaDetay, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.pnlUst, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // pnlUst
            // 
            this.pnlUst.Controls.Add(this.lcFatura);
            this.pnlUst.Controls.Add(this.lcFaturaDetay);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(514, 384);
            this.pnlUst.TabIndex = 10;
            // 
            // lcFatura
            // 
            this.lcFatura.Controls.Add(this.txtRefNo);
            this.lcFatura.Controls.Add(this.deTarih);
            this.lcFatura.Controls.Add(this.txtSeriNo);
            this.lcFatura.Controls.Add(this.lueSegment);
            this.lcFatura.Controls.Add(this.lueMuvekkil);
            this.lcFatura.Controls.Add(this.lueModul);
            this.lcFatura.Controls.Add(this.lueDosya);
            this.lcFatura.Controls.Add(this.lueBelge);
            this.lcFatura.Location = new System.Drawing.Point(0, 0);
            this.lcFatura.Name = "lcFatura";
            this.lcFatura.Root = this.lcGroupFatura;
            this.lcFatura.Size = new System.Drawing.Size(514, 185);
            this.lcFatura.TabIndex = 4;
            this.lcFatura.Text = "Fatura";
            // 
            // txtRefNo
            // 
            this.txtRefNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFatura, "REFERANS_NO", true));
            this.txtRefNo.Location = new System.Drawing.Point(364, 127);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(138, 20);
            this.txtRefNo.StyleController = this.lcFatura;
            this.txtRefNo.TabIndex = 8;
            // 
            // bndFatura
            // 
            this.bndFatura.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_FATURA);
            this.bndFatura.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bndFatura_AddingNew);
            // 
            // deTarih
            // 
            this.deTarih.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFatura, "FATURA_TARIH", true));
            this.deTarih.EditValue = null;
            this.deTarih.Location = new System.Drawing.Point(364, 103);
            this.deTarih.Name = "deTarih";
            this.deTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarih.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTarih.Size = new System.Drawing.Size(138, 20);
            this.deTarih.StyleController = this.lcFatura;
            this.deTarih.TabIndex = 7;
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFatura, "SERI_NO", true));
            this.txtSeriNo.Location = new System.Drawing.Point(67, 127);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Size = new System.Drawing.Size(238, 20);
            this.txtSeriNo.StyleController = this.lcFatura;
            this.txtSeriNo.TabIndex = 6;
            // 
            // lueSegment
            // 
            this.lueSegment.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFatura, "SEGMENT_ID", true));
            this.lueSegment.Location = new System.Drawing.Point(67, 79);
            this.lueSegment.Name = "lueSegment";
            this.lueSegment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSegment.Properties.DisplayMember = "Segment";
            this.lueSegment.Properties.ValueMember = "Id";
            this.lueSegment.Size = new System.Drawing.Size(435, 20);
            this.lueSegment.StyleController = this.lcFatura;
            this.lueSegment.TabIndex = 5;
            this.lueSegment.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueSegment_ButtonClick);
            // 
            // lueMuvekkil
            // 
            this.lueMuvekkil.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFatura, "CARI_ID", true));
            this.lueMuvekkil.Location = new System.Drawing.Point(67, 103);
            this.lueMuvekkil.Name = "lueMuvekkil";
            this.lueMuvekkil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMuvekkil.Size = new System.Drawing.Size(238, 20);
            this.lueMuvekkil.StyleController = this.lcFatura;
            this.lueMuvekkil.TabIndex = 4;
            this.lueMuvekkil.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueMuvekkil_ButtonClick);
            // 
            // lueModul
            // 
            this.lueModul.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFatura, "FATURA_HEDEF_TIP", true));
            this.lueModul.Location = new System.Drawing.Point(67, 31);
            this.lueModul.Name = "lueModul";
            this.lueModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModul.Size = new System.Drawing.Size(435, 20);
            this.lueModul.StyleController = this.lcFatura;
            this.lueModul.TabIndex = 0;
            this.lueModul.EditValueChanged += new System.EventHandler(this.lueModul_EditValueChanged);
            // 
            // lueDosya
            // 
            this.lueDosya.Enabled = false;
            this.lueDosya.Location = new System.Drawing.Point(67, 55);
            this.lueDosya.Name = "lueDosya";
            this.lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDosya.Properties.DisplayMember = "FoyNo";
            this.lueDosya.Properties.ValueMember = "Id";
            this.lueDosya.Properties.View = this.searchLookUpEdit1View;
            this.lueDosya.Size = new System.Drawing.Size(435, 20);
            this.lueDosya.StyleController = this.lcFatura;
            this.lueDosya.TabIndex = 3;
            this.lueDosya.EditValueChanged += new System.EventHandler(this.lueDosya_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFOY_NO,
            this.colADLIYE,
            this.colNO,
            this.colGOREV,
            this.colESAS_NO,
            this.colTAKIP_TARIHI});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.GroupPanelText = "Gruplamak için bir alan sürükleyiniz!";
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.Editable = false;
            this.searchLookUpEdit1View.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.searchLookUpEdit1View.OptionsFilter.UseNewCustomFilterDialog = true;
            this.searchLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupedColumns = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.Name = "colId";
            // 
            // colFOY_NO
            // 
            this.colFOY_NO.Caption = "Dosya No";
            this.colFOY_NO.FieldName = "FoyNo";
            this.colFOY_NO.Name = "colFOY_NO";
            this.colFOY_NO.Visible = true;
            this.colFOY_NO.VisibleIndex = 0;
            // 
            // colADLIYE
            // 
            this.colADLIYE.Caption = "Adliye";
            this.colADLIYE.FieldName = "Adliye";
            this.colADLIYE.Name = "colADLIYE";
            this.colADLIYE.Visible = true;
            this.colADLIYE.VisibleIndex = 1;
            // 
            // colNO
            // 
            this.colNO.Caption = "No";
            this.colNO.FieldName = "No";
            this.colNO.Name = "colNO";
            this.colNO.Visible = true;
            this.colNO.VisibleIndex = 2;
            // 
            // colGOREV
            // 
            this.colGOREV.Caption = "Görev";
            this.colGOREV.FieldName = "Gorev";
            this.colGOREV.Name = "colGOREV";
            this.colGOREV.Visible = true;
            this.colGOREV.VisibleIndex = 3;
            // 
            // colESAS_NO
            // 
            this.colESAS_NO.Caption = "Esas No";
            this.colESAS_NO.FieldName = "EsasNo";
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 4;
            // 
            // colTAKIP_TARIHI
            // 
            this.colTAKIP_TARIHI.Caption = "Tarih";
            this.colTAKIP_TARIHI.FieldName = "TakipTarihi";
            this.colTAKIP_TARIHI.Name = "colTAKIP_TARIHI";
            this.colTAKIP_TARIHI.Visible = true;
            this.colTAKIP_TARIHI.VisibleIndex = 5;
            // 
            // lueBelge
            // 
            this.lueBelge.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFatura, "BELGE_ID", true));
            this.lueBelge.Location = new System.Drawing.Point(67, 151);
            this.lueBelge.Name = "lueBelge";
            this.lueBelge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBelge.Properties.DisplayMember = "BelgeAdi";
            this.lueBelge.Properties.ValueMember = "Id";
            this.lueBelge.Properties.View = this.gridView1;
            this.lueBelge.Size = new System.Drawing.Size(435, 20);
            this.lueBelge.StyleController = this.lcFatura;
            this.lueBelge.TabIndex = 9;
            this.lueBelge.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueBelge_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lcGroupFatura
            // 
            this.lcGroupFatura.CustomizationFormText = "layoutControlGroup1";
            this.lcGroupFatura.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcGroupFatura.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciModul,
            this.lciDosya,
            this.lciMuvekkil,
            this.lciSegment,
            this.lciSeriNo,
            this.lciTarih,
            this.lciReferansNo,
            this.lciBelge});
            this.lcGroupFatura.Location = new System.Drawing.Point(0, 0);
            this.lcGroupFatura.Name = "lcGroupFatura";
            this.lcGroupFatura.Size = new System.Drawing.Size(514, 185);
            this.lcGroupFatura.Text = "Fatura";
            // 
            // lciModul
            // 
            this.lciModul.Control = this.lueModul;
            this.lciModul.CustomizationFormText = "layoutControlItem1";
            this.lciModul.Location = new System.Drawing.Point(0, 0);
            this.lciModul.Name = "lciModul";
            this.lciModul.Size = new System.Drawing.Size(494, 24);
            this.lciModul.Text = "Modul";
            this.lciModul.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciModul.TextSize = new System.Drawing.Size(50, 13);
            this.lciModul.TextToControlDistance = 5;
            // 
            // lciDosya
            // 
            this.lciDosya.Control = this.lueDosya;
            this.lciDosya.CustomizationFormText = "layoutControlItem2";
            this.lciDosya.Location = new System.Drawing.Point(0, 24);
            this.lciDosya.Name = "lciDosya";
            this.lciDosya.Size = new System.Drawing.Size(494, 24);
            this.lciDosya.Text = "Dosya";
            this.lciDosya.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciDosya.TextSize = new System.Drawing.Size(50, 13);
            this.lciDosya.TextToControlDistance = 5;
            // 
            // lciMuvekkil
            // 
            this.lciMuvekkil.Control = this.lueMuvekkil;
            this.lciMuvekkil.CustomizationFormText = "Müvekkil";
            this.lciMuvekkil.Location = new System.Drawing.Point(0, 72);
            this.lciMuvekkil.Name = "lciMuvekkil";
            this.lciMuvekkil.Size = new System.Drawing.Size(297, 24);
            this.lciMuvekkil.Text = "Müvekkil";
            this.lciMuvekkil.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciMuvekkil.TextSize = new System.Drawing.Size(50, 20);
            this.lciMuvekkil.TextToControlDistance = 5;
            // 
            // lciSegment
            // 
            this.lciSegment.Control = this.lueSegment;
            this.lciSegment.CustomizationFormText = "Bölüm";
            this.lciSegment.Location = new System.Drawing.Point(0, 48);
            this.lciSegment.Name = "lciSegment";
            this.lciSegment.Size = new System.Drawing.Size(494, 24);
            this.lciSegment.Text = "Bölüm";
            this.lciSegment.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciSegment.TextSize = new System.Drawing.Size(50, 20);
            this.lciSegment.TextToControlDistance = 5;
            // 
            // lciSeriNo
            // 
            this.lciSeriNo.Control = this.txtSeriNo;
            this.lciSeriNo.CustomizationFormText = "Seri No";
            this.lciSeriNo.Location = new System.Drawing.Point(0, 96);
            this.lciSeriNo.Name = "lciSeriNo";
            this.lciSeriNo.Size = new System.Drawing.Size(297, 24);
            this.lciSeriNo.Text = "Seri No";
            this.lciSeriNo.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciSeriNo.TextSize = new System.Drawing.Size(50, 20);
            this.lciSeriNo.TextToControlDistance = 5;
            // 
            // lciTarih
            // 
            this.lciTarih.Control = this.deTarih;
            this.lciTarih.CustomizationFormText = "Tarih";
            this.lciTarih.Location = new System.Drawing.Point(297, 72);
            this.lciTarih.Name = "lciTarih";
            this.lciTarih.Size = new System.Drawing.Size(197, 24);
            this.lciTarih.Text = "Tarih";
            this.lciTarih.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciTarih.TextSize = new System.Drawing.Size(50, 20);
            this.lciTarih.TextToControlDistance = 5;
            // 
            // lciReferansNo
            // 
            this.lciReferansNo.Control = this.txtRefNo;
            this.lciReferansNo.CustomizationFormText = "Ref. No";
            this.lciReferansNo.Location = new System.Drawing.Point(297, 96);
            this.lciReferansNo.Name = "lciReferansNo";
            this.lciReferansNo.Size = new System.Drawing.Size(197, 24);
            this.lciReferansNo.Text = "Ref. No";
            this.lciReferansNo.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciReferansNo.TextSize = new System.Drawing.Size(50, 20);
            this.lciReferansNo.TextToControlDistance = 5;
            // 
            // lciBelge
            // 
            this.lciBelge.Control = this.lueBelge;
            this.lciBelge.CustomizationFormText = "layoutControlItem1";
            this.lciBelge.Location = new System.Drawing.Point(0, 120);
            this.lciBelge.Name = "lciBelge";
            this.lciBelge.Size = new System.Drawing.Size(494, 26);
            this.lciBelge.Text = "Belge Seç";
            this.lciBelge.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciBelge.TextSize = new System.Drawing.Size(50, 13);
            this.lciBelge.TextToControlDistance = 5;
            // 
            // lcFaturaDetay
            // 
            this.lcFaturaDetay.Controls.Add(this.lueGenelToplamDoviz);
            this.lcFaturaDetay.Controls.Add(this.lueSSDFDoviz);
            this.lcFaturaDetay.Controls.Add(this.lueStopajDoviz);
            this.lcFaturaDetay.Controls.Add(this.lueKdvDoviz);
            this.lcFaturaDetay.Controls.Add(this.seBirimFiyat);
            this.lcFaturaDetay.Controls.Add(this.lueToplamDoviz);
            this.lcFaturaDetay.Controls.Add(this.chkKDV);
            this.lcFaturaDetay.Controls.Add(this.chkStopajDahil);
            this.lcFaturaDetay.Controls.Add(this.seAdet);
            this.lcFaturaDetay.Controls.Add(this.txtToplam);
            this.lcFaturaDetay.Controls.Add(this.txtKDVTutar);
            this.lcFaturaDetay.Controls.Add(this.txtStopajTutar);
            this.lcFaturaDetay.Controls.Add(this.txtSSDF);
            this.lcFaturaDetay.Controls.Add(this.txtGenelToplam);
            this.lcFaturaDetay.Controls.Add(this.memoKonu);
            this.lcFaturaDetay.Location = new System.Drawing.Point(0, 191);
            this.lcFaturaDetay.Name = "lcFaturaDetay";
            this.lcFaturaDetay.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(303, 140, 250, 350);
            this.lcFaturaDetay.Root = this.lcGroupFaturaDetay;
            this.lcFaturaDetay.Size = new System.Drawing.Size(514, 185);
            this.lcFaturaDetay.TabIndex = 5;
            this.lcFaturaDetay.Text = "layoutControl1";
            // 
            // lueGenelToplamDoviz
            // 
            this.lueGenelToplamDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "GENEL_TOPLAM_DOVIZ_ID", true));
            this.lueGenelToplamDoviz.Location = new System.Drawing.Point(436, 153);
            this.lueGenelToplamDoviz.Name = "lueGenelToplamDoviz";
            this.lueGenelToplamDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGenelToplamDoviz.Size = new System.Drawing.Size(66, 20);
            this.lueGenelToplamDoviz.StyleController = this.lcFaturaDetay;
            this.lueGenelToplamDoviz.TabIndex = 19;
            // 
            // bndFaturaDetay
            // 
            this.bndFaturaDetay.DataMember = "AV001_TDI_BIL_FATURA_DETAYCollection";
            this.bndFaturaDetay.DataSource = this.bndFatura;
            this.bndFaturaDetay.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bndFaturaDetay_AddingNew);
            // 
            // lueSSDFDoviz
            // 
            this.lueSSDFDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "SSDF_TUTAR_DOVIZ_ID", true));
            this.lueSSDFDoviz.Location = new System.Drawing.Point(436, 129);
            this.lueSSDFDoviz.Name = "lueSSDFDoviz";
            this.lueSSDFDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSSDFDoviz.Size = new System.Drawing.Size(66, 20);
            this.lueSSDFDoviz.StyleController = this.lcFaturaDetay;
            this.lueSSDFDoviz.TabIndex = 17;
            // 
            // lueStopajDoviz
            // 
            this.lueStopajDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "SSDF_TUTAR_DOVIZ_ID", true));
            this.lueStopajDoviz.Location = new System.Drawing.Point(436, 105);
            this.lueStopajDoviz.Name = "lueStopajDoviz";
            this.lueStopajDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStopajDoviz.Size = new System.Drawing.Size(66, 20);
            this.lueStopajDoviz.StyleController = this.lcFaturaDetay;
            this.lueStopajDoviz.TabIndex = 15;
            // 
            // lueKdvDoviz
            // 
            this.lueKdvDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "KDV_TUTAR_DOVIZ_ID", true));
            this.lueKdvDoviz.Location = new System.Drawing.Point(436, 81);
            this.lueKdvDoviz.Name = "lueKdvDoviz";
            this.lueKdvDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKdvDoviz.Size = new System.Drawing.Size(66, 20);
            this.lueKdvDoviz.StyleController = this.lcFaturaDetay;
            this.lueKdvDoviz.TabIndex = 14;
            // 
            // seBirimFiyat
            // 
            this.seBirimFiyat.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "BIRIM_TUTAR", true));
            this.seBirimFiyat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seBirimFiyat.Location = new System.Drawing.Point(135, 57);
            this.seBirimFiyat.Name = "seBirimFiyat";
            this.seBirimFiyat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seBirimFiyat.Properties.Mask.EditMask = "n";
            this.seBirimFiyat.Size = new System.Drawing.Size(112, 20);
            this.seBirimFiyat.StyleController = this.lcFaturaDetay;
            this.seBirimFiyat.TabIndex = 8;
            // 
            // lueToplamDoviz
            // 
            this.lueToplamDoviz.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "TOPLAM_DOVIZ_ID", true));
            this.lueToplamDoviz.Location = new System.Drawing.Point(436, 57);
            this.lueToplamDoviz.Name = "lueToplamDoviz";
            this.lueToplamDoviz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueToplamDoviz.Size = new System.Drawing.Size(66, 20);
            this.lueToplamDoviz.StyleController = this.lcFaturaDetay;
            this.lueToplamDoviz.TabIndex = 5;
            // 
            // chkKDV
            // 
            this.chkKDV.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bndFaturaDetay, "KDV_DAHIL_MI", true));
            this.chkKDV.Location = new System.Drawing.Point(12, 81);
            this.chkKDV.Name = "chkKDV";
            this.chkKDV.Properties.Caption = "KDV Dahil";
            this.chkKDV.Size = new System.Drawing.Size(235, 19);
            this.chkKDV.StyleController = this.lcFaturaDetay;
            this.chkKDV.TabIndex = 10;
            // 
            // chkStopajDahil
            // 
            this.chkStopajDahil.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bndFaturaDetay, "STOPAJ_DAHIL_MI", true));
            this.chkStopajDahil.Location = new System.Drawing.Point(12, 104);
            this.chkStopajDahil.Name = "chkStopajDahil";
            this.chkStopajDahil.Properties.Caption = "Stopaj Dahil";
            this.chkStopajDahil.Size = new System.Drawing.Size(235, 19);
            this.chkStopajDahil.StyleController = this.lcFaturaDetay;
            this.chkStopajDahil.TabIndex = 12;
            // 
            // seAdet
            // 
            this.seAdet.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFaturaDetay, "ADET", true));
            this.seAdet.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seAdet.Location = new System.Drawing.Point(80, 57);
            this.seAdet.Name = "seAdet";
            this.seAdet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seAdet.Properties.Mask.EditMask = "n0";
            this.seAdet.Size = new System.Drawing.Size(51, 20);
            this.seAdet.StyleController = this.lcFaturaDetay;
            this.seAdet.TabIndex = 4;
            // 
            // txtToplam
            // 
            this.txtToplam.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "TOPLAM", true));
            this.txtToplam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtToplam.Location = new System.Drawing.Point(319, 57);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtToplam.Properties.Mask.EditMask = "n";
            this.txtToplam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtToplam.Size = new System.Drawing.Size(113, 20);
            this.txtToplam.StyleController = this.lcFaturaDetay;
            this.txtToplam.TabIndex = 9;
            // 
            // txtKDVTutar
            // 
            this.txtKDVTutar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "KDV_TUTAR", true));
            this.txtKDVTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKDVTutar.Location = new System.Drawing.Point(319, 81);
            this.txtKDVTutar.Name = "txtKDVTutar";
            this.txtKDVTutar.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtKDVTutar.Properties.Mask.EditMask = "n";
            this.txtKDVTutar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtKDVTutar.Size = new System.Drawing.Size(113, 20);
            this.txtKDVTutar.StyleController = this.lcFaturaDetay;
            this.txtKDVTutar.TabIndex = 11;
            // 
            // txtStopajTutar
            // 
            this.txtStopajTutar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "STOPAJ_TUTAR", true));
            this.txtStopajTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtStopajTutar.Location = new System.Drawing.Point(319, 105);
            this.txtStopajTutar.Name = "txtStopajTutar";
            this.txtStopajTutar.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtStopajTutar.Properties.Mask.EditMask = "n";
            this.txtStopajTutar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtStopajTutar.Size = new System.Drawing.Size(113, 20);
            this.txtStopajTutar.StyleController = this.lcFaturaDetay;
            this.txtStopajTutar.TabIndex = 13;
            // 
            // txtSSDF
            // 
            this.txtSSDF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "SSDF_TUTAR", true));
            this.txtSSDF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSSDF.Location = new System.Drawing.Point(319, 129);
            this.txtSSDF.Name = "txtSSDF";
            this.txtSSDF.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtSSDF.Properties.Mask.EditMask = "n";
            this.txtSSDF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSSDF.Size = new System.Drawing.Size(113, 20);
            this.txtSSDF.StyleController = this.lcFaturaDetay;
            this.txtSSDF.TabIndex = 16;
            // 
            // txtGenelToplam
            // 
            this.txtGenelToplam.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "GENEL_TOPLAM", true));
            this.txtGenelToplam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGenelToplam.Location = new System.Drawing.Point(319, 153);
            this.txtGenelToplam.Name = "txtGenelToplam";
            this.txtGenelToplam.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtGenelToplam.Properties.Mask.EditMask = "n";
            this.txtGenelToplam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGenelToplam.Size = new System.Drawing.Size(113, 20);
            this.txtGenelToplam.StyleController = this.lcFaturaDetay;
            this.txtGenelToplam.TabIndex = 18;
            // 
            // memoKonu
            // 
            this.memoKonu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bndFaturaDetay, "FATURA_KONU", true));
            this.memoKonu.Location = new System.Drawing.Point(80, 31);
            this.memoKonu.Name = "memoKonu";
            this.memoKonu.Size = new System.Drawing.Size(422, 22);
            this.memoKonu.StyleController = this.lcFaturaDetay;
            this.memoKonu.TabIndex = 7;
            // 
            // lcGroupFaturaDetay
            // 
            this.lcGroupFaturaDetay.CustomizationFormText = "Fatura Detay";
            this.lcGroupFaturaDetay.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcGroupFaturaDetay.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAdet,
            this.lciKonu,
            this.lciBirimFiyat,
            this.lciToplam,
            this.lciBirimFiyatDovizId,
            this.lciKdv,
            this.lciKDVTutar,
            this.lciStopajDahil,
            this.lciStopaj,
            this.lciKdvDovizId,
            this.lciStopajDovizId,
            this.lciSSDFTutar,
            this.lciSSDFDovizId,
            this.lciGenelToplam,
            this.lciGenelToplamDoviz});
            this.lcGroupFaturaDetay.Location = new System.Drawing.Point(0, 0);
            this.lcGroupFaturaDetay.Name = "lcGroupFaturaDetay";
            this.lcGroupFaturaDetay.Size = new System.Drawing.Size(514, 185);
            this.lcGroupFaturaDetay.Text = "Fatura Detay";
            // 
            // lciAdet
            // 
            this.lciAdet.Control = this.seAdet;
            this.lciAdet.CustomizationFormText = "Adet";
            this.lciAdet.Location = new System.Drawing.Point(0, 26);
            this.lciAdet.Name = "lciAdet";
            this.lciAdet.Size = new System.Drawing.Size(123, 24);
            this.lciAdet.Text = "Adet";
            this.lciAdet.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciKonu
            // 
            this.lciKonu.Control = this.memoKonu;
            this.lciKonu.CustomizationFormText = "Konu";
            this.lciKonu.Location = new System.Drawing.Point(0, 0);
            this.lciKonu.Name = "lciKonu";
            this.lciKonu.Size = new System.Drawing.Size(494, 26);
            this.lciKonu.Text = "Konu";
            this.lciKonu.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciBirimFiyat
            // 
            this.lciBirimFiyat.Control = this.seBirimFiyat;
            this.lciBirimFiyat.CustomizationFormText = "lciBirimFiyat";
            this.lciBirimFiyat.Location = new System.Drawing.Point(123, 26);
            this.lciBirimFiyat.Name = "lciBirimFiyat";
            this.lciBirimFiyat.Size = new System.Drawing.Size(116, 24);
            this.lciBirimFiyat.Text = "lciBirimFiyat";
            this.lciBirimFiyat.TextSize = new System.Drawing.Size(0, 0);
            this.lciBirimFiyat.TextToControlDistance = 0;
            this.lciBirimFiyat.TextVisible = false;
            // 
            // lciToplam
            // 
            this.lciToplam.Control = this.txtToplam;
            this.lciToplam.CustomizationFormText = "Toplam";
            this.lciToplam.Location = new System.Drawing.Point(239, 26);
            this.lciToplam.Name = "lciToplam";
            this.lciToplam.Size = new System.Drawing.Size(185, 24);
            this.lciToplam.Text = "Toplam";
            this.lciToplam.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciBirimFiyatDovizId
            // 
            this.lciBirimFiyatDovizId.Control = this.lueToplamDoviz;
            this.lciBirimFiyatDovizId.CustomizationFormText = "Brm.";
            this.lciBirimFiyatDovizId.Location = new System.Drawing.Point(424, 26);
            this.lciBirimFiyatDovizId.Name = "lciBirimFiyatDovizId";
            this.lciBirimFiyatDovizId.Size = new System.Drawing.Size(70, 24);
            this.lciBirimFiyatDovizId.Text = "Brm.";
            this.lciBirimFiyatDovizId.TextSize = new System.Drawing.Size(0, 0);
            this.lciBirimFiyatDovizId.TextToControlDistance = 0;
            this.lciBirimFiyatDovizId.TextVisible = false;
            // 
            // lciKdv
            // 
            this.lciKdv.Control = this.chkKDV;
            this.lciKdv.CustomizationFormText = "lciKdv";
            this.lciKdv.Location = new System.Drawing.Point(0, 50);
            this.lciKdv.Name = "lciKdv";
            this.lciKdv.Size = new System.Drawing.Size(239, 23);
            this.lciKdv.Text = "lciKdv";
            this.lciKdv.TextSize = new System.Drawing.Size(0, 0);
            this.lciKdv.TextToControlDistance = 0;
            this.lciKdv.TextVisible = false;
            // 
            // lciKDVTutar
            // 
            this.lciKDVTutar.Control = this.txtKDVTutar;
            this.lciKDVTutar.CustomizationFormText = "layoutControlItem1";
            this.lciKDVTutar.Location = new System.Drawing.Point(239, 50);
            this.lciKDVTutar.Name = "lciKDVTutar";
            this.lciKDVTutar.Size = new System.Drawing.Size(185, 24);
            this.lciKDVTutar.Text = "KDV";
            this.lciKDVTutar.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciStopajDahil
            // 
            this.lciStopajDahil.Control = this.chkStopajDahil;
            this.lciStopajDahil.CustomizationFormText = "lciStopajDahil";
            this.lciStopajDahil.Location = new System.Drawing.Point(0, 73);
            this.lciStopajDahil.Name = "lciStopajDahil";
            this.lciStopajDahil.Size = new System.Drawing.Size(239, 73);
            this.lciStopajDahil.Text = "lciStopajDahil";
            this.lciStopajDahil.TextSize = new System.Drawing.Size(0, 0);
            this.lciStopajDahil.TextToControlDistance = 0;
            this.lciStopajDahil.TextVisible = false;
            // 
            // lciStopaj
            // 
            this.lciStopaj.Control = this.txtStopajTutar;
            this.lciStopaj.CustomizationFormText = "Stopaj";
            this.lciStopaj.Location = new System.Drawing.Point(239, 74);
            this.lciStopaj.Name = "lciStopaj";
            this.lciStopaj.Size = new System.Drawing.Size(185, 24);
            this.lciStopaj.Text = "Stopaj";
            this.lciStopaj.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciKdvDovizId
            // 
            this.lciKdvDovizId.Control = this.lueKdvDoviz;
            this.lciKdvDovizId.CustomizationFormText = "lciKdvDovizId";
            this.lciKdvDovizId.Location = new System.Drawing.Point(424, 50);
            this.lciKdvDovizId.Name = "lciKdvDovizId";
            this.lciKdvDovizId.Size = new System.Drawing.Size(70, 24);
            this.lciKdvDovizId.Text = "lciKdvDovizId";
            this.lciKdvDovizId.TextSize = new System.Drawing.Size(0, 0);
            this.lciKdvDovizId.TextToControlDistance = 0;
            this.lciKdvDovizId.TextVisible = false;
            // 
            // lciStopajDovizId
            // 
            this.lciStopajDovizId.Control = this.lueStopajDoviz;
            this.lciStopajDovizId.CustomizationFormText = "lciStopajDovizId";
            this.lciStopajDovizId.Location = new System.Drawing.Point(424, 74);
            this.lciStopajDovizId.Name = "lciStopajDovizId";
            this.lciStopajDovizId.Size = new System.Drawing.Size(70, 24);
            this.lciStopajDovizId.Text = "lciStopajDovizId";
            this.lciStopajDovizId.TextSize = new System.Drawing.Size(0, 0);
            this.lciStopajDovizId.TextToControlDistance = 0;
            this.lciStopajDovizId.TextVisible = false;
            // 
            // lciSSDFTutar
            // 
            this.lciSSDFTutar.Control = this.txtSSDF;
            this.lciSSDFTutar.CustomizationFormText = "SSDF";
            this.lciSSDFTutar.Location = new System.Drawing.Point(239, 98);
            this.lciSSDFTutar.Name = "lciSSDFTutar";
            this.lciSSDFTutar.Size = new System.Drawing.Size(185, 24);
            this.lciSSDFTutar.Text = "SSDF";
            this.lciSSDFTutar.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciSSDFDovizId
            // 
            this.lciSSDFDovizId.Control = this.lueSSDFDoviz;
            this.lciSSDFDovizId.CustomizationFormText = "lciSSDFDovizId";
            this.lciSSDFDovizId.Location = new System.Drawing.Point(424, 98);
            this.lciSSDFDovizId.Name = "lciSSDFDovizId";
            this.lciSSDFDovizId.Size = new System.Drawing.Size(70, 24);
            this.lciSSDFDovizId.Text = "lciSSDFDovizId";
            this.lciSSDFDovizId.TextSize = new System.Drawing.Size(0, 0);
            this.lciSSDFDovizId.TextToControlDistance = 0;
            this.lciSSDFDovizId.TextVisible = false;
            // 
            // lciGenelToplam
            // 
            this.lciGenelToplam.Control = this.txtGenelToplam;
            this.lciGenelToplam.CustomizationFormText = "Genel Toplam";
            this.lciGenelToplam.Location = new System.Drawing.Point(239, 122);
            this.lciGenelToplam.Name = "lciGenelToplam";
            this.lciGenelToplam.Size = new System.Drawing.Size(185, 24);
            this.lciGenelToplam.Text = "Genel Toplam";
            this.lciGenelToplam.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciGenelToplamDoviz
            // 
            this.lciGenelToplamDoviz.Control = this.lueGenelToplamDoviz;
            this.lciGenelToplamDoviz.CustomizationFormText = "lciGenelToplamDoviz";
            this.lciGenelToplamDoviz.Location = new System.Drawing.Point(424, 122);
            this.lciGenelToplamDoviz.Name = "lciGenelToplamDoviz";
            this.lciGenelToplamDoviz.Size = new System.Drawing.Size(70, 24);
            this.lciGenelToplamDoviz.Text = "lciGenelToplamDoviz";
            this.lciGenelToplamDoviz.TextSize = new System.Drawing.Size(0, 0);
            this.lciGenelToplamDoviz.TextToControlDistance = 0;
            this.lciGenelToplamDoviz.TextVisible = false;
            // 
            // gcFaturaDetay
            // 
            this.gcFaturaDetay.Location = new System.Drawing.Point(0, 382);
            this.gcFaturaDetay.MainView = this.gvFaturaDetay;
            this.gcFaturaDetay.Name = "gcFaturaDetay";
            this.gcFaturaDetay.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueDoviz});
            this.gcFaturaDetay.Size = new System.Drawing.Size(514, 104);
            this.gcFaturaDetay.TabIndex = 7;
            this.gcFaturaDetay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFaturaDetay});
            // 
            // gvFaturaDetay
            // 
            this.gvFaturaDetay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaturaId,
            this.colFaturaAdet,
            this.colFaturaBirimFiyat,
            this.colFaturaToplam,
            this.colFaturaKDV,
            this.colFaturaStopaj,
            this.colFaturaSSDF,
            this.colFaturaGenelToplam,
            this.colFaturaDoviz});
            this.gvFaturaDetay.GridControl = this.gcFaturaDetay;
            this.gvFaturaDetay.Name = "gvFaturaDetay";
            this.gvFaturaDetay.OptionsBehavior.Editable = false;
            this.gvFaturaDetay.OptionsCustomization.AllowFilter = false;
            this.gvFaturaDetay.OptionsFind.AllowFindPanel = false;
            this.gvFaturaDetay.OptionsView.ShowFooter = true;
            this.gvFaturaDetay.OptionsView.ShowGroupPanel = false;
            // 
            // colFaturaId
            // 
            this.colFaturaId.Caption = "ID";
            this.colFaturaId.FieldName = "ID";
            this.colFaturaId.Name = "colFaturaId";
            this.colFaturaId.Width = 30;
            // 
            // colFaturaAdet
            // 
            this.colFaturaAdet.Caption = "Adet";
            this.colFaturaAdet.FieldName = "ADET";
            this.colFaturaAdet.Name = "colFaturaAdet";
            this.colFaturaAdet.Visible = true;
            this.colFaturaAdet.VisibleIndex = 0;
            this.colFaturaAdet.Width = 30;
            // 
            // colFaturaBirimFiyat
            // 
            this.colFaturaBirimFiyat.Caption = "Birim Fiyat";
            this.colFaturaBirimFiyat.FieldName = "BIRIM_TUTAR";
            this.colFaturaBirimFiyat.Name = "colFaturaBirimFiyat";
            this.colFaturaBirimFiyat.Visible = true;
            this.colFaturaBirimFiyat.VisibleIndex = 1;
            this.colFaturaBirimFiyat.Width = 65;
            // 
            // colFaturaToplam
            // 
            this.colFaturaToplam.Caption = "Toplam";
            this.colFaturaToplam.FieldName = "TOPLAM";
            this.colFaturaToplam.Name = "colFaturaToplam";
            this.colFaturaToplam.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFaturaToplam.Visible = true;
            this.colFaturaToplam.VisibleIndex = 2;
            this.colFaturaToplam.Width = 65;
            // 
            // colFaturaKDV
            // 
            this.colFaturaKDV.Caption = "KDV";
            this.colFaturaKDV.FieldName = "KDV_TUTAR";
            this.colFaturaKDV.Name = "colFaturaKDV";
            this.colFaturaKDV.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFaturaKDV.Visible = true;
            this.colFaturaKDV.VisibleIndex = 3;
            this.colFaturaKDV.Width = 65;
            // 
            // colFaturaStopaj
            // 
            this.colFaturaStopaj.Caption = "Stopaj";
            this.colFaturaStopaj.FieldName = "STOPAJ_TUTAR";
            this.colFaturaStopaj.Name = "colFaturaStopaj";
            this.colFaturaStopaj.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFaturaStopaj.Visible = true;
            this.colFaturaStopaj.VisibleIndex = 4;
            this.colFaturaStopaj.Width = 65;
            // 
            // colFaturaSSDF
            // 
            this.colFaturaSSDF.Caption = "SSDF";
            this.colFaturaSSDF.FieldName = "SSDF_TUTAR";
            this.colFaturaSSDF.Name = "colFaturaSSDF";
            this.colFaturaSSDF.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFaturaSSDF.Width = 65;
            // 
            // colFaturaGenelToplam
            // 
            this.colFaturaGenelToplam.Caption = "Genel Toplam";
            this.colFaturaGenelToplam.FieldName = "GENEL_TOPLAM";
            this.colFaturaGenelToplam.Name = "colFaturaGenelToplam";
            this.colFaturaGenelToplam.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFaturaGenelToplam.Visible = true;
            this.colFaturaGenelToplam.VisibleIndex = 5;
            this.colFaturaGenelToplam.Width = 65;
            // 
            // colFaturaDoviz
            // 
            this.colFaturaDoviz.Caption = "Br.";
            this.colFaturaDoviz.ColumnEdit = this.rlueDoviz;
            this.colFaturaDoviz.CustomizationCaption = "Para birimi";
            this.colFaturaDoviz.FieldName = "GENEL_TOPLAM_DOVIZ_ID";
            this.colFaturaDoviz.Name = "colFaturaDoviz";
            this.colFaturaDoviz.Visible = true;
            this.colFaturaDoviz.VisibleIndex = 6;
            this.colFaturaDoviz.Width = 30;
            // 
            // rlueDoviz
            // 
            this.rlueDoviz.AutoHeight = false;
            this.rlueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueDoviz.Name = "rlueDoviz";
            // 
            // dnFaturaDetay
            // 
            this.dnFaturaDetay.DataSource = this.bndFaturaDetay;
            this.dnFaturaDetay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dnFaturaDetay.Location = new System.Drawing.Point(0, 514);
            this.dnFaturaDetay.MyChartControl = null;
            this.dnFaturaDetay.MyGridControl = null;
            this.dnFaturaDetay.MyPivotGridControl = null;
            this.dnFaturaDetay.MyVGridControl = null;
            this.dnFaturaDetay.Name = "dnFaturaDetay";
            this.dnFaturaDetay.SelectButtonVisible = false;
            this.dnFaturaDetay.Size = new System.Drawing.Size(514, 24);
            this.dnFaturaDetay.TabIndex = 6;
            this.dnFaturaDetay.Text = "dnFaturaDetay";
            // 
            // rFrmMeslekMakbuzuKaydetForDava
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 538);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Dava;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.UfakKayitFormu;
            this.MaximizeBox = false;
            this.Name = "rFrmMeslekMakbuzuKaydetForDava";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serbest Meslek Makbuzu Kayýt Ekraný";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.rFrmMeslekMakbuzuKaydetForDava_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUst)).EndInit();
            this.pnlUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcFatura)).EndInit();
            this.lcFatura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndFatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSegment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMuvekkil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBelge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupFatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDosya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMuvekkil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSeriNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReferansNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBelge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcFaturaDetay)).EndInit();
            this.lcFaturaDetay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueGenelToplamDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndFaturaDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSSDFDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStopajDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKdvDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seBirimFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueToplamDoviz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStopajDahil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seAdet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKDVTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStopajTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSSDF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenelToplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKonu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupFaturaDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBirimFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciToplam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBirimFiyatDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKdv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKDVTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopajDahil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciKdvDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStopajDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSSDFTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSSDFDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenelToplam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenelToplamDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFaturaDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFaturaDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueDoviz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        //private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        //private DevExpress.XtraBars.BarButtonItem bBtnKaydetveCik;
        //private DevExpress.XtraBars.BarButtonItem bBtnVazgec;
        private DevExpress.XtraEditors.PanelControl pnlUst;
        private DevExpress.XtraEditors.LookUpEdit lueModul;
        private DevExpress.XtraLayout.LayoutControl lcFatura;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupFatura;
        private DevExpress.XtraLayout.LayoutControlItem lciModul;
        private DevExpress.XtraLayout.LayoutControlItem lciDosya;
        private DevExpress.XtraEditors.LookUpEdit lueSegment;
        private DevExpress.XtraEditors.LookUpEdit lueMuvekkil;
        private DevExpress.XtraLayout.LayoutControlItem lciMuvekkil;
        private DevExpress.XtraLayout.LayoutControlItem lciSegment;
        private DevExpress.XtraEditors.DateEdit deTarih;
        private DevExpress.XtraEditors.TextEdit txtSeriNo;
        private DevExpress.XtraLayout.LayoutControlItem lciSeriNo;
        private DevExpress.XtraLayout.LayoutControlItem lciTarih;
        private DevExpress.XtraEditors.TextEdit txtRefNo;
        private DevExpress.XtraLayout.LayoutControlItem lciReferansNo;
        private DevExpress.XtraLayout.LayoutControl lcFaturaDetay;
        private DevExpress.XtraEditors.LookUpEdit lueGenelToplamDoviz;
        private DevExpress.XtraEditors.LookUpEdit lueSSDFDoviz;
        private DevExpress.XtraEditors.LookUpEdit lueStopajDoviz;
        private DevExpress.XtraEditors.LookUpEdit lueKdvDoviz;
        private DevExpress.XtraEditors.CheckEdit chkStopajDahil;
        private DevExpress.XtraEditors.SpinEdit seBirimFiyat;
        private DevExpress.XtraEditors.LookUpEdit lueToplamDoviz;
        private DevExpress.XtraEditors.CheckEdit chkKDV;
        private DevExpress.XtraEditors.SpinEdit seAdet;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupFaturaDetay;
        private DevExpress.XtraLayout.LayoutControlItem lciAdet;
        private DevExpress.XtraLayout.LayoutControlItem lciKonu;
        private DevExpress.XtraLayout.LayoutControlItem lciBirimFiyat;
        private DevExpress.XtraLayout.LayoutControlItem lciToplam;
        private DevExpress.XtraLayout.LayoutControlItem lciBirimFiyatDovizId;
        private DevExpress.XtraLayout.LayoutControlItem lciKdv;
        private DevExpress.XtraLayout.LayoutControlItem lciKDVTutar;
        private DevExpress.XtraLayout.LayoutControlItem lciStopajDahil;
        private DevExpress.XtraLayout.LayoutControlItem lciStopaj;
        private DevExpress.XtraLayout.LayoutControlItem lciKdvDovizId;
        private DevExpress.XtraLayout.LayoutControlItem lciStopajDovizId;
        private DevExpress.XtraLayout.LayoutControlItem lciSSDFTutar;
        private DevExpress.XtraLayout.LayoutControlItem lciSSDFDovizId;
        private DevExpress.XtraLayout.LayoutControlItem lciGenelToplam;
        private DevExpress.XtraLayout.LayoutControlItem lciGenelToplamDoviz;
        private AdimAdimDavaKaydi.Util.DataNavigatorExtended dnFaturaDetay;
        private DevExpress.XtraGrid.GridControl gcFaturaDetay;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFaturaDetay;
        private DevExpress.XtraEditors.SearchLookUpEdit lueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFOY_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colADLIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colNO;
        private DevExpress.XtraGrid.Columns.GridColumn colGOREV;
        private DevExpress.XtraGrid.Columns.GridColumn colESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTAKIP_TARIHI;
        private System.Windows.Forms.BindingSource bndFatura;
        private System.Windows.Forms.BindingSource bndFaturaDetay;
        private DevExpress.XtraEditors.TextEdit txtToplam;
        private DevExpress.XtraEditors.TextEdit txtKDVTutar;
        private DevExpress.XtraEditors.TextEdit txtStopajTutar;
        private DevExpress.XtraEditors.TextEdit txtSSDF;
        private DevExpress.XtraEditors.TextEdit txtGenelToplam;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaId;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaAdet;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaBirimFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaToplam;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaKDV;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaStopaj;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaSSDF;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaGenelToplam;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaDoviz;
        private DevExpress.XtraLayout.LayoutControlItem lciBelge;
        private DevExpress.XtraEditors.SearchLookUpEdit lueBelge;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit memoKonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDoviz;
    }
}