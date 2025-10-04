using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmBorcluMalKaydetVGrid : Util.BaseClasses.AvpXtraForm
    {
        public frmBorcluMalKaydetVGrid()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += frmBorcluMalKaydetVGrid_FormClosing;
        }

        private TList<TDI_BIL_BORCLU_MAL> _MyDataSource;

        private AV001_TDIE_BIL_PROJE _MyProje;

        private int _MyTip;

        private bool kaydedildi;

        private AV001_TI_BIL_FOY myFoy;

        private AV001_TDI_BIL_SOZLESME mySozlesme;
        //UNDONE: Seçilen kategoriye baðlý türlerin listelenmesi gerekiyor ve seçilen türe baðlý cinslerin listelenmesi gerekiyor.

        public event EventHandler<EventArgs> Kaydedildi;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<TDI_BIL_BORCLU_MAL> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (MyFoy == null)
                {
                    if (MyDataSource == null) MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();
                    ucBorcluMalBilgileri1.MyDataSource = MyDataSource;
                    ucBorcluMalBilgileri1.MyDataSource.AddingNew += BorcluMal_AddingNew;
                    ucBorcluMalBilgileri1.MyDataSource.AddNew();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !DesignMode)
                {
                    myFoy = value;
                    try
                    {
                        if (MyDataSource == null) MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();
                        ucBorcluMalBilgileri1.MyDataSource = MyDataSource;
                        ucBorcluMalBilgileri1.MyDataSource.AddingNew += BorcluMal_AddingNew;
                        ucBorcluMalBilgileri1.MyDataSource.AddNew();
                        MyDataSource.ForEach(delegate(TDI_BIL_BORCLU_MAL b)
                                                 {
                                                     b.PropertyChanged += borclu_PropertyChanged;
                                                     b.ColumnChanging += addNew_ColumnChanging;
                                                 });
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                _MyProje = value;
                initializeProjeMal(value);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                if (value != null && !DesignMode)
                {
                    mySozlesme = value;
                    try
                    {
                        if (MyDataSource == null) MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();
                        ucBorcluMalBilgileri1.MyDataSource = MyDataSource;
                        ucBorcluMalBilgileri1.MyDataSource.AddingNew += BorcluMal_AddingNew;
                        MyDataSource.ForEach(
                            delegate(TDI_BIL_BORCLU_MAL b) { b.PropertyChanged += borclu_PropertyChanged; });
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MyTip
        {
            get { return _MyTip; }
            set
            {
                if (value != null)
                    _MyTip = value;
            }
        }
        
        public void ShowDialog(AV001_TDIE_BIL_PROJE proj)
        {
            MyProje = proj;
            this.Show();
        }

        private void addNew_ColumnChanging(object sender, TDI_BIL_BORCLU_MALEventArgs e)
        {
            TDI_BIL_BORCLU_MAL malbilgi = sender as TDI_BIL_BORCLU_MAL;
            if (e.Column == TDI_BIL_BORCLU_MALColumn.HACIZLI_MAL_ADEDI)
            {
                malbilgi.HACIZLI_MAL_SATIR_TOPLAM_MIKTAR = malbilgi.HACIZLI_MAL_DEGERI.Value * Convert.ToDecimal(e.Value);
            }
        }

        private void borclu_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        private void BorcluMal_AddingNew(object sender, AddingNewEventArgs e)
        {
            TDI_BIL_BORCLU_MAL addNew = e.NewObject as TDI_BIL_BORCLU_MAL;
            TList<AV001_TI_BIL_FOY_TARAF> foytrf = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);

            try
            {
                if (MyFoy != null)
                {
                    if (addNew == null)
                        addNew = new TDI_BIL_BORCLU_MAL();

                    addNew.HACIZLI_MAL_ADET_BIRIM_ID = (int)HacizliMalAdetBirim.AD;
                    addNew.HACIZLI_MAL_ADEDI = 1;
                    if (frmIcraDosyaKayit.listTakipEden.Count != 0 || frmIcraDosyaKayit.listTakipEden.Count > 0)
                    {
                        addNew.CARI_ID = foytrf[0].CARI_ID.Value;
                    }
                    else
                    {
                        TList<AV001_TI_BIL_FOY_TARAF> TakipEdilen = ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy);
                        addNew.CARI_ID = foytrf[0].CARI_ID.Value;
                    }

                    addNew.MAL_SIRA_NO = ucBorcluMalBilgileri.GetMalSiraNo(MyFoy.TDI_BIL_BORCLU_MALCollection);
                    addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
                    addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
                    addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                    addNew.ESAS_NO = MyFoy.ESAS_NO;
                    if (MyTip == (int)HAZIZ_CHILD_TIP.Araþtýrma_Ýle_Tespit_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Rehin_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Borçlunun_Beyan_Ettiði_Mal)
                        addNew.TIP = (byte)MyTip;
                    else if (MyTip == (int)HAZIZ_CHILD_TIP.Haciz_Edilmiþ_Mal)
                        addNew.TIP = (byte)MyTip;

                    //switch ((FormTipleri)MyFoy.FORM_TIP_ID.Value)
                    //{
                    //    case FormTipleri.Form50:
                    //    case FormTipleri.Form151:
                    //    case FormTipleri.Form201:
                    //    case FormTipleri.Form152:
                    //        addNew.TIP = (int)HAZIZ_CHILD_TIP.Rehin_Edilmiþ_Mal;
                    //        break;
                    //}

                    e.NewObject = addNew;
                }
                else
                {
                    if (addNew == null)
                        addNew = new TDI_BIL_BORCLU_MAL();
                    addNew.MAL_SIRA_NO = ucBorcluMalBilgileri.GetMalSiraNo(MyDataSource);
                    if (MyProje != null)
                    {
                        AV001_TDIE_BIL_PROJE_BORCLU_MAL projMal =
                            addNew.AV001_TDIE_BIL_PROJE_BORCLU_MALCollection.AddNew();
                        projMal.PROJE_ID = MyProje.ID;
                    }
                    e.NewObject = addNew;
                }
                addNew.ColumnChanging += addNew_ColumnChanging;
            }

            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private bool CikabilirMi()
        {
            if (MyDataSource == null) return true;
            foreach (TDI_BIL_BORCLU_MAL n in MyDataSource)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmBorcluMalKaydetVGrid_Button_Kaydet_Click(object sender, EventArgs e)
        {
            bool result = true;
            foreach (TDI_BIL_BORCLU_MAL n in MyDataSource)
            {
                string sStr = ucBorcluMalBilgileri.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

                    result = false;
                    break;
                }
            }

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmBorcluMalKaydetVGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    frmBorcluMalKaydetVGrid_Button_Kaydet_Click(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmBorcluMalKaydetVGrid_Load(object sender, EventArgs e)
        {
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmBorcluMalKaydetVGrid_Button_Kaydet_Click;
        }

        private void initializeProjeMal(AV001_TDIE_BIL_PROJE proj)
        {
            ucBorcluMalBilgileri1.OutSource = true;
            ucBorcluMalBilgileri1.MyDataSource = MyDataSource = new TList<TDI_BIL_BORCLU_MAL>();

            MyDataSource.AddingNew += BorcluMal_AddingNew;
        }

        private bool Save()
        {
            bool sonuc = false;

            if (MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

                _MyDataSource.ForEach(delegate(TDI_BIL_BORCLU_MAL k)
                                          {
                                              if (MyFoy.ID > 0)
                                                  k.ICRA_FOY_ID = MyFoy.ID;
                                          });

                // MyFoy.TDI_BIL_BORCLU_MALCollection.AddRange(MyDataSource);
                foreach (var item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                              typeof(TList<AV001_TDI_BIL_SOZLESME>));
                    foreach (
                        var item2 in item.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW)
                    {
                        item2.TDI_BIL_BORCLU_MALCollection.AddRange(MyDataSource);
                    }
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            foreach (var item in MyDataSource)
            {
                if (item.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.GAYRÝMENKUL)
                {
                    if (ucBorcluMalBilgileri1.gayrimenkul.Count > 0)
                    {
                        tran.BeginTransaction();
                        DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(tran, ucBorcluMalBilgileri1.gayrimenkul,
                                                                                 DeepSaveType.IncludeChildren,
                                                                                 typeof(
                                                                                     TList
                                                                                     <AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                        tran.Commit();
                    }
                    if (ucBorcluMalBilgileri1.gayrimenkul.Count > 0)
                        item.GAYRIMENKUL_BILGI_ID = ucBorcluMalBilgileri1.gayrimenkul[0].ID;
                }
                if (item.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.ARAÇ)
                {
                    if (ucBorcluMalBilgileri1.Arac.Count > 0)
                    {
                        tran.BeginTransaction();

                        DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(tran, ucBorcluMalBilgileri1.Arac);
                        tran.Commit();
                        item.ARAC_BILGI_ID = ucBorcluMalBilgileri1.Arac[0].ID;
                    }
                    if (ucBorcluMalBilgileri1.Arac.Count > 0)
                        item.ARAC_BILGI_ID = ucBorcluMalBilgileri1.Arac[0].ID;
                }
                else if (item.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.GEMÝ)
                {
                    if (ucBorcluMalBilgileri1.Gemi.Count > 0)
                    {
                        tran.BeginTransaction();

                        DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(tran, ucBorcluMalBilgileri1.Gemi);
                        tran.Commit();
                        item.ARAC_BILGI_ID = ucBorcluMalBilgileri1.Gemi[0].ID;
                    }
                }
                else if (item.HACIZLI_MAL_KATEGORI_ID == (int)HACIZLI_MAL_KATEGORI.UÇAK)
                {
                    if (ucBorcluMalBilgileri1.Ucak.Count > 0)
                    {
                        tran.BeginTransaction();

                        DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.DeepSave(tran, ucBorcluMalBilgileri1.Ucak);
                        tran.Commit();
                        item.ARAC_BILGI_ID = ucBorcluMalBilgileri1.Ucak[0].ID;
                    }
                }
            }
            try
            {
                if (MyFoy != null)
                {
                    tran.BeginTransaction();

                    DataRepository.TDI_BIL_BORCLU_MALProvider.DeepSave(tran, MyDataSource);

                    tran.Commit();
                    sonuc = true;
                }
                else if (MyProje != null)
                {
                    tran.BeginTransaction();

                    DataRepository.TDI_BIL_BORCLU_MALProvider.DeepSave(tran, MyDataSource, DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDIE_BIL_PROJE_BORCLU_MAL>));
                    tran.Commit();
                    sonuc = true;
                }

                else if (MyFoy == null)
                {
                    tran.BeginTransaction();

                    DataRepository.TDI_BIL_BORCLU_MALProvider.DeepSave(tran, MyDataSource);

                    tran.Commit();
                    sonuc = true;
                }
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);
                if (MyFoy != null)
                    for (int i = 0; i < MyDataSource.Count; i++)
                    {
                        MyFoy.TDI_BIL_BORCLU_MALCollection.Remove(MyDataSource[i]);
                    }
            }
            finally
            {
                tran.Dispose();
            }
            if (sonuc)
                if (this.Kaydedildi != null)
                    Kaydedildi(this, null);
            return sonuc;
        }
    }
}