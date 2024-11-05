using FacilitaCondo.Domain.Enums;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterUserEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public EUserType UserType { get; set; }

        public RegisterUserEmailCommand(string email, EUserType userType)
        {
            Email = email;
            UserType = userType;
        }
    }
}
