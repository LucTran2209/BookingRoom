using AutoMapper;
using BookingRoom.Domain.Abstractions;

namespace BookingRoom.Application.Abstraction
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }   
    }
}
