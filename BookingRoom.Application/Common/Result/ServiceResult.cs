using System.Net;

namespace BookingRoom.Application.Common.Result
{
    public class ServiceResult
    {
        /// <summary>
        /// api status Code
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }
        /// <summary>
        /// Developer message
        /// </summary>
        public string? DevMsg { get; set; }
        /// <summary>
        /// user message
        /// </summary>
        public string? UserMsg { get; set; }
        /// <summary>
        /// API data 
        /// </summary>
        public object? Data { get; set; }
    }
}
