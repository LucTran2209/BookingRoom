namespace BookingRoom.Application.DependencyInjection.Options
{
    public class JwtConfig
    {
        public string? ValidAudience { get; set; }
        public string? ValidIssuer { get; set; }
        public string? Secret { get; set; }
    }
}
