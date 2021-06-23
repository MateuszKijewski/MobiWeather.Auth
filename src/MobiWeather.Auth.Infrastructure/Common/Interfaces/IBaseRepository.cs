using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiWeather.Auth.Infrastructure.Common.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdNoTrackingAsync(Guid id);

        IQueryable<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);

        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);
    }
}
