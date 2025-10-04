namespace AdimAdimDavaKaydi.Forms
{
    partial class frmCariMerge
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
            this.lueTarafAdi2 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.prgProcess = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblProcessInfo = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueTarafAdi1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueTarafAdi2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueTarafAdi1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 221);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(521, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(371, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(446, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.panelControl1);
            this.c_pnlContainer.Controls.Add(this.simpleButton1);
            this.c_pnlContainer.Controls.Add(this.labelControl3);
            this.c_pnlContainer.Controls.Add(this.labelControl2);
            this.c_pnlContainer.Controls.Add(this.labelControl1);
            this.c_pnlContainer.Controls.Add(this.lueTarafAdi1);
            this.c_pnlContainer.Controls.Add(this.lueTarafAdi2);
            this.c_pnlContainer.Size = new System.Drawing.Size(521, 246);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.lueTarafAdi2, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.lueTarafAdi1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.labelControl1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.labelControl2, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.labelControl3, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.simpleButton1, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.panelControl1, 0);
            // 
            // lueTarafAdi2
            // 
            this.lueTarafAdi2.Location = new System.Drawing.Point(89, 73);
            this.lueTarafAdi2.Name = "lueTarafAdi2";
            this.lueTarafAdi2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTarafAdi2.Properties.View = this.searchLookUpEdit1View;
            this.lueTarafAdi2.Size = new System.Drawing.Size(402, 20);
            this.lueTarafAdi2.TabIndex = 161;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 162;
            this.labelControl1.Text = "Hedef Şahıs :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(416, 103);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 163;
            this.simpleButton1.Text = "Başla";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // prgProcess
            // 
            this.prgProcess.Location = new System.Drawing.Point(12, 37);
            this.prgProcess.Name = "prgProcess";
            this.prgProcess.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.prgProcess.Properties.Step = 1;
            this.prgProcess.Size = new System.Drawing.Size(474, 18);
            this.prgProcess.TabIndex = 164;
            // 
            // lblProcessInfo
            // 
            this.lblProcessInfo.Location = new System.Drawing.Point(13, 5);
            this.lblProcessInfo.Name = "lblProcessInfo";
            this.lblProcessInfo.Size = new System.Drawing.Size(79, 13);
            this.lblProcessInfo.TabIndex = 165;
            this.lblProcessInfo.Text = "Birleştirme İşlemi";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.prgProcess);
            this.panelControl1.Controls.Add(this.lblProcessInfo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Enabled = false;
            this.panelControl1.Location = new System.Drawing.Point(0, 141);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(521, 80);
            this.panelControl1.TabIndex = 166;
            // 
            // lueTarafAdi1
            // 
            this.lueTarafAdi1.Location = new System.Drawing.Point(89, 47);
            this.lueTarafAdi1.Name = "lueTarafAdi1";
            this.lueTarafAdi1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTarafAdi1.Properties.View = this.gridView1;
            this.lueTarafAdi1.Size = new System.Drawing.Size(402, 20);
            this.lueTarafAdi1.TabIndex = 161;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 162;
            this.labelControl2.Text = "Kaynak Şahıs :";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(16, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(482, 13);
            this.labelControl3.TabIndex = 162;
            this.labelControl3.Text = "Birleştirme işleminin sağlıklı yapılabilmesi için diğer kullanıcıların sisteme ba" +
    "ğlı olmadığından emin olunuz.";
            // 
            // frmCariMerge
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 246);
            this.MinimumSize = new System.Drawing.Size(515, 230);
            this.Name = "frmCariMerge";
            this.Text = "Şahıs Birleştirme";
            this.Load += new System.EventHandler(this.frmCariMerge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            this.c_pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueTarafAdi2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueTarafAdi1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lueTarafAdi2;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ProgressBarControl prgProcess;
        private DevExpress.XtraEditors.LabelControl lblProcessInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lueTarafAdi1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}