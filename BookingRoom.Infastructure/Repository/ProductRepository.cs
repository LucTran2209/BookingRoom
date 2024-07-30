using BookingRoom.Domain.Entities;
using BookingRoom.Infastructure.Abstraction;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;

namespace BookingRoom.Infastructure.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Insert(Product entity)
        {
            try
            {
                _dbContext.Products.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
