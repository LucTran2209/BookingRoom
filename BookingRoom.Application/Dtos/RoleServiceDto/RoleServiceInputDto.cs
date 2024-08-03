using System.ComponentModel.DataAnnotations;

namespace BookingRoom.Application.Dtos.RoleServiceDto
{
    public class RoleServiceInputDto
    {
    }

    public class InsertServiceAsyncInputDto
    {
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; } = null!;
        public string RoleDescription { get; set; } = null!;
    }
}
