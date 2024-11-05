using FacilitaCondo.Application.Commands;
using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Queries;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterCondominiumManager;
using FacilitaCondo.Domain.Enums;
using FacilitaCondo.Shared.Exceptions;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class RegisterCondominiumManagerUseCase : BaseUseCase, IRegisterCondominiumManagerUseCase
    {
        public RegisterCondominiumManagerUseCase(IMediator mediator) : base(mediator) { }

        public async Task<RegisterCondominiumManagerResponseDTO> Execute(RegisterCondominiumManagerRequest request)
        {
            if (request.IsResident == true)
            {
                if (request.ResidenceType == null)
                {
                    throw new DomainException("ResidenceType is required when IsResident is true.");
                }

                if (request.ResidenceNumber <= 0)
                {
                    throw new DomainException("ResidenceNumber is required when IsResident is true.");
                }

                if (request.ResidenceType == EResidenceType.Apartment && string.IsNullOrEmpty(request.ApartmentBlock))
                {
                    throw new DomainException("ApartmentBlock is required when ResidenceType is Apartment.");
                }
            }

            var email = await mediator.Send(new GetEmailByTokenQuery(request.TemporaryToken));

            var validTemporaryToken = await mediator.Send(new GetValidTemporaryTokenQuery(request.TemporaryToken));

            if (validTemporaryToken == false)
                throw new DomainException("Token inválido ou expirado.");

            return await mediator.Send(new RegisterCondominiumManagerCommand(request.CondominiumId, 
                                                                             request.TemporaryToken, 
                                                                             request.Name,
                                                                             email,
                                                                             request.Cpf,
                                                                             request.IsResident, 
                                                                             request.ResidenceType, 
                                                                             request.ApartmentBlock, 
                                                                             request.ResidenceNumber, 
                                                                             request.Password));
        }
    }
}
