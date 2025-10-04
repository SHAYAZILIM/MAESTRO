using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmAlacakNedenTaraf : Util.BaseClasses.AvpXtraForm
    {
        public rFrmAlacakNedenTaraf()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmAlacakNedenTaraf_Load;
            this.FormClosed += rFrmAlacakNedenTaraf_FormClosed;
            this.FormClosing += rFrmAlacakNedenTaraf_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn Column { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_ALACAK_NEDEN_TARAF GelenTaraf { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmAlacakNedenTaraf_Button_Kaydet_Click;
        }

        public void Show(AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf)
        {
            GelenTaraf = taraf;
            bndAlacakNedenTaraf.DataSource = taraf;
            vGridControl1.DataSource = bndAlacakNedenTaraf;
            dataNavigatorExtended1.DataSource = bndAlacakNedenTaraf;
            this.Show();
        }

        public DialogResult ShowDialog(AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf)
        {
            GelenTaraf = taraf;
            bndAlacakNedenTaraf.DataSource = taraf;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        private bool CikabilirMi()
        {
            if (GelenTaraf.ChangedProperties.Count > 0)
            {
                if (GelenTaraf.IsPropertyChanged(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TEBLIG_TARIHI))
                    return false;
                if (GelenTaraf.IsPropertyChanged(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.TEMERRUT_TARIHI))
                    return false;
                if (GelenTaraf.IsPropertyChanged(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.ZAMAN_ASIMI_TARIHI))
                    return false;
                if (GelenTaraf.IsPropertyChanged(AV001_TI_BIL_ALACAK_NEDEN_TARAFColumn.IHTAR_TARIHI))
                    return false;
            }

            return true;
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vGridControl1.Visible)
            {
                gcAlacakNedenTaraf.Visible = true;
                vGridControl1.Visible = false;
                gcAlacakNedenTaraf.BringToFront();
            }
            else if (gcAlacakNedenTaraf.Visible)
            {
                gcAlacakNedenTaraf.Visible = false;
                vGridControl1.Visible = true;
                vGridControl1.BringToFront();
            }
        }

        private void GeriAl()
        {
            GelenTaraf.CancelChanges();
        }

        private void rFrmAlacakNedenTaraf_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                GelenTaraf.AcceptChanges();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show
                    ("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayýt",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rFrmAlacakNedenTaraf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;
            ucIcraTarafGelismeleri.NedenTarafUzerindekileriHesapla(MyGelisme, MyFoy);
        }

        private void rFrmAlacakNedenTaraf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CikabilirMi())
            {
                DialogResult dr =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmedi.Çýkmak istediðinizden emin misiniz ?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GeriAl();
                }
                else
                    e.Cancel = true;
            }
        }

        private void rFrmAlacakNedenTaraf_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.perCariGetir(rLueCari);
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();
                DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.Save(trans, GelenTaraf);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                return false;
            }
            return true;
        }
    }
}