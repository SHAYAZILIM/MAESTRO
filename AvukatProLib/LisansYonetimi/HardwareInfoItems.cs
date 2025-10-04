using System;

namespace AvukatProLib.LisansYonetimi
{
    public class HardwareInfoItems
    {
        public BaseInfo BaseInformation;
        public BIOSInfo BIOSInformation;
        public string CPUInformation;
        public DiskInfo DiskInformation;
        public string MACInformation;
        public VideoInfo VideoInformation;

        public override string ToString()
        {
            string str = string.Empty;
            try
            {
                str = (((((((((((((((((("CPU_ID: " + this.CPUInformation + "\r\n\r\n") + "BIOSInformation.Manufacturer: " + this.BIOSInformation.Manufacturer + "\r\n") + "BIOSInformation.BIOSVersion: " + this.BIOSInformation.BIOSVersion + "\r\n") + "BIOSInformation.IdentificationCode: " + this.BIOSInformation.IdentificationCode + "\r\n") + "BIOSInformation.ReleaseDate: " + this.BIOSInformation.ReleaseDate + "\r\n") + "BIOSInformation.SerialNumber: " + this.BIOSInformation.SerialNumber + "\r\n\r\n") + "BaseInformation.SerialNumber: " + this.BaseInformation.SerialNumber + "\r\n") + "BaseInformation.Name: " + this.BaseInformation.Name + "\r\n") + "BaseInformation.Model: " + this.BaseInformation.Model + "\r\n") + "BaseInformation.Manufacturer: " + this.BaseInformation.Manufacturer + "\r\n\r\n") + "VideoInformation.Name: " + this.VideoInformation.Name + "\r\n") + "VideoInformation.DriverVersion: " + this.VideoInformation.DriverVersion + "\r\n\r\n") + "DiskInformation.Model: " + this.DiskInformation.Model + "\r\n") + "DiskInformation.Manufacturer: " + this.DiskInformation.Manufacturer + "\r\n") + "DiskInformation.Signature: " + this.DiskInformation.Signature + "\r\n") + "DiskInformation.Size: " + this.DiskInformation.Size + "\r\n") + "DiskInformation.SystemName: " + this.DiskInformation.SystemName + "\r\n") + "DiskInformation.TotalHeads: " + this.DiskInformation.TotalHeads + "\r\n\r\n") + "MACInformation: " + this.MACInformation + "\r\n";
            }
            catch (Exception)
            {
                str = base.ToString();
            }
            return str;
        }
    }
}