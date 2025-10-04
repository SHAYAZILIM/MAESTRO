using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIlamTarafBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucIlamTarafBilgileri()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_ILAM_MAHKEMESI_TARAF> MyDaTaSource
        {
            get { return (TList<AV001_TI_BIL_ILAM_MAHKEMESI_TARAF>)vgAlacakNedenTaraf.DataSource; }
            set
            {
                if (value != null)
                {
                    this.vgAlacakNedenTaraf.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    //value.ListChanged += new ListChangedEventHandler(value_ListChanged);
                }
            }
        }

        private void initData()
        {
            BelgeUtil.Inits.perCariGetir(rlkTarafCari);
            BelgeUtil.Inits.TarafSifatGetir(rlkTarafSifat);
            BelgeUtil.Inits.TarafKoduGetir(rlkTarafKodu);
        }

        private void ucIlamTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            initData();
        }

        private frmCariGenelGiris cari = new frmCariGenelGiris();

        private void rlkTarafCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;

                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;
                if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
                {
                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karşı_Taraf);
                    //cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   //Inits.perCariGetirRefresh();
                                                   BelgeUtil.Inits.perCariGetir(rlkTarafCari);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rlkTarafCari_ProcessNewValue(object sender,
                                                  DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
                if (lue.Text != string.Empty)
                {
                    cari = new frmCariGenelGiris();
                    cari.tmpCariAd = lue.Text;

                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karşı_Taraf);
                    //cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   //Inits.perCariGetirRefresh();
                                                   BelgeUtil.Inits.perCariGetir(rlkTarafCari);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}