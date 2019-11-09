using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using IdentityCustomization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityCustomization.Helpers;

namespace IdentityCustomization.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public static IEnumerable<SelectListItem> Genera { get; } =
            SelectListHelper.CreateSelectListItems<Gender>();

        public static IEnumerable<SelectListItem> Categories { get; } =
            SelectListHelper.CreateSelectListItems<ApplicationUserCategory>();

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Required(AllowEmptyStrings = false)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            public Gender Gender { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Required(AllowEmptyStrings = false)]
            public string Title { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Phone]
            [Display(Name = "Fax number")]
            public string FaxNumber { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            public string Extension { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Required(AllowEmptyStrings = false)]
            public string City { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Required(AllowEmptyStrings = false)]
            public string Country { get; set; }

            public ApplicationUserCategory Category { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            public string Organization { get; set; }

            [StringLength(ApplicationUser.MaxStringLength)]
            [Display(Name = "Belongs to")]
            public string BelongsTo { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    MiddleName = Input.MiddleName,
                    LastName = Input.LastName,
                    Gender = Input.Gender,
                    Title = Input.Title,
                    PhoneNumber = Input.PhoneNumber,
                    FaxNumber = Input.FaxNumber,
                    Extension = Input.Extension,
                    City = Input.City,
                    Country = Input.Country,
                    Category = Input.Category,
                    Organization = Input.Organization,
                    BelongsTo = Input.BelongsTo
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
