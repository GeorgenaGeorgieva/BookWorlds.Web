using BookWorlds.Data.Models;
using BookWorlds.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Services.Contracts
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Task AddNewBook(BookServiceModel book);
        bool DeleteBook();
    }
}
