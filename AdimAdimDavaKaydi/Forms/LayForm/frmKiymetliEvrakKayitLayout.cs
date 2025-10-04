using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.LayForm
{
    public partial class frmKiymetliEvrakKayitLayout : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmKiymetliEvrakKayitLayout()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmKiymetliEvrakKayitLayout_Load;
        }

        public bool munzammi, teminat;
        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> _MyDataSource;

        public event EventHandler<EventArgs> Kaydedildi;

        public event EventHandler<KiymetliEvrakKaydedildiEventArgs> KiymetliEvrakKaydedildi;

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                dnKiymetliEvrak.DataSource = value;
                bndKiymetliEvrak.DataSource = value;
                _MyDataSource.AddingNew += _MyDataSource_AddingNew;
            }
        }

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        public void Show(int teminatTip)
        {
            MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            MyDataSource.AddNew();
            MyDataSource[0].EVRAK_TUR_ID = teminatTip;
            //lueSozlesmeTipi.Enabled = false;

            this.Show();
        }

        private void _MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK kiymetliEvrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();
            aV001TDIBILKIYMETLIEVRAKTARAFCollectionBindingSource.DataSource =
                kiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
            //kiymetliEvrak.EVRAK_TANZIM_TARIHI = DateTime.Today;
            if (munzammi)
            {
                kiymetliEvrak.MUNZAM_SENET_MI = true;
                kiymetliEvrak.TEMINAT_MI = false;
            }
            else if (teminat)
            {
                kiymetliEvrak.MUNZAM_SENET_MI = false;
                kiymetliEvrak.TEMINAT_MI = true;
            }
            else if (munzammi == false && teminat == false)
            {
                kiymetliEvrak.TEMINAT_MI = false;
                kiymetliEvrak.MUNZAM_SENET_MI = false;
            }
            if (MyProje != null)
            {
                if (MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                {
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(MyProje, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>),
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>));
                }
                DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.DeepLoad(
                    MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection, false, DeepLoadType.IncludeChildren,
                    typeof(AV001_TDI_BIL_CARI));
                foreach (AV001_TDIE_BIL_PROJE_TARAF item in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    if (item.CARI_IDSource != null)
                    {
                        if (item.CARI_IDSource.MUVEKKIL_MI)
                        {
                            AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF davaTaraf =
                                kiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddNew();
                            davaTaraf.TARAF_CARI_ID = item.CARI_ID;

                            davaTaraf.TARAF_TIP_ID = (int?)KiymetliEvrakTarafTip.Alacakli;
                        }
                    }
                }
            }

            kiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddingNew +=
                AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew;
            //bndKiymetliEvrakTaraf.DataSource = kiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
            // dnKiymetliEvrakTaraf.DataSource = kiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

            e.NewObject = kiymetliEvrak;

            //kiymetliEvrak.ColumnChanging += new AV001_TDI_BIL_KIYMETLI_EVRAKEventHandler(kiymetliEvrak_ColumnChanging);
        }

        private void AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF evrakT = new AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF();
            e.NewObject = evrakT;
        }

        private void dnKiymetliEvrakTaraf_Validating(object sender, CancelEventArgs e)
        {
            // exGrdTarafBilgileri.DataSource = dnKiymetliEvrakTaraf.DataSource;
        }

        private void frmKiymetliEvrakKayitLayout_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Değişiklikler kaydedildi.", "Kaydet ve Çık",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme işlemi yapılamıyor.",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKiymetliEvrakKayitLayout_Load(object sender, EventArgs e)
        {
            #region Initsler

            BelgeUtil.Inits.BankaGetir(lueBanka);
            BelgeUtil.Inits.DovizTipGetir(lueDoviz);
            BelgeUtil.Inits.KiymetliEvrakTipiGetir(lueEvrakTuru);
            BelgeUtil.Inits.DovizTipGetir(lueKarsilikTutarDoviz);
            BelgeUtil.Inits.perCariGetir(lueSoran.Properties);
            BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(lueTipi.Properties);
            BelgeUtil.Inits.perCariGetir(luTaraf.Properties);
            BelgeUtil.Inits.perCariGetir(rLueTaraf);
            BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rLueTarafTip);
            BelgeUtil.Inits.KESonucuGetir(lueSormaSonuc.Properties);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(spKarsilikTutar);

            #endregion Initsler

            if (bndKiymetliEvrak.Current != null)
                (bndKiymetliEvrak.Current as AV001_TDI_BIL_KIYMETLI_EVRAK).ColumnChanged += kiymetliEvrak_ColumnChanging;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKiymetliEvrakKayitLayout_Button_Kaydet_Click;
        }

        private void kiymetliEvrak_ColumnChanging(object sender, AV001_TDI_BIL_KIYMETLI_EVRAKEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK evrak = sender as AV001_TDI_BIL_KIYMETLI_EVRAK;
            if (e.Column == AV001_TDI_BIL_KIYMETLI_EVRAKColumn.EVRAK_TANZIM_TARIHI)
            {
                evrak.SORULDUGU_TARIH = evrak.EVRAK_TANZIM_TARIHI;
            }
            if (e.Column == AV001_TDI_BIL_KIYMETLI_EVRAKColumn.SORULDUGU_TARIH)
            {
                evrak.EVRAK_VADE_TARIHI = (DateTime)e.Value;
            }
        }

        private void lueBanka_EditValueChanged(object sender, EventArgs e)
        {
            //BelgeUtil.Inits.BankaSubeGetir(lueBankaSube, (int)lueBanka.EditValue);
            AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(lueBankaSube, (int)lueBanka.EditValue);
        }

        private void lueEvrakTuru_EditValueChanged(object sender, EventArgs e)
        {
            if ((int)lueEvrakTuru.EditValue == (int)EvrakTurleri.BONO ||
                (int)lueEvrakTuru.EditValue == (int)EvrakTurleri.POLİÇE)
            {
                //layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\KıymetliEvrakXmler\\Bono\\BonoGenelBilgiler.xml");
            }
            if ((int)lueEvrakTuru.EditValue == (int)EvrakTurleri.ÇEK)
            {
                //layoutControl1.RestoreLayoutFromXml(Application.StartupPath + "\\KıymetliEvrakXmler\\Cek\\CekGenelBilgiler.xml");
            }
        }

        private bool Save()
        {
            bool sonuc = false;
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, MyDataSource,
                                                                             DeepSaveType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));

                if (MyProje != null)
                {
                    foreach (var item in MyDataSource)
                    {
                        if (
                            DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.GetByKIYMETLI_EVRAK_IDPROJE_ID(
                                item.ID, MyProje.ID) == null)
                        {
                            AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK projesource = new AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK();
                            projesource.KIYMETLI_EVRAK_ID = item.ID;
                            projesource.PROJE_ID = MyProje.ID;
                            if (munzammi != null)
                            {
                                item.MUNZAM_SENET_MI = munzammi;
                            }
                            else if (teminat || teminat != null)
                            {
                                item.TEMINAT_MI = teminat;
                            }
                            else
                            {
                                item.TEMINAT_MI = false;
                                item.MUNZAM_SENET_MI = false;
                            }
                            DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.Save(tran, projesource);
                        }
                    }
                }
                tran.Commit();
                if (KiymetliEvrakKaydedildi != null)
                    KiymetliEvrakKaydedildi(this, new KiymetliEvrakKaydedildiEventArgs(MyDataSource));
                sonuc = true;
            }
            catch 
            {
                sonuc = false;
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

        #region <MB-20100811>

        //Tarafa yeni bir cari kaydı yapılabilmesi sağlandı.
        private void luTaraf_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "YeniKayit")
            {
                frmCariGenelGiris frm = new frmCariGenelGiris();
                frm.tmpCariAd = luTaraf.Text;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(delegate
                {
                    DialogResult dr = frm.KayitBasarili;
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Inits.perCariGetir(luTaraf.Properties);
                        Inits.perCariGetir(rLueTaraf);
                    }
                });
            }
        }

        #endregion <MB-20100811>
    }
}