namespace  AdimAdimDavaKaydi.Editor.Forms
{
    partial class frmYazdirmaAyarlari
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
            this.ucSablonYazdirmaSecim1 = new AvpNg.Editor.UserControls.ucSablonYazdirmaSecim();
            this.button1 = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            
            
            
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Size = new System.Drawing.Size(642, 327);
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(625, 33);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 304);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Location = new System.Drawing.Point(0, 33);
            this.c_pnlSol.Size = new System.Drawing.Size(17, 304);
            // 
            // c_pnlAltButtons
            // 
 
 
            // 
            // c_btnIptal
            // 
 
            // 
            // c_btnTamam
            // 
 
            // 
            // prgEnAlt
            // 
            // 
            // c_btnYardim
            // 
 
 
 
 
 
 
 
 
 
 
 
 
 
            // 
            // c_btnCaption
            // 
 
 
 
 
 
 
 
 
            // 
            // ucSablonYazdirmaSecim1
            // 
            this.ucSablonYazdirmaSecim1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSablonYazdirmaSecim1.Location = new System.Drawing.Point(0, 33);

            this.ucSablonYazdirmaSecim1.Name = "ucSablonYazdirmaSecim1";
            this.ucSablonYazdirmaSecim1.Size = new System.Drawing.Size(642, 304);
            this.ucSablonYazdirmaSecim1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(642, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmYazdirmaAyarlari
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 381);
            this.Controls.Add(this.ucSablonYazdirmaSecim1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "frmYazdirmaAyarlari";
            this.Text = "Yazdirma Ayarlari";
            this.UstMenu = true;
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.ucSablonYazdirmaSecim1, 0);
            
            
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvpNg.Editor.UserControls.ucSablonYazdirmaSecim ucSablonYazdirmaSecim1;
        private System.Windows.Forms.Button button1;
    }
}