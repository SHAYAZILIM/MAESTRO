namespace  AdimAdimDavaKaydi.UserControls
{
    partial class ucIcraBindingControl
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
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.panelMaster = new DevExpress.XtraEditors.PanelControl();
            this.panelChild = new DevExpress.XtraEditors.PanelControl();
            this.txtAyrac = new DevExpress.XtraEditors.TextEdit();
            this.txtNo = new DevExpress.XtraEditors.TextEdit();
            this.txtKod = new DevExpress.XtraEditors.TextEdit();
            this.cmbKriter = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMaster)).BeginInit();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelChild)).BeginInit();
            this.panelChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAyrac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKriter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Buttons.Append.Visible = false;
            this.dataNavigator1.Buttons.CancelEdit.Visible = false;
            this.dataNavigator1.Buttons.EndEdit.Visible = false;
            this.dataNavigator1.Buttons.NextPage.Visible = false;
            this.dataNavigator1.Buttons.PrevPage.Visible = false;
            this.dataNavigator1.Buttons.Remove.Visible = false;
            this.dataNavigator1.Location = new System.Drawing.Point(1, 2);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(162, 20);
            this.dataNavigator1.TabIndex = 217;
            this.dataNavigator1.Text = "dataNavigator1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAra);
            this.panelControl1.Controls.Add(this.btnTemizle);
            this.panelControl1.Controls.Add(this.panelMaster);
            this.panelControl1.Controls.Add(this.cmbKriter);
            this.panelControl1.Controls.Add(this.dataNavigator1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(697, 22);
            this.panelControl1.TabIndex = 218;
            // 
            // btnAra
            // 
            this.btnAra.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnAra.Location = new System.Drawing.Point(529, 2);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(45, 20);
            this.btnAra.TabIndex = 220;
            this.btnAra.Text = "Ara";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnTemizle.Location = new System.Drawing.Point(576, 2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(121, 20);
            this.btnTemizle.TabIndex = 220;
            this.btnTemizle.Text = "Kriterleri Temizle";
            // 
            // panelMaster
            // 
            this.panelMaster.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelMaster.Controls.Add(this.panelChild);
            this.panelMaster.Location = new System.Drawing.Point(317, 2);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(213, 20);
            this.panelMaster.TabIndex = 219;
            // 
            // panelChild
            // 
            this.panelChild.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelChild.Controls.Add(this.txtAyrac);
            this.panelChild.Controls.Add(this.txtNo);
            this.panelChild.Controls.Add(this.txtKod);
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(0, 0);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(213, 20);
            this.panelChild.TabIndex = 219;
            // 
            // txtAyrac
            // 
            this.txtAyrac.EditValue = "~";
            this.txtAyrac.Location = new System.Drawing.Point(99, 0);
            this.txtAyrac.Name = "txtAyrac";
            this.txtAyrac.Properties.ReadOnly = true;
            this.txtAyrac.Size = new System.Drawing.Size(14, 20);
            this.txtAyrac.TabIndex = 220;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(112, 0);
            this.txtNo.Name = "txtNo";
            this.txtNo.Properties.Mask.BeepOnError = true;
            this.txtNo.Properties.Mask.EditMask = "d";
            this.txtNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNo.Size = new System.Drawing.Size(100, 20);
            this.txtNo.TabIndex = 0;
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(0, 0);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(100, 20);
            this.txtKod.TabIndex = 0;
            // 
            // cmbKriter
            // 
            this.cmbKriter.EditValue = "Arama Kriteri Seç";
            this.cmbKriter.Location = new System.Drawing.Point(164, 2);
            this.cmbKriter.Name = "cmbKriter";
            this.cmbKriter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKriter.Properties.NullText = "Kriter Seçimi";
            this.cmbKriter.Size = new System.Drawing.Size(152, 20);
            this.cmbKriter.TabIndex = 218;
            // 
            // ucIcraBindingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ucIcraBindingControl";
            this.Size = new System.Drawing.Size(697, 22);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMaster)).EndInit();
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelChild)).EndInit();
            this.panelChild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAyrac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKriter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbKriter;
        private DevExpress.XtraEditors.PanelControl panelChild;
        private DevExpress.XtraEditors.TextEdit txtAyrac;
        private DevExpress.XtraEditors.TextEdit txtNo;
        private DevExpress.XtraEditors.TextEdit txtKod;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.PanelControl panelMaster;
        internal DevExpress.XtraEditors.DataNavigator dataNavigator1;
    }
}
