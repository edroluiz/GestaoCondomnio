using FacilitaCondo.Application.Requests;
using FacilitaCondo.Application.Responses;

namespace FacilitaCondo.Application.Interfaces
{
    public interface IGetAccessTokenUseCase
    {
        Task<GetAccessTokenResponse?> Execute(GetAccessTokenRequest request);
    }
}
