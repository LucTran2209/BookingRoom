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

        public bool Delete(Role entity)
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

        public async Task<IEnumerable<Role>> GetRolesByUserIdAsync(Guid id)
        {
            try
            {
                var rolesQuery = from role in _dbContext.Roles
                                 join userRoles in _dbContext.UserRoles on role.Id equals userRoles.RoleId
                                 where userRoles.UserId == id
                                 select new Role
                                 {
                                     Id = role.Id,
                                     RoleName = role.RoleName,
                                     RoleDescription = role.RoleDescription,
                                 };
                IEnumerable<Role> roles = await rolesQuery.ToListAsync();

                return roles;
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
        public bool Insert(Role entity)
        {
            try
            {
                _dbContext.Roles.AddAsync(entity);
                return true;
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
        public bool Update(Role entity)
        {
            try
            {
                _dbContext.Roles.Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
