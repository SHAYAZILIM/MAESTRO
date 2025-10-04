namespace  AdimAdimDavaKaydi.Util
{
    partial class frmAsamaTebligatGirisi
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkTebligatKonu = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkAltAsama = new DevExpress.XtraEditors.LookUpEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkTebligatKonu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAltAsama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 371);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(647, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(497, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(572, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Size = new System.Drawing.Size(647, 396);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Teligat Konu:";
            // 
            // lkTebligatKonu
            // 
            this.lkTebligatKonu.Location = new System.Drawing.Point(12, 27);
            this.lkTebligatKonu.Name = "lkTebligatKonu";
            this.lkTebligatKonu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkTebligatKonu.Size = new System.Drawing.Size(275, 20);
            this.lkTebligatKonu.TabIndex = 1;
            this.lkTebligatKonu.EditValueChanged += new System.EventHandler(this.lkTebligatKonu_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Alt Aþama :";
            // 
            // lkAltAsama
            // 
            this.lkAltAsama.Location = new System.Drawing.Point(12, 66);
            this.lkAltAsama.Name = "lkAltAsama";
            this.lkAltAsama.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAltAsama.Size = new System.Drawing.Size(275, 20);
            this.lkAltAsama.TabIndex = 1;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(13, 93);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("POSTALANDI_MI", "Postalanma (POSTALANDI_MI)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("TEBLIG_TARIH", "Teblið edilme(TEBLIG_TARIH)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("BILA_TARIHI", "Bila  (BILA_TARIHI)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ZABITA_ARASTIRMA_TARIHI", "Zabýta Araþtýrmasý (ZABITA_ARASTIRMA_TARIHI)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("OLUMSUZ_SONUC_TARIHI", "Olumsuz Sonuc (OLUMSUZ_SONUC_TARIHI)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("TEBLIGATA_ITIRAZ_TARIHI", "Tebligata Ýtiraz (TEBLIGATA_ITIRAZ_TARIHI)")});
            this.radioGroup1.Size = new System.Drawing.Size(274, 141);
            this.radioGroup1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(13, 256);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(274, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmAsamaTebligatGirisi
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 396);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.lkAltAsama);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lkTebligatKonu);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmAsamaTebligatGirisi";
            this.Text = "frmAsamaTebligatGirisi";
            this.Load += new System.EventHandler(this.frmAsamaTebligatGirisi_Load);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.lkTebligatKonu, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.lkAltAsama, 0);
            this.Controls.SetChildIndex(this.radioGroup1, 0);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkTebligatKonu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAltAsama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkTebligatKonu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkAltAsama;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}