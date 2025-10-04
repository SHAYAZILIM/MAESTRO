using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatPro.WinUI;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class tabHacizGridler : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        private TList<AV001_TI_BIL_KIYMET_TAKDIRI> childExpertiz = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();

        private TList<AV001_TI_BIL_ISTIHKAK> childIstihkak = new TList<AV001_TI_BIL_ISTIHKAK>();

        private TList<AV001_TI_BIL_HACIZ_ISTIRAK> childIstirak = new TList<AV001_TI_BIL_HACIZ_ISTIRAK>();

        private TList<AV001_TI_BIL_KIYMET_TAKDIRI> childKiymet = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();

        private AV001_TI_BIL_FOY myFoy;

        public tabHacizGridler()
        {
            if (DesignMode) InitializeComponent();
            this.Load += tabHacizGridler_Load;
        }

        public enum MalKategori
        {
            GAYRIMENKUL = 1,
            GELÝR = 5,
            ARAÇ = 2,
            MENKUL = 7,
            SAHISTAKÝ_HAK_VE_ALACAK = 6,
            GEMI = 8,
            UCAK = 9
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_HACIZ_CHILD HacizChildSelectedRow { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_HACIZ_MASTER HacizMasterSelectedRow { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    DataDegistir();
            }
        }

        public void tebMuzekkereveIhbarNameGetir()
        {
            #region<cc-20090722>

            //þimdilik aþaðýdaki þerkilde düzeltildi prosedür yazýlmasý gerek
            TList<AV001_TDI_BIL_TEBLIGAT> Muzekere =
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.Find("ALT_TUR_ID='94'");
            Muzekere.Filter = "ICRA_FOY_ID = " + MyFoy.ID;
            if (ucTebligat1 == null) CreateUcTebligat1();
            ucTebligat1.MyIcraFoy = MyFoy;
            ucTebligat1.muzekkre = true;
            ucTebligat1.MyDataSource = Muzekere;

            //Ihbarname getir Prosodure yazdýrdýk

            TList<AV001_TDI_BIL_TEBLIGAT> Ihaberneme =
                DataRepository.AV001_TDI_BIL_TEBLIGATProvider.HacizIhbarnameGetir();
            Ihaberneme.Filter = "ICRA_FOY_ID = " + MyFoy.ID;

            #endregion</cc-20090722>

            if (ucTebligat2 == null) CreateUcTebligat2();
            ucTebligat2.MyDataSource = Ihaberneme;
            ucTebligat2.ihbarname = true;
            ucTebligat2.MyIcraFoy = MyFoy;
        }

        private void AV001_TI_BIL_HACIZ_MASTERCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_HACIZ_MASTER master = e.NewObject as AV001_TI_BIL_HACIZ_MASTER;
            if (master == null)
                master = new AV001_TI_BIL_HACIZ_MASTER();

            master.HACIZ_KAYNAGI = (int)HacizKaynak.Normal_Haciz;
            master.HM_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            master.HM_ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID;
            master.HM_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            master.HACIZ_SIRA_NO = ucHacizMaster.SiraNo(MyFoy);
            master.AV001_TI_BIL_HACIZ_CHILDCollection.AddingNew += HacizChild_AddingNew;
            master.AV001_TI_BIL_HACIZ_CHILDCollection.AddNew();
            master.TALIMAT_ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID;
            master.TALIMAT_ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID;
            master.HACIZ_ISTEYEN_CARI_ID = ucIcraTarafBilgileri.CurrTarafId;
            if (ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy).Count > 0)
                master.HACIZ_ISTENEN_CARI_ID = ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy)[0].CARI_ID.Value;
            TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT> sorumluAvukat = ucIcraTarafBilgileri.SorumluTaraflariGetir(MyFoy);

            master.HACIZ_SORUMLU_PERSONEL_ID = (int)sorumluAvukat[0].SORUMLU_AVUKAT_CARI_ID;

            e.NewObject = master;
        }

        private void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((e.Item.Tag as AV001_TI_BIL_HACIZ_CHILD) != null)
            {
                frmMalTakipSureci malTakip = new frmMalTakipSureci();
                var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                var child = e.Item.Tag as AV001_TI_BIL_HACIZ_CHILD;
                liste.Add(child);
                malTakip.MyDataSource = liste;
                malTakip.MyFoy = MyFoy;
                malTakip.FormClosing += malTakip_FormClosing;
                malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                malTakip.Show();
            }
            else
                XtraMessageBox.Show("Hacizli mal bulunamadý.");
        }

        private void DataDegistir()
        {
            childIstihkak = new TList<AV001_TI_BIL_ISTIHKAK>();
            childIstirak = new TList<AV001_TI_BIL_HACIZ_ISTIRAK>();
            childKiymet = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();
            childExpertiz = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_HACIZ_MASTER>),
                                                             typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>),
                                                             typeof(TList<AV001_TI_BIL_ISTIHKAK>));
            if (!this.IsLoaded) this.tabHacizGridler_Load(null, EventArgs.Empty);
            if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
            {
                gcHaciz.DataSource = MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.FindAll(vi => vi.HACIZ_EDILECEK_MAL_VAR.Value);
                gcBosHacizler.DataSource = MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.FindAll(vi => !vi.HACIZ_EDILECEK_MAL_VAR.Value);
            }
            foreach (var item in MyFoy.AV001_TI_BIL_HACIZ_ISTIRAKCollection)
            {
                childIstirak.Add(item);
            }
            foreach (var item in MyFoy.AV001_TI_BIL_ISTIHKAKCollection)
            {
                childIstihkak.Add(item);
            }

            gwHaciz_Child.FocusedRowChanged += gwHaciz_Child_FocusedRowChanged;
            if (gcHaciz.DataSource != null)
                MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.AddingNew += AV001_TI_BIL_HACIZ_MASTERCollection_AddingNew;

            foreach (AV001_TI_BIL_HACIZ_MASTER master in MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection)
            {
                DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.DeepLoad(master, false, DeepLoadType.IncludeChildren,
                                                                          typeof(TList<AV001_TI_BIL_HACIZ_CHILD>));
                foreach (AV001_TI_BIL_HACIZ_CHILD child in master.AV001_TI_BIL_HACIZ_CHILDCollection)
                {
                    DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(child, false, DeepLoadType.IncludeChildren,
                                                                             typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>),
                                                                             typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>),
                                                                             typeof(TList<AV001_TI_BIL_ISTIHKAK>));

                    childIstirak.AddRange(child.AV001_TI_BIL_HACIZ_ISTIRAKCollection);

                    childIstihkak.AddRange(child.AV001_TI_BIL_ISTIHKAKCollection);
                    foreach (var item in child.AV001_TI_BIL_KIYMET_TAKDIRICollection)
                    {
                        if (item.EKSPERTIZ_KAYDI_MI == true)
                            childExpertiz.Add(item);
                        else
                            childKiymet.Add(item);
                    }
                }
            }
            gcIstihkak.DataSource = childIstihkak;
            gcIstirak.DataSource = childIstirak;
            gcKiymetT.DataSource = childKiymet;
            exGridEkspertiz.DataSource = childExpertiz;
        }

        private void exGridEkspertiz_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            #region Expertiz Mal Takip Süreci

            if (e.Button.Tag.ToString() == "MalTakip")
            {
                if (gvEkspertiz.GetFocusedRow() != null)
                {
                    frmMalTakipSureci malTakip = new frmMalTakipSureci();

                    AV001_TI_BIL_KIYMET_TAKDIRI Row = (AV001_TI_BIL_KIYMET_TAKDIRI)gvEkspertiz.GetFocusedRow();
                    AV001_TI_BIL_HACIZ_CHILD result =
                        DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(Row.HACIZ_CHILD_ID.Value);

                    if (Row != null)
                    {
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        liste.Add(result);
                        malTakip.MyDataSource = liste;

                        malTakip.MyFoy = MyFoy;

                        //.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.FormClosing += malTakip_FormClosing;
                        malTakip.Show();
                    }

                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }
            }
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                {
                    frmKiymetTakdiri frm = new frmKiymetTakdiri();

                    //.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.EkspertizKaydiMi = true;
                    frm.MyHacizChild = (gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD).ID;
                    frm.FormClosing += frm_FormClosing;
                    frm.Show(MyFoy);
                }
                else
                    XtraMessageBox.Show("Lütfen Bir Haciz/Rehin Kaydý Yapýnýz");
            }
            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmKiymetTakdiri frm = new frmKiymetTakdiri();

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.EkspertizKaydiMi = true;
                if (gvEkspertiz.FocusedRowHandle >= 0)
                {
                    if (frm.AddNewList == null) frm.AddNewList = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();
                    frm.AddNewList.Add(
                        (gvEkspertiz.DataSource as TList<AV001_TI_BIL_KIYMET_TAKDIRI>)[gvEkspertiz.FocusedRowHandle]);
                }
                frm.FormClosing += frm_FormClosing;
                frm.Show(MyFoy);
            }

            #endregion
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataDegistir();
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataDegistir();

            #region <MB-20100623>

            //Eðer yeni kaydedilen þahýs varsa, gridler üzerindeki lookup'ýn yeniden dolmasýný saðlamak için eklendi.
            if (frmKiymetTakdiri.YeniCariKaydiYapildi)
                BelgeUtil.Inits.perCariGetir(rLueCariID);

            #endregion
        }

        private void frmHacizGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataDegistir();
        }

        private void frmistihdak_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataDegistir();
        }

        private void gcBosHacizler_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "frmHacizGirisi")
            {
                frmHacizGirisi frm = new frmHacizGirisi();
                frm.FormClosed += frmHacizGirisi_FormClosed;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.HacizEdilecekMalVar = false;
                frm.Show(MyFoy, null);
            }
            else if (e.Button.Tag.ToString() == "Duzenle")
            {
                if (gvBosHacizler.GetFocusedRow() != null && gvBosHacizler.GetFocusedRow() is AV001_TI_BIL_HACIZ_MASTER)
                {
                    frmHacizGirisi frm = new frmHacizGirisi();
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += frmHacizGirisi_FormClosed;
                    frm.HacizEdilecekMalVar = false;
                    frm.Show(MyFoy, gvBosHacizler.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER);
                }
                else
                    MessageBox.Show("Düzenlenecek Kaydý Seçiniz", "Düzenle", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void gcHaciz_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            gcHaciz.Visible = !gcHaciz.Visible;
        }

        private void gcHaciz_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            //if (e.Button.Tag.ToString() == "aramaEkrani")
            //{
            //    frmHacizArama frm = new frmHacizArama();
            //    //.MdiParent = null;
            //    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            //    frm.ShowDialog(MyFoy, ucIcraTarafBilgileri.CurrBorcluId);
            //}

            if (e.Button.Tag.ToString() == "frmHacizGirisi")
            {
                frmHacizGirisi frm = new frmHacizGirisi();
                frm.FormClosed += frmHacizGirisi_FormClosed;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.HacizEdilecekMalVar = true;
                frm.Show(MyFoy, null);
            }
            else if (e.Button.Tag.ToString() == "Duzenle")
            {
                if (gwHaciz.GetFocusedRow() != null && gwHaciz.GetFocusedRow() is AV001_TI_BIL_HACIZ_MASTER)
                {
                    frmHacizGirisi frm = new frmHacizGirisi();
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += frmHacizGirisi_FormClosed;
                    frm.HacizEdilecekMalVar = true;
                    frm.Show(MyFoy, gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER);
                }
                else
                    MessageBox.Show("Düzenlenecek Kaydý Seçiniz", "Düzenle", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }

            //this.gcHaciz.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            //new DevExpress.XtraEditors.NavigatorCustomButton(9, 9, true, true, "Mal Takip Süreci", "MalTakip")});
        }

        private void gcHacizChild_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                frmHacizGirisi frm = new frmHacizGirisi();
                frm.FormClosed += frmHacizGirisi_FormClosed;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.HacizEdilecekMalVar = (gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER).HACIZ_EDILECEK_MAL_VAR == null ? true : (gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER).HACIZ_EDILECEK_MAL_VAR.Value;
                frm.Show(MyFoy, null);
            }

            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                if (gwHaciz.FocusedRowHandle >= 0)
                {
                    frmHacizGirisi frm = new frmHacizGirisi();

                    //.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.FormClosed += frmHacizGirisi_FormClosed;

                    //Düzenleme modunda ilgili child bilgisinin ekrana gelmesini saðlamak için eklendi.
                    frm.ChildList.Add((gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD));

                    //
                    frm.HacizEdilecekMalVar = (gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER).HACIZ_EDILECEK_MAL_VAR == null ? true : (gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER).HACIZ_EDILECEK_MAL_VAR.Value;
                    frm.Show(MyFoy, MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection[gwHaciz.FocusedRowHandle]);
                }
                else
                    MessageBox.Show("Düzenlenecek Kaydý Seçiniz", "Düzenle", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void gcHacizChild_Click(object sender, EventArgs e)
        {
            GetChildDetails();
        }

        private void gcIstihkak_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            gcIstihkak.Visible = !gcIstihkak.Visible;
        }

        private void gcIstihkak_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count <= 0)
                {
                    XtraMessageBox.Show("Haciz Kaydý Olmadan Istihkak Kaydý Giremezsiniz");
                    return;
                }
                frmIcraHacizIstihkak frm = new frmIcraHacizIstihkak();

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.MyHacizChild = (gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD).ID;
                frm.FormClosed += frmistihdak_FormClosed;
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }

            else if (e.Button.Tag.ToString() == "MalTakip")
            {
                #region Istihkak Mal Takip Süreci

                if (gwIstihkak.GetFocusedRow() != null)
                {
                    AV001_TI_BIL_ISTIHKAK Row = (AV001_TI_BIL_ISTIHKAK)gwIstihkak.GetFocusedRow();
                    if (Row == null) return;
                    if (Row.HACIZ_CHILD_ID.HasValue)
                    {
                        AV001_TI_BIL_HACIZ_CHILD result =
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(Row.HACIZ_CHILD_ID.Value);
                        frmMalTakipSureci malTakip = new frmMalTakipSureci();
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        liste.Add(result);
                        malTakip.MyDataSource = liste;
                        malTakip.MyFoy = MyFoy;

                        //malTakip.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.FormClosing += malTakip_FormClosing;
                        malTakip.Show();
                    }
                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }

                #endregion
            }
            else if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                frmIcraHacizIstihkak frm = new frmIcraHacizIstihkak();

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.FormClosed += frm_FormClosed;
                if (gwIstihkak.FocusedRowHandle >= 0)
                {
                    if (frm.AddNewList == null) frm.AddNewList = new TList<AV001_TI_BIL_ISTIHKAK>();
                    frm.AddNewList.Add(
                        (gwIstihkak.DataSource as TList<AV001_TI_BIL_ISTIHKAK>)[gwIstihkak.FocusedRowHandle]);
                }
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }
        }

        private void gcIstirak_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            gcIstirak.Visible = !gcIstirak.Visible;
        }

        private void gcIstirak_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null) return;

            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count <= 0)
                {
                    XtraMessageBox.Show("Haciz Kaydý Olmadan Istihkak Kaydý Giremezsiniz");
                    return;
                }
                frmIcraHacizIstirak frm = new frmIcraHacizIstirak();

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.FormClosed += frm_FormClosed;
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }

            else if (e.Button.Tag.ToString() == "MalTakip")
            {
                #region Ýþtiraktan Mal Takip Süreci

                if (gwIstirak.GetFocusedRow() != null)
                {
                    AV001_TI_BIL_HACIZ_ISTIRAK Row = (AV001_TI_BIL_HACIZ_ISTIRAK)gwIstirak.GetFocusedRow();
                    if (Row != null)
                    {
                        AV001_TI_BIL_HACIZ_CHILD result =
                            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(Row.HACIZ_CHILD_ID.Value);
                        frmMalTakipSureci malTakip = new frmMalTakipSureci();
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        liste.Add(result);
                        malTakip.MyDataSource = liste;
                        malTakip.MyFoy = MyFoy;

                        //malTakip.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.FormClosing += malTakip_FormClosing;
                        malTakip.Show();
                    }

                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }

                #endregion
            }
            else if (e.Button.Tag.ToString() == "KayitDuzenle")
            {
                frmIcraHacizIstirak frm = new frmIcraHacizIstirak();
                frm.FormClosed += frm_FormClosed;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                if (gwIstirak.FocusedRowHandle >= 0)
                {
                    if (frm.AddNewList == null) frm.AddNewList = new TList<AV001_TI_BIL_HACIZ_ISTIRAK>();
                    frm.AddNewList.Add(
                        (gwIstirak.DataSource as TList<AV001_TI_BIL_HACIZ_ISTIRAK>)[gwIstirak.FocusedRowHandle]);
                }
                frm.MyFoy = MyFoy;
                frm.Show(MyFoy);
            }
        }

        private void gcKiymetT_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            gcKiymetT.Visible = !gcKiymetT.Visible;
        }

        private void gcKiymetT_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "FrmEkle")
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_HACIZ_MASTER>));
                if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                {
                    frmKiymetTakdiri frm = new frmKiymetTakdiri();

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.EkspertizKaydiMi = false;
                    frm.MyHacizChild = (gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD).ID;
                    frm.FormClosing += frm_FormClosing;
                    frm.Show(MyFoy);
                }
                else
                    XtraMessageBox.Show("Lütfen Bir Haciz/Rehin Kaydý Yapýnýz");
            }
            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmKiymetTakdiri frm = new frmKiymetTakdiri();
                frm.EkspertizKaydiMi = false;
                if (gwKiymetTakdiri.FocusedRowHandle >= 0)
                {
                    if (frm.AddNewList == null) frm.AddNewList = new TList<AV001_TI_BIL_KIYMET_TAKDIRI>();
                    frm.AddNewList.Add(
                        (gwKiymetTakdiri.DataSource as TList<AV001_TI_BIL_KIYMET_TAKDIRI>)[
                            gwKiymetTakdiri.FocusedRowHandle]);
                }

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.FormClosing += frm_FormClosing;
                frm.Show(MyFoy);
            }
            else if (e.Button.Tag.ToString() == "MalTakip")
            {
                #region Kýymet Takdiri Mal Takip Süreci

                if (gwKiymetTakdiri.GetFocusedRow() != null)
                {
                    frmMalTakipSureci malTakip = new frmMalTakipSureci();

                    AV001_TI_BIL_KIYMET_TAKDIRI Row = (AV001_TI_BIL_KIYMET_TAKDIRI)gwKiymetTakdiri.GetFocusedRow();
                    AV001_TI_BIL_HACIZ_CHILD result =
                        DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByID(Row.HACIZ_CHILD_ID.Value);

                    if (Row != null)
                    {
                        var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                        liste.Add(result);
                        malTakip.MyDataSource = liste;
                        malTakip.MyFoy = MyFoy;

                        // malTakip.MdiParent = null;
                        malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        malTakip.FormClosing += malTakip_FormClosing;
                        malTakip.Show();
                    }

                    else
                        XtraMessageBox.Show("Hacizli mal bulunamadý.");
                }

                #endregion
            }
        }

        private void GetChildDetails()
        {
            if (gvHacizChild.GetFocusedRow() == null) return;

            AV001_TI_BIL_HACIZ_CHILD hacizChild = gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD;

            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hacizChild, false, DeepLoadType.IncludeChildren, typeof(AV001_TI_BIL_GAYRIMENKUL), typeof(AV001_TDI_BIL_GEMI_UCAK_ARAC));

            if (hacizChild.GAYRIMENKUL_BILGI_IDSource != null)
            {
                splitHacizliMalBilgileri.PanelVisibility = SplitPanelVisibility.Both;
                ucGayrimenkulBilgileri.Visible = true;
                ucAracBilgileri.Visible = false;
                ucGayrimenkulBilgileri.MyGayrimenkul = hacizChild.GAYRIMENKUL_BILGI_IDSource;
            }
            else if (hacizChild.ARAC_BILGI_IDSource != null)
            {
                splitHacizliMalBilgileri.PanelVisibility = SplitPanelVisibility.Both;
                ucAracBilgileri.Visible = true;
                ucGayrimenkulBilgileri.Visible = false;
                ucAracBilgileri.MyArac = hacizChild.ARAC_BILGI_IDSource;
            }
            else
            {
                splitHacizliMalBilgileri.PanelVisibility = SplitPanelVisibility.Panel1;
                ucAracBilgileri.Visible = false;
                ucGayrimenkulBilgileri.Visible = false;
            }

            if (BelgeUtil.Inits.PaketAdi == 1) return;//Yeni Nesil Kurumsal Finansta aþaðýdaki bilgiler mal takip süreci üzerinden izleneceði ve deðiþiklik, yeni kayýt iþlemi yapýcaðýndan gridler gösterilmiyor ve databind iþlemi de boþ yere yaptýrýlmýyor. MB
            DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.DeepLoad(hacizChild, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_KIYMET_TAKDIRI>), typeof(TList<AV001_TI_BIL_HACIZ_ISTIRAK>), typeof(TList<AV001_TI_BIL_ISTIHKAK>));
            gcKiymetT.DataSource = hacizChild.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => !vi.EKSPERTIZ_KAYDI_MI.Value);
            exGridEkspertiz.DataSource = hacizChild.AV001_TI_BIL_KIYMET_TAKDIRICollection.FindAll(vi => vi.EKSPERTIZ_KAYDI_MI.Value);
            gcIstihkak.DataSource = hacizChild.AV001_TI_BIL_ISTIHKAKCollection;
            gcIstirak.DataSource = hacizChild.AV001_TI_BIL_HACIZ_ISTIRAKCollection;
        }

        private void gvHacizChild_DataSourceChanged(object sender, EventArgs e)
        {
            GetChildDetails();
        }

        private void gvHacizChild_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetChildDetails();
        }

        private void gwHaciz_Child_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TList<AV001_TI_BIL_HACIZ_MASTER> master = gwHaciz.DataSource as TList<AV001_TI_BIL_HACIZ_MASTER>;
            if (master.Count > e.FocusedRowHandle) return;
            HacizMasterSelectedRow = master.Where(vi => vi.ID == (gwHaciz.GetFocusedRow() as AV001_TI_BIL_HACIZ_MASTER).ID).FirstOrDefault();
            if (HacizMasterSelectedRow.AV001_TI_BIL_HACIZ_CHILDCollection.Count > e.FocusedRowHandle)
                HacizChildSelectedRow = HacizMasterSelectedRow.AV001_TI_BIL_HACIZ_CHILDCollection[e.FocusedRowHandle];
        }

        private void gwHaciz_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            if ((gcHaciz.DataSource as TList<AV001_TI_BIL_HACIZ_MASTER>).Count > 0)
            {
                AV001_TI_BIL_HACIZ_MASTER hacizMaster =
                    (gcHaciz.DataSource as TList<AV001_TI_BIL_HACIZ_MASTER>)[e.FocusedRowHandle];

                TList<AV001_TI_BIL_HACIZ_CHILD> hacizChildList = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                if (hacizMaster != null)
                {
                    hacizChildList = DataRepository.AV001_TI_BIL_HACIZ_CHILDProvider.GetByMASTER_ID(hacizMaster.ID);
                    gcHacizChild.DataSource = hacizChildList;

                    if (hacizChildList.Count == 1)
                        splitHacizliMalBilgileri.PanelVisibility = SplitPanelVisibility.Panel2;
                    else
                        splitHacizliMalBilgileri.PanelVisibility = SplitPanelVisibility.Both;
                }
            }
        }

        private void HacizChild_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_HACIZ_CHILD child = e.NewObject as AV001_TI_BIL_HACIZ_CHILD;
            if (child == null) child = new AV001_TI_BIL_HACIZ_CHILD();

            if (MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection.Count > 0)
                child.MAL_SIRA_NO = ucHacizChild.MalSiraNo(MyFoy.AV001_TI_BIL_HACIZ_MASTERCollection[0]);

            child.HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = 1;
            child.HACIZLI_MAL_DEGERI_DOVIZ_ID = 1;
            child.HACIZLI_MAL_ADEDI = 1;
            child.ALACAKLI_RIZASI_VAR_MI = true;
            child.HACIZ_ISLEM_DURUM_ID = 3;
            child.KAYIT_TARIHI = DateTime.Today;
            child.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            child.KONTROL_KIM = "AVUKATPRO";
            child.KONTROL_NE_ZAMAN = DateTime.Today;
            child.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            child.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            child.SUBE_KODU = (short)AvukatProLib.Kimlik.SubeKodu;
            child.HACIZLI_MAL_ADET_BIRIM_ID = 9;
            e.NewObject = child;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMalTakipSureci malTakip = new frmMalTakipSureci();

            AV001_TI_BIL_HACIZ_CHILD result = gvHacizChild.GetFocusedRow() as AV001_TI_BIL_HACIZ_CHILD;

            if (result != null)
            {
                var liste = new TList<AV001_TI_BIL_HACIZ_CHILD>();
                liste.Add(result);
                malTakip.MyDataSource = liste;
                malTakip.MyFoy = MyFoy;
                malTakip.StartPosition = FormStartPosition.WindowsDefaultLocation;
                malTakip.FormClosing += malTakip_FormClosing;
                malTakip.Show();
            }
        }

        private void malTakip_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataDegistir();
        }

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            if (e.Rows is AV001_TI_BIL_HACIZ_CHILD)
            {
                var btn = new DevExpress.XtraBars.BarButtonItem(e.Manager, "Mal Takip Süreç");
                btn.Tag = e.Rows;
                btn.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dnext_16x16_zoom;
                e.MyPopupMenu.ItemLinks.Insert(0, btn);
                btn.ItemClick += btn_ItemClick;
            }
        }

        private void tabHacizGridler_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded)
            {
                InitializeComponent();
                xtraTabControl1.SelectedPageChanging += xtraTabControl1_SelectedPageChanging;
                gcIstihkak.ButtonCevirClick += gcIstihkak_ButtonCevirClick;
                gcIstirak.ButtonCevirClick += gcIstirak_ButtonCevirClick;
                gcKiymetT.ButtonCevirClick += gcKiymetT_ButtonCevirClick;
                gcHaciz.ButtonCevirClick += gcHaciz_ButtonCevirClick;
                this.gcHacizChild.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
                this.gvHacizChild.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvHacizChild_FocusedRowChanged);

                IsLoaded = true;
                BelgeUtil.Inits.ItirazSonucuGetir(rlueItirazSonucu);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                BelgeUtil.Inits.MalTurGetir(rLueMalTurID);
                BelgeUtil.Inits.MalKategoriGetir(rLueMalKategoriID);
                BelgeUtil.Inits.MalTurGetir(rLueMalTur2);
                BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori2);
                BelgeUtil.Inits.MalKategoriResimliGetir(rLueKategoriComboBox);
                BelgeUtil.Inits.MalcinsGetir(rLueCins);
                BelgeUtil.Inits.HacizChildGetir(MyFoy, rLueMallar);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.BirimKodGetir(rLueMalAdetBirimID);
                BelgeUtil.Inits.ImtiyazliAlacakGetir(rLueImtiyazliAlacakSiraID);
                BelgeUtil.Inits.HAcizKaynakGetir(rLueHacizKaynak);
                BelgeUtil.Inits.ParaBicimiAyarla(deger);
                if (MyFoy != null)
                    tebMuzekkereveIhbarNameGetir();

                BelgeUtil.Inits.perCariGetir(rlueYeddiemin);
                BelgeUtil.Inits.BirimKodGetir(rlueMalAdetBirim);
                BelgeUtil.Inits.HacizIslemDurumGetir(rlueHacizIslemDurum);
                BelgeUtil.Inits.DovizTipGetir(rlueMalDegeriDoviz);
                BelgeUtil.Inits.MalTurGetir(rlueHacizliMallar);
                BelgeUtil.Inits.MalTurGetir(rlueChildMallar);

                Mallar6.Visible = false;

                if (BelgeUtil.Inits.PaketAdi == 1) splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == tabHacizIhbarname.Name)
            {
                if (ucTebligat2 == null)
                {
                    CreateUcTebligat2();
                }
            }
            else if (e.Page.Name == tabHacizMuzereke.Name)
            {
                if (ucTebligat1 == null)
                {
                    CreateUcTebligat1();
                }
            }
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        #region Grid Control Button Click Events

        #region Haciz

        #endregion

        #region Boþ Haciz

        #endregion

        #region Kýymet Takdiri

        #endregion

        #region Ýþtirak

        #endregion

        #region Ýstihkak

        #endregion

        #region Expertiz

        #endregion

        #endregion

        #region <MB-20100526>

        //Haciz Master gridinde,týklanan master satýrýnýn child bilgilerinin alttaki gride getirilmesi için eklendi.

        #endregion
    }
}