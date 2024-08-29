using BookingRoom.Application.Common.Result;
using BookingRoom.Application.Dtos.AuthenServiceDto;
using Google.Apis.Auth;

namespace BookingRoom.Application.Abstraction.ServiceInterfaces
{
    public interface IAuthenService
    {
        /// <summary>
        /// Register a new account
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> RegisterAsync(RegisterAsyncInputDto inputDto);

        /// <summary>
        /// Login by UserName and Password
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> LoginByUsernamePasswordAsync(LoginByUsernamePasswordAsyncInputDto inputDto);

        /// <summary>
        /// Using Google account to login
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task<ServiceResult> ExternalLoginByGoogleAccountAsync(ExternalLoginByGoogleAccountAsyncInputDto inputDto);
    }
}
