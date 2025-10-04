namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class ucMehilBilgileri
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
            this.extMehilBilgileri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colILAM_BILGI_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIlamBilgi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMehilIsteyenCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAYA_SEVK_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_MEHIL_KARAR_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_MEHIL_KARAR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_MEHIL_ESAS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueMehilKararSonuc = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colYARGITAY_MEHIL_MUDDETI_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_MEHIL_MUDDETI_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEK_MEHIL_VAR_MI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEK_MEHIL_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMEHIL_DEVAM_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colICRA_ERTELEME_NEDEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLueIcraErtelemeNeden = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.extMehilBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMehilIsteyenCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMehilKararSonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIcraErtelemeNeden)).BeginInit();
            this.SuspendLayout();
            // 
            // extMehilBilgileri
            // 
            this.extMehilBilgileri.CustomButtonlarGorunmesin = false;
            this.extMehilBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extMehilBilgileri.DoNotExtendEmbedNavigator = false;
            this.extMehilBilgileri.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.extMehilBilgileri.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.extMehilBilgileri.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt Ekle", "FormdanEkle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kayýt Düzenle", "KaydiDuzenle")});
            this.extMehilBilgileri.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.extMehilBilgileri_ButtonClick);
            this.extMehilBilgileri.FilterText = null;
            this.extMehilBilgileri.FilterValue = null;
            this.extMehilBilgileri.GridlerDuzenlenebilir = true;
            this.extMehilBilgileri.GridsFilterControl = null;
            this.extMehilBilgileri.Location = new System.Drawing.Point(0, 0);
            this.extMehilBilgileri.MainView = this.gridView1;
            this.extMehilBilgileri.MyGridStyle = null;
            this.extMehilBilgileri.Name = "extMehilBilgileri";
            this.extMehilBilgileri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueIlamBilgi,
            this.rLueMehilIsteyenCari,
            this.rLueMehilKararSonuc,
            this.rLueIcraErtelemeNeden});
            this.extMehilBilgileri.ShowRowNumbers = false;
            this.extMehilBilgileri.SilmeKaldirilsin = false;
            this.extMehilBilgileri.Size = new System.Drawing.Size(779, 507);
            this.extMehilBilgileri.TabIndex = 0;
            this.extMehilBilgileri.TemizleKaldirGorunsunmu = false;
            this.extMehilBilgileri.UniqueId = "2d95591f-40e5-4417-a4e8-9291b1700e56";
            this.extMehilBilgileri.UseEmbeddedNavigator = true;
            this.extMehilBilgileri.UseHyperDragDrop = false;
            this.extMehilBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colILAM_BILGI_ID,
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID,
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI,
            this.colYARGITAYA_SEVK_TARIHI,
            this.colYARGITAY_MEHIL_KARAR_TARIHI,
            this.colYARGITAY_MEHIL_KARAR_NO,
            this.colYARGITAY_MEHIL_ESAS_NO,
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID,
            this.colYARGITAY_MEHIL_MUDDETI_AY,
            this.colYARGITAY_MEHIL_MUDDETI_GUN,
            this.colEK_MEHIL_VAR_MI,
            this.colEK_MEHIL_TARIHI,
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY,
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN,
            this.colMEHIL_DEVAM_TARIHI,
            this.colICRA_ERTELEME_NEDEN_ID});
            this.gridView1.GridControl = this.extMehilBilgileri;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            // 
            // colILAM_BILGI_ID
            // 
            this.colILAM_BILGI_ID.Caption = "Ýlam Bilgi";
            this.colILAM_BILGI_ID.ColumnEdit = this.rLueIlamBilgi;
            this.colILAM_BILGI_ID.FieldName = "ILAM_BILGI_ID";
            this.colILAM_BILGI_ID.Name = "colILAM_BILGI_ID";
            this.colILAM_BILGI_ID.OptionsColumn.ReadOnly = true;
            this.colILAM_BILGI_ID.Visible = true;
            this.colILAM_BILGI_ID.VisibleIndex = 0;
            // 
            // rLueIlamBilgi
            // 
            this.rLueIlamBilgi.AutoHeight = false;
            this.rLueIlamBilgi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIlamBilgi.Name = "rLueIlamBilgi";
            // 
            // colICRA_MEHIL_ISTEYEN_TARAF_ID
            // 
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.Caption = "Mehil Ýsteyen";
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.ColumnEdit = this.rLueMehilIsteyenCari;
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.FieldName = "ICRA_MEHIL_ISTEYEN_TARAF_ID";
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.Name = "colICRA_MEHIL_ISTEYEN_TARAF_ID";
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.OptionsColumn.ReadOnly = true;
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.Visible = true;
            this.colICRA_MEHIL_ISTEYEN_TARAF_ID.VisibleIndex = 1;
            // 
            // rLueMehilIsteyenCari
            // 
            this.rLueMehilIsteyenCari.AutoHeight = false;
            this.rLueMehilIsteyenCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMehilIsteyenCari.Name = "rLueMehilIsteyenCari";
            // 
            // colICRA_MEHIL_ILAM_TEMYIZ_TARIHI
            // 
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.Caption = "Temyiz T";
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.FieldName = "ICRA_MEHIL_ILAM_TEMYIZ_TARIHI";
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.Name = "colICRA_MEHIL_ILAM_TEMYIZ_TARIHI";
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.OptionsColumn.ReadOnly = true;
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.Visible = true;
            this.colICRA_MEHIL_ILAM_TEMYIZ_TARIHI.VisibleIndex = 2;
            // 
            // colYARGITAYA_SEVK_TARIHI
            // 
            this.colYARGITAYA_SEVK_TARIHI.Caption = "Sevk T";
            this.colYARGITAYA_SEVK_TARIHI.FieldName = "YARGITAYA_SEVK_TARIHI";
            this.colYARGITAYA_SEVK_TARIHI.Name = "colYARGITAYA_SEVK_TARIHI";
            this.colYARGITAYA_SEVK_TARIHI.OptionsColumn.ReadOnly = true;
            this.colYARGITAYA_SEVK_TARIHI.Visible = true;
            this.colYARGITAYA_SEVK_TARIHI.VisibleIndex = 3;
            // 
            // colYARGITAY_MEHIL_KARAR_TARIHI
            // 
            this.colYARGITAY_MEHIL_KARAR_TARIHI.Caption = "Karar T";
            this.colYARGITAY_MEHIL_KARAR_TARIHI.FieldName = "YARGITAY_MEHIL_KARAR_TARIHI";
            this.colYARGITAY_MEHIL_KARAR_TARIHI.Name = "colYARGITAY_MEHIL_KARAR_TARIHI";
            this.colYARGITAY_MEHIL_KARAR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_KARAR_TARIHI.Visible = true;
            this.colYARGITAY_MEHIL_KARAR_TARIHI.VisibleIndex = 4;
            // 
            // colYARGITAY_MEHIL_KARAR_NO
            // 
            this.colYARGITAY_MEHIL_KARAR_NO.Caption = "Karar No";
            this.colYARGITAY_MEHIL_KARAR_NO.FieldName = "YARGITAY_MEHIL_KARAR_NO";
            this.colYARGITAY_MEHIL_KARAR_NO.Name = "colYARGITAY_MEHIL_KARAR_NO";
            this.colYARGITAY_MEHIL_KARAR_NO.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_KARAR_NO.Visible = true;
            this.colYARGITAY_MEHIL_KARAR_NO.VisibleIndex = 5;
            // 
            // colYARGITAY_MEHIL_ESAS_NO
            // 
            this.colYARGITAY_MEHIL_ESAS_NO.Caption = "Esas No";
            this.colYARGITAY_MEHIL_ESAS_NO.FieldName = "YARGITAY_MEHIL_ESAS_NO";
            this.colYARGITAY_MEHIL_ESAS_NO.Name = "colYARGITAY_MEHIL_ESAS_NO";
            this.colYARGITAY_MEHIL_ESAS_NO.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_ESAS_NO.Visible = true;
            this.colYARGITAY_MEHIL_ESAS_NO.VisibleIndex = 6;
            // 
            // colYARGITAY_MEHIL_KARAR_SONUCU_ID
            // 
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.Caption = "Karar Sonucu";
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.ColumnEdit = this.rLueMehilKararSonuc;
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.FieldName = "YARGITAY_MEHIL_KARAR_SONUCU_ID";
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.Name = "colYARGITAY_MEHIL_KARAR_SONUCU_ID";
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.Visible = true;
            this.colYARGITAY_MEHIL_KARAR_SONUCU_ID.VisibleIndex = 7;
            // 
            // rLueMehilKararSonuc
            // 
            this.rLueMehilKararSonuc.AutoHeight = false;
            this.rLueMehilKararSonuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueMehilKararSonuc.Name = "rLueMehilKararSonuc";
            // 
            // colYARGITAY_MEHIL_MUDDETI_AY
            // 
            this.colYARGITAY_MEHIL_MUDDETI_AY.Caption = "Müddet";
            this.colYARGITAY_MEHIL_MUDDETI_AY.FieldName = "YARGITAY_MEHIL_MUDDETI_AY";
            this.colYARGITAY_MEHIL_MUDDETI_AY.Name = "colYARGITAY_MEHIL_MUDDETI_AY";
            this.colYARGITAY_MEHIL_MUDDETI_AY.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_MUDDETI_AY.Visible = true;
            this.colYARGITAY_MEHIL_MUDDETI_AY.VisibleIndex = 8;
            // 
            // colYARGITAY_MEHIL_MUDDETI_GUN
            // 
            this.colYARGITAY_MEHIL_MUDDETI_GUN.Caption = "Gün";
            this.colYARGITAY_MEHIL_MUDDETI_GUN.FieldName = "YARGITAY_MEHIL_MUDDETI_GUN";
            this.colYARGITAY_MEHIL_MUDDETI_GUN.Name = "colYARGITAY_MEHIL_MUDDETI_GUN";
            this.colYARGITAY_MEHIL_MUDDETI_GUN.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_MEHIL_MUDDETI_GUN.Visible = true;
            this.colYARGITAY_MEHIL_MUDDETI_GUN.VisibleIndex = 9;
            // 
            // colEK_MEHIL_VAR_MI
            // 
            this.colEK_MEHIL_VAR_MI.Caption = "Ek Mehil";
            this.colEK_MEHIL_VAR_MI.FieldName = "EK_MEHIL_VAR_MI";
            this.colEK_MEHIL_VAR_MI.Name = "colEK_MEHIL_VAR_MI";
            this.colEK_MEHIL_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colEK_MEHIL_VAR_MI.Visible = true;
            this.colEK_MEHIL_VAR_MI.VisibleIndex = 10;
            // 
            // colEK_MEHIL_TARIHI
            // 
            this.colEK_MEHIL_TARIHI.Caption = "Ek Mehil T";
            this.colEK_MEHIL_TARIHI.FieldName = "EK_MEHIL_TARIHI";
            this.colEK_MEHIL_TARIHI.Name = "colEK_MEHIL_TARIHI";
            this.colEK_MEHIL_TARIHI.OptionsColumn.ReadOnly = true;
            this.colEK_MEHIL_TARIHI.Visible = true;
            this.colEK_MEHIL_TARIHI.VisibleIndex = 11;
            // 
            // colYARGITAY_EK_MEHIL_MUDDETI_AY
            // 
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.Caption = "Ek Müddet";
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.FieldName = "YARGITAY_EK_MEHIL_MUDDETI_AY";
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.Name = "colYARGITAY_EK_MEHIL_MUDDETI_AY";
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.Visible = true;
            this.colYARGITAY_EK_MEHIL_MUDDETI_AY.VisibleIndex = 12;
            // 
            // colYARGITAY_EK_MEHIL_MUDDETI_GUN
            // 
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.Caption = "Gün";
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.FieldName = "YARGITAY_EK_MEHIL_MUDDETI_GUN";
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.Name = "colYARGITAY_EK_MEHIL_MUDDETI_GUN";
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.OptionsColumn.ReadOnly = true;
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.Visible = true;
            this.colYARGITAY_EK_MEHIL_MUDDETI_GUN.VisibleIndex = 13;
            // 
            // colMEHIL_DEVAM_TARIHI
            // 
            this.colMEHIL_DEVAM_TARIHI.Caption = "Devam T";
            this.colMEHIL_DEVAM_TARIHI.FieldName = "MEHIL_DEVAM_TARIHI";
            this.colMEHIL_DEVAM_TARIHI.Name = "colMEHIL_DEVAM_TARIHI";
            this.colMEHIL_DEVAM_TARIHI.OptionsColumn.ReadOnly = true;
            this.colMEHIL_DEVAM_TARIHI.Visible = true;
            this.colMEHIL_DEVAM_TARIHI.VisibleIndex = 14;
            // 
            // colICRA_ERTELEME_NEDEN_ID
            // 
            this.colICRA_ERTELEME_NEDEN_ID.Caption = "Ýcra Erteleme Neden";
            this.colICRA_ERTELEME_NEDEN_ID.ColumnEdit = this.rLueIcraErtelemeNeden;
            this.colICRA_ERTELEME_NEDEN_ID.FieldName = "ICRA_ERTELEME_NEDEN_ID";
            this.colICRA_ERTELEME_NEDEN_ID.Name = "colICRA_ERTELEME_NEDEN_ID";
            this.colICRA_ERTELEME_NEDEN_ID.OptionsColumn.ReadOnly = true;
            this.colICRA_ERTELEME_NEDEN_ID.Visible = true;
            this.colICRA_ERTELEME_NEDEN_ID.VisibleIndex = 15;
            // 
            // rLueIcraErtelemeNeden
            // 
            this.rLueIcraErtelemeNeden.AutoHeight = false;
            this.rLueIcraErtelemeNeden.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueIcraErtelemeNeden.Name = "rLueIcraErtelemeNeden";
            // 
            // ucMehilBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extMehilBilgileri);
            this.Name = "ucMehilBilgileri";
            this.Size = new System.Drawing.Size(779, 507);
            this.Load += new System.EventHandler(this.ucMehilBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.extMehilBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIlamBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMehilIsteyenCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueMehilKararSonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueIcraErtelemeNeden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl extMehilBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colILAM_BILGI_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_MEHIL_ISTEYEN_TARAF_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_MEHIL_ILAM_TEMYIZ_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAYA_SEVK_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_KARAR_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_KARAR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_ESAS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_KARAR_SONUCU_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_MUDDETI_AY;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_MEHIL_MUDDETI_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn colEK_MEHIL_VAR_MI;
        private DevExpress.XtraGrid.Columns.GridColumn colEK_MEHIL_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_EK_MEHIL_MUDDETI_AY;
        private DevExpress.XtraGrid.Columns.GridColumn colYARGITAY_EK_MEHIL_MUDDETI_GUN;
        private DevExpress.XtraGrid.Columns.GridColumn colMEHIL_DEVAM_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colICRA_ERTELEME_NEDEN_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIlamBilgi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMehilIsteyenCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueMehilKararSonuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueIcraErtelemeNeden;
    }
}
