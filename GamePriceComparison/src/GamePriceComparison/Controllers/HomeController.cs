using Microsoft.AspNetCore.Mvc;
using GamePriceComparison.Services;

namespace GamePriceComparison.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppStore _store;

        public HomeController(AppStore store)
        {
            _store = store;
        }

        public ViewResult Index()
        {
            var model = _store.GetTopSellers();
            return View(model);
        }
    }
}
