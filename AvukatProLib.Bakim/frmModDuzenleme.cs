using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AvukatProLib.Bakim
{
    public partial class frmModDuzenleme : DevExpress.XtraEditors.XtraForm
    {
        public frmModDuzenleme()
        {
            InitializeComponent();
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                List<KurumsalMod> modlar = vGridControl1.DataSource as List<KurumsalMod>;
                KurumsalMod ekledim = new KurumsalMod();
                ekledim.ModNo = 1000;
                if (modlar.Count > 0)
                {
                    modlar.Sort(modKarsilastir);
                    ekledim.ModNo = modlar[0].ModNo + 500;
                }
                modlar.Add(ekledim);
            }
        }

        private void frmModDuzenleme_Load(object sender, EventArgs e)
        {
            List<KurumsalMod> modlar = null;
            if (File.Exists(KurumsalMod.FilePath))
            {
                FileStream fs = File.OpenRead(KurumsalMod.FilePath);

                BinaryFormatter bf = new BinaryFormatter();
                modlar = (List<KurumsalMod>)bf.Deserialize(fs);
                fs.Close();
            }
            if (modlar == null)
            {
                modlar = new List<KurumsalMod>();
                modlar.Add(new KurumsalMod());
            }
            vGridControl1.DataSource = modlar;
            dataNavigator1.DataSource = modlar;
        }

        private int modKarsilastir(KurumsalMod bir, KurumsalMod iki)
        {
            return iki.ModNo - bir.ModNo;
        }

        private void tsKaydet_Click(object sender, EventArgs e)
        {
            List<KurumsalMod> modlar = vGridControl1.DataSource as List<KurumsalMod>;
            FileStream fs = new FileStream(KurumsalMod.FilePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, modlar);
            fs.Close();
        }
    }
}