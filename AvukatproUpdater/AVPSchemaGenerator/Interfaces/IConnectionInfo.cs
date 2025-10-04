using AVPSchemaGenerator.Common;

namespace AVPSchemaGenerator.Interfaces
{
    public interface IConnectionInfo
    {
        #region Properties

        DBConnectionInfo ConnectionInfo
        {
            get;
        }

        #endregion Properties
    }
}