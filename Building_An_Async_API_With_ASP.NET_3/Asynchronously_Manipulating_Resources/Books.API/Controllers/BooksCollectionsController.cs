using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
  [ApiController]
  [Route("api/bookcollections")]
  public class BooksCollectionsController : ControllerBase
  {
    private readonly IBooksRepository _booksRepository;

    public BooksCollectionsController(IBooksRepository booksRepository)
    {
      _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreation> bookCollection)
    {
      return Ok();
    }
  }
}