namespace BookingRoom.Domain.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// Call Save change from db context
        /// </summary>
        /// <returns></returns>
        Task SaveChangeAsync();

    }
}
