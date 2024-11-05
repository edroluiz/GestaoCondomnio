namespace FacilitaCondo.Application.Requests
{
    public class RegisterTenantRequest
    {
        public Guid CondominiumId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
