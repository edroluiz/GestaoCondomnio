using FacilitaCondo.Application.Responses;
using MediatR;

namespace FacilitaCondo.Application.Queries
{
    public class GetAccessTokenQuery : IRequest<GetAccessTokenResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetAccessTokenQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
