using BookingRoom.Domain.Entities;
using BookingRoom.Infastructure.Abstraction;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace BookingRoom.Infastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                User? user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            try
            {
                User? user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id.Equals(id));
                return user;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public bool Insert(User entity)
        {
            try
            {
                _dbContext.Users.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(User entity)
        {
            try
            {
                _dbContext.Users.Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
