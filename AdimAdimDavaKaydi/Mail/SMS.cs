using System;
using System.Data;
using System.IO;
using System.Xml;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Mail
{
    internal class SMS
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

        public string[] SMSGonder(string phone1, string phone2, string text)
        {
            CSms csms = new CSms();
            string[] phoneNumbers = new string[2];
            string templateText;
            string originatorId;
            string isUTF8Allowed;
            string validityPeriod;
            string isRepeatingDestinationAllowed;
            string clientTransactionId;

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
            phoneNumbers[0] = phone1;
            phoneNumbers[1] = phone2;
            templateText = text;
          
            isUTF8Allowed = "false";
            validityPeriod = "1680";
            isRepeatingDestinationAllowed = "false";
             

            //https://live.iletisimmakinesi.com/api/UserGatewayWS/functions/getOriginators?token=620VE66PR63RNLQJ9Z6LTPHQOVPYS3&serviceId=7

            //clientTransactionId = new Guid(8, 3, 9, new byte[] { 0,1,2,3,4,5,6,7}).ToString();
            Random rnd = new Random();
            clientTransactionId = Convert.ToInt32(Convert.ToInt32(rnd.Next(0, int.MaxValue))).ToString();

            StreamWriter dosya = new StreamWriter("C:\\knn2.txt");
            dosya.WriteLine(clientTransactionId);
            dosya.Close();

            myCUser.authenticate(SMSKullaniciAdi, SMSSifre, SMSMusteriKodu, SMSApiKey, SMSBayiKodu);
            originatorId = csms.OrginatorCreated(myCUser.token, 7);
            string returnSendSms = csms.sendSMS(myCUser.token, MySerialization(phoneNumbers), templateText, originatorId, isUTF8Allowed, validityPeriod, isRepeatingDestinationAllowed, clientTransactionId);

            TextReader txtreader = new StringReader(returnSendSms);
            XmlTextReader okuyucu = new XmlTextReader(txtreader);
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(okuyucu);
            XmlNode rss = dokuman.SelectSingleNode("/HERMES_RESPONSE");
            XmlNodeList title1 = dokuman.SelectNodes("/HERMES_RESPONSE/STATUS/DESC");
            string s1 = title1.Item(0).InnerText.ToString();
            XmlNodeList title2 = dokuman.SelectNodes("/HERMES_RESPONSE/CONTENT/SEND_SMS_SUCCESS/TRANSACTION");
            string s2 = title2.Item(0).Attributes["id"].InnerText.ToString();

            string[] returnString = { s1, s2 };
            return returnString;
        }
    }
}