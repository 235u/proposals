using DimdexRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace DimdexRegistration.Controllers
{
    public class VisitorsController : Controller
    {
        public ViewResult Create()
        {
            var model = new Visitor();
            return View(model);
        }
    }
}
