using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace AdimAdimDavaKaydi.Mail
{
    internal class CSms
    {

        public string sendSMS(string token, string phoneNumbers, string templateText, string originatorId, string isUTF8Allowed, string validityPeriod, string isRepeatingDestinationAllowed, string clientTransactionId)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create("http://live.iletisimmakinesi.com:9080/SMSGatewayWS/functions/sendSMS");
            request.Method = "POST";
            string postData;
            postData = "token=" + token + "&phoneNumbers=" + phoneNumbers + "&templateText=" + templateText + "&originatorId=" + originatorId + "&isUTF8Allowed=" + isUTF8Allowed + "&validityPeriod=" + validityPeriod + "&isRepeatingDestinationAllowed=" + isRepeatingDestinationAllowed + "&clientTransactionId=" + clientTransactionId;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        public string OrginatorCreated(string token,int servisId)
        {
            //?token=620VE66PR63RNLQJ9Z6LTPHQOVPYS3&serviceId=7
            System.Net.WebRequest request = System.Net.WebRequest.Create("https://live.iletisimmakinesi.com/api/UserGatewayWS/functions/getOriginators");
            request.Method = "POST";
            string postData;
            postData = "token=" + token + "&serviceId=" + servisId;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            TextReader txtreader = new StringReader(responseFromServer);
            XmlTextReader okuyucu = new XmlTextReader(txtreader);
            XmlDocument dokuman = new XmlDocument();
            dokuman.Load(okuyucu);
            XmlNode rss = dokuman.SelectSingleNode("/HERMES_RESPONSE");
            XmlNodeList title1 = dokuman.SelectNodes("/HERMES_RESPONSE/STATUS/DESC");
            string s1 = title1.Item(0).InnerText.ToString();
            XmlNodeList title2 = dokuman.SelectNodes("/HERMES_RESPONSE/CONTENT/ORIGINATORS/ORIGINATOR");
            string s2 = title2.Item(0).Attributes["id"].InnerText.ToString();
            return s2;
        }
    }
}