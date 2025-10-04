using AdimAdimDavaKaydi.Util;
namespace  AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge
{
    partial class ucSektor
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
            this.gridControl1 = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAYIT_TARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKONTROL_KIM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKONTROL_NE_ZAMAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKONTROL_VERSIYON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADMIN_KAYITMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTAMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DoNotExtendEmbedNavigator = false;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(651, 334);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseHyperDragDrop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAD,
            this.colACIKLAMA,
            this.colKAYIT_TARIHI,
            this.colKONTROL_KIM,
            this.colKONTROL_NE_ZAMAN,
            this.colKONTROL_VERSIYON,
            this.colADMIN_KAYITMI,
            this.colSTAMP,
            this.colIsSelected});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colAD
            // 
            this.colAD.Caption = "Ad";
            this.colAD.FieldName = "AD";
            this.colAD.Name = "colAD";
            this.colAD.Visible = true;
            this.colAD.VisibleIndex = 0;
            // 
            // colACIKLAMA
            // 
            this.colACIKLAMA.Caption = "Aciklama";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 1;
            // 
            // colKAYIT_TARIHI
            // 
            this.colKAYIT_TARIHI.Caption = "Kayýt Tarihi";
            this.colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            // 
            // colKONTROL_KIM
            // 
            this.colKONTROL_KIM.Caption = "Kontrol Kim";
            this.colKONTROL_KIM.FieldName = "KONTROL_KIM";
            this.colKONTROL_KIM.Name = "colKONTROL_KIM";
            // 
            // colKONTROL_NE_ZAMAN
            // 
            this.colKONTROL_NE_ZAMAN.Caption = "Kontrol Ne Zaman";
            this.colKONTROL_NE_ZAMAN.FieldName = "KONTROL_NE_ZAMAN";
            this.colKONTROL_NE_ZAMAN.Name = "colKONTROL_NE_ZAMAN";
            // 
            // colKONTROL_VERSIYON
            // 
            this.colKONTROL_VERSIYON.Caption = "Kontrol Versiyon";
            this.colKONTROL_VERSIYON.FieldName = "KONTROL_VERSIYON";
            this.colKONTROL_VERSIYON.Name = "colKONTROL_VERSIYON";
            // 
            // colADMIN_KAYITMI
            // 
            this.colADMIN_KAYITMI.Caption = "Admin Kayýtmý?";
            this.colADMIN_KAYITMI.FieldName = "ADMIN_KAYITMI";
            this.colADMIN_KAYITMI.Name = "colADMIN_KAYITMI";
            this.colADMIN_KAYITMI.Visible = true;
            this.colADMIN_KAYITMI.VisibleIndex = 2;
            this.colADMIN_KAYITMI.Width = 150;
            // 
            // colSTAMP
            // 
            this.colSTAMP.Caption = "STAMP";
            this.colSTAMP.FieldName = "STAMP";
            this.colSTAMP.Name = "colSTAMP";
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = "Seç";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(137, 341);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Sil";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(254, 340);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucSektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ucSektor";
            this.Size = new System.Drawing.Size(654, 374);
            this.Load += new System.EventHandler(this.ucSektor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAD;
        private DevExpress.XtraGrid.Columns.GridColumn colACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colKAYIT_TARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn colKONTROL_KIM;
        private DevExpress.XtraGrid.Columns.GridColumn colKONTROL_NE_ZAMAN;
        private DevExpress.XtraGrid.Columns.GridColumn colKONTROL_VERSIYON;
        private DevExpress.XtraGrid.Columns.GridColumn colADMIN_KAYITMI;
        private DevExpress.XtraGrid.Columns.GridColumn colSTAMP;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
