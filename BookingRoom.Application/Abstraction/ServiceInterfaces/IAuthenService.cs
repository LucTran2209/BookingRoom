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
        /// <returns></returns>
        Task<ServiceResult> RegisterAsync(RegisterAsyncInputDto inputDto);

        /// <summary>
        /// Login by UserName and Password
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult> LoginAsync();

        /// <summary>
        /// Using Google account to login
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult> ExternalLoginByGoogleAccountAsync(ExternalLoginByGoogleAccountAsyncInputDto inputDto);

        ///// <summary>
        ///// Veryfy token
        ///// </summary>
        ///// <param name="idToken"></param>
        ///// <returns></returns>
        //Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken);
    }
}
