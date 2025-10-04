namespace  IdentityUpdate
{
    partial class Form1
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lkEditTable = new DevExpress.XtraEditors.LookUpEdit();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.chkOldIdSave = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkEditTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOldIdSave.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 40);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(927, 393);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // lkEditTable
            // 
            this.lkEditTable.Location = new System.Drawing.Point(3, 12);
            this.lkEditTable.Name = "lkEditTable";
            this.lkEditTable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkEditTable.Size = new System.Drawing.Size(247, 20);
            this.lkEditTable.TabIndex = 2;
            this.lkEditTable.EditValueChanged += new System.EventHandler(this.lkEditTable_EditValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 440);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(130, 441);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Tümü";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(225, 441);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeselectAll.TabIndex = 6;
            this.btnDeselectAll.Text = "Hibiri";
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // chkOldIdSave
            // 
            this.chkOldIdSave.EditValue = true;
            this.chkOldIdSave.Location = new System.Drawing.Point(278, 13);
            this.chkOldIdSave.Name = "chkOldIdSave";
            this.chkOldIdSave.Properties.Caption = "ID\'leri kaydet";
            this.chkOldIdSave.Size = new System.Drawing.Size(88, 19);
            this.chkOldIdSave.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 477);
            this.Controls.Add(this.chkOldIdSave);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lkEditTable);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "<";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkEditTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOldIdSave.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lkEditTable;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnDeselectAll;
        private DevExpress.XtraEditors.CheckEdit chkOldIdSave;
    }
}

