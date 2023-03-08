using IRepository.IGenericRepository;
using IRepository.IUserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.GenericRepository;
using Repository.UserRepository;
using Services.IServies.Attachments;
using Services.IServies.Baskets;
using Services.IServies.Branchies;
using Services.IServies.Categories;
using Services.IServies.FoodOrders;
using Services.IServies.Foods;

using Services.IServies.Orders;
using Services.IServies.Users;
using Services.Mappers;
using Services.Services.Attachments;

using Services.Services.Baskets;
using Services.Services.Branchies;
using Services.Services.Categories;
using Services.Services.FoodOrders;
using Services.Services.Foods;
using Services.Services.Orders;
using Services.Services.Users;
using System.Text;

namespace TestAPI.Extensions
{
    public static  class ServiceExtensions
    {
        public static void AddCustomerService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFoodOrderService, FoodOrderService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
        }
    }
}
