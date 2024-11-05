using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterCondominium;

namespace FacilitaCondo.Application.Interfaces
{
    public interface IRegisterCondominiumUseCase
    {
        Task<RegisterCondominiumResponseDTO> Execute(RegisterCondominiumRequest request);
    }
}
