namespace  AdimAdimDavaKaydi
{
    partial class ucKiymetliEvrakTaraf
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.bndKEvrakTaraf = new System.Windows.Forms.BindingSource(this.components);
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.rlueTaraf = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueTarafTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowTARAF_TIP_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTARAF_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTAKIBE_KONULDU_MU = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            ((System.ComponentModel.ISupportInitialize)(this.bndKEvrakTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTaraf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafTip)).BeginInit();
            this.SuspendLayout();
            // 
            // bndKEvrakTaraf
            // 
            this.bndKEvrakTaraf.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF);
            // 
            // vGridControl1
            // 
            this.vGridControl1.DataSource = this.bndKEvrakTaraf;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.ExternalRepository = this.persistentRepository1;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 122;
            this.vGridControl1.RowHeaderWidth = 78;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTARAF_TIP_ID,
            this.rowTARAF_CARI_ID,
            this.rowTAKIBE_KONULDU_MU});
            this.vGridControl1.Size = new System.Drawing.Size(531, 306);
            this.vGridControl1.TabIndex = 2;
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueTaraf,
            this.rLueTarafTip});
            // 
            // rlueTaraf
            // 
            this.rlueTaraf.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "CariEkle", null, false)});
            this.rlueTaraf.Name = "rlueTaraf";
            this.rlueTaraf.NullText = "Taraf Tipi";
            this.rlueTaraf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.rlueTaraf.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rlueTaraf_ButtonClick);
            this.rlueTaraf.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.rlueTaraf_ProcessNewValue);
            // 
            // rLueTarafTip
            // 
            this.rLueTarafTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueTarafTip.Name = "rLueTarafTip";
            this.rLueTarafTip.NullText = "Taraf";
            // 
            // rowTARAF_TIP_ID
            // 
            this.rowTARAF_TIP_ID.Height = 22;
            this.rowTARAF_TIP_ID.Name = "rowTARAF_TIP_ID";
            this.rowTARAF_TIP_ID.Properties.Caption = "Tipi";
            this.rowTARAF_TIP_ID.Properties.FieldName = "TARAF_TIP_ID";
            this.rowTARAF_TIP_ID.Properties.RowEdit = this.rLueTarafTip;
            // 
            // rowTARAF_CARI_ID
            // 
            this.rowTARAF_CARI_ID.Height = 24;
            this.rowTARAF_CARI_ID.Name = "rowTARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.Caption = "Taraf";
            this.rowTARAF_CARI_ID.Properties.FieldName = "TARAF_CARI_ID";
            this.rowTARAF_CARI_ID.Properties.RowEdit = this.rlueTaraf;
            // 
            // rowTAKIBE_KONULDU_MU
            // 
            this.rowTAKIBE_KONULDU_MU.Height = 26;
            this.rowTAKIBE_KONULDU_MU.Name = "rowTAKIBE_KONULDU_MU";
            this.rowTAKIBE_KONULDU_MU.Properties.Caption = "Takibe Konuldu";
            this.rowTAKIBE_KONULDU_MU.Properties.FieldName = "TAKIBE_KONULDU_MU";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 306);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = this.vGridControl1;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(531, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // ucKiymetliEvrakTaraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.dataNavigatorExtended1);
            this.Name = "ucKiymetliEvrakTaraf";
            this.Size = new System.Drawing.Size(531, 330);
            ((System.ComponentModel.ISupportInitialize)(this.bndKEvrakTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueTaraf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueTarafTip)).EndInit();
            this.ResumeLayout(false);

         }

        #endregion

        private System.Windows.Forms.BindingSource bndKEvrakTaraf;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        public DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        public DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTARAF_TIP_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTAKIBE_KONULDU_MU;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueTaraf;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueTarafTip;
    }
}
