namespace FacilitaCondo.Shared.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            this.CreatedDate = DateTime.Now;
        }
    }
}
