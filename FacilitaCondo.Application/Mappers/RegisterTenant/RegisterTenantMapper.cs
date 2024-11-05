using AutoMapper;
using FacilitaCondo.Application.Responses.RegisterTenant;
using FacilitaCondo.Domain.DTOs.RegisterTenant;

namespace FacilitaCondo.Application.Mappers.RegisterTenant
{
    public class RegisterTenantMapper : Profile
    {
        public RegisterTenantMapper()
        {
            CreateMap<RegisterTenantResponseDTO, RegisterTenantResponse>();
        }
    }
}
