using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace AdimAdimDavaKaydi.Sozlesme.Forms.Sozlesme.Util
{
    public partial class ucSozlesmeTarafBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSozlesmeTarafBilgileri()
        {
            InitializeComponent();
        }

        #region Fields

        private static int _currTarafId;
        private AV001_TDI_BIL_SOZLESME _mySozlesme;
        private bool isChanged;

        #endregion Fields

        #region Properties

        private TList<AV001_TDI_BIL_SOZLESME_TARAF> _SozlesmeYapan;

        private TList<AV001_TDI_BIL_SOZLESME_TARAF> _SozlesmeYapilan;
                
        [Browsable(false)]
        public static int CurrTarafID
        {
            get { return ucSozlesmeTarafBilgileri._currTarafId; }
            set { ucSozlesmeTarafBilgileri._currTarafId = value; }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_TEBLIGAT_MUHATAP CurrMuhatap
        {
            get { return null; }
        }

        [Browsable(false)]
        public Direction Dir { get; set; }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return _mySozlesme; }
            set
            {
                _mySozlesme = value;
                if (_mySozlesme != null && this.DesignMode == false)
                {
                    SetSozlesme();
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF> SozlesmeYapan
        {
            get
            {
                if (gcSozlesmeYapan.DataSource is TList<AV001_TDI_BIL_SOZLESME_TARAF>)
                    return (TList<AV001_TDI_BIL_SOZLESME_TARAF>)gcSozlesmeYapan.DataSource;
                return _SozlesmeYapan;
            }
            set
            {
                if (value != null)
                {
                    _SozlesmeYapan = value;
                    value.AddingNew += SozlesmeYapan_AddingNew;
                }
            }
        }

        [Browsable(false)]
        public List<RepositoryItemLookUpEdit> SozlesmeYapanControls { get; set; }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF> SozlesmeYapilan
        {
            get
            {
                if (gcSozlesmeYapilan.DataSource is TList<AV001_TDI_BIL_SOZLESME_TARAF>)
                    return (TList<AV001_TDI_BIL_SOZLESME_TARAF>)gcSozlesmeYapilan.DataSource;
                return _SozlesmeYapilan;
            }
            set
            {
                if (value != null)
                {
                    _SozlesmeYapilan = value;
                    value.AddingNew += SozlesmeYapilan_AddingNew;
                }
            }
        }

        [Browsable(false)]
        public List<RepositoryItemLookUpEdit> SozlesmeYapilanControls { get; set; }

        #endregion Properties

        #region Enums

        public enum Direction
        {
            Previous = 0,
            Next = 1
        }

        public enum SozlesmeTarafKodu
        {
            SozlesmeYapan = 1,
            SozlesmeYapilan = 3,
            Diger = 2
        }

        #endregion Enums

        #region Events

        #endregion Events

        #region Private Methods

        private void AddTaraf(AV001_TDI_BIL_SOZLESME_TARAF trf)
        {
            AV001_TDI_BIL_SOZLESME_TARAF temp =
                MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Find(AV001_TDI_BIL_SOZLESME_TARAFColumn.CARI_ID,
                                                                       trf.CARI_ID.Value);
            if (temp == null)
            {
                trf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(trf.CARI_ID.Value);
                MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Add(trf);
                TarafRefresh(true);
            }
        }

        private void LoadData()
        {
            BelgeUtil.Inits.perCariGetir(rLueCariler);
            BelgeUtil.Inits.perCariGetir(rLueSozlesmeYapilan);
            BelgeUtil.Inits.AktifAvukatlariGetir(rLueCariAvukat);

            #region TarafKoduHazirla

            BelgeUtil.Inits.SozlesmeTarafKoduGetir(rLueSikayetEdenTK);
            BelgeUtil.Inits.SozlesmeTarafKoduGetir(rLueSikayetEdilenTK);

            #endregion TarafKoduHazirla

            #region TarafSifatHazirla

            BelgeUtil.Inits.SozlesmeTarafSifatGetir(rLueSikayetEdenSifat);
            BelgeUtil.Inits.SozlesmeTarafSifatGetir(rLueSikayetEdilenSifat);

            #endregion TarafSifatHazirla
        }

        private void rLueCariler_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null && e.OldValue != null)
            {
                try
                {
                    for (int i = 0; i < MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; i++)
                    {
                        if (MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID == (int)e.OldValue)
                        {
                            MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_IDSource =
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

        private void SetSozlesme()
        {
            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme, true, DeepLoadType.IncludeChildren
                                                                   , typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>)
                                                                   , typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));

            TarafBind();

            MySozlesme.ColumnChanged += MySozlesme_ColumnChanged;
            MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.AddingNew +=
                AV001_TDI_BIL_SOZLESME_SORUMLUCollection_AddingNew;

            foreach (AV001_TDI_BIL_SOZLESME_TARAF trf in MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection)
            {
                trf.ColumnChanged += trf_ColumnChanged;
                if (trf.CARI_IDSource == null)
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(trf, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(AV001_TDI_BIL_CARI));
            }

            rLueCariler.EditValueChanging += rLueCariler_EditValueChanging;
        }

        private void TarafBind()
        {
            TList<AV001_TDI_BIL_CARI> carilist = new TList<AV001_TDI_BIL_CARI>();

            if (SozlesmeYapan == null)
                SozlesmeYapan = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
            if (SozlesmeYapilan == null)
                SozlesmeYapilan = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();

            SozlesmeYapan.Clear();
            SozlesmeYapilan.Clear();
            foreach (AV001_TDI_BIL_SOZLESME_TARAF trf in MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection)
            {
                if (trf.CARI_IDSource == null)
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(trf, false,
                                                                                 DeepLoadType.IncludeChildren,
                                                                                 typeof(AV001_TDI_BIL_CARI),
                                                                                 typeof(TDIE_KOD_TARAF_SIFAT),
                                                                                 typeof(
                                                                                     TList<AV001_TDI_BIL_CARI_KIMLIK>));
                carilist.Add(trf.CARI_IDSource);
                if (trf.TARAF_KODU == (int)SozlesmeTarafKodu.SozlesmeYapan)
                    SozlesmeYapan.Add(trf);
                if (trf.TARAF_KODU == (int)SozlesmeTarafKodu.SozlesmeYapilan)
                    SozlesmeYapilan.Add(trf);
            }

            //SikayetEdenler
            gcSozlesmeYapan.BeginUpdate();
            gcSozlesmeYapan.DataSource = SozlesmeYapan;
            gcSozlesmeYapan.EndUpdate();

            //SikayetEdilenler

            gcSozlesmeYapilan.BeginUpdate();
            gcSozlesmeYapilan.DataSource = SozlesmeYapilan;
            gcSozlesmeYapilan.EndUpdate();

            //Avukatlar
            gcSorumlular.BeginUpdate();
            gcSorumlular.DataSource = MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection;
            gcSorumlular.EndUpdate();

            AV001_TDI_BIL_SOZLESME_TARAF seciliTaraf = null;
            if (SozlesmeYapilan.Count > 0)
                seciliTaraf = SozlesmeYapilan[0];

            if (seciliTaraf != null && seciliTaraf.CARI_ID.HasValue)
            {
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }

            //LueTarafDoldur
            lueTaraf_EditValueChanged(null, null);
        }

        private void TarafRefresh(bool IsNew)
        {
            TList<AV001_TDI_BIL_CARI> carilist = new TList<AV001_TDI_BIL_CARI>();
            foreach (AV001_TDI_BIL_SOZLESME_TARAF trf in MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection)
            {
                if (trf.CARI_IDSource == null)
                    DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(trf, true, DeepLoadType.IncludeChildren,
                                                                                 typeof(AV001_TDI_BIL_CARI));
                carilist.Add(trf.CARI_IDSource);
            }
        }

        private void btnIletisimBilgileriniDuzenle_Click(object sender, EventArgs e)
        {
            if (gcIletisimBilgileri.DataSource != null)
            {
                VList<per_CariKimlikIletisimBilgileri> guncellenecekCari = (VList<per_CariKimlikIletisimBilgileri>)gcIletisimBilgileri.DataSource;

                AV001_TDI_BIL_CARI cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(guncellenecekCari[0].ID);
                frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCari = cari;
                cariForms.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
            else
                XtraMessageBox.Show("Güncellenecek þahýs seçiniz!");
        }

        private void gwSorumluAvukat_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSorumluAvukat.FocusedRowHandle)
            {
                AV001_TDI_BIL_SOZLESME_SORUMLU seciliAvukat = (AV001_TDI_BIL_SOZLESME_SORUMLU)gwSorumluAvukat.GetRow(e.RowHandle);

                if (seciliAvukat.SORUMLU_CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliAvukat.SORUMLU_CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwSozlesmeYapan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSozlesmeYapan.FocusedRowHandle)
            {
                AV001_TDI_BIL_SOZLESME_TARAF seciliTaraf = (AV001_TDI_BIL_SOZLESME_TARAF)gwSozlesmeYapan.GetRow(e.RowHandle);
                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void gwSozlesmeYapilan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle == gwSozlesmeYapilan.FocusedRowHandle)
            {
                AV001_TDI_BIL_SOZLESME_TARAF seciliTaraf = (AV001_TDI_BIL_SOZLESME_TARAF)gwSozlesmeYapilan.GetRow(e.RowHandle);

                if (seciliTaraf.CARI_ID.HasValue)
                {
                    VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                    adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                    gcIletisimBilgileri.DataSource = adres;
                }
            }
        }

        private void TarafGorusmelerCariBinding(int TarafId)
        {
            AV001_TDI_BIL_CARI cari = null;

            MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Filter = string.Format("CARI_ID = {0} ", CurrTarafID);
            if (MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count > 0)
            {
                cari = MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[0].CARI_IDSource;

                if (cari != null)
                {
                    if (cari.REFERANS_CARI_IDSource == null)
                    {
                        if (cari.REFERANS_CARI_ID > 0)
                            cari.REFERANS_CARI_IDSource =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cari.REFERANS_CARI_ID.Value);
                    }

        #endregion Private Methods

                    else if (!cari.FIRMA_MI)
                    {
                        if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count == 0)
                        {
                            DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                        }

                        //Kayýtlý Olan Son Kimlik Bilgilerini Alýnýyor.
                        if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
                            cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Sort("KAYIT_TARIHI DESC");
                    }
                }
            }
            MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Filter = string.Empty;
        }

        private void ucSozlesmeTarafBilgileri_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            CheckForIllegalCrossThreadCalls = false;
            LoadData();

            if (MySozlesme == null)
                MySozlesme = new AV001_TDI_BIL_SOZLESME();

            gwSozlesmeYapan.ValidateRow += gwSozlesmeYapan_ValidateRow;
            gwSozlesmeYapilan.ValidateRow += gwSozlesmeYapilan_ValidateRow;
            gwSorumluAvukat.ValidateRow += gwSorumluAvukat_ValidateRow;

            SozlesmeYapan = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
            SozlesmeYapilan = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
        }

        #region Columns_Changed

        private void AV001_TDI_BIL_SOZLESME_SORUMLUCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_SORUMLU addnew = new AV001_TDI_BIL_SOZLESME_SORUMLU();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private void MySozlesme_ColumnChanged(object sender, AV001_TDI_BIL_SOZLESMEEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void trf_ColumnChanged(object sender, AV001_TDI_BIL_SOZLESME_TARAFEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion Columns_Changed

        #region LookUpEdit_EventArgs

        private string   adres = string.Empty;

        private void gwSorumluAvukat_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_SORUMLU rowAvukat = (AV001_TDI_BIL_SOZLESME_SORUMLU)e.Row;
            if (!rowAvukat.SORUMLU_CARI_ID.HasValue && rowAvukat.SORUMLU_CARI_IDSource == null)
            {
                e.ErrorText = "Lütfen Bir Sorumlu Seçiniz." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (
                MySozlesme.AV001_TDI_BIL_SOZLESME_SORUMLUCollection.FindAll("SORUMLU_CARI_IDSource",
                                                                            rowAvukat.SORUMLU_CARI_IDSource).Count > 1)
            {
                e.ErrorText = "Bu Sorumlu Zaten Eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
        }

        private void gwSozlesmeYapan_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF sozlesmetrf = (AV001_TDI_BIL_SOZLESME_TARAF)e.Row;

            if (!sozlesmetrf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Sikayet Eden Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!sozlesmetrf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (sozlesmetrf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SozlesmeYapan != null)
            {
                if (SozlesmeYapan.FindAll("CARI_ID", sozlesmetrf.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Sikayet Eden Kiþi Zaten Eklenmiþ" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (SozlesmeYapilan.FindAll("CARI_ID", sozlesmetrf.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Sahýþ Sikayet Edilen Taraf Olarak Zaten Eklenmiþ." + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            if (e.Valid)
            {
                AddTaraf(sozlesmetrf);
            }
        }

        private void gwSozlesmeYapilan_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF sozlesmetrf = (AV001_TDI_BIL_SOZLESME_TARAF)e.Row;
            if (!sozlesmetrf.CARI_ID.HasValue)
            {
                e.ErrorText = "Bir Sikayet Edilen Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (!sozlesmetrf.TARAF_SIFAT_ID.HasValue)
            {
                e.ErrorText = "Bir Taraf Sýfatý Seçilmelidir" + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (sozlesmetrf.TARAF_KODU == 0)
            {
                e.ErrorText = "Bir Taraf Kodu Seçilmelidir." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (SozlesmeYapilan != null)
            {
                if (SozlesmeYapilan.FindAll("CARI_ID", sozlesmetrf.CARI_ID).Count > 1)
                {
                    e.ErrorText = "Bu Sikayet Edilen Kiþi Zaten Eklenmiþ" + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
                if (SozlesmeYapan.FindAll("CARI_ID", sozlesmetrf.CARI_ID).Count > 0)
                {
                    e.ErrorText = "Bu Sahýþ Sikayet Eden Taraf Olarak Zaten Eklenmiþ." + Environment.NewLine;
                    e.Valid = false;
                    return;
                }
            }
            if (e.Valid)
            {
                AddTaraf(sozlesmetrf);
            }
        }

        private void lueTaraf_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrTarafID == 0 || !isChanged) return;

                TarafGorusmelerCariBinding(CurrTarafID);

                AV001_TDI_BIL_SOZLESME_TARAF taraf = MySozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Find(
                    delegate(AV001_TDI_BIL_SOZLESME_TARAF t) { return (t.CARI_ID == CurrTarafID); });
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        #region AddNew

        private void SozlesmeYapan_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF addnew;

            if (e.NewObject == null)
                addnew = new AV001_TDI_BIL_SOZLESME_TARAF();
            else
                addnew = e.NewObject as AV001_TDI_BIL_SOZLESME_TARAF;

            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdenTK.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
            else
            {
                string[] boll = ((TList<TDI_KOD_TARAF>)rLueSikayetEdenTK.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(boll[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
            }
            e.NewObject = addnew;
        }

        private void SozlesmeYapilan_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF addnew;
            if (e.NewObject == null)
                addnew = new AV001_TDI_BIL_SOZLESME_TARAF();
            else
                addnew = e.NewObject as AV001_TDI_BIL_SOZLESME_TARAF;

            if (String.IsNullOrEmpty(((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTK.DataSource).Filter))
                addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
            else
            {
                string[] boll = ((TList<TDI_KOD_TARAF>)rLueSikayetEdilenTK.DataSource).Filter.Split(' ');
                if (Convert.ToBoolean(boll[2]))
                {
                    addnew.TARAF_KODU = (int)TarafKodu.Muvekkil;
                }
                else
                {
                    addnew.TARAF_KODU = (int)TarafKodu.KarsiTaraf;
                }
            }
            e.NewObject = addnew;
        }

        #endregion AddNew

        #endregion LookUpEdit_EventArgs
    }
}