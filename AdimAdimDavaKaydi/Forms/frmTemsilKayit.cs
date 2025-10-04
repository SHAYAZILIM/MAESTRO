using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

//using System.Text.RegularExpressions;

namespace AdimAdimDavaKaydi
{
    public partial class frmTemsilKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Constructor

        public frmTemsilKayit()
        {
            InitializeComponent();
            InitializeEvents();
        }

        #endregion Constructor

        #region Properties

        private TList<AV001_TDI_BIL_TEMSIL> _myDataSource;
        private AV001_TD_BIL_FOY _MyDavaFoy;
        private AV001_TD_BIL_FOY_TARAF _MyDavaTaraf;
        private AV001_TI_BIL_FOY _MyFoy;
        private AV001_TD_BIL_HAZIRLIK _MySorusturmaFoy;
        private AV001_TD_BIL_HAZIRLIK_TARAF _MySorusturmaTaraf;
        private AV001_TDI_BIL_SOZLESME _MySozlesmeFoy;
        private AV001_TDI_BIL_SOZLESME_TARAF _MySozlesmeTaraf;
        private AV001_TI_BIL_FOY_TARAF _MyTaraf;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_TEMSIL> MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;

                ucTemsilBilgileri1.MyDataSource = value;
                value.AddingNew += value_AddingNew;

                //value.AddNew();
                if (value.Count > 0)
                {
                    #region <MB-20101002> Düzenleme modunda Taraf ve Avukat Gelmesi için eklendi.

                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>),
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>));

                    #endregion <MB-20101002> Düzenleme modunda Taraf ve Avukat Gelmesi için eklendi.

                    ucTemsilTaraf1.MyDataSource = value[0].AV001_TDI_BIL_TEMSIL_TARAFCollection;
                    ucTemsilAvukat2.MyDataSource = value[0].AV001_TDI_BIL_TEMSIL_AVUKATCollection;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return _MyDavaFoy; }
            set { _MyDavaFoy = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_FOY_TARAF MyDavaTaraf
        {
            get { return _MyDavaTaraf; }
            set { _MyDavaTaraf = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _MyFoy; }
            set { _MyFoy = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_HAZIRLIK MySorusturmaFoy
        {
            get { return _MySorusturmaFoy; }
            set { _MySorusturmaFoy = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_HAZIRLIK_TARAF MySorusturmaTaraf
        {
            get { return _MySorusturmaTaraf; }
            set { _MySorusturmaTaraf = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME MySozlesmeFoy
        {
            get { return _MySozlesmeFoy; }
            set { _MySozlesmeFoy = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME_TARAF MySozlesmeTaraf
        {
            get { return _MySozlesmeTaraf; }
            set { _MySozlesmeTaraf = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF MyTaraf
        {
            get { return _MyTaraf; }
            set { _MyTaraf = value; }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMSIL addnew = new AV001_TDI_BIL_TEMSIL();
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            addnew.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            addnew.TEMSIL_SEKIL_ID = 1;
            addnew.TEMSIL_TUR_ID = 1;
            addnew.ADLI_BIRIM_GOREV_ID = 31;
            string strRefNo = "V" + "-" + DateTime.Today.Year + "~" +
                              System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
            addnew.DOSYA_NO = strRefNo;
            addnew.YEKTI_KULLANMA_SEKLI = (byte?)TemsilYetkiKullanmaSekli.Tek_Baþýna;
            addnew.SULH_VAR_MI = true;
            addnew.FERAGAT_VAR_MI = true;
            addnew.AHZU_KABZ_VAR_MI = true;
            addnew.KABUL_VAR_MI = true;
            addnew.TEVKIL_VAR_MI = true;
            addnew.IBRA_VAR_MI = true;
            ucTemsilTaraf1.MyDataSource = addnew.AV001_TDI_BIL_TEMSIL_TARAFCollection;
            ucTemsilAvukat2.MyDataSource = addnew.AV001_TDI_BIL_TEMSIL_AVUKATCollection;
            e.NewObject = addnew;
        }

        #endregion Properties

        #region Events

        public void Show(AV001_TD_BIL_FOY_TARAF trf, AV001_TD_BIL_FOY foy)
        {
            _MyDavaFoy = foy;
            _MyDavaTaraf = trf;
            TarafIsleByDava();

            // .MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public void Show(AV001_TI_BIL_FOY_TARAF trf, AV001_TI_BIL_FOY foy)
        {
            _MyFoy = foy;
            _MyTaraf = trf;
            TarafIsle();

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        public DialogResult ShowDialog(AV001_TD_BIL_HAZIRLIK_TARAF trf, AV001_TD_BIL_HAZIRLIK foy)
        {
            _MySorusturmaFoy = foy;
            _MySorusturmaTaraf = trf;
            TarafIsleBySorusturma();

            //MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
            //.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(AV001_TDI_BIL_SOZLESME_TARAF trf, AV001_TDI_BIL_SOZLESME foy)
        {
            _MySozlesmeFoy = foy;
            _MySozlesmeTaraf = trf;
            TarafIsleBySozlesme();

            //MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(AV001_TD_BIL_FOY_TARAF trf, AV001_TD_BIL_FOY foy)
        {
            _MyDavaFoy = foy;
            _MyDavaTaraf = trf;
            TarafIsleByDava();

            // .MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(AV001_TI_BIL_FOY_TARAF trf, AV001_TI_BIL_FOY foy)
        {
            _MyFoy = foy;
            _MyTaraf = trf;
            TarafIsle();

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            #region

            //try
            //{
            //    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            //    tran.BeginTransaction();
            //    if (MyDavaFoy == null && MyFoy == null && MySorusturmaFoy == null && MySozlesmeFoy == null)
            //    {
            //        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepSave(tran, MyDataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>), typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>));
            //    }
            //    else
            //    {
            //        MyDataSource = ucTemsilBilgileri1.MyDataSource;
            //        AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepSave(tran, MyDataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>), typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>));
            //    }
            //    tran.Commit();

            //    //DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepSave(ucTemsilTaraf1.MyDataSource);
            //    //DataRepository.AV001_TDI_BIL_TEMSIL_AVUKATProvider.DeepSave(ucTemsilAvukat2.MyDataSource);
            //    MessageBox.Show("Dosya Kaydedildi...", "Temsil Kayýt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //this.DialogResult = dr;
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    BelgeUtil.ErrorHandler.Catch(this, ex, true); //TODO:False olucak Pencere çýkartma...
            //    MessageBox.Show("Bir yada birden fazla kayýtta sorun var lütfen düzelterek tekrar deneyiniz", "Temsil Kayýt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            #endregion Events

            try
            {
                TList<AV001_TDI_BIL_TEMSIL> temsil = ucTemsilBilgileri1.MyDataSource;

                for (int rowHandle = 0; rowHandle < ucTemsilBilgileri1.lueBelge.Properties.View.RowCount; rowHandle++)
                {
                    if ((bool)ucTemsilBilgileri1.lueBelge.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                    {
                        temsil[0].NN_BELGE_TEMSILCollection.Add(new NN_BELGE_TEMSIL() { BELGE_ID = (int)ucTemsilBilgileri1.lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id") });
                    }
                }

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepSave(ucTemsilBilgileri1.MyDataSource);

                //object o = ucTemsilBilgileri1.MyDataSourceExtendedBySozlesme;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex, true); //TODO:False olucak Pencere çýkartma...
                MessageBox.Show("Bir yada birden fazla kayýtta sorun var lütfen düzelterek tekrar deneyiniz",
                                "Temsil Kayýt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTemsilKayit_Closing(object sender, CancelEventArgs e)
        {
            if (_MyTaraf != null)
                _MyTaraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection = ucTemsilBilgileri1.MyDataSourceExtended;
            if (_MyDavaTaraf != null)
                _MyDavaTaraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection = ucTemsilBilgileri1.MyDataSourceExtendedByDava;
            if (_MySorusturmaTaraf != null)
                _MySorusturmaTaraf.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection =
                    ucTemsilBilgileri1.MyDataSourceExtendedBySorusturma;
            if (_MySozlesmeTaraf != null)
                _MySozlesmeTaraf.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection =
                    ucTemsilBilgileri1.MyDataSourceExtendedBySozlesme;
        }

        private void frmTemsilKayit_Load(object sender, EventArgs e)
        {
            //MB: Düzenleme modunda bilgilerin gelebilmesi için && operatörü || ile deðiþtirildi.
            if (MyDavaFoy == null || MyFoy == null || MySorusturmaFoy == null || MySozlesmeFoy == null)
            {
                if (MyDataSource == null) //MB: Düzenleme modunda Seçilen Vekalet bilgilerinin gelmesi için eklendi.
                    MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
            }
            this.ucTemsilBilgileri1.MyDataSourceChanged += ucTemsilBilgileri1_MyDataSourceChanged;
            this.ucTemsilBilgileri1.CurrentTEMSILChanged += ucTemsilBilgileri1_MyDataSourceChanged;
            this.Closing += frmTemsilKayit_Closing;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnTamam_Click;
        }

        private void TarafIsle()
        {
            DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(_MyTaraf, false, DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
            if (_MyTaraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection == null)
                _MyTaraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            ucTemsilBilgileri1.MyDataSourceExtended = _MyTaraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection;
            if (_MyTaraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection != null)
            {
                TList<AV001_TDI_BIL_TEMSIL_TARAF> temsil_TARAFS =
                    DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.GetByTARAF_CARI_ID(MyTaraf.CARI_ID);
                DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(temsil_TARAFS, true,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_TEMSIL));
                TList<AV001_TDI_BIL_TEMSIL> temsils = new TList<AV001_TDI_BIL_TEMSIL>();
                temsil_TARAFS.ForEach(delegate(AV001_TDI_BIL_TEMSIL_TARAF obj) { temsils.Add(obj.TEMSIL_IDSource); }
                    );
                temsils.Filter = "TEMSIL_SEKIL_ID = 1"; //Önce Vekaletname olanlarý buluyoruz...
                if (temsils.Count > 0)
                {
                    temsils.Sort("TARIHI DESC");
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                    if (ucTemsilBilgileri1.MyDataSource.Count == 0)
                    {
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                    }
                    ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    MyDataSource = temsils;
                }
                else
                {
                    temsils.Filter = String.Empty;
                    if (temsils.Count > 0)
                    {
                        temsils.Sort("TARIHI DESC");
                        DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                        ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    }
                    else
                        MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
                }
            }
        }

        private void TarafIsleByDava()
        {
            if (_MyDavaTaraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection == null)
                _MyDavaTaraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection = new TList<AV001_TD_BIL_FOY_TARAF_VEKIL>();

            ucTemsilBilgileri1.MyDataSourceExtendedByDava = _MyDavaTaraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection;
            if (_MyDavaTaraf.AV001_TD_BIL_FOY_TARAF_VEKILCollection != null)
            {
                TList<AV001_TDI_BIL_TEMSIL_TARAF> temsil_TARAFS =
                    DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.GetByTARAF_CARI_ID(_MyDavaTaraf.CARI_ID);
                DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(temsil_TARAFS, true,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_TEMSIL));
                TList<AV001_TDI_BIL_TEMSIL> temsils = new TList<AV001_TDI_BIL_TEMSIL>();
                temsil_TARAFS.ForEach(delegate(AV001_TDI_BIL_TEMSIL_TARAF obj) { temsils.Add(obj.TEMSIL_IDSource); }
                    );
                temsils.Filter = "TEMSIL_SEKIL_ID = 1"; //Önce Vekaletname olanlarý buluyoruz...
                if (temsils.Count > 0)
                {
                    temsils.Sort("TARIHI DESC");
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                    if (ucTemsilBilgileri1.MyDataSource.Count == 0)
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                    ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    MyDataSource = temsils;
                }
                else
                {
                    temsils.Filter = String.Empty;
                    if (temsils.Count > 0)
                    {
                        temsils.Sort("TARIHI DESC");
                        DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                        ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    }
                    else
                        MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
                }
            }
        }

        private void TarafIsleBySorusturma()
        {
            if (_MySorusturmaTaraf.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection == null)
                _MySorusturmaTaraf.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection =
                    new TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>();

            ucTemsilBilgileri1.MyDataSourceExtendedBySorusturma =
                _MySorusturmaTaraf.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection;
            if (_MySorusturmaTaraf.AV001_TD_BIL_HAZIRLIK_TARAF_VEKILCollection != null)
            {
                TList<AV001_TDI_BIL_TEMSIL_TARAF> temsil_TARAFS =
                    DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.GetByTARAF_CARI_ID(MySorusturmaTaraf.CARI_ID);
                DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(temsil_TARAFS, true,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_TEMSIL));
                TList<AV001_TDI_BIL_TEMSIL> temsils = new TList<AV001_TDI_BIL_TEMSIL>();
                temsil_TARAFS.ForEach(delegate(AV001_TDI_BIL_TEMSIL_TARAF obj) { temsils.Add(obj.TEMSIL_IDSource); }
                    );
                temsils.Filter = "TEMSIL_SEKIL_ID = 1"; //Önce Vekaletname olanlarý buluyoruz...
                if (temsils.Count > 0)
                {
                    temsils.Sort("TARIHI DESC");
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                    if (ucTemsilBilgileri1.MyDataSource.Count == 0)
                    {
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                    }
                    ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    MyDataSource = temsils;
                }
                else
                {
                    temsils.Filter = String.Empty;
                    if (temsils.Count > 0)
                    {
                        temsils.Sort("TARIHI DESC");
                        DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                        ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    }
                    else
                        MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
                }
            }
        }

        private void TarafIsleBySozlesme()
        {
            if (_MySozlesmeTaraf.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection == null)
                _MySozlesmeTaraf.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection =
                    new TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL>();

            ucTemsilBilgileri1.MyDataSourceExtendedBySozlesme =
                _MySozlesmeTaraf.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection;
            if (_MySozlesmeTaraf.AV001_TDI_BIL_SOZLESME_TARAF_VEKILCollection != null)
            {
                TList<AV001_TDI_BIL_TEMSIL_TARAF> temsil_TARAFS =
                    DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.GetByTARAF_CARI_ID(_MySozlesmeTaraf.CARI_ID);
                DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(temsil_TARAFS, true,
                                                                           DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_TEMSIL));
                TList<AV001_TDI_BIL_TEMSIL> temsils = new TList<AV001_TDI_BIL_TEMSIL>();
                temsil_TARAFS.ForEach(delegate(AV001_TDI_BIL_TEMSIL_TARAF obj) { temsils.Add(obj.TEMSIL_IDSource); }
                    );
                temsils.Filter = "TEMSIL_SEKIL_ID = 1"; //Önce Vekaletname olanlarý buluyoruz...
                if (temsils.Count > 0)
                {
                    temsils.Sort("TARIHI DESC");
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                         typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                    if (ucTemsilBilgileri1.MyDataSource.Count == 0)
                    {
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                    }
                    ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    MyDataSource = temsils;
                }
                else
                {
                    temsils.Filter = String.Empty;
                    if (temsils.Count > 0)
                    {
                        temsils.Sort("TARIHI DESC");
                        DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(temsils[0], true,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                        ucTemsilBilgileri1.MyDataSource.Add(temsils[0]);
                        ucTemsilBilgileri1_MyDataSourceChanged(null, new EventArgs());
                    }
                    else
                        MyDataSource = new TList<AV001_TDI_BIL_TEMSIL>();
                }
            }
        }

        private void ucTemsilBilgileri1_MyDataSourceChanged(object sender, EventArgs e)
        {
            if (ucTemsilBilgileri1.CurrentTEMSIL != null)
            {
                if (ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_TARAFCollection == null)
                {
                    ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_TARAFCollection =
                        new TList<AV001_TDI_BIL_TEMSIL_TARAF>();
                }
                if (ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_AVUKATCollection == null)
                {
                    ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_AVUKATCollection =
                        new TList<AV001_TDI_BIL_TEMSIL_AVUKAT>();
                }
                ucTemsilTaraf1.MyDataSource = ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_TARAFCollection;
                ucTemsilAvukat2.MyDataSource = ucTemsilBilgileri1.CurrentTEMSIL.AV001_TDI_BIL_TEMSIL_AVUKATCollection;
            }

            //ucTemsilBilgileri1.MyDataSource.ListChanged += new ListChangedEventHandler(ucTemsilBilgileri1_MyDataSourceChanged);
        }

        #endregion

        #region Methots

        #endregion

        #region Show & ShowDialog

        #endregion
    }
}