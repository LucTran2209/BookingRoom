using BookingRoom.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BookingRoom.Persistence
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public EFUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbContext GetDbContext() => _context;

        public async Task SaveChangeAsync() => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    }
}
