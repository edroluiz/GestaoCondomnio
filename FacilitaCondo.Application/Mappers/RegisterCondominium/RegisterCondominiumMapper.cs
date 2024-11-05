using AutoMapper;
using FacilitaCondo.Application.Responses;
using FacilitaCondo.Domain.DTOs.RegisterCondominium;

namespace FacilitaCondo.Application.Mappers
{
    public class RegisterCondominiumMapper : Profile
    {
        public RegisterCondominiumMapper()
        {
            CreateMap<RegisterCondominiumResponseDTO, RegisterCondominiumResponse>();
        }
    }
}
