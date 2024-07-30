using BookingRoom.Domain.Abstractions;

namespace BookingRoom.Domain.Entities
{
    public class User : EntityBase<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Dob { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; } = null!;
    }
}
