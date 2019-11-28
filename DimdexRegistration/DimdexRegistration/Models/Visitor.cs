using System.ComponentModel.DataAnnotations;

namespace DimdexRegistration.Models
{
    public class Visitor
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Title/Rank*")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "First/Given Name*")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Family Name*")]
        public string FamilyName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Job Title*")]
        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Company Name*")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nationality*")]
        public string Nationality { get; set; }

        [Display(Name = "Country Code", Prompt = "Select Code")]
        public string TelephoneCountryCode { get; set; }

        [Phone]
        public string Telephone { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Country Code*", Prompt = "Select Code")]
        public string MobileCountryCode { get; set; }

        [Phone]
        [Required(AllowEmptyStrings = false)]        
        [Display(Name = "Mobile*")]
        public string Mobile { get; set; }

        [EmailAddress]
        [Required(AllowEmptyStrings = false)]        
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Upload Passport/ID copy*")]
        public byte[] PassportCopy { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PassportCopyMimeType { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Your main reason for attending DIMDEX 2020")]
        public string ReasonForAttending { get; set; }
    }
}
