using System.ComponentModel.DataAnnotations;

namespace IdentityCustomization.Models
{
    public enum ApplicationUserCategory
    {
        [Display(Name = "Medical Sales/Marketing Company")]
        MedicalCompany,

        [Display(Name = "Healthcare Provider")]
        HealthcareProvider,
        
        [Display(Name = "Dependent Practitioner")]
        DependentPractitioner,

        [Display(Name = "Independent Practitioner")]
        IndependentPractitioner,

        [Display(Name = "Dependent Medical Sales/Marketing Representative")]
        DependentRepresentative,

        [Display(Name = "Independent Medical Sales/Marketing Representative")]
        IndependentRepresentative
    }
}
