using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeGelismeAdimlari : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeGelismeAdimlari()
        {
            InitializeComponent();
            this.Load += ucSozlesmeGelismeAdimlari_Load;
            grdGelismeAdimlari.ButtonClick += dNExSozlesmeGelismeleri_ButtonClick;
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM> MyDataSource
        {
            get
            {
                if (grdGelismeAdimlari.DataSource is TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM>)
                    return (TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM>)grdGelismeAdimlari.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    grdGelismeAdimlari.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        private void dNExSozlesmeGelismeleri_ButtonClick(object sender,
                                                         DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag == "FormdanEkle")
                {
                    frmSozlesmeGelismeAsamalari frm = new frmSozlesmeGelismeAsamalari();
                    frm.MySozlesme = MySozlesme;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                }
                if (e.Button.Tag == "KayitDuzenle")
                {
                    if (gwGelismeAdimlari.FocusedRowHandle >= 0)
                    {
                        frmSozlesmeGelismeAsamalari frm = new frmSozlesmeGelismeAsamalari();
                        TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM> gelisme =
                            new TList<AV001_TDI_BIL_SOZLESME_GELISME_ADIM>();
                        gelisme.Add(MyDataSource[gwGelismeAdimlari.FocusedRowHandle]);
                        frm.MyDataSource = gelisme;
                        frm.MySozlesme = MySozlesme;

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                    }
                }
            }
        }

        private void ucSozlesmeGelismeAdimlari_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.perCariGetir(rLueTarafCari);
                BelgeUtil.Inits.SozlesmeGelismeAdimGetir(rLueGelismeAdim);
            }
        }
    }
}