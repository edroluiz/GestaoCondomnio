using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterTenant;

namespace FacilitaCondo.Application.Interfaces.RegisterTenant
{
    public interface IRegisterTenantUseCase
    {
        Task<RegisterTenantResponseDTO> Execute(RegisterTenantRequest request);
    }
}
