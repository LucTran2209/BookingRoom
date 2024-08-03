using BookingRoom.Domain.Abstractions.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Domain.Entities
{
    public class UserRoles : IAuditable 
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
        public DateTimeOffset CreatedDate { get ; set ; }
        public DateTimeOffset? LastModifiedDate { get ; set ; }
        public Guid CreatedBy { get ; set ; }
        public Guid? ModifiedBy { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTimeOffset? DeletedAt { get ; set ; }
    }
}
