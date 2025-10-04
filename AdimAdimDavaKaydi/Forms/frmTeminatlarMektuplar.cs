using System;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTeminatlarMektuplar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmTeminatlarMektuplar()
        {
            InitializeComponent();
        }

        private void frmTeminatlarMektuplar_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.DovizTipGetir(lueDoviz);
            BelgeUtil.Inits.BankaGetir(lueBanka);
            BelgeUtil.Inits.BankaDirekSubeGetir(lueSube);
        }
    }
}