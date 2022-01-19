using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using des_library_api.Domain;
using des_library_api.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace des_library_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Book Get([FromRoute] int id)
        {
            return _bookRepository.Get(id);
        }

        [HttpPut("{id}")]
        public IEnumerable<Book> BorrowBook([FromRoute] long id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return (IEnumerable<Book>)NotFound();
            }
            return _bookRepository.BorrowBook(book);
        }
    }
}
