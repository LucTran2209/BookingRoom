using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Domain.Abstractions.IRepositories;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Persistence.RepositoryInterface
{
    public interface IBuildingRepository : IRepositoryBase<Building, Guid>
    {
        Task<IEnumerable<Building>> GetAllAsync();
    }
}
