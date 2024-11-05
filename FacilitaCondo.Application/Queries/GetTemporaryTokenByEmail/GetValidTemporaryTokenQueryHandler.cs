using FacilitaCondo.Domain.Repository;
using MediatR;

namespace FacilitaCondo.Application.Queries
{
    public class GetValidTemporaryTokenQueryHandler : IRequestHandler<GetValidTemporaryTokenQuery, bool>
    {
        private readonly ITokenRepository _tokenRepository;

        public GetValidTemporaryTokenQueryHandler(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<bool> Handle(GetValidTemporaryTokenQuery request, CancellationToken cancellationToken)
        {
            return await _tokenRepository.GetValidTemporaryToken(request.Token);
        }
    }
}
