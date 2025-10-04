using System;
using System.Collections.Generic;
using System.Data;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmBelgeAramaEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public DataTable belgem;
        public bool editorden;

        public rFrmBelgeAramaEkran()
        {
            this.Load += rFrmBelgeAramaEkran_Load;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ucBelgeAramaGirisEkran1 = new AdimAdimDavaKaydi.UserControls.ucBelgeAramaGirisEkran();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.navBarGroupControlContainer2.Controls.Add(this.ucBelgeAramaGirisEkran1);

            //
            // ucBelgeAramaGirisEkran1
            //
            this.ucBelgeAramaGirisEkran1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBelgeAramaGirisEkran1.Location = new System.Drawing.Point(0, 0);
            this.ucBelgeAramaGirisEkran1.Name = "ucBelgeAramaGirisEkran1";
            this.ucBelgeAramaGirisEkran1.Size = new System.Drawing.Size(918, 238);
            this.ucBelgeAramaGirisEkran1.TabIndex = 0;
            ucBelgeAramaGirisEkran1.Sorgula += ucBelgeAramaGirisEkran1_Sorgula;
            ucBelgeAramaGirisEkran1.Temizle += ucBelgeAramaGirisEkran1_Temizle;
            this.ucBelgeAramaView1 = new AdimAdimDavaKaydi.Belge.UserControls.ucBelgeAramaView();
            this.navBarGroupControlContainer1.Controls.Add(this.ucBelgeAramaView1);

            //
            // ucBelgeAramaView1
            //
            this.ucBelgeAramaView1.CurrentRecord = null;
            this.ucBelgeAramaView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBelgeAramaView1.IdValue = 0;
            this.ucBelgeAramaView1.Location = new System.Drawing.Point(0, 0);
            this.ucBelgeAramaView1.Name = "ucBelgeAramaView1";
            this.ucBelgeAramaView1.Size = new System.Drawing.Size(918, 472);
            this.ucBelgeAramaView1.TabIndex = 0;
            this.ucBelgeAramaView1.TableName = null;
            this.ucBelgeAramaView1.BringToFront();
            this.Enabled = true;

            //
            // panelControl1
            //
            this.panelControl1.Controls.Add(this.btnGonder);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 345);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(350, 50);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Visible = false;

            //
            // btnGonder
            //
            this.btnGonder.Location = new System.Drawing.Point(10, 8);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(214, 30);
            this.btnGonder.TabIndex = 0;
            this.btnGonder.Text = "Seçilen Belgeyi Editöre Gönder";
            this.btnGonder.Click += this.btnGonder_Click;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.Controls.Add(this.panelControl1);

            if (editorden)
            {
                panelControl1.Visible = true;
                panelControl1.SendToBack();
                ucBelgeAramaView1.BringToFront();
                //ucBelgeAramaView1.panelControl3.Visible = false;
            }
            else
            {
                //ucBelgeAramaView1.panelControl3.Visible = true;
                panelControl1.Visible = false;
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rFrmBelgeAramaEkran_Load(object sender, EventArgs e)
        {
            //this.Enabled = false;
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void ucBelgeAramaGirisEkran1_Sorgula(object sender, EventArgs e)
        {
            if (editorden == false)
                ucBelgeAramaView1.MyDataSource = ucBelgeAramaGirisEkran1.AramaYap();
            else
            {
                belgem = ucBelgeAramaGirisEkran1.AramaYap();

                //belgem =
                //    belgem.Where(
                //        vi => vi.DOKUMAN_UZANTI == "tx" || vi.DOKUMAN_UZANTI == "doc" || vi.DOKUMAN_UZANTI == "docx").
                //        ToList();
                ucBelgeAramaView1.MyDataSource = belgem;
            }
        }

        private void ucBelgeAramaGirisEkran1_Temizle(object sender, EventArgs e)
        {
            ucBelgeAramaView1.MyDataSource = null;
        }
    }
}