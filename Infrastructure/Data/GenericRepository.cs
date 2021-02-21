using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreContext context;
        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id) => await context.Set<TEntity>().FindAsync(id);

        public async Task<IReadOnlyList<TEntity>> ListAllAsync() => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec) => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec) => await ApplySpecification(spec).ToListAsync();

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec) => 
            SpecificationEvaluator<TEntity>.GetQuery(context.Set<TEntity>().AsQueryable(), spec);
    }
}