using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Domain.Entities;
using BookingRoom.Infastructure.Abstraction;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;

namespace BookingRoom.Infastructure.Repository
{
    public class BuildingRepository : BaseRepository, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Insert(Building entity)
        {
            try
            {
                _dbContext.Buildings.Add(entity);
            }catch (Exception)
            {
                throw;
            }
        }
        public void Delete(Building entity)
        {
            throw new NotImplementedException();
        }

        public Task<Building> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Building entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Building>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
