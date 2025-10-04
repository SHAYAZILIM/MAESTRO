using AvukatProLib.Util;

namespace  AvukatProLib.Bakim
{
    partial class frmVeriTabaniOlustur
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
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties1 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties2 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties multiEditorRowProperties4 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties();
            this.rICbHA = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rIcbMK = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grbMevcutVeriTabani = new DevExpress.XtraEditors.GroupControl();
            this.grdVeriTabanlari = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.cVeriTabaniOlusturBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rowHAIcýnYaratilacakVeriTabaniAdi = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.rowMKIcýnYaratilacakVeriTabaniAdi = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
            this.cRHA = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.crMK = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.rICbHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIcbMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbMevcutVeriTabani)).BeginInit();
            this.grbMevcutVeriTabani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVeriTabanlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVeriTabaniOlusturBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rICbHA
            // 
            this.rICbHA.AutoHeight = false;
            this.rICbHA.Name = "rICbHA";
            // 
            // rIcbMK
            // 
            this.rIcbMK.AutoHeight = false;
            this.rIcbMK.Name = "rIcbMK";
            // 
            // grbMevcutVeriTabani
            // 
            this.grbMevcutVeriTabani.Controls.Add(this.grdVeriTabanlari);
            this.grbMevcutVeriTabani.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbMevcutVeriTabani.Location = new System.Drawing.Point(0, 0);
            this.grbMevcutVeriTabani.Name = "grbMevcutVeriTabani";
            this.grbMevcutVeriTabani.Size = new System.Drawing.Size(274, 413);
            this.grbMevcutVeriTabani.TabIndex = 1;
            this.grbMevcutVeriTabani.Text = "Mevcut Veri Tabanlarý ";
            // 
            // grdVeriTabanlari
            // 
            this.grdVeriTabanlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVeriTabanlari.Location = new System.Drawing.Point(2, 20);
            this.grdVeriTabanlari.MainView = this.gridView1;
            this.grdVeriTabanlari.Name = "grdVeriTabanlari";
            this.grdVeriTabanlari.Size = new System.Drawing.Size(270, 391);
            this.grdVeriTabanlari.TabIndex = 0;
            this.grdVeriTabanlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdVeriTabanlari;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // vGridControl1
            // 
            this.vGridControl1.Appearance.Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.vGridControl1.Appearance.Category.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.vGridControl1.Appearance.Category.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.Category.Options.UseBackColor = true;
            this.vGridControl1.Appearance.Category.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.Category.Options.UseFont = true;
            this.vGridControl1.Appearance.Category.Options.UseForeColor = true;
            this.vGridControl1.Appearance.CategoryExpandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.CategoryExpandButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.CategoryExpandButton.Options.UseBackColor = true;
            this.vGridControl1.Appearance.CategoryExpandButton.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.vGridControl1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.vGridControl1.Appearance.Empty.Options.UseBackColor = true;
            this.vGridControl1.Appearance.ExpandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(205)))), ((int)(((byte)(202)))));
            this.vGridControl1.Appearance.ExpandButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(205)))), ((int)(((byte)(202)))));
            this.vGridControl1.Appearance.ExpandButton.Options.UseBackColor = true;
            this.vGridControl1.Appearance.ExpandButton.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.vGridControl1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.vGridControl1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.vGridControl1.Appearance.FocusedRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.vGridControl1.Appearance.FocusedRecord.Options.UseBackColor = true;
            this.vGridControl1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.vGridControl1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.vGridControl1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(223)))), ((int)(((byte)(220)))));
            this.vGridControl1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(195)))), ((int)(((byte)(191)))));
            this.vGridControl1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.vGridControl1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.vGridControl1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.vGridControl1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.HorzLine.Options.UseBackColor = true;
            this.vGridControl1.Appearance.RecordValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.vGridControl1.Appearance.RecordValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.vGridControl1.Appearance.RecordValue.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.RecordValue.Options.UseBackColor = true;
            this.vGridControl1.Appearance.RecordValue.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.RecordValue.Options.UseForeColor = true;
            this.vGridControl1.Appearance.RowHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(222)))));
            this.vGridControl1.Appearance.RowHeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(214)))), ((int)(((byte)(211)))));
            this.vGridControl1.Appearance.RowHeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseBackColor = true;
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseBorderColor = true;
            this.vGridControl1.Appearance.RowHeaderPanel.Options.UseForeColor = true;
            this.vGridControl1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(188)))), ((int)(((byte)(184)))));
            this.vGridControl1.Appearance.VertLine.Options.UseBackColor = true;
            this.vGridControl1.DataSource = this.cVeriTabaniOlusturBindingSource;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(274, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 140;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rICbHA,
            this.rIcbMK});
            this.vGridControl1.RowHeaderWidth = 297;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowHAIcýnYaratilacakVeriTabaniAdi,
            this.rowMKIcýnYaratilacakVeriTabaniAdi,
            this.cRHA,
            this.crMK});
            this.vGridControl1.Size = new System.Drawing.Size(397, 389);
            this.vGridControl1.TabIndex = 2;
            // 
            // cVeriTabaniOlusturBindingSource
            // 
            this.cVeriTabaniOlusturBindingSource.DataSource = typeof(AvukatProLib.Util.VeriTabaniOlustur);
            // 
            // rowHAIcýnYaratilacakVeriTabaniAdi
            // 
            this.rowHAIcýnYaratilacakVeriTabaniAdi.Name = "rowHAIcýnYaratilacakVeriTabaniAdi";
            multiEditorRowProperties1.Caption = "(Hukuk Ailesi Ýçin )Yaratilacak Veri Tabani Adi";
            multiEditorRowProperties1.CellWidth = 63;
            multiEditorRowProperties1.FieldName = "HAIcýnYaratilacakVeriTabaniAdi";
            multiEditorRowProperties1.Width = 244;
            multiEditorRowProperties2.Caption = "AVP_";
            multiEditorRowProperties2.CellWidth = 36;
            multiEditorRowProperties2.FieldName = "AVP_";
            multiEditorRowProperties2.RowEdit = this.rICbHA;
            multiEditorRowProperties2.Width = 39;
            this.rowHAIcýnYaratilacakVeriTabaniAdi.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties1,
            multiEditorRowProperties2});
            // 
            // rowMKIcýnYaratilacakVeriTabaniAdi
            // 
            this.rowMKIcýnYaratilacakVeriTabaniAdi.Name = "rowMKIcýnYaratilacakVeriTabaniAdi";
            multiEditorRowProperties3.Caption = "(Mevzuat Karar Ýçin) Yaratilacak Veri Tabani Adi";
            multiEditorRowProperties3.CellWidth = 87;
            multiEditorRowProperties3.FieldName = "MKIcýnYaratilacakVeriTabaniAdi";
            multiEditorRowProperties3.Width = 243;
            multiEditorRowProperties4.Caption = "AVP";
            multiEditorRowProperties4.CellWidth = 52;
            multiEditorRowProperties4.FieldName = "AVP_";
            multiEditorRowProperties4.RowEdit = this.rIcbMK;
            multiEditorRowProperties4.Width = 40;
            this.rowMKIcýnYaratilacakVeriTabaniAdi.PropertiesCollection.AddRange(new DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties[] {
            multiEditorRowProperties3,
            multiEditorRowProperties4});
            // 
            // cRHA
            // 
            this.cRHA.Name = "cRHA";
            this.cRHA.Properties.Caption = "Hukuk Ailesi Ýçin Veri Tabaný Oluþturulmayacak ";
            // 
            // crMK
            // 
            this.crMK.Name = "crMK";
            this.crMK.Properties.Caption = "Mevzuat Karar Ýçin Veri Tabaný Oluþturulmayacak ";
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.DataSource = this.cVeriTabaniOlusturBindingSource;
            this.dataNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator1.Location = new System.Drawing.Point(274, 389);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(397, 24);
            this.dataNavigator1.TabIndex = 3;
            this.dataNavigator1.Text = "dataNavigator1";
            // 
            // frmVeriTabaniOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 413);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.dataNavigator1);
            this.Controls.Add(this.grbMevcutVeriTabani);
            this.Name = "frmVeriTabaniOlustur";
            this.Text = "Veri Tabani Olustur";
            this.Load += new System.EventHandler(this.frmVeriTabaniOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rICbHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIcbMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbMevcutVeriTabani)).EndInit();
            this.grbMevcutVeriTabani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVeriTabanlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cVeriTabaniOlusturBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbMevcutVeriTabani;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grdVeriTabanlari;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowHAIcýnYaratilacakVeriTabaniAdi;
        private DevExpress.XtraVerticalGrid.Rows.MultiEditorRow rowMKIcýnYaratilacakVeriTabaniAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rICbHA;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rIcbMK;
        private System.Windows.Forms.BindingSource cVeriTabaniOlusturBindingSource;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow cRHA;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow crMK;
    }
}