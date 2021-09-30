using ElBastard0.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElBastard0.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntityService<TEntity>
        where TEntity: class
    {
        IQueryable<TEntity> GetAsync();
        Task<TEntity> GetAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, int id);

        Task DeleteAsync(int id);
    }
}
