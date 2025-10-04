using System;

namespace AvukatProLib.LisansYonetimi
{
    public class NewKeyProperties
    {
        public NewKeyProperties()
        {
            this.PrivateKey = string.Empty;
            this.FreeformText = string.Empty;
            this.RegisteredLicenseKey = string.Empty;
            this.UnlimitedDaysValid = false;
            this.DaysValid = -1;
            this.MachineKey = 0;
            this.NumberOfKeys = 1;
            this.UnlockCode = 0;
            this.LicenseStartDate = DateTime.Now;
        }

        public int DaysValid { get; set; }

        public string FreeformText { get; set; }

        public DateTime LicenseStartDate { get; set; }

        public int MachineKey { get; set; }

        public int NumberOfKeys { get; set; }

        public string PrivateKey { get; set; }

        public string RegisteredLicenseKey { get; set; }

        public bool UnlimitedDaysValid { get; set; }

        public int UnlockCode { get; set; }
    }
}