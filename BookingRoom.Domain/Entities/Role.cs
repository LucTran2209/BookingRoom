using BookingRoom.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Domain.Entities
{
    public class Role : EntityAuditBase<Guid>
    {
        public string RoleName { get; set; } = null!;
        public string RoleDescription { get; set; } = null!;
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
