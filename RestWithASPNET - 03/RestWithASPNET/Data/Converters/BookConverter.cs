using RestWithASPNET.Data.Converter;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            return new Book
            {
                Author = origin.Author,
                Id = origin.Id,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }

        public BookVO Parse(Book origin)
        {
            return new BookVO
            {
                Author = origin.Author,
                Id = origin.Id,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
