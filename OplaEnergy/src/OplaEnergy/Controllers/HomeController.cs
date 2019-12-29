using Microsoft.AspNetCore.Mvc;

namespace OplaEnergy.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
