using BookingRoom.Domain.Abstractions.IEntities;

namespace BookingRoom.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
