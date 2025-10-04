using System;
using System.ComponentModel;
using System.Text;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucAraKarar : AvpXUserControl
    {

        public ucAraKarar()
        {
            this.Load += ucAraKarar_Load;
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        #region Properties

        private TList<AV001_TD_BIL_ARA_KARAR> _MyDataSource;

        public TList<AV001_TD_BIL_ARA_KARAR> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    if (MyDataSource == null)
                    {
                        if (value.AV001_TD_BIL_ARA_KARARCollection == null || value.AV001_TD_BIL_ARA_KARARCollection.Count == 0)
                            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>));
                        MyDataSource = value.AV001_TD_BIL_ARA_KARARCollection;
                    }
                }
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        #endregion

        #region Events

        private void ucAraKarar_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            this.gridDavaAraKarar.ButtonClick += gridDavaAraKarar_ButtonClick;
            if (MyType == ViewType.GridView)
            {
                panelControl1.Visible = false;
                gridDavaAraKarar.Visible = true;
            }
            if (MyType == ViewType.LayoutView)
            {
                panelControl1.Visible = false;
                gridDavaAraKarar.Visible = false;
            }
            if (MyType == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                gridDavaAraKarar.Visible = false;
            }
            if (!this.DesignMode)
            {
                gridDavaAraKarar.ShowOnlyPredefinedDetails = true;
                AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(rlueAdliye);
                AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(rlueAdliGorev);
                AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rlueAdliNo);
                AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(rlueFoyDurum);
                BelgeUtil.Inits.GorevTipGetir(rlueGorevtip);
                BelgeUtil.Inits.KimYerineGetirecekEnumGetir(rlueKimYerGet);
                BelgeUtil.Inits.AraKararKodTipGetir(rlueAraKararTipGetir);
                BelgeUtil.Inits.AraKararKodTipGetir(rlueAraKararTip);
                BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKimID);
                BelgeUtil.Inits.SubeKodGetir(rlueSubeKodID);
                BindData();
            }
        }

        private void gridDavaAraKarar_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                rfrmAraKararKayit frm = new rfrmAraKararKayit();
                frm.IsModul = false;
                frm.Show(MyFoy);
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
            }
            else if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                rfrmAraKararKayit frm = new rfrmAraKararKayit();
                TList<AV001_TD_BIL_ARA_KARAR> DvList = new TList<AV001_TD_BIL_ARA_KARAR>();
                DvList.Add(DataRepository.AV001_TD_BIL_ARA_KARARProvider.GetByID(((TList<AV001_TD_BIL_ARA_KARAR>)vgAraKarar.DataSource)[vgAraKarar.FocusedRecord].ID));
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
                frm.FormClosed += frm_FormClosed;
            }
        }

        private void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            BindData();
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR karar = new AV001_TD_BIL_ARA_KARAR();
            karar.KAYIT_TARIHI = DateTime.Today;
            karar.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            karar.KONTROL_KIM = "AVUKATPRO";
            karar.KONTROL_NE_ZAMAN = DateTime.Today;
            karar.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            karar.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            karar.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            karar.KIM_YERINE_GETIRECEK = 0;
            karar.ColumnChanged += karar_ColumnChanged;
            e.NewObject = karar;
        }

        private void karar_ColumnChanged(object sender, AV001_TD_BIL_ARA_KARAREventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR krr = sender as AV001_TD_BIL_ARA_KARAR;
            if (e.Column == AV001_TD_BIL_ARA_KARARColumn.YERINE_GETIRME_GUN)
            {
                if (krr.TIP != (int)AraKararTip.Mehilsiz)
                {
                    DateTime trh = krr.TARIH;
                    int gun = 0;
                    gun = Convert.ToInt32(e.Value);
                    DateTime yeniTarih = new DateTime();
                    yeniTarih = trh.AddDays(Convert.ToDouble(gun));
                    krr.YERINE_GETIRME_TARIH = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.HSonuOnemliGunKontrol(yeniTarih);
                }
            }
            else if (e.Column == AV001_TD_BIL_ARA_KARARColumn.TIP)
            {
                if ((int)e.Value == (int)AraKararTip.Mehilsiz)
                {
                    rowYERINE_GETIRME_GUN.Visible = false;
                    rowYERINE_GETIRME_TARIH.Visible = false;
                }
                else
                {
                    rowYERINE_GETIRME_GUN.Visible = true;
                    rowYERINE_GETIRME_TARIH.Visible = true;
                }
            }
        }

        private void rlueAraKararTip_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //TARIH         :  25 Eylül 2009 Cuma
            //KODU YAZAN    :  Mehmet Emin AYDOÐDU
            //NEDENI        :  Kullanýcý Tarafýndan Ara Karar Tip Eklenmesi
            //Mehmet Start
            LookUpEdit lue = (LookUpEdit)sender;

            if ((e.Button.Tag as string) == "AraKararEkle" && lue.Text != "")
            {
                TD_KOD_ARA_KARAR_TIP tip = new TD_KOD_ARA_KARAR_TIP();
                tip.KONTROL_NE_ZAMAN = DateTime.Now;
                tip.KONTROL_KIM = AvukatProLib.Kimlik.Bilgi.KULLANICI_ADI;
                tip.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                tip.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                tip.ARA_KARAR_TIP = lue.Text;
                DataRepository.TD_KOD_ARA_KARAR_TIPProvider.Insert(tip);
                BelgeUtil.Inits._AraKararKodTipGetir.Add(BelgeUtil.Inits.GetAraKararViewItem(tip));
                BelgeUtil.Inits.AraKararKodTipGetir(rlueAraKararTip);
                XtraMessageBox.Show("Ara Karar baþarýyla eklenmiþtir.");
            }

            //Mehmet End
        }

        #endregion

        #region Methods

        public void BindData()
        {
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource != null)
                MyDataSource.AddingNew += new AddingNewEventHandler(MyDataSource_AddingNew);//Kayýt iþlemi sýrasýnda columnchange event'ýna girmesini saðlamak için eklendi. MB

            if (MyFoy != null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>));
                MyDataSource = MyFoy.AV001_TD_BIL_ARA_KARARCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.DesignMode && IsLoaded)
            {
                dataNavigatorExtended1.DataSource = MyDataSource;
                vgAraKarar.DataSource = MyDataSource;
                gridDavaAraKarar.DataSource = MyDataSource;
            }
        }

        public static string Validate(AV001_TD_BIL_ARA_KARAR row)
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }

        #endregion
    }
}