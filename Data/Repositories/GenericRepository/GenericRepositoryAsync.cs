using DatabaseContext.Data;
using Domian.Commons;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.GenericRepository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : Auditable
    {
        private readonly BelissimoDbContext dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepositoryAsync(BelissimoDbContext dBcontext)
        {
           this.dbContext = dBcontext;
           this.dbSet = dbContext.Set<T>();
        }

        public async ValueTask<T> CreateAsync(T entity)
        => (await dbSet.AddAsync(entity)).Entity;
          
        public async ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            if (entity == null)
            {
                return false;
            }
            else
            {
                dbSet.Remove(entity);
                return true;
            }
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true)
        {
            IQueryable<T> query = expression is null? dbSet : dbSet.Where(expression);

            if(includes != null)
                foreach (var include in includes)
                if(!string.IsNullOrEmpty(include))
                        query = query.Include(include);

            if (!isTracking)
               query = query.AsNoTracking();

            return query;
        }

        public async ValueTask<T> GetAsync(Expression<Func<T, bool>> expression,string[] includes = null)
        => await GetAllAsync(expression, includes, false).FirstOrDefaultAsync();

        public T Update(T entity) 
           => dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync()
        => await dbContext.SaveChangesAsync();
        
    }
}
