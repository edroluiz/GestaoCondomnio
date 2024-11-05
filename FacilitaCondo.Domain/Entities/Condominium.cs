using FacilitaCondo.Shared.Entities;

namespace FacilitaCondo.Domain.Entities
{
    public class Condominium : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public int NumberOfUnits { get; set; }
        public string ManagerEmail { get; set; }
        public string ContactNumber { get; set; }
    }
}
