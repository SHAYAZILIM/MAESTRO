using AdimAdimDavaKaydi.Muhasebe;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class ucDavaGridler : AvpXUserControl
    {
        public ucDavaGridler()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucDavaGridler_Load;
        }

        private AV001_TD_BIL_FOY _myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
            }
        }

        private void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (this.ucIliskiDetay1 != null)
                this.ucIliskiDetay1.GetList(MyFoy.ID, AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI);
        }

        private void gcDavaNeden_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NedeneBagliKayitGetir();
        }

        private void NedeneBagliKayitGetir()
        {
            AV001_TD_BIL_DAVA_NEDEN focusNeden = (AV001_TD_BIL_DAVA_NEDEN)gcDavaNeden.gwDavaNeden.GetFocusedRow();
            if (focusNeden == null)
                focusNeden = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0];

            if (dnGayrimenkulBilgileri != null)
            {
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
                if (focusNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL.Count > 0)
                {
                    dnGayrimenkulBilgileri.MyDataSource = focusNeden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL;
                }
                var gayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByDAVA_FOY_IDFromNN_DAVA_GAYRIMENKUL(MyFoy.ID);
                dnGayrimenkulBilgileri.MyDataSource = gayrimenkulList;
            }

            if (dnAracBilgileri != null)
            {
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC>));
                if (
                    focusNeden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC.Count >= 0)
                {
                    dnAracBilgileri.MyDataSource = BelgeUtil.Inits.GemiUcakAracGetirByDavaNedenId(focusNeden.ID);
                }
            }

            if (dnKiymetliEvrakBilgileri != null)
            {
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK>));
                if (
                    focusNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK.Count >= 0)
                {
                    dnKiymetliEvrakBilgileri.MyDataSource =
                        focusNeden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK;
                }
            }

            if (dnSozlesmeBilgileri != null)
            {
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW>));
                if (focusNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW.Count >= 0)
                {
                    dnSozlesmeBilgileri.MyDataSource = focusNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW;
                }
            }

            if (ucDavaPolice1 != null)
            {
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(focusNeden, false, DeepLoadType.IncludeChildren, typeof(TList<NN_DAVA_NEDEN_POLICE>), typeof(TList<AV001_TDI_BIL_POLICE>));
                if (focusNeden.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE.Count >= 0)
                {
                    ucDavaPolice1.MyFoy = MyFoy;
                    ucDavaPolice1.MyDataSource = focusNeden.AV001_TDI_BIL_POLICECollection_From_NN_DAVA_NEDEN_POLICE;
                }
            }
        }

        private void sbtnIliskiEkle_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
            frm.MyDavaFoy = MyFoy;
            frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        private void ucDavaGridler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (!IsLoaded)
            {
                InitializeComponent();
                var pages = tabGridler.TabPages.OrderBy(vi => vi.Text).ToList();

                tabGridler.TabPages.Clear();

                for (int i = 0; i < pages.Count(); i++)
                {
                    tabGridler.TabPages.Add(pages[i]);
                }
                tabGridler.SelectedTabPage = this.tabGenelNotlar;
                IsLoaded = true;

                tabGridler.SelectedPageChanging += tabGridler_SelectedPageChanging;
                xtraTabControl9.SelectedPageChanging += xtraTabControl9_SelectedPageChanging;
                tabDnIliskiliKayitlar.SelectedPageChanging += tabDnIliskiliKayitlar_SelectedPageChanging;
                xtraTabControl7.SelectedPageChanging += xtraTabControl7_SelectedPageChanging;
                xtraTabControl2.SelectedPageChanging += xtraTabControl2_SelectedPageChanging;
                xtraTabControl6.SelectedPageChanging += xtraTabControl6_SelectedPageChanging;
                xtraTabControl3.SelectedPageChanging += xtraTabControl3_SelectedPageChanging;
                xtraTabControl4.SelectedPageChanging += xtraTabControl4_SelectedPageChanging;
                xtraTabControl8.SelectedPageChanging += xtraTabControl8_SelectedPageChanging;
                xtraTabControl1.SelectedPageChanging += xtraTabControl1_SelectedPageChanging;
                xtraTabControl10.SelectedPageChanging += xtraTabControl10_SelectedPageChanging;
                xtraTabControl5.SelectedPageChanging += xtraTabControl5_SelectedPageChanging;
                xtraTabControl11.SelectedPageChanging += xtraTabControl11_SelectedPageChanging;

                if (ucGenelNotlar == null)
                    CreateUcGenelNotlar();

                ucGenelNotlar.MyFoy = MyFoy;

                if (BelgeUtil.Inits.PaketAdi != 1)
                {
                    tabAraKaraar.PageVisible = true;
                    tabDavaIzah.PageVisible = true;
                    tabDavaNeden.PageVisible = true;
                }
            }
        }

        private void ucGorevler1_Saved(System.Collections.IList Records, IEntity Record)
        {
            YapilacakIsYukle();
        }

        private void YapilacakIsYukle()
        {
            if (MyFoy == null)
                return;
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS>), typeof(TList<NN_IS_DAVA_FOY>));

            if (ucGorevler1 == null)
                return;
            ucGorevler1.MyDataSource = MyFoy.AV001_TDI_BIL_ISCollection_From_NN_IS_DAVA_FOY;
            ucGorevler1.SelectedRecord = MyFoy;
            ucGorevler1.SelectedRecordId = MyFoy.ID;
        }

        #region TabControl SelectedPageChanging Events

        private void frmMuhasebe_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByDavaFoyId(MyFoy.ID);
        }

        private void tabDnIliskiliKayitlar_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabPDnGayrimenkulBilgileri)
            {
                if (dnGayrimenkulBilgileri == null)
                    CreateDnGayriMenkulBilgileri();

                dnGayrimenkulBilgileri.MyDavaFoy = MyFoy;
                NedeneBagliKayitGetir();
            }
            else if (e.Page == tabPDnAracBilgileri)
            {
                if (dnAracBilgileri == null)
                    CreateDnAracBilgileri();

                NedeneBagliKayitGetir();
            }
            else if (e.Page == tabPDnKiymetliEvrak)
            {
                if (dnKiymetliEvrakBilgileri == null)
                    CreateDnKiymetliEvrakBilgileri();

                NedeneBagliKayitGetir();
            }
            else if (e.Page == tabPDNSozlesmeBilgileri)
            {
                if (dnSozlesmeBilgileri == null)
                    CreateDnSozlesmeBilgileri();

                NedeneBagliKayitGetir();
            }
            else if (e.Page == tbPPolice)
            {
                if (ucDavaPolice1 == null)
                    CreateUcDavaPolice1();

                NedeneBagliKayitGetir();
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void tabGridler_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabDavaNeden)
            {
                if (gcDavaNeden == null)
                    CreateGcDavaNeden();

                if (MyFoy != null)
                    gcDavaNeden.MyFoy = MyFoy;
            }
            else if (e.Page == tabCelseveArarKararBilgileri)
            {
                if (gcCelse == null)
                    CreateGcCelse();

                if (MyFoy != null)
                    gcCelse.MyFoy = MyFoy;
            }
            else if (e.Page == tabDusmeYenileme)
            {
                if (gcDusmeYenileme == null)
                    CreateGcDusmeYenileme();

                if (MyFoy != null)
                    gcDusmeYenileme.MyFoy = MyFoy;
            }
            else if (e.Page == tabKanit)
            {
                if (gcKanit == null)
                    CreateGcKanit();

                if (MyFoy != null)
                    gcKanit.MyFoy = MyFoy;
            }
            else if (e.Page == tabHesap)
            {
                if (ucMasraflar2 == null)
                {
                    CreateUcMasraflar2();
                    CreateUcMasraflar1();
                    CreateUcMasraflar3();
                }

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                if (MyFoy != null)
                {
                    ucMasraflar2.MyDavaFoy = MyFoy;
                    ucMasraflar2.MyDataSource = MyFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
                }
            }
            else if (e.Page == tabDavaliOdeme)
            {
                if (ucDavaliOdeme == null)
                    CreateGcOdeme();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_BORCLU_ODEME>));
                if (MyFoy != null)
                {
                    ucDavaliOdeme.MyFoy = MyFoy;
                    ucDavaliOdeme.MyDataSource = MyFoy.AV001_TD_BIL_BORCLU_ODEMECollection;
                }
            }
            else if (e.Page == tabGelisme)
            {
                if (gcDavaGelismeAdim == null)
                    CreateGcDavaGelismeAdim();

                if (MyFoy != null)
                    gcDavaGelismeAdim.MyFoy = MyFoy;
            }
            else if (e.Page == tabKayitIliskiDetay)
            {
                if (ucIliskiDetay1 == null)
                    CreateUcIliskiDetay1();

                ucIliskiDetay1.GetList(MyFoy.ID, AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI);
            }
            else if (e.Page == tabAsama)
            {
                if (gcAsama == null)
                    CreateGcAsama();

                if (MyFoy != null)
                    gcAsama.MyFoy = MyFoy;
            }
            else if (e.Page == tabGenelNotlar)
            {
                if (ucGenelNotlar == null)
                    CreateUcGenelNotlar();

                ucGenelNotlar.MyFoy = MyFoy;
            }
            else if (e.Page == tabDegisikIsveTeminat)
            {
                if (ucDavaTedbirBilgileri1 == null)
                    CreateUcDavaTedbirBilgileri1();

                ucDavaTedbirBilgileri1.MyFoy = MyFoy;
            }
            else if (e.Page == tabIletisim)
            {
                if (gcGorusme == null)
                    CreateGcGorusme();

                if (MyFoy != null)
                    gcGorusme.MyFoy = MyFoy;
            }
            else if (e.Page == tabHukumveTemyiz)
            {
                if (gcMahkemeHukum == null)
                    CreateGcMahkemeHukum();

                if (MyFoy != null)
                    gcMahkemeHukum.MyFoy = MyFoy;
            }
            else if (e.Page == tabDavaIzah)
            {
                if (gcDavaHikaye == null)
                    CreateGcDavaHikaye();

                gcDavaHikaye.MyFoy = MyFoy;
            }
            else if (e.Page == tabMüvekkilHesabý)
            {
                if (gcMuvekkilOdeme == null)
                    CreateGcMuvekkilOdeme();

                if (MyFoy != null)
                    gcMuvekkilOdeme.MyDavaFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage6)
            {
                if (gcPolice == null)
                    CreateGcPolice();

                if (MyFoy != null)
                    gcPolice.MyFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage8)
            {
                if (gcHasar == null)
                {
                    CreateGcHasar();
                }
            }
            else if (e.Page == c_tpGorevler)
            {
                if (ucGorevler1 == null)
                    CreateUcGorevler1();

                YapilacakIsYukle();
            }
            else if (e.Page == tbTutuklanma)
            {
                if (ucTutuklanmaVeGozAlt1 == null)
                    CreateUcTutuklanmaVeGozAlt1();

                if (MyFoy != null)
                {
                    ucTutuklanmaVeGozAlt1.MyFoy = MyFoy;
                    ucTutuklanmaVeGozAlt1.MyDataSource = MyFoy.AV001_TD_BIL_TUTUKLANMACollection;
                }
            }
            else if (e.Page == tabDokumanlar)
            {
                if (belge == null)
                    CreateBelge();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE>));
                if (MyFoy != null)
                {
                    belge.IdValue = MyFoy.ID;
                    belge.CurrentRecord = MyFoy;
                    belge.MyDataSource = BelgeUtil.Inits.BelgeGetirByDavaFoyId(MyFoy.ID);
                    belge.TableName = MyFoy.TableName;
                }
            }
            else if (e.Page == tabTebligatveGelenGidenEvrak)
            {
                if (ucTebligatMuhatapForGiris1 == null)
                    CreateUcTebligat1();

                if (MyFoy != null)
                    ucTebligatMuhatapForGiris1.MyDataSource = AvukatPro.Services.Implementations.DosyaService.GetEvrakByDavaFoyID(MyFoy.ID);
            }
            else if (e.Page == tabPMuvekkilOdeme)
            {
                if (ucMuvekkilTalimatlari1 == null)
                    CreateUcMuvekkilTalimatlari1();

                if (MyFoy != null)
                    ucMuvekkilTalimatlari1.MyDavaFoy = MyFoy;
            }
            else if (e.Page == tabPIliskiliDKayýtlarý)
            {
                if (GayrimenkulBilgileri == null)
                    CreateGayrimenkulBilgileri();

                GayrimenkulBilgileri.MyDavaFoy = MyFoy;
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_DAVA_GAYRIMENKUL>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
                GayrimenkulBilgileri.MyDataSource =
                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_DAVA_GAYRIMENKUL;
            }
            else if (e.Page == xTabPIadeAlinmamisTeminatlar)
            {
                if (gcTeminat == null)
                    CreateGcTeminat();

                if (MyFoy != null)
                    gcTeminat.MyFoy = MyFoy;
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage9)
            {
                if (gcMuvekkilOdeme == null)
                    CreateGcMuvekkilOdeme();

                if (MyFoy != null)
                    gcMuvekkilOdeme.MyDavaFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage10)
            {
                if (gcVekaletSozlesme == null)
                    CreateGcVekaletSozlesme();

                if (MyFoy != null)
                    gcVekaletSozlesme.MyDavaFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage11)
            {
                if (gcYapilacakIsSozlesme == null)
                    CreateGcYapilacakIsSozlesme();
            }
            else if (e.Page == xtraTabPage5)
            {
                if (gcMeslekMakbuzu == null)
                    CreateGcMeslekMakbuzu();

                if (MyFoy != null)
                    gcMeslekMakbuzu.MyDavaFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage3)
            {
                #region DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme

                decimal? carilestirilebilirToplam = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(MyFoy.ID, 2).Select(m => m.MuhasebelestirilmemisMiktar).Sum();

                if (carilestirilebilirToplam > 0)
                {
                    if (XtraMessageBox.Show(
                   "Bu dosyada dosya muhasebesine aktarýlmýþ ancak müvekkiller adýna muhasebeleþtirilmemiþ kayýtlar bulunmaktadýr.\nÞimdi muhasebeleþtirmek istiyormusunuz?",
                   "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme(2, MyFoy.ID);
                        frm.MdiParent = AnaForm.mdiAvukatPro.MainForm;
                        frm.FormClosed += new FormClosedEventHandler(frmMuhasebe_FormClosed);
                        frm.Show();
                    }
                }

                #endregion DosyaMuhasebesi kontrol ve muyasebeleþtirme ekranýna gönderme

                if (ucMuhasebeGenel1 == null)
                {
                    CreateUcMuhasebeGenel1();

                    //if (hesaplar == null) HesapDetayGetir();
                    //if (hesaplar != null)
                    //{
                    //}
                }
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByDavaFoyId(MyFoy.ID);
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl10_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage13)
            {
                if (ucMuhasebeGenel1 == null)
                {
                    CreateUcMuhasebeGenel1();

                    //if (hesaplar == null) HesapDetayGetir();
                    //if (hesaplar != null)
                    //{
                }
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByDavaFoyId(MyFoy.ID);

                //}
            }
            else if (e.Page == xtraTabPage19)
            {
                if (ucMuhasebeGenel2 == null)
                {
                    CreateUcMuhasebeGenel2();

                    //if (hesaplar != null)
                    //{
                    //}
                }
                ucMuhasebeGenel2.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByDavaTaraf(MyFoy.ID);
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl11_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage16)
            {
                if (GayrimenkulBilgileri == null)
                    CreateGayrimenkulBilgileri();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<NN_DAVA_GAYRIMENKUL>), typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
                GayrimenkulBilgileri.MyDataSource =
                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_DAVA_GAYRIMENKUL;
            }
            else if (e.Page == xtraTabPage17)
            {
                if (AracBilgileri == null)
                    CreateAracBilgileri();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>), typeof(TList<NN_DAVA_GEMI_UCAK_ARAC>));
                AracBilgileri.MyDataSource = MyFoy.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_DAVA_GEMI_UCAK_ARAC;
                //BelgeUtil.Inits.GemiUcakAracGetirByDavaFoyId(MyFoy.ID);
                //aykut
                AracBilgileri.MyDavaFoy = MyFoy;
            }
            else if (e.Page == xtraTabPage18)
            {
                if (KiymetliEvrakBilgileri == null)
                    CreateKiymetliEvrakBilgileri();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>), typeof(TList<NN_DAVA_KIYMETLI_EVRAK>));
                KiymetliEvrakBilgileri.MyDavaFoy = MyFoy;
                KiymetliEvrakBilgileri.MyDataSource =
                    MyFoy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_DAVA_KIYMETLI_EVRAK;
            }

            // Dava Hesabi
            if (e.Page == tabDavaHesabi)
            {
                if (davaHesaplari == null)
                    CreateDavaHesapBilgileri();

                // DataSource
            }
            else if (e.Page == tabPSozlesmeBilgileri)
            {
                if (SozlesmeBilgileri == null)
                    CreateSozlesmeBilgileri();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>), typeof(TList<NN_DAVA_SOZLESME>));
                SozlesmeBilgileri.MyDataSource = MyFoy.AV001_TDI_BIL_SOZLESMECollection_From_NN_DAVA_SOZLESME;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl2_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabDavaliOdemeleri) // PageVisible = false
            {
                if (gcDavaOdeme == null)
                    CreateGcDavaOdeme();

                if (MyFoy != null)
                    gcDavaOdeme.MyFoy = MyFoy;
            }
            else if (e.Page == tabMasraf) //masraf
            {
                CreateUcMasraflar2();
                CreateUcMasraflar1();
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

                if (MyFoy != null)
                {
                    ucMasraflar2.MyDavaFoy = MyFoy;
                    ucMasraflar2.MyDataSource = MyFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
                }
            }
            else if (e.Page == tabDosyaMuhasebesi) //dosya muhasebesi
            {
                #region Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                bool olustur = false;
                if (MyFoy != null)
                {
                    int foyID = MyFoy.ID;
                    TList<AV001_TDI_BIL_MASRAF_AVANS> gelenMasrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByDAVA_FOY_ID(foyID);

                    try
                    {
                        foreach (var masrafAvans in gelenMasrafAvans)
                        {
                            AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();

                            if (gelenMuhasebe == null)
                            {
                                olustur = true;
                            }

                            if (gelenMuhasebe != null)
                            {
                                TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                {
                                    olustur = true;
                                }
                            }
                        }

                        if (olustur)
                        {
                            if (XtraMessageBox.Show(
                           "Bu dosyada dosya muhasebesine aktarýlmamýþ masraf ve / veya avans kayýtlarý var.\nMüvekkil muhasebesine aktarýlabilmesi için öncelikle bu kayýtlarýn oluþturulmasý gerekiyor.\nÞimdi oluþturulmasýný ister misiniz?",
                           "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                foreach (var masrafAvans in gelenMasrafAvans)
                                {
                                    AV001_TDI_BIL_FOY_MUHASEBE gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    if (gelenMuhasebe == null)
                                    {
                                        CreateFoyMuhasebeByMasrafAvansRequest request = new CreateFoyMuhasebeByMasrafAvansRequest();
                                        request.MasrafAvansId = masrafAvans.ID;
                                        request.ModulId = masrafAvans.CARI_HESAP_HEDEF_TIP;
                                        AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeByMasrafAvans(request);

                                        gelenMuhasebe = DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID).FirstOrDefault();
                                    }

                                    if (gelenMuhasebe != null)
                                    {
                                        TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> mevcutMasrafDetay = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(masrafAvans.ID);
                                        TList<AV001_TDI_BIL_FOY_MUHASEBE_DETAY> gelenMuhasebeDetay = DataRepository.AV001_TDI_BIL_FOY_MUHASEBE_DETAYProvider.GetByFOY_MUHASEBE_ID(gelenMuhasebe.ID);

                                        if (mevcutMasrafDetay.Count > gelenMuhasebeDetay.Count)
                                        {
                                            foreach (var item in mevcutMasrafDetay)
                                            {
                                                //kontrol versiyon alanýnda masraf avans detay id tutulmaktadýr
                                                if (!gelenMuhasebeDetay.Any(m => m.KONTROL_VERSIYON == item.ID))
                                                {
                                                    CreateFoyMuhasebeDetayByMasrafAvansDetayRequest request = new CreateFoyMuhasebeDetayByMasrafAvansDetayRequest();
                                                    request.MasrafAvansDetayId = item.ID;
                                                    request.MuhasebeId = gelenMuhasebe.ID;
                                                    request.YenidenHesaplanabilir = !item.MA_MANUAL_KAYIT_MI;
                                                    AvukatPro.Services.Implementations.MuhasebeService.CreateFoyMuhasebeDetayByMasrafAvansDetay(request);

                                                    // son parametre yeniden hesaplanabilir olmasý için verildi
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            XtraMessageBox.Show("Masraf avans kayýtlarýnýn dosya muhasebesine aktarýlmasý tamamlandý.", "Ýþlem Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    catch (Exception)
                    {
                        XtraMessageBox.Show("Aktarým tamamlanamadý!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion Masraf Avansdan Dosya Muhasebe ve detay oluþtur

                this.tabDosyaMuhasebesi.Controls.Clear();

                UserControls.ucMuhasebeGenel ucMuhasebeDava = new UserControls.ucMuhasebeGenel("Dava", "Dosya", null);
                ucMuhasebeDava.Dock = System.Windows.Forms.DockStyle.Fill;
                ucMuhasebeDava.Location = new System.Drawing.Point(0, 0);
                ucMuhasebeDava.Name = "ucMuhasebeDava";
                ucMuhasebeDava.SaveStatus = false;
                ucMuhasebeDava.Size = new System.Drawing.Size(918, 276);
                ucMuhasebeDava.TabIndex = 9;

                ucMuhasebeDava.MyDavaFoyMuhasebeDetay = AvukatPro.Services.Implementations.MuhasebeService.GetAllMuhasebeFromDavaFoy(MyFoy.ID);
                ucMuhasebeDava.mainView.FocusedRowChanged += ucMuhasebeDava.gridView2_FocusedRowChanged;
                this.tabDosyaMuhasebesi.Controls.Add(ucMuhasebeDava);
            }

            else if (e.Page == tabPersonelHesabý) // PageVisible = false
            {
                if (ucMasraflar3 == null)
                    CreateUcMasraflar3();
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl3_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabTedbir)
            {
                if (ucDavaTedbirBilgileri1 == null)
                    CreateUcDavaTedbirBilgileri1();

                if (MyFoy != null)
                    ucDavaTedbirBilgileri1.MyFoy = MyFoy;
            }
            else if (e.Page == tabTespit)
            {
                if (ucDavaTespitBilgi1 == null)
                    CreateUcDavaTespitBilgi1();

                if (MyFoy != null)
                    ucDavaTespitBilgi1.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl4_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabGorusme)
            {
                if (gcGorusme == null)
                    CreateGcGorusme();

                if (MyFoy != null)
                    gcGorusme.MyFoy = MyFoy;
            }
            else if (e.Page == tabSms)
            {
                if (gcSms == null)
                    CreateGcSms();
            }
            else if (e.Page == tabMail)
            {
                if (ucEPosta1 == null)
                    CreateUcEPosta1();

                if (MyFoy != null)
                    ucEPosta1.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl5_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabBelgeler)
            {
                if (belge == null)
                    CreateBelge();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE>));
                if (MyFoy != null)
                {
                    belge.IdValue = MyFoy.ID;
                    belge.CurrentRecord = MyFoy;
                    belge.MyDataSource = BelgeUtil.Inits.BelgeGetirByDavaFoyId(MyFoy.ID);
                    belge.TableName = MyFoy.TableName;
                }
            }
            else if (e.Page == tabDavaSozlesmeleri)
            {
                if (ucSozlesmeGrid1 == null)
                    CreateUcSozlesmeGrid1();

                if (MyFoy != null)
                    ucSozlesmeGrid1.MyDavaFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl6_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage14)
            {
                if (ucIliskiDetay1 == null)
                    CreateUcIliskiDetay1();

                ucIliskiDetay1.GetList(MyFoy.ID, AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.DAVA_DOSYASI);
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl7_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabCelseBilgi)
            {
                if (gcCelse == null)
                    CreateGcCelse();

                if (MyFoy != null)
                    gcCelse.MyFoy = MyFoy;
            }
            else if (e.Page == tabAraKaraar)
            {
                if (gcAraKarar == null)
                    CreateGcAraKarar();

                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>));
                if (MyFoy != null)
                    gcAraKarar.MyFoy = MyFoy;
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl8_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabHukumBilgiler)
            {
                if (gcMahkemeHukum == null)
                    CreateGcMahkemeHukum();

                if (MyFoy != null)
                    gcMahkemeHukum.MyFoy = MyFoy;
            }
            else if (e.Page == tabTemyizbilgiler)
            {
                if (gcTemyiz == null)
                    CreateGcTemyiz();

                if (MyFoy != null)
                    gcTemyiz.MyFoy = MyFoy;
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void xtraTabControl9_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (e.Page == tabDavaTalep)
            {
                if (gcDavaNeden == null)
                    CreateGcDavaNeden();

                if (MyFoy != null)
                    gcDavaNeden.MyFoy = MyFoy;
            }
            else if (e.Page == tabPIliskiliKayitlar)
            {
                if (dnGayrimenkulBilgileri == null)
                    CreateDnGayriMenkulBilgileri();

                dnGayrimenkulBilgileri.MyDavaFoy = MyFoy;
                NedeneBagliKayitGetir();
            }

            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        #endregion TabControl SelectedPageChanging Events
    }
}