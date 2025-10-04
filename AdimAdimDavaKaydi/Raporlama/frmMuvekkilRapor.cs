using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AvukatPro.Services.Messaging;
using AvukatProLib2.Entities;
using System.Threading;
using AvukatProLib2.Data;
using AvukatProLib.Hesap;
using AvukatProLib;
using System.Data;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.Raporlama
{
    public partial class frmMuvekkilRapor : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private GetMuvekkilHesapByFiltreRequest _request;
        private AV001_TI_BIL_FOY _selectedFoy;

        public frmMuvekkilRapor()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public AV001_TI_BIL_FOY SelectedFoy
        {
            get { return _selectedFoy; }
            set
            {
                _selectedFoy = value;
                if (_selectedFoy != null)
                    BindFoy(TabCMuvekkilHesabi.SelectedTabPage.Name, _selectedFoy);
            }
        }

        private void BindFoy(string TabName, AV001_TI_BIL_FOY MyFoy)
        {
            switch (TabName)
            {
                case "tabDosyaOzeti":
                    ucIcraTakipMuvekkilHesabi1.MyFoy = MyFoy;
                    break;

                case "tabMuvekkilOdeme":
                    ucMuvekkilOdemeleri1.MyIcraFoy = MyFoy;
                    break;

                case "tabVekaletSozlesmesi":
                    ucIcraVekaletSozlesmesi1.MyIcraFoy = MyFoy;
                    break;

                case "tabMeslekMakbuzu":
                    ucMeslekMakbuzu1.MyIcraFoy = MyFoy;
                    break;

                case "tabMuvekkilMuhasebesi":
                    ucMuhasebeGenel1.MyMuvekkilCariHesapDetayli = AvukatPro.Services.Implementations.CariService.GetAllMuvekkilCariHesapDetayByIcraFoyId(MyFoy.ID);
                    break;
                default:
                    break;
            }
        }

        private void BindLookUps()
        {
            BindOzelKods();
            //AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueBorclu, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueMuvekkil, null);
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(lueDosyaDurum);
            AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, true);
        }

        private void BindOzelKods()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lookUpEditOzelKod1, 1, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lookUpEditOzelKod2, 2, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lookUpEditOzelKod3, 3, AvukatProLib.Extras.Modul.Icra);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lookUpEditOzelKod4, 4, AvukatProLib.Extras.Modul.Icra);
            lookUpEditOzelKod1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lookUpEditOzelKod1_ButtonClick);
            lookUpEditOzelKod2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lookUpEditOzelKod1_ButtonClick);
            lookUpEditOzelKod3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lookUpEditOzelKod1_ButtonClick);
            lookUpEditOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lookUpEditOzelKod1_ButtonClick);
        }

        List<AvukatPro.Model.EntityClasses.RMuvekkilHesapFoyTarafliEntity> hesaplar;

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("İşlem yapılıyor lütfen bekleyin...");
                return;
            }
            groupControl1.Top = (this.Height / 2) - (groupControl1.Height / 2);
            groupControl1.Left = (this.Width / 2) - (groupControl1.Width / 2);
            groupControl1.Visible = true;
            progressBarControl1.Position = 0;

            backgroundWorker1.RunWorkerAsync();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (var control in pnlfilter.Controls)
            {
                if (control.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                    (control as DevExpress.XtraEditors.LookUpEdit).EditValue = null;
                else if (control.GetType() == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
                    (control as DevExpress.XtraEditors.SearchLookUpEdit).EditValue = null;
                else if (control.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                    (control as DevExpress.XtraEditors.DateEdit).EditValue = null;
                else if (control.GetType() == typeof(DevExpress.XtraEditors.RadioGroup))
                    (control as DevExpress.XtraEditors.RadioGroup).EditValue = false;
            }

            if (lueDosya.Properties.DataSource != null)
            {
                if (lueDosya.Properties.DataSource is DataTable)
                {
                    foreach (DataRow row in (lueDosya.Properties.DataSource as DataTable).Rows)
                    {
                        row["IsSelected"] = false;
                    }
                }
                else
                {
                    foreach (var row in (lueDosya.Properties.DataSource as List<AvukatPro.Model.EntityClasses.PerAv001TiBilIcraAramaEntity>))
                    {
                        row.IsSelected = false;
                    }
                }

                lueDosya.Properties.NullText = "Seçiniz...";
            }
        }

        //private void deHesaplamaTarihi_EditValueChanged(object sender, EventArgs e)
        //{
        //    _request.HesaplanmaTarihi = (DateTime?)deHesaplamaTarihi.EditValue;
        //}

        //private void deKapamaTarihi_EditValueChanged(object sender, EventArgs e)
        //{
        //    _request.KapamaTarihi = (DateTime?)deKapamaTarihi.EditValue;
        //}

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKods();
        }

        private void frmMuvekkilRapor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            dockManager1.SaveLayoutToRegistry("DockManager\\Layouts\\MuvekkilRaporLayout");
        }

        private void frmMuvekkilRapor_Load(object sender, EventArgs e)
        {
            _request = new GetMuvekkilHesapByFiltreRequest();
            AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilHesap mhColumn = new AdimAdimDavaKaydi.UserControls.Util.Muhasebe.MuvekkilHesap();
            gvMuvekkilRapor.Columns.AddRange(mhColumn.GetHesapColumn());

            foreach (GridColumn item in gvMuvekkilRapor.Columns)
            {
                try
                {
                    if (item.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                        gvMuvekkilRapor.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, item.FieldName, item, "{0:C2}");
                }
                catch { ;}
            }



            dockManager1.RestoreLayoutFromRegistry("DockManager\\Layouts\\MuvekkilRaporLayout");
            BindLookUps();

            groupControl1.Visible = false;
        }

        private void gvMuvekkilRapor_DoubleClick(object sender, EventArgs e)
        {
            int icraFoyId = (int)(gvMuvekkilRapor.GetFocusedRow() as AvukatPro.Model.EntityClasses.RMuvekkilHesapFoyTarafliEntity).IcraFoyId;

            AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
            AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frm = new IcraTakipForms._frmIcraTakip();
            frm.Show(icraFoyId);
            AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
            frm.ucIcraHesapCetveli1.MyFoyDataSource = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(icraFoyId);
            frm.ucIcraHesapCetveli1.InitializeComponent();
            frm.ucIcraHesapCetveli1.BindData();
            frm.ucIcraHesapCetveli1.ButtonClick();
        }

        private void gvMuvekkilRapor_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle < 0 || gvMuvekkilRapor.GetRowCellValue(e.FocusedRowHandle, "IcraFoyId") == null)
            //    return;

            //SelectedFoy = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)gvMuvekkilRapor.GetRowCellValue(e.FocusedRowHandle, "IcraFoyId"));
        }

        private void lookUpEditOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        private void lookUpEditOzelKod1_EditValueChanged(object sender, EventArgs e)
        {
            _request.OzelKod1ID = (int?)lookUpEditOzelKod1.EditValue;
        }

        private void lookUpEditOzelKod2_EditValueChanged(object sender, EventArgs e)
        {
            _request.OzelKod2ID = (int?)lookUpEditOzelKod2.EditValue;
        }

        private void lookUpEditOzelKod3_EditValueChanged(object sender, EventArgs e)
        {
            _request.OzelKod3ID = (int?)lookUpEditOzelKod3.EditValue;
        }

        private void lookUpEditOzelKod4_EditValueChanged(object sender, EventArgs e)
        {
            _request.OzelKod4ID = (int?)lookUpEditOzelKod4.EditValue;
        }

        //private void lueBorclu_EditValueChanged(object sender, EventArgs e)
        //{
        //    _request.BorcluCariID = (int?)lueBorclu.EditValue;
        //}

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            _request.DosyaID = (int?)lueDosya.EditValue;
        }

        private void lueDosyaDurum_EditValueChanged(object sender, EventArgs e)
        {
            _request.DosyaDurumID = (int?)lueDosyaDurum.EditValue;
        }

        private void lueMuvekkil_EditValueChanged(object sender, EventArgs e)
        {
            _request.MuvekkilCariID = (int?)lueMuvekkil.EditValue;
        }

        private void rgFiltre_EditValueChanged(object sender, EventArgs e)
        {
            if (!(bool)rgFiltre.EditValue)
                _request.KontrolKimID = AvukatProLib.Kimlikci.Kimlik.Bilgi.ID;
            else
                _request.KontrolKimID = null;
        }

        private void TabCMuvekkilHesabi_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (SelectedFoy == null)
                return;

            BindFoy(e.Page.Name, SelectedFoy);
        }

        private void tabMuvekkilRapor_Click(object sender, EventArgs e)
        {
            pGcMuvekkilRapor.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllMuvekkilHesap();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //hesaplar = AvukatPro.Services.Implementations.DosyaService.GetMuvekkilHesapByFiltre(_request);

            string dosya = null;

            if (lueDosya.Text != "Seçiniz")
                dosya = lueDosya.Text;

            int? SorumluCariID = null;

            if (rgFiltre.SelectedIndex == 0)
                SorumluCariID = Kimlikci.Kimlik.Cari_ID;

            DataTable dt = AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_AramaSorgu.GetByFiltreView(null, null, null, null, null, null, (int?)lueMuvekkil.EditValue, SorumluCariID, null, null, null, null, null, null, null, null, null, null, null, dosya, null, null, null, (int?)lueDosyaDurum.EditValue, null, null, null, null, (int?)lookUpEditOzelKod1.EditValue, (int?)lookUpEditOzelKod2.EditValue, (int?)lookUpEditOzelKod3.EditValue, (int?)lookUpEditOzelKod4.EditValue, null, null, null, null, null, null, null, null, null, null, AvukatProLib.Kimlik.SirketBilgisi.ConStr, -1, "Tumu", -1, -1, null);

            progressBarControl1.Properties.Maximum = dt.Rows.Count;
            ABDegisken.RapordanMi = true;

            if (dt.Rows.Count > 0 && chkGuncelle.Checked)
            {
                foreach (DataRow hesap in dt.Rows)
                {
                    AV001_TI_BIL_FOY foy = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)hesap["ID"]);

                    AvukatProLib.Hesap.Hesap.Icra hesaplayıcı = new AvukatProLib.Hesap.Hesap.Icra(foy, true);

                    ucIcraTakipMuvekkilHesabi1.MyFoy = foy;

                    //if (!AvukatProLib2.Data.DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.GetByICRA_FOY_ID(foy.ID)[0].SON_HESAP_TARIHI.HasValue)
                    try
                    {
                        ucIcraTakipMuvekkilHesabi1.FaizOranlariHesapla(ucIcraTakipMuvekkilHesabi1.MyFoy, false);
                        ucIcraTakipMuvekkilHesabi1.kaydet(true);
                    }
                    catch { ;}

                    Thread.Sleep(10);
                    progressBarControl1.Position++;
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_MUVEKKIL_HESAPProvider.Update(ucIcraTakipMuvekkilHesabi1.TreeList.GetMuvekkilHesap(foy));
                }
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.ExcuteQuery("delete from AV001_TI_BIL_MUVEKKIL_HESAP where TOPLAM_SOZLESME_VEKALET_UCRETI is null");

            hesaplar = AvukatPro.Services.Implementations.DosyaService.GetMuvekkilHesapByFiltre(_request);
        }

        //public void FaizOranlariHesapla(AV001_TI_BIL_FOY foy, bool sabitDegerlerlemi)
        //{
        //    if (foy.VEKALET_SOZLESME_ID == null)
        //    {
        //        foy.VEKALET_SOZLESME_ID = 5;
        //    }

        //    AV001_TI_BIL_VEKALET_SOZLESME vekaletSozlesme = DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.GetByID((int)foy.VEKALET_SOZLESME_ID);
        //    DataRepository.AV001_TI_BIL_VEKALET_SOZLESMEProvider.DeepLoad(vekaletSozlesme, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_VEKALET_SOZLESME_DETAY>));
        //    AV001_TI_BIL_MUVEKKIL_HESAP muvekkilhesap = new AV001_TI_BIL_MUVEKKIL_HESAP();
        //    if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
        //        muvekkilhesap = foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0];

        //    if (vekaletSozlesme.SABIT_TUTAR > 0)
        //    {
        //        List<ParaVeDovizId> sabitTutarList = new List<ParaVeDovizId>();
        //        foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //        {
        //            if (item.MUHASEBE_ALT_TUR_ID == (int)AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTakipMuvekkilHesabi.TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);

        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }
        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.TAKIP_VEKALET_UCRETI = tutari;
        //            }
        //            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);

        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }

        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = tutari;
        //            }

        //            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);
        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }

        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.TD_VEKALET_UCRETI = tutari;
        //            }
        //            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);
        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }
        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = tutari;
        //            }
        //            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);
        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }
        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = tutari;
        //            }
        //            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //            {
        //                ParaVeDovizId degeri = KategoriDegeri(item, foy);
        //                decimal tutari;

        //                if (sabitDegerlerlemi)
        //                {
        //                    tutari = degeri.Para;
        //                }
        //                else
        //                {
        //                    double orani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;
        //                    tutari = degeri.Para * (decimal)orani / 100;
        //                }

        //                muvekkilhesap.DAVA_VEKALET_UCRETI = tutari;
        //            }
        //        }

        //        ParaVeDovizId sonuc = new ParaVeDovizId(vekaletSozlesme.SABIT_TUTAR, vekaletSozlesme.SABIT_TUTAR_DOVIZ_ID);
        //        sabitTutarList.Add(sonuc);
        //        var toplam = ParaVeDovizId.Topla(sabitTutarList);
        //        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //        muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //    }
        //    else
        //    {
        //        if (foy.FOY_DURUM_ID == 3)//Aciz
        //        {
        //            List<ParaVeDovizId> acizListe = new List<ParaVeDovizId>();
        //            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //            {
        //                ParaVeDovizId foyAcizDegeri = KategoriDegeri(item, foy);
        //                double acizOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                decimal acizTutari = foyAcizDegeri.Para * (decimal)acizOrani / 100;
        //                decimal acizSabitTutari = foyAcizDegeri.Para;

        //                if (sabitDegerlerlemi)
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = acizSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = acizSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = acizSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = acizSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = acizSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = acizSabitTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(acizTutari, foyAcizDegeri.DovizId);

        //                        if (acizTutari != 0 && sonuc.Para != 0)
        //                            acizListe.Add(sonuc);
        //                    }
        //                }
        //                else
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = acizTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = acizTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = acizTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = acizTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = acizTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = acizTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(acizTutari, foyAcizDegeri.DovizId);

        //                        if (acizTutari != 0 && sonuc.Para != 0)
        //                            acizListe.Add(sonuc);
        //                    }
        //                }
        //            }
        //            var toplam = ParaVeDovizId.Topla(acizListe);
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //        }
        //        else if (foy.FOY_DURUM_ID == 4)
        //        {
        //            if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue &&
        //                foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue)
        //            {
        //                if (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI <
        //                    foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI ||
        //                    (foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().DUSME_TARIHI.HasValue &&
        //                     !foy.AV001_TI_BIL_DUSME_YENILEMECollection.Last().YENILEME_TARIHI.HasValue)) //Düşme
        //                {
        //                    List<ParaVeDovizId> dusmeListe = new List<ParaVeDovizId>();

        //                    foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //                    {
        //                        ParaVeDovizId foyDusmeDegeri = KategoriDegeri(item, foy);
        //                        double dusmeOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                        decimal dusmeTutari = foyDusmeDegeri.Para * (decimal)dusmeOrani / 100;
        //                        decimal dusmeSabitTutari = foyDusmeDegeri.Para;

        //                        if (sabitDegerlerlemi)
        //                        {
        //                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.TAKIP_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.TD_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.DAVA_VEKALET_UCRETI = dusmeSabitTutari;

        //                            else
        //                            {
        //                                ParaVeDovizId sonuc = new ParaVeDovizId(dusmeTutari, foyDusmeDegeri.DovizId);
        //                                if (dusmeTutari != 0 && sonuc.Para != 0)
        //                                    dusmeListe.Add(sonuc);
        //                            }
        //                        }

        //                        else
        //                        {
        //                            if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.TAKIP_VEKALET_UCRETI = dusmeTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                                muvekkilhesap.TAHLIYE_VEKALET_UCRETI = dusmeTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.TD_VEKALET_UCRETI = dusmeTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = dusmeTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = dusmeTutari;

        //                            else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                                muvekkilhesap.DAVA_VEKALET_UCRETI = dusmeTutari;

        //                            else
        //                            {
        //                                ParaVeDovizId sonuc = new ParaVeDovizId(dusmeTutari, foyDusmeDegeri.DovizId);
        //                                if (dusmeTutari != 0 && sonuc.Para != 0)
        //                                    dusmeListe.Add(sonuc);
        //                            }
        //                        }
        //                    }
        //                    var toplam = ParaVeDovizId.Topla(dusmeListe);
        //                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //                    muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //                }
        //            }
        //        }
        //        else if (foy.FOY_DURUM_ID == 5)//Feragat
        //        {
        //            List<ParaVeDovizId> feragatListe = new List<ParaVeDovizId>();

        //            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //            {
        //                ParaVeDovizId foyFeragatDegeri = KategoriDegeri(item, foy);
        //                double feragatOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                decimal feragatTutari = foyFeragatDegeri.Para * (decimal)feragatOrani / 100;
        //                decimal feragatSabitTutari = foyFeragatDegeri.Para;

        //                if (sabitDegerlerlemi)
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = feragatSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = feragatSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = feragatSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = feragatSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = feragatSabitTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = feragatSabitTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(feragatTutari, foyFeragatDegeri.DovizId);

        //                        if (feragatTutari != 0 && sonuc.Para != 0)
        //                            feragatListe.Add(sonuc);
        //                    }
        //                }

        //                else
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = feragatTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = feragatTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = feragatTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = feragatTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = feragatTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = feragatTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(feragatTutari, foyFeragatDegeri.DovizId);

        //                        if (feragatTutari != 0 && sonuc.Para != 0)
        //                            feragatListe.Add(sonuc);
        //                    }
        //                }
        //            }

        //            var toplam = ParaVeDovizId.Topla(feragatListe);
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //        }
        //        else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count != 0)
        //        {
        //            if (foy.AV001_TI_BIL_SATIS_MASTERCollection != null && foy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)//Satış Sonrası
        //            {
        //                List<ParaVeDovizId> satisSonraiInfazListe = new List<ParaVeDovizId>();

        //                foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //                {
        //                    ParaVeDovizId foySatisSonrasiInfazDegeri = KategoriDegeri(item, foy);
        //                    double satisSonrasiFaizOrani =
        //                        SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                    decimal satisSonrasiFaizTutari = foySatisSonrasiInfazDegeri.Para *
        //                                                     (decimal)satisSonrasiFaizOrani / 100;
        //                    decimal satisSonrasiSabitFaizTutari = foySatisSonrasiInfazDegeri.Para;

        //                    if (sabitDegerlerlemi)
        //                    {
        //                        if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TAKIP_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                            muvekkilhesap.TAHLIYE_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TD_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.DAVA_VEKALET_UCRETI = satisSonrasiSabitFaizTutari;

        //                        else
        //                        {
        //                            ParaVeDovizId sonuc = new ParaVeDovizId(satisSonrasiFaizTutari,
        //                                                                    foySatisSonrasiInfazDegeri.DovizId);

        //                            if (satisSonrasiFaizTutari != 0 && sonuc.Para != 0)
        //                                satisSonraiInfazListe.Add(sonuc);
        //                        }
        //                    }

        //                    else
        //                    {
        //                        if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TAKIP_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                            muvekkilhesap.TAHLIYE_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TD_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.DAVA_VEKALET_UCRETI = satisSonrasiFaizTutari;

        //                        else
        //                        {
        //                            ParaVeDovizId sonuc = new ParaVeDovizId(satisSonrasiFaizTutari,
        //                                                                    foySatisSonrasiInfazDegeri.DovizId);

        //                            if (satisSonrasiFaizTutari != 0 && sonuc.Para != 0)
        //                                satisSonraiInfazListe.Add(sonuc);
        //                        }
        //                    }
        //                }

        //                var toplam = ParaVeDovizId.Topla(satisSonraiInfazListe);
        //                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //            }
        //            else//Satış Öncesi
        //            {
        //                List<ParaVeDovizId> satisOncesiInfazListe = new List<ParaVeDovizId>();

        //                foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //                {
        //                    ParaVeDovizId foySatisOncesiInfazDegeri = KategoriDegeri(item, foy);
        //                    double acizOrani =
        //                        SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).ACIZ;

        //                    decimal foySatisOncesiTutari = foySatisOncesiInfazDegeri.Para * (decimal)acizOrani / 100;
        //                    decimal foySatisOncesiSabitTutari = foySatisOncesiInfazDegeri.Para; ;

        //                    if (sabitDegerlerlemi)
        //                    {
        //                        if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TAKIP_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                            muvekkilhesap.TAHLIYE_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TD_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.DAVA_VEKALET_UCRETI = foySatisOncesiSabitTutari;

        //                        else
        //                        {
        //                            ParaVeDovizId sonuc = new ParaVeDovizId(foySatisOncesiTutari,
        //                                                                    foySatisOncesiInfazDegeri.DovizId);

        //                            if (foySatisOncesiTutari != 0 && sonuc.Para != 0)
        //                                satisOncesiInfazListe.Add(sonuc);
        //                        }
        //                    }

        //                    else
        //                    {
        //                        if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TAKIP_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                            muvekkilhesap.TAHLIYE_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.TD_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                            muvekkilhesap.DAVA_VEKALET_UCRETI = foySatisOncesiTutari;

        //                        else
        //                        {
        //                            ParaVeDovizId sonuc = new ParaVeDovizId(foySatisOncesiTutari,
        //                                                                    foySatisOncesiInfazDegeri.DovizId);

        //                            if (foySatisOncesiTutari != 0 && sonuc.Para != 0)
        //                                satisOncesiInfazListe.Add(sonuc);
        //                        }
        //                    }
        //                }

        //                var toplam = ParaVeDovizId.Topla(satisOncesiInfazListe);
        //                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //                muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //            }
        //        }
        //        else if (foy.AV001_TI_BIL_HACIZ_MASTERCollection.Count == 0)//Haciz Öncesi
        //        {
        //            List<ParaVeDovizId> hacizOncesiInfazListe = new List<ParaVeDovizId>();

        //            foreach (var item in vekaletSozlesme.AV001_TI_BIL_VEKALET_SOZLESME_DETAYCollection)
        //            {
        //                ParaVeDovizId foyHacizOncesiInfazDegeri = KategoriDegeri(item, foy);
        //                double hacizOncesiInfazOrani = SeciliDetayKategorisi(vekaletSozlesme.ID, item.MUHASEBE_ALT_TUR_ID.Value).HACIZ_ONCESI_INFAZ;
        //                decimal hacizOncesiInfazTutari = foyHacizOncesiInfazDegeri.Para *
        //                                                 (decimal)hacizOncesiInfazOrani / 100;
        //                decimal hacizOncesiSabitInfazTutari = foyHacizOncesiInfazDegeri.Para;

        //                if (sabitDegerlerlemi)
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = hacizOncesiSabitInfazTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(hacizOncesiInfazTutari,
        //                                                                foyHacizOncesiInfazDegeri.DovizId);

        //                        if (hacizOncesiInfazTutari != 0 && sonuc.Para != 0)
        //                            hacizOncesiInfazListe.Add(sonuc);
        //                    }
        //                }

        //                else
        //                {
        //                    if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAKİP_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TAKIP_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_VEKALET_ÜCRETI)
        //                        muvekkilhesap.TAHLIYE_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.TAHLİYE_DAVASI_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.TD_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_HACİZ_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_HACIZ_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.İHTİYATİ_TEDBİR_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.IHTIYATI_TEDBIR_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else if (item.MUHASEBE_ALT_TUR_ID == (int)TakipAlacaklariAltKategoriler.DAVA_VEKALET_ÜCRETİ)
        //                        muvekkilhesap.DAVA_VEKALET_UCRETI = hacizOncesiInfazTutari;

        //                    else
        //                    {
        //                        ParaVeDovizId sonuc = new ParaVeDovizId(hacizOncesiInfazTutari,
        //                                                                foyHacizOncesiInfazDegeri.DovizId);

        //                        if (hacizOncesiInfazTutari != 0 && sonuc.Para != 0)
        //                            hacizOncesiInfazListe.Add(sonuc);
        //                    }
        //                }
        //            }
        //            var toplam = ParaVeDovizId.Topla(hacizOncesiInfazListe);
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI = toplam.Para;
        //            muvekkilhesap.TOPLAM_SOZLESME_VEKALET_UCRETI_DOVIZ_ID = toplam.DovizId;
        //        }
        //    }
        //    if (paraIndirimMiktari.Tutar.Para > 0)
        //    {
        //        muvekkilhesap.INDIRIM_MIKTARI = paraIndirimMiktari.Tutar.Para;
        //        muvekkilhesap.INDIRIM_MIKTARI_DOVIZ_ID = paraIndirimMiktari.Tutar.DovizId;
        //    }

        //    //if (foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Count > 0)
        //    //{ muvekkilhesap.DEPO_VEKALET_UCRETI = foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection[0].DEPO_VEKALET_UCRETI; }
        //    //else
        //    //{ muvekkilhesap.DEPO_VEKALET_UCRETI = foy.DEPO_VEKALET_UCRETI; }
        //    //muvekkilhesap.DEPO_VEKALET_UCRETI_DOVIZ_ID = foy.DEPO_VEKALET_UCRET_DOVIZ_ID;
        //    BindUc(muvekkilhesap, vekaletSozlesme);
        //    bool stopajKullanılacakmı = stopajOlacakmi(MyFoy, vekaletSozlesme);

        //    //TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();
        //    //foreach (var item in foy.AV001_TI_BIL_FOY_TARAFCollection)
        //    //{
        //    //    if (item.TARAF_KODU == 1)
        //    //    {
        //    //        AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)item.CARI_ID);
        //    //        cariList.Add(cari);
        //    //    }
        //    //}

        //    //foreach (var item in cariList)
        //    //{
        //    //    if (item.VERGI_NO_KULLANIYOR_MU)
        //    //    {
        //    //        stopajKullanılacakmı = true;
        //    //        break;
        //    //    }
        //    //    else
        //    //    {
        //    //        vekaletSozlesme.STOPAJ_ICINDE_MI = false;
        //    //        stopajKullanılacakmı = false;
        //    //    }
        //    //}

        //    foy.AV001_TI_BIL_MUVEKKIL_HESAPCollection.Add(KDVHesapla(vekaletSozlesme.KDV_DAHIL, vekaletSozlesme.STOPAJ_ICINDE_MI, muvekkilhesap));
        //    BindTreeListAfterHesap(foy, stopajKullanılacakmı);
        //}

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            gcMuvekkilRapor.DataSource = hesaplar;
            gvMuvekkilRapor.Columns["TakipEdenCariId"].Group();
            groupControl1.Visible = false;
            ABDegisken.RapordanMi = false;
        }
    }
}