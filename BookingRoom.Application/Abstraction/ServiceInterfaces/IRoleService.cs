using BookingRoom.Application.Common.Result;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Entities;

namespace BookingRoom.Application.Abstraction.ServiceInterfaces
{
    public interface IRoleService
    {
        /// <summary>
		/// Insert or Update a Role
		/// </summary>
		/// <param name="entity">Entity to check </param>
		/// <returns>Service result ( sucsess or failed with all details )</returns>
		Task<ServiceResult> InsertUpdateServiceAsync(InsertUpdateServiceAsyncInputDto inputDto);
		
    }
}
