namespace FacilitaCondo.Application.Requests
{
    public class RegisterCondominiumRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public int NumberOfUnits { get; set; }
        public string ManagerEmail { get; set; }
        public string ContactNumber { get; set; }
    }
}