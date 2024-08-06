using BookingRoom.Domain.Entities;
using BookingRoom.Infastructure.Abstraction;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Infastructure.Repository
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<Room> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Insert(Room entity)
        {
            try
            {
                _dbContext.Rooms.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
