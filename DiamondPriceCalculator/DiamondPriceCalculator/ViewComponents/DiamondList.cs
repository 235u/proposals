using ActinUranium.Proposals.DiamondPriceCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActinUranium.Proposals.DiamondPriceCalculator.ViewComponents
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
