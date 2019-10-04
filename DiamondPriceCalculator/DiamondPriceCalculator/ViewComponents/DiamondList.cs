using DiamondPriceCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiamondPriceCalculator.Web.ViewComponents
{
    public class DiamondList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = DiamondInventory.Create();
            return View(model);
        }
    }
}
