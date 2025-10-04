using System;

using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Util;

using AvukatProLib.Extras;
using AvukatProLib.Hesap;

using AvukatProLib2.Data;
using AvukatProLib2.Entities;

using BelgeUtil;

using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Muhasebe
{
    public partial class rfrmMuhasebeGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        private AV001_TDI_BIL_MASRAF_AVANS _MyMasrafAvans;
        private TList<AV001_TDI_BIL_MASRAF_AVANS> avanslar = new TList<AV001_TDI_BIL_MASRAF_AVANS>();
        private bool DisardanGeldi;
        private AV001_TD_BIL_FOY kaynakDavaFoy;
        private AV001_TI_BIL_FOY kaynakFoy;
        private AV001_TD_BIL_HAZIRLIK kaynakHFoy;
        private AV001_TDI_BIL_SOZLESME kaynakSozlesmeFoy;

        #endregion Fields

        #region Constructors

        public rfrmMuhasebeGiris()
        {
            InitializeComponent();
            InitializeEvents();
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> KayitTamamlandi;

        public event EventHandler<HukukMuhasebesiEventArgs> MuhasebeKaydedildi;

        #endregion Events

        #region Properties

        public AvukatProLib.Extras.Modul IcraHesapTipi
        {
            get;
            set;
        }

        public AV001_TDI_BIL_MASRAF_AVANS MyMasrafAvans
        {
            get { return _MyMasrafAvans; }
            set
            {
                _MyMasrafAvans = value;

                value.ColumnChanged += MyMasrafAvans_ColumnChanged;
            }
        }

        #endregion Properties

        #region Methods

        public static string RefNoUret()
        {
            int NumberForRefNo = 0;
            string uretilenRefNo = String.Format("REF-{0}~{1}~{2}", DateTime.Today.Year, DateTime.Now.Hour,
                                                 NumberForRefNo);
            NumberForRefNo++;
            return uretilenRefNo;
        }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
            this.Button_PDF_Click += btnPdf_ItemClick;
            this.Button_Excel_Click += btnExcel_ItemClick;
            this.Button_Outlook_Click += btnOutLook_ItemClick;
            this.Button_Word_Click += btnWord_ItemClick;
            this.Button_Editor_Click += btnEditor_ItemClick;
        }

        /// <summary>
        /// Masraf Avans nesnesinin baðlý bulunduðu modül ü ve kayýt id sini veriyor
        /// </summary>
        /// <param name="masrafAvans"></param>
        /// <param name="kayitId"></param>
        /// <returns></returns>
        public AvukatProLib.Extras.Modul MasrafAvansToModulAndId(AV001_TDI_BIL_MASRAF_AVANS masrafAvans, out int kayitId)
        {
            AvukatProLib.Extras.Modul modul = AvukatProLib.Extras.Modul.Genel;
            kayitId = 0;
            if (masrafAvans.ICRA_FOY_ID.HasValue)
            {
                modul = AvukatProLib.Extras.Modul.Icra;
                kayitId = masrafAvans.ICRA_FOY_ID.Value;
            }
            else if (masrafAvans.DAVA_FOY_ID.HasValue)
            {
                modul = AvukatProLib.Extras.Modul.Dava;
                kayitId = masrafAvans.DAVA_FOY_ID.Value;
            }
            else if (masrafAvans.HAZIRLIK_ID.HasValue)
            {
                modul = AvukatProLib.Extras.Modul.Sorusturma;
                kayitId = masrafAvans.HAZIRLIK_ID.Value;
            }

            //else if (masrafAvans.RUCU_ID.HasValue)
            //{
            //    modul = AvukatProLib.Extras.Modul.Rucu;
            //    kayitId = masrafAvans.RUCU_ID.Value;
            //}

            return modul;
        }

        /// <summary>
        ///  Gelen Kayda göre ilk deðerleri hazýrlar
        /// </summary>
        /// <param name="kaynak">Icra Foy tipinden bir nesne alýr</param>
        public void Show(AV001_TI_BIL_FOY kaynak)
        {
            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            }

            MyMasrafAvans.MASRAF_AVANS_TIP = 1;
            MyMasrafAvans.CARI_HESAP_HEDEF_TIP = 1;
            MyMasrafAvans.ICRA_FOY_ID = kaynak.ID;
            MyMasrafAvans.CARI_ID = AvukatProLib.Kimlik.CurrentCariId;
            MyMasrafAvans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            MyMasrafAvans.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            MyMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            MyMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            MyMasrafAvans.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            MyMasrafAvans.REFERANS_NO = RefNoUret();
            kaynakFoy = kaynak;
            DisardanGeldi = true;

            cARI_HESAP_HEDEF_TIPLookUpEdit.Enabled = false;

            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME kaynak)
        {
            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            }
            MyMasrafAvans.ColumnChanged += MyMasrafAvans_ColumnChanged;

            MyMasrafAvans.MASRAF_AVANS_TIP = 1;
            MyMasrafAvans.CARI_HESAP_HEDEF_TIP = 5;
            MyMasrafAvans.SOZLESME_ID = kaynak.ID;
            MyMasrafAvans.CARI_ID = AvukatProLib.Kimlik.CurrentCariId;
            MyMasrafAvans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            MyMasrafAvans.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            MyMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            MyMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            MyMasrafAvans.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            MyMasrafAvans.REFERANS_NO = RefNoUret();
            kaynakSozlesmeFoy = kaynak;
            DisardanGeldi = true;

            cARI_HESAP_HEDEF_TIPLookUpEdit.Enabled = false;

            this.Show();
        }

        /// <summary>
        /// Gelen Kayda göre ilk deðerleri hazýrlar
        /// </summary>
        /// <param name="kaynak"></param>
        public void Show(AV001_TD_BIL_FOY kaynak)
        {
            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            }
            MyMasrafAvans.MASRAF_AVANS_TIP = 1;
            MyMasrafAvans.CARI_HESAP_HEDEF_TIP = 2;
            MyMasrafAvans.DAVA_FOY_ID = kaynak.ID;
            MyMasrafAvans.CARI_ID = AvukatProLib.Kimlik.CurrentCariId;
            MyMasrafAvans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            MyMasrafAvans.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            MyMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            MyMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            MyMasrafAvans.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            MyMasrafAvans.REFERANS_NO = RefNoUret();
            kaynakDavaFoy = kaynak;
            DisardanGeldi = true;
            cARI_HESAP_HEDEF_TIPLookUpEdit.Enabled = false;

            this.Show();
        }

        public void Show(AvukatProLib.Extras.MasrafAvansTip Tip)
        {
            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            }
            MyMasrafAvans.MASRAF_AVANS_TIP = (int)Tip;
            MyMasrafAvans.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
            MyMasrafAvans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            MyMasrafAvans.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            MyMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            MyMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            MyMasrafAvans.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            MyMasrafAvans.REFERANS_NO = RefNoUret();
            DisardanGeldi = true;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK kaynak)
        {
            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            }
            MyMasrafAvans.MASRAF_AVANS_TIP = 1;
            MyMasrafAvans.CARI_HESAP_HEDEF_TIP = (int)AvukatProLib.Extras.Modul.Sorusturma;
            MyMasrafAvans.HAZIRLIK_ID = kaynak.ID;
            MyMasrafAvans.CARI_ID = AvukatProLib.Kimlik.CurrentCariId;
            MyMasrafAvans.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            MyMasrafAvans.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            MyMasrafAvans.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            MyMasrafAvans.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            MyMasrafAvans.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            MyMasrafAvans.REFERANS_NO = RefNoUret();
            kaynakHFoy = kaynak;
            this.Show();
        }

        private void btnEditor_ItemClick(object sender, EventArgs e)
        {
            frmEditor frmEdit = new frmEditor();
            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void btnExcel_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.xls, avanslar);
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            //KAYDET
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabBir =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgMasrafAvans.DataSource;
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabIki =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgHArclar.DataSource;
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgVekaletUcretleri.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabBir)
            {
                if (detay.BIRIM_FIYAT > 0)
                {
                    MyMasrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(detay);
                }
            }
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabIki)
            {
                if (detay.BIRIM_FIYAT > 0)
                {
                    MyMasrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(detay);
                }
            }
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                if (detay.BIRIM_FIYAT > 0)
                {
                    MyMasrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(detay);
                }
            }
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                MyMasrafAvans.MANUEL_KAYIT_MI = true;

                if (searchLookUpEdit1View.SelectedRowsCount > 0)
                {
                    int? id = (int?)searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetSelectedRows()[0], "ID");
                    if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Icra")
                    {
                        MyMasrafAvans.ICRA_FOY_ID = id;
                    }
                    else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Dava")
                    {
                        MyMasrafAvans.DAVA_FOY_ID = id;
                    }
                    else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Soruþturma")
                    {
                        MyMasrafAvans.HAZIRLIK_ID = id;
                    }
                    else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Sözleþme")
                    {
                        MyMasrafAvans.SOZLESME_ID = id;
                    }
                }

                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepSave(tran, MyMasrafAvans,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(
                                                                               TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                if (MuhasebeKaydedildi != null)
                {
                    MuhasebeKaydedildi(this, new HukukMuhasebesiEventArgs(MyMasrafAvans));
                }

                tran.Commit();
                if (kaynakFoy != null)
                    kaynakFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(MyMasrafAvans);
                if (kaynakHFoy != null)
                    kaynakHFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(MyMasrafAvans);
                if (kaynakDavaFoy != null)
                    kaynakDavaFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(MyMasrafAvans);
                if (kaynakSozlesmeFoy != null)
                    kaynakSozlesmeFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Add(MyMasrafAvans);

                AV001_TDI_BIL_FOY_MUHASEBE muhasebe = MasrafAvansToMuhasebe(MyMasrafAvans);
                MuhasebeAraclari.SetCariHesapByMasrafAvans(MyMasrafAvans.ID);

                //MuhasebeHelper.MasrafAvansToCariHesap(MyMasrafAvans);

                if (muhasebe != null)
                {
                    tran.BeginTransaction();
                    DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.DeepSave(tran, muhasebe,
                                                                               DeepSaveType.IncludeChildren,
                                                                               typeof(
                                                                                   TList
                                                                                   <AV001_TDI_BIL_FOY_MUHASEBE_DETAY>));
                    tran.Commit();
                }

                //-14.09.2012-MUHASEBE KAYDINDA OTOMATÝK OLUÞTURULAN KASA KAYDI ÝÞLEMÝ ÝPTAL EDÝLMÝÞTÝR.
                //MuhasebeHelper.MasrafAvansToKasa(MyMasrafAvans);
                if (this.KayitTamamlandi != null)
                    this.KayitTamamlandi(this, new EventArgs());

                XtraMessageBox.Show("Masraflar baþarýyla kaydedildi.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void btnOutLook_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pst, avanslar);
        }

        private void btnPdf_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.pdf, avanslar);
        }

        private void btnWord_ItemClick(object sender, EventArgs e)
        {
            Tools.OpenProgram(ExtensionToOpenProgram.doc, avanslar);
        }

        private void cARI_HESAP_HEDEF_TIPLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Soruþturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (cARI_HESAP_HEDEF_TIPLookUpEdit.Text == "Sözleþme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);

            if (!DisardanGeldi)
            {
                MyMasrafAvans.ICRA_FOY_NO = null;
                MyMasrafAvans.ICRA_FOY_ID = null;

                MyMasrafAvans.DAVA_FOY_NO = null;
                MyMasrafAvans.DAVA_FOY_ID = null;

                MyMasrafAvans.RUCU_ID = null;
                MyMasrafAvans.RUCU_NO = null;

                MyMasrafAvans.HAZIRLIK_NO = null;
                MyMasrafAvans.HAZIRLIK_ID = null;
            }

            lueDosya.Enabled = true;
        }

        private void ceBorclularaPaylastir_CheckedChanged(object sender, EventArgs e)
        {
            bORCLU_CARI_IDLookUpEdit.Enabled = !ceBorclularaPaylastir.Checked;
            if (ceBorclularaPaylastir.Checked)
            {
                MyMasrafAvans.BORCLU_CARI_ID = null;
                bORCLU_CARI_IDLookUpEdit.EditValue = null;
            }
            else if (!ceBorclularaPaylastir.Checked)
            {
                if (bORCLU_CARI_IDLookUpEdit.EditValue != null
                    && bORCLU_CARI_IDLookUpEdit.EditValue.ToString().Length > 0)
                {
                    MyMasrafAvans.BORCLU_CARI_ID = int.Parse(bORCLU_CARI_IDLookUpEdit.EditValue.ToString());
                }
            }
        }

        private void chkHarclarIncelendimi_CheckedChanged(object sender, EventArgs e)
        {
            //chkHarclarIncelendimi
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabIki =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgHArclar.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabIki)
            {
                detay.INCELENDI = chkHarclarIncelendimi.Checked;
            }
        }

        private void chkHarclarMuhasebe_CheckedChanged(object sender, EventArgs e)
        {
            //chkHarclarMuhasebe
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabIki =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgHArclar.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabIki)
            {
                detay.MuhasebelestirilecekMi = chkHarclarMuhasebe.Checked;
            }
            exgHArclar.RefreshDataSource();
        }

        private void chkHarclarOnay_CheckedChanged(object sender, EventArgs e)
        {
            //chkHarclarOnay
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabIki =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgHArclar.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabIki)
            {
                detay.Onaylandi = chkHarclarOnay.Checked;
            }
        }

        private void chkMasrafAvansIncelendi_CheckedChanged(object sender, EventArgs e)
        {
            //chkMasrafAvansIncelendi
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgMasrafAvans.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                detay.INCELENDI = chkMasrafAvansIncelendi.Checked;
            }
        }

        private void chkMasrafAvansOnay_CheckedChanged(object sender, EventArgs e)
        {
            //
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgMasrafAvans.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                detay.Onaylandi = chkMasrafAvansOnay.Checked;
            }
        }

        private void chkVekaletIncelendimi_CheckedChanged(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgVekaletUcretleri.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                detay.INCELENDI = chkVekaletIncelendimi.Checked;
            }
        }

        private void chkVekaletMuhasebeletirilsinmi_CheckedChanged(object sender, EventArgs e)
        {
            //chkVekaletMuhasebeletirilsinmi
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgVekaletUcretleri.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                detay.MuhasebelestirilecekMi = chkVekaletMuhasebeletirilsinmi.Checked;
            }
            exgVekaletUcretleri.RefreshDataSource();
        }

        private void chkVekaletOnaylandimi_CheckedChanged(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> tabUc =
                (TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>)exgVekaletUcretleri.DataSource;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in tabUc)
            {
                detay.Onaylandi = chkVekaletOnaylandimi.Checked;
            }
        }

        private void dty_ColumnChanged(object sender, AV001_TDI_BIL_MASRAF_AVANS_DETAYEventArgs e)
        {
            switch (e.Column)
            {
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.BIRIM_FIYAT:
                case AV001_TDI_BIL_MASRAF_AVANS_DETAYColumn.ADET:
                    AV001_TDI_BIL_MASRAF_AVANS_DETAY dty = sender as AV001_TDI_BIL_MASRAF_AVANS_DETAY;
                    if (dty != null)
                    {
                        dty.TOPLAM_TUTAR = dty.ADET * dty.BIRIM_FIYAT;
                    }
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Masrafavans nesnesinden muhasebeleþtirme yapýyor
        /// </summary>
        /// <param name="masrafAvans"></param>
        /// <returns></returns>
        private AV001_TDI_BIL_FOY_MUHASEBE MasrafAvansToMuhasebe(AV001_TDI_BIL_MASRAF_AVANS masrafAvans)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> secimler =
                masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;
            if (secimler.Count > 0)
            {
                AV001_TDI_BIL_FOY_MUHASEBE muhasebe = new AV001_TDI_BIL_FOY_MUHASEBE();
                muhasebe.DAVA_FOY_ID = masrafAvans.DAVA_FOY_ID;
                muhasebe.DAVA_FOY_NO = masrafAvans.DAVA_FOY_NO;

                muhasebe.HAZIRLIK_ID = masrafAvans.HAZIRLIK_ID;
                muhasebe.HAZIRLIK_NO = masrafAvans.HAZIRLIK_NO;

                muhasebe.ICRA_FOY_ID = masrafAvans.ICRA_FOY_ID;
                muhasebe.ICRA_FOY_NO = masrafAvans.ICRA_FOY_NO;

                muhasebe.MASRAF_AVANS_ID = masrafAvans.ID;
                muhasebe.OTOMATIK_HESAPLANDI = false;
                muhasebe.ACIKLAMA = masrafAvans.ACIKLAMA;
                muhasebe.SOZLESME_ID = masrafAvans.SOZLESME_ID;

                string esasNo = string.Empty;
                string dosyaNo = string.Empty;
                string adliye = string.Empty;
                string gorev = string.Empty;
                string no = string.Empty;
                string referans = string.Empty;
                int muhasebeHedefTip = (int)cARI_HESAP_HEDEF_TIPLookUpEdit.EditValue;

                if (muhasebe.SOZLESME_ID.HasValue)
                {
                    AV001_TDI_BIL_SOZLESME sozlesme =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(muhasebe.SOZLESME_ID.Value);
                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                                                                           typeof(TDI_KOD_ADLI_BIRIM_GOREV),
                                                                           typeof(TDI_KOD_ADLI_BIRIM_NO));
                    referans = "SZ";
                    esasNo = "----";
                    dosyaNo = "----";
                    muhasebeHedefTip = (int)AvukatProLib.Extras.Modul.Sozlesme;
                    if (sozlesme.ADLI_BIRIM_ADLIYE_IDSource != null)
                        adliye = sozlesme.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                    if (sozlesme.ADLI_BIRIM_GOREV_IDSource != null)
                        gorev = sozlesme.ADLI_BIRIM_GOREV_IDSource.GOREV;
                    if (sozlesme.ADLI_BIRIM_NO_IDSource != null)
                        no = sozlesme.ADLI_BIRIM_NO_IDSource.NO;
                }

                else if (muhasebe.HAZIRLIK_ID.HasValue)
                {
                    AV001_TD_BIL_HAZIRLIK hazirlik =
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(muhasebe.HAZIRLIK_ID.Value);
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(hazirlik, false, DeepLoadType.IncludeChildren,
                                                                          typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                                                                          typeof(TDI_KOD_ADLI_BIRIM_GOREV),
                                                                          typeof(TDI_KOD_ADLI_BIRIM_NO));

                    referans = "HZ";
                    esasNo = "----";
                    dosyaNo = "----";
                    muhasebeHedefTip = (int)AvukatProLib.Extras.Modul.Sorusturma;

                    if (hazirlik.ADLI_BIRIM_ADLIYE_IDSource != null)
                        adliye = hazirlik.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                    if (hazirlik.ADLI_BIRIM_GOREV_IDSource != null)
                        gorev = hazirlik.ADLI_BIRIM_GOREV_IDSource.GOREV;
                    if (hazirlik.ADLI_BIRIM_NO_IDSource != null)
                        no = hazirlik.ADLI_BIRIM_NO_IDSource.NO;
                }

                else if (muhasebe.DAVA_FOY_ID.HasValue)
                {
                    AV001_TD_BIL_FOY dava = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(muhasebe.DAVA_FOY_ID.Value);
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(dava, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                                                                     typeof(TDI_KOD_ADLI_BIRIM_GOREV),
                                                                     typeof(TDI_KOD_ADLI_BIRIM_NO));

                    referans = "DV";
                    esasNo = dava.ESAS_NO;
                    dosyaNo = dava.FOY_NO;
                    muhasebeHedefTip = (int)AvukatProLib.Extras.Modul.Dava;

                    if (dava.ADLI_BIRIM_ADLIYE_IDSource != null)
                        adliye = dava.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                    if (dava.ADLI_BIRIM_GOREV_IDSource != null)
                        gorev = dava.ADLI_BIRIM_GOREV_IDSource.GOREV;
                    if (dava.ADLI_BIRIM_NO_IDSource != null)
                        no = dava.ADLI_BIRIM_NO_IDSource.NO;
                }
                else if (muhasebe.ICRA_FOY_ID.HasValue)
                {
                    AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(muhasebe.ICRA_FOY_ID.Value);
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icra, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                                                                     typeof(TDI_KOD_ADLI_BIRIM_GOREV),
                                                                     typeof(TDI_KOD_ADLI_BIRIM_NO));

                    referans = "IC";
                    esasNo = icra.ESAS_NO;
                    dosyaNo = icra.FOY_NO;
                    muhasebeHedefTip = (int)AvukatProLib.Extras.Modul.Icra;

                    if (icra.ADLI_BIRIM_ADLIYE_IDSource != null)
                        adliye = icra.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                    if (icra.ADLI_BIRIM_GOREV_IDSource != null)
                        gorev = icra.ADLI_BIRIM_GOREV_IDSource.GOREV;
                    if (icra.ADLI_BIRIM_NO_IDSource != null)
                        no = icra.ADLI_BIRIM_NO_IDSource.NO;
                }

                if (referans.Length > 0)
                {
                    referans += muhasebe.KAYIT_TARIHI.Day + muhasebe.KAYIT_TARIHI.Month.ToString() +
                                muhasebe.KAYIT_TARIHI.Year + "-" + Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
                }

                DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.DeepLoad(
                    masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection, false, DeepLoadType.IncludeChildren,
                    typeof(TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI));

                foreach (
                    AV001_TDI_BIL_MASRAF_AVANS_DETAY detay in masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    AV001_TDI_BIL_FOY_MUHASEBE_DETAY muhasebeDetay =
                        muhasebe.AV001_TDI_BIL_FOY_MUHASEBE_DETAYCollection.AddNew();
                    muhasebeDetay.BIRIM_FIYAT = detay.BIRIM_FIYAT;
                    muhasebeDetay.BIRIM_FIYAT_DOVIZ_ID = detay.BIRIM_FIYAT_DOVIZ_ID;
                    muhasebeDetay.ADET = detay.ADET;
                    muhasebeDetay.GENEL_TOPLAM = detay.GENEL_TOPLAM;
                    muhasebeDetay.SSDF_ORAN = detay.SSDF_ORAN;
                    muhasebeDetay.STOPAJ_ORAN = detay.STOPAJ_ORAN;
                    muhasebeDetay.STOPAJ_SSDF_DAHIL = detay.STOPAJ_SSDF_DAHIL;
                    muhasebeDetay.STOPAJ_SSDF_TUTAR = detay.STOPAJ_SSDF_TUTAR;
                    muhasebeDetay.TOPLAM_TUTAR = detay.TOPLAM_TUTAR;
                    muhasebeDetay.TARIH = detay.TARIH;
                    muhasebeDetay.KDV_DAHIL = detay.KDV_DAHIL;
                    muhasebeDetay.KDV_ORAN = detay.KDV_ORAN;
                    muhasebeDetay.KDV_TUTAR = detay.KDV_TUTAR;
                    muhasebeDetay.HAREKET_ALT_KATEGORI_ID = detay.HAREKET_ALT_KATEGORI_ID;
                    muhasebeDetay.HAREKET_ANA_KATEGORI_ID = detay.HAREKET_ANA_KATEGORI_ID;
                    muhasebeDetay.ACIKLAMA =
                        string.Format("{0} Nolu, {1} Tarihli, {2}-{3}-{4} ve {5} Esas Nolu Takibin {6}", dosyaNo,
                                      masrafAvans.KAYIT_TARIHI, adliye, no, gorev, esasNo,
                                      detay.HAREKET_ALT_KATEGORI_IDSource.ALT_KATEGORI);

                    if (masrafAvans.MASRAF_AVANS_TIP == 1)
                    {
                        muhasebeDetay.ACIKLAMA += " Gideri";
                    }
                    else if (masrafAvans.MASRAF_AVANS_TIP == 2)
                    {
                        muhasebeDetay.BIRIM_FIYAT = 0 - muhasebeDetay.BIRIM_FIYAT;
                        muhasebeDetay.TOPLAM_TUTAR = 0 - muhasebeDetay.TOPLAM_TUTAR;
                        muhasebeDetay.GENEL_TOPLAM = 0 - muhasebeDetay.GENEL_TOPLAM;
                    }
                }
                muhasebe.REFERANS_NO = referans;
                muhasebe.MUHASEBE_HEDEF_TIP = muhasebeHedefTip;
                return muhasebe;
            }
            else return null;
        }

        private void MyMasrafAvans_ColumnChanged(object sender, AV001_TDI_BIL_MASRAF_AVANSEventArgs e)
        {
            switch (e.Column)
            {
                case AV001_TDI_BIL_MASRAF_AVANSColumn.ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.CARI_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.CARI_ADI:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.REFERANS_NO:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.MASRAF_AVANS_TIP:
                case AV001_TDI_BIL_MASRAF_AVANSColumn.CARI_HESAP_HEDEF_TIP:

                    #region CARI HESAP HEDEF TIP

                    #region GRÝD DOLDURMA

                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> tabBir =
                        new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> tabIki =
                        new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
                    TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> tabUc =
                        new TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI>();
                    if (MyMasrafAvans.MASRAF_AVANS_TIP == 1)
                    {
                        switch ((AvukatProLib.Extras.Modul)((int)e.Value))
                        {
                            case AvukatProLib.Extras.Modul.Icra:
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.ICRA_TAKIP_MASRAFLARI));
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DIGER));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_ICRA));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_ICRA_NISPI));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL_NISPI));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_IFLAS));
                                tabUc.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.TAKIP_EDILENIN_ODEYECEGI_VEKALET_UCRETI));

                                break;

                            case AvukatProLib.Extras.Modul.Dava:
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.MAHKEME_MASRAFLARI));
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DIGER));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_DAVA));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_DAVA_NISPI));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL_NISPI));
                                tabUc.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DAVA_EDILENIN_ODEYECEGI_VEKALET_UCRETI));

                                break;

                            case AvukatProLib.Extras.Modul.Sorusturma:
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.MAHKEME_MASRAFLARI));
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DIGER));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL));
                                tabIki.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.HARCLAR_GENEL_NISPI));
                                tabUc.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DAVA_EDILENIN_ODEYECEGI_VEKALET_UCRETI));
                                break;

                            //case AvukatProLib.Extras.Modul.Rucu:
                            //    tabBir.AddRange(
                            //        DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                            //            (int)MuhasebeAnaKategori.DIGER));

                            //    break;
                            case AvukatProLib.Extras.Modul.Sozlesme:
                                tabBir.AddRange(
                                    DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                        (int)MuhasebeAnaKategori.DIGER));
                                break;
                            default:
                                return;
                        }
                        tabMasrafAvans.PageVisible = true;
                        tabHarclar.PageVisible = true;
                        tabVekaletUcretleri.PageVisible = true;
                    }
                    else if (MyMasrafAvans.MASRAF_AVANS_TIP == 2)
                    {
                        tabBir.AddRange(
                            DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.GetByANA_KATEGORI_ID(
                                (int)MuhasebeAnaKategori.AVANS_HESABI));
                        tabMasrafAvans.PageVisible = true;
                        tabHarclar.PageVisible = false;
                        tabVekaletUcretleri.PageVisible = false;
                    }
                    TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detayBir = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
                    TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detayIki = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
                    TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detayUc = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();

                    //tabBir.Sort("KOLAY_SIRA");
                    //tabIki.Sort("KOLAY_SIRA");
                    //tabUc.Sort("KOLAY_SIRA");
                    //TODO: dty.BORC_ALACAK_ID = 1; bölümü deneme amaçlýdýr... !!
                    foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI kategori in tabBir)
                    {
                        AV001_TDI_BIL_MASRAF_AVANS_DETAY dty = detayBir.AddNew();
                        dty.HAREKET_ANA_KATEGORI_ID = kategori.ANA_KATEGORI_ID;
                        dty.HAREKET_ALT_KATEGORI_ID = kategori.ID;
                        dty.BORC_ALACAK_ID = 1;
                        dty.ColumnChanged += dty_ColumnChanged;
                    }
                    foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI kategori in tabIki)
                    {
                        AV001_TDI_BIL_MASRAF_AVANS_DETAY dty = detayIki.AddNew();
                        dty.HAREKET_ANA_KATEGORI_ID = kategori.ANA_KATEGORI_ID;
                        dty.HAREKET_ALT_KATEGORI_ID = kategori.ID;
                        dty.BORC_ALACAK_ID = 1;
                        dty.ColumnChanged += dty_ColumnChanged;
                    }
                    foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI kategori in tabUc)
                    {
                        AV001_TDI_BIL_MASRAF_AVANS_DETAY dty = detayUc.AddNew();
                        dty.HAREKET_ANA_KATEGORI_ID = kategori.ANA_KATEGORI_ID;
                        dty.HAREKET_ALT_KATEGORI_ID = kategori.ID;
                        dty.BORC_ALACAK_ID = 1;
                        dty.ColumnChanged += dty_ColumnChanged;
                    }

                    //TODO: ÖN SAYFADAKI GRIDLERIN DATASOURCE -thsn-

                    exgMasrafAvans.DataSource = detayBir;
                    exgHArclar.DataSource = detayIki;
                    exgVekaletUcretleri.DataSource = detayUc;

                    #endregion GRÝD DOLDURMA

                    #region Dosya no Doldurma

                    AvukatProLib.Extras.Modul hdfTip = (AvukatProLib.Extras.Modul)e.Value;

                    switch (hdfTip)
                    {
                        //TODO: LookupEditler Doldu ..
                        //TODO: SEÇÝME GÖRE ARKA GRÝDLERE DATASOURCE -thsn-
                        //iCRA_FOY_IDGridLookUpEdit
                        //rUCU_IDGridLookUpEdit
                        //dAVA_FOY_IDGridLookUpEdit
                        //hAZIRLIK_IDGridLookUpEdit
                        case AvukatProLib.Extras.Modul.Icra:
                            ucDavaBIL_Foy1.Visible = false;
                            ucHazirlik1.Visible = false;
                            ucRucuBilgileri1.Visible = false;
                            ucIcraFoy1.Visible = true;

                            break;

                        case AvukatProLib.Extras.Modul.Dava:
                            ucIcraFoy1.Visible = false;
                            ucHazirlik1.Visible = false;
                            ucRucuBilgileri1.Visible = false;
                            ucDavaBIL_Foy1.Visible = true;
                            break;

                        case AvukatProLib.Extras.Modul.Sorusturma:

                            //dAVA_FOY_IDGridLookUpEdit
                            ucIcraFoy1.Visible = false;
                            ucDavaBIL_Foy1.Visible = false;
                            ucRucuBilgileri1.Visible = false;
                            ucHazirlik1.Visible = true;
                            break;

                        //case AvukatProLib.Extras.Modul.Rucu:
                        //    ucDavaBIL_Foy1.Visible = false;
                        //    ucHazirlik1.Visible = false;
                        //    ucIcraFoy1.Visible = false;
                        //    ucRucuBilgileri1.Visible = true;
                        //    break;
                        case AvukatProLib.Extras.Modul.Sozlesme:
                            break;
                        default:
                            break;
                    }

                    #endregion Dosya no Doldurma

                    #endregion CARI HESAP HEDEF TIP

                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.ICRA_FOY_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.ICRA_FOY_NO:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.DAVA_FOY_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.DAVA_FOY_NO:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.HAZIRLIK_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.HAZIRLIK_NO:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.RUCU_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.RUCU_NO:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.ACIKLAMA:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.KAYIT_TARIHI:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.KLASOR_KODU:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.SUBE_KODU:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.KONTROL_NE_ZAMAN:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.KONTROL_KIM:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.KONTROL_VERSIYON:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.STAMP:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.BORCLU_CARI_ID:
                    break;

                case AV001_TDI_BIL_MASRAF_AVANSColumn.BORCLU_CARI_ADI:
                    break;
                default:
                    break;
            }
        }

        private void rfrmMuhasebeGiris_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ParaBicimiAyarla(rudPara);
            BelgeUtil.Inits.ModulGetir(cARI_HESAP_HEDEF_TIPLookUpEdit.Properties);
            BelgeUtil.Inits.MasrafAvansTipGetir(mASRAF_AVANS_TIPLookUpEdit.Properties);
            BelgeUtil.Inits.CariPersonelGetir(cARI_IDLookUpEdit);
            BelgeUtil.Inits.perCariGetir(bORCLU_CARI_IDLookUpEdit);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rlkAltKategori);

            if (MyMasrafAvans == null)
            {
                MyMasrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
                MyMasrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
            }
            avanslar.Add(MyMasrafAvans);

            bindingSource1.DataSource = avanslar;
        }

        #endregion Methods
    }
}