using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaNedenTaraf : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSorusturmaNedenTaraf()
        {
            InitializeComponent();
        }

        public TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF> MyDataSource
        {
            get
            {
                if (vgSorusturmaNedenTaraf.DataSource is TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>)
                    return (TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN_TARAF>)vgSorusturmaNedenTaraf.DataSource;
                else
                    return null;
            }
            set { vgSorusturmaNedenTaraf.DataSource = value; }
        }

        private void rLueTarafCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmCariGenelGiris cari = new frmCariGenelGiris();
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                // cari.Statuler.Add(AvukatProLib.Extras.CariStatu.);
                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetirRefresh(rLueTarafCari);
                                           }
                                       };
            }
        }

        private void rLueTarafCari_ProcessNewValue(object sender,
                                                   DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            frmCariGenelGiris cari = new frmCariGenelGiris();
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.Text != string.Empty)
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetirRefresh(rLueTarafCari);
                                           }
                                       };
            }
        }

        private void ucSorusturmaNedenTaraf_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                rLueSikayetNeden.NullText = "Seç";
                rLueTarafSifat.NullText = "Seç";
                rLueTarafCari.NullText = "Seç";
                rLueSikayetNeden.Enter += delegate { BelgeUtil.Inits.SikayetNedenGetir(rLueSikayetNeden); };
                rLueTarafSifat.Enter += delegate { BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat); };
                rLueTarafCari.Enter += delegate { BelgeUtil.Inits.perCariGetir(rLueTarafCari); };
            }
        }
    }
}