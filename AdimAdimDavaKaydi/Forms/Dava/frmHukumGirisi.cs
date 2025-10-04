using AdimAdimDavaKaydi.DavaTakip;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmHukumGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmHukumGirisi()
        {
            InitializeComponent();
            this.FormClosing += frmHukumGirisi_FormClosing;
            InitializeEvents();
        }

        private TList<AV001_TD_BIL_MAHKEME_HUKUM> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_MAHKEME_HUKUM> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        [Browsable(false)]
        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    BelgeUtil.Inits.DavaNedenGetir(gvMahkemeHukum, MyFoy);

                    if (AddNewList == null)
                    {
                        AddNewList = new TList<AV001_TD_BIL_MAHKEME_HUKUM>();
                        AddNewList.AddNew();
                    }
                    AddNewList.AddingNew += AddNewList_AddingNew;
                    //ucHukumBilgileri1.MyDataSource = AddNewList;
                    dataNavigatorExtended1.DataSource = AddNewList;
                    gvMahkemeHukum.DataSource = AddNewList;
                }
                else
                    DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.DeepLoad(AddNewList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM>));
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;
            //if (MyFoy != null)
            //{
            //    ucHukumBilgileri1.DavaFoyID = MyFoy.ID;
            //    ucHukumBilgileri1.MyFoy = MyFoy;
            //}
            this.Show();
        }
        
        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_MAHKEME_HUKUM addNew = e.NewObject as AV001_TD_BIL_MAHKEME_HUKUM;
            if (addNew == null)
                addNew = new AV001_TD_BIL_MAHKEME_HUKUM();

            addNew.KLASOR_KODU = "GENEL";
            addNew.KONTROL_KIM = "AVUKATPRO";
            addNew.KONTROL_NE_ZAMAN = DateTime.Today;
            addNew.KONTROL_VERSIYON = 1;
            addNew.STAMP = 1;
            addNew.SUBE_KODU = 1;
            addNew.HUKUM_DEGER_DOVIZ_ID = 1;
            addNew.KAYIT_TARIHI = DateTime.Today;
            addNew.MUSADERE_DEGER_DOVIZ_ID = 1;
            addNew.PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = 1;
            addNew.SORUMLULUK_MIKTARI_DOVIZ_ID = 1;
            addNew.TARAF_CARI_ID = ucDavaTarafBilgileri.CurrTarafId;
            addNew.DAVA_NEDEN_ID = ucDavaTarafBilgileri.CurrTalepId;
            addNew.KARAR_NO = DateTime.Today.Year + "/";

            AV001_TD_BIL_MAHKEME_HUKUM_TARAF taraf =
                addNew.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.AddNew();

            taraf.SORUMLULUK_MIKTARI_DOVIZ_ID = 1;
            int? borclu = null;
            if (ucDavaTarafBilgileri.CurrTarafId <= 0)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_FOY_TARAF>));
                TList<AV001_TD_BIL_FOY_TARAF> trf = MyFoy.AV001_TD_BIL_FOY_TARAFCollection;
                foreach (var item in trf)
                {
                    if (item.TARAF_KODU == (int)AvukatProLib.Extras.TarafKodu.KarsiTaraf)
                        borclu = item.CARI_ID;
                }
            }
            else
                borclu = ucDavaTarafBilgileri.CurrTarafId;

            taraf.TARAF_CARI_ID = borclu;
            taraf.KAYIT_TARIHI = DateTime.Today;
            taraf.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            taraf.KONTROL_KIM = "AVUKATPRO";
            taraf.KONTROL_NE_ZAMAN = DateTime.Today;
            taraf.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            taraf.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            taraf.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            e.NewObject = addNew;
        }

        private void btnKaydetCik_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TD_BIL_MAHKEME_HUKUM m in AddNewList)
            {
                string sStr = Validate(m);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show(sStr, "Uyarý");

                    result = false;
                    break;
                }
            }

            if (result)
            {
                if (Save())
                {
                    kaydedildi = true;

                    XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CikabilirMi()
        {
            foreach (AV001_TD_BIL_MAHKEME_HUKUM h in AddNewList)
            {
                if (h.IsNew || h.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void frmHukumGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?",
                                                      "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    btnKaydetCik_ItemClick(null, null);

                    if (!kaydedildi)
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void frmHukumGirisi_Load(object sender, EventArgs e)
        {
            initData();

            #region <MB-20100615>

            //dava Tipine göre ekranýnýn biçimlenmesi saðlandý.

            gvMahkemeHukum.FocusedRow = rowDAVA_NEDEN_ID;
            SendKeys.Send("Tab");
            //gvMahkemeHukum.FocusedRow = rowTARAF_CARI_ID;
            //.SetCellValue(rowDAVA_NEDEN_ID, 0, MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0].ID);
            //grlueDavaNeden.OwnerEdit.EditValue = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection[0].ID;

            if (MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.Ceza ||
                MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.AsCeza ||
                MyFoy.DAVA_TIP_ID == (int)AdimAdimDavaKaydi.DavaTakip.GelismeHelper.DavaTip.Icra_Ceza)
            {
                multiEditorParayaCevrilenMiktar.Visible = true;
                multiEditorMusadereDeger.Visible = true;
                multiEditorMahkumiyetGAY.Visible = true;
                multiEditorHukumTipT.Visible = true;
                multiEditorEhliyet.Visible = true;
                multiEditorMeslek.Visible = true;
                multiEditorKamu.Visible = true;
                multiEditorCeza.Visible = true;
                multiEditorInfKesT.Visible = true;

                //Hukuk Dosyalarýn görünüyor.
                multiEditorSorumlulukMiktari.Visible = false;
                multiEditorHukumDeger.Visible = false;
            }

            #endregion <MB-20100615>
        }

        private void grlueHukumCelse_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag == "rFrmCelse")
            {
                rFrmCelseKayit celse = new rFrmCelseKayit();
                celse.MyFoy = MyFoy;
                celse.Show();
            }
        }

        private void grlueHukumCelse_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            rFrmCelseKayit celse = new rFrmCelseKayit();
            celse.MyFoy = MyFoy;
            celse.Show();
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydetCik_ItemClick;
        }

        private void initData()
        {
            BelgeUtil.Inits.DavaNedenGetir(MyFoy, grlueDavaNeden);
            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.HukumGetir(rlueHukum);
            BelgeUtil.Inits.HukumTipGetir(rlueHukumTip);
            BelgeUtil.Inits.ParaBicimiAyarla(tutar);
            BelgeUtil.Inits.DavaEdilenTarafGetir(MyFoy, new[] { rlueTarafCari });
            BelgeUtil.Inits.HukumCelseGetir(rlueHukumCelse, MyFoy);
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TD_BIL_MAHKEME_HUKUM h) { h.DAVA_FOY_ID = MyFoy.ID; });

            //MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection.AddRange(AddNewList);

            foreach (AV001_TD_BIL_MAHKEME_HUKUM mh in AddNewList)
            {
                if (
                    MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection.Exists(
                        delegate(AV001_TD_BIL_MAHKEME_HUKUM hukum) { return hukum.ID == mh.ID; })) continue;
                MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection.AddRange(AddNewList);
            }

            //MyFoy.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.Clear();
            //foreach (AV001_TD_BIL_MAHKEME_HUKUM_TARAF item in ucHukumBilgileri1.MyDataSource)
            //{
            //    MyFoy.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection.Add(item);
            //}

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();
                AV001_TD_BIL_MAHKEME_HUKUM_TARAF mm = new AV001_TD_BIL_MAHKEME_HUKUM_TARAF();

                DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_MAHKEME_HUKUMCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_MAHKEME_HUKUM_TARAF>));
                DataRepository.AV001_TD_BIL_MAHKEME_HUKUM_TARAFProvider.DeepSave(tran, MyFoy.AV001_TD_BIL_MAHKEME_HUKUM_TARAFCollection);

                tran.Commit();

                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                //AddNewList.Clear();
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private string Validate(AV001_TD_BIL_MAHKEME_HUKUM row)
        {
            //row.AddValidationRuleHandler(CommonRules.NotNull, "HUKUM_TARIHI");
            //row.AddValidationRuleHandler(CommonRules.NotNull, "HUKUM_TIP_ID");
            //row.AddValidationRuleHandler(CommonRules.NotNull, "KARAR_NO");

            //row.Validate();

            StringBuilder sb = new StringBuilder();

            if (row.DAVA_NEDEN_ID == 0)
                sb.AppendLine("* Dava nedeni boþ olamaz.");

            //if (!row.HUKUM_TIP_ID.HasValue)
            //    sb.AppendLine("* Hüküm tipi boþ olamaz.");

            if (row.KARAR_NO == string.Empty)
                sb.AppendLine("* Karar no boþ olamaz");

            if (row.HUKUM_ID == 0)
                sb.AppendLine("* Hüküm boþ olamaz");

            return sb.ToString();
        }
    }
}