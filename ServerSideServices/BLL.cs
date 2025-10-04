using Avukatpro.Reminder;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Data.SqlClient;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//using AvukatPro.Net.Mail;

namespace ServerSideServices
{
    public class barkodİslemleri
    {
        public void barkodSorgula(string _barkod)
        {
            #region pttTekliSorgulamaV2  çalışıyor safaat veriyor fakat sonuç bilgisi gelmiyor

            try
            {
                string _kullanici = "PttWs";
                string _sifre = "YazDes*1840";
                pttGonderiTakipV2.Input inpt = new pttGonderiTakipV2.Input();
                inpt.barkod = _barkod;// "4290000000803";
                inpt.kullanici = _kullanici;
                inpt.sifre = _sifre;
                pttGonderiTakipV2.Sorgu srg = new pttGonderiTakipV2.Sorgu();
                pttGonderiTakipV2.OutputTum optum = new pttGonderiTakipV2.OutputTum();
                srg.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";

                optum = srg.gonderiSorgu(inpt);
                foreach (var item in optum.dongu)
                {
                    string _imerk = item.IMERK;
                    string _islem = item.ISLEM;
                    string _iTarih = item.ITARIH;
                    string _siraNo = item.siraNo.ToString();
                    if (_islem.Contains("MUHTAR"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "MUHTAR");
                    }
                    else if (_islem.Contains("KENDİ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "KENDİ");
                    }
                    else if (_islem.Contains("BiZZAT"))  //MUHATABA BiZZAT TESLiM
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "KENDİ");
                    }

                    else if (_islem.Contains("YAKIN"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "BİRLİKTE SAKİN");
                    }
                    else if (_islem.Contains("ÇALIŞAN"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "ÇALIŞAN");
                    }
                    else if (_islem.Contains("AİLE"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "AİLE");
                    }
                    else if (_islem.Contains("AMİR"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "İDARE AMİRİNE");
                    }
                    else if (_islem.Contains("VELİ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VELİ");
                    }
                    else if (_islem.Contains("VEKİL"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VEKİL");
                    }
                    else if (_islem.Contains("VASİ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "VASİ");
                    }
                    else if (_islem.Contains("EŞİ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "TARAFIN EŞİ");
                    }
                    else if (_islem.Contains("ÇOCUK"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "ÇOCUK");
                    }
                    else if (_islem.Contains("BİRLİKTE"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "BİRLİKTE");
                    }
                    else if (_islem.Contains("MEMUR"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "MEMUR");
                    }
                    else if (_islem.Contains("HİZMETÇİ"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "islem basarili", "islem basarili", _imerk, inpt.barkod, "HİZMETÇİ");
                    }
                    else if (_islem.Contains("iADE EDiLDi"))
                    {
                        // listBox1.Items.Add("Barkod No : " + inpt.barkod + ", İslem Merkezi : " +
                        // _imerk + ", İşlem :" + _islem + ", İşlem Tarihi :" + _iTarih + ", Sıra No
                        // : " + _siraNo);
                        sonucUpdate(_iTarih, "BİLA TEBLİĞ", "islem basarili", _imerk, inpt.barkod, "iADE EDiLDi");
                    }

                    // dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME

                    gelismeAdimInsert(inpt.barkod, _imerk, _islem, _iTarih, _siraNo);
                }
            }
            catch (Exception)
            {
            }

            #endregion pttTekliSorgulamaV2  çalışıyor safaat veriyor fakat sonuç bilgisi gelmiyor
        }

        public void gelismeAdimInsert(string _barkodNo, string _imerk, string _islem, string _iTarih, string _siraNo)
        {
            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            int _TEBLIGAT_MUHATAP_ID = 0;
            bool insertYapsinmi = true;
            SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select ID  from AV001_TDI_BIL_TEBLIGAT_MUHATAP where PTT_BARKOD_NO='" + _barkodNo + "' ", con1);
            cmd1.CommandTimeout = 1000;
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                _TEBLIGAT_MUHATAP_ID = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            dr.Dispose();
            cmd1.Dispose();
            con1.Close();
            con1.Dispose();

            SqlConnection con3 = new SqlConnection(smtpInfo.ConStr);
            con3.Open();
            SqlCommand cmd3 = new SqlCommand("select ID  from [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME]  where [TEBLIGAT_MUHATAP_ID]=" + _TEBLIGAT_MUHATAP_ID + " and [SIRA_NO]= " + Convert.ToInt32(_siraNo) + "", con3);
            cmd3.CommandTimeout = 1000;
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                insertYapsinmi = false;
            }
            dr3.Close();
            dr3.Dispose();
            cmd3.Dispose();
            con3.Close();
            con3.Dispose();
            if (insertYapsinmi)
            {
                string commandInsert = @"INSERT INTO [dbo].[AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME]
([TEBLIGAT_MUHATAP_ID],[SIRA_NO],[ISLEM],[YER],[BILGI_GIRIS_TARIH],[ACIKLAMA],[KAYIT_TARIH])
VALUES (" + _TEBLIGAT_MUHATAP_ID + "," + Convert.ToInt32(_siraNo) + ",'" + _islem + "','" + _imerk + "','" + _iTarih + "','',getdate())";

                SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand(commandInsert, con2);
                cmd2.CommandTimeout = 1000;
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                con2.Close();
                con2.Dispose();
            }
        }

        public void sonucUpdate(string _iTarih, string _sonuc, string _durum, string _imerk, string _barkodNo, string _kime)
        {
            CompInfo smtpInfo = CompInfo.CmpNfoList[0];
            string UpdateCommand = "update AV001_TDI_BIL_TEBLIGAT_MUHATAP set ";
            if (_kime == "KENDİ")
            {
                int _MUHATAP_CARI_ID = 0;
                SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select MUHATAP_CARI_ID  from AV001_TDI_BIL_TEBLIGAT_MUHATAP where PTT_BARKOD_NO='" + _barkodNo + "' ", con1);
                cmd1.CommandTimeout = 1000;
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    _MUHATAP_CARI_ID = Convert.ToInt32(dr[0].ToString());
                    break;
                }
                dr.Close();
                dr.Dispose();
                cmd1.Dispose();
                con1.Close();
                con1.Dispose();

                UpdateCommand = UpdateCommand + " ALAN_CARI_ID=" + _MUHATAP_CARI_ID + ",";
            }
            else if (_kime == "MUHTAR")
            {
                UpdateCommand = UpdateCommand + " TEBLIGAT_SEKLI_ID=2,";
            }
            else if (_kime == "iADE EDiLDi")
            {
                //UpdateCommand = UpdateCommand + " TEBLIGAT_SEKLI_ID=2,";
            }
            else
            {
                int _ALAN_BAGLANTI_ID = 0;
                SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select ID  from TDI_KOD_TEBLIGAT_ALAN_BAGLANTI where BAGLANTI like '%" + _kime + "%' ", con1);
                cmd1.CommandTimeout = 1000;
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    _ALAN_BAGLANTI_ID = Convert.ToInt32(dr[0].ToString());
                    break;
                }

                dr.Close();
                dr.Dispose();
                cmd1.Dispose();
                con1.Close();
                con1.Dispose();
                UpdateCommand = UpdateCommand + " ALAN_BAGLANTI_ID=" + _ALAN_BAGLANTI_ID + ",";
            }
            string[] mytarih = _iTarih.Split('/');
            string yil = mytarih[2];
            string ay = mytarih[1];
            string gun = mytarih[0];
            //for (int i = 0; i < _iTarih.Length; i++)
            //{
            //    if (i < 4)
            //    {
            //        yil = yil + _iTarih[i].ToString();
            //    }
            //    else if (i < 6)
            //    {
            //        ay = ay + _iTarih[i].ToString();
            //    }
            //    else
            //    {
            //        gun = gun + _iTarih[i].ToString();
            //    }
            //}//2012-02-10 14:37:22.680
            string tarih = yil + "-" + ay + "-" + gun + " 00:00:00.000";
            //string tarih = _iTarih.Replace('/', '.');
            if (_sonuc != "islem basarili")
            {
                UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=1,";
                UpdateCommand = UpdateCommand + "BILA_TARIHI='" + tarih + "',";
                UpdateCommand = UpdateCommand + "TEBLIGAT_SONUC_ID=3,";
            }
            else if (_sonuc == "islem basarili")
            {
                UpdateCommand = UpdateCommand + "BILA_TEBLIG_MI=0,";
                UpdateCommand = UpdateCommand + "TEBLIG_TARIH='" + tarih + "',";
                UpdateCommand = UpdateCommand + "TEBLIGAT_SONUC_ID=2,";
            }
            UpdateCommand = UpdateCommand + "POSTA_DURUM='" + _durum + "',";
            UpdateCommand = UpdateCommand + "POSTA_SON_ISLEM_TARIHI='" + tarih + "',";
            UpdateCommand = UpdateCommand + "POSTAHANE='" + _imerk + "',";
            UpdateCommand = UpdateCommand + "POSTALANDI_MI=1 where PTT_BARKOD_NO='" + _barkodNo + "'";

            SqlConnection con2 = new SqlConnection(smtpInfo.ConStr);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand(UpdateCommand, con2);
            cmd2.CommandTimeout = 1000;
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            con2.Close();
            con2.Dispose();
        }
    }

    public static class BLL
    {
        private static List<int> bildirilenIdler;

        private static System.Net.Mail.SmtpClient client;

        private static DateTime comp1;

        private static AVPReminderDataContext context;

        private static string SMSGonderen;

        private static string SMSKullaniciAdi;

        private static string SMSSaglayici;

        private static string SMSSifre;

        private static string SMSVendorID;

        private static string SMSZamanAsimi;

        private static CompInfo smtpInfo;

        public static void AsistanIslemi()
        {
            try
            {
                //sms = new SMSMakinesi.Gateway();
                smtpInfo = CompInfo.CmpNfoList[0];
                SMSKullaniciAdi = smtpInfo.SMSKullaniciAdi;
                SMSSifre = smtpInfo.SMSSifre;
                SMSVendorID = smtpInfo.SMSServisSaglayiciID;
                SMSSaglayici = smtpInfo.SMSServisSaglayici;
                if (!String.IsNullOrEmpty(smtpInfo.SMSGonderen))
                    SMSGonderen = smtpInfo.SMSGonderen.Trim();
                SMSZamanAsimi = smtpInfo.SMSMaxGonderimSuresi;
                client = new SmtpClient();
                client.Host = smtpInfo.SMTPSunucuAdresi;
                if (!String.IsNullOrEmpty(smtpInfo.SMTPPort))
                    client.Port = Convert.ToInt32(smtpInfo.SMTPPort);

                client.EnableSsl = smtpInfo.SMTPSSL;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpInfo.SMTPKullaniciAdi, smtpInfo.SMTPSifre);
                //client.Password = smtpInfo.SMTPSifre;
                context = new AVPReminderDataContext(smtpInfo.ConStr);
                context.CommandTimeout = 10000;
                bildirilenIdler = new List<int>();
            }
            catch
            {

            }

            DateTime date = DateTime.Now;
            comp1 = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, 0);
            bildirilenIdler.Clear();
            var aktifHatirlatmalar = context.per_REMINDERs.Where(h => h.HATIRLATILSIN_MI == true && (h.HATIRLATMA_TIPI == "1" || h.HATIRLATMA_TIPI == "2"));

            List<Avukatpro.Reminder.per_REMINDER> hatirlatmalar = aktifHatirlatmalar.Where(h => h.ONGORULEN_BITIS_TARIHI.HasValue && h.GUNLUK_UYARI_SAAT == (comp1.Hour + ":" + comp1.Minute).ToString() && h.ONGORULEN_BITIS_TARIHI.Value.Date.AddDays((int)h.TEKRAR * (-1)) <= DateTime.Today && h.ONGORULEN_BITIS_TARIHI == null).ToList();

            //eğer her yıl tekrar edilecekse
            //&& (h.HATIRLATMA_BASLAMA_TARIHI.Value.AddYears((int)h.TEKRAR - (DateTime.Today.Year - h.HATIRLATMA_BASLAMA_TARIHI.Value.Year)).Day == DateTime.Today.Day && h.HATIRLATMA_BASLAMA_TARIHI.Value.AddYears((int)h.TEKRAR - (DateTime.Today.Year - h.HATIRLATMA_BASLAMA_TARIHI.Value.Year)).Month == DateTime.Today.Month && h.TEKRAR >= (DateTime.Today.Year - h.HATIRLATMA_BASLAMA_TARIHI.Value.Year))

            List<Avukatpro.Reminder.per_REMINDER> bildirimler = aktifHatirlatmalar.Where(b => b.BIR_DEFA_PATLAMASI_OLDU_MU == true && b.ENSON_EXTRA_1_GUN_ONCE == null).ToList();

            List<Avukatpro.Reminder.per_REMINDER> tamamlananlar = aktifHatirlatmalar.Where(t => t.GOSTERSIN_MI_1_GUN_ONCE == true && t.BITIS_TARIHI.HasValue).ToList();

            List<Avukatpro.Reminder.per_REMINDER> tamamlanmayanlar = aktifHatirlatmalar.Where(h => h.PERIYODUN_SON_PATLAMASI_OLDU_MU == true && h.ONGORULEN_BITIS_TARIHI < DateTime.Now && h.BITIS_TARIHI == null).ToList();

            #region Hatırlatma Yap

            if (hatirlatmalar.Count > 0)
            {
                foreach (var hatirlatma in hatirlatmalar)
                {
                    try
                    {
                        if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                        {
                            #region mail

                            MailMessage newmail = new MailMessage();

                            newmail.From = new MailAddress(smtpInfo.SMTPKullaniciAdi);
                            newmail.To.Add(hatirlatma.EMAIL_1);
                            newmail.IsBodyHtml = true;

                            if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                            {
                                string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                                File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                                Attachment attach = new Attachment(filePath);

                                newmail.Attachments.Add(attach);
                            }

                            newmail.Subject = TurkceKarakterleriDuzelt("Hatırlatma: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken işiniz var");

                            StringBuilder mail = new StringBuilder(193);
                            mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                            mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                            mail.AppendFormat(@"<head>");

                            mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                            mail.AppendFormat(@"<title></title>");

                            mail.AppendFormat(@"</head>");
                            mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                            newmail.Body = mail.ToString();

                            newmail.Body = newmail.Body.Replace("[ICERIKBURADAOLACAK]",
                                "<br><b>Kimden :</b> " + newmail.From +
                                "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                                "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                                "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                                "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                                "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                            newmail.Body = TurkceKarakterleriDuzelt(newmail.Body);

                            try
                            {
                                client.Send(newmail);
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                            }
                            Thread.Sleep(3000);
                            #endregion mail
                        }
                        else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                        {
                            #region sms

                            //if (sms == null)
                            //    sms = new SMSMakinesi.Gateway();

                            //StringBuilder mesaj = new StringBuilder();
                            //mesaj.Append("Yeni bir iş aldınız. Detay: ");

                            //if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            //    mesaj.Append(hatirlatma.ADLIYE + "/");
                            //if (!String.IsNullOrEmpty(hatirlatma.NO))
                            //    mesaj.Append(hatirlatma.NO + "/");
                            //if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            //    mesaj.Append(hatirlatma.GOREV + "/");
                            //if (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            //    mesaj.Append(hatirlatma.ESAS_NO + "-");
                            //if (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            //    mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "-");
                            //if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            //    mesaj.Append(hatirlatma.YAPILACAK_IS);

                            //sms.clearsmsbasket();

                            //if (mesaj.ToString() != string.Empty)
                            //    sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()), CepTelFormatla(hatirlatma.CEP_TEL.Trim()));
                            //string result;
                            //if (mesaj.Length <= 160)
                            //    result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                            //else
                            //    result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);

                            //sms.clearsmsbasket();

                            #endregion sms
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                    }
                }
            }

            #endregion Hatırlatma Yap

            //MessageBox.Show("Bildirim Sayisi : " + bildirimler.Count.ToString());

            #region İş bildirimi yap

            if (bildirimler.Count > 0)
            {
                foreach (var hatirlatma in bildirimler)
                {
                    try
                    {
                        if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                        {
                            #region mail

                            MailMessage newmail = new MailMessage();

                            newmail.From = new MailAddress(smtpInfo.SMTPKullaniciAdi);
                            newmail.To.Add(hatirlatma.EMAIL_1);
                            newmail.IsBodyHtml = true;

                            if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                            {

                                string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                                File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                                Attachment attach = new Attachment(filePath);

                                newmail.Attachments.Add(attach);

                            }

                            newmail.Subject = TurkceKarakterleriDuzelt("Yeni iş: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken yeni bir işiniz var");

                            StringBuilder mail = new StringBuilder(193);
                            mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                            mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                            mail.AppendFormat(@"<head>");

                            mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                            mail.AppendFormat(@"<title></title>");

                            mail.AppendFormat(@"</head>");
                            mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                            newmail.Body = mail.ToString();

                            newmail.Body = newmail.Body.Replace("[ICERIKBURADAOLACAK]",
                                "<br><b>Kimden :</b> " + newmail.From +
                                "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                                "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                                "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                                "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                                "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                            newmail.Body = TurkceKarakterleriDuzelt(newmail.Body);

                            try
                            {
                                client.Send(newmail);
                                if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
                                    bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                            }
                            Thread.Sleep(3000);

                            #endregion mail
                        }
                        else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                        {
                            #region sms

                            //try
                            //{
                            //    if (sms == null)
                            //        sms = new SMSMakinesi.Gateway();

                            // StringBuilder mesaj = new StringBuilder(); mesaj.Append("Yapılması
                            // gereken işiniz var. Detay: ");

                            // if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            // mesaj.Append(hatirlatma.ADLIYE + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.NO)) mesaj.Append(hatirlatma.NO + "/");
                            // if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            // mesaj.Append(hatirlatma.GOREV + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            // mesaj.Append(hatirlatma.ESAS_NO + "-"); if
                            // (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            // mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy
                            // H:mm") + "-"); if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            // mesaj.Append(hatirlatma.YAPILACAK_IS);

                            // sms.clearsmsbasket();

                            // if (mesaj.ToString() != string.Empty)
                            // sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()),
                            // CepTelFormatla(hatirlatma.CEP_TEL.Trim())); string result; if
                            // (mesaj.Length <= 160) result = sms.sendsms(SMSKullaniciAdi, SMSSifre,
                            // SMSGonderen, "", SMSVendorID); else result =
                            // sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "",
                            // SMSVendorID);

                            //    sms.clearsmsbasket();
                            //    if (result.Length > 2)
                            //    {
                            //        if (!bildirilenIdler.Contains((int)hatirlatma.HATIRLAT_ID))
                            //            bildirilenIdler.Add((int)hatirlatma.HATIRLAT_ID);
                            //    }
                            //}
                            //catch { ;}

                            #endregion sms
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                    }
                }
            }

            #endregion İş bildirimi yap

            #region Tamamlananlari Bildir

            if (tamamlananlar.Count > 0)
            {
                foreach (var hatirlatma in tamamlananlar)
                {
                    try
                    {
                        if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1))
                        {
                            #region mail

                            MailMessage newmail = new MailMessage();

                            newmail.From = new MailAddress(smtpInfo.SMTPKullaniciAdi);
                            newmail.To.Add(hatirlatma.EMAIL_1);
                            newmail.IsBodyHtml = true;

                            if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                            {
                                string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                                File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                                Attachment attach = new Attachment(filePath);

                                newmail.Attachments.Add(attach);
                            }

                            newmail.Subject = TurkceKarakterleriDuzelt("İş Tamamlandı: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken iş " + hatirlatma.BITIS_TARIHI.Value.ToShortDateString() + " tarihinde tamamlandı.");

                            StringBuilder mail = new StringBuilder(193);
                            mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                            mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                            mail.AppendFormat(@"<head>");

                            mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                            mail.AppendFormat(@"<title></title>");

                            mail.AppendFormat(@"</head>");
                            mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                            newmail.Body = mail.ToString();

                            newmail.Body = newmail.Body.Replace("[ICERIKBURADAOLACAK]",
                                "<br><b>Kimden :</b> " + newmail.From +
                                "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                                "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                                "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                                "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                                "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                            newmail.Body = TurkceKarakterleriDuzelt(newmail.Body);

                            try
                            {
                                client.Send(newmail);
                                SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                                SqlCommand cmd = new SqlCommand(@"UPDATE AV001_TDI_BIL_HATIRLAT SET GOSTERSIN_MI_1_GUN_ONCE=0 WHERE ID=@ID", con);
                                cmd.CommandTimeout = 1000;
                                cmd.Parameters.Add("@ID", hatirlatma.ID);
                                if (con.State == System.Data.ConnectionState.Closed)
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                if (con.State == System.Data.ConnectionState.Open)
                                    con.Close();
                                con.Dispose();
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                            }
                            Thread.Sleep(3000);

                            #endregion mail
                        }

                        else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                        {
                            #region sms

                            //if (sms == null)
                            //                    sms = new SMSMakinesi.Gateway();

                            // StringBuilder mesaj = new StringBuilder(); mesaj.Append("Tamamlanan iş.
                            // Detay: ");

                            // if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            // mesaj.Append(hatirlatma.ADLIYE + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.NO)) mesaj.Append(hatirlatma.NO + "/");
                            // if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            // mesaj.Append(hatirlatma.GOREV + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            // mesaj.Append(hatirlatma.ESAS_NO + "-"); if
                            // (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            // mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy
                            // H:mm") + "-"); if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            // mesaj.Append(hatirlatma.YAPILACAK_IS);

                            // sms.clearsmsbasket();

                            // if (mesaj.ToString() != string.Empty)
                            // sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()),
                            // CepTelFormatla(hatirlatma.CEP_TEL.Trim())); string result; if
                            // (mesaj.Length <= 160) result = sms.sendsms(SMSKullaniciAdi, SMSSifre,
                            // SMSGonderen, "", SMSVendorID); else result =
                            // sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "",
                            // SMSVendorID);

                            // sms.clearsmsbasket();

                            #endregion sms
                        }

                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                    }
                }
            }

            #endregion Tamamlananlari Bildir

            #region Tamamlanmayanları Bildir
            Dictionary<int, List<string>> tamamlanmayanids = new Dictionary<int, List<string>>();
            if (tamamlanmayanlar.Count > 0)
            {
                foreach (var hatirlatma in tamamlanmayanlar)
                {
                    try
                    {
                        if (hatirlatma.HATIRLATMA_TIPI == "1" && !string.IsNullOrEmpty(hatirlatma.EMAIL_1) && hatirlatma.ID.HasValue)
                        {
                            if (tamamlanmayanids.ContainsKey(hatirlatma.ID.Value))
                            {
                                if (tamamlanmayanids[hatirlatma.ID.Value].Contains(hatirlatma.EMAIL_1))
                                    continue;
                                else
                                    tamamlanmayanids[hatirlatma.ID.Value].Add(hatirlatma.EMAIL_1);
                            }
                            else
                            {
                                tamamlanmayanids.Add(hatirlatma.ID.Value, new List<string>() { hatirlatma.EMAIL_1 });
                            }
                            #region mail

                            MailMessage newmail = new MailMessage();

                            newmail.From = new MailAddress(smtpInfo.SMTPKullaniciAdi);
                            newmail.To.Add(hatirlatma.EMAIL_1);
                            newmail.IsBodyHtml = true;

                            if (!String.IsNullOrEmpty(hatirlatma.DOSYA_ADI))
                            {
                                string[] DOSYA_ADI = hatirlatma.DOSYA_ADI.Split('\\');

                                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DOSYA_ADI[DOSYA_ADI.Length - 1];
                                File.WriteAllBytes(filePath, hatirlatma.ICERIK.ToArray());
                                Attachment attach = new Attachment(filePath);

                                newmail.Attachments.Add(attach);
                            }

                            newmail.Subject = TurkceKarakterleriDuzelt("İş zamanında bitirilmedi: " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortDateString() + " tarihi ve " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToShortTimeString() + " saatinde tamamlanmasi gereken yeni iş zamanında bitirilmedi.");

                            StringBuilder mail = new StringBuilder(193);
                            mail.AppendLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                            mail.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
                            mail.AppendFormat(@"<head>");

                            mail.AppendLine("<META http-equiv=\"Content-Type\" content=\"text/html\"; charset=\"UTF-8\">");
                            mail.AppendFormat(@"<title></title>");

                            mail.AppendFormat(@"</head>");
                            mail.AppendFormat(@"<body><br>[ICERIKBURADAOLACAK]</body></html>");
                            newmail.Body = mail.ToString();

                            newmail.Body = newmail.Body.Replace("[ICERIKBURADAOLACAK]",
                                "<br><b>Kimden :</b> " + newmail.From +
                                "<br><b>Baslangıç Tarihi :</b> " + hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy H:mm") + "<br><b>Bitiş Tarihi :</b> " + hatirlatma.ONGORULEN_BITIS_TARIHI.Value.ToString("dd/MM/yyyy H:mm") +
                                "<br><b>Bilgi :</b> " + hatirlatma.ADLIYE + "/" + hatirlatma.NO + "/" + hatirlatma.GOREV + " - " + hatirlatma.ESAS_NO +
                                "<br><br><b>Görev :</b> " + hatirlatma.YAPILACAK_IS +
                                "<br><br><b>Açıklama :</b> " + hatirlatma.ACIKLAMA +
                                "<br><br><br><font color=blue>Not: Bu mail Avukatpro Yeni Nesil Asistanı tarafından otomatik olarak gönderilmiştir.</font>");
                            newmail.Body = TurkceKarakterleriDuzelt(newmail.Body);

                            try
                            {
                                client.Send(newmail);
                                SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                                SqlCommand cmd = new SqlCommand(@"UPDATE AV001_TDI_BIL_HATIRLAT SET PERIYODUN_SON_PATLAMASI_OLDU_MU=0 WHERE ID=@ID", con);
                                cmd.CommandTimeout = 1000;
                                cmd.Parameters.Add("@ID", hatirlatma.ID);
                                if (con.State == System.Data.ConnectionState.Closed)
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                if (con.State == System.Data.ConnectionState.Open)
                                    con.Close();
                                con.Dispose();
                            }
                            catch (Exception ex)
                            {
                                BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                            }
                            Thread.Sleep(3000);

                            #endregion mail
                        }

                        else if (hatirlatma.HATIRLATMA_TIPI == "2" && !string.IsNullOrEmpty(hatirlatma.CEP_TEL))
                        {
                            #region sms

                            //if (sms == null)
                            //                    sms = new SMSMakinesi.Gateway();

                            // StringBuilder mesaj = new StringBuilder(); mesaj.Append("İş zamanında
                            // bitirilmedi. Detay: ");

                            // if (!String.IsNullOrEmpty(hatirlatma.ADLIYE))
                            // mesaj.Append(hatirlatma.ADLIYE + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.NO)) mesaj.Append(hatirlatma.NO + "/");
                            // if (!String.IsNullOrEmpty(hatirlatma.GOREV))
                            // mesaj.Append(hatirlatma.GOREV + "/"); if
                            // (!String.IsNullOrEmpty(hatirlatma.ESAS_NO))
                            // mesaj.Append(hatirlatma.ESAS_NO + "-"); if
                            // (hatirlatma.BASLANGIC_TARIHI.HasValue)
                            // mesaj.Append(hatirlatma.BASLANGIC_TARIHI.Value.ToString("dd/MM/yyyy
                            // H:mm") + "-"); if (!String.IsNullOrEmpty(hatirlatma.YAPILACAK_IS))
                            // mesaj.Append(hatirlatma.YAPILACAK_IS);

                            // sms.clearsmsbasket();

                            // if (mesaj.ToString() != string.Empty)
                            // sms.addtosmsbasket(TKCeptDuzelt(mesaj.ToString()),
                            // CepTelFormatla(hatirlatma.CEP_TEL.Trim())); string result; if
                            // (mesaj.Length <= 160) result = sms.sendsms(SMSKullaniciAdi, SMSSifre,
                            // SMSGonderen, "", SMSVendorID); else result =
                            // sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "",
                            // SMSVendorID);

                            // sms.clearsmsbasket();

                            #endregion sms
                        }

                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Logger.ErrorException("Serverside", ex);
                    }
                }
            }

            #endregion Tamamlanmayanları Bildir

            #region Bildirilen hatırlatmaları güncelle

            if (bildirilenIdler.Count > 0)
            {
                SqlConnection con = new SqlConnection(smtpInfo.ConStr);
                foreach (var id in bildirilenIdler)
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE AV001_TDI_BIL_HATIRLAT SET ENSON_EXTRA_1_GUN_ONCE=getdate() WHERE ID=@ID", con);
                    cmd.CommandTimeout = 1000;
                    cmd.Parameters.Add("@ID", id);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }
                con.Dispose();
            }

            #endregion Bildirilen hatırlatmaları güncelle

            //zzzzzzzzzzzzzzzzzzzzzzzz
            //CompInfo gio = (CompInfo.CompInfoListGetir(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName))[0];

            //ABSqlConnection cn = new ABSqlConnection();
            //cn.CnString = gio.ConStr;

            //SqlNetTiersProvider prov = new SqlNetTiersProvider();
            //System.Collections.Specialized.NameValueCollection nameValueCollection = new System.Collections.Specialized.NameValueCollection();
            //nameValueCollection.Add("UseStoredProcedure", "true");
            //nameValueCollection.Add("EnableEntityTracking", "true");
            //nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
            //nameValueCollection.Add("EnableMethodAuthorization", "false");
            //nameValueCollection.Add("ConnectionString", gio.ConStr);
            //nameValueCollection.Add("ConnectionStringName", "conStr" + gio.LisansBilgisi.AdSoyad);
            //nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
            //prov.Initialize(gio.LisansBilgisi.AdSoyad, nameValueCollection);
            //DataRepository.LoadProvider(prov, true);

            //AvukatProLib.Arama.AvpDataContext db = new AvukatProLib.Arama.AvpDataContext(gio.ConStr);
            //BelgeUtil.Inits.context = db;

            //AvukatProLib.Kimlik.SirketBilgisi = gio;

            //TList<AV001_TI_BIL_FOY> foyler = DataRepository.AV001_TI_BIL_FOYProvider.GetAll();
            //foreach (AV001_TI_BIL_FOY foy in foyler)
            //{
            //    AvukatProLib.Hesap.Hesap.Icra hsp = new AvukatProLib.Hesap.Hesap.Icra(foy, true);
            //}
        }

        public static void HesaplamaIslemi()
        {
            CompInfo gio = CompInfo.CmpNfoList[0];

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = gio.ConStr;

            var ci = gio;

            if (ci != null)
            {
                SqlNetTiersProvider prov = new SqlNetTiersProvider();
                System.Collections.Specialized.NameValueCollection nameValueCollection =
                    new System.Collections.Specialized.NameValueCollection();
                nameValueCollection.Add("UseStoredProcedure", "true");
                nameValueCollection.Add("EnableEntityTracking", "true");
                nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
                nameValueCollection.Add("EnableMethodAuthorization", "false");
                nameValueCollection.Add("ConnectionString", ci.ConStr);
                nameValueCollection.Add("ConnectionStringName", "conStr" + ci.LisansBilgisi.AdSoyad);
                nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
                prov.Initialize(ci.LisansBilgisi.AdSoyad, nameValueCollection);
                DataRepository.LoadProvider(prov, true);

            }

            AvukatProLib.Arama.AvpDataContext db = new AvukatProLib.Arama.AvpDataContext(gio.ConStr);
            BelgeUtil.Inits.context = db;

            AvukatProLib.Kimlik.SirketBilgisi = gio;
            AV001_TI_BIL_FOY item;
            foreach (var id in db.AV001_TI_BIL_FOYs.Select(q => q.ID))
            {
                item = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(id);
                try
                {
                    AvukatProLib.Hesap.Hesap.Icra hy = new AvukatProLib.Hesap.Hesap.Icra(item);
                    hy = null;
                    item = null;
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Toplu Hesap Hata TAKİP Id=" + item.ID, ex);
                }
                GC.Collect();
            }
        }

        public static void MailIslem()
        {
        }

        public static void SmsIslem()
        {
        }

        public static void TarafGelismeIslem()
        {
            CompInfo gio = CompInfo.CmpNfoList[0];

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = gio.ConStr;
            DataTable MyDataSource = cn.GetDataTable("SELECT * FROM dbo.VI_BIL_ICRA_TARAF_GELISMELERI(nolock)");

            SqlNetTiersProvider prov = new SqlNetTiersProvider();
            System.Collections.Specialized.NameValueCollection nameValueCollection = new System.Collections.Specialized.NameValueCollection();
            nameValueCollection.Add("UseStoredProcedure", "true");
            nameValueCollection.Add("EnableEntityTracking", "true");
            nameValueCollection.Add("EntityCreationalFactoryType", "AvukatProLib2.Entities.EntityFactory");
            nameValueCollection.Add("EnableMethodAuthorization", "false");
            nameValueCollection.Add("ConnectionString", gio.ConStr);
            nameValueCollection.Add("ConnectionStringName", "conStr" + gio.LisansBilgisi.AdSoyad);
            nameValueCollection.Add("ProviderInvariantName", "System.Data.SqlClient");
            prov.Initialize(gio.LisansBilgisi.AdSoyad, nameValueCollection);
            DataRepository.LoadProvider(prov, true);

            AvukatProLib.Arama.AvpDataContext db = new AvukatProLib.Arama.AvpDataContext(gio.ConStr);
            BelgeUtil.Inits.context = db;

            TList<AV001_TI_BIL_FOY> foyler = new TList<AV001_TI_BIL_FOY>();
            foreach (DataRow data in MyDataSource.Rows)
            {
                if (data["ICRA_FOY_ID"] != DBNull.Value && !foyler.Contains(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)data["ICRA_FOY_ID"])))
                    foyler.Add(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)data["ICRA_FOY_ID"]));
            }

            foyler.Distinct();

            foreach (var foy in DataRepository.AV001_TI_BIL_FOYProvider.GetAll())
            {
                if (DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_ID(foy.ID).Count < 1)
                    foyler.Add(foy);
            }

            if (foyler.Count > 0)
            {
                foreach (var foy in foyler)
                {
                    if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

                    TList<AV001_TI_BIL_FOY_TARAF> taraflar = foy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(t => !t.TAKIP_EDEN_MI && t.CARI_ID.HasValue);
                    if (taraflar.Count > 0)
                    {
                        foreach (var taraf in taraflar)
                        {
                            int borcluID = (int)taraf.CARI_ID;

                            AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.CurrBorcluId = borcluID;
                            AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.BorcluCariID = borcluID;
                            AV001_TI_BIL_FOY_TARAF_GELISME guncellenecekGelisme = AdimAdimDavaKaydi.UserControls.IcraTakipUserControls.ucIcraTarafGelismeleri.GelismeleriGuncelle(foy, null)[0];

                            if (!guncellenecekGelisme.ICRA_FOY_ID.HasValue)
                                guncellenecekGelisme.ICRA_FOY_ID = foy.ID;
                            if (!guncellenecekGelisme.ICRA_FOY_TARAF_ID.HasValue)
                                guncellenecekGelisme.ICRA_FOY_TARAF_ID = taraf.ID;

                            DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.Save(guncellenecekGelisme);
                        }
                    }
                }
            }
        }

        public static void TebligatIslem()
        {
            CompInfo smtpInfo = CompInfo.CmpNfoList[0];

            #region MyRegion

            //        SqlCommand cmd1 = new SqlCommand(" select  PTT_BARKOD_NO,ID from BARKOD.dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP", con);
            //SqlDataReader dr = cmd1.ExecuteReader();
            //while (dr.Read())
            //{
            //    if (dr[0].ToString() != "" && dr[0].ToString() != null)
            //    {
            //        SqlConnection con2 = new SqlConnection(smtpInfo.smtpInfo.ConStr);
            //        con2.Open();

            // #region pttTopluSorgulamaV1 özel barkodlarda çalışmıyor
            // //pttTopluSorgulama.GonderiTakipService srg = new
            // pttTopluSorgulama.GonderiTakipService(); //srg.Url =
            // "https://pttws.ptt.gov.tr/TopluTakip/services/GonderiTakip?wsdl";
            // //pttTopluSorgulama.KurumRumuzSorguInput krsi = new
            // pttTopluSorgulama.KurumRumuzSorguInput(); //krsi.ilk_Barkod = "4290000000803";
            // //krsi.musteriId = 5373; //krsi.son_Barkod = "4290000000803"; //krsi.rezerv1
            // ="0123456789"; //krsi.rezerv2 = "0123456789"; //krsi.rezerv3 = "0123456789";

            // //pttTopluSorgulama.KurumRumuzSorgu krsrg; //krsrg= srg.gonderiSorgula(krsi);
            // //foreach (pttTopluSorgulama.GonderiSafahat item in krsrg.safahatlar) //{ //
            // item.ToString(); //}

            // #endregion

            // #region pttTekliSorgulamaV2 çalışıyor safaat veriyor fakat sonuç bilgisi gelmiyor

            // pttGonderiTakipV2.Input inpt = new Input(); inpt.barkod = "4290000000803";
            // inpt.kullanici = _kullanici; inpt.sifre = _sifre;

            // pttGonderiTakipV2.Sorgu srg = new Sorgu(); pttGonderiTakipV2.OutputTum optum = new
            // OutputTum(); srg.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";

            // optum = srg.gonderiSorgu(inpt);

            // #endregion

            // #region pttTopluSorgulamaV2

            // pttTopluSorgulamaV2.GonderiTakip gontakip = new pttTopluSorgulamaV2.GonderiTakip();

            // pttTopluSorgulamaV2.KurumRumuzSorgu krmSorgu; pttTopluSorgulamaV2.GonderiSafahat[]
            // safahatlar; pttTopluSorgulamaV2.KurumRumuzSorguInput kurumInput = new
            // pttTopluSorgulamaV2.KurumRumuzSorguInput(); //string tel = "2650150024548";

            // kurumInput.ilk_Barkod = "4290000000803"; kurumInput.son_Barkod = "4290000000803";
            // kurumInput.rezerv1 = "0123456789"; kurumInput.rezerv2 = "0123456789";
            // kurumInput.rezerv3 = "0123456789"; kurumInput.musteriId = 5373;
            // kurumInput.musteriIdSpecified = true; gontakip.Url =
            // "https://pttws.ptt.gov.tr/TopluTakipV2/services/GonderiTakip?wsdl"; krmSorgu =
            // gontakip.gonderiSorgula(kurumInput);

            // string a = krmSorgu.SONUC; safahatlar = krmSorgu.safahatlar; foreach (var item in
            // safahatlar) { string _barkod = item.BARKOD; string _imerk = item.IMERK; string _islem
            // = item.ISLEM; string _iTarih = item.ITARIH; string _rezerv1 = item.REZERVE_SONUC1;
            // string _rezerv2 = item.REZERVE_SONUC2; try { if (_barkod != null && _barkod != "") {
            // //string _ALICI = opTum.ALICI; //string _BARNO = opTum.BARNO; //string _DEGKONUCR =
            // opTum.DEGKONUCR; //// opDonArry = opTum.dongu;

            // //opDonArry = opTum.dongu; ////string dongustring = opTum2.dongu[0].ToString();
            // //string _AlanCariAd = ""; //foreach (OutputDongu item in opDonArry) //{ // if
            // (item.ISLEM.ToString() == "21.MAD. GORE MUHTARA TESLiM") // { // _AlanCariAd =
            // "MUHTARA"; // } // else if (item.ISLEM.ToString() == "21.MAD. GORE MUHTARA TESLiM")
            // // { // } // string aa = item.IMERK.ToString(); // string b = item.ISLEM.ToString();
            // //} //string _EKHIZ = opTum.EKHIZ; //string _GONDEREN = opTum.GONDEREN; //string
            // _GONUCR = opTum.GONUCR; //string _GR = opTum.GR; //string _IMERK = opTum.IMERK;
            // //string _ITARIH = opTum.ITARIH; //string _ODSARUCR = opTum.ODSARUCR; //string
            // _sonucAciklama = opTum.sonucAciklama; //int _sonucKodu = (int)opTum.sonucKodu;
            // //string _TESALAN = opTum.TESALAN; //string _VMERK = opTum.VMERK;

            // // AV001_TDI_BIL_TEBLIGAT_MUHATAP myAV001_TDI_BIL_TEBLIGAT_MUHATAP = new
            // AV001_TDI_BIL_TEBLIGAT_MUHATAP();

            // // myAV001_TDI_BIL_TEBLIGAT_MUHATAP = item; string UpdateCommand = "update
            // AV001_TDI_BIL_TEBLIGAT_MUHATAP set ALAN_CARI_AD='" + _rezerv2 + "',"; //SqlCommand
            // cmd2 = new SqlCommand("AV001_TDI_BIL_TEBLIGAT_MUHATAP ALAN_CARI_AD", con);
            // //cmd2.ExecuteNonQuery(); //cmd2.Dispose(); //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALAN_CARI_AD = _TESALAN; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.ALIM_SEKIL_ID string yil = ""; string ay = "";
            // string gun = ""; for (int i = 0; i < _iTarih.Length; i++) { if (i < 4) { yil = yil +
            // _iTarih[i].ToString(); } else if (i < 6) { ay = ay + _iTarih[i].ToString(); } else {
            // gun = gun + _iTarih[i].ToString(); } } string tarih = gun + "." + ay + "." + yil; if
            // (_rezerv1 != "islem basarili") { //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TARIHI =
            // _ITARIH; //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.BILA_TEBLIG_MI = true; UpdateCommand =
            // UpdateCommand + "BILA_TEBLIG_MI=1,"; UpdateCommand = UpdateCommand + "BILA_TARIHI='"
            // + tarih + "',"; } else if (_rezerv1 == "islem basarili") { UpdateCommand =
            // UpdateCommand + "BILA_TEBLIG_MI=0,"; UpdateCommand = UpdateCommand + "TEBLIG_TARIH='"
            // + tarih + "',"; //myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIG_TARIH = _ITARIH; }

            // //foreach (tr.gov.ptt.pttws.OutputDongu myOutputDongu in opDonArry) //{ //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA =
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + "sıra:" + myOutputDongu.siraNo +
            // "İşlem Merkezi :" + myOutputDongu.IMERK + "İşlem: " + myOutputDongu.ISLEM + "Tarih:"
            // + myOutputDongu.ITARIH; // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA =
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TB_ACIKLAMA + Environment.NewLine;

            // //} // UpdateCommand = UpdateCommand + "KONTROL_KIM_ID=" + Kimlikci.Kimlik.Bilgi.ID +
            // ","; // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            // // UpdateCommand = UpdateCommand + "KONTROL_KIM='" +
            // Kimlikci.Kimlik.Bilgi.KONTROL_KIM + "',"; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_KIM = Kimlikci.Kimlik.Bilgi.KONTROL_KIM; //
            // UpdateCommand = UpdateCommand + "KONTROL_NE_ZAMAN='" +
            // Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN + "',"; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_NE_ZAMAN =
            // Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN; // UpdateCommand = UpdateCommand +
            // "KONTROL_VERSIYON='" + Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON + "',"; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.KONTROL_VERSIYON =
            // Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON; UpdateCommand = UpdateCommand +
            // "POSTA_DURUM='" + _rezerv1 + "',"; // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_DURUM =
            // _sonucAciklama;

            // // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTA_SON_ISLEM_TARIHI = _ITARIH;

            // UpdateCommand = UpdateCommand + "POSTA_SON_ISLEM_TARIHI='" + tarih + "',";
            // UpdateCommand = UpdateCommand + "POSTAHANE='" + _imerk + "',"; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTAHANE = _IMERK; UpdateCommand = UpdateCommand +
            // "POSTALANDI_MI=1 where ID=" + dr[1] + ""; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.POSTALANDI_MI = true; // UpdateCommand =
            // UpdateCommand + "STAMP='" + Kimlikci.Kimlik.Bilgi.STAMP + "',"; //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.STAMP = Kimlikci.Kimlik.Bilgi.STAMP; //
            // UpdateCommand = UpdateCommand + "SUBE_KOD_ID='" + Kimlikci.Kimlik.Bilgi.SUBE_ID + "'
            // where ID="+dr[1]+""; // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.SUBE_KOD_ID =
            // Kimlikci.Kimlik.Bilgi.SUBE_ID; // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_ADRESI //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SEKLI_ID //
            // myAV001_TDI_BIL_TEBLIGAT_MUHATAP.TEBLIGAT_SONUC_ID SqlCommand cmd2 = new
            // SqlCommand(UpdateCommand, con2); cmd2.ExecuteNonQuery(); cmd2.Dispose();
            // con2.Close(); con2.Dispose(); //
            // DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.Update(myAV001_TDI_BIL_TEBLIGAT_MUHATAP);
            // } } catch (Exception) { } } #endregion

            // //pttGonderiTakipV2.Sorgu srgSrvc = new pttGonderiTakipV2.Sorgu();

            // //pttGonderiTakipV2.Input inpt = new pttGonderiTakipV2.Input();

            // //pttGonderiTakipV2.OutputTum opTum = new pttGonderiTakipV2.OutputTum();

            // //pttGonderiTakipV2.OutputDongu[] opDonArry;

            // //inpt.barkod = "TB01653205279";//"4290000000780";

            // //inpt.kullanici = "PttWs";

            // //inpt.sifre = "YazDes*1840";

            // //srgSrvc.Url = "https://pttws.ptt.gov.tr/GonderiTakipV2/services/Sorgu?wsdl";
            // //srgSrvc.Timeout = Int32.MaxValue; //opTum = srgSrvc.gonderiSorgu(inpt);

            // //string _sonucAciklama = opTum.sonucAciklama;

            // //opDonArry = opTum.dongu;

            // }
            //}

            #endregion MyRegion

            string _barkod = "";
            SqlConnection con1 = new SqlConnection(smtpInfo.ConStr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select PTT_BARKOD_NO  from  AV001_TDI_BIL_TEBLIGAT_MUHATAP WHERE TEBLIGAT_SONUC_ID IS NULL AND LEN(PTT_BARKOD_NO)>12", con1);
            cmd1.CommandTimeout = 1000;
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                _barkod = dr[0].ToString();
                if (_barkod.Length > 12)
                {
                    barkodİslemleri brkdislem = new barkodİslemleri();
                    brkdislem.barkodSorgula(_barkod);
                }
            }
            dr.Close();
            dr.Dispose();
            cmd1.Dispose();
            con1.Close();
            con1.Dispose();
        }

        public static string TurkceKarakterleriDuzelt(string str)
        {
            str = str.Replace("ç", "c");
            str = str.Replace("ı", "i");
            str = str.Replace("ğ", "g");
            str = str.Replace("ö", "o");
            str = str.Replace("ş", "s");
            str = str.Replace("ü", "u");
            str = str.Replace("İ", "I");
            str = str.Replace("Ğ", "G;");
            str = str.Replace("Ö", "O");
            str = str.Replace("Ş", "S");
            str = str.Replace("Ü", "U");
            str = str.Replace("Ç", "C");
            return str;
        }

        public static void UyapIslem()
        {
        }

        public static void YedekServisi()
        {
            CompInfo gio = CompInfo.CmpNfoList[0];

            string DosyaYolu = gio.YedekServisiDosyaYolu;
            if (string.IsNullOrEmpty(DosyaYolu))
                DosyaYolu = "C:\\YedekServisi";

            if (!Directory.Exists(DosyaYolu))
                Directory.CreateDirectory(DosyaYolu);

            string dosyaAdi = gio.HAVeriTabani + "_" + DateTime.Today.Day.ToString().PadLeft(2, '0') + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Year;

            SqlConnection con = new SqlConnection(gio.ConStr);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand("backup database " + gio.HAVeriTabani + " to disk = '" + DosyaYolu + "\\" + dosyaAdi + ".bak' with INIT", con);
            cmd.CommandTimeout = 999999999;
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
    }
}