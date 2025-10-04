using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls;
using AvukatProLib2.Entities;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid;
using DevExpress.XtraScheduler;
using DevExpress.XtraTreeList;
using DevExpress.XtraVerticalGrid;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil
{
    [Serializable]
    public class HelpStatus
    {
        private AvpXtraForm myForm;

        public List<GridControl> Grids = new List<GridControl>();

        public List<VGridControl> VGrids = new List<VGridControl>();

        public List<TreeList> Trees = new List<TreeList>();

        public List<SchedulerControl> Schedulers = new List<SchedulerControl>();
        
        private static TList<TDIE_KOD_UYARI_TIP> uyarilar = new TList<TDIE_KOD_UYARI_TIP>();

        public List<DockPanel> DockPanels = new List<DockPanel>();
        
        private List<ControlField> GetFields()
        {
            if (uyarilar == null)
            {
                uyarilar = AvukatProLib2.Data.DataRepository.TDIE_KOD_UYARI_TIPProvider.GetAll();
            }

            List<ControlField> returnValues = new List<ControlField>();
            TList<TDIE_KOD_PRATIK_YARDIM> yardimlar = AvukatProLib2.Data.DataRepository.TDIE_KOD_PRATIK_YARDIMProvider.GetAll();

            for (int i = 0; i < yardimlar.Count; i++)
            {
                ControlField cf = GetAsControlField(yardimlar[i]);
                returnValues.Add(cf);
            }
            frmYardimAciklama.Yardimlar = yardimlar;
            return returnValues;
        }

        private ControlField GetAsControlField(TDIE_KOD_PRATIK_YARDIM yardim)
        {
            ControlField cf = new ControlField(yardim.ID, yardim.ALAN_ADI, yardim.FORM_ADI, yardim.KONTROL_ADI,
                                               yardim.MODUL_ID, yardim.GORUNEN_AD, yardim.BASLIK, yardim.ACIKLAMA,
                                               yardim.UYARI_TIP_ID);
            return cf;
        }

        public ControlField activeField = new ControlField();

        public static List<ControlField> Fields = new List<ControlField>();

        public delegate void OnFocusedControlFieldChanged(ControlField oldField, ControlField newField, object sender);

    }
}