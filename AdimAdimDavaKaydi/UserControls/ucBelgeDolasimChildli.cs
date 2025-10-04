using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Belge.Forms;
using AvukatProLib2.Entities;
using Datas.TablesColumn;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeDolasimChildli : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBelgeDolasimChildli()
        {
            InitializeComponent();
        }

        public int IdValue { get; set; }

        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE> MyDataSource
        {
            get
            {
                if (!DesignMode && (this.exGridBelgeBilgi.DataSource is List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>))
                {
                    return (List<AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE>)this.exGridBelgeBilgi.DataSource;
                }
                return null;
            }
            set
            {
                if (value != null && !DesignMode)
                {
                    this.exGridBelgeBilgi.DataSource = value;
                }
            }
        }

        private IEntity _currentRecord;

        [Browsable(false)]
        public IEntity CurrentRecord
        {
            get { return _currentRecord; }
            set
            {
                _currentRecord = value;
                if (value != null)
                {
                    IdValue = ((int)TablesColumnData.GetColumnValueByNameFromRecord(value, "ID").Value);
                    tableName = value.TableName;
                }
            }
        }


        private frmLoading loading = new frmLoading();
        
        public delegate void OnFocusedRowChanged(AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE RowData, AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE exRowData, int RowHandle, object sender);

        public event OnFocusedRowChanged FocusedRowChanged;

        private void gridView1_FocusedRowChanged_2(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FocusedRowChanged != null)
            {
                object data = gridView1.GetRow(e.FocusedRowHandle);
                object exData = gridView1.GetRow(e.PrevFocusedRowHandle);
                if (data is AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE && exData is AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)
                {
                    FocusedRowChanged((AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)data, (AvukatProLib.Arama.per_AV001_TDIE_BIL_BELGE)exData, e.FocusedRowHandle, this);
                }
            }
        }
    }
}