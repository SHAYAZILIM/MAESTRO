using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Types;

namespace AVPSchemaGenerator.Collections
{
    public class IndexKeyCollection : CollectionWithEvents
    {
        #region Indexers

        #endregion Indexers

        #region Methods

        public int Add(IndexKey value)
        {
            return base.List.Add(value);
        }

        #endregion Methods
    }
}