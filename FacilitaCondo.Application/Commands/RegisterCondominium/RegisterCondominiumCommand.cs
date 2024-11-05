using FacilitaCondo.Domain.DTOs.RegisterCondominium;
using MediatR;

namespace FacilitaCondo.Application.Commands.RegisterCondominium
{
    public class RegisterCondominiumCommand : IRequest<RegisterCondominiumResponseDTO>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public int NumberOfUnits { get; set; }
        public string ManagerEmail { get; set; }
        public string ContactNumber { get; set; }

        public RegisterCondominiumCommand(string name, string address, int addressNumber, int numberOfUnits, string managerEmail, string contactNumber)
        {
            Name = name;
            Address = address;
            AddressNumber = addressNumber;
            NumberOfUnits = numberOfUnits;
            ManagerEmail = managerEmail;
            ContactNumber = contactNumber;
        }
    }
}
