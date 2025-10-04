namespace  AdimAdimDavaKaydi.UserControls.UcDava
{
    partial class ucDavaSMS
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
            this.gridDavaSMS = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwDavaSMS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colORGINATOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEKRAR_UST_SINIR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEKRAR_PERYOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMESAJ_METNI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAYFA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSON_GSM_OP_RESPONSE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDavaSMS
            // 
            this.gridDavaSMS.CustomButtonlarGorunmesin = false;
            this.gridDavaSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDavaSMS.DoNotExtendEmbedNavigator = false;
            this.gridDavaSMS.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridDavaSMS.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridDavaSMS.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridDavaSMS.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(6, 6, true, true, "Yeni Kayýt Ekle", "FormdanEkle"),
            new DevExpress.XtraEditors.NavigatorCustomButton(20, 20, true, true, "Kaydý Düzenle", "Duzenle")});
            this.gridDavaSMS.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridDavaSMS_EmbeddedNavigator_ButtonClick);
            this.gridDavaSMS.FilterText = null;
            this.gridDavaSMS.FilterValue = null;
            this.gridDavaSMS.GridlerDuzenlenebilir = true;
            this.gridDavaSMS.GridsFilterControl = null;
            this.gridDavaSMS.Location = new System.Drawing.Point(0, 0);
            this.gridDavaSMS.MainView = this.gwDavaSMS;
            this.gridDavaSMS.MyGridStyle = null;
            this.gridDavaSMS.Name = "gridDavaSMS";
            this.gridDavaSMS.ShowRowNumbers = false;
            this.gridDavaSMS.SilmeKaldirilsin = false;
            this.gridDavaSMS.Size = new System.Drawing.Size(732, 499);
            this.gridDavaSMS.TabIndex = 0;
            this.gridDavaSMS.TemizleKaldirGorunsunmu = false;
            this.gridDavaSMS.UniqueId = "e1b6efad-594e-4a8a-b110-dea433f2fe75";
            this.gridDavaSMS.UseEmbeddedNavigator = true;
            this.gridDavaSMS.UseHyperDragDrop = false;
            this.gridDavaSMS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDavaSMS});
            // 
            // gwDavaSMS
            // 
            this.gwDavaSMS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colORGINATOR,
            this.colTEKRAR_UST_SINIR,
            this.colTEKRAR_PERYOD,
            this.colMESAJ_METNI,
            this.colSAYFA_NO,
            this.colSON_GSM_OP_RESPONSE});
            this.gwDavaSMS.GridControl = this.gridDavaSMS;
            this.gwDavaSMS.IndicatorWidth = 20;
            this.gwDavaSMS.Name = "gwDavaSMS";
            this.gwDavaSMS.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDavaSMS.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDavaSMS.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDavaSMS.OptionsView.ColumnAutoWidth = false;
            this.gwDavaSMS.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwDavaSMS.OptionsView.ShowAutoFilterRow = true;
            this.gwDavaSMS.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDavaSMS.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gwDavaSMS.OptionsView.ShowPreview = true;
            this.gwDavaSMS.PreviewFieldName = "MESAJ_METNI";
            // 
            // colORGINATOR
            // 
            this.colORGINATOR.Caption = "Orginatör";
            this.colORGINATOR.FieldName = "ORGINATOR";
            this.colORGINATOR.Name = "colORGINATOR";
            this.colORGINATOR.OptionsColumn.ReadOnly = true;
            this.colORGINATOR.Visible = true;
            this.colORGINATOR.VisibleIndex = 0;
            this.colORGINATOR.Width = 173;
            // 
            // colTEKRAR_UST_SINIR
            // 
            this.colTEKRAR_UST_SINIR.Caption = "Tekrar Üst Sýnýr";
            this.colTEKRAR_UST_SINIR.FieldName = "TEKRAR_UST_SINIR";
            this.colTEKRAR_UST_SINIR.Name = "colTEKRAR_UST_SINIR";
            this.colTEKRAR_UST_SINIR.OptionsColumn.ReadOnly = true;
            this.colTEKRAR_UST_SINIR.Visible = true;
            this.colTEKRAR_UST_SINIR.VisibleIndex = 1;
            this.colTEKRAR_UST_SINIR.Width = 186;
            // 
            // colTEKRAR_PERYOD
            // 
            this.colTEKRAR_PERYOD.Caption = "Tekrar Peryod";
            this.colTEKRAR_PERYOD.FieldName = "TEKRAR_PERYOD";
            this.colTEKRAR_PERYOD.Name = "colTEKRAR_PERYOD";
            this.colTEKRAR_PERYOD.OptionsColumn.ReadOnly = true;
            this.colTEKRAR_PERYOD.Visible = true;
            this.colTEKRAR_PERYOD.VisibleIndex = 3;
            this.colTEKRAR_PERYOD.Width = 136;
            // 
            // colMESAJ_METNI
            // 
            this.colMESAJ_METNI.Caption = "Mesaj Metni";
            this.colMESAJ_METNI.FieldName = "MESAJ_METNI";
            this.colMESAJ_METNI.Name = "colMESAJ_METNI";
            this.colMESAJ_METNI.OptionsColumn.ReadOnly = true;
            this.colMESAJ_METNI.Visible = true;
            this.colMESAJ_METNI.VisibleIndex = 2;
            this.colMESAJ_METNI.Width = 168;
            // 
            // colSAYFA_NO
            // 
            this.colSAYFA_NO.Caption = "Sayfa No";
            this.colSAYFA_NO.FieldName = "SAYFA_NO";
            this.colSAYFA_NO.Name = "colSAYFA_NO";
            this.colSAYFA_NO.OptionsColumn.ReadOnly = true;
            this.colSAYFA_NO.Visible = true;
            this.colSAYFA_NO.VisibleIndex = 4;
            // 
            // colSON_GSM_OP_RESPONSE
            // 
            this.colSON_GSM_OP_RESPONSE.Caption = "Son GSM Operatorü";
            this.colSON_GSM_OP_RESPONSE.FieldName = "SON_GSM_OP_RESPONSE";
            this.colSON_GSM_OP_RESPONSE.Name = "colSON_GSM_OP_RESPONSE";
            this.colSON_GSM_OP_RESPONSE.OptionsColumn.ReadOnly = true;
            this.colSON_GSM_OP_RESPONSE.Visible = true;
            this.colSON_GSM_OP_RESPONSE.VisibleIndex = 5;
            this.colSON_GSM_OP_RESPONSE.Width = 105;
            // 
            // gridControl1
            // 
            this.gridControl1.CustomButtonlarGorunmesin = false;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.FilterText = null;
            this.gridControl1.FilterValue = null;
            this.gridControl1.GridlerDuzenlenebilir = true;
            this.gridControl1.GridsFilterControl = null;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.MyGridStyle = null;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowRowNumbers = false;
            this.gridControl1.SilmeKaldirilsin = false;
            this.gridControl1.Size = new System.Drawing.Size(732, 499);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.TemizleKaldirGorunsunmu = false;
            this.gridControl1.UniqueId = "926223e3-4823-425b-8e16-bc0ac5759a97";
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            this.gridControl1.Visible = false;
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Kayýt {0}";
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Orginatör";
            this.gridColumn1.FieldName = "ORGINATOR";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 173;
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(99, 13);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tekrar Üst Sýnýr";
            this.gridColumn2.FieldName = "TEKRAR_UST_SINIR";
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 186;
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(0, 27);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tekrar Peryod";
            this.gridColumn3.FieldName = "TEKRAR_PERYOD";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 136;
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(0, 54);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mesaj Metni";
            this.gridColumn4.FieldName = "MESAJ_METNI";
            this.gridColumn4.LayoutViewField = this.layoutViewField_gridColumn4;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 168;
            // 
            // layoutViewField_gridColumn4
            // 
            this.layoutViewField_gridColumn4.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn4.Location = new System.Drawing.Point(0, 81);
            this.layoutViewField_gridColumn4.Name = "layoutViewField_gridColumn4";
            this.layoutViewField_gridColumn4.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn4.TextSize = new System.Drawing.Size(99, 13);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Sayfa No";
            this.gridColumn5.FieldName = "SAYFA_NO";
            this.gridColumn5.LayoutViewField = this.layoutViewField_gridColumn5;
            this.gridColumn5.Name = "gridColumn5";
            // 
            // layoutViewField_gridColumn5
            // 
            this.layoutViewField_gridColumn5.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn5.Location = new System.Drawing.Point(0, 108);
            this.layoutViewField_gridColumn5.Name = "layoutViewField_gridColumn5";
            this.layoutViewField_gridColumn5.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn5.TextSize = new System.Drawing.Size(99, 13);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Son GSM Operatorü";
            this.gridColumn6.FieldName = "SON_GSM_OP_RESPONSE";
            this.gridColumn6.LayoutViewField = this.layoutViewField_gridColumn6;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 105;
            // 
            // layoutViewField_gridColumn6
            // 
            this.layoutViewField_gridColumn6.EditorPreferredWidth = 92;
            this.layoutViewField_gridColumn6.Location = new System.Drawing.Point(0, 135);
            this.layoutViewField_gridColumn6.Name = "layoutViewField_gridColumn6";
            this.layoutViewField_gridColumn6.Size = new System.Drawing.Size(207, 27);
            this.layoutViewField_gridColumn6.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn1,
            this.layoutViewField_gridColumn2,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn4,
            this.layoutViewField_gridColumn5,
            this.layoutViewField_gridColumn6});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // ucDavaSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDavaSMS);
            this.Controls.Add(this.gridControl1);
            this.Name = "ucDavaSMS";
            this.Size = new System.Drawing.Size(732, 499);
            ((System.ComponentModel.ISupportInitialize)(this.gridDavaSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDavaSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDavaSMS;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDavaSMS;
        private DevExpress.XtraGrid.Columns.GridColumn colORGINATOR;
        private DevExpress.XtraGrid.Columns.GridColumn colTEKRAR_UST_SINIR;
        private DevExpress.XtraGrid.Columns.GridColumn colTEKRAR_PERYOD;
        private DevExpress.XtraGrid.Columns.GridColumn colMESAJ_METNI;
        private DevExpress.XtraGrid.Columns.GridColumn colSAYFA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSON_GSM_OP_RESPONSE;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}
