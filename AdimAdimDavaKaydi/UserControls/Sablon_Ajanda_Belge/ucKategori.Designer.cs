namespace  AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    partial class ucKategori
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
            this.gridSablonKategori = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gwSablonKategori = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSablonKategori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSablonKategori)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSablonKategori
            // 
            this.gridSablonKategori.EmbeddedNavigator.Name = "";
            this.gridSablonKategori.Location = new System.Drawing.Point(3, 3);
            this.gridSablonKategori.MainView = this.gwSablonKategori;
            this.gridSablonKategori.Name = "gridSablonKategori";
            this.gridSablonKategori.Size = new System.Drawing.Size(728, 443);
            this.gridSablonKategori.TabIndex = 0;
            this.gridSablonKategori.UseEmbeddedNavigator = true;
            this.gridSablonKategori.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gwSablonKategori});
            // 
            // gwSablonKategori
            // 
            this.gwSablonKategori.GridControl = this.gridSablonKategori;
            this.gwSablonKategori.Name = "gwSablonKategori";
            this.gwSablonKategori.OptionsBehavior.FocusLeaveOnTab = true;
            this.gwSablonKategori.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gwSablonKategori.OptionsNavigation.AutoFocusNewRow = true;
            this.gwSablonKategori.OptionsNavigation.EnterMoveNextColumn = true;
            this.gwSablonKategori.OptionsView.ColumnAutoWidth = false;
            this.gwSablonKategori.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gwSablonKategori.OptionsView.ShowAutoFilterRow = true;
            this.gwSablonKategori.OptionsView.ShowChildrenInGroupPanel = true;
            this.gwSablonKategori.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(527, 453);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(344, 453);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Sil";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridSablonKategori);
            this.Name = "ucKategori";
            this.Size = new System.Drawing.Size(734, 477);
            this.Load += new System.EventHandler(this.ucKategori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSablonKategori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gwSablonKategori)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridSablonKategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gwSablonKategori;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
