using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.Forms.LayForm;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.UserControls;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;
using AvukatProLib.Extras;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
//using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKlasorYeni : AvpXtraForm
    {
        #region <MB-20102601> LOAD

        public frmKlasorYeni()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public static bool MasraflarYuklendi = false;

        public static bool OdemelerYuklendi = false;

        private AvukatProLib.Arama.AvpDataContext db = BelgeUtil.Inits.context;

        public AV001_TDIE_BIL_PROJE MyCurrentProje { get; set; }

        public TList<AV001_TDIE_BIL_PROJE> MyDataSource { get; set; }

        public void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmKlasorYeni_Button_Kaydet_Click;
            this.Button_Word_Click += frmKlasorYeni_Button_Word_Click;
            this.Button_Excel_Click += frmKlasorYeni_Button_Excel_Click;
            this.Button_PDF_Click += frmKlasorYeni_Button_PDF_Click;
            this.Button_Yeni_Click += frmKlasorYeni_Button_Yeni_Click;
            this.Button_Hesapla_Click += frmKlasorYeni_Button_Hesapla_Click;
            this.Button_Yazdir_Click += frmKlasorYeni_Button_Yazdir_Click;
            this.Button_HesaplanmisKalemler_Click += frmKlasorYeni_Button_HesaplanmisKalemler_Click;
        }

        public void Show(TList<AV001_TDIE_BIL_PROJE> foys)
        {
            //todo: canan tarafından takip ve arama ekranlarından klasörün show edilmesi tarafından eklendi 12.03.2010
            if (foys != null && foys.Count > 0)
            {
                BindLookUps();
                int klasorID = foys[0].ID;
                AV001_TDIE_BIL_PROJE secilenProje = foys[0];
                bndProje.DataSource = secilenProje;
                lueAra.EditValue = klasorID;
                MyCurrentProje = secilenProje;
                ucIcraHesapCetveli1.MyProje = secilenProje;

                TList<AV001_TDIE_BIL_PROJE> projelerim = new TList<AV001_TDIE_BIL_PROJE> { secilenProje };
                MyDataSource = projelerim;

                ProjeTaraflariYukle(klasorID);

                DeepLoadProje(secilenProje);
                DeepLoadProjeTamamlandı(secilenProje);

                tabbedControlGroup2.SelectedTabPage = layoutControlGroup9;

                TaraflariDoldur(secilenProje);
            }
            this.Show();
        }

        public void Show(List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE> foys)
        {
            TList<AV001_TDIE_BIL_PROJE> projeList = new TList<AV001_TDIE_BIL_PROJE>();

            projeList.Add(DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(foys[0].ID));
            this.Show(projeList);
        }

        private void frmKlasorYeni_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ProjeAdGetirYenile(lueAra);
            BelgeUtil.Inits.KrediGrubu(lueKrediGrubu);

            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, Modul.Klasor);

            //lueOzelKod1.Properties.NullText = "Seç";
            //BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, Modul.Klasor);

            //lueOzelKod2.Properties.NullText = "Seç";
            //BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, Modul.Klasor);

            //lueOzelKod3.Properties.NullText = "Seç";
            //BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, Modul.Klasor);

            //lueOzelKod4.Properties.NullText = "Seç";
            //BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, Modul.Klasor);

            frmOdemePlani.HesapTipiGetir(lueHesapTipi);
            this.c_titemHesaplanmisKalemler.ToolTipText = "Simülasyona Gönder";
            this.ucGorevler1.Saved += ucGorevler1_Saved;
        }

        #endregion <MB-20102601> LOAD

        #region <MB-20102601> METHODS

        private Dictionary<int, decimal> MasrafToplami = new Dictionary<int, decimal>();

        public static int KullaniciSubeIDGetir(int cariID)
        {
            var kullanici = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetByCARI_ID(cariID).FirstOrDefault();
            if (kullanici != null)
                return kullanici.KULLANICI_SUBE_ID;
            else
                return 2;//Merkez
        }

        public void Kaydet()
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                AV001_TDIE_BIL_PROJE proje = bndProje.Current as AV001_TDIE_BIL_PROJE;

                //proje.SUBE_KOD_ID = KullaniciSubeIDGetir(proje.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Find(vi => !vi.YETKILI_MI.Value).CARI_ID);
                TList<AV001_TDIE_BIL_PROJE_SORUMLU> projeSorumlulari = new TList<AV001_TDIE_BIL_PROJE_SORUMLU>();
                if (aV001TDIEBILPROJESORUMLUCollectionBindingSource.List != null)
                    projeSorumlulari = aV001TDIEBILPROJESORUMLUCollectionBindingSource.List as TList<AV001_TDIE_BIL_PROJE_SORUMLU>;

                //Klasörün sorumlusunun, icra, dava, hazırlık dosyasının sorumlusu ile aynı olup olmadığının kontrolünün yapılabilmesi için eklendi. Klasörün sorumlusu değiştirildiğinde, eski sorumlusunun dosyanın sorumlusu ile aynı olup olmadığı kontrolünü yapabilmemizi sağlıyor.
                AV001_TDIE_BIL_PROJE_SORUMLU projeEskiSorumlu = DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByPROJE_ID(proje.ID).Where(vi => vi.YETKILI_MI == true).FirstOrDefault();

                #region <MB-20100527>

                // Projenin sorumlularında bir değişiklik olunca bu sorumluların projedeki icra, dava, soruşturma dosyalarındaki sorumlu avukatlara da yansıması için eklendi.
                TList<AV001_TI_BIL_FOY> icraFoyList = DataRepository.AV001_TI_BIL_FOYProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(proje.ID);
                TList<AV001_TD_BIL_FOY> davaFoyList = DataRepository.AV001_TD_BIL_FOYProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_DAVA_FOY(proje.ID);
                TList<AV001_TD_BIL_HAZIRLIK> hazirlikFoyList = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_HAZIRLIK(proje.ID);

                #endregion <MB-20100527>

                tran.BeginTransaction();

                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(tran, proje, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TEKLIF_KARAR>), typeof(TList<AV001_TDIE_BIL_PROJE_HESAP>), typeof(TList<AV001_TDIE_BIL_PROJE_KREDI_BORCLUSU>));

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                try
                {
                    cn.AddParams("@PROJE_SUBE_ID", lueSube.EditValue);
                    cn.AddParams("@BEKLENEN_BITIS_TARIHI", dateBeklenenBitisTarihi.EditValue);
                    cn.AddParams("@KAZANMA_ORANI", spinKazanmaOrani.EditValue);
                    cn.AddParams("@ID", proje.ID);
                    cn.ExcuteQuery("update dbo.AV001_TDIE_BIL_PROJE set PROJE_SUBE_ID=@PROJE_SUBE_ID, KAZANMA_ORANI=@KAZANMA_ORANI, BEKLENEN_BITIS_TARIHI=@BEKLENEN_BITIS_TARIHI where ID=@ID");
                }
                catch { ;}
                //DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.Save(tran, proje.AV001_TDIE_BIL_PROJE_HESAPCollection);
                if (projeSorumlulari != null)
                {
                    DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.Save(tran, projeSorumlulari);

                    #region <MB-20100527>

                    // Projenin sorumlularında bir değişiklik olunca bu sorumluların projedeki icra, dava, soruşturma dosyalarındaki sorumlu avukatlara da yansıması için eklendi.

                    #region İCRA

                    if (icraFoyList != null)
                    {
                        icraFoyList.ForEach(icra =>
                        {
                            if (icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(tran, icra, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));

                            if (projeEskiSorumlu != null && icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI).Count > 0 && projeEskiSorumlu.CARI_ID == icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID.Value)
                            {
                                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.Delete(tran, icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection);
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    AV001_TI_BIL_FOY_SORUMLU_AVUKAT icraSorumluAvukat = new AV001_TI_BIL_FOY_SORUMLU_AVUKAT();
                                    icraSorumluAvukat.ICRA_FOY_ID = icra.ID;
                                    icraSorumluAvukat.SORUMLU_AVUKAT_CARI_ID = sorumlu.CARI_ID;
                                    if (sorumlu.YETKILI_MI.HasValue)
                                        icraSorumluAvukat.YETKILI_MI = sorumlu.YETKILI_MI.Value;
                                    else
                                        icraSorumluAvukat.YETKILI_MI = false;

                                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.Save(tran, icraSorumluAvukat);
                                }
                            }
                            else
                            {
                                if (icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI == false).Count != 0)
                                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.Delete(tran, icra.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(vi => vi.YETKILI_MI == false).FirstOrDefault());
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    if (sorumlu.YETKILI_MI != true)
                                    {
                                        AV001_TI_BIL_FOY_SORUMLU_AVUKAT icraSorumluAvukat = new AV001_TI_BIL_FOY_SORUMLU_AVUKAT();
                                        icraSorumluAvukat.ICRA_FOY_ID = icra.ID;
                                        icraSorumluAvukat.SORUMLU_AVUKAT_CARI_ID = sorumlu.CARI_ID;
                                        icraSorumluAvukat.YETKILI_MI = false;
                                        DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.Save(tran, icraSorumluAvukat);
                                    }
                                }
                            }
                        });
                    }

                    #endregion İCRA

                    #region DAVA

                    if (davaFoyList != null)
                    {
                        davaFoyList.ForEach(dava =>
                        {
                            if (dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(tran, dava, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT>));
                            if (projeEskiSorumlu != null && dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI).Count > 0 && projeEskiSorumlu.CARI_ID == dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI).FirstOrDefault().SORUMLU_AVUKAT_CARI_ID.Value)
                            {
                                DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.Delete(tran, dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection);
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    AV001_TD_BIL_FOY_SORUMLU_AVUKAT davaSorumluAvukat = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                                    davaSorumluAvukat.DAVA_FOY_ID = dava.ID;
                                    davaSorumluAvukat.SORUMLU_AVUKAT_CARI_ID = sorumlu.CARI_ID;
                                    if (sorumlu.YETKILI_MI.HasValue)
                                        davaSorumluAvukat.YETKILI_MI = sorumlu.YETKILI_MI.Value;
                                    else
                                        davaSorumluAvukat.YETKILI_MI = false;

                                    DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.Save(tran, davaSorumluAvukat);
                                }
                            }
                            else
                            {
                                if (dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => vi.YETKILI_MI == false).Count != 0)
                                    DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.Delete(tran, dava.AV001_TD_BIL_FOY_SORUMLU_AVUKATCollection.Where(vi => vi.YETKILI_MI == false).FirstOrDefault());
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    if (sorumlu.YETKILI_MI != true)
                                    {
                                        AV001_TD_BIL_FOY_SORUMLU_AVUKAT davaSorumluAvukat = new AV001_TD_BIL_FOY_SORUMLU_AVUKAT();
                                        davaSorumluAvukat.DAVA_FOY_ID = dava.ID;
                                        davaSorumluAvukat.SORUMLU_AVUKAT_CARI_ID = sorumlu.CARI_ID;
                                        davaSorumluAvukat.YETKILI_MI = false;
                                        DataRepository.AV001_TD_BIL_FOY_SORUMLU_AVUKATProvider.Save(tran, davaSorumluAvukat);
                                    }
                                }
                            }
                        });
                    }

                    #endregion DAVA

                    #region HAZIRLIK

                    if (hazirlikFoyList != null)
                    {
                        hazirlikFoyList.ForEach(hazirlik =>
                        {
                            if (hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count == 0)
                                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(tran, hazirlik, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));

                            if (projeEskiSorumlu != null && hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.FindAll(vi => vi.YETKILI_MI).Count > 0 && projeEskiSorumlu.CARI_ID == hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.FindAll(vi => vi.YETKILI_MI).FirstOrDefault().CARI_ID.Value)
                            {
                                DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.Delete(tran, hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection);
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    AV001_TD_BIL_HAZIRLIK_SORUMLU hazirlikSorumluAvukat = new AV001_TD_BIL_HAZIRLIK_SORUMLU();
                                    hazirlikSorumluAvukat.HAZIRLIK_ID = hazirlik.ID;
                                    hazirlikSorumluAvukat.CARI_ID = sorumlu.CARI_ID;
                                    if (sorumlu.YETKILI_MI.HasValue)
                                        hazirlikSorumluAvukat.YETKILI_MI = sorumlu.YETKILI_MI.Value;
                                    else
                                        hazirlikSorumluAvukat.YETKILI_MI = false;

                                    DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.Save(tran, hazirlikSorumluAvukat);
                                }
                            }
                            else
                            {
                                if (
                                    hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.FindAll(vi => vi.YETKILI_MI == false).Count != 0)
                                    DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.Delete(tran, hazirlik.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Where(vi => vi.YETKILI_MI == false).FirstOrDefault());
                                foreach (var sorumlu in projeSorumlulari)
                                {
                                    if (sorumlu.YETKILI_MI != true)
                                    {
                                        AV001_TD_BIL_HAZIRLIK_SORUMLU hazirlikSorumluAvukat
                                            = new AV001_TD_BIL_HAZIRLIK_SORUMLU();
                                        hazirlikSorumluAvukat.HAZIRLIK_ID = hazirlik.ID;
                                        hazirlikSorumluAvukat.CARI_ID = sorumlu.CARI_ID;
                                        hazirlikSorumluAvukat.YETKILI_MI = false;
                                        DataRepository.AV001_TD_BIL_HAZIRLIK_SORUMLUProvider.Save(tran, hazirlikSorumluAvukat);
                                    }
                                }
                            }
                        });
                    }

                    #endregion HAZIRLIK

                    #endregion <MB-20100527>
                }

                tran.Commit();

                XtraMessageBox.Show("Değişiklikler başarı ile kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BelgeUtil.Inits.ProjeAdGetirYenile(lueAra);
                lueAra.EditValue = proje.ID;
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        public void KlasorRapor()
        {
            var rapor = DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1203);

            AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editor = new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();
            editor.Show(rapor, (bndProje.Current as AV001_TDIE_BIL_PROJE));
        }

        private void AlacakIslemleri(AV001_TI_BIL_ALACAK_NEDEN aNedenTakipsiz, AV001_TI_BIL_ALACAK_NEDEN foyAlacak, AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI takipliAlacak)
        {
            #region <MB-20101203>

            //Takip silinince alacak bilgilerinin klasöre geri gelmesini sağlıyor.

            aNedenTakipsiz.ISLEME_KONAN_TUTAR = foyAlacak.ISLEME_KONAN_TUTAR;
            aNedenTakipsiz.ISLEME_KONAN_TUTAR_DOVIZ_ID = foyAlacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;

            if (aNedenTakipsiz.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNedenTakipsiz, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

            if (foyAlacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foyAlacak, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

            aNedenTakipsiz.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.ForEach(taraf => { AlacakTarafOlustur(aNedenTakipsiz.ID, AlacakNedenTarafList, taraf); });

            foyAlacak.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.ForEach(taraf =>
            {
                if (aNedenTakipsiz.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Find(vi => vi.TARAF_CARI_ID == taraf.TARAF_CARI_ID) == null)
                    AlacakTarafOlustur(aNedenTakipsiz.ID, AlacakNedenTarafList, taraf);
            });

            AlacakNedenList.Add(aNedenTakipsiz);
            TakipliAlacakList.Add(takipliAlacak);

            #endregion <MB-20101203>
        }

        private void AlacakTarafOlustur(int aNedenID, TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> liste, AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf)
        {
            #region <MB-20101203>

            //Takip silindiğinde alacağın taraflarının yeniden oluşturulmasını sağlıyor.

            AV001_TI_BIL_ALACAK_NEDEN_TARAF trf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
            trf.ICRA_ALACAK_NEDEN_ID = aNedenID;
            trf.TARAF_CARI_ID = taraf.TARAF_CARI_ID;
            trf.TARAF_SIFAT_ID = taraf.TARAF_SIFAT_ID;
            trf.SORUMLU_OLUNAN_MIKTAR = taraf.SORUMLU_OLUNAN_MIKTAR;
            trf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = taraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID;
            trf.PROTESTO_GIDERI = taraf.PROTESTO_GIDERI;
            trf.PROTESTO_GIDERI_DOVIZ_ID = taraf.PROTESTO_GIDERI_DOVIZ_ID;
            trf.IHTAR_GIDERI = taraf.IHTAR_GIDERI;
            trf.IHTAR_GIDERI_DOVIZ_ID = taraf.IHTAR_GIDERI_DOVIZ_ID;
            trf.IHTAR_TEBLIG_TARIHI = taraf.IHTAR_TEBLIG_TARIHI;
            trf.IHTAR_TARIHI = taraf.IHTAR_TARIHI;
            trf.TEMERRUT_TARIHI = taraf.TEMERRUT_TARIHI;
            trf.TAKIP_CIKISI = taraf.TAKIP_CIKISI;
            trf.TAKIP_CIKISI_DOVIZ_ID = taraf.TAKIP_CIKISI_DOVIZ_ID;
            trf.SONRAKI_FAIZ = taraf.SONRAKI_FAIZ;
            trf.SONRAKI_FAIZ_DOVIZ_ID = taraf.SONRAKI_FAIZ_DOVIZ_ID;
            trf.BSMV_TS = taraf.BSMV_TS;
            trf.BSMV_TS_DOVIZ_ID = taraf.BSMV_TS_DOVIZ_ID;
            trf.ILK_GIDERLER = taraf.ILK_GIDERLER;
            trf.ILK_GIDERLER_DOVIZ_ID = taraf.ILK_GIDERLER_DOVIZ_ID;
            trf.PESIN_HARC = taraf.PESIN_HARC;
            trf.PESIN_HARC_DOVIZ_ID = taraf.PESIN_HARC_DOVIZ_ID;

            liste.Add(trf);

            #endregion <MB-20101203>
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.FoyDurumGetir(lueDurum.Properties);
            //BelgeUtil.Inits.ProjeOzelKodGetir(lueSube.Properties);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

            lueSube.Properties.DataSource = cn.GetDataTable("SELECT a.ID,b.AD, OZEL_KOD, CARI_ID FROM dbo.TDIE_KOD_PROJE_OZEL_KOD(nolock) a LEFT JOIN dbo.AV001_TDI_BIL_CARI(nolock) b ON b.ID = a.CARI_ID ORDER BY b.AD, OZEL_KOD");

            BelgeUtil.Inits.ProjeTipGetir(lueBolum.Properties);
            //cari için kaldırıldı aykut
            //BelgeUtil.Inits.YetkiliCariIsmiGetir(rlueYetkiliCari);
            BelgeUtil.Inits.perCariGetir(rlueProjeTarafCari);

            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueTarafCari);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueTarafCariB);
            AvukatPro.Services.Implementations.DevExpressService.AvukatDoldur(rLueSorumlu, true);
        }

        private void GenelNotlariYukle(int projeID)
        {
            var genelNotlar = BelgeUtil.Inits.context.AV001_TDIE_BIL_PROJE_GENEL_NOTs.Where(vi => vi.PROJE_ID == projeID).ToList();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, genelNotlar);
            gcGenelNotlar.DataSource = genelNotlar;
        }

        private TList<AV001_TDI_BIL_MASRAF_AVANS> GetMasrafList(TList<AV001_TDI_BIL_MASRAF_AVANS> masrafList)
        {
            #region <MB-20110308>

            //Masrafların dosya ve kategorisine göre toplam olarak verilebilmesi işlemi yapılıyor.

            MasrafToplami.Clear();
            foreach (var item in masrafList)
            {
                var detayList = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(item.ID);
                if (detayList.Count > 0)
                    MasrafToplami.Add(item.ID, detayList.Sum(vi => vi.TOPLAM_TUTAR));
            }
            return masrafList;

            #endregion <MB-20110308>
        }

        private void IhtiyatiHacizTedbirIslemleri(AV001_TI_BIL_FOY foy)
        {
            //İhtiyati Haciz
            var foyIhtiyatiHacizList = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByICRA_FOY_ID(foy.ID);

            foyIhtiyatiHacizList.ForEach(iHaciz =>
                {
                    var haciz = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.GetByPROJE_IDIHTIYATI_HACIZ_ID(AktifProjeyiGetir(false).ID, iHaciz.ID);
                    if (haciz != null)
                    {
                        AV001_TI_BIL_IHTIYATI_HACIZ ihtiyatiHaciz = new AV001_TI_BIL_IHTIYATI_HACIZ();
                        ihtiyatiHaciz.ACIKLAMA = iHaciz.ACIKLAMA;
                        ihtiyatiHaciz.ADLI_BIRIM_ADLIYE_ID = iHaciz.ADLI_BIRIM_ADLIYE_ID;
                        ihtiyatiHaciz.ADLI_BIRIM_GOREV_ID = iHaciz.ADLI_BIRIM_GOREV_ID;
                        ihtiyatiHaciz.ADLI_BIRIM_NO_ID = iHaciz.ADLI_BIRIM_NO_ID;
                        ihtiyatiHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection = iHaciz.AV001_TI_BIL_IHTIYATI_HACIZ_TARAFCollection;
                        ihtiyatiHaciz.BIRIM_NO = iHaciz.BIRIM_NO;
                        ihtiyatiHaciz.ESAS_NO = iHaciz.ESAS_NO;
                        ihtiyatiHaciz.K_H_CEVIRME_TARIHI = iHaciz.K_H_CEVIRME_TARIHI;
                        ihtiyatiHaciz.KARAR_NO = iHaciz.KARAR_NO;
                        ihtiyatiHaciz.KARAR_TARIHI = iHaciz.KARAR_TARIHI;
                        ihtiyatiHaciz.MUVEKKILE_TESLIM_TARIHI = iHaciz.MUVEKKILE_TESLIM_TARIHI;
                        ihtiyatiHaciz.TEMINAT_MEKTUP_BILGI_ID = iHaciz.TEMINAT_MEKTUP_BILGI_ID;

                        if (!IhtiyatiHacizList.Contains(ihtiyatiHaciz))
                            IhtiyatiHacizList.Add(ihtiyatiHaciz);

                        if (!TakipliIhtiyatiHacizList.Contains(haciz))
                            TakipliIhtiyatiHacizList.Add(haciz);

                        AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ takipsizIHaciz = new AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ();
                        takipsizIHaciz.IHTIYATI_HACIZ_IDSource = ihtiyatiHaciz;
                        takipsizIHaciz.PROJE_ID = haciz.PROJE_ID;
                        takipsizIHaciz.STAMP = haciz.STAMP;

                        if (!TakipsizIhtiyatiHacizList.Contains(takipsizIHaciz))
                            TakipsizIhtiyatiHacizList.Add(takipsizIHaciz);
                    }
                });

            //İhtiyati Tedbir
            var foyIhtiyatiTedbirList = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.GetByICRA_FOY_ID(foy.ID);

            foyIhtiyatiTedbirList.ForEach(iTedbir =>
                {
                    var tedbir = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.GetByPROJE_IDIHTIYATI_TEDBIR_ID(AktifProjeyiGetir(false).ID, iTedbir.ID);
                    if (tedbir != null)
                    {
                        AV001_TDI_BIL_IHTIYATI_TEDBIR ihtiyatiTedbir = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
                        ihtiyatiTedbir.ACIKLAMA = iTedbir.ACIKLAMA;
                        ihtiyatiTedbir.ADLI_BIRIM_ADLIYE_ID = iTedbir.ADLI_BIRIM_ADLIYE_ID;
                        ihtiyatiTedbir.ADLI_BIRIM_GOREV_ID = iTedbir.ADLI_BIRIM_GOREV_ID;
                        ihtiyatiTedbir.ADLI_BIRIM_NO_ID = iTedbir.ADLI_BIRIM_NO_ID;
                        ihtiyatiTedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection = iTedbir.AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAFCollection;
                        ihtiyatiTedbir.BIRIM_NO = iTedbir.BIRIM_NO;
                        ihtiyatiTedbir.ESAS_NO = iTedbir.ESAS_NO;
                        ihtiyatiTedbir.K_D_CEVIRME_TARIHI = iTedbir.K_D_CEVIRME_TARIHI;
                        ihtiyatiTedbir.KARAR_NO = iTedbir.KARAR_NO;
                        ihtiyatiTedbir.KARAR_TARIHI = iTedbir.KARAR_TARIHI;
                        ihtiyatiTedbir.MUVEKKILE_TESLIM_TARIHI = iTedbir.MUVEKKILE_TESLIM_TARIHI;
                        ihtiyatiTedbir.TEMINAT_MEKTUP_BILGI_ID = iTedbir.TEMINAT_MEKTUP_BILGI_ID;

                        if (!IhtiyatiTedbirList.Contains(ihtiyatiTedbir))
                            IhtiyatiTedbirList.Add(ihtiyatiTedbir);

                        if (!TakipliIhtiyatiTedbirList.Contains(tedbir))
                            TakipliIhtiyatiTedbirList.Add(tedbir);

                        AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR takipsizITedbir = new AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR();
                        takipsizITedbir.IHTIYATI_TEDBIR_IDSource = ihtiyatiTedbir;
                        takipsizITedbir.PROJE_ID = tedbir.PROJE_ID;
                        takipsizITedbir.STAMP = tedbir.STAMP;

                        if (!TakipsizIhtiyatiTedbirList.Contains(takipsizITedbir))
                            TakipsizIhtiyatiTedbirList.Add(takipsizITedbir);
                    }
                });
        }

        private TList<AV001_TDI_BIL_MASRAF_AVANS> KlasorTumMasraflariGetir(AV001_TDIE_BIL_PROJE proje, bool eslestiMi)
        {
            #region <MB-20101227>

            //Klasöre, tüm masraf bilgilerinin gelmesini sağlıyor.

            //TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> masrafDetayList = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
            TList<AV001_TDI_BIL_MASRAF_AVANS> masrafList = new TList<AV001_TDI_BIL_MASRAF_AVANS>();

            //!MasraflarYuklendi kontrolü yeni bir masraf eklendiğinde deepload çekmeden gelmeyeceğinden bu kontrol eklendi. MB

            if (proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Count == 0 || !MasraflarYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_FOY>));
            proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.ForEach(item =>
                {
                    masrafList.AddRange(DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByICRA_FOY_ID(item.ICRA_FOY_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? vi.ESLESTI_MI.Value == eslestiMi : true));
                });

            if (proje.AV001_TDIE_BIL_PROJE_DAVA_FOYCollection.Count == 0 || !MasraflarYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_DAVA_FOY>));
            proje.AV001_TDIE_BIL_PROJE_DAVA_FOYCollection.ForEach(item =>
                {
                    masrafList.AddRange(DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByDAVA_FOY_ID(item.DAVA_FOY_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? vi.ESLESTI_MI.Value == eslestiMi : true));
                });

            if (proje.AV001_TDIE_BIL_PROJE_HAZIRLIKCollection.Count == 0 || !MasraflarYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_HAZIRLIK>));
            proje.AV001_TDIE_BIL_PROJE_HAZIRLIKCollection.ForEach(item =>
            {
                masrafList.AddRange(DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByHAZIRLIK_ID(item.HAZIRLIK_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? vi.ESLESTI_MI.Value == eslestiMi : true));
            });

            if (proje.AV001_TDIE_BIL_PROJE_SOZLESMECollection.Count == 0 || !MasraflarYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>));
            proje.AV001_TDIE_BIL_PROJE_SOZLESMECollection.ForEach(item =>
            {
                masrafList.AddRange(DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetBySOZLESME_ID(item.SOZLESME_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? vi.ESLESTI_MI.Value == eslestiMi : true));
            });

            if (proje.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.Count == 0 || !MasraflarYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_MASRAF_AVANS>));
            proje.AV001_TDIE_BIL_PROJE_MASRAF_AVANSCollection.ForEach(item =>
            {
                var masraf = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID(item.MASRAF_AVANS_ID);
                if (masraf.ESLESTI_MI.HasValue && masraf.ESLESTI_MI.Value == eslestiMi)
                    masrafList.Add(masraf);
                else if (!masraf.ESLESTI_MI.HasValue && eslestiMi)
                    masrafList.Add(masraf);
            });

            return GetMasrafList(masrafList);

            #endregion <MB-20101227>
        }

        private TList<AV001_TI_BIL_BORCLU_ODEME> KlasorTumOdemeleriGetir(AV001_TDIE_BIL_PROJE proje, bool eslestiMi)
        {
            #region <MB-20101227>

            //Klasöre, tüm ödeme bilgilerinin gelmesini sağlıyor.

            TList<AV001_TI_BIL_BORCLU_ODEME> odemeList = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            if (proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Count == 0 || !OdemelerYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_FOY>));
            proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.ForEach(item =>
            {
                odemeList.AddRange(DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByICRA_FOY_ID(item.ICRA_FOY_ID).FindAll(vi => vi.ESLESTI_MI.HasValue ? vi.ESLESTI_MI == eslestiMi : true));
            });

            if (proje.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.Count == 0 || !OdemelerYuklendi)
                DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME>));
            proje.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.ForEach(item =>
            {
                var odeme = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(item.BORCLU_ODEME_ID);

                if (odeme.ESLESTI_MI.HasValue && odeme.ESLESTI_MI.Value == eslestiMi)
                    odemeList.Add(DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(item.BORCLU_ODEME_ID));
                else if (!odeme.ESLESTI_MI.HasValue && eslestiMi)
                    odemeList.Add(DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(item.BORCLU_ODEME_ID));
            });

            return odemeList;

            #endregion <MB-20101227>
        }

        private void MunzamSenetIslemleri(AV001_TI_BIL_FOY foy)
        {
            #region <MB-20101215>

            //Takip silme sırasında munzam senet bilgilerinin de klasöre geri gelmesi sağlanıyor.

            var foyMunzamList = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByICRA_FOY_IDFromNN_ICRA_KIYMETLI_EVRAK(foy.ID).FindAll(vi => vi.MUNZAM_SENET_MI ?? false);

            foyMunzamList.ForEach(foyMunzam =>
            {
                var munzam = DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.GetByKIYMETLI_EVRAK_IDPROJE_ID(foyMunzam.ID, AktifProjeyiGetir(false).ID);
                if (munzam != null)
                {
                    if (!TakipliMunzamList.Contains(munzam))
                        TakipliMunzamList.Add(munzam);

                    AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK takipsizMunzam = new AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK();
                    takipsizMunzam.KIYMETLI_EVRAK_ID = munzam.KIYMETLI_EVRAK_ID;
                    takipsizMunzam.PROJE_ID = munzam.PROJE_ID;
                    takipsizMunzam.STAMP = munzam.STAMP;

                    if (!TakipsizMunzamList.Contains(takipsizMunzam))
                        TakipsizMunzamList.Add(takipsizMunzam);
                }
            });

            #endregion <MB-20101215>
        }

        private void ProjeTaraflariYukle(int projeID)
        {
            VList<DS_VDIE_BIL_PROJE_TARAF> projeTaraflari = DataRepository.DS_VDIE_BIL_PROJE_TARAFProvider.Get(string.Format("PROJE_ID={0}", projeID), "CARI_ID ASC");
            gcTaraflar.DataSource = projeTaraflari;
        }

        private void TaraflariDoldur(AV001_TDIE_BIL_PROJE secilenProje)
        {
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(secilenProje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));

            TList<AV001_TDIE_BIL_PROJE_TARAF> alacakli = new TList<AV001_TDIE_BIL_PROJE_TARAF>();
            TList<AV001_TDIE_BIL_PROJE_TARAF> borclu = new TList<AV001_TDIE_BIL_PROJE_TARAF>();

            foreach (var item in secilenProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
            {
                AV001_TDI_BIL_CARI car = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID);
                if (car.MUVEKKIL_MI)
                    alacakli.Add(item);
                else
                    borclu.Add(item);
            }

            gcAlacak.DataSource = alacakli;
            gcBorclu.DataSource = borclu;
            gcSorumlu.DataSource = secilenProje.AV001_TDIE_BIL_PROJE_SORUMLUCollection;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
            try
            {
                lueSube.EditValue = null;
                cn.AddParams("@ID", secilenProje.ID);
                DataTable dt = cn.GetDataTable("select PROJE_SUBE_ID from dbo.AV001_TDIE_BIL_PROJE(nolock) where ID=@ID");
                if (dt.Rows.Count > 0)
                    lueSube.EditValue = dt.Rows[0][0];
            }
            catch { ;}
        }

        private void YapilacakIsleriYukle(int projeID)
        {
            TList<AV001_TDI_BIL_IS> yapilacakIsler = DataRepository.AV001_TDI_BIL_ISProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_IS(projeID);
            ucGorevler1.MyDataSource = yapilacakIsler;
        }

        #region <MB-20100611>

        //Seçili projeye göre kayıtlı taahhüt bilgilerinin gelmesi için eklendi.

        private bool lookUpDolduruldu;

        private void TaahhutMasterYukle(AV001_TDIE_BIL_PROJE proje)
        {
            gcMaster.DataSource = BelgeUtil.Inits.context.per_AV001_TI_BIL_BORCLU_TAAHHUT_MASTERs.Where(item => item.PROJE_ID == proje.ID).ToList();
            if (!lookUpDolduruldu)
            {
                Inits.ProjeTarafGetir(proje, new[] { rlueProjeTaraf });
                Inits.TaahhutDurumGetir(rlueTaahhutDurum);
                Inits.DovizTipGetir(rlueDoviz);
                lookUpDolduruldu = true;
            }
        }

        #endregion <MB-20100611>

        #endregion <MB-20102601> METHODS

        #region <MB-20102601> EVENTS

        private void depoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGayrinakitTarihler frm = new frmGayrinakitTarihler();
            frm.Show((treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TI_BIL_ALACAK_NEDEN).ID, AktifProjeyiGetir(false).ID, TarihTip.Depo);
        }

        private void frmMasraf_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as frmAlacakGirisi) != null)
                (sender as frmAlacakGirisi).Close();
            projeGuncelle(null);

            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(AktifProjeyiGetir(true), false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
            gcMasraflar.DataSource = AktifProjeyiGetir(false).AV001_TDI_BIL_MASRAF_AVANSCollection;
        }

        private void frmOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmIcraOdemeBilgileri frm = sender as frmIcraOdemeBilgileri;
            if (frm != null && frm.Tag != null && frm.Tag is AV001_TDIE_BIL_PROJE)
            {
                AV001_TDIE_BIL_PROJE prj = frm.Tag as AV001_TDIE_BIL_PROJE;
                frm.MyDataSource.AddingNew -= OdemeAddingNew;
                projeGuncelle(null);
            }
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(AktifProjeyiGetir(false), false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_ODEME>));
            gcOdemeler.DataSource = AktifProjeyiGetir(false).AV001_TI_BIL_BORCLU_ODEMECollection_From_AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME;
        }

        private void gcGenelNotlar_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                frmKlasorGenelNotlar genelNotlar = new frmKlasorGenelNotlar();
                if (lueAra.EditValue != null)
                {
                    genelNotlar.projeID = (int)lueAra.EditValue;
                    genelNotlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    genelNotlar.Show();
                    genelNotlar.FormClosed += genelNotlar_FormClosed;
                }
                else
                    XtraMessageBox.Show("Klasör Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmKlasorGenelNotlar genelNotlar = new frmKlasorGenelNotlar();
                if (lueAra.EditValue != null)
                {
                    genelNotlar.projeID = (int)lueAra.EditValue;
                    genelNotlar.MyDataSource = gvGenelNotlar.GetFocusedRow() as AvukatProLib.Arama.AV001_TDIE_BIL_PROJE_GENEL_NOT;
                    genelNotlar.Duzenle = true;
                    genelNotlar.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    genelNotlar.Text = "GENEL NOT DÜZENLEME";
                    genelNotlar.Show();
                    genelNotlar.FormClosed += genelNotlar_FormClosed;
                }
                else
                    XtraMessageBox.Show("Klasör Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else if (e.Button.Tag.ToString() == "KaydiSil")
            {
                if (lueAra.EditValue != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDIE_BIL_PROJE_GENEL_NOT", "ID = " + (gvGenelNotlar.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE_GENEL_NOT).ID);
                    kayitSil.Show();
                    kayitSil.FormClosed += genelNotlar_FormClosed;
                }
            }
        }

        private void gcMasraflar_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            frmMasrafKayit frmMasraf = new frmMasrafKayit();
            frmMasraf.FormClosed += new FormClosedEventHandler(frmMasraf_FormClosed);
            frmMasraf.Show(AktifProjeyiGetir(true));
        }

        private void gcOdemeler_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            frmIcraOdemeBilgileri frmOdeme = new frmIcraOdemeBilgileri();
            AV001_TDIE_BIL_PROJE prj = AktifProjeyiGetir(false);
            TList<AV001_TI_BIL_BORCLU_ODEME> odemeler = new TList<AV001_TI_BIL_BORCLU_ODEME>();
            odemeler.AddingNew += OdemeAddingNew;
            frmOdeme.Show(odemeler, AktifTaraflariGetir());
            frmOdeme.MyProje = prj;
            frmOdeme.Tag = prj;
            frmOdeme.FormClosing += frmOdeme_FormClosing;
        }

        private void genelNotlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            int klasorID = 0;

            if (lueAra.EditValue != null)
                klasorID = (int)lueAra.EditValue;

            GenelNotlariYukle(klasorID);
        }

        private void gvMasraflar_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            #region <MB-20101227>

            //Masrafların hangi dosyaya ait olduğu bilgisini ekleyebilmek için eklendi.

            if (e.Column.Tag == null) return;
            if ((int)e.Column.Tag == 1)
            {
                var masraf = gvMasraflar.GetRow(e.RowHandle) as AV001_TDI_BIL_MASRAF_AVANS;
                if (BelgeUtil.Inits._AdliBirimAdliyeGetir == null)
                    BelgeUtil.Inits._AdliBirimAdliyeGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
                if (BelgeUtil.Inits._AdliBirimNoGetir == null)
                    BelgeUtil.Inits._AdliBirimNoGetir = DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
                if (BelgeUtil.Inits._AdliBirimGorevGetir_Enter == null)
                    BelgeUtil.Inits._AdliBirimGorevGetir_Enter = DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();

                if (masraf.ICRA_FOY_ID.HasValue)
                {
                    if (BelgeUtil.Inits._IcraDosyalarArama == null)
                        BelgeUtil.Inits._IcraDosyalarArama = BelgeUtil.Inits.IcraDosyalariGetir();

                    var foy = DataRepository.per_AV001_TI_BIL_ICRA_AramaProvider.Get("Id=" + masraf.ICRA_FOY_ID.Value, "Id");

                    e.DisplayText = string.Format("{0} - {1} {2}", foy[0].ESAS_NO, foy[0].ADLI_BIRIM_ADLIYE_ID.HasValue ? BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == foy[0].ADLI_BIRIM_ADLIYE_ID.Value).ADLIYE : " ", foy[0].ADLI_BIRIM_NO_ID.HasValue ? BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == foy[0].ADLI_BIRIM_NO_ID.Value).NO : " ");
                }
                else if (masraf.DAVA_FOY_ID.HasValue)
                {
                    if (BelgeUtil.Inits._DavaDosyalar == null)
                        BelgeUtil.Inits._DavaDosyalar = BelgeUtil.Inits.context.VTD_DAVA_DOSYALARs.ToList();
                    var foy = BelgeUtil.Inits._DavaDosyalar.Find(vi => vi.ID == masraf.DAVA_FOY_ID.Value);
                    e.DisplayText = string.Format("{0} {1} {2} {3}", foy.ESAS_NO, foy.ADLIYE_ID.HasValue ? BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == foy.ADLIYE_ID.Value).ADLIYE : " ", foy.BIRIM_ID.HasValue ? BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == foy.BIRIM_ID.Value).NO : " ", foy.GOREV_ID.HasValue ? BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == foy.GOREV_ID.Value).GOREV : " ");
                }
                else if (masraf.HAZIRLIK_ID.HasValue)
                {
                    if (BelgeUtil.Inits._SorusturmaDosyalar == null)
                        BelgeUtil.Inits._SorusturmaDosyalar = BelgeUtil.Inits.context.VTD_SORUSTURMA_DOSYALARs.ToList();
                    var foy = BelgeUtil.Inits._SorusturmaDosyalar.Find(vi => vi.ID == masraf.HAZIRLIK_ID.Value);
                    e.DisplayText = string.Format("{0} {1} {2} {3}", foy.HAZIRLIK_ESAS_NO, foy.ADLIYE_ID.HasValue ? BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == foy.ADLIYE_ID.Value).ADLIYE : " ", foy.BIRIM_ID.HasValue ? BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == foy.BIRIM_ID.Value).NO : " ", foy.GOREV_ID.HasValue ? BelgeUtil.Inits._AdliBirimGorevGetir_Enter.Find(vi => vi.ID == foy.GOREV_ID.Value).GOREV : " ");
                }
            }
            else if ((int)e.Column.Tag == 2)
            {
                var masraf = gvMasraflar.GetRow(e.RowHandle) as AV001_TDI_BIL_MASRAF_AVANS;
                var masrafToplami = MasrafToplami.FirstOrDefault(vi => vi.Key == masraf.ID).Value;
                AdimAdimDavaKaydi.Generalclass.SayiOkuma sa = new AdimAdimDavaKaydi.Generalclass.SayiOkuma();
                e.DisplayText = sa.ParaFormatla(masrafToplami);
            }

            #endregion <MB-20101227>
        }

        private void gvOdemeler_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            #region <MB-20101227>

            //Ödemelerin hangi dosyaya ait olduğu bilgisini ekleyebilmek için eklendi.

            if (e.Column.Tag != null && (int)e.Column.Tag == 1)
            {
                var odeme = gvOdemeler.GetRow(e.RowHandle) as AV001_TI_BIL_BORCLU_ODEME;

                if (odeme.ICRA_FOY_ID.HasValue)
                {
                    //if (BelgeUtil.Inits._IcraDosyalarArama == null)
                    //    BelgeUtil.Inits._IcraDosyalarArama = BelgeUtil.Inits.context.per_AV001_TI_BIL_ICRA_Aramas.ToList();

                    var foy = BelgeUtil.Inits.IcraDosyalariGetirByID(odeme.ICRA_FOY_ID.Value);

                    e.DisplayText = string.Format("{0} - {1} {2}", foy.Rows[0]["ESAS_NO"], foy.Rows[0]["ADLI_BIRIM_ADLIYE_ID"] != null ? BelgeUtil.Inits._AdliBirimAdliyeGetir.Find(vi => vi.ID == (int)foy.Rows[0]["ADLI_BIRIM_ADLIYE_ID"]).ADLIYE : " ", foy.Rows[0]["ADLI_BIRIM_NO_ID"] != null ? BelgeUtil.Inits._AdliBirimNoGetir.Find(vi => vi.ID == (int)foy.Rows[0]["ADLI_BIRIM_NO_ID"]).NO : " ");
                }
            }

            #endregion <MB-20101227>
        }

        private void iadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGayrinakitTarihler frm = new frmGayrinakitTarihler();
            frm.Show((treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TI_BIL_ALACAK_NEDEN).ID, AktifProjeyiGetir(false).ID, TarihTip.Iade);
        }

        private void lueAra_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sbtnBul.Focus();
                sbtnBul_Click(null, null);
            }
        }

        private void lueHesapTipi_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "duzenle")
            {
                AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira frm =
                    new AdimAdimDavaKaydi.Forms.Icra.frmHesapTipSira(Convert.ToInt32(((LookUpEdit)sender).EditValue));
                frm.StartPosition = FormStartPosition.CenterScreen;

                //  frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                if (frm.ShowDialog() == DialogResult.OK)

                    //if (frm.KayitBasarili == DialogResult.OK)
                    BelgeUtil.Inits.HesapTipiGetirYenile();
            }
        }

        private void sbtnBul_Click(object sender, EventArgs e)
        {
            lcGroupBilgiler.Enabled = false;

            if (lueAra.EditValue != null)
            {
                BindLookUps();

                int klasorID = (int)lueAra.EditValue;

                AV001_TDIE_BIL_PROJE secilenProje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(klasorID);
                bndProje.DataSource = secilenProje;

                MyCurrentProje = secilenProje;
                ucIcraHesapCetveli1.MyProje = secilenProje;

                TList<AV001_TDIE_BIL_PROJE> projelerim = new TList<AV001_TDIE_BIL_PROJE> { secilenProje };
                MyDataSource = projelerim;

                ProjeTaraflariYukle(klasorID);

                DeepLoadProje(secilenProje);
                DeepLoadProjeTamamlandı(secilenProje);

                tabbedControlGroup2.SelectedTabPage = layoutControlGroup9;

                MasraflarYuklendi = false;
                OdemelerYuklendi = false;

                lcGroupBilgiler.Enabled = true;
                treeKrediHesapBilgileri.Enabled = true;

                TaraflariDoldur(secilenProje);

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                DataTable dt = cn.GetDataTable("select KAZANMA_ORANI, BEKLENEN_BITIS_TARIHI from dbo.AV001_TDIE_BIL_PROJE where ID=" + klasorID);
                dateBeklenenBitisTarihi.EditValue = null;
                spinKazanmaOrani.EditValue = 0;

                if (dt.Rows.Count > 0)
                {
                    dateBeklenenBitisTarihi.EditValue = dt.Rows[0]["BEKLENEN_BITIS_TARIHI"];
                    spinKazanmaOrani.EditValue = dt.Rows[0]["KAZANMA_ORANI"];
                }
            }
            else
                XtraMessageBox.Show("Klasör Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        #region <MB-20100623>

        #endregion <MB-20100623>

        private void tazminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGayrinakitTarihler frm = new frmGayrinakitTarihler();
            frm.Show((treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TI_BIL_ALACAK_NEDEN).ID, AktifProjeyiGetir(false).ID, TarihTip.Tazmin);
        }

        private void ucGorevler1_Saved(System.Collections.IList Records, IEntity Record)
        {
            int klasorID = 0;

            if (lueAra.EditValue != null)
                klasorID = (int)lueAra.EditValue;

            YapilacakIsleriYukle(klasorID);
        }

        #region <MB-20100611>

        //Seçili Taahhüt Master'a göre detay bilgilerinin gelmesi için eklendi.

        private void gvMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMaster.GetFocusedRow() == null) return;

            AvukatProLib.Arama.per_AV001_TI_BIL_BORCLU_TAAHHUT_MASTER master = gvMaster.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_BORCLU_TAAHHUT_MASTER;

            TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> childs = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>();

            if (master != null)
                childs = DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProvider.GetByMASTER_TAAHHUT_ID(master.ID);

            gcChild.DataSource = childs;
        }

        #endregion <MB-20100611>

        #region <MB-20100701>

        //Taahhüt olarak kaydedilen ödeme planlarında seçili olan kaydın silinmesini sağlamak için eklendi.

        private void gcMaster_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "Sil")
            {
                AdimAdimDavaKaydi.Util.frmKayitSil sil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_BORCLU_TAAHHUT_MASTER", "ID = " + (gvMaster.GetFocusedRow() as AvukatProLib.Arama.per_AV001_TI_BIL_BORCLU_TAAHHUT_MASTER).ID);
                sil.Show();
                sil.FormClosed += sil_FormClosed;
            }
        }

        private void sil_FormClosed(object sender, FormClosedEventArgs e)
        {
            TaahhutMasterYukle(bndProje.Current as AV001_TDIE_BIL_PROJE);
        }

        #endregion <MB-20100701>

        #region <MB-20102801> AvpXtraForm EVENTS

        private void frmKlasorYeni_Button_Excel_Click(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = false;
            layoutControlGroup3.Expanded = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|Excel Dosyası";
            sfd.DefaultExt = "xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lcProjeEkrani.ExportToXls(sfd.FileName);
            }
        }

        private void frmKlasorYeni_Button_Hesapla_Click(object sender, EventArgs e)
        {
            if (AktifProjeyiGetir(false) == null)
            {
                XtraMessageBox.Show("Lütfen listeden bir klasör seçiniz", "Hata", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr =
                XtraMessageBox.Show(
                    String.Format(
                        "{0} isimli klasör hesabı yapılacak. İşlem uzun sürebilir devam etmek için Evet, iptal etmek için Hayır",
                        AktifProjeyiGetir(false).ADI), "Hesap Yapılacak", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            DateTime baslangic = DateTime.Now;
            if (dr == DialogResult.Yes)
            {
                try
                {
                    ucIcraHesapCetveli1.Enabled = false;

                    if ((bndProje.Current as AV001_TDIE_BIL_PROJE) != null)
                    {
                        KlasorHesapAraclari kh = new KlasorHesapAraclari();

                        var ozetHesap = kh.GetKonsolideAlacaklarHesabi2G((bndProje.Current as AV001_TDIE_BIL_PROJE));

                        ucIcraHesapCetveli1.MyOzetHesap = ozetHesap;

                        //tabDetayHesap.PageEnabled = true;
                        //tcOnPanel.SelectedTabPage = tabDetayHesap;
                        XtraMessageBox.Show("Hesap işlemi tamamlandı" + Environment.NewLine +
                                            (DateTime.Now - baslangic).TotalSeconds + "sn");
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex, BelgeUtil.Bilesen.Hesap);
                }
                finally
                {
                    ucIcraHesapCetveli1.Enabled = true;
                }
            }
        }

        //Simülasyona Gönder
        private void frmKlasorYeni_Button_HesaplanmisKalemler_Click(object sender, EventArgs e)
        {
            if (AktifProjeyiGetir(false) == null)
            {
                MessageBox.Show("Lütfen listeden bir klasör seçiniz.", "Klasör seçilmemiş", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmOdemePlani tahutFormu2 = new frmOdemePlani();
            tahutFormu2.FormClosed += tahutFormu2_FormClosed;
            KlasorHesapAraclari ka = new KlasorHesapAraclari();
            AvukatProLib.Hesap.HesapAraclari.OzetHesap ozetHEsap =
                ka.GetKonsolideAlacaklarHesabi2G(AktifProjeyiGetir(false));

            tahutFormu2.Show(ozetHEsap.MyFoy, AktifProjeyiGetir(true));
        }

        private void frmKlasorYeni_Button_Kaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void frmKlasorYeni_Button_PDF_Click(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = false;
            layoutControlGroup3.Expanded = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.pdf|PDF Dosyası";
            sfd.DefaultExt = "pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lcProjeEkrani.ExportToPdf(sfd.FileName);
            }
        }

        private void frmKlasorYeni_Button_Word_Click(object sender, EventArgs e)
        {
            layoutControlGroup2.Expanded = false;
            layoutControlGroup3.Expanded = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.rtf|Word Dosyası";
            sfd.DefaultExt = "rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lcProjeEkrani.ExportToRtf(sfd.FileName);
            }
        }

        //Rapor
        private void frmKlasorYeni_Button_Yazdir_Click(object sender, EventArgs e)
        {
            KlasorRapor();
        }

        private void frmKlasorYeni_Button_Yeni_Click(object sender, EventArgs e)
        {
            frmYeniKlasor frm = new frmYeniKlasor();
            if (MyDataSource == null)
                MyDataSource = new TList<AV001_TDIE_BIL_PROJE>();
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                                      if (prj != null)
                                      {
                                          prj.SUBE_KOD_ID = AdimAdimDavaKaydi.Forms.frmKlasorYeni.KullaniciSubeIDGetir(prj.AV001_TDIE_BIL_PROJE_SORUMLUCollection.Find(vi => !vi.YETKILI_MI.Value).CARI_ID);
                                          DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                                          MyDataSource.Clear();

                                          MyDataSource.Add(prj);

                                          projeGuncelle(MyDataSource);
                                          BelgeUtil.Inits._ProjeAdGetir.Add(Inits.GetProjeViewItem(prj));
                                          (lueAra.Properties.DataSource as List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE>).Add(Inits.GetProjeViewItem(prj));

                                          //BelgeUtil.Inits.ProjeAdGetirYenile(lueAra);
                                          lueAra.EditValue = prj.ID;
                                          sbtnBul.PerformClick();
                                      }
                                  };
        }

        #region <MB-20100611>

        //Yeni Taahhüt Kaydından sonra gridin yenilenmesi için eklendi.

        private void tahutFormu2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((frmOdemePlani)sender).KayitYapildi && bndProje.Current != null)
                TaahhutMasterYukle(bndProje.Current as AV001_TDIE_BIL_PROJE);
        }

        #endregion <MB-20100611>

        #endregion <MB-20102801> AvpXtraForm EVENTS

        #region <MB-20101129>

        //Ödemeye düzenleme işlemi eklendi.
        private void ödemeyiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIcraOdemeBilgileri frm = new frmIcraOdemeBilgileri();
            AV001_TDIE_BIL_PROJE prj = AktifProjeyiGetir(false);
            TList<AV001_TI_BIL_BORCLU_ODEME> odemeList = new TList<AV001_TI_BIL_BORCLU_ODEME>();

            if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_BORCLU_ODEME)
                odemeList.Add(DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(((treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TI_BIL_BORCLU_ODEME).ID));

            frm.Show(odemeList, AktifTaraflariGetir());
            frm.MyProje = prj;
            frm.Tag = prj;
            frm.FormClosing += frm_FormClosing;
        }

        #endregion <MB-20101129>

        #region <MB-20101201>

        private void frmMini_FormClosed(object sender, FormClosedEventArgs e)
        {
            projeGuncelle(null);
        }

        //Masrafa düzenleme işlemi eklendi.
        private void masrafDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IcraTakipForms.frmMasrafAvansKayitHizli frmMini = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
            frmMini.Duzenleme = true;
            frmMini.MyProje = AktifProjeyiGetir(false);
            AV001_TDI_BIL_MASRAF_AVANS masrafAvans = new AV001_TDI_BIL_MASRAF_AVANS();
            if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDI_BIL_MASRAF_AVANS)
                masrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID((treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TDI_BIL_MASRAF_AVANS).ID);
            if (masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.Count == 0)
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masrafAvans, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
            frmMini.DetayList = masrafAvans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection;
            frmMini.MyDataSource = masrafAvans;
            frmMini.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmMini.Show();
            frmMini.FormClosed += new FormClosedEventHandler(frmMini_FormClosed);
        }

        #endregion <MB-20101201>

        #endregion <MB-20102601> EVENTS

        #region KREDİ BİLGİLERİ TREE LİST

        private TreeListNode nd8 = null;

        #region METHODS

        public TList<AV001_TDIE_BIL_PROJE> GetProje;

        private DataTable _ProjeTable
        {
            get
            {
                DataTable result = new DataTable("Proje");
                result.Columns.Add("ADI");
                result.Columns.Add("ACIKLAMA");
                return result;
            }
        }

        public AV001_TDIE_BIL_PROJE AktifProjeyiGetir(bool deep)
        {
            return projeGetir(treeKrediHesapBilgileri.FocusedNode, deep);
        }

        public void nodeDoldur(TreeListNode e)
        {
            if (e == null) return;

            #region treenodes

            if (e.Tag is Type)
            {
                AV001_TDIE_BIL_PROJE prj = null;
                switch (((Type)e.Tag).Name)
                {
                    case "AV001_TI_BIL_FOY":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_ICRA_FOY> foyList = DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in foyList)
                        {
                            AV001_TI_BIL_FOY foy = new AV001_TI_BIL_FOY(); // Okan 10.08.2010 yeni yapı
                            foy.ID = item.ICRA_FOY_ID;
                            nodeEkle(foy, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_TEMINAT":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_TEMINAT> sozlesmeList = DataRepository.AV001_TDIE_BIL_PROJE_TEMINATProvider.GetByPROJE_ID(prj.ID);
                        foreach (var item in sozlesmeList)
                        {
                            AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();
                            sozlesme.ID = item.SOZLESME_ID;
                            nodeEkle(sozlesme, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TD_BIL_FOY":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_DAVA_FOY> davaFoyList = DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in davaFoyList)
                        {
                            AV001_TD_BIL_FOY foy = new AV001_TD_BIL_FOY();
                            foy.ID = item.DAVA_FOY_ID;
                            nodeEkle(foy, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_IS":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_IS> isList = DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in isList)
                        {
                            AV001_TDI_BIL_IS isITem = new AV001_TDI_BIL_IS();
                            isITem.ID = item.IS_ID;
                            nodeEkle(isITem, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TD_BIL_HAZIRLIK":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_HAZIRLIK> hazirlikList = DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in hazirlikList)
                        {
                            AV001_TD_BIL_HAZIRLIK hzr = new AV001_TD_BIL_HAZIRLIK();
                            hzr.ID = item.HAZIRLIK_ID;
                            nodeEkle(hzr, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_RUCU":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_RUCU> rucuList = DataRepository.AV001_TDIE_BIL_PROJE_RUCUProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in rucuList)
                        {
                            AV001_TDI_BIL_RUCU rcu = new AV001_TDI_BIL_RUCU();
                            rcu.ID = item.RUCU_ID;
                            nodeEkle(rcu, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_MASRAF_AVANS":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_MASRAF_AVANS> maList = DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in maList)
                        {
                            AV001_TDI_BIL_MASRAF_AVANS ma = new AV001_TDI_BIL_MASRAF_AVANS();
                            ma.ID = item.MASRAF_AVANS_ID;
                            nodeEkle(ma, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_BELGE":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_BELGE> belgeList = DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in belgeList)
                        {
                            AV001_TDIE_BIL_BELGE belge = new AV001_TDIE_BIL_BELGE();
                            belge.ID = item.BELGE_ID;
                            nodeEkle(belge, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_TEBLIGAT":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_TEBLIGAT> tebligatList = DataRepository.AV001_TDIE_BIL_PROJE_TEBLIGATProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in tebligatList)
                        {
                            AV001_TDI_BIL_TEBLIGAT tebl = new AV001_TDI_BIL_TEBLIGAT();
                            tebl.ID = item.TEBLIGAT_ID;
                            nodeEkle(tebl, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_GORUSME":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_GORUSME> gorusmeList = DataRepository.AV001_TDIE_BIL_PROJE_GORUSMEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in gorusmeList)
                        {
                            AV001_TDI_BIL_GORUSME gorusme = new AV001_TDI_BIL_GORUSME();
                            gorusme.ID = item.GORUSME_ID;
                            nodeEkle(gorusme, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_MUHASEBE":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_MUHASEBE> muhasebeList = DataRepository.AV001_TDIE_BIL_PROJE_MUHASEBEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in muhasebeList)
                        {
                            AV001_TDI_BIL_MUHASEBE muhasebe = new AV001_TDI_BIL_MUHASEBE();
                            muhasebe.ID = item.MUHASEBE_ID;
                            nodeEkle(muhasebe, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TI_BIL_ALACAK_NEDEN":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> nedenList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in nedenList)
                        {
                            AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();
                            neden.ID = item.ALACAK_NEDEN_ID;
                            nodeEkle(neden, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "TDI_BIL_BORCLU_MAL":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_BORCLU_MAL> bMalList = DataRepository.AV001_TDIE_BIL_PROJE_BORCLU_MALProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in bMalList)
                        {
                            TDI_BIL_BORCLU_MAL bMal = new TDI_BIL_BORCLU_MAL();
                            bMal.ID = item.BORCLU_MAL_ID;
                            nodeEkle(bMal, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TI_BIL_BORCLU_ODEME":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME> odemeList = DataRepository.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in odemeList)
                        {
                            AV001_TI_BIL_BORCLU_ODEME odeme = new AV001_TI_BIL_BORCLU_ODEME();
                            odeme.ID = item.BORCLU_ODEME_ID;
                            nodeEkle(odeme, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_SOZLESME":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_SOZLESME> sozlesmeListesi = DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in sozlesmeListesi)
                        {
                            AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();
                            sozlesme.ID = item.SOZLESME_ID;
                            nodeEkle(sozlesme, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR> tedbirList = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in tedbirList)
                        {
                            AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
                            tedbir.ID = item.IHTIYATI_TEDBIR_ID;
                            nodeEkle(tedbir, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TI_BIL_IHTIYATI_HACIZ":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ> iHacizList = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in iHacizList)
                        {
                            AV001_TI_BIL_IHTIYATI_HACIZ iHaciz = new AV001_TI_BIL_IHTIYATI_HACIZ();
                            iHaciz.ID = item.IHTIYATI_HACIZ_ID;
                            nodeEkle(iHaciz, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> aNedenList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(prj.ID);
                        List<int> idList = new List<int>();
                        aNedenList.ForEach(item => idList.Add(item.ALACAK_NEDEN_ID));
                        List<AvukatProLib.Arama.per_AV001_TI_BIL_ALACAK_NEDEN> alacakNedenList = BelgeUtil.Inits.AlacakNedenGetirByIdList(idList);

                        foreach (var item in alacakNedenList)
                        {
                            if (item.AN_URETIP_TIP == (byte)AN_URETIP_TIP.SenetleTakibeKonuldu)
                            {
                                continue;
                            }
                            else if (item.AN_URETIP_TIP == (byte)AN_URETIP_TIP.MunzamSenet)
                            {
                                #region Munzam Senet

                                AV001_TI_BIL_ALACAK_NEDEN aNeden = new AV001_TI_BIL_ALACAK_NEDEN();
                                aNeden.ID = item.ALACAK_NEDEN_ID;
                                aNeden.ICRA_FOY_ID = (from aNItem in BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs where aNItem.ALACAK_NEDEN_ID == item.ALACAK_NEDEN_ID select item.ICRA_FOY_ID).Single();
                                var aNode = nodeEkle(aNeden, e, treeKrediHesapBilgileri);

                                if (aNeden.ICRA_FOY_ID.HasValue)
                                {
                                    var alacaklar = BelgeUtil.Inits.AlacakNedenGetirByIcraFoyId(aNeden.ICRA_FOY_ID.Value).Where(ndn => ndn.AN_URETIP_TIP == (byte)AN_URETIP_TIP.SenetleTakibeKonuldu);

                                    TreeListNode aAltNode = nodeEkle(dataRowYap("Alacaklar", "Alacak senedi ile takibe alınan alacaklar"),
                                                 aNode, typeof(AV001_TI_BIL_ALACAK_NEDEN), 2, treeKrediHesapBilgileri, alacaklar.Count() > 0);

                                    if (aAltNode.Nodes.FirstNode != null && aAltNode.Nodes.FirstNode.Tag is bool)
                                    {
                                        aAltNode.Nodes.Remove(aAltNode.Nodes.FirstNode);
                                    }

                                    foreach (var alacak in alacaklar)
                                    {
                                        AV001_TI_BIL_ALACAK_NEDEN aNdn = new AV001_TI_BIL_ALACAK_NEDEN();
                                        aNdn.ID = alacak.ALACAK_NEDEN_ID;
                                        nodeEkle(aNdn, aAltNode, treeKrediHesapBilgileri);
                                    }
                                }

                                #endregion Munzam Senet

                                continue;
                            }
                            AV001_TI_BIL_ALACAK_NEDEN aNedeni = new AV001_TI_BIL_ALACAK_NEDEN();
                            aNedeni.ID = item.ALACAK_NEDEN_ID;
                            nodeEkle(aNedeni, e, treeKrediHesapBilgileri);
                        }

                        break;

                    case "AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_SOZLESME> sozlesmeler = DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in sozlesmeler)
                        {
                            AV001_TDI_BIL_SOZLESME sozlesme = new AV001_TDI_BIL_SOZLESME();
                            sozlesme.ID = item.SOZLESME_ID;
                            nodeEkle(sozlesme, e, treeKrediHesapBilgileri);
                        }

                        break;

                    case "AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI> ihtiyatiHacizList = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in ihtiyatiHacizList)
                        {
                            AV001_TI_BIL_IHTIYATI_HACIZ iHaciz = new AV001_TI_BIL_IHTIYATI_HACIZ();
                            iHaciz.ID = item.IHTIYATI_HACIZ_ID;
                            nodeEkle(iHaciz, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI> iTedbirList = DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.GetByPROJE_ID(prj.ID);

                        foreach (var item in iTedbirList)
                        {
                            AV001_TDI_BIL_IHTIYATI_TEDBIR iTedbir = new AV001_TDI_BIL_IHTIYATI_TEDBIR();
                            iTedbir.ID = item.IHTIYATI_TEDBIR_ID;
                            nodeEkle(iTedbir, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDI_BIL_KIYMETLI_EVRAK":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK> kEvrakList = DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.GetByPROJE_ID(prj.ID);
                        List<int> evrakIdList = new List<int>();
                        kEvrakList.ForEach(item => evrakIdList.Add(item.KIYMETLI_EVRAK_ID));
                        var kiymetliEvraklar = BelgeUtil.Inits.KiymetliEvrakGetirByIdList(evrakIdList).Where(item => item.MUNZAM_SENET_MI.HasValue && !item.MUNZAM_SENET_MI.Value);

                        foreach (var item in kiymetliEvraklar)
                        {
                            AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();
                            kEvrak.ID = item.KIYMETLI_EVRAK_ID;
                            nodeEkle(kEvrak, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(prj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI>));

                        foreach (var kEvrak in prj.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection)
                        {
                            nodeEkle(kEvrak, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_IHTARNAME":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;

                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(prj, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDIE_BIL_PROJE_IHTARNAME>));

                        foreach (AV001_TDIE_BIL_PROJE_IHTARNAME kEvrak in prj.AV001_TDIE_BIL_PROJE_IHTARNAMECollection)
                        {
                            nodeEkle(kEvrak, e, treeKrediHesapBilgileri);
                        }
                        break;

                    case "AV001_TDIE_BIL_PROJE_ILAM_BILGILERI":
                        if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                        {
                            e.Nodes.Remove(e.Nodes.FirstNode);
                        }
                        else
                        {
                            return;
                        }
                        prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;

                        DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(prj, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TDIE_BIL_PROJE_ILAM_BILGILERI>));

                        foreach (AV001_TDIE_BIL_PROJE_ILAM_BILGILERI kEvrak in prj.AV001_TDIE_BIL_PROJE_ILAM_BILGILERICollection)
                        {
                            nodeEkle(kEvrak, e, treeKrediHesapBilgileri);
                        }
                        break;
                }
            }
            else if (e.Tag is AV001_TDIE_BIL_PROJE)
            {
                if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                {
                    e.Nodes.Remove(e.Nodes.FirstNode);
                }
                else
                {
                    return;
                }
                foreach (TreeListNode node in e.Nodes)
                {
                    nodeDoldur(node);
                }
            }

            else if (e.Tag is TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)
            {
                if (e.Nodes.FirstNode != null && e.Nodes.FirstNode.Tag is bool)
                {
                    e.Nodes.Remove(e.Nodes.FirstNode);
                }
                else
                {
                    return;
                }
                AV001_TDIE_BIL_PROJE prj = null;
                prj = (AV001_TDIE_BIL_PROJE)e.ParentNode.Tag;
                TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK> kEvrakList = DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.GetByPROJE_ID(prj.ID);
                List<int> idList = new List<int>();
                kEvrakList.ForEach(item => idList.Add(item.KIYMETLI_EVRAK_ID));
                var kiymetliEvraklar = BelgeUtil.Inits.KiymetliEvrakGetirByIdList(idList).Where(item => item.MUNZAM_SENET_MI.HasValue && item.MUNZAM_SENET_MI.Value);

                foreach (var item in kiymetliEvraklar)
                {
                    AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = new AV001_TDI_BIL_KIYMETLI_EVRAK();
                    kEvrak.ID = item.KIYMETLI_EVRAK_ID;
                    nodeEkle(kEvrak, e, treeKrediHesapBilgileri);
                }

                TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI> kEvrakTakipliList = DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.GetByPROJE_ID(prj.ID);
                List<int> idListT = new List<int>();
                kEvrakTakipliList.ForEach(item => idListT.Add(item.KIYMETLI_EVRAK_ID));
                var kiymetliEvraklarT = BelgeUtil.Inits.KiymetliEvrakGetirByIdList(idListT).Where(item => item.MUNZAM_SENET_MI.HasValue && item.MUNZAM_SENET_MI.Value);

                foreach (var item in kiymetliEvraklarT)
                {
                    AV001_TDI_BIL_KIYMETLI_EVRAK kEvrakT = new AV001_TDI_BIL_KIYMETLI_EVRAK();
                    kEvrakT.ID = item.KIYMETLI_EVRAK_ID;
                    nodeEkle(kEvrakT, e, treeKrediHesapBilgileri);
                }
            }

            #endregion treenodes
        }

        public void projeGuncelle(TList<AV001_TDIE_BIL_PROJE> proje)
        {
            treeKrediHesapBilgileri.Enabled = false;
            if (proje != null)
                GetProje = proje;
            else
            {
                AV001_TDIE_BIL_PROJE prj = new AV001_TDIE_BIL_PROJE();
                TreeListNode node = treeKrediHesapBilgileri.FocusedNode;
                if (node.Tag is AV001_TDIE_BIL_PROJE)
                {
                    prj = node.Tag as AV001_TDIE_BIL_PROJE;
                }
                else if (node.ParentNode != null && node.ParentNode.Tag is AV001_TDIE_BIL_PROJE)
                {
                    prj = node.ParentNode.Tag as AV001_TDIE_BIL_PROJE;
                }
                else if (node.ParentNode != null && node.ParentNode.ParentNode != null &&
                         node.ParentNode.ParentNode.Tag is AV001_TDIE_BIL_PROJE)
                {
                    prj = node.ParentNode.ParentNode.Tag as AV001_TDIE_BIL_PROJE;
                }
                GetProje = new TList<AV001_TDIE_BIL_PROJE>();
                GetProje.Add(prj);

                DeepLoadProje(prj);
                DeepLoadProjeTamamlandı(prj);

                VList<DS_VDIE_BIL_PROJE_TARAF> projeTaraflari =
                    DataRepository.DS_VDIE_BIL_PROJE_TARAFProvider.Get(string.Format("PROJE_ID={0}", prj.ID), "CARI_ID ASC");

                bool kayitGirdi = false;
                if (prj.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(prj, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
                foreach (var item in projeTaraflari)
                {
                    if (!prj.AV001_TDIE_BIL_PROJE_TARAFCollection.Exists(vi => vi.CARI_ID == item.CARI_ID) &&
                        item.CARI_ID.HasValue)
                    {
                        prj.AV001_TDIE_BIL_PROJE_TARAFCollection.Add(new AV001_TDIE_BIL_PROJE_TARAF
                                                                         {
                                                                             CARI_ID = item.CARI_ID.Value,
                                                                             PROJE_ID = item.PROJE_ID
                                                                         });
                        kayitGirdi = true;
                    }
                }
                if (kayitGirdi)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj, DeepSaveType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
            }

            treeKrediHesapBilgileri.Enabled = true;
        }

        private TList<AV001_TDI_BIL_CARI> AktifTaraflariGetir()
        {
            TList<AV001_TDI_BIL_CARI> sonuc = new TList<AV001_TDI_BIL_CARI>();

            var carilerTakipEden = AvukatProLib2.Data.Bases.AV001_TDI_BIL_CARIProviderBaseCore.Fill(DataRepository.Provider.ExecuteReader(CommandType.Text, string.Format("EXEC dbo._AV001_TDI_BIL_CARI_GetProjeTaraflariByProjeId {0} , {1} ", (bndProje.Current as AV001_TDIE_BIL_PROJE).ID, (byte)1)), new TList<AV001_TDI_BIL_CARI>(), 0, int.MaxValue);
            var carilerTakipEdilen = AvukatProLib2.Data.Bases.AV001_TDI_BIL_CARIProviderBaseCore.Fill(DataRepository.Provider.ExecuteReader(CommandType.Text, string.Format("EXEC dbo._AV001_TDI_BIL_CARI_GetProjeTaraflariByProjeId {0} , {1} ", (bndProje.Current as AV001_TDIE_BIL_PROJE).ID, (byte)2)), new TList<AV001_TDI_BIL_CARI>(), 0, int.MaxValue);

            foreach (var item in carilerTakipEden)
            {
                item.Tag = "M";
                sonuc.Add(item);
            }
            foreach (var item in carilerTakipEdilen)
            {
                item.Tag = "B";
                sonuc.Add(item);
            }

            return sonuc;
        }

        private TreeListNode AlacakNedenTaraf(AV001_TI_BIL_ALACAK_NEDEN nd, TreeListNode node)
        {
            TreeListNode ndT = null;

            var tarafList = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDEN_TARAFs.Where(item => item.ICRA_ALACAK_NEDEN_ID == nd.ID && item.TARAF_SIFAT_ID != (int)TarafSifat.ALACAKLI);
            foreach (var item in tarafList)
            {
                AV001_TI_BIL_ALACAK_NEDEN_TARAF taraf = new AV001_TI_BIL_ALACAK_NEDEN_TARAF();
                taraf.ID = item.ID;
                taraf.TARAF_SIFAT_ID = item.TARAF_SIFAT_ID;
                ndT = nodeEkle(taraf, node, treeKrediHesapBilgileri);
            }
            return ndT;
        }

        private DataRow dataRowYap(string adi, string aciklama)
        {
            DataRow dr = _ProjeTable.NewRow();
            dr["ADI"] = adi;
            dr["ACIKLAMA"] = aciklama;
            return dr;
        }

        private TreeListNode DavaDosyasiTaraflari(AV001_TD_BIL_FOY foy, TreeListNode node)
        {
            TreeListNode ndT = null;

            if (BelgeUtil.Inits._TD_FoyTarafGetir == null)
                BelgeUtil.Inits._TD_FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TD_BIL_FOY_TARAFs.ToList();

            var foyTaraflari = BelgeUtil.Inits._TD_FoyTarafGetir.FindAll(vi => vi.DAVA_FOY_ID == foy.ID && vi.TARAF_KODU != (int)TarafKodlari.M);

            foyTaraflari.ForEach(item =>
            {
                AV001_TD_BIL_FOY_TARAF taraf = new AV001_TD_BIL_FOY_TARAF();
                taraf.ID = item.ID;
                taraf.TARAF_SIFAT_ID = item.TARAF_SIFAT_ID;
                ndT = nodeEkle(taraf, node, treeKrediHesapBilgileri);
            });
            return ndT;
        }

        private void DeepLoadProje(AV001_TDIE_BIL_PROJE secilenProje)
        {
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(secilenProje, false
                                                                 , DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_BELGE>),
                                                                 typeof(TList<NN_GORUSME_PROJE>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_HATIRLATMA>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_TESPIT>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_SORUMLU>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_HESAP>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_TEKLIF_KARAR>)
                );
        }

        private void DeepLoadProjeTamamlandı(AV001_TDIE_BIL_PROJE secilenProje)
        {
            treeKrediHesapBilgileri.Enabled = false;
            TList<AV001_TDIE_BIL_PROJE> projelerim = new TList<AV001_TDIE_BIL_PROJE> { secilenProje };

            bndProje.List.Clear();
            projelerim.ForEach(vi => bndProje.List.Add(vi));
            treeKrediHesapBilgileri.Nodes.Clear();

            //Okan Hesap Tipi Binding 23.11.2010
            lueHesapTipi.EditValue = secilenProje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count > 0 ? secilenProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].HESAPLAMA_TIPI.ToString() : "2";
            lueHesapTipi.EditValueChanged += new EventHandler(lueHesapTipi_EditValueChanged);

            foreach (AV001_TDIE_BIL_PROJE proje in projelerim)
            {
                var projeChildCounts = BelgeUtil.Inits.context.ProjeChildCount(proje.ID).Single();

                proje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN.ApplyFilter(
                    vi => vi.AN_URETIP_TIP != (byte)AvukatProLib.Extras.AN_URETIP_TIP.SenetleTakibeKonuldu);

                TreeListNode nd = nodeEkle(dataRowYap(proje.ADI, proje.KOD), null, proje, 0, treeKrediHesapBilgileri);
                nodeDoldur(nd);

                bool alacakVar = projeChildCounts.ALACAK_NEDEN_COUNT > 0 || projeChildCounts.ALACAK_NEDEN_TAKIPLI_COUNT > 0;
                TreeListNode nd1 = nodeEkle(dataRowYap("Alacaklar", ""), nd, proje, 2, treeKrediHesapBilgileri,
                                            alacakVar);
                nodeDoldur(nd1);

                bool munzamSenetVar = projeChildCounts.MUNZAM_SENET_COUNT > 0 || projeChildCounts.MUNZAM_SENET_TAKIPLI_COUNT > 0;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> evraklar = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK(proje.ID);
                TreeListNode nd9 = nodeEkle(dataRowYap("Alacak Senedi", ""), nd, proje, 2, treeKrediHesapBilgileri, munzamSenetVar);
                nodeDoldur(nd9);

                bool ihtiyatiHacizVar = projeChildCounts.IHTIYATI_HACIZ_COUNT > 0 || projeChildCounts.IHTIYATI_HACIZ_TAKIPLI_COUNT > 0;
                TreeListNode nd2 = nodeEkle(dataRowYap("İhtiyati Haciz", ""), nd, proje, 2, treeKrediHesapBilgileri, ihtiyatiHacizVar);
                nodeDoldur(nd2);

                bool ihtiyatiTedbirVar = projeChildCounts.IHTIYATI_TEDBIR_COUNT > 0 || projeChildCounts.IHTIYATI_TEDBIR_TAKIPLI_COUNT > 0;
                TreeListNode nd4 = nodeEkle(dataRowYap("İhtiyati Tedbir", ""), nd, proje, 2, treeKrediHesapBilgileri, ihtiyatiTedbirVar);
                nodeDoldur(nd4);

                bool teminatVar = projeChildCounts.TEMINAT_COUNT > 0 || projeChildCounts.TEMINAT_TAKIPLI_COUNT > 0 || projeChildCounts.KIYMETLI_EVRAK_COUNT > 0 || projeChildCounts.KIYMETLI_EVRAK_TAKIPLI_COUNT > 0;
                TreeListNode nd3 = nodeEkle(dataRowYap("Teminatlar", ""), nd, proje, 2, treeKrediHesapBilgileri, teminatVar);
                nodeDoldur(nd3);

                TreeListNode nd5 = nodeEkle(dataRowYap("Alacaklar", "Takip Bekliyor"), nd1, typeof(AV001_TI_BIL_ALACAK_NEDEN), 2, treeKrediHesapBilgileri, projeChildCounts.ALACAK_NEDEN_COUNT > 0);
                nodeDoldur(nd5);

                TreeListNode nd6 = nodeEkle(dataRowYap("Alacaklar", "Takipde"), nd1, typeof(AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI), 2, treeKrediHesapBilgileri, projeChildCounts.ALACAK_NEDEN_TAKIPLI_COUNT > 0);
                nodeDoldur(nd6);

                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> bekleyenMunzamList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                (DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.GetByPROJE_ID(proje.ID)).ForEach(item =>
                    {
                        var kEvrak = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(item.KIYMETLI_EVRAK_ID);
                        if (kEvrak != null && kEvrak.MUNZAM_SENET_MI.HasValue && kEvrak.MUNZAM_SENET_MI.Value) bekleyenMunzamList.Add(kEvrak);
                    });

                TreeListNode nd10 = nodeEkle(dataRowYap("Alacak Senedi", "Takip Bekliyor"), nd9, bekleyenMunzamList, 2, treeKrediHesapBilgileri, projeChildCounts.MUNZAM_SENET_COUNT > 0);
                nodeDoldur(nd10);

                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> takipteMunzamList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();

                (DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.GetByPROJE_ID(proje.ID)).ForEach(item =>
                {
                    var kEvrak = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(item.KIYMETLI_EVRAK_ID);
                    if (kEvrak != null && kEvrak.MUNZAM_SENET_MI.HasValue && kEvrak.MUNZAM_SENET_MI.Value) takipteMunzamList.Add(kEvrak);
                });
                TreeListNode nd11 = nodeEkle(dataRowYap("Alacak Senedi", "Takipte"), nd9, takipteMunzamList, 2, treeKrediHesapBilgileri, projeChildCounts.MUNZAM_SENET_TAKIPLI_COUNT > 0);
                nodeDoldur(nd11);

                TreeListNode nd7 = nodeEkle(dataRowYap("Dava Dosyaları", ""), nd, typeof(AV001_TD_BIL_FOY), 3, treeKrediHesapBilgileri, projeChildCounts.DAVA_FOY_COUNT > 0);
                nodeDoldur(nd7);

                nd8 = nodeEkle(dataRowYap("Soruşturma Dosyaları", ""), nd, typeof(AV001_TD_BIL_HAZIRLIK), 2, treeKrediHesapBilgileri, projeChildCounts.HAZIRLIK_COUNT > 0);
                nodeDoldur(nd8);

                nodeDoldur(nodeEkle(dataRowYap("Teminatlar (Takip Bekliyor)", "Mal Bilgileri"), nd3, typeof(TDI_BIL_BORCLU_MAL), 3, treeKrediHesapBilgileri, projeChildCounts.BORCLU_MAL_COUNT > 0));

                nodeDoldur(nodeEkle(dataRowYap("Teminatlar (Takip Bekliyor)", "Resmi Senet"), nd3, typeof(AV001_TDIE_BIL_PROJE_TEMINAT), 3, treeKrediHesapBilgileri, projeChildCounts.TEMINAT_COUNT > 0));

                nodeDoldur(nodeEkle(dataRowYap("Teminatlar (Takipde)", "Resmi Senet"), nd3, typeof(AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI), 3, treeKrediHesapBilgileri, projeChildCounts.TEMINAT_TAKIPLI_COUNT > 0));

                int projeEvrakCount = projeChildCounts.KIYMETLI_EVRAK_COUNT.Value - projeChildCounts.MUNZAM_SENET_COUNT.Value;
                nodeDoldur(nodeEkle(dataRowYap("Teminatlar (Takip Bekliyor)", "Kıymetli Evrak"), nd3,
                                    typeof(AV001_TDI_BIL_KIYMETLI_EVRAK), 3, treeKrediHesapBilgileri,
                                    projeEvrakCount > 0));

                nodeDoldur(nodeEkle(dataRowYap("Teminatlar (Takipde)", "Kıymetli Evrak"), nd3,
                                    typeof(AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI), 3, treeKrediHesapBilgileri,
                                    projeChildCounts.KIYMETLI_EVRAK_TAKIPLI_COUNT > 0));

                nodeDoldur(nodeEkle(dataRowYap("Rücu Dosyaları", ""), nd, typeof(AV001_TDI_BIL_RUCU), 4,
                                    treeKrediHesapBilgileri, projeChildCounts.RUCU_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Sözleşmeler", ""), nd, typeof(AV001_TDI_BIL_SOZLESME), 5,
                                    treeKrediHesapBilgileri, projeChildCounts.SOZLESME_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Ödemeler", ""), nd, typeof(AV001_TI_BIL_BORCLU_ODEME), 3,
                                    treeKrediHesapBilgileri, projeChildCounts.BORCLU_ODEME_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Takip Bekliyor", ""), nd2, typeof(AV001_TI_BIL_IHTIYATI_HACIZ), 3,
                                    treeKrediHesapBilgileri, projeChildCounts.IHTIYATI_HACIZ_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Takipde", ""), nd2, typeof(AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI),
                                    3, treeKrediHesapBilgileri, projeChildCounts.IHTIYATI_HACIZ_TAKIPLI_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("İhtiyati Tedbir", "Takip Bekliyor"), nd4,
                                    typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR), 3, treeKrediHesapBilgileri,
                                    projeChildCounts.IHTIYATI_TEDBIR_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("İhtiyati Tedbir", "Takipde"), nd4,
                                    typeof(AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI), 3, treeKrediHesapBilgileri,
                                    projeChildCounts.IHTIYATI_TEDBIR_TAKIPLI_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Masraflar", ""), nd, typeof(AV001_TDI_BIL_MASRAF_AVANS), 3,
                                    treeKrediHesapBilgileri, projeChildCounts.MASRAF_AVANS_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("Ihtarname", ""), nd, typeof(AV001_TDIE_BIL_PROJE_IHTARNAME), 3,
                                    treeKrediHesapBilgileri, projeChildCounts.IHTARNAME_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("İlam Bilgileri", ""), nd, typeof(AV001_TDIE_BIL_PROJE_ILAM_BILGILERI),
                                    3, treeKrediHesapBilgileri,
                                    projeChildCounts.ILAM_BILGILERI_COUNT > 0));
                nodeDoldur(nodeEkle(dataRowYap("İcra Dosyaları", ""), nd, typeof(AV001_TI_BIL_FOY), 1,
                                    treeKrediHesapBilgileri, projeChildCounts.ICRA_FOY_COUNT > 0));
                projeleriEkle(proje, nd);
            }
            treeKrediHesapBilgileri.Enabled = true;
        }

        private TreeListNode IcraDosyasiTaraflari(AV001_TI_BIL_FOY foy, TreeListNode node)
        {
            TreeListNode ndT = null;

            if (BelgeUtil.Inits._FoyTarafGetir == null)
                BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();

            var foyTaraflari = BelgeUtil.Inits._FoyTarafGetir.FindAll(vi => vi.ICRA_FOY_ID == foy.ID && !vi.TAKIP_EDEN_MI);

            foyTaraflari.ForEach(item =>
                {
                    AV001_TI_BIL_FOY_TARAF taraf = new AV001_TI_BIL_FOY_TARAF();
                    taraf.ID = item.ID;
                    taraf.TARAF_SIFAT_ID = item.TARAF_SIFAT_ID;
                    ndT = nodeEkle(taraf, node, treeKrediHesapBilgileri);
                });
            return ndT;
        }

        private TreeListNode IliskiliKayıtEkle(AV001_TI_BIL_FOY nd, TreeListNode node, TreeListNode parentNode)
        {
            TreeListNode ndT = null;
            List<int> kayitIliskiIdList = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_KAYIT_ILISKIs where item.KAYNAK_ICRA_FOY_ID == nd.ID select item.ID).ToList();

            foreach (int id in kayitIliskiIdList)
            {
                AV001_TDI_BIL_KAYIT_ILISKI_DETAYQuery detay = new AV001_TDI_BIL_KAYIT_ILISKI_DETAYQuery();
                detay.AppendIsNotNull(AV001_TDI_BIL_KAYIT_ILISKI_DETAYColumn.HEDEF_ICRA_FOY_ID);
                detay.AppendIsNotNull(AV001_TDI_BIL_KAYIT_ILISKI_DETAYColumn.HEDEF_HAZIRLIK_ID);
                detay.AppendEquals(AV001_TDI_BIL_KAYIT_ILISKI_DETAYColumn.KAYIT_ILISKI_ID, id.ToString());

                TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY> iliskiDetay = DataRepository.AV001_TDI_BIL_KAYIT_ILISKI_DETAYProvider.Find(detay);

                foreach (var item2 in iliskiDetay)
                {
                    if (item2.HEDEF_ICRA_FOY_ID.HasValue)
                    {
                        ndT = nodeEkle(item2, node, treeKrediHesapBilgileri);
                    }
                    if (item2.HEDEF_HAZIRLIK_ID.HasValue)
                    {
                        item2.HEDEF_HAZIRLIK_IDSource = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(item2.HEDEF_HAZIRLIK_ID.Value);
                        ndT = nodeEkle(item2.HEDEF_HAZIRLIK_IDSource, nd8, treeKrediHesapBilgileri);
                    }
                }
            }

            return ndT;
        }

        // Okan 23.11.2010
        private void lueHesapTipi_EditValueChanged(object sender, EventArgs e)
        {
            var proje = AktifProjeyiGetir(false);
            if (proje == null || proje.AV001_TDIE_BIL_PROJE_HESAPCollection.Count == 0) return;
            AvukatProLib.Hesap.Hesap.Hesaplansinmi = true;
            proje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].HESAPLAMA_TIPI = Convert.ToInt32(lueHesapTipi.EditValue);
            DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.Save(proje.AV001_TDIE_BIL_PROJE_HESAPCollection);
        }

        private TreeListNode nodeEkle(object dataRow, TreeListNode parent, object tag, int imageIndex, TreeList treeList, bool bosChildVarmi)
        {
            //Node içinde eleman var.
            if (bosChildVarmi)
            {
                TreeListNode nd = nodeEkle(dataRow, parent, tag, imageIndex, treeList);
                treeList.AppendNode(true, nd, true);
                return nd;
            }
            else
                return null;
        }

        private TreeListNode nodeEkle(object dataRow, TreeListNode parent, object tag, int imageIndex, TreeList treeList)
        {
            TreeListNode nd = treeList.AppendNode(dataRow, parent, tag);

            nd.StateImageIndex = imageIndex;
            return nd;
        }

        private TreeListNode nodeEkle(EntityBase entityBase, TreeListNode parentNode, TreeList treeList)
        {
            TreeListNode result = null;
            switch (entityBase.GetType().Name)
            {
                case "AV001_TI_BIL_FOY":

                    #region AV001_TI_BIL_FOY

                    AV001_TI_BIL_FOY foy = (AV001_TI_BIL_FOY)entityBase;

                    int kayitIliskiCount = BelgeUtil.Inits.context.AV001_TDI_BIL_KAYIT_ILISKIs.Count(item => item.KAYNAK_ICRA_FOY_ID == foy.ID);
                    if (kayitIliskiCount >= 0)
                    {
                        AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA icraAciklama = null;
                        string aciklama = FoyAciklamaGetir(foy, out icraAciklama);
                        string foyDurum = String.IsNullOrEmpty(icraAciklama.DURUM) ? "" : icraAciklama.DURUM;
                        result = treeList.AppendNode(dataRowYap("Esas Takip:" + foy.FOY_NO + string.Format(" ({0})", String.IsNullOrEmpty(icraAciklama.DURUM) ? "" : icraAciklama.DURUM), aciklama), parentNode, foy);
                    }
                    if (result != null)
                    {
                        if (kayitIliskiCount > 0)
                            IliskiliKayıtEkle(foy, result, parentNode);
                    }

                    IcraDosyasiTaraflari(foy, result);

                    #endregion AV001_TI_BIL_FOY

                    break;

                case "AV001_TDI_BIL_KAYIT_ILISKI_DETAY":
                    AV001_TDI_BIL_KAYIT_ILISKI_DETAY dt = (AV001_TDI_BIL_KAYIT_ILISKI_DETAY)entityBase;
                    AV001_TI_BIL_FOY icraFoy = new AV001_TI_BIL_FOY();
                    string isim = "Alt Takip : ";
                    int foyId = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_KAYIT_ILISKI_DETAYs where item.ID == dt.ID select item.HEDEF_ICRA_FOY_ID.Value).Single();
                    icraFoy.ID = foyId;
                    AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA icraAcklm = null;
                    string acklm = FoyAciklamaGetir(foyId, out icraAcklm);
                    result = treeList.AppendNode(dataRowYap(isim + icraAcklm.FOY_NO, acklm), parentNode, icraFoy);
                    break;

                case "AV001_TDIE_BIL_PROJE_TEMINAT":
                    AV001_TDI_BIL_SOZLESME sozles = (AV001_TDI_BIL_SOZLESME)entityBase;
                    AvukatProLib.Arama.per_SOZLESME_ACIKLAMA sozlesmeAciklama = null;
                    string sozAciklamaText = SozlesmeAciklamaGetir(sozles, out sozlesmeAciklama);
                    result = treeList.AppendNode(dataRowYap(String.IsNullOrEmpty(sozlesmeAciklama.ALT_TIP) ? " - " : sozlesmeAciklama.ALT_TIP, sozAciklamaText), parentNode, sozles);
                    break;

                case "AV001_TD_BIL_FOY":
                    AV001_TD_BIL_FOY dfoy = (AV001_TD_BIL_FOY)entityBase;
                    AvukatProLib.Arama.per_DAVA_FOY_ACIKLAMA davaAciklama = null;
                    string davaFoyAciklama = FoyAciklamaGetir(dfoy, out davaAciklama);

                    var hukumList = DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.GetByDAVA_FOY_ID(dfoy.ID);
                    var temyizList = DataRepository.AV001_TD_BIL_TEMYIZProvider.GetByDAVA_FOY_ID(dfoy.ID);

                    string tarihAciklama = string.Empty;
                    Dictionary<string, string> aciklamaList = new Dictionary<string, string>();

                    if (BelgeUtil.Inits._HukumGetir == null)
                        BelgeUtil.Inits._HukumGetir = DataRepository.per_TD_KOD_MAHKEME_HUKUMProvider.GetAll();

                    foreach (var item in hukumList)
                    {
                        var karar = BelgeUtil.Inits._HukumGetir.Find(vi => vi.ID == item.HUKUM_ID).HUKUM;
                        if (aciklamaList.Where(vi => vi.Key == karar).Count() == 0)
                            aciklamaList.Add(karar, item.HUKUM_TARIHI.ToShortDateString());
                    }

                    if (BelgeUtil.Inits._KararTipGetir == null)
                    {
                        BelgeUtil.Inits._KararTipGetir = DataRepository.per_TD_KOD_YUKSEK_MAHKEME_KARAR_TIPProvider.GetAll();
                    }

                    if (BelgeUtil.Inits._TemyizTipGetir == null)
                    {
                        BelgeUtil.Inits._TemyizTipGetir = DataRepository.per_TD_KOD_TEMYIZ_TIPProvider.GetAll();
                    }

                    DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(temyizList, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));

                    foreach (var item in temyizList)
                    {
                        foreach (var taraf in item.AV001_TD_BIL_TEMYIZ_TARAFCollection)
                        {
                            var temyiz = BelgeUtil.Inits._TemyizTipGetir.Find(vi => vi.ID == item.TEMYIZ_TIP_ID).TEMYIZ_TIP;
                            if (aciklamaList.ContainsKey(temyiz))
                            {
                                if (taraf.SURE_TUTUM_TARIHI.HasValue)
                                    aciklamaList[temyiz] = taraf.SURE_TUTUM_TARIHI.Value.ToShortDateString();
                            }
                            else
                            {
                                if (taraf.SURE_TUTUM_TARIHI.HasValue)
                                    aciklamaList.Add(temyiz, taraf.SURE_TUTUM_TARIHI.Value.ToShortDateString());
                            }
                        }
                        if (!item.KARAR_TIP_ID.HasValue) continue;

                        var karar = BelgeUtil.Inits._KararTipGetir.Find(vi => vi.ID == item.KARAR_TIP_ID).KARAR_TIP;
                        if (item.KARAR_TARIHI.HasValue && aciklamaList.Where(vi => vi.Key == karar && vi.Value == item.KARAR_TARIHI.Value.ToShortDateString()).Count() == 0) aciklamaList.Add(karar, item.KARAR_TARIHI.Value.ToShortDateString());
                    }
                    var list = aciklamaList.OrderBy(vi => Convert.ToDateTime(vi.Value));
                    foreach (var item in list)
                    {
                        tarihAciklama += item.Value + " " + item.Key + Environment.NewLine;
                    }

                    result = treeList.AppendNode(dataRowYap(davaAciklama.FOY_NO + string.Format(" ({0}) {1}", String.IsNullOrEmpty(davaAciklama.DURUM) ? "" : davaAciklama.DURUM, tarihAciklama), davaFoyAciklama), parentNode, dfoy);

                    DavaDosyasiTaraflari(dfoy, result);

                    break;

                case "AV001_TDI_BIL_IS":
                    AV001_TDI_BIL_IS ish = (AV001_TDI_BIL_IS)entityBase;
                    break;

                case "AV001_TD_BIL_HAZIRLIK":
                    AV001_TD_BIL_HAZIRLIK hzr = (AV001_TD_BIL_HAZIRLIK)entityBase;
                    AvukatProLib.Arama.per_HAZIRLIK_ACIKLAMA hazirlikAciklama = null;
                    string hAciklama = HazirlikAciklamaGetir(hzr, out hazirlikAciklama);
                    result = treeList.AppendNode(dataRowYap(hazirlikAciklama.HAZIRLIK_NO + string.Format(" ({0})", String.IsNullOrEmpty(hazirlikAciklama.DURUM) ? "" : hazirlikAciklama.DURUM), hAciklama), parentNode, hzr);
                    break;

                case "AV001_TDI_BIL_RUCU":
                    AV001_TDI_BIL_RUCU rucu = (AV001_TDI_BIL_RUCU)entityBase;
                    var rucuTemp = BelgeUtil.Inits.context.per_AV001_TDI_BIL_RUCUs.Single(item => item.ID == rucu.ID);
                    result = treeList.AppendNode(dataRowYap(rucuTemp.DOSYA_NO, rucuTemp.ACIKLAMA), parentNode, rucu);
                    break;

                case "AV001_TDI_BIL_MASRAF_AVANS":
                    AV001_TDI_BIL_MASRAF_AVANS mAvans = (AV001_TDI_BIL_MASRAF_AVANS)entityBase;
                    AvukatProLib.Arama.per_MASRAF_AVANS_ACIKLAMA mAciklama = null;
                    string maAciklamaText = MasrafAvansAciklamaGetir(mAvans, out mAciklama);
                    result = treeList.AppendNode(dataRowYap(mAciklama.REFERANS_NO, maAciklamaText), parentNode, mAvans);
                    break;

                case "AV001_TDIE_BIL_BELGE":
                    AV001_TDIE_BIL_BELGE belge = (AV001_TDIE_BIL_BELGE)entityBase;
                    var bel = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Single(item => item.ID == belge.ID);
                    result = treeList.AppendNode(dataRowYap(bel.KAYIT_TARIHI.ToString(), bel.ACIKLAMA), parentNode, belge);
                    break;

                case "AV001_TDI_BIL_TEBLIGAT":
                    AV001_TDI_BIL_TEBLIGAT tebligat = (AV001_TDI_BIL_TEBLIGAT)entityBase;
                    var res = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_TEBLIGATs where item.ID == tebligat.ID select new { item.POSTALANMA_TARIH, item.ACIKLAMA }).Single();
                    result = treeList.AppendNode(dataRowYap(res.POSTALANMA_TARIH.ToString(), res.ACIKLAMA), parentNode, tebligat);
                    break;

                case "AV001_TDI_BIL_GORUSME":
                    AV001_TDI_BIL_GORUSME gorusme = (AV001_TDI_BIL_GORUSME)entityBase;
                    var gor = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_GORUSMEs where item.ID == gorusme.ID select new { item.KAYIT_TARIHI, item.GORUSENIN_NOTU }).Single();
                    result = treeList.AppendNode(dataRowYap(gor.KAYIT_TARIHI.ToString(), gor.GORUSENIN_NOTU), parentNode, gorusme);
                    break;

                case "AV001_TDI_BIL_MUHASEBE":
                    AV001_TDI_BIL_MUHASEBE muhasebe = (AV001_TDI_BIL_MUHASEBE)entityBase;
                    var muh = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_MUHASEBEs where item.ID == muhasebe.ID select new { item.KAYIT_TARIHI, item.ACIKLAMA }).Single();
                    result = treeList.AppendNode(dataRowYap(muh.KAYIT_TARIHI.ToString(), muh.ACIKLAMA), parentNode, muhasebe);
                    break;

                case "AV001_TDI_BIL_SOZLESME":
                    AV001_TDI_BIL_SOZLESME sozlesme = (AV001_TDI_BIL_SOZLESME)entityBase;
                    AvukatProLib.Arama.per_SOZLESME_ACIKLAMA sozAciklama = null;
                    string sozlesmeAciklamaText = SozlesmeAciklamaGetir(sozlesme, out sozAciklama);
                    result = treeList.AppendNode(dataRowYap(String.IsNullOrEmpty(sozAciklama.ALT_TIP) ? " - " : sozAciklama.ALT_TIP, sozlesmeAciklamaText), parentNode, sozlesme);

                    SozlesmeDetaylari(sozlesme, result);
                    break;

                case "AV001_TI_BIL_ALACAK_NEDEN":
                    AV001_TI_BIL_ALACAK_NEDEN alacakNeden = (AV001_TI_BIL_ALACAK_NEDEN)entityBase;
                    var perANeden = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Single(item => item.ALACAK_NEDEN_ID == alacakNeden.ID);
                    string munzamAciklamasi = string.Empty;
                    if (perANeden.AN_URETIP_TIP == (byte)AN_URETIP_TIP.MunzamSenet)
                        munzamAciklamasi = "Alacak Senedi";
                    result = treeList.AppendNode(dataRowYap(perANeden.DIGER_ALACAK_NEDENI, String.Format("{4} Dz.T:{0:d} - Tutar:{1:###,###,###,##0.00} {2} {3}", perANeden.DUZENLENME_TARIHI, perANeden.ISLEME_KONAN_TUTAR, (DovizTip)(perANeden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 0), perANeden.ICRA_FOY_ID.HasValue ? GetFoyBilgileri(perANeden.ICRA_FOY_ID.Value) : "", munzamAciklamasi)), parentNode, alacakNeden);
                    AlacakNedenTaraf(alacakNeden, result);
                    break;

                case "AV001_TI_BIL_BORCLU_ODEME":
                    AV001_TI_BIL_BORCLU_ODEME borcluOdeme = (AV001_TI_BIL_BORCLU_ODEME)entityBase;
                    var perOdeme = BelgeUtil.Inits.context.per_AV001_TI_BIL_BORCLU_ODEMEs.Single(item => item.ID == borcluOdeme.ID);
                    result = treeList.AppendNode(dataRowYap(perOdeme.ODEME_TARIHI.ToShortDateString(), string.Format(@"{0:d} Tarihli Ödeme {1}", perOdeme.ODEME_TARIHI, new ParaVeDovizId(perOdeme.ODEME_MIKTAR, perOdeme.ODEME_MIKTAR_DOVIZ_ID).GetStringValue())), parentNode, borcluOdeme);
                    break;

                case "AV001_TI_BIL_ALACAK_NEDEN_TARAF":
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF ALtRF = (AV001_TI_BIL_ALACAK_NEDEN_TARAF)entityBase;
                    var perTaraf = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDEN_TARAFs.Single(item => item.ID == ALtRF.ID);
                    string sifat = String.IsNullOrEmpty(perTaraf.SIFAT) ? "Taraf Sıfatı Seçilmemiş" : perTaraf.SIFAT;

                    if (!String.IsNullOrEmpty(perTaraf.AD))
                        result = treeList.AppendNode(dataRowYap(sifat, perTaraf.AD + " " + string.Format("Tutar:{0:###,###,###,##0.00}", perTaraf.SORUMLU_OLUNAN_MIKTAR) + " " + perTaraf.DOVIZ_KODU), parentNode, ALtRF);
                    break;

                case "AV001_TI_BIL_FOY_TARAF":
                    AV001_TI_BIL_FOY_TARAF foyTaraf = (AV001_TI_BIL_FOY_TARAF)entityBase;
                    var perFoyTaraf = BelgeUtil.Inits._FoyTarafGetir.Find(vi => vi.ID == foyTaraf.ID);
                    if (BelgeUtil.Inits._CariSifatGetir == null)
                        BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                    result = treeList.AppendNode(dataRowYap(BelgeUtil.Inits._CariSifatGetir.Find(vi => vi.ID == foyTaraf.TARAF_SIFAT_ID).SIFAT, perFoyTaraf.AD), parentNode, foyTaraf);
                    break;

                case "AV001_TD_BIL_FOY_TARAF":
                    AV001_TD_BIL_FOY_TARAF davaFoyTaraf = (AV001_TD_BIL_FOY_TARAF)entityBase;
                    var perDavaFoyTaraf = BelgeUtil.Inits._TD_FoyTarafGetir.Find(vi => vi.ID == davaFoyTaraf.ID);
                    if (BelgeUtil.Inits._CariSifatGetir == null)
                        BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                    result = treeList.AppendNode(dataRowYap(BelgeUtil.Inits._CariSifatGetir.Find(vi => vi.ID == davaFoyTaraf.TARAF_SIFAT_ID).SIFAT, perDavaFoyTaraf.AD), parentNode, davaFoyTaraf);
                    break;

                case "AV001_TI_BIL_GAYRIMENKUL":
                    AV001_TI_BIL_GAYRIMENKUL gayrimenkul = (AV001_TI_BIL_GAYRIMENKUL)entityBase;
                    var gayrimenkulAciklama = BelgeUtil.Inits.context.per_GayrimenkulAciklamas.FirstOrDefault(vi => vi.ID == gayrimenkul.ID);
                    result = treeList.AppendNode(dataRowYap(string.Format("{0}: {1}, İli: {2}, İlçesi: {3}", gayrimenkulAciklama.TARAF_SIFAT, gayrimenkulAciklama.AD, gayrimenkulAciklama.IL, gayrimenkulAciklama.ILCE), string.Format("Mahalle: {0}, Sokak: {1}, Pafta: {2}, Ada: {3}, Parsel: {4}, Yevmiye: {5}, Niteliği: {6}", gayrimenkulAciklama.MAHALLE_ADI, gayrimenkulAciklama.SOKAK_ADI, gayrimenkulAciklama.PAFTA_NO, gayrimenkulAciklama.ADA_NO, gayrimenkulAciklama.PARSEL_NO, gayrimenkulAciklama.YEVMIYE_NO, gayrimenkulAciklama.NITELIGI)), parentNode, gayrimenkul);
                    break;

                case "AV001_TDI_BIL_GEMI_UCAK_ARAC":
                    AV001_TDI_BIL_GEMI_UCAK_ARAC gua = (AV001_TDI_BIL_GEMI_UCAK_ARAC)entityBase;
                    var guaAciklama = BelgeUtil.Inits.context.per_GemiUcakAracAciklamas.FirstOrDefault(vi => vi.ID == gua.ID);
                    result = treeList.AppendNode(dataRowYap(string.Format("Tipi: {0}", guaAciklama.TIP), string.Format("Cinsi: {0}, Adı: {1}, Plaka: {2}, Model: {3}, Motor No: {4},Şasi No: {5}", guaAciklama.CINSI, guaAciklama.ADI, guaAciklama.ARAC_PLAKA, guaAciklama.ARAC_MODEL, guaAciklama.ARAC_MOTOR_NO, guaAciklama.ARAC_SASI_NO)), parentNode, gua);
                    break;

                case "TDI_BIL_BORCLU_MAL":
                    TDI_BIL_BORCLU_MAL borcluMal = (TDI_BIL_BORCLU_MAL)entityBase;
                    AvukatProLib.Arama.per_BORCLU_MAL_ACIKLAMA bMalAciklama = null;
                    string bMalAciklamaText = BorcluMalAciklamaGetir(borcluMal, out bMalAciklama);
                    result = treeList.AppendNode(dataRowYap(!String.IsNullOrEmpty(bMalAciklama.AD) ? bMalAciklama.AD : ((AvukatProLib.Extras.HAZIZ_CHILD_TIP)borcluMal.TIP).ToString(), bMalAciklamaText), parentNode, borcluMal);
                    break;

                case "AV001_TI_BIL_IHTIYATI_HACIZ":
                    AV001_TI_BIL_IHTIYATI_HACIZ ihtiyatiHaciz = (AV001_TI_BIL_IHTIYATI_HACIZ)entityBase;
                    ihtiyatiHaciz.ICRA_FOY_ID = (from item in BelgeUtil.Inits.context.AV001_TI_BIL_IHTIYATI_HACIZs where item.ID == ihtiyatiHaciz.ID select ihtiyatiHaciz.ICRA_FOY_ID).SingleOrDefault();
                    AvukatProLib.Arama.per_IHTIYATI_HACIZ_ACIKLAMA ihAciklama = null;
                    string ihAciklamaText = IhtiyatiHacizAciklamaGetir(ihtiyatiHaciz, out ihAciklama);
                    result = treeList.AppendNode(dataRowYap(ihAciklama.ESAS_NO, ihAciklamaText), parentNode, ihtiyatiHaciz);
                    break;

                case "AV001_TDI_BIL_IHTIYATI_TEDBIR":
                    AV001_TDI_BIL_IHTIYATI_TEDBIR ihtiyatiTedbir = (AV001_TDI_BIL_IHTIYATI_TEDBIR)entityBase;
                    ihtiyatiTedbir.ICRA_FOY_ID = (from item in BelgeUtil.Inits.context.AV001_TDI_BIL_IHTIYATI_TEDBIRs where item.ID == ihtiyatiTedbir.ID select ihtiyatiTedbir.ICRA_FOY_ID).Single();
                    AvukatProLib.Arama.per_IHTIYATI_TEDBIR_ACIKLAMA itAciklama = null;
                    string itAciklamaText = IhtiyatiTedbirAciklamaGetir(ihtiyatiTedbir, out itAciklama);
                    result = treeList.AppendNode(dataRowYap(itAciklama.ESAS_NO, itAciklamaText), parentNode, ihtiyatiTedbir);
                    break;

                case "AV001_TDI_BIL_KIYMETLI_EVRAK":
                    AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak = (AV001_TDI_BIL_KIYMETLI_EVRAK)entityBase;
                    AvukatProLib.Arama.per_KIYMETLI_EVRAK_ACIKLAMA kEvrakaciklama = null;
                    string kEvrakAciklamaText = KiymetliEvrakAciklamaGetir(kEvrak, out kEvrakaciklama);
                    string tur = string.Empty;
                    if (kEvrak.MUNZAM_SENET_MI == true)
                    {
                        tur = !String.IsNullOrEmpty(kEvrakaciklama.TUR) ? kEvrakaciklama.TUR : "Tür Seçiniz" + "( MUNZAM )";
                    }
                    else if (kEvrak.TEMINAT_MI == true)
                    {
                        tur = !String.IsNullOrEmpty(kEvrakaciklama.TUR) ? kEvrakaciklama.TUR : "Tür Seçiniz" + "( TEMINAT )";
                    }
                    else
                    {
                        tur = !String.IsNullOrEmpty(kEvrakaciklama.TUR) ? kEvrakaciklama.TUR : "Tür Seçiniz";
                    }
                    result = treeList.AppendNode(dataRowYap(tur, kEvrakAciklamaText), parentNode, kEvrak);
                    break;

                case "AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI":
                    AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI kEvrakt = (AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI)entityBase;
                    if (kEvrakt == null) break;
                    var munzamMi = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(kEvrakt.KIYMETLI_EVRAK_ID).MUNZAM_SENET_MI ?? false;
                    if (!munzamMi)
                    {
                        AvukatProLib.Arama.per_KIYMETLI_EVRAK_ACIKLAMA kEvrakAciklama = null;
                        string EvrakAciklamaText = KiymetliEvrakAciklamaGetir(kEvrakt.KIYMETLI_EVRAK_ID, out kEvrakAciklama);
                        result = treeList.AppendNode(dataRowYap(kEvrakAciklama.TUR, EvrakAciklamaText), parentNode, kEvrakt);
                    }
                    break;

                case "AV001_TDIE_BIL_PROJE_IHTARNAME":
                    AV001_TDIE_BIL_PROJE_IHTARNAME tebli = (AV001_TDIE_BIL_PROJE_IHTARNAME)entityBase;
                    AvukatProLib.Arama.per_TEBLIGAT_ACIKLAMA tebAciklama = BelgeUtil.Inits.context.per_TEBLIGAT_ACIKLAMAs.Single(item => item.ID == tebli.TEBLIGAT_ID);

                    result = treeList.AppendNode(dataRowYap((tebAciklama.ADLIYE + " " + tebAciklama.NO + " " + tebAciklama.GOREV + " " + tebAciklama.TEBLIGAT_ESAS_NO), tebAciklama.POSTALANMA_TARIH.ToShortDateString() + tebAciklama.ADLIYE + " " + tebAciklama.NO + " " + tebAciklama.GOREV + " " + tebAciklama.TEBLIGAT_ESAS_NO + " " + tebAciklama.KONU), parentNode, tebli);
                    break;

                case "AV001_TDIE_BIL_PROJE_ILAM_BILGILERI":
                    AV001_TDIE_BIL_PROJE_ILAM_BILGILERI ilam = (AV001_TDIE_BIL_PROJE_ILAM_BILGILERI)entityBase;
                    var ilamAciklama = BelgeUtil.Inits.context.per_ILAM_ACIKLAMAs.Single(item => item.ID == ilam.ILAM_ID);
                    result = treeList.AppendNode(dataRowYap(ilamAciklama.BELGE_TUR, ilamAciklama.BELGE_TUR + " Esas No: " + ilamAciklama.ESAS_NO + " Karar Tarihi: " + ilamAciklama.KARAR_TARIHI), parentNode, ilam);
                    break;
            }
            return result;
        }

        private AV001_TDIE_BIL_PROJE projeGetir(TreeListNode node, bool deep)
        {
            object result = null;
            if (node != null)
                if (node.Tag is AV001_TDIE_BIL_PROJE)
                {
                    result = node.Tag;
                }
                else if (node.ParentNode != null && node.ParentNode.Tag is AV001_TDIE_BIL_PROJE)
                {
                    result = node.ParentNode.Tag;
                }
                else if (node.ParentNode != null && node.ParentNode.ParentNode != null &&
                         node.ParentNode.ParentNode.Tag is AV001_TDIE_BIL_PROJE)
                {
                    result = node.ParentNode.ParentNode.Tag;
                }
            if (result != null)
            {
                return (AV001_TDIE_BIL_PROJE)result;
            }
            return null;
        }

        private AV001_TDIE_BIL_PROJE projeGetir(TreeListNode node)
        {
            if (node.ParentNode != null && node.ParentNode.ParentNode != null &&
                node.ParentNode.ParentNode.Tag is AV001_TDIE_BIL_PROJE)
                return (AV001_TDIE_BIL_PROJE)node.ParentNode.ParentNode.Tag;
            return null;
        }

        private void projeleriEkle(AV001_TDIE_BIL_PROJE proje, TreeListNode tn)
        {
            //AV001_TDIE_BIL_PROJE prj = proje;
            treeKrediHesapBilgileri.Enabled = false;

            foreach (AV001_TDIE_BIL_PROJE prj in proje.AV001_TDIE_BIL_PROJECollection)
            {
                var projeChildCounts = BelgeUtil.Inits.context.ProjeChildCount(prj.ID).Single();
                TreeListNode nd2 = nodeEkle(dataRowYap(prj.ADI, prj.ACIKLAMA), tn, prj, 0, treeKrediHesapBilgileri);

                nodeEkle(dataRowYap("Alacaklar", "Takip Bekliyor"), nd2, typeof(AV001_TI_BIL_ALACAK_NEDEN), 2,
                         treeKrediHesapBilgileri, projeChildCounts.ALACAK_NEDEN_COUNT > 0);

                TreeListNode nd3 = nodeEkle(dataRowYap("Alacaklar", "Takibde"), nd2,
                                            typeof(AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI), 2,
                                            treeKrediHesapBilgileri,
                                            projeChildCounts.ALACAK_NEDEN_TAKIPLI_COUNT > 0);

                TreeListNode nd4 = nodeEkle(dataRowYap("Teminatlar", "Takip Bekliyor"), nd2, typeof(TDI_BIL_BORCLU_MAL),
                                            3, treeKrediHesapBilgileri,
                                            projeChildCounts.BORCLU_MAL_COUNT > 0);

                nodeEkle(dataRowYap("Teminatlar", "Takip Bekliyor"), nd2, typeof(AV001_TDIE_BIL_PROJE_TEMINAT_TAKIPLI),
                         3, treeKrediHesapBilgileri, projeChildCounts.TEMINAT_TAKIPLI_COUNT > 0);

                nodeEkle(dataRowYap("Teminatlar", "Kıymetli Evrak"), nd2, typeof(AV001_TDI_BIL_KIYMETLI_EVRAK), 3,
                         treeKrediHesapBilgileri, projeChildCounts.KIYMETLI_EVRAK_COUNT > 0);
                nodeEkle(dataRowYap("Soruşturma Dosyaları", ""), nd2, typeof(AV001_TD_BIL_HAZIRLIK), 2,
                         treeKrediHesapBilgileri, projeChildCounts.HAZIRLIK_COUNT > 0);
                nodeEkle(dataRowYap("Dava Dosyaları", ""), nd2, typeof(AV001_TD_BIL_FOY), 3, treeKrediHesapBilgileri,
                         projeChildCounts.DAVA_FOY_COUNT > 0);
                nodeEkle(dataRowYap("İcra Dosyaları", ""), nd2, typeof(AV001_TI_BIL_FOY), 1, treeKrediHesapBilgileri,
                         projeChildCounts.ICRA_FOY_COUNT > 0);
                nodeEkle(dataRowYap("Rücu Dosyaları", ""), nd2, typeof(AV001_TDI_BIL_RUCU), 4, treeKrediHesapBilgileri,
                         projeChildCounts.RUCU_COUNT > 0);
                nodeEkle(dataRowYap("Sözleşmeler", ""), nd2, typeof(AV001_TDI_BIL_SOZLESME), 5, treeKrediHesapBilgileri,
                         projeChildCounts.SOZLESME_COUNT > 0);
                nodeEkle(dataRowYap("Ödemeler", ""), nd2, typeof(AV001_TI_BIL_BORCLU_ODEME), 3, treeKrediHesapBilgileri,
                         projeChildCounts.BORCLU_ODEME_COUNT > 0);
                nodeEkle(dataRowYap("İhtiyati Haciz", ""), nd2, typeof(AV001_TI_BIL_IHTIYATI_HACIZ), 3, treeKrediHesapBilgileri,
                         projeChildCounts.IHTIYATI_HACIZ_COUNT > 0);
                nodeEkle(dataRowYap("İhtiyati Haciz", "Takipli"), nd2,
                         typeof(AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI), 3, treeKrediHesapBilgileri,
                         projeChildCounts.IHTIYATI_HACIZ_TAKIPLI_COUNT > 0);
                nodeEkle(dataRowYap("İhtiyati Tedbir", ""), nd2, typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR), 3, treeKrediHesapBilgileri,
                         projeChildCounts.IHTIYATI_TEDBIR_COUNT > 0);
                nodeEkle(dataRowYap("İhtiyati Tedbir", ""), nd2, typeof(AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI),
                         3, treeKrediHesapBilgileri,
                         projeChildCounts.IHTIYATI_TEDBIR_TAKIPLI_COUNT > 0);
                nodeEkle(dataRowYap("Masraflar", ""), nd2, typeof(AV001_TDI_BIL_MASRAF_AVANS), 3,
                         treeKrediHesapBilgileri, projeChildCounts.MASRAF_AVANS_COUNT > 0);
                nodeEkle(dataRowYap("Ihtarname", ""), nd2, typeof(AV001_TDI_BIL_TEBLIGAT), 3, treeKrediHesapBilgileri,
                         projeChildCounts.IHTARNAME_COUNT > 0);
                nodeEkle(dataRowYap("İlam Bilgileri", ""), nd2, typeof(AV001_TDIE_BIL_PROJE_ILAM_BILGILERI), 3,
                         treeKrediHesapBilgileri, projeChildCounts.ILAM_BILGILERI_COUNT > 0);
                projeleriEkle(prj, nd2);
            }
            treeKrediHesapBilgileri.Enabled = true;
        }

        private TreeListNode SozlesmeDetaylari(AV001_TDI_BIL_SOZLESME sozlesme, TreeListNode node)
        {
            TreeListNode ndD = null;

            var sozlesmeGayrimenkulList = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetBySOZLESME_IDFromNN_SOZLESME_GAYRIMENKUL(sozlesme.ID);
            if (sozlesmeGayrimenkulList.Count > 0)
            {
                sozlesmeGayrimenkulList.ForEach(item =>
                    {
                        ndD = nodeEkle(item, node, treeKrediHesapBilgileri);
                    });
                return ndD;
            }
            else
            {
                var sozlesmeGemiUcakAracList = DataRepository.AV001_TDI_BIL_GEMI_UCAK_ARACProvider.GetBySOZLESME_IDFromNN_SOZLESME_GEMI_UCAK_ARAC(sozlesme.ID);
                if (sozlesmeGemiUcakAracList.Count > 0)
                {
                    sozlesmeGemiUcakAracList.ForEach(item =>
                        {
                            ndD = nodeEkle(item, node, treeKrediHesapBilgileri);
                        });
                    return ndD;
                }
            }
            return ndD;
        }

        #region DosyaBilleri

        private string GetFoyBilgileri(int foyId)
        {
            if (foyId == 0) return string.Empty;
            AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA aciklama = null;
            FoyAciklamaGetir(foyId, out aciklama);
            var sonuc = string.Format("{0} {1} {2} {3}"
                                      , aciklama.ADLIYE
                                      , aciklama.NO
                                      , aciklama.GOREV
                                      , aciklama.ESAS_NO);

            return sonuc;
        }

        private string GetKiymetliEvrakBilgileri(int kEvrakId)
        {
            TList<NN_ICRA_KIYMETLI_EVRAK> icraList = DataRepository.NN_ICRA_KIYMETLI_EVRAKProvider.GetByKIYMETLI_EVRAK_ID(kEvrakId);
            if (icraList.Count == 0) return string.Empty;
            return GetFoyBilgileri(icraList[0].ICRA_FOY_ID);
        }

        #endregion DosyaBilleri

        #region AçıklamaGetirler

        public string FoyAciklamaGetir(AV001_TI_BIL_FOY mFoy, out AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA icraAciklama)
        {
            return FoyAciklamaGetir(mFoy.ID, out icraAciklama);
        }

        public string FoyAciklamaGetir(int icraFoyId, out AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA icraAciklama)
        {
            AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_ICRA_FOY_ACIKLAMAs.Single(item => item.ID == icraFoyId);
            icraAciklama = aciklama;
            return IcraAciklama(aciklama);
        }

        public string FoyAciklamaGetir(AV001_TD_BIL_FOY mFoy, out AvukatProLib.Arama.per_DAVA_FOY_ACIKLAMA foyAciklama)
        {
            return FoyAciklamaGetir(mFoy.ID, out foyAciklama);
        }

        public string FoyAciklamaGetir(int davaFoyId, out AvukatProLib.Arama.per_DAVA_FOY_ACIKLAMA foyAciklama)
        {
            AvukatProLib.Arama.per_DAVA_FOY_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_DAVA_FOY_ACIKLAMAs.Single(item => item.ID == davaFoyId);
            foyAciklama = aciklama;
            return DavaAciklama(aciklama);
        }

        private static string DavaAciklama(AvukatProLib.Arama.per_DAVA_FOY_ACIKLAMA aciklama)
        {
            return String.Format("{6}-{5} - {0} {1} {2} - T: {3:d} - {4} Esas",
                                 aciklama.ADLIYE ?? "",
                                 aciklama.NO ?? "",
                                 aciklama.GOREV ?? "",
                                 aciklama.DAVA_TARIHI, aciklama.ESAS_NO,
                                 aciklama.BIRIM ?? "",
                                 aciklama.DAVA_TALEP);
        }

        private static string IcraAciklama(AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA aciklama)
        {
            return String.Format("{5} - {0} {1} {2} - T: {3:d} - {4} Esas",
                                 aciklama.ADLIYE ?? "",
                                 aciklama.NO ?? "",
                                 aciklama.GOREV ?? "",
                                 aciklama.TAKIP_TARIHI, aciklama.ESAS_NO,
                                 !String.IsNullOrEmpty(aciklama.FORM_ORNEK_NO)
                                     ? String.Format("{0} ({1})", aciklama.FORM_ORNEK_NO, aciklama.YENI_FORM_ORNEK_NO) : "");
        }

        private string BorcluMalAciklamaGetir(TDI_BIL_BORCLU_MAL borcluMal, out AvukatProLib.Arama.per_BORCLU_MAL_ACIKLAMA bMalAciklama)
        {
            AvukatProLib.Arama.per_BORCLU_MAL_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_BORCLU_MAL_ACIKLAMAs.Single(item => item.ID == borcluMal.ID);
            bMalAciklama = aciklama;
            return string.Format("{0} - {1} - {2} - {3:###,###,###,##0.00} {4} ",
                                 aciklama.KAYIT_TARIHI.ToShortDateString(),
                                 aciklama.KATEGORI,
                                 aciklama.CINS, aciklama.HACIZLI_MAL_SATIR_TOPLAM_MIKTAR,
                                 aciklama.DOVIZ_KODU);
        }

        private string HazirlikAciklamaGetir(AV001_TD_BIL_HAZIRLIK hzr, out AvukatProLib.Arama.per_HAZIRLIK_ACIKLAMA hazirlikAciklama)
        {
            AvukatProLib.Arama.per_HAZIRLIK_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_HAZIRLIK_ACIKLAMAs.Single(item => item.ID == hzr.ID);
            hazirlikAciklama = aciklama;
            return String.Format("{0} {1} - T: {2:d} - {3} Esas",
                                 aciklama.ADLIYE ?? "",
                                 aciklama.GOREV ?? "",
                                 aciklama.HAZIRLIK_TARIH, aciklama.HAZIRLIK_ESAS_NO);
        }

        private string IhtiyatiHacizAciklamaGetir(AV001_TI_BIL_IHTIYATI_HACIZ hzr, out AvukatProLib.Arama.per_IHTIYATI_HACIZ_ACIKLAMA ihAciklama)
        {
            AvukatProLib.Arama.per_IHTIYATI_HACIZ_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_IHTIYATI_HACIZ_ACIKLAMAs.SingleOrDefault(item => item.ID == hzr.ID);
            ihAciklama = aciklama;
            AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA foyAciklama = null;
            if (hzr.ICRA_FOY_ID.HasValue) foyAciklama = BelgeUtil.Inits.context.per_ICRA_FOY_ACIKLAMAs.Single(item => item.ID == hzr.ICRA_FOY_ID.Value);
            string icraText = String.Empty;
            if (foyAciklama != null)
            {
                icraText = string.Format("{0} {1} {2} {3}", foyAciklama.ADLIYE, foyAciklama.NO, foyAciklama.GOREV, foyAciklama.ESAS_NO);
            }
            return String.Format("{0} {1} {2} {4} Esas - {3} Tarih ve {5} Nolu karar {6}",
                                 aciklama.ADLIYE ?? "",
                                 aciklama.NO ?? "",
                                 aciklama.GOREV ?? "",
                                 aciklama.KARAR_TARIHI.HasValue ? aciklama.KARAR_TARIHI.Value.ToShortDateString() : "[TarihYok]",
                                 aciklama.ESAS_NO,
                                 String.IsNullOrEmpty(aciklama.KARAR_NO) ? "[NoYok]" : aciklama.KARAR_NO,
                                 icraText);
        }

        private string IhtiyatiTedbirAciklamaGetir(AV001_TDI_BIL_IHTIYATI_TEDBIR hzr, out AvukatProLib.Arama.per_IHTIYATI_TEDBIR_ACIKLAMA itAciklama)
        {
            AvukatProLib.Arama.per_IHTIYATI_TEDBIR_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_IHTIYATI_TEDBIR_ACIKLAMAs.Single(item => item.ID == hzr.ID);
            itAciklama = aciklama;
            AvukatProLib.Arama.per_ICRA_FOY_ACIKLAMA foyAciklama = null;
            if (hzr.ICRA_FOY_ID.HasValue) foyAciklama = BelgeUtil.Inits.context.per_ICRA_FOY_ACIKLAMAs.Single(item => item.ID == hzr.ICRA_FOY_ID.Value);
            string icraText = String.Empty;
            if (foyAciklama != null)
            {
                icraText = string.Format("{0} {1} {2} {3}", foyAciklama.ADLIYE, foyAciklama.NO, foyAciklama.GOREV, foyAciklama.ESAS_NO);
            }
            return String.Format("{0} {1} {2} {4} Esas - {3} Tarih ve {5} Nolu karar {6}",
                                 aciklama.ADLIYE ?? "",
                                 aciklama.NO ?? "",
                                 aciklama.GOREV ?? "",
                                 aciklama.KARAR_TARIHI.HasValue ? aciklama.KARAR_TARIHI.Value.ToShortDateString() : "[TarihYok]",
                                 aciklama.ESAS_NO,
                                 String.IsNullOrEmpty(aciklama.KARAR_NO) ? "[NoYok]" : aciklama.KARAR_NO,
                                 icraText);
        }

        private string KiymetliEvrakAciklamaGetir(AV001_TDI_BIL_KIYMETLI_EVRAK kEvrak, out AvukatProLib.Arama.per_KIYMETLI_EVRAK_ACIKLAMA kEvrakaciklama)
        {
            return KiymetliEvrakAciklamaGetir(kEvrak.ID, out kEvrakaciklama);
        }

        private string KiymetliEvrakAciklamaGetir(int kEvrakId, out AvukatProLib.Arama.per_KIYMETLI_EVRAK_ACIKLAMA kEvrakaciklama)
        {
            List<AvukatProLib.Arama.per_KIYMETLI_EVRAK_ACIKLAMA> aciklamaList = BelgeUtil.Inits.context.per_KIYMETLI_EVRAK_ACIKLAMAs.Where(item => item.ID == kEvrakId).ToList();
            kEvrakaciklama = aciklamaList[0];
            string kesideciIsimler = string.Empty;
            List<int> cariIdList = new List<int>();
            aciklamaList.ForEach(item =>
            {
                if (item.TARAF_CARI_ID.HasValue && (item.TARAF_TIP_ID == 2 || item.TARAF_TIP_ID == 3)) cariIdList.Add(item.TARAF_CARI_ID.Value);
            });
            if (cariIdList.Count > 0)
            {
                foreach (var item in BelgeUtil.Inits.CariGetirByIdList(cariIdList))
                {
                    kesideciIsimler += item.AD + ",";
                }
            }

            AdimAdimDavaKaydi.Util.Uyap.UyapGenerator.SayiOkuma so = new AdimAdimDavaKaydi.Util.Uyap.UyapGenerator.SayiOkuma();

            string tarihYazisi = string.Empty;

            if (aciklamaList[0].TUR == "ÇEK") tarihYazisi = "ibraz tarihli";
            else if (aciklamaList[0].TUR == "BONO") tarihYazisi = "vade tarihli";

            return String.Format("{0} {1} {2} {3} {4} {5}",
                                 aciklamaList[0].EVRAK_VADE_TARIHI.HasValue
                                     ? aciklamaList[0].EVRAK_VADE_TARIHI.Value.ToShortDateString()
                                     : "[TarihYok]", tarihYazisi,
                                 kesideciIsimler, GetKiymetliEvrakBilgileri(kEvrakId), so.ParaFormatla(aciklamaList[0].TUTAR), aciklamaList[0].DOVIZ_KODU
                                 );
        }

        private string MasrafAvansAciklamaGetir(AV001_TDI_BIL_MASRAF_AVANS mAvans, out AvukatProLib.Arama.per_MASRAF_AVANS_ACIKLAMA mAciklama)
        {
            List<AvukatProLib.Arama.per_MASRAF_AVANS_ACIKLAMA> aciklamaList = BelgeUtil.Inits.context.per_MASRAF_AVANS_ACIKLAMAs.Where(item => item.ID == mAvans.ID).ToList();
            mAciklama = aciklamaList[0];
            ParaVeDovizId pId = new ParaVeDovizId();
            aciklamaList.ForEach(
                delegate(AvukatProLib.Arama.per_MASRAF_AVANS_ACIKLAMA dty) { pId = ParaVeDovizId.Topla(pId, new ParaVeDovizId(dty.TOPLAM_TUTAR, dty.TOPLAM_TUTAR_DOVIZ_ID)); });
            return String.Format("{0:###,###,##0.00} {1} tutarlı {2} tarihli {3} kalemi", pId.Para, pId.DovizKodu,
                                 aciklamaList[0].KAYIT_TARIHI.ToShortDateString(),
                                 aciklamaList[0].MASRAF_AVANS_TIP == 1 ? "Masraf" : "Avans");
        }

        private string SozlesmeAciklamaGetir(AV001_TDI_BIL_SOZLESME sozlesme, out AvukatProLib.Arama.per_SOZLESME_ACIKLAMA sozlesmeAciklama)
        {
            AvukatProLib.Arama.per_SOZLESME_ACIKLAMA aciklama = BelgeUtil.Inits.context.per_SOZLESME_ACIKLAMAs.Single(item => item.ID == sozlesme.ID);
            sozlesmeAciklama = aciklama;
            return String.Format("Sz.T:{0:d} - Tutar:{1:###,###,###,##0.00} {2} {3}",
                                                             aciklama.IMZA_TARIHI, aciklama.BEDELI,
                                                             (DovizTip)(aciklama.BEDELI_DOVIZ_ID ?? 1)
                                                             , GetFoyBilgileri(aciklama.ICRA_FOY_ID ?? 0));
        }

        #endregion AçıklamaGetirler

        #endregion METHODS

        #region TREE LİST RİGHT CLİCK AND EVENTS

        #region EVENTS


        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as frmAlacakGirisi) != null)
                (sender as frmAlacakGirisi).Close();
            projeGuncelle(null);
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmIcraOdemeBilgileri frm = sender as frmIcraOdemeBilgileri;
            if (frm != null && frm.Tag != null && frm.Tag is AV001_TDIE_BIL_PROJE)
            {
                AV001_TDIE_BIL_PROJE prj = frm.Tag as AV001_TDIE_BIL_PROJE;

                //prj.Tag = DateTime.Now; // artık kaydedebilsin
                frm.MyDataSource.AddingNew -= OdemeAddingNew;
                projeGuncelle(null);
            }
        }

        private void OdemeAddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_BORCLU_ODEME odm = e.NewObject as AV001_TI_BIL_BORCLU_ODEME;
            if (odm == null)
                odm = new AV001_TI_BIL_BORCLU_ODEME();
            AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME bOdeme =
                odm.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMECollection.AddNew();
            bOdeme.PROJE_ID = AktifProjeyiGetir(false).ID;

            AV001_TDIE_BIL_PROJE MyProje = AktifProjeyiGetir(false);
            List<int> cariIdList = new List<int>();
            TList<AV001_TDIE_BIL_PROJE_TARAF> tarafList = DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.GetByPROJE_ID(MyProje.ID);
            tarafList.ForEach(item => cariIdList.Add(item.CARI_ID));
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> cariList = BelgeUtil.Inits.CariGetirByIdList(cariIdList);
            foreach (var item in cariList)
            {
                if (item.MUVEKKIL_MI)
                    odm.ODENEN_CARI_ID = item.ID;

                //TODO: ŞİMDİLİK YAPILDI PROSEDÜR YAZILIP BUNA  MÜVEKKİLMİSİ FALSE OLANLAR GETİRİLP ONLARIN COUNTUNA BAKILIP O ATILACAK
                else if (tarafList.Count < 3)
                {
                    odm.BORCLU_ADINA_ODEYEN_CARI_ID = odm.ODEYEN_CARI_ID = item.ID;
                }
            }

            odm.ODEME_YER_ID = 1;
            odm.ODEME_TIP_ID = 1;
            odm.ICRADAN_CEKILME_TARIHI = null;

            odm.ColumnChanged += odm_ColumnChanged;
            e.NewObject = odm;
        }

        private void odm_ColumnChanged(object sender, AV001_TI_BIL_BORCLU_ODEMEEventArgs e)
        {
            var odeme = sender as AV001_TI_BIL_BORCLU_ODEME;

            if (e.Column == AV001_TI_BIL_BORCLU_ODEMEColumn.ODEYEN_CARI_ID)
            {
                odeme.BORCLU_ADINA_ODENEN_CARI_ID = (int)e.Value;
            }
            else if (e.Column == AV001_TI_BIL_BORCLU_ODEMEColumn.ALACAK_NEDEN_ID)
            {
                if (e.Value == null) return;

                var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID((int)e.Value);
                if (HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(alacak))//Gayrinakit
                {
                    var test = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == alacak.ID && vi.TAZMIN_TARIHI.HasValue).ToList();

                    //int alacakNedenID = 0;
                    if (test.Count == 0)
                    {
                        var takipliAlacak = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.GetByALACAK_NEDEN_ID(alacak.ID).FirstOrDefault();//GetByALACAK_NEDEN_ID procedure sonucunda count her zaman 1'dir.

                        if (takipliAlacak == null || !takipliAlacak.KAYNAK_ALACAK_NEDEN_ID.HasValue)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("GayriNakit alacağın tazmin edilmiş kısmı olmadığından ödeme kaydı yapılamıyor.\r\nGayrinakit Alacağa depo kaydı girişi yapabilirsiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //alacakNedenID = takipliAlacak.ALACAK_NEDEN_ID;
                        var kayitList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == takipliAlacak.KAYNAK_ALACAK_NEDEN_ID.Value && vi.TAZMIN_TARIHI.HasValue).ToList();
                        if (kayitList != null && kayitList.Count > 0) test.AddRange(kayitList);
                    }

                    if (test.Count > 0)
                    {
                        //depo - tazmin(ödeme) ekranı
                        var toplamTazmin = test.Sum(vi => vi.TAZMIN_TUTARI.Value);
                        if (toplamTazmin >= alacak.TUTARI)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Gayrinakit Alacağın tamamı tazmin \r\nedildiğinden ödeme girişi yapabilirsiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        frmGayrinakitTarihler frm = new frmGayrinakitTarihler();
                        frm.Show(odeme, AktifProjeyiGetir(false).ID, alacak.REFERANS_ALACAK_NEDEN_ID.Value, TarihTip.DepoOdeme);
                    }
                    else
                    {
                        //ödeme yok, depo
                        AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY gayriDetay = new AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY();

                        gayriDetay.ALACAK_NEDEN_ID = alacak.ID;
                        gayriDetay.DEPO_TARIHI = odeme.ODEME_TARIHI;
                        gayriDetay.DEPO_TUTARI = odeme.ODEME_MIKTAR;
                        gayriDetay.DEPO_TUTARI_DOVIZ_ID = odeme.ODEME_MIKTAR_DOVIZ_ID;
                        gayriDetay.DEPO_EDEN = odeme.BORCLU_ADINA_ODEYEN_CARI_ID;

                        BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.InsertOnSubmit(gayriDetay);

                        try
                        {
                            BelgeUtil.Inits.context.SubmitChanges();
                            DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedildi.\r\nGayriNakit alacağın tanzim edilmiş kısmı olmadığından ödeme kaydı yapılamıyor.\r\nGayrinakit Alacağa depo kaydı yaptınız.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            BelgeUtil.ErrorHandler.Catch(this, ex);
                            DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedilemedi.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        private void treeKrediHesapBilgileri_MouseDown(object sender, MouseEventArgs e)
        {
            if (!MousePosition.IsEmpty && e.Clicks == 2)
            {
                TreeListHitInfo currLvItem = this.treeKrediHesapBilgileri.CalcHitInfo(e.Location);
                if (currLvItem != null && currLvItem.Node != null)
                {
                    EntityBase entityBase = currLvItem.Node.Tag as EntityBase;
                    if (entityBase is AV001_TI_BIL_FOY)
                    {
                        DialogResult dr =
                            MessageBox.Show("Dosyayı Aç",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            OnKayit k = new OnKayit(frm_IcraDosyasiKaydedildi);
                            AV001_TI_BIL_FOY foy = (AV001_TI_BIL_FOY)entityBase;
                            _frmIcraTakip frm = new _frmIcraTakip(k);
                            frm.MyProje = AktifProjeyiGetir(true);
                            frm.IcraFoyKaydedildi += frm_IcraFoyKaydedildi;
                            frm.Show(foy.ID);
                        }
                    }
                    else if (entityBase is AV001_TD_BIL_FOY)
                    {
                        DialogResult dr =
                            MessageBox.Show("Dosyayı Aç",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            AV001_TD_BIL_FOY foy = (AV001_TD_BIL_FOY)entityBase;
                            frmDavaTakip frm = new frmDavaTakip();
                            frm.Show(foy.ID);
                        }
                    }
                    else if (entityBase is AV001_TDI_BIL_SOZLESME)
                    {
                        DialogResult dr =
                            MessageBox.Show("Dosyayı Aç",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            if (entityBase != null)
                            {
                                AV001_TDI_BIL_SOZLESME sozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(((AV001_TDI_BIL_SOZLESME)entityBase).ID);
                                frmSozlesmeKayitLayout frm = new frmSozlesmeKayitLayout();
                                TList<AV001_TDI_BIL_SOZLESME> list = new TList<AV001_TDI_BIL_SOZLESME>();
                                frm.SozlesmeKaydedildi += frm_SozlesmeKaydedildi;
                                frm.EditMode = true;
                                frm.MyProje = AktifProjeyiGetir(true);
                                list.Add(sozlesme);
                                frm.MySozlesme = list;
                                frm.Show(list);
                            }
                        }
                    }
                    else if (entityBase is AV001_TD_BIL_HAZIRLIK)
                    {
                        DialogResult dr =
                            MessageBox.Show("Dosyayı Aç",
                                            "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            AV001_TD_BIL_HAZIRLIK sorusturma = (AV001_TD_BIL_HAZIRLIK)entityBase;
                            Sorusturma.Forms.rFrmSorusturmaTakip frm = new Sorusturma.Forms.rFrmSorusturmaTakip();
                            frm.Show(sorusturma.ID);
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                TreeListHitInfo currLvItem = this.treeKrediHesapBilgileri.CalcHitInfo(e.Location);
                _UzerineTiklananNode = null;
                if (currLvItem != null && currLvItem.Node != null)
                {
                    _UzerineTiklananNode = currLvItem.Node;
                }
            }
        }

        #region KAYDEDİLDİ EVENT'LARI

        private void frm_DavaFoyKaydedildi(object sender, DavaFoyKaydedildiEventArgs e)
        {
            var proje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            if (proje.AV001_TDIE_BIL_PROJE_DAVA_FOYCollection.Exists(
                delegate(AV001_TDIE_BIL_PROJE_DAVA_FOY dava) { return dava.DAVA_FOY_ID == e.DavaFoy.ID; })) return;
            AV001_TDIE_BIL_PROJE_DAVA_FOY prjDavaFoy = new AV001_TDIE_BIL_PROJE_DAVA_FOY();
            prjDavaFoy.PROJE_ID = proje.ID;
            prjDavaFoy.DAVA_FOY_ID = e.DavaFoy.ID;
            DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.Save(prjDavaFoy);
            if ((sender as frmDavaDosyaKayitForm) != null)
                (sender as frmDavaDosyaKayitForm).Close();
            projeGuncelle(null);
        }

        private void frm_IcraDosyasiKaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmAlacakNedendenFoyOlustur) != null)
                (sender as frmAlacakNedendenFoyOlustur).Close();
            projeGuncelle(null);
        }

        private void frm_IcraFoyKaydedildi(object sender, IcraFoyKaydedildiEventArgs e)
        {
            var proje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_FOY>),
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>),
                                                                 typeof(
                                                                     TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI>));

            if (e.IcraFoy != null)
            {
                if (
                    proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Exists(
                        delegate(AV001_TDIE_BIL_PROJE_ICRA_FOY icra) { return icra.ICRA_FOY_ID == e.IcraFoy.ID; }))
                    return;
                AV001_TDIE_BIL_PROJE_ICRA_FOY proFoy = new AV001_TDIE_BIL_PROJE_ICRA_FOY();
                proFoy.ICRA_FOY_ID = e.IcraFoy.ID;
                proFoy.PROJE_ID = proje.ID;
                DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.Save(proFoy);
                proje.AV001_TDIE_BIL_PROJE_ICRA_FOYCollection.Add(proFoy);
                foreach (AV001_TI_BIL_ALACAK_NEDEN aneden in e.IcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    foreach (
                        AV001_TDI_BIL_KIYMETLI_EVRAK kiymetli in
                            aneden.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK)
                    {
                        if (
                            proje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKCollection.Exists(
                                delegate(AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK kiymet) { return kiymet.KIYMETLI_EVRAK_ID == kiymetli.ID; }))
                        {
                            DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.Delete(kiymetli.ID, proje.ID);
                            if (
                                proje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Exists(
                                    delegate(AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI kiymet) { return kiymet.KIYMETLI_EVRAK_ID == kiymetli.ID; })) continue;
                            AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI kTakipli =
                                new AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI();
                            kTakipli.KIYMETLI_EVRAK_ID = kiymetli.ID;
                            kTakipli.PROJE_ID = proje.ID;
                            DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.Save(kTakipli);
                            proje.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLICollection.Add(kTakipli);
                        }
                    }
                }
            }

            if ((sender as frmIcraDosyaKayit) != null)
                (sender as frmIcraDosyaKayit).Close();

            projeGuncelle(null);
        }

        private void frm_SorusturmaKaydedildi(object sender, SorusturmaFoyKaydedildiEventArgs e)
        {
            #region <MB-20100525>

            //Klasörden kaydedilen soruşturmanın proje ile ilişkili tablosuna kaydı sağlanıyor.

            var proje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            if (proje.AV001_TDIE_BIL_PROJE_HAZIRLIKCollection.Exists(
                delegate(AV001_TDIE_BIL_PROJE_HAZIRLIK hazirlik) { return hazirlik.HAZIRLIK_ID == e.SorusturmaFoy.ID; }))
                return;
            AV001_TDIE_BIL_PROJE_HAZIRLIK prjHazirlikFoy = new AV001_TDIE_BIL_PROJE_HAZIRLIK();
            prjHazirlikFoy.PROJE_ID = proje.ID;
            prjHazirlikFoy.HAZIRLIK_ID = e.SorusturmaFoy.ID;
            DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.Save(prjHazirlikFoy);

            if ((sender as rfrmSorusturmaGiris) != null)
                (sender as rfrmSorusturmaGiris).Close();
            projeGuncelle(null);

            #endregion <MB-20100525>
        }

        private void frm_SozlesmeKaydedildi(object sender, SozlesmeFoyKaydedildiEventArgs e)
        {
            var proje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_PROJE_SOZLESME>));
            if (proje.AV001_TDIE_BIL_PROJE_SOZLESMECollection.Exists(delegate(AV001_TDIE_BIL_PROJE_SOZLESME sozlesme) { return sozlesme.SOZLESME_ID == e.SozlesmeFoy.ID; }))
            {
                projeGuncelle(null);
                return;
            }
            foreach (var item in e.SozlesmeFoy.AV001_TDI_BIL_SOZLESME_TARAFCollection)
            {
                if (proje.AV001_TDIE_BIL_PROJE_TARAFCollection.Count == 0)
                    DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepLoad(proje, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_TARAF>));
                if (
                    proje.AV001_TDIE_BIL_PROJE_TARAFCollection.Exists(
                        delegate(AV001_TDIE_BIL_PROJE_TARAF soztrf) { return soztrf.CARI_ID == item.CARI_ID; }))
                    continue;
                AV001_TDIE_BIL_PROJE_TARAF trf = new AV001_TDIE_BIL_PROJE_TARAF();
                trf.CARI_ID = item.CARI_ID.Value;
                trf.PROJE_ID = proje.ID;
                DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.Save(trf);
            }
            if (e.SozlesmeFoy.TIP_ID != (int)SozlesmeAnaTip.Resmi_Senet)
            {
                AV001_TDIE_BIL_PROJE_SOZLESME nn = new AV001_TDIE_BIL_PROJE_SOZLESME();
                nn.PROJE_ID = proje.ID;
                nn.SOZLESME_ID = e.SozlesmeFoy.ID;
                DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.Save(nn);
            }
            else
            {
                if (DataRepository.AV001_TDIE_BIL_PROJE_TEMINATProvider.GetByPROJE_IDSOZLESME_ID(proje.ID, e.SozlesmeFoy.ID) == null)
                {
                    AV001_TDIE_BIL_PROJE_TEMINAT tmt = new AV001_TDIE_BIL_PROJE_TEMINAT();
                    tmt.PROJE_ID = proje.ID;
                    tmt.SOZLESME_ID = e.SozlesmeFoy.ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_TEMINATProvider.Save(tmt);
                }
            }
            if ((sender as frmSozlesmeKayit) != null)
                (sender as frmSozlesmeKayit).Close();
            projeGuncelle(null);
        }

        private void frm2Evrak_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmKiymetliEvrakKayit) != null)
                (sender as frmKiymetliEvrakKayit).Close();
            projeGuncelle(null);
        }

        private void frmavans_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmMasrafAvansKayitHizli) != null)
                (sender as frmMasrafAvansKayitHizli).Close();
            projeGuncelle(null);
        }

        private void frmHaciz_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as rFrmIcraIhtiyatiHaciz) != null)
                (sender as rFrmIcraIhtiyatiHaciz).Close();
            projeGuncelle(null);
        }

        private void frmmahkeme_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmIlamMahkemesiTarafli) != null)
                (sender as frmIlamMahkemesiTarafli).Close();
            projeGuncelle(null);
        }

        private void frmMal_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmBorcluMalKaydetVGrid) != null)
                (sender as frmBorcluMalKaydetVGrid).Close();
            projeGuncelle(null);
        }

        private void frmTedbir_Kaydedildi(object sender, EventArgs e)
        {
            if ((sender as frmDavaIcraIhtiyatiTedbir) != null)
                (sender as frmDavaIcraIhtiyatiTedbir).Close();
            projeGuncelle(null);
        }

        #endregion KAYDEDİLDİ EVENT'LARI

        #endregion EVENTS

        #region RİGHT CLİCK

        private TreeListNode _UzerineTiklananNode;

        private TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

        private TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> AlacakNedenTarafList = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

        private TList<AV001_TI_BIL_IHTIYATI_HACIZ> IhtiyatiHacizList = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();

        private TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> IhtiyatiTedbirList = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();

        private TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI> TakipliAlacakList = new TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI>();

        private TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI> TakipliIhtiyatiHacizList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLI>();

        private TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI> TakipliIhtiyatiTedbirList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLI>();

        private TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI> TakipliMunzamList = new TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLI>();

        private TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ> TakipsizIhtiyatiHacizList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ>();

        private TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR> TakipsizIhtiyatiTedbirList = new TList<AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR>();

        private TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK> TakipsizMunzamList = new TList<AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK>();

        private void ağacınTümünüAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeKrediHesapBilgileri.ExpandAll();
        }

        private void ağacıTamamenKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeKrediHesapBilgileri.CollapseAll();
        }

        private void alacaklardanİcraDosyasıOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlacakNedendenFoyOlustur frm = new frmAlacakNedendenFoyOlustur();
            frm.MyProje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            frm.IcraDosyasiKaydedildi += frm_IcraDosyasiKaydedildi;
            frm.Show();
        }

        private void aporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KlasorRapor();
        }

        //Ağaç üzerinde sağ tuşa basılınca ilgili işlemlerin sağ tuş menüsünde görünmesi sağlandı.
        private void cmsKrediBilgileri_Opening(object sender, CancelEventArgs e)
        {
            AV001_TDIE_BIL_PROJE prj = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            if (prj != null)
            {
                yeniToolStripMenuItem.Text = "Yeni (" + prj.ADI + " için)";
                yeniToolStripMenuItem.Enabled = true;

                #region <YY-20090704>

                if (_UzerineTiklananNode == null || _UzerineTiklananNode.Tag == null)
                    return;
                tsmiAlacak.Visible =
                    tsmiAlacakDuzenle.Visible =
                    tsmIhtiyatiHacizDuzenle.Visible =
                    tsmihtiyatiTedbirDuzenle.Visible =
                    ihtarnameGirişiToolStripMenuItem.Visible =
                    tsmkiymetliEvrakBilgileriDuzenle.Visible =
                    tsmiTeminat.Visible =
                    tsmiSozlesme.Visible =
                    tsmiTakipler.Visible =
                    tsmiDavaDosyasi.Visible =
                    tsmiSorusturma.Visible =
                    tsmiIhtiyatiHaciz.Visible =
                    ihtarnameDüzenleToolStripMenuItem.Visible =
                    tsmIlamBilgisiDuzenle.Visible =
                    tsmIlamGirisi.Visible =
                    tsmiIhtiyatiTedbir.Visible =
                    tsmiMasraf.Visible =
                    tsmiOdeme.Visible =
                    tsmiCizik.Visible =
                    tsmiCizik2.Visible =
                    tsmIhtiyatiHacizDilekcesi.Visible =
                    ödemeyiToolStripMenuItem.Visible =
                    masrafDüzenleToolStripMenuItem.Visible =
                    düzenleToolStripMenuItem.Visible =
                    tazminToolStripMenuItem.Visible =
                    iadeToolStripMenuItem.Visible =
                    depoToolStripMenuItem.Visible =
                    tsmiMalHakGirisi.Visible = false;
                if (_UzerineTiklananNode.Tag is AV001_TDIE_BIL_PROJE ||
                    _UzerineTiklananNode.Tag == typeof(AV001_TDIE_BIL_PROJE))
                {
                    tsmiAlacak.Visible =
                        tsmiTeminat.Visible =
                        tsmiSozlesme.Visible =
                        tsmiTakipler.Visible =
                        tsmiDavaDosyasi.Visible =
                        tsmiSorusturma.Visible =
                        tsmiIhtiyatiHaciz.Visible =
                        tsmIlamGirisi.Visible =
                        ihtarnameGirişiToolStripMenuItem.Visible =
                        tsmiIhtiyatiTedbir.Visible =
                        tsmiCizik.Visible =
                        tsmiCizik2.Visible =
                        tsmiMasraf.Visible =
                        tsmiOdeme.Visible =
                        tsmiMalHakGirisi.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TI_BIL_ALACAK_NEDEN ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TI_BIL_ALACAK_NEDEN))
                {
                    tsmiAlacak.Visible = true;
                    ihtarnameGirişiToolStripMenuItem.Visible = true;
                    tsmiTakipler.Visible = true;
                    tsmiAlacakDuzenle.Visible = true;
                    tazminToolStripMenuItem.Visible =
                        iadeToolStripMenuItem.Visible =
                        depoToolStripMenuItem.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TDI_BIL_SOZLESME ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TDI_BIL_SOZLESME))
                {
                    tsmiSozlesme.Visible = true;
                    tsmiTeminat.Visible = true;
                    düzenleToolStripMenuItem.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TD_BIL_FOY ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TD_BIL_FOY))
                {
                    tsmiDavaDosyasi.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TI_BIL_FOY ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TI_BIL_FOY))
                {
                    tsmiTakipler.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TD_BIL_HAZIRLIK ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TD_BIL_HAZIRLIK))
                {
                    tsmiSorusturma.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TDI_BIL_MASRAF_AVANS ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TDI_BIL_MASRAF_AVANS))
                {
                    tsmiMasraf.Visible = true;
                    masrafDüzenleToolStripMenuItem.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is TDI_BIL_BORCLU_MAL ||
                         _UzerineTiklananNode.Tag == typeof(TDI_BIL_BORCLU_MAL))
                {
                    tsmiMalHakGirisi.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TDI_BIL_IHTIYATI_TEDBIR ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR))
                {
                    tsmiIhtiyatiTedbir.Visible = true;
                    tsmihtiyatiTedbirDuzenle.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TI_BIL_IHTIYATI_HACIZ ||
                         _UzerineTiklananNode.Tag == typeof(AV001_TI_BIL_IHTIYATI_HACIZ))
                {
                    tsmiIhtiyatiHaciz.Visible = true;
                    tsmIhtiyatiHacizDuzenle.Visible = true;
                    tsmIhtiyatiHacizDilekcesi.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag is AV001_TI_BIL_BORCLU_ODEME ||
                         _UzerineTiklananNode.Tag ==
                         typeof(AV001_TI_BIL_BORCLU_ODEME))
                {
                    tsmiOdeme.Visible = true;
                    ödemeyiToolStripMenuItem.Visible = true;
                }
                else if (
                    _UzerineTiklananNode.Tag is
                    AV001_TDIE_BIL_PROJE_ILAM_BILGILERI ||
                    _UzerineTiklananNode.Tag ==
                    typeof(AV001_TDIE_BIL_PROJE_ILAM_BILGILERI))
                {
                    tsmIlamGirisi.Visible = true;
                    tsmIlamBilgisiDuzenle.Visible = true;
                }
                else if (
                    _UzerineTiklananNode.Tag is
                    AV001_TDIE_BIL_PROJE_IHTARNAME ||
                    _UzerineTiklananNode.Tag ==
                    typeof(AV001_TDIE_BIL_PROJE_IHTARNAME))
                {
                    ihtarnameGirişiToolStripMenuItem.Visible = true;
                    ihtarnameDüzenleToolStripMenuItem.Visible = true;

                    //ihtarnameGirişiToolStripMenuItem.Visible = true;
                }
                else if (_UzerineTiklananNode.Tag
                         is AV001_TDI_BIL_KIYMETLI_EVRAK ||
                         _UzerineTiklananNode.Tag ==
                         typeof(AV001_TDI_BIL_KIYMETLI_EVRAK))
                {
                    tsmkiymetliEvrakBilgileriDuzenle.Visible = true;
                }

                #endregion <YY-20090704>

                if (_UzerineTiklananNode.Tag is AV001_TDIE_BIL_PROJE)
                {
                    klasörüSilToolStripMenuItem.Enabled = false;
                }
                else
                {
                    klasörüSilToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                yeniToolStripMenuItem.Enabled = false;
            }

            treeKrediHesapBilgileri.FocusedNode = _UzerineTiklananNode;
        }

        private void exceleGönderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|Excel Dosyası";
            sfd.DefaultExt = "xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeKrediHesapBilgileri.ExportToXls(sfd.FileName);
            }
        }

        private void frmSil_FormClosed(object sender, FormClosedEventArgs e)
        {
            projeGuncelle(null);
        }

        private void frmTakipSil_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region <MB-20101203>

            //Takip silinince, o takipte kullanılan alacakların, taraf ve işleme konan tutar bilgileriyle klasöre yeniden gönderilmesi sağlandı.
            if ((sender as frmKayitSil).DialogResult == DialogResult.OK)
            {
                //Silme tamamlandı kontrolü eklenecek.

                TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                try
                {
                    tran.BeginTransaction();

                    //Varolan collection'lar silinip yenileri oluşturulmadan yeni kayıt işlemi yapıyordu. MB
                    AlacakNedenList.ForEach(item =>
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.Delete(tran, item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection);
                    });
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Save(tran, AlacakNedenList);
                    DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.Save(tran, AlacakNedenTarafList);
                    DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.Delete(tran, TakipliAlacakList);
                    DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK_TAKIPLIProvider.Delete(tran, TakipliMunzamList);
                    DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.Save(tran, TakipsizMunzamList);
                    DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR_TAKIPLIProvider.Delete(tran, TakipliIhtiyatiTedbirList);
                    DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ_TAKIPLIProvider.Delete(tran, TakipliIhtiyatiHacizList);
                    DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.DeepSave(tran, IhtiyatiHacizList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ_TARAF>));
                    DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.DeepSave(tran, IhtiyatiTedbirList, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDI_BIL_IHTIYATI_TEDBIR_TARAF>));
                    TakipsizIhtiyatiTedbirList.ForEach(item =>
                        {
                            if (item.IHTIYATI_TEDBIR_IDSource != null)
                                item.IHTIYATI_TEDBIR_ID = item.IHTIYATI_TEDBIR_IDSource.ID;
                        });
                    DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.Save(tran, TakipsizIhtiyatiTedbirList);
                    TakipsizIhtiyatiHacizList.ForEach(item =>
                        {
                            if (item.IHTIYATI_HACIZ_IDSource != null)
                                item.IHTIYATI_HACIZ_ID = item.IHTIYATI_HACIZ_IDSource.ID;
                        });
                    DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.Save(tran, TakipsizIhtiyatiHacizList);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran.IsOpen)
                        tran.Rollback();
                    ErrorHandler.Catch(this, ex);
                }

                projeGuncelle(null);
            }

            #endregion <MB-20101203>
        }

        private void icraDosyasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);


            frmIcraDosyaKayit frm = new frmIcraDosyaKayit();

            #region <MB-20100927>

            //Teminatlardan takip oluşturulurken alacak ve diğer bilgilerin gelmesini engellemek içen eklendi.
            frm.KrediAlacaklarindanTakip = false;

            #endregion <MB-20100927>

            frm.MyProje = proje;

            // frm.IcraDosyaKayitTiklandi += new EventHandler<FrmIcraDosyaKayitEventArgs>(frm_IcraDosyaKayitTiklandi);
            frm.IcraFoyKaydedildi += frm_IcraFoyKaydedildi;
            frm.Show();

        }

        private void ihtarnameDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TDIE_BIL_PROJE_IHTARNAME)
            {
                var nnIhtar = treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TDIE_BIL_PROJE_IHTARNAME;

                var teblig = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(nnIhtar.TEBLIGAT_ID);
                if (teblig != null)
                {
                    DataRepository.AV001_TDI_BIL_TEBLIGATProvider.DeepLoad(teblig, false, DeepLoadType.IncludeChildren,
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_MUHATAP>
                                                                               ),
                                                                           typeof(TList<AV001_TDI_BIL_TEBLIGAT_YAPAN>),
                                                                           typeof(TList<NN_BELGE_TEBLIGAT>),
                                                                           typeof(TList<AV001_TDIE_BIL_BELGE>));

                    Forms.LayForm.frmLayTabligatKayit frm = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                    frm.bndTebligat.DataSource = teblig;
                    frm.FormClosed += frm_FormClosed;
                    frm.Show();
                }
            }
        }

        private void ihtarnameGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit frm = new frmLayTabligatKayit();
            frm.FormClosed += frm_FormClosed;
            frm.Show(this.AktifProjeyiGetir(false));

            //AdimAdimDavaKaydi.Forms.Icra.frmAlacakGirisi frm = new AdimAdimDavaKaydi.Forms.Icra.frmAlacakGirisi();
            //frm.Klasordenmi = true;
            //frm.FormClosed += frm_FormClosed;
            //frm.ShowDialog(projeGetir(treeKrediHesapBilgileri.FocusedNode, true));
            //frm.Ihtarname = true;
        }

        private void klasörüSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_ALACAK_NEDEN || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TI_BIL_ALACAK_NEDEN))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_ALACAK_NEDEN", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += new FormClosedEventHandler(frmSil_FormClosed);
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDI_BIL_SOZLESME || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDI_BIL_SOZLESME))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_SOZLESME", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TD_BIL_FOY || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TD_BIL_FOY))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TD_BIL_FOY", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TD_BIL_FOY).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_FOY || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TI_BIL_FOY))
            {
                #region <MB-20101203>

                //Takip silinince, o takipte kullanılan alacakların,varsa munzam senetlerin klasöre yeniden gönderilmesi sağlandı.

                if (!(treeKrediHesapBilgileri.FocusedNode.ParentNode.Tag is AV001_TI_BIL_FOY || treeKrediHesapBilgileri.FocusedNode.ParentNode.Tag == typeof(AV001_TI_BIL_FOY)))
                {
                    XtraMessageBox.Show("İcra Dosyası Seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                var foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TI_BIL_FOY).ID);

                if (foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

                var foyAlacaklari = foy.AV001_TI_BIL_ALACAK_NEDENCollection;
                foyAlacaklari.ForEach(item =>
                    {
                        var takipliAlacak = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.GetByALACAK_NEDEN_ID(item.ID).FirstOrDefault();
                        if (takipliAlacak != null)
                        {
                            if (!takipliAlacak.KAYNAK_ALACAK_NEDEN_ID.HasValue) //Eski kayıtlarda KAYNAK_ALACAK_NEDEN_ID NULL
                            {
                                AV001_TI_BIL_ALACAK_NEDEN aNedenTakipli = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(takipliAlacak.ALACAK_NEDEN_ID);
                                TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> projeTakipsizList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(AktifProjeyiGetir(false).ID);

                                projeTakipsizList.ForEach(takipsizAlacak =>
                                     {
                                         var aNedenTakipsiz = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(takipsizAlacak.ALACAK_NEDEN_ID);
                                         if (aNedenTakipsiz.DIGER_ALACAK_NEDENI == aNedenTakipli.DIGER_ALACAK_NEDENI && aNedenTakipsiz.TUTARI == aNedenTakipli.TUTARI)
                                             AlacakIslemleri(aNedenTakipsiz, aNedenTakipli, takipliAlacak);
                                     });
                            }
                            else
                            {
                                var klasorTakipsizAlacak = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByALACAK_NEDEN_ID(takipliAlacak.KAYNAK_ALACAK_NEDEN_ID.Value).FirstOrDefault();

                                if (klasorTakipsizAlacak != null)
                                {
                                    var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(klasorTakipsizAlacak.ALACAK_NEDEN_ID);
                                    AlacakIslemleri(alacak, item, takipliAlacak);
                                }
                            }
                        }
                    });
                MunzamSenetIslemleri(foy);
                IhtiyatiHacizTedbirIslemleri(foy);

                #endregion <MB-20101203>

                AdimAdimDavaKaydi.Util.frmKayitSil frmTakipSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_FOY", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TI_BIL_FOY).ID.ToString());
                frmTakipSil.Show();
                frmTakipSil.FormClosed += new FormClosedEventHandler(frmTakipSil_FormClosed);
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TD_BIL_HAZIRLIK || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TD_BIL_HAZIRLIK))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TD_BIL_HAZIRLIK", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TD_BIL_HAZIRLIK).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDI_BIL_MASRAF_AVANS || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDI_BIL_MASRAF_AVANS))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_MASRAF_AVANS", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDI_BIL_MASRAF_AVANS).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is TDI_BIL_BORCLU_MAL || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(TDI_BIL_BORCLU_MAL))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("TDI_BIL_BORCLU_MAL", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.TDI_BIL_BORCLU_MAL).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDI_BIL_IHTIYATI_TEDBIR || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDI_BIL_IHTIYATI_TEDBIR))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_IHTIYATI_TEDBIR", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDI_BIL_IHTIYATI_TEDBIR).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_IHTIYATI_HACIZ || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TI_BIL_IHTIYATI_HACIZ))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_IHTIYATI_HACIZ", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TI_BIL_IHTIYATI_HACIZ).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_BORCLU_ODEME || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TI_BIL_BORCLU_ODEME))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TI_BIL_BORCLU_ODEME", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TI_BIL_BORCLU_ODEME).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDIE_BIL_PROJE_ILAM_BILGILERI || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDIE_BIL_PROJE_ILAM_BILGILERI))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDIE_BIL_PROJE_ILAM_BILGILERI", "ILAM_ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ILAM_BILGILERI).ILAM_ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TDIE_BIL_PROJE_IHTARNAME || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDIE_BIL_PROJE_IHTARNAME))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDIE_BIL_PROJE_IHTARNAME", "TEBLIGAT_ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTARNAME).TEBLIGAT_ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else if (treeKrediHesapBilgileri.FocusedNode.Tag
is AV001_TDI_BIL_KIYMETLI_EVRAK || treeKrediHesapBilgileri.FocusedNode.Tag == typeof(AV001_TDI_BIL_KIYMETLI_EVRAK))
            {
                AdimAdimDavaKaydi.Util.frmKayitSil frmSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDI_BIL_KIYMETLI_EVRAK", "ID = " + (treeKrediHesapBilgileri.FocusedNode.Tag as AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK).ID.ToString());
                frmSil.Show();
                frmSil.FormClosed += frmSil_FormClosed;
            }
            else
                XtraMessageBox.Show("Silinecek kayıt bulunamadı", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void munzamSenetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuzzamSenetGiris frm = new frmMuzzamSenetGiris();
            frm.ShowDialog(this.AktifProjeyiGetir(true));

            projeGuncelle(null);
        }

        private void pDFeGönderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.pdf|PDF Dosyası";
            sfd.DefaultExt = "pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeKrediHesapBilgileri.ExportToPdf(sfd.FileName);
            }
        }

        private void raporDüzenleyicisineGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeKrediHesapBilgileri.ExpandAll();
            treeKrediHesapBilgileri.Print();
        }

        private void tabbedControlGroup2_SelectedPageChanging(object sender, DevExpress.XtraLayout.LayoutTabPageChangingEventArgs e)
        {
            AV001_TDIE_BIL_PROJE secilenProje = bndProje.Current as AV001_TDIE_BIL_PROJE;
            if (secilenProje == null)
            {
                XtraMessageBox.Show("Önce KLASÖR seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                //tabbedControlGroup2.SelectedTabPage = layoutControlGroup9;
                return;
            }
            if (e.Page.Name == "layoutControlGroup10")//Yapılacak İşler
            {
                YapilacakIsleriYukle(secilenProje.ID);

                //Yapılacak iş kayıt ekranına seçili klasörün gelmesi için eklendi.
                ucGorevler1.KlasorID = secilenProje.ID;
            }
            else if (e.Page.Name == "layoutControlGroup11")//Genel Notlar
            {
                GenelNotlariYukle(secilenProje.ID);
            }
            else if (e.Page.Name == "lcGorupOdemePlani")//Ödeme Planı
            {
                TaahhutMasterYukle(secilenProje);
            }
            else if (e.Page.Name == "lcGroupDokumanlar")//Belgeler
            {
                //Seçili Klasöre ait belgelerin gelmesi için eklendi.
                ucbelgetakip1.CurrentRecord = secilenProje;
                ucbelgetakip1.MyDataSource = BelgeUtil.Inits.BelgeGetirByProjeId(secilenProje.ID);
            }
            else if (e.Page.Name == "lcGroupMasraflar")//Masraflar
            {
                if (!MasraflarYuklendi)
                {
                    gcMasraflar.DataSource = KlasorTumMasraflariGetir(secilenProje, true);

                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.ParaBicimiAyarla(rspTutar);

                    MasraflarYuklendi = true;
                }
            }
            else if (e.Page.Name == "lcGroupOdemeler")//Ödemeler
            {
                if (!OdemelerYuklendi)
                {
                    gcOdemeler.DataSource = KlasorTumOdemeleriGetir(secilenProje, true);

                    BelgeUtil.Inits.perCariGetir(rlueCariOdeme);
                    BelgeUtil.Inits.ParaBicimiAyarla(rspTutarOdeme);
                    BelgeUtil.Inits.DovizTipGetir(rlueDovizTip);
                    BelgeUtil.Inits.OdemeYeriGetir(rlueOdemeYeri);
                    BelgeUtil.Inits.OdemeTipiGetir(rlueOdemeTip);

                    OdemelerYuklendi = true;
                }
            }
            else if (e.Page.Name == "layoutControlGroup8")
            {
                if (this.WindowState != FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Maximized;
            }
            else if (e.Page.Name == "lcGroupDagitilmamisMasraflar")
            {
                MasraflarYuklendi = false;
                gcDagitilmamisMasraflar.DataSource = KlasorTumMasraflariGetir(secilenProje, false);

                BelgeUtil.Inits.perCariGetir(rlueCariDagitilmamis);
                BelgeUtil.Inits.ParaBicimiAyarla(rspTutarDagitilmamis);
            }
            else if (e.Page.Name == "lcGroupDagitilmamisTahsilatlar")
            {
                OdemelerYuklendi = false;
                gcDagitilmamisTahsilatlar.DataSource = KlasorTumOdemeleriGetir(secilenProje, false);

                BelgeUtil.Inits.ParaBicimiAyarla(rspTutarDagitilmisTahsilat);
                BelgeUtil.Inits.DovizTipGetir(rlueDovizDagitilmisTahsilat);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AktifProjeyiGetir(false) == null)
            {
                MessageBox.Show("Lütfen listeden bir klasör seçiniz.", "Klasör seçilmemiş", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmOdemePlani tahutFormu2 = new frmOdemePlani();

            KlasorHesapAraclari ka = new KlasorHesapAraclari();
            AvukatProLib.Hesap.HesapAraclari.OzetHesap ozetHEsap =
                ka.GetKonsolideAlacaklarHesabi2G(AktifProjeyiGetir(false));

            tahutFormu2.Show(ozetHEsap.MyFoy, AktifProjeyiGetir(true));
        }

        private void tsmIhtiyatiHacizDilekcesi_Click(object sender, EventArgs e)
        {
            if ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TI_BIL_IHTIYATI_HACIZ)
            {
                var iHaciz = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByID(((treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TI_BIL_IHTIYATI_HACIZ).ID);
                AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor editorFormu =
                    new AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge.frmEditor();

                editorFormu.Show(
                    DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetByID(1213),
                    projeGetir(treeKrediHesapBilgileri.FocusedNode),
                    iHaciz);
            }
        }

        private void tsmIhtiyatiHacizDuzenle_Click(object sender, EventArgs e)
        {
            if ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TI_BIL_IHTIYATI_HACIZ)
            {
                AV001_TI_BIL_IHTIYATI_HACIZ haciz =
                    DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByID(((treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TI_BIL_IHTIYATI_HACIZ).ID);
                TList<AV001_TI_BIL_IHTIYATI_HACIZ> ListHcz = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();
                ListHcz.Add(haciz);
                rFrmIcraIhtiyatiHaciz frm = new rFrmIcraIhtiyatiHaciz();
                frm.KlasorIcin = true;
                frm.hacizList = ListHcz;
                frm.ShowDialog(AktifProjeyiGetir(true));
                frm.Kaydedildi += frmHaciz_Kaydedildi;
            }
        }

        private void tsmIlamBilgisiDuzenle_Click(object sender, EventArgs e)
        {
            if ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TDIE_BIL_PROJE_ILAM_BILGILERI)
            {
                AV001_TDIE_BIL_PROJE_ILAM_BILGILERI ilam =
                    (treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TDIE_BIL_PROJE_ILAM_BILGILERI;
                AV001_TI_BIL_ILAM_MAHKEMESI tedbir =
                    DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.GetByID(ilam.ILAM_ID);
                TList<AV001_TI_BIL_ILAM_MAHKEMESI> ListTdb = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                ListTdb.Add(tedbir);
                frmIlamMahkemesiTarafli frm = new frmIlamMahkemesiTarafli();
                frm.İlamList = ListTdb;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Kaydedildi += frmmahkeme_Kaydedildi;
                frm.ShowDialog(AktifProjeyiGetir(true));
            }
        }

        private void tsmIlamGirisi_Click(object sender, EventArgs e)
        {
            frmIlamMahkemesiTarafli frm = new frmIlamMahkemesiTarafli();
            frm.ShowDialog(AktifProjeyiGetir(true));
            frm.Kaydedildi += frmmahkeme_Kaydedildi;
        }

        private void tsmiAlacakClick(object sender, EventArgs e)
        {
            Forms.frmKlasorAlacakGirisi frm1 = new frmKlasorAlacakGirisi();
            frm1.MyProje = MyCurrentProje;

            switch (((ToolStripItem)sender).Name)
            {
                case "tsmiAlacakGayriNakitAkreditif":
                case "tsmiAlacakGayriNakitAval":
                case "tsmiAlacakGayriNakitCekTaahhut":
                case "tsmiAlacakGayriNakitDiger":
                case "tsmiAlacakGayriNakitMektup":
                    frm1.DepoAlacagimi = true;
                    break;

                case "tsmiAlacakKiymetliEvrakaBaglanmisAlacakBono":
                case "tsmiAlacakKiymetliEvrakaBaglanmisAlacakCek":
                case "tsmiAlacakKiymetliEvrakaBaglanmisAlacakPolice":
                case "tsmiAlacakNakit":
                    frm1.DepoAlacagimi = false;
                    break;

                default:
                    break;
            }
            frm1.FormClosed += frmMal_Kaydedildi;
            frm1.Show();
            return;
        }

        private void tsmiAlacakDuzenle_Click(object sender, EventArgs e)
        {
            if (treeKrediHesapBilgileri.FocusedNode.Tag == null || !(treeKrediHesapBilgileri.FocusedNode.Tag is AV001_TI_BIL_ALACAK_NEDEN)) return;
            Forms.frmKlasorAlacakGirisi frm1 = new frmKlasorAlacakGirisi();
            frm1.Duzenleme = true;
            frm1.MyProje = MyCurrentProje;
            AV001_TI_BIL_ALACAK_NEDEN alacakNeden = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(((treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TI_BIL_ALACAK_NEDEN).ID);
            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacakNeden, false, DeepLoadType.IncludeChildren,
                                                                      typeof(TI_KOD_ALACAK_NEDEN));
            if (alacakNeden.ALACAK_NEDEN_KOD_IDSource != null)
                frm1.DepoAlacagimi = alacakNeden.ALACAK_NEDEN_KOD_IDSource.DEPO_ALACAGI.Value;
            frm1.MyAlacakNeden = alacakNeden;
            frm1.FormClosed += frmMal_Kaydedildi;
            frm1.Show();
            return;
        }

        private void tsmihtiyatiTedbirDuzenle_Click(object sender, EventArgs e)
        {
            if (treeKrediHesapBilgileri.FocusedNode != null &&
                ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TDI_BIL_IHTIYATI_TEDBIR))
            {
                AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir =
                    (treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TDI_BIL_IHTIYATI_TEDBIR;
                TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> ListTdb = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
                ListTdb.Add(tedbir);
                frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
                frm.KlasorIcin = true;
                frm.tedbirList = ListTdb;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Kaydedildi += frmTedbir_Kaydedildi;
                frm.ShowDialog(AktifProjeyiGetir(true));
            }
        }

        private void tsmiIhtiyatiHaciz_Click(object sender, EventArgs e)
        {
            rFrmIcraIhtiyatiHaciz frm = new rFrmIcraIhtiyatiHaciz();
            frm.KlasorIcin = true;
            frm.ShowDialog(AktifProjeyiGetir(true));
            frm.Kaydedildi += frmHaciz_Kaydedildi;
        }

        private void tsmiMalHakGirisi_Click(object sender, EventArgs e)
        {
            frmBorcluMalKaydetVGrid frm = new frmBorcluMalKaydetVGrid();
            frm.ShowDialog(AktifProjeyiGetir(true));
            frm.Kaydedildi += frmMal_Kaydedildi;
        }

        private void tsmiMasraf_Click(object sender, EventArgs e)
        {
            frmMasrafKayit frm = new frmMasrafKayit();
            frm.FormClosed += frmavans_Kaydedildi;
            frm.Show(AktifProjeyiGetir(true));

            //frm.Kaydedildi += frmavans_Kaydedildi;

            //frmMasrafAvansKayitHizli frm = new frmMasrafAvansKayitHizli();
            //frm.ShowDialog(AktifProjeyiGetir(true));
            //frm.Kaydedildi += frmavans_Kaydedildi;
        }

        private void tsmiOdeme_Click(object sender, EventArgs e)
        {
            frmIcraOdemeBilgileri frm = new frmIcraOdemeBilgileri();
            AV001_TDIE_BIL_PROJE prj = AktifProjeyiGetir(false);

            //prj.Tag = DateTime.Now.AddMinutes(10); //10 dk sonra kaydetmeye başla
            TList<AV001_TI_BIL_BORCLU_ODEME> odemeler = new TList<AV001_TI_BIL_BORCLU_ODEME>();
            odemeler.AddingNew += OdemeAddingNew;

            //frm.MdiParent = null;
            frm.Show(odemeler, AktifTaraflariGetir());
            frm.MyProje = prj;
            frm.Tag = prj;
            frm.FormClosing += frm_FormClosing;
        }

        private void tsmiSozlesmeClick(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout frm = new frmSozlesmeKayitLayout();
            frm.SozlesmeKaydedildi += frm_SozlesmeKaydedildi;
            frm.MyProje = AktifProjeyiGetir(true);
            switch (((ToolStripItem)sender).Name)
            {
                case "tsmiSozlesmeGenelKrediSozlesmesi":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, (int)SozlesmeAltTip.Genel_Kredi_Sozlesmesi);
                    break;

                case "tsmiSozlesmeGenelKrediTaahhutname":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, 167);
                    break;

                case "tsmiSozlesmeBankacilikHizmetSozlesmesi":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, 168);
                    break;

                case "tsmiSozlesmeKonutKrediSozlesmesi":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, 169);
                    break;

                case "tsmiSozlesmeIhtiyacKrediSozlesmesi":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, 170);
                    break;

                case "tsmiSozlesmeTasitKrediSozlesmesi":
                    frm.Show((int)SozlesmeAnaTip.Kredi_Sozlemesi, 171);
                    break;

                case "resenDüzenlenmişNoterSenediToolStripMenuItem":
                    frm.Show((int)SozlesmeAnaTip.Genel_Sozleme, (int)SozlesmeAltTip.Resen_Duzenlenmis_Noter_Senedi);
                    break;

                case "noterdenBorçİkrarıToolStripMenuItem":
                    frm.Show((int)SozlesmeAnaTip.Genel_Sozleme, (int)SozlesmeAltTip.Noterden_Borc_Ikrari);
                    break;
            }

            frm.Show();
        }

        private void tsmiTeminat_Click(object sender, EventArgs e)
        {
            frmSozlesmeKayitLayout frm = new frmSozlesmeKayitLayout();
            frm.MyProje = (AktifProjeyiGetir(true));
            frm.SozlesmeKaydedildi += frm_SozlesmeKaydedildi;
            switch (((ToolStripItem)sender).Name)
            {
                case "tsmiTeminatMenkulRehniAracRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, (int)SozlesmeAltTip.Arac_Rehni);
                    break;

                case "tsmiTeminatMenkulRehniDigerMenkulRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, 10);
                    break;

                case "tsmiTeminatMenkulRehniHatRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, 172);
                    break;

                case "tsmiTeminatMenkulRehniHisseSenediRehni":
                    frm.Show((int)SozlesmeAnaTip.Genel_Sozleme, (int)SozlesmeAltTip.Hisse_Rehni_Sozlesmesi);
                    break;

                case "tsmiTeminatMenkulRehniMarkaRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, 173);
                    break;

                case "tsmiTeminatMenkulRehniTicariPlakaRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, 174);
                    break;

                case "tsmiTeminatTicariIsletmeRehni":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, (int)SozlesmeAltTip.Ticari_Isletme_Rehni);
                    break;

                case "tsmiTeminatIpotek":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, (int)SozlesmeAltTip.Gayrimenkul_Ipotegi);
                    break;

                case "havaAracıİpoteğiToolStripMenuItem":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, (int)SozlesmeAltTip.Hava_Araci_Ipotegi);
                    break;

                case "gemiİpoteğiToolStripMenuItem":
                    frm.Show((int)SozlesmeAnaTip.Resmi_Senet, (int)SozlesmeAltTip.Gemi_Ipotegi);
                    break;

                case "tsmiTeminatMunzamSenet":
                case "tsmiTeminatMunzamSenetÇek":
                case "tsmiTeminatMenkulRehniKambiyoSenediCek":
                    {
                        frmKiymetliEvrakKayitLayout frm2 = new frmKiymetliEvrakKayitLayout();
                        frm2.MyProje = AktifProjeyiGetir(true);
                        frm2.munzammi = true;
                        frm2.Kaydedildi += frm2Evrak_Kaydedildi;
                        frm2.Show((int)frmKiymetliEvrakKayit.TeminatSekli.MunzamSenet_Cek);
                    }
                    break;

                case "tsmiTeminatMunzamSenetBono":
                case "tsmiTeminatMenkulRehniKambiyoSenediBono":
                    {
                        frmKiymetliEvrakKayit frm2 = new frmKiymetliEvrakKayit();
                        frm2.MyProje = AktifProjeyiGetir(true);
                        frm2.t = frmKiymetliEvrakKayit.TeminatSekli.MunzamSenet_Bono;
                        frm2.munzammi = true;
                        frm2.MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                        frm2.Kaydedildi += frm2Evrak_Kaydedildi;
                        frm2.Show();
                    }
                    break;

                case "tsmiTeminatMunzamSenetPolice":
                case "tsmiTeminatMenkulRehniKambiyoSenediPolice":
                    {
                        frmKiymetliEvrakKayit frm2 = new frmKiymetliEvrakKayit();
                        frm2.MyProje = AktifProjeyiGetir(true);
                        frm2.t = frmKiymetliEvrakKayit.TeminatSekli.MunzamSenet_Police;
                        frm2.munzammi = true;
                        frm2.MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                        frm2.Kaydedildi += frm2Evrak_Kaydedildi;
                        frm2.Show();
                    }
                    break;

                case "tsmiTeminatTeminatSenedi":
                    {
                        frmKiymetliEvrakKayitLayout frm2 = new frmKiymetliEvrakKayitLayout();
                        frm2.MyProje = AktifProjeyiGetir(true);
                        frm2.munzammi = false;
                        frm2.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frm2.Kaydedildi += frm2Evrak_Kaydedildi;
                        frm2.Show((int)frmKiymetliEvrakKayit.TeminatSekli.MunzamSenet_Police);
                    }
                    break;

                default:
                    break;
            }
        }

        private void tsmkiymetliEvrakBilgileriDuzenle_Click(object sender, EventArgs e)
        {
            if ((treeKrediHesapBilgileri.FocusedNode.Tag) is AV001_TDI_BIL_KIYMETLI_EVRAK)
            {
                AV001_TDI_BIL_KIYMETLI_EVRAK haciz = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID(((treeKrediHesapBilgileri.FocusedNode.Tag) as AV001_TDI_BIL_KIYMETLI_EVRAK).ID);
                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(haciz, false, DeepLoadType.IncludeChildren,
                                                                             typeof(
                                                                                 TList
                                                                                 <AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> ListHcz = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                ListHcz.Add(haciz);
                frmKiymetliEvrakKayitLayout frm2 = new frmKiymetliEvrakKayitLayout();
                frm2.MyProje = AktifProjeyiGetir(true);
                frm2.MyDataSource = ListHcz;

                // frm2.MdiParent = null;
                frm2.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm2.Kaydedildi += frm2Evrak_Kaydedildi;
                frm2.Show();
            }
        }

        private void wordeGönderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.rtf|Word Dosyası";
            sfd.DefaultExt = "rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                treeKrediHesapBilgileri.ExportToRtf(sfd.FileName);
            }
        }

        private void yeniKlasörOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYeniKlasor frm = new frmYeniKlasor();
            if (MyDataSource == null)
                MyDataSource = new TList<AV001_TDIE_BIL_PROJE>();
            frm.Show();
            frm.FormClosed += delegate
                                  {
                                      AV001_TDIE_BIL_PROJE prj = frm.YeniKlasorGetir();
                                      if (prj != null)
                                      {
                                          DataRepository.AV001_TDIE_BIL_PROJEProvider.DeepSave(prj);
                                          MyDataSource.Clear();
                                          MyDataSource.Add(prj);
                                          projeGuncelle(MyDataSource);
                                          BelgeUtil.Inits._ProjeAdGetir.Add(Inits.GetProjeViewItem(prj));
                                          (lueAra.Properties.DataSource as List<AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE>).Add(Inits.GetProjeViewItem(prj));

                                          //BelgeUtil.Inits.ProjeAdGetirYenile(lueAra);
                                          lueAra.EditValue = prj.ID;
                                          sbtnBul.PerformClick();
                                      }
                                  };
        }

        #region <MB-20100525>

        //Dava dosyası kaydında davacı, davalı durumuna göre tarafların otomatik gelmesi sağlandı.

        private void davacıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            frm.ProjeDavaci = true;
            frm.MyProje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            frm.DavaFoyKaydedildi += frm_DavaFoyKaydedildi;
            frm.Show();
        }

        private void davalıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDavaDosyaKayitForm frm = new frmDavaDosyaKayitForm();
            frm.ProjeDavaci = false;
            frm.MyProje = projeGetir(treeKrediHesapBilgileri.FocusedNode, true);
            frm.DavaFoyKaydedildi += frm_DavaFoyKaydedildi;
            frm.Show();
        }

        #endregion <MB-20100525>

        #region <MB-20100525>

        //Soruşturma dosyası kaydında şikayet eden, şikayet edilen durumuna göre tarafların otomatik gelmesi sağlandı.

        private void şikayetEdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfrmSorusturmaGiris frm = new rfrmSorusturmaGiris();
            frm.ProjeSikayetEden = true;
            frm.MyProje = AktifProjeyiGetir(true);
            frm.Show();
            frm.SorusturmaKaydedildi += frm_SorusturmaKaydedildi;
        }

        private void şikayetEdilenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfrmSorusturmaGiris frm = new rfrmSorusturmaGiris();
            frm.ProjeSikayetEden = false;
            frm.MyProje = AktifProjeyiGetir(true);
            frm.Show();
            frm.SorusturmaKaydedildi += frm_SorusturmaKaydedildi;
        }

        #endregion <MB-20100525>

        #endregion RİGHT CLİCK

        private void tsmiIhtiyatiTedbir_Click(object sender, EventArgs e)
        {
            frmDavaIcraIhtiyatiTedbir frm = new frmDavaIcraIhtiyatiTedbir();
            frm.KlasorIcin = true;
            frm.ShowDialog(AktifProjeyiGetir(true));
            frm.Kaydedildi += new EventHandler<EventArgs>(frmTedbir_Kaydedildi);
        }

        #endregion TREE LİST RİGHT CLİCK AND EVENTS

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedSozlesme = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((treeKrediHesapBilgileri.FocusedNode.Tag as AV001_TDI_BIL_SOZLESME).ID);
            TList<AV001_TDI_BIL_SOZLESME> sozlesmeList = new TList<AV001_TDI_BIL_SOZLESME>();
            sozlesmeList.Add(selectedSozlesme);
            AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayitLayout frm = new frmSozlesmeKayitLayout();
            frm.EditMode = true;
            frm.SozlesmeKaydedildi += frm_SozlesmeKaydedildi;
            frm.Show(sozlesmeList);
        }

        #endregion KREDİ BİLGİLERİ TREE LİST

        private enum Hangisi { Alacak, Borclu, Sorumlu };

        private void CariDetayGetir(Hangisi hh)
        {
            if (hh == Hangisi.Alacak)
            {
                AV001_TDIE_BIL_PROJE_TARAF seciliTaraf = (AV001_TDIE_BIL_PROJE_TARAF)gwAlacak.GetRow(gwAlacak.FocusedRowHandle);
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
            else if (hh == Hangisi.Borclu)
            {
                AV001_TDIE_BIL_PROJE_TARAF seciliTaraf = (AV001_TDIE_BIL_PROJE_TARAF)gwBorclu.GetRow(gwBorclu.FocusedRowHandle);
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
            else if (hh == Hangisi.Sorumlu)
            {
                AV001_TDIE_BIL_PROJE_SORUMLU seciliTaraf = (AV001_TDIE_BIL_PROJE_SORUMLU)gwSorumluAvk.GetRow(gwSorumluAvk.FocusedRowHandle);
                VList<per_CariKimlikIletisimBilgileri> adres = new VList<per_CariKimlikIletisimBilgileri>();
                adres = DataRepository.per_CariKimlikIletisimBilgileriProvider.Get("ID = " + seciliTaraf.CARI_ID.ToString(), "ID");
                gcIletisimBilgileri.DataSource = adres;
            }
        }

        private void frm_FormClosed2(object sender, FormClosedEventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod1, 1, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod2, 2, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod3, 3, Modul.Klasor);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(lueOzelKod4, 4, Modul.Klasor);
        }

        private void gcAlacak_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }

        private void gcBorclu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }

        private void gcSorumlu_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }

        private void gwAlacak_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gwAlacak.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Alacak);
        }

        private void gwAlacak_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gwAlacak.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Alacak);
        }

        private void gwBorclu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gwBorclu.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Borclu);
        }

        private void gwBorclu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gwBorclu.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Borclu);
        }

        private void gwSorumluAvk_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gwSorumluAvk.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Sorumlu);
        }

        private void gwSorumluAvk_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gwSorumluAvk.FocusedRowHandle >= 0)
                CariDetayGetir(Hangisi.Sorumlu);
        }

        private void lueOzelKod1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed2);
            }
        }

        private void lueOzelKod2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed2);
            }
        }

        private void lueOzelKod3_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed2);
            }
        }

        private void lueOzelKod4_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "ekle")
            {
                AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle frm = new AdimAdimDavaKaydi.Util.frmFoyOzelKodEkle();
                frm.Show();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed2);
            }
        }

        private void sbtnMasraflariDagit_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmDagitilmamisMasraflar frm = new AdimAdimDavaKaydi.Entegrasyon.frmDagitilmamisMasraflar();
            frm.Klasor = bndProje.Current as AV001_TDIE_BIL_PROJE;
            frm.Show();
        }

        private void sbtnTahsilatlariDagit_Click(object sender, EventArgs e)
        {
            Entegrasyon.frmDagitilmamisTahsilatlar frm = new AdimAdimDavaKaydi.Entegrasyon.frmDagitilmamisTahsilatlar();
            frm.Klasor = bndProje.Current as AV001_TDIE_BIL_PROJE;
            frm.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmKrediBorclusuSec frm = new frmKrediBorclusuSec();
            frm.Proje = bndProje.Current as AV001_TDIE_BIL_PROJE;
            frm.Show();
        }
    }
}