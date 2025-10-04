namespace Asistan.Util
{
    public static class AsistanLogger
    {
        private static NLog.Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger Logger
        {
            get { return AsistanLogger._Logger; }
            set { AsistanLogger._Logger = value; }
        }
    }
}