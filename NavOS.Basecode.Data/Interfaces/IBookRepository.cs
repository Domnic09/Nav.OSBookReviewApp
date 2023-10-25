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
        public void AddBook(Book book);
        public List<Book> GetBooks();
        public void DeleteBook(Book book);
        public Book GetBook(string BookId);
        public void UpdateBook(Book book);
    }
}
