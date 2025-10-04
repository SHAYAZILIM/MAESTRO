using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTazminat_Ihtiyat : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTazminat_Ihtiyat()
        {
            KlasorIcin = false;
            InitializeComponent();
        }

        /// <summary>
        /// Klasör için bir kayýt giriliyor ise geriye true döndürür
        /// </summary>
        public bool KlasorIcin { get; set; }

        public event EventHandler MyDataSourceChanged;

        [Browsable(false)]
        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                return (TList<AV001_TI_BIL_IHTIYATI_HACIZ>)vgTazminat_Ihtiyat.DataSource;
            }
            set
            {
                if (DesignMode)
                {
                    return;
                }
                vgTazminat_Ihtiyat.DataSource = value;
                if (MyDataSourceChanged != null)
                {
                    MyDataSourceChanged(this, new EventArgs());
                }
                TList<AV001_TDI_BIL_TEMINAT_MEKTUP> list = DataRepository.AV001_TDI_BIL_TEMINAT_MEKTUPProvider.GetAll();
                if (MyDataSource != null)
                {
                    foreach (var item in MyDataSource)
                    {
                        var listim = list.Where(vi => vi.IHTIYATI_HACIZ_ID == item.ID).ToList();
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
                else
                {
                    MyDataSourceTeminat = new TList<AV001_TDI_BIL_TEMINAT_MEKTUP>();
                    MyDataSourceTeminat.AddNew();
                }
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_IHTIYATI_HACIZ CurrentHaciz
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (vgTazminat_Ihtiyat.FocusedRecord > -1 && MyDataSource.Count > vgTazminat_Ihtiyat.FocusedRecord)
                    return MyDataSource[vgTazminat_Ihtiyat.FocusedRecord];
                else
                {
                    return null;
                }
            }
            set
            {
                if (value != null)
                    MyDataSource[vgTazminat_Ihtiyat.FocusedRecord] = value;
            }
        }

        public TList<AV001_TDI_BIL_TEMINAT_MEKTUP> MyDataSourceTeminat
        {
            get { return (TList<AV001_TDI_BIL_TEMINAT_MEKTUP>)vGTeminatMektup.DataSource; }
            set
            {
                vGTeminatMektup.DataSource = value;
                if (value != null)
                    value.AddingNew += value_AddingNew;
            }
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEMINAT_MEKTUP mektup = new AV001_TDI_BIL_TEMINAT_MEKTUP();
            mektup.ColumnChanged += mektup_ColumnChanged;
            e.NewObject = mektup;
        }

        private void mektup_ColumnChanged(object sender, AV001_TDI_BIL_TEMINAT_MEKTUPEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_TEMINAT_MEKTUPColumn.BANKA_ID)
            {
                BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube, (int)e.Value);
            }
            if (e.Column == AV001_TDI_BIL_TEMINAT_MEKTUPColumn.TEMINAT_TURU_ID)
            {
                if ((int)e.Value == 1) //NAKÝT
                {
                    //editorRow1.Visible = true;
                    //DovizId_TeminatTutari.Visible = true;
                    //ACIKLAMA.Visible = true;
                    //TEMINAT_IADE_TARIHI.Visible = true;
                    //MUVEKKILE_TESLIM_TARIHI.Visible = true;
                    //TESLIM_ALAN_CARI_ID.Visible = true;
                    ////TEMINAT_MEKTUP_BILGI_ID.Visible = true;

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
                    //TEMINAT_IADE_TARIHI.Visible = true;
                    //MUVEKKILE_TESLIM_TARIHI.Visible = true;
                    //TESLIM_ALAN_CARI_ID.Visible = true;
                    ////TEMINAT_MEKTUP_BILGI_ID.Visible = true;
                }
            }
        }

        private void ucTahminat_Ihtiyat_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTuru);
                BelgeUtil.Inits.perCariGetir(rLueTeslimAlanCari);
                BelgeUtil.Inits.TeminatMektupGetir(rLueTeminatMektupBilgi);
                BelgeUtil.Inits.ParaBicimiAyarla(rudPara);
                vgTazminat_Ihtiyat.FocusedRecordChanged += vgTazminat_Ihtiyat_FocusedRecordChanged;

                #region <MB-20100812>

                //Ýhityati haciz icra takipleri için not yazýlmasý saðlandý.
                rtxtNot.Text = " Dikkat: Ýhtiyati haciz iþlemleri, ihtiyati haciz masrafý, teminat iþlemleri ihtiyati haczin uygulanacaðý takip ekranýndan yapýlmaktadýr." + Environment.NewLine + " Bunun için normal takibi açtýðýmýz ekrandan takip açmaya girilip bu ihtiyati haciz baðlanýp takip açtýrýlýr. Ancak takip tarihi girilmez. Böylece ilk takip masraflarý ile takip vekalet ücreti ve faiz iþlemez. Ýcrai takibe geçildiðinde ise sadece takip tarihi girilir. Takip talebi, icra/ödeme emirleri alýnýr.";
                rtxtNot.ForeColor = System.Drawing.Color.Red;
                var underlineFont = new System.Drawing.Font(rtxtNot.Font, System.Drawing.FontStyle.Underline);
                rtxtNot.SelectionStart = rtxtNot.Find("takip tarihi girilmez");
                rtxtNot.SelectionFont = underlineFont;
                rtxtNot.SelectionStart = rtxtNot.Find("ilk takip masraflarý");
                rtxtNot.SelectionFont = underlineFont;
                rtxtNot.SelectionStart = rtxtNot.Find("takip vekalet ücreti");
                rtxtNot.SelectionFont = underlineFont;
                rtxtNot.SelectionStart = rtxtNot.Find("faiz iþlemez");
                rtxtNot.SelectionFont = underlineFont;

                #endregion

                #region <TIO - 20090614>

                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    //YANLIS: Burda yapýlan iþlem sadece ilgili collection ýn ilk elemanýna etki etmektedir.
                    //DOGRUSU: Bu iþlem tüm elemanlar için uygulanmalýdýr ve alt kýsýmda yazýlmýþtýr [YY]
                    //MyDataSource[0].ColumnChanged += new AV001_TI_BIL_IHTIYATI_HACIZEventHandler(ucTazminat_Ihtiyat_ColumnChanged);
                    foreach (AV001_TI_BIL_IHTIYATI_HACIZ iHaciz in MyDataSource)
                    {
                        iHaciz.ColumnChanged += ucTazminat_Ihtiyat_ColumnChanged;
                    }
                }
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

        public bool MektupTamam;

        #region <TIO - 20090614>

        private void ucTazminat_Ihtiyat_ColumnChanged(object sender, AV001_TI_BIL_IHTIYATI_HACIZEventArgs e)
        {
            if (e.Column.ToString() == "TEMINAT_TURU_ID")
            {
                if (e.Value.ToString() == "2")
                {
                    //pnlTEminatMektup.Visible = true;

                    //MektupTamam = true;
                }
                else
                {
                    //pnlTEminatMektup.Visible = false;
                    //MektupTamam = false;
                }
            }
        }

        #endregion </TIO - 20090614>

        public event IndexChangedEventHandler FocusedHacizChanged;

        private void vgTazminat_Ihtiyat_FocusedRecordChanged(object sender,
                                                             DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (FocusedHacizChanged != null)
            {
                FocusedHacizChanged(sender, e);
            }
        }

        private frmCariGenelGiris cari = new frmCariGenelGiris();

        private void rLueTeslimAlanCari_ButtonClick(object sender,
                                                    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Tag != null && e.Button.Tag == "CariEkle")
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;
                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
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
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;
                //cari.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               BelgeUtil.Inits.perCariGetirRefresh(rLueTeslimAlanCari);
                                           }
                                       };
            }
        }
    }
}