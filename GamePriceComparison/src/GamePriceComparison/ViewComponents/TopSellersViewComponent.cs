using GamePriceComparison.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamePriceComparison.ViewComponents
{
    public class TopSellersViewComponent : ViewComponent
    {
        private readonly AppStore _store;

        public TopSellersViewComponent(AppStore store)
        {
            _store = store;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _store.GetTopSellersAsync();
            return View(model);
        }
    }
}
