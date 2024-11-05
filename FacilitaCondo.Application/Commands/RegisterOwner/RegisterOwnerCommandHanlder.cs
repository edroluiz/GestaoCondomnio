using FacilitaCondo.Domain.DTOs.RegisterOwner;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Infrastructure.Services;
using FacilitaCondo.Shared.Exceptions;
using FacilitaCondo.Shared.Security;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterOwnerCommandHanlder : IRequestHandler<RegisterOwnerCommand, RegisterOwnerResponseDTO>
    {
        private readonly IUserRepository _repository;

        public RegisterOwnerCommandHanlder(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterOwnerResponseDTO> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = new Owner
            {
                CondominiumId = request.CondominiumId,
                CondominiumManagerId = request.CondominiumManagerId,
                Name = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                ResidenceType = request.ResidenceType,
                ApartmentBlock = request.ApartmentBlock,
                ResidenceNumber = request.ResidenceNumber,
                HasTenant = request.HasTenant,
                TenantEmail = request.TenantEmail,
                Password = SecurePasswordHasher.Hash(request.Password)
            };

            var registeredOwner = await _repository.RegisterOwner(owner);

            return registeredOwner; 
        }
    }
}
