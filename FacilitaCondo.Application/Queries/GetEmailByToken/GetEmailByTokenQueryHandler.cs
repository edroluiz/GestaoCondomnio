using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Shared.Exceptions;
using MediatR;

namespace FacilitaCondo.Application.Queries
{
    public class GetEmailByTokenQueryHandler : IRequestHandler<GetEmailByTokenQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public GetEmailByTokenQueryHandler(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> Handle(GetEmailByTokenQuery request, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.GetTokenInfo(request.Token);

            var email = token.Email;

            var checkEmailExists = await _userRepository.CheckEmailExists(email);
            if (checkEmailExists == false)
                throw new DomainException("Email não encontrado.");

            if (token == null || token.ExpirationDate < DateTime.Now)
                throw new DomainException("Token inválido ou expirado.");


            return email;
        }
    }
}
