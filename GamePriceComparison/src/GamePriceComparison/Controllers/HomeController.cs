using Microsoft.AspNetCore.Mvc;

namespace GamePriceComparison.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewComponentResult TopSellers()
        {
            return ViewComponent(nameof(TopSellers));
        }
    }
}
