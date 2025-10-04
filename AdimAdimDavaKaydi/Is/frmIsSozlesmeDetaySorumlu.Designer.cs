namespace  AdimAdimDavaKaydi.Is
{
    partial class frmIsSozlesmeDetaySorumlu
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
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rLueSorumlu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spMiktar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rLueDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rLueSureBirimTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rowSORUMLU_CARI_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIS_MIKTAR = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDOVIZ_ID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSURE_BIRIM_TIP = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSURE = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.dataNavigatorExtended1 = new AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumlu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSureBirimTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 219);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(598, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(448, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(523, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.vGridControl1);
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Controls.Add(this.dataNavigatorExtended1);
            this.c_pnlContainer.Size = new System.Drawing.Size(598, 268);
            this.c_pnlContainer.Controls.SetChildIndex(this.dataNavigatorExtended1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.vGridControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // vGridControl1
            // 
            this.vGridControl1.DataSource = this.bindingSource1;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(0, 83);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 195;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rLueSorumlu,
            this.spMiktar,
            this.rLueDoviz,
            this.rLueSureBirimTip});
            this.vGridControl1.RowHeaderWidth = 175;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowSORUMLU_CARI_ID,
            this.rowIS_MIKTAR,
            this.rowDOVIZ_ID,
            this.rowSURE_BIRIM_TIP,
            this.rowSURE});
            this.vGridControl1.Size = new System.Drawing.Size(598, 161);
            this.vGridControl1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(AvukatProLib2.Entities.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU);
            // 
            // rLueSorumlu
            // 
            this.rLueSorumlu.AutoHeight = false;
            this.rLueSorumlu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSorumlu.Name = "rLueSorumlu";
            // 
            // spMiktar
            // 
            this.spMiktar.AutoHeight = false;
            this.spMiktar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spMiktar.Name = "spMiktar";
            // 
            // rLueDoviz
            // 
            this.rLueDoviz.AutoHeight = false;
            this.rLueDoviz.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueDoviz.Name = "rLueDoviz";
            // 
            // rLueSureBirimTip
            // 
            this.rLueSureBirimTip.AutoHeight = false;
            this.rLueSureBirimTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rLueSureBirimTip.Name = "rLueSureBirimTip";
            // 
            // rowSORUMLU_CARI_ID
            // 
            this.rowSORUMLU_CARI_ID.Name = "rowSORUMLU_CARI_ID";
            this.rowSORUMLU_CARI_ID.Properties.Caption = "Sorumlu";
            this.rowSORUMLU_CARI_ID.Properties.FieldName = "SORUMLU_CARI_ID";
            this.rowSORUMLU_CARI_ID.Properties.RowEdit = this.rLueSorumlu;
            // 
            // rowIS_MIKTAR
            // 
            this.rowIS_MIKTAR.Name = "rowIS_MIKTAR";
            this.rowIS_MIKTAR.Properties.Caption = "Miktar";
            this.rowIS_MIKTAR.Properties.FieldName = "IS_MIKTAR";
            this.rowIS_MIKTAR.Properties.RowEdit = this.spMiktar;
            // 
            // rowDOVIZ_ID
            // 
            this.rowDOVIZ_ID.Name = "rowDOVIZ_ID";
            this.rowDOVIZ_ID.Properties.Caption = "Brm";
            this.rowDOVIZ_ID.Properties.FieldName = "DOVIZ_ID";
            this.rowDOVIZ_ID.Properties.RowEdit = this.rLueDoviz;
            // 
            // rowSURE_BIRIM_TIP
            // 
            this.rowSURE_BIRIM_TIP.Name = "rowSURE_BIRIM_TIP";
            this.rowSURE_BIRIM_TIP.Properties.Caption = "Birim Tip";
            this.rowSURE_BIRIM_TIP.Properties.FieldName = "SURE_BIRIM_TIP";
            this.rowSURE_BIRIM_TIP.Properties.RowEdit = this.rLueSureBirimTip;
            // 
            // rowSURE
            // 
            this.rowSURE.Name = "rowSURE";
            this.rowSURE.Properties.Caption = "Süre";
            this.rowSURE.Properties.FieldName = "SURE";
            // 
            // dataNavigatorExtended1
            // 
            this.dataNavigatorExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigatorExtended1.Location = new System.Drawing.Point(0, 244);
            this.dataNavigatorExtended1.MyChartControl = null;
            this.dataNavigatorExtended1.MyGridControl = null;
            this.dataNavigatorExtended1.MyPivotGridControl = null;
            this.dataNavigatorExtended1.MyVGridControl = null;
            this.dataNavigatorExtended1.Name = "dataNavigatorExtended1";
            this.dataNavigatorExtended1.SelectButtonVisible = false;
            this.dataNavigatorExtended1.Size = new System.Drawing.Size(598, 24);
            this.dataNavigatorExtended1.TabIndex = 1;
            this.dataNavigatorExtended1.Text = "dataNavigatorExtended1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lookUpEdit2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Enabled = false;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(598, 83);
            this.panelControl1.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(133, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Size = new System.Drawing.Size(304, 32);
            this.textEdit1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Kategorisi";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "İş Sözleşmesi";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Enabled = false;
            this.lookUpEdit2.Location = new System.Drawing.Point(133, 50);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Size = new System.Drawing.Size(304, 20);
            this.lookUpEdit2.TabIndex = 1;
            // 
            // frmIsSozlesmeDetaySorumlu
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 268);
            this.Name = "frmIsSozlesmeDetaySorumlu";
            this.Text = "frmIsSozlesmeDetaySorumlu";
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSorumlu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueDoviz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLueSureBirimTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSORUMLU_CARI_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIS_MIKTAR;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDOVIZ_ID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSURE_BIRIM_TIP;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSURE;
        private AvukatPro.IcraTakipWin.UserControls.DataNavigatorExtended dataNavigatorExtended1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSorumlu;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spMiktar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueDoviz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rLueSureBirimTip;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}