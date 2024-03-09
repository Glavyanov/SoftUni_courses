using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;

namespace Watchlist.ViewComponents
{
    public class ListInfoViewComponent : ViewComponent
    {
        private readonly IMovieService movieService;

        public ListInfoViewComponent(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var allFilmsTitles = await this.movieService.GetTitlesAsync(count);

            return View(allFilmsTitles);
        }
    }
}
