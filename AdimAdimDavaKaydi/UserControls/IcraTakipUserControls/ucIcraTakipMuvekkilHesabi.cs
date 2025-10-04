using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatPro.Model.EntityClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIcraTakipMuvekkilHesabi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        private bool _kaydedildimi = false;
        private AV001_TI_BIL_FOY myFoy;

        private bool TreeNodeOpened;

        public ucIcraTakipMuvekkilHesabi()
        {
            if (DesignMode) InitializeComponent();
            this.Load += this.ucIcraTakipMuvekkilHesabi_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (myFoy != null && IsLoaded == true)
                    BindDatas();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeMuvekkilHesabi TreeList { get; set; }

        public void BindDatas()
        {
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MUVEKKIL_HESAP>), typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
            vekaletSozlesmesiniGenelBilgilereGir((int)MyFoy.VEKALET_SOZLESME_ID);
            if (myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
            {
                AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetByID((int)myFoy.VEKALET_SOZLESME_ID);
                bool stopaj = stopajOlacakmi(myFoy, vekaletSozlesme);
                AV001_TI_BIL_MUVEKKIL_HESAP muvekkilhesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
                if (myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
                    muvekkilhesap = myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0];
                myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Clear();
                myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Add(KDVHesapla(vekaletSozlesme.KDV_DAHIL, vekaletSozlesme.STOPAJ_ICINDE_MI, muvekkilhesap));
                BindUc(myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0], vekaletSozlesme);
                BindTreeListAfterHesap(myFoy, stopaj);

                //BindTreeListFromMuvekkilHesabi(myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0]);

                if (myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].HESAP_KAPAMA_TARIHI != null)
                {
                    txtDosyaKapamaTarihi.Text = MyFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].HESAP_KAPAMA_TARIHI == null ? "" : MyFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].HESAP_KAPAMA_TARIHI.Value.ToShortDateString();
                    btnDosyaKapatAc.Image = AdimAdimDavaKaydi.Properties.Resources.accept_22x221;
                    btnDosyaKapatAc.Text = "Dosya Müvekkil Hesabını Aç";
                    btnDosyaKapatAc.Tag = "aç";
                }
            }

            #region BindingSources DataSource

            bndIcraFoy.DataSource = myFoy;

            if (MyFoy.SON_HESAP_TARIHI != null)
                txtSonHesapTarihi.Text = MyFoy.SON_HESAP_TARIHI.Value.ToShortDateString();

            bndMuvekkilHesabi.DataSource = myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection;

            #endregion BindingSources DataSource
        }

        public void BindLookUps()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueMudurluk.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lueNo.Properties);
            BelgeUtil.Inits.FoyDurumGetir(lueDurum);
        }

        private void BindTreeListAfterHesap(AV001_TI_BIL_FOY foy, bool stopajKullanilacakmi)
        {
            TreeList = null;
            myFoy = foy;
            TreeMuvekkilHesabi muvekkilHesabi = new TreeMuvekkilHesabi(foy, karsiVekaletUcretiStopaj, karsiVekaletUcretiKDV, stopajKullanilacakmi);
            if (muvekkilHesabi != null && treeMuvekkilHesabi != null)
            {
                TreeList = muvekkilHesabi;
                treeMuvekkilHesabi.DataSource = muvekkilHesabi;
                treeMuvekkilHesabi.DataMember = "NodeListesi";
            }
        }

        //private void BindTreeListFromMuvekkilHesabi(AV001_TI_BIL_MUVEKKIL_HESAP muvekkilHesap)
        //{
        //    TreeMuvekkilHesabi muvekkilHesabi = new TreeMuvekkilHesabi(muvekkilHesap);
        //    if (muvekkilHesabi != null && treeMuvekkilHesabi != null)
        //    {
        //        treeMuvekkilHesabi.DataSource = muvekkilHesabi;
        //        treeMuvekkilHesabi.DataMember = "NodeListesi";
        //    }
        //}

        private void BindUc(AV001_TI_BIL_MUVEKKIL_HESAP muvekkilHesap, AV001_TI_BIL_VEKALET_SOZLESME sozlesme)
        {
            ucTakipVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.TAKIP_VEKALET_UCRETI, muvekkilHesap.TAKIP_VEKALET_UCRETI_DOVIZ_ID);
            ucTahliyeVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.TAHLIYE_VEKALET_UCRETI, muvekkilHesap.TAHLIYE_VEKALET_UCRETI_DOVIZ_ID);
            ucTahDavaVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.TD_VEKALET_UCRETI, muvekkilHesap.TD_VEKALET_UCRETI_DOVIZ_ID);
            ucDavaVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.DAVA_VEKALET_UCRETI, muvekkilHesap.DAVA_VEKALET_UCRETI_DOVIZ_ID);
            ucDepoVekaletUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.DEPO_VEKALET_UCRETI, muvekkilHesap.DEPO_VEKALET_UCRETI_DOVIZ_ID);
            ucIhtHacizVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.IHTIYATI_HACIZ_VEKALET_UCRETI, muvekkilHesap.IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID);
            ucIhtTedbirVekUcreti.Tutar = new ParaVeDovizId(muvekkilHesap.IHTIYATI_TEDBIR_VEKALET_UCRETI, muvekkilHesap.IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID);
            paraIndirimMiktari.Tutar = new ParaVeDovizId(muvekkilHesap.INDIRIM_MIKTARI, muvekkilHesap.INDIRIM_MIKTARI_DOVIZ_ID);
        }

        private List<AV001_TDI_BIL_FOY_MUHASEBE> MuhasebeFoyKaydet(AV001_TDI_BIL_MASRAF_AVANS ma)
        {
            List<AV001_TDI_BIL_FOY_MUHASEBE> masrafAvansFoyListesi = new List<AV001_TDI_BIL_FOY_MUHASEBE>();

            AV001_TDI_BIL_FOY_MUHASEBE mm = new AV001_TDI_BIL_FOY_MUHASEBE();
            mm.MUHASEBE_HEDEF_TIP = ma.CARI_HESAP_HEDEF_TIP;
            mm.MASRAF_AVANS_ID = ma.ID;
            mm.REFERANS_NO = ma.REFERANS_NO;
            mm.OTOMATIK_HESAPLANDI = false;
            mm.ACIKLAMA = ma.ACIKLAMA;
            mm.KAYIT_TARIHI = ma.KAYIT_TARIHI;
            mm.KLASOR_KODU = ma.KLASOR_KODU;
            mm.SUBE_KODU = ma.SUBE_KODU;
            mm.KONTROL_NE_ZAMAN = ma.KONTROL_NE_ZAMAN;
            mm.KONTROL_KIM = ma.KONTROL_KIM;
            mm.KONTROL_VERSIYON = ma.KONTROL_VERSIYON;
            mm.STAMP = ma.STAMP;
            mm.KONTROL_KIM_ID = ma.KONTROL_KIM_ID;
            mm.SUBE_KOD_ID = ma.SUBE_KOD_ID;
            mm.ILAM_ID = ma.ILAM_ID;
            mm.MASRAF_AVANS_TIP_ID = 2;

            if (ma.CARI_HESAP_HEDEF_TIP == 1)
                mm.ICRA_FOY_ID = ma.ICRA_FOY_ID;
            else if (ma.CARI_HESAP_HEDEF_TIP == 2)
                mm.DAVA_FOY_ID = ma.DAVA_FOY_ID;
            else if (ma.CARI_HESAP_HEDEF_TIP == 3)
                mm.HAZIRLIK_ID = ma.HAZIRLIK_ID;


            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY maDetay in ma.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
            {
                var mmDetay = mm.AV001_TDI_BIL_FOY_MUHASEBE_DETAYCollection.AddNew();
                mmDetay.FOY_MUHASEBE_ID = mm.ID;
                mmDetay.YENIDEN_HESAPLANABILIR = false;
                mmDetay.TARIH = maDetay.TARIH;
                mmDetay.HAREKET_ANA_KATEGORI_ID = maDetay.HAREKET_ANA_KATEGORI_ID;
                mmDetay.HAREKET_ANA_KATEGORI = maDetay.HAREKET_ANA_KATEGORI;
                mmDetay.HAREKET_ALT_KATEGORI_ID = maDetay.HAREKET_ALT_KATEGORI_ID;
                mmDetay.HAREKET_ALT_KATEGORI = maDetay.HAREKET_ALT_KATEGORI;
                mmDetay.ADET = maDetay.ADET;
                mmDetay.BIRIM_FIYAT_DOVIZ_ID = maDetay.BIRIM_FIYAT_DOVIZ_ID;
                mmDetay.BIRIM_FIYAT_DOVIZ = maDetay.BIRIM_FIYAT_DOVIZ;
                mmDetay.BIRIM_FIYAT_DOVIZ_KUR = maDetay.BIRIM_FIYAT_DOVIZ_KUR; ;
                mmDetay.BIRIM_FIYAT = maDetay.BIRIM_FIYAT;
                mmDetay.KDV_DAHIL = maDetay.KDV_DAHIL;
                mmDetay.KDV_ORAN = maDetay.KDV_ORAN;
                mmDetay.KDV_TUTAR = maDetay.KDV_TUTAR;
                mmDetay.STOPAJ_SSDF_DAHIL = maDetay.STOPAJ_SSDF_DAHIL;
                mmDetay.STOPAJ_ORAN = maDetay.STOPAJ_ORAN;
                mmDetay.SSDF_ORAN = maDetay.SSDF_ORAN;
                mmDetay.STOPAJ_SSDF_TUTAR = maDetay.STOPAJ_SSDF_TUTAR;
                mmDetay.TOPLAM_TUTAR = maDetay.TOPLAM_TUTAR;
                mmDetay.GENEL_TOPLAM = maDetay.GENEL_TOPLAM;
                mmDetay.ACIKLAMA = maDetay.ACIKLAMA;
                mmDetay.KAYIT_TARIHI = maDetay.KAYIT_TARIHI;
                mmDetay.KLASOR_KODU = maDetay.KLASOR_KODU;
                mmDetay.SUBE_KODU = maDetay.SUBE_KODU;
                mmDetay.KONTROL_NE_ZAMAN = maDetay.KONTROL_NE_ZAMAN;
                mmDetay.KONTROL_KIM = maDetay.KONTROL_KIM;
                mmDetay.KONTROL_VERSIYON = maDetay.KONTROL_VERSIYON;
                mmDetay.STAMP = maDetay.STAMP;
                mmDetay.KONTROL_KIM_ID = maDetay.KONTROL_KIM_ID;
                mmDetay.SUBE_KOD_ID = maDetay.SUBE_KOD_ID;
                mmDetay.KIYMETLI_EVRAK_ID = maDetay.KIYMETLI_EVRAK_ID;
                mmDetay.SEGMENT_ID = maDetay.SEGMENT_ID;
                mmDetay.ICRA_ODEME_ID = maDetay.ICRA_ODEME_ID;
                mmDetay.DAVA_ODEME_ID = maDetay.DAVA_ODEME_ID;
                mmDetay.MUVEKKILE_ODEME_ID = maDetay.MUVEKKILE_ODEME_ID;
                mmDetay.MASRAF_AVANS_DETAY_ID = maDetay.ID;
                mmDetay.MUHATAP_HESAP_SAHIBI_CARI_ID = maDetay.MUHATAP_HESAP_SAHIBI_CARI_ID;
                mmDetay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = maDetay.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID;
                mmDetay.BURO_HESAP_SAHIBI_CARI_ID = maDetay.BURO_HESAP_SAHIBI_CARI_ID;
                mmDetay.BURO_HESAP_SAHIBI_CARI_BANKA_ID = maDetay.BURO_HESAP_SAHIBI_CARI_BANKA_ID;
                mmDetay.MUHASEBELESTIRILMEMIS_MIKTAR = maDetay.GENEL_TOPLAM;
                mmDetay.MUHASEBELESTIRILMEMIS_MIKTAR_DOVIZ_ID = maDetay.GENEL_TOPLAM_DOVIZ_ID;
                mmDetay.BANKA_DEKONT_NO = maDetay.BANKA_DEKONT_NO;
                mmDetay.EFT_REFERANS_NO = maDetay.EFT_REFERANS_NO;
                mmDetay.ODEME_TIP_ID = maDetay.ODEME_TIP_ID;
                mmDetay.BORC_ALACAK_ID = maDetay.BORC_ALACAK_ID;
                mmDetay.MUVEKKIL_CARI_ID = maDetay.MUVEKKIL_CARI_ID;
            } 
            
            masrafAvansFoyListesi.Add(mm);
            return masrafAvansFoyListesi;
        }

        private void MasrafAvansDetayGuncelle(AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafAvansDetay)
        {
            try
            {
                DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Update(masrafAvansDetay);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void MasrafAvansDetayKaydet(AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafAvansDetay)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.Save(tran, masrafAvansDetay);
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void treeMuvekkilHesabi_AfterCollapse(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeNodeOpened = false;
        }

        private void treeMuvekkilHesabi_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeNodeOpened = true;
        }

        private void ucIcraTakipMuvekkilHesabi_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            if (!IsLoaded)
            {
                InitializeComponent();
                IsLoaded = true;
                BindLookUps();

                if (myFoy != null)
                    BindDatas();
            }
        }

        private void vekaletSozlesmesiniGenelBilgilereGir(int vekaletSozlesmeId)
        {
            Av001TiBilVekaletSozlesmeEntity sozlesme = AvukatPro.Services.Implementations.DosyaService.GetSozlesmeById(vekaletSozlesmeId);
            txtSozlesmeTarihi.Text = sozlesme.SozlesmeTarihi.ToShortDateString();
            txtSozlesme.Text = sozlesme.SozlesmeKategori;
        }

        #region Button Clicks

        private void btnDosyaKapatAc_Click(object sender, EventArgs e)
        {
            btnDosyaKapatAc.Enabled = false;

            if (btnDosyaKapatAc.Tag == "kapat")
            {
                AvukatPro.Services.Implementations.CariService.MuvekkilHesabiAcKapat(MyFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].ID, DateTime.Now.Date);
                txtDosyaKapamaTarihi.Text = DateTime.Now.Date.ToShortDateString();
                btnDosyaKapatAc.Image = AdimAdimDavaKaydi.Properties.Resources.accept_22x221;
                btnDosyaKapatAc.ToolTip = "Dosyanın müvekkil hesabını aktif hale getir.";
                btnDosyaKapatAc.Text = "Dosya Müvekkil Hesabını Aç";
                btnDosyaKapatAc.Tag = "aç";
            }

            else if (btnDosyaKapatAc.Tag == "aç")
            {
                AvukatPro.Services.Implementations.CariService.MuvekkilHesabiAcKapat(MyFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].ID, null);
                txtDosyaKapamaTarihi.Text = "";
                btnDosyaKapatAc.Image = AdimAdimDavaKaydi.Properties.Resources.kapat_22x221;
                btnDosyaKapatAc.ToolTip = "Dosyanın müvekkil hesabını mevcut haliyle işlemlere kapatır.";
                btnDosyaKapatAc.Text = "Dosya Müvekkil Hesabını Kapat";
                btnDosyaKapatAc.Tag = "kapat";
            }

            btnDosyaKapatAc.Enabled = true;
        }

        public void kaydet(bool ServistenMi)
        {
            var data = treeMuvekkilHesabi.DataSource as TreeMuvekkilHesabi;

            TreeMuvekkilHesabi treeClass = data;

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();
                
                if (DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.GetByICRA_FOY_ID(myFoy.ID).Count > 0)
                {
                    
                    DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.Update(tran, treeClass.GetMuvekkilHesap(myFoy));
                }
                else
                {
                    //aykut (ekledi if cümlesini)
                    //if (myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].ICRA_TAKIP_SOZLESME_ID != null)
                    if (myFoy.VEKALET_SOZLESME_ID != null)
                        DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.Save(tran, treeClass.GetMuvekkilHesap(myFoy));
                }

                tran.Commit();
                _kaydedildimi = true;
                if (!ServistenMi)
                    XtraMessageBox.Show("Kayıt İşlemi Başarı ile Gerçekleştirildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void sbtnAgaciAc_Click(object sender, EventArgs e)
        {
            if (TreeNodeOpened)
            {
                treeMuvekkilHesabi.CollapseAll();
                sbtnAgaciAc.Text = "Ağacı Aç";
            }
            else
            {
                treeMuvekkilHesabi.ExpandAll();
                sbtnAgaciAc.Text = "Ağacı Kapat";
            }
        }

        #region Raporlar

        private void sbtnExceleGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|Excel Dosyası";
            sfd.DefaultExt = "xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMuvekkilHesabi.ExportToXls(sfd.FileName);
            }
        }

        private void sbtnPDFeGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.pdf|PDF Dosyası";
            sfd.DefaultExt = "pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMuvekkilHesabi.ExportToPdf(sfd.FileName);
            }
        }

        private void sbtnRaporDuzenleyicisineGonder_Click(object sender, EventArgs e)
        {
            treeMuvekkilHesabi.ExpandAll();
            AdimAdimDavaKaydi.Util.ExtendedGridControl.YazdirmaOnizleme(treeMuvekkilHesabi);
        }

        private void sbtnWordeGonder_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.rtf|Word Dosyası";
            sfd.DefaultExt = "rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeMuvekkilHesabi.ExportToRtf(sfd.FileName);
            }
        }

        #endregion Raporlar

        private void sbtnHesapla_Click(object sender, EventArgs e)
        {
            MyFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection = null;
            FaizOranlariHesapla(MyFoy, false);
            sbtnKaydet.Enabled = true;
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            kaydet(false);
        }

        private void sbtnKullaniciDuzenlemelerineGoreHesapla_Click(object sender, EventArgs e)
        {
            AV001_TI_BIL_FOY foy = myFoy;
            AV001_TI_BIL_MUVEKKIL_HESAP muvekkilhesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
            if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
                muvekkilhesap = myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0];

            if (ucTakipVekUcreti.Tutar != null)
            {
                muvekkilhesap.TAKIP_VEKALET_UCRETI = ucTakipVekUcreti.Tutar.Para;
                muvekkilhesap.TAKIP_VEKALET_UCRETI_DOVIZ_ID = ucTakipVekUcreti.Tutar.DovizId;
            }

            muvekkilhesap.TAHLIYE_VEKALET_UCRETI = ucTahliyeVekUcreti.Tutar.Para;
            muvekkilhesap.TAHLIYE_VEKALET_UCRETI_DOVIZ_ID = ucTahliyeVekUcreti.Tutar.DovizId;
            muvekkilhesap.TD_VEKALET_UCRETI = ucTahDavaVekUcreti.Tutar.Para;
            muvekkilhesap.TD_VEKALET_UCRETI_DOVIZ_ID = ucTahDavaVekUcreti.Tutar.DovizId;
            muvekkilhesap.DAVA_VEKALET_UCRETI = ucDavaVekUcreti.Tutar.Para;
            muvekkilhesap.DAVA_VEKALET_UCRETI_DOVIZ_ID = ucDavaVekUcreti.Tutar.DovizId;
            muvekkilhesap.DEPO_VEKALET_UCRETI = ucDepoVekaletUcreti.Tutar.Para;
            muvekkilhesap.DEPO_VEKALET_UCRETI_DOVIZ_ID = ucDepoVekaletUcreti.Tutar.DovizId;
            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = ucIhtHacizVekUcreti.Tutar.Para;
            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID = ucIhtHacizVekUcreti.Tutar.DovizId;
            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = ucIhtTedbirVekUcreti.Tutar.Para;
            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID = ucIhtTedbirVekUcreti.Tutar.DovizId;
            muvekkilhesap.INDIRIM_MIKTARI = paraIndirimMiktari.Tutar.Para;
            muvekkilhesap.INDIRIM_MIKTARI_DOVIZ_ID = paraIndirimMiktari.Tutar.DovizId;
            foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Add(muvekkilhesap);
            FaizOranlariHesapla(foy, true);
            sbtnKaydet.Enabled = true;
        }

        private void sbtnMuhasebeKaydiOlustur_Click(object sender, EventArgs e)
        {
            if (_kaydedildimi == false)
                kaydet(false);

            AV001_TDI_BIL_MASRAF_AVANS masraf = bndMasrafMuhasebe.Current as AV001_TDI_BIL_MASRAF_AVANS;
            masraf.RUCU_NO = myFoy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].ID;

            myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection = (TList<AV001_TDI_BIL_MASRAF_AVANS>)DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(myFoy.ID);

            //if (myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Count > 0)
            //{
            //    foreach (var item in myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            //    {
            //        if (item.RUCU_NO==masraf.RUCU_NO)
            //        {
            //        }
            //    }
            //}

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                if (myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Exists(m => m.RUCU_NO == masraf.RUCU_NO))
                {
                    masraf.ID = myFoy.AV001_TDI_BIL_MASRAF_AVANSCollection.Where(m => m.RUCU_NO == masraf.RUCU_NO).Single().ID;
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Update(tran, masraf);
                }
                else
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.Save(tran, masraf);
                }

                tran.Commit();

                foreach (var item in masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                {
                    AV001_TDI_BIL_MASRAF_AVANS gelen = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(myFoy.ID).Where(m => m.RUCU_NO == masraf.RUCU_NO).Single();
                    gelen.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(gelen.ID);

                    if (gelen.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Exists(m => m.HAREKET_ALT_KATEGORI == item.HAREKET_ALT_KATEGORI))
                    {
                        item.ID = gelen.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Where(m => m.HAREKET_ALT_KATEGORI == item.HAREKET_ALT_KATEGORI).Single().ID;
                        item.MASRAF_AVANS_ID = masraf.ID;
                        MasrafAvansDetayGuncelle(item);
                    }
                    else
                    {
                        item.MASRAF_AVANS_ID = masraf.ID;
                        MasrafAvansDetayKaydet(item);
                    }
                }

                foreach (AV001_TDI_BIL_FOY_MUHASEBE item in MuhasebeFoyKaydet(masraf))
                {
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_FOY_MUHASEBEProvider.DeepSave(item);
                }                
            }

            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            //MessageBox.Show("Kayıt işlemi tamamlandı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Button Clicks

        #region edit

        //private void paraIndirimMiktari_TutarDegisti(object sender, EventArgs e)
        //{
        //    //(treeMuvekkilHesabi.DataSource as TreeMuvekkilHesabi).NodeListesi.Where(
        //    //    vi => vi.Node == TreeMuvekkilHesabi.HesapNode.HesapEnum.INDIRIM_MIKTARI).First().ValueBorc =
        //    //    paraIndirimMiktari.Tutar;

        ////    TreeMuvekkilHesabi treeClass = new TreeMuvekkilHesabi(myFoy);
        ////    treeClass.NodeToplam(treeMuvekkilHesabi.DataSource as TreeMuvekkilHesabi);

        ////    treeMuvekkilHesabi.RefreshDataSource();
        //}

        //private void ucTakipVekUcreti_TutarDegisti(object sender, EventArgs e)
        //{
        //    //TreeMuvekkilHesabi treeClass = new TreeMuvekkilHesabi(myFoy,);
        //}

        #endregion edit

        #region <TS-20111117> Hesap

        public decimal karsiVekaletUcretiKDV;

        public decimal karsiVekaletUcretiStopaj;

        public void FaizOranlariHesapla(AV001_TI_BIL_FOY foy, bool sabitDegerlerlemi)
        {
            if (foy.VEKALET_SOZLESME_ID == null)
            {
                foy.VEKALET_SOZLESME_ID = 5;
            }

            AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetByID((int)foy.VEKALET_SOZLESME_ID);
            DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(vekaletSozlesme, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
            AV001_TI_BIL_MUVEKKIL_HESAP muvekkilhesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
            if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
                muvekkilhesap = foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0];

            if (vekaletSozlesme.SABIT_TUTAR > 0)
            {
                List<ParaVeDovizId> sabitTutarList = new List<ParaVeDovizId>();
                foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                {
                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);

                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }
                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.TAKIP_VEKALET_UCRETI = tutari;
                    }
                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);

                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }

                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = tutari;
                    }

                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);
                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }

                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.TD_VEKALET_UCRETI = tutari;
                    }
                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);
                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }
                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = tutari;
                    }
                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);
                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }
                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = tutari;
                    }
                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                    {
                        ParaVeDovizId degeri = KategoriDegeri(item, foy);
                        decimal tutari;

                        if (sabitDegerlerlemi)
                        {
                            tutari = degeri.Para;
                        }
                        else
                        {
                            double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
                            tutari = degeri.Para * (decimal)orani / 100;
                        }

                        muvekkilhesap.DAVA_VEKALET_UCRETI = tutari;
                    }
                }

                ParaVeDovizId sonuc = new ParaVeDovizId(vekaletSozlesme.SABIT_TUTAR, vekaletSozlesme.SABIT_TUTAR_DOVIZ_ID);
                sabitTutarList.Add(sonuc);
                var toplam = ParaVeDovizId.Topla(sabitTutarList);
                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
            }
            else
            {
                if (foy.FOY_DURUM_ID == 3)//Aciz
                {
                    List<ParaVeDovizId> acizListe = new List<ParaVeDovizId>();
                    foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                    {
                        ParaVeDovizId foyAcizDegeri = KategoriDegeri(item, foy);
                        double acizOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

                        decimal acizTutari = foyAcizDegeri.Para * (decimal)acizOrani / 100;
                        decimal acizSabitTutari = foyAcizDegeri.Para;

                        if (sabitDegerlerlemi)
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = acizSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = acizSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = acizSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = acizSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = acizSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = acizSabitTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(acizTutari, foyAcizDegeri.DovizId);

                                if (acizTutari != 0 && sonuc.Para != 0)
                                    acizListe.Add(sonuc);
                            }
                        }
                        else
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = acizTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = acizTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = acizTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = acizTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = acizTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = acizTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(acizTutari, foyAcizDegeri.DovizId);

                                if (acizTutari != 0 && sonuc.Para != 0)
                                    acizListe.Add(sonuc);
                            }
                        }
                    }
                    var toplam = ParaVeDovizId.Topla(acizListe);
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                }
                else if (foy.FOY_DURUM_ID == 4)
                {
                    if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue &&
                        foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue)
                    {
                        if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI <
                            foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI ||
                            (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue &&
                             !foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue)) //Düşme
                        {
                            List<ParaVeDovizId> dusmeListe = new List<ParaVeDovizId>();

                            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                            {
                                ParaVeDovizId foyDusmeDegeri = KategoriDegeri(item, foy);
                                double dusmeOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

                                decimal dusmeTutari = foyDusmeDegeri.Para * (decimal)dusmeOrani / 100;
                                decimal dusmeSabitTutari = foyDusmeDegeri.Para;

                                if (sabitDegerlerlemi)
                                {
                                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                        muvekkilhesap.TAKIP_VEKALET_UCRETI = dusmeSabitTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = dusmeSabitTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                        muvekkilhesap.TD_VEKALET_UCRETI = dusmeSabitTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = dusmeSabitTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = dusmeSabitTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                        muvekkilhesap.DAVA_VEKALET_UCRETI = dusmeSabitTutari;

                                    else
                                    {
                                        ParaVeDovizId sonuc = new ParaVeDovizId(dusmeTutari, foyDusmeDegeri.DovizId);
                                        if (dusmeTutari != 0 && sonuc.Para != 0)
                                            dusmeListe.Add(sonuc);
                                    }
                                }

                                else
                                {
                                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                        muvekkilhesap.TAKIP_VEKALET_UCRETI = dusmeTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = dusmeTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                        muvekkilhesap.TD_VEKALET_UCRETI = dusmeTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = dusmeTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = dusmeTutari;

                                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                        muvekkilhesap.DAVA_VEKALET_UCRETI = dusmeTutari;

                                    else
                                    {
                                        ParaVeDovizId sonuc = new ParaVeDovizId(dusmeTutari, foyDusmeDegeri.DovizId);
                                        if (dusmeTutari != 0 && sonuc.Para != 0)
                                            dusmeListe.Add(sonuc);
                                    }
                                }
                            }
                            var toplam = ParaVeDovizId.Topla(dusmeListe);
                            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                        }
                    }
                }
                else if (foy.FOY_DURUM_ID == 5)//Feragat
                {
                    List<ParaVeDovizId> feragatListe = new List<ParaVeDovizId>();

                    foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                    {
                        ParaVeDovizId foyFeragatDegeri = KategoriDegeri(item, foy);
                        double feragatOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

                        decimal feragatTutari = foyFeragatDegeri.Para * (decimal)feragatOrani / 100;
                        decimal feragatSabitTutari = foyFeragatDegeri.Para;

                        if (sabitDegerlerlemi)
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = feragatSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = feragatSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = feragatSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = feragatSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = feragatSabitTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = feragatSabitTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(feragatTutari, foyFeragatDegeri.DovizId);

                                if (feragatTutari != 0 && sonuc.Para != 0)
                                    feragatListe.Add(sonuc);
                            }
                        }

                        else
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = feragatTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = feragatTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = feragatTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = feragatTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = feragatTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = feragatTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(feragatTutari, foyFeragatDegeri.DovizId);

                                if (feragatTutari != 0 && sonuc.Para != 0)
                                    feragatListe.Add(sonuc);
                            }
                        }
                    }

                    var toplam = ParaVeDovizId.Topla(feragatListe);
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                }
                else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count != 0)
                {
                    if (foy.AV001_TI_BIL_SATIS_MASTERCollection != null && foy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)//Satış Sonrası
                    {
                        List<ParaVeDovizId> satisSonraiInfazListe = new List<ParaVeDovizId>();

                        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                        {
                            ParaVeDovizId foySatisSonrasiInfazDegeri = KategoriDegeri(item, foy);
                            double satisSonrasiFaizOrani =
                                SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

                            decimal satisSonrasiFaizTutari = foySatisSonrasiInfazDegeri.Para *
                                                             (decimal)satisSonrasiFaizOrani / 100;
                            decimal satisSonrasiSabitFaizTutari = foySatisSonrasiInfazDegeri.Para;

                            if (sabitDegerlerlemi)
                            {
                                if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TAKIP_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                    muvekkilhesap.TAHLIYE_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TD_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                    muvekkilhesap.DAVA_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

                                else
                                {
                                    ParaVeDovizId sonuc = new ParaVeDovizId(satisSonrasiFaizTutari,
                                                                            foySatisSonrasiInfazDegeri.DovizId);

                                    if (satisSonrasiFaizTutari != 0 && sonuc.Para != 0)
                                        satisSonraiInfazListe.Add(sonuc);
                                }
                            }

                            else
                            {
                                if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TAKIP_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                    muvekkilhesap.TAHLIYE_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TD_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                    muvekkilhesap.DAVA_VEKALET_UCRETI = satisSonrasiFaizTutari;

                                else
                                {
                                    ParaVeDovizId sonuc = new ParaVeDovizId(satisSonrasiFaizTutari,
                                                                            foySatisSonrasiInfazDegeri.DovizId);

                                    if (satisSonrasiFaizTutari != 0 && sonuc.Para != 0)
                                        satisSonraiInfazListe.Add(sonuc);
                                }
                            }
                        }

                        var toplam = ParaVeDovizId.Topla(satisSonraiInfazListe);
                        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                    }
                    else//Satış Öncesi
                    {
                        List<ParaVeDovizId> satisOncesiInfazListe = new List<ParaVeDovizId>();

                        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                        {
                            ParaVeDovizId foySatisOncesiInfazDegeri = KategoriDegeri(item, foy);
                            double acizOrani =
                                SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

                            decimal foySatisOncesiTutari = foySatisOncesiInfazDegeri.Para * (decimal)acizOrani / 100;
                            decimal foySatisOncesiSabitTutari = foySatisOncesiInfazDegeri.Para; ;

                            if (sabitDegerlerlemi)
                            {
                                if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TAKIP_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                    muvekkilhesap.TAHLIYE_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TD_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                    muvekkilhesap.DAVA_VEKALET_UCRETI = foySatisOncesiSabitTutari;

                                else
                                {
                                    ParaVeDovizId sonuc = new ParaVeDovizId(foySatisOncesiTutari,
                                                                            foySatisOncesiInfazDegeri.DovizId);

                                    if (foySatisOncesiTutari != 0 && sonuc.Para != 0)
                                        satisOncesiInfazListe.Add(sonuc);
                                }
                            }

                            else
                            {
                                if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TAKIP_VEKALET_UCRETI = foySatisOncesiTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                    muvekkilhesap.TAHLIYE_VEKALET_UCRETI = foySatisOncesiTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                    muvekkilhesap.TD_VEKALET_UCRETI = foySatisOncesiTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = foySatisOncesiTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                    muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = foySatisOncesiTutari;

                                else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                    muvekkilhesap.DAVA_VEKALET_UCRETI = foySatisOncesiTutari;

                                else
                                {
                                    ParaVeDovizId sonuc = new ParaVeDovizId(foySatisOncesiTutari,
                                                                            foySatisOncesiInfazDegeri.DovizId);

                                    if (foySatisOncesiTutari != 0 && sonuc.Para != 0)
                                        satisOncesiInfazListe.Add(sonuc);
                                }
                            }
                        }

                        var toplam = ParaVeDovizId.Topla(satisOncesiInfazListe);
                        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                    }
                }
                else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)//Haciz Öncesi
                {
                    List<ParaVeDovizId> hacizOncesiInfazListe = new List<ParaVeDovizId>();

                    foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
                    {
                        ParaVeDovizId foyHacizOncesiInfazDegeri = KategoriDegeri(item, foy);
                        double hacizOncesiInfazOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).HACIZ_ONCESI_INFAZ;
                        decimal hacizOncesiInfazTutari = foyHacizOncesiInfazDegeri.Para *
                                                         (decimal)hacizOncesiInfazOrani / 100;
                        decimal hacizOncesiSabitInfazTutari = foyHacizOncesiInfazDegeri.Para;

                        if (sabitDegerlerlemi)
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(hacizOncesiInfazTutari,
                                                                        foyHacizOncesiInfazDegeri.DovizId);

                                if (hacizOncesiInfazTutari != 0 && sonuc.Para != 0)
                                    hacizOncesiInfazListe.Add(sonuc);
                            }
                        }

                        else
                        {
                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
                                muvekkilhesap.TAKIP_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
                                muvekkilhesap.TD_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
                                muvekkilhesap.DAVA_VEKALET_UCRETI = hacizOncesiInfazTutari;

                            else
                            {
                                ParaVeDovizId sonuc = new ParaVeDovizId(hacizOncesiInfazTutari,
                                                                        foyHacizOncesiInfazDegeri.DovizId);

                                if (hacizOncesiInfazTutari != 0 && sonuc.Para != 0)
                                    hacizOncesiInfazListe.Add(sonuc);
                            }
                        }
                    }
                    var toplam = ParaVeDovizId.Topla(hacizOncesiInfazListe);
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
                }
            }
            if (paraIndirimMiktari.Tutar.Para > 0)
            {
                muvekkilhesap.INDIRIM_MIKTARI = paraIndirimMiktari.Tutar.Para;
                muvekkilhesap.INDIRIM_MIKTARI_DOVIZ_ID = paraIndirimMiktari.Tutar.DovizId;
            }

            //if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
            //{ muvekkilhesap.DEPO_VEKALET_UCRETI = foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DEPO_VEKALET_UCRETI; }
            //else
            //{ muvekkilhesap.DEPO_VEKALET_UCRETI = foy.DEPO_VEKALET_UCRETI; }
            //muvekkilhesap.DEPO_VEKALET_UCRETI_DOVIZ_ID = foy.DEPO_VEKALET_UCRET_DOVIZ_ID;
            BindUc(muvekkilhesap, vekaletSozlesme);
            bool stopajKullanılacakmı = stopajOlacakmi(MyFoy, vekaletSozlesme);

            //TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();
            //foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
            //{
            //    if (item.TARAF_KODU == 1)
            //    {
            //        AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
            //        cariList.Add(cari);
            //    }
            //}

            //foreach (var item in cariList)
            //{
            //    if (item.VERGI_NO_KULLANIYOR_MU)
            //    {
            //        stopajKullanılacakmı = true;
            //        break;
            //    }
            //    else
            //    {
            //        vekaletSozlesme.STOPAJ_ICINDE_MI = false;
            //        stopajKullanılacakmı = false;
            //    }
            //}

            foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Add(KDVHesapla(vekaletSozlesme.KDV_DAHIL, vekaletSozlesme.STOPAJ_ICINDE_MI, muvekkilhesap));
            BindTreeListAfterHesap(foy, stopajKullanılacakmı);
        }

        private AV001_TDI_BIL_MASRAF_AVANS_DETAY indirimMasrafAvansi(decimal? miktar, int? dovizId)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafDetay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();

            foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (item.TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
                    cariList.Add(cari);
                }
            }

            foreach (var cariItem in cariList)
            {
                masrafDetay.MUVEKKIL_CARI_ID = cariItem.ID;
                masrafDetay.BIRIM_FIYAT = (decimal)miktar / cariList.Count;
                masrafDetay.TOPLAM_TUTAR = (decimal)miktar / cariList.Count;
                masrafDetay.HAREKET_ANA_KATEGORI_ID = 68;
                masrafDetay.HAREKET_ALT_KATEGORI_ID = 966;
                masrafDetay.HAREKET_ALT_KATEGORI = "INDIRIM";
                masrafDetay.KDV_TUTAR = 0;
                masrafDetay.STOPAJ_SSDF_TUTAR = 0;
                masrafDetay.GENEL_TOPLAM = (decimal)miktar;
                masrafDetay.BORC_ALACAK_ID = (int)BorcAlacak.Alacak;
                masrafDetay.ODEME_TIP_ID = (int)OdemeTip.NAKİT;
                masrafDetay.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
                masrafDetay.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;
                masrafDetay.ACIKLAMA = "Müvekkil hesabı formunda avukat tarafından yapılan özel indirimdir";
            }

            return masrafDetay;
        }

        //Seçili Kategorinin Foy tablosundaki değeri
        private ParaVeDovizId KategoriDegeri(AV001_TI_BIL_VEKALET_SOZLESME_DETAY detay, AV001_TI_BIL_FOY foy)
        {
            ParaVeDovizId tutar = new ParaVeDovizId();

            if (!detay.MUHASEBE_ALT_TUR_ID.HasValue)
                return tutar;

            #region Sözleşme değerlerine göre hesaplanıyorsa

            if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
            {
                switch (detay.MUHASEBE_ALT_TUR_ID)
                {
                    case (int)TakipAlacaklariAltKategoriler.ASIL_ALACAK:
                        tutar.Para = foy.ASIL_ALACAK;
                        tutar.DovizId = foy.ASIL_ALACAK_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İŞLEMİŞ_FAİZ:
                        tutar.Para = foy.ISLEMIS_FAIZ;
                        tutar.DovizId = foy.ISLEMIS_FAIZ_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BSMV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.BSMV_TO;
                        tutar.DovizId = foy.BSMV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KKDF_TAKİP_ÖNCESİ:
                        tutar.Para = foy.KKDV_TO;
                        tutar.DovizId = foy.KKDV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖİV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.OIV_TO;
                        tutar.DovizId = foy.OIV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KDV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.KDV_TO;
                        tutar.DovizId = foy.KDV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_GİDERİ:
                        tutar.Para = foy.IH_GIDERI;
                        tutar.DovizId = foy.IH_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_GİDERİ:
                        tutar.Para = foy.IT_GIDERI;
                        tutar.DovizId = foy.IT_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_VEKALET_ÜCRETİ:
                        tutar.Para = foy.ILAM_VEK_UCR;
                        tutar.DovizId = foy.ILAM_VEK_UCR_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_TEBLİĞ_GİDERİ:
                        tutar.Para = foy.ILAM_TEBLIG_GIDERI;
                        tutar.DovizId = foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_İNKAR_TAZMİNATI:
                        tutar.Para = foy.ILAM_INKAR_TAZMINATI;
                        tutar.DovizId = foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_GİDER:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_YARGILAMA_GİDERİ:
                        tutar.Para = foy.ILAM_YARGILAMA_GIDERI;
                        tutar.DovizId = foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_BAKİYE_KARAR_HARCI:
                        tutar.Para = foy.ILAM_BK_YARG_ONAMA;
                        tutar.DovizId = foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÇEK_TAZMİNATI:
                        tutar.Para = foy.KARSILIKSIZ_CEK_TAZMINATI;
                        tutar.DovizId = foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.YARGITAY_ONAMA_HARCI:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KOMİSYON:
                        tutar.Para = foy.CEK_KOMISYONU;
                        tutar.DovizId = foy.CEK_KOMISYONU_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_1:
                        tutar.Para = foy.OZEL_TUTAR1;
                        tutar.DovizId = foy.OZEL_TUTAR1_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_2:
                        tutar.Para = foy.OZEL_TUTAR2;
                        tutar.DovizId = foy.OZEL_TUTAR2_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_3:
                        tutar.Para = foy.OZEL_TUTAR3;
                        tutar.DovizId = foy.OZEL_TUTAR3_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TAZMİNAT:
                        tutar.Para = foy.OZEL_TAZMINAT;
                        tutar.DovizId = foy.OZEL_TAZMINAT_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.PROTESTO_GİDERİ:
                        tutar.Para = foy.PROTESTO_GIDERI;
                        tutar.DovizId = foy.PROTESTO_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTAR_GİDERİ:
                        tutar.Para = foy.IHTAR_GIDERI;
                        tutar.DovizId = foy.IHTAR_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAMGA_PULU:
                        tutar.Para = foy.DAMGA_PULU;
                        tutar.DovizId = foy.DAMGA_PULU_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.SONRAKİ_FAİZ:
                        tutar.Para = foy.SONRAKI_FAIZ;
                        tutar.DovizId = foy.SONRAKI_FAIZ_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BSMV_TAKİP_SONRASI:
                        tutar.Para = foy.BSMV_TS;
                        tutar.DovizId = foy.BSMV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KDV_TAKİP_SONRASI:
                        tutar.Para = foy.KDV_TS;
                        tutar.DovizId = foy.KDV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖİV_TAKİP_SONRASI:
                        tutar.Para = foy.OIV_TS;
                        tutar.DovizId = foy.OIV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.SONRAKİ_TAZMİNATLAR:
                        tutar.Para = foy.SONRAKI_TAZMINAT;
                        tutar.DovizId = foy.SONRAKI_TAZMINAT_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BİRİKMİŞ_NAFAKALAR:
                        tutar.Para = foy.BIRIKMIS_NAFAKA;
                        tutar.DovizId = foy.BIRIKMIS_NAFAKA_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İCRA_İNKAR_TAZMİNATI:
                        tutar.Para = foy.ICRA_INKAR_TAZMINATI;
                        tutar.DovizId = foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAVA_İNKAR_TAZMİNATI:
                        tutar.Para = foy.DAVA_INKAR_TAZMINATI;
                        tutar.DovizId = foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TEBLİGAT_GİDERİ:
                        tutar.Para = foy.ILK_TEBLIGAT_GIDERI;
                        tutar.DovizId = foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DİĞER_GİDER:
                        tutar.Para = foy.DIGER_GIDERLER;
                        tutar.DovizId = foy.DIGER_GIDERLER_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_GİDERİ:
                        tutar.Para = foy.TD_GIDERI;
                        tutar.DovizId = foy.TD_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KALAN_TAHSİL_HARCI:
                        tutar.Para = foy.KALAN_TAHSIL_HARCI;
                        tutar.DovizId = foy.KALAN_TAHSIL_HARCI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.MENKUL_TESLİM_HARCI:
                        tutar.Para = foy.TESLIM_HARCI;
                        tutar.DovizId = foy.TESLIM_HARCI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.CEZAEVİ_HARCI:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_HARCI:
                        tutar.Para = foy.TAHLIYE_HARCI;
                        tutar.DovizId = foy.TAHLIYE_HARCI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ:
                        if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI.HasValue)
                            tutar.Para = (decimal)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI;
                        else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI_DOVIZ_ID.HasValue)
                            tutar.DovizId = (int)foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI_DOVIZ_ID;
                        break;
                    default:
                        break;
                }
            }

            #endregion Sözleşme değerlerine göre hesaplanıyorsa

            #region Dosya değerlerine  göre hesaplanıyorsa

            else if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count == 0)
            {
                switch (detay.MUHASEBE_ALT_TUR_ID)
                {
                    case (int)TakipAlacaklariAltKategoriler.ASIL_ALACAK:
                        tutar.Para = foy.ASIL_ALACAK;
                        tutar.DovizId = foy.ASIL_ALACAK_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İŞLEMİŞ_FAİZ:
                        tutar.Para = foy.ISLEMIS_FAIZ;
                        tutar.DovizId = foy.ISLEMIS_FAIZ_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BSMV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.BSMV_TO;
                        tutar.DovizId = foy.BSMV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KKDF_TAKİP_ÖNCESİ:
                        tutar.Para = foy.KKDV_TO;
                        tutar.DovizId = foy.KKDV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖİV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.OIV_TO;
                        tutar.DovizId = foy.OIV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KDV_TAKİP_ÖNCESİ:
                        tutar.Para = foy.KDV_TO;
                        tutar.DovizId = foy.KDV_TO_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ:
                        tutar.Para = foy.IH_VEKALET_UCRETI;
                        tutar.DovizId = foy.IH_VEKALET_UCRETI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_GİDERİ:
                        tutar.Para = foy.IH_GIDERI;
                        tutar.DovizId = foy.IH_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ:
                        tutar.Para = foy.IT_VEKALET_UCRETI;
                        tutar.DovizId = foy.IT_VEKALET_UCRETI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_GİDERİ:
                        tutar.Para = foy.IT_GIDERI;
                        tutar.DovizId = foy.IT_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_VEKALET_ÜCRETİ:
                        tutar.Para = foy.ILAM_VEK_UCR;
                        tutar.DovizId = foy.ILAM_VEK_UCR_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_TEBLİĞ_GİDERİ:
                        tutar.Para = foy.ILAM_TEBLIG_GIDERI;
                        tutar.DovizId = foy.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_İNKAR_TAZMİNATI:
                        tutar.Para = foy.ILAM_INKAR_TAZMINATI;
                        tutar.DovizId = foy.ILAM_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_GİDER:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_YARGILAMA_GİDERİ:
                        tutar.Para = foy.ILAM_YARGILAMA_GIDERI;
                        tutar.DovizId = foy.ILAM_YARGILAMA_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İLAM_BAKİYE_KARAR_HARCI:
                        tutar.Para = foy.ILAM_BK_YARG_ONAMA;
                        tutar.DovizId = foy.ILAM_BK_YARG_ONAMA_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÇEK_TAZMİNATI:
                        tutar.Para = foy.KARSILIKSIZ_CEK_TAZMINATI;
                        tutar.DovizId = foy.KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.YARGITAY_ONAMA_HARCI:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KOMİSYON:
                        tutar.Para = foy.CEK_KOMISYONU;
                        tutar.DovizId = foy.CEK_KOMISYONU_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_1:
                        tutar.Para = foy.OZEL_TUTAR1;
                        tutar.DovizId = foy.OZEL_TUTAR1_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_2:
                        tutar.Para = foy.OZEL_TUTAR2;
                        tutar.DovizId = foy.OZEL_TUTAR2_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TUTAR_3:
                        tutar.Para = foy.OZEL_TUTAR3;
                        tutar.DovizId = foy.OZEL_TUTAR3_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖZEL_TAZMİNAT:
                        tutar.Para = foy.OZEL_TAZMINAT;
                        tutar.DovizId = foy.OZEL_TAZMINAT_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.PROTESTO_GİDERİ:
                        tutar.Para = foy.PROTESTO_GIDERI;
                        tutar.DovizId = foy.PROTESTO_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İHTAR_GİDERİ:
                        tutar.Para = foy.IHTAR_GIDERI;
                        tutar.DovizId = foy.IHTAR_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAMGA_PULU:
                        tutar.Para = foy.DAMGA_PULU;
                        tutar.DovizId = foy.DAMGA_PULU_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.SONRAKİ_FAİZ:
                        tutar.Para = foy.SONRAKI_FAIZ;
                        tutar.DovizId = foy.SONRAKI_FAIZ_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BSMV_TAKİP_SONRASI:
                        tutar.Para = foy.BSMV_TS;
                        tutar.DovizId = foy.BSMV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KDV_TAKİP_SONRASI:
                        tutar.Para = foy.KDV_TS;
                        tutar.DovizId = foy.KDV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.ÖİV_TAKİP_SONRASI:
                        tutar.Para = foy.OIV_TS;
                        tutar.DovizId = foy.OIV_TS_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.SONRAKİ_TAZMİNATLAR:
                        tutar.Para = foy.SONRAKI_TAZMINAT;
                        tutar.DovizId = foy.SONRAKI_TAZMINAT_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.BİRİKMİŞ_NAFAKALAR:
                        tutar.Para = foy.BIRIKMIS_NAFAKA;
                        tutar.DovizId = foy.BIRIKMIS_NAFAKA_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ:
                        tutar.Para = foy.TAKIP_VEKALET_UCRETI;
                        tutar.DovizId = foy.TAKIP_VEKALET_UCRETI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI:
                        tutar.Para = foy.TAHLIYE_VEK_UCR;
                        tutar.DovizId = foy.TAHLIYE_VEK_UCR_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ:
                        tutar.Para = foy.DAVA_VEKALET_UCRETI;
                        tutar.DovizId = foy.DAVA_VEKALET_UCRETI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ:
                        tutar.Para = foy.TD_VEK_UCR;
                        tutar.DovizId = foy.TD_VEK_UCR_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.İCRA_İNKAR_TAZMİNATI:
                        tutar.Para = foy.ICRA_INKAR_TAZMINATI;
                        tutar.DovizId = foy.ICRA_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DAVA_İNKAR_TAZMİNATI:
                        tutar.Para = foy.DAVA_INKAR_TAZMINATI;
                        tutar.DovizId = foy.DAVA_INKAR_TAZMINATI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TEBLİGAT_GİDERİ:
                        tutar.Para = foy.ILK_TEBLIGAT_GIDERI;
                        tutar.DovizId = foy.ILK_TEBLIGAT_GIDERI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.DİĞER_GİDER:
                        tutar.Para = foy.DIGER_GIDERLER;
                        tutar.DovizId = foy.DIGER_GIDERLER_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_GİDERİ:
                        tutar.Para = foy.TD_GIDERI;
                        tutar.DovizId = foy.TD_GIDERI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.KALAN_TAHSİL_HARCI:
                        tutar.Para = foy.KALAN_TAHSIL_HARCI;
                        tutar.DovizId = foy.KALAN_TAHSIL_HARCI_DOVIZ_ID.Value;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.MENKUL_TESLİM_HARCI:
                        tutar.Para = foy.TESLIM_HARCI;
                        tutar.DovizId = foy.TESLIM_HARCI_DOVIZ_ID;
                        break;

                    case (int)TakipAlacaklariAltKategoriler.CEZAEVİ_HARCI:
                        break;

                    case (int)TakipAlacaklariAltKategoriler.TAHLİYE_HARCI:
                        tutar.Para = foy.TAHLIYE_HARCI;
                        tutar.DovizId = foy.TAHLIYE_HARCI_DOVIZ_ID;
                        break;
                    default:
                        break;
                }
            }

            #endregion Dosya değerlerine  göre hesaplanıyorsa

            return tutar;
        }

        private AV001_TI_BIL_MUVEKKIL_HESAP KDVHesapla(Boolean kdvDahil, Boolean stopajDahil, AV001_TI_BIL_MUVEKKIL_HESAP muvekkilhesap)
        {
            TList<AV001_TDI_BIL_CARI> cariBorcluList = new TList<AV001_TDI_BIL_CARI>();
            AV001_TDI_BIL_MASRAF_AVANS masraf = new AV001_TDI_BIL_MASRAF_AVANS();
            AV001_TI_BIL_MUVEKKIL_HESAP muvekkilHesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
            karsiVekaletUcretiKDV = 0;
            karsiVekaletUcretiStopaj = 0;
            decimal[] kdvStopaj = new decimal[3];

            if (myFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
            {
                myFoy.AV001_TI_BIL_FOY_TARAFCollection = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(MyFoy.ID);
            }

            foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (item.TARAF_KODU == 3)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
                    cariBorcluList.Add(cari);
                }
            }

            muvekkilHesap = muvekkilhesap;

            masraf.ICRA_FOY_ID = myFoy.ID;
            masraf.CARI_ID = Kimlikci.Kimlik.CurrentCariId;
            masraf.CARI_HESAP_HEDEF_TIP = 1;
            masraf.REFERANS_NO = string.Format(@"{0}\{1}\{2}", DateTime.Today.Year, DateTime.Today.Month, Guid.NewGuid().ToString().Split('-')[0].ToUpper());
            masraf.BORCLU_CARI_ID = cariBorcluList[0].ID;
            masraf.MANUEL_KAYIT_MI = false;
            
            //if (!SonDurum.RapordanMi)
            //{
                if (muvekkilhesap.TAKIP_VEKALET_UCRETI > 0 && muvekkilhesap.TAKIP_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.TAKIP_VEKALET_UCRETI);
                    muvekkilHesap.TAKIP_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 426, "TAKIP_VEKALET_UCRETI"));
                }

                if (muvekkilhesap.TAHLIYE_VEKALET_UCRETI > 0 && muvekkilhesap.TAHLIYE_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.TAHLIYE_VEKALET_UCRETI);
                    muvekkilHesap.TAHLIYE_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 426, "TAHLIYE_VEKALET_UCRETI"));
                }

                if (muvekkilhesap.TD_VEKALET_UCRETI > 0 && muvekkilhesap.TD_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.TD_VEKALET_UCRETI);
                    muvekkilHesap.TD_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 427, "TD_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI > 0 && muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI);
                    muvekkilHesap.IHTIYATI_HACIZ_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 126, "IHTIYATI_HACIZ_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI > 0 && muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI);
                    muvekkilHesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 126, "IHTIYATI_TEDBIR_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.DAVA_VEKALET_UCRETI > 0 && muvekkilhesap.DAVA_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.DAVA_VEKALET_UCRETI);
                    muvekkilHesap.DAVA_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 427, "DAVA_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.DEPO_VEKALET_UCRETI > 0 && muvekkilhesap.DEPO_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.DEPO_VEKALET_UCRETI);
                    muvekkilHesap.DEPO_VEKALET_UCRETI = kdvStopaj[0];
                    karsiVekaletUcretiKDV = karsiVekaletUcretiKDV + kdvStopaj[1];
                    karsiVekaletUcretiStopaj = karsiVekaletUcretiStopaj + kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 2, 427, "DEPO_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI > 0 && muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI != null)
                {
                    kdvStopaj = kdvStopajHesapla(kdvDahil, stopajDahil, (decimal)muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI);
                    muvekkilHesap.TOPLAM_SOZLESME_VEKALET_UCRETI = kdvStopaj[0];
                    muvekkilHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI = kdvStopaj[1];
                    muvekkilHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI = kdvStopaj[2];
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 5, 234, "TOPLAM_SOZLESME_VEKALET_UCRETI"));
                }
                if (muvekkilhesap.INDIRIM_MIKTARI > 0)
                {
                    muvekkilHesap.INDIRIM_MIKTARI = muvekkilhesap.INDIRIM_MIKTARI;
                    muvekkilHesap.INDIRIM_MIKTARI_DOVIZ_ID = muvekkilhesap.INDIRIM_MIKTARI_DOVIZ_ID;
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(indirimMasrafAvansi(muvekkilhesap.INDIRIM_MIKTARI, muvekkilhesap.INDIRIM_MIKTARI_DOVIZ_ID));
                } 
            //}
            foreach (var item in myFoy.AV001_TI_BIL_HARCCollection)
            {
                kdvStopaj[0] = item.HARC_MIKTARI;
                kdvStopaj[1] = 0;
                kdvStopaj[2] = 0;

                if (item.NISPI_HARC_KALEM_ID == 2)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 630, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 3)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 631, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 4)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 633, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 11)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 644, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 12)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 634, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 13)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 635, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 14)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 37, 636, "NISPI HARC"));
                }
                else if (item.NISPI_HARC_KALEM_ID == 17)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 17, 853, "NISPI HARC"));
                }
                else if (item.MAKTU_HARC_KALEM_ID == 597)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 19, 597, "MAKTU HARC"));
                }
                else if (item.MAKTU_HARC_KALEM_ID == 874)
                {
                    masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Add(masrafAvansEkle(kdvStopaj, 19, 874, "MAKTU HARC"));
                }
            }

            bndMasrafMuhasebe.DataSource = masraf;
            return muvekkilHesap;
        }

        private decimal[] kdvStopajHesapla(Boolean kdvDahil, Boolean stopajDahil, decimal brutPara)
        {
            decimal[] kdvStopaj = new decimal[3];
            TDI_CET_KDV kdv = new TDI_CET_KDV();
            TDI_CET_DIGER_VERGI stopaj = new TDI_CET_DIGER_VERGI();

            var k = DataRepository.TDI_CET_KDVProvider.Find("KDV_AD='GENEL'");
            kdv = DataRepository.TDI_CET_KDVProvider.GetByKATEGORI_IDTARIH(k[0].KATEGORI_ID, k.Max(i => i.TARIH));
            var s = DataRepository.TDI_CET_DIGER_VERGIProvider.Find("VERGI_TUR='STOPAJ'");
            stopaj = DataRepository.TDI_CET_DIGER_VERGIProvider.GetByVERGI_TUR_IDTARIH(s[0].VERGI_TUR_ID, s.Max(i => i.TARIH));

            decimal kdvOran = (decimal)kdv.KDV_ORAN / 100;
            decimal stopajOran = (decimal)stopaj.VERGI_ORAN / 100;
            decimal brut = brutPara;
            decimal KDV = 0;
            decimal STOPAJ = 0;
            if (kdvDahil)
            {
                if (stopajDahil)//KDV ve STOPAJ Dahil-------
                {
                    //brut = brutPara / (100 + (decimal)kdv.KDV_ORAN + (decimal)stopaj.VERGI_ORAN) * 100;
                    KDV = brut * kdvOran;
                    STOPAJ = brut * stopajOran;
                    kdvStopaj[0] = brut + KDV;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
                else if (!stopajDahil)//KDV Dahil, STOPAJ Hariç
                {
                    //brut = brutPara / (100 + (decimal)kdv.KDV_ORAN) * 100;
                    KDV = brut * kdvOran;
                    STOPAJ = brutPara * stopajOran;
                    kdvStopaj[0] = brut;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
            }
            else if (!kdvDahil)
            {
                if (stopajDahil)//KDV Hariç, STOPAJ Dahil
                {
                    //brut = brutPara / (100 + (decimal)stopaj.VERGI_ORAN) * 100;
                    STOPAJ = brut * stopajOran;
                    KDV = brut * kdvOran;
                    kdvStopaj[0] = brut + KDV;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
                else if (!stopajDahil)//KDV ve STOPAJ Hariç
                {
                    KDV = brutPara * kdvOran;
                    STOPAJ = brutPara * stopajOran;
                    kdvStopaj[0] = brutPara;
                    kdvStopaj[1] = KDV;
                    kdvStopaj[2] = STOPAJ;
                }
            }
            return kdvStopaj;
        }

        private AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafAvansEkle(decimal[] avansKdvStopaj, int anaKategori, int altKategori, string kalem)
        {
            AV001_TDI_BIL_MASRAF_AVANS_DETAY masrafDetay = new AV001_TDI_BIL_MASRAF_AVANS_DETAY();
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();
            bool stopajKullanilacakmi = false;
            foreach (var item in myFoy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (item.TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
                    cariList.Add(cari);
                }
            }
            foreach (var item in cariList)
            {
                if (item.VERGI_NO_KULLANIYOR_MU)
                {
                    stopajKullanilacakmi = true;
                    break;
                }
                else
                {
                    stopajKullanilacakmi = false;
                }
            }
            foreach (var cariItem in cariList)
            {
                masrafDetay.MUVEKKIL_CARI_ID = cariItem.ID;
                masrafDetay.BIRIM_FIYAT = (decimal)avansKdvStopaj[0] / cariList.Count;
                masrafDetay.TOPLAM_TUTAR = (decimal)avansKdvStopaj[0] / cariList.Count;
                masrafDetay.HAREKET_ANA_KATEGORI_ID = anaKategori;
                masrafDetay.HAREKET_ALT_KATEGORI_ID = altKategori;
                masrafDetay.HAREKET_ALT_KATEGORI = kalem;
                masrafDetay.KDV_TUTAR = (decimal)avansKdvStopaj[1] / cariList.Count;
                masrafDetay.STOPAJ_SSDF_TUTAR = stopajKullanilacakmi == true ? (decimal)avansKdvStopaj[2] / cariList.Count : 0;
                masrafDetay.BORC_ALACAK_ID = (int)BorcAlacak.Borc;
                masrafDetay.ODEME_TIP_ID = (int)OdemeTip.NAKİT;
                masrafDetay.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
                masrafDetay.SUBE_KOD_ID = Kimlikci.Kimlik.SubeKodu;
                masrafDetay.GENEL_TOPLAM = masrafDetay.BIRIM_FIYAT + masrafDetay.KDV_TUTAR + masrafDetay.STOPAJ_SSDF_TUTAR;
            }

            return masrafDetay;
        }

        //Vekalet Sözleşme Detaydaki seçili Kategori
        private AV001_TI_BIL_VEKALET_SOZLESME_DETAY SeciliDetayKategorisi(int sozlesmeID, int? kategoriID)
        {
            AV001_TI_BIL_VEKALET_SOZLESME_DETAY detay =
                DataRepository.AV001_TI_BIL_VEKALET_SOZLESME_DETAYProvider.GetByVEKALET_SOZLESME_ID(sozlesmeID).Where(
                    vi => vi.MUHASEBE_ALT_TUR_ID == kategoriID.Value).FirstOrDefault();

            return detay;
        }

        private bool stopajOlacakmi(AV001_TI_BIL_FOY foy, AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme)
        {
            bool stopajKullanılacakmı = false;
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();

            if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
            {
                myFoy.AV001_TI_BIL_FOY_TARAFCollection = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(MyFoy.ID);
            }

            foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
            {
                if (item.TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
                    cariList.Add(cari);
                }
            }

            foreach (var item in cariList)
            {
                if (item.VERGI_NO_KULLANIYOR_MU)
                {
                    stopajKullanılacakmı = true;
                    break;
                }
                else
                {
                    vekaletSozlesme.STOPAJ_ICINDE_MI = false;
                    stopajKullanılacakmı = false;
                }
            }

            return stopajKullanılacakmı;
        }

        #endregion <TS-20111117> Hesap

        #region <TS-20111117> Takip Alacakları Enum

        public enum TakipAlacaklariAltKategoriler
        {
            ASIL_ALACAK = 507,
            İŞLEMİŞ_FAİZ = 537,
            BSMV_TAKİP_ÖNCESİ = 865,
            KKDF_TAKİP_ÖNCESİ = 866,
            ÖİV_TAKİP_ÖNCESİ = 867,
            KDV_TAKİP_ÖNCESİ = 868,
            İHTİYATİ_HACİZ_VEKALET_ÜCRETİ = 549,
            İHTİYATİ_HACİZ_GİDERİ = 854,
            İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ,
            İHTİYATİ_TEDBİR_GİDERİ,
            İLAM_VEKALET_ÜCRETİ = 553,
            İLAM_TEBLİĞ_GİDERİ = 864,
            İLAM_İNKAR_TAZMİNATI = 536,
            İLAM_GİDER = 534,
            İLAM_YARGILAMA_GİDERİ = 863,
            İLAM_BAKİYE_KARAR_HARCI = 862,
            ÇEK_TAZMİNATI = 530,
            YARGITAY_ONAMA_HARCI = 547,
            KOMİSYON = 538,
            ÖZEL_TUTAR_1 = 540,
            ÖZEL_TUTAR_2 = 541,
            ÖZEL_TUTAR_3 = 542,
            ÖZEL_TAZMİNAT = 539,
            PROTESTO_GİDERİ = 543,
            İHTAR_GİDERİ = 533,
            DAMGA_PULU = 853,
            SONRAKİ_FAİZ = 544,
            BSMV_TAKİP_SONRASI = 869,
            KDV_TAKİP_SONRASI = 871,
            ÖİV_TAKİP_SONRASI = 870,
            SONRAKİ_TAZMİNATLAR = 545,
            BİRİKMİŞ_NAFAKALAR = 529,
            TAKİP_VEKALET_ÜCRETİ = 548,
            TAHLİYE_VEKALET_ÜCRETI = 550,
            DAVA_VEKALET_ÜCRETİ = 551,
            TAHLİYE_DAVASI_VEKALET_ÜCRETİ = 552,
            İCRA_İNKAR_TAZMİNATI = 532,
            DAVA_İNKAR_TAZMİNATI = 531,
            TEBLİGAT_GİDERİ = 546,
            DİĞER_GİDER = 857,
            DAVA_GİDERİ = 856,
            TAHSİL_HARCI = 855,
            TAHLİYE_DAVASI_GİDERİ = 858,
            KALAN_TAHSİL_HARCI = 872,
            MENKUL_TESLİM_HARCI = 860,
            CEZAEVİ_HARCI = 859,
            TAHLİYE_HARCI = 861
        }

        #endregion <TS-20111117> Takip Alacakları Enum
    }

    #region <MB-20100302> AĞAÇ

    public class TreeMuvekkilHesabi
    {
        public TreeMuvekkilHesabi()
        {
        }

        #region Bind TreeList

        public TreeMuvekkilHesabi(AV001_TI_BIL_FOY foy, decimal karsiVekaletUcretiStopaj, decimal karsiVekaletUcretiKDV, bool stopajKullanilacakmi)
        {
            AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetByID((int)foy.VEKALET_SOZLESME_ID);
            DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(vekaletSozlesme, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));

            this.NodeListesi = new List<HesapNode>();

            NodeEkle(new HesapNode
                         {
                             Name = "Alınan Avans",
                             Node = HesapNode.HesapEnum.ALINAN_AVANS,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });
            NodeEkle(new HesapNode
                         {
                             Name = "İade Avans",
                             Node = HesapNode.HesapEnum.IADE_AVANS,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });

            NodeEkle(new HesapNode
            {
                Name = "Teminat Avansı",
                Node = HesapNode.HesapEnum.TEMINAT_AVANSI,
                ParentNode = HesapNode.HesapEnum.ROOT,
                imageIndex = 5
            });

            NodeEkle(new HesapNode
            {
                Name = "Teminat Avans İadesi",
                Node = HesapNode.HesapEnum.TEMINAT_AVANS_IADESI,
                ParentNode = HesapNode.HesapEnum.ROOT,
                imageIndex = 5
            });

            NodeEkle(new HesapNode
                         {
                             Name = "Müvekkil Tahsilatı",
                             Node = HesapNode.HesapEnum.MUVEKKIL_TAHSILATI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });
            NodeEkle(new HesapNode
                         {
                             Name = "Avukat Tahsilatı",
                             Node = HesapNode.HesapEnum.AVUKAT_TAHSILATI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });
            NodeEkle(new HesapNode
                         {
                             Name = "Resmi Masraf Toplamı",
                             Node = HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });

            NodeEkle(new HesapNode
                         {
                             Name = "İlk Giderler",
                             Node = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                             ParentNode = HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI,
                             imageIndex = 5
                         });

            ParaVeDovizId digerGiderler = new ParaVeDovizId(foy.DIGER_GIDERLER, foy.DIGER_GIDERLER_DOVIZ_ID);
            NodeEkle(new HesapNode
                         {
                             Name = "Diğer Giderler",
                             ValueBorc = digerGiderler,
                             Node = HesapNode.HesapEnum.DIGER_GIDERLER,
                             ParentNode = HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI,
                             imageIndex = 5
                         });

            NodeEkle(new HesapNode
                         {
                             Name = "Resmi Olmayan Masraflar",
                             Node = HesapNode.HesapEnum.RESMI_OLMAYAN_MASRAF_TOPLAMI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });

            if (vekaletSozlesme.DONMEYEN_GIDERLER)
            {
                NodeEkle(new HesapNode
                              {
                                  Name = "Dönmeyen Giderler",
                                  Node = HesapNode.HesapEnum.DONMEYEN_GIDER_TOPLAMI,

                                  //ValueAlacak = donmeyenGiderler,
                                  ParentNode = HesapNode.HesapEnum.ROOT,
                                  imageIndex = 5
                              });
            }

            NodeEkle(new HesapNode
                         {
                             Name = "Harç Toplamı",
                             Node = HesapNode.HesapEnum.HARC_TOPLAMI,
                             ParentNode = HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI,
                             imageIndex = 5
                         });
            ParaVeDovizId odenenTahsilHarci = new ParaVeDovizId(foy.ODENEN_TAHSIL_HARCI,
                                                                foy.ODENEN_TAHSIL_HARCI_DOVIZ_ID);
            NodeEkle(new HesapNode
                         {
                             Name = "Ödenen Tahsil Harcı",
                             ValueBorc = odenenTahsilHarci,
                             Node = HesapNode.HesapEnum.ODENEN_TAHSIL_HARCI,
                             ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                             imageIndex = 5
                         });
            ParaVeDovizId kalanTahsilHarci = new ParaVeDovizId();

            if (foy.BAKIYE_HARC_TOPLAMA_EKLE)
            {
                kalanTahsilHarci = new ParaVeDovizId(foy.KALAN_TAHSIL_HARCI, foy.KALAN_TAHSIL_HARCI_DOVIZ_ID);
            }

            NodeEkle(new HesapNode
                         {
                             Name = "Kalan Tahsil Harcı",
                             ValueBorc = kalanTahsilHarci,
                             Node = HesapNode.HesapEnum.KALAN_TAHSIL_HARCI,
                             ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                             imageIndex = 5
                         });

            if (vekaletSozlesme.CEZAEVI_HARCI)
            {
                NodeEkle(new HesapNode
                         {
                             Name = "Cezaevi Harcı",
                             Node = HesapNode.HesapEnum.CEZAEVI_HARCI,
                             ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                             imageIndex = 5
                         });

                foreach (var item in foy.AV001_TI_BIL_HARCCollection)
                {
                    if (item.NISPI_HARC_KALEM_ID == 11)
                    {
                        ParaVeDovizId cezaeviHarci = new ParaVeDovizId(item.HARC_MIKTARI, item.HARC_MIKTARI_DOVIZ_ID);
                        NodeEkle(new HesapNode
                        {
                            Name = "",
                            ValueBorc = cezaeviHarci,
                            Node = HesapNode.UniqNodeID,
                            ParentNode = HesapNode.HesapEnum.CEZAEVI_HARCI,
                            imageIndex = 5
                        });
                    }
                }
            }

            if (vekaletSozlesme.FERAGAT_HARCI)
            {
                NodeEkle(new HesapNode
                {
                    Name = "Feragat Harcı",
                    Node = HesapNode.HesapEnum.FERAGAT_HARCI,
                    ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                    imageIndex = 5
                });

                foreach (var item in foy.AV001_TI_BIL_HARCCollection)
                {
                    if (item.NISPI_HARC_KALEM_ID == 12 || item.NISPI_HARC_KALEM_ID == 13 || item.NISPI_HARC_KALEM_ID == 14)
                    {
                        ParaVeDovizId feragatHarci = new ParaVeDovizId(item.HARC_MIKTARI, item.HARC_MIKTARI_DOVIZ_ID);
                        NodeEkle(new HesapNode
                        {
                            Name = "",
                            ValueBorc = feragatHarci,
                            Node = HesapNode.UniqNodeID,
                            ParentNode = HesapNode.HesapEnum.FERAGAT_HARCI,
                            imageIndex = 5
                        });
                    }
                }
            }

            NodeEkle(new HesapNode
            {
                Name = "Tahliye Harcı",
                Node = HesapNode.HesapEnum.TAHLIYE_HARCI,
                ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                imageIndex = 5
            });

            NodeEkle(new HesapNode
                         {
                             Name = "Diğer Harçlar",
                             Node = HesapNode.HesapEnum.DIGER_HARCLAR,
                             ParentNode = HesapNode.HesapEnum.HARC_TOPLAMI,
                             imageIndex = 5
                         });
            NodeEkle(new HesapNode
                        {
                            Name = "İflas Harcı",
                            Node = HesapNode.HesapEnum.IFLAS_HARCI,
                            ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                            imageIndex = 5
                        });
            NodeEkle(new HesapNode
                         {
                             Name = "Vek. Ücret Toplamı",
                             Node = HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });
            NodeEkle(new HesapNode
                         {
                             Name = "Toplam Vek. Sözleşmesi Ücreti",
                             Node = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETLERI,
                             ParentNode = HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI,
                             imageIndex = 5
                         });
            ParaVeDovizId sozlesmeUcreti = new ParaVeDovizId(
                     foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
                         {
                             Name = "Sözleşmesi Ücreti",
                             ValueBorc = sozlesmeUcreti,
                             Node = HesapNode.HesapEnum.SOZLESME_UCRETI,
                             ParentNode = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETLERI,
                             imageIndex = 5
                         });

            ParaVeDovizId kdvUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI_DOVIZ_ID);
            NodeEkle(new HesapNode
                         {
                             Name = "Ücret KDV",
                             ValueBorc = kdvUcreti,
                             Node = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI,
                             ParentNode = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETLERI,
                             imageIndex = 5
                         });

            ParaVeDovizId stopajUcreti = new ParaVeDovizId();
            if (stopajKullanilacakmi)
            {
                stopajUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTAR_DOVIZ_ID);
            }

            NodeEkle(new HesapNode
                         {
                             Name = "Ücret Stopaj",
                             ValueBorc = stopajUcreti,
                             Node = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI,
                             ParentNode = HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETLERI,
                             imageIndex = 5
                         });

            NodeEkle(new HesapNode
            {
                Name = "Karşı Vekalet Ücretleri",
                Node = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                ParentNode = HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI,
                imageIndex = 5
            });

            ParaVeDovizId TakipVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI,
                                                                 foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Takip Vek. Ücreti",
                ValueBorc = TakipVekaletUcreti,
                Node = HesapNode.HesapEnum.TAKIP_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            ParaVeDovizId tahliyeVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAHLIYE_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Tahliye Vek. Ücreti",
                ValueBorc = tahliyeVekaletUcreti,
                Node = HesapNode.HesapEnum.TAHLIYE_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            ParaVeDovizId tahliyeDavaVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TD_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Tah.Dava Vek.Ücreti",
                ValueBorc = tahliyeDavaVekaletUcreti,
                Node = HesapNode.HesapEnum.TD_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            ParaVeDovizId davaVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI,
                                                                foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DAVA_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Dava Vek.Ücreti",
                ValueBorc = davaVekaletUcreti,
                Node = HesapNode.HesapEnum.DAVA_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });
            ParaVeDovizId depoVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DEPO_VEKALET_UCRETI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DEPO_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Depo Vek. Ücreti",
                ValueBorc = depoVekaletUcreti,
                Node = HesapNode.HesapEnum.DEPO_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });
            ParaVeDovizId ihtiyatiHacizVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI,
                                                                         foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "İht. Haciz Vek. Ücreti",
                ValueBorc = ihtiyatiHacizVekaletUcreti,
                Node = HesapNode.HesapEnum.IHTIYATI_HACIZ_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });
            ParaVeDovizId ihtiyatiTedbirVekaletUcreti = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "İht. Tedbir Vek. Ücreti",
                ValueBorc = ihtiyatiTedbirVekaletUcreti,
                Node = HesapNode.HesapEnum.IHTIYATI_TEDBIR_VEKALET_UCRETI,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            ParaVeDovizId kdv = new ParaVeDovizId(karsiVekaletUcretiKDV, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI_DOVIZ_ID);
            NodeEkle(new HesapNode
            {
                Name = "Ücret KDV",
                ValueBorc = kdv,
                Node = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI_KDV,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            ParaVeDovizId stopaj = new ParaVeDovizId();
            if (stopajKullanilacakmi)
            {
                stopaj = new ParaVeDovizId(karsiVekaletUcretiStopaj, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].TAKIP_VEKALET_UCRETI_DOVIZ_ID);
            }

            NodeEkle(new HesapNode
            {
                Name = "Ücret STOPAJ",
                ValueBorc = stopaj,
                Node = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI_STOPAJ,
                ParentNode = HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI,
                imageIndex = 5
            });

            Av001TiBilVekaletSozlesmeEntity sozlesme = AvukatPro.Services.Implementations.DosyaService.GetSozlesmeById((int)foy.VEKALET_SOZLESME_ID);

            #region Masraf Avans Detay Tablosundan alınan node'lar

            if (sozlesme.OdemelerdenOransalKesilsin == true && foy.AV001_TDI_BIL_MASRAF_AVANSCollection.Count > 0)
            {
                NodeEkle(new HesapNode
                {
                    Name = "Tahakkuk Eden Toplam Vekalet Ücreti",
                    Node = HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI,
                    ParentNode = HesapNode.HesapEnum.ROOT,
                    imageIndex = 5
                });

                NodeEkle(new HesapNode
                {
                    Name = "TE. Sözleşme Vekalet Ücreti",
                    Node = HesapNode.HesapEnum.TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI,
                    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI,
                    imageIndex = 5
                });

                NodeEkle(new HesapNode
                {
                    Name = "TE. Takip Vekalet Ücreti",
                    Node = HesapNode.HesapEnum.TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI,
                    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI,
                    imageIndex = 5
                });
            }

            #endregion Masraf Avans Detay Tablosundan alınan node'lar

            #region Müvekkil Ödeme Tablosundan Alınan Node'lar

            if (foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID.Count < 1)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_MUVEKKILE_ODEME>));

            //foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID = DataRepository.AV001_TI_BIL_MUVEKKILE_ODEMEProvider.GetByICRA_FOY_ID(foy);

            if (foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID != null)
            {
                ParaVeDovizId muvekkileOdemeToplami = null;
                foreach (var muvekkileOdeme in foy.AV001_TI_BIL_MUVEKKILE_ODEMECollectionGetByICRA_FOY_ID)
                {
                    ParaVeDovizId mOdeme = new ParaVeDovizId(muvekkileOdeme.MIKTAR, muvekkileOdeme.MIKTAR_DOVIZ_ID);

                    muvekkileOdemeToplami += ParaVeDovizId.Topla(mOdeme);
                }
                NodeEkle(new HesapNode
                             {
                                 Name = "Müvekkile Ödeme Toplamı",
                                 ValueBorc = muvekkileOdemeToplami,
                                 Node = HesapNode.HesapEnum.MUVEKKILE_ODEME_TOPLAMI,
                                 ParentNode = HesapNode.HesapEnum.ROOT,
                                 imageIndex = 5
                             });
            }

            NodeEkle(new HesapNode
                         {
                             Name = "Toplam",
                             Node = HesapNode.HesapEnum.TOPLAM,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         }); //Bütün node'ların toplamı alınacak.
            ParaVeDovizId indirim = new ParaVeDovizId(foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].INDIRIM_MIKTARI, foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].INDIRIM_MIKTARI_DOVIZ_ID);

            NodeEkle(new HesapNode
                         {
                             Name = "İndirim Miktarı",
                             ValueAlacak = indirim,
                             Node = HesapNode.HesapEnum.INDIRIM_MIKTARI,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         });

            NodeEkle(new HesapNode
                         {
                             Name = "Kalan",
                             Node = HesapNode.HesapEnum.KALAN_TUTAR,
                             ParentNode = HesapNode.HesapEnum.ROOT,
                             imageIndex = 5
                         }); //Toplamdan indirim miktarı çıkarılıp kalan elde edilecek.

            #endregion Müvekkil Ödeme Tablosundan Alınan Node'lar

            #region Masraf Tablosundan Alınan Node'lar

            if (foy.AV001_TDI_BIL_MASRAF_AVANSCollection.Count < 1)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));

            if (foy.AV001_TDI_BIL_MASRAF_AVANSCollection != null)
            {
                ParaVeDovizId toplamTakipKDV = new ParaVeDovizId();
                ParaVeDovizId toplamTakipStopaj = new ParaVeDovizId();
                ParaVeDovizId toplamSozlesmeKDV = new ParaVeDovizId();
                ParaVeDovizId toplamSozlesmeStopaj = new ParaVeDovizId();

                foreach (var masraf in foy.AV001_TDI_BIL_MASRAF_AVANSCollection)
                {
                    if (masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count < 1)
                        DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));

                    foreach (var masrafDetay in masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection)
                    {
                        if (masrafDetay != null)
                        {
                            if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 40 ||
                                masrafDetay.HAREKET_ALT_KATEGORI_ID == 4)
                            {
                                ParaVeDovizId alinanAvans = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR,
                                                                              masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                             {
                                                 Name = "",
                                                 ValueAlacak = alinanAvans,
                                                 Node = HesapNode.UniqNodeID,
                                                 NodePreview = masrafDetay.ACIKLAMA,
                                                 ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                 ParentNode = HesapNode.HesapEnum.ALINAN_AVANS,
                                                 imageIndex = 5
                                             });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 41 ||
                                     masrafDetay.HAREKET_ALT_KATEGORI_ID == 10006)
                            {
                                ParaVeDovizId iadeAvans = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR,
                                                                            masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                             {
                                                 Name = "",
                                                 ValueBorc = iadeAvans,
                                                 Node = HesapNode.UniqNodeID,
                                                 NodePreview = masrafDetay.ACIKLAMA,
                                                 ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                 ParentNode = HesapNode.HesapEnum.IADE_AVANS,
                                                 imageIndex = 5
                                             });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 316)
                            {
                                ParaVeDovizId teminat = new ParaVeDovizId { DovizId = masrafDetay.GENEL_TOPLAM_DOVIZ_ID, Para = masrafDetay.GENEL_TOPLAM };

                                NodeEkle(new HesapNode
                                             {
                                                 Name = "",
                                                 ValueAlacak = teminat,
                                                 NodePreview = masrafDetay.ACIKLAMA,
                                                 ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                 Node = HesapNode.UniqNodeID,
                                                 ParentNode = HesapNode.HesapEnum.TEMINAT_AVANSI,
                                                 imageIndex = 5
                                             });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 943)
                            {
                                ParaVeDovizId teminatIade = new ParaVeDovizId { DovizId = masrafDetay.GENEL_TOPLAM_DOVIZ_ID, Para = masrafDetay.GENEL_TOPLAM };

                                NodeEkle(new HesapNode
                                {
                                    Name = "",
                                    ValueBorc = teminatIade,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    Node = HesapNode.UniqNodeID,
                                    ParentNode = HesapNode.HesapEnum.TEMINAT_AVANS_IADESI,
                                    imageIndex = 5
                                });
                            }

                            if (vekaletSozlesme.ODEMELERDEN_ORANSAL_KESILSIN == true)
                            {
                                if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 40)
                                {
                                    ParaVeDovizId takipVekalet = new ParaVeDovizId { DovizId = masrafDetay.TOPLAM_TUTAR_DOVIZ_ID, Para = masrafDetay.TOPLAM_TUTAR };

                                    NodeEkle(new HesapNode
                                    {
                                        Name = "",
                                        ValueBorc = takipVekalet,
                                        NodePreview = masrafDetay.ACIKLAMA,
                                        ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                        Node = HesapNode.UniqNodeID,
                                        ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI,
                                        imageIndex = 5
                                    });

                                    toplamSozlesmeKDV.Para += masrafDetay.KDV_TUTAR;
                                    toplamSozlesmeStopaj.Para += masrafDetay.STOPAJ_SSDF_TUTAR;
                                    toplamSozlesmeKDV.DovizId = toplamSozlesmeStopaj.DovizId = masrafDetay.GENEL_TOPLAM_DOVIZ_ID;
                                }
                                else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 942)
                                {
                                    ParaVeDovizId sozlesmeVekalet = new ParaVeDovizId { DovizId = masrafDetay.TOPLAM_TUTAR_DOVIZ_ID, Para = masrafDetay.TOPLAM_TUTAR };

                                    NodeEkle(new HesapNode
                                    {
                                        Name = "",
                                        ValueBorc = sozlesmeVekalet,
                                        NodePreview = masrafDetay.ACIKLAMA,
                                        ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                        Node = HesapNode.UniqNodeID,
                                        ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI,
                                        imageIndex = 5
                                    });

                                    toplamTakipKDV.Para += masrafDetay.KDV_TUTAR;
                                    toplamTakipStopaj.Para += masrafDetay.STOPAJ_SSDF_TUTAR;
                                    toplamTakipKDV.DovizId = toplamTakipStopaj.DovizId = masrafDetay.GENEL_TOPLAM_DOVIZ_ID;
                                }
                            }

                            if (masrafDetay.HAREKET_ANA_KATEGORI_ID == 12 &&
                                    masrafDetay.HAREKET_ALT_KATEGORI_ID != 43)
                            {
                                if (!vekaletSozlesme.GIDERLER_AVUKATA_AIT)
                                {
                                    ParaVeDovizId resmiOlmayanMasrafToplami = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                    NodeEkle(new HesapNode
                                                 {
                                                     Name = "",
                                                     ValueBorc = resmiOlmayanMasrafToplami,
                                                     NodePreview = masrafDetay.ACIKLAMA,
                                                     ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                     Node = HesapNode.UniqNodeID,
                                                     ParentNode = HesapNode.HesapEnum.RESMI_OLMAYAN_MASRAF_TOPLAMI,
                                                     imageIndex = 5
                                                 });
                                }
                            }
                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 43)
                            {
                                if (vekaletSozlesme.DONMEYEN_GIDERLER)
                                {
                                    ParaVeDovizId donmeyenGiderler = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR,
                                                                                       masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                    NodeEkle(new HesapNode
                                                 {
                                                     Name = "",
                                                     ValueBorc = donmeyenGiderler,
                                                     NodePreview = masrafDetay.ACIKLAMA,
                                                     ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                     Node = HesapNode.UniqNodeID,
                                                     ParentNode = HesapNode.HesapEnum.DONMEYEN_GIDER_TOPLAMI,
                                                     imageIndex = 5
                                                 });
                                }
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 440)
                            {
                                ParaVeDovizId basvurmaHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
                                                                                                      masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);

                                NodeEkle(new HesapNode
                                            {
                                                Name = "Başvurma Harcı",
                                                ValueBorc = basvurmaHarci,
                                                Node = HesapNode.UniqNodeID,
                                                NodePreview = masrafDetay.ACIKLAMA,
                                                ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                ParentNode = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                                                imageIndex = 5
                                            });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 642 || masrafDetay.HAREKET_ALT_KATEGORI_ID == 643)
                            {
                                ParaVeDovizId tahliyeHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
                                                                                                     masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);

                                NodeEkle(new HesapNode
                                {
                                    Name = "",
                                    ValueBorc = tahliyeHarci,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    Node = HesapNode.UniqNodeID,
                                    ParentNode = HesapNode.HesapEnum.TAHLIYE_HARCI,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 568)
                            {
                                ParaVeDovizId odemeEmirGiderleri = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
                                                                                       masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                            {
                                                Name = "İlk Tebligat Gideri",
                                                ValueBorc = odemeEmirGiderleri,
                                                NodePreview = masrafDetay.ACIKLAMA,
                                                ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                Node = HesapNode.UniqNodeID,
                                                ParentNode = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                                                imageIndex = 5
                                            });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 11 || masrafDetay.HAREKET_ALT_KATEGORI_ID == 629)
                            {
                                ParaVeDovizId pesinHarc = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
                                                                                                      masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                            {
                                                Name = "Peşin Harç",
                                                ValueBorc = pesinHarc,
                                                Node = HesapNode.UniqNodeID,
                                                NodePreview = masrafDetay.ACIKLAMA,
                                                ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                ParentNode = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                                                imageIndex = 5
                                            });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 590)
                            {
                                ParaVeDovizId vekaletHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
               masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                              {
                                                  Name = "Vekalet Harcı",
                                                  ValueBorc = vekaletHarci,
                                                  Node = HesapNode.UniqNodeID,
                                                  NodePreview = masrafDetay.ACIKLAMA,
                                                  ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                  ParentNode = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                                                  imageIndex = 5
                                              });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 591)
                            {
                                ParaVeDovizId vekaletPulu = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR < 0 ? masrafDetay.TOPLAM_TUTAR * -1 : masrafDetay.TOPLAM_TUTAR,
                                                                                                      masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);

                                NodeEkle(new HesapNode
                                               {
                                                   Name = "Vekalet Pulu",
                                                   ValueBorc = vekaletPulu,
                                                   Node = HesapNode.UniqNodeID,
                                                   NodePreview = masrafDetay.ACIKLAMA,
                                                   ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                                   ParentNode = HesapNode.HesapEnum.ODEME_EMRI_GIDERI,
                                                   imageIndex = 5
                                               });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 853)
                            {
                                ParaVeDovizId damgaPulu = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Damga Pulu",
                                    ValueBorc = damgaPulu,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 452)
                            {
                                ParaVeDovizId iflasBasvurmaHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "İflas Başvurma Harcı",
                                    ValueBorc = iflasBasvurmaHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.IFLAS_HARCI,
                                    imageIndex = 5
                                });
                            }
                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 601)
                            {
                                ParaVeDovizId maktuIflasinAcilmaHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR,
                                                                                                      masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Maktu İflasın Açılma Harcı",
                                    ValueBorc = maktuIflasinAcilmaHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.IFLAS_HARCI,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 441)
                            {
                                ParaVeDovizId yerineGetirmeHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Yerine Getirme Harcı",
                                    ValueBorc = yerineGetirmeHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 597 || masrafDetay.HAREKET_ALT_KATEGORI_ID == 644)
                            {
                                ParaVeDovizId maktuNispiCezaEviHarcı = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Maktu Cezaevi Harcı",
                                    ValueBorc = maktuNispiCezaEviHarcı,
                                    Node = HesapNode.UniqNodeID,
                                    ParentNode = HesapNode.HesapEnum.IFLAS_HARCI,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 603)
                            {
                                ParaVeDovizId maktuKonkordatoHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Maktu Konkordato Harcı",
                                    ValueBorc = maktuKonkordatoHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }
                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 640)
                            {
                                ParaVeDovizId menkulTeslimHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Menkul Teslim Harcı",
                                    ValueBorc = menkulTeslimHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 874)
                            {
                                ParaVeDovizId depoHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Depo Harcı",
                                    ValueBorc = depoHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 656)
                            {
                                ParaVeDovizId kefaletHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Kefalet Harcı",
                                    ValueBorc = kefaletHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }
                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 592)
                            {
                                ParaVeDovizId suretHarci = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Suret Harcı",
                                    ValueBorc = suretHarci,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }
                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 874)
                            {
                                ParaVeDovizId maktuIcraHarc = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Maktu Icra Harç",
                                    ValueBorc = maktuIcraHarc,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }

                            else if (masrafDetay.HAREKET_ALT_KATEGORI_ID == 875)
                            {
                                ParaVeDovizId maktuIcraVekalet = new ParaVeDovizId(masrafDetay.TOPLAM_TUTAR, masrafDetay.TOPLAM_TUTAR_DOVIZ_ID);
                                NodeEkle(new HesapNode
                                {
                                    Name = "Maktu İcra Vekalet",
                                    ValueBorc = maktuIcraVekalet,
                                    Node = HesapNode.UniqNodeID,
                                    NodePreview = masrafDetay.ACIKLAMA,
                                    ValueTarih = masrafDetay.TARIH.ToShortDateString(),
                                    ParentNode = HesapNode.HesapEnum.DIGER_HARCLAR,
                                    imageIndex = 5
                                });
                            }
                        }
                    }
                }

                //NodeEkle(new HesapNode
                //{
                //    Name = "Toplam KDV",
                //    ValueBorc = toplamTakipKDV,
                //    Node = HesapNode.UniqNodeID,
                //    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI,
                //    imageIndex = 5

                //});
                //NodeEkle(new HesapNode
                //{
                //    Name = "Toplam Stopaj",
                //    ValueBorc = toplamTakipStopaj,
                //    Node = HesapNode.UniqNodeID,
                //    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI,
                //    imageIndex = 5

                //});
                //NodeEkle(new HesapNode
                //{
                //    Name = "Toplam KDV",
                //    ValueBorc = toplamSozlesmeKDV,
                //    Node = HesapNode.UniqNodeID,
                //    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI,
                //    imageIndex = 5

                //});
                //NodeEkle(new HesapNode
                //{
                //    Name = "Toplam Stopaj",
                //    ValueBorc = toplamSozlesmeStopaj,
                //    Node = HesapNode.UniqNodeID,
                //    ParentNode = HesapNode.HesapEnum.TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI,
                //    imageIndex = 5

                //});
            }

            #endregion Masraf Tablosundan Alınan Node'lar

            #region Ödeme Tablosunda Alınan Node'lar

            if (foy.AV001_TI_BIL_BORCLU_ODEMECollection.Count < 1)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));

            if (foy.AV001_TI_BIL_BORCLU_ODEMECollection != null)
            {
                foreach (var odeme in foy.AV001_TI_BIL_BORCLU_ODEMECollection)
                {
                    if (odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.ALACAKLIYA || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.TAKASTAN)
                    {
                        ParaVeDovizId muvekkilTahsilati = new ParaVeDovizId(odeme.ODEME_MIKTAR,
                                                                            odeme.ODEME_MIKTAR_DOVIZ_ID);
                        AV001_TDI_BIL_CARI borcluAdinaOdeyenCari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)odeme.BORCLU_ADINA_ODENEN_CARI_ID);
                        TDI_KOD_ODEME_TIP odemeTip = DataRepository.TDI_KOD_ODEME_TIPProvider.GetByID((int)odeme.ODEME_TIP_ID);
                        NodeEkle(new HesapNode
                                     {
                                         Name = "",
                                         ValueBorc = muvekkilTahsilati,
                                         ValueTarih = odeme.ODEME_TARIHI.ToShortDateString(),
                                         NodePreview = borcluAdinaOdeyenCari.AD + " tarafından yapılan " + odemeTip.ODEME_TIP + " ödemesi. " + odeme.ACIKLAMA,
                                         Node = HesapNode.UniqNodeID,
                                         ParentNode = HesapNode.HesapEnum.MUVEKKIL_TAHSILATI,
                                         imageIndex = 5
                                     });
                    }
                    else if (odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.AVUKATA || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.BANKA_HESABINA || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.İCRA_DAİRESİNE || odeme.ODEME_YER_ID == (int)AvukatProLib.Extras.OdemeYeri.SATIŞTAN)
                    {
                        ParaVeDovizId avukatTahsilati = new ParaVeDovizId(odeme.ODEME_MIKTAR,
                                                                          odeme.ODEME_MIKTAR_DOVIZ_ID);
                        AV001_TDI_BIL_CARI borcluAdinaOdeyenCari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)odeme.BORCLU_ADINA_ODENEN_CARI_ID);
                        TDI_KOD_ODEME_TIP odemeTip = DataRepository.TDI_KOD_ODEME_TIPProvider.GetByID((int)odeme.ODEME_TIP_ID);
                        NodeEkle(new HesapNode
                                     {
                                         Name = "",
                                         ValueAlacak = avukatTahsilati,
                                         ValueTarih = odeme.ODEME_TARIHI.ToShortDateString(),
                                         NodePreview = borcluAdinaOdeyenCari.AD + " tarafından yapılan " + odemeTip.ODEME_TIP + " ödemesi. " + odeme.ACIKLAMA,
                                         Node = HesapNode.UniqNodeID,
                                         ParentNode = HesapNode.HesapEnum.AVUKAT_TAHSILATI,
                                         imageIndex = 5
                                     });
                    }
                }
            }

            #endregion Ödeme Tablosunda Alınan Node'lar

            #region Node'ların Üst Toplamlarının Yapılması

            NodeUstToplam(HesapNode.HesapEnum.ALINAN_AVANS);
            NodeUstToplam(HesapNode.HesapEnum.IADE_AVANS);
            NodeUstToplam(HesapNode.HesapEnum.TEMINAT_AVANSI);
            NodeUstToplam(HesapNode.HesapEnum.TEMINAT_AVANS_IADESI);
            NodeUstToplam(HesapNode.HesapEnum.TAHLIYE_HARCI);
            NodeUstToplam(HesapNode.HesapEnum.MUVEKKIL_TAHSILATI);
            NodeUstToplam(HesapNode.HesapEnum.AVUKAT_TAHSILATI);
            NodeUstToplam(HesapNode.HesapEnum.ODEME_EMRI_GIDERI);

            if (vekaletSozlesme.ODEMELERDEN_ORANSAL_KESILSIN == true)
            {
                NodeUstToplam(HesapNode.HesapEnum.TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI);
                NodeUstToplam(HesapNode.HesapEnum.TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI);
                NodeUstToplam(HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI);
            }

            if (!vekaletSozlesme.GIDERLER_AVUKATA_AIT)
                NodeUstToplam(HesapNode.HesapEnum.RESMI_OLMAYAN_MASRAF_TOPLAMI);

            if (vekaletSozlesme.DONMEYEN_GIDERLER)
                NodeUstToplam(HesapNode.HesapEnum.DONMEYEN_GIDER_TOPLAMI);

            if (vekaletSozlesme.CEZAEVI_HARCI)
                NodeUstToplam(HesapNode.HesapEnum.CEZAEVI_HARCI);

            if (vekaletSozlesme.FERAGAT_HARCI)
                NodeUstToplam(HesapNode.HesapEnum.FERAGAT_HARCI);
            NodeUstToplam(HesapNode.HesapEnum.IFLAS_HARCI);
            NodeUstToplam(HesapNode.HesapEnum.DIGER_HARCLAR);
            NodeUstToplam(HesapNode.HesapEnum.HARC_TOPLAMI);
            NodeUstToplam(HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI);
            NodeUstToplam(HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETLERI);
            NodeUstToplam(HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI);
            NodeUstToplam(HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI);

            #endregion Node'ların Üst Toplamlarının Yapılması

            NodeToplam(sozlesme.OdemelerdenOransalKesilsin);
        }

        #endregion Bind TreeList

        #region Müvekkil Hesabı Tablosuna Kayıt

        public AV001_TI_BIL_MUVEKKIL_HESAP GetMuvekkilHesap(AV001_TI_BIL_FOY foy)
        {
            var sonuc = DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.GetByICRA_FOY_ID(foy.ID).FirstOrDefault();

            AV001_TI_BIL_MUVEKKIL_HESAP mHesap = null;

            if (sonuc == null)
            {
                mHesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
                mHesap.ICRA_FOY_ID = foy.ID;
            }
            else
            {
                mHesap = sonuc;

                //if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
                //    mHesap = foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0];
            }

            if (!mHesap.ICRA_TAKIP_SOZLESME_ID.HasValue)
                mHesap.ICRA_TAKIP_SOZLESME_ID = foy.VEKALET_SOZLESME_ID;

            foreach (var item in this.NodeListesi)
            {
                if (item.ValueAlacak != null || item.ValueBorc != null)
                    switch (item.Node)
                    {
                        //case HesapNode.HesapEnum.ROOT:
                        //    break;
                        case HesapNode.HesapEnum.ALINAN_AVANS:
                            mHesap.ALINAN_AVANS = item.ValueAlacak.Para;
                            mHesap.ALINAN_AVANS_DOVIZ_ID = item.ValueAlacak.DovizId;
                            break;

                        case HesapNode.HesapEnum.IADE_AVANS:
                            mHesap.IADE_AVANS = item.ValueBorc.Para;
                            mHesap.IADE_AVANS_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.MUVEKKIL_TAHSILATI:
                            mHesap.MUVEKKIL_TAHSILATI = item.ValueBorc.Para;
                            mHesap.MUVEKKIL_TAHSILATI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.AVUKAT_TAHSILATI:
                            mHesap.AVUKAT_TAHSILATI = item.ValueAlacak.Para;
                            mHesap.AVUKAT_TAHSILATI_DOVIZ_ID = item.ValueAlacak.DovizId;
                            break;

                        case HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI:
                            mHesap.RESMI_MASRAF_TOPLAMI = item.ValueBorc.Para;
                            mHesap.RESMI_MASRAF_TOPLAMI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.ODEME_EMRI_GIDERI:
                            mHesap.ODEME_EMRI_GIDERI = item.ValueBorc.Para;
                            mHesap.ODEME_EMRI_GIDERI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.DIGER_GIDERLER:
                            mHesap.DIGER_GIDERLER = item.ValueBorc.Para;
                            mHesap.DIGER_GIDERLER_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.RESMI_OLMAYAN_MASRAF_TOPLAMI:
                            mHesap.DIGER_MASRAF_TOPLAMI = item.ValueBorc.Para;
                            mHesap.DIGER_MASRAF_TOPLAMI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.HARC_TOPLAMI:
                            mHesap.HARC_TOPLAMI = item.ValueBorc.Para;
                            mHesap.HARC_TOPLAMI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.ODENEN_TAHSIL_HARCI:
                            mHesap.ODENEN_TAHSIL_HARCI = item.ValueBorc.Para;
                            mHesap.ODENEN_TAHSIL_HARCI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.KALAN_TAHSIL_HARCI:
                            mHesap.KALAN_TAHSIL_HARCI = item.ValueBorc.Para;
                            mHesap.KALAN_TAHSIL_HARCI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.CEZAEVI_HARCI:
                            mHesap.CEZAEVI_HARCI = item.ValueBorc.Para;
                            mHesap.CEZAEVI_HARCI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.FERAGAT_HARCI:
                            mHesap.FERAGAT_HARCI = item.ValueBorc.Para;
                            mHesap.FERAGAT_HARCI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.DIGER_HARCLAR:
                            mHesap.DIGER_HARCLAR = item.ValueBorc.Para;
                            mHesap.DIGER_HARCLAR_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.DONMEYEN_GIDER_TOPLAMI:
                            mHesap.DONMEYEN_GIDER_TOPLAMI = item.ValueBorc.Para;
                            mHesap.DONMEYEN_GIDER_TOPLAMI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.SOZLESME_UCRETI:
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI:
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI = item.ValueBorc.Para;
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI:
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI = item.ValueBorc.Para;
                            mHesap.TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTAR_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.TAKIP_VEKALET_UCRETI:
                            mHesap.TAKIP_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.TAKIP_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI_KDV:
                            mHesap.TAKIP_VEKALET_UCRETLERI_KDV = item.ValueBorc.Para;
                            mHesap.TAKIP_VEKALET_UCRETLERI_KDV_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.KARSI_VEKALET_UCRETLERI_STOPAJ:
                            mHesap.TAKIP_VEKALET_UCRETLERI_STOPAJ = item.ValueBorc.Para;
                            mHesap.TAKIP_VEKALET_UCRETLERI_STOPAJ_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.TAHLIYE_VEKALET_UCRETI:
                            mHesap.TAHLIYE_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.TAHLIYE_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.TD_VEKALET_UCRETI:
                            mHesap.TD_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.TD_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.DAVA_VEKALET_UCRETI:
                            mHesap.DAVA_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.DAVA_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.DEPO_VEKALET_UCRETI:
                            mHesap.DEPO_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.DEPO_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.IHTIYATI_HACIZ_VEKALET_UCRETI:
                            mHesap.IHTIYATI_HACIZ_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.IHTIYATI_HACIZ_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.IHTIYATI_TEDBIR_VEKALET_UCRETI:
                            mHesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = item.ValueBorc.Para;
                            mHesap.IHTIYATI_TEDBIR_VEKALET_UCRETI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.MUVEKKILE_ODEME_TOPLAMI:
                            mHesap.MUVEKKILE_ODEME_TOPLAMI = item.ValueBorc.Para;
                            mHesap.MUVEKKILE_ODEME_TOPLAMI_DOVIZ_ID = item.ValueBorc.DovizId;
                            break;

                        case HesapNode.HesapEnum.INDIRIM_MIKTARI:
                            mHesap.INDIRIM_MIKTARI = item.ValueAlacak.Para;
                            mHesap.INDIRIM_MIKTARI_DOVIZ_ID = item.ValueAlacak.DovizId;
                            break;

                        case HesapNode.HesapEnum.TOPLAM:
                            break;

                        case HesapNode.HesapEnum.KALAN_TUTAR:
                            if (item.ValueBorc != null)
                            {
                                mHesap.KALAN_TUTAR = item.ValueBorc.Para;
                                mHesap.KALAN_TUTAR_DOVIZ_ID = item.ValueBorc.DovizId;
                            }
                            if (item.ValueAlacak != null)
                            {
                                mHesap.KALAN_TUTAR = item.ValueAlacak.Para;
                                mHesap.KALAN_TUTAR_DOVIZ_ID = item.ValueAlacak.DovizId;
                            }
                            break;
                        default:
                            break;
                    }
            }
            mHesap.SON_HESAP_TARIHI = DateTime.Now.Date;
            return mHesap;
        }

        #endregion Müvekkil Hesabı Tablosuna Kayıt

        public List<HesapNode> NodeListesi { get; set; }

        public List<HesapNode> GetNodeList()
        {
            return NodeListesi;
        }

        public void NodeEkle(HesapNode node)
        {
            NodeListesi.Add(node);
        }

        public void NodeToplam(bool? isOransal)
        {
            var paralar =
               NodeListesi.Where(
                     vi =>
                     vi.Node == HesapNode.HesapEnum.ALINAN_AVANS ||
                     vi.Node == HesapNode.HesapEnum.IADE_AVANS ||
                     vi.Node == HesapNode.HesapEnum.TEMINAT_AVANSI ||
                     vi.Node == HesapNode.HesapEnum.TEMINAT_AVANS_IADESI ||
                     vi.Node == HesapNode.HesapEnum.MUVEKKIL_TAHSILATI ||
                     vi.Node == HesapNode.HesapEnum.AVUKAT_TAHSILATI ||
                     vi.Node == HesapNode.HesapEnum.RESMI_MASRAF_TOPLAMI ||
                     vi.Node == HesapNode.HesapEnum.DONMEYEN_GIDER_TOPLAMI ||
                     vi.Node == HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI ||
                     vi.Node == HesapNode.HesapEnum.MUVEKKILE_ODEME_TOPLAMI ||
                     vi.Node == HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI).Select(
                         v => new { Alacak = v.ValueAlacak, Borc = v.ValueBorc, Tip = v.Node }).ToList();

            if (isOransal == true)
                paralar.Remove(paralar.Find(p => p.Tip == HesapNode.HesapEnum.VEKALET_UCRETLERI_TOPLAMI));
            else
                paralar.Remove(paralar.Find(p => p.Tip == HesapNode.HesapEnum.TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI));

            ParaVeDovizId toplamAlacak = ParaVeDovizId.Topla(paralar.Select(vi => vi.Alacak).ToList());
            ParaVeDovizId toplamBorc = ParaVeDovizId.Topla(paralar.Select(vi => vi.Borc).ToList());

            var toplamNodu = NodeListesi.Where(vi => vi.Node == HesapNode.HesapEnum.TOPLAM).First();

            var indirim =
                NodeListesi.Where(vi => vi.Node == HesapNode.HesapEnum.INDIRIM_MIKTARI).Select(vi => vi.ValueAlacak).First
                    ();

            toplamNodu.ValueBorc = toplamBorc;
            toplamNodu.ValueAlacak = toplamAlacak;

            var kalan = ParaVeDovizId.Cikart(toplamAlacak, toplamBorc);
            kalan = ParaVeDovizId.Topla(kalan, indirim);

            var kalanNodu = NodeListesi.Where(vi => vi.Node == HesapNode.HesapEnum.KALAN_TUTAR).First();

            if (kalan.Para > 0)
                kalanNodu.ValueAlacak = kalan;
            else
                kalanNodu.ValueBorc = kalan;
        }

        public void NodeUstToplam(HesapNode.HesapEnum hEnum, TreeMuvekkilHesabi dataSource)
        {
            {
                var paralar =
                    dataSource.NodeListesi.Where(vi => vi.ParentNode == hEnum).Select(v => v.ValueBorc).ToList();
                var toplam = ParaVeDovizId.Topla(paralar);

                dataSource.NodeListesi.Where(vi => vi.Node == hEnum).First().ValueBorc = toplam;
            }
            {
                var paralar =
                    dataSource.NodeListesi.Where(vi => vi.ParentNode == hEnum).Select(v => v.ValueAlacak).ToList();
                var toplam = ParaVeDovizId.Topla(paralar);

                dataSource.NodeListesi.Where(vi => vi.Node == hEnum).First().ValueAlacak = toplam;
            }
        }

        public void NodeUstToplam(HesapNode.HesapEnum hEnum)
        {
            {
                var paralar = NodeListesi.Where(vi => vi.ParentNode == hEnum).Select(v => v.ValueBorc).ToList();
                var toplam = ParaVeDovizId.Topla(paralar);

                NodeListesi.Where(vi => vi.Node == hEnum).First().ValueBorc = toplam;
            }
            {
                var paralar = NodeListesi.Where(vi => vi.ParentNode == hEnum).Select(v => v.ValueAlacak).ToList();
                var toplam = ParaVeDovizId.Topla(paralar);

                NodeListesi.Where(vi => vi.Node == hEnum).First().ValueAlacak = toplam;
            }
        }

        public class HesapNode
        {
            private static HesapNode.HesapEnum _UniqNodeID = (HesapNode.HesapEnum)500;

            public enum HesapEnum
            {
                ROOT = 0,
                ALINAN_AVANS,
                IADE_AVANS,
                MUVEKKIL_TAHSILATI,
                AVUKAT_TAHSILATI,
                RESMI_MASRAF_TOPLAMI,
                ODEME_EMRI_GIDERI,
                VEKALET_HARCI,
                VEKALET_PULU,
                BASVURMA_HARCI,
                IFLAS_BASVURMA_HARCI,
                ILK_TEBLİGAT_GIDERI,
                PEŞIN_HARC,
                DIGER_GIDERLER,
                RESMI_OLMAYAN_MASRAF_TOPLAMI,
                HARC_TOPLAMI,
                ODENEN_TAHSIL_HARCI,
                KALAN_TAHSIL_HARCI,
                CEZAEVI_HARCI,
                FERAGAT_HARCI,
                TAHLIYE_HARCI,
                DIGER_HARCLAR,
                DAMGAPULU,
                IFLAS_HARCI,
                MAKTU_IFLASIN_ACILMA_HARCI,
                YERINE_GETIRME_HARCI,
                MAKTI_CEZAEVI_HARCI,
                MAKTU_KONKORDATO_HARCI,
                MENKUL_TESLIM_HARCI,
                KEFALET_HARCI,
                SURET_HARCI,
                MAKTU_ICRA_HARC,
                DEPO_HARCI,
                MAKTU_ICRA_VEKALET,
                DONMEYEN_GIDER_TOPLAMI,
                VEKALET_UCRETLERI_TOPLAMI,
                TOPLAM_SOZLESME_VEKALET_UCRETLERI,
                SOZLESME_UCRETI,
                TOPLAM_SOZLESME_VEKALET_UCRETI_KDV_TUTARI,
                TOPLAM_SOZLESME_VEKALET_UCRETI_STOPAJ_TUTARI,
                KARSI_VEKALET_UCRETLERI,
                TAKIP_VEKALET_UCRETI,
                TAHLIYE_VEKALET_UCRETI,
                TD_VEKALET_UCRETI,
                DAVA_VEKALET_UCRETI,
                DEPO_VEKALET_UCRETI,
                IHTIYATI_HACIZ_VEKALET_UCRETI,
                IHTIYATI_TEDBIR_VEKALET_UCRETI,
                KARSI_VEKALET_UCRETLERI_KDV,
                KARSI_VEKALET_UCRETLERI_STOPAJ,
                MUVEKKILE_ODEME_TOPLAMI,
                INDIRIM_MIKTARI,
                TOPLAM,
                KALAN_TUTAR,
                TAHAKKUK_EDEN_TOPLAM_VEKALET_UCRETI,
                TAHAKKUK_EDEN_SOZLESME_VEKALET_UCRETI,
                TEMINAT_AVANSI,
                TEMINAT_AVANS_IADESI,
                TAHAKKUK_EDEN_TAKIP_VEKALET_UCRETI,
            }

            public static HesapNode.HesapEnum UniqNodeID
            {
                get
                {
                    int ID = (int)_UniqNodeID;
                    _UniqNodeID = (HesapNode.HesapEnum)(++ID);
                    return _UniqNodeID;
                }
            }

            public int imageIndex { get; set; }

            public string Name { get; set; }

            public HesapEnum Node { get; set; }

            public string NodePreview { get; set; }

            public HesapEnum ParentNode { get; set; }

            public ParaVeDovizId ValueAlacak { get; set; }

            public ParaVeDovizId ValueBorc { get; set; }

            public string ValueTarih { get; set; }
        }
    }

    #endregion <MB-20100302> AĞAÇ
}