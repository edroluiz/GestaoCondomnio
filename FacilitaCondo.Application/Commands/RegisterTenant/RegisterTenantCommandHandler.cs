using FacilitaCondo.Domain.DTOs.RegisterTenant;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Domain.Repository;
using FacilitaCondo.Shared.Security;
using MediatR;

namespace FacilitaCondo.Application.Commands.RegisterTenant
{
    public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand, RegisterTenantResponseDTO>
    {
        private readonly IUserRepository _repository;

        public RegisterTenantCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterTenantResponseDTO> Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant
            {
                CondominiumId = request.CondominiumId,
                OwnerId = request.OwnerId,
                Name = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                Password = SecurePasswordHasher.Hash(request.Password)
            };

            return await _repository.RegisterTenant(tenant);
        }
    }
}
