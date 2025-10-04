using System;
using System.Data;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Is
{
    public partial class frmIsKayitDetay : Form
    {
        public int Sure;

        private int dak, saat, saniye;

        private AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAY myDataSource;

        private string str = "";

        public frmIsKayitDetay()
        {
            InitializeComponent();
        }

        public AV001_TDI_BIL_IS_TAMAMLANMA_SURE_DETAY MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDataSource = value;
                    IntisData();
                    DataBinding();
                }
            }
        }

        public void DataBinding()
        {
            lueDurmaNeden.DataBindings.Clear();
            lueDurmaNeden.DataBindings.Add("EditValue", MyDataSource, "DURMA_NEDENI", true);
            memoEdit1.DataBindings.Clear();
            memoEdit1.DataBindings.Add("EditValue", MyDataSource, "DURMA_ACIKLAMA", true);
        }

        public void DurumAciklamaGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("HacizChildTip");
            dt.Columns.Add("DEGER");
            dt.Columns.Add("ACIKLAMA");
            foreach (DurumAciklama tipi in Enum.GetValues(typeof(DurumAciklama)))
            {
                dt.Rows.Add(tipi, tipi.ToString().Replace("_", " "));
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ACIKLAMA";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Durum Açıklama"));
        }

        public void IntisData()
        {
            DurumAciklamaGetir(lueDurmaNeden);
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            MyDataSource.DURMA_TARIH_ZAMAN =
                ((DateTime)MyDataSource.BASLAMA_TARIH_ZAMAN).AddHours(saat).AddMinutes(saat).AddSeconds(dak).
                    AddMilliseconds(saniye);
            MyDataSource.DURMA_ACIKLAMA = lueDurmaNeden.EditValue.ToString();
            MyDataSource.DURMA_NEDENI = lueDurmaNeden.EditValue.ToString();
            MyDataSource.OZEL_ALAN = saat + ":" + dak + ":" + saniye;
            Sure = saat + dak + saniye;
            timer1.Stop();
            this.Close();
        }

        private void frmIsKayitDetay_Load(object sender, EventArgs e)
        {
            MyDataSource.BASLAMA_TARIH_ZAMAN = DateTime.Now;
            timer1.Start();
        }

        private void lueDurmaNeden_EditValueChanged(object sender, EventArgs e)
        {
            memoEdit1.Text = lueDurmaNeden.EditValue.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye == 60)
            {
                dak++;
                saniye = 0;
            }
            if (dak == 60)
            {
                dak = 0;
                saat++;
            }
            if (saat == 60)
            {
                saat = 0;
            }
            yazdir();
        }

        private void yazdir()
        {
            if (saat < 10)
            {
                if (dak < 10)
                {
                    if (saniye < 10)
                        str = "0" + saat + ":0" + dak + ":0" + saniye;
                    else
                        str = "0" + saat + ":0" + dak + ":" + saniye;
                }
                else
                {
                    if (saniye < 10)
                        str = "0" + saat + ":" + dak + ":0" + saniye;
                    else str = "0" + saat + ":" + dak + ":" + saniye;
                }
            }
            else
            {
                if (dak < 10)
                {
                    if (saniye < 10)
                        str = saat + ":0" + dak + ":0" + saniye;
                    else
                        str = saat + ":0" + dak + ":" + saniye;
                }
                else
                {
                    if (saniye < 10)
                        str = saat + ":" + dak + ":0" + saniye;
                    else str = saat + ":" + dak + ":" + saniye;
                }
            }
            lblZaman.Text = str;
        }
    }
}