using FacilitaCondo.Application.Interfaces;
using FacilitaCondo.Application.Queries;
using FacilitaCondo.Application.Requests;
using FacilitaCondo.Application.Responses;
using MediatR;

namespace FacilitaCondo.Application.UseCases
{
    public class GetAccessTokenUseCase : BaseUseCase, IGetAccessTokenUseCase
    {
        public GetAccessTokenUseCase(IMediator mediator) : base(mediator) { }

        public async Task<GetAccessTokenResponse?> Execute(GetAccessTokenRequest request)
        {
            var command = new GetAccessTokenQuery(request.Email, request.Password);
            return await mediator.Send(command);
        }
    }
}
