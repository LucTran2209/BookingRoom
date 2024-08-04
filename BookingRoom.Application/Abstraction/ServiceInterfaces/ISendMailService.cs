using BookingRoom.Application.Dtos.SendMailServiceDto;
using System.Runtime.CompilerServices;

namespace BookingRoom.Application.Abstraction.ServiceInterfaces
{
    public interface ISendMailService
    {
        /// <summary>
        /// SendMailWelcomAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<bool> SendMailWelcomAsync(SendMailWelcomAsyncInputDto inputDto);
    }
}
