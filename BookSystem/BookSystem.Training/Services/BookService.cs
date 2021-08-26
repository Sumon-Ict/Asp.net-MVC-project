using AutoMapper;
using BookSystem.Common.Utility;
using BookSystem.Training.BusinessObjects;
using BookSystem.Training.Exceptions;
using BookSystem.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Training.Services
{
    public class BookService : IBookService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;

        private readonly IDateTimeUtility _dateTimeUtility;

      public BookService(ITrainingUnitOfWork trainingUnitOfWork,IMapper mapper,
          IDateTimeUtility dateTimeUtility)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;

        }

        public void CreateBook(Book book)
        {
            if (book == null)
                throw new InvalidParameterException("book is not provided for create");
            if (IfAlreadyUsed(book.Name))
                throw new DuplicateValueException("this book name is already used");
            if (IsvalidPublishedDate(book.PublishedDate))
                throw new InvalidOperationException("published date can not be future ");

            _trainingUnitOfWork.Books.Add(_mapper.Map<Entities.Book>(book));
            _trainingUnitOfWork.Save();

           
        }

        public void DeleteBook(int id)
        {
            _trainingUnitOfWork.Books.Remove(id);
            _trainingUnitOfWork.Save();

        }

        public Book GetBook(int id)
        {
            var book = _trainingUnitOfWork.Books.GetById(id);
            if (book == null)
                return null;

            return _mapper.Map<Book>(book);

        }

        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string sortText)
        {

            var bookData = _trainingUnitOfWork.Books.GetDynamic(string.IsNullOrEmpty(searchText) ?
             null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from book in bookData.data
                              select _mapper.Map<Book>(book)).ToList();

            return (resultData, bookData.total, bookData.totalDisplay);

        }


        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new InvalidParameterException("book is not provided for update ");

            if (IfAlreadyUsed(book.Name, book.Id))
                throw new DuplicateValueException("this book name already exist");

            var bookEntity = _trainingUnitOfWork.Books.GetById(book.Id);

            if (bookEntity != null)
            {
                _mapper.Map(book, bookEntity);
                _trainingUnitOfWork.Save();


            }
            else
                throw new InvalidOperationException("failed to update book");


        }
        private bool IfAlreadyUsed(string name) =>
            _trainingUnitOfWork.Books.GetCount(x => x.Name == name) > 0;
        private bool IfAlreadyUsed(string name,int id) =>
           _trainingUnitOfWork.Books.GetCount(x => x.Name == name && x.Id!=id) > 0;

        private bool IsvalidPublishedDate(DateTime datetime) =>
            datetime.Subtract(_dateTimeUtility.Now).TotalDays > 0;



    }
}
