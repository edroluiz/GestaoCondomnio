using FacilitaCondo.Domain.Enums;

namespace FacilitaCondo.Application.Requests
{
    public class RegisterCondominiumManagerRequest
    {
        public Guid CondominiumId { get; set; }
        public string TemporaryToken { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public bool IsResident { get; set; }
        public EResidenceType? ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int? ResidenceNumber { get; set; }
        public string Password { get; set; }
    }
}