using FacilitaCondo.Domain.Enums;

namespace FacilitaCondo.Application.Responses
{
    public class OwnerResponse
    {
        public Guid Id { get; set; }
        public Guid CondominiumId { get; set; }
        public Guid CondominiumManagerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public EResidenceType ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int ResidenceNumber { get; set; }
        public bool HasTenant { get; set; }
        public string? TenantEmail { get; set; }
    }
}
