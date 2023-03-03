using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Baskets;
using Services.Exceptions;
using Services.Extentions;
using Services.IServies.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Baskets
{
    public class BasketService : IBasketService
    {

        private readonly IGenericRepositoryAsync<Basket> basketRepository;

        private readonly IMapper mapper;

        public BasketService(IGenericRepositoryAsync<Basket> basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async ValueTask<BasketForViewDTO> CreateAsync(BasketForCreationDTO basketForCreationDTO)
        {
           // var alreadyBasket = await basketRepository.GetAsync(???);

            var basket = await basketRepository.CreateAsync(mapper.Map<Basket>(basketForCreationDTO));

            await basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(basket);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await basketRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Basket Not Delete");

            await basketRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<BasketForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Basket, bool>> expression = null)
        {
           var baskets = basketRepository.GetAllAsync(expression:expression,isTracking:false);

            if (baskets == null)
                throw new BelissimoCloneWPFException(404, "Basket Not Found");

            return mapper.Map<IEnumerable<BasketForViewDTO>>(await baskets.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<BasketForViewDTO> GetAsync(Expression<Func<Basket, bool>> expression)
        {
           var basket = await basketRepository.GetAsync(expression);

            if (basket == null)
                throw new BelissimoCloneWPFException(404, "Basket Not Found");

            return mapper.Map<BasketForViewDTO>(basket);
        }

        public async ValueTask<BasketForViewDTO> UpdateAsync(int id, BasketForUpdateDTO basketForUpdateDTO)
        {
            var basketData = await basketRepository.GetAsync(c => c.Id == id);

            if (basketData == null)
                throw new BelissimoCloneWPFException(404, "Basket Not Update");

            basketData = basketRepository.Update(mapper.Map(basketForUpdateDTO, basketData));

            await basketRepository.SaveChangesAsync();

            return mapper.Map<BasketForViewDTO>(basketData);
        }
    }
}
