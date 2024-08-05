using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterface;
using BookingRoom.Application.Common.Result;
using BookingRoom.Application.Common.Constants;
using BookingRoom.Domain.Abstractions;
using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.RepositoryInterface;

namespace BookingRoom.Application.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        public BuildingService(IUnitOfWork unitOfWork, IBuildingRepository buildingRepository) : base(unitOfWork)
        {
            _buildingRepository = buildingRepository;
        }

        public Task<ServiceResult> DeleteServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> FindByIdServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _buildingRepository.GetAllAsync();
        }

        public async Task<ServiceResult> InsertServiceAsync(Building entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                _buildingRepository.Insert(entity);
                await _unitOfWork.SaveChangeAsync();
                return new ServiceResult
                {
                    StatusCode = HttpCodeConstant.Success,
                    Data = null,
                    DevMsg = "Insert Success",
                    UserMsg = "Thanh Cong"
                };
            }catch (Exception)
            {
                throw;
            }
        }

        public Task<ServiceResult> UpdateServiceAsync(Building entity)
        {
            throw new NotImplementedException();
        }
    }
}
