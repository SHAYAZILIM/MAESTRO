namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucSeriAlacakNeden
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
            this.lstAlacakNedenleri = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dtVadeT = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtTutar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rLueDovizId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rLueAlacakNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl44 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.gun = new DevExpress.XtraEditors.SpinEdit();
            this.adet = new DevExpress.XtraEditors.SpinEdit();
            this.ay = new DevExpress.XtraEditors.SpinEdit();
            this.btnSeriKayit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl45 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lstAlacakNedenleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeT.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAlacakNedenleri
            // 
            this.lstAlacakNedenleri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn1});
            this.lstAlacakNedenleri.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstAlacakNedenleri.Location = new System.Drawing.Point(0, 0);
            this.lstAlacakNedenleri.Name = "lstAlacakNedenleri";
            this.lstAlacakNedenleri.OptionsBehavior.Editable = false;
            this.lstAlacakNedenleri.OptionsView.ShowPreview = true;
            this.lstAlacakNedenleri.PreviewFieldName = "ALACAK_NEDEN_KOD_ID";
            this.lstAlacakNedenleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueAlacakNeden,
            this.rLueDovizId,
            this.txtTutar,
            this.dtVadeT});
            this.lstAlacakNedenleri.Size = new System.Drawing.Size(283, 342);
            this.lstAlacakNedenleri.TabIndex = 34;
            this.lstAlacakNedenleri.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.lstAlacakNedenleri_FocusedNodeChanged);
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Vade T.";
            this.treeListColumn2.ColumnEdit = this.dtVadeT;
            this.treeListColumn2.FieldName = "VADE_TARIHI";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            this.treeListColumn2.Width = 116;
            // 
            // dtVadeT
            // 
            this.dtVadeT.AutoHeight = false;
            this.dtVadeT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVadeT.Name = "dtVadeT";
            this.dtVadeT.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.dtVadeT.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Tutarý";
            this.treeListColumn3.ColumnEdit = this.txtTutar;
            this.treeListColumn3.FieldName = "TUTARI";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            this.treeListColumn3.Width = 89;
            // 
            // txtTutar
            // 
            this.txtTutar.AutoHeight = false;
            this.txtTutar.Mask.EditMask = "c0";
            this.txtTutar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTutar.Name = "txtTutar";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.ColumnEdit = this.rLueDovizId;
            this.treeListColumn4.FieldName = "TUTAR_DOVIZ_ID";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 54;
            // 
            // rLueDovizId
            // 
            this.rLueDovizId.AutoHeight = false;
            this.rLueDovizId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDovizId.Name = "rLueDovizId";
            this.rLueDovizId.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.ColumnEdit = this.rLueAlacakNeden;
            this.treeListColumn1.FieldName = "ALACAK_NEDEN_KOD_ID";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // rLueAlacakNeden
            // 
            this.rLueAlacakNeden.AutoHeight = false;
            this.rLueAlacakNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueAlacakNeden.Name = "rLueAlacakNeden";
            this.rLueAlacakNeden.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.memoEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(283, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(475, 342);
            this.panelControl1.TabIndex = 35;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.memoEdit1.Location = new System.Drawing.Point(2, 168);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Size = new System.Drawing.Size(471, 172);
            this.memoEdit1.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Sonuç :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl44);
            this.panel1.Controls.Add(this.labelControl42);
            this.panel1.Controls.Add(this.gun);
            this.panel1.Controls.Add(this.adet);
            this.panel1.Controls.Add(this.ay);
            this.panel1.Controls.Add(this.btnSeriKayit);
            this.panel1.Controls.Add(this.labelControl45);
            this.panel1.Controls.Add(this.labelControl30);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl41);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 138);
            this.panel1.TabIndex = 20;
            // 
            // labelControl44
            // 
            this.labelControl44.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl44.Appearance.Options.UseFont = true;
            this.labelControl44.Location = new System.Drawing.Point(6, 13);
            this.labelControl44.Name = "labelControl44";
            this.labelControl44.Size = new System.Drawing.Size(446, 14);
            this.labelControl44.TabIndex = 10;
            this.labelControl44.Text = "Seçili Alacak Nedeni Üzerinden Takip Eden Aydan Baþlamak Üzere :";
            // 
            // labelControl42
            // 
            this.labelControl42.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl42.Appearance.Options.UseFont = true;
            this.labelControl42.Location = new System.Drawing.Point(231, 45);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(139, 14);
            this.labelControl42.TabIndex = 10;
            this.labelControl42.Text = "ayda bir olmak üzere";
            // 
            // gun
            // 
            this.gun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.gun.Location = new System.Drawing.Point(42, 42);
            this.gun.Name = "gun";
            this.gun.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gun.Size = new System.Drawing.Size(61, 22);
            this.gun.TabIndex = 18;
            // 
            // adet
            // 
            this.adet.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.adet.Location = new System.Drawing.Point(376, 41);
            this.adet.Name = "adet";
            this.adet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.adet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.adet.Size = new System.Drawing.Size(61, 22);
            this.adet.TabIndex = 18;
            // 
            // ay
            // 
            this.ay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ay.Location = new System.Drawing.Point(168, 42);
            this.ay.Name = "ay";
            this.ay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.ay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ay.Size = new System.Drawing.Size(60, 22);
            this.ay.TabIndex = 18;
            // 
            // btnSeriKayit
            // 
            this.btnSeriKayit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSeriKayit.Location = new System.Drawing.Point(1, 106);
            this.btnSeriKayit.Name = "btnSeriKayit";
            this.btnSeriKayit.Size = new System.Drawing.Size(470, 30);
            this.btnSeriKayit.TabIndex = 17;
            this.btnSeriKayit.Text = "Seri Kayýt Baþlat";
            this.btnSeriKayit.Click += new System.EventHandler(this.btnSeriKayit_Click);
            // 
            // labelControl45
            // 
            this.labelControl45.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl45.Appearance.Options.UseFont = true;
            this.labelControl45.Location = new System.Drawing.Point(106, 45);
            this.labelControl45.Name = "labelControl45";
            this.labelControl45.Size = new System.Drawing.Size(56, 14);
            this.labelControl45.TabIndex = 10;
            this.labelControl45.Text = ". gününe";
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Location = new System.Drawing.Point(7, 45);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(29, 14);
            this.labelControl30.TabIndex = 10;
            this.labelControl30.Text = "Ayýn";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(145, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "alacak nedeni oluþtur.";
            // 
            // labelControl41
            // 
            this.labelControl41.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl41.Appearance.Options.UseFont = true;
            this.labelControl41.Location = new System.Drawing.Point(438, 45);
            this.labelControl41.Name = "labelControl41";
            this.labelControl41.Size = new System.Drawing.Size(29, 14);
            this.labelControl41.TabIndex = 10;
            this.labelControl41.Text = "adet";
            // 
            // ucSeriAlacakNeden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lstAlacakNedenleri);
            this.Name = "ucSeriAlacakNeden";
            this.Size = new System.Drawing.Size(758, 342);
            this.Load += new System.EventHandler(this.ucSeriAlacakNeden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstAlacakNedenleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeT.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDovizId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueAlacakNeden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList lstAlacakNedenleri;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SpinEdit gun;
        private DevExpress.XtraEditors.LabelControl labelControl44;
        private DevExpress.XtraEditors.SimpleButton btnSeriKayit;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.LabelControl labelControl45;
        private DevExpress.XtraEditors.SpinEdit ay;
        private DevExpress.XtraEditors.SpinEdit adet;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueAlacakNeden;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDovizId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtTutar;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtVadeT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;

    }
}
