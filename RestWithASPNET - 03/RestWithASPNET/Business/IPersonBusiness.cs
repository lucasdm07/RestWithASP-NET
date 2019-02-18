using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(long id);
        List<PersonVO> FindByAll();
        List<PersonVO> FindByName(string firstName, string lastName);
        PersonVO Update(PersonVO PersonVO);
        void Delete(long id);
    }
}
