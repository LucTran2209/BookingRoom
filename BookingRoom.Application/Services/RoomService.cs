using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterface;
using BookingRoom.Application.Common.Constants;
using BookingRoom.Application.Common.Result;
using BookingRoom.Domain.Abstractions;
using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Application.Services
{
    public class RoomService : BaseService, IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IUnitOfWork unitOfWork, IRoomRepository roomRepository) : base(unitOfWork)
        {
            _roomRepository = roomRepository;
        }

        public Task<ServiceResult> DeleteServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> FindByIdServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _roomRepository.GetAllAsync();
        }

        public async Task<ServiceResult> InsertServiceAsync(Room entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                _roomRepository.Insert(entity);
                await _unitOfWork.SaveChangeAsync();
                return new ServiceResult
                {
                    StatusCode = HttpCodeConstant.Success,
                    Data = null,
                    DevMsg = "Insert Success",
                    UserMsg = "Thanh Cong"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ServiceResult> UpdateServiceAsync(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
