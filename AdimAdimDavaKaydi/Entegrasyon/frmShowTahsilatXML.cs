using AdimAdimDavaKaydi.Entegrasyon.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    public partial class frmShowTahsilatXML : Form
    {
        public frmShowTahsilatXML()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmShowTahsilatXML_Load);
        }

        public List<Tahsilatlar> TahsilatList = new List<Tahsilatlar>();

        private void frmShowTahsilatXML_Load(object sender, EventArgs e)
        {
            XDocument docs = XDocument.Load(Application.StartupPath + "\\Tahsilatlar.xml");

            foreach (var doc in docs.Descendants("TAHSILAT"))
            {
                Tahsilatlar tahsilat = new Tahsilatlar();

                if (doc.Element("Sube") != null) tahsilat.Sube = doc.Element("Sube").Value;
                if (doc.Element("KrediMusterisi") != null) tahsilat.KrediBorclusu = doc.Element("KrediMusterisi").Value;
                if (doc.Element("MusteriNo") != null) tahsilat.MusteriNo = doc.Element("MusteriNo").Value;
                if (doc.Element("HesapNo") != null) tahsilat.HesapNo = doc.Element("HesapNo").Value;
                if (doc.Element("IBANNo") != null) tahsilat.IBANNo = doc.Element("IBANNo").Value;
                if (doc.Element("Odeyen") != null) tahsilat.Odeyen = doc.Element("Odeyen").Value;
                if (doc.Element("OdemeMiktarı") != null) tahsilat.OdemeMiktari = Convert.ToDecimal(doc.Element("OdemeMiktarı").Value == "" ? "0" : doc.Element("OdemeMiktarı").Value);
                if (doc.Element("OdemeMiktariParaBirimi") != null) tahsilat.OdemeMiktariParaBirimi = doc.Element("OdemeMiktariParaBirimi").Value;
                if (doc.Element("OdemeTarihi") != null) tahsilat.OdemeTarihi = Convert.ToDateTime(doc.Element("OdemeTarihi").Value == "" ? null : doc.Element("OdemeTarihi").Value);
                if (doc.Element("KrediReferansNo") != null) tahsilat.KrediReferansNo = doc.Element("KrediReferansNo").Value;

                TahsilatList.Add(tahsilat);
            }
            gcTahsilatlar.DataSource = TahsilatList;
        }

        private void tahsilatEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (gvTahsilatlar.GetFocusedRow() as Tahsilatlar);
            MethodsForMasrafTahsilat.CheckTahsilat(item);
        }
    }
}