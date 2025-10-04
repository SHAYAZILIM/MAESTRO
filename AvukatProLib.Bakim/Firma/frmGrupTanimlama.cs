using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AvukatProLib.Bakim.Firma
{
    public partial class frmGrupTanimlama : DevExpress.XtraEditors.XtraForm
    {
        public frmGrupTanimlama()
        {
            InitializeComponent();
        }

        private TList<CS_KOD_KULLANICI_GRUP> _MyDataSource;

        private CS_KOD_KULLANICI_GRUP kgrup = new CS_KOD_KULLANICI_GRUP();

        public TList<CS_KOD_KULLANICI_GRUP> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                vgKullaniciGruplari.DataSource = value;
                dnKullaniciGruplari.DataSource = value;
            }
        }

        public void btnKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Kaydet(kgrup))
            {
                XtraMessageBox.Show("Kullanıcı kaydı başarıyla gerçekleşti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Kayıt işlemi yapılamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool Kaydet(CS_KOD_KULLANICI_GRUP klist)
        {
            TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();
                DataRepository.CS_KOD_KULLANICI_GRUPProvider.DeepSave(trans, klist);
                trans.Commit();
                return true;
            }
            catch 
            {
                if (trans.IsOpen)
                    trans.Rollback();
                return false;
            }
        }

        private void frmGrupTanimlama_Load(object sender, EventArgs e)
        {
            MyDataSource = new TList<CS_KOD_KULLANICI_GRUP>();
            MyDataSource.AddingNew += new AddingNewEventHandler(MyDataSource_AddingNew);
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            CS_KOD_KULLANICI_GRUP tlist = new CS_KOD_KULLANICI_GRUP();
            tlist.STAMP = Kimlikci.Kimlik.DefaultKontrolVersiyon;
            tlist.KONTROL_VERSIYON = Kimlikci.Kimlik.DefaultKontrolVersiyon;
            tlist.ADMIN_KAYIT_MI = true;
            tlist.KONTROL_NE_ZAMAN = DateTime.Now;
            tlist.SUBE_ID = Kimlikci.Kimlik.SubeKodu;
            kgrup = tlist;
            e.NewObject = tlist;
        }
    }
}