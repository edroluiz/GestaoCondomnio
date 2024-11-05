using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Shared.Security;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterCondominiumManagerCommandHandler : IRequestHandler<RegisterCondominiumManagerCommand, RegisterCondominiumManagerResponseDTO>
    {
        private readonly IUserRepository _repository;

        public RegisterCondominiumManagerCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterCondominiumManagerResponseDTO> Handle(RegisterCondominiumManagerCommand request, CancellationToken cancellationToken)
        {
            var condominiumManager = new CondominiumManager
            {
                CondominiumId = request.CondominiumId,
                Name = request.Name,
                Email = request.Email,
                Cpf = request.Cpf,
                IsResident = request.IsResident,
                ResidenceType = request.ResidenceType,
                ApartmentBlock = request.ApartmentBlock,
                ResidenceNumber = request.ResidenceNumber,
                Password = SecurePasswordHasher.Hash(request.Password)
            };

            return await _repository.RegisterCondominiumManager(condominiumManager);
        }
    }
}
