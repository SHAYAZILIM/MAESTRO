using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class FrmDeleteFoy : Form
    {
        public FrmDeleteFoy()
        {
            InitializeComponent();
        }

        public bool RunScript(string name, string script, decimal step)
        {
            Helper.Connection.Open();
            lstStatus.Items.Insert(0, "----------------------------------------------");
            script = string.Format(script, (int)step);
            try
            {
                SqlCommand cmd = new SqlCommand(script, Helper.Connection);
                int d = cmd.ExecuteNonQuery();
                lstStatus.Items.Insert(0, name + " is finished successfull." + d.ToString() + " row deleted.");
            }
            catch (Exception ex)
            {
                lstStatus.Items.Insert(0, name + " has error.");
                lstStatus.Items.Insert(0, ex.Message);
                return false;
            }
            finally
            {
                lstStatus.Items.Insert(0, "----------------------------------------------");
                Helper.Connection.Close();
            }
            return true;
        }

        public void RunScriptFoy(string name, string script)
        {
            var maxid = 0;
            var step = (int)numericUpDown1.Value;
            Helper.Connection.Open();

            SqlCommand cmd = new SqlCommand(foymaxid, Helper.Connection);
            maxid = (int)cmd.ExecuteScalar();
            Helper.Connection.Close();

            while (maxid - step > numericUpDown2.Value)
            {
                lstStatus.Items.Insert(0, "maxid:" + maxid.ToString());
                if (!RunScript("foy", foy, maxid - step))
                    break;

                Helper.Connection.Open();

                maxid = (int)cmd.ExecuteScalar();
                Helper.Connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                RunScript("Faiz", faiz, numericUpDown2.Value);
                RunScript("alacaknedentakipli", alacaknedentakipli, numericUpDown2.Value);
                RunScript("odemedagilim", odemedagilim, numericUpDown2.Value);
                RunScript("alacakneden", alacakneden, numericUpDown2.Value);
                RunScript("atama", atama, numericUpDown2.Value);
                RunScript("krediborclusu", krediborclusu, numericUpDown2.Value);
                RunScript("sorumlu", sorumlu, numericUpDown2.Value);
                RunScript("taraf", taraf, numericUpDown2.Value);
                RunScript("hesapdetay", hesapdetay, numericUpDown2.Value);
                RunScript("harc", harc, numericUpDown2.Value);
                RunScript("carihesap", carihesap, numericUpDown2.Value);
                RunScript("masraf", masraf, numericUpDown2.Value);
                RunScript("vekalet", vekalet, numericUpDown2.Value);
                RunScript("carihesap2", carihesap2, numericUpDown2.Value);
                RunScript("borcluodeme", borcluodeme, numericUpDown2.Value);
                RunScript("burodevri", burodevri, numericUpDown2.Value);
                RunScript("projeicra", projeicra, numericUpDown2.Value);
                RunScript("hacizmaster", hacizmaster, numericUpDown2.Value);
                RunScript("icrasozlesme", icrasozlesme, numericUpDown2.Value);
                RunScript("borclumal", borclumal, numericUpDown2.Value);
                RunScript("kayitilişki", kayitiliski, numericUpDown2.Value);
                RunScriptFoy("foy", foy);
            }));
            th.Start();
        }

        #region Scripts

        private string alacakneden = "DELETE from AV001_TI_BIL_ALACAK_NEDEN WHERE ICRA_FOY_ID>={0}";
        private string alacaknedentakipli = "DELETE from AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI WHERE ALACAK_NEDEN_ID IN (SELECT ID FROM AV001_TI_BIL_ALACAK_NEDEN WHERE ICRA_FOY_ID>={0})";
        private string atama = "DELETE from AV001_TDIE_BIL_AKTARILAN_DOSYAYI_ATAMA WHERE TAKIP_IP >={0}";
        private string borclumal = "DELETE from TDI_BIL_BORCLU_MAL WHERE ICRA_FOY_ID >={0}";
        private string borcluodeme = "DELETE from AV001_TI_BIL_BORCLU_ODEME WHERE ICRA_FOY_ID >={0}";
        private string burodevri = "DELETE from AV001_TDIE_BIL_BURO_DEVRI WHERE ICRA_ID >={0}";
        private string carihesap = "DELETE from AV001_TDI_BIL_CARI_HESAP WHERE MASRAF_AVANS_ID IN (SELECT ID FROM AV001_TDI_BIL_MASRAF_AVANS WHERE ICRA_FOY_ID >={0})";
        private string carihesap2 = "DELETE from AV001_TDI_BIL_CARI_HESAP WHERE ICRA_BORCLU_ODEME_ID IN (SELECT ID FROM AV001_TI_BIL_BORCLU_ODEME WHERE ICRA_FOY_ID >={0})";
        private string faiz = "DELETE from AV001_TI_BIL_FAIZ WHERE ICRA_FOY_ID>={0}";
        private string foy = "DELETE from AV001_TI_BIL_FOY WHERE ID>={0}";
        private string foymaxid = "Select max(ID) from AV001_TI_BIL_FOY";
        private string hacizmaster = "DELETE from AV001_TI_BIL_HACIZ_MASTER WHERE ICRA_FOY_ID >={0}";
        private string harc = "DELETE from AV001_TI_BIL_HARC WHERE ICRA_FOY_ID >={0}";
        private string hesapdetay = "DELETE from AV001_TDI_BIL_CARI_HESAP_DETAY WHERE ICRA_FOY_ID >={0}";
        private string icrasozlesme = "DELETE from NN_ICRA_SOZLESME WHERE ICRA_FOY_ID >={0}";
        private string kayitiliski = "DELETE from AV001_TDI_BIL_KAYIT_ILISKI WHERE KAYNAKICRA_FOY_ID >={0}";
        private string krediborclusu = "DELETE from AV001_TI_BIL_FOY_KREDI_BORCLUSU WHERE ICRA_FOY_ID >={0}";
        private string masraf = "DELETE from AV001_TDI_BIL_MASRAF_AVANS WHERE ICRA_FOY_ID >={0}";
        private string odemedagilim = "DELETE from AV001_TI_BIL_ODEME_DAGILIM WHERE ALACAK_NEDEN_ID IN (SELECT ID FROM AV001_TI_BIL_ALACAK_NEDEN WHERE ICRA_FOY_ID>={0})";
        private string projeicra = "DELETE from AV001_TDIE_BIL_PROJE_ICRA_FOY WHERE ICRA_FOY_ID >={0}";
        private string sorumlu = "DELETE from AV001_TI_BIL_FOY_SORUMLU_AVUKAT WHERE ICRA_FOY_ID >={0}";

        private string taraf = "DELETE from AV001_TI_BIL_FOY_TARAF WHERE ICRA_FOY_ID >={0}";
        private string vekalet = "DELETE from AV001_TI_BIL_VEKALET_UCRET WHERE ICRA_FOY_ID >={0}";

        #endregion Scripts

        private void FrmDeleteFoy_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
        }
    }
}