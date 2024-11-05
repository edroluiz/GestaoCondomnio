using FacilitaCondo.Domain.Enums;

namespace FacilitaCondo.Application.Requests
{
    public class RegisterOwnerRequest
    {
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
        public string Password { get; set; }
    }
}
