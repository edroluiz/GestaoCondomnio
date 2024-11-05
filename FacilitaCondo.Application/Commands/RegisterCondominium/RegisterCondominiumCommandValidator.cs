using FluentValidation;

namespace FacilitaCondo.Application.Commands.RegisterCondominium
{
    public class RegisterCondominiumCommandValidator : AbstractValidator<RegisterCondominiumCommand>
    {
        public RegisterCondominiumCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name must be provided!")
                .NotEmpty()
                .WithMessage("Name must be provided!");

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("Address must be provided!")
                .NotEmpty()
                .WithMessage("Address must be provided!");

            RuleFor(x => x.AddressNumber)
                .NotNull()
                .WithMessage("Address number must be provided!");

            RuleFor(x => x.NumberOfUnits)
                .NotNull()
                .WithMessage("Number of units must be provided!")
                .GreaterThan(0)
                .WithMessage("Number of units must be greater than zero.");

            RuleFor(x => x.ManagerEmail)
                .NotNull()
                .WithMessage("Manager email must be provided!")
                .NotEmpty()
                .WithMessage("Manager email must be provided!")
                .EmailAddress()
                .WithMessage("Invalid email address format.")
                .MaximumLength(100)
                .WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.ContactNumber)
                .NotNull()
                .WithMessage("Contact number must be provided!")
                .NotEmpty()
                .WithMessage("Contact number must be provided!")
                .MaximumLength(20)
                .WithMessage("Contact number cannot exceed 20 characters.");
        }
    }
}
