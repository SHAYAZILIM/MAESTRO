namespace  AdimAdimDavaKaydi.Forms
{
    partial class frmTespitKaydetForm
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
            this.ucTespitKaydet1 = new AdimAdimDavaKaydi.UserControls.ucTespitKaydet();
            
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            
            
            
            this.SuspendLayout();
            // 
            // mrqEnAlt
            // 
            
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.ucTespitKaydet1);
            this.c_pnlContainer.Size = new System.Drawing.Size(824, 519);
            this.c_pnlContainer.Controls.SetChildIndex(this.ucTespitKaydet1, 0);
 
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
            // ucTespitKaydet1
            // 
            this.ucTespitKaydet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTespitKaydet1.Location = new System.Drawing.Point(0, 0);

            this.ucTespitKaydet1.MySource = null;
            this.ucTespitKaydet1.Name = "ucTespitKaydet1";
            this.ucTespitKaydet1.Size = new System.Drawing.Size(824, 519);
            this.ucTespitKaydet1.TabIndex = 9;
            // 
            // frmTespitKaydetForm
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 573);
            this.Name = "frmTespitKaydetForm";
            this.Text = "frmTespitKaydetForm";
            this.UstMenu = true;
            this.Load += new System.EventHandler(this.frmTespitKaydetForm_Load);
 
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
 
 
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucTespitKaydet ucTespitKaydet1;
    }
}