using DatabaseContext.Data;
using Domian.Entities;
using IRepository.IGenericRepository;
using IRepository.IOrderRepository;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public class OrderRepositoryAsync:GenericRepositoryAsync<Order>,IOrderRepositoryAsync
    {
        public OrderRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
