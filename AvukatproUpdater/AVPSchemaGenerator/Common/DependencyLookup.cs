using AVPSchemaGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVPSchemaGenerator.Common
{
    public class DependencyLookup
    {
        #region Fields

        private DBSchema _db;
        private bool _ignoreSchema = true;

        #endregion Fields

        #region Constructors

        public DependencyLookup(DBSchema db)
        {
            _db = db;
            _ignoreSchema = false;

            DependencyList = new List<string>();
            DependencyNameList = new Dictionary<string, IEnumerable<string>>();
        }

        #endregion Constructors

        #region Properties

        public List<string> DependencyList
        {
            get;
            set;
        }

        public Dictionary<string, IEnumerable<string>> DependencyNameList
        {
            get;
            set;
        }

        public List<Function> Function
        {
            get;
            private set;
        }

        public List<StoredProcedure> StoredProcedures
        {
            get;
            private set;
        }

        public List<Table> Tables
        {
            get;
            private set;
        }

        public List<View> Views
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        public void GetViewDependencyList()
        {
            DependencyList.Clear();
            DependencyNameList.Clear();

            _db.Views.ForEach(view => DependencyNameList.Add(view.Name, new List<string>()));
            _db.Views.ForEach(GetViewDependencies);

            DependencyList = DependencySorter<string>.Sort(DependencyNameList).Reverse().ToList();
        }

        private void GetViewDependencies(View lookupView)
        {
            List<string> tmpList = new List<string>();
            if (!this._ignoreSchema && (lookupView.Schema.ToLower() == "dbo"))
            {
                this._ignoreSchema = true;
            }
            string fnName = lookupView.Name.Replace("[", "").Replace("]", "").ToLower();
            string schemaName = lookupView.Schema.Replace("[", "").Replace("]", "").ToLower();

            Predicate<View> predicate3 = v =>
            {
                bool flag2 = v.Definition.ToLower().Contains(fnName);
                if (this._ignoreSchema)
                    return flag2;
                bool flag3 = v.Definition.ToLower().Contains(schemaName);
                return flag2 && flag3;
            };
            List<View> list3 = this._db.Views.FindAll(predicate3);
            SQLParser parser = new SQLParser();

            list3.ForEach(view =>
            {
                if (parser.Exists(view.BodyDefinition, lookupView))
                {
                    tmpList.Add(view.Name);
                }
            });
            DependencyNameList[lookupView.Name] = tmpList;
        }

        #endregion Methods
    }
}