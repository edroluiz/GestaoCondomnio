using FacilitaCondo.Application.Commands;
using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Queries;
using FacilitaCondo.Domain.DTOs;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class SendTemporaryTokenToEmailUseCase : BaseUseCase, ISendTemporaryTokenToEmailUseCase
    {
        public SendTemporaryTokenToEmailUseCase(IMediator mediator) : base(mediator) { }

        public async Task<bool> Execute(string email)
        {
            return await mediator.Send(new SendTemporaryTokenToEmailCommand(email));
        }
    }
}
