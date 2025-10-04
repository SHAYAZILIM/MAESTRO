using System;
using System.Collections.Generic;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucBelgeIzlemeDolasimDock : AvpXUserControl
    {
        public ucBelgeIzlemeDolasimDock()
        {
            this.Load += ucBelgeIzlemeDolasimDock_Load;
        }

        private List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> _MyDataSource;

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public bool aramadanmý;
        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            //Commented out by ARCH
            //begin
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += delegate
                {
                    if (aramadanmý && MyDataSource == null)
                        MyDataSource = BelgeUtil.Inits.BelgeGetir();
                };
                bckWorker.RunWorkerCompleted += delegate
                {
                    this.ucBelgeDolasimChildli1.MyDataSource = MyDataSource;
                    if (MyDataSource != null && MyDataSource.Count > 0)
                    {
                        AV001_TDIE_BIL_BELGE RowData = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(MyDataSource[0].ID);
                        string fileName = Tools.TempFilesPath + Guid.NewGuid() + "." + RowData.DOKUMAN_UZANTI;
                        Tools.SaveTofile(fileName, RowData.ICERIK);
                        this.ucBelgeOnizleme1.ViewFile(fileName);
                    }
                };
                bckWorker.RunWorkerAsync();
            }
            //end ARCH
        }

        private void ucBelgeIzlemeDolasimDock_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            if (this.DesignMode)
                return;
            BindData();
        }

        private void ucBelgeDolasimChildli1_FocusedRowChanged(AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE RowData, AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE exRowData, int RowHandle, object sender)
        {
            AV001_TDIE_BIL_BELGE belge = DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(RowData.ID);
            string fileName = Tools.TempFilesPath + Guid.NewGuid() + "." + belge.DOKUMAN_UZANTI;
            Tools.SaveTofile(fileName, belge.ICERIK);
            this.ucBelgeOnizleme1.ViewFile(fileName);
        }
    }
}