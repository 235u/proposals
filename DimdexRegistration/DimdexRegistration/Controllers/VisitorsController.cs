using DimdexRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace DimdexRegistration.Controllers
{
    public class VisitorsController : Controller
    {
        public ViewResult Register()
        {
            var model = new Visitor();
            return View(model);
        }
    }
}
