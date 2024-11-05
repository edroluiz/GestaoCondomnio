using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Shared.Exceptions;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterUserEmailsCommandHandler : IRequestHandler<RegisterUserEmailsCommand, bool>
    {
        private readonly IUserRepository _repository;

        public RegisterUserEmailsCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RegisterUserEmailsCommand request, CancellationToken cancellationToken)
        {
            foreach (var userEmail in request.UserEmails)
            {
                var emailExists = await _repository.CheckEmailExists(userEmail.Email);
                if (emailExists)
                    throw new DomainException("Este email já foi registrado.");

                var save = await _repository.SaveUserEmail(userEmail);
                if (save == false)
                    return false;
            }

            return true;
        }
    }
}
