using BookingRoom.Domain.Abstractions.IRepositories;
using BookingRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Persistence.RepositoryInterface
{
    public interface IRoleRepository : IRepositoryBase<Role, Guid>
    {
        /// <summary>
        /// Get Roles By User's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Role>> GetRolesByUserIdAsync(Guid id);
    }
}
