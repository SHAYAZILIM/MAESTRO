namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucTabArama
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rlueColorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueColorEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Standard;
            this.treeList1.Location = new System.Drawing.Point(0, 45);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsSelection.MultiSelect = true;
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlueColorEdit});
            this.treeList1.Size = new System.Drawing.Size(263, 286);
            this.treeList1.TabIndex = 4;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Gizli mi?";
            this.treeListColumn3.CustomizationCaption = "Görünsün";
            this.treeListColumn3.FieldName = "PageVisible";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 49;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Başlık";
            this.treeListColumn1.FieldName = "Text";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 154;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Renk";
            this.treeListColumn2.ColumnEdit = this.rlueColorEdit;
            this.treeListColumn2.FieldName = "TabKulakRenk";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 39;
            // 
            // rlueColorEdit
            // 
            this.rlueColorEdit.AutoHeight = false;
            this.rlueColorEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueColorEdit.Name = "rlueColorEdit";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(263, 45);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Başlık Girin";
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit1.Location = new System.Drawing.Point(2, 22);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(259, 20);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 310);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(263, 21);
            this.panelControl1.TabIndex = 5;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkEdit1.Location = new System.Drawing.Point(2, 2);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Renklendirme Kullan";
            this.checkEdit1.Size = new System.Drawing.Size(259, 19);
            this.checkEdit1.TabIndex = 0;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // ucTabArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucTabArama";
            this.Size = new System.Drawing.Size(263, 331);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueColorEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit rlueColorEdit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}
