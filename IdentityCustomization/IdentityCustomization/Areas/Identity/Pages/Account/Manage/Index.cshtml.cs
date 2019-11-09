using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IdentityCustomization.Helpers;
using IdentityCustomization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityCustomization.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public static IEnumerable<SelectListItem> Genera { get; } =
            SelectListHelper.CreateSelectListItems<Gender>();

        public static IEnumerable<SelectListItem> Categories { get; } =
            SelectListHelper.CreateSelectListItems<ApplicationUserCategory>();

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
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

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Gender = user.Gender,
                Title = user.Title,
                FaxNumber = user.FaxNumber,
                Extension = user.Extension,
                City = user.City,
                Country = user.Country,
                Category = user.Category,
                Organization = user.Organization,
                BelongsTo = user.BelongsTo
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            user.FirstName = Input.FirstName;
            user.MiddleName = Input.MiddleName;
            user.LastName = Input.LastName;
            user.Gender = Input.Gender;
            user.Title = Input.Title;
            user.FaxNumber = Input.FaxNumber;
            user.Extension = Input.Extension;
            user.City = Input.City;
            user.Country = Input.Country;
            user.Category = Input.Category;
            user.Organization = Input.Organization;
            user.BelongsTo = Input.BelongsTo;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
