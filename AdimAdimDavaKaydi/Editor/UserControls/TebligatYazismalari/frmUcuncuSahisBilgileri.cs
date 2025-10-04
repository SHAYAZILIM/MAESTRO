using AdimAdimDavaKaydi.Editor.UserControls.TebligatYazismalari;
using AdimAdimDavaKaydi.Forms;
using AvukatProDegiskenler.Icra;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

//using AdimAdimDavaKaydi.Editor.Degiskenler.Util;

namespace ImportExportWithSelection.Import
{
    public partial class frmUcuncuSahisBilgileri : DevExpress.XtraEditors.XtraForm
    {
        public frmUcuncuSahisBilgileri()
        {
            InitializeComponent();
        }

        private AV001_TI_BIL_FOY gelenFoy = new AV001_TI_BIL_FOY();

        private TList<AV001_TDI_BIL_TEBLIGAT> gelenTebHacizIhb = new TList<AV001_TDI_BIL_TEBLIGAT>();

        public TList<AV001_TDI_BIL_CARI_ALT> MyDataSource
        {
            get { return this.ucCariArama1.MyDataSource; }
            set { this.ucCariArama1.MyDataSource = value; }
        }

        public List<AvukatProDegiskenler.Icra.CariGrup> SeciliCariler { get; set; }

        public void Show(TList<AV001_TDI_BIL_TEBLIGAT> gelenTebligat, AV001_TI_BIL_FOY mFoy)
        {
            gelenTebHacizIhb = gelenTebligat;
            gelenFoy = mFoy;
            this.Show();
        }

        private void bbtnBankaSubelerinden_Click(object sender, EventArgs e)
        {
            //BANKA ÞUBELERÝNDEN AL
            frmBankaSubeSecForAltCari frmBankaSubeSec = new frmBankaSubeSecForAltCari();
            frmBankaSubeSec.Show(gelenTebHacizIhb, gelenFoy.ID);
            frmBankaSubeSec.FormClosing += frmBankaSubeSec_FormClosing;
        }

        private void bbtnCarilerden_Click(object sender, EventArgs e)
        {
            frmCariSec cariler = new frmCariSec();

            //cariler.MdiParent = null;
            cariler.StartPosition = FormStartPosition.WindowsDefaultLocation;
            cariler.Show(gelenTebHacizIhb, gelenFoy);
            cariler.FormClosing += frmBankaSubeSec_FormClosing;
            return;

            //if (cariler.SeciliCariler == null)
            //{
            //    return;
            //}

            //var list = cariler.SeciliCariler;
            //TList<AV001_TDI_BIL_CARI> carilerim = new TList<AV001_TDI_BIL_CARI>();
            //foreach (var item in list)
            //{
            //    carilerim.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.ID));
            //}
            //foreach (var carim in carilerim)
            //{
            //    if (MyDataSource == null)
            //        MyDataSource = new TList<AV001_TDI_BIL_CARI_ALT>();
            //    this.MyDataSource.Add(getcariAlt(carim));
            //}
        }

        private void bbtnTamam_Click(object sender, EventArgs e)
        {
            //TAMAM ÝÞLEMÝ KAYDET
            if (MyDataSource == null) return;
            for (int i = 0; i < this.MyDataSource.Count; i++)
            {
                if (this.MyDataSource[i].UST_CARI_ID.HasValue)
                {
                    CariGrup cg = VarmiSeciliCarilerde(this.MyDataSource[i].UST_CARI_ID.Value);
                    if (cg != null)
                    {
                        cg.AltindakiCariler.Add(this.MyDataSource[i]);
                    }
                    else
                    {
                        cg = new CariGrup();
                        cg.Cari = new AV001_TDI_BIL_CARI();
                        cg.Cari.ID = this.MyDataSource[i].UST_CARI_ID.Value;
                        cg.AltindakiCariler = new TList<AV001_TDI_BIL_CARI_ALT>();
                        cg.AltindakiCariler.Add(this.MyDataSource[i]);
                        SeciliCariler.Add(cg);
                    }
                }
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EXELDEN AL

            frmImportFromExcel<AvukatProLib2.Entities.AV001_TDI_BIL_CARI_ALT> frm =
                new frmImportFromExcel<AvukatProLib2.Entities.AV001_TDI_BIL_CARI_ALT>();

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.ShowDialog(this.ucCariArama1.exGridCariArama);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ÝLETÝÞÝM BÝLGÝLERÝNDEN AL

            frmIletisimBilgilrindenAl frmIletisimBilgileri = new frmIletisimBilgilrindenAl();

            //frmIletisimBilgileri.MdiParent = null;
            frmIletisimBilgileri.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmIletisimBilgileri.Show();
            frmIletisimBilgileri.FormClosing += frmBankaSubeSec_FormClosing;

            if (this.ucCariArama1.MyDataSource != null)
            {
                this.ucCariArama1.MyDataSource.AddRange(frmIletisimBilgileri.SelectedCariAlt);
            }
        }

        #region <MB-20100623>

        //Gridlerde refresh sorunu çözmek için eklendi. (Kullanýcý küçük formu görmeyip, kapatmadýðý için refresh sorunu olduðunu sandýðý için otomatik kapatýlmasý saðlandý.
        private void frmBankaSubeSec_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        #endregion <MB-20100623>

        private AvukatProDegiskenler.Icra.CariGrup VarmiSeciliCarilerde(int CariId)
        {
            if (SeciliCariler == null)
            {
                SeciliCariler = new List<CariGrup>();
            }
            for (int i = 0; i < SeciliCariler.Count; i++)
            {
                if (SeciliCariler[i].Cari.ID == CariId)
                {
                    return SeciliCariler[i];
                }
            }
            return null;
        }
    }
}