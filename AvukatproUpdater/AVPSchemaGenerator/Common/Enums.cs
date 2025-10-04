namespace AVPSchemaGenerator.Common
{
    #region Enumerations

    public enum ComparedEnum
    {
        Equal,
        Modified,
        NotCompared,
        New,
        Deleted,
        DoNotCompare
    }

    public enum ConstraintType
    {
        PRIMARY_KEY,
        UNIQUE,
        FOREIGN_KEY,
        CHECK,
        DEFAULT
    }

    public enum DBObjectType
    {
        TABLES,
        VIEWS,
        COLUMNS,
        PROCEDURES,
        FUNCTIONS,
        ROUTINES,
        PARAMETERS,
        CONSTRAINTS,
        CONSTRAINT_COLUMNS,
        INDEXES,
        INDEX_COLUMNS
    }

    #endregion Enumerations
}