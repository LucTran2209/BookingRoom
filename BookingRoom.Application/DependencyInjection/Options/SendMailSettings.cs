namespace BookingRoom.Application.DependencyInjection.Options
{
    public class SendMailSettings
    {
        public string Mail { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}
