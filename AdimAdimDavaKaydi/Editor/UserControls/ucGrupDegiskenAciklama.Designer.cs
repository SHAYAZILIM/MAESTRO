namespace  AdimAdimDavaKaydi.Editor.UserControls
{
    partial class ucGrupDegiskenAciklama
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
            this.components = new System.ComponentModel.Container();
            this.lueFormTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTAKIP_TALEP_KOD_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colALACAK_NEDENI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLuealacakNedenGetir = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.lblForm = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit5 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueDovizIslemTipi = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFormTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuealacakNedenGetir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDovizIslemTipi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueFormTipi
            // 
            this.lueFormTipi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "Form_Tipi", true));
            this.lueFormTipi.Location = new System.Drawing.Point(102, 13);
            this.lueFormTipi.Name = "lueFormTipi";
            this.lueFormTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFormTipi.Size = new System.Drawing.Size(148, 20);
            this.lueFormTipi.TabIndex = 6;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AdimAdimDavaKaydi.Editor.UserControls.DegiskenAciklama);
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bindingSource1, "KodAlacakNedenler", true));
            this.gridControl1.Location = new System.Drawing.Point(18, 39);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLuealacakNedenGetir,
            this.repositoryItemImageComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(357, 126);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTAKIP_TALEP_KOD_ID,
            this.colALACAK_NEDENI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colTAKIP_TALEP_KOD_ID
            // 
            this.colTAKIP_TALEP_KOD_ID.Caption = "Takip Talep Kodu";
            this.colTAKIP_TALEP_KOD_ID.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colTAKIP_TALEP_KOD_ID.FieldName = "TAKIP_TALEP_KOD_ID";
            this.colTAKIP_TALEP_KOD_ID.Name = "colTAKIP_TALEP_KOD_ID";
            this.colTAKIP_TALEP_KOD_ID.Visible = true;
            this.colTAKIP_TALEP_KOD_ID.VisibleIndex = 0;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colALACAK_NEDENI
            // 
            this.colALACAK_NEDENI.Caption = "Alacak Nedeni";
            this.colALACAK_NEDENI.ColumnEdit = this.rLuealacakNedenGetir;
            this.colALACAK_NEDENI.FieldName = "ID";
            this.colALACAK_NEDENI.Name = "colALACAK_NEDENI";
            this.colALACAK_NEDENI.Visible = true;
            this.colALACAK_NEDENI.VisibleIndex = 1;
            // 
            // rLuealacakNedenGetir
            // 
            this.rLuealacakNedenGetir.AutoHeight = false;
            this.rLuealacakNedenGetir.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLuealacakNedenGetir.Name = "rLuealacakNedenGetir";
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "DovizliMi", true));
            this.checkEdit1.Location = new System.Drawing.Point(394, 129);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Dovizli";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 8;
            // 
            // checkEdit2
            // 
            this.checkEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "YtlLiMi", true));
            this.checkEdit2.Location = new System.Drawing.Point(394, 104);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Ytl li";
            this.checkEdit2.Size = new System.Drawing.Size(75, 19);
            this.checkEdit2.TabIndex = 8;
            // 
            // checkEdit3
            // 
            this.checkEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "FAIZ_YOK_MU", true));
            this.checkEdit3.Location = new System.Drawing.Point(394, 79);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Faiz Yok";
            this.checkEdit3.Size = new System.Drawing.Size(75, 19);
            this.checkEdit3.TabIndex = 8;
            // 
            // checkEdit4
            // 
            this.checkEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "AlacakNedeniVeyaIle", true));
            this.checkEdit4.Location = new System.Drawing.Point(394, 54);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "Alacak Nenenleri Veya ile baðlý";
            this.checkEdit4.Size = new System.Drawing.Size(213, 19);
            this.checkEdit4.TabIndex = 8;
            // 
            // lblForm
            // 
            this.lblForm.Location = new System.Drawing.Point(18, 16);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(43, 13);
            this.lblForm.TabIndex = 9;
            this.lblForm.Text = "Form Tipi";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(263, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Doviz Ýþlem Tipi";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(470, 287);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(100, 23);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // memoEdit5
            // 
            this.memoEdit5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "Aciklama", true));
            this.memoEdit5.Location = new System.Drawing.Point(18, 171);
            this.memoEdit5.Name = "memoEdit5";
            this.memoEdit5.Size = new System.Drawing.Size(528, 96);
            this.memoEdit5.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(364, 287);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 23);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.DataSource = this.bindingSource1;
            this.dataNavigator1.Location = new System.Drawing.Point(18, 269);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(243, 21);
            this.dataNavigator1.TabIndex = 14;
            this.dataNavigator1.Text = "dataNavigator1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(280, 273);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "{0} / {1}";
            // 
            // lueDovizIslemTipi
            // 
            this.lueDovizIslemTipi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "DOVIZ_ISLEM_TIPI", true));
            this.lueDovizIslemTipi.Location = new System.Drawing.Point(364, 13);
            this.lueDovizIslemTipi.Name = "lueDovizIslemTipi";
            this.lueDovizIslemTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDovizIslemTipi.Size = new System.Drawing.Size(148, 20);
            this.lueDovizIslemTipi.TabIndex = 6;
            // 
            // ucGrupDegiskenAciklama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dataNavigator1);
            this.Controls.Add(this.memoEdit5);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit4);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lueDovizIslemTipi);
            this.Controls.Add(this.lueFormTipi);
            this.Name = "ucGrupDegiskenAciklama";
            this.Size = new System.Drawing.Size(582, 313);
            this.Load += new System.EventHandler(this.ucGrupDegiskenAciklama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueFormTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLuealacakNedenGetir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDovizIslemTipi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueFormTipi;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.LabelControl lblForm;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn colTAKIP_TALEP_KOD_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colALACAK_NEDENI;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.MemoEdit memoEdit5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLuealacakNedenGetir;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.LookUpEdit lueDovizIslemTipi;

    }
}
