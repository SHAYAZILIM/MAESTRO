using AvukatProLib;
using AvukatProRaporlar.Raport.Util.Inits;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util
{
    public partial class Pending : Form
    {
        public Pending()
        {
            InitializeComponent();
        }

        public Pending(List<CompInfo> compList, DBDataContext db, AvukatProViewDataContext dbV)
        {
            InitializeComponent();
            this.compList = compList;
            this.db = db;
            this.dbV = dbV;
        }

        private List<CompInfo> compList;
        private DBDataContext db;
        private AvukatProViewDataContext dbV;

        public string BeklemeYazisi
        {
            set { label1.Text = value; }
            get { return label1.Text; }
        }

        public void Islemler()
        {
            object temp;
            temp = InitsEx.AraKararTip;
            temp = InitsEx.DovizTipGetir;
            temp = InitsEx.FaturaHedefTip;
            temp = InitsEx.FaturaKapsamTip;
            temp = InitsEx.KontrolKim;
            temp = InitsEx.MasrafAvansTip;
            temp = InitsEx.ParaBicimiAyarla;
            temp = InitsEx.SegmnetBolumGetir;
            temp = InitsEx.SubeKod;
            temp = InitsEx.TarafKodu;
            if (Program.dovizGuncel == null || Program.dovizGuncel != DateTime.Today)
            {
            }

            this.Close();
        }

        private void Pending_Load(object sender, EventArgs e)
        {
            InitsEx.comp = compList;
            InitsEx.db = db;
            InitsEx.dbV = dbV;
            ThreadStart trs = new ThreadStart(Islemler);
            Thread tr = new Thread(trs);
            tr.Start();
        }
    }
}