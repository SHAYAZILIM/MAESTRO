using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Linq;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using AvukatProLib;
using System.Data.SqlClient;
using System.IO;
using AdimAdimDavaKaydi.AnaForm;
using System.Data;
using AdimAdimDavaKaydi.Forms.LayForm;
using AdimAdimDavaKaydi.IcraTakipForms;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucTebligatMuhatapForGiris : AvpXUserControl
    {

        public ucTebligatMuhatapForGiris()
        {
            this.Load += ucTebligatMuhatapForGiris_Load;
        }

        public delegate void OnBelgeSaved(object belgeKayitSender, AV001_TDIE_BIL_BELGE savedBelge);

        public delegate void OnSaved(IList Records, IEntity Record);

        public event OnSaved Saved;

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //BarButtonItem item = e.Item as BarButtonItem;

            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                // cariForms.MdiParent = null;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        public void SagTusaEkle()
        {
            //gcKurumsalGiris.RightClickPopup.BarItemCollections.Assign(popupMenu1.LinksPersistInfo);
            exGridTebligatMuhatap.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                exGridTebligatMuhatap.RightClickPopup.LinkPersist.Add(var);
            }



            //BarButtonItem barteb = new BarButtonItem(exGridTebligatMuhatap.RightClickPopup.MyBarManager, "Tebligat Bilgisi Gir/Güncelle");
            //barteb.ItemClick += new ItemClickEventHandler(barteb_ItemClick);
            //exGridTebligatMuhatap.RightClickPopup.BarItemCollections.Add(barteb);            
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    //frmSorusturma.MdiParent = null;
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    // frmicraDosyaKayit.MdiParent = null;
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    //frmsozlesmeKayit.MdiParent = null;
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBSahis.Name)
                {
                    frmCariGenelGiris cGiris = new frmCariGenelGiris();
                    cGiris.YeniKayitMi = true;
                    // cGiris.MdiParent = null;
                    cGiris.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cGiris.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    //tKayit.MdiParent = null;
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    //frmdavaDosyaKayit.MdiParent = null;
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }

                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                    {
                        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity takipR =
                            e.Item.Tag as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                        AV001_TDI_BIL_TEBLIGAT_MUHATAP takip =
                            DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByID((int)takipR.Id);
                        DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.DeepLoad(takip, false,
                                                                                       DeepLoadType.IncludeChildren,
                                                                                       typeof(AV001_TDI_BIL_CARI));
                        string tablob = "AV001_TDI_BIL_TEBLIGAT_MUHATAP";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();

                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                belgeKayit.Child.Saved += Child_OnSave;
                                //belgeKayit.MdiParent = null;
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }
                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                    {
                        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity takip =
                            e.Item.Tag as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                        string tabloI = "AV001_TDI_BIL_TEBLIGAT_MUHATAP";
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit =
                            new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        frmisKayit.ModulID = 9;
                        frmisKayit.SetByTableNameAndId(tabloI, (int)takip.Id);
                        //frmisKayit.MdiParent = null;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }
                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT)
                    //{
                    //    AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT takip = e.Item.Tag as AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_TEBLIGAT_MUHATAP";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.ShowDialog(tabloB, takip.ID);

                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                    {
                        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity takip =
                            e.Item.Tag as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();

                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.Tebligat, (int)takip.Id);
                    }
                }

                else if (e.Item.Name == bButonKisayolEkle.Name)
                {
                    if (e.Item.Tag is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                    {
                        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity takip =
                            e.Item.Tag as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                        if (takip.Id != null)
                        {
                            #region <KA-20090709>

                            //Kisayol oluþturma tek bir yere çekildi daðýnýklýk giderildi.
                            Kisayol.CreateShortCut((int)takip.Id, Kisayol.AcilisSekli.Tebligat);

                            #endregion </KA-20090709>
                        }
                        //string dosyaUzantisi = string.Empty;
                        //if (takip.ID != null)
                        //{
                        //    dosyaUzantisi = "Tebligat Dosyasý (*.avpt)|*.AVPT";
                        //    string kaydedilecek = takip.ID.ToString();

                        //    SaveFileDialog sfd = new SaveFileDialog();
                        //    sfd.Filter = dosyaUzantisi;

                        //    DialogResult sonuc = sfd.ShowDialog();
                        //    if (sonuc == DialogResult.OK)
                        //    {
                        //        try
                        //        {
                        //            byte[] veri = System.Text.Encoding.UTF8.GetBytes(kaydedilecek);

                        //            Tools.SaveTofile(sfd.FileName, veri);
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            BelgeUtil.ErrorHandler.Catch(this, ex);
                        //        }
                        //    }
                        //}
                    }
                }
                else if (e.Item.Name == bButtonSikKullanilan.Name)
                {
                    if (e.Item.Tag is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                    {
                        AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity takip =
                            e.Item.Tag as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                        AvukatProLib.Extras.ModulTip tablo =
                            AvukatProLib.Extras.ModulTip.Tebligat;
                        string AD = string.Format("{0} {1} {2} {3}E. nolu Dosyasý", takip.Adliye,
                                                  takip.Gorev, takip.No,
                                                  takip.EsasNo);
                        rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                        frm.ShowDialog(tablo, (int)takip.Id, AD);
                    }
                }
                else if (e.Item.Caption == "Düzenle")
                {
                    AV001_TDI_BIL_TEBLIGAT t = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)gvTebligat.GetFocusedRowCellValue("Id"));
                    frmLayTabligatKayit frm = new frmLayTabligatKayit();
                    frm.MyDataSource = t;
                    if (t.ICRA_FOY_ID != null)
                        frm.Show(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)t.ICRA_FOY_ID));
                    else if (t.DAVA_FOY_ID != null)
                        frm.Show(DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)t.DAVA_FOY_ID));
                    else
                        frm.Show();
                }
                else if (e.Item.Caption == "Express Düzenle")
                {
                    AV001_TDI_BIL_TEBLIGAT t = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)gvTebligat.GetFocusedRowCellValue("Id"));
                    frmLayTabligatKayit_exp frm = new frmLayTabligatKayit_exp();
                    frm.MyDataSource = t;
                    if (t.ICRA_FOY_ID != null)
                        frm.Show(DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)t.ICRA_FOY_ID));
                    else if (t.DAVA_FOY_ID != null)
                        frm.Show(DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)t.DAVA_FOY_ID));
                    else
                        frm.Show();
                }
            }
        }

        private void Child_OnSave(IList Records, IEntity Record)
        {
            if (this.Saved != null)
            {
                this.Saved(Records, Record);
            }
        }

        private void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "AlanCariId")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity secim = e.Rows as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                R_BIRLESIK_TAKIPLER_TEBLIGAT secim = DataRepository.R_BIRLESIK_TAKIPLER_TEBLIGATProvider.Get(" ID=" + (int)gvTebligat.GetFocusedRowCellValue("Id"), "ID")[0];

                int? id = secim.ALAN_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
            else if (e.Column != null && e.Column.FieldName == "MuhatapCariId")
            {

                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");

                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                //barBtnSecimiKaldir.Tag = e.Column;

                bus.ItemLinks.Add(barBtnSecimiKaldir);

                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity secim = e.Rows as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                R_BIRLESIK_TAKIPLER_TEBLIGAT secim = DataRepository.R_BIRLESIK_TAKIPLER_TEBLIGATProvider.Get(" ID=" + (int)gvTebligat.GetFocusedRowCellValue("Id"), "ID")[0];

                int? id = secim.MUHATAP_CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(1, bus);
            }

            BarButtonItem barteb = new BarButtonItem(e.Manager, "Tebligat Bilgisi Gir/Güncelle");
            barteb.ItemClick += new ItemClickEventHandler(barteb_ItemClick);
            e.MyPopupMenu.AddItem(barteb);
        }

        void barteb_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MessageBox.Show("sdf");
            rFrmTebligat frm = new rFrmTebligat();
            frm.TFormTipi = rFrmTebligat.TebligatFormTipi.TebligatFormu;

            AV001_TDI_BIL_TEBLIGAT t = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)gvTebligat.GetFocusedRowCellValue("Id"));
            //AV001_TI_BIL_FOY_TARAF_GELISME g = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_ID((int)t.ICRA_FOY_ID)[0];

            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            if (t.ICRA_FOY_ID != null)
            {
                frm.MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)t.ICRA_FOY_ID);
                TList<AV001_TI_BIL_FOY_TARAF_GELISME> g = DataRepository.AV001_TI_BIL_FOY_TARAF_GELISMEProvider.GetByICRA_FOY_ID((int)t.ICRA_FOY_ID);
                if (g.Count > 0)
                    frm.MyGelisme = g[0];
            }
            frm.MyTebligatMuhatap = DataRepository.AV001_TDI_BIL_TEBLIGAT_MUHATAPProvider.GetByTEBLIGAT_ID((int)gvTebligat.GetFocusedRowCellValue("Id"))[0];
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(t);
        }

        public void FilitreleriTemizle()
        {
            gvTebligat.ActiveFilter.Clear();
        }

        private DataTable _myDataSource;

        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWork = new BackgroundWorker();

        public void BindData()
        {
            if (!bckWork.IsBusy)
            {
                this.Enabled = false;
                bckWork.DoWork += delegate
                                      {
                                          //if (MyDataSource != null)
                                          //AvukatProLib.AramaAV001_TDI_BIL_TEBLIGATProvider.DeepLoad(MyDataSource
                                          //    , false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_TEBLIGAT)
                                          //    , typeof(AV001_TDI_BIL_TEBLIGAT_YAPAN));
                                      };
                bckWork.RunWorkerCompleted += delegate
                                                  {
                                                      exGridTebligatMuhatap.DataSource = MyDataSource;

                                                      this.Enabled = true;
                                                  };
                bckWork.RunWorkerAsync();
            }
        }

        private void ucTebligatMuhatapForGiris_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.IsLoaded = true;
            exGridTebligatMuhatap.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            exGridTebligatMuhatap.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gvTebligat.RowStyle += gridView1_RowStyle;
            if (!this.DesignMode)
            {
                //LOAD
                exGridTebligatMuhatap.ButtonCevirClick += exGridTebligatMuhatap_ButtonCevirClick;
                LoadInits();
                SagTusaEkle();
                BindData();

                try
                {
                    foreach (GridColumn item in gvTebligat.Columns)
                    {
                        if (item.Name.Contains("colReferansNo1"))
                            item.Caption = Kimlikci.Kimlik.DavaReferans.Referans1;
                        if (item.Name.Contains("colReferansNo2"))
                            item.Caption = Kimlikci.Kimlik.DavaReferans.Referans2;
                        if (item.Name.Contains("colReferansNo3"))
                            item.Caption = Kimlikci.Kimlik.DavaReferans.Referans3;
                        if (item.Name.Contains("colOzelKod1"))
                            item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod1;
                        if (item.Name.Contains("colOzelKod2"))
                            item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod2;
                        if (item.Name.Contains("colOzelKod3"))
                            item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod3;
                        if (item.Name.Contains("colOzelKod4"))
                            item.Caption = Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
                    }

                }
                catch
                {
                }
            }
        }
        private void gridView1_RowStyle(object sender,
DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var stamp = view.GetRowCellDisplayText(e.RowHandle, view.Columns["STAMP"]);
                bool isRed = false;
                bool.TryParse(stamp, out isRed);
                if (stamp != "1")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }
        private void LoadInits()
        {
            AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(rLueDovizTip);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(rlueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rlueNo);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(rlueGorev);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur_Bind(rlueCariId, true, null);
            AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(rlueDurum);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(rLueTK);
            BelgeUtil.Inits.TebligatAltTurGetir(rlueAltTur);
            BelgeUtil.Inits.TebligatAlanBaglantiGetir(rlueBaglanti);
            AvukatPro.Services.Implementations.DevExpressService.AltKategoriDoldur(rlueMuhasebeAltKategori);
            BelgeUtil.Inits.TebligatKonuGetir(rlueKonu);
            BelgeUtil.Inits.KullaniciSubeleriGetir(rlueSube);
            AvukatPro.Services.Implementations.DevExpressService.TebligatSonucDoldur(rlueTebligatSonuc);
            BelgeUtil.Inits.TebligatAlinmamaNedenGetir(rlueAlinmamaNeden);
            BelgeUtil.Inits.TebligatAlimSekli(rlueAlimSekil);
            BelgeUtil.Inits.TebligatAnaTurGetir(rlueAnaTur); ;
            AvukatPro.Services.Implementations.DevExpressService.EvrakSonucDoldur(rlueEvrakSonuc);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, AvukatProLib.Extras.Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, AvukatProLib.Extras.Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, AvukatProLib.Extras.Modul.Tebligat);
            AvukatPro.Services.Implementations.DevExpressService.TebligatDurumDoldur(repositoryItemLookUpEdit1);

        }

        private void exGridTebligatMuhatap_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridTebligatMuhatap.Visible)
            {
                exGridTebligatMuhatap.Visible = false;
            }
        }

        public delegate void OnFocusedRowChanged(AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity RowData, AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity exRowData, int RowHandle, object sender);


        private void gvTebligat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        public event EventHandler<EventArgs> KayitSilindi;

        private void tebligat_YenileKayit(object sender, AdimAdimDavaKaydi.Forms.LayForm.EvrakKayitEventArgs e)
        {
            if (e.MyEvrak != null)
                XtraMessageBox.Show("Eklediðiniz kaydýn gelmesi için yeniden sorgulama yapýnýz.", "BÝLGÝ",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exGridTebligatMuhatap_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.LayForm.frmLayTabligatKayit tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                tebligat.YenileKayit += tebligat_YenileKayit;
                tebligat.Show();
            }
            else if (e.Button.Tag.ToString() == "FormAcExp")
            {
                Forms.LayForm.frmLayTabligatKayit_exp tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp();
                tebligat.YenileKayit += tebligat_YenileKayit;
                tebligat.Show();
            }
            else if (e.Button.Tag.ToString() == "DuzenleExp")
            {

                Forms.LayForm.frmLayTabligatKayit_exp tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit_exp();
                tebligat.Duzenlememi = true;
                if (gvTebligat.GetFocusedRow() != null && gvTebligat.GetFocusedRow() is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                {
                    var currentTebligat = gvTebligat.GetFocusedRow() as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                    switch (currentTebligat.Tipi)
                    {
                        case "Ýcra":
                            tebligat.MyIcraFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Dava":
                            tebligat.MyDavaFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Soruþturma":
                            tebligat.MyHazirlikFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Sözleþme":
                            tebligat.MySozlesmeFoyID = currentTebligat.FoyId.Value;
                            break;
                        default:
                            break;
                    }

                    tebligat.MyDataSource = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)currentTebligat.Id);
                    tebligat.Show();
                }
            }
            else if (e.Button.Tag.ToString() == "Duzenle")
            {

                Forms.LayForm.frmLayTabligatKayit tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                tebligat.Duzenlememi = true;
                if (gvTebligat.GetFocusedRow() != null && gvTebligat.GetFocusedRow() is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)
                {
                    var currentTebligat = gvTebligat.GetFocusedRow() as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;
                    switch (currentTebligat.Tipi)
                    {
                        case "Ýcra":
                            tebligat.MyIcraFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Dava":
                            tebligat.MyDavaFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Soruþturma":
                            tebligat.MyHazirlikFoyID = currentTebligat.FoyId.Value;
                            break;
                        case "Sözleþme":
                            tebligat.MySozlesmeFoyID = currentTebligat.FoyId.Value;
                            break;
                        default:
                            break;
                    }

                    tebligat.MyDataSource = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)currentTebligat.Id);
                    tebligat.Show();
                }
            }

            else if (e.Button.Tag.ToString() == "KayitSil")
            {
                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity cari =
                //    gvTebligat.GetFocusedRow() as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity;

                VList<R_BIRLESIK_TAKIPLER_TEBLIGAT> cari = DataRepository.R_BIRLESIK_TAKIPLER_TEBLIGATProvider.Get("ID=" + gvTebligat.GetFocusedRowCellValue("Id"), "ID");
                string Foy_no = cari[0].DOSYA_NO;
                frmKayitSil kayitSil = new frmKayitSil("AV001_TDI_BIL_TEBLIGAT", "ID = " + cari[0].ID);
                if (kayitSil.ShowDialog() == DialogResult.OK)
                {
                    if (KayitSilindi != null)
                        KayitSilindi(this, new EventArgs());

                    XtraMessageBox.Show(Foy_no + " Tebligat Silinmiþtir");
                }
            }
        }

        private void sbtnIliskiEkle_Click(object sender, EventArgs e)
        {
            if (gvTebligat.GetFocusedRow() == null) return;
            var selectedTebligat = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID((int)(gvTebligat.GetFocusedRow() as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity).Id);
            Forms.frmTebligatIliskiEkle frm = new frmTebligatIliskiEkle();
            frm.Show(selectedTebligat);
        }

        private void gvTebligat_RowClick(object sender, RowClickEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            //object myobject = view.GetRow(e.RowHandle);
            //TebligatSorgula(((AvukatPro.Model.EntityClasses.RBirlesikTakiplerTebligatEntity)myobject));
        }

        private void gvTebligat_DoubleClick(object sender, EventArgs e)
        {
            //barteb_ItemClick(sender, null);

            try
            {
                gridControl1.DataSource = null;
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                cn.AddParams("@ID", gvTebligat.GetFocusedRowCellValue("Id"));
                gridControl1.DataSource = cn.GetDataTable("SELECT SIRA_NO, ISLEM, YER, BILGI_GIRIS_TARIH, ACIKLAMA FROM dbo.AV001_TDI_BIL_TEBLIGAT_MUHATAP_PTT_GELISME(nolock) WHERE TEBLIGAT_MUHATAP_ID=@ID ORDER BY SIRA_NO");
            }
            catch
            {
                MessageBox.Show("Barkod detaylarý listeleniren hata oluþtu.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exGridTebligatMuhatap_Click(object sender, EventArgs e)
        {

        }

        //public event DataGridViewRowDividerDoubleClickEventHandler gvTebligat_DoubleClick;

        //private void gvTebligat_DoubleClick(object sender, EventArgs e)
        //{
        //    //if (ucTebligatMuhatapForGiris1.gvTebligat.SelectedRowsCount > 0)
        //    //{
        //    //    List<int> idler = AvukatPro.Services.Implementations.DosyaService.GetAllBelgeIDsByTebligatID((int)ucTebligatMuhatapForGiris1.gvTebligat.GetRowCellValue(e.FocusedRowHandle, "Id"));
        //    //    if (idler.Count > 0)
        //    //        ucBelgeIzleme1.BelgeIds = idler;
        //    //}
        //}
    }
}