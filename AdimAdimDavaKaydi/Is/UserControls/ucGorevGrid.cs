using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Is.Forms;
using AdimAdimDavaKaydi.Properties;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;

namespace AdimAdimDavaKaydi.Is.UserControls
{
    public partial class ucGorevGrid : AvpXUserControl
    {
        //Klasör ekranýndan iþ kaydý yapýldýðýnda -1'den farklý deðer gelecek.
        public int KlasorID = -1;

        public bool ViewDegisti;

        private TList<AV001_TDI_BIL_IS> _MyDataSource;

        private VList<per_Yapilacak_Is_Arama_Detay> _MyDataSourceView;

        private bool allowInsert;

        private int foyId;

        private int? FoySorumluId;

        private IEntity selectedrecord;

        public ucGorevGrid()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucGorevler_Load;
        }

        public delegate void OnSaved(IList Records, IEntity Record);

        public event EventHandler<EventArgs> DataSourceVerildi;

        public event OnSaved Saved;

        public bool AllowInsert
        {
            get { return allowInsert; }
            set
            {
                allowInsert = value;
                if (IsLoaded)
                {
                    if (value)
                    {
                        ((GridView)this.gcGorev.MainView).OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    }
                    else
                    {
                        ((GridView)this.gcGorev.MainView).OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                }
            }
        }

        //private DevExpress.XtraBars.Docking.DockVisibility aramaDockPanel = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        [Browsable(false)]
        public DevExpress.XtraBars.Docking.DockVisibility AramaDockPanel
        {
            get
            {
                if (DesignMode) return DevExpress.XtraBars.Docking.DockVisibility.Visible;

                if (dockArama.Visibility != null)
                    return dockArama.Visibility;
                else
                    return DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
            set
            {
                if (dockArama != null && dockArama.Parent != null && !this.DesignMode)
                {
                    dockArama.Visibility = value;
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_IS> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (ViewDegisti == false)
                {
                    if (IsLoaded)
                        BindData();
                }
            }
        }

        [Browsable(false)]
        public VList<per_Yapilacak_Is_Arama_Detay> MyDataSourceView
        {
            get { return _MyDataSourceView; }
            set
            {
                _MyDataSourceView = value;
                if (ViewDegisti)
                {
                    if (IsLoaded)
                        BindData();
                }
            }
        }

        [Browsable(false)]
        public IEntity SelectedRecord
        {
            get { return selectedrecord; }
            set
            {
                selectedrecord = value;
                if (IsLoaded)
                    SetSelectedRecord();
            }
        }

        [Browsable(false)]
        public int SelectedRecordId { get; set; }

        public bool ShowKayitEkranOnDoubleClick { get; set; }

        public void BindData()
        {
            if (MyDataSource == null && MyDataSourceView == null) return;

            if (ViewDegisti)
            {
                setViewGird();
            }
            else
            {
                setDefaultGrid();
            }
            if (MyDataSource != null)
            {
                if (!DesignMode && _MyDataSource != null && IsLoaded)
                {
                    _MyDataSource.AddingNew += value_AddingNew;
                }
                gcGorev.DataSource = _MyDataSource;
                extendedGridControl1.DataSource = _MyDataSource;
            }
            else
            {
                gcGorev.DataSource = MyDataSourceView;
            }
            if (DataSourceVerildi != null)
                DataSourceVerildi(gcGorev.DataSource, new EventArgs());
        }

        public void SagTusaEkle()
        {
            gcGorev.RightClickPopup.LinkPersist = new DevExpress.XtraBars.LinksInfo();
            foreach (DevExpress.XtraBars.LinkPersistInfo var in popupMenu1.LinksPersistInfo)
            {
                gcGorev.RightClickPopup.LinkPersist.Add(var);
            }
        }

        public bool SaveAll()
        {
            if (DesignMode) return false;
            if (MyDataSource == null) return true;
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TDI_BIL_ISProvider.DeepSave((MyDataSource), DeepSaveType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_IS_TARAF>),
                                                                 typeof(TList<AV001_TDI_BIL_IS_TAMAMLANMA_SURE>));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }

        public void SetSelectedRecord()
        {
            if (SelectedRecord != null)
                switch (SelectedRecord.TableName)
                {
                    case "AV001_TI_BIL_FOY":
                        ucIsKayitUfak1.ModulID = 1;
                        break;

                    case "AV001_TD_BIL_FOY":
                        ucIsKayitUfak1.ModulID = 2;
                        break;

                    case "AV001_TD_BIL_HAZIRLIK":
                        ucIsKayitUfak1.ModulID = 3;
                        break;

                    case "AV001_TDI_BIL_SOZLESME":
                        ucIsKayitUfak1.ModulID = 5;
                        break;
                    default:
                        break;
                }
            if (SelectedRecord == null || DesignMode)
            {
                return;
            }
            TList<AV001_TDI_BIL_IS> lstIsler = new TList<AV001_TDI_BIL_IS>();

            //TODO : Hatalý Dizin Aralýk Dýþýndaydý ...
            // lstIsler.Add( RecordGenerator.Generate.GenerateAV001_TDI_BIL_ISByRecord(value) );

            #region <KA-20090618>

            // aþaðýdaki kod yeni iþ kaydý ekranýnýn datasource si boþ olamsý gerekirken deðer atýyordu iptal edildi.

            #endregion <KA-20090618>

            //this.ucIsKayitUfak1.MyDataSource = lstIsler;
            ucIsKayitUfak1.OpenedRecord = SelectedRecord;
            if (SelectedRecord is AV001_TI_BIL_FOY)
            {
                if (((AV001_TI_BIL_FOY)SelectedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count <= 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(((AV001_TI_BIL_FOY)SelectedRecord), false,
                                                                     DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                {
                    foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                    FoySorumluId =
                        ((AV001_TI_BIL_FOY)SelectedRecord).AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection[0].
                            SORUMLU_AVUKAT_CARI_ID;
                    ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                    ucIsKayitUfak1.Modul = 1;
                }
            }
        }

        private void AV001_TDI_BIL_IS_TARAFCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IS_TARAF addNewIsTaraf = new AV001_TDI_BIL_IS_TARAF();
            addNewIsTaraf.KAYIT_TARIHI = DateTime.Now;
            addNewIsTaraf.KLASOR_KODU = "GENEL";
            addNewIsTaraf.KONTROL_KIM = "AVUKATPRO";
            addNewIsTaraf.KONTROL_NE_ZAMAN = DateTime.Now;
            addNewIsTaraf.KONTROL_VERSIYON = 1;
            addNewIsTaraf.STAMP = 1;
            addNewIsTaraf.SUBE_KODU = 1;
            e.NewObject = addNewIsTaraf;
        }

        private void AV001_TDIE_BIL_ASAMACollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDIE_BIL_ASAMA addNewAsama = new AV001_TDIE_BIL_ASAMA();
            addNewAsama.KAYIT_TARIHI = DateTime.Now;
            addNewAsama.KLASOR_KODU = "GENEL";
            addNewAsama.KONTROL_KIM = "AVUKATPRO";
            addNewAsama.KONTROL_NE_ZAMAN = DateTime.Now;
            addNewAsama.KONTROL_VERSIYON = 1;
            addNewAsama.STAMP = 1;
            addNewAsama.SUBE_KODU = 1;
            e.NewObject = addNewAsama;
        }

        private void barBtnSecimiKaldir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                int cariId = (int)e.Item.Tag;

                AV001_TDI_BIL_CARI cari = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(cariId);
                AdimAdimDavaKaydi.frmCariGenelGiris cariForms = new frmCariGenelGiris();
                cariForms.YeniKayitMi = false;
                cariForms.MyCariId = cariId;
                cariForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                cariForms.Show();
            }
        }

        private void gcGorev_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gcGorev.Visible)
            {
                extendedGridControl1.Visible = true;
                gcGorev.Visible = false;
            }
            else
            {
                extendedGridControl1.Visible = false;
                gcGorev.Visible = true;
            }
        }

        private void gcGorev_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                #region <cc-20090723>

                // forum patlýyacaðý için kapatýlmýþtýr
                //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                frmisKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;
                if (SelectedRecord != null)
                    switch (SelectedRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            frmisKayit.ucIsKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            frmisKayit.ucIsKayitUfak1.ModulID = 5;
                            break;
                        default:
                            break;
                    }
                frmisKayit.ucIsKayitUfak1.OpenedRecord = SelectedRecord;
                if (SelectedRecord is AV001_TI_BIL_FOY)
                {
                    if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                    {
                        foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                        frmisKayit.ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                    }
                }

                #region <MB-20102701>

                //Klasör ekranýndan iþ kaydý yapýlmak istendiðinde, seçili klasörün kayýt ekranýnda default gelmesi için eklendi.
                frmisKayit.ucIsKayitUfak1.KlasorID = KlasorID;

                #endregion <MB-20102701>

                //frmisKayit.MdiParent = null;
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;

                frmisKayit.Show();

                #endregion <cc-20090723>
            }
            else if (e.Button.Tag.ToString() == "KaydiDuzenle")
            {
                AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                frmisKayit.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;
                if (SelectedRecord != null)
                    switch (SelectedRecord.TableName)
                    {
                        case "AV001_TI_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 1;
                            break;

                        case "AV001_TD_BIL_FOY":
                            frmisKayit.ucIsKayitUfak1.ModulID = 2;
                            break;

                        case "AV001_TD_BIL_HAZIRLIK":
                            frmisKayit.ucIsKayitUfak1.ModulID = 3;
                            break;

                        case "AV001_TDI_BIL_SOZLESME":
                            frmisKayit.ucIsKayitUfak1.ModulID = 5;
                            break;
                        default:
                            break;
                    }
                frmisKayit.ucIsKayitUfak1.OpenedRecord = SelectedRecord;
                frmisKayit.Record = gvIsTaraf.GetFocusedRow() as AV001_TDI_BIL_IS;
                if (SelectedRecord is AV001_TI_BIL_FOY)
                {
                    if (((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.HasValue)
                    {
                        foyId = ((AV001_TI_BIL_FOY)SelectedRecord).ID;
                        frmisKayit.ucIsKayitUfak1.formTipi = ((AV001_TI_BIL_FOY)SelectedRecord).FORM_TIP_ID.Value;
                        frmisKayit.ucIsKayitUfak1.Modul = 1;
                    }
                }
                frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmisKayit.Show();
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender,
                                                       DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AJANDADA_GORUNSUN_MU")
            {
                if ((bool)e.Value)
                {
                    e.Value = Resources.ajanda22x22;
                }
                else
                {
                    e.Value = Resources.yukari;
                }
            }
        }

        private void initData()
        {
            if (DesignMode)
            {
                return;
            }
            try
            {
                if (MyDataSource == null)
                {
                    MyDataSource = new TList<AV001_TDI_BIL_IS>();
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(MyDataSource, true, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TDI_BIL_IS_TARAF>));
                    gcGorev.DataSource = MyDataSource;
                    extendedGridControl1.DataSource = MyDataSource;
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            if (MyDataSource != null)
            {
                (MyDataSource).AddingNew += MyDataSourceDeep_AddingNew;
            }

            RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
            memoEdit.WordWrap = true;
            gcGorev.RepositoryItems.Add(memoEdit);
            gvIsTaraf.Columns["YAPILACAK_IS"].ColumnEdit = memoEdit;
            gvIsTaraf.OptionsView.RowAutoHeight = false;
        }

        private void MyDataSourceDeep_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_IS addNewIS = new AV001_TDI_BIL_IS();
            addNewIS.KAYIT_TARIHI = DateTime.Now;
            addNewIS.KLASOR_KODU = "GENEL";
            addNewIS.KONTROL_KIM = "AVUKATPRO";
            addNewIS.KONTROL_NE_ZAMAN = DateTime.Now;
            addNewIS.KONTROL_VERSIYON = 1;
            addNewIS.STAMP = 1;
            addNewIS.TIP = 0;
            addNewIS.SUBE_KODU = 1;
            addNewIS.REFERANS_NO = DateTime.Now.Ticks.ToString();
            e.NewObject = addNewIS;
            addNewIS.AV001_TDI_BIL_IS_TARAFCollection = new TList<AV001_TDI_BIL_IS_TARAF>();
            addNewIS.AV001_TDI_BIL_IS_TARAFCollection.AddingNew += AV001_TDI_BIL_IS_TARAFCollection_AddingNew;
            addNewIS.STAMP = 0;

            if (selectedrecord is AV001_TI_BIL_FOY)
            {
                //TODO : isin icrasý
                NN_IS_ICRA_FOY isinIcrasi = new NN_IS_ICRA_FOY();
                isinIcrasi.ICRA_FOY_ID = ((AV001_TI_BIL_FOY)selectedrecord).ID;

                addNewIS.NN_IS_ICRA_FOYCollection.Add(isinIcrasi);

                Is.UserControls.IS issim = new Is.UserControls.IS();
                issim.Kayit = (selectedrecord);
                issim.Table = ((AV001_TI_BIL_FOY)selectedrecord).TableName;
                issim.KayitID = ((AV001_TI_BIL_FOY)selectedrecord).ID;
                issim.IsKaydi = addNewIS;
                issim.ModulesTable = "AV001_TI_BIL_FOY";

                issim.ConvertRecordToIs(issim.Kayit);
                for (int i = 0; i < ((AV001_TI_BIL_FOY)selectedrecord).AV001_TI_BIL_FOY_TARAFCollection.Count; i++)
                {
                    addNewIS.AV001_TDI_BIL_IS_TARAFCollection.Add(
                        issim.ConvertTarafToIsTaraf(
                            ((AV001_TI_BIL_FOY)selectedrecord).AV001_TI_BIL_FOY_TARAFCollection[i]));
                }
            }

            addNewIS.AV001_TDIE_BIL_ASAMACollection = new TList<AV001_TDIE_BIL_ASAMA>();
            addNewIS.AV001_TDIE_BIL_ASAMACollection.AddingNew += AV001_TDIE_BIL_ASAMACollection_AddingNew;
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Name == bBtnSorusturmaEkle.Name)
                {
                    AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris frmSorusturma =
                        new AdimAdimDavaKaydi.Sorusturma.Forms.rfrmSorusturmaGiris();
                    frmSorusturma.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmSorusturma.Show();
                }
                else if (e.Item.Name == bBtnIcraEkle.Name)
                {
                    AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit frmicraDosyaKayit =
                        new AdimAdimDavaKaydi.Forms.Icra.frmIcraDosyaKayit();
                    frmicraDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmicraDosyaKayit.Show();
                }
                else if (e.Item.Name == bBtnSozlesmeEkle.Name)
                {
                    AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit frmsozlesmeKayit =
                        new AdimAdimDavaKaydi.Sozlesme.Forms.frmSozlesmeKayit();
                    frmsozlesmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmsozlesmeKayit.Show();
                }
                else if (e.Item.Name == bBSahis.Name)
                {
                    frmCariGenelGiris cGiris = new frmCariGenelGiris();
                    cGiris.YeniKayitMi = true;
                    cGiris.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cGiris.Show();
                }
                else if (e.Item.Name == bBTemsilEkle.Name)
                {
                    frmTemsilKayit tKayit = new frmTemsilKayit();
                    tKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    tKayit.Show();
                }
                else if (e.Item.Name == bBtnDavaEkle.Name)
                {
                    AdimAdimDavaKaydi.frmDavaDosyaKayitForm frmdavaDosyaKayit = new frmDavaDosyaKayitForm();
                    frmdavaDosyaKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frmdavaDosyaKayit.Show();
                }
                else if (e.Item.Name == bButonBelgeEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_IS)
                    {
                        AV001_TDI_BIL_IS takip = e.Item.Tag as AV001_TDI_BIL_IS;
                        string tablob = "AV001_TDI_BIL_IS";
                        bool islemYap = true;
                        if (islemYap)
                        {
                            if (takip.ID != null)
                            {
                                frmBelgeKayitUfak belgeKayit = new frmBelgeKayitUfak();
                                belgeKayit.SetByTableNameAndId(tablob, takip.ID);
                                belgeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                                belgeKayit.Show();
                            }
                        }
                    }
                }
                else if (e.Item.Name == bButonIsEkle.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_IS)
                    {
                        AV001_TDI_BIL_IS takip = e.Item.Tag as AV001_TDI_BIL_IS;
                        string tabloI = "AV001_TDI_BIL_IS";
                        frmIsKayitUfak frmisKayit = new frmIsKayitUfak();
                        frmisKayit.SetByTableNameAndId(tabloI, takip.ID);
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                    }
                }
                else if (e.Item.Name == barButtonItem4.Name)
                {
                    if (e.Item.Tag is AV001_TDI_BIL_IS)
                    {
                        AV001_TDI_BIL_IS secilenIs = e.Item.Tag as AV001_TDI_BIL_IS;
                        frmIsSureOlcer SureOlcer = new frmIsSureOlcer();
                        SureOlcer.SorumluCariId = FoySorumluId.Value;
                        DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(secilenIs, false, DeepLoadType.IncludeChildren,
                                                                         typeof(TList<AV001_TDIE_BIL_PROJE_IS>));
                        TList<AV001_TDIE_BIL_PROJE_IS> myProje =
                            DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByIS_ID(secilenIs.ID);

                        if (myProje.Count > 0)
                        {
                            myProje[0].PROJE_IDSource =
                                DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID(myProje[0].PROJE_ID);
                            SureOlcer.projeadi = myProje[0].PROJE_IDSource.ADI;
                        }
                        SureOlcer.MyIs = secilenIs;
                        SureOlcer.Show();
                    }
                }
                else if (e.Item.Name == bButtonNotEkle.Name)
                {
                    //if (e.Item.Tag is AV001_TDI_BIL_IS)
                    //{
                    //    AV001_TDI_BIL_IS takip = e.Item.Tag as AV001_TDI_BIL_IS;
                    //    bool islemYap = true;
                    //    if (takip.ID != null && islemYap)
                    //    {
                    //        string tabloB = "AV001_TDI_BIL_IS";
                    //        AdimAdimDavaKaydi.CustomControls.frmYeniNot d = new AdimAdimDavaKaydi.CustomControls.frmYeniNot();
                    //        d.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    //        d.ShowDialog(tabloB, takip.ID);
                    //    }
                    //}
                }
                else if (e.Item.Name == bButtonGorusmeEkle.Name)
                {
                    bool islemYap = true;
                    if (e.Item.Tag is AV001_TDI_BIL_IS)
                    {
                        AV001_TDI_BIL_IS takip = e.Item.Tag as AV001_TDI_BIL_IS;
                        if (!islemYap)
                            return;

                        AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit gorsumeForms =
                            new AdimAdimDavaKaydi.Forms.rFrmGorusmeKayit();
                        gorsumeForms.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        gorsumeForms.ShowDialog(AvukatProLib.Extras.ModulTip.YapilacakIsler,
                                                takip.ID);
                    }
                }
            }
            else if (e.Item.Name == bButtonSikKullanilan.Name)
            {
                if (e.Item.Tag is AV001_TDI_BIL_IS)
                {
                    AV001_TDI_BIL_IS takip = e.Item.Tag as AV001_TDI_BIL_IS;
                    DataRepository.AV001_TDI_BIL_ISProvider.DeepLoad(takip, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<TDI_KOD_ADLI_BIRIM_ADLIYE>),
                                                                     typeof(TList<TDI_KOD_ADLI_BIRIM_GOREV>),
                                                                     typeof(TList<TDI_KOD_ADLI_BIRIM_NO>));
                    AvukatProLib.Extras.ModulTip tablo =
                        AvukatProLib.Extras.ModulTip.Tebligat;
                    string adliye = string.Empty;
                    string gorev = string.Empty;
                    string no = string.Empty;
                    if (takip.ADLI_BIRIM_ADLIYE_IDSource != null)
                        adliye = takip.ADLI_BIRIM_ADLIYE_IDSource.ADLIYE;
                    if (takip.ADLI_BIRIM_GOREV_IDSource != null)
                        gorev = takip.ADLI_BIRIM_GOREV_IDSource.GOREV;
                    if (takip.ADLI_BIRIM_NO_IDSource != null)
                        no = takip.ADLI_BIRIM_NO_IDSource.NO;
                    string AD = string.Format("{0} {1} {2} {3} E. nolu Dosyasý", adliye, gorev, no, takip.ESAS_NO);
                    rfrmSikKullanilanEkle frm = new rfrmSikKullanilanEkle();
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.ShowDialog(tablo, takip.ID, AD);
                }
            }
        }

        private void RightClickPopup_PopupOpened(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            e.MyPopupMenu.ItemLinks[0].Visible = false;
            e.MyPopupMenu.ItemLinks[1].Visible = false;
            e.MyPopupMenu.ItemLinks[2].Visible = false;
        }

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "CARI_ID")
            {
                BarSubItem bus = new BarSubItem(e.Manager, "Bu Kiþinin");
                BarButtonItem barBtnSecimiKaldir = new BarButtonItem(e.Manager, "Adres ve Ýletiþim Bilgileri");
                bus.ItemLinks.Add(barBtnSecimiKaldir);

                AV001_TDI_BIL_IS_TARAF secim = e.Rows as AV001_TDI_BIL_IS_TARAF;

                int? id = secim.CARI_ID;
                if (id.HasValue)
                {
                    barBtnSecimiKaldir.Tag = id.Value;
                }
                barBtnSecimiKaldir.ItemClick += barBtnSecimiKaldir_ItemClick;
                e.MyPopupMenu.ItemLinks.Insert(0, bus);
            }
        }

        private void setDefaultGrid()
        {
            this.gcGorev.ViewCollection.Clear();
            this.gcGorev.MainView = this.gvIsTaraf;
            this.gcGorev.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[]
                                                     {
                                                         this.gridView2,
                                                         this.gvIsTaraf,
                                                         this.cardView1
                                                     });
        }

        private void setViewGird()
        {
            this.gcGorev.ViewCollection.Clear();
            this.gcGorev.MainView = this.grdViewYapilacakIsDetayli;
            this.gcGorev.ViewCollection.Add(grdViewYapilacakIsDetayli);
        }

        private void ucGorevGrid_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            AV001_TDI_BIL_IS isValidate = ((AV001_TDI_BIL_IS)e.Row);
            if (isValidate.BASLANGIC_TARIHI >= isValidate.BITIS_TARIHI)
            {
                e.Valid = false;

                //TODO :  mesaj kayýttan okunucak
                e.ErrorText = "Baslangýc Tarihi Bitiþ Tarihinden Küçük veya Eþit Olmalýdir";
            }

            if (isValidate.KONU == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "Konu Deðeri Boþ Geçilmemelidir";
            }
            if (isValidate.YAPILACAK_IS == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "Yapýlacak Ýþ Deðeri Boþ Geçilmemelidir";
            }

            if (isValidate.YER == string.Empty)
            {
                e.Valid = false;
                e.ErrorText = "Yer Deðeri Boþ Geçilmemelidir";
            }

            this.SaveAll();
        }

        private void ucGorevler_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            gcGorev.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
            gcGorev.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
            gcGorev.RightClickPopup.PopupOpened += RightClickPopup_PopupOpened;
            IsLoaded = true;
            ((GridView)this.gcGorev.MainView).OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gvIsTaraf.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
            this.repositoryItemPictureEdit1.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;

            initData();
            gcGorev.ShowOnlyPredefinedDetails = true;

            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.IsTarafGetir(rLueIsTarafID);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(rLueMuhasebeID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
            BelgeUtil.Inits.MuhasebeHareketAltKategoriGetir(rlueICmb);
            BelgeUtil.Inits.IsSurecGetir(rLueIsSurecID);
            BelgeUtil.Inits.ModulGetir(rLueModulID);
            BelgeUtil.Inits.IsOncelikGetir(rLueGorevOncelik);
            BelgeUtil.Inits.IsOncelikGetir(rLueIsOncelikID);

            gcGorev.ButtonCevirClick += gcGorev_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += gcGorev_ButtonCevirClick;

            ((GridView)gcGorev.MainView).ValidateRow += ucGorevGrid_ValidateRow;
            if (this.MyDataSource == null)
            {
                this.MyDataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_ISProvider.GetAll();
            }

            this.ucIsKayitUfak1.Saved += ucIsKayitUfak1_Saved;

            SagTusaEkle();

            #region Arama Kontrolleri (gkn)

            btnAra.Click += btnAra_Click;
            xtraTabControl1.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
            Taraflar();
            Sorumlular();
            if (AllowInsert)
            {
                ((GridView)this.gcGorev.MainView).OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            }
            else
            {
                ((GridView)this.gcGorev.MainView).OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }

            BindData();
            SetSelectedRecord();

            #endregion Arama Kontrolleri (gkn)
        }

        private void ucIsKayitUfak1_Saved(System.Collections.IList Records, IEntity Record)
        {
            if (DesignMode)
            {
                return;
            }
            if (this.Saved != null)
                this.Saved(Records, Record);
        }

        #region Arama Dock Bar (gkn)

        private ImageList myImageList = new ImageList();

        private DataTable _ProjeTable
        {
            get
            {
                DataTable result = new DataTable("Asama");
                result.Columns.Add("ADI");
                return result;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            if (txtArama.Text == string.Empty) AsamaDoldur(null);

            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf taraf =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf)
                rgTaraf.Properties.Items.GetItemIndexByValue(rgTaraf.SelectedIndex);
            AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur tur =
                (AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur)
                rgTur.Properties.Items.GetItemIndexByValue(rgTur.SelectedIndex);

            AramaYap(taraf, tur);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            if (e.Page == tabArama)
            {
                splitContainerControl1.Panel2.Controls.Add(pnTreeList);
            }
            else if (e.Page == tabAsamalar)
            {
                tabAsamalar.Controls.Add(pnTreeList);
            }
        }

        #region methodlar

        private void AramaYap(AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf secTaraf,
                              AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur secTur)
        {
            if (DesignMode)
            {
                return;
            }
            TList<TDIE_KOD_ASAMA> asamaList = new TList<TDIE_KOD_ASAMA>();
            TList<TDIE_KOD_ASAMA_ALT> altAsamaList = new TList<TDIE_KOD_ASAMA_ALT>();

            if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AnaAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByMahkemeMi(txtArama.Text, true);
                }

                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    asamaList = DataRepository.TDIE_KOD_ASAMAProvider.AnaAsamaBulByTumu(txtArama.Text);
                }
            }

            else if (secTur == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTur.AltAsama)
            {
                if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Karsi)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "K");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Muvekkil)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTaraf(txtArama.Text, "M");
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Mudurluk)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByMahkemeMi(txtArama.Text, true);
                }
                else if (secTaraf == AdimAdimDavaKaydi.GirisEkran.rFrmIcraGirisEkran.AsamaTaraf.Tumu)
                {
                    altAsamaList = DataRepository.TDIE_KOD_ASAMA_ALTProvider.AltAsamaBulByTumu(txtArama.Text);
                }
            }

            AsamaDoldur(asamaList);

            if (asamaList.Count == 0)
            {
                XtraMessageBox.Show("Aradýðýnýz kriterlere uyan aþama bulunamadý.", "Arama Sonucu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                this.MyDataSource = null;
                this.MyDataSource = new TList<AV001_TDI_BIL_IS>();
            }

            tlIcraAsamalar.Nodes.TreeList.ExpandAll();
        }

        private void AsamaDoldur(TList<TDIE_KOD_ASAMA> asamaList)
        {
            if (DesignMode)
            {
                return;
            }

            if (asamaList == null)
                asamaList = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(1);

            //TList<TDIE_KOD_ASAMA> asamalar = DataRepository.TDIE_KOD_ASAMAProvider.GetByASAMA_MODUL_ID(1);
            DataRepository.TDIE_KOD_ASAMAProvider.DeepLoad(asamaList, true, DeepLoadType.IncludeChildren,
                                                           typeof(TList<TDIE_KOD_ASAMA_ALT>));

            asamaList.Sort("SIRA_NO ASC");

            tlIcraAsamalar.Nodes.Clear();
            foreach (TDIE_KOD_ASAMA asama in asamaList)
            {
                TreeListNode tn = tlIcraAsamalar.AppendNode(dataRowYap(asama.ASAMA_ADI), null);
                tn.Tag = asama;
                if (asama.SIMGE != null)
                {
                    Image img = Image.FromStream(new System.IO.MemoryStream(asama.SIMGE));
                    int imgYeri = myImageList.Images.Add(img, Color.Transparent);

                    tn.StateImageIndex = imgYeri;
                }

                asama.TDIE_KOD_ASAMA_ALTCollection.Sort("SIRA_NO ASC");

                foreach (TDIE_KOD_ASAMA_ALT altAsama in asama.TDIE_KOD_ASAMA_ALTCollection)
                {
                    TreeListNode tn2 = tlIcraAsamalar.AppendNode(dataRowYap(altAsama.ALT_ASAMA_ADI), tn, altAsama);
                    tn2.Tag = altAsama;

                    if (altAsama.SIMGE != null)
                    {
                        Image img2 = Image.FromStream(new System.IO.MemoryStream(altAsama.SIMGE));
                        int imgYeri2 = myImageList.Images.Add(img2, Color.Transparent);
                        tn2.StateImageIndex = imgYeri2;
                    }
                }
            }
        }

        private DataRow dataRowYap(string adi)
        {
            DataRow dr = _ProjeTable.NewRow();
            dr["ADI"] = adi;
            return dr;
        }

        private void Sorumlular()
        {
            return;
          
        }

        private void Taraflar()
        {
            return;
           
        }

        #endregion methodlar

        #endregion Arama Dock Bar (gkn)

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            frmIsKayitUfak isKayit = new frmIsKayitUfak();
            isKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
            isKayit.Show();
        }
    }
}