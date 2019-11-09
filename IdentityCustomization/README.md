# Issues

See Requirements.pdf

## Login

Login by (mobile) phone number not implemented.

## Two-Factor Authentication



## Registration

- `Middle name` should not be required; field name casing (`FirstName` instead of `Firstname`);
- `Title` dropdown values not provided;
- `Tel` is already available as `PhoneNumber`; phone number confirmation not implemented;
- `FaxNumber` instead of `Fax`;
- `Extension` field is confusing (what for / does it extend);
- `City` dropdown values not provided;
- `Country` dropdown values not provided;
- `Belongs to` dropdown values not provided; field name spelling (`BelongsTo` instead of `Belongto`).

### Notes

- Organizations usually dont have first name, middle name, last name, title and have neuter gender;
- all new fields decorated with the [PersonalData](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.personaldataattribute) attribute, see [Add custom user data to the Identity DB](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/add-user-data) for details;
- max length of the text fields set to 64 characters (via [MaxLength](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.maxlengthattribute) attribute).

## Categories

`Enum` instead of table, ignoring `id` and `BSMCode` fields (purpose unclear).

## Roles

- `RoleCode` and `CreationDate` fields ignored (purpose unclear; use already existing `Id`, `NormalizedName`, and `ConcurrencyStamp` fields instead); 
- `MedicalCompany` instead of `MedicalCompanyAdmin`;
- `HealthcareProvider` instead of `HealthcareProviderAdmin`;
- `DependentPractitioner` instead of `DependentPractitionorUser`;
- `IndependentPractitioner` instead of `InDependentPractitioner`;
- `DependentRepresentative` instead of `DependentRepresentativeUser`;
- `IndependentRepresentative` instead of `InDependentRepresentativeUser`;

## Pages

- `MedicalCompany.cshtml` instead of `CompanyAdmin Index.cshtml`;
- `HealthcareProvider.cshtml` instead of `HealthcareProviderAdminIndex.cshtml`;
- `DependentPractitioner.cshtml` instead of `DPractitionerIndex.cshtml`;
- `IndependentPractitioner.cshtml` instead of `IDPractitionerIndex.cshtml`;
- `DependentRepresentative.cshtml` instead of `DRepresentativeIndex.cshtml`;
- `IndependentRepresentative.cshtml` instead of `IDRepresentativeIndex.cshtml`;

