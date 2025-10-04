using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTebligatIliskiEkle : Form
    {
        public frmTebligatIliskiEkle()
        {
            InitializeComponent();
        }

        public AV001_TDI_BIL_TEBLIGAT Tebligat { get; set; }

        public void Show(AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            this.Tebligat = tebligat;
            this.Show();
        }

        private void frmTebligatIliskiEkle_Load(object sender, EventArgs e)
        {
            GetTebligatIliskiList();

            gcTebligatList.DataSource = BelgeUtil.Inits.context.TebligatDetays.ToList();
        }

        private void GetTebligatIliskiList()
        {
            List<int> iliskiliTebligatList = BelgeUtil.Inits.context.NN_TEBLIGAT_TEBLIGATs.Where(vi => vi.TEBLIGAT_ID == (Tebligat.ID)).Select(vi => vi.ILISKILI_TEBLIGAT_ID).ToList();
            List<AvukatProLib.Arama.TebligatDetay> list = new List<AvukatProLib.Arama.TebligatDetay>();
            foreach (var item in iliskiliTebligatList)
            {
                list.AddRange(BelgeUtil.Inits.context.TebligatDetays.Where(vi => vi.TEBLIGAT_ID == item));
            }
            gcIliskiliTebligatlar.DataSource = list;
        }

        private void sbtnIliskiKaydet_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.NN_TEBLIGAT_TEBLIGAT> list = new List<AvukatProLib.Arama.NN_TEBLIGAT_TEBLIGAT>();

            foreach (var item in (gcTebligatList.DataSource as List<AvukatProLib.Arama.TebligatDetay>).FindAll(vi => vi.IsSelected))
            {
                AvukatProLib.Arama.NN_TEBLIGAT_TEBLIGAT iliski = new AvukatProLib.Arama.NN_TEBLIGAT_TEBLIGAT();
                iliski.ILISKILI_TEBLIGAT_ID = item.TEBLIGAT_ID.Value;
                iliski.TEBLIGAT_ID = Tebligat.ID;

                list.Add(iliski);
            }
            BelgeUtil.Inits.context.NN_TEBLIGAT_TEBLIGATs.InsertAllOnSubmit(list);
            try
            {
                BelgeUtil.Inits.context.SubmitChanges();
                MessageBox.Show("Kayıt Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetTebligatIliskiList();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kayıt Tamamlanamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}