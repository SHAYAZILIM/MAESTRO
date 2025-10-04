using System;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIhtiyatiTedbir : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Ýlgili uc klasör üzerinden ekleme yapmak için açýldýðýný belirten property.
        /// </summary>
        public bool KlasorIcin { get; set; }

        public event EventHandler MyDataSourceChanged;

        public TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> MyDataSource
        {
            get { return (TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>)vgIhtiyatiTedbir.DataSource; }
            set
            {
                vgIhtiyatiTedbir.DataSource = value;
                gridControl1.DataSource = value;
                if (MyDataSourceChanged != null)
                {
                    MyDataSourceChanged(this, new EventArgs());
                }

                TList<AV001_TDI_BIL_TEMINAT_MEKTUP> list = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.GetAll();
                if (MyDataSource != null)
                {
                    foreach (var item in MyDataSource)
                    {
                        var listim = list.Where(vi => vi.IHTIYATI_TEDBIR_ID == item.ID).ToList();
                        if (listim.Count > 0)
                        {
                            foreach (AV001_TDI_BIL_TEMINAT_MEKTUP mek in listim)
                            {
                                if (MyDataSourceTeminat == null) MyDataSourceTeminat = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                                MyDataSourceTeminat.Add(mek);

                                #region <MB-20100812>

                                //Düzenleme modunda teminat mektubu alanlarýnýn düzgün gelmesini saðlamak için eklendi.
                                mektup_ColumnChanged(this, new AV001_TDI_BIL_TEMINAT_MEKTUPEventArgs(AV001_TDI_BIL_TEMINAT_MEKTUPColumn.TEMINAT_TURU_ID, mek.TEMINAT_TURU_ID));

                                #endregion
                            }
                        }
                        else
                        {
                            MyDataSourceTeminat = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                            MyDataSourceTeminat.AddNew();
                        }
                    }
                }
            }
        }

        private void mektup_ColumnChanged(object sender, AV001_TDI_BIL_TEMINAT_MEKTUPEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_TEMINAT_MEKTUPColumn.BANKA_ID)
            {
                BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube, (int)e.Value);
            }
            if (e.Column == AV001_TDI_BIL_TEMINAT_MEKTUPColumn.TEMINAT_TURU_ID)
            {
                if ((int)e.Value == 1)//NAKÝT
                {
                    //editorRow1.Visible = true;
                    //DovizId_TeminatTutari.Visible = true;
                    //ACIKLAMA.Visible = true;
                    //MUVEKKILE_TESLIM_TARIHI.Visible = true;
                    //TESLIM_ALAN_CARI_ID.Visible = true;
                    ////TEMINAT_MEKTUP_BILGI_ID.Visible = true;
                    //TEMINAT_IADE_TARIHI.Visible = true;

                    multiEditorRow1.Visible = false;
                    multiEditorRow5.Visible = false;
                }
                else
                {
                    //editorRow1.Visible = true;
                    //DovizId_TeminatTutari.Visible = true;
                    //ACIKLAMA.Visible = true;

                    multiEditorRow1.Visible = true;
                    multiEditorRow5.Visible = true;
                    //MUVEKKILE_TESLIM_TARIHI.Visible = true;
                    //TESLIM_ALAN_CARI_ID.Visible = true;
                    ////TEMINAT_MEKTUP_BILGI_ID.Visible = true;
                    //TEMINAT_IADE_TARIHI = true;
                }
            }
        }

        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSourceTeminat
        {
            get { return (TList<AV001_TDI_BIL_TEMINAT_MEKTUP>)vGTeminatMektup.DataSource; }
            set
            {
                vGTeminatMektup.DataSource = value;
                if (value != null)
                    value.AddingNew += new System.ComponentModel.AddingNewEventHandler(value_AddingNew);
            }
        }

        private void value_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMINAT_MEKTUP mektup = new AV001_TDI_BIL_TEMINAT_MEKTUP();
            mektup.ColumnChanged += new AV001_TDI_BIL_TEMINAT_MEKTUPEventHandler(mektup_ColumnChanged);
            e.NewObject = mektup;
        }

        public AV001_TDI_BIL_IHTIYATI_TEDBIR CurrentTedbir
        {
            get
            {
                if (vgIhtiyatiTedbir.FocusedRecord > -1 && MyDataSource.Count > vgIhtiyatiTedbir.FocusedRecord)
                    return MyDataSource[vgIhtiyatiTedbir.FocusedRecord];
                else
                {
                    return null;
                }
            }
        }

        public ucIhtiyatiTedbir()
        {
            InitializeComponent();
        }

        private void ucIhtiyatiTedbir_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTuru);
                BelgeUtil.Inits.perCariGetir(rLueTeslimAlanCari);
                BelgeUtil.Inits.TeminatMektupGetir(rLueTeminatMektupBilgi);
                BelgeUtil.Inits.ParaBicimiAyarla(rudPara);
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);

                #region <TIO - 20090614>

                if (MyDataSource != null && MyDataSource.Count > 0)
                    MyDataSource[0].ColumnChanged += ucIhtiyatiTedbir_ColumnChanged;
                BelgeUtil.Inits.TeminatTipGetir(rLueTeminatTipi);
                BelgeUtil.Inits.TeminatMektupKonuGetir(rLueMektupKonusu);
                BelgeUtil.Inits.TeminatMektupDurumGetir(rLueDurumu);
                BelgeUtil.Inits.perCariGetir(rLueLehtarCARI);
                BelgeUtil.Inits.BankaGetir(rLueBanka);
                BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);

                #endregion </TIO - 20090614>
            }
        }

        public bool MektupVarmi;

        #region <TIO - 20090614>

        private void ucIhtiyatiTedbir_ColumnChanged(object sender, AV001_TDI_BIL_IHTIYATI_TEDBIREventArgs e)
        {
            if (e.Column.ToString() == "TEMINAT_TUR_ID")
            {
                if (e.Value.ToString() == "2")
                {
                    // pnlTEminatMektup.Visible = true;

                    //MektupVarmi = true;
                }
                else
                {
                    //pnlTEminatMektup.Visible = false;
                    //MektupVarmi = false;
                }
            }
        }

        #endregion </TIO - 20090614>

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gridControl1.Visible)
            {
                gridControl1.Visible = false;
                vgIhtiyatiTedbir.Visible = true;
                vgIhtiyatiTedbir.BringToFront();
            }
            else
            {
                gridControl1.Visible = true;
                vgIhtiyatiTedbir.Visible = false;
                gridControl1.BringToFront();
            }
        }

        public event DevExpress.XtraVerticalGrid.Events.IndexChangedEventHandler FocusedTedbirChanged;

        private void dataNavigatorExtended1_PositionChanged(object sender, EventArgs e)
        {
            if (FocusedTedbirChanged != null)
            {
                FocusedTedbirChanged(null, null);
            }
        }


        private void rLueTeslimAlanCari_ButtonClick(object sender,
                                                    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                // cari.Statuler.Add(AvukatProLib.Extras.CariStatu.);
                // cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rLueTeslimAlanCari);
                                           }
                                       };
            }
        }

        private void rLueTeslimAlanCari_ProcessNewValue(object sender,
                                                        DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.Text != string.Empty)
            {
                frmCariGenelGiris cari = new frmCariGenelGiris();
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                // cari.Statuler.Add(AvukatProLib.Extras.CariStatu.);
                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetirRefresh(rLueTeslimAlanCari);
                                           }
                                       };
            }
        }

        private void vgIhtiyatiTedbir_FocusedRecordChanged(object sender,
                                                           DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedTedbirChanged != null)
            {
                FocusedTedbirChanged(sender, e);
            }
        }
    }
}