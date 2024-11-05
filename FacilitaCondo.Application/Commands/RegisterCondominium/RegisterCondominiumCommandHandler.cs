using FacilitaCondo.Domain.DTOs.RegisterCondominium;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Domain.Repository;
using MediatR;

namespace FacilitaCondo.Application.Commands.RegisterCondominium
{
    public class RegisterCondominiumCommandHandler : IRequestHandler<RegisterCondominiumCommand, RegisterCondominiumResponseDTO>
    {
        private readonly IUserRepository _repository;

        public RegisterCondominiumCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RegisterCondominiumResponseDTO> Handle(RegisterCondominiumCommand request, CancellationToken cancellationToken)
        {
            var condominium = new Condominium
            {
                Name = request.Name,
                Address = request.Address,
                AddressNumber = request.AddressNumber,
                NumberOfUnits = request.NumberOfUnits,
                ManagerEmail = request.ManagerEmail,
                ContactNumber = request.ContactNumber
            };

            return await _repository.RegisterCondominium(condominium);
        }
    }
}
