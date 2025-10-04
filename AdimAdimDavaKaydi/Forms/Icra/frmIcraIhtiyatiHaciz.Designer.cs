namespace  AdimAdimDavaKaydi
{
    partial class frmIcraIhtiyatiHaciz
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
            this.ucTazminat_Ihtiyat_Taraf1 = new AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat_Taraf();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucTazminat_Ihtiyat1 = new AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueModul = new DevExpress.XtraEditors.LookUpEdit();
            this.glueDosya = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDosya = new DevExpress.XtraEditors.LabelControl();
            this.lblModul = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).BeginInit();
            this.c_pnlAltButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).BeginInit();
            this.c_pnlFormSakla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).BeginInit();
            this.c_pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueDosya.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // c_pnlSag
            // 
            this.c_pnlSag.Location = new System.Drawing.Point(1000, 0);
            this.c_pnlSag.Size = new System.Drawing.Size(17, 630);
            // 
            // c_pnlSol
            // 
            this.c_pnlSol.Size = new System.Drawing.Size(17, 630);
            // 
            // c_pnlAltButtons
            // 
            this.c_pnlAltButtons.Location = new System.Drawing.Point(0, 605);
            this.c_pnlAltButtons.Size = new System.Drawing.Size(1017, 25);
            // 
            // c_btnUstKose
            // 
            this.c_btnUstKose.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.c_btnUstKose.Appearance.Options.UseBackColor = true;
            // 
            // c_btnIptal
            // 
            this.c_btnIptal.Location = new System.Drawing.Point(867, 0);
            // 
            // c_btnTamam
            // 
            this.c_btnTamam.Location = new System.Drawing.Point(942, 0);
            // 
            // c_pnlContainer
            // 
            this.c_pnlContainer.Controls.Add(this.splitContainerControl1);
            this.c_pnlContainer.Size = new System.Drawing.Size(1017, 630);
            this.c_pnlContainer.Controls.SetChildIndex(this.c_pnlAltButtons, 0);
            this.c_pnlContainer.Controls.SetChildIndex(this.splitContainerControl1, 0);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.ucTazminat_Ihtiyat_Taraf1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1017, 285);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Borçlular";
            // 
            // ucTazminat_Ihtiyat_Taraf1
            // 
            this.ucTazminat_Ihtiyat_Taraf1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTazminat_Ihtiyat_Taraf1.KlasorIcin = false;
            this.ucTazminat_Ihtiyat_Taraf1.Location = new System.Drawing.Point(2, 24);
            this.ucTazminat_Ihtiyat_Taraf1.Name = "ucTazminat_Ihtiyat_Taraf1";
            this.ucTazminat_Ihtiyat_Taraf1.Size = new System.Drawing.Size(1013, 259);
            this.ucTazminat_Ihtiyat_Taraf1.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucTazminat_Ihtiyat1);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1017, 605);
            this.splitContainerControl1.SplitterPosition = 315;
            this.splitContainerControl1.TabIndex = 9;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucTazminat_Ihtiyat1
            // 
            this.ucTazminat_Ihtiyat1.CurrentHaciz = null;
            this.ucTazminat_Ihtiyat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTazminat_Ihtiyat1.KlasorIcin = false;
            this.ucTazminat_Ihtiyat1.Location = new System.Drawing.Point(0, 68);
            this.ucTazminat_Ihtiyat1.MyDataSource = null;
            this.ucTazminat_Ihtiyat1.MyDataSourceTeminat = null;
            this.ucTazminat_Ihtiyat1.Name = "ucTazminat_Ihtiyat1";
            this.ucTazminat_Ihtiyat1.Size = new System.Drawing.Size(1017, 247);
            this.ucTazminat_Ihtiyat1.TabIndex = 0;
            this.ucTazminat_Ihtiyat1.MyDataSourceChanged += new System.EventHandler(this.ucTazminat_Ihtiyat1_MyDataSourceChanged);
            this.ucTazminat_Ihtiyat1.FocusedHacizChanged += new DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler(this.ucTazminat_Ihtiyat1_FocusedHacizChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueModul);
            this.panelControl1.Controls.Add(this.glueDosya);
            this.panelControl1.Controls.Add(this.lblDosya);
            this.panelControl1.Controls.Add(this.lblModul);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1017, 68);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Visible = false;
            // 
            // lueModul
            // 
            this.lueModul.Location = new System.Drawing.Point(60, 12);
            this.lueModul.Name = "lueModul";
            this.lueModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueModul.Size = new System.Drawing.Size(945, 20);
            this.lueModul.TabIndex = 5;
            this.lueModul.EditValueChanged += new System.EventHandler(this.lueModul_EditValueChanged);
            // 
            // glueDosya
            // 
            this.glueDosya.Location = new System.Drawing.Point(60, 38);
            this.glueDosya.Name = "glueDosya";
            this.glueDosya.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueDosya.Properties.View = this.gridLookUpEdit1View;
            this.glueDosya.Size = new System.Drawing.Size(945, 20);
            this.glueDosya.TabIndex = 4;
            this.glueDosya.EditValueChanged += new System.EventHandler(this.glueDosya_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblDosya
            // 
            this.lblDosya.Location = new System.Drawing.Point(6, 42);
            this.lblDosya.Name = "lblDosya";
            this.lblDosya.Size = new System.Drawing.Size(37, 13);
            this.lblDosya.TabIndex = 2;
            this.lblDosya.Text = "Dosya :";
            // 
            // lblModul
            // 
            this.lblModul.Location = new System.Drawing.Point(6, 15);
            this.lblModul.Name = "lblModul";
            this.lblModul.Size = new System.Drawing.Size(35, 13);
            this.lblModul.TabIndex = 1;
            this.lblModul.Text = "Modül :";
            // 
            // frmIcraIhtiyatiHaciz
            // 
            this.AltMenu = true;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 630);
            this.FormunBolumu = AdimAdimDavaKaydi.Util.BaseClasses.FormBolumu.Icra;
            this.FormunTipi = AdimAdimDavaKaydi.Util.BaseClasses.FormTipi.UfakKayitFormu;
            this.Name = "frmIcraIhtiyatiHaciz";
            this.Text = "Ýhtiyati Haciz Bilgileri";
            this.UstMenu = true;
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAltButtons)).EndInit();
            this.c_pnlAltButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlFormSakla)).EndInit();
            this.c_pnlFormSakla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlContainer)).EndInit();
            this.c_pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glueDosya.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat_Taraf ucTazminat_Ihtiyat_Taraf1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private AdimAdimDavaKaydi.UserControls.ucTazminat_Ihtiyat ucTazminat_Ihtiyat1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit glueDosya;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblDosya;
        private DevExpress.XtraEditors.LabelControl lblModul;
        private DevExpress.XtraEditors.LookUpEdit lueModul;

    }
}