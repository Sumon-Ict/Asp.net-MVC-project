using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookSystem.Areas.Admin.Models;
using BookSystem.Training.BusinessObjects;

namespace BookSystem.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<EditBookModel, Book>().ReverseMap();


        }
    }
}
