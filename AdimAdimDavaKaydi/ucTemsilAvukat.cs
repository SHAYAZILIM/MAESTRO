using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi
{
    public partial class ucTemsilAvukat : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        private AV001_TI_BIL_FOY myFoy;

        public ucTemsilAvukat()
        {
            InitializeComponent();
            this.Load += ucTemsilAvukat_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_TEMSIL_AVUKAT> MyDataSource
        {
            get { return (TList<AV001_TDI_BIL_TEMSIL_AVUKAT>)gridTemsilAvukat.DataSource; }
            set
            {
                if (value != null)
                {
                    gridTemsilAvukat.DataSource = value;
                    extendedGridControl1.DataSource = gridTemsilAvukat.DataSource;
                }
            }
        }

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
                }
            }
        }

        private void gridTemsilAvukat_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridTemsilAvukat.Visible = true;
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridTemsilAvukat.Visible = false;
            }
        }

        private void rlueAvukatCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "AvukatEkle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frm.MyCari != null)
                        {
                            BelgeUtil.Inits._per_CariGetir.Add(BelgeUtil.Inits.GetCariViewItem(frm.MyCari));
                            BelgeUtil.Inits._perCariAvukatGetir.Add(BelgeUtil.Inits.GetCariViewItem(frm.MyCari));
                        }
                    }
                };
            }
        }

        private void ucTemsilAvukat_Load(object sender, EventArgs e)
        {
            //LOAD DA DOLDUR
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.perCariAvukatGetir(rlueAvukatCari);
                gridTemsilAvukat.ButtonCevirClick += gridTemsilAvukat_ButtonCevirClick;
            }

            for (int i = 0; i < rlueAvukatCari.Buttons.Count; i++)
            {
                if (rlueAvukatCari.Buttons[i].Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
                {
                    rlueAvukatCari.Buttons.RemoveAt(i);
                    i = 0;
                }
            }
        }
    }
}