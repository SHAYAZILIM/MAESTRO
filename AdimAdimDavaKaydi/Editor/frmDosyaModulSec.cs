using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor
{
    public partial class frmDosyaModulSec : Form
    {
        public frmDosyaModulSec()
        {
            InitializeComponent();
        }

        private IEntity _record;

        [Browsable(false)]
        public IEntity Record
        {
            get
            {
                return _record;
            }
            set
            {
                if (value != null)
                {
                    _record = value;
                }
            }
        }

        private void btnPopupBelgeleriKaydet_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDosyaModulSec_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.ModulGetir(lueModul.Properties);
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            int ModulID = 0;
            if (lueDosya.EditValue != null)
            {
                try
                {
                    if (lueModul.EditValue != null && lueModul.EditValue != DBNull.Value)
                        ModulID = Convert.ToInt32(lueModul.EditValue);
                    switch (ModulID)
                    {
                        case 2:
                            Record = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 1:
                            Record = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 12:
                            Record = DataRepository.AV001_TDI_BIL_TEMSILProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 5:
                            Record = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 13:
                            Record = DataRepository.AV001_TI_BIL_HACIZ_MASTERProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 14:
                            Record = DataRepository.AV001_TI_BIL_SATIS_MASTERProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 15:
                            Record = DataRepository.AV001_TD_BIL_CELSEProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 16:
                            Record = DataRepository.AV001_TDI_BIL_FATURAProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 17:
                            Record = DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        case 11:
                            Record = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByID((int)lueDosya.EditValue);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.Text == "Vekalet")
            {
                colFOY_NO.FieldName = "DOSYA_NO";
                colADLIYE.FieldName = "ADLI_BIRIM_ADLIYE_ID";
                colNO.FieldName = "ADLI_BIRIM_NO_ID";
                colGOREV.FieldName = "ADLI_BIRIM_GOREV_ID";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "DOSYA_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
            else if (lueModul.Text == "Sözleşme")
            {
                colFOY_NO.FieldName = "SOZLESME_NO";
                colESAS_NO.FieldName = "SICIL_YEVMIYE_NO";
                colADLIYE.FieldName = "ADLIYE";
                colNO.FieldName = "NO";
                colGOREV.FieldName = "GOREV";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "SOZLESME_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
            else if (lueModul.Text == "Haciz")
            {
                colFOY_NO.FieldName = "TALIMAT_ESAS_NO";
                colESAS_NO.FieldName = "TUTANAK_NO";
                colADLIYE.FieldName = "TALIMAT_MUDURLUK";
                colNO.FieldName = "TALIMAT_BIRIM_NO";
                colGOREV.FieldName = "KATEGORI";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "TALIMAT_ESAS_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
            else if (lueModul.Text == "Satis")
            {
                colFOY_NO.FieldName = "Dosya_No";
                colESAS_NO.FieldName = "Esas_No";
                colADLIYE.FieldName = "Adliye";
                colNO.FieldName = "No";
                colGOREV.FieldName = "Gorev";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "Dosya_No";
                lueDosya.Properties.ValueMember = "ID";
            }

            else if (lueModul.Text == "Duruşma/Celse")
            {
                colFOY_NO.FieldName = "CELSE_REFERANS_NO";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "CELSE_REFERANS_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
            else if (lueModul.Text == "Fatura")
            {
                colFOY_NO.FieldName = "SERI_NO";
                colESAS_NO.FieldName = "REFERANS_NO";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "SERI_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
            else if (lueModul.Text == "Kiymetli Evrak")
            {
                colFOY_NO.FieldName = "HESAP_NO";
                colESAS_NO.FieldName = "CEK_NO";
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "SERI_NO";
                lueDosya.Properties.ValueMember = "KIYMETLI_EVRAK_ID";
            }
            else
            {
                lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
                lueDosya.Properties.DisplayMember = "FOY_NO";
                lueDosya.Properties.ValueMember = "ID";
            }
        }
    }
}