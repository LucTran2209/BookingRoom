using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Domain.Abstractions;

namespace BookingRoom.Domain.Entities
{
    public class Room : EntityAuditBase<Guid>
    {
        public string? RoomName { get; set; }
        public Guid BuildingId { get; set; }
        public Building Building { get; set; }

    }
}
