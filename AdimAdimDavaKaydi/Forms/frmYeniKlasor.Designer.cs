namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmYeniKlasor
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkSorumlu = new DevExpress.XtraEditors.LookUpEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.lkOzelKod1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSubesi = new DevExpress.XtraEditors.LabelControl();
            this.txtRafNo = new DevExpress.XtraEditors.TextEdit();
            this.cmbKlasorAdi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.bwCariDoldur = new System.ComponentModel.BackgroundWorker();
            this.lblIzleyenAvukat = new DevExpress.XtraEditors.LabelControl();
            this.lkIzleyenCari = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lkProjeTip = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkSorumlu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkOzelKod1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRafNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKlasorAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkIzleyenCari.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkProjeTip.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(269, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Yeni bir klasör oluþturmak için lütfen gerekli bilgileri giriniz";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Klasör Adý (Kredi Borçlusu):";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Klasör No:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Sorumlu :";
            // 
            // lkSorumlu
            // 
            this.lkSorumlu.Location = new System.Drawing.Point(3, 107);
            this.lkSorumlu.Name = "lkSorumlu";
            this.lkSorumlu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSorumlu.Properties.NullText = "Seç";
            this.lkSorumlu.Size = new System.Drawing.Size(488, 20);
            this.lkSorumlu.TabIndex = 3;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(334, 202);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 24);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(416, 202);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 24);
            this.btnIptal.TabIndex = 7;
            this.btnIptal.Text = "Ýptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // lkOzelKod1
            // 
            this.lkOzelKod1.Location = new System.Drawing.Point(91, 73);
            this.lkOzelKod1.Name = "lkOzelKod1";
            this.lkOzelKod1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "mEkle", null, true)});
            this.lkOzelKod1.Properties.NullText = "Seç";
            this.lkOzelKod1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkOzelKod1.Size = new System.Drawing.Size(400, 20);
            this.lkOzelKod1.TabIndex = 2;
            this.lkOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkOzelKod1_ButtonClick);
            // 
            // lblSubesi
            // 
            this.lblSubesi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSubesi.Appearance.Options.UseFont = true;
            this.lblSubesi.Location = new System.Drawing.Point(91, 59);
            this.lblSubesi.Name = "lblSubesi";
            this.lblSubesi.Size = new System.Drawing.Size(38, 13);
            this.lblSubesi.TabIndex = 5;
            this.lblSubesi.Text = "Þubesi :";
            // 
            // txtRafNo
            // 
            this.txtRafNo.EditValue = "";
            this.txtRafNo.Location = new System.Drawing.Point(3, 73);
            this.txtRafNo.Name = "txtRafNo";
            this.txtRafNo.Properties.Mask.EditMask = "\\d\\d\\d\\d \\/ \\d\\d\\d\\d";
            this.txtRafNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtRafNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRafNo.Properties.ReadOnly = true;
            this.txtRafNo.Size = new System.Drawing.Size(82, 20);
            this.txtRafNo.TabIndex = 1;
            // 
            // cmbKlasorAdi
            // 
            this.cmbKlasorAdi.Location = new System.Drawing.Point(3, 39);
            this.cmbKlasorAdi.Name = "cmbKlasorAdi";
            this.cmbKlasorAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, false)});
            this.cmbKlasorAdi.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbKlasorAdi.Size = new System.Drawing.Size(488, 20);
            this.cmbKlasorAdi.TabIndex = 0;
            this.cmbKlasorAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cmbKlasorAdi_ButtonClick);
            // 
            // bwCariDoldur
            // 
            this.bwCariDoldur.WorkerReportsProgress = true;
            this.bwCariDoldur.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCariDoldur_DoWork);
            this.bwCariDoldur.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCariDoldur_ProgressChanged);
            // 
            // lblIzleyenAvukat
            // 
            this.lblIzleyenAvukat.Location = new System.Drawing.Point(5, 129);
            this.lblIzleyenAvukat.Name = "lblIzleyenAvukat";
            this.lblIzleyenAvukat.Size = new System.Drawing.Size(42, 13);
            this.lblIzleyenAvukat.TabIndex = 3;
            this.lblIzleyenAvukat.Text = "Ýzleyen :";
            // 
            // lkIzleyenCari
            // 
            this.lkIzleyenCari.Location = new System.Drawing.Point(3, 142);
            this.lkIzleyenCari.Name = "lkIzleyenCari";
            this.lkIzleyenCari.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkIzleyenCari.Properties.NullText = "Seç";
            this.lkIzleyenCari.Size = new System.Drawing.Size(488, 20);
            this.lkIzleyenCari.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 163);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Bölüm :";
            // 
            // lkProjeTip
            // 
            this.lkProjeTip.Location = new System.Drawing.Point(3, 176);
            this.lkProjeTip.Name = "lkProjeTip";
            this.lkProjeTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkProjeTip.Properties.NullText = "Seç";
            this.lkProjeTip.Size = new System.Drawing.Size(488, 20);
            this.lkProjeTip.TabIndex = 5;
            // 
            // frmYeniKlasor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(503, 233);
            this.Controls.Add(this.cmbKlasorAdi);
            this.Controls.Add(this.lkOzelKod1);
            this.Controls.Add(this.lblSubesi);
            this.Controls.Add(this.txtRafNo);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lkProjeTip);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lkIzleyenCari);
            this.Controls.Add(this.lblIzleyenAvukat);
            this.Controls.Add(this.lkSorumlu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmYeniKlasor";
            this.Text = "Yeni Klasör";
            this.Load += new System.EventHandler(this.frmYeniKlasor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkSorumlu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkOzelKod1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRafNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKlasorAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkIzleyenCari.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkProjeTip.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkSorumlu;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.LookUpEdit lkOzelKod1;
        private DevExpress.XtraEditors.LabelControl lblSubesi;
        private DevExpress.XtraEditors.TextEdit txtRafNo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbKlasorAdi;
        private System.ComponentModel.BackgroundWorker bwCariDoldur;
        private DevExpress.XtraEditors.LabelControl lblIzleyenAvukat;
        private DevExpress.XtraEditors.LookUpEdit lkIzleyenCari;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lkProjeTip;
    }
}