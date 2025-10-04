namespace  AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    partial class ucDil
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
            this.gridDil = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwDil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDil)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDil
            // 
            this.gridDil.EmbeddedNavigator.Name = "";
            this.gridDil.Location = new System.Drawing.Point(3, 3);
            this.gridDil.MainView = this.gwDil;
            this.gridDil.Name = "gridDil";
            this.gridDil.Size = new System.Drawing.Size(700, 449);
            this.gridDil.TabIndex = 0;
            this.gridDil.UseEmbeddedNavigator = true;
            this.gridDil.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwDil});
            // 
            // gwDil
            // 
            this.gwDil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDIL,
            this.colKAYIT_TARIHI});
            this.gwDil.GridControl = this.gridDil;
            this.gwDil.Name = "gwDil";
            this.gwDil.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwDil.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwDil.OptionsNavigation.AutoFocusNewRow = true;
            this.gwDil.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwDil.OptionsView.ColumnAutoWidth = false;
            this.gwDil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwDil.OptionsView.ShowAutoFilterRow = true;
            this.gwDil.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwDil.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // colDIL
            // 
            this.colDIL.Caption = "Dil";
            this.colDIL.FieldName = "DIL";
            this.colDIL.Name = "colDIL";
            this.colDIL.Visible = true;
            this.colDIL.VisibleIndex = 0;
            // 
            // colKAYIT_TARIHI
            // 
            this.colKAYIT_TARIHI.Caption = "Kayýt T.";
            this.colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            this.colKAYIT_TARIHI.Visible = true;
            this.colKAYIT_TARIHI.VisibleIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(511, 459);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(101, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Giriþleri Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(334, 458);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Giriþleri Sil";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucDil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridDil);
            this.Name = "ucDil";
            this.Size = new System.Drawing.Size(706, 488);
            this.Load += new System.EventHandler(this.ucDil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwDil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridDil;
        private DevExpress.XtraGrid.Views.Grid.GridView gwDil;
        private DevExpress.XtraGrid.Columns.GridColumn colDIL;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYIT_TARIHI;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
