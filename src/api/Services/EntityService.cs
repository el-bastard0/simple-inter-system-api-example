using ElBastard0.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElBastard0.Api.Services
{
    internal class EntityService : IEntityService
    {
        private readonly MyDbContext _dbContext;

        public EntityService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            var result = await _dbContext.Entities.AddAsync(entity);

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var tmp = new Entity { Id = id };
            _dbContext.Entities.Attach(tmp);
            _dbContext.Entities.Remove(tmp);

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<Entity> GetAsync() => _dbContext.Entities;

        public Task<Entity> GetAsync(int id)
        {
            return _dbContext.Entities
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Entity> UpdateAsync(Entity entity, int id)
        {
            var attachedEntity = _dbContext.Entities.Attach(entity);
            attachedEntity.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            return attachedEntity.Entity;
        }
    }
}
