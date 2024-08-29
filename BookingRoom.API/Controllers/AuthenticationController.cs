using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.Dtos.AuthenServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace BookingRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenService _authenService;

        public AuthenticationController(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        [HttpPost]
        public async Task<IActionResult> ExternalLoginByGoogleAccount(ExternalLoginByGoogleAccountAsyncInputDto input)
        {
            try
            {
                var output = await _authenService.ExternalLoginByGoogleAccountAsync(input);
                return StatusCode(output.StatusCode, output);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
