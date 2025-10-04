using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmFoyTaraf : Util.BaseClasses.AvpXtraForm
    {
        private AV001_TI_BIL_FOY myFoy;

        private TList<AV001_TI_BIL_FOY_TARAF> result = new TList<AV001_TI_BIL_FOY_TARAF>();

        public frmFoyTaraf()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosed += frmFoyTaraf_FormClosed;
            this.FormClosing += frmFoyTaraf_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueBorcluCari });
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF MyTaraf { get; set; }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmFoyTaraf_Button_Kaydet_Click;
        }

        public void Show(AV001_TI_BIL_FOY_TARAF taraf, AV001_TI_BIL_FOY_TARAF_GELISME gelisme)
        {
            MyGelisme = gelisme;
            MyTaraf = taraf;
            result.Add(MyTaraf);

            dataNavigatorExtended1.DataSource = result;
            vGridControl2.DataSource = dataNavigatorExtended1.DataSource;
            gcFoyTaraf.DataSource = dataNavigatorExtended1.DataSource;

            this.Show();
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_FOY_TARAF taraf in result)
            {
                if (taraf.ChangedProperties.Count > 0)
                {
                    if (taraf.IsPropertyChanged(AV001_TI_BIL_FOY_TARAFColumn.ACIZ_TARIHI))
                        return false;
                    if (taraf.IsPropertyChanged(AV001_TI_BIL_FOY_TARAFColumn.GECICI_REHIN_ACIGI_TARIHI))
                        return false;
                    if (taraf.IsPropertyChanged(AV001_TI_BIL_FOY_TARAFColumn.IBRA_TARIHI))
                        return false;
                    if (taraf.IsPropertyChanged(AV001_TI_BIL_FOY_TARAFColumn.KESIN_REHIN_ACIGI_TARIHI))
                        return false;
                }
            }

            return true;
        }

        private void frmFoyTaraf_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MyTaraf.AcceptChanges();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show
                    ("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayýt",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFoyTaraf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;

            ucIcraTarafGelismeleri.FoyTarafUzerindekileriHesapla(MyGelisme, MyTaraf);
        }

        private void frmFoyTaraf_FormClosing(object sender, FormClosingEventArgs e)
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

        private void GeriAl()
        {
            MyTaraf.CancelChanges();
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOY_TARAFProvider.Save(trans, MyTaraf);

                trans.Commit();

                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
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