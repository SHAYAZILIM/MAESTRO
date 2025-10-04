using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Belge.Util;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AdimAdimDavaKaydi.Belge.UserControls;
using System.IO;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Forms.LayForm
{
    public partial class frmLayTabligatKayit_exp : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Global Properties

        #endregion Global Properties

        #region Fields
        private List<string> _FileName = new List<string>();
        public List<string> FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        public bool Duzenlememi = false;
        public bool ihbarname;
        public bool muzekkre;

        private int _ModulID = 10;

        //Düzenleme işlemi için eklenmiştir.
        private AV001_TDI_BIL_TEBLIGAT _MyDataSource;

        private int _MyDavaFoyID;
        private int _MyHazirlikFoyID;
        private int _MyIcraFoyID;
        private int _MySozlesmeFoyID;
        private IEntity _OpenedRecord;
        private CariStatu csDavaEden;
        private CariStatu csDavaEdilen;

        //İş Kaydedilsin Checked ise O tebligata iş kaydı üretilmesi sağlanıyor.
        private bool isLookUpTaraflarFill;

        #endregion Fields

        #region Constructors

        public frmLayTabligatKayit_exp()
        {
            InitializeComponent();

            this.bndTebligat.AddingNew += bndTebligat_AddingNew;
            bndTebligat.CurrentChanged += bndTebligat_CurrentChanged;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EvrakKayitEventArgs> YenileKayit;

        #endregion Events

        #region Properties

        public int ModulID
        {
            get { return _ModulID; }
            set { _ModulID = value; }
        }

        public AV001_TDI_BIL_TEBLIGAT MyDataSource
        {
            get
            {
                return _MyDataSource;
            }
            set
            {
                _MyDataSource = value;
                if (value.ID != 0)
                {
                    value.STAMP = 1;
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Save(value);
                    txtKullanici.Text = value.KONTROL_KIM;
                    txtKayitTarihi.Text = value.KONTROL_NE_ZAMAN.ToShortDateString();
                }
                else
                {
                    txtKullanici.Text = AvukatProLib.Kimlik.KullaniciAdi;
                    txtKayitTarihi.Text = DateTime.Today.ToShortDateString();
                }
                bndTebligat.DataSource = value;
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                for (int x = 0; x < value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; x++)
                {
                    try
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.Clear();
                        cn.AddParams("@TEBLIGAT_ID", value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].TEBLIGAT_ID);
                        cn.AddParams("@MUHATAP_CARI_ID", value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].MUHATAP_CARI_ID);

                        value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].PTT_BARKOD_NO = cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();

                        value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].TEBLIGAT_ADRESI = cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();
                    }
                    catch { ;}
                }

                bindingSource1.DataSource = value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;

                bindingSource2.DataSource = value.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;
                BelgeDoldur();
                (bindingSource1.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>).AddingNew += AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                (bindingSource2.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>).AddingNew += AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                if (value != null)
                {
                    if (value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                        value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                    if (value.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Count == 0)
                        value.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
                }
                try
                {
                    var yapantxt = (bindingSource2.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>)[0];
                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.DeepLoad(yapantxt, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                    txtAd.Text = yapantxt.YAPAN_CARI_IDSource.AD;
                    txtAdres.Text = yapantxt.YAPAN_CARI_IDSource.ADRES_1;
                    lkpIl.EditValue = yapantxt.YAPAN_CARI_IDSource.IL_ID;
                    lkpIlce.EditValue = yapantxt.YAPAN_CARI_IDSource.ILCE_ID;
                    txtTcKimlik.Text = yapantxt.YAPAN_CARI_IDSource.VERGI_NO;
                    txtTel.Text = yapantxt.YAPAN_CARI_IDSource.TEL_1;
                }
                catch { }
                try
                {
                    var muhatxt = (bindingSource1.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>)[0];
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    cn.Clear();
                    var table = cn.GetDataTable("Select top 1 ID,ITIRAZ_SURE,EVRAK_DURUM,BEKLEME_SURE from AV001_TDI_BIL_TEBLIGAT_MUHATAP WHERE ID=" + muhatxt.ID);

                    if (table.Rows.Count > 0)
                    {
                        var row = table.Rows[0];
                        var bekleme = 0;
                        if (row[3] is int)
                            bekleme = (int)row[3];
                        var itiraz = 0;
                        if (row[1] is int)
                            itiraz = (int)row[1];

                        if (bekleme != 0)
                            txtBekleme.EditValue = bekleme;
                        else
                        {
                            txtBekleme.Text = null;
                        }
                        if (itiraz != 0)
                            txtItiraz.EditValue = itiraz;
                        else
                            txtItiraz.Text = null;

                        var durum = 0;
                        if (row[2] is int)
                            durum = (int)row[2];
                        lookUpEdit1.EditValue = durum;
                    }
                    else
                    {
                        txtBekleme.Text = null;
                        txtItiraz.Text = null;
                    }
                    if (txtEvrakT.Value == 0)
                    {
                        txtEvrakT.Text = null;

                    }
                }
                catch { }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get;
            set;
        }

        public int MyDavaFoyID
        {
            get { return _MyDavaFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get;
            set;
        }

        public int MyHazirlikFoyID
        {
            get { return _MyHazirlikFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get;
            set;
        }

        public int MyIcraFoyID
        {
            get { return _MyIcraFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                }
            }
        }

        public AV001_TDIE_BIL_PROJE MyProje
        {
            get;
            set;
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get;
            set;
        }

        public int MySozlesmeFoyID
        {
            get { return _MySozlesmeFoyID; }
            set
            {
                if (Duzenlememi && value != null)
                {
                }
            }
        }

        [Browsable(false)]
        public IEntity OpenedRecord
        {
            get { return _OpenedRecord; }
            set { _OpenedRecord = value; }
        }

        #endregion Properties

        #region Methods

        public static string TebligatReferansNoOlustur()
        {
            var refNo = DataRepository.Provider.ExecuteScalar(System.Data.CommandType.Text, "SELECT TOP(1)TEBLIGAT_REFERANS_NO FROM AV001_TDI_BIL_TEBLIGAT ORDER BY ID DESC");
            if (refNo != null)
            {
                if (refNo.ToString().Contains("~"))
                {
                    string[] dizi = refNo.ToString().Split('~');
                    refNo = dizi[1];
                    int refNoSayi = Convert.ToInt32(refNo);
                    return "E" + "-" + DateTime.Today.Year + "~" + (++refNoSayi).ToString();
                }
                else
                {
                    string strRefNo = "E-" + DateTime.Today.Year.ToString() + "~10000";
                    return strRefNo;
                }
            }
            else
            {
                string strRefNo = "E-" + DateTime.Today.Year.ToString() + "~10000";
                return strRefNo;
            }
        }

        public void DefaultAlanlarMuhatap(AV001_TDI_BIL_TEBLIGAT_MUHATAP trf)
        {
            trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            trf.KONTROL_NE_ZAMAN = DateTime.Today;
            trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            trf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
        }

        public void DefaultAlanlarYapan(AV001_TDI_BIL_TEBLIGAT_YAPAN trf)
        {
            trf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            trf.KONTROL_NE_ZAMAN = DateTime.Today;
            trf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            trf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            trf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            trf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
        }


        public void Show(AV001_TI_BIL_FOY foy)
        {
            MyIcraFoy = foy;



            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();


            this.Show();

            for (int x = 0; x < gridView1.RowCount; x++)
            {
                try
                {
                    ABSqlConnection cn = new ABSqlConnection();
                    cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                    cn.Clear();
                    cn.AddParams("@TEBLIGAT_ID", MyDataSource.ID);
                    cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                    gridView1.SetRowCellValue(x, "PTT_BARKOD_NO", cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString());
                    gridView1.SetRowCellValue(x, "TEBLIGAT_ADRESI", cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString());
                }
                catch { ;}
            }
            chYapilacakIs.Checked = false;

        }
        TList<AV001_TDI_BIL_IS_TARAF> isTaraflari;
        private void chYapilacakIs_CheckedChanged(object sender, EventArgs e)
        {
            if (chYapilacakIs.Checked)
            {
                if (!isLookUpTaraflarFill)
                {

                    #region<MB-20100322> İş Taraflarının Gelmesi

                    AV001_TDI_BIL_TEBLIGAT tebligat = ((AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current);

                    if (tebligat != null)
                    {
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <AV001_TDI_BIL_TEBLIGAT_MUHATAP>));
                        if (tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Count == 0)
                            DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       TList
                                                                                       <AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                        TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> tebligatMuhataplar =
                            tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
                        TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebligatYapanlar =
                            tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection;

                        isTaraflari = new TList<AV001_TDI_BIL_IS_TARAF>();

                        foreach (var item in tebligatMuhataplar)
                        {
                            AV001_TDI_BIL_CARI cari =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.MUHATAP_CARI_ID);

                            if (cari != null)
                            {
                                if (cari.MUVEKKIL_MI)
                                {
                                    AV001_TDI_BIL_IS_TARAF tarafMuvekkil = new AV001_TDI_BIL_IS_TARAF();
                                    tarafMuvekkil.IS_TARAF_ID = 3;
                                    tarafMuvekkil.CARI_ID = item.MUHATAP_CARI_ID;
                                    isTaraflari.Add(tarafMuvekkil);
                                }
                            }
                        }
                        foreach (var item in tebligatYapanlar)
                        {
                            AV001_TDI_BIL_CARI cari =
                                DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.YAPAN_CARI_ID);

                            if (cari != null)
                            {
                                if (cari.MUVEKKIL_MI)
                                {
                                    AV001_TDI_BIL_IS_TARAF tarafMuvekkil = new AV001_TDI_BIL_IS_TARAF();
                                    tarafMuvekkil.IS_TARAF_ID = 3;
                                    tarafMuvekkil.CARI_ID = item.YAPAN_CARI_ID;
                                    isTaraflari.Add(tarafMuvekkil);
                                }
                            }
                        }

                        if (AvukatProLib.Kimlik.Bilgi.CARI_ID.HasValue)
                        {
                            AV001_TDI_BIL_IS_TARAF taraf = new AV001_TDI_BIL_IS_TARAF();
                            taraf.IS_TARAF_ID = 2;
                            taraf.CARI_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;
                            isTaraflari.Add(taraf);
                        }

                    }

                    #endregion Methods

                    isLookUpTaraflarFill = true;
                }
            }
        }
        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyDavaFoy = foy;

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            chYapilacakIs.Checked = false;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foy)
        {
            MyHazirlik = foy;

            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            chYapilacakIs.Checked = false;
            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME foy)
        {
            MySozlesme = foy;
            if (bndTebligat.DataSource == null || bndTebligat.Count == 0)
                bndTebligat.AddNew();

            chYapilacakIs.Checked = false;
            this.Show();
        }

        public void Show(AV001_TDIE_BIL_PROJE proje)
        {
            this.MyProje = proje;
            chYapilacakIs.Checked = false;
            this.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muhatab = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
            muhatab.OKUNDU_MU = false;
            muhatab.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            muhatab.KONTROL_NE_ZAMAN = DateTime.Today;
            muhatab.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muhatab.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muhatab.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muhatab.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            muhatab.MUHATAP_CARI_ID = AvukatProLib.Kimlik.SirketBilgisi.TebligatVarsayilanCariId;
            muhatab.MUHATAP_TARAF_KOD = 1;
            e.NewObject = muhatab;
        }

        private void AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_YAPAN yapan = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            yapan.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            yapan.KONTROL_NE_ZAMAN = DateTime.Today;
            yapan.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            yapan.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            yapan.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            yapan.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            yapan.TARAF_KOD = "3";
            yapan.YAPAN_CARI_ID = -1;
            e.NewObject = yapan;
            try
            {
                var yapantxt = (bindingSource2.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>)[0];
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.DeepLoad(yapantxt, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                txtAd.Text = yapantxt.YAPAN_CARI_IDSource.AD;
                txtAdres.Text = yapantxt.YAPAN_CARI_IDSource.ADRES_1;
                lkpIl.EditValue = yapantxt.YAPAN_CARI_IDSource.IL_ID;
                lkpIlce.EditValue = yapantxt.YAPAN_CARI_IDSource.ILCE_ID;
                txtTcKimlik.Text = yapantxt.YAPAN_CARI_IDSource.VERGI_NO;
                txtTel.Text = yapantxt.YAPAN_CARI_IDSource.TEL_1;
            }
            catch { }
        }

        private void belgeKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            TList<NN_BELGE_TEBLIGAT> belgeList =
                DataRepository.NN_BELGE_TEBLIGATProvider.GetByTEBLIGAT_ID(
                    (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT).ID);

            TList<AV001_TDIE_BIL_BELGE> belgeler = new TList<AV001_TDIE_BIL_BELGE>();

            foreach (var item in belgeList)
            {
                AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(item.BELGE_ID);

                belgeler.Add(belge);
            }
        }

        private void BindOzelKod()
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, Modul.Tebligat);
        }

        private void bndTebligat_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyIcraFoy != null)
            {
                #region İcra

                var yeniTebligat = MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyIcraFoy.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyIcraFoy.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyIcraFoy.ADLI_BIRIM_NO_ID;
                yeniTebligat.ICRA_FOY_ID = MyIcraFoy.ID;

                //yeniTebligat.ICRA_FOY_NO = MyIcraFoy.FOY_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                IcraTaraflarindanAl(MyIcraFoy, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion İcra
            }
            else if (MyDavaFoy != null)
            {
                #region Dava

                var yeniTebligat = MyDavaFoy.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyDavaFoy.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyDavaFoy.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyDavaFoy.ADLI_BIRIM_NO_ID;
                yeniTebligat.DAVA_FOY_ID = MyDavaFoy.ID;

                //yeniTebligat.DAVA_FOY_NO = MyDavaFoy.FOY_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                DavaTaraflarindanAl(MyDavaFoy, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Dava
            }
            else if (MyHazirlik != null)
            {
                #region Hazırlık

                var yeniTebligat = MyHazirlik.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MyHazirlik.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MyHazirlik.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MyHazirlik.ADLI_BIRIM_NO_ID;
                yeniTebligat.HAZIRLIK_ID = MyHazirlik.ID;

                //yeniTebligat.HAZIRLIK_NO = MyHazirlik.HAZIRLIK_NO;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                HazırlıkTaraflarindanAl(MyHazirlik, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Hazırlık
            }
            else if (MySozlesme != null)
            {
                #region Sozlesme

                var yeniTebligat = MySozlesme.AV001_TDI_BIL_TEBLIGATCollection.AddNew();

                yeniTebligat.ADLI_BIRIM_ADLIYE_ID = MySozlesme.ADLI_BIRIM_ADLIYE_ID;
                yeniTebligat.ADLI_BIRIM_GOREV_ID = MySozlesme.ADLI_BIRIM_GOREV_ID;
                yeniTebligat.ADLI_BIRIM_NO_ID = MySozlesme.ADLI_BIRIM_NO_ID;
                yeniTebligat.SOZLESME_ID = MySozlesme.ID;

                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.TIP_ID = 4; // İhtar
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();

                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                SozlesmeTaraflarindanAl(MySozlesme, yeniTebligat);

                e.NewObject = yeniTebligat;

                #endregion Sozlesme
            }
            else
            {
                AV001_TDI_BIL_TEBLIGAT yeniTebligat = new AV001_TDI_BIL_TEBLIGAT();
                yeniTebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
                yeniTebligat.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                yeniTebligat.KONTROL_NE_ZAMAN = DateTime.Today;
                yeniTebligat.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                yeniTebligat.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                yeniTebligat.STAMP = 0;
                yeniTebligat.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                yeniTebligat.TEBLIGAT_REFERANS_NO = TebligatReferansNoOlustur();
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;
                yeniTebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;
                e.NewObject = yeniTebligat;
            }
            var yeniobject = e.NewObject as AV001_TDI_BIL_TEBLIGAT;
            if (yeniobject != null)
            {
                if (yeniobject.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count == 0)
                    yeniobject.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddNew();
                if (yeniobject.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Count == 0)
                    yeniobject.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddNew();
            }
        }

        private void bndTebligat_CurrentChanged(object sender, EventArgs e)
        {
            if (bndTebligat.Current is AV001_TDI_BIL_TEBLIGAT)
            {
                AV001_TDI_BIL_TEBLIGAT tep = (AV001_TDI_BIL_TEBLIGAT)bndTebligat.Current;
                tep.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.AddingNew += AV001_TDI_BIL_TEBLIGAT_YAPANCollection_AddingNew;

                tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.AddingNew +=
                    AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;

                for (int x = 0; x < tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count; x++)
                {
                    try
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                        cn.Clear();
                        cn.AddParams("@TEBLIGAT_ID", tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0].TEBLIGAT_ID);
                        cn.AddParams("@MUHATAP_CARI_ID", tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].MUHATAP_CARI_ID);

                        tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].PTT_BARKOD_NO = cn.ExecuteScalar("select isnull(PTT_BARKOD_NO,'') as PTT_BARKOD_NO from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();

                        tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[x].TEBLIGAT_ADRESI = cn.ExecuteScalar("select isnull(TEBLIGAT_ADRESI,'') as TEBLIGAT_ADRESI from dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP(nolock) WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID").ToString();
                    }
                    catch { ;}
                }
                bindingSource1.DataSource = tep.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
            }
        }

        private void Child_OnNew(AV001_TDIE_BIL_BELGE belge, object sender)
        {
        }

        private void DavaTaraflarindanAl(AV001_TD_BIL_FOY icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>), typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
            for (int i = 0; i < icram.AV001_TD_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(
                    icram.AV001_TD_BIL_FOY_TARAFCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TD_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = (short)icram.AV001_TD_BIL_FOY_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

        }

        private void exGridBelge_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var tebligat = (bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);

            if (tebligat != null)
            {
                AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak belgeKayit = new AdimAdimDavaKaydi.Belge.Forms.frmBelgeKayitUfak();

                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = tebligat;
                belgeKayit.MyDataSource = tebligat.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT;

                //belgeKayit.MdiParent = null;
                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeKayit.Child.OnNew += Child_OnNew;
                belgeKayit.FormClosed += belgeKayit_FormClosed;
                belgeKayit.Show();
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindOzelKod();
        }

        private void frmLayTabligatKayit_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            InitsData();

            if (bndTebligat.Count == 0)
            {
                MyDataSource = new AV001_TDI_BIL_TEBLIGAT();
                bndTebligat.AddingNew += bndTebligat_AddingNew;
            }
            else
            {
            }

            lciOzelKod4.Text = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;

        }

        void BelgeDoldur()
        {
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            var c = (lueBelge.Properties as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).DataSource as DataTable;
            var tebligat = bndTebligat[0] as AV001_TDI_BIL_TEBLIGAT;
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false, DeepLoadType.IncludeChildren, typeof(TList<NN_BELGE_TEBLIGAT>));
            foreach (var item in tebligat.NN_BELGE_TEBLIGATCollection)
            {
                foreach (DataRow item2 in c.Rows)
                {
                    var belgeid = (int)item2["Id"];
                    if (belgeid == item.BELGE_ID)
                    {
                        item2["IsSelected"] = true;
                        lueBelge.Properties.NullText = "Seçildi";
                    }
                }
            }
            AvukatPro.Services.Implementations.DevExpressService.EvrakDoldur(lueEvrak);
            var c2 = (lueEvrak.Properties as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit).DataSource as DataTable;
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(tebligat, false, DeepLoadType.IncludeChildren, typeof(TList<NN_TEBLIGAT_TEBLIGAT>));
            foreach (var item in tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID)
            {
                foreach (DataRow item2 in c2.Rows)
                {
                    var belgeid = (int)item2["Id"];
                    if (belgeid == item.ILISKILI_TEBLIGAT_ID)
                    {
                        item2["IsSelected"] = true;
                        lueEvrak.Properties.NullText = "Seçildi";
                    }
                }
            }
        }

        private void HazırlıkTaraflarindanAl(AV001_TD_BIL_HAZIRLIK icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>), typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));
            for (int i = 0; i < icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(
                    icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i], false,
                    AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TD_BIL_HAZIRLIK_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;

        }

        private void IcraTaraflarindanAl(AV001_TI_BIL_FOY icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>), typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            for (int i = 0; i < icram.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(
                    icram.AV001_TI_BIL_FOY_TARAFCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID.Value;

            //for (int y = 0; y < icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count; y++)
            //{
            //    AV001_TDI_BIL_TEBLIGAT_YAPAN tarafs = new AV001_TDI_BIL_TEBLIGAT_YAPAN();
            //    tarafs.IS_TARAF_ID = 2;
            //    tarafs.CARI_ID = icram.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[y].SORUMLU_AVUKAT_CARI_ID;
            //    isTaraflari.Add(tarafs);
            //}
        }

        private void InitsData()
        {
            BelgeUtil.Inits.TebligatKonuGetir(lueKonu);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueTarafKod);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueTarafKodMuh);
            AvukatPro.Services.Implementations.DevExpressService.IlDoldur(lkpIl);
            AvukatPro.Services.Implementations.DevExpressService.TebligatDurumDoldur(lookUpEdit1);
            BelgeUtil.Inits.TebligatKonuGetir(lueKonu);

            BindOzelKod();

            lueOzelKod4.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueOzelKod_ButtonClick);
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValTebligat.Validate()) return;

                for (int i = 0; i < bndTebligat.List.Count; i++)
                {
                    var tebligat = bndTebligat[i] as AV001_TDI_BIL_TEBLIGAT;

                    TDI_KOD_TEBLIGAT_KONU Tk =
                        AvukatProLib2.Data.DataRepository.TDI_KOD_TEBLIGAT_KONUProvider.GetByID(tebligat.KONU_ID);
                    if (Tk != null)
                    {
                        tebligat.ANA_TUR_ID = Tk.ANA_TUR_ID;
                        tebligat.ALT_TUR_ID = Tk.ALT_TUR_ID;
                        //TList<TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI> Hak =
                        //    AvukatProLib2.Data.DataRepository.TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORIProvider.
                        //        GetByANA_KATEGORI_ID(Tk.ANA_TUR_ID);
                        //foreach (TDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORI mhak in Hak)
                        //{
                        //    tebligat.MUHASEBE_ALT_KATEGORI_IDSource = mhak;
                        //    break;
                        //}
                    }
                    else
                    {
                        tebligat.ANA_TUR_ID = 1;
                        tebligat.ALT_TUR_ID = 1;
                    }

                    //tebligat.NN_BELGE_TEBLIGATCollection.Clear();
                    for (int rowHandle = 0; rowHandle < lueBelge.Properties.View.RowCount; rowHandle++)
                    {
                        if ((bool)lueBelge.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        {
                            var belgeid = (int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id");
                            if (!tebligat.NN_BELGE_TEBLIGATCollection.Any(q => q.BELGE_ID == belgeid))
                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT() { BELGE_ID = belgeid });
                        }
                        else
                        {
                            var belgeid = (int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id");
                            if (tebligat.NN_BELGE_TEBLIGATCollection.Any(q => q.BELGE_ID == belgeid))
                            {
                                var c = tebligat.NN_BELGE_TEBLIGATCollection.Where(q => q.BELGE_ID == belgeid).FirstOrDefault();
                                if (c != null)
                                    AvukatProLib2.Data.DataRepository.NN_BELGE_TEBLIGATProvider.Delete(c);
                            }
                        }
                    }

                    //tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Clear();
                    for (int rowHandle = 0; rowHandle < lueEvrak.Properties.View.RowCount; rowHandle++)
                    {
                        if ((bool)lueEvrak.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        {
                            var tebligatid = (int)lueEvrak.Properties.View.GetRowCellValue(rowHandle, "Id");
                            if (!tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Any(q => q.ILISKILI_TEBLIGAT_ID == tebligatid))
                                tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Add(new NN_TEBLIGAT_TEBLIGAT() { ILISKILI_TEBLIGAT_ID = tebligatid });
                        }
                        else
                        {
                            var tebligatid = (int)lueEvrak.Properties.View.GetRowCellValue(rowHandle, "Id");
                            if (tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Any(q => q.ILISKILI_TEBLIGAT_ID == tebligatid))
                            {
                                var c = tebligat.NN_TEBLIGAT_TEBLIGATCollectionGetByTEBLIGAT_ID.Where(q => q.ILISKILI_TEBLIGAT_ID == tebligatid).FirstOrDefault();
                                if (c != null)
                                    AvukatProLib2.Data.DataRepository.NN_TEBLIGAT_TEBLIGATProvider.Delete(c);
                            }
                        }
                    }

                    AvukatProLib2.Data.TransactionManager tm =
                        new AvukatProLib2.Data.TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                    try
                    {
                        tm.BeginTransaction();

                        if (tebligat.ICRA_FOY_ID.HasValue)
                            tebligat.NN_TEBLIGAT_ICRACollection.Add(new NN_TEBLIGAT_ICRA() { ICRA_FOY_ID = tebligat.ICRA_FOY_ID.Value });
                        if (tebligat.DAVA_FOY_ID.HasValue)
                            tebligat.NN_TEBLIGAT_DAVACollection.Add(new NN_TEBLIGAT_DAVA() { DAVA_FOY_ID = tebligat.DAVA_FOY_ID.Value });
                        if (tebligat.HAZIRLIK_ID.HasValue)
                            tebligat.NN_TEBLIGAT_HAZIRLIKCollection.Add(new NN_TEBLIGAT_HAZIRLIK() { HAZIRLIK_FOY_ID = tebligat.HAZIRLIK_ID.Value });
                        if (tebligat.SOZLESME_ID.HasValue)
                            tebligat.NN_TEBLIGAT_SOZLESMECollection.Add(new NN_TEBLIGAT_SOZLESME() { SOZLESME_ID = tebligat.SOZLESME_ID.Value });

                        if (tebligat.ID == 0)
                            tebligat.STAMP = 0;
                        else
                            tebligat.STAMP = 1;

                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Save(tm, tebligat);

                        foreach (var item in tebligat.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_TEBLIGAT)
                        {
                            if (!tebligat.NN_BELGE_TEBLIGATCollection.Exists(vi => vi.BELGE_ID == item.ID))
                            {
                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT
                                                                             {
                                                                                 TEBLIGAT_ID = tebligat.ID,
                                                                                 BELGE_ID = item.ID
                                                                             });
                            }
                        }
                        try
                        {
                            var yapantxt = (bindingSource2.DataSource as TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>)[0];
                            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGAT_YAPANProvider.DeepLoad(yapantxt, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                            if (yapantxt.YAPAN_CARI_IDSource != null)
                            {
                                yapantxt.YAPAN_CARI_IDSource.AD = txtAd.Text;
                                yapantxt.YAPAN_CARI_IDSource.ADRES_1 = txtAdres.Text;
                                yapantxt.YAPAN_CARI_IDSource.VERGI_NO = txtTcKimlik.Text;
                                yapantxt.YAPAN_CARI_IDSource.TEL_1 = txtTel.Text;

                                if (lkpIl.EditValue != null)
                                    yapantxt.YAPAN_CARI_IDSource.IL_ID = (int)lkpIl.EditValue;
                                if (lkpIlce.EditValue != null)
                                    yapantxt.YAPAN_CARI_IDSource.ILCE_ID = (int)lkpIlce.EditValue;
                                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Save(yapantxt.YAPAN_CARI_IDSource);
                            }
                            else
                            {
                                var cari = new AV001_TDI_BIL_CARI();
                                cari.AD = txtAd.Text;
                                cari.ADRES_1 = txtAdres.Text;
                                cari.VERGI_NO = txtTcKimlik.Text;
                                cari.TEL_1 = txtTel.Text;
                                if (lkpIl.EditValue != null)
                                    cari.IL_ID = (int)lkpIl.EditValue;
                                if (lkpIlce.EditValue != null)
                                    cari.ILCE_ID = (int)lkpIlce.EditValue;
                                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Save(cari);
                                yapantxt.YAPAN_CARI_IDSource = cari;
                                yapantxt.YAPAN_CARI_ID = cari.ID;
                            }
                        }
                        catch { }

                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tm, tebligat, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_TEBLIGAT>), typeof(TList<NN_TEBLIGAT_TEBLIGAT>)
                            , typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>), typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>));

                        if (MyProje != null && !Duzenlememi)
                        {
                            if (DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.GetByPROJE_IDTEBLIGAT_ID(MyProje.ID, tebligat.ID) == null)
                            {
                                AV001_TDIE_BIL_PROJE_IHTARNAME ihtar = new AV001_TDIE_BIL_PROJE_IHTARNAME();
                                ihtar.TEBLIGAT_ID = tebligat.ID;
                                ihtar.PROJE_ID = MyProje.ID;
                                DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.Save(tm, ihtar);
                            }
                        }

                        int belgei = 1;
                        foreach (var item in FileName)
                        {
                            try
                            {
                                AV001_TDIE_BIL_BELGE blg = new AV001_TDIE_BIL_BELGE();
                                blg.BELGE_REFERANS_NO = DateTime.Now.Ticks.ToString();
                                blg.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
                                blg.BELGE_TUR_ID = 7;
                                blg.SUC_OLAY_VADE_TARIHI = DateTime.Now;
                                blg.YAZILMA_TARIHI = DateTime.Now;
                                blg.BELGE_NO = ucBelgeKayitUfak.BelgeNoGetir();
                                blg.STAMP = 0;
                                blg.DOSYA_ADI = item;
                                blg.DOKUMAN_UZANTI = Path.GetExtension(item).Replace(".", "");
                                blg.YIL = DateTime.Now.Year.ToString();

                                blg.ESAS_NO = "";

                                if (AvukatProLib.Kimlik.Bilgi.CARI_IDSource != null)
                                {
                                    blg.BELGE_ADI = string.Format("{0}-{1}-{2}", AvukatProLib.Kimlik.Bilgi.CARI_IDSource.VERGI_NO, AvukatProLib.Kimlik.Bilgi.CARI_IDSource.AD, blg.DOSYA_ADI);
                                }
                                if (System.IO.File.Exists(item) && blg != null)
                                {
                                    System.IO.FileStream fss = new System.IO.FileStream(item, System.IO.FileMode.Open);
                                    byte[] veri = new byte[fss.Length];
                                    fss.Read(veri, 0, veri.Length);
                                    blg.ICERIK = veri;
                                    fss.Close();
                                }

                                foreach (var muhattap in tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                                {
                                    var trf = blg.AV001_TDIE_BIL_BELGE_TARAFCollection.AddNew();
                                    trf.CARI_ID = muhattap.MUHATAP_CARI_ID;
                                    trf.SIFAT_ID = 65;
                                    trf.KODU = 1;
                                }


                                foreach (var yapan in tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection)
                                {
                                    var trf = blg.AV001_TDIE_BIL_BELGE_TARAFCollection.AddNew();
                                    trf.CARI_ID = yapan.YAPAN_CARI_ID;
                                    trf.SIFAT_ID = 38;
                                    trf.KODU = 3;
                                }
                                var blgyapan = tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0];
                                if (blgyapan != null)
                                {
                                    blg.BELGE_ADI = (blgyapan.YAPAN_CARI_IDSource != null ? blgyapan.YAPAN_CARI_IDSource.VERGI_NO + " - " + blgyapan.YAPAN_CARI_IDSource.AD : Path.GetFileNameWithoutExtension(item)) + "_" + belgei.ToString();
                                }

                                blg.OZEL_KOD_1_ID = tebligat.TEBLIGAT_OZEL_KOD_ID;
                                blg.OZEL_KOD_2_ID = tebligat.TEBLIGAT_OZEL_KOD2_ID;
                                blg.OZEL_KOD_3_ID = tebligat.TEBLIGAT_OZEL_KOD3_ID;
                                blg.OZEL_KOD_4_ID = tebligat.TEBLIGAT_OZEL_KOD4_ID;

                                if (tebligat.ICRA_FOY_ID.HasValue)
                                    blg.NN_BELGE_ICRACollection.Add(new NN_BELGE_ICRA() { ICRA_FOY_ID = tebligat.ICRA_FOY_ID.Value });
                                if (tebligat.DAVA_FOY_ID.HasValue)
                                    blg.NN_BELGE_DAVACollection.Add(new NN_BELGE_DAVA() { DAVA_FOY_ID = tebligat.DAVA_FOY_ID.Value });
                                if (tebligat.HAZIRLIK_ID.HasValue)
                                    blg.NN_BELGE_HAZIRLIKCollection.Add(new NN_BELGE_HAZIRLIK() { HAZIRLIK_ID = tebligat.HAZIRLIK_ID.Value });
                                if (tebligat.SOZLESME_ID.HasValue)
                                    blg.NN_BELGE_SOZLESMECollection.Add(new NN_BELGE_SOZLESME() { SOZLESME_ID = tebligat.SOZLESME_ID.Value });

                                blg.ESAS_NO = tebligat.TEBLIGAT_ESAS_NO;

                                if (tebligat.ADLI_BIRIM_ADLIYE_ID.HasValue)
                                    blg.ADLI_BIRIM_ADLIYE_ID = tebligat.ADLI_BIRIM_ADLIYE_ID;

                                if (tebligat.ADLI_BIRIM_NO_ID.HasValue)
                                    blg.ADLI_BIRIM_NO_ID = tebligat.ADLI_BIRIM_NO_ID;

                                if (tebligat.ADLI_BIRIM_GOREV_ID.HasValue)
                                    blg.ADLI_BIRIM_GOREV_ID = tebligat.ADLI_BIRIM_GOREV_ID;
                                if (string.IsNullOrEmpty(blg.ESAS_NO))
                                    blg.ESAS_NO = "";

                                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(blg, AvukatProLib2.Data.DeepSaveType.IncludeChildren,
                                    typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>),
                                    typeof(TList<NN_BELGE_ICRA>),
                                    typeof(TList<NN_BELGE_DAVA>),
                                    typeof(TList<NN_BELGE_HAZIRLIK>),
                                    typeof(TList<NN_BELGE_SOZLESME>)
                                    );

                                tebligat.NN_BELGE_TEBLIGATCollection.Add(new NN_BELGE_TEBLIGAT() { BELGE_ID = blg.ID });
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Tebligat Belge Kayıt", ex);
                            }
                            belgei++;
                        }
                        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(tm, tebligat, DeepSaveType.IncludeChildren, typeof(TList<NN_BELGE_TEBLIGAT>));
                        tm.Commit();
                        try
                        {
                            var muhatxt = tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0];
                            ABSqlConnection cn = new ABSqlConnection();
                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                            cn.Clear();
                            cn.AddParams("@BEKLEME_SURE", txtBekleme.EditValue);
                            cn.AddParams("@ITIRAZ_SURE", txtItiraz.EditValue);
                            cn.AddParams("@EVRAK_DURUM", lookUpEdit1.EditValue ?? 0);
                            cn.ExcuteQuery("update AV001_TDI_BIL_TEBLIGAT_MUHATAP set ITIRAZ_SURE=@ITIRAZ_SURE,EVRAK_DURUM=@EVRAK_DURUM,BEKLEME_SURE=@BEKLEME_SURE  WHERE ID=" + muhatxt.ID);
                        }
                        catch { }
                        for (int x = 0; x < gridView1.RowCount; x++)
                        {
                            try
                            {
                                if (gridView1.GetRowCellValue(x, "PTT_BARKOD_NO") != null)
                                {
                                    if (gridView1.GetRowCellValue(x, "PTT_BARKOD_NO") != DBNull.Value)
                                    {
                                        if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(x, "PTT_BARKOD_NO").ToString()))
                                        {
                                            ABSqlConnection cn = new ABSqlConnection();
                                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                                            cn.Clear();
                                            cn.AddParams("@PTT_BARKOD_NO", gridView1.GetRowCellValue(x, "PTT_BARKOD_NO"));
                                            cn.AddParams("@TEBLIGAT_ID", tebligat.ID);
                                            cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                                            cn.ExcuteQuery("UPDATE dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP SET PTT_BARKOD_NO=@PTT_BARKOD_NO WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID");
                                        }
                                    }
                                }
                                if (gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI") != null)
                                {
                                    if (gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI") != DBNull.Value)
                                    {
                                        if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI").ToString()))
                                        {
                                            ABSqlConnection cn = new ABSqlConnection();
                                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                                            cn.Clear();
                                            cn.AddParams("@TEBLIGAT_ADRESI", gridView1.GetRowCellValue(x, "TEBLIGAT_ADRESI"));
                                            cn.AddParams("@TEBLIGAT_ID", tebligat.ID);
                                            cn.AddParams("@MUHATAP_CARI_ID", gridView1.GetRowCellValue(x, "MUHATAP_CARI_ID"));
                                            cn.ExcuteQuery("UPDATE dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP SET TEBLIGAT_ADRESI=@TEBLIGAT_ADRESI WHERE TEBLIGAT_ID=@TEBLIGAT_ID and MUHATAP_CARI_ID=@MUHATAP_CARI_ID");
                                        }
                                    }
                                }
                            }
                            catch { ;}
                        }

                        if (chYapilacakIs.Checked)
                            IsKaydet();

                        XtraMessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleşmiştir");
                        if (YenileKayit != null)
                            YenileKayit(this, new EvrakKayitEventArgs(tebligat));
                    }
                    catch (Exception ex)
                    {
                        if (tm.IsOpen)
                            tm.Rollback();

                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public void IsKaydet()
        {
            if (bndTebligat.Current == null)
                return;
            AV001_TDI_BIL_TEBLIGAT tebligat = bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT;

            AV001_TDI_BIL_IS ds = new AV001_TDI_BIL_IS();
            TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();
            ds.ACIKLAMA = tebligat.ACIKLAMA;
            ds.ADLI_BIRIM_ADLIYE_ID = tebligat.ADLI_BIRIM_ADLIYE_ID;
            ds.ADLI_BIRIM_GOREV_ID = tebligat.ADLI_BIRIM_GOREV_ID;
            ds.ADLI_BIRIM_NO_ID = tebligat.ADLI_BIRIM_NO_ID;
            ds.AJANDADA_GORUNSUN_MU = true;
            ds.BASLANGIC_TARIHI = tebligat.KAYIT_TARIHI;
            ds.ESAS_NO = tebligat.TEBLIGAT_ESAS_NO;
            ds.YER = "OFİS";
            string konu = "";
            if (tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Count > 0)
            {
                if (tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_IDSource != null)
                    konu = string.Format("{0} isimli kişinin Tebligatı", tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_IDSource.AD);
            }

            ds.KONU = konu;
            ds.ONGORULEN_BITIS_TARIHI = tebligat.KAYIT_TARIHI.AddDays(1);
            //ds.REFERANS_NO = tebligat.TEBLIGAT_REFERANS_NO;
            ds.REFERANS_NO = "Y-" + DateTime.Now.Year + "~" + DateTime.Now.Ticks;
            ds.DURUM = false;
            ds.BITIS_TARIHI = null;
            ds.ONCELIK_ID = 2; //Acil
            ds.KATEGORI_ID = 612;//TEBLİGAT İŞLERİ
            ds.STAMP = 0;
            //if (isTaraflari != null)
            //    ds.AV001_TDI_BIL_IS_TARAFCollection = isTaraflari;
            
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);
            var taraf = ds.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
            taraf.CARI_ID = Kimlikci.Kimlik.Cari_ID;
            taraf.IS_TARAF_ID = 1;

            var taraf2 = ds.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
            taraf2.CARI_ID = Kimlikci.Kimlik.SirketBilgisi.TebligatIsCariId;
            taraf2.IS_TARAF_ID = 2;

            var taraf3 = ds.AV001_TDI_BIL_IS_TARAFCollection.AddNew();
            taraf3.CARI_ID = Kimlikci.Kimlik.SirketBilgisi.TebligatIsCariId2;
            taraf3.IS_TARAF_ID = 2;

            foreach (var item in tebligat.NN_BELGE_TEBLIGATCollection)
            {
                var belge = ds.NN_IS_BELGECollection.AddNew();
                belge.BELGE_ID = item.BELGE_ID;
            }

            if (isler != null && isler.Count > 0)
            {
                ds.TEKRARLAMA_BILGISI = isler[0].TEKRARLAMA_BILGISI;
                ds.HATIRLATMA_BILGISI = isler[0].HATIRLATMA_BILGISI;
            }

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.Save(ds);

            if (OpenedRecord != null)
            {
                switch (OpenedRecord.TableName)
                {
                    case "AV001_TI_BIL_FOY":
                        NN_IS_ICRA_FOY isIcra = new NN_IS_ICRA_FOY();
                        isIcra.ICRA_FOY_ID = (OpenedRecord as AV001_TI_BIL_FOY).ID;
                        isIcra.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_ICRA_FOYProvider.Save(isIcra);
                        break;

                    case "AV001_TD_BIL_FOY":
                        NN_IS_DAVA_FOY isDava = new NN_IS_DAVA_FOY();
                        isDava.DAVA_FOY_ID = (OpenedRecord as AV001_TD_BIL_FOY).ID;
                        isDava.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_DAVA_FOYProvider.Save(isDava);
                        break;
                    case "AV001_TD_BIL_HAZIRLIK":
                        NN_IS_HAZIRLIK isHazirlik = new NN_IS_HAZIRLIK();
                        isHazirlik.HAZIRLIK_ID = (OpenedRecord as AV001_TD_BIL_HAZIRLIK).ID;
                        isHazirlik.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_HAZIRLIKProvider.Save(isHazirlik);
                        break;

                    case "AV001_TDI_BIL_SOZLESME":
                        NN_IS_SOZLESME isSozlesme = new NN_IS_SOZLESME();
                        isSozlesme.SOZLESME_ID = (OpenedRecord as AV001_TDI_BIL_SOZLESME).ID;
                        isSozlesme.IS_ID = ds.ID;

                        AvukatProLib2.Data.DataRepository.NN_IS_SOZLESMEProvider.Save(isSozlesme);
                        break;

                    default:
                        break;
                }
            }

            //IEntity MyRecord;
            NNProcess.SaveIs(ds, (IEntity)bndTebligat.Current);

            foreach (var item in ds.AV001_TDI_BIL_IS_TARAFCollection)
            {
                item.IS_ID = ds.ID;
            }
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_TARAFProvider.Save(ds.AV001_TDI_BIL_IS_TARAFCollection);

            if (ds.AV001_TDI_BIL_IS_TARAFCollection != null && ds.AV001_TDI_BIL_IS_TARAFCollection.Count >= 0)
            {
                for (int i = 0; i < ds.AV001_TDI_BIL_IS_TARAFCollection.Count; i++)
                {
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(ds, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<NN_IS_CARI>));
                    NN_IS_CARI isCari = new NN_IS_CARI();
                    isCari.IS_ID = ds.ID;
                    if (ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID > 0)
                    {
                        isCari.CARI_ID = ds.AV001_TDI_BIL_IS_TARAFCollection[i].CARI_ID.Value;

                        if (
                            ds.NN_IS_CARICollection.Exists(
                                delegate(NN_IS_CARI tarf)
                                {
                                    return tarf.CARI_ID == isCari.CARI_ID; // && tarf.IS_ID==isCari.IS_ID;
                                })) continue;
                        AvukatProLib2.Data.DataRepository.NN_IS_CARIProvider.DeepSave(isCari);
                    }
                }
            }
            DataRepository.AV001_TDI_BIL_ISProvider.DeepSave(ds, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_HATIRLAT>), typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>), typeof(TList<NN_IS_BELGE>));

            #region Ekran Hatırlatması

            {
                AV001_TDI_BIL_HATIRLAT ekranHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                ekranHatirlatma.IS_ID = ds.ID;
                ekranHatirlatma.HATIRLATSIN_MI = true;
                ekranHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                ekranHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                ekranHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                ekranHatirlatma.ACIKLAMA = ds.TEKRARLAMA_BILGISI ?? string.Empty;
                ekranHatirlatma.HATIRLATMA_TIPI = "0";
                ekranHatirlatma.BASLANGIC_ID = 1;
                ekranHatirlatma.PERIYOD_ID = 1;
                ekranHatirlatma.TEKRAR = 1;
                ekranHatirlatma.GUNLUK_UYARI_SAAT = ds.BASLANGIC_TARIHI.Value.ToShortTimeString();

                foreach (var taraf1 in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf1.IS_TARAF_ID == null || ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf1.ID))
                    {
                        ekranHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf1.ID });

                    }
                }

                ekranHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(ekranHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Ekran Hatırlatması

            #region Mail Hatırlatması

            {
                AV001_TDI_BIL_HATIRLAT mailHatirlatma = new AV001_TDI_BIL_HATIRLAT();
                mailHatirlatma.IS_ID = ds.ID;
                mailHatirlatma.HATIRLATSIN_MI = true;
                mailHatirlatma.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;
                mailHatirlatma.BASLAMA_TARIHI = ds.BASLANGIC_TARIHI.Value;
                mailHatirlatma.BITIS_TARIHI = ds.ONGORULEN_BITIS_TARIHI.Value;
                mailHatirlatma.ACIKLAMA = "mail hatırlatma";
                mailHatirlatma.HATIRLATMA_TIPI = "1";
                mailHatirlatma.BASLANGIC_ID = 1;
                mailHatirlatma.PERIYOD_ID = 1;

                mailHatirlatma.TEKRAR = 1;
                //mailHatirlatma.GUNLUK_UYARI_SAAT = (ds.BASLANGIC_TARIHI.Value - (TimeSpan)ucHatirlatmaPeriyot1.durationEdit1.EditValue).ToShortTimeString();

                mailHatirlatma.BIR_DEFA_PATLAMASI_OLDU_MU = true;

                foreach (var taraf1 in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf1.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf1.ID))
                        break;
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf1.ID });

                }
                mailHatirlatma.TEKRAR = 1;

                foreach (var taraf1 in ds.AV001_TDI_BIL_IS_TARAFCollection)
                {
                    if (taraf1.IS_TARAF_ID == null || mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Exists(t => t.IS_TARAF_ID == taraf1.ID))
                        break;
                    mailHatirlatma.NN_HATIRLAT_IS_TARAFCollection.Add(new NN_HATIRLAT_IS_TARAF() { IS_TARAF_ID = taraf1.ID });

                }

                mailHatirlatma.NN_IS_HATIRLATMACollection.Add(new NN_IS_HATIRLATMA() { IS_ID = ds.ID });
                ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA.Add(mailHatirlatma);
                DataRepository.AV001_TDI_BIL_HATIRLATProvider.DeepSave(ds.AV001_TDI_BIL_HATIRLATCollection_From_NN_IS_HATIRLATMA, DeepSaveType.IncludeChildren, typeof(TList<NN_HATIRLAT_IS_TARAF>), typeof(TList<NN_IS_HATIRLATMA>));
            }

            #endregion Mail Hatırlatması


        }
        private void lueBelge_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmBelgeKayitUfak frmblg = new frmBelgeKayitUfak();
                frmblg.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);
            }
        }

        private void lueBelge_Enter(object sender, System.EventArgs e)
        {
        }

        private void lueKonu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "Yeni")
            {
                AdimAdimDavaKaydi.Forms.frmTebligatKonu frm = new frmTebligatKonu();
                frm.Show(lueKonu.Text);
            }
        }

        private void lueOzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
        }

        private void rLueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SearchLookUpEdit sLue = new SearchLookUpEdit();
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "mEkleCariD")
            {
                frm.tmpCariAd = lue.Text;

                if (csDavaEden != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEden);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
                                          }
                                      };
            }
        }

        private void rLueCari_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();

            frm.tmpCariAd = lue.Text;

            if (csDavaEden != null)
            {
                if (csDavaEden != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEden);
            }

            // frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      DialogResult dr = frm.KayitBasarili;
                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                      {
                                          //Inits.perCariGetirRefresh();
                                          AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCari);
                                      }
                                  };
        }

        private void rLueCariMuhatab_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();
            if ((e.Button.Tag as string) == "mEkleCariD")
            {
                frm.tmpCariAd = lue.Text;

                if (csDavaEdilen != CariStatu.Personel)
                    frm.Statuler.Add(csDavaEdilen);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                                      {
                                          DialogResult dr = frm.KayitBasarili;
                                          if (dr == System.Windows.Forms.DialogResult.OK)
                                          {
                                              //Inits.perCariGetirRefresh();
                                              AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
                                          }
                                      };
            }
        }

        private void rLueCariMuhatab_ProcessNewValue(object sender,
            DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            frmCariGenelGiris frm = new frmCariGenelGiris();

            frm.tmpCariAd = lue.Text;

            if (csDavaEdilen != CariStatu.Personel)
                frm.Statuler.Add(csDavaEdilen);

            frm.MdiParent = null;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      DialogResult dr = frm.KayitBasarili;
                                      if (dr == System.Windows.Forms.DialogResult.OK)
                                      {
                                          //Inits.perCariGetirRefresh();
                                          AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariMuh);
                                      }
                                  };
        }

        private void rLueTarafKod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            csDavaEden = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void rLueTarafKodMuh_EditValueChanging(object sender,
            DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            csDavaEdilen = (AvukatProLib.Extras.CariStatu)e.NewValue;
        }

        private void sbtnIliskiliEvrakEkle_Click(object sender, EventArgs e)
        {
            var selectedTebligat = bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT;
            Forms.frmTebligatIliskiEkle frm = new frmTebligatIliskiEkle();
            frm.Show(selectedTebligat);
        }

        private void SozlesmeTaraflarindanAl(AV001_TDI_BIL_SOZLESME icram, AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            TList<AV001_TDI_BIL_TEBLIGAT_YAPAN> tebTaraflari = new TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(icram, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>), typeof(TList<AV001_TDI_BIL_SOZLESME_SORUMLU>));

            for (int i = 0; i < icram.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESME_TARAFProvider.DeepLoad(
                    icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i], false,
                    AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                if (icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU == 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_YAPAN taraf = new AV001_TDI_BIL_TEBLIGAT_YAPAN();

                    taraf.YAPAN_CARI_ID = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.Value;
                    taraf.TARAF_KOD = "1";
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection.Add(taraf);
                }
                else if (icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU != 1)
                {
                    AV001_TDI_BIL_TEBLIGAT_MUHATAP taraf = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();
                    taraf.MUHATAP_CARI_ID = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.Value;
                    taraf.MUHATAP_TARAF_KOD = icram.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].TARAF_KODU;
                    taraf.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
                    taraf.KONTROL_NE_ZAMAN = DateTime.Today;
                    taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(taraf);
                }
            }

            tebligat.HAZIRLAYAN_ID = AvukatProLib.Kimlik.CurrentCariId;
        }

        private void Vazgec_Click(object sender, EventArgs e)
        {
            if (MyIcraFoy != null)
            {
                MyIcraFoy.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MyDavaFoy != null)
            {
                MyDavaFoy.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MyHazirlik != null)
            {
                MyHazirlik.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            else if (MySozlesme != null)
            {
                MySozlesme.AV001_TDI_BIL_TEBLIGATCollection.Remove(bndTebligat.Current as AV001_TDI_BIL_TEBLIGAT);
            }
            this.Close();
        }

        #endregion Methods

        private void txtTcKimlik_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTcKimlik.Text))
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.Clear();
                var table = cn.GetDataTable("Select top 1 ID from AV001_TDI_BIL_CARI WHERE VERGI_NO='" + txtTcKimlik.Text + "'");
                if (table.Rows.Count > 0)
                {
                    var cariid = (int)table.Rows[0][0];
                    var tebligat = bndTebligat[0] as AV001_TDI_BIL_TEBLIGAT;
                    var cari = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariid);
                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_ID = cariid;
                    tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_IDSource = cari;
                    txtAd.Text = cari.AD;
                    txtAdres.Text = cari.ADRES_1;
                    lkpIl.EditValue = cari.IL_ID;
                    lkpIlce.EditValue = cari.ILCE_ID;
                    txtTcKimlik.Text = cari.VERGI_NO;
                    txtTel.Text = cari.TEL_1;
                }
            }
            else
            {
                txtAd.Text = "";
                txtAdres.Text = "";
                lkpIl.EditValue = null;
                lkpIlce.EditValue = null;
                txtTcKimlik.Text = "";
                txtTel.Text = "";
            }
        }

        private void lkpIl_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpIl.EditValue != null)
                AvukatPro.Services.Implementations.DevExpressService.IlceDoldur(lkpIlce, (int)lkpIl.EditValue);

        }

        private void txtTcKimlik_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var tebligat = bndTebligat[0] as AV001_TDI_BIL_TEBLIGAT;
            if (tebligat != null)
            {
                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_ID = -1;
                tebligat.AV001_TDI_BIL_TEBLIGAT_YAPANCollection[0].YAPAN_CARI_IDSource = null;
            }
            txtAd.Text = "";
            txtAdres.Text = "";
            lkpIl.EditValue = null;
            lkpIlce.EditValue = null;
            txtTcKimlik.Text = "";
            txtTel.Text = "";
        }

        private void lueEvrak_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmLayTabligatKayit_exp frmlay = new frmLayTabligatKayit_exp();
                frmlay.FormClosed += new FormClosedEventHandler(frmlay_FormClosed);
                frmlay.Show();
            }
        }

        private void frmlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.EvrakDoldur(lueEvrak);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (opfBelge.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = opfBelge.FileNames.ToList();
            }
        }
    }
}