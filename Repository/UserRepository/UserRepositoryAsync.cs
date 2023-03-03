using DatabaseContext;
using Domian.Entities;
using IRepository.IUserRepository;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>,IUserRepositoryAsync
    {
        public UserRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
