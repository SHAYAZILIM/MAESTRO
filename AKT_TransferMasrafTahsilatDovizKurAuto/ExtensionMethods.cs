using System.Linq;

namespace AKT_TransferMasrafTahsilatDovizKurAuto
{
    public static class ExtensionMethods
    {
        public static string ReplaceFromPoint(this string str)
        {
            if (str.Contains('.'))
                return str.Replace('.', ',');
            else
                return str;
        }
    }
}