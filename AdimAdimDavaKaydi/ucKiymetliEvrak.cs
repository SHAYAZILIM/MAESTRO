using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;

//using AvukatProLib.Facade;

namespace AdimAdimDavaKaydi
{
    public enum EvrakTurleri
    {
        ÇEK = 1,
        BONO = 2,
        POLİÇE = 3
    }

    ///<summary>
    ///Listeden Kıymetli evrak getirirken kullanılır
    ///</summary>
    public class ListedenKiymetliEvrakGetirEventArgs : EventArgs
    {
        public ListedenKiymetliEvrakGetirEventArgs(AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak)
        {
            this.KiymetliEvrak = kEvrak;
        }

        ///<summary>
        ///Getirilen kiymetli evrak.
        ///</summary>
        public AV001_TDI_BIL_KIYMETLI_EVRAK KiymetliEvrak { get; set; }
    }

    public partial class ucKiymetliEvrak : DevExpress.XtraEditors.XtraUserControl
    {
        [Obsolete("Yerine Navigator Extender kullanılmaktadır")]
        public int TARAF_ID;

        public ucKiymetliEvrak()
        {
            InitializeComponent();
        }

        public event IndexChangedEventHandler FocusedRecordChanged;

        ///<summary>
        ///Listeden bir kıymetli evrak getirildiğinde patlar,(her kıymetli evrak için bir sefer patlar)
        ///</summary>
        public event EventHandler<ListedenKiymetliEvrakGetirEventArgs> OnListedenKiymetliEvrakGetirildi;

        public AV001_TDI_BIL_KIYMETLI_EVRAK CurrentEvrak
        {
            get
            {
                if (MyDataSource != null && vgKEvrak.FocusedRecord > -1 && MyDataSource.Count > 0)

                    return MyDataSource[vgKEvrak.FocusedRecord];
                else if (MyDataSource != null && MyDataSource.Count > 0 && vgKEvrak.FocusedRecord > -1)
                    return MyDataSource[0];
                else
                    return null;
            }
        }

        public LayoutViewStyle Gorunum
        {
            get { return vgKEvrak.LayoutStyle; }
            set
            {
                vgKEvrak.LayoutStyle = value;

                if (value == LayoutViewStyle.SingleRecordView && !this.DesignMode)
                {
                    vgKEvrak.RecordWidth = 135;
                    vgKEvrak.RowHeaderWidth = 65;
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> MyDataSource
        {
            get
            {
                if (vgKEvrak.DataSource is TList<AV001_TDI_BIL_KIYMETLI_EVRAK> && !DesignMode)
                    return (TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)vgKEvrak.DataSource;
                else
                    return null;
            }
            set
            {
                if (!DesignMode)
                {
                    vgKEvrak.DataSource = value;
                    gcKiymetliEvrak.DataSource = value;

                    extendedGridControl1.DataSource = gcKiymetliEvrak.DataSource;
                    if (value != null)
                    {
                        foreach (AV001_TDI_BIL_KIYMETLI_EVRAK var in value)
                        {
                            var.ColumnChanged += var_ColumnChanged;

                            //Düzenleme modunda şube bilgisinin dolmasını sağlamak için eklendi.
                            if (var.BANKA_ID.HasValue)
                                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rlkBankSube, var.BANKA_ID.Value);

                            //BelgeUtil.Inits.BankaSubeGetir(rlkBankSube, var.BANKA_ID.Value);
                        }
                    }
                }
            }
        }

        public TList<AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK> MyExtendedDataSource
        {
            get
            {
                if (DesignMode || MyDataSource == null)
                    return null;

                TList<AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK> result =
                    new TList<AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK>();
                if (MyDataSource != null)
                {
                    foreach (AV001_TDI_BIL_KIYMETLI_EVRAK evrak in MyDataSource)
                    {
                        AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK evr = new AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK();
                        evr.KIYMETLI_EVRAK_IDSource = evrak;
                        result.Add(evr);
                    }
                }
                return result;
            }
            set
            {
                if (value == null)
                    return;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> tmpevrak = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                foreach (AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK evr in value)
                {
                    tmpevrak.Add(evr.KIYMETLI_EVRAK_IDSource);
                }
                MyDataSource = tmpevrak;
            }
        }

        public bool OnlyOneRecord { get; set; }

        public void RefreshDataSource()
        {
            gcKiymetliEvrak.RefreshDataSource();
            vgKEvrak.DataSource = gcKiymetliEvrak.DataSource;
            vgKEvrak.Refresh();
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgKEvrak.Visible)
            {
                vgKEvrak.Visible = false;
                gcKiymetliEvrak.Visible = true;
                gcKiymetliEvrak.BringToFront();
                gcKiymetliEvrak.DataSource = vgKEvrak.DataSource;
            }
            else
            {
                vgKEvrak.Visible = true;
                gcKiymetliEvrak.Visible = false;
                vgKEvrak.BringToFront();
                vgKEvrak.DataSource = gcKiymetliEvrak.DataSource;
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender,
                                                                 AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK seciliEvrak = gridView1.GetFocusedRow() as AV001_TDI_BIL_KIYMETLI_EVRAK;

            if (MyDataSource != null && MyDataSource.Count > 0)
            {
                if (seciliEvrak.EVRAK_TUR_ID.HasValue)
                {
                    frmEkleKiymetliEvrak frm = new frmEkleKiymetliEvrak();
                    frm.TARAF_ID = TARAF_ID;
                    frm.Tip = seciliEvrak.EVRAK_TUR_ID.Value;
                    frm.alreadyAddedList = null; // MyDataSource;

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.Show();
                    DialogResult dr = frm.KayitBasarili;

                    if (dr == DialogResult.OK)
                    {
                        MyDataSource.Remove(seciliEvrak);
                        foreach (AV001_TDI_BIL_KIYMETLI_EVRAK evrak in frm.selectedList)
                        {
                            if (MyDataSource.Find("ID", evrak.ID) == null)
                            {
                                MyDataSource.Add(evrak);
                                if (OnListedenKiymetliEvrakGetirildi != null)
                                {
                                    OnListedenKiymetliEvrakGetirildi(this,
                                                                     new ListedenKiymetliEvrakGetirEventArgs(evrak));
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Kıymetli Evrak Türü Seçiniz");
            }
        }

        private void gcKiymetliEvrak_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gcKiymetliEvrak.Visible = true;
                gcKiymetliEvrak.BringToFront();
            }
            else
            {
                extendedGridControl1.Visible = true;
                gcKiymetliEvrak.Visible = false;
                extendedGridControl1.BringToFront();
            }
        }

        private void initSoranGetir()
        {
            BelgeUtil.Inits.perCariGetir(rlkCariSoran);
        }

        private void initTutarBirimGetir()
        {
            BelgeUtil.Inits.DovizTipGetir(rlkKarsilikTutarBirim);
            BelgeUtil.Inits.DovizTipGetir(rlkTutarBirim);
            BelgeUtil.Inits.ParaBicimiAyarla(rudKarsilikTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
        }

        private void rlkCariSoran_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frmCariGenelGiris cari = new frmCariGenelGiris();
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
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rlkCariSoran);
                                           }
                                       };
            }
        }

        private void rlkCariSoran_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            frmCariGenelGiris cari = new frmCariGenelGiris();
            if (lue.Text != string.Empty)
            {
                cari = new frmCariGenelGiris();
                cari.tmpCariAd = lue.Text;

                //cari.Statuler.Add(AvukatProLib.Extras.CariStatu.);
                //.MdiParent = null;
                cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cari.Show();
                cari.FormClosed += delegate
                                       {
                                           DialogResult dr = cari.KayitBasarili;
                                           if (dr == System.Windows.Forms.DialogResult.OK)
                                           {
                                               //Inits.perCariGetirRefresh();
                                               BelgeUtil.Inits.perCariGetir(rlkCariSoran);
                                           }
                                       };
            }
        }

        private void ucKiymetliEvrak_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                gcKiymetliEvrak.ButtonCevirClick += gcKiymetliEvrak_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gcKiymetliEvrak_ButtonCevirClick;

                initSoranGetir();
                initTutarBirimGetir();
                BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlkEvrakTur);
                BelgeUtil.Inits.BankaGetir(rlkBanka);

                BelgeUtil.Inits.KEAhzolunmaSekliGetir(rlkNeSekildeAhzolundugu);
                BelgeUtil.Inits.KESonucuGetir(rlkSorulmaSonucu);

                //BelgeUtil.Inits.BankaSubeGetir(rlkBankSube);
                if (OnlyOneRecord)
                {
                    dataNavigatorExtended1.Buttons.Append.Visible = false;
                }
            }
        }

        private void var_ColumnChanged(object sender, AV001_TDI_BIL_KIYMETLI_EVRAKEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_KIYMETLI_EVRAKColumn.EVRAK_TUR_ID)
            {
                if ((int)e.Value == (int)EvrakTurleri.ÇEK)
                {
                    vgKEvrak.Rows["mrowBankaSubeId"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                          ((((128)))),
                                                                                                          ((((0)))));
                    vgKEvrak.Rows["mrowBankaSubeId"].Properties.ImageIndex = 0;

                    vgKEvrak.Rows["mrowHesapNo"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                      ((((128)))),
                                                                                                      ((((0)))));
                    vgKEvrak.Rows["mrowHesapNo"].Properties.ImageIndex = 0;

                    vgKEvrak.Rows["mrowCekNo"].Appearance.BackColor = System.Drawing.Color.FromArgb(((((255)))),
                                                                                                    ((((128)))),
                                                                                                    ((((0)))));
                    vgKEvrak.Rows["mrowCekNo"].Properties.ImageIndex = 0;
                }
                else
                {
                    vgKEvrak.Rows["mrowBankaSubeId"].Appearance.BackColor = System.Drawing.Color.White;
                    vgKEvrak.Rows["mrowBankaSubeId"].Properties.ImageIndex = -1;

                    vgKEvrak.Rows["mrowHesapNo"].Appearance.BackColor = System.Drawing.Color.White;
                    vgKEvrak.Rows["mrowHesapNo"].Properties.ImageIndex = -1;

                    vgKEvrak.Rows["mrowCekNo"].Appearance.BackColor = System.Drawing.Color.White;
                    vgKEvrak.Rows["mrowCekNo"].Properties.ImageIndex = -1;
                }

                if ((int)e.Value == (int)EvrakTurleri.BONO || (int)e.Value == (int)EvrakTurleri.POLİÇE)
                {
                    vgKEvrak.Rows["rowEVRAK_VADE_TARIHI"].Appearance.BackColor =
                        System.Drawing.Color.FromArgb(((((255)))), ((((128)))), ((((0)))));
                    vgKEvrak.Rows["rowEVRAK_VADE_TARIHI"].Properties.ImageIndex = 0;
                }
                else
                {
                    vgKEvrak.Rows["rowEVRAK_VADE_TARIHI"].Appearance.BackColor = System.Drawing.Color.White;
                    vgKEvrak.Rows["rowEVRAK_VADE_TARIHI"].Properties.ImageIndex = -1;
                }
            }
            else if (e.Column == AV001_TDI_BIL_KIYMETLI_EVRAKColumn.BANKA_ID)
            {
                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rlkBankSube, (int)e.Value);

                //BelgeUtil.Inits.BankaSubeGetir(rlkBankSube, (int)e.Value);
            }
        }

        private void vgKEvrak_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (FocusedRecordChanged != null)
            {
                FocusedRecordChanged(sender, e);
            }
        }
    }
}