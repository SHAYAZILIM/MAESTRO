using System;
using System.Collections.Generic;
using System.Text;
using AvukatProLib2.Entities;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using AvukatProLib2.Data;
using AdimAdimDavaKaydi.Editor.UserControls;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Schema;
using DevExpress.XtraEditors;
using AvukatProLib.Hesap;
using System.Data.Linq;
using AvukatProLib.Extras;
using AdimAdimDavaKaydi.Util.UyapHelper;

namespace AdimAdimDavaKaydi.Util.Uyap
{
    public class UyapGenerator
    {
        #region UyapHataKontrol Deðiþkenleri

        AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder hatalar;
        string xmlFilePath;
        int  hataCount = 0;
        public List<per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari;

        #endregion

        #region XmlAndFile

        public UyapGenerator(AdimAdimDavaKaydi.Editor.Forms.frmAdimAdimEditoreGonder hatalar)
        {
            this.hatalar = hatalar;
        }
        
        public void WriteXmlToFile(object value, string file)
        {

            MemoryStream ms = new MemoryStream();

            XmlSerializer xs = new XmlSerializer(value.GetType());

            xs.Serialize(ms, value);
            ms.Position = 0;
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(ms);
            //encoding bilgisinin verilmesi saðlandý. MB
            xmldoc.FirstChild.Value = "version=\"1.0\" encoding=\"ISO-8859-9\"";

            XmlElement root = xmldoc.DocumentElement;

            root.RemoveAllAttributes();
            XmlNodeList xList = xmldoc.GetElementsByTagName("kisiTumBilgileri");
            XmlNodeList xListFaiz = xmldoc.GetElementsByTagName("faiz");
            foreach (XmlNode tmpNode in xList)
            {
                if (tmpNode.Attributes != null)
                    for (int i = tmpNode.Attributes.Count - 1; i >= 0; i--)
                        if (tmpNode.Attributes[i].Value == String.Empty)
                            tmpNode.Attributes.RemoveNamedItem(tmpNode.Attributes[i].Name);

            }
            for (int i = xListFaiz.Count - 1; i >= 0; i--)
            {
                xListFaiz[i].ParentNode.RemoveChild(xListFaiz[i]);
            }
            xmldoc.Save(file);
            ms.Close();
            hatalar.XMLBastir(file);

        }
        public bool WriteToFile(List<per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari, string file)
        {


            foreach (per_AV001_TI_BIL_ICRA_Arama tmp in IcraDosyalari)
            {
                Hesap.Icra hesap = new Hesap.Icra(DataRepository.AV001_TI_BIL_FOYProvider.GetByID(tmp.ID));
                new HesapAraclari.IcraHesapCetveli(hesap.Foy).HesapAlanList.Where(vi => vi.Value.Para != 0);
            }


            ExchangeData exchangeFiles;
            this.xmlFilePath = file;
            this.IcraDosyalari = IcraDosyalari;



            try
            {
                exchangeFiles = GetExchangeDatas(IcraDosyalari);
                WriteXmlToFile(exchangeFiles, file);
            }
            catch
            {
                XtraMessageBox.Show("Uyap çýktýsý yazdýrýlýrken bir sorun oluþtu.", "Hata Kodu: UYPENV01");

            }
            finally
            {

            }
            return true;
        }
     
        public bool CheckFiles(List<per_AV001_TI_BIL_ICRA_Arama> dosyalar)
        {
            bool check = true;
            if (IcraDosyalari == null)
                IcraDosyalari = dosyalar;

            hatalar.UyapBildirim = new UyapGeriBildirim(IcraDosyalari, this);


            //Exchange Dosyasý yazdýrýlmadan önce föylerin kontrolü yapýlýyor - Enver Özay 23.08.2010
            foreach (per_AV001_TI_BIL_ICRA_Arama dosya in dosyalar)
            {
                if (!CheckFile(dosya)) check = false;
            }
            return check;
        }
        public bool CheckFile(per_AV001_TI_BIL_ICRA_Arama dosya)
        {
            UyapHata tmpHata;

            bool check = true;
            bool anTarafAlacakKont = false;
            bool anTarafBocluKont = false;
            AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(dosya.ID);

            TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNedenleri = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByICRA_FOY_ID(dosya.ID);
            TList<AV001_TI_BIL_FOY_TARAF> taraflar = DataRepository.AV001_TI_BIL_FOY_TARAFProvider.GetByICRA_FOY_ID(dosya.ID);
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> sorumlular = DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByICRA_FOY_ID(dosya.ID).FindAll(vi => !vi.YETKILI_MI);
            string hataString = String.Empty;



            if (!foy.TAKIP_TARIHI.HasValue)
            {
                hataString = " için takip tarihi giriniz.";
                hataCount++;

                tmpHata = new UyapHata(foy.ID.ToString(), "icra", AvukatProLib.Extras.FormType.CariGenelGiris);
                tmpHata.HataliFoyEski = foy;
                tmpHata.HataBilgisi = hataString;

                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                if (hatalar.HataEkle(tmpItm))
                    hatalar.HataliDosyalar.Add(tmpHata);
                check = false;
            }
            if (!foy.ADLI_BIRIM_ADLIYE_ID.HasValue)
            {
                hataString = " için icra müdürlüðü seçiniz.";
                hataCount++;

                tmpHata = new UyapHata(foy.ID.ToString(), "icra", AvukatProLib.Extras.FormType.CariGenelGiris);
                tmpHata.HataliFoyEski = foy;
                tmpHata.HataBilgisi = hataString;

                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                if (hatalar.HataEkle(tmpItm))
                    hatalar.HataliDosyalar.Add(tmpHata);
                check = false;
            }

            if (!foy.FORM_TIP_ID.HasValue)
            {
                hataString = " için form tipi giriniz.";
                hataCount++;

                tmpHata = new UyapHata(foy.ID.ToString(), "icra", AvukatProLib.Extras.FormType.IcraTakip);
                tmpHata.HataliFoyEski = foy;
                tmpHata.HataBilgisi = hataString;

                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                if (hatalar.HataEkle(tmpItm))
                    hatalar.HataliDosyalar.Add(tmpHata);
                check = false;

            }
            else //Form Tiplerine göre kontroller bölümü
            {
                if (foy.FORM_TIP_ID.Value == 10) //FORM 51
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                    foreach (AV001_TI_BIL_ALACAK_NEDEN aNeden in foy.AV001_TI_BIL_ALACAK_NEDENCollection)
                    {
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(aNeden, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_SOZLESME>));
                        TList<AV001_TDI_BIL_SOZLESME> sozlesmeler = aNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.FindAll(vi => vi.TIP_ID == 1);
                        if (sozlesmeler == null || sozlesmeler.Count == 0)
                        {
                            hataString = " için alacak nedenine kira sözleþmesi baðlanmamýþ, lütfen güncelleyiniz.";
                            hataCount++;

                            tmpHata = new UyapHata(foy.ID.ToString(), "icra", AvukatProLib.Extras.FormType.IcraTakip);
                            tmpHata.HataliFoyEski = foy;
                            tmpHata.HataBilgisi = hataString;

                            string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                            error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                            DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                            tmpItm.Tag = hatalar.HataliDosyalar.Count;
                            if (hatalar.HataEkle(tmpItm))
                                hatalar.HataliDosyalar.Add(tmpHata);
                            check = false;



                        }
                        foreach (AV001_TDI_BIL_SOZLESME sozlesme in aNeden.AV001_TDI_BIL_SOZLESMECollection_From_AV001_TI_BIL_ALACAK_NEDEN_SOZLESME_NEW.FindAll(vi => vi.TIP_ID == 1))
                        {

                            if (!sozlesme.BASLANGIC_TARIHI.HasValue)
                            {
                                hataString = " için sözleþme tarihi giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "kiraSozlesme", AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
                                tmpHata.HataliSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                                tmpHata.HataliSozlesme.Add(sozlesme);
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }

                            if (!sozlesme.BITIS_TARIHI.HasValue)
                            {
                                hataString = " için sözleþme bitiþ tarihi giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "kiraSozlesme", AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
                                tmpHata.HataliSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                                tmpHata.HataliSozlesme.Add(sozlesme);
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }

                            if (sozlesme.BEDELI == 0)
                            {
                                hataString = " için sözleþme bedeli giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "kiraSozlesme", AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
                                tmpHata.HataliSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                                tmpHata.HataliSozlesme.Add(sozlesme);
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (!sozlesme.BEDELI_DOVIZ_ID.HasValue)
                            {
                                hataString = " için sözleþme para birimi giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "kiraSozlesme", AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
                                tmpHata.HataliSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                                tmpHata.HataliSozlesme.Add(sozlesme);
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (String.IsNullOrEmpty(sozlesme.TAHLIYE_ADRESI))
                            {
                                hataString = " için sözleþme tahliye adresi giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "kiraSozlesme", AvukatProLib.Extras.FormType.SozlesmeGirisEkran);
                                tmpHata.HataliSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                                tmpHata.HataliSozlesme.Add(sozlesme);
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }


                        }
                    }
                }
                if (foy.FORM_TIP_ID.Value == 4 || foy.FORM_TIP_ID.Value == 5 || foy.FORM_TIP_ID.Value == 6 || foy.FORM_TIP_ID.Value == 9) // Kontrol edilecek ilamlýlar
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ILAM_MAHKEMESI>));
                    if (foy.AV001_TI_BIL_ILAM_MAHKEMESICollection.Count == 0)
                    {
                        hataString = " için mahkeme bilgisi giriniz.";
                        hataCount++;

                        tmpHata = new UyapHata(foy.ID.ToString(), "ilamMahkemeBos", AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                        tmpHata.HataliFoyEski = foy;


                        tmpHata.HataBilgisi = hataString;

                        string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                        error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                        DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                        tmpItm.Tag = hatalar.HataliDosyalar.Count;
                        if (hatalar.HataEkle(tmpItm))
                            hatalar.HataliDosyalar.Add(tmpHata);
                        check = false;
                    }
                    else
                        foreach (AV001_TI_BIL_ILAM_MAHKEMESI tmpMahkeme in foy.AV001_TI_BIL_ILAM_MAHKEMESICollection)
                        {
                            if (String.IsNullOrEmpty(tmpMahkeme.ESAS_NO))
                            {
                                hataString = " için mahkeme bilgilerinden esas no'yu giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "ilamMahkeme", AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliIlamMahkemesi = tmpMahkeme;
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (String.IsNullOrEmpty(tmpMahkeme.KARAR_NO))
                            {
                                hataString = " için mahkeme bilgilerinden karar no'yu giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "ilamMahkeme", AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliIlamMahkemesi = tmpMahkeme;
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (!tmpMahkeme.KARAR_TARIHI.HasValue)
                            {
                                hataString = " için mahkeme bilgilerinden karar tarihini giriniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "ilamMahkeme", AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliIlamMahkemesi = tmpMahkeme;
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (tmpMahkeme.ADLI_BIRIM_ADLIYE_ID == null || tmpMahkeme.ADLI_BIRIM_GOREV_ID == null || tmpMahkeme.ADLI_BIRIM_NO_ID == null)
                            {
                                hataString = " için mahkeme bilgilerinden adliye, birim ve  görev bilgilerini kontrol ediniz.";
                                hataCount++;

                                tmpHata = new UyapHata(foy.ID.ToString(), "ilamMahkeme", AvukatProLib.Extras.FormType.IcraIlamMahkemeGiris);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliIlamMahkemesi = tmpMahkeme;
                                tmpHata.HataBilgisi = hataString;

                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }

                        }

                }
                if (foy.FORM_TIP_ID.Value == 3 || foy.FORM_TIP_ID.Value == 11) // 3 form 163 e denk düþüyor 11 de form 52 'ye
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK>));
                    foreach (AV001_TDI_BIL_KIYMETLI_EVRAK tmpEvrak in foy.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_ICRA_KIYMETLI_EVRAK)
                    {
                        if (!tmpEvrak.EVRAK_TANZIM_TARIHI.HasValue)
                        {
                            hataString = " için kýymetli evrak tanzim tarihi giriniz.";
                            hataCount++;
                            tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                            tmpHata.HataliFoyEski = foy;
                            tmpHata.HataliKiymetliEvrak = tmpEvrak;
                            tmpHata.HataBilgisi = hataString;
                            string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                            error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                            DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                            tmpItm.Tag = hatalar.HataliDosyalar.Count;
                            if (hatalar.HataEkle(tmpItm))
                                hatalar.HataliDosyalar.Add(tmpHata);
                            check = false;
                        }
                        if (tmpEvrak.TUTAR == null)
                        {
                            hataString = " için kýymetli evrak tutarý giriniz.";
                            hataCount++;
                            tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                            tmpHata.HataliFoyEski = foy;
                            tmpHata.HataliKiymetliEvrak = tmpEvrak;
                            tmpHata.HataBilgisi = hataString;
                            string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                            error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                            DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                            tmpItm.Tag = hatalar.HataliDosyalar.Count;
                            if (hatalar.HataEkle(tmpItm))
                                hatalar.HataliDosyalar.Add(tmpHata);
                            check = false;
                        }
                        if (!tmpEvrak.TUTAR_DOVIZ_ID.HasValue)
                        {
                            hataString = " için kýymetli evrak döviz tipi giriniz.";
                            hataCount++;
                            tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                            tmpHata.HataliFoyEski = foy;
                            tmpHata.HataliKiymetliEvrak = tmpEvrak;
                            tmpHata.HataBilgisi = hataString;
                            string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                            error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                            DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                            tmpItm.Tag = hatalar.HataliDosyalar.Count;
                            if (hatalar.HataEkle(tmpItm))
                                hatalar.HataliDosyalar.Add(tmpHata);
                            check = false;
                        }

                        if (tmpEvrak.EVRAK_TUR_ID.Value == 1)
                        {
                            //Çek
                            if (!tmpEvrak.BANKA_ID.HasValue)
                            {
                                hataString = " için kýymetli evrak bankasý giriniz.";
                                hataCount++;
                                tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataBilgisi = hataString;
                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                {
                                    tmpHata.HataliKiymetliEvrak = tmpEvrak;
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                }
                                check = false;
                            }

                            if (String.IsNullOrEmpty(tmpEvrak.CEK_NO))
                            {
                                hataString = " için kýymetli evrak çek numarasý giriniz.";
                                hataCount++;
                                tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliKiymetliEvrak = tmpEvrak;
                                tmpHata.HataBilgisi = hataString;
                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }
                            if (String.IsNullOrEmpty(tmpEvrak.HESAP_NO))
                            {
                                hataString = " için kýymetli evrak hesap numarasý giriniz.";
                                hataCount++;
                                tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliKiymetliEvrak = tmpEvrak;
                                tmpHata.HataBilgisi = hataString;
                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;
                            }


                        }
                        else
                        {
                            //Senet
                            if (!tmpEvrak.EVRAK_VADE_TARIHI.HasValue)
                            {
                                hataString = " için kýymetli evrak hesap numarasý giriniz.";
                                hataCount++;
                                tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                                tmpHata.HataliFoyEski = foy;
                                tmpHata.HataliKiymetliEvrak = tmpEvrak;
                                tmpHata.HataBilgisi = hataString;
                                string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                                DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                if (hatalar.HataEkle(tmpItm))
                                    hatalar.HataliDosyalar.Add(tmpHata);
                                check = false;

                            }
                            DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(tmpEvrak, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));

                            foreach (AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF tmpTaraf in tmpEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection)
                            {
                                if (!tmpTaraf.TARAF_TIP_ID.HasValue)
                                {
                                    hataString = " için kýymetli evrak taraflarýndan" + tmpTaraf.TARAF_CARI_ADI + " için sýfat bilgisi giriniz.";
                                    hataCount++;
                                    tmpHata = new UyapHata(foy.ID.ToString(), "kiymetliEvrak", AvukatProLib.Extras.FormType.KiymetliEvrakKayit);
                                    tmpHata.HataliFoyEski = foy;
                                    tmpHata.HataliKiymetliEvrak = tmpEvrak;
                                    tmpHata.HataBilgisi = hataString;
                                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                                    if (hatalar.HataEkle(tmpItm))
                                        hatalar.HataliDosyalar.Add(tmpHata);
                                    check = false;

                                }
                            }
                        }
                    }
                }

            }

            foreach (AV001_TI_BIL_ALACAK_NEDEN alacakNedeni in alacakNedenleri)
            {

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(alacakNedeni, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> alacakTaraflar = DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.GetByICRA_ALACAK_NEDEN_ID(alacakNedeni.ID);


                if (alacakNedeni.TUTARI < 0 || !alacakNedeni.TUTAR_DOVIZ_ID.HasValue)
                {
                    hataString = " için alacak nedeni tutarý veya döviz tipi geçersiz, lütfen kontrol ediniz.";
                    hataCount++;

                    tmpHata = new UyapHata(foy.ID.ToString(), "icraAlacak", AvukatProLib.Extras.FormType.CariGenelGiris);
                    tmpHata.HataliFoyEski = foy;
                    tmpHata.HataBilgisi = hataString;
                    tmpHata.HataliAlacakNedeni = alacakNedeni;

                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                    if (hatalar.HataEkle(tmpItm))
                        hatalar.HataliDosyalar.Add(tmpHata);
                    check = false;
                }
                if (alacakNedeni.ISLEME_KONAN_TUTAR < 0 || !alacakNedeni.ISLEME_KONAN_TUTAR_DOVIZ_ID.HasValue)
                {
                    hataString = " için alacak nedeni iþleme konan tutar veya döviz tipi geçersiz, lütfen kontrol ediniz.";
                    hataCount++;

                    tmpHata = new UyapHata(foy.ID.ToString(), "icraAlacak", AvukatProLib.Extras.FormType.CariGenelGiris);
                    tmpHata.HataliFoyEski = foy;
                    tmpHata.HataBilgisi = hataString;
                    tmpHata.HataliAlacakNedeni = alacakNedeni;

                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                    if (hatalar.HataEkle(tmpItm))
                        hatalar.HataliDosyalar.Add(tmpHata);
                    check = false;
                }
                if (alacakTaraflar.Count == 0)
                {
                    hataString = " için alacak nedeni tarafý giriniz.";
                    hataCount++;

                    tmpHata = new UyapHata(foy.ID.ToString(), "icraAlacak", AvukatProLib.Extras.FormType.CariGenelGiris);
                    tmpHata.HataliFoyEski = foy;
                    tmpHata.HataBilgisi = hataString;
                    tmpHata.HataliAlacakNedeni = alacakNedeni;

                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                    if (hatalar.HataEkle(tmpItm))
                        hatalar.HataliDosyalar.Add(tmpHata);
                    check = false;
                }

                bool AlacakNedeniAlacakliVarmi = false;
                bool AlacakNedeniBorcluVarmi = false;


                foreach (AV001_TI_BIL_ALACAK_NEDEN_TARAF ataraf in alacakTaraflar)
                {

                    TDIE_KOD_TARAF_SIFAT asifat;

                    var sel = (from tbl in taraflar where tbl.CARI_ID == ataraf.TARAF_CARI_ID select new { tbl.ID, tbl.TAKIP_EDEN_MI });

                    var sel2 = from tbl2 in sel where tbl2.TAKIP_EDEN_MI == true select tbl2.ID;
                    var sel3 = from tbl3 in sel where tbl3.TAKIP_EDEN_MI == false select tbl3.ID;
                    if (sel2.Count() > 0)
                        AlacakNedeniAlacakliVarmi = true;
                    if (sel3.Count() > 0)
                        AlacakNedeniBorcluVarmi = true;
                    if (!(anTarafAlacakKont && anTarafBocluKont))
                    {
                        asifat = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(ataraf.TARAF_SIFAT_ID.Value);
                        if (asifat.HANGI_TARAF_NO == 1)
                            anTarafAlacakKont = true;
                        if (asifat.HANGI_TARAF_NO == 2)
                            anTarafBocluKont = true;

                    }
                    if (sel.Count() == 0)
                    {

                        tmpHata = new UyapHata(foy.ID.ToString(), "taraf", AvukatProLib.Extras.FormType.AlacakNedenEkle);
                        tmpHata.HataliAlacakNedeni = alacakNedeni;
                        tmpHata.HataliAlacakNedenTarafi = ataraf;
                        tmpHata.HataliFoyEski = foy;
                        tmpHata.HataBilgisi = "alacak nedeni taraf bilgilerini kontrol ediniz.\n";
                        tmpHata.HataBilgisi += "Taraflar :\n";
                        foreach (AV001_TI_BIL_FOY_TARAF tmpTaraf in taraflar)
                        {
                            TDIE_KOD_TARAF_SIFAT sifat = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(tmpTaraf.TARAF_SIFAT_ID);

                            if (BelgeUtil.Inits._per_CariGetir == null)
                                BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

                            tmpHata.HataBilgisi += BelgeUtil.Inits._per_CariGetir.Find(vi => vi.ID == tmpTaraf.CARI_ID).AD + " ( " + sifat.SIFAT + " )\n";
                        }
                        tmpHata.HataBilgisi += "Taraflarda bulunmayan alacak nedeni tarafý :\n";
                        tmpHata.HataBilgisi += ataraf.TARAF_CARI_ADI + "\n";
                        var arama = from t1 in hatalar.HataliDosyalar where t1.HataliFoy.ID == dosya.ID && t1.HataNedeni == tmpHata.HataNedeni select t1;
                        if (arama.Count() == 0)
                        {
                            hataCount++;
                            string error = "Föy NO: " + foy.FOY_NO + " için " + tmpHata.HataBilgisi;
                            error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();
                            DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                            tmpItm.Tag = hatalar.HataliDosyalar.Count;
                            if (hatalar.HataEkle(tmpItm))
                                hatalar.HataliDosyalar.Add(tmpHata);
                            check = false;
                        }

                    }



                }
                if (AlacakNedeniAlacakliVarmi ^ AlacakNedeniBorcluVarmi)
                {
                    hataString = " için alacak nedeninde en az bir alacaklý ve borçlu zorunludur.";
                    hataCount++;

                    tmpHata = new UyapHata(foy.ID.ToString(), "icraAlacak", AvukatProLib.Extras.FormType.CariGenelGiris);
                    tmpHata.HataliFoyEski = foy;
                    tmpHata.HataBilgisi = hataString;
                    tmpHata.HataliAlacakNedeni = alacakNedeni;

                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                    if (hatalar.HataEkle(tmpItm))
                        hatalar.HataliDosyalar.Add(tmpHata);
                    check = false;
                }
            }


            foreach (AV001_TI_BIL_FOY_TARAF tmpTaraf in taraflar)
            {


                var result = (from item in BelgeUtil.Inits.context.per_UYAP_TARAF_CARIs where item.TARAF_ID == tmpTaraf.ID select item).First();

                bool hataCheck = false;
                hataString = result.AD + " için";
                //if (tmpTaraf.TAKIP_EDEN_MI)
                //{

                if (String.IsNullOrEmpty(result.ADRES_1))
                {
                    hataCheck = true;
                    hataString += " adres,";
                }
                if (!result.ILCE_ID.HasValue)
                {
                    hataCheck = true;
                    hataString += " ilçe,";
                }
                if (!result.IL_ID.HasValue)
                {
                    hataCheck = true;
                    hataString += " il,";
                }
                if (hataCheck)
                {
                    hataString = hataString.Substring(0, hataString.Length - 1);
                    hataString += " bilgilerini kontrol ediniz.\n";
                    hataCount++;

                    tmpHata = new UyapHata(foy.ID.ToString(), "cari", AvukatProLib.Extras.FormType.CariGenelGiris);
                    tmpHata.HataliFoyEski = foy;
                    tmpHata.HataBilgisi = hataString;
                    TList<AV001_TDI_BIL_CARI> HataliCari = new TList<AV001_TDI_BIL_CARI>();
                    AV001_TDI_BIL_CARI hcari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(result.CARI_ID.Value);
                    //Düzenleme modunda kimlik bilgisi varsa form içerisinde görünmesi için deepload eklendi. MB
                    DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(hcari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                    HataliCari.Add(hcari);
                    tmpHata.HataliCari = HataliCari;

                    string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                    error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                    DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                    tmpItm.Tag = hatalar.HataliDosyalar.Count;
                    if (hatalar.HataEkle(tmpItm))
                        hatalar.HataliDosyalar.Add(tmpHata);
                    check = false;

                }


                if (tmpTaraf.TAKIP_EDEN_MI && result.FIRMA_MI.HasValue && result.FIRMA_MI.Value)
                {
                    if (String.IsNullOrEmpty(result.VERGI_NO))
                    {
                        hataString = result.AD + " için vergi numarasý giriniz.";

                        hataCount++;

                        tmpHata = new UyapHata(foy.ID.ToString(), "cari", AvukatProLib.Extras.FormType.CariGenelGiris);
                        tmpHata.HataliFoyEski = foy;
                        tmpHata.HataBilgisi = hataString;
                        TList<AV001_TDI_BIL_CARI> HataliCari = new TList<AV001_TDI_BIL_CARI>();
                        AV001_TDI_BIL_CARI hcari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(result.CARI_ID.Value);
                        //Düzenleme modunda kimlik bilgisi varsa form içerisinde görünmesi için deepload eklendi. MB
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(hcari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                        HataliCari.Add(hcari);
                        tmpHata.HataliCari = HataliCari;

                        string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                        error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                        DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                        tmpItm.Tag = hatalar.HataliDosyalar.Count;
                        if (hatalar.HataEkle(tmpItm))
                            hatalar.HataliDosyalar.Add(tmpHata);
                        check = false;

                    }
                }
                else
                {
                    if (tmpTaraf.TAKIP_EDEN_MI && String.IsNullOrEmpty(result.TC_KIMLIK_NO))
                    {
                        hataString = result.AD + " için TC kimlik no giriniz.";
                        hataCount++;

                        tmpHata = new UyapHata(foy.ID.ToString(), "cariKimlik", AvukatProLib.Extras.FormType.CariGenelGiris);
                        tmpHata.HataliFoyEski = foy;
                        tmpHata.HataBilgisi = hataString;
                        TList<AV001_TDI_BIL_CARI> HataliCari = new TList<AV001_TDI_BIL_CARI>();
                        AV001_TDI_BIL_CARI hcari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(result.CARI_ID.Value);
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(hcari, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                        HataliCari.Add(hcari);
                        tmpHata.HataliCari = HataliCari;

                        string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                        error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                        DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                        tmpItm.Tag = hatalar.HataliDosyalar.Count;
                        if (hatalar.HataEkle(tmpItm))
                            hatalar.HataliDosyalar.Add(tmpHata);
                        check = false;

                    }
                }

                //}
                //else
                //{
                //    tarafBorcluKont = true;

                //}

            }

            if (sorumlular != null && sorumlular.Count > 0)
            {
                foreach (var av in sorumlular)
                {
                    var result = (from item in BelgeUtil.Inits.context.per_UYAP_SORUMLU_AVUKATs where item.SORUMLU_AVUKAT_CARI_ID == av.SORUMLU_AVUKAT_CARI_ID select item).First();

                    bool hataCheck = false;
                    hataString = result.AD + " için";

                    if (String.IsNullOrEmpty(result.ADRES_1))
                    {
                        hataCheck = true;
                        hataString += " adres,";
                    }
                    if (!result.ILCE_ID.HasValue)
                    {
                        hataCheck = true;
                        hataString += " ilçe,";
                    }
                    if (!result.IL_ID.HasValue)
                    {
                        hataCheck = true;
                        hataString += " il,";
                    }
                    if (String.IsNullOrEmpty(result.VERGI_NO))
                    {
                        hataCheck = true;
                        hataString += " vergi numarasý,";
                    }
                    if (string.IsNullOrEmpty(result.VERGI_DAIRESI))
                    {
                        hataCheck = true;
                        hataString += " vergi dairesi,";
                    }
                    if (String.IsNullOrEmpty(result.TC_KIMLIK_NO))
                    {
                        hataCheck = true;
                        hataString += " TC kimlik no,";
                        hataCount++;
                    }
                    if (hataCheck)
                    {
                        hataString = hataString.Substring(0, hataString.Length - 1);
                        hataString += " bilgilerini kontrol ediniz.\n";
                        hataCount++;

                        tmpHata = new UyapHata(foy.ID.ToString(), "cari", AvukatProLib.Extras.FormType.CariGenelGiris);
                        tmpHata.HataliFoyEski = foy;
                        tmpHata.HataBilgisi = hataString;
                        TList<AV001_TDI_BIL_CARI> HataliCari = new TList<AV001_TDI_BIL_CARI>();
                        AV001_TDI_BIL_CARI hcari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(result.SORUMLU_AVUKAT_CARI_ID.Value);
                        //Düzenleme modunda kimlik bilgisi varsa form içerisinde görünmesi için deepload eklendi. MB
                        DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(hcari, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));
                        HataliCari.Add(hcari);
                        tmpHata.HataliCari = HataliCari;

                        string error = "Föy NO: " + foy.FOY_NO + ", " + tmpHata.HataBilgisi;
                        error = hataCount.ToString() + "." + error[0] + error[1].ToString().ToString() + error.Substring(2).ToLower();

                        DevExpress.XtraNavBar.NavBarItem tmpItm = new DevExpress.XtraNavBar.NavBarItem(error);
                        tmpItm.Tag = hatalar.HataliDosyalar.Count;
                        if (hatalar.HataEkle(tmpItm))
                            hatalar.HataliDosyalar.Add(tmpHata);
                        check = false;

                    }
                }
            }

            return check;


        }
        public bool WriteToFile(per_AV001_TI_BIL_ICRA_Arama IcraDosya, string file)
        {
            List<per_AV001_TI_BIL_ICRA_Arama> returnValues = new List<per_AV001_TI_BIL_ICRA_Arama>();
            returnValues.Add(IcraDosya);
            return WriteToFile(returnValues, file);
        }

        public bool UyapGozdenGecir(List<per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari, string file, bool geriBildirimYapilsin)
        {
            if (geriBildirimYapilsin)
            {
                hataCount = 0;
                hatalar.HatalariSil();
                hatalar.Focus();
                bool result = CheckFiles(IcraDosyalari);
                if (result)
                    hatalar.UyapSonSayfaGetir();
                return result;
            }
            return false;

        }

        #endregion

        public static int UyapSiraNo { get; set; }

        public ExchangeData GetExchangeDatas(List<per_AV001_TI_BIL_ICRA_Arama> IcraDosyalari)
        {
            ExchangeData exchangeData = new ExchangeData();
            exchangeData.dosya = new Dosyalar();
            for (int i = 0; i < IcraDosyalari.Count; i++)
            {
                UyapSiraNo = i + 1;
                ExchangeHeader header = new ExchangeHeader();
                header.Version = AdimAdimDavaKaydi.Util.UyapHelper.Strings.XmlHeaderVersion;
                exchangeData.ExchangeHeader = header;
                Dosya dsy = GetIcraAsDosya(IcraDosyalari[i]);

                exchangeData.dosya.Add(dsy);
            }

            return exchangeData;
        }

        #region Dosya
        
        //her yeni doysa ya geçildiðinde yapýlacak olan iþlemler 
        void DosyaOnIslemler()
        {
            // her yeni edosyada dosya içindeki faizlerin tutuldugu diziyi sýfýrladýk ... 
            faizler = new List<Faiz>();
            DosyaAlacakKalemleri = new List<alacakKalemKodlar>();
        }

        public class TakipYolu
        {
            private bool _ilamsizmi;
            public bool IlamsizMi
            {
                get { return _ilamsizmi; }
                set { _ilamsizmi = value; }
            }

            private int _id;
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _laf;
            public string Laf
            {
                get { return _laf; }
                set { _laf = value; }
            }

            private int[] _formTipleri;
            public int[] FormTipleri
            {
                get { return _formTipleri; }
                set { _formTipleri = value; }
            }

            public TakipYolu()
            {

            }

            static int FormTipiIdGetir(int formTipi)
            {
                return BelgeUtil.Inits.context.per_TI_KOD_FORM_TIPs.Single(vi => vi.FORM_ORNEK_NO == formTipi.ToString()).ID;
            }

            public TakipYolu(bool ilamsizmi, int id, string laf, int[] ftips)
            {
                this._id = id;
                this._laf = laf;
                this._formTipleri = ftips;
                this._ilamsizmi = ilamsizmi;
            }

            public static int TakipYoluGetir(per_AV001_TI_BIL_ICRA_Arama IcraDosya, TakipYolu[] takipYollari)
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
        }

        public Dosya GetIcraAsDosya(per_AV001_TI_BIL_ICRA_Arama IcraDosya)
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
            returnValue.takipSekli = int.Parse(BelgeUtil.Inits._FormTipiGetir.Find(vi => vi.ID == IcraDosya.FORM_TIP_ID).UYAP_KOD);// 0; //ToDo : Burasý ayarlanacak :gkn
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
            // returnValue.evraklar = GetEvraklar(IcraDosya);

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

        private bool KontratBilgisiGelsin(per_AV001_TI_BIL_ICRA_Arama IcraDosya)
        {
            List<int> dizi = new List<int>();
            dizi.AddRange(new[] { 2, 7, 8, 13, 1, 12, 10, 6, 9 }); //form tipi 50,201,151,152 ,49, 153, 51, 54, 56 //Kenan Büyük'ün talebi ile 49, 153, 51, 54, 56 form tipleri de eklendi.

            return !dizi.Contains(IcraDosya.FORM_TIP_ID.Value);
        }

        List<alacakKalemKodlar> DosyaAlacakKalemleri = new List<alacakKalemKodlar>();

        static TDIE_KOD_TALEP_ACIKLAMA_DEGISKEN TalepAciklamasiGetir(AV001_TI_BIL_FOY foy)
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

        public static string GetIcraTakipTalebiFromNesne(per_AV001_TI_BIL_ICRA_Arama foy)
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

                    //  IcraDegiskenDegerAta("YFM", FaizHelper.FaizOraniGetir(ftid, dtip, tata));

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

            yazi = Replace("ASIL ALACAK", yazi, so.ParaFormatla(foyum.ASIL_ALACAK));
            decimal DovizKuru = AvukatProLib.Hesap.DovizHelper.CevirYTL(1, foyum.ASIL_ALACAK_DOVIZ_ID, tata);
            yazi = Replace("DÖVÝZ KURU", yazi, DovizKuru.ToString());
            yazi = Replace("HARCA ESAS DEÐER", yazi, so.ParaFormatla(harcaEsasDeger));
            //yazi= Replace("&DTC&",yazi,);

            if (foyum.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 1 && foyum.TAKIP_CIKISI_DOVIZ_ID != 1)
            {
                decimal DovizKuru1 = DovizHelper.CevirYTL(1, foy.ASIL_ALACAK_DOVIZ_ID, foy.TAKIP_TARIHI.Value);
                if (DovizKuru1 == 0) DovizKuru = 1;
                yazi = Replace("&GDK&", yazi, DovizKuru1.ToString());
                yazi = Replace("&DTC&", yazi, foyum.AV001_TI_BIL_ALACAK_NEDENCollection[0].ISLEME_KONAN_TUTAR.ToString() + " " + BelgeUtil.Inits.DovizIdSource(foyum.TAKIP_CIKISI_DOVIZ_ID.Value).DOVIZ_KODU);
            }
            else
            {
                yazi = Replace("&GDK&", yazi, "");
                yazi = Replace("&DTC&", yazi, "");
            }

            yazi = Replace("&ATK&", yazi, so.ParaFormatla(foyum.TAKIP_CIKISI) + " TL");

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

            yazi = Replace("&FO&", yazi, faizOran/* AvukatProLib.Hesap.FaizHelper.FaizOraniGetir(foy.FORM_TIP_ID.Value, dtip, tata)*/.ToString());

            if (yazi.StartsWith(" tutarýndaki "))
                yazi = yazi.Replace(" tutarýndaki ", " ");

            return yazi;
        }

        static string Replace(string var, string data, object newValue)
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

        public class SayiOkuma
        {

            private string[] yuzler = new string[10];
            private string[] onlar = new string[10];
            private string[] birler = new string[10];
            private string[] hane = new string[5];
            private string[] rakam = new string[5];
            // arraylarý tanýmlýyoruz

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

            private string birsorunu(string sorun)
            {
                string cozum = "";
                if (sorun == "birbin ")
                    cozum = "bin ";
                else
                    cozum = sorun;
                return cozum;
            }

            public string ParaFormatla(object deger)
            {
                //return string.Format("###,###,###,###,##", deger);
                decimal d = decimal.Parse(deger.ToString().Trim());
                return d.ToString("###,###,###,###,##0.00");


                ////             string yeniDeger = ""; 
                ////            if (deger.ToString().Contains(","))
                ////            {

                ////                string[] degers = deger.ToString().Split(',');

                ////                for (int i = 1; i < degers[0].Length; i++)
                ////                {

                ////yeniDeger += degers[0][i-1];                 
                ////                    if (i%3==0  && i!=0)
                ////    {
                ////                        yeniDeger+=",";
                ////    }
                ////                }
                ////                if (degers[1].Length > 2)
                ////                {
                ////                    yeniDeger += (degers[1][0] + degers[1][1]);
                ////                }

                ////            }
                ////            return yeniDeger;

                //string rv = "";
                //string kurus = "";
                //string[] paradizisi = deger.Split(',');
                //if (paradizisi.Length>=2)
                //{
                //    kurus = paradizisi[1];
                //}
                //string ss= paradizisi[0];
                //int s = 0;

                //string[] degerler = new string[10];
                //int.TryParse(ss, out s);
                //if (s == 0)
                //{
                //    return "0";
                //}
                //if (ss.Length >= 3)
                //{
                //    int j = 0;
                //    for (int i = ss.Length-1; i >= 0; i --)
                //    {
                //        j++;
                //        if ((j)%3==0)
                //        {
                //            rv = "." + ss[i] + rv;
                //        }
                //        else
                //        {
                //            rv = ss[i] + rv;
                //        }
                //    }
                //}
                //else
                //{
                //    rv = ss;
                //}
                //if (kurus.Length>2)
                //{
                //    kurus = kurus.Remove(2);
                //}
                //if (!string.IsNullOrEmpty(kurus))
                //{
                //    return rv + "," + kurus;
                //}
                //else
                //{
                //    return rv;
                //}
            }
        }

        #endregion

        #region Enums

        public enum AdresBilgiTipi
        {
            Il, Ilce, Adres, PostaKodu, AdresSirasi
        }

        #endregion

        #region kontratBilgileri

        public List<KontratKefil> GetKontratKefils(per_AV001_TI_BIL_ICRA_Arama Foyum)
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
                        //kkefil.adres = getAdres(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sozlesmeTaraflari[0].CARI_ID.Value)); // hukuk ailesinde olmadýðýndan kaldýrýldý. MB adres property tipi Adres'di, class içindeki diðer property'lerin gelmesi istenmediðinden ve bu class bir çok yerde kullanýldýðýndan iþleyiþi bozmamak için yeni bir class ile aþaðýdaki þekilde yapýldý.

                        kkefil.adres = getAdresKontratAlacakli(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sozlesmeTaraflari[0].CARI_ID.Value));

                        Kontrat kntrt = GetKontrat(lstSozlesmeler[z], alacakNedenList[i], i == 0 ? true : false);
                        kkefil.kontrat = kntrt;
                        KontratKefilIdUret(kkefil);
                        returnValues.Add(kkefil);
                    }
                }
            }
            return returnValues;
        }

        List<KontratKefil> kefiller = new List<KontratKefil>();
        int kcounter = 0;
        bool KontratKefilIdUret(KontratKefil aranan)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sozlesme"></param>
        /// <param name="aneden"></param>
        /// <param name="gecmisGunFaiziHesaplansin">
        /// true = alacak nedenine ait faiz kalemlerini yazar
        /// false = hiç yazmaz 
        /// null = föye baðlý bütün faiz kalmelerini yazar
        /// </param>
        /// <returns></returns>
        public Kontrat GetKontrat(AV001_TDI_BIL_SOZLESME Sozlesme, AV001_TI_BIL_ALACAK_NEDEN aneden, bool? gecmisGunFaiziHesaplansin)
        {
            Kontrat returnValue = new Kontrat();
            returnValue.Id = Strings.kontratIdPrefix + Sozlesme.ID.ToString();
            returnValue.aciklama = Sozlesme.ACIKLAMA;
            returnValue.adresAciklama = Sozlesme.TAHLIYE_ADRESI;
            returnValue.alacakKalemi = GetAlacakKalemleri(Sozlesme, aneden, null);
            returnValue.belgeIslemeleriBaslatiliyormu = "E"; //Belge Uyapa gönderiliyorsa zaten iþlemler baþlýyordur mantýðý güdüldü //Sozlesme.ISLEMLER_BASLADIMI ? "E" : "H"; // 'E';
            returnValue.belgeninTutari = Format.ParaUyap(Sozlesme.BEDELI);
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
            returnValue.tutarTur = dovizTip.UYAP_KODU.Trim();
            returnValue.tutarTurAciklama = dovizTip.UYAP_ACIKLAMA;
            returnValue.uzerindekiPulDegeri = Strings.UzerindekiPulDegeriDefault;

            KontratIdUret(returnValue);
            return returnValue;
        }

        List<Kontrat> Kontratlar = new List<Kontrat>();
        int kntCounter = 0;
        bool KontratIdUret(Kontrat kntrt)
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

        #endregion

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

        public List<Taraf> GetIcraTarafs(per_AV001_TI_BIL_ICRA_Arama IcraDosya)
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
                myTaraf.id = Strings.icraDosyaTarafIdPrefix + UyapSiraNo + taraf.CARI_ID.ToString();

                KisiKurumBilgileri kurumbilgisi = new KisiKurumBilgileri();
                kurumbilgisi.ad = taraf.AD;
                kurumbilgisi.id = Strings.kisiKurumIdPrefix + UyapSiraNo + taraf.CARI_ID;

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

                //XML çýktýsýnda ref bilgilerinin gösterilmesi istendmediðinden - Hukuk Ailesinde yokmuþ - kaldýrýldý. MB
                //if (curentTaraf.TARAF_SIFAT_ID == (int)AvukatProLib.Extras.TarafSifat.ALACAKLI)
                //{
                //    if (BelgeUtil.Inits._DosyaSorumluAvukatGetir == null)
                //        BelgeUtil.Inits._DosyaSorumluAvukatGetir = BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.ToList();
                //    var sorumlular = BelgeUtil.Inits._DosyaSorumluAvukatGetir.FindAll(vi => vi.ICRA_FOY_ID == IcraDosya.ID && !vi.YETKILI_MI);
                //    foreach (var sorumlu in sorumlular)
                //    {

                //        if (myTaraf.refler == null) myTaraf.refler = new List<Ref>();
                //        try
                //        {
                //            myTaraf.refler.Add(new Ref() { to = "VekilKisi", id = Strings.vekilKisiIdPrefix + UyapSiraNo + sorumlu.SORUMLU_AVUKAT_CARI_ID.ToString() });
                //        }
                //        catch
                //        {
                //            throw new Exception("Sorumlu Avukat Seçilmemiþ...");
                //        }

                //    }
                //    foreach (var vekil in BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(vi => vi.FOY_TARAF_ID == curentTaraf.ID && vi.TAKIP_EDENIN_VEKILI_MI.HasValue && !vi.TAKIP_EDENIN_VEKILI_MI.Value))
                //    {
                //        if (sorumlular.Count(s => s.SORUMLU_AVUKAT_CARI_ID == vekil.AVUKAT_CARI_ID) == 0)
                //        {
                //            if (myTaraf.refler == null) myTaraf.refler = new List<Ref>();
                //            try
                //            {
                //                myTaraf.refler.Add(new Ref() { to = "VekilKisi", id = Strings.vekilKisiIdPrefix + UyapSiraNo + vekil.ID.ToString() });
                //            }
                //            catch
                //            {

                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    TList<AV001_TI_BIL_FOY_TARAF_VEKIL> vekiller = DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_ID(taraf.ID);
                //    foreach (var tVekil in vekiller)
                //    {
                //        if (myTaraf.refler == null) myTaraf.refler = new List<Ref>();

                //        myTaraf.refler.Add(new Ref() { to = "VekilKisi", id = Strings.vekilKisiIdPrefix + UyapSiraNo + tVekil.ID.ToString() });
                //    }
                //}
                returnValues.Add(myTaraf);
            }
            return returnValues;
        }

        #endregion

        #region TarafIslemleri

        Kurum GetKurumBilgisi(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
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
                //Hukuk ailesinde olmadýðýndan aþaðýdaki atama kaldýrýldý. MB
                //donecek.harcDurumu = cari.HARCDAN_MUAF_MI ? "1" : "0";

                return donecek;
            }
            return null;
        }

        KisiTumBilgileri getKisiTumBilgileri(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
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

        #endregion

        #region CariBilgileri

        object GetAdresBilgi(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim, AdresBilgiTipi tip)
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

        Adres getAdres(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim)
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

        KontratAlacakliAdres getAdresKontratAlacakli(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim)
        {
            if (carim == null)
            {
                return null;
            }

            KontratAlacakliAdres adres = new KontratAlacakliAdres();

            adres.id = Strings.adresIdPrefix + carim.ID.ToString() + GetAdresBilgi(carim, AdresBilgiTipi.AdresSirasi).ToString();

            return adres;
        }

        KisiTumBilgileri getKisiTumBilgileri(AvukatProLib2.Entities.AV001_TDI_BIL_CARI_KIMLIK kimlik)
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

        KisiTumBilgileri getKisiTumBilgiler(AvukatProLib2.Entities.AV001_TDI_BIL_CARI cari)
        {
            AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.DeepLoad(cari, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI),
                typeof(TDI_KOD_CINSIYET), typeof(TDI_KOD_KIMLIK_VERILIS_NEDEN), typeof(TDI_KOD_IL), typeof(TDI_KOD_ILCE));

            KisiTumBilgileri kisiTumBilgisi = new KisiTumBilgileri();

            string[] adSoyad = GetAdSoyadFromCari(cari);

            kisiTumBilgisi.id = Strings.kisiTumBilgileriIdPrefix + cari.ID.ToString();
            kisiTumBilgisi.adi = adSoyad[0];
            kisiTumBilgisi.soyadi = adSoyad[1];
            // kisiTumBilgisi.cinsiyeti = Strings.CinsiyetErkek;//(cari.CINSIYET_IDSource.ID == 1 ? "E" : "K");
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
            kisiTumBilgisi.verildigiTarih = "";// Format.Tarih(kimlik.CUZDANIN_VERILIS_TARIHI);//Kontrol
            kisiTumBilgisi.verilisNedeni = "";// kimlik.CUZDANIN_VERILME_NEDENI_IDSource.UYAP_KOD;
            kisiTumBilgisi.ybnNfsKayitliOldgYer = "";//Kontrol

            return kisiTumBilgisi;
        }

        string[] GetAdSoyadFromCari(AvukatProLib2.Entities.AV001_TDI_BIL_CARI carim)
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

        #endregion

        #region VekilIslemleri


        Vekil getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL vekil)
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
            vkl.id = Strings.vekilIdPrefix + UyapSiraNo + vekil.ID.ToString();
            //  vkl.kapanmaNedeni = ' ';
            vkl.kurumAvikatiMi = (vekil.AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI == true ? Strings.Evet : Strings.Hayir);
            vkl.sigortaliMi = (vekil.AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU == true ? Strings.Evet : Strings.Hayir);
            vkl.tbbNo = vekil.AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO;
            vkl.tcKimlikNo = vekil.AVUKAT_CARI_IDSource.VERGI_NO;

            vkl.vekilTipi = "B";// TODO :  taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString(); // TODO: KOD;

            return vkl;
        }

        Vekil getVekil(AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT vekil)
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
            #endregion </GKN-20090629>

            vkl.id = Strings.vekilIdPrefix + UyapSiraNo + vekil.ID.ToString();
            vkl.kapanmaNedeni = "0";
            vkl.kurumAvikatiMi = (vekil.SORUMLU_AVUKAT_CARI_IDSource.KURUM_AVUKATI_MI == true ? Strings.Evet : Strings.Hayir);
            vkl.sigortaliMi = (vekil.SORUMLU_AVUKAT_CARI_IDSource.SG_NO_KULLANIYOR_MU == true ? Strings.Evet : Strings.Hayir);
            vkl.tbbNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.BARO_BIRLIK_SICIL_NO;
            vkl.tcKimlikNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.VERGI_NO;
            vkl.vergiNo = vekil.SORUMLU_AVUKAT_CARI_IDSource.VERGI_NO;
            vkl.vekilTipi = Strings.VekilTipiB;// TODO :  taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection[i].TEMSIL_IDSource.ID.ToString(); // TODO: KOD;
            return vkl;
        }

        bool TakipEdenAvukatimi(AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT vekil)
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

        List<VekilKisi> getVekilKisi(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY_TARAF_VEKIL> tarafVekils)
        {
            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            //AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(tarafVekils, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

            for (int i = 0; i < tarafVekils.Count; i++)
            {
                //if (tarafVekils[i].AVUKAT_CARI_IDSource != null)
                //{
                VekilKisi vekilKisisi = new VekilKisi();

                vekilKisisi.adres = getAdres(tarafVekils[i].AVUKAT_CARI_IDSource);
                vekilKisisi.id = Strings.vekilKisiIdPrefix + UyapSiraNo + tarafVekils[i].ID.ToString();

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
                //}
            }
            return lstVekilKisi;
        }

        List<VekilKisi> getVekilKisi(TList<AvukatProLib2.Entities.AV001_TI_BIL_FOY_SORUMLU_AVUKAT> sorumluAvukatlar)
        {
            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            VekilKisi vekilKisisi;

            foreach (var carim in sorumluAvukatlar)
            {
                if (carim.SORUMLU_AVUKAT_CARI_IDSource == null)
                    DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.DeepLoad(carim, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                vekilKisisi = new VekilKisi();

                vekilKisisi.adres = getAdres(carim.SORUMLU_AVUKAT_CARI_IDSource);
                vekilKisisi.id = Strings.vekilKisiIdPrefix + UyapSiraNo + carim.SORUMLU_AVUKAT_CARI_ID.ToString();
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

            }
            return lstVekilKisi;
        }

        List<VekilKisi> getVekilKisi(per_AV001_TI_BIL_ICRA_Arama Foyum)
        {


            List<VekilKisi> lstVekilKisi = new List<VekilKisi>();
            TList<AV001_TI_BIL_FOY_TARAF_VEKIL> lstVekils = new TList<AV001_TI_BIL_FOY_TARAF_VEKIL>();

            #region eski
            //#region Taraflarýn vekillerinde dönüp listelere ekliyoruz

            //  List<per_AV001_TI_BIL_FOY_TARAF> foyTaraflar= BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAFs.Where(cci=>cci.ICRA_FOY_ID==Foyum.ID).ToList();

            //foreach (var taraf in foyTaraflar)
            //{
            //    foreach (var vekil in DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.GetByFOY_TARAF_CARI_ID(taraf.ID))
            //    {
            //        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(vekil, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
            //        //Avukat bilgileri dolu ise
            //        //if (vekil.AVUKAT_CARI_IDSource != null)
            //        //{
            //            //Vekil listesine daha önce eklenmemiþ ise
            //            if (!IsInVekilCollection(lstVekils, vekil))
            //            {
            //                //Cari Listesine daha önce eklenmemiþ ise 
            //                if (!IsInCariCollection(VekilCarileri, vekil.AVUKAT_CARI_IDSource))
            //                {
            //                    //Her iki listeye de ekliyoruz.. 
            //                    lstVekils.Add(vekil);
            //                    VekilCarileri.Add(vekil.AVUKAT_CARI_IDSource);
            //                }
            //            }
            //        //}
            //    }
            //}
            //#endregion

            //TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> SorumluAvukatlar = new TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>();

            //#region Sorumlarda dönüp listeye ekliyoruz
            //List<per_AV001_TI_BIL_FOY_SORUMLU_AVUKAT> dosyaSorumluAvukatlari= BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vi => vi.ICRA_FOY_ID == Foyum.ID).ToList();


            //foreach (var sorumlu in dosyaSorumluAvukatlari)
            //{
            //    //Vekil listesine eklenmemiþ ise listelere ekliyeceðiz
            //    var sorumluCari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(sorumlu.SORUMLU_AVUKAT_CARI_ID.Value);
            //    if (!IsInCariCollection(VekilCarileri, sorumluCari))
            //    {
            //        SorumluAvukatlar.Add(DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetByID(sorumlu.ID));
            //        VekilCarileri.Add(sorumluCari);
            //    }
            //}
            //#endregion
            #endregion
            AV001_TI_BIL_FOY UypMyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Foyum.ID);
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(UypMyFoy, true, DeepLoadType.IncludeChildren
                                                             , typeof(TList<AV001_TI_BIL_FOY_TARAF>)
                                                             , typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>)
                                                             ,
                                                               typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));




            if (UypMyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count > 0)
            {
                lstVekilKisi.AddRange(getVekilKisi(UypMyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.FindAll(vi => !vi.YETKILI_MI)));

            }
            AV001_TI_BIL_FOY_TARAF_VEKIL tmpVekil;
            foreach (AV001_TI_BIL_FOY_TARAF currentTaraf in UypMyFoy.AV001_TI_BIL_FOY_TARAFCollection)
                foreach (var vekil in BelgeUtil.Inits.context.per_AV001_TI_BIL_FOY_TARAF_VEKILs.Where(vi => vi.FOY_TARAF_ID == currentTaraf.ID && vi.TAKIP_EDENIN_VEKILI_MI.HasValue && !vi.TAKIP_EDENIN_VEKILI_MI.Value))
                {

                    tmpVekil = DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.GetByID(vekil.ID);
                    DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(tmpVekil, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                    lstVekils.Add(tmpVekil);


                }

            //foreach (var taraf in UypMyFoy.AV001_TI_BIL_FOY_TARAFCollection)
            //{
            //    if(!taraf.TAKIP_EDEN_MI)
            //    {
            //    DataRepository.AV001_TI_BIL_FOY_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF_VEKIL>));
            //    foreach (var tarafVekil in taraf.AV001_TI_BIL_FOY_TARAF_VEKILCollection)
            //    {

            //        DataRepository.AV001_TI_BIL_FOY_TARAF_VEKILProvider.DeepLoad(tarafVekil, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
            //        if (tarafVekil.ICRA_FOY_ID.HasValue &&tarafVekil.ICRA_FOY_ID.Value==UypMyFoy.ID && tarafVekil.AVUKAT_CARI_IDSource != null)
            //        {
            //            if(UypMyFoy.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Where(vi=> vi.SORUMLU_AVUKAT_CARI_ID==tarafVekil.AVUKAT_CARI_ID).Count()<1)
            //            lstVekils.Add(tarafVekil);
            //        }
            //    }
            //    }

            //}

            if (lstVekils.Count > 0)
            {
                lstVekilKisi.AddRange(getVekilKisi(lstVekils));
            }
            return lstVekilKisi;
        }

        #endregion

        #region AlacakKalemi Bilgileri

        public enum AlacakKalemTipi
        {
            DigerAlacak, Kontrat, Hicbiri
        }

        List<alacakKalemKodlar> GetAlacakKalemAdi(AV001_TI_BIL_ALACAK_NEDEN aneden, AlacakKalemTipi kalemTipi, AV001_TI_BIL_FOY iFoy, AV001_TI_BIL_ILAM_MAHKEMESI ilam, bool? gecmisGunFaiziEkle)
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
                    //akkod.alacakKalemKodAciklama = Strings.AsilAlacak; //MB
                    //akkod.alacakKalemKodTip = "0";// Strings.AsilAlacakKalemKodTipi; MB
                    akkod.alacakKalemKodTuru = Strings.AsilAlacakKalemKodTuru;
                    //akkod.ilamliIlamsiz = "1";// Strings.AsilAlacakIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.ISLEME_KONAN_TUTAR);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.ISLEME_KONAN_TUTAR_DOVIZ_ID ?? 1);

                    returnValues.Add(akkod);
                }

                #endregion
                #region PROTESTO MASRAFI
                //protesto masrafý
                if (decimal.Zero != aneden.PROTESTO_GIDERI)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.ProtestoMasrafiKalemKod;
                    akkod.alacakKalemKodAciklama = Strings.ProtestoMasrafi; //MB
                    //akkod.alacakKalemKodTip = "0";// Strings.ProtestoMasrafiKodTipi; MB
                    akkod.alacakKalemKodTuru = Strings.ProtestoMasrafiKodTuru;
                    //akkod.ilamliIlamsiz = "1";//Strings.ProtestoMasrafiIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.PROTESTO_GIDERI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.PROTESTO_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region KOMÝSYON

                //komisyon
                if (aneden.KOMISYONU != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.KomisyonKod;
                    akkod.alacakKalemKodAciklama = "Komisyon";
                    //akkod.alacakKalemKodTip = "0";// Strings.KomisyonKodTip; MB
                    akkod.alacakKalemKodTuru = Strings.KomisyonKodTur;
                    //akkod.ilamliIlamsiz = "1";//Strings.KomisyonIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.KOMISYONU);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.KOMISYONU_DOVIZ_ID.Value);


                    returnValues.Add(akkod);
                }
                #endregion
                #region ÇEK TAZMÝNATI

                //çek tazminatý
                if (aneden.CEK_TAZMINATI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.CekTazminatiKod;
                    akkod.alacakKalemKodAciklama = Strings.CekTazminati; //MB
                    //akkod.alacakKalemKodTip = "0";// Strings.CekTazminatiKodTipi; MB
                    akkod.alacakKalemKodTuru = Strings.CekTazminatiKodTuru;
                    //akkod.ilamliIlamsiz = "1";//Strings.CekTazminatiIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.CEK_TAZMINATI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.CEK_TAZMINATI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region ÝHTAR GÝDERÝ

                //yeni alacak kalemi *IHTAR_GIDERI
                if (aneden.IHTAR_GIDERI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.YeniAlacakKalemiKod;
                    akkod.alacakKalemKodAciklama = Strings.YeniAlacakKalemi; //MB
                    //akkod.alacakKalemKodTip = Strings.YeniAlacakKalemiKodTipi; //MB
                    akkod.alacakKalemKodTuru = Strings.YeniAlacakKalemiKodTuru;
                    //akkod.ilamliIlamsiz = "1";//Strings.YeniAlacakKalemiIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.IHTAR_GIDERI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.IHTAR_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion
                #region BSMV TUTARI
                //bsmv
                if (aneden.BSMV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = Strings.BSMVKod;
                    akkod.alacakKalemKodAciklama = Strings.BSMV; //MB
                    //akkod.alacakKalemKodTip = "0";// Strings.BSMVKodTipi; MB
                    akkod.alacakKalemKodTuru = Strings.BSMVKodTuru;
                    //akkod.ilamliIlamsiz = "1";//Strings.BSMVIlam; MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.BSMV_TUTARI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.BSMV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }
                #endregion
                #region KKDF
                //kkdf
                if (aneden.KKDV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7179";
                    akkod.alacakKalemKodAciklama = "KKDF"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "0";
                    //akkod.ilamliIlamsiz = "1";// MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.KKDV_TUTARI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.KKDV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }
                #endregion
                #region KDV
                //kdv
                if (aneden.KDV_TUTARI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7180";
                    akkod.alacakKalemKodAciklama = "KDV"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "0";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.KDV_TUTARI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.KDV_TUTARI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }
                #endregion
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
                            if (faiz.BSMV_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7177") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7177");
                                    temp.Miktar = Format.ParaUyap(Convert.ToDecimal(temp.Miktar.Replace('.', ',')) + faiz.BSMV_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = Strings.BSMVKod;
                                    akkod.alacakKalemKodAciklama = Strings.BSMV; //MB
                                    //akkod.alacakKalemKodTip = "0";// Strings.BSMVKodTipi; MB
                                    akkod.alacakKalemKodTuru = Strings.BSMVKodTuru;
                                    //akkod.ilamliIlamsiz = "1";//Strings.BSMVIlam; MB
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(aneden.BSMV_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, aneden.BSMV_TUTARI_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }
                            if (faiz.KKDF_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7179") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7179");
                                    temp.Miktar += Format.ParaUyap(faiz.KKDF_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = "7179";
                                    akkod.alacakKalemKodAciklama = "KKDF"; //MB
                                    //akkod.alacakKalemKodTip = "0"; //MB
                                    akkod.alacakKalemKodTuru = "0";
                                    //akkod.ilamliIlamsiz = "1";// MB
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(aneden.KKDV_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, aneden.KKDV_TUTARI_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }
                            if (faiz.KDV_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7180") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7180");
                                    temp.Miktar = Format.ParaUyap(Convert.ToDecimal(temp.Miktar.Replace('.', ',')) + faiz.KDV_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = "7180";
                                    akkod.alacakKalemKodAciklama = "KDV"; //MB
                                    //akkod.alacakKalemKodTip = "0"; //MB
                                    akkod.alacakKalemKodTuru = "0";
                                    //akkod.ilamliIlamsiz = "1"; //MB
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(aneden.KDV_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, aneden.KDV_TUTARI_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }

                            if (faiz.FAIZ_TAKIPDEN_ONCE_MI == 1 && !faiz.ALACAK_NEDEN_TARAF_ID.HasValue)
                                faizler.Add(faiz);
                        }
                    }
                    else if (gecmisGunFaiziEkle.HasValue && gecmisGunFaiziEkle.Value) // true ise tüm alacak nedenlerinin altlarýndaki 
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(iFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>), typeof(TList<AV001_TI_BIL_FAIZ>));
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(iFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FAIZ>));

                        foreach (var faiz in iFoy.AV001_TI_BIL_FAIZCollection)
                        {
                            if (faiz.ICRA_ALACAK_NEDEN_ID != aneden.ID)
                                continue;
                            if (faiz.BSMV_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7177") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7177");
                                    temp.Miktar = Format.ParaUyap(Convert.ToDecimal(temp.Miktar.Replace('.', ',')) + faiz.BSMV_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = "7177";
                                    akkod.alacakKalemKodTuru = "0";
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(faiz.BSMV_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, faiz.BSMV_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }
                            if (faiz.KKDF_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7179") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7179");
                                    temp.Miktar += Format.ParaUyap(faiz.KKDF_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = "7179";
                                    akkod.alacakKalemKodTuru = "0";
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(faiz.KKDF_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, faiz.KKDF_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }
                            if (faiz.KDV_TUTARI != 0)
                            {
                                if (returnValues.Find(vi => vi.alacakKalemKod == "7180") != null)
                                {
                                    var temp = returnValues.Find(vi => vi.alacakKalemKod == "7180");
                                    temp.Miktar += Format.ParaUyap(faiz.KKDF_TUTARI);
                                }
                                else
                                {
                                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                                    akkod.alacakKalemKod = "7180";
                                    akkod.alacakKalemKodTuru = "0";
                                    akkod.Id = alacakKalemIdCounter;
                                    akkod.AlacakKalemID = aneden.ID;
                                    alacakKalemIdCounter++;
                                    //kalemin miktarýný para formatý ile verdik
                                    akkod.Miktar = Format.ParaUyap(faiz.KDV_TUTARI);
                                    //Doviz turunu ve acýklamasýný yazýyoruz    
                                    Format.DovizTurAd(akkod, faiz.KDV_DOVIZ_ID.Value);
                                    returnValues.Add(akkod);
                                }
                            }

                            if (faiz.FAIZ_TAKIPDEN_ONCE_MI == 1 && !faiz.ALACAK_NEDEN_TARAF_ID.HasValue)
                            {
                                faizler.Add(faiz);
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
                        //akkod.alacakKalemKodAciklama = "Geçmiþ Gün Faizi"; //MB
                        //akkod.alacakKalemKodTip = "0"; //MB
                        akkod.alacakKalemKodTuru = "2";
                        //akkod.ilamliIlamsiz = "1"; //MB
                        akkod.Id = alacakKalemIdCounter;
                        akkod.AlacakKalemID = aneden.ID;
                        alacakKalemIdCounter++;
                        //kalemin miktarýný para formatý ile verdik
                        akkod.Miktar = Format.ParaUyap(toplamPara.Para);
                        //Doviz turunu ve acýklamasýný yazýyoruz    
                        Format.DovizTurAd(akkod, toplamPara.DovizId);
                        returnValues.Add(akkod);
                    }
                }
                #endregion
                #region GECÝKME ZAMMI

                //gecikme zammý
                if (aneden.TAZMINATI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7184";
                    akkod.alacakKalemKodAciklama = "Gecikme Zammý"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "0";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.AlacakKalemID = aneden.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(aneden.TAZMINATI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, aneden.TAZMINATI_DOVIZ_ID.Value);
                    returnValues.Add(akkod);
                }
            }

                #endregion

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
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.IlamID = ilam.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.INKAR_TAZMINATI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.INKAR_TAZMINATI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region ÝLAM YARGILAMA GÝDERÝ
                //yeni alacak kalemi *ILAM_YARGILAMA_GIDERI
                if (ilam.YARGILAMA_GIDERI.HasValue && ilam.YARGILAMA_GIDERI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    akkod.IlamID = ilam.ID;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.YARGILAMA_GIDERI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.YARGILAMA_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }


                #endregion
                #region ÝLAM VEKALET ÜCRETÝ
                //yeni alacak kalemi *ILAM_VEK_UCR
                if (ilam.ILAM_VEKALET_UCRETI.HasValue && ilam.ILAM_VEKALET_UCRETI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.ILAM_VEKALET_UCRETI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.ILAM_VEKALET_UCRETI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }


                #endregion
                #region ÝLAM BAKÝYE YARGI ONAMA
                //yeni alacak kalemi *ILAM_BK_YARG_ONAMA 
                if (ilam.YARGITAY_ONAMA_HARCI.HasValue && ilam.YARGITAY_ONAMA_HARCI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.YARGITAY_ONAMA_HARCI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.YARGITAY_ONAMA_HARCI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion
                #region BAKÝYE KARAR HARCI

                if (ilam.BAKIYE_KARAR_HARCI.HasValue && ilam.BAKIYE_KARAR_HARCI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.BAKIYE_KARAR_HARCI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.BAKIYE_KARAR_HARCI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region ÝLAM TEBLÝÐ GÝDERÝ
                //yeni alacak kalemi *ILAM_TEBLIG_GIDERI 
                if (ilam.ILAM_TEBLIG_GIDERI.HasValue && ilam.ILAM_TEBLIG_GIDERI.Value != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.IlamID = ilam.ID;
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(ilam.ILAM_TEBLIG_GIDERI.Value);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, ilam.ILAM_TEBLIG_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }


                #endregion

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

                //    //kalemin miktarýný para formatý ile verdik
                //    akkod.Miktar = Format.ParaUyap(ilamFaizToplami);
                //    //Doviz turunu ve acýklamasýný yazýyoruz    
                //    Format.DovizTurAd(akkod, inlamFaizid);
                //    returnValues.Add(akkod);
                //} 
                #endregion

                #endregion
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
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.IH_VEKALET_UCRETI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.IH_VEKALET_UCRETI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region ÝH GÝDERÝ
                //yeni alacak kalemi *IH_GIDERI 
                if (iFoy.IH_GIDERI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7173";
                    akkod.alacakKalemKodAciklama = "ihtiyati Haciz masrafý"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "0";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.IH_GIDERI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.IH_GIDERI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion
                #region ÝT HACÝZDEN ÖDENEN
                //yeni alacak kalemi *IT_HACIZDE_ODENEN 
                if (iFoy.IT_HACIZDE_ODENEN != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.IT_HACIZDE_ODENEN);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.IT_HACIZDE_ODENEN_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion
                #region ÖZEL TUTAR 1
                //yeni alacak kalemi *OZEL_TUTAR1 
                if (iFoy.OZEL_TUTAR1 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.OZEL_TUTAR1);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR1_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion
                #region ÖZEL TUTAR 2
                //yeni alacak kalemi *OZEL_TUTAR2 
                if (iFoy.OZEL_TUTAR2 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.OZEL_TUTAR2);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR2_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }


                #endregion                //yeni alacak kalemi *OZEL_TUTAR3
                #region ÖZEL TUTAR 3

                if (iFoy.OZEL_TUTAR3 != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.OZEL_TUTAR3);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.OZEL_TUTAR3_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
                #region MAHSUP TOPLAMI
                //yeni alacak kalemi *MAHSUP_TOPLAMI 
                if (iFoy.MAHSUP_TOPLAMI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.MAHSUP_TOPLAMI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.MAHSUP_TOPLAMI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }

                #endregion                //yeni alacak kalemi *TO_ODEME_TOPLAMI
                #region TÖ ÖDEME TOPLAMI
                if (iFoy.TO_ODEME_TOPLAMI != decimal.Zero)
                {
                    alacakKalemKodlar akkod = new alacakKalemKodlar();
                    akkod.FoydenMi = true;
                    akkod.FoyID = iFoy.ID;
                    akkod.alacakKalemKod = "7937";
                    akkod.alacakKalemKodAciklama = "yeni alacak kalemi"; //MB
                    //akkod.alacakKalemKodTip = "0"; //MB
                    akkod.alacakKalemKodTuru = "1";
                    //akkod.ilamliIlamsiz = "1"; //MB
                    akkod.Id = alacakKalemIdCounter;
                    alacakKalemIdCounter++;
                    //kalemin miktarýný para formatý ile verdik
                    akkod.Miktar = Format.ParaUyap(iFoy.TO_ODEME_TOPLAMI);
                    //Doviz turunu ve acýklamasýný yazýyoruz    
                    Format.DovizTurAd(akkod, iFoy.TO_ODEME_TOPLAMI_DOVIZ_ID.Value);

                    returnValues.Add(akkod);
                }
                #endregion
            }
            return returnValues;
        }

        List<AlacakKalemi> GetKalem(List<alacakKalemKodlar> kalemler, AlacakKalemTipi kalemtipi, AV001_TI_BIL_ALACAK_NEDEN aneden)
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
                    AlacakKalem.alacakKalemAdi = kalemler[i].alacakKalemKodAciklama; //MB
                    //if (AlacakKalem.alacakKalemAdi != "Geçmiþ Gün Faizi")

                    //AlacakKalem.aciklama = aneden.DIGER_ALACAK_NEDENI; //Eski programgda Diðer Alacak Nedeni açýklamaya geliyor

                    //todo : eski programda yok.
                    //AlacakKalem.alacakKalemIlkTutar = Format.ParaUyap(aneden.ISLEME_KONAN_TUTAR);
                    AlacakKalem.alacakKalemKod = kalemler[i].alacakKalemKod;
                    // AlacakKalem.alacakKalemKodAciklama = "";
                    AlacakKalem.alacakKalemKodTuru = kalemler[i].alacakKalemKodTuru;
                    //AlacakKalem.alacakKalemKodTip = kalemler[i].alacakKalemKodTip; //MB
                    //  AlacakKalem.alacakKalemTutar=lstAlacakNeden[i].K;
                    //AlacakKalem.dovizKurCevrimi =/;

                    //AlacakKalem.sabitTaksitTarihi = DateTime.Now;//=aneden.VADE_TARIHI.Value.tos.sa;
                    AlacakKalem.alacakKalemTutar = AlacakKalem.alacakKalemIlkTutar = kalemler[i].Miktar.ToString();
                    AlacakKalem.tutarAdi = kalemler[i].DovizAdi;
                    AlacakKalem.tutarTur = kalemler[i].DovizTuru.Trim();
                    //AlacakKalem.ilamliIlamsiz = kalemler[i].ilamliIlamsiz; //MB
                    //AlacakKalem.alacakKalemKodAciklama = kalemler[i].alacakKalemKodAciklama; MB
                    //AlacakKalem.alacakKalemKodTip = kalemler[i].alacakKalemKodTip; MB

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
                    ///

                    int? formTipID = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(aneden.ICRA_FOY_ID.Value).FORM_TIP_ID;
                    if (formTipID.HasValue)
                    {
                        #region MASRAF ALACAÐI

                        if (kalemler[i].alacakKalemKodTuru == "0")
                        {
                            switch (formTipID.Value)
                            {
                                case (int)AvukatProLib.Extras.FormTipleri.Form151:
                                case (int)AvukatProLib.Extras.FormTipleri.Form152:
                                case (int)AvukatProLib.Extras.FormTipleri.Form50:
                                case (int)AvukatProLib.Extras.FormTipleri.Form201:
                                    AlacakKalem.alacakKalemAdi = "Diðer Masraf Alacaðý";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form49:
                                case (int)AvukatProLib.Extras.FormTipleri.Form153:
                                    AlacakKalem.alacakKalemAdi = "Diðer Masraf Alacaðý";
                                    break;
                                default:
                                    break;
                            }
                        }
                        #endregion
                        #region ASIL ALACAK

                        if (kalemler[i].alacakKalemKodTuru == "1")
                        {
                            switch (formTipID.Value)
                            {
                                case (int)AvukatProLib.Extras.FormTipleri.Form151:
                                case (int)AvukatProLib.Extras.FormTipleri.Form152:
                                case (int)AvukatProLib.Extras.FormTipleri.Form50:
                                case (int)AvukatProLib.Extras.FormTipleri.Form201:
                                    AlacakKalem.aciklama = "Asýl Alacak";
                                    AlacakKalem.alacakKalemAdi = "Diðer Asýl Alacaðý";
                                    AlacakKalem.alacakKalemKod = "3";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form49:
                                case (int)AvukatProLib.Extras.FormTipleri.Form153:
                                    AlacakKalem.aciklama = "Asýl Alacak";
                                    AlacakKalem.alacakKalemAdi = "Diðer Asýl Alacaðý";
                                    AlacakKalem.alacakKalemKod = "3";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form53:
                                    AlacakKalem.aciklama = "ilamlý alacak";
                                    AlacakKalem.alacakKalemAdi = "Asýl Alacak";
                                    AlacakKalem.alacakKalemKod = "7168";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form51:
                                    AlacakKalem.aciklama = "Asýl alacak";
                                    AlacakKalem.alacakKalemAdi = "Kontrat Asýl Alacaðý";
                                    AlacakKalem.alacakKalemKod = "2";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form163:
                                case (int)AvukatProLib.Extras.FormTipleri.Form52:
                                    AlacakKalem.alacakKalemAdi = "Asýl Alacak";
                                    AlacakKalem.alacakKalemKod = "7168";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form54:
                                    AlacakKalem.aciklama = aneden.DIGER_ALACAK_NEDENI;
                                    AlacakKalem.alacakKalemAdi = "Asýl Alacak";
                                    AlacakKalem.alacakKalemKod = "7168";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form55:
                                    AlacakKalem.aciklama = aneden.DIGER_ALACAK_NEDENI;
                                    break;
                                default:
                                    break;
                            }
                        }

                        #endregion
                        #region FAÝZ ALACAÐI

                        if (kalemler[i].alacakKalemKodTuru == "2")
                        {
                            switch (formTipID.Value)
                            {
                                case (int)AvukatProLib.Extras.FormTipleri.Form151:
                                case (int)AvukatProLib.Extras.FormTipleri.Form152:
                                case (int)AvukatProLib.Extras.FormTipleri.Form50:
                                case (int)AvukatProLib.Extras.FormTipleri.Form201:
                                    AlacakKalem.aciklama = "Geçmiþ Gün Faizi";
                                    AlacakKalem.alacakKalemAdi = "Diðer Faiz Alacaðý";
                                    AlacakKalem.alacakKalemKod = "6";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form49:
                                case (int)AvukatProLib.Extras.FormTipleri.Form153:
                                    AlacakKalem.aciklama = "Geçmiþ Gün Faizi";
                                    AlacakKalem.alacakKalemAdi = "Diðer Faiz Alacaðý";
                                    AlacakKalem.alacakKalemKod = "6";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form53:
                                case (int)AvukatProLib.Extras.FormTipleri.Form163:
                                case (int)AvukatProLib.Extras.FormTipleri.Form52:
                                    AlacakKalem.alacakKalemAdi = "Geçmiþ Gün Faizi";
                                    AlacakKalem.alacakKalemKod = "7183";
                                    break;
                                case (int)AvukatProLib.Extras.FormTipleri.Form51:
                                    AlacakKalem.aciklama = "Geçmiþ Gün Faizi";
                                    AlacakKalem.alacakKalemAdi = "Kontrat Faiz Alacaðý";
                                    AlacakKalem.alacakKalemKod = "9";
                                    break;
                                default:
                                    break;
                            }
                        }
                        #endregion
                    }
                    //AlacakKalem.alacakKalemKodAciklama = AlacakKalem.aciklama; MB

                    returnValues.Add(AlacakKalem);
                }
            }
            return returnValues;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aneden"></param>
        /// <param name="kalemTipi"></param>
        /// <param name="ilam"></param>
        /// <param name="gecmisGunFaiziHesaplansin"><
        /// true = alacak nedenine ait faiz kalemlerini yazar
        /// false = hiç yazmaz 
        /// null = föye baðlý bütün faiz kalmelerini yazar
        /// /param>
        /// <returns></returns>
        List<AlacakKalemi> GetAlacakKalemi(AV001_TI_BIL_ALACAK_NEDEN aneden, AV001_TI_BIL_FOY icraFoy, AlacakKalemTipi kalemTipi, AV001_TI_BIL_ILAM_MAHKEMESI ilam, bool? gecmisGunFaiziHesaplansin)
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

        public List<AlacakKalemi> GetAlacakKalemleri(AvukatProLib2.Entities.AV001_TI_BIL_ILAM_MAHKEMESI ilam)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(ilam, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_FOY));
            AV001_TI_BIL_FOY myFoy = null;
            if (ilam.ICRA_FOY_ID.HasValue)
            {
                myFoy = ilam.ICRA_FOY_IDSource;
            }

            List<AlacakKalemi> returnValues = new List<AlacakKalemi>();

            List<AlacakKalemi> AlacakKalem = null;// GetAlacakKalemi(null, AlacakKalemTipi.Hicbiri, ilam);

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

        public List<ParaylaOlculemeyenAlacak> GetParaylaOlculemeyenAlacaklar(AV001_TI_BIL_FOY myFoy)
        {
            List<ParaylaOlculemeyenAlacak> returnValues = new List<ParaylaOlculemeyenAlacak>();

            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));

            foreach (var alacak in myFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
            {
                ParaylaOlculemeyenAlacak item = new ParaylaOlculemeyenAlacak();

                if (string.IsNullOrEmpty(alacak.DIGER_ALACAK_NEDENI))
                    alacak.DIGER_ALACAK_NEDENI = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(alacak.ALACAK_NEDEN_KOD_ID.Value).ALACAK_NEDENI;
                item.aciklama = alacak.DIGER_ALACAK_NEDENI;
                item.id = "paraylaOlculemeyenAlacak_" + alacak.ID.ToString();

                returnValues.Add(item);
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
        /// <param name="aneden</param>
        /// <param name="gecmisGunFaiziHesaplansin">
        /// true = alacak nedenine ait faiz kalemlerini yazar
        /// false = hiç yazmaz 
        /// null = föye baðlý bütün faiz kalmelerini yazar
        /// </param>
        /// <returns></returns>
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

        bool AlacakKalemiVarmi(AV001_TI_BIL_ALACAK_NEDEN akalem)
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

        public List<DigerAlacak> GetDigerAlacaklar(per_AV001_TI_BIL_ICRA_Arama Foy)
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

                    //Aþaðýdaki satýrlar test amaçlý kapatýldý ve aþaðýdaki bir satýr kod eklendi. Sorun çýkarsa eski haline döndürülecek. MB
                    //Eski haline döndürüldü. MB
                    //
                    //dAlacak.alacakNo = "";
                    if (!aNeden.DIGER_ALACAK_NEDENI.Contains("DÝÐER ALACAK..."))
                        dAlacak.digerAlacakAciklama = aNeden.DIGER_ALACAK_NEDENI;
                    else
                        dAlacak.digerAlacakAciklama = String.Empty;
                    //

                    //UYAP'taki sorun giderildiðinden aþaðýdaki bir satýr kod iptal edildi. MB
                    //dAlacak.digerAlacakAciklama = DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(SetAlacakNedenID(Foy.FORM_TIP_ID.Value, aNeden.ALACAK_NEDEN_KOD_ID.Value)).ALACAK_NEDENI;

                    dAlacak.Id = "digerAlacak_" + aNeden.ID.ToString();
                    dAlacak.tarih = Format.Tarih(aNeden.KAYIT_TARIHI);
                    dAlacak.tutar = Format.ParaUyap(aNeden.TUTARI);

                    if (aNeden.TUTAR_DOVIZ_ID.HasValue)
                    {
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(aNeden.TUTAR_DOVIZ_ID.Value);
                        dAlacak.tutarAdi = dovizTip.UYAP_ACIKLAMA;
                        dAlacak.tutarTur = dovizTip.UYAP_KODU.Trim();
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

        bool AlacakKalemiKontrol(string kalem, alacakKalemKodlar akkod)
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

        #endregion

        #region Faiz bilgileri
        
        //dosyadaki tum faizler burada tutulur. Her dosya deðiþtiðinde bu list new olur... 
        List<Faiz> faizler = new List<Faiz>();
        /// <summary>
        /// ayný fazin iki kez yazýlmamasý için burada tum sistemdeki faizleri tutuyorz ve boylece bir faiz bir kere yzýlmasý için kontrol yapýyoruz
        /// </summary>
        /// <param name="myFaiz">aranan faiz</param>
        /// <returns>sonuc varsa evet yoksa hayýr </returns>
        bool FaizlerdeVarmi(Faiz myFaiz)
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

                    fz.faizOran = Convert.ToDecimal(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_ORANI);
                    fz.faizSureTip = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_KOD;
                    fz.faizTipKodAciklama = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_ACIKLAMA;
                    fz.faizTutar = Decimal.Round(AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI, 2);
                    fz.faizTutarTur = AlacakNeden.ICRA_FOY_IDSource.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_KODU.Trim(); // TODO:
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

                    fz.faizOran = Convert.ToDecimal(AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_ORANI);
                    fz.faizSureTip = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_KOD;
                    fz.faizTipKodAciklama = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TIP_IDSource.UYAP_ACIKLAMA;
                    fz.faizTutar = Decimal.Round(AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI, 2);
                    fz.faizTutarTur = AlacakNeden.AV001_TI_BIL_FAIZCollection[i].FAIZ_TUTARI_DOVIZ_IDSource.UYAP_KODU.Trim(); // TODO:
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

        #endregion

        #region REf

        public List<Ref> getRef(AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN AlacakNeden)
        {
            List<Ref> returnValue = new List<Ref>();
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(AlacakNeden, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
            for (int i = 0; i < AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.Count; i++)
            {
                Ref rf = new Ref();
                rf.to = "taraf";
                rf.id = Strings.taraf + UyapSiraNo + AlacakNeden.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection[i].TARAF_CARI_ID.ToString();
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
                rf.id = Strings.taraf + UyapSiraNo + KiymetliEvrak.AV001_TDI_BIL_KIYMETLI_EVRAK_TARAFCollection[i].TARAF_CARI_ID.ToString();
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
                rf.id = Strings.taraf + UyapSiraNo + Sozlesme.AV001_TDI_BIL_SOZLESME_TARAFCollection[i].CARI_ID.ToString();
                returnValue.Add(rf);
            }
            return returnValue;
        }

        #endregion

        #region Kiymetli Evrak

        public List<Police> GetPolice(per_AV001_TI_BIL_ICRA_Arama Foyum)
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
                        pol.belgeninTutari = Format.ParaUyap(lstKiymetliEvraks[y].TUTAR);
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
                        //pol.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI; //Hukuk ailesinde olmadýðýndan kapatýldý. MB
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        pol.tutarAdi = dovizTip.UYAP_ACIKLAMA;
                        pol.tutarTur = dovizTip.UYAP_KODU.Trim(); // TODO : 
                        pol.uzerindekiPulunDegeri = Format.ParaUyap(alacakNeden.DAMGA_PULU); // TODO  : 
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

        public List<Cek> GetCek(per_AV001_TI_BIL_ICRA_Arama Foyum)
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
                        ck.tutar = Format.ParaUyap(lstKiymetliEvraks[y].TUTAR);
                        TDI_KOD_DOVIZ_TIP doviztip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        ck.tutarTur = doviztip.UYAP_KODU.Trim();   // TODO : 
                        ck.tutarTurAciklama = doviztip.UYAP_ACIKLAMA; // TODO : 

                        ck.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

                        returnValues.Add(ck);
                    }
                }
            }
            return returnValues;
        }

        /// <summary>
        /// verilen dizideki sadece sayýlarý döndürür
        /// Z12423-1 => 124231
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

        public List<Senet> GetSenet(per_AV001_TI_BIL_ICRA_Arama Foyum)
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
                        sen.belgeninTutari = Format.ParaUyap(lstKiymetliEvraks[y].TUTAR);
                        sen.Id = "sen_" + lstKiymetliEvraks[y].ID.ToString();
                        sen.islemlerBasladimi = (lstKiymetliEvraks[y].ISLEMLER_BASLADIMI == true ? "E" : "H");
                        sen.odemeYeri = lstKiymetliEvraks[y].ODEME_YERI;
                        //sen.olmasiGrknPulDegeri = ""; //Hukuk ailesinde olmadýðýndan kapatýldý. MB
                        if (lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI.HasValue)
                        {
                            sen.tanzimTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_TANZIM_TARIHI);
                        }

                        //sen.tanzimYeri = lstKiymetliEvraks[y].KESIDE_YERI; //Hukuk ailesinde olmadýðýndan kapatýldý. MB
                        TDI_KOD_DOVIZ_TIP dovizTip = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(lstKiymetliEvraks[y].TUTAR_DOVIZ_ID.Value);
                        sen.tutarAdi = dovizTip.UYAP_ACIKLAMA; // TODO : 
                        sen.tutarTur = dovizTip.UYAP_KODU.Trim(); // TODO :
                        //sen.uzerindekiPulunDegeri = alacakNeden.DAMGA_PULU.ToString(); //Hukuk ailesinde olmadýðýndan kapatýldý. MB
                        if (lstKiymetliEvraks[y].EVRAK_VADE_TARIHI.HasValue)
                        {
                            sen.vadeTarihi = Format.Tarih(lstKiymetliEvraks[y].EVRAK_VADE_TARIHI);
                        }

                        sen.alacakKalemi = GetAlacakKalemleri(lstKiymetliEvraks[y]);

                        foreach (var item in sen.alacakKalemi)
                        {
                            if (item.aciklama == "BONO") item.aciklama = "SENET";
                        }

                        returnValues.Add(sen);
                    }
                }
            }
            return returnValues;
        }

        public List<Ilam> GetIlamlar(per_AV001_TI_BIL_ICRA_Arama Foy)
        {
            List<Ilam> returnValues = new List<Ilam>();
            AV001_TI_BIL_FOY Foyum = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Foy.ID);

            //Hukuk ailesinde 56 form tipinde ilam tagi görünmediðinden, sadece diðer alacak tagi þeklinde göründüðünden bu þekilde yapýldý. MB
            if (Foyum.FORM_TIP_ID.Value == (int)AvukatProLib.Extras.FormTipleri.Form56) return returnValues;

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

                #endregion

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

                #endregion

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

                //if (Foyum.FORM_TIP_ID.Value == (int)AvukatProLib.Extras.FormTipleri.Form55 || Foyum.FORM_TIP_ID.Value == (int)AvukatProLib.Extras.FormTipleri.Form54)
                ilm.paraylaOlculemeyenAlacak = GetParaylaOlculemeyenAlacaklar(Foyum);
                //else
                ilm.alacakKalemi = GetAlacakKalemleri(Foyum.AV001_TI_BIL_ILAM_MAHKEMESICollection[i]);

                returnValues.Add(ilm);
            }
            return returnValues;
        }

        #endregion
    }

    public static class Format
    {
        public static string ParaUyap(decimal para)
        {
            return para.ToString("##############0.00").Replace(',', '.');
        }
        static List<TDI_KOD_DOVIZ_TIP> _DovizSource;
        public static List<TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = new List<TDI_KOD_DOVIZ_TIP>(DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll());
                return _DovizSource;
            }
        }

        public static TDI_KOD_DOVIZ_TIP GetDovizIdSource(int id)
        {
            var dovizTip = DovizSource.Where(vi => vi.ID == id);
            return dovizTip.Count() > 0 ? dovizTip.First() : null;
        }
        public static void DovizTurAd(alacakKalemKodlar kalem, int DovizId)
        {
            kalem.DovizAdi = GetDovizIdSource(DovizId).UYAP_ACIKLAMA;
            kalem.DovizTuru = GetDovizIdSource(DovizId).UYAP_KODU;
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

}