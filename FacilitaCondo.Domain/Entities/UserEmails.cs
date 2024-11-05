using FacilitaCondo.Domain.Enums;
using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class UserEmails : Entity
    {
        public Guid CondominiumId { get; set; }
        public string Email { get; set; }
        public EUserType UserType { get; set; }
    }
}
