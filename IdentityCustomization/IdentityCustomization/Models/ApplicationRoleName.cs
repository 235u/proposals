using System.Collections.Generic;

namespace IdentityCustomization.Models
{
    public static class ApplicationRoleName
    {
        public const string MedicalCompany = nameof(MedicalCompany);
        public const string HealthcareProvider = nameof(HealthcareProvider);
        public const string DependentPractitioner = nameof(DependentPractitioner);
        public const string IndependentPractitioner = nameof(IndependentPractitioner);
        public const string DependentRepresentative = nameof(DependentRepresentative);
        public const string IndependentRepresentative = nameof(IndependentRepresentative);
        public const string Administrator = nameof(Administrator);

        public static readonly List<string> All = new List<string>
        {
            MedicalCompany,
            HealthcareProvider,
            DependentPractitioner,
            IndependentPractitioner,
            DependentRepresentative,
            IndependentRepresentative,
            Administrator
        };

        public static readonly Dictionary<ApplicationUserCategory, string> ByCategory =
            new Dictionary<ApplicationUserCategory, string>()
            {
                [ApplicationUserCategory.MedicalCompany] = MedicalCompany,
                [ApplicationUserCategory.HealthcareProvider] = HealthcareProvider,
                [ApplicationUserCategory.DependentPractitioner] = DependentPractitioner,
                [ApplicationUserCategory.IndependentPractitioner] = IndependentPractitioner,
                [ApplicationUserCategory.DependentRepresentative] = DependentRepresentative,
                [ApplicationUserCategory.IndependentRepresentative] = IndependentRepresentative
            };
    }
}
