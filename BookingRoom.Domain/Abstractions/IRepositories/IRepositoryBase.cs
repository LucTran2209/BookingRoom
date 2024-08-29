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
        bool Insert(TEntity entity);

        /// <summary>
        /// Update data of Entity
        /// </summary>
        /// <param name="entity"></param>
        bool Update(TEntity entity);

        /// <summary>
        /// Deactive a Entity
        /// </summary>
        /// <param name="entity"></param>
        bool Delete(TEntity entity);
    }
}
