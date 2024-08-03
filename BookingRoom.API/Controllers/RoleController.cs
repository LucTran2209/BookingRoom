using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsyncRole([FromBody] InsertServiceAsyncInputDto input)
        {
            try
            {
                var output = await _roleService.InsertServiceAsync(input);
                return StatusCode(output.StatusCode, output);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
