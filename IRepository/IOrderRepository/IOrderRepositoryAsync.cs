using Domian.Entities;
using IRepository.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IOrderRepository
{
    public interface IOrderRepositoryAsync : IGenericRepositoryAsync<Order>
    {
    }
}
