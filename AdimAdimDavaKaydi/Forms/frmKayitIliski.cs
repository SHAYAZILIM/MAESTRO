using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKayitIliski : Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        //Herhangi bir dosya altýna iliþkili dosya kaydý yapýldýðýnda bu dosyayý iliþkilendirildiði dosyanýn baðlý olduðu klasöre iliþkilendirmek için eklendi.
        public bool TransactionKapat;

        private AV001_TD_BIL_FOY myDavaFoy;
        private AV001_TD_BIL_HAZIRLIK myHazirlik;
        private AV001_TI_BIL_FOY myIcraFoy;
        private AV001_TDI_BIL_KAYIT_ILISKI myIliski;
        private AV001_TDI_BIL_SOZLESME mySozlesme;

        #endregion Fields

        #region Constructors

        public frmKayitIliski()
        {
            InitializeComponent();
            InitsData();
            InitializeEvents();
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> KayitTamamlandi;

        #endregion Events

        #region Properties

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> AddNewList
        {
            get;
            set;
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                if (value != null)
                {
                    myDavaFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
                    TList<AV001_TDI_BIL_KAYIT_ILISKI> sonuc =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format(@"{0}={1}",
                                                                                             AV001_TDI_BIL_KAYIT_ILISKIColumn
                                                                                                 .KAYNAK_DAVA_FOY_ID,
                                                                                             value.ID));
                    if (sonuc.Count > 0)
                    {
                        MyIliski = sonuc[0];
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(MyIliski, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       AV001_TDI_BIL_KAYIT_ILISKI_DETAY));

                        grdIliskiDetay.DataSource = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyDavaFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection
                            )
                            MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Add(var);

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            var.IsNew = false;
                    }
                    else
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI addNew = value.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew();

                        // new AV001_TDI_BIL_KAYIT_ILISKI();
                        addNew.KAYNAK_TIP = (byte)AvukatProLib.Extras.Modul.Dava;
                        addNew.KAYNAK_KAYIT_ID = value.ID;
                        addNew.ILISKI_TUR_ID = ModulToIliskiId(AvukatProLib.Extras.Modul.Dava);
                        addNew.KAYNAK_DAVA_FOY_ID = value.ID;
                        addNew.SUBE_KODU = 1;
                        MyIliski = addNew;
                    }
                    lueKaynakModulMaster.EditValue = MyIliski.KAYNAK_TIP;

                    //ModuleGoreDosyaGetir(glueDosyaMaster, AvukatProLib.Extras.Modul.Dava);
                    TList<AV001_TD_BIL_FOY> liste = new TList<AV001_TD_BIL_FOY>();
                    liste.Add(value);
                    glueDosyaMaster.Properties.DataSource = liste;
                    glueDosyaMaster.EditValue = value.ID;
                    glueDosyaMaster.Properties.DisplayMember = "FOY_NO";
                    glueDosyaMaster.Refresh();

                    //lueIliskiTuruMAster.EditValue = MyIliski.ILISKI_TUR_ID;
                }
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                if (value != null)
                {
                    myHazirlik = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
                    TList<AV001_TDI_BIL_KAYIT_ILISKI> sonuc =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format(@"{0}={1}",
                                                                                             AV001_TDI_BIL_KAYIT_ILISKIColumn
                                                                                                 .KAYNAK_HAZIRLIK_ID,
                                                                                             value.ID));
                    if (sonuc.Count > 0)
                    {
                        MyIliski = sonuc[0];
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(MyIliski, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       AV001_TDI_BIL_KAYIT_ILISKI_DETAY));

                        grdIliskiDetay.DataSource = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in
                                MyHazirlik.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Add(var);

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            var.IsNew = false;
                    }
                    else
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI addNew = value.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew();
                        addNew.KAYNAK_TIP = (byte)AvukatProLib.Extras.Modul.Sorusturma;
                        addNew.KAYNAK_KAYIT_ID = value.ID;
                        addNew.ILISKI_TUR_ID = ModulToIliskiId(AvukatProLib.Extras.Modul.Sorusturma);
                        addNew.KAYNAK_HAZIRLIK_ID = value.ID;
                        addNew.SUBE_KODU = 1;
                        MyIliski = addNew;
                    }
                    lueKaynakModulMaster.EditValue = MyIliski.KAYNAK_TIP;
                    TList<AV001_TD_BIL_HAZIRLIK> liste = new TList<AV001_TD_BIL_HAZIRLIK>();
                    liste.Add(value);
                    glueDosyaMaster.Properties.DataSource = liste;
                    glueDosyaMaster.EditValue = value.ID;
                    glueDosyaMaster.Properties.DisplayMember = "HAZIRLIK_NO";
                    glueDosyaMaster.Refresh();

                    //lueIliskiTuruMAster.EditValue = MyIliski.ILISKI_TUR_ID;
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                if (value != null)
                {
                    myIcraFoy = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
                    TList<AV001_TDI_BIL_KAYIT_ILISKI> sonuc =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format(@"{0}={1}",
                                                                                             AV001_TDI_BIL_KAYIT_ILISKIColumn
                                                                                                 .KAYNAK_ICRA_FOY_ID,
                                                                                             value.ID));
                    if (sonuc.Count > 0)
                    {
                        MyIliski = sonuc[0];
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(MyIliski, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       AV001_TDI_BIL_KAYIT_ILISKI_DETAY));

                        grdIliskiDetay.DataSource = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyIcraFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection
                            )
                            MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Add(var);

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            var.IsNew = false;
                    }
                    else
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI addNew = new AV001_TDI_BIL_KAYIT_ILISKI();
                        addNew.KAYNAK_TIP = (byte)AvukatProLib.Extras.Modul.Icra;
                        addNew.KAYNAK_KAYIT_ID = value.ID;
                        addNew.ILISKI_TUR_ID = ModulToIliskiId(AvukatProLib.Extras.Modul.Icra);
                        addNew.KAYNAK_ICRA_FOY_ID = value.ID;
                        addNew.SUBE_KODU = 1;
                        MyIliski = addNew;
                    }
                    lueKaynakModulMaster.EditValue = MyIliski.KAYNAK_TIP;
                    TList<AV001_TI_BIL_FOY> liste = new TList<AV001_TI_BIL_FOY>();
                    liste.Add(value);
                    glueDosyaMaster.Properties.DataSource = liste;
                    glueDosyaMaster.EditValue = value.ID;
                    glueDosyaMaster.Properties.DisplayMember = "FOY_NO";
                    glueDosyaMaster.Refresh();

                    //lueIliskiTuruMAster.EditValue = MyIliski.ILISKI_TUR_ID;
                }
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_KAYIT_ILISKI MyIliski
        {
            get { return myIliski; }
            set
            {
                if (value != null)
                {
                    myIliski = value;
                }
            }
        }

        public AvukatProLib.Extras.Modul MyModul
        {
            get
            {
                if (lueKaynakModulMaster.EditValue != null)
                    return (AvukatProLib.Extras.Modul)int.Parse(lueKaynakModulMaster.EditValue.ToString());
                return AvukatProLib.Extras.Modul.Is;
            }
        }

        //[Browsable(false)]
        //public AV001_TDI_BIL_RUCU MyRucu
        //{
        //    get { return myRucu; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            myRucu = value;
        //            TList<AV001_TDI_BIL_KAYIT_ILISKI> sonuc =
        //                DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format(@"{0}={1}",
        //                                                                                     AV001_TDI_BIL_KAYIT_ILISKIColumn
        //                                                                                         .KAYNAK_RUCU_ID,
        //                                                                                     value.ID));
        //            if (sonuc.Count > 0)
        //            {
        //                MyIliski = sonuc[0];
        //            }
        //            else
        //            {
        //                AV001_TDI_BIL_KAYIT_ILISKI addNew = new AV001_TDI_BIL_KAYIT_ILISKI();
        //                addNew.KAYNAK_KAYIT_ID = value.ID;
        //                addNew.ILISKI_TUR_ID = ModulToIliskiId(AvukatProLib.Extras.Modul.Rucu);
        //                addNew.KAYNAK_RUCU_ID = value.ID;
        //                addNew.SUBE_KODU = 1;
        //                MyIliski = addNew;
        //            }
        //            lueKaynakModulMaster.EditValue = MyIliski.KAYNAK_TIP;
        //            TList<AV001_TDI_BIL_RUCU> liste = new TList<AV001_TDI_BIL_RUCU>();
        //            liste.Add(value);
        //            glueDosyaMaster.Properties.DataSource = liste;
        //            glueDosyaMaster.EditValue = value.ID;
        //            glueDosyaMaster.Refresh();

        //            //lueIliskiTuruMAster.EditValue = MyIliski.ILISKI_TUR_ID;
        //        }
        //    }
        //}

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                if (value != null)
                {
                    mySozlesme = value;
                    if (AddNewList == null) AddNewList = new TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>();
                    TList<AV001_TDI_BIL_KAYIT_ILISKI> sonuc =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Find(string.Format(@"{0}={1}",
                                                                                             AV001_TDI_BIL_KAYIT_ILISKIColumn
                                                                                                 .KAYNAK_KAYIT_ID,
                                                                                             value.ID));
                    if (sonuc.Count > 0)
                    {
                        MyIliski = sonuc[0];
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepLoad(MyIliski, false,
                                                                                   DeepLoadType.IncludeChildren,
                                                                                   typeof(
                                                                                       AV001_TDI_BIL_KAYIT_ILISKI_DETAY));

                        grdIliskiDetay.DataSource = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;

                        var iliskiDetay =
                            DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(value.ID);

                        foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in iliskiDetay)
                            MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.Add(var);

                        foreach (
                            AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection)
                            var.IsNew = false;
                    }
                    else
                    {
                        AV001_TDI_BIL_KAYIT_ILISKI addNew = new AV001_TDI_BIL_KAYIT_ILISKI();

                        addNew.KAYNAK_TIP = (byte)AvukatProLib.Extras.Modul.Sozlesme;
                        addNew.KAYNAK_KAYIT_ID = value.ID;
                        addNew.ILISKI_TUR_ID = ModulToIliskiId(AvukatProLib.Extras.Modul.Sozlesme);
                        addNew.SUBE_KODU = 1;
                        MyIliski = addNew;
                    }
                    lueKaynakModulMaster.EditValue = MyIliski.KAYNAK_TIP;
                    TList<AV001_TDI_BIL_SOZLESME> liste = new TList<AV001_TDI_BIL_SOZLESME>();
                    liste.Add(value);
                    glueDosyaMaster.Properties.DataSource = liste;
                    glueDosyaMaster.EditValue = value.ID;
                    glueDosyaMaster.Properties.DisplayMember = "SOZLESME_NO";
                    glueDosyaMaster.Refresh();

                    //lueIliskiTuruMAster.EditValue = MyIliski.ILISKI_TUR_ID;
                }
            }
        }

        #endregion Properties

        #region Methods

        public static void ModuleGoreDosyaGetir(GridLookUpEdit rlue, AvukatProLib.Extras.Modul modulId)
        {
            switch (modulId)
            {
                case AvukatProLib.Extras.Modul.Icra:
                    if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    {
                        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                            rlue.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(AvukatProLib.Extras.Modul.Icra.ToString());
                        else
                            rlue.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetirAramaBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                        //rlue.Properties.DataSource = BelgeUtil.Inits._IcraDosyalarArama != null ? BelgeUtil.Inits.IcraDosyalariGetirAramaBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID) : BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.Where(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();

                        rlue.Properties.DisplayMember = "FOY_NO";
                        if (rlue.Properties.View.Columns.ColumnByName("FOY_NO1") != null)
                            rlue.Properties.View.Columns.ColumnByName("FOY_NO1").FieldName = "FOY_NO";
                    }
                    break;

                case AvukatProLib.Extras.Modul.Dava:
                    if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    {
                        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                            rlue.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(AvukatProLib.Extras.Modul.Dava.ToString());
                        else
                            rlue.Properties.DataSource = BelgeUtil.Inits._DavaDosyalar != null ? BelgeUtil.Inits._DavaDosyalar.FindAll(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID) :
                                BelgeUtil.Inits.context.VTD_DAVA_DOSYALARs.Where(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();
                        rlue.Properties.DisplayMember = "FOY_NO";
                        if (rlue.Properties.View.Columns.ColumnByName("FOY_NO1") != null)
                            rlue.Properties.View.Columns.ColumnByName("FOY_NO1").FieldName = "FOY_NO";
                    }
                    break;

                case AvukatProLib.Extras.Modul.Sorusturma:
                    if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    {
                        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                            rlue.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Soruþturma");
                        else
                            rlue.Properties.DataSource = BelgeUtil.Inits._SorusturmaDosyalar != null ? BelgeUtil.Inits._SorusturmaDosyalar.FindAll(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID) :
                                BelgeUtil.Inits.context.VTD_SORUSTURMA_DOSYALARs.Where(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();
                        rlue.Properties.DisplayMember = "HAZIRLIK_NO";
                        if (rlue.Properties.View.Columns.ColumnByName("FOY_NO1") != null)
                            rlue.Properties.View.Columns.ColumnByName("FOY_NO1").FieldName = "HAZIRLIK_NO";
                    }
                    break;

                //case AvukatProLib.Extras.Modul.Rucu:
                //    if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                //    {
                //        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                //            rlue.Properties.DataSource = BelgeUtil.Inits.RucuGetir();
                //        else
                //            rlue.Properties.DataSource = BelgeUtil.Inits.RucuGetirBySube(AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID);
                //        rlue.Properties.DisplayMember = "DOSYA_NO";
                //        if (rlue.Properties.View.Columns.ColumnByName("FOY_NO1") != null)
                //            rlue.Properties.View.Columns.ColumnByName("FOY_NO1").FieldName = "DOSYA_NO";
                //    }
                //    break;
                case AvukatProLib.Extras.Modul.Sozlesme:
                    if (AvukatProLib.Kimlik.Bilgi != null && AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource != null)
                    {
                        if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                            rlue.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Sözleþme");
                        else
                            rlue.Properties.DataSource = BelgeUtil.Inits._SozlesmeDosyalar != null ? BelgeUtil.Inits._SozlesmeDosyalar.FindAll(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID) :
                                BelgeUtil.Inits.context.VTD_SOZLESME_DOSYALARs.Where(vi => vi.SUBE_KOD_ID == AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID).ToList();
                        rlue.Properties.DisplayMember = "SOZLESME_NO";
                        if (rlue.Properties.View.Columns.ColumnByName("FOY_NO1") != null)
                            rlue.Properties.View.Columns.ColumnByName("FOY_NO1").FieldName = "SOZLESME_NO";
                    }
                    break;

                case AvukatProLib.Extras.Modul.Muhasebe:
                    break;

                case AvukatProLib.Extras.Modul.Genel:
                    break;

                case AvukatProLib.Extras.Modul.Belge:
                    break;

                case AvukatProLib.Extras.Modul.Tebligat:
                    break;

                case AvukatProLib.Extras.Modul.Is:
                    break;

                default:
                    break;
            }

            rlue.Properties.NullText = "Seç";
            rlue.Properties.ValueMember = "ID";
        }

        public bool KlasorIliskisiniOlustur(TransactionManager tran, TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> AddNewList)
        {
            if (AddNewList == null) return false;

            if (TransactionKapat)
                tran.Commit();

            if (!tran.IsOpen) tran.BeginTransaction();

            if (AddNewList.Count > 0 && MyIliski == null)
                MyIliski = DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(AddNewList[0].KAYIT_ILISKI_ID);

            foreach (var item in AddNewList)
            {
                if (MyIliski.ILISKI_TUR_ID == ModulToIliskiId(AvukatProLib.Extras.Modul.Icra))
                {
                    TList<AV001_TDIE_BIL_PROJE_ICRA_FOY> icraProjeList =
                        DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(MyIliski.KAYNAK_KAYIT_ID);

                    if (icraProjeList != null && icraProjeList.Count > 0)
                        return KlasoreIliskilendirmeKontrol(tran, item, icraProjeList[0].PROJE_ID);
                }
                else if (MyIliski.ILISKI_TUR_ID == ModulToIliskiId(AvukatProLib.Extras.Modul.Dava))
                {
                    TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> davaProjeList =
                        DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(MyIliski.KAYNAK_KAYIT_ID);

                    if (davaProjeList != null && davaProjeList.Count > 0)
                        return KlasoreIliskilendirmeKontrol(tran, item, davaProjeList[0].PROJE_ID);
                }
                else if (MyIliski.ILISKI_TUR_ID == ModulToIliskiId(AvukatProLib.Extras.Modul.Sorusturma))
                {
                    TList<AV001_TDIE_BIL_PROJE_HAZIRLIK> hazirlikProjeList =
                        DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(MyIliski.KAYNAK_KAYIT_ID);

                    if (hazirlikProjeList != null && hazirlikProjeList.Count > 0)
                        return KlasoreIliskilendirmeKontrol(tran, item, hazirlikProjeList[0].PROJE_ID);
                }
            }
            return true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            AV001_TDI_BIL_KAYIT_ILISKI_DETAY Detay = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddNew();

            //Detay.ILISKI_TUR_ID = Convert.ToInt32(lueIliskiTuru.EditValue);

            if (lueModul.EditValue != null)
            {
                AvukatProLib.Extras.Modul modul = (AvukatProLib.Extras.Modul)Convert.ToInt32(lueModul.EditValue);

                Detay.ILISKI_TUR_ID = ModulToIliskiId(modul);
            }
            else
            {
                MessageBox.Show("Hedef Modülü Seçilmemiþ.", "Dikkat", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            Detay.ILISKI_NEDEN_ID = Convert.ToInt32(lueIliskiNeden.EditValue);

            //object kayit = glueDosyaChild.Properties.View.GetFocusedRow();

            //if (kayit != null)
            //{
            if ((int)lueModul.EditValue == 1)
            {
                //saat 23:59 da eklendi.
                VList<per_AV001_TI_BIL_ICRA_Arama> foy = DataRepository.per_AV001_TI_BIL_ICRA_AramaProvider.Get("ID=" + glueDosyaChild.EditValue, "ID");

                Detay.HEDEF_TIP = (byte)AvukatProLib.Extras.Modul.Icra;
                Detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = foy[0].ADLI_BIRIM_ADLIYE_ID;
                Detay.HEDEF_ADLI_BIRIM_GOREV_ID = 18;//ÝCRM
                Detay.HEDEF_ADLI_BIRIM_NO_ID = foy[0].ADLI_BIRIM_NO_ID;
                Detay.HEDEF_ESAS_NO = foy[0].ESAS_NO;
                Detay.HEDEF_ICRA_FOY_ID = foy[0].ID;
                Detay.HEDEF_DOSYA_TARIHI = foy[0].TAKIP_TARIHI;
                Detay.HEDEF_KAYIT_ID = foy[0].ID;
                Detay.HEDEF_FOY_NO = foy[0].FOY_NO;
                if (BelgeUtil.Inits._TakipKonusuGetir_Enter == null)
                    BelgeUtil.Inits._TakipKonusuGetir_Enter = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.GetAll();
                if (foy[0].TAKIP_TALEP_ID.HasValue && BelgeUtil.Inits._TakipKonusuGetir_Enter.Find(vi => vi.ID == foy[0].TAKIP_TALEP_ID.Value) != null)
                    Detay.HEDEF_DOSYA_TALEP = BelgeUtil.Inits._TakipKonusuGetir_Enter.Find(vi => vi.ID == foy[0].TAKIP_TALEP_ID.Value).TALEP_ADI;
            }
            else if ((int)lueModul.EditValue == 2)
            {
                VList<VTD_DAVA_DOSYALAR> foy = DataRepository.VTD_DAVA_DOSYALARProvider.Get("ID=" + glueDosyaChild.EditValue, "ID");
                Detay.HEDEF_TIP = (byte)AvukatProLib.Extras.Modul.Dava;
                Detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = foy[0].ADLIYE_ID;
                Detay.HEDEF_ADLI_BIRIM_GOREV_ID = foy[0].GOREV_ID;
                Detay.HEDEF_ADLI_BIRIM_NO_ID = foy[0].BIRIM_ID;
                Detay.HEDEF_ESAS_NO = foy[0].ESAS_NO;
                Detay.HEDEF_DAVA_FOY_ID = foy[0].ID;
                Detay.HEDEF_DOSYA_TARIHI = foy[0].DAVA_TARIHI;
                Detay.HEDEF_KAYIT_ID = foy[0].ID;
                Detay.HEDEF_FOY_NO = foy[0].FOY_NO;
                if (BelgeUtil.Inits._DavaTalepGetir == null)
                    BelgeUtil.Inits._DavaTalepGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
                if (foy[0].DAVA_TALEP_ID.HasValue && BelgeUtil.Inits._DavaTalepGetir.Find(vi => vi.ID == foy[0].DAVA_TALEP_ID.Value) != null)
                    Detay.HEDEF_DOSYA_TALEP = BelgeUtil.Inits._DavaTalepGetir.Find(vi => vi.ID == foy[0].DAVA_TALEP_ID.Value).DAVA_TALEP;
            }
            else if ((int)lueModul.EditValue == 3)
            {
                VList<VTD_SORUSTURMA_DOSYALAR> foy = DataRepository.VTD_SORUSTURMA_DOSYALARProvider.Get("ID=" + glueDosyaChild.EditValue, "ID");
                Detay.HEDEF_TIP = (byte)AvukatProLib.Extras.Modul.Sorusturma;
                Detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = foy[0].ADLIYE_ID;
                Detay.HEDEF_ADLI_BIRIM_GOREV_ID = foy[0].GOREV_ID;
                Detay.HEDEF_ADLI_BIRIM_NO_ID = foy[0].BIRIM_ID;
                Detay.HEDEF_ESAS_NO = foy[0].HAZIRLIK_ESAS_NO;
                Detay.HEDEF_HAZIRLIK_ID = foy[0].ID;
                Detay.HEDEF_DOSYA_TARIHI = foy[0].HAZIRLIK_TARIH;
                Detay.HEDEF_KAYIT_ID = foy[0].ID;
                Detay.HEDEF_FOY_NO = foy[0].HAZIRLIK_NO;

                //if (foy.HAZIRLIK_DURUM_IDSource != null)
                //    Detay.HEDEF_DOSYA_TALEP = foy.SIKAYET_KONU_IDSource.SIKAYET_KON;
            }
            else if ((int)lueModul.EditValue == 5)
            {
                VList<VTD_SOZLESME_DOSYALAR> foy = DataRepository.VTD_SOZLESME_DOSYALARProvider.Get("ID=" + glueDosyaChild.EditValue, "ID");
                Detay.HEDEF_TIP = (byte)AvukatProLib.Extras.Modul.Sozlesme;
                Detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = foy[0].ADLIYE_ID;
                Detay.HEDEF_ADLI_BIRIM_GOREV_ID = foy[0].GOREV_ID;
                Detay.HEDEF_ADLI_BIRIM_NO_ID = foy[0].BIRIM_ID;
                Detay.HEDEF_ESAS_NO = foy[0].NOTER_YEVMIYE_NO;
                Detay.HEDEF_DOSYA_TARIHI = foy[0].BASLANGIC_TARIHI;
                Detay.HEDEF_KAYIT_ID = foy[0].ID;
                Detay.HEDEF_FOY_NO = foy[0].SOZLESME_NO;
                if (BelgeUtil.Inits._SozlesmeAltTipiHepsiGetir_Enter == null)
                    BelgeUtil.Inits._SozlesmeAltTipiHepsiGetir_Enter = DataRepository.per_TDI_KOD_SOZLESME_ALT_TIPProvider.GetAll();
                if (foy[0].ALT_TIP_ID.HasValue && BelgeUtil.Inits._SozlesmeAltTipiHepsiGetir_Enter.Find(vi => vi.ID == foy[0].ALT_TIP_ID.Value) != null)
                    Detay.HEDEF_DOSYA_TALEP = BelgeUtil.Inits._SozlesmeAltTipiHepsiGetir_Enter.Find(vi => vi.ID == foy[0].ALT_TIP_ID.Value).ALT_TIP;
            }
            //}
            AddNewList.Add(Detay);
            grdIliskiDetay.DataSource = MyIliski.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection;
        }

        private bool DosyayiKlasoreIliskilendir(TransactionManager tran, int foyID, int klasorID, AvukatProLib.Extras.Modul modul)
        {
            if (modul == AvukatProLib.Extras.Modul.Dava)
            {
                AV001_TDIE_BIL_PROJE_DAVA_FOY davaProje = new AV001_TDIE_BIL_PROJE_DAVA_FOY();
                davaProje.DAVA_FOY_ID = foyID;
                davaProje.PROJE_ID = klasorID;

                if (DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByDAVA_FOY_ID(foyID).Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.Save(tran, davaProje);
                    return true;
                }

                //else
                //{
                //    XtraMessageBox.Show(
                //        "Seçili Dava Dosyasý baþka bir klasör üzerinde olduðu için iliþkilendirme iþlemi gerçekleþtirilemedi.",
                //        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return false;
                //}
            }
            else if (modul == AvukatProLib.Extras.Modul.Icra)
            {
                AV001_TDIE_BIL_PROJE_ICRA_FOY icraProje = new AV001_TDIE_BIL_PROJE_ICRA_FOY();
                icraProje.ICRA_FOY_ID = foyID;
                icraProje.PROJE_ID = klasorID;

                if (DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByICRA_FOY_ID(foyID).Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.Save(tran, icraProje);
                    return true;
                }

                //else
                //{
                //    XtraMessageBox.Show(
                //        "Seçili Ýcra Dosyasý baþka bir klasör üzerinde olduðu için iliþkilendirme iþlemi gerçekleþtirilemedi.",
                //        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return false;
                //}
            }
            else if (modul == AvukatProLib.Extras.Modul.Sorusturma)
            {
                AV001_TDIE_BIL_PROJE_HAZIRLIK hazirlikProje = new AV001_TDIE_BIL_PROJE_HAZIRLIK();
                hazirlikProje.HAZIRLIK_ID = foyID;
                hazirlikProje.PROJE_ID = klasorID;

                if (DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByHAZIRLIK_ID(foyID).Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.Save(tran, hazirlikProje);
                    return true;
                }

                //else
                //{
                //    XtraMessageBox.Show(
                //        "Seçili Hazýrlýk Dosyasý baþka bir klasör üzerinde olduðu için iliþkilendirme iþlemi gerçekleþtirilemedi.",
                //        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return false;
                //}
            }

            return true;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += Kaydet_Click;
        }

        private void InitsData()
        {
            BelgeUtil.Inits.ModulKodGetirForKayitIliski(lueKaynakModulMaster);
            BelgeUtil.Inits.ModulKodGetirForKayitIliski(lueModul);
            BelgeUtil.Inits.KayitIliskiTurGetir(rLueIlýskiTur);
            BelgeUtil.Inits.KayitIliskiNedenGetir(lueIliskiNeden);
            BelgeUtil.Inits.KayitIliskiNedenGetir(rLueIliskiNeden);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye2);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev2);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo2);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.ModulGetir(rlueHedefTip);
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;

            if (result)
            {
                if (Save())
                {
                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private bool KlasoreIliskilendirmeKontrol(TransactionManager tran, AV001_TDI_BIL_KAYIT_ILISKI_DETAY item,
            int klasorID)
        {
            if (item == null) return false;

            if (item.HEDEF_DAVA_FOY_ID.HasValue)
                return DosyayiKlasoreIliskilendir(tran, item.HEDEF_DAVA_FOY_ID.Value, klasorID, AvukatProLib.Extras.Modul.Dava);
            else if (item.HEDEF_ICRA_FOY_ID.HasValue)
                return DosyayiKlasoreIliskilendir(tran, item.HEDEF_ICRA_FOY_ID.Value, klasorID, AvukatProLib.Extras.Modul.Icra);
            else if (item.HEDEF_HAZIRLIK_ID.HasValue)
                return DosyayiKlasoreIliskilendir(tran, item.HEDEF_HAZIRLIK_ID.Value, klasorID, AvukatProLib.Extras.Modul.Sorusturma);
            return true;
        }

        private void lueKaynakModulMaster_EditValueChanged(object sender, EventArgs e)
        {
            object EditValueKaynakModul = lueKaynakModulMaster.EditValue;
            if (EditValueKaynakModul != null)
            {
                AvukatProLib.Extras.Modul modul = (AvukatProLib.Extras.Modul)Convert.ToInt32(lueKaynakModulMaster.EditValue);
                ModuleGoreDosyaGetir(glueDosyaMaster, modul);
            }
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            object EditValueKaynakModul = lueModul.EditValue;
            if (lueModul != null)
            {
                AvukatProLib.Extras.Modul modul = (AvukatProLib.Extras.Modul)EditValueKaynakModul;
                ModuleGoreDosyaGetir(glueDosyaChild, modul);
            }
        }

        private int ModulToIliskiId(AvukatProLib.Extras.Modul MyModul)
        {
            switch (MyModul)
            {
                case AvukatProLib.Extras.Modul.Icra:
                    return 601;

                case AvukatProLib.Extras.Modul.Dava:
                    return 5661;

                case AvukatProLib.Extras.Modul.Sorusturma:
                    return 5610;

                //case AvukatProLib.Extras.Modul.Rucu:
                //    return 5600;
                //    break;
                case AvukatProLib.Extras.Modul.Sozlesme:
                    return 7500;

                default:
                    return 1;
            }
        }

        private bool Save()
        {
            bool sonuc = false;
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay = null;
                tran.BeginTransaction();
                AV001_TDI_BIL_KAYIT_ILISKI iliski =
                    DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByILISKI_TUR_IDKAYNAK_KAYIT_ID(
                        MyIliski.ILISKI_TUR_ID, MyIliski.KAYNAK_KAYIT_ID);
                if (iliski == null)
                {
                    detay =
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.GetByHEDEF_KAYIT_ID(
                            MyIliski.KAYNAK_KAYIT_ID).FirstOrDefault();
                    if (detay != null)
                    {
                        var kaynakKayit =
                            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.GetByID(detay.KAYIT_ILISKI_ID);

                        //detay.KAYIT_ILISKI_ID = kaynakKayit.ID;
                        //DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.Save(tran, detay);
                        MyIliski = kaynakKayit;
                    }
                    else
                        DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.Save(tran, MyIliski);
                }
                else
                {
                    MyIliski = iliski;

                    #region <MB-20100627>

                    //Herhangi bir dosya altýna iliþkili dosya kaydý yapýldýðýnda bu dosyayý iliþkilendirildiði dosyanýn baðlý olduðu klasöre iliþkilendirmek için eklendi.
                    if (!KlasorIliskisiniOlustur(tran, AddNewList)) return false;

                    #endregion <MB-20100627>
                }

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    AddNewList[i].KAYIT_ILISKI_ID = MyIliski.ID;
                }

                //foreach (AV001_TDI_BIL_KAYIT_ILISKI_DETAY var in AddNewList)
                //{
                //    var.KAYIT_ILISKI_ID = var.ID;
                //}
                DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.DeepSave(tran, AddNewList);
                tran.Commit();
                if (KayitTamamlandi != null)
                    KayitTamamlandi(AddNewList, new EventArgs());

                sonuc = true;

                switch (MyModul)
                {
                    case AvukatProLib.Extras.Modul.Icra:
                        MyIcraFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddRange(AddNewList);
                        break;

                    case AvukatProLib.Extras.Modul.Dava:
                        MyDavaFoy.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddRange(AddNewList);
                        break;

                    case AvukatProLib.Extras.Modul.Sorusturma:
                        MyHazirlik.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddRange(AddNewList);
                        break;

                    //case AvukatProLib.Extras.Modul.Rucu:
                    //    MyRucu.AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddRange(AddNewList);
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                if (ex.Message.Contains("uKAYIT_ILISKI_ID_ILISKI_TUR_ID_HEDEF_KAYIT_ID"))
                {
                    XtraMessageBox.Show("Daha önce bu dosya iliþkilerndirilmiþ baþka dosya seçiniz.",
                                        "Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                    BelgeUtil.ErrorHandler.Catch(this, ex);
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        #endregion Methods
    }
}