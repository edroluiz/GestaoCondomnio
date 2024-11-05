using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class TemporaryTokens : Entity
    {
        //public Guid CondominiumId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
