﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using BookSystem.Training.BusinessObjects;
using BookSystem.Training.Services;

namespace BookSystem.Areas.Admin.Models
{
    public class CreateBookModel
    {
        [Required,MaxLength(200,ErrorMessage =" Book Name must be less than 200 character")]
        public string Name { get; set; }
        [Required,MaxLength(100,ErrorMessage ="Writer name must be less than 100 character")]
        public string Writer { get; set; }
        [Required,Range(typeof(DateTime),"1/1/1900","1/2/2021")]
        public DateTime PublishedDate { get; set; }
        public int Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;


        public CreateBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateBookModel(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public void createBook()
        {
            var book = _mapper.Map<Book>(this);
            _bookService.CreateBook(book);
        }



    }
}
