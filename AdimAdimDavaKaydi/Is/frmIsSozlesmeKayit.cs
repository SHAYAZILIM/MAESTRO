using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Is.Util;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Is
{
    public partial class frmIsSozlesmeKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private IsSozlesmeDetayGetir dGetir = new IsSozlesmeDetayGetir();

        private TList<AV001_TDI_BIL_IS_SOZLESME_DETAY> dList;

        private int? Katid;

        private AV001_TDI_BIL_IS_SOZLESME myDataSource;

        public frmIsSozlesmeKayit()
        {
            InitializeComponent();
            InitializeEvents();
            exIsSozlesmeDetay.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            exIsSozlesmeDetay.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
        }

        public AV001_TDI_BIL_IS_SOZLESME MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myDataSource = value;
                    if (myDataSource.ID == 0)
                        SetIs();

                    InitsData();
                    bndIsSozlesme.DataSource = myDataSource;
                    BindData();
                    if (myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection.Count == 0)
                    {
                        dList = dGetir.DetayGetir();
                        myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection.AddRange(dList);
                    }
                    else
                        dList = myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection;
                    exIsSozlesmeDetay.DataSource = dList;
                    if (myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection.Count == 0)
                    {
                        exgrdDetaySorumlu.DataSource = dGetir.DetaySorumluGetir();

                        // GetBySorumlu(MyDataSource.ID, myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection[0].IS_MUHASEBE_ALT_KATEGORI_ID.Value);
                    }
                    else
                        exgrdDetaySorumlu.DataSource = myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection;
                }
            }
        }

        private void BindData()
        {
            DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.DeepLoad(myDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY>), typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>));
        }

        private void bus_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIsSozlesmeDetaySorumlu sorumlu = new frmIsSozlesmeDetaySorumlu();
            sorumlu.kategoriID = Katid.Value;
            sorumlu.MyIsSozlesme = MyDataSource;
            sorumlu.Show();
        }

        private void exgrdDetaySorumlu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> DetayS =
                    new TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>();
                if (gridView1.GetFocusedRow() != null)
                {
                    AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU detay =
                        (gridView2.GetFocusedRow()) as AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU;
                    if (detay != null)
                        DetayS.Add(detay);
                    frmIsSozlesmeDetaySorumlu sorumlu = new frmIsSozlesmeDetaySorumlu();
                    sorumlu.kategoriID = detay.IS_MUHASEBE_ALT_KATEGORI_ID.Value;
                    sorumlu.MyDataSource = DetayS;
                    sorumlu.MyIsSozlesme = MyDataSource;

                    //sorumlu.MdiParent = null;
                    sorumlu.StartPosition = FormStartPosition.WindowsDefaultLocation;

                    sorumlu.Show();
                }
                else
                {
                    XtraMessageBox.Show("Sorumlu Eklemek İçin Lütfen Öce Bir Kategori Seçiniz");
                }
            }
        }

        private void frmIsSozlesmeKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_s> detList= dGetir.DetayEkle(item.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection);
                MyDataSource.FAIZ_BASLANGIC_TARIHI = DateTime.Now;
                TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU> sor =
                    exgrdDetaySorumlu.DataSource as TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>;
                foreach (var item2 in MyDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection)
                {
                    if (sor[0].SORUMLU_CARI_ID == item2.SORUMLU_CARI_ID)
                    {
                        item2.IS_MIKTAR = sor[0].IS_MIKTAR;
                        item2.DOVIZ_ID = sor[0].DOVIZ_ID;
                    }
                }

                TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                trans.BeginTransaction();
                DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.DeepSave(trans, MyDataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY>), typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>));
                XtraMessageBox.Show("Kayıt Başarılı");
                trans.Commit();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIsSozlesmeKayit_Button_Kaydet_Click;
        }

        private void InitsData()
        {
            BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            BelgeUtil.Inits.SozlesmeKategorisiGetir(lueKategori.Properties);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMuhaseAltKategori);
            BelgeUtil.Inits.SorumluAvukatGetir(rLueSorumlu);
            BelgeUtil.Inits.SorumluAvukatGetir(lueSorumlu);
            BelgeUtil.Inits.SubeKodGetir(lueBuro.Properties);
            BelgeUtil.Inits.SureTipTipGetir(rLueSüreBirimTip);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
        }

        private void KatEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            BelgeUtil.Inits.SozlesmeKategorisiGetirRefresh();
            BelgeUtil.Inits.SozlesmeKategorisiGetir(lueKategori.Properties);
        }

        private void lueKategori_EditValueChanged(object sender, EventArgs e)
        {
            //if (lueKategori.EditValue != null && !string.IsNullOrEmpty(lueKategori.EditValue.ToString()))
            //{
            //    TList<AV001_TDI_BIL_IS_SOZLESME> sIsS =
            //        DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.GetBySOZLESME_KATEGORI_ID(
            //            (int)lueKategori.EditValue);
            //    if (sIsS.Count > 0)
            //    {
            //        DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.DeepLoad(sIsS, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY>), typeof(TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>));
            //        MyDataSource = sIsS[0];
            //    }
            //    else
            //        MyDataSource = new AV001_TDI_BIL_IS_SOZLESME();
            //}
            //else
            //    MyDataSource = new AV001_TDI_BIL_IS_SOZLESME();
        }

        private void lueKategori_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "kategoriEkle")
            {
                frmIsSozlesmeKategoriEkle KatEkle = new frmIsSozlesmeKategoriEkle();
                KatEkle.KategoriName = lueKategori.Text;
                KatEkle.MyKategori = new TDI_KOD_SOZLESME_KATEGORILERI();
                KatEkle.Show();
                KatEkle.FormClosing += KatEkle_FormClosing;
            }
        }

        private void lueKategori_Properties_ProcessNewValue(object sender,
                                                            DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (!string.IsNullOrEmpty(lueKategori.Text))
            {
                frmIsSozlesmeKategoriEkle KatEkle = new frmIsSozlesmeKategoriEkle();
                KatEkle.KategoriName = lueKategori.Text;
                KatEkle.MyKategori = new TDI_KOD_SOZLESME_KATEGORILERI();
                KatEkle.Show();
                KatEkle.FormClosing += KatEkle_FormClosing;
            }
        }

        private void lueSorumlu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSorumlu.EditValue != null)
            {
                foreach (
                    AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU item in
                        (exgrdDetaySorumlu.DataSource as TList<AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLU>))
                {
                    item.SORUMLU_CARI_ID = (int)lueSorumlu.EditValue;
                }
            }
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "IS_MUHASEBE_ALT_KATEGORI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Sorumlu Ekle");
                AV001_TDI_BIL_IS_SOZLESME_DETAY secim = e.Rows as AV001_TDI_BIL_IS_SOZLESME_DETAY;

                Katid = secim.IS_MUHASEBE_ALT_KATEGORI_ID;
                bus.ItemClick += bus_ItemClick;
            }
        }

        private void SetIs()
        {
            myDataSource.SOZLESME_TARIHI = DateTime.Now;
            myDataSource.ADMIN_KAYIT_MI = true;
            myDataSource.KAYIT_TARIHI = DateTime.Now;
            myDataSource.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            myDataSource.KONTROL_NE_ZAMAN = DateTime.Now;
            myDataSource.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            myDataSource.FAIZ_BASLANGIC_TARIHI = DateTime.Now;
            myDataSource.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;
            myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection = dGetir.DetaySorumluGetir();
            exgrdDetaySorumlu.DataSource = myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAY_SORUMLUCollection;
            myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection = dGetir.DetayGetir();
            exIsSozlesmeDetay.DataSource = myDataSource.AV001_TDI_BIL_IS_SOZLESME_DETAYCollection;
        }
    }
}