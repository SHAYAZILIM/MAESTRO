using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public partial class ucAntetKaydet : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAntetKaydet()
        {
            InitializeComponent();
            rChkAvukatlar.EditValueChanged += rChkAvukatlar_EditValueChanged;
            rChkAvukatlar.CloseUp += rChkAvukatlar_CloseUp;
        }

        public string secilenAvukatlarIsimleri = string.Empty;

        private TList<AV001_TDI_BIL_CARI> avukatlar = new TList<AV001_TDI_BIL_CARI>();

        [Browsable(false)]
        public TList<AV001_TDI_BIL_ANTET> MyDataSource
        {
            get
            {
                if (vGridAntetKayit.DataSource is TList<AV001_TDI_BIL_ANTET>)
                    return (TList<AV001_TDI_BIL_ANTET>)vGridAntetKayit.DataSource;
                return null;
            }
            set
            {
                vGridAntetKayit.DataSource = value;
                dataNavigatorExtended1.DataSource = value;

                //if (value != null)
                //    value.AddingNew += new AddingNewEventHandler(value_AddingNew);
            }
        }

        private void rChkAvukatlar_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //Close Up olayý Seçim YAPILSIN
            //rChkAvukatlar

            for (int i = 0; i < rChkAvukatlar.Items.Count; i++)
            {
                if (rChkAvukatlar.Items[i].CheckState == CheckState.Checked)
                {
                    secilenAvukatlarIsimleri += rChkAvukatlar.Items[i].Description + ",";
                }
            }
        }

        private void rChkAvukatlar_EditValueChanged(object sender, EventArgs e)
        {
            //rChkAvukatlar
            //EditValueChanged Olayý
            //SEÇÝM YAPILSIN .

            for (int i = 0; i < rChkAvukatlar.Items.Count; i++)
            {
                if (rChkAvukatlar.Items[i].CheckState == CheckState.Checked)
                {
                    secilenAvukatlarIsimleri += rChkAvukatlar.Items[i].Description + ",";
                }
            }
        }

        private void rpicAntetLogo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is byte[])
            {
                e.NewValue = ResimAraclari.ResmiBoyutlandir(e.NewValue as byte[], new Size(149, 49));
            }
        }

        private void ucAntetKaydet_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            rpicAntetLogo.EditValueChanging += rpicAntetLogo_EditValueChanging;

            BelgeUtil.Inits.KullaniciListesiGetir(rLueKullaniciID);
            BelgeUtil.Inits.YaziStilGetir(rLueStilYaziFont);
            avukatlar = DataRepository.AV001_TDI_BIL_CARIProvider.Find("AVUKAT_MI='true'");
            rChkAvukatlar.DataSource = avukatlar;
            rChkAvukatlar.DisplayMember = "AD";
            rChkAvukatlar.ValueMember = "ID";

            //rChkAvukatlar
        }
    }
}