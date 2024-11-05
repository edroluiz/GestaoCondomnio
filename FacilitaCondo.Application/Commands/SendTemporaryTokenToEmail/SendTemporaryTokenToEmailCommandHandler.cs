using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Infrastructure.Services;
using FacilitaCondo.Shared.Exceptions;
using FacilitaCondo.Shared.Security;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class SendTemporaryTokenToEmailCommandHandler : IRequestHandler<SendTemporaryTokenToEmailCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenRepository _tokenRepository;
        private readonly EmailService _emailService;

        public SendTemporaryTokenToEmailCommandHandler(IUserRepository repository, ITokenRepository tokenRepository, EmailService emailService)
        {
            _repository = repository;
            _tokenRepository = tokenRepository;
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendTemporaryTokenToEmailCommand request, CancellationToken cancellationToken)
        {
            var checkEmailExists = await _repository.CheckEmailExists(request.Email);
            if (checkEmailExists == false)
            {
                throw new DomainException("Email não encontrado.");
            }

            var tokenGenerator = new TokenGenerator();
            var token = tokenGenerator.GenerateToken();
            var expiryTime = tokenGenerator.GetExpiryTime();

            await _tokenRepository.SaveTemporaryToken(request.Email, token, expiryTime);

            await _emailService.SendEmail(request.Email, token);

            return true;
        }
    }
}
