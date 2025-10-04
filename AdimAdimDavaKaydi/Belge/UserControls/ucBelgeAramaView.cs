using AdimAdimDavaKaydi.Belge.Forms;
using AvukatProLib;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeAramaView : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        #region Global Fields

        private IEntity _currentRecord;
        private int id;
        private string tableName;

        #endregion Global Fields

        #region Global Properties

        [Browsable(false)]
        public IEntity CurrentRecord
        {
            get { return _currentRecord; }
            set
            {
                _currentRecord = value;
                if (value != null)
                {
                    //  IdValue = ((int)TablesColumnData.GetColumnValueByNameFromRecord(value, "ID").Value);
                    tableName = value.TableName;

                    //      this.ucBelgeKayitUfak1.OpenedRecord = value;
                }
            }
        }

        [Browsable(false)]
        public int IdValue
        {
            get { return id; }
            set
            {
                if (!DesignMode)
                {
                    id = value;
                }
            }
        }

        //aykut hızlandırma 14.02.2013
        //[Browsable(false)]
        //public List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> MyDataSource
        //{
        //    get
        //    {
        //        if (!DesignMode && (this.grdBelge.DataSource is List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>))
        //        {
        //            return (List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>)this.grdBelge.DataSource;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        if (value == null)
        //            grdBelge.DataSource = null;
        //        if (value != null && !DesignMode)
        //        {
        //            this.grdBelge.DataSource = value;

        //            //TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
        //            //  belgeList.Add(value.AddNew());
        //            //  this.ucBelgeKayitUfak1.MyDataSource = belgeList;
        //        }
        //    }
        //}

        [Browsable(false)]
        public DataTable MyDataSource
        {
            get
            {
                return grdBelge.DataSource as DataTable;
            }
            set
            {
                if (value == null)
                    grdBelge.DataSource = null;
                if (value != null && !DesignMode)
                {
                    this.grdBelge.DataSource = value;

                    //TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
                    //  belgeList.Add(value.AddNew());
                    //  this.ucBelgeKayitUfak1.MyDataSource = belgeList;
                }
            }
        }

        [Browsable(false)]
        public string TableName
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return tableName;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    tableName = value;
                }
            }
        }

        #endregion Global Properties

        public ucBelgeAramaView()
        {
            InitializeComponent();
            this.Load += ucbelgetakip_Load;
            grdBelge.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            grdBelge.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gvBelgeArama.RowStyle += gridView1_RowStyle;
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
        private frmLoading loading = new frmLoading();

        public static List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE> GetSelectedFoy(
            List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE> foy)
        {
            List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE> seciliKayitlar =
                new List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE>();

            foreach (AvukatProLib.Arama.AV001_TDIE_BIL_BELGE f in foy)
            {
                if (f.IsSelected)
                {
                    seciliKayitlar.Add(f);
                }
            }
            return seciliKayitlar;
        }

        public void OpenFile(string fileName, byte[] data, BinaryStreamType stype)
        {
            try
            {
                this.textControl1.Load(data, stype);
            }
            catch (Exception)
            {
                textControl1.Text = "Desteklenmeyen Format";
                textControl1.SelectAll();
                textControl1.Selection.FontSize = 1200;
                textControl1.Selection.Bold = true;
            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            List<R_BIRLESIK_TAKIPLER_TUMU_BELGE> seciliKayitlar = new List<R_BIRLESIK_TAKIPLER_TUMU_BELGE>();

            foreach (DataRow f in ((DataTable)grdBelge.DataSource).Rows)
            {
                if (Convert.ToBoolean(f["IsSelected"].ToString()))
                {
                    seciliKayitlar.Add(DataRepository.R_BIRLESIK_TAKIPLER_TUMU_BELGEProvider.Get("ID=" + f["ID"].ToString(), "ID")[0]);
                }
            }

            //foreach (AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity f in (grdBelge.DataSource as List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>))
            //{
            //    if (f.IsSelected)
            //    {
            //        seciliKayitlar.Add(f);
            //    }
            //}
            if (seciliKayitlar.Count > 0)
            {
                foreach (var item in seciliKayitlar)
                {
                    AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(item.ID);
                    if (belge != null && belge.ICERIK != null)
                    {
                        string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DOKUMAN_UZANTI;
                        FileStream fs = new FileStream(bad, FileMode.Create);
                        fs.Write(belge.ICERIK, 0, belge.ICERIK.Length);
                        fs.Close();
                        fs.Dispose();
                        Tools.OpenProgram(bad);
                    }
                    else
                        MessageBox.Show("Belge İçeriği Bulunamadı", "Dikkat", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
            else
            {
                //object obj = ((GridView)grdBelge.MainView).GetFocusedRow();

                AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID((int)((GridView)grdBelge.MainView).GetFocusedRowCellValue("ID"));
                if (belge != null && belge.ICERIK != null)
                {
                    if (string.IsNullOrEmpty(belge.DOKUMAN_UZANTI))
                    {
                        string[] p = belge.DOSYA_ADI.Split('.');
                        if (p.Length > 1)
                            belge.DOKUMAN_UZANTI = p[p.Length - 1];
                    }

                    string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DOKUMAN_UZANTI;
                    FileStream fs = new FileStream(bad, FileMode.Create);
                    fs.Write(belge.ICERIK, 0, belge.ICERIK.Length);
                    fs.Close();
                    fs.Dispose();
                    Tools.OpenProgram(bad);
                }
                else
                    MessageBox.Show("Belge İçeriği Bulunamadı", "Dikkat", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void grdBelge_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                CompInfo cmpNfo = cmpNfoList[0];
                if (cmpNfo.DegistirmeSilmeSifresiAktif)
                {
                    frmOnaySifreKontrolu frmx = new frmOnaySifreKontrolu(4);
                    frmx.ShowDialog();
                    if (!frmx.Onaylandi)
                        return;
                }

                //List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> blgList =
                //    grdBelge.DataSource as List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>;
                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity belge = new AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity();
                AV001_TDIE_BIL_BELGE belgeorj = new AV001_TDIE_BIL_BELGE();
                //if (blgList[gvBelgeArama.FocusedRowHandle] is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity)
                //    belge = blgList[gvBelgeArama.FocusedRowHandle];

                belgeorj = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")));

                DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(belgeorj, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
                TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
                belgeList.Add(belgeorj);

                frmBelgeKayitUfak belgeEkle = new frmBelgeKayitUfak();
                belgeEkle.ucBelgeKayitUfak1.MyDataSource = belgeList;
                belgeEkle.ucBelgeKayitUfak1.Duzenle = true;
                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity duzenlenenBelgem =
                //    gvBelgeArama.GetFocusedRow() as AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity;

                AV001_TDIE_BIL_BELGE belgem = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")));
                DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(belgem, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<NN_BELGE_ICRA>),
                                                                     typeof(TList<NN_BELGE_DAVA>),
                                                                     typeof(TList<NN_BELGE_SOZLESME>),
                                                                     typeof(TList<NN_BELGE_HAZIRLIK>));
                if (belgem.NN_BELGE_ICRACollection.Count > 0)
                {
                    foreach (var icra in belgem.NN_BELGE_ICRACollection)
                    {
                        if (icra.ICRA_FOY_IDSource == null)
                            DataRepository.NN_BELGE_ICRAProvider.DeepLoad(icra, false, DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TI_BIL_FOY));

                        CurrentRecord = icra.ICRA_FOY_IDSource;
                    }
                }

                if (belgem.NN_BELGE_DAVACollection.Count > 0)
                {
                    foreach (var dava in belgem.NN_BELGE_DAVACollection)
                    {
                        if (dava.DAVA_FOY_IDSource == null)
                            DataRepository.NN_BELGE_DAVAProvider.DeepLoad(dava, false, DeepLoadType.IncludeChildren,
                                                                          typeof(AV001_TD_BIL_FOY));

                        CurrentRecord = dava.DAVA_FOY_IDSource;
                    }
                }

                if (belgem.NN_BELGE_SOZLESMECollection.Count > 0)
                {
                    foreach (var sozlesme in belgem.NN_BELGE_SOZLESMECollection)
                    {
                        if (sozlesme.SOZLESME_IDSource == null)
                            DataRepository.NN_BELGE_SOZLESMEProvider.DeepLoad(sozlesme, false,
                                                                              DeepLoadType.IncludeChildren,
                                                                              typeof(AV001_TDI_BIL_SOZLESME));

                        CurrentRecord = sozlesme.SOZLESME_IDSource;
                    }
                }

                if (belgem.NN_BELGE_HAZIRLIKCollection.Count > 0)
                {
                    foreach (var hazirlik in belgem.NN_BELGE_HAZIRLIKCollection)
                    {
                        if (hazirlik.HAZIRLIK_IDSource == null)
                            DataRepository.NN_BELGE_HAZIRLIKProvider.DeepLoad(hazirlik, false,
                                                                              DeepLoadType.IncludeChildren,
                                                                              typeof(AV001_TD_BIL_HAZIRLIK));

                        CurrentRecord = hazirlik.HAZIRLIK_IDSource;
                    }
                }

                if (CurrentRecord != null)
                {
                    switch (CurrentRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belgeEkle.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belgeEkle.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belgeEkle.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belgeEkle.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        default:
                            break;
                    }
                }
                belgeEkle.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;
                belgeEkle.ucBelgeKayitUfak1.Record = belgem;

                //belgeEkle.MdiParent = null;
                belgeEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeEkle.Show();
            }

            else if (e.Button.Tag.ToString() == "Sil")
            {
                //List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> blgList =
                //    grdBelge.DataSource as List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>;
                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity belge = new AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity();
                //belge = blgList[gvBelgeArama.FocusedRowHandle];
                AV001_TDIE_BIL_BELGE seciliBelge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")));

                if (seciliBelge != null)
                {
                    AdimAdimDavaKaydi.Util.frmKayitSil kayitSil =
                        new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDIE_BIL_BELGE", "ID = " + seciliBelge.ID);
                    kayitSil.Show();
                }
            }
        }

        private void grdBelge_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "FormdanEkle")
            {
                TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
                frmBelgeKayitUfak belgeEkle = new frmBelgeKayitUfak();
                belgeEkle.ucBelgeKayitUfak1.MyDataSource = belgeList;
                belgeEkle.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;

                //.MdiParent = null;
                belgeEkle.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeEkle.Show();
            }
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (gvBelgeArama.GetFocusedRow() != null)
            {
                //AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity belge =
                //    ((AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity)gvBelgeArama.GetFocusedRow());

                if (Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")) != 0)
                {
                    AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE selBel =
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")));
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(selBel, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_DOLASIM>));

                    if (gvBelgeArama.GetFocusedRow() == null)
                    {
                        return;
                    }

                    string file = selBel.DOSYA_ADI;
                    string[] exts = file.Split('.');

                    if (exts.Length <= 0)
                    {
                        return;
                    }

                    string ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
                    byte[] data = selBel.ICERIK;

                    if (file == string.Empty && data == null)
                    {
                        return;
                    }

                    if (data == null)
                    {
                        if (File.Exists(file))
                        {
                            FileStream fss = new FileStream(file, FileMode.Open);

                            byte[] veri = new byte[fss.Length];
                            fss.Read(veri, 0, veri.Length);
                            selBel.ICERIK = veri;
                            data = selBel.ICERIK;
                            fss.Close();
                        }
                    }

                    Loading();
                    ucBelgeDolasim1.MyDataSource = selBel.AV001_TDIE_BIL_BELGE_DOLASIMCollection;
                    ucBelgeOnizleme1.ViewFile(data, selBel.ID, selBel.KONTROL_VERSIYON, ext);
                    loading.Close();

                    dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                }
            }
        }

        private void gvBelgeArama_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                gridControl1.DataSource = null;
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                cn.AddParams("@BELGE_ID", gvBelgeArama.GetFocusedRowCellValue("ID"));
                gridControl1.DataSource = cn.GetDataTable("select a.KODU,  CARI_ID, c.AD as CARI_ADI, A.SIFAT_ID from dbo.AV001_TDIE_BIL_BELGE_TARAF(nolock) a LEFT join dbo.AV001_TDI_BIL_CARI(nolock) c on c.ID=a.CARI_ID  where BELGE_ID=@BELGE_ID");
            }
            catch { ;}
        }

        private void Loading()
        {
            loading = new frmLoading();
            loading.TopMost = true;
            loading.ShowInTaskbar = false;
            loading.StartPosition = FormStartPosition.CenterScreen;
            loading.ShowIcon = false;
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Name == "bButonIsEkle")
            {
                //if (e.Item.Tag is AvukatProLib.Arama.AV001_TDIE_BIL_BELGE)
                //{
                AvukatProLib.Arama.AV001_TDIE_BIL_BELGE genel = e.Item.Tag as AvukatProLib.Arama.AV001_TDIE_BIL_BELGE;

                AV001_TDIE_BIL_BELGE takip = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(Convert.ToInt32(gvBelgeArama.GetFocusedRowCellValue("ID")));
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();

                frmisKayit.ucIsKayitUfak1.ModulID = 8;
                frmisKayit.ucIsKayitUfak1.OpenedRecord = takip;
                frmisKayit.ucIsKayitUfak1.Modul = 8;

                // frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.Show();
                //}
            }
        }

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            BarButtonItem bus2 = new BarButtonItem(e.Manager, "İş Ekle");
            bus2.Tag = e.Rows;
            bus2.Name = "bButonIsEkle";
            bus2.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.accept_22x221;
            e.MyPopupMenu.ItemLinks.Insert(1, bus2);
        }

        private void tsmKaydiDuzenle_Click(object sender, EventArgs e)
        {
            List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> blgList =
                grdBelge.DataSource as List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>;
            AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity belge = new AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity();
            AV001_TDIE_BIL_BELGE belgeorj = new AV001_TDIE_BIL_BELGE();
            if (blgList[gvBelgeArama.FocusedRowHandle] is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity)
                belge = blgList[gvBelgeArama.FocusedRowHandle];
            belgeorj = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(belge.Id);

            DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(belgeorj, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
            TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
            belgeList.Add(belgeorj);
            frmBelgeKayitUfak belgeEkle = new frmBelgeKayitUfak();
            belgeEkle.ucBelgeKayitUfak1.MyDataSource = belgeList;
            belgeEkle.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;
            belgeEkle.ucBelgeKayitUfak1.Duzenle = true;
            belgeEkle.Show();
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity> blgList =
                grdBelge.DataSource as List<AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity>;
            AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity belge = new AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity();
            AV001_TDIE_BIL_BELGE belgeorj = new AV001_TDIE_BIL_BELGE();
            if (blgList[gvBelgeArama.FocusedRowHandle] is AvukatPro.Model.EntityClasses.RBirlesikTakiplerTumuBelgeEntity)
                belge = blgList[gvBelgeArama.FocusedRowHandle];
            belgeorj = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(belge.Id);
            DataRepository.AV001_TDIE_BIL_BELGEProvider.Delete(belgeorj);
        }

        private void tsmYeniKayit_Click(object sender, EventArgs e)
        {
            TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
            frmBelgeKayitUfak belgeEkle = new frmBelgeKayitUfak();
            belgeEkle.ucBelgeKayitUfak1.MyDataSource = belgeList;
            belgeEkle.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;
            belgeEkle.Show();
        }

        private void ucbelgetakip_Load(object sender, EventArgs e)
        {
            Yukle();
            if (!this.DesignMode)
            {
                if (this.CurrentRecord != null)
                {
                    MyDataSource = new DataTable();
                }
                try
                {
                    foreach (GridColumn item in gvBelgeArama.Columns)
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

        private void Yukle()
        {
            if (DesignMode)
            {
                return;
            }

            Inits.AsamaKodGetir(rLueBelgeAsamaID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(rLueAdliBirimAdliyeID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rLueAdliBirimNoID);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(rLueAdliBirimGorevID);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rLueCariID);
            AvukatPro.Services.Implementations.DevExpressService.TarafKoduDoldur(lkpKodu);
            BelgeUtil.Inits.CariSifatGetir(lkpSifat);
            Inits.BelgeOzelKodGetir(rLueOzelKodID);
            Inits.CariSifatGetir(rLueBelgeSifatKodID);

            //Inits.BelgeTurleriResimliGetir(rLueBelgeTurResimli);
            Inits.KontrolKimGetir(rLueKontrolKim);
            Inits.SubeKodGetir(rLueSubeKod);

            #region Grid View RepositoryItems

            AvukatPro.Services.Implementations.DevExpressService.BelgeTuruDoldur(rlueBelgeTur);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod1, 1, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod2, 2, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod3, 3, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.OzelKodDoldur(rlueOzelKod4, 4, AvukatProLib.Extras.Modul.Belge);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(rlueAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(rlueGorev);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(rlueNo);
            //AvukatPro.Services.Implementations.DevExpressService.FoyDurumDoldur(rlueDurum);
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(rlueModul, null);
            AvukatPro.Services.Implementations.DevExpressService.SegmentDoldur(rlueSegment);
            //AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);
            Inits.DokumanUzantiComboBox(rLueBelgeDosyaUzanti);

            #endregion Grid View RepositoryItems

            //Inits.perSorumluAvukatGetir(rLueSorumlu);
        }
    }
}