using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTazminat_Ihtiyat_Taraf : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTazminat_Ihtiyat_Taraf()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Klasör üzerinden ekleme yapýldýðýnda true olan property
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KlasorIcin { get; set; }

        private AV001_TI_BIL_FOY myFoy;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null)
                {
                    myFoy = value;
                    BelgeUtil.Inits.FoyTarafGetir(new[] { rlkCariId }, MyFoy);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF> MyDataSource
        {
            get
            {
                //if (gridControl1.DataSource != null)
                return (TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>)gridControl1.DataSource;
                //else
                //    return null;
            }
            set
            {
                //if(value != null)
                //{
                vgIhtiyatiHacizTaraf.DataSource = value;
                gridControl1.DataSource = value;
                extendedGridControl1.DataSource = vgIhtiyatiHacizTaraf.DataSource;

                //}
            }
        }

        private void ucTazminat_Ihtiyat_Taraf_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    gridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;

                    BelgeUtil.Inits.CariSifatGetir(rlkTarafSifat);
                    if (KlasorIcin)
                    {
                        BelgeUtil.Inits.perCariGetir(rlkCariId);
                    }
                    else
                    {
                        BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, (new[] { rlkCariId }));
                    }
                    BelgeUtil.Inits.IcraItirazSonucGetir(rlkItirazSonucId);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Icra, BelgeUtil.Bilesen.BilesenYok);
                }
            }
        }

        private void gridControl1_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridControl1.Visible = true;
                extendedGridControl1.BringToFront();
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridControl1.Visible = false;
                gridControl1.BringToFront();
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                vgIhtiyatiHacizTaraf.Visible = true;
                extendedGridControl1.Visible = false;
            }
            else if (vgIhtiyatiHacizTaraf.Visible)
            {
                gridControl1.Visible = false;
                vgIhtiyatiHacizTaraf.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                vgIhtiyatiHacizTaraf.Visible = false;
                extendedGridControl1.Visible = false;
            }
        }

        private frmCariGenelGiris cari = new frmCariGenelGiris();

        private void rlkCariId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            cari.tmpCariAd = lue.Text;
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();

                // cari.Statuler.Add(AvukatProLib.Extras.CariStatu.);
                // cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rlkCariId);
                                           }
                                       };
            }
        }

        private void rlkCariId_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.Text != string.Empty)
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
                                               BelgeUtil.Inits.perCariGetirRefresh(rlkCariId);
                                           }
                                       };
            }
        }
    }
}