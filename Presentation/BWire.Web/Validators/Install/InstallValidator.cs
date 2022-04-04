using FluentValidation;
using BWire.Data;
using BWire.Web.Framework.Validators;
using BWire.Web.Infrastructure.Installation;
using BWire.Web.Models.Install;

namespace BWire.Web.Validators.Install
{
    public partial class InstallValidator : BaseNopValidator<InstallModel>
    {
        public InstallValidator(IInstallationLocalizationService locService)
        {
            RuleFor(x => x.AdminEmail).NotEmpty().WithMessage(locService.GetResource("AdminEmailRequired"));
            RuleFor(x => x.AdminEmail).EmailAddress();
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage(locService.GetResource("AdminPasswordRequired"));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(locService.GetResource("ConfirmPasswordRequired"));
            RuleFor(x => x.AdminPassword).Equal(x => x.ConfirmPassword).WithMessage(locService.GetResource("PasswordsDoNotMatch"));

            RuleFor(x => x.DataProvider).NotEqual(DataProviderType.Unknown).WithMessage(locService.GetResource("DataProviderRequired"));
            RuleFor(x => x.ConnectionString)
                .NotEmpty()
                .When(x => x.ConnectionStringRaw)
                .WithMessage(locService.GetResource("ConnectionStringRequired"));

            When(x => !x.ConnectionStringRaw, () =>
            {
                RuleFor(x => x.ServerName).NotEmpty().WithMessage(locService.GetResource("ServerNameRequired"));
                RuleFor(x => x.DatabaseName).NotEmpty().WithMessage(locService.GetResource("ConnectionStringRequired"));

                When(x => !x.IntegratedSecurity, () =>
                {
                    RuleFor(x => x.Username).NotEmpty().WithMessage(locService.GetResource("SqlUsernameRequired"));
                    RuleFor(x => x.Password).NotEmpty().WithMessage(locService.GetResource("SqlPasswordRequired"));
                });
            });

        }
    }
}