using NavOS.Basecode.Data;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Data.Models;
using NavOS.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Services.Interfaces
{
    public interface IBookService
    {
        public void AddBook(BookViewModel bookViewModel);
        public bool DeleteBook(BookViewModel bookViewModel);
        public List<Book> GetBooks();
        public Book GetBook(string id);

        public bool UpdateBook(BookViewModel bookViewModel);


        List<BookViewModel> GetBooks();
        public BookViewModel GetBook(string BookId);
    }
}
