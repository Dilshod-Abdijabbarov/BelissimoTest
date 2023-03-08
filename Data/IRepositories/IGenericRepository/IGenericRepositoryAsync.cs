using Domian.Commons;
using System.Linq.Expressions;

namespace IRepository.IGenericRepository
{
    public interface IGenericRepositoryAsync<T> where T : Auditable
    {
        public ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true);
        public ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        public T Update(T entity);
        public ValueTask<T> CreateAsync(T entity);
        public ValueTask SaveChangesAsync();

    }
}
