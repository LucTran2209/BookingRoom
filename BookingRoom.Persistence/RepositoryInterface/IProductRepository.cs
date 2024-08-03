using BookingRoom.Domain.Abstractions.IRepositories;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Persistence.RepositoryInterface
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {

    }
}
