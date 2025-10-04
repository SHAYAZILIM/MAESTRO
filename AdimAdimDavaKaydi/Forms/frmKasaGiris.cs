using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKasaGiris : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmKasaGiris()
        {
            InitializeComponent();

            this.EventlerKullanilacakMi = true;
            this.Load += frmKasaGiris_Load;
            this.Button_Kaydet_Click += frmKasaGiris_Button_Kaydet_Click;
        }

        public bool YeniKayit = true;

        private void frmKasaGiris_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (!YeniKayit)
                EklenenlerListesi.RemoveAt(0);

            Ekle();
            AvukatProLib2.Data.TransactionManager trans = new AvukatProLib2.Data.TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            trans.BeginTransaction();

            try
            {
                foreach (var item in EklenenlerListesi)
                {
                    if (item.BORC_ALACAK_ID == (int)AvukatProLib.Extras.BorcAlacak.Alacak)
                    {
                        if (item.BIRIM_FIYAT > 0)
                            item.BIRIM_FIYAT = -1 * item.BIRIM_FIYAT;
                    }
                    else
                    {
                        if (item.BIRIM_FIYAT < 0)
                            item.BIRIM_FIYAT = -1 * item.BIRIM_FIYAT;
                    }
                    item.GENEL_TOPLAM = item.ADET * item.BIRIM_FIYAT;
                }

                //AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KASAProvider.Update(trans, EklenenlerListesi);

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KASAProvider.DeepSave(trans, EklenenlerListesi, AvukatProLib2.Data.DeepSaveType.IncludeChildren, typeof(AvukatProLib2.Entities.TList<AvukatProLib2.Entities.NN_BELGE_KASA>));

                trans.Commit();
                System.Windows.Forms.MessageBox.Show("Kayýt Ýþlemi Gerçekleþti" + Environment.NewLine + "Pencere Kapatýlacak");
                this.Close();
            }
            catch
            {
                if (trans.IsOpen)
                    trans.Rollback();
            }
        }

        #region Events

        public AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDI_BIL_KASA> EklenenlerListesi = new AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDI_BIL_KASA>();

        private void BinDataToForm(AvukatProLib2.Entities.AV001_TDI_BIL_KASA kasa)
        {
            if (kasa.SEGMENT_ID.HasValue)
                lueSegment.EditValue = kasa.SEGMENT_ID;
            if (kasa.HAREKET_CARI_ID > 0)
                lueCari.EditValue = kasa.HAREKET_CARI_ID;
            if (kasa.TARIH.HasValue)
                dateTarih.EditValue = kasa.TARIH;
            if (kasa.ODEME_TIP_ID.HasValue)
                lueOdemeTipi.EditValue = kasa.ODEME_TIP_ID;
            if (kasa.KIYMETLI_EVRAK_ID.HasValue)
                lueCekSenet.EditValue = kasa.KIYMETLI_EVRAK_ID;
            spAdet.Value = kasa.ADET;
            spinBirimFiyat.Value = kasa.BIRIM_FIYAT;
            spToplam.Value = kasa.GENEL_TOPLAM;
            if (kasa.BIRIM_FIYAT_DOVIZ_ID.HasValue)
                lueToplamDoviz.EditValue = kasa.BIRIM_FIYAT_DOVIZ_ID;
            if (kasa.HAREKET_ANA_KATEGORI_ID.HasValue)
            {
                lueAnaKategori.EditValue = kasa.HAREKET_ANA_KATEGORI_ID;
                if (kasa.HAREKET_ALT_KATEGORI_ID.HasValue)
                    lueAltKategori.EditValue = kasa.HAREKET_ALT_KATEGORI_ID;
            }
            if (kasa.BURO_HESAP_SAHIBI_CARI_BANKA_ID.HasValue)
                lueKasaHesap.EditValue = kasa.BURO_HESAP_SAHIBI_CARI_BANKA_ID;
            if (kasa.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID.HasValue)
                lueMuhatapHesap.EditValue = kasa.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID;
            txtEftReferansNo.Text = kasa.EFT_REFERANS_NO;
            txtBankaDekontNo.Text = kasa.BANKA_DEKONT_NO;
            if (kasa.NN_BELGE_KASACollection.Count > 0)
            {
                foreach (var belge in kasa.NN_BELGE_KASACollection)
                {
                    for (int rowHandle = 0; rowHandle < lueBelge.Properties.View.RowCount; rowHandle++)
                    {
                        if ((int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id") == belge.BELGE_ID)
                            lueBelge.Properties.View.SetRowCellValue(rowHandle, "IsSelected", true);
                    }
                }
            }

            txtAciklama.Text = kasa.ACIKLAMA;
        }

        private void Ekle()
        {
            AvukatProLib2.Entities.AV001_TDI_BIL_KASA kasa = new AvukatProLib2.Entities.AV001_TDI_BIL_KASA();

            if (lueSegment.EditValue != null)
                kasa.SEGMENT_ID = (int?)lueSegment.EditValue;
            if (lueCari.EditValue != null)
                kasa.HAREKET_CARI_ID = (int)lueCari.EditValue;
            if (dateTarih.EditValue != null)
                kasa.TARIH = (DateTime?)dateTarih.EditValue;
            kasa.REFERANS_NO = txtReferans.Text;
            kasa.BELGE_NO = txtBelgeNo.Text;
            if (lueOdemeTipi.EditValue != null)
                kasa.ODEME_TIP_ID = (int?)lueOdemeTipi.EditValue;
            if (lueCekSenet.EditValue != null)
                kasa.KIYMETLI_EVRAK_ID = (int?)lueCekSenet.EditValue;
            kasa.ADET = (int)spAdet.Value;
            kasa.BIRIM_FIYAT = spinBirimFiyat.Value;
            kasa.GENEL_TOPLAM = spToplam.Value;
            if (lueToplamDoviz.EditValue != null)
                kasa.BIRIM_FIYAT_DOVIZ_ID = (int)lueToplamDoviz.EditValue;
            if (lueAnaKategori.EditValue != null)
            {
                kasa.HAREKET_ANA_KATEGORI_ID = (int)lueAnaKategori.EditValue;
                if (lueAltKategori.EditValue != null)
                    kasa.HAREKET_ALT_KATEGORI_ID = (int)lueAltKategori.EditValue;
            }
            if (lueKasaHesap.EditValue != null)
                kasa.BURO_HESAP_SAHIBI_CARI_BANKA_ID = (int?)lueMuhatapHesap.EditValue;
            if (lueMuhatapHesap.EditValue != null)
                kasa.MUHATAP_HESAP_SAHIBI_CARI_BANKA_ID = (int?)lueMuhatapHesap.EditValue;
            kasa.EFT_REFERANS_NO = txtEftReferansNo.Text;
            kasa.BANKA_DEKONT_NO = txtBankaDekontNo.Text;

            for (int i = 0; i < lueBelge.Properties.View.RowCount; i++)
            {
                if ((bool)lueBelge.Properties.View.GetRowCellValue(i, "IsSelected") == true)
                    kasa.NN_BELGE_KASACollection.Add(new AvukatProLib2.Entities.NN_BELGE_KASA { BELGE_ID = (int)lueBelge.Properties.View.GetRowCellValue(i, "Id") });
            }

            kasa.ACIKLAMA = txtAciklama.Text;
            kasa.BORC_ALACAK = lueBorcAlacak.Text;
            kasa.BORC_ALACAK_ID = (int?)lueBorcAlacak.EditValue;
            kasa.ODEME_TIP_ID = (int?)lueOdemeTipi.EditValue;

            EklenenlerListesi.Add(kasa);
        }

        private void frmKasaGiris_Load(object sender, EventArgs e)
        {
            InitsData();

            if (EklenenlerListesi.Count == 1)
                BinDataToForm(EklenenlerListesi[0]);
        }

        #endregion Events

        private void InitsData()
        {
            BelgeUtil.Inits.DovizTipGetir(lueToplamDoviz);
            BelgeUtil.Inits.perCariGetir(lueCari);
            AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueAnaKategori);
            BelgeUtil.Inits.OdemeTipiGetir(lueOdemeTipi);
            BelgeUtil.Inits.BorcAlacakGetir(lueBorcAlacak);

            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);

            AvukatPro.Services.Implementations.DevExpressService.KasaHesapBilgileriDoldur(lueKasaHesap);
            AvukatPro.Services.Implementations.DevExpressService.MuhatapHesapBilgilerirDoldur(lueMuhatapHesap);
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);

            lueOdemeTipi.EditValue = (int)AvukatProLib.Extras.OdemeTip.NAKÝT;
            dateTarih.EditValue = DateTime.Today;
            spAdet.EditValue = 1;
            lueToplamDoviz.EditValue = 1;

            if (AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value) != null)
                lueCari.EditValue = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value);
        }

        private void lueAltKategori_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                if (lueAnaKategori.EditValue == null || lueAnaKategori.EditValue == "")
                    return;
                int anaKategoriID = (int)lueAnaKategori.EditValue;

                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.AltKategori, anaKategoriID);
                frmalt.ShowDialog();

                if (anaKategoriID != null)
                    AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueAltKategori, (int)lueAnaKategori.EditValue);
            }
        }

        private void lueAnaKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnaKategori.EditValue == null)
                return;
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueAltKategori, (int)lueAnaKategori.EditValue);

            for (int i = lueAltKategori.Properties.Buttons.Count - 1; i > 1; i--)
            {
                lueAltKategori.Properties.Buttons.RemoveAt(i);
            }
        }

        private void lueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            }
        }

        private void lueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();

                frm.tmpCariAd = lueCari.Text;
                frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Avukat);
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        BelgeUtil.Inits.perCariGetir(lueCari);
                    }
                };
            }
        }

        private void lueOdemeTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOdemeTipi.Text == EvrakTurleri.ÇEK.ToString())
            {
                lueCekSenet.Enabled = true;
                lciCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueCekSenet);
            }

            else if (lueOdemeTipi.Text == EvrakTurleri.BONO.ToString())
            {
                lueCekSenet.Enabled = true;
                lciCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AvukatPro.Services.Implementations.DevExpressService.KiymetliEvrakDoldur(lueCekSenet);
            }

            else
            {
                lciCekSenet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lueCekSenet.Enabled = false;
            }
        }

        private void lueSegment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.Segment, -1);
                frmalt.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            }
        }

        private void spAdet_EditValueChanged(object sender, EventArgs e)
        {
            spToplam.Value = spAdet.Value * spinBirimFiyat.Value;
        }

        private void spinBirimFiyat_EditValueChanged(object sender, EventArgs e)
        {
            spToplam.Value = spAdet.Value * spinBirimFiyat.Value;
        }
    }
}