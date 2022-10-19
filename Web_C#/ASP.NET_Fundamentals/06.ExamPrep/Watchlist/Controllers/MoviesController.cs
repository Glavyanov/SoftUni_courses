using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext data;
        public MoviesController(WatchlistDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await this.data.Movies
                .Include(x => x.Genre)
                .AsNoTracking()
                .Select(m => new MoviesAllViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Genre = m.Genre.Name,
                    Rating = m.Rating

                }).ToListAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            MoviesAddViewModel model = new()
            {
                Genres = await GetGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MoviesAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Adding");
                model.Genres = await GetGenres();

                return View(model);
            }

            if (!(await this.data.Genres.AsNoTracking().ToListAsync()).Any(g => g.Id == model.GenreId))
            {
                ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist");
                model.Genres = await GetGenres();

                return View(model);
            }

            Movie movie = new()
            {
                Title = model.Title,
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            await this.data.Movies.AddAsync(movie);
            await this.data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private async Task<IEnumerable<Genre>> GetGenres() => await this.data.Genres.AsNoTracking().ToListAsync();
    }
}
