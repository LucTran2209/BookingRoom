using BookingRoom.Domain.Abstractions;

namespace BookingRoom.Domain.Entities
{
    public class Category : EntityAuditBase<Guid>
    {
        public string CategoryName { get; set; } = null!;
    }
}
