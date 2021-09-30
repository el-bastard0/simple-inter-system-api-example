using ElBastard0.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElBastard0.Api.Services
{
    public interface IEntityService
    {
        IQueryable<Entity> GetAsync();
        Task<Entity> GetAsync(int id);

        Task<Entity> AddAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity, int id);

        Task DeleteAsync(int id);
    }
}
