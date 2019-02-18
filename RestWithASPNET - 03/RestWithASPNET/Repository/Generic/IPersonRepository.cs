using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Repository.Generic
{
    namespace RestWithASPNET.Repository.Generic
    {
        public interface IPersonRepository : IRepository<Person>
        {
            List<Person> FindByName(string firstName, string lastName);
        }
    }

}
