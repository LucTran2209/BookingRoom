using AutoMapper;
using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.Common.Constants;
using BookingRoom.Application.Common.Result;
using BookingRoom.Application.Dtos.RoleServiceDto;
using BookingRoom.Domain.Abstractions;
using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.RepositoryInterface;

namespace BookingRoom.Application.Services
{
    public class RoleService : BaseService, IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper,
                           IRoleRepository roleRepository) : base(unitOfWork, mapper)
        {
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Insert or Update Role's Information 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ServiceResult> InsertUpdateServiceAsync(InsertUpdateServiceAsyncInputDto inputDto)
        {
            try
            {
                // Declarations Service Result
                ServiceResult result = new ServiceResult()
                {
                    Data = null,
                    StatusCode = HttpCodeConstant.Success,
                    DevMsg = "",
                    UserMsg = "",
                };

                Role existRole = new Role();
                bool IsSuccess= false;

                if (inputDto.Id != Guid.Empty)
                {
                    existRole = await _roleRepository.FindByIdAsync(inputDto.Id);
                }

                if (existRole == null)
                {
                    Role roleNew = _mapper.Map<Role>(inputDto);
                    roleNew.Id = Guid.NewGuid();
                    roleNew.CreatedDate = DateTime.Now;

                    IsSuccess = _roleRepository.Insert(roleNew);
                }
                else
                {
                    existRole.RoleName = inputDto.RoleName;
                    existRole.RoleDescription = inputDto.RoleDescription;
                    existRole.LastModifiedDate = DateTime.Now;

                    IsSuccess = _roleRepository.Update(existRole);
                }

                if (IsSuccess) await _unitOfWork.SaveChangeAsync();

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Data = null,
                    StatusCode = HttpCodeConstant.BadRequest,
                    DevMsg = ex.Message,
                    UserMsg = "False",
                };
            }
        }      
    }
}
