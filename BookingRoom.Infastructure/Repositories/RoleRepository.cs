using BookingRoom.Domain.Entities;
using BookingRoom.Infastructure.Abstraction;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace BookingRoom.Infastructure.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FindByIdAsync Find Role by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> FindByIdAsync(Guid id)
        {
            try
            {
                Role? role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Id.Equals(id));
                return role;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Insert a Role to Database
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(Role entity)
        {
            try
            {
                _dbContext.AddAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update information a role
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Role entity)
        {
            try
            {
                _dbContext.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
