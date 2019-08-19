using System.Collections.Generic;

namespace LibraryManagementCore
{
    public interface IDataBase
    {
        void Add(object value);
        void Delete(string id);
        IEnumerable<object> Find(string field, string value);
        void Update(object value);
    }
}