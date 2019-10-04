using DiamondPriceCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiamondPriceCalculator.Web.Controllers
{
    public class FrontEndController : Controller
    {
        public IActionResult Index()
        {
            var model = new RingInfo();
            return View(model);
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
