using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Domain.Abstractions;

namespace BookingRoom.Domain.Entities
{
    public class Building : EntityAuditBase<Guid>
    {
        public int BuildingId { get; set; } = 0;
        public string BuildingName { get; set; } = null;

        public string Address { get; set; } = null;
    }
}
