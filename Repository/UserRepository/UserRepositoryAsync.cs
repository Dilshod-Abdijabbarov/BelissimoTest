using DatabaseContext;
using Domian.Entities;
using IRepository.IUserRepository;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>,IUserRepositoryAsync
    {
        private readonly BelissimoDbContext belissimoDbContext;
        public UserRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {
            belissimoDbContext = dbContext;
        }
        public virtual IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression, bool tracking) =>
            !tracking ?
            belissimoDbContext.Set<User>()
                .Where(expression) :
            belissimoDbContext.Set<User>()
                .Where(expression);

        public async Task<User> LoginAsync(string login, string password, bool traking, CancellationToken cancellationToken = default) =>
             await FindByCondition(x => x.Login.Equals(login) && x.Password.Equals(password), traking)
             .SingleOrDefaultAsync(cancellationToken);
    }
}
