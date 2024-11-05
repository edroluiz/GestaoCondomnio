namespace FacilitaCondo.Shared.Entities
{
    public abstract class User
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            this.CreatedDate = DateTime.Now;
        }
    }
}
