using MediatR;

namespace FacilitaCondo.Application.Queries
{
    public class GetEmailByTokenQuery : IRequest<string>
    {
        public string Token { get; set; }

        public GetEmailByTokenQuery(string token)
        {
            Token = token;
        }
    }
}
