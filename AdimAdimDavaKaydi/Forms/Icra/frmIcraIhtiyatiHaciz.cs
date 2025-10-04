using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmIcraIhtiyatiHaciz : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraIhtiyatiHaciz()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosed += frmIcraIhtiyatiHaciz_FormClosed;
            this.Load += frmIcraIhtiyatiHaciz_Load;
        }

        public bool DosyaKayitEkranindanmi;
        private TList<AV001_TI_BIL_IHTIYATI_HACIZ> _MyDataSource;
        private bool isModul;

        private bool kaydedildi;

        public event EventHandler<IhtiyatiHacizEventArgs> KayitYapildi;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource
        {
            get
            {
                return _MyDataSource; //ucTazminat_Ihtiyat1.MyDataSource;
            }
            set
            {
                _MyDataSource = value;

                if (_MyDataSource == null)
                {
                    _MyDataSource = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
                    _MyDataSource.AddNew();
                }
                else
                {
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
                }
                foreach (AV001_TI_BIL_IHTIYATI_HACIZ_TARAF item in _MyDataSource[0].AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection)
                {
                    item.ICRA_FOY_ID = MyFoy.ID;
                }
                ucTazminat_Ihtiyat1.MyDataSource = _MyDataSource;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        private void frmIcraIhtiyatiHaciz_Button_Kaydet_Click(object sender, EventArgs e)
        {
            IslemTamamlandi();

            //if (MyFoy != null && DosyaKayitEkranindanmi) AYKUT KALDIRDI
            if (MyFoy != null)
            {
                foreach (var item in MyDataSource)
                {
                    item.ICRA_FOY_ID = MyFoy.ID;
                }
            }

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            tran.BeginTransaction();
            DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(tran, MyDataSource, DeepSaveType.IncludeChildren,
                                                                        typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>
                                                                            ));
            foreach (var item in MyDataSource)
            {
                foreach (var mektup in ucTazminat_Ihtiyat1.MyDataSourceTeminat)
                {
                    if (mektup.IHTIYATI_HACIZ_ID == null)
                        mektup.IHTIYATI_HACIZ_ID = item.ID;
                    if (MyFoy != null)
                        mektup.ICRA_FOY_ID = MyFoy.ID;
                }
            }
            DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.Save(tran, ucTazminat_Ihtiyat1.MyDataSourceTeminat);

            tran.Commit();

            ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);

            if (KayitYapildi != null)
                KayitYapildi(this, new IhtiyatiHacizEventArgs(MyDataSource[0]));
            kaydedildi = true;

            this.Close();
        }

        private void frmIcraIhtiyatiHaciz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection[0].ID == 0)
                MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection.RemoveAt(0);

            if (MyGelisme == null)
            {
                return;
            }

            if (kaydedildi)
                ucIcraTarafGelismeleri.IhtiyatiHacizHesapla(MyGelisme, MyFoy);
        }

        private void frmIcraIhtiyatiHaciz_Load(object sender, EventArgs e)
        {
            if (isModul)
            {
                lueModul.Properties.NullText = "Seç";
                lueModul.Enter += BelgeUtil.Inits.ModulKodGetir_Enter;
                ucTazminat_Ihtiyat1.Enabled = false;
                ucTazminat_Ihtiyat_Taraf1.Enabled = false;
            }

            else
            {
                //deneme amaçlı ekledim
                if (ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection == null)
                {
                    ucTazminat_Ihtiyat_Taraf1.MyDataSource = new TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>();
                    ucTazminat_Ihtiyat_Taraf1.MyDataSource.AddNew();
                }
                else
                {
                    ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                        ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
                }
            }
        }

        private void glueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if ((int)lueModul.EditValue == (int)AvukatProLib.Extras.ModulTip.Icra)
            {
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
                MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;
            }
            ucTazminat_Ihtiyat1.Enabled = true;
            ucTazminat_Ihtiyat_Taraf1.Enabled = true;
            MyDataSource = null;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIcraIhtiyatiHaciz_Button_Kaydet_Click;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            glueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
            glueDosya.Properties.DisplayMember = "FOY_NO";
            glueDosya.Properties.ValueMember = "ID";
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_IHTIYATI_HACIZ hcz = new AV001_TI_BIL_IHTIYATI_HACIZ();
            hcz.ADLI_BIRIM_GOREV_ID =
                DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.Get("GOREV = 'AHM'", "GOREV DESC")[0].ID;

            //Find("GOREV = 'AHM'")[0].ID;

            hcz.TALEP_TARIHI = MyFoy.TAKIP_TARIHI;
            hcz.KARAR_TARIHI = hcz.TALEP_TARIHI;
            hcz.TEMINAT_TURU_ID = 1; //NAKİT
            hcz.TEMINAT_TUTARI_DOVIZ_ID = 1;

            hcz.TEMINAT_TUTARI = MyFoy.ASIL_ALACAK * (decimal)0.10; // TODO:Kullanİcİ seçenekleri.. Oransal
            hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection = new TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>();

            //if (MyFoy != null)
            //{
            foreach (AV001_TI_BIL_FOY_TARAF taraf in ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy))
            {
                AV001_TI_BIL_IHTIYATI_HACIZ_TARAF trf = hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection.AddNew();
                trf.ICRA_CARI_TARAF_ID = taraf.CARI_ID;
                trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            }
            ucTazminat_Ihtiyat_Taraf1.MyFoy = MyFoy;
            ucTazminat_Ihtiyat_Taraf1.MyDataSource = hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;

            //}
            //else
            //    ucTazminat_Ihtiyat_Taraf1.MyDataSource = hcz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;

            hcz.KAYIT_TARIHI = DateTime.Now;
            hcz.KONTROL_NE_ZAMAN = DateTime.Now;
            hcz.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            hcz.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            hcz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            hcz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            //if (ucTazminat_Ihtiyat1.MyDataSource == null)
            //    ucTazminat_Ihtiyat1.MyDataSource = MyDataSource;
            e.NewObject = hcz;
        }

        private void ucTazminat_Ihtiyat1_FocusedHacizChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex >= 0)
                ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                    MyDataSource[e.NewIndex].AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
        }

        private void ucTazminat_Ihtiyat1_MyDataSourceChanged(object sender, EventArgs e)
        {
            if (ucTazminat_Ihtiyat1.CurrentHaciz != null)
            {
                if (MyFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, true, DeepLoadType.IncludeChildren,
                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                }
                ucTazminat_Ihtiyat_Taraf1.MyFoy = MyFoy;
                ucTazminat_Ihtiyat_Taraf1.MyDataSource =
                    ucTazminat_Ihtiyat1.CurrentHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
            }
        }

        #region IslemMethods

        private void IslemTamamlandi()
        {
            string error = string.Empty;
            foreach (AV001_TI_BIL_IHTIYATI_HACIZ teki in MyDataSource)
            {
                #region Hata Kontrolleri (gkn)

                if (!teki.KARAR_TARIHI.HasValue)
                {
                    error += string.Format("{0} Esas Nolu Kaydın Karar Tarihi Girilmelidir {1}", teki.ESAS_NO,
                                           Environment.NewLine);
                }
                if (!teki.TALEP_TARIHI.HasValue)
                {
                    error += string.Format("{0} Esas Nolu Kaydın Talep Tarihi Girilmelidir {1}", teki.ESAS_NO,
                                           Environment.NewLine);
                }
                if (teki.ADLI_BIRIM_ADLIYE_ID == 0)
                    error += string.Format("{0} Esas Nolu Kaydın Adliye Bilgisi Girilmelidir {1}", teki.ESAS_NO,
                                           Environment.NewLine);

                if (teki.ADLI_BIRIM_GOREV_ID == 0)
                    error += string.Format("{0} Esas Nolu Kaydın Görev Bilgisi Girilmelidir {1}", teki.ESAS_NO,
                                           Environment.NewLine);

                #endregion Hata Kontrolleri (gkn)
            }
            if (error == string.Empty)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                XtraMessageBox.Show(error, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    public class IhtiyatiHacizEventArgs : EventArgs
    {
        public IhtiyatiHacizEventArgs(AV001_TI_BIL_IHTIYATI_HACIZ myIhtHcz)
        {
            MyIhtHcz = myIhtHcz;
        }

        public AV001_TI_BIL_IHTIYATI_HACIZ MyIhtHcz { get; set; }
    }
}