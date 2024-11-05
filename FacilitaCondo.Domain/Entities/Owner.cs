using FacilitaCondo.Domain.Enums;
using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class Owner : User
    {
        public Guid CondominiumId { get; set; }
        public Guid CondominiumManagerId {  get; set; }
        public EResidenceType ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int ResidenceNumber { get; set; }
        public bool HasTenant { get; set; }
        public string? TenantEmail { get; set; }
    }
}
