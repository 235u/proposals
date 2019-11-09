using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityCustomization.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IdentityCustomization.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            switch (user.Category)
            {
                case ApplicationUserCategory.MedicalCompany:
                    return RedirectToAction(nameof(MedicalCompany));

                case ApplicationUserCategory.HealthcareProvider:
                    return RedirectToAction(nameof(HealthcareProvider));

                case ApplicationUserCategory.DependentPractitioner:
                    return RedirectToAction(nameof(DependentPractitioner));

                case ApplicationUserCategory.IndependentPractitioner:
                    return RedirectToAction(nameof(IndependentPractitioner));

                case ApplicationUserCategory.DependentRepresentative:
                    return RedirectToAction(nameof(DependentRepresentative));

                case ApplicationUserCategory.IndependentRepresentative:
                    return RedirectToAction(nameof(IndependentRepresentative));

                default:
                    return RedirectToAction(nameof(Error));
            }
        }

        [Authorize(Roles = ApplicationRoleName.MedicalCompany)]
        public ViewResult MedicalCompany()
        {
            return View();
        }

        [Authorize(Roles = ApplicationRoleName.HealthcareProvider)]
        public ViewResult HealthcareProvider()
        {
            return View();
        }

        [Authorize(Roles = ApplicationRoleName.DependentPractitioner)]
        public ViewResult DependentPractitioner()
        {
            return View();
        }

        [Authorize(Roles = ApplicationRoleName.IndependentPractitioner)]
        public ViewResult IndependentPractitioner()
        {
            return View();
        }

        [Authorize(Roles = ApplicationRoleName.DependentRepresentative)]
        public ViewResult DependentRepresentative()
        {
            return View();
        }

        [Authorize(Roles = ApplicationRoleName.IndependentRepresentative)]
        public ViewResult IndependentRepresentative()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
