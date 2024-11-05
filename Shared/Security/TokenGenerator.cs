namespace FacilitaCondo.Shared.Security
{
    public class TokenGenerator
    {
        public string GenerateToken()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        public DateTime GetExpiryTime()
        {
            return DateTime.UtcNow.AddMinutes(15);
        }
    }

}
