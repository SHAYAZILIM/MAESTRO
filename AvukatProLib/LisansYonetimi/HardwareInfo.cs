using System;
using System.Management;

namespace AvukatProLib.LisansYonetimi
{
    public static class HardwareInfo
    {
        public static BaseInfo GetBaseInformation()
        {
            BaseInfo information2 = null;
            try
            {
                information2 = new BaseInfo();
                BaseInfo information3 = information2;
                information3.Model = GetMachineIdentifiers("Win32_BaseBoard", "Model");
                information3.Manufacturer = GetMachineIdentifiers("Win32_BaseBoard", "Manufacturer");
                information3.Name = GetMachineIdentifiers("Win32_BaseBoard", "Name");
                information3.SerialNumber = GetMachineIdentifiers("Win32_BaseBoard", "SerialNumber");
                information3 = null;
            }
            catch (Exception)
            {
            }
            return information2;
        }

        public static BIOSInfo GetBIOSInformation()
        {
            BIOSInfo information2 = new BIOSInfo();
            try
            {
                BIOSInfo information3 = information2;
                information3.Manufacturer = GetMachineIdentifiers("Win32_BIOS", "Manufacturer");
                information3.BIOSVersion = GetMachineIdentifiers("Win32_BIOS", "Version");
                information3.IdentificationCode = GetMachineIdentifiers("Win32_BIOS", "IdentificationCode");
                information3.SerialNumber = GetMachineIdentifiers("Win32_BIOS", "SerialNumber");
                information3.ReleaseDate = GetMachineIdentifiers("Win32_BIOS", "ReleaseDate");
                information3 = null;
            }
            catch (Exception)
            {
            }
            return information2;
        }

        public static string GetCPUInformation()
        {
            string machineIdentifiers = string.Empty;
            machineIdentifiers = GetMachineIdentifiers("Win32_Processor", "UniqueId");
            if (string.IsNullOrEmpty(machineIdentifiers))
            {
                machineIdentifiers = GetMachineIdentifiers("Win32_Processor", "ProcessorId");
                if (!string.IsNullOrEmpty(machineIdentifiers))
                {
                    return machineIdentifiers;
                }
                machineIdentifiers = GetMachineIdentifiers("Win32_Processor", "Name");
                if (string.IsNullOrEmpty(machineIdentifiers))
                {
                    machineIdentifiers = GetMachineIdentifiers("Win32_Processor", "Manufacturer");
                }
            }
            return machineIdentifiers;
        }

        public static DiskInfo GetDiskInformation()
        {
            DiskInfo information2 = new DiskInfo();
            try
            {
                DiskInfo information3 = information2;
                information3.Model = GetMachineIdentifiers("Win32_DiskDrive", "Model");
                information3.Manufacturer = GetMachineIdentifiers("Win32_DiskDrive", "Manufacturer");
                information3.Signature = GetMachineIdentifiers("Win32_DiskDrive", "Signature");
                information3.TotalHeads = GetMachineIdentifiers("Win32_DiskDrive", "TotalHeads");
                information3.SystemName = GetMachineIdentifiers("Win32_DiskDrive", "SystemName");
                information3.Size = GetMachineIdentifiers("Win32_DiskDrive", "Size");
                information3 = null;
            }
            catch (Exception)
            {
            }
            return information2;
        }

        public static HardwareInfoItems GetHardWareInformation_All()
        {
            HardwareInfoItems items2 = new HardwareInfoItems();
            items2.CPUInformation = GetCPUInformation();
            items2.BIOSInformation = GetBIOSInformation();
            items2.DiskInformation = GetDiskInformation();
            items2.BaseInformation = GetBaseInformation();
            items2.VideoInformation = GetVideoInformation();
            items2.MACInformation = GetMacInformation();
            return items2;
        }

        public static string GetMacInformation()
        {
            return GetMachineIdentifiers("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }

        public static VideoInfo GetVideoInformation()
        {
            VideoInfo information2 = null;
            try
            {
                information2 = new VideoInfo();
                VideoInfo information3 = information2;
                information3.DriverVersion = GetMachineIdentifiers("Win32_VideoController", "DriverVersion");
                information3.Name = GetMachineIdentifiers("Win32_VideoController", "Name");
                information3 = null;
            }
            catch (Exception)
            {
            }
            return information2;
        }

        private static string GetMachineIdentifiers(string strWMIClass, string strWMIProperty)
        {
            string str2 = string.Empty;
            ManagementObjectCollection objects = new ManagementClass(strWMIClass).GetInstances();
            foreach (ManagementObject obj2 in objects)
            {
                if (str2 == "")
                {
                    try
                    {
                        if (obj2[strWMIProperty] != null)
                        {
                            return obj2[strWMIProperty].ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return str2;
        }

        private static string GetMachineIdentifiers(string strWMIClass, string strWMIProperty, string strWMIMustBeTrue)
        {
            string str2 = string.Empty;
            ManagementObjectCollection objects = new ManagementClass(strWMIClass).GetInstances();
            foreach (ManagementObject obj2 in objects)
            {
                if ((obj2[strWMIMustBeTrue].ToString() == "True") && (str2 == ""))
                {
                    try
                    {
                        if (obj2[strWMIProperty] != null)
                        {
                            return obj2[strWMIProperty].ToString();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return str2;
        }
    }
}