using FacilitaCondo.Domain.DTOs;
using FacilitaCondo.Domain.DTOs.RegisterCondominium;
using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;
using FacilitaCondo.Domain.DTOs.RegisterOwner;
using FacilitaCondo.Domain.DTOs.RegisterTenant;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Repository
{
    public interface IUserRepository
    {
        Task<RegisterCondominiumResponseDTO> RegisterCondominium(Condominium condominium);
        Task<RegisterCondominiumManagerResponseDTO> RegisterCondominiumManager(CondominiumManager condominiumManager);
        Task<RegisterOwnerResponseDTO> RegisterOwner(Owner owner);
        Task<RegisterTenantResponseDTO> RegisterTenant(Tenant tenant);
        Task<User> GetUserByUsernameAndPassword(string email, string password);
        Task<bool> SaveUserEmail(UserEmails userEmails);
        Task<bool> CheckEmailExists(string email);
    }
}
