using BookWorlds.Data;
using BookWorlds.Data.Models;
using BookWorlds.Services.Contracts;
using BookWorlds.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Services
{
    public class BookService : IBookService
    {
        private BookWorldsDbContext context;

        public BookService(BookWorldsDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewBook(BookServiceModel book)
        {
            CheckRequiredProperties(book);

            //ToDo: Implement Exist() method in AuthorService
            var author = this.context.Authors.FirstOrDefault(x => x.Name == book.AuthorName);
            if (author == null)
            {
                author = new Author
                {
                    Name = book.AuthorName,
                };
                this.context.Authors.Add(author);
            }

            //ToDo
            var user = await this.context.Users.FirstAsync(x => x.Email == book.UserEmail.ToString());

            var bookForAdding = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Author = author,
                Images = book.Images,
                IsАvailable = true,
                User = user
            };

            this.context.Books.Add(bookForAdding);
            this.context.SaveChanges();
        }


        public bool DeleteBook()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
            =>  this.context.Books
                .Select(x => new Book
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    AuthorId = x.AuthorId,
                    Categories = x.Categories.ToList(),
                    Images = x.Images.ToList(),
                    Comments = x.Comments.ToList(),
                    UserId = x.UserId,
                }).ToList();


        private static void CheckRequiredProperties(BookServiceModel book)
        {
            if (book != null)
            {
                throw new ArgumentException("The model is null.");
            }
            if (book.Title != null)
            {
                throw new ArgumentException("The title is null.");
            }
            if (book.Description != null)
            {
                throw new ArgumentException("The description is null.");
            }
        }
    }
}
