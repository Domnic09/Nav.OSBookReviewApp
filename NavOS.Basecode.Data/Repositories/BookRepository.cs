using Basecode.Data.Repositories;
using NavOS.Basecode.Data.Interfaces;
using NavOS.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavOS.Basecode.Data.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        //create a ctor contructor
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        //create a function or method

        //add Book
        public void AddBook(Book book)
        {
            this.GetDbSet<Book>().Add(book);
            UnitOfWork.SaveChanges();
        }

        //get all books
        public List<Book> GetBooks()
        {
            var books = GetDbSet<Book>().ToList();
            return books;
        }

       
        //retrieve single book
        public Book GetBook(string id)
        {
            var book = this.GetDbSet<Book>().FirstOrDefault(x => x.BookId == id);
            return book;
        }
        //update book
        public void UpdateBook(Book book)
        {
            this.GetDbSet<Book>().Update(book);
            UnitOfWork.SaveChanges();
        }

        //delete Book
        public void DeleteBook(Book book)
        {
            this.GetDbSet<Book>().Remove(book);
            UnitOfWork.SaveChanges();
        }

    }

}
