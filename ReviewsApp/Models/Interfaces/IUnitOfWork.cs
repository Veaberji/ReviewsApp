using System;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    public IReviewRepository Reviews { get; }
    Task<int> CompleteAsync();
}