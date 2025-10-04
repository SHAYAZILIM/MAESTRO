using AdimAdimDavaKaydi.Util.Uyap;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKiymetliEvrakKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        #region Uyap GeriBildirim

        private UyapGeriBildirim _uyapBildirim;

        public UyapGeriBildirim UyapBildirim
        {
            get { return _uyapBildirim; }
            set { _uyapBildirim = value; }
        }

        #endregion Uyap GeriBildirim

        public frmKiymetliEvrakKayit()
        {
            this.Load += frmKiymetliEvrakKayit_Load;
            InitializeComponent();
            InitializeEvents();

            ucKiymetliEvrak1.FocusedRecordChanged += ucKiymetliEvrak1_FocusedRecordChanged;
        }

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> kiymetList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

        public bool munzammi, teminat;

        public TeminatSekli t;

        private TList<AV001_TDI_BIL_KIYMETLI_EVRAK> myDataSource;

        public event EventHandler<EventArgs> Kaydedildi;

        public event EventHandler<KiymetliEvrakKaydedildiEventArgs> KiymetliEvrakKaydedildi;

        public enum TeminatSekli
        {
            MunzamSenet_Cek = 1,
            MunzamSenet_Bono = 2,
            MunzamSenet_Police = 3,
        }

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (!this.DesignMode && value != null)
                {
                    myDataSource = value;
                    kiymetList = value;
                    kiymetList.AddingNew += kiymetList_AddingNew;
                    if (kiymetList.Count <= 0)
                        kiymetList.AddNew();
                    ucKiymetliEvrak1.MyDataSource = kiymetList;

                    //TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> taraflar = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>();
                    //foreach (var item in kiymetList[0].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection)
                    //{
                    //    if (item.TARAF_TIP_ID == 1)
                    //        taraflar.Add(item);
                    //}
                    ucKiymetliEvrakTaraf1.MyDataSource = kiymetList[0].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;
                }
            }
        }

        public AV001_TDIE_BIL_PROJE MyProje { get; set; }

        private void addNew_ColumnChanged(object sender, AV001_TDI_BIL_KIYMETLI_EVRAKEventArgs e)
        {
            if (e.Column == AV001_TDI_BIL_KIYMETLI_EVRAKColumn.EVRAK_TUR_ID)
            {
                if ((int)e.Value == (int)EvrakTurleri.POLÝÇE)
                {
                    if (ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID != null)
                    {
                        ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID.Appearance.BackColor =
                            System.Drawing.Color.FromArgb(((((255)))), ((((128)))), ((((0)))));
                        ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID.Properties.ImageIndex = 0;
                    }
                }
                else
                {
                    if (ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID != null)
                    {
                        ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID.Appearance.BackColor = System.Drawing.Color.White;
                        ucKiymetliEvrakTaraf1.rowTARAF_CARI_ID.Properties.ImageIndex = -1;
                    }
                }
            }
        }

        private void frmKiymetliEvrakKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKiymetliEvrakKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UyapBildirim != null)
                UyapBildirim.CagiranUyap.UyapGozdenGecir(UyapBildirim.IcraDosyalari, UyapBildirim.XmlDosyaYolu, UyapBildirim.geriBildirimYapilsin);
        }

        private void frmKiymetliEvrakKayit_Load(object sender, EventArgs e)
        {
            if (this.MyProje != null)
            {
                //if(MyDataSource == null)
                //    MyDataSource = MyProje.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKiymetliEvrakKayit_Button_Kaydet_Click;
        }

        private void kiymetList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK addNew = new AV001_TDI_BIL_KIYMETLI_EVRAK();
            addNew.ColumnChanged += addNew_ColumnChanged;
            switch (t)
            {
                case TeminatSekli.MunzamSenet_Cek:

                    addNew.EVRAK_TUR_ID = (int)t;
                    break;

                case TeminatSekli.MunzamSenet_Bono:

                    addNew.EVRAK_TUR_ID = (int)t;
                    break;

                case TeminatSekli.MunzamSenet_Police:
                    addNew.EVRAK_TUR_ID = (int)t;
                    break;

                default:
                    break;
            }
            if (munzammi)
            {
                addNew.MUNZAM_SENET_MI = true;
                addNew.TEMINAT_MI = false;
            }
            else if (teminat)
            {
                addNew.MUNZAM_SENET_MI = false;
                addNew.TEMINAT_MI = true;
            }
            else if (munzammi == false && teminat == false)
            {
                addNew.TEMINAT_MI = false;
                addNew.MUNZAM_SENET_MI = false;
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
                                addNew.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddNew();
                            davaTaraf.TARAF_CARI_ID = item.CARI_ID;

                            davaTaraf.TARAF_TIP_ID = (int?)KiymetliEvrakTarafTip.Alacakli;
                        }

                        //else
                        //{
                        //    AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF davaTaraf = addNew.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.AddNew();
                        //    davaTaraf.TARAF_CARI_ID = item.CARI_ID;

                        //    davaTaraf.TARAF_TIP_ID = (int?)KiymetliEvrakTarafTip.Kesideci_Borclu;
                        //}
                    }
                }
            }

            e.NewObject = addNew;
        }

        private bool Save()
        {
            bool sonuc = false;

            //MyDataSource.AddRange(kiymetList);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                //Uyap boþ geçilemez alanlar kontrolü

                #region <MB-20091226>

                List<String> uyapBosAlanlar = new List<string>();

                for (int i = 0; i < ucKiymetliEvrak1.MyDataSource.Count; i++)
                {
                    AV001_TDI_BIL_KIYMETLI_EVRAK kiymetliEvrak = ucKiymetliEvrak1.MyDataSource[i];
                    TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF> kiymetliEvrakTaraf =
                        ucKiymetliEvrak1.MyDataSource[i].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

                    if (!kiymetliEvrak.EVRAK_TANZIM_TARIHI.HasValue)
                    {
                        uyapBosAlanlar.Add(
                            String.Format(
                                "{0} numaralý kayýtta Tanzim Tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                i + 1));
                    }
                    if (kiymetliEvrak.TUTAR == null)
                    {
                        uyapBosAlanlar.Add(
                            String.Format("{0} numaralý kayýtta Tutar bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                          i + 1));
                    }

                    if (kiymetliEvrak.EVRAK_TUR_ID.HasValue)
                    {
                        if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.POLÝÇE)
                        {
                            if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Vade tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                            if (kiymetliEvrakTaraf.Count != 0 && !kiymetliEvrakTaraf[i].TARAF_CARI_ID.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Kýymetli Evrak Taraf bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                        }
                        if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.BONO)
                        {
                            if (!kiymetliEvrak.EVRAK_VADE_TARIHI.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Vade tarihi bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                        }
                        if (kiymetliEvrak.EVRAK_TUR_ID.Value == (int)EvrakTurleri.ÇEK)
                        {
                            if (!kiymetliEvrak.BANKA_ID.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Banka bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                            if (!kiymetliEvrak.SUBE_ID.HasValue)
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Þube bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                            if (string.IsNullOrEmpty(kiymetliEvrak.HESAP_NO.Trim()))
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Hesap No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                            if (string.IsNullOrEmpty(kiymetliEvrak.CEK_NO.Trim()))
                            {
                                uyapBosAlanlar.Add(
                                    String.Format(
                                        "{0} numaralý kayýtta Çek No bölümü Uyap için zorunlu alandýr. Boþ geçilmiþ",
                                        i + 1));
                            }
                        }
                    }
                }

                if (uyapBosAlanlar.Count > 0)
                {
                    string birlestirilmisHata = string.Empty;
                    foreach (string str in uyapBosAlanlar)
                    {
                        birlestirilmisHata += Environment.NewLine + str;
                    }
                    DialogResult dr =
                        XtraMessageBox.Show(
                            "Aþaðýda bulunan alan(lar) Uyap için zorunludur. Boþ geçmek istediðinize emin misiniz?" +
                            birlestirilmisHata, "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        return false;
                }

                #endregion <MB-20091226>

                MyDataSource = kiymetList;
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepSave(tran, MyDataSource, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));

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
                            if (munzammi || munzammi != null)
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
                //BelgeUtil.ErrorHandler.Catch(this, ex);

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

        private void ucKiymetliEvrak1_FocusedRecordChanged(object sender,
                                                           DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex > 0 && e.NewIndex < kiymetList.Count)
                ucKiymetliEvrakTaraf1.MyDataSource = kiymetList[e.NewIndex].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection;

            if (ucKiymetliEvrak1.CurrentEvrak != null)
            {
                if (!ucKiymetliEvrak1.CurrentEvrak.IsNew && ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_ID > 0)
                {
                    DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.
                        DeepLoad(ucKiymetliEvrak1.CurrentEvrak, true, DeepLoadType.IncludeChildren,
                                 typeof(TDI_KOD_KIYMETLI_EVRAK_TUR));
                }
                else if (ucKiymetliEvrak1.CurrentEvrak.IsNew && ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_ID > 0)
                {
                    ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_IDSource =
                        DataRepository.TDI_KOD_KIYMETLI_EVRAK_TURProvider.GetByID(
                            ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_ID.Value);
                }
                if (ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_IDSource != null)
                {
                    switch (ucKiymetliEvrak1.CurrentEvrak.EVRAK_TUR_IDSource.TUR)
                    {
                        case "ÇEK":
                        case "POLICE":
                            ucKiymetliEvrak1.crowBankaBilgileri.Visible = true;
                            ucKiymetliEvrak1.crowKarsilikveIslemBilgileri.Visible = true;
                            break;

                        case "SENET":
                            ucKiymetliEvrak1.crowBankaBilgileri.Visible = false;
                            ucKiymetliEvrak1.crowKarsilikveIslemBilgileri.Visible = false;
                            break;
                    }
                }
            }
        }
    }
}