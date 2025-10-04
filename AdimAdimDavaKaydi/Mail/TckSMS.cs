using System;
using System.IO;
using System.Xml;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Mail
{
    internal class TckSMS
    {
        private CUser myCUser = new CUser();
        private string SMSApiKey;
        private string SMSBayiKodu;
        private string SMSGonderen;
        private string SMSIletisimTel;
        private string SMSKullaniciAdi;
        private string SMSMusteriKodu;
        private string SMSSaglayici;
        private string SMSSifre;
        private string SMSVendorID;
        private string SMSZamanAsimi;
        private CompInfo smtpInfo;

        public string MySerialization(string[] myDizi)
        {
            string value = "";
            for (int i = 0; i < myDizi.Length; i++)
            {
                if (myDizi.Length == 1)
                {
                    value = "[" + '"' + myDizi[i] + '"' + "]";
                }
                else if (i == 0)
                {
                    value = "[" + '"' + myDizi[i] + '"';
                }
                else if (i == (myDizi.Length - 1))
                {
                    value = value + ',' + '"' + myDizi[i] + '"' + "]";
                }
                else
                {
                    value = value + ',' + '"' + myDizi[i] + '"';
                }
            }

            return value;
        }

        public string[] SMSGonder(string TcNo, string text)
        {
            CTckSms myCTckSms = new CTckSms();
            string templateText;
            string originatorId;
            string isUTF8Allowed;
            string validityPeriod;

            //string isRepeatingDestinationAllowed;
            //string clientTransactionId;
            smtpInfo = CompInfo.CmpNfoList[0];
            SMSKullaniciAdi = smtpInfo.SMSKullaniciAdi;
            SMSSifre = smtpInfo.SMSSifre;
            SMSVendorID = smtpInfo.SMSServisSaglayiciID;
            SMSSaglayici = smtpInfo.SMSServisSaglayici;
            if (!String.IsNullOrEmpty(smtpInfo.SMSGonderen))
                SMSGonderen = smtpInfo.SMSGonderen.Trim();
            SMSZamanAsimi = smtpInfo.SMSMaxGonderimSuresi;
            SMSMusteriKodu = smtpInfo.SMSMusteriKodu;
            SMSBayiKodu = smtpInfo.SMSBayiKodu;
            SMSApiKey = smtpInfo.SMSApiKey;
            SMSIletisimTel = smtpInfo.SMSIletisimTel;
            templateText = text;
       
            isUTF8Allowed = "false";
            validityPeriod = "1680";
            myCUser.authenticate(SMSKullaniciAdi, SMSSifre, SMSMusteriKodu, SMSApiKey, SMSBayiKodu);
            originatorId = myCTckSms.OrginatorCreated(myCUser.token, 6);
            string returnSendSms = myCTckSms.sendTckSms(myCUser.token, MySerialization(new string[] { TcNo }), templateText, originatorId, isUTF8Allowed, validityPeriod);

            TextReader txtreader = new StringReader(returnSendSms);
            XmlTextReader okuyucu = new XmlTextReader(txtreader);
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(okuyucu);
            XmlNode rss = dokuman.SelectSingleNode("/HERMES_RESPONSE");
            XmlNodeList title1 = dokuman.SelectNodes("/HERMES_RESPONSE/STATUS/DESC");
            string s1 = title1.Item(0).InnerText.ToString();
            XmlNodeList title2 = dokuman.SelectNodes("/HERMES_RESPONSE/CONTENT/SEND_TCKNO_SUCCESS/TRANSACTION");
            string s2 = title2.Item(0).Attributes["id"].InnerText.ToString();
            string[] returnString = { s1, s2 };
            return returnString;
        }
    }
}