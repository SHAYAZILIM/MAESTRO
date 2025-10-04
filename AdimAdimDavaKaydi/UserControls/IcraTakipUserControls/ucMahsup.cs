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
    public partial class ucMahsup : AvpXUserControl
    {
        private TList<AV001_TI_BIL_BORCLU_MAHSUP> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private AV001_TI_BIL_FOY myFoy;

        public ucMahsup()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMahsup_Load;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_MAHSUP> MyDataSource
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
                    MyDataSource = value.AV001_TI_BIL_BORCLU_MAHSUPCollection;
            }
        }

        public void BindData()
        {
            if (MyDataSource == null) return;
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
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_MAHSUP>));
                MyDataSource = MyFoy.AV001_TI_BIL_BORCLU_MAHSUPCollection;
                MyDataSource.ForEach(item => item.ColumnChanged += ucMahsup_ColumnChanged);
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                gridMahsupBilgileri.DataSource = MyDataSource;
            }
        }

        private void gridMahsupBilgileri_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                frmMahsupBilgileri frm = new frmMahsupBilgileri();
                frm.MyFoy = MyFoy;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show(MyFoy);
            }
            else if (e.Button.Tag.ToString() == "Duzenle" && gwMahsupBilgileri.GetFocusedRow() != null)
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
                //UNDONE: Form açýldýðýnda grid deki kayýtlarýn tamamý görüntüleniyor. Sadece seçilen kaydýn listelenmesi gerekiyor.
                frmMahsupBilgileri frm = new frmMahsupBilgileri();
                frm.MyFoy = MyFoy;
                frm.AddNewList = new TList<AV001_TI_BIL_BORCLU_MAHSUP>();
                frm.AddNewList.Add(MyDataSource[gwMahsupBilgileri.FocusedRowHandle]);
                MyDataSource[gwMahsupBilgileri.FocusedRowHandle].ColumnChanged += ucMahsup_ColumnChanged;

                //frm.MdiParent = null;
                frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frm.Show();

                #endregion <AC - 20090614>
            }
            else if (e.Button.Tag.ToString() == "Sil" && gwMahsupBilgileri.GetFocusedRow() != null)
            {
                // UNDONE: Seçilen kaydý silme iþlemi yapýlacak.
            }
        }

        private void ucMahsup_ColumnChanged(object sender, AV001_TI_BIL_BORCLU_MAHSUPEventArgs e)
        {
            #region Föyün tekrar hesaplanmasýný önlemek için yapýldý. Okan 18.08.2010

            if (myFoy == null || myFoy.EXTRA_LONG1 == 1) return;
            switch (e.Column)
            {
                case AV001_TI_BIL_BORCLU_MAHSUPColumn.MAHSUP_MIKTAR:
                case AV001_TI_BIL_BORCLU_MAHSUPColumn.MAHSUP_MIKTAR_DOVIZ:
                case AV001_TI_BIL_BORCLU_MAHSUPColumn.MAHSUP_MIKTAR_DOVIZ_ID:
                case AV001_TI_BIL_BORCLU_MAHSUPColumn.MAHSUP_MIKTAR_KUR:
                    myFoy.EXTRA_LONG1 = 1;
                    break;
            }

            #endregion Föyün tekrar hesaplanmasýný önlemek için yapýldý. Okan 18.08.2010
        }

        private void ucMahsup_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            try
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BindData();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}