using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using Books.API.Filters;

namespace Books.API.Controllers
{
  [ApiController]
  [Route("api/syncbooks")]
  public class SynchronousBooksController : ControllerBase
  {
    private readonly IBooksRepository _booksRepository;
    public SynchronousBooksController(IBooksRepository booksRepository)
    {
      _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    [HttpGet]
    [BooksResultFilter]

    public IActionResult GetBooks()
    {
      var bookEntities = _booksRepository.GetBooks();
      if (bookEntities == null)
      {
        return NotFound();
      }
      return Ok(bookEntities);
    }
  }
}