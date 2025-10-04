using System.Collections.Generic;

namespace AdimAdimDavaKaydi.Util.BaseClasses
{
    public static class FormTutucu
    {
        private static List<AvpXtraForm> _forms;

        public static List<AvpXtraForm> Forms
        {
            get
            {
                if (FormTutucu._forms == null)
                    FormTutucu._forms = new List<AvpXtraForm>();

                return FormTutucu._forms;
            }
            set { FormTutucu._forms = value; }
        }

        public static AvpXtraForm GetFormByName(string name)
        {
            for (int i = 0; i < Forms.Count; i++)
            {
                if (Forms[i].Name == name)
                    return Forms[i];
            }
            return null;
        }
    }
}