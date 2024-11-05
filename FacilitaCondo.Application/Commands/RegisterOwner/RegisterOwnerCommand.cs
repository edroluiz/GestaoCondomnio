using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterOwner;
using FacilitaCondo.Domain.Enums;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterOwnerCommand : IRequest<RegisterOwnerResponseDTO>
    {
        public Guid CondominiumId { get; set; }
        public Guid CondominiumManagerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public EResidenceType ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int ResidenceNumber { get; set; }
        public bool HasTenant { get; set; }
        public string? TenantEmail { get; set; }
        public string Password { get; set; }

        public RegisterOwnerCommand(Guid condominiumId, Guid condominiumManagerId, string name, string cpf, string email, EResidenceType residenceType, string? apartmentBlock, int residenceNumber, bool hasTenant, string? tenantEmail, string password)
        {
            CondominiumId = condominiumId;
            CondominiumManagerId = condominiumManagerId;
            Name = name;
            Cpf = cpf;
            Email = email;
            ResidenceType = residenceType;
            ApartmentBlock = apartmentBlock;
            ResidenceNumber = residenceNumber;
            HasTenant = hasTenant;
            TenantEmail = tenantEmail;
            Password = password;
        }

    }
}
