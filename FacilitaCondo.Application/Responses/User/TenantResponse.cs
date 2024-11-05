namespace FacilitaCondo.Application.Responses
{
    public class TenantResponse
    {
        public Guid Id { get; set; }
        public Guid CondominiumId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
