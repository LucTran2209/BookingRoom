using BookingRoom.Domain.Abstractions.IRepositories;
using BookingRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Persistence.RepositoryInterface
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        /// <summary>
        /// Find Entity by its Email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> FindByEmailAsync(string email);
    }
}
