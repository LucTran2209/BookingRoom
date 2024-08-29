using BookingRoom.Application.Common.Result;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Application.Abstraction.ServiceInterfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// InsertUpdateServiceAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns>ServiceResult</returns>
		Task<ServiceResult> InsertUpdateServiceAsync(InsertUpdateServiceAsyncInputDto inputDto);
		
    }
}
