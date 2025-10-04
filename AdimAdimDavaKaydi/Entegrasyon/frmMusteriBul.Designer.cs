namespace AdimAdimDavaKaydi.Entegrasyon
{
    partial class frmMusteriBul
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
            this.sbtnSec = new DevExpress.XtraEditors.SimpleButton();
            this.lueMusteri = new AdimAdimDavaKaydi.Util.ExtendedLookUpEdit();
            this.txtUyari = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lueMusteri.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbtnSec
            // 
            this.sbtnSec.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.sbtnSec.Appearance.ForeColor = System.Drawing.Color.Red;
            this.sbtnSec.Appearance.Options.UseFont = true;
            this.sbtnSec.Appearance.Options.UseForeColor = true;
            this.sbtnSec.Location = new System.Drawing.Point(73, 142);
            this.sbtnSec.Name = "sbtnSec";
            this.sbtnSec.Size = new System.Drawing.Size(156, 23);
            this.sbtnSec.TabIndex = 1;
            this.sbtnSec.Text = "SEÇ";
            this.sbtnSec.Click += new System.EventHandler(this.sbtnSec_Click);
            // 
            // lueMusteri
            // 
            this.lueMusteri.Location = new System.Drawing.Point(12, 116);
            this.lueMusteri.Name = "lueMusteri";
            this.lueMusteri.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lueMusteri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Ekle", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", 1, null, true)});
            this.lueMusteri.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.lueMusteri.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueMusteri.Size = new System.Drawing.Size(283, 20);
            this.lueMusteri.TabIndex = 0;
            this.lueMusteri.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueMusteri_ButtonClick);
            // 
            // txtUyari
            // 
            this.txtUyari.Location = new System.Drawing.Point(12, 12);
            this.txtUyari.Multiline = true;
            this.txtUyari.Name = "txtUyari";
            this.txtUyari.Size = new System.Drawing.Size(283, 90);
            this.txtUyari.TabIndex = 2;
            // 
            // frmMusteriBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 175);
            this.Controls.Add(this.txtUyari);
            this.Controls.Add(this.sbtnSec);
            this.Controls.Add(this.lueMusteri);
            this.Name = "frmMusteriBul";
            this.Text = "Müşteri Bulma Ekranı";
            this.Load += new System.EventHandler(this.frmMusteriBul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueMusteri.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbtnSec;
        private AdimAdimDavaKaydi.Util.ExtendedLookUpEdit lueMusteri;
        private System.Windows.Forms.TextBox txtUyari;
    }
}