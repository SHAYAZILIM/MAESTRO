using AdimAdimDavaKaydi.AnaForm;
using AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.PaketKontrol;
namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmAdimAdimIcraKaydi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmAdimAdimIcraKaydi()
        {
            InitializeComponent();
            InitializeEvents();
            this.Button_Editor_Click += frmAdimAdimIcraKaydi_Button_Editor_Click;
        }

        private static int ilkFormTipId;

        private AvukatProLib.Extras.FormTipi f;

        private bool finish;

        private int formKodId;

        private int formKonusu;

        private bool kiymetliEvrakCheck;

        private int kiymetliEvrakID;

        private AV001_TI_BIL_FOY myFoy;

        private bool sozlesmeCheck;

        private int sozlesmeID;

        private TList<AV001_TDI_BIL_SOZLESME> szListBagýmsýz = new TList<AV001_TDI_BIL_SOZLESME>();

        private string tempFoyNo = string.Empty;

        public event EventHandler<BelgeUtil.IcraFoyKaydedildiEventArgs> IcraFoyKaydedildi;

        public enum DataKontrol
        {
            GayriMenkul,
            Arac
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> Alacakli
        {
            get { return (TList<AV001_TI_BIL_FOY_TARAF>)lstAlacaklilar.DataSource; }
            set
            {
                lstAlacaklilar.DataSource = value;
                if (value != null)
                {
                    value.AddingNew += Alacakli_AddingNew;

                    value.ListChanged += Alacakli_ListChanged;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF_VEKIL> AlacakliVekil
        {
            get { return (TList<AV001_TI_BIL_FOY_TARAF_VEKIL>)gcAlacakliVekil.DataSource; }
            set
            {
                gcAlacakliVekil.DataSource = value;

                AlacakliVekil.AddingNew += AlacakliVekil_AddingNew;

                AlacakliVekil.ListChanged += AlacakliVekil_ListChanged;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> Borclu
        {
            get { return (TList<AV001_TI_BIL_FOY_TARAF>)lstBorclular.DataSource; }
            set
            {
                lstBorclular.DataSource = value;
                if (value != null)
                {
                    value.AddingNew += Borclu_AddingNew;

                    value.ListChanged += Borclu_ListChanged;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF_VEKIL> BorcluVekil
        {
            get { return (TList<AV001_TI_BIL_FOY_TARAF_VEKIL>)gcBorcluVekil.DataSource; }
            set
            {
                gcBorcluVekil.DataSource = value;
                BorcluVekil.AddingNew += BorcluVekil_AddingNew;

                BorcluVekil.ListChanged += BorcluVekil_ListChanged;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;

                BindingFoy();

                MyFoy.ColumnChanged += MyFoy_ColumnChanged;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FOY_TARAF> TumTaraflar
        {
            get
            {
                TList<AV001_TI_BIL_FOY_TARAF> result = new TList<AV001_TI_BIL_FOY_TARAF>();
                result.AddRange(Alacakli);
                result.AddRange(Borclu);
                return result;
            }
        }

        public void AlacakNedenTarafYapilandir(AV001_TI_BIL_ALACAK_NEDEN ndn)
        {
            if (ndn == null)
                return;
            if (ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
                return;

            //if (ndn.ISLEME_KONAN_TUTAR > 0 && ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
            //{
            foreach (AV001_TI_BIL_FOY_TARAF taraf in Borclu)
            {
                AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();

                //TODO: Managed code haline çevir
                foreach (string s in trf.TableColumns)
                {
                    if (s.EndsWith("DOVIZ_ID"))
                        trf.GetType().GetProperty(s).SetValue(trf, 1, null);
                }
                trf.TARAF_CARI_ID = taraf.CARI_ID.Value;
                if (taraf.CARI_ID.HasValue)
                    trf.TARAF_CARI_ADI = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value).AD;
                else trf.TARAF_CARI_ADI = "<Cari Seçilmemiþ>";
                trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection =
                    new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>();
                trf.SORUMLU_OLUNAN_MIKTAR = ndn.ISLEME_KONAN_TUTAR;
                trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = ndn.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                trf.PROTESTO_GIDERI = ndn.PROTESTO_GIDERI;
                trf.PROTESTO_GIDERI_DOVIZ_ID = ndn.PROTESTO_GIDERI_DOVIZ_ID.Value;
                trf.IHTAR_GIDERI = ndn.IHTAR_GIDERI;
                trf.IHTAR_GIDERI_DOVIZ_ID = ndn.IHTAR_GIDERI_DOVIZ_ID.Value;
                trf.CEK_TAZMINATI_ORANI = ndn.CEK_TAZMINATI_ORANI;
                trf.KOMISYONU_ORANI = ndn.KOMISYONU_ORANI;
                trf.IHTAR_TARIHI = ndn.IHTAR_TARIHI;
                trf.KAYIT_TARIHI = DateTime.Now;
                trf.KLASOR_KODU = "GENEL";
                trf.KONTROL_KIM = "AVUKATPRO";
                trf.KONTROL_NE_ZAMAN = DateTime.Now;
                trf.STAMP = 1;
                ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Add(trf);

                MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddRange(ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
            }

            //}
            if ((ndn.TO_ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.TO_UYGULANACAK_FAIZ_ORANI > 0)) &&
                ndn.FAIZ_BASLANGIC_TARIHI.HasValue)
            {
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();
                    faiz.FAIZ_BASLANGIC_TARIHI = ndn.VADE_TARIHI.Value;
                    faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI.Value;
                    faiz.FAIZ_TIP_ID = ndn.TO_ALACAK_FAIZ_TIP_ID;
                    faiz.FAIZ_ORANI = ndn.TO_UYGULANACAK_FAIZ_ORANI;
                    faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                    faiz.KAYIT_TARIHI = DateTime.Now;
                    faiz.KLASOR_KODU = "GENEL";
                    faiz.KONTROL_KIM = "AVUKATPRO";
                    faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                    faiz.STAMP = 1;
                    trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                }
            }
            if ((ndn.ALACAK_FAIZ_TIP_ID.HasValue || (ndn.SABIT_FAIZ_UYGULA && ndn.UYGULANACAK_FAIZ_ORANI > 0)))
            {
                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF trf in ndn.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection)
                {
                    bool gerekVar = true;
                    if (ndn.SABIT_FAIZ_UYGULA &&
                        (trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                         trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_ORANI == ndn.UYGULANACAK_FAIZ_ORANI))
                    {
                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = DateTime.Today;
                        gerekVar = false;
                    }
                    if (!ndn.SABIT_FAIZ_UYGULA && trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Count > 0 &&
                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_TIP_ID.Value ==
                        ndn.ALACAK_FAIZ_TIP_ID.Value)
                    {
                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection[0].FAIZ_BITIS_TARIHI = DateTime.Today;
                        gerekVar = false;
                    }
                    if (gerekVar)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ faiz = new AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ();

                        faiz.FAIZ_BASLANGIC_TARIHI = ndn.VADE_TARIHI.Value;
                        faiz.FAIZ_BITIS_TARIHI = myFoy.TAKIP_TARIHI.Value;
                        faiz.FAIZ_TIP_ID = ndn.ALACAK_FAIZ_TIP_ID;
                        faiz.FAIZ_ORANI = ndn.UYGULANACAK_FAIZ_ORANI;
                        faiz.SABIT_FAIZ = ndn.SABIT_FAIZ_UYGULA;
                        faiz.KAYIT_TARIHI = DateTime.Now;
                        faiz.KLASOR_KODU = "GENEL";
                        faiz.KONTROL_KIM = "AVUKATPRO";
                        faiz.KONTROL_NE_ZAMAN = DateTime.Now;
                        faiz.STAMP = 1;
                        trf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Add(faiz);
                    }
                }
            }

            #region AlacakNedeninden ÇekSenet Oluþturma

            if (ndn.ALACAK_NEDEN_KOD_IDSource == null && !ndn.IsNew)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(ndn,
                                                                                             true,
                                                                                             AvukatProLib2.
                                                                                                 Data.
                                                                                                 DeepLoadType
                                                                                                 .
                                                                                                 IncludeChildren,
                                                                                             typeof(
                                                                                                 TI_KOD_ALACAK_NEDEN
                                                                                                 ));
            }
            else if (ndn.ALACAK_NEDEN_KOD_IDSource == null && ndn.IsNew)
            {
                ndn.ALACAK_NEDEN_KOD_IDSource = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                    ndn.ALACAK_NEDEN_KOD_ID.Value);
            }

            #region Kýymetli Evrak taraf

            #region

            KiymetliEvrakTarafTip kTarafTipBorclu = new KiymetliEvrakTarafTip();
            KiymetliEvrakTarafTip kTarafTipAlacakli = new KiymetliEvrakTarafTip();
            TDI_KOD_KIYMETLI_EVRAK_TUR keTur = null;
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK> keList = null;
            TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> keTarafList = null;
            switch (ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI)
            {
                case "ÇEK":
                    keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                    kTarafTipBorclu = KiymetliEvrakTarafTip.Kesideci_Borclu;
                    kTarafTipAlacakli = KiymetliEvrakTarafTip.Alacakli;
                    break;

                case "SENET":
                    keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                    kTarafTipBorclu = KiymetliEvrakTarafTip.Borclu;
                    kTarafTipAlacakli = KiymetliEvrakTarafTip.Alacakli;
                    break;

                case "BONO":
                    keTur = AvukatProLib2.Data.DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByTUR(
                        ndn.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI);

                    kTarafTipAlacakli = KiymetliEvrakTarafTip.Lehtar;
                    kTarafTipBorclu = KiymetliEvrakTarafTip.Kesideci_Borclu;
                    break;

                default:
                    break;
            }

            #endregion Kýymetli Evrak taraf

            #region

            if (keTur != null)
            {
                keList = ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
                keList.AddingNew += keList_AddingNew;
                AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = null;
                if (keList.Count > 0)
                    kEvrak = keList[0];
                else
                    kEvrak = keList.AddNew();

                kEvrak.EVRAK_TUR_ID = keTur.ID;
                kEvrak.EVRAK_KAYIT_TARIHI = DateTime.Today;
                kEvrak.EVRAK_TUR_IDSource = keTur;
                kEvrak.EVRAK_VADE_TARIHI = ndn.VADE_TARIHI;
                kEvrak.EVRAK_TANZIM_TARIHI = ndn.DUZENLENME_TARIHI;
                kEvrak.TUTAR = ndn.TUTARI;
                kEvrak.TUTAR_DOVIZ_ID = ndn.TUTAR_DOVIZ_ID;
                kEvrak.TUTAR_DOVIZ_IDSource = ndn.TUTAR_DOVIZ_IDSource;

            #endregion AlacakNedeninden ÇekSenet Oluþturma

            #endregion

                #region Kullanýlmayan

                //kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
                //kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddingNew += new AddingNewEventHandler(AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew);

                #endregion

                keTarafList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
                keTarafList.AddingNew += AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew;

                for (int i = 0; i < TumTaraflar.Count; i++)
                {
                    AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF keTaraf = keTarafList.AddNew();

                    keTaraf.TARAF_CARI_ID = TumTaraflar[i].CARI_ID.Value;
                    if (Alacakli.Contains(TumTaraflar[i]))
                        keTaraf.TARAF_TIP_ID = (int)kTarafTipAlacakli;

                    else if (Borclu.Contains(TumTaraflar[i]))
                        keTaraf.TARAF_TIP_ID = (int)kTarafTipBorclu;

                    keTaraf.TAKIBE_KONULDU_MU = true;
                }

                kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Clear();
                kEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddRange(keTarafList);
            }
            ucKiymetliEvrak.MyDataSource = keList;
            ucKiymetliEvrak.RefreshDataSource();
            ucKiymetliEvrakTaraf1.MyDataSource = keTarafList;
            ucKiymetliEvrakTaraf1.Refresh();

            if (!MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Contains(ndn))
                MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Add(ndn);

            #endregion
        }

        public void DataDoldur(DataKontrol dk)
        {
            switch (dk)
            {
                case DataKontrol.Arac:
                    break;

                case DataKontrol.GayriMenkul:
                    MyFoy.AV001_TI_BIL_GAYRIMENKULCollection.AddingNew += AV001_TI_BIL_GAYRIMENKULCollection_AddingNew;
                    ucGayriMenkul1.MyDataSource = myFoy.AV001_TI_BIL_GAYRIMENKULCollection;
                    break;
            }
        }

        public void OzelTanimCheckEt()
        {
            if (lueOzelKod1.Text != "" && lueOzelKod2.Text != "" && lueOzelKod3.Text != "" && lueOzelKod4.Text != "" &&
                txtRef1.Text != "" && txtRef2.Text != "" && txtRef3.Text != "")
            {
                ucAdimTree1.NodeChecked("Özel Tanýmlar");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Tanýmlar");
            }
        }

        private void Alacakli_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF addNew = new AV001_TI_BIL_FOY_TARAF();
            addNew.ColumnChanged += AlacakliItem_ColumnChanged;
            addNew.TARAF_SIFAT_ID = ((TDIE_KOD_TARAF_SIFAT)lueAlacakliSifat.EditValue).ID;

            addNew.CARI_ID = (int)lueAlacakliTaraf.EditValue;

            //TODO : Eklenen Alacaklý Takip Eden olacagý için onun takip edenmi ozelligini true yaptým. Editorde hata veriordu . Bu deðeri set edelim lutfen uygun bi þeilde  22 aralik 2008 11 : 00 Ersin ...
            addNew.TAKIP_EDEN_MI = true;
            if (M_1.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 1;
                K_1.Enabled = false;
            }
            else if (K_1.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 3;
                M_1.Enabled = false;
                D_1.Enabled = false;
            }
            else if (D_1.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 2;
                K_1.Enabled = false;
            }

            addNew.IsSelected = false;
            e.NewObject = addNew;

            MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(Alacakli);
        }

        private void Alacakli_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (gwAlacakli.RowCount <= 0)
                {
                    K_1.Enabled = true;
                    M_1.Enabled = true;
                    D_1.Enabled = true;
                }

                #region Kapanmýþ

                //if (AlacakliVekil.Count > 0)
                //{
                //    for (int i = 0; i < AlacakliVekil.Count; i++)
                //    {
                //        if (AlacakliVekil[i].FOY_TARAF_CARI_ID.Value == secilen.CARI_ID.Value)
                //        {
                //            AlacakliVekil.Remove(AlacakliVekil[i]);
                //        }
                //    }
                //}

                #endregion
            }

            wpAdim6.AllowNext = Alacakli.Count > 0;

            if (wpAdim6.AllowNext)
            {
                ucAdimTree1.NodeChecked("Alacaklýlar");
                ucAdimTree1.NodeChecked("Alacaklý Taraf");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Alacaklýlar");
                ucAdimTree1.NodeUnChecked("Alacaklý Taraf");
            }
        }

        private void AlacakliItem_ColumnChanged(object sender, AV001_TI_BIL_FOY_TARAFEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF gonderen = (AV001_TI_BIL_FOY_TARAF)sender;
            if (e.Column == AV001_TI_BIL_FOY_TARAFColumn.CARI_ID)
            {
                TList<AV001_TDI_BIL_CARI> cariLer = lueAlacakliTaraf.Properties.DataSource as TList<AV001_TDI_BIL_CARI>;
                if (cariLer != null && gonderen.CARI_ID.HasValue)
                {
                    AV001_TDI_BIL_CARI cari = cariLer.Find("ID", gonderen.CARI_ID.Value);
                    if (cari != null)
                    {
                        gonderen.CARI_IDSource = cari;
                    }
                }
            }
            else if (e.Column == AV001_TI_BIL_FOY_TARAFColumn.TARAF_SIFAT_ID)
            {
                TList<TDIE_KOD_TARAF_SIFAT> cariSifat =
                    lueAlacakliSifat.Properties.DataSource as TList<TDIE_KOD_TARAF_SIFAT>;
                if (cariSifat != null && gonderen.TARAF_SIFAT_ID != null)
                {
                    TDIE_KOD_TARAF_SIFAT sifat = cariSifat.Find("ID", gonderen.TARAF_SIFAT_ID);
                    if (sifat != null)
                    {
                        gonderen.TARAF_SIFAT_IDSource = sifat;
                    }
                }
            }
        }

        private bool AlacaklilardaBorcluTarafVarmi(int TarafCariId)
        {
            foreach (AV001_TI_BIL_FOY_TARAF trf in Alacakli)
            {
                if (trf.CARI_ID.Value == TarafCariId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool AlacakliTarafVarmi(int TarafCariId)
        {
            foreach (AV001_TI_BIL_FOY_TARAF trf in Alacakli)
            {
                if (trf.CARI_ID.Value == TarafCariId)
                {
                    return true;
                }
            }
            return false;
        }

        private void AlacakliVekil_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF_VEKIL addNew = new AV001_TI_BIL_FOY_TARAF_VEKIL();

            addNew.AVUKAT_CARI_ID = ((AV001_TDI_BIL_CARI)lueAlacakliVekil.EditValue).ID;
            addNew.AVUKAT_CARI_IDSource = (AV001_TDI_BIL_CARI)lueAlacakliVekil.EditValue;

            addNew.TEMSIL_SEKLI_ID = ((TDI_KOD_TEMSIL_TUR)lueTemsilTuru.EditValue).ID;

            e.NewObject = addNew;

            AlacakliVekil.ListChanged += AlacakliVekil_ListChanged;
        }

        private void AlacakliVekil_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (AlacakliVekil.Count > 0)
            {
                //ucAdimTree1.NodeChecked("Alacaklý Taraf Vekil");

                ucAdimTree1.NodeChecked(new[] { "Alacaklý Vekilleri" });
            }
            else
                ucAdimTree1.NodeUnChecked("Alacaklý Taraf Vekil");
        }

        private void alacakNeden_ColumnChanged(object sender, AV001_TI_BIL_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN gelen = sender as AV001_TI_BIL_ALACAK_NEDEN;
            if (gelen.ALACAK_NEDEN_KOD_ID.HasValue)
                switch (gelen.ALACAK_NEDEN_KOD_ID.Value)
                {
                    case 52: //Telefon Faturasý
                    case 4: //	153	FATURA
                    case 37: //	49	FATURA
                    case 81: //	49	KAÇAK ELEKTRÝK FATURASI
                    case 82: //	49	ELEKTRÝK FATURASI
                    case 84: //	49	TESVÝYE
                    case 88: //	49	TESCÝL
                    case 89: //	49	TEFTÝÞ
                        gelen.KDV_HESAPLANSIN = false;
                        gelen.SABIT_FAIZ_UYGULA = false;

                        break;

                    case 42: //	49	TELEFON FATURASI
                    case 51: //	153	TELEFON FATURASI
                        gelen.KDV_HESAPLANSIN = true;
                        gelen.OIV_HESAPLANSIN = true;
                        break;

                    case 49: //KREDI KARTI
                    case 50: //KREDI ALACAÐI

                        gelen.BSMV_HESAPLANSIN = true;
                        break;
                        
                }
        }

        private void AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF keTaraf = new AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF();
            keTaraf.KAYIT_TARIHI = DateTime.Now;
            keTaraf.KONTROL_NE_ZAMAN = DateTime.Now;
            keTaraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            keTaraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            keTaraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            keTaraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = keTaraf;
        }

        private void AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK_ListChanged(
            object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> gonderen = sender as TList<AV001_TDI_BIL_KIYMETLI_EVRAK>;
                if (gonderen != null)
                    if (gonderen.Count > 0)
                    {
                        //ucAdimTree1.NodeExpend("Sözleþme Bilgileri");
                        ucAdimTree1.NodeChecked("Kýymetli Evrak");
                        kiymetliEvrakCheck = true;
                        if (sozlesmeCheck)
                        {
                            ucAdimTree1.NodeChecked("Alacak Neden Baðlantýlarý");
                        }
                    }
                    else
                    {
                        kiymetliEvrakCheck = false;
                        ucAdimTree1.NodeUnChecked("Kýymetli Evrak");
                        ucAdimTree1.NodeUnChecked("Alacak Neden Baðlantýlarý");
                    }
            }
        }

        private void AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW_ListChanged(
            object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                TList<AV001_TDI_BIL_SOZLESME> gonderen = sender as TList<AV001_TDI_BIL_SOZLESME>;
                if (gonderen != null)
                    if (gonderen.Count > 0)
                    {
                        ucAdimTree1.NodeExpend("Sözleþme Bilgileri");
                        ucAdimTree1.NodeChecked("Sözleþme Bilgileri");
                        sozlesmeCheck = true;
                        if (kiymetliEvrakCheck)
                            ucAdimTree1.NodeChecked("Alacak Neden Baðlantýlarý");
                        else
                            ucAdimTree1.NodeChecked("Alacak Neden Baðlantýlarý");
                    }
                    else
                    {
                        ucAdimTree1.NodeUnChecked("Sözleþme Bilgileri");
                        sozlesmeCheck = false;
                        ucAdimTree1.NodeUnChecked("Alacak Neden Baðlantýlarý");
                    }
            }
        }

        private void AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
            {
                ucAdimTree1.NodeChecked("Alacak Neden Taraflarý");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Alacak Neden Taraflarý");
            }
        }

        private void AV001_TI_BIL_ALACAK_NEDENCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.ListChanged +=
                AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection_ListChanged;
            wpAdim11.AllowNext = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0;
            if (wpAdim11.AllowNext)
            {
                ucAdimTree1.NodeExpend("Alacak Nedenleri");
                ucAdimTree1.NodeChecked("Alacak Neden Giriþi");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Alacak Neden Giriþi");
            }

            if (MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0)
            {
                ucAdimTree1.NodeUnChecked("Alacak Neden Taraflarý");
            }

            #region Kapanmýþ

            // if ((MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0))
            //{
            //    wpAdim11.AllowNext = true;
            //}
            //else
            //    wpAdim11.AllowNext = false;

            //if (wpAdim11.AllowNext)
            //{
            //    ucAdimTree1.NodeChecked("Alacak Neden Giriþi");
            //    // ucAdimTree1.NodeChecked("Alacak Nedenleri");
            //}
            //if (MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count > 0 && wpAdim11.AllowNext)
            //{
            //    //ucAdimTree1.NodeChecked("Alacak Neden Taraflarý");
            //}

            #endregion
        }

        private void AV001_TI_BIL_BORCLU_ODEMECollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.Count > 0)
            {
                ucAdimTree1.NodeExpend("Takip Öncesi Ödemeler");
                ucAdimTree1.NodeChecked("Borçlu Ödeme Bilgileri");
                ucAdimTree1.NodeChecked("Takip Öncesi Ödemeler");
            }
            else
            {
                ucAdimTree1.NodeUnExpend("Takip Öncesi Ödemeler");
                ucAdimTree1.NodeUnChecked("Borçlu Ödeme Bilgileri");
                ucAdimTree1.NodeUnChecked("Takip Öncesi Ödemeler");
            }
        }

        private void AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_SORUMLU_AVUKAT addNew = new AV001_TI_BIL_FOY_SORUMLU_AVUKAT();

            addNew.YETKILI_MI = chkYetkiliMi.Checked;
            lueSorumluAvukat.Properties.ValueMember = "";
            addNew.SORUMLU_AVUKAT_CARI_ID = ((AvukatProLib.Arama.per_AV001_TDI_BIL_CARI)lueSorumluAvukat.EditValue).ID;

            e.NewObject = addNew;
        }

        private void AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            wpAdim5.AllowNext = MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0;

            if (wpAdim5.AllowNext)
            {
                ucAdimTree1.NodeChecked("Sorumlu Bilgileri");
                ucAdimTree1.NodeChecked("Sorumlu Avukat");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Sorumlu Avukat");
                ucAdimTree1.NodeUnChecked("Sorumlu Bilgileri");
            }
        }

        private void AV001_TI_BIL_GAYRIMENKULCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL addnew = new AV001_TI_BIL_GAYRIMENKUL();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.STAMP = 1;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = addnew;
        }

        private void AV001_TI_BIL_ILAM_MAHKEMESICollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0)
            {
                ucAdimTree1.NodeExpend("Ýlam Bilgileri");
                ucAdimTree1.NodeChecked("Ýlam Bilgileri");
                ucAdimTree1.NodeChecked("Ýlamlý Alacak");
            }
            else
            {
                ucAdimTree1.NodeUnExpend("Ýlam Bilgileri");
                ucAdimTree1.NodeUnChecked("Ýlam Bilgileri");
                ucAdimTree1.NodeUnChecked("Ýlamlý Alacak");
            }
        }

        private void BindingFoy()
        {
            lueFormTipi.DataBindings.Clear();
            lueFormTipi.DataBindings.Add("EditValue", MyFoy, "FORM_TIP_ID", true);

            lueTakipKonusu.DataBindings.Clear();
            lueTakipKonusu.DataBindings.Add("EditValue", MyFoy, "TAKIP_TALEP_ID", true);

            txtFoyNoKod.DataBindings.Clear();
            txtFoyNoKod.DataBindings.Add("TEXT", MyFoy, "FOY_NO_Kod", true);

            txtFoyNoSayi.DataBindings.Clear();
            txtFoyNoSayi.DataBindings.Add("TEXT", MyFoy, "FOY_NO_Sayi", true);

            dtTakipTarihi.DataBindings.Clear();
            dtTakipTarihi.DataBindings.Add("EditValue", MyFoy, "TAKIP_TARIHI", true);

            dtAvkIntT.DataBindings.Clear();
            dtAvkIntT.DataBindings.Add("EditValue", MyFoy, "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true);

            lueDosyaDurum.DataBindings.Clear();
            lueDosyaDurum.DataBindings.Add("EditValue", MyFoy, "FOY_DURUM_ID", true);

            lueAdliBirimAdliye.DataBindings.Clear();
            lueAdliBirimAdliye.DataBindings.Add("EditValue", MyFoy, "ADLI_BIRIM_ADLIYE_ID", true);

            lueMudurlukNo.DataBindings.Clear();
            lueMudurlukNo.DataBindings.Add("EditValue", MyFoy, "ADLI_BIRIM_NO_ID", true);

            txtEsasNo.DataBindings.Clear();
            txtEsasNo.DataBindings.Add("TEXT", MyFoy, "ESAS_NO", true);

            lueTakipYolu.DataBindings.Clear();
            lueTakipYolu.DataBindings.Add("EditValue", MyFoy, "TAKIP_YOLU_ID", true);

            lueOzelKod1.DataBindings.Clear();
            lueOzelKod1.DataBindings.Add("EditValue", MyFoy, "ICRA_OZEL_KOD1_ID", true);

            lueOzelKod2.DataBindings.Clear();
            lueOzelKod2.DataBindings.Add("EditValue", MyFoy, "ICRA_OZEL_KOD2_ID", true);

            lueOzelKod3.DataBindings.Clear();
            lueOzelKod3.DataBindings.Add("EditValue", MyFoy, "ICRA_OZEL_KOD3_ID", true);

            lueOzelKod4.DataBindings.Clear();
            lueOzelKod4.DataBindings.Add("EditValue", MyFoy, "ICRA_OZEL_KOD4_ID", true);

            txtRef1.DataBindings.Clear();
            txtRef1.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO", true);

            txtRef2.DataBindings.Clear();
            txtRef2.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO2", true);

            txtRef3.DataBindings.Clear();
            txtRef3.DataBindings.Add("TEXT", MyFoy, "REFERANS_NO3", true);

            //lueMudurlukNo.DataBindings.Clear();
            //lueMudurlukNo.DataBindings.Add("TEXT", MyFoy, "ADLI_BIRIM_NO_ID", true);
        }

        private void Borclu_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF addNew = new AV001_TI_BIL_FOY_TARAF();
            addNew.ColumnChanged += BorcluItem_ColumnChanged;
            lueBorcluTaraf.Properties.ValueMember = string.Empty;

            #region Kapanmýþ

            //if (addNew.TARAF_SIFAT_IDSource == null)
            //    addNew.TARAF_SIFAT_IDSource = new TDIE_KOD_TARAF_SIFAT();

            //if (addNew.CARI_IDSource == null)
            //    addNew.CARI_IDSource = new AV001_TDI_BIL_CARI();

            #endregion

            addNew.TARAF_SIFAT_ID = ((TDIE_KOD_TARAF_SIFAT)lueBorcluSifat.EditValue).ID;

            //addNew.TARAF_SIFAT_IDSource = (TDIE_KOD_TARAF_SIFAT)lueBorcluSifat.EditValue;

            if (lueBorcluTaraf.EditValue is int)
                addNew.CARI_ID = (int)lueBorcluTaraf.EditValue;
            else if (lueBorcluTaraf.EditValue is AvukatProLib.Arama.per_AV001_TDI_BIL_CARI)
                addNew.CARI_ID = ((AvukatProLib.Arama.per_AV001_TDI_BIL_CARI)lueBorcluTaraf.EditValue).ID;

            //addNew.CARI_IDSource = (AV001_TDI_BIL_CARI)lueBorcluTaraf.EditValue;

            if (M_2.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 1;
                K_2.Enabled = false;
            }
            else if (K_2.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 3;
                M_2.Enabled = false;
                D_2.Enabled = false;
            }
            else if (D_2.CheckState == CheckState.Checked)
            {
                addNew.TARAF_KODU = 2;
                K_2.Enabled = false;
            }

            e.NewObject = addNew;
            MyFoy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(Borclu);
        }

        private void Borclu_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (gwBorclu.RowCount <= 0)
                {
                    M_2.Enabled = true;
                    D_2.Enabled = true;
                    K_2.Enabled = true;
                }
            }
            wpAdim8.AllowNext = Borclu.Count > 0;

            if (wpAdim7.AllowNext)
            {
                ucAdimTree1.NodeChecked("Borçlular");
                ucAdimTree1.NodeChecked("Borçlu Taraf");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Borçlular");
                ucAdimTree1.NodeUnChecked("Borçlu Taraf");
            }
        }

        private void BorcluItem_ColumnChanged(object sender, AV001_TI_BIL_FOY_TARAFEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF gonderen = (AV001_TI_BIL_FOY_TARAF)sender;
            if (e.Column == AV001_TI_BIL_FOY_TARAFColumn.CARI_ID)
            {
                TList<AV001_TDI_BIL_CARI> cariLer = lueBorcluTaraf.Properties.DataSource as TList<AV001_TDI_BIL_CARI>;
                if (cariLer != null && gonderen.CARI_ID.HasValue)
                {
                    AV001_TDI_BIL_CARI cari = cariLer.Find("ID", gonderen.CARI_ID.Value);
                    if (cari != null)
                    {
                        gonderen.CARI_IDSource = cari;
                    }
                }
            }
            else if (e.Column == AV001_TI_BIL_FOY_TARAFColumn.TARAF_SIFAT_ID)
            {
                TList<TDIE_KOD_TARAF_SIFAT> cariSifat =
                    lueBorcluSifat.Properties.DataSource as TList<TDIE_KOD_TARAF_SIFAT>;
                if (cariSifat != null && gonderen.TARAF_SIFAT_ID != null)
                {
                    TDIE_KOD_TARAF_SIFAT sifat = cariSifat.Find("ID", gonderen.TARAF_SIFAT_ID);
                    if (sifat != null)
                    {
                        gonderen.TARAF_SIFAT_IDSource = sifat;
                    }
                }
            }
        }

        private bool BorclulardaAlacakliTarafVarmi(int TarafCariId)
        {
            foreach (AV001_TI_BIL_FOY_TARAF trf in Borclu)
            {
                if (trf.CARI_ID.Value == TarafCariId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool BorcluTarafVarmi(int TarafCariId)
        {
            foreach (AV001_TI_BIL_FOY_TARAF trf in Borclu)
            {
                if (trf.CARI_ID.Value == TarafCariId)
                {
                    return true;
                }
            }

            return false;
        }

        private void BorcluVekil_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF_VEKIL addNew = new AV001_TI_BIL_FOY_TARAF_VEKIL();

            addNew.AVUKAT_CARI_ID = ((AV001_TDI_BIL_CARI)lueBorcluVekil.EditValue).ID;
            addNew.AVUKAT_CARI_IDSource = (AV001_TDI_BIL_CARI)lueBorcluVekil.EditValue;

            addNew.TEMSIL_SEKLI_ID = ((TDI_KOD_TEMSIL_TUR)lueTemsilTuru2.EditValue).ID;

            e.NewObject = addNew;
            BorcluVekil.ListChanged += BorcluVekil_ListChanged;
        }

        private void BorcluVekil_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (BorcluVekil.Count > 0)
            {
                ucAdimTree1.NodeChecked("Borçlu Taraf Vekil");
            }
            else
                ucAdimTree1.NodeUnChecked("Borçlu Taraf Vekil");
        }

        //TODO: Türkçe karakterli method deðiþken class yapmýyoruz. [YY]
        private void btnAlacaklýSil_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF> secilenler = new TList<AV001_TI_BIL_FOY_TARAF>();

            int[] secilenIndexler = gwAlacakVekil.GetSelectedRows();
            for (int i = 0; i < secilenIndexler.Length; i++)
            {
                AV001_TI_BIL_FOY_TARAF obj = (AV001_TI_BIL_FOY_TARAF)gwAlacakli.GetRow(secilenIndexler[i]);

                secilenler.Add(obj);
            }

            for (int j = 0; j < Alacakli.Count; j++)
            {
                if (Alacakli[j].IsSelected && !secilenler.Contains(Alacakli[j]))
                    secilenler.Add(Alacakli[j]);
            }

            if (secilenler.Count == 0) return;

            DialogResult ds1 = XtraMessageBox.Show("Bu alacaklýyý silmek istediðinizden emin misiniz ?", "Silme Ýþlemi",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (ds1 == DialogResult.Yes)
                {
                    for (int i = 0; i < secilenler.Count; i++)
                    {
                        Alacakli.Remove(secilenler[i]);
                    }
                }
            }
        }

        private void btnAlacakliEkle_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            string msj = string.Empty;

            if ((validator.Validate(lueAlacakliTaraf)) && (validator.Validate(lueAlacakliSifat)))
            {
                if (gwAlacakli.RowCount == 0)
                    Alacakli.AddNew();
                else
                {
                    if (AlacakliTarafVarmi(((AV001_TDI_BIL_CARI)lueAlacakliTaraf.EditValue).ID))
                    {
                        kontrol = false;
                        msj = "Bu alacaklý daha önce eklenmiþ.";
                    }
                    if (BorclulardaAlacakliTarafVarmi(((AV001_TDI_BIL_CARI)lueAlacakliTaraf.EditValue).ID))
                    {
                        kontrol = false;
                        msj = "Bu alacaklý borçlular listesine eklenmiþ.";
                    }
                    if (kontrol)
                        Alacakli.AddNew();

                    else if (!kontrol)
                    {
                        XtraMessageBox.Show(msj
                                            + System.Environment.NewLine +
                                            "Lütfen baþka bir alacaklý seçip yeniden deneyiniz.", "Uyarý",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (!validator.Validate(lueAlacakliTaraf))
            {
                lueAlacakliTaraf.Properties.NullText = "Eklemek için alacakli seçmelisiniz.";
            }

            if (!validator.Validate(lueAlacakliSifat))
            {
                lueAlacakliSifat.Properties.NullText = "Eklemek için sýfat seçmelisiniz";
            }
        }

        private void btnAlacakliVekilEkle_Click(object sender, EventArgs e)
        {
            if (validator.Validate(lueAlacakliVekil) && validator.Validate(lueTemsilTuru))
            {
                foreach (AV001_TI_BIL_FOY_TARAF taraf in Alacakli)
                {
                    AV001_TI_BIL_FOY_TARAF_VEKIL yeniVekil = new AV001_TI_BIL_FOY_TARAF_VEKIL();

                    yeniVekil.AVUKAT_CARI_ID = ((AV001_TDI_BIL_CARI)lueAlacakliVekil.EditValue).ID;
                    yeniVekil.AVUKAT_CARI_IDSource = (AV001_TDI_BIL_CARI)lueAlacakliVekil.EditValue;
                    yeniVekil.TEMSIL_SEKLI_ID = ((TDI_KOD_TEMSIL_TUR)lueTemsilTuru.EditValue).ID;

                    for (int i = 0; i < taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; i++)
                    {
                        if (taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_ID ==
                            yeniVekil.AVUKAT_CARI_ID.Value)
                            taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.RemoveAt(i);
                    }

                    //AlacakliVekil.Add(yeniVekil);

                    taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Add(yeniVekil);
                    MyFoy.AV001_TI_BIL_FOY_TARAF_VEKILCollection.AddRange(taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection);
                }
            }
        }

        private void btnAvkEkle_Click(object sender, EventArgs e)
        {
            if (validator.Validate(lueSorumluAvukat))
            {
                if (gwSorumluAvukat.RowCount == 0)
                {
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddNew();
                }
                else
                {
                    if (!SorumluAvkVarmi(((AV001_TDI_BIL_CARI)lueSorumluAvukat.EditValue).ID))
                        MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddNew();
                    else
                        XtraMessageBox.Show("Bu avukat zaten listede kayýtlýdýr."
                                            + System.Environment.NewLine +
                                            "Lütfen baþka bir avukat seçip yeniden eklemeyi deneyiniz.", "Uyarý",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBorcluEkle_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            string msj = string.Empty;

            if ((validator.Validate(lueBorcluTaraf)) && (validator.Validate(lueBorcluSifat)))
            {
                if (gwBorclu.RowCount == 0)
                    Borclu.AddNew();
                else
                {
                    if (BorcluTarafVarmi(((AV001_TDI_BIL_CARI)lueBorcluTaraf.EditValue).ID))
                    {
                        kontrol = false;
                        msj = "Bu borçlu daha önce eklenmiþ.";
                    }
                    if (AlacaklilardaBorcluTarafVarmi(((AV001_TDI_BIL_CARI)lueBorcluTaraf.EditValue).ID))
                    {
                        kontrol = false;
                        msj = "Bu borçlu alacaklýlar listesine eklenmiþ.";
                    }
                    if (kontrol)
                        Borclu.AddNew();

                    else if (!kontrol)
                    {
                        XtraMessageBox.Show(msj
                                            + System.Environment.NewLine +
                                            "Lütfen baþka bir borçlu seçip yeniden deneyiniz.", "Uyarý",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (!validator.Validate(lueBorcluTaraf))
            {
                lueBorcluTaraf.Properties.NullText = "Eklemek için borçlu seçmelisiniz.";
            }

            if (!validator.Validate(lueBorcluSifat))
            {
                lueBorcluTaraf.Properties.NullText = "Eklemek için sýfat seçmelisiniz";
            }
        }

        private void btnBorcluSil_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF> secilenler = new TList<AV001_TI_BIL_FOY_TARAF>();

            //  if (secilen == null) return;
            int[] secilenIndexler = gwBorclu.GetSelectedRows();
            for (int i = 0; i < secilenIndexler.Length; i++)
            {
                AV001_TI_BIL_FOY_TARAF obj = (AV001_TI_BIL_FOY_TARAF)gwBorclu.GetRow(secilenIndexler[i]);

                secilenler.Add(obj);
            }

            for (int j = 0; j < Borclu.Count; j++)
            {
                if (Borclu[j].IsSelected && !secilenler.Contains(Borclu[j]))
                    secilenler.Add(Borclu[j]);
            }

            if (secilenler.Count == 0) return;

            else
            {
                DialogResult ds = XtraMessageBox.Show("Bu borçluyu silmek istediðinizden emin misiniz ?", "Silme Ýþlemi",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                {
                    if (ds == DialogResult.Yes)
                    {
                        for (int i = 0; i < secilenler.Count; i++)
                        {
                            Borclu.Remove(secilenler[i]);
                        }
                    }
                }
            }
        }

        private void btnBorcluVekilEkle_Click(object sender, EventArgs e)
        {
            if (validator.Validate(lueBorcluVekil) && validator.Validate(lueTemsilTuru2))
            {
                foreach (AV001_TI_BIL_FOY_TARAF taraf in Borclu)
                {
                    AV001_TI_BIL_FOY_TARAF_VEKIL yeniVekil = new AV001_TI_BIL_FOY_TARAF_VEKIL();

                    yeniVekil.AVUKAT_CARI_ID = ((AV001_TDI_BIL_CARI)lueBorcluVekil.EditValue).ID;
                    yeniVekil.AVUKAT_CARI_IDSource = (AV001_TDI_BIL_CARI)lueBorcluVekil.EditValue;
                    yeniVekil.TEMSIL_SEKLI_ID = ((TDI_KOD_TEMSIL_TUR)lueTemsilTuru2.EditValue).ID;

                    for (int i = 0; i < taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Count; i++)
                    {
                        if (taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].AVUKAT_CARI_ID ==
                            yeniVekil.AVUKAT_CARI_ID.Value)
                            taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.RemoveAt(i);
                    }

                    //BorcluVekil.Add(yeniVekil);
                    taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection.Add(yeniVekil);
                    MyFoy.AV001_TI_BIL_FOY_TARAF_VEKILCollection.AddRange(taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection);
                }
            }
        }

        private void btnSorumluSil_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> secilenler = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();

            for (int j = 0; j < MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; j++)
            {
                if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[j].IsSelected &&
                    !secilenler.Contains(MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[j]))
                    secilenler.Add(MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[j]);
            }

            if (secilenler.Count > 0)
            {
                DialogResult ds =
                    XtraMessageBox.Show("Seçilen sorumluyu/sorumlularý silmek istediðinizden emin misiniz ?",
                                        "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                {
                    if (ds == DialogResult.Yes)
                    {
                        for (int i = 0; i < secilenler.Count; i++)
                        {
                            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Remove(secilenler[i]);
                        }
                    }
                }
            }
        }

        private void CreateForm(int? formKonu)
        {
            f = (FormTipi)formKodId;

            if (formKonu.HasValue)
                formKonusu = formKonu.Value;

            switch (f)
            {
                case FormTipi.KambiyoSenetleri_163:
                case FormTipi.KambiyoSenetleri_52:

                    ucForm163_52 frm163 = new ucForm163_52();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm163);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm163);
                    frm163.Dock = DockStyle.Fill;
                    frm163.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm163.MyFoy = MyFoy;

                    break;

                case FormTipi.IlamsizOdemeEmri_49:
                case FormTipi.IlamsizOdemeEmri_153:

                    ucForm49_153 frm49 = new ucForm49_153();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm49);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm49);
                    frm49.Dock = DockStyle.Fill;
                    frm49.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm49.MyFoy = MyFoy;

                    break;

                case FormTipi.MenkulRehninParayaCevrilmesi_50:
                case FormTipi.MenukulRehninParayaCevrilmesi_201:
                case FormTipi.IpoteginParayaCevrilmesi_151:
                case FormTipi.IpoteginParayaCevrilmesi_152:

                    ucForm151_152_50_201 frm201 = new ucForm151_152_50_201();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm201);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm201);
                    frm201.Dock = DockStyle.Fill;
                    frm201.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm201.MyFoy = MyFoy;

                    break;

                case FormTipi.ParaTeminatIcraEmri_53:

                    if (formKonu.Value == 5 || formKonu.Value == 6 || formKonu.Value == 18)
                    {
                        ucForm53_ilam_nafaka_alacak frm53 = new ucForm53_ilam_nafaka_alacak();

                        //tabAlacakNedenGirisi.Controls.Clear();
                        //tabAlacakNedenGirisi.Controls.Add(frm53);
                        controlPanel.Controls.Clear();
                        controlPanel.Controls.Add(frm53);
                        frm53.Dock = DockStyle.Fill;
                        frm53.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                        frm53.MyFoy = MyFoy;

                        //frm53.LoadData();
                    }
                    else if (formKonu.Value == 7)
                    {
                        ucForm53_IsYap frm53IsYap = new ucForm53_IsYap();

                        //tabAlacakNedenGirisi.Controls.Clear();
                        //tabAlacakNedenGirisi.Controls.Add(frm53IsYap);
                        controlPanel.Controls.Clear();
                        controlPanel.Controls.Add(frm53IsYap);
                        frm53IsYap.Dock = DockStyle.Fill;
                        frm53IsYap.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                        frm53IsYap.MyFoy = MyFoy;
                    }

                    else if (formKonu.Value == 8)
                    {
                        ucForm55_53_irt frm55 = new ucForm55_53_irt();

                        //tabAlacakNedenGirisi.Controls.Clear();
                        //tabAlacakNedenGirisi.Controls.Add(frm55);
                        controlPanel.Controls.Clear();
                        controlPanel.Controls.Add(frm55);
                        frm55.Dock = DockStyle.Fill;
                        frm55.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                        frm55.MyFoy = MyFoy;
                    }

                    break;

                case FormTipi.CocukTeslimi_55:

                    ucForm55_53_irt frm55_irt = new ucForm55_53_irt();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm55_irt);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm55_irt);
                    frm55_irt.Dock = DockStyle.Fill;
                    frm55_irt.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm55_irt.MyFoy = MyFoy;

                    break;

                case FormTipi.MenukulTeslimiveyaGayrimenkul_51:
                    ucForm51 frm51 = new ucForm51();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm51);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm51);
                    frm51.Dock = DockStyle.Fill;
                    frm51.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm51.MyFoy = MyFoy;

                    break;

                case FormTipi.MenkulTeslimiveyaGayrimenkul_54:
                    ucForm54 frm54 = new ucForm54();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm54);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm54);
                    frm54.Dock = DockStyle.Fill;
                    frm54.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm54.MyFoy = MyFoy;

                    break;

                case FormTipi.MenkulTeslimiveyaGayrimenkul_56:
                    ucForm56 frm56 = new ucForm56();

                    //tabAlacakNedenGirisi.Controls.Clear();
                    //tabAlacakNedenGirisi.Controls.Add(frm56);
                    controlPanel.Controls.Clear();
                    controlPanel.Controls.Add(frm56);
                    frm56.Dock = DockStyle.Fill;
                    frm56.OnAlacakNedenEklendi += frm201_OnAlacakNedenEklendi;
                    frm56.MyFoy = MyFoy;

                    break;
            }
        }

        private void D_1_CheckStateChanged(object sender, EventArgs e)
        {
            if (D_1.CheckState == CheckState.Checked)
            {
                K_1.CheckState = CheckState.Unchecked;
                M_1.CheckState = CheckState.Unchecked;

                ((TList<AV001_TDI_BIL_CARI>)lueAlacakliTaraf.Properties.DataSource).Filter = string.Empty;
            }
        }

        private void D_2_CheckStateChanged(object sender, EventArgs e)
        {
            if (D_2.CheckState == CheckState.Checked)
            {
                K_2.CheckState = CheckState.Unchecked;
                M_2.CheckState = CheckState.Unchecked;

                ((TList<AV001_TDI_BIL_CARI>)lueBorcluTaraf.Properties.DataSource).Filter = string.Empty;
            }
        }

        private void dtTakipTarihi_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit lue = sender as DateEdit;

            if (lue.EditValue != null)
            {
                MyFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI = (DateTime)lue.EditValue;
            }
        }

        private string EsasNoOlustur()
        {
            return DateTime.Today.Year + "/";
        }

        private void FoyHesaplanmisKalemler()
        {
            frmIcraHesaplanmisFaizGiris frm = new frmIcraHesaplanmisFaizGiris();
            frm.MyDataSource = myFoy;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

            frm.Show();
        }

        private void FoyIhtiyatiHacizBilgileri()
        {
            frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();
            frm.MyFoy = MyFoy;
            frm.MyDataSource = myFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyIhtiyatiTedbirBilgileri()
        {
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.MyFoy = MyFoy;
            frm.MyDataSource = myFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection;

            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyIlamMahkemesi()
        {
            frmIcraIlamMahkemesiGiris frm = new frmIcraIlamMahkemesiGiris();
            frm.MyDataSource = myFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection;

            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyNoKaydet()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.Save(trans, MyFoy);

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private string FoyNoOlustur()
        {
            string foyNo = String.Empty;

            AV001_TI_BIL_FOYQuery que = new AV001_TI_BIL_FOYQuery();
            int k = 0;
            TList<AV001_TI_BIL_FOY> foyler = DataRepository.AV001_TI_BIL_FOYProvider.Find(que, "ID DESC", 0, 1, out k);
            if (foyler.Count > 0)
            {
                int foyNoSayi = foyler[0].FOY_NO_Sayi;
                bool foyNoVarmi = true;
                while (foyNoVarmi)
                {
                    foyNoSayi++;
                    foyNo = String.Format("{0}~{1}", foyler[0].FOY_NO_Kod, foyNoSayi);
                    foyNoVarmi =
                        Convert.ToBoolean(DataRepository.AV001_TI_BIL_FOYProvider.FoyNoVarmi(foyNo).Tables[0].Rows[0][0]);
                }
            }
            else
            {
                foyNo = String.Format("I-{0}~{1}", DateTime.Today.Year, 10001);
            }
            return foyNo;
        }

        private void FoyTakipOncesiOdemeler()
        {
            frmIcraOdemeBilgileri frm = new frmIcraOdemeBilgileri();

            // frm.MyDataSource = myFoy.AV001_TI_BIL_BORCLU_ODEMECollection;
            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
        }

        private void FoyuEditoreGonder()
        {
            TList<AV001_TI_BIL_FOY> lstFoys = new TList<AV001_TI_BIL_FOY>();
            lstFoys.Add(myFoy);
            TakipOnizleme(lstFoys);
        }

        private void FoyuHesapla()
        {
            MyFoy.AV001_TI_BIL_FOY_TARAFCollection = TumTaraflar;
            try
            {
                Hesap.Icra hy = new Hesap.Icra(MyFoy);

                ucIcraHesapCetveli1.MyFoyDataSource = MyFoy;
                ucIcraHesapCetveli1.MyTarafSource = MyFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll("TAKIP_EDEN_MI",
                                                                                                   false);
                XtraMessageBox.Show("Hesaplama Ýþleminiz Baþarýyla Gerçekleþmiþtir..", "Bilgilendirme",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                XtraMessageBox.Show("Hesaplama Ýþleminizde Bir Hata Olmuþtur..", "Bilgilendirme", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void FoyuMahsupBilgileri()
        {
            frmMahsupBilgileri mahsup = new frmMahsupBilgileri();
            mahsup.MyFoy = myFoy;
            mahsup.Show();
        }

        private void FoyuYazdýr()
        {
            Editor.Forms.frmEditoreGonder frmEGonder = new AdimAdimDavaKaydi.Editor.Forms.frmEditoreGonder();
            frmEGonder.MyFoy = myFoy;
            frmEGonder.Show();
        }

        private void frm201_OnAlacakNedenEklendi(object sender, AlacakNedenEklendiEventArgs e)
        {
            AlacakNedenTarafYapilandir(e.Neden);
        }

        private void frmAdimAdimIcraKaydi_Button_Editor_Click(object sender, EventArgs e)
        {
            FoyuEditoreGonder();
        }

        #region Events

        private void frmAdimAdimIcraKaydi_Button_Hesapla_Click(object sender, EventArgs e)
        {
            FoyuHesapla();
        }

        private void frmAdimAdimIcraKaydi_Button_HesaplanmisKalemler_Click(object sender, EventArgs e)
        {
            FoyHesaplanmisKalemler();
        }

        private void frmAdimAdimIcraKaydi_Button_IhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            FoyIhtiyatiHacizBilgileri();
        }

        private void frmAdimAdimIcraKaydi_Button_IhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            FoyIhtiyatiTedbirBilgileri();
        }

        private void frmAdimAdimIcraKaydi_Button_IlamBilgileri_Click(object sender, EventArgs e)
        {
            FoyIlamMahkemesi();
        }

        private void frmAdimAdimIcraKaydi_Button_MahsupBilgileri_Click(object sender, EventArgs e)
        {
            FoyuMahsupBilgileri();
        }

        private void frmAdimAdimIcraKaydi_Button_TakipOncesiOdemeleri_Click(object sender, EventArgs e)
        {
            FoyTakipOncesiOdemeler();
        }

        private void frmAdimAdimIcraKaydi_Button_Yazdir_Click(object sender, EventArgs e)
        {
            FoyuYazdýr();
        }

        private void frmAdimAdimIcraKaydi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finish) return;

            if (
                XtraMessageBox.Show(this, "Çýkmak istediðinizden emin misiniz?", "Çýkýþ", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                Sil();
            }
        }

        private void frmAdimAdimIcraKaydi_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //this.compRibbonExtender1.LoadMainMenu = true;
                //this.compRibbonExtender1.RibbonForExtend = null;
                //this.compRibbonExtender1.RibbonFormForExtend = this;
                ucIcraHesapCetveli1.Gorunum = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;

                btnAlacakliVekilEkle.Click += btnAlacakliVekilEkle_Click;
                btnBorcluVekilEkle.Click += btnBorcluVekilEkle_Click;

                lueFormTipi.EditValueChanging += lueFormTipi_EditValueChanging;
                lueTakipKonusu.EditValueChanging += lueTakipKonusu_EditValueChanging;
                lueAdliBirimAdliye.EditValueChanging += lueAdliBirimAdliye_EditValueChanging;
                lueTakipYolu.EditValueChanging += lueTakipYolu_EditValueChanging;

                //lueOzelKod1.EditValueChanging += new ChangingEventHandler(lueOzelKod1_EditValueChanging);
                lueOzelKod1.EditValueChanged += lueOzelKod1_EditValueChanged;

                //lueOzelKod2.EditValueChanging += new ChangingEventHandler(lueOzelKod2_EditValueChanging);
                lueOzelKod2.EditValueChanged += lueOzelKod2_EditValueChanged;

                //lueOzelKod3.EditValueChanging += new ChangingEventHandler(lueOzelKod3_EditValueChanging);
                lueOzelKod3.EditValueChanged += lueOzelKod3_EditValueChanged;

                //lueOzelKod4.EditValueChanging += new ChangingEventHandler(lueOzelKod4_EditValueChanging);
                lueOzelKod4.EditValueChanged += lueOzelKod4_EditValueChanged;

                gwAlacakNedenleri.FocusedRowChanged += gwAlacakNedenleri_FocusedRowChanged;

                txtRef1.TextChanged += txtRef1_TextChanged;
                txtRef2.TextChanged += txtRef2_TextChanged;
                txtRef3.TextChanged += txtRef3_TextChanged;
                txtFoyNoKod.TextChanged += txtFoyNoKod_TextChanged;
                txtEsasNo.TextChanged += txtEsasNo_TextChanged;

                wizardControl1.CancelClick += wizardControl1_CancelClick;
                wizardControl1.FinishClick += wizardControl1_FinishClick;
                this.FormClosing += frmAdimAdimIcraKaydi_FormClosing;

                gwAlacakli.ValidateRow += gwAlacakli_ValidateRow;

                #region AlacakliTaraf_CheckStateChanged

                M_1.CheckStateChanged += M_1_CheckStateChanged;
                K_1.CheckStateChanged += K_1_CheckStateChanged;
                D_1.CheckStateChanged += D_1_CheckStateChanged;

                #endregion

                #region BorcluTaraf_CheckStateChanged

                M_2.CheckStateChanged += M_2_CheckStateChanged;
                K_2.CheckStateChanged += K_2_CheckStateChanged;
                D_2.CheckStateChanged += D_2_CheckStateChanged;

                #endregion
            }

            #region Kapanmýþ

            //LoadGridStyle(gwSorumluAvukat);
            //LoadGridStyle(gwAlacakli);
            //LoadGridStyle(gwBorclu);
            //LoadGridStyle(gwAlacakVekil);

            #endregion

            SetFoy();

            LoadData();

            //compRibbonExtender1.RibbonFormForExtend = this;
            //compRibbonExtender1.LoadMainMenu = true;
            wpAdim15.Visible = false;
            wpAdim14.Visible = false;
            wpAdim10.Visible = false;
        }

        private void gwAlacakli_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TI_BIL_FOY_TARAF trf = (AV001_TI_BIL_FOY_TARAF)e.Row;
            if (Alacakli.FindAll("CARI_ID", trf.CARI_ID).Count > 1)
            {
                e.ErrorText = "Bu þahýs alacaklý olarak zaten eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }
            if (Borclu.FindAll("CARI_ID", trf.CARI_ID).Count > 0)
            {
                e.ErrorText = "Bu þahýs borçlular listesine eklenmiþ." + Environment.NewLine;
                e.Valid = false;
                return;
            }

            TDI_KOD_TARAF trfkod = ((TList<TDI_KOD_TARAF>)rLueAlacakliTK.DataSource).Find("ID", (int)trf.TARAF_KODU);

            ((TList<TDI_KOD_TARAF>)rLueAlacakliTK.DataSource).Filter = "IsSelected = " + trfkod.IsSelected;
            ((TList<TDI_KOD_TARAF>)rLueBorcluTK.DataSource).Filter = "IsSelected = " + (!trfkod.IsSelected);
        }

        private void gwAlacakNedenleri_FocusedRowChanged(object sender,
                                                         DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN neden = gwAlacakNedenleri.GetRow(e.FocusedRowHandle) as AV001_TI_BIL_ALACAK_NEDEN;
            if (neden != null && neden.ALACAK_NEDEN_KOD_ID != null)
            {
                AlacakNeden f =
                    (AlacakNeden)
                    ((AV001_TI_BIL_ALACAK_NEDEN)gwAlacakNedenleri.GetRow(e.FocusedRowHandle)).ALACAK_NEDEN_KOD_ID.Value;

                switch (f)
                {
                    case AlacakNeden.Cek:
                    case AlacakNeden.Cek_33:
                    case AlacakNeden.Cek_34:
                    case AlacakNeden.Cek_35:
                    case AlacakNeden.Senet_2:
                    case AlacakNeden.Senet:
                    case AlacakNeden.Senet_38:
                    case AlacakNeden.Senet_36:
                    case AlacakNeden.Police:
                    case AlacakNeden.Police_40:
                    case AlacakNeden.Police_41:
                    case AlacakNeden.Police_39:

                        kiymetliEvrakID = 1;
                        sozlesmeID = 0;
                        break;

                    case AlacakNeden.Kira_43:
                    case AlacakNeden.Kira:
                    case AlacakNeden.Kira_5:
                    case AlacakNeden.KiraFarký_45:
                    case AlacakNeden.KiraFarký_46:
                    case AlacakNeden.KiraFarký_6:
                    case AlacakNeden.BankaKrediKarti:
                    case AlacakNeden.BankaKrediKarti_9:
                    case AlacakNeden.BankaKrediAlacagi:
                    case AlacakNeden.BankaKrediAlacagi_10:
                    case AlacakNeden.Tahliye_Taahhudu_12:
                    case AlacakNeden.MenkulRehni_14:
                    case AlacakNeden.MenkulRehni_53:
                    case AlacakNeden.Tahliye_29:
                    case AlacakNeden.Ipotek_32:
                    case AlacakNeden.Ipotek_52:
                    case AlacakNeden.Irtifak_Hakkinin_Kaldirilmasi_60:
                    case AlacakNeden.Sozlesme_7:
                    case AlacakNeden.Sozlesme_47:
                        sozlesmeID = 1;
                        kiymetliEvrakID = 0;
                        break;

                    case AlacakNeden.Fatura_37:
                        sozlesmeID = 1;
                        kiymetliEvrakID = 1;
                        break;

                    default:
                        sozlesmeID = 0;
                        kiymetliEvrakID = 0;
                        break;
                }
                if (sozlesmeID > 1 && kiymetliEvrakID > 1)
                {
                    tabKiymetliEvrak.PageVisible = true;
                    tabControlSozlesme.Visible = true;
                    tabSozlesme.PageVisible = true;
                    sozlesmeID = 0;
                    kiymetliEvrakID = 0;
                }
                if (sozlesmeID > 0)
                {
                    //tabControlSozlesme.TabPages[0].PageVisible = true;
                    //tabControlSozlesme.TabPages[1].PageVisible = false;
                    gcAlacakNedenleri.Dock = DockStyle.Left;
                    tabControlSozlesme.Visible = true;
                    tabKiymetliEvrak.PageVisible = false;
                    tabSozlesme.PageVisible = true;
                    kiymetliEvrakID = 0;
                }
                if (kiymetliEvrakID > 0)
                {
                    //tabControlSozlesme.TabPages[0].PageVisible = false;
                    //tabControlSozlesme.TabPages[1].PageVisible = true;
                    tabKiymetliEvrak.PageVisible = true;
                    gcAlacakNedenleri.Dock = DockStyle.Left;
                    tabControlSozlesme.Visible = true;
                    tabSozlesme.PageVisible = false;
                    sozlesmeID = 0;
                }
                if (sozlesmeID == 0 && kiymetliEvrakID == 0)
                {
                    //tabControlSozlesme.TabPages[0].PageVisible = false;
                    //tabControlSozlesme.TabPages[1].PageVisible = false;
                    tabControlSozlesme.Visible = false;
                    gcAlacakNedenleri.Dock = DockStyle.Fill;
                    sozlesmeID = 0;
                    kiymetliEvrakID = 0;
                }

                #region Doldurma

                ucKiymetliEvrak.MyDataSource =
                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;

                //neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.AddingNew+=new AddingNewEventHandler(AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW_AddingNew);
                ucSozlesmeBilgileri1.MyIcraFoy = this.MyFoy;

                ucSozlesmeBilgileri1.MyDataSource =
                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW;
                neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.ListChanged +=
                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW_ListChanged;

                neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.ListChanged
                    += AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK_ListChanged;

                //neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC.AddingNew += new AddingNewEventHandler(ugaList_AddingNew);
                //ucUcakGemiArac1.MyDataSource = neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC;
                //neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL.AddingNew += new AddingNewEventHandler(AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL_AddingNew);
                //ucGayriMenkul1.MyDataSource = neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL;
            }

                #endregion

            #region Kapanmýþ

            //if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count <= 0)
            //{
            //    //gwAlacakNedenleri.DataSource = null;
            //    ucAdimTree1.NodeUnChecked("Kýymetli Evrak");
            //}
            //else
            //    ucAdimTree1.NodeChecked("Kýymetli Evrak");

            #endregion
            this.GetPaketForm();
        }

        private void HesaplanmisFaizKontrol(AV001_TI_BIL_FOY foy)
        {
            if (foy.HESAPLANMIS_FAIZ > 0 || foy.HESAPLANMIS_KDV > 0 || foy.HESAPLANMIS_BSMV > 0
                || foy.HESAPLANMIS_OIV > 0 || foy.HESAPLANMIS_KKDF > 0)
                ucAdimTree1.NodeChecked("Hesaplanmýþ Tutar");
            else
            {
                ucAdimTree1.NodeUnChecked("Hesaplanmýþ Tutar");
            }

            if (foy.OZEL_TUTAR2_KONU_ID.HasValue || foy.OZEL_TUTAR1_KONU_ID.HasValue || foy.OZEL_TUTAR3_KONU_ID.HasValue ||
                (double)foy.OZEL_TAZMINAT > 0)
            {
                ucAdimTree1.NodeChecked("Özel Kodlar");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Kodlar");
            }
            if (foy.OZEL_TUTAR2_KONU_ID.HasValue || foy.OZEL_TUTAR1_KONU_ID.HasValue || foy.OZEL_TUTAR3_KONU_ID.HasValue ||
                (double)foy.OZEL_TAZMINAT > 0 && foy.HESAPLANMIS_FAIZ > 0 || foy.HESAPLANMIS_KDV > 0 ||
                foy.HESAPLANMIS_BSMV > 0
                || foy.HESAPLANMIS_OIV > 0 || foy.HESAPLANMIS_KKDF > 0)
            {
                ucAdimTree1.NodeExpend("Hesaplanmýþ Kalemler");
                ucAdimTree1.NodeChecked("Hesaplanmýþ Kalemler");
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Hesaplanmýþ Kalemler");
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_TakipOncesiOdemeleri_Click += frmAdimAdimIcraKaydi_Button_TakipOncesiOdemeleri_Click;
            this.Button_IhtiyatiHaciz_Click += frmAdimAdimIcraKaydi_Button_IhtiyatiHaciz_Click;
            this.Button_IhtiyatiTedbir_Click += frmAdimAdimIcraKaydi_Button_IhtiyatiTedbir_Click;
            this.Button_IlamBilgileri_Click += frmAdimAdimIcraKaydi_Button_IlamBilgileri_Click;
            this.Button_HesaplanmisKalemler_Click += frmAdimAdimIcraKaydi_Button_HesaplanmisKalemler_Click;
            this.Button_MahsupBilgileri_Click += frmAdimAdimIcraKaydi_Button_MahsupBilgileri_Click;
            this.Button_Yazdir_Click += frmAdimAdimIcraKaydi_Button_Yazdir_Click;
            this.Button_Hesapla_Click += frmAdimAdimIcraKaydi_Button_Hesapla_Click;
        }

        private void ItemsSelected(TreeList lst)
        {
            foreach (AV001_TI_BIL_FOY_TARAF var in (TList<AV001_TI_BIL_FOY_TARAF>)lst.DataSource)
            {
                var.IsSelected = true;
            }
        }

        private void K_1_CheckStateChanged(object sender, EventArgs e)
        {
            if (K_1.CheckState == CheckState.Checked)
            {
                M_1.CheckState = CheckState.Unchecked;
                D_1.CheckState = CheckState.Unchecked;

                ((TList<AV001_TDI_BIL_CARI>)lueAlacakliTaraf.Properties.DataSource).Filter = string.Empty;

                ((TList<AV001_TDI_BIL_CARI>)lueAlacakliTaraf.Properties.DataSource).Filter = "KARSI_TARAF_MI = TRUE";

                lueAlacakliTaraf.Properties.ValueMember = string.Empty;
            }
        }

        private void K_2_CheckStateChanged(object sender, EventArgs e)
        {
            if (K_2.CheckState == CheckState.Checked)
            {
                M_2.CheckState = CheckState.Unchecked;
                D_2.CheckState = CheckState.Unchecked;

                if (lueBorcluTaraf.Properties.DataSource != null)
                {
                    ((TList<AV001_TDI_BIL_CARI>)lueBorcluTaraf.Properties.DataSource).Filter = string.Empty;
                    ((TList<AV001_TDI_BIL_CARI>)lueBorcluTaraf.Properties.DataSource).Filter = "KARSI_TARAF_MI = TRUE";
                }
                lueBorcluTaraf.Properties.ValueMember = string.Empty;
            }
        }

        private bool Kaydet(AV001_TI_BIL_FOY foy)
        {
            try
            {
                foy.AV001_TI_BIL_FOY_TARAFCollection.Clear();
                foy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(Alacakli);
                foy.AV001_TI_BIL_FOY_TARAFCollection.AddRange(Borclu);

                //Aþama Kaydý ve Ýlk Tebligat Kaydý AsamaHelper a taþýnmýþtýr.
                AsamaHelper.IlkTebligatAsamaHallet(foy);
                AsamaHelper.AsamalariHallet(foy);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            #region Dosyadaki Sözleþmenin Bütün Alacak Nedenlerine Baðlanmasý

            TList<AV001_TDI_BIL_SOZLESME> szList = new TList<AV001_TDI_BIL_SOZLESME>();

            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count > 0)
                {
                    szList.AddRange(neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW);
                }
            }

            if (szList.Count > 0)
            {
                List<int> indexes = new List<int>();
                for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
                {
                    foreach (AV001_TDI_BIL_SOZLESME var in szList)
                    {
                        if (var.BAGIMSIZ_MI == true)
                        {
                            if (
                                myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.
                                    Contains(var))
                            {
                                szListBagýmsýz.Add(var);

                                myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Remove(
                                        var);

                                //SozlesmeKaydet(szListBagýmsýz,foy);
                            }
                        }
                    }
                    if (
                        myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].
                            AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Count > 0)
                        continue;
                    else
                        indexes.Add(i);
                }

                if (indexes.Count > 0)
                {
                    StringBuilder msj = new StringBuilder();
                    msj.Append(
                        "Aþaðýdaki düzenlenme tarihi ve alacak nedeni belirtilen kayýtlara sözleþme baðlanmamýþtýr.");
                    msj.AppendLine();
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        msj.Append("*");
                        msj.Append(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].DUZENLENME_TARIHI);
                        msj.Append("-");
                        msj.Append(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].DIGER_ALACAK_NEDENI);
                        msj.AppendLine();
                    }

                    msj.Append("Sözleþme kaydýný alacak nedenlerine baðlamak ister misiniz ?");

                    DialogResult dr = XtraMessageBox.Show(msj.ToString(), "Uyarý", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        for (int j = 0; j < indexes.Count; j++)
                        {
                            for (int k = 0; k < szList.Count; k++)
                            {
                                myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[indexes[j]].
                                    AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.Add(
                                        szList[k]);
                            }
                        }
                    }
                }
            }

            #endregion

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                //Todo :yanlýþ ama iþimi görüyor canan

                trans.BeginTransaction();
                foreach (AV001_TI_BIL_BORCLU_MAHSUP var in foy.AV001_TI_BIL_BORCLU_MAHSUPCollection)
                {
                    if (var.ICRA_FOY_ID != null && !var.IsNew)
                        var.IsNew = true;
                }

                TList<NN_ICRA_KIYMETLI_EVRAK> kiyList = foy.NN_ICRA_KIYMETLI_EVRAKCollection;
                if (kiyList.Count > 1)
                {
                    for (int i = 0; i < kiyList.Count; i++)
                    {
                        if (kiyList[i].ICRA_FOY_ID == kiyList[i + 1].ICRA_FOY_ID)
                            kiyList.Remove(kiyList[i]);
                    }
                    foy.NN_ICRA_KIYMETLI_EVRAKCollection = kiyList;
                }

                AV001_TI_BIL_ILAM_MAHKEMESI ÝLAM = new AV001_TI_BIL_ILAM_MAHKEMESI();
                if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0)
                    ÝLAM = foy.AV001_TI_BIL_ILAM_MAHKEMESICollection[0];

                #region  <CC-20090613>

                // faizde alacak neden ýdsi verilmiþ ve bu alan kaydedilmemiþ alan olduðu için hata alýnýyordu  alacak neden kaydý yapýldý
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection);

                #endregion</CC-20090613>

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy,
                                                                 DeepSaveType.ExcludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                                                                 typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                                                                 typeof(TList<NN_ICRA_GAYRIMENKUL>),
                                                                 typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>),
                                                                 typeof(TList<NN_ICRA_KIYMETLI_EVRAK>),
                                                                 typeof(TList<NN_ICRA_POLICE>),
                                                                 typeof(TList<NN_ICRA_SOZLESME>));
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>));

                DataRepository.AV001_TDIE_BIL_ASAMAProvider.DeepSave(trans, foy.AV001_TDIE_BIL_ASAMACollection,
                                                                     DeepSaveType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_ASAMA_SORUMLU>),
                                                                     typeof(TList<AV001_TDIE_BIL_ASAMA_TARAF>));

                DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepSave(trans,
                                                                             foy.AV001_TI_BIL_FOY_TARAF_VEKILCollection);

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection,
                                                                          DeepSaveType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>
                                                                              ));

                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    #region//Alacak Neden Taraf

                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(trans,
                                                                                    neden.
                                                                                        AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);

                    #endregion

                    #region  //Kýymetli Evrak

                    neden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK.
                        ForEach(
                            delegate(AV001_TDI_BIL_KIYMETLI_EVRAK obj)
                            {
                                if (
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.FindAll(
                                        AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKColumn.KIYMETLI_EVRAK_ID, obj.ID).
                                        Count == 0)
                                {
                                    AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK ke =
                                        neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.AddNew();

                                    ke.KIYMETLI_EVRAK_IDSource = obj;
                                }
                            }
                        );

                    #endregion

                    #region//Kýymetli Evrak Taraf

                    foreach (AV001_TI_BIL_ALACAK_NEDEN var in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(trans,
                                                                                     var.
                                                                                         AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK,
                                                                                     DeepSaveType.IncludeChildren,
                                                                                     typeof(
                                                                                         TList
                                                                                         <
                                                                                         AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF
                                                                                         >));

                        foreach (
                            AV001_TDI_BIL_KIYMETLI_EVRAK k in
                                var.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK
                            )
                        {
                            DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFProvider.Save(trans,
                                                                                           k.
                                                                                               AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection);
                        }
                    }

                    #endregion

                    #region //GEMÝUÇAKARAÇ

                    neden.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC.
                        ForEach(
                            delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                            {
                                if (
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.FindAll(
                                        AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).
                                        Count == 0)
                                {
                                    AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC gua =
                                        neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection.AddNew();
                                    obj.ICRA_FOY_ID = foy.ID;
                                    gua.GEMI_UCAK_ARAC_IDSource = obj;
                                }
                            });

                    #endregion

                    #region Gayrimenkul

                    neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL.ForEach(
                        delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                        {
                            if (
                                neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.FindAll(
                                    AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count ==
                                0)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL gm =
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection.AddNew();

                                gm.GAYRIMENKUL_IDSource = obj;
                            }
                        }
                        );
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(trans,
                                                                             neden.
                                                                                 AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL,
                                                                             DeepSaveType.IncludeChildren,
                                                                             typeof(
                                                                                 TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));

                    foreach (
                        AV001_TI_BIL_GAYRIMENKUL g in
                            neden.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL)
                    {
                        DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.Save(trans,
                                                                                   g.
                                                                                       AV001_TI_BIL_GAYRIMENKUL_TARAFCollection);
                    }

                    #endregion

                    #region Diger Alacak Nedeni Dolduruluyor

                    try
                    {
                        foy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(
                            delegate(AV001_TI_BIL_ALACAK_NEDEN n)
                            {
                                if (n.ALACAK_NEDEN_KOD_IDSource == null)
                                    n.ALACAK_NEDEN_KOD_IDSource =
                                        DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(
                                            n.ALACAK_NEDEN_KOD_ID.Value);

                                if (n.ALACAK_NEDEN_KOD_ID.HasValue)
                                    n.DIGER_ALACAK_NEDENI = n.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI;
                            });
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }

                    #endregion

                    #region Sozlesme

                    //neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.ForEach(delegate(AV001_TDI_BIL_SOZLESME obj)
                    //  {
                    //      if (neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.FindAll(AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWColumn.SOZLESME_ID, obj.ID).Count == 0)
                    //      {
                    //          AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW gua = neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.AddNew();
                    //          obj.ICRA_FOY_ID = foy.ID;
                    //          gua.SOZLESME_IDSource = obj;
                    //      }
                    //  });

                    //    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
                    //    //foreach (AV001_TDI_BIL_SOZLESME s in neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    //    //{
                    //    //    DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.Save(trans, s.AV001_TDI_BIL_SOZLESME_TARAFCollection);

                    //    //    #region
                    //            foreach (AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC gua in neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection)
                    //            {
                    //                NN_SOZLESME_GEMI_UCAK_ARAC Igua = s.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();
                    //                Igua.GEMI_UCAK_ARAC_IDSource = gua.GEMI_UCAK_ARAC_IDSource;
                    //                Igua.SOZLESME_ID = s.ID;
                    //            }
                    //            foreach (AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL gayrimenkul in neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection)
                    //            {
                    //                NN_SOZLESME_GAYRIMENKUL Igayrimenkul = s.NN_SOZLESME_GAYRIMENKULCollection.AddNew();
                    //                Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul.GAYRIMENKUL_IDSource;
                    //                Igayrimenkul.SOZLESME_ID = s.ID;
                    //            }
                    //            DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, s, DeepSaveType.IncludeChildren, typeof(TList<NN_SOZLESME_GAYRIMENKUL>), typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));
                    //    //    #endregion
                    //    //}

                    //    foreach (AV001_TDI_BIL_SOZLESME s in neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    //    {
                    //        //s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Clear();

                    //        s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.ForEach(
                    //            delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                    //            {
                    //                if (s.NN_SOZLESME_GAYRIMENKULCollection.FindAll
                    //                    (NN_SOZLESME_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count == 0)
                    //                {
                    //                    NN_SOZLESME_GAYRIMENKUL gm = s.NN_SOZLESME_GAYRIMENKULCollection.AddNew();

                    //                    gm.GAYRIMENKUL_IDSource = obj;
                    //                    gm.SOZLESME_ID = s.ID;

                    //                }
                    //            });
                    //    }
                    //    foreach (AV001_TDI_BIL_SOZLESME s in neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    //    {
                    //        //s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Clear();

                    //        s.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.ForEach(
                    //            delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                    //            {
                    //                if (s.NN_SOZLESME_GEMI_UCAK_ARACCollection.FindAll
                    //                    (NN_SOZLESME_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                    //                {
                    //                    NN_SOZLESME_GEMI_UCAK_ARAC gm = s.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();

                    //                    gm.GEMI_UCAK_ARAC_IDSource = obj;
                    //                    gm.SOZLESME_ID = s.ID;

                    //                }
                    //            });
                    //    }

                    //    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW,
                    //        DeepSaveType.IncludeChildren,
                    //        typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>),
                    //        typeof(TList<NN_SOZLESME_GAYRIMENKUL>),
                    //        typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));

                    #endregion

                    neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.ForEach(
                        delegate(AV001_TDI_BIL_SOZLESME obj)
                        {
                            if (
                                neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.FindAll(
                                    AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWColumn.SOZLESME_ID, obj.ID).Count == 0)
                            {
                                AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW sn =
                                    neden.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWCollection.AddNew();
                                sn.SOZLESME_IDSource = obj;
                            }
                        }
                        );

                    //Sözlesme Taraflarý

                    foreach (
                        AV001_TDI_BIL_SOZLESME s in
                            neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    {
                        DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.Save
                            (trans, s.AV001_TDI_BIL_SOZLESME_TARAFCollection);
                    }

                    //Sozlesmeye Baglý Gayrimenkul
                    foreach (
                        AV001_TDI_BIL_SOZLESME s in
                            neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    {
                        //s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Clear();

                        s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.ForEach(
                            delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                            {
                                if (s.NN_SOZLESME_GAYRIMENKULCollection.FindAll
                                        (NN_SOZLESME_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count == 0)
                                {
                                    NN_SOZLESME_GAYRIMENKUL gm = s.NN_SOZLESME_GAYRIMENKULCollection.AddNew();

                                    gm.GAYRIMENKUL_IDSource = obj;
                                    gm.SOZLESME_ID = s.ID;
                                }
                            });
                    }
                    foreach (
                        AV001_TDI_BIL_SOZLESME s in
                            neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    {
                        //s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Clear();

                        s.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.ForEach(
                            delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                            {
                                if (s.NN_SOZLESME_GEMI_UCAK_ARACCollection.FindAll
                                        (NN_SOZLESME_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                                {
                                    NN_SOZLESME_GEMI_UCAK_ARAC gm = s.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();

                                    gm.GEMI_UCAK_ARAC_IDSource = obj;
                                    gm.SOZLESME_ID = s.ID;
                                }
                            });
                    }

                    DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans,
                                                                           neden.
                                                                               AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>),
                                                                           typeof(TList<NN_SOZLESME_GAYRIMENKUL>),
                                                                           typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));
                }

                #region //BorcluOdeme

                DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(trans, foy.AV001_TI_BIL_BORCLU_ODEMECollection);

                #endregion

                #region //Ihtiyati Haciz

                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(foy.AV001_TI_BIL_IHTIYATI_HACIZCollection);

                #endregion

                #region  //Ilam Bilgisi

                DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(foy.AV001_TI_BIL_ILAM_MAHKEMESICollection);

                #endregion

                #region ÝlkTebligatKayýt
                foreach (var item in foy.AV001_TDI_BIL_TEBLIGATCollection)
                {
                    if (item.ID == 0)
                        item.STAMP = 0;
                }
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, foy.AV001_TDI_BIL_TEBLIGATCollection,
                                                                       DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>),
                                                                       typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));
                //// Bu Kýsým yýlmaz Yavuz tarafýndan comment edilip en üst satýrlara koyulmuþtur.
                //// Teþekkürler

                //TList<TDIE_KOD_ASAMA_ILISKI> asama_ILISKIS =
                //   DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.GetByTABLO_ADI(foy.TableName);
                //DataRepository.TDIE_KOD_ASAMA_ILISKIProvider.DeepLoad(asama_ILISKIS, false, DeepLoadType.IncludeChildren,
                //                                                      typeof(TDIE_KOD_ASAMA_ALT),
                //                                                      typeof(TDI_KOD_TEBLIGAT_KONU));

                //foreach (string str in foy.ChangedProperties)
                //{
                //    TList<TDIE_KOD_ASAMA_ILISKI> iliskiS = asama_ILISKIS.FindAll(delegate(TDIE_KOD_ASAMA_ILISKI obj) { return obj.SUTUN_ADI.Contains(str); });
                //    foreach (TDIE_KOD_ASAMA_ILISKI iliski in iliskiS)
                //    {
                //        if (iliski != null && iliski.TEBLIGAT_URETSIN_MI && iliski.TEBLIGAT_KONU_ID.HasValue && foy.FORM_TIP_ID.HasValue && iliski.AsamaDegerKarsilastir(foy))
                //        {
                //            AV001_TDI_BIL_TEBLIGAT tebl = foy.AV001_TDI_BIL_TEBLIGATCollection.Find(AV001_TDI_BIL_TEBLIGATColumn.KONU_ID, iliski.TEBLIGAT_KONU_ID.Value);
                //            if (tebl != null)
                //            {
                //                foy.TebligatDoldur(tebl);
                //                tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(foy);
                //                tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                //                        //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.
                //                        if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                //                        {
                //                            tebl.HAZIRLAMA_TARIH = foy.TAKIP_TARIHI.Value;
                //                            tebl.POSTALANMA_TARIH = foy.TAKIP_TARIHI.Value;
                //                            tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                //                            //tebl.KAYIT_TARIHI = DataTime.Now;
                //                            tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                //                            tebl.KONTROL_VERSIYON++;
                //                            tebl.ICRA_ILK_TEBLIGAT_MI=true;
                //                            tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                //                            tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                //                            tebl.MUHASEBE_ALT_KATEGORI_ID = 1;
                //                            tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                //                            tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                //                        }
                //              foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                //            {
                //                if (!taraf.TAKIP_EDEN_MI) //Takip edilenler.//TODO:DÜZELT BURAYI
                //                {
                //                    AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                //                        tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                //                    mhtp.TEBLIGAT_HEDEF_TIP = 1;
                //                    mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                //                    mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                //                    mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                //                    mhtp.MUHASEBE_ALT_KATEGORI_ID =
                //                        (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                //                    mhtp.EVRAK_TARIHI = DateTime.Today;
                //                    mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                //                    mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                //                    mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                //                    mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                //                    mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                //                    //TODO: Sýralý kayýt
                //                    //mhtp.TEBLIGAT_ADRESI = taraf.CARI_IDSource. //KALDI:aktiff adres
                //                }

                //                else if (taraf.TAKIP_EDEN_MI) //TakipEdenler//TODO:DÜZELT BURAYI
                //                {
                //                    AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                //                        tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                //                    ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                //                    ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();

                //                }
                //            }

                //        }

                //    else
                //    {
                //        tebl = foy.TebligatGetir();
                //        tebl.ACIKLAMA = iliski.AsamaAciklamaGetir(foy);
                //        tebl.KONU_ID = iliski.TEBLIGAT_KONU_ID.Value;
                //        tebl.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                //        tebl.TEBLIGAT_REFERANS_NO = DateTime.Now.Ticks.ToString();

                //        //TODO: Yukarýdaki yer bugünü kurtarmak için yapýlmýþ olup acilen deðiþtirilmesi gerekmektedir.

                //        if (iliski.TEBLIGAT_KONU_IDSource.ILK_TEBLIGAT_MI)
                //        {
                //            tebl.HAZIRLAMA_TARIH = foy.TAKIP_TARIHI.Value;
                //            tebl.POSTALANMA_TARIH = foy.TAKIP_TARIHI.Value;
                //            tebl.ANA_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ANA_TUR_ID;
                //            tebl.ICRA_ILK_TEBLIGAT_MI = true;
                //            tebl.ALT_TUR_ID = iliski.TEBLIGAT_KONU_IDSource.ALT_TUR_ID;
                //            tebl.MUHASEBE_ALT_KATEGORI_ID = (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi; ;
                //            //tebl.KAYIT_TARIHI = DataTime.Now;
                //            tebl.KONTROL_NE_ZAMAN = DateTime.Now;
                //            tebl.KONTROL_VERSIYON++;
                //            tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Clear();
                //            tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Clear();
                //            foreach (AV001_TI_BIL_FOY_TARAF taraf in foy.AV001_TI_BIL_FOY_TARAFCollection)
                //            {
                //                if (!taraf.TAKIP_EDEN_MI) //Takip edilenler.//TODO:DÜZELT BURAYI
                //                {
                //                    AV001_TDI_BIL_TEBLIGAT_MUHATAP mhtp =
                //                        tebl.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                //                    mhtp.TEBLIGAT_HEDEF_TIP = 1;
                //                    mhtp.ALAN_CARI_ID = taraf.CARI_ID;
                //                    mhtp.MUHATAP_CARI_ID = taraf.CARI_ID.Value;
                //                    mhtp.MUHATAP_TARAF_KOD = taraf.TARAF_KODU;
                //                    mhtp.MUHASEBE_ALT_KATEGORI_ID =
                //                        (int)AvukatProLib.Extras.MuhasebeAltKategoriId.iLK_TEBLiGAT_GiDERi;
                //                    mhtp.EVRAK_TARIHI = DateTime.Today;
                //                    mhtp.EVRAK_NO = DateTime.Today.Year + "/" + DateTime.Now.Millisecond;
                //                    mhtp.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                //                    mhtp.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                //                    mhtp.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                //                    mhtp.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                //                    //TODO: Sýralý kayýt
                //                    //mhtp.TEBLIGAT_ADRESI = taraf.CARI_IDSource. //KALDI:aktiff adres
                //                }
                //                else //TODO:TakipEdenler
                //                {
                //                    AV001_TDI_BIL_TEBLIGAT_YAPAN ypn =
                //                        tebl.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                //                    ypn.YAPAN_CARI_ID = taraf.CARI_ID.Value;
                //                    ypn.TARAF_KOD = ((TarafKodu)taraf.TARAF_KODU).ToString()[0].ToString();

                //                }
                //            }

                //        }
                //          foy.AV001_TDI_BIL_TEBLIGATCollection.Add(tebl);
                //        }

                //        }
                //    }
                //}

                #endregion

                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren,
                                                                 typeof(TList<NN_ICRA_GAYRIMENKUL>),
                                                                 typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>),
                                                                 typeof(TList<NN_ICRA_KIYMETLI_EVRAK>),
                                                                 typeof(TList<NN_ICRA_POLICE>),
                                                                 typeof(TList<NN_ICRA_SOZLESME>));

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(trans, foy.AV001_TI_BIL_ALACAK_NEDENCollection);

                #region ICRA Police ,Gayrimenkul,Sozlesme,KýymetliEvrak,ARAC  Kayýt NN

                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    if (foy.NN_ICRA_KIYMETLI_EVRAKCollection.Count == 0 &&
                        foy.NN_ICRA_GEMI_UCAK_ARACCollection.Count == 0 && foy.NN_ICRA_GAYRIMENKULCollection.Count == 0 &&
                        foy.NN_ICRA_SOZLESMECollection.Count == 0)
                    {
                        foreach (
                            AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK aNKEvrak in
                                neden.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection)
                        {
                            NN_ICRA_KIYMETLI_EVRAK kEvrak = foy.NN_ICRA_KIYMETLI_EVRAKCollection.AddNew();
                            kEvrak.KIYMETLI_EVRAK_IDSource = aNKEvrak.KIYMETLI_EVRAK_IDSource;
                            kEvrak.ICRA_FOY_ID = foy.ID;
                        }
                        foreach (
                            AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARAC gua in
                                neden.AV001_TI_BIL_ALACAK_NEDEN_GEMI_UCAK_ARACCollection)
                        {
                            NN_ICRA_GEMI_UCAK_ARAC Igua = foy.NN_ICRA_GEMI_UCAK_ARACCollection.AddNew();
                            Igua.GEMI_UCAK_ARAC_IDSource = gua.GEMI_UCAK_ARAC_IDSource;
                            Igua.ICRA_FOY_ID = foy.ID;
                        }
                        foreach (
                            AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKUL gayrimenkul in
                                neden.AV001_TI_BIL_ALACAK_NEDEN_GAYRIMENKULCollection)
                        {
                            NN_ICRA_GAYRIMENKUL Igayrimenkul = foy.NN_ICRA_GAYRIMENKULCollection.AddNew();
                            Igayrimenkul.GAYRIMENKUL_IDSource = gayrimenkul.GAYRIMENKUL_IDSource;
                            Igayrimenkul.ICRA_FOY_ID = foy.ID;
                        }
                        foreach (
                            AV001_TDI_BIL_SOZLESME sozlesme in
                                neden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                        {
                            NN_ICRA_SOZLESME soz = foy.NN_ICRA_SOZLESMECollection.AddNew();
                            soz.SOZLESME_IDSource = sozlesme;
                            soz.ICRA_FOY_ID = foy.ID;
                        }

                        // todo : poliçede eklenince yukardýkilere benzer þekilde oluþturulacak
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren,
                                                                         typeof(TList<NN_ICRA_GAYRIMENKUL>),
                                                                         typeof(TList<NN_ICRA_GEMI_UCAK_ARAC>),
                                                                         typeof(TList<NN_ICRA_KIYMETLI_EVRAK>),
                                                                         typeof(TList<NN_ICRA_POLICE>),
                                                                         typeof(TList<NN_ICRA_SOZLESME>));
                    }
                }

                #endregion

                #region SozlesmeBaðýmsýz

                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, szListBagýmsýz);

                //Sozlesmeye Baglý Gayrimenkul
                foreach (AV001_TDI_BIL_SOZLESME s in szListBagýmsýz)
                {
                    s.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.ForEach(
                        delegate(AV001_TI_BIL_GAYRIMENKUL obj)
                        {
                            if (s.NN_SOZLESME_GAYRIMENKULCollection.FindAll
                                    (NN_SOZLESME_GAYRIMENKULColumn.GAYRIMENKUL_ID, obj.ID).Count == 0)
                            {
                                NN_SOZLESME_GAYRIMENKUL gm = s.NN_SOZLESME_GAYRIMENKULCollection.AddNew();

                                gm.GAYRIMENKUL_IDSource = obj;
                                gm.SOZLESME_ID = s.ID;
                            }
                        });
                }
                foreach (AV001_TDI_BIL_SOZLESME s in szListBagýmsýz)
                {
                    s.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_NN_SOZLESME_GEMI_UCAK_ARAC.ForEach(
                        delegate(AV001_TDI_BIL_GEMI_UCAK_ARAC obj)
                        {
                            if (s.NN_SOZLESME_GEMI_UCAK_ARACCollection.FindAll
                                    (NN_SOZLESME_GEMI_UCAK_ARACColumn.GEMI_UCAK_ARAC_ID, obj.ID).Count == 0)
                            {
                                NN_SOZLESME_GEMI_UCAK_ARAC gm = s.NN_SOZLESME_GEMI_UCAK_ARACCollection.AddNew();

                                gm.GEMI_UCAK_ARAC_IDSource = obj;
                                gm.SOZLESME_ID = s.ID;
                            }
                        });
                    foreach (AV001_TDI_BIL_SOZLESME sozlesme in szListBagýmsýz)
                    {
                        NN_ICRA_SOZLESME soz = foy.NN_ICRA_SOZLESMECollection.AddNew();
                        soz.SOZLESME_IDSource = sozlesme;
                        soz.ICRA_FOY_ID = foy.ID;
                    }
                }

                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepSave(trans, szListBagýmsýz,
                                                                       DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>),
                                                                       typeof(TList<NN_SOZLESME_GAYRIMENKUL>),
                                                                       typeof(TList<NN_SOZLESME_GEMI_UCAK_ARAC>));
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(trans, foy, DeepSaveType.IncludeChildren,
                                                                 typeof(TList<NN_ICRA_SOZLESME>));

                #endregion

                if (IcraFoyKaydedildi != null)
                {
                    IcraFoyKaydedildi(this, new BelgeUtil.IcraFoyKaydedildiEventArgs(foy));
                }

                trans.Commit();

                return true;
            }

            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }
        }

        private void keList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();
            kEvrak.KAYIT_TARIHI = DateTime.Now;
            kEvrak.KONTROL_NE_ZAMAN = DateTime.Now;
            kEvrak.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            kEvrak.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            kEvrak.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            kEvrak.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = kEvrak;
        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.KullaniciAyar.frmGenelAyar frmGenelAyar = new AdimAdimDavaKaydi.Util.KullaniciAyar.frmGenelAyar();
            frmGenelAyar.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenWebSite("www.avukatpro.com/icrakayit.aspx?Id=3");
        }

        private void lnkKayitEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditor frmEdit = new frmEditor();

            frmEdit.MdiParent = mdiAvukatPro.MainForm;
            frmEdit.Show();
        }

        private void lnkKlasikKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmIcraDosyaKayit frmIcraKaydet = new frmIcraDosyaKayit();
            frmIcraKaydet.Show();
        }

        private void lnkVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.OpenWebSite(
                "http://www.avukatpro.com/images/video/sihirbazIcraKayit/Sihirbazla%20Ä°cra%20Dosya%20KaydÄ±_demo.htm");
        }

        private void LoadData()
        {
            //Týklayýnca gelecekler
            lueBorcluTaraf.Properties.NullText = "Seç";
            lueAlacakliTaraf.Properties.NullText = "Seç";
            lueMudurlukNo.Properties.NullText = "Seç";

            //dolu gelecekler
            lueTakipYolu.Properties.NullText = "Seç";
            rLueBorcluTaraf.NullText = "Seç";
            rLueAlacakliTaraf.NullText = "Seç";
            rLueAlacakliTK.NullText = "Seç";
            rLueDovizID.NullText = "Seç";
            rLueBorcluTK.NullText = "Seç";
            lueTakipKonusu.Enabled = false;
            BelgeUtil.Inits.TakipYoluGetir(lueTakipYolu.Properties);

            // Inits.CariGetir(rLueBorcluTaraf);
            //Inits.CariGetir(lueBorcluTaraf);
            BelgeUtil.Inits.perCariGetir(rLueBorcluTaraf);
            lueBorcluTaraf.Enter += BelgeUtil.Inits.perCariGetir_Enter;

            //Inits.CariGetir(rLueAlacakliTaraf);
            //Inits.CariGetir(lueAlacakliTaraf);
            BelgeUtil.Inits.perCariGetir(rLueAlacakliTaraf);
            lueAlacakliTaraf.Enter += BelgeUtil.Inits.perCariGetir_Enter;
            BelgeUtil.Inits.TarafKoduGetir(rLueAlacakliTK);
            lueMudurlukNo.Enter += BelgeUtil.Inits.AdliBirimNoGetir_Enter;
            BelgeUtil.Inits.DovizTipGetir(rLueDovizID);

            //Inits.FaizTipiGetir(rLueFaizTipId);
            M_1.CheckState = CheckState.Checked;
            TarafSifatGetir(AvukatProLib.Extras.IcraTarafKodu.TakipEden, new[]
                                                                           {
                                                                               lueAlacakliSifat.Properties,
                                                                               rLueAlacakliSifat
                                                                           });

            lueAlacakliSifat.Properties.ValueMember = string.Empty;
            BelgeUtil.Inits.TarafKoduGetir(rLueBorcluTK);
            TarafSifatGetir(AvukatProLib.Extras.IcraTarafKodu.TakipEdilen, new[]
                                                                             {
                                                                                 lueBorcluSifat.Properties,
                                                                                 rLueBorcluSifat
                                                                             });
            lueBorcluSifat.Properties.ValueMember = string.Empty;
        }

        private void LoadTree(System.Windows.Forms.Panel pn)
        {
            pn.Controls.Add(ucAdimTree1);
            ucAdimTree1.Dock = DockStyle.Fill;
        }

        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            frmCariGenelGiris frm = new frmCariGenelGiris();

            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Name.Contains("OzelKod") && e.IsTypedValue)
                {
                    try
                    {
                        AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();
                        ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                        ozel.KONTROL_KIM = "AVUKATPRO";
                        ozel.STAMP = 1;
                        ozel.KONTROL_VERSIYON = 1;
                        ozel.KOD = e.TypedValue;
                        DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                        ((TList<AV001_TDI_KOD_FOY_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

            if (e.IsTypedValue)
            {
                if (e.SenderLookUp.Name.Contains("AlacakliTaraf"))
                {
                    try
                    {
                        if (e.IsTypedValue)
                            frm.tmpCariAd = e.TypedValue;
                        if (M_1.Checked)
                        {
                            frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                            //frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };
                            return;
                        }
                        else if (K_1.Checked)
                        {
                            frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                            //frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };
                            return;
                        }
                        else
                        {
                            //frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };
                        }
                    }

                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else if (e.SenderLookUp.Name.Contains("BorcluTaraf") && e.IsTypedValue)
                {
                    if (M_2.Checked)
                    {
                        frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                        return;
                    }
                    else if (K_2.Checked)
                    {
                        frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                        return;
                    }
                    else
                    {
                        // frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                    }
                }

                else if (e.SenderLookUp.Name.Contains("AlacakliVekil"))
                {
                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    frm.FormClosed += delegate
                                          {
                                              DialogResult dr = frm.KayitBasarili;
                                              if (dr == System.Windows.Forms.DialogResult.OK)
                                              {
                                                  BelgeUtil.Inits.perCariGetir(lueAlacakliVekil.Properties);
                                              }
                                          };
                }
                else if (e.SenderLookUp.Name.Contains("BorcluVekil"))
                {
                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    frm.FormClosed += delegate
                                          {
                                              DialogResult dr = frm.KayitBasarili;
                                              if (dr == System.Windows.Forms.DialogResult.OK)
                                              {
                                                  BelgeUtil.Inits.perCariGetir(lueBorcluVekil.Properties);
                                                  ((TList<AV001_TDI_BIL_CARI>)(e.SenderLookUp.Properties.DataSource)).
                                                      Add(frm.MyCari);
                                              }
                                          };
                }
            }
        }

        private void lstAlacaklilar_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                int cariId = (int)e.Node.GetValue("CARI_ID");

                AV001_TI_BIL_FOY_TARAF taraf = (AV001_TI_BIL_FOY_TARAF)((TreeList)sender).GetDataRecordByNode(e.Node);

                gcAlacakliVekil.DataSource = taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection;
            }
        }

        private void lstBorclular_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                int cariId = (int)e.Node.GetValue("CARI_ID");

                AV001_TI_BIL_FOY_TARAF taraf = (AV001_TI_BIL_FOY_TARAF)((TreeList)sender).GetDataRecordByNode(e.Node);

                gcBorcluVekil.DataSource = taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection;
            }
        }

        private void lueAdliBirimAdliye_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                MyFoy.ADLI_BIRIM_ADLIYE_ID = (int)e.NewValue;
                ucAdimTree1.NodeChecked("Müdürlük");
            }
        }

        private void lueAlacakliTaraf_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if (e.Button.Tag == "mEkle")
            {
                LookUpEdit lue = sender as LookUpEdit;
                try
                {
                    if (lue.Text != string.Empty)
                    {
                        if (frm.IsDisposed)
                            frm = new frmCariGenelGiris();
                        frm.tmpCariAd = lue.Text;
                        if (M_1.Checked)
                        {
                            frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                            //frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };
                            return;
                        }
                        else if (K_1.Checked)
                        {
                            frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                            // frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };

                            return;
                        }
                        else
                        {
                            // frm.MdiParent = null;
                            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                            frm.Show();
                            frm.FormClosed += delegate
                                                  {
                                                      DialogResult dr = frm.KayitBasarili;
                                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                                      {
                                                          BelgeUtil.Inits.perCariGetir(lueAlacakliTaraf.Properties);
                                                      }
                                                  };
                        }
                    }
                }

                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void lueAlacakliVekil_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if (e.Button.Tag == "mEkle")
            {
                if (lue.Text != string.Empty)
                {
                    if (frm.IsDisposed)
                        frm = new frmCariGenelGiris();
                    frm.tmpCariAd = lue.Text;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    frm.FormClosed += delegate
                                          {
                                              DialogResult dr = frm.KayitBasarili;
                                              if (dr == System.Windows.Forms.DialogResult.OK)
                                              {
                                                  BelgeUtil.Inits.perCariGetir(lueAlacakliVekil.Properties);
                                              }
                                          };
                }
            }
        }

        private void lueBorcluTaraf_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris frm = new frmCariGenelGiris();

            if (e.Button.Tag == "mEkle")
            {
                if (lue.Text != string.Empty)
                {
                    if (frm.IsDisposed)
                        frm = new frmCariGenelGiris();
                    frm.tmpCariAd = lue.Text;
                    if (M_2.Checked)
                    {
                        frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Müvekkil);

                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                        return;
                    }
                    else if (K_2.Checked)
                    {
                        frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Karþý_Taraf);

                        // frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                        return;
                    }
                    else
                    {
                        //frm.MdiParent = null;
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.Show();
                        frm.FormClosed += delegate
                                              {
                                                  DialogResult dr = frm.KayitBasarili;
                                                  if (dr == System.Windows.Forms.DialogResult.OK)
                                                  {
                                                      BelgeUtil.Inits.perCariGetir(lueBorcluTaraf.Properties);
                                                  }
                                              };
                    }
                }
            }
        }

        private void lueBorcluVekil_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if (e.Button.Tag == "mEkle")
            {
                if (lue.Text != string.Empty)
                {
                    if (frm.IsDisposed)
                        frm = new frmCariGenelGiris();
                    frm.tmpCariAd = lue.Text;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    frm.FormClosed += delegate
                                          {
                                              DialogResult dr = frm.KayitBasarili;
                                              if (dr == System.Windows.Forms.DialogResult.OK)
                                              {
                                                  BelgeUtil.Inits.perCariGetir(lueBorcluVekil.Properties);
                                              }
                                          };
                }
            }
        }

        private void lueFormTipi_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lk = sender as LookUpEdit;
            if (lk.EditValue != null)
            {
                if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                {
                    if (ilkFormTipId != (int)lueFormTipi.EditValue)
                    {
                        DialogResult ds =
                            XtraMessageBox.Show("Bütün Kayýtlar Silinecektir. Devam Etmek Ýstiyor musunuz ?",
                                                "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (ds == DialogResult.Yes)
                        {
                            gcAlacakNedenleri.DataSource = null;
                            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Clear();
                            MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Clear();
                            MyFoy.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.Clear();
                            if (MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count > 0)
                                MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Clear();
                        }
                        else
                        {
                            lueFormTipi.EditValue = ilkFormTipId;
                        }
                    }
                }

                #region AdimKontrol

                //Forum Tipi 49 and 153
                if ((FormTipleri)lk.EditValue == FormTipleri.Form49 ||
                    (FormTipleri)lk.EditValue == FormTipleri.Form153)
                {
                    wpAdim16.Visible = false;
                    tabArac.PageVisible = false;
                }
                else
                {
                    wpAdim16.Visible = true;
                    tabArac.PageVisible = true;
                }

                //ForumTipi50
                if ((FormTipleri)lk.EditValue == FormTipleri.Form50)
                {
                    //wpAdim16.Visible = false;
                    ucGayriMenkul1.Visible = false;
                    tabArac.Text = "[Gemi-Uçak-Araç]";
                    tabKiymetliEvrak.PageVisible = false;
                    DataDoldur(DataKontrol.Arac);
                }
                else
                {
                    ucGayriMenkul1.Visible = true;
                    tabArac.Text = "[Gayrimenkul]";
                }

                //ForumTipi 51
                if ((FormTipleri)lk.EditValue == FormTipleri.Form51)
                {
                    //wpAdim10.Visible = false;
                    tabUcakGemiArac.Visible = false;
                    tabArac.Text = "[Gayrimenkul]";
                    wpAdim16.Visible = false;
                    tabKiymetliEvrak.PageVisible = false;
                    ucGayriMenkul1.Dock = DockStyle.Fill;
                    DataDoldur(DataKontrol.GayriMenkul);
                }
                else
                {
                    //wpAdim10.Visible = true;
                    tabKiymetliEvrak.PageVisible = true;
                    ucGayriMenkul1.Dock = DockStyle.Top;
                    tabArac.Text = "[Gayrimenkul]";
                    tabUcakGemiArac.Visible = true;
                }

                //Forum Tip52 and163
                if ((FormTipleri)lk.EditValue == FormTipleri.Form52 ||
                    (FormTipleri)lk.EditValue == FormTipleri.Form163)
                {
                    //wpAdim10.Visible = false;
                    tabKiymetliEvrak.PageVisible = false;
                    tabArac.PageVisible = false;
                    wpAdim16.Visible = false;
                }

                //Forumtipi 54
                if ((FormTipleri)lk.EditValue == FormTipleri.Form54)
                {
                    //wpAdim10.Visible = false;
                    tabKiymetliEvrak.PageVisible = false;
                    tabUcakGemiArac.Visible = false;
                    tabArac.Text = "[Gayrimenkul]";
                    ucGayriMenkul1.Dock = DockStyle.Fill;
                }

                //Forumtipi 55
                if ((FormTipleri)lk.EditValue == FormTipleri.Form55)
                {
                    wpAdim12.Visible = false;

                    //wpAdim10.Visible = false;
                }
                else
                {
                    wpAdim12.Visible = true;
                }

                //forumtipi 56
                if ((FormTipleri)lk.EditValue == FormTipleri.Form56)
                {
                    //wpAdim10.Visible = false;
                    tabKiymetliEvrak.PageVisible = false;
                    tabUcakGemiArac.Visible = false;
                    tabArac.Text = "[Gayrimenkul]";
                    ucGayriMenkul1.Dock = DockStyle.Fill;
                    wpAdim16.Visible = false;
                    DataDoldur(DataKontrol.GayriMenkul);
                }

                //forumtipi 151
                if ((FormTipleri)lk.EditValue == FormTipleri.Form151)
                {
                    tabKiymetliEvrak.PageVisible = false;
                    tabUcakGemiArac.Visible = false;
                    tabArac.Text = "[Gayrimenkul]";
                    ucGayriMenkul1.Dock = DockStyle.Fill;
                    DataDoldur(DataKontrol.GayriMenkul);
                }

                //forumtipi152
                if ((FormTipleri)lk.EditValue == FormTipleri.Form152)
                {
                    tabKiymetliEvrak.PageVisible = false;
                    tabUcakGemiArac.Visible = false;
                    ucGayriMenkul1.Dock = DockStyle.Fill;
                    tabArac.Text = "[Gayrimenkul]";
                    wpAdim16.Visible = false;
                    DataDoldur(DataKontrol.GayriMenkul);
                }

                //forumtipi201
                if ((FormTipleri)lk.EditValue == FormTipleri.Form201)
                {
                    ucGayriMenkul1.Visible = false;
                    tabArac.Text = "[Gemi-Uçak-Araç]";
                    tabKiymetliEvrak.PageVisible = false;
                    DataDoldur(DataKontrol.Arac);
                }

                #endregion
            }
            this.GetPaketForm();
        }

        private void lueFormTipi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                neden.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
            }

            if (e.NewValue != null)
            {
                lueTakipKonusu.Enabled = lueFormTipi.EditValue != null;
                ucAdimTree1.NodeChecked(new[] { "Form Tipi ve Konusu" });

                MyFoy.FORM_TIP_ID = (int)e.NewValue;

                string[] str = null;
                string formTip = null;

                formTip = lueFormTipi.Properties.GetDisplayText((int)e.NewValue);

                str = formTip.Split('(');
                str[0] = str[0].Replace("Form", "");

                #region <cc-20090806>

                //Viewden Gelecek þekilde düzenlendi ...

                #endregion >/cc-200908069>

                per_TI_KOD_TAKIP_TALEPQuery qu = new per_TI_KOD_TAKIP_TALEPQuery();
                qu.Append(per_TI_KOD_TAKIP_TALEPColumn.FORM_TIPI, str[0]);
                lueTakipKonusu.Properties.DataSource = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.Find(qu);

                // VList < TI_KOD_TAKIP_TALEP > list= DataRepository.TI_KOD_TAKIP_TALEPProvider.Find(string.Format("FORM_TIPI = '{0}'", str[0]));
                //= list;
                if (((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource).Count == 1)
                {
                    lueTakipKonusu.EditValue =
                        ((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource)[0].ID;
                    MyFoy.TAKIP_TALEP_ID = ((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource)[0].ID;

                    switch ((int)e.NewValue)
                    {
                        case 2:
                            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                neden.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                                neden.BSMV_HESAPLANSIN = true;
                            }
                            break;

                        case 7:
                            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                neden.BSMV_HESAPLANSIN = true;
                            }
                            break;

                        case 8:
                            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                neden.BSMV_HESAPLANSIN = true;
                            }
                            break;

                        case 13:
                            foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                            {
                                neden.BSMV_HESAPLANSIN = true;
                            }
                            break;
                    }
                }
                else if (((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource).Count > 1)
                {
                    VList<per_TI_KOD_TAKIP_TALEP> temp = new VList<per_TI_KOD_TAKIP_TALEP>();

                    switch ((int)e.NewValue)
                    {
                        case 6:

                            temp =
                                ((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource).FindAll(
                                    per_TI_KOD_TAKIP_TALEPColumn.ID, 10);
                            break;

                        case 4:

                            temp =
                                ((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource).FindAll(
                                    per_TI_KOD_TAKIP_TALEPColumn.ID, 18);

                            break;

                        case 9:

                            temp =
                                ((VList<per_TI_KOD_TAKIP_TALEP>)lueTakipKonusu.Properties.DataSource).FindAll(
                                    per_TI_KOD_TAKIP_TALEPColumn.ID, 12);

                            break;
                    }
                    if (temp.Count > 0)
                        lueTakipKonusu.EditValue = temp[0].ID;
                }

                TI_KOD_FORM_TIP formTipi = DataRepository.TI_KOD_FORM_TIPProvider.GetByID((int)e.NewValue);

                #region <AC - 20090618>

                // lueTakipYolu.Properties.DataSource view dan geldiði için TList VList olarak deðiþtirildi.
                VList<per_TI_KOD_TAKIP_YOLU> obj = (VList<per_TI_KOD_TAKIP_YOLU>)lueTakipYolu.Properties.DataSource;

                #endregion </AC - 20090618>

                obj.Filter = "ID = " + formTipi.TAKIP_YOLU_ID;

                if (obj.Count > 0)
                    lueTakipYolu.EditValue = obj[0].ID;

                formKodId = Convert.ToInt32(str[0]);
            }
        }

        private void lueOzelKod1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && e.Button.Tag == "mEkle")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod1.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod1_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod1.Text != "Seç")
            {
                ucAdimTree1.NodeChecked("Özel Kod 1");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Kod 1");
                OzelTanimCheckEt();
            }
        }

        private void lueOzelKod1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (lueOzelKod1.EditValue != null)
                ucAdimTree1.NodeChecked("Özel Kod 1");
            else
                ucAdimTree1.NodeUnChecked("Özel Kod 1");
        }

        private void lueOzelKod1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && lue.Text != "Seç")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod1.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && e.Button.Tag == "mEkle")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod2.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod2_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod2.Text != "Seç")
            {
                ucAdimTree1.NodeChecked("Özel Kod 2");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Kod 2");
                OzelTanimCheckEt();
            }
        }

        private void lueOzelKod2_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && lue.Text != "Seç")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod2.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod3_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && e.Button.Tag == "mEkle")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod3.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod3_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod3.Text != "Seç")
            {
                ucAdimTree1.NodeChecked("Özel Kod 3");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Kod 3");
                OzelTanimCheckEt();
            }
        }

        private void lueOzelKod3_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && lue.Text != "Seç")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod3.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod4_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && e.Button.Tag == "mEkle")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod3.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueOzelKod4_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOzelKod4.Text != "Seç")
            {
                ucAdimTree1.NodeChecked("Özel Kod 4");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Özel Kod 4");
                OzelTanimCheckEt();
            }
        }

        private void lueOzelKod4_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            try
            {
                if (lue.Text != string.Empty && lue.Text != "Seç")
                {
                    AV001_TDI_KOD_FOY_OZEL ozel = new AV001_TDI_KOD_FOY_OZEL();

                    //ozel.SUBE_KODU = "GENEL";
                    ozel.KONTROL_NE_ZAMAN = DateTime.Now;
                    ozel.KONTROL_KIM = "AVUKATPRO";
                    ozel.STAMP = 1;
                    ozel.KONTROL_VERSIYON = 1;
                    ozel.KOD = lue.Text;
                    DataRepository.AV001_TDI_KOD_FOY_OZELProvider.Save(ozel);
                    ((TList<AV001_TDI_KOD_FOY_OZEL>)lueOzelKod4.Properties.DataSource).Add(ozel);
                    XtraMessageBox.Show("Özel kod baþarýyla eklenmiþtir.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("uKOD"))
                    XtraMessageBox.Show("Girilen kod kod daha önce kaydedilmiþ." + Environment.NewLine + "Lütfen baþka bir özel kod giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void lueTakipKonusu_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                MyFoy.TAKIP_TALEP_ID = (int?)e.NewValue;
            }
            if (MyFoy.TAKIP_TALEP_ID.HasValue || MyFoy.FORM_TIP_ID.HasValue)
            {
                if (MyFoy.FORM_TIP_ID.Value == 6 && MyFoy.TAKIP_TALEP_ID.Value == 9)
                {
                    //FORM TÝPÝ 54 ||TAKIP KONUSU MENKUL REHNI

                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.MENKUL_TESLIMI_54;

                        // 30; //ALACAK NEDEN MENKU TESLÝM
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 4 && MyFoy.TAKIP_TALEP_ID.Value == 18)
                {
                    //FORM TÝPÝ 54 ||TAKIP KONUSU MENKUL REHNI

                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.DIGER_ALACAK_53;

                        // 10001; //ALACAK NEDEN MENKU TESLÝM
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 4 && MyFoy.TAKIP_TALEP_ID.Value == 5)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.NAFAKA_ISTIRAK_53; // 16; //NAFAKA ÝÞTÝRAK
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 4 && MyFoy.TAKIP_TALEP_ID.Value == 6)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.ISCI_ALACAGI_KIDEM_TAZMINATI_53;

                        //25; //ÝÞÇÝ ALACAÐI KIDEM TAZMINATI
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 4 && MyFoy.TAKIP_TALEP_ID.Value == 7)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.ISIN_YAPILMASI_53; //  19; //ÝÞÝN YAPILMASI
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 4 && MyFoy.TAKIP_TALEP_ID.Value == 8)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.IRTIFAK_HAKKI_TESISI_53;

                        // 21; //ÝRTÝFAK HAKKI TESÝSÝ
                    }
                }
                if (MyFoy.FORM_TIP_ID.Value == 9 && MyFoy.TAKIP_TALEP_ID.Value == 12)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = (int)AlacakNeden.Tahliye_Taahhudu_12; //12; //TAHLÝYE TAAHHÜDÜ
                    }
                }
            }
        }

        private void lueTakipYolu_EditValueChanging(object sender, ChangingEventArgs e)
        {
            MyFoy.TAKIP_YOLU_ID = (int)e.NewValue;
        }

        private void M_1_CheckStateChanged(object sender, EventArgs e)
        {
            if (M_1.CheckState == CheckState.Checked)
            {
                K_1.CheckState = CheckState.Unchecked;
                D_1.CheckState = CheckState.Unchecked;

                if (lueAlacakliTaraf.Properties.DataSource != null)
                {
                    ((TList<AV001_TDI_BIL_CARI>)lueAlacakliTaraf.Properties.DataSource).Filter = string.Empty;

                    ((TList<AV001_TDI_BIL_CARI>)lueAlacakliTaraf.Properties.DataSource).Filter = "MUVEKKIL_MI = TRUE";
                }

                lueAlacakliTaraf.Properties.ValueMember = string.Empty;
            }
        }

        private void M_2_CheckStateChanged(object sender, EventArgs e)
        {
            if (M_2.CheckState == CheckState.Checked)
            {
                K_2.CheckState = CheckState.Unchecked;
                D_2.CheckState = CheckState.Unchecked;

                ((TList<AV001_TDI_BIL_CARI>)lueBorcluTaraf.Properties.DataSource).Filter = string.Empty;

                ((TList<AV001_TDI_BIL_CARI>)lueBorcluTaraf.Properties.DataSource).Filter = "MUVEKKIL_MI = TRUE";

                lueBorcluTaraf.Properties.ValueMember = string.Empty;
            }
        }

        private void MyFoy_ColumnChanged(object sender, AV001_TI_BIL_FOYEventArgs e)
        {
            if (myFoy.FORM_TIP_ID.HasValue)

                #region KAPANMIÞ

                //if (e.Column == AV001_TI_BIL_FOYColumn.FORM_TIP_ID)
                //{
                //     ucAlacakNedenTaraf1.DtAlacakNeden = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();
                //     gcTarafFaiz.DataSource = null;
                //}

                #endregion

                if (e.Column == AV001_TI_BIL_FOYColumn.TAKIP_TARIHI)
                    myFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI = myFoy.TAKIP_TARIHI;

            if (e.Column == AV001_TI_BIL_FOYColumn.FOY_NO)
            {
                AV001_TI_BIL_FOY foyNo = DataRepository.AV001_TI_BIL_FOYProvider.GetByFOY_NO(MyFoy.FOY_NO);

                if (foyNo != null)
                {
                    picOnay.Image = AdimAdimDavaKaydi.Properties.Resources.cancel1;
                    picOnay.ToolTip = "Bu foy numarasý daha önce kullanýlmýþtýr.";

                    ucAdimTree1.NodeUnChecked("Dosya No");
                    wpAdim2.AllowNext = false;
                }
                else
                {
                    picOnay.Image = AdimAdimDavaKaydi.Properties.Resources.accept1;
                    picOnay.ToolTip = "Foy numarasý onaylandý";
                    ucAdimTree1.NodeChecked("Dosya No");
                    wpAdim2.AllowNext = true;
                }
            }

            if (e.Column == AV001_TI_BIL_FOYColumn.FORM_TIP_ID)
            {
                if (myFoy.FORM_TIP_ID.Value == 2 || myFoy.FORM_TIP_ID.Value == 13)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 14;
                        neden.SABIT_FAIZ_UYGULA = true;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        neden.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 7 || myFoy.FORM_TIP_ID.Value == 8)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 32;
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 5)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 31;
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 6)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 29;
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }

                if (myFoy.FORM_TIP_ID.Value == 4)
                {
                    //Yukarý tasýnmýstýr
                    // myFoy.TAKIP_TALEP_ID = 10001;
                    myFoy.TAKIP_TALEP_ID = (int)TakipTalep.ILAMLI_ALACAK_53;
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 18;
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 9)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.ALACAK_NEDEN_KOD_ID = 12;
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 1 || myFoy.FORM_TIP_ID.Value == 8 || myFoy.FORM_TIP_ID.Value == 10 ||
                    myFoy.FORM_TIP_ID.Value == 12)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.SABIT_FAIZ_UYGULA = true;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Özel_Sabit_Faiz;
                        neden.HESAPLAMA_MODU = (byte)AvukatProLib.Extras.IcraDovizIslemTipi.Vade_Tarihinde_TL;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 11 || myFoy.FORM_TIP_ID.Value == 3)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Reeskont_Avans;
                    }
                }
                if (myFoy.FORM_TIP_ID.Value == 13)
                {
                    foreach (AV001_TI_BIL_ALACAK_NEDEN neden in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        neden.SABIT_FAIZ_UYGULA = false;
                        neden.TO_ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                        neden.ALACAK_FAIZ_TIP_ID = (int)FaizTip.Yasal_Faiz;
                    }
                }
            }

            if (MyFoy.FORM_TIP_ID.HasValue)
                ucAdimTree1.NodeChecked("Form Tipi");

            if (MyFoy.TAKIP_TALEP_ID.HasValue)
                ucAdimTree1.NodeChecked("Form Konusu");

            wpAdim1.AllowNext = MyFoy.FORM_TIP_ID.HasValue && MyFoy.TAKIP_TALEP_ID.HasValue;

            #region Kapanmýþ

            //if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
            //    ucAdimTree1.NodeChecked("Müdürlük");
            //if (MyFoy.TAKIP_YOLU_ID.HasValue)
            //    ucAdimTree1.NodeChecked("Takip Yolu");
            //if (MyFoy.ESAS_NO != "")
            //    ucAdimTree1.NodeChecked("Esas No");

            #endregion

            wpAdim3.AllowNext = MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue && MyFoy.TAKIP_YOLU_ID.HasValue &&
                                MyFoy.ESAS_NO != string.Empty &&
                                ucAdimTree1.NodeChecked("Müdürlük Bilgileri");

            //ForumTipi53/Diðer
            if (MyFoy.FORM_TIP_ID != null && MyFoy.TAKIP_TALEP_ID != null)
            {
                if ((FormTipleri)MyFoy.FORM_TIP_ID == FormTipleri.Form53)
                {
                    //wpAdim10.Visible = false;
                    if ((FormKonusu)MyFoy.TAKIP_TALEP_ID == FormKonusu.Form53_ISIN_YAPILMASI ||
                        (FormKonusu)MyFoy.TAKIP_TALEP_ID == FormKonusu.Form53_IRTIFAK_HAKKI)
                    {
                        wpAdim12.Visible = false;
                    }
                    else
                    {
                        wpAdim12.Visible = true;
                        tabKiymetliEvrak.PageVisible = false;
                        tabArac.PageVisible = false;
                    }
                }
                else
                {
                    wpAdim12.Visible = true;
                }
                this.GetPaketForm();
            }

            #region kapanmýþ

            ////ADIM-4
            //ucAdimTree1.NodeExpend("Özel Tanýmlar");

            // if (MyFoy.ICRA_OZEL_KOD1_ID.HasValue)
            //     ucAdimTree1.NodeChecked("Özel Kod 1");
            // else
            //     ucAdimTree1.NodeUnChecked("Özel Kod 1");
            // if (MyFoy.ICRA_OZEL_KOD2_ID.HasValue)
            //     ucAdimTree1.NodeChecked("Özel Kod 2");
            // else
            //     ucAdimTree1.NodeUnChecked("Özel Kod 2");
            // if (MyFoy.ICRA_OZEL_KOD3_ID.HasValue)
            //    ucAdimTree1.NodeChecked("Özel Kod 3");
            // else
            //    ucAdimTree1.NodeUnChecked("Özel Kod 3");
            //if (MyFoy.ICRA_OZEL_KOD4_ID.HasValue)
            //    ucAdimTree1.NodeChecked("Özel Kod 4");
            //else
            //    ucAdimTree1.NodeUnChecked("Özel Kod 4");
            //if (string.IsNullOrEmpty(MyFoy.REFERANS_NO) == false)
            //    ucAdimTree1.NodeChecked("Referans1");
            //else
            //    ucAdimTree1.NodeUnChecked("Referans1");
            //if (string.IsNullOrEmpty(MyFoy.REFERANS_NO2) == false)
            //    ucAdimTree1.NodeChecked("Referans2");
            //else
            //    ucAdimTree1.NodeUnChecked("Referans2");
            //if (string.IsNullOrEmpty(MyFoy.REFERANS_NO3) == false)
            //    ucAdimTree1.NodeChecked("Referans3");
            //else
            //    ucAdimTree1.NodeUnChecked("Referans3");

            #endregion

            HesaplanmisFaizKontrol(MyFoy);

            wpAdim3.AllowNext = MyFoy.TAKIP_YOLU_ID.HasValue && MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue;

            #region Kapanmýþ

            //if (wpAdim3.AllowNext)
            //    ucAdimTree1.NodeChecked("Müdürlük Bilgileri");

            //if (wpAdim4.AllowNext)
            //{
            //    ucAdimTree1.NodeChecked("Özel Tanýmlar");
            //}

            #endregion

            wpAdim5.AllowNext = MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0;
        }

        private void SetFoy()
        {
            MyFoy = new AV001_TI_BIL_FOY();

            foreach (string s in MyFoy.TableColumns)
            {
                if (s.EndsWith("DOVIZ_ID"))
                    MyFoy.GetType().GetProperty(s).SetValue(MyFoy, 1, null);
            }

            MyFoy.FOY_DURUM_ID = 2;
            MyFoy.TAKIP_TARIHI = DateTime.Today;
            MyFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI = DateTime.Now;
            MyFoy.FOY_NO_Kod = DateTime.Now.ToShortDateString();
            MyFoy.ESAS_NO = EsasNoOlustur();

            MyFoy.FOY_NO = FoyNoOlustur();

            #region SorumluAvukat

            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();
            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.AddingNew
                += AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_AddingNew;

            MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.ListChanged
                += AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection_ListChanged;

            #endregion

            #region BorcluOdeme

            MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            //MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.AddNew();
            MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection.ListChanged += AV001_TI_BIL_BORCLU_ODEMECollection_ListChanged;

            #endregion

            #region AlacakNedenleri

            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

            //MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.AddNew();

            MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ListChanged
                += AV001_TI_BIL_ALACAK_NEDENCollection_ListChanged;

            foreach (AV001_TI_BIL_ALACAK_NEDEN alacakNeden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                alacakNeden.ColumnChanged += alacakNeden_ColumnChanged;
            }

            #endregion

            #region IhtiyatiHacizIhtiyatiTedbir

            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection.ListChanged +=
                AV001_TDI_BIL_IHTIYATI_TEDBIRCollection_ListChanged;

            #endregion

            #region DosyaTaraflarý

            MyFoy.AV001_TI_BIL_FOY_TARAFCollection = new TList<AV001_TI_BIL_FOY_TARAF>();
            Alacakli = new TList<AV001_TI_BIL_FOY_TARAF>();
            Borclu = new TList<AV001_TI_BIL_FOY_TARAF>();

            #endregion

            #region TarafVekilleri

            MyFoy.AV001_TI_BIL_FOY_TARAF_VEKILCollection = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            AlacakliVekil = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();
            BorcluVekil = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            #endregion

            #region IhtiyatiHaciz_IhtiyatiTedbir

            MyFoy.AV001_TDI_BIL_IHTIYATI_TEDBIRCollection = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();

            MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

            ucIhtiyati_Haciz_Tedbir1.MyDataSource = MyFoy;

            #endregion

            MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
            MyFoy.AV001_TI_BIL_ILAM_MAHKEMESICollection.ListChanged += AV001_TI_BIL_ILAM_MAHKEMESICollection_ListChanged;

            this.ucFormIlamBilgileri1.Foy = MyFoy;
        }

        private void Sil()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_FOYProvider.Delete(MyFoy.ID);

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF_VEKIL> secilenler = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            int[] secilenIndexler = gwAlacakVekil.GetSelectedRows();

            for (int i = 0; i < secilenIndexler.Length; i++)
            {
                AV001_TI_BIL_FOY_TARAF_VEKIL obj =
                    (AV001_TI_BIL_FOY_TARAF_VEKIL)gwAlacakVekil.GetRow(secilenIndexler[i]);

                secilenler.Add(obj);
            }

            for (int j = 0; j < AlacakliVekil.Count; j++)
            {
                if (AlacakliVekil[j].IsSelected && !secilenler.Contains(AlacakliVekil[j]))
                    secilenler.Add(AlacakliVekil[j]);
            }

            if (secilenler.Count == 0) return;

            DialogResult ds = XtraMessageBox.Show("Bu vekili silmek istediðinizden emin misiniz ?",
                                                  "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (ds == DialogResult.Yes)
                {
                    for (int i = 0; i < secilenler.Count; i++)
                    {
                        AlacakliVekil.Remove(secilenler[i]);
                    }
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF_VEKIL> secilenler = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            int[] secilenIndexler = gwBorcluVekil.GetSelectedRows();

            for (int i = 0; i < secilenIndexler.Length; i++)
            {
                AV001_TI_BIL_FOY_TARAF_VEKIL obj =
                    (AV001_TI_BIL_FOY_TARAF_VEKIL)gwBorcluVekil.GetRow(secilenIndexler[i]);

                secilenler.Add(obj);
            }

            for (int j = 0; j < BorcluVekil.Count; j++)
            {
                if (BorcluVekil[j].IsSelected && !secilenler.Contains(BorcluVekil[j]))
                    secilenler.Add(BorcluVekil[j]);
            }

            if (secilenler.Count == 0) return;

            DialogResult ds = XtraMessageBox.Show("Bu vekili silmek istediðinizden emin misiniz ?",
                                                  "Silme Ýþlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (ds == DialogResult.Yes)
                {
                    for (int i = 0; i < secilenler.Count; i++)
                    {
                        BorcluVekil.Remove(secilenler[i]);
                    }
                }
            }
            BorcluVekil.ListChanged += BorcluVekil_ListChanged;
        }

        private bool SorumluAvkVarmi(int ID)
        {
            for (int i = 0; i < MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; i++)
            {
                if (MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[i].SORUMLU_AVUKAT_CARI_ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        private void sozTarafList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME_TARAF sozTaraf = new AV001_TDI_BIL_SOZLESME_TARAF();
            sozTaraf.KAYIT_TARIHI = DateTime.Now;
            sozTaraf.KONTROL_NE_ZAMAN = DateTime.Now;
            sozTaraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            sozTaraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            sozTaraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            sozTaraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            e.NewObject = sozTaraf;
        }

        private void TakipOnizleme(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY> foylerim)
        {
            frmEditor fedit = new frmEditor();
            fedit.MdiParent = mdiAvukatPro.MainForm;
            fedit.OpenAllSablon(BelgeUtil.Inits.context.VDIE_BIL_SABLON_RAPORs.Where(item => item.FORM_ORNEK_ID == this.myFoy.FORM_TIP_ID).ToList(), myFoy, true, false);
            fedit.SelectedFoys = foylerim;
        }

        private void TarafSifatGetir(AvukatProLib.Extras.IcraTarafKodu t, RepositoryItemLookUpEdit[] controls)
        {
            TList<TDIE_KOD_TARAF_SIFAT> obj = new TList<TDIE_KOD_TARAF_SIFAT>();

            foreach (RepositoryItemLookUpEdit lue in controls)
            {
                if (lue.DataSource == null)
                {
                    if (t == AvukatProLib.Extras.IcraTarafKodu.TakipEden)
                    {
                        obj = DataRepository.TDIE_KOD_TARAF_SIFATProvider.Find
                            (string.Format("HANGI_TARAFI = '{0}'", "TAKÝP EDEN"));
                    }

                    else if (t == AvukatProLib.Extras.IcraTarafKodu.TakipEdilen)
                    {
                        obj = DataRepository.TDIE_KOD_TARAF_SIFATProvider.Find("HANGI_TARAFI='TAKÝP EDÝLEN'");
                    }

                    lue.DisplayMember = "SIFAT";
                    lue.ValueMember = "ID";
                    lue.DataSource = obj;
                    lue.Columns.Clear();
                    lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SIFAT"));
                    lue.NullText = "Taraf Sýfatý Seç";
                }
            }
        }

        private void txtEsasNo_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (txtEsasNo.Text == "")
            {
                ucAdimTree1.NodeUnChecked("Esas No");
                ucAdimTree1.NodeUnChecked("Müdürlük Bilgileri");
            }
            else
            {
                ucAdimTree1.NodeChecked("Esas No");
            }
        }

        private void txtEsasNo_TextChanged(object sender, EventArgs e)
        {
            MyFoy.ESAS_NO = txtEsasNo.Text;
        }

        private void txtFoyNoKod_TextChanged(object sender, EventArgs e)
        {
            if (txtFoyNoKod.Text != string.Empty && txtFoyNoSayi.Text != string.Empty)
                ucAdimTree1.NodeChecked("Dosya No");

            else if ((txtFoyNoKod.Text == string.Empty))
                ucAdimTree1.NodeUnChecked("Dosya No");
        }

        private void txtRef1_TextChanged(object sender, EventArgs e)
        {
            if (txtRef1.Text != "")
            {
                ucAdimTree1.NodeChecked("Referans1");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Referans1");
                OzelTanimCheckEt();
            }
        }

        private void txtRef2_TextChanged(object sender, EventArgs e)
        {
            if (txtRef2.Text != "")
            {
                ucAdimTree1.NodeChecked("Referans2");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Referans2");
                OzelTanimCheckEt();
            }
        }

        private void txtRef3_TextChanged(object sender, EventArgs e)
        {
            if (txtRef3.Text != "")
            {
                ucAdimTree1.NodeChecked("Referans3");
                OzelTanimCheckEt();
            }
            else
            {
                ucAdimTree1.NodeUnChecked("Referans3");
                OzelTanimCheckEt();
            }
        }
        private void ucSozlesmeBilgileri1_SozlesmeValidateRecord(object sender,
                                                                 DevExpress.XtraVerticalGrid.Events.
                                                                     ValidateRecordEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME row = null;

            if (e.RecordIndex >= 0)
                row = ucSozlesmeBilgileri1.MyDataSource[e.RecordIndex];

            if (row != null)
            {
                SozlesmeTarafTip stTakipEden = new SozlesmeTarafTip();
                SozlesmeTarafTip stTakipEdilen = new SozlesmeTarafTip();
                TList<AV001_TDI_BIL_SOZLESME_TARAF> sozTarafList = null;
                switch ((SozlesmeAnaTip)row.TIP_ID)
                {
                    case SozlesmeAnaTip.Kira_Sozlemesi:
                        stTakipEden = SozlesmeTarafTip.Kiralayan;
                        stTakipEdilen = SozlesmeTarafTip.Kiracý;
                        tabArac.PageVisible = true;
                        ucGayriMenkul1.Dock = DockStyle.Fill;
                        tabUcakGemiArac.Visible = false;
                        break;

                    case SozlesmeAnaTip.Resmi_Senet:
                        stTakipEden = SozlesmeTarafTip.RehinAlan;
                        stTakipEdilen = SozlesmeTarafTip.RehinVeren;
                        break;

                    case SozlesmeAnaTip.Kredi_Sozlemesi:
                        stTakipEden = SozlesmeTarafTip.KrediVeren;
                        stTakipEdilen = SozlesmeTarafTip.KrediAlan;
                        break;

                    case SozlesmeAnaTip.Marka_Patent_Sozlemesi:
                    case SozlesmeAnaTip.Hakem_Sozlemesi:
                    case SozlesmeAnaTip.Genel_Sozleme:
                        stTakipEden = SozlesmeTarafTip.SozlesmeYapan;
                        stTakipEdilen = SozlesmeTarafTip.Muhatap;
                        break;

                    default:
                        break;
                }

                sozTarafList = new TList<AV001_TDI_BIL_SOZLESME_TARAF>();
                sozTarafList.AddingNew += sozTarafList_AddingNew;
                for (int i = 0; i < TumTaraflar.Count; i++)
                {
                    AV001_TDI_BIL_SOZLESME_TARAF sozTaraf = sozTarafList.AddNew();

                    sozTaraf.CARI_ID = TumTaraflar[i].CARI_ID.Value;
                    if (Alacakli.Contains(TumTaraflar[i]))
                        sozTaraf.TARAF_SIFAT_ID = (int)stTakipEden;

                    else if (Borclu.Contains(TumTaraflar[i]))
                        sozTaraf.TARAF_SIFAT_ID = (int)stTakipEdilen;
                }

                row.AV001_TDI_BIL_SOZLESME_TARAFCollection.Clear();
                row.AV001_TDI_BIL_SOZLESME_TARAFCollection.AddRange(sozTarafList);
            }
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            if (
                XtraMessageBox.Show(this, "Çýkmak istediðinizden emin misiniz?", "Çýkýþ", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();

            //Sil();
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            finish = true;

            if (rgFinish.SelectedIndex == 0)
            {
                _frmIcraTakip frm = new _frmIcraTakip();

                TList<AV001_TI_BIL_FOY> foys = new TList<AV001_TI_BIL_FOY>();
                foys.Add(MyFoy);
                frm.Show(foys);
                frm.Focus();
            }
            else if (rgFinish.SelectedIndex == 1)
            {
                Editor.Forms.frmEditoreGonder frmEGonder = new AdimAdimDavaKaydi.Editor.Forms.frmEditoreGonder();
                frmEGonder.MyFoy = myFoy;
                frmEGonder.StartPosition = FormStartPosition.CenterScreen;
                frmEGonder.Show();
            }
            else if (rgFinish.SelectedIndex == 2)
            {
                FoyuYazdýr();
            }
        }

        #region CheckStateChanged_EventArgs

        #endregion

        #region Properties

        #endregion

        #region ChangedEventArgs

        #endregion

        #region ChangingEventArgs

        private void wizardControl1_SelectedPageChanging(object sender, WizardPageChangingEventArgs e)
        {
            if (e.Page == wpAdim1 && e.Direction == Direction.Forward)
            {
                if ((lueFormTipi.Properties.DataSource == null) && (lueTakipKonusu.Properties.DataSource == null))
                {
                    BelgeUtil.Inits.FormTipiGetir(lueFormTipi.Properties);

                    BelgeUtil.Inits.TakipKonusuGetir(lueTakipKonusu.Properties);
                }

                ucAdimTree1.NodeExpend("Form Tipi ve Konusu");
            }

            if (e.Page == wpAdim1 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim1);
            }

            if (e.Page == wpAdim2 && e.Direction == Direction.Forward)
            {
                if (lueDosyaDurum.Properties.DataSource == null)
                {
                    BelgeUtil.Inits.FoyDurumGetir(lueDosyaDurum.Properties);
                }

                LoadTree(pnAdim2);

                ucAdimTree1.NodeExpend("Dosya Bilgileri");

                if (MyFoy.FOY_NO_Kod != "" && MyFoy.FOY_NO_Sayi.ToString() != "")
                    ucAdimTree1.NodeChecked("Dosya No");
                if (MyFoy.TAKIP_TARIHI.HasValue)
                    ucAdimTree1.NodeChecked("Takip Tarihi");
                if (MyFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI.HasValue)
                    ucAdimTree1.NodeChecked("Avukata Ýntikal Tarihi");
                if (MyFoy.FOY_DURUM_ID.HasValue)
                    ucAdimTree1.NodeChecked("Dosya Durumu");

                wpAdim2.AllowNext = MyFoy.FOY_NO != string.Empty && MyFoy.TAKIP_TARIHI.HasValue &&
                                    MyFoy.TAKIBIN_AVUKATA_INTIKAL_TARIHI.HasValue && MyFoy.FOY_DURUM_ID.HasValue &&
                                    ucAdimTree1.NodeChecked("Dosya Bilgileri");
                ilkFormTipId = (int)lueFormTipi.EditValue;
            }
            if (e.Page == wpAdim2 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim2);
            }

            if (e.Page == wpAdim3 && e.Direction == Direction.Forward)
            {
                if (lueAdliBirimAdliye.Properties.DataSource == null)
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliBirimAdliye);

                if (lueTakipYolu.Properties.DataSource == null)
                    BelgeUtil.Inits.TakipYoluGetir(lueTakipYolu.Properties);

                if (lueMudurlukNo.Properties.DataSource == null)
                    BelgeUtil.Inits.AdliBirimNoGetir(lueMudurlukNo);

                LoadTree(pnAdim3);
                ucAdimTree1.NodeExpend("Müdürlük Bilgileri");
                if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                    ucAdimTree1.NodeChecked("Müdürlük");
                if (MyFoy.ESAS_NO != "")
                    ucAdimTree1.NodeChecked("Esas No");
                if (MyFoy.TAKIP_YOLU_ID.HasValue)
                    ucAdimTree1.NodeChecked("Takip Yolu");

                if (wpAdim3.AllowNext)
                    FoyNoKaydet();
            }
            if (e.Page == wpAdim3 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim3);
            }

            if (e.Page == wpAdim4 && e.Direction == Direction.Forward)
            {
                if (lueOzelKod1.Properties.DataSource == null && lueOzelKod2.Properties.DataSource == null &&
                    lueOzelKod3.Properties.DataSource == null && lueOzelKod4.Properties.DataSource == null)
                {
                    BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, Modul.Icra);
                    BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, Modul.Icra);
                    BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, Modul.Icra);
                    BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, Modul.Icra);
                }

                LoadTree(pnAdim4);
            }

            if (e.Page == wpAdim4 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim4);
            }

            if (e.Page == wpAdim5 && e.Direction == Direction.Forward)
            {
                if (lueSorumluAvukat.Properties.DataSource == null && rLueSorumluAvk.DataSource == null)
                {
                    //SorumluAvukatGetir(new RepositoryItemLookUpEdit[]
                    //{
                    //    lueSorumluAvukat.Properties,
                    //    rLueSorumluAvk

                    //});
                    BelgeUtil.Inits.AktifAvukatlariGetir(lueSorumluAvukat.Properties);
                    BelgeUtil.Inits.AktifAvukatlariGetir(rLueSorumluAvk);

                    rLueSorumluAvk.NullText = "Sorumlu Avukat Seç";
                }

                gcSorumluAvukat.DataSource = MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection;

                LoadTree(pnAdim5);
            }

            if (e.Page == wpAdim5 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim5);
            }

            if (e.Page == wpAdim6 && e.Direction == Direction.Forward)
            {
                lueAlacakliSifat.EditValue =
                    ((TList<TDIE_KOD_TARAF_SIFAT>)lueAlacakliSifat.Properties.DataSource)[0];

                if (rLueAlacakliTK.DataSource == null)
                {
                    BelgeUtil.Inits.TarafKoduGetir(rLueAlacakliTK);
                }

                gcAlacakli.DataSource = Alacakli;
                wpAdim6.AllowNext = Alacakli.Count > 0;
                LoadTree(pnAdim6);
            }

            if (e.Page == wpAdim6 && e.Direction == Direction.Backward)
            {
                gcAlacakli.DataSource = Alacakli;
                wpAdim6.AllowNext = Alacakli.Count > 0;

                LoadTree(pnAdim6);
            }

            if (e.Page == wpAdim7 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim7);

                ItemsSelected(lstAlacaklilar);

                if (lueAlacakliVekil.Properties.DataSource == null && lueTemsilTuru.Properties.DataSource == null)
                {
                    BelgeUtil.Inits.perCariAvukatGetir(lueAlacakliVekil.Properties);
                    BelgeUtil.Inits.perCariAvukatGetir(rlueAlacakliVekilCari);
                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.TemsilTuruGetir(lueTemsilTuru);
                    BelgeUtil.Inits.TemsilTuruGetir(rLueAlacakliVekilTemsilSekli);

                    lueAlacakliVekil.Properties.ValueMember = string.Empty;
                    lueTemsilTuru.Properties.ValueMember = string.Empty;
                    lueTemsilTuru.EditValue = ((VList<per_TDI_KOD_TEMSIL_TUR>)lueTemsilTuru.Properties.DataSource)[0];
                }
            }

            if (e.Page == wpAdim7 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim7);
            }

            if (e.Page == wpAdim8 && e.Direction == Direction.Forward)
            {
                if (K_1.Enabled)
                {
                    M_2.Enabled = true;
                    D_2.Enabled = true;
                    K_2.Enabled = false;

                    M_2.Checked = true;
                }
                else if (!K_1.Enabled)
                {
                    M_2.Enabled = false;
                    D_2.Enabled = false;
                    K_2.Enabled = true;

                    K_2.CheckState = CheckState.Checked;
                }

                lueBorcluSifat.EditValue = ((TList<TDIE_KOD_TARAF_SIFAT>)lueBorcluSifat.Properties.DataSource)[0];

                gcBorclu.DataSource = Borclu;
                wpAdim8.AllowNext = Borclu.Count > 0;

                LoadTree(pnAdim8);
            }

            if (e.Page == wpAdim8 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim8);
            }

            if (e.Page == wpAdim9 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim9);

                ItemsSelected(lstBorclular);

                if (lueBorcluVekil.Properties.DataSource == null && lueTemsilTuru2.Properties.DataSource == null)
                {
                    BelgeUtil.Inits.perCariAvukatGetir(lueBorcluVekil.Properties);
                    BelgeUtil.Inits.perCariAvukatGetir(rlueBorcluVekilCari);
                    BelgeUtil.Inits.TemsilTuruGetir(lueTemsilTuru);
                    BelgeUtil.Inits.TemsilTuruGetir(rLueAlacakliVekilTemsilSekli);

                    lueBorcluVekil.Properties.ValueMember = string.Empty;
                    lueTemsilTuru2.Properties.ValueMember = string.Empty;

                    if (lueTemsilTuru2.Properties.DataSource != null)
                        lueTemsilTuru2.EditValue = ((VList<per_TDI_KOD_TEMSIL_TUR>)lueTemsilTuru2.Properties.DataSource)[0];
                }
            }
            if (e.Page == wpAdim9 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim9);
            }

            if (e.Page == wpAdim10 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim10);

                ucHesapOncesiKalem.MyDataSource = MyFoy;
            }
            if (e.Page == wpAdim10 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim10);
            }

            if (e.Page == wpAdim11 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim11);
                try
                {
                    if (MyFoy.TAKIP_TALEP_ID == 5 || MyFoy.TAKIP_TALEP_ID == 6 || MyFoy.TAKIP_TALEP_ID == 18
                        || MyFoy.TAKIP_TALEP_ID == 7 || MyFoy.TAKIP_TALEP_ID == 8)

                        CreateForm(MyFoy.TAKIP_TALEP_ID);
                    else
                        CreateForm(0);
                }

                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
                wpAdim11.AllowNext = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0;
            }
            if (e.Page == wpAdim11 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim11);
                wpAdim11.AllowNext = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0;
            }

            if (e.Page == wpAdim12 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim12);
                BelgeUtil.Inits.AlacakNedeniDoldur(new[] { rLueAlacakNedenKodID }, MyFoy.TAKIP_TALEP_ID.Value);

                if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                {
                    gcAlacakNedenleri.DataSource = null;
                    tabControlSozlesme.Visible = false;
                    gcAlacakNedenleri.Dock = DockStyle.Fill;
                }
                else
                {
                    gcAlacakNedenleri.DataSource = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection;
                    tabControlSozlesme.Visible = true;
                    gcAlacakNedenleri.Dock = DockStyle.Left;
                }

                if (ucKiymetliEvrak.MyDataSource.Count > 0)
                    ucAdimTree1.NodeChecked("Kýymetli Evrak");
                else
                    ucAdimTree1.NodeUnChecked("Kýymetli Evrak");
            }
            if (e.Page == wpAdim12 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim12);
                ucIcraHesapCetveli1.MyFoyDataSource = this.MyFoy;
            }

            if (e.Page == wpAdim14 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim14);
                try
                {
                    ucFormOdemeBilgileri1.Foy = MyFoy;
                    ucFormOdemeBilgileri1.MyDataSource = MyFoy.AV001_TI_BIL_BORCLU_ODEMECollection;
                    ucFormOdemeBilgileri1.DataGetir();

                    ucFormOdemeBilgileri1.ListAlacakli = Alacakli;
                    ucFormOdemeBilgileri1.ListBorclu = Borclu;
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
            if (e.Page == wpAdim14 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim14);
            }
            if (e.Page == wpAdim15 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim15);
                ucIhtiyati_Haciz_Tedbir1.MyFoy = MyFoy;
            }
            if (e.Page == wpAdim15 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim15);
            }
            if (e.Page == wpAdim16 && e.Direction == Direction.Forward)
            {
                LoadTree(pnAdim16);
            }
            if (e.Page == wpAdim16 && e.Direction == Direction.Backward)
            {
                LoadTree(pnAdim16);
            }
            if (e.Page == wpAdim16 && e.Direction == Direction.Forward)
            {
                ucIcraHesapCetveli1.MyFoyDataSource = this.MyFoy;

                ucIcraHesapCetveli1.MyTarafSource = Borclu;
            }
            if (e.Page == wpAdim17)
            {
                ucIcraHesapCetveli1.MyFoyDataSource = this.MyFoy;
            }

            if (e.Page == wpFinish && e.Direction == Direction.Forward)
            {
                if (Kaydet(MyFoy))
                {
                    wpFinish.FinishText = "Kayýt Sihirbazý Ýcra Dosya Kayýt Ýþleminizi Tamamladý." +
                                          System.Environment.
                                              NewLine + "Kayýt ekranýný kapatmak için bitir butonuna týklayýnýz...";
                }
                else
                    wpFinish.FinishText = "Kayýt iþlemi yapýlamadý.Lütfen adýmlarýnýzý kontrol edip tekrar deneyiniz." +
                                          System.Environment.NewLine +
                                          "Bu hata genelde foy numarasýnýn tekrarlanmasýndan dolayý oluþmaktadýr.";
            }
        }

        #endregion

        #region AddingNewEventArgs

        #endregion

        #region Private Methods

        #endregion

        #region ButtonClick_EventArgs

        #endregion

        #region Overriden methods

        //public override void DosyaHsapla()
        //{
        //    base.DosyaHsapla();
        //    FoyuHesapla();
        //}

        //public override void DosyaYazdir()
        //{
        //    base.DosyaYazdir();
        //    FoyuYazdýr();
        //}

        //public override void MahsupBilgileri()
        //{
        //    base.MahsupBilgileri();
        //    FoyuMahsupBilgileri();
        //}

        //public override void HesaplanmisKalemler()
        //{
        //    base.HesaplanmisKalemler();
        //    FoyHesaplanmisKalemler();
        //}

        //public override void IlamBilgileri()
        //{
        //    base.IlamBilgileri();
        //    FoyIlamMahkemesi();
        //}

        //public override void IhtiyatiHaciz()
        //{
        //    base.IhtiyatiHaciz();
        //    FoyIhtiyatiHacizBilgileri();
        //}

        //public override void IhtiyatiTedbir()
        //{
        //    base.IhtiyatiTedbir();
        //    FoyIhtiyatiTedbirBilgileri();
        //}

        //public override void TakipOncesiOdeme()
        //{
        //    base.TakipOncesiOdeme();
        //    FoyTakipOncesiOdemeler();
        //}

        #endregion

        #region IslemMetotlarý

        #endregion
    }
}