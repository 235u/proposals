using Microsoft.AspNetCore.Mvc;

namespace DiamondPriceCalculator.Web.Controllers
{
    public class BackEndController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
