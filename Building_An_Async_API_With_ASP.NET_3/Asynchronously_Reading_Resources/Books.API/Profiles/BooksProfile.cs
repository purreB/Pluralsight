using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books.API.Entities;

namespace Books.API.Profiles
{
  public class BooksProfile : Profile
  {
    public BooksProfile()
    {
      CreateMap<Entities.Book, Models.Book>()
      .ForMember(dest => dest.Author, opt =>
      opt.MapFrom(src => src.Author));
    }
  }
}