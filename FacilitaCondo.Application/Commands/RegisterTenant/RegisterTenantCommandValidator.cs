using FluentValidation;

namespace FacilitaCondo.Application.Commands.RegisterTenant
{
    public class RegisterTenantCommandValidator : AbstractValidator<RegisterTenantCommand>
    {
        public RegisterTenantCommandValidator()
        {
            //RuleFor(o => o.Name)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Name must be provided!");

            //RuleFor(o => o.Cpf)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("CPF must be provided!");

            //RuleFor(o => o.Email)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Email must be provided!");

            //RuleFor(o => o.Password)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Password must be provided!");
        }
    }
}
