using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindByAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
