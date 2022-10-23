using Library.Data;
using Library.Data.Entities;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext data;

        public BooksController(LibraryDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await data.Books
                .Include(c => c.Category)
                .AsNoTracking()
                .Select(b => new BookAllViewModel()
                {
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Id = b.Id,
                    Rating = b.Rating
                }).ToListAsync();

            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookAddViewModel model = new()
            {
                Categories = await GetCategoriesAsync()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(BookAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Adding");
                model.Categories = await GetCategoriesAsync();

                return View(model);
            }

            if (!(await this.data.Categories.AsNoTracking().ToListAsync()).Any(g => g.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.Categories = await GetCategoriesAsync();

                return View(model);
            }

            Book book = new()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Description = model.Description
            };

            await this.data.Books.AddAsync(book);
            await this.data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            Book book = await this.data.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null) return RedirectToAction(nameof(All));

            string currentUserId = GetCurrentUser();

            ApplicationUser user = await this.data.Users
                                       .Include(x => x.ApplicationUsersBooks)
                                       .FirstOrDefaultAsync(x => x.Id == currentUserId);

            if (user == null) return RedirectToAction(nameof(All));

            if (!user.ApplicationUsersBooks.Any(x => x.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = currentUserId,
                    Book = book,
                    ApplicationUser = user
                });

                await this.data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string currentUserId = GetCurrentUser();

            List<BooksMineViewModel> books = await this.data.Users
                            .Include(u => u.ApplicationUsersBooks)
                            .ThenInclude(m => m.Book)
                            .Where(u => u.Id == currentUserId)
                            .SelectMany(u => u.ApplicationUsersBooks.Select(x => new BooksMineViewModel()
                            {
                                Title = x.Book.Title,
                                Description = x.Book.Description,
                                Category = x.Book.Category.Name,
                                Id = x.BookId,
                                ImageUrl = x.Book.ImageUrl,
                                Author = x.Book.Author

                            }).ToList())
                            .ToListAsync();

            if (books == null) throw new ArgumentException("Invalid user ID");

            return View(books);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            string currentUserId = GetCurrentUser();

            ApplicationUser user = 
                await this.data.Users.Include(x => x.ApplicationUsersBooks).FirstOrDefaultAsync(x => x.Id == currentUserId);
            if (user == null) return RedirectToAction(nameof(Mine));

            ApplicationUserBook book = user.ApplicationUsersBooks.FirstOrDefault(x => x.BookId == bookId);
            if (book == null) return RedirectToAction(nameof(Mine));

            user.ApplicationUsersBooks.Remove(book);
            await this.data.SaveChangesAsync();

            return RedirectToAction(nameof(Mine));
        }

        private string GetCurrentUser() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await this.data.Categories.AsNoTracking().ToListAsync();

    }
}
