using AvukatProLib2.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TableConverter;

namespace AdimAdimDavaKaydi.Belge.Forms
{
    public partial class frmBelgeKayitUfak : DevExpress.XtraEditors.XtraForm
    {
        public frmBelgeKayitUfak()
        {
            InitializeComponent();

            //this.MdiParent = AnaForm.mdiAvukatPro.MainForm;
            this.ucBelgeKayitUfak1.Saved += ucBelgeKayitUfak1_Saved;
        }

        private TList<AV001_TDIE_BIL_BELGE> _myDataSource;

        private List<string> _FileName = new List<string>();
        public List<string> FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                this.ucBelgeKayitUfak1.FileName = value;
            }
        }

        [Browsable(false)]
        public UserControls.ucBelgeKayitUfak Child
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return this.ucBelgeKayitUfak1;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get
            {
                if (DesignMode)
                {
                    return null;
                }
                if (this.ucBelgeKayitUfak1.MyDataSource is TList<AV001_TDIE_BIL_BELGE>)
                {
                    return this.ucBelgeKayitUfak1.MyDataSource;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (DesignMode || value == null)
                {
                    return;
                }
                this.ucBelgeKayitUfak1.MyDataSource = value;
                _myDataSource = value;
            }
        }

        [Browsable(false)]
        public IEntity OpenedRecord
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return OpenedRecord;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    this.ucBelgeKayitUfak1.OpenedRecord = value;
                }
            }
        }

        public IEntity Record
        {
            get
            {
                return ucBelgeKayitUfak1.Record;
            }
            set
            {
                ucBelgeKayitUfak1.Record = value;
            }
        }

        public void SetByTableNameAndId(string tableName, int id)
        {
            //this.ucBelgeKayitUfak1.OpenedRecord = OpenedRecord;
            this.ucBelgeKayitUfak1.Record = (IEntity)TableStringConverter.GetRecordByTableNameAndId(tableName, id);
            this.ucBelgeKayitUfak1.TabloName = tableName;
        }

        //        return _Openedrecord;
        //    }
        //    set
        //    {
        //        if (value != null && !DesignMode)
        //        {
        //            _Openedrecord = value;
        //        }
        //    }
        //}
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        private void ucBelgeKayitUfak1_Saved(IList Records, IEntity Record)
        {
            AV001_TDIE_BIL_BELGE lstBelgeler = (AV001_TDIE_BIL_BELGE)Record;

            //for (int i = 0; i < lstBelgeler.Count; i++)
            //{
            //    AdimAdimDavaKaydi.Belge.Forms.frmBelgeDolasimKayit dolasim =
            //        new AdimAdimDavaKaydi.Belge.Forms.frmBelgeDolasimKayit();
            //    dolasim.MyBelge = lstBelgeler[i];

            //    dolasim.MyDataSource = lstBelgeler[i].AV001_TDIE_BIL_BELGE_DOLASIMCollection;
            //    //dolasim.MdiParent = null;
            //    //dolasim.ShowDialog();
            //}
            if (lstBelgeler.AV001_TDI_BIL_ISCollection_From_NN_IS_BELGE.Count < 1)
                this.Close();
        }

        //private IEntity _Openedrecord;
        //[Browsable(false)]
        //public IEntity OpenedRecord
        //{
        //    get
        //    {
        //        if (this.DesignMode)
        //            return null;
    }
}