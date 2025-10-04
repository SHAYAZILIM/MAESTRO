using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSikayetBilgileri : AvpXUserControl
    {
        public ucSikayetBilgileri()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucSikayetBilgileri_Load;
        }

        private AV001_TI_BIL_FOY myFoy;
        private TList<AV001_TI_BIL_SIKAYET> _MyDataSource;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    if (myFoy.AV001_TI_BIL_SIKAYETCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy, false, DeepLoadType.IncludeChildren
                                                                         , typeof(TList<AV001_TI_BIL_SIKAYET>));
                MyDataSource = value.AV001_TI_BIL_SIKAYETCollection;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_SIKAYET> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

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

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            InitsDoldur();
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            InitsDoldur();
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                if (MyFoy != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                     , false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_SIKAYET>));
                    _MyDataSource = MyFoy.AV001_TI_BIL_SIKAYETCollection;
                }
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                InitsDoldur();
                exGridSikayet.DataSource = MyDataSource;
            }
        }

        private void ucSikayetBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            BindData();
        }

        private bool initsFilled;

        private void InitsDoldur()
        {
            if (!initsFilled && MyDataSource.Count > 0)
            {
                BelgeUtil.Inits.perCariGetir(rLueSikayetCari);
                BelgeUtil.Inits.SikayetNEdenGetir(rLueSikayetNEdeni);
                BelgeUtil.Inits.SikayetKategoriGetir(rLueSikayetKategorisi);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);

                initsFilled = true;
            }
        }

        public static string Validate(AV001_TI_BIL_SIKAYET row)
        {
            StringBuilder sb = new StringBuilder();
            if (row.SIKAYET_NEDEN_ID == 0)
                sb.AppendLine("* Þikayet Nedeni Boþ Olamaz.");
            if (row.SIKAYET_KATEGORISI_ID == 0)
                sb.AppendLine("* Kategorisi Boþ Olamaz.");
            return sb.ToString();
        }

        private void exGridSikayet_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "rFrmSikayetKayit")
            {
                //UNDONE: Kayýt ekleme formu açýlýyor yeni bir kayýt girip kaydet butonuna týklandýðýnda deðiþiklikler kaydedildi mesajý çýkýyor fakat kayýt grid de görünmüyor.
                rFrmSikayetKayit frm = new rFrmSikayetKayit();
                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(MyFoy);
                frm.FormClosed += frm_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gridView1.GetFocusedRow() != null)
            {
                #region <AC - 20090614>

                //Seçilen kaydý düzenle.
                //UNDONE: Kayýtlar grid de listelenmediði için kontrol edilemedi!
                rFrmSikayetKayit frm = new rFrmSikayetKayit();
                frm.AddNewList = MyDataSource;
                frm.Show(MyFoy);

                #endregion </AC - 20090614>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gridView1.GetFocusedRow() != null)
            {
                #region <AC - 20090611>

                // Seçilen kaydý sil.
                //UNDONE: Kayýtlar grid de listelenmediði için kontrol edilemedi!
                //UNDONE: AV001_TI_BIL_SIKAYET Database Delete Cascade kontrolü yapýlacak.
                if (
                    XtraMessageBox.Show(
                        string.Format("Seçilen kayýt silinsin mi?{0}Bu kayda baðlý kayýtlar varsa tamamý silinecek.",
                                      Environment.NewLine), "Kayýt Sil", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    if (MyDataSource.Remove((AV001_TI_BIL_SIKAYET)gridView1.GetFocusedRow()))
                        XtraMessageBox.Show("Kayýt baþarýyla silindi.", "Bilgi", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Kayýt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #endregion </AC - 20090611>
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }
    }
}