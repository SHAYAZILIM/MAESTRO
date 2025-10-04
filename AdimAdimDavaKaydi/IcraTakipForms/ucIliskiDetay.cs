using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public class TarafDosyalari
    {
        private List<int> _icraFoyleri;

        private TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> _iliskiler = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();

        private string _tarafAdi;

        private VList<R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU> _tumDosyalar;

        public TarafDosyalari(int tarafID)
        {
            this.TarafID = tarafID;
        }

        public List<int> IcraFoyleri
        {
            get
            {
                if (_icraFoyleri.Count < 1)
                {
                }
                return _icraFoyleri;
            }
            set { _icraFoyleri = value; }
        }

        public TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> Iliskiler
        {
            get { return _iliskiler; }
            set { _iliskiler = value; }
        }

        public string TarafAdi
        {
            get
            {
                if (_tarafAdi == null)
                {
                    AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(TarafID);
                    if (cari != null)
                    {
                        _tarafAdi = cari.AD;
                        return _tarafAdi;
                    }
                    else return _tarafAdi;
                }
                else
                    return _tarafAdi;
            }
            set { _tarafAdi = value; }
        }

        public AV001_TI_BIL_FOY_TARAF TarafHesabi { get; set; }

        public int TarafID { get; set; }

        public VList<R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU> TumDosyalar
        {
            get
            {
                if (_tumDosyalar != null)
                    return _tumDosyalar;
                else
                {
                    _tumDosyalar =
                        DataRepository.R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULUProvider.GetByTarafID(this.TarafID);
                    if (_tumDosyalar.Count > 1)
                    {
                        _tumDosyalar.Add(new R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU());
                    }
                    return _tumDosyalar;
                }
            }
            set { _tumDosyalar = value; }
        }

        public override string ToString()
        {
            return TarafAdi;
        }
    }

    public partial class ucIliskiDetay : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucIliskiDetay()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIliskiDetay_Load;
        }

        #region Events

        [Category("AlacakNeden")]

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Caption == "Takip Ekraný")
            {
                if (e.Item.Tag is R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU)
                {
                    R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU secim = e.Item.Tag as R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU;

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

                        case "Soruþturma":
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
                            XtraMessageBox.Show(string.Format("{0} Takip Ekranýna Gönderme Yapým Aþamasýnda", secim.Tipi));
                            break;
                    }
                }
                else if (e.Item.Tag is AV001_TDI_BIL_KAYIT_ILISKI_DETAY)
                {
                    AV001_TDI_BIL_KAYIT_ILISKI_DETAY secim = e.Item.Tag as AV001_TDI_BIL_KAYIT_ILISKI_DETAY;
                    switch (secim.HEDEF_TIP)
                    {
                        case 1:

                            if (!secim.HEDEF_ICRA_FOY_ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }

                            AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip frmIcra =
                                new AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip();
                            AV001_TI_BIL_FOY icraFoy =
                                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(secim.HEDEF_ICRA_FOY_ID.Value);
                            TList<AV001_TI_BIL_FOY> icraFoyListesi = new TList<AV001_TI_BIL_FOY>();
                            icraFoyListesi.Add(icraFoy);
                            frmIcra.Show(icraFoyListesi);
                            break;

                        case 2:

                            if (!secim.HEDEF_DAVA_FOY_ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }
                            AV001_TD_BIL_FOY davaFoy =
                                DataRepository.AV001_TD_BIL_FOYProvider.GetByID(secim.HEDEF_DAVA_FOY_ID.Value);
                            TList<AV001_TD_BIL_FOY> davaFoyListesi = new TList<AV001_TD_BIL_FOY>();
                            davaFoyListesi.Add(davaFoy);
                            AdimAdimDavaKaydi.DavaTakip.frmDavaTakip frmDava =
                                new AdimAdimDavaKaydi.DavaTakip.frmDavaTakip();
                            frmDava.Show(davaFoyListesi);
                            break;

                        case 3:
                            if (!secim.HEDEF_HAZIRLIK_ID.HasValue)
                            {
                                MsgKayitBulunamadi();
                                break;
                            }
                            AV001_TD_BIL_HAZIRLIK hazirlik =
                                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(secim.HEDEF_HAZIRLIK_ID.Value);
                            TList<AV001_TD_BIL_HAZIRLIK> hazirlikListesi = new TList<AV001_TD_BIL_HAZIRLIK>();
                            hazirlikListesi.Add(hazirlik);
                            AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip frmSorusturma =
                                new AdimAdimDavaKaydi.Sorusturma.Forms.rFrmSorusturmaTakip();
                            frmSorusturma.Show(hazirlikListesi);
                            break;
                        default:
                            XtraMessageBox.Show(string.Format("{0} Takip Ekranýna Gönderme Yapým Aþamasýnda",
                                                              secim.HEDEF_TIP));
                            break;
                    }
                }
            }
            else if (e.Item.Caption == "Kayýt Sil")
            {
                AV001_TDI_BIL_KAYIT_ILISKI_DETAY secim = e.Item.Tag as AV001_TDI_BIL_KAYIT_ILISKI_DETAY;

                AdimAdimDavaKaydi.Util.frmKayitSil kayitSil =
                    new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_KAYIT_ILISKI_DETAY", "ID = " + secim.ID);
                kayitSil.FormClosed += kayitSil_FormClosed;
                kayitSil.Show();
            }
            else if (e.Item.Caption == "Ýliþkili Dosya Ekle")
            {
                AdimAdimDavaKaydi.Forms.frmKayitIliski frm = new AdimAdimDavaKaydi.Forms.frmKayitIliski();
                frm.MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(FoyId);
                frm.FormClosed += kayitSil_FormClosed;
                frm.Show();
            }
        }

        private void btnDIDHesapla_Click(object sender, EventArgs e)
        {
            if (treeList1.DataSource != null)
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detaylar =
                    treeList1.DataSource as TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;

                if (detaylar.Count > 0)
                {
                    AV001_TI_BIL_FOY toplananFoy = new AV001_TI_BIL_FOY();
                    HesapYapar hy = new HesapYapar();

                    AV001_TDI_BIL_KAYIT_ILISKI_DETAY anaDetay = detaylar.Find("Tag", 1);
                    if (anaDetay != null)
                    {
                        if (anaDetay.HEDEF_ICRA_FOY_ID != null)
                        {
                            AV001_TI_BIL_FOY anaFoy = hy.IcraFoyHesaplaByID(anaDetay.HEDEF_ICRA_FOY_ID.Value);
                            List<AV001_TI_BIL_FOY> detayFoyListesi = new List<AV001_TI_BIL_FOY>();
                            foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay in detaylar)
                            {
                                if (detay.HEDEF_ICRA_FOY_ID != null)
                                    if (detay.Tag == null)
                                        detayFoyListesi.Add(hy.IcraFoyHesaplaByID(detay.HEDEF_ICRA_FOY_ID.Value));
                            }

                            hy.FoyleriToplaLimited(detayFoyListesi, anaFoy);

                            ucIcraHesapCetveli1.MyFoyDataSource = anaFoy;
                        }
                    }
                }
            }
            else if (treeList1.DataSource == null)
            {
                XtraMessageBox.Show("Tarafýn Ýliþikili Dosyasý Bulunamadý");
            }
        }

        private void btnTarafinDosyalariniHesapla_Click(object sender, EventArgs e)
        {
            TarafDosyalari td = lookUpEdit1.EditValue as TarafDosyalari;
            List<TarafDosyalari> tarafListesi = lookUpEdit1.Properties.DataSource as List<TarafDosyalari>;
            HesapYapar hy = new HesapYapar();
            if (td.Iliskiler.Count > 0)
            {
                AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay = td.Iliskiler.Find("Tag", 1);
                AV001_TI_BIL_FOY anaFoy = null;
                List<AV001_TI_BIL_FOY> foylerinListesi = new List<AV001_TI_BIL_FOY>();

                if (detay != null)
                {
                    if (detay.HEDEF_TIP == 1)
                    {
                        if (detay.HEDEF_ICRA_FOY_ID != null)
                            if (detay.HEDEF_ICRA_FOY_IDSource != null)
                            {
                                anaFoy = detay.HEDEF_ICRA_FOY_IDSource;
                            }
                            else
                            {
                                anaFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(detay.HEDEF_ICRA_FOY_ID.Value);
                            }
                    }
                }

                foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY teki in td.Iliskiler)
                {
                    if (teki.Tag == null)
                    {
                        if (teki.HEDEF_ICRA_FOY_IDSource != null)
                            foylerinListesi.Add(teki.HEDEF_ICRA_FOY_IDSource);

                        else if (teki.HEDEF_ICRA_FOY_ID != null)
                        {
                            AV001_TI_BIL_FOY eklenenFoy =
                                DataRepository.AV001_TI_BIL_FOYProvider.GetByID(teki.HEDEF_ICRA_FOY_ID.Value);
                            if (eklenenFoy != null)
                                foylerinListesi.Add(eklenenFoy);
                        }
                    }
                }
                if (foylerinListesi.Count > 0)
                {
                    foylerinListesi.Remove(anaFoy);
                    List<AV001_TI_BIL_FOY_TARAF> tarafinListesi = new List<AV001_TI_BIL_FOY_TARAF>();

                    for (int i = 0; i < foylerinListesi.Count; i++)
                    {
                        foylerinListesi[i] = hy.IcraFoyHesaplaByID(foylerinListesi[i].ID);

                        foreach (AV001_TI_BIL_FOY_TARAF tekTaraf in foylerinListesi[i].AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (tekTaraf.CARI_ID == td.TarafID)
                                tarafinListesi.Add(tekTaraf);
                        }
                    }

                    hy.TaraflariToplaLimited(tarafinListesi, td.TarafHesabi, anaFoy.TAKIP_TARIHI);
                    TList<AV001_TI_BIL_FOY_TARAF> hesaplananTaraf = new TList<AV001_TI_BIL_FOY_TARAF>();
                    hesaplananTaraf.Add(td.TarafHesabi);
                    ucIcraHesapCetveli2.MyTarafSource = hesaplananTaraf;
                    ucIcraHesapCetveli2.Refresh();

                    //ToDo : Gkn Burada alt föylerin hesaplanmasý yapýlacak;
                }
                else
                {
                    if (anaFoy != null)
                    {
                        anaFoy = hy.IcraFoyHesaplaByID(anaFoy.ID);
                        TList<AV001_TI_BIL_FOY_TARAF> hesaplananTaraf = new TList<AV001_TI_BIL_FOY_TARAF>();

                        foreach (AV001_TI_BIL_FOY_TARAF tekTaraf in anaFoy.AV001_TI_BIL_FOY_TARAFCollection)
                        {
                            if (tekTaraf.CARI_ID == td.TarafID)
                            {
                                hesaplananTaraf.Add(tekTaraf);
                            }
                        }
                        ucIcraHesapCetveli2.MyTarafSource = hesaplananTaraf;
                    }
                }
            }
            else
            {
                DialogResult dSonuc = XtraMessageBox.Show("Tarafýn Dosya Ýle Ýliþkili Dosyasý Bulunmamaktadýr.",
                                                          "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridControl2_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void kayitSil_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetList(FoyId, ucIliskiDetay.IliskiTur.ÝCRA_DOSYASI);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            TarafDosyalari tDosyalari = lookUpEdit1.EditValue as TarafDosyalari;
            if (tDosyalari == null)
                return;
            tDosyalari.Iliskiler.Filter = "ID > 0";
            tlTarafDosya.DataSource = tDosyalari.Iliskiler;
            tlTarafDosya.KeyFieldName = "ID";
            tlTarafDosya.ParentFieldName = "KAYIT_ILISKI_ID";
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            TarafDosyalari dosyalar = lookUpEdit2.EditValue as TarafDosyalari;

            gridControl2.DataSource = dosyalar.TumDosyalar;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TarafDosyalari liste = lookUpEdit2.EditValue as TarafDosyalari;
            HesapYapar hy = new HesapYapar();

            List<AV001_TI_BIL_FOY> hesaplananFoylerinListesi = new List<AV001_TI_BIL_FOY>();

            foreach (R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU teki in liste.TumDosyalar)
            {
                if (teki.Tipi == "Icra")
                {
                    if (teki.ID != null)
                        hesaplananFoylerinListesi.Add(hy.IcraFoyHesaplaByID(teki.ID.Value));
                }
            }
            if (hesaplananFoylerinListesi.Count > 0)
            {
                DateTime? zaman = DateTime.Now;
                ucIcraHesapCetveli3.MyFoyDataSource = hy.TumFoyTopla(hesaplananFoylerinListesi, zaman);
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay =
                treeList1.GetDataRecordByNode(treeList1.FocusedNode) as AV001_TDI_BIL_KAYIT_ILISKI_DETAY;

            if (detay == null)
                return;

            switch (detay.HEDEF_TIP)
            {
                case 1:

                    //dava
                    if (detay.HEDEF_ICRA_FOY_IDSource != null)
                    {
                    }
                    else if (detay.HEDEF_ICRA_FOY_ID != null)
                        break;
                    break;
                default:
                    break;
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None
                && tree.State == TreeListState.Regular)
            {
                Point pt = tree.PointToClient(MousePosition);
                TreeListHitInfo info = tree.CalcHitInfo(e.Location);
                if (info.HitInfoType == HitInfoType.Cell)
                {
                    TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detaylar =
                        (sender as DevExpress.XtraTreeList.TreeList).DataSource as
                        TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>;
                    if (detaylar.Count > 0)
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI_DETAY o = detaylar[info.Node.Id];

                        popupMenu1.ItemLinks.Clear();
                        DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem(barManager1,
                                                                                                       "Takip Ekraný");
                        item.Tag = o;

                        DevExpress.XtraBars.BarButtonItem item2 = new DevExpress.XtraBars.BarButtonItem(barManager1,
                                                                                                        "Kayýt Sil");
                        item2.Tag = o;

                        DevExpress.XtraBars.BarButtonItem item3 = new DevExpress.XtraBars.BarButtonItem(barManager1, "Ýliþkili Dosya Ekle");
                        item3.Tag = -1;

                        popupMenu1.ItemLinks.Add(item);
                        popupMenu1.ItemLinks.Add(item2);
                        popupMenu1.ItemLinks.Add(item3);

                        popupMenu1.ShowPopup(MousePosition);
                    }
                    else
                    {
                        MsgKayitBulunamadi();
                    }
                }
            }
        }

        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {
            object o = treeList1.FocusedNode;
        }

        private void ucIliskiDetay_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            this.HesapCetveliGorunsun = false;
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimID);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorevID);
            BelgeUtil.Inits.KayitIliskiNedenGetir(rLueKayitIliskiNEden);

            BelgeUtil.Inits.KayitIliskiTurGetir(rlueIliskiTurId);

            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliyeNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliyeGorev);

            BelgeUtil.Inits.IliskiDetayHedefTipiGetir(rlueHedefTip);
            BelgeUtil.Inits.KayitIliskiNedenGetir(rlueIliskiNeden);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
            BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
            BelgeUtil.Inits.DosyaDurumGetir(rLueDosyaDurum);
            BelgeUtil.Inits.TakipKonusuGetir(rLueTakipKonusu);
        }

        #endregion Events

        #region Methots

        public DataTable DataTableVer()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("HEDEF_TIP");
            dt.Columns.Add("HEDEF_FOY_NO");
            dt.Columns.Add("HEDEF_DOSYA_TALEP");
            dt.Columns.Add("HEDEF_ADLI_BIRIM_ADLIYE_ID");
            dt.Columns.Add("HEDEF_ADLI_BIRIM_NO_ID");
            dt.Columns.Add("HEDEF_ADLI_BIRIM_GOREV_ID");
            dt.Columns.Add("HEDEF_ESAS_NO");
            dt.Columns.Add("ILISKI_NEDEN_ID");
            dt.Columns.Add("ILISKI_TUR_ID");
            dt.Columns.Add("HEDEF_DOSYA_TARIHI");
            dt.Columns.Add("ACIKLAMA");

            //dt.Columns.Add("ADMIN_KAYIT_MI");
            //dt.Columns.Add("HEDEF_DAVA_FOY_ID");
            //dt.Columns.Add("HEDEF_HAZIRLIK_ID");
            //dt.Columns.Add("HEDEF_ICRA_FOY_ID");
            //dt.Columns.Add("HEDEF_KAYIT_ID");
            //dt.Columns.Add("HEDEF_RUCU_ID");
            //dt.Columns.Add("ID");
            //dt.Columns.Add("KAYIT_ILISKI_ID");
            //dt.Columns.Add("KAYIT_TARIHI");
            //dt.Columns.Add("KLASOR_KODU");
            //dt.Columns.Add("KONTROL_KIM");
            //dt.Columns.Add("KONTROL_NE_ZAMAN");
            //dt.Columns.Add("KONTROL_VERSIYON");
            //dt.Columns.Add("STAMP");
            //dt.Columns.Add("SUBE_KODU");
            return dt;
        }

        public void DoShowMenu(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi)
        {
            if (hi.HitTest == GridHitTest.RowCell)
            {
                GridView view = gridControl2.FocusedView as GridView;

                popupMenu1.ItemLinks.Clear();
                object obj = view.GetRowCellValue(hi.RowHandle, hi.Column);
                R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU secilenKayit =
                    view.GetRow(hi.RowHandle) as R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU;

                DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem(barManager1,
                                                                                               "Takip Ekraný");
                item.Tag = secilenKayit;
                popupMenu1.ItemLinks.Add(item);

                DevExpress.XtraBars.BarButtonItem item2 = new DevExpress.XtraBars.BarButtonItem(barManager1, "Kayýt Sil");
                item2.Tag = secilenKayit;
                popupMenu1.ItemLinks.Add(item2);

                //object o = gcKurumsalGiris.PointToScreen(hi.HitPoint);
                //popupMenu1.ItemLinks.Add(dbn);
                popupMenu1.ShowPopup(gridControl2.PointToScreen(hi.HitPoint));
                ExtendedGridControl gc = new ExtendedGridControl();
            }
        }

        public void GetList(int FoyId, IliskiTur Tur)
        {
            try
            {
                if (!IsLoaded) this.ucIliskiDetay_Load(null, EventArgs.Empty);
                if (Tur == IliskiTur.ÝCRA_DOSYASI)
                {
                    #region icra için iliþkili dosyalarý getiriyoruz

                    int? hedefId = KaynakVerIcra(FoyId);
                    if (hedefId != null)
                    {
                        IliskiliDosyalariToparla(hedefId.Value);
                    }
                    else if (hedefId == null)
                    {
                        treeList1.DataSource = null;
                    }

                    TList<AV001_TI_BIL_FOY_TARAF> taraflar =
                        DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(FoyId);

                    List<TarafDosyalari> tarafListesi = new List<TarafDosyalari>();
                    foreach (AV001_TI_BIL_FOY_TARAF taraf in taraflar)
                    {
                        if (taraf.CARI_ID != null && taraf.TARAF_KODU != Convert.ToByte(TarafKodu.Muvekkil))
                        {
                            tarafListesi.Add(new TarafDosyalari(taraf.CARI_ID.Value));
                        }
                    }
                    lookUpEdit2.Properties.DataSource = tarafListesi;

                    if (lookUpEdit1.Properties.DataSource == null)
                        lookUpEdit1.Properties.DataSource = tarafListesi;

                    if (tarafListesi.Count > 0)
                    {
                        lookUpEdit2.EditValue = tarafListesi[0];
                        lookUpEdit1.EditValue = tarafListesi[0];
                    }

                    #endregion icra için iliþkili dosyalarý getiriyoruz
                }
                else if (Tur == IliskiTur.DAVA_DOSYASI)
                {
                    #region Dava için iliþkili dosyalarý getiriyoruz

                    int? hedefId = KaynakVerDava(FoyId);
                    if (hedefId != null)
                    {
                        IliskiliDosyalariToparla(hedefId.Value);
                    }
                    else if (hedefId == null)
                    {
                        treeList1.DataSource = null;
                    }

                    TList<AV001_TD_BIL_FOY_TARAF> taraflar =
                        DataRepository.AV001_TD_BIL_FOY_TARAFProvider.GetByDAVA_FOY_ID(FoyId);

                    List<TarafDosyalari> tarafListesi = new List<TarafDosyalari>();
                    foreach (AV001_TD_BIL_FOY_TARAF taraf in taraflar)
                    {
                        if (taraf.CARI_ID != null && taraf.TARAF_KODU != Convert.ToByte(TarafKodu.Muvekkil))
                        {
                            tarafListesi.Add(new TarafDosyalari(taraf.CARI_ID.Value));
                        }
                    }
                    lookUpEdit2.Properties.DataSource = tarafListesi;

                    if (lookUpEdit1.Properties.DataSource == null)
                        lookUpEdit1.Properties.DataSource = tarafListesi;

                    if (tarafListesi.Count > 0)
                    {
                        lookUpEdit2.EditValue = tarafListesi[0];
                        lookUpEdit1.EditValue = tarafListesi[0];
                    }

                    #endregion Dava için iliþkili dosyalarý getiriyoruz
                }
                else if (Tur == IliskiTur.HAZIRLIK_DOSYASI)
                {
                    #region Sorusturma için iliþkili dosyalarý getiriyoruz

                    int? hedefId = KaynakVerSorusturma(FoyId);
                    if (hedefId != null)
                    {
                        IliskiliDosyalariToparla(hedefId.Value);
                    }
                    else if (hedefId == null)
                    {
                        treeList1.DataSource = null;
                    }

                    TList<AV001_TD_BIL_HAZIRLIK_TARAF> taraflar =
                        DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.GetByHAZIRLIK_ID(FoyId);

                    List<TarafDosyalari> tarafListesi = new List<TarafDosyalari>();
                    foreach (AV001_TD_BIL_HAZIRLIK_TARAF taraf in taraflar)
                    {
                        if (taraf.CARI_ID != null && taraf.TARAF_KODU != Convert.ToByte(TarafKodu.Muvekkil))
                        {
                            tarafListesi.Add(new TarafDosyalari(taraf.CARI_ID.Value));
                        }
                    }
                    lookUpEdit2.Properties.DataSource = tarafListesi;

                    if (lookUpEdit1.Properties.DataSource == null)
                        lookUpEdit1.Properties.DataSource = tarafListesi;

                    if (tarafListesi.Count > 0)
                    {
                        lookUpEdit2.EditValue = tarafListesi[0];
                        lookUpEdit1.EditValue = tarafListesi[0];
                    }

                    #endregion Sorusturma için iliþkili dosyalarý getiriyoruz
                }
                else if (Tur == IliskiTur.SOZLESME_DOSYASI)
                {
                    #region Sözleþme için iliþkili dosyalarý getiriyoruz

                    int? hedefId = KaynakVerSozlesme(FoyId);
                    if (hedefId != null)
                    {
                        IliskiliDosyalariToparla(hedefId.Value);
                    }
                    else if (hedefId == null)
                    {
                        treeList1.DataSource = null;
                    }

                    TList<AV001_TDI_BIL_SOZLESME_TARAF> taraflar =
                        DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.GetBySOZLESME_ID(FoyId);

                    List<TarafDosyalari> tarafListesi = new List<TarafDosyalari>();
                    foreach (AV001_TDI_BIL_SOZLESME_TARAF taraf in taraflar)
                    {
                        if (taraf.CARI_ID != null && taraf.TARAF_KODU != Convert.ToByte(TarafKodu.Muvekkil))
                        {
                            tarafListesi.Add(new TarafDosyalari(taraf.CARI_ID.Value));
                        }
                    }
                    lookUpEdit2.Properties.DataSource = tarafListesi;

                    if (lookUpEdit1.Properties.DataSource == null)
                        lookUpEdit1.Properties.DataSource = tarafListesi;

                    if (tarafListesi.Count > 0)
                    {
                        lookUpEdit2.EditValue = tarafListesi[0];
                        lookUpEdit1.EditValue = tarafListesi[0];
                    }

                    #endregion Sözleþme için iliþkili dosyalarý getiriyoruz
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            #region Kapanan Alan

            //Bu Bölüm Tahliye edildi (gkn)
            //AV001_TDI_BIL_KAYIT_ILISKI kiliski = new AV001_TDI_BIL_KAYIT_ILISKI();
            //TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> Detaylar = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();

            //if (FoyId > 0 && Tur != IliskiTur.NULL)
            //{
            //    kiliski = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.
            //             GetByILISKI_TUR_IDKAYNAK_KAYIT_ID((int)Tur, FoyId);

            //    if (kiliski != null)
            //    {
            //        // GKN : Testing
            //        DosyalariToparla(kiliski);
            //        // Testing end

            //        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(kiliski, true,
            //            DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            //        foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay in kiliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
            //        {
            //            Detaylar.Add(detay);
            //        }
            //    }

            //    Detaylar.Sort("HEDEF_TIP DESC");

            //    gridControl1.DataSource = Detaylar;

            #endregion Kapanan Alan
        }

        public void IliskiliDosyalariToparla(int hedefId)
        {
            AV001_TDI_BIL_KAYIT_ILISKI iliski = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(hedefId);
            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(iliski, false, DeepLoadType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));

            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yapmacikDetay = IliskiToDetayConverter(iliski);
            IliskiDetayEksikAlanlariDoldur(yapmacikDetay);

            TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskililerListe = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();

            List<TarafDosyalari> taraflar = TaraflarinTespiti(yapmacikDetay);

            yapmacikDetay.KAYIT_ILISKI_ID = 0;

            iliskililerListe.Add(yapmacikDetay);

            iliskililerListe.AddRange(iliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection);
            if (iliskililerListe.Count < 1)
                return;
            if (iliskililerListe[0].HEDEF_ICRA_FOY_ID != null)
            {
                iliskililerListe[0].HEDEF_ICRA_FOY_IDSource =
                    DataRepository.AV001_TI_BIL_FOYProvider.GetByID(iliskililerListe[0].HEDEF_ICRA_FOY_ID.Value);
            }

            DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.DeepLoad(iliskililerListe, false,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(AV001_TI_BIL_FOY),
                                                                             typeof(AV001_TD_BIL_FOY),
                                                                             typeof(AV001_TD_BIL_HAZIRLIK),
                                                                             typeof(AV001_TDI_BIL_RUCU),
                                                                             typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>),
                                                                             typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>),
                                                                             typeof(TList<AV001_TDI_BIL_RUCU_TARAF>));

            foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay in iliskililerListe)
            {
                IliskiDetayEksikAlanlariDoldur(detay);
                foreach (TarafDosyalari var in taraflar)
                {
                    var.Iliskiler.Add(yapmacikDetay);
                    if (TarafVarmi(detay, var.TarafID))
                    {
                        if (var.Iliskiler == null) var.Iliskiler = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
                        var.Iliskiler.Add(detay);
                    }
                }

                //DataRow drAlt = RowEkle(DataTableVer(), detay);
            }

            lookUpEdit1.Properties.DataSource = taraflar;
            if (taraflar.Count > 0)
                lookUpEdit1.EditValue = taraflar[0].TarafID;

            for (int i = 0; i < iliskililerListe.Count; i++)
            {
                iliskililerListe[i].KAYIT_ILISKI_ID = 0 - iliskililerListe[i].KAYIT_ILISKI_ID;
            }

            treeList1.DataSource = iliskililerListe;
            treeList1.OptionsView.AutoWidth = true;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "KAYIT_ILISKI_ID";
        }

        // TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskililerListe = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
        /// <summary>
        /// Verdiðimiz Ýliþki taplosundaki alanlar ile iliþki_detay tablosunda ki ortak belirlenen alanlar arasýnda baðlantý kurarark bir detay kaydý vermekte (gkn)
        /// </summary>
        /// <param name="iliski"></param>
        /// <returns></returns>
        public AV001_TDI_BIL_KAYIT_ILISKI_DETAY IliskiToDetayConverter(AV001_TDI_BIL_KAYIT_ILISKI iliski)
        {
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY yapmacikDetay = new AV001_TDI_BIL_KAYIT_ILISKI_DETAY();

            yapmacikDetay.ID = 0 - iliski.ID;

            if (iliski.ILISKI_TUR_ID.HasValue)
                yapmacikDetay.ILISKI_TUR_ID = iliski.ILISKI_TUR_ID.Value;

            yapmacikDetay.HEDEF_KAYIT_ID = iliski.KAYNAK_KAYIT_ID;
            yapmacikDetay.ACIKLAMA = iliski.ACIKLAMA;
            yapmacikDetay.KAYIT_TARIHI = iliski.KAYIT_TARIHI;
            yapmacikDetay.KLASOR_KODU = iliski.KLASOR_KODU;
            yapmacikDetay.SUBE_KODU = iliski.SUBE_KODU;
            yapmacikDetay.KONTROL_NE_ZAMAN = iliski.KONTROL_NE_ZAMAN;
            yapmacikDetay.KONTROL_KIM = iliski.KONTROL_KIM;
            yapmacikDetay.KONTROL_VERSIYON = iliski.KONTROL_VERSIYON;
            yapmacikDetay.STAMP = iliski.STAMP;
            yapmacikDetay.HEDEF_DAVA_FOY_ID = iliski.KAYNAK_DAVA_FOY_ID;
            yapmacikDetay.HEDEF_ICRA_FOY_ID = iliski.KAYNAK_ICRA_FOY_ID;
            yapmacikDetay.HEDEF_HAZIRLIK_ID = iliski.KAYNAK_HAZIRLIK_ID;
            yapmacikDetay.HEDEF_RUCU_ID = iliski.KAYNAK_RUCU_ID;
            yapmacikDetay.HEDEF_TIP = iliski.KAYNAK_TIP;
            yapmacikDetay.Tag = 1;
            switch (yapmacikDetay.HEDEF_TIP)
            {
                case 1:

                    //icra
                    if (yapmacikDetay.HEDEF_ICRA_FOY_ID != null)
                    {
                        AV001_TI_BIL_FOY icrafoy =
                            DataRepository.AV001_TI_BIL_FOYProvider.GetByID(yapmacikDetay.HEDEF_ICRA_FOY_ID.Value);
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icrafoy, false, DeepLoadType.IncludeChildren,
                                                                         typeof(AV001_TI_BIL_FOY_TARAF));
                        yapmacikDetay.HEDEF_ICRA_FOY_IDSource = icrafoy;
                    }
                    break;

                case 2:

                    //dava
                    if (yapmacikDetay.HEDEF_DAVA_FOY_ID != null)
                    {
                        AV001_TD_BIL_FOY davafoy =
                            DataRepository.AV001_TD_BIL_FOYProvider.GetByID(yapmacikDetay.HEDEF_DAVA_FOY_ID.Value);
                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(davafoy, false, DeepLoadType.IncludeChildren,
                                                                         typeof(AV001_TD_BIL_FOY_TARAF));
                        yapmacikDetay.HEDEF_DAVA_FOY_IDSource = davafoy;
                    }

                    break;

                case 3:

                    //hazýrlýk

                    if (yapmacikDetay.HEDEF_HAZIRLIK_ID != null)
                    {
                        AV001_TD_BIL_HAZIRLIK hazirlik =
                            DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(yapmacikDetay.HEDEF_HAZIRLIK_ID.Value);
                        DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(hazirlik, false,
                                                                              DeepLoadType.IncludeChildren,
                                                                              typeof(AV001_TD_BIL_HAZIRLIK_TARAF));
                        yapmacikDetay.HEDEF_HAZIRLIK_IDSource = hazirlik;
                    }
                    break;

                case 4:

                    //rucu

                    if (yapmacikDetay.HEDEF_RUCU_ID != null)
                    {
                        AV001_TDI_BIL_RUCU rucu =
                            DataRepository.AV001_TDI_BIL_RUCUProvider.GetByID(yapmacikDetay.HEDEF_RUCU_ID.Value);
                        DataRepository.AV001_TDI_BIL_RUCUProvider.DeepLoad(rucu, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_RUCU_TARAF>));
                        yapmacikDetay.HEDEF_RUCU_IDSource = rucu;
                    }
                    break;

                case 5: //Sözleþme
                    AV001_TDI_BIL_SOZLESME sozlesme =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(yapmacikDetay.HEDEF_KAYIT_ID);

                    yapmacikDetay.HEDEF_ADLI_BIRIM_ADLIYE_ID = sozlesme.ADLI_BIRIM_ADLIYE_ID;
                    yapmacikDetay.HEDEF_ADLI_BIRIM_GOREV_ID = sozlesme.ADLI_BIRIM_GOREV_ID;
                    yapmacikDetay.HEDEF_ADLI_BIRIM_NO_ID = sozlesme.ADLI_BIRIM_NO_ID;
                    yapmacikDetay.HEDEF_DOSYA_TARIHI = sozlesme.BASLANGIC_TARIHI;

                    break;

                default:
                    break;
            }

            return yapmacikDetay;
        }

        public int? KaynakVerDava(int foyId)
        {
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(5661, foyId);
            if (iliski != null)
            {
                // iliþki
                return iliski.ID;
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detay =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_DAVA_FOY_ID(foyId);
                if (detay.Count > 0)
                {
                    return detay[0].KAYIT_ILISKI_ID;
                }
            }
            return null;
        }

        public int? KaynakVerIcra(int foyId)
        {
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(601, foyId);
            if (iliski != null)
            {
                // iliþki
                return iliski.ID;
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detay =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_ICRA_FOY_ID(foyId);
                if (detay.Count > 0)
                {
                    return detay[0].KAYIT_ILISKI_ID;
                }
            }
            return null;
        }

        public int? KaynakVerSorusturma(int foyId)
        {
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int)IliskiTur.HAZIRLIK_DOSYASI, foyId);
            if (iliski != null)
            {
                // iliþki
                return iliski.ID;
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detay =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_HAZIRLIK_ID(foyId);
                if (detay.Count > 0)
                {
                    return detay[0].KAYIT_ILISKI_ID;
                }
            }
            return null;
        }

        public int? KaynakVerSozlesme(int foyId)
        {
            AV001_TDI_BIL_KAYIT_ILISKI iliski =
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                    (int)IliskiTur.SOZLESME_DOSYASI, foyId);
            if (iliski != null)
            {
                // iliþki
                return iliski.ID;
            }
            else
            {
                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> detay =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(foyId);
                if (detay.Count > 0)
                {
                    return detay[0].KAYIT_ILISKI_ID;
                }
            }
            return null;
        }

        public void MsgKayitBulunamadi()
        {
            XtraMessageBox.Show("Kayýda Adit Föy Bulunamadý", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public DataRow RowEkle(DataTable dt, AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay)
        {
            DataRow dr = dt.NewRow();
            dr["HEDEF_TIP"] = detay.HEDEF_TIP;
            dr["HEDEF_FOY_NO"] = detay.HEDEF_FOY_NO;
            dr["HEDEF_DOSYA_TALEP"] = detay.HEDEF_DOSYA_TALEP;
            dr["HEDEF_ADLI_BIRIM_ADLIYE_ID"] = detay.HEDEF_ADLI_BIRIM_ADLIYE_ID;
            dr["HEDEF_ADLI_BIRIM_NO_ID"] = detay.HEDEF_ADLI_BIRIM_NO_ID;
            dr["HEDEF_ADLI_BIRIM_GOREV_ID"] = detay.HEDEF_ADLI_BIRIM_GOREV_ID;
            dr["HEDEF_ESAS_NO"] = detay.HEDEF_ESAS_NO;
            dr["HEDEF_DOSYA_TARIHI"] = detay.HEDEF_DOSYA_TARIHI;
            dr["ILISKI_NEDEN_ID"] = detay.ILISKI_NEDEN_ID;
            dr["ILISKI_TUR_ID"] = detay.ILISKI_TUR_ID;
            dr["ACIKLAMA"] = detay.ACIKLAMA;

            //dr["ADMIN_KAYIT_MI"] = detay.ADMIN_KAYIT_MI;
            //dr["HEDEF_DAVA_FOY_ID"] = detay.HEDEF_DAVA_FOY_ID;
            //dr["HEDEF_HAZIRLIK_ID"] = detay.HEDEF_HAZIRLIK_ID;
            //dr["HEDEF_ICRA_FOY_ID"] = detay.HEDEF_ICRA_FOY_ID;
            //dr["HEDEF_KAYIT_ID"] = detay.HEDEF_KAYIT_ID;
            //dr["HEDEF_RUCU_ID"] = detay.HEDEF_RUCU_ID;
            //dr["ID"] = detay.ID;
            //dr["KAYIT_ILISKI_ID"] = detay.KAYIT_ILISKI_ID;
            //dr["KAYIT_TARIHI"] = detay.KAYIT_TARIHI;
            //dr["KLASOR_KODU"] = detay.KLASOR_KODU;
            //dr["KONTROL_KIM"] = detay.KONTROL_KIM;
            //dr["KONTROL_NE_ZAMAN"] = detay.KONTROL_NE_ZAMAN;
            //dr["KONTROL_VERSIYON"] = detay.KONTROL_VERSIYON;
            //dr["STAMP"] = detay.STAMP;
            //dr["SUBE_KODU"] = detay.SUBE_KODU;

            return dr;
        }

        public List<TarafDosyalari> TaraflarinTespiti(AV001_TDI_BIL_KAYIT_ILISKI_DETAY iliskiDetay)
        {
            List<TarafDosyalari> liste = new List<TarafDosyalari>();

            if (iliskiDetay.HEDEF_TIP != null)
            {
                switch (iliskiDetay.HEDEF_TIP.Value)
                {
                    case 1:

                        //icra
                        if (iliskiDetay.HEDEF_ICRA_FOY_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TI_BIL_FOY_TARAF icraTaraf in
                                        iliskiDetay.HEDEF_ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    if (!icraTaraf.TAKIP_EDEN_MI)
                                        liste.Add(new TarafDosyalari(icraTaraf.CARI_ID.Value));
                                }
                            }
                            else
                            {
                                TList<AV001_TI_BIL_FOY_TARAF> icraTaraflar =
                                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(
                                        iliskiDetay.HEDEF_ICRA_FOY_IDSource.ID);
                                foreach (AV001_TI_BIL_FOY_TARAF icraTaraf in icraTaraflar)
                                {
                                    if (!icraTaraf.TAKIP_EDEN_MI)
                                        liste.Add(new TarafDosyalari(icraTaraf.CARI_ID.Value));
                                }
                            }
                        }

                        break;

                    case 2:

                        //Dava

                        if (iliskiDetay.HEDEF_DAVA_FOY_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_DAVA_FOY_IDSource.AV001_TD_BIL_FOY_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TD_BIL_FOY_TARAF davaTaraf in
                                        iliskiDetay.HEDEF_DAVA_FOY_IDSource.AV001_TD_BIL_FOY_TARAFCollection)
                                {
                                    liste.Add(new TarafDosyalari(davaTaraf.CARI_ID.Value));
                                }
                            }
                        }

                        break;

                    case 3:

                        //hazýrlýk

                        if (iliskiDetay.HEDEF_HAZIRLIK_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_HAZIRLIK_IDSource.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf in
                                        iliskiDetay.HEDEF_HAZIRLIK_IDSource.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                                {
                                    liste.Add(new TarafDosyalari(hazirlikTaraf.CARI_ID.Value));
                                }
                            }
                        }

                        break;

                    case 4:

                        //rucu
                        if (iliskiDetay.HEDEF_RUCU_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_RUCU_IDSource.AV001_TDI_BIL_RUCU_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TDI_BIL_RUCU_TARAF rucuTaraf in
                                        iliskiDetay.HEDEF_RUCU_IDSource.AV001_TDI_BIL_RUCU_TARAFCollection)
                                {
                                    liste.Add(new TarafDosyalari(rucuTaraf.CARI_ID.Value));
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return liste;
        }

        public bool TarafVarmi(AV001_TDI_BIL_KAYIT_ILISKI_DETAY iliskiDetay, int cariId)
        {
            bool sonuc = true;
            if (iliskiDetay.HEDEF_TIP != null)
            {
                switch (iliskiDetay.HEDEF_TIP.Value)
                {
                    case 1:

                        //icra
                        if (iliskiDetay.HEDEF_ICRA_FOY_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TI_BIL_FOY_TARAF icraTaraf in
                                        iliskiDetay.HEDEF_ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection)
                                {
                                    if (icraTaraf.CARI_ID == cariId) sonuc = true;
                                }
                            }
                            else
                            {
                                TList<AV001_TI_BIL_FOY_TARAF> icraTaraflar =
                                    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(
                                        iliskiDetay.HEDEF_ICRA_FOY_IDSource.ID);
                                foreach (AV001_TI_BIL_FOY_TARAF icraTaraf in icraTaraflar)
                                {
                                    if (icraTaraf.CARI_ID == cariId) sonuc = true;
                                }
                            }
                        }
                        return sonuc;


                    case 2:

                        //Dava

                        if (iliskiDetay.HEDEF_DAVA_FOY_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_DAVA_FOY_IDSource.AV001_TD_BIL_FOY_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TD_BIL_FOY_TARAF davaTaraf in
                                        iliskiDetay.HEDEF_DAVA_FOY_IDSource.AV001_TD_BIL_FOY_TARAFCollection)
                                {
                                    if (davaTaraf.CARI_ID == cariId) sonuc = true;
                                }
                            }
                        }
                        return sonuc;


                    case 3:

                        //hazýrlýk

                        if (iliskiDetay.HEDEF_HAZIRLIK_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_HAZIRLIK_IDSource.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TD_BIL_HAZIRLIK_TARAF hazirlikTaraf in
                                        iliskiDetay.HEDEF_HAZIRLIK_IDSource.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
                                {
                                    if (hazirlikTaraf.CARI_ID == cariId) sonuc = true;
                                }
                            }
                        }

                        return sonuc;


                    case 4:

                        //rucu
                        if (iliskiDetay.HEDEF_RUCU_IDSource != null)
                        {
                            if (iliskiDetay.HEDEF_RUCU_IDSource.AV001_TDI_BIL_RUCU_TARAFCollection.Count > 0)
                            {
                                foreach (
                                    AV001_TDI_BIL_RUCU_TARAF rucuTaraf in
                                        iliskiDetay.HEDEF_RUCU_IDSource.AV001_TDI_BIL_RUCU_TARAFCollection)
                                {
                                    if (rucuTaraf.CARI_ID == cariId) sonuc = true;
                                }
                            }
                        }
                        return sonuc;
                    default:
                        return sonuc;
                }
            }
            return false;
        }

        private static void IliskiDetayEksikAlanlariDoldur(AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay)
        {
            switch (detay.HEDEF_TIP)
            {
                case 1:
                    if (detay.HEDEF_ICRA_FOY_IDSource != null)
                    {
                        AV001_TI_BIL_FOY icraFoy = detay.HEDEF_ICRA_FOY_IDSource;

                        // DataRepository.AV001_TI_BIL_FOYProvider.GetByID(detay.HEDEF_ICRA_FOY_ID.Value);

                        detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = icraFoy.ADLI_BIRIM_ADLIYE_ID;
                        detay.HEDEF_ADLI_BIRIM_GOREV_ID = icraFoy.ADLI_BIRIM_GOREV_ID;
                        detay.HEDEF_ADLI_BIRIM_NO_ID = icraFoy.ADLI_BIRIM_NO_ID;
                        detay.HEDEF_DOSYA_TARIHI = icraFoy.TAKIP_TARIHI;
                        detay.HEDEF_ESAS_NO = icraFoy.ESAS_NO;
                    }

                    //icra
                    break;

                case 2:
                    if (detay.HEDEF_DAVA_FOY_IDSource != null)
                    {
                        AV001_TD_BIL_FOY davaFoy = detay.HEDEF_DAVA_FOY_IDSource;

                        // DataRepository.AV001_TD_BIL_FOYProvider.GetByID(detay.HEDEF_DAVA_FOY_ID.Value);
                        detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = davaFoy.ADLI_BIRIM_ADLIYE_ID;
                        detay.HEDEF_ADLI_BIRIM_GOREV_ID = davaFoy.ADLI_BIRIM_GOREV_ID;
                        detay.HEDEF_ADLI_BIRIM_NO_ID = davaFoy.ADLI_BIRIM_NO_ID;
                        detay.HEDEF_DOSYA_TARIHI = davaFoy.DAVA_TARIHI;
                        detay.HEDEF_ESAS_NO = davaFoy.ESAS_NO;

                        DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(davaFoy, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TD_KOD_DAVA_TALEP));
                        detay.HEDEF_DOSYA_TALEP = davaFoy.DAVA_TALEP_IDSource.DAVA_TALEP;
                    }

                    //dava
                    break;

                case 3:
                    if (detay.HEDEF_HAZIRLIK_IDSource != null)
                    {
                        AV001_TD_BIL_HAZIRLIK hazirlik = detay.HEDEF_HAZIRLIK_IDSource;

                        //DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(detay.HEDEF_HAZIRLIK_ID.Value);
                        detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = hazirlik.ADLI_BIRIM_ADLIYE_ID;
                        detay.HEDEF_ADLI_BIRIM_GOREV_ID = hazirlik.ADLI_BIRIM_GOREV_ID;
                        detay.HEDEF_ADLI_BIRIM_NO_ID = hazirlik.ADLI_BIRIM_NO_ID;
                        detay.HEDEF_DOSYA_TARIHI = hazirlik.HAZIRLIK_TARIH;
                        detay.HEDEF_ESAS_NO = hazirlik.HAZIRLIK_ESAS_NO;
                    }

                    //Hazýrlýk
                    break;

                case 4:
                    if (detay.HEDEF_RUCU_IDSource != null)
                    {
                        AV001_TDI_BIL_RUCU rucu = detay.HEDEF_RUCU_IDSource;

                        //DataRepository.AV001_TDI_BIL_RUCUProvider.GetByID(detay.HEDEF_RUCU_ID.Value);
                        //detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = rucu.ADLI_BIRIM_ADLIYE_ID;
                        //detay.HEDEF_ADLI_BIRIM_GOREV_ID = rucu.ADLI_BIRIM_GOREV_ID;
                        //detay.HEDEF_ADLI_BIRIM_NO_ID = rucu.ADLI_BIRIM_NO_ID;
                        detay.HEDEF_DOSYA_TARIHI = rucu.MURACAT_TARIHI;
                    }

                    //rucu
                    break;

                case 5: //Sözleþme
                    AV001_TDI_BIL_SOZLESME sozlesme =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(detay.HEDEF_KAYIT_ID);

                    detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = sozlesme.ADLI_BIRIM_ADLIYE_ID;
                    detay.HEDEF_ADLI_BIRIM_GOREV_ID = sozlesme.ADLI_BIRIM_GOREV_ID;
                    detay.HEDEF_ADLI_BIRIM_NO_ID = sozlesme.ADLI_BIRIM_NO_ID;
                    detay.HEDEF_DOSYA_TARIHI = sozlesme.BASLANGIC_TARIHI;
                    break;
            }
        }

        #endregion Methots

        #region Properties

        private bool _HesapCetveliGorunsun;

        public AV001_TDI_BIL_KAYIT_ILISKI DataSourceIliskiliDosyalar { get; set; }

        public int FoyId { get; set; }

        [Browsable(true), DefaultValue(true)]
        public bool HesapCetveliGorunsun
        {
            get { return _HesapCetveliGorunsun; }
            set
            {
                _HesapCetveliGorunsun = value;
                if (!value)
                {
                    if (xtraTabControl2 != null)
                    {
                        xtraTabControl2.TabPages[1].PageVisible = false;
                        xtraTabControl4.TabPages[1].PageVisible = false;
                        xtraTabControl5.TabPages[1].PageVisible = false;
                    }
                }
                else
                {
                    if (xtraTabControl2 != null)
                    {
                        xtraTabControl2.TabPages[1].PageVisible = true;
                        xtraTabControl4.TabPages[1].PageVisible = true;
                        xtraTabControl5.TabPages[1].PageVisible = true;
                    }
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> IliskililerListe { get; set; }

        public IliskiTur Tur { get; set; }

        #endregion Properties

        public enum IliskiTur
        {
            NULL = 0,
            DAVA_DOSYASI = 5661,
            ÝCRA_DOSYASI = 601,
            ÝHTÝYATÝ_HACÝZ = 620,
            ÝHTÝYATÝ_TEDBÝR = 622,
            TESPÝT_DOSYASI = 1730,
            RÜCU_DOSYASI = 5600,
            HAZIRLIK_DOSYASI = 5610,
            TALÝMAT_ÝCRA = 1703,
            TALÝMAT_DAVA = 1704,
            SOZLESME_DOSYASI = 7500,
        }
    }
}