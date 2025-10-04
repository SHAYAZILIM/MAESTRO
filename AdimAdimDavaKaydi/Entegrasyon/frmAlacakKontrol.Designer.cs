namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmAlacakKontrol
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
            this.lblVadeTarihi = new DevExpress.XtraEditors.LabelControl();
            this.lblTutar = new DevExpress.XtraEditors.LabelControl();
            this.lblFaizOrani = new DevExpress.XtraEditors.LabelControl();
            this.dtVadeTarihi = new DevExpress.XtraEditors.DateEdit();
            this.spTutar = new DevExpress.XtraEditors.SpinEdit();
            this.lueTutarParaBirimi = new DevExpress.XtraEditors.LookUpEdit();
            this.spFaizOrani = new DevExpress.XtraEditors.SpinEdit();
            this.sbtnTamam = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTutarParaBirimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFaizOrani.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVadeTarihi
            // 
            this.lblVadeTarihi.Location = new System.Drawing.Point(30, 20);
            this.lblVadeTarihi.Name = "lblVadeTarihi";
            this.lblVadeTarihi.Size = new System.Drawing.Size(63, 13);
            this.lblVadeTarihi.TabIndex = 0;
            this.lblVadeTarihi.Text = "Vade Tarihi : ";
            // 
            // lblTutar
            // 
            this.lblTutar.Location = new System.Drawing.Point(30, 47);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(36, 13);
            this.lblTutar.TabIndex = 1;
            this.lblTutar.Text = "Tutar : ";
            // 
            // lblFaizOrani
            // 
            this.lblFaizOrani.Location = new System.Drawing.Point(30, 74);
            this.lblFaizOrani.Name = "lblFaizOrani";
            this.lblFaizOrani.Size = new System.Drawing.Size(58, 13);
            this.lblFaizOrani.TabIndex = 2;
            this.lblFaizOrani.Text = "Faiz Oranı : ";
            // 
            // dtVadeTarihi
            // 
            this.dtVadeTarihi.EditValue = null;
            this.dtVadeTarihi.Location = new System.Drawing.Point(117, 12);
            this.dtVadeTarihi.Name = "dtVadeTarihi";
            this.dtVadeTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtVadeTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtVadeTarihi.Size = new System.Drawing.Size(185, 20);
            this.dtVadeTarihi.TabIndex = 3;
            // 
            // spTutar
            // 
            this.spTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spTutar.Location = new System.Drawing.Point(117, 39);
            this.spTutar.Name = "spTutar";
            this.spTutar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spTutar.Size = new System.Drawing.Size(115, 20);
            this.spTutar.TabIndex = 4;
            // 
            // lueTutarParaBirimi
            // 
            this.lueTutarParaBirimi.Location = new System.Drawing.Point(239, 39);
            this.lueTutarParaBirimi.Name = "lueTutarParaBirimi";
            this.lueTutarParaBirimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTutarParaBirimi.Size = new System.Drawing.Size(63, 20);
            this.lueTutarParaBirimi.TabIndex = 5;
            // 
            // spFaizOrani
            // 
            this.spFaizOrani.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spFaizOrani.Location = new System.Drawing.Point(117, 66);
            this.spFaizOrani.Name = "spFaizOrani";
            this.spFaizOrani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spFaizOrani.Size = new System.Drawing.Size(185, 20);
            this.spFaizOrani.TabIndex = 6;
            // 
            // sbtnTamam
            // 
            this.sbtnTamam.Location = new System.Drawing.Point(117, 102);
            this.sbtnTamam.Name = "sbtnTamam";
            this.sbtnTamam.Size = new System.Drawing.Size(185, 23);
            this.sbtnTamam.TabIndex = 7;
            this.sbtnTamam.Text = "TAMAMLA";
            this.sbtnTamam.Click += new System.EventHandler(this.sbtnTamam_Click);
            // 
            // frmAlacakKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 140);
            this.Controls.Add(this.sbtnTamam);
            this.Controls.Add(this.spFaizOrani);
            this.Controls.Add(this.lueTutarParaBirimi);
            this.Controls.Add(this.spTutar);
            this.Controls.Add(this.dtVadeTarihi);
            this.Controls.Add(this.lblFaizOrani);
            this.Controls.Add(this.lblTutar);
            this.Controls.Add(this.lblVadeTarihi);
            this.Name = "frmAlacakKontrol";
            this.Text = "KREDİ BİLGİLERİ KONTROL EKRANI";
            this.Load += new System.EventHandler(this.frmAlacakKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVadeTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTutarParaBirimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFaizOrani.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblVadeTarihi;
        private DevExpress.XtraEditors.LabelControl lblTutar;
        private DevExpress.XtraEditors.LabelControl lblFaizOrani;
        private DevExpress.XtraEditors.DateEdit dtVadeTarihi;
        private DevExpress.XtraEditors.SpinEdit spTutar;
        private DevExpress.XtraEditors.LookUpEdit lueTutarParaBirimi;
        private DevExpress.XtraEditors.SpinEdit spFaizOrani;
        private DevExpress.XtraEditors.SimpleButton sbtnTamam;
    }
}