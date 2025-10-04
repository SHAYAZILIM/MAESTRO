using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;

namespace AVPSchemaGenerator.Types
{
    public class IndexKey : DBObject
    {
        #region Constructors

        public IndexKey(string name, ComparedEnum compared)
            : base(name, compared)
        {
        }

        #endregion Constructors
    }
}