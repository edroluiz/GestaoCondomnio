using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;
using FacilitaCondo.Domain.Enums;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterCondominiumManagerCommand : IRequest<RegisterCondominiumManagerResponseDTO>
    {
        public Guid CondominiumId { get; set; }
        public string TemporaryToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool IsResident { get; set; }
        public EResidenceType? ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int? ResidenceNumber { get; set; }
        public string Password { get; set; }

        public RegisterCondominiumManagerCommand(Guid condominiumId, string temporaryToken, string email, string name, string cpf, bool isResident, EResidenceType? residenceType, string? apartmentBlock, int? residenceNumber, string password)
        {
            CondominiumId = condominiumId;
            TemporaryToken = temporaryToken;
            Name = name;
            Email = email;
            Cpf = cpf;
            IsResident = isResident;
            ResidenceType = residenceType;
            ApartmentBlock = apartmentBlock;
            ResidenceNumber = residenceNumber;
            Password = password;
        }
    }
}
