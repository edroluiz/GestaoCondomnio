using FacilitaCondo.Application.Commands;
using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterOwner;
using FacilitaCondo.Domain.Entities;
using FacilitaCondo.Shared.Exceptions;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class RegisterOwnerUseCase : BaseUseCase, IRegisterOwnerUseCase
    {
        public RegisterOwnerUseCase(IMediator mediator) : base(mediator) { }

        public async Task<RegisterOwnerResponseDTO> Execute(RegisterOwnerRequest request)
        {
            var command = new RegisterOwnerCommand(request.CondominiumId,
                                                    request.CondominiumManagerId,
                                                    request.Name,
                                                    request.Cpf,
                                                    request.Email,
                                                    request.ResidenceType,
                                                    request.ApartmentBlock,
                                                    request.ResidenceNumber,
                                                    request.HasTenant,
                                                    request.TenantEmail,
                                                    request.Password);

            var ownerResponse = await mediator.Send(command);

            if (ownerResponse == null)
            {
                throw new DomainException("Failed to register Owner");
            }

            if (request.HasTenant == true)
            {
                if (!string.IsNullOrEmpty(request.TenantEmail))
                {
                    var userEmail = new List<UserEmails>
                    {
                        new UserEmails
                        {
                            CondominiumId = request.CondominiumId,
                            Email = request.TenantEmail,
                            UserType = Domain.Enums.EUserType.Tenant
                        }
                    };

                    var registerUserEmail = await mediator.Send(new RegisterUserEmailsCommand(userEmail));

                    if (!registerUserEmail)
                    {
                        throw new DomainException("Failed to register user email");
                    }
                }
                else
                {
                    throw new DomainException("TenantEmail inválido.");
                }

            }

            return ownerResponse;
        }
    }
}
