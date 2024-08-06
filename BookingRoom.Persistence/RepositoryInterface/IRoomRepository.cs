﻿using BookingRoom.Domain.Abstractions.IRepositories;
using BookingRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Persistence.RepositoryInterface
{
    public interface IRoomRepository : IRepositoryBase<Room, Guid>
    {
        Task<IEnumerable<Room>> GetAllAsync();
    }
}