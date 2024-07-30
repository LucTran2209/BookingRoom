namespace BookingRoom.Domain.Abstractions.IRepositories
{
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// Find Entity by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindByIdAsync(TKey id);

        /// <summary>
        /// Add a Entity to Database
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Update data of Entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Deactive a Entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
