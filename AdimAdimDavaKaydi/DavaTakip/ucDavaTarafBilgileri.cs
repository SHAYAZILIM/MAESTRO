using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.DavaTakip
{
    public partial class ucDavaTarafBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucDavaTarafBilgileri()
        {
            if (DesignMode)
            {
                InitializeComponent();
            }
            this.Load += ucDavaTarafBilgileri_Load;
        }

        private void btnSahsinIletisimBilgileriniDuzenle_Click(object sender, EventArgs e)
        {
            if (gcIletisimBilgileri.DataSource != null)
            {
                VList<per_CariKimlikIletisimBilgileri> guncellenecekCari = (VList<per_CariKimlikIletisimBilgileri>)gcIletisimBilgileri.DataSource;

                AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(guncellenecekCari[0].ID);
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
            else
                XtraMessageBox.Show("Güncellenecek þahýs seçiniz!");
        }

        private void gvDavaEden_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gvDavaEden.FocusedRowHandle)
            {
                AV001_TD_BIL_FOY_TARAF seciliTaraf = (AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(e.RowHandle);
                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwDavaEdilenler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwDavaEdilenler.FocusedRowHandle)
            {
                AV001_TD_BIL_FOY_TARAF seciliTaraf = (AV001_TD_BIL_FOY_TARAF)gwDavaEdilenler.GetRow(e.RowHandle);

                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        //    if (seciliTaraf.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}
        private void gwSorumlular_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSorumlular.FocusedRowHandle)
            {
                AV001_TD_BIL_FOY_SORUMLU_AVUKAT seciliAvukat = (AV001_TD_BIL_FOY_SORUMLU_AVUKAT)gwSorumlular.GetRow(e.RowHandle);

                if (seciliAvukat.SORUMLU_AVUKAT_CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_AVUKAT_CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void rbtnTemsilEkle_Click(object sender, EventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TD_BIL_FOY_TARAF trf = gvDavaEden.GetRow(gvDavaEden.FocusedRowHandle) as AV001_TD_BIL_FOY_TARAF;
            frm.MdiParent = null;
            DialogResult dr = frm.ShowDialog(trf, MyFoy);
        }

        private void rbtnTemsilEkleDavali_Click(object sender, EventArgs e)
        {
            frmTemsilKayit frm = new frmTemsilKayit();
            AV001_TD_BIL_FOY_TARAF trf =
                gwDavaEdilenler.GetRow(gwDavaEdilenler.FocusedRowHandle) as AV001_TD_BIL_FOY_TARAF;
            frm.MdiParent = null;
            DialogResult dr = frm.ShowDialog(trf, MyFoy);
        }

        private void rLueCariler_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "Yeni")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = lue.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                        BelgeUtil.Inits.perCariGetir(rLueCariler);
                };
            }
        }

        private void rLueCariler_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                int i = 0;
                try
                {
                    for (i = 0; i < MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
                    {
                        if (MyFoy.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID == (int)e.OldValue)
                        {
                            MyFoy.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)e.NewValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void rLueSorumluTaraf_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                int i = 0;

                try
                {
                    for (i = 0; i < MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
                    {
                        if (MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID ==
                            (int)e.OldValue)
                        {
                            MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)e.NewValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void ucDavaTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();

                #region Events

                gvDavaEden.ValidateRow += gwDavaEdenler_ValidateRow;
                gwDavaEdilenler.ValidateRow += gwDavaEdilenler_ValidateRow;
                gwSorumlular.ValidateRow += gwSorumlular_ValidateRow;

                #endregion Events

                gvDavaEdilenTarafVekil.OptionsDetail.AllowExpandEmptyDetails = true;
                CheckForIllegalCrossThreadCalls = false;
                IsLoaded = true;
            }
            LoadData();
        }

        #region Veriables

        private static int _currSorumluAvkId;
        private static int _currTalepId;
        private static int _currTarafId;
        private TList<AV001_TD_BIL_FOY_TARAF> _davaEdenler = new TList<AV001_TD_BIL_FOY_TARAF>();
        private TList<AV001_TD_BIL_FOY_TARAF> _davaEdilenler = new TList<AV001_TD_BIL_FOY_TARAF>();
        private AV001_TD_BIL_FOY _myFoy;

        #endregion Veriables

        #region Enums

        public enum Direction
        {
            Previous = 0,
            Next = 1
        }

        #endregion Enums

        #region Properties

        public static int CurrSorumluAvkId
        {
            get { return ucDavaTarafBilgileri._currSorumluAvkId; }
            set { ucDavaTarafBilgileri._currSorumluAvkId = value; }
        }

        public static int CurrTalepId
        {
            get { return ucDavaTarafBilgileri._currTalepId; }
            set { ucDavaTarafBilgileri._currTalepId = value; }
        }

        public static int CurrTarafId
        {
            get { return ucDavaTarafBilgileri._currTarafId; }
            set { ucDavaTarafBilgileri._currTarafId = value; }
        }

        public TList<AV001_TD_BIL_FOY_TARAF> DavaEdenler
        {
            get
            {
                if (gcDavaEdenler.DataSource is TList<AV001_TD_BIL_FOY_TARAF>)
                    return (TList<AV001_TD_BIL_FOY_TARAF>)gcDavaEdenler.DataSource;
                return null;
            }
            set
            {
                if (value != null)
                {
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TD_BIL_FOY_TARAF_VEKIL>));

                    gcDavaEdenler.DataSource = value;

                    DavaEdenler.AddingNew += DavaEdenler_AddingNew;

                    rLueCariler.EditValueChanging += DavaEdenler_EditValueChanging;
                }
            }
        }

        public TList<AV001_TD_BIL_FOY_TARAF> DavaEdilenler
        {
            get
            {
                if (gcDavaEdilenler.DataSource is TList<AV001_TD_BIL_FOY_TARAF>)
                    return (TList<AV001_TD_BIL_FOY_TARAF>)gcDavaEdilenler.DataSource;
                return null;
            }
            set
            {
                if (value != null)
                {
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TD_BIL_FOY_TARAF_VEKIL>));

                    gcDavaEdilenler.DataSource = value;

                    DavaEdilenler.AddingNew += DavaEdilenler_AddingNew;
                }
            }
        }

        public Direction Dir { get; set; }

        public AV001_TD_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;

                if (_myFoy != null)
                {
                    SetFoy();
                }
            }
        }

        #endregion Properties

        #region Private Methods

        private void AddNewTaraf(AV001_TD_BIL_FOY_TARAF trf)
        {
            AV001_TD_BIL_FOY_TARAF temp =
                MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Find(AV001_TD_BIL_FOY_TARAFColumn.CARI_ID, trf.CARI_ID.Value);

            if (temp == null)
            {
                trf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value);

                MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Add(trf);
            }
        }

        private void LoadData()
        {
            // Okan 04.01.2010 //Performans Çalýþmasý

            BelgeUtil.Inits.perCariGetir(rLueCariler);
            BelgeUtil.Inits.AktifAvukatlariGetir(rLueSorumluTaraf);
            BelgeUtil.Inits.CariAvukatGetirTemsil(rLueDavaEdenAvukat);
            BelgeUtil.Inits.CariAvukatGetirTemsil(rLueDavaEdilenAvukat);
            BelgeUtil.Inits.TemsilSekliGetir(rLueDavaEdilenTemsilSekli);
            BelgeUtil.Inits.TemsilSekliGetir(rLueTemsilSekli);
            BelgeUtil.Inits.TemsilTipiGetir(rLueDavaEdilenTemsil);
            BelgeUtil.Inits.TemsilTipiGetir(rLueDavaEdenTemsil);
            BelgeUtil.Inits.DavaTarafSifatGetir(rLueSifatlar);
            BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
        }

        private void SetFoy()
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
            TarafBind();
        }

        private void TarafBind()
        {
            if (DavaEdenler == null) DavaEdenler = new TList<AV001_TD_BIL_FOY_TARAF>();
            else
                DavaEdenler.Clear();

            if (DavaEdilenler == null) DavaEdilenler = new TList<AV001_TD_BIL_FOY_TARAF>();
            else
                DavaEdilenler.Clear();

            DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(MyFoy.AV001_TD_BIL_FOY_TARAFCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF_VEKIL>));

            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.DAVA_EDEN_MI)
                {
                    DavaEdenler.Add(taraf);
                }
                else
                {
                    DavaEdilenler.Add(taraf);
                }
            }

            //DavaEdenler Doluyor.
            gcDavaEdenler.BeginUpdate();
            gcDavaEdenler.DataSource = DavaEdenler;
            gcDavaEdenler.EndUpdate();

            //SorumluAvukatlar Doluyor.
            gcSorumlular.BeginUpdate();
            gcSorumlular.DataSource = MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection;
            gcSorumlular.EndUpdate();

            //DavaEdilenler Doluyor.
            gcDavaEdilenler.BeginUpdate();
            gcDavaEdilenler.DataSource = DavaEdilenler;
            gcDavaEdilenler.EndUpdate();

            AV001_TD_BIL_FOY_TARAF seciliTaraf = (AV001_TD_BIL_FOY_TARAF)DavaEdilenler[0];

            if (seciliTaraf.CARI_ID.HasValue)
            {
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
        }

        #endregion Private Methods

        #region EditValue_EventArgs

        public static TList<AV001_TD_BIL_FOY_TARAF> AlacakliTaraflariGetir(AV001_TD_BIL_FOY MyFoy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_CARI),
                                                                           typeof(TDIE_KOD_TARAF_SIFAT),
                                                                           typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>),
                                                                           typeof(TList<AV001_TD_BIL_FOY_GELISME>
                                                                               ));

                if (taraf.TARAF_SIFAT_IDSource != null
                    && taraf.TARAF_SIFAT_IDSource.HANGI_TARAF_NO == (int)DavaTarafKodu.Davacý)
                {
                    result.Add(taraf);
                }
            }

            return result;
        }

        private void DavaEdenler_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                int i = 0;

                for (i = 0; i < MyFoy.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
                {
                    if (MyFoy.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID == (int)e.OldValue)
                    {
                        MyFoy.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_IDSource =
                            DataRepository.AV001_TDI_BIL_CARIProvider.GetByID((int)e.NewValue);
                    }
                }
            }
        }

        #endregion EditValue_EventArgs

        #region ValidateRowEventArgs

        private void gwDavaEdenler_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF trf = (AV001_TD_BIL_FOY_TARAF)e.Row;
            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Dava Eden Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!trf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdenler.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Dava Eden Zaten Eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdilenler.FindAll("CARI_ID", trf.CARI_ID).Count > 0)
            {
                e.ErrorText = "Bu þahýs Dava Edilen Olarak Zaten Eklenmiþtir" + Environment.NewLine;
                e.Valid = false;
                return;
            }

            if (e.Valid)
            {
                AddNewTaraf(trf);
            }
        }

        private void gwDavaEdilenler_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF trf = (AV001_TD_BIL_FOY_TARAF)e.Row;
            if (!trf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Dava Edilen Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!trf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (trf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdilenler.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Dava Edilen Zaten Eklenmiþtir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (DavaEdenler.FindAll("CARI_ID", trf.CARI_ID).Count > 0)
            {
                e.ErrorText = "Bu þahýs Dava Eden Olarak Zaten Eklenmiþtir" + Environment.NewLine;
                e.Valid = false;
                return;
            }

            if (e.Valid)
            {
                AddNewTaraf(trf);
            }
        }

        private void gwSorumlular_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TD_BIL_FOY_SORUMLU_AVUKAT avk = (AV001_TD_BIL_FOY_SORUMLU_AVUKAT)e.Row;
            if (!avk.SORUMLU_AVUKAT_CARI_ID.HasValue && avk.SORUMLU_AVUKAT_CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen bir sorumlu seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            if (
                MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll("SORUMLU_AVUKAT_CARI_ID",
                                                                        avk.SORUMLU_AVUKAT_CARI_ID.Value).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        #endregion ValidateRowEventArgs

        #region AddingNew

        private void DavaEdenler_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF addNew = e.NewObject as AV001_TD_BIL_FOY_TARAF;
            if (e.NewObject == null)
                addNew = new AV001_TD_BIL_FOY_TARAF();

            addNew.DAVA_EDEN_MI = true;
            addNew.TARAF_KODU = 1; //M
            addNew.TARAF_SIFAT_ID = 7; //Davaci

            e.NewObject = addNew;
        }

        private void DavaEdilenler_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_FOY_TARAF addNew = e.NewObject as AV001_TD_BIL_FOY_TARAF;
            if (e.NewObject == null)
                addNew = new AV001_TD_BIL_FOY_TARAF();

            addNew.TARAF_KODU = 3; //K
            addNew.TARAF_SIFAT_ID = 8; //Davali
            addNew.DAVA_EDEN_MI = false;

            e.NewObject = addNew;
        }

        #endregion AddingNew

        //private void gvDavaEden_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_FOY_TARAF seciliTaraf = (AV001_TD_BIL_FOY_TARAF)gvDavaEden.GetRow(e.FocusedRowHandle);
        //    if (seciliTaraf.CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwSorumlular_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_FOY_SORUMLU_AVUKAT seciliAvukat = (AV001_TD_BIL_FOY_SORUMLU_AVUKAT)gwSorumlular.GetRow(e.FocusedRowHandle);

        //    if (seciliAvukat.SORUMLU_AVUKAT_CARI_ID.HasValue)
        //    {
        //        VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
        //        adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_AVUKAT_CARI_ID.ToString(), "ID");
        //        gcIletisimBilgileri.DataSource = adres;
        //    }
        //}

        //private void gwDavaEdilenler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle < 0)
        //        return;

        //    AV001_TD_BIL_FOY_TARAF seciliTaraf = (AV001_TD_BIL_FOY_TARAF)gwDavaEdilenler.GetRow(e.FocusedRowHandle);
    }
}