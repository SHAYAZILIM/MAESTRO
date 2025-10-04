namespace AdimAdimDavaKaydi.Util
{
    partial class frmKayitSil
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.bndFormKontrol = new System.Windows.Forms.BindingSource(this.components);
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.ıliskiNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colGorunen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.lblSifre = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bndFormKontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıliskiNodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Listedeki bağlantılı kayıtlarla beraber silinecek";
            // 
            // btnTamam
            // 
            this.btnTamam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTamam.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTamam.Appearance.Options.UseForeColor = true;
            this.btnTamam.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bndFormKontrol, "BtnTamamEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnTamam.Enabled = false;
            this.btnTamam.Location = new System.Drawing.Point(191, 340);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 2;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // bndFormKontrol
            // 
            this.bndFormKontrol.DataSource = typeof(AdimAdimDavaKaydi.Util.frmKayitSil.FormKontrol);
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(272, 340);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // ıliskiNodeBindingSource
            // 
            this.ıliskiNodeBindingSource.DataSource = typeof(AdimAdimDavaKaydi.Util.frmKayitSil.IliskiNode);
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGorunen});
            this.treeList1.DataSource = this.ıliskiNodeBindingSource;
            this.treeList1.KeyFieldName = "Name";
            this.treeList1.Location = new System.Drawing.Point(12, 12);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "ParentName";
            this.treeList1.Size = new System.Drawing.Size(335, 302);
            this.treeList1.TabIndex = 4;
            // 
            // colGorunen
            // 
            this.colGorunen.Caption = "İlişkili Kayıtlar";
            this.colGorunen.FieldName = "Gorunen";
            this.colGorunen.Name = "colGorunen";
            this.colGorunen.OptionsColumn.ReadOnly = true;
            this.colGorunen.Visible = true;
            this.colGorunen.VisibleIndex = 0;
            this.colGorunen.Width = 104;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndFormKontrol, "BtnTamamEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkEdit1.Location = new System.Drawing.Point(120, 342);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Onayla";
            this.checkEdit1.Size = new System.Drawing.Size(65, 19);
            this.checkEdit1.TabIndex = 5;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(85, 342);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 6;
            this.txtSifre.EditValueChanged += new System.EventHandler(this.txtSifre_EditValueChanged);
            // 
            // lblSifre
            // 
            this.lblSifre.Location = new System.Drawing.Point(28, 345);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(53, 13);
            this.lblSifre.TabIndex = 7;
            this.lblSifre.Text = "Şifre Girin :";
            // 
            // frmKayitSil
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(359, 375);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKayitSil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kayıt Silme Kontrolü";
            this.Load += new System.EventHandler(this.FrmKayitSil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bndFormKontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıliskiNodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private System.Windows.Forms.BindingSource ıliskiNodeBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGorunen;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.BindingSource bndFormKontrol;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.LabelControl lblSifre;
    }
}