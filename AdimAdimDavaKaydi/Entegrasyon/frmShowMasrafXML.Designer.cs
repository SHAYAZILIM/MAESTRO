namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmShowMasrafXML
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
            this.gcMasraflar = new DevExpress.XtraGrid.GridControl();
            this.cmsMasraf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.masrafEşleştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvMasraflar = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcMasraflar)).BeginInit();
            this.cmsMasraf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMasraflar)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMasraflar
            // 
            this.gcMasraflar.ContextMenuStrip = this.cmsMasraf;
            this.gcMasraflar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMasraflar.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcMasraflar.EmbeddedNavigator.TextStringFormat = "Kayıt {0} / {1}";
            this.gcMasraflar.Location = new System.Drawing.Point(0, 0);
            this.gcMasraflar.MainView = this.gvMasraflar;
            this.gcMasraflar.Name = "gcMasraflar";
            this.gcMasraflar.Size = new System.Drawing.Size(621, 317);
            this.gcMasraflar.TabIndex = 0;
            this.gcMasraflar.UseEmbeddedNavigator = true;
            this.gcMasraflar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMasraflar});
            // 
            // cmsMasraf
            // 
            this.cmsMasraf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masrafEşleştirToolStripMenuItem});
            this.cmsMasraf.Name = "contextMenuStrip1";
            this.cmsMasraf.Size = new System.Drawing.Size(153, 48);
            // 
            // masrafEşleştirToolStripMenuItem
            // 
            this.masrafEşleştirToolStripMenuItem.Image = global::AdimAdimDavaKaydi.Properties.Resources.accept_22x222;
            this.masrafEşleştirToolStripMenuItem.Name = "masrafEşleştirToolStripMenuItem";
            this.masrafEşleştirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masrafEşleştirToolStripMenuItem.Text = "Masraf Eşleştir";
            this.masrafEşleştirToolStripMenuItem.Click += new System.EventHandler(this.masrafEşleştirToolStripMenuItem_Click);
            // 
            // gvMasraflar
            // 
            this.gvMasraflar.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.Empty.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gvMasraflar.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gvMasraflar.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvMasraflar.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.gvMasraflar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gvMasraflar.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gvMasraflar.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gvMasraflar.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvMasraflar.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvMasraflar.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvMasraflar.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gvMasraflar.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvMasraflar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gvMasraflar.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.gvMasraflar.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gvMasraflar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gvMasraflar.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvMasraflar.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.OddRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.OddRow.Options.UseBorderColor = true;
            this.gvMasraflar.Appearance.OddRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gvMasraflar.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gvMasraflar.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gvMasraflar.Appearance.Preview.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.Preview.Options.UseFont = true;
            this.gvMasraflar.Appearance.Preview.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.Row.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.Row.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gvMasraflar.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.gvMasraflar.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvMasraflar.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvMasraflar.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gvMasraflar.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gvMasraflar.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gvMasraflar.Appearance.VertLine.Options.UseBackColor = true;
            this.gvMasraflar.Appearance.VertLine.Options.UseBorderColor = true;
            this.gvMasraflar.GridControl = this.gcMasraflar;
            this.gvMasraflar.Name = "gvMasraflar";
            this.gvMasraflar.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMasraflar.OptionsView.EnableAppearanceOddRow = true;
            // 
            // frmShowMasrafXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 317);
            this.Controls.Add(this.gcMasraflar);
            this.Name = "frmShowMasrafXML";
            this.Text = "Masraflar";
            ((System.ComponentModel.ISupportInitialize)(this.gcMasraflar)).EndInit();
            this.cmsMasraf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMasraflar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMasraflar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMasraflar;
        private System.Windows.Forms.ContextMenuStrip cmsMasraf;
        private System.Windows.Forms.ToolStripMenuItem masrafEşleştirToolStripMenuItem;
    }
}