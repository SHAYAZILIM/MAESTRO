namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmAvukatAta
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
            this.groupAvukataAta = new DevExpress.XtraEditors.GroupControl();
            this.sbtnSorumluIzleyenAyni = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAvukataAta = new DevExpress.XtraEditors.SimpleButton();
            this.lueIzleyenAvukat = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSorumluAvukat = new DevExpress.XtraEditors.LookUpEdit();
            this.lblIzleyenAvukat = new DevExpress.XtraEditors.LabelControl();
            this.lblSorumluAvukat = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupAvukataAta)).BeginInit();
            this.groupAvukataAta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueIzleyenAvukat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumluAvukat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAvukataAta
            // 
            this.groupAvukataAta.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupAvukataAta.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this.groupAvukataAta.AppearanceCaption.Options.UseFont = true;
            this.groupAvukataAta.AppearanceCaption.Options.UseForeColor = true;
            this.groupAvukataAta.Controls.Add(this.sbtnSorumluIzleyenAyni);
            this.groupAvukataAta.Controls.Add(this.sbtnAvukataAta);
            this.groupAvukataAta.Controls.Add(this.lueIzleyenAvukat);
            this.groupAvukataAta.Controls.Add(this.lueSorumluAvukat);
            this.groupAvukataAta.Controls.Add(this.lblIzleyenAvukat);
            this.groupAvukataAta.Controls.Add(this.lblSorumluAvukat);
            this.groupAvukataAta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAvukataAta.Location = new System.Drawing.Point(0, 0);
            this.groupAvukataAta.Name = "groupAvukataAta";
            this.groupAvukataAta.Size = new System.Drawing.Size(480, 122);
            this.groupAvukataAta.TabIndex = 0;
            this.groupAvukataAta.Text = "Dosyanın SORUMLU ve İZLEYEN avukatlarını seçiniz.";
            // 
            // sbtnSorumluIzleyenAyni
            // 
            this.sbtnSorumluIzleyenAyni.Location = new System.Drawing.Point(338, 54);
            this.sbtnSorumluIzleyenAyni.Name = "sbtnSorumluIzleyenAyni";
            this.sbtnSorumluIzleyenAyni.Size = new System.Drawing.Size(134, 27);
            this.sbtnSorumluIzleyenAyni.TabIndex = 5;
            this.sbtnSorumluIzleyenAyni.Text = "Sorumlu - İzleyen Aynı";
            this.sbtnSorumluIzleyenAyni.Click += new System.EventHandler(this.sbtnSorumluIzleyenAyni_Click);
            // 
            // sbtnAvukataAta
            // 
            this.sbtnAvukataAta.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAvukataAta.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.sbtnAvukataAta.Appearance.Options.UseFont = true;
            this.sbtnAvukataAta.Appearance.Options.UseForeColor = true;
            this.sbtnAvukataAta.Location = new System.Drawing.Point(106, 87);
            this.sbtnAvukataAta.Name = "sbtnAvukataAta";
            this.sbtnAvukataAta.Size = new System.Drawing.Size(226, 23);
            this.sbtnAvukataAta.TabIndex = 4;
            this.sbtnAvukataAta.Text = "ATAMAYI GERÇEKLEŞTİR";
            this.sbtnAvukataAta.Click += new System.EventHandler(this.sbtnAvukataAta_Click);
            // 
            // lueIzleyenAvukat
            // 
            this.lueIzleyenAvukat.Location = new System.Drawing.Point(106, 61);
            this.lueIzleyenAvukat.Name = "lueIzleyenAvukat";
            this.lueIzleyenAvukat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIzleyenAvukat.Size = new System.Drawing.Size(226, 20);
            this.lueIzleyenAvukat.TabIndex = 3;
            // 
            // lueSorumluAvukat
            // 
            this.lueSorumluAvukat.Location = new System.Drawing.Point(106, 35);
            this.lueSorumluAvukat.Name = "lueSorumluAvukat";
            this.lueSorumluAvukat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSorumluAvukat.Size = new System.Drawing.Size(226, 20);
            this.lueSorumluAvukat.TabIndex = 2;
            // 
            // lblIzleyenAvukat
            // 
            this.lblIzleyenAvukat.Location = new System.Drawing.Point(12, 64);
            this.lblIzleyenAvukat.Name = "lblIzleyenAvukat";
            this.lblIzleyenAvukat.Size = new System.Drawing.Size(72, 13);
            this.lblIzleyenAvukat.TabIndex = 1;
            this.lblIzleyenAvukat.Text = "İzleyen Avukat";
            // 
            // lblSorumluAvukat
            // 
            this.lblSorumluAvukat.Location = new System.Drawing.Point(12, 38);
            this.lblSorumluAvukat.Name = "lblSorumluAvukat";
            this.lblSorumluAvukat.Size = new System.Drawing.Size(75, 13);
            this.lblSorumluAvukat.TabIndex = 0;
            this.lblSorumluAvukat.Text = "Sorumlu Avukat";
            // 
            // frmAvukatAta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 122);
            this.Controls.Add(this.groupAvukataAta);
            this.Name = "frmAvukatAta";
            this.Text = "Avuakata Atama Ekranı";
            this.Load += new System.EventHandler(this.frmAvukatAta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupAvukataAta)).EndInit();
            this.groupAvukataAta.ResumeLayout(false);
            this.groupAvukataAta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueIzleyenAvukat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSorumluAvukat.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupAvukataAta;
        private DevExpress.XtraEditors.LookUpEdit lueIzleyenAvukat;
        private DevExpress.XtraEditors.LookUpEdit lueSorumluAvukat;
        private DevExpress.XtraEditors.LabelControl lblIzleyenAvukat;
        private DevExpress.XtraEditors.LabelControl lblSorumluAvukat;
        private DevExpress.XtraEditors.SimpleButton sbtnAvukataAta;
        private DevExpress.XtraEditors.SimpleButton sbtnSorumluIzleyenAyni;
    }
}