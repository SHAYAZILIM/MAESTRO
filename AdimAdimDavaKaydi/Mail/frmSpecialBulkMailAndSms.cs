using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Mail
{
    public partial class frmSpecialBulkMailAndSms : Form
    {
        int basarili = 0;
        int basarisiz = 0;
        private string _ADLI_BIRIM_ADLIYE;
        private string _ADLI_BIRIM_NO;
        private string _ESAS_NO;
        private string _FOY_NO;
        private string _howSend;
        private decimal _KALAN;
        private string _KALAN_DOVIZ;
        private string _KALAN_DOVIZ_ID;
        private DataColumn dc_ADLI_BIRIM_ADLIYE = new DataColumn("_ADLI_BIRIM_ADLIYE");
        private DataColumn dc_ADLI_BIRIM_NO = new DataColumn("_ADLI_BIRIM_NO");
        private DataColumn dc_ESAS_NO = new DataColumn("_ESAS_NO");
        private DataColumn dc_FOY_NO = new DataColumn("_FOY_NO");
        private DataColumn dc_KALAN = new DataColumn("_KALAN");
        private DataColumn dc_KALAN_DOVIZ = new DataColumn("_KALAN_DOVIZ");
        private DataColumn dcAd = new DataColumn("Ad");
        private DataColumn dcCepTel = new DataColumn("CepTel");
        private DataColumn dcCepTel2 = new DataColumn("CepTel2");
        private DataColumn dcEmail1 = new DataColumn("Email1");
        private DataColumn dcEmail2 = new DataColumn("Email2");
        private DataColumn dcEvFax = new DataColumn("EvFax");
        private DataColumn dcFax = new DataColumn("Fax");
        private DataColumn dcFirmaMi = new DataColumn("FirmaMi");
        private DataColumn dcFirmaTurId = new DataColumn("FirmaTurId");
        private DataColumn dcId = new DataColumn("Id");
        private DataColumn dcTcKimlikNo = new DataColumn("TcKimlikNo");
        private DataTable dt = new DataTable();
        private string nerden = "";
        private string OzellestirilmisMesaj;
        private CompInfo smtpInfo = CompInfo.CmpNfoList[0];

        public frmSpecialBulkMailAndSms()
        {
            InitializeComponent();
        }

        public void chkBoxControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            rchTxtMesaj1.Text = "";

            if (chkBoxAdiSMS.Checked == true)
            {
                rchTxtMesaj1.Text = @"Sn.[Ad],";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
            }
            if (chkBoxAdliyeBilgileriSMS.Checked == true)
            {
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "[Adliye] [AdliBirimNo] [AdliBirim]";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
            }
            if (chkBoxEsasSMS.Checked == true)
            {
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "[EsasNo] sayılı dosyası";
            }
            if (chkBoxDosyaBakiyesiSMS.Checked == true)
            {
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "(Dosya bakiyesi: [Bakiye] [BakiyeDövizTip])";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
            }
            if (chkBoxBuroDosyaNoSMS.Checked == true)
            {
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "(Foy No :[FoyNo])";
            }
            rchTxtMesaj1.Text = rchTxtMesaj1.Text + "+Mesaj";
            rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
            if (chkBoxSMSIletisimTel.Checked != true || rchTxtMesaj1.Text.Contains("İletişim:[Tel]"))
            {
            }
            else
            {
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "İletişim:[Tel]";
            }
        }

        public void Show(List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> foyler, string howSend)
        {
            nerden = "taraf gelişme";
            _howSend = howSend;
            dt.Columns.Add(dcId);
            dt.Columns.Add(dcAd);
            dt.Columns.Add(dcEmail1);
            dt.Columns.Add(dcEmail2);
            dt.Columns.Add(dcCepTel);
            dt.Columns.Add(dcCepTel2);
            dt.Columns.Add(dcFax);
            dt.Columns.Add(dcEvFax);
            dt.Columns.Add(dcTcKimlikNo);
            dt.Columns.Add(dcFirmaMi);
            dt.Columns.Add(dcFirmaTurId);
            dt.Columns.Add(dc_ADLI_BIRIM_ADLIYE);
            dt.Columns.Add(dc_ADLI_BIRIM_NO);
            dt.Columns.Add(dc_ESAS_NO);
            dt.Columns.Add(dc_KALAN);
            dt.Columns.Add(dc_KALAN_DOVIZ);
            dt.Columns.Add(dc_FOY_NO);
            List<AvukatProLib.Arama.per_AV001_TI_BIL_ICRA_Arama> myFoys = foyler;
            for (int i = 0; i < myFoys.Count; i++)
            {
                _FOY_NO = myFoys[i].FOY_NO;
                _ADLI_BIRIM_ADLIYE = myFoys[i].ADLI_BIRIM_ADLIYE;
                _ADLI_BIRIM_NO = myFoys[i].ADLI_BIRIM_NO;
                _ESAS_NO = myFoys[i].ESAS_NO;
                _KALAN = Convert.ToDecimal(String.Format("{0:0.00}", myFoys[i].KALAN));
                _KALAN_DOVIZ_ID = myFoys[i].KALAN_DOVIZ_ID.ToString();
                TDI_KOD_DOVIZ_TIP myTDI_KOD_DOVIZ_TIP = DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetByID(Convert.ToInt32(_KALAN_DOVIZ_ID));
                _KALAN_DOVIZ = myTDI_KOD_DOVIZ_TIP.DOVIZ_KODU;

                foreach (var item2 in AvukatPro.Services.Implementations.BaseService._db.Av001TdiBilCari.Where(k => k.Id == (int)myFoys[i].TAKIP_EDILEN_CARI_ID).ToList())
                {
                    string TcKimlikNo = tcKimlikGetir(myFoys[i].TAKIP_EDILEN_CARI_ID.ToString());
                    if (TcKimlikNo == "")
                    {
                        TcKimlikNo = "YOK";
                    }

                    if (item2.Email1 == "" || item2.Email1 == null)
                    {
                        item2.Email1 = "YOK";
                    }
                    if (item2.Email2 == "" || item2.Email2 == null)
                    {
                        item2.Email2 = "YOK";
                    }
                    if (item2.CepTel == "" || item2.CepTel == null)
                    {
                        item2.CepTel = "YOK";
                    }
                    if (item2.CepTel2 == "" || item2.CepTel2 == null)
                    {
                        item2.CepTel2 = "YOK";
                    }
                    if (item2.Fax == "" || item2.Fax == null)
                    {
                        item2.Fax = "YOK";
                    }
                    if (item2.EvFax == "" || item2.EvFax == null)
                    {
                        item2.EvFax = "YOK";
                    }
                    bool kaydet = true;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (item2.Id.ToString() == dt.Rows[j][0].ToString() && _FOY_NO == dt.Rows[j]["_FOY_NO"].ToString())
                        {
                            kaydet = false;
                        }
                    }
                    if (kaydet)
                    {
                        dt.Rows.Add(item2.Id, item2.Ad, item2.Email1, item2.Email2, item2.CepTel, item2.CepTel2, item2.Fax, item2.EvFax, TcKimlikNo, item2.FirmaMi, item2.FirmaTurId, _ADLI_BIRIM_ADLIYE, _ADLI_BIRIM_NO, _ESAS_NO, _KALAN, _KALAN_DOVIZ, _FOY_NO);
                    }
                }
            }
            this.Show();
        }

        public void Show(DataTable mydt, string howSend)
        {
            dt.Columns.Add(dcId);
            dt.Columns.Add(dcAd);
            dt.Columns.Add(dcEmail1);
            dt.Columns.Add(dcEmail2);
            dt.Columns.Add(dcCepTel);
            dt.Columns.Add(dcCepTel2);
            dt.Columns.Add(dcFax);
            dt.Columns.Add(dcEvFax);
            dt.Columns.Add(dcTcKimlikNo);
            dt.Columns.Add(dcFirmaMi);
            dt.Columns.Add(dcFirmaTurId);
            dt.Columns.Add(dc_ADLI_BIRIM_ADLIYE);
            dt.Columns.Add(dc_ADLI_BIRIM_NO);
            dt.Columns.Add(dc_ESAS_NO);
            dt.Columns.Add(dc_KALAN);
            dt.Columns.Add(dc_KALAN_DOVIZ);
            dt.Columns.Add(dc_FOY_NO);
            nerden = "cari arama";
            _howSend = howSend;

            foreach (DataRow item in mydt.Rows)
            {
                string TcKimlikNo = tcKimlikGetir(item[0].ToString());
                if (TcKimlikNo == "")
                {
                    TcKimlikNo = "YOK";
                }
                if (item[2] == "" || item[2] == null)
                {
                    item[2] = "YOK";
                }
                if (item[3] == "" || item[3] == null)
                {
                    item[3] = "YOK";
                }
                if (item[4] == "" || item[4] == null)
                {
                    item[4] = "YOK";
                }
                if (item[5] == "" || item[5] == null)
                {
                    item[5] = "YOK";
                }
                if (item[6] == "" || item[6] == null)
                {
                    item[6] = "YOK";
                }
                if (item[7] == "" || item[7] == null)
                {
                    item[7] = "YOK";
                }
                dt.Rows.Add(item[0], item[1], item[2], item[3], item[4], item[5], item[6], item[7], TcKimlikNo, "", "", "", "", "", "", "", "");
            }

            this.Show();
        }

        private void btnFaxGonder_Click(object sender, EventArgs e)
        {
        }

        private void btnMailGonder_Click(object sender, EventArgs e)
        {
            string mailGonderilenMail1 = "";
            string mailGonderilenMail2 = "";

            foreach (ListViewItem item in lswKimlereMail.Items)
            {
                for (int i = 1; i < lswKimlereMail.Columns.Count; i++)
                {
                    if (item.SubItems[i].Text != "YOK" && item.SubItems[i].Text != "")
                    {
                        if (i == 1)
                        {
                            mailGonderilenMail1 = item.SubItems[i].Text.Trim();
                        }
                        else if (i == 2)
                        {
                            mailGonderilenMail2 = item.SubItems[i].Text.Trim();
                        }
                    }
                }
                if (rdBtnEmail1Email2.Checked == true)
                {
                    if (rchTxtMail.Text != null && rchTxtMail.Text != "")
                    {
                        mailHazirla(mailGonderilenMail1, mailGonderilenMail2, rchTxtMail.Text);
                    }
                }
                else if (rdBtnEmail1.Checked == true)
                {
                    if (rchTxtMail.Text != null && rchTxtMail.Text != "")
                    {
                        mailHazirla(mailGonderilenMail1, "", rchTxtMail.Text);
                    }
                }
                else if (rdBtnEmail2.Checked == true)
                {
                    if (rchTxtMail.Text != null && rchTxtMail.Text != "")
                    {
                        mailHazirla("", mailGonderilenMail2, rchTxtMail.Text);
                    }
                }
            }
        }

        private void btnOnizleme_Click(object sender, EventArgs e)
        {
            string Ad = lswKimlereSms.Items[lswKimlereSms.Items.Count - 1].Text;
            OzellestirilmisMesaj = rchTxtMesaj1.Text;
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[Ad]", Ad);
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[Adliye]", _ADLI_BIRIM_ADLIYE);
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[AdliBirimNo]", _ADLI_BIRIM_NO);
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[AdliBirim]", "İCRM.");
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[EsasNo]", _ESAS_NO);
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[Bakiye]", _KALAN.ToString());
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[BakiyeDövizTip]", _KALAN_DOVIZ);
            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[FoyNo]", _FOY_NO);
            if (chkBoxSMSIletisimTel.Checked == true)
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("[Tel]", txtBoxSMSIletisimTel.Text);
            }
            else
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("İletişim:[Tel]", "");
            }

            OzellestirilmisMesaj = OzellestirilmisMesaj.Replace("+Mesaj", " "+rchTxtMesaj2.Text);

            MessageBox.Show(OzellestirilmisMesaj);
        }

        private void btnSMSGonder_Click(object sender, EventArgs e)
        {
            OzellestirilmisMesaj = "";
            if (chkBoxAdiSMS.Checked == true)
            {
                OzellestirilmisMesaj = @"Sn.[Ad],";
                OzellestirilmisMesaj = OzellestirilmisMesaj + Environment.NewLine;
            }
            if (chkBoxAdliyeBilgileriSMS.Checked == true)
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj + "[Adliye] [AdliBirimNo] [AdliBirim]";
                OzellestirilmisMesaj = OzellestirilmisMesaj + Environment.NewLine;
            }
            if (chkBoxEsasSMS.Checked == true)
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj + "[EsasNo] sayılı dosyası";
            }
            if (chkBoxDosyaBakiyesiSMS.Checked == true)
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj + "(Bakiye:[Bakiye][BakiyeDövizTip])";
                OzellestirilmisMesaj = OzellestirilmisMesaj + Environment.NewLine;
            }
            if (chkBoxBuroDosyaNoSMS.Checked == true)
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj + "(Foy:[FoyNo])";
            }
            OzellestirilmisMesaj = OzellestirilmisMesaj + " "+rchTxtMesaj2.Text;
            if (chkBoxSMSIletisimTel.Checked != true || OzellestirilmisMesaj.Contains("İletişim:[Tel]"))
            {
            }
            else
            {
                OzellestirilmisMesaj = OzellestirilmisMesaj + Environment.NewLine;
                OzellestirilmisMesaj = OzellestirilmisMesaj + "İletişim:[Tel]";
            }

            foreach (ListViewItem item in lswKimlereSms.Items)
            {
                string smsGonderilenNo1 = "";
                string smsGonderilenNo2 = "";
                string smsGonderilenTcNo = "";
                string FirmaTurId = "";
                string CariId = "";
                string CariAdi = "";
                CariId = ((DataRow)item.Tag)["Id"].ToString();
                for (int i = 1; i < lswKimlereSms.Columns.Count; i++)
                {
                    if (item.SubItems[i].Text != "YOK" && item.SubItems[i].Text != "")
                    {
                        if (i == 1)
                        {
                            smsGonderilenTcNo = item.SubItems[i].Text.Trim();
                        }
                        else if (i == 2)
                        {
                            smsGonderilenNo1 = item.SubItems[i].Text.Trim().TrimStart('0');
                        }
                        else if (i == 3)
                        {
                            smsGonderilenNo2 = item.SubItems[i].Text.Trim().TrimStart('0');
                        }
                    }
                }
                foreach (var a in AvukatPro.Services.Implementations.BaseService._db.Av001TdiBilCari.Where(k => k.Id == Convert.ToInt16(((DataRow)item.Tag)["Id"].ToString())).ToList())
                {
                    CariAdi = a.Ad;
                    if (a.FirmaMi == true)
                    {
                        FirmaTurId = a.FirmaTurId.ToString();
                    }
                }
                string OzellestirilmisMesajGonderilcek = OzellestirilmisMesaj;
                OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[Ad]", CariAdi);
                if (((DataRow)item.Tag)["_ADLI_BIRIM_ADLIYE"].ToString() != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[Adliye]", ((DataRow)item.Tag)["_ADLI_BIRIM_ADLIYE"].ToString());
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[Adliye]", "");
                }
                if (((DataRow)item.Tag)["_ADLI_BIRIM_NO"].ToString() != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[AdliBirimNo]", ((DataRow)item.Tag)["_ADLI_BIRIM_NO"].ToString());
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[AdliBirim]", "İCRM.");
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[AdliBirimNo]", "");
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[AdliBirim]", "");
                }
                if (((DataRow)item.Tag)["_ESAS_NO"].ToString() != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[EsasNo]", ((DataRow)item.Tag)["_ESAS_NO"].ToString());
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[EsasNo] sayılı dosyası", "");
                }
                if (((DataRow)item.Tag)["_KALAN"].ToString() != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[Bakiye]", ((DataRow)item.Tag)["_KALAN"].ToString());
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[BakiyeDövizTip]", ((DataRow)item.Tag)["_KALAN_DOVIZ"].ToString());
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("(Dosya bakiyesi: [Bakiye] [BakiyeDövizTip])", "");
                }
                if (((DataRow)item.Tag)["_FOY_NO"].ToString() != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[FoyNo]", ((DataRow)item.Tag)["_FOY_NO"].ToString());
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("(Foy No :[FoyNo])", "");
                }
                if (chkBoxSMSIletisimTel.Checked == true && txtBoxSMSIletisimTel.Text != "")
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("[Tel]", txtBoxSMSIletisimTel.Text);
                }
                else
                {
                    OzellestirilmisMesajGonderilcek = OzellestirilmisMesajGonderilcek.Replace("İletişim:[Tel]", "");
                }

                if (rdBtnCep1Cep2.Checked == true)
                {
                    if (rchTxtMesaj2.Text != null && rchTxtMesaj2.Text != "")
                    {
                        SmsHazirla(smsGonderilenNo1, smsGonderilenNo2, "", OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                    }
                }
                else if (rdBtnCep1Cep2Tc.Checked == true)
                {
                    if (rchTxtMesaj2.Text != null && rchTxtMesaj2.Text != "")
                    {
                        SmsHazirla(smsGonderilenNo1, smsGonderilenNo2, smsGonderilenTcNo, OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                    }
                }
                else if (rdBtnCep1.Checked == true)
                {
                    if (OzellestirilmisMesajGonderilcek != null && OzellestirilmisMesajGonderilcek != "")
                    {
                        SmsHazirla(smsGonderilenNo1, "", "", OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                    }
                }
                else if (rdBtnCep2.Checked == true)
                {
                    if (OzellestirilmisMesajGonderilcek != null && OzellestirilmisMesajGonderilcek != "")
                    {
                        SmsHazirla("", smsGonderilenNo2, "", OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                    }
                }
                else if (rdBtnTcNo.Checked == true)
                {
                    if (OzellestirilmisMesajGonderilcek != null && OzellestirilmisMesajGonderilcek != "")
                    {
                        SmsHazirla("", "", smsGonderilenTcNo, OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                    }
                }
                else if (rdBtnCepOrTc.Checked == true)
                {
                    if (OzellestirilmisMesajGonderilcek != null && OzellestirilmisMesajGonderilcek != "")
                    {
                        if (smsGonderilenNo1 == "" || smsGonderilenNo1 == "YOK")
                        {
                            if (smsGonderilenNo2 == "" || smsGonderilenNo2 == "YOK")
                            {
                                SmsHazirla("", "", smsGonderilenTcNo, OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                            }
                            else
                            {
                                SmsHazirla("", smsGonderilenNo2, "", OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                            }
                        }
                        else
                        {
                            SmsHazirla(smsGonderilenNo1, "", "", OzellestirilmisMesajGonderilcek, CariId, CariAdi, FirmaTurId);
                        }
                    }
                }
            }
            MessageBox.Show(basarili + " adet başarılı " + basarisiz + " adet başarısız gönderim gerçekleşti ");
            basarisiz = 0;
            basarili = 0;
        }

        private void cbKonuSMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nerden == "cari arama")
            {
                switch (cbKonuSMS.SelectedItem.ToString())
                {
                    case "Genel": rchTxtMesaj2.Text = "";
                        break;

                    case "Yılbaşı": rchTxtMesaj2.Text = @" Geleceği oluşturacak her yeni günün bir önceki günden daha güzel, isteklerinize uygun ve sizi daha huzurlu, sağlıklı ve mutlu etmesi dileğiyle. Mutlu Yıllar!";
                        break;

                    case "Ramazan Bayramı": rchTxtMesaj2.Text = @" Mübarek ramazan Bayramı Size ve Ailenize Bol Mutluluk Bol Huzur Ve Refah dolu bir Hayat Getirsin, Bu Bayramın Güzelliğini ve Bereketini Evinize Getirsin Kalbinizdeki Sevgiyi, Geleceğe Umutlarınızı arttırsın.Ramazan Bayramınız Kutlu Olsun.";
                        break;

                    case "Kurban Bayramı": rchTxtMesaj2.Text = @"Kuskunlerin Baristigi, Sevenlerin Bir Araya Geldigi, Rahmet Ve Sefkat Dolu Gunlerin En Degerlilerinden Olan Kurban Bayraminiz Kutlu Olsun.";
                        break;

                    case "Doğum Günü": rchTxtMesaj2.Text = @"Nice yaşlarınızı sağlık, huzur, refah, mutluluk ve başarı ile geçirmeniz dileğiyle. Doğum gününüz kutlu olsun.";
                        break;

                    case "Kuruluş Yıldonümü": rchTxtMesaj2.Text = @"Çalışma Hayatımıza katkıları ile" + '"' + "Özenilen Kuruluş" + '"' + " olma yolundaki gelişimini sürdüren şirketinizin tüm çalışanlarının Kuruluş Yıldönümünü kutluyoruz.";
                        break;

                    case "Evlilik Yıldonümü": rchTxtMesaj2.Text = @"Her gününüz birbirinizi daha çok severek ve birbirinize daha çok bağlanarak geçsin. Hayat boyu sağlıklı, refah içinde, mutlu ve huzurlu yasayın! Yuvanızdan sevgi ve neş'e eksik olmasın.";
                        break;
                }
            }
            else
            {
                switch (cbKonuSMS.SelectedItem.ToString())
                {
                    case "Genel": rchTxtMesaj2.Text = "";
                        break;

                    case "Takip başlangıcı": rchTxtMesaj2.Text = " Hakkınızda İcra Takibi başlatılmıştır. Dosya Borcunuza daha fazla masraf ve faiz uygulanmaması için en kısa sürede büromuzu arayınız ";
                        break;

                    case "Kesinleşme": rchTxtMesaj2.Text = " Hakkınızda yapılan İcra Takibi kesinleşmiştir. Ev ve İş Yerinizdeki mallarınıza, hak ve alacaklarınıza haciz uygulanmasını istemiyorsanız en kısa sürede büromuzu arayınız.";
                        break;

                    case "Haciz": rchTxtMesaj2.Text = " Ev ve İş Yerinizdeki mallarınıza, hak ve alacaklarınıza haciz uygulanacaktır. Masrafların ve harçların artmasını istemiyorsanız en kısa sürede büromuzu arayınız.";
                        break;

                    case "Muhafaza": rchTxtMesaj2.Text = " Haczedilen mallarınız ev ve işyerinizden alınarak yeddemine teslim edilecek ve ek hacizler uygulanacaktır. Masrafların ve harçların artmasını istemiyorsanız en kısa sürede büromuzu arayınız.";
                        break;

                    case "Satış": rchTxtMesaj2.Text = " Haczedilen mallarınızın Satışı yapılacaktır. Mallarınız icra yolu ile değerinin % 40 ına kadar düşürülerek satılabilir ve ek hacizlere muhatap olabilirsiniz. Büromuzu arayınız.";
                        break;

                    case "Taahhüdü ihlal": rchTxtMesaj2.Text = " Büromuza vermiş olduğunuz ödeme taahüdünüzü ihlal etmiş bulunmaktasınız. Hakkınızda ceza davası açılacak ve hapis cezasına çarptırılacaksınız. Büromuzu arayınız";
                        break;
                }
            }
        }

        private void chkBoxSMSIletisimTel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSMSIletisimTel.Checked == false)
            {
                txtBoxSMSIletisimTel.Text = smtpInfo.SMSIletisimTel;
                txtBoxSMSIletisimTel.ReadOnly = true;
                if (rchTxtMesaj1.Text.Contains("İletişim:[Tel]"))
                {
                    if (chkBoxAdiSMS.Checked == true)
                    {
                        rchTxtMesaj1.Text = "Sn.[Ad]," + Environment.NewLine;
                    }
                    else
                    {
                        rchTxtMesaj1.Text = "";
                    }
                    rchTxtMesaj1.Text = rchTxtMesaj1.Text + "+Mesaj";
                }
            }
            else
            {
                txtBoxSMSIletisimTel.Text = smtpInfo.SMSIletisimTel;
                txtBoxSMSIletisimTel.ReadOnly = false;
                if (rchTxtMesaj1.Text.Contains("İletişim:[Tel]"))
                {
                }
                else
                {
                    if (chkBoxAdiSMS.Checked == true)
                    {
                        rchTxtMesaj1.Text = "Sn.[Ad]," + Environment.NewLine;
                    }
                    else
                    {
                        rchTxtMesaj1.Text = "";
                    }
                    rchTxtMesaj1.Text = rchTxtMesaj1.Text + "+Mesaj";
                    rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
                    rchTxtMesaj1.Text = rchTxtMesaj1.Text + "İletişim:[Tel]";
                }
            }
        }

        private void frmSpecialBulkMailAndSms_Load(object sender, EventArgs e)
        {
            txtBoxSMSIletisimTel.Text = smtpInfo.SMSIletisimTel;
            if (nerden == "cari arama")
            {
                comboBox2.Enabled = false;
                chkBoxAdliyeBilgileriSMS.Enabled = false;
                chkBoxBuroDosyaNoSMS.Enabled = false;
                chkBoxDosyaBakiyesiSMS.Enabled = false;
                chkBoxEsasSMS.Enabled = false;

                //cbKonuSMS.Enabled = false;

                chkBoxAdliyeBilgileriSMS.Checked = false;
                chkBoxBuroDosyaNoSMS.Checked = false;
                chkBoxDosyaBakiyesiSMS.Checked = false;
                chkBoxEsasSMS.Checked = false;
                rchTxtMesaj1.Text = "Sn.[Ad]," + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + " +Mesaj";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "İletişim:[Tel]";

                cbKonuSMS.Items.Clear();
                cbKonuSMS.Items.Add("Genel");
                cbKonuSMS.Items.Add("Yılbaşı");
                cbKonuSMS.Items.Add("Ramazan Bayramı");
                cbKonuSMS.Items.Add("Kurban Bayramı");
                cbKonuSMS.Items.Add("Doğum Günü");
                cbKonuSMS.Items.Add("Kuruluş Yıldonümü");
                cbKonuSMS.Items.Add("Evlilik Yıldonümü");
                cbKonuSMS.SelectedItem = "Genel";
            }
            else if (nerden == "taraf gelişme")
            {
                comboBox2.Enabled = false;
                cbKonuSMS.Items.Clear();
                cbKonuSMS.Items.Add("Genel");
                cbKonuSMS.Items.Add("Takip başlangıcı");
                cbKonuSMS.Items.Add("Kesinleşme");
                cbKonuSMS.Items.Add("Haciz");
                cbKonuSMS.Items.Add("Muhafaza");
                cbKonuSMS.Items.Add("Satış");
                cbKonuSMS.Items.Add("Taahhüdü ihlal");
                cbKonuSMS.SelectedItem = "Genel";
                rchTxtMesaj1.Text = "Sn.[Ad]," + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "[Adliye] [AdliBirimNo] [AdliBirim]" + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "[EsasNo] sayılı dosyası";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "(Dosya bakiyesi: [Bakiye] [BakiyeDövizTip])" + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "(Foy No :[FoyNo]);";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + " +Mesaj";
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + Environment.NewLine;
                rchTxtMesaj1.Text = rchTxtMesaj1.Text + "İletişim:[Tel]";
            }

            foreach (DataRow myrow in dt.Rows)
            {
                ListViewItem yeniSms = new ListViewItem();
                yeniSms.Tag = myrow;
                yeniSms.Text = myrow["Ad"].ToString();
                yeniSms.SubItems.Add(myrow["TcKimlikNo"].ToString());
                yeniSms.SubItems.Add(myrow["CepTel"].ToString());
                yeniSms.SubItems.Add(myrow["CepTel2"].ToString());
                lswKimlereSms.Items.Add(yeniSms);
                ListViewItem yeniMail = new ListViewItem();
                yeniMail.Tag = myrow;
                yeniMail.Text = myrow["Ad"].ToString();
                yeniMail.SubItems.Add(myrow["Email1"].ToString());
                yeniMail.SubItems.Add(myrow["Email2"].ToString());
                lswKimlereMail.Items.Add(yeniMail);
                ListViewItem yeniFax = new ListViewItem();
                yeniFax.Tag = myrow;
                yeniFax.Text = myrow["Ad"].ToString();
                yeniFax.SubItems.Add(myrow["Fax"].ToString());
                yeniFax.SubItems.Add(myrow["EvFax"].ToString());
                lswKimlereFax.Items.Add(yeniFax);
            }
            if (_howSend == "SendSms")
            {
                tabControl.SelectedIndex = 0;
            }
            else if (_howSend == "SendMail")
            {
                tabControl.SelectedIndex = 1;
            }
            else if (_howSend == "SendFax")
            {
                tabControl.SelectedIndex = 2;
            }
        }

        private void mailHazirla(string mail1, string mail2, string mailText)
        {
            if ((mail1 != "" && mail2 != "") && (mail1 != "YOK" && mail2 != "YOK") && (mail1 != "YOK" && mail2 != "") && (mail1 != "" && mail2 != "YOK"))
            {
                //MailGonder(mail1, mailText);

                //MailGonder(mail2, mailText);
            }
            else if (mail1 != "" && mail2 != "YOK")
            {
                try
                {
                    //if (sms == null)
                    //    sms = new SMSMakinesi.Gateway();
                    //sms.clearsmsbasket();
                    //if (mailText.ToString() != string.Empty)
                    //    sms.addtosmsbasket(TKCeptDuzelt(mailText.ToString()), CepTelFormatla(mail1.Trim()));
                    //string result;
                    //if (mailText.Length <= 160)
                    //    result = sms.sendsms(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                    //else
                    //    result = sms.sendsmsconcat(SMSKullaniciAdi, SMSSifre, SMSGonderen, "", SMSVendorID);
                    //sms.clearsmsbasket();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            else if (mail2 != "" && mail2 != "YOK")
            {
                //MailGonder(mail2, mailText);
            }
        }

        private void rchTxtMesaj_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            char[] c = new char[rchTxtMesaj1.Text.Length];
            for (int i = 0; i < rchTxtMesaj1.Text.Length; i++)
            {
                c[i] = Convert.ToChar(rchTxtMesaj1.Text[i]);
            }
            char[] c2 = new char[rchTxtMesaj2.Text.Length];
            for (int i = 0; i < rchTxtMesaj2.Text.Length; i++)
            {
                c2[i] = Convert.ToChar(rchTxtMesaj2.Text[i]);
            }

            lblCharCount.Text = "mesaj: " + (c.Length + c2.Length).ToString() + "karakter" + " : " + ((c.Length + c2.Length) / 160 + 1).ToString() + " Mesaj ";
        }

        private void SmsGonder(string cepNo, string mesaj, string CariId, string CariAdi, string FirmaTurId)
        {
            SMS mySMS = new SMS();

            //mySMS.IDyeGoreRapor("1481");
            //SMS mySMS = new SMS();
            string[] sonuc = mySMS.SMSGonder(cepNo.Trim(), "",mesaj);
            if (sonuc[0] == "İşlem başarıyla gerçekleştirildi.")
            {
                int MesajDbId = SmsMesajKaydet(mesaj, "0");
                SmsRaporDuzenle(cepNo, "0", sonuc[1].ToString(), CariId, CariAdi, FirmaTurId, mesaj, MesajDbId);

                //mySMS.IDyeGoreRapor(sonuc[1].ToString());
                //MessageBox.Show("mesaj gönderilmiştir");
                basarili++;
            }
            else
            {
                //MessageBox.Show("hata : " + sonuc[0].ToString());
                basarisiz++;
            }
        }

        private void SmsGonder(string cepNo1, string cepNo2, string mesaj, string CariId, string CariAdi, string FirmaTurId)
        {
            SMS mySMS = new SMS();

            //mySMS.IDyeGoreRapor("1481");
            //SMS mySMS = new SMS();

            string[] sonuc = mySMS.SMSGonder(cepNo1.Trim(), cepNo2.Trim(), mesaj);
            if (sonuc[0] == "İşlem başarıyla gerçekleştirildi.")
            {
                int MesajDbId = SmsMesajKaydet(mesaj, "0");
                if (cepNo2 == "")
                {
                    SmsRaporDuzenle(cepNo1, "0", sonuc[1].ToString(), CariId, CariAdi, FirmaTurId, mesaj, MesajDbId);

                    //mySMS.IDyeGoreRapor(sonuc[1].ToString());
                }
                else
                {
                    SmsRaporDuzenle(cepNo1, "0", sonuc[1].ToString(), CariId, CariAdi, FirmaTurId, mesaj, MesajDbId);
                    SmsRaporDuzenle(cepNo2, "0", sonuc[1].ToString(), CariId, CariAdi, FirmaTurId, mesaj, MesajDbId);
                }

                //MessageBox.Show("mesaj gönderilmiştir");
                basarili++;
            }
            else
            {
                //MessageBox.Show("hata : " + sonuc[0].ToString());
                basarisiz++;
            }
        }

        private void SmsHazirla(string cepNo1, string cepNo2, string TcNo, string mesaj, string CariId, string CariAdi, string FirmaTurId)
        {
            if ((cepNo1 != "" && cepNo2 != "") && (cepNo1 != "YOK" && cepNo2 != "YOK") && (cepNo1 != "YOK" && cepNo2 != "") && (cepNo1 != "" && cepNo2 != "YOK"))
            {
                SmsGonder(cepNo1, cepNo2, mesaj, CariId, CariAdi, FirmaTurId);
            }
            else if (cepNo1 != "" && cepNo1 != "YOK")
            {
                SmsGonder(cepNo1, mesaj, CariId, CariAdi, FirmaTurId);
            }
            else if (cepNo2 != "" && cepNo2 != "YOK")
            {
                SmsGonder(cepNo2, mesaj, CariId, CariAdi, FirmaTurId);
            }
            else if (TcNo != "" && TcNo != "YOK")
            {
                TCSmsGonder(TcNo, mesaj, CariId, CariAdi, FirmaTurId);
            }
        }

        private int SmsMesajKaydet(string mesajMetni, string resultValue)
        {
            TSMS_BIL_MESAJ myTSMS_BIL_MESAJ = new TSMS_BIL_MESAJ();
            myTSMS_BIL_MESAJ.ORGINATOR = "TURKCELL";
            myTSMS_BIL_MESAJ.TEKRAR_UST_SINIR = 0;
            myTSMS_BIL_MESAJ.TEKRAR_PERYOD = 0;
            myTSMS_BIL_MESAJ.MESAJ_METNI = mesajMetni;
            myTSMS_BIL_MESAJ.SAYFA_NO = 0;
            switch (Convert.ToInt32(resultValue))
            {
                case 0:
                    myTSMS_BIL_MESAJ.SON_GSM_OP_RESPONSE = "GSM Operatör- Başarılı";
                    break;

                case 1:
                    myTSMS_BIL_MESAJ.SON_GSM_OP_RESPONSE = "GSM Operatör- Başarısız";
                    break;

                case 2:
                    myTSMS_BIL_MESAJ.SON_GSM_OP_RESPONSE = "GSM Operatör- Bekliyor";
                    break;
                default:

                    break;
            }
            myTSMS_BIL_MESAJ.KAYIT_TARIHI = DateTime.Now;
            myTSMS_BIL_MESAJ.SUBE_KODU = (short)Kimlikci.Kimlik.Bilgi.SUBE_ID;
            myTSMS_BIL_MESAJ.KONTROL_NE_ZAMAN = Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN;
            myTSMS_BIL_MESAJ.KONTROL_KIM = Kimlikci.Kimlik.Bilgi.KONTROL_KIM;
            myTSMS_BIL_MESAJ.KONTROL_VERSIYON = Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON;
            myTSMS_BIL_MESAJ.STAMP = Kimlikci.Kimlik.Bilgi.STAMP;
            myTSMS_BIL_MESAJ.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            myTSMS_BIL_MESAJ.SUBE_KOD_ID = Kimlikci.Kimlik.Bilgi.SUBE_ID;
            DataRepository.TSMS_BIL_MESAJProvider.Save(myTSMS_BIL_MESAJ);
            return myTSMS_BIL_MESAJ.ID;

            #region ado.net version

            //           SqlConnection con = new SqlConnection(smtpInfo.ConStr);
            //            SqlCommand cmd = new SqlCommand(@"INSERT INTO [BOS].[dbo].[TSMS_BIL_MESAJ]
            //           ([ORGINATOR]
            //           ,[TEKRAR_UST_SINIR]
            //           ,[TEKRAR_PERYOD]
            //           ,[MESAJ_METNI]
            //           ,[SAYFA_NO]
            //           ,[SON_GSM_OP_RESPONSE]
            //           ,[KAYIT_TARIHI]
            //           ,[SUBE_KODU]
            //           ,[KONTROL_NE_ZAMAN]
            //           ,[KONTROL_KIM]
            //           ,[KONTROL_VERSIYON]
            //           ,[STAMP]
            //           ,[KONTROL_KIM_ID]
            //           ,[SUBE_KOD_ID])
            //     VALUES
            //           (@ORGINATOR
            //           ,@TEKRAR_UST_SINIR
            //           ,@TEKRAR_PERYOD
            //           ,@MESAJ_METNI
            //           ,@SAYFA_NO
            //           ,@SON_GSM_OP_RESPONSE
            //           ,getdate()
            //           ,@SUBE_KODU
            //           ,@KONTROL_NE_ZAMAN
            //           ,@KONTROL_KIM
            //           ,@KONTROL_VERSIYON
            //           ,@STAMP
            //           ,@KONTROL_KIM_ID
            //           ,@SUBE_KOD_ID); SELECT @@IDENTITY AS ID
            //");
            //            cmd.Parameters.AddWithValue("@ORGINATOR", "TURKCELL");
            //            cmd.Parameters.AddWithValue("@TEKRAR_UST_SINIR", 0);
            //            cmd.Parameters.AddWithValue("@TEKRAR_PERYOD", 0);
            //            cmd.Parameters.AddWithValue("@MESAJ_METNI", mesajMetni);
            //            cmd.Parameters.AddWithValue("@SAYFA_NO", 0);
            //            cmd.Parameters.AddWithValue("@SON_GSM_OP_RESPONSE", resultValue);
            //            cmd.Parameters.AddWithValue("@SUBE_KODU", Kimlikci.Kimlik.Bilgi.SUBE_ID);
            //            cmd.Parameters.AddWithValue("@KONTROL_NE_ZAMAN", Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN);
            //            cmd.Parameters.AddWithValue("@KONTROL_KIM", Kimlikci.Kimlik.Bilgi.KONTROL_KIM);
            //            cmd.Parameters.AddWithValue("@KONTROL_VERSIYON", Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON);
            //            cmd.Parameters.AddWithValue("@STAMP", Kimlikci.Kimlik.Bilgi.STAMP);
            //            cmd.Parameters.AddWithValue("@KONTROL_KIM_ID", Kimlikci.Kimlik.Bilgi.ID);
            //            cmd.Parameters.AddWithValue("@SUBE_KOD_ID", Kimlikci.Kimlik.Bilgi.SUBE_ID);
            //            int x = 0;
            //            if (con.State == System.Data.ConnectionState.Closed)
            //            {
            //                x = Convert.ToInt32(cmd.ExecuteScalar());

            //                con.Open();
            //                cmd.ExecuteNonQuery();
            //            }
            //            if (con.State == System.Data.ConnectionState.Open)
            //                con.Close();
            //            con.Dispose();

            //            return x;

            #endregion ado.net version
        }

        private void SmsRaporDuzenle(string gsmNo, string resultValue, string MESAJ_ID, string CariId, string CariAdi, string FirmaTurId, string mesajMetni, int mesajDbId)
        {
            //SMS mySMS = new SMS();
            //DataTable dt=  mySMS.IDyeGoreRapor(MESAJ_ID);

            //TransactionManager tm=new TransactionManager()
            TSMS_BIL_MESAJ_NUMARA myTSMS_BIL_MESAJ_NUMARA = new TSMS_BIL_MESAJ_NUMARA();
            myTSMS_BIL_MESAJ_NUMARA.MESAJ_ID = mesajDbId;
            myTSMS_BIL_MESAJ_NUMARA.NUMARA_KAYNAK = 0;
            myTSMS_BIL_MESAJ_NUMARA.FIRMA_TABLO_KOD = FirmaTurId;
            myTSMS_BIL_MESAJ_NUMARA.CARI_ID = Convert.ToInt32(CariId);
            myTSMS_BIL_MESAJ_NUMARA.CARI_ADI = CariAdi;
            myTSMS_BIL_MESAJ_NUMARA.NUMARA = gsmNo;
            myTSMS_BIL_MESAJ_NUMARA.AKTIFLESME_TARIHI = DateTime.Now;
            myTSMS_BIL_MESAJ_NUMARA.PASIFLESME_TARIHI = DateTime.Now;
            myTSMS_BIL_MESAJ_NUMARA.SON_GONDERIM_ZAMANI = DateTime.Now;
            myTSMS_BIL_MESAJ_NUMARA.GONDERIM_SAYISI = 1;
            switch (Convert.ToInt32(resultValue))
            {
                case 0:
                    myTSMS_BIL_MESAJ_NUMARA.DURUM_ID = 4;
                    myTSMS_BIL_MESAJ_NUMARA.DURUM = "GSM Operatör- Başarılı";
                    break;

                case 1:
                    myTSMS_BIL_MESAJ_NUMARA.DURUM_ID = 6;
                    myTSMS_BIL_MESAJ_NUMARA.DURUM = "GSM Operatör- Başarısız";
                    break;

                case 2:
                    myTSMS_BIL_MESAJ_NUMARA.DURUM_ID = 5;
                    myTSMS_BIL_MESAJ_NUMARA.DURUM = "GSM Operatör- Bekliyor";
                    break;
                default:

                    break;
            }
            myTSMS_BIL_MESAJ_NUMARA.GSM_OP_MESAJ_ID = MESAJ_ID;
            myTSMS_BIL_MESAJ_NUMARA.GSM_OP_RAPOR_TARIHI = DateTime.Now;
            myTSMS_BIL_MESAJ_NUMARA.GSM_OP_RAPOR_DURUM = "";
            myTSMS_BIL_MESAJ_NUMARA.GSM_XML_SATIR_NO = 0;
            myTSMS_BIL_MESAJ_NUMARA.KAYIT_TARIHI = DateTime.Now;
            myTSMS_BIL_MESAJ_NUMARA.SUBE_KODU = (short)Kimlikci.Kimlik.Bilgi.SUBE_ID;
            myTSMS_BIL_MESAJ_NUMARA.KONTROL_NE_ZAMAN = Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN;
            myTSMS_BIL_MESAJ_NUMARA.KONTROL_KIM = Kimlikci.Kimlik.Bilgi.KONTROL_KIM;
            myTSMS_BIL_MESAJ_NUMARA.KONTROL_VERSIYON = Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON;
            myTSMS_BIL_MESAJ_NUMARA.STAMP = Kimlikci.Kimlik.Bilgi.STAMP;
            myTSMS_BIL_MESAJ_NUMARA.KONTROL_KIM_ID = Kimlikci.Kimlik.Bilgi.ID;
            myTSMS_BIL_MESAJ_NUMARA.SUBE_KOD_ID = Kimlikci.Kimlik.Bilgi.SUBE_ID;
            DataRepository.TSMS_BIL_MESAJ_NUMARAProvider.Save(myTSMS_BIL_MESAJ_NUMARA);

            #region ado.net version

            //                int mesajId = mesajKaydet(mesajMetni, resultValue);
            //                SqlConnection con = new SqlConnection(smtpInfo.ConStr);

            //                SqlCommand cmd = new SqlCommand(@"INSERT INTO [BOS].[dbo].[TSMS_BIL_MESAJ_NUMARA]
            //           ([MESAJ_ID]
            //           ,[NUMARA_KAYNAK]
            //           ,[FIRMA_TABLO_KOD]
            //           ,[CARI_ID]
            //           ,[CARI_ADI]
            //           ,[NUMARA]
            //           ,[AKTIFLESME_TARIHI]
            //           ,[PASIFLESME_TARIHI]
            //           ,[SON_GONDERIM_ZAMANI]
            //           ,[GONDERIM_SAYISI]
            //           ,[DURUM_ID]
            //           ,[DURUM]
            //           ,[GSM_OP_MESAJ_ID]
            //           ,[GSM_OP_RAPOR_TARIHI]
            //           ,[GSM_OP_RAPOR_DURUM]
            //           ,[GSM_XML_SATIR_NO]
            //           ,[KAYIT_TARIHI]
            //           ,[SUBE_KODU]
            //           ,[KONTROL_NE_ZAMAN]
            //           ,[KONTROL_KIM]
            //           ,[KONTROL_VERSIYON]
            //           ,[STAMP]
            //           ,[KONTROL_KIM_ID]
            //           ,[SUBE_KOD_ID])
            //     VALUES
            //           (@MESAJ_ID
            //           ,@NUMARA_KAYNAK
            //           ,@FIRMA_TABLO_KOD
            //           ,@CARI_ID
            //           ,@CARI_ADI
            //           ,@NUMARA
            //           ,getdate()
            //           ,getdate()
            //           ,getdate()
            //           ,@GONDERIM_SAYISI
            //           ,@DURUM_ID
            //           ,@DURUM
            //           ,@GSM_OP_MESAJ_ID
            //           ,getdate()
            //           ,@GSM_OP_RAPOR_DURUM
            //           ,@GSM_XML_SATIR_NO
            //           ,getdate()
            //           ,@SUBE_KOD_ID
            //           ,@KONTROL_NE_ZAMAN
            //           ,@KONTROL_KIM
            //           ,@KONTROL_VERSIYON
            //           ,@STAMP
            //           ,@KONTROL_KIM_ID
            //           ,@SUBE_KOD_ID)", con);
            //                cmd.Parameters.AddWithValue("@MESAJ_ID",mesajId);
            //                cmd.Parameters.AddWithValue("@NUMARA_KAYNAK", 0);
            //                cmd.Parameters.AddWithValue("@FIRMA_TABLO_KOD", FirmaTurId);
            //                cmd.Parameters.AddWithValue("@CARI_ID", Convert.ToInt32(CariId));
            //                cmd.Parameters.AddWithValue("@CARI_ADI", CariAdi);
            //                cmd.Parameters.AddWithValue("@NUMARA", gsmNo);
            //                //cmd.Parameters.AddWithValue("@AKTIFLESME_TARIHI", );
            //                //cmd.Parameters.AddWithValue("@PASIFLESME_TARIHI", );
            //                //cmd.Parameters.AddWithValue("@SON_GONDERIM_ZAMANI", );
            //                cmd.Parameters.AddWithValue("@GONDERIM_SAYISI", 1);

            //                  switch(Convert.ToInt32(resultValue))
            //       {
            //         case 0:
            //               cmd.Parameters.AddWithValue("@DURUM", "GSM Operatör- Başarılı");
            //            cmd.Parameters.AddWithValue("@DURUM_ID", 4);

            //            break;
            //         case 1:
            //            cmd.Parameters.AddWithValue("@DURUM", "GSM Operatör- Başarısız");
            //           cmd.Parameters.AddWithValue("@DURUM_ID", 6);
            //             break;
            //         case 2:
            //             cmd.Parameters.AddWithValue("@DURUM", "GSM Operatör- Bekliyor");
            //            cmd.Parameters.AddWithValue("@DURUM_ID", 5);
            //             break;
            //         default:

            //            break;
            //       }

            //                  cmd.Parameters.AddWithValue("@GSM_OP_MESAJ_ID", Convert.ToInt32(MESAJ_ID));
            //                //cmd.Parameters.AddWithValue("@GSM_OP_RAPOR_TARIHI", DateTime.Now);

            //                cmd.Parameters.AddWithValue("@GSM_OP_RAPOR_DURUM", "");
            //                cmd.Parameters.AddWithValue("@GSM_XML_SATIR_NO", 0);
            //                //cmd.Parameters.AddWithValue("@KAYIT_TARIHI", DateTime.Now);
            //                cmd.Parameters.AddWithValue("@SUBE_KODU", Kimlikci.Kimlik.Bilgi.SUBE_ID);
            //                cmd.Parameters.AddWithValue("@KONTROL_NE_ZAMAN", Kimlikci.Kimlik.Bilgi.KONTROL_NE_ZAMAN);
            //                cmd.Parameters.AddWithValue("@KONTROL_KIM", Kimlikci.Kimlik.Bilgi.KONTROL_KIM);
            //                cmd.Parameters.AddWithValue("@KONTROL_VERSIYON", Kimlikci.Kimlik.Bilgi.KONTROL_VERSIYON);
            //                cmd.Parameters.AddWithValue("@STAMP", Kimlikci.Kimlik.Bilgi.STAMP);
            //                cmd.Parameters.AddWithValue("@KONTROL_KIM_ID", Kimlikci.Kimlik.Bilgi.ID);
            //                cmd.Parameters.AddWithValue("@SUBE_KOD_ID", Kimlikci.Kimlik.Bilgi.SUBE_ID);

            //                if (con.State == System.Data.ConnectionState.Closed)
            //                {
            //                    con.Open();
            //                    cmd.ExecuteNonQuery();
            //                }
            //                if (con.State == System.Data.ConnectionState.Open)
            //                    con.Close();
            //                    con.Dispose();

            #endregion ado.net version
        }

        private string tcKimlikGetir(string Id)
        {
            string tcNo = "";
            foreach (var item3 in DataRepository.AV001_TDI_BIL_CARI_KIMLIKProvider.GetByCARI_ID(Convert.ToInt32(Id)))
            {
                if (item3.TC_KIMLIK_NO.ToString() == null || item3.TC_KIMLIK_NO.ToString() == "")
                {
                    tcNo = "YOK";
                }
                else
                {
                    tcNo = item3.TC_KIMLIK_NO.ToString();
                }
            }

            return tcNo;
        }

        private void TCSmsGonder(string tcNo, string mesaj, string CariId, string CariAdi, string FirmaTurId)
        {
            TckSMS myTckSMS = new TckSMS();
            string[] sonuc = myTckSMS.SMSGonder(tcNo, mesaj);

            if (sonuc[0] == "İşlem başarıyla gerçekleştirildi.")
            {
                int MesajDbId = SmsMesajKaydet(mesaj, "0");
                SmsRaporDuzenle("TC" + tcNo, "0", sonuc[1].ToString(), CariId, CariAdi, FirmaTurId, mesaj, MesajDbId);

                //mySMS.IDyeGoreRapor(sonuc[1].ToString());
                basarili = basarili + 1;
                //MessageBox.Show("mesaj gönderilmiştir");
            }
            else
            {
                basarisiz = basarisiz + 1;
                //MessageBox.Show("hata : " + sonuc[0].ToString());
            }
        }

        private void txtBoxSMSIletisimTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chkBoxSMSIletisimTel.Checked == true)
            {
                if ((e.KeyChar < 58 && e.KeyChar >= 48) || e.KeyChar == 08)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtBoxSMSIletisimTel_Leave(object sender, EventArgs e)
        {
            if (chkBoxSMSIletisimTel.Checked == true)
            {
                if (txtBoxSMSIletisimTel.Text.Trim().Length == 0)
                {
                    MessageBox.Show("bir tel no giriniz");
                    txtBoxSMSIletisimTel.Text = smtpInfo.SMSIletisimTel;
                }
                else if (txtBoxSMSIletisimTel.Text.Trim().Length != 11)
                {
                    MessageBox.Show("doğru bir tel no giriniz");
                    txtBoxSMSIletisimTel.Text = smtpInfo.SMSIletisimTel;
                }
            }
        }

        private void txtBoxSMSIletisimTel_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkBoxSMSIletisimTel.Checked == true)
            {
                txtBoxSMSIletisimTel.Text = "";
            }
        }
    }
}