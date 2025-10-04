namespace AdimAdimDavaKaydi.Forms
{
    partial class frmTebligatKonu
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
            this.gbTebligatKonu = new DevExpress.XtraEditors.GroupControl();
            this.sbtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lueAdliBirimBolum = new DevExpress.XtraEditors.LookUpEdit();
            this.lueAltTur = new DevExpress.XtraEditors.LookUpEdit();
            this.lueAnaTur = new DevExpress.XtraEditors.LookUpEdit();
            this.txtKonu = new DevExpress.XtraEditors.TextEdit();
            this.lblBolum = new DevExpress.XtraEditors.LabelControl();
            this.lblAltTur = new DevExpress.XtraEditors.LabelControl();
            this.lblAnaTur = new DevExpress.XtraEditors.LabelControl();
            this.lblKonu = new DevExpress.XtraEditors.LabelControl();
            this.bndKonu = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbTebligatKonu)).BeginInit();
            this.gbTebligatKonu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliBirimBolum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAltTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnaTur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKonu)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTebligatKonu
            // 
            this.gbTebligatKonu.Controls.Add(this.sbtnKaydet);
            this.gbTebligatKonu.Controls.Add(this.lueAdliBirimBolum);
            this.gbTebligatKonu.Controls.Add(this.lueAltTur);
            this.gbTebligatKonu.Controls.Add(this.lueAnaTur);
            this.gbTebligatKonu.Controls.Add(this.txtKonu);
            this.gbTebligatKonu.Controls.Add(this.lblBolum);
            this.gbTebligatKonu.Controls.Add(this.lblAltTur);
            this.gbTebligatKonu.Controls.Add(this.lblAnaTur);
            this.gbTebligatKonu.Controls.Add(this.lblKonu);
            this.gbTebligatKonu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTebligatKonu.Location = new System.Drawing.Point(0, 0);
            this.gbTebligatKonu.Name = "gbTebligatKonu";
            this.gbTebligatKonu.Size = new System.Drawing.Size(357, 188);
            this.gbTebligatKonu.TabIndex = 1;
            this.gbTebligatKonu.Text = "Yeni Tebligat Konu";
            // 
            // sbtnKaydet
            // 
            this.sbtnKaydet.Location = new System.Drawing.Point(262, 150);
            this.sbtnKaydet.Name = "sbtnKaydet";
            this.sbtnKaydet.Size = new System.Drawing.Size(75, 23);
            this.sbtnKaydet.TabIndex = 8;
            this.sbtnKaydet.Text = "KAYDET";
            this.sbtnKaydet.Click += new System.EventHandler(this.sbtnKaydet_Click);
            // 
            // lueAdliBirimBolum
            // 
            this.lueAdliBirimBolum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndKonu, "ADLI_BIRIM_BOLUM_ID", true));
            this.lueAdliBirimBolum.Location = new System.Drawing.Point(141, 111);
            this.lueAdliBirimBolum.Name = "lueAdliBirimBolum";
            this.lueAdliBirimBolum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAdliBirimBolum.Size = new System.Drawing.Size(197, 20);
            this.lueAdliBirimBolum.TabIndex = 7;
            // 
            // lueAltTur
            // 
            this.lueAltTur.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndKonu, "ALT_TUR_ID", true));
            this.lueAltTur.Location = new System.Drawing.Point(141, 85);
            this.lueAltTur.Name = "lueAltTur";
            this.lueAltTur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAltTur.Size = new System.Drawing.Size(197, 20);
            this.lueAltTur.TabIndex = 6;
            // 
            // lueAnaTur
            // 
            this.lueAnaTur.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndKonu, "ANA_TUR_ID", true));
            this.lueAnaTur.Location = new System.Drawing.Point(141, 59);
            this.lueAnaTur.Name = "lueAnaTur";
            this.lueAnaTur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnaTur.Size = new System.Drawing.Size(197, 20);
            this.lueAnaTur.TabIndex = 5;
            // 
            // txtKonu
            // 
            this.txtKonu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bndKonu, "KONU", true));
            this.txtKonu.Location = new System.Drawing.Point(141, 33);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(197, 20);
            this.txtKonu.TabIndex = 4;
            // 
            // lblBolum
            // 
            this.lblBolum.Location = new System.Drawing.Point(25, 114);
            this.lblBolum.Name = "lblBolum";
            this.lblBolum.Size = new System.Drawing.Size(28, 13);
            this.lblBolum.TabIndex = 3;
            this.lblBolum.Text = "Bölüm";
            // 
            // lblAltTur
            // 
            this.lblAltTur.Location = new System.Drawing.Point(25, 88);
            this.lblAltTur.Name = "lblAltTur";
            this.lblAltTur.Size = new System.Drawing.Size(32, 13);
            this.lblAltTur.TabIndex = 2;
            this.lblAltTur.Text = "Alt Tür";
            // 
            // lblAnaTur
            // 
            this.lblAnaTur.Location = new System.Drawing.Point(25, 62);
            this.lblAnaTur.Name = "lblAnaTur";
            this.lblAnaTur.Size = new System.Drawing.Size(38, 13);
            this.lblAnaTur.TabIndex = 1;
            this.lblAnaTur.Text = "Ana Tür";
            // 
            // lblKonu
            // 
            this.lblKonu.Location = new System.Drawing.Point(25, 36);
            this.lblKonu.Name = "lblKonu";
            this.lblKonu.Size = new System.Drawing.Size(24, 13);
            this.lblKonu.TabIndex = 0;
            this.lblKonu.Text = "Konu";
            // 
            // bndKonu
            // 
            this.bndKonu.DataSource = typeof(AvukatProLib2.Entities.TDI_KOD_TEBLIGAT_KONU);
            this.bndKonu.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.bndKonu_AddingNew);
            // 
            // frmTebligatKonu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 188);
            this.Controls.Add(this.gbTebligatKonu);
            this.Name = "frmTebligatKonu";
            this.Text = "frmTebligatKonu";
            ((System.ComponentModel.ISupportInitialize)(this.gbTebligatKonu)).EndInit();
            this.gbTebligatKonu.ResumeLayout(false);
            this.gbTebligatKonu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAdliBirimBolum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAltTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnaTur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKonu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKonu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbTebligatKonu;
        private DevExpress.XtraEditors.SimpleButton sbtnKaydet;
        private DevExpress.XtraEditors.LookUpEdit lueAdliBirimBolum;
        private DevExpress.XtraEditors.LookUpEdit lueAltTur;
        private DevExpress.XtraEditors.LookUpEdit lueAnaTur;
        private DevExpress.XtraEditors.TextEdit txtKonu;
        private DevExpress.XtraEditors.LabelControl lblBolum;
        private DevExpress.XtraEditors.LabelControl lblAltTur;
        private DevExpress.XtraEditors.LabelControl lblAnaTur;
        private DevExpress.XtraEditors.LabelControl lblKonu;
        private System.Windows.Forms.BindingSource bndKonu;
    }
}