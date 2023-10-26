using NavOS.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Data.Interfaces
{
    public interface IBookRepository
    {
//<<<<<<< Taboada
        public void AddBook(Book book);
        public List<Book> GetBooks();
        public void DeleteBook(Book book);
        public Book GetBook(string BookId);
        public void UpdateBook(Book book);
//=======
        //get all books
        IQueryable<Book> GetBooks();
        //get single book
        IQueryable<Book> GetBook(string BookId);
//>>>>>>> main
    }
}
