using ElBastard0.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElBastard0.Api.Services
{
    internal class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly MyDbContext _dbContext;

        public EntityService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var tmp = new TEntity { Id = id };
            _dbContext.Set<TEntity>().Attach(tmp);
            _dbContext.Set<TEntity>().Remove(tmp);

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<TEntity> GetAsync() => _dbContext.Set<TEntity>();

        public Task<TEntity> GetAsync(int id)
        {
            return _dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, int id)
        {
            var attachedEntity = _dbContext.Set<TEntity>().Attach(entity);
            attachedEntity.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            return attachedEntity.Entity;
        }

    }
}
