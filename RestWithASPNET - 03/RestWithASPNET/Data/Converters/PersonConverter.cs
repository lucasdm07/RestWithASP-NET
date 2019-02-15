using RestWithASPNET.Data.Converter;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName,
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName,
            };
        }

        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
