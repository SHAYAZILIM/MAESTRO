using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTebligatKonu : Form
    {
        public frmTebligatKonu()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmTebligatKonu_Load);
        }

        public void Show(string konu)
        {
            bndKonu.AddNew();
            (bndKonu.Current as TDI_KOD_TEBLIGAT_KONU).KONU = konu.ToUpper();
            this.Show();
        }

        private void bndKonu_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDI_KOD_TEBLIGAT_KONU konu = new TDI_KOD_TEBLIGAT_KONU();

            konu.MODUL = 1;
            konu.KONTROL_NE_ZAMAN = DateTime.Now;
            konu.KONTROL_KIM = "AVUKATPRO";
            konu.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            konu.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            konu.STAMP = AvukatProLib.Kimlik.DefaultStamp;

            konu.ColumnChanged += new TDI_KOD_TEBLIGAT_KONUEventHandler(konu_ColumnChanged);

            e.NewObject = konu;
        }

        private void frmTebligatKonu_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.TebligatAnaTurGetir(lueAnaTur);
            BelgeUtil.Inits.AdliBirimBolumGetir(lueAdliBirimBolum);
        }

        private void konu_ColumnChanged(object sender, TDI_KOD_TEBLIGAT_KONUEventArgs e)
        {
            TDI_KOD_TEBLIGAT_KONU konu = sender as TDI_KOD_TEBLIGAT_KONU;

            if (e.Column == TDI_KOD_TEBLIGAT_KONUColumn.ADLI_BIRIM_BOLUM_ID)
            {
                var bolum = DataRepository.TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetByID((int)e.Value);
                konu.ADLI_BIRIM_BOLUM_KOD = bolum.KOD;
            }
            else if (e.Column == TDI_KOD_TEBLIGAT_KONUColumn.ANA_TUR_ID)
            {
                BelgeUtil.Inits.TebligatAltTurGetir(lueAltTur);
                (lueAltTur.Properties.DataSource as TList<TDI_KOD_TEBLIGAT_ALT_TUR>).FindAll(vi => vi.ANA_TUR_ID == (int)e.Value);
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.Save(tran, bndKonu.Current as TDI_KOD_TEBLIGAT_KONU);
                tran.Commit();
                MessageBox.Show("Kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BelgeUtil.Inits._TebligatKonuGetir.Add(bndKonu.Current as TDI_KOD_TEBLIGAT_KONU);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen) tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kayıt Yapılamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}