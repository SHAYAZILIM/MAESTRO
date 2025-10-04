using AVPSchemaGenerator.Common;
using System;
using System.Xml.Serialization;

namespace AVPSchemaGenerator.Base
{
    public abstract class DBObject : IDisposable
    {
        #region Constructors
        
        public DBObject(string name, ComparedEnum compared)
        {
            Name = name;
            Compared = compared;
        }

        protected DBObject()
        {
        }

        #endregion Constructors

        #region Properties

        [XmlIgnore]
        public ComparedEnum Compared
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void Dispose()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        #endregion Methods
    }
}