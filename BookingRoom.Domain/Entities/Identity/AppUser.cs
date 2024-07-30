//using BookingTable.Domain.Abstractions.IEntities;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookingTable.Domain.Entities.Identity
//{
//    public class AppUser : IdentityUser<Guid>, IAuditable
//    {
//        public string? FirstName { get; set; }
//        public string? LastName { get; set; }
//        public DateTime? DateOfBirth { get; set; }
//        public bool IsDirector { get; set; }
//        public bool IsHeadOfDepartment { get; set; }
//        public Guid? ManagerId { get; set; }
        
//        public virtual ICollection<IdentityUserRole<Guid>>? UserRoles { get; set; }

//        public DateTimeOffset CreatedDate { get ; set ; }
//        public DateTimeOffset? LastModifiedDate { get ; set ; }
//        public Guid CreatedBy { get ; set ; }
//        public Guid? ModifiedBy { get ; set ; }
//        public bool IsDeleted { get ; set ; }
//        public DateTimeOffset? DeletedAt { get ; set ; }
//    }
//}
