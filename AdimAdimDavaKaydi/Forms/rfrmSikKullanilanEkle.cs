using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class rfrmSikKullanilanEkle : Util.BaseClasses.AvpXtraForm
    {
        public rfrmSikKullanilanEkle()
        {
            InitializeComponent();
            this.Load += rfrmSikKullanilanEkle_Load;
        }

        private TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI> MyKullanilan =
            new TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI>();

        public static event EventHandler<SikKullanilanEventArgs> Yenile;

        public event EventHandler<SikKullanilanEventArgs> SikKullanilanKaydedildi;

        public int KayitId { get; set; }

        public AvukatProLib.Extras.ModulTip ModulTipi { get; set; }

        public List<TreeListNode> GetCheckedNode(TreeListNodes nodes)
        {
            List<TreeListNode> secilenler = new List<TreeListNode>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Checked)
                    secilenler.Add(nodes[i]);

                if (nodes[i].Nodes.Count > 0)
                {
                    secilenler.AddRange(GetCheckedNode(nodes[i].Nodes));
                }
            }

            return secilenler;
        }

        public bool KayitVarmi(byte Modul, int KayitId)
        {
            bool b = true;

            TList<AV001_TDIE_BIL_SIK_KULLANILAN> SikKullanilanList =
                DataRepository.AV001_TDIE_BIL_SIK_KULLANILANProvider.GetByKontrol(Modul, KayitId);
            if (SikKullanilanList.Count > 0)
            {
                b = false;
            }
            else
            {
                b = true;
            }

            return b;
        }

        internal void Show(AvukatProLib.Extras.ModulTip modulTip, int kayitId, string kayitAdi)
        {
            ModulTipi = modulTip;
            KayitId = kayitId;
            txtAdi.Text = kayitAdi;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        internal void ShowDialog(AvukatProLib.Extras.ModulTip modulTip, int kayitId,
                                 string kayitAdi)
        {
            ModulTipi = modulTip;
            KayitId = kayitId;
            txtAdi.Text = kayitAdi;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void rfrmSikKullanilanEkle_Load(object sender, EventArgs e)
        {
            TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI> Kullanilan =
                DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);

            foreach (AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI item in Kullanilan)
            {
                if (item.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID)
                    MyKullanilan.Add(item);
            }

            treeList1.DataSource = MyKullanilan;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "UST_KATEGORI_ID";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI kategori = new AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI();
            kategori.ADI = txtKategoriAdi.Text;
            kategori.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
            kategori.KAYIT_TARIHI = DateTime.Now;
            if (treeList1.DataSource is TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI>)
            {
                List<TreeListNode> secilenler = GetCheckedNode(treeList1.Nodes);

                if (secilenler.Count == 1)
                {
                    if (treeList1.GetDataRecordByNode(secilenler[0]) is AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI)
                    {
                        AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI ustKategori =
                            treeList1.GetDataRecordByNode(secilenler[0]) as AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI;
                        kategori.UST_KATEGORI_ID = ustKategori.ID;
                    }
                }

                //TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI> secilen = treeList1.DataSource as TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI>;
                //secilen.Add(kategori);

                //treeList1.Refresh();
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            trans.BeginTransaction();
            try
            {
                DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.DeepSave(trans, kategori);
            }

            catch 
            {
                if (trans.IsOpen)
                    trans.Rollback();
            }

            trans.Commit();

            TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI> Kullanilan =
                DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);
            MyKullanilan = Kullanilan;

            //foreach (BIRLESIK_SIK_KULLANILANLAR item in Kullanilan)
            //{
            //    if (item.KULLANICI_ID == AvukatProLib.Kimlik.Bilgi.ID)
            //        MyKullanilan.Add(item);
            //}

            treeList1.DataSource = MyKullanilan;

            treeList1.Refresh();

            treeList1.ExpandAll();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AV001_TDIE_BIL_SIK_KULLANILAN kullanilan = new AV001_TDIE_BIL_SIK_KULLANILAN();

            kullanilan.ACIKLAMA = txtAciklama.Text;
            kullanilan.ADI = txtAdi.Text;

            kullanilan.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;

            List<TreeListNode> secilenKategoriler = GetCheckedNode(treeList1.Nodes);

            if (secilenKategoriler.Count == 1)
            {
                object o = treeList1.GetDataRecordByNode(secilenKategoriler[0]);
                if (o is AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI)
                {
                    AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI kategori = o as AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI;

                    kullanilan.KATEGORI_ID = kategori.ID;
                }
                else
                {
                    XtraMessageBox.Show("Lütfen Bir Kategori Seçiniz", "Dikkat", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Lütfen Bir Kategori Seçiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kullanilan.MODUL = (byte)ModulTipi;
            kullanilan.KAYIT_ID = KayitId;
            kullanilan.KAYIT_TARIHI = DateTime.Now;

            TransactionManager tm = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            tm.BeginTransaction();

            try
            {
                if (KayitVarmi((byte)ModulTipi, KayitId))
                {
                    DataRepository.AV001_TDIE_BIL_SIK_KULLANILANProvider.DeepSave(tm, kullanilan,
                                                                                  DeepSaveType.IncludeChildren,
                                                                                  typeof(AV001_TDIE_BIL_SIK_KULLANILAN));

                    tm.Commit();
                    if (SikKullanilanKaydedildi != null)
                        SikKullanilanKaydedildi(this, new SikKullanilanEventArgs(kullanilan));

                    if (Yenile != null)
                        Yenile(this, new SikKullanilanEventArgs(kullanilan));
                    XtraMessageBox.Show("Kayıt Başarı İle Gerçekleşti", "İşlem Tamamlandı", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Bu Kayit Daha Önce Eklenmiş..", "UYARI", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
            catch 
            {
                if (tm.IsOpen)
                    tm.Rollback();
                XtraMessageBox.Show("Kayıt Esnasında Hata Oluştu", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}