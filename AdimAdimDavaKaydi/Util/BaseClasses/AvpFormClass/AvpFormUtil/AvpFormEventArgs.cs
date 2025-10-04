using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData;
using DevExpress.Utils;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil
{
    [Serializable]
    public class AvpFormEventArgs : EventArgs
    {
    }

    public enum ExportTypes
    {
        Editor,
        Excel,
        Word,
        Outlook,
        Pdf,
        Html,
        Txt,
        Rtf,
        Xml,
    }

    public enum DigerMenuButtonType
    {
        HesaplanmisKalemler,
        IhtiyatiHaciz,
        IhtiyatiTedbir,
        Ilambilgileri,
        MahsupBilgileri,
        TakipOncesiOdemeler,
        DavaOncesiOdemeler,
    }

    public class AvpFormChildRecordFormOpenEventArgs : AvpFormAvpDataSourceEventArgs
    {
        public IBindingList ParentRecord { get; set; }

        public ToolTipItem ClickedMenuItem { get; set; }

        public object CurrentRecord { get; set; }
    }

    public class AvpFormChildOpenEventArgs : AvpFormAvpDataSourceEventArgs
    {
        public IBindingList ParentRecord { get; set; }

        public DigerMenuButtonType Button { get; set; }

        public ToolTipItem ClickedMenuItem { get; set; }
    }

    public class AvpFormExportEventArgs : AvpFormEventArgs
    {
        public AvpDatas Datas { get; set; }

        public AvpDataSource DataSource { get; set; }

        public ExportTypes ExportType { get; set; }
    }
}