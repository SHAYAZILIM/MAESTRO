namespace AdimAdimDavaKaydi.Generalclass.Forms
{
    partial class frmFoySec
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
            this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.lblDosya = new DevExpress.XtraEditors.LabelControl();
            this.lueDosya = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGonder
            // 
            this.btnGonder.Enabled = false;
            this.btnGonder.Location = new System.Drawing.Point(428, 47);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(100, 23);
            this.btnGonder.TabIndex = 0;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(322, 47);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(100, 23);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // lblDosya
            // 
            this.lblDosya.Location = new System.Drawing.Point(12, 12);
            this.lblDosya.Name = "lblDosya";
            this.lblDosya.Size = new System.Drawing.Size(37, 13);
            this.lblDosya.TabIndex = 2;
            this.lblDosya.Text = "Dosya :";
            // 
            // lueDosya
            // 
            this.lueDosya.Location = new System.Drawing.Point(55, 9);
            this.lueDosya.Name = "lueDosya";
            this.lueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDosya.Properties.View = this.searchLookUpEdit1View;
            this.lueDosya.Size = new System.Drawing.Size(473, 20);
            this.lueDosya.TabIndex = 3;
            this.lueDosya.EditValueChanged += new System.EventHandler(this.lueDosya_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmFoySec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 77);
            this.Controls.Add(this.lblDosya);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.lueDosya);
            this.Name = "frmFoySec";
            this.Text = "Dosya Seç";
            this.Load += new System.EventHandler(this.frmFoySec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGonder;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.LabelControl lblDosya;
        private DevExpress.XtraEditors.SearchLookUpEdit lueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}