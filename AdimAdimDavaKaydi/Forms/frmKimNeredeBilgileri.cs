using System;
using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmKimNeredeBilgileri : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmKimNeredeBilgileri()
        {
            InitializeComponent();
            this.xtabCPersonelNerede.SelectedPageChanging += xtabCPersonelNerede_SelectedPageChanging;
        }

        private string Aciklama;

        private int? AdliyeID;

        private bool arsivdenMi;

        private bool arsivYuklendi;

        private DateTime? BaslangicT;

        private DateTime? BitisT;

        private AvukatProLib.Arama.AvpDataContext db =
            new AvukatProLib.Arama.AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

        private bool? DonduMu;

        private int? PersonelID;

        public void BindLookUps()
        {
            cmbPersonel.Properties.NullText = "Seç";
            cmbPersonel.Enter += delegate { BelgeUtil.Inits.GetCariImages(cmbPersonel.Properties); };

            lueAdliye.Properties.NullText = "Seç";
            lueAdliye.Enter += delegate { BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliye); };
        }

        public void PersonelNeredeBilgileriGetir(bool arsivMi)
        {
            if (!arsivMi)
            {
                List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> kimNerede =
                    AvukatProLib.Arama.R_KIM_NEREDESorgu.GetByFiltre(null, DateTime.Now.Date, null, null, null, null,
                                                                     AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                ucKimNeredeBilgileri1.MyDataSource = kimNerede;
            }
        }

        private void chDonduMu_CheckedChanged(object sender, EventArgs e)
        {
            if (chDonduMu.EditValue != null)
                DonduMu = Convert.ToBoolean(chDonduMu.EditValue);
            else
                DonduMu = null;
        }

        private void dtBaslangicT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBaslangicT.EditValue != null)
                BaslangicT = (DateTime?)dtBaslangicT.EditValue;
            else
                BaslangicT = null;
        }

        private void dtBitisT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtBitisT.EditValue != null)
                BitisT = (DateTime?)dtBitisT.EditValue;
            else
                BitisT = null;
        }

        private void frmKimNeredeBilgileri_Load(object sender, EventArgs e)
        {
            PersonelNeredeBilgileriGetir(arsivdenMi);

            BindLookUps();

            ucKimNeredeBilgileri1.ArsivMi = false;
            ucKimNeredeBilgileri2.ArsivMi = true;
        }

        private void lueAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAdliye.EditValue != null)
                AdliyeID = (int)lueAdliye.EditValue;
            else
                AdliyeID = null;
        }

        private void luePersonel_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbPersonel.EditValue != null)
                PersonelID = (int)cmbPersonel.EditValue;
            else
                PersonelID = null;
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.AV001_TDIE_BIL_KIM_NEREDE> kimNerede =
                AvukatProLib.Arama.R_KIM_NEREDESorgu.GetByFiltre(PersonelID, BaslangicT, BitisT, DonduMu, AdliyeID,
                                                                 Aciklama, AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            ucKimNeredeBilgileri2.MyDataSource = kimNerede;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            lueAdliye.EditValue = null;
            cmbPersonel.EditValue = null;
            dtBaslangicT.EditValue = null;
            dtBitisT.EditValue = null;
            chDonduMu.Checked = false;
            txtAciklama.Text = string.Empty;
            DonduMu = null;
        }

        private void txtAciklama_EditValueChanged(object sender, EventArgs e)
        {
            Aciklama = txtAciklama.Text;
            if (txtAciklama.Text == string.Empty)
                Aciklama = null;
        }

        private void xtabCPersonelNerede_SelectedPageChanging(object sender,
                                                              DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == this.xtabPPersonelArsiv.Name)
            {
                arsivdenMi = true;
                if (!arsivYuklendi)
                {
                    PersonelNeredeBilgileriGetir(arsivdenMi);
                    arsivYuklendi = true;
                }
            }
            if (e.Page.Name == this.xtabPPersonelGunluk.Name)
                arsivdenMi = false;
        }
    }
}