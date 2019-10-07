using ActinUranium.Proposals.DiamondPriceCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Controllers
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
