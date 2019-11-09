using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityCustomization.Models
{
    public sealed class ApplicationUser : IdentityUser
    {
        public const int MaxStringLength = 64;

        [PersonalData]
        [MaxLength(MaxStringLength)]
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        public string MiddleName { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        public Gender Gender { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [PersonalData]
        public string FaxNumber { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        public string Extension { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }

        [PersonalData]
        public ApplicationUserCategory Category { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        public string Organization { get; set; }

        [PersonalData]
        [MaxLength(MaxStringLength)]
        public string BelongsTo { get; set; }
    }
}
