using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Create(TEntity entity);
        Task<int> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        ICollection<TEntity> ReadAll();
        Task<ICollection<TEntity>> ReadAllAsync(CancellationToken cancellationToken);
        TEntity ReadById(object id);
        Task<TEntity> ReadByIdAsync(object id, CancellationToken cancellationToken);
        int Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        IQueryable<TEntity> Query();
    }
}
