using Microsoft.AspNetCore.Mvc.Filters;
using Watchlist.Contracts;

namespace Watchlist.Filters
{
    public class MyActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var movieService = context.HttpContext.RequestServices.GetService<IMovieService>();// this is a object locator

            base.OnActionExecuting(context);
        }
    }
}
