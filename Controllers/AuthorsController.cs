using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase {
        private readonly AuthorContext _context;

        public AuthorsController (AuthorContext context) {
            this._context = context;

            if (this._context.AuthorsList.Count () == 0) {
                _context.AuthorsList.Add (new Author { Name = "First Author" });
                _context.SaveChanges ();
            }
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll () {
            return _context.AuthorsList.ToList ();
        }

        [HttpGet ("{id}")]
        public ActionResult<Author> Get (long id) {
            var _author = _context.AuthorsList.Find (id);
            if (_author == null) {
                return NotFound ();
            }
            return _author;
        }

        [HttpPost]
        [ProducesResponseType (201)]
        public void Post ([FromBody] Author author) {
            _context.AuthorsList.Add (author);
            _context.SaveChanges ();
        }

        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}