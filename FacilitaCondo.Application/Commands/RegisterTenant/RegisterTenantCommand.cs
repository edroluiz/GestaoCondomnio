using FacilitaCondo.Domain.DTOs.RegisterTenant;
using MediatR;

namespace FacilitaCondo.Application.Commands
{
    public class RegisterTenantCommand : IRequest<RegisterTenantResponseDTO>
    {

        public Guid CondominiumId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterTenantCommand(Guid condominiumId, Guid ownerId, string name, string cpf, string email, string password)
        {
            CondominiumId = condominiumId;
            OwnerId = ownerId;
            Name = name;
            Cpf = cpf;
            Email = email;
            Password = password;
        }
    }
}
