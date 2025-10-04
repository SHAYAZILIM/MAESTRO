using AdimAdimDavaKaydi.Editor.UserControls;
using System;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmRaporKAydet : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmRaporKAydet()
        {
            InitializeComponent();
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmRaporKAydet_Button_Kaydet_Click;
        }

        public ucRaporBilgi Child
        {
            get { return this.ucRaporBilgi1; }
        }

        private void frmRaporKAydet_Button_Kaydet_Click(object sender, EventArgs e)
        {
            this.ucRaporBilgi1.Save();
        }
    }
}