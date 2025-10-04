namespace  AdimAdimDavaKaydi.Util
{
    partial class UcDovizliTutarAlani
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
            this.spinTutar = new DevExpress.XtraEditors.SpinEdit();
            this.lueBirim = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinTutar
            // 
            this.spinTutar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spinTutar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinTutar.Location = new System.Drawing.Point(0, 0);
            this.spinTutar.Name = "spinTutar";
            this.spinTutar.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.spinTutar.Properties.Appearance.Options.UseBackColor = true;
            this.spinTutar.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spinTutar.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.spinTutar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinTutar.Properties.NullValuePromptShowForEmptyValue = true;
            this.spinTutar.Size = new System.Drawing.Size(107, 20);
            this.spinTutar.TabIndex = 0;
            // 
            // lueBirim
            // 
            this.lueBirim.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lueBirim.Location = new System.Drawing.Point(107, 0);
            this.lueBirim.Name = "lueBirim";
            this.lueBirim.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.lueBirim.Properties.Appearance.Options.UseBackColor = true;
            this.lueBirim.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lueBirim.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.lueBirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBirim.Size = new System.Drawing.Size(53, 20);
            this.lueBirim.TabIndex = 1;
            this.lueBirim.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lueBirim_EditValueChanging);
            // 
            // UcDovizliTutarAlani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lueBirim);
            this.Controls.Add(this.spinTutar);
            this.MaximumSize = new System.Drawing.Size(0, 20);
            this.MinimumSize = new System.Drawing.Size(160, 20);
            this.Name = "UcDovizliTutarAlani";
            this.Size = new System.Drawing.Size(160, 20);
            ((System.ComponentModel.ISupportInitialize)(this.spinTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBirim.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinTutar;
        private DevExpress.XtraEditors.LookUpEdit lueBirim;
    }
}
