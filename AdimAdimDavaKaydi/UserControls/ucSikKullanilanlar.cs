using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSikKullanilanlar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSikKullanilanlar()
        {
            InitializeComponent();
        }

        private VList<BIRLESIK_SIK_KULLANILANLAR> myDataSource;

        [Browsable(false)]
        public VList<BIRLESIK_SIK_KULLANILANLAR> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myDataSource = value;
                    treeList1.DataSource = value;
                    treeList1.ImageIndexFieldName = BIRLESIK_SIK_KULLANILANLARColumn.MODUL.ToString();
                }
            }
        }

        private void ucSikKullanilanlar_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                VList<BIRLESIK_SIK_KULLANILANLAR> MyKullanilan = new VList<BIRLESIK_SIK_KULLANILANLAR>();
                if (AvukatProLib.Kimlik.Bilgi != null)
                {
                    VList<BIRLESIK_SIK_KULLANILANLAR> Kullanilan = BelgeUtil.Inits.BIRLESIK_SIK_KULLANILANLARGetirbyKullaniciId(AvukatProLib.Kimlik.Bilgi.ID);
                }

                else
                    MyKullanilan = null;

                MyDataSource = MyKullanilan;
                Forms.rfrmSikKullanilanEkle.Yenile += sikKullanilanDuzenle_Yenile;
            }

            treeList1.KeyFieldName = BIRLESIK_SIK_KULLANILANLARColumn.KATEGORI_ID.ToString();
            treeList1.ParentFieldName = BIRLESIK_SIK_KULLANILANLARColumn.UST_KATEGORI_ID.ToString();
            treeList1.ImageIndexFieldName = "ImageIndex";
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender,
                                                           DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (treeList1.GetDataRecordByNode(treeList1.FocusedNode) is BIRLESIK_SIK_KULLANILANLAR)
            {
                BIRLESIK_SIK_KULLANILANLAR kullanilan =
                    treeList1.GetDataRecordByNode(treeList1.FocusedNode) as BIRLESIK_SIK_KULLANILANLAR;

                if (kullanilan.MODUL.HasValue || kullanilan.ID.HasValue)
                {
                    AvukatProLib.Extras.ModulTip modul =
                        (AvukatProLib.Extras.ModulTip)kullanilan.MODUL;
                    switch (modul)
                    {
                        case AvukatProLib.Extras.ModulTip.Sorusturma:
                            AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip sorusturmaTakip =
                                new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                            TList<AV001_TD_BIL_HAZIRLIK> Hfoy = new TList<AV001_TD_BIL_HAZIRLIK>();
                            Hfoy.Add(DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(kullanilan.KAYIT_ID.Value));
                            sorusturmaTakip.Show(Hfoy);
                            break;
                        case AvukatProLib.Extras.ModulTip.Dava:
                            AdimAdimDavaKaydi.DavaTakip.frmDavaTakip davaTakip =
                                new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                            TList<AV001_TD_BIL_FOY> dfoy = new TList<AV001_TD_BIL_FOY>();
                            dfoy.Add(DataRepository.AV001_TD_BIL_FOYProvider.GetByID(kullanilan.KAYIT_ID.Value));
                            davaTakip.Show(dfoy);
                            break;
                        case AvukatProLib.Extras.ModulTip.Icra:
                            AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip icraForms =
                                new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                            TList<AV001_TI_BIL_FOY> Ifoy = new TList<AV001_TI_BIL_FOY>();
                            Ifoy.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(kullanilan.KAYIT_ID.Value));
                            icraForms.Show(Ifoy);

                            break;
                        case AvukatProLib.Extras.ModulTip.Sozlesme:
                            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip sozlesmeTakip =
                                new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeTakip();
                            sozlesmeTakip.Show(kullanilan.KAYIT_ID.Value);
                            break;
                        case AvukatProLib.Extras.ModulTip.Tebligat:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                BIRLESIK_SIK_KULLANILANLAR kullanilan = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as BIRLESIK_SIK_KULLANILANLAR;
                if (kullanilan.ID.HasValue)
                {
                    AV001_TDIE_BIL_SIK_KULLANILAN kullItem = DataRepository.AV001_TDIE_BIL_SIK_KULLANILANProvider.GetByID(kullanilan.ID.Value);
                    if (kullItem != null)
                    {
                        DataRepository.AV001_TDIE_BIL_SIK_KULLANILANProvider.Delete(kullItem);
                        MyDataSource.Remove(kullanilan);
                        treeList1.DataSource = MyDataSource;
                    }
                }
                else
                {
                    TList<AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI> kullanilanKat = DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.Find(String.Format("ADI = '{0}'", kullanilan.ADI));
                    if (kullanilanKat.Count > 0)
                    {
                        foreach (AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI var in kullanilanKat)
                        {
                            if (var.ADI == kullanilan.ADI)
                            {
                                DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.Delete(var);
                                MyDataSource = DataRepository.BIRLESIK_SIK_KULLANILANLARProvider.GetByKullaniciId(AvukatProLib.Kimlik.Bilgi.ID);
                                treeList1.DataSource = MyDataSource;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("Lütfen Kayýt Seçiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public event EventHandler<EventArgs> Yenile;

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Yenile != null)
                Yenile(this, new EventArgs());
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                BIRLESIK_SIK_KULLANILANLAR kullanilan =
                    treeList1.GetDataRecordByNode(treeList1.FocusedNode) as BIRLESIK_SIK_KULLANILANLAR;
                AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORI kat =
                    DataRepository.AV001_TDIE_BIL_SIK_KULLANILAN_KATEGORIProvider.GetByID(kullanilan.KATEGORI_ID.Value);

                Forms.frmSikKullanilanDuzenle sikKullanilanDuzenle =
                    new AdimAdimDavaKaydi.Forms.frmSikKullanilanDuzenle();
                sikKullanilanDuzenle.MyKategori = kat;
                sikKullanilanDuzenle.Show();
                sikKullanilanDuzenle.Yenile += sikKullanilanDuzenle_Yenile;
            }
            else
                MessageBox.Show("Lütfen Kayýt Seçiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sikKullanilanDuzenle_Yenile(object sender, EventArgs e)
        {
            if (AvukatProLib.Kimlik.Bilgi != null)
            {
                MyDataSource = BelgeUtil.Inits.BIRLESIK_SIK_KULLANILANLARGetirbyKullaniciId(AvukatProLib.Kimlik.Bilgi.ID);
            }
        }
    }
}