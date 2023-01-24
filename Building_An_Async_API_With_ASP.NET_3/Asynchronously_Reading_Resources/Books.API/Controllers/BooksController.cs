using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Books.API.Services;
using Microsoft.Extensions.Logging;
using Books.API.Filters;

namespace Books.API.Controllers
{
  [ApiController]
  [Route("api/books")]
  public class BooksController : ControllerBase
  {
    private readonly IBooksRepository _bookRepository;

    public BooksController(IBooksRepository bookRepository)
    {
      _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(BooksRepository));
    }

    [HttpGet]
    [BookResultFilter()]
    public async Task<IActionResult> GetBooks()
    {
      var bookEntities = await _bookRepository.GetBooksAsync();
      return Ok(bookEntities);
    }

    [HttpGet]
    [Route("{id}")]
    [BookResultFilter()]
    public async Task<IActionResult> GetBook(Guid id)
    {
      var bookEntity = await _bookRepository.GetBookAsync(id);
      if (bookEntity == null)
      {
        return NotFound();
      }
      return Ok(bookEntity);
    }
  }
}