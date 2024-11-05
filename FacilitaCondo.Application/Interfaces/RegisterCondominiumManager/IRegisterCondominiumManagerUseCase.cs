using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;

namespace FacilitaCondo.Application.Interfaces
{
    public interface IRegisterCondominiumManagerUseCase
    {
        Task<RegisterCondominiumManagerResponseDTO> Execute(RegisterCondominiumManagerRequest request);
    }
}
