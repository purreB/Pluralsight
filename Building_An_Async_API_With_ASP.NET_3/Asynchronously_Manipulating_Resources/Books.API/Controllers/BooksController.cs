﻿using AutoMapper;
using Books.API.Filters;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
  [ApiController]
  [Route("api/books")]
  public class BooksController : ControllerBase
  {
    private readonly IBooksRepository _booksRepository;
    private readonly IMapper _mapper;

    public BooksController(IBooksRepository booksRepository, IMapper mapper)
    {
      _booksRepository = booksRepository ??
          throw new ArgumentNullException(nameof(booksRepository));

      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [BooksResultFilter]
    public async Task<IActionResult> GetBooks()
    {
      var bookEntities = await _booksRepository.GetBooksAsync();
      return Ok(bookEntities);
    }

    [HttpGet]
    [Route("{id}", Name = "GetBook")]
    [BookResultFilter]
    public async Task<IActionResult> GetBook(Guid id)
    {
      var bookEntity = await _booksRepository.GetBookAsync(id);
      if (bookEntity == null)
      {
        return NotFound();
      }

      return Ok(bookEntity);
    }

    [HttpPost]
    [BookResultFilter]
    public async Task<IActionResult> CreateBook(BookForCreation bookForCreation)
    {
      var bookEntity = _mapper.Map<Entities.Book>(bookForCreation);
      _booksRepository.AddBook(bookEntity);
      await _booksRepository.SaveChangesAsync();

      await _booksRepository.GetBookAsync(bookEntity.Id);

      return CreatedAtRoute("GetBook", new { id = bookEntity.Id }, bookEntity);
    }
  }
}
