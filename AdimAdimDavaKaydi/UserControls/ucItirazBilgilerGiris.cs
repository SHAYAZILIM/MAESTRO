using System;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucItirazBilgilerGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucItirazBilgilerGiris()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> MyDataSource
        {
            get
            {
                if (exGridItirazGiris.DataSource is TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>)
                    return (TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>)exGridItirazGiris.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    if (exGridItirazGiris != null)
                    {
                        exGridItirazGiris.DataSource = value;
                        extendedGridControl1.DataSource = exGridItirazGiris.DataSource;
                    }
                }

                exGridItirazGiris.DataSource = value;
                extendedGridControl1.DataSource = exGridItirazGiris.DataSource;
            }
        }

        private void ucItirazBilgilerGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.AlacakNEdenGetir(rLueAlacakNeden);
            BelgeUtil.Inits.perCariGetir(rLueItirazEdenCARI);
            BelgeUtil.Inits.ItirazSebebiGetir(rLueItirazSebeb);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.ItirazGiderilmeYol(rLueItirazGiderilmeYol);
            BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonuc);
            //Inits.TarihAlaniAyarla(repositoryItemDateEdit1);
            //rLueItirazBeyanSekli
            BelgeUtil.Inits.ItirazBeyanSekliGetir(rLueItirazBeyanSekli);

            exGridItirazGiris.ButtonCevirClick += exGridItirazGiris_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridItirazGiris_ButtonCevirClick;
        }

        private void exGridItirazGiris_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridItirazGiris.Visible)
            {
                exGridItirazGiris.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridItirazGiris.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void exGridItirazGiris_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;
            else if (e.Button.Tag.ToString() == "FormAc")
            {
                IcraTakipForms.rFrmItiraz ItirazKayit = new AdimAdimDavaKaydi.IcraTakipForms.rFrmItiraz();
                //ItirazKayit.MdiParent = null;
                ItirazKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                ItirazKayit.AddNewList = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                ItirazKayit.IsModul = true;
                ItirazKayit.Show();
            }
        }
    }
}