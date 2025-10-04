using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Types;

namespace AVPSchemaGenerator.Collections
{
    public class ParameterCollection : CollectionWithEvents
    {
        #region Indexers

        #endregion Indexers

        #region Methods

        public int Add(Parameter value)
        {
            return base.List.Add(value);
        }
        
        #endregion Methods
    }
}