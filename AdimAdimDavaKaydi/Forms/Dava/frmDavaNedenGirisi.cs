using AdimAdimDavaKaydi.UserControls.UcDava;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Dava
{
    public partial class frmDavaNedenGirisi : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDavaNedenGirisi()
        {
            InitializeComponent();
            this.FormClosing += Form_Closing;
            this.DosyaKaydet += btnKaydet_ItemClick;
        }

        public bool Duzenleme;

        private TList<AV001_TD_BIL_DAVA_NEDEN> addNewList;

        private bool kaydedildi;

        private AV001_TD_BIL_FOY myFoy;

        [Browsable(false)]
        public TList<AV001_TD_BIL_DAVA_NEDEN> AddNewList
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
                    try
                    {
                        ucDavaNedenleri1.Yapilandir(DataRepository.TDI_KOD_ADLI_BIRIM_BOLUMProvider.GetByID
                                                        (MyFoy.DAVA_TIP_ID.Value).KOD, false);

                        //MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Clear();

                        if (AddNewList == null)
                            AddNewList = new TList<AV001_TD_BIL_DAVA_NEDEN>();

                        ucDavaNedenleri1.MyDataSource = AddNewList;

                        ucDavaNedenleri1.MyDataSource.AddingNew += DavaNedenleri_AddingNew;

                        //if (AddNewList.Count == 0)
                        //    ucDavaNedenleri1.MyDataSource.AddNew();//Kayýt formlarý default 0 kayýtla getirilecek.

                        //ucDavaNedenleri1.MyDataSource.ForEach(
                        //    delegate(AV001_TD_BIL_DAVA_NEDEN neden) { neden.ColumnChanged += neden_ColumnChanged; });
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        public void Show(AV001_TD_BIL_FOY foy)
        {
            MyFoy = foy;

            this.Show();
        }

        private void btnKaydet_ItemClick(object sender, EventArgs e)
        {
            bool result = true;
            foreach (AV001_TD_BIL_DAVA_NEDEN n in AddNewList)
            {
                string sStr = ucDavaNedenleri.Validate(n);

                if (sStr != string.Empty)
                {
                    XtraMessageBox.Show("Lütfen kayýtlarý kontrol ediniz." + System.Environment.NewLine
                                        + System.Environment.NewLine + sStr, "Uyarý");

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
            foreach (AV001_TD_BIL_DAVA_NEDEN n in AddNewList)
            {
                if (n.IsNew || n.HasDataChanged())
                    return false;
            }

            return true;
        }

        private void DavaNedenleri_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN dn = new AV001_TD_BIL_DAVA_NEDEN();
            dn.ColumnChanged += neden_ColumnChanged;

            dn.FAIZ_TALEP_TARIHI = MyFoy.DAVA_TARIHI.Value;
            dn.DAVA_EDILEN_TUTAR_DOVIZ_ID = 1;
            dn.DIGER_GIDER_DOVIZ_ID = 1;
            dn.PROTESTO_GIDERI_DOVIZ_ID = 1;
            dn.IHTAR_GIDERI_DOVIZ_ID = 1;
            dn.TUTAR_DOVIZ_ID = 1;
            dn.TAZMINAT_DOVIZ_ID = 1;
            dn.ISLAH_EDILEN_TUTAR_DOVIZ_ID = 1;
            dn.DIGER_GIDER_DOVIZ_ID = 1;
            dn.DOVIZ_ISLEM_TIPI = (byte)AvukatProLib.Extras.DavaDovizIslemTipi.Dava_Tarihinde_TL;
            dn.TAZMINAT_HESAP_TIP = (byte)DavaTazminatHesapTipi.Nispi;
            dn.DO_FAIZ_TIP_ID = 1;
            dn.FAIZ_TIP_ID = 1;
            dn.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection = new TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>();

            dn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TD_BIL_DAVA_NEDEN_KIYMETLI_EVRAK =
                new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
            dn.AV001_TI_BIL_GAYRIMENKULCollection_From_AV001_TD_BIL_DAVA_NEDEN_GAYRIMENKUL =
                new TList<AV001_TI_BIL_GAYRIMENKUL>();

            dn.AV001_TDI_BIL_GEMI_UCAK_ARACCollection_From_AV001_TD_BIL_DAVA_NEDEN_GEMI_UCAK_ARAC =
                new TList<AV001_TDI_BIL_GEMI_UCAK_ARAC>();
            dn.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TD_BIL_DAVA_NEDEN_SOZLESME_NEW =
                new TList<AV001_TDI_BIL_SOZLESME>();

            dn.KAYIT_TARIHI = DateTime.Now;
            dn.KONTROL_NE_ZAMAN = DateTime.Now;
            dn.KONTROL_KIM = AvukatProLib.Kimlik.KullaniciAdi;
            dn.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            dn.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            dn.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;

            e.NewObject = dn;

            //AV001_TD_BIL_DAVA_NEDEN newObj = e.NewObject as AV001_TD_BIL_DAVA_NEDEN;
            //if (newObj == null)
            //    newObj = new AV001_TD_BIL_DAVA_NEDEN();
            //newObj.ColumnChanged += neden_ColumnChanged;
            //e.NewObject = newObj;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
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

        private void neden_ColumnChanged(object sender, AV001_TD_BIL_DAVA_NEDENEventArgs e)
        {
            //AV001_TD_BIL_DAVA_NEDEN gonderen = sender as AV001_TD_BIL_DAVA_NEDEN;
            //if (gonderen != null)
            //    switch (e.Column)
            //    {
            //        case AV001_TD_BIL_DAVA_NEDENColumn.OLAY_SUC_TARIHI:
            //            gonderen.FAIZ_TALEP_TARIHI = gonderen.OLAY_SUC_TARIHI;
            //            gonderen.FAIZ_KARAR_TARIHI = gonderen.OLAY_SUC_TARIHI;
            //            break;
            //        case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR:
            //            gonderen.DAVA_EDILEN_TUTAR = gonderen.TUTAR;
            //            break;
            //        case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR_DOVIZ_ID:
            //            gonderen.DAVA_EDILEN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
            //            break;
            //        case AV001_TD_BIL_DAVA_NEDENColumn.VERGI_DONEMI:
            //            break;
            //        case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_TIP_ID:
            //            gonderen.FAIZ_TIP_ID = gonderen.DO_FAIZ_TIP_ID;
            //            break;
            //        case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_ORANI:
            //            gonderen.FAIZ_ORANI = gonderen.DO_FAIZ_ORANI;
            //            break;
            //        default:
            //            break;
            //    }
            AV001_TD_BIL_DAVA_NEDEN gonderen = sender as AV001_TD_BIL_DAVA_NEDEN;
            if (gonderen != null)
                switch (e.Column)
                {
                    case AV001_TD_BIL_DAVA_NEDENColumn.OLAY_SUC_TARIHI:
                        gonderen.FAIZ_TALEP_TARIHI = gonderen.OLAY_SUC_TARIHI;
                        gonderen.FAIZ_KARAR_TARIHI = gonderen.OLAY_SUC_TARIHI;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR:
                        gonderen.DAVA_EDILEN_TUTAR = gonderen.TUTAR;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.TUTAR_DOVIZ_ID:
                        gonderen.DAVA_EDILEN_TUTAR_DOVIZ_ID = gonderen.TUTAR_DOVIZ_ID;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.VERGI_DONEMI:
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_TIP_ID:
                        gonderen.FAIZ_TIP_ID = gonderen.DO_FAIZ_TIP_ID;
                        break;

                    case AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_ORANI:
                        gonderen.FAIZ_ORANI = gonderen.DO_FAIZ_ORANI;
                        break;

                    default:
                        break;
                }
            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.TAZMINAT_HESAP_TIP)
            {
                DavaTazminatHesapTipi dt = (DavaTazminatHesapTipi)gonderen.TAZMINAT_HESAP_TIP;
                if (e.Value != null)
                    ucDavaNedenleri1.TazminatYapilandir(dt);
            }

            #region Faiz Oranlarý Getir

            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.DO_FAIZ_TIP_ID)
            {
                gonderen.DO_FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                   gonderen.ISLAH_EDILEN_TUTAR_DOVIZ_ID,
                                                                   myFoy.HESAPLAMA_TARIHI);
            }
            if (e.Column == AV001_TD_BIL_DAVA_NEDENColumn.FAIZ_TIP_ID)
            {
                gonderen.FAIZ_ORANI = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)e.Value,
                                                                gonderen.ISLAH_EDILEN_TUTAR_DOVIZ_ID,
                                                                myFoy.HESAPLAMA_TARIHI);
            }

            #endregion Faiz Oranlarý Getir
        }

        private bool Save()
        {
            bool sonuc = false;

            addNewList.ForEach(delegate(AV001_TD_BIL_DAVA_NEDEN n) { n.DAVA_FOY_ID = MyFoy.ID; });

            #region <MB-20100609>

            //Dava Nedenleri toplamýnýn dava dosyasýn kaydýný saðlamak için eklendi. Föy üzerinden dava deðeri 0 geldiði için foreach ile yapýlmak zorunda kalýndý.

            decimal davaTutari = 0;
            decimal davaEdilenTutar = 0;

            foreach (var item in AddNewList)
            {
                if (item.TUTAR_DOVIZ_ID == 1)
                {
                    davaTutari += item.TUTAR;
                    davaEdilenTutar += item.DAVA_EDILEN_TUTAR;
                }
                else
                {
                    davaTutari += AvukatProLib.Hesap.DovizHelper.CevirYTL(item.TUTAR, item.TUTAR_DOVIZ_ID, DateTime.Now);
                    davaEdilenTutar += AvukatProLib.Hesap.DovizHelper.CevirYTL(item.DAVA_EDILEN_TUTAR, item.DAVA_EDILEN_TUTAR_DOVIZ_ID, DateTime.Now);
                }
            }

            //Update iþleminde, deðer olsa da MyFoy.DAVA_DEGERI = 0 göründüðünden deðer collection'dan alýndý. MB
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));

            MyFoy.DAVA_DEGERI = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Sum(vi => vi.TUTAR) + davaTutari;
            MyFoy.DAVA_DEGERI_DOVIZ_ID = 1; //TL

            MyFoy.CEZAI_SART_TOPLAMI = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Sum(vi => vi.DAVA_EDILEN_TUTAR) + davaEdilenTutar;
            myFoy.CEZAI_SART_TOPLAMI_DOVIZ_ID = 1; //TL

            #endregion <MB-20100609>

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                #region Diger Dava Nedeni Dolduruluyor

                try
                {
                    MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.ForEach(
                        delegate(AV001_TD_BIL_DAVA_NEDEN obj)
                        {
                            if (obj.DAVA_NEDEN_KOD_IDSource == null)
                                obj.DAVA_NEDEN_KOD_IDSource = DataRepository.TDI_KOD_DAVA_ADIProvider.GetByID(obj.DAVA_NEDEN_KOD_ID.Value);
                            if (obj.DAVA_NEDEN_KOD_ID.HasValue && obj.DIGER_DAVA_NEDEN == string.Empty)
                                obj.DIGER_DAVA_NEDEN = obj.DAVA_NEDEN_KOD_IDSource.DAVA_ADI;
                        });
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(typeof(frmDavaDosyaKayitForm), ex);
                }

                #endregion Diger Dava Nedeni Dolduruluyor

                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepSave(tran, AddNewList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF>), typeof(TList<AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ>));

                #region <MB-20100609>

                //Dava Nedenleri toplamýnýn dava dosyasýn kaydýný saðlamak için eklendi.

                DataRepository.AV001_TD_BIL_FOYProvider.DeepSave(tran, MyFoy);

                #endregion <MB-20100609>

                tran.Commit();
                foreach (var item in AddNewList)
                {
                    if (MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Exists(delegate(AV001_TD_BIL_DAVA_NEDEN dn) { return dn.ID == item.ID; })) continue;
                    MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Add(item);
                }
                sonuc = true;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                for (int i = 0; i < AddNewList.Count; i++)
                {
                    MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Remove(AddNewList[i]);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }

        private void ucDavaNedenleri1_ValidateNeden(object sender, ValidateRecordEventArgs e)
        {
            AV001_TD_BIL_DAVA_NEDEN neden = ucDavaNedenleri1.CurrentNeden;
            if (neden != null)
            {
                neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.Clear();
                foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
                {
                    AV001_TD_BIL_DAVA_NEDEN_TARAF dnTaraf = neden.AV001_TD_BIL_DAVA_NEDEN_TARAFCollection.AddNew();
                    dnTaraf.TARAF_CARI_ID = taraf.CARI_ID.Value;
                    dnTaraf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
                    dnTaraf.SORUMLU_OLUNAN_MIKTAR = neden.DAVA_EDILEN_TUTAR;
                    dnTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = neden.DAVA_EDILEN_TUTAR_DOVIZ_ID;
                    if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davalý && MyFoy.DAVA_TARIHI.HasValue &&
                        neden.FAIZ_KARAR_TARIHI.HasValue)
                    {
                        AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ faiz =
                            dnTaraf.AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection.AddNew();
                        faiz.FAIZ_BASLANGIC_TARIHI = neden.FAIZ_KARAR_TARIHI.Value;
                        faiz.FAIZ_BITIS_TARIHI = MyFoy.DAVA_TARIHI.Value;
                        faiz.SABIT_FAIZ = neden.SABIT_FAIZ_UYGULA;
                        faiz.FAIZ_TIP_ID = neden.DO_FAIZ_TIP_ID;
                        faiz.FAIZ_ORANI = neden.DO_FAIZ_ORANI;
                        if (neden.DO_FAIZ_TIP_ID == neden.FAIZ_TIP_ID ||
                            (neden.SABIT_FAIZ_UYGULA && neden.FAIZ_ORANI == neden.DO_FAIZ_ORANI))
                        {
                            faiz.FAIZ_BITIS_TARIHI = MyFoy.SON_HESAP_TARIHI;
                        }
                        else
                        {
                            AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZ faiz2 =
                                dnTaraf.AV001_TD_BIL_DAVA_NEDEN_TARAF_FAIZCollection.AddNew();
                            faiz2.FAIZ_BASLANGIC_TARIHI = MyFoy.DAVA_TARIHI.Value;
                            faiz2.FAIZ_BITIS_TARIHI = MyFoy.SON_HESAP_TARIHI;
                            faiz2.SABIT_FAIZ = neden.SABIT_FAIZ_UYGULA;
                            faiz2.FAIZ_TIP_ID = neden.FAIZ_TIP_ID;
                            faiz2.FAIZ_ORANI = neden.FAIZ_ORANI;
                        }
                    }
                }
            }
        }
    }
}