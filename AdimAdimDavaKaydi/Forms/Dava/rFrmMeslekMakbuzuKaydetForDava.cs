using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmMeslekMakbuzuKaydetForDava : Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        private int _foyId;
        private bool _IsModul;
        private Modul? _modul;
        private TList<AV001_TDI_BIL_FATURA> addNewList;
        private bool kaydedildi;
        private AV001_TD_BIL_FOY myFoy;
        private AV001_TD_BIL_HAZIRLIK myHazirlik;
        private AV001_TI_BIL_FOY myIcraFoy;
        private AV001_TDI_BIL_SOZLESME mySozlesme;

        #endregion Fields

        #region Constructors

        public rFrmMeslekMakbuzuKaydetForDava()
        {
            InitializeComponent();

            this.FormClosing += rFrmMeslekMakbuzuKaydetForDava_FormClosing;
            InitializeEvents();
            _modul = null;
        }

        public rFrmMeslekMakbuzuKaydetForDava(int foyId, Modul modul)
        {
            InitializeComponent();
            this.FormClosing += rFrmMeslekMakbuzuKaydetForDava_FormClosing;
            InitializeEvents();
            _modul = modul;
            _foyId = foyId;
        }

        #endregion Constructors

        #region Properties

        [Browsable(false)]
        public TList<AV001_TDI_BIL_FATURA> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        public bool IsModul
        {
            get { return _IsModul; }
            set
            {
                _IsModul = value;
                //pnlUst.Visible = value;
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myFoy = value;
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TDI_BIL_FATURA>();
                            AddNewList.AddNew();
                        }
                        DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

                else
                    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_FATURA>));
            }
        }

        [Browsable(false)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlik
        {
            get { return myHazirlik; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myHazirlik = value;
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TDI_BIL_FATURA>();
                            AddNewList.AddingNew += MyDataSource_AddingNew;
                            AddNewList.AddNew();
                        }
                        else
                            AddNewList.AddingNew += MyDataSource_AddingNew;

                        DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else
                    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myIcraFoy = value;
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TDI_BIL_FATURA>();
                            AddNewList.AddNew();
                        }

                        DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else
                    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
            }
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    mySozlesme = value;
                    try
                    {
                        if (AddNewList == null)
                        {
                            AddNewList = new TList<AV001_TDI_BIL_FATURA>();
                            AddNewList.AddNew();
                        }

                        DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA>));
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                else
                    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_FATURA>));
            }
        }

        #endregion Properties

        #region Methods

        public void Show(AV001_TD_BIL_FOY foyEn)
        {
            MyDavaFoy = foyEn;

            this.Show();
        }

        public void Show(AV001_TDI_BIL_SOZLESME foySozlesme)
        {
            MySozlesme = foySozlesme;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY foyIcra)
        {
            MyIcraFoy = foyIcra;
            this.Show();
        }

        public void Show(AV001_TD_BIL_HAZIRLIK foyHazirlik)
        {
            MyHazirlik = foyHazirlik;
            this.Show();
        }

        private void bBtnKaydetveCik_ItemClick(object sender, EventArgs e)
        {
            AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;
            fatura.Validate();

            if (Kaydet())
            {
                kaydedildi = true;

                DevExpress.XtraEditors.XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindSource()
        {
            if (_modul == null)
            {
                bndFatura.AddNew();
                bndFaturaDetay.AddNew();
            }
        }

        private void bndFatura_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_FATURA fatura = new AV001_TDI_BIL_FATURA();
            fatura.FATURA_HEDEF_TIP = Convert.ToInt16(lueModul.EditValue);
            fatura.KAYIT_TARIHI = DateTime.Now.Date;
            fatura.FATURA_TARIH = DateTime.Now.Date;
            fatura.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            fatura.KONTROL_NE_ZAMAN = DateTime.Now;
            fatura.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            fatura.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;
            fatura.REFERANS_NO = "SMM" + "-" + DateTime.Today.Year + "~" + System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();

            if (MyIcraFoy != null)
                fatura.ICRA_FOY_ID = MyIcraFoy.ID;

            else if (MyDavaFoy != null)
                fatura.DAVA_FOY_ID = MyDavaFoy.ID;

            else if (MyHazirlik != null)
                fatura.HAZIRLIK_ID = MyHazirlik.ID;

            else if (MySozlesme != null)
                fatura.SOZLESME_ID = MySozlesme.ID;

            e.NewObject = fatura;
        }

        private void bndFaturaDetay_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_FATURA_DETAY detay = new AV001_TDI_BIL_FATURA_DETAY();
            detay.KDV_DAHIL_MI = false;
            detay.STOPAJ_DAHIL_MI = false;
            detay.ADET = 1;
            detay.BIRIM_TUTAR = 0;
            detay.TOPLAM = 0;
            detay.KDV_TUTAR = 0;
            detay.STOPAJ_TUTAR = 0;
            detay.SSDF_TUTAR = 0;
            detay.GENEL_TOPLAM = 0;
            detay.BIRIM_TUTAR_DOVIZ_ID = 1;
            detay.GENEL_TOPLAM_DOVIZ_ID = 1;
            detay.KDV_TUTAR_DOVIZ_ID = 1;
            detay.SSDF_TUTAR_DOVIZ_ID = 1;
            detay.STOPAJ_TUTAR_DOVIZ_ID = 1;
            detay.TOPLAM_DOVIZ_ID = 1;
            detay.KAYIT_TARIHI = DateTime.Now.Date;
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_NE_ZAMAN = DateTime.Now;
            detay.SUBE_KOD_ID = AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;

            AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;

            fatura.AV001_TDI_BIL_FATURA_DETAYCollection.Add(detay);

            if (fatura == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Modül ve Dosya Seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            detay.ColumnChanged += new AV001_TDI_BIL_FATURA_DETAYEventHandler(detay_ColumnChanged);

            e.NewObject = fatura;

            gcFaturaDetay.DataSource = fatura.AV001_TDI_BIL_FATURA_DETAYCollection;
        }

        private bool CikabilirMi()
        {
            if (AddNewList == null || AddNewList.Count < 1)
                return true;
            foreach (AV001_TDI_BIL_FATURA f in AddNewList)
            {
                if (f.IsNew || f.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void detay_ColumnChanged(object sender, AV001_TDI_BIL_FATURA_DETAYEventArgs e)
        {
            AV001_TDI_BIL_FATURA_DETAY detay = sender as AV001_TDI_BIL_FATURA_DETAY;
            AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;

            if (detay == null || fatura == null) return;

            switch (e.Column)
            {
                case AV001_TDI_BIL_FATURA_DETAYColumn.ADET:
                case AV001_TDI_BIL_FATURA_DETAYColumn.BIRIM_TUTAR:
                    detay.TOPLAM = detay.ADET * detay.BIRIM_TUTAR;
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.KDV_TUTAR:
                case AV001_TDI_BIL_FATURA_DETAYColumn.STOPAJ_TUTAR:
                case AV001_TDI_BIL_FATURA_DETAYColumn.SSDF_TUTAR:
                case AV001_TDI_BIL_FATURA_DETAYColumn.TOPLAM:
                    detay.GENEL_TOPLAM = Convert.ToDecimal(detay.TOPLAM + detay.KDV_TUTAR + detay.STOPAJ_TUTAR + detay.SSDF_TUTAR);
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.BIRIM_TUTAR_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.GENEL_TOPLAM_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.KDV_TUTAR_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.SSDF_TUTAR_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.STOPAJ_TUTAR_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.TOPLAM_DOVIZ_ID:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.KDV_DAHIL_MI:
                    break;

                case AV001_TDI_BIL_FATURA_DETAYColumn.STOPAJ_DAHIL_MI:
                    break;

                default:
                    break;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += bBtnKaydetveCik_ItemClick;
        }

        private bool Kaydet()
        {
            try
            {
                AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;

                #region Belgeleri Ekle

                for (int rowHandle = 0; rowHandle < lueBelge.Properties.View.RowCount; rowHandle++)
                {
                    if ((bool)lueBelge.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        fatura.NN_FATURA_BELGECollection.Add(new AvukatProLib2.Entities.NN_FATURA_BELGE { BELGE_ID = (int)lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id") });
                }

                #endregion Belgeleri Ekle

                if (fatura.AV001_TDI_BIL_FATURA_DETAYCollection.Count > 0)
                {
                    DataRepository.AV001_TDI_BIL_FATURAProvider.DeepSave(fatura, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_FATURA_DETAY>), typeof(TList<NN_FATURA_BELGE>));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.Text != "Genel")
            {
                if (lueDosya.EditValue == null)
                    return;

                lueDosya.Enabled = true;
            }
            else
                lueDosya.Enabled = false;

            switch (lueModul.Text)
            {
                case "Icra":
                    MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyIcraFoy.ID, ModulId = (int)Modul.Icra, TarafKodu = TarafKodu.Muvekkil });
                    BindSource();
                    if (MyIcraFoy.SEGMENT_ID.HasValue)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).SEGMENT_ID = MyIcraFoy.SEGMENT_ID;
                    if (MyIcraFoy.ID > 0)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).ICRA_FOY_ID = MyIcraFoy.ID;
                    break;

                case "Dava":
                    MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                    AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyDavaFoy.ID, ModulId = (int)Modul.Dava, TarafKodu = TarafKodu.Muvekkil });
                    BindSource();
                    if (MyDavaFoy.SEGMENT_ID.HasValue)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).SEGMENT_ID = MyDavaFoy.SEGMENT_ID;
                    if (MyDavaFoy.ID > 0)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).DAVA_FOY_ID = MyDavaFoy.ID;
                    break;

                case "Soruþturma":
                    MyHazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)lueDosya.EditValue);
                    AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyHazirlik.ID, ModulId = (int)Modul.Sorusturma, TarafKodu = TarafKodu.Muvekkil });
                    BindSource();
                    if (MyHazirlik.SEGMENT_ID.HasValue)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).SEGMENT_ID = MyHazirlik.SEGMENT_ID;
                    if (MyHazirlik.ID > 0)
                        (bndFatura.Current as AV001_TDI_BIL_FATURA).HAZIRLIK_ID = MyHazirlik.ID;
                    break;

                case "Sözleþme":
                    MySozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)lueDosya.EditValue);
                    //AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MySozlesme.ID, ModulId = (int)Modul.Sozlesme, TarafKodu = TarafKodu.Muvekkil });
                    BindSource();
                    //if (MySozlesme.SEGMENT_ID.HasValue)
                    //    (bndFatura.Current as AV001_TDI_BIL_FATURA).SEGMENT_ID = MySozlesme.SEGMENT_ID;
                    //if (MySozlesme.ID > 0)
                    //    (bndFatura.Current as AV001_TDI_BIL_FATURA).SOZLESME_ID = MySozlesme.ID;

                    ABSqlConnection cn = new ABSqlConnection();
                    List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                    CompInfo cmpNfo = cmpNfoList[0];
                    cn.CnString = cmpNfo.ConStr;
                    lueMuvekkil.Properties.DataSource = cn.GetDataTable("SELECT ID,Kod,AD FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE ID in (SELECT CARI_ID FROM dbo.AV001_TDI_BIL_SOZLESME_TARAF(nolock) WHERE SOZLESME_ID=" + MySozlesme.ID + ") AND MUVEKKIL_MI=1");
                    lueMuvekkil.Properties.DisplayMember = "AD";
                    lueMuvekkil.Properties.ValueMember = "ID";
                    lueMuvekkil.Properties.NullText = "Müvekkil Seçiniz...";
                    lueMuvekkil.Properties.Columns.Clear();
                    lueMuvekkil.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "AD")
                    });
                    break;

                default:
                    break;
            }
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            lueDosya.Enabled = true;
            if (lueModul.Text == "Icra")
            {
                colFOY_NO.FieldName = "FoyNo";
                colADLIYE.FieldName = "AdliBirimAdliye";
                colNO.FieldName = "AaliBirimNo";
                colESAS_NO.FieldName = "EsasNo";
                colTAKIP_TARIHI.FieldName = "TakipTarihi";
                lueDosya.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllDosyaByModul(lueModul.Text);
                lueDosya.Properties.DisplayMember = "FoyNo";
                lueDosya.Properties.ValueMember = "Id";
            }

            else if (lueModul.Text == "Dava")
            {
                colFOY_NO.FieldName = "FoyNo";
                colADLIYE.FieldName = "Adliye";
                colNO.FieldName = "BirimId";
                colESAS_NO.FieldName = "EsasNo";
                colTAKIP_TARIHI.FieldName = "DavaTarihi";
                lueDosya.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllDosyaByModul(lueModul.Text);
                lueDosya.Properties.DisplayMember = "FoyNo";
                lueDosya.Properties.ValueMember = "Id";
            }

            else if (lueModul.Text == "Soruþturma")
            {
                colFOY_NO.FieldName = "HazirlikNo";
                colADLIYE.FieldName = "Adliye";
                colADLIYE.Caption = "Savcýlýk";
                colNO.FieldName = "BirimId";
                colESAS_NO.FieldName = "HazirlikEsasNo";
                colTAKIP_TARIHI.FieldName = "HazirlikTarih";
                lueDosya.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllDosyaByModul(lueModul.Text);
                lueDosya.Properties.DisplayMember = "HazirlikNo";
                lueDosya.Properties.ValueMember = "Id";
            }

            else if (lueModul.Text == "Sözleþme")
            {
                colFOY_NO.FieldName = "SozlesmeNo";
                colADLIYE.FieldName = "Adliye";
                colNO.FieldName = "No";
                colESAS_NO.FieldName = "NoterYevmiyeNo";
                colTAKIP_TARIHI.FieldName = "BaslangicTarihi";
                lueDosya.Properties.DataSource = AvukatPro.Services.Implementations.DosyaService.GetAllDosyaByModul(lueModul.Text);
                lueDosya.Properties.DisplayMember = "SozlesmeNo";
                lueDosya.Properties.ValueMember = "Id";
            }
            else if (lueModul.Text == "Genel")
            {
                BindSource();
                lueDosya.Properties.DataSource = null;
                ABSqlConnection cn = new ABSqlConnection();
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                CompInfo cmpNfo = cmpNfoList[0];
                cn.CnString = cmpNfo.ConStr;
                lueMuvekkil.Properties.DataSource = cn.GetDataTable("SELECT ID,Kod,AD FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE MUVEKKIL_MI=1");
                lueMuvekkil.Properties.DisplayMember = "AD";
                lueMuvekkil.Properties.ValueMember = "ID";
                lueMuvekkil.Properties.NullText = "Müvekkil Seçiniz...";
                lueMuvekkil.Properties.Columns.Clear();
                lueMuvekkil.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD", 30, "AD")
                    });
                lueDosya.Enabled = false;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_FATURA addNew = e.NewObject as AV001_TDI_BIL_FATURA;

            if (addNew == null)
                addNew = new AV001_TDI_BIL_FATURA();
            if (MyDavaFoy != null)
            {
                addNew.DAVA_FOY_ID = MyDavaFoy.ID;
            }
            else if (MySozlesme != null)
            {
                addNew.SOZLESME_ID = MySozlesme.ID;
            }
            else if (MyIcraFoy != null)
            {
                addNew.ICRA_FOY_ID = MyIcraFoy.ID;
            }
            else if (MyHazirlik != null)
            {
                addNew.HAZIRLIK_ID = MyHazirlik.ID;
            }
            string strRefNo = "SMM" + "-" + DateTime.Today.Year + "~" + System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
            addNew.REFERANS_NO = strRefNo;
            e.NewObject = addNew;
        }

        private void rFrmMeslekMakbuzuKaydetForDava_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = DevExpress.XtraEditors.XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?", "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bBtnKaydetveCik_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void rFrmMeslekMakbuzuKaydetForDava_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ModulGetir(lueModul.Properties);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueToplamDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueKdvDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueStopajDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueSSDFDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueGenelToplamDoviz);
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(rlueDoviz);
            deTarih.EditValue = DateTime.Now.Date;

            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);

            if (AddNewList != null && AddNewList.Count > 0)
            {
                bndFatura.AddNew();
                bndFaturaDetay.AddNew();
                bndFatura[0] = AddNewList[0];
                //bndFaturaDetay = AddNewList[0].AV001_TDI_BIL_FATURA_DETAYCollection;
                gcFaturaDetay.DataSource = AddNewList[0].AV001_TDI_BIL_FATURA_DETAYCollection;

                AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;
                fatura = AddNewList[0];
                if (AddNewList[0].ICRA_FOY_ID != null)
                    _modul = Modul.Icra;
                else if (AddNewList[0].DAVA_FOY_ID != null)
                    _modul = Modul.Dava;
                else if (AddNewList[0].HAZIRLIK_ID != null)
                    _modul = Modul.Sorusturma;
                else if (AddNewList[0].SOZLESME_ID != null)
                    _modul = Modul.Sozlesme;

                if (_modul == Modul.Icra)
                {
                    MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)AddNewList[0].ICRA_FOY_ID);
                    lueDosya.EditValue = MyIcraFoy.ID;
                }
                else if (_modul == Modul.Dava)
                {
                    MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)AddNewList[0].DAVA_FOY_ID);
                    lueDosya.EditValue = MyDavaFoy.ID;
                }
                else if (_modul == Modul.Sorusturma)
                {
                    MyHazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID((int)AddNewList[0].HAZIRLIK_ID);
                    lueDosya.EditValue = MyHazirlik.ID;
                }
                else if (_modul == Modul.Sozlesme)
                {
                    MySozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)AddNewList[0].SOZLESME_ID);
                    lueDosya.EditValue = MySozlesme.ID;
                }

                fatura.FATURA_HEDEF_TIP = Convert.ToInt16(_modul);
            }
            else
            {
                bndFatura.AddNew();
                if (_modul != null && _foyId > 0)
                {
                    bndFaturaDetay.AddNew();
                    AV001_TDI_BIL_FATURA fatura = bndFatura.Current as AV001_TDI_BIL_FATURA;

                    if (_modul == Modul.Icra)
                        MyIcraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(_foyId);
                    else if (_modul == Modul.Dava)
                        MyDavaFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(_foyId);
                    else if (_modul == Modul.Sorusturma)
                        MyHazirlik = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(_foyId);
                    else if (_modul == Modul.Sozlesme)
                        MySozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(_foyId);

                    fatura.FATURA_HEDEF_TIP = Convert.ToInt16(_modul);
                    lueDosya.EditValue = _foyId;
                }
            }

            EditorButton eb = new EditorButton();
            eb.Kind = ButtonPredefines.Plus;
            eb.Tag = "ekle";
            eb.ToolTip = "Yeni Þahýs Ekle";
            lueMuvekkil.Properties.Buttons.Add(eb);
        }

        #endregion Methods

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

        private void lueMuvekkil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();

                frm.tmpCariAd = lueMuvekkil.Text;
                frm.Statuler.Add(AvukatProLib.Extras.CariStatu.Avukat);
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        ABSqlConnection cn = new ABSqlConnection();
                        List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                        CompInfo cmpNfo = cmpNfoList[0];
                        cn.CnString = cmpNfo.ConStr;

                        switch (lueModul.Text)
                        {
                            case "Icra":
                                AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyIcraFoy.ID, ModulId = (int)Modul.Icra, TarafKodu = TarafKodu.Muvekkil });
                                break;

                            case "Dava":
                                AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyDavaFoy.ID, ModulId = (int)Modul.Dava, TarafKodu = TarafKodu.Muvekkil });
                                break;

                            case "Soruþturma":
                                AvukatPro.Services.Implementations.DevExpressService.DosyaTaraflariniDoldur(lueMuvekkil, new AvukatPro.Services.Messaging.GetDosyaTaraflariRequest { FoyId = MyHazirlik.ID, ModulId = (int)Modul.Sorusturma, TarafKodu = TarafKodu.Muvekkil });
                                break;

                            case "Sözleþme":
                                lueMuvekkil.Properties.DataSource = cn.GetDataTable("SELECT ID,Kod,AD FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE ID in (SELECT CARI_ID FROM dbo.AV001_TDI_BIL_SOZLESME_TARAF(nolock) WHERE SOZLESME_ID=" + MySozlesme.ID + ") AND MUVEKKIL_MI=1");
                                break;

                            case "Genel":
                                lueMuvekkil.Properties.DataSource = cn.GetDataTable("SELECT ID,Kod,AD FROM dbo.AV001_TDI_BIL_CARI(NOLOCK) WHERE MUVEKKIL_MI=1");
                                break;

                            default:
                                break;
                        }
                    }
                };
            }
        }

        private void lueSegment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                frmAltKategoriEkle frmalt = new frmAltKategoriEkle(frmAltKategoriEkle.Tipler.Segment, -1);
                frmalt.ShowDialog();
                AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(lueSegment);
            }
        }
    }
}