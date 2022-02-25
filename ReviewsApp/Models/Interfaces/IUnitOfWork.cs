using System;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    public IUserRepository Users { get; }
    public IReviewRepository Reviews { get; }
    public IProductRepository Products { get; }
    Task<int> CompleteAsync();
}