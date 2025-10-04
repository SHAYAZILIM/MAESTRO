using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucItirazAlacakNeden : AvpXUserControl
    {
        private AV001_TI_BIL_FOY _foy;

        private TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        public ucItirazAlacakNeden()
        {
            if (this.DesignMode) InitializeComponent();
            this.Load += ucItirazAlacakNeden_Load;
        }

        public event DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler ucItirazValidateRow;

        public AV001_TI_BIL_FOY Foy
        {
            get { return _foy; }
            set
            {
                _foy = value;
                if (value != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>));
                    MyDataSource = value.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection;
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
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
            //if (MyDataSource.Count == 0)
            //{
            DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(Foy
                                                             , false, DeepLoadType.IncludeChildren,
                                                             typeof(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>));
            MyDataSource = Foy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection;

            //}
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                InitsDoldur();
                grdItirazlar.DataSource = MyDataSource;
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }

        private void grdItirazlar_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: Ýlk kayýt eklendiðinde eklenen kayýt grid de görünmüyor fakat önceden kayýt girilmiþse yeni kayýt eklendiðinde görünüyor.
                //UNDONE: Kayýt ekleme formu açýldýðýnda kayýtlar görüntüleniyor. Yeni kayýt eklemek için formun boþ gelmesi gerekli.
                rFrmItiraz frm = new rFrmItiraz();
                //frm.MyFoy = Foy;
                //.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.Show(Foy);
                frm.FormClosed += frm_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwItiraz.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                // Seçilen kaydý düzenle.
                //UNDONE: Form açýldýðýnda kayýtlarýn tamamý görüntüleniyor. Sadece seçilen kaydý görüntülemeli.
                rFrmItiraz frm = new rFrmItiraz();
                TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itirazList = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                itirazList.Add(gwItiraz.GetFocusedRow() as AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN);
                frm.AddNewList = itirazList;
                frm.MyGelisme = ucIcraTarafGelismeleri.myGelisme;
                frm.Show(Foy);

                #endregion <AC - 20090614>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwItiraz.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                // Seçilen Kaydý Sil
                // AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN Database Delete Cascade kontrolü yapýldý.
                if (
                    XtraMessageBox.Show(
                        string.Format("Seçilen kayýt silinsin mi?{0}Bu kayda baðlý kayýtlar varsa tamamý silinecek.",
                                      Environment.NewLine), "Kayýt Sil", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MyDataSource.Remove((AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)gwItiraz.GetFocusedRow()))
                        XtraMessageBox.Show("Kayýt baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Kayýt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion <AC - 20090614>
            }
        }

        private void gwItiraz_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ucItirazValidateRow != null)
                ucItirazValidateRow(sender, e);
        }

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDoviz);
                BelgeUtil.Inits.DovizTipGetir(rlueTutarDovizId);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueItrSonuc);
                BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNedenKodId);
                BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNeden);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorevID);
                BelgeUtil.Inits.perCariGetir(rLueCariID);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliyeID);
                BelgeUtil.Inits.IcraItirazSonucGetir(rLueItirazSonucuID);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNoID);
                BelgeUtil.Inits.ParaBicimiAyarla(rudTutar);
                BelgeUtil.Inits.ParaBicimiAyarla(tutar);

                if (Foy != null && !this.DesignMode)
                {
                    try
                    {
                        BelgeUtil.Inits.AlacakNedenByFoy(Foy, glueAlacakNedeni);

                        BelgeUtil.Inits.OdemeBorcluTarafByFoy(Foy, new[] { rLueCari });
                    }

                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
                initsFilled = true;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur();
        }

        private void ucItirazAlacakNeden_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            this.IsLoaded = true;

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