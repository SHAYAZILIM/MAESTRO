using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSablonRaporKaydet : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSablonRaporKaydet()
        {
            InitializeComponent();
        }

        private AV001_TDIE_BIL_SABLON_RAPOR current = new AV001_TDIE_BIL_SABLON_RAPOR();

        private TextControl document;

        private string filename = "";

        public TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> Datas
        {
            get { return (TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR>)vGridControl1.DataSource; }
            set
            {
                if (value != null)
                {
                    vGridControl1.DataSource = value;
                }
            }
        }

        public TextControl Document
        {
            get { return document; }
            set { document = value; }
        }

        public void ShowMe(string _fileName)
        {
            filename = _fileName;
        }

        public void ShowMe(TXTextControl.TextControl _document)
        {
            document = _document;
        }

        private void frmSablonRaporKaydet_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            repositoryItemComboBox1.Validating += repositoryItemComboBox1_Validating;
            repositoryItemComboBox1.AutoComplete = true;

            #region TAHSIN ...  LOOKUPLAR

            BelgeUtil.Inits.DavaAdi(rLueDavaNeden);
            BelgeUtil.Inits.AdliBirimBolumGetir(rLueAdlibirimBolum);
            BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTip);
            BelgeUtil.Inits.DavaTalepGetir(rLueDavaTalep);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.SektorKodGetir(rLueSektor);
            BelgeUtil.Inits.DilKodGetir(rLueDil);
            BelgeUtil.Inits.TakipKonusuGetir(rLueTakipTalepKonu);
            repositoryItemPopupContainerEdit1.EditValueChangedFiringMode =
                DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            repositoryItemPopupContainerEdit1.CloseOnLostFocus = false;
            repositoryItemPopupContainerEdit1.CloseOnOuterMouseClick = false;
            repositoryItemPopupContainerEdit1.HideSelection = false;
            repositoryItemPopupContainerEdit1.ExportMode =
                DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            repositoryItemPopupContainerEdit1.CloseUp += repositoryItemPopupContainerEdit1_CloseUp;

            gridView1.Click += gridView1_Click;

            BelgeUtil.Inits.ModulKodGetir(rLueModul);
            BelgeUtil.Inits.SablonRaporTipGetir(rLueRaporTip);
            BelgeUtil.Inits.FormTipiGetir(gridControl1);
            BelgeUtil.Inits.SablonAltKategoriGetir(rLueKategori);
            BelgeUtil.Inits.TakipYoluGetir(rLueTakipYolu);

            #endregion TAHSIN ...  LOOKUPLAR

            TList<AvukatProLib2.Entities.AV001_TDIE_BIL_SABLON_RAPOR> lstRapor =
                new TList<AV001_TDIE_BIL_SABLON_RAPOR>();
            lstRapor.AllowNew = true;
            if (vGridControl1.DataSource == null)
            {
                lstRapor.Add(new AV001_TDIE_BIL_SABLON_RAPOR());
                this.vGridControl1.DataSource = lstRapor;
            }

            this.vGridControl1.Rows["rowDOSYA_ADRES"].Properties.Value = filename;
            SetForms();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            SetFormsTorapor();
        }

        private void repositoryItemComboBox1_Validating(object sender, CancelEventArgs e)
        {
            int count = 0;
            AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.GetTotalItems("AD='" + ((ComboBoxEdit)sender).Text + "'", out count);
            if (count > 0)
            {
                e.Cancel = true;
            }
        }

        private void repositoryItemPopupContainerEdit1_CloseUp(object sender,
                                                               DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridView1.FocusedRowHandle < gridView1.RowCount - 2)
            {
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
            }
            else
            {
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle - 1;
            }

            SetFormsTorapor();
        }

        private void SetForms()
        {
            if (current == null)
            {
                return;
            }
            if (current.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection.Count == 0)
            {
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_RAPORProvider.DeepLoad(current, false,
                                                                                               AvukatProLib2.Data.
                                                                                                   DeepLoadType.
                                                                                                   IncludeChildren,
                                                                                               typeof(
                                                                                                   TList
                                                                                                   <
                                                                                                   AV001_TDIE_BIL_SABLON_SECILI_BELGE
                                                                                                   >));
            }
            TList<AV001_TDIE_BIL_SABLON_SECILI_BELGE> lstseciliBelgeler =
                new TList<AV001_TDIE_BIL_SABLON_SECILI_BELGE>();
            lstseciliBelgeler =
                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_SABLON_SECILI_BELGEProvider.GetBySABLON_RAPOR_ID(
                    current.ID);
            for (int y = 0; y < lstseciliBelgeler.Count; y++)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    per_TI_KOD_FORM_TIP ftip = (per_TI_KOD_FORM_TIP)gridView1.GetRow(i);
                    if (lstseciliBelgeler[y].FORM_ORNEK_ID.Value == ftip.ID)
                    {
                        ftip.IsSelected = true;
                    }
                }
            }
        }

        private void SetFormsTorapor()
        {
            if (current == null)
            {
                current = ((AV001_TDIE_BIL_SABLON_RAPOR)this.vGridControl1.GetRecordObject(0));
            }
            TList<AV001_TDIE_BIL_SABLON_SECILI_BELGE> lstSecililer = new TList<AV001_TDIE_BIL_SABLON_SECILI_BELGE>();
            VList<per_TI_KOD_FORM_TIP> lstFormTipleri = ((VList<per_TI_KOD_FORM_TIP>)gridControl1.DataSource);
            for (int i = 0; i < lstFormTipleri.Count; i++)
            {
                per_TI_KOD_FORM_TIP ftip = lstFormTipleri[i];
                AV001_TDIE_BIL_SABLON_SECILI_BELGE secili = new AV001_TDIE_BIL_SABLON_SECILI_BELGE();
                secili.SABLON_RAPOR_ID = current.ID;
                secili.FORM_ORNEK_ID = ftip.ID;

                AV001_TDIE_BIL_SABLON_SECILI_BELGE seccili = new AV001_TDIE_BIL_SABLON_SECILI_BELGE();

                if (ftip.IsSelected)
                {
                    lstSecililer.Add(secili);
                }
            }
            current.AV001_TDIE_BIL_SABLON_SECILI_BELGECollection = lstSecililer;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void vGridControl1_FocusedRecordChanged(object sender,
                                                        DevExpress.XtraVerticalGrid.Events.IndexChangedEventArgs e)
        {
            current = ((AV001_TDIE_BIL_SABLON_RAPOR)this.vGridControl1.GetRecordObject(e.NewIndex));
            SetForms();
        }

        private void vGridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VGridHitInfo hitinf = vGridControl1.CalcHitInfo(e.Location);
        }
    }
}