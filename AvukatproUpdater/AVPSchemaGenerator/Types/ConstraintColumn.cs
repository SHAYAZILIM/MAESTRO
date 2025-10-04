using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;
using System;

namespace AVPSchemaGenerator.Types
{
    public class ConstraintColumn : DBObject, IDisposable
    {
        #region Fields

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors

        public ConstraintColumn(string name, ComparedEnum compared)
            : base(name, compared)
        {
        }

        ~ConstraintColumn()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        public string CheckClause
        {
            get;
            set;
        }

        public string ColumnType
        {
            get;
            set;
        }

        public int OrdinalPosition
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods
        
        private void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    CheckClause = ColumnType = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}