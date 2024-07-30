using BookingRoom.Domain.Abstractions.IEntities;

namespace BookingRoom.Domain.Abstractions
{
    public abstract class EntityAuditBase<Tkey> : EntityBase<Tkey>, IEntityAuditBase<Tkey>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
