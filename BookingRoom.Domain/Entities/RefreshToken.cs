using BookingRoom.Domain.Abstractions.IEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingRoom.Domain.Entities
{
    public class RefreshToken : IDateTracking
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public required string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTimeOffset CreatedDate { get ; set ; } = DateTimeOffset.Now;
        public DateTimeOffset? LastModifiedDate { get ; set ; }
        public virtual User? User { set; get; }

    }
}
