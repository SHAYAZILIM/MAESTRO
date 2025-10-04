//using AvukatProRaporlar.Raport.Util;
using AvukatProRaporlar.Util;
using AvukatProRaporlar.Raport.Util;
namespace AvukatProRaporlar.Forms
{
    partial class ftmPivotGrid
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.btnPopupKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrafikSecti = new DevExpress.XtraEditors.SimpleButton();
            this.btnListeSecti = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.extendedPivotControl1 = new AvukatProRaporlar.Lib.ExtendedPivotControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.dataNavigatorExtended2 = new AvukatProRaporlar.Raport.Util.DataNavigatorExtended();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.chBoxSutunToplami = new DevExpress.XtraEditors.CheckEdit();
            this.chBoxSatirToplami = new DevExpress.XtraEditors.CheckEdit();
            this.chBoxYonDegis = new DevExpress.XtraEditors.CheckEdit();
            this.lookGrafikSecimi = new DevExpress.XtraEditors.LookUpEdit();
            this.compGridDovizSummary1 = new AvukatProRaporlar.Raport.Util.compGridDovizSummary();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedPivotControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSutunToplami.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSatirToplami.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxYonDegis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrafikSecimi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(726, 692);
            this.panelControl2.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.Options.UseTextOptions = true;
            this.splitContainerControl1.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.popupContainerControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.extendedPivotControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.dataNavigatorExtended2);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.ScrollBarSmallChange = 1;
            this.splitContainerControl1.Size = new System.Drawing.Size(722, 688);
            this.splitContainerControl1.SplitterPosition = 293;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupContainerControl1.Appearance.Options.UseBackColor = true;
            this.popupContainerControl1.Controls.Add(this.btnPopupKapat);
            this.popupContainerControl1.Controls.Add(this.btnGrafikSecti);
            this.popupContainerControl1.Controls.Add(this.btnListeSecti);
            this.popupContainerControl1.Controls.Add(this.groupControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(218, 17);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(293, 130);
            this.popupContainerControl1.TabIndex = 10;
            // 
            // btnPopupKapat
            // 
            this.btnPopupKapat.Location = new System.Drawing.Point(13, 90);
            this.btnPopupKapat.Name = "btnPopupKapat";
            this.btnPopupKapat.Size = new System.Drawing.Size(264, 26);
            this.btnPopupKapat.TabIndex = 4;
            this.btnPopupKapat.Text = "Kapat";
            this.btnPopupKapat.Click += new System.EventHandler(this.btnPopupKapat_Click);
            // 
            // btnGrafikSecti
            // 
            this.btnGrafikSecti.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGrafikSecti.Appearance.Options.UseFont = true;
            this.btnGrafikSecti.Appearance.Options.UseTextOptions = true;
            this.btnGrafikSecti.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btnGrafikSecti.Image = global::AvukatProRaporlar.Properties.Resources.buro_istatistikleri40x40;
            this.btnGrafikSecti.Location = new System.Drawing.Point(151, 31);
            this.btnGrafikSecti.Name = "btnGrafikSecti";
            this.btnGrafikSecti.Size = new System.Drawing.Size(128, 53);
            this.btnGrafikSecti.TabIndex = 3;
            this.btnGrafikSecti.Text = "Grafik";
            this.btnGrafikSecti.Click += new System.EventHandler(this.btnGrafikSecti_Click);
            // 
            // btnListeSecti
            // 
            this.btnListeSecti.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeSecti.Appearance.Options.UseFont = true;
            this.btnListeSecti.Appearance.Options.UseTextOptions = true;
            this.btnListeSecti.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btnListeSecti.Image = global::AvukatProRaporlar.Properties.Resources.tablo_40x40;
            this.btnListeSecti.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnListeSecti.Location = new System.Drawing.Point(14, 31);
            this.btnListeSecti.Name = "btnListeSecti";
            this.btnListeSecti.Size = new System.Drawing.Size(128, 53);
            this.btnListeSecti.TabIndex = 2;
            this.btnListeSecti.Text = "Liste";
            this.btnListeSecti.Click += new System.EventHandler(this.btnListeSecti_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(293, 130);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Tercih Yapınız";
            // 
            // extendedPivotControl1
            // 
            this.extendedPivotControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.extendedPivotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extendedPivotControl1.Location = new System.Drawing.Point(0, 0);
            this.extendedPivotControl1.Name = "extendedPivotControl1";
            this.extendedPivotControl1.Size = new System.Drawing.Size(722, 293);
            this.extendedPivotControl1.TabIndex = 11;
            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 71);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.RuntimeSelection = true;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            pointOptions1.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            this.chartControl1.SeriesTemplate.LegendPointOptions = pointOptions1;
            this.chartControl1.SeriesTemplate.SynchronizePointOptions = false;
            this.chartControl1.Size = new System.Drawing.Size(722, 300);
            this.chartControl1.TabIndex = 7;
            // 
            // dataNavigatorExtended2
            // 
            this.dataNavigatorExtended2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended2.Location = new System.Drawing.Point(0, 371);
            this.dataNavigatorExtended2.MyGridControl = null;
            this.dataNavigatorExtended2.MyPivotGridControl = null;
            this.dataNavigatorExtended2.MyVGridControl = null;
            this.dataNavigatorExtended2.Name = "dataNavigatorExtended2";
            this.dataNavigatorExtended2.SelectButtonVisible = false;
            this.dataNavigatorExtended2.Size = new System.Drawing.Size(722, 19);
            this.dataNavigatorExtended2.TabIndex = 9;
            this.dataNavigatorExtended2.Text = "dataNavigatorExtended2";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(722, 71);
            this.xtraTabControl1.TabIndex = 8;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.chBoxSutunToplami);
            this.xtraTabPage1.Controls.Add(this.chBoxSatirToplami);
            this.xtraTabPage1.Controls.Add(this.chBoxYonDegis);
            this.xtraTabPage1.Controls.Add(this.lookGrafikSecimi);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(716, 43);
            this.xtraTabPage1.Text = "Seçenekler";
            // 
            // chBoxSutunToplami
            // 
            this.chBoxSutunToplami.Location = new System.Drawing.Point(307, 7);
            this.chBoxSutunToplami.Name = "chBoxSutunToplami";
            this.chBoxSutunToplami.Properties.Caption = "Sütun Toplamı";
            this.chBoxSutunToplami.Size = new System.Drawing.Size(115, 19);
            this.chBoxSutunToplami.TabIndex = 3;
            this.chBoxSutunToplami.CheckedChanged += new System.EventHandler(this.chBoxSutunToplami_CheckedChanged);
            // 
            // chBoxSatirToplami
            // 
            this.chBoxSatirToplami.Location = new System.Drawing.Point(213, 7);
            this.chBoxSatirToplami.Name = "chBoxSatirToplami";
            this.chBoxSatirToplami.Properties.Caption = "Satır Toplamı";
            this.chBoxSatirToplami.Size = new System.Drawing.Size(88, 19);
            this.chBoxSatirToplami.TabIndex = 2;
            this.chBoxSatirToplami.CheckedChanged += new System.EventHandler(this.chBoxSatirToplami_CheckedChanged);
            // 
            // chBoxYonDegis
            // 
            this.chBoxYonDegis.Location = new System.Drawing.Point(128, 7);
            this.chBoxYonDegis.Name = "chBoxYonDegis";
            this.chBoxYonDegis.Properties.Caption = "Yön Değiştir";
            this.chBoxYonDegis.Size = new System.Drawing.Size(75, 19);
            this.chBoxYonDegis.TabIndex = 1;
            this.chBoxYonDegis.CheckedChanged += new System.EventHandler(this.chBoxYonDegis_CheckedChanged);
            // 
            // lookGrafikSecimi
            // 
            this.lookGrafikSecimi.Location = new System.Drawing.Point(9, 6);
            this.lookGrafikSecimi.Name = "lookGrafikSecimi";
            this.lookGrafikSecimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGrafikSecimi.Properties.NullText = "Grafik Seçin";
            this.lookGrafikSecimi.Size = new System.Drawing.Size(100, 20);
            this.lookGrafikSecimi.TabIndex = 0;
            this.lookGrafikSecimi.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // compGridDovizSummary1
            // 
            this.compGridDovizSummary1.AltToplamlarAktifMi = false;
            this.compGridDovizSummary1.MyGridView = null;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(424, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // ftmPivotGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 692);
            this.Controls.Add(this.panelControl2);
            this.Name = "ftmPivotGrid";
            this.Text = "pivotGrid";
            this.Load += new System.EventHandler(this.pivotGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extendedPivotControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSutunToplami.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxSatirToplami.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBoxYonDegis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGrafikSecimi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.CheckEdit chBoxSutunToplami;
        private DevExpress.XtraEditors.CheckEdit chBoxSatirToplami;
        private DevExpress.XtraEditors.CheckEdit chBoxYonDegis;
        private DevExpress.XtraEditors.LookUpEdit lookGrafikSecimi;
        private DataNavigatorExtended dataNavigatorExtended2;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnPopupKapat;
        private DevExpress.XtraEditors.SimpleButton btnGrafikSecti;
        private DevExpress.XtraEditors.SimpleButton btnListeSecti;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private AvukatProRaporlar.Lib.ExtendedPivotControl extendedPivotControl1;
        private compGridDovizSummary compGridDovizSummary1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}