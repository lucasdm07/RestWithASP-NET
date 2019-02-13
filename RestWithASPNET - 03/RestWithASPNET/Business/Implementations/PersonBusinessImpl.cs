using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;

namespace RestWithASPNET.Business
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _personRepository;

        public PersonBusinessImpl(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> FindByAll()
        {
            return _personRepository.FindByAll();
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}
