namespace BookingRoom.Application.Dtos.AuthenServiceDto
{
    public class AuthenServiceInputDto
    {
    }

    public class RegisterAsyncInputDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { set; get; }
    }

    public class ExternalLoginByGoogleAccountAsyncInputDto
    {
        public string? IdToken { get; set; }
        public string? Provider { get; set; }
    }
}
