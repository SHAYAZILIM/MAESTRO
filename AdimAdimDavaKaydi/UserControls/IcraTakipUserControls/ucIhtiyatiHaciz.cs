using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucIhtiyatiHaciz : AvpXUserControl
    {
        private TList<AV001_TI_BIL_IHTIYATI_HACIZ> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucIhtiyatiHaciz()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucIhtiyatiHaciz_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_IHTIYATI_HACIZ> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    MyDataSource = value.AV001_TI_BIL_IHTIYATI_HACIZCollection;
                }
            }
        }

        public void BindData()
        {
            if (MyDataSource == null) return;
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            MyDataSource.AddingNew += MyDataSource_AddingNew;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0 && MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_IHTIYATI_HACIZ>));
                _MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                LoadInitsData();
                gridIhtiyatiHaciz.DataSource = MyDataSource;
            }
        }

        private void frm_KayitYapildi(object sender, IhtiyatiHacizEventArgs e)
        {
            if (e.MyIhtHcz != null)
                MyDataSource.Add(e.MyIhtHcz);
        }

        private void gridIhtiyatiHaciz_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: Form açýldýðýnda kayýt ekle butonuna týklamadan varsayýlan bilgileri getiriyor. Kayýt ekle butonuna týklandýðýnda getirmeli.
                //UNDONE: Kaydetme iþlemi baþarýsýz.
                frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();

                //frm.MdiParent = null;
                TList<AV001_TI_BIL_FOY_TARAF> taraf = MyFoy.AV001_TI_BIL_FOY_TARAFCollection;
                frm.MyFoy = MyFoy;
                frm.KayitYapildi += frm_KayitYapildi;
                frm.MyDataSource = null;

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwIhtiyatiHaciz.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                frmIcraIhtiyatiHaciz frm = new frmIcraIhtiyatiHaciz();
                frm.MyFoy = MyFoy;
                frm.MyDataSource = MyFoy.AV001_TI_BIL_IHTIYATI_HACIZCollection;

                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                #endregion <AC - 20090614>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwIhtiyatiHaciz.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                AV001_TI_BIL_IHTIYATI_HACIZ icra = gwIhtiyatiHaciz.GetFocusedRow() as AV001_TI_BIL_IHTIYATI_HACIZ;
                string Foy_no = icra.ESAS_NO;
                frmKayitSil kayitSil = new frmKayitSil("AV001_TI_BIL_IHTIYATI_HACIZ", "ID = " + icra.ID);
                if (kayitSil.ShowDialog() == DialogResult.OK)
                {
                    XtraMessageBox.Show(Foy_no + " 'nolo Kayit Silinmiþtir");
                }

                #endregion <AC - 20090614>
            }
        }

        private void LoadInitsData()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                BelgeUtil.Inits.DovizTipGetir(rLueTeminatDovizTipiID);
                BelgeUtil.Inits.TeminatTuruGetir(rLueTeminatTurID);
                BelgeUtil.Inits.TarafKoduGetir(rLueTarafKodu);
                BelgeUtil.Inits.TarafSifatGetir(rLueTarafSifat);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueSonucId);

                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            LoadInitsData();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData();
        }

        private void ucIhtiyatiHaciz_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}