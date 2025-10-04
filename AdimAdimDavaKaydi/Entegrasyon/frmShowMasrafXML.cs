using AdimAdimDavaKaydi.Entegrasyon.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmShowMasrafXML : Form
    {
        public frmShowMasrafXML()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmShowMasrafXML_Load);
        }

        public List<Masraflar> MasrafList = new List<Masraflar>();

        private object returnValue = new object();

        private void frmShowMasrafXML_Load(object sender, EventArgs e)
        {
            //Kullanıcı manuel yapacak.

            XDocument docs = XDocument.Load(Application.StartupPath + "\\Masraflar.xml");

            foreach (var doc in docs.Descendants("MASRAF"))
            {
                MasrafList.Add(MethodsForMasrafTahsilat.BindMasrafXML(doc));
            }

            DialogResult drKullaniciOnay = MessageBox.Show("Masraflardan referansı ve tutarı tutunlar otomatik eşleşsin mi?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drKullaniciOnay == DialogResult.Yes)
            {
                MethodsForMasrafTahsilat.ControlToMasraf(MasrafList);
            }
            else
            {
                gcMasraflar.DataSource = MasrafList;
            }
        }

        private void masrafEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = gvMasraflar.GetFocusedRow() as Masraflar;
            MethodsForMasrafTahsilat.CheckMasrafAvans(item);
        }
    }
}