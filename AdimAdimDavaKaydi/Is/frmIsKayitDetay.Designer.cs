namespace  AdimAdimDavaKaydi.Is
{
    partial class frmIsKayitDetay
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.btnBitir = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lueDurmaNeden = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblZaman = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurmaNeden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZaman.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblZaman);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.memoEdit1);
            this.panelControl1.Controls.Add(this.btnBitir);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(416, 131);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(104, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Duruklama Açıklaması ";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(24, 25);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(357, 28);
            this.memoEdit1.TabIndex = 4;
            // 
            // btnBitir
            // 
            this.btnBitir.Location = new System.Drawing.Point(122, 98);
            this.btnBitir.Name = "btnBitir";
            this.btnBitir.Size = new System.Drawing.Size(131, 23);
            this.btnBitir.TabIndex = 2;
            this.btnBitir.Text = "İşe Başla";
            this.btnBitir.Click += new System.EventHandler(this.btnBitir_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lueDurmaNeden);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(416, 30);
            this.panelControl2.TabIndex = 0;
            // 
            // lueDurmaNeden
            // 
            this.lueDurmaNeden.Location = new System.Drawing.Point(85, 5);
            this.lueDurmaNeden.Name = "lueDurmaNeden";
            this.lueDurmaNeden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDurmaNeden.Size = new System.Drawing.Size(257, 20);
            this.lueDurmaNeden.TabIndex = 1;
            this.lueDurmaNeden.EditValueChanged += new System.EventHandler(this.lueDurmaNeden_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Neden";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblZaman
            // 
            this.lblZaman.Location = new System.Drawing.Point(101, 69);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblZaman.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblZaman.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblZaman.Properties.Appearance.Options.UseBackColor = true;
            this.lblZaman.Properties.Appearance.Options.UseFont = true;
            this.lblZaman.Properties.Appearance.Options.UseForeColor = true;
            this.lblZaman.Properties.Appearance.Options.UseTextOptions = true;
            this.lblZaman.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblZaman.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblZaman.Size = new System.Drawing.Size(164, 23);
            this.lblZaman.TabIndex = 6;
            // 
            // frmIsKayitDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 161);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmIsKayitDetay";
            this.Text = "frmIsKayitDetay";
            this.Load += new System.EventHandler(this.frmIsKayitDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDurmaNeden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZaman.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueDurmaNeden;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnBitir;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.TextEdit lblZaman;
    }
}