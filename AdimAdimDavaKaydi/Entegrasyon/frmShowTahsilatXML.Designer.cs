namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmShowTahsilatXML
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
            this.gcTahsilatlar.Size = new System.Drawing.Size(549, 332);
            this.gcTahsilatlar.TabIndex = 0;
            this.gcTahsilatlar.UseEmbeddedNavigator = true;
            this.gcTahsilatlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTahsilatlar});
            // 
            // cmsTahsilatlar
            // 
            this.cmsTahsilatlar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tahsilatEşleştirToolStripMenuItem});
            this.cmsTahsilatlar.Name = "cmsTahsilatlar";
            this.cmsTahsilatlar.Size = new System.Drawing.Size(155, 48);
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
            this.gvTahsilatlar.GridControl = this.gcTahsilatlar;
            this.gvTahsilatlar.Name = "gvTahsilatlar";
            this.gvTahsilatlar.OptionsView.EnableAppearanceEvenRow = true;
            this.gvTahsilatlar.OptionsView.EnableAppearanceOddRow = true;
            // 
            // frmShowTahsilatXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 332);
            this.Controls.Add(this.gcTahsilatlar);
            this.Name = "frmShowTahsilatXML";
            this.Text = "Tahsilatlar";
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
    }
}