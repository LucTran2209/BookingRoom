using System.Net;

namespace BookingRoom.Application.Common.Constants
{
    public static class HttpCodeConstant
    {
        /// <summary>
        /// HttpStatus Code Success
        /// </summary>
        public const int Success = (int)HttpStatusCode.OK;

        /// <summary>
        /// HttpStatus Code BadRequest
        /// </summary>
        public const int BadRequest = (int)HttpStatusCode.BadRequest;

        /// <summary>
        /// HttpStatus Code NotFound
        /// </summary>
        public const int NotFound = (int)HttpStatusCode.NotFound;

        /// <summary>
        /// HttpStatus Code BadGateway
        /// </summary>
        public const int BadGateway = (int)HttpStatusCode.BadGateway;
    }
}
