using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace ReviewsApp.Data;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Reviews = new ReviewRepository(_context);
        Products = new ProductRepository(_context);
        Tags = new TagRepository(_context);
    }
    public IUserRepository Users { get; }
    public IReviewRepository Reviews { get; }
    public IProductRepository Products { get; }
    public ITagRepository Tags { get; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_context is not null)
        {
            await _context.DisposeAsync().ConfigureAwait(false);
        }

        _context = null;
    }
}