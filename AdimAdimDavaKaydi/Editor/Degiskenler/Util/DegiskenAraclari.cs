namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    public static class DegiskenAraclari
    {
        public static class FormTip
        {
            /// <summary>
            /// Verilen Form tip id sine göre Form tipinin özetini döndür
            /// örn = Ödeme Emri , Tahliye Emri , İcra Emri
            /// </summary>
            /// <param name="formTipId"></param>
            /// <returns></returns>
            public static string GetFormTipOzet(int formTipId)
            {
                string returnValue = string.Empty;
                int[] listeOdemeEmri = new[]
                                           {
                                               1, 2, 3, 8, 10, 11, 12
                                           };

                int[] listeIcraEmri = new[]
                                          {
                                              4, 5, 6, 7, 13
                                          };
                int tahliyeEmri = 9;

                foreach (var item in listeOdemeEmri)
                {
                    if (item == formTipId)
                        return "Ödeme Emri,";
                }
                foreach (var item in listeIcraEmri)
                {
                    if (item == formTipId)
                        return "İcra Emri,";
                }
                if (tahliyeEmri == formTipId)
                    return "Tahliye Emri,";

                return returnValue;
            }
        }
    }
}