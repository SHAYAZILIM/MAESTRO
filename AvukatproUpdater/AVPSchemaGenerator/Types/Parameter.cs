using AVPSchemaGenerator.Base;
using AVPSchemaGenerator.Common;
using System;

namespace AVPSchemaGenerator.Types
{
    public class Parameter : DBObject, IDisposable
    {
        #region Fields

        private bool isDisposed = false;

        #endregion Fields

        #region Constructors
        
        public Parameter(string name, ComparedEnum compare)
            : base(name, compare)
        {
        }

        ~Parameter()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        public string AsLocator
        {
            get;
            set;
        }

        public string CharacterMaximumLength
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public string DateTimePrecision
        {
            get;
            set;
        }

        public string IsResult
        {
            get;
            set;
        }

        public string NumericPrecision
        {
            get;
            set;
        }

        public string NumericScale
        {
            get;
            set;
        }

        public string ParameterMode
        {
            get;
            set;
        }

        public string UserDefinedTypeName
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
                    AsLocator = CharacterMaximumLength = DataType = DateTimePrecision = IsResult = NumericPrecision = NumericScale = ParameterMode = UserDefinedTypeName = null;
                    Dispose();
                }
                isDisposed = true;
            }
        }

        #endregion Methods
    }
}