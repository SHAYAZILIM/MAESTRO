using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIhtiyatiTedbirTaraf : DevExpress.XtraEditors.XtraUserControl
    {
        private AV001_TI_BIL_FOY myIcraFoy;

        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                if (value != null)
                {
                    myIcraFoy = value;
                    mrowIcra.Visible = true;
                    mrowDava.Visible = false;
                    BelgeUtil.Inits.TarafSifatGetir(rlkSifatDavaId);
                    BelgeUtil.Inits.ItirazSonucuGetir(rlkItirazSonucId);
                    BelgeUtil.Inits.FoyTarafGetir(new[] { rlkCariDavaId }, MyIcraFoy);
                }
            }
        }

        private AV001_TD_BIL_FOY myDavaFoy;

        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                if (value != null)
                {
                    myDavaFoy = value;
                    mrowDava.Visible = true;
                    mrowIcra.Visible = false;
                    BelgeUtil.Inits.TarafSifatGetir(rlkSifatDavaId);
                    BelgeUtil.Inits.ItirazSonucuGetir(rlkItirazSonucId);
                    BelgeUtil.Inits.FoyTarafGetir(new[] { rlkCariDavaId }, MyDavaFoy);
                }
            }
        }

        //<YY-20090619>
        //Klasör ile ilgili yapýlan iþlemler için eklenmiþtir.
        public bool KlasorIcin
        {
            get { return MyProje != null; }
        }

        private AV001_TDIE_BIL_PROJE _MyProje;

        /// <summary>
        /// Usercontrol bir proje için iþlev gerçekleþtiriyor ise kullanýlacak property.
        /// </summary>
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                _MyProje = value;
                if (_MyProje != null)
                {
                    mrowIcra.Visible = true;
                    mrowDava.Visible = false;
                    BelgeUtil.Inits.TarafSifatGetir(rlkSifatDavaId);
                    BelgeUtil.Inits.ItirazSonucuGetir(rlkItirazSonucId);
                    BelgeUtil.Inits.ProjeTarafGetir(_MyProje, rlkCariDavaId);

                    dataNavigatorExtended1.Buttons.Append.Visible = true;
                }
            }
        }

        //</YY-20090619>
        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF> MyDataSource
        {
            get
            {
                if (vgIhtiyatiTedbirTaraf.DataSource != null)
                    return (TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>)vgIhtiyatiTedbirTaraf.DataSource;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    vgIhtiyatiTedbirTaraf.DataSource = value;
                    dataNavigatorExtended1.DataSource = value;
                    gridControl1.DataSource = vgIhtiyatiTedbirTaraf.DataSource;
                }
            }
        }

        public ucIhtiyatiTedbirTaraf()
        {
            InitializeComponent();
        }

        private void ucIhtiyatiTedbirTaraf_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && AvukatProLib.Kimlik.DesignMode)
            {
                try
                {
                    //if (MyIcraFoy != null)

                    BelgeUtil.Inits.TarafSifatGetir(rlkSifatDavaId);
                    //Inits.ItirazSebebiGetir(rlkCariId);
                    BelgeUtil.Inits.ItirazSonucuGetir(rlkItirazSonucId);

                    BelgeUtil.Inits.IcraItirazSonucGetir(rlkItirazSonucId);
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                vgIhtiyatiTedbirTaraf.Visible = true;
            }
            else
            {
                gridControl1.Visible = true;
                vgIhtiyatiTedbirTaraf.Visible = false;
            }
        }


        private void rlkCariDavaId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                                               BelgeUtil.Inits.perCariGetir(rlkCariDavaId);
                                           }
                                       };
            }
        }

        private void rlkCariDavaId_ProcessNewValue(object sender,
                                                   DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.Text != string.Empty)
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();
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
                                               BelgeUtil.Inits.perCariGetir(rlkCariDavaId);
                                           }
                                       };
            }
        }
    }
}