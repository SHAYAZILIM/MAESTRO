using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AdimAdimDavaKaydi.Util;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmSatisGirisi : Util.BaseClasses.AvpXtraForm
    {
        #region Fields

        public TList<AV001_TI_BIL_SATIS_CHILD> ChildList = new TList<AV001_TI_BIL_SATIS_CHILD>();
        public int hacizChildID = -1;
        private frmHacizliMallar frm;
        private bool isModul;
        private bool kaydedildi;
        private int masterIndex;
        private AV001_TI_BIL_FOY myFoy;
        private TList<AV001_TI_BIL_SATIS_MASTER> tempList = new TList<AV001_TI_BIL_SATIS_MASTER>();

        #endregion Fields

        #region Constructors

        public frmSatisGirisi()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += frmSatisGirisi_Load;
            this.FormClosing += frmSatisGirisi_FormClosing;
            this.FormClosed += frmSatisGirisi_FormClosed;

            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> satisYenile;

        #endregion Events

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_SATIS_MASTER> AddNewList
        {
            get;
            set;
        }

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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                if (value != null && !DesignMode)
                {
                    myFoy = value;

                    //vgSatisMaster.DataSource = value;
                    //vgSatisChild.DataSource = value;

                    //  SetFoy(value);
                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TI_BIL_SATIS_MASTER>();
                        AddNewList.AddingNew += AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
                        AddNewList.AddNew();
                    }
                    SetSatis(AddNewList);
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy,
                                                     new[] { rlueBorcluCari });
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy,
                                                       new[] { rlueAlacakliCari });

                    //AddNewList.AddingNew += AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
                    //vgSatisMaster.DataSource = AddNewList;
                    //vgSatisChild.DataSource = AddNewList[vgSatisMaster.FocusedRecord].AV001_TI_BIL_SATIS_CHILDCollection;
                    //TList<AV001_TI_BIL_SATIS_CHILD> childList = new TList<AV001_TI_BIL_SATIS_CHILD>();
                    //childList.AddingNew += childList_AddingNew;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public static int SatisChildSiraNo(AV001_TI_BIL_SATIS_MASTER satisMaster)
        {
            int i = 1;

            if (satisMaster.AV001_TI_BIL_SATIS_CHILDCollection.Count == 0)
                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepLoad(satisMaster, false,
                                                                          DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

            if (satisMaster.AV001_TI_BIL_SATIS_CHILDCollection.Count > 0)
            {
                int malSiraNo = satisMaster.AV001_TI_BIL_SATIS_CHILDCollection.Last().MAL_SIRA_NO;

                i = ++malSiraNo;
            }

            return i;
        }

        public static int SatisSiraNo(AV001_TI_BIL_FOY foy)
        {
            int i = 1;

            if (foy.AV001_TI_BIL_SATIS_MASTERCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_SATIS_MASTER>));

            if (foy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
            {
                int satisSiraNo = foy.AV001_TI_BIL_SATIS_MASTERCollection.Last().SATIS_SIRA_NO;

                i = ++satisSiraNo;
            }

            return i;
        }

        public void Show(AV001_TI_BIL_FOY Foy)
        {
            MyFoy = Foy;
            this.Show();
        }

        private void AV001_TI_BIL_SATIS_MASTERCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_SATIS_MASTER master = e.NewObject as AV001_TI_BIL_SATIS_MASTER;
            if (master == null)
                master = new AV001_TI_BIL_SATIS_MASTER();
            master.SATIS_TURU_ID = (int)SatisTur.ÝHALE_ÝLE;
            master.SATISIN_ISTENME_SEKLI_ID = (int)SatisIstemeSekli.ALACAKLI_TARAF;
            if (MyFoy != null)
            {
                master.SATISI_ISTENEN_CARI_ID = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID.Value;
                master.SATISI_ISTEYEN_CARI_ID = ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID.Value;
                master.SATIS_SORUMLU_PERSONEL_ID =
                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(MyFoy.ID)[0].
                        SORUMLU_AVUKAT_CARI_ID.Value;
            }

            master.SATIS_SIRA_NO = SatisSiraNo(MyFoy);

            // master.ICRA_FOY_ID = MyFoy.ID;
            //master.
            e.NewObject = master;

            //master.AV001_TI_BIL_SATIS_CHILDCollection.AddingNew += childList_AddingNew;

            if (!tempList.Contains(master))
                tempList.Add(master);
            master.ILAN_SEKLI = 0;
        }

        private void AV001_TI_BIL_SATIS_MASTERCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (tempList.Count > 0)
            //{
            //    if (e.ListChangedType == ListChangedType.ItemDeleted)
            //    {
            //        tempList.RemoveAt(e.NewIndex);
            //    }
            //}
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;

            #region Validate Yapýlacak

            //foreach (AV001_TI_BIL_HACIZ_MASTER n in AddNewList)
            //{
            //    string sStr = Validate(n);

            //    if (sStr != string.Empty)
            //    {
            //        XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
            //            + System.Environment.NewLine + sStr, "Uyarý");

            //        result = false;
            //        break;
            //    }
            //}

            #endregion Validate Yapýlacak

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.", "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            vgSatisMaster.Enabled = true;
            vgSatisChild.Enabled = true;
            if (c_lueDosya.EditValue != null)
                MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
        }

        private void childList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_SATIS_CHILD child = e.NewObject as AV001_TI_BIL_SATIS_CHILD;
            if (child == null)

                child = new AV001_TI_BIL_SATIS_CHILD();

            //if (tempList.Count == 1)
            //    masterIndex = 0;
            if (tempList.Count != 0 && tempList.Count > masterIndex)
            {
                child.MAL_SIRA_NO =
                    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip.SiraNo(
                        tempList[masterIndex].AV001_TI_BIL_SATIS_CHILDCollection);
                child.HACIZLI_MAL_ADEDI = 1;
                child.ADMIN_KAYIT_MI = false;
                child.KAYIT_TARIHI = DateTime.Now;
                child.KLASOR_KODU = "GENEL";
                child.KONTROL_KIM = "AVUKATPRO";
                child.KONTROL_NE_ZAMAN = DateTime.Today;
                child.KONTROL_VERSIYON = 1;
                child.STAMP = 1;
                child.SUBE_KODU = 1;
                child.TOPLAM_MIKTAR_DOVIZ_ID = 1;
                child.HACIZLI_MAL_ADEDI = 1;

                child.HACIZLI_MAL_DEGERI_DOVIZ_ID = 1;

                e.NewObject = child;
            }

            //if (!tempList[masterIndex].AV001_TI_BIL_SATIS_CHILDCollection.Contains(child))
            //    tempList[masterIndex].AV001_TI_BIL_SATIS_CHILDCollection.Add(child);
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TI_BIL_SATIS_MASTER h in tempList)
            {
                if (h.IsNew || h.IsDirty) return false;

                //if (h.IsNew || h.HasDataChanged())
            }

            return true;
        }

        private void dnSatisChild_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                frm = new frmHacizliMallar();
                frm.FormClosed += frm_FormClosed;
                frm.Show(MyFoy);
            }
        }

        private void dnSatisChild_OnListedenGetirClick(object sender, ListedenGetirEventArgs e)
        {
            frm = new frmHacizliMallar();
            frm.hacizChildID = hacizChildID;
            frm.FormClosed += frm_FormClosed;
            frm.Show(MyFoy);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm.Secilenler.Count > 0)
            {
                SecilenleriEkle();
            }
        }

        private void frmSatisGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme == null) return;

            ucIcraTarafGelismeleri.SonSatisTarihiHesapla(MyGelisme, MyFoy);
        }

        private void frmSatisGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydet_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmSatisGirisi_Load(object sender, EventArgs e)
        {
            initData();

            vgSatisMaster.FocusedRecordChanged += vgSatisMaster_FocusedRecordChanged;
            vgSatisChild.FocusedRecordChanged += vgSatisChild_FocusedRecordChanged;
            if (MyFoy != null)
                MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.ListChanged += AV001_TI_BIL_SATIS_MASTERCollection_ListChanged;

            if (IsModul)
            {
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Icra, false);
                vgSatisMaster.Enabled = false;
                vgSatisChild.Enabled = false;
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void initData()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.CariGetirBilirkisi(rlueCariBilirkisi);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
            BelgeUtil.Inits.MalKategoriGetir(rlueMalKat);
            BelgeUtil.Inits.MalTurGetir(rlueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rlueMalCins);
            BelgeUtil.Inits.CariPersonelGetir(rlueSorPerCariPer);
            BelgeUtil.Inits.CariAdliPersonelGetir(rlueSatisMemAdliPer);
            BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rlueBorcluCari });
            BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rlueAlacakliCari });
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.SatisTuruGetir(rlueSatisTuru);
            BelgeUtil.Inits.SatisIstemeSekliGetir(rlueSatýsÝstenmeSekli);
            BelgeUtil.Inits.BirimKodGetir(rlueAdetBirim);
            BelgeUtil.Inits.SatisIlanSekliGetir(rlueSatisIlanSekli);
            AvukatPro.Services.Implementations.DevExpressService.BelgeDoldur(rlueBelge);
        }

        private bool Save()
        {
            bool sonuc = false;

            if (MyFoy != null)
            {
                AddNewList.ForEach(delegate(AV001_TI_BIL_SATIS_MASTER s) { s.ICRA_FOY_ID = MyFoy.ID; });
            }

            else if ((int)c_lueDosya.EditValue > 0)
            {
                AddNewList.ForEach(delegate(AV001_TI_BIL_SATIS_MASTER s) { s.ICRA_FOY_ID = (int)c_lueDosya.EditValue; });
            }

            else
                return false;

            foreach (var item in AddNewList)
            {
                for (int rowHandle = 0; rowHandle < rlueBelge.View.RowCount; rowHandle++)
                {
                    if ((bool)rlueBelge.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        item.NN_BELGE_SATISCollection.Add(new NN_BELGE_SATIS() { BELGE_ID = (int)rlueBelge.View.GetRowCellValue(rowHandle, "Id") });
                }

                if (item.ID == 0)
                    MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.AddRange(AddNewList);
            }

            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.DeepSave(trans, AddNewList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_SATIS_CHILD>));

                foreach (var item in vgSatisChild.DataSource as TList<AV001_TI_BIL_SATIS_CHILD>)
                {
                    item.MASTER_ID = AddNewList[0].ID;
                    DataRepository.AV001_TI_BIL_SATIS_CHILDProvider.Save(trans, item);
                }

                //typeof(TList<AV001_TI_BIL_GAYRIMENKUL>),
                //typeof(TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>));

                trans.Commit();
                if (satisYenile != null)
                    satisYenile(this, new EventArgs());
                sonuc = true;

                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < tempList.Count; i++)
                {
                    MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.Remove(tempList[i]);
                }

                kaydedildi = false;

                return false;
            }

            finally
            {
                trans.Dispose();
            }

            return sonuc;
        }

        private void SecilenleriEkle()
        {
            for (int i = 0; i < frm.Secilenler.Count; i++)
            {
                AV001_TI_BIL_SATIS_CHILD child =
                    ((TList<AV001_TI_BIL_SATIS_MASTER>)vgSatisMaster.DataSource)[vgSatisMaster.FocusedRecord].
                        AV001_TI_BIL_SATIS_CHILDCollection.AddNew();

                child.HACIZLI_MAL_CINS_ID = frm.Secilenler[i].HACIZLI_MAL_CINS_ID;
                child.HACIZLI_MAL_TUR_ID = frm.Secilenler[i].HACIZLI_MAL_TUR_ID;
                child.HACIZLI_MAL_KAT_ID = frm.Secilenler[i].HACIZLI_MAL_KATEGORI_ID;
                child.HACIZLI_MAL_DEGERI_DOVIZ_ID = frm.Secilenler[i].HACIZLI_MAL_DEGERI_DOVIZ_ID;
                child.HACIZLI_MAL_DEGERI = frm.Secilenler[i].HACIZLI_MAL_DEGERI.Value;
                child.HACIZLI_MAL_ADET_BIRIM_ID = frm.Secilenler[i].HACIZLI_MAL_ADET_BIRIM_ID;
                child.HACIZLI_MAL_ADEDI = frm.Secilenler[i].HACIZLI_MAL_ADEDI;
                child.HACIZLI_MAL_TOPLAM_MIKTAR = frm.Secilenler[i].HACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Value;
                child.HACIZ_CHILD_ID = frm.Secilenler[i].ID;

                child.MAL_SIRA_NO = SatisChildSiraNo(AddNewList[vgSatisMaster.FocusedRecord]);

                //MyFoy.AV001_TI_BIL_SATIS_MASTERCollection[vgSatisMaster.FocusedRecord].AV001_TI_BIL_SATIS_CHILDCollection.Add(child);
            }

            vgSatisChild.DataSource =
                ((TList<AV001_TI_BIL_SATIS_MASTER>)vgSatisMaster.DataSource)[vgSatisMaster.FocusedRecord].
                    AV001_TI_BIL_SATIS_CHILDCollection;
            vgSatisMaster.Refresh();
        }

        private void SetSatis(TList<AV001_TI_BIL_SATIS_MASTER> AddNewList)
        {
            TList<AV001_TI_BIL_SATIS_CHILD> childList = new TList<AV001_TI_BIL_SATIS_CHILD>();

            AddNewList.ForEach(
                delegate(AV001_TI_BIL_SATIS_MASTER master) { childList.AddRange(master.AV001_TI_BIL_SATIS_CHILDCollection); });

            vgSatisMaster.DataSource = AddNewList;

            //Düzenleme modunda ilgili child bilgisinin ekrana gelmesini saðlamak için eklendi.
            if (ChildList.Count == 0)
                vgSatisChild.DataSource = childList;
            else
                vgSatisChild.DataSource = ChildList;

            //

            AddNewList.AddingNew += AV001_TI_BIL_SATIS_MASTERCollection_AddingNew;
            childList.AddingNew += childList_AddingNew;
        }

        private void vgSatisChild_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            //int i = vgSatisMaster.FocusedRecord;
            //int j = vgSatisChild.FocusedRecord;

            //if (e.NewIndex > 0)
            //{
            //    vgSatisMaster.DataSource =
            //      MyFoy.AV001_TI_BIL_SATIS_MASTERCollection[e.NewIndex-1].AV001_TI_BIL_SATIS_CHILDCollection;

            //    vgSatisChild.DataSource =
            //        MyFoy.AV001_TI_BIL_SATIS_MASTERCollection[e.NewIndex-1].AV001_TI_BIL_SATIS_CHILDCollection;

            //}
        }

        private void vgSatisMaster_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            masterIndex = vgSatisMaster.FocusedRecord;

            if (MyFoy.AV001_TI_BIL_SATIS_MASTERCollection.Count > 0)
            {
                // MyFoy.AV001_TI_BIL_SATIS_MASTERCollection[masterIndex].AV001_TI_BIL_SATIS_CHILDCollection.AddingNew += childList_AddingNew;
                vgSatisChild.DataSource =
                    MyFoy.AV001_TI_BIL_SATIS_MASTERCollection[masterIndex].AV001_TI_BIL_SATIS_CHILDCollection;
            }
        }

        #endregion Methods

        #region Other

        //private void btnIptal_ItemClick(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        #endregion Other
    }
}