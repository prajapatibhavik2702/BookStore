using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;
namespace BookStore.repository
{
    public class BookRepository
    {
        testContext _context = new testContext();
        public ListResponse<Book> GetBooks(int pageindex,int pagesize, string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query=_context.Books.Where(c=>keyword==null||c.Name.ToLower().Contains(keyword)).AsQueryable();
            var total=query.Count();    
            List<Book> books= query.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new ListResponse<Book>()
            {
                totalRecords=total,
                records=books
            };

        }
        public Book GetBook(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var book=_context.Books.FirstOrDefault(c=>c.Id==id);
            return book;
        }
        public Book AddBook(Book b)
        {
            var book = _context.Books.Add(b);
            _context.SaveChanges();
            return book.Entity;
        }
        public Book UpdateBook(Book b)
        {
            var book = _context.Books.Update(b);
            _context.SaveChanges();
            return book.Entity;
        }
        public bool DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(c => c.Id == id);
            if (book != null)
            {
                var entry = _context.Books.Remove(book);
                _context.SaveChanges();
                return Book.Entity;
            }

            return Book.Entity;
        }
    }
}
