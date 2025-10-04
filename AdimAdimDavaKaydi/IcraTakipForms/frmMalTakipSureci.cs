using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib;
using AvukatProLib.Hesap.Views;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmMalTakipSureci : AvpXtraForm
    {
        public frmMalTakipSureci()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Button_Kaydet_Click += new EventHandler<EventArgs>(frmMalTakipSureci_Button_Kaydet_Click);
        }

        #region Properties

        private MalTakipKategori malKategori;

        private TList<AV001_TI_BIL_HACIZ_CHILD> myDataSource;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_HACIZ_CHILD> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null)
                {
                    myDataSource = value;

                    DeepLoadHaciz(value);
                    bndHacizChild.DataSource = value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        #endregion Properties

        #region Events

        private void bndHacizChild_CurrentChanged(object sender, EventArgs e)
        {
            var child = bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD;

            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_HACIZ_MASTER), typeof(TList<AV001_TI_BIL_SATIS_CHILD>), typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));

            if (child != null)
            {
                bndHacizMaster.DataSource = child.MASTER_IDSource;

                TList<AV001_TI_BIL_SATIS_MASTER> satisList = new TList<AV001_TI_BIL_SATIS_MASTER>();
                child.AV001_TI_BIL_SATIS_CHILDCollection.ForEach(item =>
                {
                    var master = DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByID(item.MASTER_ID);
                    if (!satisList.Contains(master))
                        satisList.Add(DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByID(item.MASTER_ID));
                });
                bndSatisMaster.DataSource = satisList;

                bndExpertiz.DataSource = child.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI == true);

                bndKiymetTakdiri.DataSource = child.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI == false);

                bndGayrimenkul.DataSource = new TList<AV001_TI_BIL_GAYRIMENKUL>(new[] { child.GAYRIMENKUL_BILGI_IDSource });

                bndArac.DataSource = new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>(new[] { child.ARAC_BILGI_IDSource });

                if (child.ARAC_BILGI_ID.HasValue)
                {
                    bndSozlesme.DataSource = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByGEMI_UCAK_ARAC_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(child.ARAC_BILGI_ID.Value);
                    bndTakyidat.DataSource = DataRepository.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATProvider.GetByGEMI_UCAK_ARAC_ID(child.ARAC_BILGI_ID.Value);
                }
                else if (child.GAYRIMENKUL_BILGI_ID.HasValue)
                {
                    bndSozlesme.DataSource = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByGAYRIMENKUL_IDFromNN_SOZLESME_GAYRIMENKUL(child.GAYRIMENKUL_BILGI_ID.Value);
                    bndTakyidat.DataSource = DataRepository.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATProvider.GetByGAYRIMENKUL_ID(child.GAYRIMENKUL_BILGI_ID.Value);
                }
            }
        }

        private void bndHacizMaster_CurrentChanged(object sender, EventArgs e)
        {
            var master = bndHacizMaster.Current as AV001_TI_BIL_HACIZ_MASTER;

            DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(master, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY));
            if (master != null)
            {
                bndIcraFoy.DataSource = master.ICRA_FOY_IDSource;
            }
        }

        private void bndSatisMaster_CurrentChanged(object sender, EventArgs e)
        {
            var master = bndSatisMaster.Current as AV001_TI_BIL_SATIS_MASTER;

            if (master == null) return;

            if (master.AV001_TI_BIL_SATIS_CHILDCollection.Count == 0)
                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(master, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

            if (master.AV001_TI_BIL_SATIS_CHILDCollection.Count > 0)
                bndSatisChild.DataSource = master.AV001_TI_BIL_SATIS_CHILDCollection;
            else
            {
                master.AV001_TI_BIL_SATIS_CHILDCollection.AddNew();
                master.AV001_TI_BIL_SATIS_CHILDCollection[0].HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;
                bndSatisChild.DataSource = master.AV001_TI_BIL_SATIS_CHILDCollection;
            }
        }

        private void dtMuhafaT_EditValueChanged(object sender, EventArgs e)
        {
            var date = sender as DateEdit;
            if (date != null && date.DateTime != null) (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).HACIZ_ISLEM_DURUM_ID = 2;
        }

        private void frm_DavaFoyKaydedildi(object sender, DavaFoyKaydedildiEventArgs e)
        {
            if (bndKiymetTakdiri.Current == null) return;
            (bndKiymetTakdiri.Current as AV001_TI_BIL_KIYMET_TAKDIRI).SIKAYET_VARMI = true;
            (bndKiymetTakdiri.Current as AV001_TI_BIL_KIYMET_TAKDIRI).SIKAYET_DAVA_FOY_ID = e.DavaFoy.ID;
            frmMalTakipSureci_Button_Kaydet_Click(this, new EventArgs());
        }

        private void frmDavaKayit_DavaFoyKaydedildi(object sender, DavaFoyKaydedildiEventArgs e)
        {
            AvukatProLib.Arama.NN_DAVA_HACIZLI_MAL davaHacizliMal = new AvukatProLib.Arama.NN_DAVA_HACIZLI_MAL();
            davaHacizliMal.DAVA_FOY_ID = e.DavaFoy.ID;
            davaHacizliMal.HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;

            if (BelgeUtil.Inits.context.NN_DAVA_HACIZLI_MALs.Where(vi => vi.DAVA_FOY_ID == davaHacizliMal.DAVA_FOY_ID && vi.HACIZ_CHILD_ID == davaHacizliMal.HACIZ_CHILD_ID).Count() == 0)
            {
                BelgeUtil.Inits.context.NN_DAVA_HACIZLI_MALs.InsertOnSubmit(davaHacizliMal);

                try
                {
                    BelgeUtil.Inits.context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmKayit_DavaFoyKaydedildi(object sender, DavaFoyKaydedildiEventArgs e)
        {
            if (bndSatisChild.Current == null) return;
            (bndSatisChild.Current as AV001_TI_BIL_SATIS_CHILD).SATIS_ISLEMINI_SIKAYET_DAVA_FOY_ID = e.DavaFoy.ID;
            frmMalTakipSureci_Button_Kaydet_Click(this, new EventArgs());
        }

        private void frmMalTakipSureci_Load(object sender, EventArgs e)
        {
            BindLookUpEdits();

            #region <MB-20101001>

            //Form Yükleme

            var hacizChild = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD);

            if (MyFoy.FORM_TIP_ID == (int)AvukatProLib.Extras.FormTipleri.Form50 || MyFoy.FORM_TIP_ID == (int)AvukatProLib.Extras.FormTipleri.Form201)
            {
                AV001_TDI_BIL_SOZLESME sozlesme = null;
                if (hacizChild.ARAC_BILGI_ID.HasValue)
                    sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByGEMI_UCAK_ARAC_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(hacizChild.ARAC_BILGI_ID.Value).FirstOrDefault();

                if (sozlesme != null && sozlesme.ALT_TIP_ID == (int)AvukatProLib.Extras.SozlesmeAltTip.Ticari_Isletme_Rehni)//Ticari İşletme Rehni
                {
                    lcGroupKategori.Text = "T.İ.R";
                    malKategori = MalTakipKategori.TicariIsletmeRehni;
                    BindTreeList(malKategori);
                }
                else//Taşınır Rehni Satışı
                {
                    lcGroupKategori.Text = "Taşınır Rehni";
                    malKategori = MalTakipKategori.TasinirRehniSatisi;
                    BindTreeList(malKategori);
                }
            }
            else if (MyFoy.FORM_TIP_ID == (int)AvukatProLib.Extras.FormTipleri.Form151 || MyFoy.FORM_TIP_ID == (int)AvukatProLib.Extras.FormTipleri.Form152)//İpotek Satışı
            {
                lcGroupKategori.Text = "İpotek";
                malKategori = MalTakipKategori.IpotekSatisi;
                BindTreeList(malKategori);
            }
            else if (hacizChild.GAYRIMENKUL_BILGI_ID.HasValue)//Taşınmaz Haczi Satışı
            {
                lcGroupKategori.Text = "Taşınmaz Haczi";
                malKategori = MalTakipKategori.TasinmazHacziSatisi;
                BindTreeList(malKategori);
                lcItemHacizKaynagi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcItemIhtiyatiHacizT.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else//Taşınır Haczi Bilgileri
            {
                lcGroupKategori.Text = "Taşınır Haczi";
                malKategori = MalTakipKategori.TasinirHaczi;
                BindTreeList(malKategori);
                lcItemHacizKaynagi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lcItemIhtiyatiHacizT.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            #endregion <MB-20101001>

            memGenelBilgiler.Text = BindKategoriAciklama(malKategori);

            //İlk işlemlerde satış child üzerindeki 2 alan kullanıldığından add yapılmak zorunda kalındı.MB
            if ((bndSatisMaster.DataSource as TList<AV001_TI_BIL_SATIS_MASTER>).Count == 0)
                bndSatisMaster.AddNew();

            //if ((bndSatisChild.DataSource as TList<AV001_TI_BIL_SATIS_CHILD>).Count == 0)
            //    bndSatisChild.AddNew();

            if (bndGayrimenkul.DataSource != null) memMalBilgileri.Text = BindTasinmazBilgisi();
            else if (bndArac.DataSource != null) memMalBilgileri.Text = BindAracBilgisi();

            treeMalTakipSureci.ExpandAll();
        }
                
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            frmCariTebligTarihiEkleme frm = new frmCariTebligTarihiEkleme();
            if (bndGayrimenkul.Current != null)
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndSatisMaster.Current as AV001_TI_BIL_SATIS_MASTER).ID, AvukatProLib.Extras.TebligTip.Satis, AvukatProLib.Extras.MalTip.Gayrimenkul, (bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL).ID);
            else if (bndArac.Current != null)
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndSatisMaster.Current as AV001_TI_BIL_SATIS_MASTER).ID, AvukatProLib.Extras.TebligTip.Satis, AvukatProLib.Extras.MalTip.GemiUcakArac, (bndArac.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID);
            else
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndSatisMaster.Current as AV001_TI_BIL_SATIS_MASTER).ID, AvukatProLib.Extras.TebligTip.Satis, AvukatProLib.Extras.MalTip.Diger, null);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            bndTakyidat.AddNew();

            if (bndGayrimenkul.Current != null)
                (bndTakyidat.Current as AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT).GAYRIMENKUL_ID = (bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL).ID;
            else if (bndArac.Current != null)
                (bndTakyidat.Current as AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT).GEMI_UCAK_ARAC_ID = (bndArac.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            kiymetTakdiriSikayetmi = true;
            ShowDavaKayitForm();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            bndTakyidat.RemoveCurrent();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //DavaCreated DC = new DavaCreated();
            //DC.IhaleninFeshiDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);

            //frmDavaDosyaKayitForm frmKayit = new frmDavaDosyaKayitForm();
            //frmKayit.RelatedIcraFoy = bndIcraFoy.Current as AV001_TI_BIL_FOY;
            //frmKayit.DavaFoyKaydedildi += new EventHandler<DavaFoyKaydedildiEventArgs>(frmKayit_DavaFoyKaydedildi);
            //frmKayit.Show();

            satisIsleminiSikayetmi = true;
            ShowDavaKayitForm();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            ShowDavaKayitForm();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frmCariTebligTarihiEkleme frm = new frmCariTebligTarihiEkleme();
            if (bndGayrimenkul.Current != null)
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndKiymetTakdiri.Current as AV001_TI_BIL_KIYMET_TAKDIRI).ID, AvukatProLib.Extras.TebligTip.KiymetTakdiri, AvukatProLib.Extras.MalTip.Gayrimenkul, (bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL).ID);
            else if (bndArac.Current != null)
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndKiymetTakdiri.Current as AV001_TI_BIL_KIYMET_TAKDIRI).ID, AvukatProLib.Extras.TebligTip.KiymetTakdiri, AvukatProLib.Extras.MalTip.GemiUcakArac, (bndArac.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID);
            else
                frm.Show(bndIcraFoy.Current as AV001_TI_BIL_FOY, (bndKiymetTakdiri.Current as AV001_TI_BIL_KIYMET_TAKDIRI).ID, AvukatProLib.Extras.TebligTip.KiymetTakdiri, AvukatProLib.Extras.MalTip.Diger, null);
        }

        private void tabbedControlGroup3_SelectedPageChanged(object sender, DevExpress.XtraLayout.LayoutTabPageChangedEventArgs e)
        {
            if (e.Page.Name == "lcGroupMalDavalari")
            {
                gcMalileIlgiliDavalar.DataSource = AvukatProLib.Hesap.Views.MalTakipDavalari.GetMalTakipDavalariByHacizChildId((bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID);
            }
        }

        #region Mal Takip Davalar

        private void cbeDavalar_EditValueChanged(object sender, EventArgs e)
        {
            if (cbeDavalar.EditValue == null) return;

            int dava = (int)cbeDavalar.EditValue;
            DavaCreated DC = new DavaCreated();
            switch (dava)
            {
                case 0:
                    DC.HacizIsleminiSikayet(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 1:
                    DC.MeskeniyetDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 2:
                    DC.IstihkakHakkiDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 3:
                    DC.KiymetTaktirineItiraz(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 4:
                    DC.MemuruSikayet(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 5:
                    DC.IhaleninFeshiDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 6:
                    DC.YediEminiSıkayetDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 7:
                    DC.MemuraHakaretDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 8:
                    DC.MemuraMuessirDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 9:
                    DC.AvukataHakaretDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 10:
                    DC.AvukataMuessirDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 11:
                    DC.TahliyeEdilenGayrimenkul(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 12:
                    DC.TahliyeEdilenGayrimenkul(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;

                case 13:
                    DC.Tahliye(ucIcraTarafGelismeleri.myGelisme, MyFoy);
                    break;
                default:
                    break;
            }
        }

        private void sbtnIIKm97KarsiDava_Click(object sender, EventArgs e)
        {
            ShowDavaKayitForm();

            //frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            //frm.RelatedIcraFoy = bndIcraFoy.Current as AV001_TI_BIL_FOY;
            //frm.Show(); frm.Show();
        }

        private void sbtnIstihkakDavasiAc_Click(object sender, EventArgs e)
        {
            ShowDavaKayitForm();

            //DavaCreated DC = new DavaCreated();
            //DC.IstihkakHakkiDavasi(ucIcraTarafGelismeleri.myGelisme, MyFoy);
        }

        #endregion Mal Takip Davalar

        #region <MB-20101201> Word-Excel-Pdf-Rapora Gönderme

        private void sbtnExceleGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|Excel Dosyası";
            sfd.DefaultExt = "xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMalTakipSureci.ExportToXls(sfd.FileName);
            }
        }

        private void sbtnPDFeGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.pdf|PDF Dosyası";
            sfd.DefaultExt = "pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMalTakipSureci.ExportToPdf(sfd.FileName);
            }
        }

        private void sbtnRaporaGonder_Click(object sender, EventArgs e)
        {
            treeMalTakipSureci.ExpandAll();
            ExtendedGridControl.YazdirmaOnizleme(treeMalTakipSureci);
        }

        private void sbtnWordeGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.rtf|Word Dosyası";
            sfd.DefaultExt = "rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMalTakipSureci.ExportToRtf(sfd.FileName);
            }
        }

        #endregion <MB-20101201> Word-Excel-Pdf-Rapora Gönderme

        #region <MB-20101005> Ağaç Sağ Tuş

        private void ağacıAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeMalTakipSureci.ExpandAll();
        }

        private void ağacıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeMalTakipSureci.CollapseAll();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (malKategori != null)
                BindTreeList(malKategori);
        }

        #endregion <MB-20101005> Ağaç Sağ Tuş

        #region <MB-20101201> AddingNew, Kayıt

        private void bndExpertiz_AddingNew(object sender, AddingNewEventArgs e)
        {
            var expertiz = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).AV001_TI_BIL_KIYMET_TAKDIRICollection.AddNew();
            expertiz.EKSPERTIZ_KAYDI_MI = true;
            expertiz.KAYIT_TARIHI = DateTime.Now;
            expertiz.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
            expertiz.KONTROL_NE_ZAMAN = DateTime.Now;
            expertiz.SUBE_KOD_ID = Kimlik.SubeKodu;
            expertiz.STAMP = Kimlik.DefaultStamp;
            expertiz.HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;
            e.NewObject = expertiz;
        }

        private void bndIstihkak_AddingNew(object sender, AddingNewEventArgs e)
        {
            var istihkak = new AV001_TI_BIL_ISTIHKAK();

            istihkak.KAYIT_TARIHI = DateTime.Now;
            istihkak.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
            istihkak.KONTROL_NE_ZAMAN = DateTime.Now;
            istihkak.SUBE_KOD_ID = Kimlik.SubeKodu;
            istihkak.STAMP = Kimlik.DefaultStamp;
            istihkak.HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;
            e.NewObject = istihkak;
        }

        private void bndKiymetTakdiri_AddingNew(object sender, AddingNewEventArgs e)
        {
            var kiymetTakdiri = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).AV001_TI_BIL_KIYMET_TAKDIRICollection.AddNew();
            kiymetTakdiri.EKSPERTIZ_KAYDI_MI = false;
            kiymetTakdiri.KAYIT_TARIHI = DateTime.Now;
            kiymetTakdiri.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
            kiymetTakdiri.KONTROL_NE_ZAMAN = DateTime.Now;
            kiymetTakdiri.SUBE_KOD_ID = Kimlik.SubeKodu;
            kiymetTakdiri.STAMP = Kimlik.DefaultStamp;
            kiymetTakdiri.HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;
            e.NewObject = kiymetTakdiri;
        }

        private void bndSatisChild_AddingNew(object sender, AddingNewEventArgs e)
        {
            var satisChild = new AV001_TI_BIL_SATIS_CHILD();

            satisChild.KAYIT_TARIHI = DateTime.Now;
            satisChild.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
            satisChild.KONTROL_NE_ZAMAN = DateTime.Now;
            satisChild.SUBE_KOD_ID = Kimlik.SubeKodu;
            satisChild.STAMP = Kimlik.DefaultStamp;
            satisChild.HACIZ_CHILD_ID = (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).ID;

            e.NewObject = satisChild;
        }

        private void bndSatisMaster_AddingNew(object sender, AddingNewEventArgs e)
        {
            var satisMaster = new AV001_TI_BIL_SATIS_MASTER();

            satisMaster.KAYIT_TARIHI = DateTime.Now;
            satisMaster.KONTROL_KIM_ID = Kimlik.Bilgi.ID;
            satisMaster.KONTROL_NE_ZAMAN = DateTime.Now;
            satisMaster.SUBE_KOD_ID = Kimlik.SubeKodu;
            satisMaster.STAMP = Kimlik.DefaultStamp;
            satisMaster.ICRA_FOY_ID = (bndIcraFoy.Current as AV001_TI_BIL_FOY).ID;
            satisMaster.SATIS_TURU_ID = 1;
            satisMaster.SATISIN_ISTENME_SEKLI_ID = 1;
            satisMaster.SATISI_ISTENEN_CARI_ID = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == TreeMalTakip.HacizMaster.HACIZ_ISTENEN_CARI_ID).ID;
            satisMaster.SATIS_TARIHI_1 = null;
            if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            satisMaster.SATIS_SORUMLU_PERSONEL_ID = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FirstOrDefault(avk => !avk.YETKILI_MI).SORUMLU_AVUKAT_CARI_ID).ID;

            e.NewObject = satisMaster;
        }

        private void frmMalTakipSureci_Button_Kaydet_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(Kimlik.SirketBilgisi.ConStr);

            try
            {
                if (!vpBosGecilezler.Validate())
                {
                    tabbedControlGroup1.SelectedTabPage = lcGroupSatis;
                    XtraMessageBox.Show("Satış kaydındaki zorunlu alanlar boş geçildiğinden \r\n kayıt işlemi gerçekleştirilemiyor.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepSave(tran, bndHacizMaster.Current as AV001_TI_BIL_HACIZ_MASTER, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepSave(tran, bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>), typeof(TList<AV001_TI_BIL_ISTIHKAK>), typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));
                DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.DeepSave(tran, bndExpertiz.List as TList<AV001_TI_BIL_KIYMET_TAKDIRI>);
                DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.DeepSave(tran, bndKiymetTakdiri.List as TList<AV001_TI_BIL_KIYMET_TAKDIRI>);
                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepSave(tran, bndSatisMaster.List as TList<AV001_TI_BIL_SATIS_MASTER>, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

                if (bndGayrimenkul.Current != null)
                    (bndTakyidat.List as TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>).ForEach(item =>
                    {
                        item.GAYRIMENKUL_ID = (bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL).ID;
                    });
                else if (bndArac.Current != null)
                    (bndTakyidat.List as TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>).ForEach(item =>
                    {
                        item.GEMI_UCAK_ARAC_ID = (bndArac.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID;
                    });

                DataRepository.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATProvider.Save(tran, bndTakyidat.List as TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>);
                if (bndSozlesme.Current != null)
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.Save(tran, bndSozlesme.Current as AV001_TDI_BIL_SOZLESME);

                tran.Commit();
                XtraMessageBox.Show("Kayıt işlemi başarı ile gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (malKategori != null)
                    BindTreeList(malKategori);
                treeMalTakipSureci.ExpandAll();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                ErrorHandler.Catch(this, ex);
            }
        }

        #endregion <MB-20101201> AddingNew, Kayıt

        #region <MB-20101501> Takip ve Klasör ekranlarının açılması

        private void gcMalileIlgiliDavalar_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "TakipEkrani")
            {
                AV001_TD_BIL_FOY foyd = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((gvMalileIlgiliDavalar.GetFocusedRow() as MalTakipDavalari).ID);
                if (foyd != null)
                {
                    TList<AV001_TD_BIL_FOY> seciliDKayitlar = new TList<AV001_TD_BIL_FOY>();
                    seciliDKayitlar.Add(foyd);
                    AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmdavaTakip = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                    frmdavaTakip.Show(seciliDKayitlar);
                }
            }
            else if (e.Button.Tag.ToString() == "Klasor")
            {
                AV001_TD_BIL_FOY foyd = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((gvMalileIlgiliDavalar.GetFocusedRow() as MalTakipDavalari).ID);

                if (foyd != null)
                {
                    TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> projeDava = DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(foyd.ID);
                    if (projeDava.Count > 0)
                    {
                        AV001_TDIE_BIL_PROJE proj = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(projeDava[0].PROJE_ID);
                        TList<AV001_TDIE_BIL_PROJE> seciliKayitlar = new TList<AV001_TDIE_BIL_PROJE>();
                        seciliKayitlar.Add(proj);
                        AdimAdimDavaKaydi.Forms.frmKlasorYeni klasorGenel = new AdimAdimDavaKaydi.Forms.frmKlasorYeni();

                        // .MdiParent = null;
                        klasorGenel.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        klasorGenel.Show(seciliKayitlar);
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                    }
                }
            }
        }

        #endregion <MB-20101501> Takip ve Klasör ekranlarının açılması

        #endregion Events

        #region Methods

        private bool kiymetTakdiriSikayetmi = false;
        private bool satisIsleminiSikayetmi = false;

        private string BindAracBilgisi()
        {
            if (bndArac.Current == null) return string.Empty;

            string aciklama = string.Empty;
            var arac = bndGayrimenkul.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC;

            aciklama += "Maliki: " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == TreeMalTakip.HacizMaster.HACIZ_ISTENEN_CARI_ID).AD + ", ";
            aciklama += "Trafik Şube: " + arac.TRAFIK_SUBESI + ", ";
            aciklama += "Plaka: " + arac.ARAC_PLAKA + ", ";
            aciklama += "Model: " + arac.ARAC_MODEL + ", ";

            return aciklama;
        }

        private string BindKategoriAciklama(MalTakipKategori malKategori)
        {
            string aciklama = string.Empty;

            if (bndSozlesme.Current == null) return aciklama;

            var sozlesme = bndSozlesme.Current as AV001_TDI_BIL_SOZLESME;
            AdimAdimDavaKaydi.Generalclass.SayiOkuma sa = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();

            switch (malKategori)
            {
                case MalTakipKategori.TicariIsletmeRehni:
                    if (sozlesme.ADLI_BIRIM_ADLIYE_ID.HasValue)
                        aciklama += BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == sozlesme.ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE;
                    if (sozlesme.ADLI_BIRIM_NO_ID.HasValue)
                        aciklama += BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == sozlesme.ADLI_BIRIM_NO_ID.Value).NO;
                    if (sozlesme.ADLI_BIRIM_GOREV_ID.HasValue)
                        aciklama += BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == sozlesme.ADLI_BIRIM_GOREV_ID.Value).GOREV;
                    if (!string.IsNullOrEmpty(aciklama)) aciklama += " noterliğinden ";
                    if (sozlesme.IMZA_TARIHI.HasValue) aciklama += sozlesme.IMZA_TARIHI.Value.ToShortDateString() + " tarihli ";
                    if (!string.IsNullOrEmpty(sozlesme.TICARI_ISLETME_UNVANI)) aciklama += sozlesme.TICARI_ISLETME_UNVANI + " ünvanlı ";
                    if (!string.IsNullOrEmpty(sozlesme.TICARI_ISLETME_ADI))
                        aciklama += sozlesme.TICARI_ISLETME_ADI + " işletme adlı ticari işletme rehni.";
                    if (sozlesme.BEDELI != null && sozlesme.BEDELI != 0)
                        aciklama += " Rehin Bedeli " + sa.ParaFormatla(sozlesme.BEDELI) + " " + BelgeUtil.Inits._DovizSource.Find(vi => vi.ID == sozlesme.BEDELI_DOVIZ_ID).DOVIZ_KODU + "'dir.";
                    if (sozlesme.SICIL_TARIHI.HasValue)
                        aciklama += "Rehnin ticaret sicile kayıt edildiği ve masrafının verildiği tarih: " + sozlesme.SICIL_TARIHI.Value.ToShortDateString();
                    return aciklama;
                case MalTakipKategori.TasinirRehniSatisi:
                    aciklama += "Maliki " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == TreeMalTakip.HacizMaster.HACIZ_ISTENEN_CARI_ID).AD;
                    if (sozlesme.IMZA_TARIHI.HasValue) aciklama += " tarihi " + sozlesme.IMZA_TARIHI.Value.ToShortDateString();
                    if (sozlesme.BEDELI != null && sozlesme.BEDELI != 0)
                        aciklama += "  bedeli " + sa.ParaFormatla(sozlesme.BEDELI) + " " + BelgeUtil.Inits._DovizSource.Find(vi => vi.ID == sozlesme.BEDELI_DOVIZ_ID).DOVIZ_KODU;
                    aciklama += "olan Taşınır Rehni";
                    return aciklama;
                case MalTakipKategori.IpotekSatisi:
                    if (!string.IsNullOrEmpty(sozlesme.BOLGE_MUDURLUGU))
                        aciklama += "Tapu Dairesi: " + sozlesme.BOLGE_MUDURLUGU + " " + sozlesme.SICIL_BOLGE_NO + ", ";
                    if (sozlesme.IMZA_TARIHI.HasValue)
                        aciklama += "Tesis Tarihi: " + sozlesme.IMZA_TARIHI.Value.ToShortDateString() + ", ";
                    if (sozlesme.SICIL_TARIHI.HasValue)
                        aciklama += "Tescil Tarihi: " + sozlesme.SICIL_TARIHI.Value.ToShortDateString() + ", ";
                    if (!string.IsNullOrEmpty(sozlesme.SICIL_YEVMIYE_NO))
                        aciklama += "Yevmiye No: " + sozlesme.SICIL_YEVMIYE_NO + ", ";
                    if (sozlesme.MUSTEREKMI_MUSTAKILMI.HasValue)
                    {
                        if (sozlesme.MUSTEREKMI_MUSTAKILMI.Value)
                            aciklama += "Münferit, ";
                        else
                            aciklama += "Müşterel, ";
                    }

                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_DERECE>));

                    var gayrimenkul = sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.FirstOrDefault();
                    if (gayrimenkul != null)
                    {
                        var sozlesmeGayrimenkul = gayrimenkul.AV001_TDI_BIL_SOZLESME_DERECECollection.FirstOrDefault();
                        if (sozlesmeGayrimenkul != null)
                            aciklama += "Derece: " + sozlesmeGayrimenkul.DERECESI + ", ";
                    }

                    if (BelgeUtil.Inits._DovizTipGetir == null)
                        BelgeUtil.Inits._DovizTipGetir = DataRepository.per_TDI_KOD_DOVIZ_TIPProvider.GetAll();
                    aciklama += " İpotek Bedeli " + sa.ParaFormatla(sozlesme.BEDELI) + " " + BelgeUtil.Inits._DovizTipGetir.Find(vi => vi.ID == sozlesme.BEDELI_DOVIZ_ID).DOVIZ_KODU;

                    return aciklama;
                case MalTakipKategori.TasinmazHacziSatisi:
                case MalTakipKategori.TasinirHaczi:
                    aciklama += "Maliki " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == TreeMalTakip.HacizMaster.HACIZ_ISTENEN_CARI_ID).AD;
                    return aciklama;
                default:
                    return string.Empty;
            }
        }

        private void BindLookUpEdits()
        {
            #region Cari

            BelgeUtil.Inits.perCariGetir(lueExpertizBilirKisi1.Properties);
            BelgeUtil.Inits.perCariGetir(lueIstihkakTalepEden.Properties);
            BelgeUtil.Inits.perCariGetir(rlueTakyidatSahibi);
            BelgeUtil.Inits.perCariGetir(lookUpEdit6.Properties);

            #endregion Cari

            #region Döviz

            BelgeUtil.Inits.DovizTipGetir(lueKesinlesenDegerDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueTakdirDegeriDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueExpertizDegeriDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueSatisDegeriDoviz.Properties);
            BelgeUtil.Inits.DovizTipGetir(rlueTakyidatTutarDoviz);
            BelgeUtil.Inits.DovizTipGetir(lookUpEdit16.Properties);

            #endregion Döviz

            #region Para Formatla

            BelgeUtil.Inits.ParaBicimiAyarla(spExpertizDegeri);
            BelgeUtil.Inits.ParaBicimiAyarla(spTakdirDegeri);
            BelgeUtil.Inits.ParaBicimiAyarla(spKesinlesenDeger);
            BelgeUtil.Inits.ParaBicimiAyarla(spSatisDegeri);

            #endregion Para Formatla

            BelgeUtil.Inits.TakipYoluGetir(lueTakipYolu.Properties);
            BelgeUtil.Inits.ItirazSonucuGetir(lueItirazSonucu.Properties);
            BelgeUtil.Inits.DavaTalepGetir(rlueDavaKonu);
            BelgeUtil.Inits.SubeKodGetir(rlueSubeKod);
            BelgeUtil.Inits.CariPersonelGetir(lueSorumluPersonel);
            BelgeUtil.Inits.SozlesmeTakyidatKodGetir(rlueTakyidatTuru);
            BelgeUtil.Inits.SozlesmeTakyidatKodGetir(lookUpEdit5);
            BelgeUtil.Inits.HAcizKaynakGetir(lueHacizKaynagi.Properties);

            #region Adliye-Birim-Görev

            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueIcraFoyAdliye.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lookUpEdit13.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueTakyidatAdliye);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueTalimatMudurluk.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lueIcraFoyBirimNo.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lookUpEdit14.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueTakyidatNo);
            BelgeUtil.Inits.AdliBirimNoGetir(lueTalimatBirimNo.Properties);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.AdliBirimGorevGetir(lookUpEdit15);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueTakyidatGorev);

            #endregion Adliye-Birim-Görev
        }

        private string BindTasinmazBilgisi()
        {
            if (bndGayrimenkul.Current == null) return string.Empty;

            string aciklama = string.Empty;
            var gayrimenkul = bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL;

            aciklama += "Maliki: " + BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == TreeMalTakip.HacizMaster.HACIZ_ISTENEN_CARI_ID).AD + ", ";
            if (gayrimenkul.IL_ID.HasValue)
                aciklama += "Tapu İl: " + BelgeUtil.Inits._IlGetir_Enter.Find(vi => vi.ID == gayrimenkul.IL_ID.Value).IL + ", ";
            if (gayrimenkul.ILCE_ID.HasValue)
                aciklama += "Tapu İlçe: " + BelgeUtil.Inits._IlceGetirTumu_Enter.Find(vi => vi.ID == gayrimenkul.ILCE_ID.Value).ILCE + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.ADA_NO))
                aciklama += "Ada: " + gayrimenkul.ADA_NO + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.PAFTA_NO))
                aciklama += "Pafta: " + gayrimenkul.PAFTA_NO + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.PARSEL_NO))
                aciklama += "Parsel: " + gayrimenkul.PARSEL_NO + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.KOY_ADI))
                aciklama += "Köy: " + gayrimenkul.KOY_ADI + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.SOKAK_ADI))
                aciklama += "Sokak: " + gayrimenkul.SOKAK_ADI + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.MAHALLE_ADI))
                aciklama += "Sokak: " + gayrimenkul.MAHALLE_ADI + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.SAHIFE_NO))
                aciklama += "Sahife: " + gayrimenkul.SAHIFE_NO + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.ARSA_PAYI))
                aciklama += "Arsa Payı: " + gayrimenkul.ARSA_PAYI + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.KAT_NO))
                aciklama += "Kat: " + gayrimenkul.KAT_NO + ", ";
            if (!string.IsNullOrEmpty(gayrimenkul.BAGIMSIZ_BOLUM_NO))
                aciklama += "Bağımsız Bölüm No: " + gayrimenkul.BAGIMSIZ_BOLUM_NO + ", ";

            aciklama += "Türü: " + BelgeUtil.Inits._MalTurGetir.Find(vi => vi.ID == (bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD).HACIZLI_MAL_TUR_ID).TUR;

            return aciklama;
        }

        private void BindTreeList(MalTakipKategori kategori)
        {
            if (bndHacizChild.Current != null)
            {
                TreeMalTakip.SatisChild = bndSatisChild.List as TList<AV001_TI_BIL_SATIS_CHILD>;
                TreeMalTakip.SatisMaster = bndSatisMaster.List as TList<AV001_TI_BIL_SATIS_MASTER>;
                TreeMalTakip.HacizMaster = bndHacizMaster.Current as AV001_TI_BIL_HACIZ_MASTER;
                TreeMalTakip.KiymetTakdiri = bndKiymetTakdiri.List as TList<AV001_TI_BIL_KIYMET_TAKDIRI>;
                TreeMalTakip.Istihkak = bndIstihkak.List as TList<AV001_TI_BIL_ISTIHKAK>;

                TreeMalTakip malTakip = new TreeMalTakip(kategori, bndHacizChild.Current as AV001_TI_BIL_HACIZ_CHILD, bndIcraFoy.Current as AV001_TI_BIL_FOY);
                if (malTakip != null)
                    treeMalTakipSureci.DataSource = malTakip.GetNodeList();
            }
        }

        private void DeepLoadHaciz(TList<AV001_TI_BIL_HACIZ_CHILD> value)
        {
            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_HACIZ_MASTER>), typeof(TList<AV001_TI_BIL_SATIS_CHILD>), typeof(TList<AV001_TI_BIL_SATIS_MASTER>), typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>), typeof(TList<AV001_TI_BIL_ISTIHKAK>), typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>));
            FoyGetir(value);
        }

        private void FoyGetir(TList<AV001_TI_BIL_HACIZ_CHILD> value)
        {
            foreach (var item in value)
            {
                var master = DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByID(item.MASTER_ID);
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(master.ICRA_FOY_ID.Value);
            }
        }

        private void ShowDavaKayitForm()
        {
            frmDavaDosyaKayitForm frmDavaKayit = new frmDavaDosyaKayitForm();
            frmDavaKayit.OtomatikKayit = true;
            frmDavaKayit.RelatedIcraFoy = bndIcraFoy.Current as AV001_TI_BIL_FOY;
            if (bndArac.Current != null)
                frmDavaKayit.GUAID = (bndArac.Current as AV001_TDI_BIL_GEMI_UCAK_ARAC).ID;
            else if (bndGayrimenkul.Current != null)
                frmDavaKayit.GayrimenkulID = (bndGayrimenkul.Current as AV001_TI_BIL_GAYRIMENKUL).ID;
            else
                frmDavaKayit.DavaFoyKaydedildi += new EventHandler<DavaFoyKaydedildiEventArgs>(frmDavaKayit_DavaFoyKaydedildi);//Katman basıldıktan sonra dava dosya kayıtta collectiona eklenerek yukarıdaki gayrimenkul ve gua gibi yapılacak.

            if (kiymetTakdiriSikayetmi) frmDavaKayit.DavaFoyKaydedildi += frm_DavaFoyKaydedildi;
            if (satisIsleminiSikayetmi) frmDavaKayit.DavaFoyKaydedildi += frmKayit_DavaFoyKaydedildi;

            frmDavaKayit.Show();

            kiymetTakdiriSikayetmi = false;
            satisIsleminiSikayetmi = false;
        }

        #endregion Methods
    }

    #region <MB-20101201> MalAracTipi Enum

    public enum MalTakipKategori
    {
        TicariIsletmeRehni,
        TasinirRehniSatisi,
        IpotekSatisi,
        TasinmazHacziSatisi,
        TasinirHaczi,
    }

    #endregion <MB-20101201> MalAracTipi Enum

    #region <MB-20100901>TreeMalTakip Class

    public class TreeMalTakip
    {
        public TreeMalTakip(MalTakipKategori kategori, AV001_TI_BIL_HACIZ_CHILD hacizChild, AV001_TI_BIL_FOY myFoy)
        {
            SurecDoldur(kategori, hacizChild, myFoy);
        }

        public static AV001_TI_BIL_HACIZ_MASTER HacizMaster { get; set; }

        public static TList<AV001_TI_BIL_ISTIHKAK> Istihkak { get; set; }

        public static TList<AV001_TI_BIL_KIYMET_TAKDIRI> KiymetTakdiri { get; set; }

        public static TList<AV001_TI_BIL_SATIS_CHILD> SatisChild { get; set; }

        public static TList<AV001_TI_BIL_SATIS_MASTER> SatisMaster { get; set; }

        private List<MalNode> NodeListesi { get; set; }

        public List<MalNode> GetNodeList()
        {
            return NodeListesi;
        }

        public void NodeEkle(MalNode node)
        {
            if ((int)node.Node > 499 && !node.Value.HasValue)
            {
                return;
            }
            NodeListesi.Add(node);
        }

        private void SurecDoldur(MalTakipKategori malKategori, AV001_TI_BIL_HACIZ_CHILD child, AV001_TI_BIL_FOY foy)
        {
            this.NodeListesi = new List<MalNode>();

            #region Alanları Doldur

            if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
                NodeEkle(new MalNode { Name = "İhtiyati/kesin haciz T.(İİK.m.91,102)", Node = MalNode.MalNodeName.HACIZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori == MalTakipKategori.TasinirHaczi)
                NodeEkle(new MalNode { Name = "İhtiyati/kesin haciz T.", Node = MalNode.MalNodeName.HACIZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori == MalTakipKategori.IpotekSatisi)
                NodeEkle(new MalNode { Name = "Takibe Geçildiğinin Tapu Siciline Bildirildiği T.(İİK.m.150/C)", Node = MalNode.MalNodeName.IIK_150_C_SERHI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else
                NodeEkle(new MalNode { Name = "Takibe Geçildiğinin Ticaret Sicile Bildirildiği T.", Node = MalNode.MalNodeName.IIK_150_C_SERHI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            if (malKategori == MalTakipKategori.TicariIsletmeRehni)
            {
                NodeEkle(new MalNode { Name = "1447 sayılı Yasa m.14.İhtiyati haciz alındığı T.", Node = MalNode.MalNodeName.KARAR_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İhtiyati haczin uygulandığı T.", Node = MalNode.MalNodeName.IHTIYATI_HACIZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori == MalTakipKategori.TicariIsletmeRehni)
                NodeEkle(new MalNode { Name = "Muhafaza T. (1447 sy.K.m.16)", Node = MalNode.MalNodeName.MUHAFAZA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori == MalTakipKategori.TasinirRehniSatisi || malKategori == MalTakipKategori.IpotekSatisi)
                NodeEkle(new MalNode { Name = "Muhafaza T. (İİK.m.150/g, 92/3)", Node = MalNode.MalNodeName.MUHAFAZA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
                NodeEkle(new MalNode { Name = "Muhafaza T. (İİK.m.92/3)", Node = MalNode.MalNodeName.MUHAFAZA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else
                NodeEkle(new MalNode { Name = "Muhafaza T. (İİK.m.88)", Node = MalNode.MalNodeName.MUHAFAZA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });

            if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
                NodeEkle(new MalNode { Name = "Kiracıya Muhtıra Tebliği(İİK.m.92/3)", Node = MalNode.MalNodeName.IIK_M_150_B_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori != MalTakipKategori.TasinirHaczi && malKategori != MalTakipKategori.TasinirRehniSatisi)
                NodeEkle(new MalNode { Name = "İİK.m.150/b gereği kiracıya muhtıra tebliğ T.", Node = MalNode.MalNodeName.IIK_M_150_B_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });

            if (malKategori == MalTakipKategori.IpotekSatisi)
                NodeEkle(new MalNode { Name = "İcra Kıymet Takdiri T.(İİK.m.150/d)", Node = MalNode.MalNodeName.KIYMET_TAKDIRI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
                NodeEkle(new MalNode { Name = "İcra Kıymet Takdiri T.(İİK.m.102)", Node = MalNode.MalNodeName.KIYMET_TAKDIRI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else
                NodeEkle(new MalNode { Name = "İcra Kıymet Takdiri T.", Node = MalNode.MalNodeName.KIYMET_TAKDIRI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });

            NodeEkle(new MalNode { Name = "Kıymet Takdiri şikayet T.", Node = MalNode.MalNodeName.KIYMET_TAKDIRI_SIKAYET_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Mahkemece yaptırılan kıymet takdiri T.", Node = MalNode.MalNodeName.KIYMET_TAKDIRI_TEBLIG_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Kıymet Takdirinin Kesinleştiği T.", Node = MalNode.MalNodeName.DEGERIN_KESINLESME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            if (malKategori != MalTakipKategori.TasinmazHacziSatisi && malKategori != MalTakipKategori.TasinirHaczi)
            {
                NodeEkle(new MalNode { Name = "Geçici Rehin Açığı Belgesi Alındığı T.(İİK.m.150/f-1) ", Node = MalNode.MalNodeName.GECICI_REHIN_ACIGI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Geçici Rehin Açığı Nedeniyle Haciz Yapıldığı T.(İİK.m.150/f-2)", Node = MalNode.MalNodeName.GECICI_HACIZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            else if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
            {
                NodeEkle(new MalNode { Name = "Meskeniyet Davası T. (İİK.m.82/b.12)", Node = MalNode.MalNodeName.MESKENIYET_DAVA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Meskeniyet Davası Sonucu T.", Node = MalNode.MalNodeName.MESKENIYET_DAVA_SONUCU_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori != MalTakipKategori.IpotekSatisi && malKategori != MalTakipKategori.TasinmazHacziSatisi)
            {
                NodeEkle(new MalNode { Name = "İstihkak İddiası T.", Node = MalNode.MalNodeName.ISTIHKAK_IDDIA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İstihkak İddiasının Alacaklıya Tebliğ T.", Node = MalNode.MalNodeName.ISTIHKAK_IDDIASININ_ALACAKLIYA_TEBLIG_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İstihkak İddiasına Alacaklının İtiraz T.", Node = MalNode.MalNodeName.ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İİK.m.97 gereği İHUM'ne Sevk T.", Node = MalNode.MalNodeName.SEVK_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İHUM'nin satışı durdurma T.", Node = MalNode.MalNodeName.SATIS_DURDURMA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });//db Alan Eklenecek.
                NodeEkle(new MalNode { Name = "İHUM'nin satışa devam kararı T.", Node = MalNode.MalNodeName.SATIS_DEVAM_KARARI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });//db Alan Eklenecek.
                NodeEkle(new MalNode { Name = "İHUM'nin kararının 'İstihkak İddia Edene' tebliğ T.", Node = MalNode.MalNodeName.TEBLIG_ISTIHKAK_DAVASI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });//db Alan Eklenecek.
                NodeEkle(new MalNode { Name = "İstihkak Davası T.", Node = MalNode.MalNodeName.ISTIHKAK_DAVASI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İİK.m.97/18 gereği Karşı dava Tasarrufun İptali T.", Node = MalNode.MalNodeName.IIK_M_97_GORE_SEVK_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İstihkak Davası Sonucu T.", Node = MalNode.MalNodeName.ISTIHKAK_DAVASI_KARAR_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Alacaklı Tarafından İİK.m.99 gereği Açılan Dava T.", Node = MalNode.MalNodeName.BANKAMIZCA_IIK_M_99_GORE_ACILAN_DAVA_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Alacaklının İİK.m.99 davasının sonucu T.", Node = MalNode.MalNodeName.ALACAKLI_DAVA_SONUCU_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori == MalTakipKategori.TasinirHaczi)
                NodeEkle(new MalNode { Name = "Haczin Kesinleştiği T.", Node = MalNode.MalNodeName.HACZIN_KESINLESME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            else
                NodeEkle(new MalNode { Name = "Borçlulara İcra/Ödeme Emri Tebliğ (İİK.m.150/e)", Node = MalNode.MalNodeName.ODEME_EMRI_TEBLIG_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Borçlular Hakkında Takibin Kesinleştiği T.", Node = MalNode.MalNodeName.TAKIBIN_KESINLESTIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış Talep T.", Node = MalNode.MalNodeName.SATIS_ISTEME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satışa Dair İcra Müdürlüğünün Karar T.", Node = MalNode.MalNodeName.SATIS_KARAR_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış Avansının Yatırıldığı T.", Node = MalNode.MalNodeName.SATIS_AVANSININ_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış İlanının Divanhaneye Asıldığı T.", Node = MalNode.MalNodeName.DIVANHANE_ILAN_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış İlanının Büyük Gazetede İlan T.", Node = MalNode.MalNodeName.ILAN_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış İlanının Yerel Gazetede İlan T.", Node = MalNode.MalNodeName.YEREL_GAZETE_ILAN_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış İlanının Mahalle Muhtarlığında İlan T.", Node = MalNode.MalNodeName.MAHALLE_MUHTARLIGINDA_ILAN_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış İlanının Divanhaneden İndirildiği T.", Node = MalNode.MalNodeName.ILANI_DIVANHANEDEN_INDIRME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "1.Satış T.", Node = MalNode.MalNodeName.SATIS_TARIHI_1, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "2.Satış T.", Node = MalNode.MalNodeName.SATIS_TARIHI_2, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satışın Gerçekleşme T.", Node = MalNode.MalNodeName.SATIS_GERCEKLESME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "İhalenin Feshi Davası T.", Node = MalNode.MalNodeName.IHALENIN_FESHI_DAVASI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "İhalenin Kesinleştiği T.", Node = MalNode.MalNodeName.SATIS_KESINLESME_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Damga Vergisinin Yatırıldığı T.", Node = MalNode.MalNodeName.DAMGA_VERGISININ_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Tellaliyenin Yatırıldığı T.", Node = MalNode.MalNodeName.DELLALIYENIN_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "KDV Yatırıldığı T.", Node = MalNode.MalNodeName.KDV_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Bedel Yatırıldı veya Mahsup Beyanında Bulunulduğu T.", Node = MalNode.MalNodeName.SATIS_BEDELININ_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });// ya da MAHSUP_BEYAN_TARIHI
            NodeEkle(new MalNode { Name = "Satış Bedelinin Esas Dosyaya Gönderildiği T.", Node = MalNode.MalNodeName.SATIS_BEDELININ_DOSYAYA_GONDERILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Sıra cetveli Yapıldığı T.", Node = MalNode.MalNodeName.SIRA_CETVELININ_YAPILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "İsabet Eden Pay Teminat Mektubuyla Alındığı T.(İİK.142/a)", Node = MalNode.MalNodeName.SATIS_BEDELININ_TEMINAT_MEKTUBU_ILE_ALINDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Sıra Cetveline Karşı Şikayet T.", Node = MalNode.MalNodeName.SIRA_CETVELINE_KARSI_SIKAYET_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Sıra Cetveline Karşı İtiraz T.", Node = MalNode.MalNodeName.SIRA_CETVELINE_KARSI_ITIRAZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Sıra Cetvelinin Kesinleştiği T.", Node = MalNode.MalNodeName.SIRA_CETVELININ_KESINLESTIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Tahsil Harcının Yatırıldığı T.", Node = MalNode.MalNodeName.TAHSIL_HARCI_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Cezaevi YPB Yatırıldığı T.", Node = MalNode.MalNodeName.CEZAEVI_HARCI_YATIRILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Satış Bedelinin Çekildiği T.", Node = MalNode.MalNodeName.SATIS_BEDELININ_CEKILDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            NodeEkle(new MalNode { Name = "Teminat Mektubunun İade T.", Node = MalNode.MalNodeName.TEMINAT_MEKTUPLARININ_IADE_ALINDIGI_TARIH, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
            {
                NodeEkle(new MalNode { Name = "Alacağına Mahsuben taşınamz alan yabancı sermayeli bankanın valilik izni için Müracaat T.", Node = MalNode.MalNodeName.VALILIK_IZNI_MURACAAT_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Valilik İzni T.", Node = MalNode.MalNodeName.VALILIK_IZNI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            else if (malKategori != MalTakipKategori.TasinirHaczi)
            {
                NodeEkle(new MalNode { Name = "Kesin Rehin Açığı Belgesi Alındığı T.(İİK.m.152/1)", Node = MalNode.MalNodeName.KESIN_REHIN_ACIGI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Açık Kalan Kısım İçin Haciz Yapıldığı T.(İİK.m.152/2)", Node = MalNode.MalNodeName.EK_HACIZ_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori == MalTakipKategori.IpotekSatisi)
            {
                NodeEkle(new MalNode { Name = "Alacağına Mahsuben taşınamaz alan yabancı sermayeli bankanın valilik izni için Müracaat T.", Node = MalNode.MalNodeName.VALILIK_IZNI_MURACAAT_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Valilik İzni T.", Node = MalNode.MalNodeName.VALILIK_IZNI_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori != MalTakipKategori.IpotekSatisi && malKategori != MalTakipKategori.TasinmazHacziSatisi)
            {
                NodeEkle(new MalNode { Name = "Tahliye ve Teslim Alındığı T.", Node = MalNode.MalNodeName.TAHLIYE_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Muhasebeye Maliyet Bildirimi T.", Node = MalNode.MalNodeName.GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            else if (malKategori != MalTakipKategori.TasinirHaczi)
            {
                NodeEkle(new MalNode { Name = "İİK.m.135 gereğince tahliye emri talep T.", Node = MalNode.MalNodeName.TAHLIYE_EMRI_TALEP_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "İİK.m.135 tebliğ T.", Node = MalNode.MalNodeName.TAHLIYE_EMRI_TEBLIG_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Cebri Tescil T.", Node = MalNode.MalNodeName.CEBRI_TESCIL_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
                NodeEkle(new MalNode { Name = "Tahliye ve Teslim Alındığı T.", Node = MalNode.MalNodeName.TAHLIYE_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });
            }
            if (malKategori == MalTakipKategori.IpotekSatisi || malKategori == MalTakipKategori.TasinmazHacziSatisi)
                NodeEkle(new MalNode { Name = "Muhasebeye Maliyet Bildirimi T.", Node = MalNode.MalNodeName.GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI, ParentNode = MalNode.MalNodeName.ROOT, imageIndex = 9 });

            #endregion Alanları Doldur

            #region Değerleri Getir

            if (malKategori == MalTakipKategori.TasinmazHacziSatisi)
            {
                NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.MESKENIYET_DAVA_TARIHI, Value = child.MESKENIYET_DAVA_TARIHI, imageIndex = 9 });

                //NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.MESKENIYET_DAVA_SONUCU_TARIHI, imageIndex = 9 });//Alan bulunamadı.
            }
            if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.BANKAMIZCA_IIK_M_99_GORE_ACILAN_DAVA_TARIHI) != null)
                NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.BANKAMIZCA_IIK_M_99_GORE_ACILAN_DAVA_TARIHI, Value = child.BANKAMIZCA_IIK_M_99_GORE_ACILAN_DAVA_TARIHI, imageIndex = 9 });
            if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.HACZIN_KESINLESME_TARIHI) != null)
                NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.HACZIN_KESINLESME_TARIHI, imageIndex = 9, Value = child.HACZIN_KESINLESME_TARIHI });
            if (HacizMaster != null)
            {
                if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.HACIZ_TARIHI) != null)
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.HACIZ_TARIHI, Value = HacizMaster.HACIZ_TARIHI, imageIndex = 9 });
                if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.IHTIYATI_HACIZ_TARIHI) != null)
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.IHTIYATI_HACIZ_TARIHI, Value = HacizMaster.HACIZ_TARIHI, imageIndex = 9 });
                if (child.HACIZ_ISLEM_DURUM_ID == 2)//MUHAFAZA VAR
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.MUHAFAZA_TARIHI, imageIndex = 9, Value = HacizMaster.HACIZ_TARIHI });
            }
            if (SatisChild != null)
                SatisChild.ForEach(item =>
                {
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.IIK_150_C_SERHI_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.IIK_150_C_SERHI_TARIHI, Value = item.IIK_150_C_SERHI_TARIHI, imageIndex = 9 });
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.IIK_M_150_B_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.IIK_M_150_B_TARIHI, Value = item.IIK_M_150_B_TARIHI, imageIndex = 9 });
                    if (item.SATIS_ISLEMINI_SIKAYET_DAVA_FOY_ID.HasValue)
                    {
                        var ihaleninFeshiDavaTarihi = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item.SATIS_ISLEMINI_SIKAYET_DAVA_FOY_ID.Value).DAVA_TARIHI.Value;
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.IHALENIN_FESHI_DAVASI_TARIHI, Value = ihaleninFeshiDavaTarihi, NodePreview = item.SATIS_MAL_DEGERINE_ITIRAZ_SONUCU, imageIndex = 9 });
                    }
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI, Value = item.GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI, imageIndex = 9 });

                    if (malKategori != MalTakipKategori.TasinirHaczi)
                    {
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ODEME_EMRI_TEBLIG_TARIHI, Value = item.BORCLULARA_ICRA_ODEME_EMRI_TEBLIG_TARIHI, imageIndex = 9 });//*
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TAHLIYE_EMRI_TEBLIG_TARIHI, Value = item.TAHLIYE_EMRI_TEBLIG_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.CEBRI_TESCIL_TARIHI, Value = item.CEBRI_TESCIL_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TAHLIYE_TARIHI, Value = item.TAHLIYE_TARIHI, imageIndex = 9 });
                    }
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.TAKIBIN_KESINLESTIGI_TARIH) != null)//*
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TAKIBIN_KESINLESTIGI_TARIH, Value = item.BORCLULAR_HAKKINDA_TAKIBIN_KESINLESTIGI_TARIH, imageIndex = 9 });//*
                });
            if (foy != null)
            {
                var ihtiyatiHacizList = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByICRA_FOY_ID(foy.ID);
                if (ihtiyatiHacizList != null)
                    ihtiyatiHacizList.ForEach(item =>
                    {
                        if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.KARAR_TARIHI) != null)
                            NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KARAR_TARIHI, Value = item.KARAR_TARIHI, imageIndex = 9 });
                    });
            }
            if (KiymetTakdiri != null)
            {
                DataRepository.AV001_TI_BIL_KIYMET_TAKDIRIProvider.DeepLoad(KiymetTakdiri, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP));
                KiymetTakdiri.ForEach(item =>
                {
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KIYMET_TAKDIRI_TARIHI, Value = item.KIYMET_TAKDIRI_TARIHI, NodePreview = "Biçilen Değer= " + item.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI + item.HACIZLI_MAL_MIKTARI_BIRIM_FIYATI_DOVIZ_IDSource.DOVIZ_KODU, imageIndex = 9 });

                    if (item.SIKAYET_DAVA_FOY_ID.HasValue)
                    {
                        var davaTarihi = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item.SIKAYET_DAVA_FOY_ID.Value).DAVA_TARIHI;
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KIYMET_TAKDIRI_SIKAYET_TARIHI, Value = davaTarihi.Value, imageIndex = 9 });
                    }
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KIYMET_TAKDIRI_TEBLIG_TARIHI, Value = item.KIYMET_TAKDIRI_TEBLIG_TARIHI, imageIndex = 9 });//Açıklama
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.DEGERIN_KESINLESME_TARIHI, Value = item.DEGERIN_KESINLESME_TARIHI, imageIndex = 9 });
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.GECICI_REHIN_ACIGI_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.GECICI_REHIN_ACIGI_TARIHI, Value = item.RAPOR_TARIHI1, imageIndex = 9 });
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.GECICI_HACIZ_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.GECICI_HACIZ_TARIHI, Value = item.RAPOR_TARIHI2, imageIndex = 9 });
                });
            }
            if (malKategori != MalTakipKategori.IpotekSatisi && malKategori != MalTakipKategori.TasinmazHacziSatisi)
            {
                if (Istihkak != null)
                    Istihkak.ForEach(item =>
                    {
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ISTIHKAK_IDDIA_TARIHI, Value = item.ISTIHKAK_IDDIA_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI, Value = item.ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ISTIHKAK_IDDIASININ_ALACAKLIYA_TEBLIG_TARIHI, Value = item.ISTIHKAK_IDDIASI_ALACAKLIYA_TEBLIG_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SEVK_TARIHI, Value = item.IIK_M_97_IHUM_SEVK_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TEBLIG_ISTIHKAK_DAVASI_TARIHI, Value = item.IHUM_KARARININ_ISTIHKAK_EDENE_TEBLIG_TARIHI, imageIndex = 9 });//*
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_DURDURMA_TARIHI, Value = item.IHUM_SATIS_DURDURMA_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_DEVAM_KARARI_TARIHI, Value = item.IHUM_SATISA_DEVAM_KARARI_TARIHI, imageIndex = 9 });
                        if (item.DAVA_FOY_ID.HasValue)
                        {
                            var istihkakDavaT = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(item.DAVA_FOY_ID.Value).DAVA_TARIHI.Value;
                            NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ISTIHKAK_DAVASI_TARIHI, Value = istihkakDavaT, imageIndex = 9 });
                        }
                    });
            }
            if (SatisMaster != null)
                SatisMaster.ForEach(item =>
                {
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.IIK_M_97_GORE_SEVK_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.IIK_M_97_GORE_SEVK_TARIHI, Value = item.IIK_M_97_GORE_SEVK_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_ISTEME_TARIHI, Value = item.SATIS_ISTEME_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_KARAR_TARIHI, Value = item.SATISA_DAIR_ICRA_MUDURLUGU_KARAR_TARIHI, imageIndex = 9 });//Açıklama alan bulunamadı.*
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_AVANSININ_YATIRILDIGI_TARIH, Value = item.DELLALIYENIN_YATIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.DIVANHANE_ILAN_TARIHI, Value = item.SATIS_ILANININ_DIVANHANEYE_ASILDIGI_TARIH, imageIndex = 9 }); //*
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ILAN_TARIHI, Value = item.ILAN_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.YEREL_GAZETE_ILAN_TARIHI, Value = item.SATIS_ILANININ_YEREL_GAZETEDE_ILAN_TARIHI, imageIndex = 9 }); //*
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.MAHALLE_MUHTARLIGINDA_ILAN_TARIHI, Value = item.SATIS_ILANININ_MAH_MUHTARLIGI_ILAN_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.ILANI_DIVANHANEDEN_INDIRME_TARIHI, Value = item.SATIS_ILANININ_DIVANHANEDEN_INDIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_TARIHI_1, Value = item.SATIS_TARIHI_1, NodePreview = item.SATIS_NETICESI_1, imageIndex = 9 }); //*
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_TARIHI_2, Value = item.SATIS_TARIHI_2, NodePreview = item.SafeName_SATIS_NETICES__2, imageIndex = 9 });// *
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TAHSIL_HARCI_YATIRILDIGI_TARIH, Value = item.TAHSIL_HARCININ_YATIRILDIGI_TARIH, imageIndex = 9 });// *
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.CEZAEVI_HARCI_YATIRILDIGI_TARIH, Value = item.CEZAEVI_YPB_YATIRILDIGI_TARIH, imageIndex = 9 });// *
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_GERCEKLESME_TARIHI, Value = item.SATIS_GERCEKLESME_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_KESINLESME_TARIHI, Value = item.SATIS_KESINLESME_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.DAMGA_VERGISININ_YATIRILDIGI_TARIH, Value = item.DAMGA_VERGISININ_YATIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.DELLALIYENIN_YATIRILDIGI_TARIH, Value = item.DELLALIYENIN_YATIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KDV_YATIRILDIGI_TARIH, Value = item.KDV_NIN_YATIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_BEDELININ_YATIRILDIGI_TARIH, Value = item.SATIS_BEDELININ_YATIRILDIGI_TARIH, imageIndex = 9 });// ya da MAHSUP_BEYAN_TARIHI
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_BEDELININ_DOSYAYA_GONDERILDIGI_TARIH, Value = item.SATIS_BEDELININ_YATIRILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SIRA_CETVELININ_YAPILDIGI_TARIH, Value = item.SIRA_CETVELININ_YAPILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_BEDELININ_TEMINAT_MEKTUBU_ILE_ALINDIGI_TARIH, Value = item.SATIS_BEDELININ_TEMINAT_MEKTUBU_ILE_ALINDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SIRA_CETVELINE_KARSI_SIKAYET_TARIHI, Value = item.SIRA_CETVELINE_KARSI_SIKAYET_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SIRA_CETVELINE_KARSI_ITIRAZ_TARIHI, Value = item.SIRA_CETVELINE_KARSI_ITIRAZ_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SIRA_CETVELININ_KESINLESTIGI_TARIH, Value = item.SIRA_CETVELININ_KESINLESTIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_BEDELININ_CEKILDIGI_TARIH, Value = item.SATIS_BEDELININ_CEKILDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TEMINAT_MEKTUPLARININ_IADE_ALINDIGI_TARIH, Value = item.TEMINAT_MEKTUPLARININ_IADE_ALINDIGI_TARIH, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_DURDURMA_TARIHI, Value = item.IHUM_SATIS_DURDURMA_TARIHI, imageIndex = 9 });
                    NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.SATIS_DEVAM_KARARI_TARIHI, Value = item.IHUM_SATISA_DEVAM_KARARI_TARIHI, imageIndex = 9 });
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.KESIN_REHIN_ACIGI_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.KESIN_REHIN_ACIGI_TARIHI, Value = item.MAHSUP_BEYAN_TARIHI, imageIndex = 9 });
                    if (NodeListesi.Find(vi => vi.Node == MalNode.MalNodeName.EK_HACIZ_TARIHI) != null)
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.EK_HACIZ_TARIHI, Value = item.ACIK_KALAN_KISIM_ICIN_HACIZ_YAPILDIGI_TARIH, imageIndex = 9 });

                    if (malKategori == MalTakipKategori.IpotekSatisi || malKategori == MalTakipKategori.TasinmazHacziSatisi)
                    {
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.VALILIK_IZNI_MURACAAT_TARIHI, Value = item.VALILIK_IZNI_MURACAAT_TARIHI, imageIndex = 9 });
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.VALILIK_IZNI_TARIHI, Value = item.VALILIK_IZNI_TARIHI, imageIndex = 9 });//*
                        NodeEkle(new MalNode { Name = "", Node = MalNode.UniqNodeID, ParentNode = MalNode.MalNodeName.TAHLIYE_EMRI_TALEP_TARIHI, Value = item.IIK_M_135_TAHLIYE_EMRI_TALEP_TARIHI, imageIndex = 9 });
                    }
                });

            #endregion Değerleri Getir
        }

        public class MalNode
        {
            private static MalNodeName _UniqNodeID = (MalNodeName)500;

            public enum MalNodeName
            {
                ROOT = 0,
                HACZIN_KESINLESME_TARIHI,
                IHTIYATI_HACIZ_TARIHI,
                BANKAMIZCA_IIK_M_99_GORE_ACILAN_DAVA_TARIHI,
                ISTIHKAK_IDDIA_TARIHI,
                ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI,
                ISTIHKAK_IDDIASININ_ALACAKLIYA_TEBLIG_TARIHI,
                IIK_M_97_GORE_SEVK_TARIHI,
                KIYMET_TAKDIRI_TEBLIG_TARIHI,
                KIYMET_TAKDIRI_TARIHI,
                DEGERIN_KESINLESME_TARIHI,
                HACIZ_TARIHI,
                IIK_150_C_SERHI_TARIHI,
                IIK_M_150_B_TARIHI,
                IMAR_DURUMU_CELP_TARIHI,
                SATIS_ISTEME_TARIHI,
                SATIS_TARIHI_1,
                SATIS_TARIHI_2,
                SATIS_GERCEKLESME_TARIHI,
                SATIS_BEDELININ_YATIRILDIGI_TARIH,
                SATIS_BEDELININ_DOSYAYA_GONDERILDIGI_TARIH,
                SIRA_CETVELINE_KARSI_ITIRAZ_TARIHI,
                SATIS_KESINLESME_TARIHI,
                SIRA_CETVELININ_KESINLESTIGI_TARIH,
                TAHSIL_HARCI_YATIRILDIGI_TARIH,
                CEZAEVI_HARCI_YATIRILDIGI_TARIH,
                SATIS_BEDELININ_TEMINAT_MEKTUBU_ILE_ALINDIGI_TARIH,
                SATIS_BEDELININ_CEKILDIGI_TARIH,
                TAHLIYE_EMRI_TEBLIG_TARIHI,
                TAHLIYE_TARIHI,
                MESKENIYET_DAVA_TARIHI,
                MESKENIYET_DAVA_SONUCU_TARIHI,
                KARAR_TARIHI,
                GECICI_REHIN_ACIGI_TARIHI,
                GECICI_HACIZ_TARIHI,
                MUHAFAZA_TARIHI,
                ODEME_EMRI_TEBLIG_TARIHI,
                TAKIBIN_KESINLESTIGI_TARIH,
                SATIS_KARAR_TARIHI,
                DELLALIYENIN_YATIRILDIGI_TARIH,
                SATIS_AVANSININ_YATIRILDIGI_TARIH,
                DIVANHANE_ILAN_TARIHI,
                ILAN_TARIHI,
                YEREL_GAZETE_ILAN_TARIHI,
                MAHALLE_MUHTARLIGINDA_ILAN_TARIHI,
                ILANI_DIVANHANEDEN_INDIRME_TARIHI,
                DAMGA_VERGISININ_YATIRILDIGI_TARIH,
                KDV_YATIRILDIGI_TARIH,
                SIRA_CETVELININ_YAPILDIGI_TARIH,
                SIRA_CETVELINE_KARSI_SIKAYET_TARIHI,
                TEMINAT_MEKTUPLARININ_IADE_ALINDIGI_TARIH,
                KESIN_REHIN_ACIGI_TARIHI,
                EK_HACIZ_TARIHI,
                GENEL_MUHASEBEYE_MALIYET_BILDIRIM_TARIHI,
                ISTIHKAK_DAVASI_KARAR_TARIHI,
                ISTIHKAK_DAVASI_TARIHI,
                ALACAKLI_DAVA_SONUCU_TARIHI,
                IHALENIN_FESHI_DAVASI_TARIHI,
                KIYMET_TAKDIRI_SIKAYET_TARIHI,
                SEVK_TARIHI,
                SATIS_DURDURMA_TARIHI,
                SATIS_DEVAM_KARARI_TARIHI,
                TEBLIG_ISTIHKAK_DAVASI_TARIHI,
                TAHLIYE_EMRI_TALEP_TARIHI,
                CEBRI_TESCIL_TARIHI,
                VALILIK_IZNI_MURACAAT_TARIHI,
                VALILIK_IZNI_TARIHI,
            }

            public static MalNodeName UniqNodeID
            {
                get
                {
                    int ID = (int)_UniqNodeID;
                    _UniqNodeID = (MalNodeName)(++ID);
                    return _UniqNodeID;
                }
            }

            public int imageIndex { get; set; }

            public string Name { get; set; }

            public MalNodeName Node { get; set; }

            public string NodePreview { get; set; }

            public MalNodeName ParentNode { get; set; }

            public DateTime? Value { get; set; }
        }
    }

    #endregion <MB-20100901>TreeMalTakip Class
}