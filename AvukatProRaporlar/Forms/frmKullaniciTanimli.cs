#define debug

using AvukatProRaporlar.Lib;
using AvukatProRaporlar.Raport.Util;
using AvukatProRaporlar.Util;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using RaporDataSource.TableDB;
using ReportPro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProRaporlar.Forms
{
    public partial class frmKullaniciTanimli : DevExpress.XtraEditors.XtraForm
    {
        public frmKullaniciTanimli()
        {
            InitializeComponent();
            GridView grid = gridRaporCntrol.MainView as GridView;

            checkBox1.Checked = grid.OptionsView.AllowCellMerge;
        }

        //DataObjectDataContext odb = new DataObjectDataContext();
        private readonly List<GridColumn> groupColon = new List<GridColumn>();

        //private List<ParaVeDovizId> odemeToplamlar = new List<ParaVeDovizId>();
        private List<int?> dovizler = new List<int?>();

        private Dictionary<int, decimal> kurlar;

        private List<TimeSpan> listeTime = new List<TimeSpan>();

        private List<GridColumn> selectColumns = new List<GridColumn>();

        private SaveList sl = new SaveList();

        /// <summary>
        /// Kaydetmeden önce çalışan delegate
        /// </summary>
        /// <param name="sender">kaydedilecek dizi</param>
        /// <param name="path">kaydedilecek yol </param>
        public delegate void OnBeforeSave(SaveList sender, string path);

        /// <summary>
        /// kaydetme işlemi bitince çalışır
        /// </summary>
        /// <param name="sender">kaydedilen form</param>
        /// <param name="data">kaydedilen data</param>
        /// <param name="path">kaydedilen dosya</param>
        public delegate void OnSaved(frmKullaniciTanimli sender, SaveList data, string path);

        /// <summary>
        /// kaydetme işleminden önce tetiklenir
        /// </summary>
        public event OnBeforeSave BeforeSave;

        /// <summary>
        /// kaydetme işleminden sonra tetiklenir...
        /// </summary>
        public event OnSaved Saved;

        public Dictionary<int, decimal> Kurlar
        {
            get
            {
                if (kurlar == null)
                    kurlar = DovizGetir(DateTime.Today);
                return kurlar;
            }
            set { kurlar = value; }
        }

        //    }
        //    else if (sonuclar.Count > 1)
        //    {
        //        result.DovizId = 1; //YTL
        //        foreach (ParaVeDovizId id in paralar)
        //        {
        //            if (id.DovizId == 1)
        //                result.Para += id.Para;
        //            else
        //                result.Para += id.Para * Kurlar[id.DovizId];
        //            //id.YtlCevir(id.KurCevrimTarihi.Value);
        //        }
        //    }
        //    return result;
        //}
        public Dictionary<int, decimal> DovizGetir(DateTime gun)
        {
            try
            {
                //if (new DovizAPI.AVP_NG_DOVIZ_SOAP_API_NENCSoapClient() == null)
                //{
                //    return null;
                //}
                System.Globalization.NumberFormatInfo formatProvider = new System.Globalization.NumberFormatInfo();
                formatProvider.NumberDecimalSeparator = ".";
                formatProvider.NumberGroupSeparator = ",";
                formatProvider.NumberGroupSizes = new int[] { 3 };

                //DovizAPI.AVP_NG_DOVIZ_SOAP_API_NENCSoapClient m = new AvukatProRaporlar.DovizAPI.AVP_NG_DOVIZ_SOAP_API_NENCSoapClient();
                DataSet onlineKur;
                Dictionary<int, decimal> kurlar;
                List<TDI_KOD_DOVIZ_TIP> tipler;

                Connection conn = new Connection();
                DBDataContext db = new DBDataContext(conn.MyConnection);
                tipler = db.TDI_KOD_DOVIZ_TIPs.ToList();
                kurlar = new Dictionary<int, decimal>();

                //onlineKur = m.GunlukKurGetir(DateTime.Today.ToString("ddMMyyyy 7652626"), gun.Date);

                //ToDo : Burası Halledilecek;
                //MessageBox.Show(ex.Message);
                Dictionary<int, decimal> ahmet = new Dictionary<int, decimal>();
                foreach (DovizTip tp in Enum.GetValues(typeof(DovizTip)))
                {
                    ahmet.Add((int)tp, 1);
                }
                return ahmet;
            }
            catch 
            {
                // MessageBox.Show("Yok internet");
                return null;
            }
        }

        public void RaporCagir(string pencere)
        {
            switch (pencere)
            {
                case "KulTanimli_Icra":
                    btnKaydet.Tag = pencere;
                    GenelTablo();
                    break;

                case "KulTanimli_YapilacakIs":
                    btnKaydet.Tag = pencere;
                    IsTablo();
                    break;

                case "KulTanimli_Hesapli_Kapsamli_Genel_Tarafli":
                    btnKaydet.Tag = pencere;
                    HESAPLI_KAPSAMLI_GENEL_TARAFLI();
                    break;

                case "KulTanimli_Hesapli_Kapsamli_Genel_Sorumlu":
                    btnKaydet.Tag = pencere;
                    HESAPLI_KAPSAMLI_GENEL_SORUMLU();
                    break;

                case "KulTanimli_Sorusturma_Genel_Hesapsiz":
                    btnKaydet.Tag = pencere;
                    SORUSTURMA_GENEL_HESAPSIZ();
                    break;

                case "KulTanimli_Sorusturma_Genel_Hesapsiz_Sorumlu":
                    btnKaydet.Tag = pencere;
                    SORUSTURMA_GENEL_HESAPSIZ_SORUMLULU();
                    break;

                case "KulTanimli_sorusturma_Genel_Hesapsiz_Tarafli":
                    btnKaydet.Tag = pencere;
                    SORUSTURMA_GENEL_HESAPSIZ_TARAFLI();
                    break;

                case "KulTanimli_Tebligat_Muhatap":
                    btnKaydet.Tag = pencere;
                    TEBLIGAT_MUHATAP();
                    break;

                case "KulTanimli_Yapilacak_Isler":
                    btnKaydet.Tag = pencere;
                    YAPILACA_IS();
                    break;

                case "KulTanimli_Gorusmeler":
                    btnKaydet.Tag = pencere;
                    GORUSMELER_GENEL_TARAFLI();
                    break;

                case "KulTanimli_Belgeler":
                    btnKaydet.Tag = pencere;
                    BELGELER_TARAFLI();
                    break;

                case "KulTanimli_Temsil":
                    btnKaydet.Tag = pencere;
                    TEMSIL_TARAFLI();
                    break;

                case "KulTanimli_Masraf_Avans":
                    btnKaydet.Tag = pencere;
                    MASRAF_AVANS_TARAFLI();
                    break;

                case "KulTanimli_Muhasebe_Tarafli":
                    btnKaydet.Tag = pencere;
                    MUHASEBE_TARAFLI();
                    break;

                case "KulTanimli_Mal_Satis_Tarafli_Sorumlulu":
                    btnKaydet.Tag = pencere;
                    MAL_SATIS_SURECI();
                    break;

                case "KulTanimli_Temyiz_Takip":
                    btnKaydet.Tag = pencere;
                    TEMYIZ_TAKIP_SORUMLU_TARAFLI();
                    break;

                case "KulTanimli_Kasa_Bilgileri":
                    btnKaydet.Tag = pencere;
                    KASA_BILGILERI_GENEL();
                    break;

                case "KulTanimli_Kiymetli_Evrak_Genel":
                    btnKaydet.Tag = pencere;
                    KIYMETLI_EVRAK_GENEL();
                    break;

                case "KulTanimli_Gayrimenkul_Genel":
                    btnKaydet.Tag = pencere;
                    GAYRIMENKUL_TARAFLI_GENEL();
                    break;

                case "KulTanimli_Gemi_Ucak_Arac_Genel":
                    btnKaydet.Tag = pencere;
                    GEMI_UCAK_ARAC_GENEL();
                    break;

                default:
                    break;
            }
        }

        public void RaporCagir(string pencere, string filePath)
        {
            try
            {
                RaporCagir(pencere);
                SaveReport sr = SaveReport.Oku(filePath);
                sr.Layout.Seek(0, SeekOrigin.Begin);

                gridRaporView.RestoreLayoutFromStream(sr.Layout);

                //initGridStyleCon(gridRaporView, sr.Ayarlar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static GridColumn colmnVer(string columnCaption, string columnFieldName, bool colmnVisible, int visibleIndex)
        {
            return colmnVer(columnCaption, columnFieldName, colmnVisible, visibleIndex, null);
        }

        private static GridColumn colmnVer(string columnCaption, string columnFieldName, bool colmnVisible, int visibleIndex, RepositoryItemLookUpEdit rlueLookUpEdit)
        {
            DevExpress.XtraGrid.Columns.GridColumn colFORM_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            colFORM_TIP_ID.Caption = columnCaption;
            colFORM_TIP_ID.ColumnEdit = rlueLookUpEdit;
            colFORM_TIP_ID.FieldName = columnFieldName;

            //colFORM_TIP_ID.Name = "colFORM_TIP_ID";
            colFORM_TIP_ID.Visible = colmnVisible;
            colFORM_TIP_ID.VisibleIndex = visibleIndex;
            return colFORM_TIP_ID;
        }

        private static GridColumn colmnVer(string columnCaption, string columnFieldName, bool colmnVisible, int visibleIndex, RepositoryItemLookUpEdit rlueLookUpEdit, GridColumn kardesKolon)
        {
            DevExpress.XtraGrid.Columns.GridColumn colFORM_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            colFORM_TIP_ID.Caption = columnCaption;
            colFORM_TIP_ID.ColumnEdit = rlueLookUpEdit;
            colFORM_TIP_ID.FieldName = columnFieldName;

            //colFORM_TIP_ID.Name = "colFORM_TIP_ID";
            colFORM_TIP_ID.Visible = colmnVisible;
            colFORM_TIP_ID.Tag = kardesKolon;
            colFORM_TIP_ID.VisibleIndex = visibleIndex;
            return colFORM_TIP_ID;
        }

        private static GridColumn colmnVer(string columnCaption, string columnFieldName, bool colmnVisible, int visibleIndex, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueLookUpEdit, GridColumn kardesKolon, string displayFormat)
        {
            DevExpress.XtraGrid.Columns.GridColumn colFORM_TIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            colFORM_TIP_ID.Caption = columnCaption;
            colFORM_TIP_ID.ColumnEdit = rlueLookUpEdit;
            colFORM_TIP_ID.FieldName = columnFieldName;

            //colFORM_TIP_ID.Name = "colFORM_TIP_ID";
            colFORM_TIP_ID.Visible = colmnVisible;
            colFORM_TIP_ID.Tag = kardesKolon;
            colFORM_TIP_ID.VisibleIndex = visibleIndex;
            colFORM_TIP_ID.DisplayFormat.FormatString = displayFormat;
            colFORM_TIP_ID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            return colFORM_TIP_ID;
        }

        private static void DebugWrite(string mesaj)
        {
            System.Diagnostics.Debug.WriteLine(mesaj + " " + DateTime.Now.ToLongTimeString());
        }

        private void btnFarkliKaydet_Click(object sender, EventArgs e)
        {
            List<GridMenuItem> sonuc = GridMenuItem.GetListForSaveList(sl);

            frmMain mainForm = (frmMain)this.MdiParent;
            mainForm.gridMenu.DataSource = sonuc;
        }

        private void btnGrublaraEkle_Click(object sender, EventArgs e)
        {
            try
            {
                GridColumn secilenKolon = lBoxSeciliAlanlar.SelectedItem as GridColumn;
                groupColon.Add(secilenKolon);
                if (secilenKolon != null) secilenKolon.Group();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ListeDoldur_Gruplananlar();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            frmKullaniciTanimliKaydet frm = new frmKullaniciTanimliKaydet();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string kayitAdi = frm.KayitAdi;
                string grupAdi = frm.GrupAdi;
                SaveReport.KayitGizlilik kayitTipi = frm.KayitTipi;
                FormuKaydet(kayitAdi, grupAdi, kayitTipi);
                MessageBox.Show("Kayıt İşlemi Gerçekleşti");
            }
        }

        private void btnSeciliAlanKaldir_Click(object sender, EventArgs e)
        {
            int secilenIndeex = lBoxSeciliAlanlar.SelectedIndex;
            GridColumn secilenKolon = lBoxSeciliAlanlar.SelectedItem as GridColumn;

            if (secilenKolon != null)
            {
                secilenKolon.Visible = false;
            }

            ListDoldur_Secilenler();
            ListeDoldur_TanimliAlanlar();

            lBoxSeciliAlanlar.SelectedIndex = secilenIndeex;
        }

        private void btnTanimliAlanSec_Click(object sender, EventArgs e)
        {
            int secilenKolon = lBoxTanimliAlanlar.SelectedIndex;
            DevExpress.XtraGrid.Columns.GridColumn kolon = lBoxTanimliAlanlar.SelectedItem as DevExpress.XtraGrid.Columns.GridColumn;

            if (kolon != null)
            {
                if (!kolon.Visible)
                {
                    kolon.Visible = true;
                    kolon.VisibleIndex = gridRaporView.Columns.OfType<GridColumn>().Where(vi => vi.Visible == true).Count() + 1;
                }
            }

            ListDoldur_Secilenler();
            ListeDoldur_TanimliAlanlar();

            lBoxTanimliAlanlar.SelectedIndex = secilenKolon;
        }

        private void chBoxSikKullanilan_CheckedChanged(object sender, EventArgs e)
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            gvMain.OptionsView.ShowGroupedColumns = chBoxSikKullanilan.Checked;
        }

        //    foreach (ParaVeDovizId id in paralar)
        //    {
        //        sonuclar[id.DovizId] += id.Para;
        //    }
        //    AdimAdimDavaKaydi.IcraTakipForms._frmIcraTakip.BosOlanAlanlariSil(sonuclar);
        //    if (sonuclar.Count == 1)
        //    {
        //        Dictionary<int, decimal>.Enumerator tor = sonuclar.GetEnumerator();
        //        tor.MoveNext();
        //        result.DovizId = tor.Current.Key;
        //        result.Para = tor.Current.Value;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.OptionsView.AllowCellMerge = checkBox1.Checked;
        }

        private void filterAlani_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            // int sonu = e.CurrentNode.;
            object sagDeger = ((CriteriaOperator)e.CurrentNode.ToCriteria());
            object ss = ((BinaryOperator)sagDeger).RightOperand;     //ToDo : burda hata patlatıyor..!
            if (ss.ToString() == "")
            {
            }

            //string sd = ((BinaryOperator)filterAlani.FilterCriteria).RightOperand.ToString();
            //string sagDeger2 = ((BinaryOperator)filterAlani.FilterCriteria).RightOperand.LegacyToString();
            //string sagdeger1 = ((BinaryOperator)filterAlani.FilterCriteria).RightOperand.IsNull().ToString();
            filterAlani.ApplyFilter();
        }

        private void FormuKaydet(string raporAdi, string grupAdi, SaveReport.KayitGizlilik kaydinTipi)
        {
            Stream st = new MemoryStream();
            foreach (BaseView view in gridRaporCntrol.ViewCollection)
            {
                if (view is GridView)
                {
                    view.SaveLayoutToStream(st, OptionsLayoutBase.FullLayout);
                    GridView gv = (GridView)view;
                    SaveReport sRapor = new SaveReport
                                            {
                                                Ayarlar = SaveReport.AyarAl(gv),
                                                CariID = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.Bilgi.CARI_ID.Value,
                                                Grup = grupAdi,
                                                Layout = st,
                                                KaydinTipi = kaydinTipi,
                                                RaporAdi = raporAdi
                                            };

                    if (btnKaydet.Tag != null)
                    {
                        GridMenuItem.AcilacakPencere aPencere = (GridMenuItem.AcilacakPencere)btnKaydet.Tag;
                        sRapor.AcilacakPencere = aPencere;
                    }

                    sRapor.Save();

                    SaveListItem sli = new SaveListItem(sRapor);

                    sl.Add(sli);
                    sl.BeforeSave += new SaveList.OnBeforeSave(sl_BeforeSave);
                    if (Saved != null)
                    {
                        this.Saved(this, sl, sl.Save());
                    }
                }
            }
        }

        private void frmKullaniciTanimli_Load(object sender, EventArgs e)
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            Control.CheckForIllegalCrossThreadCalls = false;

            gvMain.OptionsView.ShowGroupedColumns = chBoxSikKullanilan.Checked;
        }

        //void gridRaporCntrol_ColumnVisibleIndexChanged(ExtendedGridControl senderGrid, DevExpress.XtraGrid.Views.Base.BaseView senderView, GridControlEx.ViewType Viewstype, GridColumn sender, int index)
        //{
        //    if (sender.Tag != null)
        //    {
        //        if (sender.Tag is GridColumn)
        //        {
        //            GridColumn kardesi = sender.Tag as GridColumn;
        //            if (index == -1)
        //            {
        //                kardesi.VisibleIndex = -1;
        //            }
        //            else
        //            {
        //                kardesi.VisibleIndex = sender.VisibleIndex += 1;
        //            }
        //            var sonuc = gridRaporView.Columns.OfType<GridColumn>().Where(vi=>vi.GroupIndex != -1);

        //            gridRaporView.RefreshData();
        //        }
        //    }
        //    else
        //    {
        //        var sonuclar = gridRaporView.Columns.OfType<GridColumn>().Where(vi => vi.Tag == sender);

        //        if (sonuclar.Dolumu())
        //        {
        //            GridColumn sonuc = sonuclar.First();
        //            sonuc.VisibleIndex = sender.VisibleIndex -= 1;
        //            gridRaporView.RefreshData();
        //        }
        //    }

        //    var kolonlar = gridRaporView.Columns.OfType<GridColumn>().Where(vi=>vi.Tag != null);

        //    foreach (GridColumn kolon in kolonlar)
        //    {
        //        if (kolon.Tag != null)
        //        {
        //            if (kolon.Tag is GridColumn)
        //            {
        //                GridColumn kardesKolon = kolon.Tag as GridColumn;
        //                if (kolon.VisibleIndex == -1)
        //                {
        //                    kardesKolon.VisibleIndex = -1;

        //                }
        //                else if (kardesKolon.VisibleIndex != kolon.VisibleIndex - 1)
        //                {
        //                    kardesKolon.VisibleIndex = kolon.VisibleIndex += 1;
        //                }
        //            }
        //        }
        //    }
        //    gridRaporView.RefreshData();
        //}

        #region Colonları Listele

        private void ListDoldur_Secilenler()
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            var sonuc = gvMain.Columns.OfType<GridColumn>().Where(vi => vi.Visible == true && !vi.Caption.EndsWith("BRM")).OrderBy(vi => vi.VisibleIndex);
            lBoxSeciliAlanlar.DataSource = sonuc.ToArray();
            lBoxSeciliAlanlar.DisplayMember = "Caption";
        }

        private void ListeDoldur_Gruplananlar()
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            var secilen = lBoxGruplariSirala.SelectedItem as GridColumn;
            var sonuc = gvMain.GroupedColumns.OfType<GridColumn>().OrderBy(vi => vi.GroupIndex);

            lBoxGruplariSirala.DataSource = sonuc.ToArray();
            lBoxGruplariSirala.DisplayMember = "Caption";

            lBoxGruplariSirala.SelectedItem = secilen;
        }

        private void ListeDoldur_TanimliAlanlar()
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            var sonuc = gvMain.Columns.OfType<GridColumn>().Where(vi => vi.Visible == false && !vi.Caption.EndsWith("BRM"));

            lBoxTanimliAlanlar.DataSource = sonuc.ToArray();
            lBoxTanimliAlanlar.DisplayMember = "Caption";
        }

        #endregion Colonları Listele

        private void gridRaporView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //if (bwLayout.IsBusy)
            //{
            //    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //    {
            //        e.TotalValue = "<N>";
            //    }
            //    return;
            //}
            DateTime basladi = DateTime.Now;

            if (e.Item != null && e.Item is DevExpress.XtraGrid.GridSummaryItem && (e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag is int)
            {
                //SummaryID yi alıyoruz
                int summaryID = Convert.ToInt32((e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag);
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view == null)
                    return;

                // Başlangıç
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    switch (summaryID)
                    {
                        case 1:

                            //odemeToplamlar.Clear();
                            break;

                        case 2:
                            dovizler.Clear();
                            break;
                    }
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    //AV001_TI_BIL_HESAPLI_KAPSAMLI_GENEL odeme = view.GetRow(e.RowHandle) as AV001_TI_BIL_HESAPLI_KAPSAMLI_GENEL;

                    int? dovizId = null;
                    GridColumn fc = view.Columns["sxscfd"];
                    switch (summaryID)
                    {
                        case 1: // YTL Cinsinden Cevirip toplanılan yer
                            if (true)

                                //odeme.ODEME_TARIHI = DateTime.Today;

                                dovizId = (int?)view.GetRowCellValue(e.RowHandle, ((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName + "_DOVIZ_ID");
                            if (dovizId != null)
                            {
                                if (e.FieldValue != null)
                                {
                                    //odemeToplamlar.Add(new ParaVeDovizId((decimal)e.FieldValue, dovizId, DateTime.Today));
                                }
                            }
                            break;

                        case 2:
                            if (!dovizler.Contains((int?)e.FieldValue))
                                dovizler.Add((int?)e.FieldValue);
                            break;
                    }
                }

                // Sonuç yazdırma
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    switch (summaryID)
                    {
                        case 1:

                            //ParaVeDovizId pDId = ParaVeDovizId.Topla(odemeToplamlar);
                            //ParaVeDovizId pDId =Toplaa(odemeToplamlar);  //ParaVeDovizId.Topla(odemeToplamlar);
                            //e.TotalValue = pDId.Para;
                            break;

                        case 2:
                            if (dovizler.Count > 1)
                            {
                                //e.TotalValue = DovizHelper.CevirString(1);//YTL
                            }
                            else if (dovizler.Count == 1)
                            {
                                if (dovizler[0].HasValue)
                                {
                                    // e.TotalValue = DovizHelper.CevirString(dovizler[0].Value);
                                }
                                else
                                {
                                    e.TotalValue = string.Empty;
                                }
                            }

                            break;
                    }
                }
            }
        }

        private void gridRaporView_EndGrouping(object sender, EventArgs e)
        {
            ListeDoldur_Gruplananlar();
            ListDoldur_Secilenler();
            ListeDoldur_TanimliAlanlar();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            GridColumn secilenKolon = lBoxGruplariSirala.SelectedItem as GridColumn;
            GridView gvMain = (GridView)gridRaporCntrol.MainView;
            if (secilenKolon != null)
                if (secilenKolon.GroupIndex < gvMain.GroupCount)
                {
                    int gelecekSira = lBoxGruplariSirala.SelectedIndex + 1;

                    var kolonlar = gvMain.GroupedColumns.OfType<GridColumn>().Where(vi => vi.GroupIndex == gelecekSira);
                    if (kolonlar.Dolumu())
                    {
                        GridColumn kolon = kolonlar.First();
                        kolon.GroupIndex = kolon.GroupIndex - 1;
                    }
                }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            GridColumn secilenKolon = lBoxGruplariSirala.SelectedItem as GridColumn;
            if (secilenKolon != null)
            {
                secilenKolon.UnGroup();
            }
            ListeDoldur_Gruplananlar();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            GridColumn secilenKolon = lBoxGruplariSirala.SelectedItem as GridColumn;

            if (secilenKolon != null)
            {
                if (secilenKolon.GroupIndex > 0)
                {
                    secilenKolon.GroupIndex = lBoxGruplariSirala.SelectedIndex - 1;
                }
            }
            else
            {
                //Utils.Tools.Logla(
            }
        }

        #region Tablolar

        private RepositoryItemLookUpEdit lupDoviz = TablesGrids.GetTDI_KOD_DOVIZ_TIPLookup();// lookUpVer("Birim", "ID", "DOVIZ_KODU", db.TDI_KOD_DOVIZ_TIPs);

        private void Ayarla_Isimleri()
        {
            var grid = (GridView)gridRaporCntrol.MainView;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].Caption.EndsWith("ID"))
                {
                    grid.Columns[i].Caption = grid.Columns[i].Caption.Replace(" ID", "");
                }
            }
        }

        private void BELGELER_TARAFLI()
        {
            var colmBELGE_REFERANS_NO = colmnVer("BELGE REFERANS NO", "BELGE_REFERANS_NO", true, 1, null);
            var colmBELGE_TUR_ID = colmnVer("BELGE TUR ID", "BELGE_TUR_ID", true, 2, TablesGrids.GetTDIE_KOD_BELGE_TURLookup());
            var colmBELGE_ADI = colmnVer("BELGE ADI", "BELGE_ADI", true, 3, null);
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 4, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 5, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 6, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 7, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmDOSYA_ADI = colmnVer("DOSYA ADI", "DOSYA_ADI", true, 8, null);
            var colmYAZILMA_TARIHI = colmnVer("YAZILMA TARIHI", "YAZILMA_TARIHI", true, 9, null);
            var colmBELGEYI_YAZAN_ID = colmnVer("BELGEYI YAZAN ID", "BELGEYI_YAZAN_ID", true, 10, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmDAVA_TAKIP_KONU = colmnVer("DAVA TAKIP KONU", "DAVA_TAKIP_KONU", true, 11, null);
            var colmSUC_OLAY_VADE_TARIHI = colmnVer("SUC OLAY VADE TARIHI", "SUC_OLAY_VADE_TARIHI", true, 12, null);
            var colmOZEL_KOD_1_ID = colmnVer("OZEL KOD 1 ID", "OZEL_KOD_1_ID", true, 13, TablesGrids.GetAV001_TDI_KOD_BELGE_OZEL_KODLookup());
            var colmOZEL_KOD_2_ID = colmnVer("OZEL KOD 2 ID", "OZEL_KOD_2_ID", true, 14, TablesGrids.GetAV001_TDI_KOD_BELGE_OZEL_KODLookup());
            var colmOZEL_KOD_3_ID = colmnVer("OZEL KOD 3 ID", "OZEL_KOD_3_ID", true, 15, TablesGrids.GetAV001_TDI_KOD_BELGE_OZEL_KODLookup());
            var colmOZEL_KOD_4_ID = colmnVer("OZEL KOD 4 ID", "OZEL_KOD_4_ID", true, 16, TablesGrids.GetAV001_TDI_KOD_BELGE_OZEL_KODLookup());
            var colmDOKUMAN_UZANTI = colmnVer("DOKUMAN UZANTI", "DOKUMAN_UZANTI", true, 17, null);
            var colmBELGE_NO = colmnVer("BELGE NO", "BELGE_NO", true, 18, null);
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 19, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 20, null);
            var colmKODU = colmnVer("KODU", "KODU", true, 21, null);
            var colmSIFAT_ID = colmnVer("SIFAT ID", "SIFAT_ID", true, 22, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 23, TablesGrids.GetAV001_TDI_BIL_CARILookup());

            GridView grid = gridRaporCntrol.MainView as GridView;
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            grid.Columns.AddRange(new[] { colmBELGE_REFERANS_NO, colmBELGE_TUR_ID, colmBELGE_ADI, colmESAS_NO, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmDOSYA_ADI, colmYAZILMA_TARIHI, colmBELGEYI_YAZAN_ID, colmDAVA_TAKIP_KONU, colmSUC_OLAY_VADE_TARIHI, colmOZEL_KOD_1_ID, colmOZEL_KOD_2_ID, colmOZEL_KOD_3_ID, colmOZEL_KOD_4_ID, colmDOKUMAN_UZANTI, colmBELGE_NO, colmASAMA_ID, colmKAYIT_TARIHI, colmKODU, colmSIFAT_ID, colmCARI_ID });

            gridRaporCntrol.DataSource = db.BELGELER_TARAFLIs;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void GAYRIMENKUL_TARAFLI_GENEL()
        {
            var colmTARIHI = colmnVer("TARIHI", "TARIHI", true, 1, null);
            var colmIL_ID = colmnVer("IL ID", "IL_ID", true, 2, TablesGrids.GetTDI_KOD_ILLookup());
            var colmILCE_ID = colmnVer("ILCE ID", "ILCE_ID", true, 3, TablesGrids.GetTDI_KOD_ILCELookup());
            var colmBUCAK = colmnVer("BUCAK", "BUCAK", true, 4, null);
            var colmMAHALLE_ADI = colmnVer("MAHALLE ADI", "MAHALLE_ADI", true, 5, null);
            var colmKOY_ADI = colmnVer("KOY ADI", "KOY_ADI", true, 6, null);
            var colmSOKAK_ADI = colmnVer("SOKAK ADI", "SOKAK_ADI", true, 7, null);
            var colmMEVKI_ADI = colmnVer("MEVKI ADI", "MEVKI_ADI", true, 8, null);
            var colmPAFTA_NO = colmnVer("PAFTA NO", "PAFTA_NO", true, 9, null);
            var colmADA_NO = colmnVer("ADA NO", "ADA_NO", true, 10, null);
            var colmPARSEL_NO = colmnVer("PARSEL NO", "PARSEL_NO", true, 11, null);
            var colmYEVMIYE_NO = colmnVer("YEVMIYE NO", "YEVMIYE_NO", true, 12, null);
            var colmCILT_NO = colmnVer("CILT NO", "CILT_NO", true, 13, null);
            var colmSAHIFE_NO = colmnVer("SAHIFE NO", "SAHIFE_NO", true, 14, null);
            var colmSIRA_NO = colmnVer("SIRA NO", "SIRA_NO", true, 15, null);
            var colmYUZOLCUMU_HEKTAR = colmnVer("YUZOLCUMU HEKTAR", "YUZOLCUMU_HEKTAR", true, 16, null);
            var colmYUZOLCUMU_DEKAR = colmnVer("YUZOLCUMU DEKAR", "YUZOLCUMU_DEKAR", true, 17, null);
            var colmYUZOLCUMU_DM2 = colmnVer("YUZOLCUMU DM2", "YUZOLCUMU_DM2", true, 18, null);
            var colmNITELIGI = colmnVer("NITELIGI", "NITELIGI", true, 19, null);
            var colmARSA_PAYI = colmnVer("ARSA PAYI", "ARSA_PAYI", true, 20, null);
            var colmKAT_NO = colmnVer("KAT NO", "KAT_NO", true, 21, null);
            var colmBAGIMSIZ_BOLUM_NO = colmnVer("BAGIMSIZ BOLUM NO", "BAGIMSIZ_BOLUM_NO", true, 22, null);
            var colmSINIRI = colmnVer("SINIRI", "SINIRI", true, 23, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 24, null);
            var colmKLASOR_KODU = colmnVer("KLASOR KODU", "KLASOR_KODU", true, 25, null);
            var colmSUBE_KODU = colmnVer("SUBE KODU", "SUBE_KODU", true, 26, null);
            var colmKONTROL_NE_ZAMAN = colmnVer("KONTROL NE ZAMAN", "KONTROL_NE_ZAMAN", true, 27, null);
            var colmKONTROL_VERSIYON = colmnVer("KONTROL VERSIYON", "KONTROL_VERSIYON", true, 28, null);
            var colmKONTROL_KIM = colmnVer("KONTROL KIM", "KONTROL_KIM", true, 29, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 30, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 31, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 32, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 33, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 34, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 35, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 36, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 37, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 38, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 39, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 40, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 41, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 42, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 43, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 44, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 45, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 46, null);
            var colmTipi = colmnVer("Tipi", "Tipi", true, 47, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[]
                                      {
                                          colmTARIHI, colmIL_ID, colmILCE_ID, colmBUCAK, colmMAHALLE_ADI, colmKOY_ADI,
                                          colmSOKAK_ADI, colmMEVKI_ADI, colmPAFTA_NO, colmADA_NO, colmPARSEL_NO,
                                          colmYEVMIYE_NO, colmCILT_NO, colmSAHIFE_NO, colmSIRA_NO, colmYUZOLCUMU_HEKTAR,
                                          colmYUZOLCUMU_DEKAR, colmYUZOLCUMU_DM2, colmNITELIGI, colmARSA_PAYI, colmKAT_NO,
                                          colmBAGIMSIZ_BOLUM_NO, colmSINIRI, colmKAYIT_TARIHI, colmKLASOR_KODU,
                                          colmSUBE_KODU, colmKONTROL_NE_ZAMAN, colmKONTROL_VERSIYON, colmKONTROL_KIM,
                                          colmTARAF_CARI_ID, colmTARAF_SIFAT_ID, colmFOY_NO, colmADLI_BIRIM_ADLIYE_ID,
                                          colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T,
                                          colmREFERANS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmOZEL_KOD1, colmOZEL_KOD2
                                          , colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP, colmTipi
                                      });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.GAYRIMENKUL_TARAFLI_BIRLESIKs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();

            //
        }

        private void GEMI_UCAK_ARAC_GENEL()
        {
            var colmGEMI_UCAK_ARAC_TIP = colmnVer("GEMI UCAK ARAC TIP", "GEMI_UCAK_ARAC_TIP", true, 1, TablesGrids.GetTDI_KOD_ARAC_TIPLookup());
            var colmADI = colmnVer("ADI", "ADI", true, 2, null);
            var colmCINSI = colmnVer("CINSI", "CINSI", true, 3, null);
            var colmTESCIL_NUMARASI = colmnVer("TESCIL NUMARASI", "TESCIL_NUMARASI", true, 4, null);
            var colmTANIMA_ISARETI = colmnVer("TANIMA ISARETI", "TANIMA_ISARETI", true, 5, null);
            var colmINSA_YILI = colmnVer("INSA YILI", "INSA_YILI", true, 6, null);
            var colmINSA_YERI = colmnVer("INSA YERI", "INSA_YERI", true, 7, null);
            var colmBOYU = colmnVer("BOYU", "BOYU", true, 8, null);
            var colmENI = colmnVer("ENI", "ENI", true, 9, null);
            var colmTONALITOSU = colmnVer("TONALITOSU", "TONALITOSU", true, 10, null);
            var colmBAGLAMA_LIMANI = colmnVer("BAGLAMA LIMANI", "BAGLAMA_LIMANI", true, 11, null);
            var colmTEKNIK_KUTUK_NO = colmnVer("TEKNIK KUTUK NO", "TEKNIK_KUTUK_NO", true, 12, null);
            var colmERISIM_NO = colmnVer("ERISIM NO", "ERISIM_NO", true, 13, null);
            var colmTIPI = colmnVer("TIPI", "TIPI", true, 14, null);
            var colmDERINLIGI = colmnVer("DERINLIGI", "DERINLIGI", true, 15, null);
            var colmKUTUK_BOYU = colmnVer("KUTUK BOYU", "KUTUK_BOYU", true, 16, null);
            var colmARAC_PLAKA = colmnVer("ARAC PLAKA", "ARAC_PLAKA", true, 17, null);
            var colmARAC_MODEL = colmnVer("ARAC MODEL", "ARAC_MODEL", true, 18, null);
            var colmARAC_TIP = colmnVer("ARAC TIP", "ARAC_TIP", true, 19, null);
            var colmARAC_MOTOR_NO = colmnVer("ARAC MOTOR NO", "ARAC_MOTOR_NO", true, 20, null);
            var colmARAC_SASI_NO = colmnVer("ARAC SASI NO", "ARAC_SASI_NO", true, 21, null);
            var colmARAC_RENK = colmnVer("ARAC RENK", "ARAC_RENK", true, 22, null);
            var colmTRAFIK_SUBESI = colmnVer("TRAFIK SUBESI", "TRAFIK_SUBESI", true, 23, null);
            var colmRUHSAT_TARIHI = colmnVer("RUHSAT TARIHI", "RUHSAT_TARIHI", true, 24, null);
            var colmRUHSAT_SICIL_NO = colmnVer("RUHSAT SICIL NO", "RUHSAT_SICIL_NO", true, 25, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 26, null);
            var colmKLASOR_KODU = colmnVer("KLASOR KODU", "KLASOR_KODU", true, 27, null);
            var colmSUBE_KODU = colmnVer("SUBE KODU", "SUBE_KODU", true, 28, null);
            var colmADMIN_KAYIT_MI = colmnVer("ADMIN KAYIT MI", "ADMIN_KAYIT_MI", true, 29, null);
            var colmKONTROL_NE_ZAMAN = colmnVer("KONTROL NE ZAMAN", "KONTROL_NE_ZAMAN", true, 30, null);
            var colmKONTROL_KIM = colmnVer("KONTROL KIM", "KONTROL_KIM", true, 31, null);
            var colmKONTROL_VERSIYON = colmnVer("KONTROL VERSIYON", "KONTROL_VERSIYON", true, 32, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 33, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 34, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 35, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 36, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 37, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 38, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 39, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 40, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 41, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 42, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 43, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 44, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 45, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 46, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 47, null);
            var colmTip = colmnVer("Tip", "Tip", true, 48, null);

            GridView grid = gridRaporCntrol.MainView as GridView;
            grid.Columns.AddRange(new[]
                                      {
                                          colmGEMI_UCAK_ARAC_TIP, colmADI, colmCINSI, colmTESCIL_NUMARASI,
                                          colmTANIMA_ISARETI, colmINSA_YILI, colmINSA_YERI, colmBOYU, colmENI,
                                          colmTONALITOSU, colmBAGLAMA_LIMANI, colmTEKNIK_KUTUK_NO, colmERISIM_NO, colmTIPI,
                                          colmDERINLIGI, colmKUTUK_BOYU, colmARAC_PLAKA, colmARAC_MODEL, colmARAC_TIP,
                                          colmARAC_MOTOR_NO, colmARAC_SASI_NO, colmARAC_RENK, colmTRAFIK_SUBESI,
                                          colmRUHSAT_TARIHI, colmRUHSAT_SICIL_NO, colmKAYIT_TARIHI, colmKLASOR_KODU,
                                          colmSUBE_KODU, colmADMIN_KAYIT_MI, colmKONTROL_NE_ZAMAN, colmKONTROL_KIM,
                                          colmKONTROL_VERSIYON, colmFOY_NO, colmADLI_BIRIM_ADLIYE_ID,
                                          colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T,
                                          colmREFERANS_NO2, colmREFERANS_NO3, colmREFERANS_NO, colmOZEL_KOD1, colmOZEL_KOD2
                                          , colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP, colmTip
                                      });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.GEMI_UCAK_ARAC_BIRLESIKs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void GenelTablo()
        {
            GridView gvMain = (GridView)gridRaporCntrol.MainView;

            System.Diagnostics.Debug.WriteLine("Kolonlar Oluşturuluyor " + DateTime.Now.ToLongTimeString());

            #region Column & Summary

            var colmFOY_ID = colmnVer("FOY ID", "FOY_ID", true, 1, null);
            var colmFORM_ADI = colmnVer("FORM ADI", "FORM_ADI", true, 2, null);
            var colmDURUM = colmnVer("DURUM", "DURUM", true, 3, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 4, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 5, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 6, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 7, null);
            var colmNO = colmnVer("NO", "NO", true, 8, null);
            var colmADLIYE = colmnVer("ADLIYE", "ADLIYE", true, 9, null);
            var colmICRA_OZEL_KOD1_ID = colmnVer("ICRA OZEL KOD1 ID", "ICRA_OZEL_KOD1_ID", true, 10, null);
            var colmICRA_OZEL_KOD2_ID = colmnVer("ICRA OZEL KOD2 ID", "ICRA_OZEL_KOD2_ID", true, 11, null);
            var colmICRA_OZEL_KOD3_ID = colmnVer("ICRA OZEL KOD3 ID", "ICRA_OZEL_KOD3_ID", true, 12, null);
            var colmICRA_OZEL_KOD4_ID = colmnVer("ICRA OZEL KOD4 ID", "ICRA_OZEL_KOD4_ID", true, 13, null);
            var colmTAKIBIN_AVUKATA_INTIKAL_TARIHI = colmnVer("TAKIBIN AVUKATA INTIKAL TARIHI", "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true, 14, null);
            var colmFOY_ARSIV_TARIHI = colmnVer("FOY ARSIV TARIHI", "FOY_ARSIV_TARIHI", true, 15, null);
            var colmFOY_INFAZ_TARIHI = colmnVer("FOY INFAZ TARIHI", "FOY_INFAZ_TARIHI", true, 16, null);
            var colmTAKIBIN_MUVEKKILE_IADE_TARIHI = colmnVer("TAKIBIN MUVEKKILE IADE TARIHI", "TAKIBIN_MUVEKKILE_IADE_TARIHI", true, 17, null);
            var colmSON_HESAP_TARIHI = colmnVer("SON HESAP TARIHI", "SON_HESAP_TARIHI", true, 18, null);
            var colmBIR_YIL_KAC_GUN = colmnVer("BIR YIL KAC GUN", "BIR_YIL_KAC_GUN", true, 19, null);

            var colmASIL_ALACAK_DOVIZ_ID = colmnVer("ASIL ALACAK DOVIZ ID", "ASIL_ALACAK_DOVIZ_ID", true, 20, lupDoviz);
            var colmASIL_ALACAK = colmnVer("ASIL ALACAK", "ASIL_ALACAK", true, 21, null, colmASIL_ALACAK_DOVIZ_ID, "###,###,###,###,##0.00");//
            var summaryASIL_ALACAK = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK", colmASIL_ALACAK, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            var summaryASIL_ALACAK_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK_DOVIZ_ID", colmASIL_ALACAK_DOVIZ_ID, "", 2);
            System.Diagnostics.Debug.WriteLine(2);

            var colmISLEMIS_FAIZ_DOVIZ_ID = colmnVer("ISLEMIS FAIZ DOVIZ ID", "ISLEMIS_FAIZ_DOVIZ_ID", true, 22, lupDoviz);
            var colmISLEMIS_FAIZ = colmnVer("ISLEMIS FAIZ", "ISLEMIS_FAIZ", true, 23, null, colmISLEMIS_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");//
            var summaryISLEMIS_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ_DOVIZ_ID", colmISLEMIS_FAIZ_DOVIZ_ID, "", 2);
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;
            System.Diagnostics.Debug.WriteLine(3);

            var summaryISLEMIS_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ", colmISLEMIS_FAIZ, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryISLEMIS_FAIZ, summaryISLEMIS_FAIZ_DOVIZ_ID });
            colmISLEMIS_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmISLEMIS_FAIZ.SummaryItem.FieldName = "ISLEMIS_FAIZ";
            colmISLEMIS_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ.SummaryItem.Tag = 1;

            var colmBSMV_TO_DOVIZ_ID = colmnVer("BSMV TO DOVIZ ID", "BSMV_TO_DOVIZ_ID", true, 24, lupDoviz);
            var colmBSMV_TO = colmnVer("BSMV TO", "BSMV_TO", true, 25, null, colmBSMV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBSMV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO_DOVIZ_ID", colmBSMV_TO_DOVIZ_ID, "", 2);
            colmBSMV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TO_DOVIZ_ID";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryBSMV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO", colmBSMV_TO, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryBSMV_TO, summaryBSMV_TO_DOVIZ_ID });
            colmBSMV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TO.SummaryItem.FieldName = "BSMV_TO";
            colmBSMV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO.SummaryItem.Tag = 1;
            System.Diagnostics.Debug.WriteLine(4);

            var colmKKDV_TO_DOVIZ_ID = colmnVer("KKDV TO DOVIZ ID", "KKDV_TO_DOVIZ_ID", true, 26, lupDoviz);
            var colmKKDV_TO = colmnVer("KKDV TO", "KKDV_TO", true, 27, null, colmKKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO_DOVIZ_ID", colmKKDV_TO_DOVIZ_ID, "", 2);
            colmKKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KKDV_TO_DOVIZ_ID";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO", colmKKDV_TO, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKKDV_TO, summaryKKDV_TO_DOVIZ_ID });
            colmKKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKKDV_TO.SummaryItem.FieldName = "KKDV_TO";
            colmKKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO.SummaryItem.Tag = 1;
            System.Diagnostics.Debug.WriteLine(5);

            var colmOIV_TO_DOVIZ_ID = colmnVer("OIV TO DOVIZ ID", "OIV_TO_DOVIZ_ID", true, 51, lupDoviz);
            var colmOIV_TO = colmnVer("OIV TO", "OIV_TO", true, 28, null, colmOIV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOIV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO_DOVIZ_ID", colmOIV_TO_DOVIZ_ID, "", 2);
            colmOIV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TO_DOVIZ_ID.SummaryItem.FieldName = "OIV_TO_DOVIZ_ID";
            colmOIV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOIV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO", colmOIV_TO, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOIV_TO, summaryOIV_TO_DOVIZ_ID });
            colmOIV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TO.SummaryItem.FieldName = "OIV_TO";
            colmOIV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO.SummaryItem.Tag = 1;

            var colmKDV_TO_DOVIZ_ID = colmnVer("KDV TO DOVIZ ID", "KDV_TO_DOVIZ_ID", true, 29, lupDoviz);
            var colmKDV_TO = colmnVer("KDV TO", "KDV_TO", true, 30, null, colmKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO_DOVIZ_ID", colmKDV_TO_DOVIZ_ID, "", 2);
            colmKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KDV_TO_DOVIZ_ID";
            colmKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO", colmKDV_TO, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKDV_TO, summaryKDV_TO_DOVIZ_ID });
            colmKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TO.SummaryItem.FieldName = "KDV_TO";
            colmKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO.SummaryItem.Tag = 1;
            System.Diagnostics.Debug.WriteLine(6);

            var colmIH_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IH VEKALET UCRETI DOVIZ ID", "IH_VEKALET_UCRETI_DOVIZ_ID", true, 31, lupDoviz);
            var colmIH_VEKALET_UCRETI = colmnVer("IH VEKALET UCRETI", "IH_VEKALET_UCRETI", true, 32, null, colmIH_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI_DOVIZ_ID", colmIH_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIH_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI", colmIH_VEKALET_UCRETI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIH_VEKALET_UCRETI, summaryIH_VEKALET_UCRETI_DOVIZ_ID });
            colmIH_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_VEKALET_UCRETI.SummaryItem.FieldName = "IH_VEKALET_UCRETI";
            colmIH_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIH_GIDERI_DOVIZ_ID = colmnVer("IH GIDERI DOVIZ ID", "IH_GIDERI_DOVIZ_ID", true, 33, lupDoviz);
            var colmIH_GIDERI = colmnVer("IH GIDERI", "IH_GIDERI", true, 34, null, colmIH_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI_DOVIZ_ID", colmIH_GIDERI_DOVIZ_ID, "", 2);
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IH_GIDERI_DOVIZ_ID";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIH_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI", colmIH_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIH_GIDERI, summaryIH_GIDERI_DOVIZ_ID });
            colmIH_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_GIDERI.SummaryItem.FieldName = "IH_GIDERI";
            colmIH_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI.SummaryItem.Tag = 1;

            var colmIT_HACIZDE_ODENEN_DOVIZ_ID = colmnVer("IT HACIZDE ODENEN DOVIZ ID", "IT_HACIZDE_ODENEN_DOVIZ_ID", true, 35, lupDoviz);
            var colmIT_HACIZDE_ODENEN = colmnVer("IT HACIZDE ODENEN", "IT_HACIZDE_ODENEN", true, 36, null, colmIT_HACIZDE_ODENEN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_HACIZDE_ODENEN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN_DOVIZ_ID", colmIT_HACIZDE_ODENEN_DOVIZ_ID, "", 2);
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIT_HACIZDE_ODENEN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN", colmIT_HACIZDE_ODENEN, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIT_HACIZDE_ODENEN, summaryIT_HACIZDE_ODENEN_DOVIZ_ID });
            colmIT_HACIZDE_ODENEN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_HACIZDE_ODENEN.SummaryItem.FieldName = "IT_HACIZDE_ODENEN";
            colmIT_HACIZDE_ODENEN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN.SummaryItem.Tag = 1;

            var colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = colmnVer("KARSILIKSIZ CEK TAZMINATI DOVIZ ID", "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", true, 37, lupDoviz);
            var colmKARSILIKSIZ_CEK_TAZMINATI = colmnVer("KARSILIKSIZ CEK TAZMINATI", "KARSILIKSIZ_CEK_TAZMINATI", true, 38, null, colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "", 2);
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKARSILIKSIZ_CEK_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI", colmKARSILIKSIZ_CEK_TAZMINATI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKARSILIKSIZ_CEK_TAZMINATI, summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID });
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.FieldName = "KARSILIKSIZ CEK TAZMINATI";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.Tag = 1;

            var colmCEK_KOMISYONU_DOVIZ_ID = colmnVer("CEK KOMISYONU DOVIZ ID", "CEK_KOMISYONU_DOVIZ_ID", true, 39, lupDoviz);
            var colmCEK_KOMISYONU = colmnVer("CEK KOMISYONU", "CEK_KOMISYONU", true, 40, null, colmCEK_KOMISYONU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryCEK_KOMISYONU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU_DOVIZ_ID", colmCEK_KOMISYONU_DOVIZ_ID, "", 2);
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryCEK_KOMISYONU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU", colmCEK_KOMISYONU, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryCEK_KOMISYONU, summaryCEK_KOMISYONU_DOVIZ_ID });
            colmCEK_KOMISYONU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmCEK_KOMISYONU.SummaryItem.FieldName = "CEK_KOMISYONU";
            colmCEK_KOMISYONU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU.SummaryItem.Tag = 1;

            var colmILAM_YARGILAMA_GIDERI_DOVIZ_ID = colmnVer("ILAM YARGILAMA GIDERI DOVIZ ID", "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", true, 41, lupDoviz);
            var colmILAM_YARGILAMA_GIDERI = colmnVer("ILAM YARGILAMA GIDERI", "ILAM_YARGILAMA_GIDERI", true, 42, null, colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILAM_YARGILAMA_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI", colmILAM_YARGILAMA_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_YARGILAMA_GIDERI, summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID });
            colmILAM_YARGILAMA_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_BK_YARG_ONAMA_DOVIZ_ID = colmnVer("ILAM BK YARG ONAMA DOVIZ ID", "ILAM_BK_YARG_ONAMA_DOVIZ_ID", true, 43, lupDoviz);
            var colmILAM_BK_YARG_ONAMA = colmnVer("ILAM BK YARG ONAMA", "ILAM_BK_YARG_ONAMA", true, 44, null, colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_BK_YARG_ONAMA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA_DOVIZ_ID", colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "", 2);
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILAM_BK_YARG_ONAMA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA", colmILAM_BK_YARG_ONAMA, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_BK_YARG_ONAMA, summaryILAM_BK_YARG_ONAMA_DOVIZ_ID });
            colmILAM_BK_YARG_ONAMA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_BK_YARG_ONAMA.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA";
            colmILAM_BK_YARG_ONAMA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA.SummaryItem.Tag = 1;

            var colmILAM_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("ILAM TEBLIG GIDERI DOVIZ ID", "ILAM_TEBLIG_GIDERI_DOVIZ_ID", true, 45, lupDoviz);
            var colmILAM_TEBLIG_GIDERI = colmnVer("ILAM TEBLIG GIDERI", "ILAM_TEBLIG_GIDERI", true, 46, null, colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI_DOVIZ_ID", colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILAM_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI", colmILAM_TEBLIG_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_TEBLIG_GIDERI, summaryILAM_TEBLIG_GIDERI_DOVIZ_ID });
            colmILAM_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_TEBLIG_GIDERI.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI";
            colmILAM_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ILAM INKAR TAZMINATI DOVIZ ID", "ILAM_INKAR_TAZMINATI_DOVIZ_ID", true, 47, lupDoviz);
            var colmILAM_INKAR_TAZMINATI = colmnVer("ILAM INKAR TAZMINATI", "ILAM_INKAR_TAZMINATI", true, 48, null, colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI_DOVIZ_ID", colmILAM_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILAM_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI", colmILAM_INKAR_TAZMINATI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_INKAR_TAZMINATI, summaryILAM_INKAR_TAZMINATI_DOVIZ_ID });
            colmILAM_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_INKAR_TAZMINATI.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI";
            colmILAM_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmILAM_VEK_UCR_DOVIZ_ID = colmnVer("ILAM VEK UCR DOVIZ ID", "ILAM_VEK_UCR_DOVIZ_ID", true, 49, lupDoviz);
            var colmILAM_VEK_UCR = colmnVer("ILAM VEK UCR", "ILAM_VEK_UCR", true, 50, null, colmILAM_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR_DOVIZ_ID", colmILAM_VEK_UCR_DOVIZ_ID, "", 2);
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;
            System.Diagnostics.Debug.WriteLine(7);

            var summaryILAM_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR", colmILAM_VEK_UCR, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_VEK_UCR, summaryILAM_VEK_UCR_DOVIZ_ID });
            colmILAM_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_VEK_UCR.SummaryItem.FieldName = "ILAM_VEK_UCR";
            colmILAM_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR.SummaryItem.Tag = 1;

            var colmPROTESTO_GIDERI_DOVIZ_ID = colmnVer("PROTESTO GIDERI DOVIZ ID", "PROTESTO_GIDERI_DOVIZ_ID", true, 52, lupDoviz);
            var colmPROTESTO_GIDERI = colmnVer("PROTESTO GIDERI", "PROTESTO_GIDERI", true, 53, null, colmPROTESTO_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTESTO_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI_DOVIZ_ID", colmPROTESTO_GIDERI_DOVIZ_ID, "", 2);
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryPROTESTO_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI", colmPROTESTO_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryPROTESTO_GIDERI, summaryPROTESTO_GIDERI_DOVIZ_ID });
            colmPROTESTO_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTESTO_GIDERI.SummaryItem.FieldName = "PROTESTO_GIDERI";
            colmPROTESTO_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI.SummaryItem.Tag = 1;

            var colmIHTAR_GIDERI_DOVIZ_ID = colmnVer("IHTAR GIDERI DOVIZ ID", "IHTAR_GIDERI_DOVIZ_ID", true, 54, lupDoviz);
            var colmIHTAR_GIDERI = colmnVer("IHTAR GIDERI", "IHTAR_GIDERI", true, 55, null, colmIHTAR_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIHTAR_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI_DOVIZ_ID", colmIHTAR_GIDERI_DOVIZ_ID, "", 2);
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIHTAR_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI", colmIHTAR_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIHTAR_GIDERI, summaryIHTAR_GIDERI_DOVIZ_ID });
            colmIHTAR_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIHTAR_GIDERI.SummaryItem.FieldName = "IHTAR_GIDERI";
            colmIHTAR_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI.SummaryItem.Tag = 1;

            var colmOZEL_TAZMINAT_DOVIZ_ID = colmnVer("OZEL TAZMINAT DOVIZ ID", "OZEL_TAZMINAT_DOVIZ_ID", true, 56, lupDoviz);
            var colmOZEL_TAZMINAT = colmnVer("OZEL TAZMINAT", "OZEL_TAZMINAT", true, 57, null, colmOZEL_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT_DOVIZ_ID", colmOZEL_TAZMINAT_DOVIZ_ID, "", 2);
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOZEL_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT", colmOZEL_TAZMINAT, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOZEL_TAZMINAT, summaryOZEL_TAZMINAT_DOVIZ_ID });
            colmOZEL_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TAZMINAT.SummaryItem.FieldName = "OZEL_TAZMINAT";
            colmOZEL_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT.SummaryItem.Tag = 1;
            System.Diagnostics.Debug.WriteLine(9);

            var colmOZEL_TUTAR1_FAIZ_ORANI = colmnVer("OZEL TUTAR1 FAIZ ORANI", "OZEL_TUTAR1_FAIZ_ORANI", true, 58, null);
            var colmOZEL_TUTAR1_KONU_ID = colmnVer("OZEL TUTAR1 KONU ID", "OZEL_TUTAR1_KONU_ID", true, 59, null);
            var colmOZEL_TUTAR1_KONU_ADI = colmnVer("OZEL TUTAR1 KONU ADI", "OZEL_TUTAR1_KONU_ADI", true, 60, null);
            var colmOZEL_TUTAR2_KONU_ID = colmnVer("OZEL TUTAR2 KONU ID", "OZEL_TUTAR2_KONU_ID", true, 63, null);
            var colmOZEL_TUTAR2_KONU_ADI = colmnVer("OZEL TUTAR2 KONU ADI", "OZEL_TUTAR2_KONU_ADI", true, 64, null);

            var colmOZEL_TUTAR1_DOVIZ_ID = colmnVer("OZEL TUTAR1 DOVIZ ID", "OZEL_TUTAR1_DOVIZ_ID", true, 61, lupDoviz);
            var colmOZEL_TUTAR1 = colmnVer("OZEL TUTAR1", "OZEL_TUTAR1", true, 62, null, colmOZEL_TUTAR1_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR1_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1_DOVIZ_ID", colmOZEL_TUTAR1_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOZEL_TUTAR1 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1", colmOZEL_TUTAR1, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOZEL_TUTAR1, summaryOZEL_TUTAR1_DOVIZ_ID });
            colmOZEL_TUTAR1.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR1.SummaryItem.FieldName = "OZEL_TUTAR1";
            colmOZEL_TUTAR1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR2_DOVIZ_ID = colmnVer("OZEL TUTAR2 DOVIZ ID", "OZEL_TUTAR2_DOVIZ_ID", true, 65, lupDoviz);
            var colmOZEL_TUTAR2 = colmnVer("OZEL TUTAR2", "OZEL_TUTAR2", true, 66, null, colmOZEL_TUTAR2_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR2_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2_DOVIZ_ID", colmOZEL_TUTAR2_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOZEL_TUTAR2 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2", colmOZEL_TUTAR2, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOZEL_TUTAR2, summaryOZEL_TUTAR2_DOVIZ_ID });
            colmOZEL_TUTAR2.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR2.SummaryItem.FieldName = "OZEL_TUTAR2";
            colmOZEL_TUTAR2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR3_KONU_ID = colmnVer("OZEL TUTAR3 KONU ID", "OZEL_TUTAR3_KONU_ID", true, 67, null);
            var colmOZEL_TUTAR3_KONU_ADI = colmnVer("OZEL TUTAR3 KONU ADI", "OZEL_TUTAR3_KONU_ADI", true, 68, null);

            var colmOZEL_TUTAR3_DOVIZ_ID = colmnVer("OZEL TUTAR3 DOVIZ ID", "OZEL_TUTAR3_DOVIZ_ID", true, 69, lupDoviz);
            var colmOZEL_TUTAR3 = colmnVer("OZEL TUTAR3", "OZEL_TUTAR3", true, 70, null, colmOZEL_TUTAR3_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR3_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3_DOVIZ_ID", colmOZEL_TUTAR3_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOZEL_TUTAR3 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3", colmOZEL_TUTAR3, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOZEL_TUTAR3, summaryOZEL_TUTAR3_DOVIZ_ID });
            colmOZEL_TUTAR3.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR3.SummaryItem.FieldName = "OZEL_TUTAR3";
            colmOZEL_TUTAR3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3.SummaryItem.Tag = 1;

            var colmTAKIP_CIKISI_DOVIZ_ID = colmnVer("TAKIP CIKISI DOVIZ ID", "TAKIP_CIKISI_DOVIZ_ID", true, 71, null);
            var colmTAKIP_CIKISI = colmnVer("TAKIP CIKISI", "TAKIP_CIKISI", true, 72, null, colmTAKIP_CIKISI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_CIKISI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI_DOVIZ_ID", colmTAKIP_CIKISI_DOVIZ_ID, "", 2);
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTAKIP_CIKISI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI", colmTAKIP_CIKISI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTAKIP_CIKISI, summaryTAKIP_CIKISI_DOVIZ_ID });
            colmTAKIP_CIKISI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_CIKISI.SummaryItem.FieldName = "TAKIP_CIKISI";
            colmTAKIP_CIKISI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI.SummaryItem.Tag = 1;

            var colmSONRAKI_FAIZ_DOVIZ_ID = colmnVer("SONRAKI FAIZ DOVIZ ID", "SONRAKI_FAIZ_DOVIZ_ID", true, 73, lupDoviz);
            var colmSONRAKI_FAIZ = colmnVer("SONRAKI FAIZ", "SONRAKI_FAIZ", true, 74, null, colmSONRAKI_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ_DOVIZ_ID", colmSONRAKI_FAIZ_DOVIZ_ID, "", 2);
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;

            var summarySONRAKI_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ", colmSONRAKI_FAIZ, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summarySONRAKI_FAIZ, summarySONRAKI_FAIZ_DOVIZ_ID });
            colmSONRAKI_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_FAIZ.SummaryItem.FieldName = "SONRAKI_FAIZ";
            colmSONRAKI_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ.SummaryItem.Tag = 1;

            var colmSONRAKI_TAZMINAT_DOVIZ_ID = colmnVer("SONRAKI TAZMINAT DOVIZ ID", "SONRAKI_TAZMINAT_DOVIZ_ID", true, 75, lupDoviz);
            var colmSONRAKI_TAZMINAT = colmnVer("SONRAKI TAZMINAT", "SONRAKI_TAZMINAT", true, 76, null, colmSONRAKI_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT_DOVIZ_ID", colmSONRAKI_TAZMINAT_DOVIZ_ID, "", 2);
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var summarySONRAKI_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT", colmSONRAKI_TAZMINAT, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summarySONRAKI_TAZMINAT, summarySONRAKI_TAZMINAT_DOVIZ_ID });
            colmSONRAKI_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_TAZMINAT.SummaryItem.FieldName = "SONRAKI_TAZMINAT";
            colmSONRAKI_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT.SummaryItem.Tag = 1;

            var colmBSMV_TS_DOVIZ_ID = colmnVer("BSMV TS DOVIZ ID", "BSMV_TS_DOVIZ_ID", true, 77, lupDoviz);
            var colmBSMV_TS = colmnVer("BSMV TS", "BSMV_TS", true, 78, null, colmBSMV_TS_DOVIZ_ID);
            var summaryBSMV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS_DOVIZ_ID", colmBSMV_TS_DOVIZ_ID, "", 2);
            colmBSMV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TS_DOVIZ_ID";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryBSMV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS", colmBSMV_TS, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryBSMV_TS, summaryBSMV_TS_DOVIZ_ID });
            colmBSMV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TS.SummaryItem.FieldName = "BSMV_TS";
            colmBSMV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS.SummaryItem.Tag = 1;

            var colmOIV_TS_DOVIZ_ID = colmnVer("OIV TS DOVIZ ID", "OIV_TS_DOVIZ_ID", true, 79, null);
            var colmOIV_TS = colmnVer("OIV TS", "OIV_TS", true, 80, null, colmOIV_TS_DOVIZ_ID);
            var summaryOIV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS_DOVIZ_ID", colmOIV_TS_DOVIZ_ID, "", 2);
            colmOIV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TS_DOVIZ_ID.SummaryItem.FieldName = "OIV_TS_DOVIZ_ID";
            colmOIV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryOIV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS", colmOIV_TS, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryOIV_TS, summaryOIV_TS_DOVIZ_ID });
            colmOIV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TS.SummaryItem.FieldName = "OIV_TS";
            colmOIV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS.SummaryItem.Tag = 1;

            var colmKDV_TS_DOVIZ_ID = colmnVer("KDV TS DOVIZ ID", "KDV_TS_DOVIZ_ID", true, 81, lupDoviz);
            var colmKDV_TS = colmnVer("KDV TS", "KDV_TS", true, 82, null, colmKDV_TS_DOVIZ_ID);
            var summaryKDV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS_DOVIZ_ID", colmKDV_TS_DOVIZ_ID, "", 2);
            colmKDV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TS_DOVIZ_ID.SummaryItem.FieldName = "KDV_TS_DOVIZ_ID";
            colmKDV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKDV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS", colmKDV_TS, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKDV_TS, summaryKDV_TS_DOVIZ_ID });
            colmKDV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TS.SummaryItem.FieldName = "KDV_TS";
            colmKDV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS.SummaryItem.Tag = 1;

            var colmILK_GIDERLER_DOVIZ_ID = colmnVer("ILK GIDERLER DOVIZ ID", "ILK_GIDERLER_DOVIZ_ID", true, 83, lupDoviz);
            var colmILK_GIDERLER = colmnVer("ILK GIDERLER", "ILK_GIDERLER", true, 84, null, colmILK_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER_DOVIZ_ID", colmILK_GIDERLER_DOVIZ_ID, "", 2);
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILK_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER", colmILK_GIDERLER, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILK_GIDERLER, summaryILK_GIDERLER_DOVIZ_ID });
            colmILK_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_GIDERLER.SummaryItem.FieldName = "ILK_GIDERLER";
            colmILK_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER.SummaryItem.Tag = 1;

            var colmPESIN_HARC_DOVIZ_ID = colmnVer("PESIN HARC DOVIZ ID", "PESIN_HARC_DOVIZ_ID", true, 85, lupDoviz);
            var colmPESIN_HARC = colmnVer("PESIN HARC", "PESIN_HARC", true, 86, null, colmPESIN_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPESIN_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC_DOVIZ_ID", colmPESIN_HARC_DOVIZ_ID, "", 2);
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.FieldName = "PESIN_HARC_DOVIZ_ID";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryPESIN_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC", colmPESIN_HARC, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryPESIN_HARC, summaryPESIN_HARC_DOVIZ_ID });
            colmPESIN_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPESIN_HARC.SummaryItem.FieldName = "PESIN_HARC";
            colmPESIN_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC.SummaryItem.Tag = 1;

            var colmODENEN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("ODENEN TAHSIL HARCI DOVIZ ID", "ODENEN_TAHSIL_HARCI_DOVIZ_ID", true, 87, lupDoviz);
            var colmODENEN_TAHSIL_HARCI = colmnVer("ODENEN TAHSIL HARCI", "ODENEN_TAHSIL_HARCI", true, 88, null, colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODENEN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI_DOVIZ_ID", colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryODENEN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI", colmODENEN_TAHSIL_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryODENEN_TAHSIL_HARCI, summaryODENEN_TAHSIL_HARCI_DOVIZ_ID });
            colmODENEN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODENEN_TAHSIL_HARCI.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI";
            colmODENEN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmKALAN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("KALAN TAHSIL HARCI DOVIZ ID", "KALAN_TAHSIL_HARCI_DOVIZ_ID", true, 89, lupDoviz);
            var colmKALAN_TAHSIL_HARCI = colmnVer("KALAN TAHSIL HARCI", "KALAN_TAHSIL_HARCI", true, 90, null, colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI_DOVIZ_ID", colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKALAN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI", colmKALAN_TAHSIL_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKALAN_TAHSIL_HARCI, summaryKALAN_TAHSIL_HARCI_DOVIZ_ID });
            colmKALAN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN_TAHSIL_HARCI.SummaryItem.FieldName = "KALAN TAHSIL HARCI";
            colmKALAN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmMASAYA_KATILMA_HARCI_DOVIZ_ID = colmnVer("MASAYA KATILMA HARCI DOVIZ ID", "MASAYA_KATILMA_HARCI_DOVIZ_ID", true, 91, lupDoviz);
            var colmMASAYA_KATILMA_HARCI = colmnVer("MASAYA KATILMA HARCI", "MASAYA_KATILMA_HARCI", true, 92, null, colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMASAYA_KATILMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI_DOVIZ_ID", colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "", 2);
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryMASAYA_KATILMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI", colmMASAYA_KATILMA_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryMASAYA_KATILMA_HARCI, summaryMASAYA_KATILMA_HARCI_DOVIZ_ID });
            colmMASAYA_KATILMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMASAYA_KATILMA_HARCI.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI";
            colmMASAYA_KATILMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI.SummaryItem.Tag = 1;

            var colmPAYLASMA_HARCI_DOVIZ_ID = colmnVer("PAYLASMA HARCI DOVIZ ID", "PAYLASMA_HARCI_DOVIZ_ID", true, 93, lupDoviz);
            var colmPAYLASMA_HARCI = colmnVer("PAYLASMA HARCI", "PAYLASMA_HARCI", true, 94, null, colmPAYLASMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPAYLASMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI_DOVIZ_ID", colmPAYLASMA_HARCI_DOVIZ_ID, "", 2);
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryPAYLASMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI", colmPAYLASMA_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryPAYLASMA_HARCI, summaryPAYLASMA_HARCI_DOVIZ_ID });
            colmPAYLASMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPAYLASMA_HARCI.SummaryItem.FieldName = "PAYLASMA_HARCI";
            colmPAYLASMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI.SummaryItem.Tag = 1;

            var colmDAVA_GIDERLERI_DOVIZ_ID = colmnVer("DAVA GIDERLERI DOVIZ ID", "DAVA_GIDERLERI_DOVIZ_ID", true, 95, lupDoviz);
            var colmDAVA_GIDERLERI = colmnVer("DAVA GIDERLERI", "DAVA_GIDERLERI", true, 96, null, colmDAVA_GIDERLERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_GIDERLERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI_DOVIZ_ID", colmDAVA_GIDERLERI_DOVIZ_ID, "", 2);
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDAVA_GIDERLERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI", colmDAVA_GIDERLERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDAVA_GIDERLERI, summaryDAVA_GIDERLERI_DOVIZ_ID });
            colmDAVA_GIDERLERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_GIDERLERI.SummaryItem.FieldName = "DAVA_GIDERLERI";
            colmDAVA_GIDERLERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI.SummaryItem.Tag = 1;

            var colmDIGER_GIDERLER_DOVIZ_ID = colmnVer("DIGER GIDERLER DOVIZ ID", "DIGER_GIDERLER_DOVIZ_ID", true, 97, lupDoviz);
            var colmDIGER_GIDERLER = colmnVer("DIGER GIDERLER", "DIGER_GIDERLER", true, 98, null, colmDIGER_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER_DOVIZ_ID", colmDIGER_GIDERLER_DOVIZ_ID, "", 2);
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDIGER_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER", colmDIGER_GIDERLER, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDIGER_GIDERLER, summaryDIGER_GIDERLER_DOVIZ_ID });
            colmDIGER_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_GIDERLER.SummaryItem.FieldName = "DIGER_GIDERLER";
            colmDIGER_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER.SummaryItem.Tag = 1;

            var colmTAKIP_VEKALET_UCRETI_KATSAYI = colmnVer("TAKIP VEKALET UCRETI KATSAYI", "TAKIP_VEKALET_UCRETI_KATSAYI", true, 99, null);

            var colmTAKIP_VEKALET_UCRETI_DOVIZ_ID = colmnVer("TAKIP VEKALET UCRETI DOVIZ ID", "TAKIP_VEKALET_UCRETI_DOVIZ_ID", true, 100, lupDoviz);
            var colmTAKIP_VEKALET_UCRETI = colmnVer("TAKIP VEKALET UCRETI", "TAKIP_VEKALET_UCRETI", true, 101, null, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI_DOVIZ_ID", colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTAKIP_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI", colmTAKIP_VEKALET_UCRETI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTAKIP_VEKALET_UCRETI, summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID });
            colmTAKIP_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmDAVA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("DAVA INKAR TAZMINATI DOVIZ ID", "DAVA_INKAR_TAZMINATI_DOVIZ_ID", true, 102, lupDoviz);
            var colmDAVA_INKAR_TAZMINATI = colmnVer("DAVA INKAR TAZMINATI", "DAVA_INKAR_TAZMINATI", true, 103, null, colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI_DOVIZ_ID", colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDAVA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI", colmDAVA_INKAR_TAZMINATI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDAVA_INKAR_TAZMINATI, summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID });
            colmDAVA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAVA_VEKALET_UCRETI_DOVIZ_ID = colmnVer("DAVA VEKALET UCRETI DOVIZ ID", "DAVA_VEKALET_UCRETI_DOVIZ_ID", true, 104, lupDoviz);
            var colmDAVA_VEKALET_UCRETI = colmnVer("DAVA VEKALET UCRETI", "DAVA_VEKALET_UCRETI", true, 105, null, colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI_DOVIZ_ID", colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDAVA_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI", colmDAVA_VEKALET_UCRETI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDAVA_VEKALET_UCRETI, summaryDAVA_VEKALET_UCRETI_DOVIZ_ID });
            colmDAVA_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_VEKALET_UCRETI.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI";
            colmDAVA_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmODEME_TOPLAMI_DOVIZ_ID = colmnVer("ODEME TOPLAMI DOVIZ ID", "ODEME_TOPLAMI_DOVIZ_ID", true, 106, lupDoviz);
            var colmODEME_TOPLAMI = colmnVer("ODEME TOPLAMI", "ODEME_TOPLAMI", true, 107, null, colmODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI_DOVIZ_ID", colmODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI", colmODEME_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryODEME_TOPLAMI, summaryODEME_TOPLAMI_DOVIZ_ID });
            colmODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODEME_TOPLAMI.SummaryItem.FieldName = "ODEME_TOPLAMI";
            colmODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_ODEME_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME TOPLAMI DOVIZ ID", "TO_ODEME_TOPLAMI_DOVIZ_ID", true, 108, lupDoviz);
            var colmTO_ODEME_TOPLAMI = colmnVer("TO ODEME TOPLAMI", "TO_ODEME_TOPLAMI", true, 109, null, colmTO_ODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI_DOVIZ_ID", colmTO_ODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;
            System.Diagnostics.Debug.WriteLine(10);

            var summaryTO_ODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI", colmTO_ODEME_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTO_ODEME_TOPLAMI, summaryTO_ODEME_TOPLAMI_DOVIZ_ID });
            colmTO_ODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_TOPLAMI";
            colmTO_ODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmMAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("MAHSUP TOPLAMI DOVIZ ID", "MAHSUP_TOPLAMI_DOVIZ_ID", true, 110, lupDoviz);
            var colmMAHSUP_TOPLAMI = colmnVer("MAHSUP TOPLAMI", "MAHSUP_TOPLAMI", true, 111, null, colmMAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI_DOVIZ_ID", colmMAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryMAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI", colmMAHSUP_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryMAHSUP_TOPLAMI, summaryMAHSUP_TOPLAMI_DOVIZ_ID });
            colmMAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMAHSUP_TOPLAMI.SummaryItem.FieldName = "MAHSUP_TOPLAMI";
            colmMAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmFERAGAT_TOPLAMI_DOVIZ_ID = colmnVer("FERAGAT TOPLAMI DOVIZ ID", "FERAGAT_TOPLAMI_DOVIZ_ID", true, 113, lupDoviz);
            var colmFERAGAT_TOPLAMI = colmnVer("FERAGAT TOPLAMI", "FERAGAT_TOPLAMI", true, 112, null, colmFERAGAT_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI_DOVIZ_ID", colmFERAGAT_TOPLAMI_DOVIZ_ID, "", 2);
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryFERAGAT_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI", colmFERAGAT_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryFERAGAT_TOPLAMI, summaryFERAGAT_TOPLAMI_DOVIZ_ID });
            colmFERAGAT_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_TOPLAMI.SummaryItem.FieldName = "FERAGAT_TOPLAMI";
            colmFERAGAT_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI.SummaryItem.Tag = 1;

            var colmALACAK_TOPLAMI_DOVIZ_ID = colmnVer("ALACAK TOPLAMI DOVIZ ID", "ALACAK_TOPLAMI_DOVIZ_ID", true, 114, lupDoviz);
            var colmALACAK_TOPLAMI = colmnVer("ALACAK TOPLAMI", "ALACAK_TOPLAMI", true, 115, null, colmALACAK_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryALACAK_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI_DOVIZ_ID", colmALACAK_TOPLAMI_DOVIZ_ID, "", 2);
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryALACAK_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI", colmALACAK_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryALACAK_TOPLAMI, summaryALACAK_TOPLAMI_DOVIZ_ID });
            colmALACAK_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmALACAK_TOPLAMI.SummaryItem.FieldName = "ALACAK_TOPLAMI";
            colmALACAK_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI.SummaryItem.Tag = 1;

            var colmKALAN_DOVIZ_ID = colmnVer("KALAN DOVIZ ID", "KALAN_DOVIZ_ID", true, 116, lupDoviz);
            var colmKALAN = colmnVer("KALAN", "KALAN", true, 117, null, colmKALAN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_DOVIZ_ID", colmKALAN_DOVIZ_ID, "", 2);
            colmKALAN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_DOVIZ_ID.SummaryItem.FieldName = "KALAN_DOVIZ_ID";
            colmKALAN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKALAN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN", colmKALAN, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKALAN, summaryKALAN_DOVIZ_ID });
            colmKALAN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN.SummaryItem.FieldName = "KALAN";
            colmKALAN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN.SummaryItem.Tag = 1;

            var colmTAHLIYE_VEK_UCR_DOVIZ_ID = colmnVer("TAHLIYE VEK UCR DOVIZ ID", "TAHLIYE_VEK_UCR_DOVIZ_ID", true, 118, lupDoviz);
            var colmTAHLIYE_VEK_UCR = colmnVer("TAHLIYE VEK UCR", "TAHLIYE_VEK_UCR", true, 119, null, colmTAHLIYE_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR_DOVIZ_ID", colmTAHLIYE_VEK_UCR_DOVIZ_ID, "", 2);
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTAHLIYE_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR", colmTAHLIYE_VEK_UCR, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTAHLIYE_VEK_UCR, summaryTAHLIYE_VEK_UCR_DOVIZ_ID });
            colmTAHLIYE_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_VEK_UCR.SummaryItem.FieldName = "TAHLIYE_VEK_UCR";
            colmTAHLIYE_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR.SummaryItem.Tag = 1;

            var colmDIGER_HARC_DOVIZ_ID = colmnVer("DIGER HARC DOVIZ ID", "DIGER_HARC_DOVIZ_ID", true, 120, lupDoviz);
            var colmDIGER_HARC = colmnVer("DIGER HARC", "DIGER_HARC", true, 121, null, colmDIGER_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC_DOVIZ_ID", colmDIGER_HARC_DOVIZ_ID, "", 2);
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.FieldName = "DIGER_HARC_DOVIZ_ID";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDIGER_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC", colmDIGER_HARC, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDIGER_HARC, summaryDIGER_HARC_DOVIZ_ID });
            colmDIGER_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_HARC.SummaryItem.FieldName = "DIGER_HARC";
            colmDIGER_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC.SummaryItem.Tag = 1;

            var colmTD_GIDERI_DOVIZ_ID = colmnVer("TD GIDERI DOVIZ ID", "TD_GIDERI_DOVIZ_ID", true, 122, lupDoviz);
            var colmTD_GIDERI = colmnVer("TD GIDERI", "TD_GIDERI", true, 123, null, colmTD_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI_DOVIZ_ID", colmTD_GIDERI_DOVIZ_ID, "", 2);
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_GIDERI_DOVIZ_ID";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTD_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI", colmTD_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTD_GIDERI, summaryTD_GIDERI_DOVIZ_ID });
            colmTD_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_GIDERI.SummaryItem.FieldName = "TD_GIDERI";
            colmTD_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI.SummaryItem.Tag = 1;

            var colmTD_BAKIYE_HARC_DOVIZ_ID = colmnVer("TD BAKIYE HARC DOVIZ ID", "TD_BAKIYE_HARC_DOVIZ_ID", true, 124, lupDoviz);
            var colmTD_BAKIYE_HARC = colmnVer("TD BAKIYE HARC", "TD_BAKIYE_HARC", true, 125, null, colmTD_BAKIYE_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_BAKIYE_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC_DOVIZ_ID", colmTD_BAKIYE_HARC_DOVIZ_ID, "", 2);
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTD_BAKIYE_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC", colmTD_BAKIYE_HARC, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTD_BAKIYE_HARC, summaryTD_BAKIYE_HARC_DOVIZ_ID });
            colmTD_BAKIYE_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_BAKIYE_HARC.SummaryItem.FieldName = "TD_BAKIYE_HARC";
            colmTD_BAKIYE_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC.SummaryItem.Tag = 1;

            var colmTD_VEK_UCR_DOVIZ_ID = colmnVer("TD VEK UCR DOVIZ ID", "TD_VEK_UCR_DOVIZ_ID", true, 126, lupDoviz);
            var colmTD_VEK_UCR = colmnVer("TD VEK UCR", "TD_VEK_UCR", true, 127, null, colmTD_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR_DOVIZ_ID", colmTD_VEK_UCR_DOVIZ_ID, "", 2);
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTD_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR", colmTD_VEK_UCR, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTD_VEK_UCR, summaryTD_VEK_UCR_DOVIZ_ID });
            colmTD_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_VEK_UCR.SummaryItem.FieldName = "TD_VEK_UCR";
            colmTD_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR.SummaryItem.Tag = 1;

            var colmTD_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("TD TEBLIG GIDERI DOVIZ ID", "TD_TEBLIG_GIDERI_DOVIZ_ID", true, 128, lupDoviz);
            var colmTD_TEBLIG_GIDERI = colmnVer("TD TEBLIG GIDERI", "TD_TEBLIG_GIDERI", true, 129, null, colmTD_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI_DOVIZ_ID", colmTD_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTD_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI", colmTD_TEBLIG_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTD_TEBLIG_GIDERI, summaryTD_TEBLIG_GIDERI_DOVIZ_ID });
            colmTD_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_TEBLIG_GIDERI.SummaryItem.FieldName = "TD_TEBLIG_GIDERI";
            colmTD_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmBIRIKMIS_NAFAKA_DOVIZ_ID = colmnVer("BIRIKMIS NAFAKA DOVIZ ID", "BIRIKMIS_NAFAKA_DOVIZ_ID", true, 130, lupDoviz);
            var colmBIRIKMIS_NAFAKA = colmnVer("BIRIKMIS NAFAKA", "BIRIKMIS_NAFAKA", true, 131, null, colmBIRIKMIS_NAFAKA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIKMIS_NAFAKA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA_DOVIZ_ID", colmBIRIKMIS_NAFAKA_DOVIZ_ID, "", 2);
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryBIRIKMIS_NAFAKA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA", colmBIRIKMIS_NAFAKA, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryBIRIKMIS_NAFAKA, summaryBIRIKMIS_NAFAKA_DOVIZ_ID });
            colmBIRIKMIS_NAFAKA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIKMIS_NAFAKA.SummaryItem.FieldName = "BIRIKMIS_NAFAKA";
            colmBIRIKMIS_NAFAKA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA.SummaryItem.Tag = 1;

            var colmICRA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ICRA INKAR TAZMINATI DOVIZ ID", "ICRA_INKAR_TAZMINATI_DOVIZ_ID", true, 132, lupDoviz);
            var colmICRA_INKAR_TAZMINATI = colmnVer("ICRA INKAR TAZMINATI", "ICRA_INKAR_TAZMINATI", true, 133, null, colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryICRA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI_DOVIZ_ID", colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryICRA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI", colmICRA_INKAR_TAZMINATI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryICRA_INKAR_TAZMINATI, summaryICRA_INKAR_TAZMINATI_DOVIZ_ID });
            colmICRA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmICRA_INKAR_TAZMINATI.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI";
            colmICRA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAMGA_PULU_DOVIZ_ID = colmnVer("DAMGA PULU DOVIZ ID", "DAMGA_PULU_DOVIZ_ID", true, 134, lupDoviz);
            var colmDAMGA_PULU = colmnVer("DAMGA PULU", "DAMGA_PULU", true, 135, null, colmDAMGA_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAMGA_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU_DOVIZ_ID", colmDAMGA_PULU_DOVIZ_ID, "", 2);
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.FieldName = "DAMGA_PULU_DOVIZ_ID";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryDAMGA_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU", colmDAMGA_PULU, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryDAMGA_PULU, summaryDAMGA_PULU_DOVIZ_ID });
            colmDAMGA_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAMGA_PULU.SummaryItem.FieldName = "DAMGA_PULU";
            colmDAMGA_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU.SummaryItem.Tag = 1;

            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 136, null);

            var colmPROTOKOL_MIKTARI_DOVIZ_ID = colmnVer("PROTOKOL MIKTARI DOVIZ ID", "PROTOKOL_MIKTARI_DOVIZ_ID", true, 137, lupDoviz);
            var colmPROTOKOL_MIKTARI = colmnVer("PROTOKOL MIKTARI", "PROTOKOL_MIKTARI", true, 138, null, colmPROTOKOL_MIKTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTOKOL_MIKTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI_DOVIZ_ID", colmPROTOKOL_MIKTARI_DOVIZ_ID, "", 2);
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryPROTOKOL_MIKTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI", colmPROTOKOL_MIKTARI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryPROTOKOL_MIKTARI, summaryPROTOKOL_MIKTARI_DOVIZ_ID });
            colmPROTOKOL_MIKTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTOKOL_MIKTARI.SummaryItem.FieldName = "PROTOKOL_MIKTARI";
            colmPROTOKOL_MIKTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI.SummaryItem.Tag = 1;

            var colmPROTOKOL_FAIZ_ORANI = colmnVer("PROTOKOL FAIZ ORANI", "PROTOKOL_FAIZ_ORANI", true, 139, null);
            var colmPROTOKOL_TARIHI = colmnVer("PROTOKOL TARIHI", "PROTOKOL_TARIHI", true, 140, null);

            var colmKARSILIK_TUTARI_DOVIZ_ID = colmnVer("KARSILIK TUTARI DOVIZ ID", "KARSILIK_TUTARI_DOVIZ_ID", true, 141, lupDoviz);
            var colmKARSILIK_TUTARI = colmnVer("KARSILIK TUTARI", "KARSILIK_TUTARI", true, 142, null, colmKARSILIK_TUTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIK_TUTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI_DOVIZ_ID", colmKARSILIK_TUTARI_DOVIZ_ID, "", 2);
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKARSILIK_TUTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI", colmKARSILIK_TUTARI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKARSILIK_TUTARI, summaryKARSILIK_TUTARI_DOVIZ_ID });
            colmKARSILIK_TUTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIK_TUTARI.SummaryItem.FieldName = "KARSILIK_TUTARI";
            colmKARSILIK_TUTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI.SummaryItem.Tag = 1;

            var colmTO_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TO MASRAF TOPLAMI DOVIZ ID", "TO_MASRAF_TOPLAMI_DOVIZ_ID", true, 144, lupDoviz);
            var colmTO_MASRAF_TOPLAMI = colmnVer("TO MASRAF TOPLAMI", "TO_MASRAF_TOPLAMI", true, 143, null, colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI_DOVIZ_ID", colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTO_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI", colmTO_MASRAF_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTO_MASRAF_TOPLAMI, summaryTO_MASRAF_TOPLAMI_DOVIZ_ID });
            colmTO_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_MASRAF_TOPLAMI.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI";
            colmTO_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TS MASRAF TOPLAMI DOVIZ ID", "TS_MASRAF_TOPLAMI_DOVIZ_ID", true, 146, lupDoviz);
            var colmTS_MASRAF_TOPLAMI = colmnVer("TS MASRAF TOPLAMI", "TS_MASRAF_TOPLAMI", true, 145, null, colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI_DOVIZ_ID", colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTS_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI", colmTS_MASRAF_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTS_MASRAF_TOPLAMI, summaryTS_MASRAF_TOPLAMI_DOVIZ_ID });
            colmTS_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_MASRAF_TOPLAMI.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI";
            colmTS_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TUM MASRAF TOPLAMI DOVIZ ID", "TUM_MASRAF_TOPLAMI_DOVIZ_ID", true, 148, lupDoviz);
            var colmTUM_MASRAF_TOPLAMI = colmnVer("TUM MASRAF TOPLAMI", "TUM_MASRAF_TOPLAMI", true, 147, null, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI_DOVIZ_ID", colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTUM_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI", colmTUM_MASRAF_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTUM_MASRAF_TOPLAMI, summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID });
            colmTUM_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmHARC_TOPLAMI_DOVIZ_ID = colmnVer("HARC TOPLAMI DOVIZ ID", "HARC_TOPLAMI_DOVIZ_ID", true, 150, lupDoviz);
            var colmHARC_TOPLAMI = colmnVer("HARC TOPLAMI", "HARC_TOPLAMI", true, 149, null, colmHARC_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHARC_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI_DOVIZ_ID", colmHARC_TOPLAMI_DOVIZ_ID, "", 2);
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryHARC_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI", colmHARC_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryHARC_TOPLAMI, summaryHARC_TOPLAMI_DOVIZ_ID });
            colmHARC_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHARC_TOPLAMI.SummaryItem.FieldName = "HARC_TOPLAMI";
            colmHARC_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TO VEKALET TOPLAMI DOVIZ ID", "TO_VEKALET_TOPLAMI_DOVIZ_ID", true, 151, lupDoviz);
            var colmTO_VEKALET_TOPLAMI = colmnVer("TO VEKALET TOPLAMI", "TO_VEKALET_TOPLAMI", true, 152, null, colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI_DOVIZ_ID", colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTO_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI", colmTO_VEKALET_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTO_VEKALET_TOPLAMI, summaryTO_VEKALET_TOPLAMI_DOVIZ_ID });
            colmTO_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_VEKALET_TOPLAMI.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI";
            colmTO_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TS VEKALET TOPLAMI DOVIZ ID", "TS_VEKALET_TOPLAMI_DOVIZ_ID", true, 154, lupDoviz);
            var colmTS_VEKALET_TOPLAMI = colmnVer("TS VEKALET TOPLAMI", "TS_VEKALET_TOPLAMI", true, 153, null, colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI_DOVIZ_ID", colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTS_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI", colmTS_VEKALET_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTS_VEKALET_TOPLAMI, summaryTS_VEKALET_TOPLAMI_DOVIZ_ID });
            colmTS_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_VEKALET_TOPLAMI.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI";
            colmTS_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TUM VEKALET TOPLAMI DOVIZ ID", "TUM_VEKALET_TOPLAMI_DOVIZ_ID", true, 156, lupDoviz);
            var colmTUM_VEKALET_TOPLAMI = colmnVer("TUM VEKALET TOPLAMI", "TUM_VEKALET_TOPLAMI", true, 155, null, colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI_DOVIZ_ID", colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTUM_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI", colmTUM_VEKALET_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTUM_VEKALET_TOPLAMI, summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID });
            colmTUM_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("KARSI VEKALET TOPLAMI DOVIZ ID", "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", true, 158, lupDoviz);
            var colmKARSI_VEKALET_TOPLAMI = colmnVer("KARSI VEKALET TOPLAMI", "KARSI_VEKALET_TOPLAMI", true, 157, null, colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryKARSI_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI", colmKARSI_VEKALET_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryKARSI_VEKALET_TOPLAMI, summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID });
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmFAIZ_TOPLAMI_DOVIZ_ID = colmnVer("FAIZ TOPLAMI DOVIZ ID", "FAIZ_TOPLAMI_DOVIZ_ID", true, 160, lupDoviz);
            var colmFAIZ_TOPLAMI = colmnVer("FAIZ TOPLAMI", "FAIZ_TOPLAMI", true, 159, null, colmFAIZ_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFAIZ_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI_DOVIZ_ID", colmFAIZ_TOPLAMI_DOVIZ_ID, "", 2);
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryFAIZ_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI", colmFAIZ_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryFAIZ_TOPLAMI, summaryFAIZ_TOPLAMI_DOVIZ_ID });
            colmFAIZ_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFAIZ_TOPLAMI.SummaryItem.FieldName = "FAIZ_TOPLAMI";
            colmFAIZ_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI.SummaryItem.Tag = 1;

            var colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID = colmnVer("ILAM UCRETLER TOPLAMI DOVIZ ID", "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", true, 162, lupDoviz);
            var colmILAM_UCRETLER_TOPLAMI = colmnVer("ILAM UCRETLER TOPLAMI", "ILAM_UCRETLER_TOPLAMI", true, 161, null, colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "", 2);
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILAM_UCRETLER_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI", colmILAM_UCRETLER_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILAM_UCRETLER_TOPLAMI, summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID });
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.Tag = 1;

            var colmIT_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IT VEKALET UCRETI DOVIZ ID", "IT_VEKALET_UCRETI_DOVIZ_ID", true, 163, lupDoviz);
            var colmIT_VEKALET_UCRETI = colmnVer("IT VEKALET UCRETI", "IT_VEKALET_UCRETI", true, 164, null, colmIT_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI_DOVIZ_ID", colmIT_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIT_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI", colmIT_VEKALET_UCRETI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIT_VEKALET_UCRETI, summaryIT_VEKALET_UCRETI_DOVIZ_ID });
            colmIT_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_VEKALET_UCRETI.SummaryItem.FieldName = "IT_VEKALET_UCRETI";
            colmIT_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIT_GIDERI_DOVIZ_ID = colmnVer("IT GIDERI DOVIZ ID", "IT_GIDERI_DOVIZ_ID", true, 165, lupDoviz);
            var colmIT_GIDERI = colmnVer("IT GIDERI", "IT_GIDERI", true, 166, null, colmIT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI_DOVIZ_ID", colmIT_GIDERI_DOVIZ_ID, "", 2);
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IT_GIDERI_DOVIZ_ID";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI", colmIT_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIT_GIDERI, summaryIT_GIDERI_DOVIZ_ID });
            colmIT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_GIDERI.SummaryItem.FieldName = "IT_GIDERI";
            colmIT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI.SummaryItem.Tag = 1;

            var colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME MAHSUP TOPLAMI DOVIZ ID", "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", true, 168, lupDoviz);
            var colmTO_ODEME_MAHSUP_TOPLAMI = colmnVer("TO ODEME MAHSUP TOPLAMI", "TO_ODEME_MAHSUP_TOPLAMI", true, 167, null, colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTO_ODEME_MAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI", colmTO_ODEME_MAHSUP_TOPLAMI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTO_ODEME_MAHSUP_TOPLAMI, summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID });
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmPAYLASIM_TIPI = colmnVer("PAYLASIM TIPI", "PAYLASIM_TIPI", true, 169, null);
            var colmTS_HESAP_TIP_ID = colmnVer("TS HESAP TIP ID", "TS_HESAP_TIP_ID", true, 170, null);
            var colmTS_HESAP_TIP_ADI = colmnVer("TS HESAP TIP ADI", "TS_HESAP_TIP_ADI", true, 171, null);
            var colmTO_HESAP_TIP_ID = colmnVer("TO HESAP TIP ID", "TO_HESAP_TIP_ID", true, 172, null);
            var colmTO_HESAP_TIP_ADI = colmnVer("TO HESAP TIP ADI", "TO_HESAP_TIP_ADI", true, 173, null);

            var colmBASVURMA_HARCI_DOVIZ_ID = colmnVer("BASVURMA HARCI DOVIZ ID", "BASVURMA_HARCI_DOVIZ_ID", true, 175, lupDoviz);
            var colmBASVURMA_HARCI = colmnVer("BASVURMA HARCI", "BASVURMA_HARCI", true, 174, null, colmBASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI_DOVIZ_ID", colmBASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryBASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI", colmBASVURMA_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryBASVURMA_HARCI, summaryBASVURMA_HARCI_DOVIZ_ID });
            colmBASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBASVURMA_HARCI.SummaryItem.FieldName = "BASVURMA_HARCI";
            colmBASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_HARCI_DOVIZ_ID = colmnVer("VEKALET HARCI DOVIZ ID", "VEKALET_HARCI_DOVIZ_ID", true, 177, lupDoviz);
            var colmVEKALET_HARCI = colmnVer("VEKALET HARCI", "VEKALET_HARCI", true, 176, null, colmVEKALET_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI_DOVIZ_ID", colmVEKALET_HARCI_DOVIZ_ID, "", 2);
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryVEKALET_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI", colmVEKALET_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryVEKALET_HARCI, summaryVEKALET_HARCI_DOVIZ_ID });
            colmVEKALET_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_HARCI.SummaryItem.FieldName = "VEKALET_HARCI";
            colmVEKALET_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_PULU_DOVIZ_ID = colmnVer("VEKALET PULU DOVIZ ID", "VEKALET_PULU_DOVIZ_ID", true, 179, lupDoviz);
            var colmVEKALET_PULU = colmnVer("VEKALET PULU", "VEKALET_PULU", true, 178, null, colmVEKALET_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU_DOVIZ_ID", colmVEKALET_PULU_DOVIZ_ID, "", 2);
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_PULU_DOVIZ_ID";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryVEKALET_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU", colmVEKALET_PULU, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryVEKALET_PULU, summaryVEKALET_PULU_DOVIZ_ID });
            colmVEKALET_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_PULU.SummaryItem.FieldName = "VEKALET_PULU";
            colmVEKALET_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU.SummaryItem.Tag = 1;

            var colmIFLAS_BASVURMA_HARCI_DOVIZ_ID = colmnVer("IFLAS BASVURMA HARCI DOVIZ ID", "IFLAS_BASVURMA_HARCI_DOVIZ_ID", true, 181, lupDoviz);
            var colmIFLAS_BASVURMA_HARCI = colmnVer("IFLAS BASVURMA HARCI", "IFLAS_BASVURMA_HARCI", true, 180, null, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI_DOVIZ_ID", colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIFLAS_BASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI", colmIFLAS_BASVURMA_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIFLAS_BASVURMA_HARCI, summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID });
            colmIFLAS_BASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID = colmnVer("IFLASIN ACILMASI HARCI DOVIZ ID", "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", true, 183, lupDoviz);
            var colmIFLASIN_ACILMASI_HARCI = colmnVer("IFLASIN ACILMASI HARCI", "IFLASIN_ACILMASI_HARCI", true, 182, null, colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "", 2);
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryIFLASIN_ACILMASI_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI", colmIFLASIN_ACILMASI_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryIFLASIN_ACILMASI_HARCI, summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID });
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.Tag = 1;

            var colmILK_TEBLIGAT_GIDERI_DOVIZ_ID = colmnVer("ILK TEBLIGAT GIDERI DOVIZ ID", "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", true, 185, lupDoviz);
            var colmILK_TEBLIGAT_GIDERI = colmnVer("ILK TEBLIGAT GIDERI", "ILK_TEBLIGAT_GIDERI", true, 184, null, colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "", 2);
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryILK_TEBLIGAT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI", colmILK_TEBLIGAT_GIDERI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryILK_TEBLIGAT_GIDERI, summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID });
            colmILK_TEBLIGAT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI.SummaryItem.Tag = 1;

            var colmTAHLIYE_HARCI_DOVIZ_ID = colmnVer("TAHLIYE HARCI DOVIZ ID", "TAHLIYE_HARCI_DOVIZ_ID", true, 187, lupDoviz);
            var colmTAHLIYE_HARCI = colmnVer("TAHLIYE HARCI", "TAHLIYE_HARCI", true, 186, null, colmTAHLIYE_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI_DOVIZ_ID", colmTAHLIYE_HARCI_DOVIZ_ID, "", 2);
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTAHLIYE_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI", colmTAHLIYE_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTAHLIYE_HARCI, summaryTAHLIYE_HARCI_DOVIZ_ID });
            colmTAHLIYE_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_HARCI.SummaryItem.FieldName = "TAHLIYE_HARCI";
            colmTAHLIYE_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI.SummaryItem.Tag = 1;

            var colmTESLIM_HARCI_DOVIZ_ID = colmnVer("TESLIM HARCI DOVIZ ID", "TESLIM_HARCI_DOVIZ_ID", true, 189, lupDoviz);
            var colmTESLIM_HARCI = colmnVer("TESLIM HARCI", "TESLIM_HARCI", true, 188, null, colmTESLIM_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTESLIM_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI_DOVIZ_ID", colmTESLIM_HARCI_DOVIZ_ID, "", 2);
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTESLIM_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI", colmTESLIM_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTESLIM_HARCI, summaryTESLIM_HARCI_DOVIZ_ID });
            colmTESLIM_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTESLIM_HARCI.SummaryItem.FieldName = "TESLIM_HARCI";
            colmTESLIM_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI.SummaryItem.Tag = 1;

            var colmFERAGAT_HARCI_DOVIZ_ID = colmnVer("FERAGAT HARCI DOVIZ ID", "FERAGAT_HARCI_DOVIZ_ID", true, 191, lupDoviz);
            var colmFERAGAT_HARCI = colmnVer("FERAGAT HARCI", "FERAGAT_HARCI", true, 190, null, colmFERAGAT_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI_DOVIZ_ID", colmFERAGAT_HARCI_DOVIZ_ID, "", 2);
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryFERAGAT_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI", colmFERAGAT_HARCI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryFERAGAT_HARCI, summaryFERAGAT_HARCI_DOVIZ_ID });
            colmFERAGAT_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_HARCI.SummaryItem.FieldName = "FERAGAT_HARCI";
            colmFERAGAT_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI.SummaryItem.Tag = 1;

            var colmTO_YONETIMG_TAZMINATI_DOVIZ_ID = colmnVer("TO YONETIMG TAZMINATI DOVIZ ID", "TO_YONETIMG_TAZMINATI_DOVIZ_ID", true, 192, lupDoviz);
            var colmTO_YONETIMG_TAZMINATI = colmnVer("TO YONETIMG TAZMINATI", "TO_YONETIMG_TAZMINATI", true, 193, null, colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI_DOVIZ_ID", colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "", 2);
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var summaryTO_YONETIMG_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI", colmTO_YONETIMG_TAZMINATI, "Grup Toplamı : {0:###,###,###,##0.00}", 1);
            gvMain.GroupSummary.AddRange(new[] { summaryTO_YONETIMG_TAZMINATI, summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID });
            colmTO_YONETIMG_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI.SummaryItem.Tag = 1;

            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 194, null);
            var colmASAMA_ADI = colmnVer("ASAMA ADI", "ASAMA_ADI", true, 195, null);

            colmASIL_ALACAK.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmASIL_ALACAK.SummaryItem.FieldName = "ASIL_ALACAK";
            colmASIL_ALACAK.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK.SummaryItem.Tag = 1;

            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.Tag = 2;

            gvMain.GroupSummary.AddRange(new[] { summaryASIL_ALACAK, summaryASIL_ALACAK_DOVIZ_ID });

            #endregion Column & Summary

            System.Diagnostics.Debug.WriteLine("Kolonlar Oluşturuldu " + DateTime.Now.ToLongTimeString());

            System.Diagnostics.Debug.WriteLine("Kolonlar Ekleniyor " + DateTime.Now.ToLongTimeString());

            #region Columns.AddRange

            gvMain.Columns.AddRange(new[]
                                               {
                                                   colmFOY_ID, colmFORM_ADI, colmDURUM, colmFOY_NO, colmREFERANS_NO, colmREFERANS_NO2,
                                                   colmREFERANS_NO3, colmNO, colmADLIYE, colmICRA_OZEL_KOD1_ID, colmICRA_OZEL_KOD2_ID,
                                                   colmICRA_OZEL_KOD3_ID, colmICRA_OZEL_KOD4_ID, colmTAKIBIN_AVUKATA_INTIKAL_TARIHI,
                                                   colmFOY_ARSIV_TARIHI, colmFOY_INFAZ_TARIHI, colmTAKIBIN_MUVEKKILE_IADE_TARIHI,
                                                   colmSON_HESAP_TARIHI, colmBIR_YIL_KAC_GUN, colmASIL_ALACAK_DOVIZ_ID, colmASIL_ALACAK,
                                                   colmISLEMIS_FAIZ_DOVIZ_ID, colmISLEMIS_FAIZ, colmBSMV_TO_DOVIZ_ID, colmBSMV_TO,
                                                   colmKKDV_TO_DOVIZ_ID, colmKKDV_TO, colmOIV_TO, colmKDV_TO_DOVIZ_ID, colmKDV_TO,
                                                   colmIH_VEKALET_UCRETI_DOVIZ_ID, colmIH_VEKALET_UCRETI, colmIH_GIDERI_DOVIZ_ID,
                                                   colmIH_GIDERI, colmIT_HACIZDE_ODENEN_DOVIZ_ID, colmIT_HACIZDE_ODENEN,
                                                   colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, colmKARSILIKSIZ_CEK_TAZMINATI,
                                                   colmCEK_KOMISYONU_DOVIZ_ID, colmCEK_KOMISYONU, colmILAM_YARGILAMA_GIDERI_DOVIZ_ID,
                                                   colmILAM_YARGILAMA_GIDERI, colmILAM_BK_YARG_ONAMA_DOVIZ_ID, colmILAM_BK_YARG_ONAMA,
                                                   colmILAM_TEBLIG_GIDERI_DOVIZ_ID, colmILAM_TEBLIG_GIDERI, colmILAM_INKAR_TAZMINATI_DOVIZ_ID,
                                                   colmILAM_INKAR_TAZMINATI, colmILAM_VEK_UCR_DOVIZ_ID, colmILAM_VEK_UCR, colmOIV_TO_DOVIZ_ID,
                                                   colmPROTESTO_GIDERI_DOVIZ_ID, colmPROTESTO_GIDERI, colmIHTAR_GIDERI_DOVIZ_ID, colmIHTAR_GIDERI,
                                                   colmOZEL_TAZMINAT_DOVIZ_ID, colmOZEL_TAZMINAT, colmOZEL_TUTAR1_FAIZ_ORANI,
                                                   colmOZEL_TUTAR1_KONU_ID, colmOZEL_TUTAR1_KONU_ADI, colmOZEL_TUTAR1_DOVIZ_ID, colmOZEL_TUTAR1,
                                                   colmOZEL_TUTAR2_KONU_ID, colmOZEL_TUTAR2_KONU_ADI, colmOZEL_TUTAR2_DOVIZ_ID, colmOZEL_TUTAR2,
                                                   colmOZEL_TUTAR3_KONU_ID, colmOZEL_TUTAR3_KONU_ADI, colmOZEL_TUTAR3_DOVIZ_ID, colmOZEL_TUTAR3,
                                                   colmTAKIP_CIKISI_DOVIZ_ID, colmTAKIP_CIKISI, colmSONRAKI_FAIZ_DOVIZ_ID, colmSONRAKI_FAIZ,
                                                   colmSONRAKI_TAZMINAT_DOVIZ_ID, colmSONRAKI_TAZMINAT, colmBSMV_TS_DOVIZ_ID, colmBSMV_TS,
                                                   colmOIV_TS_DOVIZ_ID, colmOIV_TS, colmKDV_TS_DOVIZ_ID, colmKDV_TS, colmILK_GIDERLER_DOVIZ_ID,
                                                   colmILK_GIDERLER, colmPESIN_HARC_DOVIZ_ID, colmPESIN_HARC, colmODENEN_TAHSIL_HARCI_DOVIZ_ID,
                                                   colmODENEN_TAHSIL_HARCI, colmKALAN_TAHSIL_HARCI_DOVIZ_ID, colmKALAN_TAHSIL_HARCI,
                                                   colmMASAYA_KATILMA_HARCI_DOVIZ_ID, colmMASAYA_KATILMA_HARCI, colmPAYLASMA_HARCI_DOVIZ_ID,
                                                   colmPAYLASMA_HARCI, colmDAVA_GIDERLERI_DOVIZ_ID, colmDAVA_GIDERLERI, colmDIGER_GIDERLER_DOVIZ_ID,
                                                   colmDIGER_GIDERLER, colmTAKIP_VEKALET_UCRETI_KATSAYI, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID,
                                                   colmTAKIP_VEKALET_UCRETI, colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, colmDAVA_INKAR_TAZMINATI,
                                                   colmDAVA_VEKALET_UCRETI_DOVIZ_ID, colmDAVA_VEKALET_UCRETI, colmODEME_TOPLAMI_DOVIZ_ID,
                                                   colmODEME_TOPLAMI, colmTO_ODEME_TOPLAMI_DOVIZ_ID, colmTO_ODEME_TOPLAMI,
                                                   colmMAHSUP_TOPLAMI_DOVIZ_ID, colmMAHSUP_TOPLAMI, colmFERAGAT_TOPLAMI,
                                                   colmFERAGAT_TOPLAMI_DOVIZ_ID, colmALACAK_TOPLAMI_DOVIZ_ID, colmALACAK_TOPLAMI,
                                                   colmKALAN_DOVIZ_ID, colmKALAN, colmTAHLIYE_VEK_UCR_DOVIZ_ID, colmTAHLIYE_VEK_UCR,
                                                   colmDIGER_HARC_DOVIZ_ID, colmDIGER_HARC, colmTD_GIDERI_DOVIZ_ID, colmTD_GIDERI,
                                                   colmTD_BAKIYE_HARC_DOVIZ_ID, colmTD_BAKIYE_HARC, colmTD_VEK_UCR_DOVIZ_ID, colmTD_VEK_UCR,
                                                   colmTD_TEBLIG_GIDERI_DOVIZ_ID, colmTD_TEBLIG_GIDERI, colmBIRIKMIS_NAFAKA_DOVIZ_ID,
                                                   colmBIRIKMIS_NAFAKA, colmICRA_INKAR_TAZMINATI_DOVIZ_ID, colmICRA_INKAR_TAZMINATI,
                                                   colmDAMGA_PULU_DOVIZ_ID, colmDAMGA_PULU, colmACIKLAMA, colmPROTOKOL_MIKTARI_DOVIZ_ID,
                                                   colmPROTOKOL_MIKTARI, colmPROTOKOL_FAIZ_ORANI, colmPROTOKOL_TARIHI,
                                                   colmKARSILIK_TUTARI_DOVIZ_ID, colmKARSILIK_TUTARI, colmTO_MASRAF_TOPLAMI,
                                                   colmTO_MASRAF_TOPLAMI_DOVIZ_ID, colmTS_MASRAF_TOPLAMI, colmTS_MASRAF_TOPLAMI_DOVIZ_ID,
                                                   colmTUM_MASRAF_TOPLAMI, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, colmHARC_TOPLAMI,
                                                   colmHARC_TOPLAMI_DOVIZ_ID, colmTO_VEKALET_TOPLAMI_DOVIZ_ID, colmTO_VEKALET_TOPLAMI,
                                                   colmTS_VEKALET_TOPLAMI, colmTS_VEKALET_TOPLAMI_DOVIZ_ID, colmTUM_VEKALET_TOPLAMI,
                                                   colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, colmKARSI_VEKALET_TOPLAMI, colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID,
                                                   colmFAIZ_TOPLAMI, colmFAIZ_TOPLAMI_DOVIZ_ID, colmILAM_UCRETLER_TOPLAMI,
                                                   colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, colmIT_VEKALET_UCRETI_DOVIZ_ID, colmIT_VEKALET_UCRETI,
                                                   colmIT_GIDERI_DOVIZ_ID, colmIT_GIDERI, colmTO_ODEME_MAHSUP_TOPLAMI,
                                                   colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, colmPAYLASIM_TIPI, colmTS_HESAP_TIP_ID,
                                                   colmTS_HESAP_TIP_ADI, colmTO_HESAP_TIP_ID, colmTO_HESAP_TIP_ADI, colmBASVURMA_HARCI,
                                                   colmBASVURMA_HARCI_DOVIZ_ID, colmVEKALET_HARCI, colmVEKALET_HARCI_DOVIZ_ID, colmVEKALET_PULU,
                                                   colmVEKALET_PULU_DOVIZ_ID, colmIFLAS_BASVURMA_HARCI, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID,
                                                   colmIFLASIN_ACILMASI_HARCI, colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, colmILK_TEBLIGAT_GIDERI,
                                                   colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, colmTAHLIYE_HARCI, colmTAHLIYE_HARCI_DOVIZ_ID,
                                                   colmTESLIM_HARCI, colmTESLIM_HARCI_DOVIZ_ID, colmFERAGAT_HARCI, colmFERAGAT_HARCI_DOVIZ_ID,
                                                   colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, colmTO_YONETIMG_TAZMINATI, colmASAMA_ID, colmASAMA_ADI
                                               });

            #endregion Columns.AddRange

            System.Diagnostics.Debug.WriteLine("Kolonlar Eklendi " + DateTime.Now.ToLongTimeString());

            System.Diagnostics.Debug.WriteLine("Kolonlar Gizleniyor " + DateTime.Now.ToLongTimeString());
            if (gvMain.Columns.Dolumu())
            {
                for (int i = 0; i < gvMain.Columns.Count; i++)
                {
                    gvMain.Columns[i].Visible = false;
                }
            }

            DebugWrite("Kolonlar Gizlendi");

            DebugWrite("Listeler Dolduruluyor");
            ListeDoldur_TanimliAlanlar();
            ListDoldur_Secilenler();
            DebugWrite("Listeler Dolduruldu");

            gvMain.Appearance.FooterPanel.TextOptions.HAlignment = HorzAlignment.Near;

            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            System.Diagnostics.Debug.WriteLine("Datasorce Veriliyor " + DateTime.Now.ToLongTimeString());
            gridRaporCntrol.DataSource = db.AV001_TI_BIL_HESAPLI_KAPSAMLI_GENELs;
            System.Diagnostics.Debug.WriteLine("Datasorce Verildi " + DateTime.Now.ToLongTimeString());
        }

        private void GORUSMELER_GENEL_TARAFLI()
        {
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 1, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 2, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 3, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 4, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmBITIS_SAATI = colmnVer("BITIS SAATI", "BITIS_SAATI", true, 5, null);
            var colmBITIS_TARIH = colmnVer("BITIS TARIH", "BITIS_TARIH", true, 6, null);
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 7, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 8, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 9, null);
            var colmGORUSEN_CARI_ID = colmnVer("GORUSEN CARI ID", "GORUSEN_CARI_ID", true, 10, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmGORUSEN_TEL = colmnVer("GORUSEN TEL", "GORUSEN_TEL", true, 11, null);
            var colmGORUSENIN_NOTU = colmnVer("GORUSENIN NOTU", "GORUSENIN_NOTU", true, 12, null);
            var colmGORUSME_SURE = colmnVer("GORUSME SURE", "GORUSME_SURE", true, 13, null);
            var colmGORUSME_YONU = colmnVer("GORUSME YONU", "GORUSME_YONU", true, 14, null);
            var colmGORUSULEN_CARI_ID = colmnVer("GORUSULEN CARI ID", "GORUSULEN_CARI_ID", true, 15, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmGORUSULEN_TEL = colmnVer("GORUSULEN TEL", "GORUSULEN_TEL", true, 16, null);
            var colmIS_KATEGORI_ID = colmnVer("IS KATEGORI ID", "IS_KATEGORI_ID", true, 17, TablesGrids.GetTDI_KOD_GORUSMELER_HAREKET_ALT_KATEGORILookup());
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 18, null);
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 19, null);
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 20, null);
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 21, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 22, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 23, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 24, null);
            var colmSAAT = colmnVer("SAAT", "SAAT", true, 25, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 26, null);
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 27, null);
            var colmTALEP_ID = colmnVer("TALEP ID", "TALEP_ID", true, 28, null);
            var colmTARAF_KODU = colmnVer("TARAF KODU", "TARAF_KODU", true, 29, null);
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 30, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmTARIH = colmnVer("TARIH", "TARIH", true, 31, null);
            var colmTipi = colmnVer("Tipi", "Tipi", true, 32, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmASAMA_ID, colmBITIS_SAATI, colmBITIS_TARIH, colmCARI_ID, colmESAS_NO, colmFOY_NO, colmGORUSEN_CARI_ID, colmGORUSEN_TEL, colmGORUSENIN_NOTU, colmGORUSME_SURE, colmGORUSME_YONU, colmGORUSULEN_CARI_ID, colmGORUSULEN_TEL, colmIS_KATEGORI_ID, colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmREFERANS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmSAAT, colmTAKIP_T, colmTALEP, colmTALEP_ID, colmTARAF_KODU, colmTARAF_SIFAT_ID, colmTARIH, colmTipi });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.GORUSMELER_BIRLESIK_TARAFLIs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();

            //
        }

        private void HESAPLI_KAPSAMLI_GENEL_SORUMLU()
        {
            #region Tablolar

            var colmASIL_ALACAK_DOVIZ_ID = colmnVer("ASIL ALACAK DOVIZ ID", "ASIL_ALACAK_DOVIZ_ID", true, 21, lupDoviz);
            var summaryASIL_ALACAK_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK_DOVIZ_ID", colmASIL_ALACAK_DOVIZ_ID, "", 2);
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmISLEMIS_FAIZ_DOVIZ_ID = colmnVer("ISLEMIS FAIZ DOVIZ ID", "ISLEMIS_FAIZ_DOVIZ_ID", true, 23, lupDoviz);
            var summaryISLEMIS_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ_DOVIZ_ID", colmISLEMIS_FAIZ_DOVIZ_ID, "", 2);
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBSMV_TO_DOVIZ_ID = colmnVer("BSMV TO DOVIZ ID", "BSMV_TO_DOVIZ_ID", true, 25, lupDoviz);
            var summaryBSMV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO_DOVIZ_ID", colmBSMV_TO_DOVIZ_ID, "", 2);
            colmBSMV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TO_DOVIZ_ID";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKKDV_TO_DOVIZ_ID = colmnVer("KKDV TO DOVIZ ID", "KKDV_TO_DOVIZ_ID", true, 27, lupDoviz);
            var summaryKKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO_DOVIZ_ID", colmKKDV_TO_DOVIZ_ID, "", 2);
            colmKKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KKDV_TO_DOVIZ_ID";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKDV_TO_DOVIZ_ID = colmnVer("KDV TO DOVIZ ID", "KDV_TO_DOVIZ_ID", true, 30, lupDoviz);
            var summaryKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO_DOVIZ_ID", colmKDV_TO_DOVIZ_ID, "", 2);
            colmKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KDV_TO_DOVIZ_ID";
            colmKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIH_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IH VEKALET UCRETI DOVIZ ID", "IH_VEKALET_UCRETI_DOVIZ_ID", true, 32, lupDoviz);
            var summaryIH_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI_DOVIZ_ID", colmIH_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIH_GIDERI_DOVIZ_ID = colmnVer("IH GIDERI DOVIZ ID", "IH_GIDERI_DOVIZ_ID", true, 34, lupDoviz);
            var summaryIH_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI_DOVIZ_ID", colmIH_GIDERI_DOVIZ_ID, "", 2);
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IH_GIDERI_DOVIZ_ID";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_HACIZDE_ODENEN_DOVIZ_ID = colmnVer("IT HACIZDE ODENEN DOVIZ ID", "IT_HACIZDE_ODENEN_DOVIZ_ID", true, 36, lupDoviz);
            var summaryIT_HACIZDE_ODENEN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN_DOVIZ_ID", colmIT_HACIZDE_ODENEN_DOVIZ_ID, "", 2);
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = colmnVer("KARSILIKSIZ CEK TAZMINATI DOVIZ ID", "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", true, 38, lupDoviz);
            var summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "", 2);
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmCEK_KOMISYONU_DOVIZ_ID = colmnVer("CEK KOMISYONU DOVIZ ID", "CEK_KOMISYONU_DOVIZ_ID", true, 40, lupDoviz);
            var summaryCEK_KOMISYONU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU_DOVIZ_ID", colmCEK_KOMISYONU_DOVIZ_ID, "", 2);
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_YARGILAMA_GIDERI_DOVIZ_ID = colmnVer("ILAM YARGILAMA GIDERI DOVIZ ID", "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", true, 42, lupDoviz);
            var summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_BK_YARG_ONAMA_DOVIZ_ID = colmnVer("ILAM BK YARG ONAMA DOVIZ ID", "ILAM_BK_YARG_ONAMA_DOVIZ_ID", true, 44, lupDoviz);
            var summaryILAM_BK_YARG_ONAMA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA_DOVIZ_ID", colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "", 2);
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("ILAM TEBLIG GIDERI DOVIZ ID", "ILAM_TEBLIG_GIDERI_DOVIZ_ID", true, 46, lupDoviz);
            var summaryILAM_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI_DOVIZ_ID", colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ILAM INKAR TAZMINATI DOVIZ ID", "ILAM_INKAR_TAZMINATI_DOVIZ_ID", true, 48, lupDoviz);
            var summaryILAM_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI_DOVIZ_ID", colmILAM_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_VEK_UCR_DOVIZ_ID = colmnVer("ILAM VEK UCR DOVIZ ID", "ILAM_VEK_UCR_DOVIZ_ID", true, 50, lupDoviz);
            var summaryILAM_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR_DOVIZ_ID", colmILAM_VEK_UCR_DOVIZ_ID, "", 2);
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOIV_TO_DOVIZ_ID = colmnVer("OIV TO DOVIZ ID", "OIV_TO_DOVIZ_ID", true, 52, lupDoviz);
            var summaryOIV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO_DOVIZ_ID", colmOIV_TO_DOVIZ_ID, "", 2);
            colmOIV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TO_DOVIZ_ID.SummaryItem.FieldName = "OIV_TO_DOVIZ_ID";
            colmOIV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPROTESTO_GIDERI_DOVIZ_ID = colmnVer("PROTESTO GIDERI DOVIZ ID", "PROTESTO_GIDERI_DOVIZ_ID", true, 53, lupDoviz);
            var summaryPROTESTO_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI_DOVIZ_ID", colmPROTESTO_GIDERI_DOVIZ_ID, "", 2);
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIHTAR_GIDERI_DOVIZ_ID = colmnVer("IHTAR GIDERI DOVIZ ID", "IHTAR_GIDERI_DOVIZ_ID", true, 55, lupDoviz);
            var summaryIHTAR_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI_DOVIZ_ID", colmIHTAR_GIDERI_DOVIZ_ID, "", 2);
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TAZMINAT_DOVIZ_ID = colmnVer("OZEL TAZMINAT DOVIZ ID", "OZEL_TAZMINAT_DOVIZ_ID", true, 57, lupDoviz);
            var summaryOZEL_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT_DOVIZ_ID", colmOZEL_TAZMINAT_DOVIZ_ID, "", 2);
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR1_DOVIZ_ID = colmnVer("OZEL TUTAR1 DOVIZ ID", "OZEL_TUTAR1_DOVIZ_ID", true, 61, lupDoviz);
            var summaryOZEL_TUTAR1_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1_DOVIZ_ID", colmOZEL_TUTAR1_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR2_DOVIZ_ID = colmnVer("OZEL TUTAR2 DOVIZ ID", "OZEL_TUTAR2_DOVIZ_ID", true, 64, lupDoviz);
            var summaryOZEL_TUTAR2_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2_DOVIZ_ID", colmOZEL_TUTAR2_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR3_DOVIZ_ID = colmnVer("OZEL TUTAR3 DOVIZ ID", "OZEL_TUTAR3_DOVIZ_ID", true, 67, lupDoviz);
            var summaryOZEL_TUTAR3_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3_DOVIZ_ID", colmOZEL_TUTAR3_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAKIP_CIKISI_DOVIZ_ID = colmnVer("TAKIP CIKISI DOVIZ ID", "TAKIP_CIKISI_DOVIZ_ID", true, 69, lupDoviz);
            var summaryTAKIP_CIKISI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI_DOVIZ_ID", colmTAKIP_CIKISI_DOVIZ_ID, "", 2);
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSONRAKI_FAIZ_DOVIZ_ID = colmnVer("SONRAKI FAIZ DOVIZ ID", "SONRAKI_FAIZ_DOVIZ_ID", true, 71, lupDoviz);
            var summarySONRAKI_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ_DOVIZ_ID", colmSONRAKI_FAIZ_DOVIZ_ID, "", 2);
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSONRAKI_TAZMINAT_DOVIZ_ID = colmnVer("SONRAKI TAZMINAT DOVIZ ID", "SONRAKI_TAZMINAT_DOVIZ_ID", true, 73, lupDoviz);
            var summarySONRAKI_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT_DOVIZ_ID", colmSONRAKI_TAZMINAT_DOVIZ_ID, "", 2);
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBSMV_TS_DOVIZ_ID = colmnVer("BSMV TS DOVIZ ID", "BSMV_TS_DOVIZ_ID", true, 75, lupDoviz);
            var summaryBSMV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS_DOVIZ_ID", colmBSMV_TS_DOVIZ_ID, "", 2);
            colmBSMV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TS_DOVIZ_ID";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOIV_TS_DOVIZ_ID = colmnVer("OIV TS DOVIZ ID", "OIV_TS_DOVIZ_ID", true, 77, lupDoviz);
            var summaryOIV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS_DOVIZ_ID", colmOIV_TS_DOVIZ_ID, "", 2);
            colmOIV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TS_DOVIZ_ID.SummaryItem.FieldName = "OIV_TS_DOVIZ_ID";
            colmOIV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKDV_TS_DOVIZ_ID = colmnVer("KDV TS DOVIZ ID", "KDV_TS_DOVIZ_ID", true, 79, lupDoviz);
            var summaryKDV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS_DOVIZ_ID", colmKDV_TS_DOVIZ_ID, "", 2);
            colmKDV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TS_DOVIZ_ID.SummaryItem.FieldName = "KDV_TS_DOVIZ_ID";
            colmKDV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILK_GIDERLER_DOVIZ_ID = colmnVer("ILK GIDERLER DOVIZ ID", "ILK_GIDERLER_DOVIZ_ID", true, 81, lupDoviz);
            var summaryILK_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER_DOVIZ_ID", colmILK_GIDERLER_DOVIZ_ID, "", 2);
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPESIN_HARC_DOVIZ_ID = colmnVer("PESIN HARC DOVIZ ID", "PESIN_HARC_DOVIZ_ID", true, 83, lupDoviz);
            var summaryPESIN_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC_DOVIZ_ID", colmPESIN_HARC_DOVIZ_ID, "", 2);
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.FieldName = "PESIN_HARC_DOVIZ_ID";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmODENEN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("ODENEN TAHSIL HARCI DOVIZ ID", "ODENEN_TAHSIL_HARCI_DOVIZ_ID", true, 85, lupDoviz);
            var summaryODENEN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI_DOVIZ_ID", colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKALAN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("KALAN TAHSIL HARCI DOVIZ ID", "KALAN_TAHSIL_HARCI_DOVIZ_ID", true, 87, lupDoviz);
            var summaryKALAN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI_DOVIZ_ID", colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmMASAYA_KATILMA_HARCI_DOVIZ_ID = colmnVer("MASAYA KATILMA HARCI DOVIZ ID", "MASAYA_KATILMA_HARCI_DOVIZ_ID", true, 89, lupDoviz);
            var summaryMASAYA_KATILMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI_DOVIZ_ID", colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "", 2);
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPAYLASMA_HARCI_DOVIZ_ID = colmnVer("PAYLASMA HARCI DOVIZ ID", "PAYLASMA_HARCI_DOVIZ_ID", true, 91, lupDoviz);
            var summaryPAYLASMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI_DOVIZ_ID", colmPAYLASMA_HARCI_DOVIZ_ID, "", 2);
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_GIDERLERI_DOVIZ_ID = colmnVer("DAVA GIDERLERI DOVIZ ID", "DAVA_GIDERLERI_DOVIZ_ID", true, 93, lupDoviz);
            var summaryDAVA_GIDERLERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI_DOVIZ_ID", colmDAVA_GIDERLERI_DOVIZ_ID, "", 2);
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDIGER_GIDERLER_DOVIZ_ID = colmnVer("DIGER GIDERLER DOVIZ ID", "DIGER_GIDERLER_DOVIZ_ID", true, 95, lupDoviz);
            var summaryDIGER_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER_DOVIZ_ID", colmDIGER_GIDERLER_DOVIZ_ID, "", 2);
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAKIP_VEKALET_UCRETI_DOVIZ_ID = colmnVer("TAKIP VEKALET UCRETI DOVIZ ID", "TAKIP_VEKALET_UCRETI_DOVIZ_ID", true, 98, lupDoviz);
            var summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI_DOVIZ_ID", colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("DAVA INKAR TAZMINATI DOVIZ ID", "DAVA_INKAR_TAZMINATI_DOVIZ_ID", true, 100, lupDoviz);
            var summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI_DOVIZ_ID", colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_VEKALET_UCRETI_DOVIZ_ID = colmnVer("DAVA VEKALET UCRETI DOVIZ ID", "DAVA_VEKALET_UCRETI_DOVIZ_ID", true, 102, lupDoviz);
            var summaryDAVA_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI_DOVIZ_ID", colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmODEME_TOPLAMI_DOVIZ_ID = colmnVer("ODEME TOPLAMI DOVIZ ID", "ODEME_TOPLAMI_DOVIZ_ID", true, 104, lupDoviz);
            var summaryODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI_DOVIZ_ID", colmODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_ODEME_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME TOPLAMI DOVIZ ID", "TO_ODEME_TOPLAMI_DOVIZ_ID", true, 106, lupDoviz);
            var summaryTO_ODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI_DOVIZ_ID", colmTO_ODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmMAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("MAHSUP TOPLAMI DOVIZ ID", "MAHSUP_TOPLAMI_DOVIZ_ID", true, 108, lupDoviz);
            var summaryMAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI_DOVIZ_ID", colmMAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFERAGAT_TOPLAMI_DOVIZ_ID = colmnVer("FERAGAT TOPLAMI DOVIZ ID", "FERAGAT_TOPLAMI_DOVIZ_ID", true, 111, lupDoviz);
            var summaryFERAGAT_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI_DOVIZ_ID", colmFERAGAT_TOPLAMI_DOVIZ_ID, "", 2);
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmALACAK_TOPLAMI_DOVIZ_ID = colmnVer("ALACAK TOPLAMI DOVIZ ID", "ALACAK_TOPLAMI_DOVIZ_ID", true, 112, lupDoviz);
            var summaryALACAK_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI_DOVIZ_ID", colmALACAK_TOPLAMI_DOVIZ_ID, "", 2);
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKALAN_DOVIZ_ID = colmnVer("KALAN DOVIZ ID", "KALAN_DOVIZ_ID", true, 114, lupDoviz);
            var summaryKALAN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_DOVIZ_ID", colmKALAN_DOVIZ_ID, "", 2);
            colmKALAN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_DOVIZ_ID.SummaryItem.FieldName = "KALAN_DOVIZ_ID";
            colmKALAN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAHLIYE_VEK_UCR_DOVIZ_ID = colmnVer("TAHLIYE VEK UCR DOVIZ ID", "TAHLIYE_VEK_UCR_DOVIZ_ID", true, 116, lupDoviz);
            var summaryTAHLIYE_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR_DOVIZ_ID", colmTAHLIYE_VEK_UCR_DOVIZ_ID, "", 2);
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDIGER_HARC_DOVIZ_ID = colmnVer("DIGER HARC DOVIZ ID", "DIGER_HARC_DOVIZ_ID", true, 118, lupDoviz);
            var summaryDIGER_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC_DOVIZ_ID", colmDIGER_HARC_DOVIZ_ID, "", 2);
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.FieldName = "DIGER_HARC_DOVIZ_ID";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_GIDERI_DOVIZ_ID = colmnVer("TD GIDERI DOVIZ ID", "TD_GIDERI_DOVIZ_ID", true, 120, lupDoviz);
            var summaryTD_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI_DOVIZ_ID", colmTD_GIDERI_DOVIZ_ID, "", 2);
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_GIDERI_DOVIZ_ID";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_BAKIYE_HARC_DOVIZ_ID = colmnVer("TD BAKIYE HARC DOVIZ ID", "TD_BAKIYE_HARC_DOVIZ_ID", true, 122, lupDoviz);
            var summaryTD_BAKIYE_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC_DOVIZ_ID", colmTD_BAKIYE_HARC_DOVIZ_ID, "", 2);
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_VEK_UCR_DOVIZ_ID = colmnVer("TD VEK UCR DOVIZ ID", "TD_VEK_UCR_DOVIZ_ID", true, 124, lupDoviz);
            var summaryTD_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR_DOVIZ_ID", colmTD_VEK_UCR_DOVIZ_ID, "", 2);
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("TD TEBLIG GIDERI DOVIZ ID", "TD_TEBLIG_GIDERI_DOVIZ_ID", true, 126, lupDoviz);
            var summaryTD_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI_DOVIZ_ID", colmTD_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBIRIKMIS_NAFAKA_DOVIZ_ID = colmnVer("BIRIKMIS NAFAKA DOVIZ ID", "BIRIKMIS_NAFAKA_DOVIZ_ID", true, 128, lupDoviz);
            var summaryBIRIKMIS_NAFAKA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA_DOVIZ_ID", colmBIRIKMIS_NAFAKA_DOVIZ_ID, "", 2);
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmICRA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ICRA INKAR TAZMINATI DOVIZ ID", "ICRA_INKAR_TAZMINATI_DOVIZ_ID", true, 130, lupDoviz);
            var summaryICRA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI_DOVIZ_ID", colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAMGA_PULU_DOVIZ_ID = colmnVer("DAMGA PULU DOVIZ ID", "DAMGA_PULU_DOVIZ_ID", true, 132, lupDoviz);
            var summaryDAMGA_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU_DOVIZ_ID", colmDAMGA_PULU_DOVIZ_ID, "", 2);
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.FieldName = "DAMGA_PULU_DOVIZ_ID";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPROTOKOL_MIKTARI_DOVIZ_ID = colmnVer("PROTOKOL MIKTARI DOVIZ ID", "PROTOKOL_MIKTARI_DOVIZ_ID", true, 135, lupDoviz);
            var summaryPROTOKOL_MIKTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI_DOVIZ_ID", colmPROTOKOL_MIKTARI_DOVIZ_ID, "", 2);
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSILIK_TUTARI_DOVIZ_ID = colmnVer("KARSILIK TUTARI DOVIZ ID", "KARSILIK_TUTARI_DOVIZ_ID", true, 139, lupDoviz);
            var summaryKARSILIK_TUTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI_DOVIZ_ID", colmKARSILIK_TUTARI_DOVIZ_ID, "", 2);
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TO MASRAF TOPLAMI DOVIZ ID", "TO_MASRAF_TOPLAMI_DOVIZ_ID", true, 142, lupDoviz);
            var summaryTO_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI_DOVIZ_ID", colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTS_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TS MASRAF TOPLAMI DOVIZ ID", "TS_MASRAF_TOPLAMI_DOVIZ_ID", true, 144, lupDoviz);
            var summaryTS_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI_DOVIZ_ID", colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTUM_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TUM MASRAF TOPLAMI DOVIZ ID", "TUM_MASRAF_TOPLAMI_DOVIZ_ID", true, 146, lupDoviz);
            var summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI_DOVIZ_ID", colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHARC_TOPLAMI_DOVIZ_ID = colmnVer("HARC TOPLAMI DOVIZ ID", "HARC_TOPLAMI_DOVIZ_ID", true, 148, lupDoviz);
            var summaryHARC_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI_DOVIZ_ID", colmHARC_TOPLAMI_DOVIZ_ID, "", 2);
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TO VEKALET TOPLAMI DOVIZ ID", "TO_VEKALET_TOPLAMI_DOVIZ_ID", true, 149, lupDoviz);
            var summaryTO_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI_DOVIZ_ID", colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTS_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TS VEKALET TOPLAMI DOVIZ ID", "TS_VEKALET_TOPLAMI_DOVIZ_ID", true, 152, lupDoviz);
            var summaryTS_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI_DOVIZ_ID", colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTUM_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TUM VEKALET TOPLAMI DOVIZ ID", "TUM_VEKALET_TOPLAMI_DOVIZ_ID", true, 154, lupDoviz);
            var summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI_DOVIZ_ID", colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("KARSI VEKALET TOPLAMI DOVIZ ID", "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", true, 156, lupDoviz);
            var summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFAIZ_TOPLAMI_DOVIZ_ID = colmnVer("FAIZ TOPLAMI DOVIZ ID", "FAIZ_TOPLAMI_DOVIZ_ID", true, 158, lupDoviz);
            var summaryFAIZ_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI_DOVIZ_ID", colmFAIZ_TOPLAMI_DOVIZ_ID, "", 2);
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID = colmnVer("ILAM UCRETLER TOPLAMI DOVIZ ID", "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", true, 160, lupDoviz);
            var summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "", 2);
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IT VEKALET UCRETI DOVIZ ID", "IT_VEKALET_UCRETI_DOVIZ_ID", true, 161, lupDoviz);
            var summaryIT_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI_DOVIZ_ID", colmIT_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_GIDERI_DOVIZ_ID = colmnVer("IT GIDERI DOVIZ ID", "IT_GIDERI_DOVIZ_ID", true, 163, lupDoviz);
            var summaryIT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI_DOVIZ_ID", colmIT_GIDERI_DOVIZ_ID, "", 2);
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IT_GIDERI_DOVIZ_ID";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME MAHSUP TOPLAMI DOVIZ ID", "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", true, 166, lupDoviz);
            var summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBASVURMA_HARCI_DOVIZ_ID = colmnVer("BASVURMA HARCI DOVIZ ID", "BASVURMA_HARCI_DOVIZ_ID", true, 171, lupDoviz);
            var summaryBASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI_DOVIZ_ID", colmBASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmVEKALET_HARCI_DOVIZ_ID = colmnVer("VEKALET HARCI DOVIZ ID", "VEKALET_HARCI_DOVIZ_ID", true, 173, lupDoviz);
            var summaryVEKALET_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI_DOVIZ_ID", colmVEKALET_HARCI_DOVIZ_ID, "", 2);
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmVEKALET_PULU_DOVIZ_ID = colmnVer("VEKALET PULU DOVIZ ID", "VEKALET_PULU_DOVIZ_ID", true, 175, lupDoviz);
            var summaryVEKALET_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU_DOVIZ_ID", colmVEKALET_PULU_DOVIZ_ID, "", 2);
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_PULU_DOVIZ_ID";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIFLAS_BASVURMA_HARCI_DOVIZ_ID = colmnVer("IFLAS BASVURMA HARCI DOVIZ ID", "IFLAS_BASVURMA_HARCI_DOVIZ_ID", true, 177, lupDoviz);
            var summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI_DOVIZ_ID", colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID = colmnVer("IFLASIN ACILMASI HARCI DOVIZ ID", "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", true, 179, lupDoviz);
            var summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "", 2);
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILK_TEBLIGAT_GIDERI_DOVIZ_ID = colmnVer("ILK TEBLIGAT GIDERI DOVIZ ID", "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", true, 181, lupDoviz);
            var summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "", 2);
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAHLIYE_HARCI_DOVIZ_ID = colmnVer("TAHLIYE HARCI DOVIZ ID", "TAHLIYE_HARCI_DOVIZ_ID", true, 183, lupDoviz);
            var summaryTAHLIYE_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI_DOVIZ_ID", colmTAHLIYE_HARCI_DOVIZ_ID, "", 2);
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTESLIM_HARCI_DOVIZ_ID = colmnVer("TESLIM HARCI DOVIZ ID", "TESLIM_HARCI_DOVIZ_ID", true, 185, lupDoviz);
            var summaryTESLIM_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI_DOVIZ_ID", colmTESLIM_HARCI_DOVIZ_ID, "", 2);
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFERAGAT_HARCI_DOVIZ_ID = colmnVer("FERAGAT HARCI DOVIZ ID", "FERAGAT_HARCI_DOVIZ_ID", true, 187, lupDoviz);
            var summaryFERAGAT_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI_DOVIZ_ID", colmFERAGAT_HARCI_DOVIZ_ID, "", 2);
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_YONETIMG_TAZMINATI_DOVIZ_ID = colmnVer("TO YONETIMG TAZMINATI DOVIZ ID", "TO_YONETIMG_TAZMINATI_DOVIZ_ID", true, 188, lupDoviz);
            var summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI_DOVIZ_ID", colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "", 2);
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSORUMLU_AVUKAT_CARI_ID = colmnVer("SORUMLU AVUKAT CARI ID", "SORUMLU_AVUKAT_CARI_ID", true, 1, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTALEP_ADI = colmnVer("TALEP ADI", "TALEP_ADI", true, 2, null);
            var colmFORM_TIP_ID = colmnVer("FORM TIP ID", "FORM_TIP_ID", true, 3, TablesGrids.GetTI_KOD_FORM_TIPLookup());
            var colmFOY_DURUM_ID = colmnVer("FOY DURUM ID", "FOY_DURUM_ID", true, 4, TablesGrids.GetTDI_KOD_FOY_DURUMLookup());
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 5, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 6, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 7, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 8, null);
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 9, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 10, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmICRA_OZEL_KOD1_ID = colmnVer("ICRA OZEL KOD1 ID", "ICRA_OZEL_KOD1_ID", true, 11, null);
            var colmICRA_OZEL_KOD2_ID = colmnVer("ICRA OZEL KOD2 ID", "ICRA_OZEL_KOD2_ID", true, 12, null);
            var colmICRA_OZEL_KOD3_ID = colmnVer("ICRA OZEL KOD3 ID", "ICRA_OZEL_KOD3_ID", true, 13, null);
            var colmICRA_OZEL_KOD4_ID = colmnVer("ICRA OZEL KOD4 ID", "ICRA_OZEL_KOD4_ID", true, 14, null);
            var colmTAKIBIN_AVUKATA_INTIKAL_TARIHI = colmnVer("TAKIBIN AVUKATA INTIKAL TARIHI", "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true, 15, null);
            var colmFOY_ARSIV_TARIHI = colmnVer("FOY ARSIV TARIHI", "FOY_ARSIV_TARIHI", true, 16, null);
            var colmFOY_INFAZ_TARIHI = colmnVer("FOY INFAZ TARIHI", "FOY_INFAZ_TARIHI", true, 17, null);
            var colmTAKIBIN_MUVEKKILE_IADE_TARIHI = colmnVer("TAKIBIN MUVEKKILE IADE TARIHI", "TAKIBIN_MUVEKKILE_IADE_TARIHI", true, 18, null);
            var colmSON_HESAP_TARIHI = colmnVer("SON HESAP TARIHI", "SON_HESAP_TARIHI", true, 19, null);
            var colmBIR_YIL_KAC_GUN = colmnVer("BIR YIL KAC GUN", "BIR_YIL_KAC_GUN", true, 20, null);
            var colmASIL_ALACAK = colmnVer("ASIL ALACAK", "ASIL_ALACAK", true, 22, null, colmASIL_ALACAK_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryASIL_ALACAK = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK", colmASIL_ALACAK, "", 1);
            colmASIL_ALACAK.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmASIL_ALACAK.SummaryItem.FieldName = "ASIL_ALACAK";
            colmASIL_ALACAK.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK.SummaryItem.Tag = 1;

            var colmISLEMIS_FAIZ = colmnVer("ISLEMIS FAIZ", "ISLEMIS_FAIZ", true, 24, null, colmISLEMIS_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryISLEMIS_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ", colmISLEMIS_FAIZ, "", 1);
            colmISLEMIS_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmISLEMIS_FAIZ.SummaryItem.FieldName = "ISLEMIS_FAIZ";
            colmISLEMIS_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ.SummaryItem.Tag = 1;

            var colmBSMV_TO = colmnVer("BSMV TO", "BSMV_TO", true, 26, null, colmBSMV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBSMV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO", colmBSMV_TO, "", 1);
            colmBSMV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TO.SummaryItem.FieldName = "BSMV_TO";
            colmBSMV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO.SummaryItem.Tag = 1;

            var colmKKDV_TO = colmnVer("KKDV TO", "KKDV_TO", true, 28, null, colmKKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO", colmKKDV_TO, "", 1);
            colmKKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKKDV_TO.SummaryItem.FieldName = "KKDV_TO";
            colmKKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO.SummaryItem.Tag = 1;

            var colmOIV_TO = colmnVer("OIV TO", "OIV_TO", true, 29, null, colmOIV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOIV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO", colmOIV_TO, "", 1);
            colmOIV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TO.SummaryItem.FieldName = "OIV_TO";
            colmOIV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO.SummaryItem.Tag = 1;

            var colmKDV_TO = colmnVer("KDV TO", "KDV_TO", true, 31, null, colmKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO", colmKDV_TO, "", 1);
            colmKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TO.SummaryItem.FieldName = "KDV_TO";
            colmKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO.SummaryItem.Tag = 1;

            var colmIH_VEKALET_UCRETI = colmnVer("IH VEKALET UCRETI", "IH_VEKALET_UCRETI", true, 33, null, colmIH_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI", colmIH_VEKALET_UCRETI, "", 1);
            colmIH_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_VEKALET_UCRETI.SummaryItem.FieldName = "IH_VEKALET_UCRETI";
            colmIH_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIH_GIDERI = colmnVer("IH GIDERI", "IH_GIDERI", true, 35, null, colmIH_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI", colmIH_GIDERI, "", 1);
            colmIH_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_GIDERI.SummaryItem.FieldName = "IH_GIDERI";
            colmIH_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI.SummaryItem.Tag = 1;

            var colmIT_HACIZDE_ODENEN = colmnVer("IT HACIZDE ODENEN", "IT_HACIZDE_ODENEN", true, 37, null, colmIT_HACIZDE_ODENEN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_HACIZDE_ODENEN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN", colmIT_HACIZDE_ODENEN, "", 1);
            colmIT_HACIZDE_ODENEN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_HACIZDE_ODENEN.SummaryItem.FieldName = "IT_HACIZDE_ODENEN";
            colmIT_HACIZDE_ODENEN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN.SummaryItem.Tag = 1;

            var colmKARSILIKSIZ_CEK_TAZMINATI = colmnVer("KARSILIKSIZ CEK TAZMINATI", "KARSILIKSIZ_CEK_TAZMINATI", true, 39, null, colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIKSIZ_CEK_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI", colmKARSILIKSIZ_CEK_TAZMINATI, "", 1);
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.Tag = 1;

            var colmCEK_KOMISYONU = colmnVer("CEK KOMISYONU", "CEK_KOMISYONU", true, 41, null, colmCEK_KOMISYONU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryCEK_KOMISYONU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU", colmCEK_KOMISYONU, "", 1);
            colmCEK_KOMISYONU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmCEK_KOMISYONU.SummaryItem.FieldName = "CEK_KOMISYONU";
            colmCEK_KOMISYONU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU.SummaryItem.Tag = 1;

            var colmILAM_YARGILAMA_GIDERI = colmnVer("ILAM YARGILAMA GIDERI", "ILAM_YARGILAMA_GIDERI", true, 43, null, colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_YARGILAMA_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI", colmILAM_YARGILAMA_GIDERI, "", 1);
            colmILAM_YARGILAMA_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_BK_YARG_ONAMA = colmnVer("ILAM BK YARG ONAMA", "ILAM_BK_YARG_ONAMA", true, 45, null, colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_BK_YARG_ONAMA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA", colmILAM_BK_YARG_ONAMA, "", 1);
            colmILAM_BK_YARG_ONAMA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_BK_YARG_ONAMA.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA";
            colmILAM_BK_YARG_ONAMA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA.SummaryItem.Tag = 1;

            var colmILAM_TEBLIG_GIDERI = colmnVer("ILAM TEBLIG GIDERI", "ILAM_TEBLIG_GIDERI", true, 47, null, colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI", colmILAM_TEBLIG_GIDERI, "", 1);
            colmILAM_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_TEBLIG_GIDERI.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI";
            colmILAM_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_INKAR_TAZMINATI = colmnVer("ILAM INKAR TAZMINATI", "ILAM_INKAR_TAZMINATI", true, 49, null, colmILAM_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI", colmILAM_INKAR_TAZMINATI, "", 1);
            colmILAM_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_INKAR_TAZMINATI.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI";
            colmILAM_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmILAM_VEK_UCR = colmnVer("ILAM VEK UCR", "ILAM_VEK_UCR", true, 51, null, colmILAM_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR", colmILAM_VEK_UCR, "", 1);
            colmILAM_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_VEK_UCR.SummaryItem.FieldName = "ILAM_VEK_UCR";
            colmILAM_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR.SummaryItem.Tag = 1;

            var colmPROTESTO_GIDERI = colmnVer("PROTESTO GIDERI", "PROTESTO_GIDERI", true, 54, null, colmPROTESTO_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTESTO_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI", colmPROTESTO_GIDERI, "", 1);
            colmPROTESTO_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTESTO_GIDERI.SummaryItem.FieldName = "PROTESTO_GIDERI";
            colmPROTESTO_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI.SummaryItem.Tag = 1;

            var colmIHTAR_GIDERI = colmnVer("IHTAR GIDERI", "IHTAR_GIDERI", true, 56, null, colmIHTAR_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIHTAR_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI", colmIHTAR_GIDERI, "", 1);
            colmIHTAR_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIHTAR_GIDERI.SummaryItem.FieldName = "IHTAR_GIDERI";
            colmIHTAR_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI.SummaryItem.Tag = 1;

            var colmOZEL_TAZMINAT = colmnVer("OZEL TAZMINAT", "OZEL_TAZMINAT", true, 58, null, colmOZEL_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT", colmOZEL_TAZMINAT, "", 1);
            colmOZEL_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TAZMINAT.SummaryItem.FieldName = "OZEL_TAZMINAT";
            colmOZEL_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR1_FAIZ_ORANI = colmnVer("OZEL TUTAR1 FAIZ ORANI", "OZEL_TUTAR1_FAIZ_ORANI", true, 59, null);
            var colmOZEL_TUTAR1_KONU_ID = colmnVer("OZEL TUTAR1 KONU ID", "OZEL_TUTAR1_KONU_ID", true, 60, null);
            var colmOZEL_TUTAR1 = colmnVer("OZEL TUTAR1", "OZEL_TUTAR1", true, 62, null, colmOZEL_TUTAR1_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR1 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1", colmOZEL_TUTAR1, "", 1);
            colmOZEL_TUTAR1.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR1.SummaryItem.FieldName = "OZEL_TUTAR1";
            colmOZEL_TUTAR1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR2_KONU_ID = colmnVer("OZEL TUTAR2 KONU ID", "OZEL_TUTAR2_KONU_ID", true, 63, null);
            var colmOZEL_TUTAR2 = colmnVer("OZEL TUTAR2", "OZEL_TUTAR2", true, 65, null, colmOZEL_TUTAR2_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR2 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2", colmOZEL_TUTAR2, "", 1);
            colmOZEL_TUTAR2.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR2.SummaryItem.FieldName = "OZEL_TUTAR2";
            colmOZEL_TUTAR2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR3_KONU_ID = colmnVer("OZEL TUTAR3 KONU ID", "OZEL_TUTAR3_KONU_ID", true, 66, null);
            var colmOZEL_TUTAR3 = colmnVer("OZEL TUTAR3", "OZEL_TUTAR3", true, 68, null, colmOZEL_TUTAR3_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR3 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3", colmOZEL_TUTAR3, "", 1);
            colmOZEL_TUTAR3.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR3.SummaryItem.FieldName = "OZEL_TUTAR3";
            colmOZEL_TUTAR3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3.SummaryItem.Tag = 1;

            var colmTAKIP_CIKISI = colmnVer("TAKIP CIKISI", "TAKIP_CIKISI", true, 70, null, colmTAKIP_CIKISI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_CIKISI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI", colmTAKIP_CIKISI, "", 1);
            colmTAKIP_CIKISI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_CIKISI.SummaryItem.FieldName = "TAKIP_CIKISI";
            colmTAKIP_CIKISI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI.SummaryItem.Tag = 1;

            var colmSONRAKI_FAIZ = colmnVer("SONRAKI FAIZ", "SONRAKI_FAIZ", true, 72, null, colmSONRAKI_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ", colmSONRAKI_FAIZ, "", 1);
            colmSONRAKI_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_FAIZ.SummaryItem.FieldName = "SONRAKI_FAIZ";
            colmSONRAKI_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ.SummaryItem.Tag = 1;

            var colmSONRAKI_TAZMINAT = colmnVer("SONRAKI TAZMINAT", "SONRAKI_TAZMINAT", true, 74, null, colmSONRAKI_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT", colmSONRAKI_TAZMINAT, "", 1);
            colmSONRAKI_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_TAZMINAT.SummaryItem.FieldName = "SONRAKI_TAZMINAT";
            colmSONRAKI_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT.SummaryItem.Tag = 1;

            var colmBSMV_TS = colmnVer("BSMV TS", "BSMV_TS", true, 76, null, colmBSMV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBSMV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS", colmBSMV_TS, "", 1);
            colmBSMV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TS.SummaryItem.FieldName = "BSMV_TS";
            colmBSMV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS.SummaryItem.Tag = 1;

            var colmOIV_TS = colmnVer("OIV TS", "OIV_TS", true, 78, null, colmOIV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOIV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS", colmOIV_TS, "", 1);
            colmOIV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TS.SummaryItem.FieldName = "OIV_TS";
            colmOIV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS.SummaryItem.Tag = 1;

            var colmKDV_TS = colmnVer("KDV TS", "KDV_TS", true, 80, null, colmKDV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKDV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS", colmKDV_TS, "", 1);
            colmKDV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TS.SummaryItem.FieldName = "KDV_TS";
            colmKDV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS.SummaryItem.Tag = 1;

            var colmILK_GIDERLER = colmnVer("ILK GIDERLER", "ILK_GIDERLER", true, 82, null, colmILK_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER", colmILK_GIDERLER, "", 1);
            colmILK_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_GIDERLER.SummaryItem.FieldName = "ILK_GIDERLER";
            colmILK_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER.SummaryItem.Tag = 1;

            var colmPESIN_HARC = colmnVer("PESIN HARC", "PESIN_HARC", true, 84, null, colmPESIN_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPESIN_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC", colmPESIN_HARC, "", 1);
            colmPESIN_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPESIN_HARC.SummaryItem.FieldName = "PESIN_HARC";
            colmPESIN_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC.SummaryItem.Tag = 1;

            var colmODENEN_TAHSIL_HARCI = colmnVer("ODENEN TAHSIL HARCI", "ODENEN_TAHSIL_HARCI", true, 86, null, colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODENEN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI", colmODENEN_TAHSIL_HARCI, "", 1);
            colmODENEN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODENEN_TAHSIL_HARCI.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI";
            colmODENEN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmKALAN_TAHSIL_HARCI = colmnVer("KALAN TAHSIL HARCI", "KALAN_TAHSIL_HARCI", true, 88, null, colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI", colmKALAN_TAHSIL_HARCI, "", 1);
            colmKALAN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN_TAHSIL_HARCI.SummaryItem.FieldName = "KALAN_TAHSIL_HARCI";
            colmKALAN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmMASAYA_KATILMA_HARCI = colmnVer("MASAYA KATILMA HARCI", "MASAYA_KATILMA_HARCI", true, 90, null, colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMASAYA_KATILMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI", colmMASAYA_KATILMA_HARCI, "", 1);
            colmMASAYA_KATILMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMASAYA_KATILMA_HARCI.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI";
            colmMASAYA_KATILMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI.SummaryItem.Tag = 1;

            var colmPAYLASMA_HARCI = colmnVer("PAYLASMA HARCI", "PAYLASMA_HARCI", true, 92, null, colmPAYLASMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPAYLASMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI", colmPAYLASMA_HARCI, "", 1);
            colmPAYLASMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPAYLASMA_HARCI.SummaryItem.FieldName = "PAYLASMA_HARCI";
            colmPAYLASMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI.SummaryItem.Tag = 1;

            var colmDAVA_GIDERLERI = colmnVer("DAVA GIDERLERI", "DAVA_GIDERLERI", true, 94, null, colmDAVA_GIDERLERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_GIDERLERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI", colmDAVA_GIDERLERI, "", 1);
            colmDAVA_GIDERLERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_GIDERLERI.SummaryItem.FieldName = "DAVA_GIDERLERI";
            colmDAVA_GIDERLERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI.SummaryItem.Tag = 1;

            var colmDIGER_GIDERLER = colmnVer("DIGER GIDERLER", "DIGER_GIDERLER", true, 96, null, colmDIGER_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER", colmDIGER_GIDERLER, "", 1);
            colmDIGER_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_GIDERLER.SummaryItem.FieldName = "DIGER_GIDERLER";
            colmDIGER_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER.SummaryItem.Tag = 1;

            var colmTAKIP_VEKALET_UCRETI_KATSAYI = colmnVer("TAKIP VEKALET UCRETI KATSAYI", "TAKIP_VEKALET_UCRETI_KATSAYI", true, 97, null);
            var colmTAKIP_VEKALET_UCRETI = colmnVer("TAKIP VEKALET UCRETI", "TAKIP_VEKALET_UCRETI", true, 99, null, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI", colmTAKIP_VEKALET_UCRETI, "", 1);
            colmTAKIP_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmDAVA_INKAR_TAZMINATI = colmnVer("DAVA INKAR TAZMINATI", "DAVA_INKAR_TAZMINATI", true, 101, null, colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI", colmDAVA_INKAR_TAZMINATI, "", 1);
            colmDAVA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAVA_VEKALET_UCRETI = colmnVer("DAVA VEKALET UCRETI", "DAVA_VEKALET_UCRETI", true, 103, null, colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI", colmDAVA_VEKALET_UCRETI, "", 1);
            colmDAVA_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_VEKALET_UCRETI.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI";
            colmDAVA_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmODEME_TOPLAMI = colmnVer("ODEME TOPLAMI", "ODEME_TOPLAMI", true, 105, null, colmODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI", colmODEME_TOPLAMI, "", 1);
            colmODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODEME_TOPLAMI.SummaryItem.FieldName = "ODEME_TOPLAMI";
            colmODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_ODEME_TOPLAMI = colmnVer("TO ODEME TOPLAMI", "TO_ODEME_TOPLAMI", true, 107, null, colmTO_ODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI", colmTO_ODEME_TOPLAMI, "", 1);
            colmTO_ODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_TOPLAMI";
            colmTO_ODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmMAHSUP_TOPLAMI = colmnVer("MAHSUP TOPLAMI", "MAHSUP_TOPLAMI", true, 109, null, colmMAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI", colmMAHSUP_TOPLAMI, "", 1);
            colmMAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMAHSUP_TOPLAMI.SummaryItem.FieldName = "MAHSUP_TOPLAMI";
            colmMAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmFERAGAT_TOPLAMI = colmnVer("FERAGAT TOPLAMI", "FERAGAT_TOPLAMI", true, 110, null, colmFERAGAT_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI", colmFERAGAT_TOPLAMI, "", 1);
            colmFERAGAT_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_TOPLAMI.SummaryItem.FieldName = "FERAGAT_TOPLAMI";
            colmFERAGAT_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI.SummaryItem.Tag = 1;

            var colmALACAK_TOPLAMI = colmnVer("ALACAK TOPLAMI", "ALACAK_TOPLAMI", true, 113, null, colmALACAK_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryALACAK_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI", colmALACAK_TOPLAMI, "", 1);
            colmALACAK_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmALACAK_TOPLAMI.SummaryItem.FieldName = "ALACAK_TOPLAMI";
            colmALACAK_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI.SummaryItem.Tag = 1;

            var colmKALAN = colmnVer("KALAN", "KALAN", true, 115, null, colmKALAN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN", colmKALAN, "", 1);
            colmKALAN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN.SummaryItem.FieldName = "KALAN";
            colmKALAN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN.SummaryItem.Tag = 1;

            var colmTAHLIYE_VEK_UCR = colmnVer("TAHLIYE VEK UCR", "TAHLIYE_VEK_UCR", true, 117, null, colmTAHLIYE_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR", colmTAHLIYE_VEK_UCR, "", 1);
            colmTAHLIYE_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_VEK_UCR.SummaryItem.FieldName = "TAHLIYE_VEK_UCR";
            colmTAHLIYE_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR.SummaryItem.Tag = 1;

            var colmDIGER_HARC = colmnVer("DIGER HARC", "DIGER_HARC", true, 119, null, colmDIGER_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC", colmDIGER_HARC, "", 1);
            colmDIGER_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_HARC.SummaryItem.FieldName = "DIGER_HARC";
            colmDIGER_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC.SummaryItem.Tag = 1;

            var colmTD_GIDERI = colmnVer("TD GIDERI", "TD_GIDERI", true, 121, null, colmTD_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI", colmTD_GIDERI, "", 1);
            colmTD_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_GIDERI.SummaryItem.FieldName = "TD_GIDERI";
            colmTD_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI.SummaryItem.Tag = 1;

            var colmTD_BAKIYE_HARC = colmnVer("TD BAKIYE HARC", "TD_BAKIYE_HARC", true, 123, null, colmTD_BAKIYE_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_BAKIYE_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC", colmTD_BAKIYE_HARC, "", 1);
            colmTD_BAKIYE_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_BAKIYE_HARC.SummaryItem.FieldName = "TD_BAKIYE_HARC";
            colmTD_BAKIYE_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC.SummaryItem.Tag = 1;

            var colmTD_VEK_UCR = colmnVer("TD VEK UCR", "TD_VEK_UCR", true, 125, null, colmTD_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR", colmTD_VEK_UCR, "", 1);
            colmTD_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_VEK_UCR.SummaryItem.FieldName = "TD_VEK_UCR";
            colmTD_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR.SummaryItem.Tag = 1;

            var colmTD_TEBLIG_GIDERI = colmnVer("TD TEBLIG GIDERI", "TD_TEBLIG_GIDERI", true, 127, null, colmTD_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI", colmTD_TEBLIG_GIDERI, "", 1);
            colmTD_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_TEBLIG_GIDERI.SummaryItem.FieldName = "TD_TEBLIG_GIDERI";
            colmTD_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmBIRIKMIS_NAFAKA = colmnVer("BIRIKMIS NAFAKA", "BIRIKMIS_NAFAKA", true, 129, null, colmBIRIKMIS_NAFAKA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIKMIS_NAFAKA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA", colmBIRIKMIS_NAFAKA, "", 1);
            colmBIRIKMIS_NAFAKA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIKMIS_NAFAKA.SummaryItem.FieldName = "BIRIKMIS_NAFAKA";
            colmBIRIKMIS_NAFAKA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA.SummaryItem.Tag = 1;

            var colmICRA_INKAR_TAZMINATI = colmnVer("ICRA INKAR TAZMINATI", "ICRA_INKAR_TAZMINATI", true, 131, null, colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryICRA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI", colmICRA_INKAR_TAZMINATI, "", 1);
            colmICRA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmICRA_INKAR_TAZMINATI.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI";
            colmICRA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAMGA_PULU = colmnVer("DAMGA PULU", "DAMGA_PULU", true, 133, null, colmDAMGA_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAMGA_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU", colmDAMGA_PULU, "", 1);
            colmDAMGA_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAMGA_PULU.SummaryItem.FieldName = "DAMGA_PULU";
            colmDAMGA_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU.SummaryItem.Tag = 1;

            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 134, null);
            var colmPROTOKOL_MIKTARI = colmnVer("PROTOKOL MIKTARI", "PROTOKOL_MIKTARI", true, 136, null, colmPROTOKOL_MIKTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTOKOL_MIKTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI", colmPROTOKOL_MIKTARI, "", 1);
            colmPROTOKOL_MIKTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTOKOL_MIKTARI.SummaryItem.FieldName = "PROTOKOL_MIKTARI";
            colmPROTOKOL_MIKTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI.SummaryItem.Tag = 1;

            var colmPROTOKOL_FAIZ_ORANI = colmnVer("PROTOKOL FAIZ ORANI", "PROTOKOL_FAIZ_ORANI", true, 137, null);
            var colmPROTOKOL_TARIHI = colmnVer("PROTOKOL TARIHI", "PROTOKOL_TARIHI", true, 138, null);
            var colmKARSILIK_TUTARI = colmnVer("KARSILIK TUTARI", "KARSILIK_TUTARI", true, 140, null, colmKARSILIK_TUTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIK_TUTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI", colmKARSILIK_TUTARI, "", 1);
            colmKARSILIK_TUTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIK_TUTARI.SummaryItem.FieldName = "KARSILIK_TUTARI";
            colmKARSILIK_TUTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI.SummaryItem.Tag = 1;

            var colmTO_MASRAF_TOPLAMI = colmnVer("TO MASRAF TOPLAMI", "TO_MASRAF_TOPLAMI", true, 141, null, colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI", colmTO_MASRAF_TOPLAMI, "", 1);
            colmTO_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_MASRAF_TOPLAMI.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI";
            colmTO_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_MASRAF_TOPLAMI = colmnVer("TS MASRAF TOPLAMI", "TS_MASRAF_TOPLAMI", true, 143, null, colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI", colmTS_MASRAF_TOPLAMI, "", 1);
            colmTS_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_MASRAF_TOPLAMI.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI";
            colmTS_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_MASRAF_TOPLAMI = colmnVer("TUM MASRAF TOPLAMI", "TUM_MASRAF_TOPLAMI", true, 145, null, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI", colmTUM_MASRAF_TOPLAMI, "", 1);
            colmTUM_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmHARC_TOPLAMI = colmnVer("HARC TOPLAMI", "HARC_TOPLAMI", true, 147, null, colmHARC_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHARC_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI", colmHARC_TOPLAMI, "", 1);
            colmHARC_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHARC_TOPLAMI.SummaryItem.FieldName = "HARC_TOPLAMI";
            colmHARC_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_VEKALET_TOPLAMI = colmnVer("TO VEKALET TOPLAMI", "TO_VEKALET_TOPLAMI", true, 150, null, colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI", colmTO_VEKALET_TOPLAMI, "", 1);
            colmTO_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_VEKALET_TOPLAMI.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI";
            colmTO_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_VEKALET_TOPLAMI = colmnVer("TS VEKALET TOPLAMI", "TS_VEKALET_TOPLAMI", true, 151, null, colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI", colmTS_VEKALET_TOPLAMI, "", 1);
            colmTS_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_VEKALET_TOPLAMI.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI";
            colmTS_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_VEKALET_TOPLAMI = colmnVer("TUM VEKALET TOPLAMI", "TUM_VEKALET_TOPLAMI", true, 153, null, colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI", colmTUM_VEKALET_TOPLAMI, "", 1);
            colmTUM_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmKARSI_VEKALET_TOPLAMI = colmnVer("KARSI VEKALET TOPLAMI", "KARSI_VEKALET_TOPLAMI", true, 155, null, colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSI_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI", colmKARSI_VEKALET_TOPLAMI, "", 1);
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmFAIZ_TOPLAMI = colmnVer("FAIZ TOPLAMI", "FAIZ_TOPLAMI", true, 157, null, colmFAIZ_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFAIZ_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI", colmFAIZ_TOPLAMI, "", 1);
            colmFAIZ_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFAIZ_TOPLAMI.SummaryItem.FieldName = "FAIZ_TOPLAMI";
            colmFAIZ_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI.SummaryItem.Tag = 1;

            var colmILAM_UCRETLER_TOPLAMI = colmnVer("ILAM UCRETLER TOPLAMI", "ILAM_UCRETLER_TOPLAMI", true, 159, null, colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_UCRETLER_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI", colmILAM_UCRETLER_TOPLAMI, "", 1);
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.Tag = 1;

            var colmIT_VEKALET_UCRETI = colmnVer("IT VEKALET UCRETI", "IT_VEKALET_UCRETI", true, 162, null, colmIT_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI", colmIT_VEKALET_UCRETI, "", 1);
            colmIT_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_VEKALET_UCRETI.SummaryItem.FieldName = "IT_VEKALET_UCRETI";
            colmIT_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIT_GIDERI = colmnVer("IT GIDERI", "IT_GIDERI", true, 164, null, colmIT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI", colmIT_GIDERI, "", 1);
            colmIT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_GIDERI.SummaryItem.FieldName = "IT_GIDERI";
            colmIT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI.SummaryItem.Tag = 1;

            var colmTO_ODEME_MAHSUP_TOPLAMI = colmnVer("TO ODEME MAHSUP TOPLAMI", "TO_ODEME_MAHSUP_TOPLAMI", true, 165, null, colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_MAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI", colmTO_ODEME_MAHSUP_TOPLAMI, "", 1);
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmPAYLASIM_TIPI = colmnVer("PAYLASIM TIPI", "PAYLASIM_TIPI", true, 167, null);
            var colmTS_HESAP_TIP_ID = colmnVer("TS HESAP TIP ID", "TS_HESAP_TIP_ID", true, 168, TablesGrids.GetAV001_TI_KOD_HESAP_TIPLookup());
            var colmTO_HESAP_TIP_ID = colmnVer("TO HESAP TIP ID", "TO_HESAP_TIP_ID", true, 169, TablesGrids.GetAV001_TI_KOD_HESAP_TIPLookup());
            var colmBASVURMA_HARCI = colmnVer("BASVURMA HARCI", "BASVURMA_HARCI", true, 170, null, colmBASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI", colmBASVURMA_HARCI, "", 1);
            colmBASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBASVURMA_HARCI.SummaryItem.FieldName = "BASVURMA_HARCI";
            colmBASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_HARCI = colmnVer("VEKALET HARCI", "VEKALET_HARCI", true, 172, null, colmVEKALET_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI", colmVEKALET_HARCI, "", 1);
            colmVEKALET_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_HARCI.SummaryItem.FieldName = "VEKALET_HARCI";
            colmVEKALET_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_PULU = colmnVer("VEKALET PULU", "VEKALET_PULU", true, 174, null, colmVEKALET_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU", colmVEKALET_PULU, "", 1);
            colmVEKALET_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_PULU.SummaryItem.FieldName = "VEKALET_PULU";
            colmVEKALET_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU.SummaryItem.Tag = 1;

            var colmIFLAS_BASVURMA_HARCI = colmnVer("IFLAS BASVURMA HARCI", "IFLAS_BASVURMA_HARCI", true, 176, null, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLAS_BASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI", colmIFLAS_BASVURMA_HARCI, "", 1);
            colmIFLAS_BASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmIFLASIN_ACILMASI_HARCI = colmnVer("IFLASIN ACILMASI HARCI", "IFLASIN_ACILMASI_HARCI", true, 178, null, colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLASIN_ACILMASI_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI", colmIFLASIN_ACILMASI_HARCI, "", 1);
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.Tag = 1;

            var colmILK_TEBLIGAT_GIDERI = colmnVer("ILK TEBLIGAT GIDERI", "ILK_TEBLIGAT_GIDERI", true, 180, null, colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_TEBLIGAT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI", colmILK_TEBLIGAT_GIDERI, "", 1);
            colmILK_TEBLIGAT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI.SummaryItem.Tag = 1;

            var colmTAHLIYE_HARCI = colmnVer("TAHLIYE HARCI", "TAHLIYE_HARCI", true, 182, null, colmTAHLIYE_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI", colmTAHLIYE_HARCI, "", 1);
            colmTAHLIYE_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_HARCI.SummaryItem.FieldName = "TAHLIYE_HARCI";
            colmTAHLIYE_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI.SummaryItem.Tag = 1;

            var colmTESLIM_HARCI = colmnVer("TESLIM HARCI", "TESLIM_HARCI", true, 184, null, colmTESLIM_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTESLIM_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI", colmTESLIM_HARCI, "", 1);
            colmTESLIM_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTESLIM_HARCI.SummaryItem.FieldName = "TESLIM_HARCI";
            colmTESLIM_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI.SummaryItem.Tag = 1;

            var colmFERAGAT_HARCI = colmnVer("FERAGAT HARCI", "FERAGAT_HARCI", true, 186, null, colmFERAGAT_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI", colmFERAGAT_HARCI, "", 1);
            colmFERAGAT_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_HARCI.SummaryItem.FieldName = "FERAGAT_HARCI";
            colmFERAGAT_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI.SummaryItem.Tag = 1;

            var colmTO_YONETIMG_TAZMINATI = colmnVer("TO YONETIMG TAZMINATI", "TO_YONETIMG_TAZMINATI", true, 189, null, colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_YONETIMG_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI", colmTO_YONETIMG_TAZMINATI, "", 1);
            colmTO_YONETIMG_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI.SummaryItem.Tag = 1;

            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 190, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTAKIP_TALEP_ID = colmnVer("TAKIP TALEP ID", "TAKIP_TALEP_ID", true, 191, TablesGrids.GetTI_KOD_TAKIP_TALEPLookup());

            #endregion Tablolar

            var grid = (GridView)gridRaporCntrol.MainView;

            #region AddRange

            grid.Columns.AddRange(new[]
                                      {
                                          colmASIL_ALACAK_DOVIZ_ID, colmISLEMIS_FAIZ_DOVIZ_ID, colmBSMV_TO_DOVIZ_ID,
                                          colmKKDV_TO_DOVIZ_ID, colmKDV_TO_DOVIZ_ID, colmIH_VEKALET_UCRETI_DOVIZ_ID,
                                          colmIH_GIDERI_DOVIZ_ID, colmIT_HACIZDE_ODENEN_DOVIZ_ID,
                                          colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, colmCEK_KOMISYONU_DOVIZ_ID,
                                          colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, colmILAM_BK_YARG_ONAMA_DOVIZ_ID,
                                          colmILAM_TEBLIG_GIDERI_DOVIZ_ID, colmILAM_INKAR_TAZMINATI_DOVIZ_ID,
                                          colmILAM_VEK_UCR_DOVIZ_ID, colmOIV_TO_DOVIZ_ID, colmPROTESTO_GIDERI_DOVIZ_ID,
                                          colmIHTAR_GIDERI_DOVIZ_ID, colmOZEL_TAZMINAT_DOVIZ_ID, colmOZEL_TUTAR1_DOVIZ_ID,
                                          colmOZEL_TUTAR2_DOVIZ_ID, colmOZEL_TUTAR3_DOVIZ_ID, colmTAKIP_CIKISI_DOVIZ_ID,
                                          colmSONRAKI_FAIZ_DOVIZ_ID, colmSONRAKI_TAZMINAT_DOVIZ_ID, colmBSMV_TS_DOVIZ_ID,
                                          colmOIV_TS_DOVIZ_ID, colmKDV_TS_DOVIZ_ID, colmILK_GIDERLER_DOVIZ_ID,
                                          colmPESIN_HARC_DOVIZ_ID, colmODENEN_TAHSIL_HARCI_DOVIZ_ID,
                                          colmKALAN_TAHSIL_HARCI_DOVIZ_ID, colmMASAYA_KATILMA_HARCI_DOVIZ_ID,
                                          colmPAYLASMA_HARCI_DOVIZ_ID, colmDAVA_GIDERLERI_DOVIZ_ID,
                                          colmDIGER_GIDERLER_DOVIZ_ID, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID,
                                          colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, colmDAVA_VEKALET_UCRETI_DOVIZ_ID,
                                          colmODEME_TOPLAMI_DOVIZ_ID, colmTO_ODEME_TOPLAMI_DOVIZ_ID,
                                          colmMAHSUP_TOPLAMI_DOVIZ_ID, colmFERAGAT_TOPLAMI_DOVIZ_ID,
                                          colmALACAK_TOPLAMI_DOVIZ_ID, colmKALAN_DOVIZ_ID, colmTAHLIYE_VEK_UCR_DOVIZ_ID,
                                          colmDIGER_HARC_DOVIZ_ID, colmTD_GIDERI_DOVIZ_ID, colmTD_BAKIYE_HARC_DOVIZ_ID,
                                          colmTD_VEK_UCR_DOVIZ_ID, colmTD_TEBLIG_GIDERI_DOVIZ_ID,
                                          colmBIRIKMIS_NAFAKA_DOVIZ_ID, colmICRA_INKAR_TAZMINATI_DOVIZ_ID,
                                          colmDAMGA_PULU_DOVIZ_ID, colmPROTOKOL_MIKTARI_DOVIZ_ID,
                                          colmKARSILIK_TUTARI_DOVIZ_ID, colmTO_MASRAF_TOPLAMI_DOVIZ_ID,
                                          colmTS_MASRAF_TOPLAMI_DOVIZ_ID, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                                          colmHARC_TOPLAMI_DOVIZ_ID, colmTO_VEKALET_TOPLAMI_DOVIZ_ID,
                                          colmTS_VEKALET_TOPLAMI_DOVIZ_ID, colmTUM_VEKALET_TOPLAMI_DOVIZ_ID,
                                          colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, colmFAIZ_TOPLAMI_DOVIZ_ID,
                                          colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, colmIT_VEKALET_UCRETI_DOVIZ_ID,
                                          colmIT_GIDERI_DOVIZ_ID, colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID,
                                          colmBASVURMA_HARCI_DOVIZ_ID, colmVEKALET_HARCI_DOVIZ_ID,
                                          colmVEKALET_PULU_DOVIZ_ID, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID,
                                          colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, colmILK_TEBLIGAT_GIDERI_DOVIZ_ID,
                                          colmTAHLIYE_HARCI_DOVIZ_ID, colmTESLIM_HARCI_DOVIZ_ID, colmFERAGAT_HARCI_DOVIZ_ID
                                          , colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, colmSORUMLU_AVUKAT_CARI_ID, colmTALEP_ADI,
                                          colmFORM_TIP_ID, colmFOY_DURUM_ID, colmFOY_NO, colmREFERANS_NO, colmREFERANS_NO2,
                                          colmREFERANS_NO3, colmADLI_BIRIM_NO_ID, colmADLI_BIRIM_ADLIYE_ID,
                                          colmICRA_OZEL_KOD1_ID, colmICRA_OZEL_KOD2_ID, colmICRA_OZEL_KOD3_ID,
                                          colmICRA_OZEL_KOD4_ID, colmTAKIBIN_AVUKATA_INTIKAL_TARIHI, colmFOY_ARSIV_TARIHI,
                                          colmFOY_INFAZ_TARIHI, colmTAKIBIN_MUVEKKILE_IADE_TARIHI, colmSON_HESAP_TARIHI,
                                          colmBIR_YIL_KAC_GUN, colmASIL_ALACAK, colmISLEMIS_FAIZ, colmBSMV_TO, colmKKDV_TO,
                                          colmOIV_TO, colmKDV_TO, colmIH_VEKALET_UCRETI, colmIH_GIDERI,
                                          colmIT_HACIZDE_ODENEN, colmKARSILIKSIZ_CEK_TAZMINATI, colmCEK_KOMISYONU,
                                          colmILAM_YARGILAMA_GIDERI, colmILAM_BK_YARG_ONAMA, colmILAM_TEBLIG_GIDERI,
                                          colmILAM_INKAR_TAZMINATI, colmILAM_VEK_UCR, colmPROTESTO_GIDERI, colmIHTAR_GIDERI
                                          , colmOZEL_TAZMINAT, colmOZEL_TUTAR1_FAIZ_ORANI, colmOZEL_TUTAR1_KONU_ID,
                                          colmOZEL_TUTAR1, colmOZEL_TUTAR2_KONU_ID, colmOZEL_TUTAR2,
                                          colmOZEL_TUTAR3_KONU_ID, colmOZEL_TUTAR3, colmTAKIP_CIKISI, colmSONRAKI_FAIZ,
                                          colmSONRAKI_TAZMINAT, colmBSMV_TS, colmOIV_TS, colmKDV_TS, colmILK_GIDERLER,
                                          colmPESIN_HARC, colmODENEN_TAHSIL_HARCI, colmKALAN_TAHSIL_HARCI,
                                          colmMASAYA_KATILMA_HARCI, colmPAYLASMA_HARCI, colmDAVA_GIDERLERI,
                                          colmDIGER_GIDERLER, colmTAKIP_VEKALET_UCRETI_KATSAYI, colmTAKIP_VEKALET_UCRETI,
                                          colmDAVA_INKAR_TAZMINATI, colmDAVA_VEKALET_UCRETI, colmODEME_TOPLAMI,
                                          colmTO_ODEME_TOPLAMI, colmMAHSUP_TOPLAMI, colmFERAGAT_TOPLAMI, colmALACAK_TOPLAMI
                                          , colmKALAN, colmTAHLIYE_VEK_UCR, colmDIGER_HARC, colmTD_GIDERI,
                                          colmTD_BAKIYE_HARC, colmTD_VEK_UCR, colmTD_TEBLIG_GIDERI, colmBIRIKMIS_NAFAKA,
                                          colmICRA_INKAR_TAZMINATI, colmDAMGA_PULU, colmACIKLAMA, colmPROTOKOL_MIKTARI,
                                          colmPROTOKOL_FAIZ_ORANI, colmPROTOKOL_TARIHI, colmKARSILIK_TUTARI,
                                          colmTO_MASRAF_TOPLAMI, colmTS_MASRAF_TOPLAMI, colmTUM_MASRAF_TOPLAMI,
                                          colmHARC_TOPLAMI, colmTO_VEKALET_TOPLAMI, colmTS_VEKALET_TOPLAMI,
                                          colmTUM_VEKALET_TOPLAMI, colmKARSI_VEKALET_TOPLAMI, colmFAIZ_TOPLAMI,
                                          colmILAM_UCRETLER_TOPLAMI, colmIT_VEKALET_UCRETI, colmIT_GIDERI,
                                          colmTO_ODEME_MAHSUP_TOPLAMI, colmPAYLASIM_TIPI, colmTS_HESAP_TIP_ID,
                                          colmTO_HESAP_TIP_ID, colmBASVURMA_HARCI, colmVEKALET_HARCI, colmVEKALET_PULU,
                                          colmIFLAS_BASVURMA_HARCI, colmIFLASIN_ACILMASI_HARCI, colmILK_TEBLIGAT_GIDERI,
                                          colmTAHLIYE_HARCI, colmTESLIM_HARCI, colmFERAGAT_HARCI, colmTO_YONETIMG_TAZMINATI
                                          , colmASAMA_ID, colmTAKIP_TALEP_ID
                                      });

            grid.GroupSummary.AddRange(new[]
                                           {
                                               summaryASIL_ALACAK_DOVIZ_ID, summaryASIL_ALACAK,
                                               summaryISLEMIS_FAIZ_DOVIZ_ID, summaryISLEMIS_FAIZ, summaryBSMV_TO_DOVIZ_ID,
                                               summaryBSMV_TO, summaryKKDV_TO_DOVIZ_ID, summaryKKDV_TO, summaryOIV_TO,
                                               summaryKDV_TO_DOVIZ_ID, summaryKDV_TO, summaryIH_VEKALET_UCRETI_DOVIZ_ID,
                                               summaryIH_VEKALET_UCRETI, summaryIH_GIDERI_DOVIZ_ID, summaryIH_GIDERI,
                                               summaryIT_HACIZDE_ODENEN_DOVIZ_ID, summaryIT_HACIZDE_ODENEN,
                                               summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, summaryKARSILIKSIZ_CEK_TAZMINATI,
                                               summaryCEK_KOMISYONU_DOVIZ_ID, summaryCEK_KOMISYONU,
                                               summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID, summaryILAM_YARGILAMA_GIDERI,
                                               summaryILAM_BK_YARG_ONAMA_DOVIZ_ID, summaryILAM_BK_YARG_ONAMA,
                                               summaryILAM_TEBLIG_GIDERI_DOVIZ_ID, summaryILAM_TEBLIG_GIDERI,
                                               summaryILAM_INKAR_TAZMINATI_DOVIZ_ID, summaryILAM_INKAR_TAZMINATI,
                                               summaryILAM_VEK_UCR_DOVIZ_ID, summaryILAM_VEK_UCR, summaryOIV_TO_DOVIZ_ID,
                                               summaryPROTESTO_GIDERI_DOVIZ_ID, summaryPROTESTO_GIDERI,
                                               summaryIHTAR_GIDERI_DOVIZ_ID, summaryIHTAR_GIDERI,
                                               summaryOZEL_TAZMINAT_DOVIZ_ID, summaryOZEL_TAZMINAT,
                                               summaryOZEL_TUTAR1_DOVIZ_ID, summaryOZEL_TUTAR1, summaryOZEL_TUTAR2_DOVIZ_ID
                                               , summaryOZEL_TUTAR2, summaryOZEL_TUTAR3_DOVIZ_ID, summaryOZEL_TUTAR3,
                                               summaryTAKIP_CIKISI_DOVIZ_ID, summaryTAKIP_CIKISI,
                                               summarySONRAKI_FAIZ_DOVIZ_ID, summarySONRAKI_FAIZ,
                                               summarySONRAKI_TAZMINAT_DOVIZ_ID, summarySONRAKI_TAZMINAT,
                                               summaryBSMV_TS_DOVIZ_ID, summaryBSMV_TS, summaryOIV_TS_DOVIZ_ID,
                                               summaryOIV_TS, summaryKDV_TS_DOVIZ_ID, summaryKDV_TS,
                                               summaryILK_GIDERLER_DOVIZ_ID, summaryILK_GIDERLER,
                                               summaryPESIN_HARC_DOVIZ_ID, summaryPESIN_HARC,
                                               summaryODENEN_TAHSIL_HARCI_DOVIZ_ID, summaryODENEN_TAHSIL_HARCI,
                                               summaryKALAN_TAHSIL_HARCI_DOVIZ_ID, summaryKALAN_TAHSIL_HARCI,
                                               summaryMASAYA_KATILMA_HARCI_DOVIZ_ID, summaryMASAYA_KATILMA_HARCI,
                                               summaryPAYLASMA_HARCI_DOVIZ_ID, summaryPAYLASMA_HARCI,
                                               summaryDAVA_GIDERLERI_DOVIZ_ID, summaryDAVA_GIDERLERI,
                                               summaryDIGER_GIDERLER_DOVIZ_ID, summaryDIGER_GIDERLER,
                                               summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID, summaryTAKIP_VEKALET_UCRETI,
                                               summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID, summaryDAVA_INKAR_TAZMINATI,
                                               summaryDAVA_VEKALET_UCRETI_DOVIZ_ID, summaryDAVA_VEKALET_UCRETI,
                                               summaryODEME_TOPLAMI_DOVIZ_ID, summaryODEME_TOPLAMI,
                                               summaryTO_ODEME_TOPLAMI_DOVIZ_ID, summaryTO_ODEME_TOPLAMI,
                                               summaryMAHSUP_TOPLAMI_DOVIZ_ID, summaryMAHSUP_TOPLAMI,
                                               summaryFERAGAT_TOPLAMI, summaryFERAGAT_TOPLAMI_DOVIZ_ID,
                                               summaryALACAK_TOPLAMI_DOVIZ_ID, summaryALACAK_TOPLAMI, summaryKALAN_DOVIZ_ID
                                               , summaryKALAN, summaryTAHLIYE_VEK_UCR_DOVIZ_ID, summaryTAHLIYE_VEK_UCR,
                                               summaryDIGER_HARC_DOVIZ_ID, summaryDIGER_HARC, summaryTD_GIDERI_DOVIZ_ID,
                                               summaryTD_GIDERI, summaryTD_BAKIYE_HARC_DOVIZ_ID, summaryTD_BAKIYE_HARC,
                                               summaryTD_VEK_UCR_DOVIZ_ID, summaryTD_VEK_UCR,
                                               summaryTD_TEBLIG_GIDERI_DOVIZ_ID, summaryTD_TEBLIG_GIDERI,
                                               summaryBIRIKMIS_NAFAKA_DOVIZ_ID, summaryBIRIKMIS_NAFAKA,
                                               summaryICRA_INKAR_TAZMINATI_DOVIZ_ID, summaryICRA_INKAR_TAZMINATI,
                                               summaryDAMGA_PULU_DOVIZ_ID, summaryDAMGA_PULU,
                                               summaryPROTOKOL_MIKTARI_DOVIZ_ID, summaryPROTOKOL_MIKTARI,
                                               summaryKARSILIK_TUTARI_DOVIZ_ID, summaryKARSILIK_TUTARI,
                                               summaryTO_MASRAF_TOPLAMI, summaryTO_MASRAF_TOPLAMI_DOVIZ_ID,
                                               summaryTS_MASRAF_TOPLAMI, summaryTS_MASRAF_TOPLAMI_DOVIZ_ID,
                                               summaryTUM_MASRAF_TOPLAMI, summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID,
                                               summaryHARC_TOPLAMI, summaryHARC_TOPLAMI_DOVIZ_ID,
                                               summaryTO_VEKALET_TOPLAMI_DOVIZ_ID, summaryTO_VEKALET_TOPLAMI,
                                               summaryTS_VEKALET_TOPLAMI, summaryTS_VEKALET_TOPLAMI_DOVIZ_ID,
                                               summaryTUM_VEKALET_TOPLAMI, summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID,
                                               summaryKARSI_VEKALET_TOPLAMI, summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID,
                                               summaryFAIZ_TOPLAMI, summaryFAIZ_TOPLAMI_DOVIZ_ID,
                                               summaryILAM_UCRETLER_TOPLAMI, summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID,
                                               summaryIT_VEKALET_UCRETI_DOVIZ_ID, summaryIT_VEKALET_UCRETI,
                                               summaryIT_GIDERI_DOVIZ_ID, summaryIT_GIDERI, summaryTO_ODEME_MAHSUP_TOPLAMI,
                                               summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, summaryBASVURMA_HARCI,
                                               summaryBASVURMA_HARCI_DOVIZ_ID, summaryVEKALET_HARCI,
                                               summaryVEKALET_HARCI_DOVIZ_ID, summaryVEKALET_PULU,
                                               summaryVEKALET_PULU_DOVIZ_ID, summaryIFLAS_BASVURMA_HARCI,
                                               summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID, summaryIFLASIN_ACILMASI_HARCI,
                                               summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID, summaryILK_TEBLIGAT_GIDERI,
                                               summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID, summaryTAHLIYE_HARCI,
                                               summaryTAHLIYE_HARCI_DOVIZ_ID, summaryTESLIM_HARCI,
                                               summaryTESLIM_HARCI_DOVIZ_ID, summaryFERAGAT_HARCI,
                                               summaryFERAGAT_HARCI_DOVIZ_ID, summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID,
                                               summaryTO_YONETIMG_TAZMINATI
                                           });

            #endregion AddRange

            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.TI_BIL_HESAPLI_KAPSAMLI_GENEL_SORUMLUs;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void HESAPLI_KAPSAMLI_GENEL_TARAFLI()
        {
            #region Column & Summary & LookUps

            var colmASIL_ALACAK_DOVIZ_ID = colmnVer("ASIL ALACAK DOVIZ ID", "ASIL_ALACAK_DOVIZ_ID", true, 19, lupDoviz);
            var summaryASIL_ALACAK_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK_DOVIZ_ID", colmASIL_ALACAK_DOVIZ_ID, "", 2);
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.FieldName = "ASIL_ALACAK_DOVIZ_ID";
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmISLEMIS_FAIZ_DOVIZ_ID = colmnVer("ISLEMIS FAIZ DOVIZ ID", "ISLEMIS_FAIZ_DOVIZ_ID", true, 21, lupDoviz);
            var summaryISLEMIS_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ_DOVIZ_ID", colmISLEMIS_FAIZ_DOVIZ_ID, "", 2);
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "ISLEMIS_FAIZ_DOVIZ_ID";
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBSMV_TO_DOVIZ_ID = colmnVer("BSMV TO DOVIZ ID", "BSMV_TO_DOVIZ_ID", true, 23, lupDoviz);
            var summaryBSMV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO_DOVIZ_ID", colmBSMV_TO_DOVIZ_ID, "", 2);
            colmBSMV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TO_DOVIZ_ID";
            colmBSMV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKKDV_TO_DOVIZ_ID = colmnVer("KKDV TO DOVIZ ID", "KKDV_TO_DOVIZ_ID", true, 25, lupDoviz);
            var summaryKKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO_DOVIZ_ID", colmKKDV_TO_DOVIZ_ID, "", 2);
            colmKKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KKDV_TO_DOVIZ_ID";
            colmKKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKDV_TO_DOVIZ_ID = colmnVer("KDV TO DOVIZ ID", "KDV_TO_DOVIZ_ID", true, 28, lupDoviz);
            var summaryKDV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO_DOVIZ_ID", colmKDV_TO_DOVIZ_ID, "", 2);
            colmKDV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TO_DOVIZ_ID.SummaryItem.FieldName = "KDV_TO_DOVIZ_ID";
            colmKDV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIH_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IH VEKALET UCRETI DOVIZ ID", "IH_VEKALET_UCRETI_DOVIZ_ID", true, 30, lupDoviz);
            var summaryIH_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI_DOVIZ_ID", colmIH_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IH_VEKALET_UCRETI_DOVIZ_ID";
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIH_GIDERI_DOVIZ_ID = colmnVer("IH GIDERI DOVIZ ID", "IH_GIDERI_DOVIZ_ID", true, 32, lupDoviz);
            var summaryIH_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI_DOVIZ_ID", colmIH_GIDERI_DOVIZ_ID, "", 2);
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IH_GIDERI_DOVIZ_ID";
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_HACIZDE_ODENEN_DOVIZ_ID = colmnVer("IT HACIZDE ODENEN DOVIZ ID", "IT_HACIZDE_ODENEN_DOVIZ_ID", true, 34, lupDoviz);
            var summaryIT_HACIZDE_ODENEN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN_DOVIZ_ID", colmIT_HACIZDE_ODENEN_DOVIZ_ID, "", 2);
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.FieldName = "IT_HACIZDE_ODENEN_DOVIZ_ID";
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = colmnVer("KARSILIKSIZ CEK TAZMINATI DOVIZ ID", "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", true, 36, lupDoviz);
            var summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID", colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "", 2);
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID";
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmCEK_KOMISYONU_DOVIZ_ID = colmnVer("CEK KOMISYONU DOVIZ ID", "CEK_KOMISYONU_DOVIZ_ID", true, 38, lupDoviz);
            var summaryCEK_KOMISYONU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU_DOVIZ_ID", colmCEK_KOMISYONU_DOVIZ_ID, "", 2);
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.FieldName = "CEK_KOMISYONU_DOVIZ_ID";
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_YARGILAMA_GIDERI_DOVIZ_ID = colmnVer("ILAM YARGILAMA GIDERI DOVIZ ID", "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", true, 40, lupDoviz);
            var summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI_DOVIZ_ID", colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI_DOVIZ_ID";
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_BK_YARG_ONAMA_DOVIZ_ID = colmnVer("ILAM BK YARG ONAMA DOVIZ ID", "ILAM_BK_YARG_ONAMA_DOVIZ_ID", true, 42, lupDoviz);
            var summaryILAM_BK_YARG_ONAMA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA_DOVIZ_ID", colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "", 2);
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA_DOVIZ_ID";
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("ILAM TEBLIG GIDERI DOVIZ ID", "ILAM_TEBLIG_GIDERI_DOVIZ_ID", true, 44, lupDoviz);
            var summaryILAM_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI_DOVIZ_ID", colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI_DOVIZ_ID";
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ILAM INKAR TAZMINATI DOVIZ ID", "ILAM_INKAR_TAZMINATI_DOVIZ_ID", true, 46, lupDoviz);
            var summaryILAM_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI_DOVIZ_ID", colmILAM_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI_DOVIZ_ID";
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_VEK_UCR_DOVIZ_ID = colmnVer("ILAM VEK UCR DOVIZ ID", "ILAM_VEK_UCR_DOVIZ_ID", true, 48, lupDoviz);
            var summaryILAM_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR_DOVIZ_ID", colmILAM_VEK_UCR_DOVIZ_ID, "", 2);
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "ILAM_VEK_UCR_DOVIZ_ID";
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOIV_TO_DOVIZ_ID = colmnVer("OIV TO DOVIZ ID", "OIV_TO_DOVIZ_ID", true, 50, lupDoviz);
            var summaryOIV_TO_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO_DOVIZ_ID", colmOIV_TO_DOVIZ_ID, "", 2);
            colmOIV_TO_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TO_DOVIZ_ID.SummaryItem.FieldName = "OIV_TO_DOVIZ_ID";
            colmOIV_TO_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPROTESTO_GIDERI_DOVIZ_ID = colmnVer("PROTESTO GIDERI DOVIZ ID", "PROTESTO_GIDERI_DOVIZ_ID", true, 51, lupDoviz);
            var summaryPROTESTO_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI_DOVIZ_ID", colmPROTESTO_GIDERI_DOVIZ_ID, "", 2);
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIHTAR_GIDERI_DOVIZ_ID = colmnVer("IHTAR GIDERI DOVIZ ID", "IHTAR_GIDERI_DOVIZ_ID", true, 53, lupDoviz);
            var summaryIHTAR_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI_DOVIZ_ID", colmIHTAR_GIDERI_DOVIZ_ID, "", 2);
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TAZMINAT_DOVIZ_ID = colmnVer("OZEL TAZMINAT DOVIZ ID", "OZEL_TAZMINAT_DOVIZ_ID", true, 55, lupDoviz);
            var summaryOZEL_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT_DOVIZ_ID", colmOZEL_TAZMINAT_DOVIZ_ID, "", 2);
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TAZMINAT_DOVIZ_ID";
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR1_DOVIZ_ID = colmnVer("OZEL TUTAR1 DOVIZ ID", "OZEL_TUTAR1_DOVIZ_ID", true, 59, lupDoviz);
            var summaryOZEL_TUTAR1_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1_DOVIZ_ID", colmOZEL_TUTAR1_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR1_DOVIZ_ID";
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR2_DOVIZ_ID = colmnVer("OZEL TUTAR2 DOVIZ ID", "OZEL_TUTAR2_DOVIZ_ID", true, 62, lupDoviz);
            var summaryOZEL_TUTAR2_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2_DOVIZ_ID", colmOZEL_TUTAR2_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR2_DOVIZ_ID";
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOZEL_TUTAR3_DOVIZ_ID = colmnVer("OZEL TUTAR3 DOVIZ ID", "OZEL_TUTAR3_DOVIZ_ID", true, 65, lupDoviz);
            var summaryOZEL_TUTAR3_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3_DOVIZ_ID", colmOZEL_TUTAR3_DOVIZ_ID, "", 2);
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.FieldName = "OZEL_TUTAR3_DOVIZ_ID";
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAKIP_CIKISI_DOVIZ_ID = colmnVer("TAKIP CIKISI DOVIZ ID", "TAKIP_CIKISI_DOVIZ_ID", true, 67, lupDoviz);
            var summaryTAKIP_CIKISI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI_DOVIZ_ID", colmTAKIP_CIKISI_DOVIZ_ID, "", 2);
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_CIKISI_DOVIZ_ID";
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSONRAKI_FAIZ_DOVIZ_ID = colmnVer("SONRAKI FAIZ DOVIZ ID", "SONRAKI_FAIZ_DOVIZ_ID", true, 69, lupDoviz);
            var summarySONRAKI_FAIZ_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ_DOVIZ_ID", colmSONRAKI_FAIZ_DOVIZ_ID, "", 2);
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_FAIZ_DOVIZ_ID";
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSONRAKI_TAZMINAT_DOVIZ_ID = colmnVer("SONRAKI TAZMINAT DOVIZ ID", "SONRAKI_TAZMINAT_DOVIZ_ID", true, 71, lupDoviz);
            var summarySONRAKI_TAZMINAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT_DOVIZ_ID", colmSONRAKI_TAZMINAT_DOVIZ_ID, "", 2);
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.FieldName = "SONRAKI_TAZMINAT_DOVIZ_ID";
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBSMV_TS_DOVIZ_ID = colmnVer("BSMV TS DOVIZ ID", "BSMV_TS_DOVIZ_ID", true, 73, lupDoviz);
            var summaryBSMV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS_DOVIZ_ID", colmBSMV_TS_DOVIZ_ID, "", 2);
            colmBSMV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.FieldName = "BSMV_TS_DOVIZ_ID";
            colmBSMV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmOIV_TS_DOVIZ_ID = colmnVer("OIV TS DOVIZ ID", "OIV_TS_DOVIZ_ID", true, 75, lupDoviz);
            var summaryOIV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS_DOVIZ_ID", colmOIV_TS_DOVIZ_ID, "", 2);
            colmOIV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmOIV_TS_DOVIZ_ID.SummaryItem.FieldName = "OIV_TS_DOVIZ_ID";
            colmOIV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKDV_TS_DOVIZ_ID = colmnVer("KDV TS DOVIZ ID", "KDV_TS_DOVIZ_ID", true, 77, lupDoviz);
            var summaryKDV_TS_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS_DOVIZ_ID", colmKDV_TS_DOVIZ_ID, "", 2);
            colmKDV_TS_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKDV_TS_DOVIZ_ID.SummaryItem.FieldName = "KDV_TS_DOVIZ_ID";
            colmKDV_TS_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILK_GIDERLER_DOVIZ_ID = colmnVer("ILK GIDERLER DOVIZ ID", "ILK_GIDERLER_DOVIZ_ID", true, 79, lupDoviz);
            var summaryILK_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER_DOVIZ_ID", colmILK_GIDERLER_DOVIZ_ID, "", 2);
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "ILK_GIDERLER_DOVIZ_ID";
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPESIN_HARC_DOVIZ_ID = colmnVer("PESIN HARC DOVIZ ID", "PESIN_HARC_DOVIZ_ID", true, 81, lupDoviz);
            var summaryPESIN_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC_DOVIZ_ID", colmPESIN_HARC_DOVIZ_ID, "", 2);
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.FieldName = "PESIN_HARC_DOVIZ_ID";
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmODENEN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("ODENEN TAHSIL HARCI DOVIZ ID", "ODENEN_TAHSIL_HARCI_DOVIZ_ID", true, 83, lupDoviz);
            var summaryODENEN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI_DOVIZ_ID", colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI_DOVIZ_ID";
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKALAN_TAHSIL_HARCI_DOVIZ_ID = colmnVer("KALAN TAHSIL HARCI DOVIZ ID", "KALAN_TAHSIL_HARCI_DOVIZ_ID", true, 85, lupDoviz);
            var summaryKALAN_TAHSIL_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI_DOVIZ_ID", colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "", 2);
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.FieldName = "KALAN_TAHSIL_HARCI_DOVIZ_ID";
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmMASAYA_KATILMA_HARCI_DOVIZ_ID = colmnVer("MASAYA KATILMA HARCI DOVIZ ID", "MASAYA_KATILMA_HARCI_DOVIZ_ID", true, 87, lupDoviz);
            var summaryMASAYA_KATILMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI_DOVIZ_ID", colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "", 2);
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI_DOVIZ_ID";
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPAYLASMA_HARCI_DOVIZ_ID = colmnVer("PAYLASMA HARCI DOVIZ ID", "PAYLASMA_HARCI_DOVIZ_ID", true, 89, lupDoviz);
            var summaryPAYLASMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI_DOVIZ_ID", colmPAYLASMA_HARCI_DOVIZ_ID, "", 2);
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "PAYLASMA_HARCI_DOVIZ_ID";
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_GIDERLERI_DOVIZ_ID = colmnVer("DAVA GIDERLERI DOVIZ ID", "DAVA_GIDERLERI_DOVIZ_ID", true, 91, lupDoviz);
            var summaryDAVA_GIDERLERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI_DOVIZ_ID", colmDAVA_GIDERLERI_DOVIZ_ID, "", 2);
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_GIDERLERI_DOVIZ_ID";
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDIGER_GIDERLER_DOVIZ_ID = colmnVer("DIGER GIDERLER DOVIZ ID", "DIGER_GIDERLER_DOVIZ_ID", true, 93, lupDoviz);
            var summaryDIGER_GIDERLER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER_DOVIZ_ID", colmDIGER_GIDERLER_DOVIZ_ID, "", 2);
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.FieldName = "DIGER_GIDERLER_DOVIZ_ID";
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAKIP_VEKALET_UCRETI_DOVIZ_ID = colmnVer("TAKIP VEKALET UCRETI DOVIZ ID", "TAKIP_VEKALET_UCRETI_DOVIZ_ID", true, 96, lupDoviz);
            var summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI_DOVIZ_ID", colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI_DOVIZ_ID";
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("DAVA INKAR TAZMINATI DOVIZ ID", "DAVA_INKAR_TAZMINATI_DOVIZ_ID", true, 98, lupDoviz);
            var summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI_DOVIZ_ID", colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI_DOVIZ_ID";
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_VEKALET_UCRETI_DOVIZ_ID = colmnVer("DAVA VEKALET UCRETI DOVIZ ID", "DAVA_VEKALET_UCRETI_DOVIZ_ID", true, 100, lupDoviz);
            var summaryDAVA_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI_DOVIZ_ID", colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI_DOVIZ_ID";
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmODEME_TOPLAMI_DOVIZ_ID = colmnVer("ODEME TOPLAMI DOVIZ ID", "ODEME_TOPLAMI_DOVIZ_ID", true, 102, lupDoviz);
            var summaryODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI_DOVIZ_ID", colmODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ODEME_TOPLAMI_DOVIZ_ID";
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_ODEME_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME TOPLAMI DOVIZ ID", "TO_ODEME_TOPLAMI_DOVIZ_ID", true, 104, lupDoviz);
            var summaryTO_ODEME_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI_DOVIZ_ID", colmTO_ODEME_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmMAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("MAHSUP TOPLAMI DOVIZ ID", "MAHSUP_TOPLAMI_DOVIZ_ID", true, 106, lupDoviz);
            var summaryMAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI_DOVIZ_ID", colmMAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "MAHSUP_TOPLAMI_DOVIZ_ID";
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFERAGAT_TOPLAMI_DOVIZ_ID = colmnVer("FERAGAT TOPLAMI DOVIZ ID", "FERAGAT_TOPLAMI_DOVIZ_ID", true, 109, lupDoviz);
            var summaryFERAGAT_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI_DOVIZ_ID", colmFERAGAT_TOPLAMI_DOVIZ_ID, "", 2);
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_TOPLAMI_DOVIZ_ID";
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmALACAK_TOPLAMI_DOVIZ_ID = colmnVer("ALACAK TOPLAMI DOVIZ ID", "ALACAK_TOPLAMI_DOVIZ_ID", true, 110, lupDoviz);
            var summaryALACAK_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI_DOVIZ_ID", colmALACAK_TOPLAMI_DOVIZ_ID, "", 2);
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ALACAK_TOPLAMI_DOVIZ_ID";
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKALAN_DOVIZ_ID = colmnVer("KALAN DOVIZ ID", "KALAN_DOVIZ_ID", true, 112, lupDoviz);
            var summaryKALAN_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_DOVIZ_ID", colmKALAN_DOVIZ_ID, "", 2);
            colmKALAN_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKALAN_DOVIZ_ID.SummaryItem.FieldName = "KALAN_DOVIZ_ID";
            colmKALAN_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAHLIYE_VEK_UCR_DOVIZ_ID = colmnVer("TAHLIYE VEK UCR DOVIZ ID", "TAHLIYE_VEK_UCR_DOVIZ_ID", true, 114, lupDoviz);
            var summaryTAHLIYE_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR_DOVIZ_ID", colmTAHLIYE_VEK_UCR_DOVIZ_ID, "", 2);
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_VEK_UCR_DOVIZ_ID";
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDIGER_HARC_DOVIZ_ID = colmnVer("DIGER HARC DOVIZ ID", "DIGER_HARC_DOVIZ_ID", true, 116, lupDoviz);
            var summaryDIGER_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC_DOVIZ_ID", colmDIGER_HARC_DOVIZ_ID, "", 2);
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.FieldName = "DIGER_HARC_DOVIZ_ID";
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_GIDERI_DOVIZ_ID = colmnVer("TD GIDERI DOVIZ ID", "TD_GIDERI_DOVIZ_ID", true, 118, lupDoviz);
            var summaryTD_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI_DOVIZ_ID", colmTD_GIDERI_DOVIZ_ID, "", 2);
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_GIDERI_DOVIZ_ID";
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_BAKIYE_HARC_DOVIZ_ID = colmnVer("TD BAKIYE HARC DOVIZ ID", "TD_BAKIYE_HARC_DOVIZ_ID", true, 120, lupDoviz);
            var summaryTD_BAKIYE_HARC_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC_DOVIZ_ID", colmTD_BAKIYE_HARC_DOVIZ_ID, "", 2);
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.FieldName = "TD_BAKIYE_HARC_DOVIZ_ID";
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_VEK_UCR_DOVIZ_ID = colmnVer("TD VEK UCR DOVIZ ID", "TD_VEK_UCR_DOVIZ_ID", true, 122, lupDoviz);
            var summaryTD_VEK_UCR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR_DOVIZ_ID", colmTD_VEK_UCR_DOVIZ_ID, "", 2);
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.FieldName = "TD_VEK_UCR_DOVIZ_ID";
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTD_TEBLIG_GIDERI_DOVIZ_ID = colmnVer("TD TEBLIG GIDERI DOVIZ ID", "TD_TEBLIG_GIDERI_DOVIZ_ID", true, 124, lupDoviz);
            var summaryTD_TEBLIG_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI_DOVIZ_ID", colmTD_TEBLIG_GIDERI_DOVIZ_ID, "", 2);
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "TD_TEBLIG_GIDERI_DOVIZ_ID";
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBIRIKMIS_NAFAKA_DOVIZ_ID = colmnVer("BIRIKMIS NAFAKA DOVIZ ID", "BIRIKMIS_NAFAKA_DOVIZ_ID", true, 126, lupDoviz);
            var summaryBIRIKMIS_NAFAKA_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA_DOVIZ_ID", colmBIRIKMIS_NAFAKA_DOVIZ_ID, "", 2);
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.FieldName = "BIRIKMIS_NAFAKA_DOVIZ_ID";
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmICRA_INKAR_TAZMINATI_DOVIZ_ID = colmnVer("ICRA INKAR TAZMINATI DOVIZ ID", "ICRA_INKAR_TAZMINATI_DOVIZ_ID", true, 128, lupDoviz);
            var summaryICRA_INKAR_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI_DOVIZ_ID", colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "", 2);
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI_DOVIZ_ID";
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAMGA_PULU_DOVIZ_ID = colmnVer("DAMGA PULU DOVIZ ID", "DAMGA_PULU_DOVIZ_ID", true, 130, lupDoviz);
            var summaryDAMGA_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU_DOVIZ_ID", colmDAMGA_PULU_DOVIZ_ID, "", 2);
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.FieldName = "DAMGA_PULU_DOVIZ_ID";
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPROTOKOL_MIKTARI_DOVIZ_ID = colmnVer("PROTOKOL MIKTARI DOVIZ ID", "PROTOKOL_MIKTARI_DOVIZ_ID", true, 133, lupDoviz);
            var summaryPROTOKOL_MIKTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI_DOVIZ_ID", colmPROTOKOL_MIKTARI_DOVIZ_ID, "", 2);
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.FieldName = "PROTOKOL_MIKTARI_DOVIZ_ID";
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSILIK_TUTARI_DOVIZ_ID = colmnVer("KARSILIK TUTARI DOVIZ ID", "KARSILIK_TUTARI_DOVIZ_ID", true, 137, lupDoviz);
            var summaryKARSILIK_TUTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI_DOVIZ_ID", colmKARSILIK_TUTARI_DOVIZ_ID, "", 2);
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.FieldName = "KARSILIK_TUTARI_DOVIZ_ID";
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TO MASRAF TOPLAMI DOVIZ ID", "TO_MASRAF_TOPLAMI_DOVIZ_ID", true, 140, lupDoviz);
            var summaryTO_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI_DOVIZ_ID", colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTS_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TS MASRAF TOPLAMI DOVIZ ID", "TS_MASRAF_TOPLAMI_DOVIZ_ID", true, 142, lupDoviz);
            var summaryTS_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI_DOVIZ_ID", colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTUM_MASRAF_TOPLAMI_DOVIZ_ID = colmnVer("TUM MASRAF TOPLAMI DOVIZ ID", "TUM_MASRAF_TOPLAMI_DOVIZ_ID", true, 144, lupDoviz);
            var summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI_DOVIZ_ID", colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI_DOVIZ_ID";
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHARC_TOPLAMI_DOVIZ_ID = colmnVer("HARC TOPLAMI DOVIZ ID", "HARC_TOPLAMI_DOVIZ_ID", true, 146, lupDoviz);
            var summaryHARC_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI_DOVIZ_ID", colmHARC_TOPLAMI_DOVIZ_ID, "", 2);
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "HARC_TOPLAMI_DOVIZ_ID";
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TO VEKALET TOPLAMI DOVIZ ID", "TO_VEKALET_TOPLAMI_DOVIZ_ID", true, 147, lupDoviz);
            var summaryTO_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI_DOVIZ_ID", colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTS_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TS VEKALET TOPLAMI DOVIZ ID", "TS_VEKALET_TOPLAMI_DOVIZ_ID", true, 150, lupDoviz);
            var summaryTS_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI_DOVIZ_ID", colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTUM_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("TUM VEKALET TOPLAMI DOVIZ ID", "TUM_VEKALET_TOPLAMI_DOVIZ_ID", true, 152, lupDoviz);
            var summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI_DOVIZ_ID", colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI_DOVIZ_ID";
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID = colmnVer("KARSI VEKALET TOPLAMI DOVIZ ID", "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", true, 154, lupDoviz);
            var summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI_DOVIZ_ID", colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "", 2);
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI_DOVIZ_ID";
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFAIZ_TOPLAMI_DOVIZ_ID = colmnVer("FAIZ TOPLAMI DOVIZ ID", "FAIZ_TOPLAMI_DOVIZ_ID", true, 156, lupDoviz);
            var summaryFAIZ_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI_DOVIZ_ID", colmFAIZ_TOPLAMI_DOVIZ_ID, "", 2);
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "FAIZ_TOPLAMI_DOVIZ_ID";
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID = colmnVer("ILAM UCRETLER TOPLAMI DOVIZ ID", "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", true, 158, lupDoviz);
            var summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID", colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "", 2);
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI_DOVIZ_ID";
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_VEKALET_UCRETI_DOVIZ_ID = colmnVer("IT VEKALET UCRETI DOVIZ ID", "IT_VEKALET_UCRETI_DOVIZ_ID", true, 159, lupDoviz);
            var summaryIT_VEKALET_UCRETI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI_DOVIZ_ID", colmIT_VEKALET_UCRETI_DOVIZ_ID, "", 2);
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.FieldName = "IT_VEKALET_UCRETI_DOVIZ_ID";
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIT_GIDERI_DOVIZ_ID = colmnVer("IT GIDERI DOVIZ ID", "IT_GIDERI_DOVIZ_ID", true, 161, lupDoviz);
            var summaryIT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI_DOVIZ_ID", colmIT_GIDERI_DOVIZ_ID, "", 2);
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IT_GIDERI_DOVIZ_ID";
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = colmnVer("TO ODEME MAHSUP TOPLAMI DOVIZ ID", "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", true, 164, lupDoviz);
            var summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID", colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "", 2);
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID";
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmBASVURMA_HARCI_DOVIZ_ID = colmnVer("BASVURMA HARCI DOVIZ ID", "BASVURMA_HARCI_DOVIZ_ID", true, 169, lupDoviz);
            var summaryBASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI_DOVIZ_ID", colmBASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "BASVURMA_HARCI_DOVIZ_ID";
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmVEKALET_HARCI_DOVIZ_ID = colmnVer("VEKALET HARCI DOVIZ ID", "VEKALET_HARCI_DOVIZ_ID", true, 171, lupDoviz);
            var summaryVEKALET_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI_DOVIZ_ID", colmVEKALET_HARCI_DOVIZ_ID, "", 2);
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_HARCI_DOVIZ_ID";
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmVEKALET_PULU_DOVIZ_ID = colmnVer("VEKALET PULU DOVIZ ID", "VEKALET_PULU_DOVIZ_ID", true, 173, lupDoviz);
            var summaryVEKALET_PULU_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU_DOVIZ_ID", colmVEKALET_PULU_DOVIZ_ID, "", 2);
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.FieldName = "VEKALET_PULU_DOVIZ_ID";
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIFLAS_BASVURMA_HARCI_DOVIZ_ID = colmnVer("IFLAS BASVURMA HARCI DOVIZ ID", "IFLAS_BASVURMA_HARCI_DOVIZ_ID", true, 175, lupDoviz);
            var summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI_DOVIZ_ID", colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "", 2);
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI_DOVIZ_ID";
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID = colmnVer("IFLASIN ACILMASI HARCI DOVIZ ID", "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", true, 177, lupDoviz);
            var summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI_DOVIZ_ID", colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "", 2);
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI_DOVIZ_ID";
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmILK_TEBLIGAT_GIDERI_DOVIZ_ID = colmnVer("ILK TEBLIGAT GIDERI DOVIZ ID", "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", true, 179, lupDoviz);
            var summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI_DOVIZ_ID", colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "", 2);
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI_DOVIZ_ID";
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTAHLIYE_HARCI_DOVIZ_ID = colmnVer("TAHLIYE HARCI DOVIZ ID", "TAHLIYE_HARCI_DOVIZ_ID", true, 181, lupDoviz);
            var summaryTAHLIYE_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI_DOVIZ_ID", colmTAHLIYE_HARCI_DOVIZ_ID, "", 2);
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TAHLIYE_HARCI_DOVIZ_ID";
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTESLIM_HARCI_DOVIZ_ID = colmnVer("TESLIM HARCI DOVIZ ID", "TESLIM_HARCI_DOVIZ_ID", true, 183, lupDoviz);
            var summaryTESLIM_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI_DOVIZ_ID", colmTESLIM_HARCI_DOVIZ_ID, "", 2);
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.FieldName = "TESLIM_HARCI_DOVIZ_ID";
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFERAGAT_HARCI_DOVIZ_ID = colmnVer("FERAGAT HARCI DOVIZ ID", "FERAGAT_HARCI_DOVIZ_ID", true, 185, lupDoviz);
            var summaryFERAGAT_HARCI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI_DOVIZ_ID", colmFERAGAT_HARCI_DOVIZ_ID, "", 2);
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.FieldName = "FERAGAT_HARCI_DOVIZ_ID";
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTO_YONETIMG_TAZMINATI_DOVIZ_ID = colmnVer("TO YONETIMG TAZMINATI DOVIZ ID", "TO_YONETIMG_TAZMINATI_DOVIZ_ID", true, 186, lupDoviz);
            var summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI_DOVIZ_ID", colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "", 2);
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI_DOVIZ_ID";
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmFORM_TIP_ID = colmnVer("FORM TIP ID", "FORM_TIP_ID", true, 1, TablesGrids.GetTI_KOD_FORM_TIPLookup());
            var colmFOY_DURUM_ID = colmnVer("FOY DURUM ID", "FOY_DURUM_ID", true, 2, TablesGrids.GetTDI_KOD_FOY_DURUMLookup());
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 3, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 4, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 5, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 6, null);
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 7, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 8, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmICRA_OZEL_KOD1_ID = colmnVer("ICRA OZEL KOD1 ID", "ICRA_OZEL_KOD1_ID", true, 9, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmICRA_OZEL_KOD2_ID = colmnVer("ICRA OZEL KOD2 ID", "ICRA_OZEL_KOD2_ID", true, 10, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmICRA_OZEL_KOD3_ID = colmnVer("ICRA OZEL KOD3 ID", "ICRA_OZEL_KOD3_ID", true, 11, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmICRA_OZEL_KOD4_ID = colmnVer("ICRA OZEL KOD4 ID", "ICRA_OZEL_KOD4_ID", true, 12, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTAKIBIN_AVUKATA_INTIKAL_TARIHI = colmnVer("TAKIBIN AVUKATA INTIKAL TARIHI", "TAKIBIN_AVUKATA_INTIKAL_TARIHI", true, 13, null);
            var colmFOY_ARSIV_TARIHI = colmnVer("FOY ARSIV TARIHI", "FOY_ARSIV_TARIHI", true, 14, null);
            var colmFOY_INFAZ_TARIHI = colmnVer("FOY INFAZ TARIHI", "FOY_INFAZ_TARIHI", true, 15, null);
            var colmTAKIBIN_MUVEKKILE_IADE_TARIHI = colmnVer("TAKIBIN MUVEKKILE IADE TARIHI", "TAKIBIN_MUVEKKILE_IADE_TARIHI", true, 16, null);
            var colmSON_HESAP_TARIHI = colmnVer("SON HESAP TARIHI", "SON_HESAP_TARIHI", true, 17, null);
            var colmBIR_YIL_KAC_GUN = colmnVer("BIR YIL KAC GUN", "BIR_YIL_KAC_GUN", true, 18, null);
            var colmASIL_ALACAK = colmnVer("ASIL ALACAK", "ASIL_ALACAK", true, 20, null, colmASIL_ALACAK_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryASIL_ALACAK = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ASIL_ALACAK", colmASIL_ALACAK, "", 1);
            colmASIL_ALACAK.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmASIL_ALACAK.SummaryItem.FieldName = "ASIL_ALACAK";
            colmASIL_ALACAK.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmASIL_ALACAK.SummaryItem.Tag = 1;

            var colmISLEMIS_FAIZ = colmnVer("ISLEMIS FAIZ", "ISLEMIS_FAIZ", true, 22, null, colmISLEMIS_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryISLEMIS_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLEMIS_FAIZ", colmISLEMIS_FAIZ, "", 1);
            colmISLEMIS_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmISLEMIS_FAIZ.SummaryItem.FieldName = "ISLEMIS_FAIZ";
            colmISLEMIS_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLEMIS_FAIZ.SummaryItem.Tag = 1;

            var colmBSMV_TO = colmnVer("BSMV TO", "BSMV_TO", true, 24, null, colmBSMV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBSMV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TO", colmBSMV_TO, "", 1);
            colmBSMV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TO.SummaryItem.FieldName = "BSMV_TO";
            colmBSMV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TO.SummaryItem.Tag = 1;

            var colmKKDV_TO = colmnVer("KKDV TO", "KKDV_TO", true, 26, null, colmKKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KKDV_TO", colmKKDV_TO, "", 1);
            colmKKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKKDV_TO.SummaryItem.FieldName = "KKDV_TO";
            colmKKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKKDV_TO.SummaryItem.Tag = 1;

            var colmOIV_TO = colmnVer("OIV TO", "OIV_TO", true, 27, null, colmOIV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOIV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TO", colmOIV_TO, "", 1);
            colmOIV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TO.SummaryItem.FieldName = "OIV_TO";
            colmOIV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TO.SummaryItem.Tag = 1;

            var colmKDV_TO = colmnVer("KDV TO", "KDV_TO", true, 29, null, colmKDV_TO_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKDV_TO = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TO", colmKDV_TO, "", 1);
            colmKDV_TO.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TO.SummaryItem.FieldName = "KDV_TO";
            colmKDV_TO.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TO.SummaryItem.Tag = 1;

            var colmIH_VEKALET_UCRETI = colmnVer("IH VEKALET UCRETI", "IH_VEKALET_UCRETI", true, 31, null, colmIH_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_VEKALET_UCRETI", colmIH_VEKALET_UCRETI, "", 1);
            colmIH_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_VEKALET_UCRETI.SummaryItem.FieldName = "IH_VEKALET_UCRETI";
            colmIH_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIH_GIDERI = colmnVer("IH GIDERI", "IH_GIDERI", true, 33, null, colmIH_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIH_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IH_GIDERI", colmIH_GIDERI, "", 1);
            colmIH_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIH_GIDERI.SummaryItem.FieldName = "IH_GIDERI";
            colmIH_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIH_GIDERI.SummaryItem.Tag = 1;

            var colmIT_HACIZDE_ODENEN = colmnVer("IT HACIZDE ODENEN", "IT_HACIZDE_ODENEN", true, 35, null, colmIT_HACIZDE_ODENEN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_HACIZDE_ODENEN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_HACIZDE_ODENEN", colmIT_HACIZDE_ODENEN, "", 1);
            colmIT_HACIZDE_ODENEN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_HACIZDE_ODENEN.SummaryItem.FieldName = "IT_HACIZDE_ODENEN";
            colmIT_HACIZDE_ODENEN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_HACIZDE_ODENEN.SummaryItem.Tag = 1;

            var colmKARSILIKSIZ_CEK_TAZMINATI = colmnVer("KARSILIKSIZ CEK TAZMINATI", "KARSILIKSIZ_CEK_TAZMINATI", true, 37, null, colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIKSIZ_CEK_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIKSIZ_CEK_TAZMINATI", colmKARSILIKSIZ_CEK_TAZMINATI, "", 1);
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.FieldName = "KARSILIKSIZ_CEK_TAZMINATI";
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIKSIZ_CEK_TAZMINATI.SummaryItem.Tag = 1;

            var colmCEK_KOMISYONU = colmnVer("CEK KOMISYONU", "CEK_KOMISYONU", true, 39, null, colmCEK_KOMISYONU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryCEK_KOMISYONU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "CEK_KOMISYONU", colmCEK_KOMISYONU, "", 1);
            colmCEK_KOMISYONU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmCEK_KOMISYONU.SummaryItem.FieldName = "CEK_KOMISYONU";
            colmCEK_KOMISYONU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmCEK_KOMISYONU.SummaryItem.Tag = 1;

            var colmILAM_YARGILAMA_GIDERI = colmnVer("ILAM YARGILAMA GIDERI", "ILAM_YARGILAMA_GIDERI", true, 41, null, colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_YARGILAMA_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_YARGILAMA_GIDERI", colmILAM_YARGILAMA_GIDERI, "", 1);
            colmILAM_YARGILAMA_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.FieldName = "ILAM_YARGILAMA_GIDERI";
            colmILAM_YARGILAMA_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_YARGILAMA_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_BK_YARG_ONAMA = colmnVer("ILAM BK YARG ONAMA", "ILAM_BK_YARG_ONAMA", true, 43, null, colmILAM_BK_YARG_ONAMA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_BK_YARG_ONAMA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_BK_YARG_ONAMA", colmILAM_BK_YARG_ONAMA, "", 1);
            colmILAM_BK_YARG_ONAMA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_BK_YARG_ONAMA.SummaryItem.FieldName = "ILAM_BK_YARG_ONAMA";
            colmILAM_BK_YARG_ONAMA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_BK_YARG_ONAMA.SummaryItem.Tag = 1;

            var colmILAM_TEBLIG_GIDERI = colmnVer("ILAM TEBLIG GIDERI", "ILAM_TEBLIG_GIDERI", true, 45, null, colmILAM_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_TEBLIG_GIDERI", colmILAM_TEBLIG_GIDERI, "", 1);
            colmILAM_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_TEBLIG_GIDERI.SummaryItem.FieldName = "ILAM_TEBLIG_GIDERI";
            colmILAM_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmILAM_INKAR_TAZMINATI = colmnVer("ILAM INKAR TAZMINATI", "ILAM_INKAR_TAZMINATI", true, 47, null, colmILAM_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_INKAR_TAZMINATI", colmILAM_INKAR_TAZMINATI, "", 1);
            colmILAM_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_INKAR_TAZMINATI.SummaryItem.FieldName = "ILAM_INKAR_TAZMINATI";
            colmILAM_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmILAM_VEK_UCR = colmnVer("ILAM VEK UCR", "ILAM_VEK_UCR", true, 49, null, colmILAM_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_VEK_UCR", colmILAM_VEK_UCR, "", 1);
            colmILAM_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_VEK_UCR.SummaryItem.FieldName = "ILAM_VEK_UCR";
            colmILAM_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_VEK_UCR.SummaryItem.Tag = 1;

            var colmPROTESTO_GIDERI = colmnVer("PROTESTO GIDERI", "PROTESTO_GIDERI", true, 52, null, colmPROTESTO_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTESTO_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI", colmPROTESTO_GIDERI, "", 1);
            colmPROTESTO_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTESTO_GIDERI.SummaryItem.FieldName = "PROTESTO_GIDERI";
            colmPROTESTO_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI.SummaryItem.Tag = 1;

            var colmIHTAR_GIDERI = colmnVer("IHTAR GIDERI", "IHTAR_GIDERI", true, 54, null, colmIHTAR_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIHTAR_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI", colmIHTAR_GIDERI, "", 1);
            colmIHTAR_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIHTAR_GIDERI.SummaryItem.FieldName = "IHTAR_GIDERI";
            colmIHTAR_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI.SummaryItem.Tag = 1;

            var colmOZEL_TAZMINAT = colmnVer("OZEL TAZMINAT", "OZEL_TAZMINAT", true, 56, null, colmOZEL_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TAZMINAT", colmOZEL_TAZMINAT, "", 1);
            colmOZEL_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TAZMINAT.SummaryItem.FieldName = "OZEL_TAZMINAT";
            colmOZEL_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TAZMINAT.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR1_FAIZ_ORANI = colmnVer("OZEL TUTAR1 FAIZ ORANI", "OZEL_TUTAR1_FAIZ_ORANI", true, 57, null);
            var colmOZEL_TUTAR1_KONU_ID = colmnVer("OZEL TUTAR1 KONU ID", "OZEL_TUTAR1_KONU_ID", true, 58, null);
            var colmOZEL_TUTAR1 = colmnVer("OZEL TUTAR1", "OZEL_TUTAR1", true, 60, null, colmOZEL_TUTAR1_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR1 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR1", colmOZEL_TUTAR1, "", 1);
            colmOZEL_TUTAR1.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR1.SummaryItem.FieldName = "OZEL_TUTAR1";
            colmOZEL_TUTAR1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR1.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR2_KONU_ID = colmnVer("OZEL TUTAR2 KONU ID", "OZEL_TUTAR2_KONU_ID", true, 61, null);
            var colmOZEL_TUTAR2 = colmnVer("OZEL TUTAR2", "OZEL_TUTAR2", true, 63, null, colmOZEL_TUTAR2_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR2 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR2", colmOZEL_TUTAR2, "", 1);
            colmOZEL_TUTAR2.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR2.SummaryItem.FieldName = "OZEL_TUTAR2";
            colmOZEL_TUTAR2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR2.SummaryItem.Tag = 1;

            var colmOZEL_TUTAR3_KONU_ID = colmnVer("OZEL TUTAR3 KONU ID", "OZEL_TUTAR3_KONU_ID", true, 64, null);
            var colmOZEL_TUTAR3 = colmnVer("OZEL TUTAR3", "OZEL_TUTAR3", true, 66, null, colmOZEL_TUTAR3_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOZEL_TUTAR3 = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OZEL_TUTAR3", colmOZEL_TUTAR3, "", 1);
            colmOZEL_TUTAR3.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOZEL_TUTAR3.SummaryItem.FieldName = "OZEL_TUTAR3";
            colmOZEL_TUTAR3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOZEL_TUTAR3.SummaryItem.Tag = 1;

            var colmTAKIP_CIKISI = colmnVer("TAKIP CIKISI", "TAKIP_CIKISI", true, 68, null, colmTAKIP_CIKISI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_CIKISI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_CIKISI", colmTAKIP_CIKISI, "", 1);
            colmTAKIP_CIKISI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_CIKISI.SummaryItem.FieldName = "TAKIP_CIKISI";
            colmTAKIP_CIKISI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_CIKISI.SummaryItem.Tag = 1;

            var colmSONRAKI_FAIZ = colmnVer("SONRAKI FAIZ", "SONRAKI_FAIZ", true, 70, null, colmSONRAKI_FAIZ_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_FAIZ = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_FAIZ", colmSONRAKI_FAIZ, "", 1);
            colmSONRAKI_FAIZ.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_FAIZ.SummaryItem.FieldName = "SONRAKI_FAIZ";
            colmSONRAKI_FAIZ.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_FAIZ.SummaryItem.Tag = 1;

            var colmSONRAKI_TAZMINAT = colmnVer("SONRAKI TAZMINAT", "SONRAKI_TAZMINAT", true, 72, null, colmSONRAKI_TAZMINAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySONRAKI_TAZMINAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SONRAKI_TAZMINAT", colmSONRAKI_TAZMINAT, "", 1);
            colmSONRAKI_TAZMINAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSONRAKI_TAZMINAT.SummaryItem.FieldName = "SONRAKI_TAZMINAT";
            colmSONRAKI_TAZMINAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSONRAKI_TAZMINAT.SummaryItem.Tag = 1;

            var colmBSMV_TS = colmnVer("BSMV TS", "BSMV_TS", true, 74, null, colmBSMV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBSMV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BSMV_TS", colmBSMV_TS, "", 1);
            colmBSMV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBSMV_TS.SummaryItem.FieldName = "BSMV_TS";
            colmBSMV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBSMV_TS.SummaryItem.Tag = 1;

            var colmOIV_TS = colmnVer("OIV TS", "OIV_TS", true, 76, null, colmOIV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryOIV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "OIV_TS", colmOIV_TS, "", 1);
            colmOIV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmOIV_TS.SummaryItem.FieldName = "OIV_TS";
            colmOIV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmOIV_TS.SummaryItem.Tag = 1;

            var colmKDV_TS = colmnVer("KDV TS", "KDV_TS", true, 78, null, colmKDV_TS_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKDV_TS = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TS", colmKDV_TS, "", 1);
            colmKDV_TS.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TS.SummaryItem.FieldName = "KDV_TS";
            colmKDV_TS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TS.SummaryItem.Tag = 1;

            var colmILK_GIDERLER = colmnVer("ILK GIDERLER", "ILK_GIDERLER", true, 80, null, colmILK_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_GIDERLER", colmILK_GIDERLER, "", 1);
            colmILK_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_GIDERLER.SummaryItem.FieldName = "ILK_GIDERLER";
            colmILK_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_GIDERLER.SummaryItem.Tag = 1;

            var colmPESIN_HARC = colmnVer("PESIN HARC", "PESIN_HARC", true, 82, null, colmPESIN_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPESIN_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PESIN_HARC", colmPESIN_HARC, "", 1);
            colmPESIN_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPESIN_HARC.SummaryItem.FieldName = "PESIN_HARC";
            colmPESIN_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPESIN_HARC.SummaryItem.Tag = 1;

            var colmODENEN_TAHSIL_HARCI = colmnVer("ODENEN TAHSIL HARCI", "ODENEN_TAHSIL_HARCI", true, 84, null, colmODENEN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODENEN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODENEN_TAHSIL_HARCI", colmODENEN_TAHSIL_HARCI, "", 1);
            colmODENEN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODENEN_TAHSIL_HARCI.SummaryItem.FieldName = "ODENEN_TAHSIL_HARCI";
            colmODENEN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODENEN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmKALAN_TAHSIL_HARCI = colmnVer("KALAN TAHSIL HARCI", "KALAN_TAHSIL_HARCI", true, 86, null, colmKALAN_TAHSIL_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN_TAHSIL_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN_TAHSIL_HARCI", colmKALAN_TAHSIL_HARCI, "", 1);
            colmKALAN_TAHSIL_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN_TAHSIL_HARCI.SummaryItem.FieldName = "KALAN_TAHSIL_HARCI";
            colmKALAN_TAHSIL_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN_TAHSIL_HARCI.SummaryItem.Tag = 1;

            var colmMASAYA_KATILMA_HARCI = colmnVer("MASAYA KATILMA HARCI", "MASAYA_KATILMA_HARCI", true, 88, null, colmMASAYA_KATILMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMASAYA_KATILMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MASAYA_KATILMA_HARCI", colmMASAYA_KATILMA_HARCI, "", 1);
            colmMASAYA_KATILMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMASAYA_KATILMA_HARCI.SummaryItem.FieldName = "MASAYA_KATILMA_HARCI";
            colmMASAYA_KATILMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMASAYA_KATILMA_HARCI.SummaryItem.Tag = 1;

            var colmPAYLASMA_HARCI = colmnVer("PAYLASMA HARCI", "PAYLASMA_HARCI", true, 90, null, colmPAYLASMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPAYLASMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PAYLASMA_HARCI", colmPAYLASMA_HARCI, "", 1);
            colmPAYLASMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPAYLASMA_HARCI.SummaryItem.FieldName = "PAYLASMA_HARCI";
            colmPAYLASMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPAYLASMA_HARCI.SummaryItem.Tag = 1;

            var colmDAVA_GIDERLERI = colmnVer("DAVA GIDERLERI", "DAVA_GIDERLERI", true, 92, null, colmDAVA_GIDERLERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_GIDERLERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_GIDERLERI", colmDAVA_GIDERLERI, "", 1);
            colmDAVA_GIDERLERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_GIDERLERI.SummaryItem.FieldName = "DAVA_GIDERLERI";
            colmDAVA_GIDERLERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_GIDERLERI.SummaryItem.Tag = 1;

            var colmDIGER_GIDERLER = colmnVer("DIGER GIDERLER", "DIGER_GIDERLER", true, 94, null, colmDIGER_GIDERLER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_GIDERLER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_GIDERLER", colmDIGER_GIDERLER, "", 1);
            colmDIGER_GIDERLER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_GIDERLER.SummaryItem.FieldName = "DIGER_GIDERLER";
            colmDIGER_GIDERLER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_GIDERLER.SummaryItem.Tag = 1;

            var colmTAKIP_VEKALET_UCRETI_KATSAYI = colmnVer("TAKIP VEKALET UCRETI KATSAYI", "TAKIP_VEKALET_UCRETI_KATSAYI", true, 95, null);
            var colmTAKIP_VEKALET_UCRETI = colmnVer("TAKIP VEKALET UCRETI", "TAKIP_VEKALET_UCRETI", true, 97, null, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAKIP_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAKIP_VEKALET_UCRETI", colmTAKIP_VEKALET_UCRETI, "", 1);
            colmTAKIP_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.FieldName = "TAKIP_VEKALET_UCRETI";
            colmTAKIP_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAKIP_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmDAVA_INKAR_TAZMINATI = colmnVer("DAVA INKAR TAZMINATI", "DAVA_INKAR_TAZMINATI", true, 99, null, colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_INKAR_TAZMINATI", colmDAVA_INKAR_TAZMINATI, "", 1);
            colmDAVA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.FieldName = "DAVA_INKAR_TAZMINATI";
            colmDAVA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAVA_VEKALET_UCRETI = colmnVer("DAVA VEKALET UCRETI", "DAVA_VEKALET_UCRETI", true, 101, null, colmDAVA_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_VEKALET_UCRETI", colmDAVA_VEKALET_UCRETI, "", 1);
            colmDAVA_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_VEKALET_UCRETI.SummaryItem.FieldName = "DAVA_VEKALET_UCRETI";
            colmDAVA_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmODEME_TOPLAMI = colmnVer("ODEME TOPLAMI", "ODEME_TOPLAMI", true, 103, null, colmODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ODEME_TOPLAMI", colmODEME_TOPLAMI, "", 1);
            colmODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmODEME_TOPLAMI.SummaryItem.FieldName = "ODEME_TOPLAMI";
            colmODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_ODEME_TOPLAMI = colmnVer("TO ODEME TOPLAMI", "TO_ODEME_TOPLAMI", true, 105, null, colmTO_ODEME_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_TOPLAMI", colmTO_ODEME_TOPLAMI, "", 1);
            colmTO_ODEME_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_TOPLAMI";
            colmTO_ODEME_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_TOPLAMI.SummaryItem.Tag = 1;

            var colmMAHSUP_TOPLAMI = colmnVer("MAHSUP TOPLAMI", "MAHSUP_TOPLAMI", true, 107, null, colmMAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MAHSUP_TOPLAMI", colmMAHSUP_TOPLAMI, "", 1);
            colmMAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMAHSUP_TOPLAMI.SummaryItem.FieldName = "MAHSUP_TOPLAMI";
            colmMAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmFERAGAT_TOPLAMI = colmnVer("FERAGAT TOPLAMI", "FERAGAT_TOPLAMI", true, 108, null, colmFERAGAT_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_TOPLAMI", colmFERAGAT_TOPLAMI, "", 1);
            colmFERAGAT_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_TOPLAMI.SummaryItem.FieldName = "FERAGAT_TOPLAMI";
            colmFERAGAT_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_TOPLAMI.SummaryItem.Tag = 1;

            var colmALACAK_TOPLAMI = colmnVer("ALACAK TOPLAMI", "ALACAK_TOPLAMI", true, 111, null, colmALACAK_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryALACAK_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ALACAK_TOPLAMI", colmALACAK_TOPLAMI, "", 1);
            colmALACAK_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmALACAK_TOPLAMI.SummaryItem.FieldName = "ALACAK_TOPLAMI";
            colmALACAK_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmALACAK_TOPLAMI.SummaryItem.Tag = 1;

            var colmKALAN = colmnVer("KALAN", "KALAN", true, 113, null, colmKALAN_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKALAN = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KALAN", colmKALAN, "", 1);
            colmKALAN.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKALAN.SummaryItem.FieldName = "KALAN";
            colmKALAN.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKALAN.SummaryItem.Tag = 1;

            var colmTAHLIYE_VEK_UCR = colmnVer("TAHLIYE VEK UCR", "TAHLIYE_VEK_UCR", true, 115, null, colmTAHLIYE_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_VEK_UCR", colmTAHLIYE_VEK_UCR, "", 1);
            colmTAHLIYE_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_VEK_UCR.SummaryItem.FieldName = "TAHLIYE_VEK_UCR";
            colmTAHLIYE_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_VEK_UCR.SummaryItem.Tag = 1;

            var colmDIGER_HARC = colmnVer("DIGER HARC", "DIGER_HARC", true, 117, null, colmDIGER_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDIGER_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DIGER_HARC", colmDIGER_HARC, "", 1);
            colmDIGER_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDIGER_HARC.SummaryItem.FieldName = "DIGER_HARC";
            colmDIGER_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDIGER_HARC.SummaryItem.Tag = 1;

            var colmTD_GIDERI = colmnVer("TD GIDERI", "TD_GIDERI", true, 119, null, colmTD_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_GIDERI", colmTD_GIDERI, "", 1);
            colmTD_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_GIDERI.SummaryItem.FieldName = "TD_GIDERI";
            colmTD_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_GIDERI.SummaryItem.Tag = 1;

            var colmTD_BAKIYE_HARC = colmnVer("TD BAKIYE HARC", "TD_BAKIYE_HARC", true, 121, null, colmTD_BAKIYE_HARC_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_BAKIYE_HARC = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_BAKIYE_HARC", colmTD_BAKIYE_HARC, "", 1);
            colmTD_BAKIYE_HARC.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_BAKIYE_HARC.SummaryItem.FieldName = "TD_BAKIYE_HARC";
            colmTD_BAKIYE_HARC.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_BAKIYE_HARC.SummaryItem.Tag = 1;

            var colmTD_VEK_UCR = colmnVer("TD VEK UCR", "TD_VEK_UCR", true, 123, null, colmTD_VEK_UCR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_VEK_UCR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_VEK_UCR", colmTD_VEK_UCR, "", 1);
            colmTD_VEK_UCR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_VEK_UCR.SummaryItem.FieldName = "TD_VEK_UCR";
            colmTD_VEK_UCR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_VEK_UCR.SummaryItem.Tag = 1;

            var colmTD_TEBLIG_GIDERI = colmnVer("TD TEBLIG GIDERI", "TD_TEBLIG_GIDERI", true, 125, null, colmTD_TEBLIG_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTD_TEBLIG_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TD_TEBLIG_GIDERI", colmTD_TEBLIG_GIDERI, "", 1);
            colmTD_TEBLIG_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTD_TEBLIG_GIDERI.SummaryItem.FieldName = "TD_TEBLIG_GIDERI";
            colmTD_TEBLIG_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTD_TEBLIG_GIDERI.SummaryItem.Tag = 1;

            var colmBIRIKMIS_NAFAKA = colmnVer("BIRIKMIS NAFAKA", "BIRIKMIS_NAFAKA", true, 127, null, colmBIRIKMIS_NAFAKA_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIKMIS_NAFAKA = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIKMIS_NAFAKA", colmBIRIKMIS_NAFAKA, "", 1);
            colmBIRIKMIS_NAFAKA.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIKMIS_NAFAKA.SummaryItem.FieldName = "BIRIKMIS_NAFAKA";
            colmBIRIKMIS_NAFAKA.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIKMIS_NAFAKA.SummaryItem.Tag = 1;

            var colmICRA_INKAR_TAZMINATI = colmnVer("ICRA INKAR TAZMINATI", "ICRA_INKAR_TAZMINATI", true, 129, null, colmICRA_INKAR_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryICRA_INKAR_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_INKAR_TAZMINATI", colmICRA_INKAR_TAZMINATI, "", 1);
            colmICRA_INKAR_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmICRA_INKAR_TAZMINATI.SummaryItem.FieldName = "ICRA_INKAR_TAZMINATI";
            colmICRA_INKAR_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_INKAR_TAZMINATI.SummaryItem.Tag = 1;

            var colmDAMGA_PULU = colmnVer("DAMGA PULU", "DAMGA_PULU", true, 131, null, colmDAMGA_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAMGA_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAMGA_PULU", colmDAMGA_PULU, "", 1);
            colmDAMGA_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAMGA_PULU.SummaryItem.FieldName = "DAMGA_PULU";
            colmDAMGA_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAMGA_PULU.SummaryItem.Tag = 1;

            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 132, null);
            var colmPROTOKOL_MIKTARI = colmnVer("PROTOKOL MIKTARI", "PROTOKOL_MIKTARI", true, 134, null, colmPROTOKOL_MIKTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTOKOL_MIKTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTOKOL_MIKTARI", colmPROTOKOL_MIKTARI, "", 1);
            colmPROTOKOL_MIKTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTOKOL_MIKTARI.SummaryItem.FieldName = "PROTOKOL_MIKTARI";
            colmPROTOKOL_MIKTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTOKOL_MIKTARI.SummaryItem.Tag = 1;

            var colmPROTOKOL_FAIZ_ORANI = colmnVer("PROTOKOL FAIZ ORANI", "PROTOKOL_FAIZ_ORANI", true, 135, null);
            var colmPROTOKOL_TARIHI = colmnVer("PROTOKOL TARIHI", "PROTOKOL_TARIHI", true, 136, null);
            var colmKARSILIK_TUTARI = colmnVer("KARSILIK TUTARI", "KARSILIK_TUTARI", true, 138, null, colmKARSILIK_TUTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIK_TUTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTARI", colmKARSILIK_TUTARI, "", 1);
            colmKARSILIK_TUTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIK_TUTARI.SummaryItem.FieldName = "KARSILIK_TUTARI";
            colmKARSILIK_TUTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTARI.SummaryItem.Tag = 1;

            var colmTO_MASRAF_TOPLAMI = colmnVer("TO MASRAF TOPLAMI", "TO_MASRAF_TOPLAMI", true, 139, null, colmTO_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_MASRAF_TOPLAMI", colmTO_MASRAF_TOPLAMI, "", 1);
            colmTO_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_MASRAF_TOPLAMI.SummaryItem.FieldName = "TO_MASRAF_TOPLAMI";
            colmTO_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_MASRAF_TOPLAMI = colmnVer("TS MASRAF TOPLAMI", "TS_MASRAF_TOPLAMI", true, 141, null, colmTS_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_MASRAF_TOPLAMI", colmTS_MASRAF_TOPLAMI, "", 1);
            colmTS_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_MASRAF_TOPLAMI.SummaryItem.FieldName = "TS_MASRAF_TOPLAMI";
            colmTS_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_MASRAF_TOPLAMI = colmnVer("TUM MASRAF TOPLAMI", "TUM_MASRAF_TOPLAMI", true, 143, null, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_MASRAF_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_MASRAF_TOPLAMI", colmTUM_MASRAF_TOPLAMI, "", 1);
            colmTUM_MASRAF_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.FieldName = "TUM_MASRAF_TOPLAMI";
            colmTUM_MASRAF_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_MASRAF_TOPLAMI.SummaryItem.Tag = 1;

            var colmHARC_TOPLAMI = colmnVer("HARC TOPLAMI", "HARC_TOPLAMI", true, 145, null, colmHARC_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHARC_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HARC_TOPLAMI", colmHARC_TOPLAMI, "", 1);
            colmHARC_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHARC_TOPLAMI.SummaryItem.FieldName = "HARC_TOPLAMI";
            colmHARC_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHARC_TOPLAMI.SummaryItem.Tag = 1;

            var colmTO_VEKALET_TOPLAMI = colmnVer("TO VEKALET TOPLAMI", "TO_VEKALET_TOPLAMI", true, 148, null, colmTO_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_VEKALET_TOPLAMI", colmTO_VEKALET_TOPLAMI, "", 1);
            colmTO_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_VEKALET_TOPLAMI.SummaryItem.FieldName = "TO_VEKALET_TOPLAMI";
            colmTO_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTS_VEKALET_TOPLAMI = colmnVer("TS VEKALET TOPLAMI", "TS_VEKALET_TOPLAMI", true, 149, null, colmTS_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTS_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TS_VEKALET_TOPLAMI", colmTS_VEKALET_TOPLAMI, "", 1);
            colmTS_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTS_VEKALET_TOPLAMI.SummaryItem.FieldName = "TS_VEKALET_TOPLAMI";
            colmTS_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTS_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmTUM_VEKALET_TOPLAMI = colmnVer("TUM VEKALET TOPLAMI", "TUM_VEKALET_TOPLAMI", true, 151, null, colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUM_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUM_VEKALET_TOPLAMI", colmTUM_VEKALET_TOPLAMI, "", 1);
            colmTUM_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.FieldName = "TUM_VEKALET_TOPLAMI";
            colmTUM_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUM_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmKARSI_VEKALET_TOPLAMI = colmnVer("KARSI VEKALET TOPLAMI", "KARSI_VEKALET_TOPLAMI", true, 153, null, colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSI_VEKALET_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSI_VEKALET_TOPLAMI", colmKARSI_VEKALET_TOPLAMI, "", 1);
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.FieldName = "KARSI_VEKALET_TOPLAMI";
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSI_VEKALET_TOPLAMI.SummaryItem.Tag = 1;

            var colmFAIZ_TOPLAMI = colmnVer("FAIZ TOPLAMI", "FAIZ_TOPLAMI", true, 155, null, colmFAIZ_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFAIZ_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FAIZ_TOPLAMI", colmFAIZ_TOPLAMI, "", 1);
            colmFAIZ_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFAIZ_TOPLAMI.SummaryItem.FieldName = "FAIZ_TOPLAMI";
            colmFAIZ_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFAIZ_TOPLAMI.SummaryItem.Tag = 1;

            var colmILAM_UCRETLER_TOPLAMI = colmnVer("ILAM UCRETLER TOPLAMI", "ILAM_UCRETLER_TOPLAMI", true, 157, null, colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILAM_UCRETLER_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILAM_UCRETLER_TOPLAMI", colmILAM_UCRETLER_TOPLAMI, "", 1);
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.FieldName = "ILAM_UCRETLER_TOPLAMI";
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILAM_UCRETLER_TOPLAMI.SummaryItem.Tag = 1;

            var colmIT_VEKALET_UCRETI = colmnVer("IT VEKALET UCRETI", "IT_VEKALET_UCRETI", true, 160, null, colmIT_VEKALET_UCRETI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_VEKALET_UCRETI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_VEKALET_UCRETI", colmIT_VEKALET_UCRETI, "", 1);
            colmIT_VEKALET_UCRETI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_VEKALET_UCRETI.SummaryItem.FieldName = "IT_VEKALET_UCRETI";
            colmIT_VEKALET_UCRETI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_VEKALET_UCRETI.SummaryItem.Tag = 1;

            var colmIT_GIDERI = colmnVer("IT GIDERI", "IT_GIDERI", true, 162, null, colmIT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IT_GIDERI", colmIT_GIDERI, "", 1);
            colmIT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIT_GIDERI.SummaryItem.FieldName = "IT_GIDERI";
            colmIT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIT_GIDERI.SummaryItem.Tag = 1;

            var colmTO_ODEME_MAHSUP_TOPLAMI = colmnVer("TO ODEME MAHSUP TOPLAMI", "TO_ODEME_MAHSUP_TOPLAMI", true, 163, null, colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_ODEME_MAHSUP_TOPLAMI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_ODEME_MAHSUP_TOPLAMI", colmTO_ODEME_MAHSUP_TOPLAMI, "", 1);
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.FieldName = "TO_ODEME_MAHSUP_TOPLAMI";
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_ODEME_MAHSUP_TOPLAMI.SummaryItem.Tag = 1;

            var colmPAYLASIM_TIPI = colmnVer("PAYLASIM TIPI", "PAYLASIM_TIPI", true, 165, null);
            var colmTS_HESAP_TIP_ID = colmnVer("TS HESAP TIP ID", "TS_HESAP_TIP_ID", true, 166, TablesGrids.GetAV001_TI_KOD_HESAP_TIPLookup());
            var colmTO_HESAP_TIP_ID = colmnVer("TO HESAP TIP ID", "TO_HESAP_TIP_ID", true, 167, null);
            var colmBASVURMA_HARCI = colmnVer("BASVURMA HARCI", "BASVURMA_HARCI", true, 168, null, colmBASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BASVURMA_HARCI", colmBASVURMA_HARCI, "", 1);
            colmBASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBASVURMA_HARCI.SummaryItem.FieldName = "BASVURMA_HARCI";
            colmBASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_HARCI = colmnVer("VEKALET HARCI", "VEKALET_HARCI", true, 170, null, colmVEKALET_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_HARCI", colmVEKALET_HARCI, "", 1);
            colmVEKALET_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_HARCI.SummaryItem.FieldName = "VEKALET_HARCI";
            colmVEKALET_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_HARCI.SummaryItem.Tag = 1;

            var colmVEKALET_PULU = colmnVer("VEKALET PULU", "VEKALET_PULU", true, 172, null, colmVEKALET_PULU_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryVEKALET_PULU = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "VEKALET_PULU", colmVEKALET_PULU, "", 1);
            colmVEKALET_PULU.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmVEKALET_PULU.SummaryItem.FieldName = "VEKALET_PULU";
            colmVEKALET_PULU.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmVEKALET_PULU.SummaryItem.Tag = 1;

            var colmIFLAS_BASVURMA_HARCI = colmnVer("IFLAS BASVURMA HARCI", "IFLAS_BASVURMA_HARCI", true, 174, null, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLAS_BASVURMA_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLAS_BASVURMA_HARCI", colmIFLAS_BASVURMA_HARCI, "", 1);
            colmIFLAS_BASVURMA_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.FieldName = "IFLAS_BASVURMA_HARCI";
            colmIFLAS_BASVURMA_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLAS_BASVURMA_HARCI.SummaryItem.Tag = 1;

            var colmIFLASIN_ACILMASI_HARCI = colmnVer("IFLASIN ACILMASI HARCI", "IFLASIN_ACILMASI_HARCI", true, 176, null, colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIFLASIN_ACILMASI_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IFLASIN_ACILMASI_HARCI", colmIFLASIN_ACILMASI_HARCI, "", 1);
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.FieldName = "IFLASIN_ACILMASI_HARCI";
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIFLASIN_ACILMASI_HARCI.SummaryItem.Tag = 1;

            var colmILK_TEBLIGAT_GIDERI = colmnVer("ILK TEBLIGAT GIDERI", "ILK_TEBLIGAT_GIDERI", true, 178, null, colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryILK_TEBLIGAT_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ILK_TEBLIGAT_GIDERI", colmILK_TEBLIGAT_GIDERI, "", 1);
            colmILK_TEBLIGAT_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.FieldName = "ILK_TEBLIGAT_GIDERI";
            colmILK_TEBLIGAT_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmILK_TEBLIGAT_GIDERI.SummaryItem.Tag = 1;

            var colmTAHLIYE_HARCI = colmnVer("TAHLIYE HARCI", "TAHLIYE_HARCI", true, 180, null, colmTAHLIYE_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTAHLIYE_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TAHLIYE_HARCI", colmTAHLIYE_HARCI, "", 1);
            colmTAHLIYE_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTAHLIYE_HARCI.SummaryItem.FieldName = "TAHLIYE_HARCI";
            colmTAHLIYE_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTAHLIYE_HARCI.SummaryItem.Tag = 1;

            var colmTESLIM_HARCI = colmnVer("TESLIM HARCI", "TESLIM_HARCI", true, 182, null, colmTESLIM_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTESLIM_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TESLIM_HARCI", colmTESLIM_HARCI, "", 1);
            colmTESLIM_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTESLIM_HARCI.SummaryItem.FieldName = "TESLIM_HARCI";
            colmTESLIM_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTESLIM_HARCI.SummaryItem.Tag = 1;

            var colmFERAGAT_HARCI = colmnVer("FERAGAT HARCI", "FERAGAT_HARCI", true, 184, null, colmFERAGAT_HARCI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryFERAGAT_HARCI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "FERAGAT_HARCI", colmFERAGAT_HARCI, "", 1);
            colmFERAGAT_HARCI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmFERAGAT_HARCI.SummaryItem.FieldName = "FERAGAT_HARCI";
            colmFERAGAT_HARCI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmFERAGAT_HARCI.SummaryItem.Tag = 1;

            var colmTO_YONETIMG_TAZMINATI = colmnVer("TO YONETIMG TAZMINATI", "TO_YONETIMG_TAZMINATI", true, 187, null, colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTO_YONETIMG_TAZMINATI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TO_YONETIMG_TAZMINATI", colmTO_YONETIMG_TAZMINATI, "", 1);
            colmTO_YONETIMG_TAZMINATI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.FieldName = "TO_YONETIMG_TAZMINATI";
            colmTO_YONETIMG_TAZMINATI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTO_YONETIMG_TAZMINATI.SummaryItem.Tag = 1;

            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 188, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTAKIP_TALEP_ID = colmnVer("TAKIP TALEP ID", "TAKIP_TALEP_ID", true, 189, TablesGrids.GetTI_KOD_TAKIP_TALEPLookup());
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 190, TablesGrids.GetAV001_TDI_BIL_CARILookup());

            #endregion Column & Summary & LookUps

            var grid = (GridView)gridRaporCntrol.MainView;

            grid.Columns.AddRange(new[] { colmASIL_ALACAK_DOVIZ_ID, colmISLEMIS_FAIZ_DOVIZ_ID, colmBSMV_TO_DOVIZ_ID, colmKKDV_TO_DOVIZ_ID, colmKDV_TO_DOVIZ_ID, colmIH_VEKALET_UCRETI_DOVIZ_ID, colmIH_GIDERI_DOVIZ_ID, colmIT_HACIZDE_ODENEN_DOVIZ_ID, colmKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, colmCEK_KOMISYONU_DOVIZ_ID, colmILAM_YARGILAMA_GIDERI_DOVIZ_ID, colmILAM_BK_YARG_ONAMA_DOVIZ_ID, colmILAM_TEBLIG_GIDERI_DOVIZ_ID, colmILAM_INKAR_TAZMINATI_DOVIZ_ID, colmILAM_VEK_UCR_DOVIZ_ID, colmOIV_TO_DOVIZ_ID, colmPROTESTO_GIDERI_DOVIZ_ID, colmIHTAR_GIDERI_DOVIZ_ID, colmOZEL_TAZMINAT_DOVIZ_ID, colmOZEL_TUTAR1_DOVIZ_ID, colmOZEL_TUTAR2_DOVIZ_ID, colmOZEL_TUTAR3_DOVIZ_ID, colmTAKIP_CIKISI_DOVIZ_ID, colmSONRAKI_FAIZ_DOVIZ_ID, colmSONRAKI_TAZMINAT_DOVIZ_ID, colmBSMV_TS_DOVIZ_ID, colmOIV_TS_DOVIZ_ID, colmKDV_TS_DOVIZ_ID, colmILK_GIDERLER_DOVIZ_ID, colmPESIN_HARC_DOVIZ_ID, colmODENEN_TAHSIL_HARCI_DOVIZ_ID, colmKALAN_TAHSIL_HARCI_DOVIZ_ID, colmMASAYA_KATILMA_HARCI_DOVIZ_ID, colmPAYLASMA_HARCI_DOVIZ_ID, colmDAVA_GIDERLERI_DOVIZ_ID, colmDIGER_GIDERLER_DOVIZ_ID, colmTAKIP_VEKALET_UCRETI_DOVIZ_ID, colmDAVA_INKAR_TAZMINATI_DOVIZ_ID, colmDAVA_VEKALET_UCRETI_DOVIZ_ID, colmODEME_TOPLAMI_DOVIZ_ID, colmTO_ODEME_TOPLAMI_DOVIZ_ID, colmMAHSUP_TOPLAMI_DOVIZ_ID, colmFERAGAT_TOPLAMI_DOVIZ_ID, colmALACAK_TOPLAMI_DOVIZ_ID, colmKALAN_DOVIZ_ID, colmTAHLIYE_VEK_UCR_DOVIZ_ID, colmDIGER_HARC_DOVIZ_ID, colmTD_GIDERI_DOVIZ_ID, colmTD_BAKIYE_HARC_DOVIZ_ID, colmTD_VEK_UCR_DOVIZ_ID, colmTD_TEBLIG_GIDERI_DOVIZ_ID, colmBIRIKMIS_NAFAKA_DOVIZ_ID, colmICRA_INKAR_TAZMINATI_DOVIZ_ID, colmDAMGA_PULU_DOVIZ_ID, colmPROTOKOL_MIKTARI_DOVIZ_ID, colmKARSILIK_TUTARI_DOVIZ_ID, colmTO_MASRAF_TOPLAMI_DOVIZ_ID, colmTS_MASRAF_TOPLAMI_DOVIZ_ID, colmTUM_MASRAF_TOPLAMI_DOVIZ_ID, colmHARC_TOPLAMI_DOVIZ_ID, colmTO_VEKALET_TOPLAMI_DOVIZ_ID, colmTS_VEKALET_TOPLAMI_DOVIZ_ID, colmTUM_VEKALET_TOPLAMI_DOVIZ_ID, colmKARSI_VEKALET_TOPLAMI_DOVIZ_ID, colmFAIZ_TOPLAMI_DOVIZ_ID, colmILAM_UCRETLER_TOPLAMI_DOVIZ_ID, colmIT_VEKALET_UCRETI_DOVIZ_ID, colmIT_GIDERI_DOVIZ_ID, colmTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, colmBASVURMA_HARCI_DOVIZ_ID, colmVEKALET_HARCI_DOVIZ_ID, colmVEKALET_PULU_DOVIZ_ID, colmIFLAS_BASVURMA_HARCI_DOVIZ_ID, colmIFLASIN_ACILMASI_HARCI_DOVIZ_ID, colmILK_TEBLIGAT_GIDERI_DOVIZ_ID, colmTAHLIYE_HARCI_DOVIZ_ID, colmTESLIM_HARCI_DOVIZ_ID, colmFERAGAT_HARCI_DOVIZ_ID, colmTO_YONETIMG_TAZMINATI_DOVIZ_ID, colmFORM_TIP_ID, colmFOY_DURUM_ID, colmFOY_NO, colmREFERANS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmADLI_BIRIM_NO_ID, colmADLI_BIRIM_ADLIYE_ID, colmICRA_OZEL_KOD1_ID, colmICRA_OZEL_KOD2_ID, colmICRA_OZEL_KOD3_ID, colmICRA_OZEL_KOD4_ID, colmTAKIBIN_AVUKATA_INTIKAL_TARIHI, colmFOY_ARSIV_TARIHI, colmFOY_INFAZ_TARIHI, colmTAKIBIN_MUVEKKILE_IADE_TARIHI, colmSON_HESAP_TARIHI, colmBIR_YIL_KAC_GUN, colmASIL_ALACAK, colmISLEMIS_FAIZ, colmBSMV_TO, colmKKDV_TO, colmOIV_TO, colmKDV_TO, colmIH_VEKALET_UCRETI, colmIH_GIDERI, colmIT_HACIZDE_ODENEN, colmKARSILIKSIZ_CEK_TAZMINATI, colmCEK_KOMISYONU, colmILAM_YARGILAMA_GIDERI, colmILAM_BK_YARG_ONAMA, colmILAM_TEBLIG_GIDERI, colmILAM_INKAR_TAZMINATI, colmILAM_VEK_UCR, colmPROTESTO_GIDERI, colmIHTAR_GIDERI, colmOZEL_TAZMINAT, colmOZEL_TUTAR1_FAIZ_ORANI, colmOZEL_TUTAR1_KONU_ID, colmOZEL_TUTAR1, colmOZEL_TUTAR2_KONU_ID, colmOZEL_TUTAR2, colmOZEL_TUTAR3_KONU_ID, colmOZEL_TUTAR3, colmTAKIP_CIKISI, colmSONRAKI_FAIZ, colmSONRAKI_TAZMINAT, colmBSMV_TS, colmOIV_TS, colmKDV_TS, colmILK_GIDERLER, colmPESIN_HARC, colmODENEN_TAHSIL_HARCI, colmKALAN_TAHSIL_HARCI, colmMASAYA_KATILMA_HARCI, colmPAYLASMA_HARCI, colmDAVA_GIDERLERI, colmDIGER_GIDERLER, colmTAKIP_VEKALET_UCRETI_KATSAYI, colmTAKIP_VEKALET_UCRETI, colmDAVA_INKAR_TAZMINATI, colmDAVA_VEKALET_UCRETI, colmODEME_TOPLAMI, colmTO_ODEME_TOPLAMI, colmMAHSUP_TOPLAMI, colmFERAGAT_TOPLAMI, colmALACAK_TOPLAMI, colmKALAN, colmTAHLIYE_VEK_UCR, colmDIGER_HARC, colmTD_GIDERI, colmTD_BAKIYE_HARC, colmTD_VEK_UCR, colmTD_TEBLIG_GIDERI, colmBIRIKMIS_NAFAKA, colmICRA_INKAR_TAZMINATI, colmDAMGA_PULU, colmACIKLAMA, colmPROTOKOL_MIKTARI, colmPROTOKOL_FAIZ_ORANI, colmPROTOKOL_TARIHI, colmKARSILIK_TUTARI, colmTO_MASRAF_TOPLAMI, colmTS_MASRAF_TOPLAMI, colmTUM_MASRAF_TOPLAMI, colmHARC_TOPLAMI, colmTO_VEKALET_TOPLAMI, colmTS_VEKALET_TOPLAMI, colmTUM_VEKALET_TOPLAMI, colmKARSI_VEKALET_TOPLAMI, colmFAIZ_TOPLAMI, colmILAM_UCRETLER_TOPLAMI, colmIT_VEKALET_UCRETI, colmIT_GIDERI, colmTO_ODEME_MAHSUP_TOPLAMI, colmPAYLASIM_TIPI, colmTS_HESAP_TIP_ID, colmTO_HESAP_TIP_ID, colmBASVURMA_HARCI, colmVEKALET_HARCI, colmVEKALET_PULU, colmIFLAS_BASVURMA_HARCI, colmIFLASIN_ACILMASI_HARCI, colmILK_TEBLIGAT_GIDERI, colmTAHLIYE_HARCI, colmTESLIM_HARCI, colmFERAGAT_HARCI, colmTO_YONETIMG_TAZMINATI, colmASAMA_ID, colmTAKIP_TALEP_ID, colmCARI_ID });
            grid.GroupSummary.AddRange(new[] { summaryASIL_ALACAK_DOVIZ_ID, summaryASIL_ALACAK, summaryISLEMIS_FAIZ_DOVIZ_ID, summaryISLEMIS_FAIZ, summaryBSMV_TO_DOVIZ_ID, summaryBSMV_TO, summaryKKDV_TO_DOVIZ_ID, summaryKKDV_TO, summaryOIV_TO, summaryKDV_TO_DOVIZ_ID, summaryKDV_TO, summaryIH_VEKALET_UCRETI_DOVIZ_ID, summaryIH_VEKALET_UCRETI, summaryIH_GIDERI_DOVIZ_ID, summaryIH_GIDERI, summaryIT_HACIZDE_ODENEN_DOVIZ_ID, summaryIT_HACIZDE_ODENEN, summaryKARSILIKSIZ_CEK_TAZMINATI_DOVIZ_ID, summaryKARSILIKSIZ_CEK_TAZMINATI, summaryCEK_KOMISYONU_DOVIZ_ID, summaryCEK_KOMISYONU, summaryILAM_YARGILAMA_GIDERI_DOVIZ_ID, summaryILAM_YARGILAMA_GIDERI, summaryILAM_BK_YARG_ONAMA_DOVIZ_ID, summaryILAM_BK_YARG_ONAMA, summaryILAM_TEBLIG_GIDERI_DOVIZ_ID, summaryILAM_TEBLIG_GIDERI, summaryILAM_INKAR_TAZMINATI_DOVIZ_ID, summaryILAM_INKAR_TAZMINATI, summaryILAM_VEK_UCR_DOVIZ_ID, summaryILAM_VEK_UCR, summaryOIV_TO_DOVIZ_ID, summaryPROTESTO_GIDERI_DOVIZ_ID, summaryPROTESTO_GIDERI, summaryIHTAR_GIDERI_DOVIZ_ID, summaryIHTAR_GIDERI, summaryOZEL_TAZMINAT_DOVIZ_ID, summaryOZEL_TAZMINAT, summaryOZEL_TUTAR1_DOVIZ_ID, summaryOZEL_TUTAR1, summaryOZEL_TUTAR2_DOVIZ_ID, summaryOZEL_TUTAR2, summaryOZEL_TUTAR3_DOVIZ_ID, summaryOZEL_TUTAR3, summaryTAKIP_CIKISI_DOVIZ_ID, summaryTAKIP_CIKISI, summarySONRAKI_FAIZ_DOVIZ_ID, summarySONRAKI_FAIZ, summarySONRAKI_TAZMINAT_DOVIZ_ID, summarySONRAKI_TAZMINAT, summaryBSMV_TS_DOVIZ_ID, summaryBSMV_TS, summaryOIV_TS_DOVIZ_ID, summaryOIV_TS, summaryKDV_TS_DOVIZ_ID, summaryKDV_TS, summaryILK_GIDERLER_DOVIZ_ID, summaryILK_GIDERLER, summaryPESIN_HARC_DOVIZ_ID, summaryPESIN_HARC, summaryODENEN_TAHSIL_HARCI_DOVIZ_ID, summaryODENEN_TAHSIL_HARCI, summaryKALAN_TAHSIL_HARCI_DOVIZ_ID, summaryKALAN_TAHSIL_HARCI, summaryMASAYA_KATILMA_HARCI_DOVIZ_ID, summaryMASAYA_KATILMA_HARCI, summaryPAYLASMA_HARCI_DOVIZ_ID, summaryPAYLASMA_HARCI, summaryDAVA_GIDERLERI_DOVIZ_ID, summaryDAVA_GIDERLERI, summaryDIGER_GIDERLER_DOVIZ_ID, summaryDIGER_GIDERLER, summaryTAKIP_VEKALET_UCRETI_DOVIZ_ID, summaryTAKIP_VEKALET_UCRETI, summaryDAVA_INKAR_TAZMINATI_DOVIZ_ID, summaryDAVA_INKAR_TAZMINATI, summaryDAVA_VEKALET_UCRETI_DOVIZ_ID, summaryDAVA_VEKALET_UCRETI, summaryODEME_TOPLAMI_DOVIZ_ID, summaryODEME_TOPLAMI, summaryTO_ODEME_TOPLAMI_DOVIZ_ID, summaryTO_ODEME_TOPLAMI, summaryMAHSUP_TOPLAMI_DOVIZ_ID, summaryMAHSUP_TOPLAMI, summaryFERAGAT_TOPLAMI, summaryFERAGAT_TOPLAMI_DOVIZ_ID, summaryALACAK_TOPLAMI_DOVIZ_ID, summaryALACAK_TOPLAMI, summaryKALAN_DOVIZ_ID, summaryKALAN, summaryTAHLIYE_VEK_UCR_DOVIZ_ID, summaryTAHLIYE_VEK_UCR, summaryDIGER_HARC_DOVIZ_ID, summaryDIGER_HARC, summaryTD_GIDERI_DOVIZ_ID, summaryTD_GIDERI, summaryTD_BAKIYE_HARC_DOVIZ_ID, summaryTD_BAKIYE_HARC, summaryTD_VEK_UCR_DOVIZ_ID, summaryTD_VEK_UCR, summaryTD_TEBLIG_GIDERI_DOVIZ_ID, summaryTD_TEBLIG_GIDERI, summaryBIRIKMIS_NAFAKA_DOVIZ_ID, summaryBIRIKMIS_NAFAKA, summaryICRA_INKAR_TAZMINATI_DOVIZ_ID, summaryICRA_INKAR_TAZMINATI, summaryDAMGA_PULU_DOVIZ_ID, summaryDAMGA_PULU, summaryPROTOKOL_MIKTARI_DOVIZ_ID, summaryPROTOKOL_MIKTARI, summaryKARSILIK_TUTARI_DOVIZ_ID, summaryKARSILIK_TUTARI, summaryTO_MASRAF_TOPLAMI, summaryTO_MASRAF_TOPLAMI_DOVIZ_ID, summaryTS_MASRAF_TOPLAMI, summaryTS_MASRAF_TOPLAMI_DOVIZ_ID, summaryTUM_MASRAF_TOPLAMI, summaryTUM_MASRAF_TOPLAMI_DOVIZ_ID, summaryHARC_TOPLAMI, summaryHARC_TOPLAMI_DOVIZ_ID, summaryTO_VEKALET_TOPLAMI_DOVIZ_ID, summaryTO_VEKALET_TOPLAMI, summaryTS_VEKALET_TOPLAMI, summaryTS_VEKALET_TOPLAMI_DOVIZ_ID, summaryTUM_VEKALET_TOPLAMI, summaryTUM_VEKALET_TOPLAMI_DOVIZ_ID, summaryKARSI_VEKALET_TOPLAMI, summaryKARSI_VEKALET_TOPLAMI_DOVIZ_ID, summaryFAIZ_TOPLAMI, summaryFAIZ_TOPLAMI_DOVIZ_ID, summaryILAM_UCRETLER_TOPLAMI, summaryILAM_UCRETLER_TOPLAMI_DOVIZ_ID, summaryIT_VEKALET_UCRETI_DOVIZ_ID, summaryIT_VEKALET_UCRETI, summaryIT_GIDERI_DOVIZ_ID, summaryIT_GIDERI, summaryTO_ODEME_MAHSUP_TOPLAMI, summaryTO_ODEME_MAHSUP_TOPLAMI_DOVIZ_ID, summaryBASVURMA_HARCI, summaryBASVURMA_HARCI_DOVIZ_ID, summaryVEKALET_HARCI, summaryVEKALET_HARCI_DOVIZ_ID, summaryVEKALET_PULU, summaryVEKALET_PULU_DOVIZ_ID, summaryIFLAS_BASVURMA_HARCI, summaryIFLAS_BASVURMA_HARCI_DOVIZ_ID, summaryIFLASIN_ACILMASI_HARCI, summaryIFLASIN_ACILMASI_HARCI_DOVIZ_ID, summaryILK_TEBLIGAT_GIDERI, summaryILK_TEBLIGAT_GIDERI_DOVIZ_ID, summaryTAHLIYE_HARCI, summaryTAHLIYE_HARCI_DOVIZ_ID, summaryTESLIM_HARCI, summaryTESLIM_HARCI_DOVIZ_ID, summaryFERAGAT_HARCI, summaryFERAGAT_HARCI_DOVIZ_ID, summaryTO_YONETIMG_TAZMINATI_DOVIZ_ID, summaryTO_YONETIMG_TAZMINATI });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.R_TI_BIL_HESAPLI_KAPSAMLI_GENEL_TARAFLIs;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void IsTablo()
        {
            var colmIS_SOZLESME_ID = colmnVer("IS SOZLESME ID", "IS_SOZLESME_ID", true, 1, null);
            var colmKATEGORI_ID = colmnVer("KATEGORI ID", "KATEGORI_ID", true, 2, null);
            var colmYAPILACAK_IS = colmnVer("YAPILACAK IS", "YAPILACAK_IS", true, 3, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 4, null);
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 5, null);
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 6, null);
            var colmFORM_ID = colmnVer("FORM ID", "FORM_ID", true, 7, null);
            var colmTABLO_ID = colmnVer("TABLO ID", "TABLO_ID", true, 8, null);
            var colmMODUL_ID = colmnVer("MODUL ID", "MODUL_ID", true, 9, null);
            var colmDURUM = colmnVer("DURUM", "DURUM", true, 10, null);
            var colmMUHASEBELESTIRILSIN_MI = colmnVer("MUHASEBELESTIRILSIN MI", "MUHASEBELESTIRILSIN_MI", true, 11, null);
            var colmHATIRLATILSIN_MI = colmnVer("HATIRLATILSIN MI", "HATIRLATILSIN_MI", true, 12, null);
            var colmAJANDADA_GORUNSUN_MU = colmnVer("AJANDADA GORUNSUN MU", "AJANDADA_GORUNSUN_MU", true, 13, null);
            var colmTIP = colmnVer("TIP", "TIP", true, 14, null);
            var colmBITIS_TARIHI = colmnVer("BITIS TARIHI", "BITIS_TARIHI", true, 15, null);
            var colmBASLANGIC_TARIHI = colmnVer("BASLANGIC TARIHI", "BASLANGIC_TARIHI", true, 16, null);
            var colmONGORULEN_BITIS_TARIHI = colmnVer("ONGORULEN BITIS TARIHI", "ONGORULEN_BITIS_TARIHI", true, 17, null);
            var colmONGORULEN_BITIS_ZAMANI = colmnVer("ONGORULEN BITIS ZAMANI", "ONGORULEN_BITIS_ZAMANI", true, 18, null);
            var colmYER = colmnVer("YER", "YER", true, 19, null);
            var colmKONU = colmnVer("KONU", "KONU", true, 20, null);
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 21, null);
            var colmHER_GUN_MU = colmnVer("HER GUN MU", "HER_GUN_MU", true, 22, null);
            var colmSTATU = colmnVer("STATU", "STATU", true, 23, null);
            var colmETIKET = colmnVer("ETIKET", "ETIKET", true, 24, null);
            var colmHATIRLATMA_BILGISI = colmnVer("HATIRLATMA BILGISI", "HATIRLATMA_BILGISI", true, 25, null);
            var colmTEKRARLAMA_BILGISI = colmnVer("TEKRARLAMA BILGISI", "TEKRARLAMA_BILGISI", true, 26, null);
            var colmIS_NO = colmnVer("IS NO", "IS_NO", true, 27, null);
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 28, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 29, null);
            var colmKLASOR_KODU = colmnVer("KLASOR KODU", "KLASOR_KODU", true, 30, null);
            var colmSUBE_KODU = colmnVer("SUBE KODU", "SUBE_KODU", true, 31, null);
            var colmKONTROL_NE_ZAMAN = colmnVer("KONTROL NE ZAMAN", "KONTROL_NE_ZAMAN", true, 32, null);
            var colmKONTROL_KIM = colmnVer("KONTROL KIM", "KONTROL_KIM", true, 33, null);
            var colmKONTROL_VERSIYON = colmnVer("KONTROL VERSIYON", "KONTROL_VERSIYON", true, 34, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 35, null);
            var colmSTAMP = colmnVer("STAMP", "STAMP", true, 36, null);
            var colmTARAF_TIP = colmnVer("TARAF TIP", "TARAF_TIP", true, 37, null);
            var colmTARAF_ID = colmnVer("TARAF ID", "TARAF_ID", true, 38, null);
            var colmTEBLIGAT_ID = colmnVer("TEBLIGAT ID", "TEBLIGAT_ID", true, 39, null);
            var colmTEBLIGAT_MUHATAP_ID = colmnVer("TEBLIGAT MUHATAP ID", "TEBLIGAT_MUHATAP_ID", true, 40, null);
            var colmONCELIK_ID = colmnVer("ONCELIK ID", "ONCELIK_ID", true, 41, null);
            var colmIS_HEDEF_TIP_ = colmnVer("IS HEDEF TIP ", "IS_HEDEF_TIP_", true, 42, null);
            var colmMUHASEBE_ID = colmnVer("MUHASEBE ID", "MUHASEBE_ID", true, 43, null);
            var colmBIL_IS_CARI_ID = colmnVer("BIL IS CARI ID", "BIL_IS_CARI_ID", true, 44, null);
            var colmAKILLI_ID = colmnVer("AKILLI ID", "AKILLI_ID", true, 45, null);
            var colmGORUSME_ID = colmnVer("GORUSME ID", "GORUSME_ID", true, 46, null);
            var colmHATIRLATMA_ID = colmnVer("HATIRLATMA ID", "HATIRLATMA_ID", true, 47, null);
            var colmICRA_FOY_NO = colmnVer("ICRA FOY NO", "ICRA_FOY_NO", true, 48, null);
            var colmDAVA_FOY_NO = colmnVer("DAVA FOY NO", "DAVA_FOY_NO", true, 49, null);
            var colmDAVA_FOY_OZET_ID = colmnVer("DAVA FOY OZET ID", "DAVA_FOY_OZET_ID", true, 50, null);
            var colmDAVA_FOY_OZET_NO = colmnVer("DAVA FOY OZET NO", "DAVA_FOY_OZET_NO", true, 51, null);
            var colmHAZIRLIK_NO = colmnVer("HAZIRLIK NO", "HAZIRLIK_NO", true, 52, null);
            var colmRUCU_NO = colmnVer("RUCU NO", "RUCU_NO", true, 53, null);
            var colmHACIZ_SIRA_NO = colmnVer("HACIZ SIRA NO", "HACIZ_SIRA_NO", true, 54, null);
            var colmSATIS_SIRA_NO = colmnVer("SATIS SIRA NO", "SATIS_SIRA_NO", true, 55, null);
            var colmIS_HEDEF_TIP = colmnVer("IS HEDEF TIP", "IS_HEDEF_TIP", true, 56, null);
            var colmBASLAMA_TARIH = colmnVer("BASLAMA TARIH", "BASLAMA_TARIH", true, 57, null);
            var colmBASLAMA_SAAT = colmnVer("BASLAMA SAAT", "BASLAMA_SAAT", true, 58, null);
            var colmONGORULEN_BITIS_TARIH = colmnVer("ONGORULEN BITIS TARIH", "ONGORULEN_BITIS_TARIH", true, 59, null);
            var colmONGORULEN_BITIS_SAAT = colmnVer("ONGORULEN BITIS SAAT", "ONGORULEN_BITIS_SAAT", true, 60, null);
            var colmBITIS_TARIH = colmnVer("BITIS TARIH", "BITIS_TARIH", true, 61, null);
            var colmBITIS_SAAT = colmnVer("BITIS SAAT", "BITIS_SAAT", true, 62, null);
            var colmKIM_YAPACAK_CARI_ID = colmnVer("KIM YAPACAK CARI ID", "KIM_YAPACAK_CARI_ID", true, 63, null);
            var colmKATEGORI_AD = colmnVer("KATEGORI AD", "KATEGORI_AD", true, 64, null);
            var colmADLI_BIRIM_ADLIYE = colmnVer("ADLI BIRIM ADLIYE", "ADLI_BIRIM_ADLIYE", true, 65, null);
            var colmADLI_BIRIM_GOREV = colmnVer("ADLI BIRIM GOREV", "ADLI_BIRIM_GOREV", true, 66, null);
            var colmADLI_BIRIM_NO = colmnVer("ADLI BIRIM NO", "ADLI_BIRIM_NO", true, 67, null);
            var colmISI_PLANLAYAN_CARI_ID = colmnVer("ISI PLANLAYAN CARI ID", "ISI_PLANLAYAN_CARI_ID", true, 68, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 69, null);

            GridView gvMain = (GridView)gridRaporCntrol.MainView;

            gvMain.Columns.AddRange(new GridColumn[]
                                               {
                                                   colmIS_SOZLESME_ID, colmKATEGORI_ID, colmYAPILACAK_IS,
                                                   colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID,
                                                   colmADLI_BIRIM_NO_ID,
                                                   colmFORM_ID, colmTABLO_ID, colmMODUL_ID, colmDURUM,
                                                   colmMUHASEBELESTIRILSIN_MI, colmHATIRLATILSIN_MI,
                                                   colmAJANDADA_GORUNSUN_MU, colmTIP, colmBITIS_TARIHI,
                                                   colmBASLANGIC_TARIHI, colmONGORULEN_BITIS_TARIHI,
                                                   colmONGORULEN_BITIS_ZAMANI, colmYER, colmKONU, colmACIKLAMA,
                                                   colmHER_GUN_MU, colmSTATU, colmETIKET, colmHATIRLATMA_BILGISI,
                                                   colmTEKRARLAMA_BILGISI, colmIS_NO, colmESAS_NO, colmKAYIT_TARIHI,
                                                   colmKLASOR_KODU, colmSUBE_KODU, colmKONTROL_NE_ZAMAN, colmKONTROL_KIM,
                                                   colmKONTROL_VERSIYON, colmREFERANS_NO, colmSTAMP, colmTARAF_TIP,
                                                   colmTARAF_ID, colmTEBLIGAT_ID, colmTEBLIGAT_MUHATAP_ID,
                                                   colmONCELIK_ID,
                                                   colmIS_HEDEF_TIP_, colmMUHASEBE_ID, colmBIL_IS_CARI_ID, colmAKILLI_ID,
                                                   colmGORUSME_ID, colmHATIRLATMA_ID, colmICRA_FOY_NO, colmDAVA_FOY_NO,
                                                   colmDAVA_FOY_OZET_ID, colmDAVA_FOY_OZET_NO, colmHAZIRLIK_NO,
                                                   colmRUCU_NO, colmHACIZ_SIRA_NO, colmSATIS_SIRA_NO, colmIS_HEDEF_TIP,
                                                   colmBASLAMA_TARIH, colmBASLAMA_SAAT, colmONGORULEN_BITIS_TARIH,
                                                   colmONGORULEN_BITIS_SAAT, colmBITIS_TARIH, colmBITIS_SAAT,
                                                   colmKIM_YAPACAK_CARI_ID, colmKATEGORI_AD, colmADLI_BIRIM_ADLIYE,
                                                   colmADLI_BIRIM_GOREV, colmADLI_BIRIM_NO, colmISI_PLANLAYAN_CARI_ID,
                                                   colmTARAF_CARI_ID
                                               });

            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.R_TDI_BIL_IS_TARAFLIs;

            if (gvMain.Columns.Dolumu())
            {
                for (int i = 0; i < gvMain.Columns.Count; i++)
                {
                    gvMain.Columns[i].VisibleIndex = -1;
                }
            }
            ListeDoldur_TanimliAlanlar();
            ListDoldur_Secilenler();
        }

        private void KASA_BILGILERI_GENEL()
        {
            var colmBIRIM_FIYAT_DOVIZ_ID = colmnVer("BIRIM FIYAT DOVIZ ID", "BIRIM_FIYAT_DOVIZ_ID", true, 5, lupDoviz);
            var summaryBIRIM_FIYAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT_DOVIZ_ID", colmBIRIM_FIYAT_DOVIZ_ID, "", 2);
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 1, null);
            var colmADET = colmnVer("ADET", "ADET", true, 2, null);
            var colmBELGE_NO = colmnVer("BELGE NO", "BELGE_NO", true, 3, null);
            var colmBIRIM_FIYAT = colmnVer("BIRIM FIYAT", "BIRIM_FIYAT", true, 4, null, colmBIRIM_FIYAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIM_FIYAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT", colmBIRIM_FIYAT, "", 1);
            colmBIRIM_FIYAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIM_FIYAT.SummaryItem.FieldName = "BIRIM_FIYAT";
            colmBIRIM_FIYAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT.SummaryItem.Tag = 1;

            var colmBORC_ALACAK_ID = colmnVer("BORC ALACAK ID", "BORC_ALACAK_ID", true, 6, TablesGrids.GetTDI_KOD_MUHASEBE_BORC_ALACAKLookup());
            var colmGENEL_TOPLAM = colmnVer("GENEL TOPLAM", "GENEL_TOPLAM", true, 7, null);
            var colmHAREKET_ANA_KATEGORI_ID = colmnVer("HAREKET ANA KATEGORI ID", "HAREKET_ANA_KATEGORI_ID", true, 8, TablesGrids.GetTDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORILookup());
            var colmHAREKET_CARI_ID = colmnVer("HAREKET CARI ID", "HAREKET_CARI_ID", true, 9, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 10, null);
            var colmODEME_TIP_ID = colmnVer("ODEME TIP ID", "ODEME_TIP_ID", true, 11, TablesGrids.GetTDI_KOD_ODEME_TIPLookup());
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 12, null);
            var colmSUBE_KODU = colmnVer("SUBE KODU", "SUBE_KODU", true, 13, null);
            var colmTARIH = colmnVer("TARIH", "TARIH", true, 14, null);

            GridView grid = gridRaporCntrol.MainView as GridView;
            if (grid != null) grid.Columns.AddRange(new[]
            {
                colmBIRIM_FIYAT_DOVIZ_ID, colmACIKLAMA, colmADET, colmBELGE_NO, colmBIRIM_FIYAT, colmBORC_ALACAK_ID, colmGENEL_TOPLAM, colmHAREKET_ANA_KATEGORI_ID, colmHAREKET_CARI_ID, colmKAYIT_TARIHI, colmODEME_TIP_ID, colmREFERANS_NO, colmSUBE_KODU, colmTARIH
            });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            if (grid != null)
                grid.GroupSummary.AddRange(new[]
                                               {
                                                   summaryBIRIM_FIYAT, summaryBIRIM_FIYAT_DOVIZ_ID
                                               });
            gridRaporCntrol.DataSource = db.KASA_BILGILERIs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void KIYMETLI_EVRAK_GENEL()
        {
            var colmTUTAR_DOVIZ_ID = colmnVer("TUTAR DOVIZ ID", "TUTAR_DOVIZ_ID", true, 5, lupDoviz);
            var summaryTUTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUTAR_DOVIZ_ID", colmTUTAR_DOVIZ_ID, "", 2);
            colmTUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTUTAR_DOVIZ_ID.SummaryItem.FieldName = "TUTAR_DOVIZ_ID";
            colmTUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmKARSILIK_TUTAR_DOVIZ_ID = colmnVer("KARSILIK TUTAR DOVIZ ID", "KARSILIK_TUTAR_DOVIZ_ID", true, 15, lupDoviz);
            var summaryKARSILIK_TUTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTAR_DOVIZ_ID", colmKARSILIK_TUTAR_DOVIZ_ID, "", 2);
            colmKARSILIK_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmKARSILIK_TUTAR_DOVIZ_ID.SummaryItem.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            colmKARSILIK_TUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmEVRAK_TUR_ID = colmnVer("EVRAK TUR ID", "EVRAK_TUR_ID", true, 1, TablesGrids.GetTDI_KOD_KIYMETLI_EVRAK_TURLookup());
            var colmEVRAK_KAYIT_TARIHI = colmnVer("EVRAK KAYIT TARIHI", "EVRAK_KAYIT_TARIHI", true, 2, null);
            var colmEVRAK_VADE_TARIHI = colmnVer("EVRAK VADE TARIHI", "EVRAK_VADE_TARIHI", true, 3, null);
            var colmEVRAK_TANZIM_TARIHI = colmnVer("EVRAK TANZIM TARIHI", "EVRAK_TANZIM_TARIHI", true, 4, null);
            var colmTUTAR = colmnVer("TUTAR", "TUTAR", true, 6, null, colmTUTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TUTAR", colmTUTAR, "", 1);
            colmTUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTUTAR.SummaryItem.FieldName = "TUTAR";
            colmTUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTUTAR.SummaryItem.Tag = 1;

            var colmNE_SEKILDE_AHZOLUNDUGU = colmnVer("NE SEKILDE AHZOLUNDUGU", "NE_SEKILDE_AHZOLUNDUGU", true, 7, null);
            var colmBANKA_ID = colmnVer("BANKA ID", "BANKA_ID", true, 8, TablesGrids.GetTDI_KOD_BANKALookup());
            var colmSUBE_ID = colmnVer("SUBE ID", "SUBE_ID", true, 9, TablesGrids.GetTDI_KOD_BANKA_SUBELookup());
            var colmBANKA_SUBE_KODU = colmnVer("BANKA SUBE KODU", "BANKA_SUBE_KODU", true, 10, null);
            var colmHESAP_NO = colmnVer("HESAP NO", "HESAP_NO", true, 11, null);
            var colmCEK_NO = colmnVer("CEK NO", "CEK_NO", true, 12, null);
            var colmSORULDUGU_TARIH = colmnVer("SORULDUGU TARIH", "SORULDUGU_TARIH", true, 13, null);
            var colmSORULMA_SONUCU = colmnVer("SORULMA SONUCU", "SORULMA_SONUCU", true, 14, null);
            var colmKARSILIK_TUTAR = colmnVer("KARSILIK TUTAR", "KARSILIK_TUTAR", true, 16, null, colmKARSILIK_TUTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryKARSILIK_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KARSILIK_TUTAR", colmKARSILIK_TUTAR, "", 1);
            colmKARSILIK_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKARSILIK_TUTAR.SummaryItem.FieldName = "KARSILIK_TUTAR";
            colmKARSILIK_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKARSILIK_TUTAR.SummaryItem.Tag = 1;

            var colmSORAN_ID = colmnVer("SORAN ID", "SORAN_ID", true, 17, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmARKASI_YAZILDI_MI = colmnVer("ARKASI YAZILDI MI", "ARKASI_YAZILDI_MI", true, 18);
            var colmSERH_ACIKLAMASI = colmnVer("SERH ACIKLAMASI", "SERH_ACIKLAMASI", true, 19, null);
            var colmSIKAYET_EDILDI_MI = colmnVer("SIKAYET EDILDI MI", "SIKAYET_EDILDI_MI", true, 20, null);
            var colmKESIDE_YERI = colmnVer("KESIDE YERI", "KESIDE_YERI", true, 21, null);
            var colmODEME_YERI = colmnVer("ODEME YERI", "ODEME_YERI", true, 22, null);
            var colmISLEMLER_BASLADIMI = colmnVer("ISLEMLER BASLADIMI", "ISLEMLER_BASLADIMI", true, 23, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 24, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_TIP_ID = colmnVer("TARAF TIP ID", "TARAF_TIP_ID", true, 25, TablesGrids.GetTDI_KOD_KIYMETLI_EVRAK_TARAF_TIPLookup());
            var colmTAKIBE_KONULDU_MU = colmnVer("TAKIBE KONULDU MU", "TAKIBE_KONULDU_MU", true, 26, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 27, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 28, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 29, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 30, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 31, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 32, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 33, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 34, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 35, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 36, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 37, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 38, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 39, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 40, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 41, null);
            var colmTipi = colmnVer("Tipi", "Tipi", true, 42, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[]
                                      {
                                          colmTUTAR_DOVIZ_ID, colmKARSILIK_TUTAR_DOVIZ_ID, colmEVRAK_TUR_ID,
                                          colmEVRAK_KAYIT_TARIHI, colmEVRAK_VADE_TARIHI, colmEVRAK_TANZIM_TARIHI, colmTUTAR
                                          , colmNE_SEKILDE_AHZOLUNDUGU, colmBANKA_ID, colmSUBE_ID, colmBANKA_SUBE_KODU,
                                          colmHESAP_NO, colmCEK_NO, colmSORULDUGU_TARIH, colmSORULMA_SONUCU,
                                          colmKARSILIK_TUTAR, colmSORAN_ID, colmARKASI_YAZILDI_MI, colmSERH_ACIKLAMASI,
                                          colmSIKAYET_EDILDI_MI, colmKESIDE_YERI, colmODEME_YERI, colmISLEMLER_BASLADIMI,
                                          colmTARAF_CARI_ID, colmTARAF_TIP_ID, colmTAKIBE_KONULDU_MU, colmFOY_NO,
                                          colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID,
                                          colmESAS_NO, colmTAKIP_T, colmREFERANS_NO2, colmREFERANS_NO3, colmREFERANS_NO,
                                          colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID,
                                          colmTALEP, colmTipi
                                      });

            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);

            grid.GroupSummary.AddRange(new[]
                                           {
                                               summaryTUTAR_DOVIZ_ID, summaryTUTAR, summaryKARSILIK_TUTAR_DOVIZ_ID,
                                               summaryKARSILIK_TUTAR
                                           });

            gridRaporCntrol.DataSource = db.KIYMETLI_EVRAK_TARAFLI_BIRLESIKs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void MAL_SATIS_SURECI()
        {
            var colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID = colmnVer("HACIZ TOPLAM DEGERI DOVIZ ID", "HACIZ_TOPLAM_DEGERI_DOVIZ_ID", true, 35, lupDoviz);
            var summaryHACIZ_TOPLAM_DEGERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZ_TOPLAM_DEGERI_DOVIZ_ID", colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID, "", 2);
            colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID.SummaryItem.FieldName = "HACIZ_TOPLAM_DEGERI_DOVIZ_ID";
            colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = colmnVer("HACIZLI MAL SATIR TOPLAM DOVIZ ID", "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID", true, 54, lupDoviz);
            var summaryHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID", colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID, "", 2);
            colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.SummaryItem.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHACIZLI_MAL_DEGERI_DOVIZ_ID = colmnVer("HACIZLI MAL DEGERI DOVIZ ID", "HACIZLI_MAL_DEGERI_DOVIZ_ID", true, 57, lupDoviz);
            var summaryHACIZLI_MAL_DEGERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZLI_MAL_DEGERI_DOVIZ_ID", colmHACIZLI_MAL_DEGERI_DOVIZ_ID, "", 2);
            colmHACIZLI_MAL_DEGERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHACIZLI_MAL_DEGERI_DOVIZ_ID.SummaryItem.FieldName = "HACIZLI_MAL_DEGERI_DOVIZ_ID";
            colmHACIZLI_MAL_DEGERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZLI_MAL_DEGERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmISTIRAK_TUTARI_DOVIZ_ID = colmnVer("ISTIRAK TUTARI DOVIZ ID", "ISTIRAK_TUTARI_DOVIZ_ID", true, 68, lupDoviz);
            var summaryISTIRAK_TUTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISTIRAK_TUTARI_DOVIZ_ID", colmISTIRAK_TUTARI_DOVIZ_ID, "", 2);
            colmISTIRAK_TUTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmISTIRAK_TUTARI_DOVIZ_ID.SummaryItem.FieldName = "ISTIRAK_TUTARI_DOVIZ_ID";
            colmISTIRAK_TUTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISTIRAK_TUTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTOPLAM_SATIS_DEGERI_DOVIZ_ID = colmnVer("TOPLAM SATIS DEGERI DOVIZ ID", "TOPLAM_SATIS_DEGERI_DOVIZ_ID", true, 110, lupDoviz);
            var summaryTOPLAM_SATIS_DEGERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TOPLAM_SATIS_DEGERI_DOVIZ_ID", colmTOPLAM_SATIS_DEGERI_DOVIZ_ID, "", 2);
            colmTOPLAM_SATIS_DEGERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmTOPLAM_SATIS_DEGERI_DOVIZ_ID.SummaryItem.FieldName = "TOPLAM_SATIS_DEGERI_DOVIZ_ID";
            colmTOPLAM_SATIS_DEGERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTOPLAM_SATIS_DEGERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmICRA_SATIS_BEDELI_DOVIZ_ID = colmnVer("ICRA SATIS BEDELI DOVIZ ID", "ICRA_SATIS_BEDELI_DOVIZ_ID", true, 120, lupDoviz);
            var summaryICRA_SATIS_BEDELI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_SATIS_BEDELI_DOVIZ_ID", colmICRA_SATIS_BEDELI_DOVIZ_ID, "", 2);
            colmICRA_SATIS_BEDELI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmICRA_SATIS_BEDELI_DOVIZ_ID.SummaryItem.FieldName = "ICRA_SATIS_BEDELI_DOVIZ_ID";
            colmICRA_SATIS_BEDELI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_SATIS_BEDELI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDOSYA_GIREN_BEDEL_DOVIZ_ID = colmnVer("DOSYA GIREN BEDEL DOVIZ ID", "DOSYA_GIREN_BEDEL_DOVIZ_ID", true, 122, lupDoviz);
            var summaryDOSYA_GIREN_BEDEL_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DOSYA_GIREN_BEDEL_DOVIZ_ID", colmDOSYA_GIREN_BEDEL_DOVIZ_ID, "", 2);
            colmDOSYA_GIREN_BEDEL_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDOSYA_GIREN_BEDEL_DOVIZ_ID.SummaryItem.FieldName = "DOSYA_GIREN_BEDEL_DOVIZ_ID";
            colmDOSYA_GIREN_BEDEL_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDOSYA_GIREN_BEDEL_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHACIZ_TARIHI = colmnVer("HACIZ TARIHI", "HACIZ_TARIHI", true, 1, null);
            var colmHACIZ_SAATI = colmnVer("HACIZ SAATI", "HACIZ_SAATI", true, 2, null);
            var colmHACIZ_SIRA_NO = colmnVer("HACIZ SIRA NO", "HACIZ_SIRA_NO", true, 3, null);
            var colmBAKIYE_HACIZI_MI = colmnVer("BAKIYE HACIZI MI", "BAKIYE_HACIZI_MI", true, 4, null);
            var colmHACIZ_ISTEYEN_CARI_ID = colmnVer("HACIZ ISTEYEN CARI ID", "HACIZ_ISTEYEN_CARI_ID", true, 5, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmHACIZ_ISTENEN_CARI_ID = colmnVer("HACIZ ISTENEN CARI ID", "HACIZ_ISTENEN_CARI_ID", true, 6, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTALIMAT_MI = colmnVer("TALIMAT MI", "TALIMAT_MI", true, 7, null);
            var colmTALIMAT_ADLI_BIRIM_ADLIYE_ID = colmnVer("TALIMAT ADLI BIRIM ADLIYE ID", "TALIMAT_ADLI_BIRIM_ADLIYE_ID", true, 8, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmTALIMAT_ADLI_BIRIM_GOREV_ID = colmnVer("TALIMAT ADLI BIRIM GOREV ID", "TALIMAT_ADLI_BIRIM_GOREV_ID", true, 9, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmTALIMAT_ADLI_BIRIM_NO_ID = colmnVer("TALIMAT ADLI BIRIM NO ID", "TALIMAT_ADLI_BIRIM_NO_ID", true, 10, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmTALIMAT_BIRIM_NO = colmnVer("TALIMAT BIRIM NO", "TALIMAT_BIRIM_NO", true, 11, null);
            var colmTALIMAT_ESAS_NO = colmnVer("TALIMAT ESAS NO", "TALIMAT_ESAS_NO", true, 12, null);
            var colmHACIZ_TALEP_TARIHI = colmnVer("HACIZ TALEP TARIHI", "HACIZ_TALEP_TARIHI", true, 13, null);
            var colmGECICI_HACIZ_MI = colmnVer("GECICI HACIZ MI", "GECICI_HACIZ_MI", true, 14, null);
            var colmHACIZ_KAYNAGI = colmnVer("HACIZ KAYNAGI", "HACIZ_KAYNAGI", true, 15, null);
            var colmHACIZ_KAYNAGI_IHTIYATI_TEDBIR_ID = colmnVer("HACIZ KAYNAGI IHTIYATI TEDBIR ID", "HACIZ_KAYNAGI_IHTIYATI_TEDBIR_ID", true, 16, TablesGrids.GetAV001_TDI_BIL_IHTIYATI_TEDBIRLookup());
            var colmHACIZ_KAYNAGI_IHTIYATI_HACIZ_ID = colmnVer("HACIZ KAYNAGI IHTIYATI HACIZ ID", "HACIZ_KAYNAGI_IHTIYATI_HACIZ_ID", true, 17, TablesGrids.GetAV001_TI_BIL_IHTIYATI_HACIZLookup());
            var colmICRA_TUTANAK_NO = colmnVer("ICRA TUTANAK NO", "ICRA_TUTANAK_NO", true, 18, null);
            var colmBORCLU_HAZIR_MI = colmnVer("BORCLU HAZIR MI", "BORCLU_HAZIR_MI", true, 19, null);
            var colmYUZUC_UYGULANDI_MI = colmnVer("YUZUC UYGULANDI MI", "YUZUC_UYGULANDI_MI", true, 20, null);
            var colmSURET_BIRAKILDI_MI = colmnVer("SURET BIRAKILDI MI", "SURET_BIRAKILDI_MI", true, 21, null);
            var colmCILINGIR_VAR_MI = colmnVer("CILINGIR VAR MI", "CILINGIR_VAR_MI", true, 22, null);
            var colmKOLLUK_VAR_MI = colmnVer("KOLLUK VAR MI", "KOLLUK_VAR_MI", true, 23, null);
            var colmHACIZ_MEMURU_CARI_ID = colmnVer("HACIZ MEMURU CARI ID", "HACIZ_MEMURU_CARI_ID", true, 24, null);
            var colmHACIZ_SORUMLU_PERSONEL_ID = colmnVer("HACIZ SORUMLU PERSONEL ID", "HACIZ_SORUMLU_PERSONEL_ID", true, 25, null);
            var colmSEHIR_DISI_MI = colmnVer("SEHIR DISI MI", "SEHIR_DISI_MI", true, 26, null);
            var colmHACIZ_ACIKLAMA = colmnVer("HACIZ ACIKLAMA", "HACIZ_ACIKLAMA", true, 27, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 28, null);
            var colmKLASOR_KODU = colmnVer("KLASOR KODU", "KLASOR_KODU", true, 29, null);
            var colmSUBE_KODU = colmnVer("SUBE KODU", "SUBE_KODU", true, 30, null);
            var colmPEDAGOG_CARI_ID = colmnVer("PEDAGOG CARI ID", "PEDAGOG_CARI_ID", true, 31, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmHACIZE_KABIL_MAL_YOK = colmnVer("HACIZE KABIL MAL YOK", "HACIZE_KABIL_MAL_YOK", true, 32, null);
            var colmHACIZ_ADRESI = colmnVer("HACIZ ADRESI", "HACIZ_ADRESI", true, 33, null);
            var colmHACIZ_TOPLAM_DEGERI = colmnVer("HACIZ TOPLAM DEGERI", "HACIZ_TOPLAM_DEGERI", true, 34, null, colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHACIZ_TOPLAM_DEGERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZ_TOPLAM_DEGERI", colmHACIZ_TOPLAM_DEGERI, "", 1);
            colmHACIZ_TOPLAM_DEGERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHACIZ_TOPLAM_DEGERI.SummaryItem.FieldName = "HACIZ_TOPLAM_DEGERI";
            colmHACIZ_TOPLAM_DEGERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZ_TOPLAM_DEGERI.SummaryItem.Tag = 1;

            var colmMUHAFAZALI_KAYIT_VAR_MI = colmnVer("MUHAFAZALI KAYIT VAR MI", "MUHAFAZALI_KAYIT_VAR_MI", true, 36, null);
            var colmHACIZ_EDILECEK_MAL_VAR = colmnVer("HACIZ EDILECEK MAL VAR", "HACIZ_EDILECEK_MAL_VAR", true, 37, null);
            var colmMAL_SIRA_NO = colmnVer("MAL SIRA NO", "MAL_SIRA_NO", true, 38);
            var colmHACIZLI_MAL_TUR_ID = colmnVer("HACIZLI MAL TUR ID", "HACIZLI_MAL_TUR_ID", true, 39, TablesGrids.GetTI_KOD_MAL_TURLookup());
            var colmHACIZLI_MAL_KATEGORI_ID = colmnVer("HACIZLI MAL KATEGORI ID", "HACIZLI_MAL_KATEGORI_ID", true, 40, TablesGrids.GetTI_KOD_MAL_KATEGORILookup());
            var colmHACIZLI_MAL_CINS_ID = colmnVer("HACIZLI MAL CINS ID", "HACIZLI_MAL_CINS_ID", true, 41, TablesGrids.GetTI_KOD_MAL_CINSLookup());
            var colmHACIZLI_MAL_NEVI = colmnVer("HACIZLI MAL NEVI", "HACIZLI_MAL_NEVI", true, 42, null);
            var colmHACIZLI_MAL_MARKASI = colmnVer("HACIZLI MAL MARKASI", "HACIZLI_MAL_MARKASI", true, 43, null);
            var colmHACIZLI_MAL_OZELLIKLERI = colmnVer("HACIZLI MAL OZELLIKLERI", "HACIZLI_MAL_OZELLIKLERI", true, 44, null);
            var colmHACIZLI_MAL_ACIKLAMASI = colmnVer("HACIZLI MAL ACIKLAMASI", "HACIZLI_MAL_ACIKLAMASI", true, 45, null);
            var colmHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI = colmnVer("HACZEDILEMEZLIKTEN FERAGAT VAR MI", "HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI", true, 46, null);
            var colmUCUNCU_SAHISTA_MI = colmnVer("UCUNCU SAHISTA MI", "UCUNCU_SAHISTA_MI", true, 47, null);
            var colmUCUNCU_SAHIS_CARI_ID = colmnVer("UCUNCU SAHIS CARI ID", "UCUNCU_SAHIS_CARI_ID", true, 48, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmGAYRIMENKUL_BILGI_ID = colmnVer("GAYRIMENKUL BILGI ID", "GAYRIMENKUL_BILGI_ID", false, 49, TablesGrids.GetAV001_TI_BIL_GAYRIMENKULLookup());
            var colmHACIZ_ISLEM_DURUM_ID = colmnVer("HACIZ ISLEM DURUM ID", "HACIZ_ISLEM_DURUM_ID", true, 50, TablesGrids.GetTI_KOD_HACIZ_ISLEM_DURUMLookup());
            var colmISTIHKAK_IDDIASI_VAR_MI = colmnVer("ISTIHKAK IDDIASI VAR MI", "ISTIHKAK_IDDIASI_VAR_MI", true, 51, null);
            var colmHACIZLI_MAL_ADEDI = colmnVer("HACIZLI MAL ADEDI", "HACIZLI_MAL_ADEDI", true, 52, null);
            var colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = colmnVer("HACIZLI MAL SATIR TOPLAM MIKTAR", "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR", true, 53, null, colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR", colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR, "", 1);
            colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.SummaryItem.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.SummaryItem.Tag = 1;

            var colmHACIZLI_MAL_ADET_BIRIM_ID = colmnVer("HACIZLI MAL ADET BIRIM ID", "HACIZLI_MAL_ADET_BIRIM_ID", true, 55, null);
            var colmBIRIM_KOD = colmnVer("BIRIM KOD", "BIRIM_KOD", true, 56, null);
            var colmHACIZLI_MAL_DEGERI = colmnVer("HACIZLI MAL DEGERI", "HACIZLI_MAL_DEGERI", true, 58, null, colmHACIZLI_MAL_DEGERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHACIZLI_MAL_DEGERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HACIZLI_MAL_DEGERI", colmHACIZLI_MAL_DEGERI, "", 1);
            colmHACIZLI_MAL_DEGERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHACIZLI_MAL_DEGERI.SummaryItem.FieldName = "HACIZLI_MAL_DEGERI";
            colmHACIZLI_MAL_DEGERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHACIZLI_MAL_DEGERI.SummaryItem.Tag = 1;

            var colmPARAYA_CEVRILDI_MI = colmnVer("PARAYA CEVRILDI MI", "PARAYA_CEVRILDI_MI", true, 59, null);
            var colmYEDIEMIN_CARI_ID = colmnVer("YEDIEMIN CARI ID", "YEDIEMIN_CARI_ID", true, 60, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmALACAKLI_RIZASI_VAR_MI = colmnVer("ALACAKLI RIZASI VAR MI", "ALACAKLI_RIZASI_VAR_MI", true, 61, null);
            var colmARAC_PLAKA_NO = colmnVer("ARAC PLAKA NO", "ARAC_PLAKA_NO", true, 62, null);
            var colmISTIRAK_HACIZ_TARIHI = colmnVer("ISTIRAK HACIZ TARIHI", "ISTIRAK_HACIZ_TARIHI", true, 63, null);
            var colmISTIRAK_HACIZ_SAATI = colmnVer("ISTIRAK HACIZ SAATI", "ISTIRAK_HACIZ_SAATI", true, 64, null);
            var colmISTIRAK_MIKTAR = colmnVer("ISTIRAK MIKTAR", "ISTIRAK_MIKTAR", true, 65, null);
            var colmISTIRAK_MIKTAR_BIRIM_ID = colmnVer("ISTIRAK MIKTAR BIRIM ID", "ISTIRAK_MIKTAR_BIRIM_ID", true, 66, TablesGrids.GetTDI_KOD_BIRIMLookup());
            var colmISTIRAK_MIKTAR_BIRIM_KOD = colmnVer("ISTIRAK MIKTAR BIRIM KOD", "ISTIRAK_MIKTAR_BIRIM_KOD", true, 67, null);
            var colmISTIRAK_TUTARI = colmnVer("ISTIRAK TUTARI", "ISTIRAK_TUTARI", true, 69, null, colmISTIRAK_TUTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryISTIRAK_TUTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISTIRAK_TUTARI", colmISTIRAK_TUTARI, "", 1);
            colmISTIRAK_TUTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmISTIRAK_TUTARI.SummaryItem.FieldName = "ISTIRAK_TUTARI";
            colmISTIRAK_TUTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISTIRAK_TUTARI.SummaryItem.Tag = 1;

            var colmISTIRAK_ISTEYEN_CARI_ID = colmnVer("ISTIRAK ISTEYEN CARI ID", "ISTIRAK_ISTEYEN_CARI_ID", true, 70, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmISTIRAK_ISTENEN_CARI_ID = colmnVer("ISTIRAK ISTENEN CARI ID", "ISTIRAK_ISTENEN_CARI_ID", true, 71, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmISTIRAK_TALIMAT_ADLI_BIRIM_ADLIYE_ID = colmnVer("ISTIRAK TALIMAT ADLI BIRIM ADLIYE ID", "ISTIRAK_TALIMAT_ADLI_BIRIM_ADLIYE_ID", true, 72, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmISTIRAK_TALIMAT_ADLI_BIRIM_GOREV_ID = colmnVer("ISTIRAK TALIMAT ADLI BIRIM GOREV ID", "ISTIRAK_TALIMAT_ADLI_BIRIM_GOREV_ID", true, 73, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmISTIRAK_TALIMAT_ADLI_BIRIM_NO_ID = colmnVer("ISTIRAK TALIMAT ADLI BIRIM NO ID", "ISTIRAK_TALIMAT_ADLI_BIRIM_NO_ID", true, 74, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmISTIRAK_TALIMAT_ICRA_ESAS_NO = colmnVer("ISTIRAK TALIMAT ICRA ESAS NO", "ISTIRAK_TALIMAT_ICRA_ESAS_NO", true, 75, null);
            var colmHACIZ_ISTIRAK_TALEP_TARIHI = colmnVer("HACIZ ISTIRAK TALEP TARIHI", "HACIZ_ISTIRAK_TALEP_TARIHI", true, 76, null);
            var colmISTIHKAK_IDDIA_TARIHI = colmnVer("ISTIHKAK IDDIA TARIHI", "ISTIHKAK_IDDIA_TARIHI", true, 77, null);
            var colmISTIHKAK_IDDIA_EDEN_ID = colmnVer("ISTIHKAK IDDIA EDEN ID", "ISTIHKAK_IDDIA_EDEN_ID", true, 78, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmISTIHKAK_IDDIASINA_ITIRAZ_TARIHI = colmnVer("ISTIHKAK IDDIASINA ITIRAZ TARIHI", "ISTIHKAK_IDDIASINA_ITIRAZ_TARIHI", true, 79, null);
            var colmKIYMET_TAKDIRI_TARIHI = colmnVer("KIYMET TAKDIRI TARIHI", "KIYMET_TAKDIRI_TARIHI", true, 80, null);
            var colmKIYMET_TAKDIRI_ISTEME_TARIHI = colmnVer("KIYMET TAKDIRI ISTEME TARIHI", "KIYMET_TAKDIRI_ISTEME_TARIHI", true, 81, null);
            var colmKIYMET_TAKDIRI_YAPAN1_ID = colmnVer("KIYMET TAKDIRI YAPAN1 ID", "KIYMET_TAKDIRI_YAPAN1_ID", true, 82, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmKIYMET_TAKDIRI_YAPAN2_ID = colmnVer("KIYMET TAKDIRI YAPAN2 ID", "KIYMET_TAKDIRI_YAPAN2_ID", true, 83, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmRAPOR_TARIHI1 = colmnVer("RAPOR TARIHI1", "RAPOR_TARIHI1", true, 84, null);
            var colmRAPOR_TARIHI2 = colmnVer("RAPOR TARIHI2", "RAPOR_TARIHI2", true, 85, null);
            var colmDEGERIN_KESINLESME_TARIHI = colmnVer("DEGERIN KESINLESME TARIHI", "DEGERIN_KESINLESME_TARIHI", true, 86, null);
            var colmITIRAZ_VARMI = colmnVer("ITIRAZ VARMI", "ITIRAZ_VARMI", true, 87, null);
            var colmITIRAZ_SONUCU = colmnVer("ITIRAZ SONUCU", "ITIRAZ_SONUCU", true, 88, null);
            var colmSATIS_SIRA_NO = colmnVer("SATIS SIRA NO", "SATIS_SIRA_NO", true, 89, null);
            var colmSATISIN_ISTENME_SEKLI_ID = colmnVer("SATISIN ISTENME SEKLI ID", "SATISIN_ISTENME_SEKLI_ID", true, 90, TablesGrids.GetTI_KOD_SATIS_ISTEME_SEKILLookup());
            var colmSATISI_ISTEYEN_CARI_ID = colmnVer("SATISI ISTEYEN CARI ID", "SATISI_ISTEYEN_CARI_ID", true, 91, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSATISI_ISTENEN_CARI_ID = colmnVer("SATISI ISTENEN CARI ID", "SATISI_ISTENEN_CARI_ID", true, 92, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmVAKTINDE_MI = colmnVer("VAKTINDE MI", "VAKTINDE_MI", true, 93, null);
            var colmVAKTINDEN_ONCE_NEDENI = colmnVer("VAKTINDEN ONCE NEDENI", "VAKTINDEN_ONCE_NEDENI", true, 94, null);
            var colmILAN_SEKLI = colmnVer("ILAN SEKLI", "ILAN_SEKLI", true, 95, null);
            var colmILAN_TARIHI = colmnVer("ILAN TARIHI", "ILAN_TARIHI", true, 96, null);
            var colmSATIS_ISTEME_TARIHI = colmnVer("SATIS ISTEME TARIHI", "SATIS_ISTEME_TARIHI", true, 97, null);
            var colmSATIS_TURU_ID = colmnVer("SATIS TURU ID", "SATIS_TURU_ID", true, 98, TablesGrids.GetTI_KOD_SATIS_TURULookup());
            var colmSATIS_TARIHI_1 = colmnVer("SATIS TARIHI 1", "SATIS_TARIHI_1", true, 99, null);
            var colmSATIS_SAATI_1 = colmnVer("SATIS SAATI 1", "SATIS_SAATI_1", true, 100, null);
            var colmSATIS_TARIHI_2 = colmnVer("SATIS TARIHI 2", "SATIS_TARIHI_2", true, 101, null);
            var colmSATIS_SAATI_2 = colmnVer("SATIS SAATI 2", "SATIS_SAATI_2", true, 102, null);
            var colmSATIS_TATILI_VAR_MI = colmnVer("SATIS TATILI VAR MI", "SATIS_TATILI_VAR_MI", true, 103, null);
            var colmSATIS_TATIL_NEDENI = colmnVer("SATIS TATIL NEDENI", "SATIS_TATIL_NEDENI", true, 104, null);
            var colmSATIS_KESINLESME_TARIHI = colmnVer("SATIS KESINLESME TARIHI", "SATIS_KESINLESME_TARIHI", true, 105, null);
            var colmSATIS_MEMURU_ID = colmnVer("SATIS MEMURU ID", "SATIS_MEMURU_ID", true, 106, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSATIS_SORUMLU_PERSONEL_ID = colmnVer("SATIS SORUMLU PERSONEL ID", "SATIS_SORUMLU_PERSONEL_ID", true, 107, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSEHIR_ICI_DISI = colmnVer("SEHIR ICI DISI", "SEHIR_ICI_DISI", true, 108, null);
            var colmTOPLAM_SATIS_DEGERI = colmnVer("TOPLAM SATIS DEGERI", "TOPLAM_SATIS_DEGERI", true, 109, null, colmTOPLAM_SATIS_DEGERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryTOPLAM_SATIS_DEGERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TOPLAM_SATIS_DEGERI", colmTOPLAM_SATIS_DEGERI, "", 1);
            colmTOPLAM_SATIS_DEGERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTOPLAM_SATIS_DEGERI.SummaryItem.FieldName = "TOPLAM_SATIS_DEGERI";
            colmTOPLAM_SATIS_DEGERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTOPLAM_SATIS_DEGERI.SummaryItem.Tag = 1;

            var colmSATIS_TALIMAT_MI = colmnVer("SATIS TALIMAT MI", "SATIS_TALIMAT_MI", true, 111, null);
            var colmSATIS_TALIMAT_ADLI_BIRIM_ADLIYE_ID = colmnVer("SATIS TALIMAT ADLI BIRIM ADLIYE ID", "SATIS_TALIMAT_ADLI_BIRIM_ADLIYE_ID", true, 112, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmSATIS_TALIMAT_ADLI_BIRIM_GOREV_ID = colmnVer("SATIS TALIMAT ADLI BIRIM GOREV ID", "SATIS_TALIMAT_ADLI_BIRIM_GOREV_ID", true, 113, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmSATIS_TALIMAT_ADLI_BIRIM_NO_ID = colmnVer("SATIS TALIMAT ADLI BIRIM NO ID", "SATIS_TALIMAT_ADLI_BIRIM_NO_ID", true, 114, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmSATIS_GERCEKLESME_TARIHI = colmnVer("SATIS GERCEKLESME TARIHI", "SATIS_GERCEKLESME_TARIHI", true, 115, null);
            var colmSATIS_GERCEKLESMEME_NEDENI = colmnVer("SATIS GERCEKLESMEME NEDENI", "SATIS_GERCEKLESMEME_NEDENI", true, 116, null);
            var colmSATIS_MAL_SIRA_NO = colmnVer("SATIS MAL SIRA NO", "SATIS_MAL_SIRA_NO", true, 117, null);
            var colmSATIS_MAL_DEGERINE_ITIRAZ_TARIHI = colmnVer("SATIS MAL DEGERINE ITIRAZ TARIHI", "SATIS_MAL_DEGERINE_ITIRAZ_TARIHI", true, 118, null);
            var colmSATIS_MAL_DEGERINE_ITIRAZ_SONUCU = colmnVer("SATIS MAL DEGERINE ITIRAZ SONUCU", "SATIS_MAL_DEGERINE_ITIRAZ_SONUCU", true, 119, null);
            var colmICRA_SATIS_BEDELI = colmnVer("ICRA SATIS BEDELI", "ICRA_SATIS_BEDELI", true, 121, null, colmICRA_SATIS_BEDELI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryICRA_SATIS_BEDELI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ICRA_SATIS_BEDELI", colmICRA_SATIS_BEDELI, "", 1);
            colmICRA_SATIS_BEDELI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmICRA_SATIS_BEDELI.SummaryItem.FieldName = "ICRA_SATIS_BEDELI";
            colmICRA_SATIS_BEDELI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmICRA_SATIS_BEDELI.SummaryItem.Tag = 1;

            var colmDOSYA_GIREN_BEDEL = colmnVer("DOSYA GIREN BEDEL", "DOSYA_GIREN_BEDEL", true, 123, null, colmDOSYA_GIREN_BEDEL_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDOSYA_GIREN_BEDEL = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DOSYA_GIREN_BEDEL", colmDOSYA_GIREN_BEDEL, "", 1);
            colmDOSYA_GIREN_BEDEL.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDOSYA_GIREN_BEDEL.SummaryItem.FieldName = "DOSYA_GIREN_BEDEL";
            colmDOSYA_GIREN_BEDEL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDOSYA_GIREN_BEDEL.SummaryItem.Tag = 1;

            var colmGEMI_UCAK_ARAC_TIP = colmnVer("GEMI UCAK ARAC TIP", "GEMI_UCAK_ARAC_TIP", true, 124, null);
            var colmADI = colmnVer("ADI", "ADI", true, 125, null);
            var colmCINSI = colmnVer("CINSI", "CINSI", true, 126, null);
            var colmTESCIL_NUMARASI = colmnVer("TESCIL NUMARASI", "TESCIL_NUMARASI", true, 127, null);
            var colmTANIMA_ISARETI = colmnVer("TANIMA ISARETI", "TANIMA_ISARETI", true, 128, null);
            var colmINSA_YILI = colmnVer("INSA YILI", "INSA_YILI", true, 129, null);
            var colmINSA_YERI = colmnVer("INSA YERI", "INSA_YERI", true, 130, null);
            var colmBOYU = colmnVer("BOYU", "BOYU", true, 131, null);
            var colmENI = colmnVer("ENI", "ENI", true, 132, null);
            var colmTONALITOSU = colmnVer("TONALITOSU", "TONALITOSU", true, 133, null);
            var colmBAGLAMA_LIMANI = colmnVer("BAGLAMA LIMANI", "BAGLAMA_LIMANI", true, 134, null);
            var colmTEKNIK_KUTUK_NO = colmnVer("TEKNIK KUTUK NO", "TEKNIK_KUTUK_NO", true, 135, null);
            var colmERISIM_NO = colmnVer("ERISIM NO", "ERISIM_NO", true, 136, null);
            var colmTIPI = colmnVer("TIPI", "TIPI", true, 137, null);
            var colmDERINLIGI = colmnVer("DERINLIGI", "DERINLIGI", true, 138, null);
            var colmKUTUK_BOYU = colmnVer("KUTUK BOYU", "KUTUK_BOYU", true, 139, null);
            var colmARAC_PLAKA = colmnVer("ARAC PLAKA", "ARAC_PLAKA", true, 140, null);
            var colmARAC_MODEL = colmnVer("ARAC MODEL", "ARAC_MODEL", true, 141, null);
            var colmARAC_TIP = colmnVer("ARAC TIP", "ARAC_TIP", true, 142, null);
            var colmARAC_MOTOR_NO = colmnVer("ARAC MOTOR NO", "ARAC_MOTOR_NO", true, 143, null);
            var colmARAC_SASI_NO = colmnVer("ARAC SASI NO", "ARAC_SASI_NO", true, 144, null);
            var colmARAC_RENK = colmnVer("ARAC RENK", "ARAC_RENK", true, 145, null);
            var colmTRAFIK_SUBESI = colmnVer("TRAFIK SUBESI", "TRAFIK_SUBESI", true, 146, null);
            var colmRUHSAT_TARIHI = colmnVer("RUHSAT TARIHI", "RUHSAT_TARIHI", true, 147, null);
            var colmRUHSAT_SICIL_NO = colmnVer("RUHSAT SICIL NO", "RUHSAT_SICIL_NO", true, 148, null);
            var colmTARIHI = colmnVer("TARIHI", "TARIHI", true, 149, null);
            var colmIL_ID = colmnVer("IL ID", "IL_ID", true, 150, TablesGrids.GetTDI_KOD_ILLookup());
            var colmILCE_ID = colmnVer("ILCE ID", "ILCE_ID", true, 151, TablesGrids.GetTDI_KOD_ILCELookup());
            var colmBUCAK = colmnVer("BUCAK", "BUCAK", true, 152, null);
            var colmMAHALLE_ADI = colmnVer("MAHALLE ADI", "MAHALLE_ADI", true, 153, null);
            var colmKOY_ADI = colmnVer("KOY ADI", "KOY_ADI", true, 154, null);
            var colmSOKAK_ADI = colmnVer("SOKAK ADI", "SOKAK_ADI", true, 155, null);
            var colmMEVKI_ADI = colmnVer("MEVKI ADI", "MEVKI_ADI", true, 156, null);
            var colmPAFTA_NO = colmnVer("PAFTA NO", "PAFTA_NO", true, 157, null);
            var colmADA_NO = colmnVer("ADA NO", "ADA_NO", true, 158, null);
            var colmPARSEL_NO = colmnVer("PARSEL NO", "PARSEL_NO", true, 159, null);
            var colmYEVMIYE_NO = colmnVer("YEVMIYE NO", "YEVMIYE_NO", true, 160, null);
            var colmCILT_NO = colmnVer("CILT NO", "CILT_NO", true, 161, null);
            var colmSAHIFE_NO = colmnVer("SAHIFE NO", "SAHIFE_NO", true, 162, null);
            var colmSIRA_NO = colmnVer("SIRA NO", "SIRA_NO", true, 163, null);
            var colmYUZOLCUMU_HEKTAR = colmnVer("YUZOLCUMU HEKTAR", "YUZOLCUMU_HEKTAR", true, 164, null);
            var colmYUZOLCUMU_DEKAR = colmnVer("YUZOLCUMU DEKAR", "YUZOLCUMU_DEKAR", true, 165, null);
            var colmYUZOLCUMU_DM2 = colmnVer("YUZOLCUMU DM2", "YUZOLCUMU_DM2", true, 166, null);
            var colmNITELIGI = colmnVer("NITELIGI", "NITELIGI", true, 167, null);
            var colmARSA_PAYI = colmnVer("ARSA PAYI", "ARSA_PAYI", true, 168, null);
            var colmKAT_NO = colmnVer("KAT NO", "KAT_NO", true, 169, null);
            var colmBAGIMSIZ_BOLUM_NO = colmnVer("BAGIMSIZ BOLUM NO", "BAGIMSIZ_BOLUM_NO", true, 170, null);
            var colmSINIRI = colmnVer("SINIRI", "SINIRI", true, 171, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 172, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 173, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 174, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 175, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 176, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 177, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 178, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 179, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 180, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 181, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 182, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 183, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 184, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 185, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 186, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 187, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_KODU = colmnVer("TARAF KODU", "TARAF_KODU", true, 188, null);
            var colmSORUMLU_AVUKAT_CARI_ID = colmnVer("SORUMLU AVUKAT CARI ID", "SORUMLU_AVUKAT_CARI_ID", true, 189, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSORUMLU_TIP = colmnVer("SORUMLU TIP", "SORUMLU_TIP", true, 190);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmHACIZ_TOPLAM_DEGERI_DOVIZ_ID, colmHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID, colmHACIZLI_MAL_DEGERI_DOVIZ_ID, colmISTIRAK_TUTARI_DOVIZ_ID, colmTOPLAM_SATIS_DEGERI_DOVIZ_ID, colmICRA_SATIS_BEDELI_DOVIZ_ID, colmDOSYA_GIREN_BEDEL_DOVIZ_ID, colmHACIZ_TARIHI, colmHACIZ_SAATI, colmHACIZ_SIRA_NO, colmBAKIYE_HACIZI_MI, colmHACIZ_ISTEYEN_CARI_ID, colmHACIZ_ISTENEN_CARI_ID, colmTALIMAT_MI, colmTALIMAT_ADLI_BIRIM_ADLIYE_ID, colmTALIMAT_ADLI_BIRIM_GOREV_ID, colmTALIMAT_ADLI_BIRIM_NO_ID, colmTALIMAT_BIRIM_NO, colmTALIMAT_ESAS_NO, colmHACIZ_TALEP_TARIHI, colmGECICI_HACIZ_MI, colmHACIZ_KAYNAGI, colmHACIZ_KAYNAGI_IHTIYATI_TEDBIR_ID, colmHACIZ_KAYNAGI_IHTIYATI_HACIZ_ID, colmICRA_TUTANAK_NO, colmBORCLU_HAZIR_MI, colmYUZUC_UYGULANDI_MI, colmSURET_BIRAKILDI_MI, colmCILINGIR_VAR_MI, colmKOLLUK_VAR_MI, colmHACIZ_MEMURU_CARI_ID, colmHACIZ_SORUMLU_PERSONEL_ID, colmSEHIR_DISI_MI, colmHACIZ_ACIKLAMA, colmKAYIT_TARIHI, colmKLASOR_KODU, colmSUBE_KODU, colmPEDAGOG_CARI_ID, colmHACIZE_KABIL_MAL_YOK, colmHACIZ_ADRESI, colmHACIZ_TOPLAM_DEGERI, colmMUHAFAZALI_KAYIT_VAR_MI, colmHACIZ_EDILECEK_MAL_VAR, colmMAL_SIRA_NO, colmHACIZLI_MAL_TUR_ID, colmHACIZLI_MAL_KATEGORI_ID, colmHACIZLI_MAL_CINS_ID, colmHACIZLI_MAL_NEVI, colmHACIZLI_MAL_MARKASI, colmHACIZLI_MAL_OZELLIKLERI, colmHACIZLI_MAL_ACIKLAMASI, colmHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI, colmUCUNCU_SAHISTA_MI, colmUCUNCU_SAHIS_CARI_ID, colmGAYRIMENKUL_BILGI_ID, colmHACIZ_ISLEM_DURUM_ID, colmISTIHKAK_IDDIASI_VAR_MI, colmHACIZLI_MAL_ADEDI, colmHACIZLI_MAL_SATIR_TOPLAM_MIKTAR, colmHACIZLI_MAL_ADET_BIRIM_ID, colmBIRIM_KOD, colmHACIZLI_MAL_DEGERI, colmPARAYA_CEVRILDI_MI, colmYEDIEMIN_CARI_ID, colmALACAKLI_RIZASI_VAR_MI, colmARAC_PLAKA_NO, colmISTIRAK_HACIZ_TARIHI, colmISTIRAK_HACIZ_SAATI, colmISTIRAK_MIKTAR, colmISTIRAK_MIKTAR_BIRIM_ID, colmISTIRAK_MIKTAR_BIRIM_KOD, colmISTIRAK_TUTARI, colmISTIRAK_ISTEYEN_CARI_ID, colmISTIRAK_ISTENEN_CARI_ID, colmISTIRAK_TALIMAT_ADLI_BIRIM_ADLIYE_ID, colmISTIRAK_TALIMAT_ADLI_BIRIM_GOREV_ID, colmISTIRAK_TALIMAT_ADLI_BIRIM_NO_ID, colmISTIRAK_TALIMAT_ICRA_ESAS_NO, colmHACIZ_ISTIRAK_TALEP_TARIHI, colmISTIHKAK_IDDIA_TARIHI, colmISTIHKAK_IDDIA_EDEN_ID, colmISTIHKAK_IDDIASINA_ITIRAZ_TARIHI, colmKIYMET_TAKDIRI_TARIHI, colmKIYMET_TAKDIRI_ISTEME_TARIHI, colmKIYMET_TAKDIRI_YAPAN1_ID, colmKIYMET_TAKDIRI_YAPAN2_ID, colmRAPOR_TARIHI1, colmRAPOR_TARIHI2, colmDEGERIN_KESINLESME_TARIHI, colmITIRAZ_VARMI, colmITIRAZ_SONUCU, colmSATIS_SIRA_NO, colmSATISIN_ISTENME_SEKLI_ID, colmSATISI_ISTEYEN_CARI_ID, colmSATISI_ISTENEN_CARI_ID, colmVAKTINDE_MI, colmVAKTINDEN_ONCE_NEDENI, colmILAN_SEKLI, colmILAN_TARIHI, colmSATIS_ISTEME_TARIHI, colmSATIS_TURU_ID, colmSATIS_TARIHI_1, colmSATIS_SAATI_1, colmSATIS_TARIHI_2, colmSATIS_SAATI_2, colmSATIS_TATILI_VAR_MI, colmSATIS_TATIL_NEDENI, colmSATIS_KESINLESME_TARIHI, colmSATIS_MEMURU_ID, colmSATIS_SORUMLU_PERSONEL_ID, colmSEHIR_ICI_DISI, colmTOPLAM_SATIS_DEGERI, colmSATIS_TALIMAT_MI, colmSATIS_TALIMAT_ADLI_BIRIM_ADLIYE_ID, colmSATIS_TALIMAT_ADLI_BIRIM_GOREV_ID, colmSATIS_TALIMAT_ADLI_BIRIM_NO_ID, colmSATIS_GERCEKLESME_TARIHI, colmSATIS_GERCEKLESMEME_NEDENI, colmSATIS_MAL_SIRA_NO, colmSATIS_MAL_DEGERINE_ITIRAZ_TARIHI, colmSATIS_MAL_DEGERINE_ITIRAZ_SONUCU, colmICRA_SATIS_BEDELI, colmDOSYA_GIREN_BEDEL, colmGEMI_UCAK_ARAC_TIP, colmADI, colmCINSI, colmTESCIL_NUMARASI, colmTANIMA_ISARETI, colmINSA_YILI, colmINSA_YERI, colmBOYU, colmENI, colmTONALITOSU, colmBAGLAMA_LIMANI, colmTEKNIK_KUTUK_NO, colmERISIM_NO, colmTIPI, colmDERINLIGI, colmKUTUK_BOYU, colmARAC_PLAKA, colmARAC_MODEL, colmARAC_TIP, colmARAC_MOTOR_NO, colmARAC_SASI_NO, colmARAC_RENK, colmTRAFIK_SUBESI, colmRUHSAT_TARIHI, colmRUHSAT_SICIL_NO, colmTARIHI, colmIL_ID, colmILCE_ID, colmBUCAK, colmMAHALLE_ADI, colmKOY_ADI, colmSOKAK_ADI, colmMEVKI_ADI, colmPAFTA_NO, colmADA_NO, colmPARSEL_NO, colmYEVMIYE_NO, colmCILT_NO, colmSAHIFE_NO, colmSIRA_NO, colmYUZOLCUMU_HEKTAR, colmYUZOLCUMU_DEKAR, colmYUZOLCUMU_DM2, colmNITELIGI, colmARSA_PAYI, colmKAT_NO, colmBAGIMSIZ_BOLUM_NO, colmSINIRI, colmFOY_NO, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T, colmREFERANS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP, colmTARAF_CARI_ID, colmTARAF_KODU, colmSORUMLU_AVUKAT_CARI_ID, colmSORUMLU_TIP });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            grid.GroupSummary.AddRange(new[] { summaryHACIZ_TOPLAM_DEGERI, summaryHACIZ_TOPLAM_DEGERI_DOVIZ_ID, summaryHACIZLI_MAL_SATIR_TOPLAM_MIKTAR, summaryHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID, summaryHACIZLI_MAL_DEGERI_DOVIZ_ID, summaryHACIZLI_MAL_DEGERI, summaryISTIRAK_TUTARI_DOVIZ_ID, summaryISTIRAK_TUTARI, summaryTOPLAM_SATIS_DEGERI, summaryTOPLAM_SATIS_DEGERI_DOVIZ_ID, summaryICRA_SATIS_BEDELI_DOVIZ_ID, summaryICRA_SATIS_BEDELI, summaryDOSYA_GIREN_BEDEL_DOVIZ_ID, summaryDOSYA_GIREN_BEDEL });
            gridRaporCntrol.DataSource = db.R_MAL_SATIS_SURECI_ICRA_TARAF_SORUMLUs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void MASRAF_AVANS_TARAFLI()
        {
            var colmBIRIM_FIYAT_DOVIZ_ID = colmnVer("BIRIM FIYAT DOVIZ ID", "BIRIM_FIYAT_DOVIZ_ID", true, 14, lupDoviz);
            var summaryBIRIM_FIYAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT_DOVIZ_ID", colmBIRIM_FIYAT_DOVIZ_ID, "", 2);
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 1, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmAVANS_REFERANS_NO = colmnVer("AVANS REFERANS NO", "AVANS_REFERANS_NO", true, 2, null);
            var colmMASRAF_AVANS_TIP = colmnVer("MASRAF AVANS TIP", "MASRAF_AVANS_TIP", true, 3, null);
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 4, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 5, null);
            var colmBORCLU_CARI_ID = colmnVer("BORCLU CARI ID", "BORCLU_CARI_ID", true, 6, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARIH = colmnVer("TARIH", "TARIH", true, 7, null);
            var colmKULLANICI_BELGE_NO = colmnVer("KULLANICI BELGE NO", "KULLANICI_BELGE_NO", true, 8, null);
            var colmBORC_ALACAK_ID = colmnVer("BORC ALACAK ID", "BORC_ALACAK_ID", true, 9, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmODEME_TIP_ID = colmnVer("ODEME TIP ID", "ODEME_TIP_ID", true, 10, TablesGrids.GetTDI_KOD_ODEME_TIPLookup());
            var colmHAREKET_ANA_KATEGORI_ID = colmnVer("HAREKET ANA KATEGORI ID", "HAREKET_ANA_KATEGORI_ID", true, 11, TablesGrids.GetTDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORILookup());
            var colmHAREKET_ALT_KATEGORI_ID = colmnVer("HAREKET ALT KATEGORI ID", "HAREKET_ALT_KATEGORI_ID", true, 12, TablesGrids.GetTDI_KOD_MUHASEBE_HAREKET_ALT_KATEGORILookup());
            var colmADET = colmnVer("ADET", "ADET", true, 13, null);
            var summaryADET = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ADET", colmADET, "", 1);
            colmADET.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmADET.SummaryItem.FieldName = "ADET";
            colmADET.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmADET.SummaryItem.Tag = 1;

            var colmBIRIM_FIYAT = colmnVer("BIRIM FIYAT", "BIRIM_FIYAT", true, 15, null, colmBIRIM_FIYAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIM_FIYAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT", colmBIRIM_FIYAT, "", 1);
            colmBIRIM_FIYAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIM_FIYAT.SummaryItem.FieldName = "BIRIM_FIYAT";
            colmBIRIM_FIYAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT.SummaryItem.Tag = 1;

            var colmKDV_DAHIL = colmnVer("KDV DAHIL", "KDV_DAHIL", true, 16, null);
            var colmKDV_ORAN = colmnVer("KDV ORAN", "KDV_ORAN", true, 17, null);
            var colmKDV_TUTAR = colmnVer("KDV TUTAR", "KDV_TUTAR", true, 18, null);
            var summaryKDV_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "KDV_TUTAR", colmKDV_TUTAR, "", 1);
            colmKDV_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmKDV_TUTAR.SummaryItem.FieldName = "KDV_TUTAR";
            colmKDV_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmKDV_TUTAR.SummaryItem.Tag = 1;

            var colmSTOPAJ_SSDF_DAHIL = colmnVer("STOPAJ SSDF DAHIL", "STOPAJ_SSDF_DAHIL", true, 19, null);
            var colmSTOPAJ_ORAN = colmnVer("STOPAJ ORAN", "STOPAJ_ORAN", true, 20, null);
            var colmSSDF_ORAN = colmnVer("SSDF ORAN", "SSDF_ORAN", true, 21, null);
            var colmSTOPAJ_SSDF_TUTAR = colmnVer("STOPAJ SSDF TUTAR", "STOPAJ_SSDF_TUTAR", true, 22, null);
            var summarySTOPAJ_SSDF_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "STOPAJ_SSDF_TUTAR", colmSTOPAJ_SSDF_TUTAR, "", 1);
            colmSTOPAJ_SSDF_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSTOPAJ_SSDF_TUTAR.SummaryItem.FieldName = "STOPAJ_SSDF_TUTAR";
            colmSTOPAJ_SSDF_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSTOPAJ_SSDF_TUTAR.SummaryItem.Tag = 1;

            var colmTOPLAM_TUTAR = colmnVer("TOPLAM TUTAR", "TOPLAM_TUTAR", true, 23, null);
            var summaryTOPLAM_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TOPLAM_TUTAR", colmTOPLAM_TUTAR, "", 1);
            colmTOPLAM_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmTOPLAM_TUTAR.SummaryItem.FieldName = "TOPLAM_TUTAR";
            colmTOPLAM_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmTOPLAM_TUTAR.SummaryItem.Tag = 1;

            var colmGENEL_TOPLAM = colmnVer("GENEL TOPLAM", "GENEL_TOPLAM", true, 24, null);
            var summaryGENEL_TOPLAM = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "GENEL_TOPLAM", colmGENEL_TOPLAM, "", 1);
            colmGENEL_TOPLAM.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmGENEL_TOPLAM.SummaryItem.FieldName = "GENEL_TOPLAM";
            colmGENEL_TOPLAM.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmGENEL_TOPLAM.SummaryItem.Tag = 1;

            var colmTUM_MUVEKKILLERE_PAYLASTIR = colmnVer("TUM MUVEKKILLERE PAYLASTIR", "TUM_MUVEKKILLERE_PAYLASTIR", true, 25, null);
            var colmMUVEKKIL_CARI_ID = colmnVer("MUVEKKIL CARI ID", "MUVEKKIL_CARI_ID", true, 26, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmINCELENDI = colmnVer("INCELENDI", "INCELENDI", true, 27, null);
            var colmONAY_TARIHI = colmnVer("ONAY TARIHI", "ONAY_TARIHI", true, 28, null);
            var colmONAY_NO = colmnVer("ONAY NO", "ONAY_NO", true, 29, null);
            var colmONAY_DURUM = colmnVer("ONAY DURUM", "ONAY_DURUM", true, 30, null);
            var colmDETAY_ACIKLAMA = colmnVer("DETAY ACIKLAMA", "DETAY_ACIKLAMA", true, 31, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 32, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 33, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 34, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 35, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 36, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 37, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 38, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 39, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 40, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 41, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 42, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 43, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 44, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 46, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 47, null);
            var colmTARAF_KODU = colmnVer("TARAF KODU", "TARAF_KODU", true, 48, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 49, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 50, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmTipi = colmnVer("Tipi", "Tipi", true, 51, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmBIRIM_FIYAT_DOVIZ_ID, colmCARI_ID, colmAVANS_REFERANS_NO, colmMASRAF_AVANS_TIP, colmACIKLAMA, colmKAYIT_TARIHI, colmBORCLU_CARI_ID, colmTARIH, colmKULLANICI_BELGE_NO, colmBORC_ALACAK_ID, colmODEME_TIP_ID, colmHAREKET_ANA_KATEGORI_ID, colmHAREKET_ALT_KATEGORI_ID, colmADET, colmBIRIM_FIYAT, colmKDV_DAHIL, colmKDV_ORAN, colmKDV_TUTAR, colmSTOPAJ_SSDF_DAHIL, colmSTOPAJ_ORAN, colmSSDF_ORAN, colmSTOPAJ_SSDF_TUTAR, colmTOPLAM_TUTAR, colmGENEL_TOPLAM, colmTUM_MUVEKKILLERE_PAYLASTIR, colmMUVEKKIL_CARI_ID, colmINCELENDI, colmONAY_TARIHI, colmONAY_NO, colmONAY_DURUM, colmDETAY_ACIKLAMA, colmFOY_NO, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T, colmREFERANS_NO2, colmREFERANS_NO3, colmREFERANS_NO, colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP, colmTARAF_KODU, colmTARAF_CARI_ID, colmTARAF_SIFAT_ID, colmTipi });

            grid.GroupSummary.AddRange(new[] { summaryADET, summaryBIRIM_FIYAT_DOVIZ_ID, summaryBIRIM_FIYAT, summaryKDV_TUTAR, summarySTOPAJ_SSDF_TUTAR, summaryTOPLAM_TUTAR, summaryGENEL_TOPLAM });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.MASRAF_AVANS_BIRLESIK_TARAFs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void MUHASEBE_TARAFLI()
        {
            var colmBIRIM_FIYAT_DOVIZ_ID = colmnVer("BIRIM FIYAT DOVIZ ID", "BIRIM_FIYAT_DOVIZ_ID", true, 8, lupDoviz);
            var summaryBIRIM_FIYAT_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT_DOVIZ_ID", colmBIRIM_FIYAT_DOVIZ_ID, "", 2);
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 1, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmHESAP_REFERANS = colmnVer("HESAP REFERANS", "HESAP_REFERANS", true, 2, null);
            var colmBORC_ALACAK_ID = colmnVer("BORC ALACAK ID", "BORC_ALACAK_ID", true, 3, TablesGrids.GetTDI_KOD_MUHASEBE_BORC_ALACAKLookup());
            var colmODEME_TIP_ID = colmnVer("ODEME TIP ID", "ODEME_TIP_ID", true, 4, TablesGrids.GetTDI_KOD_ODEME_TIPLookup());
            var colmHAREKET_ANA_KATEGORI_ID = colmnVer("HAREKET ANA KATEGORI ID", "HAREKET_ANA_KATEGORI_ID", true, 5, TablesGrids.GetTDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORILookup());
            var colmKULLANICI_BELGE_NO = colmnVer("KULLANICI BELGE NO", "KULLANICI_BELGE_NO", true, 6, null);
            var colmADET = colmnVer("ADET", "ADET", true, 7, null);
            var colmBIRIM_FIYAT = colmnVer("BIRIM FIYAT", "BIRIM_FIYAT", true, 9, null, colmBIRIM_FIYAT_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryBIRIM_FIYAT = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BIRIM_FIYAT", colmBIRIM_FIYAT, "", 1);
            colmBIRIM_FIYAT.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmBIRIM_FIYAT.SummaryItem.FieldName = "BIRIM_FIYAT";
            colmBIRIM_FIYAT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmBIRIM_FIYAT.SummaryItem.Tag = 1;

            var colmGENEL_TOPLAM = colmnVer("GENEL TOPLAM", "GENEL_TOPLAM", true, 10, null);
            var colmDETAY_ACIKLAMA = colmnVer("DETAY ACIKLAMA", "DETAY_ACIKLAMA", true, 11, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 12, null);
            var colmONAY_TARIHI = colmnVer("ONAY TARIHI", "ONAY_TARIHI", true, 13, null);
            var colmONAY_DURUM = colmnVer("ONAY DURUM", "ONAY_DURUM", true, 14, null);
            var colmDOSYA_MUH_AKTARILDI = colmnVer("DOSYA MUH AKTARILDI", "DOSYA_MUH_AKTARILDI", true, 15, null);
            var colmTARIH = colmnVer("TARIH", "TARIH", true, 16, null);
            var colmINCELENDI = colmnVer("INCELENDI", "INCELENDI", true, 17, null);
            var colmONAY_NO = colmnVer("ONAY NO", "ONAY_NO", true, 18, null);
            var colmMASRAF_AVANS_ID = colmnVer("MASRAF AVANS ID", "MASRAF_AVANS_ID", true, 19, TablesGrids.GetAV001_TDI_BIL_MASRAF_AVANSLookup());
            var colmFOY_ID = colmnVer("FOY ID", "FOY_ID", true, 20, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 21, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 22, null);
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 23, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 24, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 25, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 26, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 27, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 28, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 29, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 30, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 31, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 32, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 33, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 34, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 35, null);
            var colmTipi = colmnVer("Tipi", "Tipi", true, 36, null);
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 37, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_KODU = colmnVer("TARAF KODU", "TARAF_KODU", true, 38, null);
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 39, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmBIRIM_FIYAT_DOVIZ_ID, colmCARI_ID, colmHESAP_REFERANS, colmBORC_ALACAK_ID, colmODEME_TIP_ID, colmHAREKET_ANA_KATEGORI_ID, colmKULLANICI_BELGE_NO, colmADET, colmBIRIM_FIYAT, colmGENEL_TOPLAM, colmDETAY_ACIKLAMA, colmKAYIT_TARIHI, colmONAY_TARIHI, colmONAY_DURUM, colmDOSYA_MUH_AKTARILDI, colmTARIH, colmINCELENDI, colmONAY_NO, colmMASRAF_AVANS_ID, colmFOY_ID, colmADLI_BIRIM_ADLIYE_ID, colmFOY_NO, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T, colmREFERANS_NO2, colmREFERANS_NO3, colmREFERANS_NO, colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP, colmTipi, colmTARAF_CARI_ID, colmTARAF_KODU, colmTARAF_SIFAT_ID });
            grid.GroupSummary.AddRange(new[] { summaryBIRIM_FIYAT_DOVIZ_ID, summaryBIRIM_FIYAT });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.MASRAF_AVANS_BIRLESIK_TARAFs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void SORUSTURMA_GENEL_HESAPSIZ()
        {
            var colmHAZIRLIK_NO = colmnVer("HAZIRLIK NO", "HAZIRLIK_NO", true, 1, null);
            var colmSIKAYET_TARIHI = colmnVer("SIKAYET TARIHI", "SIKAYET_TARIHI", true, 2, null);
            var colmSIKAYET_KONU_ID = colmnVer("SIKAYET KONU ID", "SIKAYET_KONU_ID", true, 3, TablesGrids.GetTD_KOD_DAVA_TALEPLookup());
            var colmHAZIRLIK_TARIH = colmnVer("HAZIRLIK TARIH", "HAZIRLIK_TARIH", true, 4, null);
            var colmHAZIRLIK_ESAS_NO = colmnVer("HAZIRLIK ESAS NO", "HAZIRLIK_ESAS_NO", true, 5, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 6, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 7, null);
            var colmHAZIRLIK_DURUM_ID = colmnVer("HAZIRLIK DURUM ID", "HAZIRLIK_DURUM_ID", true, 8, TablesGrids.GetTD_KOD_HAZIRLIK_DURUMLookup());
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 9, null);
            var colmOZEL_KOD_1_ID = colmnVer("OZEL KOD 1 ID", "OZEL_KOD_1_ID", true, 10, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_3_ID = colmnVer("OZEL KOD 3 ID", "OZEL_KOD_3_ID", true, 11, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_4_ID = colmnVer("OZEL KOD 4 ID", "OZEL_KOD_4_ID", true, 12, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_2_ID = colmnVer("OZEL KOD 2 ID", "OZEL_KOD_2_ID", true, 13, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 14, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 15, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 16, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 17, null);

            GridView grid = (GridView)gridRaporCntrol.MainView;

            grid.Columns.AddRange(new[] { colmHAZIRLIK_NO, colmSIKAYET_TARIHI, colmSIKAYET_KONU_ID, colmHAZIRLIK_TARIH, colmHAZIRLIK_ESAS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmHAZIRLIK_DURUM_ID, colmACIKLAMA, colmOZEL_KOD_1_ID, colmOZEL_KOD_3_ID, colmOZEL_KOD_4_ID, colmOZEL_KOD_2_ID, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmREFERANS_NO });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.SORUSTURMA_GENEL_HESAPSIZs;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void SORUSTURMA_GENEL_HESAPSIZ_SORUMLULU()
        {
            var colmHAZIRLIK_NO = colmnVer("HAZIRLIK NO", "HAZIRLIK_NO", true, 1, null);
            var colmSIKAYET_TARIHI = colmnVer("SIKAYET TARIHI", "SIKAYET_TARIHI", true, 2, null);
            var colmSIKAYET_KONU_ID = colmnVer("SIKAYET KONU ID", "SIKAYET_KONU_ID", true, 3, TablesGrids.GetTD_KOD_DAVA_TALEPLookup());
            var colmHAZIRLIK_TARIH = colmnVer("HAZIRLIK TARIH", "HAZIRLIK_TARIH", true, 4, null);
            var colmHAZIRLIK_ESAS_NO = colmnVer("HAZIRLIK ESAS NO", "HAZIRLIK_ESAS_NO", true, 5, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 6, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 7, null);
            var colmHAZIRLIK_DURUM_ID = colmnVer("HAZIRLIK DURUM ID", "HAZIRLIK_DURUM_ID", true, 8, TablesGrids.GetTD_KOD_HAZIRLIK_DURUMLookup());
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 9, null);
            var colmOZEL_KOD_1_ID = colmnVer("OZEL KOD 1 ID", "OZEL_KOD_1_ID", true, 10, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_3_ID = colmnVer("OZEL KOD 3 ID", "OZEL_KOD_3_ID", true, 11, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_4_ID = colmnVer("OZEL KOD 4 ID", "OZEL_KOD_4_ID", true, 12, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_2_ID = colmnVer("OZEL KOD 2 ID", "OZEL_KOD_2_ID", true, 13, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 14, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 15, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 16, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 17, null);
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 18, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSORUMLU_TIP = colmnVer("SORUMLU TIP", "SORUMLU_TIP", true, 19, null);

            GridView grid = (GridView)gridRaporCntrol.MainView;

            grid.Columns.AddRange(new[] { colmHAZIRLIK_NO, colmSIKAYET_TARIHI, colmSIKAYET_KONU_ID, colmHAZIRLIK_TARIH, colmHAZIRLIK_ESAS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmHAZIRLIK_DURUM_ID, colmACIKLAMA, colmOZEL_KOD_1_ID, colmOZEL_KOD_3_ID, colmOZEL_KOD_4_ID, colmOZEL_KOD_2_ID, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmREFERANS_NO, colmCARI_ID, colmSORUMLU_TIP });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.R_SORUSTURMA_GENEL_HESAPSIZ_SORUMLULUs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void SORUSTURMA_GENEL_HESAPSIZ_TARAFLI()
        {
            var colmTARAF_KODU = colmnVer("TARAF KODU", "TARAF_KODU", true, 1, null);
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 2, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 3, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmHAZIRLIK_NO = colmnVer("HAZIRLIK NO", "HAZIRLIK_NO", true, 4, null);
            var colmSIKAYET_TARIHI = colmnVer("SIKAYET TARIHI", "SIKAYET_TARIHI", true, 5, null);
            var colmSIKAYET_KONU_ID = colmnVer("SIKAYET KONU ID", "SIKAYET_KONU_ID", true, 6, TablesGrids.GetTD_KOD_DAVA_TALEPLookup());
            var colmHAZIRLIK_TARIH = colmnVer("HAZIRLIK TARIH", "HAZIRLIK_TARIH", true, 7, null);
            var colmHAZIRLIK_ESAS_NO = colmnVer("HAZIRLIK ESAS NO", "HAZIRLIK_ESAS_NO", true, 8, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 9, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 10, null);
            var colmHAZIRLIK_DURUM_ID = colmnVer("HAZIRLIK DURUM ID", "HAZIRLIK_DURUM_ID", true, 11, TablesGrids.GetTD_KOD_HAZIRLIK_DURUMLookup());
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 12, null);
            var colmOZEL_KOD_1_ID = colmnVer("OZEL KOD 1 ID", "OZEL_KOD_1_ID", true, 13, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_3_ID = colmnVer("OZEL KOD 3 ID", "OZEL_KOD_3_ID", true, 14, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_4_ID = colmnVer("OZEL KOD 4 ID", "OZEL_KOD_4_ID", true, 15, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmOZEL_KOD_2_ID = colmnVer("OZEL KOD 2 ID", "OZEL_KOD_2_ID", true, 16, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 17, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 18, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 19, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 20, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmTARAF_KODU, colmTARAF_SIFAT_ID, colmCARI_ID, colmHAZIRLIK_NO, colmSIKAYET_TARIHI, colmSIKAYET_KONU_ID, colmHAZIRLIK_TARIH, colmHAZIRLIK_ESAS_NO, colmREFERANS_NO2, colmREFERANS_NO3, colmHAZIRLIK_DURUM_ID, colmACIKLAMA, colmOZEL_KOD_1_ID, colmOZEL_KOD_3_ID, colmOZEL_KOD_4_ID, colmOZEL_KOD_2_ID, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmREFERANS_NO });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.R_SORUSTURMA_GENEL_HESAPSIZ_SORUMLULUs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void TEBLIGAT_MUHATAP()
        {
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            var colmGELEN_BELGE_MI = colmnVer("GELEN BELGE MI", "GELEN_BELGE_MI", true, 1, null);
            var colmRESMI_MI = colmnVer("RESMI MI", "RESMI_MI", true, 2, null);
            var colmANA_TUR_ID = colmnVer("ANA TUR ID", "ANA_TUR_ID", true, 3, TablesGrids.GetTDI_KOD_TEBLIGAT_ANA_TURLookup());
            var colmALT_TUR_ID = colmnVer("ALT TUR ID", "ALT_TUR_ID", true, 4, TablesGrids.GetTDI_KOD_TEBLIGAT_ALT_TURLookup());
            var colmILK_TEBLIGAT_YAPAN_ID = colmnVer("ILK TEBLIGAT YAPAN ID", "ILK_TEBLIGAT_YAPAN_ID", true, 5, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmHAZIRLAYAN = colmnVer("HAZIRLAYAN", "HAZIRLAYAN", true, 6, null);
            var colmHAZIRLAMA_TARIH = colmnVer("HAZIRLAMA TARIH", "HAZIRLAMA_TARIH", true, 7, null);
            var colmPOSTALANMA_TARIH = colmnVer("POSTALANMA TARIH", "POSTALANMA_TARIH", true, 8, null);
            var colmICRA_ILK_TEBLIGAT_MI = colmnVer("ICRA ILK TEBLIGAT MI", "ICRA_ILK_TEBLIGAT_MI", true, 9, null);
            var colmDAVA_ILK_TEBLIGAT_MI = colmnVer("DAVA ILK TEBLIGAT MI", "DAVA_ILK_TEBLIGAT_MI", true, 10, null);
            var colmKONU_ID = colmnVer("KONU ID", "KONU_ID", true, 11, TablesGrids.GetTDI_KOD_TEBLIGAT_KONULookup());
            var colmBELGE_OZEL_KOD_ID = colmnVer("BELGE OZEL KOD ID", "BELGE_OZEL_KOD_ID", true, 12, TablesGrids.GetAV001_TDI_KOD_BELGE_OZEL_KODLookup());
            var colmOZEL_FOY_KOD_ID = colmnVer("OZEL FOY KOD ID", "OZEL_FOY_KOD_ID", true, 13, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmMUHATAP_CARI_ID = colmnVer("MUHATAP CARI ID", "MUHATAP_CARI_ID", true, 14, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmMUHATAP_TARAF_KOD = colmnVer("MUHATAP TARAF KOD", "MUHATAP_TARAF_KOD", true, 15, null);
            var colmALAN_CARI_ID = colmnVer("ALAN CARI ID", "ALAN_CARI_ID", true, 16, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmALAN_EHIL_MI = colmnVer("ALAN EHIL MI", "ALAN_EHIL_MI", true, 17, null);
            var colmTEBLIGAT_ADRESI = colmnVer("TEBLIGAT ADRESI", "TEBLIGAT_ADRESI", true, 18, null);
            var colmALAN_BAGLANTI_ID = colmnVer("ALAN BAGLANTI ID", "ALAN_BAGLANTI_ID", true, 19, TablesGrids.GetTDI_KOD_TEBLIGAT_ALAN_BAGLANTILookup());
            var colmALIM_SEKIL_ID = colmnVer("ALIM SEKIL ID", "ALIM_SEKIL_ID", true, 20, TablesGrids.GetTDI_KOD_TEBLIGAT_ALIM_SEKILLookup());
            var colmTEBLIG_TARIH = colmnVer("TEBLIG TARIH", "TEBLIG_TARIH", true, 21, null);
            var colmTEBLIG_SAAT = colmnVer("TEBLIG SAAT", "TEBLIG_SAAT", true, 22, null);
            var colmALINMAMA_NEDEN_ID = colmnVer("ALINMAMA NEDEN ID", "ALINMAMA_NEDEN_ID", true, 23, TablesGrids.GetTDI_KOD_TEBLIGAT_ALINMAMA_NEDENLookup());
            var colmTESLIM_YER_ID = colmnVer("TESLIM YER ID", "TESLIM_YER_ID", true, 24, TablesGrids.GetTDI_KOD_TEBLIGAT_TESLIM_YERLookup());
            var colmGECERLILIK_TARIH = colmnVer("GECERLILIK TARIH", "GECERLILIK_TARIH", true, 25, null);
            var colmPOSTALANDI_MI = colmnVer("POSTALANDI MI", "POSTALANDI_MI", true, 26, null);
            var colmLISTE_NO = colmnVer("LISTE NO", "LISTE_NO", true, 27, null);
            var colmPOSTAHANE = colmnVer("POSTAHANE", "POSTAHANE", true, 28, null);
            var colmTEBLIGAT_SEKLI_ID = colmnVer("TEBLIGAT SEKLI ID", "TEBLIGAT_SEKLI_ID", true, 29, TablesGrids.GetTDI_KOD_TEBLIGAT_SEKILLookup());
            var colmBILA_TEBLIG_MI = colmnVer("BILA TEBLIG MI", "BILA_TEBLIG_MI", true, 30, null);
            var colmZABITA_ARASTIRMASI_ISTENDI_MI = colmnVer("ZABITA ARASTIRMASI ISTENDI MI", "ZABITA_ARASTIRMASI_ISTENDI_MI", true, 31, null);
            var colmZABITA_ARASTIRMASI_OLUMSUZ_MU = colmnVer("ZABITA ARASTIRMASI OLUMSUZ MU", "ZABITA_ARASTIRMASI_OLUMSUZ_MU", true, 32, null);
            var colmPTT_BARKOD_NO = colmnVer("PTT BARKOD NO", "PTT_BARKOD_NO", true, 33, null);
            var colmEVRAK_TARIHI = colmnVer("EVRAK TARIHI", "EVRAK_TARIHI", true, 34, null);
            var colmEVRAK_NO = colmnVer("EVRAK NO", "EVRAK_NO", true, 35, null);
            var colmBILA_TARIHI = colmnVer("BILA TARIHI", "BILA_TARIHI", true, 36, null);
            var colmZABITA_ARASTIRMA_TARIHI = colmnVer("ZABITA ARASTIRMA TARIHI", "ZABITA_ARASTIRMA_TARIHI", true, 37, null);
            var colmOLUMSUZ_SONUC_TARIHI = colmnVer("OLUMSUZ SONUC TARIHI", "OLUMSUZ_SONUC_TARIHI", true, 38, null);
            var colmYAPAN_CARI_ID = colmnVer("YAPAN CARI ID", "YAPAN_CARI_ID", true, 39, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_KOD = colmnVer("TARAF KOD", "TARAF_KOD", true, 40, null);
            var colmFOY_NO = colmnVer("FOY NO", "FOY_NO", true, 41, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 42, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 43, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 44, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 45, null);
            var colmTAKIP_T = colmnVer("TAKIP T", "TAKIP_T", true, 46, null);
            var colmREFERANS_NO2 = colmnVer("REFERANS NO2", "REFERANS_NO2", true, 47, null);
            var colmREFERANS_NO3 = colmnVer("REFERANS NO3", "REFERANS_NO3", true, 48, null);
            var colmREFERANS_NO = colmnVer("REFERANS NO", "REFERANS_NO", true, 49, null);
            var colmOZEL_KOD1 = colmnVer("OZEL KOD1", "OZEL_KOD1", true, 50, null);
            var colmOZEL_KOD2 = colmnVer("OZEL KOD2", "OZEL_KOD2", true, 51, null);
            var colmOZEL_KOD3 = colmnVer("OZEL KOD3", "OZEL_KOD3", true, 52, null);
            var colmOZEL_KOD4 = colmnVer("OZEL KOD4", "OZEL_KOD4", true, 53, null);
            var colmASAMA_ID = colmnVer("ASAMA ID", "ASAMA_ID", true, 54, TablesGrids.GetTDIE_KOD_ASAMALookup());
            var colmTALEP = colmnVer("TALEP", "TALEP", true, 55, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmGELEN_BELGE_MI, colmRESMI_MI, colmANA_TUR_ID, colmALT_TUR_ID, colmILK_TEBLIGAT_YAPAN_ID, colmHAZIRLAYAN, colmHAZIRLAMA_TARIH, colmPOSTALANMA_TARIH, colmICRA_ILK_TEBLIGAT_MI, colmDAVA_ILK_TEBLIGAT_MI, colmKONU_ID, colmBELGE_OZEL_KOD_ID, colmOZEL_FOY_KOD_ID, colmMUHATAP_CARI_ID, colmMUHATAP_TARAF_KOD, colmALAN_CARI_ID, colmALAN_EHIL_MI, colmTEBLIGAT_ADRESI, colmALAN_BAGLANTI_ID, colmALIM_SEKIL_ID, colmTEBLIG_TARIH, colmTEBLIG_SAAT, colmALINMAMA_NEDEN_ID, colmTESLIM_YER_ID, colmGECERLILIK_TARIH, colmPOSTALANDI_MI, colmLISTE_NO, colmPOSTAHANE, colmTEBLIGAT_SEKLI_ID, colmBILA_TEBLIG_MI, colmZABITA_ARASTIRMASI_ISTENDI_MI, colmZABITA_ARASTIRMASI_OLUMSUZ_MU, colmPTT_BARKOD_NO, colmEVRAK_TARIHI, colmEVRAK_NO, colmBILA_TARIHI, colmZABITA_ARASTIRMA_TARIHI, colmOLUMSUZ_SONUC_TARIHI, colmYAPAN_CARI_ID, colmTARAF_KOD, colmFOY_NO, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmTAKIP_T, colmREFERANS_NO2, colmREFERANS_NO3, colmREFERANS_NO, colmOZEL_KOD1, colmOZEL_KOD2, colmOZEL_KOD3, colmOZEL_KOD4, colmASAMA_ID, colmTALEP });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            gridRaporCntrol.DataSource = db.TEBLIGAT_MUHATAP_BIRLESIKs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void TEMSIL_TARAFLI()
        {
            var colmTEMSIL_SEKIL_ID = colmnVer("TEMSIL SEKIL ID", "TEMSIL_SEKIL_ID", true, 1, TablesGrids.GetTDI_KOD_TEMSIL_SEKILLookup());
            var colmTEMSIL_TUR_ID = colmnVer("TEMSIL TUR ID", "TEMSIL_TUR_ID", true, 2, TablesGrids.GetTDI_KOD_TEMSIL_TURLookup());
            var colmDOSYA_NO = colmnVer("DOSYA NO", "DOSYA_NO", true, 3, null);
            var colmBELGE_SAYI_BILGISI = colmnVer("BELGE SAYI BILGISI", "BELGE_SAYI_BILGISI", true, 4, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 5, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 6, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 7, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmBIRIM_NO = colmnVer("BIRIM NO", "BIRIM_NO", true, 8, null);
            var colmTARIHI = colmnVer("TARIHI", "TARIHI", true, 9, null);
            var colmYEVMIYE = colmnVer("YEVMIYE", "YEVMIYE", true, 10, null);
            var colmSULH_VAR_MI = colmnVer("SULH VAR MI", "SULH_VAR_MI", true, 11, null);
            var colmFERAGAT_VAR_MI = colmnVer("FERAGAT VAR MI", "FERAGAT_VAR_MI", true, 12, null);
            var colmKABUL_VAR_MI = colmnVer("KABUL VAR MI", "KABUL_VAR_MI", true, 13, null);
            var colmAHZU_KABZ_VAR_MI = colmnVer("AHZU KABZ VAR MI", "AHZU_KABZ_VAR_MI", true, 14, null);
            var colmIBRA_VAR_MI = colmnVer("IBRA VAR MI", "IBRA_VAR_MI", true, 15, null);
            var colmTEVKIL_VAR_MI = colmnVer("TEVKIL VAR MI", "TEVKIL_VAR_MI", true, 16, null);
            var colmKAYIT_TARIHI = colmnVer("KAYIT TARIHI", "KAYIT_TARIHI", true, 17, null);
            var colmYEKTI_KULLANMA_SEKLI = colmnVer("YEKTI KULLANMA SEKLI", "YEKTI_KULLANMA_SEKLI", true, 18, null);
            var colmKALAN_SURE = colmnVer("KALAN SURE", "KALAN_SURE", true, 19, null);
            var colmEVRAK_SORUMLU_ID = colmnVer("EVRAK SORUMLU ID", "EVRAK_SORUMLU_ID", true, 20, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 21, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTEMSIL_YETKISI_VAR_MI = colmnVer("TEMSIL YETKISI VAR MI", "TEMSIL_YETKISI_VAR_MI", true, 22, null);
            var colmTEMSIL_TIP_ID = colmnVer("TEMSIL TIP ID", "TEMSIL_TIP_ID", true, 23, TablesGrids.GetTDI_KOD_TEMSIL_TIPLookup());
            var colmTEMSILE_YETKILI_CARI1_ID = colmnVer("TEMSILE YETKILI CARI1 ID", "TEMSILE_YETKILI_CARI1_ID", true, 24, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTEMSILE_YETKILI_CARI2_ID = colmnVer("TEMSILE YETKILI CARI2 ID", "TEMSILE_YETKILI_CARI2_ID", true, 25, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTEMSILE_YETKILI_CARI3_ID = colmnVer("TEMSILE YETKILI CARI3 ID", "TEMSILE_YETKILI_CARI3_ID", true, 26, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTEMSIL_SONA_ERME_TARIHI = colmnVer("TEMSIL SONA ERME TARIHI", "TEMSIL_SONA_ERME_TARIHI", true, 27, null);
            var colmVSES_ID = colmnVer("VSES ID", "VSES_ID", true, 28, TablesGrids.GetTDI_KOD_TEMSIL_SONA_ERME_SEBEPLookup());
            var colmVSES_TIP = colmnVer("VSES TIP", "VSES_TIP", true, 29);
            var colmAVUKAT_CARI_ID = colmnVer("AVUKAT CARI ID", "AVUKAT_CARI_ID", true, 30, TablesGrids.GetAV001_TDI_BIL_CARILookup());

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmTEMSIL_SEKIL_ID, colmTEMSIL_TUR_ID, colmDOSYA_NO, colmBELGE_SAYI_BILGISI, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmBIRIM_NO, colmTARIHI, colmYEVMIYE, colmSULH_VAR_MI, colmFERAGAT_VAR_MI, colmKABUL_VAR_MI, colmAHZU_KABZ_VAR_MI, colmIBRA_VAR_MI, colmTEVKIL_VAR_MI, colmKAYIT_TARIHI, colmYEKTI_KULLANMA_SEKLI, colmKALAN_SURE, colmEVRAK_SORUMLU_ID, colmTARAF_CARI_ID, colmTEMSIL_YETKISI_VAR_MI, colmTEMSIL_TIP_ID, colmTEMSILE_YETKILI_CARI1_ID, colmTEMSILE_YETKILI_CARI2_ID, colmTEMSILE_YETKILI_CARI3_ID, colmTEMSIL_SONA_ERME_TARIHI, colmVSES_ID, colmVSES_TIP, colmAVUKAT_CARI_ID });

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.TEMSIL_TARAFLIs;

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void TEMYIZ_TAKIP_SORUMLU_TARAFLI()
        {
            var colmDAVA_N_TUTAR_DOVIZ_ID = colmnVer("DAVA N TUTAR DOVIZ ID", "DAVA_N_TUTAR_DOVIZ_ID", true, 23, lupDoviz);
            var summaryDAVA_N_TUTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_N_TUTAR_DOVIZ_ID", colmDAVA_N_TUTAR_DOVIZ_ID, "", 2);
            colmDAVA_N_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_N_TUTAR_DOVIZ_ID.SummaryItem.FieldName = "DAVA_N_TUTAR_DOVIZ_ID";
            colmDAVA_N_TUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_N_TUTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_EDILEN_TUTAR_DOVIZ_ID = colmnVer("DAVA EDILEN TUTAR DOVIZ ID", "DAVA_EDILEN_TUTAR_DOVIZ_ID", true, 25, lupDoviz);
            var summaryDAVA_EDILEN_TUTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_EDILEN_TUTAR_DOVIZ_ID", colmDAVA_EDILEN_TUTAR_DOVIZ_ID, "", 2);
            colmDAVA_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
            colmDAVA_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmISLAH_EDILEN_TUTAR_DOVIZ_ID = colmnVer("ISLAH EDILEN TUTAR DOVIZ ID", "ISLAH_EDILEN_TUTAR_DOVIZ_ID", true, 29, lupDoviz);
            var summaryISLAH_EDILEN_TUTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLAH_EDILEN_TUTAR_DOVIZ_ID", colmISLAH_EDILEN_TUTAR_DOVIZ_ID, "", 2);
            colmISLAH_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmISLAH_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.FieldName = "ISLAH_EDILEN_TUTAR_DOVIZ_ID";
            colmISLAH_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLAH_EDILEN_TUTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPROTESTO_GIDERI_DOVIZ_ID = colmnVer("PROTESTO GIDERI DOVIZ ID", "PROTESTO_GIDERI_DOVIZ_ID", true, 31, lupDoviz);
            var summaryPROTESTO_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI_DOVIZ_ID", colmPROTESTO_GIDERI_DOVIZ_ID, "", 2);
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmIHTAR_GIDERI_DOVIZ_ID = colmnVer("IHTAR GIDERI DOVIZ ID", "IHTAR_GIDERI_DOVIZ_ID", true, 33, lupDoviz);
            var summaryIHTAR_GIDERI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI_DOVIZ_ID", colmIHTAR_GIDERI_DOVIZ_ID, "", 2);
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmDAVA_N_DIGER_GIDER_DOVIZ_ID = colmnVer("DAVA N DIGER GIDER DOVIZ ID", "DAVA_N_DIGER_GIDER_DOVIZ_ID", true, 35, lupDoviz);
            var summaryDAVA_N_DIGER_GIDER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_N_DIGER_GIDER_DOVIZ_ID", colmDAVA_N_DIGER_GIDER_DOVIZ_ID, "", 2);
            colmDAVA_N_DIGER_GIDER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmDAVA_N_DIGER_GIDER_DOVIZ_ID.SummaryItem.FieldName = "DAVA_N_DIGER_GIDER_DOVIZ_ID";
            colmDAVA_N_DIGER_GIDER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_N_DIGER_GIDER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = colmnVer("SORUMLU OLUNAN MIKTAR DOVIZ ID", "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID", true, 68, lupDoviz);
            var summarySORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID", colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, "", 2);
            colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.SummaryItem.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
            colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmHUKUM_DEGER_DOVIZ_ID = colmnVer("HUKUM DEGER DOVIZ ID", "HUKUM_DEGER_DOVIZ_ID", true, 90, lupDoviz);
            var summaryHUKUM_DEGER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HUKUM_DEGER_DOVIZ_ID", colmHUKUM_DEGER_DOVIZ_ID, "", 2);
            colmHUKUM_DEGER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmHUKUM_DEGER_DOVIZ_ID.SummaryItem.FieldName = "HUKUM_DEGER_DOVIZ_ID";
            colmHUKUM_DEGER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHUKUM_DEGER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmMUSADERE_DEGER_DOVIZ_ID = colmnVer("MUSADERE DEGER DOVIZ ID", "MUSADERE_DEGER_DOVIZ_ID", true, 91, lupDoviz);
            var summaryMUSADERE_DEGER_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MUSADERE_DEGER_DOVIZ_ID", colmMUSADERE_DEGER_DOVIZ_ID, "", 2);
            colmMUSADERE_DEGER_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmMUSADERE_DEGER_DOVIZ_ID.SummaryItem.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
            colmMUSADERE_DEGER_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMUSADERE_DEGER_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = colmnVer("PARAYA CEVRILEN MIKTAR DOVIZ ID", "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID", true, 98, lupDoviz);
            var summaryPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID", colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID, "", 2);
            colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.SummaryItem.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
            colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmSORUMLULUK_MIKTARI_DOVIZ_ID = colmnVer("SORUMLULUK MIKTARI DOVIZ ID", "SORUMLULUK_MIKTARI_DOVIZ_ID", true, 110, lupDoviz);
            var summarySORUMLULUK_MIKTARI_DOVIZ_ID = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SORUMLULUK_MIKTARI_DOVIZ_ID", colmSORUMLULUK_MIKTARI_DOVIZ_ID, "", 2);
            colmSORUMLULUK_MIKTARI_DOVIZ_ID.SummaryItem.DisplayFormat = "{0}";
            colmSORUMLULUK_MIKTARI_DOVIZ_ID.SummaryItem.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
            colmSORUMLULUK_MIKTARI_DOVIZ_ID.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSORUMLULUK_MIKTARI_DOVIZ_ID.SummaryItem.Tag = 2;

            var colmTERDITLI_MI = colmnVer("TERDITLI MI", "TERDITLI_MI", true, 1, null);
            var colmANA_DAVA_NEDEN_ID = colmnVer("ANA DAVA NEDEN ID", "ANA_DAVA_NEDEN_ID", true, 2, TablesGrids.GetAV001_TD_BIL_DAVA_NEDENLookup());
            var colmDAVA_EDEN_TARAF_STATU_ID = colmnVer("DAVA EDEN TARAF STATU ID", "DAVA_EDEN_TARAF_STATU_ID", true, 3, TablesGrids.GetTD_KOD_TARAF_STATULookup());
            var colmDAVA_EDILEN_TARAF_STATU_ID = colmnVer("DAVA EDILEN TARAF STATU ID", "DAVA_EDILEN_TARAF_STATU_ID", true, 4, TablesGrids.GetTD_KOD_TARAF_STATULookup());
            var colmDAVA_NEDEN_TIP_ID = colmnVer("DAVA NEDEN TIP ID", "DAVA_NEDEN_TIP_ID", true, 5, TablesGrids.GetTD_KOD_DAVA_NEDEN_TIPLookup());
            var colmDAVA_NEDEN_KOD_ID = colmnVer("DAVA NEDEN KOD ID", "DAVA_NEDEN_KOD_ID", true, 6, TablesGrids.GetTDI_KOD_DAVA_ADILookup());
            var colmDIGER_DAVA_NEDEN = colmnVer("DIGER DAVA NEDEN", "DIGER_DAVA_NEDEN", true, 7, null);
            var colmOLAY_ADLI_BIRIM_ADLIYE_ID = colmnVer("OLAY ADLI BIRIM ADLIYE ID", "OLAY_ADLI_BIRIM_ADLIYE_ID", true, 8, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmOLAY_SUC_TARIHI = colmnVer("OLAY SUC TARIHI", "OLAY_SUC_TARIHI", true, 9);
            var colmDUZENLEME_TARIHI = colmnVer("DUZENLEME TARIHI", "DUZENLEME_TARIHI", true, 10, null);
            var colmTEBELLUG_TARIHI = colmnVer("TEBELLUG TARIHI", "TEBELLUG_TARIHI", true, 11, null);
            var colmFAIZ_TALEP_TARIHI = colmnVer("FAIZ TALEP TARIHI", "FAIZ_TALEP_TARIHI", true, 12, null);
            var colmFAIZ_KARAR_TARIHI = colmnVer("FAIZ KARAR TARIHI", "FAIZ_KARAR_TARIHI", true, 13, null);
            var colmTEDBIR_TARIHI = colmnVer("TEDBIR TARIHI", "TEDBIR_TARIHI", true, 14, null);
            var colmTEDBIR_KALDIRILMA_TARIHI = colmnVer("TEDBIR KALDIRILMA TARIHI", "TEDBIR_KALDIRILMA_TARIHI", true, 15, null);
            var colmTEDBIR_TALEP_TARIHI = colmnVer("TEDBIR TALEP TARIHI", "TEDBIR_TALEP_TARIHI", true, 16, null);
            var colmDOVIZ_ISLEM_TIPI = colmnVer("DOVIZ ISLEM TIPI", "DOVIZ_ISLEM_TIPI", true, 17, null);
            var colmSABIT_FAIZ_UYGULA = colmnVer("SABIT FAIZ UYGULA", "SABIT_FAIZ_UYGULA", true, 18, null);
            var colmDO_FAIZ_TIP_ID = colmnVer("DO FAIZ TIP ID", "DO_FAIZ_TIP_ID", true, 19, TablesGrids.GetTDI_KOD_FAIZ_TIPLookup());
            var colmDO_FAIZ_ORANI = colmnVer("DO FAIZ ORANI", "DO_FAIZ_ORANI", true, 20, null);
            var colmDAVA_NEDEN_FAIZ_TIP_ID = colmnVer("DAVA NEDEN FAIZ TIP ID", "DAVA_NEDEN_FAIZ_TIP_ID", true, 21, TablesGrids.GetTDI_KOD_FAIZ_TIPLookup());
            var colmDAVA_NEDEN_FAIZ_ORANI = colmnVer("DAVA NEDEN FAIZ ORANI", "DAVA_NEDEN_FAIZ_ORANI", true, 22, null);
            var colmDAVA_N_TUTAR = colmnVer("DAVA N TUTAR", "DAVA_N_TUTAR", true, 24, null, colmDAVA_N_TUTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_N_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_N_TUTAR", colmDAVA_N_TUTAR, "", 1);
            colmDAVA_N_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_N_TUTAR.SummaryItem.FieldName = "DAVA_N_TUTAR";
            colmDAVA_N_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_N_TUTAR.SummaryItem.Tag = 1;

            var colmDAVA_EDILEN_TUTAR = colmnVer("DAVA EDILEN TUTAR", "DAVA_EDILEN_TUTAR", true, 26, null, colmDAVA_EDILEN_TUTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_EDILEN_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_EDILEN_TUTAR", colmDAVA_EDILEN_TUTAR, "", 1);
            colmDAVA_EDILEN_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_EDILEN_TUTAR.SummaryItem.FieldName = "DAVA_EDILEN_TUTAR";
            colmDAVA_EDILEN_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_EDILEN_TUTAR.SummaryItem.Tag = 1;

            var colmISLAH_EDILMIS = colmnVer("ISLAH EDILMIS", "ISLAH_EDILMIS", true, 27, null);
            var colmISLAH_TARIHI = colmnVer("ISLAH TARIHI", "ISLAH_TARIHI", true, 28, null);
            var colmISLAH_EDILEN_TUTAR = colmnVer("ISLAH EDILEN TUTAR", "ISLAH_EDILEN_TUTAR", true, 30, null, colmISLAH_EDILEN_TUTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryISLAH_EDILEN_TUTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "ISLAH_EDILEN_TUTAR", colmISLAH_EDILEN_TUTAR, "", 1);
            colmISLAH_EDILEN_TUTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmISLAH_EDILEN_TUTAR.SummaryItem.FieldName = "ISLAH_EDILEN_TUTAR";
            colmISLAH_EDILEN_TUTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmISLAH_EDILEN_TUTAR.SummaryItem.Tag = 1;

            var colmPROTESTO_GIDERI = colmnVer("PROTESTO GIDERI", "PROTESTO_GIDERI", true, 32, null, colmPROTESTO_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPROTESTO_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PROTESTO_GIDERI", colmPROTESTO_GIDERI, "", 1);
            colmPROTESTO_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPROTESTO_GIDERI.SummaryItem.FieldName = "PROTESTO_GIDERI";
            colmPROTESTO_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPROTESTO_GIDERI.SummaryItem.Tag = 1;

            var colmIHTAR_GIDERI = colmnVer("IHTAR GIDERI", "IHTAR_GIDERI", true, 34, null, colmIHTAR_GIDERI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryIHTAR_GIDERI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "IHTAR_GIDERI", colmIHTAR_GIDERI, "", 1);
            colmIHTAR_GIDERI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmIHTAR_GIDERI.SummaryItem.FieldName = "IHTAR_GIDERI";
            colmIHTAR_GIDERI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmIHTAR_GIDERI.SummaryItem.Tag = 1;

            var colmDAVA_N_DIGER_GIDER = colmnVer("DAVA N DIGER GIDER", "DAVA_N_DIGER_GIDER", true, 36, null, colmDAVA_N_DIGER_GIDER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryDAVA_N_DIGER_GIDER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DAVA_N_DIGER_GIDER", colmDAVA_N_DIGER_GIDER, "", 1);
            colmDAVA_N_DIGER_GIDER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmDAVA_N_DIGER_GIDER.SummaryItem.FieldName = "DAVA_N_DIGER_GIDER";
            colmDAVA_N_DIGER_GIDER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmDAVA_N_DIGER_GIDER.SummaryItem.Tag = 1;

            var colmDAVA_NEDEN_SURE_GUN = colmnVer("DAVA NEDEN SURE GUN", "DAVA_NEDEN_SURE_GUN", true, 37, null);
            var colmDAVA_NEDEN_SURE_AY = colmnVer("DAVA NEDEN SURE AY", "DAVA_NEDEN_SURE_AY", true, 38, null);
            var colmDAVA_NEDEN_SURE_YIL = colmnVer("DAVA NEDEN SURE YIL", "DAVA_NEDEN_SURE_YIL", true, 39, null);
            var colmDAVA_NEDEN_REFERANS_NO1 = colmnVer("DAVA NEDEN REFERANS NO1", "DAVA_NEDEN_REFERANS_NO1", true, 40, null);
            var colmDAVA_NEDEN_REFERANS_NO2 = colmnVer("DAVA NEDEN REFERANS NO2", "DAVA_NEDEN_REFERANS_NO2", true, 41, null);
            var colmVERGI_DONEMI = colmnVer("VERGI DONEMI", "VERGI_DONEMI", true, 42, null);
            var colmFAIZ_YOK = colmnVer("FAIZ YOK", "FAIZ_YOK", true, 43, null);
            var colmTARAF_SIFAT_ID = colmnVer("TARAF SIFAT ID", "TARAF_SIFAT_ID", true, 44, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmTARAF_CARI_ID = colmnVer("TARAF CARI ID", "TARAF_CARI_ID", true, 45, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmKESINLESME_TARIHI = colmnVer("KESINLESME TARIHI", "KESINLESME_TARIHI", true, 46, null);
            var colmSULH_TARIHI = colmnVer("SULH TARIHI", "SULH_TARIHI", true, 47, null);
            var colmKABUL_TARIHI = colmnVer("KABUL TARIHI", "KABUL_TARIHI", true, 48, null);
            var colmATIYE_BIRAKMA_TARIHI = colmnVer("ATIYE BIRAKMA TARIHI", "ATIYE_BIRAKMA_TARIHI", true, 49, null);
            var colmVAZGECME_TARIHI = colmnVer("VAZGECME TARIHI", "VAZGECME_TARIHI", true, 50, null);
            var colmIKRAR_TARIHI = colmnVer("IKRAR TARIHI", "IKRAR_TARIHI", true, 51, null);
            var colmGERI_ALMA_TARIHI = colmnVer("GERI ALMA TARIHI", "GERI_ALMA_TARIHI", true, 52, null);
            var colmASLI_MUDEHALE_TARIHI = colmnVer("ASLI MUDEHALE TARIHI", "ASLI_MUDEHALE_TARIHI", true, 53, null);
            var colmFERI_MUDEHALE_TARIHI = colmnVer("FERI MUDEHALE TARIHI", "FERI_MUDEHALE_TARIHI", true, 54, null);
            var colmYETKIYE_ITIRAZ_TARIHI = colmnVer("YETKIYE ITIRAZ TARIHI", "YETKIYE_ITIRAZ_TARIHI", true, 55, null);
            var colmGOREVE_ITIRAZ_TARIHI = colmnVer("GOREVE ITIRAZ TARIHI", "GOREVE_ITIRAZ_TARIHI", true, 56, null);
            var colmTAKIGAT_TARIHI = colmnVer("TAKIGAT TARIHI", "TAKIGAT_TARIHI", true, 57, null);
            var colmESAS_BEYAN_TARIHI = colmnVer("ESAS BEYAN TARIHI", "ESAS_BEYAN_TARIHI", true, 58, null);
            var colmEK_SAVUNMA_TARIHI = colmnVer("EK SAVUNMA TARIHI", "EK_SAVUNMA_TARIHI", true, 59, null);
            var colmMUDAHALE_TARIHI = colmnVer("MUDAHALE TARIHI", "MUDAHALE_TARIHI", true, 60, null);
            var colmSON_SAVUNMA_TARIHI = colmnVer("SON SAVUNMA TARIHI", "SON_SAVUNMA_TARIHI", true, 61, null);
            var colmSAVUNMA_TARIHI = colmnVer("SAVUNMA TARIHI", "SAVUNMA_TARIHI", true, 62, null);
            var colmMUTALAA_TARIHI = colmnVer("MUTALAA TARIHI", "MUTALAA_TARIHI", true, 63, null);
            var colmIDDIANAME_OKUNMA_TARIHI = colmnVer("IDDIANAME OKUNMA TARIHI", "IDDIANAME_OKUNMA_TARIHI", true, 64, null);
            var colmZAMAN_ASIMI_TARIHI = colmnVer("ZAMAN ASIMI TARIHI", "ZAMAN_ASIMI_TARIHI", true, 65, null);
            var colmOGRENME_TARIHI = colmnVer("OGRENME TARIHI", "OGRENME_TARIHI", true, 66, null);
            var colmSORUMLU_OLUNAN_MIKTAR = colmnVer("SORUMLU OLUNAN MIKTAR", "SORUMLU_OLUNAN_MIKTAR", true, 67, null, colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySORUMLU_OLUNAN_MIKTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SORUMLU_OLUNAN_MIKTAR", colmSORUMLU_OLUNAN_MIKTAR, "", 1);
            colmSORUMLU_OLUNAN_MIKTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSORUMLU_OLUNAN_MIKTAR.SummaryItem.FieldName = "SORUMLU_OLUNAN_MIKTAR";
            colmSORUMLU_OLUNAN_MIKTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSORUMLU_OLUNAN_MIKTAR.SummaryItem.Tag = 1;

            var colmSURE_TUTUM_TARIHI = colmnVer("SURE TUTUM TARIHI", "SURE_TUTUM_TARIHI", true, 69, null);
            var colmDURUSMA_TALEP_TARIHI = colmnVer("DURUSMA TALEP TARIHI", "DURUSMA_TALEP_TARIHI", true, 70, null);
            var colmKESIF_TALEP_TARIHI = colmnVer("KESIF TALEP TARIHI", "KESIF_TALEP_TARIHI", true, 71, null);
            var colmGERI_BASVURMA_TARIHI = colmnVer("GERI BASVURMA TARIHI", "GERI_BASVURMA_TARIHI", true, 72, null);
            var colmYURUTME_DURDURMA_TALEP_TARIHI = colmnVer("YURUTME DURDURMA TALEP TARIHI", "YURUTME_DURDURMA_TALEP_TARIHI", true, 73, null);
            var colmYURUTME_DURDURMA_TARIHI = colmnVer("YURUTME DURDURMA TARIHI", "YURUTME_DURDURMA_TARIHI", true, 74, null);
            var colmYURUTME_DURDURMA_KALDIRILMA_TARIHI = colmnVer("YURUTME DURDURMA KALDIRILMA TARIHI", "YURUTME_DURDURMA_KALDIRILMA_TARIHI", true, 75, null);
            var colmIHBAR_TARIHI = colmnVer("IHBAR TARIHI", "IHBAR_TARIHI", true, 76, null);
            var colmIHBAR_EDILEN_CARI_ID = colmnVer("IHBAR EDILEN CARI ID", "IHBAR_EDILEN_CARI_ID", true, 77, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmIHTAR_TARIHI = colmnVer("IHTAR TARIHI", "IHTAR_TARIHI", true, 78, null);
            var colmIHTAR_TEBLIG_TARIHI = colmnVer("IHTAR TEBLIG TARIHI", "IHTAR_TEBLIG_TARIHI", true, 79, null);
            var colmIHTAR_TEMERRUT_TARIHI = colmnVer("IHTAR TEMERRUT TARIHI", "IHTAR_TEMERRUT_TARIHI", true, 80, null);
            var colmZAMANASIMI_IDDIA_TARIHI = colmnVer("ZAMANASIMI IDDIA TARIHI", "ZAMANASIMI_IDDIA_TARIHI", true, 81, null);
            var colmIHBAR_TEBLIG_TARIHI = colmnVer("IHBAR TEBLIG TARIHI", "IHBAR_TEBLIG_TARIHI", true, 82, null);
            var colmMAHKEMEDE_UZLASMA_TARIHI = colmnVer("MAHKEMEDE UZLASMA TARIHI", "MAHKEMEDE_UZLASMA_TARIHI", true, 83, null);
            var colmHUKUM_TARIHI = colmnVer("HUKUM TARIHI", "HUKUM_TARIHI", true, 84, null);
            var colmKARAR_NO = colmnVer("KARAR NO", "KARAR_NO", true, 85, null);
            var colmHUKUM_ID = colmnVer("HUKUM ID", "HUKUM_ID", true, 86, TablesGrids.GetTD_KOD_MAHKEME_HUKUMLookup());
            var colmHUKUM_TIP_ID = colmnVer("HUKUM TIP ID", "HUKUM_TIP_ID", true, 87, TablesGrids.GetTD_KOD_MAHKEME_HUKUM_TIPLookup());
            var colmHUKUM_GEREKCE = colmnVer("HUKUM GEREKCE", "HUKUM_GEREKCE", true, 88, null);
            var colmHUKUM_DEGER = colmnVer("HUKUM DEGER", "HUKUM_DEGER", true, 89, null, colmHUKUM_DEGER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryHUKUM_DEGER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "HUKUM_DEGER", colmHUKUM_DEGER, "", 1);
            colmHUKUM_DEGER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmHUKUM_DEGER.SummaryItem.FieldName = "HUKUM_DEGER";
            colmHUKUM_DEGER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmHUKUM_DEGER.SummaryItem.Tag = 1;

            var colmMUSADERE_DEGER = colmnVer("MUSADERE DEGER", "MUSADERE_DEGER", true, 92, null, colmMUSADERE_DEGER_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryMUSADERE_DEGER = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MUSADERE_DEGER", colmMUSADERE_DEGER, "", 1);
            colmMUSADERE_DEGER.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmMUSADERE_DEGER.SummaryItem.FieldName = "MUSADERE_DEGER";
            colmMUSADERE_DEGER.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmMUSADERE_DEGER.SummaryItem.Tag = 1;

            var colmMAHKUMIYET_YIL = colmnVer("MAHKUMIYET YIL", "MAHKUMIYET_YIL", true, 93, null);
            var colmMAHKUMIYET_AY = colmnVer("MAHKUMIYET AY", "MAHKUMIYET_AY", true, 94, null);
            var colmMAHKUMIYET_GUN = colmnVer("MAHKUMIYET GUN", "MAHKUMIYET_GUN", true, 95, null);
            var colmCEZA_ERTELENDI = colmnVer("CEZA ERTELENDI", "CEZA_ERTELENDI", true, 96, null);
            var colmPARAYA_CEVRILDI = colmnVer("PARAYA CEVRILDI", "PARAYA_CEVRILDI", true, 97, null);
            var colmPARAYA_CEVRILEN_MIKTAR = colmnVer("PARAYA CEVRILEN MIKTAR", "PARAYA_CEVRILEN_MIKTAR", true, 99, null, colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID, "###,###,###,###,##0.00");
            var summaryPARAYA_CEVRILEN_MIKTAR = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PARAYA_CEVRILEN_MIKTAR", colmPARAYA_CEVRILEN_MIKTAR, "", 1);
            colmPARAYA_CEVRILEN_MIKTAR.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmPARAYA_CEVRILEN_MIKTAR.SummaryItem.FieldName = "PARAYA_CEVRILEN_MIKTAR";
            colmPARAYA_CEVRILEN_MIKTAR.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmPARAYA_CEVRILEN_MIKTAR.SummaryItem.Tag = 1;

            var colmMESLEK_ICRA_MEN_TIP = colmnVer("MESLEK ICRA MEN TIP", "MESLEK_ICRA_MEN_TIP", true, 100, TablesGrids.GetMEN_TIPLookup());
            var colmMESLEK_ICRA_MEN_SURE = colmnVer("MESLEK ICRA MEN SURE", "MESLEK_ICRA_MEN_SURE", true, 101, null);
            var colmEHLIYET_GERI_ALINMA_MEN_TIP = colmnVer("EHLIYET GERI ALINMA MEN TIP", "EHLIYET_GERI_ALINMA_MEN_TIP", true, 102, TablesGrids.GetMEN_TIPLookup());
            var colmEHLIYET_GERI_ALINMA_MEN_SURE = colmnVer("EHLIYET GERI ALINMA MEN SURE", "EHLIYET_GERI_ALINMA_MEN_SURE", true, 103, null);
            var colmKAMU_HIZMET_YASAK_TIP = colmnVer("KAMU HIZMET YASAK TIP", "KAMU_HIZMET_YASAK_TIP", true, 104, TablesGrids.GetMEN_TIPLookup());
            var colmKAMU_HIZMET_YASAK_SURE = colmnVer("KAMU HIZMET YASAK SURE", "KAMU_HIZMET_YASAK_SURE", true, 105, null);
            var colmHUKUM_TARAF_CARI_ID = colmnVer("HUKUM TARAF CARI ID", "HUKUM_TARAF_CARI_ID", true, 106, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmINFAZ_TARIHI = colmnVer("INFAZ TARIHI", "INFAZ_TARIHI", true, 107, null);
            var colmHUKUM_KESINLESME_TARIHI = colmnVer("HUKUM KESINLESME TARIHI", "HUKUM_KESINLESME_TARIHI", true, 108, null);
            var colmSORUMLULUK_MIKTARI = colmnVer("SORUMLULUK MIKTARI", "SORUMLULUK_MIKTARI", true, 109, null, colmSORUMLULUK_MIKTARI_DOVIZ_ID, "###,###,###,###,##0.00");
            var summarySORUMLULUK_MIKTARI = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SORUMLULUK_MIKTARI", colmSORUMLULUK_MIKTARI, "", 1);
            colmSORUMLULUK_MIKTARI.SummaryItem.DisplayFormat = "Toplam = {0:###,###,##0.00}";
            colmSORUMLULUK_MIKTARI.SummaryItem.FieldName = "SORUMLULUK_MIKTARI";
            colmSORUMLULUK_MIKTARI.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            colmSORUMLULUK_MIKTARI.SummaryItem.Tag = 1;

            var colmHUKUM_TEBLIG_TEFHIM_TARIHI = colmnVer("HUKUM TEBLIG TEFHIM TARIHI", "HUKUM_TEBLIG_TEFHIM_TARIHI", true, 111, null);
            var colmTEMYIZ_TIP_ID = colmnVer("TEMYIZ TIP ID", "TEMYIZ_TIP_ID", true, 112, TablesGrids.GetTD_KOD_TEMYIZ_TIPLookup());
            var colmYUKSEK_MAHKEME_GONDERIM_TARIHI = colmnVer("YUKSEK MAHKEME GONDERIM TARIHI", "YUKSEK_MAHKEME_GONDERIM_TARIHI", true, 113, null);
            var colmTEMYIZ_ADLI_BIRIM_ADLIYE_ID = colmnVer("TEMYIZ ADLI BIRIM ADLIYE ID", "TEMYIZ_ADLI_BIRIM_ADLIYE_ID", true, 114, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmTEMYIZ_ADLI_BIRIM_GOREV_ID = colmnVer("TEMYIZ ADLI BIRIM GOREV ID", "TEMYIZ_ADLI_BIRIM_GOREV_ID", true, 115, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmTEMYIZ_ADLI_BIRIM_NO_ID = colmnVer("TEMYIZ ADLI BIRIM NO ID", "TEMYIZ_ADLI_BIRIM_NO_ID", true, 116, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmTEMYIZ_ESAS_NO = colmnVer("TEMYIZ ESAS NO", "TEMYIZ_ESAS_NO", true, 117, null);
            var colmTEMYIZ_KARAR_TARIHI = colmnVer("TEMYIZ KARAR TARIHI", "TEMYIZ_KARAR_TARIHI", true, 118, null);
            var colmTEMYIZ_KARAR_NO = colmnVer("TEMYIZ KARAR NO", "TEMYIZ_KARAR_NO", true, 119, null);
            var colmTEMYIZ_KARAR_TIP_ID = colmnVer("TEMYIZ KARAR TIP ID", "TEMYIZ_KARAR_TIP_ID", true, 120, TablesGrids.GetTD_KOD_TEMYIZ_TIPLookup());
            var colmTEMYIZ_GEREKCE = colmnVer("TEMYIZ GEREKCE", "TEMYIZ_GEREKCE", true, 121, null);
            var colmTEMYIZ_TARAF_TEMYIZ_TARIHI = colmnVer("TEMYIZ TARAF TEMYIZ TARIHI", "TEMYIZ_TARAF_TEMYIZ_TARIHI", true, 122, null);
            var colmTEMYIZ_TARAF_CARI_ID = colmnVer("TEMYIZ TARAF CARI ID", "TEMYIZ_TARAF_CARI_ID", true, 123, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmTEMYIZ_TARAF_USUL_NEDENLERI = colmnVer("TEMYIZ TARAF USUL NEDENLERI", "TEMYIZ_TARAF_USUL_NEDENLERI", true, 124, null);
            var colmTEMYIZ_TARAF_YASAL_NEDENLER = colmnVer("TEMYIZ TARAF YASAL NEDENLER", "TEMYIZ_TARAF_YASAL_NEDENLER", true, 125, null);
            var colmTEMYIZ_TARAF_ACIKLAMA = colmnVer("TEMYIZ TARAF ACIKLAMA", "TEMYIZ_TARAF_ACIKLAMA", true, 126, null);
            var colmTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI = colmnVer("TEMYIZ TARAF TEDBIR ISTEM TARIHI", "TEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI", true, 127, null);
            var colmTEMYIZ_TARAF_TEDBIR_TARIHI = colmnVer("TEMYIZ TARAF TEDBIR TARIHI", "TEMYIZ_TARAF_TEDBIR_TARIHI", true, 128, null);
            var colmTEMYIZ_TARAF_TEDBIR_ACIKLAMASI = colmnVer("TEMYIZ TARAF TEDBIR ACIKLAMASI", "TEMYIZ_TARAF_TEDBIR_ACIKLAMASI", true, 129, null);
            var colmTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI = colmnVer("TEMYIZ TARAF TEDBIRIN KALDIRILMASI TARIHI", "TEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI", true, 130, null);
            var colmTEMYIZ_TEBLIG_TARIHI = colmnVer("TEMYIZ TEBLIG TARIHI", "TEMYIZ_TEBLIG_TARIHI", true, 131, null);
            var colmTEFHIM_TARIHI = colmnVer("TEFHIM TARIHI", "TEFHIM_TARIHI", true, 132, null);
            var colmTEMYIZ_TARAF_SURE_TUTUM_TARIHI = colmnVer("TEMYIZ TARAF SURE TUTUM TARIHI", "TEMYIZ_TARAF_SURE_TUTUM_TARIHI", true, 133, null);
            var colmDAVA_FOY_NO = colmnVer("DAVA FOY NO", "DAVA_FOY_NO", true, 134, null);
            var colmDAVA_ADLI_BIRIM_ADLIYE_ID = colmnVer("DAVA ADLI BIRIM ADLIYE ID", "DAVA_ADLI_BIRIM_ADLIYE_ID", true, 135, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmDAVA_ADLI_BIRIM_GOREV_ID = colmnVer("DAVA ADLI BIRIM GOREV ID", "DAVA_ADLI_BIRIM_GOREV_ID", true, 136, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmDAVA_ADLI_BIRIM_NO_ID = colmnVer("DAVA ADLI BIRIM NO ID", "DAVA_ADLI_BIRIM_NO_ID", true, 137, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmDAVA_ESAS_NO = colmnVer("DAVA ESAS NO", "DAVA_ESAS_NO", true, 138, null);
            var colmDAVA_TAKIP_T = colmnVer("DAVA TAKIP T", "DAVA_TAKIP_T", true, 139, null);
            var colmDAVA_REFERANS_NO2 = colmnVer("DAVA REFERANS NO2", "DAVA_REFERANS_NO2", true, 140, null);
            var colmDAVA_REFERANS_NO3 = colmnVer("DAVA REFERANS NO3", "DAVA_REFERANS_NO3", true, 141, null);
            var colmDAVA_REFERANS_NO = colmnVer("DAVA REFERANS NO", "DAVA_REFERANS_NO", true, 142, null);
            var colmDAVA_OZEL_KOD1 = colmnVer("DAVA OZEL KOD1", "DAVA_OZEL_KOD1", true, 143, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmDAVA_OZEL_KOD2 = colmnVer("DAVA OZEL KOD2", "DAVA_OZEL_KOD2", true, 144, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmDAVA_OZEL_KOD3 = colmnVer("DAVA OZEL KOD3", "DAVA_OZEL_KOD3", true, 145, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmDAVA_OZEL_KOD4 = colmnVer("DAVA OZEL KOD4", "DAVA_OZEL_KOD4", true, 146, TablesGrids.GetAV001_TDI_KOD_FOY_OZELLookup());
            var colmDAVA_ASAMA_ID = colmnVer("DAVA ASAMA ID", "DAVA_ASAMA_ID", true, 147, TablesGrids.GetAV001_TDIE_BIL_ASAMALookup());
            var colmDAVA_TALEP = colmnVer("DAVA TALEP", "DAVA_TALEP", true, 148, null);
            var colmDAVA_TARAF_KODU = colmnVer("DAVA TARAF KODU", "DAVA_TARAF_KODU", true, 149, null);
            var colmDAVA_TARAF_CARI_ID = colmnVer("DAVA TARAF CARI ID", "DAVA_TARAF_CARI_ID", true, 150, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmDAVA_TARAF_SIFAT_ID = colmnVer("DAVA TARAF SIFAT ID", "DAVA_TARAF_SIFAT_ID", true, 151, TablesGrids.GetTDIE_KOD_TARAF_SIFATLookup());
            var colmSORUMLU_AVUKAT_CARI_ID = colmnVer("SORUMLU AVUKAT CARI ID", "SORUMLU_AVUKAT_CARI_ID", true, 152, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmSORUMLU_TIP = colmnVer("SORUMLU TIP", "SORUMLU_TIP", true, 153, null);

            GridView grid = gridRaporCntrol.MainView as GridView;

            grid.Columns.AddRange(new[] { colmDAVA_N_TUTAR_DOVIZ_ID, colmDAVA_EDILEN_TUTAR_DOVIZ_ID, colmISLAH_EDILEN_TUTAR_DOVIZ_ID, colmPROTESTO_GIDERI_DOVIZ_ID, colmIHTAR_GIDERI_DOVIZ_ID, colmDAVA_N_DIGER_GIDER_DOVIZ_ID, colmSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, colmHUKUM_DEGER_DOVIZ_ID, colmMUSADERE_DEGER_DOVIZ_ID, colmPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID, colmSORUMLULUK_MIKTARI_DOVIZ_ID, colmTERDITLI_MI, colmANA_DAVA_NEDEN_ID, colmDAVA_EDEN_TARAF_STATU_ID, colmDAVA_EDILEN_TARAF_STATU_ID, colmDAVA_NEDEN_TIP_ID, colmDAVA_NEDEN_KOD_ID, colmDIGER_DAVA_NEDEN, colmOLAY_ADLI_BIRIM_ADLIYE_ID, colmOLAY_SUC_TARIHI, colmDUZENLEME_TARIHI, colmTEBELLUG_TARIHI, colmFAIZ_TALEP_TARIHI, colmFAIZ_KARAR_TARIHI, colmTEDBIR_TARIHI, colmTEDBIR_KALDIRILMA_TARIHI, colmTEDBIR_TALEP_TARIHI, colmDOVIZ_ISLEM_TIPI, colmSABIT_FAIZ_UYGULA, colmDO_FAIZ_TIP_ID, colmDO_FAIZ_ORANI, colmDAVA_NEDEN_FAIZ_TIP_ID, colmDAVA_NEDEN_FAIZ_ORANI, colmDAVA_N_TUTAR, colmDAVA_EDILEN_TUTAR, colmISLAH_EDILMIS, colmISLAH_TARIHI, colmISLAH_EDILEN_TUTAR, colmPROTESTO_GIDERI, colmIHTAR_GIDERI, colmDAVA_N_DIGER_GIDER, colmDAVA_NEDEN_SURE_GUN, colmDAVA_NEDEN_SURE_AY, colmDAVA_NEDEN_SURE_YIL, colmDAVA_NEDEN_REFERANS_NO1, colmDAVA_NEDEN_REFERANS_NO2, colmVERGI_DONEMI, colmFAIZ_YOK, colmTARAF_SIFAT_ID, colmTARAF_CARI_ID, colmKESINLESME_TARIHI, colmSULH_TARIHI, colmKABUL_TARIHI, colmATIYE_BIRAKMA_TARIHI, colmVAZGECME_TARIHI, colmIKRAR_TARIHI, colmGERI_ALMA_TARIHI, colmASLI_MUDEHALE_TARIHI, colmFERI_MUDEHALE_TARIHI, colmYETKIYE_ITIRAZ_TARIHI, colmGOREVE_ITIRAZ_TARIHI, colmTAKIGAT_TARIHI, colmESAS_BEYAN_TARIHI, colmEK_SAVUNMA_TARIHI, colmMUDAHALE_TARIHI, colmSON_SAVUNMA_TARIHI, colmSAVUNMA_TARIHI, colmMUTALAA_TARIHI, colmIDDIANAME_OKUNMA_TARIHI, colmZAMAN_ASIMI_TARIHI, colmOGRENME_TARIHI, colmSORUMLU_OLUNAN_MIKTAR, colmSURE_TUTUM_TARIHI, colmDURUSMA_TALEP_TARIHI, colmKESIF_TALEP_TARIHI, colmGERI_BASVURMA_TARIHI, colmYURUTME_DURDURMA_TALEP_TARIHI, colmYURUTME_DURDURMA_TARIHI, colmYURUTME_DURDURMA_KALDIRILMA_TARIHI, colmIHBAR_TARIHI, colmIHBAR_EDILEN_CARI_ID, colmIHTAR_TARIHI, colmIHTAR_TEBLIG_TARIHI, colmIHTAR_TEMERRUT_TARIHI, colmZAMANASIMI_IDDIA_TARIHI, colmIHBAR_TEBLIG_TARIHI, colmMAHKEMEDE_UZLASMA_TARIHI, colmHUKUM_TARIHI, colmKARAR_NO, colmHUKUM_ID, colmHUKUM_TIP_ID, colmHUKUM_GEREKCE, colmHUKUM_DEGER, colmMUSADERE_DEGER, colmMAHKUMIYET_YIL, colmMAHKUMIYET_AY, colmMAHKUMIYET_GUN, colmCEZA_ERTELENDI, colmPARAYA_CEVRILDI, colmPARAYA_CEVRILEN_MIKTAR, colmMESLEK_ICRA_MEN_TIP, colmMESLEK_ICRA_MEN_SURE, colmEHLIYET_GERI_ALINMA_MEN_TIP, colmEHLIYET_GERI_ALINMA_MEN_SURE, colmKAMU_HIZMET_YASAK_TIP, colmKAMU_HIZMET_YASAK_SURE, colmHUKUM_TARAF_CARI_ID, colmINFAZ_TARIHI, colmHUKUM_KESINLESME_TARIHI, colmSORUMLULUK_MIKTARI, colmHUKUM_TEBLIG_TEFHIM_TARIHI, colmTEMYIZ_TIP_ID, colmYUKSEK_MAHKEME_GONDERIM_TARIHI, colmTEMYIZ_ADLI_BIRIM_ADLIYE_ID, colmTEMYIZ_ADLI_BIRIM_GOREV_ID, colmTEMYIZ_ADLI_BIRIM_NO_ID, colmTEMYIZ_ESAS_NO, colmTEMYIZ_KARAR_TARIHI, colmTEMYIZ_KARAR_NO, colmTEMYIZ_KARAR_TIP_ID, colmTEMYIZ_GEREKCE, colmTEMYIZ_TARAF_TEMYIZ_TARIHI, colmTEMYIZ_TARAF_CARI_ID, colmTEMYIZ_TARAF_USUL_NEDENLERI, colmTEMYIZ_TARAF_YASAL_NEDENLER, colmTEMYIZ_TARAF_ACIKLAMA, colmTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI, colmTEMYIZ_TARAF_TEDBIR_TARIHI, colmTEMYIZ_TARAF_TEDBIR_ACIKLAMASI, colmTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI, colmTEMYIZ_TEBLIG_TARIHI, colmTEFHIM_TARIHI, colmTEMYIZ_TARAF_SURE_TUTUM_TARIHI, colmDAVA_FOY_NO, colmDAVA_ADLI_BIRIM_ADLIYE_ID, colmDAVA_ADLI_BIRIM_GOREV_ID, colmDAVA_ADLI_BIRIM_NO_ID, colmDAVA_ESAS_NO, colmDAVA_TAKIP_T, colmDAVA_REFERANS_NO2, colmDAVA_REFERANS_NO3, colmDAVA_REFERANS_NO, colmDAVA_OZEL_KOD1, colmDAVA_OZEL_KOD2, colmDAVA_OZEL_KOD3, colmDAVA_OZEL_KOD4, colmDAVA_ASAMA_ID, colmDAVA_TALEP, colmDAVA_TARAF_KODU, colmDAVA_TARAF_CARI_ID, colmDAVA_TARAF_SIFAT_ID, colmSORUMLU_AVUKAT_CARI_ID, colmSORUMLU_TIP });

            grid.GroupSummary.AddRange(new[] { summaryDAVA_N_TUTAR_DOVIZ_ID, summaryDAVA_N_TUTAR, summaryDAVA_EDILEN_TUTAR_DOVIZ_ID, summaryDAVA_EDILEN_TUTAR, summaryISLAH_EDILEN_TUTAR_DOVIZ_ID, summaryISLAH_EDILEN_TUTAR, summaryPROTESTO_GIDERI_DOVIZ_ID, summaryPROTESTO_GIDERI, summaryIHTAR_GIDERI_DOVIZ_ID, summaryIHTAR_GIDERI, summaryDAVA_N_DIGER_GIDER_DOVIZ_ID, summaryDAVA_N_DIGER_GIDER, summarySORUMLU_OLUNAN_MIKTAR, summarySORUMLU_OLUNAN_MIKTAR_DOVIZ_ID, summaryHUKUM_DEGER, summaryHUKUM_DEGER_DOVIZ_ID, summaryMUSADERE_DEGER_DOVIZ_ID, summaryMUSADERE_DEGER, summaryPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID, summaryPARAYA_CEVRILEN_MIKTAR, summarySORUMLULUK_MIKTARI, summarySORUMLULUK_MIKTARI_DOVIZ_ID });
            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);
            gridRaporCntrol.DataSource = db.TEMYIZ_TAKIPs;

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();
        }

        private void YAPILACA_IS()
        {
            var colmKATEGORI_ID = colmnVer("KATEGORI ID", "KATEGORI_ID", true, 1, null);
            var colmYAPILACAK_IS = colmnVer("YAPILACAK IS", "YAPILACAK_IS", true, 2, null);
            var colmADLI_BIRIM_ADLIYE_ID = colmnVer("ADLI BIRIM ADLIYE ID", "ADLI_BIRIM_ADLIYE_ID", true, 3, TablesGrids.GetTDI_KOD_ADLI_BIRIM_ADLIYELookup());
            var colmADLI_BIRIM_GOREV_ID = colmnVer("ADLI BIRIM GOREV ID", "ADLI_BIRIM_GOREV_ID", true, 4, TablesGrids.GetTDI_KOD_ADLI_BIRIM_GOREVLookup());
            var colmADLI_BIRIM_NO_ID = colmnVer("ADLI BIRIM NO ID", "ADLI_BIRIM_NO_ID", true, 5, TablesGrids.GetTDI_KOD_ADLI_BIRIM_NOLookup());
            var colmESAS_NO = colmnVer("ESAS NO", "ESAS_NO", true, 6, null);
            var colmDURUM = colmnVer("DURUM", "DURUM", true, 7, null);
            var colmMUHASEBELESTIRILSIN_MI = colmnVer("MUHASEBELESTIRILSIN MI", "MUHASEBELESTIRILSIN_MI", true, 8, null);
            var colmHATIRLATILSIN_MI = colmnVer("HATIRLATILSIN MI", "HATIRLATILSIN_MI", true, 9, null);
            var colmAJANDADA_GORUNSUN_MU = colmnVer("AJANDADA GORUNSUN MU", "AJANDADA_GORUNSUN_MU", true, 10, null);
            var colmTIP = colmnVer("TIP", "TIP", true, 11, null);
            var colmBITIS_TARIHI = colmnVer("BITIS TARIHI", "BITIS_TARIHI", true, 12, null);
            var colmBASLANGIC_TARIHI = colmnVer("BASLANGIC TARIHI", "BASLANGIC_TARIHI", true, 13, null);
            var colmONGORULEN_BITIS_TARIHI = colmnVer("ONGORULEN BITIS TARIHI", "ONGORULEN_BITIS_TARIHI", true, 14, null);
            var colmONGORULEN_BITIS_ZAMANI = colmnVer("ONGORULEN BITIS ZAMANI", "ONGORULEN_BITIS_ZAMANI", true, 15, null);
            var colmYER = colmnVer("YER", "YER", true, 16, null);
            var colmKONU = colmnVer("KONU", "KONU", true, 17, null);
            var colmACIKLAMA = colmnVer("ACIKLAMA", "ACIKLAMA", true, 18, null);
            var colmSTATU = colmnVer("STATU", "STATU", true, 19, null);
            var colmIS_NO = colmnVer("IS NO", "IS_NO", true, 20, null);
            var colmONCELIK_ID = colmnVer("ONCELIK ID", "ONCELIK_ID", true, 21, TablesGrids.GetTDI_KOD_IS_ONCELIKLookup());
            var colmICRA_FOY_NO = colmnVer("ICRA FOY NO", "ICRA_FOY_NO", true, 22, null);
            var colmDAVA_FOY_NO = colmnVer("DAVA FOY NO", "DAVA_FOY_NO", true, 23, null);
            var colmHAZIRLIK_NO = colmnVer("HAZIRLIK NO", "HAZIRLIK_NO", true, 24, null);
            var colmRUCU_NO = colmnVer("RUCU NO", "RUCU_NO", true, 25, null);
            var colmBASLAMA_TARIH = colmnVer("BASLAMA TARIH", "BASLAMA_TARIH", true, 26, null);
            var colmBASLAMA_SAAT = colmnVer("BASLAMA SAAT", "BASLAMA_SAAT", true, 27, null);
            var colmONGORULEN_BITIS_TARIH = colmnVer("ONGORULEN BITIS TARIH", "ONGORULEN_BITIS_TARIH", true, 28, null);
            var colmONGORULEN_BITIS_SAAT = colmnVer("ONGORULEN BITIS SAAT", "ONGORULEN_BITIS_SAAT", true, 29, null);
            var colmBITIS_TARIH = colmnVer("BITIS TARIH", "BITIS_TARIH", true, 30, null);
            var colmBITIS_SAAT = colmnVer("BITIS SAAT", "BITIS_SAAT", true, 31, null);
            var colmCARI_ID = colmnVer("CARI ID", "CARI_ID", true, 32, TablesGrids.GetAV001_TDI_BIL_CARILookup());
            var colmIS_TARAF_ID = colmnVer("IS TARAF ID", "IS_TARAF_ID", true, 33, TablesGrids.GetTDI_KOD_IS_TARAFLookup());

            GridView grid = gridRaporCntrol.MainView as GridView;

            Connection conn = new Connection();
            DBDataContext db = new DBDataContext(conn.MyConnection);

            grid.Columns.AddRange(new[] { colmKATEGORI_ID, colmYAPILACAK_IS, colmADLI_BIRIM_ADLIYE_ID, colmADLI_BIRIM_GOREV_ID, colmADLI_BIRIM_NO_ID, colmESAS_NO, colmDURUM, colmMUHASEBELESTIRILSIN_MI, colmHATIRLATILSIN_MI, colmAJANDADA_GORUNSUN_MU, colmTIP, colmBITIS_TARIHI, colmBASLANGIC_TARIHI, colmONGORULEN_BITIS_TARIHI, colmONGORULEN_BITIS_ZAMANI, colmYER, colmKONU, colmACIKLAMA, colmSTATU, colmIS_NO, colmONCELIK_ID, colmICRA_FOY_NO, colmDAVA_FOY_NO, colmHAZIRLIK_NO, colmRUCU_NO, colmBASLAMA_TARIH, colmBASLAMA_SAAT, colmONGORULEN_BITIS_TARIH, colmONGORULEN_BITIS_SAAT, colmBITIS_TARIH, colmBITIS_SAAT, colmCARI_ID, colmIS_TARAF_ID });
            gridRaporCntrol.DataSource = db.R_YAPILACAK_ISLERs;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].FieldName.Contains("DOVIZ_ID"))
                {
                    grid.Columns[i].Caption = "BRM";
                }
                grid.Columns[i].VisibleIndex = -1;
            }

            Ayarla_Isimleri();
            ListeDoldur_Gruplananlar();
            ListeDoldur_TanimliAlanlar();

            //
        }

        #endregion Tablolar

        private void sl_BeforeSave(SaveList sender, string path)
        {
            if (BeforeSave != null)
            {
                this.BeforeSave(sender, path);
            }

            var sonuc = sl.Select(vi =>
                                   new GridMenuItem
                                   {
                                       GrubDegeri = "Diger",
                                       Grubu = vi.Grubu,
                                       AcilacakPencereDegeri = "KulTanimli_Icra",

                                       //ModulDegeri = GridMenuItem.Modul.Icra,
                                       ModulDegeri = "Icra",
                                       TipDegeri = GridMenuItem.Tip.KullaniciTanimli,
                                       Adi = vi.ReportName
                                   });

            frmMain mainForm = (frmMain)this.MdiParent;
            mainForm.gridMenu.DataSource = sonuc.ToList();
        }

        //public  ParaVeDovizId Toplaa(List<ParaVeDovizId> paralar)
        //{
        //    ParaVeDovizId result = new ParaVeDovizId(0, 1);//0 YTL
        //    Dictionary<int, decimal> sonuclar = new Dictionary<int, decimal>();
        //    List<TDI_KOD_DOVIZ_TIP> paraTipleri = new DBDataContext().TDI_KOD_DOVIZ_TIPs.ToList(); ;  // DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll();
        //    foreach (DovizTip dTip in Enum.GetValues(typeof(DovizTip)))
        //    {
        //        if (dTip > 0)
        //        {
        //            sonuclar.Add((int)dTip, 0);
        //        }
        //    }
    }
}