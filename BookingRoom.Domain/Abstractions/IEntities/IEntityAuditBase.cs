namespace BookingRoom.Domain.Abstractions.IEntities
{
    public interface IEntityAuditBase<Tkey> : IEntityBase<Tkey>, IAuditable
    {
    }
}
