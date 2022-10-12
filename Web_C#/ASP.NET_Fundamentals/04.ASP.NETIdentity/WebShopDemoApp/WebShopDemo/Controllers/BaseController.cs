using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebShopDemo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
