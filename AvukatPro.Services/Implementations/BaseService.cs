using AvukatPro.Services.Interfaces;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace AvukatPro.Services.Implementations
{
    public class BaseService : IBaseService
    {
        public BaseService()
        {
        }

        private static Context _context;
        private static AvukatPro.Model.Linq.LinqMetaData _dbField;

        public static AvukatPro.Model.Linq.LinqMetaData _db
        {
            get
            {
                if (_dbField == null)
                    _dbField = new Model.Linq.LinqMetaData();
                _dbField.ContextToUse = null;

                _dbField.ContextToUse = Context;

                return _dbField;
            }
        }

        public static Context Context
        {
            get
            {
                _context = null;
                if (_context == null)
                    _context = new Context();
                _context.SetExistingEntityFieldsInGet = false;
                return _context;
            }
        }
    }
}