using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucMalBeyani : AvpXUserControl
    {
        private TList<AV001_TI_BIL_MAL_BEYANI> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucMalBeyani()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMalBeyani_Load;
        }

        [Description("Görünümü deðiþtirir.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ViewType MView { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_MAL_BEYANI> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
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
                    MyDataSource = value.AV001_TI_BIL_MAL_BEYANICollection;
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
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_MAL_BEYANI>));
                _MyDataSource = MyFoy.AV001_TI_BIL_MAL_BEYANICollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                LoadInitsData();
                grdMalBeyani.DataSource = MyDataSource;
                dnMalBeyani.DataSource = MyDataSource;
                vGMalBeyani.DataSource = MyDataSource;
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }

        private void grdMalBeyani_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmMalBeyani frm = new frmMalBeyani();

                // frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;

                //UNDONE: Form açýldýðýnda kayýtlarý listeliyor. Yeni bir kayýt eklemek için boþ form getirmeli.
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.Show(MyFoy);
                frm.FormClosed += frm_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwMalBeyan.GetFocusedRow() != null)
            {
                #region <AC - 20090613>

                // Seçilen kaydý düzenle.
                //UNDONE: Form açýldýðýnda kayýtlarý listeliyor. Sadece seçilen kaydýn gelmesi gerek.
                frmMalBeyani frm = new frmMalBeyani();
                frm.Text = "Mal Beyaný Bilgileri Düzenleme Formu";
                frm.result = MyDataSource;
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.Show(MyFoy);

                #endregion <AC - 20090613>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwMalBeyan.GetFocusedRow() != null)
            {
                #region <AC - 20090613>

                // Seçilen kaydý sil.
                // AV001_TI_BIL_MAL_BEYANI Database Delete Cascade kontrolü yapýldý.
                if (
                    XtraMessageBox.Show(
                        string.Format("Seçilen kayýt silinsin mi?{0}Bu kayda baðlý kayýtlar varsa tamamý silinecek.",
                                      Environment.NewLine), "Kayýt Sil", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MyDataSource.Remove((AV001_TI_BIL_MAL_BEYANI)gwMalBeyan.GetFocusedRow()))
                        XtraMessageBox.Show("Kayýt baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Kayýt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion <AC - 20090613>
            }
        }

        private void LoadInitsData()
        {
            if (!initsFilled)
            {
                BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rLueCariID });
                BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
                BelgeUtil.Inits.IlceGetirOzetli(rLueIlce);
                BelgeUtil.Inits.IlGetir(rLueIl);
                BelgeUtil.Inits.UlkeGetir(rLueUlke);
                BelgeUtil.Inits.BirimKodGetir(rLueMalBirim);
                BelgeUtil.Inits.MalKategoriResimliGetir(rLueKategori);
                BelgeUtil.Inits.MalTurGetir(rLueMalTuru);
                BelgeUtil.Inits.MalcinsGetir(rLueMalCinsi);

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

        private void ucMalBeyani_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            grdMalBeyani.ShowOnlyPredefinedDetails = true;

            if (BelgeUtil.Inits._MalcinsGetir == null)
            {
                BelgeUtil.Inits._MalcinsGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.GetAll();
            }
            rGLueMallar.DataSource = BelgeUtil.Inits._MalcinsGetir;
            rGLueMallar.DisplayMember = "CINS";
            rGLueMallar.ValueMember = "ID";

            BindData();

            if (MView == ViewType.GridView)
            {
                panelControl1.Visible = false;
                grdMalBeyani.Visible = true;
                grdMalBeyani.BringToFront();
            }
            else if (MView == ViewType.VGrid)
            {
                panelControl1.Visible = true;
                grdMalBeyani.Visible = false;
                panelControl1.BringToFront();
            }
        }
    }
}