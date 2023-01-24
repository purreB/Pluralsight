using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public BooksCollectionsController(IBooksRepository booksRepository, IMapper mapper)
    {
      _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    [HttpPost]
    public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreation> bookCollection)
    {
      var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);
      foreach (var bookEntity in bookEntities)
      {
        _booksRepository.AddBook(bookEntity);
      }

      await _booksRepository.SaveChangesAsync();
      return Ok();
    }
  }
}