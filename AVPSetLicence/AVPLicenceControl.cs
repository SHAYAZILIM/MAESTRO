using AVPSetLicence;
using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Runtime.InteropServices;

public static class AVPLicenceControl
{
    public static string cn()
    {
        return "data source=" + AVPSetLicence.Properties.Settings.Default.LicenceServer + "\\SQLEXPRESS;database=AVPYONETIM;uid=avp;pwd=PASSWRD1;";
    }

    /// <summary>
    /// Determines if there is an active connection on this computer
    /// </summary>
    /// <returns></returns>
    public static bool HasActiveConnection()
    {
        int desc;
        return InternetGetConnectedState(out desc, 0);
    }

    public static void LisansKontrolu(string StartupPath)
    {
        List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
        CompInfo cmpNfo = cmpNfoList[0];

        if (cmpNfo.BitisTarihi < DateTime.Today)
        {
            frmLicenceWarning frm = new frmLicenceWarning();
            frm.ShowDialog();
        }
    }

    public static void PaketiGuncelle(string StartupPath)
    {
        if (!HasActiveConnection())
            return;

        try
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];

            ABSqlConnection cn = new ABSqlConnection();

            cn.CnString = "data source=" + AVPSetLicence.Properties.Settings.Default.LicenceServer + "\\SQLEXPRESS;database=AVPYONETIM;uid=avp;pwd=PASSWRD1;";

            string Email = cn.ExecuteScalar("SELECT b.KullaniciAdi FROM dbo.Lisanslar(NOLOCK) a INNER JOIN dbo.Kullanicilar(NOLOCK) b ON b.MusteriID=a.MusteriID WHERE LisansNo='" + cmpNfo.LisansNo + "'").ToString();

            string ComputerInfo = "";
            ManagementClass islemci;
            islemci = new ManagementClass("Win32_ComputerSystemProduct");
            foreach (ManagementObject cpu in islemci.GetInstances())
            {
                ComputerInfo = Convert.ToString(cpu["UUID"]);
            }

            cn.Clear();
            cn.AddParams("@KullaniciAdi", Email);
            cn.AddParams("@BilgisayarBilgisi", ComputerInfo);
            cn.AddParams("@LisansNo", cmpNfo.LisansNo);

            DataTable dt = cn.GetDataTable("select a.*,c.UrunAdi from dbo.Lisanslar(nolock) a inner join dbo.Kullanicilar(nolock) b on b.MusteriID=a.MusteriID inner join dbo.Urunler(nolock) c on c.ModulNo=a.UrunID where b.KullaniciAdi=@KullaniciAdi and a.Durumu=1 and (BilgisayarBilgisi='' or BilgisayarBilgisi=@BilgisayarBilgisi OR BilgisayarBilgisi is null) and a.LisansNo=@LisansNo and a.BitisTarihi>GETDATE()");

            if (dt.Rows.Count > 0)
            {
                cmpNfo.BilgisayarID = ComputerInfo;
                //cmpNfo.LisansNo = cmpNfo.LisansNo;
                cmpNfo.BaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["BaslangicTarihi"].ToString());
                cmpNfo.BitisTarihi = Convert.ToDateTime(dt.Rows[0]["BitisTarihi"].ToString());
                cmpNfo.ModulNo = dt.Rows[0]["UrunID"].ToString();
                cmpNfo.UrunAdi = dt.Rows[0]["UrunAdi"].ToString();
                CompInfo.Kaydet(cmpNfoList, StartupPath);
            }
            else
            {
                cmpNfo.BilgisayarID = ComputerInfo;
                //cmpNfo.LisansNo = "";
                cmpNfo.BaslangicTarihi = Convert.ToDateTime("01.01.1900");
                cmpNfo.BitisTarihi = Convert.ToDateTime("01.01.1900");
                CompInfo.Kaydet(cmpNfoList, StartupPath);
            }
        }
        catch { ;}
    }

    [DllImport("wininet.dll", CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private extern static bool
        InternetGetConnectedState(out int Description, int ReservedValue);
}