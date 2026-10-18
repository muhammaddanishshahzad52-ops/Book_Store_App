using hw_5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw_5.Controllers
{
    public class HomeController : Controller
    {

        private static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "United Kingdom" },
            new Author { Id = 2, Name = "George R.R. Martin", Country = "United States" }
        };

        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter and the Sorcerer's Stone", Price = 19.99m, AuthorId = 1 },
            new Book { Id = 2, Title = "A Game of Thrones", Price = 24.99m, AuthorId = 2 },
            new Book { Id = 3, Title = "A Clash of Kings", Price = 22.50m, AuthorId = 2 }
        };
        public IActionResult Index()
        {
            return View(books);
        }
        [HttpPost]
        public IActionResult AddAuthor(Author newAuthor)
        {
            int newId = 1;
            if (authors.Any())
            {
                newId = authors.Max(a => a.Id);
            }
            newAuthor.Id = newId;
            authors.Add(newAuthor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddBook(Book newBook)
        {
            int newId = 1;
            if(books.Any())
            {
                newId = books.Max(a=> a.Id);
            }
            newBook.Id = newId;

            books.Add(newBook);
            return RedirectToAction("Index");
        }
    }
}
