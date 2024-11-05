using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Queries;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class GetValidTemporaryTokenUseCase : BaseUseCase, IGetValidTemporaryTokenUseCase
    {
        public GetValidTemporaryTokenUseCase(IMediator mediator) : base(mediator) { }

        public async Task<bool> Execute(string token)
        {
            return await mediator.Send(new GetValidTemporaryTokenQuery(token));
        }
    }
}
