using System.Collections.Generic;
using System.Linq;
using AuthorApi.Model;
using AuthorApi.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AuthorApi.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorListController : ControllerBase

    {
        private LibrayDbContext _libraryDbContext;// inject database context into the controller

        public AuthorListController(LibrayDbContext librayDbContext)
        {
            _libraryDbContext = librayDbContext;
        }

        [HttpGet]
        public List<Author> Authors()
        {
            return _libraryDbContext.Authors.Include("Books").ToList();// have to include book
        }

        [HttpPost]
        public ActionResult SaveAuthor([FromBody]Author author)
        {
            if (!ModelState.IsValid) // for validation  to check
            {
                return BadRequest();
            }

            _libraryDbContext.Authors.Add(author);
            _libraryDbContext.SaveChanges();
            return Ok(author);
        }
    }
}