using MediatR;

namespace FacilitaCondo.Application.Queries
{
    public class GetValidTemporaryTokenQuery : IRequest<bool>
    {
        public string Token { get; set; }

        public GetValidTemporaryTokenQuery(string token)
        {
            Token = token;
        }
    }
}
