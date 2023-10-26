using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NavOS.Basecode.BookApp.Mvc;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using System;
using System.Linq;

namespace NavOS.Basecode.BookApp.Controllers
{
    public class BookController : ControllerBase<BookController>
    {
        private readonly IBookService _bookService;
        private readonly IReviewService _reviewService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public BookController(IBookService bookService,
                              IReviewService reviewService,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _bookService = bookService;
            _reviewService = reviewService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _bookService.GetBooks();
            return View(data);
        }
        [HttpGet]
        public IActionResult ViewNewBooks(string searchQuery)
        {
            var currentDate = DateTime.Now;

            // Calculate the date two weeks ago
            var twoWeeksAgo = currentDate.AddDays(-14);

            // Filter and sort the books
            var data = _bookService.GetBooks()
                // Filter books added in the last two weeks
                .Where(book => book.AddedTime >= twoWeeksAgo)
                // Sort by AddedTime in descending order
                .OrderByDescending(book => book.AddedTime)
                .ToList();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // If a search query is provided, filter the books based on the query
                data = data.Where(book => book.Genre.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult ViewTopBooks(string searchQuery)
        {
            // Get all books from your service
            var data = _bookService.GetBooks();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                // If a search query is provided, filter the books based on the query
                data = data.Where(book => book.Genre.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort the filtered books by AddedTime in descending order
            data = data.OrderByDescending(book => book.AddedTime).ToList();

            return View(data);
        }
        [HttpGet]
        public IActionResult Search(string query)
        {
            var books = _bookService.GetBooks();

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim().ToLower();
                books = books.Where(book => book.BookTitle.ToLower().Contains(query)).ToList();
            }

            if (books.Any())
            {
                return PartialView("_SearchResultsPartial", books);
            }
            else
            {
                return Content("No books found");
            }
        }
        public IActionResult ViewSingleBook(string BookId)
        {
            var book = _bookService.GetBook(BookId);
            if (book != null)
            {
                var reviews = _reviewService.GetReviews();

                // Store reviews in ViewData
                ViewData["Reviews"] = reviews;

                return View(book);
            }
            return NotFound();
        }

        public IActionResult GetReviews()
        {
            var data = _reviewService.GetReviews();
            return RedirectToAction("ViewSingleBook", new { data });
        }

        public IActionResult AddReview(ReviewViewModel review)
        {
            _reviewService.AddReview(review);
            return RedirectToAction("ViewSingleBook", new { review.BookId });
        }

    }
}
