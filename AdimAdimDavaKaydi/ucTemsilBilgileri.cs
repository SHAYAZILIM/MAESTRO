using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.Belge.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class ucTemsilBilgileri : XtraUserControl
    {
        #region Fields

        public TList<AV001_TI_BIL_FOY_TARAF_VEKIL> _MyOldVekils = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();
        public TList<AV001_TD_BIL_FOY_TARAF_VEKIL> _MyOldVekilsDava = new TList<AV001_TD_BIL_FOY_TARAF_VEKIL>();

        public TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL> _MyOldVekilsSorusturma =
            new TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>();

        public TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL> _MyOldVekilsSozlesme =
            new TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL>();

        #endregion Fields

        #region Constructors

        public ucTemsilBilgileri()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        public event EventHandler CurrentTEMSILChanged;

        public event EventHandler MyDataSourceChanged;

        #endregion Events

        #region Properties

        public AV001_TDI_BIL_TEMSIL CurrentTEMSIL
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (dataNavigatorExtended1.Position > -1)
                {
                    return MyDataSource[dataNavigatorExtended1.Position];
                }
                else
                {
                    return null;
                }
            }
        }

        public TList<AvukatProLib2.Entities.AV001_TDI_BIL_TEMSIL> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return (TList<AV001_TDI_BIL_TEMSIL>)vgTemsil.DataSource;
            }
            set
            {
                if (DesignMode || value == null)
                {
                    return;
                }
                vgTemsil.DataSource = value;
                gridControl1.DataSource = value;
                if (value != null)
                    value.AddingNew += value_AddingNew;
                if (MyDataSourceChanged != null)
                {
                    MyDataSourceChanged(this, new EventArgs());
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_TARAF_VEKIL> MyDataSourceExtended
        {
            get
            {
                if (this.DesignMode) return null;

                TList<AV001_TI_BIL_FOY_TARAF_VEKIL> result = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

                foreach (AV001_TDI_BIL_TEMSIL temsil in MyDataSource)
                {
                    foreach (AV001_TDI_BIL_TEMSIL_AVUKAT avukat in temsil.AV001_TDI_BIL_TEMSIL_AVUKATCollection)
                    {
                        AV001_TI_BIL_FOY_TARAF_VEKIL o = result.AddNew();
                        o.AVUKAT_CARI_ID = avukat.AVUKAT_CARI_ID;
                        o.AVUKAT_CARI_IDSource = avukat.AVUKAT_CARI_IDSource;
                        o.TEMSIL_ID = temsil.ID;
                        o.TEMSIL_IDSource = temsil;
                        o.TEMSIL_SEKLI_ID = temsil.TEMSIL_SEKIL_ID;
                        o.TEMSIL_SEKLI_IDSource = temsil.TEMSIL_SEKIL_IDSource;
                    }
                }

                //result.AddRange(_MyOldVekils);
                return result;
            }
            set
            {
                if (value == null || this.DesignMode)
                    return;

                TList<AV001_TDI_BIL_TEMSIL> result = new TList<AV001_TDI_BIL_TEMSIL>();
                foreach (AV001_TI_BIL_FOY_TARAF_VEKIL vekil in value)
                {
                    if (vekil.TEMSIL_IDSource == null && vekil.TEMSIL_ID.HasValue)
                    {
                        //Burda yapýlan bir hata düzeltildi daha önce Temsil Sekil Id ye göre getiriliyordu..
                        vekil.TEMSIL_IDSource =
                            DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekil.TEMSIL_ID.Value);
                        DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(vekil.TEMSIL_IDSource, true,
                                                                             DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_AVUKAT>),
                                                                             typeof(TList<AV001_TDI_BIL_TEMSIL_TARAF>));
                    }

                    if (vekil.TEMSIL_IDSource != null)
                        result.Add(vekil.TEMSIL_IDSource);
                    else
                    {
                        _MyOldVekils.Add(vekil);
                    }
                }
                MyDataSource = result;
            }
        }

        [Browsable(false)]
        public TList<AV001_TD_BIL_FOY_TARAF_VEKIL> MyDataSourceExtendedByDava
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                TList<AV001_TD_BIL_FOY_TARAF_VEKIL> result = new TList<AV001_TD_BIL_FOY_TARAF_VEKIL>();

                foreach (AV001_TDI_BIL_TEMSIL temsil in MyDataSource)
                {
                    foreach (AV001_TDI_BIL_TEMSIL_AVUKAT avukat in temsil.AV001_TDI_BIL_TEMSIL_AVUKATCollection)
                    {
                        AV001_TD_BIL_FOY_TARAF_VEKIL o = result.AddNew();
                        o.AVUKAT_CARI_ID = avukat.AVUKAT_CARI_ID;
                        o.AVUKAT_CARI_IDSource = avukat.AVUKAT_CARI_IDSource;
                        o.TEMSIL_ID = temsil.ID;
                        o.TEMSIL_IDSource = temsil;
                        o.TEMSIL_SEKLI_ID = temsil.TEMSIL_SEKIL_ID;
                        o.TEMSIL_SEKLI_IDSource = temsil.TEMSIL_SEKIL_IDSource;
                    }
                }

                //result.AddRange(_MyOldVekilsDava);
                return result;
            }
            set
            {
                if (value == null || DesignMode)
                    return;

                TList<AV001_TDI_BIL_TEMSIL> result = new TList<AV001_TDI_BIL_TEMSIL>();
                foreach (AV001_TD_BIL_FOY_TARAF_VEKIL vekil in value)
                {
                    if (vekil.TEMSIL_IDSource == null && vekil.TEMSIL_ID.HasValue)
                    {
                        vekil.TEMSIL_IDSource =
                            DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekil.TEMSIL_SEKLI_ID.Value);
                    }
                    if (vekil.TEMSIL_IDSource != null)
                        result.Add(vekil.TEMSIL_IDSource);
                    else
                    {
                        _MyOldVekilsDava.Add(vekil);
                    }
                }
                MyDataSource = result;
            }
        }

        [Browsable(false)]
        public TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL> MyDataSourceExtendedBySorusturma
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL> result = new TList<AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL>();
                foreach (AV001_TDI_BIL_TEMSIL temsil in MyDataSource)
                {
                    foreach (AV001_TDI_BIL_TEMSIL_AVUKAT avukat in temsil.AV001_TDI_BIL_TEMSIL_AVUKATCollection)
                    {
                        AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL vekil = result.AddNew();
                        vekil.AVUKAT_CARI_ID = avukat.AVUKAT_CARI_ID;
                        vekil.AVUKAT_CARI_IDSource = avukat.AVUKAT_CARI_IDSource;
                        vekil.TEMSIL_ID = temsil.ID;
                        vekil.TEMSIL_SEKLI_ID = temsil.TEMSIL_SEKIL_ID;
                        vekil.TEMSIL_SEKLI_IDSource = temsil.TEMSIL_SEKIL_IDSource;
                    }
                }

                //result.AddRange(_MyOldVekilsSorusturma);
                return result;
            }
            set
            {
                if (value == null || DesignMode)
                    return;
                TList<AV001_TDI_BIL_TEMSIL> result = new TList<AV001_TDI_BIL_TEMSIL>();
                foreach (AV001_TD_BIL_HAZIRLIK_TARAF_VEKIL vekil in value)
                {
                    if (vekil.TEMSIL_IDSource == null && vekil.TEMSIL_ID.HasValue)
                    {
                        vekil.TEMSIL_IDSource =
                            DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekil.TEMSIL_SEKLI_ID.Value);
                    }
                    if (vekil.TEMSIL_SEKLI_IDSource != null)
                        result.Add(vekil.TEMSIL_IDSource);
                    else
                    {
                        _MyOldVekilsSorusturma.Add(vekil);
                    }
                }
                MyDataSource = result;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL> MyDataSourceExtendedBySozlesme
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL> result = new TList<AV001_TDI_BIL_SOZLESME_TARAF_VEKIL>();
                foreach (AV001_TDI_BIL_TEMSIL temsil in MyDataSource)
                {
                    foreach (AV001_TDI_BIL_TEMSIL_AVUKAT avukat in temsil.AV001_TDI_BIL_TEMSIL_AVUKATCollection)
                    {
                        AV001_TDI_BIL_SOZLESME_TARAF_VEKIL vekil = result.AddNew();
                        vekil.AVUKAT_CARI_ID = avukat.AVUKAT_CARI_ID;
                        vekil.AVUKAT_CARI_IDSource = avukat.AVUKAT_CARI_IDSource;
                        vekil.TEMSIL_ID = temsil.ID;
                        vekil.TEMSIL_SEKLI_ID = temsil.TEMSIL_SEKIL_ID;
                        vekil.TEMSIL_SEKLI_IDSource = temsil.TEMSIL_SEKIL_IDSource;
                    }
                }

                //result.AddRange(_MyOldVekilsSozlesme);
                return result;
            }
            set
            {
                if (value == null || DesignMode)
                    return;
                TList<AV001_TDI_BIL_TEMSIL> result = new TList<AV001_TDI_BIL_TEMSIL>();
                foreach (AV001_TDI_BIL_SOZLESME_TARAF_VEKIL vekil in value)
                {
                    if (vekil.TEMSIL_IDSource == null && vekil.TEMSIL_ID.HasValue)
                    {
                        vekil.TEMSIL_IDSource =
                            DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID(vekil.TEMSIL_SEKLI_ID.Value);
                    }
                    if (vekil.TEMSIL_SEKLI_IDSource != null)
                        result.Add(vekil.TEMSIL_IDSource);
                    else
                    {
                        _MyOldVekilsSozlesme.Add(vekil);
                    }
                }
                MyDataSource = result;
            }
        }

        #endregion Properties

        #region Methods

        private void AV001_TDI_BIL_TEMSIL_AVUKATCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMSIL_AVUKAT avk = new AV001_TDI_BIL_TEMSIL_AVUKAT();
            avk.KAYIT_TARIHI = DateTime.Now;
            avk.KLASOR_KODU = "GENEL";
            avk.KONTROL_KIM = "AVUKATPRO";
            avk.KONTROL_NE_ZAMAN = DateTime.Now;
            avk.STAMP = 1;
            e.NewObject = avk;
        }

        private void AV001_TDI_BIL_TEMSIL_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMSIL_TARAF trf = new AV001_TDI_BIL_TEMSIL_TARAF();
            trf.KAYIT_TARIHI = DateTime.Now;
            trf.KLASOR_KODU = "GENEL";
            trf.KONTROL_KIM = "AVUKATPRO";
            trf.KONTROL_NE_ZAMAN = DateTime.Now;
            trf.STAMP = 1;
            e.NewObject = trf;
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                vgTemsil.Visible = true;
                gridControl1.Visible = false;
            }
            else
            {
                vgTemsil.Visible = !true;
                gridControl1.Visible = !false;
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender,
            AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
            frmTemsilKayit kyt = (frmTemsilKayit)this.FindForm();
            if (kyt.MyTaraf != null)
            {
                frmTemsilBilgisiEkle frm = new frmTemsilBilgisiEkle();
                TList<AV001_TDI_BIL_TEMSIL_TARAF> tarafs =
                    DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.GetByTARAF_CARI_ID(kyt.MyTaraf.CARI_ID);
                DataRepository.AV001_TDI_BIL_TEMSIL_TARAFProvider.DeepLoad(tarafs, true, DeepLoadType.IncludeChildren,
                                                                           typeof(AV001_TDI_BIL_TEMSIL));
                TList<AV001_TDI_BIL_TEMSIL> temsils = new TList<AV001_TDI_BIL_TEMSIL>();
                tarafs.ForEach(delegate(AV001_TDI_BIL_TEMSIL_TARAF obj)
                                   {
                                       if (obj.TEMSIL_IDSource != null)
                                           temsils.Add(obj.TEMSIL_IDSource);
                                   });

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                if (frm.ShowDialog(temsils) == DialogResult.OK)
                {
                    DataRepository.AV001_TDI_BIL_TEMSILProvider.DeepLoad(frm.MySelectedList);
                    MyDataSource.AddRange(frm.MySelectedList);
                }
            }
        }

        private void dataNavigatorExtended1_PositionChanged(object sender, EventArgs e)
        {
            if (CurrentTEMSILChanged != null)
            {
                CurrentTEMSILChanged(this, new EventArgs());
            }
        }

        private void initTemsil()
        {
            if (DesignMode)
            {
                return;
            }

            //Týklayýnca Gelecekler
            rlkADLI_BIRIM_ADLIYE_ID.NullText = "Seç";
            rlueAdliyeNo.NullText = "Seç";
            rlkEVRAK_SORUMLU_ID.NullText = "Seç";
            //Dolu gelecekler
            rlkYETKI_KULLANMA_SEKLI.NullText = "Seç";
            rlkADLI_BIRIM_GOREV_ID.NullText = "Seç";
            rlkTEMSIL_SEKIL_ID.NullText = "Seç";
            rlkTEMSIL_TUR_ID.NullText = "Seç";
            BelgeUtil.Inits.TemsilYetkiKullanmaTipiGetir(rlkYETKI_KULLANMA_SEKLI);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlkADLI_BIRIM_ADLIYE_ID);
            BelgeUtil.Inits.AdliBirimGorevGetirSadeceN(rlkADLI_BIRIM_GOREV_ID);
            
            BelgeUtil.Inits.perCariGetir(rlkEVRAK_SORUMLU_ID);
            
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlkEVRAK_SORUMLU_ID, AvukatProLib.Extras.CariStatu.Personel);

            BelgeUtil.Inits.TemsilSekliGetir(rlkTEMSIL_SEKIL_ID);
            BelgeUtil.Inits.TemsilTuruGetir(rlkTEMSIL_TUR_ID);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliyeNo);

            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(lueBelge);

            //BU KALDI rlkKULLANILACAK_SABLON_ID
        }

        private void ucTemsilBilgileri_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            if (!DesignMode)
            {
                initTemsil();
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMSIL tm = new AV001_TDI_BIL_TEMSIL();
            tm.AV001_TDI_BIL_TEMSIL_TARAFCollection = new TList<AV001_TDI_BIL_TEMSIL_TARAF>();
            tm.AV001_TDI_BIL_TEMSIL_TARAFCollection.AddingNew += AV001_TDI_BIL_TEMSIL_TARAFCollection_AddingNew;
            tm.AV001_TDI_BIL_TEMSIL_AVUKATCollection = new TList<AV001_TDI_BIL_TEMSIL_AVUKAT>();
            tm.AV001_TDI_BIL_TEMSIL_AVUKATCollection.AddingNew += AV001_TDI_BIL_TEMSIL_AVUKATCollection_AddingNew;
            tm.KAYIT_TARIHI = DateTime.Now;
            tm.KLASOR_KODU = "GENEL";
            tm.KONTROL_KIM = "AVUKATPRO";
            tm.KONTROL_NE_ZAMAN = DateTime.Now;
            tm.STAMP = 1;
            e.NewObject = tm;
        }

        private void vgTemsil_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (e.Row.Name == "rowBelge")
            {
                NN_BELGE_TEMSIL belge = new NN_BELGE_TEMSIL();
                belge.BELGE_ID = (int)e.Value;

                foreach (var item in MyDataSource)
                    item.NN_BELGE_TEMSILCollection.Add(belge);
            }
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

        #region Other

        //private DataTable GetTemsilDt()
        //{
        //    DataTable dt = new DataTable("TemsilDT");
        //    dt.Columns.Add("ID", typeof(int));
        //    dt.Columns.Add("TEMSIL_SEKIL_ID", typeof(int));
        //    dt.Columns.Add("TEMSIL_SEKIL");
        //    dt.Columns.Add("TEMSIL_TUR_ID", typeof(int));
        //    dt.Columns.Add("TEMSIL_TUR");
        //    dt.Columns.Add("DOSYA_NO");
        //    dt.Columns.Add("BELGE_SAYI_BILGISI");
        //    dt.Columns.Add("ADLI_BIRIM_ADLIYE_ID", typeof(int));
        //    dt.Columns.Add("ADLIYE");
        //    dt.Columns.Add("ADLI_BIRIM_GOREV_ID", typeof(int));
        //    dt.Columns.Add("GOREV");
        //    dt.Columns.Add("ADLI_BIRIM_NO_ID", typeof(int));
        //    dt.Columns.Add("BIRIM_NO", typeof(int));
        //    dt.Columns.Add("TARIHI");
        //    dt.Columns.Add("SENESI");
        //    dt.Columns.Add("YEVMIYE");
        //    dt.Columns.Add("SULH_VAR_MI", typeof(bool));
        //    dt.Columns.Add("FERAGAT_VAR_MI", typeof(bool));
        //    dt.Columns.Add("KABUL_VAR_MI", typeof(bool));
        //    dt.Columns.Add("AHZU_KABZ_VAR_MI", typeof(bool));
        //    dt.Columns.Add("IBRA_VAR_MI", typeof(bool));
        //    dt.Columns.Add("TEVKIL_VAR_MI", typeof(bool));
        //    dt.Columns.Add("OZEL_BELGE_ID", typeof(int));
        //    dt.Columns.Add("DOSYA_KAYITLI_MI", typeof(bool));
        //    dt.Columns.Add("KAYIT_TARIHI");
        //    dt.Columns.Add("KLASOR_KODU");
        //    dt.Columns.Add("SUBE_KODU");
        //    dt.Columns.Add("KONTROL_NE_ZAMAN");
        //    dt.Columns.Add("KONTROL_KIM");
        //    dt.Columns.Add("KONTROL_VERSIYON");
        //    dt.Columns.Add("STAMP");
        //    dt.Columns.Add("YEKTI_KULLANMA_SEKLI", typeof(int));
        //    dt.Columns.Add("KALAN_SURE");
        //    dt.Columns.Add("EVRAK_SORUMLU");
        //    dt.Columns.Add("EVRAK_SORUMLU_ID", typeof(int));
        //    dt.Columns.Add("KULLANILACAK_SABLON_ID", typeof(int));
        //    dt.Columns.Add("YETKILER");
        //    DataRow dr = dt.NewRow();
        //    dr["TEMSIL_SEKIL_ID"] = 1;
        //    dr["TEMSIL_TUR_ID"] = 1;
        //    dr["YEKTI_KULLANMA_SEKLI"] = 1;
        //    dr["TEMSIL_TUR_ID"] = 1;
        //    dt.Rows.Add(dr);
        //    return dt;
        //}

        #endregion Other
    }
}