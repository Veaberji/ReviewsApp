using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using System.Threading.Tasks;

namespace ReviewsApp.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
    }
    public IUserRepository Users { get; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}