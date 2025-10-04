using System.Data.SqlClient;

namespace AVPSchemaGenerator.Common
{
    public class DBConnectionInfo
    {
        #region Fields

        public readonly string Database;
        public readonly int LCID;
        public readonly string Server;

        public string connectionString;

        #endregion Fields

        #region Constructors

        #endregion Constructors

        #region Methods

        private int GetSQLServerLCID(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string cmdText = "select lcid from master..syslanguages where langid = @@langid";
                    SqlCommand command = new SqlCommand(cmdText, connection);
                    return (int)command.ExecuteScalar();
                }
            }
            catch
            {
            }
            return 0x409;
        }

        #endregion Methods
    }
}