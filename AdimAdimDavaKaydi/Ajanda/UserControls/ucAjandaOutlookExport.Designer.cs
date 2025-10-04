namespace  AdimAdimDavaKaydi.Ajanda.UserControls
{
    partial class ucAjandaOutlookExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAjandaOutlookExport));
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnOutlooktanAl = new DevExpress.XtraEditors.SimpleButton();
            this.btnOutlookaGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnOutlooklaSenk = new DevExpress.XtraEditors.SimpleButton();
            this.btnOutlookuSenkron = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(73, 12);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "Outlook Klasörü Seçiniz...";
            this.lookUpEdit1.Size = new System.Drawing.Size(276, 20);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // btnOutlooktanAl
            // 
            this.btnOutlooktanAl.Image = ((System.Drawing.Image)(resources.GetObject("btnOutlooktanAl.Image")));
            this.btnOutlooktanAl.Location = new System.Drawing.Point(192, 38);
            this.btnOutlooktanAl.Name = "btnOutlooktanAl";
            this.btnOutlooktanAl.Size = new System.Drawing.Size(157, 23);
            this.btnOutlooktanAl.TabIndex = 1;
            this.btnOutlooktanAl.Text = "Outlooktan Al";
            this.btnOutlooktanAl.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnOutlookaGonder
            // 
            this.btnOutlookaGonder.Image = ((System.Drawing.Image)(resources.GetObject("btnOutlookaGonder.Image")));
            this.btnOutlookaGonder.Location = new System.Drawing.Point(29, 38);
            this.btnOutlookaGonder.Name = "btnOutlookaGonder";
            this.btnOutlookaGonder.Size = new System.Drawing.Size(157, 23);
            this.btnOutlookaGonder.TabIndex = 1;
            this.btnOutlookaGonder.Text = "Outlooka Ver";
            this.btnOutlookaGonder.Click += new System.EventHandler(this.btnOutlookaGonder_Click);
            // 
            // btnOutlooklaSenk
            // 
            this.btnOutlooklaSenk.Location = new System.Drawing.Point(157, 67);
            this.btnOutlooklaSenk.Name = "btnOutlooklaSenk";
            this.btnOutlooklaSenk.Size = new System.Drawing.Size(29, 23);
            this.btnOutlooklaSenk.TabIndex = 1;
            this.btnOutlooklaSenk.Text = "Outlook ile Senkronize Et";
            this.btnOutlooklaSenk.Visible = false;
            this.btnOutlooklaSenk.Click += new System.EventHandler(this.btnOutlooklaSenk_Click);
            // 
            // btnOutlookuSenkron
            // 
            this.btnOutlookuSenkron.Location = new System.Drawing.Point(99, 67);
            this.btnOutlookuSenkron.Name = "btnOutlookuSenkron";
            this.btnOutlookuSenkron.Size = new System.Drawing.Size(29, 23);
            this.btnOutlookuSenkron.TabIndex = 1;
            this.btnOutlookuSenkron.Text = "Outlook u senkronize et";
            this.btnOutlookuSenkron.Visible = false;
            this.btnOutlookuSenkron.Click += new System.EventHandler(this.btnOutlookuSenkron_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Klasör";
            // 
            // ucAjandaOutlookExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnOutlookuSenkron);
            this.Controls.Add(this.btnOutlooklaSenk);
            this.Controls.Add(this.btnOutlookaGonder);
            this.Controls.Add(this.btnOutlooktanAl);
            this.Controls.Add(this.lookUpEdit1);
            this.Name = "ucAjandaOutlookExport";
            this.Size = new System.Drawing.Size(375, 103);
            this.Load += new System.EventHandler(this.ucAjandaOutlookExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton btnOutlooktanAl;
        private DevExpress.XtraEditors.SimpleButton btnOutlookaGonder;
        private DevExpress.XtraEditors.SimpleButton btnOutlooklaSenk;
        private DevExpress.XtraEditors.SimpleButton btnOutlookuSenkron;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
