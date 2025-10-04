namespace  ImportExportWithSelection.Import
{
    partial class frmMaskeler
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
            this.lueDeger = new DevExpress.XtraEditors.LookUpEdit();
            this.bndMask = new System.Windows.Forms.BindingSource(this.components);
            this.lueMaskeTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.lueMaske = new DevExpress.XtraEditors.LookUpEdit();
            this.lueTablo = new DevExpress.XtraEditors.LookUpEdit();
            this.lueKolon = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pnlKolonTablo = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pnlMaske = new DevExpress.XtraEditors.PanelControl();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnKayitSayisi = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.lueDeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaskeTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaske.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTablo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKolon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKolonTablo)).BeginInit();
            this.pnlKolonTablo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMaske)).BeginInit();
            this.pnlMaske.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDeger
            // 
            this.lueDeger.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndMask, "Value", true));
            this.lueDeger.Location = new System.Drawing.Point(231, 12);
            this.lueDeger.Name = "lueDeger";
            this.lueDeger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDeger.Properties.DisplayMember = "Text";
            this.lueDeger.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueDeger.Properties.ValueMember = "Value";
            this.lueDeger.Size = new System.Drawing.Size(270, 20);
            this.lueDeger.TabIndex = 0;
            // 
            // lueMaskeTipi
            // 
            this.lueMaskeTipi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndMask, "MaskType", true));
            this.lueMaskeTipi.Location = new System.Drawing.Point(231, 38);
            this.lueMaskeTipi.Name = "lueMaskeTipi";
            this.lueMaskeTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaskeTipi.Properties.DisplayMember = "Text";
            this.lueMaskeTipi.Properties.ValueMember = "Value";
            this.lueMaskeTipi.Size = new System.Drawing.Size(270, 20);
            this.lueMaskeTipi.TabIndex = 0;
            this.lueMaskeTipi.EditValueChanged += new System.EventHandler(this.lueMaskeTipi_EditValueChanged);
            // 
            // lueMaske
            // 
            this.lueMaske.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndMask, "Mask", true));
            this.lueMaske.Location = new System.Drawing.Point(219, 5);
            this.lueMaske.Name = "lueMaske";
            this.lueMaske.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaske.Size = new System.Drawing.Size(270, 20);
            this.lueMaske.TabIndex = 0;
            // 
            // lueTablo
            // 
            this.lueTablo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndMask, "Tablo", true));
            this.lueTablo.Location = new System.Drawing.Point(219, 5);
            this.lueTablo.Name = "lueTablo";
            this.lueTablo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTablo.Size = new System.Drawing.Size(270, 20);
            this.lueTablo.TabIndex = 0;
            // 
            // lueKolon
            // 
            this.lueKolon.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndMask, "Kolon", true));
            this.lueKolon.Location = new System.Drawing.Point(219, 31);
            this.lueKolon.Name = "lueKolon";
            this.lueKolon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKolon.Size = new System.Drawing.Size(270, 20);
            this.lueKolon.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(66, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Deðer";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(66, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "MaskeTipi";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(54, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Maske";
            // 
            // pnlKolonTablo
            // 
            this.pnlKolonTablo.Controls.Add(this.lueTablo);
            this.pnlKolonTablo.Controls.Add(this.labelControl5);
            this.pnlKolonTablo.Controls.Add(this.lueKolon);
            this.pnlKolonTablo.Controls.Add(this.labelControl4);
            this.pnlKolonTablo.Location = new System.Drawing.Point(12, 64);
            this.pnlKolonTablo.Name = "pnlKolonTablo";
            this.pnlKolonTablo.Size = new System.Drawing.Size(517, 56);
            this.pnlKolonTablo.TabIndex = 2;
            this.pnlKolonTablo.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(26, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Kolon";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(54, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Tablo";
            // 
            // pnlMaske
            // 
            this.pnlMaske.Controls.Add(this.lueMaske);
            this.pnlMaske.Controls.Add(this.labelControl3);
            this.pnlMaske.Location = new System.Drawing.Point(12, 63);
            this.pnlMaske.Name = "pnlMaske";
            this.pnlMaske.Size = new System.Drawing.Size(517, 27);
            this.pnlMaske.TabIndex = 3;
            this.pnlMaske.Visible = false;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(191, 126);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(26, 23);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "<<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnKayitSayisi
            // 
            this.btnKayitSayisi.Location = new System.Drawing.Point(223, 126);
            this.btnKayitSayisi.Name = "btnKayitSayisi";
            this.btnKayitSayisi.Size = new System.Drawing.Size(64, 23);
            this.btnKayitSayisi.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(293, 126);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">>";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(368, 126);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(32, 23);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "S";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(406, 126);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(32, 23);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "K";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.Location = new System.Drawing.Point(330, 126);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(32, 23);
            this.btnYeni.TabIndex = 5;
            this.btnYeni.Text = "Y";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 155);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(530, 189);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frmMaskeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 356);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnKayitSayisi);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pnlMaske);
            this.Controls.Add(this.pnlKolonTablo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lueMaskeTipi);
            this.Controls.Add(this.lueDeger);
            this.Name = "frmMaskeler";
            this.Load += new System.EventHandler(this.frmMaskeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaskeTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaske.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTablo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKolon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlKolonTablo)).EndInit();
            this.pnlKolonTablo.ResumeLayout(false);
            this.pnlKolonTablo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMaske)).EndInit();
            this.pnlMaske.ResumeLayout(false);
            this.pnlMaske.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lueDeger;
        private DevExpress.XtraEditors.LookUpEdit lueMaskeTipi;
        private DevExpress.XtraEditors.LookUpEdit lueMaske;
        private DevExpress.XtraEditors.LookUpEdit lueTablo;
        private DevExpress.XtraEditors.LookUpEdit lueKolon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl pnlKolonTablo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl pnlMaske;
        private System.Windows.Forms.BindingSource bndMask;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnKayitSayisi;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}