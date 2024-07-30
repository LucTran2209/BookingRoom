using BookingRoom.Domain.Abstractions;
using BookingRoom.Persistence;
using BookingRoom.Persistence.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Infastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
     
        public UnitOfWork(ApplicationDbContext dbContext)                        
        {
            _dbContext = dbContext;     
        }

        public async ValueTask DisposeAsync()
        {
            if (_dbContext != null)
            {
                // Giải phóng các tài nguyên được quản lý bất đồng bộ
                await _dbContext.DisposeAsync();
            }
        }

        public async Task SaveChangeAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
