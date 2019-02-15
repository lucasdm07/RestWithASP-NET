using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET.Data.Converters;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Generic;

namespace RestWithASPNET.Business
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private PersonConverter _personConverter;

        public PersonBusinessImpl(IRepository<Person> personRepository)
        {
            _repository = personRepository;
            _personConverter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _personConverter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _personConverter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindByAll()
        {
            return _personConverter.ParseList(_repository.FindByAll());
        }

        public PersonVO FindById(long id)
        {
            return _personConverter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _personConverter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _personConverter.Parse(personEntity);
        }
    }
}
