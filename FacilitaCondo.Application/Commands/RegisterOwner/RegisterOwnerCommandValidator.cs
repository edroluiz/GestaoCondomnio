using FluentValidation;

namespace FacilitaCondo.Application.Commands.RegisterOwner
{
    public class RegisterOwnerCommandValidator : AbstractValidator<RegisterOwnerCommand>
    {
        public RegisterOwnerCommandValidator()
        {
            RuleFor(o => o.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name must be provided!");

            RuleFor(o => o.Cpf)
                .NotNull()
                .NotEmpty()
                .WithMessage("CPF must be provided!");

            RuleFor(o => o.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email must be provided!");

            RuleFor(o => o.ResidenceType)
                .NotNull()
                .NotEmpty()
                .WithMessage("ResidenceType must be provided!");

            RuleFor(o => o.ResidenceNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("ResidenceNumber must be provided!");

            RuleFor(o => o.HasTenant)
                .NotNull()
                .NotEmpty()
                .WithMessage("HasTenant must be provided!");

            RuleFor(o => o.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password must be provided!");
        }
    }
}
