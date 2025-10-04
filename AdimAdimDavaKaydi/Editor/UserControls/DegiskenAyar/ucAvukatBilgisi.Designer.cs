namespace  AdimAdimDavaKaydi.Editor.UserControls.DegiskenAyar
{
    partial class ucAvukatBilgisi
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
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.glueAvukatlar = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.glueAntetBilgileri = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lueAntet = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAvukatlar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAntetBilgileri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAntet.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(15, 10);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Sorumlu Avukat Bilgisinden";
            this.checkEdit1.Size = new System.Drawing.Size(261, 19);
            this.checkEdit1.TabIndex = 0;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(15, 78);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Antet Bilgisinden ";
            this.checkEdit2.Size = new System.Drawing.Size(288, 19);
            this.checkEdit2.TabIndex = 0;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // glueAvukatlar
            // 
            this.glueAvukatlar.Enabled = false;
            this.glueAvukatlar.Location = new System.Drawing.Point(37, 35);
            this.glueAvukatlar.Name = "glueAvukatlar";
            this.glueAvukatlar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueAvukatlar.Properties.View = this.gridLookUpEdit1View;
            this.glueAvukatlar.Size = new System.Drawing.Size(299, 20);
            this.glueAvukatlar.TabIndex = 1;
            this.glueAvukatlar.EditValueChanged += new System.EventHandler(this.glueAvukatlar_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // glueAntetBilgileri
            // 
            this.glueAntetBilgileri.Enabled = false;
            this.glueAntetBilgileri.Location = new System.Drawing.Point(70, 131);
            this.glueAntetBilgileri.Name = "glueAntetBilgileri";
            this.glueAntetBilgileri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueAntetBilgileri.Properties.View = this.gridView1;
            this.glueAntetBilgileri.Size = new System.Drawing.Size(266, 20);
            this.glueAntetBilgileri.TabIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(17, 172);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(356, 138);
            this.memoEdit1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(348, 38);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(25, 17);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "+";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(348, 134);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(25, 17);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "+";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // lueAntet
            // 
            this.lueAntet.Location = new System.Drawing.Point(70, 105);
            this.lueAntet.Name = "lueAntet";
            this.lueAntet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAntet.Size = new System.Drawing.Size(303, 20);
            this.lueAntet.TabIndex = 4;
            this.lueAntet.EditValueChanged += new System.EventHandler(this.lueAntet_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 108);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Antet";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 134);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(21, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Alan";
            // 
            // ucAvukatBilgisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lueAntet);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.glueAntetBilgileri);
            this.Controls.Add(this.glueAvukatlar);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Name = "ucAvukatBilgisi";
            this.Size = new System.Drawing.Size(407, 326);
            this.Load += new System.EventHandler(this.ucAvukatBilgisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAvukatlar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueAntetBilgileri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAntet.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.GridLookUpEdit glueAvukatlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.GridLookUpEdit glueAntetBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LookUpEdit lueAntet;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
