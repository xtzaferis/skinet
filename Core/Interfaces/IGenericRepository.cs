using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
         Task<TEntity> GetByIdAsync(int id);
         Task<IReadOnlyList<TEntity>> ListAllAsync();
         Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec);
         Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);
    }
}