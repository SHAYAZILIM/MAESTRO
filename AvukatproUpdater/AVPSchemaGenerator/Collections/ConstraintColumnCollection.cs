using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Types;

namespace AVPSchemaGenerator.Collections
{
    public class ConstraintColumnCollection : CollectionWithEvents
    {
        #region Indexers

        public ConstraintColumn this[int index]
        {
            get { return (base.List[index] as ConstraintColumn); }
        }

        #endregion Indexers

        #region Methods

        public int Add(ConstraintColumn value)
        {
            return base.List.Add(value);
        }

        #endregion Methods
    }
}