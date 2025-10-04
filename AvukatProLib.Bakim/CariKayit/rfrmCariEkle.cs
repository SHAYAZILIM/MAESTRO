using AvukatProLib.Bakim.Resources;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AvukatProLib.Bakim.CariKayit
{
    public partial class rfrmCariEkle : XtraForm
    {
        public rfrmCariEkle()
        {
            InitializeComponent();
        }

        public static MemoryStream MyLayout;

        public List<CariStatu> Statuler = new List<CariStatu>();

        public string tmpCariAd = "";

        private string _cariAdi;

        private TList<TDI_KOD_IL> cloneIl = null;

        private TList<TDI_KOD_ILCE> cloneIlce = null;

        private AV001_TDI_BIL_CARI MyCari;

        public string CariAdi
        {
            get { return _cariAdi; }
            set { _cariAdi = value; }
        }

        public AV001_TDI_BIL_CARI myCari
        {
            get
            {
                return MyCari;
            }
            set
            {
                MyCari = value;
                try
                {
                    setCari(value);

                    myCari.ColumnChanged += myCari_ColumnChanged;

                    foreach (AV001_TDI_BIL_CARI_KIMLIK kimlik in myCari.AV001_TDI_BIL_CARI_KIMLIKCollection)
                    {
                        kimlik.ColumnChanged += new AV001_TDI_BIL_CARI_KIMLIKEventHandler(kimlik_ColumnChanged);
                    }
                }
                catch { }
            }
        }

        public bool Kaydet(AV001_TDI_BIL_CARI cari)
        {
            bool b = false;
            //TransactionManager trans = new TransactionManager(Kimlikci.Kimlik.SirketBilgisi.ConStr);

            try
            {
                //trans.BeginTransaction();
                DataRepository.AV001_TDI_BIL_CARIProvider.DeepSave(myCari);
                DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepSave(myCari.AV001_TDI_BIL_CARI_KIMLIKCollection);

                //trans.Commit();
                b = true;
            }
            catch
            {
                //if (trans.IsOpen)
                //    trans.Rollback();
                b = false;
            }
            return b;
        }

        public void setCari(AV001_TDI_BIL_CARI cari)
        {
            if (cari.IsNew && !cari.IsSelected)
            {
                foreach (string s in cari.TableColumns)
                {
                    if (s.EndsWith("DOVIZ_ID"))
                        cari.GetType().GetProperty(s).SetValue(cari, 1, null);
                }
                cari.AV001_TDI_BIL_CARI_KIMLIKCollection = new TList<AV001_TDI_BIL_CARI_KIMLIK>();
            }
            else
            {
                DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
            }

            cari.AV001_TDI_BIL_CARI_KIMLIKCollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_CARI_KIMLIKCollection_AddingNew);
            cari.AV001_TDI_BIL_CARI_KIMLIKCollection.AddNew();
            vgCariKimlik.DataSource = cari.AV001_TDI_BIL_CARI_KIMLIKCollection;
            cari.STATU = "Personel";
            cari.KOD = Inits.CariYeniKodGetir();
            cari.AD = CariAdi;
            vgCariKimlik.DataSource = cari.AV001_TDI_BIL_CARI_KIMLIKCollection;
            TList<AV001_TDI_BIL_CARI> carilist = new TList<AV001_TDI_BIL_CARI>();
            carilist.Add(cari);
            carilist.AddingNew += new AddingNewEventHandler(mydatatableAddingNewItem);
            vgCari.DataSource = carilist;
        }

        private void AV001_TDI_BIL_CARI_KIMLIKCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI_KIMLIK addnew = new AV001_TDI_BIL_CARI_KIMLIK();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = 0;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = "GENEL";
            e.NewObject = addnew;
        }

        private void kimlik_ColumnChanged(object sender, AV001_TDI_BIL_CARI_KIMLIKEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_CARI_KIMLIKColumn.IL)
            {
                Inits.IlceGetirIleGore(rLueKayitliIlce, (int)e.Value);
            }
        }

        private void myCari_ColumnChanged(object sender, AV001_TDI_BIL_CARIEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_CARIColumn.FIRMA_MI)
            {
                AV001_TDI_BIL_CARI myCari = (AV001_TDI_BIL_CARI)sender;
                crowFirma.Visible = myCari.FIRMA_MI;
            }
        }

        private void mydatatableAddingNewItem(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_CARI myCari = (AV001_TDI_BIL_CARI)e.NewObject;
            if (myCari == null)
                myCari = new AV001_TDI_BIL_CARI();
            myCari.KOD = Inits.CariYeniKodGetir();
            myCari.ColumnChanged += new AV001_TDI_BIL_CARIEventHandler(myCari_ColumnChanged);
            e.NewObject = myCari;
        }

        private void rfrmCariEkle_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                myCari = new AV001_TDI_BIL_CARI();

                initKontrol();
            }
        }

        #region LookUpDoldurma

        private void initKontrol()
        {
            Inits.FirmaTurGetir(rlkFirmaTur);
            Inits.MeslekGetir(rlkMeslek);
            Inits.AdresTurGetir(rlkAdresTur);
            Inits.IlceGetirOzetli(rlkTicariSicilYeriIlce);
            Inits.CariGetir(rlkCari);
            Inits.CariUnvanGetir(rlkYCariUnvan);
            Inits.CariUnvanGetir(rlkYCariUnvan2);
            Inits.UlkeGetir(rlkAdresUlke);
            Inits.UlkeGetir(rlkAdresUlke2);
            Inits.BankaGetir(rlkBanka);
            Inits.IsSozlesmeGetir(rlkIsSozlesme);
            Inits.CariTipiGetir(rlkCariTip);
            Inits.IlGetir(rLueKayitliIl);
            Inits.CariGetir(rLueCariID);
            Inits.BelgeTurGetir(rLueBelgeTuru);
            Inits.KimlikVerilisNedenGetir(rLueCuzdaninVerilmeNedeni);
            Inits.MedeniHalGetir(rLueMedeniHal);
            Inits.UyrukGetir(rLueUyruk);
            Inits.KanGrupGetir(rLueKanGrup);
            Inits.KimlikTurGetir(rLueKimlikTuru);
            Inits.CinsiyetGetir(rLuekCinsiyet);
            Inits.CariGetir(rlkReferansCari);
            Inits.CariGetir(rlkYetkiliCari1);
            Inits.CariGetir(rlkYetkiliCari2);
            Inits.IlceGetirTumu(rLueKayitliIlce);
            Inits.IlGetir(rlkAdresIl);
            Inits.IlceGetirTumu(rlkAdresIlce);
            rowStatuChk.Properties.FieldName = "STATU";
            StatuDoldur(rchklSahisStatuleri);
            rlkBankaSube.NullText = "Seç";
            if (rfrmCariEkle.MyLayout != null)
            {
                rfrmCariEkle.MyLayout.Position = 0;
                vgCari.RestoreLayoutFromStream(rfrmCariEkle.MyLayout);
            }

            OzelKodDoldur(new RepositoryItemLookUpEdit[] { rlkOzelKod, rLueOzelKod2, rLueOzelKod3, rLueOzelKod4 });
        }

        private void OzelKodDoldur(RepositoryItemLookUpEdit[] luies)
        {
            TList<AV001_TDI_KOD_CARI_OZEL> obj = DataRepository.AV001_TDI_KOD_CARI_OZELProvider.GetAll();

            foreach (RepositoryItem l in luies)
            {
                if (l is RepositoryItemLookUpEdit)
                {
                    RepositoryItemLookUpEdit lue = l as RepositoryItemLookUpEdit;

                    if (lue.DataSource == null)
                    {
                        lue.BeginUpdate();

                        lue.DataSource = obj;
                        lue.ValueMember = "ID";
                        lue.DisplayMember = "KOD";

                        lue.Columns.Clear();

                        lue.Columns.Add(new LookUpColumnInfo("KOD", 30, "Föy Özel Kod"));
                        lue.EndUpdate();
                    }
                }
            }
        }

        private void StatuDoldur(RepositoryItemCheckedComboBoxEdit cmb)
        {
            cmb.Items.Clear();
            cmb.AutoHeight = true;
            foreach (string st in Enum.GetNames(typeof(AvukatProLib.Extras.CariStatu)))
            {
                cmb.Items.Add(st.ToString().Replace("_", " "));
            }
        }

        #endregion LookUpDoldurma

        private void rlkOzelKod_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            try
            {
                AV001_TDI_KOD_CARI_OZEL ozel = new AV001_TDI_KOD_CARI_OZEL();
                ozel.KOD = e.DisplayValue.ToString();
                DataRepository.AV001_TDI_KOD_CARI_OZELProvider.Insert(ozel);
                ((TList<AV001_TDI_KOD_CARI_OZEL>)rlkOzelKod.DataSource).Add(ozel);
                XtraMessageBox.Show("Özel kod başarıyla eklenmiştir.");
            }
            catch
            {
                XtraMessageBox.Show("Kayıt esnasında bir hata oluştu.");
            }
        }

        private void tbtnKaydet_Click(object sender, EventArgs e)
        {
            if (Kaydet(myCari))
            {
                XtraMessageBox.Show("Kaydedildi", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("Kayıt Esnasında Hata Oluştu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vgCari_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneIl != null)
            {
                cloneIl.Dispose();
                cloneIl = null;
            }
            if (cloneIlce != null)
            {
                cloneIlce.Dispose();
                cloneIlce = null;
            }
        }

        private void vgCari_ShownEditor(object sender, EventArgs e)
        {
            VGridControl gonderen = sender as VGridControl;
            if (gonderen.FocusedRow.Tag != null && gonderen.FocusedRow.Tag.ToString().Contains("Adres") && gonderen.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;

                if (edit.Properties.DisplayField == "IL")
                {
                    TList<TDI_KOD_IL> iller = edit.Properties.DataSource as TList<TDI_KOD_IL>;
                    cloneIl = new TList<TDI_KOD_IL>(iller);
                    AV001_TDI_BIL_CARI cari = gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_CARI;
                    cloneIl.Filter = "ULKE_ID = 0";//Hiçbir kayıt göstermiyoruz.
                    switch (gonderen.FocusedRow.Tag.ToString())
                    {
                        case "Adres1IL":
                            if (cari.ULKE_ID.HasValue)
                                cloneIl.Filter = "ULKE_ID = " + cari.ULKE_ID.Value;
                            break;

                        case "Adres2IL":
                            if (cari.ULKE_ID.HasValue)
                                cloneIl.Filter = "ULKE_ID = " + cari.ULKE2_ID.Value;
                            break;

                        case "Adres3IL":
                            if (cari.ULKE_ID.HasValue)
                                cloneIl.Filter = "ULKE_ID = " + cari.ULKE3_ID.Value;
                            break;

                        default:
                            break;
                    }
                    edit.Properties.DataSource = cloneIl;
                }
                else if (edit.Properties.DisplayField == "ILCE")
                {
                    TList<TDI_KOD_ILCE> ilceler = edit.Properties.DataSource as TList<TDI_KOD_ILCE>;
                    cloneIlce = new TList<TDI_KOD_ILCE>(ilceler);
                    AV001_TDI_BIL_CARI cari = gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_CARI;
                    cloneIlce.Filter = "IL_ID = 0"; // Hiç bir kayıt göstermiyoruz
                    switch (gonderen.FocusedRow.Tag.ToString())
                    {
                        case "Adres1ILCE":
                            if (cari.IL_ID.HasValue)
                                cloneIlce.Filter = "IL_ID = " + cari.IL_ID.Value;
                            break;

                        case "Adres2ILCE":
                            if (cari.IL2_ID.HasValue)
                                cloneIlce.Filter = "IL_ID = " + cari.IL2_ID.Value;
                            break;

                        case "AdresILCE":
                            if (cari.IL3_ID.HasValue)
                                cloneIlce.Filter = "IL_ID = " + cari.IL3_ID.Value;
                            break;

                        default:
                            break;
                    }
                    edit.Properties.DataSource = cloneIlce;
                }
            }
        }

        private void vgCariKimlik_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneIl != null)
            {
                cloneIl.Dispose();
                cloneIl = null;
            }
            if (cloneIlce != null)
            {
                cloneIlce.Dispose();
                cloneIlce = null;
            }
        }

        private void vgCariKimlik_ShownEditor(object sender, EventArgs e)
        {
            VGridControl gonderen = sender as VGridControl;
            if (gonderen.FocusedRow.Tag != null && gonderen.FocusedRow.Tag.ToString().Contains("Adres") && gonderen.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;

                if (edit.Properties.DisplayField == "ILCE")
                {
                    TList<TDI_KOD_ILCE> ilceler = edit.Properties.DataSource as TList<TDI_KOD_ILCE>;
                    cloneIlce = new TList<TDI_KOD_ILCE>(ilceler);
                    AV001_TDI_BIL_CARI_KIMLIK carikim = gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_CARI_KIMLIK;
                    cloneIlce.Filter = "IL_ID = 0"; // Hiç bir kayıt göstermiyoruz
                    switch (gonderen.FocusedRow.Tag.ToString())
                    {
                        case "Adres1ILCE":
                            if (carikim.NKO_IL_ID.HasValue)
                                cloneIlce.Filter = "IL_ID = " + carikim.NKO_IL_ID.Value;
                            break;

                        default:
                            break;
                    }
                    edit.Properties.DataSource = cloneIlce;
                }
            }
        }
    }
}