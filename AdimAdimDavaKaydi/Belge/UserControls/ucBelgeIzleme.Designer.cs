namespace AdimAdimDavaKaydi.Belge.UserControls
{
    partial class ucBelgeIzleme
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
            this.ucBelgeOnizleme1 = new AdimAdimDavaKaydi.Belge.UserControls.ucBelgeOnizleme();
            this.btnProgram = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucBelgeOnizleme1
            // 
            this.ucBelgeOnizleme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBelgeOnizleme1.Location = new System.Drawing.Point(0, 0);
            this.ucBelgeOnizleme1.Name = "ucBelgeOnizleme1";
            this.ucBelgeOnizleme1.SelectedRecordID = 0;
            this.ucBelgeOnizleme1.SelectedRecordVersion = 0;
            this.ucBelgeOnizleme1.Size = new System.Drawing.Size(395, 461);
            this.ucBelgeOnizleme1.TabIndex = 0;
            // 
            // btnProgram
            // 
            this.btnProgram.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProgram.Location = new System.Drawing.Point(0, 492);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(395, 23);
            this.btnProgram.TabIndex = 12;
            this.btnProgram.Text = "Programda Aç";
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 461);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(395, 31);
            this.panelControl1.TabIndex = 13;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(159, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(28, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "<";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(193, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(28, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = ">";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // ucBelgeIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucBelgeOnizleme1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnProgram);
            this.Name = "ucBelgeIzleme";
            this.Size = new System.Drawing.Size(395, 515);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBelgeOnizleme ucBelgeOnizleme1;
        private DevExpress.XtraEditors.SimpleButton btnProgram;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
