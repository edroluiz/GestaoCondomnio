using AutoMapper;
using FacilitaCondo.Application.Responses.RegisterCondominiumManager;
using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;

namespace FacilitaCondo.Application.Mappers.RegisterCondominiumManager
{
    public class RegisterCondominiumManagerMapper : Profile
    {
        public RegisterCondominiumManagerMapper()
        {
            CreateMap<RegisterCondominiumManagerResponseDTO, RegisterCondominiumManagerResponse>();
        }
    }
}
