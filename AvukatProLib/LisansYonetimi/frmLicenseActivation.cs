using AvukatProLib.AVPLicence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AvukatProLib.LisansYonetimi
{
    public partial class frmLicenseActivation : DevExpress.XtraEditors.XtraForm
    {
        public frmLicenseActivation(string licenseKey)
        {
            license = new License();
            extensionWorkerObject = new ExtensionWorkerObject();
            InitializeComponent();
            this.licenseKey = licenseKey;
            if (!String.IsNullOrEmpty(licenseKey)) txtProductKey.Text = licenseKey;
            btnSaveSettings.Enabled = false;
        }

        private bool changesSaved = false;
        private bool closeOnSave = false;
        private ExtensionWorkerObject extensionWorkerObject = null;
        private License license = null;
        private string licenseKey = "";
        private int modulNo = 0;
        private string tempFolder = Path.Combine(Application.StartupPath, "tmp");
        private ValidatedKey validatedKey = null;
        private bool validLicense = false;

        public bool ValidateKey(string licenseKey)
        {
            bool flag = true;
            validatedKey = LicenseUtil.ValidateLicense(licenseKey);
            ValidatedKey fromRegistry = extensionWorkerObject.GetValidatedKeyFromRegistry();

            if (validatedKey == null) return false;
            if (!validatedKey.MachineCodeValidates || validatedKey.FreeformTextItems.Count == 0 || validatedKey.Key == "Invalid")
            {
                lblLicenseStatus.ForeColor = Color.Red;
                lblLicenseStatus.Text = "Geçersiz lisans anahtarı.";
                flag = false;
            }
            else if (!validatedKey.IsCurrentlyValid)
            {
                lblLicenseStatus.ForeColor = Color.Red;
                lblLicenseStatus.Text = "Lisans süreniz doldu.";
                flag = false;
            }
            else if (fromRegistry != null && fromRegistry.Key != validatedKey.Key && !fromRegistry.IsCurrentlyValid && (fromRegistry.DateValidThrough.Subtract(fromRegistry.DateCreated).Days <= 30))
            {
                if (validatedKey.DateValidThrough.Subtract(validatedKey.DateCreated).Days <= 30) // Gio dosyasındaki anahtar demo bir anahtar
                {
                    lblLicenseStatus.ForeColor = Color.Red;
                    lblLicenseStatus.Text = "Lisans süreniz doldu.";
                    flag = false;
                }
                else // Gio dosyasında demo olmayan geçerli bir lisans anahtarı mevcut. Bu yeni değer registry'ye kaydediliyor
                {
                    extensionWorkerObject.SaveKeyToRegistryEncrypted(validatedKey.Key);
                    lblLicenseStatus.ForeColor = Color.Green;
                    lblLicenseStatus.Text = "Aktif lisans anahtarı.";
                    flag = true;
                }
            }
            else// if (validatedKey.FreeformTextItems[0] != Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.ModulNo.ToString())
            {
                extensionWorkerObject.SaveKeyToRegistryEncrypted(validatedKey.Key);
                lblLicenseStatus.ForeColor = Color.Green;
                lblLicenseStatus.Text = "Aktif lisans anahtarı.";
                flag = true;
            }

            lblLicenseStartDate.Text = validatedKey.DateCreated.ToShortDateString();
            lblLicenseExpirationDate.Text = validatedKey.DateValidThrough.ToShortDateString();
            lblIcraUserCount.Text = validatedKey.FreeformTextItems[0] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[0];
            lblIcraFileCount.Text = validatedKey.FreeformTextItems[1] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[1];
            lblDavaUserCount.Text = validatedKey.FreeformTextItems[2] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[2];
            lblDavaFileCount.Text = validatedKey.FreeformTextItems[3] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[3];
            lblSorusturmaUserCount.Text = validatedKey.FreeformTextItems[4] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[4];
            lblSorusturmaFileCount.Text = validatedKey.FreeformTextItems[5] == "-1" ? "Sınırsız" : validatedKey.FreeformTextItems[5];
            modulNo = validatedKey.FreeformTextItems.Count >= 7 ? int.Parse(validatedKey.FreeformTextItems[6]) : 0;
            return flag;
        }

        private void btnActivateLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductKey.Text)) return;

            pnlMain.Enabled = false;
            pnlLoading.BringToFront();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
        }

        private void frmLicenseActivation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeOnSave) Environment.Exit(1);
            if (validLicense)
            {
                if (changesSaved) DialogResult = DialogResult.OK;
                else if (MessageBox.Show("Değişiklikler kaydedilsin mi?", "Lisanslama", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    btnSaveSettings.PerformClick();
                    DialogResult = DialogResult.OK;
                }
                else DialogResult = DialogResult.Cancel;
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void frmLicenseActivation_Load(object sender, EventArgs e)
        {
            lblLicenseKey.Visible = false;
            txtCustomerKey.Text = license.EncryptMD5(license.LocalMachineCode.ToString(), license.PrivateKey);
            if (Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi == null) return;
            lblName.Text = Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.AdSoyad;
            if (ValidateKey(licenseKey))
            {
                pnlLicensedUser.Visible = true;
            }
            else
            {
                pnlLicensedUser.Visible = false;
            }

            //   txtProductKey.Text = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.LisansBilgisi.ProductKey;
        }
    }
}