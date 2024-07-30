using BookingRoom.Application.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Application.Abstraction
{
    public interface IBaseService<TEntity> 
    {
        /// <summary>
        /// Find entity by Id and map data to ServiceResutl
        /// </summary>
        /// <param name="id">Id for entity searching </param>
        /// <returns>Service result ( sucsess or failed with all details )</returns>
        /// <exception cref="NotFoundException">Data not found</exception>
        ///  created by: LucTD
        ///  created at: 07/30/2024
        Task<ServiceResult> FindByIdServiceAsync(Guid id);

        /// <summary>
		/// Check is all entity' properies is valid -> insert
		/// </summary>
		/// <param name="entity">Entity to check </param>
		/// <returns>Service result ( sucsess or failed with all details )</returns>
		///  created by: LucTD
        ///  created at: 07/30/2024
		Task<ServiceResult> InsertServiceAsync(TEntity entity);

        /// <summary>
        /// Check is all entity' properies is valid -> update
        /// </summary>
        /// <param name="entity">Entity to check </param>
        /// <returns>Service result ( sucsess or failed with all details )</returns>
        ///  created by: LucTD
        ///  created at: 07/30/2024
        Task<ServiceResult> UpdateServiceAsync(TEntity entity);

        /// <summary>
        /// Check is all entity' properies is valid -> delete
        /// </summary>
        /// <param name="entity">Entity to check </param>
        /// <returns>Service result ( sucsess or failed with all details )</returns>
        ///  created by: LucTD
        ///  created at: 07/30/2024
        Task<ServiceResult> DeleteServiceAsync(Guid id);
    }
}
