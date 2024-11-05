namespace FacilitaCondo.Application.Responses
{
    public class GetTemporaryTokenByEmailResponse
    {
        public string Token { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
