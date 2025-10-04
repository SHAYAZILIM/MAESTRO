using System;
using System.Collections.Generic;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Messaging;
using AvukatProLib.Hesap;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using AvukatProLib;
using System.Windows.Forms;
using System.Data;

namespace AdimAdimDavaKaydi.Muhasebe
{
    public partial class frmDosyaMuhasebelestirme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private int _foyID;
        private int _modul;

        public frmDosyaMuhasebelestirme()
        {
            InitializeComponent();
        }

        public frmDosyaMuhasebelestirme(int modul, int foyID)
        {
            _foyID = foyID;
            _modul = modul;
            InitializeComponent();
        }

        private void btnAra_Click(object sender, System.EventArgs e)
        {
            List<int?> seciliIDler = new List<int?>();
            if (searchLookUpEdit1View.SelectedRowsCount > 0 && !string.IsNullOrEmpty(lueModul.Text))
            {
                for (int rowHandle = 0; rowHandle < searchLookUpEdit1View.RowCount; rowHandle++)
                {
                    if ((bool)searchLookUpEdit1View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        seciliIDler.Add((int)searchLookUpEdit1View.GetRowCellValue(rowHandle, "Id"));
                }
            }

            AvukatProLib.Extras.Modul? modul = null;
            switch (lueModul.Text)
            {
                case "Icra":
                    modul = AvukatProLib.Extras.Modul.Icra;
                    break;

                case "Dava":
                    modul = AvukatProLib.Extras.Modul.Dava;
                    break;

                case "Soruşturma":
                    modul = AvukatProLib.Extras.Modul.Sorusturma;
                    break;

                case "Sözleşme":
                    modul = AvukatProLib.Extras.Modul.Sozlesme;
                    break;
                case "Genel":
                    modul = AvukatProLib.Extras.Modul.Genel;
                    break;
            }

            GetMuhasebeBirlesikByFiltreRequest request = new GetMuhasebeBirlesikByFiltreRequest();

            request.Modul = modul;
            request.DosyaIds = seciliIDler;
            request.AnaKategori = (int?)lueAnaKategori.EditValue;
            request.AltKategori = (int?)lueAltKategori.EditValue;
            request.BorcAlacak = null;
            request.MasrafAvansTip = null;
            request.MasrafTarihi = null;
            request.MuvekkilID = null;
            request.ReferansNo = null;

            gcMuhasebeDetay.DataSource = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFiltre(request, "Tumu");
           
            BelgeUtil.Inits.HareketAnaKategoriGetir(lueGvAnaKategori);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(lueGvAltKategori);
            BelgeUtil.Inits.ParaBicimiAyarla(rluePara);
            BelgeUtil.Inits.ParaBicimiAyarla(rluePara2);
        }

        private void btnGonder_Click(object sender, System.EventArgs e)
        {
            List<int> olusturulanIDler = new List<int>();
            Dictionary<int, List<int>> olusturulanCariler = new Dictionary<int, List<int>>();

            if (gridView3.SelectedRowsCount > 0)
            {
                try
                {
                    for (int rowHandle = 0; rowHandle < gridView3.RowCount; rowHandle++)
                    {
                        if (Convert.ToDecimal(gridView3.GetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar")) > 0 && (bool)gridView3.GetRowCellValue(rowHandle, "IsSelected") == true)
                        {
                            int ID = (int)gridView3.GetRowCellValue(rowHandle, "Id");
                            List<int> cariIDs = new List<int> ();

                            //if (lueModul.Text == "Genel")
                            //    cariIDs = GetCariIDByFoyID((int)gridView3.GetRowCellValue(rowHandle, "MasrafAvansId"));
                            //else
                            //    cariIDs = GetCariIDByFoyID((int)gridView3.GetRowCellValue(rowHandle, "KayitId"));
                            cariIDs.Add((int)gridView3.GetRowCellValue(rowHandle, "MuvekkilCariId"));

                            bool varmi = false;
                            foreach (int key in olusturulanCariler.Keys)
                            {
                                if (key == ID)
                                    varmi = true;
                            }

                            if (!varmi)
                            {
                                List<int> idler = new List<int>();

                                foreach (var cariId in cariIDs)
                                {
                                    idler.Add(MuhasebeAraclari.SetCariHesapByMuhasebe(ID, cariId));
                                }

                                olusturulanCariler.Add(ID, idler);
                            }

                            int detayID = (int)gridView3.GetRowCellValue(rowHandle, "DetayId");
                            decimal birimFiyat = ((decimal)gridView3.GetRowCellValue(rowHandle, "BirimFiyat")) / cariIDs.Count;
                            int adet = (int)gridView3.GetRowCellValue(rowHandle, "Adet");

                            if (olusturulanCariler.ContainsKey(ID))
                            {
                                Av001TdiBilFoyMuhasebeDetayEntity guncellencekMuhasebeDetay = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeDetayById(detayID);
                                decimal carilestirilecek = ((decimal)gridView3.GetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar"));
                                decimal yeniCari = guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar - carilestirilecek;

                                foreach (var values in olusturulanCariler)
                                {
                                    if (values.Key == ID)
                                    {
                                        foreach (var value in values.Value)
                                        {
                                            olusturulanIDler.Add(MuhasebeAraclari.SetCariHesapByMuhasebeDetay(ID, detayID, value, birimFiyat, adet, cariIDs.Count));
                                        }
                                    }
                                }

                                guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar = yeniCari;
                                AvukatPro.Services.Implementations.MuhasebeService.UpdateMuhasebeDetay(guncellencekMuhasebeDetay);
                                gridView3.SetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar", yeniCari);
                            }
                        
                        
                        }
                    }
                    XtraMessageBox.Show("Seçili kayıtlar başarı ile muhasebeleştirildi.");
                }
                catch 
                {
                    XtraMessageBox.Show("İşlem sırasında hata oluştu. Lütfen tekrar deneyin!");
                }

                if (olusturulanIDler.Count > 0)
                {
                    List<RCariHesapDetayliEntity> cariHesaplar = new List<RCariHesapDetayliEntity>();

                    foreach (var id in olusturulanIDler)
                    {
                        cariHesaplar.Add(AvukatPro.Services.Implementations.CariService.GetCariHesapDetayById(id));
                    }

                    gcCariHesap.DataSource = cariHesaplar;
                    AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueCariAnaKategori);
                    AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueCariAltKategori);
                    BelgeUtil.Inits.BorcAlacakGetir(lueCariBorcAlacak);
                    BelgeUtil.Inits.OdemeTipiGetir(lueCariOdemeTip);
                }

                btnAra_Click(sender, e);
            }
        }

        private void btnHepsiniGonder_Click(object sender, EventArgs e)
        {
            List<int> olusturulanIDler = new List<int>();
            Dictionary<int, List<int>> olusturulanCariler = new Dictionary<int, List<int>>();

            if (gridView3.RowCount > 0)
            {
                try
                {
                    for (int rowHandle = 0; rowHandle < gridView3.RowCount; rowHandle++)
                    {
                        if (Convert.ToDecimal(gridView3.GetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar")) > 0)
                        {
                            int ID = (int)gridView3.GetRowCellValue(rowHandle, "Id");
                            
                            List<int> cariIDs = new List<int>();

                            //if (lueModul.Text == "Genel")
                            //    cariIDs = GetCariIDByFoyID((int)gridView3.GetRowCellValue(rowHandle, "MasrafAvansId"));
                            //else
                            //    cariIDs = GetCariIDByFoyID((int)gridView3.GetRowCellValue(rowHandle, "KayitId"));
                            cariIDs.Add((int)gridView3.GetRowCellValue(rowHandle, "MuvekkilCariId"));

                            bool varmi = false;
                            foreach (int key in olusturulanCariler.Keys)
                            {
                                if (key == ID)
                                    varmi = true;
                            }

                            if (!varmi)
                            {
                                List<int> idler = new List<int>();

                                foreach (var cariId in cariIDs)
                                {
                                    idler.Add(MuhasebeAraclari.SetCariHesapByMuhasebe(ID, cariId));
                                }

                                olusturulanCariler.Add(ID, idler);
                            }

                            int detayID = (int)gridView3.GetRowCellValue(rowHandle, "DetayId");
                            decimal birimFiyat = ((decimal)gridView3.GetRowCellValue(rowHandle, "BirimFiyat")) / cariIDs.Count;
                            int adet = (int)gridView3.GetRowCellValue(rowHandle, "Adet");

                            if (olusturulanCariler.ContainsKey(ID))
                            {
                                Av001TdiBilFoyMuhasebeDetayEntity guncellencekMuhasebeDetay = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeDetayById(detayID);
                                decimal carilestirilecek = ((decimal)gridView3.GetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar"));
                                decimal yeniCari = guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar - carilestirilecek;

                                foreach (var values in olusturulanCariler)
                                {
                                    if (values.Key == ID)
                                    {
                                        foreach (var value in values.Value)
                                        {
                                            olusturulanIDler.Add(MuhasebeAraclari.SetCariHesapByMuhasebeDetay(ID, detayID, value, birimFiyat, adet, cariIDs.Count));
                                        }
                                    }
                                }

                                guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar = yeniCari;
                                AvukatPro.Services.Implementations.MuhasebeService.UpdateMuhasebeDetay(guncellencekMuhasebeDetay);
                                gridView3.SetRowCellValue(rowHandle, "MuhasebelestirilmemisMiktar", yeniCari);
                            }
                        }
                    }
                    XtraMessageBox.Show("Tüm kayıtlar başarı ile muhasebeleştirildi.");
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("İşlem sırasında hata oluştu. Lütfen tekrar deneyin!");
                }

                if (olusturulanIDler.Count > 0)
                {
                    List<RCariHesapDetayliEntity> cariHesaplar = new List<RCariHesapDetayliEntity>();

                    foreach (var id in olusturulanIDler)
                    {
                        cariHesaplar.Add(AvukatPro.Services.Implementations.CariService.GetCariHesapDetayById(id));
                    }

                    gcCariHesap.DataSource = cariHesaplar;
                    AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueCariAnaKategori);
                    AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueCariAltKategori);
                    BelgeUtil.Inits.BorcAlacakGetir(lueCariBorcAlacak);
                    BelgeUtil.Inits.OdemeTipiGetir(lueCariOdemeTip);
                }

                btnAra_Click(sender, e);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            lueDosya.Enabled = false;
            btnAra.Enabled = false;
            lueDosya.Reset();
            lueModul.Refresh();
            lueAltKategori.Reset();
            lueAnaKategori.Reset();
            gcMuhasebeDetay.DataSource = null;
            gcMuvekkiller.DataSource = null;
            gcCariHesap.DataSource = null;
            this.Refresh();
        }

        private void frmDosyaMuhasebelestirme_Load(object sender, System.EventArgs e)
        {
            if (_foyID > 0)
            {
                spGridlerMuhasebe.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                pnlFiltre.Enabled = false;
                pnlFiltre.Visible = false;
                pnlUstMenu.Enabled = false;
                pnlUstMenu.Visible = false;
                gcMuhasebeDetay.DataSource = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFoyId(_foyID, _modul);
                AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueGvAnaKategori);
                AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueGvAltKategori);
                BelgeUtil.Inits.ParaBicimiAyarla(rluePara);
                BelgeUtil.Inits.ParaBicimiAyarla(rluePara2);
            }

            else
            {
                AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);
                AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueAnaKategori);
                spGridlerMuhasebe.SplitterPosition = 410;
                gcMuvekkiller.Enabled = false;
                gcMuvekkiller.Visible = false;
            }
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);

            //ColumnFilterInfo cfi = new ColumnFilterInfo("[Muh. Miktar] <> '0'");
            //gridView3.filtere = "[Muh. Miktar] <> '0'";

            //gridView3.Columns["asd"].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Equals;

            //gridView3.FilterExpression = "[Budget] > 100000  AND [Location] = 'Monterey'";
            //gridView3.SettingsText.Title = gridView3.FilterExpression;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Adet" || e.Column.FieldName == "BirimFiyat")
            {
                int muhasebeDetayId = (int)gridView3.GetRowCellValue(e.RowHandle, "DetayId");
                Av001TdiBilFoyMuhasebeDetayEntity guncellencekMuhasebeDetay = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeDetayById(muhasebeDetayId);
                if (e.Column.FieldName == "Adet")
                {
                    guncellencekMuhasebeDetay.Adet = (int)e.Value;
                    decimal toplamTutar = (int)e.Value * guncellencekMuhasebeDetay.BirimFiyat;
                    decimal genelToplam = toplamTutar + guncellencekMuhasebeDetay.KdvTutar + guncellencekMuhasebeDetay.StopajSsdfTutar;
                    decimal cari = guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar + (toplamTutar - guncellencekMuhasebeDetay.ToplamTutar);
                    gridView3.SetRowCellValue(e.RowHandle, "ToplamTutar", toplamTutar);
                    gridView3.SetRowCellValue(e.RowHandle, "MuhasebelestirilmemisMiktar", cari);
                    guncellencekMuhasebeDetay.ToplamTutar = toplamTutar;
                    guncellencekMuhasebeDetay.GenelToplam = genelToplam;
                    guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar = cari;
                }

                else if (e.Column.FieldName == "BirimFiyat")
                {
                    guncellencekMuhasebeDetay.BirimFiyat = (decimal)e.Value;
                    decimal toplamTutar = (decimal)e.Value * guncellencekMuhasebeDetay.Adet;
                    decimal genelToplam = toplamTutar + guncellencekMuhasebeDetay.KdvTutar + guncellencekMuhasebeDetay.StopajSsdfTutar;
                    decimal cari = guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar + (toplamTutar - guncellencekMuhasebeDetay.ToplamTutar);
                    gridView3.SetRowCellValue(e.RowHandle, "ToplamTutar", toplamTutar);
                    gridView3.SetRowCellValue(e.RowHandle, "MuhasebelestirilmemisMiktar", cari);
                    guncellencekMuhasebeDetay.ToplamTutar = toplamTutar;
                    guncellencekMuhasebeDetay.GenelToplam = genelToplam;
                    guncellencekMuhasebeDetay.MuhasebelestirilmemisMiktar = cari;
                }

                AvukatPro.Services.Implementations.MuhasebeService.UpdateMuhasebeDetay(guncellencekMuhasebeDetay);
            }
        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridView3.SelectedRowsCount > 0)
            {
                object obj = gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "KayitId");
                if (obj != null)
                    muvekkilleriGetir((int)obj);
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "BorcAlacakId" || e.Column.FieldName == "OdemeTipId")
            {
                int cariDetayID = (int)gridView3.GetRowCellValue(e.RowHandle, "Id");
                Av001TdiBilCariHesapDetayEntity guncellenecekCari = new Av001TdiBilCariHesapDetayEntity();

                if (e.Column.FieldName == "BorcAlacakId")
                {
                    guncellenecekCari.BorcAlacakId = (int)e.Value;
                }

                else if (e.Column.FieldName == "OdemeTipId")
                {
                    guncellenecekCari.OdemeTipId = (int)e.Value;
                }
                AvukatPro.Services.Implementations.CariService.UpdateCariHesapDetay(guncellenecekCari);
            }
        }

        private void lueAnaKategori_EditValueChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(lueAnaKategori.EditValue.ToString()))
                return;
            int anaKategoriID = (int)lueAnaKategori.EditValue;

            if (anaKategoriID != null)
            {
                BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties, anaKategoriID);
            }
        }

        private void lueModul_EditValueChanged(object sender, System.EventArgs e)
        {
            switch (lueModul.Text)
            {
                case "Icra":
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, true);
                    break;

                case "Dava":
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, true);
                    break;

                case "Soruşturma":
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, true);
                    break;

                case "Sözleşme":
                    AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, true);
                    break;
                default:
                    break;
            }
            lueDosya.Enabled = true;
            btnAra.Enabled = true;
        }

        private void muvekkilleriGetir(int foyID)
        {
            if (lueModul.Text == "Icra" || _modul == 1)
            {
                List<PerAv001TiBilFoyTarafEntity> taraflar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilFromIcraByFoyId(foyID);

                gcMuvekkiller.DataSource = taraflar;
            }

            else if (lueModul.Text == "Dava" || _modul == 2)
            {
                List<PerAv001TdBilFoyTarafEntity> taraflar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilFromDavaByFoyId(foyID);

                gcMuvekkiller.DataSource = taraflar;
            }

            else if (lueModul.Text == "Soruşturma" || _modul == 3)
            {
                List<PerAv001TdBilHazirlikTarafEntity> taraflar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilFromSorusturmaByFoyId(foyID);

                gcMuvekkiller.DataSource = taraflar;
            }

            else if (lueModul.Text == "Sözleşme" || _modul == 5)
            {
                List<PerAv001TdiBilSozlesmeTarafEntity> taraflar = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilFromSozlesmeByFoyId(foyID);

                gcMuvekkiller.DataSource = taraflar;
            }
        }
    }
}