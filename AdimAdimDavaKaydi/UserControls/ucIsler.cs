using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIsler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucIsler()
        {
            InitializeComponent();
        }

        private List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> myDataSource;

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                myDataSource = value;
                if (!this.DesignMode && value != null)
                {
                    TreeViewBind();
                }
            }
        }

        public class IsNode
        {
            public IsNode(string ad, int id, int parentId)
            {
                this.AD = ad;
                this.Id = id;
                this.ParentId = parentId;
            }

            public string AD { get; set; }

            public override string ToString()
            {
                return AD;
            }

            public int Id { get; set; }

            public int ParentId { get; set; }

            public int SourceId { get; set; }

            public string YapilacakIs { get; set; }

            private static int _getId = 100;

            public bool IsYapildimi { get; set; }

            public int imageIndex { get; set; }

            public static int GetId
            {
                get { return _getId++; }
            }
        }

        private List<IsNode> BindWork(AvukatProLib.Arama.per_AV001_TDI_BIL_I isler, int parentID)
        {
            List<IsNode> liste = new List<IsNode>();

            string treeCaption = " ";
            if (isler.DURUM)
                treeCaption = "Yapýldý" + '/' + isler.BASLANGIC_TARIHI + '/' + isler.KONU;
            if (!isler.DURUM)
                treeCaption = "Yapýlmadý" + '/' + isler.BASLANGIC_TARIHI + '/' + isler.KONU;

            var nod = new IsNode(treeCaption, IsNode.GetId, parentID);
            liste.Add(new IsNode(isler.YAPILACAK_IS, IsNode.GetId, nod.Id));
            liste.Add(nod);
            nod.SourceId = isler.ID;
            nod.YapilacakIs = isler.YAPILACAK_IS;
            nod.IsYapildimi = isler.DURUM;

            return liste;
        }

        private void TreeViewBind()
        {
            treeView1.Nodes.Clear();

            List<IsNode> liste = new List<IsNode>();

            liste.Add(new IsNode("Evvelki Gün", 1, 0));
            liste.Add(new IsNode("Dün", 2, 0));
            liste.Add(new IsNode("Bugün", 3, 0));
            liste.Add(new IsNode("Yarýn", 4, 0));
            liste.Add(new IsNode("Öbür Gün", 5, 0));

            string evvelkiGun = DateTime.Now.AddDays(-2).ToShortDateString();
            string dun = DateTime.Now.AddDays(-1).ToShortDateString();
            string bugun = DateTime.Now.ToShortDateString();
            string yarin = DateTime.Now.AddDays(1).ToShortDateString();
            string oburGun = DateTime.Now.AddDays(2).ToShortDateString();

            foreach (var item in MyDataSource)
            {
                string isTarih = item.BASLANGIC_TARIHI.Value.ToShortDateString();

                if (isTarih == evvelkiGun)
                    liste.AddRange(BindWork(item, 1));
                if (isTarih == dun)
                    liste.AddRange(BindWork(item, 2));
                if (isTarih == bugun)
                    liste.AddRange(BindWork(item, 3));
                if (isTarih == yarin)
                    liste.AddRange(BindWork(item, 4));

                if (isTarih == oburGun)
                    liste.AddRange(BindWork(item, 5));
            }
            treeView1.DataSource = liste;
        }

        private void ucSikKullanilanlar_Load(object sender, EventArgs e)
        {
            treeListColumn1.Caption = AvukatProLib.Kimlik.Bilgi.KULLANICI_ADI + " Kullanýcýsýnýn Ýþleri";
            Is.UserControls.ucIsKayitUfak.Yenile += ucIsKayitUfak_Yenile;
        }

        private void ucIsKayitUfak_Yenile(object sender, BelgeUtil.IsKayitEventArgs e)
        {
            List<AvukatProLib.Arama.per_AV001_TDI_BIL_I> MyIsler = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_I>();
            if (AvukatProLib.Kimlik.Bilgi != null)
            {
                if (BelgeUtil.Inits._IsGetir != null) MyIsler = BelgeUtil.Inits._IsGetir.FindAll(item => item.KONTROL_KIM_ID == AvukatProLib.Kimlik.Bilgi.ID);
                else MyIsler = BelgeUtil.Inits.context.per_AV001_TDI_BIL_Is.Where(item => item.KONTROL_KIM_ID == AvukatProLib.Kimlik.Bilgi.ID).ToList();
            }

            else
                MyIsler = null;

            MyDataSource = MyIsler;
        }

        public event EventHandler<EventArgs> Yenile;

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Yenile != null)
                Yenile(this, new EventArgs());
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            Is.Forms.frmIsKayitUfak frmIsKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

            TList<AV001_TDI_BIL_IS> isler = new TList<AV001_TDI_BIL_IS>();

            var isNod = treeView1.GetDataRecordByNode(treeView1.FocusedNode) as IsNode;
            if (isNod == null || isNod.SourceId == 0)
                return;
            AV001_TDI_BIL_IS isim = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(isNod.SourceId);
            DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(isim, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TDI_BIL_IS_TARAF>));
            isler.Add(isim);
            frmIsKayit.ucIsKayitUfak1.IsEdit = true;
            switch ((AvukatProLib.Extras.ModulTip)isim.MODUL_ID)
            {
                case AvukatProLib.Extras.ModulTip.Icra:
                    AV001_TI_BIL_FOY foyI = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(isim.FORM_ID ?? 0);
                    frmIsKayit.ucIsKayitUfak1.OpenedRecord = foyI;
                    break;
                case AvukatProLib.Extras.ModulTip.Dava:
                    AV001_TD_BIL_FOY foyD = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(isim.FORM_ID ?? 0);
                    frmIsKayit.ucIsKayitUfak1.OpenedRecord = foyD;
                    break;
                case AvukatProLib.Extras.ModulTip.Sorusturma:
                    AV001_TD_BIL_HAZIRLIK foyH = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(isim.FORM_ID ?? 0);
                    frmIsKayit.ucIsKayitUfak1.OpenedRecord = foyH;
                    break;
                case AvukatProLib.Extras.ModulTip.Sozlesme:
                    AV001_TDI_BIL_SOZLESME foyS =
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(isim.FORM_ID ?? 0);
                    frmIsKayit.ucIsKayitUfak1.OpenedRecord = foyS;
                    break;
            }
            frmIsKayit.ucIsKayitUfak1.Record = isim;
            //frmIsKayit.MdiParent = null;
            frmIsKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frmIsKayit.Show();
        }
    }
}