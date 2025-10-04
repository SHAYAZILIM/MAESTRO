using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using AdimAdimDavaKaydi.Sorusturma.UserControls;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil;

namespace AdimAdimDavaKaydi.Util
{
    public class DavaCreated
    {
        private frmDavaTakip frm;

        public void SorusturmaDavaDosyasiOlustur(AV001_TD_BIL_HAZIRLIK MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MAL_BEYANINDA_BULUNMAMA);
            TList<AV001_TD_BIL_FOY> result = ucSorusturmaTarafBilgileri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TD_BIL_HAZIRLIK_TARAF>),
                                                                     typeof(TList<AV001_TD_BIL_HAZIRLIK_SORUMLU>));


                DialogResult dr =
                   XtraMessageBox.Show("Dosyanın şikayet eden tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)", "Dava Kaydı Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.CEZA,
                        DateTime.Now, false, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.CEZA,
                        DateTime.Now, true, kaydedildi);
                }
            }
            else
            {
                //string str = "Dosyayı";
                //if (result.Count > 1)
                //    str = "Dosyaları";

                //DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                //                                      "mal beyanı dava kaydı bulunmaktadır." + str + " " +
                //                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                //                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (dr == DialogResult.OK)
                //{
                frm = new frmDavaTakip();

                frm.Show(result);
                //}
            }
        }

        public void MalBeyaniDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MAL_BEYANINDA_BULUNMAMA);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                //DialogResult dr =
                //    XtraMessageBox.Show(
                //        ucIcraTarafGelismeleri.CurrTarafAdi(
                //            MyFoy.AV001_TI_BIL_FOY_TARAFCollection[ucIcraTarafGelismeleri.TarafIndexBul(MyFoy)]) + " " +
                //        "isimli tarafa bağlı dosyada mal beyanı davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                //        "Mal Beyanı Dava Kaydı Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                DialogResult dr =
                   XtraMessageBox.Show(
                       ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                       "isimli tarafa bağlı dosyada mal beyanı davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                       "Mal Beyanı Dava Kaydı Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "mal beyanı dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void EksikMalBeyaniDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.GERCEGE_AYKIRI_MAL_BEYANINDA_BULUNMAK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada mal beyanı davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Mal Beyanı Dava Kaydı Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.GERCEGE_AYKIRI_MAL_BEYANINDA_BULUNMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "mal beyanı dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void ItirazinKaldirilmasiDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme,
                                                 AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ITIRAZIN_KESIN_OLARAK_KALDIRILMASI);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada itiraz davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "İtiraz Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("İtiraz tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //XtraMessageBox.Show("İtiraz kaydı oluşturma istiyormusunuz?", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.ITIRAZIN_KESIN_KALDIRILMASI_TALEBI,
                            AdliBirimBolumGorev.IHUM,
                            DavaTipi.ICRA_HUKUK,
                            DavaAdi.ITIRAZIN_KESIN_OLARAK_KALDIRILMASI,
                            GonderilenGelisme.ITIRAZ_TARIHI.Value,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.DAVALI,
                            TarafKodu.KarsiTaraf, kaydedildi);
                    }
                }

                else if (dr == DialogResult.No)
                {
                    if (!GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("İtiraz tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_CEZA,
                            DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                            DateTime.Now,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                            TarafKodu.KarsiTaraf,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.DAVALI,
                            TarafKodu.Muvekkil, kaydedildi);
                    }
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "itiraz davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void OlumsuzTespitDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.OLUMSUZ_TESPİT);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada itiraz davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Olumsuz Tespit Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.OLUMSUZ_TESPIT,
                        AdliBirimBolumGorev.AHM,
                        DavaTipi.HUKUK,
                        DavaAdi.OLUMSUZ_TESPİT,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Olumsuz Tespit Davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void DavaIstishak(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ALACAKLININ_ISTIHKAK_DAVASI);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada istihkak davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Istirdat Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.ISTIHKAK,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.ALACAKLININ_ISTIHKAK_DAVASI,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Istirdat davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void DavaIstirdat(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.İSTİRDAT);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada istirdat davası bulunmadığından sistem sizin için üretecektir. \r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Istirdat Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.ISTIRDAT,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.İSTİRDAT,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Istirdat Davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void DavaIhaleninFeshi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.IHALENIN_FESHI);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada ihalenin feshi davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Ihalenin Feshi Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.IHALENIN_FESHI_TALEBI,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.IHALENIN_FESHI,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Ihalenin Feshi davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void DavaTahrifat(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.SENETTE_TAHRİFAT);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada tahrifat davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Tahrifat Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!GonderilenGelisme.SATIS_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("Satış tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.SENETTE_TAHRİFAT,
                            AdliBirimBolumGorev.AGCM,
                            DavaTipi.CEZA,
                            DavaAdi.SENETTE_TAHRİFAT,
                            DateTime.Now,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.SANIK,
                            TarafKodu.KarsiTaraf, kaydedildi);
                    }
                }
                else if (dr == DialogResult.No)
                {
                    if (!GonderilenGelisme.SATIS_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("Satış tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_CEZA,
                            DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                            DateTime.Now,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                            TarafKodu.KarsiTaraf,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.SANIK,
                            TarafKodu.Muvekkil, kaydedildi);
                    }
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Tahrifat davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void ItirazinKaldirillmasiIflasDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme,
                                                       AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();

            dList.Add(DavaAdi.ITIRAZIN_KALDIRILMASI_VE_TAHLIYE);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada itirazın kaldırılması iflas davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "İtiraz Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("İtiraz tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //XtraMessageBox.Show("İtiraz kaydı oluşturma istiyormusunuz?", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.ITIRAZI_KALDIRILMASI_VE_TAHLIYE,
                            AdliBirimBolumGorev.ATM,
                            DavaTipi.HUKUK,
                            DavaAdi.ITIRAZIN_KALDIRILMASI_VE_TAHLIYE,
                            GonderilenGelisme.ITIRAZ_TARIHI.Value,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                            TarafKodu.Muvekkil,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.DAVALI,
                            TarafKodu.KarsiTaraf, kaydedildi);
                    }
                }

                else if (dr == DialogResult.No)
                {
                    if (!GonderilenGelisme.ITIRAZ_TARIHI.HasValue)
                    {
                        XtraMessageBox.Show("İtiraz tarihi bulunamıyor! Bu durumda yeni dava kaydı oluşturulamaz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DavaCreator.DavaOlustur(
                            MyFoy, GonderilenGelisme,
                            DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                            AdliBirimBolumGorev.ICM,
                            DavaTipi.ICRA_CEZA,
                            DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                            DateTime.Now,
                            ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                            TarafKodu.KarsiTaraf,
                            ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                            TarafSifat.DAVALI,
                            TarafKodu.Muvekkil, kaydedildi);
                    }
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "itiraz davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void IhlalDavasıAc(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            //if (result.Count == 0)
            //{
            if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                 typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
            DialogResult dr =
                XtraMessageBox.Show(
                    ucIcraTarafGelismeleri.CurrTarafAdi(
                       MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                    "bağlı dosyaya sistem sizin için ihlal davası üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                    "Dava Kaydı Üretilecek",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.TAAHHUDU_IHLAL,
                    AdliBirimBolumGorev.ICM,
                    DavaTipi.ICRA_CEZA,
                    DavaAdi.ICRA_DAIRESINDE_KARARLASTIRILAN_BORCUN_ODEME_SARTINI_IHLAL_ETMEK,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf,
                    kaydedildi);
            }

            else if (dr == DialogResult.No)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                    AdliBirimBolumGorev.ICM,
                    DavaTipi.ICRA_CEZA,
                    DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                    DateTime.Now,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.KarsiTaraf,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.Muvekkil,
                    kaydedildi);
            }
            //}

            //else
            //{
            //    string str = "Dosyayı";
            //    if (result.Count > 1)
            //        str = "Dosyaları";

            //    DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
            //                                          "dava kaydı bulunmaktadır." + str + " " +
            //                                          "takip ekranında açmak istiyor musunuz?", "Dava Takip",
            //                                          MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (dr == DialogResult.OK)
            //    {
            //        if (frm == null)
            //            frm = new frmDavaTakip();

            //        frm.Show(result);
            //    }
            //}
        }

        public void KarsiliksizCek(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            formDeeploadkiymetliEvrakCek(MyFoy);
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.CEKI_KARSILIKSIZ_OLARAK_KESIDE_ETMEK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada karşılıksız çek davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.KARSILIKSIZ_CEK,
                        AdliBirimBolumGorev.ACM,
                        DavaTipi.CEZA,
                        DavaAdi.CEKI_KARSILIKSIZ_OLARAK_KESIDE_ETMEK,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }

                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void NafakaSartiniIhlal(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.NAFAKA_ŞARTINI_İHLAL);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada nafaka şartını ihlal davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.NAFAKANIN_KALDIRILMASI,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.NAFAKA_ŞARTINI_İHLAL,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }

                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void EmniyetiSuistimal(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.HİZMET_SEBEBİYLE_EMNİYETİ_SUİSTİMAL);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada emniyeti suistimal davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.EMNİYETİ_SUİSTİMAL,
                        AdliBirimBolumGorev.ACM,
                        DavaTipi.CEZA,
                        DavaAdi.HİZMET_SEBEBİYLE_EMNİYETİ_SUİSTİMAL,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void MemuruSikayet(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MEMURUN_ISLEMINI_SIKAYET);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada memuru şikayet davası bulunmadığından sistem sizin için üretecektir.r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.ISLEMI_SIKAYET_TALEBI,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.MEMURUN_ISLEMINI_SIKAYET,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void HileliIflas(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.İFLASIN_HİLELİ_OLARAK_YAPILMASI);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada iflasın hileli olarak yapılması davası bulunmadığından sistem sizin için üretecektir.r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.İFLASIN_HİLELİ_OLARAK_YAPILMASI,
                        AdliBirimBolumGorev.ACM,
                        DavaTipi.CEZA,
                        DavaAdi.İFLASIN_HİLELİ_OLARAK_YAPILMASI,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void Iflas(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.IFLAS);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada iflas davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.IFLAS,
                        AdliBirimBolumGorev.ATM,
                        DavaTipi.HUKUK,
                        DavaAdi.IFLAS,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void IhtiyatiHaciz(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.IHTIYATI_HACIZ);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada ihtiyati haciz davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.IHTIYATI_HACIZ,
                        AdliBirimBolumGorev.AHM,
                        DavaTipi.HUKUK,
                        DavaAdi.IHTIYATI_HACIZ,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void IhtiyatiTedbir(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.IHTIYATI_TEDBIR);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada ihtiyati tedbir davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.IHTIYATI_TEDBIR,
                        AdliBirimBolumGorev.AHM,
                        DavaTipi.HUKUK,
                        DavaAdi.IHTIYATI_TEDBIR,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void KiymetTaktirineItiraz(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.KIYMET_TAKDİRİNE_İTİRAZ);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada kıymet taktirine itiraz davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.KIYMET_TAKDIRINE_ITIRAZ,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.KIYMET_TAKDİRİNE_İTİRAZ,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void ImzayaItiraz(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.İMZAYA_İTİRAZ);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada imzaya itiraz davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.IMZAYA_ITIRAZLARIMIN_SUNULMASI_TALEBI,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.İMZAYA_İTİRAZ,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void TahliyeEdilenGayrimenkul(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.TAHLİYESİ_EMROLUNAN_YERİ_KİRALAYANA_ZARAR_VERMEK_MAKSADI_İLE_İŞGAL_ETTİRMEK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada Tahliye edilen gayrimenkule işgal etme davası bulunmadığından sistem sizin için üretecektir. \r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.TAHLİYESİ_EMROLUNAN_YERİ_KİRALAYANA_ZARAR_VERMEK_MAKSADI_İLE_İŞGAL_ETTİRMEK,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.TAHLİYESİ_EMROLUNAN_YERİ_KİRALAYANA_ZARAR_VERMEK_MAKSADI_İLE_İŞGAL_ETTİRMEK,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.SANIK,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void TakibinIptali(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.ICRA_TAKIBININ_IPTALI);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada Takibin iptali davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.ICRA_TAKIBININ_IPTALI_TALEBI,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.ICRA_TAKIBININ_IPTALI,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void Tahliye(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.TAHLIYE);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada Tahliye davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Dava Kaydı Üretilecek",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.TAHLIYE,
                        AdliBirimBolumGorev.IHUM,
                        DavaTipi.ICRA_HUKUK,
                        DavaAdi.TAHLIYE,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void HacizIsleminiSikayet(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.HACIZ_ISLEMININ_IPTALI);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.HACZE_ITIRAZ,
                    AdliBirimBolumGorev.IHUM,
                    DavaTipi.ICRA_HUKUK,
                    DavaAdi.HACIZ_ISLEMININ_IPTALI,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void MeskeniyetDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MESKENIYET_IDDIASI);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.MESKENIYET_IDDIASI_DAVASI,
                    AdliBirimBolumGorev.IHUM,
                    DavaTipi.ICRA_HUKUK,
                    DavaAdi.MESKENIYET_IDDIASI,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void IstihkakHakkiDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.İSTİHKAK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.ISTIHKAK,
                    AdliBirimBolumGorev.IHUM,
                    DavaTipi.ICRA_HUKUK,
                    DavaAdi.İSTİHKAK,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void IhaleninFeshiDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.IHALENIN_FESHI);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.IHALENIN_FESHI_TALEBI,
                    AdliBirimBolumGorev.IHUM,
                    DavaTipi.ICRA_HUKUK,
                    DavaAdi.IHALENIN_FESHI,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void MemuraHakaretDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MEMURA_HAKARET);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.HAKARET,
                    AdliBirimBolumGorev.ACM,
                    DavaTipi.CEZA,
                    DavaAdi.MEMURA_HAKARET,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void MemuraMuessirDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MEMURU_DOVMEK_YARALAMAK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.MEMURU_DOVMEK_YARALAMAK,
                    AdliBirimBolumGorev.AGCM,
                    DavaTipi.CEZA,
                    DavaAdi.MEMURA_HAKARET,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void YediEminiSıkayetDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.YEDDI_EMINLIGI_SUISTIMAL);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.YEDDIEMINLI_SUİSTİMAL,
                    AdliBirimBolumGorev.ACM,
                    DavaTipi.CEZA,
                    DavaAdi.YEDDI_EMINLIGI_SUISTIMAL,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void AvukataHakaretDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.DURUSMADA_HAKARET_VE_SOVME);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.HAKARET,
                    AdliBirimBolumGorev.AGCM,
                    DavaTipi.CEZA,
                    DavaAdi.DURUSMADA_HAKARET_VE_SOVME,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void AvukataMuessirDavasi(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.MUESSIR_FIILDE_BULUNMAK);
            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                DavaCreator.DavaOlustur(
                    MyFoy, GonderilenGelisme,
                    DavaTalep.MUESSIR_FIILDE_BULUNMAK,
                    AdliBirimBolumGorev.AGCM,
                    DavaTipi.CEZA,
                    DavaAdi.MUESSIR_FIILDE_BULUNMAK,
                    DateTime.Now,
                    ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                    TarafKodu.Muvekkil,
                    ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                    TarafSifat.DAVALI,
                    TarafKodu.KarsiTaraf, kaydedildi);
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "dava kaydı bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public void DavaTasarrufunIptali(AV001_TI_BIL_FOY_TARAF_GELISME GonderilenGelisme, AV001_TI_BIL_FOY MyFoy, OnKayit kaydedildi = null)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            dList.Add(DavaAdi.TASARRUFUN_IPTALI);

            TList<AV001_TD_BIL_FOY> result = ucIcraTarafGelismeleri.IliskiliDavaKayitlari(MyFoy, dList);

            if (result.Count == 0)
            {
                if (MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0 ||
                    MyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>),
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                DialogResult dr =
                    XtraMessageBox.Show(
                        ucIcraTarafGelismeleri.CurrTarafAdi(
                           MyFoy.AV001_TI_BIL_FOY_TARAFCollection.Find(t => t.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)) + " " +
                        "isimli tarafa bağlı dosyada Tasarrufun İptali davası bulunmadığından sistem sizin için üretecektir.\r\nDosyanın alacaklı tarafı 'DAVACI' mı olsun? (Evet=Davacı, Hayır=Davalı)",
                        "Tasarrufun İptali Davası Üretilecek", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.TASARRUFUN_IPTALI,
                        AdliBirimBolumGorev.AHM,
                        DavaTipi.HUKUK,
                        DavaAdi.TASARRUFUN_IPTALI,
                        DateTime.Now,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.Muvekkil,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.KarsiTaraf, kaydedildi);
                }
                else if (dr == DialogResult.No)
                {
                    DavaCreator.DavaOlustur(
                        MyFoy, GonderilenGelisme,
                        DavaTalep.MAL_BEYANINDA_BULUNMAMA,
                        AdliBirimBolumGorev.ICM,
                        DavaTipi.ICRA_CEZA,
                        DavaAdi.MAL_BEYANINDA_BULUNMAMA,
                        DateTime.Now,
                        ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.DAVACI,
                        TarafKodu.KarsiTaraf,
                        ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID,
                        TarafSifat.DAVALI,
                        TarafKodu.Muvekkil, kaydedildi);
                }
            }

            else
            {
                string str = "Dosyayı";
                if (result.Count > 1)
                    str = "Dosyaları";

                DialogResult dr = XtraMessageBox.Show("Bu dosyaya bağlı" + " " + result.Count + " " + "tane" + " " +
                                                      "Tasarrufun İptali davası bulunmaktadır." + str + " " +
                                                      "takip ekranında açmak istiyor musunuz?", "Dava Takip",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (frm == null)
                        frm = new frmDavaTakip();

                    frm.Show(result);
                }
            }
        }

        public string IlkHarfiBuyut(string Text)
        {
            string[] sText = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sText.Length; i++)
            {
                sText[i] = sText[i].Substring(0, 1).ToUpper() + sText[i].Substring(1).ToLower();
            }
            return string.Join(" ", sText);
        }

        internal void SucDuyurusuOlustur(AV001_TI_BIL_FOY MyFoy)
        {
            List<DavaAdi> dList = new List<DavaAdi>();
            SorusturmaOlustur(
                MyFoy,
                null,
                AdliBirimBolumGorev.SVC,
                null,
                DateTime.Now,
                ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                TarafKodu.Muvekkil,
                ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                TarafSifat.SANIK,
                TarafKodu.KarsiTaraf);
        }

        internal static void SorusturmaIliskiOlustur(AV001_TI_BIL_FOY MyFoy, AV001_TD_BIL_HAZIRLIK mysorus)
        {
            TList<AV001_TDI_BIL_KAYIT_ILISKI> iliski = ucIcraTarafGelismeleri.KayitIliskiGetir(MyFoy.ID);

            if (iliski.Count == 0)
            {
                iliski.Add(MyFoy.AV001_TDI_BIL_KAYIT_ILISKICollection.AddNew());

                iliski[0].ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.İCRA_DOSYASI;
                iliski[0].KAYIT_TARIHI = DateTime.Today;
                iliski[0].KAYNAK_ICRA_FOY_ID = MyFoy.ID;
                iliski[0].KAYNAK_KAYIT_ID = MyFoy.ID;
                iliski[0].KAYNAK_TIP = 1;
                iliski[0].AKTIF_MI = true;
                iliski[0].KAYIT_TARIHI = DateTime.Today;
                iliski[0].KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                iliski[0].KONTROL_KIM = "AVUKATPRO";
                iliski[0].KONTROL_NE_ZAMAN = DateTime.Today;
                iliski[0].KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
                iliski[0].STAMP = AvukatProLib.Kimlik.DefaultStamp;
                iliski[0].SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            }

            AV001_TDI_BIL_KAYIT_ILISKI_DETAY detay = iliski[0].AV001_TDI_BIL_KAYIT_ILISKI_DETAYCollection.AddNew();

            detay.HEDEF_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            detay.HEDEF_ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            detay.HEDEF_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            detay.HEDEF_HAZIRLIK_ID = mysorus.ID;
            detay.HEDEF_DOSYA_TARIHI = MyFoy.TAKIP_TARIHI;
            detay.HEDEF_ESAS_NO = MyFoy.ESAS_NO;
            detay.HEDEF_FOY_NO = MyFoy.FOY_NO;
            detay.HEDEF_ICRA_FOY_ID = null; //RelatedIcraFoy.ID;
            detay.HEDEF_KAYIT_ID = mysorus.ID;
            detay.HEDEF_RUCU_ID = null;
            detay.HEDEF_TIP = 1;
            detay.ILISKI_TUR_ID = (int)AdimAdimDavaKaydi.IcraTakipForms.ucIliskiDetay.IliskiTur.İCRA_DOSYASI;
            detay.ADMIN_KAYIT_MI = 0;
            detay.KAYIT_TARIHI = DateTime.Today;

            detay.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            detay.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            detay.KONTROL_NE_ZAMAN = DateTime.Today;
            detay.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            detay.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            detay.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            trans.BeginTransaction();
            DataRepository.AV001_TDI_BIL_KAYIT_ILISKIProvider.DeepSave(trans, iliski,
                                                                       DeepSaveType.IncludeChildren,
                                                                       typeof(TList<AV001_TDI_BIL_KAYIT_ILISKI_DETAY>));
            trans.Commit();
        }

        internal void formDeeploadkiymetliEvrakCek(AV001_TI_BIL_FOY MyFoy)
        {
            if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            foreach (AV001_TI_BIL_ALACAK_NEDEN item in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                if (item.AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAKCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                              typeof(
                                                                                  TList
                                                                                  <
                                                                                  AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK
                                                                                  >));
            }
        }

        internal void SucDuyurusuOlusturKarsiliksizCek(AV001_TI_BIL_FOY MyFoy)
        {
            formDeeploadkiymetliEvrakCek(MyFoy);
            List<DavaAdi> dList = new List<DavaAdi>();

            SorusturmaOlustur(
                MyFoy, DavaTalep.KARSILIKSIZ_CEK_C,
                AdliBirimBolumGorev.SVC,
                DavaAdi.CEKI_KARSILIKSIZ_OLARAK_KESIDE_ETMEK,
                DateTime.Now,
                ucIcraTarafBilgileri.AlacakliTaraflariGetir(MyFoy)[0].CARI_ID, TarafSifat.YAKINAN,
                TarafKodu.Muvekkil,
                ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID,
                TarafSifat.SANIK,
                TarafKodu.KarsiTaraf);
        }

        #region ÖnHazirlik Soruşturma

        private static AV001_TI_BIL_FOY foyum = new AV001_TI_BIL_FOY();
        private static AV001_TD_BIL_HAZIRLIK sorusturmam = new AV001_TD_BIL_HAZIRLIK();

        public static void SorusturmaOlustur(AV001_TI_BIL_FOY mFoy, DavaTalep? mDavaTalep,
                                             AdliBirimBolumGorev mAdliGorev,
                                             DavaAdi? mDavaAdi, DateTime mOlayTarihi, int? mDavaEdenCariId,
                                             TarafSifat mDavaEdenSifat, TarafKodu? mDavaEdenTarafKodu,
                                             int? mDavaEdilenCariId, TarafSifat mDavaEdilenSifat,
                                             TarafKodu? mDavaEdilenTarafKodu)
        {
            rfrmSorusturmaGiris frm = new rfrmSorusturmaGiris();
            frm.OtomatikKayit = true;
            frm.RelatedIcraFoy = mFoy;
            frm.Icradanmi = true;
            frm.Show();
            SorusturmaUret(frm.MySikayet, mFoy, mDavaTalep, mAdliGorev, mDavaAdi, mOlayTarihi, mDavaEdenCariId,
                           mDavaEdenSifat, mDavaEdenTarafKodu, mDavaEdilenCariId, mDavaEdilenSifat, mDavaEdilenTarafKodu);
            frm.MySikayet = frm.MySikayet;
            frm.FormClosed += frm_FormClosed;
            foyum = mFoy;
            sorusturmam = frm.MySikayet;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sorusturmam.ID != 0)
                SorusturmaIliskiOlustur(foyum, sorusturmam);
        }

        public static void SorusturmaUret
            (AV001_TD_BIL_HAZIRLIK mHazirlikFoy, AV001_TI_BIL_FOY mFoy, DavaTalep? mDavaTalep,
             AdliBirimBolumGorev mAdliGorev, DavaAdi? mDavaAdi,
             DateTime mOlayTarihi, int? mDavaEdenCariId,
             TarafSifat mDavaEdenSifat, TarafKodu? mDavaEdenTarafKodu, int? mDavaEdilenCariId,
             TarafSifat mDavaEdilenSifat, TarafKodu? mDavaEdilenTarafKodu)
        {
            mHazirlikFoy.Tag = "[OTO]";
            mHazirlikFoy.ADLI_BIRIM_ADLIYE_ID = mFoy.ADLI_BIRIM_ADLIYE_ID;
            mHazirlikFoy.ADLI_BIRIM_GOREV_ID = (int)mAdliGorev;
            mHazirlikFoy.SIKAYET_KONU_ID = (int?)mDavaTalep;
            mHazirlikFoy.HAZIRLIK_TARIH = DateTime.Today;
            mHazirlikFoy.SIKAYET_TARIHI = DateTime.Today;
            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN ndn =
                mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection.AddNew();

            ndn.SIKAYET_NEDEN_KOD_ID = (int?)mDavaAdi;
            ndn.OLAY_SUC_TARIHI = mOlayTarihi;
            if (mFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(mFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            foreach (AV001_TI_BIL_ALACAK_NEDEN item in mFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren,
                                                                          typeof(
                                                                              TList
                                                                              <AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK>
                                                                              ),
                                                                          typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                foreach (
                    var kiymet in
                        item.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK)
                {
                    if (kiymet.EVRAK_TUR_ID == (int)EvrakTurleri.ÇEK)
                        ndn.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SIKAYET_NEDEN_KIYMETLI_EVRAK.Add(kiymet);
                }
            }
            if (mDavaEdenCariId.HasValue)
            {
                AV001_TD_BIL_HAZIRLIK_TARAF trf = mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddNew();
                trf.SIKAYET_EDEN_MI = true;
                trf.CARI_ID = mDavaEdenCariId.Value;
                if (mDavaEdenTarafKodu.HasValue)
                    trf.TARAF_KODU = (short)mDavaEdenTarafKodu.Value;
                trf.TARAF_SIFAT_ID = (int)mDavaEdenSifat;
            }
            else
            {
                foreach (AV001_TI_BIL_FOY_TARAF icrTaraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (icrTaraf.TAKIP_EDEN_MI)
                    {
                        AV001_TD_BIL_HAZIRLIK_TARAF trf = mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddNew();
                        trf.SIKAYET_EDEN_MI = true;
                        trf.CARI_ID = icrTaraf.CARI_ID;
                        trf.TARAF_KODU = icrTaraf.TARAF_KODU;
                        trf.TARAF_SIFAT_ID = (int)mDavaEdenSifat;
                    }
                }
            }
            if (mDavaEdilenCariId.HasValue)
            {
                AV001_TD_BIL_HAZIRLIK_TARAF trf = mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddNew();
                trf.SIKAYET_EDEN_MI = false;
                trf.CARI_ID = mDavaEdilenCariId.Value;
                if (mDavaEdilenTarafKodu.HasValue)
                    trf.TARAF_KODU = (short)mDavaEdilenTarafKodu.Value;
                trf.TARAF_SIFAT_ID = (int)mDavaEdilenSifat;
            }
            else
            {
                foreach (AV001_TI_BIL_FOY_TARAF icrTaraf in mFoy.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    if (icrTaraf.TAKIP_EDEN_MI)
                    {
                        AV001_TD_BIL_HAZIRLIK_TARAF trf = mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_TARAFCollection.AddNew();
                        trf.SIKAYET_EDEN_MI = false;
                        trf.CARI_ID = icrTaraf.CARI_ID;
                        trf.TARAF_KODU = icrTaraf.TARAF_KODU;
                        trf.TARAF_SIFAT_ID = (int)mDavaEdilenSifat;
                    }
                }
            }
            foreach (AV001_TI_BIL_FOY_SORUMLU_AVUKAT sorumluAvk in mFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
            {
                AV001_TD_BIL_HAZIRLIK_SORUMLU sorumlu = mHazirlikFoy.AV001_TD_BIL_HAZIRLIK_SORUMLUCollection.AddNew();
                sorumlu.CARI_ID = sorumluAvk.SORUMLU_AVUKAT_CARI_ID;
                sorumlu.YETKILI_MI = sorumluAvk.YETKILI_MI;
            }
        }

        #endregion
    }
}