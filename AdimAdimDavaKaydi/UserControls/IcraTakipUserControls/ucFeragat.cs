using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Icra;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using AvukatProLib;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucFeragat : AvpXUserControl
    {
        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucFeragat()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucFeragat_Load;
        }

        public event DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler ucFeragatValidateRow;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_FERAGAT> MyDataSource { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TI_BIL_FERAGATCollection;
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
                                                                 typeof(TList<AV001_TI_BIL_FERAGAT>));
                MyDataSource = MyFoy.AV001_TI_BIL_FERAGATCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                InitsDoldur(false);
                gridFeragat.DataSource = MyDataSource;
            }
        }

        private void gridFeragat_ButtonEditorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            AV001_TI_BIL_FERAGAT feragat = gwFeragat.GetFocusedRow() as AV001_TI_BIL_FERAGAT;

            Editor.Degiskenler.Util.FeragatMakbuzu.FeragatMakbuzuGetir(feragat);
        }

        private void gridFeragat_EmbeddedNavigator_ButtonClick(object sender,
                                                               DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: Aþaðýdaki "geçerli kaydý tamamlar" butonuna týklamadan kaydet butonuna týkladýðýmda kaydetme iþlemini yapýyor fakat "Feragat Kapsamý" alanýna girdiðim veriyi kaydetmiyor.
                frmFeragatBilgileri frm = new frmFeragatBilgileri();
                InitsDoldur(true);

                //frm.AddNewList = MyDataSource;
                frm.MyFoy = MyFoy;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwFeragat.GetFocusedRow() != null)
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

                #region <AC - 20090614>

                // Seçilen kaydý düzenle.
                //UNDONE: Form açýldýðýnda grid deki kayýtlarýn tamamýný listeliyor. Sadece seçtiðim kaydý görüntülemeli.
                //UNDONE: Formu kapattýðýmda hiçbir uyarý vermeden kapatýyor ve grid deki tüm kayýtlarý siliyor.
                frmFeragatBilgileri frm = new frmFeragatBilgileri();
                frm.MyFoy = MyFoy;
                frm.AddNewList = new TList<AV001_TI_BIL_FERAGAT>();
                frm.AddNewList.Add(MyDataSource[gwFeragat.FocusedRowHandle]);

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                #endregion <AC - 20090614>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwFeragat.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                // Seçilen Kaydý Sil
                // AV001_TI_BIL_FERAGAT Database Delete Cascade kontrolü yapýldý.
                if (
                    XtraMessageBox.Show(
                        string.Format("Seçilen kayýt silinsin mi?{0}Bu kayda baðlý kayýtlar varsa tamamý silinecek.",
                                      Environment.NewLine), "Kayýt Sil", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MyDataSource.Remove((AV001_TI_BIL_FERAGAT)gwFeragat.GetFocusedRow()))
                        XtraMessageBox.Show("Kayýt baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Kayýt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion <AC - 20090614>
            }
        }

        private void gwFeragat_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ucFeragatValidateRow != null)
                ucFeragatValidateRow(sender, e);
        }

        private void InitsDoldur(bool newItem)
        {
            if ((!initsFilled && MyDataSource.Count > 0) || newItem)
            {
                BelgeUtil.Inits.AlacakNEdenGetir(rLueFeragatAlacakNedenID);
                BelgeUtil.Inits.FeragatHesapKalemGetir(rLueFeragatAlacakKalemID);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.FeragatKapsamiGetir(rLueFeragatKapsamID);
                BelgeUtil.Inits.FeragatTipiGetir(rLueFeragatTipID);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.perCariGetir(rLueTarafCARI);
                BelgeUtil.Inits.MahsupAltKategoriGetir(rLueMahsupAltKategori);
                BelgeUtil.Inits.MahsupKategoriGetir(rLueMahsupKategori);

                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur(false);
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur(false);
        }

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridFeragat_EmbeddedNavigator_ButtonClick(sender,
                                                      new NavigatorButtonClickEventArgs(
                                                          e.Item.Tag as NavigatorCustomButton));
        }

        private void ucFeragat_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            gridFeragat.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
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