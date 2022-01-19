using System.Collections.Generic;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class BookRepository
    {
        private List<Book> bookList = new List<Book>();

        List<Book> bs = new List<Book>()
            {
                new Book { Id = 1, Name = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin", Language = "English", Pages = 464 },
                new Book { Id = 2, Name = "Test Driven Development: By Example", Author = "Kent Beck", Language = "English", Pages = 240},
                new Book { Id = 3, Name = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma; Richard Helm; Ralph Johnson; John Vlissides", Language = "English", Pages = 416},
                new Book { Id = 4, Name = "Angular in Action", Author = "Jeremy Wilken", Language = "English", Pages = 320}
            };

        public BookRepository()
        {
            bookList = bs;
        }

        public IEnumerable<Book> GetAll()
        {
            return bookList;
        }

        public Book Get(int id)
        {
          foreach (var book in bookList)
            { 
               if(book.Id == id)
                    return book;
            }

            return null;
        }

        public IEnumerable<Book> BorrowBook(Book book)
        {
            book.Status = "Borrowed";
            var newBookList = new List<Book>();
            foreach (var b in bookList)
            {
                if( b.Id == book.Id)
                    newBookList.Add(book);
                else
                    newBookList.Add(b);
            }
            bookList = newBookList;
            return newBookList;
        }
    }
}
