using System;
using System.Data;

public static class ABDegiskenler
{
    public static DateTime OTO_KASA_TARIHI;
    public static DateTime OTO_MASRAF_TARIHI;

    public static void DegiskenleriDoldur()
    {
        ABSqlConnection cn = new ABSqlConnection();
        cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;

        DataTable dt = cn.GetDataTable("SELECT ID, OTO_MASRAF_TARIHI, OTO_KASA_TARIHI FROM dbo.AV001_TDIE_BIL_SISTEM_TANIMLARI(nolock)");
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["OTO_MASRAF_TARIHI"] != DBNull.Value)
                OTO_MASRAF_TARIHI = Convert.ToDateTime(dt.Rows[0]["OTO_MASRAF_TARIHI"].ToString());
            if (dt.Rows[0]["OTO_KASA_TARIHI"] != DBNull.Value)
                OTO_KASA_TARIHI = Convert.ToDateTime(dt.Rows[0]["OTO_KASA_TARIHI"].ToString());
        }
    }
}

public static class Metotlar
{
    public static string ZamanDilimiParametresiOlustur(ABSqlConnection cn, string AlanAdi, string SeciliDilim)
    {
        string where = "";

        if (SeciliDilim == "Dun")
        {
            cn.AddParams("@" + AlanAdi, DateTime.Today.AddDays(-1));
            where += " and " + AlanAdi + "=@" + AlanAdi;
        }
        else if (SeciliDilim == "Bugun")
        {
            cn.AddParams("@" + AlanAdi, DateTime.Today);
            where += " and " + AlanAdi + "=@" + AlanAdi;
        }
        else if (SeciliDilim == "Yarin")
        {
            cn.AddParams("@" + AlanAdi, DateTime.Today.AddDays(1));
            where += " and " + AlanAdi + "=@" + AlanAdi;
        }
        else if (SeciliDilim == "BuHafta")
        {
            if ((int)DateTime.Today.DayOfWeek == 1)
                cn.AddParams("@" + AlanAdi + "1", DateTime.Today);
            else
                cn.AddParams("@" + AlanAdi + "1", DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek * -1).AddDays(1));

            if ((int)DateTime.Today.DayOfWeek == 7)
                cn.AddParams("@" + AlanAdi + "2", DateTime.Today);
            else
                cn.AddParams("@" + AlanAdi + "2", DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek));

            where += " and " + AlanAdi + ">=@" + AlanAdi + "1 and " + AlanAdi + "<=@" + AlanAdi + "2";
        }
        else if (SeciliDilim == "BuAy")
        {
            if ((int)DateTime.Today.Day == 1)
                cn.AddParams("@" + AlanAdi + "1", DateTime.Today);
            else
                cn.AddParams("@" + AlanAdi + "1", Convert.ToDateTime("01." + DateTime.Today.Month + "." + DateTime.Today.Year));

            int ay = 0;
            if (DateTime.Today.Month == 1 || DateTime.Today.Month == 3 || DateTime.Today.Month == 5 || DateTime.Today.Month == 7 || DateTime.Today.Month == 8 || DateTime.Today.Month == 10 || DateTime.Today.Month == 12)
                ay = 31;
            else if (DateTime.Today.Month == 4 || DateTime.Today.Month == 6 || DateTime.Today.Month == 9 || DateTime.Today.Month == 11)
                ay = 30;
            else
                ay = 28;

            cn.AddParams("@" + AlanAdi + "2", Convert.ToDateTime(ay + "." + DateTime.Today.Month + "." + DateTime.Today.Year));

            where += " and " + AlanAdi + ">=@" + AlanAdi + "1 and " + AlanAdi + "<=@" + AlanAdi + "2";
        }
        else if (SeciliDilim == "BuYil")
        {
            cn.AddParams("@" + AlanAdi + "1", Convert.ToDateTime("01.01." + DateTime.Today.Year));
            cn.AddParams("@" + AlanAdi + "2", Convert.ToDateTime("31.12." + DateTime.Today.Year));

            where += " and " + AlanAdi + ">=@" + AlanAdi + "1 and " + AlanAdi + "<=@" + AlanAdi + "2";
        }

        return where;
    }
}