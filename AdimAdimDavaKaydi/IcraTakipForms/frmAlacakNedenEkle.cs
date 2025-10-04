using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class frmAlacakNedenEkle : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Uyap GeriBildirim

        private UyapGeriBildirim _uyapBildirim;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        #endregion Uyap GeriBildirim

        public bool DuzenlemeMi;
        public bool EditMode = false;
        public System.Collections.Generic.List<int> yeniIdListesi = new System.Collections.Generic.List<int>();
        private TList<AV001_TI_BIL_ALACAK_NEDEN> addNewList;
        private int adet;
        private AV001_TI_BIL_FOY myFoy;
        private AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucAlacaklar ParentControl;
        private decimal sorumlulukmiktr;
        private List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> Source;
        public frmAlacakNedenEkle()
        {
            InitializeComponent();
            InitializeEvents();
            Source = new List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN>();
            ucAlacakNedenGirisi1.Load += ucAlacakNedenGirisi1_Load;
            this.FormClosing += frmAlacakNedenEkle_FormClosing;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ALACAK_NEDEN> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;

                if (value != null && !this.DesignMode)
                {
                    if (AddNewList == null)
                        AddNewList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

                    //AddNewList.AddingNew += AV001_TI_BIL_ALACAK_NEDENCollection_AddingNew;
                    ucAlacakNedenGirisi1.Foy = value;
                    ucAlacakNedenGirisi1.DtAlacakNeden = AddNewList;
                    if (AddNewList.Count == 0)
                    {
                        ucAlacakNedenGirisi1.DtAlacakNeden.AddNew();
                        ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddingNew +=
                            AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew;
                        ucAlacakNedenTaraf1.DtAlacakNeden =
                            ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                    }
                    ucAlacakNedenGirisi1.DtAlacakNeden = AddNewList;

                    ucAlacakNedenTaraf1.DtAlacakNeden =
                        ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                    ucAlacakNedenGirisi1.FormdaMi = true;
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in AddNewList)
                    {
                        neden.ColumnChanged += neden_ColumnChanged;

                        if (!DuzenlemeMi)
                            neden.HESAPLAMA_MODU = 1;
                    }
                }
            }
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            MyFoy = foy;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foyEntity, List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> Source)
        {
            MyFoy = foyEntity;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Source = Source;
            this.Show();
        }

        public void Show(AV001_TI_BIL_ALACAK_NEDEN neden, AV001_TI_BIL_FOY foyEntity)
        {
            addNewList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            addNewList.Add(neden);
            ucAlacakNedenTaraf1.DtAlacakNeden = neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
            MyFoy = foyEntity;

            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN aNeden, AV001_TI_BIL_FOY foyEntity, List<AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN> Source, AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucAlacaklar ParentControl)
        {
            this.ParentControl = ParentControl;
            AV001_TI_BIL_ALACAK_NEDEN neden = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(aNeden.ID);
            addNewList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            addNewList.Add(neden);
            this.Source = Source;
            if (neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(neden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

            ucAlacakNedenTaraf1.DtAlacakNeden = neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
            MyFoy = foyEntity;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public DialogResult ShowDialog(AV001_TI_BIL_FOY foyEntity)
        {
            MyFoy = foyEntity;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;

            return this.ShowDialog();
        }

        public DialogResult ShowDialog(AV001_TI_BIL_ALACAK_NEDEN neden, AV001_TI_BIL_FOY foyEntity)
        {
            addNewList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            addNewList.Add(neden);
            ucAlacakNedenTaraf1.DtAlacakNeden = neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
            MyFoy = foyEntity;

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        private void AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN ndn = ucAlacakNedenGirisi1.DtAlacakNeden[0];
            foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                foreach (string s in trf.TableColumns)
                {
                    if (s.EndsWith("DOVIZ_ID"))
                        trf.GetType().GetProperty(s).SetValue(trf, 1, null);
                }
                trf.TARAF_CARI_ID = taraf.CARI_ID.Value;
                if (taraf.CARI_ID.HasValue)
                    trf.TARAF_CARI_ADI = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value).AD;
                else trf.TARAF_CARI_ADI = "<Cari Seçilmemiþ>";
                trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection =
                    new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>();
                trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;
                trf.KAYIT_TARIHI = DateTime.Now;
                trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                trf.KONTROL_KIM = "AVUKATPRO";
                trf.KONTROL_NE_ZAMAN = DateTime.Now;
                trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(trf);
            }
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_ALACAK_NEDEN n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmAlacakNedenEkle_Button_Kaydet_Click(object sender, EventArgs e)
        {
            ucAlacakNedenGirisi1.vgAlacakNedenGirisi.CloseEditor();
            AlacakNedenKaydet();
        }

        private void frmAlacakNedenEkle_Button_Yazdir_Click(object sender, EventArgs e)
        {
            YazdirmaIslemi();
        }

        private void frmAlacakNedenEkle_Button_Yeni_Click(object sender, EventArgs e)
        {
            YeniAlacakNeden();
        }

        private void frmAlacakNedenEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?", "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmAlacakNedenEkle_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmAlacakNedenEkle_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmAlacakNedenEkle_Button_Kaydet_Click;
            this.Button_Yazdir_Click += frmAlacakNedenEkle_Button_Yazdir_Click;
            this.Button_Yeni_Click += frmAlacakNedenEkle_Button_Yeni_Click;
        }

        private void neden_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gonderen = sender as AV001_TI_BIL_ALACAK_NEDEN;

            #region Alacak Nedenine Gore Davran

            if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ALACAK_NEDEN_KOD_ID)
            {
                gonderen.ALACAK_NEDEN_KOD_IDSource =
                    DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(gonderen.ALACAK_NEDEN_KOD_ID.Value);
                ucAlacakNedenGirisi1.vgAlacakNedenGirisi_FocusedRecordChanged(ucAlacakNedenGirisi1.vgAlacakNedenGirisi, new IndexChangedEventArgs(ucAlacakNedenGirisi1.vgAlacakNedenGirisi.FocusedRecord, -1));
                if (gonderen.ALACAK_NEDEN_KOD_ID.HasValue)
                    gonderen.DIGER_ALACAK_NEDENI = gonderen.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI;
            }

            #endregion Alacak Nedenine Gore Davran

            #region Tutar Doviz ID

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID)
            {
                if (gonderen.TUTAR_DOVIZ_ID.HasValue)
                {
                    if (gonderen.TUTAR_DOVIZ_ID.Value > 1)
                    {
                        gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL;
                    }
                    else
                    {
                        gonderen.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                    }
                    gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;

                    //gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                    gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                }
            }

            #endregion Tutar Doviz ID

            #region Faiz Oranlarý Getir

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_UYGULANACAK_FAIZ_ORANI)
            {
                gonderen.UYGULANACAK_FAIZ_ORANI = gonderen.TO_UYGULANACAK_FAIZ_ORANI;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TO_ALACAK_FAIZ_TIP_ID)
            {
                gonderen.ALACAK_FAIZ_TIP_ID = gonderen.TO_ALACAK_FAIZ_TIP_ID;
                gonderen.UYGULANACAK_FAIZ_ORANI = FaizHelper.FaizOraniGetir((int)e.Value, gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID, myFoy.TAKIP_TARIHI);
                gonderen.TO_UYGULANACAK_FAIZ_ORANI = gonderen.UYGULANACAK_FAIZ_ORANI;
            }

            #endregion Faiz Oranlarý Getir

            #region Düzenleme Tarihini Vade Tarihine At

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DUZENLENME_TARIHI)
            {
                gonderen.VADE_TARIHI = (DateTime?)e.Value;
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion Düzenleme Tarihini Vade Tarihine At

            #region VadeTarihini FBasTar a At

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.VADE_TARIHI)
            {
                gonderen.FAIZ_BASLANGIC_TARIHI = (DateTime?)e.Value;
            }

            #endregion VadeTarihini FBasTar a At

            #region Tutarý ÝþlemeKonana At

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTARI || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TUTAR_DOVIZ_ID || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.HESAPLAMA_MODU)
            {
                switch ((IcraDovizIslemTipi)gonderen.HESAPLAMA_MODU)
                {
                    case IcraDovizIslemTipi.Vade_Tarihinde_TL:
                        if (!gonderen.VADE_TARIHI.HasValue)
                            gonderen.VADE_TARIHI = DateTime.Today;
                        DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                        gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                           gonderen.VADE_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                        ucAlacakNedenGirisi1.RefreshDataSource();
                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;

                    case IcraDovizIslemTipi.Takip_Tarihinde_TL:
                        if (!myFoy.TAKIP_TARIHI.HasValue)
                            myFoy.TAKIP_TARIHI = DateTime.Today;
                        DovizHelper.GetMerkezBankasiBilgisi(gonderen.ALACAK_NEDEN_KOD_ID);
                        gonderen.ISLEME_KONAN_TUTAR = DovizHelper.CevirYTL(gonderen.TUTARI, gonderen.TUTAR_DOVIZ_ID,
                                                                           myFoy.TAKIP_TARIHI.Value, gonderen.ALACAK_NEDEN_KOD_ID);
                        ucAlacakNedenGirisi1.RefreshDataSource();
                        gonderen.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.En_Yüksek_Mevduat_Faizi;
                        gonderen.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = 1; //YTL
                        break;

                    case IcraDovizIslemTipi.Fiili_Ödeme_Tarihinde_TL:
                        gonderen.ISLEME_KONAN_TUTAR = gonderen.TUTARI;
                        gonderen.ISLEME_KONAN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
                        ucAlacakNedenGirisi1.RefreshDataSource();
                        break;
                    default:
                        break;
                }
            }

            #endregion Tutarý ÝþlemeKonana At

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.ADET)
            {
                adet = (int)e.Value;
            }
            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.CEK_YAPRAGI_SORUMLULUK_MIKTARI)
            {
                sorumlulukmiktr = (decimal)e.Value;
                gonderen.TUTARI = Convert.ToDecimal(adet * sorumlulukmiktr);
            }

            //else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_SAYISI)
            //{
            //    deposayisi = (int)e.Value;
            //    gonderen.DEPO_MIKTARI = sorumlulukmiktr * deposayisi;
            //    gonderen.DEPO_MIKTARI_DOVIZ_ID = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID;
            //}
            //else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_SAYISI)
            //{
            //    iadesayisi = (int)e.Value;
            //    int toplam = deposayisi + iadesayisi;
            //    decimal tutar = sorumlulukmiktr * toplam;
            //    gonderen.ISLEME_KONAN_TUTAR = Convert.ToDecimal(gonderen.TUTARI - tutar);
            //    gonderen.IADE_MIKTARI = sorumlulukmiktr * iadesayisi;
            //    gonderen.IADE_MIKTARI_DOVIZ_ID = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID;
            //}

            #region DEPO_SAYISI || IADE_SAYISI || TAZMIN_SAYISI)

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_SAYISI
                     || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_SAYISI || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_SAYISI)
            {
                if (gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI.HasValue)
                {
                    if (gonderen.DEPO_SAYISI.HasValue)
                        gonderen.DEPO_MIKTARI = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * gonderen.DEPO_SAYISI;
                    if (gonderen.IADE_SAYISI.HasValue)
                        gonderen.IADE_MIKTARI = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * gonderen.IADE_SAYISI;
                    if (gonderen.TAZMIN_SAYISI.HasValue)
                        gonderen.TAZMIN_MIKTARI = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * gonderen.TAZMIN_SAYISI;

                    gonderen.DEPO_MIKTARI_DOVIZ_ID = gonderen.IADE_MIKTARI_DOVIZ_ID = gonderen.TAZMIN_MIKTAR_DOVIZ_ID = gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI_DOVIZ_ID;
                }
                int toplam = (gonderen.DEPO_SAYISI ?? 0) + (gonderen.IADE_SAYISI ?? 0) + (gonderen.TAZMIN_SAYISI ?? 0);
                decimal tutar = (decimal)(gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI * (toplam));
                gonderen.ISLEME_KONAN_TUTAR = Convert.ToDecimal(gonderen.TUTARI - tutar);
            }

            #endregion DEPO_SAYISI || IADE_SAYISI || TAZMIN_SAYISI)

            #region DEPO_MIKTARI || IADE_MIKTARI || TAZMIN_MIKTARI)

            else if (e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.DEPO_MIKTARI
                     || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.IADE_MIKTARI || e.Column == AV001_TI_BIL_ALACAK_NEDENColumn.TAZMIN_MIKTARI)
            {
                if (gonderen.CEK_YAPRAGI_SORUMLULUK_MIKTARI.HasValue) return;
                decimal tutar = 0;
                if (gonderen.DEPO_MIKTARI.HasValue)
                    tutar += gonderen.DEPO_MIKTARI.Value;
                if (gonderen.IADE_MIKTARI.HasValue)
                    tutar += gonderen.IADE_MIKTARI.Value;
                if (gonderen.TAZMIN_MIKTARI.HasValue)
                    tutar += gonderen.TAZMIN_MIKTARI.Value;
                gonderen.ISLEME_KONAN_TUTAR = Convert.ToDecimal(gonderen.TUTARI - tutar);
            }

            #endregion DEPO_MIKTARI || IADE_MIKTARI || TAZMIN_MIKTARI)

            #region BSMV - KDV - OIV

            if (gonderen.ALACAK_NEDEN_KOD_ID.HasValue)
                switch (gonderen.ALACAK_NEDEN_KOD_ID.Value)
                {
                    case 52: //Telefon Faturasý
                    case 4: //	153	FATURA
                    case 37: //	49	FATURA
                    case 81: //	49	KAÇAK ELEKTRÝK FATURASI
                    case 82: //	49	ELEKTRÝK FATURASI
                    case 84: //	49	TESVÝYE
                    case 88: //	49	TESCÝL
                    case 89: //	49	TEFTÝÞ
                        gonderen.KDV_HESAPLANSIN = true;
                        break;

                    case 42: //	49	TELEFON FATURASI
                    case 51: //	153	TELEFON FATURASI
                        gonderen.KDV_HESAPLANSIN = true;
                        gonderen.OIV_HESAPLANSIN = true;
                        break;

                    case 49: //KREDI KARTI
                    case 50: //KREDI ALACAÐI

                        gonderen.BSMV_HESAPLANSIN = true;
                        break;
                }

            #endregion BSMV - KDV - OIV
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TI_BIL_ALACAK_NEDEN k) { k.ICRA_FOY_ID = MyFoy.ID; });

            foreach (var item in addNewList)
            {
                if (item.TUTARI < 0 || item.ISLEME_KONAN_TUTAR < 0)
                {
                    XtraMessageBox.Show("'Tutar' ve 'Ýþleme Konan Tutar' alanlarý eksi girilemez.", "UYARI",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, addNewList,
                                                                          DeepSaveType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
                                                                          typeof(
                                                                              TList
                                                                              <AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>),
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                              ));

                tran.Commit();

                foreach (var aNeden in addNewList)
                {
                    if (
                        MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Exists(
                            delegate(AV001_TI_BIL_ALACAK_NEDEN neden) { return neden.ID == aNeden.ID; }))
                    {
                        EditMode = true;
                        continue;
                    }
                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(aNeden);
                    yeniIdListesi.Add(aNeden.ID);
                }
                if (EditMode)
                {
                    if (ParentControl != null)
                        ParentControl.DatayiDoldur();
                        //ParentControl.MyDataSource = BelgeUtil.Inits.context.per_TAKIP_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == MyFoy.ID).ToList();
                }
                else
                    Source.AddRange(BelgeUtil.Inits.GetAlacakNedenViewItem(yeniIdListesi));
                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void ucAlacakNedenGirisi1_FocusedNedenChanged(object sender, IndexChangedEventArgs e)
        {
            if (e.NewIndex >= 0 && AddNewList.Count > 0)
            {
                AddNewList[e.NewIndex].ColumnChanged
                    += neden_ColumnChanged;
                if (ucAlacakNedenGirisi1.CurrentNeden != null)
                {
                    ucAlacakNedenTaraf1.DtAlacakNeden =
                        ucAlacakNedenGirisi1.CurrentNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepLoad(ucAlacakNedenTaraf1.DtAlacakNeden,
                                                                                    false, DeepLoadType.IncludeChildren,
                                                                                    typeof(
                                                                                        TList
                                                                                        <
                                                                                        AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ
                                                                                        >));
                    if (ucAlacakNedenTaraf1.DtAlacakNeden != null && ucAlacakNedenTaraf1.DtAlacakNeden.Count
                        > 0)
                    {
                        ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                            ucAlacakNedenTaraf1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
                    }
                }
                else if (ucAlacakNedenGirisi1.DtAlacakNeden.Count != 0)
                {
                    ucAlacakNedenTaraf1.DtAlacakNeden =
                        ucAlacakNedenGirisi1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection;
                    if (ucAlacakNedenTaraf1.DtAlacakNeden != null && ucAlacakNedenTaraf1.DtAlacakNeden.Count
                        > 0)
                    {
                        ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                            ucAlacakNedenTaraf1.DtAlacakNeden[0].AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
                    }
                }
            }
        }

        private void ucAlacakNedenGirisi1_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.AlacakNedenKodGetir((FormTipleri)MyFoy.FORM_TIP_ID.Value,
                                                ucAlacakNedenGirisi1.rlkAlacakNeden, MyFoy);
        }

        private void ucAlacakNedenGirisi1_NedenValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN ndn = ucAlacakNedenGirisi1.CurrentNeden;
            if (ndn == null)
                return;

            if (ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
            {
                #region AlacakNedenTarafFaiz

                if ((ndn.TO_ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.TO_UYGULANACAK_FAIZ_ORANI > 0)) &&
                    ndn.FAIZ_BASLANGIC_TARIHI.HasValue)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        if (trf.TARAF_SIFAT_ID == (int)TarafSifat.BORCLU)
                        {
                            trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                            trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                            trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                            trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                            trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                            trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                            trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                            AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = null;
                            if (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count != 0)
                                faiz = trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0];
                            else
                                faiz = trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddNew();

                            faiz.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI.Value;
                            faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI.Value;
                            faiz.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                            faiz.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                            faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                            faiz.KAYIT_TARIHI = DateTime.Now;
                            faiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                            faiz.KONTROL_KIM = "AVUKATPRO";
                            faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                            faiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                        }
                    }
                }

                #endregion AlacakNedenTarafFaiz
            }
            else
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                //foreach (AV001_TI_BIL_FOY_TARAF var in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                //{
                //    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(var, false, DeepLoadType.IncludeChildren,
                //                                                           typeof(TDIE_KOD_TARAF_SIFAT));
                //}

                #region AlacakNedenTaraflarý

                if (ndn.ISLEME_KONAN_TUTAR > 0 && ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
                {
                    foreach (AV001_TI_BIL_FOY_TARAF taraf in MyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                        foreach (string s in trf.TableColumns)
                        {
                            if (s.EndsWith("DOVIZ_ID"))
                                trf.GetType().GetProperty(s).SetValue(trf, 1, null);
                        }
                        trf.TARAF_CARI_ID = taraf.CARI_ID.Value;
                        if (taraf.CARI_ID.HasValue)
                        {
                            trf.TARAF_CARI_ADI = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value).AD;
                        }
                        else trf.TARAF_CARI_ADI = "<Cari Seçilmemiþ>";
                        trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                        trf.KAYIT_TARIHI = DateTime.Now;
                        trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        trf.KONTROL_KIM = "AVUKATPRO";
                        trf.KONTROL_NE_ZAMAN = DateTime.Now;
                        trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;

                        if (!taraf.TAKIP_EDEN_MI)
                        {
                            trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>();
                            trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                            trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                            trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                            trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                            trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                            trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                            trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                            trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;

                            AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();

                            faiz.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI ?? myFoy.TAKIP_TARIHI.Value;
                            faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI;
                            faiz.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                            faiz.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                            faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                            faiz.KAYIT_TARIHI = DateTime.Now;
                            faiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                            faiz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                            faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                            faiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                            faiz.TARAF_CARI_ID = trf.TARAF_CARI_ID;

                            if ((ndn.ALACAK_FAIZ_TIP_ID.HasValue ||
                                 (ndn.SABIT_FAIZ_UYGULA && ndn.UYGULANACAK_FAIZ_ORANI > 0)))
                            {
                                bool gerekVar = true;
                                if (ndn.SABIT_FAIZ_UYGULA &&
                                    (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                     trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_ORANI ==
                                     ndn.UYGULANACAK_FAIZ_ORANI))
                                {
                                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI =
                                        myFoy.TAKIP_TARIHI;
                                    gerekVar = false;
                                }
                                if (!ndn.SABIT_FAIZ_UYGULA && trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_TIP_ID.Value ==
                                    ndn.ALACAK_FAIZ_TIP_ID.Value)
                                {
                                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI =
                                        myFoy.TAKIP_TARIHI;
                                    gerekVar = false;
                                }
                                if (gerekVar)
                                {
                                    //AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                                    faiz.FAIZ_BASLANGIC_TARIHI = ndn.FAIZ_BASLANGIC_TARIHI ?? myFoy.TAKIP_TARIHI.Value;
                                    faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI;
                                    faiz.FAIZ_TIP_ID = ndn.ALACAK_FAIZ_TIP_ID;
                                    faiz.FAIZ_ORANI = ndn.UYGULANACAK_FAIZ_ORANI;
                                    faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                                    faiz.KAYIT_TARIHI = DateTime.Now;
                                    faiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                                    faiz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                                    faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                                    faiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                                }
                            }

                            trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                        }
                        ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(trf);
                    }

                    TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> tempTrf = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

                    foreach (
                        AV001_TI_BIL_ALACAK_NEDEN_TARAF eklenenTaraf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                    {
                        foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                        {
                            foreach (
                                AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf in neden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection
                                )
                            {
                                if (taraf.TARAF_CARI_ID == ucIcraTarafBilgileri.CurrBorcluId)
                                    tempTrf.Add(taraf);
                            }
                        }
                        if (tempTrf.Count > 0)
                        {
                            tempTrf.Sort("IHTAR_TEBLIG_TARIHI DESC");
                            eklenenTaraf.IHTAR_TEBLIG_TARIHI = tempTrf[0].IHTAR_TEBLIG_TARIHI;

                            tempTrf.Sort("IHTAR_TARIHI DESC");
                            eklenenTaraf.IHTAR_TARIHI = tempTrf[0].IHTAR_TARIHI;

                            tempTrf.Sort("TEMERRUT_TARIHI DESC");
                            eklenenTaraf.TEMERRUT_TARIHI = tempTrf[0].TEMERRUT_TARIHI;

                            tempTrf.Sort("ZAMAN_ASIMI_TARIHI DESC");
                            eklenenTaraf.ZAMAN_ASIMI_TARIHI = tempTrf[0].ZAMAN_ASIMI_TARIHI;
                        }
                    }
                }

                #endregion AlacakNedenTaraflarý
            }

            #region AlacakNedeninden ÇekSenet Oluþturma

            if (ndn.ALACAK_NEDEN_KOD_IDSource == null && !ndn.IsNew)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(ndn, true, DeepLoadType.IncludeChildren,
                                                                          typeof(TI_KOD_ALACAK_NEDEN));
            }
            else if (ndn.ALACAK_NEDEN_KOD_IDSource == null && ndn.IsNew)
            {
                ndn.ALACAK_NEDEN_KOD_IDSource = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                    ndn.ALACAK_NEDEN_KOD_ID.Value);
            }

            TDI_KOD_KIYMETLI_EVRAK_TUR keTur = null;
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> keList = null;
            switch (ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI)
            {
                case "ÇEK":
                    keTur = DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                    break;

                case "SENET":
                    keTur = DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                    break;

                case "POLÝÇE":
                    keTur = DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);
                    break;
                default:
                    break;
            }
            if (keTur != null)
            {
                keList = ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
                AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = null;
                if (keList.Count > 0)
                    kEvrak = keList[0];
                else
                    kEvrak = keList.AddNew();

                kEvrak.EVRAK_TUR_ID = keTur.ID;
                kEvrak.EVRAK_KAYIT_TARIHI = DateTime.Today;
                kEvrak.EVRAK_TUR_IDSource = keTur;
                kEvrak.EVRAK_VADE_TARIHI = ndn.VADE_TARIHI;
                kEvrak.EVRAK_TANZIM_TARIHI = ndn.DUZENLENME_TARIHI;
                kEvrak.TUTAR = ndn.TUTARI;
                kEvrak.TUTAR_DOVIZ_ID = ndn.TUTAR_DOVIZ_ID;
                kEvrak.TUTAR_DOVIZ_IDSource = ndn.TUTAR_DOVIZ_IDSource;
                kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
            }

            #endregion AlacakNedeninden ÇekSenet Oluþturma
        }

        #region IslemMetodlarý

        private bool kaydedildi;

        private void AlacakNedenKaydet()
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

        private void YazdirmaIslemi()
        {
            this.ucAlacakNedenGirisi1.vgAlacakNedenGirisi.Print();
        }

        private void YeniAlacakNeden()
        {
            ucAlacakNedenGirisi1.vgAlacakNedenGirisi.AddNewRecord();
        }

        #endregion IslemMetodlarý

        private void ucAlacakNedenTaraf1_FocusedTarafChanged(object sender, IndexChangedEventArgs e)
        {
            try
            {
                if (e.NewIndex != -1 && ucAlacakNedenTaraf1.DtAlacakNeden != null &&
                    ucAlacakNedenTaraf1.DtAlacakNeden.Count > 0)
                    ucAlacakNedenTaraf_Faiz1.DtAlacakNeden =
                        ucAlacakNedenTaraf1.DtAlacakNeden[e.NewIndex].AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}