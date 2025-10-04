namespace  AdimAdimDavaKaydi.Ajanda.Forms.SmallForms
{
    partial class frmCalismaSaatleri
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
            this.teBaslangic = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teBitis = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.teBaslangic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBitis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teBaslangic
            // 
            this.teBaslangic.EditValue = new System.DateTime(2009, 5, 8, 0, 0, 0, 0);
            this.teBaslangic.Location = new System.Drawing.Point(159, 30);
            this.teBaslangic.Name = "teBaslangic";
            this.teBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teBaslangic.Size = new System.Drawing.Size(100, 20);
            this.teBaslangic.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Ýþe Baþlama";
            // 
            // teBitis
            // 
            this.teBitis.EditValue = new System.DateTime(2009, 5, 8, 0, 0, 0, 0);
            this.teBitis.Location = new System.Drawing.Point(159, 56);
            this.teBitis.Name = "teBitis";
            this.teBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teBitis.Size = new System.Drawing.Size(100, 20);
            this.teBitis.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(64, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Ýþ Bitiþ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(103, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Ýptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTamm
            // 
            this.btnTamm.Location = new System.Drawing.Point(184, 96);
            this.btnTamm.Name = "btnTamm";
            this.btnTamm.Size = new System.Drawing.Size(75, 23);
            this.btnTamm.TabIndex = 2;
            this.btnTamm.Text = "Tamam";
            this.btnTamm.Click += new System.EventHandler(this.btnTamm_Click);
            // 
            // frmCalismaSaatleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 131);
            this.Controls.Add(this.btnTamm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.teBitis);
            this.Controls.Add(this.teBaslangic);
            this.Name = "frmCalismaSaatleri";
            this.Text = "frmCalismaSaatleri";
            this.Load += new System.EventHandler(this.frmCalismaSaatleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teBaslangic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBitis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit teBaslangic;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit teBitis;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnTamm;
    }
}