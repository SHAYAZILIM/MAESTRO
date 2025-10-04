using AdimAdimDavaKaydi.DavaTakip;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rfrmDavaPolice : Util.BaseClasses.AvpXtraForm
    {
        public rfrmDavaPolice()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rfrmDavaPolice_FormClosing;
        }

        private TList<AV001_TDI_BIL_POLICE> addNewList;

        private bool davaNedeniYok;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TDI_BIL_POLICE> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_DAVA_NEDEN DavaNeden
        {
            get { return DavaNedenBul(); }

            //set { davaNeden = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TDI_BIL_POLICE>();
                            AddNewList.AddingNew += AddNewList_AddingNew;
                            AddNewList.AddNew();
                        }
                        else
                            AddNewList.AddingNew += AddNewList_AddingNew;

                        DataRepository.AV001_TDI_BIL_POLICEProvider.DeepLoad(AddNewList, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_POLICE>));

                        //AddNewList.AddNew();
                        ucDavaPolice1.MyDataSource = AddNewList;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_POLICE police = e.NewObject as AV001_TDI_BIL_POLICE;
            if (police == null)
                police = new AV001_TDI_BIL_POLICE();

            police.SIGORTALI_CARI_ID = ucDavaTarafBilgileri.CurrTarafId;
            police.KAYIT_TARIHI = DateTime.Now;
            police.KLASOR_KODU = "GENEL";
            police.KONTROL_KIM = "AVUKATPRO";
            police.KONTROL_NE_ZAMAN = DateTime.Now;
            police.KONTROL_VERSIYON = 1;
            police.STAMP = 1;
            police.SUBE_KODU = 1;
            police.POLICE_LIMIT_DOVIZ_ID = 1;
            e.NewObject = police;
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            //foreach (AV001_TDI_BIL_POLICE p in AddNewList)
            //{
            //    string sStr = ucKanit.Validate(n);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
            //            + System.Environment.NewLine + sStr, "Uyarý");

            //        result = false;
            //        break;
            //    }
            //}

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CikabilirMi()
        {
            if (AddNewList == null)
                return true;
            foreach (AV001_TDI_BIL_POLICE p in AddNewList)
            {
                if (p.IsNew || p.HasDataChanged())
                    return false;
            }

            return true;
        }

        private AV001_TD_BIL_DAVA_NEDEN DavaNedenBul()
        {
            AV001_TD_BIL_DAVA_NEDEN dn = null;

            // if (MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
            dn =
                MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Find(
                    delegate(AV001_TD_BIL_DAVA_NEDEN n) { return (n.ID == ucDavaTarafBilgileri.CurrTalepId); });
            if (dn == null)
                dn = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0];

            return dn;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void rfrmDavaPolice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi || davaNedeniYok) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void rfrmDavaPolice_Load(object sender, EventArgs e)
        {
            if (DavaNedenBul() == null)
            {
                XtraMessageBox.Show("Dosyada dava nedeni bulunmadýðýndan poliçe kayýt ekraný açýlamýyor", "Uyarý",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                davaNedeniYok = true;
                this.Close();
            }
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TDI_BIL_POLICE p) { p.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TDI_BIL_POLICECollection.AddRange(AddNewList);

            foreach (AV001_TDI_BIL_POLICE p in AddNewList)
            {
                if (
                    MyFoy.AV001_TDI_BIL_POLICECollection.Exists(
                        delegate(AV001_TDI_BIL_POLICE police) { return police.ID == p.ID; })) continue;
                MyFoy.AV001_TDI_BIL_POLICECollection.Add(p);
            }
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_POLICEProvider.DeepSave(tran, MyFoy.AV001_TDI_BIL_POLICECollection);

                // TList<NN_DAVA_NEDEN_POLICE> result = new TList<NN_DAVA_NEDEN_POLICE>();

                foreach (AV001_TDI_BIL_POLICE police in MyFoy.AV001_TDI_BIL_POLICECollection)
                {
                    if (
                        DataRepository.NN_DAVA_NEDEN_POLICEProvider.GetByDAVA_NEDEN_IDPOLICE_ID(DavaNedenBul().ID,
                                                                                                police.ID) == null)
                    {
                        if (
                            DavaNedenBul().NN_DAVA_NEDEN_POLICECollection.Exists(
                                delegate(NN_DAVA_NEDEN_POLICE p) { return police.ID == p.POLICE_ID; })) continue;
                        NN_DAVA_NEDEN_POLICE nn = new NN_DAVA_NEDEN_POLICE();
                        nn.POLICE_ID = police.ID;
                        nn.DAVA_NEDEN_ID = DavaNedenBul().ID;

                        // result.Add(nn);
                        DataRepository.NN_DAVA_NEDEN_POLICEProvider.Save(tran, nn);
                    }
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<NN_DAVA_POLICE>));
                    if (
                        MyFoy.NN_DAVA_POLICECollection.Exists(
                            delegate(NN_DAVA_POLICE p) { return police.ID == p.POLICE_ID; })) continue;
                    NN_DAVA_POLICE nnD = new NN_DAVA_POLICE();
                    nnD.POLICE_ID = police.ID;
                    nnD.DAVA_FOY_ID = MyFoy.ID;
                    DataRepository.NN_DAVA_POLICEProvider.Save(tran, nnD);
                }

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TDI_BIL_POLICECollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }
    }
}