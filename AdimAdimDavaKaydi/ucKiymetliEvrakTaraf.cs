using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi
{
    public partial class ucKiymetliEvrakTaraf : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> myDataSource;

        public ucKiymetliEvrakTaraf()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucKiymetliEvrakTaraf_Load;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> MyDataSource
        {
            get
            {
                if (vGridControl1 != null)
                {
                    if (vGridControl1.DataSource is TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>)
                        return (TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>)vGridControl1.DataSource;
                }
                return null;
            }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    if (vGridControl1 != null)
                        vGridControl1.DataSource = value;
                    else
                        myDataSource = value;
                }
            }
        }

        public void Refresh()
        {
            if (vGridControl1 != null) vGridControl1.Refresh();
        }

        private void rlueTaraf_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
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
                                               BelgeUtil.Inits.perCariGetir(rlueTaraf);
                                           }
                                       };
            }
        }

        private void rlueTaraf_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();

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
                                               BelgeUtil.Inits.perCariGetir(rlueTaraf);
                                           }
                                       };
            }
        }

        private void ucKiymetliEvrakTaraf_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            BelgeUtil.Inits.perCariGetir(rlueTaraf);
            BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rLueTarafTip);
            MyDataSource = myDataSource;
        }
    }
}