using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class frmBaglantiAyar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmBaglantiAyar()
        {
            InitializeComponent();
        }

        private List<CompInfo> sList;
        public static string SirketNfo = Application.StartupPath + "\\cmpnfo2.gio";

        private void frmBaglantiAyar_Load(object sender, EventArgs e)
        {
            if (!File.Exists(SirketNfo))
            {
                sList = new List<CompInfo>();
                CompInfo ci = new CompInfo("AvukatPro Server",
                                           "server=192.9.0.199;database=AVP_NHA_NG;uid=yilmaz;pwd=123");
                CompInfo ci2 = new CompInfo("AvukatPro Yilmaz",
                                            "server=192.9.0.145;database=AVP_NHA_KISA;uid=sa;pwd=123");
                CompInfo ci3 = new CompInfo("AvukatPro Sunum", "server=.;database=AVP_NHA_NG;uid=sa;pwd=123");
                sList.Add(ci);
                sList.Add(ci2);
                sList.Add(ci3);
                FileStream fs = new FileStream(SirketNfo, FileMode.CreateNew);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, sList);
                fs.Close();
            }

            FileStream fss = File.OpenRead(SirketNfo);
            BinaryFormatter bff = new BinaryFormatter();
            sList = (List<CompInfo>)bff.Deserialize(fss);
            listBoxControl1.DataSource = sList;
            listBoxControl1.DisplayMember = "CompanyName";
            fss.Close();
        }

        private void listBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedValue != null)
            {
                CompInfo cmp = listBoxControl1.SelectedValue as CompInfo;
                if (cmp != null)
                {
                    txtName.Text = cmp.LisansBilgisi.AdSoyad;
                    txtConStr.Text = cmp.ConStr;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedValue != null)
            {
                CompInfo cmp = listBoxControl1.SelectedValue as CompInfo;
                if (cmp != null)
                {
                    cmp.LisansBilgisi.AdSoyad = txtName.Text;
                    cmp.ConStr = txtConStr.Text;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CompInfo cmp = new CompInfo(txtName.Text, txtConStr.Text);
            sList.Add(cmp);
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(SirketNfo, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sList);
            fs.Close();
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            sList.Remove(listBoxControl1.SelectedValue as CompInfo);
        }
    }
}