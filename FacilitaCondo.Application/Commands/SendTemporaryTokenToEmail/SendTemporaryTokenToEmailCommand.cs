using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class SendTemporaryTokenToEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public SendTemporaryTokenToEmailCommand(string email)
        {
            Email = email;
        }
    }
}
