using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmAlacakKontrol : Form
    {
        public frmAlacakKontrol()
        {
            InitializeComponent();
        }

        public KontrolItems KontrolItem = new KontrolItems();

        public Classes.GayriNakitAlacak AktarilanGayrinakitAlacak { get; set; }

        public Classes.NakitAlacak AktarilanNakitAlacak { get; set; }

        public void ShowDialog(Classes.NakitAlacak aktarilanNakitAlacak)
        {
            this.AktarilanNakitAlacak = aktarilanNakitAlacak;

            this.ShowDialog();
        }

        private void frmAlacakKontrol_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.DovizTipGetir(lueTutarParaBirimi);

            if (AktarilanNakitAlacak != null)
            {
                dtVadeTarihi.EditValue = AktarilanNakitAlacak.VadeTarihi;
                spTutar.EditValue = AktarilanNakitAlacak.Tutari;
                spFaizOrani.EditValue = AktarilanNakitAlacak.FaizOrani;
            }
        }

        private void sbtnTamam_Click(object sender, EventArgs e)
        {
            if (dtVadeTarihi.EditValue != null) KontrolItem.VadeTarihi = (DateTime)dtVadeTarihi.EditValue;
            if (spTutar.EditValue != null) KontrolItem.Tutar = (decimal)spTutar.EditValue;
            if (lueTutarParaBirimi.EditValue != null) KontrolItem.TutarParaBirimi = (int)lueTutarParaBirimi.EditValue;
            if (spFaizOrani.EditValue != null) KontrolItem.FaizOrani = Convert.ToDouble(spFaizOrani.EditValue);

            this.Close();
        }

        public class KontrolItems
        {
            public double FaizOrani { get; set; }

            public decimal Tutar { get; set; }

            public int TutarParaBirimi { get; set; }

            public DateTime VadeTarihi { get; set; }
        }
    }
}