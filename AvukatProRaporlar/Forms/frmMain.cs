using AvukatProRaporlar.Lib;
using AvukatProRaporlar.Raport.Util;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using RaporDataSource.ViewDB;
using ReportPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public int cariID;
        public Bilgi gridbilgi;
        private static List<GridMenuItem> menuList;
        private SaveList _kullaniciTanimliListesi;
        private List<Form> acikFormlar = new List<Form>();
        private List<string> acikKullaniciTanimlilar = new List<string>();
        private BackgroundWorker bw = new BackgroundWorker();
        private string deger;
        private List<GridMenuItem> kullaniciTanimliListesi;
        private ftmPivotGrid pivot;

        private bool test = true;

        public SaveList KullaniciTanimliListesi
        {
            get
            {
                if (_kullaniciTanimliListesi != null)
                {
                    return _kullaniciTanimliListesi;
                }
                else
                {
                    _kullaniciTanimliListesi = new SaveList();
                    return _kullaniciTanimliListesi;
                }
            }
            set { _kullaniciTanimliListesi = value; }
        }

        public DialogResult TabKontrol()
        {
            return XtraMessageBox.Show("Rapor yeni pencerde açılsın mı ?", "Tab Kontrolü", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private static string GetAcilacakPencere(string p)
        {
            return p;
        }

        private static List<GridMenuItem> MenuListCollection()
        {
            if (menuList != null) return menuList;

            AvukatProViewDataContext dbV = Program.dbV;
            menuList = dbV.TDI_KOD_RAPOR_MENUs.Select(vi => new GridMenuItem
              {
                  Adi = vi.ALT_RAPOR_BASLIGI,
                  GrubDegeri = vi.RAPOR_BASLIGI,
                  ModulDegeri = vi.MODUL.ToString(),
                  TipDegeri = (GridMenuItem.Tip)vi.TIP,
                  AcilacakPencereDegeri = GetAcilacakPencere(vi.ALT_RAPOR_BASLIGI),
                  UniqueId = vi.UniqueId
              }).ToList();
            return menuList;
        }

        private void barBtnDava_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "DAVA").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "YAPILACAK ISLER").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "DAVA").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "ICRA").ToList();
            sonuc.AddRange(kullaniciTanimliListesi);
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli).ToList();
            sonuc.AddRange(kullaniciTanimliListesi);
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Muhasebe").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Temsil").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Yapilacak_Is").ToList();

            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Belgeler").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Gorusmeler").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GridMenuItem> sonuc = menuList.Where(vi => vi.TipDegeri == GridMenuItem.Tip.KullaniciTanimli && vi.ModulDegeri == "Tebligat").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "SORUŞTURMA").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null || this.ActiveMdiChild is iAVPForms)
            {
                (this.ActiveMdiChild as iAVPForms).ExportXls();
            }
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null || this.ActiveMdiChild is iAVPForms)
            {
                (this.ActiveMdiChild as iAVPForms).ExportPDF();

                // DevExpress.XtraPrinting.DynamicPrintHelper;
            }
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null || this.ActiveMdiChild is iAVPForms)
            {
                (this.ActiveMdiChild as iAVPForms).ExportMail();
            }
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null || this.ActiveMdiChild is iAVPForms)
            {
                (this.ActiveMdiChild as iAVPForms).ExportPrint();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "ICRA" && vi.TipDegeri != GridMenuItem.Tip.KullaniciTanimli).ToList();
            gridMenu.DataSource = sonuc;
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult sonuc = XtraMessageBox.Show("Program Kapatılsın mı?", "Kapatılıyor..", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            menuList = menuList.Where(vi => vi.TipDegeri != GridMenuItem.Tip.KullaniciTanimli).ToList();
            gridMenu.DataSource = menuList;
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "SORUŞTURMA").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void btnDonemselRaporlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "DONEMSEL RAPORLAR").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void btnFiltreleriDuzenle_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnGenel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "GENEL").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void btnKlasor_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sonuc = menuList.Where(vi => vi.ModulDegeri == "KLASÖR").ToList();
            gridMenu.DataSource = sonuc;
        }

        private void btnKosulluBicimlendir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //foreach (Form item in acikFormlar)
            //{
            //    if (item as frmListeRapor)
            //    {
            //        KosulluBicimlendirListe(item);
            //    }
            //    else if (item as ftmPivotGrid)
            //    {
            //        KosulluBicimlendirPivot(item);
            //    }
            //}
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            RibbonForm mainForm = e.Argument as RibbonForm;
            MenuCalistir(this);
            gridMenu.Enabled = false;
            riMProgress.Stopped = false;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridMenu.Enabled = true;
            riMProgress.Stopped = true;
        }

        private void fc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;
            acikFormlar.Remove(frm);
            if (test)
                frm.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MdiChildActivate += new EventHandler(frmMain_MdiChildActivate);
            simpleButton1.Visible = false;
            if (!Program.girisYapilmis)
            {
                frmIntro frm = new frmIntro();

                this.Visible = false;
                DialogResult dr = frm.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                {
                    this.Close();
                }
            }
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            Pending InitsDolduruluyor = new Pending(Program.compList, Program.db, Program.dbV);
            InitsDolduruluyor.ShowDialog();

            menuList = MenuListCollection();
            menuList = menuList.Where(vi => vi.TipDegeri != GridMenuItem.Tip.KullaniciTanimli).ToList();
            gridMenu.DataSource = menuList;
            _kullaniciTanimliListesi = new SaveList();
            kullaniciTanimliListesi = GridMenuItem.GetListForSaveList(KullaniciTanimliListesi);
            kullaniciTanimliListesi.AddRange(menuList);
            if (!String.IsNullOrEmpty(Program.acilacakRapor) && Program.acilacakRapor == "DonemselRapor")
            {
                GridMenuItem grd = new GridMenuItem();
                grd.AcilacakPencereDegeri = "Devre Raporları";
                grd.Adi = "Devre Raporları";
                grd.GrubDegeri = "DEVRE RAPORLARI";
                grd.Grubu = "DEVRE RAPORLARI";
                grd.Modulu = "DÖNEMSEL RAPORLAR";
                grd.ModulDegeri = "DÖNEMSEL RAPORLAR";
                grd.TipDegeri = GridMenuItem.Tip.Liste;
                grd.Tipi = "Liste";
                MenuCalistir(this, grd);
            }
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            RibbonForm frm = (RibbonForm)sender;
            if (frm.ActiveMdiChild is frmChart)
                simpleButton1.Visible = false;
            else if (frm.ActiveMdiChild is ftmPivotGrid)
            {
                simpleButton1.Visible = true;
                deger = ((ftmPivotGrid)frm.ActiveMdiChild).window;
                pivot = ((ftmPivotGrid)frm.ActiveMdiChild);
            }
            else simpleButton1.Visible = false;
        }

        private void gridMenu_DataSourceChanged(object sender, EventArgs e)
        {
            gridView1.ExpandAllGroups();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                riMProgress.Stopped = false;
                MenuCalistir(this);

                riMProgress.Stopped = true;
            }
            catch (Exception ex)
            {
                string S = ex.Message;

                //AvukatProRaporlar.Raport.Util.Tools.Logla(ex,this);
            }
        }

        private void liste_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;
            acikFormlar.Remove(frm);

            //if (test)
            //    frm.Dispose();
        }

        private void MenuCalistir(RibbonForm mainForm)
        {
            GridMenuItem menuItem = (GridMenuItem)gridView1.GetFocusedRow();

            switch (menuItem.TipDegeri)
            {
                case GridMenuItem.Tip.Chart:

                    var varMi = from frm in acikFormlar where (frm.Tag is ReportPro.GridMenuItem.AcilacakPencere && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;

                    if (varMi.Count() > 0)
                    {
                        varMi.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }
                        frmChart fc = new frmChart();
                        fc.MdiParent = mainForm;
                        fc.Show();
                        fc.Text = menuItem.Adi;
                        fc.Tag = menuItem.AcilacakPencereDegeri;
                        fc.TabloDegistir(menuItem.AcilacakPencereDegeri);
                        acikFormlar.Add(fc);

                        fc.FormClosing += new FormClosingEventHandler(fc_FormClosing);
                    }
                    break;

                case GridMenuItem.Tip.Pivot:
                    var varMii = from frm in acikFormlar where (frm.Tag is ReportPro.GridMenuItem.AcilacakPencere && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;
                    if (varMii.Count() > 0)
                    {
                        varMii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        ftmPivotGrid pivot = new ftmPivotGrid();
                        pivot.MdiParent = mainForm;
                        pivot.window = menuItem.AcilacakPencereDegeri;
                        pivot.Show();
                        pivot.Text = menuItem.Adi;
                        pivot.TabloAc(menuItem.AcilacakPencereDegeri);
                        pivot.Tag = menuItem.AcilacakPencereDegeri;
                        acikFormlar.Add(pivot);
                        pivot.FormClosing += new FormClosingEventHandler(pivot_FormClosing);
                    }

                    break;

                case GridMenuItem.Tip.Liste:

                    var varMiii = from frm in acikFormlar where (frm.Tag is string && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;
                    if (varMiii.Count() > 0)
                    {
                        varMiii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        frmListeRapor liste = new frmListeRapor();
                        liste.MdiParent = mainForm;
                        liste.Text = menuItem.Adi;
                        liste.Tag = menuItem.AcilacakPencereDegeri;
                        if (menuItem.AcilacakPencereDegeri != "Ticari Krediler Tüm Alacaklar İçin Dönemsel Rapor" && menuItem.AcilacakPencereDegeri != "Ticari Krediler Takipli Alacaklar İçin Dönemsel Rapor" && menuItem.AcilacakPencereDegeri != "Bireysel Krediler Takipli Alacaklar İçin Dönemsel Rapor")
                        {
                            liste.Show();
                            acikFormlar.Add(liste);
                        }

                        string frm = menuItem.AcilacakPencereDegeri.Replace(' ', '_').Replace('ş', 's').Replace('ü', 'u').Replace('ğ', 'g').Replace('ı', 'i').Replace('(', 'æ').Replace(')', 'æ').Replace('Ç', 'C');

                        //AvukatProRaporlar.Raport.Util.RaporSource.Enums.ListeRaporBaslik list= (AvukatProRaporlar.Raport.Util.RaporSource.Enums.ListeRaporBaslik)
                        liste.RaporCagir(menuItem.AcilacakPencereDegeri, menuItem.UniqueId.ToString());
                        liste.FormClosing += new FormClosingEventHandler(liste_FormClosing);
                    }
                    break;

                case GridMenuItem.Tip.KullaniciTanimli:
                    var varMiiii = from frm in acikFormlar where (frm.Tag is string && frm.Tag.ToString() == menuItem.KullaniciTanimliDosyaYolu) select frm;
                    if (varMiiii.Dolumu())
                    {
                        varMiiii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        frmKullaniciTanimli tanimli = new frmKullaniciTanimli();

                        //tanimli.Saved += new frmKullaniciTanimli.OnSaved(tanimli_Saved);
                        tanimli.MdiParent = mainForm;
                        tanimli.Show();
                        tanimli.Text = menuItem.Adi;
                        tanimli.Tag = menuItem.KullaniciTanimliDosyaYolu;
                        acikFormlar.Add(tanimli);
                        if (menuItem.KullaniciTanimliDosyaYolu != null)
                        {
                            tanimli.RaporCagir(menuItem.AcilacakPencereDegeri, menuItem.KullaniciTanimliDosyaYolu);

                            //acikKullaniciTanimlilar.Add(menuItem.KullaniciTanimliDosyaYolu);
                        }
                        else
                        {
                            tanimli.RaporCagir(menuItem.AcilacakPencereDegeri);
                        }
                        tanimli.FormClosing += new FormClosingEventHandler(tanimli_FormClosing);
                    }
                    break;

                default:
                    break;
            }
        }

        private void MenuCalistir(RibbonForm mainForm, GridMenuItem acilacakForm)
        {
            GridMenuItem menuItem = acilacakForm;

            switch (menuItem.TipDegeri)
            {
                case GridMenuItem.Tip.Chart:

                    var varMi = from frm in acikFormlar where (frm.Tag is ReportPro.GridMenuItem.AcilacakPencere && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;

                    if (varMi.Count() > 0)
                    {
                        varMi.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }
                        frmChart fc = new frmChart();
                        fc.MdiParent = mainForm;
                        fc.Show();
                        fc.Text = menuItem.Adi;
                        fc.Tag = menuItem.AcilacakPencereDegeri;
                        fc.TabloDegistir(menuItem.AcilacakPencereDegeri);
                        acikFormlar.Add(fc);

                        fc.FormClosing += new FormClosingEventHandler(fc_FormClosing);
                    }
                    break;

                case GridMenuItem.Tip.Pivot:
                    var varMii = from frm in acikFormlar where (frm.Tag is ReportPro.GridMenuItem.AcilacakPencere && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;
                    if (varMii.Count() > 0)
                    {
                        varMii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        ftmPivotGrid pivot = new ftmPivotGrid();
                        pivot.MdiParent = mainForm;
                        pivot.Show();
                        pivot.Text = menuItem.Adi;
                        pivot.TabloAc(menuItem.AcilacakPencereDegeri);
                        pivot.Tag = menuItem.AcilacakPencereDegeri;
                        acikFormlar.Add(pivot);
                        pivot.FormClosing += new FormClosingEventHandler(pivot_FormClosing);
                    }

                    break;

                case GridMenuItem.Tip.Liste:

                    var varMiii = from frm in acikFormlar where (frm.Tag is string && (string)frm.Tag == menuItem.AcilacakPencereDegeri) select frm;
                    if (varMiii.Count() > 0)
                    {
                        varMiii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        frmListeRapor liste = new frmListeRapor();
                        liste.MdiParent = mainForm;
                        liste.Text = menuItem.Adi;
                        liste.Tag = menuItem.AcilacakPencereDegeri;
                        if (menuItem.AcilacakPencereDegeri != "Ticari Krediler Tüm Alacaklar İçin Dönemsel Rapor" && menuItem.AcilacakPencereDegeri != "Ticari Krediler Takipli Alacaklar İçin Dönemsel Rapor" && menuItem.AcilacakPencereDegeri != "Bireysel Krediler Takipli Alacaklar İçin Dönemsel Rapor")
                        {
                            liste.Show();
                            acikFormlar.Add(liste);
                        }
                        string frm = menuItem.AcilacakPencereDegeri.Replace(' ', '_').Replace('ş', 's').Replace('ü', 'u').Replace('ğ', 'g').Replace('ı', 'i').Replace('(', 'æ').Replace(')', 'æ').Replace('Ç', 'C');

                        //AvukatProRaporlar.Raport.Util.RaporSource.Enums.ListeRaporBaslik list= (AvukatProRaporlar.Raport.Util.RaporSource.Enums.ListeRaporBaslik)
                        liste.RaporCagir(menuItem.AcilacakPencereDegeri, menuItem.UniqueId.ToString());
                        liste.FormClosing += new FormClosingEventHandler(liste_FormClosing);
                    }
                    break;

                case GridMenuItem.Tip.KullaniciTanimli:
                    var varMiiii = from frm in acikFormlar where (frm.Tag is string && frm.Tag.ToString() == menuItem.KullaniciTanimliDosyaYolu) select frm;
                    if (varMiiii.Dolumu())
                    {
                        varMiiii.First().BringToFront();
                    }
                    else
                    {
                        //Acik Formları Kapatır
                        if (acikFormlar.Count > 0 && TabKontrol() == DialogResult.No)
                        {
                            Form tmpform;
                            for (int i = 0; i < acikFormlar.Count; i++)
                            {
                                tmpform = acikFormlar[i];
                                acikFormlar[i] = null;
                                tmpform.Dispose();
                            }
                            acikFormlar.Clear();
                        }

                        frmKullaniciTanimli tanimli = new frmKullaniciTanimli();

                        //tanimli.Saved += new frmKullaniciTanimli.OnSaved(tanimli_Saved);
                        tanimli.MdiParent = mainForm;
                        tanimli.Show();
                        tanimli.Text = menuItem.Adi;
                        tanimli.Tag = menuItem.KullaniciTanimliDosyaYolu;
                        acikFormlar.Add(tanimli);
                        if (menuItem.KullaniciTanimliDosyaYolu != null)
                        {
                            tanimli.RaporCagir(menuItem.AcilacakPencereDegeri, menuItem.KullaniciTanimliDosyaYolu);

                            //acikKullaniciTanimlilar.Add(menuItem.KullaniciTanimliDosyaYolu);
                        }
                        else
                        {
                            tanimli.RaporCagir(menuItem.AcilacakPencereDegeri);
                        }
                        tanimli.FormClosing += new FormClosingEventHandler(tanimli_FormClosing);
                    }
                    break;

                default:
                    break;
            }
        }

        private void pivot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;
            acikFormlar.Remove(frm);

            if (test)
            {
                frm.Dispose();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //riMProgress.Stopped = false;
                MenuCalistir(this);

                //riMProgress.Stopped = true;
            }
            catch (Exception ex)
            {
                string S = ex.Message;

                //AvukatProRaporlar.Raport.Util.Tools.Logla(ex,this);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pivot.pivotlayoutkaydet(deger);
        }

        private void tanimli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;
            acikFormlar.Remove(frm);
            if (test)
                frm.Dispose();
        }
    }
}