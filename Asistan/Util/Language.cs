using DevExpress.XtraScheduler.Localization;
using System;
using System.Windows.Forms;
using System.Xml;

namespace Asistan.Util
{
    public static class LocalResxFile
    {
        private static XmlDocument _LanguageXML = null;

        public static XmlDocument LanguageXML
        {
            get
            {
                if (_LanguageXML == null)
                {
                    _LanguageXML = new XmlDocument();
                    _LanguageXML.Load(string.Format(@"{0}\Localization\Scheduler.tr-TR.resx", Application.StartupPath));
                }
                return _LanguageXML;
            }
        }
    }

    public class SchExtensionsLocalizer : SchedulerExtensionsLocalizer
    {
        public override string GetLocalizedString(SchedulerExtensionsStringId id)
        {
            XmlNode node = LocalResxFile.LanguageXML.SelectSingleNode(
                string.Format("root/data[@name='SchedulerStringId.{0}']"
                , Enum.GetName(typeof(SchedulerStringId), id)));
            return node == null ? base.GetLocalizedString(id) : node.InnerText.Replace(@"\r\n", "").Trim();
        }
    }

    public class SchExtensionsResLocalizer : SchedulerExtensionsResLocalizer
    {
        public override string GetLocalizedString(SchedulerExtensionsStringId id)
        {
            XmlNode node = LocalResxFile.LanguageXML.SelectSingleNode(
                string.Format("root/data[@name='SchedulerStringId.{0}']"
                , Enum.GetName(typeof(SchedulerStringId), id)));
            return node == null ? base.GetLocalizedString(id) : node.InnerText.Replace(@"\r\n", "").Trim();
        }
    }

    public class SchLocalizer : SchedulerLocalizer
    {
        public override string GetLocalizedString(SchedulerStringId id)
        {
            XmlNode node = LocalResxFile.LanguageXML.SelectSingleNode(
                string.Format("root/data[@name='SchedulerStringId.{0}']"
                , Enum.GetName(typeof(SchedulerStringId), id)));
            return node == null ? base.GetLocalizedString(id) : node.InnerText.Replace(@"\r\n", "").Trim();
        }
    }

    public class SchResLocalizer : SchedulerResLocalizer
    {
        public override string GetLocalizedString(SchedulerStringId id)
        {
            XmlNode node = LocalResxFile.LanguageXML.SelectSingleNode(
                string.Format("root/data[@name='SchedulerStringId.{0}']"
                , Enum.GetName(typeof(SchedulerStringId), id)));
            return node == null ? base.GetLocalizedString(id) : node.InnerText.Replace(@"\r\n", "").Trim();
        }
    }
}