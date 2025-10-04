using AdimAdimDavaKaydi.Belge.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucbelgetakip : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucbelgetakip()
        {
            InitializeComponent();
        }

        private byte[] data;

        private string ext = "";

        private bool initsLoaded;

        private frmLoading loading = new frmLoading();

        private AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE selBel;

        public event OnSaved Saved;

        public void RefreshGridDataSource(AV001_TDIE_BIL_BELGE belge)
        {
            ((List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>)grdBelge.DataSource).Add(BelgeUtil.Inits.BelgeGetir().Find(vi => vi.ID == belge.ID));
            grdBelge.RefreshDataSource();
        }

        #region Properties

        private IEntity _currentRecord;
        private bool _IsLoaded;

        private List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> _MyDatasource;

        private int id;

        private string tableName;

        [Browsable(false)]
        public IEntity CurrentRecord
        {
            get { return _currentRecord; }
            set
            {
                _currentRecord = value;
                if (value != null)
                {
                    tableName = value.TableName;
                    this.ucBelgeKayitUfak1.OpenedRecord = value;
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

        public bool IsLoaded
        {
            get { return _IsLoaded; }
            set { _IsLoaded = value; }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get { return _MyDatasource; }
            set
            {
                _MyDatasource = value;
                if (IsLoaded)
                    BindData();
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

        #endregion Properties

        #region Events

        public delegate void OnSaved(IList Records, IEntity Record);

        private void btnProgram_Click(object sender, EventArgs e)
        {
            object obj = ((GridView)grdBelge.MainView).GetFocusedRow();
            AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID((obj as AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE).ID);
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
                MessageBox.Show("Belge Ýçeriði Bulunamadý", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grdBelge_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();

                TList<AV001_TDIE_BIL_BELGE> duzenlenenBelge = new TList<AV001_TDIE_BIL_BELGE>();
                duzenlenenBelge.Add(DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(MyDataSource[gridView1.FocusedRowHandle].ID));

                if (CurrentRecord != null)
                {
                    switch (CurrentRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belgeKayit.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belgeKayit.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belgeKayit.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belgeKayit.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belgeKayit.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;

                        default:
                            break;
                    }
                }

                belgeKayit.ucBelgeKayitUfak1.MyDataSource = duzenlenenBelge;
                belgeKayit.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;
                belgeKayit.ucBelgeKayitUfak1.Duzenle = true;
                belgeKayit.ucBelgeKayitUfak1.Record = gridView1.GetFocusedRow() as AV001_TDIE_BIL_BELGE;
                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belgeKayit.Show();
            }
        }

        private void grdBelge_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmBelgeKayitUfak belge = new frmBelgeKayitUfak();

                if (CurrentRecord != null)
                {
                    switch (CurrentRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            belge.ucBelgeKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            belge.ucBelgeKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            belge.ucBelgeKayitUfak1.ModulID = 5;
                            break;

                        case "AV001_TDIE_BIL_PROJE":
                            belge.ucBelgeKayitUfak1.ModulID = 11; //Klasör
                            break;

                        default:
                            break;
                    }
                }

                belge.MyDataSource = new TList<AV001_TDIE_BIL_BELGE>();
                belge.SetByTableNameAndId(CurrentRecord.TableName, IdValue);
                belge.ucBelgeKayitUfak1.OpenedRecord = CurrentRecord;
                belge.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
                belge.ucBelgeKayitUfak1.BelgeKaydedildi += ucBelgeKayitUfak1_BelgeKaydedildi;
                belge.StartPosition = FormStartPosition.WindowsDefaultLocation;
                belge.Show();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            object obj = ((GridView)grdBelge.MainView).GetFocusedRow();
            if (((AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)obj).DOKUMAN_UZANTI.ToLower().Equals("msg"))
            {
                string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + ((AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)obj).DOKUMAN_UZANTI;
                FileStream fs = new FileStream(bad, FileMode.Create);
                fs.Write(data, 0, data.Length);
                fs.Close();
                fs.Dispose();
                Tools.OpenProgram(bad);
            }
            else
            {
                if (data == null || data.Length == 0 || selBel == null || String.IsNullOrEmpty(ext)) return;
                ucBelgeOnizleme1.ViewFile(data, selBel.ID, selBel.KONTROL_VERSIYON, ext);
                loading.Close();
                ucBelgeOnizleme1.BringToFront();
                dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                return;
            }

            selBel = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(((AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)gridView1.GetFocusedRow()).ID);
            string file = selBel.DOSYA_ADI;
            string[] exts = file.Split('.');

            if (exts.Length <= 0)
            {
                return;
            }

            ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
            data = selBel.ICERIK;

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
            loading.Close();
            this.ucBelgeKayitUfak1.Position = gridView1.GetVisibleIndex(e.FocusedRowHandle);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ucBelgeKayitUfak belgeKayit = new ucBelgeKayitUfak();
            belgeKayit.MyDataSource = new TList<AV001_TDIE_BIL_BELGE>();
            belgeKayit.OpenedRecord = CurrentRecord;
            belgeKayit.Duzenle = true;
            belgeKayit.Show();
        }

        private void ucBelgeKayitUfak1_BelgeKaydedildi(object sender, ucBelgeKayitUfak.BelgeKaydedildiEventArgs e)
        {
            if (e.Belge != null)
            {
                BelgeUtil.Inits._BelgeGetir = BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.ToList();
                BelgeUtil.Inits._BelgeGetir.Add(BelgeUtil.Inits.context.per_AV001_TDIE_BIL_BELGEs.Where(vi => vi.ID == e.Belge.ID).FirstOrDefault());
                ((List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>)grdBelge.DataSource).Add(BelgeUtil.Inits.BelgeGetir().Find(vi => vi.ID == e.Belge.ID));
                grdBelge.RefreshDataSource();
            }
        }

        private void ucBelgeKayitUfak1_Saved(IList Records, IEntity Record)
        {
            if (DesignMode)
            {
                return;
            }

            if (this.Saved != null)
                this.Saved(Records, Record);
        }

        private void ucbelgetakip_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                IsLoaded = true;

                //Yukle(); Okan ARDIÇ // Buradan taþýndý
                if (this.CurrentRecord != null)
                {
                    MyDataSource = AdimAdimDavaKaydi.Belge.Util.NNProcess.GetBelgeler(this.CurrentRecord, false);
                }
                else
                {
                }
                gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
                BindData();
                gridView1.FocusedRowHandle = -1;

                if (BelgeUtil.Inits.PaketAdi == 0)
                {
                    gridColumn1.Visible = colBELGE_TUR_ID.Visible = BELGE_NO.Visible = colDOSYA_ADI.Visible = ColTebligTarihi.Visible = gridColumn33.Visible = gridColumn34.Visible = gridColumn35.Visible = true;
                    gridColumn1.VisibleIndex = 0;
                }
            }
        }

        #endregion Events

        #region Methods

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

        public void Save()
        {
            if (grdBelge.DataSource is TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)
            {
                for (int i = 0;
                     i < ((TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)grdBelge.DataSource).DeletedItems.Count;
                     i++)
                {
                    if (
                        ((TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)grdBelge.DataSource).DeletedItems[i].
                            IsDeleted)
                    {
                        AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_TARAFProvider.Delete(
                            ((TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)grdBelge.DataSource).DeletedItems[i].
                                AV001_TDIE_BIL_BELGE_TARAFCollection);
                    }
                }
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepSave(
                    ((TList<AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE>)grdBelge.DataSource),
                    AvukatProLib2.Data.DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
            }
        }

        private void BindData()
        {
            if (MyDataSource != null && !DesignMode)
            {
                //MyDataSource.ListChanged += MyDataSource_ListChanged; //Okan ARDIÇ // Performans Çalýþmasý // 06.01.2010
                //MyDataSource.AddingNew += MyDataSource_AddingNew;
                InitsDoldur();

                //DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
                this.grdBelge.DataSource = MyDataSource;
                TList<AV001_TDIE_BIL_BELGE> belgeList = new TList<AV001_TDIE_BIL_BELGE>();
                this.ucBelgeKayitUfak1.MyDataSource = belgeList;
                ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
            }
        }

        private void InitsDoldur()
        {
            if (DesignMode)
            {
                return;
            }
            if (!initsLoaded && MyDataSource.Count > 0) // Okan ARDIÇ // 06.01.2010 // Performans Çalýþmasý
            {
                BelgeUtil.Inits.AsamaKodGetir(rLueBelgeAsamaID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.BelgeOzelKodGetir(rLueOzelKodID);
                BelgeUtil.Inits.CariSifatGetir(rLueBelgeSifatKodID);
                BelgeUtil.Inits.BelgeTurGetir(rlueBelgeTur);
                initsLoaded = true;
            }
        }

        private void Loading()
        {
            loading = new frmLoading();
            loading.TopMost = true;
            loading.ShowInTaskbar = false;
            loading.StartPosition = FormStartPosition.CenterScreen;
            loading.ShowIcon = false;
        }

        #endregion Methods

        private void grdBelge_Click_1(object sender, EventArgs e)
        {
        }
    }
}