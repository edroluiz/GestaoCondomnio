using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterOwner;

namespace FacilitaCondo.Application.Interfaces
{
    public interface IRegisterOwnerUseCase
    {
        Task<RegisterOwnerResponseDTO> Execute(RegisterOwnerRequest request);
    }
}
