using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rFrmTumDosyalar : Util.BaseClasses.AvpXtraForm
    {
        public rFrmTumDosyalar()
        {
            InitializeComponent();
        }

        public List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu> MyDataSource =
            new List<AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu>();

        public AdimAdimDavaKaydi.UserControls.ucKurumsalGiris.AcilisModu AcilisModu
        {
            get { return ucKurumsalGiris1.Acilis; }
            set { ucKurumsalGiris1.Acilis = value; }
        }

        public void TumDosyalarDoldur()
        {
            if (MyDataSource == null)
                MyDataSource = AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu.GetAll();
            ucKurumsalGiris1.MyDataSource = MyDataSource;
        }

        private void rFrmTumDosyalar_Load(object sender, EventArgs e)
        {
            TumDosyalarDoldur();
        }
    }
}