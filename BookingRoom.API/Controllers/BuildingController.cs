using BookingRoom.Application.Abstraction.ServiceInterface;
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
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BuildingController> _logger;
        private readonly IBuildingService _buildingService;

        public BuildingController(ILogger<BuildingController> logger, IBuildingService buildingService)
        {
            _logger = logger;
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Building>> GetBuildings()
        {
            try
            {
                var buildings = await _buildingService.GetAllAsync();
                return buildings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting buildings.");
                return Enumerable.Empty<Building>();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding([FromBody] Building building)
        {
            try
            {
                var result = await _buildingService.InsertServiceAsync(building);
                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a building.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
