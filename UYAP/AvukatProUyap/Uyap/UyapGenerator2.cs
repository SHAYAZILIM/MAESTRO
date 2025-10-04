using AdimAdimDavaKaydi.UyapClass;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatProUyap;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AdimAdimDavaKaydi.Util.Uyap
{
    public static class Format
    {
        private static List<TDI_KOD_DOVIZ_TIP> _DovizSource;

        public static List<TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = new List<TDI_KOD_DOVIZ_TIP>(DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll());
                return _DovizSource;
            }
        }

        public static void DovizTurAd(alacakKalemKodlar kalem, int DovizId)
        {
            kalem.DovizAdi = GetDovizIdSource(DovizId).UYAP_ACIKLAMA;
            kalem.DovizTuru = GetDovizIdSource(DovizId).UYAP_KODU;
        }

        public static TDI_KOD_DOVIZ_TIP GetDovizIdSource(int id)
        {
            var dovizTip = DovizSource.Where(vi => vi.ID == id);
            return dovizTip.Count() > 0 ? dovizTip.First() : null;
        }

        public static string Para(decimal para)
        {
            return para.ToString("##############0.00");
        }

        public static string Tarih(DateTime tarih)
        {
            return tarih.ToString("dd/MM/yyyy").Replace(".", "/");
        }

        public static string Tarih(DateTime? tarih)
        {
            if (tarih.HasValue)
            {
                return Tarih(tarih.Value);
            }
            return Tarih(DateTime.Now);
        }
    }

    public class UyapGenerator
    {
        #region UyapHataKontrol Deðiþkenleri

        private List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari;
        private bool isXmlValid = true;
        private int uyariCount, hataCount;
        private XmlReader validator;

        #endregion UyapHataKontrol Deðiþkenleri

        #region XmlAndFile

        private frmHatalar hatalar = new frmHatalar();

        public bool WriteToFile(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari, string file)
        {
            try
            {
                ///GetExchangeDatas  uyap cýktýsýný alýr...
                this.IcraDosyalari = IcraDosyalari;

                if (IcraDosyalari.Count > 1)
                {
                    foreach (AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama tmp in IcraDosyalari)
                    {
                        WriteToFile(tmp, file);
                    }
                    WriteXmlToFile(GetExchangeDatas(IcraDosyalari), file, false);
                }
                else
                    WriteXmlToFile(GetExchangeDatas(IcraDosyalari), file, true);
            }
            catch
            {
                XtraMessageBox.Show("Uyap çýktýsý yazdýrýlýrken bir sorun oluþtu.", "Hata Kodu: UYPENV01");
            }
            return true;
        }

        public bool WriteToFile(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama IcraDosya, string file)
        {
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> returnValues = new List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama>();
            returnValues.Add(IcraDosya);
            return WriteToFile(returnValues, file);
        }

        public void WriteXmlToFile(object value, string file, bool check)
        {
            if (!check)
                hatalar.Show();

            MemoryStream ms = new MemoryStream();

            XmlSerializer xs = new XmlSerializer(value.GetType());

            xs.Serialize(ms, value);
            ms.Position = 0;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ms);

            XmlElement root = xmldoc.DocumentElement;

            root.RemoveAllAttributes();
            //xmldoc.GetElementById("exchangeHeader").RemoveAll();

            xmldoc.Save(file);

            ms.Close();

            if (check)
                UyapKontroluYap(file);
            else
                hatalar.XMLBastir(file);
        }

        private void UyapHataBastir(object sender, ValidationEventArgs args)
        {
            isXmlValid = false;
            if (!args.Message.Contains("zaten ID olarak kullanýlýyor."))
            {
                string error;

                ///uyarýlar
                if (IcraDosyalari[0].FOY_NO == null)
                {   //sadece Föy Numarasý olmayanlar için uyarý bastýrýlacak. Diðer ID ler þart deðil.
                    uyariCount++;
                    error = "Föy No: (bilinmiyor, lütfen güncelleyiniz. )" + args.Message;
                    error = uyariCount.ToString() + "." + error[0] + error[1].ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmp = new DevExpress.XtraNavBar.NavBarItem(error);

                    hatalar.UyariEkle(tmp);
                }//hatalar
                else
                {
                    hataCount++;
                    error = "Föy No: " + IcraDosyalari[0].FOY_NO + ". " + validator.Name + " için " + args.Message;

                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmp = new DevExpress.XtraNavBar.NavBarItem(error);
                    hatalar.HataEkle(tmp);
                }
            }
        }

        private bool UyapKontroluYap(string xmlDosyaYolu)
        {
            uyariCount = 0;
            hataCount = 0;

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(xmlDosyaYolu);
            }
            catch
            {
                string hata = "Seçilen dosya XML formatýna uygun deðildir.";
                DevExpress.XtraNavBar.NavBarItem tmp = new DevExpress.XtraNavBar.NavBarItem(hata);
                hatalar.HataEkle(tmp);
                return false;
            }
            doc.InsertBefore(doc.CreateDocumentType("exchangeData", null, Application.StartupPath + "\\exchange.dtd", null),
                    doc.DocumentElement);

            StringWriter sw = new StringWriter();
            doc.Save(sw);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            settings.IgnoreWhitespace = true;

            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(UyapHataBastir);

            validator = XmlReader.Create(new StringReader(sw.ToString()), settings);

            while (validator.Read())
            {
            }

            validator.Close();

            return isXmlValid;
        }

        #endregion XmlAndFile

        public static int UyapSiraNo { get; set; }

        public ExchangeData GetExchangeDatas(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari)
        {
            ExchangeData exchangeData = new ExchangeData();
            exchangeData.dosya = new Dosyalar();
            for (int i = 0; i < IcraDosyalari.Count; i++)
            {
                UyapSiraNo = i;
                ExchangeHeader header = new ExchangeHeader();
                header.Version = Strings.XmlHeaderVersion;
                exchangeData.ExchangeHeader = header;
                Dosya dsy = GetIcraAsDosya(IcraDosyalari[i]);

                exchangeData.dosya.Add(dsy);
            }
            return exchangeData;
        }

        #region Dosya

        private List<alacakKalemKodlar> DosyaAlacakKalemleri = new List<alacakKalemKodlar>();

        public static string GetIcraTakipTalebiFromNesne(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama foy)
        {
            string yazi = "Bu alan için Bir Deðer Bulunamadý ... ";
            decimal harcaEsasDeger = decimal.MinValue;
            double vorn = 0;
            bool kdvsiVarmi = false;
            bool oivsiVarmi = false;
            AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(foy.ID);
            DateTime tata = DateTime.Now;
            int ftid = 0;
            int dtip = 0;
            bool Dovizlimi = false;
            bool YtlLiMi = false;
            string faizLAfi = "";
            string kademeliSabitLafi = string.Empty;
            bool farkliFaziTipleriVarmi = false;
            int kdvTip = 1;

            if (foyum.TAKIP_TARIHI.HasValue)
            {
                tata = foyum.TAKIP_TARIHI.Value;
            }
            if (foyum.KDV_TO != 0)
            {
                kdvsiVarmi = true;
            }

            if (foyum.OIV_TO != 0)
            {
                oivsiVarmi = true;
            }

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, true, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenler = foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
            TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> lstGruplar = AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetAll();
            TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> kritereGoreAlacakNedenler = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();

            for (int i = 0; i < AlacakNedenler.Count; i++)
            {
                if (!AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
                    AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID = 1;

                if ((AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1) == 2)
                {
                    Dovizlimi = true;
                }
                if ((AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1) == 1)
                {
                    YtlLiMi = true;
                }
            }

            string fOran = "";

            for (int i = 0; i < AlacakNedenler.Count; i++)
            {
                if (AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.HasValue)
                {
                        fOran = AlacakNedenler[i].TO_UYGULANACAK_FAIZ_ORANI.ToString();

                    if (string.IsNullOrEmpty(kademeliSabitLafi))
                    {
                        kademeliSabitLafi = (AlacakNedenler[i].SABIT_FAIZ_UYGULA == true ? string.Empty : "kademeli olarak hesaplanacak");
                    }

                    // farklý fazi tipi varsa
                    if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID != AlacakNedenler[0].TO_ALACAK_FAIZ_TIP_ID)
                    {
                        farkliFaziTipleriVarmi = true;
                    }

                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNedenler[i], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP));
                    if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_IDSource != null)
                    {
                        faizLAfi = AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_IDSource.FAIZ_TIP;
                    }

                    harcaEsasDeger = AlacakNedenler[i].HARCA_ESAS_DEGER;

                    AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN kodAlancakNeden = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.Value);

                    if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID != null)
                    {
                        ftid = AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID.Value;
                    }

                    dtip = AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1;

                    // IcraDegiskenDegerAta("YFM", FaizHelper.FaizOraniGetir(ftid, dtip, tata));

                    if (AlacakNedenler[i].KDV_TIP_ID.HasValue)
                    {
                        kdvTip = AlacakNedenler[i].KDV_TIP_ID.Value;
                    }

                    if (kdvsiVarmi)
                    {
                        vorn = AvukatProLib.Hesap.FaizHelper.KDVOraniGetir(kdvTip, tata);
                    }
                    if (oivsiVarmi)
                    {
                        if (AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid, tata, dtip) != null)
                        {
                            vorn = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid, tata, dtip).TARIFE_TUTARI;
                        }
                    }
                }
            }
            string faizOran = fOran;
            if (fOran == string.Empty)
            {
                faizOran = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(ftid, dtip, null).ToString();
            }

            if (farkliFaziTipleriVarmi)
            {
                faizLAfi = "**, alacak nedenlerinin yanýnda yer alan faiz tiplerine göre";
                faizOran = "";
            }

            // string yazi = "";

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_NO), typeof(TDI_KOD_ADLI_BIRIM_GOREV), typeof(TDI_KOD_ADLI_BIRIM_BOLUM), typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
            AdimAdimDavaKaydi.Editor.UserControls.GrupAciklama ga = new AdimAdimDavaKaydi.Editor.UserControls.GrupAciklama();
            TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN DEG = TalepAciklamasiGetir(foyum);
            if (DEG.ID == 0)
            {
                yazi = "Her hangibir açýklama deðeri Bulunamadý";
            }
            else
            {
                yazi = DEG.ACIKLAMA;
            }

            yazi = Replace("YFM", yazi, faizOran + " " + faizLAfi + " " + kademeliSabitLafi + " ");
            if (Convert.ToInt32(vorn) != 0)
            {
                if (oivsiVarmi)
                {
                    yazi = Replace("&VERGIORN&", yazi, " %" + vorn.ToString() + " ÖÝV ");
                }
                if (kdvsiVarmi)
                {
                    yazi = Replace("&VERGIORN&", yazi, " %" + vorn.ToString() + " KDV ");
                }
            }
            else
            {
                yazi = Replace("&VERGIORN&", yazi, "");
            }
            SayiOkuma so = new SayiOkuma();

            yazi = Replace("&OIVKDV&", yazi, " OIV si ile birlikte ");
            yazi = Replace("&KDV&", yazi, " KDV si ile birlikte ");

            yazi = Replace("&GDK&", yazi, foyum.TAKIP_CIKISI_DOVIZ_ID);
            yazi = Replace("ASIL ALACAK", yazi, so.ParaFormatla(foyum.ASIL_ALACAK));
            decimal DovizKuru = AvukatProLib.Hesap.DovizHelper.CevirYTL(1, foyum.ASIL_ALACAK_DOVIZ_ID, tata);
            yazi = Replace("DÖVÝZ KURU", yazi, DovizKuru.ToString());
            yazi = Replace("HARCA ESAS DEÐER", yazi, so.ParaFormatla(harcaEsasDeger));

            //yazi= Replace("&DTC&",yazi,);
            yazi = Replace("&ATK&", yazi, so.ParaFormatla(foyum.TAKIP_CIKISI));

            if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
            {
                yazi = Replace("&ILAMACIK&", yazi, "");
            }
            else
                if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 1)
                {
                    yazi = Replace("&ILAMACIK&", yazi, foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[0].ILAM_ACIKLAMASI);
                }
                else
                {
                    string aciklama = "";

                    for (int ii = 0; ii < foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; ii++)
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii], false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADLI_BIRIM_ADLIYE), typeof(TDI_KOD_ADLI_BIRIM_GOREV), typeof(TDI_KOD_ADLI_BIRIM_NO));
                        string No = "";
                        string Adliye = "";
                        string Gorev = "";
                        if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_NO_IDSource != null)
                        {
                            No = foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_NO_IDSource.NO;
                        }
                        if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_ADLIYE_IDSource != null)
                        {
                            Adliye = foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                        }
                        if (foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_GOREV_IDSource != null)
                        {
                            Gorev = foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].ADLI_BIRIM_GOREV_IDSource.GOREV;
                        }
                        aciklama += Adliye + No + " " + Gorev + foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].KARAR_TARIHI + foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[ii].KARAR_NO + " nolu ilamý ," + Environment.NewLine;
                    }
                    yazi = Replace("&ILAMACIK&", yazi, foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[0].ILAM_ACIKLAMASI);
                }

            yazi = Replace("&FO&", yazi, AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(foy.FORM_TIP_ID.Value, dtip, tata).ToString());

            if (yazi.StartsWith(" tutarýndaki "))
                yazi = yazi.Replace(" tutarýndaki ", " ");

            return yazi;
        }

        public Dosya GetIcraAsDosya(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama IcraDosya)
        {
            // HesapYapar hy = new HesapYapar();
            //hy.IcraFoyHesapla(IcraDosya);
            DosyaOnIslemler();

            //Performans, DeepLoad'lar, föy view olduðu için kapatýldý. Merve
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(IcraDosya, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
            //    typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>),
            //    typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>)
            //    );

            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));

            //for (int i = 0; i < IcraDosya.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            //{
            //    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection[i].CARI_IDSource, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_DOVIZ_TIP), typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));
            //}

            Dosya returnValue = new Dosya();
            returnValue.id = Strings.dosyaIdPrefix + IcraDosya.ID.ToString();
            returnValue.dosyaTipi = "Genel Ýcra Dairesi";
            returnValue.dosyaTuru = 0;

            if (BelgeUtil.Inits._FormTipiGetir == null)
                BelgeUtil.Inits._FormTipiGetir = BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.Where(vi => vi.FORM_ORNEK_NO != "48").ToList();
            if (BelgeUtil.Inits._FormTipiGetir.Find(vi => vi.ID == IcraDosya.FORM_TIP_ID).ILAMLI_MI)
            {
                //ilamlý
                returnValue.takipTuru = 0;
            }
            else
            {
                //ilamsýz
                returnValue.takipTuru = 1;
            }

            // form tipine gore takip yolu
            TakipYolu[] takipYollari = new TakipYolu[]{
         new TakipYolu(true,0,"Genel Haciz Yoluyla Takip",new int[]{ 49 }),
             new TakipYolu(true,1,"IflasYoluylaTakip",   new int[] { 153,52 }),
             new TakipYolu(true,2,"RehninParayaCevrilmesiYoluylaTakip",new int[] { 152,50 }),
            new TakipYolu(true,3,"KambiyoSenetlerineMahsusHacizYolu", new int[] { 163 }),
            new TakipYolu(true,4,"KiralananGayrimenkulunIlamsizTahliyesi", new int[] { 56,51 }),
            new TakipYolu(true,5,"Diger",  new int[] { 0 }),
              new TakipYolu(false,0,"IlamlarinIcrasiParaveTeminattanBaskaBorclar" , new int[] { 54,55 }),
              new TakipYolu(false,1,"IlamlarýnIcrasiParaveTeminatVerilmesiYoluyla" ,new int[] { 53, 151 }),
              new TakipYolu(false,2,"Diger" , new int[] { 152, 50 }),
              new TakipYolu(false,3,"RehninParayaCevrilmesiYoluylaTakip" , new int[] { 201 })
};
            returnValue.takipYolu = TakipYolu.TakipYoluGetir(IcraDosya, takipYollari); ;
            returnValue.takipSekli = int.Parse(BelgeUtil.Inits._FormTipiGetir.Find(vi => vi.ID == IcraDosya.FORM_TIP_ID).UYAP_KOD);// 0; //ToDo : Burasý
                                                                                                                                   // ayarlanacak :gkn
            returnValue.alacaklininTalepEttigiHak = GetIcraTakipTalebiFromNesne(IcraDosya);
            returnValue.BK84MaddeUygulansin = (IcraDosya.TO_HESAPLAMA_TIPI == 1 ? Strings.Evet : Strings.Hayir);
            returnValue.taraflar = GetIcraTarafs(IcraDosya);
            returnValue.BSMVUygulansin = (IcraDosya.BSMV_TO == 0 ? Strings.Hayir : Strings.Evet);
            returnValue.KKDFUygulansin = (IcraDosya.KKDV_TO == 0 ? Strings.Hayir : Strings.Evet);
            returnValue.aciklama48e9 = IcraDosya.TAKIP_YOLU;
            returnValue.dosyaBelirleyicisi = String.Empty;

            //Performans, DeepLoad'lar, föy view olduðu için kapatýldý. Merve
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(IcraDosya.AV001_TI_BIL_FOY_TARAFCollection, false,
            //AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));

            returnValue.VekilKisi = getVekilKisi(IcraDosya);
            returnValue.evraklar = GetEvraklar(IcraDosya);

            if (KontratBilgisiGelsin(IcraDosya))
                returnValue.kontratKefiller = GetKontratKefils(IcraDosya);
            returnValue.Ilamlar = GetIlamlar(IcraDosya);
            returnValue.cekler = GetCek(IcraDosya);
            returnValue.senetler = GetSenet(IcraDosya);
            returnValue.policeler = GetPolice(IcraDosya);
            if (returnValue.Ilamlar.Count <= 0)
            {
                returnValue.digerAlacaklar = GetDigerAlacaklar(IcraDosya);
            }

            return returnValue;
        }

        private static string Replace(string var, string data, object newValue)
        {
            if (data == null)
            {
                return "";
            }
            if (data.Contains(var))
            {
                return data.Replace(var, newValue.ToString());
            }
            return data;
        }

        private static TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN TalepAciklamasiGetir(AV001_TI_BIL_FOY foy)
        {
            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> Degiskenler = AvukatProLib2.Data.DataRepository.
TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.GetByFORM_TIPI_ID(foy.FORM_TIP_ID.Value);
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
            AvukatProLib2.Data.DataRepository.
TDIE_KOD_TALEP_ACIKLAMA_DEGISKENProvider.DeepLoad(Degiskenler, false, DeepLoadType.IncludeChildren, typeof(TList<TI_KOD_ALACAK_NEDEN>));
            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> UyanDegiskenler = new TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN>();
            bool YtlLi = false, Dovizli = false;
            for (int i = 0; i < Degiskenler.Count; i++)
            {
                bool Uyarmi = true; // kosullara uyarmý =?
                for (int y = 0; y < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; y++)
                {
                    YtlLi = ((foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1) == 1);
                    Dovizli = ((foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1) != 1);

                    if (Degiskenler[i].FAIZ_YOK_MU == foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].FAIZ_YOK &&
                        Degiskenler[i].DOVIZ_ISLEM_TIPI == foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].HESAPLAMA_MODU &&
                        ((
                          Degiskenler[i].YTL_MI == (foy.ASIL_ALACAK_DOVIZ_ID.Value == 1) &&
                          Degiskenler[i].DOVIZLI_MI == ((foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1) != 1)
                         )
                        ||
                         (
                          Degiskenler[i].YTL_MI == true &&
                          Degiskenler[i].DOVIZLI_MI == true
                         )
                         )
                        )
                    {
                        if (Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                            Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                        {
                            for (int j = 0; j < Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count; j++)
                            {
                                if (!Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Contains(foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_IDSource))
                                {
                                    Uyarmi = false;
                                }
                            }
                        }
                        else if (Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count == 1)
                        {
                            if (Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD[0].ID != foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_ID.Value)
                            {
                                Uyarmi = false;
                            }
                        }
                        else if (!Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                       Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                        {
                            for (int j = 0; j < Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count; j++)
                            {
                                if (!Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Contains(foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].ALACAK_NEDEN_KOD_IDSource))
                                {
                                    foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Uyarmi = false;
                    }
                }

                if (!Degiskenler[i].ALACAK_NEDENLERI_VEYA_ILE_MI_BAGLI &&
                       Degiskenler[i].TI_KOD_ALACAK_NEDENCollection_From_NN_TALEP_ACIKLAMA_DEGISKEN_ALACAK_NEDEN_KOD.Count > 1)
                {
                    for (int y = 0; y < foy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; y++)
                    {
                        if (foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag != null && (bool)foy.AV001_TI_BIL_ALACAK_NEDENCollection[y].Tag == false)
                        {
                            Uyarmi = false;
                        }
                    }
                }

                if (Uyarmi)
                {
                    UyanDegiskenler.Add(Degiskenler[i]);
                }
            }

            TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN> Sonuc = new TList<TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN>();
            if (UyanDegiskenler.Count > 1)
            {
                for (int i = 0; i < UyanDegiskenler.Count; i++)
                {
                    if (UyanDegiskenler[i].YTL_MI == YtlLi || UyanDegiskenler[i].DOVIZLI_MI == Dovizli)
                    {
                        Sonuc.Add(UyanDegiskenler[i]);
                    }
                }
                if (Sonuc.Count >= 1)
                {
                    return Sonuc[0];
                }
            }
            if (UyanDegiskenler.Count >= 1)
            {
                return UyanDegiskenler[0];
            }
            return new TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN();
        }

        //her yeni doysa ya geçildiðinde yapýlacak olan iþlemler
        private void DosyaOnIslemler()
        {
            // her yeni edosyada dosya içindeki faizlerin tutuldugu diziyi sýfýrladýk ...
            faizler = new List<Faiz>();
            DosyaAlacakKalemleri = new List<alacakKalemKodlar>();
        }

        private bool KontratBilgisiGelsin(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama IcraDosya)
        {
            List<int> dizi = new List<int>();
            dizi.AddRange(new[] { 2, 7, 8, 13 }); //form tipi 50,201,151,152

            return !dizi.Contains(IcraDosya.FORM_TIP_ID.Value);
        }

        public class SayiOkuma
        {
            public SayiOkuma()
            {
                // içlerini dolduruyoruz

                yuzler.SetValue("dokuzyüz", 9);
                yuzler.SetValue("sekizyüz", 8);
                yuzler.SetValue("yediyüz", 7);
                yuzler.SetValue("altýyüz", 6);
                yuzler.SetValue("beþyüz", 5);
                yuzler.SetValue("dörtyüz", 4);
                yuzler.SetValue("üçyüz", 3);
                yuzler.SetValue("ikiyüz", 2);
                yuzler.SetValue("yüz", 1);
                yuzler.SetValue("", 0);

                onlar.SetValue("doksan", 9);
                onlar.SetValue("seksen", 8);
                onlar.SetValue("yetmiþ", 7);
                onlar.SetValue("altmýþ", 6);
                onlar.SetValue("elli", 5);
                onlar.SetValue("kýrk", 4);
                onlar.SetValue("otuz", 3);
                onlar.SetValue("yirmi", 2);
                onlar.SetValue("on", 1);
                onlar.SetValue("", 0);

                birler.SetValue("dokuz", 9);
                birler.SetValue("sekiz", 8);
                birler.SetValue("yedi", 7);
                birler.SetValue("altý", 6);
                birler.SetValue("beþ", 5);
                birler.SetValue("dört", 4);
                birler.SetValue("üç", 3);
                birler.SetValue("iki", 2);
                birler.SetValue("bir", 1);
                birler.SetValue("", 0);

                hane.SetValue("", 0);
                hane.SetValue("", 1);
                hane.SetValue("", 2);
                hane.SetValue("", 3);
                hane.SetValue("", 4);
                /*  ilk olarak bu arrayýn elemanlarýný boþ olarak ayarlýyoruz eðer küme elemanlarý
                000 deðilse trilyon,milyar,milyon bin deðerleri ile dolduruyoruz
                */
            }

            private string[] birler = new string[10];
            private string[] hane = new string[5];
            private string[] onlar = new string[10];
            private string[] rakam = new string[5];
            private string[] yuzler = new string[10];

            public string ParaFormatla(object deger)
            {
                //return string.Format("###,###,###,###,##", deger);
                decimal d = decimal.Parse(deger.ToString().Trim());
                return d.ToString("###,###,###,###,##0.00");

            }

            private string birsorunu(string sorun)
            {
                string cozum = "";
                if (sorun == "birbin ")
                    cozum = "bin ";
                else
                    cozum = sorun;
                return cozum;
            }
        }

        public class TakipYolu
        {

            public TakipYolu(bool ilamsizmi, int id, string laf, int[] ftips)
            {
                this._id = id;
                this._laf = laf;
                this._formTipleri = ftips;
                this._ilamsizmi = ilamsizmi;
            }

            private int[] _formTipleri;
            private int _id;
            private bool _ilamsizmi;
            private string _laf;

            public int[] FormTipleri
            {
                get { return _formTipleri; }
                set { _formTipleri = value; }
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public bool IlamsizMi
            {
                get { return _ilamsizmi; }
                set { _ilamsizmi = value; }
            }

            public string Laf
            {
                get { return _laf; }
                set { _laf = value; }
            }

            public static int TakipYoluGetir(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama IcraDosya, TakipYolu[] takipYollari)
            {
                if (BelgeUtil.Inits._FormTipiGetir == null)
                    BelgeUtil.Inits._FormTipiGetir = BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.Where(vi => vi.FORM_ORNEK_NO != "48").ToList();

                for (int i = 0; i < takipYollari.Length; i++)
                {
                    if (takipYollari[i]._ilamsizmi == !(BelgeUtil.Inits._FormTipiGetir.Find(vi => vi.ID == IcraDosya.FORM_TIP_ID).ILAMLI_MI))
                    {
                        for (int y = 0; y < takipYollari[i]._formTipleri.Length; y++)
                        {
                            if (IcraDosya.FORM_TIP_ID == FormTipiIdGetir(takipYollari[i]._formTipleri[y]))
                            {
                                return takipYollari[i].Id;
                            }
                        }
                    }
                }
                return 4;
            }

            private static int FormTipiIdGetir(int formTipi)
            {
                return BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.Single(vi => vi.FORM_ORNEK_NO == formTipi.ToString()).ID;
            }
        }

        #endregion Dosya

        #region Enums

        public enum AdresBilgiTipi
        {
            Il, Ilce, Adres, PostaKodu, AdresSirasi
        }

        #endregion Enums

        #region kontratBilgileri

        private int kcounter = 0;

        private List<KontratKefil> kefiller = new List<KontratKefil>();

        private int kntCounter = 0;

        private List<Kontrat> Kontratlar = new List<Kontrat>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="Sozlesme"></param>
        /// <param name="aneden"></param>
        /// <param name="gecmisGunFaiziHesaplansin">true = alacak nedenine ait faiz kalemlerini
        /// yazar false = hiç yazmaz null = föye baðlý bütün faiz kalmelerini yazar</param>
        /// <returns></returns>
        public Kontrat GetKontrat(AV001_TDI_BIL_SOZLESME Sozlesme, AV001_TI_BIL_ALACAK_NEDEN aneden, bool? gecmisGunFaiziHesaplansin)
        {
            Kontrat returnValue = new Kontrat();
            returnValue.Id = Strings.kontratIdPrefix + Sozlesme.ID.ToString();
            returnValue.aciklama = Sozlesme.ACIKLAMA;
            returnValue.adresAciklama = Sozlesme.TAHLIYE_ADRESI;
            returnValue.alacakKalemi = GetAlacakKalemleri(Sozlesme, aneden, null);
            returnValue.belgeIslemeleriBaslatiliyormu = "E"; //Belge Uyapa gönderiliyorsa zaten iþlemler baþlýyordur mantýðý güdüldü //Sozlesme.ISLEMLER_BASLADIMI ? "E" : "H"; // 'E';
            returnValue.belgeninTutari = Format.Para(Sozlesme.BEDELI);
            returnValue.gecerlilikBaslangicTarihi = Format.Tarih(Sozlesme.BASLANGIC_TARIHI);
            returnValue.gecerlilikSonlanmaTarihi = Format.Tarih(Sozlesme.BITIS_TARIHI);
            if (Sozlesme.BITIS_TARIHI.HasValue)
            {
                returnValue.gecerliOlduguSure = (Sozlesme.BITIS_TARIHI.Value - Sozlesme.BASLANGIC_TARIHI.Value).Days.ToString();
            }
            returnValue.hazirlanisTarihi = Format.Tarih(Sozlesme.BASLANGIC_TARIHI);
            returnValue.olmasiGerekenPulDegeri = Strings.OlmasiGerekenPulDegeriDefault;
            returnValue.refler = getRef(Sozlesme);
            returnValue.sozlesmeSozluBelgeli = (Sozlesme.TUR == 0 ? Strings.SozlesmeTurB : Strings.SozlesmeTurS);
            TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(Sozlesme.BEDELI_DOVIZ_ID.Value);
            returnValue.tutarTur = dovizTip.UYAP_KODU;
            returnValue.tutarTurAciklama = dovizTip.UYAP_ACIKLAMA;
            returnValue.uzerindekiPulDegeri = Strings.UzerindekiPulDegeriDefault;

            KontratIdUret(returnValue);
            return returnValue;
        }

        public List<KontratKefil> GetKontratKefils(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            List<KontratKefil> returnValues = new List<KontratKefil>();
            TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenList = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(Foyum.ID);
            for (int i = 0; i < alacakNedenList.Count; i++)
            {
                TList<AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW> lstAlacakNedenSozlesmeler = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEWProvider.GetByALACAK_NEDEN_ID(alacakNedenList[i].ID);
                TList<AV001_TDI_BIL_SOZLESME> lstSozlesmeler = new TList<AV001_TDI_BIL_SOZLESME>();
                for (int y = 0; y < lstAlacakNedenSozlesmeler.Count; y++)
                {
                    lstSozlesmeler.Add(AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(lstAlacakNedenSozlesmeler[y].SOZLESME_ID));
                }
                for (int z = 0; z < lstSozlesmeler.Count; z++)
                {
                    if (BelgeUtil.Inits._SozlesmeTaraf == null)
                        BelgeUtil.Inits._SozlesmeTaraf = BelgeUtil.Inits.context.per_AV001_TDI_BIL_SOZLESME_TARAFs.ToList();
                    var sozlesmeTaraflari = BelgeUtil.Inits._SozlesmeTaraf.FindAll(vi => vi.SOZLESME_ID == lstSozlesmeler[z].ID);
                    if (sozlesmeTaraflari.Count >= 1)
                    {
                        KontratKefil kkefil = new KontratKefil();
                        kkefil.Id = Strings.kontratKefilIdPrefix + sozlesmeTaraflari[0].ID.ToString();
                        kkefil.adres = getAdres(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sozlesmeTaraflari[0].CARI_ID.Value));
                        Kontrat kntrt = GetKontrat(lstSozlesmeler[z], alacakNedenList[i], i == 0 ? true : false);
                        kkefil.kontrat = kntrt;
                        KontratKefilIdUret(kkefil);
                        returnValues.Add(kkefil);
                    }
                }
            }
            return returnValues;
        }

        private bool KontratIdUret(Kontrat kntrt)
        {
            for (int i = 0; i < Kontratlar.Count; i++)
            {
                if (Kontratlar[i].Id == kntrt.Id)
                {
                    kntrt.Id = kntrt.Id + kntCounter.ToString();
                    kntCounter++;
                    return true;
                }
            }
            Kontratlar.Add(kntrt);
            return false;
        }

        private bool KontratKefilIdUret(KontratKefil aranan)
        {
            for (int i = 0; i < kefiller.Count; i++)
            {
                if (kefiller[i].Id == aranan.Id)
                {
                    aranan.Id = aranan.Id + kcounter.ToString();
                    kcounter++;
                    return true;
                }
            }
            kefiller.Add(aranan);
            return false;
        }

        #endregion kontratBilgileri

        #region RolBilgileri

        public RolTur getRolTur(AvukatProLib.Arama.per_AV001_TI_BIL_FOY_TARAF myTaraf)
        {
            RolTur rlTur = new RolTur();

            if (BelgeUtil.Inits._CariSifatGetir == null)
                BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
            var tarafSifat = BelgeUtil.Inits._CariSifatGetir.Single(vi => vi.ID == myTaraf.TARAF_SIFAT_ID);
            rlTur.rolID = tarafSifat.UYAP_KOD;
            rlTur.Rol = tarafSifat.UYAP_ACIKLAMA;
            return rlTur;
        }
                
        #endregion RolBilgileri

        #region TarafIslemleri

        public List<Taraf> GetIcraTarafs(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama IcraDosya)
        {
            List<Taraf> returnValues = new List<Taraf>();
            if (BelgeUtil.Inits._FoyTarafGetir == null)
            {
                BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();
            }
            foreach (var taraf in BelgeUtil.Inits._FoyTarafGetir.FindAll(vi => vi.ICRA_FOY_ID == IcraDosya.ID))
            {
                var curentTaraf = taraf;
                Taraf myTaraf = new Taraf();
                myTaraf.id = Strings.icraDosyaTarafIdPrefix + taraf.CARI_ID.ToString();

                KisiKurumBilgileri kurumbilgisi = new KisiKurumBilgileri();
                kurumbilgisi.ad = taraf.AD;
                kurumbilgisi.id = Strings.kisiKurumIdPrefix + taraf.CARI_ID;

                AV001_TDI_BIL_CARI tarafCari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value);
                if (taraf.CARI_ID.HasValue)
                    kurumbilgisi.adres = getAdres(tarafCari);//Tablodan Çekmesine bakýlacak. Merve

                if (BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Single(vi => vi.ID == taraf.CARI_ID).FIRMA_MI)
                {
                    kurumbilgisi.kurum = GetKurumBilgisi(tarafCari);
                }
                else
                {
                    kurumbilgisi.kisiTumBilgileri = getKisiTumBilgileri(tarafCari);
                }

                myTaraf.kisiKurumBilgileri = kurumbilgisi;

                myTaraf.rolTur = getRolTur(taraf);

                if (curentTaraf.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                {
                    if (BelgeUtil.Inits._DosyaSorumluAvukatGetir == null)
                        BelgeUtil.Inits._DosyaSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.ToList();

                    foreach (var sorumlu in BelgeUtil.Inits._DosyaSorumluAvukatGetir.FindAll(vi => vi.ICRA_FOY_ID == IcraDosya.ID))
                    {
                        if (!sorumlu.YETKILI_MI)
                        {
                            if (myTaraf.refler == null) myTaraf.refler = new List<Ref>();
                            try
                            {
                                myTaraf.refler.Add(new Ref() { to = "VekilKisi", id = Strings.vekilKisiIdPrefix + sorumlu.SORUMLU_AVUKAT_CARI_ID.ToString() });
                            }
                            catch
                            {
                                throw new Exception("Sorumlu Avukat Seçilmemiþ...");
                            }
                        }
                    }
                }
                else
                {
                    TList<AV001_TI_BIL_FOY_TARAF_VEKIL> vekiller = DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_ID(taraf.ID);
                    foreach (var tVekil in vekiller)
                    {
                        if (myTaraf.refler == null) myTaraf.refler = new List<Ref>();

                        myTaraf.refler.Add(new Ref() { to = "VekilKisi", id = Strings.vekilKisiIdPrefix + tVekil.ID.ToString() });
                    }
                }
                returnValues.Add(myTaraf);
            }
            return returnValues;
        }
        
        private KisiTumBilgileri getKisiTumBilgileri(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
        {
            if (cari == null)
            {
                return null;
            }

            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
            if (cari.AV001_TDI_BIL_CARI_KIMLIKCollection != null && cari.AV001_TDI_BIL_CARI_KIMLIKCollection.Count > 0)
            {
                KisiTumBilgileri bilgiler = getKisiTumBilgileri(cari.AV001_TDI_BIL_CARI_KIMLIKCollection[0]);
                return bilgiler;
            }
            else
            {
                return getKisiTumBilgiler(cari);
            }
        }

        private Kurum GetKurumBilgisi(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
        {
            if (cari.FIRMA_MI)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, DeepLoadType.IncludeChildren, typeof(TDI_KOD_ILCE));
                Kurum donecek = new Kurum();
                donecek.vergiNo = cari.VERGI_NO;
                donecek.vergiDairesi = cari.VERGI_DAIRESI;
                donecek.id = Strings.kisiTumBilgileriIdPrefix + cari.ID.ToString();
                donecek.kamuOzel = (cari.KAMU_CARI_MI == true ? "K" : "O");
                donecek.kurumAdi = cari.AD;
                donecek.ticariSicilNo = cari.SICIL_NO;
                donecek.sskIsyeriSicilNo = cari.SG_NO;
                if (cari.TICARI_SICIL_YERI_ID.HasValue)
                {
                    donecek.ticaretSicilNoVerildigiYer = string.Format("{0}-{1}", cari.TICARI_SICIL_YERI_IDSource.IL, cari.TICARI_SICIL_YERI_IDSource.ILCE);
                }
                else
                {
                    donecek.ticaretSicilNoVerildigiYer = "";
                }
                donecek.harcDurumu = cari.HARCDAN_MUAF_MI ? "1" : "0";

                return donecek;
            }
            return null;
        }

        #endregion TarafIslemleri

        #region CariBilgileri

        private Adres getAdres(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim)
        {
            if (carim == null)
            {
                return null;
            }
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(carim, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_ADRES_TUR), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            Adres adres = new Adres();
            adres.adres = GetAdresBilgi(carim, AdresBilgiTipi.Adres).ToString();
            if (carim.ADRES_TUR_IDSource != null)
            {
                //TODO: uygulamaya açýldý // eski programda yok
                adres.adresTuru = carim.ADRES_TUR_IDSource.UYAP_KOD;
                adres.adresTuruAciklama = carim.ADRES_TUR_IDSource.UYAP_ACIKLAMA;
            }
            else
            { }

            adres.cepTelefon = carim.CEP_TEL;
            adres.elektronikPostaAdresi = carim.EMAIL_1;
            adres.fax = carim.FAX;
            adres.id = Strings.adresIdPrefix + carim.ID.ToString() + GetAdresBilgi(carim, AdresBilgiTipi.AdresSirasi).ToString();
            TDI_KOD_ILCE ilce = ((TDI_KOD_ILCE)GetAdresBilgi(carim, AdresBilgiTipi.Ilce));
            TDI_KOD_IL il = ((TDI_KOD_IL)GetAdresBilgi(carim, AdresBilgiTipi.Il));
            if (il != null)
            {
                adres.il = il.IL;
                adres.ilKodu = il.PLAKA_NO;
            }
            if (ilce != null)
            {
                adres.ilce = ilce.ILCE;
                adres.ilceKodu = ilce.KOD;
            }

            adres.postaKodu = GetAdresBilgi(carim, AdresBilgiTipi.PostaKodu).ToString();
            adres.telefon = carim.TEL_1;

            return adres;
        }

        private object GetAdresBilgi(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim, AdresBilgiTipi tip)
        {
            if (carim.AKTIF_ADRES)
            {
                switch (tip)
                {
                    case AdresBilgiTipi.Il:
                        return carim.IL_IDSource;

                    case AdresBilgiTipi.Ilce:
                        return carim.ILCE_IDSource;

                    case AdresBilgiTipi.Adres:
                        return carim.ADRES_1;

                    case AdresBilgiTipi.PostaKodu:
                        return carim.POSTA_KODU;

                    case AdresBilgiTipi.AdresSirasi:
                        return 1;

                    default:
                        break;
                }
            }
            if (carim.AKTIF_ADRES_2)
            {
                switch (tip)
                {
                    case AdresBilgiTipi.Il:
                        return carim.IL2_IDSource;

                    case AdresBilgiTipi.Ilce:
                        return carim.ILCE2_IDSource;

                    case AdresBilgiTipi.Adres:
                        return carim.ADRES_2;

                    case AdresBilgiTipi.PostaKodu:
                        return carim.POSTA_KODU2;

                    case AdresBilgiTipi.AdresSirasi:
                        return 2;

                    default:
                        break;
                }
            }

            if (carim.AKTIF_ADRES_3)
            {
                switch (tip)
                {
                    case AdresBilgiTipi.Il:
                        return carim.IL3_IDSource;

                    case AdresBilgiTipi.Ilce:
                        return carim.ILCE3_IDSource;

                    case AdresBilgiTipi.Adres:
                        return carim.ADRES_3;

                    case AdresBilgiTipi.PostaKodu:
                        return carim.POSTA_KODU3;

                    case AdresBilgiTipi.AdresSirasi:
                        return 3;

                    default:
                        break;
                }
            }
            return 0;
        }

        private string[] GetAdSoyadFromCari(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim)
        {
            //string returnValue = "";
            string[] strArray = carim.AD.Split(' ');
            string ad = string.Empty;
            string soyad = string.Empty;

            for (int i = 0; i < strArray.Length - 1; i++)
            {
                ad += strArray[i];
            }
            soyad = strArray[strArray.Length - 1];

            return new string[] { ad, soyad };
        }

        private KisiTumBilgileri getKisiTumBilgiler(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
        {
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI),
                typeof(TDI_KOD_CINSIYET), typeof(TDI_KOD_KIMLIK_VERILIS_NEDEN), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            KisiTumBilgileri kisiTumBilgisi = new KisiTumBilgileri();

            string[] adSoyad = GetAdSoyadFromCari(cari);

            kisiTumBilgisi.id = Strings.kisiTumBilgileriIdPrefix + cari.ID.ToString();
            kisiTumBilgisi.adi = adSoyad[0];
            kisiTumBilgisi.soyadi = adSoyad[1];

            // kisiTumBilgisi.cinsiyeti = Strings.CinsiyetErkek;//(cari.CINSIYET_IDSource.ID == 1 ?
            // "E" : "K");
            kisiTumBilgisi.vergiNo = cari.VERGI_NO;
            kisiTumBilgisi.tcKimlikNo = cari.VERGI_NO; //kimlik.TC_KIMLIK_NO;
            kisiTumBilgisi.oncekiSoyadi = "";//kimlik.ONCEKI_SOYADI;
            kisiTumBilgisi.aileSiraNo = "";//kimlik.NKO_AILE_SIRA_NO;
            kisiTumBilgisi.anaAdi = "";//kimlik.ANA_ADI;
            kisiTumBilgisi.babaAdi = "";// kimlik.BABA_ADI;
            kisiTumBilgisi.ciltNo = "";//kimlik.NKO_CILT_NO;
            kisiTumBilgisi.cinsiyeti = "";//(kimlik.CINSIYET_ID.Value == 1 ? Strings.CinsiyetErkek : Strings.CinsiyetBayan);
            kisiTumBilgisi.cuzdanNo = "";//kimlik.CUZDANIN_KAYIT_NO;
            kisiTumBilgisi.cuzdanSeriNo = "";// kimlik.CUZDANIN_KAYIT_NO;
            kisiTumBilgisi.dogumYeri = "";//kimlik.DOGUM_YERI;
            kisiTumBilgisi.kayitNo = "";//kimlik.CUZDANIN_KAYIT_NO; // kontrol
            kisiTumBilgisi.mahKoy = "";//kimlik.NKO_MAHALLE_KOY;
            kisiTumBilgisi.nufusaKayitIlceKodu = "";//kimlik.NKO_ILCE_IDSource.KOD; // Kod
            kisiTumBilgisi.nufusaKayitIlKodu = "";// kimlik.NKO_IL_IDSource.PLAKA_NO;//Kod
            kisiTumBilgisi.siraNo = "";//kimlik.NKO_SIRA_NO;
            kisiTumBilgisi.tcKimlikNo = "";//kimlik.TC_KIMLIK_NO;
            kisiTumBilgisi.verildigiIlAdi = "";// kimlik.CUZDANIN_VERILDIGI_YER;//Kontrol
            kisiTumBilgisi.verildigiIlceAdi = "";// kimlik.IL; // Kontrol
            kisiTumBilgisi.verildigiIlceKodu = "";//kimlik.ILCE; //Kontrol
            kisiTumBilgisi.verildigiIlKodu = "";//kimlik.NKO_CILT_NO; //Kontrol
            kisiTumBilgisi.verildigiTarih = "";//
                                               // Format.Tarih(kimlik.CUZDANIN_VERILIS_TARIHI);//Kontrol
            kisiTumBilgisi.verilisNedeni = "";// kimlik.CUZDANIN_VERILME_NEDENI_IDSource.UYAP_KOD;
            kisiTumBilgisi.ybnNfsKayitliOldgYer = "";//Kontrol

            return kisiTumBilgisi;
        }

        private KisiTumBilgileri getKisiTumBilgileri(AvukatProLib2.Entities.AV001_TDI_BIL_CARI_KIMLIK kimlik)
        {
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.DeepLoad(kimlik, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI),
                typeof(TDI_KOD_CINSIYET), typeof(TDI_KOD_KIMLIK_VERILIS_NEDEN), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            KisiTumBilgileri kisiTumBilgisi = new KisiTumBilgileri();

            string[] adSoyad = GetAdSoyadFromCari(kimlik.CARI_IDSource);

            kisiTumBilgisi.id = Strings.kisiTumBilgileriIdPrefix + kimlik.CARI_ID.Value.ToString();

            kisiTumBilgisi.adi = adSoyad[0];
            kisiTumBilgisi.soyadi = adSoyad[1];
            kisiTumBilgisi.oncekiSoyadi = kimlik.ONCEKI_SOYADI;
            kisiTumBilgisi.aileSiraNo = kimlik.NKO_AILE_SIRA_NO;
            kisiTumBilgisi.anaAdi = kimlik.ANA_ADI;
            kisiTumBilgisi.babaAdi = kimlik.BABA_ADI;
            kisiTumBilgisi.ciltNo = kimlik.NKO_CILT_NO;
            if (kimlik.CINSIYET_ID.HasValue)
            {
                kisiTumBilgisi.cinsiyeti = (kimlik.CINSIYET_ID.Value == 2 ? Strings.CinsiyetErkek : Strings.CinsiyetBayan);
            }
            else
            {
                kisiTumBilgisi.cinsiyeti = "";
            }

            kisiTumBilgisi.cuzdanNo = kimlik.CUZDANIN_KAYIT_NO;
            kisiTumBilgisi.cuzdanSeriNo = kimlik.CUZDANIN_KAYIT_NO;
            if (kimlik.DOGUM_TARIHI.HasValue)
            {
                kisiTumBilgisi.dogumTarihi = Format.Tarih(kimlik.DOGUM_TARIHI);
            }

            kisiTumBilgisi.dogumYeri = kimlik.DOGUM_YERI;
            kisiTumBilgisi.kayitNo = kimlik.CUZDANIN_KAYIT_NO; // kontrol
            kisiTumBilgisi.mahKoy = kimlik.NKO_MAHALLE_KOY;
            if (kimlik.NKO_ILCE_IDSource != null)
            {
                kisiTumBilgisi.nufusaKayitIlceKodu = kimlik.NKO_ILCE_IDSource.KOD; // Kod
            }
            if (kimlik.NKO_IL_IDSource != null)
            {
                kisiTumBilgisi.nufusaKayitIlKodu = kimlik.NKO_IL_IDSource.PLAKA_NO;//Kod
            }

            kisiTumBilgisi.siraNo = kimlik.NKO_SIRA_NO;
            kisiTumBilgisi.tcKimlikNo = kimlik.TC_KIMLIK_NO;
            kisiTumBilgisi.vergiNo = kimlik.CARI_IDSource.VERGI_NO;
            kisiTumBilgisi.verildigiIlAdi = kimlik.CUZDANIN_VERILDIGI_YER;//Kontrol
            kisiTumBilgisi.verildigiIlceAdi = kimlik.IL; // Kontrol
            kisiTumBilgisi.verildigiIlceKodu = kimlik.ILCE; //Kontrol
            kisiTumBilgisi.verildigiIlKodu = kimlik.NKO_CILT_NO; //Kontrol
            if (kimlik.CUZDANIN_VERILIS_TARIHI.HasValue)
            {
                kisiTumBilgisi.verildigiTarih = Format.Tarih(kimlik.CUZDANIN_VERILIS_TARIHI);//Kontrol
            }
            if (kimlik.CUZDANIN_VERILME_NEDENI_IDSource != null)
            {
                kisiTumBilgisi.verilisNedeni = kimlik.CUZDANIN_VERILME_NEDENI_IDSource.UYAP_KOD;
            }

            kisiTumBilgisi.ybnNfsKayitliOldgYer = "";//Kontrol

            return kisiTumBilgisi;
        }

        #endregion CariBilgileri

        #region VekilIslemleri

        private Vekil getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL vekil)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(vekil, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY_TARAF));
            Vekil vkl = new Vekil();
            string[] adSoyad = GetAdSoyadFromCari(vekil.AVUKAT_CARI_IDSource);
            vkl.adi = adSoyad[0];
            vkl.soyadi = adSoyad[1];
            vkl.avukatlikBuroAdi = vekil.AVUKAT_CARI_IDSource.UNVAN;

            //todo: eski programda yok
            //vkl.bakanlikDosyaNo = "";
            vkl.baroNo = vekil.AVUKAT_CARI_IDSource.BARO_SICIL_NO;
            vkl.borcluVekilMi = (vekil.FOY_TARAF_IDSource.TAKIP_EDEN_MI == true ? Strings.Hayir : Strings.Evet);
            vkl.id = Strings.vekilIdPrefix + vekil.ID.ToString();

            // vkl.kapanmaNedeni = ' ';
            vkl.kurumAvikatiMi = (vekil.AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI == true ? Strings.Evet : Strings.Hayir);
            vkl.sigortaliMi = (vekil.AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU == true ? Strings.Evet : Strings.Hayir);
            vkl.tbbNo = vekil.AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO;
            vkl.tcKimlikNo = vekil.AVUKAT_CARI_IDSource.VERGI_NO;

            vkl.vekilTipi = "B";// TODO :
                                // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString();
                                // // TODO: KOD;

            return vkl;
        }

        private Vekil getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT vekil)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(vekil, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY_TARAF));
            Vekil vkl = new Vekil();
            string[] adSoyad = GetAdSoyadFromCari(vekil.SORUMLU_AVUKAT_CARI_IDSource);
            vkl.adi = adSoyad[0];
            string adSoyadi = "";
            for (int i = 1; i < adSoyad.Length; i++)
            {
                adSoyadi += adSoyad[i];
            }
            vkl.soyadi = adSoyadi;
            vkl.avukatlikBuroAdi = vekil.SORUMLU_AVUKAT_CARI_IDSource.UNVAN;

            //todo : eski programda yok
            // vkl.bakanlikDosyaNo = "";
            vkl.baroNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.BARO_SICIL_NO;

            #region <GKN-20090629>

            //Ters Mantýk kurulmuþtu düzeltildi
            vkl.borcluVekilMi = (TakipEdenAvukatimi(vekil) ? Strings.Hayir : Strings.Evet);

            #endregion <GKN-20090629>

            vkl.id = Strings.vekilIdPrefix + vekil.ID.ToString();
            vkl.kapanmaNedeni = "0";
            vkl.kurumAvikatiMi = (vekil.SORUMLU_AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI == true ? Strings.Evet : Strings.Hayir);
            vkl.sigortaliMi = (vekil.SORUMLU_AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU == true ? Strings.Evet : Strings.Hayir);
            vkl.tbbNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO;
            vkl.tcKimlikNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.VERGI_NO;
            vkl.vergiNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.VERGI_NO;
            vkl.vekilTipi = Strings.VekilTipiB;// TODO :
                                               // taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString();
                                               // // TODO: KOD;
            return vkl;
        }

        private List<VekilKisi> getVekilKisi(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL> tarafVekils)
        {
            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(tarafVekils, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

            for (int i = 0; i < tarafVekils.Count; i++)
            {
                if (tarafVekils[i].AVUKAT_CARI_IDSource != null)
                {
                    VekilKisi vekilKisisi = new VekilKisi();

                    vekilKisisi.adres = getAdres(tarafVekils[i].AVUKAT_CARI_IDSource);
                    vekilKisisi.id = Strings.vekilKisiIdPrefix + tarafVekils[i].ID.ToString();

                    AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(tarafVekils[i].AVUKAT_CARI_IDSource, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    if (tarafVekils[i].AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count >= 1)
                    {
                        vekilKisisi.kisiTumBilgileri = getKisiTumBilgileri(tarafVekils[i].AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0]);
                    }
                    else
                    {
                        vekilKisisi.kisiTumBilgileri = getKisiTumBilgileri(tarafVekils[i].AVUKAT_CARI_IDSource);
                    }
                    vekilKisisi.vekil = getVekil(tarafVekils[i]);
                    lstVekilKisi.Add(vekilKisisi);
                }
            }
            return lstVekilKisi;
        }

        private List<VekilKisi> getVekilKisi(AV001_TI_BIL_FOY_SORUMLU_AVUKAT carim)
        {
            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            VekilKisi vekilKisisi = new VekilKisi();

            if (carim.SORUMLU_AVUKAT_CARI_IDSource == null)
                DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(carim, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
            vekilKisisi.adres = getAdres(carim.SORUMLU_AVUKAT_CARI_IDSource);
            vekilKisisi.id = Strings.vekilKisiIdPrefix + carim.SORUMLU_AVUKAT_CARI_ID.ToString();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(carim.SORUMLU_AVUKAT_CARI_IDSource, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
            if (carim.SORUMLU_AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection.Count >= 1)
            {
                vekilKisisi.kisiTumBilgileri = getKisiTumBilgileri(carim.SORUMLU_AVUKAT_CARI_IDSource.AV001_TDI_BIL_CARI_KIMLIKCollection[0]);
            }
            else
            {
                vekilKisisi.kisiTumBilgileri = getKisiTumBilgileri(carim.SORUMLU_AVUKAT_CARI_IDSource);
            }
            vekilKisisi.vekil = getVekil(carim);
            lstVekilKisi.Add(vekilKisisi);

            return lstVekilKisi;
        }

        private List<VekilKisi> getVekilKisi(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            TList<AV001_TDI_BIL_CARI> VekilCarileri = new TList<AV001_TDI_BIL_CARI>();
            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            TList<AV001_TI_BIL_FOY_TARAF_VEKIL> lstVekils = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            #region Taraflarýn vekillerinde dönüp listelere ekliyoruz

            if (BelgeUtil.Inits._FoyTarafGetir == null)
                BelgeUtil.Inits._FoyTarafGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.ToList();

            foreach (var taraf in BelgeUtil.Inits._FoyTarafGetir.FindAll(vi => vi.ICRA_FOY_ID == Foyum.ID))
            {
                foreach (var vekil in DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(taraf.ID))
                {
                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(vekil, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                    //Avukat bilgileri dolu ise
                    if (vekil.AVUKAT_CARI_IDSource != null)
                    {
                        //Vekil listesine daha önce eklenmemiþ ise
                        if (!IsInVekilCollection(lstVekils, vekil))
                        {
                            //Cari Listesine daha önce eklenmemiþ ise
                            if (!IsInCariCollection(VekilCarileri, vekil.AVUKAT_CARI_IDSource))
                            {
                                //Her iki listeye de ekliyoruz..
                                lstVekils.Add(vekil);
                                VekilCarileri.Add(vekil.AVUKAT_CARI_IDSource);
                            }
                        }
                    }
                }
            }

            #endregion Taraflarýn vekillerinde dönüp listelere ekliyoruz

            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> SorumluAvukatlar = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();

            #region Sorumlarda dönüp listeye ekliyoruz

            if (BelgeUtil.Inits._DosyaSorumluAvukatGetir == null)
                BelgeUtil.Inits._DosyaSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.ToList();

            foreach (var sorumlu in BelgeUtil.Inits._DosyaSorumluAvukatGetir.FindAll(vi => vi.ICRA_FOY_ID == Foyum.ID))
            {
                //Vekil listesine eklenmemiþ ise listelere ekliyeceðiz
                var sorumluCari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumlu.SORUMLU_AVUKAT_CARI_ID.Value);
                if (!IsInCariCollection(VekilCarileri, sorumluCari))
                {
                    SorumluAvukatlar.Add(DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByID(sorumlu.ID));
                    VekilCarileri.Add(sorumluCari);
                }
            }

            #endregion Sorumlarda dönüp listeye ekliyoruz

            if (SorumluAvukatlar.Count > 0)
            {
                for (int z = 0; z < SorumluAvukatlar.Count; z++)
                {
                    lstVekilKisi.AddRange(getVekilKisi(SorumluAvukatlar[z]));
                }
            }

            if (lstVekils.Count > 0)
            {
                lstVekilKisi.AddRange(getVekilKisi(lstVekils));
            }

            return lstVekilKisi;
        }

        private bool IsInCariCollection(TList<AV001_TDI_BIL_CARI> cariler, AV001_TDI_BIL_CARI cari)
        {
            for (int i = 0; i < cariler.Count; i++)
            {
                if (cariler[i].ID == cari.ID)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsInVekilCollection(TList<AV001_TI_BIL_FOY_TARAF_VEKIL> lstVekils, AV001_TI_BIL_FOY_TARAF_VEKIL vekil)
        {
            for (int i = 0; i < lstVekils.Count; i++)
            {
                if (lstVekils[i].ID == vekil.ID)
                {
                    return true;
                }
            }
            return false;
        }

        private bool TakipEdenAvukatimi(AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT vekil)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(vekil, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(vekil.ICRA_FOY_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));
            for (int i = 0; i < vekil.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
            {
                if (vekil.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection[i].TARAF_KODU == 1 && vekil.ICRA_FOY_IDSource.AV001_TI_BIL_FOY_TARAFCollection[i].TAKIP_EDEN_MI)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion VekilIslemleri

        #region AlacakKalemi Bilgileri

        public enum AlacakKalemTipi
        {
            DigerAlacak, Kontrat, Hicbiri
        }

        public List<AlacakKalemi> GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TI_BIL_ILAM_MAHKEMESI ilam)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(ilam, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY));
            AV001_TI_BIL_FOY myFoy = null;
            if (ilam.ICRA_FOY_ID.HasValue)
            {
                myFoy = ilam.ICRA_FOY_IDSource;
            }

            List<AlacakKalemi> returnValues = new List<AlacakKalemi>();

            List<AlacakKalemi> AlacakKalem = null;// GetAlacakKalemi(null, AlacakKalemTipi.Hicbiri,
                                                  // ilam);

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                AlacakKalem = GetAlacakKalemi(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i], myFoy, AlacakKalemTipi.Hicbiri, ilam, i == 0 ? true : false);
                if (AlacakKalem != null)
                {
                    returnValues.AddRange(AlacakKalem);
                }
            }

            if (returnValues.Count <= 0)
            {
                returnValues = null;
            }
            return returnValues;
        }

        public List<AlacakKalemi> GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK evrak)
        {
            List<AlacakKalemi> returnValues = new List<AlacakKalemi>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(evrak, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            TList<AV001_TI_BIL_ALACAK_NEDEN> lstAlacakNeden = evrak.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK;
            var icraFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(lstAlacakNeden[0].ICRA_FOY_ID.Value);
            for (int i = 0; i < lstAlacakNeden.Count; i++)
            {
                List<AlacakKalemi> AlacakKalem = GetAlacakKalemi(lstAlacakNeden[i], icraFoy, AlacakKalemTipi.Hicbiri, null, i == 0 ? true : false);
                if (AlacakKalem != null)
                {
                    returnValues.AddRange(AlacakKalem);
                }
            }
            return returnValues;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sozlesme"></param>
        /// <param name="aneden</param><param name="gecmisGunFaiziHesaplansin"> true = alacak nedenine ait faiz kalemlerini yazar false = hiç yazmaz null = föye baðlý bütün faiz kalmelerini yazar </param> <returns></returns>
        public List<AlacakKalemi> GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME sozlesme, AV001_TI_BIL_ALACAK_NEDEN aneden, bool? gecmisGunFaiziHesaplansin)
        {
            List<AlacakKalemi> returnValues = new List<AlacakKalemi>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            List<AlacakKalemi> AlacakKalem = GetAlacakKalemi(aneden, DataRepository.AV001_TI_BIL_FOYProvider.GetByID(aneden.ICRA_FOY_ID.Value), AlacakKalemTipi.Kontrat, null, gecmisGunFaiziHesaplansin);
            if (AlacakKalem != null)
            {
                returnValues.AddRange(AlacakKalem);
            }
            return returnValues;
        }

        public List<DigerAlacak> GetDigerAlacaklar(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foy)
        {
            List<DigerAlacak> returnValues = new List<DigerAlacak>();
            int[] DigerAlacaklar = new int[] {
                    53,  85,64,65, 66,  67,  68,  69,   70, 71,  72, 73, 74, 75, 76, 55, 54,
            };
            int i = 0;
            var aNedenList = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(Foy.ID);
            foreach (var aNeden in aNedenList)
            {
                if (AlacakKalemiVarmi(aNeden))
                {
                    continue;
                }
                DigerAlacak dAlacak = new DigerAlacak();

                returnValues.Add(dAlacak);
                dAlacak.alacakKalemi = new List<AlacakKalemi>();
                if (aNeden.ALACAK_NEDEN_KOD_ID.HasValue)
                {
                    List<AlacakKalemi> kalemler = GetAlacakKalemi(aNeden, DataRepository.AV001_TI_BIL_FOYProvider.GetByID(aNeden.ICRA_FOY_ID.Value), AlacakKalemTipi.DigerAlacak, null, i == 0 ? true : false);
                    if (kalemler != null)
                    {
                        dAlacak.alacakKalemi.AddRange(kalemler);
                    }

                    dAlacak.alacakNo = "";
                    dAlacak.digerAlacakAciklama = aNeden.DIGER_ALACAK_NEDENI;
                    dAlacak.Id = "digerAlacak_" + aNeden.ID.ToString();
                    dAlacak.tarih = Format.Tarih(aNeden.KAYIT_TARIHI);
                    dAlacak.tutar = aNeden.TUTARI.ToString();

                    if (aNeden.TUTAR_DOVIZ_ID.HasValue)
                    {
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(aNeden.TUTAR_DOVIZ_ID.Value);
                        dAlacak.tutarAdi = dovizTip.UYAP_ACIKLAMA;
                        dAlacak.tutarTur = dovizTip.UYAP_KODU;
                    }
                }
                i++;
            }
            if (returnValues.Count == 0)
            {
                return null;
            }
            return returnValues;
        }

        private bool AlacakKalemiKontrol(string kalem, alacakKalemKodlar akkod)
        {
            for (int i = 0; i < DosyaAlacakKalemleri.Count; i++)
            {
                if (DosyaAlacakKalemleri[i].IlamID == akkod.IlamID && DosyaAlacakKalemleri[i].FoyID == akkod.FoyID && DosyaAlacakKalemleri[i].AlacakKalemID == akkod.AlacakKalemID && DosyaAlacakKalemleri[i].Id == akkod.Id)
                {
                    return false;
                }
            }
            DosyaAlacakKalemleri.Add(akkod);
            return true;
        }

        private bool AlacakKalemiVarmi(AV001_TI_BIL_ALACAK_NEDEN akalem)
        {
            for (int i = 0; i < DosyaAlacakKalemleri.Count; i++)
            {
                if (DosyaAlacakKalemleri[i].AlacakKalemID == akalem.ID)
                {
                    return true;
                }
            }
            return false;
        }

        private List<alacakKalemKodlar> GetAlacakKalemAdi(AV001_TI_BIL_ALACAK_NEDEN aneden, AlacakKalemTipi kalemTipi, AV001_TI_BIL_FOY iFoy, AV001_TI_BIL_ILAM_MAHKEMESI ilam, bool? gecmisGunFaiziEkle)
        {
            if (aneden != null)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aneden, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));
            }

            List<alacakKalemKodlar> returnValues = new List<alacakKalemKodlar>();

            int alacakKalemIdCounter = 0;
            if (aneden != null)
            {
                alacakKalemIdCounter = 0;

                #region ASIL ALACAK

                //Asýl Alacak
                if (aneden.ISLEME_KONAN_TUTAR != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.AsilAlacakKalemKod;
                    akkod.alacakKalemKodAciklama = Strings.AsilAlacak;
                    akkod.alacakKalemKodTip = Strings.AsilAlacakKalemKodTipi;
                    akkod.alacakKalemKodTuru = Strings.AsilAlacakKalemKodTuru;
                    akkod.ilamliIlamsiz = Strings.AsilAlacakIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.ISLEME_KONAN_TUTAR);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1);

                    returnValues.Add(akkod);
                }

                #endregion ASIL ALACAK

                #region PROTESTO MASRAFI

                //protesto masrafý
                if (decimal.Zero != aneden.PROTESTO_GIDERI)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.ProtestoMasrafiKalemKod;
                    akkod.alacakKalemKodAciklama = Strings.ProtestoMasrafi;
                    akkod.alacakKalemKodTip = Strings.ProtestoMasrafiKodTipi;
                    akkod.alacakKalemKodTuru = Strings.ProtestoMasrafiKodTuru;
                    akkod.ilamliIlamsiz = Strings.ProtestoMasrafiIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.PROTESTO_GIDERI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.PROTESTO_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion PROTESTO MASRAFI

                #region KOMÝSYON

                //komisyon
                if (aneden.KOMISYONU != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.KomisyonKod;
                    akkod.alacakKalemKodAciklama = Strings.Komisyon;
                    akkod.alacakKalemKodTip = Strings.KomisyonKodTip;
                    akkod.alacakKalemKodTuru = Strings.KomisyonKodTur;
                    akkod.ilamliIlamsiz = Strings.KomisyonIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.KOMISYONU);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.KOMISYONU_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion KOMÝSYON

                #region ÇEK TAZMÝNATI

                //çek tazminatý
                if (aneden.CEK_TAZMINATI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.CekTazminatiKod;
                    akkod.alacakKalemKodAciklama = Strings.CekTazminati;
                    akkod.alacakKalemKodTip = Strings.CekTazminatiKodTipi;
                    akkod.alacakKalemKodTuru = Strings.CekTazminatiKodTuru;
                    akkod.ilamliIlamsiz = Strings.CekTazminatiIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.CEK_TAZMINATI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.CEK_TAZMINATI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÇEK TAZMÝNATI

                #region ÝHTAR GÝDERÝ

                //yeni alacak kalemi *IHTAR_GIDERI
                if (aneden.IHTAR_GIDERI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.YeniAlacakKalemiKod;
                    akkod.alacakKalemKodAciklama = Strings.YeniAlacakKalemi;
                    akkod.alacakKalemKodTip = Strings.YeniAlacakKalemiKodTipi;
                    akkod.alacakKalemKodTuru = Strings.YeniAlacakKalemiKodTuru;
                    akkod.ilamliIlamsiz = Strings.YeniAlacakKalemiIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.IHTAR_GIDERI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.IHTAR_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝHTAR GÝDERÝ

                #region BSMV TUTARI

                //bsmv
                if (aneden.BSMV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.BSMVKod;
                    akkod.alacakKalemKodAciklama = Strings.BSMV;
                    akkod.alacakKalemKodTip = Strings.BSMVKodTipi;
                    akkod.alacakKalemKodTuru = Strings.BSMVKodTuru;
                    akkod.ilamliIlamsiz = Strings.BSMVIlam;
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.BSMV_TUTARI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.BSMV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }

                #endregion BSMV TUTARI

                #region KKDF

                //kkdf
                if (aneden.KKDV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7179";
                    akkod.alacakKalemKodAciklama = "KKDF";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "0";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.KKDV_TUTARI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.KKDV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }

                #endregion KKDF

                #region KDV

                //kdv
                if (aneden.KDV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7180";
                    akkod.alacakKalemKodAciklama = "KDV";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "0";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.KDV_TUTARI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.KDV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }

                #endregion KDV

                #region GEÇMÝÞ GÜN FAÝZÝ

                if (true)//(gecmisGunFaiziEkle)
                {
                    //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(iFoy, false, DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>) , typeof(TList<AV001_TI_BIL_FAIZ>));
                    var paraListesi = new List<AvukatProLib.Hesap.ParaVeDovizId>();
                    List<AV001_TI_BIL_FAIZ> faizler = new List<AV001_TI_BIL_FAIZ>();

                    //foreach (var aNeden in iFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    //{
                    //    foreach (var faiz in aNeden.AV001_TI_BIL_FAIZCollection)
                    //    {
                    //        if (faiz.FAIZ_TAKIPDEN_ONCE_MI == 1 && !faiz.ALACAK_NEDEN_TARAF_ID.HasValue)
                    //        {
                    //            faizler.Add(faiz);
                    //        }
                    //    }
                    //}
                    faizler.Clear();

                    //geçmiþ gün faizi null ise alacak nedeninin
                    if (!gecmisGunFaiziEkle.HasValue)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aneden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));

                        foreach (var faiz in aneden.AV001_TI_BIL_FAIZCollection)
                        {
                            if (faiz.FAIZ_TAKIPDEN_ONCE_MI == 1 && !faiz.ALACAK_NEDEN_TARAF_ID.HasValue)
                                faizler.Add(faiz);
                        }
                    }
                    else if (gecmisGunFaiziEkle.HasValue && gecmisGunFaiziEkle.Value) // true ise tüm
                                                                                      // alacak
                                                                                      // nedenlerinin
                                                                                      // altlarýndaki
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(iFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TI_BIL_FAIZ>));
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(iFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));

                        foreach (var aNeden in iFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                        {
                            foreach (var faiz in aNeden.AV001_TI_BIL_FAIZCollection)
                            {
                                if (faiz.FAIZ_TAKIPDEN_ONCE_MI == 1 && !faiz.ALACAK_NEDEN_TARAF_ID.HasValue)
                                {
                                    faizler.Add(faiz);
                                }
                            }
                        }
                    }

                    for (int i = 0; i < faizler.Count; i++)
                    {
                        //kontrol listeye eklenirken yapýldý
                        if (true)//(faizler[i].FAIZ_TAKIPDEN_ONCE_MI == 1 && !faizler[i].ALACAK_NEDEN_TARAF_ID.HasValue)
                        {
                            //faizToplami += faizler[i].FAIZ_TUTARI;
                            //faizDovizId = faizler[i].FAIZ_TUTARI_DOVIZ_ID.Value;
                            paraListesi.Add(new AvukatProLib.Hesap.ParaVeDovizId(faizler[i].FAIZ_TUTARI, faizler[i].FAIZ_TUTARI_DOVIZ_ID));
                        }
                    }
                    var toplamPara = AvukatProLib.Hesap.ParaVeDovizId.Topla(paraListesi);

                    //Geçmiþ Gün Faizi
                    if (faizler.Count > 0 && toplamPara.Para > decimal.Zero)
                    {
                        alacakKalemKodlar akkod = new alacakKalemKodlar();
                        akkod.alacakKalemKod = "7183";
                        akkod.alacakKalemKodAciklama = "Geçmiþ Gün Faizi";
                        akkod.alacakKalemKodTip = "0";
                        akkod.alacakKalemKodTuru = "2";
                        akkod.ilamliIlamsiz = "1";
                        akkod.Id = alacakKalemIdCounter;
                        akkod.AlacakKalemID = aneden.ID;
                        alacakKalemIdCounter++;

                        //kalemin miktarýný para formatý ile verdik
                        akkod.Miktar = Format.Para(Decimal.Round(toplamPara.Para, 2));

                        //Doviz turunu ve acýklamasýný yazýyoruz
                        Format.DovizTurAd(akkod, toplamPara.DovizId);
                        returnValues.Add(akkod);
                    }
                }

                #endregion GEÇMÝÞ GÜN FAÝZÝ

                #region GECÝKME ZAMMI

                //gecikme zammý
                if (aneden.TAZMINATI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7184";
                    akkod.alacakKalemKodAciklama = "Gecikme Zammý";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "0";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(aneden.TAZMINATI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, aneden.TAZMINATI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }
            }

                #endregion GECÝKME ZAMMI

            if (ilam != null)
            {
                #region ÝLAM

                alacakKalemIdCounter = 0;

                #region ÝLAM ÝNKAR TAZMÝNATI

                //yeni alacak kalemi *ILAM_INKAR_TAZMINATI
                if (ilam.INKAR_TAZMINATI.HasValue && ilam.INKAR_TAZMINATI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    akkod.IlamID = ilam.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.INKAR_TAZMINATI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.INKAR_TAZMINATI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝLAM ÝNKAR TAZMÝNATI

                #region ÝLAM YARGILAMA GÝDERÝ

                //yeni alacak kalemi *ILAM_YARGILAMA_GIDERI
                if (ilam.YARGILAMA_GIDERI.HasValue && ilam.YARGILAMA_GIDERI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    akkod.IlamID = ilam.ID;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.YARGILAMA_GIDERI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.YARGILAMA_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝLAM YARGILAMA GÝDERÝ

                #region ÝLAM VEKALET ÜCRETÝ

                //yeni alacak kalemi *ILAM_VEK_UCR
                if (ilam.ILAM_VEKALET_UCRETI.HasValue && ilam.ILAM_VEKALET_UCRETI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.ILAM_VEKALET_UCRETI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝLAM VEKALET ÜCRETÝ

                #region ÝLAM BAKÝYE YARGI ONAMA

                //yeni alacak kalemi *ILAM_BK_YARG_ONAMA
                if (ilam.YARGITAY_ONAMA_HARCI.HasValue && ilam.YARGITAY_ONAMA_HARCI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.YARGITAY_ONAMA_HARCI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝLAM BAKÝYE YARGI ONAMA

                #region BAKÝYE KARAR HARCI

                if (ilam.BAKIYE_KARAR_HARCI.HasValue && ilam.BAKIYE_KARAR_HARCI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.BAKIYE_KARAR_HARCI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion BAKÝYE KARAR HARCI

                #region ÝLAM TEBLÝÐ GÝDERÝ

                //yeni alacak kalemi *ILAM_TEBLIG_GIDERI
                if (ilam.ILAM_TEBLIG_GIDERI.HasValue && ilam.ILAM_TEBLIG_GIDERI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(ilam.ILAM_TEBLIG_GIDERI.Value);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝLAM TEBLÝÐ GÝDERÝ

                #region COMMENT

                //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(iFoy,false, DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_FAIZ>));

                //decimal ilamFaizToplami = decimal.Zero;
                //int inlamFaizid = 1;
                //TList<AV001_TI_BIL_FAIZ> ilamFaizleri = iFoy.AV001_TI_BIL_FAIZCollection;
                //for (int i = 0; i < ilamFaizleri.Count; i++)
                //{
                //    if (ilamFaizleri[i].FAIZ_TAKIPDEN_ONCE_MI == 1)
                //    {
                //        ilamFaizToplami += ilamFaizleri[i].FAIZ_TUTARI;
                //        inlamFaizid = ilamFaizleri[i].FAIZ_TUTARI_DOVIZ_ID.Value;
                //    }
                //}

                ////Geçmiþ Gün Faizi
                //if (ilamFaizToplami != decimal.Zero)
                //{
                //    alacakKalemKodlar akkod = new alacakKalemKodlar();
                //    akkod.alacakKalemKod = "7183";
                //    akkod.alacakKalemKodAciklama = "Geçmiþ Gün Faizi";
                //    akkod.alacakKalemKodTip = "0";
                //    akkod.alacakKalemKodTuru = "2";
                //    akkod.ilamliIlamsiz = "1";
                //    akkod.Id = alacakKalemIdCounter;
                //    akkod.IlamID = ilam.ID;
                //    alacakKalemIdCounter++;

                // //kalemin miktarýný para formatý ile verdik akkod.Miktar =
                // Format.Para(ilamFaizToplami); //Doviz turunu ve acýklamasýný yazýyoruz
                // Format.DovizTurAd(akkod, inlamFaizid); returnValues.Add(akkod);
                //}

                #endregion COMMENT

                #endregion ÝLAM
            }

            if (iFoy != null)
            {
                #region ÝH VEKALET ÜCRETÝ

                //yeni alacak kalemi *IH_VEKALET_UCRETI
                if (iFoy.IH_VEKALET_UCRETI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.IH_VEKALET_UCRETI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.IH_VEKALET_UCRETI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝH VEKALET ÜCRETÝ

                #region ÝH GÝDERÝ

                //yeni alacak kalemi *IH_GIDERI
                if (iFoy.IH_GIDERI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.IH_GIDERI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.IH_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝH GÝDERÝ

                #region ÝT HACÝZDEN ÖDENEN

                //yeni alacak kalemi *IT_HACIZDE_ODENEN
                if (iFoy.IT_HACIZDE_ODENEN != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.IT_HACIZDE_ODENEN);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.IT_HACIZDE_ODENEN_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÝT HACÝZDEN ÖDENEN

                #region ÖZEL TUTAR 1

                //yeni alacak kalemi *OZEL_TUTAR1
                if (iFoy.OZEL_TUTAR1 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.OZEL_TUTAR1);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR1_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÖZEL TUTAR 1

                #region ÖZEL TUTAR 2

                //yeni alacak kalemi *OZEL_TUTAR2
                if (iFoy.OZEL_TUTAR2 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.OZEL_TUTAR2);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR2_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÖZEL TUTAR 2

                #region ÖZEL TUTAR 3

                if (iFoy.OZEL_TUTAR3 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.OZEL_TUTAR3);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR3_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion ÖZEL TUTAR 3

                #region MAHSUP TOPLAMI

                //yeni alacak kalemi *MAHSUP_TOPLAMI
                if (iFoy.MAHSUP_TOPLAMI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.MAHSUP_TOPLAMI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.MAHSUP_TOPLAMI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion MAHSUP TOPLAMI

                #region TÖ ÖDEME TOPLAMI

                if (iFoy.TO_ODEME_TOPLAMI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi";
                    akkod.alacakKalemKodTip = "0";
                    akkod.alacakKalemKodTuru = "1";
                    akkod.ilamliIlamsiz = "1";
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;

                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.Para(iFoy.TO_ODEME_TOPLAMI);

                    //Doviz turunu ve acýklamasýný yazýyoruz
                    Format.DovizTurAd(akkod, iFoy.TO_ODEME_TOPLAMI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion TÖ ÖDEME TOPLAMI
            }
            return returnValues;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="aneden"></param>
        /// <param name="kalemTipi"></param>
        /// <param name="ilam"></param>
        /// <param name="gecmisGunFaiziHesaplansin">< true = alacak nedenine ait faiz kalemlerini yazar false = hiç yazmaz null = föye baðlý bütün faiz kalmelerini yazar /param>
        /// <returns></returns>
        private List<AlacakKalemi> GetAlacakKalemi(AV001_TI_BIL_ALACAK_NEDEN aneden, AV001_TI_BIL_FOY icraFoy, AlacakKalemTipi kalemTipi, AV001_TI_BIL_ILAM_MAHKEMESI ilam, bool? gecmisGunFaiziHesaplansin)
        {
            List<alacakKalemKodlar> kalemKodlar = new List<alacakKalemKodlar>();
            if (aneden != null)
            {
                kalemKodlar = GetAlacakKalemAdi(aneden, kalemTipi, icraFoy, ilam, gecmisGunFaiziHesaplansin);
            }
            else
            {
                kalemKodlar = GetAlacakKalemAdi(aneden, kalemTipi, null, ilam, gecmisGunFaiziHesaplansin);
            }
            aneden.ICRA_FOY_IDSource = icraFoy;
            List<AlacakKalemi> kalemleri = GetKalem(kalemKodlar, kalemTipi, aneden);

            if (kalemleri != null && kalemleri.Count > 0)
            {
                return kalemleri;
            }

            return null;
        }

        private List<AlacakKalemi> GetKalem(List<alacakKalemKodlar> kalemler, AlacakKalemTipi kalemtipi, AV001_TI_BIL_ALACAK_NEDEN aneden)
        {
            if (aneden != null)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aneden, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
            }

            List<AlacakKalemi> returnValues = new List<AlacakKalemi>();

            for (int i = 0; i < kalemler.Count; i++)
            {
                //TODO : Alacak kalem için bir tip kontrolu yapýyoruz. Bu kontrolu yaparken ilam içrisinden ilamla baghlý olanlarý aldýgýmýzdan hepsi dolmamakta.
                // Diger alkacak kalemleride eski p*rogramdaki gibi ilamla birlikte gelmeli

                AlacakKalemi AlacakKalem = new AlacakKalemi();
                if (AlacakKalemiKontrol((aneden.ID.ToString()), kalemler[i]))
                {
                    AlacakKalem.Id = ("alacakKalem_" + aneden.ID + i).ToString();

                    // AlacakKalem.akdiFaiz = //aneden.TO_UYGULANACAK_FAIZ_ORANI.ToString();
                    AlacakKalem.alacakKalemAdi = kalemler[i].alacakKalemKodAciklama;
                    if (AlacakKalem.alacakKalemAdi != "Geçmiþ Gün Faizi")
                        AlacakKalem.aciklama = aneden.ALACAK_NEDEN_KOD_IDSource.ALACAK_NEDENI;

                    //todo : eski programda yok.
                    //AlacakKalem.alacakKalemIlkTutar = Format.Para(aneden.ISLEME_KONAN_TUTAR);
                    AlacakKalem.alacakKalemKod = kalemler[i].alacakKalemKod;

                    // AlacakKalem.alacakKalemKodAciklama = "";
                    AlacakKalem.alacakKalemKodTuru = kalemler[i].alacakKalemKodTuru;

                    //AlacakKalem.alacakKalemTip = kalemler[i].alacakKalemKodTip;
                    //  AlacakKalem.alacakKalemTutar=lstAlacakNeden[i].K;
                    //AlacakKalem.dovizKurCevrimi =/;

                    //AlacakKalem.sabitTaksitTarihi = DateTime.Now;//=aneden.VADE_TARIHI.Value.tos.sa;
                    AlacakKalem.alacakKalemTutar = kalemler[i].Miktar.ToString();
                    AlacakKalem.tutarAdi = kalemler[i].DovizAdi;
                    AlacakKalem.tutarTur = kalemler[i].DovizTuru.Trim();
                    if (AlacakKalem.alacakKalemAdi != "Geçmiþ Gün Faizi")
                    {
                        AlacakKalem.faizler = GetFaiz(aneden);
                    }

                    AlacakKalem.refler = getRef(aneden);

                    ///Alacak kalemkod turu
                    ///0 masraf alacagý
                    ///1 Asýl Alacak
                    ///2 faiz alacaðý
                    ///Alacak kalemi Diger alacak kalemleri altýundays ...
                    ///Alacak kalemi Bir kontrat altýndaysa ....

                    #region MASRAF ALACAÐI

                    if (kalemler[i].alacakKalemKodTuru == "0")
                    {
                        switch (kalemtipi)
                        {
                            case AlacakKalemTipi.DigerAlacak:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Diðer Masraf Alacaðý";
                                AlacakKalem.alacakKalemKod = "5";
                                AlacakKalem.aciklama = "Diðer Masraf Alacaðý";
                                break;

                            case AlacakKalemTipi.Kontrat:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Kontrat Masraf Alacaðý";
                                AlacakKalem.alacakKalemKod = "8";
                                AlacakKalem.aciklama = "Kontrat Masraf Alacaðý";
                                break;

                            case AlacakKalemTipi.Hicbiri:
                                break;

                            default:
                                break;
                        }
                    }

                    #endregion MASRAF ALACAÐI

                    #region ASIL ALACAK

                    if (kalemler[i].alacakKalemKodTuru == "1")
                    {
                        switch (kalemtipi)
                        {
                            case AlacakKalemTipi.DigerAlacak:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Diðer Asýl Alacaðý";
                                AlacakKalem.alacakKalemKod = "3";
                                AlacakKalem.aciklama = "Diðer Asýl Alacaðý";
                                break;

                            case AlacakKalemTipi.Kontrat:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Kontrat Asýl Alacaðý";
                                AlacakKalem.alacakKalemKod = "2";
                                AlacakKalem.aciklama = "Kontrat Asýl Alacaðý";
                                break;

                            case AlacakKalemTipi.Hicbiri:
                                break;

                            default:
                                break;
                        }
                    }

                    #endregion ASIL ALACAK

                    #region FAÝZ ALACAÐI

                    if (kalemler[i].alacakKalemKodTuru == "2")
                    {
                        switch (kalemtipi)
                        {
                            case AlacakKalemTipi.DigerAlacak:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Diðer Faiz Alacaðý";
                                AlacakKalem.alacakKalemKod = "6";
                                AlacakKalem.aciklama = "Diðer Faiz Alacaðý";
                                break;

                            case AlacakKalemTipi.Kontrat:
                                AlacakKalem.aciklama = kalemler[i].alacakKalemKodAciklama;
                                AlacakKalem.alacakKalemAdi = "Kontrat Faiz Alacaðý";
                                AlacakKalem.alacakKalemKod = "9";
                                AlacakKalem.aciklama = "Kontrat Faiz Alacaðý";
                                break;

                            case AlacakKalemTipi.Hicbiri:
                                break;

                            default:
                                break;
                        }
                    }

                    #endregion FAÝZ ALACAÐI

                    returnValues.Add(AlacakKalem);
                }
            }
            return returnValues;
        }

        #endregion AlacakKalemi Bilgileri

        #region Faiz bilgileri

        //dosyadaki tum faizler burada tutulur. Her dosya deðiþtiðinde bu list new olur...
        private List<Faiz> faizler = new List<Faiz>();


        //
        public List<Faiz> GetFaiz(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN AlacakNeden)
        {
            List<Faiz> returnValue = new List<Faiz>();

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNeden, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(AlacakNeden.ICRA_FOY_IDSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));

            for (int i = 0; i < AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection.Count; i++)
            {
                Faiz fz = new Faiz();
                if (AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TAKIPDEN_ONCE_MI == 1)
                {
                    if (AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.HasValue)
                    {
                        fz.baslangicTarihi = Format.Tarih(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.Value);
                    }
                    if (AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.HasValue)
                    {
                        fz.bitisTarihi = Format.Tarih(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.Value);
                    }

                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FAIZProvider.DeepLoad(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DOVIZ_TIP));

                    fz.faizOran = Format.Para(Convert.ToDecimal(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_ORANI));
                    fz.faizSureTip = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_KOD;
                    fz.faizTipKodAciklama = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_ACIKLAMA;
                    fz.faizTutar = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI;
                    fz.faizTutarTur = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_KODU; // TODO:
                    fz.faizTutarTurAdi = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_ACIKLAMA; // TODO :
                    fz.Id = "faiz_" + AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].ID.ToString();

                    //faiz daha once dosyaya eklenmediyse ekliyoruz. Bunuda faizler adýndaki dizimizden kontrol ediyoruz.
                    if (!FaizlerdeVarmi(fz))
                    {
                        returnValue.Add(fz);
                        faizler.Add(fz);
                    }
                }
            }

            for (int i = 0; i < AlacakNeden.AV001_TI_BIL_FAIZCollection.Count; i++)
            {
                Faiz fz = new Faiz();
                if (AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TAKIPDEN_ONCE_MI == 1)
                {
                    if (AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.HasValue)
                    {
                        fz.baslangicTarihi = Format.Tarih(AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BASLANGIC_TARIHI.Value);
                    }
                    if (AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.HasValue)
                    {
                        fz.bitisTarihi = Format.Tarih(AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_BITIS_TARIHI.Value);
                    }

                    AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FAIZProvider.DeepLoad(AlacakNeden.AV001_TI_BIL_FAIZCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_FAIZ_TIP), typeof(TDI_KOD_DOVIZ_TIP));

                    fz.faizOran = Format.Para(Convert.ToDecimal(AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_ORANI));
                    fz.faizSureTip = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_KOD;
                    fz.faizTipKodAciklama = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_ACIKLAMA;
                    fz.faizTutar = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI;
                    fz.faizTutarTur = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_KODU; // TODO:
                    fz.faizTutarTurAdi = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_ACIKLAMA; // TODO :
                    fz.Id = "faiz_" + AlacakNeden.AV001_TI_BIL_FAIZCollection[i].ID.ToString();

                    //faiz daha once dosyaya eklenmediyse ekliyoruz. Bunuda faizler adýndaki dizimizden kontrol ediyoruz.
                    if (!FaizlerdeVarmi(fz))
                    {
                        returnValue.Add(fz);
                        faizler.Add(fz);
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// ayný fazin iki kez yazýlmamasý için burada tum sistemdeki faizleri tutuyorz ve boylece
        /// bir faiz bir kere yzýlmasý için kontrol yapýyoruz
        /// </summary>
        /// <param name="myFaiz">aranan faiz</param>
        /// <returns>sonuc varsa evet yoksa hayýr</returns>
        private bool FaizlerdeVarmi(Faiz myFaiz)
        {
            for (int i = 0; i < faizler.Count; i++)
            {
                if (faizler[i].Id == myFaiz.Id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion Faiz bilgileri

        #region REf

        public List<Ref> getRef(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN AlacakNeden)
        {
            List<Ref> returnValue = new List<Ref>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNeden, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
            for (int i = 0; i < AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count; i++)
            {
                Ref rf = new Ref();
                rf.to = "taraf";
                rf.id = Strings.taraf + AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_ID.ToString();
                returnValue.Add(rf);
            }
            return returnValue;
        }

        public List<Ref> getRef(AvukatProLib2.Entities.AV001_TDI_BIL_KIYMETLI_EVRAK KiymetliEvrak)
        {
            List<Ref> returnValue = new List<Ref>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(KiymetliEvrak, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
            for (int i = 0; i < KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count; i++)
            {
                Ref rf = new Ref();
                rf.to = "taraf";
                rf.id = Strings.taraf + KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[i].TARAF_CARI_ID.ToString();
                returnValue.Add(rf);
            }
            return returnValue;
        }

        public List<Ref> getRef(AvukatProLib2.Entities.AV001_TDI_BIL_SOZLESME Sozlesme)
        {
            List<Ref> returnValue = new List<Ref>();
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(Sozlesme, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME_TARAF>));
            for (int i = 0; i < Sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection.Count; i++)
            {
                Ref rf = new Ref();
                rf.to = "taraf";
                rf.id = Strings.taraf + Sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.ToString();
                returnValue.Add(rf);
            }
            return returnValue;
        }

        #endregion REf

        #region Kiymetli Evrak

        public List<Cek> GetCek(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            List<Cek> returnValues = new List<Cek>();

            foreach (var alacakNeden in BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == Foyum.ID))
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByALACAK_NEDEN_IDFromAV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK(alacakNeden.ALACAK_NEDEN_ID);

                AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(lstKiymetliEvraks, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TDI_KOD_BANKA), typeof(TDI_KOD_BANKA_SUBE), typeof(TDI_KOD_DOVIZ_TIP), typeof(TDI_KOD_BANKA), typeof(TDI_KOD_BANKA_SUBE));

                for (int y = 0; y < lstKiymetliEvraks.Count; y++)
                {
                    if (lstKiymetliEvraks[y].EVRAK_TUR_ID == 1)
                    {
                        Cek ck = new Cek();
                        if (lstKiymetliEvraks[y].BANKA_ID.HasValue)
                        {
                            if (BelgeUtil.Inits._BankaGetir == null)
                                BelgeUtil.Inits._BankaGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BANKAProvider.GetAll();
                            ck.bankaAdi = BelgeUtil.Inits._BankaGetir.Single(vi => vi.ID == lstKiymetliEvraks[y].BANKA_ID).BANKA;
                            ck.bankaID = "banka_" + lstKiymetliEvraks[y].BANKA_ID.ToString();
                        }
                        if (true)
                        {
                        }
                        if (lstKiymetliEvraks[y].SUBE_ID.HasValue)
                        {
                            if (BelgeUtil.Inits._BankaSubeGetirDetay == null)
                                BelgeUtil.Inits._BankaSubeGetirDetay = BelgeUtil.Inits.context.VDI_KOD_BANKA_SUBE_Detays.ToList();
                            var sube = BelgeUtil.Inits._BankaSubeGetirDetay.Single(vi => vi.ID == lstKiymetliEvraks[y].SUBE_ID.Value);
                            ck.bankaSubeAdi = sube.SUBE;
                            ck.bankaSubeAdres = sube.ADRES;
                            ck.bankaSubeIl = sube.IL;
                            ck.bankaSubeIlce = sube.ILCE;
                            ck.bankaSubeKod = sube.KODU;
                        }

                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            ck.ibrazTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI);
                        }
                        ck.Id = "cek_" + lstKiymetliEvraks[y].ID.ToString();
                        ck.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? "E" : "H");
                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            ck.kesideTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI);
                        }

                        ck.kesideYeri = lstKiymetliEvraks[y].KESIDE_YERI;
                        ck.kocanNo = GetSadeceSayilar(lstKiymetliEvraks[y].CEK_NO); // TODO :
                        ck.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI;
                        ck.seriNo = GetSadeceSayilar(lstKiymetliEvraks[y].HESAP_NO);  // TODO :
                        ck.tutar = Format.Para(lstKiymetliEvraks[y].TUTAR);
                        TDI_KOD_DOVIZ_TIP doviztip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        ck.tutarTur = doviztip.UYAP_KODU;   // TODO :
                        ck.tutarTurAciklama = doviztip.UYAP_ACIKLAMA; // TODO :

                        ck.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

                        returnValues.Add(ck);
                    }
                }
            }
            return returnValues;
        }

        public List<Evrak> GetEvraklar(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            List<Evrak> returnValues = new List<Evrak>();
            TList<AV001_TDIE_BIL_BELGE> list = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByICRA_FOY_IDFromNN_BELGE_ICRA(Foyum.ID);

            foreach (var item in list)
            {
                var dosyaAdi = item.DOSYA_ADI;
                var icerik = item.ICERIK;

                if (icerik != null)
                    returnValues.Add(GetEvrak(dosyaAdi, icerik));
            }
            return returnValues;
        }

        public List<Ilam> GetIlamlar(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foy)
        {
            List<Ilam> returnValues = new List<Ilam>();
            AV001_TI_BIL_FOY Foyum = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Foy.ID);

            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foyum, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));

            for (int i = 0; i < Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren,
                    typeof(TDI_KOD_ADLI_BIRIM_ADLIYE),
                    typeof(TDI_KOD_ADLI_BIRIM_GOREV),
                    typeof(TDI_KOD_ADLI_BIRIM_NO),
                    typeof(TDI_KOD_ILAM_BELGE_TUR),
                    typeof(AV001_TI_BIL_DAVA_OZET)
                    );
                if (string.IsNullOrEmpty(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ESAS_NO))
                {
                    Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ESAS_NO = "I-" + DateTime.Now.Year.ToString() + "~" + "0";
                }
                string[] ilamDosyaEsas = Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ESAS_NO.Split('~');
                string[] ilamKarar = Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_NO.Split('~');
                Ilam ilm = new Ilam();
                ilm.id = "ilam_" + Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ID.ToString();
                string[] DosyaSiraDosyaNo = null;
                string[] DosyaKararNo = null;
                ilm.kesifTarihi = "";

                #region DosyaEsasNo

                if (ilamDosyaEsas.Length > 1)
                {
                    if (ilamDosyaEsas[0].Contains("/"))
                    {
                        DosyaSiraDosyaNo = ilamDosyaEsas[0].Split('/');
                    }
                }
                else if (ilamDosyaEsas.Length == 1)
                {
                    DosyaSiraDosyaNo = ilamDosyaEsas[0].Split('/');
                }

                if (DosyaSiraDosyaNo != null && DosyaSiraDosyaNo.Length > 1)
                {
                    ilm.ilamDosyaNoYil = DosyaSiraDosyaNo[0];
                    ilm.ilamDosyaSira = DosyaSiraDosyaNo[1];
                }
                else
                {
                    ilm.ilamDosyaNoYil = DateTime.Now.Year.ToString();
                    ilm.ilamDosyaSira = "1";
                }

                #endregion DosyaEsasNo

                #region ilamKararNo

                if (ilamKarar.Length > 1)
                {
                    if (ilamKarar[0].Contains("/"))
                    {
                        DosyaKararNo = ilamKarar[0].Split('/');
                    }
                }
                else if (ilamKarar.Length == 1)
                {
                    if (ilamKarar[0].Contains("/"))
                    {
                        DosyaKararNo = ilamKarar[0].Split('/');
                    }
                }

                if (DosyaKararNo != null && DosyaKararNo.Length > 1)
                {
                    ilm.ilamKararNoYil = DosyaKararNo[0];
                    ilm.ilamKararSira = DosyaKararNo[1];
                }
                else
                {
                    ilm.ilamKararNoYil = DateTime.Now.Year.ToString();
                    ilm.ilamKararSira = "1";
                }

                #endregion ilamKararNo

                string Mahkemesi = "";

                Mahkemesi += Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_ADLIYE_IDSource != null)
                {
                    Mahkemesi += " ";
                }

                Mahkemesi += Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_GOREV_IDSource.GOREV;
                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_GOREV_IDSource != null)
                {
                    Mahkemesi += " ";
                }

                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_NO_ID.HasValue)
                {
                    Mahkemesi += Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ADLI_BIRIM_NO_IDSource.NO;
                }

                ilm.ilamKurumAd = Mahkemesi;
                ilm.ilamiVerenMahkeme = Mahkemesi;

                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_TARIHI.HasValue)
                {
                    ilm.ilamTarihi = Format.Tarih(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_TARIHI);
                }

                ilm.ilamKurumTip = Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_TIP_IDSource.UYAP_KOD;

                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_KESINLESME_TARIHI.HasValue)
                {
                    ilm.kesinlesmeTarih = Format.Tarih(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].KARAR_KESINLESME_TARIHI);
                }

                ilm.davaAcilisTarihi = "";
                if (Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].DAVA_OZET_FOY_ID.HasValue)
                {
                    ilm.davaAcilisTarihi = Format.Tarih(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].DAVA_OZET_FOY_IDSource.DAVA_TARIHI);
                }

                ilm.ilamAciklama = Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i].ILAM_ACIKLAMASI;
                ilm.alacakKalemi = GetAlacakKalemleri(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i]);
                returnValues.Add(ilm);
            }
            return returnValues;
        }

        public List<Police> GetPolice(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            List<Police> returnValues = new List<Police>();

            foreach (var alacakNeden in BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == Foyum.ID))
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByALACAK_NEDEN_IDFromAV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK(alacakNeden.ALACAK_NEDEN_ID);

                for (int y = 0; y < lstKiymetliEvraks.Count; y++)
                {
                    if (lstKiymetliEvraks[y].EVRAK_TUR_ID == 3)
                    {
                        Police pol = new Police();
                        pol.belgeninTutari = Format.Para(lstKiymetliEvraks[y].TUTAR);
                        pol.Id = "police_" + lstKiymetliEvraks[y].ID.ToString();
                        pol.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? "E" : "H");

                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            pol.kesideTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.Value);
                        }
                        pol.kesideYeri = lstKiymetliEvraks[y].KESIDE_YERI;
                        bool KesideComma = false;
                        bool LehtarComma = false;

                        //bool OdeyecekComma = false;
                        for (int z = 0; z < lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection.Count; z++)
                        {
                            if (lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_TIP_ID == 5)
                            {
                                LehtarComma = true;
                                pol.lehtarAdSoyad += lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_CARI_IDSource.AD + ",";
                            }
                            if (lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_TIP_ID == 2)
                            {
                                KesideComma = true;
                                pol.kesideciAdSoyad += lstKiymetliEvraks[y].AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[z].TARAF_CARI_IDSource.AD + ",";
                            }

                            if (LehtarComma)
                            {
                                pol.lehtarAdSoyad = pol.lehtarAdSoyad.Remove(pol.lehtarAdSoyad.Length - 1, 1);
                            }

                            if (KesideComma)
                            {
                                pol.kesideciAdSoyad = pol.kesideciAdSoyad.Remove(pol.kesideciAdSoyad.Length - 1, 1);
                            }
                        }
                        if (lstKiymetliEvraks[y].BANKA_ID.HasValue)
                        {
                            if (BelgeUtil.Inits._BankaGetir == null)
                                BelgeUtil.Inits._BankaGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BANKAProvider.GetAll();
                            pol.odeyecekKisiAdSoyad += BelgeUtil.Inits._BankaGetir.Single(vi => vi.ID == lstKiymetliEvraks[y].BANKA_ID).BANKA;
                        }
                        pol.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI;
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        pol.tutarAdi = dovizTip.UYAP_ACIKLAMA;
                        pol.tutarTur = dovizTip.UYAP_KODU; // TODO :
                        pol.uzerindekiPulunDegeri = alacakNeden.DAMGA_PULU.ToString(); // TODO :
                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            pol.vadeTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI);
                        }
                        pol.refler = getRef(lstKiymetliEvraks[y]);
                        pol.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);
                        returnValues.Add(pol);
                    }
                }
            }
            return returnValues;
        }

        /// <summary>
        /// verilen dizideki sadece sayýlarý döndürür Z12423-1 => 124231
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public string GetSadeceSayilar(string st)
        {
            Regex reg = new Regex("[0-9]");
            string sonuc = "";

            foreach (Match item in reg.Matches(st))
            {
                sonuc += item.Value;
            }
            return sonuc;
        }

        public List<Senet> GetSenet(AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama Foyum)
        {
            List<Senet> returnValues = new List<Senet>();

            foreach (var alacakNeden in BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(vi => vi.ICRA_FOY_ID == Foyum.ID))
            {
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> lstKiymetliEvraks = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByALACAK_NEDEN_IDFromAV001_TI_BIL_ALACAK_NEDEN_KIYMETLI_EVRAK(alacakNeden.ALACAK_NEDEN_ID);

                for (int y = 0; y < lstKiymetliEvraks.Count; y++)
                {
                    if (lstKiymetliEvraks[y].EVRAK_TUR_ID == 2)
                    {
                        Senet sen = new Senet();
                        sen.belgeninTutari = Format.Para(lstKiymetliEvraks[y].TUTAR);
                        sen.Id = "sen_" + lstKiymetliEvraks[y].ID.ToString();
                        sen.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? "E" : "H");
                        sen.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI;
                        sen.olmasiGrknPulDegeri = "";
                        if (lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI.HasValue)
                        {
                            sen.tanzimTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI);
                        }

                        sen.tanzimYeri = lstKiymetliEvraks[y].KESIDE_YERI;
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        sen.tutarAdi = dovizTip.UYAP_ACIKLAMA; // TODO :
                        sen.tutarTur = dovizTip.UYAP_KODU; // TODO :
                        sen.uzerindekiPulunDegeri = alacakNeden.DAMGA_PULU.ToString();
                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            sen.vadeTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI);
                        }

                        sen.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

                        returnValues.Add(sen);
                    }
                }
            }
            return returnValues;
        }

        private Evrak GetEvrak(string dosyaAdi, byte[] icerik)
        {
            Evrak evrk = new Evrak();
            MemoryStream fs = new MemoryStream(icerik);

            // StreamReader sr = new StreamReader(fs);
            //evrk.Data = icerik; Uyap için gerek yok þimdilik
            //evrk.Data = sr.ReadToEnd();
            // sr.Close();
            evrk.fileName = dosyaAdi;
            evrk.mimeType = GetMimeType(dosyaAdi);
            return evrk;
        }

        private string GetMimeType(string fileName)
        {
            if (!fileName.Contains("."))
            {
                return "";
            }
            string uzanti = fileName.Substring(fileName.LastIndexOf(".")).Trim();
            switch (uzanti)
            {
                case "doc":
                    return "application/msword";

                case "docx":
                    return "application/msword";

                default:
                    return "";
            }
        }

        #endregion Kiymetli Evrak
    }
}