using Microsoft.EntityFrameworkCore;
using PromoCodesAspNetCoreWebApi.Application.Common.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Persistence.PromoCodesAspNetCoreWebApiDb
{
    public class PromoCodesAspNetCoreWebApiDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PromoCodesAspNetCoreWebApiDbContext dbContext;

        public PromoCodesAspNetCoreWebApiDbRepository(
            PromoCodesAspNetCoreWebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return dbContext.SaveChanges();
        }

        public async Task<int> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public int Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return dbContext.SaveChanges();
        }

        public async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<TEntity> Query()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }

        public ICollection<TEntity> ReadAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public async Task<ICollection<TEntity>> ReadAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public TEntity ReadById(object id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> ReadByIdAsync(object id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public int Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
