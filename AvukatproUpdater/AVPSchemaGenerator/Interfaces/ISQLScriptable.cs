namespace AVPSchemaGenerator.Interfaces
{
    public interface ISQLScriptable
    {
        #region Methods

        string SQLAlterMSSQL2MSSQL();

        string SQLCreateMSSQL2MSSQL();

        string SQLDropMSSQL2MSSQL();

        string SQLScript(bool bNotExistInMaster);

        #endregion Methods
    }
}