using Microsoft.AspNetCore.Mvc;
using NavOS.Basecode.Services.Interfaces;
using NavOS.Basecode.Services.ServiceModels;
using NavOS.Basecode.Services.Services;

namespace NavOS.Basecode.AdminApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookService.AddBook(bookViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string BookId) 
        {
            var book = _bookService.GetBook(BookId); // the int Id used will be searched within the .GetBook(Id) if exists. If not exists then NotFound().
            if (book != null)
            {
                BookViewModel bookViewModel = new()
                {
                    BookId = BookId,
                    BookTitle = book.BookTitle,
                    Summary = book.Summary,
                    Author = book.Author,
                    Status = book.Status,
                    Genre = book.Genre,
                    Volume = book.Volume,
                };

                return View(bookViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel bookViewModel)
        {
            bool isUpdated = _bookService.UpdateBook(bookViewModel);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(BookViewModel bookViewModel)
        {
            bool isDeleted = _bookService.DeleteBook(bookViewModel);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
