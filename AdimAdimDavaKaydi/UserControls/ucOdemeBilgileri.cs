using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakip
{
    public partial class ucOdemeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public TList<AV001_TI_BIL_BORCLU_ODEME> MyDataSource
        {
            get
            {
                if (vgOdemeBilgileri.DataSource is TList<AV001_TI_BIL_BORCLU_ODEME>)
                    return (TList<AV001_TI_BIL_BORCLU_ODEME>)vgOdemeBilgileri.DataSource;

                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    vgOdemeBilgileri.DataSource = value;
                }
            }
        }

        public TList<AV001_TDI_BIL_CARI> MyTarafList
        {
            get { return _MyTarafList; }
            set
            {
                if (value != null)
                {
                    BelgeUtil.Inits.OdemeAlacakliTarafByProje(value, rLueCariHepsi);
                    BelgeUtil.Inits.OdemeBorcluTarafByProje(value, rLueBorclular);
                }
                _MyTarafList = value;
            }
        }

        private AV001_TI_BIL_FOY _foy;

        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null && !this.DesignMode)
                {
                    try
                    {
                        //BelgeUtil.Inits.AlacakNedenByFoy(Foy, glueAlacakNeden);
                    }

                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        private TList<AV001_TDI_BIL_CARI> _MyTarafList;

        public ucOdemeBilgileri()
        {
            InitializeComponent();
        }

        private void ucOdemeBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            BelgeUtil.Inits.perCariGetir(rLueCariHepsi);
            BelgeUtil.Inits.perCariGetir(rLueBorclular);
            BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNedenKod);
            BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYeri);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTipi);
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
            BelgeUtil.Inits.perCariGetir(rLueBorcluAdinaOdeyen);
            BelgeUtil.Inits.OdemeKimAdina(rLueOdemeKimAdina);
        }

        private frmCariGenelGiris cari = new frmCariGenelGiris();

        private void rLueBorclular_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
                if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
                {
                    cari = new frmCariGenelGiris();
                    cari.tmpCariAd = lue.Text;

                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                    //cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   BelgeUtil.Inits.perCariGetir(rLueBorclular);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueBorclular_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
                if (lue.Text != string.Empty)
                {
                    cari = new frmCariGenelGiris();
                    cari.tmpCariAd = lue.Text;

                    cari.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);
                    //cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   BelgeUtil.Inits.perCariGetir(rLueBorclular);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueBorcluAdinaOdeyen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                LookUpEdit lue = sender as LookUpEdit;
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
                                                   BelgeUtil.Inits.perCariGetir(rLueBorcluAdinaOdeyen);
                                               }
                                           };
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void rLueBorcluAdinaOdeyen_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            try
            {
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
                                                   BelgeUtil.Inits.perCariGetir(rLueBorcluAdinaOdeyen);
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