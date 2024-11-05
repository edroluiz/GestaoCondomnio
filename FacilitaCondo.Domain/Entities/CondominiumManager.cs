using FacilitaCondo.Domain.Enums;
using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class CondominiumManager : User
    {
        public Guid CondominiumId { get; set; }
        public bool IsResident { get; set; }
        public EResidenceType? ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int? ResidenceNumber { get; set; }
    }
}
