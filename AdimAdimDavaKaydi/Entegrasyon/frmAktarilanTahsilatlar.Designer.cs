namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmAktarilanTahsilatlar
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
            this.gcTahsilatlar = new DevExpress.XtraGrid.GridControl();
            this.cmsTahsilatlar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tahsilatEşleştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvTahsilatlar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTahsilatlar)).BeginInit();
            this.cmsTahsilatlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTahsilatlar)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTahsilatlar
            // 
            this.gcTahsilatlar.ContextMenuStrip = this.cmsTahsilatlar;
            this.gcTahsilatlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTahsilatlar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTahsilatlar.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcTahsilatlar.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTahsilatlar.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcTahsilatlar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTahsilatlar.EmbeddedNavigator.TextStringFormat = "Kayıt {0} / {1}";
            this.gcTahsilatlar.Location = new System.Drawing.Point(0, 0);
            this.gcTahsilatlar.MainView = this.gvTahsilatlar;
            this.gcTahsilatlar.Name = "gcTahsilatlar";
            this.gcTahsilatlar.Size = new System.Drawing.Size(664, 340);
            this.gcTahsilatlar.TabIndex = 1;
            this.gcTahsilatlar.UseEmbeddedNavigator = true;
            this.gcTahsilatlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTahsilatlar});
            // 
            // cmsTahsilatlar
            // 
            this.cmsTahsilatlar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tahsilatEşleştirToolStripMenuItem});
            this.cmsTahsilatlar.Name = "cmsTahsilatlar";
            this.cmsTahsilatlar.Size = new System.Drawing.Size(155, 26);
            // 
            // tahsilatEşleştirToolStripMenuItem
            // 
            this.tahsilatEşleştirToolStripMenuItem.Image = global::AdimAdimDavaKaydi.Properties.Resources.accept_22x222;
            this.tahsilatEşleştirToolStripMenuItem.Name = "tahsilatEşleştirToolStripMenuItem";
            this.tahsilatEşleştirToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.tahsilatEşleştirToolStripMenuItem.Text = "Tahsilat Eşleştir";
            this.tahsilatEşleştirToolStripMenuItem.Click += new System.EventHandler(this.tahsilatEşleştirToolStripMenuItem_Click);
            // 
            // gvTahsilatlar
            // 
            this.gvTahsilatlar.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.Empty.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gvTahsilatlar.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gvTahsilatlar.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvTahsilatlar.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.gvTahsilatlar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvTahsilatlar.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gvTahsilatlar.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gvTahsilatlar.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvTahsilatlar.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvTahsilatlar.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvTahsilatlar.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvTahsilatlar.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvTahsilatlar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvTahsilatlar.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.gvTahsilatlar.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gvTahsilatlar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gvTahsilatlar.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvTahsilatlar.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.OddRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvTahsilatlar.Appearance.OddRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gvTahsilatlar.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvTahsilatlar.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gvTahsilatlar.Appearance.Preview.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.Preview.Options.UseFont = true;
            this.gvTahsilatlar.Appearance.Preview.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.Row.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.Row.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvTahsilatlar.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.gvTahsilatlar.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvTahsilatlar.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvTahsilatlar.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvTahsilatlar.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gvTahsilatlar.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvTahsilatlar.Appearance.VertLine.Options.UseBackColor = true;
            this.gvTahsilatlar.Appearance.VertLine.Options.UseBorderColor = true;
            this.gvTahsilatlar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvTahsilatlar.GridControl = this.gcTahsilatlar;
            this.gvTahsilatlar.GroupCount = 2;
            this.gvTahsilatlar.Name = "gvTahsilatlar";
            this.gvTahsilatlar.OptionsView.ColumnAutoWidth = false;
            this.gvTahsilatlar.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTahsilatlar.OptionsView.EnableAppearanceOddRow = true;
            this.gvTahsilatlar.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Şube";
            this.gridColumn1.FieldName = "SUBE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kredi Müşterisi";
            this.gridColumn2.FieldName = "KREDI_MUSTERISI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Müşteri No";
            this.gridColumn3.FieldName = "MUSTERI_NO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Hesap No";
            this.gridColumn4.FieldName = "HESAP_NO";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IBAN No";
            this.gridColumn5.FieldName = "IBAN_NO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ödeyen";
            this.gridColumn6.FieldName = "ODEYEN";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ödeme Miktarı";
            this.gridColumn7.FieldName = "ODEME_MIKTARI";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = " ";
            this.gridColumn8.FieldName = "ODEME_MIKTARI_PARA_BIRIMI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ödeme Tarihi";
            this.gridColumn9.FieldName = "ODEME_TARIHI";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Kredi Referans No";
            this.gridColumn10.FieldName = "KREDI_REFERANS_NO";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            // 
            // frmAktarilanTahsilatlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 340);
            this.Controls.Add(this.gcTahsilatlar);
            this.Name = "frmAktarilanTahsilatlar";
            this.Text = "AKTARILAN TAHSİLATLAR EKRANI";
            this.Load += new System.EventHandler(this.frmAktarilanTahsilatlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTahsilatlar)).EndInit();
            this.cmsTahsilatlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTahsilatlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTahsilatlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTahsilatlar;
        private System.Windows.Forms.ContextMenuStrip cmsTahsilatlar;
        private System.Windows.Forms.ToolStripMenuItem tahsilatEşleştirToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}