namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucIlamTarafBilgileri
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.vgAlacakNedenTaraf = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rlkTarafSifat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkTarafCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkTarafKodu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowTarafK = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTarafSifat = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTaraf = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataNavigatorExtended1 = new AdimAdimDavaKaydi.Util.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.vgAlacakNedenTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafSifat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vgAlacakNedenTaraf
            // 
            this.vgAlacakNedenTaraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgAlacakNedenTaraf.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vgAlacakNedenTaraf.Location = new System.Drawing.Point(2, 20);
            this.vgAlacakNedenTaraf.Name = "vgAlacakNedenTaraf";
            this.vgAlacakNedenTaraf.OptionsBehavior.UseEnterAsTab = true;
            this.vgAlacakNedenTaraf.RecordWidth = 269;
            this.vgAlacakNedenTaraf.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkTarafSifat,
            this.rlkTarafCari,
            this.rlkTarafKodu});
            this.vgAlacakNedenTaraf.RowHeaderWidth = 188;
            this.vgAlacakNedenTaraf.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTarafK,
            this.rowTarafSifat,
            this.rowTaraf});
            this.vgAlacakNedenTaraf.Size = new System.Drawing.Size(546, 193);
            this.vgAlacakNedenTaraf.TabIndex = 1;
            // 
            // rlkTarafSifat
            // 
            this.rlkTarafSifat.AutoHeight = false;
            this.rlkTarafSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "CariEkle", null)});
            this.rlkTarafSifat.Name = "rlkTarafSifat";
            this.rlkTarafSifat.NullText = "<>";
            // 
            // rlkTarafCari
            // 
            this.rlkTarafCari.AutoHeight = false;
            this.rlkTarafCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "CariEkle", null)});
            this.rlkTarafCari.Name = "rlkTarafCari";
            this.rlkTarafCari.NullText = "<>";
            this.rlkTarafCari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlkTarafCari.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlkTarafCari_ButtonClick);
            this.rlkTarafCari.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlkTarafCari_ProcessNewValue);
            // 
            // rlkTarafKodu
            // 
            this.rlkTarafKodu.AutoHeight = false;
            this.rlkTarafKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkTarafKodu.Name = "rlkTarafKodu";
            // 
            // rowTarafK
            // 
            this.rowTarafK.Name = "rowTarafK";
            this.rowTarafK.Properties.Caption = "T.K";
            this.rowTarafK.Properties.FieldName = "TARAF_KOD_ID";
            this.rowTarafK.Properties.RowEdit = this.rlkTarafKodu;
            // 
            // rowTarafSifat
            // 
            this.rowTarafSifat.Name = "rowTarafSifat";
            this.rowTarafSifat.Properties.Caption = "Sıfat";
            this.rowTarafSifat.Properties.FieldName = "TARAF_SIFAT_ID";
            this.rowTarafSifat.Properties.RowEdit = this.rlkTarafSifat;
            // 
            // rowTaraf
            // 
            this.rowTaraf.Name = "rowTaraf";
            this.rowTaraf.Properties.Caption = "Taraf";
            this.rowTaraf.Properties.FieldName = "ILAM_TARAF_CARI_ID";
            this.rowTaraf.Properties.RowEdit = this.rlkTarafCari;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.vgAlacakNedenTaraf);
            this.groupControl1.Controls.Add(this.dataNavigatorExtended1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(550, 239);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "İlam Mahkemesi Tarafları";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Buttons.Append.Visible = false;
            this.dataNavigatorExtended1.Buttons.CancelEdit.Visible = false;
            this.dataNavigatorExtended1.Buttons.NextPage.Visible = false;
            this.dataNavigatorExtended1.Buttons.PrevPage.Visible = false;
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(2, 213);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vgAlacakNedenTaraf;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(546, 24);
            this.dataNavigatorExtended1.TabIndex = 2;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.dataNavigatorExtended1.TextStringFormat = "Taraf {0} / {1}";
            // 
            // ucIlamTarafBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "ucIlamTarafBilgileri";
            this.Size = new System.Drawing.Size(550, 239);
            this.Load += new System.EventHandler(this.ucIlamTarafBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vgAlacakNedenTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkTarafKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgAlacakNedenTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTarafSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTarafCari;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkTarafKodu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public AdimAdimDavaKaydi.Util.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTarafK;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTarafSifat;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTaraf;
    }
}
