using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VendingMachine.Services.Interfaces.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> CreateRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> Remove(TEntity entity);
    }
}
