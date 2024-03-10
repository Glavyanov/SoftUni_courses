using Microsoft.AspNetCore.Mvc;

namespace Watchlist.ViewComponents
{
    public class FooterCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(bool show) => View(show);
    }
}
