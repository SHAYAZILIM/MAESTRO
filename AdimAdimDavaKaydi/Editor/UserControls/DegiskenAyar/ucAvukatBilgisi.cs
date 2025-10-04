using AvukatProLib2.Entities;
using System;

namespace AdimAdimDavaKaydi.Editor.UserControls.DegiskenAyar
{
    public partial class ucAvukatBilgisi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAvukatBilgisi()
        {
            InitializeComponent();
        }

        public string Deger
        {
            get { return this.memoEdit1.Text; }
        }

        private void AntetDoldur()
        {
            TList<AV001_TDIE_BIL_ANTET> antets =
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_ANTETProvider.GetBySUBE_KOD_ID(
                    AvukatProLib.Kimlik.SubeKodu);

            if (antets == null)
            {
                antets =
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_ANTETProvider.GetByCARI_ID(
                        AvukatProLib.Kimlik.CurrentCariId);
            }

            lueAntet.Properties.DataSource = antets;
            lueAntet.Properties.DisplayMember = "AD";
            lueAntet.Properties.ValueMember = "ID";
            lueAntet.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AD"));
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            this.glueAvukatlar.Enabled = this.checkEdit1.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            this.glueAntetBilgileri.Enabled = this.checkEdit2.Checked;
        }

        private void glueAvukatlar_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void lueAntet_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAntet.EditValue is AV001_TDIE_BIL_ANTET)
            {
                AV001_TDIE_BIL_ANTET antet = (AV001_TDIE_BIL_ANTET)lueAntet.EditValue;
                this.glueAntetBilgileri.Properties.DataSource =
                    AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_ANTET_DEGERProvider.Find(
                        string.Format("ANTET_ID='{0}'", antet.ID));
                DevExpress.XtraGrid.Columns.GridColumn clmAd = new DevExpress.XtraGrid.Columns.GridColumn();
                clmAd.FieldName = "AD";
                clmAd.Caption = "Alan";
                glueAntetBilgileri.Properties.View.Columns.Add(clmAd);
                glueAntetBilgileri.Properties.DisplayMember = "AD";
                glueAntetBilgileri.Properties.ValueMember = "ID";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TList<AV001_TDI_BIL_CARI> lstCariler =
                ((TList<AV001_TDI_BIL_CARI>)this.glueAvukatlar.Properties.View.DataSource);

            for (int i = 0; i < lstCariler.Count; i++)
            {
                if (lstCariler[i].IsSelected)
                {
                    this.memoEdit1.SelectedText = "<<C-[" + lstCariler[i].ID + "]" + lstCariler[i].AD + ">>";
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TList<AV001_TDIE_BIL_ANTET_DEGER> lstAntetBilgileri =
                ((TList<AV001_TDIE_BIL_ANTET_DEGER>)this.glueAntetBilgileri.Properties.View.DataSource);

            for (int i = 0; i < lstAntetBilgileri.Count; i++)
            {
                if (lstAntetBilgileri[i].IsSelected)
                {
                    this.memoEdit1.SelectedText = "<<A-[" + lstAntetBilgileri[i].ID + "]" + lstAntetBilgileri[i].ANAHTAR +
                                                  ">>";
                }
            }
        }

        private void ucAvukatBilgisi_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            AntetDoldur();
        }
    }
}