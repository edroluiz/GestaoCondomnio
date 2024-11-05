using FluentValidation;

namespace FacilitaCondo.Application.Commands.RegisterCondominiumManager
{
    public class RegisterCondominiumManagerCommandValidator : AbstractValidator<RegisterCondominiumManagerCommand>
    {
        public RegisterCondominiumManagerCommandValidator()
        {
            RuleFor(o => o.Name)
                .NotNull()
                .WithMessage("Name must be provided!")
                .NotEmpty()
                .WithMessage("Name must be provided!");

            RuleFor(o => o.Cpf)
                .NotNull()
                .WithMessage("CPF must be provided!")
                .NotEmpty()
                .WithMessage("CPF must be provided!");

            RuleFor(o => o.Email)
                .NotNull()
                .WithMessage("Email must be provided!")
                .NotEmpty()
                .WithMessage("Email must be provided!");

            RuleFor(o => o.IsResident)
                .NotNull()
                .WithMessage("IsResident must be provided!")
                .NotEmpty()
                .WithMessage("IsResident must be provided!");

            RuleFor(o => o.Password)
                .NotNull()
                .WithMessage("Password must be provided!")
                .NotEmpty()
                .WithMessage("Password must be provided!");
        }
    }
}
