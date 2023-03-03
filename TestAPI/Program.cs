using DatabaseContext;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<BelissimoDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped(typeof(IGenericRepositoryAsync<>),typeof(GenericRepositoryAsync<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFoodOrderService, FoodOrderService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
