namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmMusteriSec
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
            this.groupCariList = new DevExpress.XtraEditors.GroupControl();
            this.gcCariList = new DevExpress.XtraGrid.GridControl();
            this.gvCariList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSec = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colMusteri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBabaAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDogumTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIlce = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVergiNo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupCariList)).BeginInit();
            this.groupCariList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCariList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCariList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSec)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCariList
            // 
            this.groupCariList.Controls.Add(this.gcCariList);
            this.groupCariList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCariList.Location = new System.Drawing.Point(0, 0);
            this.groupCariList.Name = "groupCariList";
            this.groupCariList.Size = new System.Drawing.Size(574, 335);
            this.groupCariList.TabIndex = 3;
            this.groupCariList.Text = "İşlem Yapmak İstediğiniz MÜŞTERİYİ Seçiniz.";
            // 
            // gcCariList
            // 
            this.gcCariList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCariList.Location = new System.Drawing.Point(2, 22);
            this.gcCariList.MainView = this.gvCariList;
            this.gcCariList.Name = "gcCariList";
            this.gcCariList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnSec});
            this.gcCariList.Size = new System.Drawing.Size(570, 311);
            this.gcCariList.TabIndex = 0;
            this.gcCariList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCariList});
            // 
            // gvCariList
            // 
            this.gvCariList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvCariList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvCariList.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvCariList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSec,
            this.colMusteri,
            this.colTCKimlikNo,
            this.colBabaAdi,
            this.colDogumTarihi,
            this.colAdres,
            this.colIlce,
            this.colIl,
            this.colVergiNo});
            this.gvCariList.GridControl = this.gcCariList;
            this.gvCariList.Name = "gvCariList";
            this.gvCariList.OptionsView.ColumnAutoWidth = false;
            this.gvCariList.OptionsView.ShowGroupPanel = false;
            // 
            // colSec
            // 
            this.colSec.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSec.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.colSec.AppearanceHeader.Options.UseFont = true;
            this.colSec.AppearanceHeader.Options.UseForeColor = true;
            this.colSec.Caption = "SEÇ";
            this.colSec.ColumnEdit = this.btnSec;
            this.colSec.Name = "colSec";
            this.colSec.Visible = true;
            this.colSec.VisibleIndex = 0;
            this.colSec.Width = 68;
            // 
            // btnSec
            // 
            this.btnSec.AutoHeight = false;
            this.btnSec.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSec.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.btnSec.Name = "btnSec";
            this.btnSec.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // colMusteri
            // 
            this.colMusteri.Caption = "Müşteri";
            this.colMusteri.FieldName = "AD";
            this.colMusteri.Name = "colMusteri";
            this.colMusteri.Visible = true;
            this.colMusteri.VisibleIndex = 1;
            this.colMusteri.Width = 68;
            // 
            // colTCKimlikNo
            // 
            this.colTCKimlikNo.Caption = "TC Kimlik No";
            this.colTCKimlikNo.FieldName = "TC_KIMLIK_NO";
            this.colTCKimlikNo.Name = "colTCKimlikNo";
            this.colTCKimlikNo.Visible = true;
            this.colTCKimlikNo.VisibleIndex = 2;
            this.colTCKimlikNo.Width = 68;
            // 
            // colBabaAdi
            // 
            this.colBabaAdi.Caption = "Baba Adı";
            this.colBabaAdi.FieldName = "BABA_ADI";
            this.colBabaAdi.Name = "colBabaAdi";
            this.colBabaAdi.Visible = true;
            this.colBabaAdi.VisibleIndex = 3;
            this.colBabaAdi.Width = 68;
            // 
            // colDogumTarihi
            // 
            this.colDogumTarihi.Caption = "Doğum Tarihi";
            this.colDogumTarihi.FieldName = "DOGUM_TARIHI";
            this.colDogumTarihi.Name = "colDogumTarihi";
            this.colDogumTarihi.Visible = true;
            this.colDogumTarihi.VisibleIndex = 4;
            this.colDogumTarihi.Width = 84;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "ADRES_1";
            this.colAdres.Name = "colAdres";
            this.colAdres.Visible = true;
            this.colAdres.VisibleIndex = 5;
            this.colAdres.Width = 119;
            // 
            // colIlce
            // 
            this.colIlce.Caption = "İlçe";
            this.colIlce.FieldName = "ILCE";
            this.colIlce.Name = "colIlce";
            this.colIlce.Visible = true;
            this.colIlce.VisibleIndex = 6;
            this.colIlce.Width = 34;
            // 
            // colIl
            // 
            this.colIl.Caption = "İl";
            this.colIl.FieldName = "IL";
            this.colIl.Name = "colIl";
            this.colIl.Visible = true;
            this.colIl.VisibleIndex = 7;
            this.colIl.Width = 40;
            // 
            // colVergiNo
            // 
            this.colVergiNo.Caption = "Vergi No";
            this.colVergiNo.FieldName = "VERGI_NO";
            this.colVergiNo.Name = "colVergiNo";
            // 
            // frmMusteriSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 335);
            this.Controls.Add(this.groupCariList);
            this.Name = "frmMusteriSec";
            this.Text = "Müşteri Seçme Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.groupCariList)).EndInit();
            this.groupCariList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCariList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCariList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupCariList;
        private DevExpress.XtraGrid.GridControl gcCariList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCariList;
        private DevExpress.XtraGrid.Columns.GridColumn colSec;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteri;
        private DevExpress.XtraGrid.Columns.GridColumn colTCKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colBabaAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colDogumTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colAdres;
        private DevExpress.XtraGrid.Columns.GridColumn colIlce;
        private DevExpress.XtraGrid.Columns.GridColumn colIl;
        private DevExpress.XtraGrid.Columns.GridColumn colVergiNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSec;
    }
}