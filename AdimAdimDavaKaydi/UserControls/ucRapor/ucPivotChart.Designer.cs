namespace  AdimAdimDavaKaydi.UserControls.ucRapor
{
    partial class ucPivotChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPivotChart));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnGorunumuKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPopupKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnListeSecti = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrafikSecti = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinSonucSayisi = new DevExpress.XtraEditors.SpinEdit();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.pivotGridControl1 = new AdimAdimDavaKaydi.Util.ExtendedPivotControl();
            this.ucChartDesignerControlPanel1 = new AdimAdimDavaKaydi.UserControls.ucRapor.ucChartDesignerControlPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinSonucSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnGorunumuKaydet);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnExcel);
            this.splitContainerControl1.Panel1.Controls.Add(this.popupContainerControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.spinSonucSayisi);
            this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.ucChartDesignerControlPanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(868, 427);
            this.splitContainerControl1.SplitterPosition = 199;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnGorunumuKaydet
            // 
            this.btnGorunumuKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnGorunumuKaydet.Image")));
            this.btnGorunumuKaydet.Location = new System.Drawing.Point(129, 3);
            this.btnGorunumuKaydet.Name = "btnGorunumuKaydet";
            this.btnGorunumuKaydet.Size = new System.Drawing.Size(120, 23);
            this.btnGorunumuKaydet.TabIndex = 13;
            this.btnGorunumuKaydet.Text = "Görünümü Kaydet";
            this.btnGorunumuKaydet.Click += new System.EventHandler(this.btnGorunumuKaydet_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(3, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(120, 23);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "Excel\'e Gönder";
            this.btnExcel.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupContainerControl1.Appearance.Options.UseBackColor = true;
            this.popupContainerControl1.Controls.Add(this.groupControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(288, 34);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(293, 130);
            this.popupContainerControl1.TabIndex = 11;
            // 
            // groupControl1
            // 
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.groupControl1.Controls.Add(this.btnPopupKapat);
            this.groupControl1.Controls.Add(this.btnListeSecti);
            this.groupControl1.Controls.Add(this.btnGrafikSecti);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(293, 130);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Tercih Yapýnýz";
            this.groupControl1.Visible = false;
            // 
            // btnPopupKapat
            // 
            this.btnPopupKapat.Location = new System.Drawing.Point(5, 84);
            this.btnPopupKapat.Name = "btnPopupKapat";
            this.btnPopupKapat.Size = new System.Drawing.Size(264, 26);
            this.btnPopupKapat.TabIndex = 8;
            this.btnPopupKapat.Text = "Kapat";
            this.btnPopupKapat.Click += new System.EventHandler(this.btnPopupKapat_Click);
            // 
            // btnListeSecti
            // 
            this.btnListeSecti.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeSecti.Appearance.Options.UseFont = true;
            this.btnListeSecti.Appearance.Options.UseTextOptions = true;
            this.btnListeSecti.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btnListeSecti.Image = ((System.Drawing.Image)(resources.GetObject("btnListeSecti.Image")));
            this.btnListeSecti.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnListeSecti.Location = new System.Drawing.Point(5, 25);
            this.btnListeSecti.Name = "btnListeSecti";
            this.btnListeSecti.Size = new System.Drawing.Size(128, 53);
            this.btnListeSecti.TabIndex = 6;
            this.btnListeSecti.Text = "Liste";
            this.btnListeSecti.Click += new System.EventHandler(this.btnListeSecti_Click);
            // 
            // btnGrafikSecti
            // 
            this.btnGrafikSecti.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGrafikSecti.Appearance.Options.UseFont = true;
            this.btnGrafikSecti.Appearance.Options.UseTextOptions = true;
            this.btnGrafikSecti.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnGrafikSecti.Image = ((System.Drawing.Image)(resources.GetObject("btnGrafikSecti.Image")));
            this.btnGrafikSecti.Location = new System.Drawing.Point(139, 25);
            this.btnGrafikSecti.Name = "btnGrafikSecti";
            this.btnGrafikSecti.Size = new System.Drawing.Size(128, 53);
            this.btnGrafikSecti.TabIndex = 7;
            this.btnGrafikSecti.Text = "Grafik";
            this.btnGrafikSecti.Click += new System.EventHandler(this.btnGrafikSecti_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(689, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Sonuç Sayýsý";
            // 
            // spinSonucSayisi
            // 
            this.spinSonucSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinSonucSayisi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinSonucSayisi.Location = new System.Drawing.Point(754, 6);
            this.spinSonucSayisi.Name = "spinSonucSayisi";
            this.spinSonucSayisi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinSonucSayisi.Size = new System.Drawing.Size(100, 20);
            this.spinSonucSayisi.TabIndex = 3;
            this.spinSonucSayisi.EditValueChanged += new System.EventHandler(this.spinSonucSayisi_EditValueChanged);
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Location = new System.Drawing.Point(15, -20);
            this.chartControl1.Name = "chartControl1";
            sideBySideBarSeriesLabel1.LineVisible = true;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.Name = "Series";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            sideBySideBarSeriesLabel2.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartControl1.Size = new System.Drawing.Size(864, 168);
            this.chartControl1.TabIndex = 0;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 32);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(864, 163);
            this.pivotGridControl1.TabIndex = 0;
            // 
            // ucChartDesignerControlPanel1
            // 
            this.ucChartDesignerControlPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucChartDesignerControlPanel1.Location = new System.Drawing.Point(-2, 167);
            this.ucChartDesignerControlPanel1.MyChartControl = null;
            this.ucChartDesignerControlPanel1.Name = "ucChartDesignerControlPanel1";
            this.ucChartDesignerControlPanel1.Size = new System.Drawing.Size(724, 50);
            this.ucChartDesignerControlPanel1.TabIndex = 1;
            // 
            // ucPivotChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucPivotChart";
            this.Size = new System.Drawing.Size(868, 427);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinSonucSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinSonucSayisi;
        private  AdimAdimDavaKaydi.Util.ExtendedPivotControl pivotGridControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private ucChartDesignerControlPanel ucChartDesignerControlPanel1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPopupKapat;
        private DevExpress.XtraEditors.SimpleButton btnListeSecti;
        private DevExpress.XtraEditors.SimpleButton btnGrafikSecti;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnGorunumuKaydet;
    }
}
