using Elmah;
using System;
using System.Web.Mvc;

namespace ElmahConfiguration.Controllers
{
public class HomeController : Controller
{
    public ActionResult Index()
    {
        RaiseErrorSignal();
        return RedirectToAction(actionName: "Index", controllerName: "elmah");
    }

    private static void RaiseErrorSignal()
    {
        try
        {
            throw new Exception(message: "Catch Me If You Can");
        }
        catch (Exception e)
        {
            ErrorSignal.FromCurrentContext().Raise(e);
        }
    }
}
}
