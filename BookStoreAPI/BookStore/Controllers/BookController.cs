using Microsoft.AspNetCore.Mvc;
using BookStore.repository;
using BookStore.models.Models;
using BookStore.models.ViewModels;
namespace BookStore.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : Controller
    {
        BookRepository repository = new BookRepository();
        [HttpGet]
        [Route("list")]
        public IActionResult GetBooks(int pageindex=1,int pagesize=10,string? keyword="")
        {
            var books=repository.GetBooks(pageindex,pagesize,keyword);
            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                records=books.records.Select(c=>new BookModel(c)),
                totalRecords=books.totalRecords,
            };
            return Ok(listResponse);
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
                var books = repository.GetBook(id);
            if (books == null)
            {
                return NotFound();
            }
                return Ok(books);
            
            //BookModel bookModel = new BookModel(books);
            
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddBook(BookModel model)
        {
            if(model == null)
            {
                return BadRequest("value not must be null");
            }
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,

        };
                var books = repository.AddBook(book);
                return Ok(books);
            //BookModel bookModel = new BookModel(books);

        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateBook(BookModel model)
        {
            if (model == null)
            {
                return BadRequest("value not must be null");
            }
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,

            };
            var books = repository.UpdateBook(book);
            return Ok(books);
        }
        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult RemoveBook(int id)
        {
            if (id == 0)
            {
                return BadRequest("value not must be null");
            }
           var books = repository.DeleteBook(id);
            if (books == false)
            {
                return BadRequest("enter valid id");
            }
            return Ok("book Deleted Successfully");
        }
    }
}
