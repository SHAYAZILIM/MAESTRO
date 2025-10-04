using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraVerticalGrid.Events;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi
{
    public partial class ucGayriMenkul : AvpXUserControl
    {
        public bool dnExtented = true;
        private TList<AV001_TI_BIL_GAYRIMENKUL> _MyDataSource;

        public ucGayriMenkul()
        {
            if (DesignMode)
                InitializeComponent();
            this.Load += ucGayriMenkul_Load;
        }

        public AV001_TI_BIL_GAYRIMENKUL CurrentGayriMenkul
        {
            get
            {
                if (MyDataSource != null && vgGayrimenkul.FocusedRecord > -1 && MyDataSource.Count > 0)
                    
                    return MyDataSource[vgGayrimenkul.FocusedRecord];
                else
                    return null;
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_GAYRIMENKUL> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                if (value != null)
                {
                    value.ForEach(item => item.ColumnChanged += new AV001_TI_BIL_GAYRIMENKULEventHandler(item_ColumnChanged));

                    #region <MB-20100927>

                    //Kayýt iþleminde columnchange eventine girmesini saðlamak için eklendi.
                    value.AddingNew += new AddingNewEventHandler(value_AddingNew);

                    #endregion <MB-20100927>

                    if (IsLoaded)
                        BindData();
                }
            }
        }

        public AV001_TD_BIL_FOY MyDavaFoy { get; set; }

        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        public int RecordIndex
        {
            get
            {
                if (vgGayrimenkul != null)
                    return vgGayrimenkul.FocusedRecord;
                else
                    return 0;
            }
        }

        public void BindData()
        {
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit2);
            if (MyDataSource != null && !this.DesignMode)
            {
                InitsData();
                vgGayrimenkul.DataSource = MyDataSource;
                gcGayrimenkul.DataSource = MyDataSource;
                dataNavigatorExtended1.DataSource = MyDataSource;
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgGayrimenkul.Visible)
            {
                vgGayrimenkul.Visible = false;
                gcGayrimenkul.Visible = true;
                gcGayrimenkul.DataSource = vgGayrimenkul.DataSource;
            }
            else
            {
                vgGayrimenkul.Visible = true;
                gcGayrimenkul.Visible = false;
                vgGayrimenkul.DataSource = gcGayrimenkul.DataSource;
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender, ListedenGetirEventArgs e)
        {
            frmEkleGayriMenkul frm = new frmEkleGayriMenkul();
            frm.alreadyaddedList = MyDataSource;

            // frm.MdiParent = null;
            if (MyDavaFoy != null)
                frm.MyDavaFoy = MyDavaFoy;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.Show();

            //DialogResult dr = frm.KayitBasarili;

            //if (dr == DialogResult.OK)
            //{
            //    foreach (AV001_TI_BIL_GAYRIMENKUL gm in frm.selectedList)
            //    {
            //        if (MyDataSource.Find("ID", gm.ID) == null)
            //        {
            //            MyDataSource.Add(gm);
            //        }
            //    }
            //}
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyDavaFoy != null)
                MyDataSource = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByDAVA_FOY_IDFromNN_DAVA_GAYRIMENKUL(MyDavaFoy.ID);
        }

        private void frmSil_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL>));
            vgGayrimenkul.DataSource = MyDavaFoy.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_DAVA_GAYRIMENKUL;
        }

        private void InitsData()
        {
            BelgeUtil.Inits.IlGetirUlkeyeGore(rlkIL_ID, 1);//TÜRKÝYE
        }

        private void item_ColumnChanged(object sender, AV001_TI_BIL_GAYRIMENKULEventArgs e)
        {
            if (e.Column == AV001_TI_BIL_GAYRIMENKULColumn.IL_ID)
                BelgeUtil.Inits.IlceGetirIleGore(rlkILCE_ID, (int)e.Value);
            else if (e.Column == AV001_TI_BIL_GAYRIMENKULColumn.ILCE_ID)
            {
                BelgeUtil.Inits.TapuMudurlukGetirIlceyeGore(rLueTapuMudurluk, (int)e.Value);
                BelgeUtil.Inits.BelediyeGetirIlceyeGor(rLueBelediye, (int)e.Value);
            }

            if (MyDavaFoy != null)
                MyDavaFoy.AV001_TI_BIL_GAYRIMENKULCollection = MyDataSource;
            else if (MySozlesme != null)
                MySozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL = MyDataSource;
        }

        private void sbtnIliskiliMaliKaldir_Click(object sender, EventArgs e)
        {
            frmKayitSil frmSil = new frmKayitSil("NN_DAVA_GAYRIMENKUL", string.Format("DAVA_FOY_ID = {0} AND GAYRIMENKUL_ID = {1}", MyDavaFoy.ID, (vgGayrimenkul.DataSource as TList<AV001_TI_BIL_GAYRIMENKUL>)[vgGayrimenkul.FocusedRecord].ID));
            frmSil.FormClosed += new FormClosedEventHandler(frmSil_FormClosed);
            frmSil.Show();
        }

        private void ucGayriMenkul_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            if (!IsLoaded)
                InitializeComponent();

            IsLoaded = true;
            compVGridRecordCopy1.MyVGridControl = vgGayrimenkul;
            compGridRowCopy1.MyGridControl = gcGayrimenkul;

            dataNavigatorExtended1.Visible = dnExtented;

            //Düzenleme modunda ilçe, tapu, belediye lookuplarý dolmadýðý için eklendi.
            if (MyDataSource != null)
                MyDataSource.ForEach(item =>
                    {
                        if (item.IL_ID.HasValue)
                            BelgeUtil.Inits.IlceGetirIleGore(rlkILCE_ID, item.IL_ID.Value);
                        if (item.ILCE_ID.HasValue)
                        {
                            BelgeUtil.Inits.TapuMudurlukGetirIlceyeGore(rLueTapuMudurluk, item.ILCE_ID.Value);
                            BelgeUtil.Inits.BelediyeGetirIlceyeGor(rLueBelediye, item.ILCE_ID.Value);
                        }
                    });
            BindData();
            if (MyDavaFoy == null)
                sbtnIliskiliMaliKaldir.Visible = false;
            else
                sbtnIliskiliMaliKaldir.Visible = true;

            vgGayrimenkul.CellValueChanged += vgGayrimenkul_CellValueChanged;

        }

        void vgGayrimenkul_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            MyDataSource[RecordIndex].ColumnChanged += item_ColumnChanged;
        }

        private void value_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (e.NewObject != null)
                (e.NewObject as AV001_TI_BIL_GAYRIMENKUL).ColumnChanged += item_ColumnChanged;
        }

        private void vgGayrimenkul_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            //if (GayriMenkulFocusedChanged != null)
            //{

            //    GayriMenkulFocusedChanged(sender, e);
            //}

            if (e.NewIndex >= 0)
            {
                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    MyDataSource[e.NewIndex].ColumnChanged += item_ColumnChanged;
                    if (MyDataSource[e.NewIndex].IL_ID.HasValue)
                        BelgeUtil.Inits.IlceGetirIleGore(rlkILCE_ID, MyDataSource[e.NewIndex].IL_ID.Value);

                    if (MyDataSource[e.NewIndex].ILCE_ID.HasValue)
                    {
                        BelgeUtil.Inits.TapuMudurlukGetirIlceyeGore(rLueTapuMudurluk, MyDataSource[e.NewIndex].ILCE_ID.Value);
                        BelgeUtil.Inits.BelediyeGetirIlceyeGor(rLueBelediye, MyDataSource[e.NewIndex].ILCE_ID.Value);
                    }
                }
            }
        }

        private void vgGayrimenkul_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            //if (GayriMenkulValidteRecord != null)
            //{
            //    GayriMenkulValidteRecord(sender, e);
            //}
        }
    }
}