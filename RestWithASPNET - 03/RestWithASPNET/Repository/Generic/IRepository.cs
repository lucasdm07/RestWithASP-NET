using RestWithASPNET.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNET.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindByAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
