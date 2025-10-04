using AvukatProLib.Util;
namespace  AdimAdimDavaKaydi.IcraTakipForms
{
    partial class ucIcraCore
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
            if (AuthHelperBase.loadedControlList.Contains(this.Name)) AuthHelperBase.loadedControlList.Remove(this.Name);
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.ucIcraGridlerTemp1 = new AdimAdimDavaKaydi.IcraTakipForms.ucIcraGridlerTemp();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblKlasorr2 = new System.Windows.Forms.Label();
            this.lblKlasorr1 = new System.Windows.Forms.Label();
            this.lblTahsilatt = new System.Windows.Forms.Label();
            this.KrediTipp = new System.Windows.Forms.Label();
            this.lblKrediGrupp = new System.Windows.Forms.Label();
            this.lblOzell = new System.Windows.Forms.Label();
            this.lblFoyYerii = new System.Windows.Forms.Label();
            this.lblFoyBirimm = new System.Windows.Forms.Label();
            this.lblSubee = new System.Windows.Forms.Label();
            this.lblBankk = new System.Windows.Forms.Label();
            this.lueBanka = new DevExpress.XtraEditors.LookUpEdit();
            this.lueFoyBirim = new DevExpress.XtraEditors.LookUpEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.lueTahsilat = new DevExpress.XtraEditors.LookUpEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.lueKrediGrup = new DevExpress.XtraEditors.LookUpEdit();
            this.lueKrediTip = new DevExpress.XtraEditors.LookUpEdit();
            this.lueFoyOzelDurum = new DevExpress.XtraEditors.LookUpEdit();
            this.lueFoyYeri = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSube = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBanka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTahsilat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediGrup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyOzelDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyYeri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(739, 572);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.ucIcraGridlerTemp1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(733, 544);
            this.xtraTabPage1.Text = "Ýcra Takip Bilgileri";
            // 
            // ucIcraGridlerTemp1
            // 
            this.ucIcraGridlerTemp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIcraGridlerTemp1.Location = new System.Drawing.Point(0, 0);
            this.ucIcraGridlerTemp1.Name = "ucIcraGridlerTemp1";
            this.ucIcraGridlerTemp1.Size = new System.Drawing.Size(733, 544);
            this.ucIcraGridlerTemp1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panelControl3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(733, 544);
            this.xtraTabPage2.Text = "Dosya Özel Bilgileri";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.xtraTabControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(733, 544);
            this.panelControl3.TabIndex = 202;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage4;
            this.xtraTabControl2.Size = new System.Drawing.Size(729, 540);
            this.xtraTabControl2.TabIndex = 180;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage4});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.xtraScrollableControl1);
            this.xtraTabPage4.Controls.Add(this.panelControl1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(723, 512);
            this.xtraTabPage4.Text = "Dosya Kodlarý";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.panelControl4);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 181);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(723, 331);
            this.xtraScrollableControl1.TabIndex = 184;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.txtAciklama);
            this.panelControl4.Controls.Add(this.lblAciklama);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(723, 331);
            this.panelControl4.TabIndex = 183;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAciklama.Location = new System.Drawing.Point(2, 15);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(719, 314);
            this.txtAciklama.TabIndex = 183;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAciklama.Location = new System.Drawing.Point(2, 2);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(52, 13);
            this.lblAciklama.TabIndex = 184;
            this.lblAciklama.Text = "Açýklama:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblKlasorr2);
            this.panelControl1.Controls.Add(this.lblKlasorr1);
            this.panelControl1.Controls.Add(this.lblTahsilatt);
            this.panelControl1.Controls.Add(this.KrediTipp);
            this.panelControl1.Controls.Add(this.lblKrediGrupp);
            this.panelControl1.Controls.Add(this.lblOzell);
            this.panelControl1.Controls.Add(this.lblFoyYerii);
            this.panelControl1.Controls.Add(this.lblFoyBirimm);
            this.panelControl1.Controls.Add(this.lblSubee);
            this.panelControl1.Controls.Add(this.lblBankk);
            this.panelControl1.Controls.Add(this.lueBanka);
            this.panelControl1.Controls.Add(this.lueFoyBirim);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.lueTahsilat);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.lueKrediGrup);
            this.panelControl1.Controls.Add(this.lueKrediTip);
            this.panelControl1.Controls.Add(this.lueFoyOzelDurum);
            this.panelControl1.Controls.Add(this.lueFoyYeri);
            this.panelControl1.Controls.Add(this.lueSube);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(723, 181);
            this.panelControl1.TabIndex = 182;
            // 
            // lblKlasorr2
            // 
            this.lblKlasorr2.AutoSize = true;
            this.lblKlasorr2.Location = new System.Drawing.Point(486, 45);
            this.lblKlasorr2.Name = "lblKlasorr2";
            this.lblKlasorr2.Size = new System.Drawing.Size(49, 13);
            this.lblKlasorr2.TabIndex = 249;
            this.lblKlasorr2.Text = "Klasör 2:";
            // 
            // lblKlasorr1
            // 
            this.lblKlasorr1.AutoSize = true;
            this.lblKlasorr1.Location = new System.Drawing.Point(486, 2);
            this.lblKlasorr1.Name = "lblKlasorr1";
            this.lblKlasorr1.Size = new System.Drawing.Size(49, 13);
            this.lblKlasorr1.TabIndex = 248;
            this.lblKlasorr1.Text = "Klasör 1:";
            // 
            // lblTahsilatt
            // 
            this.lblTahsilatt.AutoSize = true;
            this.lblTahsilatt.Location = new System.Drawing.Point(245, 88);
            this.lblTahsilatt.Name = "lblTahsilatt";
            this.lblTahsilatt.Size = new System.Drawing.Size(48, 13);
            this.lblTahsilatt.TabIndex = 247;
            this.lblTahsilatt.Text = "Tahsilat:";
            // 
            // KrediTipp
            // 
            this.KrediTipp.AutoSize = true;
            this.KrediTipp.Location = new System.Drawing.Point(245, 131);
            this.KrediTipp.Name = "KrediTipp";
            this.KrediTipp.Size = new System.Drawing.Size(52, 13);
            this.KrediTipp.TabIndex = 246;
            this.KrediTipp.Text = "Kredi Tip:";
            // 
            // lblKrediGrupp
            // 
            this.lblKrediGrupp.AutoSize = true;
            this.lblKrediGrupp.Location = new System.Drawing.Point(245, 45);
            this.lblKrediGrupp.Name = "lblKrediGrupp";
            this.lblKrediGrupp.Size = new System.Drawing.Size(61, 13);
            this.lblKrediGrupp.TabIndex = 245;
            this.lblKrediGrupp.Text = "Kredi Grup:";
            // 
            // lblOzell
            // 
            this.lblOzell.AutoSize = true;
            this.lblOzell.Location = new System.Drawing.Point(245, 2);
            this.lblOzell.Name = "lblOzell";
            this.lblOzell.Size = new System.Drawing.Size(32, 13);
            this.lblOzell.TabIndex = 244;
            this.lblOzell.Text = "Özel:";
            // 
            // lblFoyYerii
            // 
            this.lblFoyYerii.AutoSize = true;
            this.lblFoyYerii.Location = new System.Drawing.Point(5, 131);
            this.lblFoyYerii.Name = "lblFoyYerii";
            this.lblFoyYerii.Size = new System.Drawing.Size(50, 13);
            this.lblFoyYerii.TabIndex = 243;
            this.lblFoyYerii.Text = "Föy Yeri:";
            // 
            // lblFoyBirimm
            // 
            this.lblFoyBirimm.AutoSize = true;
            this.lblFoyBirimm.Location = new System.Drawing.Point(5, 88);
            this.lblFoyBirimm.Name = "lblFoyBirimm";
            this.lblFoyBirimm.Size = new System.Drawing.Size(54, 13);
            this.lblFoyBirimm.TabIndex = 242;
            this.lblFoyBirimm.Text = "Föy Birim:";
            // 
            // lblSubee
            // 
            this.lblSubee.AutoSize = true;
            this.lblSubee.Location = new System.Drawing.Point(5, 45);
            this.lblSubee.Name = "lblSubee";
            this.lblSubee.Size = new System.Drawing.Size(35, 13);
            this.lblSubee.TabIndex = 241;
            this.lblSubee.Text = "Þube:";
            // 
            // lblBankk
            // 
            this.lblBankk.AutoSize = true;
            this.lblBankk.Location = new System.Drawing.Point(5, 2);
            this.lblBankk.Name = "lblBankk";
            this.lblBankk.Size = new System.Drawing.Size(40, 13);
            this.lblBankk.TabIndex = 240;
            this.lblBankk.Text = "Banka:";
            // 
            // lueBanka
            // 
            this.lueBanka.Location = new System.Drawing.Point(5, 20);
            this.lueBanka.Name = "lueBanka";
            this.lueBanka.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lueBanka.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBanka.Properties.NullText = "Banka Listesi";
            this.lueBanka.Properties.ShowHeader = false;
            this.lueBanka.Size = new System.Drawing.Size(225, 20);
            this.lueBanka.TabIndex = 168;
            // 
            // lueFoyBirim
            // 
            this.lueFoyBirim.Location = new System.Drawing.Point(5, 106);
            this.lueFoyBirim.Name = "lueFoyBirim";
            this.lueFoyBirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFoyBirim.Properties.NullText = "Foy Birim";
            this.lueFoyBirim.Properties.ShowHeader = false;
            this.lueFoyBirim.Size = new System.Drawing.Size(225, 20);
            this.lueFoyBirim.TabIndex = 169;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(486, 20);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(228, 20);
            this.textEdit2.TabIndex = 238;
            // 
            // lueTahsilat
            // 
            this.lueTahsilat.Location = new System.Drawing.Point(245, 106);
            this.lueTahsilat.Name = "lueTahsilat";
            this.lueTahsilat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTahsilat.Properties.NullText = "Tahsilat";
            this.lueTahsilat.Properties.ShowHeader = false;
            this.lueTahsilat.Size = new System.Drawing.Size(228, 20);
            this.lueTahsilat.TabIndex = 177;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(486, 63);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(228, 20);
            this.textEdit3.TabIndex = 238;
            // 
            // lueKrediGrup
            // 
            this.lueKrediGrup.Location = new System.Drawing.Point(245, 63);
            this.lueKrediGrup.Name = "lueKrediGrup";
            this.lueKrediGrup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKrediGrup.Properties.NullText = "Kredi Grubu";
            this.lueKrediGrup.Properties.ShowHeader = false;
            this.lueKrediGrup.Size = new System.Drawing.Size(227, 20);
            this.lueKrediGrup.TabIndex = 174;
            // 
            // lueKrediTip
            // 
            this.lueKrediTip.Location = new System.Drawing.Point(245, 149);
            this.lueKrediTip.Name = "lueKrediTip";
            this.lueKrediTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKrediTip.Properties.NullText = "Kredi Tipi";
            this.lueKrediTip.Properties.ShowHeader = false;
            this.lueKrediTip.Size = new System.Drawing.Size(227, 20);
            this.lueKrediTip.TabIndex = 172;
            // 
            // lueFoyOzelDurum
            // 
            this.lueFoyOzelDurum.Location = new System.Drawing.Point(245, 20);
            this.lueFoyOzelDurum.Name = "lueFoyOzelDurum";
            this.lueFoyOzelDurum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFoyOzelDurum.Properties.NullText = "Özel Kod";
            this.lueFoyOzelDurum.Properties.ShowHeader = false;
            this.lueFoyOzelDurum.Size = new System.Drawing.Size(227, 20);
            this.lueFoyOzelDurum.TabIndex = 171;
            // 
            // lueFoyYeri
            // 
            this.lueFoyYeri.Location = new System.Drawing.Point(5, 149);
            this.lueFoyYeri.Name = "lueFoyYeri";
            this.lueFoyYeri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFoyYeri.Properties.NullText = "Foy Yeri";
            this.lueFoyYeri.Properties.ShowHeader = false;
            this.lueFoyYeri.Size = new System.Drawing.Size(225, 20);
            this.lueFoyYeri.TabIndex = 170;
            // 
            // lueSube
            // 
            this.lueSube.Location = new System.Drawing.Point(5, 63);
            this.lueSube.Name = "lueSube";
            this.lueSube.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSube.Properties.NullText = "Þube Listesi";
            this.lueSube.Properties.ShowHeader = false;
            this.lueSube.Size = new System.Drawing.Size(225, 20);
            this.lueSube.TabIndex = 173;
            // 
            // ucIcraCore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucIcraCore";
            this.Size = new System.Drawing.Size(739, 572);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBanka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTahsilat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediGrup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKrediTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyOzelDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFoyYeri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSube.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        internal ucIcraGridlerTemp ucIcraGridlerTemp1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueBanka;
        private DevExpress.XtraEditors.LookUpEdit lueFoyBirim;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        internal DevExpress.XtraEditors.LookUpEdit lueTahsilat;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        internal DevExpress.XtraEditors.LookUpEdit lueKrediGrup;
        internal DevExpress.XtraEditors.LookUpEdit lueKrediTip;
        internal DevExpress.XtraEditors.LookUpEdit lueFoyOzelDurum;
        internal DevExpress.XtraEditors.LookUpEdit lueFoyYeri;
        private DevExpress.XtraEditors.LookUpEdit lueSube;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Label lblOzell;
        private System.Windows.Forms.Label lblFoyYerii;
        private System.Windows.Forms.Label lblFoyBirimm;
        private System.Windows.Forms.Label lblSubee;
        private System.Windows.Forms.Label lblBankk;
        private System.Windows.Forms.Label lblKlasorr2;
        private System.Windows.Forms.Label lblKlasorr1;
        private System.Windows.Forms.Label lblTahsilatt;
        private System.Windows.Forms.Label KrediTipp;
        private System.Windows.Forms.Label lblKrediGrupp;
        private System.Windows.Forms.Label lblAciklama;
    }
}
