namespace FacilitaCondo.Domain.DTOs
{
    public class GetTemporaryTokenByEmailResponseDTO
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
