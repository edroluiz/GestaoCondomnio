using AutoMapper;
using FacilitaCondo.Application.Responses.RegisterOwner;
using FacilitaCondo.Domain.DTOs.RegisterOwner;

namespace FacilitaCondo.Application.Mappers.RegisterOwner
{
    public class RegisterOwnerMapper : Profile
    {
        public RegisterOwnerMapper()
        {
            CreateMap<RegisterOwnerResponseDTO, RegisterOwnerResponse>();
        }
    }
}
