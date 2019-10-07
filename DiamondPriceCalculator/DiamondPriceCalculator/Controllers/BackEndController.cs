using Microsoft.AspNetCore.Mvc;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Controllers
{
    public class BackEndController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
