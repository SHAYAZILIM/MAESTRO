namespace AdimAdimDavaKaydi.Forms
{
    partial class frmTebligatIliskiEkle
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.popupContainerTebligatlar = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupTebligatlar = new DevExpress.XtraEditors.PopupContainerControl();
            this.gcTebligatList = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnIliskiKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcIliskiliTebligatlar = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerTebligatlar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTebligatlar)).BeginInit();
            this.popupTebligatlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTebligatList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIliskiliTebligatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.popupContainerTebligatlar);
            this.groupControl1.Controls.Add(this.popupTebligatlar);
            this.groupControl1.Controls.Add(this.sbtnIliskiKaydet);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(606, 157);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Yeni İlişki";
            // 
            // popupContainerTebligatlar
            // 
            this.popupContainerTebligatlar.EditValue = "Seçilen Tebligatlar";
            this.popupContainerTebligatlar.Location = new System.Drawing.Point(67, 37);
            this.popupContainerTebligatlar.Name = "popupContainerTebligatlar";
            this.popupContainerTebligatlar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerTebligatlar.Properties.PopupControl = this.popupTebligatlar;
            this.popupContainerTebligatlar.Size = new System.Drawing.Size(511, 20);
            this.popupContainerTebligatlar.TabIndex = 10;
            // 
            // popupTebligatlar
            // 
            this.popupTebligatlar.Controls.Add(this.gcTebligatList);
            this.popupTebligatlar.Location = new System.Drawing.Point(67, 92);
            this.popupTebligatlar.Name = "popupTebligatlar";
            this.popupTebligatlar.Size = new System.Drawing.Size(436, 183);
            this.popupTebligatlar.TabIndex = 9;
            // 
            // gcTebligatList
            // 
            this.gcTebligatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTebligatList.Location = new System.Drawing.Point(0, 0);
            this.gcTebligatList.MainView = this.gridView5;
            this.gcTebligatList.Name = "gcTebligatList";
            this.gcTebligatList.Size = new System.Drawing.Size(436, 183);
            this.gcTebligatList.TabIndex = 1;
            this.gcTebligatList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView5.GridControl = this.gcTebligatList;
            this.gridView5.GroupCount = 1;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView5.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn6, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Seç";
            this.gridColumn12.FieldName = "IsSelected";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Referans No";
            this.gridColumn6.FieldName = "TEBLIGAT_REFERANS_NO";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tebligat Konu";
            this.gridColumn7.FieldName = "TEBLIGAT_KONU";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Dosya No";
            this.gridColumn8.FieldName = "TEBLIGAT_ESAS_NO";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Muhatap";
            this.gridColumn9.FieldName = "MUHATAP_AD";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tarih / Sayı";
            this.gridColumn10.FieldName = "ILK_TEBLIGAT_YAPAN_ADI";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Açıklama";
            this.gridColumn11.FieldName = "ACIKLAMA";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // sbtnIliskiKaydet
            // 
            this.sbtnIliskiKaydet.Location = new System.Drawing.Point(179, 63);
            this.sbtnIliskiKaydet.Name = "sbtnIliskiKaydet";
            this.sbtnIliskiKaydet.Size = new System.Drawing.Size(225, 23);
            this.sbtnIliskiKaydet.TabIndex = 2;
            this.sbtnIliskiKaydet.Text = "İlişki Ekle";
            this.sbtnIliskiKaydet.Click += new System.EventHandler(this.sbtnIliskiKaydet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tebligatlar";
            // 
            // gcIliskiliTebligatlar
            // 
            this.gcIliskiliTebligatlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIliskiliTebligatlar.Location = new System.Drawing.Point(0, 157);
            this.gcIliskiliTebligatlar.MainView = this.gridView4;
            this.gcIliskiliTebligatlar.Name = "gcIliskiliTebligatlar";
            this.gcIliskiliTebligatlar.Size = new System.Drawing.Size(606, 297);
            this.gcIliskiliTebligatlar.TabIndex = 3;
            this.gcIliskiliTebligatlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn18,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gridView4.GridControl = this.gcIliskiliTebligatlar;
            this.gridView4.GroupCount = 1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView4.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Referans No";
            this.gridColumn13.FieldName = "TEBLIGAT_REFERANS_NO";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tebligat Konu";
            this.gridColumn14.FieldName = "TEBLIGAT_KONU";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Dosya No";
            this.gridColumn18.FieldName = "TEBLIGAT_ESAS_NO";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Muhatap";
            this.gridColumn15.FieldName = "MUHATAP_AD";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Tarih / Sayı";
            this.gridColumn16.FieldName = "ILK_TEBLIGAT_YAPAN_ADI";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 3;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Açıklama";
            this.gridColumn17.FieldName = "ACIKLAMA";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            // 
            // frmTebligatIliskiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 454);
            this.Controls.Add(this.gcIliskiliTebligatlar);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmTebligatIliskiEkle";
            this.Text = "Tebligat İlişki Ekle";
            this.Load += new System.EventHandler(this.frmTebligatIliskiEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerTebligatlar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTebligatlar)).EndInit();
            this.popupTebligatlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTebligatList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIliskiliTebligatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerTebligatlar;
        private DevExpress.XtraEditors.PopupContainerControl popupTebligatlar;
        private DevExpress.XtraGrid.GridControl gcTebligatList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.SimpleButton sbtnIliskiKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcIliskiliTebligatlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}