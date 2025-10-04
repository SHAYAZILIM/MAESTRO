namespace  AnaForm
{
    partial class frmOdemeTip
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
            this.panelOdemeTipleri = new DevExpress.XtraEditors.PanelControl();
            this.gridOdemeTipleri = new AdimAdimDavaKaydi.Util.ExtendedGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlExtender1 = new AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender();
            ((System.ComponentModel.ISupportInitialize)(this.panelOdemeTipleri)).BeginInit();
            this.panelOdemeTipleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeTipleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOdemeTipleri
            // 
            this.panelOdemeTipleri.Controls.Add(this.gridOdemeTipleri);
            this.panelOdemeTipleri.Controls.Add(this.panelControl1);
            this.panelOdemeTipleri.Controls.Add(this.panelControl2);
            this.panelOdemeTipleri.Location = new System.Drawing.Point(6, 12);
            this.panelOdemeTipleri.Name = "panelOdemeTipleri";
            this.panelOdemeTipleri.Size = new System.Drawing.Size(750, 360);
            this.panelOdemeTipleri.TabIndex = 19;
            // 
            // gridOdemeTipleri
            // 
            this.gridOdemeTipleri.CustomButtonlarGorunmesin = false;
            this.gridOdemeTipleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOdemeTipleri.DoNotExtendEmbedNavigator = false;
            this.gridOdemeTipleri.FilterText = null;
            this.gridOdemeTipleri.FilterValue = null;
            this.gridOdemeTipleri.GridlerDuzenlenebilir = true;
            this.gridOdemeTipleri.GridsFilterControl = null;
            this.gridOdemeTipleri.Location = new System.Drawing.Point(2, 72);
            this.gridOdemeTipleri.MainView = this.gridView1;
            this.gridOdemeTipleri.MyGridStyle = null;
            this.gridOdemeTipleri.Name = "gridOdemeTipleri";
            this.gridOdemeTipleri.ShowRowNumbers = false;
            this.gridOdemeTipleri.Size = new System.Drawing.Size(746, 286);
            this.gridOdemeTipleri.TabIndex = 5;
            this.gridOdemeTipleri.TemizleKaldirGorunsunmu = false;
            this.gridOdemeTipleri.UniqueId = "c2addb29-0c34-4ffc-8de6-c20dd7af7489";
            this.gridOdemeTipleri.UseEmbeddedNavigator = true;
            this.gridOdemeTipleri.UseHyperDragDrop = false;
            this.gridOdemeTipleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridOdemeTipleri;
            this.gridView1.GroupPanelText = "Verileri Gruplamak için Baþlýklarý Buraya Sürükleyin..";
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Ödeme Tipi Ekleyin ";
            this.gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 27);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ödeme Tipleri";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(746, 43);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::AdimAdimDavaKaydi.Properties.Resources.kaydet_22x22;
            this.simpleButton1.Location = new System.Drawing.Point(35, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControlExtender1
            // 
            this.gridControlExtender1.Form = this;
            this.gridControlExtender1.FormSize = new System.Drawing.Size(0, 0);
            this.gridControlExtender1.GridControl = this.gridOdemeTipleri;
            this.gridControlExtender1.GridLocation = new System.Drawing.Point(2, 72);
            this.gridControlExtender1.GridSize = new System.Drawing.Size(746, 286);
            this.gridControlExtender1.Location = new System.Drawing.Point(516, 392);
            this.gridControlExtender1.Name = "gridControlExtender1";
            this.gridControlExtender1.Size = new System.Drawing.Size(75, 23);
            this.gridControlExtender1.TabIndex = 20;
            this.gridControlExtender1.Text = "gridControlExtender1";
            this.gridControlExtender1.Visible = false;
            // 
            // frmOdemeTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 453);
            this.Controls.Add(this.gridControlExtender1);
            this.Controls.Add(this.panelOdemeTipleri);
            this.Name = "frmOdemeTip";
            this.Text = "Ödeme Tipleri";
            ((System.ComponentModel.ISupportInitialize)(this.panelOdemeTipleri)).EndInit();
            this.panelOdemeTipleri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOdemeTipleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelOdemeTipleri;
        private AdimAdimDavaKaydi.Util.ExtendedGridControl gridOdemeTipleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private AdimAdimDavaKaydi.IcraTakip.component.GridControlExtender gridControlExtender1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}