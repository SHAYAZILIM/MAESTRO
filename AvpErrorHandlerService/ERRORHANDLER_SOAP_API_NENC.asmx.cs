using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;

namespace AvpErrorHandlerService
{
    /// <summary>
    /// Summary description for ERRORHANDLER_SOAP_API_NENC
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class ERRORHANDLER_SOAP_API_NENC : System.Web.Services.WebService
    {
        private ErrorHandlerDataContext dataContext = new ErrorHandlerDataContext();

        //[WebMethod]
        //public string ErrorReport(string from, string fromName, string noteFromSender, string errorDetail, string exeVersionNumber, string dbVersionNumber, byte errorSource)
        //{
        //    //errorsource şuanda kullanılmıyor ancak service denmi yoksa bakımdan mı vs nerden geldiğini anlamak için koyduk
        //    TMYS_HATA_RAPORU hataRaporu = new TMYS_HATA_RAPORU();
        //    hataRaporu.GONDEREN_EMAIL = from;
        //    hataRaporu.NE_ZAMAN = DateTime.Now;
        //    hataRaporu.HATA_RAPORU = errorDetail;
        //    hataRaporu.KIMDEN = fromName;
        //    hataRaporu.GONDEREN_NOTU = noteFromSender;
        //    List<TMYS_EXE_SURUM> exeList = dataContext.TMYS_EXE_SURUMs.Where(itm => itm.SURUM == exeVersionNumber).ToList();
        //    if (exeList.Count > 0) hataRaporu.TMYS_EXE_SURUM = exeList[0];
        //    List<TMYS_DB_SURUM> dbList = dataContext.TMYS_DB_SURUMs.Where(itm => itm.SURUM == dbVersionNumber).ToList();
        //    if (dbList.Count > 0) hataRaporu.TMYS_DB_SURUM = dbList[0];
        //    hataRaporu.DURUM = 0;
        //    dataContext.TMYS_HATA_RAPORUs.InsertOnSubmit(hataRaporu);
        //    if (dataContext.Connection.State != ConnectionState.Open) dataContext.Connection.Open();
        //    dataContext.SubmitChanges();
        //    return String.Format("#{0} numaralı hata kaydınız alınmıştır.{1}En kısa sürede size geri dönüş sağlanacaktır.", hataRaporu.ID, Environment.NewLine);
        //    //TEST
        //}

        [WebMethod]
        public string ErrorReport(string from, string fromName, string noteFromSender, string errorDetail, string exeVersionNumber, string dbVersionNumber, byte errorSource)
        {
            int recId = 0;

            //errorsource şuanda kullanılmıyor ancak service denmi yoksa bakımdan mı vs nerden geldiğini anlamak için koyduk
            List<TMYS_EXE_SURUM> exeList = dataContext.TMYS_EXE_SURUMs.Where(itm => itm.SURUM == exeVersionNumber).ToList();
            List<TMYS_DB_SURUM> dbList = dataContext.TMYS_DB_SURUMs.Where(itm => itm.SURUM == dbVersionNumber).ToList();

            //using (SqlConnection con = new SqlConnection("Data Source=89.19.25.138;Initial Catalog=AVP_MYS;User ID=AVP_NHA_NG;Password=sch1open5"))
            using (SqlConnection con = new SqlConnection("Data Source=89.19.25.138;Initial Catalog=AVP_MYS;User ID=AVP_NHA_NG;Password=sch1open5"))
            {
                using (SqlCommand cmd = new SqlCommand("", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    string cmdText1 = "Insert into TMYS_HATA_RAPORU (KIMDEN, NE_ZAMAN, GONDEREN_EMAIL, GONDEREN_NOTU, HATA_RAPORU, KAYIT_TARIHI, DURUM ";
                    string cmdText2 = String.Format("values (@KIMDEN, @NE_ZAMAN, @GONDEREN_EMAIL, @GONDEREN_NOTU, @HATA_RAPORU, @KAYIT_TARIHI, @DURUM");

                    //cmd.CommandText = "Insert into TMYS_HATA_RAPORU2 (KIMDEN, NE_ZAMAN, GONDEREN_EMAIL, GONDEREN_NOTU, HATA_RAPORU, EXE_SURUM_ID, KAYIT_TARIHI, DB_SURUM_ID, DURUM) ";
                    //cmd.CommandText += String.Format("values (@KIMDEN, @NE_ZAMAN, @GONDEREN_EMAIL, @GONDEREN_NOTU, @HATA_RAPORU, @EXE_SURUM_ID, @KAYIT_TARIHI, @DB_SURUM_ID, @DURUM); SELECT SCOPE_IDENTITY()");
                    cmd.Parameters.AddWithValue("@KIMDEN", fromName);
                    cmd.Parameters.AddWithValue("@NE_ZAMAN", DateTime.Now);
                    cmd.Parameters.AddWithValue("@GONDEREN_EMAIL", from);
                    cmd.Parameters.AddWithValue("@GONDEREN_NOTU", noteFromSender);
                    cmd.Parameters.AddWithValue("@HATA_RAPORU", errorDetail);
                    cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DURUM", 0);
                    if (exeList.Count > 0)
                    {
                        cmd.Parameters.AddWithValue("@EXE_SURUM_ID", exeList[0].ID);
                        cmdText1 += ",EXE_SURUM_ID";
                        cmdText2 += ",@EXE_SURUM_ID";
                    }
                    if (dbList.Count > 0)
                    {
                        cmd.Parameters.AddWithValue("@DB_SURUM_ID", dbList[0].ID);
                        cmdText1 += ",DB_SURUM_ID";
                        cmdText2 += ",@DB_SURUM_ID";
                    }
                    cmdText1 += ") ";
                    cmdText2 += "); SELECT SCOPE_IDENTITY()";
                    cmd.CommandText = cmdText1 + cmdText2;
                    recId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return String.Format("#{0} numaralı hata kaydınız alınmıştır.{1}En kısa sürede size geri dönüş sağlanacaktır.", recId, Environment.NewLine);
            //TEST
        }
    }
}