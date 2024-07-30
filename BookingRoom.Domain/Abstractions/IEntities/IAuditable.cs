namespace BookingRoom.Domain.Abstractions.IEntities
{
    public interface IAuditable : IDateTracking, IUserTracking, ISoftDelete
    {

    }
}
