using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterface;
using BookingRoom.Application.Common.Constants;
using BookingRoom.Application.Common.Result;
using BookingRoom.Domain.Abstractions;
using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.RepositoryInterface;

namespace BookingRoom.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork,
                              IProductRepository productRepository) : base(unitOfWork)
        {
            _productRepository = productRepository;
        }



        public Task<ServiceResult> DeleteServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> FindByIdServiceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> InsertServiceAsync(Product entity)
        {
            try
            {
                entity.Id = new Guid();
                _productRepository.Insert(entity);
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

        public Task<ServiceResult> UpdateServiceAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
