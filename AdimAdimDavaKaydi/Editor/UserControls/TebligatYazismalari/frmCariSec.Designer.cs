namespace  AdimAdimDavaKaydi.Editor.UserControls.TebligatYazismalari
{
    partial class frmCariSec
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ucCariArama1 = new AdimAdimDavaKaydi.UserControls.ucCariArama();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(678, 478);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Tamam";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ucCariArama1
            // 
            this.ucCariArama1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCariArama1.Location = new System.Drawing.Point(17, 22);

            this.ucCariArama1.Name = "ucCariArama1";
            //this.ucCariArama1.Secilebilirmi = false;
            this.ucCariArama1.SeciliCariler = null;
            this.ucCariArama1.Size = new System.Drawing.Size(752, 368);
            this.ucCariArama1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 486);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(787, 36);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Location = new System.Drawing.Point(691, 8);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(96, 23);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "Tamam";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmCariSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 522);
            this.Controls.Add(this.ucCariArama1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmCariSec";
            this.Text = "frmCariSec";
            this.Load += new System.EventHandler(this.frmCariSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucCariArama ucCariArama1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}