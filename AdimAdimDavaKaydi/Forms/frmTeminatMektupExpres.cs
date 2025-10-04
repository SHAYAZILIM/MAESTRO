using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmTeminatMektupExpres : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmTeminatMektupExpres()
        {
            InitializeComponent();
        }

        private int? BankaID;

        private int? DurumID;

        private string HesapNo;

        private int? LehtarCariID;

        private int? MektupKonuID;

        private DateTime? OdemeTarihi;

        private string ReferansNo;

        private int? SubeID;

        private byte? SureTip;

        private DateTime? TanzimBaslangşcTarihi;

        private DateTime? TanzimBitisTarihi;

        private DateTime? Tarihi;

        private int? TipID;

        private DateTime? VadeTarihi;

        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                    else if (con is SpinEdit)
                    {
                        (con as SpinEdit).EditValue = null;
                    }
                }
            }
            catch 
            {
            }
        }

        private void dtOdemeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtOdemeTarihi.EditValue != null)
                OdemeTarihi = (DateTime?)dtOdemeTarihi.EditValue;
            else
                OdemeTarihi = null;
        }

        private void dtTanzimBaslangicTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTanzimBaslangicTarihi.EditValue != null)
                TanzimBaslangşcTarihi = (DateTime?)dtTanzimBaslangicTarihi.EditValue;
            else
                TanzimBaslangşcTarihi = null;
        }

        private void dtTanzimBitisTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTanzimBitisTarihi.EditValue != null)
                TanzimBitisTarihi = (DateTime?)dtTanzimBitisTarihi.EditValue;
            else
                TanzimBitisTarihi = null;
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarihi = (DateTime?)dtTarih.EditValue;
            else
                Tarihi = null;
        }

        private void dtVadeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtVadeTarihi.EditValue != null)
                VadeTarihi = (DateTime?)dtVadeTarihi.EditValue;
            else
                VadeTarihi = null;
        }

        private void frmTeminatMektupExpres_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lueTipID.Properties.NullText = "Seç";
            lueTipID.Enter += delegate { BelgeUtil.Inits.TeminatTipGetir(lueTipID.Properties); };

            lueMektupKonuID.Properties.NullText = "Seç";
            lueMektupKonuID.Enter += delegate { BelgeUtil.Inits.TeminatMektupKonuGetir(lueMektupKonuID.Properties); };

            lueBankaID.Properties.NullText = "Seç";
            lueBankaID.Enter += delegate { BelgeUtil.Inits.BankaGetir(lueBankaID); };

            lueSubeID.Properties.NullText = "Seç";
            lueSubeID.Enter += delegate { BelgeUtil.Inits.BankaSubeGetir(lueSubeID); };

            lueSureTip.Properties.NullText = "Seç";
            lueSureTip.Enter += delegate { BelgeUtil.Inits.SureTipTipGetir(lueSureTip.Properties); };

            lueDurumID.Properties.NullText = "Seç";
            lueDurumID.Enter += delegate { BelgeUtil.Inits.TeminatMektupDurumGetir(lueDurumID.Properties); };

            lueLehtarCariID.Properties.NullText = "Seç";
            lueLehtarCariID.Enter += delegate
                                         {
                                             BelgeUtil.Inits.perCariGetir(lueLehtarCariID);
                                         };
        }

        private void lueBankaID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBankaID.EditValue != null)
                BankaID = (int)lueBankaID.EditValue;
            else
                BankaID = null;
        }

        private void lueDurumID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurumID.EditValue != null)
                DurumID = (int)lueDurumID.EditValue;
            else
                DurumID = null;
        }

        private void lueLehtarCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLehtarCariID.EditValue != null)
                LehtarCariID = (int)lueLehtarCariID.EditValue;
            else
                LehtarCariID = null;
        }

        private void lueMektupKonuID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMektupKonuID.EditValue != null)
                MektupKonuID = (int)lueMektupKonuID.EditValue;
            else
                MektupKonuID = null;
        }

        private void lueSubeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSubeID.EditValue != null)
                SubeID = (int)lueSubeID.EditValue;
            else
                SubeID = null;
        }

        private void lueSureTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueSureTip.EditValue != null)
                SureTip = (byte)lueSureTip.EditValue;
            else
                SureTip = null;
        }

        private void lueTipID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTipID.EditValue != null)
                TipID = (int)lueTipID.EditValue;
            else
                TipID = null;
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP> TeminatMektubuList =
                new VList<R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUP>();

            TeminatMektubuList = DataRepository.R_BIRLESIK_TAKIPLER_TEMINAT_MEKTUPProvider.GetByFiltre(TipID,
                                                                                                       MektupKonuID,
                                                                                                       BankaID, SubeID,
                                                                                                       HesapNo, Tarihi,
                                                                                                       ReferansNo,
                                                                                                       SureTip,
                                                                                                       VadeTarihi, null,
                                                                                                       TanzimBaslangşcTarihi,
                                                                                                       TanzimBitisTarihi,
                                                                                                       OdemeTarihi, null,
                                                                                                       LehtarCariID);
            ucTeminatMektupBilgileri1.MyDataSource = TeminatMektubuList;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            ucTeminatMektupBilgileri1.MyDataSource = null;
        }

        private void txtHesapNo_EditValueChanged(object sender, EventArgs e)
        {
            HesapNo = "%" + txtHesapNo.Text + "%";
            if (txtHesapNo.Text == string.Empty)
                HesapNo = null;
        }

        private void txtReferansNo_EditValueChanged(object sender, EventArgs e)
        {
            ReferansNo = "%" + txtReferansNo.Text + "%";
            if (txtReferansNo.Text == string.Empty)
                ReferansNo = null;
        }
    }
}