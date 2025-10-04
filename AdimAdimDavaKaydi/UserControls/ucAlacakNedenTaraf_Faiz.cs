using System;
using System.Windows.Forms;
using AvukatProLib.Hesap;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.IcraTakip.UserControls
{
    public partial class ucAlacakNedenTaraf_Faiz : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucAlacakNedenTaraf_Faiz()
        {
            InitializeComponent();
        }

        public TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ> DtAlacakNeden
        {
            get { return (TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>)gcAlacakNedenFaiz.DataSource; }
            set
            {
                if (value != null)
                {
                    this.gcAlacakNedenFaiz.DataSource = value;
                    foreach (var item in value)
                    {
                        item.ColumnChanged += item_ColumnChanged;
                    }
                }
            }
        }

        private void item_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = sender as AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ;
            if (e.Column == AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZColumn.FAIZ_TIP_ID)
            {
                faiz.FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, 1, DateTime.Now);
            }
        }

        private void ucAlacakNedenTaraf_Faiz_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.FaizTipiGetir(rlkFaizTipId);
                BelgeUtil.Inits.YuzdeBicimiAyarla(spORan);
            }
        }
    }
}