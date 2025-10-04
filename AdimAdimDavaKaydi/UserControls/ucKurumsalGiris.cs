//#define tmpTOTALOZEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Hesap.Views;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKurumsalGiris : XtraUserControl
    {
        public ucKurumsalGiris()
        {
            InitializeComponent();
            this.Load += ucKurumsalGiris_Load;

            txtEsasNo.TextChanged += txtEsasNo_TextChanged;
            lueAdliye.EditValueChanged += lueAdliye_EditValueChanged;
            lueAdliyeNo.EditValueChanged += lueAdliyeNo_EditValueChanged;
            lueAdliyeGorev.EditValueChanged += lueAdliyeGorev_EditValueChanged;

            dateTarihi.EditValueChanged += dateTarihi_EditValueChanged;

            txtRef1.TextChanged += txtRef1_TextChanged;
            txtRef2.TextChanged += txtRef2_TextChanged;
            txtRef3.TextChanged += txtRef3_TextChanged;
            lueDurum.EditValueChanged += txtDurum_TextChanged;
            txtOzelKod1.TextChanged += txtOzelKod1_TextChanged;
            txtOzelKod2.TextChanged += txtOzelKod2_TextChanged;
            txtOzelKod3.TextChanged += txtOzelKod3_TextChanged;
            txtOzelKod4.TextChanged += txtOzelKod4_TextChanged;
            lueSorumluAdi.EditValueChanged += lueSorumluAdi_EditValueChanged;
            lueBanka.EditValueChanged += lueBanka_EditValueChanged;
            lueDosyaninYeri.EditValueChanged += lueDosyaninYeri_EditValueChanged;
            txtSubeKodu.TextChanged += txtSubeKodu_TextChanged;
            txtKonu.TextChanged += txtKonu_TextChanged;
            txtKlasor1.TextChanged += txtKlasor1_TextChanged;
            txtKlasor2.TextChanged += txtKlasor2_TextChanged;
            lueSube.EditValueChanged += lueSube_EditValueChanged;
            lueTahsilatDurumu.EditValueChanged += lueTahsilatDurumu_EditValueChanged;
            lueDosyaBirim.EditValueChanged += lueDosyaBirim_EditValueChanged;
            lueKrediGurubu.EditValueChanged += lueKrediGurubu_EditValueChanged;

            barManager1.ItemClick += barManager1_ItemClick;
            simpleButton1.Click += btnTemizle_Click;

            bwYukle.DoWork += bwYukle_DoWork;
            bwYukle.RunWorkerCompleted += bwYukle_RunWorkerCompleted;
        }

        public void MsgKayitBulunamadi()
        {
            XtraMessageBox.Show("Kayıda Adit Föy Bulunamadı", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        #region Events

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Caption == "Takip Ekranı")
                if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                {
                    ProjeBirlesikTakiplerTumu secim = e.Item.Tag as ProjeBirlesikTakiplerTumu;

                    switch (secim.Tipi)
                    {
                        case "Icra":

                            if (!secim.ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }

                            AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmIcra =
                                new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                            AV001_TI_BIL_FOY icraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(secim.ID.Value);
                            TList<AV001_TI_BIL_FOY> icraFoyListesi = new TList<AV001_TI_BIL_FOY>();
                            icraFoyListesi.Add(icraFoy);
                            frmIcra.Show(icraFoyListesi);
                            break;
                        case "Dava":

                            if (!secim.ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }
                            AV001_TD_BIL_FOY davaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(secim.ID.Value);
                            TList<AV001_TD_BIL_FOY> davaFoyListesi = new TList<AV001_TD_BIL_FOY>();
                            davaFoyListesi.Add(davaFoy);
                            AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmDava =
                                new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                            frmDava.Show(davaFoyListesi);
                            break;
                        case "Soruşturma":
                            if (!secim.ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }
                            AV001_TD_BIL_HAZIRLIK hazirlik =
                                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(secim.ID.Value);
                            TList<AV001_TD_BIL_HAZIRLIK> hazirlikListesi = new TList<AV001_TD_BIL_HAZIRLIK>();
                            hazirlikListesi.Add(hazirlik);
                            AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmSorusturma =
                                new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                            frmSorusturma.Show(hazirlikListesi);
                            break;
                        default:
                            XtraMessageBox.Show(string.Format("{0} Takip Ekranına Gönderme Yapım Aşamasında", secim.Tipi));
                            break;
                    }
                }
        }

        private void txtKonu_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colTakip_Konusu);
        }

        private void lueSorumluAdi_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colSorumlu_Adi);
        }

        private void txtOzelKod4_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colOzel_Kod4);
        }

        private void lueKrediGurubu_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colKREDI_GRUP_ID);
        }

        private void lueDosyaBirim_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colFOY_BIRIM_ID);
        }

        private void lueTahsilatDurumu_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colTAHSILAT_DURUM_ID);
        }

        private void lueSube_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colSUBE_ID);
        }

        private void txtKlasor2_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colKLASOR_2);
        }

        private void txtKlasor1_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colKLASOR_1);
        }

        private void txtSubeKodu_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colSUBE_KODU);
        }

        private void lueDosyaninYeri_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colFOY_YERI_ID);
        }

        private void lueBanka_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colBANKA_ID);
        }

        private void txtOzelKod3_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colOzel_Kod3);
        }

        private void txtOzelKod2_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colOzel_Kod2);
        }

        private void txtOzelKod1_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colOzel_Kod1);
        }

        private void txtDurum_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colDurum);
        }

        private void txtRef3_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colReferans3);
        }

        private void txtRef2_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colReferans2);
        }

        private void txtRef1_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colReferans1);
        }

        private void dateTarihi_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colTakip_T);
        }

        private void lueAdliyeGorev_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colGorev);
        }

        private void lueAdliyeNo_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colNo);
        }

        private void lueAdliye_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colAdliye);
        }

        private void txtEsasNo_TextChanged(object sender, EventArgs e)
        {
            FilitreUygulaByTextEdit(sender, colEsas_No);
        }

        private void glueAdi_EditValueChanged(object sender, EventArgs e)
        {
            FilitreUygulaByLookUp(sender, colTaraf_Adi);

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ControlCleaner(navBarGroupControlContainer1.Controls);
            ControlCleaner(navBarGroupControlContainer3.Controls);

            gwKurumsalGiris.ActiveFilter.Clear();

            FilitreSozlugu.Clear();
        }

        private void ControlCleaner(ControlCollection collection)
        {
            foreach (Control con in collection)
            {
                if (con is ExtendedLookUpEdit)
                {
                    (con as ExtendedLookUpEdit).EditValue = null;
                }
                else if (con is DateEdit)
                {
                    (con as DateEdit).EditValue = null;
                }
                else if (con is TextEdit)
                {
                    con.Text = string.Empty;
                }
                else if (con is PanelControl)
                {
                    ControlCleaner((con as PanelControl).Controls);
                }
            }
        }

        private void lueSorumluAdi_Properties_ButtonClick(object sender,
                                                          DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                ((LookUpEdit)sender).EditValue = null;
            }
        }

        public void SagTusaEkle()
        {
            gcKurumsalGiris.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcKurumsalGiris.RightClickPopup.LinkPersist.Add(var);
            }
        }

        private void ucKurumsalGiris_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            gcKurumsalGiris.ButtonCevirClick += gcKurumsalGiris_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gcKurumsalGiris_ButtonCevirClick;

            #region EskiGridden KALANLAR

            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(lueAdliyeGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(lueAdliyeNo);
            //lueKonu;
            BelgeUtil.Inits.SorumluAvukatGetir(lueSorumluAdi);
            BelgeUtil.Inits.BankaGetir(lueBanka);
            glueAdi.Properties.NullText = "Seç";
            glueAdi.Enter += delegate { BelgeUtil.Inits.perCariGetirKimlikIletisim(glueAdi); };
            BelgeUtil.Inits.BankaSubeGetir(lueSube);
            BelgeUtil.Inits.KrediGrubu(lueKrediGurubu);
            BelgeUtil.Inits.KrediTipiGetir(lueKrediTipi);

            #endregion

            BelgeUtil.Inits.BankaGetir(rLueBankaID);
            BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueDosyaYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.perCariGetir(rLueTarafcAri);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.FoyDurumGetir(lueDurum);

            SagTusaEkle();

            gcKurumsalGiris.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gcKurumsalGiris.RightClickPopup.PopupOpening += PopupOpenning_Event;

            if (Acilis == AcilisModu.Genel)
            {
                gwKurumsalGiris.Columns.Remove(gwKurumsalGiris.Columns.ColumnByFieldName("PROJE_ADI"));
                gwKurumsalGiris.Columns.Remove(gwKurumsalGiris.Columns.ColumnByFieldName("PROJE_KOD"));
                gwKurumsalGiris.Columns.Remove(gwKurumsalGiris.Columns.ColumnByFieldName("YETKILI_CARI_ADI"));
                gwKurumsalGiris.Columns.Remove(gwKurumsalGiris.Columns.ColumnByFieldName("SUBE"));
                gwKurumsalGiris.Columns.Remove(gwKurumsalGiris.Columns.ColumnByFieldName("PROJE_DURUM"));
            }
        }

        private AcilisModu _Acilis = AcilisModu.Genel;

        [Browsable(false)]
        public AcilisModu Acilis
        {
            get { return _Acilis; }
            set { _Acilis = value; }
        }

        public enum AcilisModu
        {
            Genel,
            Envanter
        }

        private void PopupOpenning_Event(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Taraf_Adi" || e.Column.FieldName == "Sorumlu_Adi")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kişinin");
                bus.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.Client_2_22x22;
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve İletişim Bilgileri");
                BarButtonItem barBtnCariRapor = new BarButtonItem(e.Manager, "Bu Şahsın Raporuna Git");
                bus.ItemLinks.Add(barBtnSecimiKaldir);
                bus.ItemLinks.Add(barBtnCariRapor);

                ProjeBirlesikTakiplerTumu secim = e.Rows as ProjeBirlesikTakiplerTumu;
                if (secim != null)
                {
                    int? id = secim.Taraf_Adi.Value;
                    if (id.HasValue)
                    {
                        barBtnSecimiKaldir.Tag = id.Value;
                        barBtnCariRapor.Tag = id.Value;
                    }

                    barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                    barBtnCariRapor.ItemClick += barBtnCariRapor_ItemClick;
                    e.MyPopupMenu.ItemLinks.Add(bus);
                }
            }
            BarButtonItem bus4 = new BarButtonItem(e.Manager, "Klasörünü Aç");
            bus4.Tag = e.Rows;
            bus4.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dosya_ac_22x22;
            bus4.Name = "bButtonKlasorAc";
            BarButtonItem bus5 = new BarButtonItem(e.Manager, "Takip Ekranına Gönder");
            bus5.Tag = e.Rows;
            bus5.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.gonder16x16;
            bus5.Name = "bButtonTakipGonder";
            e.MyPopupMenu.AddItem(bus4);
            e.MyPopupMenu.AddItem(bus5);
        }

        private void barBtnCariRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm cariForms =
                    new AdimAdimDavaKaydi.CariTakipForms.Forms.frmCariTakipForm();
                cariForms.Show(cari);
            }
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //BarButtonItem item = e.Item as BarButtonItem;

            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                //cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    //frmSorusturma.MdiParent = null;
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    //frmicraDosyaKayit.MdiParent = null;
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    // frmsozlesmeKayit.MdiParent = null;
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    //frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }
                #region Belge

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;

                        string tablo = string.Empty;
                        bool islemYap = true;

                        switch (takip.Tipi)
                        {
                            case "Icra":
                                tablo = "AV001_TI_BIL_FOY";
                                break;
                            case "Dava":
                                tablo = "AV001_TD_BIL_FOY";
                                break;
                            case "Tebligat":
                                tablo = "AV001_TDI_BIL_TEBLIGAT";
                                break;
                            case "Sorusturma":
                                tablo = "AV001_TD_BIL_HAZIRLIK";
                                break;
                            case "Sözleşme":
                                tablo = "AV001_TDI_BIL_SOZLESME";
                                break;
                            default:
                                islemYap = false;
                                break;
                        }

                        if (islemYap)
                        {
                            if (takip.ID.HasValue)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablo, takip.ID.Value);
                                // belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }
                #endregion

                #region Is Hatırlatma Ekle

                else if (e.Item.Name == bButonIsEkle.Name || e.Item.Name == bButonHatirlatmaEkle.Name)
                {
                    string tablo = string.Empty;
                    bool islemYap = true;
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                        if (takip.ID.HasValue && islemYap)
                        {
                            switch (takip.Tipi)
                            {
                                case "Icra":
                                    tablo = "AV001_TI_BIL_FOY";
                                    break;
                                case "Dava":
                                    tablo = "AV001_TD_BIL_FOY";
                                    break;
                                case "Tebligat":
                                    tablo = "AV001_TDI_BIL_TEBLIGAT";
                                    break;
                                case "Sorusturma":
                                    tablo = "AV001_TD_BIL_HAZIRLIK";
                                    break;
                                case "Sözleşme":
                                    tablo = "AV001_TDI_BIL_SOZLESME";
                                    break;
                                default:
                                    islemYap = false;
                                    break;
                            }
                            AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                                new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                            frmisKayit.SetByTableNameAndId(tablo, takip.ID.Value);
                            //frmisKayit.MdiParent = null;
                            frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frmisKayit.Show();
                        }
                    }
                }
                #endregion

                #region not Ekle

                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    string tablo = string.Empty;
                    bool islemYap = true;
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                        if (takip.ID.HasValue && islemYap)
                        {
                            switch (takip.Tipi)
                            {
                                case "Icra":
                                    tablo = "AV001_TI_BIL_FOY";
                                    break;
                                case "Dava":
                                    tablo = "AV001_TD_BIL_FOY";
                                    break;
                                case "Tebligat":
                                    tablo = "AV001_TDI_BIL_TEBLIGAT";
                                    break;
                                case "Sorusturma":
                                    tablo = "AV001_TD_BIL_HAZIRLIK";
                                    break;
                                case "Sözleşme":
                                    tablo = "AV001_TDI_BIL_SOZLESME";
                                    break;
                                default:
                                    islemYap = false;
                                    break;
                            }
                            if (!islemYap)
                                return;
                            //AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                            //AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                            //d.ShowDialog(tablo, takip.ID.Value);

                            //frmisKayit.SetByTableNameAndId(tablo, takip.ID.Value);
                            //frmisKayit.ShowDialog();
                        }
                    }
                }
                #endregion

                #region Klasor Aç

                else if (e.Item.Name == "bButtonKlasorAc")
                {
                    ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                    if (takip.ID.HasValue)
                    {
                        switch (takip.Tipi)
                        {
                            case "Icra":
                                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(takip.ID.Value);
                                TList<AV001_TDIE_BIL_PROJE_ICRA_FOY> icra =
                                    DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(foy.ID);
                                if (icra.Count > 0)
                                {
                                    AV001_TDIE_BIL_PROJE proj =
                                        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(icra[0].PROJE_ID);
                                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                    seciliKayitler.Add(proj);
                                    frmKlasorYeni kg = new frmKlasorYeni();
                                    // kg.MdiParent = null;
                                    kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                    kg.Show(seciliKayitler);
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                                }
                                break;
                            case "Dava":
                                AV001_TD_BIL_FOY foyd = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(takip.ID.Value);
                                TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> dava =
                                    DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(foyd.ID);
                                if (dava.Count > 0)
                                {
                                    AV001_TDIE_BIL_PROJE proj =
                                        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(dava[0].PROJE_ID);
                                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                    seciliKayitler.Add(proj);
                                    frmKlasorYeni kg = new frmKlasorYeni();
                                    //kg.MdiParent = null;
                                    kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                    kg.Show(seciliKayitler);
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                                }
                                break;
                            case "Tebligat":
                                AV001_TDI_BIL_TEBLIGAT foyt =
                                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(takip.ID.Value);
                                TList<AV001_TDIE_BIL_PROJE_TEBLIGAT> tebl =
                                    DataRepository.AV001_TDIE_BIL_PROJE_TEBLIGATProvider.GetByTEBLIGAT_ID(foyt.ID);
                                if (tebl.Count > 0)
                                {
                                    AV001_TDIE_BIL_PROJE proj =
                                        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(tebl[0].PROJE_ID);
                                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                    seciliKayitler.Add(proj);
                                    frmKlasorYeni kg = new frmKlasorYeni();
                                    //kg.MdiParent = null;
                                    kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                    kg.Show(seciliKayitler);
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                                }
                                break;
                            case "Sorusturma":
                                AV001_TD_BIL_HAZIRLIK foyh =
                                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(takip.ID.Value);
                                TList<AV001_TDIE_BIL_PROJE_HAZIRLIK> sors =
                                    DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(foyh.ID);
                                if (sors.Count > 0)
                                {
                                    AV001_TDIE_BIL_PROJE proj =
                                        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(sors[0].PROJE_ID);
                                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                    seciliKayitler.Add(proj);
                                    frmKlasorYeni kg = new frmKlasorYeni();
                                    //kg.MdiParent = null;
                                    kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                    kg.Show(seciliKayitler);
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                                }
                                break;
                            case "Sözleşme":
                                AV001_TDI_BIL_SOZLESME foyS =
                                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID.Value);
                                TList<AV001_TDIE_BIL_PROJE_SOZLESME> sozles =
                                    DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetBySOZLESME_ID(foyS.ID);
                                if (sozles.Count > 0)
                                {
                                    AV001_TDIE_BIL_PROJE proj =
                                        DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(sozles[0].PROJE_ID);
                                    TList<AV001_TDIE_BIL_PROJE> seciliKayitler = new TList<AV001_TDIE_BIL_PROJE>();
                                    seciliKayitler.Add(proj);
                                    frmKlasorYeni kg = new frmKlasorYeni();
                                    //kg.MdiParent = null;
                                    kg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                    kg.Show(seciliKayitler);
                                }
                                else
                                {
                                    XtraMessageBox.Show("Bu Dosyaya Ait Klasör Kaydı Bulunmamaktadır", "Uyarı");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                #endregion

                #region Takibe Gonder

                else if (e.Item.Name == "bButtonTakipGonder")
                {
                    ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                    if (takip.ID != 0)
                    {
                        switch (takip.Tipi)
                        {
                            case "Icra":
                                AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(takip.ID.Value);
                                TList<AV001_TI_BIL_FOY> seciliIKayitler = new TList<AV001_TI_BIL_FOY>();
                                seciliIKayitler.Add(foy);
                                _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                                frmicraTakip.Show(seciliIKayitler);
                                break;
                            case "Dava":
                                AV001_TD_BIL_FOY foyd = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(takip.ID.Value);
                                TList<AV001_TD_BIL_FOY> seciliDKayitler = new TList<AV001_TD_BIL_FOY>();
                                seciliDKayitler.Add(foyd);
                                frmDavaTakip frmdavaTakip = new frmDavaTakip();
                                frmdavaTakip.Show(seciliDKayitler);
                                break;
                            case "Tebligat":
                                return;

                            case "Sorusturma":
                                AV001_TD_BIL_HAZIRLIK foyh =
                                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(takip.ID.Value);
                                TList<AV001_TD_BIL_HAZIRLIK> seciliHKayitler = new TList<AV001_TD_BIL_HAZIRLIK>();
                                seciliHKayitler.Add(foyh);
                                rFrmSorusturmaTakip frmhazirlikTakip = new rFrmSorusturmaTakip();
                                frmhazirlikTakip.Show(seciliHKayitler);
                                break;
                            case "Sözleşme":
                                AV001_TDI_BIL_SOZLESME foyS =
                                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID.Value);
                                frmSozlesmeTakip frmhsozlesmeTakip = new frmSozlesmeTakip();
                                frmhsozlesmeTakip.Show(foyS.ID);
                                break;
                            default:
                                break;
                        }
                    }

                    if (e.Item.Tag is AvukatProLib.Arama.AV001_TD_BIL_FOY)
                    {
                    }
                }
                #endregion

                #region Görüşme Ekle

                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    AvukatProLib.Extras.ModulTip tablo =
                        AvukatProLib.Extras.ModulTip.Dava;
                    bool islemYap = true;
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                        if (takip.ID.HasValue && islemYap)
                        {
                            switch (takip.Tipi)
                            {
                                case "Icra":
                                    tablo = AvukatProLib.Extras.ModulTip.Icra;
                                    break;
                                case "Dava":
                                    tablo = AvukatProLib.Extras.ModulTip.Dava;
                                    break;
                                case "Tebligat":
                                    tablo = AvukatProLib.Extras.ModulTip.Tebligat;
                                    break;
                                case "Sorusturma":
                                    tablo = AvukatProLib.Extras.ModulTip.Sorusturma;
                                    break;
                                case "Sözleşme":
                                    tablo = AvukatProLib.Extras.ModulTip.Sozlesme;
                                    break;
                                default:
                                    islemYap = false;
                                    break;
                            }
                            if (!islemYap)
                                return;

                            AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                                new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                            gorsumeForms.ShowDialog(tablo, takip.ID.Value);
                        }
                    }
                }
                #endregion

                #region Kısayol Ekle

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;

                        if (takip.ID.HasValue)
                        {
                            string dosyaUzantisi = string.Empty;

                            #region <KA-20090709>

                            //Kisayol oluşturma tek bir yere çekildi dağınıklık giderildi.

                            #endregion </KA-20090709>

                            switch (takip.Tipi)
                            {
                                case "Icra":
                                    Kisayol.CreateShortCut(takip.ID.Value, Kisayol.AcilisSekli.IcraTakip);
                                    break;
                                case "Dava":
                                    Kisayol.CreateShortCut(takip.ID.Value, Kisayol.AcilisSekli.DavaTakip);
                                    break;
                                case "Tebligat":
                                    Kisayol.CreateShortCut(takip.ID.Value, Kisayol.AcilisSekli.Tebligat);
                                    break;
                                case "Sorusturma":
                                    Kisayol.CreateShortCut(takip.ID.Value, Kisayol.AcilisSekli.SorusturmaTakip);
                                    break;
                                case "Sözleşme":
                                    Kisayol.CreateShortCut(takip.ID.Value, Kisayol.AcilisSekli.SozlesmeTakip);
                                    break;
                                default:
                                    break;
                            }
                            //string kaydedilecek = takip.ID.Value.ToString();

                            //SaveFileDialog sfd = new SaveFileDialog();
                            //sfd.Filter = dosyaUzantisi;

                            //DialogResult sonuc = sfd.ShowDialog();
                            //if (sonuc == DialogResult.OK)
                            //{

                            //    try
                            //    {
                            //        byte[] veri = System.Text.Encoding.UTF8.GetBytes(kaydedilecek);

                            //        Tools.SaveTofile(sfd.FileName, veri);
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        BelgeUtil.ErrorHandler.Catch(this, ex);
                            //    }
                            //}
                        }
                    }
                }
                #endregion

                else if (e.Item.Name == bBSahisEkle.Name)
                {
                    frmCariGenelGiris cg = new frmCariGenelGiris();
                    //cg.MdiParent = null;
                    cg.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cg.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tk = new frmTemsilKayit();
                    //tk.MdiParent = null;
                    tk.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tk.Show();
                }

                #region Sikkullanilan

                else if (e.Item.Name == bButtonSikKullanilanlar.Name)
                {
                    AvukatProLib.Extras.ModulTip tablo =
                        AvukatProLib.Extras.ModulTip.Dava;
                    bool islemYap = true;
                    string AD = string.Empty;
                    if (e.Item.Tag is ProjeBirlesikTakiplerTumu)
                    {
                        ProjeBirlesikTakiplerTumu takip = e.Item.Tag as ProjeBirlesikTakiplerTumu;
                        if (takip.ID.HasValue && islemYap)
                        {
                            switch (takip.Tipi)
                            {
                                case "Icra":
                                    tablo = AvukatProLib.Extras.ModulTip.Icra;
                                    AD = string.Format("{0} {1} {2} {3}E. nolu Dosyası", takip.Adliye, takip.Gorev,
                                                       takip.No, takip.Esas_No);
                                    break;
                                case "Dava":
                                    tablo = AvukatProLib.Extras.ModulTip.Dava;
                                    AD = string.Format("{0} {1} {2} {3}E. nolu Dosyası", takip.Adliye, takip.Gorev,
                                                       takip.No, takip.Esas_No);
                                    break;
                                case "Tebligat":
                                    tablo = AvukatProLib.Extras.ModulTip.Tebligat;
                                    AD = string.Format("{0} {1} {2} {3}E. nolu Dosyası", takip.Adliye, takip.Gorev,
                                                       takip.No, takip.Esas_No);
                                    break;
                                case "Sorusturma":
                                    tablo = AvukatProLib.Extras.ModulTip.Sorusturma;
                                    AD = string.Format("{0} {1} {2} {3}E. nolu Dosyası", takip.Adliye, takip.Gorev,
                                                       takip.No, takip.Esas_No);
                                    break;
                                case "Sözleşme":
                                    tablo = AvukatProLib.Extras.ModulTip.Sozlesme;
                                    AV001_TDI_BIL_SOZLESME soz =
                                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takip.ID.Value);
                                    AD = string.Format("{0} {1} E. nolu Dosyası", soz.BASLANGIC_TARIHI, soz.SOZLESME_ADI);
                                    break;
                                default:
                                    islemYap = false;
                                    break;
                            }
                            if (!islemYap)
                                return;
                            Forms.rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();

                            //frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show(tablo, takip.ID.Value, AD);
                        }
                    }
                }

                #endregion

                #region Kapalı

                //}
                //switch (e.Item.Name)
                //{
                //    case bBtnSorusturmaEkle.Name:
                //        AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma = new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                //        frmSorusturma.ShowDialog();
                //        break;
                //    case bBtnIcraEkle.Name:
                //        AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit = new AdimAdimDavaKaydi.Forms.Icra();
                //        frmicraDosyaKayit.ShowDialog();
                //        break; 
                //    case bBtnSozlesmeEkle.Name :
                //        AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit = new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                //        frmicraDosyaKayit.ShowDialog();
                //        break; 
                //    case bBtnDavaEkle.Name :
                //        AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                //        frmdavaDosyaKayit.ShowDialog(); 
                //        break; 

                //    default:
                //        break;
                //}

                #endregion
            }
        }

        private void gcKurumsalGiris_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcKurumsalGiris.Visible)
            {
                gcKurumsalGiris.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                gcKurumsalGiris.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        #endregion

        #region Methots

        private void FilitreUygulaByTextEdit(object sender, GridColumn kolon)
        {
            try
            {
                if (((TextEdit)sender).Text != string.Empty)
                {
                    string filitre = string.Format("[{0}] Like '{1}%'", kolon.FieldName, ((TextEdit)sender).Text);

                    FilitreUygula(kolon, filitre);
                }
                else if (((TextEdit)sender).Text == string.Empty)
                {
                    FilitreUygula(kolon, string.Empty);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(sender, ex);
            }
        }

        internal void FilitreUygula()
        {
            gwKurumsalGiris.ActiveFilter.Clear();
            foreach (KeyValuePair<GridColumn, string> teki in FilitreSozlugu)
            {
                gwKurumsalGiris.ActiveFilter.Add(teki.Key, new ColumnFilterInfo(teki.Value));
            }
        }

        internal void FilitreUygula(GridColumn kolon, string filitre)
        {
            if (filitre == string.Empty)
            {
                if (FilitreSozlugu.ContainsKey(kolon))
                {
                    FilitreSozlugu.Remove(kolon);
                }
            }
            else
            {
                if (FilitreSozlugu.ContainsKey(kolon))
                {
                    FilitreSozlugu[kolon] = filitre;
                }
                else
                {
                    FilitreSozlugu.Add(kolon, filitre);
                }
            }
            FilitreUygula();
        }

        private void FilitreUygulaByLookUp(object sender, GridColumn kolon)
        {
            try
            {
                if (sender is LookUpEdit && ((LookUpEdit)sender).EditValue == null)
                {
                    FilitreUygula(kolon, string.Empty);
                    return;
                }
                else if (sender is GridLookUpEdit && ((GridLookUpEdit)sender).EditValue == null)
                {
                    FilitreUygula(kolon, string.Empty);
                    return;
                }
                else
                {
                    string filitre = "";

                    if (sender is GridLookUpEdit)
                        filitre = string.Format("[{0}] = {1}", kolon.FieldName, ((GridLookUpEdit)sender).EditValue);
                    else
                        filitre = string.Format("[{0}] = {1}", kolon.FieldName, ((LookUpEdit)sender).EditValue);

                    FilitreUygula(kolon, filitre);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(sender, ex);
            }
        }

        #endregion

        #region Property

        private Dictionary<GridColumn, string> FilitreSozlugu = new Dictionary<GridColumn, string>();

        public List<ProjeBirlesikTakiplerTumu> MyDataSource
        {
            get
            {
                if (gcKurumsalGiris.DataSource is List<ProjeBirlesikTakiplerTumu>)
                    return (List<ProjeBirlesikTakiplerTumu>)gcKurumsalGiris.DataSource;
                return null;
            }
            set
            {
                gcKurumsalGiris.DataSource = value;
#if tmpTOTALOZEL
                if (value != null && AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI != "MERKEZ")
                {
                    value.Filter = "Referans2 = '" + AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI + "'";
                }
#endif
            }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl MyRibbonControl { get; set; }

        #endregion

        public void DoShowMenu(GridHitInfo hi)
        {
            if (hi.HitTest == GridHitTest.RowCell)
            {
                GridView view = gcKurumsalGiris.FocusedView as GridView;

                popupMenu1.ItemLinks.Clear();
                AvukatProLib.Hesap.Views.ProjeBirlesikTakiplerTumu secilenKayit =
                    view.GetRow(hi.RowHandle) as ProjeBirlesikTakiplerTumu;

                DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem(barManager1,
                                                                                               "Takip Ekranı");
                item.Tag = secilenKayit;
                popupMenu1.ItemLinks.Add(item);

                popupMenu1.ShowPopup(gcKurumsalGiris.PointToScreen(hi.HitPoint));
            }
        }

        private BackgroundWorker bwYukle = new BackgroundWorker();

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!bwYukle.IsBusy)
                bwYukle.RunWorkerAsync();
        }

        private void bwYukle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is List<ProjeBirlesikTakiplerTumu>)
            {
                MyDataSource = e.Result as List<ProjeBirlesikTakiplerTumu>;
            }
        }

        private void bwYukle_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ProjeBirlesikTakiplerTumu> MyData = ProjeBirlesikTakiplerTumu.GetAll();

            if (Acilis == AdimAdimDavaKaydi.UserControls.ucKurumsalGiris.AcilisModu.Genel)
            {
                e.Result = MyData;
            }
            else
                e.Result = MyData.Where(vi => vi.Tipi != "Sözleşme").ToList();
        }

        private void gcKurumsalGiris_DoubleClick(object sender, EventArgs e)
        {
            if (gwKurumsalGiris.FocusedRowHandle >= 0)
            {
                //ProjeBirlesikTakiplerTumu secim = MyDataSource[gwKurumsalGiris.FocusedRowHandle];

                switch (gwKurumsalGiris.GetFocusedRowCellValue("Tipi").ToString())
                {
                    case "Icra":

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == null)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == DBNull.Value)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmIcra =
                            new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                        AV001_TI_BIL_FOY icraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Convert.ToInt32(gwKurumsalGiris.GetFocusedRowCellValue("ID")));
                        TList<AV001_TI_BIL_FOY> icraFoyListesi = new TList<AV001_TI_BIL_FOY>();
                        icraFoyListesi.Add(icraFoy);
                        frmIcra.Show(icraFoyListesi);
                        break;
                    case "Dava":

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == null)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == DBNull.Value)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        AV001_TD_BIL_FOY davaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(Convert.ToInt32(gwKurumsalGiris.GetFocusedRowCellValue("ID")));
                        //TList<AV001_TD_BIL_FOY> davaFoyListesi = new TList<AV001_TD_BIL_FOY>();
                        //davaFoyListesi.Add(davaFoy);
                        AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmDava = new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                        //frmDava.Show(davaFoyListesi);
                        frmDava.MyFoy = davaFoy;
                        frmDava.Show(davaFoy);
                        break;
                    case "Soruşturma":
                    case "Sorusturma":

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == null)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == DBNull.Value)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }

                        AV001_TD_BIL_HAZIRLIK hazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(Convert.ToInt32(gwKurumsalGiris.GetFocusedRowCellValue("ID")));
                        TList<AV001_TD_BIL_HAZIRLIK> hazirlikListesi = new TList<AV001_TD_BIL_HAZIRLIK>();
                        hazirlikListesi.Add(hazirlik);
                        AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmSorusturma =
                            new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                        frmSorusturma.Show(hazirlikListesi);
                        break;
                    case "Sozlesme":
                    case "Sözleşme":
                    case "Sozleşme":
                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == null)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }
                        if (gwKurumsalGiris.GetFocusedRowCellValue("ID") == DBNull.Value)
                        {
                            MsgKayitBulunamadi();
                            break;
                        }
                        
                        frmSozlesmeTakip frm = new frmSozlesmeTakip();
                        frm.Show(Convert.ToInt32(gwKurumsalGiris.GetFocusedRowCellValue("ID")));
                        break;
                    case "Belge":

                        break;
                    default:
                        XtraMessageBox.Show(string.Format("{0} Takip Ekranına Gönderme Yapım Aşamasında", gwKurumsalGiris.GetFocusedRowCellValue("Tipi").ToString()));
                        break;
                }
            }
        }
    }
}