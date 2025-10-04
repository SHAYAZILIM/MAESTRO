using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Genel;
using AdimAdimDavaKaydi.Muhasebe;
using AdimAdimDavaKaydi.UserControls.MuhasebeArama;
using AvukatPro.Model.EntityClasses;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.UserControls;

namespace AdimAdimDavaKaydi.GirisEkran
{
    public partial class rFrmMuhasebeGirisEkran : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public rFrmMuhasebeGirisEkran()
        {
            InitializeComponent();
            navBarItem10.LinkClicked += navBarItem10_LinkClicked;
            navBarItem4.LinkClicked += navBarItem4_LinkClicked;
            navBarItem2.LinkClicked += navBarItem2_LinkClicked;
            this.EventlerKullanilacakMi = true;
        }

        public List<int> BelgeIds { get; set; }

        public int BelgeIndex { get; set; }

        public int? KasaHesapId { get; set; }

        public int? KiymetliEvrakId { get; set; }

        public int? MuhatapHesapId { get; set; }        

        private void arama_Arama(object sender, AramaYapildi e)
        {
            ucMuhasebeGenel1.MyMasrafAvansDetayli = e.Sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyMasrafAvansDetayliSonuc = ucMuhasebeGenel1.MyMasrafAvansDetayli;
        }

        private void arama_AramaCariHesap(object sender, AramaYapildiCariHesap e)
        {
            if (e.Sonuc != null)
            {
                ucMuhasebeGenel1.MyPersonelCariHesapDetayli = e.Sonuc;
                ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = e.Sonuc;
            }
            else
            {
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = e.Sonuc;
                ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = e.Sonuc;
            }
        }

        private void arama_AramaCariHesapMuvekkil(object sender, AramaYapildiCariHesap e)
        {
            if (e.Sonuc != null)
            {
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = e.Sonuc;
                ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = e.Sonuc;
            }
            else
            {
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = e.Sonuc;
                ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = e.Sonuc;
            }
        }

        private void arama_AramaFatura(object sender, ucSerbestMeslekMakbuzuArama.AramaYapildiFatura e)
        {
            ucMuhasebeGenel1.MyFaturaView = e.Sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyDataSource = ucMuhasebeGenel1.MyFaturaView;
        }

        private void arama_AramaKasa(object sender, AramaYapildiKasa e)
        {
            ucMuhasebeGenel1.MyKasaView = e.Sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyKasaView = ucMuhasebeGenel1.MyKasaView;
        }

        private void arama_AramaMuhasebe(object sender, AramaYapildiMuhasebe e)
        {
            ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli = e.SonucMuhasebe;
            ucMuhasebeGenel1.ucPivotChart1.MyDataSource = e.SonucMuhasebe;
        }

        private void arama_Temizle(object sender, Temizlendi e)
        {
            ucMuhasebeGenel1.MyMasrafAvansDetayli = e.SonucT;
            ucMuhasebeGenel1.ucPivotChart1.MyDataSource = ucMuhasebeGenel1.MyMasrafAvansDetayli;
        }

        private void arama_TemizleCariHesap(object sender, TemizlendiCariHesap e)
        {
            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = e.SonucT;
        }

        private void arama_TemizleFatura(object sender, ucSerbestMeslekMakbuzuArama.TemizlendiFatura e)
        {
            ucMuhasebeGenel1.MyFaturaView = e.SonucT;
            ucMuhasebeGenel1.ucPivotChart1.MyDataSource = ucMuhasebeGenel1.MyFaturaView;
        }

        private void arama_TemizleKasa(object sender, TemizlendiKasa e)
        {
            ucMuhasebeGenel1.MyKasaView = e.SonucT;
            ucMuhasebeGenel1.ucPivotChart1.MyKasaView = ucMuhasebeGenel1.MyKasaView;
        }

        private void belgeyiOnlizle(Av001TdieBilBelgeEntity belge, int index)
        {
            if (belge != null && belge.Id != 0)
            {
                string file = belge.DosyaAdi;
                string[] exts = file.Split('.');

                if (exts.Length <= 0)
                {
                    return;
                }

                string ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
                byte[] data = belge.Icerik;

                if (file == string.Empty && data == null)
                {
                    return;
                }

                if (data == null)
                {
                    if (File.Exists(file))
                    {
                        FileStream fss = new FileStream(file, FileMode.Open);

                        byte[] veri = new byte[fss.Length];
                        fss.Read(veri, 0, veri.Length);
                        belge.Icerik = veri;
                        data = belge.Icerik;
                        fss.Close();
                    }
                }
                ucBelgeOnizleme1.ViewFile(data, belge.Id, belge.KontrolVersiyon, ext);
                dnBelge.Tag = belge.Id;
                BelgeIndex = index;
            }
        }

        private void btnProgram_Click(object sender, System.EventArgs e)
        {
            Av001TdieBilBelgeEntity belge = AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]);
            if (belge != null && belge.Icerik != null)
            {
                string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DokumanUzanti;
                FileStream fs = new FileStream(bad, FileMode.Create);
                fs.Write(belge.Icerik.ToArray(), 0, belge.Icerik.Length);
                fs.Close();
                fs.Dispose();
                Tools.OpenProgram(bad);
            }
            else
            {
                MessageBox.Show("Belge Ýçeriði Bulunamadý", "Dikkat", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void dnBelge_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "first")
            {
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.First()), BelgeIds.Count - 1);
            }

            else if (e.Button.Tag == "last")
            {
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.Last()), BelgeIds.Count - 1);
            }

            else if (e.Button.Tag == "next")
            {
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex + 1]), BelgeIndex + 1);
            }

            else if (e.Button.Tag == "prev")
            {
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex - 1]), BelgeIndex - 1);
            }
        }

        private void hidePanelTemizle()
        {
            BelgeIds = null;
            btnProgram.Enabled = false;
            gcKasaHesap.Visible = false;
            gcMuhatapHesap.Visible = false;
            gcKiymetliEvrak.Visible = false;
            gcKiymetliEvrakTaraf.Visible = false;
            ucBelgeOnizleme1.Visible = false;
        }

        private void mainView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            hidePanelTemizle();

            if (ucMuhasebeGenel1.mainView.SelectedRowsCount > 0)
            {
                if (ucMuhasebeGenel1.ColumnsMode != "Serbest")
                {
                    if (ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "BuroHesapSahibiCariBankaId") != DBNull.Value)
                        KasaHesapId = (int?)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "BuroHesapSahibiCariBankaId");

                    if (ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "MuhatapHesapSahibiCariBankaId") != DBNull.Value)
                        MuhatapHesapId = (int?)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "MuhatapHesapSahibiCariBankaId");

                    if (ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "KiymetliEvrakId") != DBNull.Value)
                        KiymetliEvrakId = (int?)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "KiymetliEvrakId");
                }

                if (ucMuhasebeGenel1.ColumnsMode == "Serbest" && ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "BelgeId") != null)
                {
                    List<int> ids = new List<int>();
                    ids.Add((int)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "BelgeId"));
                    if (ids.Count > 0)
                        BelgeIds = ids;
                }

                if (ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId") == DBNull.Value)
                    return;
                else if (((int?)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "MasrafAvansDetayId")).HasValue)
                {
                    if (ucMuhasebeGenel1.ColumnsMode == "Masraf")
                    {
                        BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByMayrafAvansDetayId((int)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "Id"));
                    }

                    if (ucMuhasebeGenel1.ColumnsMode == "Dosya")
                    {
                        BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByMuhasebeDetayId((int)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "Id"));
                    }

                    if (ucMuhasebeGenel1.ColumnsMode == "Personel" || ucMuhasebeGenel1.ColumnsMode == "Müvekkil")
                    {
                        BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByCariHesapDetayId((int)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "Id"));
                    }

                    if (ucMuhasebeGenel1.ColumnsMode == "Kasa")
                    {
                        BelgeIds = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByKasaDetayDetayId((int)ucMuhasebeGenel1.mainView.GetRowCellValue(e.FocusedRowHandle, "Id"));
                    }
                }

                if (KasaHesapId.HasValue)
                {
                    BelgeUtil.Inits.CariIsmiGetir(rlueKasaCariAd);
                    BelgeUtil.Inits.BankaGetir(rlueKasaBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueKasaSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueKasaHesapTuru);
                    BelgeUtil.Inits.BankaKartTipiGetir(rlueKasaKartTipi);

                    gcKasaHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetCariBankaById((int)KasaHesapId);
                    gcKasaHesap.Visible = true;
                }

                if (MuhatapHesapId.HasValue)
                {
                    BelgeUtil.Inits.CariIsmiGetir(rlueMuhatapCari);
                    BelgeUtil.Inits.BankaGetir(rlueMuhatapBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueMuhatapSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueMuhatapHesapTur);
                    BelgeUtil.Inits.BankaKartTipiGetir(rlueMuhatapKartTipi);
                    gcMuhatapHesap.DataSource = AvukatPro.Services.Implementations.CariService.GetCariBankaById((int)MuhatapHesapId);

                    gcMuhatapHesap.Visible = true;
                }

                if (KiymetliEvrakId.HasValue)
                {
                    BelgeUtil.Inits.BankaGetir(rlueKiymetliEvrakBanka);
                    BelgeUtil.Inits.BankaSubeGetir(rlueKiymetliEvrakSube);
                    BelgeUtil.Inits.DovizTipGetir(rlueKiymetliEvrakDoviz);
                    BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlueKiymetliEvrakTur);

                    List<Av001TdiBilKiymetliEvrakEntity> gelenKiymetliEvrak = AvukatPro.Services.Implementations.DosyaService.GetKiymetliEvrakById((int)KiymetliEvrakId);
                    gcKiymetliEvrak.DataSource = gelenKiymetliEvrak;
                    List<Av001TdiBilKiymetliEvrakTarafEntity> gelenTaraflar = AvukatPro.Services.Implementations.DosyaService.GetKiymetliEvrakTarafByKiymetliEvrakId(gelenKiymetliEvrak.FirstOrDefault().Id);

                    if (gelenTaraflar.Count > 0)
                    {
                        gcKiymetliEvrakTaraf.DataSource = gelenTaraflar;
                        gcKiymetliEvrakTaraf.Visible = true;
                        BelgeUtil.Inits.perCariGetir(rlueTarafCari);
                        BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rlueTarafTipi);
                        gcKiymetliEvrakTaraf.BringToFront();
                    }

                    gcKiymetliEvrak.Visible = true;
                }

                if (BelgeIds != null && BelgeIds.Count > 0)
                {
                    dnBelge.DataSource = BelgeIds;
                    Av001TdieBilBelgeEntity belge = AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[0]);
                    belgeyiOnlizle(belge, 0);
                    btnProgram.Enabled = true;
                    ucBelgeOnizleme1.Visible = true;
                }
            }
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            ucMuhasebeGenel1.MyCariHesapDetayli = BelgeUtil.Inits.R_CARI_HESAP_DETAYLIGetir();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.frmKasaGiris kg = new AdimAdimDavaKaydi.Forms.frmKasaGiris();
            kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
            kg.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucMasrafAvansMuhArama arama = new ucMasrafAvansMuhArama("masraf");
            arama.Dock = DockStyle.Fill;
            arama.Arama += arama_Arama;
            arama.Temizle += arama_Temizle;
            pnlArama.Controls.Clear();
            ngrbArama.Expanded = true;
            pnlArama.Controls.Add(arama);

            foreach (NavigatorCustomButton item in ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons)
            {
                if (item.Index == 18)
                    item.Visible = true;
            }

            ucMuhasebeGenel1.MyMasrafAvansDetayli = arama.masraf;
            ucMuhasebeGenel1.ucPivotChart1.MyMasrafAvansDetayliSonuc = ucMuhasebeGenel1.MyMasrafAvansDetayli;
            ucMuhasebeGenel1.mainView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(mainView_FocusedRowChanged);
            ucMuhasebeGenel1.ColumnsMode = "Masraf";
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucSerbestMeslekMakbuzuArama arama = new ucSerbestMeslekMakbuzuArama();
            arama.Dock = DockStyle.Fill;
            arama.AramaFatura += arama_AramaFatura;
            arama.TemizleFatura += arama_TemizleFatura;
            pnlArama.Controls.Clear();
            pnlArama.Controls.Add(arama);
            ngrbArama.Expanded = true;

            foreach (NavigatorCustomButton item in ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons)
            {
                if (item.Index == 18)
                    item.Visible = false;
            }

            ucMuhasebeGenel1.MyFaturaView = arama.sonuc;
            ucMuhasebeGenel1.mainView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(mainView_FocusedRowChanged);
            ucMuhasebeGenel1.ColumnsMode = "Serbest";
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucKasaMuhArama arama = new ucKasaMuhArama();
            arama.Dock = DockStyle.Fill;
            arama.AramaKasa += arama_AramaKasa;
            arama.TemizleKasa += arama_TemizleKasa;
            pnlArama.Controls.Clear();
            ngrbArama.Expanded = true;
            pnlArama.Controls.Add(arama);

            foreach (NavigatorCustomButton item in ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons)
            {
                if (item.Index == 18)
                    item.Visible = false;
            }

            ucMuhasebeGenel1.MyKasaView = arama.sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyKasaView = ucMuhasebeGenel1.MyKasaView;
            ucMuhasebeGenel1.mainView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(mainView_FocusedRowChanged);
            ucMuhasebeGenel1.ColumnsMode = "Kasa";
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucCariHesapArama arama = new ucCariHesapArama("müvekkil");
            arama.Dock = DockStyle.Fill;
            arama.AramaCariHesapMuvekkil += arama_AramaCariHesapMuvekkil;
            arama.TemizleCariHesap += arama_TemizleCariHesap;
            pnlArama.Controls.Clear();
            ucMuhasebeGenel1.personel = false;
            arama.muvekkil = true;
            ngrbArama.Expanded = true;
            pnlArama.Controls.Add(arama);

            foreach (NavigatorCustomButton item in ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons)
            {
                if (item.Index == 18)
                    item.Visible = false;
            }

            ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = arama.sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli;
            ucMuhasebeGenel1.mainView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(mainView_FocusedRowChanged);
            ucMuhasebeGenel1.ColumnsMode = "Müvekkil";
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucCariHesapArama arama = new ucCariHesapArama("personel");
            arama.Dock = DockStyle.Fill;
            arama.AramaCariHesapPersonel += arama_AramaCariHesap;
            arama.TemizleCariHesap += arama_TemizleCariHesap;
            pnlArama.Controls.Clear();
            ucMuhasebeGenel1.personel = true;
            arama.personel = true;
            ngrbArama.Expanded = true;
            pnlArama.Controls.Add(arama);

            foreach (NavigatorCustomButton item in ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons)
            {
                if (item.Index == 18)
                    item.Visible = false;
            }

            ucMuhasebeGenel1.MyPersonelCariHesapDetayli = arama.sonuc;
            ucMuhasebeGenel1.ucPivotChart1.MyCarHesapDetayliArama = ucMuhasebeGenel1.MyPersonelCariHesapDetayli;
            ucMuhasebeGenel1.mainView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(mainView_FocusedRowChanged);
            ucMuhasebeGenel1.ColumnsMode = "Personel";
        }

        private void navBarItem7_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Temizle();
            hidePanelTemizle();
            ucMasrafAvansMuhArama arama = new ucMasrafAvansMuhArama("muhasebe");
            arama.Dock = DockStyle.Fill;
            arama.AramaMuhasebe += arama_AramaMuhasebe;
            pnlArama.Controls.Clear();
            ngrbArama.Expanded = true;
            pnlArama.Controls.Add(arama);
            var list = ucMuhasebeGenel1.gcGenel.EmbeddedNavigator.Buttons.CustomButtons;

            foreach (NavigatorCustomButton item in list)
            {
                if (item.Index == 18)
                    item.Visible = false;
            }
            ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli = arama.muhasebe;
            ucMuhasebeGenel1.ucPivotChart1.MyDataSource = ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli;
            ucMuhasebeGenel1.ColumnsMode = "Dosya";
        }

        private void nbiDosyaMuhasebesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDosyaMuhasebelestirme frm = new frmDosyaMuhasebelestirme();
            frm.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            frm.Show();
        }

        private void nbiMasrafAvansOnay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmMasrafAvansOnay frm = new frmMasrafAvansOnay();
            frm.MdiParent = AdimAdimDavaKaydi.AnaForm.mdiAvukatPro.MainForm;
            frm.Show();
        }

        private void Temizle()
        {
            GC.RemoveMemoryPressure(9);
            GC.SuppressFinalize(ucMuhasebeGenel1);

            if (ucMuhasebeGenel1.MyPersonelCariHesapDetayli != null)
                ucMuhasebeGenel1.MyPersonelCariHesapDetayli = null;

            if (ucMuhasebeGenel1.MyCariHesapDetayli != null)
                ucMuhasebeGenel1.MyCariHesapDetayli.Clear();

            if (ucMuhasebeGenel1.MyDavaFoyMuhasebeDetay != null)
                ucMuhasebeGenel1.MyDavaFoyMuhasebeDetay.Clear();

            if (ucMuhasebeGenel1.MyFaturaView != null)
                ucMuhasebeGenel1.MyFaturaView = null;

            if (ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli != null)
                ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli = null;

            if (ucMuhasebeGenel1.MyIcraFoyMuhasebeDetay != null)
                ucMuhasebeGenel1.MyIcraFoyMuhasebeDetay.Clear();

            if (ucMuhasebeGenel1.MyKasaView != null)
                ucMuhasebeGenel1.MyKasaView = null;

            if (ucMuhasebeGenel1.MyMasrafAvansDetayli != null)
                ucMuhasebeGenel1.MyMasrafAvansDetayli = null;

            if (ucMuhasebeGenel1.MyMasrafDataSource != null)
                ucMuhasebeGenel1.MyMasrafDataSource.Clear();

            if (ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli != null)
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = null;

            if (ucMuhasebeGenel1.MyPersonelCariHesapDetayli != null)
                ucMuhasebeGenel1.MyPersonelCariHesapDetayli = null;

            if (ucMuhasebeGenel1.MySorusturmaFoyMuhasebe != null)
                ucMuhasebeGenel1.MySorusturmaFoyMuhasebe.Clear();

            if (ucMuhasebeGenel1.MySozlesmeFoyMuhasebe != null)
                ucMuhasebeGenel1.MySozlesmeFoyMuhasebe.Clear();

            if (ucMuhasebeGenel1.MyPersonelCariHesapDetayli != null)
                ucMuhasebeGenel1.MyPersonelCariHesapDetayli.Dispose();

            if (ucMuhasebeGenel1.MyFaturaView != null)
                ucMuhasebeGenel1.MyFaturaView.Dispose();

            if (ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli != null)
                ucMuhasebeGenel1.MyFoyMuhasebeBirlesikDetayli.Dispose();

            if (ucMuhasebeGenel1.MyKasaView != null)
                ucMuhasebeGenel1.MyKasaView.Dispose();

            if (ucMuhasebeGenel1.MyMasrafAvansDetayli != null)
                ucMuhasebeGenel1.MyMasrafAvansDetayli.Dispose();

            if (ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli != null)
                ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli.Dispose();

            if (ucMuhasebeGenel1.MyPersonelCariHesapDetayli != null)
                ucMuhasebeGenel1.MyPersonelCariHesapDetayli.Dispose();
        }
    }
}