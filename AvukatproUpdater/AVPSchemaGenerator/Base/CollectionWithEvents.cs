using System.Collections;

namespace AVPSchemaGenerator.Base
{
    public class CollectionWithEvents : CollectionBase
    {
        #region Delegates

        public delegate void CollectionChange(int index, object value);

        public delegate void CollectionClear();

        #endregion Delegates

        #region Events

        public event CollectionClear Cleared;

        public event CollectionClear Clearing;

        public event CollectionChange Inserted;

        public event CollectionChange Inserting;

        public event CollectionChange Removed;

        public event CollectionChange Removing;

        #endregion Events

        #region Methods

        protected override void OnClear()
        {
            if (Clearing != null)
            {
                Clearing();
            }
        }

        protected override void OnClearComplete()
        {
            if (Cleared != null)
            {
                Cleared();
            }
        }

        protected override void OnInsert(int index, object value)
        {
            if (Inserting != null)
            {
                Inserting(index, value);
            }
        }

        protected override void OnInsertComplete(int index, object value)
        {
            if (Inserted != null)
            {
                Inserted(index, value);
            }
        }

        protected override void OnRemove(int index, object value)
        {
            if (Removing != null)
            {
                Removing(index, value);
            }
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            if (Removed != null)
            {
                Removed(index, value);
            }
        }

        #endregion Methods
    }
}