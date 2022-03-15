using System;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IUserRepository Users { get; }
    IReviewRepository Reviews { get; }
    IProductRepository Products { get; }
    ITagRepository Tags { get; }
    IImageRepository Images { get; }
    ICommentRepository Comments { get; }
    ILikeRepository Likes { get; }
    IUserGradeRepository UserGrades { get; }
    Task<int> CompleteAsync();
}