using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class rFrmIcraIhtiyatiHaciz : Util.BaseClasses.AvpXtraForm
    {
        public rFrmIcraIhtiyatiHaciz()
        {
            InitializeComponent();
            this.FormClosed += rFrmIcraIhtiyatiHaciz_FormClosed;
            this.FormClosing += rFrmIcraIhtiyatiHaciz_FormClosing;
            InitializeEvents();
        }

        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> hacizList = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

        private bool _KlasorIcin;

        private AV001_TDIE_BIL_PROJE _MyProje;

        private AV001_TI_BIL_FOY myFoy;

        private AV001_TI_BIL_IHTIYATI_HACIZ row;

        public event EventHandler<EventArgs> Kaydedildi;

        /// <summary>
        /// Klasör için iþlem yapýlacak ise true olmalýdýr.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool KlasorIcin
        {
            get { return _KlasorIcin; }
            set
            {
                _KlasorIcin = value;
                ucTazminat_Ihtiyat_Taraf1.KlasorIcin = value;
                ucTazminat_Ihtiyat1.KlasorIcin = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    ucTazminat_Ihtiyat1.MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;

                    //if (ucTazminat_Ihtiyat1.CurrentHaciz != null)
                    //    ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                    //        ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;

                    MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.ForEach(
                        delegate(AV001_TI_BIL_IHTIYATI_HACIZ h) { h.ColumnChanged += ucTazminat_Ihtiyat1_MyDataSourceChanged; });

                    MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.AddingNew +=
                        AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew;

                    if (ucTazminat_Ihtiyat1.CurrentHaciz == null)
                    {
                        if (ucTazminat_Ihtiyat_Taraf1.MyDataSource != null)
                            ucTazminat_Ihtiyat_Taraf1.MyDataSource.Clear();
                    }
                    else
                    {
                        ucTazminat_Ihtiyat_Taraf1.MyFoy = MyFoy;
                        ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                            ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        /// <summary>
        /// Klasör ile ilgili iþlem yapýlacaðýnda kullanýlacak olan property.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                _MyProje = value;
                if (value != null)
                {
                    //Eðer klasör den geliniyor ise yeni bir collection oluþturuyoruz.
                    if (hacizList.Count == 0)
                    {
                        hacizList.AddingNew += AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew;
                        hacizList.AddNew();
                        ucTazminat_Ihtiyat1.MyDataSource = hacizList;

                        //Birtane ekliyoruz ki paþam uðraþmasýn birde artý butonuyla
                        //ucTazminat_Ihtiyat1.MyDataSource.AddNew();
                    }
                    else
                    {
                        ucTazminat_Ihtiyat1.MyDataSource = hacizList;
                    }
                    if (ucTazminat_Ihtiyat1.CurrentHaciz == null)
                    {
                        if (ucTazminat_Ihtiyat_Taraf1.MyDataSource != null)
                            ucTazminat_Ihtiyat_Taraf1.MyDataSource.Clear();
                    }
                    else
                    {
                        if (MyFoy != null)
                        {
                            ucTazminat_Ihtiyat_Taraf1.MyFoy = MyFoy;
                            ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                                ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
                        }
                        else
                        {
                            if (ucTazminat_Ihtiyat1.MyDataSource[0].AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Count ==
                                0)
                                DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepLoad(
                                    ucTazminat_Ihtiyat1.MyDataSource[0], false, DeepLoadType.IncludeChildren,
                                    typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>),
                                    typeof(TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ>));
                            ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                                ucTazminat_Ihtiyat1.MyDataSource[0].AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
                        }
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_IHTIYATI_HACIZ Row
        {
            get
            {
                if (MyFoy != null && MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Count > 0)
                {
                    return row = ucTazminat_Ihtiyat1.CurrentHaciz;
                }
                return null;
            }
        }

        #region Eski

        //[Browsable(false)]
        //public TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource
        //{
        //    get
        //    {
        //        return ucTazminat_Ihtiyat1.MyDataSource;
        //    }
        //    set
        //    {
        //        ucTazminat_Ihtiyat1.MyDataSource = value;
        //        if (ucTazminat_Ihtiyat1.CurrentHaciz != null)
        //            ucTazminat_Ihtiyat_Taraf1.MyDataSource = ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;

        //        MyDataSource.ForEach(delegate(AV001_TI_BIL_IHTIYATI_HACIZ h)
        //        {
        //            h.ColumnChanged += new AV001_TI_BIL_IHTIYATI_HACIZEventHandler(ucTazminat_Ihtiyat1_MyDataSourceChanged);
        //        });

        //        MyDataSource.AddingNew += new AddingNewEventHandler(MyDataSource_AddingNew);
        //    }
        //}

        #endregion Eski
        
        /// <summary>
        /// Formu klasör ile kullanacaksak bu methodu kullanabiliriz
        /// </summary>
        /// <param name="proje">Ýþlemin gerçekleþeceði proje örneði</param>
        /// <returns>ShowDialog() methodundan geri dönen deðer.</returns>
        public void ShowDialog(AV001_TDIE_BIL_PROJE proje)
        {
            this.MyProje = proje;
            this.Show();
        }

        private void AV001_TI_BIL_IHTIYATI_HACIZCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_IHTIYATI_HACIZ entity = e.NewObject as AV001_TI_BIL_IHTIYATI_HACIZ;
            if (entity == null)
                entity = new AV001_TI_BIL_IHTIYATI_HACIZ();

            entity.TALEP_TARIHI = DateTime.Today;
            if (MyFoy != null)
            {
                if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                    entity.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID.Value;

                entity.ESAS_NO = MyFoy.ESAS_NO;
                entity.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID.Value;
                entity.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
                entity.BIRIM_NO = MyFoy.BIRIM_NO;
            }
            entity.KAYIT_TARIHI = DateTime.Today;
            entity.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            entity.KONTROL_KIM = "AVUKATPRO";
            entity.KONTROL_NE_ZAMAN = DateTime.Today;
            entity.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            entity.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            entity.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            entity.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Clear();
            AV001_TI_BIL_IHTIYATI_HACIZ_TARAF taraf = entity.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.AddNew();

            taraf.ADMIN_KAYIT_MI = false;
            taraf.KAYIT_TARIHI = DateTime.Today;
            taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            taraf.KONTROL_KIM = "AVUKATPRO";
            taraf.KONTROL_NE_ZAMAN = DateTime.Today;
            taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            taraf.ICRA_CARI_TARAF_ID = ucIcraTarafBilgileri.CurrBorcluId;

            if (BelgeUtil.Inits._FoyTarafGetir == null)
                BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();

            AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF t =
                BelgeUtil.Inits._FoyTarafGetir.Find(vi => vi.CARI_ID == ucIcraTarafBilgileri.CurrBorcluId);
            if (t != null)
            {
                taraf.TARAF_SIFAT_ID = t.TARAF_SIFAT_ID;
            }
            if (MyProje != null)
            {
                entity.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.Clear();

                if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
                foreach (AV001_TDIE_BIL_PROJE_TARAF pTrf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    AV001_TI_BIL_IHTIYATI_HACIZ_TARAF acima =
                        entity.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.AddNew();
                    acima.ADMIN_KAYIT_MI = false;
                    acima.KAYIT_TARIHI = DateTime.Today;
                    acima.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                    acima.KONTROL_KIM = "AVUKATPRO";
                    acima.KONTROL_NE_ZAMAN = DateTime.Today;
                    acima.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                    acima.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    acima.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
                    acima.ICRA_CARI_TARAF_ID = pTrf.CARI_ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(pTrf, true, DeepLoadType.IncludeChildren,
                                                                               typeof(AV001_TDI_BIL_CARI));
                    if (pTrf.CARI_IDSource != null && pTrf.CARI_IDSource.MUVEKKIL_MI)
                        acima.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.DAVACI;
                    else
                        acima.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.DAVALI;
                }
            }
            e.NewObject = entity;
        }

        private bool CikabilirMi()
        {
            if (KlasorIcin) return true; //Klasör için olduðunda bu method çalýþmayacak
            if (Row != null && (Row.IsNew || Row.HasDataChanged()))
                return false;

            return true;
        }

        private void GeriAl()
        {
            if (KlasorIcin) return; //Klasör için olduðunda bu method çalýþmayacak
            try
            {
                if (Row != null)
                {
                    if (Row.IsNew)
                    {
                        MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.RemoveEntity(Row);
                    }
                    else if (Row.ChangedProperties.Count > 0)
                    {
                        Row.CancelChanges();
                    }
                }
                else if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.DeletedItems.Count > 0)
                    MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.Add(Row);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmIcraIhtiyatiHaciz_Button_Kaydet_Click;
        }

        private void rFrmIcraIhtiyatiHaciz_Button_Kaydet_Click(object sender, EventArgs e)
        {
            IslemTamamlandi();
        }

        private void rFrmIcraIhtiyatiHaciz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (KlasorIcin) return; //Klasör için olduðunda bu method çalýþmayacak
            if (MyGelisme == null) return;

            ucIcraTarafGelismeleri.IhtiyatiHacizHesapla(MyGelisme, MyFoy);
        }

        private void rFrmIcraIhtiyatiHaciz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KlasorIcin) return; //Klasör için olduðunda bu method çalýþmayacak
            if (!CikabilirMi())
            {
                DialogResult dr =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmedi.Çýkmak istediðinizden emin misiniz ?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GeriAl();
                }
                else
                    e.Cancel = true;
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();
                if (KlasorIcin)
                {
                    DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(trans, ucTazminat_Ihtiyat1.MyDataSource,
                                                                                DeepSaveType.IncludeChildren,
                                                                                typeof(
                                                                                    TList
                                                                                    <AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>));
                    foreach (AV001_TI_BIL_IHTIYATI_HACIZ iHaciz in ucTazminat_Ihtiyat1.MyDataSource)
                    {
                        ucTazminat_Ihtiyat1.MyDataSourceTeminat.ForEach(mektup =>
                                                                            {
                                                                                mektup.IHTIYATI_HACIZ_ID = iHaciz.ID;
                                                                                if (MyFoy != null)
                                                                                    mektup.ICRA_FOY_ID = MyFoy.ID;
                                                                            });

                        if (
                            MyProje.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZCollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ kiymetliEvrak) { return kiymetliEvrak.IHTIYATI_HACIZ_ID == iHaciz.ID; })) continue;

                        AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ pHaciz = new AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ();
                        pHaciz.PROJE_ID = MyProje.ID;
                        pHaciz.IHTIYATI_HACIZ_ID = iHaciz.ID;
                        DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.Save(trans, pHaciz);
                    }

                    DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Save(trans,
                                                                             ucTazminat_Ihtiyat1.MyDataSourceTeminat);
                }
                else
                {
                    foreach (var item in MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection)
                    {
                        item.ICRA_FOY_ID = MyFoy.ID;
                    }

                    DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(trans,
                                                                                MyFoy.
                                                                                    AV001_TI_BIL_IHTIYATI_HACIZCollection,
                                                                                DeepSaveType.IncludeChildren,
                                                                                typeof(
                                                                                    TList
                                                                                    <AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>));
                }
                trans.Commit();

                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }
            if (this.Kaydedildi != null)
                Kaydedildi(this, null);
            return true;
        }

        private void ucTazminat_Ihtiyat1_FocusedHacizChanged(object sender, IndexChangedEventArgs e)
        {
            if (ucTazminat_Ihtiyat1.CurrentHaciz == null)
            {
                if (ucTazminat_Ihtiyat_Taraf1.MyDataSource != null)
                    ucTazminat_Ihtiyat_Taraf1.MyDataSource.Clear();
            }
            else
            {
                ucTazminat_Ihtiyat_Taraf1.MyFoy = MyFoy;
                ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                    ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
            }
        }

        private void ucTazminat_Ihtiyat1_MyDataSourceChanged(object sender, EventArgs e)
        {
            if (ucTazminat_Ihtiyat1.CurrentHaciz != null)
            {
                ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                    ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
            }
        }

        #region IslemMethods
        
        private void IslemTamamlandi()
        {
            if (Save())
            {
                if (KlasorIcin)
                    this.DialogResult = DialogResult.OK;
                else
                    this.Close();
            }

            else
            {
                XtraMessageBox.Show
                    ("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayýt",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion IslemMethods

        #region OverrideMethods

        //public override void Kaydet()
        //{
        //    base.Kaydet();
        //    IslemTamamlandi();
        //}
        //public override void Cikis()
        //{
        //    base.Cikis();
        //    DosyadanCikis();
        //}

        #endregion OverrideMethods
    }
}