using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmTebligat : Util.BaseClasses.AvpXtraForm
    {
        private bool kaydedildi;

        private AV001_TDI_BIL_TEBLIGAT myTebligat;

        public rFrmTebligat()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmTebligat_Load;
            this.FormClosing += rFrmTebligat_FormClosing;
            this.FormClosed += rFrmTebligat_FormClosed;
        }

        public enum TebligatFormTipi
        {
            TebligatFormu,
            YuzucFormu
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_TEBLIGAT MyTebligat
        {
            get { return myTebligat; }
            set
            {
                myTebligat = value;
                if (value != null)
                {
                    TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> result = new TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>();
                    result.AddingNew += AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew;

                    if (MyTebligatMuhatap == null && value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count > 0)
                        result = value.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection;
                    else if (MyTebligatMuhatap != null)
                        result.Add(MyTebligatMuhatap);
                    if (result == null || result.Count == 0)
                        result.AddNew();

                    dataNavigatorExtended1.DataSource = result;
                    vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                    gcTebligat.DataSource = dataNavigatorExtended1.DataSource;

                    foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP muh in MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection)
                    {
                        muh.ColumnChanged += muhatap_ColumnChanged;
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_TEBLIGAT_MUHATAP MyTebligatMuhatap { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TebligatFormTipi TFormTipi { get; set; }

        public void Show(AV001_TDI_BIL_TEBLIGAT tebligat)
        {
            MyTebligat = tebligat;

            this.Show();
        }

        private void AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP muh = e.NewObject as AV001_TDI_BIL_TEBLIGAT_MUHATAP;
            if (muh == null)
                muh = new AV001_TDI_BIL_TEBLIGAT_MUHATAP();

            muh.MUHATAP_CARI_ID = ucIcraTarafBilgileri.CurrBorcluId;

            muh.TEBLIG_TARIH = DateTime.Today;
            muh.KAYIT_TARIHI = DateTime.Today;
            muh.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            muh.KONTROL_KIM = "AVUKATPRO";
            muh.KONTROL_NE_ZAMAN = DateTime.Today;
            muh.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            muh.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            muh.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            e.NewObject = muh;

            if (!MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Contains(muh))
                MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Add(muh);

            muh.ColumnChanged += muhatap_ColumnChanged;
        }

        private bool CikabilirMi(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> list)
        {
            foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP muh in list)
            {
                if (muh.IsNew || muh.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vGridControl1.Visible)
            {
                vGridControl1.Visible = false;
                gcTebligat.Visible = true;
                gcTebligat.BringToFront();
            }
            else if (gcTebligat.Visible)
            {
                vGridControl1.Visible = true;
                gcTebligat.Visible = false;
                vGridControl1.BringToFront();
            }
        }

        private void GeriAl(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP> list)
        {
            try
            {
                if (list.Count > 0)
                    list.AddRange(list.DeletedItems);

                foreach (AV001_TDI_BIL_TEBLIGAT_MUHATAP muh in list)
                {
                    if (muh.HasDataChanged())
                        muh.CancelChanges();
                }
            }
            catch
            {
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmTebligat_Button_Kaydet_Click;
        }

        private void muhatap_ColumnChanged(object sender, AV001_TDI_BIL_TEBLIGAT_MUHATAPEventArgs e)
        {
            AV001_TDI_BIL_TEBLIGAT_MUHATAP gonderilen = sender as AV001_TDI_BIL_TEBLIGAT_MUHATAP;

            //if (e.Column == AV001_TDI_BIL_TEBLIGAT_MUHATAPColumn.BILA_TEBLIG_MI)
            //{
            //    if ((bool)e.Value)
            //        gonderilen.TEBLIG_TARIH = DateTime.Today;
            //} // Bila tebliði seçilince teblið tarihinin otomatik getirilmesi istenmediðinden ( Bahattin Çelik ) kapatýldý. MB

            if (gonderilen.ZABITA_ARASTIRMA_TARIHI.HasValue)
                gonderilen.ZABITA_ARASTIRMASI_ISTENDI_MI = true;
            else
                gonderilen.ZABITA_ARASTIRMASI_ISTENDI_MI = false;

            if (gonderilen.OLUMSUZ_SONUC_TARIHI.HasValue)
                gonderilen.ZABITA_ARASTIRMASI_OLUMSUZ_MU = true;
            else
                gonderilen.ZABITA_ARASTIRMASI_OLUMSUZ_MU = false;
        }

        private void rFrmTebligat_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                kaydedildi = true;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kayýt Esnasýnda Hata Oluþtu." + Environment.NewLine + "Dosya Kaydedilemedi.",
                                    "Kayýt",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rFrmTebligat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;

            ucIcraTarafGelismeleri.TebligatTarihiHesapla(MyGelisme, MyFoy);
            ucIcraTarafGelismeleri.YuzucTarihiHesapla(MyGelisme, MyFoy);

            //Tebligat Sonrasi Gelismeler
            if (MyGelisme.ILK_TEBLIGAT_TARIHI.HasValue)
            {
                ucIcraTarafGelismeleri.MalBeyaniTarihiHesapla(MyGelisme, MyFoy);
                ucIcraTarafGelismeleri.ItirazTarihiHesapla(MyGelisme, MyFoy);
                ucIcraTarafGelismeleri.KesinlesmeTarihiHesapla(MyGelisme, MyFoy);
                ucIcraTarafGelismeleri.HacizTarihiHesapla(MyGelisme, MyFoy);
            }
        }

        private void rFrmTebligat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi(MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection))
            {
                DialogResult dr =
                    XtraMessageBox.Show("Yapýlan deðiþiklikler kaydedilmedi.Çýkmak istediðinizden emin misiniz ?",
                                        "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GeriAl(MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection);
                }
                else
                    e.Cancel = true;
            }
        }

        private void rFrmTebligat_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                BelgeUtil.Inits.perCariGetir(rlueBorclu);
                BelgeUtil.Inits.TebligatAlanBaglantiGetirBy23_32Haric(rlueAlanBaglantý);
                BelgeUtil.Inits.TebligatSekliGetir(rlueTebligtSekli);
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                //foreach (var item in MyFoy.AV001_TDI_BIL_TEBLIGATCollection)
                //{
                //    item.ICRA_FOY_ID = MyFoy.ID;
                //}
                //if (MyFoy != null)
                //{
                //    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, MyFoy.AV001_TDI_BIL_TEBLIGATCollection,
                //                                                           DeepSaveType.IncludeChildren,
                //                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                //                                                               ));
                //}
                if (MyTebligatMuhatap == null)
                {
                    if (MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection.Count > 0)
                        MyTebligatMuhatap = MyTebligat.AV001_TDI_BIL_TEBLIGAT_MUHATAPCollection[0];
                }

                if (MyTebligatMuhatap == null)
                    return false;

                if (MyTebligatMuhatap.ALAN_CARI_ID == null)
                    MyTebligatMuhatap.ALAN_CARI_ID = MyTebligatMuhatap.MUHATAP_CARI_ID;
                MyTebligat.MUHASEBE_ALT_KATEGORI_ID = 568;

                if (MyTebligat != null)
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepSave(trans, MyTebligat,
                                                                           DeepSaveType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ));

                //Takip ekranýnda, düzenle iþleminde deðiþiklikler yapýlýp, kaydet dendiði halde deðiþikliklerin algýlanmamasý sorunu için eklendi. MB (Form takip ekranlarýnda düzenleme iþlemi için, taraf ve geliþmelerde de kayýt ve düzenleme iþlemi için kullanýlýyor.
                if (MyTebligatMuhatap != null)
                    DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Save(trans, MyTebligatMuhatap);

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
            return true;
        }
    }
}