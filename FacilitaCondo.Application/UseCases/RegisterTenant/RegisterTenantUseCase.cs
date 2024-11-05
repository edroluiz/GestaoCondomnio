using FacilitaCondo.Application.Commands;
using FacilitaCondo.Application.Interfaces.RegisterTenant;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Domain.DTOs.RegisterTenant;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class RegisterTenantUseCase : BaseUseCase, IRegisterTenantUseCase
    {
        public RegisterTenantUseCase(IMediator mediator) : base(mediator) { }

        public async Task<RegisterTenantResponseDTO> Execute(RegisterTenantRequest request)
        {
            return await mediator.Send(new RegisterTenantCommand(request.CondominiumId, 
                                                                 request.OwnerId, 
                                                                 request.Name, 
                                                                 request.Cpf, 
                                                                 request.Email, 
                                                                 request.Password));
        }
    }
}
