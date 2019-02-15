using RestWithASPNET.Data.Converters;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;
        private BookConverter _bookConverter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _bookConverter = new BookConverter();
        }

        public BookVO Create(BookVO bookVO)
        {
            var book = _bookConverter.Parse(bookVO);
            book = _repository.Create(book);
            return _bookConverter.Parse(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _bookConverter.ParseList(_repository.FindByAll());
        }

        public BookVO FindById(long id)
        {
            return _bookConverter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO bookVO)
        {
            var book = _bookConverter.Parse(bookVO);
            book = _repository.Update(book);
            return _bookConverter.Parse(book);
        }
    }
}
