using System.Net;

namespace BookingRoom.Application.Common.Constants
{
    public static class HttpCodeConstant
    {
        /// <summary>
        /// HttpStatus Code Success
        /// </summary>
        public const HttpStatusCode Success = HttpStatusCode.OK;

        /// <summary>
        /// HttpStatus Code BadRequest
        /// </summary>
        public const HttpStatusCode BadRequest = HttpStatusCode.BadRequest;

        /// <summary>
        /// HttpStatus Code NotFound
        /// </summary>
        public const HttpStatusCode NotFound = HttpStatusCode.NotFound;

        /// <summary>
        /// HttpStatus Code BadGateway
        /// </summary>
        public const HttpStatusCode BadGateway = HttpStatusCode.BadGateway;
    }
}
