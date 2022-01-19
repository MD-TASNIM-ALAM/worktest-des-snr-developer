using System.Collections.Generic;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class BookRepository
    {
        private readonly IEnumerable<Book> _books;

        List<Book> bs = new List<Book>()
            {
                new Book { Id = 1, Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Language = "English", Pages = 464 },
                new Book { Id = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", Language = "English", Pages = 240},
                new Book { Id = 1, Name = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma; Richard Helm; Ralph Johnson; John Vlissides", Language = "English", Pages = 416},
                new Book { Id = 1, Name = "Angular in Action", Author = "Jeremy Wilken", Language = "English", Pages = 320}
            };

        public BookRepository()
        {
            _books = bs;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book Get(int id)
        {
          foreach (var book in _books)
            { 
               if(book.Id == id)
                    return book;
            }

            return null;
        }

        public IEnumerable<Book> BorrowBook(Book book)
        {
            book.Status = "Borrowed";
            var bookList = new List<Book>();
            bookList.Add(book);
            foreach (var b in _books)
            {
                if( b.Id != book.Id)
                    bookList.Add(b);
            }
            return bookList;
        }
    }
}
