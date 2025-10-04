using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmEkleUcakGemiArac : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmEkleUcakGemiArac()
        {
            InitializeComponent();
        }

        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> alreadyaddedList;

        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> selectedList;

        public GemiUcakAracTipi AracTipi { get; set; }

        [Browsable(false), Description("Seçilen araç kayýtlarýný döndürür.")]
        public TList<AV001_TDI_BIL_GEMI_UCAK_ARAC> Secilenler { get; set; }

        public void Show(GemiUcakAracTipi tip)
        {
            //.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.AracTipi = tip;

            //return DialogResult.OK;
            this.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.c_btnTamam.Text = "Gönder";
        }

        private void frmEkleUcakGemiArac_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.GUATipGetirByGUATipId(rlkTipi, (int)this.AracTipi);
            if (BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC == null)
                BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC = BelgeUtil.Inits.context.per_AV001_TDI_BIL_GEMI_UCAK_ARACs.ToList();
            if (alreadyaddedList.Count > 0)
                this.gridControl1.DataSource = alreadyaddedList;
            else
                this.gridControl1.DataSource = BelgeUtil.Inits._per_AV001_TDI_BIL_GEMI_UCAK_ARAC.FindAll(vi => vi.GEMI_UCAK_ARAC_TIP == (byte)this.AracTipi);
            GetirGoturBulYokEt();
        }

        private void GetirGoturBulYokEt()
        {
            //Enum elemanýn ilk harfini alýyoruz
            string kd = this.AracTipi.ToString()[0].ToString();
            foreach (DevExpress.XtraGrid.Columns.GridColumn c in gridView1.Columns)
            {
                string tag = c.Tag == null ? "" : c.Tag.ToString();
                if (tag.Contains("+") && tag.Length == 1)
                {
                    c.Visible = true;
                }
                else if (tag.Contains("+") && !tag.Contains(kd.ToLower()))
                {
                    c.Visible = true;
                }
                else if (tag.Contains(kd))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> result = ((List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC>)gridControl1.DataSource).FindAll(item => item.IsSelected);
                List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC> sonhal = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC>();

                foreach (AvukatProLib.Arama.per_AV001_TDI_BIL_GEMI_UCAK_ARAC gm in result)
                {
                    TList<NN_DAVA_GEMI_UCAK_ARAC> guaDavaList = BelgeUtil.Inits.GemiUcakAracGetirByIdFromNNDava(gm.ID);
                    string mesaj = "";
                    if (guaDavaList != null && guaDavaList.Count > 0)
                    {
                        string msg = "";
                        foreach (NN_DAVA_GEMI_UCAK_ARAC d in guaDavaList)
                        {
                            var davaFoy = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_DosyaBilgileris.Single(vi => vi.ID == d.DAVA_FOY_ID);
                            msg += String.Format("Dosya No: {1} , Adliye : {0} {4} {5} , Esas No: {2} {3}", davaFoy.ADLIYE, davaFoy.FOY_NO, davaFoy.ESAS_NO, Environment.NewLine, davaFoy.NO, davaFoy.GOREV);
                        }
                        mesaj += gm.ID + " Sistem numaralý arac daha önce aþaðýda bulunan dava dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg;
                    }

                    TList<NN_ICRA_GEMI_UCAK_ARAC> guaIcraList = BelgeUtil.Inits.GemiUcakAracGetirByIdFromNNIcra(gm.ID);
                    if (guaIcraList != null && guaIcraList.Count > 0)
                    {
                        string msg = "";
                        foreach (NN_ICRA_GEMI_UCAK_ARAC d in guaIcraList)
                        {
                            var icraFoy = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_DosyaBilgileris.Single(item => item.ID == d.ICRA_FOY_ID);
                            msg += String.Format("Dosya No: {1} , Müdürlük : {0} {4} {5} , Esas No: {2} {3}", icraFoy.ADLIYE ?? "", icraFoy.FOY_NO, icraFoy.ESAS_NO, Environment.NewLine, icraFoy.NO ?? "", icraFoy.GOREV ?? "");
                        }
                        mesaj += (gm.ID + " Sistem numaralý arac daha önce aþaðýda bulunan icra dosya(sýn/larýn) da kullanýlmýþtýr." + Environment.NewLine + msg);
                    }
                    if (DataRepository.NN_SIKAYET_NEDEN_GEMI_UCAK_ARACProvider.GetByGEMI_UCAK_ARAC_ID(gm.ID).Count > 0)
                    {
                        mesaj += (gm.ID + " Sistem numaralý arac daha önceden bir soruþturma dosyasýnda kullanýlmýþtýr.");
                    }
                    if (string.IsNullOrEmpty(mesaj))
                        sonhal.Add(gm);
                    else
                    {
                        System.Windows.Forms.DialogResult dr = MessageBox.Show(mesaj + Environment.NewLine + "Eklemek istediðinize eminmisiniz ?", "Dikkat", MessageBoxButtons.YesNo);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            sonhal.Add(gm);
                        }
                    }
                }

                selectedList = sonhal;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}