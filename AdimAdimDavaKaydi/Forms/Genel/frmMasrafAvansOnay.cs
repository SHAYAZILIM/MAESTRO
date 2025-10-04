using AvukatPro.Model.EntityClasses;
using AvukatProLib;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Genel
{
    public partial class frmMasrafAvansOnay : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmMasrafAvansOnay()
        {
            InitializeComponent();
        }

        private CompInfo cmpNfo;

        private void btnAra_Click(object sender, EventArgs e)
        {
            gcCariHespDetay.DataSource = null;

            List<int?> dosyaIDleri = new List<int?>();
            if (searchLookUpEdit1View.SelectedRowsCount > 0 && !string.IsNullOrEmpty(lueModul.Text))
            {
                for (int rowHandle = 0; rowHandle < searchLookUpEdit1View.RowCount; rowHandle++)
                {
                    if ((bool)searchLookUpEdit1View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        dosyaIDleri.Add((int)searchLookUpEdit1View.GetRowCellValue(rowHandle, "Id"));
                }
            }

            AvukatPro.Services.Messaging.GetCariHesapDetayRequest request = new AvukatPro.Services.Messaging.GetCariHesapDetayRequest();
            request.OnayDurum = lueOnay.EditValue == null ? null : (int?)Convert.ToInt32(lueOnay.EditValue);
            request.Cari = (int?)luePersonelAd.EditValue;
            request.DosyaIDs = dosyaIDleri;

            if (lueModul.EditValue != null)
            {
                switch ((int)lueModul.EditValue)
                {
                    case 1:
                        request.Modul = AvukatProLib.Extras.Modul.Icra;
                        break;

                    case 2:
                        request.Modul = AvukatProLib.Extras.Modul.Dava;
                        break;

                    case 3:
                        request.Modul = AvukatProLib.Extras.Modul.Sorusturma;
                        break;

                    case 5:
                        request.Modul = AvukatProLib.Extras.Modul.Sozlesme;
                        break;

                    default:
                        break;
                }
            }

            //aykut hızlandırma 28.01.2013
            //gcCariHespDetay.DataSource = AvukatPro.Services.Implementations.CariService.GetPersonelCariHesapDetayByFiltre(request);
            gcCariHespDetay.DataSource = AvukatPro.Services.Implementations.CariService.CariHesabiFiltreleMasrafOnay(request);
            AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueGcKategori);
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(lueGcAltKategori);
            BelgeUtil.Inits.OnayDurumGetir(lueGcOnay);

            if (gridView1.RowCount > 0)
            {
                btnTumunuOnayla.Enabled = true;
                btnSecilileriOnayla.Enabled = true;
            }
        }

        private void btnSecilileriOnayla_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (!KontrolEdildiOnaylandi(false))
                    return;

                List<Av001TdiBilCariHesapDetayEntity> guncellenecekCariler = new List<Av001TdiBilCariHesapDetayEntity>();
                for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                {
                    if ((bool)gridView1.GetRowCellValue(rowHandle, "IsSelected") == true)
                    {
                        Av001TdiBilCariHesapDetayEntity guncellenecekCari = AvukatPro.Services.Implementations.CariService.GetCariHesapById((int)gridView1.GetRowCellValue(rowHandle, "HesapDetayId"));
                        if (guncellenecekCari.OnayDurum < (int)AvukatProLib.Extras.MasrafOnay.uOnay)
                            guncellenecekCari.OnayDurum = guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.Değerlendirilmedi ? (int)AvukatProLib.Extras.MasrafOnay.bOnay : guncellenecekCari.OnayDurum + 1;
                        guncellenecekCari.OnayTarihi = DateTime.Now;
                        guncellenecekCari.Incelendi = true;
                        guncellenecekCari.OnayNo = guncellenecekCari.OnayNo == string.Empty ? guncellenecekCari.Id + '-' + DateTime.Now.Date.ToString().Trim('.') : guncellenecekCari.OnayNo;
                        guncellenecekCariler.Add(guncellenecekCari);
                        gridView1.SetRowCellValue(rowHandle, "OnayTarihi", guncellenecekCari.OnayTarihi);
                        gridView1.SetRowCellValue(rowHandle, "OnayDurum", guncellenecekCari.OnayDurum);
                        gridView1.SetRowCellValue(rowHandle, "OnayNo", guncellenecekCari.OnayNo);
                    }
                }

                try
                {
                    AvukatPro.Services.Implementations.CariService.UpdateCariHesapDetay(guncellenecekCariler);
                    XtraMessageBox.Show("Tüm masraf avanslar onaylandı");
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Onaylama sırasında bir sorun oluştu!");
                }
            }
            else
                XtraMessageBox.Show("Onaylamak istediğiniz masraf avansları seçiniz!");
        }

        private void btnTumunuOnayla_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                if (!KontrolEdildiOnaylandi(true))
                    return;

                List<Av001TdiBilCariHesapDetayEntity> guncellenecekCariler = new List<Av001TdiBilCariHesapDetayEntity>();
                for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                {
                    Av001TdiBilCariHesapDetayEntity guncellenecekCari = AvukatPro.Services.Implementations.CariService.GetCariHesapById((int)gridView1.GetRowCellValue(rowHandle, "HesapDetayId"));
                    if (guncellenecekCari.OnayDurum < (int)AvukatProLib.Extras.MasrafOnay.uOnay)
                        guncellenecekCari.OnayDurum = guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.Değerlendirilmedi ? (int)AvukatProLib.Extras.MasrafOnay.bOnay : guncellenecekCari.OnayDurum + 1;
                    guncellenecekCari.OnayTarihi = DateTime.Now;
                    guncellenecekCari.Incelendi = true;
                    guncellenecekCari.OnayNo = guncellenecekCari.OnayNo == string.Empty ? guncellenecekCari.Id + '-' + DateTime.Now.Date.ToString().Trim('.') : guncellenecekCari.OnayNo;
                    guncellenecekCariler.Add(guncellenecekCari);
                    gridView1.SetRowCellValue(rowHandle, "OnayTarihi", guncellenecekCari.OnayTarihi);
                    gridView1.SetRowCellValue(rowHandle, "OnayDurum", guncellenecekCari.OnayDurum);
                    gridView1.SetRowCellValue(rowHandle, "OnayNo", guncellenecekCari.OnayNo);
                }

                try
                {
                    AvukatPro.Services.Implementations.CariService.UpdateCariHesapDetay(guncellenecekCariler);
                    XtraMessageBox.Show("Tüm masraf avanslar onaylandı");
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Onaylama sırasında bir sorun oluştu!");
                }
            }
        }

        private void frmMasrafAvansOnay_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ModulKodGetir(lueModul);
            BelgeUtil.Inits.OnayDurumGetir(lueOnay);
            BelgeUtil.Inits.CariPersonelGetir(luePersonelAd);
            BelgeUtil.Inits.ParaBicimiAyarla(rluePara);

            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            cmpNfo = cmpNfoList[0];
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelected")
                return;
            Av001TdiBilCariHesapDetayEntity guncellenecekCari = AvukatPro.Services.Implementations.CariService.GetCariHesapById((int)gridView1.GetRowCellValue(e.RowHandle, "HesapDetayId"));

            if (e.Column.FieldName == "Adet")
            {
                int adet = (int)gridView1.GetRowCellValue(e.RowHandle, "Adet");
                decimal yeniGenelToplam = adet * ((decimal)gridView1.GetRowCellValue(e.RowHandle, "GenelToplam"));
                gridView1.SetRowCellValue(e.RowHandle, "GenelToplam", yeniGenelToplam);
                guncellenecekCari.Adet = adet;
                guncellenecekCari.GenelToplam = yeniGenelToplam;
            }

            else if (e.Column.FieldName == "BirimFiyat")
            {
                decimal birimFiyat = (decimal)gridView1.GetRowCellValue(e.RowHandle, "BirimFiyat");
                decimal yeniGenelToplam = birimFiyat * (int)gridView1.GetRowCellValue(e.RowHandle, "Adet");
                gridView1.SetRowCellValue(e.RowHandle, "GenelToplam", yeniGenelToplam);
                guncellenecekCari.BirimFiyat = birimFiyat;
                guncellenecekCari.GenelToplam = yeniGenelToplam;
            }

            else if (e.Column.FieldName == "Incelendi")
            {
                bool incelendi = (bool)gridView1.GetRowCellValue(e.RowHandle, "Incelendi");
                guncellenecekCari.Incelendi = incelendi;
            }

            else if (e.Column.FieldName == "OnayDurum")
            {
                int onayDurum = (int)gridView1.GetRowCellValue(e.RowHandle, "OnayDurum");
                guncellenecekCari.OnayDurum = onayDurum;
                guncellenecekCari.Incelendi = true;
                guncellenecekCari.OnayNo = guncellenecekCari.OnayNo == string.Empty ? guncellenecekCari.Id + '-' + DateTime.Now.Date.ToString().Trim('.') : guncellenecekCari.OnayNo;
                gridView1.SetRowCellValue(e.RowHandle, "Incelendi", true);
            }

            else if (e.Column.FieldName == "OnayTarihi")
            {
                DateTime onayTarihi = (DateTime)gridView1.GetRowCellValue(e.RowHandle, "OnayTarihi");
                guncellenecekCari.OnayTarihi = onayTarihi;
            }

            else if (e.Column.FieldName == "Aciklama")
            {
                guncellenecekCari.Aciklama = gridView1.GetRowCellValue(e.RowHandle, "Aciklama").ToString();
            }

            AvukatPro.Services.Implementations.CariService.UpdateCariHesapDetay(guncellenecekCari);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < -1)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            gv.SetRowCellValue(e.RowHandle, gv.Columns["IsSelected"], !((bool)gv.GetRowCellValue(e.RowHandle, "IsSelected")));
        }

        private bool KontrolEdildiOnaylandi(bool HepsiMi)
        {
            if (cmpNfo.OnaylamaSifresiAktif)
            {
                bool Onay1Varmi = false;
                bool Onay2Varmi = false;
                bool Onay3Varmi = false;

                bool Onaylandi1 = false;
                bool Onaylandi2 = false;
                bool Onaylandi3 = false;

                for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                {
                    if (HepsiMi)
                    {
                        Av001TdiBilCariHesapDetayEntity guncellenecekCari = AvukatPro.Services.Implementations.CariService.GetCariHesapById((int)gridView1.GetRowCellValue(rowHandle, "HesapDetayId"));
                        if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.Değerlendirilmedi)
                            Onay1Varmi = true;
                        else if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.bOnay)
                            Onay2Varmi = true;
                        else if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.iOnay)
                            Onay3Varmi = true;
                    }
                    else
                    {
                        if ((bool)gridView1.GetRowCellValue(rowHandle, "IsSelected") == true)
                        {
                            Av001TdiBilCariHesapDetayEntity guncellenecekCari = AvukatPro.Services.Implementations.CariService.GetCariHesapById((int)gridView1.GetRowCellValue(rowHandle, "HesapDetayId"));
                            if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.Değerlendirilmedi)
                                Onay1Varmi = true;
                            else if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.bOnay)
                                Onay2Varmi = true;
                            else if (guncellenecekCari.OnayDurum == (int)AvukatProLib.Extras.MasrafOnay.iOnay)
                                Onay3Varmi = true;
                        }
                    }
                }

                if (Onay1Varmi)
                {
                    frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(1);
                    frm.ShowDialog();
                    Onaylandi1 = frm.Onaylandi;
                }
                else
                    Onaylandi1 = true;

                if (Onay2Varmi && Onaylandi1)
                {
                    frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(2);
                    frm.ShowDialog();
                    Onaylandi2 = frm.Onaylandi;
                }
                else
                    Onaylandi2 = true;

                if (Onay3Varmi && Onaylandi1 && Onaylandi2)
                {
                    frmOnaySifreKontrolu frm = new frmOnaySifreKontrolu(3);
                    frm.ShowDialog();
                    Onaylandi3 = frm.Onaylandi;
                }
                else
                    Onaylandi3 = true;

                if (!Onaylandi1 || !Onaylandi2 || !Onaylandi3)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
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
        }
    }
}