using AvukatProLib.Bakim.Resources;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmKullaniciGruplari : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciGruplari()
        {
            InitializeComponent();
        }

        private TList<CS_KOD_KULLANICI_GRUP> _MyDataSource;

        private CS_KOD_KULLANICI_GRUP _MyGrup;

        private CS_KOD_KULLANICI_GRUP grup = new CS_KOD_KULLANICI_GRUP();

        private string KýsaAd = string.Empty;

        private TDI_BIL_KULLANICI_LISTESI klist = new TDI_BIL_KULLANICI_LISTESI();

        private int s, KullaniciID, KullaniciGrupID = 0;

        public TList<CS_KOD_KULLANICI_GRUP> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                tlistKullaniciGrup.DataSource = value;
            }
        }

        public CS_KOD_KULLANICI_GRUP MyGrup
        {
            get
            {
                return _MyGrup;
            }
            set
            {
                _MyGrup = value;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                if (klist != null)
                {
                    KullaniciGrupID = (int)klist.KULLANICI_GRUP_ID;
                    KullaniciID = (int)klist.ID;

                    if (s != KullaniciGrupID)
                    {
                        DialogResult dr;
                        if (KýsaAd != string.Empty)
                            dr = XtraMessageBox.Show("Bu Kullanici " + KýsaAd + " Grubuna Atanmýþ Deðiþtirmek Ýstiyormusunuz!!", "Bilgilendirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        else
                            dr = DialogResult.OK;

                        if (dr == DialogResult.OK)
                        {
                            trans.BeginTransaction();
                            klist.KULLANICI_GRUP_ID = s;
                            klist.GRUP_KISA_ADI = Inits.GrupKýsaAdiGetir(s);
                            NN_KULLANICI_GRUP kgrup = new NN_KULLANICI_GRUP();
                            kgrup.KULLANICI_ID = (int)klist.ID;
                            kgrup.KULLANICI_GRUP_ID = s;

                            DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Save(trans, klist);
                            DataRepository.NN_KULLANICI_GRUPProvider.Save(trans, kgrup);
                            XtraMessageBox.Show("Kayýt Baþarýyla Gerçekleþti ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            trans.Commit();
                        }
                    }
                }
            }
            catch
            {
                if (trans.IsOpen)
                    trans.Rollback();
                XtraMessageBox.Show("Kayýt Gerçekleþmedi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            TDI_BIL_KULLANICI_LISTESI row = (TDI_BIL_KULLANICI_LISTESI)gridView1.GetFocusedRow();
            TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                if (row != null)
                {
                    DialogResult dr = XtraMessageBox.Show("Bu Kullaniciyi Grubdan Kaldýrmak Ýstiyormusunuz!!", "Bilgilendirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        trans.BeginTransaction();
                        NN_KULLANICI_GRUP kg = DataRepository.NN_KULLANICI_GRUPProvider.GetByKULLANICI_ID(row.ID)[0];
                        DataRepository.NN_KULLANICI_GRUPProvider.Delete(trans, kg);
                        XtraMessageBox.Show("Grubtan Kaldýrma Ýþlemi Baþarýyla Gerçekleþti ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        trans.Commit();
                    }
                }
            }
            catch
            {
                if (trans.IsOpen)
                    trans.Rollback();
                XtraMessageBox.Show("Grubtan Kaldýrma Ýþlemi Gerçekleþmedi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmKullaniciGruplari_Load(object sender, EventArgs e)
        {
            Inits.KullaniciGetir(lueKullanici);
            MyDataSource = DataRepository.CS_KOD_KULLANICI_GRUPProvider.GetAll();
        }

        private void lueKullanici_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                klist = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByID((int)e.NewValue);

                TList<NN_KULLANICI_GRUP> kg = DataRepository.NN_KULLANICI_GRUPProvider.GetByKULLANICI_ID((int)klist.ID);
                if (kg.Count > 0)
                {
                    grup = DataRepository.CS_KOD_KULLANICI_GRUPProvider.Find("ID = " + kg[0].KULLANICI_GRUP_ID.ToString())[0];
                    KýsaAd = grup.KISA_ADI;
                }
            }
        }

        private void mItemSil_Click(object sender, EventArgs e)
        {
        }

        private void tlistKullaniciGrup_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            s = (int)tlistKullaniciGrup.FindNodeByID(e.Node.Id).GetValue(0);

            TList<NN_KULLANICI_GRUP> KullanýcýIDlist = DataRepository.NN_KULLANICI_GRUPProvider.Find("KULLANICI_GRUP_ID = " + s.ToString());
            TList<TDI_BIL_KULLANICI_LISTESI> kullist = new TList<TDI_BIL_KULLANICI_LISTESI>();
            foreach (NN_KULLANICI_GRUP var in KullanýcýIDlist)
            {
                klist = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.Find("ID = " + var.KULLANICI_ID)[0];
                kullist.Add(klist);
            }
            grdKullaniciList.DataSource = kullist;
        }
    }
}