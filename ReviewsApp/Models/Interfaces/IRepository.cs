using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReviewsApp.Models.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        EntityEntry<TEntity> Remove(TEntity entity);
    }
}
