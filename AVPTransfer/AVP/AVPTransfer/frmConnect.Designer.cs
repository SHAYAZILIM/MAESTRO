namespace AVPTransfer
{
    partial class frmConnect
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.numCompany = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtDbName = new DevExpress.XtraEditors.TextEdit();
            this.cmbServerAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDbName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.numCompany);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnTransfer);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtPass);
            this.groupControl1.Controls.Add(this.txtUser);
            this.groupControl1.Controls.Add(this.txtDbName);
            this.groupControl1.Controls.Add(this.cmbServerAddress);
            this.groupControl1.Controls.Add(this.btnTestConnection);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(313, 239);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Kaynak Veritabanı";
            // 
            // numCompany
            // 
            this.numCompany.Location = new System.Drawing.Point(119, 152);
            this.numCompany.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCompany.Name = "numCompany";
            this.numCompany.Size = new System.Drawing.Size(59, 21);
            this.numCompany.TabIndex = 30;
            this.numCompany.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(10, 154);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Firma";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Enabled = false;
            this.btnTransfer.Location = new System.Drawing.Point(203, 198);
            this.btnTransfer.LookAndFeel.SkinName = "iMaginary";
            this.btnTransfer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(96, 24);
            this.btnTransfer.TabIndex = 28;
            this.btnTransfer.Text = "Aktar";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "Kullanıcı Şifresi";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "Kullanıcı Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Veritabanı Adı";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(68, 13);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "Sunucu Adresi";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(119, 117);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(180, 20);
            this.txtPass.TabIndex = 23;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(119, 91);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(180, 20);
            this.txtUser.TabIndex = 22;
            // 
            // txtDbName
            // 
            this.txtDbName.EditValue = "master";
            this.txtDbName.Location = new System.Drawing.Point(119, 65);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(180, 20);
            this.txtDbName.TabIndex = 21;
            // 
            // cmbServerAddress
            // 
            this.cmbServerAddress.Location = new System.Drawing.Point(119, 34);
            this.cmbServerAddress.Name = "cmbServerAddress";
            this.cmbServerAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServerAddress.Size = new System.Drawing.Size(180, 20);
            this.cmbServerAddress.TabIndex = 8;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(10, 198);
            this.btnTestConnection.LookAndFeel.SkinName = "iMaginary";
            this.btnTestConnection.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(96, 24);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Bağlantıyı Sına";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 263);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmConnect";
            this.Text = "Veritabanı Bağlantı Bilgileri";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDbName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerAddress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraEditors.ComboBoxEdit cmbServerAddress;
        private DevExpress.XtraEditors.SimpleButton btnTransfer;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtDbName;
        private System.Windows.Forms.NumericUpDown numCompany;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}