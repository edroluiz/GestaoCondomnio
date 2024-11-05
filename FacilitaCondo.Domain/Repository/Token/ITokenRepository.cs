using FacilitaCondo.Domain.Entities;

namespace FacilitaCondo.Domain.Repository
{
    public interface ITokenRepository
    {
        Task SaveTemporaryToken(string email, string token, DateTime expirationDate);
        Task<bool> GetValidTemporaryToken(string token);
        Task<TemporaryTokens> GetTokenInfo(string token);
    }
}
