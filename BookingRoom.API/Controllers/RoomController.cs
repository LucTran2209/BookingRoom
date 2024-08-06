using BookingRoom.Application.Abstraction.ServiceInterface;
using BookingRoom.Application.Common.Result;
using BookingRoom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingRoom.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllAsync();
                return rooms;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting rooms.");
                return Enumerable.Empty<Room>();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] Room room)
        {
            try
            {
                var result = await _roomService.InsertServiceAsync(room);
                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a room.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
