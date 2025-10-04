namespace AdimAdimDavaKaydi.Forms
{
    partial class frmKlasorGenelNotlar
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
            this.lcProjeGenelNotlar = new DevExpress.XtraLayout.LayoutControl();
            this.memProjeNotlar = new DevExpress.XtraEditors.MemoEdit();
            this.txtNotTarihi = new DevExpress.XtraEditors.TextEdit();
            this.txtNotAlan = new DevExpress.XtraEditors.TextEdit();
            this.lcGroupProjeGenelNotlar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcItemNotAlan = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemNotTarih = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcItemProjeNotlar = new DevExpress.XtraLayout.LayoutControlItem();
            this.bndGenelNotlar = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcProjeGenelNotlar)).BeginInit();
            this.lcProjeGenelNotlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memProjeNotlar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotAlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupProjeGenelNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNotAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNotTarih)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemProjeNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndGenelNotlar)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 274);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(507, 10);
            // 
            // c_pnlFormSakla
            // 
            this.c_pnlFormSakla.Size = new System.Drawing.Size(343, 10);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(357, 0);
            this.c_btnIptal.Size = new System.Drawing.Size(75, 10);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(432, 0);
            this.c_btnTamam.Size = new System.Drawing.Size(75, 10);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.lcProjeGenelNotlar);
            this.c_pnlContainer.Size = new System.Drawing.Size(507, 284);
            this.c_pnlContainer.Controls.SetChildIndex(this.lcProjeGenelNotlar, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            // 
            // lcProjeGenelNotlar
            // 
            this.lcProjeGenelNotlar.BackColor = System.Drawing.SystemColors.Control;
            this.lcProjeGenelNotlar.Controls.Add(this.memProjeNotlar);
            this.lcProjeGenelNotlar.Controls.Add(this.txtNotTarihi);
            this.lcProjeGenelNotlar.Controls.Add(this.txtNotAlan);
            this.lcProjeGenelNotlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcProjeGenelNotlar.Location = new System.Drawing.Point(0, 0);
            this.lcProjeGenelNotlar.Name = "lcProjeGenelNotlar";
            this.lcProjeGenelNotlar.Root = this.lcGroupProjeGenelNotlar;
            this.lcProjeGenelNotlar.Size = new System.Drawing.Size(507, 284);
            this.lcProjeGenelNotlar.TabIndex = 10;
            this.lcProjeGenelNotlar.Text = "layoutControl1";
            // 
            // memProjeNotlar
            // 
            this.memProjeNotlar.Location = new System.Drawing.Point(57, 60);
            this.memProjeNotlar.Name = "memProjeNotlar";
            this.memProjeNotlar.Size = new System.Drawing.Size(438, 212);
            this.memProjeNotlar.StyleController = this.lcProjeGenelNotlar;
            this.memProjeNotlar.TabIndex = 6;
            // 
            // txtNotTarihi
            // 
            this.txtNotTarihi.Location = new System.Drawing.Point(57, 36);
            this.txtNotTarihi.Name = "txtNotTarihi";
            this.txtNotTarihi.Properties.ReadOnly = true;
            this.txtNotTarihi.Size = new System.Drawing.Size(438, 20);
            this.txtNotTarihi.StyleController = this.lcProjeGenelNotlar;
            this.txtNotTarihi.TabIndex = 5;
            // 
            // txtNotAlan
            // 
            this.txtNotAlan.Location = new System.Drawing.Point(57, 12);
            this.txtNotAlan.Name = "txtNotAlan";
            this.txtNotAlan.Properties.ReadOnly = true;
            this.txtNotAlan.Size = new System.Drawing.Size(438, 20);
            this.txtNotAlan.StyleController = this.lcProjeGenelNotlar;
            this.txtNotAlan.TabIndex = 4;
            // 
            // lcGroupProjeGenelNotlar
            // 
            this.lcGroupProjeGenelNotlar.CustomizationFormText = "layoutControlGroup1";
            this.lcGroupProjeGenelNotlar.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcGroupProjeGenelNotlar.GroupBordersVisible = false;
            this.lcGroupProjeGenelNotlar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemNotAlan,
            this.lcItemNotTarih,
            this.lcItemProjeNotlar});
            this.lcGroupProjeGenelNotlar.Location = new System.Drawing.Point(0, 0);
            this.lcGroupProjeGenelNotlar.Name = "lcGroupProjeGenelNotlar";
            this.lcGroupProjeGenelNotlar.Size = new System.Drawing.Size(507, 284);
            this.lcGroupProjeGenelNotlar.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcGroupProjeGenelNotlar.Text = "lcGroupProjeGenelNotlar";
            this.lcGroupProjeGenelNotlar.TextVisible = false;
            // 
            // lcItemNotAlan
            // 
            this.lcItemNotAlan.Control = this.txtNotAlan;
            this.lcItemNotAlan.CustomizationFormText = "Not Alan";
            this.lcItemNotAlan.Location = new System.Drawing.Point(0, 0);
            this.lcItemNotAlan.Name = "lcItemNotAlan";
            this.lcItemNotAlan.Size = new System.Drawing.Size(487, 24);
            this.lcItemNotAlan.Text = "Not Alan";
            this.lcItemNotAlan.TextSize = new System.Drawing.Size(41, 13);
            // 
            // lcItemNotTarih
            // 
            this.lcItemNotTarih.Control = this.txtNotTarihi;
            this.lcItemNotTarih.CustomizationFormText = "Tarih";
            this.lcItemNotTarih.Location = new System.Drawing.Point(0, 24);
            this.lcItemNotTarih.Name = "lcItemNotTarih";
            this.lcItemNotTarih.Size = new System.Drawing.Size(487, 24);
            this.lcItemNotTarih.Text = "Tarih";
            this.lcItemNotTarih.TextSize = new System.Drawing.Size(41, 13);
            // 
            // lcItemProjeNotlar
            // 
            this.lcItemProjeNotlar.Control = this.memProjeNotlar;
            this.lcItemProjeNotlar.CustomizationFormText = "Not";
            this.lcItemProjeNotlar.Location = new System.Drawing.Point(0, 48);
            this.lcItemProjeNotlar.Name = "lcItemProjeNotlar";
            this.lcItemProjeNotlar.Size = new System.Drawing.Size(487, 216);
            this.lcItemProjeNotlar.Text = "Not";
            this.lcItemProjeNotlar.TextSize = new System.Drawing.Size(41, 13);
            // 
            // frmKlasorGenelNotlar
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 284);
            this.Name = "frmKlasorGenelNotlar";
            this.Text = "Genel Notlar Kayıt";
            this.Load += new System.EventHandler(this.frmKlasorGenelNotlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcProjeGenelNotlar)).EndInit();
            this.lcProjeGenelNotlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memProjeNotlar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotAlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcGroupProjeGenelNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNotAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemNotTarih)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcItemProjeNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndGenelNotlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcProjeGenelNotlar;
        private DevExpress.XtraLayout.LayoutControlGroup lcGroupProjeGenelNotlar;
        private DevExpress.XtraEditors.MemoEdit memProjeNotlar;
        private DevExpress.XtraEditors.TextEdit txtNotTarihi;
        private DevExpress.XtraEditors.TextEdit txtNotAlan;
        private DevExpress.XtraLayout.LayoutControlItem lcItemNotAlan;
        private DevExpress.XtraLayout.LayoutControlItem lcItemNotTarih;
        private DevExpress.XtraLayout.LayoutControlItem lcItemProjeNotlar;
        private System.Windows.Forms.BindingSource bndGenelNotlar;
    }
}