using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatPro.Model.EntityClasses;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSahisBankaBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSahisBankaBilgileri()
        {
            InitializeComponent();
        }

        private void ucSahisBankaBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            BelgeUtil.Inits.BankaGetir(rlueBanka);
            BelgeUtil.Inits.DovizTipGetir(rlueHesapTur);
            BelgeUtil.Inits.BankaKartTipiGetir(rlueKartTipi);
            if (MyDataBankaSource.Count > 0)
                if (MyDataBankaSource[0].BANKA_ID.HasValue)
                    BelgeUtil.Inits.BankaSubeGetir(rlueSube, (int)MyDataBankaSource[0].BANKA_ID);
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_CARI_BANKA> MyDataBankaSource
        {
            get
            {
                if (vGcSahisBanka.DataSource is TList<AV001_TDI_BIL_CARI_BANKA>)
                    return (TList<AV001_TDI_BIL_CARI_BANKA>)this.vGcSahisBanka.DataSource;
                return null;
            }
            set
            {
                this.vGcSahisBanka.DataSource = value;            
            }
        }

        private void vGcSahisBanka_ValidateRecord(object sender, DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
        {
            if (e.RecordIndex > 0)
            {
                AV001_TDI_BIL_CARI_BANKA banka = MyDataBankaSource[e.RecordIndex];
            }
        }

        private void vGcSahisBanka_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (e.Row.Name == "erBanka")
            {
                BelgeUtil.Inits.BankaSubeGetir(rlueSube, (int)e.Value);
            }
        }

        private void vGcSahisBanka_ShownEditor(object sender, EventArgs e)
        {
            VGridControl gonderen = sender as VGridControl;
            if (gonderen.FocusedRow.Properties.FieldName == "NKO_ILCE_ID" && gonderen.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;

                if (edit.Properties.DisplayField == "ILCE")
                {
                    //VList<per_TDI_KOD_ILCE> ilceler = edit.Properties.DataSource as VList<per_TDI_KOD_ILCE>;
                    //cloneIlce = new VList<per_TDI_KOD_ILCE>(ilceler);
                    //AV001_TDI_BIL_CARI_KIMLIK cari =
                    //    gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_CARI_KIMLIK;
                    //if (cari.NKO_IL_ID.HasValue)
                    //    cloneIlce.Filter = "IL_ID = " + cari.NKO_IL_ID.Value;
                    //else
                    //    cloneIlce.Filter = "IL_ID = 0"; // Hiç bir kayıt göstermiyoruz

                    //edit.Properties.DataSource = cloneIlce;
                }
            }
        }

        private void vGcSahisBanka_HiddenEditor(object sender, EventArgs e)
        {
            //if (cloneIlce != null)
            //{
            //    cloneIlce.Dispose();
            //    cloneIlce = null;
            //}
        }
    }
}
