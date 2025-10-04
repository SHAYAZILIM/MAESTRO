using DevExpress.XtraTab;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class TabControlHelper
    {
        internal static void GetControls(this XtraTabControl control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (XtraTabPage item in control.TabPages)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }
    }
}