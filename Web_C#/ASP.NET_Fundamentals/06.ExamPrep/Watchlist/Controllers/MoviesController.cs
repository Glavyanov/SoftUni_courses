using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Claims;
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

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            Movie movie = await this.data.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == movieId);
            if (movie == null) return RedirectToAction(nameof(All));

            string currentUserId = GetCurrentUser();
            User user = await this.data.Users
                                       .Include(x => x.UsersMovies)
                                       .FirstOrDefaultAsync(x => x.Id == currentUserId);

            if(user == null) return RedirectToAction(nameof(All));

            if (!user.UsersMovies.Any(x => x.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movieId,
                    UserId = currentUserId,
                    Movie = movie,
                    User = user
                });

                await this.data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string currentUserId = GetCurrentUser();
            List<MoviesAllViewModel> movies = await this.data.Users
                            .Include(u => u.UsersMovies)
                            .ThenInclude(m => m.Movie)
                            .Where(u => u.Id == currentUserId)
                            .SelectMany(u => u.UsersMovies.Select(x => new MoviesAllViewModel()
                            {
                                Title = x.Movie.Title,
                                Director = x.Movie.Director,
                                Genre = x.Movie.Genre.Name,
                                Id = x.MovieId,
                                ImageUrl = x.Movie.ImageUrl,
                                Rating = x.Movie.Rating,

                            }).ToList())
                            .ToListAsync();

            if (movies == null) throw new ArgumentException("Invalid user ID");

            return View(movies);
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            UserMovie movie = await this.data.UsersMovies
                .FirstOrDefaultAsync(x => x.MovieId == movieId);

            if (movie == null) return RedirectToAction(nameof(Watched));

            string currentUserId = GetCurrentUser();
            User user = await this.data.Users
                                       .Include(x => x.UsersMovies)
                                       .FirstOrDefaultAsync(x => x.Id == currentUserId);

            if (user == null) return RedirectToAction(nameof(Watched));

            if (user.UsersMovies.Any(x => x.MovieId == movieId))
            {
                user.UsersMovies.Remove(movie);

                await this.data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Watched));
        }

        private async Task<IEnumerable<Genre>> GetGenres() => await this.data.Genres.AsNoTracking().ToListAsync();

        private string GetCurrentUser() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
