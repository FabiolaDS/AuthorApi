using System;
using System.Collections.Generic;
using System.Linq;
using AuthorApi.Model;
using AuthorApi.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AuthorApi.Controllers
{
    [ApiController]
    //[Route("/authors/{authorId}/books")] //path variable


    public class BookController : ControllerBase
    {
        private LibrayDbContext _libDbContext;

        public BookController(LibrayDbContext librayDbContext)
        {
            _libDbContext = librayDbContext;
        }

        //[HttpGet]
       //public List<Book> GetAllBookForAnAuthor([FromRoute] int authorId)
       //{

          //  return _libDbContext.Authors.Find(authorId).Books;
        //}
       
        [HttpGet ("/Books")]
        public List<Book> GetAllBooks()
        {
            return _libDbContext.Books.ToList();
        }

        private Book GetBookByIsbn(int isbn)
        {
            return _libDbContext.Books.First(b => b.ISBN == isbn);
        }


        [HttpPost("/Book/{authorId}")]
        public ActionResult SaveBook([FromBody]Book book, [FromRoute]int authorId)
        {
            
            if (!ModelState.IsValid)// actually check if data is valid
            {
                return BadRequest();
            }
            _libDbContext.Books.Add(book);
            _libDbContext.Authors.Find(authorId).Books.Add(book);
            _libDbContext.SaveChanges();
            return Ok(book);
        }
        
        [HttpDelete("/Book/{bookId}")]
        public void DeleteBook([FromRoute]int bookId)
        {
            Book b = GetBookByIsbn(bookId);
            _libDbContext.Books.Remove(b);
            _libDbContext.SaveChanges();
        }
    }

    
}