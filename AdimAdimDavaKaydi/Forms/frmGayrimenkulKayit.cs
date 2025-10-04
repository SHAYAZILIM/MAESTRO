using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmGayrimenkulKayit : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGayrimenkulKayit()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TI_BIL_GAYRIMENKUL> gayriList = new TList<AV001_TI_BIL_GAYRIMENKUL>();

        //private void ucGayriMenkul1_GayriMenkulFocusedChanged(object sender,
        //                                                      DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        //{
        //    //if (e.NewIndex > -1)
        //    if ((e.NewIndex > 0) && (e.NewIndex < gayriList.Count))
        //        ucGayriMenkulTaraf1.MyDataSource = gayriList[e.NewIndex].AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
        //}
        private TList<AV001_TI_BIL_GAYRIMENKUL> myDataSource;

        public event EventHandler<GayrimenkulKaydedildiEventArgs> GayrimenkulKaydedildi;

        [Browsable(false)]
        public TList<AV001_TI_BIL_GAYRIMENKUL> MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myDataSource = value;
                    if (gayriList.Count <= 0)
                        gayriList.AddNew();
                    ucGayrimenkulTarafliExpertizli1.MyDataSource = value;
                    ucGayrimenkulTarafliExpertizli1.HacizKayitEkranimi = false;
                }
            }
        }

        private void frmGayrimenkulKayit_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Kaydetme iþlemi yapýlamýyor.",
                                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmGayrimenkulKayit_Button_Kaydet_Click;
        }

        private bool Save()
        {
            bool sonuc = false;

            // MyDataSource.AddRange(gayriList);

            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                tran.BeginTransaction();

                DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepSave(tran, MyDataSource);

                tran.Commit();
                if (GayrimenkulKaydedildi != null)
                    GayrimenkulKaydedildi(this, new GayrimenkulKaydedildiEventArgs(MyDataSource));
                sonuc = true;
            }
            catch (Exception )
            {
                //BelgeUtil.ErrorHandler.Catch(this, ex);

                sonuc = false;
            }
            finally
            {
                tran.Dispose();
            }
            return sonuc;
        }
    }
}