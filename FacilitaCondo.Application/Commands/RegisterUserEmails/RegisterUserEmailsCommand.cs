using FacilitaCondo.Domain.Entities;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterUserEmailsCommand : IRequest<bool>
    {
        public List<UserEmails> UserEmails { get; set; }

        public RegisterUserEmailsCommand(List<UserEmails> userEmails)
        {
            UserEmails = userEmails;
        }
    }
}

