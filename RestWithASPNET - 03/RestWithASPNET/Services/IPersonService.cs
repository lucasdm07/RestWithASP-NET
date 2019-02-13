using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindByAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
