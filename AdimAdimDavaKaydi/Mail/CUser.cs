using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace AdimAdimDavaKaydi.Mail
{
    internal class CUser
    {
        public string token;

        public void authenticate(string userName, string userPass, string customerCode, string apiKey, string vendorCode)
        {
            WebRequest request = WebRequest.Create("http://live.iletisimmakinesi.com:9080/UserGatewayWS/functions/authenticate");
            request.Method = "POST";
            string postData;
            postData = "userName=" + userName + "&userPass=" + userPass + "&customerCode=" + customerCode + "&apiKey=" + apiKey + "&vendorCode=" + vendorCode;

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
            XmlReader reader1 = XmlReader.Create(new StringReader(responseFromServer));
            reader1.ReadToFollowing("TOKEN_NO");
            token = reader1.ReadElementContentAsString();
            reader.Close();
            reader1.Close();
            dataStream.Close();
            response.Close();
        }
    }
}