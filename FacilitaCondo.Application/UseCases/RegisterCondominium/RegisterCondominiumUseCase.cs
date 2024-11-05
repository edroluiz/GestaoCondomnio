using FacilitaCondo.Application.Commands;
using FacilitaCondo.Application.Commands.RegisterCondominium;
using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterCondominium;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Shared.Exceptions;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class RegisterCondominiumUseCase : BaseUseCase, IRegisterCondominiumUseCase
    {
        public RegisterCondominiumUseCase(IMediator mediator) : base(mediator) { }

        public async Task<RegisterCondominiumResponseDTO> Execute(RegisterCondominiumRequest request)
        {
            var command = new RegisterCondominiumCommand(request.Name,
                                                         request.Address,
                                                         request.AddressNumber,
                                                         request.NumberOfUnits,
                                                         request.ManagerEmail,
                                                         request.ContactNumber);

            var condominiumResponse = await mediator.Send(command);

            if (condominiumResponse == null)
            {
                throw new DomainException("Failed to register condominium");
            }

            var condominium = new Condominium
            {
                Id = condominiumResponse.CondominiumId,
                Name = request.Name,
                Address = request.Address,
                AddressNumber = request.AddressNumber,
                NumberOfUnits = request.NumberOfUnits,
                ManagerEmail = request.ManagerEmail,
                ContactNumber = request.ContactNumber
            };

            var userEmail = new List<UserEmails>
            {
                new UserEmails
                {
                    CondominiumId = condominium.Id,
                    Email = request.ManagerEmail,
                    UserType = Domain.Enums.EUserType.CondominiumManager
                }
            };

            var registerUserEmail = await mediator.Send(new RegisterUserEmailsCommand(userEmail));

            if (!registerUserEmail)
            {
                throw new DomainException("Failed to register user emails");
            }

            return condominiumResponse;           
        }
    }
}
