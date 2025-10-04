using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class rFrmCelseKayit : Util.BaseClasses.AvpXtraForm
    {
        public rFrmCelseKayit()
        {
            InitializeComponent();
            InitializeEvents();
            this.FormClosing += rFrmCelseKayit_FormClosing;
            c_lueDosya.EditValueChanged += c_lueDosya_EditValueChanged;
        }

        public AV001_TD_BIL_CELSE MyCelse;
        private bool _IsModul;

        private TList<AV001_TD_BIL_ARA_KARAR> addAraKarar;

        private TList<AV001_TD_BIL_CELSE> addNewList;

        private bool kaydedildi;

        private bool kayitIptal = false;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_ARA_KARAR> AddAraKarar
        {
            get { return addAraKarar; }
            set
            {
                addAraKarar = value;
                ucAraKarar1.MyDataSource = addAraKarar;

                addAraKarar.AddingNew += AV001_TD_BIL_ARA_KARARCollection_AddingNew;
            }
        }

        [Browsable(false)]
        public TList<AV001_TD_BIL_CELSE> AddNewList
        {
            get { return addNewList; }
            set { addNewList = value; }
        }

        public bool IsModul
        {
            get { return _IsModul; }
            set
            {
                _IsModul = value;
                panelControl1.Visible = value;
            }
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
                    if (AddNewList == null)
                        AddNewList = new TList<AV001_TD_BIL_CELSE>();

                    addNewList.AddingNew += celse_AddingNew;

                    //ucCelseBilgileri1.MyFoy = MyFoy;
                    //ucAraKarar1.MyFoy = myFoy;
                    if (addNewList.Count == 0)
                    {
                        if (MyCelse == null)
                        {
                            ucCelseBilgileri.Duzenlememi = false;
                            addNewList.AddNew();
                        }
                        else
                        {
                            if (MyCelse.CELSE_MI)
                                ucCelseBilgileri.Duzenlememi = false;
                            else
                                ucCelseBilgileri.Duzenlememi = true;

                            DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(AddNewList, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(TList<AV001_TD_BIL_ARA_KARAR>));
                            AddNewList.Add(MyCelse);
                        }
                    }
                    ucCelseBilgileri1.MyDataSource = AddNewList;

                    if (addNewList.Count > 0)
                    {
                        if (MyCelse != null)
                            AddAraKarar = addNewList[0].AV001_TD_BIL_ARA_KARARCollection;
                    }
                    ucCelseBilgileri1.FocusedRecordChanged += ucCelseBilgileri1_FocusedRecordChanged;
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }
        
        private void AV001_TD_BIL_ARA_KARARCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR karar = new AV001_TD_BIL_ARA_KARAR();
            karar.KAYIT_TARIHI = DateTime.Today;
            karar.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            karar.KONTROL_KIM = "AVUKATPRO";
            karar.KONTROL_NE_ZAMAN = DateTime.Today;
            karar.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            karar.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            karar.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            karar.KIM_YERINE_GETIRECEK = 0;
            karar.TARIH = AddNewList[ucCelseBilgileri1.vgRecordIndex].TARIH;
            karar.ColumnChanged += karar_ColumnChanged;
            e.NewObject = karar;
        }

        private void belgeKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            TList<NN_BELGE_DAVA> belgeList = DataRepository.NN_BELGE_DAVAProvider.GetByDAVA_FOY_ID(MyFoy.ID);
            TList<AV001_TDIE_BIL_BELGE> belgeler = new TList<AV001_TDIE_BIL_BELGE>();

            foreach (var item in belgeList)
            {
                AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(item.BELGE_ID);

                belgeler.Add(belge);
            }
            exGridBelge.DataSource = belgeler;
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TD_BIL_ARA_KARAR k in AddNewList[ucCelseBilgileri1.vgRecordIndex].AV001_TD_BIL_ARA_KARARCollection)
            {
                string sStr = ucAraKarar.Validate(k);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show(sStr, "Uyarý");

                    result = false;
                    break;
                }
            }

            if (result)
            {
                if (Save() && Is.Util.IsHelper.IsleriKaydet(MyFoy))
                {
                    kaydedildi = true;

                    if (MyCelse != null)
                        DurusmaKayittanCikisKontrol(MyCelse);
                    else if (AddNewList != null && AddNewList.Count > 0)
                        DurusmaKayittanCikisKontrol(AddNewList[0]);

                    #region <MB-20100524>

                    //Belge Kaydý yapýlabileceði için formun kayýttan sonra kapatýlmasý iptal edildi.
                    //this.Close();
                    tpCelseZapti.PageVisible = true;

                    #endregion <MB-20100524>
                }
                else
                {
                    XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                        "Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void c_lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            ucCelseBilgileri1.Enabled = true;
            ucAraKarar1.Enabled = true;
            if (c_lueDosya.EditValue != null)
                MyFoy = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)c_lueDosya.EditValue);
        }

        private void celse_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_CELSE celse = e.NewObject as AV001_TD_BIL_CELSE;
            if (celse == null)
                celse = new AV001_TD_BIL_CELSE();

            celse.CELSE_REFERANS_NO = ucCelseBilgileri.ReferansNo();
            celse.TARIH = DateTime.Today;
            celse.SAAT = DateTime.Today.ToShortTimeString();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));

            var avk = MyFoy.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FirstOrDefault(vi => !vi.YETKILI_MI);
            if (avk != null)
            {
                if (BelgeUtil.Inits._per_CariGetir == null || BelgeUtil.Inits._per_CariGetir.Count == 0)
                    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                var cariAvk = BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == avk.SORUMLU_AVUKAT_CARI_ID.Value);

                if (avk.SORUMLU_AVUKAT_CARI_ID.HasValue)
                {
                    if (celse.SORUMLU_AVUKAT_CARI1_ID == 0)
                    {
                        celse.SORUMLU_AVUKAT_CARI1_ID = cariAvk.ID;
                        celse.SORUMLU_AVUKAT_CARI2_ID = cariAvk.ID;
                    }
                    else if (celse.SORUMLU_AVUKAT_CARI2_ID == 0)
                    {
                        celse.SORUMLU_AVUKAT_CARI1_ID = cariAvk.ID;
                        celse.SORUMLU_AVUKAT_CARI2_ID = cariAvk.ID;
                    }
                }
            }

            celse.CELSE_MI = true;
            celse.AV001_TD_BIL_ARA_KARARCollection.AddingNew += AV001_TD_BIL_ARA_KARARCollection_AddingNew;
            AddAraKarar = celse.AV001_TD_BIL_ARA_KARARCollection;
            celse.KAYIT_TARIHI = DateTime.Today;
            celse.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            celse.KONTROL_KIM = "AVUKATPRO";
            celse.KONTROL_NE_ZAMAN = DateTime.Today;
            celse.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            celse.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            celse.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;

            //celse.
            e.NewObject = celse;
        }

        private bool CikabilirMi()
        {
            if (addNewList == null)
                return true;

            foreach (AV001_TD_BIL_CELSE c in AddNewList)
                if (c.IsNew || c.HasDataChanged())
                    return false;

            return true;
        }

        private void DurusmaKayittanCikisKontrol(AV001_TD_BIL_CELSE celse)
        {
            if (celse.CELSEYE_GIRILDI_MI.HasValue && celse.CELSEYE_GIRILDI_MI.Value)
            {
                DialogResult dr = XtraMessageBox.Show("Kayýt Tamamlandý.\r\nKarara Baðlandý mý ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    DialogResult drMessage = XtraMessageBox.Show("Lütfen Karar Giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (drMessage == DialogResult.OK)
                    {
                        frmHukumKayit frm = new frmHukumKayit();
                        frm.Show(MyFoy);
                    }
                }
                else
                {
                    DialogResult drMessage = XtraMessageBox.Show("Lütfen Yeni Duruþma / Ýnceleme Tarihi Giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (drMessage == DialogResult.OK)
                    {
                        rFrmCelseKayit frm = new rFrmCelseKayit();
                        frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                        frm.Show(MyFoy);
                    }
                }
            }
            else
                XtraMessageBox.Show("Kayýt Tamamlandý.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exGridBelge_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();

            belgeKayit.ucBelgeKayitUfak1.CelseEkranindanmi = true;
            belgeKayit.ucBelgeKayitUfak1.OpenedRecord = MyFoy;
            belgeKayit.MyDataSource = MyFoy.AV001_TDIE_BIL_BELGECollection_From_NN_BELGE_DAVA;

            //.MdiParent = null;
            belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            belgeKayit.FormClosed += belgeKayit_FormClosed;
            belgeKayit.Show();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucCelseBilgileri1.BindData();
        }

        //Duruþmaya girildiði bilgisinin istenilen koþula göre kontrolünün yapýlabilmesi için eklendi. MB
        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += btnKaydet_ItemClick;
        }

        private void karar_ColumnChanged(object sender, AV001_TD_BIL_ARA_KARAREventArgs e)
        {
            AV001_TD_BIL_ARA_KARAR krr = sender as AV001_TD_BIL_ARA_KARAR;
            if (krr.TARIH != null && krr.YERINE_GETIRME_GUN != null)
            {
                DateTime trh = krr.TARIH;
                int gun = 0;
                gun = (int)krr.YERINE_GETIRME_GUN;
                krr.YERINE_GETIRME_TARIH = trh.AddDays(Convert.ToDouble(gun));
            }
        }

        private void rFrmCelseKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildi) return;

            if (!CikabilirMi())
            {
                DialogResult dr = XtraMessageBox.Show("Yapýlan deðiþiklikleri kaydetmediniz.Þimdi kaydedilsin mi?", "Vazgeç", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        private void rFrmCelseKayit_Load(object sender, EventArgs e)
        {
            if (_IsModul)
            {
                //c_lueDosya.Enter += delegate {
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(c_lueDosya, AvukatProLib.Extras.Modul.Dava, false);

                //};

                ucCelseBilgileri1.Enabled = false;
                ucAraKarar1.Enabled = false;
            }
            if (BelgeUtil.Inits.PaketAdi != 1) splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private bool Save()
        {
            kayitIptal = false;

            foreach (AV001_TD_BIL_CELSE c in AddNewList)
            {
                if (c.CELSE_MI)
                {
                    if (c.TARIH <= DateTime.Today)//MB
                    {
                        if (!c.CELSEYE_GIRILDI_MI.HasValue)
                        {
                            XtraMessageBox.Show(c.TARIH + c.SAAT + " tarihli duruþma için duruþmaya \r\ngirilip girilmediðini iþaretlemeden \r\nkayýt iþlemi gerçekleþtirilemez.", "ÝPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            kayitIptal = true;
                            break;
                        }
                    }
                }

                c.DAVA_FOY_ID = MyFoy.ID;
                foreach (AV001_TD_BIL_ARA_KARAR item in c.AV001_TD_BIL_ARA_KARARCollection)
                {
                    if (MyFoy != null && MyFoy.AV001_TD_BIL_ARA_KARARCollection.Exists(delegate(AV001_TD_BIL_ARA_KARAR karar) { return karar.ID == item.ID; })
                        )
                        continue;

                    else if (c_lueDosya.EditValue != null && (int)c_lueDosya.EditValue > 0)
                        addNewList.ForEach(delegate(AV001_TD_BIL_CELSE karar) { karar.ID = (int)c_lueDosya.EditValue; });

                    //else
                    //return false;

                    #region ara karar kayýt saðlanmasý

                    if (MyFoy != null)
                    {
                        if (item.DAVA_FOY_ID == null)
                            item.DAVA_FOY_ID = MyFoy.ID;
                    }

                    #endregion ara karar kayýt saðlanmasý
                }
            }

            if (kayitIptal)
                return false;

            foreach (AV001_TD_BIL_CELSE cl in AddNewList)
            {
                for (int rowHandle = 0; rowHandle < ucCelseBilgileri1.lueBelge.Properties.View.RowCount; rowHandle++)
                {
                    if ((bool)ucCelseBilgileri1.lueBelge.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        cl.NN_BELGE_CELSECollection.Add(new NN_BELGE_CELSE() { BELGE_ID = (int)ucCelseBilgileri1.lueBelge.Properties.View.GetRowCellValue(rowHandle, "Id") });
                }

                if (MyFoy.AV001_TD_BIL_CELSECollection.Exists(delegate(AV001_TD_BIL_CELSE celse) { return celse.ID == cl.ID; })) continue;
                MyFoy.AV001_TD_BIL_CELSECollection.AddRange(AddNewList);
            }
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TD_BIL_CELSEProvider.DeepSave(trans, MyFoy.AV001_TD_BIL_CELSECollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_ARA_KARAR>), typeof(TList<NN_BELGE_CELSE>));

                trans.Commit();

                foreach (AV001_TD_BIL_CELSE c in AddNewList)
                {
                    foreach (AV001_TD_BIL_ARA_KARAR item in c.AV001_TD_BIL_ARA_KARARCollection)
                    {
                        if (
                            MyFoy.AV001_TD_BIL_ARA_KARARCollection.Exists(delegate(AV001_TD_BIL_ARA_KARAR karar) { return karar.ID == item.ID; })) continue;
                        MyFoy.AV001_TD_BIL_ARA_KARARCollection.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                    MyFoy.AV001_TD_BIL_CELSECollection.RemoveEntity(AddNewList[i]);

                return false;
            }
            finally
            {
                trans.Dispose();
            }

            return true;
        }

        private void ucCelseBilgileri1_FocusedRecordChanged(object sender,
                                                            DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            if (e.NewIndex >= 0)
                if (AddNewList.Count >= e.NewIndex && AddNewList.Count > 0)
                    addAraKarar = AddNewList[e.NewIndex].AV001_TD_BIL_ARA_KARARCollection;
        }

        //#region IslemMethods

        //void IslemTamamlandi()
        //{
        //    bool result = true;
        //    foreach (AV001_TD_BIL_ARA_KARAR k in
        //        AddNewList[ucCelseBilgileri1.vgRecordIndex].AV001_TD_BIL_ARA_KARARCollection)
        //    {
        //        string sStr = ucAraKarar.Validate(k);

        //        if (sStr != string.Empty)
        //        {
        //            XtraMessageBox.Show(sStr, "Uyarý");

        //            result = false;
        //            break;
        //        }
        //    }

        //    if (result)
        //    {
        //        if (Save())
        //        {
        //            kaydedildi = true;

        //            //XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
        //            //    MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            this.Close();
        //        }
        //        else
        //        {
        //            kaydedildi = false;
        //            return;
        //          //  XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
        //          //"Kaydet ve Çýk", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        //void DosyadanCikis()
        //{
        //    this.Close();
        //}

        //#endregion

        //#region OverrideMedhots

        //public override void Kaydet()
        //{
        //    base.Kaydet();
        //    IslemTamamlandi();
        //}
        //public override void Cikis()
        //{
        //    base.Cikis();
        //    DosyadanCikis();
        //}

        //#endregion
    }
}