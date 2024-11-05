using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class Tenant : User
    {
        public Guid CondominiumId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
