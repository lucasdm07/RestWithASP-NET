using RestWithASPNET.Data.Converters;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository.Generic.RestWithASPNET.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNET.Business
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;
        private PersonConverter _personConverter;

        public PersonBusinessImpl(IPersonRepository personRepository)
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

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _personConverter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _personConverter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _personConverter.Parse(personEntity);
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"SELECT * FROM persons P WHERE 1 = 1";

            if (!string.IsNullOrEmpty(name)) query = query + $" AND P.FirstName LIKE '%{name}%'";
            query = query + $" ORDER BY P.FirstName {sortDirection} LIMIT {pageSize} OFFSET {page}";

            string countQuery = @"select count(*) from Persons p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName LIKE '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page,
                List = _personConverter.ParseList(persons),
                PageSize = pageSize,
                TotalResults = totalResults
            };
        }
    }
}
