using ReviewsApp.Models.Common;
using ReviewsApp.Models.MainReview;
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
    Task<int> CompleteAsync();
    void RemoveLike(Like like, User user, Review review);
    Task AddLike(Like like, User user, Review review);
}