using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO bookVO);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO bookVO);
        void Delete(long id);
    }
}
