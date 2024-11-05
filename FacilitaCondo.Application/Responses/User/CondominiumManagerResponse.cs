using FacilitaCondo.Domain.Enums;

namespace FacilitaCondo.Application.Responses
{
    public class CondominiumManagerResponse
    {
        public Guid Id { get; set; }
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public bool IsResident { get; set; }
        public EResidenceType? ResidenceType { get; set; }
        public string? ApartmentBlock { get; set; }
        public int? ResidenceNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
