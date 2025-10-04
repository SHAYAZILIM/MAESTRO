namespace  AdimAdimDavaKaydi.Is.UserControls
{
    partial class ucHatirlatmaPeriyot
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
            this.dailyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.DailyRecurrenceControl();
            this.weeklyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl();
            this.monthlyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl();
            this.yearlyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.YearlyRecurrenceControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rdSonsuz = new System.Windows.Forms.RadioButton();
            this.rbTekrarsayisi = new System.Windows.Forms.RadioButton();
            this.rbBitisTarihi = new System.Windows.Forms.RadioButton();
            this.nmTekrarSayisi = new System.Windows.Forms.NumericUpDown();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.durationEdit1 = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbxHatirlatmaEkran = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nmTekrarSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHatirlatmaEkran.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dailyRecurrenceControl1
            // 
            this.dailyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dailyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            this.dailyRecurrenceControl1.Location = new System.Drawing.Point(3, 45);
            this.dailyRecurrenceControl1.Name = "dailyRecurrenceControl1";
            this.dailyRecurrenceControl1.Size = new System.Drawing.Size(368, 80);
            this.dailyRecurrenceControl1.TabIndex = 0;
            // 
            // weeklyRecurrenceControl1
            // 
            this.weeklyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.weeklyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            this.weeklyRecurrenceControl1.Location = new System.Drawing.Point(3, 45);
            this.weeklyRecurrenceControl1.Name = "weeklyRecurrenceControl1";
            this.weeklyRecurrenceControl1.Size = new System.Drawing.Size(368, 80);
            this.weeklyRecurrenceControl1.TabIndex = 1;
            this.weeklyRecurrenceControl1.Visible = false;
            // 
            // monthlyRecurrenceControl1
            // 
            this.monthlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.monthlyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            this.monthlyRecurrenceControl1.Location = new System.Drawing.Point(3, 45);
            this.monthlyRecurrenceControl1.Name = "monthlyRecurrenceControl1";
            this.monthlyRecurrenceControl1.Size = new System.Drawing.Size(368, 80);
            this.monthlyRecurrenceControl1.TabIndex = 2;
            this.monthlyRecurrenceControl1.Visible = false;
            // 
            // yearlyRecurrenceControl1
            // 
            this.yearlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.yearlyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            this.yearlyRecurrenceControl1.Location = new System.Drawing.Point(3, 42);
            this.yearlyRecurrenceControl1.Name = "yearlyRecurrenceControl1";
            this.yearlyRecurrenceControl1.Size = new System.Drawing.Size(368, 80);
            this.yearlyRecurrenceControl1.TabIndex = 3;
            this.yearlyRecurrenceControl1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Günlük",
            "Haftalýk",
            "Aylýk",
            "Yýllýk"});
            this.comboBox1.Location = new System.Drawing.Point(17, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // rdSonsuz
            // 
            this.rdSonsuz.AutoSize = true;
            this.rdSonsuz.Location = new System.Drawing.Point(17, 121);
            this.rdSonsuz.Name = "rdSonsuz";
            this.rdSonsuz.Size = new System.Drawing.Size(64, 17);
            this.rdSonsuz.TabIndex = 5;
            this.rdSonsuz.Text = "Bitis Yok";
            this.rdSonsuz.UseVisualStyleBackColor = true;
            // 
            // rbTekrarsayisi
            // 
            this.rbTekrarsayisi.AutoSize = true;
            this.rbTekrarsayisi.Checked = true;
            this.rbTekrarsayisi.Location = new System.Drawing.Point(17, 144);
            this.rbTekrarsayisi.Name = "rbTekrarsayisi";
            this.rbTekrarsayisi.Size = new System.Drawing.Size(86, 17);
            this.rbTekrarsayisi.TabIndex = 5;
            this.rbTekrarsayisi.TabStop = true;
            this.rbTekrarsayisi.Text = "Tekrar Sayýsý";
            this.rbTekrarsayisi.UseVisualStyleBackColor = true;
            // 
            // rbBitisTarihi
            // 
            this.rbBitisTarihi.AutoSize = true;
            this.rbBitisTarihi.Location = new System.Drawing.Point(17, 169);
            this.rbBitisTarihi.Name = "rbBitisTarihi";
            this.rbBitisTarihi.Size = new System.Drawing.Size(73, 17);
            this.rbBitisTarihi.TabIndex = 5;
            this.rbBitisTarihi.Text = "Bitis Tarihi";
            this.rbBitisTarihi.UseVisualStyleBackColor = true;
            // 
            // nmTekrarSayisi
            // 
            this.nmTekrarSayisi.Location = new System.Drawing.Point(109, 144);
            this.nmTekrarSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTekrarSayisi.Name = "nmTekrarSayisi";
            this.nmTekrarSayisi.Size = new System.Drawing.Size(45, 21);
            this.nmTekrarSayisi.TabIndex = 6;
            this.nmTekrarSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(109, 168);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 7;
            // 
            // durationEdit1
            // 
            this.durationEdit1.EditValue = System.TimeSpan.Parse("00:10:00");
            this.durationEdit1.Location = new System.Drawing.Point(155, 194);
            this.durationEdit1.Name = "durationEdit1";
            this.durationEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.durationEdit1.Properties.ShowEmptyItem = false;
            this.durationEdit1.Size = new System.Drawing.Size(100, 20);
            this.durationEdit1.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 197);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Ýþin baþlangýç zamanýndan :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(261, 197);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "önce";
            // 
            // cbxHatirlatmaEkran
            // 
            this.cbxHatirlatmaEkran.EditValue = "Ýþi Veren ve Yapan";
            this.cbxHatirlatmaEkran.Location = new System.Drawing.Point(234, 18);
            this.cbxHatirlatmaEkran.Name = "cbxHatirlatmaEkran";
            this.cbxHatirlatmaEkran.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxHatirlatmaEkran.Properties.Items.AddRange(new object[] {
            "Ýþ Veren",
            "Ýþi Yapan",
            "Ýþi Veren ve Yapan",
            "Hepsi"});
            this.cbxHatirlatmaEkran.Size = new System.Drawing.Size(114, 20);
            this.cbxHatirlatmaEkran.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(147, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Bildirilecek Taraf:";
            // 
            // ucHatirlatmaPeriyot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cbxHatirlatmaEkran);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.durationEdit1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.nmTekrarSayisi);
            this.Controls.Add(this.rbBitisTarihi);
            this.Controls.Add(this.rbTekrarsayisi);
            this.Controls.Add(this.rdSonsuz);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.yearlyRecurrenceControl1);
            this.Controls.Add(this.monthlyRecurrenceControl1);
            this.Controls.Add(this.weeklyRecurrenceControl1);
            this.Controls.Add(this.dailyRecurrenceControl1);
            this.Name = "ucHatirlatmaPeriyot";
            this.Size = new System.Drawing.Size(378, 420);
            this.Load += new System.EventHandler(this.ucHatirlatmaPeriyot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmTekrarSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHatirlatmaEkran.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.UI.DailyRecurrenceControl dailyRecurrenceControl1;
        private DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl weeklyRecurrenceControl1;
        private DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl monthlyRecurrenceControl1;
        private DevExpress.XtraScheduler.UI.YearlyRecurrenceControl yearlyRecurrenceControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rdSonsuz;
        private System.Windows.Forms.RadioButton rbTekrarsayisi;
        private System.Windows.Forms.RadioButton rbBitisTarihi;
        private System.Windows.Forms.NumericUpDown nmTekrarSayisi;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraScheduler.UI.DurationEdit durationEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.ComboBoxEdit cbxHatirlatmaEkran;
        private DevExpress.XtraEditors.LabelControl labelControl3;

    }
}
