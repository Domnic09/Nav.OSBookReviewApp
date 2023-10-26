using Microsoft.AspNetCore.Http;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Data.Repositories;
using NavOS.Basecode.Resources.Views;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using NavOS.Basecode.Services.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NavOS.Basecode.Resources.Constants.Enums;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace NavOS.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        //Make sure that you have the IHttpContextAccessor properly injected into your BookService class. This is required to get the username of the logged-in user.
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookService(IBookRepository bookRepository, IHttpContextAccessor httpContextAccessor)
        {
            _bookRepository = bookRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddBook(BookViewModel bookViewModel)
        {
            // Get the username of the logged-in user

            string loggedInUser = _httpContextAccessor.HttpContext.User.Identity.Name;

            Book book = new()
            {
                BookId = Guid.NewGuid().ToString(),
                BookTitle = bookViewModel.BookTitle,
                Summary = bookViewModel.Summary,
                Author = bookViewModel.Author,
                Status = bookViewModel.Status,
                Genre = bookViewModel.Genre,
                Volume = bookViewModel.Volume,
                DateReleased = DateTime.Now,
                AddedBy = loggedInUser,
                AddedTime = DateTime.Now,
                UpdatedBy = loggedInUser,  // Also set UpdatedBy to the user creating the record
                UpdatedTime = DateTime.Now
            };
            _bookRepository.AddBook(book);
        }

        //public void DeleteBook(BookViewModel bookViewModel)
        //{
        //    Book book = new()
        //    {
        //        BookId = bookViewModel.BookId,
        //    };
        //    _bookRepository.DeleteBook(book);
        //}
        public List<Book> GetBooks()
        {
            _bookRepository.GetBooks();
            return _bookRepository.GetBooks();
        }
        public Book GetBook(string id)
        {
            var book = _bookRepository.GetBook(id);

            return book;
        }
        public bool UpdateBook(BookViewModel bookViewModel)
        {
            Book book = _bookRepository.GetBook(bookViewModel.BookId);
            if (book != null)
            {
                // Check if any property is actually modified
                if (
                    book.Author != bookViewModel.Author ||
                    book.Status != bookViewModel.Status || book.BookTitle != bookViewModel.BookTitle ||
                    book.Summary != bookViewModel.Summary || book.Genre != bookViewModel.Genre || book.Volume != bookViewModel.Volume)
                {
                    // Get the username of the logged-in user
                    string loggedInUser = _httpContextAccessor.HttpContext.User.Identity.Name;

                   
                    book.BookTitle = bookViewModel.BookTitle;
                    book.Summary = bookViewModel.Summary;
                    book.Author = bookViewModel.Author;
                    book.Status = bookViewModel.Status;
                    book.Genre = bookViewModel.Genre;
                    book.Volume = bookViewModel.Volume;
                    //book.DateReleased = DateTime.Now;
                    //book.AddedBy = loggedInUser;
                    //book.AddedTime = DateTime.Now;
                    book.UpdatedBy = loggedInUser;  // Also set UpdatedBy to the user creating the record
                    //book.UpdatedTime = DateTime.Now;

                    _bookRepository.UpdateBook(book);
                    return true;
                }
            }

            return false;
        }
        public bool DeleteBook(BookViewModel bookViewModel)
        {
            Book book = _bookRepository.GetBook(bookViewModel.BookId);
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
                return true;
            }

            return false;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        //get specific book details based on the bookService models
        public List<BookViewModel> GetBooks()
        {
            var data = _bookRepository.GetBooks().Select(s => new BookViewModel
            {
                BookId = s.BookId,
                BookTitle = s.BookTitle,
                Summary = s.Summary,
                Author = s.Author,
                Status = s.Status,
                Genre = s.Genre,
                Volume = s.Volume,
                DateReleased = s.DateReleased,
                AddedTime = s.AddedTime
            })
            .ToList();

            return data;
        }
        public BookViewModel GetBook(string BookId)
        {
            var book = _bookRepository.GetBooks().FirstOrDefault(s => s.BookId == BookId);

            if (book != null)
            {
                var bookViewModel = new BookViewModel
                {
                    BookId = book.BookId,
                    BookTitle = book.BookTitle,
                    Summary = book.Summary,
                    Author = book.Author,
                    Status = book.Status,
                    Genre = book.Genre,
                    Volume = book.Volume,
                    DateReleased = book.DateReleased,
                    AddedTime = book.AddedTime
                };
                return bookViewModel;
            }
            else
            {
                return null;
            }

        }

    }
}
