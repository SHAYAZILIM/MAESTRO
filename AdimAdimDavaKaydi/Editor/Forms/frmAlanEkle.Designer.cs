namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmAlanEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlanEkle));
            this.c_spnGenislik = new DevExpress.XtraEditors.SpinEdit();
            this.c_spnBoy = new DevExpress.XtraEditors.SpinEdit();
            this.c_clrArka = new DevExpress.XtraEditors.ColorEdit();
            this.c_lblGenislik = new DevExpress.XtraEditors.LabelControl();
            this.c_lblBoy = new DevExpress.XtraEditors.LabelControl();
            this.c_lblCerceve = new DevExpress.XtraEditors.LabelControl();
            this.c_btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.c_btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_spnGenislik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_spnBoy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_clrArka.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // c_spnGenislik
            // 
            this.c_spnGenislik.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.c_spnGenislik.Location = new System.Drawing.Point(135, 8);
            this.c_spnGenislik.Name = "c_spnGenislik";
            this.c_spnGenislik.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.c_spnGenislik.Size = new System.Drawing.Size(100, 20);
            this.c_spnGenislik.TabIndex = 0;
            // 
            // c_spnBoy
            // 
            this.c_spnBoy.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.c_spnBoy.Location = new System.Drawing.Point(135, 34);
            this.c_spnBoy.Name = "c_spnBoy";
            this.c_spnBoy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.c_spnBoy.Size = new System.Drawing.Size(100, 20);
            this.c_spnBoy.TabIndex = 0;
            // 
            // c_clrArka
            // 
            this.c_clrArka.EditValue = System.Drawing.Color.Empty;
            this.c_clrArka.Location = new System.Drawing.Point(135, 60);
            this.c_clrArka.Name = "c_clrArka";
            this.c_clrArka.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_clrArka.Size = new System.Drawing.Size(100, 20);
            this.c_clrArka.TabIndex = 1;
            // 
            // c_lblGenislik
            // 
            this.c_lblGenislik.Location = new System.Drawing.Point(17, 11);
            this.c_lblGenislik.Name = "c_lblGenislik";
            this.c_lblGenislik.Size = new System.Drawing.Size(35, 13);
            this.c_lblGenislik.TabIndex = 2;
            this.c_lblGenislik.Text = "Genislik";
            // 
            // c_lblBoy
            // 
            this.c_lblBoy.Location = new System.Drawing.Point(17, 6);
            this.c_lblBoy.Name = "c_lblBoy";
            this.c_lblBoy.Size = new System.Drawing.Size(18, 13);
            this.c_lblBoy.TabIndex = 2;
            this.c_lblBoy.Text = "Boy";
            // 
            // c_lblCerceve
            // 
            this.c_lblCerceve.Location = new System.Drawing.Point(17, 67);
            this.c_lblCerceve.Name = "c_lblCerceve";
            this.c_lblCerceve.Size = new System.Drawing.Size(72, 13);
            this.c_lblCerceve.TabIndex = 2;
            this.c_lblCerceve.Text = "ArkaPlan Rengi";
            // 
            // c_btnOk
            // 
            this.c_btnOk.Location = new System.Drawing.Point(160, 111);
            this.c_btnOk.Name = "c_btnOk";
            this.c_btnOk.Size = new System.Drawing.Size(75, 23);
            this.c_btnOk.TabIndex = 1;
            this.c_btnOk.Text = "Tamam";
            this.c_btnOk.Click += new System.EventHandler(this.c_btnOk_Click);
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.Location = new System.Drawing.Point(17, 111);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.c_btnCancel.TabIndex = 0;
            this.c_btnCancel.Text = "Vazgeç";
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Boy";
            // 
            // frmAlanEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 146);
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_btnOk);
            this.Controls.Add(this.c_lblCerceve);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.c_lblGenislik);
            this.Controls.Add(this.c_clrArka);
            this.Controls.Add(this.c_spnBoy);
            this.Controls.Add(this.c_spnGenislik);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlanEkle";
            this.Text = "Alan Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.c_spnGenislik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_spnBoy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_clrArka.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit c_spnGenislik;
        private DevExpress.XtraEditors.SpinEdit c_spnBoy;
        private DevExpress.XtraEditors.ColorEdit c_clrArka;
        private DevExpress.XtraEditors.LabelControl c_lblGenislik;
        private DevExpress.XtraEditors.LabelControl c_lblBoy;
        private DevExpress.XtraEditors.LabelControl c_lblCerceve;
        private DevExpress.XtraEditors.SimpleButton c_btnOk;
        private DevExpress.XtraEditors.SimpleButton c_btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}