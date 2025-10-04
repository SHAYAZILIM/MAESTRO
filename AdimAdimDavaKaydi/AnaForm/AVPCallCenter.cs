using AvukatProLib.Hesap.Views;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AdimAdimDavaKaydi.AnaForm
{
    public static class ControlExtensions
    {
    }

    internal class AVPCallCenter
    {
        private string IpadressServer = "192.9.0.12";

        public void EskiGorusmeDoldur(UserControls.IcraTakipUserControls.ucGorusmeler ucGorusme, AvukatProLib.Extras.ModulTip mdl, string foyId, string cariId)
        {
            if (foyId != "")
            {
                TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMEs = new TList<AV001_TDI_BIL_GORUSME>();
                switch (mdl)
                {
                    case AvukatProLib.Extras.ModulTip.Dava:
                        myAV001_TDI_BIL_GORUSMEs = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByDAVA_FOY_ID(Convert.ToInt32(foyId));
                        break;

                    case AvukatProLib.Extras.ModulTip.Icra:

                        myAV001_TDI_BIL_GORUSMEs = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByICRA_FOY_ID(Convert.ToInt32(foyId));
                        break;

                    case AvukatProLib.Extras.ModulTip.Sorusturma:
                        myAV001_TDI_BIL_GORUSMEs = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByHAZIRLIK_ID(Convert.ToInt32(foyId));
                        break;

                    default:
                        break;
                }

                ucGorusme.MyDataSource = myAV001_TDI_BIL_GORUSMEs;
            }
            else if (cariId != "")
            {
                TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMEs = new TList<AV001_TDI_BIL_GORUSME>();
                myAV001_TDI_BIL_GORUSMEs = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByGORUSULEN_CARI_ID(Convert.ToInt32(cariId));
                ucGorusme.MyDataSource = myAV001_TDI_BIL_GORUSMEs;
            }
        }

        public XmlDocument forVoipXmlCreator(string _hedef, string _kaynak, string _davetEdilen, string _cagriTipi)
        {
            XmlDocument xmldoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            XmlElement xmlelem2;
            XmlElement xmlelem3;
            XmlElement xmlelem4;
            XmlElement xmlelem5;
            XmlElement xmlelem6;
            XmlElement xmlelem7;
            XmlElement xmlelem8;
            XmlElement xmlelem9;
            XmlElement xmlelem10;
            XmlElement xmlelem11;
            XmlElement xmlelem12;
            XmlElement xmlelem13;
            XmlElement xmlelem14;
            XmlElement xmlelem15;
            XmlElement xmlelem16;
            XmlElement xmlelem17;
            XmlElement xmlelem18;
            XmlElement xmlelem19;
            XmlElement xmlelem20;
            XmlElement xmlelem21;

            XmlText xmltext;

            xmldoc = new XmlDocument();
            xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmldoc.AppendChild(xmlnode);

            xmlelem = xmldoc.CreateElement("", "PBX", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem.AppendChild(xmltext);
            xmldoc.AppendChild(xmlelem);

            xmlelem2 = xmldoc.CreateElement("", "Cagri", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem2.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem2);

            xmlelem16 = xmldoc.CreateElement("", "Id", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem16.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem16);

            if (_cagriTipi == "19")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else if (_cagriTipi == "20")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else if (_cagriTipi == "10")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else if (_cagriTipi == "16")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            xmlelem15 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem15.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem15);

            xmlelem13 = xmldoc.CreateElement("", "CagriTipi", "");
            xmltext = xmldoc.CreateTextNode(_cagriTipi);
            xmlelem13.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem13);

            xmlelem6 = xmldoc.CreateElement("", "BaslangicTarih", "");
            xmltext = xmldoc.CreateTextNode("12345");
            xmlelem6.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem6);

            xmlelem7 = xmldoc.CreateElement("", "BaslangicSaat", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem7.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem7);

            xmlelem8 = xmldoc.CreateElement("", "KayitUrl", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem8.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem8);

            xmlelem9 = xmldoc.CreateElement("", "BitisTarih", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem9.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem9);

            xmlelem10 = xmldoc.CreateElement("", "BitisSaat", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem10.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem10);

            xmlelem21 = xmldoc.CreateElement("", "KabulBilgisi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem21.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem21);

            xmlelem3 = xmldoc.CreateElement("", "Yonlendir", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem3.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem3);

            xmlelem20 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem20.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem20);

            xmlelem17 = xmldoc.CreateElement("", "Yonlendiren", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem17.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem17);

            xmlelem11 = xmldoc.CreateElement("", "Yonlendirilen", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem11.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem11);

            xmlelem4 = xmldoc.CreateElement("", "Konferans", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem4.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem4);

            xmlelem19 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem19.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem19);

            if (_cagriTipi == "19")
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode(_davetEdilen);
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }
            else if (_cagriTipi == "20")
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode(_davetEdilen);
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }
            else
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }

            return xmldoc;
        }

        public XmlDocument forVoipXmlCreatorIkinciCagri(string _hedef, string _kaynak, string _davetEdilen, string _cagriTipi, string s)
        {
            XmlDocument xmldoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            XmlElement xmlelem2;
            XmlElement xmlelem3;
            XmlElement xmlelem4;
            XmlElement xmlelem5;
            XmlElement xmlelem6;
            XmlElement xmlelem7;
            XmlElement xmlelem8;
            XmlElement xmlelem9;
            XmlElement xmlelem10;
            XmlElement xmlelem11;
            XmlElement xmlelem12;
            XmlElement xmlelem13;
            XmlElement xmlelem14;
            XmlElement xmlelem15;
            XmlElement xmlelem16;
            XmlElement xmlelem17;
            XmlElement xmlelem18;
            XmlElement xmlelem19;
            XmlElement xmlelem20;
            XmlElement xmlelem21;

            XmlText xmltext;

            xmldoc = new XmlDocument();
            xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmldoc.AppendChild(xmlnode);

            xmlelem = xmldoc.CreateElement("", "PBX", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem.AppendChild(xmltext);
            xmldoc.AppendChild(xmlelem);

            xmlelem2 = xmldoc.CreateElement("", "Cagri", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem2.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem2);

            xmlelem16 = xmldoc.CreateElement("", "Id", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem16.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem16);

            if (_cagriTipi == "19")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else if (_cagriTipi == "20")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else if (_cagriTipi == "10")
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }
            else
            {
                xmlelem5 = xmldoc.CreateElement("", "Kaynak", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem5.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem5);

                xmlelem14 = xmldoc.CreateElement("", "Hedef", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem14.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem14);
            }

            xmlelem15 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem15.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem15);

            xmlelem13 = xmldoc.CreateElement("", "CagriTipi", "");
            xmltext = xmldoc.CreateTextNode(_cagriTipi);
            xmlelem13.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem13);

            xmlelem6 = xmldoc.CreateElement("", "BaslangicTarih", "");
            xmltext = xmldoc.CreateTextNode("12345");
            xmlelem6.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem6);

            xmlelem7 = xmldoc.CreateElement("", "BaslangicSaat", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem7.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem7);

            xmlelem8 = xmldoc.CreateElement("", "KayitUrl", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem8.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem8);

            xmlelem9 = xmldoc.CreateElement("", "BitisTarih", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem9.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem9);

            xmlelem10 = xmldoc.CreateElement("", "BitisSaat", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem10.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem10);

            xmlelem21 = xmldoc.CreateElement("", "KabulBilgisi", "");
            xmltext = xmldoc.CreateTextNode(s);
            xmlelem21.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(1).AppendChild(xmlelem21);

            xmlelem3 = xmldoc.CreateElement("", "Yonlendir", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem3.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem3);

            xmlelem20 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem20.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem20);

            xmlelem17 = xmldoc.CreateElement("", "Yonlendiren", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem17.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem17);

            xmlelem11 = xmldoc.CreateElement("", "Yonlendirilen", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem11.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(2).AppendChild(xmlelem11);

            xmlelem4 = xmldoc.CreateElement("", "Konferans", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem4.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).AppendChild(xmlelem4);

            xmlelem19 = xmldoc.CreateElement("", "KanalAdi", "");
            xmltext = xmldoc.CreateTextNode("");
            xmlelem19.AppendChild(xmltext);
            xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem19);

            if (_cagriTipi == "19")
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode(_hedef);
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode(_davetEdilen);
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }
            else if (_cagriTipi == "20")
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode(_kaynak);
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode(_davetEdilen);
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }
            else
            {
                xmlelem12 = xmldoc.CreateElement("", "DavetEden", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem12.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem12);

                xmlelem18 = xmldoc.CreateElement("", "DavetEdilen", "");
                xmltext = xmldoc.CreateTextNode("");
                xmlelem18.AppendChild(xmltext);
                xmldoc.ChildNodes.Item(1).ChildNodes.Item(3).AppendChild(xmlelem18);
            }

            return xmldoc;
        }

        public void GorusmeKaydet(AdimAdimDavaKaydi.UserControls.ucGorusmeKayit uckayit)
        {
            TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMESs = new TList<AV001_TDI_BIL_GORUSME>();
            myAV001_TDI_BIL_GORUSMESs = uckayit.MyDataSource;
            foreach (AV001_TDI_BIL_GORUSME item in myAV001_TDI_BIL_GORUSMESs)
            {
                if (item != null)
                {
                    // item.IS_KATEGORI  GÖRÜŞME LİNKİNİ TUTACAZ
                    item.GORUSME_SURE = (item.BITIS_TARIH - item.TARIH).ToString();
                    DataRepository.AV001_TDI_BIL_GORUSMEProvider.DeepSave(item);
                }
            }
        }

        public void gorusmeKayitDoldur(AdimAdimDavaKaydi.UserControls.ucGorusmeKayit uckayit, string foyId, string Tipi, string Tel, string gorusulen, int gorusmeYonu, AdimAdimDavaKaydi.UserControls.ucIcraHesapCetveli ucicraHesap)
        {
            ucicraHesap.MyFoyDataSource = new AV001_TI_BIL_FOY();
            uckayit.MyDataSource = new TList<AV001_TDI_BIL_GORUSME>();
            switch (Tipi)
            {
                case "İCRA":
                    AV001_TI_BIL_FOY myAV001_TI_BIL_FOY = new AV001_TI_BIL_FOY();
                    myAV001_TI_BIL_FOY = AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.GetByID(Convert.ToInt32(foyId));
                    TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMEIs = new TList<AV001_TDI_BIL_GORUSME>();

                    AV001_TDI_BIL_GORUSME myAV001_TDI_BIL_GORUSMEI = new AV001_TDI_BIL_GORUSME();

                    myAV001_TDI_BIL_GORUSMEI.ICRA_FOY_ID = myAV001_TI_BIL_FOY.ID;
                    myAV001_TDI_BIL_GORUSMEI.ICRA_FOY_NO = myAV001_TI_BIL_FOY.FOY_NO_Sayi;
                    myAV001_TDI_BIL_GORUSMEI.TARIH = DateTime.Now;
                    myAV001_TDI_BIL_GORUSMEI.IS_KATEGORI_ID = 493;
                    myAV001_TDI_BIL_GORUSMEI.GORUSME_YONU = (byte)gorusmeYonu;
                    myAV001_TDI_BIL_GORUSMEI.GORUSEN_CARI_ID = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
                    myAV001_TDI_BIL_GORUSMEI.GORUSEN_TEL = "1007";
                    myAV001_TDI_BIL_GORUSMEI.GORUSULEN_TEL = Tel;
                    myAV001_TDI_BIL_GORUSMEI.GORUSULEN_CARI_ID = Convert.ToInt32(gorusulen);

                    myAV001_TDI_BIL_GORUSMEIs.Add(myAV001_TDI_BIL_GORUSMEI);
                    uckayit.ModulTipi = AvukatProLib.Extras.ModulTip.Icra;
                    uckayit.MyDataSource = myAV001_TDI_BIL_GORUSMEIs;
                    ucicraHesap.MyFoyDataSource = myAV001_TI_BIL_FOY;

                    break;

                case "DAVA":
                    AV001_TD_BIL_FOY myAV001_TD_BIL_FOY = new AV001_TD_BIL_FOY();
                    myAV001_TD_BIL_FOY = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_FOYProvider.GetByID(Convert.ToInt32(foyId));
                    TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMEDs = new TList<AV001_TDI_BIL_GORUSME>();

                    AV001_TDI_BIL_GORUSME myAV001_TDI_BIL_GORUSMED = new AV001_TDI_BIL_GORUSME();

                    myAV001_TDI_BIL_GORUSMED.DAVA_FOY_ID = myAV001_TD_BIL_FOY.ID;
                    myAV001_TDI_BIL_GORUSMED.DAVA_FOY_NO = myAV001_TD_BIL_FOY.FOY_NO_Sayi;
                    myAV001_TDI_BIL_GORUSMED.TARIH = DateTime.Now;
                    myAV001_TDI_BIL_GORUSMED.IS_KATEGORI_ID = 493;
                    myAV001_TDI_BIL_GORUSMED.GORUSME_YONU = (byte)gorusmeYonu;
                    myAV001_TDI_BIL_GORUSMED.GORUSEN_CARI_ID = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
                    myAV001_TDI_BIL_GORUSMED.GORUSEN_TEL = "1007";
                    myAV001_TDI_BIL_GORUSMED.GORUSULEN_TEL = Tel;
                    myAV001_TDI_BIL_GORUSMED.GORUSULEN_CARI_ID = Convert.ToInt32(gorusulen);
                    myAV001_TDI_BIL_GORUSMEDs.Add(myAV001_TDI_BIL_GORUSMED);
                    uckayit.ModulTipi = AvukatProLib.Extras.ModulTip.Dava;
                    uckayit.MyDataSource = myAV001_TDI_BIL_GORUSMEDs;

                    break;

                case "SORUŞTURMA":

                    AV001_TD_BIL_HAZIRLIK myAV001_TD_BIL_HAZIRLIK = new AV001_TD_BIL_HAZIRLIK();
                    myAV001_TD_BIL_HAZIRLIK = AvukatProLib2.Data.DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(Convert.ToInt32(foyId));

                    TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMESs = new TList<AV001_TDI_BIL_GORUSME>();

                    AV001_TDI_BIL_GORUSME myAV001_TDI_BIL_GORUSMES = new AV001_TDI_BIL_GORUSME();

                    myAV001_TDI_BIL_GORUSMES.HAZIRLIK_ID = myAV001_TD_BIL_HAZIRLIK.ID;
                    myAV001_TDI_BIL_GORUSMES.HAZIRLIK_NO = myAV001_TD_BIL_HAZIRLIK.HAZIRLIK_NO_Sayi;
                    myAV001_TDI_BIL_GORUSMES.TARIH = DateTime.Now;
                    myAV001_TDI_BIL_GORUSMES.IS_KATEGORI_ID = 493;
                    myAV001_TDI_BIL_GORUSMES.GORUSME_YONU = (byte)gorusmeYonu;
                    myAV001_TDI_BIL_GORUSMES.GORUSEN_CARI_ID = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
                    myAV001_TDI_BIL_GORUSMES.GORUSEN_TEL = "1007";
                    myAV001_TDI_BIL_GORUSMES.GORUSULEN_TEL = Tel;
                    myAV001_TDI_BIL_GORUSMES.GORUSULEN_CARI_ID = Convert.ToInt32(gorusulen);
                    myAV001_TDI_BIL_GORUSMESs.Add(myAV001_TDI_BIL_GORUSMES);
                    uckayit.ModulTipi = AvukatProLib.Extras.ModulTip.Sorusturma;
                    uckayit.MyDataSource = myAV001_TDI_BIL_GORUSMESs;

                    break;

                case "KLASÖR":
                    /*  AV001_TDIE_BIL_PROJE myAV001_TDIE_BIL_PROJE = new AV001_TDIE_BIL_PROJE();
                      myAV001_TDIE_BIL_PROJE = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(Convert.ToInt32(foyId));

                                                              TList<AV001_TDI_BIL_GORUSME> myAV001_TDI_BIL_GORUSMEKs = new TList<AV001_TDI_BIL_GORUSME>();

                      AV001_TDI_BIL_GORUSME myAV001_TDI_BIL_GORUSMEK = new AV001_TDI_BIL_GORUSME();

                   //   myAV001_TDI_BIL_GORUSMEK.ıd = myAV001_TDIE_BIL_PROJE.ID;
                      myAV001_TDI_BIL_GORUSMEK.KLASOR_KODU = myAV001_TDIE_BIL_PROJE.KOD;
                      myAV001_TDI_BIL_GORUSMEK.TARIH = DateTime.Now;
                      myAV001_TDI_BIL_GORUSMEK.IS_KATEGORI_ID = 493;
                      myAV001_TDI_BIL_GORUSMEK.GORUSME_YONU = 0;
                      myAV001_TDI_BIL_GORUSMEK.GORUSEN_CARI_ID = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
                      myAV001_TDI_BIL_GORUSMEK.GORUSEN_TEL = "1007";
                      myAV001_TDI_BIL_GORUSMEK.GORUSULEN_TEL = Tel;
                      myAV001_TDI_BIL_GORUSMEK.GORUSULEN_CARI_ID = Convert.ToInt32(gorusulen);
                      myAV001_TDI_BIL_GORUSMEKs.Add(myAV001_TDI_BIL_GORUSMEK);
                      uckayit.MyDataSource = myAV001_TDI_BIL_GORUSMEKs;
                      */
                    break;

                default:
                    break;
            }
        }

        public void gridDoldur(DevExpress.XtraGrid.GridControl mygrid, List<HizliArama> aramaSonuclari, int cariId)
        {
            mygrid.RefreshDataSource();
            DataTable table = new DataTable();
            table.Columns.Add("Tipi", typeof(string));
            table.Columns.Add("Dosya No", typeof(string));
            table.Columns.Add("Adliye", typeof(string));
            table.Columns.Add("No", typeof(string));
            table.Columns.Add("Görev", typeof(string));
            table.Columns.Add("Esas No", typeof(string));
            table.Columns.Add("Takip Tarihi", typeof(string));
            table.Columns.Add("Foy İd", typeof(string));
            table.Columns.Add("isSelected", typeof(bool));

            foreach (var item in aramaSonuclari)
            {
                DataRow workRow = table.NewRow();

                workRow[0] = (DBNull.Value.Equals(item.TIPI) || item.TIPI == null) ? "" : item.TIPI.ToString();
                workRow[1] = (DBNull.Value.Equals(item.FOY_NO) || item.FOY_NO == null) ? "" : item.FOY_NO.ToString();
                workRow[2] = (DBNull.Value.Equals(item.ADLI_BIRIM_ADLIYE_ID) || item.ADLI_BIRIM_ADLIYE_ID == null) ? "" : AdliBirimAdliyeGetir((int)item.ADLI_BIRIM_ADLIYE_ID);
                workRow[3] = (DBNull.Value.Equals(item.ADLI_BIRIM_NO_ID) || item.ADLI_BIRIM_NO_ID == null) ? "" : AdliBirimNoGetir((int)item.ADLI_BIRIM_NO_ID);
                workRow[4] = (DBNull.Value.Equals(item.ADLI_BIRIM_GOREV_ID) || item.ADLI_BIRIM_GOREV_ID == null) ? "" : AdliBirimGorevGetir((int)item.ADLI_BIRIM_GOREV_ID);
                workRow[5] = (DBNull.Value.Equals(item.ESAS_NO) || item.ESAS_NO == null) ? "" : item.ESAS_NO.ToString();
                workRow[6] = (DBNull.Value.Equals(item.TAKIP_TARIHI) || item.TAKIP_TARIHI == null) ? "" : item.TAKIP_TARIHI.ToString();
                workRow[7] = (DBNull.Value.Equals(item.ID) || item.ID == null) ? "" : item.ID.ToString();
                workRow[8] = false;
                table.Rows.Add(workRow);
            }
            //mygrid.Tag = cariId;
            mygrid.DataSource = table;
        }

        public void HideTabPage(TabControl tabControl1, TabPage tp)
        {
            if (tabControl1.TabPages.Contains(tp))
                tabControl1.TabPages.Remove(tp);
        }

        public void HideTabPage(DevExpress.XtraTab.XtraTabControl tabControl1, DevExpress.XtraTab.XtraTabPage tp)
        {
            if (tabControl1.TabPages.Contains(tp))
                tabControl1.TabPages.Remove(tp);
        }

        public void offline()
        {
        }

        public bool online()
        {
            return true;
        }

        public void selectTabPage(TabControl tabControl1, TabPage tabpage)
        {
            tabControl1.SelectedTab = tabpage;
        }

        public int sendIpSantralForwardService(string _aranan, string _arayan, string _cagriTip)
        {
            Thread.Sleep(2000);
            try
            {
                //string IpadressServer = "192.9.0.7";
                System.Net.Sockets.TcpClient clientSocket2;
                clientSocket2 = new System.Net.Sockets.TcpClient(IpadressServer, 5093);
                NetworkStream serverStream = clientSocket2.GetStream();

                XmlDocument xmldocumant = forVoipXmlCreator(_aranan, _arayan, "", _cagriTip);
                StringWriter stringw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(stringw);
                xmldocumant.WriteTo(xw);
                //xmldocumant.Save("C:\\IpSantralIletisim.xml");

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(stringw.ToString());
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                clientSocket2.Close();
                serverStream.Close();
                return 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Santral Servisi Kapalı");

                return 0;
            }
        }

        public int sendIpSantralForwardService(string _aranan, string _arayan, string _davetEdilen, string _cagriTip)
        {
            Thread.Sleep(2000);
            try
            {
                //string IpadressServer = "192.9.0.7";
                System.Net.Sockets.TcpClient clientSocket2;
                clientSocket2 = new System.Net.Sockets.TcpClient(IpadressServer, 5093);
                NetworkStream serverStream = clientSocket2.GetStream();

                XmlDocument xmldocumant = forVoipXmlCreator(_aranan, _arayan, _davetEdilen, _cagriTip);
                StringWriter stringw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(stringw);
                xmldocumant.WriteTo(xw);
                //xmldocumant.Save("C:\\IpSantralIletisim.xml");

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(stringw.ToString());
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                clientSocket2.Close();
                serverStream.Close();
                return 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Santral Servisi Kapalı");

                return 0;
            }
        }

        public int sendIpSantralForwardServicetring(string _aranan, string _arayan, string _cagriTip, string s)
        {
            //Thread.Sleep(2000);
            try
            {
                //string IpadressServer = "192.9.0.7";
                System.Net.Sockets.TcpClient clientSocket2;
                clientSocket2 = new System.Net.Sockets.TcpClient(IpadressServer, 5093);
                NetworkStream serverStream = clientSocket2.GetStream();

                XmlDocument xmldocumant = forVoipXmlCreatorIkinciCagri(_aranan, _arayan, "", _cagriTip, s);
                StringWriter stringw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(stringw);
                xmldocumant.WriteTo(xw);
                //xmldocumant.Save("C:\\IpSantralIletisim.xml");

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(stringw.ToString());
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                clientSocket2.Close();
                serverStream.Close();
                return 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Santral Servisi Kapalı");

                return 0;
            }
        }

        public void ShowTabPage(TabControl tabControl1, TabPage tp)
        {
            ShowTabPage(tabControl1, tp, tabControl1.TabPages.Count);
        }

        public void ShowTabPage(DevExpress.XtraTab.XtraTabControl tabControl1, DevExpress.XtraTab.XtraTabPage tp)
        {
            ShowTabPage(tabControl1, tp, tabControl1.TabPages.Count);
        }

        private string AdliBirimAdliyeGetir(int ID)
        {
            string adliye = "";
            VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE> mylist = new VList<per_TDI_KOD_ADLI_BIRIM_ADLIYE>();
            mylist = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_ADLIYEProvider.GetAll();
            foreach (per_TDI_KOD_ADLI_BIRIM_ADLIYE item in mylist)
            {
                if (item.ID == ID)
                {
                    adliye = item.ADLIYE.ToString();
                }
            }

            return adliye;
        }

        private string AdliBirimGorevGetir(int gorevID)
        {
            string adlibirimGorev = "";
            VList<per_TDI_KOD_ADLI_BIRIM_GOREV> mylist = new VList<per_TDI_KOD_ADLI_BIRIM_GOREV>();
            mylist = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_GOREVProvider.GetAll();
            foreach (per_TDI_KOD_ADLI_BIRIM_GOREV item in mylist)
            {
                if (item.ID == gorevID)
                {
                    adlibirimGorev = item.GOREV;
                }
            }
            return adlibirimGorev;
        }

        private string AdliBirimNoGetir(int NoId)
        {
            string adlibirimNo = "";
            VList<per_TDI_KOD_ADLI_BIRIM_NO> mylist = new VList<per_TDI_KOD_ADLI_BIRIM_NO>();
            mylist = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ADLI_BIRIM_NOProvider.GetAll();
            foreach (per_TDI_KOD_ADLI_BIRIM_NO item in mylist)
            {
                if (item.ID == NoId)
                {
                    adlibirimNo = item.NO;
                }
            }
            return adlibirimNo;
        }

        private void InsertTabPage(TabControl tabControl1, TabPage tabpage, int index)
        {
            if (index < 0 || index > tabControl1.TabCount)
                throw new ArgumentException("Aralık dışında dizin.");
            tabControl1.TabPages.Add(tabpage);
            if (index < tabControl1.TabCount - 1)
                do
                {
                    SwapTabPages(tabControl1, tabpage, (tabControl1.TabPages[tabControl1.TabPages.IndexOf(tabpage) - 1]));
                }
                while (tabControl1.TabPages.IndexOf(tabpage) != index);
            tabControl1.SelectedTab = tabpage;
        }

        private void InsertTabPage(DevExpress.XtraTab.XtraTabControl tabControl1, DevExpress.XtraTab.XtraTabPage tabpage, int index)
        {
            if (index < 0 || index > tabControl1.TabPages.Count)
                throw new ArgumentException("Aralık dışında dizin.");
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTabPage = tabpage;
        }

        private void ShowTabPage(DevExpress.XtraTab.XtraTabControl tabControl1, DevExpress.XtraTab.XtraTabPage tp, int index)
        {
            if (tabControl1.TabPages.Contains(tp)) return;
            InsertTabPage(tabControl1, tp, index);
        }

        private void ShowTabPage(TabControl tabControl1, TabPage tp, int index)
        {
            if (tabControl1.TabPages.Contains(tp)) return;
            InsertTabPage(tabControl1, tp, index);
        }

        private void SwapTabPages(TabControl tabControl1, TabPage tp1, TabPage tp2)
        {
            if (tabControl1.TabPages.Contains(tp1) == false || tabControl1.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages, TabControl.TabPageCollection tipinde olmalıdır.");

            int Index1 = tabControl1.TabPages.IndexOf(tp1);
            int Index2 = tabControl1.TabPages.IndexOf(tp2);
            tabControl1.TabPages[Index1] = tp2;
            tabControl1.TabPages[Index2] = tp1;
        }
    }
}