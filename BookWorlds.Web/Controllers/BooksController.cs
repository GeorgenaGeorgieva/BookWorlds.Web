using BookWorlds.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookWorlds.Web.Controllers
{
    public class BooksController : Controller
    {
        private IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = this.bookService.GetAllBooks();
            return View(books);
        }

        //[HttpPost]
        //public IActionResult AddBook() 
        //{ 
        //}
    }
}
